namespace EspacioCadeteria
{
    public abstract class AccesoADatos
    {
        // Métodos que serán implementados por las clases derivadas
        public abstract List<Cadete> CargarCadetes();
        public abstract List<Pedido> CargarPedidos();

        // Método opcional para guardar cadetes/pedidos
        public abstract void GuardarCadetes(List<Cadete> cadetes);
        public abstract void GuardarPedidos(List<Pedido> pedidos);
    }
}
