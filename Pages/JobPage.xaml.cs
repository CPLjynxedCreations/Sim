using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Sim.Scripts;

namespace Sim.Pages
{
    /// <summary>
    /// Interaction logic for JobPage.xaml
    /// </summary>
    public partial class JobPage : Page
    {
        MainWindow mWindow;
        Controller controller;

        string strNewJob;
        public decimal decIncome;
        public string strIncome;


        public JobPage()
        {
            InitializeComponent();
            controller = new Controller();
        }

        public void OnJobClicked(object sender, RoutedEventArgs e)
        {
            mWindow = (MainWindow)Application.Current.MainWindow;
            Button btnJobPressed = (Button)sender;
            strNewJob = Convert.ToString(btnJobPressed.Content);
            controller.strCurrentJob = strNewJob;
            controller.strCurrentPlayerMoney = mWindow.lblMoney.Text.ToString();
            if (strNewJob == "Police")
            {
                decIncome = (decimal)50.70;
                controller.strPlayerIncome = decIncome.ToString();
            }
            if (strNewJob == "Fire Fighter")
            {
                decIncome = (decimal)30.00;
                controller.strPlayerIncome = decIncome.ToString();
            }
            if (strNewJob == "Paramedic")
            {
                decIncome = (decimal)24.30;
                controller.strPlayerIncome = decIncome.ToString();
            }
            if (strNewJob == "Army")
            {
                decIncome = (decimal)76.80;
                controller.strPlayerIncome = decIncome.ToString();
            }
            controller.UpDateControllerFile();
        }
    }
}
