using System;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    public abstract class AccesoADatos
    {
        public abstract List<Cadete> CargarCadetes(string ruta);
        public abstract Cadeteria CargarCadeteria(string ruta, List<Cadete> cadetes);
    }
}
