using FormatoEwo.Database;
using FormatoEwo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatoEwo.Util
{
    public class Global
    {
        private static int _maqSeleted = 0;

        private static tecnicos _userLoged;

        public static int MaqSelected
        {
            get { return _maqSeleted; }
            set { _maqSeleted = value; }
        }

        private static int _sisSeleted = 0;

        public static int SisSelected
        {
            get { return _sisSeleted; }
            set { _sisSeleted = value; }
        }

        private static int _conSeleted = 0;

        public static int ConSelected
        {
            get { return _conSeleted; }
            set { _conSeleted = value; }
        }

        private static int _compSeleted = 0;

        public static int CompSelected
        {
            get { return _compSeleted; }
            set { _compSeleted = value; }
        }

        public static int MaqDup { get; set; }

        public static Conjuntos conjunto { get; set; }
        public static tecnicos UserLoged { get => _userLoged; set => _userLoged = value; }

        //MODULOS
        //1 -> PM
        //2 -> AM
        public static int Modulo { get => _modulo; set => _modulo = value; }

        public static int planta_selected { get; set; }

        public static CustomLineas selected_line { get; set; }

        public static string DIRECTORIO =
                System.IO.Directory.GetParent
                    ((Environment.CurrentDirectory).ToString())
                           .ToString() + @"\AppFormatos";

        public static string DIRECTORIO_IMAGENES =
                DIRECTORIO + @"\Images";

        public static string DIRECTORIO_BASEDATOS =
                DIRECTORIO + @"\Database";

        public static string DIRECTORIO_FORMATOS =
                DIRECTORIO + @"\Formats";

        public static string ARCHIVO_BASEDATOS =
            "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " 
                + DIRECTORIO_BASEDATOS + @"\EwoDatabase.accdb";

        private static int _modulo;
    }
}
