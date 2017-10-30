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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AltaSucursal : Form
    {
        public AltaSucursal()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.altaSucursal();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }


        private void altaSucursal() {
            String nombreSucursal = txtSucu_nombre.Text;
            String direccionSucursal = txtSucu_direccion.Text;
            String codigoPostal = txtSucu_codigo_postal.Text;

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@nombre", this.txtSucu_nombre.Text));
            query.Parameters.Add(new SqlParameter("@direccion", this.txtSucu_direccion.Text));
            query.Parameters.Add(new SqlParameter("@codigo_postal", this.txtSucu_codigo_postal.Text));
            query.Parameters.Add(new SqlParameter("@habilitado", 1));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            


        }

    
        private void validar() {
            if (Validacion.estaVacio(txtSucu_codigo_postal.Text) || Validacion.estaVacio(txtSucu_direccion.Text) || Validacion.estaVacio(txtSucu_nombre.Text))
            {
               
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtSucu_codigo_postal.Text))
            {
                
                throw new Exception("El código postal debe contener únicamente números");
            }


          //  if (!txtSucu_codigo_postal.Text.Count().Equals(4))
            //    throw new Exception("El código postal debe estar compuesto por 4 números");
        
        }

        private void AltaSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
