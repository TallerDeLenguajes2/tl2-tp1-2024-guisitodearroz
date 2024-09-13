namespace EspacioCadeteria
{
    public class AccesoCSV : AccesoADatos
    {
        private string rutaCadetes = "archivosCsv/cadetes.csv";
        private string rutaPedidos = "archivosCsv/pedidos.csv";
        private string rutaCadeteria = "archivosCsv/cadeteria.csv";

        public override List<Cadete> CargarCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (File.Exists(rutaCadetes))
            {
                using (var reader = new StreamReader(rutaCadetes))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Cadete cadete = new Cadete(values[0], values[1], values[2], values[3]);
                        cadetes.Add(cadete);
                    }
                }
            }
            return cadetes;
        }

        public override List<Pedido> CargarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (File.Exists(rutaPedidos))
            {
                using (var reader = new StreamReader(rutaPedidos))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Pedido pedido = new Pedido(values[0], values[1], values[2], values[3], values[4], values[5], (Estado)Enum.Parse(typeof(Estado), values[6]));
                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }

        public override void GuardarCadetes(List<Cadete> cadetes)
        {
            using (var writer = new StreamWriter(rutaCadetes))
            {
                foreach (var cadete in cadetes)
                {
                    writer.WriteLine($"{cadete.Id},{cadete.Nombre},{cadete.Direccion},{cadete.Telefono}");
                }
            }
        }

        public override void GuardarPedidos(List<Pedido> pedidos)
        {
            using (var writer = new StreamWriter(rutaPedidos))
            {
                foreach (var pedido in pedidos)
                {
                    writer.WriteLine($"{pedido.NumeroPedido},{pedido.Observaciones},{pedido.Cliente.Nombre},{pedido.Cliente.Direccion},{pedido.Cliente.Telefono},{pedido.Cliente.DatosReferenciaDireccion},{pedido.EstadoPedido}");
                }
            }
        }

        public Cadeteria CargarCadeteria()
        {
           
            if (File.Exists(rutaCadeteria))
            {
                using (var reader = new StreamReader(rutaCadeteria))
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        string nombre = values[0];
                        string telefono = values[1];
                        return new Cadeteria(nombre, telefono);
                    }
                }
            }
            return null; 
        }
    }
}
