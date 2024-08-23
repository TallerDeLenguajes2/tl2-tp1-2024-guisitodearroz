namespace cadeteria;
public class Cliente
{
    string Nombre;
    string Direccion;
    string telefono;
    DatosRef DatosDeReferencia;

    public Cliente(string nombre, string direccion, string telefono, DatosRef datosDeReferencia)
    {
        Nombre1 = nombre;
        Direccion1 = direccion;
        this.Telefono = telefono;
        DatosDeReferencia1 = datosDeReferencia;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direccion1 { get => Direccion; set => Direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public DatosRef DatosDeReferencia1 { get => DatosDeReferencia; set => DatosDeReferencia = value; }
}