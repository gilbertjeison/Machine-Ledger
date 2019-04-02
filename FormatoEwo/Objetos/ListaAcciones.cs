using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class ListaAcciones
    {
        public Nullable<int> id { get; set; }
        public string accion { get; set; }
        public string tipo_accion { get; set; }
        public string responsable { get; set; }
        public Nullable<DateTime> fecha { get; set; }
        public Nullable<int> id_ewo { get; set; }
    }
}
