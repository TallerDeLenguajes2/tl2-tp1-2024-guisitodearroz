using EspacioCadeteria;
using System;
using System.Collections.Generic;

        List<Cadete> cadetes = ManejadorDeCsv.CargaDeCadetes("Cadetes.csv");
        Cadeteria cadeteria = ManejadorDeCsv.CargaDeCadeteria("Cadeteria.csv", cadetes);

        cadeteria.MostrarCadeteria();

        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    DarDeAltaPedido(cadeteria);
                    break;

                case "2":
                    AsignarPedido(cadeteria, cadetes);
                    break;

                case "3":
                    CambiarEstadoPedido(cadeteria);
                    break;

                case "4":
                    ReasignarPedido(cadeteria, cadetes);
                    break;

                case "5":
                    DarDeAltaCadete(cadetes);
                    break;

                case "6":
                    cadeteria.MostrarCadeteria();
                    break;

                case "7":
                    continuar = false;
                    Console.WriteLine("Saliendo del sistema de gestión de pedidos.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n\n=== Sistema de Gestión de Pedidos ===");
        Console.WriteLine("1. Dar de alta pedidos");
        Console.WriteLine("2. Asignar pedidos a cadetes");
        Console.WriteLine("3. Cambiar estado de un pedido");
        Console.WriteLine("4. Reasignar pedido a otro cadete");
        Console.WriteLine("5. Dar de alta cadete");
        Console.WriteLine("6. Mostrar cadetería");
        Console.WriteLine("7. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void DarDeAltaPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Dar de alta pedidos");

        Console.Write("Ingrese el número del pedido: ");
        string nroPedido = Console.ReadLine();
        Console.Write("Ingrese observaciones: ");
        string observaciones = Console.ReadLine();
        Console.Write("Ingrese nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.Write("Ingrese dirección del cliente: ");
        string direccionCliente = Console.ReadLine();
        Console.Write("Ingrese teléfono del cliente: ");
        string telefonoCliente = Console.ReadLine();
        Console.Write("Ingrese datos de referencia de la dirección: ");
        string datosRefCliente = Console.ReadLine();

        try
        {
            Pedido pedido = cadeteria.DarDeAltaPedido(
                nroPedido, observaciones, nombreCliente, direccionCliente, telefonoCliente, datosRefCliente, Estado.Pendiente
            );
            Console.WriteLine("Pedido dado de alta exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al dar de alta el pedido: " + ex.Message);
        }
    }

    static void AsignarPedido(Cadeteria cadeteria, List<Cadete> cadetes)
    {
        Console.WriteLine("\nAsignar pedidos a cadetes");
        if (cadeteria.Pedidos.Count > 0 && cadetes.Count > 0)
        {
            Console.Write("Ingrese el número del pedido a asignar: ");
            string nroPedidoAAsignar = Console.ReadLine();

            Pedido pedidoAAsignar = cadeteria.Pedidos.Find(p => p.NumeroPedido == nroPedidoAAsignar);
            if (pedidoAAsignar != null)
            {
                try
                {
                    cadeteria.AsignarPedidoCadete(pedidoAAsignar.NumeroPedido, cadeteria.CadeteConMenosPedidos().Id);
                    Console.WriteLine("Pedido asignado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar el pedido: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("No hay pedidos o cadetes disponibles.");
        }
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("Cambiar estado de un pedido");
        if (cadeteria.Pedidos.Count > 0)
        {
            Console.Write("Ingrese el número del pedido a modificar: ");
            string nroPedidoModificar = Console.ReadLine();

            Pedido pedidoModificar = cadeteria.Pedidos.Find(p => p.NumeroPedido == nroPedidoModificar);
            if (pedidoModificar != null)
            {
                try
                {
                    cadeteria.CambioDeEstadoDePedido(nroPedidoModificar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cambiar el estado del pedido: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("No hay pedidos disponibles.");
        }
    }

    static void ReasignarPedido(Cadeteria cadeteria, List<Cadete> cadetes)
    {
        Console.WriteLine("Reasignar pedido a otro cadete");
        if (cadeteria.Pedidos.Count > 0 && cadetes.Count > 1)
        {
            Console.Write("Ingrese el número del pedido a reasignar: ");
            string nroPedidoReasignar = Console.ReadLine();

            Pedido pedidoReasignar = cadeteria.Pedidos.Find(p => p.NumeroPedido == nroPedidoReasignar);
            if (pedidoReasignar != null)
            {
                Console.Write("Ingrese el ID del nuevo cadete: ");
                string idNuevoCadete = Console.ReadLine();

                try
                {
                    cadeteria.AsignarPedidoCadete(idNuevoCadete, nroPedidoReasignar);
                    Console.WriteLine("Pedido reasignado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al reasignar el pedido: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("No hay suficientes cadetes o pedidos para reasignar.");
        }
    }

    static void DarDeAltaCadete(List<Cadete> cadetes)
    {
        Console.WriteLine("Dar de alta a un cadete");

        Console.Write("Ingrese el nombre del cadete: ");
        string nombreCadete = Console.ReadLine();
        Console.Write("Ingrese el teléfono del cadete: ");
        string telefonoCadete = Console.ReadLine();

        try
        {
            Cadete nuevoCadete = new Cadete(nombreCadete, telefonoCadete, new List<Pedido>());
            cadetes.Add(nuevoCadete);
            Console.WriteLine("Cadete dado de alta exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al dar de alta el cadete: " + ex.Message);
        }