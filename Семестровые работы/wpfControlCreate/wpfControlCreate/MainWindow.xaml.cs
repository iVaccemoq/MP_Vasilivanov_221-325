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

from 

namespace wpfControlCreate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.MouseDown += MainWindow_MouseDown;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var curLocation = e.GetPosition(this);

            if (e.ChangedButton == MouseButton.Left)
            {
                var la = new Label();
                la.Background = new SolidColorBrush(
                    Color.FromRgb((byte)rnd.Next(256),
                    (byte)rnd.Next(256), (byte)rnd.Next(256)));
                la.SetValue(Canvas.LeftProperty, curLocation.X);
                la.SetValue(Canvas.TopProperty, curLocation.Y);
                la.Content = $"{la.GetValue(Canvas.LeftProperty):0}:{la.GetValue(Canvas.TopProperty):0}";
                this.main.Children.Add(la);
            }

            if (e.ChangedButton == MouseButton.Right)
            {
                var la = new Label();
                la.Background = new SolidColorBrush(
                    Color.FromRgb((byte)rnd.Next(256),
                    (byte)rnd.Next(256), (byte)rnd.Next(256)));
                la.SetValue(Canvas.LeftProperty, rnd.Next((int)this.Width));
                la.SetValue(Canvas.TopProperty, rnd.Next((int)this.Height));
                la.Content = $"{la.GetValue(Canvas.LeftProperty):0}:{la.GetValue(Canvas.TopProperty):0}";
                this.main.Children.Add(la);
            }

        }
    }
}