using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoHerr
    {
        public int AddTool(Herramientas herr)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.herramientas.Add(new herramientas()
                    {
                        herramienta = herr.herramienta,
                        tipo = herr.tipo,
                        image_path = herr.imagen_name
                    });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar herramienta: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public List<Herramientas> GetTools()
        {
            List<Herramientas> list = new List<Herramientas>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = (from b in context.herramientas
                              select  b).OrderBy(x=> x.herramienta);


                    foreach (var item in als.ToList())
                    {
                        list.Add(new Herramientas()
                        {
                            sel = false,
                            Id = item.Id,
                            herramienta = item.herramienta,
                            tipo = item.tipo,
                            imagen_name = item.image_path
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

        public int EditTool(Herramientas her)
        {
            herramientas here;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    here = context.herramientas.Where(s => s.Id == her.Id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (here != null)
                {
                    here.image_path = her.imagen_name;                    
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(here).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar Herramienta: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    var query = (from b in context.herramientas select b.image_path);

                    list = query.ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != null)
                        {
                            list[i] = Path.GetFileName(list[i]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar imagenes en herramientas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
