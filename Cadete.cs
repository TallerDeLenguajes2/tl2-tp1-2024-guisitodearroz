namespace cadeteria;
public class Cadete
{
    int Id;
    string Nombre;
    string Direccion;
    string Telefono;
    List<Pedido> listaPedido;
    
    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listaPedido)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        this.listaPedido = listaPedido;
    }

    public int Id1 { get => Id; set => Id = value; }
    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direccion1 { get => Direccion; set => Direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }

    //metodos
    public int pedidosDespachados(List<Pedido> Listapedidos){
       int totalPagar=0;
       foreach (var pedido in Listapedidos)
       {
        if (pedido.Estado == 1)
        {
            totalPagar += 500;
        }
       }
       return totalPagar;
    }
}