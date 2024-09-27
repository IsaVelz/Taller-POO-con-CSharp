using ProyectoC.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoC.Logica
{
    public class PersonaService
    {
        // Referencia al contexto de datos para acceder a la base de datos.
        private MiContextoDeDatos _contexto;

        // Constructor: Inicializa el servicio con una instancia del contexto de datos MiContextoDeDatos.
        // Encapsulación: El contexto _contexto está encapsulado como privado y solo se accede a él a través de los métodos de esta clase.
        public PersonaService(MiContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Método para listar todas las personas.
        // Responsabilidad: Recuperar todas las personas de la base de datos y mostrarlas en la consola.
        // Se maneja el control de errores para capturar excepciones que puedan ocurrir al acceder a la base de datos.
        public void ListarPersonas()
        {
            try
            {
                // Recupera la lista de todas las personas desde la base de datos.
                var personas = _contexto.Personas.ToList(); // Asume que tienes una propiedad 'Personas' en tu contexto de datos que devuelve todas las instancias de 'Persona'

                Console.WriteLine("Lista de Personas:");
                foreach (var persona in personas)
                {
                    // Muestra los detalles de cada persona.
                    Console.WriteLine($"ID: {persona.PersonaId}, Código: {persona.Codigo}, Nombre: {persona.Nombre}, Email: {persona.Email}, Teléfono: {persona.Telefono}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Captura cualquier excepción y muestra el mensaje de error.
                Console.WriteLine($"Error al listar las personas: {ex.Message}");
            }
        }
    }
}
