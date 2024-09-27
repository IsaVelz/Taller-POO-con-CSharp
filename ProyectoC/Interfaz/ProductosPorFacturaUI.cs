using ProyectoC.AccesoDatos;
using System;

public class ProductosPorFacturaUI
{
    private ProductosPorFacturaService _productosPorFacturaService;

    // Constructor: Recibe una instancia del servicio ProductosPorFacturaService, que maneja la lógica de negocio.
    // Encapsulación: El servicio _productosPorFacturaService está encapsulado como privado y solo es accesible dentro de esta clase.
    public ProductosPorFacturaUI(ProductosPorFacturaService productosPorFacturaService)
    {
        _productosPorFacturaService = productosPorFacturaService;
    }

    // Método principal que presenta el menú de opciones para la gestión de productos por factura.
    // Interfaz: Permite al usuario interactuar con la aplicación para agregar productos a facturas o salir.
    public void MenuPrincipal()
    {
        bool continuar = true;
        while (continuar)
        {
            // Menú principal para la gestión de productos por factura.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Gestión de Productos por Factura");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Agregar producto a factura");
            Console.WriteLine("2. Salir");
            Console.Write("Ingrese su elección: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para manejar las opciones del menú.
            switch (opcion)
            {
                case "1":
                    AgregarProductoAFactura();
                    break;
                case "2":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    // Método para agregar un producto a una factura.
    // Interfaz: Solicita los datos necesarios (ID de factura, ID de producto y cantidad) y delega la lógica al servicio.
    public void AgregarProductoAFactura()
    {
        try
        {
            // Solicitud de datos para agregar el producto a la factura.
            Console.WriteLine("Ingrese el ID de la factura:");
            if (!int.TryParse(Console.ReadLine(), out int facturaId))
            {
                Console.WriteLine("ID de factura inválido. Por favor, ingrese un número entero.");
                return;
            }

            Console.WriteLine("Ingrese el ID del producto:");
            if (!int.TryParse(Console.ReadLine(), out int productoId))
            {
                Console.WriteLine("ID de producto inválido. Por favor, ingrese un número entero.");
                return;
            }

            Console.WriteLine("Ingrese la cantidad del producto:");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                Console.WriteLine("Cantidad inválida. Por favor, ingrese un número entero.");
                return;
            }

            // Uso del servicio para agregar el producto a la factura.
            _productosPorFacturaService.AgregarProductoAFactura(facturaId, productoId, cantidad);
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra un mensaje de error
            Console.WriteLine($"Error al agregar el producto a la factura: {ex.Message}");
        }
    }
}

