using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FormatoEwo.DaoEF
{
    public class DaoLinea
    {
        DaoML daoMl = new DaoML();
        DaoCalPM daoCal = new DaoCalPM();

        public int AddLine(lineas lin)
        {
            int regs = 0;

            try
            {
                using (var context = new MttoAppEntities())
                {
                    context.lineas.Add(new lineas() { id_planta = lin.id_planta, nombre = lin.nombre, image_path = lin.image_path });
                    regs = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al agregar línea: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return regs;
        }

        public List<CustomLineas> GetLines(int id_planta)
        {
            List<lineas> list = new List<lineas>();

            List<CustomLineas> listCL = new List<CustomLineas>();
            try
            {
                using (var context = new MttoAppEntities())
                {
                    // Query for all
                    var als = from b in context.lineas
                              where b.id_planta == id_planta
                              select b;

                    list = als.ToList();
                }

                foreach (var item in list)
                {
                    listCL.Add(new CustomLineas()
                    {
                        id = item.id,
                        cant_maqs = daoMl.GetMachines(item.id).ToList().Count,
                        cant_mttos = daoCal.GetCalendarioCurrentWeek(item.id, GetIso8601WeekOfYear(DateTime.Now), DateTime.Now.Year).ToList().Count,
                        id_planta = (int)item.id_planta,
                        image = item.image_path == null ? new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\default2.JPG")) : new BitmapImage(new Uri(Util.Global.DIRECTORIO_IMAGENES + @"\" + item.image_path)),
                        image_path = item.image_path,
                        nombre = item.nombre                        
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar las líneas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return listCL;
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public int EditLinea(lineas lin)
        {
            lineas line;

            int regs = 0;

            try
            {
                //1. Get row from DB
                using (var context = new MttoAppEntities())
                {
                    line = context.lineas.Where(s => s.id == lin.id).FirstOrDefault();
                }

                //2. change data in disconnected mode (out of ctx scope)
                if (line != null)
                {
                    line.nombre = lin.nombre;
                    line.image_path = lin.image_path;
                    line.id_planta = lin.id_planta;
                }

                //save modified entity using new Context
                using (var context = new MttoAppEntities())
                {
                    //3. Mark entity as modified
                    context.Entry(line).State = System.Data.Entity.EntityState.Modified;

                    //4. call SaveChanges
                    regs = context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al editar linea: " + e.ToString(), "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    var query = (from b in context.lineas select b.image_path);

                    list = query.ToList();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción al consultar imagenes en lineas: " + e,
                    "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return list;
        }
    }
}
