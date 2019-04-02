using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoPaso
    {
        smp_pasosTableAdapter sta = new smp_pasosTableAdapter();
        tipos_dataTableAdapter tdta = new tipos_dataTableAdapter();

        public int AddPaso(PasoaPaso pap)
        {
            int res = 0;
            if (pap != null)
            {
                int id_cat = int.Parse(tdta.GetDataByDesc
                    (pap.categoria).Rows[0]["Id"].ToString());
                
                res = sta.Insert(pap.paso,pap.desc,int.Parse(pap.duracion),pap.imagen_paso_path,id_cat,0);
            }

            return res;
        }

        public PasoaPaso ConsultarPasoByPasoDesc(string paso,string desc)
        {
            PasoaPaso pp = new PasoaPaso();
            smp_pasosDataTable pdt = null;

            pdt = sta.GetDataByPasoDesc(paso,desc);

            if (pdt.Rows.Count > 0)
            {
                pp.Id = int.Parse(pdt.Rows[0]["Id"].ToString());
            }

            return pp;
        }

        public int EditPaso(PasoaPaso pp)
        {
            int res = 0;
            if (pp != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = sta.GetData().
                    Where(x => x.Id == pp.Id).CopyToDataTable<smp_pasosRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                smp_pasosDataTable pdt = new smp_pasosDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                pdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.smp_pasosRow pasRow =
                   pdt.FindById(pp.Id);

                int id_cat = int.Parse(tdta.GetDataByDesc
                    (pp.categoria).Rows[0]["Id"].ToString());

                //SE ASIGNAN LOS VALORES MODIFICADOS               
                //pasRow.image_path = Path.GetFileName(pp.imagen_paso_path);
                //pasRow.paso = pp.paso;
                //pasRow.descripcion = pp.desc;
                //pasRow.duracion = int.Parse(pp.duracion);
                //pasRow.categoria_id = id_cat;
                pasRow.id_smp = pp.id_smp;

                //SE EJECUTA LA ACTUALIZACIÓN
                res = sta.Update(pasRow);
            }

            return res;
        }
    }
}
