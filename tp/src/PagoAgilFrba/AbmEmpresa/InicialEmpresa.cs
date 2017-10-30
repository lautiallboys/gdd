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
    public partial class InicialEmpresa : Form
    {
        Form parent;
        public InicialEmpresa(Form form)
        {
            this.parent = form;
            InitializeComponent();
        }

        private List<Rubro> obtenerRubros()
        {
            var connection = DBConnection.getInstance().getConnection();
            List<Rubro> rubros = new List<Rubro>();

            // Pido todas las funcionalidades
            SqlCommand all_functionalities_command = new SqlCommand("SELECT * FROM POSTRESQL.Rubro", connection);
            connection.Open();
            SqlDataReader reader = all_functionalities_command.ExecuteReader();
            while (reader.Read())
                rubros.Add(new Rubro(Int32.Parse(reader["rubr_id"].ToString()), reader["rubr_detalle"].ToString()));
            connection.Close();
            return rubros;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new AbmEmpresa.AltaEmpresa(obtenerRubros());
            alta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form bm = new AbmEmpresa.BMEmpresa(obtenerRubros());
            bm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void InicialEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
