using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmRol
{
    class Functionality : IEquatable<Functionality>
    {
        public int code { get; private set; }
        public string description { get; private set; }

        public Functionality(int code, string description)
        {
            this.code = code;
            this.description = description;
        }

        public bool Equals(Functionality other)
        {
            return this.code == other.code;
        }

        public override string ToString()
        {
            return this.description;
        }
    }
}