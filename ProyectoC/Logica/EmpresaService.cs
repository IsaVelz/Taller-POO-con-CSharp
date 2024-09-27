using ProyectoC.AccesoDatos;
using System;
using System.Linq;

namespace ProyectoC.Logica
{
    public class EmpresaService
    {
        private MiContextoDeDatos _contexto;

        // Constructor: Inicializa el servicio de empresa con una instancia de MiContextoDeDatos, permitiendo el acceso a la base de datos.
        // Encapsulación: El contexto _contexto está encapsulado como privado y solo es accesible a través de los métodos del servicio.
        public EmpresaService(MiContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Método para agregar una nueva empresa.
        // Responsabilidad: Agregar una nueva empresa a la base de datos.
        // Se maneja el control de errores para capturar excepciones durante la operación de guardado.
        public void AgregarEmpresa(EmpresaDatos nuevaEmpresa)
        {
            try
            {
                _contexto.Empresas.Add(nuevaEmpresa);       // Agrega la nueva empresa al contexto.
                _contexto.SaveChanges();                    // Guarda los cambios en la base de datos.
                Console.WriteLine("---------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar la empresa: {ex.Message}");
            }
        }

        // Método para listar todas las empresas.
        // Responsabilidad: Recuperar todas las empresas de la base de datos y mostrarlas en la consola.
        public void ListarEmpresas()
        {
            try
            {
                var empresas = _contexto.Empresas.ToList(); // Recupera la lista de empresas.
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Lista de Empresas:");
                Console.WriteLine("------------------------------------------------------");
                foreach (var empresa in empresas)
                {
                    // Muestra los detalles de cada empresa.
                    Console.WriteLine($"ID: {empresa.EmpresaId}, Código: {empresa.Codigo}, Nombre: {empresa.Nombre}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al listar las empresas: {ex.Message}");
            }
        }

        // Método para actualizar una empresa existente.
        // Responsabilidad: Buscar una empresa por su ID y actualizar sus detalles en la base de datos.
        public void ActualizarEmpresa(int id, EmpresaDatos empresaActualizada)
        {
            try
            {
                var empresa = _contexto.Empresas.Find(id);  // Busca la empresa por su ID.
                if (empresa == null)
                {
                    Console.WriteLine("Empresa no encontrada.");
                    return;                                 // Finaliza si la empresa no se encuentra.
                }
                // Actualiza los detalles de la empresa con los nuevos datos.
                empresa.Codigo = empresaActualizada.Codigo;
                empresa.Nombre = empresaActualizada.Nombre;

                _contexto.SaveChanges();    // Guarda los cambios en la base de datos.
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
            }
        }

        // Método para eliminar una empresa.
        // Responsabilidad: Buscar una empresa por su ID y eliminarla de la base de datos.
        public void EliminarEmpresa(int id)
        {
            try
            {
                var empresa = _contexto.Empresas.Find(id);  // Busca la empresa por su ID.
                if (empresa == null)
                {
                    Console.WriteLine("Empresa no encontrada.");
                    return;     // Finaliza si la empresa no se encuentra.
                }

                _contexto.Empresas.Remove(empresa);         // Elimina la empresa del contexto.
                _contexto.SaveChanges();                    // Guarda los cambios en la base de datos.
                Console.WriteLine("Empresa eliminada con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura y muestra un mensaje de error.
                Console.WriteLine($"Error al eliminar la empresa: {ex.Message}");
            }
        }
    }
}
