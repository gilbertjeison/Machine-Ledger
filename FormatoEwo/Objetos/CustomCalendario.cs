using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatoEwo.Objetos
{
    public class CustomCalendario
    {
        public int idCalendario{get; set;}
        public int idComponente{get; set;}
        public int idPlanta{get; set;}
        public string maquina{get; set;}
        public string sistema{get; set;}
        public string conjunto{get; set;}
        public string componente{get; set;}
        public int idTipoMtto{get; set;}
        public string tipoMtto{get; set;}
        public int week{get; set;}
        public int year{get; set;}
        public string observacion{get; set;}
    }
}
