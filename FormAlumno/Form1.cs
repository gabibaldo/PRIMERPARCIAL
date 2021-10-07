using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAlumno
{
    public partial class Form1 : Form
    {
        private List<Alumno> alumnos = new List<Alumno>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                alumnos.Add(new Alumno(txtNombre.Text, txtApellido.Text, Int32.Parse(txtDni.Text), txtLegajo.Text, txtCarrera.Text, Int32.Parse(txtAñoinsc.Text),
                    Int32.Parse(txtAñoNacimiento.Text), txtMailContacto.Text));
                MessageBox.Show("Alumno agregado correctamente!");
                txtNombre.Clear();
                txtApellido.Clear();
                txtDni.Clear();
                txtLegajo.Clear();
                txtCarrera.Clear();
                txtAñoinsc.Clear();
                txtAñoNacimiento.Clear();
                txtMailContacto.Clear();
                dgvAlumnos.Rows.Clear();
                if (alumnos.Count == 1)
                {
                    lblDatos.Text = "Usted ha ingresado: " + (alumnos.Count) + " Alumno.";
                }
                else
                {
                    lblDatos.Text = "Usted ha ingresado: " + (alumnos.Count) + " Alumnos.";
                }
            }
            else
            {
                MessageBox.Show("Intente nuevamente");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtLegajo.Clear();
            txtCarrera.Clear();
            txtAñoinsc.Clear();
            txtAñoNacimiento.Clear();
            txtMailContacto.Clear();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            foreach (Alumno alum in alumnos)
            {
                dgvAlumnos.Rows.Add(alum.Nombre, alum.Apellido, alum.DNI, alum.FechaNacimiento, alum.MailContacto,
                    alum.Legajo, alum.Carrera, alum.AñoInscripcion); 
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Validación para los campos ingresados por el usuario
        private bool Validar()
        {
            bool datoValido;
            datoValido = true;

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El Nombre esta vacio");
                txtNombre.Focus();
                datoValido = false;
            }

            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("El Apellido esta vacio");
                txtApellido.Focus();
                datoValido = false;
            }

            try
            {
                Int32.Parse(txtDni.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El dato DNI es incorrecto o esta vacio.");
                datoValido = false;
            }

            if (txtLegajo.Text.Trim() == "")
            {
                MessageBox.Show("El Legajo esta vacio.");
                txtLegajo.Focus();
                datoValido = false;
            }

            if (txtCarrera.Text.Trim() == "")
            {
                MessageBox.Show("La Carrera esta vacia.");
                txtCarrera.Focus();
                datoValido = false;
            }

            try
            {
                Int32.Parse(txtAñoinsc.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Año de Inscripción es incorrecto o esta vacio.");
                datoValido = false;
            }

            try
            {
                if (Int32.Parse(txtAñoNacimiento.Text.Trim()) > 2002)
                {
                    MessageBox.Show("¡Para poder inscribirse hay que ser mayor de 18 años!");
                    txtAñoNacimiento.Focus();
                    datoValido = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Año de Nacimiento es incorrecto o esta vacio.");
                datoValido = false;
            }

            if (txtMailContacto.Text.Trim() == "")
            {
                MessageBox.Show("El mail de contacto esta vacio.");
                txtMailContacto.Focus();
                datoValido = false;
            }

            return datoValido;
        }
    }
}