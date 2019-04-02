using FormatoEwo.Objetos;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class FormDetalleEntrada : Form
    {
        public FormDetalleEntrada(Componentes com_sel, string[] param_dates)
        {
            InitializeComponent();
            elementHost1.Child = new UserControls.DetalleEntradaMtto(com_sel, param_dates);
        }
    }
}
