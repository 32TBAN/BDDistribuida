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
    public partial class Publicar : Form
    {
        public Publicacion publicacion = new Publicacion();
        public Publicar(Publicacion pulicacion)
        {
            InitializeComponent();
            this.publicacion = pulicacion;
            button_OK.Enabled = false;
            label_Contrasena.Enabled = false;
            textBox_Contrase.Enabled = false;
        }

        private void Publicar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                publicacion.NombrePub = textBox_NombrePub.Text;
                if (publicacion.Filtro == "")
                {
                    NegocioPublicacion.PublicarReplicaSinFiltro(publicacion);
                    MessageBox.Show("Se ha publicado");
                    textBox_NombrePub.Enabled = false;
                    textBox_Contrase.Enabled = false;
                    button_OK.Enabled = false;
                    button_B.Enabled = false;
                }
                else
                {
                    NegocioPublicacion.PublicarReplicaConFiltro(publicacion);
                    MessageBox.Show("Se ha publicado");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }    
        }

        private void textBox_NombrePub_TextChanged(object sender, EventArgs e)
        {
            if (textBox_NombrePub.Text != "")
            {
                label_Contrasena.Enabled = true;
                textBox_Contrase.Enabled = true;
            }
            else
            {
                label_Contrasena.Enabled = false;
                textBox_Contrase.Enabled = false;
            }
        }

        private void textBox_Contrase_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contrase.Text != "")
            {
                button_OK.Enabled = true;
            }
            else
            {
                button_OK.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            BaseDatos baseDatos = new BaseDatos(publicacion);
            baseDatos.Show();
        }
    }
}
