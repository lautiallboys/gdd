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
        String codigo;
              
        public ModificarSucursal(Int16 id,String nombre,String direccion, String codigo)
        {
           InitializeComponent();
           this.id = id;
           this.nombre = nombre;
           this.direccion = direccion;
           this.codigo = codigo;

           
            
            
        }

        private void ModificarSucursal_Load(object sender, EventArgs e)
        {
            txtNombre.Text = nombre;
            txtDireccion.Text = direccion;
            txtCodigo.Text = codigo;
           
        }

        private void modificarSucursal() {
            String nombreSucursal = txtNombre.Text;
            String direccionSucursal = txtDireccion.Text;
            String codigoPostal = txtCodigo.Text;

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", id));
            query.Parameters.Add(new SqlParameter("@nombre", nombreSucursal));
            query.Parameters.Add(new SqlParameter("@direccion", direccionSucursal));
            query.Parameters.Add(new SqlParameter("@codigo_postal", codigoPostal));
                
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.modificarSucursal();
            this.Close();
        }


    }
}
