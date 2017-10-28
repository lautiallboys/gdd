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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ModificarSucursal : Form
    {
  
        Int16 id;
        String nombre;
        String direccion;
        Int32 codigo;
        bool habilitado;

        public ModificarSucursal(Int16 id, String nombre, String direccion, Int32 codigo, bool habilitado)
        {
           InitializeComponent();
           this.id = id;
           this.nombre = nombre;
           this.direccion = direccion;
           this.codigo = codigo;
           this.habilitado = habilitado;
           if (habilitado)
               checkBox1.Checked = true;
        }

        private void ModificarSucursal_Load(object sender, EventArgs e)
        {
            txtNombre.Text = nombre;
            txtDireccion.Text = direccion;
            txtCodigo.Text = codigo.ToString();
           
        }

        private void validar()
        {
            if (Validacion.estaVacio(txtCodigo.Text) || Validacion.estaVacio(txtDireccion.Text) || Validacion.estaVacio(txtNombre.Text))
            {
                throw new Exception("Debe completar todos los datos");
            }
            if (!Validacion.contieneSoloNumeros(txtCodigo.Text))
                throw new Exception("El código postal debe contener únicamente números");

            //  if (!txtSucu_codigo_postal.Text.Count().Equals(4))
            //    throw new Exception("El código postal debe estar compuesto por 4 números");

        }

        private void modificarSucursal() {
            String nombreSucursal = txtNombre.Text;
            String direccionSucursal = txtDireccion.Text;
            String codigoPostal = txtCodigo.Text;

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", id));
            query.Parameters.Add(new SqlParameter("@nombre", txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@direccion", txtDireccion.Text));
            query.Parameters.Add(new SqlParameter("@codigo_postal", Convert.ToInt32(txtCodigo.Text)));
            bool habilitado = false;
            if (checkBox1.Checked)
            {
                habilitado = true;
            }
            query.Parameters.Add(new SqlParameter("@habilitado", habilitado)); 
                
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.modificarSucursal();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }


    }
}
