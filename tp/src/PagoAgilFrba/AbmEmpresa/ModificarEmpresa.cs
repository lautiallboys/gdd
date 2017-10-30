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
    public partial class ModificarEmpresa : Form
    {
        public Int16 id { get; set; }
        public Rubro rubro { get; set; }
        public String cuit { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public bool habilitado { get; set; }




        public ModificarEmpresa(Int16 id,Rubro rubro, String cuit, String nombre, String direccion, bool habilitado)
        {
            InitializeComponent();
            this.id = id;
            this.rubro = rubro;
            this.cuit = cuit;
            this.nombre = nombre;
            this.direccion = direccion;
            this.habilitado = habilitado;
            if (habilitado)
                checkBox1.Checked = true;
            fill_rubro_combo(rubro);
        }

        private void validar()
        {
            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtCuit.Text) || Validacion.estaVacio(txtDireccion.Text) || comboBoxRubro.SelectedItem == null)
            {
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.tieneFormatoDeCuit(txtCuit.Text))
            {

                throw new Exception("No tiene formato de cuit");
            }
        }

        private void fill_rubro_combo(Rubro rubroSeleccionado)
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
            foreach (Rubro rubro in all_functionalities)
            {
                this.comboBoxRubro.Items.Add(rubro);
                if (rubro.code == rubroSeleccionado.code)
                    this.comboBoxRubro.SelectedItem = rubro;
            }
        }

        private void ModificarEmpresa_Load(object sender, EventArgs e)
        {
            txtDireccion.Text = direccion;
            txtNombre.Text = nombre;
            txtCuit.Text = cuit;
            comboBoxRubro.SelectedItem = rubro;

        }


        private void modificarEmpresa() {

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarEmpresa", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@empr_id", id));
            query.Parameters.Add(new SqlParameter("@empr_nombre", this.txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@empr_cuit", this.txtCuit.Text));
            query.Parameters.Add(new SqlParameter("@empr_direccion", this.txtDireccion.Text));
            Rubro rubro = (Rubro)(this.comboBoxRubro.SelectedItem);
            query.Parameters.Add(new SqlParameter("@empr_rubro", Convert.ToInt32(rubro.code)));
            bool habilitado = false;
            if (checkBox1.Checked)
            {
                habilitado = true;
            }
            query.Parameters.Add(new SqlParameter("@empr_habilitado", habilitado)); 
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.modificarEmpresa();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
