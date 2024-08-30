using Datos; // Espacio de nombres para la capa de acceso a datos
using Modelos; // Espacio de nombres para los modelos de datos
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
    public partial class Principal : Form
    {
        PostresDAL _postresDAL; // Instancia de la capa de acceso a datos para postres

        // Constructor de la clase, inicializa el formulario y carga los datos
        public Principal()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
            Datos(); // Carga los datos iniciales en el DataGridView
        }

        // Evento para el clic del botón "Buscar"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL
            string nombre = textBoxNombre.Text; // Obtiene el nombre del postre del TextBox
            dgvPostres.DataSource = _postresDAL.ObtenerPostresPorNombre(nombre); // Actualiza el DataGridView con los postres filtrados por nombre
        }

        // Evento para el cambio de texto en el TextBox "Nombre"
        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL
            string Nombre = textBoxNombre.Text; // Obtiene el texto del TextBox

            if (Nombre != "")
            {
                // Si el TextBox no está vacío, filtra los postres por nombre
                dgvPostres.DataSource = _postresDAL.Filtrar(Nombre);
            }
            else
            {
                // Si el TextBox está vacío, muestra todos los postres
                dgvPostres.DataSource = _postresDAL.ObtenerPostres();
            }
        }

        // Método para cargar los datos de todos los postres en el DataGridView
        private void Datos()
        {
            _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL
            dgvPostres.DataSource = _postresDAL.ObtenerPostres(); // Obtiene todos los postres y los muestra en el DataGridView
        }

        // Evento para el clic del botón "Agregar Postre"
        private void buttonPrinciAdd_Click(object sender, EventArgs e)
        {
            AgregarPostre agregarPostre = new AgregarPostre(); // Crea una instancia del formulario para agregar un nuevo postre
            agregarPostre.ShowDialog(); // Muestra el formulario como un diálogo modal
            Datos(); // Vuelve a cargar los datos en el DataGridView después de agregar el postre
        }

        // Evento para el clic en una celda del DataGridView
        private void dgvPostres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verifica que el clic esté dentro de una celda válida
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int id = int.Parse(dgvPostres.Rows[e.RowIndex].Cells["IdPostre"].Value.ToString()); // Obtiene el ID del postre desde la celda

                    if (dgvPostres.Columns[e.ColumnIndex].Name.Equals("Editar"))
                    {
                        // Si la columna es "Editar", abre el formulario para editar el postre seleccionado
                        AgregarPostre agregarcliente = new AgregarPostre(id);
                        agregarcliente.ShowDialog();
                        Datos(); // Vuelve a cargar los datos en el DataGridView después de editar
                    }
                    else if (dgvPostres.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                    {
                        // Si la columna es "Eliminar", muestra un mensaje de confirmación para eliminar el postre
                        var desicion = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Eliminar Postre", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        _postresDAL = new PostresDAL(); // Crea una instancia de PostresDAL

                        int resultado = 0;

                        if (desicion != DialogResult.Yes)
                        {
                            MessageBox.Show("El registro se continúa mostrando en el listado."); // Mensaje si se cancela la eliminación
                        }
                        else
                        {
                            // Si se confirma la eliminación, elimina el postre de la base de datos
                            resultado = _postresDAL.EliminarPostre(id);
                            if (resultado > 0)
                            {
                                MessageBox.Show("El registro eliminado con éxito."); // Mensaje de éxito
                                Datos(); // Vuelve a cargar los datos en el DataGridView después de eliminar
                            }
                            else
                            {
                                MessageBox.Show("No se logró eliminar el registro."); // Mensaje si no se pudo eliminar el registro
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show($"Ocurrió un error: {ex}");
            }
        }
    }
}
