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
using System.Windows.Threading;

namespace MyPomo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // dispatcher timer setup
        private readonly DispatcherTimer dispatcherTimer = new();
        private TimeSpan remainingTime = TimeSpan.FromMinutes(5);

        static readonly TimeSpan TickRate = TimeSpan.FromSeconds(1);




        public MainWindow()
        {
            InitializeComponent();

            // Dispatcher timer setup
            dispatcherTimer.Interval = TickRate;
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            tbDisplay.Text = remainingTime.ToString();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            remainingTime -= TickRate;
            if (remainingTime <= TimeSpan.Zero)
            {
                dispatcherTimer.Stop();
            }

            tbDisplay.Text = remainingTime.ToString();
        }

        private void ClickedTimerToggle(object? sender, RoutedEventArgs e)
        {
            if (dispatcherTimer.IsEnabled) {
                dispatcherTimer.Stop();
                btnTimerToggle.Content = "Start";
            }
            else
            {
                dispatcherTimer.Start();
                btnTimerToggle.Content = "Pause";
            }
        }

    }
}