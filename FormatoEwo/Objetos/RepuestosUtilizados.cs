using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class RepuestosUtilizados
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> cod_sap { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> costo { get; set; }
        public Nullable<int> id_ewo { get; set; }
    }
}
