using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmEmpresa
{
    public class ModificadoEmpresa
    {
        public Int16 id { get; set; }
        public Rubro rubro { get; set; }
        public String cuit { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public bool habilitado { get; set; }
    }
}
