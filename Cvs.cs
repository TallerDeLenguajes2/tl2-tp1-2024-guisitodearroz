namespace cadeteria;
class Cvs
{
     public static List<Cadete> CargarCadetesDesdeCSV(string archivoCadetes)
        {
            List<Cadete> cadetes = new List<Cadete>();

            try
            {
                using (StreamReader sr = new StreamReader(archivoCadetes))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(','); // Asumimos que los datos están separados por comas
                        int id = int.Parse(datos[0]);
                        string nombre = datos[1];
                        string direccion = datos[2];
                        string telefono = datos[3];
                        List<Pedido> pedidos = new List<Pedido>(); // Los pedidos pueden cargarse luego

                        Cadete cadete = new Cadete(id, nombre, direccion, telefono, pedidos);
                        cadetes.Add(cadete);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar el archivo CSV: " + e.Message);
            }

            return cadetes;
        }

        // Guardar Cadetes en un archivo CSV
        public static void GuardarCadetesEnCSV(string archivoCadetes, List<Cadete> cadetes)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoCadetes))
                {
                    foreach (Cadete cadete in cadetes)
                    {
                        string linea = $"{cadete.Id},{cadete.Nombre},{cadete.Direccion},{cadete.Telefono}";
                        sw.WriteLine(linea);
                    }
                }
                Console.WriteLine("Datos de cadetes guardados con éxito.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al guardar el archivo CSV: " + e.Message);
            }
        }
}