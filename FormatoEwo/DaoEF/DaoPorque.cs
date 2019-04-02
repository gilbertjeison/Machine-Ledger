using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoPorque
    {
        public int AddPorque(porques porque)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.porques.Add(porque);
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar porque: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }
    }
}
