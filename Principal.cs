﻿using Datos;
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
            _postresDAL = new PostresDAL();
            dgvPostres.DataSource = _postresDAL.ObtenerPostres();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
