using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoC.AccesoDatos
{
    // 1. Herencia: Esta clase hereda de la clase abstracta PersonaDatos. Al heredar, reutiliza todas las propiedades
    //    de PersonaDatos como PersonaId, Codigo, Email, Nombre y Telefono.
    // 2. Polimorfismo: Al heredar de PersonaDatos, VendedorDatos puede extender o sobrescribir el comportamiento de PersonaDatos,
    //    aplicando polimorfismo.
    // 3. Encapsulación: Las propiedades Carne y Direccion están encapsuladas mediante getters y setters, lo que permite
    //    controlar el acceso a estas propiedades.
    // 4. Relación UML - Asociación: Hereda las relaciones establecidas en PersonaDatos, como la asociación con FacturaDatos.
    public class VendedorDatos : PersonaDatos
    {
        public int Carne { get; set; }  // Propiedad Carne: Almacena el número de carné del vendedor.  
        public required string Direccion { get; set; }  // Propiedad requerida: Dirección del vendedor.
    }
}