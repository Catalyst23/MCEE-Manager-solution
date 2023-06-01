using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

using MahApps.Metro.Controls;

namespace MetroStyleBaseApp
{


    public partial class App : Application
    {

        public static MainWindow main;
        public static Etapa0 zero;
        public static Etapa1 one;
        public static Example_img example;
        public static CloseDialog close;
        public static HelpWindow help;
        public static Etapa1_EngineManagement engines_mg;
        public static Etapa1_HeavyCentre one_heavy_centre;

        

        // start the main app
        void Application_Startup(object sender, StartupEventArgs e)
        {

            main = new MainWindow();
            main = (MainWindow)Application.Current.MainWindow;
            main.Show();
            main.Activate();

            StartupHelpWindow();    // enable startup Help Window

        }


        // new thead for help-window

        private void NewWindowHandler(object sender, RoutedEventArgs e)
        {
            Thread newWindowThread = new Thread(new ThreadStart(ThreadStartingPoint));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void ThreadStartingPoint()
        {
            HelpWindow help = new HelpWindow();
            help.Show();
            System.Windows.Threading.Dispatcher.Run();
        }

        void CloseWindowSafe(HelpWindow help) // unused code
        {
            if (help.Dispatcher.CheckAccess())
                help.Close();
            else
                help.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(help.Close));
        }

        //[STAThread]
        void StartupHelpWindow()
        {

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                App.help = new HelpWindow();
                App.help.Activate();
                App.help.ShowDialog();
            };
            
        }
    }
}
