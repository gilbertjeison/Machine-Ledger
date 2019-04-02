using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using FormatoEwo.Util;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class FormSmp : MetroForm
    {
        DaoSMP daoSmp = new DaoSMP();
        DaoEquipos daoEq = new DaoEquipos();
        DaoTipos daoTip = new DaoTipos();
        DaoPersonal daoPer = new DaoPersonal();
        DaoEpps daoEpp = new DaoEpps();
        DaoPasoPaso daoPP = new DaoPasoPaso();
        List<equipos> listEq = new List<equipos>();
        List<tipos_data> listTipo = new List<tipos_data>();
        List<tecnicos> listTec = new List<tecnicos>();
        List<Epps> listEpps = new List<Epps>();
        List<Objetos.Repuestos> listR = new List<Objetos.Repuestos>();
        List<Objetos.Herramientas> list = new List<Objetos.Herramientas>();
        List<PasoaPaso> listPasos = new List<PasoaPaso>();
        List<Validacionescs> listVal = new List<Validacionescs>();
        BindingSource bs = new BindingSource();
        int dur_act = 0;
        private string path;
        string imagen1 = "";
        string imagen2 = "";
        System.Data.DataTable dt_epps = new System.Data.DataTable();
        System.Data.DataTable dt_herramientas = new System.Data.DataTable();
        System.Data.DataTable dt_repuestos = new System.Data.DataTable();
        System.Data.DataTable dt_pasos = new System.Data.DataTable();

        Splash splash = new Splash();

        public FormSmp()
        {
            InitializeComponent();
        }

        private void FormSmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void FormSmp_Load(object sender, EventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
        }

        private void bgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dtgEpps.Rows.Count; i++)
            {
                dtgEpps.Rows[i].Height = 120;
            }

            listEpps = daoEpp.GetEpps();
            foreach (Epps item in listEpps)
            {
                item.imagen = EppsImages.Images[item.path_image];
            }
                        
            listTipo = daoTip.ConsultarTipoComboBox(true);
            listTec = daoPer.ConsultarTecnicosComboBox();
            listEq = daoEq.ConsultarEquiposComboBox();
            e.Result = daoSmp.GetLastConsecutive().ToString();
        }

        private void bgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboAreaLinea.DataSource = listTipo.Where(x => x.id_tipo == 14).ToList();
            cboClasificación.DataSource = listTipo.Where(x => x.id_tipo == 15).ToList();
            cboFrecuencia.DataSource = listTipo.Where(x => x.id_tipo == 2).ToList();
            cboTipoMtto.DataSource = listTipo.Where(x => x.id_tipo == 1).ToList();
            cboElaborador.DataSource = listTec;
            cboAprobador.BindingContext = new BindingContext();
            cboAprobador.DataSource = listTec;
            cboEquipo.DataSource = listEq;
            txtConsecutivo.Text = e.Result.ToString();
            dtgEpps.DataSource = listEpps;

            var listPer = listTipo.Where(x => x.id_tipo == 12).ToList();

            //CARGAR PERMISOS DE TRABAJO
            foreach (tipos_data item in listPer)
            {
                chlbPermisosRequeridos.Items.Add(item.descripcion);
            }

            //cboClasificación.SelectedIndex = 0;
            //cboTipoMtto.SelectedIndex = 0;
            //cboFrecuencia.SelectedIndex = 0;
            lblDisponibles.Text = dtgEpps.Rows.Count.ToString();

            dtgEpps.CellValueChanged += new DataGridViewCellEventHandler(dtgEpps_CellValueChanged);

            dtgPasoAPaso.AutoGenerateColumns = false;

            this.Text = "@" + DateTime.Now.Year + " SMP(Procedimiento Estandar de Mantenimiento)";

            splash.Hide();          
            
            
        }

        private void dtgEpps_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dtgEpps.Rows[e.RowIndex].Cells[1];

                var checkedRows = from DataGridViewRow r in dtgEpps.Rows
                                  where Convert.ToBoolean(r.Cells[1].Value) == true
                                  select r;

                listEpps[e.RowIndex].sel = (bool)checkCell.Value;
                lblSeleccionados.Text = checkedRows.ToList().Count.ToString();

                dtgEpps.Invalidate();
            }
        }

        private void dtgEpps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgEpps.IsCurrentCellDirty)
            {
                dtgEpps.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim().Length > 0)
            {
                foreach (System.Windows.Forms.DataGridViewRow r in dtgEpps.Rows)
                {
                    if ((r.Cells[2].Value).ToString().Contains(txtBuscar.Text) || (r.Cells[3].Value).ToString().ToUpper().Contains(txtBuscar.Text.ToUpper()))
                    {
                        dtgEpps.Rows[r.Index].Visible = true;
                        dtgEpps.Rows[r.Index].Selected = true;
                    }
                    else
                    {
                        dtgEpps.CurrentCell = null;
                        dtgEpps.Rows[r.Index].Visible = false;
                    }

                    var rv = from DataGridViewRow ra in dtgEpps.Rows
                             where Convert.ToBoolean(ra.Visible) == true
                             select ra;

                    lblDisponibles.Text = rv.ToList().Count.ToString();
                }
            }
            else
            {
                dtgEpps.DataSource = null;
                dtgEpps.DataSource = listEpps;
                dtgEpps.Columns["id"].Visible = false;
                dtgEpps.Columns["path_image"].Visible = false;
                dtgEpps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lblDisponibles.Text = dtgEpps.Rows.Count.ToString();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!bgSaveData.IsBusy)
            {
                try
                {
                    splash.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                lblGenerando.Visible = true;
                
                bgSaveData.RunWorkerAsync();
            }
        }

        private Microsoft.Office.Interop.Excel.Range GetRangeImageEpp(Worksheet w, int index)
        {
            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)w.Cells[8, index];
            return rIm;
        }

        private Microsoft.Office.Interop.Excel.Range GetRangeImageRisk(Worksheet w, int index)
        {
            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)w.Cells[16, index];
            return rIm;
        }

        private Microsoft.Office.Interop.Excel.Range GetRangeHerramienta(Worksheet w, double row, int index)
        {
            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)w.Cells[row, index];
            rIm.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            return rIm;
        }

        public static System.Data.DataTable FillEpps(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Index == 4)
                {
                    dt.Columns.Add(col.HeaderText, typeof(Image));
                }
                else
                {
                    dt.Columns.Add(col.HeaderText, typeof(string));
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();

                if ((bool)row.Cells[1].Value)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }
            }

            return dt;
        }

        public static System.Data.DataTable FillRepuestos(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Index == 4)
                {
                    dt.Columns.Add(col.HeaderText, typeof(Image));
                }
                else
                {
                    dt.Columns.Add(col.HeaderText, typeof(string));
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }

        public static System.Data.DataTable FillHerramientas(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Index == 4)
                {
                    dt.Columns.Add(col.HeaderText, typeof(Image));
                }
                else
                {
                    dt.Columns.Add(col.HeaderText, typeof(string));
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();

                if ((bool)row.Cells[0].Value)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }
            }

            return dt;
        }

        public static System.Data.DataTable FillPasoPaso(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                //Console.WriteLine( col.HeaderText);
                if (col.Index == 4 || col.Index == 5)
                {
                    dt.Columns.Add(col.HeaderText, typeof(Image));
                }
                else
                {
                    dt.Columns.Add(col.HeaderText, typeof(string));
                }
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void FillCell(Worksheet w, int row, int column, string value)
        {
            w.Cells[row, column] = (string)(w.Cells[row, column]
                as Microsoft.Office.Interop.Excel.Range).Value + " " + value;
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
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

        private void pbImg1_Click(object sender, EventArgs e)
        {
            imagen1 = SomeHelpers.CargarImagenPictureBox(pbImg1);
        }

        private void pbImg2_Click(object sender, EventArgs e)
        {
            imagen2 = SomeHelpers.CargarImagenPictureBox(pbImg2);
        }

        private void cmsImagen2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagen2, e, new List<ToolStripMenuItem>()
            {
                tsmVerImagen2,
                itemQuitarImagen2
            }, true, pbImg2);

            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen2)
            {
                imagen2 = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRepuestos r = new FRepuestos();

            if (r.ShowDialog() == DialogResult.OK)
            {
                listR = r.listRep;
                dtgRep.DataSource = listR;
                dtgRep.Visible = true;
                lblCargados.Text = listR.Count.ToString();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Herramientas h = new Herramientas();

            if (h.ShowDialog() == DialogResult.OK)
            {
                list = h.listRet;
                dtgHerr.DataSource = list;
                dtgHerr.Columns[5].Visible = false;
                dtgHerr.Visible = true;
                lblCargadas.Text = list.Count.ToString();
            }
        }

        private void btnPaso_Click(object sender, EventArgs e)
        {
            NuevoPaso np = new NuevoPaso(null);

            if (np.ShowDialog() == DialogResult.OK)
            {
                listPasos.Add(np.pp);
                bs.DataSource = listPasos;
                dtgPasoAPaso.DataSource = bs;
                bs.ResetBindings(true);
                dtgPasoAPaso.Visible = true;
                lblPaPCargados.Text = listPasos.Count.ToString();


                //SUMA DE LA ACTIVIDAD TOTAL
                dur_act = listPasos.Sum(x => int.Parse(x.duracion));
                txtDuracionActividad.Text = dur_act.ToString();
            }
        }

        private void dtgPasoAPaso_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgPasoAPaso.SelectedRows.Count > 0)
            {
                btnEditar.Visible = true;
            }
            else
            {
                btnEditar.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            NuevoPaso np = new NuevoPaso(listPasos[dtgPasoAPaso.SelectedRows[0].Index]);

            if (np.ShowDialog() == DialogResult.OK)
            {                
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].id_smp = np.pp.id_smp;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].paso = np.pp.paso;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].desc = np.pp.desc;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].duracion = np.pp.duracion;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].categoria_img = np.pp.categoria_img;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].imagen_paso = np.pp.imagen_paso;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].imagen_paso_path = np.pp.imagen_paso_path;
                listPasos[dtgPasoAPaso.SelectedRows[0].Index].categoria_img = np.pp.categoria_img;

                bs.DataSource = listPasos;
                dtgPasoAPaso.DataSource = bs;
                dtgPasoAPaso.Refresh();
                lblPaPCargados.Text = listPasos.Count.ToString();

                dur_act = listPasos.Sum(x => int.Parse(x.duracion));
                txtDuracionActividad.Text = dur_act.ToString();
            }
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            switch (tabcontrol.SelectedIndex)
            {
                case 0:
                    ValidaciónPag1();
                    break;
                case 1:
                    ValidaciónPag2();
                    break;
                case 2:
                    ValidaciónPag3();
                    break;
                case 3:
                    ValidaciónPag4();
                    break;
                case 4:
                    ValidaciónPag5();
                    break;
                default:
                    break;
            }

            switch (listVal.Count)
            {
                case 1:
                    pbLoad.Value = 20;
                    lblPorcentaje.Text = "20%";
                    break;

                case 2:
                    pbLoad.Value = 40;
                    lblPorcentaje.Text = "40%";
                    break;

                case 3:
                    pbLoad.Value = 60;
                    lblPorcentaje.Text = "60%";
                    break;

                case 4:
                    pbLoad.Value = 80;
                    lblPorcentaje.Text = "80%";
                    break;

                case 5:
                    pbLoad.Value = 100;
                    lblPorcentaje.Text = "100%";
                    btnExportar.Visible = true;
                    chkPDF.Visible = true;
                    break;
            }
        }
        private void ValidaciónPag5()
        {
            if (int.Parse(lblPaPCargados.Text) > 0)
            {
                ValidarPestañaGen(tabPasoPaso);                
            }
            else
            {
                MessageBox.Show("Se debe diligenciar un paso a paso!");
            }
        }

        private void ValidaciónPag4()
        {
            if (int.Parse(lblCargados.Text) > 0)
            {
                ValidarPestañaGen(tabRepuestos);
            }
            else
            {
                MessageBox.Show("Se deben seleccionar los repuestos!");
            }
        }

        private void ValidaciónPag3()
        {
            if (int.Parse(lblCargadas.Text) > 0)
            {
                ValidarPestañaGen(tabHerramientas);
                dt_herramientas = FillHerramientas(dtgHerr);
            }
            else
            {
                MessageBox.Show("Se deben seleccionar las herramientas!");
            }
        }

        private void ValidaciónPag2()
        {
            if (int.Parse(lblSeleccionados.Text) > 0)
            {
                ValidarPestañaGen(tabEpps);
            }
            else
            {
                MessageBox.Show("Se deben seleccionar los elementos de protección personal!");
            }
        }

        private void ValidaciónPag1()
        {
            if (txtNombreSMP.Text.Trim().Length > 0)
            {
                if (cboEquipo.Text.Trim().Length > 0)
                {
                    if (cboAreaLinea.Text.Trim().Length > 0)
                    {
                        if (txtSMP.Text.Trim().Length > 0)
                        {
                            if (txtTecnicosRequeridos.Text.Trim().Length > 0)
                            {
                                if (txtDuracionActividad.Text.Trim().Length > 0)
                                {
                                    if (txtTiempoEquipoParado.Text.Trim().Length > 0)
                                    {
                                        if (txtFrecuencia.Text.Trim().Length > 0)
                                        {
                                            if (cboElaborador.Text.Trim().Length > 0)
                                            {
                                                if (cboAprobador.Text.Trim().Length > 0)
                                                {
                                                    if (chlbPermisosRequeridos.CheckedItems.Count > 0)
                                                    {
                                                        if (!imagen1.Equals("") || !imagen2.Equals(""))
                                                        {
                                                            ValidarPestañaGen(tabInformacionBasica);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Se debe agregar al menos una imágen!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Al menos debe estar un permiso requerido seleccionado!");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No hay aprobador seleccionado!");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("No hay elaborador seleccionado!");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Se debe escribir frecuencia!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Se debe escribir el tiempo de equipo parado!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Se debe escribir duración de actividad!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se debe escribir # técnicos requeridos!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se debe escribir SMP #!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay Área/Línea seleccionada!");
                    }
                }
                else
                {
                    MessageBox.Show("No hay equipo seleccionado!");
                }
            }
            else
            {
                MessageBox.Show("Se debe escribir nombre de SMP!");
            }
        }
       
        private void ValidarPestañaGen(TabPage tp)
        {
            int np = tabcontrol.TabPages.IndexOf(tp) + 1;
            bool encontrada = false;
            foreach (Validacionescs v in listVal)
            {
                if (v.pestaña == np)
                {
                    encontrada = true;
                    break;
                }
            }
            if (encontrada)
            {
                MessageBox.Show("Pestaña ya validada!");
            }
            else
            {
                listVal.Add(new Validacionescs() { pestaña = np, validado = true });
                //EnableTab(tp, false);
            }
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }

        private void txtFrecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void bgSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {                    
                    //LLENAR RESPECTIVOS DATATABLES PARA VALIDAR INFORMACIÓN A GUARDAR
                    dt_epps = FillEpps(dtgEpps);
                    dt_repuestos = FillRepuestos(dtgRep);
                    dt_pasos = FillPasoPaso(dtgPasoAPaso);


                    System.Windows.Forms.Application.DoEvents();


                    //GUARDAR EN BASE DE DATOS
                    smp smp = new smp();

                    smp.consecutivo = int.Parse(txtConsecutivo.Text);
                    smp.nombre = txtNombreSMP.Text.Trim();
                    smp.numero = long.Parse(txtSMP.Text);
                    smp.id_linea = int.Parse(cboAreaLinea.SelectedValue.ToString());
                    smp.id_equipo = int.Parse(cboEquipo.SelectedValue.ToString());
                    smp.feha_smp = dtpFecha.Value;
                    smp.clasificacion = int.Parse(cboClasificación.SelectedValue.ToString());
                    smp.tipo_mtto = int.Parse(cboTipoMtto.SelectedValue.ToString());
                    smp.tecnicos_req = int.Parse(txtTecnicosRequeridos.Text);
                    smp.duracion_actividad = int.Parse(txtDuracionActividad.Text);
                    smp.equipo_parado = int.Parse(txtTiempoEquipoParado.Text);
                    smp.frecuencia = int.Parse(txtFrecuencia.Text);
                    smp.tipo_frecuencia = int.Parse(cboFrecuencia.SelectedValue.ToString());
                    smp.id_elaborador = int.Parse(cboElaborador.SelectedValue.ToString());
                    smp.id_aprobador = int.Parse(cboAprobador.SelectedValue.ToString());
                    smp.loto = rbLotoSi.Checked;
                    smp.user_id = Util.Global.UserLoged.Id;

                    //PERMISOS CHEKEADOS
                    foreach (object itemChecked in chlbPermisosRequeridos.CheckedItems)
                    {
                        smp.permisos += itemChecked.ToString() + ",";
                    }

                    //QUITAR ULTIMA COMA
                    smp.permisos = smp.permisos.TrimEnd(',');
                    smp.imagen_1 = Path.GetFileName(imagen1);
                    smp.imagen_2 = Path.GetFileName(imagen2);

                    //GUARDAR OBJETO EN BASE DE DATOS
                    int id_smp = daoSmp.AddSmp(smp);
                    
                    System.Windows.Forms.Application.DoEvents();
                    
                    //PENDIENTE GUARDAR EPPS, HERRAMIENTAS, PASOS, REPUESTOS
                    //E INDEPENDIZAR PERMISOS DE RIESGOS
                    if (id_smp > 0)
                    {
                        //AGREGAR EPPS
                        for (int i = 0; i < listEpps.Count; i++)
                        {
                            if (listEpps[i].sel)
                            {
                                daoSmp.AddSmpUtil(new smp_util()
                                {
                                    id_smp = id_smp,
                                    id_tipo = 9,
                                    id_util = listEpps[i].id
                                });
                            }
                        }

                        foreach (Objetos.Herramientas item in list)
                        {
                            if (item.sel)
                            {
                                daoSmp.AddSmpUtil(new smp_util()
                                {
                                    id_smp = id_smp,
                                    id_tipo = 10,
                                    id_util = item.Id
                                });
                            }
                        }

                        foreach (Objetos.Repuestos item in listR)
                        {
                            if (item.sel)
                            {
                                daoSmp.AddSmpUtil(new smp_util()
                                {
                                    id_smp = id_smp,
                                    id_tipo = 11,
                                    id_util = item.Id
                                });
                            }
                        }

                        foreach (PasoaPaso item in listPasos)
                        {
                            daoPP.AddPaso(new smp_pasos()
                            {
                                categoria_id = daoTip.GetTipoByDesc(item.categoria) != null ? daoTip.GetTipoByDesc(item.categoria).Id : 0,
                                descripcion = item.desc,
                                duracion = int.Parse(item.duracion),
                                id_smp = id_smp,
                                paso = item.paso,
                                image_path = item.imagen_paso_path
                            });
                            //item.Id = daoPP.GetPasoByDesc(item.paso, item.desc).Id;                               
                        }
                    }
                    
                    System.Windows.Forms.Application.DoEvents();
                    
                    //GENERAR EXCEL
                    //OBEJTO QUE PERMITE GESTIONAR DOCUMENTO EXCEL
                    Microsoft.Office.Interop.Excel.Application xlApp =
                            new Microsoft.Office.Interop.Excel.Application();

                    //NO MOSTRAR ARCHIVO MIENTRAS SE UTILIZA
                    xlApp.Visible = false;
                    xlApp.Interactive = false;

                    //DIRECTORIO DONDE SE COPIARÁ EL ARCHIVO TEMPORALMENTE
                    //PARA EDITARLO
                    string sru = Util.Global.DIRECTORIO_FORMATOS;

                    //NOMBRE DEL ARCHIVO TEMPORAL
                    path = @"" + sru + "\\SMP.xlsx";

                    //COPIAR EL ARCHIVO DE LOS RECURSOS DE LA APLICACIÓN
                    // A LA RUTA ESTABLECIDA
                    File.WriteAllBytes(path, Properties.Resources.SMP_MODIFICADO);

                    //VERIFICAR SI EL ARCHIVO ESTÁ BLOQUEADO O ESTA SIENDO UTILIZADO POR OTRO PROCESO
                    if (IsFileLocked(new FileInfo(path)))
                    {
                        MessageBox.Show("El archivo se está ejecutando, debe cerrarlo para continuar",
                                "Exportar en Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.Windows.Forms.Application.DoEvents();
                        
                        //CREAR EL OBJETO DEL LIBRO A PARTIR DE LA RUTA 
                        Workbook wb = xlApp.Workbooks.Open(path);

                        //FIJAR EN OBJETOS LAS PESTAÑAS U HOJA DEL LIBRO PARA TRABAJAR
                        Worksheet ws2 = (Worksheet)wb.Worksheets[1];

                        //////////////////////////////////////////////////
                        //**************** INFORMACIÓN BÁSICA ************
                        //////////////////////////////////////////////////      
                        //LINEA
                        FillCell(ws2, 3, 5, cboAreaLinea.Text.ToString());
                        //EQUIPO
                        FillCell(ws2, 4, 5, cboEquipo.Text.ToString());
                        //CLASDIFICACIÓN SMP
                        FillCell(ws2, 5, 5, cboClasificación.Text.ToString());
                        //NOMBRE SMP
                        FillCell(ws2, 2, 14, txtNombreSMP.Text.ToString());
                        //NÚMERO SMP
                        FillCell(ws2, 3, 18, txtSMP.Text.ToString());
                        //ELABORADO POR
                        FillCell(ws2, 3, 25, cboElaborador.Text.ToString());
                        //APROBADO POR
                        FillCell(ws2, 3, 35, cboAprobador.Text.ToString());
                        //FECHA
                        FillCell(ws2, 4, 40, dtpFecha.Value.ToShortDateString());
                        //NÚMERO DE TECNICOS REQUERIDOS
                        FillCell(ws2, 5, 14, txtTecnicosRequeridos.Text.ToString());
                        //TIPO MANTENIMIENTO
                        FillCell(ws2, 5, 24, cboTipoMtto.Text.ToString());
                        //DURACIÓN DE LA ACTIVIDAD
                        FillCell(ws2, 5, 30, txtDuracionActividad.Text.ToString());
                        //TIEMPO EQUIPO PARADO
                        FillCell(ws2, 5, 35, txtTiempoEquipoParado.Text.ToString());
                        //FREUENCIA
                        FillCell(ws2, 5, 41, txtFrecuencia.Text.ToString() + " " + cboFrecuencia.Text.ToString());
                        //LOTO
                        FillCell(ws2, 16, 3, rbLotoSi.Checked ? "SI" : "NO");
                        //IMAGEN 1                
                        if (!imagen1.Equals(""))
                        {
                            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[7, 9];
                            SomeHelpers.AddImageExcel(ws2, imagen1, (float)rIm.Left + 1, (float)rIm.Top + 1, 152, 150);
                        }
                        //IMAGEN 2                
                        if (!imagen2.Equals(""))
                        {
                            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[7, 21];
                            SomeHelpers.AddImageExcel(ws2, imagen2, (float)rIm.Left + 1, (float)rIm.Top + 1, 152, 150);
                        }
                        //TO DO: YA SABE

                        //PERMISOS DE TRABAJO
                        int k = 0;
                        for (int i = 5; i <= 30; i += 2)
                        {
                            if (k < chlbPermisosRequeridos.CheckedIndices.Count)
                            {
                                //CÓDIGO PODEROSO
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                    + RiskImages.Images.Keys[chlbPermisosRequeridos.CheckedIndices[k]].ToString(), (float)GetRangeImageRisk(ws2, i).Left + 1,
                                    (float)GetRangeImageRisk(ws2, i).Top + 1, 55, 58);

                                FillCell(ws2, 19, i, chlbPermisosRequeridos.CheckedItems[k].ToString());
                                k++;
                            }
                        }

                        //////////////////////////////////////////////////
                        //**************** EPPS *************************
                        ////////////////////////////////////////////////// 
                        //EPPS
                        //EPPS IMAGENES RANGO
                        int j = 0;

                        for (int i = 6; i <= 70; i += 2)
                        {
                            if (j < dt_epps.Rows.Count)
                            {
                                //CÓDIGO PODEROSO
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                    + dt_epps.Rows[j][5].ToString(), (float)GetRangeImageEpp(ws2, i).Left + 1,
                                    (float)GetRangeImageEpp(ws2, i).Top + 1, 56, 59);

                                FillCell(ws2, 12, i, dt_epps.Rows[j][3].ToString());

                                j++;
                            }
                        }
                        //////////////////////////////////////////////////
                        //**************** HERRAMIENTAS *****************
                        //////////////////////////////////////////////////   
                        int herramientas_cant = dt_herramientas.Rows.Count;
                        int inicio_herr = 22;
                        Range linePpal = (Range)ws2.Rows[inicio_herr - 1];
                        if (herramientas_cant > 0)
                        {
                            linePpal.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < herramientas_cant; i++)
                        {
                            Range line = (Range)ws2.Rows[inicio_herr];
                            linePpal.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_herr, 26], ws2.Cells[inicio_herr, 42]].Merge();
                            //COMBINAR CELDA DE NOMBRE HERRAMIENTA
                            ws2.Range[ws2.Cells[inicio_herr, 13], ws2.Cells[inicio_herr, 25]].Merge();
                            //COMBINAR CELDA DE NOMBRE CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_herr, 11], ws2.Cells[inicio_herr, 12]].Merge();
                        }
                        //SI HAY MAS DE 1 ELEMENTO, SE COMBINAN LAS COLUMNAS
                        if (herramientas_cant > 1)
                        {
                            ws2.Range[ws2.Cells[inicio_herr - 1, 3], ws2.Cells[inicio_herr + herramientas_cant - 2, 9]].Merge();
                        }

                        //AÑADIR ELEMENTOS A CELDAS
                        int l = inicio_herr - 1;

                        for (int i = 0; i < herramientas_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, l, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(list[i].imagen_name);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS
                            SomeHelpers.AddImageExcel(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137);
                            //NOMBRE DE LA HERRAMIENTA
                            FillCell(ws2, l, 13, dt_herramientas.Rows[i][2].ToString());
                            l++;
                        }


                        System.Windows.Forms.Application.DoEvents();

                        //////////////////////////////////////////////////
                        //**************** REPUESTOS *****************
                        ////////////////////////////////////////////////// 
                        if (herramientas_cant == 0)
                        {
                            herramientas_cant++;
                        }

                        int repuestos_cant = dt_repuestos.Rows.Count;
                        int inicio_rep = inicio_herr + herramientas_cant; //+ 1; //23;
                        Range linePpalRep = (Range)ws2.Rows[inicio_rep - 1];
                        if (repuestos_cant > 0)
                        {
                            linePpalRep.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < repuestos_cant; i++)
                        {
                            Range line = (Range)ws2.Rows[inicio_rep];
                            linePpalRep.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_rep, 26], ws2.Cells[inicio_rep, 42]].Merge();
                            //COMBINAR CELDA DE NOMBRE HERRAMIENTA
                            ws2.Range[ws2.Cells[inicio_rep, 13], ws2.Cells[inicio_rep, 25]].Merge();
                            //COMBINAR CELDA DE NOMBRE CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_rep, 11], ws2.Cells[inicio_rep, 12]].Merge();
                        }
                        //SI HAY MAS DE 1 ELEMENTO, SE COMBINAN LAS COLUMNAS
                        if (repuestos_cant > 1)
                        {
                            ws2.Range[ws2.Cells[inicio_rep - 1, 3], ws2.Cells[inicio_rep + repuestos_cant - 2, 9]].Merge();
                        }

                        //AÑADIR ELEMENTOS A CELDAS
                        int b = inicio_rep - 1;

                        for (int i = 0; i < repuestos_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, b, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(listR[i].imagen_name);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcel(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137);
                            //NOMBRE DE LA HERRAMIENTA
                            FillCell(ws2, b, 13, "(" + dt_repuestos.Rows[i][2].ToString() + ") " + dt_repuestos.Rows[i][1].ToString());
                            b++;
                        }

                        //////////////////////////////////////////////////
                        //**************** PASO A PASO *****************
                        //////////////////////////////////////////////////                  
                        if (repuestos_cant == 0)
                        {
                            repuestos_cant += 1;
                        }

                        int paso_cant = dt_pasos.Rows.Count;
                        int inicio_paso = inicio_rep + repuestos_cant + 1; //23;
                        Range linePpalPas = (Range)ws2.Rows[inicio_paso - 1];
                        if (paso_cant > 0)
                        {
                            linePpalPas.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < paso_cant; i++)
                        {
                            Range line = (Range)ws2.Rows[inicio_paso];
                            linePpalPas.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_paso, 26], ws2.Cells[inicio_paso, 42]].Merge();
                            //COMBINAR CELDA DESCRIPCIÓN DEL PASO
                            ws2.Range[ws2.Cells[inicio_paso, 13], ws2.Cells[inicio_paso, 25]].Merge();
                            //COMBINAR CELDA DE FOTO CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_paso, 11], ws2.Cells[inicio_paso, 12]].Merge();
                            //COMBINAR CELDA DE DURACIÓN
                            ws2.Range[ws2.Cells[inicio_paso, 10], ws2.Cells[inicio_paso, 10]].Merge();
                            //COMBINAR CELDA DE NOMBRE
                            ws2.Range[ws2.Cells[inicio_paso, 3], ws2.Cells[inicio_paso, 9]].Merge();
                        }
                        
                        System.Windows.Forms.Application.DoEvents();
                        
                        //AÑADIR ELEMENTOS A CELDAS
                        int p = inicio_paso - 1;

                        for (int i = 0; i < paso_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, p, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(listPasos[i].imagen_paso_path);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcel(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137);

                            //DESCRIPCIÓN
                            FillCell(ws2, p, 13, dt_pasos.Rows[i][1].ToString());
                            //NOMBRE
                            FillCell(ws2, p, 3, dt_pasos.Rows[i][0].ToString());
                            //DURACIÓN
                            FillCell(ws2, p, 10, dt_pasos.Rows[i][2].ToString() + "");
                            //NUMERO PASO
                            int num_pas = i + 1;
                            FillCell(ws2, p, 2, num_pas.ToString() + "");

                            //IMAGEN CATEGORIA
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPositionCat = GetRangeHerramienta(ws2, p, 11);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_pCat = Util.Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(listPasos[i].categoria + ".PNG");
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcel(ws2, image_pCat, (float)picPositionCat.Left + 15, (float)picPositionCat.Top + 57, 20, 20);

                            p++;
                        }

                        int limit = inicio_paso + paso_cant;
                        //CONFIGURANDO AREA DE IMPRESIÓN
                        ws2.PageSetup.PrintArea = "$A$1:$AP$" + limit;

                        //GUARDAR FORMATO PDF
                        if (chkPDF.Checked)
                        {
                            wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,
                                Util.Global.DIRECTORIO_FORMATOS + "\\SMP.pdf");
                        }

                        wb.Save();
                        wb.Close();
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    splash.Hide();
                }
            });
        }

        private void bgSaveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show
                    ("El archivo se ha generado correctamente, se encuentra en "
                        + path + " Desea guardarlo en otra ubicación?", "Proceso finalizado!"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            myStream.Close();
                            File.Copy(path, saveFileDialog1.FileName, true);
                            File.Copy(Util.Global.DIRECTORIO_FORMATOS + "\\SMP.pdf", saveFileDialog1.FileName.Replace("xlsx", "pdf"));

                            MessageBox.Show("Archivo guardado!");

                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }
                
                lblGenerando.Visible = false;
                splash.Hide();

                DialogResult dr2 = MessageBox.Show
                    ("Desea diligenciar un nuevo formato?", "Formato SMP"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr2 == System.Windows.Forms.DialogResult.Yes)
                {
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }

        private void LimpiarCampos()
        {
            txtConsecutivo.Text = daoSmp.GetLastConsecutive().ToString();
            dtpFecha.Value = DateTime.Now;
            cboAreaLinea.SelectedIndex = 0;
            cboClasificación.SelectedIndex = 0;
            txtTecnicosRequeridos.Text = "0";
            txtDuracionActividad.Text = "0";
            txtTiempoEquipoParado.Text = "0";
            txtFrecuencia.Text = "0";
            cboFrecuencia.SelectedIndex = 0;
            cboElaborador.SelectedIndex = 0;
            cboAprobador.SelectedIndex = 0;

            dtgPasoAPaso.DataSource = null;
            dtgPasoAPaso.Visible = false;
            bs.DataSource = null;

            pbImg1.Image = Properties.Resources.placeholder;
            pbImg2.Image = Properties.Resources.placeholder;
            imagen1 = "";
            imagen2 = "";

            txtNombreSMP.Text = "";
            cboEquipo.SelectedIndex = 0;
            txtSMP.Text = "";
            cboTipoMtto.SelectedIndex = 0;
                        
            foreach (int i in chlbPermisosRequeridos.CheckedIndices)
            {
                chlbPermisosRequeridos.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (DataGridViewRow row in dtgEpps.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];                
                chk.Value = chk.FalseValue;                
            }

            lblSeleccionados.Text = "0";
            lblDisponibles.Text = "0";
            txtBuscar.Text = "";

            dtgHerr.Visible = false;
            dtgHerr.DataSource = null;
            lblCargadas.Text = "0";

            dtgRep.Visible = false;
            dtgRep.DataSource = null;
            lblCargados.Text = "0";

            
            
            lblPaPCargados.Text = "0";
            btnEditar.Visible = false;

            foreach (TabPage tp in tabcontrol.TabPages)
            {
                EnableTab(tp, true);
            }

            pbLoad.Value = 0;
            btnExportar.Visible = false;
            chkPDF.Visible = false;
            chkPDF.Checked = false;
            lblPorcentaje.Text = "0%";
        }
    }
}
