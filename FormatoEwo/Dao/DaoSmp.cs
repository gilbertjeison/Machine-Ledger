using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormatoEwo.Dao
{
    public class DaoSmp
    {
        DataTable dt = new DataTable();
        FormatoEwo.EwoDatabaseDataSet.smpDataTable dtSmp = new EwoDatabaseDataSet.smpDataTable();
        smpTableAdapter sta = new smpTableAdapter();
        smp_utilTableAdapter suta = new smp_utilTableAdapter();

        //public int GetLastId()
        //{
        //    return (int)eta.IdByConsecutivo(GetLastConsecutive());
        //}

        public int GetLastConsecutive()
        {
            if (sta.ScalarQuery() == null)
            {
                return 1;
            }
            else
            {
                return (int)sta.ScalarQuery() + 1;
            }            
        }

        public int AddSmp(Smp s)
        {
            int res = 0;
            if (s != null)
            {
               res = sta.Insert(GetLastConsecutive(),s.nombre,s.numero,
                   s.id_linea,s.id_equipo,s.fecha_smp,s.clasificacion,
                    s.tipo_mtto,s.tecnicos_eq,s.duracion_actividad,
                        s.equipo_parado,s.frecuencia,s.tipo_frecuencia,
                            s.id_elaborador,s.id_aprobador,s.loto,s.permisos,
                                s.imagen_1,s.imagen_2);
            }

            return (int)sta.ScalarQuery();
        }

        public int AddSmpUtil(SmpUtil su)
        {
            int res = 0;
            if (su != null)
            {
                res = suta.Insert(su.id_smp,su.id_util,su.id_tipo);
            }

            return res;
        }
    }
}
