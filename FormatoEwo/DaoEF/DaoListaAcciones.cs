using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoListaAcciones
    {
        public int AddAccion(lista_acciones la)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.lista_acciones.Add(la);
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar lista de acciones: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }
    }
}
