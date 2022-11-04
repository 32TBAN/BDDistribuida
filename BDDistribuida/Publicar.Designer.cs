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
            this.button_OK.Size = new System.Drawing.Size(56, 23);
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
            // Publicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 277);
            this.Controls.Add(this.textBox_Contrase);
            this.Controls.Add(this.label_Contrasena);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_NombrePub);
            this.Controls.Add(this.label1);
            this.Name = "Publicar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pulicacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Publicar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NombrePub;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_Contrase;
        private System.Windows.Forms.Label label_Contrasena;
    }
}