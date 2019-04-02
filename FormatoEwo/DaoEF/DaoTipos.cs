using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoTipos
    {
        public List<tipos_data> ConsultarTipoComboBox(bool combobox)
        {
            List<tipos_data> list = new List<tipos_data>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.tipos_data
                              //where b.id_tipo == tipo
                              select b;

                    // Query for the Blog named ADO.NET Blog 
                    //var blog = context.Blogs
                    //                .Where(b => b.Name == "ADO.NET Blog")
                    //                .FirstOrDefault();

                    if (combobox)
                    {
                        list = als.ToList();
                        list.Insert(0, new tipos_data() { descripcion = "-- SELECCIONE --" });
                    }
                    else
                    {
                        list = als.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las areas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public tipos_data GetTipoByDesc(string type)
        {
            tipos_data data = new tipos_data();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.tipos_data
                              where b.descripcion.Equals(type)
                              select b;

                   
                    data = als.ToList().Count > 0 ? als.ToList()[0] : null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las areas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return data;
        }
    }
}
