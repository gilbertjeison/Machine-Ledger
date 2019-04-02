using FormatoEwo.DaoEF;
using FormatoEwo.Util;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormatoEwo.UserControls
{
    /// <summary>
    /// Lógica de interacción para AlmacenStock.xaml
    /// </summary>
    public partial class AlmacenStock : System.Windows.Controls.UserControl
    {
        BackgroundWorker bgLoad = new BackgroundWorker();
        BackgroundWorker bgPlantaFilter = new BackgroundWorker();
        BackgroundWorker bgLoadDeviation = new BackgroundWorker();
        BackgroundWorker bgExportToExcel = new BackgroundWorker();

        DeviationParameters dp = new DeviationParameters();
        string path;
        DaoMateriales daoMat = new DaoMateriales();
        public ICollectionView GroupedMaterial { get; set; }

        private IList<MaxAndMin> listToExport;

        public AlmacenStock()
        {
            InitializeComponent();
            //BACKGROUNDWORKER PARA CARGAR LOS ELEMENTOS
            bgLoad.DoWork += BgLoad_DoWork;
            bgLoad.RunWorkerCompleted += BgLoad_RunWorkerCompleted;
            //BACKGROUNDWORKER PARA FILTRAR LOS ELEMENTOS
            bgPlantaFilter.DoWork += BgPlantaFilter_DoWork;
            bgPlantaFilter.RunWorkerCompleted += BgPlantaFilter_RunWorkerCompleted;
            //BACKGROUNDWORKER PARA CARGAR LOS ELEMENTOS PARA CALCULAR DESVIACIÓN
            bgLoadDeviation.DoWork += BgLoadDeviation_DoWork;
            bgLoadDeviation.RunWorkerCompleted += BgLoadDeviation_RunWorkerCompleted;
            //BACKGROUNDWORKER PARA EXPORTAR LOS ELEMENTOS A UN EXCEL
            bgExportToExcel.DoWork += BgExportToExcel_DoWork;
            bgExportToExcel.RunWorkerCompleted += BgExportToExcel_RunWorkerCompleted;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //CARGAR DATOS ESTABLECIDOS EN EL ITEM #1 DEL COMBOBOX FILTRO
            StartWork(7);

            //ASIGNAR EVENTOS A CONTROLES
            //cboFIltro.SelectionChanged += cboFIltro_SelectionChanged;
            cboPlanta.SelectionChanged += cboPlanta_SelectionChanged;
        }

        private void BgExportToExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //UNA VEZ EXPORTADO PREGUNTA DONDE QUIERE GUARDAR EL ARCHIVO
                MessageBoxResult dr = System.Windows.MessageBox.Show
                    ("El archivo se ha generado correctamente, se encuentra en "
                        + path + " Desea guardarlo en otra ubicación?", "Proceso finalizado!"
                            , MessageBoxButton.YesNo, MessageBoxImage.Question);

                //PROCESO PARA GUARDAR EL ARCHIVO EN LA UBICACIÓN SELECCIONADA
                if (dr == MessageBoxResult.Yes)
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
                            System.IO.File.Copy(path, saveFileDialog1.FileName, true);

                            System.Windows.MessageBox.Show("Archivo guardado!");

                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }

                //RESTAURAR VALORES DE VISTA
                pbLoad.Visibility = Visibility.Hidden;
                lblTextLoad.Content = "Cargando...";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void BgExportToExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //GENERAR EXCEL
                //OBEJTO QUE PERMITE GESTIONAR DOCUMENTO EXCEL
                Microsoft.Office.Interop.Excel.Application xlApp =
                    new Microsoft.Office.Interop.Excel.Application();

                //MOSTRAR ARCHIVO MIENTRAS SE UTILIZA
                xlApp.Visible = false;

                //DIRECTORIO DONDE SE COPIARÁ EL ARCHIVO TEMPORALMENTE
                //PARA EDITARLO
                string sru = Util.Global.DIRECTORIO_FORMATOS;

                //NOMBRE DEL ARCHIVO TEMPORAL
                path = @"" + sru + "\\EXPORT.xlsx";

                //COPIAR EL ARCHIVO DE LOS RECURSOS DE LA APLICACIÓN
                // A LA RUTA ESTABLECIDA
                File.WriteAllBytes(path, Properties.Resources.Excel_export);

                //VERIFICAR SI EL ARCHIVO ESTÁ BLOQUEADO O ESTA SIENDO UTILIZADO POR OTRO PROCESO
                if (IsFileLocked(new FileInfo(path)))
                {
                    this.Dispatcher.BeginInvoke((System.Action)delegate ()
                    {
                        System.Windows.MessageBox.Show("El archivo se está ejecutando, debe cerrarlo para continuar",
                                    "Exportar en Excel", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                }
                else
                {
                    //CREAR EL OBJETO DEL LIBRO A PARTIR DE LA RUTA 
                    Workbook wb = xlApp.Workbooks.Open(path);

                    //FIJAR EN OBJETOS LAS PESTAÑAS U HOJA DEL LIBRO PARA TRABAJAR
                    Worksheet ws = (Worksheet)wb.Worksheets["Hoja1"];

                    //PROCESO PARA CONVERTIR UNA LISTA GENERICA DE OBJETOS EN DATATABLE PARA 
                    //FACILITAR SU PROCESO DE ESCRITURA EN EL ARCHIVO EXCEL
                    System.Data.DataTable dt = ConvertToDataTable<MaxAndMin>(listToExport);

                    //CICLOS PARA RECORRER FILAS Y COLUMNAS Y ESCRIBIR EN EL ARCHIVO EXCEL
                    for (int i = 2; i <= dt.Rows.Count + 1; i++)
                    {
                        for (int j = 1; j < dt.Columns.Count + 1; j++)
                        {
                            if (j == 7)
                            {
                                if (dt.Rows[i - 2][j - 1].ToString().Equals("0"))
                                {
                                    //LINEA
                                    FillCell(ws, i, j, "Todas");
                                }
                                if (dt.Rows[i - 2][j - 1].ToString().Equals("1"))
                                {
                                    //LINEA
                                    FillCell(ws, i, j, "Jabones");
                                }
                                if (dt.Rows[i - 2][j - 1].ToString().Equals("2"))
                                {
                                    //LINEA
                                    FillCell(ws, i, j, "Detergentes");
                                }
                            }
                            else
                            {
                                //LINEA
                                FillCell(ws, i, j, dt.Rows[i - 2][j - 1].ToString());
                            }
                        }
                    }

                    //GUARDAR Y CERRAR CONEXIÓN CON ARCHIVO EXCEL
                    wb.Save();
                    wb.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void BgLoadDeviation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //POSTULAR DATOS CON MAX Y MIN CALCULADOS 
            lvStock.ItemsSource = GroupedMaterial;

            //CANTIDAD DE REGISTROS
            lblCount.Content = lvStock.Items.Count.ToString() + " Elementos";

            //HABILITAR SELECCION DE PLANTAS SOLO PARA CUANDO SELECCIONE STOCK
            //if (cboFIltro.SelectedIndex == 6 || cboFIltro.SelectedIndex == 7)
            //{
            //    cboPlanta.IsEnabled = true;
            //}
            //else
            //{
            //    cboPlanta.IsEnabled = false;
            //    cboPlanta.SelectedIndex = 0;
            //}

            //RESTAURAR VALORES DE VISTA
            pbLoad.Visibility = Visibility.Hidden;
        }

        private void BgLoadDeviation_DoWork(object sender, DoWorkEventArgs e)
        {
            //CAPTURAR PARAMETRO DE ENTRADA
            int opcion = (int)e.Argument;

            //CONSULTAR DATOS DE ACUERDO A LA OPCION SELECCIONADA
            List<MaxAndMin> list = daoMat.MaxAndMin(opcion);

            //CALCULAR MINIMO Y MAXIMO PARA CADA UNO DE LOS ELEMENTOS DE LA LISTA BASADO EN EL PORCENTAJE DE DESVIACIÓN
            foreach (var item in list)
            {
                item.maximo = (Decimal.Divide(dp.superior, 100) * item.cantidad) + item.cantidad;
                item.minimo = item.cantidad - (Decimal.Divide(dp.inferior, 100) * item.cantidad) < 0 ? 1 : item.cantidad - (Decimal.Divide(dp.inferior, 100) * item.cantidad);
            }

            //ASIGNAR LA LISTA MODIFICADA PARA SER POSTULADA
            GroupedMaterial = new ListCollectionView(list);
            GroupedMaterial.GroupDescriptions.Add(new PropertyGroupDescription("descripcion"));
        }

        private void BgPlantaFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //POSTULAR DATOS FILTRADOS DE PLANTAS
            ICollectionView fl = (ICollectionView)e.Result;
            lvStock.ItemsSource = fl;
            lblCount.Content = lvStock.Items.Count.ToString() + " Elementos";

            //RESTAURAR VALORES DE VISTA
            pbLoad.Visibility = Visibility.Hidden;
        }

        private void BgPlantaFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            //FILTRAR DATOS POR PLANTA
            var filtered = GroupedMaterial.OfType<MaxAndMin>().Where(x => x.planta == (int)e.Argument);
            ICollectionView fl = new ListCollectionView(filtered.ToList());
            fl.GroupDescriptions.Add(new PropertyGroupDescription("descripcion"));

            e.Result = fl;
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvStock.ItemsSource = GroupedMaterial;
            lblCount.Content = lvStock.Items.Count.ToString() + " Elementos";

            //if (cboFIltro.SelectedIndex == 6 || cboFIltro.SelectedIndex == 7)
            //{
            //    cboPlanta.IsEnabled = true;
            //}
            //else
            //{
            //    cboPlanta.IsEnabled = false;
            //    cboPlanta.SelectedIndex = 0;
            //}

            pbLoad.Visibility = Visibility.Hidden;
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            int opcion = (int)e.Argument;
            GroupedMaterial = new ListCollectionView(daoMat.MaxAndMin(opcion));
            GroupedMaterial.GroupDescriptions.Add(new PropertyGroupDescription("descripcion"));
        }

        private void StartWork(int opcion)
        {
            if (!bgLoad.IsBusy)
            {
                pbLoad.Visibility = Visibility.Visible;
                bgLoad.RunWorkerAsync(opcion);
            }
            
        }

        

        private void cboPlanta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if (cboPlanta.SelectedIndex == 0)
            {
                StartWork(7);
            }
            else
            {
                if (!bgPlantaFilter.IsBusy)
                {
                    pbLoad.Visibility = Visibility.Visible;
                    bgPlantaFilter.RunWorkerAsync(cboPlanta.SelectedIndex);
                }
            }            
        }

        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBusqueda.Text.Trim().Length == 0)
            {
                var busqueda_normal = new Predicate<object>(item =>
                ((MaxAndMin)item).descripcion.ToLower().Contains(
                    this.txtBusqueda.Text.Trim().ToLower()) ||
                        ((MaxAndMin)item).material.Contains(
                            this.txtBusqueda.Text.Trim()));

                lvStock.Items.Filter = busqueda_normal;
                lvStock.Items.Refresh();

                lblCount.Content = lvStock.Items.Count.ToString() + " Elementos";
            }
        }

        private void txtBusqueda_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var busqueda_normal = new Predicate<object>(item =>
                ((MaxAndMin)item).descripcion.ToLower().Contains(
                    this.txtBusqueda.Text.Trim().ToLower()) ||
                        ((MaxAndMin)item).material.Contains(
                            this.txtBusqueda.Text.Trim()));

                lvStock.Items.Filter = busqueda_normal;
                lvStock.Items.Refresh();

                lblCount.Content = lvStock.Items.Count.ToString() + " Elementos";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lvStock.SelectAll();
            lblSeleccionados.Text = "Exportar (" + lvStock.SelectedItems.Count + ")";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lvStock.UnselectAll();
            lblSeleccionados.Text = "Exportar (" + lvStock.SelectedItems.Count + ")";
        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = System.Windows.MessageBox.Show("Exportar (" + lvStock.SelectedItems.Count + ") registros ?", "Confirmación para datos", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                listToExport = lvStock.SelectedItems.Cast<MaxAndMin>().ToList();

                if (!bgExportToExcel.IsBusy)
                {
                    pbLoad.Visibility = Visibility.Visible;
                    lblTextLoad.Content = "Exportando archivo excel...";
                    bgExportToExcel.RunWorkerAsync();
                }
            }
        }

        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                System.Data.DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            lblSeleccionados.Text = "Exportar (" + lvStock.SelectedItems.Count + ")";
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            lblSeleccionados.Text = "Exportar (" + lvStock.SelectedItems.Count + ")";
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
            w.Cells[row, column] = value;
            //(string)(w.Cells[row, column]
            //as Microsoft.Office.Interop.Excel.Range).Value + " " + value;
        }

    }

    public class DeviationParameters
    {
        public decimal superior { get; set; }
        public decimal inferior { get; set; }
        public int aplicacion { get; set; }
    }
}
