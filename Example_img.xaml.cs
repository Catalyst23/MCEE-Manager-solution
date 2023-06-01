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
using XAMLMarkupExtensions;
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using System.Printing;

namespace MetroStyleBaseApp
{

    public class ZoomBorder : Border
    {
        private UIElement child = null;
        private Point origin;
        private Point start;

        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != this.Child)
                    this.Initialize(value);
                base.Child = value;
            }
        }

        public void Initialize(UIElement element)
        {
            this.child = element;
            if (child != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                child.RenderTransform = group;
                child.RenderTransformOrigin = new Point(0.0, 0.0);
                this.MouseWheel += child_MouseWheel;
                this.MouseLeftButtonDown += child_MouseLeftButtonDown;
                this.MouseLeftButtonUp += child_MouseLeftButtonUp;
                this.MouseMove += child_MouseMove;
                this.PreviewMouseRightButtonDown += new MouseButtonEventHandler(
                  child_PreviewMouseRightButtonDown);
            }
        }

        public void Reset()
        {
            if (child != null)
            {
                // reset zoom
                var st = GetScaleTransform(child);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform(child);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        #region Child Events

        private void child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (child != null)
            {
                var st = GetScaleTransform(child);
                var tt = GetTranslateTransform(child);

                double zoom = e.Delta > 0 ? .2 : -.2;
                if (!(e.Delta > 0) && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                Point relative = e.GetPosition(child);
                double absoluteX;
                double absoluteY;

                absoluteX = relative.X * st.ScaleX + tt.X;
                absoluteY = relative.Y * st.ScaleY + tt.Y;

                st.ScaleX += zoom;
                st.ScaleY += zoom;

                tt.X = absoluteX - relative.X * st.ScaleX;
                tt.Y = absoluteY - relative.Y * st.ScaleY;
            }
        }

        private void child_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                var tt = GetTranslateTransform(child);
                start = e.GetPosition(this);
                origin = new Point(tt.X, tt.Y);
                this.Cursor = Cursors.Hand;
                child.CaptureMouse();
            }
        }

        private void child_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (child != null)
            {
                child.ReleaseMouseCapture();
                this.Cursor = Cursors.Arrow;
            }
        }

        void child_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Reset();
        }

        private void child_MouseMove(object sender, MouseEventArgs e)
        {
            if (child != null)
            {
                if (child.IsMouseCaptured)
                {
                    var tt = GetTranslateTransform(child);
                    Vector v = start - e.GetPosition(this);
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;
                }
            }
        }

        #endregion
    }


    public partial class Example_img : MetroWindow
    {
        string currentIndex;

        private void nr_ordin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonShow.IsEnabled = true;
            currentIndex = ((ListBoxItem)nr_ordin.SelectedValue).Content.ToString();  // convert objects from listBox to string

        }

        Image N1 = new Image();
        BitmapImage n1_link = new BitmapImage();
        Image N2 = new Image();
        BitmapImage n2_link = new BitmapImage();

        void GetImageLinks()        // this function behavior was disabled (it could be useful when using another approach on displaying the image)
        {
            //#region No image

            //if (currentIndex == null)
            //{
            //    Image no_Image = new Image();


            //    BitmapImage no_image_link = new BitmapImage();
            //    no_image_link.BeginInit();
            //    no_image_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    no_image_link.EndInit();


            //    no_Image.Source = no_image_link;
            //}

            //#endregion

            //#region N1
            //if (currentIndex == null)
            //{
                
            //    n1_link.BeginInit();
            //    n1_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    n1_link.EndInit();
            //    N1.Source = n1_link;
            //}
            //#endregion

            //#region N2
            //if (currentIndex == null)
            //{

            //    n2_link.BeginInit();
            //    n2_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    n2_link.EndInit();
            //    N2.Source = n2_link;
            //}
            //#endregion

            //#region N3
            //if (currentIndex == null)
            //{
            //    Image N3 = new Image();


            //    BitmapImage n3_link = new BitmapImage();
            //    n3_link.BeginInit();
            //    n3_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    n3_link.EndInit();


            //    N3.Source = n3_link;
            //}
            //#endregion

            //#region N4
            //if (currentIndex == null)
            //{
            //    Image N4 = new Image();


            //    BitmapImage n4_link = new BitmapImage();
            //    n4_link.BeginInit();
            //    n4_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    n4_link.EndInit();


            //    N4.Source = n4_link;
            //}
            //#endregion

            //#region N5
            //if (currentIndex == null)
            //{
            //    Image N5 = new Image();


            //    BitmapImage n5_link = new BitmapImage();
            //    n5_link.BeginInit();
            //    n5_link.UriSource = new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg");
            //    n5_link.EndInit();


            //    N5.Source = n5_link;
            //}
            //#endregion
        }


        void SetImageSource()               // this function creates an individual image for every selected option
        {
            #region SelectImageIndex

            if (currentIndex == null)
            {               
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg"));             
            }

            if (currentIndex == "1")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N1.jpg"));
            }

            if (currentIndex == "2")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N2.jpg"));
            }

            if (currentIndex == "3")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N3.jpg"));
            }

            if (currentIndex == "4")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N4.jpg"));
            }

            if (currentIndex == "5")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N5.jpg"));
            }

            if (currentIndex == "6")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N6.jpg"));
            }

            if (currentIndex == "7")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N7.jpg"));
            }

            if (currentIndex == "8")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N8.jpg"));
            }

            if (currentIndex == "9")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N9.jpg"));
            }

            if (currentIndex == "10")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N10.jpg"));
            }

            if (currentIndex == "11")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N11.jpg"));
            }

            if (currentIndex == "12")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N12.jpg"));
            }

            if (currentIndex == "13")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N13.jpg"));
            }

            if (currentIndex == "14")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N14.jpg"));
            }

            if (currentIndex == "15")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N15.jpg"));
            }

            if (currentIndex == "16")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N16.jpg"));
            }

            if (currentIndex == "17")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N17.jpg"));
            }

            if (currentIndex == "18")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N18.jpg"));
            }

            if (currentIndex == "19")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N19.jpg"));
            }

            if (currentIndex == "20")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N20.jpg"));
            }

            if (currentIndex == "21")
            {
                ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/Schema_mono_N21.jpg"));
            }

            #endregion
        }

        private void Select_Block_Click(object sender, RoutedEventArgs e)
        {
            SetImageSource();
            buttonSave.IsEnabled = true;
        }

        public Example_img()
        {           
            InitializeComponent();
            ImageData.Source = new BitmapImage(new Uri("pack://application:,,,/ManagerMCEE;component/Maps/default - no image.jpg"));
        }

        void SaveScheme(object sender, RoutedEventArgs e)
        {
            SaveCanvasToPDF(border);
        }


        void SaveCanvasToPDF(Border border) 
        {
            SetImageSource();
            PrintDialog pd = new PrintDialog();
            pd.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
            pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
            pd.PrintTicket.PageScalingFactor = 100;
            pd.PrintVisual(border, "Schema monofilara");
            
        }


    }
}
