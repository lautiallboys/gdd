using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmFactura
{
    class ItemFactura : IEquatable<ItemFactura>
    {
        public double monto{ get; private set; }
        public string concepto { get; private set; }
        public int cantidad { get; private set; }
        public int factura { get; private set; }

        public ItemFactura(string concepto, double monto, int cantidad, int factura)
        {
            this.concepto = concepto;
            this.cantidad = cantidad;
            this.monto = monto;
            this.factura = factura;
        }

        public bool Equals(ItemFactura other)
        {
            return this.factura == other.factura && this.concepto == other.concepto;
        }

        public override string ToString()
        {
            return this.concepto;
        }
    }
}