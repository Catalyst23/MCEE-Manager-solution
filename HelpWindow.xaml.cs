using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using ControlzEx.Theming;

namespace MetroStyleBaseApp
{

    public partial class HelpWindow : MetroWindow
    {

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
            App.help.ShowDialog();
            System.Windows.Threading.Dispatcher.Run();
        }
        
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void Ok_dialog(object sender, RoutedEventArgs e)
        { 

            if (App.help.Dispatcher.CheckAccess())
                App.help.Close();
            else
                App.help.Dispatcher.Invoke(DispatcherPriority.Normal, new ThreadStart(App.help.Close));

        }
    }
}
