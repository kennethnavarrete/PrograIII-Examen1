using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class DetalleVenta
    {
        private Producto Producto;
        private int Cantidad;
        private double PrecioUnitario;
        private double SubTotal;

        public Producto GetProducto()
        {
            return Producto;
        }

        public void SetProducto(Producto producto)
        {
            Producto = producto;
        }
        public int GetCantidad()
        {
            return Cantidad;
        }

        public void SetCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }
        public double GetPrecioUnitario()
        {
            return PrecioUnitario;
        }

        public void SetPrecioUnitario(double precioUnitario)
        {
            PrecioUnitario = precioUnitario;
        }

        public double GetSubTotal()
        {
            return this.Cantidad * this.PrecioUnitario;
        }

        public DetalleVenta(Producto producto, int cantidad, double precioUnitario)
        {
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

    }
}
