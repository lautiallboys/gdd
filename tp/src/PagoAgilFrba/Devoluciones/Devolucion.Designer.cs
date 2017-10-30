namespace PagoAgilFrba.Devoluciones
{
    partial class Devolucion
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
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivoDevolucion = new System.Windows.Forms.Label();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoFactura = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(32, 142);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(256, 20);
            this.txtMotivo.TabIndex = 5;
            // 
            // lblMotivoDevolucion
            // 
            this.lblMotivoDevolucion.AutoSize = true;
            this.lblMotivoDevolucion.Location = new System.Drawing.Point(102, 107);
            this.lblMotivoDevolucion.Name = "lblMotivoDevolucion";
            this.lblMotivoDevolucion.Size = new System.Drawing.Size(109, 13);
            this.lblMotivoDevolucion.TabIndex = 3;
            this.lblMotivoDevolucion.Text = "Motivo de devolucion";
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Location = new System.Drawing.Point(32, 180);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(75, 23);
            this.btnDevolucion.TabIndex = 6;
            this.btnDevolucion.Text = "Devolver";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numero de Factura";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigoFactura
            // 
            this.txtCodigoFactura.Location = new System.Drawing.Point(32, 63);
            this.txtCodigoFactura.Name = "txtCodigoFactura";
            this.txtCodigoFactura.Size = new System.Drawing.Size(256, 20);
            this.txtCodigoFactura.TabIndex = 8;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(213, 180);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "Atras";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 232);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtCodigoFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDevolucion);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivoDevolucion);
            this.Name = "Devolucion";
            this.Text = "AltaSucursal";
            this.Load += new System.EventHandler(this.AltaSucursal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivoDevolucion;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoFactura;
        private System.Windows.Forms.Button btnVolver;
    }
}