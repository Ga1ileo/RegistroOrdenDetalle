using RegistroOrdenDetalle.BLL;
using RegistroOrdenDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroOrdenDetalle.UI.Registros
{
    /// <summary>
    /// Interaction logic for ROConsulta.xaml
    /// </summary>
    public partial class ROConsulta : Window
    {
        public ROConsulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Orden>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = OrdenBLL.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = OrdenBLL.GetList(p => p.OrdenId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = OrdenBLL.GetList(p => p.Fecha == fecha);
                        break;

                }

            }
            else
            {
                listado = OrdenBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
