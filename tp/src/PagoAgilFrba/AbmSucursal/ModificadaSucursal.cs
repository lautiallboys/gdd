using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmSucursal
{
    public class ModificadaSucursal
    {
        public Int16 id{ get;  set; }
        public String nombre { get;  set; }
        public String direccion { get;  set; }
        public Int32 codigo { get;  set; }
        public bool habilitado { get; set; }

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
        public void setCodigo(Int32 codigo)
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
        public Int32 getCodigo()
        {
            return codigo;
        }
    }
}
