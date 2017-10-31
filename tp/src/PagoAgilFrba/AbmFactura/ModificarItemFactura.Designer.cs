namespace PagoAgilFrba.AbmFactura
{
    partial class ModificarItemFactura
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
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblSucu_direccion = new System.Windows.Forms.Label();
            this.lblSucu_nombre = new System.Windows.Forms.Label();
            this.lblSucu_codigo_postal = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(122, 38);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 1;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(122, 12);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(100, 20);
            this.txtConcepto.TabIndex = 0;
            // 
            // lblSucu_direccion
            // 
            this.lblSucu_direccion.AutoSize = true;
            this.lblSucu_direccion.Location = new System.Drawing.Point(12, 41);
            this.lblSucu_direccion.Name = "lblSucu_direccion";
            this.lblSucu_direccion.Size = new System.Drawing.Size(37, 13);
            this.lblSucu_direccion.TabIndex = 2;
            this.lblSucu_direccion.Text = "Monto";
            // 
            // lblSucu_nombre
            // 
            this.lblSucu_nombre.AutoSize = true;
            this.lblSucu_nombre.Location = new System.Drawing.Point(12, 15);
            this.lblSucu_nombre.Name = "lblSucu_nombre";
            this.lblSucu_nombre.Size = new System.Drawing.Size(53, 13);
            this.lblSucu_nombre.TabIndex = 3;
            this.lblSucu_nombre.Text = "Concepto";
            // 
            // lblSucu_codigo_postal
            // 
            this.lblSucu_codigo_postal.AutoSize = true;
            this.lblSucu_codigo_postal.Location = new System.Drawing.Point(12, 67);
            this.lblSucu_codigo_postal.Name = "lblSucu_codigo_postal";
            this.lblSucu_codigo_postal.Size = new System.Drawing.Size(49, 13);
            this.lblSucu_codigo_postal.TabIndex = 2;
            this.lblSucu_codigo_postal.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(122, 64);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(66, 102);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(147, 102);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = " Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ModificarItemFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 137);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.lblSucu_codigo_postal);
            this.Controls.Add(this.lblSucu_direccion);
            this.Controls.Add(this.lblSucu_nombre);
            this.Name = "ModificarItemFactura";
            this.Text = "Modificar Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblSucu_direccion;
        private System.Windows.Forms.Label lblSucu_nombre;
        private System.Windows.Forms.Label lblSucu_codigo_postal;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
    }
}