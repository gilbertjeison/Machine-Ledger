using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.Objetos;
using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormatoEwo.SubViews
{
    public partial class NuevoItem : MetroForm
    {
        BackgroundWorker bgLoad = new BackgroundWorker();
        Splash splash = new Splash();
        List<CustomLineas> listLines = new List<CustomLineas>();

        DaoLinea daoLin = new DaoLinea();

        private string imagen1 = "";
        Machines m_ = new Machines();
        public Machines maquina { get; set; }

        public NuevoItem(Machines m)
        {
            InitializeComponent();

            bgLoad.DoWork += BgLoad_DoWork;
            bgLoad.RunWorkerCompleted += BgLoad_RunWorkerCompleted;

            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync(m);
            }            
        }

        private void NuevoItem_Load(object sender, EventArgs e)
        {
           
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboLinea.DataSource = listLines;

            if (e.Result != null)
            {
                Machines m = (Machines)e.Result;

                if (m != null)
                {
                    m_ = m;
                    txtNombre.Text = m.nombre;
                    imagen1 = m.foto;
                    cboLinea.SelectedValue = m.id_linea;

                    FileStream stream = new FileStream(Util.Global.DIRECTORIO_IMAGENES + @"\" + m.foto, FileMode.Open, FileAccess.Read);
                    pbImg1.Image = Image.FromStream(stream);
                    stream.Close();
                }
            }
           
            splash.Hide();
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                Machines m = (Machines)e.Argument;
                e.Result = m;
            }            
            
            listLines = daoLin.GetLines(Global.planta_selected);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAcpetar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length > 0 && imagen1.Length>0)
            {                
                m_.nombre = txtNombre.Text.Trim();
                m_.foto = Path.GetFileName(imagen1);
                m_.foto_max = pbImg1.Image;
                m_.id_linea = int.Parse(cboLinea.SelectedValue.ToString());

                maquina
                     = new Machines();
                maquina = m_;

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            imagen1 = SomeHelpers.CargarImagenPictureBox(pbImg1);
        }

        private void cmsImagen1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagen1, e, new List<ToolStripMenuItem>() { tsmVerImagen, itemQuitarImagen }, true, pbImg1);
            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen)
            {
                imagen1 = "";
            }
        }

        
    }
}
