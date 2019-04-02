
using FormatoEwo.DaoEF;
using FormatoEwo.Objetos;
using FormatoEwo.Util;
using FormatoEwo.Vistas;
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
    public partial class FRepuestos : MetroForm
    {
        Bitmap bmp;
        int i = 0;
        string data = "";
        public string elemento { get; set; }
        public List<Objetos.Repuestos> listRep { get; set; }
        public List<Objetos.Repuestos> list = new List<Objetos.Repuestos>();
        public List<Objetos.Repuestos> listDB = new List<Objetos.Repuestos>();
        DaoRepuestosUtilizados daoRU = new DaoRepuestosUtilizados();
        Splash splash = new Splash();

        public FRepuestos()
        {
            InitializeComponent();
        }

        private void FRepuestos_Load(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            //CUANDO SE PRODUZCA UN CAMBIO EN LAS CELDAS DEL DATAGRID
            dtgRep.CellValueChanged += DtgHerr_CellValueChanged;

            UpdateDatagrid();
        }

        private void UpdateDatagrid()
        {
            
            dtgRep.AutoGenerateColumns = false;

            listDB = daoRU.GetReplacement();

            for (int i = 0; i < listDB.Count; i++)
            {
                var exs = list.Find(x => x.Id == listDB[i].Id);
                if (exs == null)
                {
                    list.Add(new Objetos.Repuestos()
                    {
                        sel = false,
                        Id = listDB[i].Id,
                        repuesto = listDB[i].repuesto,                        
                        imagen = icons.Images[14],
                        imagen_name = listDB[i].imagen_name
                    });
                }
            }

            dtgRep.DataSource = null;

            if (list.Count > 0)
            {
                dtgRep.DataSource = list;
            }

            //VISUALIZAR CANTIDADES DE SELECCIONADOS Y ENCONTRADOS
            lblDisponibles.Text = dtgRep.Rows.Count.ToString();
        }

        private void DtgHerr_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dtgRep.Rows[e.RowIndex].Cells[0];

                    var checkedRows = from DataGridViewRow r in dtgRep.Rows
                                      where Convert.ToBoolean(r.Cells[0].Value) == true
                                      select r;

                    list[e.RowIndex].sel = (bool)checkCell.Value;

                    if (list[e.RowIndex].imagen_name != null)
                    {
                        dtgRep.SelectedRows[0].Cells[3].Value = new Bitmap(Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(list[e.RowIndex].imagen_name));
                        dtgRep.SelectedRows[0].Height = 180;                        
                    }

                    lblSeleccionados.Text = checkedRows.ToList().Count.ToString();

                    dtgRep.Invalidate();
                }
                if (e.ColumnIndex == 1)
                {
                    DataGridViewTextBoxCell Cell = (DataGridViewTextBoxCell)dtgRep.Rows[e.RowIndex].Cells[1];

                    list[e.RowIndex].repuesto = Cell.Value.ToString();
                }
                if (e.ColumnIndex == 2)
                {
                    DataGridViewTextBoxCell Cell = (DataGridViewTextBoxCell)dtgRep.Rows[e.RowIndex].Cells[2];

                    list[e.RowIndex].cantidad = int.Parse(Cell.Value.ToString());
                }
                if (e.ColumnIndex == 3)
                {
                    DataGridViewImageCell Cell = (DataGridViewImageCell)dtgRep.Rows[e.RowIndex].Cells[3];

                    list[e.RowIndex].imagen = (Image)Cell.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ojo con el error: " + ex.ToString());
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int ndx = data.IndexOf("\"ou\"", StringComparison.Ordinal);

            while (ndx >= 0)
            {
                ndx = data.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                ndx++;
                int ndx2 = data.IndexOf("\"", ndx, StringComparison.Ordinal);
                string urlUn = data.Substring(ndx, ndx2 - ndx);
                ndx = data.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);

                try
                {
                    var webClient = new WebClientMia();
                    webClient.Headers.Add("User-Agent: Other");
                    webClient.Timeout = 10000;
                    byte[] imageBytes = webClient.DownloadData(urlUn);
                    webClient.Dispose();

                    if (imageBytes != null)
                    {
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            Console.WriteLine(urlUn);
                            bmp = new Bitmap(ms);
                            if (ms != null)
                            {
                                imageList1.Images.Add(urlUn, bmp);
                                lvImagenes.Items.Add(urlUn, "", i);
                                i++;
                            }
                        }
                    }
                }
                catch (Exception we)
                {
                    Console.WriteLine("Error en imagen # " + i + ", " + we.ToString());
                    splash.Hide();
                }
                if (i == 6) { break; }
            }

            lblCantidadImagenes.Text = lvImagenes.Items.Count.ToString();
            lblInfo.Visible = false;
            timer1.Stop();
            timer1.Dispose();
            splash.Hide();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                data = GetHtmlCode();

            }), null);
        }

        private string GetHtmlCode()
        {
            try
            {
                string url = "https://www.google.com/search?q=" + elemento + "&tbm=isch";

                var webClient = new WebClientMia();
                webClient.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko");
                webClient.Timeout = 10 * 60 * 1000;
                data = webClient.DownloadString(url);
                webClient.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa tu conexión a internet, " + ex.Message);
            }
            return data;
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            if (dtgRep.SelectedRows.Count > 0)
            {
                lblCantidadImagenes.Text = "0";
                splash.Show();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una herramienta!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (dtgRep.SelectedRows[0].Cells[1].Value != null)
                {
                    lblInfo.Visible = true;
                    lblInfo.Update();
                    elemento = dtgRep.SelectedRows[0].Cells[1].Value.ToString();
                    Text = elemento;
                    this.UpdateStyles();                    
                    lvImagenes.Clear();
                    imageList1.Images.Clear();
                    i = 0;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void dtgRep_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgRep.IsCurrentCellDirty)
            {
                dtgRep.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void lvImagenes_DoubleClick(object sender, EventArgs e)
        {
            if (lvImagenes.SelectedItems.Count > 0)
            {
                VisorImagenes vi = new VisorImagenes(false);
                vi.b_imgShow = lvImagenes.SelectedItems[0].Name;
                vi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Se debe seleccionar una imágen!");
            }
        }

        private void cmsOpciones_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)e.ClickedItem;
            if (lvImagenes.SelectedItems.Count > 0)
            {
                if (tsmi == tsmFijarImagen)
                {
                    dtgRep.SelectedRows[0].Cells[3].Value = lvImagenes.SelectedItems[0].ImageList.Images[lvImagenes.SelectedItems[0].Index];
                    dtgRep.SelectedRows[0].Height = 180;

                    //DESCARGAR IMAGEN A EQUIPO
                    string url = lvImagenes.SelectedItems[0].ImageList.Images.Keys[lvImagenes.SelectedItems[0].Index];
                    list[dtgRep.SelectedRows[0].Index].imagen_name = url;

                    //EDITAR EN LA BASE DE DATOS EL NOMBRE DE LA IMAGEN DESCARGADA
                    daoRU.EditRep(list[dtgRep.SelectedRows[0].Index]);

                    SomeHelpers.DownloadImageUrl(url);
                }
                if (tsmi == tsmVerImagenInternet)
                {
                    VisorImagenes vi = new VisorImagenes(false);
                    vi.b_imgShow = lvImagenes.SelectedItems[0].Name;
                    vi.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar una imágen!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtgRep.SelectedRows.Count > 0)
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Abrir imagen";
                    dlg.Filter = "Imágenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    dlg.InitialDirectory = Util.Global.DIRECTORIO_IMAGENES;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        dtgRep.SelectedRows[0].Cells[3].Value =
                            SomeHelpers.resizeImage(180, 180, dlg.FileName); ;
                        dtgRep.SelectedRows[0].Height = 180;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una herramienta!");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim().Length > 0)
            {
                foreach (DataGridViewRow r in dtgRep.Rows)
                {
                    if ((r.Cells[1].Value).ToString().Contains(txtBuscar.Text))
                    {
                        dtgRep.Rows[r.Index].Visible = true;
                        dtgRep.Rows[r.Index].Selected = true;
                    }
                    else
                    {
                        dtgRep.CurrentCell = null;
                        dtgRep.Rows[r.Index].Visible = false;
                    }

                    var rv = from DataGridViewRow ra in dtgRep.Rows
                             where Convert.ToBoolean(ra.Visible) == true
                             select ra;

                    lblDisponibles.Text = rv.ToList().Count.ToString();
                }
            }
            else
            {
                UpdateDatagrid();

                foreach (DataGridViewRow row in dtgRep.Rows)
                {
                    Image img1 = (Image)row.Cells[3].Value;
                    if (img1 != null)
                    {
                        if (img1.Height == 180)
                        {
                            row.Height = 180;
                        }
                    }                    
                }
                //VISUALIZAR CANTIDAD DE HERRAMIENTAS DISPONIBLES
                lblDisponibles.Text = dtgRep.Rows.Count.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoRepuesto nr = new NuevoRepuesto();

            if (nr.ShowDialog() == DialogResult.OK)
            {
                //list.Add(new Objetos.Repuestos()
                //{
                //    repuesto = nr.repuesto,
                //    cantidad = nr.cantidad,
                //    imagen = icons.Images[14]
                //});

                UpdateDatagrid();

                dtgRep.FirstDisplayedScrollingRowIndex = dtgRep.RowCount - 1;
            }
            else
            {
                MessageBox.Show("No agregó repuesto!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listRep = list.Where(x => x.sel).ToList();

                //VERIFICAR CANTIDADES
                int sinCant = listRep.Where(x => x.cantidad==0).ToList().Count;
                
                if (sinCant > 0 )
                {
                    MessageBox.Show("Revise las cantidades de los repuestos seleccionados!");
                }
                else
                {
                    //DEVOLVER SOLO LOS QUE ESTÉN SELECCIONADOS
                   

                    //foreach (Objetos.Repuestos item in listRep)
                    //{
                    //    item.Id = (int)daoRU.GetRepByDesc(item.repuesto).Id;
                    //}

                    DialogResult = DialogResult.OK;
                    Dispose();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar repuesto, " + ex.ToString());
            }
        }
    }
}
