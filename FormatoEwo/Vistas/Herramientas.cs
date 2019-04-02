using FormatoEwo.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using FormatoEwo.DaoEF;

namespace FormatoEwo.Vistas
{
    
    public partial class Herramientas : Form
    {        
        Bitmap bmp;
        int i = 0;
        string data = "";
        public string elemento { get; set; }
        public List<Objetos.Herramientas> listRet { get; set; }
        List<Objetos.Herramientas> listHerr = new List<Objetos.Herramientas>();
        List<Objetos.Herramientas> listHerrDB = new List<Objetos.Herramientas>();
        DaoHerr daoH = new DaoHerr();

        public Herramientas()
        {
            InitializeComponent();
        }

        private void Herramientas_Load(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            LoadGrid();

            //CUANDO SE PRODUZCA UN CAMBIO EN LAS CELDAS DEL DATAGRID
            dtgHerr.CellValueChanged += DtgHerr_CellValueChanged;
               
        }

        private void LoadGrid() 
        {
            //listHerr.Clear();

            //CARGANDO DATOS EN LISTA (BASE DE DATOS)
            listHerrDB = daoH.GetTools();

            for (int i = 0; i < listHerrDB.Count; i++)
            {
                var exs = listHerr.Find(x => x.Id == listHerrDB[i].Id);
                if (exs == null)
                {
                    listHerr.Add(new Objetos.Herramientas()
                    {
                        sel = false,
                        Id = listHerrDB[i].Id,
                        herramienta = listHerrDB[i].herramienta,
                        tipo = listHerrDB[i].tipo,
                        imagen_name = listHerrDB[i].imagen_name,
                        imagen = columnsPlaceholder.Images[0]
                    });
                }
            }

            UpdateDatagrid();
        }

        private void UpdateDatagrid()
        {            
            dtgHerr.DataSource = null;
            dtgHerr.DataSource = listHerr;
            //CONFIGURACIONES POR DEFECTOS DE LAS COLUMNAS
            dtgHerr.Columns[1].Visible = false;
            dtgHerr.Columns[5].Visible = false;
            dtgHerr.Columns[2].Width = 240;

            //VISUALIZAR CANTIDADES DE SELECCIONADOS Y ENCONTRADOS
            lblDisponibles.Text = dtgHerr.Rows.Count.ToString();     
        }

        private void DtgHerr_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dtgHerr.Rows[e.RowIndex].Cells[0];

                    var checkedRows = from DataGridViewRow r in dtgHerr.Rows
                                      where Convert.ToBoolean(r.Cells[0].Value) == true
                                      select r;

                    listHerr[e.RowIndex].sel = (bool)checkCell.Value;

                    if (listHerr[e.RowIndex].imagen_name != null)
                    {
                        dtgHerr.Rows[e.RowIndex].Cells[4].Value = new Bitmap(Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(listHerr[e.RowIndex].imagen_name));
                        dtgHerr.SelectedRows[0].Height = 180;
                    }                    


                    lblSeleccionados.Text = checkedRows.ToList().Count.ToString();

