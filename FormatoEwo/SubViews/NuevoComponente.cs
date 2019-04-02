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
using System.Windows.Forms;

namespace FormatoEwo.SubViews
{
    public partial class NuevoComponente : MetroForm
    {
        DaoML daoML = new DaoML();
        DaoTipos daoTip = new DaoTipos();
        DaoSMP daoSmp = new DaoSMP();
        DaoSMP daoSMP = new DaoSMP();
        private string imagen1 = "";
        Componentes comp;
        private int id_edit;
        List<Conjuntos> listConj = new List<Conjuntos>();
        List<tipos_data> listTipos = new List<tipos_data>();
        List<smp> listSmp = new List<smp>();
        byte[] smp_file;
        string path = "";
        SmpHandler sHan = new SmpHandler();
        Splash splash = new Splash();
        public NuevoComponente(Componentes comp_edit)
        {
            InitializeComponent();

            this.comp = comp_edit;            
        }                

        private void cboSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = ((ComboBox)sender).Items[cboClase.SelectedIndex].ToString();
            
            Color brush;
            if (text.Equals("A"))// compare  date with your list.  
            {
                brush = Color.Red;
            }
            else if (text.Equals("B"))
            {
                brush = Color.Yellow;
            }
            else if (text.Equals("C"))
            {
                brush = Color.Green;
            }
            else 
            {
                brush = Color.White;
            }
            lblClase.BackColor = brush;
            cboClase.BackColor = brush;
        }

