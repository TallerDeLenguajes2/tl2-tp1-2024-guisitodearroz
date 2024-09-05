namespace cadeteria;
class AltaPedido
{
    static void DarDeAltaPedidos(){
        Console.WriteLine("Ingrese el numero del pedido: \n");
        int numero= int.Parse(Console.ReadLine());
        Console.WriteLine("\n ingrese observaciones: \n");
        string observaciones= Console.ReadLine(); 
        Console.WriteLine("\n Ingrese el nombre del Cliente: \n");
        string nombreCliente= Console.ReadLine();
        Console.WriteLine("\n Ingrese la direccion del Cliente\n");
        string direccionCliente= Console.ReadLine();
        Console.WriteLine("\n Ingrese telefono del Cliente");
        string telefonoCliente= Console.ReadLine();
        Cliente nuevoCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, null);
        Pedido nuevoPedido = new Pedido(numero, observaciones, nuevoCliente, Pedido.EstadoPedido.Pendiente);
        AsignarPedidoCadete(nuevoPedido);
    }
    static void AsignarPedidoACadete(Pedido pedido)
        {
            Cadeteria cadeteria= new Cadeteria();
            cadeteria.mostrarCadete();
            Console.Write("Ingrese el ID del cadete: ");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadeteSeleccionado = cadeteria.ListadoCadetes.Find(c => c.Id == idCadete);
            if (cadeteSeleccionado != null)
            {
                cadeteSeleccionado.AsignarPedido(pedido);
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
}