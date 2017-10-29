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

namespace PagoAgilFrba.AbmFactura
{
    public partial class  MenuFactura : Form
    {
        Form parent;
        public MenuFactura(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new AbmFactura.AltaFactura();
            alta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form bm = new AbmFactura.BMFactura();
            bm.Show();
        }

        private void MenuFactura_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
