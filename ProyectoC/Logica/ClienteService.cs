using ProyectoC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoC.Logica
{
    public class ClienteService
    {
        private MiContextoDeDatos _contexto;

        // Constructor: Inicializa el servicio de cliente con una instancia de MiContextoDeDatos para acceder a la base de datos.
        // Encapsulación: El contexto _contexto está encapsulado como privado y solo se accede desde los métodos del servicio.
        public ClienteService(MiContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Método para crear un nuevo cliente.
        // Responsabilidad: Agregar un nuevo cliente a la base de datos.
        // Se maneja el control de errores para capturar posibles excepciones en la operación de guardado.
        public void AgregarCliente(ClienteDatos cliente)
        {
            try
            {
                _contexto.Clientes.Add(cliente);    // Agrega el cliente al contexto.
                _contexto.SaveChanges();            // Guarda los cambios en la base de datos.
                Console.WriteLine("---------------------------");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura excepciones y muestra mensajes de error detallados, incluyendo errores internos.
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Error interno: {ex.InnerException.Message}");
                }
                Console.WriteLine($"Error al agregar el cliente: {ex.Message}");
            }
        }

        // Método para obtener y listar todos los clientes.
        // Responsabilidad: Recuperar todos los clientes de la base de datos y mostrarlos en la consola.
        public void ListarClientes()
        {
            try
            {
                var clientes = _contexto.Clientes.ToList();     // Obtiene todos los clientes de la base de datos. 
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Lista de Clientes:");
                Console.WriteLine("------------------------------------------------------");
                foreach (var cliente in clientes)
                {
                    // Muestra los detalles de cada cliente.
                    Console.WriteLine($"ID: {cliente.PersonaId}, Código: {cliente.Codigo}, Nombre: {cliente.Nombre}, Email: {cliente.Email}, Teléfono: {cliente.Telefono}, Crédito: {cliente.Credito}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura excepciones y muestra un mensaje de error.
                Console.WriteLine($"Error al listar los clientes: {ex.Message}");
            }
        }

        // Método para actualizar un cliente existente.
        // Responsabilidad: Buscar un cliente por su ID y actualizar sus detalles en la base de datos.
        public void ActualizarCliente(int id, ClienteDatos clienteActualizado)
        {
            try
            {
                var cliente = _contexto.Clientes.Find(id);       // Busca el cliente por su ID.
                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;                 // Finaliza si el cliente no se encuentra.
                }
                // Actualiza los detalles del cliente con los nuevos datos proporcionados.
                cliente.Codigo = clienteActualizado.Codigo;
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Email = clienteActualizado.Email;
                cliente.Telefono = clienteActualizado.Telefono;
                cliente.Credito = clienteActualizado.Credito;

                _contexto.SaveChanges();    // Guarda los cambios en la base de datos.
                Console.WriteLine("---------------------------");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura excepciones y muestra un mensaje de error.
                Console.WriteLine($"Error al actualizar el cliente: {ex.Message}");
            }
        }

        // Método para eliminar un cliente.
        // Responsabilidad: Buscar un cliente por su ID y eliminarlo de la base de datos.
        public void EliminarCliente(int id)
        {
            try
            {
                var cliente = _contexto.Clientes.Find(id);  // Busca el cliente por su ID.
                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;                                 // Finaliza si el cliente no se encuentra.
                }

                _contexto.Clientes.Remove(cliente);         // Elimina el cliente del contexto.
                _contexto.SaveChanges();                    // Guarda los cambios en la base de datos.
                Console.WriteLine("Cliente eliminado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura excepciones y muestra un mensaje de error.
                Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
            }
        }
    }
}
