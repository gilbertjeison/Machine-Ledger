using FormatoEwo.Dao;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;

using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using FormatoEwo.DaoEF;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using FormatoEwo.Util;
using FormatoEwo.Database;
using System.Windows.Input;
            

namespace FormatoEwo.UserControls
{
    /// <summary>
    /// Lógica de interacción para ComponentesCPM.xaml
    /// </summary>
    public partial class ComponentesCPM : UserControl
    {
        BackgroundWorker bgLoad = new BackgroundWorker();
        BackgroundWorker bgLoadSmp = new BackgroundWorker();
        DaoML daoML = new DaoML();
        DaoCalPM daoCal = new DaoCalPM();
        DaoSMP daoSMP = new DaoSMP();
        List<Componentes> listComp = new List<Componentes>();        
        PropertyValueStringConverter pvsc = new PropertyValueStringConverter();
        ImageConverter ic = new ImageConverter();
        Splash splash = new Splash();      
        SmpHandler sHan = new SmpHandler();

        public ComponentesCPM()
        {
            InitializeComponent();

            //BG INICIAL
            bgLoad.DoWork += BgLoad_DoWork;
            bgLoad.RunWorkerCompleted += BgLoad_RunWorkerCompleted;

            //BG INICIAL
            bgLoadSmp.DoWork += BgLoadSmp_DoWork; ;
            bgLoadSmp.RunWorkerCompleted += BgLoadSmp_RunWorkerCompleted; ;
        }

        private void BgLoadSmp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splash.Hide();
        }

        private void BgLoadSmp_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //VERIFICAR LA EXISTENCIA DEL ARCHIVO EXCEL EN LA BD

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar SMP "+ex.ToString());;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cboYear.ItemsSource = daoCal.GetDistinctYear().Count == 0 ? 
                new List<int>() { DateTime.Now.Year } : 
                    daoCal.GetDistinctYear();

