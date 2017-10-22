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

namespace PagoAgilFrba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = DBConnection.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from gd_esquema.Maestra;", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)  // El usuario no existe
                MessageBox.Show("no se que mierda paso");
            else
                while (reader.Read())
                {
                    MessageBox.Show(reader["Cliente-Apellido"].ToString());
                }
            reader.Close();
            connection.Close();
        }
    }
}
