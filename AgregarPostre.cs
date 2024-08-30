using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPARCIAL1
{
    public partial class AgregarPostre : Form
    {
        PostresDAL _postresDAL; // Instancia de la capa de acceso a datos para postres
        int _id; // ID del postre que se está editando o agregando

        // Constructor de la clase, inicializa el formulario
        public AgregarPostre(int id = 0)
        {
            _id = id; // Asigna el ID del postre
            InitializeComponent(); // Inicializa los componentes del formulario

            // Si se proporciona un ID mayor que 0, se trata de editar un postre existente
            if (_id > 0)
            {
                _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL
                var datos = _postresDAL.ObtenerPostresPorId(_id); // Obtiene los datos del postre por ID

                // Rellena los campos del formulario con los datos del postre
                textBoxNombre.Text = datos.Nombre;
                textBoxDescripcion.Text = datos.Descripcion;
                textBoxPrecio.Text = datos.Precio.ToString();
                textBoxCalorias.Text = datos.Calorias.ToString();
                textBoxStock.Text = datos.Stock.ToString();
                dateTimeFV.Value = datos.FechaVencimiento;
                checkBoxEstado.Checked = datos.Estado;
            }
        }

        // Evento para el clic del botón "Guardar"
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL

                if (_id > 0)
                {
                    // Editar un postre existente
                    Postres postre = new Postres
                    {
                        IdPostre = _id, // Asigna el ID del postre
                        Nombre = textBoxNombre.Text,
                        Descripcion = textBoxDescripcion.Text,
                        Precio = decimal.Parse(textBoxPrecio.Text), // Convierte el texto a decimal
                        FechaVencimiento = dateTimeFV.Value,
                        Estado = checkBoxEstado.Checked,
                        Stock = int.Parse(textBoxStock.Text), // Convierte el texto a entero
                        Calorias = int.Parse(textBoxCalorias.Text) // Convierte el texto a entero
                    };

                    int filasAfectadas = _postresDAL.ActualizarPostre(postre); // Actualiza el postre en la base de datos

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("El postre se actualizó exitosamente."); // Muestra mensaje de éxito
                        this.Close(); // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ningún postre. Verifique el ID."); // Mensaje si no se actualizó nada
                    }
                }
                else
                {
                    // Agregar un nuevo postre
                    Postres postre = new Postres
                    {
                        Nombre = textBoxNombre.Text,
                        Descripcion = textBoxDescripcion.Text,
                        Precio = decimal.Parse(textBoxPrecio.Text), // Convierte el texto a decimal
                        FechaVencimiento = dateTimeFV.Value,
                        Estado = checkBoxEstado.Checked,
                        Stock = int.Parse(textBoxStock.Text), // Convierte el texto a entero
                        Calorias = int.Parse(textBoxCalorias.Text) // Convierte el texto a entero
                    };

                    int filasAfectadas = _postresDAL.InsertarPostre(postre); // Inserta el nuevo postre en la base de datos

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Se agregó un postre."); // Muestra mensaje de éxito
                        this.Close(); // Cierra el formulario
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        // Evento para el clic del botón "Atrás"
        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}