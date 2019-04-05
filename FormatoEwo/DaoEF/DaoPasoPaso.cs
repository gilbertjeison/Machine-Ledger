using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoPasoPaso
    {
        DaoTipos daoTip = new DaoTipos();
        public int AddPaso(smp_pasos sp)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {                  
                    context.smp_pasos.Add(sp);
                    regs = context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ee)
            {
                foreach (var eve in ee.EntityValidationErrors)
                {
                    System.Windows.Forms.MessageBox.Show("Entity of type "+ eve.Entry.Entity.GetType().Name 
                        + " in state "+ eve.Entry.State + " has the following validation errors:");
                                        
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Windows.Forms.MessageBox.Show("- Property: "+ ve.PropertyName + ", Error: "+ ve.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar paso a paso: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return regs;
        }

        public int AddPasoSop(sop_pasos sp)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.sop_pasos.Add(sp);
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar paso a paso sop: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public smp_pasos GetPasoByDesc(string paso, string desc)
        {
            smp_pasos data = new smp_pasos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.smp_pasos
                              where b.descripcion.Equals(desc)
                              && b.paso.Equals(paso)
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

        public int EditPaso(PasoaPaso sp)
        {
            smp_pasos spe;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    spe = context.smp_pasos.Where(s => s.Id == sp.Id).FirstOrDefault();                    
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (spe != null)
                {
                    spe.id_smp = sp.id_smp;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(spe).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar paso a paso: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public List<string> GetImagesPath()
        {
            List<string> list = new List<string>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var query = (from b in context.smp_pasos select b.image_path)
                                .Concat(from b in context.sop_pasos select b.image_path);

                    list = query.ToList();                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar imagenes en smp pasoss: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
