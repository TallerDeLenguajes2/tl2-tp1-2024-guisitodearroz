using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioCadeteria
{
    public class Cadete
    {
        private string id;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        // Método para calcular el jornal a cobrar por el cadete basado en los pedidos
        public double JornalACobrar(List<Pedido> pedidos)
        {
            double pagoPorPedido = 500; // Monto por cada pedido
            int contador = pedidos.Count(p => p.Cadete != null && p.Cadete.Id == id);
            return contador * pagoPorPedido;
        }

        // Método para mostrar la información del cadete
        public void MostrarCadete()
        {
            System.Console.WriteLine($"\n\tId: {Id}");
            System.Console.WriteLine($"\tNombre: {Nombre}");
            System.Console.WriteLine($"\tDireccion: {Direccion}");
            System.Console.WriteLine($"\tTelefono: {Telefono}");
        }
    }
}
