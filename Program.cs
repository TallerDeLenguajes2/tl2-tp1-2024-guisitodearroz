using EspacioCadeteria;
using System;
using System.Collections.Generic;
using System.Linq;

static void Main(string[] args)
{
    try
    {
        AccesoCSV accesoCSV = new AccesoCSV();
        List<Cadete> cadetes = accesoCSV.CargarCadetes();
        List<Pedido> pedidos = accesoCSV.CargarPedidos();
        Cadeteria cadeteria = accesoCSV.CargarCadeteria();

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Dar de alta un pedido");
            Console.WriteLine("2. Asignar pedido a cadete");
            Console.WriteLine("3. Cambiar estado del pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Mostrar informe");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Ingrese un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    DarDeAltaPedido(cadeteria, accesoCSV);
                    break;
                case 2:
                    AsignarPedidoCadete(cadeteria, accesoCSV);
                    break;
                case 3:
                    CambiarEstadoPedido(cadeteria, accesoCSV);
                    break;
                case 4:
                    ReasignarPedido(cadeteria, accesoCSV);
                    break;
                case 5:
                    MostrarInforme(cadeteria);
                    break;
                case 6:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se ha producido un error: {ex.Message}");
    }
}

static void DarDeAltaPedido(Cadeteria cadeteria, AccesoCSV accesoCSV)
{
    Console.Write("Número del pedido: ");
    string nro = Console.ReadLine();
    Console.Write("Observaciones: ");
    string obs = Console.ReadLine();
    Console.Write("Nombre del cliente: ");
    string nombre = Console.ReadLine();
    Console.Write("Dirección del cliente: ");
    string direccion = Console.ReadLine();
    Console.Write("Teléfono del cliente: ");
    string telefono = Console.ReadLine();
    Console.Write("Datos de referencia de dirección del cliente: ");
    string datosRef = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nro) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono))
    {
        Console.WriteLine("Todos los campos son obligatorios.");
        return;
    }

    Pedido nuevoPedido = cadeteria.DarDeAltaPedido(nro, obs, nombre, direccion, telefono, datosRef, Estado.Pendiente);
    Console.WriteLine("Pedido creado con éxito.");

    // Guardar los cambios en los archivos
    accesoCSV.GuardarCadetes(cadeteria.Cadetes);
    accesoCSV.GuardarPedidos(cadeteria.Pedidos);
}

static void AsignarPedidoCadete(Cadeteria cadeteria, AccesoCSV accesoCSV)
{
    Console.Write("Número del pedido a asignar: ");
    string nroPedido = Console.ReadLine();

    // Buscar el pedido en la lista de pedidos
    Pedido pedido = cadeteria.BuscarPedidoPorNumero(nroPedido);

    if (pedido == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    // Asignar el pedido al cadete
    Cadete cadete = cadeteria.AsignarPedidoCadete(pedido);
    if (cadete != null)
    {
        Console.WriteLine($"Pedido asignado al cadete {cadete.Nombre}.");
        // Guardar los cambios en los archivos
        accesoCSV.GuardarCadetes(cadeteria.Cadetes);
        accesoCSV.GuardarPedidos(cadeteria.Pedidos);
    }
    else
    {
        Console.WriteLine("No hay cadetes disponibles.");
    }
}

static void CambiarEstadoPedido(Cadeteria cadeteria, AccesoCSV accesoCSV)
{
    Console.Write("Número del pedido para cambiar el estado: ");
    string nroPedido = Console.ReadLine();

    // Buscar el pedido en todos los cadetes
    Pedido pedido = cadeteria.Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);
    if (pedido != null)
    {
        cadeteria.CambioDeEstadoDePedido(pedido);
        Console.WriteLine("Estado del pedido cambiado con éxito.");

        // Guardar los cambios en los archivos
        accesoCSV.GuardarCadetes(cadeteria.Cadetes);
        accesoCSV.GuardarPedidos(cadeteria.Pedidos);
    }
    else
    {
        Console.WriteLine("Pedido no encontrado.");
    }
}

static void ReasignarPedido(Cadeteria cadeteria, AccesoCSV accesoCSV)
{
    Console.Write("Número del pedido a reasignar: ");
    string nroPedido = Console.ReadLine();

    // Buscar el pedido en todos los cadetes
    Pedido pedido = cadeteria.Pedidos.FirstOrDefault(p => p.NumeroPedido == nroPedido);
    if (pedido == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    // Eliminar el pedido del cadete actual
    foreach (var cadete in cadeteria.Cadetes)
    {
        if (cadete.Pedidos.Remove(pedido))
        {
            // Asignar el pedido al nuevo cadete
            Cadete nuevoCadete = cadeteria.AsignarPedidoCadete(pedido);
            if (nuevoCadete != null)
            {
                Console.WriteLine($"Pedido reasignado al cadete {nuevoCadete.Nombre}.");
                // Guardar los cambios en los archivos
                accesoCSV.GuardarCadetes(cadeteria.Cadetes);
                accesoCSV.GuardarPedidos(cadeteria.Pedidos);
            }
            else
            {
                Console.WriteLine("No hay cadetes disponibles para reasignar el pedido.");
            }
            return;
        }
    }

    Console.WriteLine("No se pudo encontrar el cadete actual del pedido.");
}

static void MostrarInforme(Cadeteria cadeteria)
{
    double totalGanado = 0;
    int totalPedidos = 0;
    foreach (var cadete in cadeteria.Cadetes)
    {
        double jornal = cadeteria.JornalACobrar(cadete); // Cambiar esta línea según la implementación de AccesoCSV
        totalGanado += jornal;
        totalPedidos += cadete.Pedidos.Count;
        Console.WriteLine($"Cadete: {cadete.Nombre}, Pedidos: {cadete.Pedidos.Count}, Jornal: {jornal}");
    }

    int cantidadCadetes = cadeteria.Cadetes.Count;
    double promedioPedidos = (cantidadCadetes > 0) ? (double)totalPedidos / cantidadCadetes : 0;

    Console.WriteLine($"\nTotal ganado: {totalGanado}");
    Console.WriteLine($"Cantidad total de envíos: {totalPedidos}");
    Console.WriteLine($"Promedio de envíos por cadete: {promedioPedidos}");
}
