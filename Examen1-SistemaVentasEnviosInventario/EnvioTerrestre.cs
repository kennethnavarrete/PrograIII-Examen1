using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class EnvioTerrestre : Envio
    {
        private string NumeroCamion;

        public EnvioTerrestre(string numeroEnvio, string destinatario, string direccion, string numeroCamion, string estado = "Pendiente")
            : base(numeroEnvio, destinatario, direccion, estado)
        {
            NumeroCamion = numeroCamion;
        }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Envío Terrestre - Número de Envío: {NumeroEnvio}, Destinatario: {Destinatario}, Dirección: {Direccion}, Estado: {EstadoEnvio}, Número de Camión: {NumeroCamion}");
        }
    }
}
