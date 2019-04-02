using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoCalendarioPm
    {
        calendarioPMTableAdapter cpmta = new calendarioPMTableAdapter();
        DaoEwo daoEwo = new DaoEwo();

        public int AddEntradaMtto(CalendarioPm cpm)
        {
            int res = 0;
            if (cpm != null)
            {
                //res = cpmta.Insert(cpm.id_componente,cpm.id_ewo,cpm.id_tipo_mtto,cpm.cantidad,cpm.fecha);
            }

            return res;
        }

        public List<CalendarioPm> ConsultarCalendario(int id_componente)
        {
            List<CalendarioPm> list = new List<CalendarioPm>();
            calendarioPMDataTable cmdt = new calendarioPMDataTable();

            cmdt = cpmta.GetDataById(id_componente);

            for (int i = 0; i < cmdt.Rows.Count; i++)
            {
                list.Add(new CalendarioPm()
                {
                    id = int.Parse(cmdt.Rows[i][0].ToString()),
                    id_componente = int.Parse(cmdt.Rows[i][1].ToString()),
                    id_ewo = int.Parse(cmdt.Rows[i][2].ToString()),
                    id_tipo_mtto = int.Parse(cmdt.Rows[i][3].ToString()),
                    cantidad = int.Parse(cmdt.Rows[i][4].ToString()),
                    //semana = DateTime.Parse(cmdt.Rows[i][5].ToString()),
                    desc = cmdt.Rows[i][6].ToString(),
                    duracion_total = (int)daoEwo.ConsultarEwoById(int.Parse(cmdt.Rows[i][2].ToString())).tiempo_total
                });                
            }

            return list;
        }

        public int DeleteEntry(CalendarioPm cpm)
        {
            int res = 0;
            if (cpm.id > 0)
            {
                //SE EJECUTA LA ACTUALIZACIÓN
                //res = cpmta.Delete(cpm.id,cpm.id_componente,cpm.id_ewo,cpm.id_tipo_mtto,cpm.cantidad,cpm.fecha);
            }

            return res;
        }

        public int EditEntry(CalendarioPm cm)
        {
            int res = 0;
            if (cm != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = cpmta.GetData().
                    Where(x => x.Id == cm.id).CopyToDataTable<calendarioPMRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                calendarioPMDataTable cpmdt = new calendarioPMDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                cpmdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.calendarioPMRow cpmRow =
                   cpmdt.FindById(cm.id);

                //SE ASIGNAN LOS VALORES MODIFICADOS
                cpmRow.id_componente = cm.id_componente;
                cpmRow.id_ewo = cm.id_ewo;
                cpmRow.tipo_mantenimiento = cm.id_tipo_mtto;
                cpmRow.cantidad = cm.cantidad;
                //cpmRow.fecha = cm.fecha;

                //SE EJECUTA LA ACTUALIZACIÓN
                res = cpmta.Update(cpmRow);
            }

            return res;
        }
    }
}
