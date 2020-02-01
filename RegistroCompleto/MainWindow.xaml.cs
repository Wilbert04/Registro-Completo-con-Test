using RegistroCompleto.BLL;
using RegistroCompleto.Entidades;
using RegistroCompleto.UI.Registros;
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
using RegistroCompleto.UI;

namespace RegistroCompleto
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

        private void ConsultaCombobox(object sender, SelectionChangedEventArgs e)
        {
            switch (ConsultaCombobox.SelectedIndex)
            {
                case 0:
                    RegistroPersona registro = new RegistroPersona();
                    registro.Show();
                    break;
                case 1:
                    RegistroInscripcion inscricion = new RegistroInscripcion();
                    inscricion.Show();
                    break;
              
            }
        }
    }
}