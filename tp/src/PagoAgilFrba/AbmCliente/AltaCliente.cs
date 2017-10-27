using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void validar()
        {
            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtApellido.Text) || Validacion.estaVacio(txtDni.Text) || Validacion.estaVacio(txtMail.Text) || Validacion.estaVacio(txtTelefono.Text) || Validacion.estaVacio(txtDireccion.Text) || Validacion.estaVacio(txtCodigo.Text))
            {
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtCodigo.Text))
                throw new Exception("El código postal debe contener únicamente números");

            //  if (!txtSucu_codigo_postal.Text.Count().Equals(4))
            //    throw new Exception("El código postal debe estar compuesto por 4 números");

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }
    }
}
