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
using RegistroCompleto.BLL;
using RegistroCompleto.Entidades;



namespace RegistroCompleto.UI.Registros
{
    /// <summary>
    /// Interaction logic for Inscripcion.xaml
    /// </summary>
    public partial class Inscripcion : Window
    {
        private readonly object IdTextBox;

        public Inscripcion()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            PersonaIdTextBox.Text = string.Empty;
            ComentarioTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            FechaDate.SelectedDate = DateTime.Now;
        }

        private void NuevoButton(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionesBLL.Buscar((int)InscripcionIDnumericUpDown.Value);
            return (inscripcion != null);
        }



        private Inscripciones LlenaClase()
        {

            Inscripciones inscripcion = new Inscripciones();
            inscripcion.IncripcionId = Convert.ToInt32(IdTextBox.Text);
            inscripcion .Fecha = Convert.ToDateTime(FechaDate.SelectedDate);
            inscripcion.EstudianteId = Convert.ToInt32(PersonaIdTextBox.Text);
            inscripcion.Comentario = ComentarioTextBox.Text;
            inscripcion.Monto = Convert.ToInt32(MontonTextBox.Text);
            inscripcion.Balance = Convert.ToInt32(BalanceTextBox.Text);

            return inscripcion;
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (Depositonumeric.Value == 0)
            {

                Depositonumeric.Focus();
                paso = false;
            }


            return paso;
        }

        private void GuardarButton(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();

            if (InscripcionIDnumericUpDown.Value == 0)
                paso = InscripcionesBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar una Inscripcion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
