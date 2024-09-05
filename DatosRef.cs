namespace negocio
{
    public class DatosRef
    {
        public string? Referencia { get; set; }

        public DatosRef(string? referencia)
        {
            Referencia = referencia;
        }

        // Método
        public string ObtenerReferencia()
        {
            return Referencia ?? "No disponible"; // Manejo de null
        }
    }
}
