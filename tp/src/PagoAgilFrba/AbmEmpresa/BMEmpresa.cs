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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class BMEmpresa : Form
    {
        public BMEmpresa(List<Rubro> rubros)
        {
            InitializeComponent();
            fill_rubro_combo(rubros);
        }

        private void fill_rubro_combo(List<Rubro> rubros)
        {
            foreach (Rubro rubro in rubros)
                this.comboBoxRubro.Items.Add(rubro);
        }

        private void BMCliente_Load(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.todos(), dataGridView1);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private SqlDataReader filtrar()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarEmpresas", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(new SqlParameter("@empr_nombre", txtNombre.Text));
            command.Parameters.Add(new SqlParameter("@empr_cuit", txtCuit.Text));
            if (comboBoxRubro.SelectedIndex > -1)
            {
                Rubro rubro = (Rubro)(this.comboBoxRubro.SelectedItem);
                command.Parameters.Add(new SqlParameter("@empr_rubro", Convert.ToInt32(rubro.code)));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@empr_rubro", Convert.ToInt32(0)));
            }
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

        private ModificadoEmpresa seleccionarEmpresa(){
            AbmEmpresa.ModificadoEmpresa modificar = new ModificadoEmpresa();
            Int16 id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
            String nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            String cuit = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            String direccion = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Int16 rubro_id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            String rubro_detalle = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            bool habilitado = (bool)dataGridView1.SelectedRows[0].Cells[6].Value;
            Rubro rubro = new Rubro(rubro_id,rubro_detalle);

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
                    ModificadoEmpresa aModif = this.seleccionarEmpresa();
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

    }
}
