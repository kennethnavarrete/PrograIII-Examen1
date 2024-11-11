using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class EnvioAereo : Envio
    {
        private string NumeroVuelo;
        private double Peso;

        public EnvioAereo(string numeroEnvio, string destinatario, string direccion, string numeroVuelo, double peso, string estado = "Pendiente")
        : base(numeroEnvio, destinatario, direccion, estado)
        {
            NumeroVuelo = numeroVuelo;
            Peso = peso;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Envío Aéreo - Número de Envío: {NumeroEnvio}, Destinatario: {Destinatario}, Dirección: {Direccion}, Estado: {EstadoEnvio}, Número de Vuelo: {NumeroVuelo}, Peso: {Peso}kg");
        }
    }
}