        private void NuevoComponente_Load(object sender, EventArgs e)
        {        
            if (!bgLoadData.IsBusy)
            {
                splash.Show();
                bgLoadData.RunWorkerAsync();                    
            }        
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            try
            {
                if (imagen1.Trim().Length > 0)
                {
                    if (txtFabricante.Text.Trim().Length > 0)
                    {
                        if (txtSap.Text.Trim().Length > 0)
                        {
                            if (txtDescripción.Text.Trim().Length > 0)
                            {
                                if (cboClase.SelectedIndex > 0)
                                {
                                    if (!bgSaveData.IsBusy)
                                    {
                                        splash.Show();

                                        Componentes comp = new Componentes();

                                        comp.id = id_edit;
                                        comp.codigo_fabricante = txtFabricante.Text;
                                        comp.codigo_sap = txtSap.Text;
                                        comp.clase = cboClase.Text;
                                        comp.descripcion = txtDescripción.Text;
                                        comp.ubicacion_almacen = txtUbicacion.Text;
                                        comp.proveedor = txtProveedor.Text;
                                        comp.codigo_estrategia_mtto = (int)cboEstrategiaMtto.SelectedValue;
                                        comp.id_smp = cboSmp.SelectedValue != null ? (int)cboSmp.SelectedValue : 0;
                                        comp.duracion_estandar = int.Parse(txtDuracion.Text);
                                        comp.estado_equipo = (int)cboEstadoEquipo.SelectedValue;
                                        comp.frecuencia_pm = int.Parse(txtFrecuenciaPM.Text);
                                        comp.tipo_frecuencia_pm = (int)cboFrecuenciaPM.SelectedValue;
                                        comp.estandar_am = (int)cboEstandarAM.SelectedValue;
                                        comp.frecuencia_am = int.Parse(txtFrecuenciaAM.Text);
                                        comp.tipo_frecuencia_am = (int)cboFrecuenciaAM.SelectedValue;
                                        comp.n_matriz_qp = txtMatrizQP.Text;
                                        comp.n_matriz_qm = txtMatrizQM.Text;
                                        comp.n_kaizen = int.Parse(txtKaizen.Text);
                                        comp.tipo_kaizen = (int)cboTipoKaizen.SelectedValue;
                                        comp.image_path = Path.GetFileName(imagen1);
                                        comp.id_conjunto = (int)cboConjunto.SelectedValue;
                                        comp.smp_file = smp_file;
                                        
                                        bgSaveData.RunWorkerAsync(comp);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por seleccione clasificación!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor ingrese descripción!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor ingrese código SAP!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese código de fabricante!");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor agregue una imagen!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando componente: "+ex.ToString());
            }
        }

        private void bgSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                if (btnAceptar.Tag.ToString().Equals("guardar"))
                {
                    Componentes c = (Componentes)e.Argument;
                    int res = daoML.AddComponente(c);
                    e.Result = res;
                }
                else
                {
                    Componentes c = (Componentes)e.Argument;
                    int res = daoML.EditComponente(c);
                    e.Result = res;
                }
            }
            else
            {
                Console.WriteLine("Es Null");
            }
        }

        private void bgSaveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                int res = (int)e.Result;

                if (res > 0)
                {
                    if (btnAceptar.Tag.ToString().Equals("guardar"))
                    {
                        DialogResult dr =
                        MessageBox.Show("Componente agregado correctamente, desea agregar otro?",
                            "Nuevo componente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            //LIMPIAR FORMULARIO
                            RestartForm();
                        }
                        else
                        {                            
                            //CERRAR VENTANA
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Se cierra despues de editar!");
                        //CERRAR VENTANA
                        DialogResult = DialogResult.OK;
                    }                    
                }
                else
                {
                    MessageBox.Show("No se pudo agregar componente, intente nuevamente!");
                }
            }

            splash.Hide();
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

        private void RestartForm()
        {
            try
            {
                txtFabricante.Text = "0";
                txtSap.Text = "0";
                cboClase.SelectedIndex = 0;
                txtDescripción.Text = "";
                txtProveedor.Text = "";
                txtUbicacion.Text = "";
                imagen1 = "";
                pbImg1.Image = Properties.Resources.placeholder;

                cboEstadoEquipo.SelectedIndex = 0;
                cboEstrategiaMtto.SelectedIndex = 0;
                //cboSmp.SelectedValue != null ? cboSmp.SelectedIndex = 0 : 0;
                txtDuracion.Text = "0";
                txtFrecuenciaPM.Text = "0";
                cboFrecuenciaPM.SelectedIndex = 0;
                cboEstandarAM.SelectedIndex = 0;
                txtFrecuenciaAM.Text = "0";
                cboFrecuenciaAM.SelectedIndex = 0;
                txtMatrizQP.Text = "0";
                txtMatrizQM.Text = "0";
                txtKaizen.Text = "0";
                cboTipoKaizen.SelectedIndex = 0;
                smp_file = null;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mientras se restauraba formulario: "+ex.ToString());
            }            
        }

        private void bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {

            listConj = daoML.GetConjuntos(Global.conjunto.id_sistema);
            listTipos = daoTip.ConsultarTipoComboBox(true);
            listSmp = daoSmp.GetSmps();
        }

        private void bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboConjunto.DataSource = listConj;
            cboEstrategiaMtto.DataSource = listTipos.Where(x => x.id_tipo == 1).ToList();
            cboEstadoEquipo.DataSource = listTipos.Where(x => x.id_tipo == 3).ToList();
            cboFrecuenciaAM.DataSource = listTipos.Where(x => x.id_tipo == 2).ToList();
            cboFrecuenciaPM.BindingContext = new BindingContext();
            cboFrecuenciaPM.DataSource = listTipos.Where(x => x.id_tipo == 2).ToList();
            cboEstandarAM.DataSource = listTipos.Where(x => x.id_tipo == 6).ToList();
            cboTipoKaizen.DataSource = listTipos.Where(x => x.id_tipo == 4).ToList();

            cboSmp.DataSource = listSmp;
            cboClase.SelectedIndex = 0;            
            cboConjunto.SelectedValue = Global.conjunto.id;


            if (comp != null)
            {
                id_edit = comp.id;
                imagen1 = Util.Global.DIRECTORIO_IMAGENES + @"\" + comp.image_path;
                                
                FileStream stream = new FileStream(Util.Global.DIRECTORIO_IMAGENES + @"\" + comp.image_path, FileMode.Open, FileAccess.Read);
                pbImg1.Image = Image.FromStream(stream);
                stream.Close();

                txtFabricante.Text = comp.codigo_fabricante;
                txtSap.Text = comp.codigo_sap;
                cboClase.Text = comp.clase;
                cboConjunto.SelectedValue = comp.id_conjunto;
                txtDescripción.Text = comp.descripcion;
                txtUbicacion.Text = comp.ubicacion_almacen;
                txtProveedor.Text = comp.proveedor;
                cboEstrategiaMtto.SelectedValue = comp.codigo_estrategia_mtto;
                cboSmp.SelectedValue = comp.id_smp;
                txtDuracion.Text = comp.duracion_estandar.ToString();
                cboEstadoEquipo.SelectedValue = comp.estado_equipo;
                txtFrecuenciaPM.Text = comp.frecuencia_pm.ToString();
                cboFrecuenciaPM.SelectedValue = comp.tipo_frecuencia_pm;
                cboEstandarAM.SelectedValue = comp.estandar_am;
                txtFrecuenciaAM.Text = comp.frecuencia_am.ToString();
                cboFrecuenciaAM.SelectedValue = comp.tipo_frecuencia_am;
                txtMatrizQP.Text = comp.n_matriz_qp;
                txtMatrizQM.Text = comp.n_matriz_qm;
                txtKaizen.Text = comp.n_kaizen.ToString();
                cboTipoKaizen.SelectedValue = comp.tipo_kaizen;

               
                btnAceptar.Tag = "editar";
                
            }
            else
            {
                btnAceptar.Tag = "guardar";
            }

            splash.Hide();
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

        private void btnCargarSmp_Click(object sender, EventArgs e)
        {
            try
            {
                smp smp_sel = listSmp.FirstOrDefault(x => x.Id.ToString().Equals(cboSmp.SelectedValue.ToString()));
                sHan.GenerateSmp(smp_sel.Id);            
            }
            catch (Exception ex)
            {
                splash.Hide();
                MessageBox.Show("Item inválido, " + ex.Message.ToLower());
            }
        }

    }
}
