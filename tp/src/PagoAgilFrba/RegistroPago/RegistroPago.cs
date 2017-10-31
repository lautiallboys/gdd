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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : Form
    {
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private Decimal importeTotal = 0;
        private List<Decimal> facturas = new List<Decimal>();
        private int sucursalCode;
        private string username;

        Form parent;
        public RegistroPago(Form parent, string username, int sucursalCode)
        {
            this.parent = parent;
            this.sucursalCode = sucursalCode;
            this.username = username;
            InitializeComponent();
            fill_empresa_combo();
            fill_medioPago_combo();
            fill_clientes_combo();
        }

        private void medioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMedioPago.Text = comboMedioPago.SelectedText;
        }

        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEmpresa.Text = comboEmpresa.SelectedText;
        }

        private void registrarPago()
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }


        private void fill_medioPago_combo()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<MedioPago> current_functionalities = new List<MedioPago>();
            List<MedioPago> all_functionalities = new List<MedioPago>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT medio_pago_id, medio_pago_descripcion FROM POSTRESQL.MedioPago", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                all_functionalities.Add(new MedioPago(Int32.Parse(reader["medio_pago_id"].ToString()), reader["medio_pago_descripcion"].ToString()));
            connection.Close();
            foreach (MedioPago medioPago in all_functionalities)
            {
                this.comboMedioPago.Items.Add(medioPago);
            }
        }

        private void fill_empresa_combo()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<AbmFactura.Empresa> current_functionalities = new List<AbmFactura.Empresa>();
            List<AbmFactura.Empresa> all_functionalities = new List<AbmFactura.Empresa>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT empr_id, empr_nombre FROM POSTRESQL.Empresa where empr_habilitado = 1", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                all_functionalities.Add(new AbmFactura.Empresa(Int32.Parse(reader["empr_id"].ToString()), reader["empr_nombre"].ToString()));
            connection.Close();
            foreach (AbmFactura.Empresa empresa in all_functionalities)
            {
                this.comboEmpresa.Items.Add(empresa);
            }
        }

        private void fill_clientes_combo()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<AbmFactura.Cliente> current_functionalities = new List<AbmFactura.Cliente>();
            List<AbmFactura.Cliente> all_functionalities = new List<AbmFactura.Cliente>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT clie_id, clie_nombre, clie_apellido, clie_dni FROM POSTRESQL.Cliente", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                all_functionalities.Add(new AbmFactura.Cliente(Int32.Parse(reader["clie_id"].ToString()), reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString(), Int32.Parse(reader["clie_dni"].ToString())));
            connection.Close();
            foreach (AbmFactura.Cliente cliente in all_functionalities)
            {
                this.comboCliente.Items.Add(cliente);

            }
        }

        private void validar()
        {

    //       If fechaVencimiento > fechaActual -> Rompe
    //      if factura <> empresa -> Rompe
   //         if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtApellido.Text) || Validacion.estaVacio(txtDni.Text) || Validacion.estaVacio(txtCliente.Text) || Validacion.estaVacio(txtTelefono.Text) || Validacion.estaVacio(txtImporte.Text) || Validacion.estaVacio(txtSucursal.Text))
   //         {
    //            throw new Exception("Debe completar todos los datos");
            //         }
            //         if (!Validacion.contieneSoloNumeros(txtSucursal.Text))
            //              throw new Exception("El código postal debe contener únicamente números");
            //       if (!Validacion.contieneSoloNumeros(txtTelefono.Text))
            //           throw new Exception("El telefono debe contener únicamente números");
            //      if (!Validacion.contieneSoloNumeros(txtDni.Text))
            //      throw new Exception("El dni debe contener únicamente números");

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.cargarFactura();
                this.pagar();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCargarOtraFactura_Click(object sender, EventArgs e)
        {
                try
                {
                    this.validar();
                    this.cargarFactura();
                    this.Close();
                    //refresh()
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }           
        }

        private void pagar()
        {

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.registrarPago", connection);
            query.CommandType = CommandType.StoredProcedure;
            MedioPago medioPago = (MedioPago)(this.comboMedioPago.SelectedItem);
            query.Parameters.Add(new SqlParameter("@medio_pago", Convert.ToInt32(medioPago.code)));   
            query.Parameters.Add(new SqlParameter("@sucursal", sucursalCode));
            query.Parameters.Add(new SqlParameter("@usuario", username));
            AbmFactura.Cliente cliente = (AbmFactura.Cliente)(this.comboCliente.SelectedItem);
            query.Parameters.Add(new SqlParameter("@cliente", Convert.ToInt32(cliente.code)));
            query.Parameters.Add(new SqlParameter("@fecha", DateTime.Today));
            query.Parameters.Add(new SqlParameter("@total", importeTotal));    

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();

            //PONER FACTURA COMO PAGA
            foreach (Decimal factura in facturas)
            {
                PagarFactura(factura);
            }

        }

        public void PagarFactura(Decimal idFactura)
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.pagar_factura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@usuario", username));
            query.Parameters.Add(new SqlParameter("@factura", idFactura));
            query.Parameters.Add(new SqlParameter("@fecha", DateTime.Today));
            AbmFactura.Cliente cliente = (AbmFactura.Cliente)(this.comboCliente.SelectedItem);
            query.Parameters.Add(new SqlParameter("@cliente", Convert.ToInt32(cliente.code)));
            query.Parameters.Add(new SqlParameter("@importe", importeTotal));
            query.Parameters.Add(new SqlParameter("@sucursal", sucursalCode));
            MedioPago medioPago = (MedioPago)(this.comboMedioPago.SelectedItem);
            query.Parameters.Add(new SqlParameter("@medio", Convert.ToInt32(medioPago.code)));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void cargarFactura()
        {
            facturas.Add(Convert.ToDecimal(txtNumeroFactura.Text));
            importeTotal += Convert.ToDecimal(txtImporte.Text);
        }

    }
}
