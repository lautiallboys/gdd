namespace PagoAgilFrba.AbmFactura
{
    partial class AltaFactura
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.fechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.grdItems = new System.Windows.Forms.DataGridView();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(232, 230);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(200, 20);
            this.txtTotal.TabIndex = 1;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(232, 64);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(200, 20);
            this.txtNumero.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(359, 274);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha alta";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(232, 38);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(200, 21);
            this.cmbEmpresa.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Enabled = false;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(232, 12);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 21);
            this.cmbCliente.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fecha vencimiento";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(278, 274);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 16;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Location = new System.Drawing.Point(232, 114);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaVencimiento.TabIndex = 17;
            // 
            // fechaAlta
            // 
            this.fechaAlta.Location = new System.Drawing.Point(232, 87);
            this.fechaAlta.Name = "fechaAlta";
            this.fechaAlta.Size = new System.Drawing.Size(200, 20);
            this.fechaAlta.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Items";
            // 
            // grdItems
            // 
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Concepto,
            this.Monto,
            this.Cantidad});
            this.grdItems.Location = new System.Drawing.Point(88, 140);
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(344, 84);
            this.grdItems.TabIndex = 24;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // AltaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 309);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fechaAlta);
            this.Controls.Add(this.fechaVencimiento);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaFactura";
            this.Text = "Alta Factura";
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DateTimePicker fechaVencimiento;
        private System.Windows.Forms.DateTimePicker fechaAlta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grdItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}