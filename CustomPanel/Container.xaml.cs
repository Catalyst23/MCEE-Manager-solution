using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Data;
using System.Windows.Controls.Primitives;
using System.Printing;

namespace MetroStyleBaseApp
{

    public partial class Container : System.Windows.Controls.UserControl
    {
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        void CheckContainerState()
        {
            // does absolutely nothing 
        }

        public static Etapa1_EngineManagement engines_mg;

        CustomPanel Panel = null;
        UnDoRedo UnDoObject = null;    

        #region Constructor

        public Container()
        {
            CheckContainerState();

            InitializeComponent();
            Panel = new CustomPanel();
            
            SetPanel();
            InitializeEvent();
        }


        void ConfigureMapView_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Panel.delete();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
            {
                UnDoObject.Undo(1);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.G)
            {
                UnDoObject.Redo(1);
            }
        }

        #endregion

        private void SetPanel()
        {

            UnDoObject = new UnDoRedo();
            Panel.UnDoObject = UnDoObject;
            UnDoObject.Container = Panel;
            vbPanel.Child = Panel;

            UnDoObject.EnableDisableUndoRedoFeature += new EventHandler(UnDoObject_EnableDisableUndoRedoFeature);

        }



        public void UnDoObject_EnableDisableUndoRedoFeature(object sender, EventArgs e)
        {
            if (UnDoObject.IsUndoPossible())
            {
                App.engines_mg.btnUndo.IsEnabled = true;
            }
            else
            {
                App.engines_mg.btnUndo.IsEnabled = false;
            }

            if (UnDoObject.IsRedoPossible())
            {
                App.engines_mg.btnRedo.IsEnabled = true;
            }
            else
            {
                App.engines_mg.btnRedo.IsEnabled = false;
            }

        }

        void Panel_EndDrawing(object sender, EventArgs e)
        {
            CheckSelection(false);       
        }

        private void CheckSelection(bool IsCheck)
        {
            App.engines_mg.btnHall.IsChecked = IsCheck;
            App.engines_mg.btnEngine.IsChecked = IsCheck;
            //App.engines_mg.btnDelete.IsChecked = IsCheck;
        }

        #region delete

        void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Panel.delete();
        }

        #endregion



        void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            Panel.RemoveSelection();
            UnDoObject.Redo(1);

        }

        void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            Panel.RemoveSelection();
            UnDoObject.Undo(1);
        }

        void btnHall_Click(object sender, RoutedEventArgs e)   
        {
            //((ToggleButton)sender).IsChecked = true;
            Panel.DrawRectangleApbMode();
        }
        void btnEngine_Click(object sender, RoutedEventArgs e)   
        {
            //((ToggleButton)sender).IsChecked = true;
            Panel.DrawEllipseApbMode();
        }


        // DO WORK --- RETURN DELETE KEY EVENT

        private void DrawHallFrame(object sender, RoutedEventArgs e)   // Afisare hala
        {

            Panel.Children.Clear(); // clear every element on Panel 

            #region Hall Dimension

            Line line = new Line();
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 3;
            line.Stroke = System.Windows.Media.Brushes.Black;
            line.X1 = 100;
            line.X2 = 725;
            line.Y1 = 75;
            line.Y2 = 75;
            Panel.Children.Add(line);

            Line line2 = new Line(); 
            line2.Visibility = System.Windows.Visibility.Visible;
            line2.StrokeThickness = 3;
            line2.Stroke = System.Windows.Media.Brushes.Black;
            line2.X1 = 100;
            line2.X2 = 725;
            line2.Y1 = 350;
            line2.Y2 = 350;
            Panel.Children.Add(line2);

            Line line3 = new Line();
            line3.Visibility = System.Windows.Visibility.Visible;
            line3.StrokeThickness = 3;
            line3.Stroke = System.Windows.Media.Brushes.Black;
            line3.X1 = 725;
            line3.X2 = 725;
            line3.Y1 = 75;
            line3.Y2 = 350;
            Panel.Children.Add(line3);

            Line line4 = new Line();
            line4.Visibility = System.Windows.Visibility.Visible;
            line4.StrokeThickness = 3;
            line4.Stroke = System.Windows.Media.Brushes.Black;
            line4.X1 = 100;
            line4.X2 = 100;
            line4.Y1 = 75;
            line4.Y2 = 350;
            Panel.Children.Add(line4);


            #endregion


        }

        private void InitializeEvent()
        {

            #region Register Event  

            foreach (Window window in Application.Current.Windows)
            {
               if (window.GetType() == typeof(Etapa1_EngineManagement))
               {
                   (window as Etapa1_EngineManagement).btnHallDraw.Click += new RoutedEventHandler(DrawHallFrame);
               }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                    (window as Etapa1_EngineManagement).btnDelete.Click += new RoutedEventHandler(btnDelete_Click);
                }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                   (window as Etapa1_EngineManagement).btnHall.Click += new RoutedEventHandler(btnHall_Click);
                }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                   (window as Etapa1_EngineManagement).btnEngine.Click += new RoutedEventHandler(btnEngine_Click);
                }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                   (window as Etapa1_EngineManagement).btnUndo.Click += new RoutedEventHandler(btnUndo_Click);
                }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                   (window as Etapa1_EngineManagement).btnRedo.Click += new RoutedEventHandler(btnRedo_Click);
                }

                if (window.GetType() == typeof(Etapa1_EngineManagement))
                {
                   (window as Etapa1_EngineManagement).btnHallSave.Click += new RoutedEventHandler(SaveHallImage);
                }
            }       

            Panel.CompleteDraw += new EventHandler(Panel_EndDrawing);

            this.KeyDown += new System.Windows.Input.KeyEventHandler(ConfigureMapView_KeyDown);

            #endregion


            //if (engines_mg.btnHall.IsChecked == true)
            //{
            //    Panel.DrawRectangleApbMode();
            //}

            //if (engines_mg.btnEngine.IsChecked == true)
            //{
            //    Panel.DrawEllipseApbMode();
            //}
        }

        void SaveCanvasToPDF(CustomPanel myCanvas)
        {
            PrintDialog pd = new PrintDialog();
            pd.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
            pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
            pd.PrintTicket.PageScalingFactor = 100;
            pd.PrintVisual(myCanvas, "Desen hala");
        }


        private void SaveHallImage(object sender, RoutedEventArgs e)
        {
            SaveCanvasToPDF(Panel);
        }
    }
}

