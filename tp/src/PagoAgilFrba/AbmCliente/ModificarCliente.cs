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
    public partial class ModificarCliente : Form
    {
        Int16 id;
        Int32 dni;
        String apellido;
        String nombre;
        DateTime fecha;
        String mail;
        Int16 telefono;
        String direccion;
        String codigo;




        public ModificarCliente(Int16 id, Int32 dni, String apellido, String nombre,DateTime fecha, String mail,Int16 telefono,String direccion, String codigo)
        {
            InitializeComponent();
            this.id = id;
            this.dni = dni;
            this.apellido = apellido;
            this.nombre = nombre;
            this.fecha = fecha;
            this.mail = mail;
            this.telefono = telefono;
            this.direccion = direccion;
            this.codigo = codigo;

        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            txtDni.Text = dni.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            dtmFecha.Value = fecha;
            txtMail.Text = mail;
            txtTelefono.Text = telefono.ToString();
            txtDireccion.Text = direccion;
            txtCodigo.Text = codigo;



        }


        private void modificarCliente() {

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarCliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", id));
            query.Parameters.Add(new SqlParameter("@dni",dni));
            query.Parameters.Add(new SqlParameter("@apellido", apellido));
            query.Parameters.Add(new SqlParameter("@nombre", nombre));
            query.Parameters.Add(new SqlParameter("@mail", mail));
            query.Parameters.Add(new SqlParameter("@telefono", telefono));
            query.Parameters.Add(new SqlParameter("@direccion", direccion));
            query.Parameters.Add(new SqlParameter("@codigo", codigo));
            query.Parameters.Add(new SqlParameter("@fecha", fecha));

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.modificarCliente();
            this.Close();
        }

    }
}
