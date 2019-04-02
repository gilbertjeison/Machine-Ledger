using FormatoEwo.Database;
using FormatoEwo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FormatoEwo.DaoEF
{
    public class DaoPersonal
    {
        public List<tecnicos> ConsultarTecnicosComboBox()
        {
            List<tecnicos> list = new List<tecnicos>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all blogs with names starting with B 
                    var als = from b in context.tecnicos
                                  //where b.tipo_usuario == 102
                              select b;

                    // Query for the Blog named ADO.NET Blog 
                    //var blog = context.Blogs
                    //                .Where(b => b.Name == "ADO.NET Blog")
                    //                .FirstOrDefault();

                    //if (combobox)
                    //{
                    //    list = als.ToList();
                    //    list.Insert(0, new tecnicos() { Nombre = "-- SELECCIONE --" });
                    //}
                    //else
                    //{
                    list = als.OrderBy(x=>x.Nombre).ToList();
                    //}
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar los técnicos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
                       
        public int EditTecnico(tecnicos tec)
        {
            tecnicos tece;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    tece = context.tecnicos.Where(s => s.Id == tec.Id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (tece != null)
                {                    
                    tece.usuario = tec.usuario;
                    tece.password = tec.password;
                    tece.id_rol = tec.id_rol;
                    tece.activo = tec.activo;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(tece).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar técnico: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public tecnicos LoginUser(tecnicos u)
        {
            tecnicos uslog = new tecnicos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    string passMD5 = SomeHelpers.CalculateMD5Hash(u.password);

                    // Query for all
                    var als = from b in context.tecnicos
                              where b.usuario.Equals(u.usuario)
                              && b.password.Equals(passMD5)
                              select b;

                    var item = als.FirstOrDefault();

                    if (item != null)
                    {
                        uslog.Id = item.Id;
                        uslog.Nombre = item.Nombre;
                        uslog.usuario = item.usuario;
                        uslog.password = item.password;
                        uslog.activo = item.activo;
                        uslog.id_rol = item.id_rol;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al iniciar sesión con usuario: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return uslog;
        }

        public tecnicos LoginUser(tecnicos u, int pilar)
        {
            tecnicos uslog = new tecnicos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    string passMD5 = SomeHelpers.CalculateMD5Hash(u.password);

                    // Query for all
                    var als = from b in context.tecnicos
                              where b.usuario.Equals(u.usuario)
                              && b.password.Equals(passMD5)
                              && b.tipo_usuario == pilar
                              select b;

                    var item = als.FirstOrDefault();

                    if (item != null)
                    {
                        uslog.Id = item.Id;
                        uslog.Nombre = item.Nombre;
                        uslog.usuario = item.usuario;
                        uslog.password = item.password;
                        uslog.activo = item.activo;
                        uslog.id_rol = item.id_rol;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al iniciar sesión con usuario: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return uslog;
        }

        public tecnicos GetUser(int id)
        {
            tecnicos uslog = new tecnicos();

            try
            {
                using (var context = new MttoAppEntities())
                {                    
                    // Query for all
                    var als = from b in context.tecnicos
                              where b.Id==id                              
                              select b;

                    var item = als.FirstOrDefault();
                    if (item != null)
                    {
                        uslog.Id = item.Id;
                        uslog.Nombre = item.Nombre;
                        uslog.usuario = item.usuario;
                        uslog.password = item.password;
                        uslog.activo = item.activo;
                        uslog.id_rol = item.id_rol;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar usuario usuario: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return uslog;
        }
    }
}
