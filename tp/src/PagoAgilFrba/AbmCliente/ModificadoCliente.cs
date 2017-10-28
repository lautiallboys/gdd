using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.AbmCliente
{
    class ModificadoCliente
    {
        Int32 id;
        Int32 dni;
        String apellido;
        String nombre;
        DateTime fecha;
        String mail;
        Int32 telefono;
        String direccion;
        Int32 codigo;
        bool habilitado;

        public void setHabilitado(bool habilitado)
        {
            this.habilitado = habilitado;
        }

        public bool getHabilitado()
        {
            return this.habilitado;
        }

        public void setId(Int32 id)
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
        public void setTelefono(Int32 telefono) {
            this.telefono = telefono;
        }
        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }
        public void setCodigo(Int32 codigo)
        {
            this.codigo = codigo;
        }
        public Int32 getId()
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
        public Int32 getCodigo()
        {
            return codigo;
        }
        public Int32 getTelefono()
        {
            return telefono;
        }
        public DateTime getFecha() {
            return fecha;
        }

    }
}
