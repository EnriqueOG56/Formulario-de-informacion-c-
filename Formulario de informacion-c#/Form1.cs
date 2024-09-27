using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_de_informacion_c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Agregar Controladores de eventos TextChanged a los campos
            txtEdad.TextChanged += ValidarEdad;
            txtEstatura.TextChanged += ValidarEstatura;
            //txttelefono.TextChanged += ValidarTelefono;
            txtTelefono.Leave += ValidarTelefono;
            txtNombre.TextChanged += ValidarNombre;
            txtApellidos.TextChanged += ValidarApellidos;

        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Obtener los datos
            string nombres = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string NumTel = txtTelefono.Text;
            string estatura = txtEstatura.Text;
            string edad = txtEdad.Text;

            // Genero seleccionado
            string genero = "";
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }

            // Cadena de datos
            string datos = $"Nombres: {nombres}\r\n Apellidos: {apellidos}\r\n Telefono: {NumTel} \r\n Estatura: {estatura} \r\n Edad: {edad} \r\n Genero: {genero}";

            // Datos en un archivo
            string rutaArchivo = "C:/Users/orozc/OneDrive/Documentos/Abraham Enrique UNACH NSEMESTRE 3PROGRAMACION AVANZADA.txt";

            // Verificar si el archivo ya existe
            bool archivoexiste = File.Exists(rutaArchivo);

            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                if (archivoexiste)
                {
                    // si el archivo existe, añadir el separador
                    writer.WriteLine("===============================");
                }
                writer.WriteLine(datos);

                // mostrar un mensaje con los datos guardados
                MessageBox.Show("Datos Guardados by: Enrique: \n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }
        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }
        private bool EsEnteroValido10digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;
        }
        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$"); // Esto para permitir espacios y Letras
        }
        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsEnteroValido(textbox.Text))
            {
                MessageBox.Show("Ingrese una edad valida", "Error Edad PGJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsDecimalValido(textBox.Text))
            {
                MessageBox.Show("Ingrese una estatura valida", "Error Estatura PGJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }
        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Length == 10 && EsEnteroValido10digitos(textbox.Text))
            {
                textbox.BackColor = Color.Green;
            }
            else
            {
                textbox.BackColor = Color.Red;
                MessageBox.Show("Ingrese un telefono de 10 digitos", "Error telefono PGJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }

        }
        private void ValidarApellidos(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Ingrese Apellidos Validos", "Error Apellidos PGJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }
        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (!EsTextoValido(textbox.Text))
            {
                MessageBox.Show("Ingrese Nombres Validos", "Error Nombres PGJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Limpiar txt rbt
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEdad.Clear();
            txtEstatura.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;

        }
    }
}

