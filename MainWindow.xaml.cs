using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using ControlzEx.Theming;
using System.Threading;
using System.Windows.Threading;

namespace MetroStyleBaseApp
{


    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
 
        }

        // collection for window state check

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }


        // Dialog close all windows
        public static CloseDialog close;

        private void close_Click(object sender, RoutedEventArgs e)
        {
            App.close = new CloseDialog();
            App.close.ShowDialog();

        }
      
        // Etapa 0 Launcher     

        public static Etapa0 zero; 

        private void Etapa0_Click(object sender, RoutedEventArgs e)
        {
            // check if open handlers 

            if (IsWindowOpen<Etapa0>())
            {
                try
                {
                    if (App.zero.WindowState == WindowState.Minimized)
                        App.zero.WindowState = WindowState.Normal;
                }

                catch { }

                finally
                {
                    App.zero.Show();
                    App.zero.Activate();
                }       
            }

            else
            {
                App.zero = new Etapa0();
                App.zero.Closed += zero_Closed;
                App.zero.Show();
                App.zero.Activate();
            }
        }
        void zero_Closed(object sender, EventArgs e)
        {
            App.zero = null;
        }

        // Etapa1 Launcher

        public static Etapa1 one;
       
        private void Etapa1_Click(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<Etapa1>())
            {
                try
                {
                    if (App.one.WindowState == WindowState.Minimized)
                        App.one.WindowState = WindowState.Normal;
                }

                catch { }

                finally
                {
                    App.one.Show();
                    App.one.Activate();
                }
            }

            else
            {
                App.one = new Etapa1();
                App.one.Closed += one_Closed;
                App.one.Show();
                App.one.Activate();
            }
        }

        void one_Closed(object sender, EventArgs e)
        {
            App.one = null;
        }

    }
}
