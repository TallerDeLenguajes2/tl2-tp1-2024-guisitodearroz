using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes ?? new List<Cadete>();
            this.pedidos = new List<Pedido>();
        }

        public string Nombre 
        { 
            get => nombre; 
            set => nombre = value; 
        }

        public string Telefono 
        { 
            get => telefono; 
            set => telefono = value; 
        }

        public List<Cadete> Cadetes 
        { 
            get => cadetes; 
            private set => cadetes = value; 
        }

        public List<Pedido> Pedidos 
        { 
            get => pedidos; 
            private set => pedidos = value; 
        }

        public Pedido DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
        {
            var pedido = new Pedido(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado);
            pedidos.Add(pedido);
            return pedido;
        }

        public Cadete CadeteConMenosPedidos()
        {
            if (!Cadetes.Any())
            {
                Console.WriteLine("No hay cadetes disponibles.");
                return null;
            }

            var cadeteConMenosPedidos = Cadetes.OrderBy(c => c.Pedidos.Count).FirstOrDefault();
            Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre} con {cadeteConMenosPedidos.Pedidos.Count} pedidos.");
            return cadeteConMenosPedidos;
        }

        public Cadete AsignarPedidoCadete(string idCadete, string nroPedido)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);
            var cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);

            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return null;
            }

            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return null;
            }

            if (pedido.CadeteAsignado != null)
            {
                Console.WriteLine("El pedido ya tiene un cadete asignado.");
                return null;
            }

            pedido.CadeteAsignado = cadete;
            pedido.EstadoPedido = Estado.Enviado;
            cadete.Pedidos.Add(pedido);
            return cadete;
        }

        public double JornalACobrar(string idCadete)
        {
            var cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return 0;
            }

            return cadete.JornalACobrar();
        }

        public void MostrarCadeteria()
        {
            Console.WriteLine("\n\nDatos de la cadetería:");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine("Lista de cadetes:");
            foreach (var cadete in Cadetes)
            {
                cadete.MostrarCadete();
            }
            Console.WriteLine("Lista de pedidos:");
            foreach (var pedido in Pedidos)
            {
                pedido.MostrarPedido();
            }
        }

        public Pedido CambioDeEstadoDePedido(string nroPedido)
        {
            var pedido = Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);

            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return null;
            }

            var estados = new Dictionary<int, Estado>
            {
                { 1, Estado.Entregado },
                { 2, Estado.Enviado },
                { 3, Estado.Rechazado },
                { 4, Estado.Pendiente }
            };

            bool continuar = true;
            do
            {
                Console.WriteLine("\nEstado actual del pedido:");
                foreach (var estado in estados)
                {
                    Console.WriteLine($"{estado.Key}. {estado.Value}");
                }
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione estado: ");

                if (int.TryParse(Console.ReadLine(), out int opcion) && estados.ContainsKey(opcion))
                {
                    pedido.EstadoPedido = estados[opcion];
                    Console.WriteLine($"Estado cambiado a {pedido.EstadoPedido}.");
                }
                else if (opcion == 5)
                {
                    continuar = false;
                    Console.WriteLine("Saliendo del cambio de estado.");
                }
                else
                {
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                }

            } while (continuar);

            return pedido;
        }
    }
}
