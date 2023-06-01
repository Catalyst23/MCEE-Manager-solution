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
using System.Text.RegularExpressions;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using ControlzEx.Theming;

namespace MetroStyleBaseApp
{
    public partial class Etapa1 : MetroWindow
    {
        public Etapa1()
        {
            InitializeComponent();
        }

        int N;
        int Nmh; // nmb of engines;
        double cosF; // cosine 
        double nrand;
        decimal Ki;
        decimal Smcoef;

        void ZeroCalculations()
        {
            
            if (Int32.TryParse(currentIndex, out N)) { }
            
            Nmh = 30 - N; // (15)  
            cosF = 0.85; // (16)     
            nrand = 0.8;  // (17)   
            Ki = 0 + (decimal)N / 100; // (18) 
            Smcoef = 1 - Ki; //(19)
        }

        double Pel_motoare,    Icurent, Icurent_rounded;     
        double Pcons;          double Pcons_rounded;
        double P_aparenta;     double P_aparenta_rounded;

        void CalcsConversion()
        {
            int number10000kw = 0;  int number250kw = 0;     int number10kw = 0;            
            int number5000kw = 0;   int number150kw = 0;     int number5kw = 0;          
            int number1000kw = 0;   int number100kw = 0;     int number3kw = 0;    
            int number600kw = 0;    int number60kw = 0;      int number1kw = 0;    
            int number500kw = 0;    int number25kw = 0;      int numberTot = 0;      
            int number400kw = 0;    int number15kw = 0;      int Pmot = 0;

            // intermediary values for conversion :

            string intermediary_number_10000kw = null;  string intermediary_number_250kw = null;     string intermediary_number_10kw = null;            
            string intermediary_number_5000kw = null;   string intermediary_number_150kw = null;     string intermediary_number_5kw = null;          
            string intermediary_number_1000kw = null;   string intermediary_number_100kw = null;     string intermediary_number_3kw = null;    
            string intermediary_number_600kw = null;    string intermediary_number_60kw = null;      string intermediary_number_1kw = null;    
            string intermediary_number_500kw = null;    string intermediary_number_25kw = null;           
            string intermediary_number_400kw = null;    string intermediary_number_15kw = null;

            intermediary_number_10000kw = nr_engi_10000.Text;  intermediary_number_100kw = nr_engi_100.Text;
            intermediary_number_5000kw = nr_engi_5000.Text;    intermediary_number_60kw = nr_engi_60.Text;
            intermediary_number_1000kw = nr_engi_1000.Text;    intermediary_number_25kw = nr_engi_25.Text;
            intermediary_number_600kw = nr_engi_600.Text;      intermediary_number_15kw = nr_engi_15.Text;
            intermediary_number_500kw = nr_engi_500.Text;      intermediary_number_10kw = nr_engi_10.Text;
            intermediary_number_400kw = nr_engi_400.Text;      intermediary_number_5kw = nr_engi_5.Text;
            intermediary_number_250kw = nr_engi_250.Text;      intermediary_number_3kw = nr_engi_3.Text;
            intermediary_number_150kw = nr_engi_150.Text;      intermediary_number_1kw = nr_engi_1.Text;


            //
            number10000kw = Convert.ToInt32(Regex.Replace(intermediary_number_10000kw, "[^0-9]", ""));
            number5000kw = Convert.ToInt32(Regex.Replace(intermediary_number_5000kw, "[^0-9]", ""));
            number1000kw = Convert.ToInt32(Regex.Replace(intermediary_number_1000kw, "[^0-9]", ""));
            number600kw = Convert.ToInt32(Regex.Replace(intermediary_number_600kw, "[^0-9]", ""));
            number500kw = Convert.ToInt32(Regex.Replace(intermediary_number_500kw, "[^0-9]", ""));
            number400kw = Convert.ToInt32(Regex.Replace(intermediary_number_400kw, "[^0-9]", ""));
            number250kw = Convert.ToInt32(Regex.Replace(intermediary_number_250kw, "[^0-9]", ""));
            number150kw = Convert.ToInt32(Regex.Replace(intermediary_number_150kw, "[^0-9]", ""));
            number100kw = Convert.ToInt32(Regex.Replace(intermediary_number_100kw, "[^0-9]", ""));
            number60kw = Convert.ToInt32(Regex.Replace(intermediary_number_60kw, "[^0-9]", ""));
            number25kw = Convert.ToInt32(Regex.Replace(intermediary_number_25kw, "[^0-9]", ""));
            number15kw = Convert.ToInt32(Regex.Replace(intermediary_number_15kw, "[^0-9]", ""));
            number10kw = Convert.ToInt32(Regex.Replace(intermediary_number_10kw, "[^0-9]", ""));
            number5kw = Convert.ToInt32(Regex.Replace(intermediary_number_5kw, "[^0-9]", ""));
            number3kw = Convert.ToInt32(Regex.Replace(intermediary_number_3kw, "[^0-9]", ""));
            number1kw = Convert.ToInt32(Regex.Replace(intermediary_number_1kw, "[^0-9]", ""));
            
            numberTot = number10000kw + number5000kw + number1000kw + number600kw + number500kw + number400kw
               + number250kw + number150kw + number100kw + number60kw + number25kw + number15kw + number10kw
                + number5kw + number3kw + number1kw;

            Pmot = (number10000kw * 10000) + (number5000kw * 5000) + (number1000kw * 1000) + (number600kw * 600) + (number500kw * 500) + (number400kw * 400)
               + (number250kw * 250) + (150 * number150kw) + (100 * number100kw) + (60 * number60kw) + (25 * number25kw)
               + (15 * number15kw) + (10 * number10kw) + (5 * number5kw) + (3 * number3kw) + (1 * number1kw);

            Pel_motoare = Pmot / 0.8;
            Pel_txt.Text = Pel_motoare.ToString();
            Pcons = (double)Ki * (double)Smcoef * Pel_motoare;
            Pcons_rounded =  Math.Round(Pcons, 2);
            Pc_text.Text = Pcons_rounded.ToString();
            P_aparenta = Pcons / 0.85 ;
            P_aparenta_rounded = Math.Round(P_aparenta, 2);
            Sc_text.Text = P_aparenta_rounded.ToString();
            Icurent = (P_aparenta) / (Math.Sqrt(3) * 6);
            Icurent_rounded = Math.Round(Icurent, 2);
            Ic_txt.Text = Icurent_rounded.ToString();
            ki_txt.Text = Ki.ToString();
            ks_txt.Text = Smcoef.ToString();
            cosF_txt.Text = cosF.ToString();

        }

