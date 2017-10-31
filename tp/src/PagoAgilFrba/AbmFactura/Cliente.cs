using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmFactura
{
    public class Cliente : IEquatable<Cliente>
    {
        public int code { get; private set; }
        public string name { get; private set; }
        public string surname{ get; private set; }
        public int dni { get; private set; }

        public Cliente(int code, string name, string surname, int dni)
        {
            this.code = code;
            this.name= name;
            this.surname = surname;
            this.dni = dni;
        }

        public bool Equals(Cliente other)
        {
            return this.code == other.code;
        }

        public override string ToString()
        {
            return this.name + ' ' + this.surname + " (" + this.dni + ")";
        }
    }
}
