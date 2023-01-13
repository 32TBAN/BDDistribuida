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
        public Publicacion instancia = new Publicacion();
        
        public Form1()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            comboBox_NombreServer.DataSource = NegocioPublicacion.DevolverListaInstancias();
            comboBox_NombreServer.DisplayMember = "NombreInstancia";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            instancia.NombreInstancia = comboBox_NombreServer.Text;
            BaseDatos baseDatos = new BaseDatos(instancia);
            baseDatos.Show();
            this.Hide();
        }


    }
}
