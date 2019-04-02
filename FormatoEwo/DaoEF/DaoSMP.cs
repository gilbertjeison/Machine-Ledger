using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormatoEwo.Database;
using System.Windows;
using FormatoEwo.Objetos;

namespace FormatoEwo.DaoEF
{
    public class DaoSMP
    {
        public int GetLastConsecutive()
        {
            int max = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    if (context.smp.Count()>0)
                    {
                        max = (int)context.smp.OrderByDescending(u => u.Id).FirstOrDefault().consecutivo + 1;
                    }
                    else
                    {
                        max = 1;
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar el consecutivo mayor (SMP): " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return max;
        }

        public int AddSmp(smp smp)
        {
            int id = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.smp.Add(smp);
                    context.SaveChanges();
                    id = smp.Id;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar smp: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return id;
        }

        public int AddSmpUtil(smp_util smpU)
        {
            int res = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.smp_util.Add(smpU);
                    res = context.SaveChanges();                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar smp util: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

        public List<smp> GetSmps()
        {
            List<smp> list = new List<smp>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.smp
                              select b;


                    list = als.ToList().OrderBy(x=> x.nombre).ToList();                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar smp: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public CustomSMP GetCustomSMP(int id_smp)
        {
            CustomSMP cs = new CustomSMP();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from s in context.smp
                              join td in context.tipos_data
                              on s.id_linea equals td.Id
                              join e in context.equipos
                              on s.id_equipo equals e.Id
                              join tdc in context.tipos_data
                              on s.clasificacion equals tdc.Id
                              join tdtm in context.tipos_data
                              on s.tipo_mtto equals tdtm.Id
                              join tdtf in context.tipos_data
                              on s.tipo_frecuencia equals tdtf.Id
                              join t in context.tecnicos
                              on s.id_elaborador equals t.Id
                              join ta in context.tecnicos
                              on s.id_aprobador equals ta.Id
                              where s.Id == id_smp
                              select new { s,td,e,tdc,tdtm,tdtf,t,ta };

                    foreach (var item in als.ToList())
                    {
                        cs.id = item.s.Id;
                        cs.consecutivo = (int)item.s.consecutivo;
                        cs.nombre = item.s.nombre;
                        cs.numero = (int)item.s.numero;
                        cs.id_linea = (int)item.s.id_linea;
                        cs.desc_linea = item.td.descripcion;
                        cs.id_equipo = (int)item.s.id_equipo;
                        cs.desc_equipo = item.e.Nombre;
                        cs.fecha_smp = (DateTime)item.s.feha_smp;
                        cs.id_clasificacion = (int)item.s.clasificacion;
                        cs.desc_clasificacion = item.tdc.descripcion;
                        cs.tipo_mtto = (int)item.s.tipo_mtto;
                        cs.desc_tipo_mtto = item.tdtm.descripcion;
                        cs.tecnicos_eq = (int)item.s.tecnicos_req;
                        cs.duracion_actividad = (int)item.s.duracion_actividad;
                        cs.equipo_parado = (int)item.s.equipo_parado;
                        cs.frecuencia = (int)item.s.frecuencia;
                        cs.tipo_frecuencia = (int)item.s.tipo_frecuencia;
                        cs.desc_tipo_frecuencia = item.tdtf.descripcion;
                        cs.id_elaborador = (int)item.s.id_elaborador;
                        cs.desc_elaborador = item.t.Nombre;
                        cs.id_aprobador = (int)item.s.id_aprobador;
                        cs.desc_aprobador = item.ta.Nombre;
                        cs.loto = (bool)item.s.loto;
                        cs.permisos = item.s.permisos;
                        cs.imagen_1 = item.s.imagen_1;
                        cs.imagen_2 = item.s.imagen_2;
                    }

                    //CARGAR EPPS 9 - HERRAMIENTAS 10 - REPUESTOS 11
                    //var lt = from su in context.smp_util
                    //         where su.id_smp == id_smp
                    //         select su;

                    //cs.list_util = lt.ToList();

                    //CARGAR PASOS
                    cs.list_pasos = new List<PasoaPaso>();

                    var lp = from sp in context.smp_pasos
                             join td in context.tipos_data
                             on sp.categoria_id equals td.Id
                             where sp.id_smp == id_smp
                             select new { sp,td };

                    foreach (var item in lp.ToList())
                    {
                        cs.list_pasos.Add(new PasoaPaso()
                        {
                            categoria = item.td.descripcion,
                            desc = item.sp.descripcion,
                            duracion = item.sp.duracion.ToString(),
                            Id = item.sp.Id,
                            id_smp = (int)item.sp.id_smp,
                            imagen_paso_path = item.sp.image_path,
                            paso = item.sp.paso
                        });
                    }
                   

                    //CARGAR EPPS DEPENDIENDO ID
                    cs.list_epps = new List<epps>();

                    var epps = from e in context.epps
                                join su in context.smp_util
                                on e.Id equals su.id_util
                                where su.id_tipo == 9
                                && su.id_smp == id_smp
                                select new {e};

                    foreach (var item in epps.ToList())
                    {
                        cs.list_epps.Add(new Database.epps()
                        {
                            codigo = item.e.codigo,
                            foto =item.e.foto,
                            Id = item.e.Id,
                            nombre = item.e.nombre,
                            seleccionado = item.e.seleccionado
                        });
                    }

                    //CARGAR HERRAMIENTAS DEPENDIENDO ID
                    cs.list_herramientas = new List<herramientas>();

                    var herr = from h in context.herramientas
                               join su in context.smp_util
                               on h.Id equals su.id_util
                               where su.id_tipo == 10
                               && su.id_smp == id_smp
                               select new { h };

                    foreach (var item in herr.ToList())
                    {
                        cs.list_herramientas.Add(new Database.herramientas()
                        {                            
                            Id = item.h.Id,
                            herramienta = item.h.herramienta,
                            image_path = item.h.image_path,
                            tipo = item.h.tipo                            
                        });
                    }

                    //CARGAR REPUESTOS DEPENDIENDO ID
                    cs.list_repuestos = new List<repuestos_utilizados>();

                    var rep = from r in context.repuestos_utilizados
                               join su in context.smp_util
                               on r.Id equals su.id_util
                               where su.id_tipo == 11
                               && su.id_smp == id_smp
                               select new { r };

                    foreach (var item in rep.ToList())
                    {
                        cs.list_repuestos.Add(new Database.repuestos_utilizados()
                        {
                            Id = item.r.Id,
                            cantidad = item.r.cantidad,
                            image_path = item.r.image_path,
                            descripcion = item.r.descripcion
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar Custom SMP: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return cs;
        }
    }
}
