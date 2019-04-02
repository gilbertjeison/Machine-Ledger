using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FormatoEwo.Objetos
{
    public class Componentes
    {
        public int id { get; set; }
        public string codigo_fabricante { get; set; }
        public string codigo_sap { get; set; }
        public string descripcion { get; set; }
        public string ubicacion_almacen { get; set; }
        public string clase { get; set; }
        public string proveedor { get; set; }
        public int codigo_estrategia_mtto { get; set; }
        public int id_smp { get; set; }
        public int frecuencia_pm { get; set; }
        public int tipo_frecuencia_pm { get; set; }
        public int duracion_estandar { get; set; }
        public int estado_equipo { get; set; }
        public int estandar_am { get; set; }
        public int frecuencia_am { get; set; }
        public int tipo_frecuencia_am { get; set; }
        public string n_matriz_qp { get; set; }
        public string n_matriz_qm { get; set; }
        public int tipo_kaizen { get; set; }
        public int n_kaizen { get; set; }
        public string image_path { get; set; }
        public BitmapImage image { get; set; }
        public int id_conjunto { get; set; }
        public byte[] smp_file { get; set; }

        public List<CalendarioPm> mttos { get; set; }


    }
}
