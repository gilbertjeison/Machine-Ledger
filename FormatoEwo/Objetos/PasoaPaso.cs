using System.Drawing;

namespace FormatoEwo.Objetos
{
    public class PasoaPaso
    {
       
        public string paso { get; set; }
        public int numPaso { get; set; }
        public string desc { get; set; }
        public string duracion { get; set; }
        public string categoria { get; set; }
        public Image categoria_img { get; set; }
        public Image imagen_paso { get; set; }
        public string imagen_paso_path { get; set; }
        public int Id { get; set; }
        public int codigo_herramienta { get; set; }
        public string herramienta { get; set; }
        public int id_smp { get; set; }

    }
}
