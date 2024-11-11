using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Producto
    {
        private string Nombre;
        private double Precio;
        private int CantidadDisponible;
        private bool EsPerecedero;

        public string GetNombre()
        {
            return Nombre;
        }

        public void SetNombre(string nuevoNombre)
        {
            Nombre = nuevoNombre;
        }

        public double GetPrecio()
        {
            return Precio;
        }

        public void SetPrecio(double nuevoPrecio)
        {
            if (nuevoPrecio >= 0)
                Precio = nuevoPrecio;
        }

        public int GetCantidadDisponible()
        {
            return CantidadDisponible;
        }

        public void SetCantidadDisponible(int nuevaCantidad)
        {
            if (nuevaCantidad >= 0)
                CantidadDisponible = nuevaCantidad;
        }

        public bool GetEsPerecedero()
        {
            return EsPerecedero;
        }

        public void SetEsPerecedero(bool perecedero)
        {
            EsPerecedero = perecedero;
        }
        public Producto(string nombre, double precio, int cantidadDisponible, bool esPerecedero)
        {
            this.Nombre = nombre;
            this.Precio = precio >= 0 ? precio : 0;
            this.CantidadDisponible = cantidadDisponible >= 0 ? cantidadDisponible : 0;
            this.EsPerecedero = esPerecedero;
        }
    }
}
