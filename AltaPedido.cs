namespace Cadeteria
    class AltaPedido
    {
        private static Cadeteria cadeteria;

        // Inicialización con la instancia existente de Cadeteria
        public static void Iniciar(Cadeteria cadeteriaExistente)
        {
            cadeteria = cadeteriaExistente;
        }

        // Dar de alta un pedido
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

        // Asignar pedido a un cadete
        public static void AsignarPedidoACadete(Pedido pedido)
        {
            cadeteria.MostrarCadetes();  // Corrección en el método 'MostrarCadetes'
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

        // Cambiar el estado de un pedido
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

        // Reasignar un pedido a otro cadete
        public static void ReasignarPedido()
        {
            cadeteria.MostrarCadetes();
            Console.Write("Ingrese el ID del cadete: ");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadeteSeleccionado = cadeteria.ListadoCadetes.Find(c => c.Id == idCadete);
            if (cadeteSeleccionado != null)
            {
                cadeteSeleccionado.MostrarPedidos();
                Console.Write("Ingrese el número de pedido a reasignar: ");
                int numeroPedido = int.Parse(Console.ReadLine());

                Pedido pedidoSeleccionado = cadeteSeleccionado.ListaPedido.Find(p => p.Numero == numeroPedido);
                if (pedidoSeleccionado != null)
                {
                    cadeteria.MostrarCadetes();
                    Console.Write("Ingrese el ID del nuevo cadete: ");
                    int idNuevoCadete = int.Parse(Console.ReadLine());

                    Cadete nuevoCadete = cadeteria.ListadoCadetes.Find(c => c.Id == idNuevoCadete);
                    if (nuevoCadete != null)
                    {
                        cadeteSeleccionado.ReasignarPedido(pedidoSeleccionado, nuevoCadete);
                    }
                    else
                    {
                        Console.WriteLine("\nCadete nuevo no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("\nPedido no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("\nCadete no encontrado.");
            }
        }
    }
