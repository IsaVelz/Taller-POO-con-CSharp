using ProyectoC.Logica;
using System;

public class PersonaUI
{
    private PersonaService _personaService;

    // Constructor: Recibe una instancia de PersonaService como dependencia, permitiendo la interacción con la capa de lógica.
    // Encapsulación: El servicio _personaService está encapsulado como privado y solo es accesible dentro de esta clase.
    public PersonaUI(PersonaService personaService)
    {
        _personaService = personaService;
    }

    // Método principal que presenta el menú de opciones para la gestión de personas.
    // Interfaz: Permite al usuario seleccionar distintas opciones relacionadas con la gestión de personas.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Menú principal para la gestión de personas - El CRUD completo va en las clases que hereda Persona
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Menu de Personas:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("1. Listar Personas");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para manejar las opciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarPersonas();
                    break;
                case "2":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (continuar);
    }

    // Método para listar todas las personas.
    // Interfaz: Solicita al servicio la lista de personas y la muestra al usuario.
    private void ListarPersonas()
    {
        // Invoca el método de servicio para listar las personas.
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Listando personas...");
        Console.WriteLine("------------------------------------------------------");
        _personaService.ListarPersonas();
    }
}
