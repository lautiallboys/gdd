using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ModificarItemFactura : Form
    {
        ModificarFactura parent;
        int id;
        public ModificarItemFactura(ModificarFactura parent, int id, double monto, int cantidad, string concepto)
        {
            this.parent = parent;
            this.id = id;
            InitializeComponent();
            txtConcepto.Text = concepto;
            txtMonto.Text = monto.ToString();
            txtCantidad.Text = cantidad.ToString();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.parent.Enabled = true;
                this.parent.modificarItemFactura(id, txtConcepto.Text, Int32.Parse(txtCantidad.Text), Double.Parse(txtMonto.Text));
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void validar() {
            if (Validacion.estaVacio(txtCantidad.Text) || Validacion.estaVacio(txtMonto.Text) || Validacion.estaVacio(txtConcepto.Text))
            {
               
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtCantidad.Text) || !Validacion.contieneSoloNumeros(txtMonto.Text))
            {
                
                throw new Exception("La cantidad y el monto deben contener únicamente números");
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Enabled= true;
        }
    }
}
