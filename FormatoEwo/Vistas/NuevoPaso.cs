using FormatoEwo.Objetos;
using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class NuevoPaso : MetroForm
    {
        public PasoaPaso pp { get; set; }
        /// <summary>
        /// Acción 0 para agregar, 1 para editar
        /// </summary>
        /// <param name="accion"></param>
        public NuevoPaso(PasoaPaso p)
        {
            InitializeComponent();
            if (p == null)
            {
                pp = new PasoaPaso();
                pp.imagen_paso_path = "";
            }
            else
            {
                pp = p;
                txtPaso.Text = pp.paso;
                txtDuracion.Text = pp.duracion;
                txtDescripcion.Text = pp.desc;
                pbImg1.Image = pp.imagen_paso;

                switch (pp.categoria)
                {
                    case "1":
                        rbSafety.Checked = true;
                        break;
                    case "2":
                        rbQuality.Checked = true;
                        break;
                    case "3":
                        rbEnvironment.Checked = true;
                        break;
                    case "4":
                        rbProductivity.Checked = true;
                        break;
                    default:
                        break;
                }
                
            }

            //GUARDAR IMAGENES DE CATEGORÍAS EN CARPETAS SINO EXISTEN
            for (int i = 0; i < categoryImages.Images.Count; i++)
            {
                string ruta_destino = Util.Global.DIRECTORIO_IMAGENES + @"\" + categoryImages.Images.Keys[i].ToString();

                if (!File.Exists(ruta_destino))
                {
                    categoryImages.Images[i].Save(ruta_destino);
                }
            }
        }
                

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void cmsImagen1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(pp.imagen_paso_path, e, new List<ToolStripMenuItem>() {tsmVerImagen,itemQuitarImagen }, true,pbImg1);
            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen)
            {
                pp.imagen_paso_path = "";
            }
        }

        private void pbImg1_Click(object sender, EventArgs e)
        {
            pp.imagen_paso_path = Path.GetFileName(SomeHelpers.CargarImagenPictureBox(pbImg1));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtPaso.Text.Trim().Length > 0 && txtDescripcion.Text.Trim().Length > 0
                    && txtDuracion.Text.Length > 0 && pp.imagen_paso_path.Length > 0 && pp.categoria != null)
            {
                pp.paso = txtPaso.Text;
                pp.desc = txtDescripcion.Text;
                pp.duracion = txtDuracion.Text;
                pp.imagen_paso = pbImg1.Image;
                
                DialogResult = DialogResult.OK;
                Dispose();
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar diligenciados!");
            }           
        }

        private void rbSafety_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;

            if (btn != null && btn.Checked)
            {
               switch(btn.Name)
               {
                    case "rbSafety":
                        pp.categoria = "Safety";
                        pp.categoria_img = pbSafety.Image;
                    break;
                        
                    case "rbQuality":
                        pp.categoria = "Quality";
                        pp.categoria_img = pbQuality.Image;
                        break;

                    case "rbEnvironment":
                        pp.categoria = "Environment";
                        pp.categoria_img = pbEnvironment.Image;
                        break;
                        
                    case "rbProductivity":
                        pp.categoria = "Productivity";
                        pp.categoria_img = pbProductivity.Image;
                        break;
                }
            }
        }
    }
}
