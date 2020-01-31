using RegistroCompleto.BLL;
using RegistroCompleto.Entidades;
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

namespace RegistroCompleto.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaDate1.SelectedDate = DateTime.Now;
        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaID = Convert.ToInt32(IdTextBox.Text);
            persona.Nombre = NombreTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(FechaDate1.SelectedDate);

            return persona;
        }

        private bool ExisteEnLaBaseDeDatos() // VERIFICA SI UNA PERSONA EXISTE EN LA BASE DE DATOS
        {
            Persona persona = RegistroBLL.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (persona != null);
        }

        private bool Corregir()     // CREE ESTE METODO PARA QUE CAPTURE ERRORES CUANDO SE DEJA ALGUN CAMPO VACIO, 
                                    // YA QUE EL METODO DEL PDF NO ME APARECE
        {
            bool estado = false;

            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show("Este Campo no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                estado = true;
            }
            return estado;

        }

        private bool validar()
        {
            bool paso = true;
            //  MyErrorProvider.Clear();

            if (NombreTextBox.Text == String.Empty)
            {
                Corregir();
                // MyErrorProvider.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                Corregir();
                //  MyErrorProvider.SetError(DireccionTextBox, "El campo no puede esta vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text.Replace("-", "")))
            {
                Corregir();
                //   MyErrorProvider.SetError.SetError(CedulaTextBox, "El campo cedula no puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;
            }

            return paso;

        }

        private void LlenaCampo(Persona persona)
        {
            IdTextBox.Text = Convert.ToString(persona.PersonaID);
            NombreTextBox.Text = persona.Nombre;
            CedulaTextBox.Text = persona.Cedula;
            TelefonoTextBox.Text = persona.Telefono;
            DireccionTextBox.Text = persona.Direccion;
            FechaDate1.SelectedDate = persona.FechaNacimiento;

        }

        private void Button_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            Persona persona;

            bool paso = false;
            if (!validar())
                return;

            persona = LlenaClase();

            Corregir();

            if (IdTextBox.Text == "0")
            {
                paso = RegistroBLL.Guardar(persona);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("NO SE PUEDE MOFICICAR PERSONAS QUE NO EXISTEN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = RegistroBLL.Modificar(persona);
            }

            Corregir();

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con EXITO!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {

            int ID;
            Persona persona = new Persona();

            int.TryParse(IdTextBox.Text, out ID);

            Limpiar();

            if (RegistroBLL.Eliminar(ID))
                MessageBox.Show("ELiminado", "EXITOO!!!", MessageBoxButton.OK, MessageBoxImage.Information);



        }

        private void Button_Buscar(object sender, RoutedEventArgs e)
        {
            int ID;
            Persona persona = new Persona();

            int.TryParse(IdTextBox.Text, out ID);

            Limpiar();

            persona = RegistroBLL.Buscar(ID);

            if (persona != null)
            {
                MessageBox.Show("PERSONA ENCONTRADA");
                LlenaCampo(persona);
            }
        }
    }
}
