using RegistroUsuario.UI.Registros;
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

namespace RegistroUsuario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UsuarioMenuItem(object sender, RoutedEventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();

        }

        private void ConsultaUsuariosMenuItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No Diponible por el momento", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnHerramientas(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No Diponible por el momento", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
