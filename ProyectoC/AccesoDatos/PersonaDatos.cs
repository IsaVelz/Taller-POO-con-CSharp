using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoC.AccesoDatos
{
    // Clase abstracta: PersonaDatos
    // 1. Herencia: Esta clase es abstracta, lo que significa que no puede ser instanciada directamente.
    // 2. Polimorfismo: Como es una clase abstracta, permitirá que las clases derivadas implementen su comportamiento específico.
    // 3. Encapsulación: Las propiedades PersonaId, Codigo, Email, Nombre y Telefono están encapsuladas utilizando
    //    getters y setters. Aunque las propiedades son públicas, el acceso a las variables internas está controlado 
    //    a través de estos métodos de acceso.
    public abstract class PersonaDatos
    {
        // Uso de Data Annotations (ORM): La propiedad PersonaId será la clave primaria en la base de datos
        [Key]
        public int PersonaId { get; set; } //Encapsulación de las propiedades de persona

        // Propiedades obligatorias (usando 'required') que deben ser asignadas al crear un objeto.
        public required string Codigo { get; set; }
        public required string Email { get; set; }
        public required string Nombre { get; set; }
        public required string Telefono { get; set; }

        // Relación UML - Composición: Una Persona tiene una lista de Facturas asociadas (composición uno a muchos).
        // Entity Framework lo mapeará como una relación en la base de datos.
        public required List<FacturaDatos> Facturas { get; set; } // Relación uno a muchos con Factura en base al diagrama UML
    }
}