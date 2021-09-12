using RegistroUsuario.BLL;
using RegistroUsuario.Entidades;
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

namespace RegistroUsuario.UI.Registros
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        private bool ComboB = true;
        private Roles Usuario = new Roles();
        public Registro()
        {
            InitializeComponent();
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextID.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Id vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (TextAlias.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Alias vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TextEmail.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Email vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (TextCosto.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Costo x Hora vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ComboB)
            {
                esValido = false;
                MessageBox.Show("Nivel vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            

            return esValido;
        }

        private void Limpiar()
        {
            this.Usuario = new Roles();
            TextID.Text = string.Empty;
            TextAlias.Text = string.Empty;
            TextNombre.Text = string.Empty;
            TextCosto.Text = string.Empty;
            TextEmail.Text = string.Empty;
            TextClave.Password = string.Empty;
            TextConfClave.Password = string.Empty;
            ComboBoxItemAdministrador.IsSelected = false;
            ComboBoxItemUsuario.IsSelected = false;
            CheckBoxActivo.IsChecked = false;
           
        }
        private void limpiar()
        {
            TextAlias.Text = string.Empty;
            TextNombre.Text = string.Empty;
            TextCosto.Text = string.Empty;
            TextEmail.Text = string.Empty;
            TextClave.Password = string.Empty;
            TextConfClave.Password = string.Empty;
            ComboBoxItemAdministrador.IsSelected = false;
            ComboBoxItemUsuario.IsSelected = false;
            CheckBoxActivo.IsChecked = false;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextID.Text.Length == 0)
            {
                MessageBox.Show("Id vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Roles usuario = UsuarioBLL.Buscar(Convert.ToInt32(TextID.Text));

            if (usuario == null)
            {
                this.Usuario = usuario;
                Limpiar();
                MessageBox.Show("No existe el usuario con este ID", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                limpiar();
                TextNombre.Text = usuario.Nombres;
                TextAlias.Text = usuario.Alias;
                TextEmail.Text = usuario.Email;
                TextCosto.Text = Convert.ToString(usuario.CostoXHora);
                TextConfClave.Password = usuario.ConfirmarClave;
                TextClave.Password = usuario.Clave;
                if ((string)ComboBoxItemAdministrador.Content == usuario.Nivel)
                    ComboBoxItemAdministrador.IsSelected = true;

                if ((string)ComboBoxItemUsuario.Content == usuario.Nivel)
                    ComboBoxItemUsuario.IsSelected = true;

                if(usuario.Activo == "Activo")
                {
                    CheckBoxActivo.IsChecked = true;
                }
            }


        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            ComboB = true;
            Usuario.ID = Convert.ToInt32(TextID.Text);
            Usuario.Alias = TextAlias.Text;
            Usuario.Nombres = TextNombre.Text;
            Usuario.Email = TextEmail.Text;
            Usuario.CostoXHora = Convert.ToInt32(TextCosto.Text);
            Usuario.Clave = TextClave.Password;
            Usuario.ConfirmarClave = TextConfClave.Password;
            var paso = UsuarioBLL.Guardar(Usuario);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);


        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (TextID.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el ID para poder eliminar el registro.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (UsuarioBLL.Eliminar(Convert.ToInt32(TextID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void selecAdministrador(object sender, RoutedEventArgs e)
        {
            
            Usuario.Nivel = (string)ComboBoxItemAdministrador.Content;
            ComboB = false;
        }

        private void SeleUsuario(object sender, RoutedEventArgs e)
        {
            
           
            Usuario.Nivel = (string)ComboBoxItemUsuario.Content;
            ComboB = false;

        }

        private void Activo(object sender, RoutedEventArgs e)
        {
            Usuario.Activo = (string)CheckBoxActivo.Content;
        }
    }
}
