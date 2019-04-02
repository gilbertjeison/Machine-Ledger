using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormatoEwo.Objetos;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using FormatoEwo.EwoDatabaseDataSetTableAdapters;

namespace FormatoEwo.Dao
{
    public class DaoTecnicos
    {
        tecnicosTableAdapter tta = new tecnicosTableAdapter();
        DataTable dt = new DataTable();
        FormatoEwo.EwoDatabaseDataSet.tecnicosDataTable dtTec = new EwoDatabaseDataSet.tecnicosDataTable();
        List<Tecnicos> list = new List<Tecnicos>();

        public List<Tecnicos> GetTecnicos()
        {
            tta.Fill(dtTec);
            dt = dtTec;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new Tecnicos() 
                {
                    id = int.Parse(dt.Rows[i][0].ToString()),
                    nombre = dt.Rows[i][1].ToString()
                });
            }

            return list;
        }

        public int ExistsTecnico(string nombre)
        {
            int filled = 0;
            dtTec = tta.GetDataByNombre(nombre);

            if (dtTec.Rows.Count > 0)
            {
                filled = int.Parse(dtTec.Rows[0][0].ToString());
            }

            return filled;
        }

        public int AddTecnico(Tecnicos t)
        {
            int res = 0;
            if (t != null)
            {
                res = tta.Insert(t.nombre);
            }

            return res;
        }


    }
}