            cboYear.SelectedIndex = 0;

            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }

            cboYear.SelectionChanged += CboYear_SelectionChanged;
            //il.Images.Add()
        }

        private void CboYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoad.Visibility = Visibility.Hidden;
            lblInfo.Content = listComp.Count+" componente(s)";
            lvCalendar.IsEnabled = true;
            
            splash.Hide();
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                listComp = daoML.GetComponentes(Util.Global.conjunto.id,int.Parse(cboYear.Text));
                
                lvCalendar.ItemsSource = listComp;

                for (int i = lvCalendar.Columns.Count - 2; i > 0; i--)
                {
                    if (lvCalendar.Columns[i].Width  != 429)
                    {
                        lvCalendar.Columns.RemoveAt(i);
                    }
                }
                if (lvCalendar.Columns.Count > 1)
                {
                    lvCalendar.Columns.RemoveAt(1);
                }

                for (int i = 1; i < 53; i++)
                {
                    //COLUMNA HEADER
                    DataTemplate dt = new DataTemplate();

                    FrameworkElementFactory tb = (new FrameworkElementFactory(typeof(TextBlock)));
                    tb.SetValue(TextBlock.TextProperty, "Week "+(i)+" "+ cboYear.Text);                   
                    dt.VisualTree = tb;

                    DataGridTemplateColumn dtc = new DataGridTemplateColumn();
                    dtc = CreateEntry(i, cboYear.Text);

                    dtc.HeaderTemplate = dt;
                    dtc.Width = 85;

                    lvCalendar.Columns.Add(dtc);
                }
            });           
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        static DateTime FirstDateOfWeek(int year, int weekNum, CalendarWeekRule rule)
        {
            Debug.Assert(weekNum >= 1);

            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);
            Debug.Assert(firstMonday.DayOfWeek == DayOfWeek.Monday);

            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstMonday, rule, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            DateTime result = firstMonday.AddDays(weekNum * 7);

            return result;
        }

        private DataGridTemplateColumn CreateEntry(int week, string aa)
        {
            //COLUMNA CONTENT
            DataTemplate dt_con = new DataTemplate();
            DataGridTemplateColumn dtc = new DataGridTemplateColumn();            
            Binding b = new Binding("mttos");
            Binding b1 = new Binding("mttos");
            b1.Converter = ic;
            b.Converter = pvsc;

            int[] param_dates = new int[2] {week, int.Parse(aa) };

            b.ConverterParameter = param_dates;
            b1.ConverterParameter = param_dates;

            FrameworkElementFactory stack = new FrameworkElementFactory(typeof(StackPanel));
            stack.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            stack.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);
            

            FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
            image.SetValue(MarginProperty, new Thickness(0, 0, 0, 20));
            image.SetBinding(Image.SourceProperty, b1);
            image.SetValue(Image.HeightProperty, 70.0);
            image.SetValue(Image.WidthProperty, 70.0);
            image.SetValue(Image.TagProperty, week+"-"+int.Parse(aa));
            image.AddHandler(Image.MouseDownEvent, new MouseButtonEventHandler(ImageClick));

            FrameworkElementFactory tAver = new FrameworkElementFactory(typeof(TextBox));
            tAver.SetValue(ToolTipProperty, "Información de mantenimiento...");
            tAver.SetBinding(TextBox.TextProperty, b);
            tAver.SetValue(TextBox.IsReadOnlyProperty, true);           
            tAver.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            tAver.SetValue(TextBox.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            tAver.SetValue(TextBox.HeightProperty, 110.0);

            stack.AppendChild(image);
            stack.AppendChild(tAver);
            dt_con.VisualTree = stack;
            dtc.CellTemplate = dt_con;
            
            return dtc;
        }

        private void ImageClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Componentes com_sel = ((FrameworkElement)sender).DataContext as Componentes;
                 
                string[] param_dates = ((Image)sender).Tag.ToString().Split('-');
                                
                Vistas.FormDetalleEntrada fde = new Vistas.FormDetalleEntrada(com_sel, param_dates);
                fde.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NuevoComponente nvc = new NuevoComponente(null);
            nvc.ShowDialog();

            if (!bgLoad.IsBusy)
            {
                bgLoad.RunWorkerAsync();
            }

            nvc.Dispose();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                pbLoad.Visibility = Visibility.Visible;
                lvCalendar.IsEnabled = false;

                Componentes com_sel = (Componentes)lvCalendar.SelectedItem;               
                NuevoComponente nc = new NuevoComponente(com_sel);
                nc.ShowDialog();

                if (nc.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (!bgLoad.IsBusy)
                    {
                        bgLoad.RunWorkerAsync();
                    }
                }
                else
                {
                    pbLoad.Visibility = Visibility.Hidden;
                    lvCalendar.IsEnabled = true;
                }

                nc.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item inválido, "+ ex.Message.ToLower());
            }           
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txtBuscar.Text.Equals("Buscar componente..."))
            {
                var busqueda_normal = new Predicate<object>(item =>
                ((Componentes)item).descripcion.ToLower().Contains(
                    this.txtBuscar.Text.Trim().ToLower()));

                lvCalendar.Items.Filter = busqueda_normal;

                lvCalendar.Items.Refresh();

                lblInfo.Content = (lvCalendar.Items.Count - 1).ToString() + " componente(s)";
            }
        }

        private void txtBuscar_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void txtBuscar_LostFocus(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = "Buscar componente..."; 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                pbLoad.Visibility = Visibility.Visible;

                Componentes com_sel = (Componentes)lvCalendar.SelectedItem;
                NuevaEntradaMtto nem = new NuevaEntradaMtto(com_sel);
                nem.ShowDialog();

                if (!bgLoad.IsBusy)
                {
                    bgLoad.RunWorkerAsync();
                }                

                nem.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item inválido, " + ex.Message.ToLower());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                pbLoad.Visibility = Visibility.Visible;
                Componentes com_sel = (Componentes)lvCalendar.SelectedItem;

                MessageBoxResult res = MessageBox.Show("Desea eliminar a " + com_sel.descripcion + "? posiblemente lo esté usando otro proceso",
                "Eliminar componente", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (res == MessageBoxResult.Yes)
                {
                    daoML.DeleteComponente(new Database.componentes() { Id = com_sel.id });

                    if (!bgLoad.IsBusy)
                    {
                        bgLoad.RunWorkerAsync();
                    }
                    else
                    {
                        pbLoad.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    pbLoad.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item inválido, " + ex.Message.ToLower());
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            sHan.GenerateSmp((lvCalendar.SelectedItem as Componentes).id_smp);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pbLoad.Visibility = Visibility.Visible;
                Componentes com_sel = (Componentes)lvCalendar.SelectedItem;

                MessageBoxResult res = MessageBox.Show("Desea duplicar " + com_sel.descripcion + "? se copiarán todas las propiedades pero no las entradas de mantenimiento",
                "Duplicar componente", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (res == MessageBoxResult.Yes)
                {
                    daoML.AddComponente(com_sel);

                    if (!bgLoad.IsBusy)
                    {
                        bgLoad.RunWorkerAsync();
                    }
                    else
                    {
                        pbLoad.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    pbLoad.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item inválido, " + ex.Message.ToLower());
            }
        }
    }
    public class PropertyValueStringConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int[] param = (int[])parameter;

            //CAPTURAR PARAMETRO DE LA SEMANA Y AÑO
            int semana = param[0];
            int year = param[1];

            //CAPTURAR LISTA DE MANTENIMIENTO DE CADA COMPONENTE
            List<CalendarioPm> list = (List<CalendarioPm>)value;
            //FILTRAR DE LA LISTA SOLO LOS QUE CORRESPONDEN A LA FECHA PARAMETRIZADA
            var listFil = list.Where(x => x.semana == semana).ToList();

            string data = "";
            if (listFil.Count > 0)
            {
                foreach (var item in listFil)                
                {
                    data += "Mtto: " + item.desc + "\n" +
                            "# EWO: " + item.id_ewo + "\n" +
                           "DURACIÓN (MIN): " + item.duracion_total + "\n" +
                           "CANTIDAD: " + item.cantidad + "\n"+
                           "Obs: " + item.observaciones + "\n"
                           + "------------------\n";
                }
            }
            else
            {
                data = "SIN MTTO";
            }

            return data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.Forms.MessageBox.Show("Test");

            return null;
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int[] param = (int[])parameter;

            //CAPTURAR PARAMETRO DE LA SEMANA Y AÑO
            int semana = param[0];
            int year = param[1];

            //CAPTURAR LISTA DE MANTENIMIENTO DE CADA COMPONENTE
            List<CalendarioPm> list = (List<CalendarioPm>)value;
            //FILTRAR DE LA LISTA SOLO LOS QUE CORRESPONDEN A LA FECHA PARAMETRIZADA
            var listFil = list.Where(x => x.semana == semana).ToList();

            string data = "";

            if (listFil.Count == 1)
            {    
                foreach (CalendarioPm item in listFil)
                {
                    if (item.id_tipo_mtto == 19)
                    {
                        data = "pack://application:,,,/FormatoEwo;component/Resources/1.png";
                    }
                    if (item.id_tipo_mtto == 17)
                    {
                        data = "pack://application:,,,/FormatoEwo;component/Resources/2.png";
                    }
                    if (item.id_tipo_mtto == 20)
                    {
                        data = "pack://application:,,,/FormatoEwo;component/Resources/3.png";
                    }
                    if (item.id_tipo_mtto == 18)
                    {
                        data = "pack://application:,,,/FormatoEwo;component/Resources/4.png";
                    }                                                                     
                }
            }
            if (listFil.Count == 2)
            {
                var founded5 = listFil.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 19);
                var founded6 = listFil.Where(x => x.id_tipo_mtto == 20 || x.id_tipo_mtto == 19);
                var founded7 = listFil.Where(x => x.id_tipo_mtto == 18 || x.id_tipo_mtto == 19);
                var founded8 = listFil.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 20);
                var founded9 = listFil.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 18);
                var founded10 = listFil.Where(x => x.id_tipo_mtto == 20 || x.id_tipo_mtto == 18);

                if (founded5.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/5.png";
                }
                if (founded6.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/6.png";
                }
                if (founded7.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/7.png";
                }
                if (founded8.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/8.png";
                }
                if (founded9.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/9.png";
                }
                if (founded10.Count() == 2)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/10.png";
                }                
            }
            if (listFil.Count == 3)
            {
                var founded11 = listFil.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 19 || x.id_tipo_mtto == 20);
                var founded12 = listFil.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 20);
                var founded13 = listFil.Where(x => x.id_tipo_mtto == 19 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 20);
                var founded14 = listFil.Where(x => x.id_tipo_mtto == 19 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 17);

                if (founded11.Count() == 3)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/11.png";
                }
                if (founded12.Count() == 3)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/12.png";
                }
                if (founded13.Count() == 3)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/13.png";
                }
                if (founded14.Count() == 3)
                {
                    data = "pack://application:,,,/FormatoEwo;component/Resources/14.png";
                }
                
            }
            if (listFil.Count == 4)
            {
                data = "pack://application:,,,/FormatoEwo;component/Resources/15.png";
            }
            if (listFil.Count == 0)
            {
                data = "pack://application:,,,/FormatoEwo;component/Resources/0.png";
            }

            return data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.Forms.MessageBox.Show("Test");

            return null;
        }
    }
}
