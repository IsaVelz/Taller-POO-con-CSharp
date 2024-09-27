using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoC.AccesoDatos
{
    // 1. Encapsulación: Las propiedades EmpresaId, Codigo y Nombre están encapsuladas a través de getters y setters. 
    //    Esto asegura que el acceso a los valores internos de estas propiedades sea controlado.
    public class EmpresaDatos //Clase Independiente
    {
        // Uso de Data Annotations (ORM): EmpresaId es la clave primaria en la base de datos
        [Key]
        public int EmpresaId { get; set; }

        // Propiedad requerida: Código único que identifica a la empresa.
        public required string Codigo { get; set; }

        // Propiedad requerida: Nombre de la empresa.
        public required string Nombre { get; set; }
    }
}
