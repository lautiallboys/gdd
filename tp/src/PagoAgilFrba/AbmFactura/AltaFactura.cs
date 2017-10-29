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
        Form parent;
        public AltaFactura(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            cargar_proximo_numero();
            fill_clientes();
            fill_rubro_combo();
        }

        private void fill_rubro_combo()
        {
            foreach (Rubro rubro in obtenerRubros())
                this.cmbFiltroRubro.Items.Add(rubro);
        }

         private List<Rubro> obtenerRubros()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<Rubro> rubros = new List<Rubro>();

            // Pido todos los rubros
            SqlCommand all_functionalities_command = new SqlCommand("SELECT * FROM POSTRESQL.Rubro", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                rubros.Add(new Rubro(Int32.Parse(reader["rubr_id"].ToString()), reader["rubr_detalle"].ToString()));
            connection.Close();
            return rubros;
        }

        private void cargar_proximo_numero()
        {
            this.txtNumero.Text = (numeroMayorFactura() + 1).ToString();
        }

        private void fill_empresas(String nombreFiltro, String cuitFiltro, Int32 codigoRubroFiltro)
        {
            this.cmbEmpresa.Items.Clear();
            foreach (Empresa empresa in obtenerEmpresas(nombreFiltro, cuitFiltro, codigoRubroFiltro))
                this.cmbEmpresa.Items.Add(empresa);
        }

        private void fill_clientes()
        {
            foreach (Cliente cliente in obtenerClientes())
                this.cmbCliente.Items.Add(cliente);
        }
        
        private Int32 numeroMayorFactura()
        {
            var connection = DBConnection.getInstance().getConnection();
            // Pido el mayor número de factura
            SqlCommand highest_number_command = new SqlCommand("SELECT MAX(fact_numero) FROM POSTRESQL.Factura", connection);
            connection.Open();
            return Convert.ToInt32(highest_number_command.ExecuteScalar().ToString()) + 1;
        }

        private List<Empresa> obtenerEmpresas(String nombreFiltro, String cuitFiltro, Int32 codigoRubroFiltro)
        {
            List<Empresa> empresas = new List<Empresa>();
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarEmpresas", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(new SqlParameter("@empr_nombre", nombreFiltro));
            command.Parameters.Add(new SqlParameter("@empr_cuit", cuitFiltro));
            command.Parameters.Add(new SqlParameter("@empr_rubro", codigoRubroFiltro));
            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

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
            if (Validacion.estaVacio(txtNumero.Text) || cmbCliente.SelectedItem == null || cmbEmpresa.SelectedItem == null || grdItems.RowCount == 0 )
            {
                throw new Exception("Se deben ingresar todos los datos correctamente");
            }
            if (fechaAlta.Value > fechaVencimiento.Value)
            {
                throw new Exception("La fecha de vencimiento debe ser posterior a la fecha de alta");
            }
            if (esUnico(Int32.Parse(txtNumero.Text)))
            {
                throw new Exception("Ya existe una factura con el número ingresado");
            }
        }

        private bool esUnico(Int32 unNumero)
        {
            Int32 rowsAffected;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.facturaPorNumero", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@numero", unNumero));
            connection.Open();
            rowsAffected = query.ExecuteNonQuery();
            connection.Close();
            return (rowsAffected == 0);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                /* this.altaFactura();*/
                this.Close();
                parent.Show();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void filtrosEmpresaCambiaron(object sender, EventArgs e)
        {
            Int32 codigoRubro;
            if(cmbFiltroRubro.SelectedItem != null)
            {
                codigoRubro =((Rubro)cmbFiltroRubro.SelectedItem).code;
            }
            else{codigoRubro = 0;}
            fill_empresas(txtFiltroNombre.Text, txtFiltroCuit.Text, codigoRubro);
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
