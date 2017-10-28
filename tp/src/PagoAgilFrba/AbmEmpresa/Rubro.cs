using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmEmpresa
{
    class Rubro : IEquatable<Rubro>
    {
        public int code { get; private set; }
        public string description { get; private set; }

        public Rubro(int code, string description)
        {
            this.code = code;
            this.description = description;
        }

        public bool Equals(Rubro other)
        {
            return this.code == other.code;
        }

        public override string ToString()
        {
            return this.description;
        }
    }
}
