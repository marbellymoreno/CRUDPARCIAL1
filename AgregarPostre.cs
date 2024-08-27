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
        PostresDAL _postresDAL;
        int _id;
        public AgregarPostre(int id = 0)
        {
            _id = id;
            InitializeComponent();
            if (_id > 0)
            {
                _postresDAL = new PostresDAL();
                var datos = _postresDAL.ObtenerPostresPorId(_id);
                textBoxNombre.Text = datos.Nombre;
                textBoxDescripcion.Text = datos.Descripcion;
                textBoxPrecio.Text = datos.Precio.ToString();
                textBoxCalorias.Text = datos.Calorias.ToString();
                textBoxStock.Text = datos.Stock.ToString();
                dateTimeFV.Value = datos.FechaVencimiento;
                checkBoxEstado.Checked = datos.Estado;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _postresDAL = new PostresDAL();

                if (_id > 0)
                {
                    // Editar un postre existente
                    Postres postre = new Postres
                    {
                        IdPostre = _id, // Asigna el ID del postre que se va a actualizar
                        Nombre = textBoxNombre.Text,
                        Descripcion = textBoxDescripcion.Text,
                        Precio = decimal.Parse(textBoxPrecio.Text),
                        FechaVencimiento = dateTimeFV.Value,
                        Estado = checkBoxEstado.Checked,
                        Stock = int.Parse(textBoxStock.Text),
                        Calorias = int.Parse(textBoxCalorias.Text),
                    };

                    int filasAfectadas = _postresDAL.ActualizarPostre(postre);

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("El postre se actualizó exitosamente.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ningún postre. Verifique el ID.");
                    }
                }
                else
                {
                    // Agregar un nuevo postre
                    Postres postre = new Postres
                    {
                        Nombre = textBoxNombre.Text,
                        Descripcion = textBoxDescripcion.Text,
                        Precio = decimal.Parse(textBoxPrecio.Text),
                        FechaVencimiento = dateTimeFV.Value,
                        Estado = checkBoxEstado.Checked,
                        Stock = int.Parse(textBoxStock.Text),
                        Calorias = int.Parse(textBoxCalorias.Text),
                    };

                    int filasAfectadas = _postresDAL.InsertarPostre(postre);

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Se agregó un postre.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
