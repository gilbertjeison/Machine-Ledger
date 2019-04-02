using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class CustomSMP
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
        public int id_clasificacion { get; set; }
        public string desc_clasificacion { get; set; }
        public int tipo_mtto { get; set; }
        public string desc_tipo_mtto { get; set; }
        public int tecnicos_eq { get; set; }
        public int duracion_actividad { get; set; }
        public int equipo_parado { get; set; }
        public int frecuencia { get; set; }
        public int tipo_frecuencia { get; set; }
        public string desc_tipo_frecuencia { get; set; }
        public int id_elaborador { get; set; }
        public string desc_elaborador { get; set; }
        public int id_aprobador { get; set; }
        public string desc_aprobador { get; set; }
        public bool loto { get; set; }
        public string permisos { get; set; }
        public string imagen_1 { get; set; }
        public string imagen_2 { get; set; }
        public List<smp_util> list_util { get; set; }
        public List<PasoaPaso> list_pasos { get; set; }
        public List<epps> list_epps { get; set; }
        public List<herramientas> list_herramientas { get; set; }
        public List<repuestos_utilizados> list_repuestos { get; set; }
    }
}
