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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class FormSop : MetroForm
    {
        DaoTipos daoTip = new DaoTipos();
        DaoML daoMl = new DaoML();
        DaoSOP daoSop = new DaoSOP();
        DaoEpps daoEpp = new DaoEpps();
        DaoPersonal daoPer = new DaoPersonal();
        DaoPasoPaso daoPP = new DaoPasoPaso();

        List<Validacionescs> listVal = new List<Validacionescs>();
        List<PasoaPaso> listPasos = new List<PasoaPaso>();
        List<Objetos.Herramientas> list = new List<Objetos.Herramientas>();
        List<tipos_data> listTipo = new List<tipos_data>();
        List<tecnicos> listTec = new List<tecnicos>();
        List<Machines> listMaq = new List<Machines>();
        List<Epps> listEpps = new List<Epps>();
        Splash splash = new Splash();
        BindingSource bs = new BindingSource();
        private string path;
        System.Data.DataTable dt_epps = new System.Data.DataTable();
        System.Data.DataTable dt_herramientas = new System.Data.DataTable();
        System.Data.DataTable dt_repuestos = new System.Data.DataTable();
        System.Data.DataTable dt_pasos = new System.Data.DataTable();

        public FormSop()
        {
            InitializeComponent();

            dtgEpps.CellValueChanged += new DataGridViewCellEventHandler(dtgEpps_CellValueChanged);
        }

        private void FormSop_Load(object sender, EventArgs e)
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

            listTipo = daoTip.ConsultarTipoComboBox(true).OrderBy(x => x.descripcion).ToList();
            listMaq = daoMl.GetMachines().OrderBy(x => x.nombre).ToList();
            listTec = daoPer.ConsultarTecnicosComboBox();

            e.Result = daoSop.GetLastConsecutive().ToString();



            //LABORATORIO PARA PASOS DINÁMICOS EN SOP EXCEL
            CalculteRowsStepsExcel(7);
        }

        public decimal CalculteRowsStepsExcel(int pasos)
        {
            decimal tempRows = pasos / 3;
            decimal res = Math.Floor(tempRows);

            return res;
        }

        private void bgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "@" + DateTime.Now.Year + " SOP (Procedimiento Estandar de Operación)";
            cboCategoria.DataSource = listTipo.Where(x => x.id_tipo == 16).ToList();
            cboTipoSop.DataSource = listTipo.Where(x => x.id_tipo == 17).ToList();
            cboFrecuencia.DataSource = listTipo.Where(x => x.id_tipo == 18).ToList();
            cboAreaAprobadora.DataSource = listTipo.Where(x => x.id_tipo == 14).ToList();
            cboElaborador.DataSource = listTec.Where(x => x.tipo_usuario == 102 && x.id_rol == 1).ToList();
            cboAprobador.DataSource = listTec.Where(x => x.tipo_usuario == 102 && x.id_rol == 2).ToList();

            cboMaquina.DataSource = listMaq;
            dtgEpps.DataSource = listEpps;

            txtConsecutivo.Text = e.Result.ToString();
            dtgPasoAPaso.AutoGenerateColumns = false;
            //dtgHerr.AutoGenerateColumns = false;
            
            splash.Hide();            
        }

        private void txtNumPersonas_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void dtgEpps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgEpps.IsCurrentCellDirty)
            {
                dtgEpps.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
            NuevoPasoSop np = new NuevoPasoSop(null,listPasos.Count,list);

            if (np.ShowDialog() == DialogResult.OK)
            {
                listPasos.Add(np.pp);
                bs.DataSource = listPasos;
                dtgPasoAPaso.DataSource = bs;
                bs.ResetBindings(true);
                dtgPasoAPaso.Visible = true;
                lblPaPCargados.Text = listPasos.Count.ToString();                
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
                default:
                    break;
            }

            switch (listVal.Count)
            {
                case 1:
                    pbLoad.Value = 25;
                    lblPorcentaje.Text = "25%";
                    break;

                case 2:
                    pbLoad.Value = 50;
                    lblPorcentaje.Text = "50%";
                    break;

                case 3:
                    pbLoad.Value = 75;
                    lblPorcentaje.Text = "75%";
                    break;

                case 4:
                    pbLoad.Value = 100;
                    lblPorcentaje.Text = "100%";
                    btnExportar.Visible = true;
                    chkPDF.Visible = true;
                    break;
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

        private void ValidaciónPag4()
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
            if (txtNombreSOP.Text.Trim().Length > 0)
            {
                if (cboCategoria.Text.Trim().Length > 0)
                {
                    if (cboTipoSop.Text.Trim().Length > 0)
                    {
                        if (txtSOP.Text.Trim().Length > 0)
                        {
                            if (txtNumPersonas.Text.Trim().Length > 0)
                            {
                                if (dtpTiempoPersona.Text.Trim().Length > 0)
                                {
                                    if (dtpDuracionTarea.Text.Trim().Length > 0)
                                    {
                                        if (dtpMaquinaParada.Text.Trim().Length > 0)
                                        {
                                            if (cboElaborador.Text.Trim().Length > 0)
                                            {
                                                if (cboAprobador.Text.Trim().Length > 0)
                                                {                                                    
                                                    ValidarPestañaGen(tabInformacionBasica);                                                   
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
                                            MessageBox.Show("Se debe escribir tiempo máquina parada!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Se debe escribir el tiempo de duración de la tarea!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Se debe escribir tiempo por persona!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se debe escribir # peronas requeridas!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se debe escribir SOP #!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay tipo SOP seleccionado!");
                    }
                }
                else
                {
                    MessageBox.Show("No hay una categoria seleccionada!");
                }
            }
            else
            {
                MessageBox.Show("Se debe escribir nombre de SOP!");
            }
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

        public static System.Data.DataTable FillPasoPaso(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                //Console.WriteLine( col.HeaderText);
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

        private void FillCell(Worksheet w, int row, int column, string value)
        {
            w.Cells[row, column] = (string)(w.Cells[row, column]
                as Microsoft.Office.Interop.Excel.Range).Value + " " + value;
        }

        private Microsoft.Office.Interop.Excel.Range GetRangeImageEpp(Worksheet w,int row, int index)
        {
            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)w.Cells[row, index];
            return rIm;
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

                            if (File.Exists(Util.Global.DIRECTORIO_FORMATOS + "\\SOP.pdf"))
                            {
                                File.Copy(Util.Global.DIRECTORIO_FORMATOS + "\\SOP.pdf", 
                                    saveFileDialog1.FileName.Replace("xlsx", "pdf"));
                            }
                            
                            MessageBox.Show("Archivo guardado!");

                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }

                lblGenerando.Visible = false;
                splash.Hide();

                DialogResult dr2 = MessageBox.Show
                    ("Desea diligenciar un nuevo formato?", "Formato SOP"
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

        private void bgSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    //LLENAR RESPECTIVOS DATATABLES PARA VALIDAR INFORMACIÓN A GUARDAR
                    dt_epps = FillEpps(dtgEpps);                    
                    dt_pasos = FillPasoPaso(dtgPasoAPaso);

                    System.Windows.Forms.Application.DoEvents();

                    //GUARDAR EN BASE DE DATOS
                    sop sop = new sop();

                    sop.consecutivo = int.Parse(txtConsecutivo.Text);
                    sop.titulo = txtNombreSOP.Text.Trim();
                    sop.numero_sop = int.Parse(txtSOP.Text);
                    sop.codigo_categoria = int.Parse(cboCategoria.SelectedValue.ToString());
                    sop.codigo_tipo = int.Parse(cboTipoSop.SelectedValue.ToString());
                    sop.fecha = dtpFecha.Value;
                    sop.codigo_maquina = int.Parse(cboMaquina.SelectedValue.ToString());
                    sop.codigo_frecuencia = int.Parse(cboFrecuencia.SelectedValue.ToString());
                    sop.personas_requeridas = int.Parse(txtNumPersonas.Text);
                    sop.tiempo_persona = dtpTiempoPersona.Text;
                    sop.duracion_tarea = dtpDuracionTarea.Text;
                    sop.maquina_parada = dtpMaquinaParada.Text;                    
                    sop.codigo_area_aprobadora = int.Parse(cboAreaAprobadora.SelectedValue.ToString());
                    sop.codigo_usuario_preparador = int.Parse(cboElaborador.SelectedValue.ToString());
                    sop.codigo_lider_area = int.Parse(cboAprobador.SelectedValue.ToString());
                    sop.numero_revision = int.Parse(txtNumRevision.Text);
                    sop.codigo_formato = txtCodFormato.Text.Trim();
                    sop.user_id = Util.Global.UserLoged.Id;

                    //GUARDAR OBJETO EN BASE DE DATOS
                    int id_sop = daoSop.AddSop(sop);

                    System.Windows.Forms.Application.DoEvents();

                    //PENDIENTE GUARDAR EPPS, HERRAMIENTAS, PASOS, REPUESTOS
                    //E INDEPENDIZAR PERMISOS DE RIESGOS
                    if (id_sop > 0)
                    {
                        //AGREGAR EPPS
                        for (int i = 0; i < listEpps.Count; i++)
                        {
                            if (listEpps[i].sel)
                            {
                                daoSop.AddSopUtil(new sop_utils()
                                {
                                    id_sop = id_sop,
                                    id_tipo = 9,
                                    id_util = listEpps[i].id
                                });
                            }
                        }

                        foreach (Objetos.Herramientas item in list)
                        {
                            if (item.sel)
                            {
                                daoSop.AddSopUtil(new sop_utils()
                                {
                                    id_sop = id_sop,
                                    id_tipo = 10,
                                    id_util = item.Id
                                });
                            }
                        }

                        foreach (PasoaPaso item in listPasos)
                        {
                            daoPP.AddPasoSop(new sop_pasos()
                            {                                
                                descripcion = item.desc,
                                duracion = item.duracion,
                                id_smp = id_sop,
                                num_paso = item.numPaso,
                                codigo_herramienta = item.codigo_herramienta,
                                image_path = item.imagen_paso_path
                            });                                                        
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
                    path = @"" + sru + "\\SOP.xlsx";

                    //COPIAR EL ARCHIVO DE LOS RECURSOS DE LA APLICACIÓN
                    // A LA RUTA ESTABLECIDA
                    File.WriteAllBytes(path, Properties.Resources.SOP_BLANCO);

                    //VERIFICAR SI EL ARCHIVO ESTÁ BLOQUEADO O ESTA SIENDO UTILIZADO POR OTRO PROCESO
                    if (IsFileLocked(new FileInfo(path)))
                    {
                        MessageBox.Show("El archivo se está ejecutando, debe cerrarlo para continuar",
                                "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //CATEGORIA
                        FillCell(ws2, 3, 10, cboCategoria.Text.ToString());
                        //FORMATO
                        FillCell(ws2, 6, 1, txtCodFormato.Text.ToString());
                        //MAQUINA
                        FillCell(ws2, 6, 4, cboMaquina.Text.ToString());
                        //TITULO
                        FillCell(ws2, 2, 5, txtNombreSOP.Text.ToString());
                        //NÚMERO 
                        FillCell(ws2, 2, 14, txtSOP.Text.ToString());
                        //NÚMERO REVISION
                        FillCell(ws2, 4, 14, txtNumRevision.Text.ToString());
                        //TIPO
                        FillCell(ws2, 6, 7, cboTipoSop.Text.ToString());
                        //ELABORADO POR
                        FillCell(ws2, 6, 9, cboElaborador.Text.ToString());
                        //AREA APROBADORA
                        FillCell(ws2, 6, 11, cboAreaAprobadora.Text.ToString());
                        //LIDER AREA
                        FillCell(ws2, 6, 13, cboAprobador.Text.ToString());
                        //FECHA
                        FillCell(ws2, 3, 13, dtpFecha.Value.ToShortDateString());
                        //NÚMERO DE PERSONAS REQUERIDAS
                        FillCell(ws2, 8, 9, txtNumPersonas.Text.ToString());
                        //TIEMPO POR PERSONA
                        FillCell(ws2, 8, 10, dtpTiempoPersona.Text.ToString());
                        //DURACIÓN DE LA ACTIVIDAD
                        FillCell(ws2, 8, 11, dtpDuracionTarea.Text.ToString());
                        //TIEMPO EQUIPO PARADO
                        FillCell(ws2, 8, 12, dtpMaquinaParada.Text.ToString());
                        //FREUENCIA
                        string name_opt = "";
                        switch (cboFrecuencia.SelectedValue.ToString())
                        {
                            case "91":
                                name_opt = "turno";
                            break;
                            case "92":
                                name_opt = "diario";
                                break;
                            case "96":
                                name_opt = "cada_cambio";
                                break;
                            case "97":
                                name_opt = "semanal";
                                break;
                            case "99":
                                name_opt = "quincenal";
                                break;
                            case "100":
                                name_opt = "mensual";
                                break;
                            default:
                                break;
                        }
                        Microsoft.Office.Interop.Excel.OptionButton opt =
                            (Microsoft.Office.Interop.Excel.OptionButton)ws2.OptionButtons(name_opt);
                        opt.Value = true;
                       
                        //////////////////////////////////////////////////
                        //**************** EPPS *************************
                        ////////////////////////////////////////////////// 
                        //EPPS
                        //EPPS IMAGENES RANGO
                        int j = 0;

                        for (int i = 1; i <= 70; i ++)
                        {
                            if (j < dt_epps.Rows.Count)
                            {
                                if (j >= 4 && j <= 8)
                                {
                                    //CÓDIGO PODEROSO
                                    SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_epps.Rows[j][5].ToString(), (float)GetRangeImageEpp(ws2, 10, i-4).Left + 1,
                                        (float)GetRangeImageEpp(ws2, 10, i-4).Top + 1, 62, 48);

                                    FillCell(ws2, 11, i-4, dt_epps.Rows[j][3].ToString());
                                }
                                else
                                {
                                    //CÓDIGO PODEROSO
                                    SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_epps.Rows[j][5].ToString(), (float)GetRangeImageEpp(ws2,8, i).Left + 1,
                                        (float)GetRangeImageEpp(ws2,8, i).Top + 1, 62, 48);

                                    FillCell(ws2, 9, i, dt_epps.Rows[j][3].ToString());
                                }                                

                                j++;
                            }
                        }
                        //////////////////////////////////////////////////
                        //**************** HERRAMIENTAS *****************
                        //////////////////////////////////////////////////   
                        int h = 0;

                        for (int i = 5; i <= 70; i++)
                        {
                            if (h < dt_herramientas.Rows.Count)
                            {
                                if (h >= 4 && h <= 8)
                                {
                                    //CÓDIGO PODEROSO
                                    SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        +Path.GetFileName(list[h].imagen_name), (float)GetRangeImageEpp(ws2, 10, i-4).Left + 1,
                                        (float)GetRangeImageEpp(ws2, 10, i-4).Top + 1, 62, 48);

                                    FillCell(ws2, 11, i-4, list[h].herramienta.ToString());
                                }
                                else
                                {
                                    //CÓDIGO PODEROSO
                                    SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + Path.GetFileName(list[h].imagen_name), (float)GetRangeImageEpp(ws2, 8, i).Left + 1,
                                        (float)GetRangeImageEpp(ws2, 8, i).Top + 1, 62, 48);

                                    FillCell(ws2, 9, i, list[h].herramienta.ToString());
                                }

                                h++;
                            }
                        }
                        
                        System.Windows.Forms.Application.DoEvents();

                        for (int i = 0; i < listPasos.Count; i++)
                        {
                            if (i == 0)
                            {
                                //PASO A PASO
                                FillCell(ws2, 12, 1, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 13, 1).Left + 1, (float)GetRangeImageEpp(ws2, 13, 1).Top + 1, 380,228);
                                //HERRAMIENTA
                                FillCell(ws2, 14, 1, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 14, 4, listPasos[i].duracion);
                            }

                            if (i == 1)
                            {
                                //PASO A PASO
                                FillCell(ws2, 12, 7, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 13, 7).Left + 1, (float)GetRangeImageEpp(ws2, 13, 7).Top + 1, 330, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 14, 7, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 14, 9, listPasos[i].duracion);
                            }

                            if (i == 2)
                            {
                                //PASO A PASO
                                FillCell(ws2, 12,11, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 13, 11).Left + 1, (float)GetRangeImageEpp(ws2, 13, 11).Top + 1, 403, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 14, 11, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 14, 13, listPasos[i].duracion);
                            }


                            if (i == 3)
                            {
                                //PASO A PASO
                                FillCell(ws2, 15, 1, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 16, 1).Left + 1, (float)GetRangeImageEpp(ws2, 16, 1).Top + 1, 380, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 17, 1, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 17, 4, listPasos[i].duracion);
                            }

                            if (i == 4)
                            {
                                //PASO A PASO
                                FillCell(ws2, 15, 7, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 16, 7).Left + 1, (float)GetRangeImageEpp(ws2, 16, 7).Top + 1, 330, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 17, 7, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 17, 9, listPasos[i].duracion);
                            }

                            if (i == 5)
                            {
                                //PASO A PASO
                                FillCell(ws2, 15, 11, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 16, 11).Left + 1, (float)GetRangeImageEpp(ws2, 16, 11).Top + 1, 403, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 17, 11, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 17, 13, listPasos[i].duracion);
                            }

                            if (i == 6)
                            {
                                //PASO A PASO
                                FillCell(ws2, 18, 1, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 19, 1).Left + 1, (float)GetRangeImageEpp(ws2, 19, 1).Top + 1, 380, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 20, 1, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 20, 4, listPasos[i].duracion);
                            }

                            if (i == 7)
                            {
                                //PASO A PASO
                                FillCell(ws2, 18, 7, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 19, 7).Left + 1, (float)GetRangeImageEpp(ws2, 19, 7).Top + 1, 330, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 20, 7, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 20, 9, listPasos[i].duracion);
                            }

                            if (i == 8)
                            {
                                //PASO A PASO
                                FillCell(ws2, 18, 11, ": " + listPasos[i].desc);
                                //IMAGEN
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                        + dt_pasos.Rows[i][5].ToString(), (float)GetRangeImageEpp(ws2, 19, 11).Left + 1, (float)GetRangeImageEpp(ws2, 19, 11).Top + 1, 403, 228);
                                //HERRAMIENTA
                                FillCell(ws2, 20, 11, listPasos[i].herramienta);
                                //DURACION
                                FillCell(ws2, 20, 13, listPasos[i].duracion);
                            }

                        }                        

                        //int limit = inicio_paso + paso_cant;
                        ////CONFIGURANDO AREA DE IMPRESIÓN
                        //ws2.PageSetup.PrintArea = "$A$1:$AP$" + limit;

                        //GUARDAR FORMATO PDF
                        if (chkPDF.Checked)
                        {
                            wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,
                                Util.Global.DIRECTORIO_FORMATOS + "\\SOP.pdf");
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

        private void LimpiarCampos()
        {
            txtConsecutivo.Text = daoSop.GetLastConsecutive().ToString();
            dtpFecha.Value = DateTime.Now;
            cboCategoria.SelectedIndex = 0;
            cboTipoSop.SelectedIndex = 0;
            txtNumPersonas.Text = "0";
            dtpTiempoPersona.Value = new DateTime(2018,1,1,0,0,0);
            dtpDuracionTarea.Value = new DateTime(2018, 1, 1, 0, 0, 0);
            dtpMaquinaParada.Value = new DateTime(2018, 1, 1, 0, 0, 0);
            txtNombreSOP.Text = "";
            txtSOP.Text = "0";
            txtNumRevision.Text = "0";
            txtCodFormato.Text = "0";
            cboFrecuencia.SelectedIndex = 0;
            cboMaquina.SelectedIndex = 0;
            cboElaborador.SelectedIndex = 0;
            cboAprobador.SelectedIndex = 0;
            cboAreaAprobadora.SelectedIndex = 0;

            dtgPasoAPaso.DataSource = null;
            dtgPasoAPaso.Visible = false;
            bs.DataSource = null;


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



            lblPaPCargados.Text = "0";
            btnEditar.Visible = false;

            //foreach (TabPage tp in tabcontrol.TabPages)
            //{
            //    EnableTab(tp, true);
            //}

            pbLoad.Value = 0;
            btnExportar.Visible = false;
            chkPDF.Visible = false;
            chkPDF.Checked = false;
            lblPorcentaje.Text = "0%";
        }
    }
}
