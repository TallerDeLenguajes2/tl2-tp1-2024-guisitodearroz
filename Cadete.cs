namespace cadeteria;
public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listaPedido;
    
    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listaPedido)
    {
        this.id= id;
        this.nombre= nombre;
        this.direccion= direccion;
        this.telefono= telefono;
        this.listaPedido = listaPedido;
    }

    //get y set
    public int Id{
        get => id;
        set => id= value;
    }
    public string Nombre{
        get => nombre;
        set => nombre= value;
    }
    public string Direccion{
        get => direccion;
        set => direccion= value;
    }
    public string Telefono{
        get => telefono;
        set => telefono= value;
    }
    public List<Pedido> ListaPedido{
        get => listaPedido;
        set => listaPedido= value;
    }
    //metodos

    public int JornalACobrar(){
       const int pagoPorPedido= 500;
       int totalPagar = 0;
       foreach (var pedido in listaPedido)
       {
        if (pedido.Estado == Pedido.EstadoPedido.Entregado)
        {
            totalPagar += pagoPorPedido;
        }
       }
       return totalPagar;
    }
    public void AsignarPedidos(Pedido pedido){
        listaPedido.Add(pedido);
        Console.WriteLine($"Pedido {pedido.Numero} asignado a {nombre}");
    }
    public void MostrarPedidos(){
        Console.WriteLine($"\n--------Pedidos del cadete {nombre}--------");
        foreach (var pedido in listaPedido)
        {
            Console.WriteLine($"Numero: {pedido.Numero}, Estado: {pedido.Estado}");
        }
    }
    public void CambiarCadete(Pedido pedido, Cadete nuevoCadete){
        listaPedido.Remove(pedido);
        nuevoCadete.AsignarPedidos(pedido);
    }
}