        string currentIndex;
        

        private void Select_Engines_Click(object sender, RoutedEventArgs e)
        {
            ZeroCalculations();
            TypeEngines();
            CalcsConversion();
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentIndex = ((ListBoxItem)listBox2.SelectedValue).Content.ToString();  // convert objects from listBox to string
            if (Int32.TryParse(currentIndex, out N)) { }
            
        }


        void TypeEngines()
        {
            engine_number.Text = Nmh.ToString();

            if (Nmh == 29)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 2";
                nr_engi_500.Text = "x 2"; nr_engi_400.Text = "x 2"; nr_engi_250.Text = "x 2"; nr_engi_150.Text = "x 2";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 28)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 2"; nr_engi_400.Text = "x 2"; nr_engi_250.Text = "x 2"; nr_engi_150.Text = "x 2";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 27)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 2"; nr_engi_250.Text = "x 2"; nr_engi_150.Text = "x 2";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 26)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 2"; nr_engi_150.Text = "x 2";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 25)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 2";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 24)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 2"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 23)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 2"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 22)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 2"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 21)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 2";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 20)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 2"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 19)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 2"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 18)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 1"; nr_engi_3.Text = "x 2"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 17)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 1"; nr_engi_3.Text = "x 1"; nr_engi_1.Text = "x 2";
            }

            if (Nmh == 16)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 1"; nr_engi_3.Text = "x 1"; nr_engi_1.Text = "x 1";
            }

            if (Nmh == 15)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 1"; nr_engi_3.Text = "x 1"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 14)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 1"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 13)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 1"; nr_engi_5.Text = "x 0"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 12)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 1";
                nr_engi_10.Text = "x 0"; nr_engi_5.Text = "x 0"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 11)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 1"; nr_engi_15.Text = "x 0";
                nr_engi_10.Text = "x 0"; nr_engi_5.Text = "x 0"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 10)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 1"; nr_engi_25.Text = "x 0"; nr_engi_15.Text = "x 0";
                nr_engi_10.Text = "x 0"; nr_engi_5.Text = "x 0"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

            if (Nmh == 9)
            {
                nr_engi_10000.Text = "x 1"; nr_engi_5000.Text = "x 1"; nr_engi_1000.Text = "x 1"; nr_engi_600.Text = "x 1";
                nr_engi_500.Text = "x 1"; nr_engi_400.Text = "x 1"; nr_engi_250.Text = "x 1"; nr_engi_150.Text = "x 1";
                nr_engi_100.Text = "x 1"; nr_engi_60.Text = "x 0"; nr_engi_25.Text = "x 0"; nr_engi_15.Text = "x 0";
                nr_engi_10.Text = "x 0"; nr_engi_5.Text = "x 0"; nr_engi_3.Text = "x 0"; nr_engi_1.Text = "x 0";
            }

        }

        // main menu + collection for window status

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<MainWindow>())
            {
                try
                {
                    if (App.main.WindowState == WindowState.Minimized)
                        App.main.WindowState = WindowState.Normal;
                }

                catch { }

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


        // image launcher

        public static Example_img example;

        private void example_Mono(object sender, RoutedEventArgs e)
        {
            // check if open handlers 

            if (IsWindowOpen<Example_img>())
            {
                try
                {
                    if (App.example.WindowState == WindowState.Minimized)
                        App.example.WindowState = WindowState.Normal;
                }

                catch { }

                finally
                {
                    App.example.Show();
                    App.example.Activate();
                }
            }

            else
            {
                App.example = new Example_img();
                App.example.Closed += example_Closed;
                App.example.Show();
                App.example.Activate();
            }
        }
        void example_Closed(object sender, EventArgs e)
        {
            App.example = null;
        }

        // engine management launcher

        public static Etapa1_EngineManagement engines_mg;

        private void Engine_Management(object sender, RoutedEventArgs e)
        {
            if (IsWindowOpen<Etapa1_EngineManagement>())
            {
                try
                {
                    if (App.engines_mg.WindowState == WindowState.Minimized)
                        App.engines_mg.WindowState = WindowState.Normal;
                }

                catch { }

                finally
                {
                    App.engines_mg.Show();
                    App.engines_mg.Activate();
                }
            }

            else
            {
                App.engines_mg = new Etapa1_EngineManagement();
                App.engines_mg.Closed += engines_mg_Closed;
                App.engines_mg.Show();
                App.engines_mg.Activate();
            }
        }
        void engines_mg_Closed(object sender, EventArgs e) 
        {
            App.engines_mg = null;
        } 

    }
}
