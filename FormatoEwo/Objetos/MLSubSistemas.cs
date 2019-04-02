using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Sistemas
    {
        public int id { get; set; }        
        public string nombre { get; set; }
        public int id_machine { get; set; }
        public string image_path { get; set; }
        public Image image { get; set; }
    }
}
