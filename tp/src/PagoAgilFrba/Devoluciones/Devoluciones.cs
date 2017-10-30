using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Devoluciones
{
    class Devoluciones
    {
      public Int32 numeroFactura { get; set; }
      public DateTime fechaDeCobro { get;  set; }
      public Int32 empresa { get;  set; }
      public Int32 cliente { get; set; }
      public DateTime fechaDeVencimiento { get; set; }
      public Int32 importe { get;  set; }
      public Int32 sucursal { get; set; }


    }
}
