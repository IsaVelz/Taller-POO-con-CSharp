using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

public class FacturaUI
{
    private FacturaService _facturaService;

    // Constructor: Recibe una instancia del servicio FacturaService, que es la dependencia inyectada para manejar las operaciones de facturas.
    // Encapsulación: El servicio _facturaService está encapsulado como privado y es accedido solamente dentro de esta clase.
    public FacturaUI(FacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    // Método principal que presenta el menú de opciones para gestionar las facturas.
    // Interfaz: Permite al usuario interactuar con la aplicación, eligiendo distintas opciones de gestión de facturas.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de facturas.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menú de Gestión de Facturas:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Facturas");
            Console.WriteLine("2. Agregar Factura");
            Console.WriteLine("3. Actualizar Factura");
            Console.WriteLine("4. Eliminar Factura");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para manejar las diferentes opciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarFacturas();
                    break;
                case "2":
                    AgregarFactura();
                    break;
                case "3":
                    ActualizarFactura();
                    break;
                case "4":
                    EliminarFactura();
                    break;
                case "5":
                    continuar = false;  // Sale del menú.
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (continuar);
    }

    // Método para agregar una nueva factura.
    // Interfaz: Solicita los datos de la factura al usuario y los valida antes de crear una instancia de FacturaDatos.
    private void AgregarFactura()
    {
        try
        {
            // Solicitud de los datos necesarios para crear la factura.
            Console.WriteLine("Ingrese el número de la factura:");
            if (!long.TryParse(Console.ReadLine(), out long numero))
            {
                Console.WriteLine("Número de factura inválido. Por favor, ingrese un número válido.");
                return;
            }

            Console.WriteLine("Ingrese la fecha de la factura (formato YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida. Por favor, use el formato correcto YYYY-MM-DD.");
                return;
            }

            Console.WriteLine("Ingrese el total de la factura:");
            if (!double.TryParse(Console.ReadLine(), out double total))
            {
                Console.WriteLine("Total inválido. Por favor, ingrese un número válido.");
                return;
            }

            Console.WriteLine("Ingrese el ID de la persona asociada a la factura:");
            if (!int.TryParse(Console.ReadLine(), out int personaId))
            {
                Console.WriteLine("ID de persona inválido. Por favor, ingrese un número entero.");
                return;
            }

            // Verificación de la existencia de la persona asociada.
            var persona = _facturaService.ObtenerPersonaPorId(personaId);
            if (persona == null)
            {
                Console.WriteLine("No se encontró la persona con el ID proporcionado.");
                return;
            }

             // Creación de la instancia de FacturaDatos con los datos proporcionados.
            FacturaDatos nuevaFactura = new FacturaDatos
            {
                Numero = numero,
                Fecha = fecha,
                Total = total,
                PersonaId = personaId,
                Persona = persona,
                ProductosPorFactura = new List<ProductosPorFacturaDatos>() // Asegura que la lista esté inicializada
            };

            // Llama al servicio para agregar la factura.
            _facturaService.AgregarFactura(nuevaFactura);
            Console.WriteLine("Factura agregada con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error en caso de una excepción.
            Console.WriteLine($"Error al agregar la factura: {ex.Message}");
        }
    }

    // Método para listar todas las facturas.
    // Interfaz: Interactúa con el servicio para mostrar al usuario la lista de facturas.
    private void ListarFacturas()
    {
        _facturaService.ListarFacturas();
    }

    // Método para actualizar una factura existente.
    // Interfaz: Solicita los nuevos datos de la factura al usuario y los pasa al servicio para actualizar.
    private void ActualizarFactura()
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la factura a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo número de la factura:");
            if (!long.TryParse(Console.ReadLine(), out long numero))
            {
                Console.WriteLine("Número de factura inválido. Por favor, ingrese un número válido.");
                return;
            }

            Console.WriteLine("Ingrese la nueva fecha de la factura (formato YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida. Por favor, use el formato correcto YYYY-MM-DD.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo total de la factura:");
            if (!double.TryParse(Console.ReadLine(), out double total))
            {
                Console.WriteLine("Total inválido. Por favor, ingrese un número válido.");
                return;
            }

            Console.WriteLine("Ingrese el nuevo ID de la persona asociada a la factura:");
            if (!int.TryParse(Console.ReadLine(), out int personaId))
            {
                Console.WriteLine("ID de persona inválido. Por favor, ingrese un número entero.");
                return;
            }

            // Verificación de la existencia de la persona asociada.
            var persona = _facturaService.ObtenerPersonaPorId(personaId);
            if (persona == null)
            {
                Console.WriteLine("No se encontró la persona con el ID proporcionado.");
                return;
            }

            // Creación de la instancia de FacturaDatos actualizada.
            FacturaDatos facturaActualizada = new FacturaDatos
            {
                Numero = numero,
                Fecha = fecha,
                Total = total,
                PersonaId = personaId,
                Persona = persona,
                ProductosPorFactura = new List<ProductosPorFacturaDatos>() // Inicializa aunque esté vacía
            };

            // Llama al servicio para actualizar la factura.
            _facturaService.ActualizarFactura(id, facturaActualizada);
            Console.WriteLine("Factura actualizada con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura y muestra el mensaje de error.
            Console.WriteLine($"Error al actualizar la factura: {ex.Message}");
        }
    }

    // Método para eliminar una factura.
    // Interfaz: Solicita el ID de la factura a eliminar y lo pasa al servicio para su eliminación.
    private void EliminarFactura()
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la factura a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }

            // Llama al servicio para eliminar la factura.
            _facturaService.EliminarFactura(id);
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error si ocurre una excepción.
            Console.WriteLine($"Error al eliminar la factura: {ex.Message}");
        }
    }

}
