using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
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
            SetImageRole();
            SetImageName();
            MyAnimation();
        }

        internal void SetImageRole()
        {
            imageInfo.Role = "NIAN";
        }

        internal void SetImageRole(string role)
        {
            imageInfo.Role = role;
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
            if (imageInfo.Role != null)
            {
                imagesOnDisk = imageRead.GetImageNames(imageInfo.Role);
            }
            else
            {
                imageInfo.Role = "NIAN";
                imagesOnDisk=imageRead.GetImageNames(imageInfo.Role);
            }
                
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
            image.UriSource = new Uri(@"Image\" +imageInfo.Role + @"\" + imageInfo.Type, UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(Body, image);
            ImageBehavior.SetRepeatBehavior(Body, RepeatBehavior.Forever);
        }

        internal async void MyAnimation(int time,string type) 
        {
            BitmapImage image = new();
            image.BeginInit();
            image.UriSource = new Uri(@"Image\" + imageInfo.Role + @"\" + imageInfo.Type, UriKind.Relative);
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

            switch (imageInfo.Role)
            {
                case "DASKADI": 
                    MyAnimation(2500, temp); break;
                case "CHEN_SUMMER":
                    MyAnimation(1300, temp); break;
                case "MLYSS":
                    MyAnimation(1500, temp); break;
                case "KALTSIT":
                    MyAnimation(1700, temp); break;
                default:
                    MyAnimation(1000, temp); break;
            }  
        }

        private void Body_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void MoveClick(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.WorkArea.Width - 500.0;
            SetImageName("move.gif");
            MyAnimation();
            Left = 100;
            while(imageInfo.Type=="move.gif")
            {
                if (Left <= screenWidth)
                {
                    Left += 1.8;
                    await Task.Delay(150);
                }
                else
                {
                    Left = 100;
                    Left += 1.8;
                    await Task.Delay(150);
                }
               
            }
        }

        private void ClickNian(object sender, RoutedEventArgs e)
        {
            SetImageRole("NIAN");
            MyAnimation();
        }

        private void ClickFmout(object sender, RoutedEventArgs e)
        {
            SetImageRole("FMOUT");
            MyAnimation();
        }

        private void ClickMudrok(object sender, RoutedEventArgs e)
        {
            SetImageRole("MUDROK");
            MyAnimation();
        }

        private void ClickDASkadi(object sender, RoutedEventArgs e)
        {
            SetImageRole("DASKADI");
            MyAnimation();
        }

        private void ClickMuelsyse(object sender, RoutedEventArgs e) 
        {
            SetImageRole("MLYSS");
            MyAnimation();
        }

        private void ClickChenSummer(object sender, RoutedEventArgs e)
        {
            SetImageRole("CHEN_SUMMER");
            MyAnimation();
        }

        private void ClickKaltsit(object sender, RoutedEventArgs e)
        {
            SetImageRole("KALTSIT");
            MyAnimation();
        }
    }
}
