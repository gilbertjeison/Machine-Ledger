using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class FormLogin: MetroForm
    {
        public FormLogin()
        {
            InitializeComponent();
            
            elementHost1.ChildChanged += ElementHost1_ChildChanged;
            elementHost1.Child = new UserControls.Login();
        }

        private void ElementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            var ctr = (elementHost1.Child as UserControls.Login);
            if (ctr != null)
                ctr.FormsWindow = this;
        }
    }
}
