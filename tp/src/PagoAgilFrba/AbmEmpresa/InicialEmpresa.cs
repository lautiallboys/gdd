using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class InicialEmpresa : Form
    {
        public InicialEmpresa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form alta = new AbmEmpresa.AltaEmpresa();
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
    }
}
