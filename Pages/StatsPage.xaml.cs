using Sim.Scripts;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace Sim.Pages
{
    public partial class StatsPage : Page
    {
        Controller controller;

        public StatsPage()
        {
            InitializeComponent();
            controller = new Controller();
            controller.ReadControllerFile();
            Debug.WriteLine("job " + controller.strCurrentJob);
            SetLabels();
        }

        public void SetLabels()
        {
            lblCurrentJob.Text = controller.strCurrentJob;
            lblCurrentPay.Text = controller.strPlayerIncome.ToString();
        }
    }
}
