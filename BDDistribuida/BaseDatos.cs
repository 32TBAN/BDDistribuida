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
        public Instancia instancia { get; set; }
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
        }

        private void BaseDatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_BD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var num = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Num"].Value.ToString());
                BuscarBodega(num);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
