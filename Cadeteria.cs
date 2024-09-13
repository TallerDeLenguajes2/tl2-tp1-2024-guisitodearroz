using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Pedido> listadoPedidos = new List<Pedido>();

        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Pedido DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
        {
            Pedido pedido = new Pedido(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado);
            listadoPedidos.Add(pedido);
            return pedido;
        }

        public Cadete CadeteConMenosPedidos()
        {
            if (listadoPedidos == null || listadoPedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos disponibles.");
                return null;
            }

            Dictionary<Cadete, int> cadetePedidoCount = new Dictionary<Cadete, int>();

            foreach (var pedido in listadoPedidos)
            {
                var cadete = pedido.CadeteAsignado;
                if (cadete != null)
                {
                    if (!cadetePedidoCount.ContainsKey(cadete))
                    {
                        cadetePedidoCount[cadete] = 0;
                    }
                    cadetePedidoCount[cadete]++;
                }
            }

            if (cadetePedidoCount.Count == 0)
            {
                Console.WriteLine("No hay cadetes asignados a los pedidos.");
                return null;
            }

            Cadete cadeteConMenosPedidos = cadetePedidoCount.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre} con {cadetePedidoCount[cadeteConMenosPedidos]} pedidos.");

            return cadeteConMenosPedidos;
        }

        public Cadete AsignarPedidoCadete(Pedido pedido, List<Cadete> cadetes)
        {
            if (cadetes == null || cadetes.Count == 0)
            {
                Console.WriteLine("No hay cadetes disponibles.");
                return null;
            }

            if (listadoPedidos == null)
            {
                listadoPedidos = new List<Pedido>();
            }

            pedido.EstadoPedido = Estado.Enviado;
            Cadete cadete = CadeteConMenosPedidos();

            if (cadete != null)
            {
                pedido.CadeteAsignado = cadete;
                Console.WriteLine($"Pedido asignado a {cadete.Nombre}");
            }

            return cadete;
        }

        public double JornalACobrar(string idCadete, List<Cadete> cadetes)
        {
            Cadete cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return 0;
            }

            var pedidosAsignados = listadoPedidos.Where(p => p.CadeteAsignado == cadete).ToList();
            double jornal = pedidosAsignados.Count * 100; // Ejemplo: 100 unidades monetarias por pedido
            return jornal;
        }

        public void MostrarCadeteria()
        {
            Console.WriteLine("\n\nDatos de cadeteria:");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Teléfono: {telefono}");
            Console.WriteLine("Lista de pedidos:");
            foreach (var pedido in listadoPedidos)
            {
                Console.WriteLine($"Pedido {pedido.NumeroPedido}, Estado: {pedido.EstadoPedido}, Cliente: {pedido.Cliente.Nombre}");
            }
        }

        public Pedido BuscarPedidoPorNumero(string numeroPedido)
        {
            return listadoPedidos.FirstOrDefault(p => p.NumeroPedido == numeroPedido);
        }

        public Cadete AsignarCadeteAPedido(string idCadete, string numeroPedido, List<Cadete> cadetes)
        {
            Cadete cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido pedido = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == numeroPedido);

            if (cadete != null && pedido != null)
            {
                pedido.CadeteAsignado = cadete;
                Console.WriteLine($"Pedido {numeroPedido} asignado al cadete {cadete.Nombre}.");
                return cadete;
            }
            else
            {
                Console.WriteLine("Cadete o pedido no encontrado.");
                return null;
            }
        }

        public void CambioDeEstadoDePedido(string numeroPedido, Estado nuevoEstado)
        {
            Pedido pedido = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == numeroPedido);
            if (pedido != null)
            {
                pedido.EstadoPedido = nuevoEstado;
                Console.WriteLine($"Estado del pedido {numeroPedido} cambiado a {nuevoEstado}.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }

        public void EliminarPedido(Pedido pedido)
        {
            if (listadoPedidos.Remove(pedido))
            {
                Console.WriteLine($"Pedido {pedido.NumeroPedido} y su cliente {pedido.Cliente.Nombre} eliminados.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }

        public void ReasignarPedido(Pedido pedido, List<Cadete> cadetes)
        {
            if (pedido.CadeteAsignado != null)
            {
                pedido.CadeteAsignado = null;
            }

            Cadete nuevoCadete = AsignarPedidoCadete(pedido, cadetes);
            if (nuevoCadete != null)
            {
                Console.WriteLine($"Pedido reasignado a {nuevoCadete.Nombre}");
            }
            else
            {
                Console.WriteLine("No hay cadetes disponibles para reasignar el pedido.");
            }
        }

        public void MostrarCadete(string idCadete, List<Cadete> cadetes)
        {
            Cadete cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete != null)
            {
                Console.WriteLine($"ID: {cadete.Id}");
                Console.WriteLine($"Nombre: {cadete.Nombre}");

                double jornal = JornalACobrar(idCadete, cadetes);
                Console.WriteLine($"Jornal a Cobrar: {jornal}");

                var pedidosAsignados = listadoPedidos.Where(p => p.CadeteAsignado == cadete).ToList();
                Console.WriteLine($"Pedidos Asignados:");
                foreach (var pedido in pedidosAsignados)
                {
                    Console.WriteLine($"- Número: {pedido.NumeroPedido}, Estado: {pedido.EstadoPedido}");
                }
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
    }
}
