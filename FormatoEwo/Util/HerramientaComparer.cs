using FormatoEwo.Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FormatoEwo.Util
{
    class HerramientaComparer : IComparer
    {

        private int propertyIndex;
        ListSortDirection direction;

        public HerramientaComparer(int propertyIndex, ListSortDirection direction)
        {
            this.propertyIndex = propertyIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            Herramientas obj1 = (Herramientas)x;
            Herramientas obj2 = (Herramientas)y;

            switch (propertyIndex)
            {
                case 1:
                    return CompareStrings(obj1.herramienta, obj2.herramienta);
                case 2:
                    return CompareStrings(obj1.tipo, obj2.tipo);
            
                default:
                    return CompareNumbers((double)obj1.Id, (double)obj2.Id);
            }
        }
        #endregion

        private int CompareStrings(string val1, string val2)
        {
            return string.Compare(val1, val2) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }

        private int CompareDates(DateTime val1, DateTime val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

        private int CompareNumbers(double val1, double val2)
        {
            if (val1 > val2) return (direction == ListSortDirection.Ascending ? 1 : -1);
            if (val1 < val2) return (direction == ListSortDirection.Ascending ? -1 : 1);
            return 0;
        }

    }
}
