using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FormatoEwo.DaoEF
{
    public class DaoML
    {
        DaoCalPM daoCal = new DaoCalPM();

        public int AddMachine(Machines maq)
        {
            int regs = 0;
            
            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.maquinas.Add(new maquinas() {id_planta = maq.id_planta, nombre = maq.nombre, foto_path = maq.foto, id_linea = maq.id_linea });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar maquina: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int AddSistema(Sistemas sis)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.sistemas.Add(new sistemas()
                    {
                        id_maquina = sis.id_machine,
                        Nombre = sis.nombre,
                        image_path = sis.image_path
                    });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar sistema: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int AddConjunto(Conjuntos con)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.conjuntos.Add(new conjuntos()
                    {
                        id_sistema = con.id_sistema,
                        nombre = con.nombre,
                        image_path = con.image_path,
                        id_smp = con.id_smp
                    });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar conjunto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int AddComponente(Componentes comp)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.componentes.Add(new componentes()
                    {
                        Id = comp.id,
                        codigo_fabricante= comp.codigo_fabricante,
                        codigo_sap = comp.codigo_sap,
                        clase = comp.clase,
                        descripcion = comp.descripcion,
                        ubicacion_almacen = comp.ubicacion_almacen,
                        proveedor = comp.proveedor,
                        estrategia_mtto = comp.codigo_estrategia_mtto,
                        id_smp = comp.id_smp,
                        duracion_estandar = comp.duracion_estandar,
                        estado_equipo = comp.estado_equipo,
                        frecuencia_pm = comp.frecuencia_pm,
                        tipo_frecuencia_pm = comp.tipo_frecuencia_pm,
                        estandar_am = comp.estandar_am,
                        frecuencia_am = comp.frecuencia_am,
                        tipo_frecuencia_am = comp.tipo_frecuencia_am,
                        n_matriz_qp = comp.n_matriz_qp,
                        n_matriz_qm = comp.n_matriz_qm,
                        n_kaizen = comp.n_kaizen,
                        tipo_kaizen = comp.tipo_kaizen,
                        image_path = comp.image_path,
                        id_conjunto = comp.id_conjunto,
                        smp_file = comp.smp_file
                });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar componente: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditMaquina(Machines maq)
        {
            maquinas maqe;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    maqe = context.maquinas.Where(s => s.Id == maq.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (maqe != null)
                {
                    maqe.nombre = maq.nombre;
                    maqe.foto_path = maq.foto;
                    maqe.id_linea = maq.id_linea;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(maqe).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar maquina: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditSistema(Sistemas sis)
        {
            sistemas sise;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    sise = context.sistemas.Where(s => s.Id == sis.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (sise != null)
                {
                    sise.Nombre = sis.nombre;
                    sise.image_path = sis.image_path;
                    sise.id_maquina = sis.id_machine;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(sise).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar sistema: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditConjunto(Conjuntos con)
        {
            conjuntos conje;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    conje = context.conjuntos.Where(s => s.Id == con.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (conje != null)
                {
                    conje.nombre = con.nombre;
                    conje.image_path = con.image_path;
                    conje.id_sistema = con.id_sistema;
                    conje.id_smp = con.id_smp;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(conje).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar conjunto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditComponente(Componentes com)
        {
            componentes come;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    come = context.componentes.Where(s => s.Id == com.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (come != null)
                {                  
                    come.codigo_fabricante = com.codigo_fabricante;
                    come.codigo_sap = com.codigo_sap;
                    come.descripcion = com.descripcion;
                    come.ubicacion_almacen = com.ubicacion_almacen;
                    come.clase = com.clase;
                    come.proveedor = com.proveedor;
                    come.estrategia_mtto = com.codigo_estrategia_mtto;
                    come.id_smp = com.id_smp;
                    come.frecuencia_pm = com.frecuencia_pm;
                    come.tipo_frecuencia_pm = com.tipo_frecuencia_pm;
                    come.duracion_estandar = com.duracion_estandar;
                    come.estado_equipo = com.estado_equipo;
                    come.estandar_am = com.estandar_am;
                    come.frecuencia_am = com.frecuencia_am;
                    come.tipo_frecuencia_am = com.tipo_frecuencia_am;
                    come.n_matriz_qp = com.n_matriz_qp;
                    come.n_matriz_qm = com.n_matriz_qm;
                    come.tipo_kaizen = com.tipo_kaizen;
                    come.n_kaizen = com.n_kaizen;
                    come.image_path = com.image_path;
                    come.id_conjunto = com.id_conjunto;
                    come.smp_file = com.smp_file;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(come).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar componente: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int EditSmpComponents(Conjuntos cnt)
        {           
            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    var come = context.componentes.Where(s => s.id_conjunto == cnt.id).ToList();
                    come.ForEach(x=> x.id_smp = cnt.id_smp);

                    //context.Entry(come).State = System.Data.Entity.EntityState.Modified;

                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al asignar SMP a todos los componentes: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int DeleteMaquina(Machines maq)
        {
            maquinas maqd;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    maqd = context.maquinas.Where(s => s.Id == maq.id).FirstOrDefault();
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as deleted
                    context.Entry(maqd).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar maquina: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int DeleteSistema(Sistemas sis)
        {
            sistemas sisd;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    sisd = context.sistemas.Where(s => s.Id == sis.id).FirstOrDefault();
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as deleted
                    context.Entry(sisd).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar sistema: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int DeleteConjunto(Conjuntos con)
        {
            conjuntos cond;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    cond = context.conjuntos.Where(s => s.Id == con.id).FirstOrDefault();
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as deleted
                    context.Entry(cond).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                    if (regs>0)
                    {
                        //BORRAR IMAGEN DE GALERÍA

                    }
                }

                //BORRAR COMPONENTES DEL CONJUNTO
                DeleteComponentesByConjunto(con.id);

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar conjunto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public int DeleteComponente(componentes com)
        {
            componentes comd;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    comd = context.componentes.Where(s => s.Id == com.Id).FirstOrDefault();
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as deleted
                    context.Entry(comd).State = System.Data.Entity.EntityState.Deleted;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar componente: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }


        public int DeleteComponentesByConjunto(int id_conjunto)
        {
            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    context.componentes.RemoveRange(context.componentes.Where(x => x.id_conjunto == id_conjunto));
                    context.SaveChanges();                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al eliminar componente por conjunto: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public List<Machines> GetMachines(int id_linea)
        {
            List<Machines> list = new List<Machines>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.maquinas
                              where b.id_linea == id_linea
                              select b;
                                        
                    
                    foreach (var item in als.ToList())
                    {
                        list.Add(new Machines()
                        {
                            id = item.Id,
                            nombre = item.nombre,
                            foto = item.foto_path,
                            id_linea = (int)item.id_linea
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las maquinas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public maquinas GetMachineById(int id_machine)
        {
            maquinas list = new maquinas();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.maquinas
                              where b.Id == id_machine
                              select b;
                    
                        list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar maquina en especial: " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
        
        public maquinas GetMachineByName(string machine_name)
        {
            maquinas list = new maquinas();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.maquinas
                              where b.nombre.Equals(machine_name)
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar maquina en especial (Nombre): " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public sistemas GetSystemByName(string system_name)
        {
            sistemas list = new sistemas();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.sistemas
                              where b.Nombre.Equals(system_name)
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar sistema en especial (Nombre): " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<Machines> GetMachines()
        {
            List<Machines> list = new List<Machines>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.maquinas                              
                              select b;


                    foreach (var item in als.ToList())
                    {
                        list.Add(new Machines()
                        {
                            id = item.Id,
                            nombre = item.nombre,
                            foto = item.foto_path
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las maquinas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<Sistemas> GetSystems(int id_maquina)
        {
            List<Sistemas> list = new List<Sistemas>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.sistemas
                              where b.id_maquina == id_maquina
                              select b;


                    foreach (var item in als.ToList())
                    {
                        list.Add(new Sistemas()
                        {
                            id = item.Id,
                            nombre = item.Nombre,
                            id_machine = (int)item.id_maquina,
                            image_path = item.image_path
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las sistemas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public sistemas GetSystemById(int id_system)
        {
            sistemas list = new sistemas();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.sistemas
                              where b.Id == id_system
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar sistema en especial: " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<Conjuntos> GetConjuntos(int id_sistema)
        {
            List<Conjuntos> list = new List<Conjuntos>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.conjuntos
                              where b.id_sistema == id_sistema
                              select b;


                    foreach (var item in als.ToList())
                    {
                        list.Add(new Conjuntos()
                        {
                            id = item.Id,
                            nombre = item.nombre,
                            id_sistema = (int)item.id_sistema,
                            image_path = item.image_path,
                            id_smp = (int)item.id_smp
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las conjuntos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public conjuntos GetConjuntoById(int id_conjunto)
        {
            conjuntos list = new conjuntos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.conjuntos
                              where b.Id == id_conjunto
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar conjunto en especial: " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public conjuntos GetConjuntoByName(string conjunto_name)
        {
            conjuntos list = new conjuntos();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.conjuntos
                              where b.nombre.Equals(conjunto_name)
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar conjunto en especial (Nombre): " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<Componentes> GetComponentes(int id_conjunto, int year)
        {
            List<Componentes> list = new List<Componentes>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.componentes
                              where b.id_conjunto == id_conjunto
                              select b;
                    
                    foreach (var item in als.ToList())
                    {
                        list.Add(new Componentes()
                        {
                            id = item.Id,
                            codigo_fabricante = item.codigo_fabricante,
                            codigo_sap = item.codigo_sap,
                            descripcion = item.descripcion.Trim(),
                            ubicacion_almacen = item.ubicacion_almacen,
                            clase = item.clase,
                            proveedor = item.proveedor,
                            codigo_estrategia_mtto = (int)item.estrategia_mtto,
                            id_smp = (int)item.id_smp,
                            frecuencia_pm = (int)item.frecuencia_pm,
                            tipo_frecuencia_pm = (int)item.tipo_frecuencia_pm,
                            duracion_estandar = (int)item.duracion_estandar,
                            estado_equipo = (int)item.estado_equipo,
                            estandar_am = (int)item.estandar_am,
                            frecuencia_am = (int)item.frecuencia_am,
                            tipo_frecuencia_am = (int)item.tipo_frecuencia_am,
                            n_matriz_qp = item.n_matriz_qp,
                            n_matriz_qm = item.n_matriz_qm,
                            tipo_kaizen = (int)item.tipo_kaizen,
                            n_kaizen = (int)item.n_kaizen,
                            image_path = item.image_path,
                            id_conjunto = (int)item.id_conjunto,
                            image = new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\" + item.image_path)),
                            mttos = daoCal.GetCalendario(item.Id,year),
                            smp_file = item.smp_file
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las conjuntos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public List<Componentes> GetCompCal(int id_conjunto)
        {
            List<Componentes> list = new List<Componentes>();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.componentes
                              join c in context.calendarioPM
                              on b.Id equals c.id_componente into lj
                              from x in lj.DefaultIfEmpty()
                              where b.id_conjunto == id_conjunto
                              select new {b,x};

                    foreach (var item in als.ToList())
                    {
                        list.Add(new Componentes()
                        {
                            //id = item.b.Id,
                            //codigo_fabricante = item.b.codigo_fabricante,
                            //codigo_sap = item.codigo_sap,
                            //descripcion = item.descripcion,
                            //ubicacion_almacen = item.ubicacion_almacen,
                            //clase = item.clase,
                            //proveedor = item.proveedor,
                            //codigo_estrategia_mtto = (int)item.estado_equipo,
                            //id_smp = (int)item.id_smp,
                            //frecuencia_pm = (int)item.frecuencia_pm,
                            //tipo_frecuencia_pm = (int)item.tipo_frecuencia_pm,
                            //duracion_estandar = (int)item.duracion_estandar,
                            //estado_equipo = (int)item.estado_equipo,
                            //estandar_am = (int)item.estandar_am,
                            //frecuencia_am = (int)item.frecuencia_am,
                            //tipo_frecuencia_am = (int)item.tipo_frecuencia_am,
                            //n_matriz_qp = item.n_matriz_qp,
                            //n_matriz_qm = item.n_matriz_qm,
                            //tipo_kaizen = (int)item.tipo_kaizen,
                            //n_kaizen = (int)item.n_kaizen,
                            //image_path = item.image_path,
                            //id_conjunto = (int)item.id_conjunto,
                            //image = new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\" + item.image_path)),
                            //mttos = daoCal.GetCalendario(item.Id)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las conjuntos: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }

        public componentes GetComponentById(int id_componente)
        {
            componentes list = new componentes();

            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.componentes
                              where b.Id == id_componente
                              select b;

                    list = als.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción al consultar componente en especial: " + e);
                //MessageBox.Show("Excepción al consultar maquina en especial: " + e,
                //    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
        
    }
}
