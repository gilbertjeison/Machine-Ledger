using FormatoEwo.DaoEF;
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
    public partial class NuevoSistema : MetroForm
    {
        private string imagen1 = "";

        public Sistemas sistema { get; set; }
        public Machines machine { get; set; }
        
        Sistemas sis_ = new Sistemas();
        Machines maq_ = new Machines();
        DaoML daoML = new DaoML();

        public NuevoSistema(Sistemas s, Machines m)
        {            
            InitializeComponent();
            maq_ = m;           
            
            if (s != null)
            {
                sis_ = s;
                txtNombre.Text = s.nombre;
                imagen1 = s.image_path;
                
                FileStream stream = new FileStream(Global.DIRECTORIO_IMAGENES + @"\" + s.image_path, FileMode.Open, FileAccess.Read);                
                pbImg1.Image = Image.FromStream(stream);
                stream.Close();

                cboMaquina.SelectedValue = s.id_machine;                
                this.Text = "Editando sistema";
            }           
        }

        private void NuevoSistema_Load(object sender, EventArgs e)
        {            
            cboMaquina.DataSource = daoML.GetMachines();

            if (maq_ != null)
            {
                cboMaquina.SelectedValue = maq_.id;                
            }
            else if (sis_ != null)
            {
                cboMaquina.SelectedValue = sis_.id_machine;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length > 0 && imagen1.Length > 0)
            {
                sis_.nombre = txtNombre.Text.Trim();
                sis_.image_path = Path.GetFileName(imagen1);
                sis_.image = pbImg1.Image;
                sis_.id_machine = (int)cboMaquina.SelectedValue;

                sistema
                     = new Sistemas();
                sistema = sis_;

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos!");
            }
        }

        private void pbImg1_Click(object sender, EventArgs e)
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
