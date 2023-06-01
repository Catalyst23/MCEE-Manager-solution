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

    public partial class Etapa1_HeavyCentre : MetroWindow
    {
        public Etapa1_HeavyCentre()
        {
            InitializeComponent();
        }

        #region MainMenuFunc
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        private void ReturnMainMenu(object sender, RoutedEventArgs e)
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

        #endregion

        #region variables

        double XG_6kV_result = 0;
        double XG_6kV_result_half = 0;

        double M1 = 0; string string_M1 = "0";
        double M2 = 0; string string_M2 = "0";
        double M3 = 0; string string_M3 = "0";
        double M4 = 0; string string_M4 = "0";
        double M5 = 0; string string_M5 = "0";
        double M6 = 0; string string_M6 = "0";
        double M7 = 0; string string_M7 = "0";

        double X1 = 0; double X2 = 0; double X3 = 0; double X4 = 0; double X5 = 0; double X6 = 0; double X7 = 0;


        double XG_04kV_result = 0;
        double XG_04kV_result_half = 0;

        double FM1 = 0; string string_FM1 = "0";
        double FM2 = 0; string string_FM2 = "0";
        double FM3 = 0; string string_FM3 = "0";
        double FM4 = 0; string string_FM4 = "0";
        double FM5 = 0; string string_FM5 = "0";
        double FM6 = 0; string string_FM6 = "0";
        double FM7 = 0; string string_FM7 = "0";
        double FM8 = 0; string string_FM8 = "0";
        double FM9 = 0; string string_FM9 = "0";
        double FM10 = 0; string string_FM10 = "0";
        double FM11 = 0; string string_FM11 = "0";
        double FM12 = 0; string string_FM12 = "0";
        double FM13 = 0; string string_FM13 = "0";
        double FM14 = 0; string string_FM14 = "0";
        double FM15 = 0; string string_FM15 = "0";
        double FM16 = 0; string string_FM16 = "0";
        double FM17 = 0; string string_FM17 = "0";
        double FM18 = 0; string string_FM18 = "0";
        double FM19 = 0; string string_FM19 = "0";
        double FM20 = 0; string string_FM20 = "0";
        double FM21 = 0; string string_FM21 = "0";
        double FM22 = 0; string string_FM22 = "0";
    

        double FX1 = 0; double FX2 = 0; double FX3 = 0; double FX4 = 0;
        double FX5 = 0; double FX6 = 0; double FX7 = 0; double FX8 = 0;
        double FX9 = 0; double FX10 = 0; double FX11 = 0; double FX12 = 0;
        double FX13 = 0; double FX14 = 0; double FX15 = 0; double FX16 = 0;
        double FX17 = 0; double FX18 = 0; double FX19 = 0; double FX20 = 0; double FX21 = 0; double FX22 = 0;

        double YG_04kV_result = 0;
        double YG_04kV_result_half = 0;

        double YM1 = 0; string string_YM1 = "0";
        double YM2 = 0; string string_YM2 = "0";
        double YM3 = 0; string string_YM3 = "0";
        double YM4 = 0; string string_YM4 = "0";
        double YM5 = 0; string string_YM5 = "0";
        double YM6 = 0; string string_YM6 = "0";
        double YM7 = 0; string string_YM7 = "0";
        double YM8 = 0; string string_YM8 = "0";
        double YM9 = 0; string string_YM9 = "0";
        double YM10 = 0; string string_YM10 = "0";
        double YM11 = 0; string string_YM11 = "0";
        double YM12 = 0; string string_YM12 = "0";
        double YM13 = 0; string string_YM13 = "0";
        double YM14 = 0; string string_YM14 = "0";
        double YM15 = 0; string string_YM15 = "0";
        double YM16 = 0; string string_YM16 = "0";
        double YM17 = 0; string string_YM17 = "0";
        double YM18 = 0; string string_YM18 = "0";
        double YM19 = 0; string string_YM19 = "0";
        double YM20 = 0; string string_YM20 = "0";
        double YM21 = 0; string string_YM21 = "0";
        double YM22 = 0; string string_YM22 = "0";

        double FY1 = 0; string string_FY1 = "0";
        double FY2 = 0; string string_FY2 = "0";
        double FY3 = 0; string string_FY3 = "0";
        double FY4 = 0; string string_FY4 = "0";
        double FY5 = 0; string string_FY5 = "0";
        double FY6 = 0; string string_FY6 = "0";
        double FY7 = 0; string string_FY7 = "0";
        double FY8 = 0; string string_FY8 = "0";
        double FY9 = 0; string string_FY9 = "0";
        double FY10 = 0; string string_FY10 = "0";
        double FY11 = 0; string string_FY11 = "0";
        double FY12 = 0; string string_FY12 = "0";
        double FY13 = 0; string string_FY13 = "0";
        double FY14 = 0; string string_FY14 = "0";
        double FY15 = 0; string string_FY15 = "0";
        double FY16 = 0; string string_FY16 = "0";
        double FY17 = 0; string string_FY17 = "0";
        double FY18 = 0; string string_FY18 = "0";
        double FY19 = 0; string string_FY19 = "0";
        double FY20 = 0; string string_FY20 = "0";
        double FY21 = 0; string string_FY21 = "0";
        double FY22 = 0; string string_FY22 = "0";


        double YG_6kV_result = 0;
        double YG_6kV_result_half = 0;

        double Mtr1 = 0; string string_Mtr1 = "0";
        double Mtr2 = 0; string string_Mtr2 = "0";
        double Mtr3 = 0; string string_Mtr3 = "0";
        double Mtr4 = 0; string string_Mtr4 = "0";
        double Mtr5 = 0; string string_Mtr5 = "0";
        double Mtr6 = 0; string string_Mtr6 = "0";
        double Mtr7 = 0; string string_Mtr7 = "0";

        double Y1 = 0; double Y2 = 0; double Y3 = 0; double Y4 = 0;
        double Y5 = 0; double Y6 = 0; double Y7 = 0;

        double XG = 0; double YG = 0;

        #endregion


        private void CalculateCoords(object sender, RoutedEventArgs e)
        {
            #region X - 6kV engine types

            string_M1 = ((ListBoxItem)engine_XG_6kv_list_1.SelectedValue).Content.ToString();
            if (double.TryParse(string_M1, out M1)) { }

            string_M2 = ((ListBoxItem)engine_XG_6kv_list_2.SelectedValue).Content.ToString();
            if (double.TryParse(string_M2, out M2)) { }

            string_M3 = ((ListBoxItem)engine_XG_6kv_list_3.SelectedValue).Content.ToString();
            if (double.TryParse(string_M3, out M3)) { }

            string_M4 = ((ListBoxItem)engine_XG_6kv_list_4.SelectedValue).Content.ToString();
            if (double.TryParse(string_M4, out M4)) { }

            string_M5 = ((ListBoxItem)engine_XG_6kv_list_5.SelectedValue).Content.ToString();
            if (double.TryParse(string_M5, out M5)) { }

            string_M6 = ((ListBoxItem)engine_XG_6kv_list_6.SelectedValue).Content.ToString();
            if (double.TryParse(string_M6, out M6)) { }

            string_M7 = ((ListBoxItem)engine_XG_6kv_list_7.SelectedValue).Content.ToString();
            if (double.TryParse(string_M7, out M7)) { }

            #endregion

            #region X - 6kV engine coords and calculation formula

            if (double.TryParse(engine_XG_6kv_coord_1.Text, out X1)) { }
            if (double.TryParse(engine_XG_6kv_coord_2.Text, out X2)) { }
            if (double.TryParse(engine_XG_6kv_coord_3.Text, out X3)) { }
            if (double.TryParse(engine_XG_6kv_coord_4.Text, out X4)) { }
            if (double.TryParse(engine_XG_6kv_coord_5.Text, out X5)) { }
            if (double.TryParse(engine_XG_6kv_coord_6.Text, out X6)) { }
            if (double.TryParse(engine_XG_6kv_coord_7.Text, out X7)) { }

            XG_6kV_result_half = (M1 * X1) + (M2 * X2) + (M3 * X3) + (M4 * X4) + (M5 * X5) + (M6 * X6) + (M7 * X7);
            XG_6kV_result = XG_6kV_result_half / (M1 + M2 + M3 + M4 + M5 + M6 + M7);
            Coord_XG_6kv.Text = XG_6kV_result.ToString();

            #endregion

            #region X - 0.4kV engine types

            string_FM1 = ((ListBoxItem)engine_XG_04kv_list_1.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM1, out FM1)) { }

            string_FM2 = ((ListBoxItem)engine_XG_04kv_list_2.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM2, out FM2)) { }

            string_FM3 = ((ListBoxItem)engine_XG_04kv_list_3.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM3, out FM3)) { }

            string_FM4 = ((ListBoxItem)engine_XG_04kv_list_4.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM4, out FM4)) { }

            string_FM5 = ((ListBoxItem)engine_XG_04kv_list_5.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM5, out FM5)) { }

            string_FM6 = ((ListBoxItem)engine_XG_04kv_list_6.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM6, out FM6)) { }

            string_FM7 = ((ListBoxItem)engine_XG_04kv_list_7.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM7, out FM7)) { }

            string_FM8 = ((ListBoxItem)engine_XG_04kv_list_8.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM8, out FM8)) { }

            string_FM9 = ((ListBoxItem)engine_XG_04kv_list_9.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM9, out FM9)) { }

            string_FM10 = ((ListBoxItem)engine_XG_04kv_list_10.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM10, out FM10)) { }

            string_FM11 = ((ListBoxItem)engine_XG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM11, out FM11)) { }

            string_FM12 = ((ListBoxItem)engine_XG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM12, out FM12)) { }

            string_FM13 = ((ListBoxItem)engine_XG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM13, out FM13)) { }

            string_FM14 = ((ListBoxItem)engine_XG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM14, out FM14)) { }

            string_FM11 = ((ListBoxItem)engine_XG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM15, out FM15)) { }

            string_FM12 = ((ListBoxItem)engine_XG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM16, out FM16)) { }

            string_FM13 = ((ListBoxItem)engine_XG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM17, out FM17)) { }

            string_FM14 = ((ListBoxItem)engine_XG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM18, out FM18)) { }

            string_FM11 = ((ListBoxItem)engine_XG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM19, out FM19)) { }

            string_FM12 = ((ListBoxItem)engine_XG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM20, out FM20)) { }

            string_FM13 = ((ListBoxItem)engine_XG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM21, out FM21)) { }

            string_FM14 = ((ListBoxItem)engine_XG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_FM22, out FM22)) { }

            #endregion

            #region X - 0.4kV engine coords and calculation formula

            if (double.TryParse(engine_XG_04kv_coord_1.Text, out FX1)) { }
            if (double.TryParse(engine_XG_04kv_coord_2.Text, out FX2)) { }
            if (double.TryParse(engine_XG_04kv_coord_3.Text, out FX3)) { }
            if (double.TryParse(engine_XG_04kv_coord_4.Text, out FX4)) { }
            if (double.TryParse(engine_XG_04kv_coord_5.Text, out FX5)) { }
            if (double.TryParse(engine_XG_04kv_coord_6.Text, out FX6)) { }
            if (double.TryParse(engine_XG_04kv_coord_7.Text, out FX7)) { }
            if (double.TryParse(engine_XG_04kv_coord_8.Text, out FX8)) { }
            if (double.TryParse(engine_XG_04kv_coord_9.Text, out FX9)) { }
            if (double.TryParse(engine_XG_04kv_coord_10.Text, out FX10)) { }
            if (double.TryParse(engine_XG_04kv_coord_11.Text, out FX11)) { }
            if (double.TryParse(engine_XG_04kv_coord_12.Text, out FX12)) { }
            if (double.TryParse(engine_XG_04kv_coord_13.Text, out FX13)) { }
            if (double.TryParse(engine_XG_04kv_coord_14.Text, out FX14)) { }
            if (double.TryParse(engine_XG_04kv_coord_15.Text, out FX15)) { }
            if (double.TryParse(engine_XG_04kv_coord_16.Text, out FX16)) { }
            if (double.TryParse(engine_XG_04kv_coord_17.Text, out FX17)) { }
            if (double.TryParse(engine_XG_04kv_coord_18.Text, out FX18)) { }
            if (double.TryParse(engine_XG_04kv_coord_19.Text, out FX19)) { }
            if (double.TryParse(engine_XG_04kv_coord_20.Text, out FX20)) { }
            if (double.TryParse(engine_XG_04kv_coord_21.Text, out FX21)) { }
            if (double.TryParse(engine_XG_04kv_coord_22.Text, out FX22)) { }

            XG_04kV_result_half = (FM1 * FX1) + (FM2 * FX2) + (FM3 * FX3) + (FM4 * FX4) + (FM5 * FX5) + (FM6 * FX6) + (FM7 * FX7)
            + (FM8 * FX8) + (FM9 * FX9) + (FM10 * FX10) + (FM11 * FX11) + (FM12 * FX12) + (FM13 * FX13) + (FM14 * FX14) + (FM15 * FX15) + (FM16 * FX16) + (FM17 * FX17) + (FM17 * FX17)
            + (FM18 * FX18) + (FM19 * FX19) + (FM20 * FX20) + (FM21 * FX21) + (FM22 * FX22);

            XG_04kV_result = XG_04kV_result_half / (FM1 + FM2 + FM3 + FM4 + FM5 + FM6 + FM7 + FM8 + FM9 + FM10 + FM11 + FM12 + FM13 + FM14
                + FM15 + FM16 + FM17 + FM18 + FM19 + FM20 + FM21 + FM22);
            Coord_XG_04kv.Text = XG_04kV_result.ToString();

            #endregion

            #region Y - 0.4kV engine types


            string_YM1 = ((ListBoxItem)engine_YG_04kv_list_1.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM1, out YM1)) { }

            string_YM2 = ((ListBoxItem)engine_YG_04kv_list_2.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM2, out YM2)) { }

            string_YM3 = ((ListBoxItem)engine_YG_04kv_list_3.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM3, out YM3)) { }

            string_YM4 = ((ListBoxItem)engine_YG_04kv_list_4.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM4, out YM4)) { }

            string_YM5 = ((ListBoxItem)engine_YG_04kv_list_5.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM5, out YM5)) { }

            string_YM6 = ((ListBoxItem)engine_YG_04kv_list_6.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM6, out YM6)) { }

            string_YM7 = ((ListBoxItem)engine_YG_04kv_list_7.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM7, out YM7)) { }

            string_YM8 = ((ListBoxItem)engine_YG_04kv_list_8.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM8, out YM8)) { }

            string_YM9 = ((ListBoxItem)engine_YG_04kv_list_9.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM9, out YM9)) { }

            string_YM10 = ((ListBoxItem)engine_YG_04kv_list_10.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM10, out YM10)) { }

            string_YM11 = ((ListBoxItem)engine_YG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM11, out YM11)) { }

            string_YM12 = ((ListBoxItem)engine_YG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM12, out YM12)) { }

            string_YM13 = ((ListBoxItem)engine_YG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM13, out YM13)) { }

            string_YM14 = ((ListBoxItem)engine_YG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM14, out YM14)) { }

            string_YM11 = ((ListBoxItem)engine_YG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM15, out YM15)) { }

            string_YM12 = ((ListBoxItem)engine_YG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM16, out YM16)) { }

            string_YM13 = ((ListBoxItem)engine_YG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM17, out YM17)) { }

            string_YM14 = ((ListBoxItem)engine_YG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM18, out YM18)) { }

            string_YM11 = ((ListBoxItem)engine_YG_04kv_list_11.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM19, out YM19)) { }

            string_YM12 = ((ListBoxItem)engine_YG_04kv_list_12.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM20, out YM20)) { }

            string_YM13 = ((ListBoxItem)engine_YG_04kv_list_13.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM21, out YM21)) { }

            string_YM14 = ((ListBoxItem)engine_YG_04kv_list_14.SelectedValue).Content.ToString();
            if (double.TryParse(string_YM22, out YM22)) { }

            #endregion

            #region Y - 0.4kV engine coords and calculation formula

            if (double.TryParse(engine_YG_04kv_coord_1.Text, out FY1)) { }
            if (double.TryParse(engine_YG_04kv_coord_2.Text, out FY2)) { }
            if (double.TryParse(engine_YG_04kv_coord_3.Text, out FY3)) { }
            if (double.TryParse(engine_YG_04kv_coord_4.Text, out FY4)) { }
            if (double.TryParse(engine_YG_04kv_coord_5.Text, out FY5)) { }
            if (double.TryParse(engine_YG_04kv_coord_6.Text, out FY6)) { }
            if (double.TryParse(engine_YG_04kv_coord_7.Text, out FY7)) { }
            if (double.TryParse(engine_YG_04kv_coord_8.Text, out FY8)) { }
            if (double.TryParse(engine_YG_04kv_coord_9.Text, out FY9)) { }
            if (double.TryParse(engine_YG_04kv_coord_10.Text, out FY10)) { }
            if (double.TryParse(engine_YG_04kv_coord_11.Text, out FY11)) { }
            if (double.TryParse(engine_YG_04kv_coord_12.Text, out FY12)) { }
            if (double.TryParse(engine_YG_04kv_coord_13.Text, out FY13)) { }
            if (double.TryParse(engine_YG_04kv_coord_14.Text, out FY14)) { }
            if (double.TryParse(engine_YG_04kv_coord_15.Text, out FY15)) { }
            if (double.TryParse(engine_YG_04kv_coord_16.Text, out FY16)) { }
            if (double.TryParse(engine_YG_04kv_coord_17.Text, out FY17)) { }
            if (double.TryParse(engine_YG_04kv_coord_18.Text, out FY18)) { }
            if (double.TryParse(engine_YG_04kv_coord_19.Text, out FY19)) { }
            if (double.TryParse(engine_YG_04kv_coord_20.Text, out FY20)) { }
            if (double.TryParse(engine_YG_04kv_coord_21.Text, out FY21)) { }
            if (double.TryParse(engine_YG_04kv_coord_22.Text, out FY22)) { }

            YG_04kV_result_half = (FY1 * FX1) + (FY2 * FX2) + (FY3 * FX3) + (FY4 * FX4) + (FY5 * FX5) + (FY6 * FX6) + (FY7 * FX7)
            + (FY8 * FX8) + (FY9 * FX9) + (FY10 * FX10) + (FY11 * FX11) + (FY12 * FX12) + (FY13 * FX13) + (FY14 * FX14) + (FY15 * FX15) + (FY16 * FX16) + (FY17 * FX17) + (FY17 * FX17)
            + (FY18 * FX18) + (FY19 * FX19) + (FY20 * FX20) + (FY21 * FX21) + (FY22 * FX22);

            YG_04kV_result = YG_04kV_result_half / (FY1 + FY2 + FY3 + FY4 + FY5 + FY6 + FY7 + FY8 + FY9 + FY10 + FY11 + FY12 + FY13 + FY14
                + FY15 + FY16 + FY17 + FY18 + FY19 + FY20 + FY21 + FY22);
            Coord_YG_04kv.Text = YG_04kV_result.ToString();

            #endregion

            #region Y - 6kV engine types, coords and final calculations



            string_Mtr1 = ((ListBoxItem)engine_YG_6kv_list_1.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr1, out Mtr1)) { }

            string_Mtr2 = ((ListBoxItem)engine_YG_6kv_list_2.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr2, out Mtr2)) { }

            string_Mtr3 = ((ListBoxItem)engine_YG_6kv_list_3.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr3, out Mtr3)) { }

            string_Mtr4 = ((ListBoxItem)engine_YG_6kv_list_4.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr4, out Mtr4)) { }

            string_Mtr5 = ((ListBoxItem)engine_YG_6kv_list_5.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr5, out Mtr5)) { }

            string_Mtr6 = ((ListBoxItem)engine_YG_6kv_list_6.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr6, out Mtr6)) { }

            string_Mtr7 = ((ListBoxItem)engine_YG_6kv_list_7.SelectedValue).Content.ToString();
            if (double.TryParse(string_Mtr7, out Mtr7)) { }


            if (double.TryParse(engine_YG_6kv_coord_1.Text, out Y1)) { }
            if (double.TryParse(engine_YG_6kv_coord_2.Text, out Y2)) { }
            if (double.TryParse(engine_YG_6kv_coord_3.Text, out Y3)) { }
            if (double.TryParse(engine_YG_6kv_coord_4.Text, out Y4)) { }
            if (double.TryParse(engine_YG_6kv_coord_5.Text, out Y5)) { }
            if (double.TryParse(engine_YG_6kv_coord_6.Text, out Y6)) { }
            if (double.TryParse(engine_YG_6kv_coord_7.Text, out Y7)) { }

            YG_6kV_result_half = (Mtr1 * Y1) + (Mtr2 * Y2) + (Mtr3 * Y3) + (Mtr4 * Y4) + (Mtr5 * Y5) + (Mtr6 * Y6) + (Mtr7 * Y7);
            YG_6kV_result = YG_6kV_result_half / (Mtr1 + Mtr2 + Mtr3 + Mtr4 + Mtr5 + Mtr6 + Mtr7);
            Coord_YG_6kv.Text = YG_6kV_result.ToString();

            XG = XG_04kV_result + XG_6kV_result;
            YG = YG_04kV_result + YG_6kV_result;
            Coord_XG.Text = XG.ToString();
            Coord_YG.Text = YG.ToString();
            #endregion
        }

    }
}
