using Examen1_SistemaVentasEnviosInventario;
using System;
using System.Collections.Generic;

public class Program
{
    static SistemaLogistica sistemaLogistica = new SistemaLogistica();
    static Inventario inventario = new Inventario(new List<Producto>());
    static List<Venta> ventas = new List<Venta>();

    public static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Gestión de Ventas e Inventario ===");
            Console.WriteLine("1. Gestión de Productos");
            Console.WriteLine("2. Gestión de Ventas");
            Console.WriteLine("3. Gestión de Envíos");
            Console.WriteLine("4. Mostrar Inventario");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    MenuGestionProductos();
                    break;
                case "2":
                    MenuGestionVentas();
                    break;
                case "3":
                    MenuGestionEnvios();
                    break;
                case "4":
                    inventario.MostrarInventario();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione cualquier tecla para intentar de nuevo.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void MenuGestionProductos()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Productos ===");
        Console.WriteLine("1. Agregar Producto");
        Console.WriteLine("2. Actualizar Producto");
        Console.WriteLine("3. Eliminar Producto");
        Console.WriteLine("4. Ver Todos los Productos");
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                AgregarProducto();
                break;
            case "2":
                ActualizarProducto();
                break;
            case "3":
                EliminarProducto();
                break;
            case "4":
                inventario.MostrarInventario();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarProducto()
    {
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el precio del producto: ");
        double precio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la cantidad disponible: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Console.Write("¿Es perecedero? (s/n): ");
        bool esPerecedero = Console.ReadLine().ToLower() == "s";

        Producto producto = new Producto(nombre, precio, cantidad, esPerecedero);
        inventario.AgregarProducto(producto);

        Console.WriteLine("Producto agregado correctamente.");
    }

    static void ActualizarProducto()
    {
        Console.Write("Ingrese el nombre del producto a actualizar: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el nuevo precio: ");
        double nuevoPrecio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la nueva cantidad disponible: ");
        int nuevaCantidad = Convert.ToInt32(Console.ReadLine());

        inventario.ActualizarProducto(nombre, nuevoPrecio, nuevaCantidad);
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el nombre del producto a eliminar: ");
        string nombre = Console.ReadLine();

        inventario.EliminarProducto(nombre);
    }

    static void MenuGestionVentas()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Ventas ===");
        Console.WriteLine("1. Crear Venta");
        Console.WriteLine("2. Mostrar Ventas");
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                CrearVenta();
                break;
            case "2":
                MostrarVentas();
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void CrearVenta()
    {

        Console.Write("Ingrese el nombre del empleado: ");
        string nombreEmpleado = Console.ReadLine();
        Console.Write("Ingrese el puesto del empleado: ");
        string puestoEmpleado = Console.ReadLine();
        Empleado nuevoEmpleado = new Empleado(nombreEmpleado, puestoEmpleado);

        Console.Write("Ingrese el nombre del cliente: ");
        Cliente nuevoCliente = IngresarInformacionCliente();

        Console.Write("Ingrese el número de la venta: ");
        string numeroVenta = Console.ReadLine();
        string estadoVenta = "Pendiente";
        double totalVenta = 0.0;
        List<DetalleVenta> detalles = new List<DetalleVenta>();

        bool agregarProductos = true;
        while (agregarProductos)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Ingrese la cantidad: ");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.Write("Cantidad inválida. Ingrese un número entero positivo: ");
            }

            try
            {
                Producto producto = inventario.ConsultarProducto(nombreProducto);
                DetalleVenta detalle = new DetalleVenta(producto, cantidad, producto.GetPrecio());
                detalles.Add(detalle);
                totalVenta += detalle.GetSubTotal();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. No se pudo agregar el producto.");
            }
            Console.Write("¿Desea agregar otro producto a la venta? (s/n): ");
            agregarProductos = Console.ReadLine().ToLower() == "s";
        }
        // Venta(List<DetalleVenta> detalles, DateTime fechaVenta, Cliente cliente, Empleado empleado, string numeroVenta, string estadoVenta, double totalVenta, Envio envio)
        Venta venta = new Venta(detalles, DateTime.Now, nuevoCliente, nuevoEmpleado, numeroVenta, estadoVenta, totalVenta, null);

        ventas.Add(venta);
        Console.WriteLine("Venta creada correctamente.");
    }

    static void MostrarVentas()
    {
        foreach (var venta in ventas)
        {
            Console.WriteLine($"Número de Venta: {venta.GetNumeroVenta()}, Total: {venta.GetTotalVenta()}, Cliente: {venta.GetCliente().GetNombre()}");
        }
    }

    static void MenuGestionEnvios()
    {
        Console.Clear();
        Console.WriteLine("=== Gestión de Envíos ===");
        Console.WriteLine("1. Agregar Envío");
        Console.WriteLine("2. Actualizar Estado de Envío");
        Console.WriteLine("3. Mostrar Todos los Envíos");
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                AgregarEnvio();
                break;
            case "2":
                ActualizarEstadoEnvio();
                break;
            case "3":
                sistemaLogistica.MostrarTodosLosEnvios();
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarEnvio()
    {
        Console.Write("Ingrese el número de envío: ");
        string numeroEnvio = Console.ReadLine();

        Console.Write("Ingrese el nombre del destinatario: ");
        string destinatario = Console.ReadLine();

        Console.Write("Ingrese la dirección del destinatario: ");
        string direccion = Console.ReadLine();

        Console.Write("Tipo de envío (1: Aéreo, 2: Terrestre): ");
        string tipoEnvio = Console.ReadLine();

        if (tipoEnvio == "1")
        {
            Console.Write("Ingrese el número de vuelo: ");
            string numeroVuelo = Console.ReadLine();

            Console.Write("Ingrese el peso: ");
            double peso = Convert.ToDouble(Console.ReadLine());

            Envio envio = new EnvioAereo(numeroEnvio, destinatario, direccion, numeroVuelo, peso);
            sistemaLogistica.AgregarEnvio(envio);
        }
        else if (tipoEnvio == "2")
        {
            Console.Write("Ingrese el número de camión: ");
            string numeroCamion = Console.ReadLine();

            Envio envio = new EnvioTerrestre(numeroEnvio, destinatario, direccion, numeroCamion);
            sistemaLogistica.AgregarEnvio(envio);
        }
        else
        {
            Console.WriteLine("Tipo de envío inválido.");
        }
    }

    static void ActualizarEstadoEnvio()
    {
        Console.Write("Ingrese el número de envío: ");
        string numeroEnvio = Console.ReadLine();

        Console.Write("Ingrese el nuevo estado: ");
        string nuevoEstado = Console.ReadLine();

        sistemaLogistica.ActualizarEstadoEnvio(numeroEnvio, nuevoEstado);
    }

    public static Cliente IngresarInformacionCliente()
    {
        Console.WriteLine("=== Registro de Cliente ===");

        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la información de contacto (por ejemplo, email o teléfono): ");
        string informacionContacto = Console.ReadLine();

        Console.Write("Ingrese la dirección del cliente: ");
        string direccion = Console.ReadLine();

        Console.Write("Ingrese las preferencias del cliente (o deje en blanco si no tiene): ");
        string preferencias = Console.ReadLine();
        if (string.IsNullOrEmpty(preferencias))
        {
            preferencias = "Sin preferencias";
        }

        List<DetalleVenta> historialCompras = new List<DetalleVenta>();

        Cliente cliente = new Cliente(nombre, informacionContacto, direccion, preferencias, historialCompras);
        return cliente;
    }
}

