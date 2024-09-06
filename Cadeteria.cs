
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
        private List<Pedido> pedidos; // Nueva propiedad para el listado de pedidos

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
            this.pedidos = new List<Pedido>(); // Inicializa la lista de pedidos
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; } // Propiedad pública para el listado de pedidos

        public Pedido DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
        {
            Pedido pedido = new Pedido(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado);
            pedidos.Add(pedido); // Agrega el nuevo pedido a la lista de pedidos
            return pedido;
        }

        public Cadete CadeteConMenosPedidos()
        {
            Cadete cadeteConMenosPedidos = Cadetes.MinBy(cadete => cadete.Pedidos.Count);
            if (cadeteConMenosPedidos != null)
            {
                Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre} con {cadeteConMenosPedidos.Pedidos.Count} pedidos.");
            }
            else
            {
                Console.WriteLine("No hay cadetes disponibles.");
            }
            return cadeteConMenosPedidos;
        }

        public Cadete AsignarPedidoCadete(string idCadete, string nroPedido)
        {
            Pedido pedido = Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);
            Cadete cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);

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

            pedido.CadeteAsignado = cadete; // Asigna el cadete al pedido
            pedido.EstadoPedido = Estado.Enviado; // Cambia el estado del pedido a Enviado
            cadete.Pedidos.Add(pedido); // Agrega el pedido a la lista de pedidos del cadete
            return cadete;
        }

        public double JornalACobrar(string idCadete)
        {
            Cadete cadete = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return 0;
            }

            return cadete.Pedidos.Count * 500; // Calcula el pago total del cadete
        }

        public void MostrarCadeteria()
        {
            System.Console.WriteLine("\n\nDatos de la cadeteria:");
            System.Console.WriteLine("Nombre: " + Nombre);
            System.Console.WriteLine("Telefono: " + Telefono);
            System.Console.WriteLine("Lista de cadetes: ");
            foreach (var cadete in Cadetes)
            {
                cadete.MostrarCadete();
            }
            System.Console.WriteLine("Lista de pedidos: ");
            foreach (var pedido in Pedidos)
            {
                pedido.MostrarPedido();
            }
        }

        public Pedido CambioDeEstadoDePedido(string nroPedido)
        {
            Pedido pedido = Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);

            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return null;
            }

            bool continuar = true;
            do
            {
                System.Console.WriteLine("\nEstado actual del pedido?");
                Console.WriteLine("1. Entregado");
                Console.WriteLine("2. Enviado");
                Console.WriteLine("3. Rechazado");
                Console.WriteLine("4. Pendiente");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione estado: ");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        pedido.EstadoPedido = Estado.Entregado;
                        Console.WriteLine("Estado cambiado a Entregado.");
                        break;
                    case 2:
                        pedido.EstadoPedido = Estado.Enviado;
                        Console.WriteLine("Estado cambiado a Enviado.");
                        break;
                    case 3:
                        pedido.EstadoPedido = Estado.Rechazado;
                        Console.WriteLine("Estado cambiado a Rechazado.");
                        break;
                    case 4:
                        pedido.EstadoPedido = Estado.Pendiente;
                        Console.WriteLine("Estado cambiado a Pendiente.");
                        break;
                    case 5:
                        continuar = false;
                        Console.WriteLine("Saliendo del cambio de estado.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }

            } while (continuar);

            return pedido;
        }
    }
}
