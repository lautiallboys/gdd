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
    public partial class ModificarFactura: Form
    {
        Form parent;
        int numeroFactura;

        public ModificarFactura(Form parent, int numeroFactura)
        {
            this.parent = parent;
            this.numeroFactura = numeroFactura;
            InitializeComponent();
            fill_clientes();
            fill_empresas();
            cargarDatos();
            cargarItems();
            actualizarItems();
        }

        private void cargarDatos()
        {
            var connection = DBConnection.getInstance().getConnection();
            //Obtengo Factura
            SqlCommand query = new SqlCommand("POSTRESQL.facturaPorNumero", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@numero", numeroFactura));
            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            reader.Read();
            
            txtNumero.Text = reader["fact_numero"].ToString();
            foreach (Cliente cliente in cmbCliente.Items)
            {
                if (cliente.code == Int32.Parse(reader["fact_cliente"].ToString()))
                    cmbCliente.SelectedIndex = cmbCliente.Items.IndexOf(cliente);
            } 
            foreach (Empresa empresa in cmbEmpresa.Items)
            {
                if (empresa.code == Int32.Parse(reader["fact_empresa"].ToString()))
                    cmbEmpresa.SelectedIndex = cmbEmpresa.Items.IndexOf(empresa);
            }
            fechaAlta.Value = DateTime.Parse(reader["fact_fecha"].ToString());
            fechaVencimiento.Value = DateTime.Parse(reader["fact_fecha_vencimiento"].ToString());

            connection.Close();
        }

        private void cargarItems() 
        {
            var connection = DBConnection.getInstance().getConnection();
            //Obtengo Factura
            SqlCommand query = new SqlCommand("POSTRESQL.itemsPorFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@numeroFactura", numeroFactura));
            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            ConfiguradorDataGrid.llenarDataGridConConsulta(reader, grdItems);
            
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
        
        private Int32 numeroMayorFactura()
        {
            var connection = DBConnection.getInstance().getConnection();
            // Pido el mayor número de factura
            SqlCommand highest_number_command = new SqlCommand("SELECT MAX(fact_numero) FROM POSTRESQL.Factura", connection);
            connection.Open();
            return Convert.ToInt32(highest_number_command.ExecuteScalar().ToString());
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
            List<Cliente> clientes= new List<Cliente>();

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
            if (!estanBienGenerados(generarItems()))
            {
                throw new Exception("Se deben completar los 3 campos de cada item ingresado correctamente");
            }
            
        }

        private bool esUnico(Int32 unNumero)
        {
            bool existsNumber;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.facturaPorNumero", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@numero", unNumero));
            connection.Open();
            existsNumber = query.ExecuteReader().HasRows;
            connection.Close();
            return existsNumber;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.modificarFactura();
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
            this.parent.Enabled = true;
        }

        private void filtrosClienteCambiaron(object sender, EventArgs e)
        {
            fill_clientes();
        }

        private void cambioItems(object sender, DataGridViewCellEventArgs e)
        {
            actualizarItems();
        }

        private void actualizarItems()
        {
            List<ItemFactura> listaItems = generarItems();
            if (estanBienGenerados(listaItems))
            {
                txtTotal.Text = listaItems.Sum(item => item.cantidad * item.monto).ToString();
            }
            else
            {
                txtTotal.Clear();
            }
        }

        private bool estanBienGenerados(List<ItemFactura> listaItems)
        {
            return listaItems.Count != 0;
        }

        private List<ItemFactura> generarItems()
        {
            List<ItemFactura> listaItems = new List<ItemFactura>();
            try
            {
                
                foreach (DataGridViewRow row in grdItems.Rows)
                    if (!row.IsNewRow)
                    {
                        listaItems.Add(new ItemFactura(row.Cells[1].Value.ToString(), Double.Parse(row.Cells[3].Value.ToString()), Int32.Parse(row.Cells[2].Value.ToString()), Int16.Parse(txtNumero.Text)));
                    }
               
            }
            catch (NullReferenceException e)
            {
                listaItems.Clear();
            }
            return listaItems;
        }

        private void modificarFactura() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fact_numero", Int16.Parse(txtNumero.Text)));
            query.Parameters.Add(new SqlParameter("@fact_cliente", ((Cliente)cmbCliente.SelectedItem).code));
            query.Parameters.Add(new SqlParameter("@fact_empresa", ((Empresa)cmbEmpresa.SelectedItem).code));
            query.Parameters.Add(new SqlParameter("@fact_fecha", fechaVencimiento.Value));
            query.Parameters.Add(new SqlParameter("@fact_fecha_vencimiento", fechaAlta.Value));
            query.Parameters.Add(new SqlParameter("@fact_total", Double.Parse(txtTotal.Text)));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnBorrarItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdItems.SelectedRows){
                bajaItemFactura(Convert.ToInt32(row.Cells[0].Value));
                cargarItems();
                actualizarItems();
            }
        }

        private void bajaItemFactura(int numeroItem)
        {
            var connection = DBConnection.getInstance().getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("POSTRESQL.bajaItemFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", numeroItem));
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnModificarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdItems.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = grdItems.SelectedRows[0];
                    int id= Int32.Parse(row.Cells[0].Value.ToString());
                    double monto= Double.Parse(row.Cells[3].Value.ToString());
                    int cantidad= Int32.Parse(row.Cells[2].Value.ToString());
                    string concepto = row.Cells[1].Value.ToString();
                    Form modif = new AbmFactura.ModificarItemFactura(this, id, monto, cantidad, concepto);
                    modif.Show();
                    this.Enabled = false;
                }
                else
                    throw new Exception("Se debe seleccionar exactamente una fila");
            }

            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public void modificarItemFactura(int id, string concepto, int cantidad, double monto)
        {
            var connection = DBConnection.getInstance().getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarItemFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@concepto", concepto));
            query.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            query.Parameters.Add(new SqlParameter("@monto", monto));
            query.Parameters.Add(new SqlParameter("@id", id));
            query.ExecuteNonQuery();
            connection.Close();
            cargarItems();
            actualizarItems();
        }

        public void agregarItemFactura(string concepto, int cantidad, double monto)
        {
            var connection = DBConnection.getInstance().getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("POSTRESQL.altaItemFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@concepto", concepto));
            query.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            query.Parameters.Add(new SqlParameter("@monto", monto));
            query.Parameters.Add(new SqlParameter("@numeroFactura", Int32.Parse(txtNumero.Text)));
            query.ExecuteNonQuery();
            connection.Close();
            cargarItems();
            actualizarItems();
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            Form agregar = new AbmFactura.AgregarItemFactura(this);
            agregar.Show();
            this.Enabled = false;
        }
    }
}
