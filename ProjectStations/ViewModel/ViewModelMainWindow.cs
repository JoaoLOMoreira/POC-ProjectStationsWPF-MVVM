using ProjectStations.View.Emissoras;
using ProjectStations.ViewModel.Emissoras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectStations.ViewModel
{
    public class ViewModelMainWindow : ViewModelProjectEmissoras
    {
        public ICommand CmdAbrirEmissoras { get; set; }

        public ViewModelEmissoras vmEmissoras { get; set; }
        public event EventHandler<object> OnAbrirTelaEmissoras;

        public ViewModelMainWindow() {
            CmdAbrirEmissoras = new DelegateCommand<object>(AbriEmissoras);
        }

        public void AbriEmissoras(object obj)
        {
            vmEmissoras = new ViewModelEmissoras();
            OnAbrirTelaEmissoras?.Invoke(this, vmEmissoras);
        }
    }
}
