using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoEquipos
    {
        public List<equipos> ConsultarEquiposComboBox()
        {
            List<equipos> list = new List<equipos>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.equipos
                                  //where b.id_tipo == tipo
                              select b;

                    // Query for the Blog named ADO.NET Blog 
                    //var blog = context.Blogs
                    //                .Where(b => b.Name == "ADO.NET Blog")
                    //                .FirstOrDefault();

                    //if (combobox)
                    //{
                    //    list = als.ToList();
                    //    list.Insert(0, new tecnicos() { Nombre = "-- SELECCIONE --" });
                    //}
                    //else
                    //{
                    list = als.OrderBy(x => x.Nombre).ToList();
                    //}
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar los equipos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
