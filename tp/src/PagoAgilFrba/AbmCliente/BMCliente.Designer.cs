namespace PagoAgilFrba.AbmCliente
{
    partial class BMCliente
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar por nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtrar por apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Filtrar por DNI";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(436, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(436, 72);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(436, 110);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(435, 323);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(75, 23);
            this.btnModif.TabIndex = 7;
            this.btnModif.Text = "Modificar";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(331, 323);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 5;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(232, 323);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // BMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 384);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BMCliente";
            this.Text = "BMCliente";
            this.Load += new System.EventHandler(this.BMCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnFiltrar;
    }
}