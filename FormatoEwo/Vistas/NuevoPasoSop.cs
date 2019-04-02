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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class NuevoPasoSop : MetroForm
    {
        public PasoaPaso pp { get; set; }

        public NuevoPasoSop(PasoaPaso p, int pasos, List<Objetos.Herramientas> listHerr)
        {
            InitializeComponent();


            if (p == null)
            {
                pp = new PasoaPaso();
                pp.imagen_paso_path = "";
                txtNumPaso.Text = (pasos + 1).ToString();
                cboHerramienta.DataSource = listHerr;
            }
            else
            {
                pp = p;
                dtpDuracion.Text = pp.duracion;
                txtDescripcion.Text = pp.desc;
                pbImg1.Image = pp.imagen_paso;



            }
        }

        private void pbImg1_Click(object sender, EventArgs e)
        {
            pp.imagen_paso_path = Path.GetFileName(SomeHelpers.CargarImagenPictureBox(pbImg1));
        }

        private void cmsImagen1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(pp.imagen_paso_path, e, new List<ToolStripMenuItem>() { tsmVerImagen, itemQuitarImagen }, true, pbImg1);
            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen)
            {
                pp.imagen_paso_path = "";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Trim().Length > 0  
                    && dtpDuracion.Text.Length > 0 
                        && pp.imagen_paso_path.Length > 0)
            {
                pp.numPaso = int.Parse(txtNumPaso.Text);
                pp.desc = txtDescripcion.Text;
                pp.duracion = dtpDuracion.Text;
                pp.imagen_paso = pbImg1.Image;
                pp.codigo_herramienta = cboHerramienta.Items.Count > 0 ? int.Parse(cboHerramienta.SelectedValue.ToString()) : 0;
                pp.herramienta = cboHerramienta.Items.Count > 0 ? cboHerramienta.Text : "no registra";

                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar diligenciados!");
            }
        }
    }
}
