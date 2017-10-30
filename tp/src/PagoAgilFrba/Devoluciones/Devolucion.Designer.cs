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
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(32, 75);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(256, 20);
            this.txtMotivo.TabIndex = 5;
            // 
            // lblMotivoDevolucion
            // 
            this.lblMotivoDevolucion.AutoSize = true;
            this.lblMotivoDevolucion.Location = new System.Drawing.Point(102, 33);
            this.lblMotivoDevolucion.Name = "lblMotivoDevolucion";
            this.lblMotivoDevolucion.Size = new System.Drawing.Size(109, 13);
            this.lblMotivoDevolucion.TabIndex = 3;
            this.lblMotivoDevolucion.Text = "Motivo de devolucion";
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Location = new System.Drawing.Point(105, 158);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(75, 23);
            this.btnDevolucion.TabIndex = 6;
            this.btnDevolucion.Text = "Devolver";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // AltaSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 232);
            this.Controls.Add(this.btnDevolucion);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivoDevolucion);
            this.Name = "AltaSucursal";
            this.Text = "AltaSucursal";
            this.Load += new System.EventHandler(this.AltaSucursal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivoDevolucion;
        private System.Windows.Forms.Button btnDevolucion;
    }
}