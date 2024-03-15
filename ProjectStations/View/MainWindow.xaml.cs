using ProjectStations.View.Emissoras;
using ProjectStations.ViewModel;
using System;
using System.Collections.Generic;
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

namespace ProjectStations
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModelMainWindow vmMainWindow;
        private WInEmissoras winEmissoras;

        public MainWindow(ViewModelMainWindow vmMain)
        {
            InitializeComponent();
            DataContext = vmMain;
            vmMainWindow = DataContext as ViewModelMainWindow;
            vmMainWindow.OnAbrirTelaEmissoras += vmMainWindow_OnAbrirTelaEmissoras;

            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
        }

        private void vmMainWindow_OnAbrirTelaEmissoras(object sender, object e)
        {
            Dispatcher.Invoke(() =>
            {
                if (winEmissoras == null)
                {
                    winEmissoras = new WInEmissoras() { DataContext = e };
                    winEmissoras.Closed += WinEmissoras_Closed;
                    winEmissoras.Owner = this;
                    winEmissoras.ShowDialog();
                }
            });
        }

        private void WinEmissoras_Closed(object sender, EventArgs e)
        {
            winEmissoras.Closed -= WinEmissoras_Closed;
            winEmissoras = null;
        }
    }
}
