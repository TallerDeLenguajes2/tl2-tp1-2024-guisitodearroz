namespace cadeteria;
public class Pedido
{
    int numero;
    string? observaciones;
    Cliente cliente;
    int estado;

    public Pedido(int numero, string observaciones, Cliente cliente, int estado)
    {
        this.Numero = numero;
        this.Observaciones = observaciones;
        this.Cliente = cliente;
        this.Estado = estado;
    }

    public int Numero { get => numero; set => numero = value; }
    public string Observaciones { get => observaciones; set => observaciones = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public int Estado { get => estado; set => estado = value; }
}