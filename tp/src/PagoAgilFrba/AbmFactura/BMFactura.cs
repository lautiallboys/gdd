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
            InitializeComponent();
            this.parent = parent;
            InitializeComponent();
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

        private void fill_empresas(String nombreFiltro, String cuitFiltro, Int32 codigoRubroFiltro)
        {
            this.cmbEmpresa.Items.Clear();
            foreach (Empresa empresa in obtenerEmpresas(nombreFiltro, cuitFiltro, codigoRubroFiltro))
                this.cmbEmpresa.Items.Add(empresa);
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
        
        private void BMCliente_Load(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.todos(), dataGridView1);
        }

        private SqlDataReader filtrar()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarFacturasModificables", connection);
            command.CommandType = CommandType.StoredProcedure;

            int codigoEmpresa;
            if(cmbEmpresa.SelectedItem != null)
            {
                codigoEmpresa = ((Empresa)cmbEmpresa.SelectedItem).code;
            }
            else
            {
                codigoEmpresa = 0;
            
            }
            command.Parameters.Add(new SqlParameter("@fact_cliente", txtCliente.Text));
            command.Parameters.Add(new SqlParameter("@fact_empresa", codigoEmpresa));
            command.Parameters.Add(new SqlParameter("@fact_numero", txtNumero.Text));
           
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;


        }
        private SqlDataReader todos()
        {

            SqlDataReader reader;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand consulta = new SqlCommand("SELECT empr_id, empr_nombre, empr_cuit, empr_direccion, empr_rubro, rubr_detalle, empr_habilitado from POSTRESQL.Empresa join POSTRESQL.Rubro on empr_rubro = rubr_id", connection);
            connection.Open();

            reader = consulta.ExecuteReader();

            return reader;


        }

        private void bajaEmpresa() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.bajaEmpresa", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", this.seleccionarEmpresa().id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        
        }



        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.bajaEmpresa();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
           
        
        }

        private AbmEmpresa.ModificadoEmpresa seleccionarEmpresa(){
            AbmEmpresa.ModificadoEmpresa modificar = new AbmEmpresa.ModificadoEmpresa();
            Int16 id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
            String nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            String cuit = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            String direccion = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Int16 rubro_id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            String rubro_detalle = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            bool habilitado = (bool)dataGridView1.SelectedRows[0].Cells[6].Value;
            AbmEmpresa.Rubro rubro = new AbmEmpresa.Rubro(rubro_id, rubro_detalle);

            modificar.id = id;
            modificar.cuit = cuit;
            modificar.direccion = direccion;
            modificar.nombre = nombre;
            modificar.rubro = rubro;
            modificar.habilitado = habilitado;
            return modificar;
        
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    AbmEmpresa.ModificadoEmpresa aModif = this.seleccionarEmpresa();
                    Form modif = new AbmEmpresa.ModificarEmpresa(aModif.id, aModif.rubro, aModif.cuit, aModif.nombre, aModif.direccion, aModif.habilitado);
                    modif.Show();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void cambioFiltro(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Close();
        }

    }
}
