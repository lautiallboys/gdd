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

namespace PagoAgilFrba.Rendicion
{
    /*funcionalidad para rendir facturas de una empresa, siempre que estas no hayan sido rendidas en ese mes*/
    public partial class Rendicion: Form
    {
        Form parent;
        public Rendicion(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            fillEmpresas();
        }

        private void fillEmpresas()
        {
            foreach (Empresa empresa in obtenerEmpresas())
                this.cmbEmpresa.Items.Add(empresa);
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

        private void validar()
        {

            if (Validacion.estaVacio(txtPorcentaje.Text) || cmbEmpresa.SelectedItem == null )
            {
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtPorcentaje.Text))
            {
                throw new Exception("El porcentaje de comisión debe contener únicamente números");
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.altaRendicion();
                this.Close();
                parent.Show();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void altaRendicion() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaRendicion", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@fecha", fechaRendicion.Value));
            query.Parameters.Add(new SqlParameter("@empresa", ((Empresa)cmbEmpresa.SelectedItem).code));
            query.Parameters.Add(new SqlParameter("@coef", Convert.ToInt32(txtPorcentaje.Text)));
            query.Parameters.Add(new SqlParameter("@total", Convert.ToDouble(txtTotalRendicion.Text)));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void llenarListaFacturas()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.facturasARendir", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@empresa", Convert.ToInt32(((Empresa)cmbEmpresa.SelectedItem).code)));
            query.Parameters.Add(new SqlParameter("@fecha", fechaRendicion.Value));
           
            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            ConfiguradorDataGrid.llenarDataGridConConsulta(reader, grdFacturas);

            connection.Close();
            
        }

        private void obtenerItemsPara(int numeroFactura)
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.itemsPorFactura", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@numeroFactura", numeroFactura));
           
            connection.Open();

            SqlDataReader reader = query.ExecuteReader();

            ConfiguradorDataGrid.llenarDataGridConConsulta(reader, grdItems);

            connection.Close();
            
        }

        private void actualizarFacturas()
        {
            llenarListaFacturas();
            txtCantidadFacturas.Text = grdFacturas.Rows.Count.ToString();
        }

        private void actualizarImportes()
        { 
            double acumuladoFacturas = 0;
            foreach (DataGridViewRow row in grdFacturas.Rows)
                acumuladoFacturas += Double.Parse(row.Cells[4].Value.ToString());
            txtImporteComision.Text = (acumuladoFacturas * (Double.Parse(txtPorcentaje.Text) / 100)).ToString();
            txtTotalRendicion.Text = (acumuladoFacturas + Double.Parse(txtImporteComision.Text)).ToString();
        }

        private void cambioFiltro(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                actualizarFacturas();
                actualizarImportes();
            }
            catch 
            {
            }  
        }

        private void cargarItems(object sender, DataGridViewCellEventArgs e)
        {
            if (grdFacturas.SelectedRows.Count == 1)
                obtenerItemsPara(Int32.Parse(grdFacturas.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void cargarItems(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (grdFacturas.SelectedRows.Count == 1)
                obtenerItemsPara(Int32.Parse(grdFacturas.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void cargarItems(object sender, EventArgs e)
        {
            if (grdFacturas.SelectedRows.Count == 1)
                obtenerItemsPara(Int32.Parse(grdFacturas.SelectedRows[0].Cells[0].Value.ToString()));
     
        }

        private void Rendicion_Load(object sender, EventArgs e)
        {

        }

    }
}
