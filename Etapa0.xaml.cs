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
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using ControlzEx.Theming;




namespace MetroStyleBaseApp
{
    // <summary>
    // Interaction logic for Etapa0.xaml
    // </summary>
    public partial class Etapa0 : MetroWindow
    {
        public Etapa0()
        {
            InitializeComponent();
        }

        string currentIndex;

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           currentIndex = ((ListBoxItem)listBox2.SelectedValue).Content.ToString();  // convert objects from listBox to string
        }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int N ;

            if (Int32.TryParse(currentIndex, out N)) { }

            int D = 0;
            string kVA = " kVA";
            string km = " km";
            string m = " m "; string then = "; ";
            D = 15 + N;   // se calculeaza (1)
            LEA.Text = D.ToString() + km;
            int Sk = 3000 + (150 * N);
            Nod_scc.Text = Sk.ToString();
            decimal SixKV = (decimal)1 + ((decimal)N / (decimal)10);     // cast is redundant, still - I wanted to be sure of that :))
            G_bar_6kV.Text = SixKV.ToString();
            decimal GenPow = 3 + 3 * ((decimal)N / (decimal)10);  // (4)
            GeneratorPow.Text = GenPow.ToString();
            decimal Nu = 4 + ((decimal)N / 3); // (5)
            decimal NuA = decimal.Round(Nu, 2);             // approximates decimal values to 2 characters after point
            Urban.Text = NuA.ToString();
            decimal Nr = 5 + ((decimal)N / 10); // (6)          
            Rural.Text = Nr.ToString();  // (6)
            decimal Nptu = 6 + ((decimal)N / 2); //(7)
            NrDU.Text = Nptu.ToString(); // (7)
            decimal Nptr = 10 + ((decimal)N / 2); //(8)
            NrDR.Text = Nptr.ToString(); // (8)
            decimal Lu = 2 + ((decimal)N / 10); //(9)
            L_DU.Text = Lu.ToString() + km; // (9)
            decimal Lr = 10 + N; //(10)
            L_DR.Text = Lr.ToString() + km; // (10)
            int Sptu = 400; //(11)
            P_PTU.Text = Sptu.ToString() + kVA;  // (11)
            int Sptr = 100; //(12)
            P_PTR.Text = Sptr.ToString() + kVA;  // (12)
            int Nh = 1; //(13)
            Nh_text.Text = Nh.ToString(); //(13)
            int Lh = 20 + N; int lh = 10 + N; // (14)
            Hall_dim.Text = Lh.ToString() + m + then + lh.ToString() + m; // (14)
            int Nmh = 30 - N; // (15)
            EnginesNm.Text = Nmh.ToString(); // (15)
            double cosF = 0.85; // (16)
            cosPhi.Text = cosF.ToString(); // (16)
            double nrand = 0.8;  // (17)
            Nrand.Text = nrand.ToString(); // (17)
            decimal Ki = 0 + (decimal)N / 100; // (18)
            Kmcoef.Text = Ki.ToString();  // (18)
            decimal Smcoef = 1 - Ki; //(19)
            Ksim.Text = Smcoef.ToString();  // (19)
        }

        
        // collection for window's status

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        // Main Menu

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<MainWindow>())
            {
                try
                {
                    if (App.main.WindowState == WindowState.Minimized)
                        App.main.WindowState = WindowState.Normal;
                }

                catch  { }
                
                finally
                {
                    App.main.Show();
                    App.main.Activate();
                }
               
            }

            else
            {
                App.main = new MainWindow();
                App.main.Closed += main_Closed;
                App.main.Show();
                App.main.Activate();
            }
        }
        

        void main_Closed(object sender, EventArgs e)
        {
            App.main = null;
        }


    }
}
