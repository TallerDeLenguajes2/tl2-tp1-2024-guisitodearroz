using Cadeteria;

using cadeteria

Cadeteria cadeteria= new Cadeteria("OKA", "02221111", new List<Cadete>());
const string archivoCadetes = "cadetes.csv";

AltaPedido.Iniciar(cadeteria);

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Cadetería ===");
                Console.WriteLine("1. Dar de alta pedidos");
                Console.WriteLine("2. Asignar pedido a cadete");
                Console.WriteLine("3. Cambiar estado del pedido");
                Console.WriteLine("4. Reasignar pedido a otro cadete");
                Console.WriteLine("5. Mostrar informe");
                Console.WriteLine("6. Generar cadetes aleatorios");
                Console.WriteLine("0. Salir y Guardar");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AltaPedido.DarDeAltaPedidos();
                        break;
                    case 2:
                        AltaPedido.AsignarPedidoACadete(null);
                        break;
                    case 3:
                        AltaPedido.CambiarEstadoPedido();
                        break;
                    case 4:
                        AltaPedido.ReasignarPedido();
                        break;
                    case 5:
                        cadeteria.GenerarInforme();
                        break;
                    case 6:
                        GenerarCadetesAleatorios();
                        break;
                    case 0:
                        // Guardar cadetes en el archivo CSV
                        cadeteria.GuardarCadetesEnCSV(archivoCadetes);
                        Console.WriteLine("Datos guardados y saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcion != 0);
        }

        // Método para generar cadetes aleatorios
        static void GenerarCadetesAleatorios()
        {
            Console.Write("¿Cuántos cadetes desea generar? ");
            int cantidad = int.Parse(Console.ReadLine());
            cadeteria.GenerarCadetesAleatorios(cantidad);
        }