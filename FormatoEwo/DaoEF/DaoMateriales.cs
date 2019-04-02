using FormatoEwo.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FormatoEwo.DaoEF
{
    public class DaoMateriales
    {
        public int SaveMaterial(materiales m)
        {
            WarehouseEntities data = new WarehouseEntities();
            int res = 0;
            data.materiales.Add(m);

            try
            {
                res = data.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción guardando material: " + ex.Message);
            }
            return res;
        }

        public void DeleteAllMaterial()
        {
            WarehouseEntities data = new WarehouseEntities();

            data.Database.ExecuteSqlCommand("TRUNCATE TABLE materiales");

            try
            {
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción eleminando todos los materiales: " + ex.Message);
            }
        }

        public List<materiales> GetAllMateriales()
        {
            List<materiales> list = new List<materiales>();
            WarehouseEntities data = new WarehouseEntities();

            try
            {
                var query = data.materiales;

                list = query.ToList();
                data.Dispose();
            }
            catch (Exception e)
            {
                Console.Write("Excepción mientras se consultaban los materiales: " + e);
            }

            return list;
        }

        public int GetAllMaterialesCount()
        {
            int list = 0;
            WarehouseEntities data = new WarehouseEntities();

            try
            {
                var query = (from m in data.materiales select m).Count();

                list = query;
                data.Dispose();
            }
            catch (Exception e)
            {
                Console.Write("Excepción mientras se consultaban los materiales: " + e);
            }

            return list;
        }

        public DateTime[] GetMinAndMaxDate()
        {
            DateTime[] list = new DateTime[2];
            WarehouseEntities data = new WarehouseEntities();

            try
            {
                var query = data.materiales;

                list[0] = query.Max(x => x.fecha_salida);
                list[1] = query.Min(x => x.fecha_salida);

                data.Dispose();
            }
            catch (Exception e)
            {
                Console.Write("Excepción mientras se consultaban los materiales: " + e);
            }

            return list;
        }


        public List<MaxAndMin> MaxAndMin(int opcion)
        {
            using (var context = new WarehouseEntities())
            {
                var parameter = new SqlParameter("@tipo", opcion);

                return context.Database
                    .SqlQuery<MaxAndMin>("GetMaxAndMinStock @tipo", parameter)
                    .ToList();
            }
        }
    
    }

    public class MaxAndMin
    {
        public string material { get; set; }

        public string descripcion { get; set; }

        public string fecha { get; set; }

        public decimal cantidad { get; set; }

        public decimal minimo { get; set; }

        public decimal maximo { get; set; }

        public int planta { get; set; }

        public string ubicacion { get; set; }
    }
}
