namespace cadeteria;
public class Cadete
{
    int Id;
    string Nombre;
    string Direccion;
    int Telefono;
    List<Pedido> listaPedido;

    public Cadete(int id, string nombre, string direccion, int telefono, List<Pedido> listaPedido)
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
    public int Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }
}