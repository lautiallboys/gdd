﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Menu
{
    /*menu que muestra las funcionalidades disponibles para ese rol*/
    public partial class MainMenu : Form
    {
        Dictionary<int, Func<Form>> form_mapping;
        Form login_form;
        string username;
        int sucursal_code;

        public MainMenu(Form login_form, int role_code, string username, int sucursal_code)
        {
            InitializeComponent();
            this.login_form = login_form;
            this.username = username;
            this.sucursal_code = sucursal_code;
            this.initialize_form_mapping();
            this.fill_list(role_code);
        }

        private void fill_list(int role_code)
        {
            var sp_params = new List<KeyValuePair<string, object>>();
            sp_params.Add(new KeyValuePair<string, object>("@rol_id", role_code));
            var roles = new List<KeyValuePair<int, string>>();

            using (SqlConnection connection = DBConnection.getInstance().getConnection())
            {
                SqlCommand query = Utils.create_sp("POSTRESQL.funcionalidades_del_rol", sp_params, connection);
                connection.Open();
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                    roles.Add(new KeyValuePair<int, string>(Int32.Parse(reader["func_id"].ToString()), reader["func_descripcion"].ToString()));
            }
            Utils.populate(this.listBox1, roles);
            if (this.listBox1.Items.Count < 1)
            {
                this.button1.Enabled = false;
            }
        }

        private void initialize_form_mapping()
        {
            this.form_mapping = new Dictionary<int, Func<Form>>();
            this.form_mapping.Add(1, () => new AbmRol.AbmRol(this, this.username));
            this.form_mapping.Add(2, () => new AbmCliente.InicialCliente(this));
            this.form_mapping.Add(3, () => new AbmEmpresa.InicialEmpresa(this));
            this.form_mapping.Add(4, () => new AbmSucursal.InicialSucursal(this));
            this.form_mapping.Add(5, () => new AbmFactura.MenuFactura(this));
            this.form_mapping.Add(6, () => new RegistroPago.RegistroPago(this, this.username, this.sucursal_code));
            this.form_mapping.Add(7, () => new Devoluciones.Devolucion(this));
            this.form_mapping.Add(8, () => new Rendicion.Rendicion(this));
            this.form_mapping.Add(9, () => new ListadoEstadistico.ListadoEstadistico(this));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.login_form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_functionality_code = ((KeyValuePair<int, string>)this.listBox1.SelectedItem).Key;
            if (!this.form_mapping.ContainsKey(selected_functionality_code))
                return;

            this.Hide();
            (this.form_mapping[selected_functionality_code])().Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load_1(object sender, EventArgs e)
        {

        }
    }
}