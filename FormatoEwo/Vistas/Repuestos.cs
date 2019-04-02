using FormatoEwo.DaoEF;
using FormatoEwo.Util;
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
    public partial class Repuestos : Form
    {
        Bitmap bmp;
        int i = 0;
        string data = "";
        public string elemento { get; set; }
        public List<Objetos.Repuestos> listRep { get; set; }
        public List<Objetos.Repuestos> list = new List<Objetos.Repuestos>();
        DaoRepuestosUtilizados daoRU = new DaoRepuestosUtilizados();

        public Repuestos()
        {
            InitializeComponent();
        }

        private void Repuestos_Load(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            //CUANDO SE PRODUZCA UN CAMBIO EN LAS CELDAS DEL DATAGRID
            dtgRep.CellValueChanged += DtgHerr_CellValueChanged;

            UpdateDatagrid();
        }

        private void UpdateDatagrid()
        {
            dtgRep.DataSource = null;
            dtgRep.AutoGenerateColumns = false;
            list = daoRU.GetReplacement();            

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
                }
                if (i == 6) { break; }
            }

            lblCantidadImagenes.Text = lvImagenes.Items.Count.ToString();
            lblInfo.Visible = false;
            timer1.Stop();
            timer1.Dispose();
            pbCargando.Visible = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (dtgRep.SelectedRows[0].Cells[1].Value != null)
                {
                    elemento = dtgRep.SelectedRows[0].Cells[1].Value.ToString();
                    this.Text = elemento;
                    lblInfo.Visible = true;
                    lvImagenes.Clear();
                    imageList1.Images.Clear();
                    i = 0;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtgRep.SelectedRows.Count > 0)
            {
                lblCantidadImagenes.Text = "0";
                pbCargando.Visible = true;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una herramienta!");
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
                    if (img1.Height == 180)
                    {
                        row.Height = 180;
                    }
                }
                //VISUALIZAR CANTIDAD DE HERRAMIENTAS DISPONIBLES
                lblDisponibles.Text = dtgRep.Rows.Count.ToString();
            }
        }

        private void dtgRep_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgRep.IsCurrentCellDirty)
            {
                dtgRep.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoRepuesto nr = new NuevoRepuesto();

            if (nr.ShowDialog() == DialogResult.OK)
            {
                list.Add(new Objetos.Repuestos()
                {
                    repuesto = nr.repuesto,
                    cantidad = nr.cantidad,
                    imagen = columnsPlaceholder.Images[0]
                });

                UpdateDatagrid();
            }
            else
            {
                MessageBox.Show("No agregó repuesto!");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //DEVOLVER SOLO LOS QUE ESTÉN SELECCIONADOS
                listRep = list;

                foreach (Objetos.Repuestos item in listRep)
                {
                    item.Id = (int)daoRU.GetRepByDesc(item.repuesto).Id;
                }

                DialogResult = DialogResult.OK;
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar repuesto, " + ex.ToString());
            }
        }
    }
}
