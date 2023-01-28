using BDDistribuida.Entidades;
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
    public partial class ReplicaA : Form
    {
        public Publicacion instancia = new Publicacion();

        public ReplicaA(Publicacion instancia)
        {
            InitializeComponent();
            this.instancia = instancia;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BaseDatos baseDatos = new BaseDatos(instancia);
            baseDatos.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BaseDatos baseDatos = new BaseDatos(instancia);
            baseDatos.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            BaseDatos baseDatos = new BaseDatos(instancia);
            baseDatos.Show();
            this.Hide();
        }
    }
}
