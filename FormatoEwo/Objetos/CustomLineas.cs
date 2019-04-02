using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FormatoEwo.Objetos
{
    public class CustomLineas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int id_planta { get; set; }
        public string image_path { get; set; }
        public BitmapImage image { get; set; }
        public int cant_mttos { get; set; }
        public int cant_maqs { get; set; }
    }
}
