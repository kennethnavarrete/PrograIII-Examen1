using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Empleado
    {
        private string Puesto { get; set; }
        private string NombreEmpleado { get; set; }

        public Empleado(string nombre, string puesto)
        {
            this.Puesto = puesto;
            this.NombreEmpleado = nombre;
        }
        
        public void ActualizarPuesto(string nuevoPuesto)
        {
            Puesto = nuevoPuesto;
        }

    }
}
