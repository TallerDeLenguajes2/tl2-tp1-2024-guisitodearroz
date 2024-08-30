namespace cadeteria;
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
    public int Numero{
        get => numero;
        set{
            if (value > 0)
            {
                numero= value;      
            }else
            {
                Console.WriteLine("El numero debe ser positivo");
            }
        } 
    }
    public string? Observaciones{
            get => observaciones;
            set => observaciones= value;
        }
        public string Telefono{
            get => telefono;
            set => telefono= value;
        }
        public Cliente Cliente{
            get => cliente;
            set => cliente= value;
        }
        public EstadoPedido Estado 
        { 
            get => estado; 
            set => estado = value; 
        }
        //metodos
        public string verDireccionCliente(){
            return cliente.Direccion;
        }
        public string verDatosCliente(){
            string datos= $"Nombre: {cliente.Nombre} , Telefono: {cliente.Telefono} , Direccion : {cliente.Direccion}";
            return datos;
        }
        //enum estados
        public enum EstadoPedido
        {
            Pendiente,
            EnProceso,
            Entregado,
            Cancelado

        }
    
}