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

namespace wpfCommand
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

        private void Command_New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command_New_Executed");
        }

        private void Command_Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command_Save_Executed");
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = edNote?.Text?.Length != null;
            e.CanExecute = false;
        }

        private void Command_cmdAddtime_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class MyCommands
    {
        public static RoutedCommand cmdAddTime { get; set; } = new("cmdAddTime", typeof(MainWindow));
    }
}