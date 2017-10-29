using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        Form parent;
        List<string> meses = new List<string>();

        public ListadoEstadistico(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.numericUpDown1.Maximum = int.MaxValue;
            this.numericUpDown1.Value = 2017;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = new SqlCommand("POSTRESQL.listados", connection);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@anio", numericUpDown1.Value));
                query.Parameters.Add(new SqlParameter("@nro_trim", numericUpDown2.Value));
                query.Parameters.Add(new SqlParameter("@tipoListado", comboBox1.SelectedIndex));

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                this.dataGridView1.DataSource = table;
                this.dataGridView1.ReadOnly = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                this.dataGridView1.AllowUserToAddRows = false;
            }
        }

    }
}