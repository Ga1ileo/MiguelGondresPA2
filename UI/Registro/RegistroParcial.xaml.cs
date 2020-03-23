using MiguelGondresPA2.BLL;
using MiguelGondresPA2.Entidades;
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

namespace MiguelGondresPA2.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroParcial.xaml
    /// </summary>
    public partial class RegistroParcial : Window
    {
        Llamadas llamadas = new Llamadas();
        public RegistroParcial()
        {
            InitializeComponent();
            this.DataContext = llamadas;
            IdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;

            DetalleDataGrid.ItemsSource = new List<LlamadaDetalle>();
            Actualizar();
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = llamadas;
        }

        private bool ExisteEnBaseDatos()
        {
            llamadas = LlamadasBLL.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (llamadas != null);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = LlamadasBLL.Guardar(llamadas);
            else
            {
                if (!ExisteEnBaseDatos())
                {
                    MessageBox.Show("No se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = LlamadasBLL.Modificar(llamadas);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puede Guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas anterior = LlamadasBLL.Buscar(Convert.ToInt32(IdTextBox.Text));

            if (anterior != null)
            {
                llamadas = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("llamadas no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdTextBox.Text);

            Limpiar();

            if (LlamadasBLL.Eliminar(id))
                MessageBox.Show("Eliminar", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(IdTextBox.Text, "No se puede eliminar una llamada que no existe");
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            llamadas.LlamadaDetalle.Add(new LlamadaDetalle(Convert.ToInt32(IdTextBox.Text), ProblemaTextBox.Text, SolucionTextBox.Text));
            Actualizar();
            ProblemaTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            llamadas.LlamadaDetalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            Actualizar();
        }
    }
}
