using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Objetos
{
    public class Ewo
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> consecutivo { get; set; }
        public Nullable<int> id_area_linea { get; set; }	
        public Nullable<int> id_equipo { get; set; }	
        public Nullable<DateTime> fecha_ewo { get; set; }
        public Nullable<int> aviso_numero	{ get; set; }
        public Nullable<int> id_tecnico { get; set; }
        public Nullable<int> id_tipo_averia { get; set; }	
        public Nullable<int> id_turno { get; set; }	
        public Nullable<DateTime> notificacion_averia	{ get; set; }
        public Nullable<DateTime> inicio_reparacion { get; set; }
        public Nullable<int> tiempo_espera_tecnico { get; set; }
        public Nullable<int> tiempo_diagnostico { get; set; }
        public Nullable<int> tiempo_espera_repuestos { get; set; }
        public Nullable<int> tiempo_reparacion { get; set; }	
        public Nullable<int> tiempo_pruebas { get; set; }	
        public Nullable<DateTime> fin_reparacion { get; set; }
        public int tiempo_total	{ get; set; }
        public string imagen_1 { get; set; }
        public string imagen_2 { get; set; }
        public string desc_imagen_1	{ get; set; }
        public string desc_imagen_2	{ get; set; }
        public string desc_averia { get; set; }	
        public bool cambio_componente { get; set; }
        public bool ajuste { get; set; }
        public string what { get; set; }
        public string where	{ get; set; }
        public string when { get; set; }
        public string who { get; set; }	
        public string wich { get; set; }	
        public string how { get; set; }
        public string fenomeno { get; set; }	
        public string gemba	{ get; set; }
        public bool gemba_ok { get; set; }
        public string gembutsu { get; set; }
        public bool gembutsu_ok	{ get; set; }
        public string genjitsu { get; set; }
        public bool genjitsu_ok	{ get; set; }
        public string genri { get; set; }
        public bool genri_ok { get; set; }	
        public string gensoku { get; set; }	
        public bool gensoku_ok{ get; set; }
        public string imagen_3 { get; set; }
        public string imagen_4 { get; set; }
        public string desc_imagen_3	{ get; set; }
        public string desc_imagen_4	{ get; set; }
        public Nullable<DateTime> fecha_ultimo_mtto { get; set; }
        public Nullable<DateTime> fecha_proximo_mtto { get; set; }	
        public Nullable<int> falla_index { get; set; }
        public string causa_raiz_index { get; set; }	
        public string tecnicos_man_involucrados	{ get; set; }
        public string operarios_involucrados { get; set; }
        public string elaborador_analisis { get; set; }	
        public Nullable<DateTime> fecha_analisis { get; set; }
        public string definidor_contramedidas { get; set; }
        public Nullable<DateTime> fecha_contramedida { get; set; }
        public string validador_ejecucion { get; set; }
        public Nullable<DateTime> fecha_validacion { get; set; }
        
    }
}
