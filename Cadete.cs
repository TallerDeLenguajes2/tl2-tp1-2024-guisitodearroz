using System;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    public class Cadete
    {
        private string id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> pedidos;

        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.pedidos = new List<Pedido>();
        }

        public string Id 
        { 
            get => id; 
            set => id = value; 
        }

        public string Nombre 
        { 
            get => nombre; 
            set => nombre = value; 
        }

        public string Direccion 
        { 
            get => direccion; 
            set => direccion = value; 
        }

        public string Telefono 
        { 
            get => telefono; 
            set => telefono = value; 
        }

        // Agrega un pedido a la lista de pedidos
        public void AgregarPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                pedidos.Add(pedido);
            }
            else
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
            }
        }

        // Elimina un pedido de la lista de pedidos
        public void EliminarPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                pedidos.Remove(pedido);
            }
            else
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
            }
        }

        public double JornalACobrar()
        {
            const double pagoPorPedido = 500; // Monto por cada pedido
            return pedidos.Count * pagoPorPedido;
        }

        public void MostrarCadete()
        {
            Console.WriteLine($"\n\tId: {Id}");
            Console.WriteLine($"\tNombre: {Nombre}");
            Console.WriteLine($"\tDirección: {Direccion}");
            Console.WriteLine($"\tTeléfono: {Telefono}");
        }
    }
}
