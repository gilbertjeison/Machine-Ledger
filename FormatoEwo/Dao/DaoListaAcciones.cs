using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FormatoEwo.Objetos;

namespace FormatoEwo.Dao
{
    public class DaoListaAcciones
    {
        DataTable dt = new DataTable();
        FormatoEwo.EwoDatabaseDataSet.lista_accionesDataTable
            dtCons = new EwoDatabaseDataSet.lista_accionesDataTable();

        EwoDatabaseDataSetTableAdapters.lista_accionesTableAdapter
            lata = new EwoDatabaseDataSetTableAdapters.lista_accionesTableAdapter();

        public int AddAccion(ListaAcciones la)
        {
            int res = 0;
            if (la != null)
            {
                res = lata.Insert(la.accion,la.tipo_accion,la.responsable,la.fecha,la.id_ewo);
            }

            return res;
        }
    }
}
