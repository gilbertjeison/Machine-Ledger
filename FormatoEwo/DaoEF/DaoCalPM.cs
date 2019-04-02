using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FormatoEwo.DaoEF
{
    public class DaoCalPM
    {
        DaoEwo daoEwo = new DaoEwo();
        DaoPersonal daoPer = new DaoPersonal();
        public List<CalendarioPm> GetCalendario(int id_componente, int year)
        {
            List<CalendarioPm> list = new List<CalendarioPm>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.calendarioPM
                              join t in context.tipos_data 
                              on b.tipo_mantenimiento equals t.Id
                              where b.id_componente == id_componente
                              && b.year == year
                              select new { b,t} ;
                    
                    foreach (var item in als.ToList())
                    {
                        list.Add(new CalendarioPm()
                        {
                            id = item.b.Id,
                            id_componente = (int)item.b.id_componente,
                            id_ewo = (int)item.b.id_ewo,
                            id_tipo_mtto = (int)item.b.tipo_mantenimiento,
                            semana = (int)item.b.semana,
                            year = (int)item.b.year,
                            desc = item.t.descripcion,
                            duracion_total = item.b.id_ewo == 0 ? 0 : (int)daoEwo.GetEwoById((int)item.b.id_ewo).tiempo_total,
                            observaciones = item.b.observaciones
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar Calendario PM: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<CalendarioPm> GetCalendario(int id_componente, int year, int week)
        {
            List<CalendarioPm> list = new List<CalendarioPm>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.calendarioPM
                              join t in context.tipos_data
                              on b.tipo_mantenimiento equals t.Id
                              where b.id_componente == id_componente
                              && b.year == year
                              && b.semana == week
                              select new { b, t };

                    foreach (var item in als.ToList())
                    {
                        list.Add(new CalendarioPm()
                        {
                            id = item.b.Id,
                            id_componente = (int)item.b.id_componente,
                            id_ewo = (int)item.b.id_ewo,
                            id_tipo_mtto = (int)item.b.tipo_mantenimiento,
                            semana = (int)item.b.semana,
                            year = (int)item.b.year,
                            desc = item.t.descripcion,
                            duracion_total = item.b.id_ewo == 0 ? 0 : (int)daoEwo.GetEwoById((int)item.b.id_ewo).tiempo_total,
                            observaciones = item.b.observaciones,
                            image = SetImage(item.b.tipo_mantenimiento.ToString()),
                            creado = item.b.creado == null ? new DateTime(1,1,1) : (DateTime)item.b.creado,
                            usuario = item.b.user_id == null ? "No registra..." : daoPer.GetUser((int)item.b.user_id).Nombre
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar Calendario PM: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<CustomCalendarioAlerts> GetCalendarioCurrentWeek(int linea, int week, int year)
        {           
            List<CustomCalendarioAlerts> list = new List<CustomCalendarioAlerts>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    var noti = from c in context.calendarioPM
                               join com in context.componentes
                                on c.id_componente equals com.Id
                               join con in context.conjuntos
                               on com.id_conjunto equals con.Id
                               join sis in context.sistemas
                               on con.id_sistema equals sis.Id
                               join maq in context.maquinas
                               on sis.id_maquina equals maq.Id
                               join lin in context.lineas
                               on maq.id_linea equals lin.id
                               where c.tipo_mantenimiento == 18
                               && lin.id == linea 
                               && c.year == year
                               && c.semana == week
                               select c.Id;

                    // Query for all
                    var als = from cal in context.calendarioPM
                                join com in context.componentes
                                on cal.id_componente equals com.Id
                                join con in context.conjuntos
                                on com.id_conjunto equals con.Id
                                join sis in context.sistemas
                                on con.id_sistema equals sis.Id
                                join maq in context.maquinas
                                on sis.id_maquina equals maq.Id
                                join lin in context.lineas
                                on maq.id_linea equals lin.id
                                join td in context.tipos_data
                                on cal.tipo_mantenimiento equals td.Id
                                where cal.year == year                                
                                && cal.semana == week
                                && cal.tipo_mantenimiento == 17
                                && lin.id == linea
                                && !noti.ToList().Contains(cal.Id)
                                select new { cal, com, con, sis, maq, td, lin };

                    foreach (var item in als.ToList())
                    {
                        list.Add(new CustomCalendarioAlerts()
                        {
                            idLinea = item.lin.id,
                            idCalendario = item.cal.Id,
                            idComponente = item.com.Id,
                            maquina = item.maq.nombre,
                            sistema = item.sis.Nombre,
                            conjunto = item.con.nombre,
                            componente = item.com.descripcion.Trim(),
                            idTipoMtto = (int)item.cal.tipo_mantenimiento,
                            tipoMtto = item.td.descripcion,
                            week = (int)item.cal.semana,
                            year = (int)item.cal.year,
                            observacion = item.cal.observaciones
                        });
                    }
                }
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Por favor revise conexión con el servidor ",
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al consultar Calendario PM por linea: " + ex,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
           
        }

        private string SetImage(string type)
        {
            return "pack://application:,,,/FormatoEwo;component/Resources/"+type+".png";
        }

        public List<CalendarioPm> GetCalendario(int id_componente)
        {
            List<CalendarioPm> list = new List<CalendarioPm>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = (from b in context.calendarioPM
                              join t in context.tipos_data
                              on b.tipo_mantenimiento equals t.Id
                              where b.id_componente == id_componente
                              select new { b, t }).OrderBy(x=>x.b.year).ThenBy(x=> x.b.semana);

                    foreach (var item in als.ToList())
                    {
                        list.Add(new CalendarioPm()
                        {
                            id = item.b.Id,
                            id_componente = (int)item.b.id_componente,
                            id_ewo = (int)item.b.id_ewo,
                            id_tipo_mtto = (int)item.b.tipo_mantenimiento,
                            semana = (int)item.b.semana,
                            year = (int)item.b.year,
                            desc = item.t.descripcion,
                            duracion_total = item.b.id_ewo == 0 ? 0 : (int)daoEwo.GetEwoById((int)item.b.id_ewo).tiempo_total,
                            observaciones = item.b.observaciones,
                            usuario = item.b.user_id == null ? "No registra..." : daoPer.GetUser((int)item.b.user_id).Nombre 
                            
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar Calendario PM: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<int> GetDistinctYear()
        {
            List<int> list = new List<int>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = (from b in context.calendarioPM
                              select b.year).Distinct();

                    foreach (var item in als.ToList())
                    {
                        list.Add((int)item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar diferentes años del Calendario PM: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            list.Sort();

            return list;
        }

        public int AddEntryMtto(CalendarioPm cal)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.calendarioPM.Add(new calendarioPM()
                    {
                        id_componente = cal.id_componente,
                        id_ewo = cal.id_ewo,
                        tipo_mantenimiento = cal.id_tipo_mtto,
                        semana = cal.semana,
                        year = cal.year,
                        observaciones = cal.observaciones,
                        user_id = cal.user_id,
                       creado = DateTime.Now 
                    });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar entrada mtto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int DeleteEntry(CalendarioPm cal)
        {
            calendarioPM cald;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    cald = context.calendarioPM.Where(s => s.Id == cal.id).FirstOrDefault();
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as deleted
                    context.Entry(cald).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar Entrada (CalPM): " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditEntry(CalendarioPm cal)
        {
            calendarioPM cale;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    cale = context.calendarioPM.Where(s => s.Id == cal.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (cale != null)
                {
                    cale.id_componente = cal.id_componente;
                    cale.id_ewo = cal.id_ewo;
                    cale.tipo_mantenimiento = cal.id_tipo_mtto;
                    cale.semana = cal.semana;
                    cale.year = cal.year;
                    cale.observaciones = cal.observaciones;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(cale).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar entrada (CalPM): " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public List<CustomCalendario> GetCalendarioData(int year, int week, int id_linea)
        {           
            List<CustomCalendario> list = new List<CustomCalendario>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    var noti = from c in context.calendarioPM
                                where c.tipo_mantenimiento == 18
                                && c.year == year
                                && c.semana == week 
                                select c.id_componente;

                    // Query for all
                    var als = from cal in context.calendarioPM
                                join com in context.componentes
                                on cal.id_componente equals com.Id
                                join con in context.conjuntos
                                on com.id_conjunto equals con.Id
                                join sis in context.sistemas
                                on con.id_sistema equals sis.Id
                                join maq in context.maquinas
                                on sis.id_maquina equals maq.Id
                                join pla in context.plantas
                                on maq.id_planta equals pla.Id
                                join td in context.tipos_data
                                on cal.tipo_mantenimiento equals td.Id
                                where cal.year == year                              
                                && cal.semana == week
                                && !noti.ToList().Contains(cal.id_componente)
                                select new { cal, pla, com, con, sis, maq, td };

                    foreach (var item in als.ToList())
                    {
                        list.Add(new CustomCalendario()
                        {
                            idPlanta = item.pla.Id,
                            idCalendario = item.cal.Id,
                            idComponente = item.com.Id,
                            maquina = item.maq.nombre,
                            sistema = item.sis.Nombre,
                            conjunto = item.con.nombre,
                            componente = item.com.descripcion.Trim(),
                            idTipoMtto = (int)item.cal.tipo_mantenimiento,
                            tipoMtto = item.td.descripcion,
                            week = (int)item.cal.semana,
                            year = (int)item.cal.year,
                            observacion = item.cal.observaciones
                        });
                    }
                }
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Por favor revise conexión con el servidor ",
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al consultar Calendario PM por planta: " + ex,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }        
    }
}
