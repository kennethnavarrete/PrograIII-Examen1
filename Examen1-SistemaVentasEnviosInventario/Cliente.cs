using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Cliente : Persona
    {


        private List<DetalleVenta> HistorialCompras { get; set; }
        private string Preferencias { get; set; }


        public Cliente(string nombre, string informacionContacto, string direccion, string preferencias, List<DetalleVenta> historialCompras) : base(nombre, informacionContacto, direccion)
        {
            HistorialCompras = historialCompras;
            Preferencias = preferencias;

        }

        public void ConsultarHistorialCompras ()
        {
            foreach (var detalle in HistorialCompras)
            {
                Console.WriteLine($"Producto: {detalle.GetProducto().GetNombre()}, Cantidad: {detalle.GetCantidad()}, Precio Unitario: {detalle.GetPrecioUnitario()}");
            }

        }
        public override void ActualizarDireccion(string nuevaDireccion)
        {
            SetDireccion (nuevaDireccion);
        }

        public override void ActualizarInfoContacto(string nuevaInformacionContacto)
        {
            SetInformacionContacto (nuevaInformacionContacto);
        }
    }
}
