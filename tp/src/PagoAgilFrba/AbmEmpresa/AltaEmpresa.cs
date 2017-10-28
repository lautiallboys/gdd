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
    public partial class AltaEmpresa : Form
    {
        public AltaEmpresa()
        {
            InitializeComponent();
            fill_rubro_combo();

        }

        private void fill_rubro_combo()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<Rubro> current_functionalities = new List<Rubro>();
            List<Rubro> all_functionalities = new List<Rubro>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT * FROM POSTRESQL.Rubro", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                all_functionalities.Add(new Rubro(Int32.Parse(reader["rubr_id"].ToString()), reader["rubr_detalle"].ToString()));
            connection.Close();

            // Si es un update, pido las funcionalidades asignadas al rol
            /* if (this.rubro_code > 0)
            {
                SqlCommand current_functionalities_command = new SqlCommand("POSTRESQL.rubros_de_empresa", connection);
                current_functionalities_command.CommandType = CommandType.StoredProcedure;
                current_functionalities_command.Parameters.Add(new SqlParameter("@rol_id", role_code));
                connection.Open();
                SqlDataReader second_reader = current_functionalities_command.ExecuteReader();
                while (second_reader.Read())
                    current_functionalities.Add(new Functionality(Int32.Parse(second_reader["func_id"].ToString()), second_reader["func_descripcion"].ToString()));
                connection.Close();
            } */

            foreach (Rubro rubro in all_functionalities)
                this.comboBoxRubro.Items.Add(rubro);
       
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void validar()
        {
            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtCuit.Text) || Validacion.estaVacio(txtDireccion.Text) || Validacion.estaVacio(comboBoxRubro.Text))
            {
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtCuit.Text))
                throw new Exception("El Cuit debe contener únicamente números");
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.altaCliente();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void altaCliente() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaEmpresa", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@empr_nombre", Convert.ToInt16(this.txtNombre.Text)));
            query.Parameters.Add(new SqlParameter("@empr_cuit", Convert.ToInt16(this.txtCuit.Text)));
            query.Parameters.Add(new SqlParameter("@empr_direccion", this.txtDireccion.Text));
            query.Parameters.Add(new SqlParameter("@empr_rubro", this.comboBoxRubro.Text)); 

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
