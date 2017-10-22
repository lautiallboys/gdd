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
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.todos(), dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnModificar_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                   
                    Form modif = new AbmSucursal.ModificarSucursal( this.seleccionarSucursal());
                    modif.Show();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }

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
            SqlCommand query = new SqlCommand("POSTRESQL.modificarSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@nombre", this.seleccionarSucursal().getNombre()));
            query.Parameters.Add(new SqlParameter("@direccion", this.seleccionarSucursal().getDireccion()));
            query.Parameters.Add(new SqlParameter("@codigo_postal", this.seleccionarSucursal().getCodigo()));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        
        
        }

        private ModificadaSucursal seleccionarSucursal() {
            AbmSucursal.ModificadaSucursal modificar = new ModificadaSucursal();
            Int16 id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
            String nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            String direccion = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            String codigo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            modificar.setId(id);
            modificar.setNombre(nombre);
            modificar.setDireccion(direccion);
            modificar.setCodigo(codigo);
            return modificar;    
        
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
              ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }

        private SqlDataReader filtrar()
        {
            SqlDataReader reader;
            SqlCommand consulta = new SqlCommand();
            consulta.CommandType = CommandType.Text;
            //hacer el filtrar sucursal
            
            consulta.CommandText = "SELECT * from GD2C2017.POSTRESQL.filtrarSucursal(@nombre, @direccion, @codigo_postal)";
            consulta.Parameters.Add(new SqlParameter("@nombre", txtNombre.Text));
            consulta.Parameters.Add(new SqlParameter("@direccion", txtDireccion.Text));
            consulta.Parameters.Add(new SqlParameter("@codigo_postal", txtCodigo.Text));
            consulta.Connection = DBConnection.getInstance().getConnection();
            reader = consulta.ExecuteReader();

            return reader;


        }


        private SqlDataReader todos()
        {
            SqlDataReader reader;
            SqlCommand consulta = new SqlCommand();
            consulta.CommandType = CommandType.Text;
            

            consulta.CommandText = "SELECT * from GD2C2017.POSTRESQL)";
           
            consulta.Connection = DBConnection.getInstance().getConnection();
            reader = consulta.ExecuteReader();

            return reader;


        }




    }
}
