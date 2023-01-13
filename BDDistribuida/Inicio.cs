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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            f1.FormClosed += F1_FormClosed;
        }

        private void F1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)(sender)).BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)(sender)).BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
