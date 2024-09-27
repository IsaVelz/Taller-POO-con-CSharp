using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

public class VendedorUI
{
    private VendedorService _vendedorService;

    // Constructor: Recibe una instancia de VendedorService, que maneja la lógica relacionada con la entidad Vendedor.
    // Encapsulación: El servicio _vendedorService está encapsulado como privado y solo es accesible dentro de esta clase.
    public VendedorUI(VendedorService vendedorService)
    {
        _vendedorService = vendedorService;
    }

    // Método principal que presenta el menú de opciones para la gestión de vendedores.
    // Interfaz: Permite al usuario interactuar con la aplicación y realizar operaciones relacionadas con vendedores.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de vendedores.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menú de Gestión de Vendedores:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Vendedores");
            Console.WriteLine("2. Agregar Vendedor");
            Console.WriteLine("3. Actualizar Vendedor");
            Console.WriteLine("4. Eliminar Vendedor");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para manejar las opciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarVendedores();
                    break;
                case "2":
                    AgregarVendedor();
                    break;
                case "3":
                    ActualizarVendedor();
                    break;
                case "4":
                    EliminarVendedor();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (continuar);
    }

    // Método para agregar un nuevo vendedor.
    // Interfaz: Solicita los datos del nuevo vendedor al usuario y delega la creación al servicio.
    private void AgregarVendedor()
    {
        try
        {
            // Solicitud de datos para el nuevo vendedor.
            Console.WriteLine("Ingrese el código del vendedor:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nombre del vendedor:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el email del vendedor:");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el teléfono del vendedor:");
            string telefono = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el carné del vendedor:");
            if (!int.TryParse(Console.ReadLine(), out int carne))
            {
                Console.WriteLine("Carné inválido. Por favor, ingrese un número entero.");
                return;
            }
            Console.WriteLine("Ingrese la dirección del vendedor:");
            string direccion = Console.ReadLine() ?? "";

            // Creación de una nueva instancia de VendedorDatos con los datos proporcionados.
            VendedorDatos nuevoVendedor = new VendedorDatos
            {
                Codigo = codigo,
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                Carne = carne,
                Direccion = direccion,
                Facturas = new List<FacturaDatos>()  // Inicializando la propiedad de navegación requerida
            };

            // Uso del servicio para agregar el nuevo vendedor.
            _vendedorService.AgregarVendedor(nuevoVendedor);
            Console.WriteLine("Vendedor agregado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error si ocurre una excepción.
            Console.WriteLine($"Error al agregar el vendedor: {ex.Message}");
        }
    }

    // Método para listar todos los vendedores.
    // Interfaz: Interactúa con el servicio para obtener y mostrar la lista de vendedores.
    private void ListarVendedores()
    {
        _vendedorService.ListarVendedores();    // Invoca el método del servicio para listar los vendedores.
    }

    // Método para actualizar un vendedor existente.
    // Interfaz: Solicita los datos actualizados al usuario y delega la actualización al servicio.
    private void ActualizarVendedor()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del vendedor a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }
            // Solicitud de los nuevos datos del vendedor.
            Console.WriteLine("Ingrese el nuevo código del vendedor:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo nombre del vendedor:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo email del vendedor:");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo teléfono del vendedor:");
            string telefono = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo carné del vendedor:");
            if (!int.TryParse(Console.ReadLine(), out int carne))
            {
                Console.WriteLine("Carné inválido. Por favor, ingrese un número entero.");
                return;
            }
            Console.WriteLine("Ingrese la nueva dirección del vendedor:");
            string direccion = Console.ReadLine() ?? "";

            // Creación de la instancia de VendedorDatos con los nuevos datos proporcionados.
            VendedorDatos vendedorActualizado = new VendedorDatos
            {
                PersonaId = id,
                Codigo = codigo,
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                Carne = carne,
                Direccion = direccion,
                Facturas = new List<FacturaDatos>() // Inicializando la propiedad de navegación requerida
            };

            // Uso del servicio para actualizar el vendedor.
            _vendedorService.ActualizarVendedor(id, vendedorActualizado);
            Console.WriteLine("Vendedor actualizado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error si ocurre una excepción.
            Console.WriteLine($"Error al actualizar el vendedor: {ex.Message}");
        }
    }

    // Método para eliminar un vendedor existente.
    // Interfaz: Solicita el ID del vendedor a eliminar y delega la eliminación al servicio.
    private void EliminarVendedor()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del vendedor a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }

            // Uso del servicio para eliminar el vendedor.
            _vendedorService.EliminarVendedor(id);
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra un mensaje de error.
            Console.WriteLine($"Error al eliminar el vendedor: {ex.Message}");
        }
    }
}
