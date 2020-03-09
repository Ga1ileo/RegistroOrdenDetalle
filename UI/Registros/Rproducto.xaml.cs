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
    /// Interaction logic for Rproducto.xaml
    /// </summary>
    public partial class Rproducto : Window
    {
        Producto producto = new Producto();
        public Rproducto()
        {
            InitializeComponent();
            this.DataContext = producto;
            ProductoIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            InventarioTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (string.IsNullOrWhiteSpace(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                paso = ProductoBLL.Guardar(producto);
            else
            {
                if (!ExisteBD())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ProductoBLL.Modificar(producto);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ExisteBD()
        {
            producto = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            return (producto != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = producto;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(ProductoIdTextBox.Text);

            Limpiar();

            if (ProductoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(ProductoIdTextBox.Text, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Producto anterior = ProductoBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            if (anterior != null)
            {
                producto = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");

            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            RPConsulta rpconsulta = new RPConsulta();
            rpconsulta.Show();
        }
    }
}
