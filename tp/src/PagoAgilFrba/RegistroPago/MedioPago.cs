using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.RegistroPago
{
    public class MedioPago: IEquatable<MedioPago>
    {
        public int code { get; private set; }
        public string name{ get; private set; }

        public MedioPago(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        public bool Equals(MedioPago other)
        {
            return this.code == other.code;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
