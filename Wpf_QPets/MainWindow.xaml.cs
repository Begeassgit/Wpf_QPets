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

        string temp;
        public MainWindow()
        {
            InitializeComponent();
            this.AllowsTransparency = true;
            MyAnimation("relax.gif");
        }

        internal void MyAnimation(string type)
        {
            BitmapImage image = new BitmapImage();
            ReadImageName readImageName = new ReadImageName();
            foreach(string name in readImageName.GetImageNames())
            {
                if (name == type)
                {
                    image.BeginInit();
                    image.UriSource = new Uri(@"Image\" + type, UriKind.Relative);
                    image.EndInit();
                    ImageBehavior.SetAnimatedSource(Body, image);
                    ImageBehavior.SetRepeatBehavior(Body, RepeatBehavior.Forever);
                }
                
            }    
        }
        private void RelaxClick(object sender, RoutedEventArgs e)
        {
            MyAnimation("relax.gif");
        }

        private void SitClick(object sender, RoutedEventArgs e)
        {
            MyAnimation("sit.gif");
        }

        private void SleepClick(object sender, RoutedEventArgs e)
        {
            MyAnimation("sleep.gif");
        }
        private void SpecialClick(object sender, RoutedEventArgs e)
        {
            MyAnimation("special.gif");
        }

        private void Body_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            temp = ImageBehavior.GetAnimatedSource(Body).ToString();
            MyAnimation("interact.gif");          
        }

        private void Body_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MyAnimation(temp.Substring(6));
        }
    }
}
