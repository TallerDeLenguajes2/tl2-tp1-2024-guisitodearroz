namespace EspacioCadeteria
{
    public enum Estado
    {
        Entregado,
        Enviado,
        Rechazado,
        Pendiente
    }

    public class Pedido
    {
        private string nro;
        private string obs;
        private Cliente cliente;
        private Estado estado;

        public Pedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
        {
            this.nro = nro;
            this.obs = obs;
            this.cliente = new Cliente(nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli);
            this.estado = estado;
        }

        public string NumeroPedido { get => nro; set => nro = value; }
        public string Observaciones { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Estado EstadoPedido { get => estado; set => estado = value; }
        public Cadete CadeteAsignado { get; set; }

        public void MostrarPedido()
        {
            System.Console.WriteLine("\nDatos del pedido: ");
            System.Console.WriteLine($"Numero: {NumeroPedido}");
            System.Console.WriteLine($"Observacion: {Observaciones}");
            System.Console.WriteLine($"Nombre: {Cliente.Nombre}");
            System.Console.WriteLine($"Estado: {EstadoPedido}");
        }

        public void VerDireccionCliente()
        {
            Console.WriteLine($"La direccion del cliente es: {Cliente.Direccion}");
        }

        public void VerDatosCliente()
        {
            Console.WriteLine("\nDatos del cliente: ");
            Console.WriteLine($"{Cliente.Nombre}");
            Console.WriteLine($"{Cliente.Direccion}");
            Console.WriteLine($"{Cliente.Telefono}");
            Console.WriteLine($"{Cliente.DatosReferenciaDireccion}");
        }
    }
}
