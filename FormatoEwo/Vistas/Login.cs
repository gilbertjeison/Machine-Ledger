using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using FormatoEwo.SubViews;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class Login : MetroForm
    {
        DaoPersonal daoPer = new DaoPersonal();
        Splash splash = new Splash();
        tecnicos userObj;

        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUser.Text.Length > 0)
                {
                    if (this.txtPass.Text.Length > 0)
                    {
                        splash.Show();
                        enabledComponents(false);
                        tecnicos login = new tecnicos()
                        {
                            usuario = txtUser.Text.ToString().Trim(),
                            password = txtPass.Text.ToString().Trim()
                        };
                        //Comienza el worker
                        bgLoadSession.RunWorkerAsync(login);
                    }
                    else
                    {
                        MessageBox.Show("Escriba Password", "Login");
                        this.txtPass.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en inicio de sesión: " + ex.Message);
            }
        }

        private void bgLoadSession_DoWork(object sender, DoWorkEventArgs e)
        {
            tecnicos objLong = (tecnicos)e.Argument;
            userObj = daoPer.LoginUser(objLong);
            e.Result = userObj;
        }

        private void bgLoadSession_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //tecnicos usCompl = (tecnicos)e.Result;
            //if (usCompl.Id > 0)
            //{
            //    (App.Current as App).user = usCompl;

            //    if (daoTer.ConsultarTerminal().PKTERMINAL != 0)
            //    {
            //        if (this.chkRecordarUser.IsChecked == true)
            //        {
            //            Properties.Settings.Default.user = usCompl.CHLOGIN;
            //            Properties.Settings.Default.pass = usCompl.CHPASS;
            //            Properties.Settings.Default.userSet = true;
            //            Properties.Settings.Default.Save();
            //        }

                    
            //        (App.Current as App).terminal = daoTer.ConsultarTerminal();
            //        //REGISTRAR INICIO DE SESIÓN
            //        (App.Current as App).id_login = daoSes.LogIn((App.Current as App).terminal.PKTERMINAL, usCompl.PKUSUARIO);
            //        //CAMBIAR ESTADO A TERMINAL
            //        daoTer.UpdateTerminal((decimal)(App.Current as App).terminal.PKTERMINAL, 2);//ARRANQUE
            //        Principal obj_ubicaciones = new Principal();
            //        obj_ubicaciones.Show();
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show(
            //                        "La terminal actual no  esta registrada, por favor contacte con el administrador de la aplicación,\nNombre del equipo: " + Environment.MachineName,
            //                        "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(
            //        "Error al iniciar sesión, asesor no registrado",
            //        "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            //}

            //enabledComponents(true);
            //this.PBarLogin.Visibility = System.Windows.Visibility.Hidden;
        }

        private void enabledComponents(bool ena)
        {
            this.txtUser.Enabled = ena;
            this.txtPass.Enabled = ena;          
            this.btnIniciar.Enabled = ena;
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

                daoPer.EditTecnico(new tecnicos() {Id = item.Id,usuario = user, password = pass,activo = rol, id_rol = rol
                });
                Console.WriteLine(user+"---"+pass);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            int nGCD = GetGreatestCommonDivisor(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
            string str = string.Format("{0}:{1}", Screen.PrimaryScreen.Bounds.Height / nGCD, Screen.PrimaryScreen.Bounds.Width / nGCD);
            MessageBox.Show(str);
        }

        static int GetGreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
        }
    }
}
