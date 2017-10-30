using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.Devoluciones
{
    public partial class Devolucion : Form
    {

        Form parent;
        public Devolucion(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }


        private void btnDevolucion_Click(object sender, EventArgs e)
        {


        }

    
        private void validar() {

          //  if (!txtSucu_codigo_postal.Text.Count().Equals(4))
            //    throw new Exception("El código postal debe estar compuesto por 4 números");
        
        }

        private void AltaSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
