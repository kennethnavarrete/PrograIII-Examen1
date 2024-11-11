using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class SistemaLogistica
    {
        private List<Envio> Envios;

        public List<Envio> GetEnvios()
        {
            return Envios;
        }

        public void SetEnvios(List<Envio> value)
        {
            Envios = value;
        }
        public SistemaLogistica()
        {
            Envios = new List<Envio>();
        }

        public void AgregarEnvio(Envio envio)
        {
            if (Envios.Any(e => e.GetNumeroEnvio() == envio.GetNumeroEnvio()))
            {
                Console.WriteLine("Error: Ya existe un envío con el mismo número.");
            }
            else
            {
                Envios.Add(envio);
                Console.WriteLine("Envío agregado correctamente.");
            }
        }

        public Envio BuscarEnvio(string numeroEnvio)
        {
            var envio = Envios.FirstOrDefault(e => e.GetNumeroEnvio() == numeroEnvio);
            if (envio == null)
            {
                Console.WriteLine("Envío no encontrado.");
                throw new Exception("Envío no encontrado.");
            }
            return envio;
        }

        public void ActualizarEstadoEnvio(string numeroEnvio, string nuevoEstado)
        {
            try
            {
                var envio = BuscarEnvio(numeroEnvio);
                envio.ActualizarEstado(nuevoEstado);
                Console.WriteLine("Estado del envío actualizado a: " + nuevoEstado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void MostrarTodosLosEnvios()
        {
            try
            {
                if (Envios.Count == 0)
                {
                    Console.WriteLine("No hay envíos registrados.");
                }
                else
                {
                    foreach (var envio in Envios)
                    {
                        envio.MostrarDetalles();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al mostrar los envíos: " + ex.Message);
            }
        }
    }
}
