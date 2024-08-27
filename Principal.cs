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
    public partial class Principal : Form
    {
        PostresDAL _postresDAL;
        public Principal()
        {
            InitializeComponent();
            Datos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _postresDAL = new PostresDAL();
            string nombre = textBoxNombre.Text;
            dgvPostres.DataSource = _postresDAL.ObtenerPostresPorNombre(nombre);
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            _postresDAL = new PostresDAL();
            string Nombre = textBoxNombre.Text;

            if (Nombre != "")
            {
                dgvPostres.DataSource = _postresDAL.Filtrar(Nombre);
            }
            else
            {
                dgvPostres.DataSource = _postresDAL.ObtenerPostres();
            }
        }

        private void Datos()
        {
            _postresDAL = new PostresDAL();
            dgvPostres.DataSource = _postresDAL.ObtenerPostres();
        }

        private void buttonPrinciAdd_Click(object sender, EventArgs e)
        {
            AgregarPostre agregarPostre = new AgregarPostre();
            agregarPostre.ShowDialog();
            Datos();
        }

        private void dgvPostres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int id = int.Parse(dgvPostres.Rows[e.RowIndex].Cells["IdPostre"].Value.ToString());

                    if (dgvPostres.Columns[e.ColumnIndex].Name.Equals("Editar"))
                    {
                        AgregarPostre agregarcliente = new AgregarPostre(id);
                        agregarcliente.ShowDialog();
                        Datos();
                    }
                    else if (dgvPostres.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                    {
                        var desicion = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Eliminar Postre", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        _postresDAL = new PostresDAL();

                        int resultado = 0;

                        if (desicion != DialogResult.Yes)
                        {
                            MessageBox.Show("El registro se continua mostrando en el listado.");
                        }
                        else
                        {
                            resultado = _postresDAL.EliminarPostre(id);
                            if (resultado > 0)
                            {
                                MessageBox.Show("El registro eliminado con exito.");
                                Datos();
                            }
                            else
                            {
                                MessageBox.Show("No se logró eliminar el registro.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error {ex}");
            }
        }
    }
}
