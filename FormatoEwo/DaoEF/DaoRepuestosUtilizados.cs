using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoRepuestosUtilizados
    {
        public int AddRepuestoUtilizado(repuestos_utilizados ru)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.repuestos_utilizados.Add(ru);
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar repuestos utilizados: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public repuestos_utilizados GetRepByDesc(string desc)
        {
            repuestos_utilizados data = new repuestos_utilizados();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.repuestos_utilizados
                              where b.descripcion.Equals(desc)
                              select b;

                    data = als.ToList().Count > 0 ? als.ToList()[0] : null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las repuestos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return data;
        }

        public List<Repuestos> GetReplacement()
        {
            List<Repuestos> list = new List<Repuestos>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = (from b in context.repuestos_utilizados
                              select b).OrderBy(x=> x.descripcion);


                    foreach (var item in als.ToList())
                    {
                        list.Add(new Repuestos()
                        {
                            sel = false,
                            Id = item.Id,
                            repuesto = item.descripcion,
                            cantidad = (int)item.cantidad,
                            imagen_name= item.image_path
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar Herramientas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public int EditRep(Repuestos rep)
        {
            repuestos_utilizados repe;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    repe = context.repuestos_utilizados.Where(s => s.Id == rep.Id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (repe != null)
                {
                    repe.image_path = rep.imagen_name;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(repe).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar repuesto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }
    }
}
