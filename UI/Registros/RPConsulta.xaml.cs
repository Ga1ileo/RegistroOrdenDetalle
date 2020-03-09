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
    /// Interaction logic for RPConsulta.xaml
    /// </summary>
    public partial class RPConsulta : Window
    {
        public RPConsulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Producto>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ProductoBLL.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ProductoBLL.GetList(p => p.ProductoId == id);
                        break;
                    case 2://Nombre Producto
                        listado = ProductoBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = ProductoBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
