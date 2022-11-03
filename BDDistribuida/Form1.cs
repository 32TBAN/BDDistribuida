using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDDistribuida.Entidades;
using BDDistribuida.Negocio;

namespace BDDistribuida
{
    public partial class Form1 : Form
    {
        public Instancia instancia = new Instancia();
        
        public Form1()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            comboBox_NombreServer.DataSource = NegocioInstancias.DevolverListaInstancias();
            comboBox_NombreServer.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instancia.Nombre = comboBox_NombreServer.Text;
            BaseDatos baseDatos = new BaseDatos(instancia);
            baseDatos.Show();
            this.Hide();
        }
    }
}
