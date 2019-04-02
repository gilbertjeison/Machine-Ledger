using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        BackgroundWorker bwLogin = new BackgroundWorker();
        tecnicos userObj;
        DaoPersonal daoPer = new DaoPersonal();
        public System.Windows.Forms.Form FormsWindow { get; set; }

        public Login()
        {
            InitializeComponent();
                                   
            bwLogin.DoWork += new DoWorkEventHandler(LoginWork);
            bwLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoginComplete);
            bwLogin.WorkerSupportsCancellation = false;
        }

        private void LoginComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            tecnicos usCompl = (tecnicos)e.Result;
            if (usCompl.Id > 0)
            {
                Global.UserLoged = usCompl;


                switch (Global.Modulo)
                {
                    case 1:
                        Vistas.SubMenu menu = new Vistas.SubMenu();
                        menu.Show();
                        menu.BringToFront();
                        break;
                    case 2:
                        Vistas.FormSop sop = new Vistas.FormSop();
                        sop.Show();
                        sop.BringToFront();
                        break;
                    default:
                        break;
                }
                              

                this.FormsWindow.Close();
                GC.Collect();
            }
            else
            {
                MessageBox.Show(
                    "Error al iniciar sesión, usuario no reconocido!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

            EnabledComponents(true);
            this.PBarLogin.Visibility = System.Windows.Visibility.Hidden;
        }

        private void LoginWork(object sender, DoWorkEventArgs e)
        {
            tecnicos objLong = (tecnicos)e.Argument;
            int pilar = 0;
            if (Global.Modulo == 1)
            {
                pilar = 101;
            }
            if (Global.Modulo == 2)
            {
                pilar = 102;
            }

            userObj = daoPer.LoginUser(objLong,pilar);
            e.Result = userObj;
        }

        private void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.txtNombreUser.Text.Length > 0)
                {
                    if (this.txtPassUser.Password.Length > 0)
                    {
                        this.PBarLogin.Visibility = System.Windows.Visibility.Visible;
                        EnabledComponents(false);
                        tecnicos login = new tecnicos()
                        {
                            usuario = txtNombreUser.Text.ToString().Trim(),
                            password = txtPassUser.Password.ToString().Trim()
                        };

                        //Comienza el worker
                        bwLogin.RunWorkerAsync(login);
                    }
                    else
                    {
                        MessageBox.Show("Escriba Password", "Login");
                        this.txtPassUser.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en inicio de sesión: " + ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtNombreUser.Focus();           
        }

        private void EnabledComponents(bool ena)
        {
            this.txtNombreUser.IsEnabled = ena;
            this.txtPassUser.IsEnabled = ena;
            this.chkRecordarUser.IsEnabled = ena;
            this.lblRecordar.IsEnabled = ena;
            this.BtnIniciar.IsEnabled = ena;
        }

        private void UserRoutine()
        {
            List<tecnicos> listTec = daoPer.ConsultarTecnicosComboBox();
            foreach (var item in listTec)
            {
                string n_clean = Util.SomeHelpers.RemoveDiacritics(item.Nombre.ToLower());
                string user = n_clean.Split(' ')[0].Substring(0, 3) + n_clean.Split(' ')[1].Substring(0, 3);
                string pass = Util.SomeHelpers.CalculateMD5Hash(n_clean.Split(' ')[1]);
                int rol = 1;

                daoPer.EditTecnico(new tecnicos()
                {
                    Id = item.Id,
                    usuario = user,
                    password = pass                 
                    
                });
                Console.WriteLine(user + "---" + pass);
            }
        }
    }
}
