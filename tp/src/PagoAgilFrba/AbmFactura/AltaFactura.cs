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
            fill_empresas();
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
            if (!Validacion.contieneSoloNumeros(txtNumero.Text))
            {
                throw new Exception("El campo 'Número' solo puede tener números");
            }
            if (noEsUnico(Int32.Parse(txtNumero.Text)))
            {
                throw new Exception("Ya existe una factura con el número ingresado");
            }
            if (!estanBienGenerados(generarItems()))
            {
                throw new Exception("Se deben completar los 3 campos de cada item ingresado correctamente");
            }
            
        }

        private bool noEsUnico(Int32 unNumero)
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
                this.altaFactura();
                this.altaItems();
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

        private void filtrosClienteCambiaron(object sender, EventArgs e)
        {
            fill_clientes();
        }

        private void cambioItems(object sender, DataGridViewCellEventArgs e)
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
                        listaItems.Add(new ItemFactura(row.Cells[0].Value.ToString(), Double.Parse(row.Cells[1].Value.ToString()), Int32.Parse(row.Cells[2].Value.ToString()), Int16.Parse(txtNumero.Text)));
                    }
               
            }
            catch 
            {
                listaItems.Clear();
            }
            return listaItems;
        }

        private void altaFactura() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fact_numero", Int16.Parse(txtNumero.Text)));
            query.Parameters.Add(new SqlParameter("@fact_cliente", ((Cliente)cmbCliente.SelectedItem).code));
            query.Parameters.Add(new SqlParameter("@fact_empresa", ((Empresa)cmbEmpresa.SelectedItem).code));
            query.Parameters.Add(new SqlParameter("@fact_fecha", fechaAlta.Value));
            query.Parameters.Add(new SqlParameter("@fact_fecha_vencimiento", fechaVencimiento.Value));
            query.Parameters.Add(new SqlParameter("@fact_total", Double.Parse(txtTotal.Text)));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void altaItems()
        {
            List<ItemFactura> items = generarItems();

            var connection = DBConnection.getInstance().getConnection();
            connection.Open();

            foreach (ItemFactura item in items)
            {
                SqlCommand query = new SqlCommand("POSTRESQL.altaItemFactura", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@concepto", item.concepto));
                query.Parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                query.Parameters.Add(new SqlParameter("@monto", item.monto));
                query.Parameters.Add(new SqlParameter("@numeroFactura", item.factura));    
                query.ExecuteNonQuery();   
            }
            connection.Close();
        }

        private void AltaFactura_Load(object sender, EventArgs e)
        {

        }

        private void fechaAlta_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
