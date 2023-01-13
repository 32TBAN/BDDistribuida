namespace BDDistribuida
{
    partial class BaseDatos
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_BD = new System.Windows.Forms.DataGridView();
            this.dataGridView_Datos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_Columnas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Columnas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publicacion de base de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Escoja una base de datos";
            // 
            // dataGridView_BD
            // 
            this.dataGridView_BD.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_BD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_BD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_BD.Location = new System.Drawing.Point(15, 59);
            this.dataGridView_BD.Name = "dataGridView_BD";
            this.dataGridView_BD.Size = new System.Drawing.Size(172, 150);
            this.dataGridView_BD.TabIndex = 2;
            this.dataGridView_BD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_BD_CellClick);
            // 
            // dataGridView_Datos
            // 
            this.dataGridView_Datos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Datos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Datos.Location = new System.Drawing.Point(193, 59);
            this.dataGridView_Datos.Name = "dataGridView_Datos";
            this.dataGridView_Datos.Size = new System.Drawing.Size(168, 150);
            this.dataGridView_Datos.TabIndex = 5;
            this.dataGridView_Datos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Datos_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Escoja una tabla";
            // 
            // dataGridView_Columnas
            // 
            this.dataGridView_Columnas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Columnas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Columnas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Columnas.Location = new System.Drawing.Point(367, 90);
            this.dataGridView_Columnas.Name = "dataGridView_Columnas";
            this.dataGridView_Columnas.Size = new System.Drawing.Size(155, 119);
            this.dataGridView_Columnas.TabIndex = 7;
            this.dataGridView_Columnas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Columnas_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Escoja las columnas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Publicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BaseDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView_Columnas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView_Datos);
            this.Controls.Add(this.dataGridView_BD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BaseDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseDatos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseDatos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_BD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Columnas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_BD;
        private System.Windows.Forms.DataGridView dataGridView_Datos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_Columnas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}