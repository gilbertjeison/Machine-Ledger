using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoEquipo
    {
        equiposTableAdapter eqta = new equiposTableAdapter();
        List<Equipos> list = new List<Equipos>();

        public int ExistsEquipo(string nombre)
        {
            int filled = 0;
            equiposDataTable eqDT = new equiposDataTable();
            eqDT = eqta.GetDataByNombre(nombre);

            if (eqDT.Rows.Count > 0)
            {
                filled = int.Parse(eqDT.Rows[0][0].ToString());
            }

            return filled;
        }

        public int AddEquipo(Equipos eq)
        {
            int res = 0;
            if (eq != null)
            {
                res = eqta.Insert(eq.nombre);
            }

            return res;
        }
    }
}
