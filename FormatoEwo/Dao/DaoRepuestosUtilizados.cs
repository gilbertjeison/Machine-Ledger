using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FormatoEwo.Objetos;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoRepuestosUtilizados
    {
        DataTable dt = new DataTable();
        repuestos_utilizadosDataTable 
            dtCons = new repuestos_utilizadosDataTable();

        EwoDatabaseDataSetTableAdapters.repuestos_utilizadosTableAdapter 
            ruta = new EwoDatabaseDataSetTableAdapters.repuestos_utilizadosTableAdapter();

        public int AddRepuestoUtilizado(RepuestosUtilizados ru)
        {
            int res = 0;
            if (ru != null)
            {
                res = ruta.Insert(ru.cod_sap,ru.descripcion,ru.cantidad,ru.costo,ru.id_ewo,"");
            }

            return res;
        }

        public RepuestosUtilizados ConsultarRepByDesc(string desc)
        {
            RepuestosUtilizados r = new RepuestosUtilizados();
            repuestos_utilizadosDataTable edt = null;

            edt = ruta.GetDataByDesc(desc);

            if (edt.Rows.Count > 0)
            {
                r.id = int.Parse(edt.Rows[0]["Id"].ToString());
                r.descripcion = edt.Rows[0]["descripcion"].ToString();
                r.cantidad = int.Parse(edt.Rows[0]["cantidad"].ToString());
            }

            return r;
        }
    }
}
