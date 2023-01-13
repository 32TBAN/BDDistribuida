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
        public Publicacion instancia = new Publicacion();
        public BaseDatos(Publicacion instancia)
        {
            InitializeComponent();
            this.instancia = instancia;
            CargarBD();
        }

        private void CargarBD()
        {
            List<Publicacion> baseDatos = NegocioPublicacion.DevolverBD(instancia.NombreInstancia);
            dataGridView_BD.DataSource = baseDatos;
            dataGridView_BD.Columns["Tabla"].Visible = false;
            dataGridView_BD.Columns["BaseDatos"].Visible = false;
            dataGridView_BD.Columns["Filtro"].Visible = false;
            dataGridView_BD.Columns["NombrePub"].Visible = false;
            dataGridView_BD.Columns["Contraseña"].Visible = false;

        }

        private void BaseDatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_BD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                instancia.BaseDatos = dataGridView_BD.Rows[e.RowIndex].Cells["NombreInstancia"].Value.ToString();
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
            dataGridView_Columnas.DataSource = null;
            dataGridView_Datos.DataSource = null;
            dataGridView_Datos.DataSource = NegocioPublicacion.DevolverTablas(bd,instancia.NombreInstancia);
            dataGridView_Datos.Columns["Tabla"].Visible = false;
            dataGridView_Datos.Columns["BaseDatos"].Visible = false;
            dataGridView_Datos.ColumnHeadersVisible = false;
            dataGridView_Datos.Columns["Filtro"].Visible = false;
            dataGridView_Datos.Columns["NombrePub"].Visible = false;
            dataGridView_Datos.Columns["Contraseña"].Visible = false;

        }

        private void dataGridView_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                instancia.Tabla = dataGridView_Datos.Rows[e.RowIndex].Cells["NombreInstancia"].Value.ToString();
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
            dataGridView_Columnas.DataSource = NegocioPublicacion.DevolverColumnas(instancia);
            dataGridView_Columnas.Columns["Tabla"].Visible = false;
            dataGridView_Columnas.Columns["BaseDatos"].Visible = false;
            dataGridView_Columnas.ColumnHeadersVisible = false;
            dataGridView_Columnas.Columns["Filtro"].Visible = false;
            dataGridView_Columnas.Columns["NombrePub"].Visible = false;
            dataGridView_Columnas.Columns["Contraseña"].Visible = false;

        }

        private void dataGridView_Columnas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var c = dataGridView_Columnas.Rows[e.RowIndex].Cells["NombreInstancia"].Value.ToString();
                //if (label_Consulta.Text.Length != 6)
                //{
                //    label_Consulta.Text += " ," + c;
                //}
                //else
                //{
                //    label_Consulta.Text += " " + c;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (instancia.BaseDatos != null  || instancia.Tabla != null)
            {
                Publicar publicar = new Publicar(instancia);
                publicar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Faltan datos para relizar la replica");
            }
        }
    }
}
