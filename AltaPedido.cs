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
}