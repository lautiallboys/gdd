using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtApellido.Text) || Validacion.estaVacio(txtDni.Text) || Validacion.estaVacio(txtMail.Text) || Validacion.estaVacio(txtTelefono.Text) || Validacion.estaVacio(txtCalle.Text) || Validacion.estaVacio(txtCodigo.Text) || Validacion.estaVacio(txtLocalidad.Text))
            {
              
                throw new Exception("Debe completar todos los datos");

            }
            if (!Validacion.contieneSoloNumeros(txtCodigo.Text))
            {
                
                throw new Exception("El código postal debe contener únicamente números");
            }
            if (!Validacion.contieneSoloNumeros(txtTelefono.Text))
            {
              
                throw new Exception("El telefono debe contener únicamente números");
            }
            if (!Validacion.contieneSoloNumeros(txtDni.Text))
            {
               
                throw new Exception("El dni debe contener únicamente números");
            }
            if (!Validacion.tieneFormatoMail(txtMail.Text))
            {

                throw new Exception("Ingrese el mail correctamente");
            }
            


        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.altaCliente();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void altaCliente() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaCliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(this.txtDni.Text)));
            query.Parameters.Add(new SqlParameter("@apellido", this.txtApellido.Text));
            query.Parameters.Add(new SqlParameter("@nombre", this.txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@mail", this.txtMail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(this.txtTelefono.Text)));
            query.Parameters.Add(new SqlParameter("@direccion", this.obtenerDireccion()));
            query.Parameters.Add(new SqlParameter("@codigo", this.txtCodigo.Text));
            query.Parameters.Add(new SqlParameter("@fecha", this.dtmFecha.Value));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private String obtenerDireccion() {

            if (!(txtPisoDepto.Text == ""))
            {
                return this.txtCalle.Text + ", " + txtPisoDepto.Text + ", " + txtLocalidad.Text;
            }
            else
                return this.txtCalle.Text + ", " + txtLocalidad.Text;
        
        }
    }
}
