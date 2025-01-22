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

namespace wpfControlContent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new();
            stackPanel.Children.Add(new Label() { Content="qqq"});
            stackPanel.Children.Add(new Label() { Content="www"});
            stackPanel.Children.Add(new Label() { Content="zzz"});
            buAdd.Content = stackPanel;
        }

        private void buAdd_Click(object sender, RoutedEventArgs e)
        {
            buAdd.Content = $"Password {DateTime.Now}";
        }
    }
}