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
    /// <summary>
    /// Логика взаимодействия для CloseDialog.xaml
    /// </summary>
    public partial class CloseDialog : MetroWindow
    {
        public CloseDialog()
        {
            InitializeComponent();
            
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        
           
        private void Close(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            App.close.Close();
            App.close = null;
        }
           
      
    }
}
