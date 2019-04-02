using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Machines
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }
        public int id_planta { get; set; }
        public int id_linea { get; set; }
        public Image foto_max { get; set; }
    }
}
