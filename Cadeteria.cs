namespace cadeteria;
public class Cadeteria
{
    string Nombre;
    int Telefono;
    List<Cadete> listadoCadetes;
    
    public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
    {
        Nombre = nombre;
        Telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public int Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
}