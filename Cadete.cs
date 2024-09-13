namespace EspacioCadeteria
{
    public class Cadete
    {
        private string id;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            
        }

        // Propiedades
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

    }
}
