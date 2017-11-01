namespace PagoAgilFrba.Rendicion
{
    partial class Rendicion
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporteComision = new System.Windows.Forms.TextBox();
            this.txtCantidadFacturas = new System.Windows.Forms.TextBox();
            this.txtTotalRendicion = new System.Windows.Forms.TextBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.fechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.btnRendir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.grdFacturas = new System.Windows.Forms.DataGridView();
            this.grdItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha cobro";
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
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cantidad de Facturas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Conjunto de Facturas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(698, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Items";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Comisión (%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Comisión ($)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total";
            // 
            // txtImporteComision
            // 
            this.txtImporteComision.Enabled = false;
            this.txtImporteComision.Location = new System.Drawing.Point(143, 117);
            this.txtImporteComision.Name = "txtImporteComision";
            this.txtImporteComision.Size = new System.Drawing.Size(200, 20);
            this.txtImporteComision.TabIndex = 1;
            // 
            // txtCantidadFacturas
            // 
            this.txtCantidadFacturas.Enabled = false;
            this.txtCantidadFacturas.Location = new System.Drawing.Point(143, 65);
            this.txtCantidadFacturas.Name = "txtCantidadFacturas";
            this.txtCantidadFacturas.Size = new System.Drawing.Size(200, 20);
            this.txtCantidadFacturas.TabIndex = 1;
            // 
            // txtTotalRendicion
            // 
            this.txtTotalRendicion.Enabled = false;
            this.txtTotalRendicion.Location = new System.Drawing.Point(143, 143);
            this.txtTotalRendicion.Name = "txtTotalRendicion";
            this.txtTotalRendicion.Size = new System.Drawing.Size(200, 20);
            this.txtTotalRendicion.TabIndex = 1;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(143, 91);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(200, 20);
            this.txtPorcentaje.TabIndex = 2;
            this.txtPorcentaje.TextChanged += new System.EventHandler(this.cambioFiltro);
            // 
            // fechaRendicion
            // 
            this.fechaRendicion.Location = new System.Drawing.Point(143, 12);
            this.fechaRendicion.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.fechaRendicion.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.fechaRendicion.Name = "fechaRendicion";
            this.fechaRendicion.Size = new System.Drawing.Size(200, 20);
            this.fechaRendicion.TabIndex = 0;
            this.fechaRendicion.Value = new System.DateTime(2017, 10, 26, 11, 38, 33, 0);
            this.fechaRendicion.ValueChanged += new System.EventHandler(this.cambioFiltro);
            // 
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(858, 286);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(75, 23);
            this.btnRendir.TabIndex = 5;
            this.btnRendir.Text = "Rendir";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(939, 286);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(143, 38);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(200, 21);
            this.cmbEmpresa.TabIndex = 1;
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cambioFiltro);
            // 
            // grdFacturas
            // 
            this.grdFacturas.AllowUserToAddRows = false;
            this.grdFacturas.AllowUserToDeleteRows = false;
            this.grdFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFacturas.Location = new System.Drawing.Point(352, 38);
            this.grdFacturas.Name = "grdFacturas";
            this.grdFacturas.ReadOnly = true;
            this.grdFacturas.Size = new System.Drawing.Size(343, 242);
            this.grdFacturas.TabIndex = 3;
            this.grdFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cargarItems);
            this.grdFacturas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cargarItems);
            this.grdFacturas.SelectionChanged += new System.EventHandler(this.cargarItems);
            // 
            // grdItems
            // 
            this.grdItems.AllowUserToAddRows = false;
            this.grdItems.AllowUserToDeleteRows = false;
            this.grdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItems.Location = new System.Drawing.Point(701, 38);
            this.grdItems.Name = "grdItems";
            this.grdItems.ReadOnly = true;
            this.grdItems.Size = new System.Drawing.Size(313, 242);
            this.grdItems.TabIndex = 4;
            // 
            // Rendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 321);
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.grdFacturas);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.fechaRendicion);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.txtTotalRendicion);
            this.Controls.Add(this.txtCantidadFacturas);
            this.Controls.Add(this.txtImporteComision);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Rendicion";
            this.Text = "Rendicion";
            this.Load += new System.EventHandler(this.Rendicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImporteComision;
        private System.Windows.Forms.TextBox txtCantidadFacturas;
        private System.Windows.Forms.TextBox txtTotalRendicion;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.DateTimePicker fechaRendicion;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.DataGridView grdFacturas;
        private System.Windows.Forms.DataGridView grdItems;
    }
}