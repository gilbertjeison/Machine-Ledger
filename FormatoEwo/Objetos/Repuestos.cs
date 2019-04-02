using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Repuestos
    {
        

        public int Id { get; set; }
        public bool sel { get; set; }
        public string repuesto { get; set; }
        public int cantidad { get; set; }
        public Image imagen { get; set; }
        public string imagen_name { get; set; }
    }
}
