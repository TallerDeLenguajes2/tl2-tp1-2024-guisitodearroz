using System;
using System.Collections.Generic;
using System.IO;

namespace negocio
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listaPedido;

        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listaPedido)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listaPedido = listaPedido;
        }

        // Getters y Setters
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }

        // Métodos
        public int JornalACobrar()
        {
            const int pagoPorPedido = 500;
            int totalPagar = 0;
            foreach (var pedido in listaPedido)
            {
                if (pedido.Estado == Pedido.EstadoPedido.Entregado)
                {
                    totalPagar += pagoPorPedido;
                }
            }
            return totalPagar;
        }

        public void AsignarPedido(Pedido pedido)
        {
            listaPedido.Add(pedido);
            Console.WriteLine($"Pedido {pedido.Numero} asignado a {Nombre}");
        }

        public void MostrarPedidos()
        {
            Console.WriteLine($"\n--------Pedidos del cadete {nombre}--------");
            foreach (var pedido in listaPedido)
            {
                Console.WriteLine($"Numero: {pedido.Numero}, Estado: {pedido.Estado}");
            }
        }

        public void ReasignarPedido(Pedido pedido, Cadete nuevoCadete)
        {
            if (listaPedido.Remove(pedido))
            {
                nuevoCadete.AsignarPedido(pedido);
                Console.WriteLine($"Pedido {pedido.Numero} reasignado a {nuevoCadete.Nombre}");
            }
            else
            {
                Console.WriteLine($"Pedido {pedido.Numero} no encontrado en la lista de pedidos.");
            }
        }
    }
}
