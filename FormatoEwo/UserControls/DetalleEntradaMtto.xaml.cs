using FormatoEwo.DaoEF;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FormatoEwo.UserControls
{
    /// <summary>
    /// Lógica de interacción para DetalleEntradaMtto.xaml
    /// </summary>
    public partial class DetalleEntradaMtto : UserControl
    {
        DaoCalPM daoCal = new DaoCalPM();
        DaoSMP daoSmp = new DaoSMP();
        BackgroundWorker bgLoad = new BackgroundWorker();
        Splash sc = new Splash();
        CustomSMP csmp;

        Componentes cmp;
        string[] paramss;
        List<CalendarioPm> lc;

        public DetalleEntradaMtto(Componentes com_sel, string[] param_dates)
        {
            InitializeComponent();

            this.cmp = com_sel;
            this.paramss = param_dates;            

            bgLoad.DoWork += BgLoad_DoWork;
            bgLoad.RunWorkerCompleted += BgLoad_RunWorkerCompleted;
        }

        private void BgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string data = "0";

            if (lc.Count == 1)
            {
                foreach (CalendarioPm item in lc)
                {
                    if (item.id_tipo_mtto == 19)
                    {
                        data = "1";
                    }
                    if (item.id_tipo_mtto == 17)
                    {
                        data = "2";
                    }
                    if (item.id_tipo_mtto == 20)
                    {
                        data = "3";
                    }
                    if (item.id_tipo_mtto == 18)
                    {
                        data = "4";
                    }
                }
            }
            if (lc.Count == 2)
            {
                var founded5 = lc.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 19);
                var founded6 = lc.Where(x => x.id_tipo_mtto == 20 || x.id_tipo_mtto == 19);
                var founded7 = lc.Where(x => x.id_tipo_mtto == 18 || x.id_tipo_mtto == 19);
                var founded8 = lc.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 20);
                var founded9 = lc.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 18);
                var founded10 = lc.Where(x => x.id_tipo_mtto == 20 || x.id_tipo_mtto == 18);

                if (founded5.Count() == 2)
                {
                    data = "5";
                }
                if (founded6.Count() == 2)
                {
                    data = "6";
                }
                if (founded7.Count() == 2)
                {
                    data = "7";
                }
                if (founded8.Count() == 2)
                {
                    data = "8";
                }
                if (founded9.Count() == 2)
                {
                    data = "9";
                }
                if (founded10.Count() == 2)
                {
                    data = "10";
                }
            }
            if (lc.Count == 3)
            {
                var founded11 = lc.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 19 || x.id_tipo_mtto == 20);
                var founded12 = lc.Where(x => x.id_tipo_mtto == 17 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 20);
                var founded13 = lc.Where(x => x.id_tipo_mtto == 19 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 20);
                var founded14 = lc.Where(x => x.id_tipo_mtto == 19 || x.id_tipo_mtto == 18 || x.id_tipo_mtto == 17);

                if (founded11.Count() == 3)
                {
                    data = "11";
                }
                if (founded12.Count() == 3)
                {
                    data = "12";
                }
                if (founded13.Count() == 3)
                {
                    data = "13";
                }
                if (founded14.Count() == 3)
                {
                    data = "14";
                }

            }
            if (lc.Count == 4)
            {
                data = "15";
            }
            if (lc.Count == 0)
            {
                data = "0";
            }

            image.Source = SetImage(data);

            txtComp.Text = cmp.descripcion;
            txtWeek.Text = paramss[0];
            txtYear.Text = paramss[1];
            txtSmp.Text = csmp.nombre;
            txtDuracion.Text = csmp.duracion_actividad.ToString() + " Min";
            txtTecnicos.Text = csmp.tecnicos_eq.ToString();

            lvEntries.ItemsSource = lc;

            if (lc.Count > 0)
            {
                lvEntries.Visibility = Visibility.Visible;
                lblNoHay.Visibility = Visibility.Collapsed;
            }
            else
            {
                lvEntries.Visibility = Visibility.Collapsed;
                lblNoHay.Visibility = Visibility.Visible;
            }

            sc.Hide();
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
           lc = daoCal.GetCalendario(cmp.id, int.Parse(paramss[1]), int.Parse(paramss[0]));
           csmp = daoSmp.GetCustomSMP(cmp.id_smp);
        }

        private BitmapImage SetImage(string imageIndex)
        {
            Image finalImage = new Image();
            finalImage.Width = 80;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/FormatoEwo;component/Resources/"+imageIndex+".png");
            logo.EndInit();

            return logo;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                sc.Show();
                bgLoad.RunWorkerAsync();
            }
        }
    }
}
