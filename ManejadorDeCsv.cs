using System;
using System.Collections.Generic;
using System.IO;

namespace EspacioCadeteria
{
    public class ManejadorDeCsv
    {
        /// <summary>
        /// Carga una lista de cadetes desde un archivo CSV.
        /// </summary>
        /// <param name="rutaCadete">Ruta del archivo CSV con los datos de los cadetes.</param>
        /// <returns>Lista de cadetes cargados, o null si ocurre un error.</returns>
        public static List<Cadete> CargaDeCadetes(string rutaCadete)
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (ExisteArchivo(rutaCadete))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaCadete, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 4)
                            {
                                string id = campos[0];
                                string nombre = campos[1];
                                string direccion = campos[2];
                                string telefono = campos[3];
                                List<Pedido> pedidos = new List<Pedido>();

                                Cadete cadete = new Cadete(id, nombre, direccion, telefono, pedidos);
                                cadetes.Add(cadete);
                            }
                            else
                            {
                                Console.WriteLine("Formato de línea incorrecto en el archivo de cadetes.");
                            }
                        }
                    }
                    Console.WriteLine("Carga exitosa de cadetes.");
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine("Error de E/S al cargar los cadetes: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar los cadetes: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadetes.");
            }
            return cadetes;
        }

        /// <summary>
        /// Carga la información de la cadetería desde un archivo CSV.
        /// </summary>
        /// <param name="rutaCadeteria">Ruta del archivo CSV con los datos de la cadetería.</param>
        /// <param name="cadetes">Lista de cadetes a asociar con la cadetería.</param>
        /// <returns>Instancia de Cadeteria cargada, o null si ocurre un error.</returns>
        public static Cadeteria CargaDeCadeteria(string rutaCadeteria, List<Cadete> cadetes)
        {
            if (cadetes == null || cadetes.Count == 0)
            {
                Console.WriteLine("No se cargaron cadetes.");
                return null;
            }

            if (ExisteArchivo(rutaCadeteria))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaCadeteria, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        if ((linea = sr.ReadLine()) != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 2)
                            {
                                string nombre = campos[0];
                                string telefono = campos[1];
                                Cadeteria cadeteria = new Cadeteria(nombre, telefono, cadetes);
                                Console.WriteLine("Carga exitosa de cadeteria.");
                                return cadeteria;
                            }
                            else
                            {
                                Console.WriteLine("Datos de cadeteria incorrectos en el archivo.");
                            }
                        }
                    }
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine("Error de E/S al cargar la cadeteria: " + ioEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar la cadeteria: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadeteria.");
            }
            return null;
        }

        /// <summary>
        /// Verifica si el archivo existe en la ruta especificada.
        /// </summary>
        /// <param name="ruta">Ruta del archivo a verificar.</param>
        /// <returns>True si el archivo existe, false en caso contrario.</returns>
        public static bool ExisteArchivo(string ruta)
        {
            return File.Exists(ruta);
        }
    }
}
