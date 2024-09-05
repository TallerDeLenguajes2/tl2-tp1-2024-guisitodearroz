namespace negocio;
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    
    public Cadeteria(string nombre, string telefono, List<Cadete>? listadoCadetes = null)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes ?? new List<Cadete>();
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
    public void GenerarCadetesAleatorios(int cantidad)
{
    Random random = new Random();
    for (int i = 0; i < cantidad; i++)
    {
        int id = random.Next(1, 1000);
        string nombre = $"Cadete{id}";
        string direccion = $"Calle {random.Next(1, 100)}";
        string telefono = $"123456{random.Next(100, 999)}";

        Cadete nuevoCadete = new Cadete(id, nombre, direccion, telefono, new List<Pedido>());
        listadoCadetes.Add(nuevoCadete);
    }
    Console.WriteLine($"{cantidad} cadetes generados aleatoriamente.");
}
    public void GuardarCadetesEnCSV(string archivoCadetes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoCadetes))
                {
                    foreach (Cadete cadete in listadoCadetes)
                    {
                        string linea = $"{cadete.Id},{cadete.Nombre},{cadete.Direccion},{cadete.Telefono}";
                        sw.WriteLine(linea);
                    }
                }
                Console.WriteLine("Datos de cadetes guardados con éxito en el CSV.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el archivo CSV: " + e.Message);
            }
        }
    public void CargarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }
    public void BorrarCadetePorId(int idCadete)
    {
        Cadete? cadeteEncontrado = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        if (cadeteEncontrado != null)
        {
            listadoCadetes.Remove(cadeteEncontrado);
            Console.WriteLine($"Cadete con ID {idCadete} eliminado.");
        }
        else
        {
            Console.WriteLine($"Cadete con ID {idCadete} no encontrado.");
        }
    }

    public void MostrarCadete(){
        Console.WriteLine("-------Lista de cadetes-------");
        foreach (var cadete in listadoCadetes)
        {
            Console.WriteLine($"ID:{cadete.Id}, Nombre: {cadete.Nombre}");
        }
    }
    public void GenerarInforme(){
        foreach (var cadete in listadoCadetes)
        {
            Console.WriteLine($"Cadete: {cadete.Nombre}, Pedido Entregados: {cadete.ListaPedido.Count}, Jornel: {cadete.JornalACobrar()}");
        }
    }
}