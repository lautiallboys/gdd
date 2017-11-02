using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal 
{
    public partial class InicialSucursal  : Form 
    {
        /* Menu inicial del ABM Sucursal que permite alta, baja y modificacion */
        Form parent;
        public InicialSucursal(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Form alta = new AbmSucursal.AltaSucursal();
            alta.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Form bm = new AbmSucursal.BMSucursal();
            bm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void InicialSucursal_Load(object sender, EventArgs e)
        {

        }

    }
}
