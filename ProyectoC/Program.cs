using Microsoft.EntityFrameworkCore;
using ProyectoC.AccesoDatos;
using ProyectoC.Logica;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Bloque "using" que inicializa el contexto de datos y garantiza su correcta disposición al finalizar.
            using (var contexto = new MiContextoDeDatos())
            {
                // Aplicar migraciones pendientes en la base de datos.
                // Esto asegura que la base de datos esté actualizada con la estructura definida en las entidades y migraciones.
                contexto.Database.Migrate();
                contexto.Database.Migrate();
                Console.WriteLine("Las migraciones se han aplicado y la base de datos está lista.");

                // Inicializar los servicios, los cuales interactúan con la capa de acceso a datos a través del contexto de base de datos
                var clienteService = new ClienteService(contexto);
                var empresaService = new EmpresaService(contexto);
                var facturaService = new FacturaService(contexto);
                var personaService = new PersonaService(contexto);
                var productosPorFacturaService = new ProductosPorFacturaService(contexto);
                var productoService = new ProductoService(contexto);
                var vendedorService = new VendedorService(contexto);

                // Inicializar las interfaces de usuario correspondientes, pasando los servicios correspondientes.
                var clienteUI = new ClienteUI(clienteService);
                var empresaUI = new EmpresaUI(empresaService);
                var facturaUI = new FacturaUI(facturaService);
                var personaUI = new PersonaUI(personaService);
                var productosPorFacturaUI = new ProductosPorFacturaUI(productosPorFacturaService);
                var productoUI = new ProductoUI(productoService);
                var vendedorUI = new VendedorUI(vendedorService);

                // Bucle principal para gestionar el flujo de la aplicación.
                bool continuar = true;
                while (continuar)
                {
                    // Menú principal que permite al usuario seleccionar entre los distintos módulos.
                    Console.WriteLine("\n----------------------Bienvenido----------------------");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Seleccione el módulo para gestionar:");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("1. Clientes");
                    Console.WriteLine("2. Empresas");
                    Console.WriteLine("3. Facturas");
                    Console.WriteLine("4. Personas");
                    Console.WriteLine("5. Productos por Factura");
                    Console.WriteLine("6. Productos");
                    Console.WriteLine("7. Vendedores");
                    Console.WriteLine("8. Salir del menú principal");
                    Console.WriteLine("------------------------------------------------------");
                    Console.Write("Ingrese su elección: ");
                    string? eleccion = Console.ReadLine();

                    // Control de flujo basado en la elección del usuario. Cada opción invoca el menú del módulo correspondiente.
                    switch (eleccion)
                    {
                        case "1":
                            clienteUI.MenuPrincipal();      // Módulo de gestión de clientes
                            break;
                        case "2":
                            empresaUI.MenuPrincipal();      // Módulo de gestión de empresas
                            break;
                        case "3":
                            facturaUI.MenuPrincipal();      // Módulo de gestión de facturas
                            break;
                        case "4":
                            personaUI.MenuPrincipal();      // Módulo de gestión de personas
                            break;
                        case "5":
                            productosPorFacturaUI.MenuPrincipal();  // Módulo de gestión de productos por factura
                            break;
                        case "6":
                            productoUI.MenuPrincipal();     // Módulo de gestión de productos
                            break;
                        case "7":
                            vendedorUI.MenuPrincipal();     // Módulo de gestión de vendedores
                            break;
                        case "8":
                            continuar = false;              // Salir de la aplicación
                            break;
                        default:
                            Console.WriteLine("Selección no válida.");  // Manejo de entradas inválidas 
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores que puedan ocurrir durante la ejecución del programa.
            Console.WriteLine($"Error durante la ejecución del programa: {ex.Message}");
        }
    }
}
