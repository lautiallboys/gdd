namespace PagoAgilFrba.AbmSucursal
{
    partial class AltaSucursal
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
            this.txtSucu_direccion = new System.Windows.Forms.TextBox();
            this.txtSucu_nombre = new System.Windows.Forms.TextBox();
            this.lblSucu_direccion = new System.Windows.Forms.Label();
            this.lblSucu_nombre = new System.Windows.Forms.Label();
            this.lblSucu_codigo_postal = new System.Windows.Forms.Label();
            this.txtSucu_codigo_postal = new System.Windows.Forms.TextBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSucu_direccion
            // 
            this.txtSucu_direccion.Location = new System.Drawing.Point(241, 80);
            this.txtSucu_direccion.Name = "txtSucu_direccion";
            this.txtSucu_direccion.Size = new System.Drawing.Size(100, 20);
            this.txtSucu_direccion.TabIndex = 4;
            // 
            // txtSucu_nombre
            // 
            this.txtSucu_nombre.Location = new System.Drawing.Point(241, 45);
            this.txtSucu_nombre.Name = "txtSucu_nombre";
            this.txtSucu_nombre.Size = new System.Drawing.Size(100, 20);
            this.txtSucu_nombre.TabIndex = 5;
            // 
            // lblSucu_direccion
            // 
            this.lblSucu_direccion.AutoSize = true;
            this.lblSucu_direccion.Location = new System.Drawing.Point(30, 87);
            this.lblSucu_direccion.Name = "lblSucu_direccion";
            this.lblSucu_direccion.Size = new System.Drawing.Size(109, 13);
            this.lblSucu_direccion.TabIndex = 2;
            this.lblSucu_direccion.Text = "Direccion de sucursal";
            // 
            // lblSucu_nombre
            // 
            this.lblSucu_nombre.AutoSize = true;
            this.lblSucu_nombre.Location = new System.Drawing.Point(30, 45);
            this.lblSucu_nombre.Name = "lblSucu_nombre";
            this.lblSucu_nombre.Size = new System.Drawing.Size(101, 13);
            this.lblSucu_nombre.TabIndex = 3;
            this.lblSucu_nombre.Text = "Nombre de sucursal";
            // 
            // lblSucu_codigo_postal
            // 
            this.lblSucu_codigo_postal.AutoSize = true;
            this.lblSucu_codigo_postal.Location = new System.Drawing.Point(30, 129);
            this.lblSucu_codigo_postal.Name = "lblSucu_codigo_postal";
            this.lblSucu_codigo_postal.Size = new System.Drawing.Size(71, 13);
            this.lblSucu_codigo_postal.TabIndex = 2;
            this.lblSucu_codigo_postal.Text = "Codigo postal";
            // 
            // txtSucu_codigo_postal
            // 
            this.txtSucu_codigo_postal.Location = new System.Drawing.Point(241, 126);
            this.txtSucu_codigo_postal.Name = "txtSucu_codigo_postal";
            this.txtSucu_codigo_postal.Size = new System.Drawing.Size(100, 20);
            this.txtSucu_codigo_postal.TabIndex = 4;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(105, 187);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 6;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // AltaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 232);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.txtSucu_codigo_postal);
            this.Controls.Add(this.txtSucu_direccion);
            this.Controls.Add(this.txtSucu_nombre);
            this.Controls.Add(this.lblSucu_codigo_postal);
            this.Controls.Add(this.lblSucu_direccion);
            this.Controls.Add(this.lblSucu_nombre);
            this.Name = "AltaSucursal";
            this.Text = "AltaSucursal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSucu_direccion;
        private System.Windows.Forms.TextBox txtSucu_nombre;
        private System.Windows.Forms.Label lblSucu_direccion;
        private System.Windows.Forms.Label lblSucu_nombre;
        private System.Windows.Forms.Label lblSucu_codigo_postal;
        private System.Windows.Forms.TextBox txtSucu_codigo_postal;
        private System.Windows.Forms.Button btnAlta;
    }
}