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
    /* Funcionalidad que permite devolver una factura si esta existe y fue pagada */
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
            try
            {
                this.validar();
                this.efectuarDevolucion();
                this.Close();
                this.parent.Show();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Error", MessageBoxButtons.OK);
            }

        }


        private void efectuarDevolucion()
        {   
            var connection = DBConnection.getInstance().getConnection();
            if (factura_es_valida(Convert.ToInt32(this.txtCodigoFactura.Text))) {
              SqlCommand query = new SqlCommand("POSTRESQL.efectuarDevolucion", connection);
              query.CommandType = CommandType.StoredProcedure;
              query.Parameters.Add(new SqlParameter("@factura", Convert.ToInt32(this.txtCodigoFactura.Text)));
              query.Parameters.Add(new SqlParameter("@motivo", this.txtMotivo.Text));
              query.Parameters.Add(new SqlParameter("@fecha", DateTime.Today));
              
              connection.Open();
              query.ExecuteNonQuery();
              connection.Close();
            } else {
                throw new Exception("El numero de factura no existe o no fue pagada");
            }
            
            
        }

        private bool factura_es_valida(Int32 numero) {
            SqlDataReader reader;
            var connection = DBConnection.getInstance().getConnection();
            String command = "SELECT * from POSTRESQL.Factura where fact_numero=" + numero.ToString();
            SqlCommand consulta = new SqlCommand(command, connection);
            connection.Open();

            reader = consulta.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string pagado = reader["fact_pagado"].ToString();
                return pagado == "True";
            }
            else {

                return false;
            }

        }

    
        private void validar() {
          if (Validacion.estaVacio(txtCodigoFactura.Text) || Validacion.estaVacio(txtMotivo.Text))
            {
                MessageBox.Show("Debe completar todos los datos", "Error", MessageBoxButtons.OK);
                throw new Exception("Debe completar todos los datos");
           } 
          if (!Validacion.contieneSoloNumeros(txtCodigoFactura.Text)){
                throw new Exception("El código de Factura debe tener solo numeros");
          }
          

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Show();
        }

        private void AltaSucursal_Load(object sender, EventArgs e)
        {

        }
    }
}
