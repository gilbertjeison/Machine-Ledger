using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Smp
    {
        public int id { get; set; }
        public int consecutivo { get; set; }
        public string nombre { get; set; }
        public int numero { get; set; }
        public int id_linea { get; set; }
        public string desc_linea { get; set; }
        public int id_equipo { get; set; }
        public string desc_equipo { get; set; }
        public DateTime fecha_smp { get; set; }
        public string clasificacion { get; set; }
        public string tipo_mtto { get; set; }
        public int tecnicos_eq { get; set; }
        public int duracion_actividad { get; set; }
        public int equipo_parado { get; set; }
        public int frecuencia { get; set; }
        public string tipo_frecuencia { get; set; }
        public int id_elaborador { get; set; }
        public int id_aprobador { get; set; }
        public bool loto { get; set; }
        public string permisos { get; set; }
        public string imagen_1 { get; set; }
        public string imagen_2 { get; set; }
    }
}
