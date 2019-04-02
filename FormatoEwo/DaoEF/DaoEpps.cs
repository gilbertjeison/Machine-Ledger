using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoEpps
    {
        public List<Epps> GetEpps()
        {
            List<Epps> list = new List<Epps>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.epps                                  
                              select b;
                                        
                    var res = als.ToList();

                    for (int i = 0; i < res.Count; i++)
                    {
                        list.Add(new Epps(res[i].Id, (bool)res[i].seleccionado, int.Parse(res[i].codigo), res[i].nombre, res[i].foto));
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar los epps: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
