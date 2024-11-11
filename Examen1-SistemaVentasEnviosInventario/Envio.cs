using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public abstract class Envio
    {
        protected string NumeroEnvio { get; set; }
        protected string Destinatario { get; set; }
        protected string Direccion { get; set; }
        protected string EstadoEnvio { get; set; }

        public string GetNumeroEnvio()
        {
            return NumeroEnvio;
        }

        public string GetDestinatario()
        {
            return Destinatario;
        }

        public string GetDireccion()
        {
            return Direccion;
        }

        public string GetEstado()
        {
            return EstadoEnvio;
        }

        public void ActualizarEstado(string nuevoEstado)
        {
            EstadoEnvio = nuevoEstado;
        }

        protected Envio(string numeroEnvio, string destinatario, string direccion, string estadoEnvio)
        {
            NumeroEnvio = numeroEnvio;
            Destinatario = destinatario;
            Direccion = direccion;
            EstadoEnvio = estadoEnvio;
        }

        public abstract void MostrarDetalles();
    }
}
