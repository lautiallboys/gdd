using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Login
{
    public partial class EleccionRoles : Form
    {
        Form login_form;
        string username;
        int sucursal_code = 0;

        public EleccionRoles(Form login_form, string username, List<KeyValuePair<int, string>> roles)
        {
            InitializeComponent();
            this.login_form = login_form;
            this.username = username;
            Utils.populate(this.comboBox1, roles);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new Login()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_value = ((KeyValuePair<int, string>)this.comboBox1.SelectedItem).Key;
            if (selected_value == 1)
                (new Menu.MainMenu(this.login_form, selected_value, this.username, this.sucursal_code)).Show();
            else
                (new Sucursales(this.login_form, selected_value, this.username)).Show();
            this.Close();
        }

        private void EleccionRoles_Load(object sender, EventArgs e)
        {

        }
    }
}