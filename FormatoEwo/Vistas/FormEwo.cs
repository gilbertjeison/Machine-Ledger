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
    public partial class FormEwo : MetroForm
    {
        string path;
        string imagen1 = "";
        string imagen2 = "";
        string imagenPorque1 = "";
        string imagenPorque2 = "";
        System.Data.DataTable dt_repuestos = new System.Data.DataTable();
        System.Data.DataTable dt_porque = new System.Data.DataTable();
        System.Data.DataTable dt_lista_acciones = new System.Data.DataTable();
        List<tipos_data> listTipo = new List<tipos_data>();
        List<tecnicos> listTec = new List<tecnicos>();
        List<equipos> listEq = new List<equipos>();
        List<Validacionescs> listVal = new List<Validacionescs>();
        DaoTipos daoTip = new DaoTipos();
        DaoPersonal daoPer = new DaoPersonal();
        DaoEquipos daoEq = new DaoEquipos();
        DaoEwo daoEwo = new DaoEwo();
        DaoPorque daoPor = new DaoPorque();
        DaoListaAcciones daoLAcc = new DaoListaAcciones();
        DaoRepuestosUtilizados daoRU = new DaoRepuestosUtilizados();
        DateTimePicker dtp;
        Splash splash = new Splash();

        public FormEwo()
        {
            InitializeComponent();
        }

        private void FormEwo_Load(object sender, EventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
        }

        private void bgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillMCombos();

            cboAreaLinea.DataSource = listTipo.Where(x => x.id_tipo == 14).ToList();
            cboTipoAveria.DataSource = listTipo.Where(x => x.id_tipo == 13).ToList();
            cboTecnico.DataSource = listTec;
            cboEquipo.DataSource = listEq;

            txtConsecutivo.Text = daoEwo.GetLastConsecutive().ToString();

            cboTurno.SelectedIndex = 0;
            splash.Close();
        }

        private void bgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            listTipo = daoTip.ConsultarTipoComboBox(true);
            listTec = daoPer.ConsultarTecnicosComboBox();
            listEq = daoEq.ConsultarEquiposComboBox();
        }
        
        private void txtConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void txtDiagnostico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void rbAjuste_CheckedChanged(object sender, EventArgs e)
        {
            gbRepuestos.Visible = false;            
        }

        private void rbCambioComponente_CheckedChanged(object sender, EventArgs e)
        {
            gbRepuestos.Visible = true;
        }

        private void img1_Click(object sender, EventArgs e)
        {
            imagen1 = SomeHelpers.CargarImagenPictureBox(img1);
        }

        private void img2_Click(object sender, EventArgs e)
        {
            imagen2 = SomeHelpers.CargarImagenPictureBox(img2);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagen1, e, new List<ToolStripMenuItem>() { itemVerImagen, itemQuitarImagen }, true, img1);

            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen)
            {
                imagen1 = "";
            }
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagen2, e, new List<ToolStripMenuItem>() { itemVerImagen2, itemQuitarImagen2 }, true, img2);

            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen2)
            {
                imagen2 = "";
            }
        }

        private void CalcularTiempoEsperaTec()
        {
            TimeSpan span = dtpIniReparacion.Value - dtpNotAveria.Value;
            double totalMinutes = span.TotalMinutes;

            txtEsperaTecnico.Text = Math.Round(totalMinutes).ToString();
        }

        private void dtpNotAveria_ValueChanged(object sender, EventArgs e)
        {
            CalcularTiempoEsperaTec();
        }

        private void dtpIniReparacion_ValueChanged(object sender, EventArgs e)
        {
            CalcularTiempoEsperaTec();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDiagnostico.Text.Trim().Length > 0 && txtEsperaRepuestos.Text.Trim().Length > 0
                    && txtEsperaTecnico.Text.Trim().Length > 0 && txtPruebasArranque.Text.Trim().Length > 0
                        && txtReparacionPiezas.Text.Trim().Length > 0)
            {

                double res = int.Parse(txtDiagnostico.Text) +
                             int.Parse(txtEsperaRepuestos.Text) +
                             int.Parse(txtEsperaTecnico.Text) +
                             int.Parse(txtPruebasArranque.Text) +
                             int.Parse(txtReparacionPiezas.Text);

                double min_ini_fin = Math.Round(dtpFinReparacion.Value.Subtract
                    (dtpNotAveria.Value).TotalMinutes);

                Console.WriteLine(res.ToString());
                Console.WriteLine(min_ini_fin.ToString());

                if (min_ini_fin == res)
                {
                    txtTiempoFinal.Text = res.ToString();
                }
                else
                {
                    MessageBox.Show("La diferencia de hora de inicio y fin de reparación no coincide con la suma de los minútos de estratificación, por favor revisar tiempos !", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Los campos de minutos de estratificación no deben estar en blanco !", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillMCombos()
        {
            listTec = daoPer.ConsultarTecnicosComboBox();

            SomeHelpers.FillMultiCombo(cboChkTecInvolucrados, listTec);
            SomeHelpers.FillMultiCombo(cboChkContraInvolucrados, listTec);
            SomeHelpers.FillMultiCombo(cboChkElaborado, listTec);
            SomeHelpers.FillMultiCombo(cboChkOpeInvolucrados, listTec);
            SomeHelpers.FillMultiCombo(cboChkValidInvolucrados, listTec);
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }

        private void ValidaciónPag1()
        {
            if (cboAreaLinea.Text.Length > 0)
            {
                if (cboEquipo.Text.Length > 0)
                {
                    if (dtpFecha.Text.Length > 0)
                    {
                        if (cboTurno.Text != null)
                        {
                            if (txtAviso.Text.Trim().Length > 0)
                            {
                                if (cboTecnico.Text.Trim().Length > 0)
                                {
                                    if (cboTipoAveria.SelectedValue != null)
                                    {
                                        if (txtTiempoFinal.Text.Trim().Length > 0)
                                        {
                                            if (txtDescripcion.Text.Trim().Length > 0)
                                            {
                                                if (!imagen1.Equals("") || !imagen2.Equals(""))
                                                {
                                                    if (!txtDescImagen1.Text.Equals("") || !txtDescImagen2.Text.Equals(""))
                                                    {
                                                        if (rbCambioComponente.Checked)
                                                        {
                                                            dt_repuestos = SomeHelpers.FillDataGridOnDataTable(dtgRepuestos);

                                                            if (dt_repuestos.Rows.Count > 1)
                                                            {
                                                                ValidarPestañaGen(tabPrincipal);
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Se ha indicado un cambio de componente pero no se ha ingresado ningún repuesto!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ValidarPestañaGen(tabPrincipal);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Se debe describir imágen!");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Se debe agregar al menos una imágen!");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Se debe ingresar una descripción de la avería!");

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Verificar el tiempo total de reparación!");

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No hay un Tipo de Avería Seleccionado!");

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No hay un Técnico Seleccionado!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un numero de aviso!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay un Turno Seleccionado!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay una Fecha Seleccionada!");
                    }
                }
                else
                {
                    MessageBox.Show("No hay un Equipo Seleccionado!");
                }
            }
            else
            {
                MessageBox.Show("No hay una Área/Linea Seleccionada!");
            }
        }

        private void ValidaciónPag3()
        {
            if (!txtWhat.Text.Trim().Equals(""))
            {
                if (!txtWhere.Text.Trim().Equals(""))
                {
                    if (!txtWhen.Text.Trim().Equals(""))
                    {
                        if (!txtWho.Text.Trim().Equals(""))
                        {
                            if (!txtWich.Text.Trim().Equals(""))
                            {
                                if (!txtHow.Text.Trim().Equals(""))
                                {
                                    dt_porque = SomeHelpers.FillDataGridOnDataTable(dtgPorque);
                                    //if (dt_porque.Rows.Count > 1)
                                    //{

                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show("Es necesario que haya un registro en el análisis del [POR QUÉ POR QUÉ]");
                                    //}
                                    ValidarPestañaGen(tab5g5w);
                                }
                                else
                                {
                                    MessageBox.Show("Se requiere el campo [COMO (HOW)?]");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se requiere el campo [CUAL (WICH)?]");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se requiere el campo [QUIEN (WHO)?]");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se requiere el campo [CUANDO (WHEN)?]");
                    }
                }
                else
                {
                    MessageBox.Show("Se requiere el campo [DONDE (WHERE)?]");
                }
            }
            else
            {
                MessageBox.Show("Se requiere el campo [QUE (WHAT)?]");
            }
        }

        private void ValidaciónPag2()
        {
            if (rbOkGemba.Checked && rbOkGembutsu.Checked &&
                    rbOkGenjitsu.Checked && rbOkGenri.Checked && rbOkGensoku.Checked)
            {
                ValidarPestañaGen(tabCasusasRaices);
            }
            else if (rbNokGemba.Checked || rbNokGembutsu.Checked ||
                    rbNokGenjitsu.Checked || rbNokGenri.Checked || rbNokGensoku.Checked)
            {
                ValidarPestañaGen(tabCasusasRaices);
            }
            else
            {
                MessageBox.Show("Los campos requieren información!");
            }
        }

        private void ValidaciónPag4()
        {
            var checkedRadio = new[] { gbTipoFalla }
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));

            if (checkedRadio.ToList().Count > 0)
            {
                if (!imagenPorque1.Equals("") || !imagenPorque2.Equals(""))
                {
                    if (!txtDescImgPorque1.Text.Equals("") || !txtDescImgPorque2.Text.Equals(""))
                    {
                        ValidarPestañaGen(tabJustificacion);
                    }
                    else
                    {
                        MessageBox.Show("Se debe describir imágen!");
                    }
                }
                else
                {
                    MessageBox.Show("Se debe agregar al menos una imágen!");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una opción del gráfico de la bañera!");
            }
        }

        private void ValidaciónPag5()
        {
            var checkedRadio = new[] { gbCausaRaiz }
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));

            if (checkedRadio.ToList().Count > 0)
            {
                dt_lista_acciones = SomeHelpers.FillDataGridOnDataTable(dtgListaAcciones);
                if (dt_lista_acciones.Rows.Count > 1)
                {
                    if (!cboChkTecInvolucrados.Text.Equals(""))
                    {
                        if (!cboChkOpeInvolucrados.Text.Equals(""))
                        {
                            if (!cboChkElaborado.Text.Equals(""))
                            {
                                if (!cboChkContraInvolucrados.Text.Equals(""))
                                {
                                    if (!cboChkValidInvolucrados.Text.Equals(""))
                                    {
                                        ValidarPestañaGen(tabListAcc);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione los validadores de la ejecución!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione los definidores de la contramedida!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione los analistas involucrados!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione los operarios involucrados!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione los técnicos involucrados!");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario que haya un registro en la lista de acciones!");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una opción de la causa raíz!");
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
                EnableTab(tp, false);
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
                    break;
            }
        }

        private void dtgRepuestos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (!Util.MathHelper.IsNumeric(e.FormattedValue.ToString()) || string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dtgRepuestos.Rows[e.RowIndex].ErrorText =
                        "Valor no permitido para el registro!";
                    e.Cancel = true;
                }
            }
        }

        private void dtgRepuestos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgRepuestos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void txtWhat_TextChanged(object sender, EventArgs e)
        {
            txtFenomeno.Text = txtHow.Text.Trim() + " " + txtWhat.Text.Trim() + " " + txtWhere.Text.Trim() + " " +
                txtWhen.Text.Trim() + " " + txtWich.Text.Trim() + " " + txtWho.Text.Trim();
        }

        private void rbNokGemba_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbNokGemba.Checked || rbNokGembutsu.Checked ||
            //        rbNokGenjitsu.Checked || rbNokGenri.Checked || rbNokGensoku.Checked)
            //{
            //    ValidarPestañaGen(tab5g5w);

            //}
            //if (rbOkGemba.Checked && rbOkGembutsu.Checked &&
            //        rbOkGenjitsu.Checked && rbOkGenri.Checked && rbOkGensoku.Checked)
            //{
            //    ValidarPestañaGen(tab5g5w);
            //}
            if (rbOkGemba.Checked || rbNokGemba.Checked)
            {
                if (txtGemba.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Se debe ingresar primero el [GEMBA]");
                    RadioButton rb = (RadioButton)sender;
                    rb.Checked = false;
                }
            }

            if (rbOkGembutsu.Checked || rbNokGembutsu.Checked)
            {
                if (txtGembutsu.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Se debe ingresar primero el [GEMBUTSU]");
                    RadioButton rb = (RadioButton)sender;
                    rb.Checked = false;
                }
            }

            if (rbOkGenjitsu.Checked || rbNokGenjitsu.Checked)
            {
                if (txtGenjitsu.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Se debe ingresar primero el [GENJITSU]");
                    RadioButton rb = (RadioButton)sender;
                    rb.Checked = false;
                }
            }

            if (rbOkGenri.Checked || rbNokGenri.Checked)
            {
                if (txtGenri.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Se debe ingresar primero el [GENRI]");
                    RadioButton rb = (RadioButton)sender;
                    rb.Checked = false;
                }
            }
        }

        private void dtgListaAcciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dtp = new DateTimePicker();
                dtgListaAcciones.Controls.Add(dtp);
                dtp.Format = DateTimePickerFormat.Short;
                System.Drawing.Rectangle Rectangle = dtgListaAcciones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                dtp.Location = new System.Drawing.Point(Rectangle.X, Rectangle.Y);


                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_OnTextChange);


                dtp.Visible = true;
            }
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dtgListaAcciones.CurrentCell.Value = dtp.Text.ToString();
        }

        private void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void pbImagenPorque1_Click(object sender, EventArgs e)
        {
            imagenPorque1 = SomeHelpers.CargarImagenPictureBox(pbImagenPorque1);
        }

        private void pbImagenPorque2_Click(object sender, EventArgs e)
        {
            imagenPorque2 = SomeHelpers.CargarImagenPictureBox(pbImagenPorque2);
        }

        private void item_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagenPorque1, e, new List<ToolStripMenuItem>() { itemVerImagen3, itemQuitarImagen3 }, true, pbImagenPorque1);

            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen3)
            {
                imagenPorque1 = "";
            }
        }

        private void contextMenuStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SomeHelpers.ImageManager(imagenPorque2, e, new List<ToolStripMenuItem>() { itemVerImagen4, itemQuitarImagen4 }, true, pbImagenPorque2);

            ToolStripMenuItem tsmCk = (ToolStripMenuItem)e.ClickedItem;
            if (tsmCk == itemQuitarImagen4)
            {
                imagenPorque2 = "";
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!bgGenerar.IsBusy)
            {
                pbGenerando.Visible = true;
                lblGenerando.Visible = true;
                bgGenerar.RunWorkerAsync();
            }
        }

        private void FillCell(Worksheet w, int row, int column, string value)
        {
            w.Cells[row, column] = (string)(w.Cells[row, column]
                as Microsoft.Office.Interop.Excel.Range).Value + " " + value;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
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

        private void FillGENS(Worksheet ws2)
        {
            if (rbNokGemba.Checked)
            {
                FillCell(ws2, 22, 9, "X");
            }
            if (rbOkGemba.Checked)
            {
                FillCell(ws2, 22, 10, "X");
            }

            if (rbNokGembutsu.Checked)
            {
                FillCell(ws2, 23, 9, "X");
            }
            if (rbOkGembutsu.Checked)
            {
                FillCell(ws2, 23, 10, "X");
            }

            if (rbNokGenjitsu.Checked)
            {
                FillCell(ws2, 24, 9, "X");
            }
            if (rbOkGenjitsu.Checked)
            {
                FillCell(ws2, 24, 10, "X");
            }

            if (rbNokGenri.Checked)
            {
                FillCell(ws2, 25, 9, "X");
            }
            if (rbOkGenri.Checked)
            {
                FillCell(ws2, 25, 10, "X");
            }

            if (rbNokGensoku.Checked)
            {
                FillCell(ws2, 26, 9, "X");
            }
            if (rbOkGensoku.Checked)
            {
                FillCell(ws2, 26, 10, "X");
            }
        }

        private void bgGenerar_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    //SELECCIONAR LA OPCIÓN EN LA BAÑERA
                    var checkedRadio = new[] { gbTipoFalla }
                            .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));
                    int check = 1;
                    foreach (var item in checkedRadio)
                    {
                        if (item.Checked)
                        {
                            check = int.Parse(item.Tag.ToString());
                        }
                    }

                    //IDENTIFICAR CAUSA RAIZ
                    var checkedRadio1 = new[] { gbCausaRaiz2 }
                            .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));
                    int check1 = 1;
                    foreach (var item in checkedRadio1)
                    {
                        if (item.Checked)
                        {
                            check1 = int.Parse(item.Tag.ToString());
                        }
                    }

                    //GUARDAR EN BASE DE DATOS
                    ewos ewo = new ewos();
                    ewo.consecutivo = int.Parse(txtConsecutivo.Text.ToString());
                    ewo.id_area_linea = int.Parse(cboAreaLinea.SelectedValue.ToString());
                    ewo.id_equipo = int.Parse(cboEquipo.SelectedValue.ToString());
                    ewo.fecha_ewo = dtpFecha.Value;
                    ewo.aviso_numero = txtAviso.Text.Trim();
                    ewo.id_tecnico = cboTecnico.SelectedValue.ToString();
                    ewo.id_tipo_averia = int.Parse(cboTipoAveria.SelectedValue.ToString());
                    ewo.id_turno = int.Parse(cboTurno.Text);
                    ewo.notificacion_averia = dtpNotAveria.Value;
                    ewo.inicio_reparacion = dtpIniReparacion.Value;
                    ewo.tiempo_espera_tecnico = int.Parse(txtEsperaTecnico.Text);
                    ewo.tiempo_diagnostico = int.Parse(txtDiagnostico.Text);
                    ewo.tiempo_espera_repuestos = int.Parse(txtEsperaRepuestos.Text);
                    ewo.tiempo_reparacion = int.Parse(txtReparacionPiezas.Text);
                    ewo.tiempo_pruebas = int.Parse(txtPruebasArranque.Text);
                    ewo.fin_reparacion = dtpFinReparacion.Value;
                    ewo.tiempo_total = int.Parse(txtTiempoFinal.Text);
                    ewo.imagen_1 = Path.GetFileName(imagen1);
                    ewo.imagen_2 = Path.GetFileName(imagen2); ;
                    ewo.desc_imagen_1 = txtDescImagen1.Text;
                    ewo.desc_imagen_2 = txtDescImagen2.Text;
                    ewo.desc_averia = txtDescripcion.Text;
                    ewo.cambio_componente = rbCambioComponente.Checked;
                    ewo.ajuste = rbAjuste.Checked;
                    ewo.what = txtWhat.Text;
                    ewo.where = txtWhere.Text;
                    ewo.when = txtWhen.Text;
                    ewo.who = txtWho.Text;
                    ewo.wich = txtWich.Text;
                    ewo.how = txtHow.Text;
                    ewo.fenomeno = txtFenomeno.Text;
                    ewo.gemba = txtGemba.Text;
                    ewo.gemba_ok = rbOkGemba.Checked;
                    ewo.gembutsu = txtGembutsu.Text;
                    ewo.gembutsu_ok = rbOkGembutsu.Checked;
                    ewo.genjitsu = txtGenjitsu.Text;
                    ewo.genjitsu_ok = rbOkGenjitsu.Checked;
                    ewo.genri = txtGenri.Text;
                    ewo.genri_ok = rbOkGenri.Checked;
                    ewo.gensoku = txtGensoku.Text;
                    ewo.gensoku_ok = rbOkGensoku.Checked;
                    ewo.imagen_3 = Path.GetFileName(imagenPorque1);
                    ewo.imagen_4 = Path.GetFileName(imagenPorque2); ;
                    ewo.desc_imagen_3 = txtDescImgPorque1.Text;
                    ewo.desc_imagen_4 = txtDescImgPorque2.Text;
                    ewo.fecha_ultimo_mtto = dtpFechaUltimoMtto.Value;
                    ewo.fecha_proximo_mtto = dtpFechaProxMtto.Value;
                    ewo.falla_index = check;
                    ewo.causa_raiz_index = check1;
                    ewo.tecnicos_man_involucrados = cboChkTecInvolucrados.Text;
                    ewo.operarios_involucrados = cboChkOpeInvolucrados.Text;
                    ewo.elaborador_analisis = cboChkElaborado.Text;
                    ewo.fecha_analisis = dtpFechaAnalisis.Value;
                    ewo.definidor_contramedidas = cboChkContraInvolucrados.Text;
                    ewo.fecha_contramedida = dtpFechaContraMedidas.Value;
                    ewo.validador_ejecucion = cboChkValidInvolucrados.Text;
                    ewo.fecha_validacion = dtpValidacion.Value;
                    ewo.user_id = Util.Global.UserLoged.Id;

                    if (daoEwo.AddEwo(ewo) > 1)
                    {
                        for (int i = 0; i < dt_porque.Rows.Count; i++)
                        {
                            daoPor.AddPorque(new porques()
                            {
                                id_ewo = daoEwo.GetLastId(),
                                porque_1 = dt_porque.Rows[i][0].ToString(),
                                porque_2 = dt_porque.Rows[i][1].ToString(),
                                porque_3 = dt_porque.Rows[i][2].ToString(),
                                porque_4 = dt_porque.Rows[i][3].ToString(),
                                porque_5 = dt_porque.Rows[i][4].ToString()
                            });
                        }

                        for (int i = 0; i < dt_lista_acciones.Rows.Count; i++)
                        {
                            daoLAcc.AddAccion(new lista_acciones()
                            {
                                id_ewo = daoEwo.GetLastId(),
                                accion = dt_lista_acciones.Rows[i][0].ToString(),
                                tipo_accion = dt_lista_acciones.Rows[i][1].ToString(),
                                responsable = dt_lista_acciones.Rows[i][2].ToString(),
                                fecha = DateTime.Parse(dt_lista_acciones.Rows[i][3].ToString())
                            });
                        }

                        for (int i = 0; i < dt_repuestos.Rows.Count; i++)
                        {
                            daoRU.AddRepuestoUtilizado(new repuestos_utilizados()
                            {
                                id_ewo = daoEwo.GetLastId(),
                                codigo_sap = int.Parse(dt_repuestos.Rows[i][0].ToString()),
                                descripcion = dt_repuestos.Rows[i][1].ToString(),
                                cantidad = int.Parse(dt_repuestos.Rows[i][2].ToString()),
                                costo = int.Parse(dt_repuestos.Rows[i][3].ToString())
                            });
                        }
                    }

                    //GENERAR EXCEL
                    Microsoft.Office.Interop.Excel.Application xlApp =
                            new Microsoft.Office.Interop.Excel.Application();

                    xlApp.Visible = false;

                    string sru = Util.Global.DIRECTORIO_FORMATOS;                                     
                    
                    path = @"" + sru + "\\EWO.xlsx";

                    File.WriteAllBytes(path, Properties.Resources.FORMATO_EWO_EN_BLANCO_UNIFICADO);

                    if (IsFileLocked(new FileInfo(path)))
                    {
                        MessageBox.Show("El archivo se está ejecutando, debe cerrarlo para continuar",
                                "Exportar en Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Workbook wb = xlApp.Workbooks.Open(path);
                        Worksheet ws2 = (Worksheet)wb.Worksheets[1];
                        
                        //PESTAÑA 1
                        //FILA 2
                        FillCell(ws2, 3, 1, txtConsecutivo.Text.ToString());
                        FillCell(ws2, 3, 2, cboAreaLinea.Text);
                        FillCell(ws2, 3, 3, cboEquipo.Text);
                        FillCell(ws2, 3, 5, dtpFecha.Value.ToShortDateString().ToString());
                        FillCell(ws2, 3, 6, txtAviso.Text);
                        FillCell(ws2, 3, 7, cboTecnico.Text);
                        FillCell(ws2, 3, 8, cboTipoAveria.Text);
                        FillCell(ws2, 3, 10, cboTurno.Text);

                        //FILA 5
                        FillCell(ws2, 6,1, dtpNotAveria.Value.ToShortTimeString());
                        FillCell(ws2, 6,2, dtpIniReparacion.Value.ToShortTimeString());
                        FillCell(ws2, 6,3, txtEsperaTecnico.Text);
                        FillCell(ws2, 6,4, txtDiagnostico.Text);
                        FillCell(ws2, 6,5,txtEsperaRepuestos.Text);
                        FillCell(ws2, 6,6, txtReparacionPiezas.Text);

                        var pauseDuration = TimeSpan.FromMinutes(int.Parse(txtPruebasArranque.Text));
                        FillCell(ws2, 6, 7, pauseDuration.ToString());
                        FillCell(ws2, 6, 8, dtpFinReparacion.Value.ToShortTimeString());
                        FillCell(ws2, 6, 9, txtTiempoFinal.Text);

                        ////PRIMERAS IMAGENES
                        Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[8, 1];
                        Microsoft.Office.Interop.Excel.Range oRange2 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[8, 3];

                        if (!imagen1.Equals(""))
                        {
                            Image oImage = Image.FromFile(imagen1);
                            oImage = resizeImage(oImage, new Size(190, 200));
                            System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                            ws2.Paste(oRange, imagen1);
                        }
                        if (!imagen2.Equals(""))
                        {
                            Image oImage = Image.FromFile(imagen2);
                            oImage = resizeImage(oImage, new Size(210, 200));
                            System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                            ws2.Paste(oRange2, imagen2);
                        }

                        //FILA 15
                        FillCell(ws2, 16, 1, txtDescImagen1.Text);
                        FillCell(ws2, 16, 3, txtDescImagen2.Text);

                        //DESCRIPCIÓN
                        FillCell(ws2, 8, 6, "\r\n" + "\r\n" + txtDescripcion.Text);

                        ////CAMBIO DE REPUESTO O AJUSTE
                        string a = "", c = ""; if (rbAjuste.Checked) { a = "X"; } else { c = "X"; }
                        ws2.Cells[12, 6] = "( " + c + "  ) Cambio de Componente                    (  " + a + "  ) Ajuste";

                        //LISTA DE REPUESTOS USADOS
                        if (dt_repuestos.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt_repuestos.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dt_repuestos.Columns.Count; j++)
                                {
                                    if (j == 2 || j == 3)
                                    {
                                        FillCell(ws2, 15 + i, j + 7, dt_repuestos.Rows[i][j].ToString());
                                    }
                                    else
                                    {
                                        FillCell(ws2, 15 + i, j + 6, dt_repuestos.Rows[i][j].ToString());
                                    }
                                }
                            }
                        }

                        //PESTAÑA 2
                        //5 W
                        FillCell(ws2, 28, 3, txtWhat.Text);
                        FillCell(ws2, 29, 3, txtWhere.Text);
                        FillCell(ws2, 30, 3, txtWhen.Text);
                        FillCell(ws2, 31, 3, txtWho.Text);
                        FillCell(ws2, 32, 3, txtWich.Text);
                        FillCell(ws2, 33, 3, txtHow.Text);
                        FillCell(ws2, 35, 1, txtFenomeno.Text);

                        //PESTAÑA 3
                        //5 G - IDENTIFICACIÓN DE CAUSAS RAICES
                        FillCell(ws2, 22, 3, txtGemba.Text);
                        FillCell(ws2, 23, 3, txtGembutsu.Text);
                        FillCell(ws2, 24, 3, txtGenjitsu.Text);
                        FillCell(ws2, 25, 3, txtGenri.Text);
                        FillCell(ws2, 26, 3, txtGensoku.Text);

                        ////5 G - NOK,OK
                        FillGENS(ws2);

                        //LISTA DE PORQUE PORQUE
                        if (dt_porque.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt_porque.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dt_porque.Columns.Count; j++)
                                {
                                    if (j == 0)
                                    {
                                        FillCell(ws2, 38 + i, j + 1, dt_porque.Rows[i][j].ToString());
                                    }
                                    if (j == 1)
                                    {
                                        FillCell(ws2, 38 + i, j + 2, dt_porque.Rows[i][j].ToString());
                                    }
                                    if (j == 2)
                                    {
                                        FillCell(ws2, 38 + i, j + 3, dt_porque.Rows[i][j].ToString());
                                    }
                                    if (j == 3)
                                    {
                                        FillCell(ws2, 38 + i, j + 4, dt_porque.Rows[i][j].ToString());
                                    }
                                    if (j == 4)
                                    {
                                        FillCell(ws2, 38 + i, j + 5, dt_porque.Rows[i][j].ToString());
                                    }
                                }
                            }
                        }

                        //SEGUNDAS IMAGENES
                        Microsoft.Office.Interop.Excel.Range oRange3 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[43, 2];
                        Microsoft.Office.Interop.Excel.Range oRange4 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[43, 6];

                        if (!imagenPorque1.Equals(""))
                        {
                            Image oImage = Image.FromFile(imagenPorque1);
                            oImage = resizeImage(oImage, new Size(260, 230));
                            System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                            ws2.Paste(oRange3, imagenPorque1);
                        }

                        if (!imagenPorque2.Equals(""))
                        {
                            Image oImage = Image.FromFile(imagenPorque2);
                            oImage = resizeImage(oImage, new Size(260, 230));
                            System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                            ws2.Paste(oRange4, imagenPorque2);
                        }

                        //DESCRIPCIÓN SEGUNDAS IMAGENES
                        FillCell(ws2, 55, 1, txtDescImgPorque1.Text.ToString());
                        FillCell(ws2, 55, 6, txtDescImgPorque2.Text.ToString());

                        Microsoft.Office.Interop.Excel.OptionButton opt =
                            (Microsoft.Office.Interop.Excel.OptionButton)ws2.OptionButtons(check);
                        opt.Value = true;

                        FillCell(ws2, 64, 2, dtpFechaUltimoMtto.Value.ToShortDateString());
                        FillCell(ws2, 64, 8, dtpFechaProxMtto.Value.ToShortDateString());

                        //CAUSA RAIZ
                        Microsoft.Office.Interop.Excel.Range rango1 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 1];
                        Microsoft.Office.Interop.Excel.Range rango2 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 2];
                        Microsoft.Office.Interop.Excel.Range rango3 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 4];
                        Microsoft.Office.Interop.Excel.Range rango4 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 5];
                        Microsoft.Office.Interop.Excel.Range rango5 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 7];
                        Microsoft.Office.Interop.Excel.Range rango6 = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[69, 9];

                        float pri = (float)rango1.Left;
                        float seg = (float)rango2.Left + 28f;
                        float ter = (float)rango3.Left;
                        float cua = (float)rango4.Left + 37f;
                        float qui = (float)rango5.Left + 8f;
                        float sex = (float)rango6.Left;

                        if (rbPri.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                pri, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }
                        if (rbSeg.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                seg, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }
                        if (rbTer.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                ter, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }
                        if (rbCua.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                cua, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }
                        if (rbQui.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                qui, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }
                        if (rbSex.Checked)
                        {
                            ws2.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeOval,
                                sex, 1700, 80, 200).Fill.Transparency = 0.89f;
                        }

                        if (dt_lista_acciones.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt_lista_acciones.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dt_lista_acciones.Columns.Count; j++)
                                {
                                    if (j == 0)
                                    {
                                        FillCell(ws2, 88 + i, j + 2, dt_lista_acciones.Rows[i][j].ToString());
                                    }
                                    if (j == 1)
                                    {
                                        //(CM) Contramedidas o Acciones Inmediatas
                                        //(AP) Acción Preventiva
                                        //(RH) Replica Horizontal
                                        if (dt_lista_acciones.Rows[i][j].ToString().Equals("(CM) Contramedidas o Acciones Inmediatas"))
                                        {
                                            FillCell(ws2, 88 + i, j + 6, "CM");
                                        }
                                        if (dt_lista_acciones.Rows[i][j].ToString().Equals("(AP) Acción Preventiva"))
                                        {
                                            FillCell(ws2, 88 + i, j + 6, "AP");
                                        }
                                        if (dt_lista_acciones.Rows[i][j].ToString().Equals("(RH) Replica Horizontal"))
                                        {
                                            FillCell(ws2, 88 + i, j + 6, "RH");
                                        }
                                    }
                                    if (j == 2)
                                    {
                                        FillCell(ws2, 88 + i, j + 6, dt_lista_acciones.Rows[i][j].ToString());
                                    }
                                    if (j == 3)
                                    {
                                        if (dt_lista_acciones.Rows[i][j].ToString().Equals(""))
                                        {
                                            FillCell(ws2, 88 + i, j + 7, DateTime.Now.ToShortDateString());
                                        }
                                        else
                                        {
                                            FillCell(ws2, 88 + i, j + 7, dt_lista_acciones.Rows[i][j].ToString());
                                        }
                                    }
                                }
                            }
                        }

                        //RESPONSABLES
                        FillCell(ws2, 103, 1, cboChkTecInvolucrados.Text.Replace('"', ' '));
                        FillCell(ws2, 103, 6, cboChkOpeInvolucrados.Text.Replace('"', ' '));
                        FillCell(ws2, 105, 1, cboChkElaborado.Text.Replace('"', ' '));
                        FillCell(ws2, 105, 3, dtpFechaAnalisis.Value.ToShortDateString());
                        FillCell(ws2, 105, 4, cboChkContraInvolucrados.Text.Replace('"', ' '));
                        FillCell(ws2, 105, 7, dtpFechaContraMedidas.Value.ToShortDateString());
                        FillCell(ws2, 105, 8, cboChkValidInvolucrados.Text.Replace('"', ' '));
                        FillCell(ws2, 105, 10, dtpValidacion.Value.ToShortDateString());

                        wb.Save();
                        wb.Close();
                    }

                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }

        private void bgGenerar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                            MessageBox.Show("Archivo guardado!");

                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }
                pbGenerando.Visible = false;
                lblGenerando.Visible = false;

                DialogResult dr2 = MessageBox.Show
                    ("Desea diligenciar un nuevo formato?", "Formato EWO"
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

        private void FormEwo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();

            GC.Collect();
        }

        private void LimpiarCampos()
        {
            try
            {
                //PESTAÑA 1
                txtConsecutivo.Text = daoEwo.GetLastConsecutive().ToString();
                cboAreaLinea.SelectedIndex = 0;
                txtAviso.Text = "";
                cboTipoAveria.SelectedIndex = 0;
                cboTecnico.SelectedIndex = 0;
                dtpFecha.Value = DateTime.Now;
                cboEquipo.SelectedIndex = 0;
                cboTurno.SelectedIndex = 0;

                dtpNotAveria.Value = DateTime.Now;
                dtpIniReparacion.Value = DateTime.Now;
                dtpFinReparacion.Value = DateTime.Now;
                txtEsperaTecnico.Text = "0";
                txtDiagnostico.Text = "0";
                txtEsperaRepuestos.Text = "0";
                txtReparacionPiezas.Text = "0";
                txtPruebasArranque.Text = "0";
                txtTiempoFinal.Text = "";

                txtDescripcion.Text = "";
                rbAjuste.Checked = false;
                rbCambioComponente.Checked = true;
                dtgRepuestos.Rows.Clear();
                dtgRepuestos.DataSource = null;
                img1.Image = Properties.Resources.placeholder;
                img2.Image = Properties.Resources.placeholder;
                txtDescImagen1.Text = "";
                txtDescImagen2.Text = "";

                //PESTAÑA 2
                txtGemba.Text = "-";
                txtGembutsu.Text = "-";
                txtGenjitsu.Text = "-";
                txtGenri.Text = "-";
                txtGensoku.Text = "-";

                rbNokGemba.Checked = false;
                rbNokGembutsu.Checked = false;
                rbNokGenjitsu.Checked = false;
                rbNokGenri.Checked = false;
                rbNokGensoku.Checked = false;
                rbOkGemba.Checked = false;
                rbOkGembutsu.Checked = false;
                rbOkGenjitsu.Checked = false;
                rbOkGenri.Checked = false;
                rbOkGensoku.Checked = false;

                //PESTAÑA 3
                txtWhat.Text = "";
                txtWhere.Text = "";
                txtWhen.Text = "";
                txtWho.Text = "";
                txtWich.Text = "";
                txtHow.Text = "";
                txtFenomeno.Text = "";
                dtgPorque.Rows.Clear();
                dtgPorque.DataSource = null;

                //PESTAÑA 4
                dtpFechaUltimoMtto.Value = DateTime.Now;
                dtpFechaProxMtto.Value = DateTime.Now;
                rbErrorHumano.Checked = false;
                rbFallaDiseño.Checked = false;
                rbCalidadRepuestos.Checked = false;
                rbCondicionesOperacion.Checked = false;
                rbCondicionesBasicas.Checked = false;
                rbErrorHumano2.Checked = false;
                rbNoPM.Checked = false;
                rbNoAM.Checked = false;
                pbImagenPorque1.Image = Properties.Resources.placeholder;
                pbImagenPorque2.Image = Properties.Resources.placeholder;
                txtDescImgPorque1.Text = "";
                txtDescImgPorque2.Text = "";

                //PESTAÑA 5
                rbPri.Checked = false;
                rbSeg.Checked = false;
                rbTer.Checked = false;
                rbCua.Checked = false;
                rbQui.Checked = false;
                rbSex.Checked = false;
                dtgListaAcciones.Rows.Clear();
                dtgListaAcciones.DataSource = null;

                cboChkTecInvolucrados.Text = "";
                cboChkContraInvolucrados.Text = "";
                cboChkOpeInvolucrados.Text = "";
                cboChkElaborado.Text = "";
                cboChkValidInvolucrados.Text = "";

                dtpFechaContraMedidas.Value = DateTime.Now;
                dtpFechaAnalisis.Value = DateTime.Now;
                dtpValidacion.Value = DateTime.Now;

                //GENERALES
                imagen1 = "";
                imagen2 = "";
                pbGenerando.Visible = false;
                lblGenerando.Visible = false;

                foreach (TabPage tp in tabcontrol.TabPages)
                {
                    EnableTab(tp, true);
                }

                btnExportar.Visible = false;
                lblPorcentaje.Text = "0%";
                pbLoad.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error mientras se restauraba formulario, intente nuevamente! " + ex.ToString());
            }
        }
    }
}
