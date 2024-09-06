using System;
using System.Collections.Generic;
using System.IO;

namespace EspacioCadeteria
{
    public class AccesoCSV : AccesoADatos
    {
        public override List<Cadete> CargarCadetes(string ruta)
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (File.Exists(ruta))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 4)
                            {
                                string id = campos[0].Trim();
                                string nombre = campos[1].Trim();
                                string direccion = campos[2].Trim();
                                string telefono = campos[3].Trim();
                                List<Pedido> pedidos = new List<Pedido>();

                                Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                                cadetes.Add(cadete);
                            }
                            else
                            {
                                Console.WriteLine($"Línea de cadete inválida: {linea}");
                            }
                        }
                    }
                    Console.WriteLine("Carga exitosa de cadetes desde CSV.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar los cadetes desde CSV: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadetes CSV.");
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
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        string linea = sr.ReadLine();
                        if (linea != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 2)
                            {
                                string nombre = campos[0].Trim();
                                string telefono = campos[1].Trim();
                                Cadeteria cadeteria = new Cadeteria(nombre, telefono, cadetes);
                                Console.WriteLine("Carga exitosa de cadeteria desde CSV.");
                                return cadeteria;
                            }
                            else
                            {
                                Console.WriteLine("Datos de cadeteria incorrectos en CSV.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El archivo de cadeteria está vacío.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar la cadeteria desde CSV: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadeteria CSV.");
            }

            return null;
        }
    }
}
