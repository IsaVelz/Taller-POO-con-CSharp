using ProyectoC.AccesoDatos;
using System;
using System.Linq;

namespace ProyectoC.Logica
{
    public class VendedorService
    {
        private MiContextoDeDatos _contexto;

        // Constructor que asegura que el contexto no es nulo antes de asignarlo.
        // Encapsulación: El contexto _contexto está encapsulado como privado y se asegura que no sea nulo al asignarlo.
        public VendedorService(MiContextoDeDatos contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto), "El contexto de datos no puede ser nulo.");
        }

        // Método para agregar un nuevo vendedor.
        // Responsabilidad: Agregar una nueva instancia de VendedorDatos a la base de datos.
        // Se maneja el control de errores para capturar posibles excepciones en la operación de guardado.
        public void AgregarVendedor(VendedorDatos nuevoVendedor)
        {
            try
            {
                _contexto.Vendedores.Add(nuevoVendedor);     // Agrega el nuevo vendedor al contexto.
                _contexto.SaveChanges();                     // Guarda los cambios en la base de datos.
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra el mensaje de error.
                Console.WriteLine($"Error al agregar el vendedor: {ex.Message}");
            }
        }

        // Método para listar todos los vendedores.
        // Responsabilidad: Recuperar todos los vendedores de la base de datos y mostrarlos en la consola.
        public void ListarVendedores()
        {
            try
            {
                var vendedores = _contexto.Vendedores.ToList(); // Recupera la lista de vendedores.
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Lista de Vendedores:");
                Console.WriteLine("------------------------------------------------------");
                foreach (var vendedor in vendedores)
                {
                    // Muestra los detalles de cada vendedor.
                    Console.WriteLine($"ID: {vendedor.PersonaId}, Código: {vendedor.Codigo}, Nombre: {vendedor.Nombre}, Email: {vendedor.Email}, Teléfono: {vendedor.Telefono}, Carné: {vendedor.Carne}, Dirección: {vendedor.Direccion}");
                }
            }
            catch (Exception ex)
            {
                 // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al listar los vendedores: {ex.Message}");
            }
        }

        // Método para actualizar un vendedor existente.
        // Responsabilidad: Buscar un vendedor por su ID y actualizar sus detalles en la base de datos.
        public void ActualizarVendedor(int id, VendedorDatos vendedorActualizado)
        {
            try
            {
                var vendedor = _contexto.Vendedores.Find(id);   // Busca el vendedor por su ID.
                if (vendedor == null)
                {
                    Console.WriteLine("Vendedor no encontrado.");
                    return;     // Finaliza si el vendedor no se encuentra.
                }

                // Actualiza los detalles del vendedor con los nuevos datos proporcionados.
                vendedor.Codigo = vendedorActualizado.Codigo;
                vendedor.Codigo = vendedorActualizado.Codigo;
                vendedor.Nombre = vendedorActualizado.Nombre;
                vendedor.Email = vendedorActualizado.Email;
                vendedor.Telefono = vendedorActualizado.Telefono;
                vendedor.Carne = vendedorActualizado.Carne;
                vendedor.Direccion = vendedorActualizado.Direccion;

                _contexto.SaveChanges();                        // Guarda los cambios en la base de datos.
                Console.WriteLine("Vendedor actualizado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al actualizar el vendedor: {ex.Message}");
            }
        }

        // Método para eliminar un vendedor.
        // Responsabilidad: Buscar un vendedor por su ID y eliminarlo de la base de datos.
        public void EliminarVendedor(int id)
        {
            try
            {
                var vendedor = _contexto.Vendedores.Find(id);    // Busca el vendedor por su ID.
                if (vendedor == null)
                {
                    Console.WriteLine("Vendedor no encontrado.");
                    return;         // Finaliza si el vendedor no se encuentra.
                }

                _contexto.Vendedores.Remove(vendedor);       // Elimina el vendedor del contexto.
                _contexto.SaveChanges();                     // Guarda los cambios en la base de datos.
                Console.WriteLine("Vendedor eliminado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al eliminar el vendedor: {ex.Message}");
            }
        }
    }
}
