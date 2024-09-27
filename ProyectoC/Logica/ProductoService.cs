using ProyectoC.AccesoDatos;
using System;
using System.Linq;

namespace ProyectoC.Logica
{
    public class ProductoService
    {
        private MiContextoDeDatos _contexto;

        // Constructor: Inicializa el servicio de producto con una instancia de MiContextoDeDatos, 
        // que maneja el acceso a la base de datos.
        public ProductoService(MiContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Método para agregar un nuevo producto.
        // Responsabilidad: Agregar una nueva instancia de ProductoDatos a la base de datos.
        // Se maneja el control de errores para capturar posibles excepciones en la operación de guardado.
        public void AgregarProducto(ProductoDatos nuevoProducto)
        {
            try
            {
                _contexto.Productos.Add(nuevoProducto);     // Agrega el nuevo producto al contexto.
                _contexto.SaveChanges();                    // Guarda los cambios en la base de datos.
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra el mensaje de error.
                Console.WriteLine($"Error al agregar el producto: {ex.Message}");
            }
        }

        // Método para obtener un producto por su ID.
        // Responsabilidad: Buscar un producto en la base de datos por su ID.
        public ProductoDatos? ObtenerProductoPorId(int id)
        {
            return _contexto.Productos.Find(id);    // Busca el producto por su ID.
        }

        // Método para listar todos los productos.
        // Responsabilidad: Recuperar todos los productos de la base de datos y mostrarlos en la consola.
        public void ListarProductos()
        {
            try
            {
                var productos = _contexto.Productos.ToList();   // Recupera la lista de productos.
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Lista de Productos:");
                Console.WriteLine("------------------------------------------------------");
                foreach (var producto in productos)
                {
                    // Muestra los detalles de cada producto.
                    Console.WriteLine($"ID: {producto.ProductoId}, Código: {producto.Codigo}, Nombre: {producto.Nombre}, Stock: {producto.Stock}, Valor Unitario: {producto.ValorUnitario}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al listar los productos: {ex.Message}");
            }
        }

        // Método para actualizar un producto existente.
        // Responsabilidad: Buscar un producto por su ID y actualizar sus detalles en la base de datos.
        public void ActualizarProducto(int id, ProductoDatos productoActualizado)
        {
            try
            {
                var producto = _contexto.Productos.Find(id);         // Busca el producto por su ID.
                if (producto == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    return;         // Finaliza si el producto no se encuentra.
                }

                // Actualiza los detalles del producto con los nuevos datos proporcionados.                
                producto.Codigo = productoActualizado.Codigo;
                producto.Nombre = productoActualizado.Nombre;
                producto.Stock = productoActualizado.Stock;
                producto.ValorUnitario = productoActualizado.ValorUnitario;

                _contexto.SaveChanges();        // Guarda los cambios en la base de datos.
                Console.WriteLine("Producto actualizado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
            }
        }

        // Método para eliminar un producto.
        // Responsabilidad: Buscar un producto por su ID y eliminarlo de la base de datos.
        public void EliminarProducto(int id)
        {
            try
            {
                var producto = _contexto.Productos.Find(id);        // Busca el producto por su ID.
                if (producto == null)
                {
                    Console.WriteLine("Producto no encontrado.");
                    return;                                 // Finaliza si el producto no se encuentra.
                }

                _contexto.Productos.Remove(producto);       // Elimina el producto del contexto.
                _contexto.SaveChanges();                    // Guarda los cambios en la base de datos.
                Console.WriteLine("Producto eliminado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
            }
        }
    }
}
