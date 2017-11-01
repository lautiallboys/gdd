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
    public partial class BMFactura : Form
    {
        Form parent;
        public BMFactura(Form parent)
        {
            this.parent = parent;
            InitializeComponent(); 
            fill_clientes();
            fill_empresas();
            actualizarFacturas();
        }

        private void fill_empresas()
        {
            this.cmbEmpresa.Items.Clear();
            foreach (Empresa empresa in obtenerEmpresas())
                this.cmbEmpresa.Items.Add(empresa);
        }

        private void fill_clientes()
        {
            cmbCliente.Items.Clear();
            foreach (Cliente cliente in obtenerClientes())
                this.cmbCliente.Items.Add(cliente);
        }

        private List<Empresa> obtenerEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from POSTRESQL.Empresa", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                empresas.Add(new Empresa(Int32.Parse(reader["empr_id"].ToString()), reader["empr_nombre"].ToString()));
            connection.Close();
            return empresas;
        }

        private List<Cliente> obtenerClientes()
        {
            int dni;
            if (Validacion.estaVacio(txtFiltroDni.Text))
                dni = 0;
            else
                dni = Int32.Parse(txtFiltroDni.Text);

            var connection = DBConnection.getInstance().getConnection();
            List<Cliente> clientes = new List<Cliente>();

            // Filtro Clientes
            SqlCommand query = new SqlCommand("POSTRESQL.filtrarClientes", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@nombre", txtFiltroNombre.Text));
            query.Parameters.Add(new SqlParameter("@apellido", txtFiltroApellido.Text));
            query.Parameters.Add(new SqlParameter("@dni", dni));
            connection.Open();

            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
                clientes.Add(new Cliente(Int32.Parse(reader["clie_id"].ToString()), reader["clie_nombre"].ToString(), reader["clie_apellido"].ToString(), Int32.Parse(reader["clie_dni"].ToString())));
            connection.Close();
            return clientes;
        }

        private void filtrosClienteCambiaron(object sender, EventArgs e)
        {
            fill_clientes();
        }

        private SqlDataReader filtrar()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarFacturasModificables", connection);
            command.CommandType = CommandType.StoredProcedure;

            int codigoEmpresa;
            int codigoCliente;

            if(cmbEmpresa.SelectedItem != null)
                codigoEmpresa = ((Empresa)cmbEmpresa.SelectedItem).code;
            else
                codigoEmpresa = 0;
            
            if (cmbCliente.SelectedItem != null)
                codigoCliente = ((Cliente)cmbCliente.SelectedItem).code;
            else
                codigoCliente = 0;

            command.Parameters.Add(new SqlParameter("@fact_cliente", codigoCliente));
            command.Parameters.Add(new SqlParameter("@fact_empresa", codigoEmpresa));
            command.Parameters.Add(new SqlParameter("@fact_numero", txtNumero.Text));
           
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;

        }
      
        private void bajaFactura() {

            var connection = DBConnection.getInstance().getConnection();
            connection.Open();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SqlCommand query = new SqlCommand("POSTRESQL.bajaFactura", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@numero", Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value)));
                query.ExecuteNonQuery();
            }

            connection.Close();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.bajaFactura();
                    this.actualizarFacturas();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    try
                    {
                        int idFactura = Int16.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        Form modif = new AbmFactura.ModificarFactura(this, idFactura);
                        modif.Show();
                        this.Enabled = false;
                    }
                    catch (Exception excepcion)
                    {
                        MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else
                    throw new Exception("Se debe seleccionar exactamente una fila");
            }

            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cambioFiltro(object sender, EventArgs e)
        {
            actualizarFacturas();
        }

        private void actualizarFacturas()
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }

        private void BMFactura_Load(object sender, EventArgs e)
        {

        }

    }
}
