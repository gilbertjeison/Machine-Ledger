using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoEwo
    {
        public int GetLastConsecutive()
        {
            int max = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    max = (int)context.ewos.OrderByDescending(u => u.Id).FirstOrDefault().consecutivo+1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar el consecutivo mayor (EWO): " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return max;
        }

        public int AddEwo(ewos ewo)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.ewos.Add(ewo);
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar ewo: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        internal int GetLastId()
        {
            int max = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    max = context.ewos.OrderByDescending(u => u.Id).FirstOrDefault().Id ;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar el último consecutivo (EWO): " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return max;
        }

        public ewos GetEwoById(int id)
        {
            ewos data = new ewos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.ewos
                              where b.Id == id                             
                              select b;

                    data = als.ToList().Count > 0 ? als.ToList()[0] : null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar ewo por id: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return data;
        }

        public List<ewos> GetEwos()
        {
            List<ewos> list = new List<ewos>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.ewos
                              select b;


                    list = als.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar ewos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
