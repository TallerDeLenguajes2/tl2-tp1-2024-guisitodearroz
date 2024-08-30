namespace cadeteria;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    
    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre=nombre;
        this.telefono=telefono;
        this.listadoCadetes = listadoCadetes;
    }
    //geter u setter
    public string Nombre{
        get => nombre;
        set => nombre= value;
    }
    public string Telefono{
        get => telefono;
        set => telefono= value;
    }
    public List<Cadete> ListadoCadetes{
        get => listadoCadetes;
        set => listadoCadetes= value;
    }

    //metodos
    public void cargarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }
    public void borrarCadetePorId(int idCadete){
        Cadete cadeteEncontrado= null;
        foreach (var cadete in listadoCadetes)
        {
            if (cadete.Id == idCadete)
            {
                cadeteEncontrado= cadete;
                break;
            }
        }
        if (cadeteEncontrado != null)
        {
            listadoCadetes.Remove(cadeteEncontrado);
        }
    }
    public void generarInforme(){
        foreach (var cadete in listadoCadetes)
        {
            Console.WriteLine($"Cadete: {cadete.Nombre}, Pedido Entregados: {cadete.ListaPedido.Count}, Jornel: {cadete.jornalACobrar()}");W
        }
    }















}