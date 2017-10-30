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
        public AltaEmpresa(List<Rubro> rubros)
        {
            InitializeComponent();
            fill_rubro_combo(rubros);

        }

        private void fill_rubro_combo(List<Rubro> rubros)
        {
            foreach (Rubro rubro in rubros)
                this.comboBoxRubro.Items.Add(rubro);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void validar()
        {
            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtCuit.Text) || Validacion.estaVacio(txtDireccion.Text) || comboBoxRubro.SelectedItem == null)
            {
               
                throw new Exception("Debe completar todos los datos");
            }
           if (!Validacion.tieneFormatoDeCuit(txtCuit.Text)) {
                
                throw new Exception("No tiene formato de cuit");
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.altaEmpresa();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void altaEmpresa() {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.altaEmpresa", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@empr_nombre", this.txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@empr_cuit", this.txtCuit.Text));
            query.Parameters.Add(new SqlParameter("@empr_direccion", this.txtDireccion.Text));
            Rubro rubro = (Rubro) (this.comboBoxRubro.SelectedItem);
            query.Parameters.Add(new SqlParameter("@empr_rubro", Convert.ToInt32(rubro.code))); 
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

        private void comboBoxRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRubro.Text = comboBoxRubro.SelectedText;
        }

    }
}
