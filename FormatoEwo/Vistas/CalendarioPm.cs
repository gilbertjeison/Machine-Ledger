using FormatoEwo.Dao;
using FormatoEwo.Objetos;
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
    public partial class CalendarioPm : MetroForm
    {
        public CalendarioPm()
        {
            InitializeComponent();
            this.FormClosed += CalendarioPm_FormClosed;
            this.Text = "Calendario PM - "+ Util.Global.conjunto.nombre;
            this.UpdateStyles();
        }

        private void CalendarioPm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
    }
}
