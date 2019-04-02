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
    public partial class Configuraciones : MetroForm
    {
        public Configuraciones()
        {
            InitializeComponent();
            txtRuta.Text = Properties.Settings.Default["MachineLedger"].ToString();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog())
            {
                dlg.Title = "Abrir Excel";
                dlg.Filter = "Libro de excel para macros (*.xlsm)|*.xlsm";

                if (dlg.ShowDialog() == DialogResult.OK)
                {                    
                    txtRuta.Text = dlg.FileName;
                }
            }            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["MachineLedger"] = txtRuta.Text;
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
        }
    }
}
