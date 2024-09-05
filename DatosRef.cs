namespace negocio;
public class DatosRef
{
    private string? referencia;

    public DatosRef(string? referencia)
    {
        this.referencia = referencia;
    }
    //metodo
    public string obtenerReferencia(){
        return referencia;
    }

}