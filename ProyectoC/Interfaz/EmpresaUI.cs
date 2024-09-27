using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

public class EmpresaUI
{
    private EmpresaService _empresaService;

    // Constructor: Se recibe una instancia del servicio de empresa (EmpresaService) como dependencia.
    // Encapsulación: El servicio _empresaService está encapsulado como privado y es accedido únicamente desde los métodos de esta clase.
    public EmpresaUI(EmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    // Método principal que ofrece un menú para la gestión de empresas.
    // Interfaz: Este método permite la interacción con el usuario, brindando opciones para gestionar empresas mediante la consola.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de empresas.
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menú de Gestión de Empresas:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Empresas");
            Console.WriteLine("2. Agregar Empresa");
            Console.WriteLine("3. Actualizar Empresa");
            Console.WriteLine("4. Eliminar Empresa");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control (switch) que determina la acción a realizar en función de la opción seleccionada.
            switch (opcion)
            {
                case "1":
                    ListarEmpresas();
                    break;
                case "2":
                    AgregarEmpresa();
                    break;
                case "3":
                    ActualizarEmpresa();
                    break;
                case "4":
                    EliminarEmpresa();
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

    // Método para agregar una nueva empresa.
    // Interfaz: Recibe datos de entrada del usuario y crea una nueva instancia de EmpresaDatos que es pasada al servicio para su almacenamiento.
    private void AgregarEmpresa()
    {
        try
        {
            // Solicitud de los datos de la empresa.
            Console.WriteLine("Ingrese el código de la empresa:");
            string? codigo = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de la empresa:");
            string? nombre = Console.ReadLine();

             // Creación de un nuevo objeto EmpresaDatos con los datos proporcionados.
            EmpresaDatos nuevaEmpresa = new EmpresaDatos
            {
                Codigo = codigo!,
                Nombre = nombre!
            };

            // Uso del servicio para agregar la empresa.
            _empresaService.AgregarEmpresa(nuevaEmpresa);
            Console.WriteLine("Empresa agregada con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Se captura cualquier excepción y se muestra un mensaje de error.
            Console.WriteLine($"Error al agregar la empresa: {ex.Message}");
        }
    }

    // Método para listar todas las empresas.
    // Interfaz: Interactúa con el servicio para obtener y mostrar la lista de empresas.
    private void ListarEmpresas()
    {
        _empresaService.ListarEmpresas();    // Invoca el método del servicio para listar empresas.
    }

    // Método para actualizar una empresa existente.
    // Interfaz: Solicita los nuevos datos de la empresa al usuario y los pasa al servicio para actualizar.
    private void ActualizarEmpresa()
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la empresa a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido, debe ser un número entero.");
                return; // Salimos del método si la entrada no es válida
            }

            Console.WriteLine("Ingrese el nuevo código de la empresa:");
            string? codigo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.WriteLine("El código no puede estar vacío.");
                return; // Salimos del método si la entrada no es válida
            }

            Console.WriteLine("Ingrese el nuevo nombre de la empresa:");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return; // Salimos del método si la entrada no es válida
            }

            // Creación de un nuevo objeto EmpresaDatos con los datos actualizados.
            EmpresaDatos empresaActualizada = new EmpresaDatos
            {
                Codigo = codigo,
                Nombre = nombre
            };

            // Uso del servicio para actualizar la empresa.
            _empresaService.ActualizarEmpresa(id, empresaActualizada);
            Console.WriteLine("Empresa actualizada con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra un mensaje de error.
            Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
        }
    }

    // Método para eliminar una empresa existente.
    // Interfaz: Solicita al usuario el ID de la empresa a eliminar y lo pasa al servicio para su eliminación.
    private void EliminarEmpresa()
    {
        try
        {
            Console.WriteLine("Ingrese el ID de la empresa a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido, debe ser un número entero.");
                return; // Salimos del método si la entrada no es válida
            }

            // Uso del servicio para eliminar la empresa.
            _empresaService.EliminarEmpresa(id);
        }
        catch (Exception ex)
        {
            // Manejo de errores: Captura excepciones y muestra un mensaje de error.
            Console.WriteLine($"Error al eliminar la empresa: {ex.Message}");
        }
    }

}
