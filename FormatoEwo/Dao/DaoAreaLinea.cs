using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoAreaLinea
    {        
        area_lineaTableAdapter alta = new area_lineaTableAdapter();
        List<AreaLinea> list = new List<AreaLinea>();

        public int ExistsAreaLinea(string nombre)
        {
            int filled = 0;
            area_lineaDataTable alDT = new area_lineaDataTable();
            alDT = alta.GetDataByNombre(nombre);

            if (alDT.Rows.Count > 0)
            {
                filled = int.Parse(alDT.Rows[0][0].ToString());
            }
            
            return filled;
        }

        public int AddAreaLinea(AreaLinea al)
        {
            int res = 0;
            if (al != null)
            {
                res = alta.Insert(al.nombre);
            }

            return res;
        }
    }
}
