using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class Validacion
    {
        public static Boolean estaVacio(String texto)
        {
            return texto.Length.Equals(0);
        }
        public static Boolean contieneSoloNumeros(String texto)
        {
            return (texto.All(caracter => Char.IsNumber(caracter)));
        }
    }
}
