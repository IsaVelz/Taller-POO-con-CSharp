using ProyectoC.AccesoDatos;
using System;

public class ProductosPorFacturaService
{
    private MiContextoDeDatos _contexto;

    // Constructor que asegura que el contexto no es nulo antes de asignarlo.
    // Encapsulación: El contexto _contexto está encapsulado como privado y se asegura que no sea nulo.
    public ProductosPorFacturaService(MiContextoDeDatos contexto)
    {
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto), "El contexto de datos no puede ser nulo.");
    }

    // Método para agregar un producto a una factura.
    // Responsabilidad: Asociar un producto existente a una factura y calcular el subtotal.
    // Se maneja el control de errores y validaciones para verificar que la factura y el producto existan.
    public void AgregarProductoAFactura(int facturaId, int productoId, int cantidad)
    {
        try
        {
            // Busca la factura por su ID.
            var factura = _contexto.Facturas.Find(facturaId);
            // Busca el producto por su ID.
            var producto = _contexto.Productos.Find(productoId);
            // Valida que tanto la factura como el producto existan.
            if (factura == null || producto == null)
            {
                Console.WriteLine("Factura o Producto no encontrado.");
                return;     // Finaliza si alguno de los dos no existe.
            }

            // Crea una nueva instancia de ProductosPorFacturaDatos con los detalles proporcionados.
            ProductosPorFacturaDatos nuevoProductoFactura = new ProductosPorFacturaDatos
            {
                Factura = factura,      // Asigna la factura asociada.
                Producto = producto,    // Asigna el producto asociado.
                Cantidad = cantidad,    // Cantidad de productos agregados a la factura.
                Subtotal = cantidad * producto.ValorUnitario    // Calcula el subtotal basado en la cantidad y el valor unitario del producto.
            };

            // Agrega el producto a la factura.
            _contexto.ProductosPorFactura.Add(nuevoProductoFactura);
            _contexto.SaveChanges();     // Guarda los cambios en la base de datos.
            Console.WriteLine("Producto agregado a la factura con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura y muestra el mensaje de error.
            Console.WriteLine($"Error al agregar el producto a la factura: {ex.Message}");
        }
    }

}
