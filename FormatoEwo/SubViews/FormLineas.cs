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

namespace FormatoEwo.SubViews
{
    public partial class FormLineas : MetroForm
    {
        
        public FormLineas(Plantas planta)
        {
            InitializeComponent();
            elementHost1.Child = new UserControls.Lineas(planta);
            
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            var ctr = (elementHost1.Child as UserControls.Lineas);
            if (ctr != null)
                ctr.FormsWindow = this;            
        }
    }
}
