using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoC.AccesoDatos
{
    // 1. Encapsulación: Las propiedades ProductoId, Codigo, Nombre, Stock y ValorUnitario están encapsuladas
    //    mediante getters y setters. Esto permite el acceso controlado a los valores internos de estas propiedades.
    public class ProductoDatos
    {
        // Uso de Data Annotations (ORM): ProductoId es la clave primaria de la tabla en la base de datos.
        [Key]
        public int ProductoId { get; set; }

        // Propiedades obligatorias (usando 'required') que deben ser asignadas al crear un objeto
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public int Stock { get; set; }   // Propiedad que almacena la cantidad de stock disponible del producto.
        public double ValorUnitario { get; set; }

        // Relación UML - Composición: Relación uno a muchos con ProductosPorFacturaDatos.
        // Un producto puede estar asociado a múltiples facturas a través de esta lista.
        public required List<ProductosPorFacturaDatos> ProductosPorFactura { get; set; }
    }
}