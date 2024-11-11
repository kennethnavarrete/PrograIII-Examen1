using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Venta
    {
        private List<DetalleVenta> Detalles;
        private DateTime FechaVenta;
        private Cliente Cliente;
        private Empleado Empleado;
        private string NumeroVenta;
        private string EstadoVenta;
        private double TotalVenta;
        private Envio Envio;

        public List<DetalleVenta> GetDetalle()
        {
            return Detalles;
        }

        public void SetDetalle(List<DetalleVenta> value)
        {
            Detalles = value;
        }
        public DateTime GetFechaVenta()
        {
            return FechaVenta;
        }

        public void SetFechaVenta(DateTime value)
        {
            FechaVenta = value;
        }
        public Cliente GetCliente()
        {
            return Cliente;
        }

        public void SetCliente(Cliente value)
        {
            Cliente = value;
        }

        public Empleado GetEmpleado()
        {
            return Empleado;
        }

        public void SetEmpleado(Empleado value)
        {
            Empleado = value;
        }

        public string GetNumeroVenta()
        {
            return NumeroVenta;
        }

        public void SetNumeroVenta(string value)
        {
            NumeroVenta = value;
        }

        public string GetEstadoVenta()
        {
            return EstadoVenta;
        }

        public void SetEstadoVenta(string value)
        {
            EstadoVenta = value;
        }

        public double GetTotalVenta()
        {
            return TotalVenta;
        }

        public void SetTotalVenta(double value)
        {
            TotalVenta = value;
        }

        public Envio GetEnvio()
        {
            return Envio;
        }

        public void SetEnvio(Envio value)
        {
            Envio = value;
        }

        public Venta(List<DetalleVenta> detalles, DateTime fechaVenta, Cliente cliente, Empleado empleado, string numeroVenta, string estadoVenta, double totalVenta, Envio envio)
        {
            this.Detalles = detalles;
            this.FechaVenta = fechaVenta;
            this.Cliente = cliente;
            this.Empleado = empleado;
            this.NumeroVenta = numeroVenta;
            this.EstadoVenta = estadoVenta;
            this.TotalVenta = totalVenta;
            this.Envio = envio;
            Detalles = new List<DetalleVenta>();
        }
        public void AsignarEnvio(Envio envio)
        {
            this.Envio = envio;
            Console.WriteLine("Envío asignado a la venta.");
        }

        public void AgregarDetalle(DetalleVenta detalle)
        {
            Detalles.Add(detalle);
            ActualizarTotalVenta();
        }

        private void ActualizarTotalVenta()
        {
            TotalVenta = 0;
            foreach (var detalle in Detalles)
            {
                TotalVenta += detalle.GetSubTotal();
            }
        }

    }
}
