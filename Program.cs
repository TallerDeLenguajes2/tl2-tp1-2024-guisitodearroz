using negocio;

Cadeteria cadeteria = new Cadeteria("OKA", "02221111", new List<Cadete>());
const string archivoCadetes = "cadetes.csv";

// Cargar cadetes desde el archivo CSV si existe
if (File.Exists(archivoCadetes))
{
    var cadetesCargados = Cvs.CargarCadetesDesdeCSV(archivoCadetes);
    foreach (var cadete in cadetesCargados)
    {
        cadeteria.CargarCadete(cadete);
    }
}

AltaPedido.Iniciar(cadeteria);

int opcion;
do
{
    Console.Clear();
    Console.WriteLine("=== Menu Cadetería ===");
    Console.WriteLine("1. Dar de alta pedidos");
    Console.WriteLine("2. Asignar pedido a cadete");
    Console.WriteLine("3. Cambiar estado del pedido");
    Console.WriteLine("4. Reasignar pedido a otro cadete");
    Console.WriteLine("5. Mostrar informe");
    Console.WriteLine("6. Generar cadetes aleatorios");
    Console.WriteLine("0. Salir y Guardar");
    Console.Write("Seleccione una opción: ");

    // Manejo de excepciones para entrada del usuario
    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Entrada inválida. Por favor ingrese un número.");
        opcion = -1; // Para asegurarse de que el menú se muestre nuevamente
        continue;
    }

    switch (opcion)
    {
        case 1:
            AltaPedido.DarDeAltaPedidos();
            break;
        case 2:
            AltaPedido.AsignarPedidoACadete(null); // Reemplazar null con un valor adecuado o eliminar si no es necesario
            break;
        case 3:
            AltaPedido.CambiarEstadoPedido();
            break;
        case 4:
            AltaPedido.ReasignarPedido();
            break;
        case 5:
            cadeteria.GenerarInforme();
            break;
        case 6:
            GenerarCadetesAleatorios(cadeteria);
            break;
        case 0:
            // Guardar cadetes en el archivo CSV
            Cvs.GuardarCadetesEnCSV(archivoCadetes, cadeteria.ListadoCadetes);
            Console.WriteLine("Datos guardados y saliendo del sistema...");
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    if (opcion != 0)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
} while (opcion != 0);

// Método para generar cadetes aleatorios
static void GenerarCadetesAleatorios(Cadeteria cadeteria)
{
    Console.Write("¿Cuántos cadetes desea generar? ");
    if (int.TryParse(Console.ReadLine(), out int cantidad))
    {
        cadeteria.GenerarCadetesAleatorios(cantidad);
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor ingrese un número.");
    }
}
