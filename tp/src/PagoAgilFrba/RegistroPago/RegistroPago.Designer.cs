namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPago
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
            this.dtmFechaVenc = new System.Windows.Forms.DateTimePicker();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCargarOtraFactura = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboMedioPago = new System.Windows.Forms.ComboBox();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.comboCliente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtmFechaVenc
            // 
            this.dtmFechaVenc.Location = new System.Drawing.Point(227, 81);
            this.dtmFechaVenc.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.dtmFechaVenc.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtmFechaVenc.Name = "dtmFechaVenc";
            this.dtmFechaVenc.Size = new System.Drawing.Size(200, 20);
            this.dtmFechaVenc.TabIndex = 18;
            this.dtmFechaVenc.Value = new System.DateTime(2017, 10, 26, 11, 38, 33, 0);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(227, 129);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(200, 20);
            this.txtImporte.TabIndex = 12;
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(227, 32);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(200, 20);
            this.txtNumeroFactura.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Importe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha de Vencimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cliente*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Empresa*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Numero de Factura";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(43, 346);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 23);
            this.btnPagar.TabIndex = 19;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnCargarOtraFactura
            // 
            this.btnCargarOtraFactura.Location = new System.Drawing.Point(167, 346);
            this.btnCargarOtraFactura.Name = "btnCargarOtraFactura";
            this.btnCargarOtraFactura.Size = new System.Drawing.Size(141, 23);
            this.btnCargarOtraFactura.TabIndex = 22;
            this.btnCargarOtraFactura.Text = "Registrar otra factura";
            this.btnCargarOtraFactura.UseVisualStyleBackColor = true;
            this.btnCargarOtraFactura.Click += new System.EventHandler(this.btnCargarOtraFactura_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Medio de pago*";
            // 
            // comboMedioPago
            // 
            this.comboMedioPago.FormattingEnabled = true;
            this.comboMedioPago.Location = new System.Drawing.Point(227, 252);
            this.comboMedioPago.Name = "comboMedioPago";
            this.comboMedioPago.Size = new System.Drawing.Size(200, 21);
            this.comboMedioPago.TabIndex = 24;
            this.comboMedioPago.SelectedIndexChanged += new System.EventHandler(this.medioPago_SelectedIndexChanged);
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(227, 215);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(200, 21);
            this.comboEmpresa.TabIndex = 25;
            this.comboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "*Seleccionar despues de que se hayan cargado todas las facturas";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(352, 346);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 27;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // comboCliente
            // 
            this.comboCliente.FormattingEnabled = true;
            this.comboCliente.Location = new System.Drawing.Point(227, 172);
            this.comboCliente.Name = "comboCliente";
            this.comboCliente.Size = new System.Drawing.Size(200, 21);
            this.comboCliente.TabIndex = 29;
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 391);
            this.Controls.Add(this.comboCliente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.comboMedioPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCargarOtraFactura);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dtmFechaVenc);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "RegistroPago";
            this.Text = "Registro Pago";
            this.Load += new System.EventHandler(this.RegistroPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtmFechaVenc;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnCargarOtraFactura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboMedioPago;
        private System.Windows.Forms.ComboBox comboEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox comboCliente;
    }
}