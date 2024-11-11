using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public abstract class Persona
    {
        protected string nombre;
        protected string informacionContacto;
        protected string direccion;

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }
        public string GetInformacionContacto()
        {
            return informacionContacto;
        }
        public void SetInformacionContacto(string value)
        {
            informacionContacto = value;
        }
        public string GetDireccion()
        {
            return direccion;
        }
        public void SetDireccion(string value)
        {
            direccion = value;
        }

        protected Persona(string nombre, string informacionContacto, string direccion)
        {
            this.nombre = nombre;
            this.informacionContacto = informacionContacto;
            this.direccion = direccion;
        }

        public abstract void ActualizarInfoContacto(string nuevaInformacionContacto);

        public abstract void ActualizarDireccion(string nuevaDireccion);
    }
}
