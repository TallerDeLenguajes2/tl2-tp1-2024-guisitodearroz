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
                    
                    // Verificar si la deserialización fue exitosa
                    if (cadetes == null)
                    {
                        Console.WriteLine("Error al deserializar los cadetes desde JSON.");
                        return null;
                    }

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

                    // Verificar si la deserialización fue exitosa
                    if (cadeteria == null)
                    {
                        Console.WriteLine("Error al deserializar la cadeteria desde JSON.");
                        return null;
                    }

                    cadeteria.Cadetes = cadetes; // Asigna la lista de cadetes cargados
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
        }
    }
}
