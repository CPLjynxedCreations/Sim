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
            controller.strNewJob = strNewJob;
            controller.UpDateControllerFile();
            mWindow.lblJob.Text = strNewJob;
        }
    }
}
