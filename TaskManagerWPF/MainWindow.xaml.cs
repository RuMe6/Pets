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
using TaskManager;


namespace TaskManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskContext context = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = context;
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter the data of task");
        }
    }
}