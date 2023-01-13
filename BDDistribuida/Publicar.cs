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
        List<Suscripcion> datosSuscripcion = new List<Suscripcion>();
        private string NombreInstanciaS;
        public Publicar(Publicacion pulicacion)
        {
            InitializeComponent();
            this.publicacion = pulicacion;
            button_OK.Enabled = false;
            label_Contrasena.Enabled = false;
            textBox_Contrase.Enabled = false;
            comboBox1.Enabled = false;
            button_Sus.Enabled = false;
            dataGridView_BD.Enabled = false;
            dataGridView_BD.Visible = false;
            button_Sus.Enabled = false;
            CargarInstancias();
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
                publicacion.Contraseña = textBox_Contrase.Text;

                NegocioPublicacion.PublicarReplicaSinFiltro(publicacion);
                MessageBox.Show("Se ha publicado");
                textBox_NombrePub.Enabled = false;
                textBox_Contrase.Enabled = false;
                button_OK.Enabled = false;
                button_B.Enabled = false;
                button_Sus.Enabled = true;
                CargarInstancias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }    
        }
        private void CargarInstancias()
        {
            List<Publicacion> baseDatos = NegocioPublicacion.DevolverListaInstancias();
            dataGridView_BD.DataSource = baseDatos;
            dataGridView_BD.Columns["Tabla"].Visible = false;
            dataGridView_BD.Columns["BaseDatos"].Visible = false;
            dataGridView_BD.Columns["Filtro"].Visible = false;
            dataGridView_BD.Columns["NombrePub"].Visible = false;
            dataGridView_BD.Columns["Contraseña"].Visible = false;

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
                button_Sus.Enabled = false;
                dataGridView_BD.Enabled = false;
                dataGridView_BD.Visible = false;
                textBox_Contrase.Text = "";
                richTextBox_SUS.Text = "";
                comboBox1.Enabled = false;
                comboBox1.Text = "";
            }
        }

        private void textBox_Contrase_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Contrase.Text != "")
            {
                button_OK.Enabled = true;
                dataGridView_BD.Enabled = true;
                dataGridView_BD.Visible = true;
            }
            else
            {
                button_OK.Enabled = false;
                dataGridView_BD.Enabled = false;
                dataGridView_BD.Visible = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BaseDatos baseDatos = new BaseDatos(publicacion);
            this.Hide();
            baseDatos.Show();
        }

        private void dataGridView_BD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NombreInstanciaS = dataGridView_BD.Rows[e.RowIndex].Cells["NombreInstancia"].Value.ToString();
                bool repetido = false;

                foreach (var item in datosSuscripcion)
                {
                    if (item.NombreIntanciaS == NombreInstanciaS)
                    {
                        repetido = true;
                    }
                }
                if (!repetido)
                {
                    //richTextBox_SUS.Text = "";
                    richTextBox_SUS.Text += NombreInstanciaS + " en ";
                    EscojerBD(NombreInstanciaS);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            comboBox1.Enabled = true;
            button_Sus.Enabled = true;
        }

        private void EscojerBD(string n)
        {
            comboBox1.DataSource = NegocioPublicacion.DevolverBD(n);
            comboBox1.DisplayMember = "NombreInstancia";
            comboBox1.Enabled = true;
            dataGridView_BD.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dataGridView_BD.Enabled)
            {
                richTextBox_SUS.Text += ((Publicacion)(comboBox1.SelectedValue)).NombreInstancia+"\n";
                dataGridView_BD.Enabled = true;
                datosSuscripcion.Add(new Suscripcion(NombreInstanciaS, ((Publicacion)(comboBox1.SelectedValue)).NombreInstancia));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox_SUS.Text = "";
            datosSuscripcion.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                NegocioPublicacion.RealizarSuscripcion(publicacion,datosSuscripcion);
                MessageBox.Show("Se ha creado la suscripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
