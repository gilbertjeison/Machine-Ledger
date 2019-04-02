using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Epps 
    {
        public int id { get; set; }
        public bool sel { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public Image imagen { get; set; }
        public string path_image { get; set; }

        public Epps(int _id,bool s, int c, string n,string p_i)
        {
            id = _id;
            sel = s;
            codigo = c;
            nombre = n;
            path_image = p_i;
        }
    }
}
