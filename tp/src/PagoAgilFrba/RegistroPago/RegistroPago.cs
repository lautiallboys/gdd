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
        private IList<SqlParameter> parametros = new List<SqlParameter>();


        public RegistroPago()
        {
            InitializeComponent();
        }

        private void medioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            medioPago.Text = medioPago.SelectedText;
        }

        private void comboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEmpresa.Text = comboEmpresa.SelectedText;
        }



        private void fill_medioPago()
        {
                this.medioPago.Items.Add(1);
                this.medioPago.Items.Add(2);
                this.medioPago.Items.Add(3);
        }

        
  //      SQLCOMMAND command = new SqlCommand();
  //      command.CommandText = "SELECT * from dbo.    
  //                where SUCURSAL_ID = @SUCURSAL";


        private void registrarPago()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.registrarPago", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@medio_pago", Convert.ToInt32(this.txtDni.Text)));
            query.Parameters.Add(new SqlParameter("@sucursal", this.txtApellido.Text));
            query.Parameters.Add(new SqlParameter("@usuario", this.txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@cliente", this.txtMail.Text));
            query.Parameters.Add(new SqlParameter("@fecha", Convert.ToInt32(this.txtTelefono.Text)));
            query.Parameters.Add(new SqlParameter("@total", this.txtDireccion.Text));

            //PONER FACTURA COMO PAGA
            //LLENAR TABLA INTERMEDIA

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }


        private void CargarMedioPago()
        {
            DataSet rubros = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros.Clear();
            parametros = new List<SqlParameter>();
            command = builderDeComandos.Crear("SELECT DISTINCT medi_descripcion FROM AMBDA.MedioDePago ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(rubros);
            combo_MedioPago.DataSource = rubros.Tables[0].DefaultView;
            combo_MedioPago.ValueMember = "medi_descripcion";
            combo_MedioPago.SelectedIndex = -1;
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
            if (!Validacion.contieneSoloNumeros(txtTelefono.Text))
                throw new Exception("El telefono debe contener únicamente números");
            if (!Validacion.contieneSoloNumeros(txtDni.Text))
                throw new Exception("El dni debe contener únicamente números");

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

    }
}
