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

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaFactura: Form
    {
        public AltaFactura()
        {
            InitializeComponent();
            cargar_proximo_numero();
            fill_empresas();
            fill_clientes();
        }

        private void cargar_proximo_numero()
        {
            this.txtNumero.Text = (numeroMayorFactura() + 1).ToString();
        }

        private void fill_empresas()
        {
            foreach (Empresa empresa in obtenerEmpresas())
                this.cmbEmpresa.Items.Add(empresa);
        }

        private void fill_clientes()
        {
            foreach (Cliente cliente in obtenerClientes())
                this.cmbCliente.Items.Add(cliente);
        }
        
        private Int64 numeroMayorFactura()
        {
            var connection = DBConnection.getInstance().getConnection();
            // Pido todas las empresas
            SqlCommand highest_number_command = new SqlCommand("SELECT MAX(fact_numero) FROM POSTRESQL.Factura", connection);
            connection.Open();
            return (Int64)highest_number_command.ExecuteScalar();
        }

        private List<Empresa> obtenerEmpresas()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<Empresa> empresas= new List<Empresa>();

            // Pido todas las empresas
            SqlCommand all_empresas_command = new SqlCommand("SELECT * FROM POSTRESQL.Empresa", connection);
            connection.Open();
            SqlDataReader reader = all_empresas_command.ExecuteReader();
            while (reader.Read())
                empresas.Add(new Empresa(Int32.Parse(reader["empr_id"].ToString()), reader["empr_nombre"].ToString()));
            connection.Close();
            return empresas;
        }

        private List<Cliente> obtenerClientes()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<Cliente> clientes= new List<Cliente>();

            // Pido todos los clientes
            SqlCommand all_clientes_command = new SqlCommand("SELECT * FROM POSTRESQL.Cliente", connection);
            connection.Open();
            SqlDataReader reader = all_clientes_command.ExecuteReader();
            while (reader.Read())
                clientes.Add(new Cliente(Int32.Parse(reader["clie_id"].ToString()), reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString()));
            connection.Close();
            return clientes;
        }

        private void validar()
        {
            if (Validacion.estaVacio(txtNumero.Text) || cmbCliente.SelectedItem == null || cmbEmpresa.SelectedItem == null || fechaAlta.Value > fechaVencimiento.Value || grdItems.RowCount == 0)
            {
                throw new Exception("Se deben ingresar todos los datos correctamente");
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
               /* this.altaFactura();*/
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
        /*private void altaFactura() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaEmpresa", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@empr_nombre", this.txtCliente.Text));
            query.Parameters.Add(new SqlParameter("@empr_cuit", this.txtTotal.Text));
            query.Parameters.Add(new SqlParameter("@empr_direccion", this.txtNumero.Text));
            Rubro rubro = (Rubro) (this.cmbEmpresa.SelectedItem);
            query.Parameters.Add(new SqlParameter("@empr_rubro", Convert.ToInt32(rubro.code))); 
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }*/
    }
}
