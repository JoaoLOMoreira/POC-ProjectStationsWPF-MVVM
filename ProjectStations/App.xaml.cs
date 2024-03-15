using ProjectStations.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectStations
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow vMain;
        private ViewModelMainWindow vmMain;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            vmMain = new ViewModelMainWindow();
            vMain = new MainWindow(vmMain);
            vMain.Show();

        }

    }
}
