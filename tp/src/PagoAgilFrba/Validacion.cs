using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static Boolean tieneFormatoMail(String texto) { 
            
            return Regex.IsMatch(texto, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");// false o True
        }


        public static Boolean tieneFormatoDeCuit(String texto)
        {
            int i = 0;

            for ( ; i < 2; i++)
            {
                if (!Char.IsNumber(texto[i]))
                    return false;
            }

            if (!texto[i].Equals('-'))
                return false;

            for (i++; i < 11; i++)
            {
                if(!Char.IsNumber(texto[i]))
                    return false;
            }

            if (!texto[i].Equals('-'))
                return false;

            for (i++; i < 13; i++)
            {
                if (!Char.IsNumber(texto[i]))
                    return false;
            }

            return true;
        }



    }
}
