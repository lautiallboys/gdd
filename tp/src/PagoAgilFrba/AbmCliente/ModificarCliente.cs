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
        Int32 id;
        Int32 dni;
        String apellido;
        String nombre;
        DateTime fecha;
        String mail;
        Int32 telefono;
        String direccion;
        Int32 codigo;
        bool habilitado;




        public ModificarCliente(Int32 id, Int32 dni, String apellido, String nombre,DateTime fecha, String mail,Int32 telefono,String direccion, Int32 codigo, bool habilitado)
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
            this.habilitado = habilitado;
            if (habilitado)
                checkBox1.Checked = true;

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
            txtCodigo.Text = codigo.ToString();
        }


        private void modificarCliente() {

            var connection = DBConnection.getInstance().getConnection();
            SqlCommand query = new SqlCommand("POSTRESQL.modificarCliente", connection);
            query.CommandType = CommandType.StoredProcedure;
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@id", id));
            query.Parameters.Add(new SqlParameter("@dni",Convert.ToInt32(txtDni.Text)));
            query.Parameters.Add(new SqlParameter("@apellido", txtApellido.Text));
            query.Parameters.Add(new SqlParameter("@nombre", txtNombre.Text));
            query.Parameters.Add(new SqlParameter("@mail", txtMail.Text));
            query.Parameters.Add(new SqlParameter("@telefono", Convert.ToInt32(txtTelefono.Text)));
            query.Parameters.Add(new SqlParameter("@direccion", txtDireccion.Text));
            query.Parameters.Add(new SqlParameter("@codigo", Convert.ToInt32(txtCodigo.Text)));
            query.Parameters.Add(new SqlParameter("@fecha", dtmFecha.Value));
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

        private void validar()
        {
            if (Validacion.estaVacio(txtNombre.Text) || Validacion.estaVacio(txtApellido.Text) || Validacion.estaVacio(txtDni.Text) || Validacion.estaVacio(txtMail.Text) || Validacion.estaVacio(txtTelefono.Text) || Validacion.estaVacio(txtDireccion.Text) || Validacion.estaVacio(txtCodigo.Text))
            {
                
                throw new Exception("Debe completar todos los datos");

            }
            if (!Validacion.contieneSoloNumeros(txtCodigo.Text))
            {
               
                throw new Exception("El código postal debe contener únicamente números");
            }
            if (!Validacion.contieneSoloNumeros(txtTelefono.Text))
            {
        
                throw new Exception("El telefono debe contener únicamente números");
            }
            if (!Validacion.contieneSoloNumeros(txtDni.Text))
            {
               
                throw new Exception("El dni debe contener únicamente números");
            }
            if (!Validacion.tieneFormatoMail(txtMail.Text))
            {

                throw new Exception("Ingrese el mail correctamente");
            }

        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                this.modificarCliente();
                this.Close();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }
        }

    }
}
