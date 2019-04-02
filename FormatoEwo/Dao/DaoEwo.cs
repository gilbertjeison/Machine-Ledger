
using System.Data;
using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoEwo 
    {
        DataTable dt = new DataTable();
        FormatoEwo.EwoDatabaseDataSet.ewosDataTable dtCons = new EwoDatabaseDataSet.ewosDataTable();
        EwoDatabaseDataSetTableAdapters.ewosTableAdapter eta = new ewosTableAdapter();
        
        public int GetLastId()
        {
            return (int)eta.IdByConsecutivo(GetLastConsecutive());            
        }

        public int GetLastConsecutive()
        {
            return (int)eta.ScalarQuery() + 1;
        }

        public int AddEwo(Ewo e)
        {
            int res = 0;
            if (e != null)
            {
              res = eta.Insert(e.consecutivo, 
                    e.id_area_linea, 
                    e.id_equipo,
                    e.fecha_ewo, 
                    e.aviso_numero,
                    e.id_tecnico,
                    e.id_tipo_averia,
                    e.id_turno, 
                    e.notificacion_averia,
                    e.inicio_reparacion, 
                    e.tiempo_espera_tecnico, 
                    e.tiempo_diagnostico, 
                    e.tiempo_espera_repuestos, 
                    e.tiempo_reparacion, 
                    e.tiempo_pruebas,
                    e.fin_reparacion, 
                    e.tiempo_total, 
                    e.imagen_1, 
                    e.imagen_2, 
                    e.desc_imagen_1, 
                    e.desc_imagen_2, 
                    e.desc_averia, 
                    e.cambio_componente, 
                    e.ajuste,
                    e.what, 
                    e.where, 
                    e.when,
                    e.who,
                    e.wich,
                    e.how,
                    e.fenomeno,
                    e.gemba,
                    e.gemba_ok, 
                    e.gembutsu,
                    e.gembutsu_ok,
                    e.genjitsu,
                    e.genjitsu_ok,
                    e.genri,
                    e.genri_ok,
                    e.gensoku,
                    e.gensoku_ok,
                    e.imagen_3,
                    e.imagen_4,
                    e.desc_imagen_3,
                    e.desc_imagen_4,
                    e.fecha_proximo_mtto,
                    e.fecha_ultimo_mtto,
                    e.falla_index,
                    int.Parse(e.causa_raiz_index),
                    e.tecnicos_man_involucrados,
                    e.operarios_involucrados,
                    e.elaborador_analisis,
                    e.fecha_analisis,
                    e.definidor_contramedidas,
                    e.fecha_contramedida,
                    e.validador_ejecucion,
                    e.fecha_validacion);
            }

            return res;
        }

        public Ewo ConsultarEwoById(int id)
        {
            Ewo e = new Ewo();
            ewosDataTable edt = null;

            edt = eta.GetDataById(id);

            if (edt.Rows.Count > 0)
            {
                e.id = int.Parse(edt.Rows[0]["Id"].ToString());
                e.tiempo_total = int.Parse(edt.Rows[0]["tiempo_total"].ToString());
            }

            return e;
        }

        public int ConsultarEwoDuracionTotal(int id)
        {
            int duracion = 0;
            ewosDataTable edt = null;

            edt = eta.GetDataById(id);

            if (edt.Rows.Count > 0)
            {                
                duracion = int.Parse(edt.Rows[0]["tiempo_total"].ToString());
            }
            
            return duracion;
        }
    }
}
