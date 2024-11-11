using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Inventario
    {
        private List<Producto> ListaProductos;

        public List<Producto> GetListaProductos()
        {
            return ListaProductos;
        }

        public void SetListaProductos(List<Producto> value)
        {
            ListaProductos = value;
        }

        public Inventario(List<Producto> listaProductos)
        {
            this.ListaProductos = listaProductos;
        }
        public Inventario()
        {
            ListaProductos = new List<Producto>();
        }
        public void AgregarProducto(Producto producto)
        {
            this.ListaProductos.Add(producto);
        }

        public void ActualizarProducto(string nombre, double nuevoPrecio, int nuevaCantidad)
        {
            try
            {
                var producto = ListaProductos.FirstOrDefault(p => p.GetNombre() == nombre);
                if (producto != null)
                {
                    producto.SetPrecio(nuevoPrecio);
                    producto.SetCantidadDisponible(nuevaCantidad);
                    Console.WriteLine("Producto actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado en el inventario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al intentar actualizar el producto: {ex.Message}");
            }
        }

        public void EliminarProducto(string nombre)
        {
            try
            {
                var producto = ListaProductos.FirstOrDefault(p => p.GetNombre() == nombre);
                if (producto != null)
                {
                    ListaProductos.Remove(producto);
                    Console.WriteLine("Producto eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado en el inventario.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al intentar eliminar el producto: {ex.Message}");
            }
        }
        
        public Producto ConsultarProducto(string nombre)
        {
            var producto = ListaProductos.FirstOrDefault(p => p.GetNombre() == nombre);
            if (producto == null)
            {
                throw new Exception("Producto no encontrado en el inventario");
            }
            return producto;
        }

        public void MostrarInventario()
        {
            foreach (var producto in ListaProductos)
            {
                Console.WriteLine($"Producto: {producto.GetNombre()}, Precio: {producto.GetPrecio()}, Cantidad: {producto.GetCantidadDisponible()}");
            }
        }
    }
}
