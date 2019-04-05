using FormatoEwo.DaoEF;
using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class Menu : MetroForm
    {
        string databaseName = "EwoDatabase.accdb";
        //@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Global.DIRECTORIO_BASEDATOS + @"\EwoDatabase.accdb";
        DaoEwo daoE = new DaoEwo();
        DaoSMP daoS = new DaoSMP();
        DaoPlantas daoP = new DaoPlantas();
        DaoLinea daoL = new DaoLinea();
        DaoML daoM = new DaoML();
        DaoRepuestosUtilizados daoR = new DaoRepuestosUtilizados();
        DaoEpps daoEpps = new DaoEpps();
        DaoHerr daoH = new DaoHerr();
        DaoPasoPaso daoPP = new DaoPasoPaso();

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        public Menu()
        {
            InitializeComponent();
            ManageFolder();
            //Properties.Settings.Default.EwoDatabaseConnectionString = ""; 
            Console.WriteLine(SomeHelpers.CalculateMD5Hash("prueba"));
            //this.Text = this.Text +" - " + Global.UserLoged.Nombre;
            //VerifyImages();
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

        private void VerifyImages()
        {
            List<string> images = new List<string>();
            List<string> AllImages = new List<string>();
            //IMAGENES DEL EWO 
            AllImages.AddRange(daoE.GetEwosImagesPath());
            AllImages.AddRange(daoS.GetSmpImagesPath());
            AllImages.AddRange(daoP.GetImagesPath());
            AllImages.AddRange(daoL.GetImagesPath());
            AllImages.AddRange(daoM.GetImagesPath());
            AllImages.AddRange(daoR.GetImagesPath());
            AllImages.AddRange(daoEpps.GetImagesPath());
            AllImages.AddRange(daoH.GetImagesPath());
            AllImages.AddRange(daoPP.GetImagesPath());
            AllImages.Add("environment.png");
            AllImages.Add("quality.png");
            AllImages.Add("safety.png");
            AllImages.Add("productivity.png");

            images = GetRealImages(AllImages).Distinct().OrderBy(x=>x).ToList();

            string[] files = System.IO.Directory.GetFiles(Global.DIRECTORIO_IMAGENES);
            List<string> unusedFiles = new List<string>();

            foreach (var file in files)
            {
                if (images.FirstOrDefault(x=>x == Path.GetFileName(file)) == null)
                {
                    unusedFiles.Add(file);
                }
            }

            //MOVER ARCHIVOS
            foreach (var file in unusedFiles)
            {               
                string target = @"C:\Users\UNILEVER_MTTO\Pictures\Digitools Desktop\" + Path.GetFileName(file);
                File.Move(file, target);
            }           

        }

        private List<string> GetRealImages(List<string> imgs)
        {
            List<string> realImages = new List<string>();
            foreach (var f in imgs)
            {
                if (f != null)
                {
                    if (ImageExtensions.Contains(Path.GetExtension(f).ToUpperInvariant()))
                    {
                        realImages.Add(f);
                    }
                }                
            }

            return realImages;
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
