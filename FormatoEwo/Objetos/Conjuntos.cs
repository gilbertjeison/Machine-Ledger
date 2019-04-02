using System.Drawing;

namespace FormatoEwo.Objetos
{
    public class Conjuntos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int id_sistema { get; set; }
        public int id_smp { get; set; }
        public string image_path { get; set; }
        public Image image { get; set; }
    }
}