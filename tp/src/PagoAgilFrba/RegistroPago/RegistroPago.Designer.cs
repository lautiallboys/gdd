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
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.medioPago = new System.Windows.Forms.ComboBox();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtmFechaVenc
            // 
            this.dtmFechaVenc.Location = new System.Drawing.Point(227, 162);
            this.dtmFechaVenc.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.dtmFechaVenc.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtmFechaVenc.Name = "dtmFechaVenc";
            this.dtmFechaVenc.Size = new System.Drawing.Size(200, 20);
            this.dtmFechaVenc.TabIndex = 18;
            this.dtmFechaVenc.Value = new System.DateTime(2017, 10, 26, 11, 38, 33, 0);
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(227, 246);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(200, 20);
            this.txtSucursal.TabIndex = 11;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(227, 204);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(200, 20);
            this.txtImporte.TabIndex = 12;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(227, 111);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(200, 20);
            this.txtCliente.TabIndex = 14;
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(227, 32);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(200, 20);
            this.txtNumeroFactura.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Sucursal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Importe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha de Vencimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Empresa";
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
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(63, 346);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 19;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(286, 346);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(141, 23);
            this.btnContinuar.TabIndex = 22;
            this.btnContinuar.Text = "Registrar otro pago";
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Medio de pago";
            // 
            // medioPago
            // 
            this.medioPago.FormattingEnabled = true;
            this.medioPago.Items.AddRange(new object[] {
            "Efectivo",
            "Debito",
            "Credito"});
            this.medioPago.Location = new System.Drawing.Point(227, 285);
            this.medioPago.Name = "medioPago";
            this.medioPago.Size = new System.Drawing.Size(200, 21);
            this.medioPago.TabIndex = 24;
            this.medioPago.SelectedIndexChanged += new System.EventHandler(this.medioPago_SelectedIndexChanged);
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Location = new System.Drawing.Point(227, 72);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(200, 21);
            this.comboEmpresa.TabIndex = 25;
            this.comboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 391);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.medioPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dtmFechaVenc);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "RegistroPago";
            this.Text = "RegistrarPago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtmFechaVenc;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox medioPago;
        private System.Windows.Forms.ComboBox comboEmpresa;
    }
}