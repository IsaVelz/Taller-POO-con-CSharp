using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

public class ProductoUI
{
    private ProductoService _productoService;

    // Constructor: Recibe una instancia del servicio ProductoService, que maneja la lógica de negocio relacionada con productos.
    // Encapsulación: El servicio _productoService está encapsulado como privado y solo es accesible dentro de esta clase.
    public ProductoUI(ProductoService productoService)
    {
        _productoService = productoService;
    }

    // Método principal que presenta el menú de opciones para la gestión de productos.
    // Interfaz: Permite al usuario interactuar con la aplicación, eligiendo distintas opciones de gestión de productos.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de productos.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menú de Gestión de Productos:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Productos");
            Console.WriteLine("2. Agregar Producto");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para manejar las opciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarProductos();
                    break;
                case "2":
                    AgregarProducto();
                    break;
                case "3":
                    ActualizarProducto();
                    break;
                case "4":
                    EliminarProducto();
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

    // Método para agregar un nuevo producto.
    // Interfaz: Solicita los datos del nuevo producto al usuario y delega la creación al servicio.
    private void AgregarProducto()
    {
        try
        {
            // Solicitud de datos para el nuevo producto.
            Console.WriteLine("Ingrese el código del producto:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nombre del producto:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el stock del producto:");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Stock inválido. Por favor, ingrese un número entero.");
                return;
            }
            Console.WriteLine("Ingrese el valor unitario del producto:");
            if (!double.TryParse(Console.ReadLine(), out double valorUnitario))
            {
                Console.WriteLine("Valor unitario inválido. Por favor, ingrese un número válido.");
                return;
            }

            // Creación de una nueva instancia de ProductoDatos con los datos proporcionados.
            ProductoDatos nuevoProducto = new ProductoDatos
            {
                Codigo = codigo,
                Nombre = nombre,
                Stock = stock,
                ValorUnitario = valorUnitario,
                ProductosPorFactura = new List<ProductosPorFacturaDatos>() // Inicialización de la lista
            };

            // Uso del servicio para agregar el nuevo producto.
            _productoService.AgregarProducto(nuevoProducto);
            Console.WriteLine("Producto agregado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error si ocurre una excepción.
            Console.WriteLine($"Error al agregar el producto: {ex.Message}");
        }
    }

    // Método para listar todos los productos.
    // Interfaz: Interactúa con el servicio para obtener y mostrar la lista de productos.
    private void ListarProductos()
    {
        _productoService.ListarProductos(); // Invoca el método del servicio para listar los productos.
    }

    // Método para actualizar un producto existente.
    // Interfaz: Solicita los datos actualizados al usuario y delega la actualización al servicio.
    private void ActualizarProducto()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del producto a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }

            // Verificación de la existencia del producto.
            var productoExistente = _productoService.ObtenerProductoPorId(id);
            if (productoExistente == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            // Solicitud de los nuevos datos del producto.
            Console.WriteLine("Ingrese el nuevo código del producto:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo nombre del producto:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingrese el nuevo stock del producto:");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Stock inválido. Por favor, ingrese un número entero.");
                return;
            }
            Console.WriteLine("Ingrese el nuevo valor unitario del producto:");
            if (!double.TryParse(Console.ReadLine(), out double valorUnitario))
            {
                Console.WriteLine("Valor unitario inválido. Por favor, ingrese un número válido.");
                return;
            }

            // Actualización de los valores del producto existente.
            productoExistente.Codigo = codigo;
            productoExistente.Nombre = nombre;
            productoExistente.Stock = stock;
            productoExistente.ValorUnitario = valorUnitario;

            // Uso del servicio para actualizar el producto.
            _productoService.ActualizarProducto(id, productoExistente);
            Console.WriteLine("Producto actualizado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Muestra el mensaje de error en caso de excepción.
            Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
        }
    }

    // Método para eliminar un producto existente.
    // Interfaz: Solicita el ID del producto a eliminar y delega la eliminación al servicio.
    private void EliminarProducto()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                return;
            }
            // Uso del servicio para eliminar el producto.
            _productoService.EliminarProducto(id);
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra un mensaje de error.
            Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
        }
    }
}
