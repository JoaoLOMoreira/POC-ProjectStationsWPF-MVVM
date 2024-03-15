using ProjectStations.ADO;
using ProjectStations.Business;
using ProjectStations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using ProjectStations.View.Emissoras;

namespace ProjectStations.ViewModel.Emissoras
{
    public class ViewModelEmissoras : ViewModelProjectEmissoras
    {
        public ObservableCollection<ModelEmissoras> ISEmissoras { get; set; }
        public ICommand CmdSalvarEmissora { get; set; }
        public ICommand CmdAlterar { get; set; }
        public ICommand CmdExcluir { get; set; }
        public ICommand GridEmissora { get; set; }
        public ViewModelEmissoras()
        {
            ISEmissoras = new ObservableCollection<ModelEmissoras>();
            CmdSalvarEmissora = new DelegateCommand<object>(SalvarEmissora);
            CmdExcluir = new DelegateCommand<object>(deletarEmissora);
            CmdAlterar = new DelegateCommand<object>(AlterarEmissora);
            caregarEmissoras();
        }

        private void SalvarEmissora(object obj)
        {
            ModelEmissoras emissoras = new ModelEmissoras
            {
                IdEmissoras = Guid.NewGuid(),
                NomeFantasia = NomeFantasia,
                RazaoSocial = RazaoSocial,
                Tipo = Tipo,
            };

            new EmissoraBusiness().AddEmissoras(emissoras);
            caregarEmissoras();
        }
        private void AlterarEmissora(object obj)
        {
            ModelEmissoras emissoras = new ModelEmissoras
            {
                IdEmissoras = Guid.Parse(IdEmissoras),
                NomeFantasia = NomeFantasia,
                RazaoSocial = RazaoSocial,
                Tipo = Tipo,
            };
            new EmissoraBusiness().alterarEmissoras(emissoras);
            caregarEmissoras();
        }
        private void deletarEmissora(object obj)
        {
            MessageBoxResult result;
            if (!string.IsNullOrEmpty(IdEmissoras))
            {
                var idEmissora = IdEmissoras;
                result = MessageBox.Show("Você deseja realmente excluir a emissora?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    new EmissoraBusiness().ExcluirEmissoras(idEmissora); 
                    caregarEmissoras();
                }
            }
        }

        private void caregarEmissoras()
        {
            limpaComponentes();
            var emissoras = new EmissoraBusiness().CarregarEmissoras();
            foreach (var emissora in emissoras)
            {
                ISEmissoras.Add(emissora);
            }
        }

        private void limpaComponentes()
        {
            ISEmissoras.Clear();       //Limpa a grid antes de carregar as coisas pra que no insert pra que n fique repitido
        }


        public ModelEmissoras EventoSelecionado
        {
            get { return eventoSelecionado; }
            set { eventoSelecionado = value; }
        }
        private ModelEmissoras eventoSelecionado;

        public string IdEmissoras
        {
            get { return idEmissoras; }
            set { idEmissoras = value; }
        }
        private string idEmissoras;
        public string NomeFantasia
        {
            get { return nomeFantasia; }
            set { nomeFantasia = value; }
        }
        private string nomeFantasia;

        public string RazaoSocial
        {
            get { return razaoSocial; }
            set { razaoSocial = value; }
        }
        private string razaoSocial;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string tipo;

    }

}



