using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Examen1_SistemaVentasEnviosInventario
{
    public class Usuario
    {
        private string NombreUsuario {  get; set; }
        private string Password;
        private string Rol { get; set; }
        private Empleado EmpleadoAsociado { get; set; }

        public Usuario(string nombreUsuario, string password, string rol, Empleado empleadoAsociado)
        {
            NombreUsuario = nombreUsuario;
            Password = password;
            Rol = rol;
            EmpleadoAsociado = empleadoAsociado;
        }
        //PENDIENTE TERMINAR LÓGICA DE INICIO, CIERRE SESION Y ROL
        public void IniciarSesion ()
        {
            Console.WriteLine($"Bienvenido {NombreUsuario}.");
        }

        public void CerrarSesion ()
        {
            Console.WriteLine($"{NombreUsuario} ha cerrado sesión.");
        }

        public string ObtenerRol()
        {
            return Rol;
        }
    }
}
