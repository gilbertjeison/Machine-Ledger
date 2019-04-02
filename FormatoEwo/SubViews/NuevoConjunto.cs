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
    public partial class NuevoConjunto : MetroForm
    {
        private string imagen1 = "";

        public Conjuntos conjunto { get; set; }
        public Sistemas sistema { get; set; }
        List<smp> listSmp = new List<smp>();
        List<tipos_data> listTipos = new List<tipos_data>();
        DaoML daoML = new DaoML();
        DaoSMP daoSmp = new DaoSMP();
        DaoTipos daoTip = new DaoTipos();

        Conjuntos con_ = new Conjuntos();

        public NuevoConjunto(Sistemas s, Conjuntos c)
        {
            InitializeComponent();            
           
            cboSistema.DataSource = daoML.GetSystems(s.id_machine);
            sistema = s;
            if (c != null)
            {
                con_ = c;
                txtNombre.Text = c.nombre;
               
                imagen1 = c.image_path;

                FileStream stream = new FileStream(Util.Global.DIRECTORIO_IMAGENES + @"\" + c.image_path, FileMode.Open, FileAccess.Read);
                pbImg1.Image = Image.FromStream(stream);
                stream.Close();
                               
                cboSistema.SelectedValue = c.id_sistema;
            }
            if (s != null)
            {
                cboSistema.SelectedValue = sistema.id;
            }
        }

        private void NuevoConjunto_Load(object sender, EventArgs e)
        {
            listSmp = daoSmp.GetSmps();
            listTipos = daoTip.ConsultarTipoComboBox(true);

            cboSmp.DataSource = listSmp;
            cboEstrategiaMtto.DataSource = listTipos.Where(x => x.id_tipo == 1).ToList();
            cboEstadoEquipo.DataSource = listTipos.Where(x => x.id_tipo == 3).ToList();
            cboFrecuenciaPM.DataSource = listTipos.Where(x => x.id_tipo == 2).ToList();

            cboSmp.SelectedValue = con_.id_smp;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length > 0 && imagen1.Length > 0)
            {
                con_.nombre = txtNombre.Text.Trim();
                con_.image_path = Path.GetFileName(imagen1);
                con_.image = pbImg1.Image;
                con_.id_sistema = (int)cboSistema.SelectedValue;

                if (cboSmp.SelectedIndex>-1)
                {
                    con_.id_smp = (int)cboSmp.SelectedValue;
                }               

                conjunto
                     = new Conjuntos();
                conjunto = con_;

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos!");
            }
        }

        private void cboSmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSmp.SelectedIndex >= 0)
            {
                int smps = int.Parse(cboSmp.SelectedValue.ToString());

                smp s = listSmp.FirstOrDefault(x => x.Id == smps);

                txtDuracion.Text = s.duracion_actividad.ToString();
                cboEstrategiaMtto.SelectedValue = s.tipo_mtto;
                cboEstadoEquipo.SelectedValue = (bool)s.loto ? 8 : 9;
                txtFrecuenciaPM.Text = s.frecuencia.ToString();
                cboFrecuenciaPM.SelectedValue = s.tipo_frecuencia;
            }
        }
    }
}
