using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class BMSucursal : Form
    {
        public BMSucursal()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


       private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.bajaSucursal();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void bajaSucursal() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.bajaSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", this.seleccionarSucursal().getId()));
           

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        
        
        }

        private ModificadaSucursal seleccionarSucursal() {
            AbmSucursal.ModificadaSucursal modificar = new ModificadaSucursal();
            Int16 id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
            String nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            String direccion = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Int32 codigo =  Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            bool habilitado = (bool)dataGridView1.SelectedRows[0].Cells[4].Value;
            modificar.setId(id);
            modificar.setNombre(nombre);
            modificar.setDireccion(direccion);
            modificar.setCodigo(codigo);
            modificar.habilitado = habilitado;
            return modificar;    
        
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
              ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private SqlDataReader filtrar()
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarSucursales", connection);
            command.CommandType = CommandType.StoredProcedure;
                     
           
            command.Parameters.Add(new SqlParameter("@nombre", txtNombre.Text));
            command.Parameters.Add(new SqlParameter("@direccion", txtDireccion.Text));
            command.Parameters.Add(new SqlParameter("@codigo_postal", txtCodigo.Text));
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;


        }


        private SqlDataReader todos()
        {
      
            SqlDataReader reader;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand consulta = new SqlCommand("SELECT * from POSTRESQL.Sucursal",connection);
            connection.Open();
            
            reader = consulta.ExecuteReader();

            return reader;


        }

        private void BMSucursal_Load(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.todos(), dataGridView1);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    ModificadaSucursal aModif = this.seleccionarSucursal();
                    Form modif = new AbmSucursal.ModificarSucursal(aModif.getId(), aModif.getNombre(), aModif.getDireccion(), aModif.getCodigo(), aModif.habilitado);
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
