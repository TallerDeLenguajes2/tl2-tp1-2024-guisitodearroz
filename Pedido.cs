namespace negocio
{
    public class Pedido
    {
        private int numero;
        private string? observaciones;
        private Cliente cliente;
        private EstadoPedido estado;

        public Pedido(int numero, string? observaciones, Cliente cliente, EstadoPedido estado)
        {
            this.Numero = numero;
            this.Observaciones = observaciones;
            this.Cliente = cliente;
            this.Estado = estado;
        }

        public int Numero 
        { 
            get => numero; 
            set => numero = value; 
        }

        public string? Observaciones
        { 
            get => observaciones; 
            set => observaciones = value; 
        }

        public Cliente Cliente 
        { 
            get => cliente; 
            set => cliente = value; 
        }

        public EstadoPedido Estado 
        { 
            get => estado; 
            set => estado = value; 
        }

        // Métodos
        public string VerDireccionCliente()
        {
            return cliente.Direccion;
        }

        public string VerDatosCliente()
        {
            return $"Nombre: {cliente.Nombre}, Teléfono: {cliente.Telefono}, Dirección: {cliente.Direccion}";
        }

        public void CambiarEstadoPedido(EstadoPedido nuevoEstado)
        {
            this.Estado = nuevoEstado;
            Console.WriteLine($"El estado del pedido {numero} ha sido cambiado a {estado}.");
        }

        // Enum estados
        public enum EstadoPedido
        {
            Pendiente,
            EnProceso,
            Entregado,
            Cancelado
        }
    }