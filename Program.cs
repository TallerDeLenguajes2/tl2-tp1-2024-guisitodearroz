using Cadeteria;

using cadeteria

Cadeteria cadeteria= new Cadeteria("OKA", "02221111", new List<Cadete>());

AltaPedido.Iniciar(cadeteria);
int opcion;
do
{
    Console.Clear();
    Console.WriteLine("\n---------Menu---------\n");
    Console.WriteLine("1_Dar de alta pedidos\n");
    Console.WriteLine("2_Asignar Pedidos\n");
    Console.WriteLine("3_Cambiar Estado de Pedido\n");
    Console.WriteLine("4_Reasignar Pedido a otro Cadete\n");
    Console.WriteLine("5_Mostrar Informe\n");
    Console.WriteLine("0_Salir.\n");
    Console.WriteLine("Seleccione una opcion\n");
    opcion= int.Parse(Console.ReadLine());
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
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
                if (opcion!=0)
                {
                    Console.WriteLine("\nPresione Cualquier Boton para continuar");
                    Console.ReadKey();
                }
} while (opcion !=0);
