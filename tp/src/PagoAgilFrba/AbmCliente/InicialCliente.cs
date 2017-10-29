using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class InicialCliente : Form
    {
        Form parent;
        public InicialCliente(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new AbmCliente.AltaCliente();
            alta.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form bm = new AbmCliente.BMCliente();
            bm.Show();
        }

        private void InicialCliente_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }
    }
}
