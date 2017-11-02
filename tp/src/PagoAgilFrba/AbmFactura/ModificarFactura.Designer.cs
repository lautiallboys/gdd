namespace PagoAgilFrba.AbmFactura
{
    partial class ModificarFactura
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
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.txtFiltroDni = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.btnBorrarItem = new System.Windows.Forms.Button();
            this.btnModificarItem = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(232, 202);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(200, 20);
            this.txtTotal.TabIndex = 8;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(232, 123);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(200, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(916, 227);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha alta";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(232, 96);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(200, 21);
            this.cmbEmpresa.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(232, 12);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 21);
            this.cmbCliente.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fecha vencimiento";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(835, 227);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Location = new System.Drawing.Point(232, 176);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(200, 20);
            this.fechaVencimiento.TabIndex = 7;
            // 
            // fechaAlta
            // 
            this.fechaAlta.Location = new System.Drawing.Point(232, 149);
            this.fechaAlta.Name = "fechaAlta";
            this.fechaAlta.Size = new System.Drawing.Size(200, 20);
            this.fechaAlta.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Items";
            // 
            // grdItems
            // 
            this.grdItems.AllowUserToAddRows = false;
            this.grdItems.AllowUserToDeleteRows = false;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Location = new System.Drawing.Point(552, 12);
            this.grdItems.Name = "grdItems";
            this.grdItems.ReadOnly = true;
            this.grdItems.Size = new System.Drawing.Size(353, 206);
            this.grdItems.TabIndex = 9;
            this.grdItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.cambioItems);
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(126, 13);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 0;
            this.txtFiltroNombre.TextChanged += new System.EventHandler(this.filtrosClienteCambiaron);
            // 
            // txtFiltroDni
            // 
            this.txtFiltroDni.Location = new System.Drawing.Point(126, 65);
            this.txtFiltroDni.Name = "txtFiltroDni";
            this.txtFiltroDni.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDni.TabIndex = 2;
            this.txtFiltroDni.TextChanged += new System.EventHandler(this.filtrosClienteCambiaron);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(73, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Nombre:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(92, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Dni:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(73, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Apellido:";
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(126, 39);
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroApellido.TabIndex = 1;
            this.txtFiltroApellido.TextChanged += new System.EventHandler(this.filtrosClienteCambiaron);
            // 
            // btnBorrarItem
            // 
            this.btnBorrarItem.Location = new System.Drawing.Point(916, 70);
            this.btnBorrarItem.Name = "btnBorrarItem";
            this.btnBorrarItem.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarItem.TabIndex = 12;
            this.btnBorrarItem.Text = "Borrar";
            this.btnBorrarItem.UseVisualStyleBackColor = true;
            this.btnBorrarItem.Click += new System.EventHandler(this.btnBorrarItem_Click);
            // 
            // btnModificarItem
            // 
            this.btnModificarItem.Location = new System.Drawing.Point(916, 41);
            this.btnModificarItem.Name = "btnModificarItem";
            this.btnModificarItem.Size = new System.Drawing.Size(75, 23);
            this.btnModificarItem.TabIndex = 11;
            this.btnModificarItem.Text = "Modificar";
            this.btnModificarItem.UseVisualStyleBackColor = true;
            this.btnModificarItem.Click += new System.EventHandler(this.btnModificarItem_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Location = new System.Drawing.Point(916, 12);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarItem.TabIndex = 10;
            this.btnAgregarItem.Text = "Agregar";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // ModificarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 262);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.btnModificarItem);
            this.Controls.Add(this.btnBorrarItem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFiltroApellido);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFiltroDni);
            this.Controls.Add(this.txtFiltroNombre);
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
            this.Name = "ModificarFactura";
            this.Text = " Modificar factura";
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
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroDni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.Button btnBorrarItem;
        private System.Windows.Forms.Button btnModificarItem;
        private System.Windows.Forms.Button btnAgregarItem;
    }
}