using System.ComponentModel;
using System.Diagnostics;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Timers;
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
using Sim.Scripts;
using Sim.Windows;

namespace Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;
        PayWindow payWindow = new PayWindow();

        public string strMoney;
        public decimal decMoney;
        public decimal decPay = (decimal)20.50;

        public string strCurrentJob;

        public System.Timers.Timer timPay;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
            controller.CreateControllerFile();
            lblJob.Text = controller.strCurrentJob;
            InitializeTimer();
            mainWindowFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }

        private void OnHomeClick(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Navigate(new Uri("Pages/HomePage.xaml", UriKind.Relative));
        }
        private void OnJobsClick(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Navigate(new Uri("Pages/JobPage.xaml", UriKind.Relative));
        }


        private void InitializeTimer()
        {
            System.Timers.Timer timPay = new System.Timers.Timer(10000);
            timPay.Elapsed += OnTimedEvent;
            timPay.AutoReset = true;
            timPay.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            getPaid();
        }

        public void GetPaid()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                decMoney = Convert.ToDecimal(Convert.ToString(lblMoney.Text));
                decMoney = decMoney + decPay;
                strMoney = decMoney.ToString();
                lblMoney.Text = strMoney;

                if (payWindow.Owner != this)
                {
                    payWindow.Owner = this;

                }
                payWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                payWindow.btnOk.Click += (sender, e) => { payWindow.Close(); };
                payWindow.lblPayLabel.Text = "You've been paid " + decPay + "!";
                payWindow.Show();
            });
        }
    }
}