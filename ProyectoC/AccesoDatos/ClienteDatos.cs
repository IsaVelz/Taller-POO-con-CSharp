using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoC.AccesoDatos
{
    // Clase concreta: ClienteDatos
    // 1. Herencia: Esta clase hereda de la clase abstracta PersonaDatos, lo que permite reutilizar las propiedades
    //    y comportamientos definidos en PersonaDatos.
    // 2. Polimorfismo: Dado que ClienteDatos hereda de PersonaDatos, puede implementar o extender cualquier 
    //    comportamiento definido en PersonaDatos.
    // 3. Relación UML - Asociación: Esta clase mantiene la asociación heredada con FacturaDatos (uno a muchos).
    // 4. Encapsulación: Las propiedades ClienteId y Credito están encapsuladas mediante getters y setters, lo que 
    //    permite controlar cómo se accede y modifica el valor de estas propiedades desde fuera de la clase.
    public class ClienteDatos : PersonaDatos
    {
        // Constructor: Inicializa la lista de Facturas para evitar errores de referencia nula al agregar Facturas.
        public ClienteDatos()
        {
            Facturas = new List<FacturaDatos>();  // Inicializa la lista de facturas
        }
        // Propiedad ClienteId: Podría servir como clave primaria si es necesario para diferenciar clientes de otras personas.
        public int ClienteId { get; set; }

        // Propiedad Credito: Almacena el valor del crédito que tiene el cliente.
        public double Credito { get; set; }
    }
}