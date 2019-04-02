using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoSOP
    {
        public int GetLastConsecutive()
        {
            int max = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    if (context.sop.Count() > 0)
                    {
                        max = (int)context.sop.OrderByDescending(u => u.id).FirstOrDefault().consecutivo + 1;
                    }
                    else
                    {
                        max = 1;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar el consecutivo mayor (SOP): " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return max;
        }

        public int AddSop(sop sop)
        {
            int id = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.sop.Add(sop);
                    context.SaveChanges();
                    id = sop.id;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar sop: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return id;
        }

        public int AddSopUtil(sop_utils sopU)
        {
            int res = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.sop_utils.Add(sopU);
                    res = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar sop util: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

    }
}
