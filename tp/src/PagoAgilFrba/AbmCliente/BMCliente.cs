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

namespace PagoAgilFrba.AbmCliente
{
    public partial class BMCliente : Form
    {
        public BMCliente()
        {
            InitializeComponent();
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
            SqlCommand command = new SqlCommand("POSTRESQL.filtrarClientes", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add(new SqlParameter("@nombre", txtNombre.Text));
            command.Parameters.Add(new SqlParameter("@apellido", txtApellido.Text));
            if (txtDni.Text == "")
            {
                command.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(0)));
            }
            else 
            {
                command.Parameters.Add(new SqlParameter("@dni", Convert.ToInt32(txtDni.Text)));
            }
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;


        }
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

        private ModificadoCliente seleccionarCliente() {
            AbmCliente.ModificadoCliente modificar = new ModificadoCliente();
            Int32 id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Int32 dni = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            String apellido = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            String nombre = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
            String mail = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Int32 telefono = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value);
            String direccion = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            Int32 codigo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            bool habilitado = (bool)dataGridView1.SelectedRows[0].Cells[9].Value;
            
            modificar.setId(id);
            modificar.setNombre(nombre);
            modificar.setApellido(apellido);
            modificar.setDni(dni);
            modificar.setFecha(fecha);
            modificar.setMail(mail);
            modificar.setTelefono(telefono);
            modificar.setDireccion(direccion);
            modificar.setCodigo(codigo);
            modificar.setHabilitado(habilitado);
            
            return modificar;    
        
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    ModificadoCliente aModif = this.seleccionarCliente();
                    Form modif = new AbmCliente.ModificarCliente(aModif.getId(),aModif.getDni(),aModif.getApellido(),aModif.getNombre(), aModif.getFecha(),aModif.getMail(),aModif.getTelefono(), aModif.getDireccion(), aModif.getCodigo(), aModif.getHabilitado());
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
