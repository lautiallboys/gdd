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
        public BMEmpresa()
        {
            InitializeComponent();
        }

        private void BMCliente_Load(object sender, EventArgs e)
        {
            ConfiguradorDataGrid.llenarDataGridConConsulta(this.todos(), dataGridView1);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
          //ConfiguradorDataGrid.llenarDataGridConConsulta(this.filtrar(), dataGridView1);
        }
        /*
        private SqlDataReader filtrar()
        {
            //HACER FUNCION
            SqlDataReader reader= new SqlDataReader();
            return reader;
        }
        */
        private SqlDataReader todos()
        {

            SqlDataReader reader;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand consulta = new SqlCommand("SELECT * from POSTRESQL.Cliente", connection);
            connection.Open();

            reader = consulta.ExecuteReader();

            return reader;


        }

        private void bajaCliente() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.bajaCliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", this.seleccionarCliente().getId()));


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
                    this.bajaCliente();
                    this.Close();
                }
                catch (Exception excepcion)
                {
                    MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
                }
            }
           
        
        }

        private ModificadoEmpresa seleccionarCliente(){
            AbmEmpresa.ModificadoEmpresa modificar = new ModificadoEmpresa();
            Int16 id = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[0].Value);
            Int32 dni = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[1].Value);
            String apellido = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            String nombre = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
            String mail = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Int16 telefono = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells[6].Value);
            String direccion = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            String codigo = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            
            modificar.setId(id);
            modificar.setNombre(nombre);
            modificar.setApellido(apellido);
            modificar.setDni(dni);
            modificar.setFecha(fecha);
            modificar.setMail(mail);
            modificar.setTelefono(telefono);
            modificar.setDireccion(direccion);
            modificar.setCodigo(codigo);
            
            return modificar;    
        
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    ModificadoEmpresa aModif = this.seleccionarCliente();
                    Form modif = new AbmCliente.ModificarCliente(aModif.getId(),aModif.getDni(),aModif.getApellido(),aModif.getNombre(), aModif.getFecha(),aModif.getMail(),aModif.getTelefono(), aModif.getDireccion(), aModif.getCodigo());
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
