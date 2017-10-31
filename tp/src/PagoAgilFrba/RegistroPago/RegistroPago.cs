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
        Int32 numeroFactura;
        DateTime fechaDeCobro;
        Int32 empresa;
        Int32 cliente;
        DateTime fechaDeVencimiento;
        Int32 importe;
        Int32 sucursal;
        AbmFactura.Empresa empresaSeleccionada;
        AbmFactura.Cliente clienteSeleccionado;
        MedioPago medioPagoSeleccionado;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private Decimal importeTotal = 0;
        private List<Decimal> facturas = new List<Decimal>();



        Form parent;
        public RegistroPago(Form parent)
        {
            this.parent = parent;
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

        
  //      SQLCOMMAND command = new SqlCommand();
  //      command.CommandText = "SELECT * from dbo.    
  //                where SUCURSAL_ID = @SUCURSAL";


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
               // if (rubro.code == rubroSeleccionado.code)
                this.comboMedioPago.SelectedItem = medioPagoSeleccionado;
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
                // if (rubro.code == rubroSeleccionado.code)
                this.comboEmpresa.SelectedItem = empresaSeleccionada;
            }
        }

        private void fill_clientes_combo()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<AbmFactura.Cliente> current_functionalities = new List<AbmFactura.Cliente>();
            List<AbmFactura.Cliente> all_functionalities = new List<AbmFactura.Cliente>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT medio_pago_id, medio_pago_descripcion FROM POSTRESQL.MedioPago", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                all_functionalities.Add(new AbmFactura.Cliente(Int32.Parse(reader["clie_id"].ToString()), reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString(), Int32.Parse(reader["clie_dni"].ToString())));
            connection.Close();
            foreach (AbmFactura.Cliente cliente in all_functionalities)
            {
                this.comboCliente.Items.Add(cliente);
                // if (rubro.code == rubroSeleccionado.code)
                this.comboCliente.SelectedItem = clienteSeleccionado;
            }
        }

        private void validar()
        {

    //       If fechaVencimiento > fechaActual -> Rompe
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
            //query.Parameters.Add(new SqlParameter("@medio_pago", this.comboMedioPago.SelectedItem.getCode() ));
            // query.Parameters.Add(new SqlParameter("@sucursal", this.txtSucursal.Text));
            query.Parameters.Add(new SqlParameter("@usuario", this.txtUsuario.Text));
            // query.Parameters.Add(new SqlParameter("@cliente", this.comboCliente.SelectedItem.getId());
            query.Parameters.Add(new SqlParameter("@fecha", DateTime.Today));
            query.Parameters.Add(new SqlParameter("@total", importeTotal));

            //PONER FACTURA COMO PAGA

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
