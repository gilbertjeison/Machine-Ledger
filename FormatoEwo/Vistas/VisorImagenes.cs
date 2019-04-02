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
    public partial class VisorImagenes : Form
    {        
        public string imgShow { get; set; }
        public string b_imgShow { get; set; }
        bool isPath = false;

        public VisorImagenes(bool _isPath)
        {
            InitializeComponent();
            this.isPath = _isPath;
        }

        private void VisorImagenes_Load(object sender, EventArgs e)
        {
            try
            {
                if (isPath)
                {
                    pictureBox1.Image = new Bitmap(imgShow);
                    imgCargando.Visible = false;
                }
                else
                {
                    bgLoadImage.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imágen no válida para mostrar, "+ex.Message);
            }
            
        }
        private void bgLoadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                pictureBox1.Image = Util.SomeHelpers.GetImageFromUrl(b_imgShow);
            });
        }

        private void bgLoadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            imgCargando.Visible = false;
        }
    }
}
