namespace BDDistribuida
{
    partial class Publicar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_NombrePub = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_Contrase = new System.Windows.Forms.TextBox();
            this.label_Contrasena = new System.Windows.Forms.Label();
            this.label_Suscripcion = new System.Windows.Forms.Label();
            this.button_B = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_BD = new System.Windows.Forms.DataGridView();
            this.label_Suscripciones = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_SUS = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la publicacion";
            // 
            // textBox_NombrePub
            // 
            this.textBox_NombrePub.Location = new System.Drawing.Point(145, 6);
            this.textBox_NombrePub.Name = "textBox_NombrePub";
            this.textBox_NombrePub.Size = new System.Drawing.Size(288, 20);
            this.textBox_NombrePub.TabIndex = 1;
            this.textBox_NombrePub.TextChanged += new System.EventHandler(this.textBox_NombrePub_TextChanged);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(439, 34);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(68, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "Ok";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Contrase
            // 
            this.textBox_Contrase.Location = new System.Drawing.Point(145, 36);
            this.textBox_Contrase.Name = "textBox_Contrase";
            this.textBox_Contrase.Size = new System.Drawing.Size(288, 20);
            this.textBox_Contrase.TabIndex = 4;
            this.textBox_Contrase.UseSystemPasswordChar = true;
            this.textBox_Contrase.TextChanged += new System.EventHandler(this.textBox_Contrase_TextChanged);
            // 
            // label_Contrasena
            // 
            this.label_Contrasena.AutoSize = true;
            this.label_Contrasena.Location = new System.Drawing.Point(12, 39);
            this.label_Contrasena.Name = "label_Contrasena";
            this.label_Contrasena.Size = new System.Drawing.Size(112, 13);
            this.label_Contrasena.TabIndex = 3;
            this.label_Contrasena.Text = "Ingrese su contraseña";
            // 
            // label_Suscripcion
            // 
            this.label_Suscripcion.AutoSize = true;
            this.label_Suscripcion.Location = new System.Drawing.Point(12, 76);
            this.label_Suscripcion.Name = "label_Suscripcion";
            this.label_Suscripcion.Size = new System.Drawing.Size(73, 13);
            this.label_Suscripcion.TabIndex = 5;
            this.label_Suscripcion.Text = "Suscripciones";
            // 
            // button_B
            // 
            this.button_B.Location = new System.Drawing.Point(439, 3);
            this.button_B.Name = "button_B";
            this.button_B.Size = new System.Drawing.Size(68, 23);
            this.button_B.TabIndex = 6;
            this.button_B.Text = "Back";
            this.button_B.UseVisualStyleBackColor = true;
            this.button_B.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Escoja las instancias";
            // 
            // dataGridView_BD
            // 
            this.dataGridView_BD.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_BD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_BD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_BD.Location = new System.Drawing.Point(12, 115);
            this.dataGridView_BD.Name = "dataGridView_BD";
            this.dataGridView_BD.Size = new System.Drawing.Size(172, 150);
            this.dataGridView_BD.TabIndex = 8;
            this.dataGridView_BD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_BD_CellClick);
            // 
            // label_Suscripciones
            // 
            this.label_Suscripciones.AutoSize = true;
            this.label_Suscripciones.Location = new System.Drawing.Point(192, 163);
            this.label_Suscripciones.Name = "label_Suscripciones";
            this.label_Suscripciones.Size = new System.Drawing.Size(88, 13);
            this.label_Suscripciones.TabIndex = 9;
            this.label_Suscripciones.Text = "Suscripciones a: ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(193, 130);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(240, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Base de datos";
            // 
            // richTextBox_SUS
            // 
            this.richTextBox_SUS.Location = new System.Drawing.Point(193, 179);
            this.richTextBox_SUS.Name = "richTextBox_SUS";
            this.richTextBox_SUS.Size = new System.Drawing.Size(238, 96);
            this.richTextBox_SUS.TabIndex = 12;
            this.richTextBox_SUS.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "Crear suscripcion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(439, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 38);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Publicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 277);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox_SUS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_Suscripciones);
            this.Controls.Add(this.dataGridView_BD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_B);
            this.Controls.Add(this.label_Suscripcion);
            this.Controls.Add(this.textBox_Contrase);
            this.Controls.Add(this.label_Contrasena);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_NombrePub);
            this.Controls.Add(this.label1);
            this.Name = "Publicar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pulicacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Publicar_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NombrePub;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_Contrase;
        private System.Windows.Forms.Label label_Contrasena;
        private System.Windows.Forms.Label label_Suscripcion;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_BD;
        private System.Windows.Forms.Label label_Suscripciones;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox_SUS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}