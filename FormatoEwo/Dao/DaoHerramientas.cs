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
    public class DaoHerramientas
    {
        herramientasTableAdapter hta = new herramientasTableAdapter();
        List<Herramientas> list = new List<Herramientas>();

        public int AddHerramienta(Herramientas h)
        {
            int res = 0;
            if (h != null)
            {
                res = hta.Insert(h.herramienta, h.tipo, h.imagen_name);
            }

            return res;
        }

        public List<Herramientas> GetHerramientas()
        {
            herramientasDataTable herDT = new herramientasDataTable();
            herDT = hta.GetData();

            for (int i = 0; i < herDT.Rows.Count; i++)
            {
                list.Add(new Herramientas()
                {
                    sel= false,
                    Id = int.Parse(herDT.Rows[i][0].ToString()),
                    herramienta = herDT.Rows[i][1].ToString(),
                    tipo = herDT.Rows[i][2].ToString()
                });
            }
            return list;
        }

        public bool ExistsHerramienta(int id)
        {
            herramientasDataTable herDT = new herramientasDataTable();
            herDT = hta.GetDataById(id);

            if (herDT.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public int EditHerramienta(Herramientas h)
        {
            int res = 0;
            if (h != null)
            {
                //SE CREA UN DATATABLE COMUN Y SE ASIGNA 
                //EL RESULTADO DE UNA CONSULTA LINQ
                //CON EL ID DE LA FILA
                DataTable dt = hta.GetData().
                    Where(x => x.Id == h.Id).CopyToDataTable<herramientasRow>();

                //SE CREA UN DATATABLE TIPO DE LA TABLA
                herramientasDataTable hdt = new herramientasDataTable();
                //SE COMBINA LOS DATATABLES PARA FACILITAR EL MANEJO
                hdt.Merge(dt);

                //SE CREA UN DATAROW DEL TIPO DE LA TABLA
                EwoDatabaseDataSet.herramientasRow herRow =
                   hdt.FindById(h.Id);

                //SE ASIGNAN LOS VALORES MODIFICADOS               
                herRow.image_path = Path.GetFileName(h.imagen_name);
               
                //SE EJECUTA LA ACTUALIZACIÓN
                res = hta.Update(herRow);
            }

            return res;
        }
    }
}
