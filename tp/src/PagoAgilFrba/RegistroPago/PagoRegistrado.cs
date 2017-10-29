using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    class PagoRegistrado
    {
        Int32 numeroFactura;
        DateTime fechaDeCobro;
        Int32 empresa;
        Int32 cliente;
        DateTime fechaDeVencimiento;
        Int32 importe;
        Int32 sucursal;

        

        public void setNumeroFactura(Int32 numeroFactura)
        {
            this.numeroFactura = numeroFactura;
        }

        public Int32 getNumeroFactura()
        {
            return this.numeroFactura;
        }

        public void setFechaDeCobro(DateTime fechaDeCobro)
        {
            this.fechaDeCobro = fechaDeCobro;
        }

        public DateTime getFechaDeCobro()
        {
            return this.fechaDeCobro;
        }

        public void setEmpresa(Int32 empresa)
        {
            this.empresa = empresa;
        }

        public Int32 getEmpresa()
        {
            return this.empresa;
        }

        public void setCliente(Int32 cliente)
        {
            this.cliente = cliente;
        }

        public Int32 getCliente()
        {
            return this.cliente;
        }

        public void setFechaDeVencimiento(DateTime fechaDeVencimiento)
        {
            this.fechaDeVencimiento = fechaDeVencimiento;
        }

        public DateTime getFechaVencimiento()
        {
            return this.fechaDeVencimiento;
        }

        public void setImporte(Int32 importe)
        {
            this.importe = importe;
        }

        public Int32 getImporte()
        {
            return this.importe;
        }

        public void setSucursal(Int32 sucursal)
        {
            this.sucursal = sucursal;
        }

        public Int32 getSucursal()
        {
            return this.sucursal;
        }

    }
}
