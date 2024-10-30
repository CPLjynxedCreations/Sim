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
using Sim.Pages;
using Sim.Scripts;

namespace Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;

        public string strMoney;
        public decimal decMoney;
        public decimal decPay;// = (decimal)20.50;

        public string strCurrentJob;

        public System.Timers.Timer timPay;

        public MainWindow()
        {
            InitializeComponent();
            lblAddMoneyAmount.Visibility = Visibility.Hidden;
            controller = new Controller();
            controller.CreateControllerFile();
            controller.ReadControllerFile();
            ShowLabels();
            InitializeTimers();
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
        private void OnStatsClick(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Navigate(new Uri("Pages/StatsPage.xaml", UriKind.Relative));
        }


        private void InitializeTimers()
        {
            System.Timers.Timer timPay = new System.Timers.Timer(10000);
            timPay.Elapsed += GetPaid;
            timPay.AutoReset = true;
            timPay.Enabled = true;

            System.Timers.Timer timPayed = new System.Timers.Timer(11000);
            timPayed.Elapsed += BeenPaid;
            timPayed.AutoReset = true;
            timPayed.Enabled = true;
        }

        private void ShowLabels()
        {
            lblMoney.Text = controller.strCurrentPlayerMoney;
        }

        private void GetPaid(Object source, ElapsedEventArgs e)
        {
            controller.ReadControllerFile();
            if (controller.strCurrentJob != "No Job")
            {
                Application.Current.Dispatcher.Invoke(() =>
            {
                decMoney = Convert.ToDecimal(Convert.ToString(lblMoney.Text));
                decPay = Convert.ToDecimal(controller.strPlayerIncome);
                decMoney = decMoney + decPay;
                strMoney = decMoney.ToString();
                lblMoney.Text = strMoney;
                controller.strCurrentPlayerMoney = decMoney.ToString();
                controller.UpDateControllerFile();
                lblAddMoneyAmount.Text = "+" + decPay.ToString();
                lblAddMoneyAmount.Visibility = Visibility.Visible;
            });
            }
        }

        private void BeenPaid(Object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
        {
            lblAddMoneyAmount.Visibility = Visibility.Hidden;
        });
        }
    }
}