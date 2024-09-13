using System.Text.Json;

namespace EspacioCadeteria;
public class AccesoJSON : AccesoADatos
{
    private string rutaCadetes = "archivosJson/cadetes.json";
    private string rutaPedidos = "archivosJson/pedidos.json";

    public override List<Cadete> CargarCadetes()
    {
        if (File.Exists(rutaCadetes))
        {
            string json = File.ReadAllText(rutaCadetes);
            return JsonSerializer.Deserialize<List<Cadete>>(json);
        }
        return new List<Cadete>();
    }

    public override List<Pedido> CargarPedidos()
    {
        if (File.Exists(rutaPedidos))
        {
            string json = File.ReadAllText(rutaPedidos);
            return JsonSerializer.Deserialize<List<Pedido>>(json);
        }
        return new List<Pedido>();
    }

    public override void GuardarCadetes(List<Cadete> cadetes)
    {
        string json = JsonSerializer.Serialize(cadetes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(rutaCadetes, json);
    }

    public override void GuardarPedidos(List<Pedido> pedidos)
    {
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(rutaPedidos, json);
    }
}
