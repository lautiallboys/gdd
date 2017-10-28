using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmCliente
{
    class ModificadoCliente
    {
        Int16 id;
        Int32 dni;
        String apellido;
        String nombre;
        DateTime fecha;
        String mail;
        Int16 telefono;
        String direccion;
        String codigo;

        public void setId(Int16 id)
        {
            this.id = id;
        }
        public void setDni(Int32 dni)
        {
            this.dni = dni;
        }
        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public void setFecha(DateTime fecha) {
            this.fecha = fecha;
        }
        public void setMail(String mail) {
            this.mail = mail;
        }
        public void setTelefono(Int16 telefono) {
            this.telefono = telefono;
        }
        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }
        public void setCodigo(String codigo)
        {
            this.codigo = codigo;
        }
        public Int16 getId()
        {
            return id;
        }
        public Int32 getDni()
        {
            return dni;
        }
        public String getNombre()
        {
            return nombre;
        }
        public String getApellido()
        {
            return apellido;
        }
        public String getMail()
        {
            return mail;
        }
        public String getDireccion()
        {
            return direccion;
        }
        public String getCodigo()
        {
            return codigo;
        }
        public Int16 getTelefono()
        {
            return telefono;
        }
        public DateTime getFecha() {
            return fecha;
        }

    }
}
