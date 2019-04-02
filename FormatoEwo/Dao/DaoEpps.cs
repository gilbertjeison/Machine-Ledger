using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoEpps
    {
        eppsTableAdapter eta = new eppsTableAdapter();
        List<Epps> listEpps = new List<Epps>();

        public List<Epps> getEpps()
        {
            //int filled = 0;
            eppsDataTable edt = new eppsDataTable();
            edt = eta.GetData();

            for (int i = 0; i < edt.Rows.Count; i++)
            {
                listEpps.Add(new Epps(int.Parse(edt.Rows[i]["Id"].ToString()),
                    bool.Parse(edt.Rows[i]["seleccionado"].ToString()),
                        int.Parse(edt.Rows[i]["codigo"].ToString()),
                            edt.Rows[i]["nombre"].ToString(),
                                edt.Rows[i]["foto"].ToString()));
            }

            return listEpps;
        }
    }
}
