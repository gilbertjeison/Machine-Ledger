using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using FormatoEwo.Util;
using FormatoEwo.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace FormatoEwo.UserControls
{
    /// <summary>
    /// Lógica de interacción para Lineas.xaml
    /// </summary>
    public partial class Lineas : UserControl
    {
        //BACKGROUNDWORKERS PARA OPERACIONES 2DO PLANO
        BackgroundWorker bgLoad = new BackgroundWorker();
        BackgroundWorker bgLine = new BackgroundWorker();

        //SPLAS QUE SE MUESTRA MIENTRA SE REALIZA UNA TRANSACCIÓN
        Splash splash = new Splash();
        //OBJETO PARA ACCEDER A LAS TRANSACCIONES DE BASE DE DATOS
        DaoLinea daoLin = new DaoLinea();
        DaoPlantas daoPla = new DaoPlantas();
        //LISTAS PARA ALMACENAR INFORMACIÓN CONSULTADA DE LA BASE DE DATOS
        List<CustomLineas> list = new List<CustomLineas>();
        List<plantas> listPla = new List<plantas>();
        //OBJETO PARA IDENTIFICAR LA PLANTA SELECCIONADA
        Plantas planta;
        //OBJETO PARA IDENTIFICAR EL OBJETO (LÍNEA) SELECCIOANDO
        CustomLineas cl;
        //TIMER PARA ACTUALIZAR LA HORA CADA SEGUNDO
        Timer t = new Timer();
        //STRING DONDE SE ALMACENA LA RUTA DE LA IMAGEN DE LA LÍNEA SELECCIONADA
        string image = "";
        //VARIABLE DONDE SE ALMACENA EL ID DE LA LÍNEA QUE SE ESTÁ EDITANDO O ELIMINANDO
        private int id_edit;

        
        public System.Windows.Forms.Form FormsWindow { get; set; }

        public Lineas(Plantas planta)
        {
            InitializeComponent();

            this.planta = planta;
            //BG CARGA INICIAL
            bgLoad.DoWork += BgLoad_DoWork;
            bgLoad.RunWorkerCompleted += BgLoad_RunWorkerCompleted;

            //BG EDITAR LINEA
            bgLine.DoWork += BgLine_DoWork;
            bgLine.RunWorkerCompleted += BgLine_RunWorkerCompleted;

            //TIMER DE HORA
            t.Elapsed += T_Elapsed;
        }

        private void BgLine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //SI RETORNA UN RESULTADO, LA TRANSACCIÓN FUE VÁLIDA
            if (((int)e.Result) > 0)
            {
                MessageBox.Show("Operación realizada correctamente!");
                //LIMPIAR CONTROLES PARA NUEVA MÁQUINA
                ClearControls();
                //RECARGAR INFORMACIÓN DE LA BASE DE DATOS
                if (!bgLoad.IsBusy)
                {
                    bgLoad.RunWorkerAsync();
                }               
            }

            //RESETEAR LINEA SELECCIONADA
            Global.selected_line = new CustomLineas() { id = 0 };
            //ESCONDER SPLASH 'CARGANDO'
            splash.Hide();
        }

        private void BgLine_DoWork(object sender, DoWorkEventArgs e)
        {           
            if (e.Argument != null)
            {
                lineas lineToOper = (lineas)e.Argument;

                if (lineToOper.id == 0)
                {
                    //AGREGAR
                    e.Result = daoLin.AddLine((lineas)e.Argument);
                }
                else
                {
                    //EDITAR
                    e.Result = daoLin.EditLinea((lineas)e.Argument);
                    
                }                
            }
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                txtDate.Text = DateTime.Now.ToLongDateString().ToUpper() +" "+ DateTime.Now.ToLongTimeString().ToUpper();
            });
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtPlanta.Text = planta.nombre.ToUpper();
            txtCantLineas.Content = list.Count.ToString();
            cboPlantas.ItemsSource = listPla;
            txtUser.Text = Global.UserLoged.Nombre;
            EnableControls(false);

            t.Start();            
            splash.Hide();
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                listPla = daoPla.GetPlants();
                list = daoLin.GetLines(planta.id);
                lbLineas.ItemsSource = list;
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
        }                      

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            object linkDataContext = (sender as Hyperlink).DataContext;

            ListBoxItem lbi = (ListBoxItem)
                lbLineas.ItemContainerGenerator.ContainerFromItem(linkDataContext);

            lbi.IsSelected = true;

            if (lbLineas.SelectedItems.Count > 0)
            {
                cl = lbLineas.SelectedItem as CustomLineas;

                //CARAGAR INFORMACIÓN EN CAMPOS PARA EDITAR
                id_edit = cl.id;
                txtNombre.Text = cl.nombre;
                cboPlantas.SelectedValue = cl.id_planta;
                pbImage.Source = cl.image;
                image = Global.DIRECTORIO_IMAGENES + @"\" + cl.image_path;

                btnCrearLinea.Tag = "1";
                txtBtnOp.Text = "Guardar edición";

                EnableControls(true);
            }
        }

        private void EnableControls(bool value)
        {
            lblPlanta.IsEnabled = value;
            cboPlantas.IsEnabled = value;
            lblNombre.IsEnabled = value;
            txtNombre.IsEnabled = value;
            lblImagen.IsEnabled = value;
            pbImage.IsEnabled = value;
        }

        private void ClearControls()
        {            
            cboPlantas.Text = "";            
            txtNombre.Text = "";           
            pbImage.Source = new BitmapImage(new Uri(Global.DIRECTORIO_IMAGENES + @"\" + "placeholder.png"));

            btnCrearLinea.Tag = "0";
            txtBtnOp.Text = "Crear nueva línea";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (image.Length > 0)
            {
                VisorImagenes vi = new VisorImagenes(true);
                vi.imgShow = image; // Global.DIRECTORIO_IMAGENES + @"\" + cl.image_path;
                vi.ShowDialog();
                vi.Dispose();
            }           
        }
        
        private void pbImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {           
            image = SomeHelpers.CargarImagenXaml();

            if (!image.Equals(""))
            {
                pbImage.Source = new BitmapImage(new Uri(image));
            }            
        }

        private void btnCrearLinea_Click(object sender, RoutedEventArgs e)
        {
            try
            {                            
                string tag = btnCrearLinea.Tag.ToString();

                switch (tag)
                {
                    case "0":
                        EnableControls(true);

                        btnCrearLinea.Tag = "2";
                        txtBtnOp.Text = "Guardar línea";
                        
                        break;
                
                    //PREPARAR CONTROLES PARA NUEVO REGISTRO
                    case "1":

                        //GUARDAR EDICIÓN
                        if (cboPlantas.Text.Length > 0)
                        {
                            if (txtNombre.Text.Trim().Length > 0)
                            {
                                if (image.Length > 0)
                                {
                                    lineas l = new lineas();
                                    l.id = id_edit;
                                    l.id_planta = int.Parse(cboPlantas.SelectedValue.ToString());
                                    l.nombre = txtNombre.Text.Trim();
                                    l.image_path = Path.GetFileName(image);

                                    if (!bgLine.IsBusy)
                                    {
                                        splash.Show();
                                        bgLine.RunWorkerAsync(l);
                                    }                               
                                }
                                else
                                {
                                    MessageBox.Show("Por favor seleccione una imágen válida!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor escribir nombre!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor seleccione planta!");
                        }
                                            
                        break;

                    case "2":                      
                        //GUARDAR NUEVA LÍNEA
                        if (cboPlantas.Text.Length > 0)
                        {
                            if (txtNombre.Text.Trim().Length > 0)
                            {
                                if (image.Length > 0)
                                {
                                    lineas l = new lineas();                                   
                                    l.id_planta = int.Parse(cboPlantas.SelectedValue.ToString());
                                    l.nombre = txtNombre.Text.Trim();
                                    l.image_path = Path.GetFileName(image);

                                    if (!bgLine.IsBusy)
                                    {
                                        splash.Show();
                                        bgLine.RunWorkerAsync(l);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor seleccione una imágen válida!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor escribir nombre!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor seleccione planta!");
                        }
                        EnableControls(false);
                        ClearControls();

                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar transacción. " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            //LIMPIAR LOS CONTROLES Y PREPARAR PARA UN NUEVO REGISTRO
            ClearControls();
            EnableControls(false);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busqueda_normal = new Predicate<object>(item =>
                ((CustomLineas)item).nombre.ToString().ToUpper().Contains(
                    this.txtSearch.Text.ToUpper()));
            this.lbLineas.Items.Filter = busqueda_normal;
            this.lbLineas.Items.Refresh();

            txtCantLineas.Content = lbLineas.Items.Count.ToString();
        }

        private void lbLineas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbLineas.SelectedItems.Count == 1)
            {
                btnExplorar.Visibility = Visibility.Visible;
                CustomLineas cls = (CustomLineas)lbLineas.SelectedItems[0];
                lblLine.Text = "["+cls.nombre.ToUpper()+"]";
            }
            else if (lbLineas.SelectedItems.Count == 0)
            {
                btnExplorar.Visibility = Visibility.Hidden;
            }
        }

        private void btnExplorar_Click(object sender, RoutedEventArgs e)
        {
            //CARGAR LISTADO DE MÁQUINAS CORRSPONDIENTES A LA LÍNEA SELECCIONADA           
            Global.selected_line = (CustomLineas)lbLineas.SelectedItems[0];

            this.FormsWindow.DialogResult = System.Windows.Forms.DialogResult.OK;
            GC.Collect();

        }
    }
}
