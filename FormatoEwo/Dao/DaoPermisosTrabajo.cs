using FormatoEwo.EwoDatabaseDataSetTableAdapters;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FormatoEwo.EwoDatabaseDataSet;

namespace FormatoEwo.Dao
{
    public class DaoPermisosTrabajo
    {
        permisos_trabajoTableAdapter ptta = new permisos_trabajoTableAdapter();

        public List<PermisosTrabajo> ConsultarPermisosTrabajos()
        {
            List<PermisosTrabajo> list = new List<PermisosTrabajo>();
            permisos_trabajoDataTable ptdt = new permisos_trabajoDataTable();

            ptdt = ptta.GetData();

            for (int i = 0; i < ptdt.Rows.Count; i++)
            {
                list.Add(new PermisosTrabajo()
                {
                    id = int.Parse(ptdt.Rows[i][0].ToString()),                   
                    descripcion = ptdt.Rows[i][1].ToString()
                });
            }

            return list;
        }
    }
}
