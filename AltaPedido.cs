namespace cadeteria;
class AltaPedido
{
    private static Cadeteria cadeteria;
    public static void iniciar(Cadeteria cadeteriaExistente){
        cadeteria= cadeteriaExistente;
    }
    public static void DarDeAltaPedidos()
        {
            Console.WriteLine("Ingrese el número del pedido: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese observaciones: ");
            string observaciones = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del cliente: ");
            string nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del cliente: ");
            string direccionCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono del cliente: ");
            string telefonoCliente = Console.ReadLine();
            Cliente nuevoCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, null);
            Pedido nuevoPedido = new Pedido(numero, observaciones, nuevoCliente, Pedido.EstadoPedido.Pendiente);

            // Asignar el nuevo pedido a un cadete
            AsignarPedidoACadete(nuevoPedido);
        }
        public static void AsignarPedidoACadete(Pedido pedido)
        {
            cadeteria.mostrarCadete();
            Console.Write("Ingrese el ID del cadete: ");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadeteSeleccionado = cadeteria.ListadoCadetes.Find(c => c.Id == idCadete);
            if (cadeteSeleccionado != null)
            {
                cadeteSeleccionado.AsignarPedido(pedido);
                Console.WriteLine($"Pedido asignado al cadete {cadeteSeleccionado.Nombre}.");
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
        public static void CambiarEstadoPedido()
        {
            cadeteria.MostrarCadetes();
            Console.Write("Ingrese el ID del cadete: ");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadeteSeleccionado = cadeteria.ListadoCadetes.Find(c => c.Id == idCadete);
            if (cadeteSeleccionado != null)
            {
                cadeteSeleccionado.MostrarPedidos();
                Console.Write("Ingrese el número de pedido a cambiar el estado: ");
                int numeroPedido = int.Parse(Console.ReadLine());

                Pedido pedidoSeleccionado = cadeteSeleccionado.ListaPedido.Find(p => p.Numero == numeroPedido);
                if (pedidoSeleccionado != null)
                {
                    Console.WriteLine("Seleccione el nuevo estado del pedido:");
                    Console.WriteLine("1. Pendiente");
                    Console.WriteLine("2. En Proceso");
                    Console.WriteLine("3. Entregado");
                    Console.WriteLine("4. Cancelado");
                    int nuevoEstado = int.Parse(Console.ReadLine());

                    pedidoSeleccionado.CambiarEstado((Pedido.EstadoPedido)(nuevoEstado - 1));
                }
                else
                {
                    Console.WriteLine("Pedido no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
        public static void ReasignarPedido(){
            cadeteria.mostrarCadete();
            Console.WriteLine("Ingrese el ID del cadete: \n");
            int idCadete= int.Parse(Console.ReadLine());
            Cadete cadeteSeleccionado= cadeteria.ListadoCadetes.Find(c => c.Id == idCadete);
            if (cadeteSeleccionado != null)
            {
                cadeteSeleccionado.MostrarPedidos();
                Console.WriteLine("Ingrese el numero de pedido a reasignar: \n");
                int numeroPedido= int.Parse(Console.ReadLine());
                 Pedido pedidoSeleccionado = cadeteSeleccionado.ListaPedido.Find(p => p.Numero == numeroPedido);
                 if (pedidoSeleccionado != null)
                 {
                    cadeteria.MostrarCadetes();
                    Console.Write("Ingrese el ID del nuevo cadete: ");
                    int idNuevoCadete = int.Parse(Console.ReadLine());
                    Cadete nuevoCadete = cadeteria.ListadoCadetes.Find(c => c.Id == idNuevoCadete);
                    if (nuevoCadete != null)
                    {
                         cadeteSeleccionado.CambiarCadete(pedidoSeleccionado, nuevoCadete);
                    }
                    else
                    {
                        Console.WriteLine("\n Cadete Nuevo no encontrado");
                    }
                }else
                {
                    Console.WriteLine("\n Pedido no encontrado");
                }
            }else
            {
                Console.WriteLine("\n Cadete no encontrado")
            }

        }
}