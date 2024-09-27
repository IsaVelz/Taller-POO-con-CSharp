using ProyectoC.AccesoDatos;
using System;
using System.Linq;

namespace ProyectoC.Logica
{
    public class FacturaService
    {
        private MiContextoDeDatos _contexto;

        // Constructor: Inicializa el servicio con una instancia de MiContextoDeDatos, que maneja el acceso a la base de datos.
        public FacturaService(MiContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Método para obtener una persona por su ID.
        // Responsabilidad: Recuperar una persona específica de la base de datos por su ID.
        public PersonaDatos? ObtenerPersonaPorId(int personaId)
        {
            var persona = _contexto.Personas.Find(personaId);   // Busca la persona por su ID.
            return persona; // Retorna la persona o null si no se encuentra.
        }


        // Método para agregar una nueva factura.
        // Responsabilidad: Agregar una nueva instancia de FacturaDatos a la base de datos.
        // Se maneja el control de errores para capturar posibles excepciones en la operación de guardado.
        public void AgregarFactura(FacturaDatos nuevaFactura)
        {
            try
            {
                _contexto.Facturas.Add(nuevaFactura);   // Agrega la nueva factura al contexto.
                _contexto.SaveChanges();                // Guarda los cambios en la base de datos.
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra el mensaje de error.
                Console.WriteLine($"Error al agregar la factura: {ex.Message}");
            }
        }

        // Método para listar todas las facturas.
        // Responsabilidad: Recuperar todas las facturas de la base de datos y mostrarlas en la consola.
        public void ListarFacturas()
        {
            try
            {
                var facturas = _contexto.Facturas.ToList(); // Recupera la lista de facturas.
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Lista de Facturas:");
                Console.WriteLine("------------------------------------------------------");
                foreach (var factura in facturas)
                {
                    // Muestra los detalles de cada factura.
                    Console.WriteLine($"ID: {factura.FacturaId}, Fecha: {factura.Fecha}, Número factura: {factura.Numero}, Total: {factura.Total}, Identificacion Persona: {factura.PersonaId}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al listar las facturas: {ex.Message}");
            }
        }

        // Método para actualizar una factura existente.
        // Responsabilidad: Buscar una factura por su ID y actualizar sus detalles en la base de datos.
        public void ActualizarFactura(int id, FacturaDatos facturaActualizada)
        {
            try
            {
                var factura = _contexto.Facturas.Find(id);      // Busca la factura por su ID.
                if (factura == null)
                {
                    Console.WriteLine("Factura no encontrada.");
                    return;     // Finaliza si la factura no se encuentra.
                }
                // Actualiza los detalles de la factura con los nuevos datos.
                factura.Fecha = facturaActualizada.Fecha;
                factura.Numero = facturaActualizada.Numero;
                factura.Total = facturaActualizada.Total;
                factura.PersonaId = facturaActualizada.PersonaId; // Asumiendo que se puede cambiar la persona asociada a la factura.

                _contexto.SaveChanges();    // Guarda los cambios en la base de datos.
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al actualizar la factura: {ex.Message}");
            }
        }

        // Método para eliminar una factura.
        // Responsabilidad: Buscar una factura por su ID y eliminarla de la base de datos.
        public void EliminarFactura(int id)
        {
            try
            {
                var factura = _contexto.Facturas.Find(id);      // Busca la factura por su ID.
                if (factura == null)
                {
                    Console.WriteLine("Factura no encontrada.");
                    return;                             // Finaliza si la factura no se encuentra.
                }

                _contexto.Facturas.Remove(factura);     // Elimina la factura del contexto.
                _contexto.SaveChanges();                // Guarda los cambios en la base de datos.
                Console.WriteLine("Factura eliminada con éxito");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al eliminar la factura: {ex.Message}");
            }
        }
    }
}
