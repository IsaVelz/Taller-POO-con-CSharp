using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

public class ClienteUI
{
    private ClienteService _clienteService;

    // Constructor: Recibe un servicio de cliente (ClienteService), que es parte de la capa lógica.
    // Encapsulación: El servicio _clienteService está encapsulado como privado y accedido solo dentro de esta clase.
    public ClienteUI(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    // Método principal que ofrece un menú para la gestión de clientes.
    // Interacción con el usuario: Este método utiliza la consola para recibir la entrada del usuario y mostrar opciones.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de clientes.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menú de Gestión de Clientes:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Agregar Cliente");
            Console.WriteLine("3. Actualizar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control (switch) para gestionar las acciones según la opción del usuario.
            switch (opcion)
            {
                case "1":
                    ListarClientes();
                    break;
                case "2":
                    AgregarCliente();
                    break;
                case "3":
                    ActualizarCliente();
                    break;
                case "4":
                    EliminarCliente();
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

    // Método para agregar un cliente.
    // Valida la entrada del usuario y crea un objeto ClienteDatos que luego es pasado al servicio.
    private void AgregarCliente()
    {
        try
        {
            // Solicitud de datos del cliente al usuario.
            Console.WriteLine("Ingrese el código del cliente:");
            string? codigo = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del cliente:");
            string? nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el email del cliente:");
            string? email = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono del cliente:");
            string? telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el crédito del cliente:");
            double credito = Convert.ToDouble(Console.ReadLine());

            // Creación de un nuevo ClienteDatos asegurando que todas las propiedades requeridas están inicializadas
            ClienteDatos nuevoCliente = new ClienteDatos
            {
                Codigo = codigo!,
                Nombre = nombre!,
                Email = email!,
                Telefono = telefono!,
                Credito = credito,
                Facturas = new List<FacturaDatos>()  // Asegurando que la lista de Facturas está inicializada
            };

            // Uso del servicio para agregar el cliente a través del método AgregarCliente.
            _clienteService.AgregarCliente(nuevoCliente);
            Console.WriteLine("Cliente agregado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra el mensaje de error
            Console.WriteLine($"Error al agregar el cliente: {ex.Message}");
        }
    }

    // Método para listar clientes.
    // Se encarga de solicitar al servicio la lista de clientes y mostrarla al usuario
    private void ListarClientes()
    {
        _clienteService.ListarClientes();   // Invoca el método para listar clientes desde el servicio.
    }

    // Método para actualizar un cliente.
    // Solicita nuevos datos del cliente y los actualiza mediante el servicio.
    private void ActualizarCliente()
    {
        try
        {
            Console.WriteLine("Ingrese el ID del cliente a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("ID inválido, debe ser un número entero.");
            }

            Console.WriteLine("Ingrese el nuevo código del cliente:");
            string? codigo = Console.ReadLine();
            if (string.IsNullOrEmpty(codigo))
            {
                throw new ArgumentException("El código no puede estar vacío.");
            }

            Console.WriteLine("Ingrese el nuevo nombre del cliente:");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            Console.WriteLine("Ingrese el nuevo email del cliente:");
            string? email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }

            Console.WriteLine("Ingrese el nuevo teléfono del cliente:");
            string? telefono = Console.ReadLine();
            if (string.IsNullOrEmpty(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }

            Console.WriteLine("Ingrese el nuevo crédito del cliente:");
            if (!double.TryParse(Console.ReadLine(), out double credito))
            {
                throw new ArgumentException("Crédito inválido, debe ser un número.");
            }

            // Creación de un objeto ClienteDatos con los nuevos datos ingresados.
            ClienteDatos clienteActualizado = new ClienteDatos
            {
                Codigo = codigo!,
                Nombre = nombre!,
                Email = email!,
                Telefono = telefono!,
                Credito = credito,
                Facturas = new List<FacturaDatos>() // Asegura que la lista de facturas está inicializada
            };

            // Uso del servicio para actualizar el cliente.
            _clienteService.ActualizarCliente(id, clienteActualizado);
            Console.WriteLine("Cliente actualizado con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra el mensaje de error.
            Console.WriteLine($"Error al actualizar el cliente: {ex.Message}");
        }
    }

    // Método para eliminar un cliente.
    // Solicita el ID del cliente y lo elimina a través del servicio.
    private void EliminarCliente()
    {
        Console.WriteLine("Ingrese el ID del cliente a eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());
        _clienteService.EliminarCliente(id);    // Invoca el servicio para eliminar el cliente.
    }
}
