namespace cadeteria;
public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private DatosRef? datosDeReferencia;

    public Cliente(string nombre, string direccion, string telefono, DatosRef? datosDeReferencia)
    {
        this.Nombre = nombre;
        this.Direccion= direccion;
        this.Telefono = telefono;
        this.DatosDeReferencia = datosDeReferencia;
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
    public DatosRef? DatosDeReferencia{
        get => datosDeReferencia;
        set => datosDeReferencia= value;
    }
    //metodos
    public string ObtenerDescripcionCompleta()
        {
            string descripcion = $"Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}";
            if (DatosDeReferencia != null)
            {
                descripcion += $", Datos de Referencia: {DatosDeReferencia.ObtenerDescripcion()}";
            }
            return descripcion;
        }
}