using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarioPMBiBlio
{
    /// <summary>
    /// Lógica de interacción para Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();
            var gridView = new GridView();
            this.lvCalendar.View = gridView;
                      
            for (int i = 0; i < 30; i++)
            {
                DateTime dt = DateTime.Now.AddDays(i);
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = dt.ToShortDateString()

                    //DisplayMemberBinding = new Binding("Id")
                });
            }
        }


    }

    public class MyItem
    {

    }
}
