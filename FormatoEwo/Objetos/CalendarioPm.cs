using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace FormatoEwo.Objetos
{
    public class CalendarioPm
    {
        public int id { get; set; }
        public int id_componente { get; set; }
        public int id_ewo { get; set; }
        public int id_tipo_mtto { get; set; }
        public string desc { get; set; }
        public int cantidad { get; set; }
        public int semana { get; set; }
        public int year { get; set; }
        public int duracion_total { get; set; }
        public string observaciones { get; set; }
        public int user_id { get; set; }

        public string image { get; set; }

        public string usuario { get; set; }

        public DateTime creado { get; set; }
    }
}
