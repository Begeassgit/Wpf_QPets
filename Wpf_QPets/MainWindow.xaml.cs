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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using WpfAnimatedGif;


namespace Wpf_QPets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageInfo imageInfo = new();
        Dictionary<string, string> imagesOnDisk = new();
        ImageRead imageRead = new();

        public MainWindow()
        {
            InitializeComponent();
            AllowsTransparency = true;
            SetImageName();
            MyAnimation();
        }

        internal void SetImageName()
        {
            imageInfo.Type = "relax.gif";
        }

        internal void SetImageName(string type)
        {
            if (CheckFileName(type))
            {
                imageInfo.Type = type;
            }
            else
            {
                imageInfo.Type = "relax.gif";
            }
            

        }

        internal bool CheckFileName(string type)
        {

            imagesOnDisk = imageRead.GetImageNames();
            if (imagesOnDisk.ContainsKey(type))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        internal void MyAnimation()
        {
            BitmapImage image = new();
            image.BeginInit();
            image.UriSource = new Uri(@"Image\" + imageInfo.Type, UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Body, image);
            ImageBehavior.SetRepeatBehavior(Body, RepeatBehavior.Forever);
        }

        internal async void MyAnimation(int time,string type)
        {
            BitmapImage image = new();
            image.BeginInit();
            image.UriSource = new Uri(@"Image\" + imageInfo.Type, UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Body, image);
            ImageBehavior.SetRepeatBehavior(Body, RepeatBehavior.Forever);

            await Task.Delay(time);

            SetImageName(type.Remove(0,6));
            BitmapImage image_reload = new();
            image_reload.BeginInit();
            image_reload.UriSource = new Uri(type, UriKind.Relative);
            image_reload.EndInit();
            ImageBehavior.SetAnimatedSource(Body, image_reload);
            ImageBehavior.SetRepeatBehavior(Body, RepeatBehavior.Forever);
        }
        private void RelaxClick(object sender, RoutedEventArgs e)
        {
            SetImageName("relax.gif");
            MyAnimation();
        }

        private void SitClick(object sender, RoutedEventArgs e)
        {
            SetImageName("sit.gif");
            MyAnimation();
        }

        private void SleepClick(object sender, RoutedEventArgs e)
        {
            SetImageName("sleep.gif");
            MyAnimation();
        }
        private void SpecialClick(object sender, RoutedEventArgs e)
        {
            SetImageName("special.gif");
            MyAnimation();
        }

        private void Body_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string temp = ImageBehavior.GetAnimatedSource(Body).ToString();
            SetImageName("interact.gif");
            MyAnimation(1000, temp);
        }

        private void Body_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
