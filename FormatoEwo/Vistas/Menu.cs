using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class Menu : MetroForm
    {
        string databaseName = "EwoDatabase.accdb";
        //@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Global.DIRECTORIO_BASEDATOS + @"\EwoDatabase.accdb";
        
        public Menu()
        {
            InitializeComponent();
            ManageFolder();
            //Properties.Settings.Default.EwoDatabaseConnectionString = ""; 
            Console.WriteLine(SomeHelpers.CalculateMD5Hash("prueba"));
            //this.Text = this.Text +" - " + Global.UserLoged.Nombre;
        }

        private void ManageFolder()
        {
            bool exists = System.IO.Directory.Exists(Global.DIRECTORIO);
            
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Global.DIRECTORIO);
                System.IO.Directory.CreateDirectory(Global.DIRECTORIO_BASEDATOS);
                System.IO.Directory.CreateDirectory(Global.DIRECTORIO_IMAGENES);
                System.IO.Directory.CreateDirectory(Global.DIRECTORIO_FORMATOS);
            }

            //COPIAR BASE DE DATOS A DIRECTORIO
            if (!File.Exists(Global.DIRECTORIO_BASEDATOS + @"\" + databaseName))
            {
                string dn = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), databaseName);

                File.Copy(dn, Global.DIRECTORIO_BASEDATOS + @"\" + databaseName);
            }
        }

        private void btnEwo_Click(object sender, EventArgs e)
        {
          
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAcerca_Click(object sender, EventArgs e)
        {
                      
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSmp_Click(object sender, EventArgs e)
        {           
           
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {     
            //if (chkTeclado.Checked)
            //{
            //    Properties.Settings.Default["tecladoPantalla"] = true;
            //}
            //else
            //{
            //    Properties.Settings.Default["tecladoPantalla"] = false;
            //}            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Acerca a = new Acerca();
            a.ShowDialog();
            a.Dispose();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            //Configuraciones con = new Configuraciones();
            FormEwo con = new FormEwo();
            con.ShowDialog();
            con.Dispose();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            Global.Modulo = 2;
            FormLogin login = new FormLogin();
            login.Show();
            //login.Dispose();
            this.SendToBack();
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            Global.Modulo = 1;
            FormLogin login = new FormLogin();            
            login.Show();
            //login.Dispose();
            this.SendToBack();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo en construcción...");
        }

        private void bunifuTileButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Módulo en construcción...");
        }
    }
}
