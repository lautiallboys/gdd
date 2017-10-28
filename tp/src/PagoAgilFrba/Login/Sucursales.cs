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

namespace PagoAgilFrba.Login
{
    public partial class Sucursales : Form
    {
        Form login_form;
        string username;
        int role_code;
        public Sucursales(Form login_form, int role_code, string username)
        {
            InitializeComponent();
            this.username = username;
            this.role_code = role_code;
            this.login_form = login_form;
            List<KeyValuePair<int, string>> sucursales = obtenerSucursales();
            Utils.populate(this.comboBox1, sucursales);
            
        }
        private List<KeyValuePair<int, string>> obtenerSucursales()
        {

            SqlDataReader reader;
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("POSTRESQL.obtenerSucursalesDeUsuario", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@username", this.username));
            connection.Open();
            List<KeyValuePair<int, string>> sucursales = new List<KeyValuePair<int, string>>();
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read())
                {
                    sucursales.Add(new KeyValuePair<int, string>(Int32.Parse(reader["sucu_id"].ToString()),
                                                                              reader["sucu_nombre"].ToString()));
                }
            }
            reader.Close();
            connection.Close();
            return sucursales;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex > -1)
            {
                int selected_value = ((KeyValuePair<int, string>)this.comboBox1.SelectedItem).Key;
                (new Menu.MainMenu(this.login_form, this.role_code, this.username, selected_value)).Show();
                this.Close();
            }
            else {
                MessageBox.Show("Elija una sucursal");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Login()).Show();
        }

        private void Sucursales_Load(object sender, EventArgs e)
        {

        }
    }


}
