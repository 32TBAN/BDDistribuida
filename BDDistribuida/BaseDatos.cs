using BDDistribuida.Entidades;
using BDDistribuida.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDDistribuida
{
    public partial class BaseDatos : Form
    {
        public Instancia instancia = new Instancia();
        public BaseDatos(Instancia instancia)
        {
            InitializeComponent();
            this.instancia = instancia;
            CargarBD();
        }

        private void CargarBD()
        {
            List<Instancia> baseDatos = NegocioInstancias.DevolverBD(instancia.Nombre);
            dataGridView_BD.DataSource = baseDatos;
            dataGridView_BD.Columns["Tabla"].Visible = false;
            dataGridView_BD.Columns["BaseDatos"].Visible = false;

        }

        private void BaseDatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_BD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                instancia.BaseDatos = dataGridView_BD.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                CargarTablas(instancia.BaseDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CargarTablas(string bd)
        {
            dataGridView_Datos.DataSource = null;
            dataGridView_Datos.DataSource = NegocioInstancias.DevolverTablas(bd,instancia.Nombre);
            dataGridView_Datos.Columns["Tabla"].Visible = false;
            dataGridView_Datos.Columns["BaseDatos"].Visible = false;
        }

        private void dataGridView_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                instancia.Tabla = dataGridView_BD.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                CargarColumnas(instancia.Tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CargarColumnas(string tabla)
        {
            dataGridView_Columnas.DataSource = null;
            dataGridView_Columnas.DataSource = NegocioInstancias.DevolverColumnas(instancia);
            dataGridView_Columnas.Columns["Tabla"].Visible = false;
            dataGridView_Columnas.Columns["BaseDatos"].Visible = false;
        }
    }
}