                    dtgHerr.Invalidate();
                }
                if (e.ColumnIndex == 2)
                {
                    DataGridViewTextBoxCell Cell = (DataGridViewTextBoxCell)dtgHerr.Rows[e.RowIndex].Cells[2];

                    listHerr[e.RowIndex].herramienta = Cell.Value.ToString();
                }
                if (e.ColumnIndex == 3)
                {
                    DataGridViewTextBoxCell Cell = (DataGridViewTextBoxCell)dtgHerr.Rows[e.RowIndex].Cells[3];

                    listHerr[e.RowIndex].tipo = Cell.Value.ToString();
                }
                if (e.ColumnIndex == 4)
                {
                    DataGridViewImageCell Cell = (DataGridViewImageCell)dtgHerr.Rows[e.RowIndex].Cells[4];

                    listHerr[e.RowIndex].imagen = (Image)Cell.Value;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ojo con el error: "+ex.ToString());
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
                    webClient.Timeout = 4000;
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
                    Console.WriteLine("Error en imagen # "+i+", "+we.ToString());
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
                MessageBox.Show("Revisa tu conexión a internet, "+ex.Message);
            }
            return data;                        
        }       
               
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (dtgHerr.SelectedRows[0].Cells[1].Value != null)
                {
                    elemento = dtgHerr.SelectedRows[0].Cells[2].Value.ToString();
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
            if (dtgHerr.SelectedRows.Count > 0)
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
            try
            {               
                ToolStripMenuItem tsmi = (ToolStripMenuItem)e.ClickedItem; 
                if (lvImagenes.SelectedItems.Count > 0)
                {
                    if (tsmi == tsmFijarImagen)
                    {
                        dtgHerr.SelectedRows[0].Cells[4].Value = lvImagenes.SelectedItems[0].ImageList.Images[lvImagenes.SelectedItems[0].Index];
                        dtgHerr.SelectedRows[0].Height = 180;
                    
                        //DESCARGAR IMAGEN A EQUIPO
                        string url = lvImagenes.SelectedItems[0].ImageList.Images.Keys[lvImagenes.SelectedItems[0].Index];
                        listHerr[dtgHerr.SelectedRows[0].Index].imagen_name = url;

                        //EDITAR EN LA BASE DE DATOS EL NOMBRE DE LA IMAGEN DESCARGADA
                        daoH.EditTool(listHerr[dtgHerr.SelectedRows[0].Index]);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error configurando imágen: "+ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtgHerr.SelectedRows.Count > 0)
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Abrir imágen";
                    dlg.Filter = "Imágenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    dlg.InitialDirectory = Util.Global.DIRECTORIO_IMAGENES;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        dtgHerr.SelectedRows[0].Cells[4].Value = 
                            SomeHelpers.resizeImage(180, 180, dlg.FileName);
                        dtgHerr.SelectedRows[0].Height = 180;
                        //EDITAR EN LA BASE DE DATOS EL NOMBRE DE LA IMAGEN DESCARGADA
                        daoH.EditTool(listHerr[dtgHerr.SelectedRows[0].Index]);

                        listHerr[dtgHerr.SelectedRows[0].Index].imagen_name = dlg.SafeFileName;
                        SomeHelpers.CopyImageToServer(dlg);                        
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
                foreach (DataGridViewRow r in dtgHerr.Rows)
                {
                    if ((r.Cells[2].Value).ToString().Contains(txtBuscar.Text))
                    {
                        dtgHerr.Rows[r.Index].Visible = true;
                        dtgHerr.Rows[r.Index].Selected = true;
                    }
                    else
                    {
                        dtgHerr.CurrentCell = null;
                        dtgHerr.Rows[r.Index].Visible = false;
                    }

                    var rv = from DataGridViewRow ra in dtgHerr.Rows
                             where Convert.ToBoolean(ra.Visible) == true
                             select ra;

                    lblDisponibles.Text = rv.ToList().Count.ToString();
                }
            }
            else
            {
                UpdateDatagrid();

                foreach (DataGridViewRow row in dtgHerr.Rows)
                {
                    Image img1 = (Image)row.Cells[4].Value;
                    if (img1.Height == 180)
                    {
                        row.Height = 180;
                    }                 
                }
                //VISUALIZAR CANTIDAD DE HERRAMIENTAS DISPONIBLES
                lblDisponibles.Text = dtgHerr.Rows.Count.ToString();
            }
        }

        private void dtgHerr_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgHerr.IsCurrentCellDirty)
            {
                dtgHerr.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoElemento ne = new NuevoElemento();

            if (ne.ShowDialog() == DialogResult.OK)
            {
                LoadGrid();

                listHerr.Find(x => x.herramienta.Equals(ne.herramienta)).sel = ne.seleccionada;

                //MOSTRAR LA ULTIMA FILA
                dtgHerr.FirstDisplayedScrollingRowIndex = dtgHerr.RowCount - 1;
                //listHerr.Add(new Objetos.Herramientas()
                //{
                //    herramienta = ne.herramienta,
                //    sel = ne.seleccionada,
                //    tipo = ne.tipo,
                //    imagen = columnsPlaceholder.Images[0]
                //});


            }
            else
            {
                MessageBox.Show("No agregó herramienta!");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //DEVOLVER SOLO LOS QUE ESTÉN SELECCIONADOS
            listRet = listHerr.Where(x => x.sel == true).ToList();
            DialogResult = DialogResult.OK;
            Dispose();
        }
    }

    public class WebClientMia : System.Net.WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest lWebRequest = base.GetWebRequest(uri);
            lWebRequest.Timeout = Timeout;
            ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
            return lWebRequest;
        }
    }
}