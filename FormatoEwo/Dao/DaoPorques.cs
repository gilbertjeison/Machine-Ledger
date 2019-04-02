using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FormatoEwo.Objetos;

namespace FormatoEwo.Dao
{
    public class DaoPorques
    {
        DataTable dt = new DataTable();
        FormatoEwo.EwoDatabaseDataSet.porquesDataTable
            dtCons = new EwoDatabaseDataSet.porquesDataTable();

        EwoDatabaseDataSetTableAdapters.porquesTableAdapter
            pta = new EwoDatabaseDataSetTableAdapters.porquesTableAdapter();

        public int AddPorque(Porques p)
        {
            int res = 0;
            if (p != null)
            {
                res = pta.Insert(p.id_ewo,p.porque_1,p.porque_2,p.porque_3,p.porque_4,p.porque_5);
            }

            return res;
        }
    }
}
