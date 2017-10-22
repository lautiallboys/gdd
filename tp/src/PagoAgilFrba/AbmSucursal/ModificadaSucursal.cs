using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmSucursal
{
    class ModificadaSucursal
    {
        Int16 id;
        String nombre;
        String direccion;
        String codigo;

        public void setId(Int16 id)
        {
            this.id = id;
        }
        public void setNombre(String nombre)
        {
            this.nombre =  nombre;
        }
        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }
        public void setCodigo(String codigo)
        {
            this.codigo = codigo;
        }
        public Int16 getId() {
            return id;
        }
        public String getNombre() {
            return nombre;
        }
        public String getDireccion()
        {
            return direccion;
        }
        public String getCodigo()
        {
            return codigo;
        }
    }
}
