using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using MahApps.Metro.Controls;



namespace MetroStyleBaseApp
{
    

    public partial class Etapa1_EngineManagement : MetroWindow
    {

      

        // collection for window state check

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        Container WindowContainer = null;

        public Etapa1_EngineManagement()  // entry point
        {
            InitializeComponent();

            borderArea.Child = null;
            if (WindowContainer == null)
            {
                WindowContainer = new Container();

            }
            borderArea.Child = WindowContainer;

        }
        
        

        private void CreateHeavyCentreWindow(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<Etapa1_HeavyCentre>())
            {
                try
                {
                    if (App.one_heavy_centre.WindowState == WindowState.Minimized)
                        App.one_heavy_centre.WindowState = WindowState.Normal;
                }

                catch { }

                finally
                {
                    App.one_heavy_centre.Show();
                    App.one_heavy_centre.Activate();
                }
            }

            else
            {
                App.one_heavy_centre = new Etapa1_HeavyCentre();
                App.one_heavy_centre.Closed += one_heavy_centre_Closed;
                App.one_heavy_centre.Show();
                App.one_heavy_centre.Activate();
            }
        }

        void one_heavy_centre_Closed(object sender, EventArgs e)
        {
            App.one_heavy_centre = null;
        }


        string currentIndex; int N;
        private void Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentIndex = ((ListBoxItem)listBox2.SelectedValue).Content.ToString();  // convert objects from listBox to string
            if (int.TryParse(currentIndex, out N)) { }

            int Lh = 20 + N; int lh = 10 + N;
            string m = " m ";
            lung.Text = Lh.ToString() + m; lat.Text = lh.ToString() + m;
            btnHallDraw.IsEnabled = true;
        }

        private void EngineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CheckSelection(bool IsCheck)
        {
            btnHall.IsChecked = IsCheck;
            btnEngine.IsChecked = IsCheck;
            //btnDelete.IsChecked = IsCheck;      //   this function is disabled but could be required if work scenario is changed from Window dispatcher
        }  


    }

}



