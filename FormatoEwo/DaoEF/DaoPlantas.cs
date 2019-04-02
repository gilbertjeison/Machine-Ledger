using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoPlantas
    {
        public List<plantas> GetPlants()
        {
            List<plantas> list = new List<plantas>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.plantas
                              select b;


                    list = als.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar plantas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
