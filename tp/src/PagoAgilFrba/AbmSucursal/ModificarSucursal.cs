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
        int id;
        public ModificarSucursal(ModificadaSucursal modif)
        {
            InitializeComponent();
            txtNombre.Text = modif.getNombre();
            txtDireccion.Text = modif.getDireccion();
            txtCodigo.Text = modif.getCodigo();
            id = modif.getId();
        }

        private void ModificarSucursal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificadaSucursal a_modificar = new ModificadaSucursal();
            a_modificar.setNombre(txtNombre.Text);
            a_modificar.setDireccion(txtDireccion.Text);
            a_modificar.setCodigo(txtCodigo.Text);


        }


        private void modificarSucursal() {
            String nombreSucursal = txtNombre.Text;
            String direccionSucursal = txtDireccion.Text;
            String codigoPostal = txtCodigo.Text;

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.bajaSucursal", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", id));
            query.Parameters.Add(new SqlParameter("@nombre", nombreSucursal));
            query.Parameters.Add(new SqlParameter("@direccion", direccionSucursal));
            query.Parameters.Add(new SqlParameter("@codigo_postal", codigoPostal));
                
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }


    }
}
