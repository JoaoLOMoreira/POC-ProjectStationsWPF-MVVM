using ProjectStations.ADO;
using ProjectStations.Models;
using ProjectStations.ViewModel;
using ProjectStations.ViewModel.Emissoras;
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
using System.Windows.Shapes;

namespace ProjectStations.View.Emissoras
{
    /// <summary>
    /// Lógica interna para WInEmissoras.xaml
    /// </summary>
    public partial class WInEmissoras : Window
    {
        public WInEmissoras()
        {
            InitializeComponent();
            this.Closed += WinEmissoras_Closed;
        }

        private void WinEmissoras_Closed(object sender, EventArgs e)
        {
            this.Owner?.Focus();
        }



        public void apagarDadosTB()
        {
            tbNomeFantasia.Text = string.Empty;//apos incluir ele apaga os dados do textbox
            tbRazaoSocial.Text = string.Empty;//apos incluir ele apaga os dados do textbox
            tbTipo.Text = string.Empty;//apos incluir ele apaga os dados do textbox
        }

        private void DataGridEmissoras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = DataGridEmissoras.SelectedItem;
            var selectedEmissora = (ModelEmissoras)selectedItem;
            if (selectedEmissora != null)
            {
                tbNomeFantasia.Text = selectedEmissora.NomeFantasia;
                tbRazaoSocial.Text = selectedEmissora.RazaoSocial;
                tbTipo.Text = selectedEmissora.Tipo;
            }

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridEmissoras.SelectedItem;
            var selectedEmissora = (ModelEmissoras)selectedItem;
            if (!string.IsNullOrEmpty(selectedEmissora.IdEmissoras.ToString()))
            {
                ((ViewModelEmissoras)DataContext).IdEmissoras = selectedEmissora.IdEmissoras.ToString();
                ((ViewModelEmissoras)DataContext).NomeFantasia = tbNomeFantasia.Text;
                ((ViewModelEmissoras)DataContext).RazaoSocial = tbRazaoSocial.Text;
                ((ViewModelEmissoras)DataContext).Tipo = tbTipo.Text;
                MessageBox.Show("Emissora alterada com sucesso!!");
                apagarDadosTB();
            }
            else
            {
                MessageBox.Show("Você não selecionou a emissora que quer alterar!!");
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridEmissoras.SelectedItem;
            var selectedEmissora = (ModelEmissoras)selectedItem;
            if (!string.IsNullOrEmpty(selectedEmissora.IdEmissoras.ToString()))
            {
                ((ViewModelEmissoras)DataContext).IdEmissoras = selectedEmissora.IdEmissoras.ToString();
                apagarDadosTB();
            }
            else
            {
                MessageBox.Show("Você não selecionou a emissora que quer excluir!!");
            }
        }
    }
}
