using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EspacioCadeteria
{
    public class AccesoJSON : AccesoADatos
    {
        public override List<Cadete> CargarCadetes(string ruta)
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (File.Exists(ruta))
            {
                try
                {
                    string jsonString = File.ReadAllText(ruta);
                    cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
                    Console.WriteLine("Carga exitosa de cadetes desde JSON.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar los cadetes desde JSON: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadetes JSON.");
                return null;
            }
            return cadetes;
        }

        public override Cadeteria CargarCadeteria(string ruta, List<Cadete> cadetes)
        {
            if (cadetes == null || cadetes.Count == 0)
            {
                Console.WriteLine("No se cargaron cadetes.");
                return null;
            }

            if (File.Exists(ruta))
            {
                try
                {
                    string jsonString = File.ReadAllText(ruta);
                    Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonString);
                    cadeteria.Cadetes = cadetes; // Asegúrate de asignar la lista de cadetes cargados
                    Console.WriteLine("Carga exitosa de cadeteria desde JSON.");
                    return cadeteria;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar la cadeteria desde JSON: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadeteria JSON.");
                return null;
            }

            return null;
        }
    }
}
