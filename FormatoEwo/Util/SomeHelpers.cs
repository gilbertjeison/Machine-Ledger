using System;
using System.Collections.Generic;
using FormatoEwo.Objetos;
using System.Net;
using System.IO;
using System.Drawing;
using FormatoEwo.Vistas;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using FormatoEwo.Dao;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Reflection;
using FormatoEwo.Database;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace FormatoEwo.Util
{
    class SomeHelpers
    {
        public static DaoAreaLinea daoAL = new DaoAreaLinea();
        public static DaoEquipo daoEq = new DaoEquipo();
        public static DaoTecnicos daoTec = new DaoTecnicos();
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        string data = "";
        Bitmap bmp;
        int i = 0;

        public SomeHelpers()
        {
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
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
                                //imageList1.Images.Add(urlUn, bmp);
                                //lvImagenes.Items.Add(urlUn, "", i);
                                i++;
                            }
                        }
                    }
                }
                catch (Exception we)
                {
                    Console.WriteLine("Error en imagen # " + i + ", " + we.ToString());
                }
                if (i == 1) { break; }
            }

            //lblCantidadImagenes.Text = lvImagenes.Items.Count.ToString();
            //lblInfo.Visible = false;
            //timer1.Stop();
            //timer1.Dispose();
            //pbCargando.Visible = false;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.BeginInvoke((Action)(() =>
            //{
                data = GetHtmlCode(e.Argument.ToString());
            //}), null);
        }

        private string GetHtmlCode(string elemento)
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

        public static Image GetImageFromPicPath(string strUrl)
        {
            using (WebResponse wrFileResponse = WebRequest.Create(strUrl).GetResponse())
            using (Stream objWebStream = wrFileResponse.GetResponseStream())
            {
                MemoryStream ms = new MemoryStream();
                objWebStream.CopyTo(ms, 8192);
                return System.Drawing.Image.FromStream(ms);
            }
        }

        public static void FillMultiCombo(PresentationControls.CheckBoxComboBox ccbo, List<tecnicos> lista)
        {
            ccbo.DataSource = new
                    PresentationControls.ListSelectionWrapper<tecnicos>
                (
                    lista,
                    "Nombre"
                );

            ccbo.DisplayMemberSingleItem = "Name";
            ccbo.DisplayMember = "NameConcatenated";
            ccbo.ValueMember = "Selected";
        }

        public static Bitmap GetImageFromUrl(string url)
        {
            try
            {
                var webClient = new WebClientMia();
                webClient.Headers.Add("User-Agent: Other");
                webClient.Timeout = 4000;
                byte[] imageBytes = webClient.DownloadData(url);
                webClient.Dispose();
                using (var ms = new MemoryStream(imageBytes))
                {
                    return new Bitmap(ms);
                }

            }
            catch (WebException we)
            {
                Console.WriteLine(we.ToString());
            }
            return null;
        }

        public static void AddImageExcel(Worksheet ws2, string image,float left, float top, float width, float height )
        {
            if (!image.Equals(""))
            {
                try
                {
                    if (File.Exists(image))
                    {
                        ws2.Shapes.AddPicture(image, MsoTriState.msoFalse,
                        MsoTriState.msoCTrue, left, top, width, height);
                    }
                    else
                    {
                        string ruta_destino = Global.DIRECTORIO_IMAGENES + @"\" + "phaf.JPG";
                        
                        if (!File.Exists(ruta_destino))
                        {
                            Properties.Resources.hpc_logo.Save(ruta_destino);
                        }

                        ws2.Shapes.AddPicture(ruta_destino, MsoTriState.msoFalse,
                        MsoTriState.msoCTrue, left, top, width, height);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en tiempo de ejecución: "+ex.ToString());
                }               
            }
        }

        public static void AddImageExcelFromWeb(Worksheet ws2, string image, float left, float top, float width, float height, string complete_path)
        {
            if (!image.Equals(""))
            {
                try
                {
                    if (File.Exists(image))
                    {
                        ws2.Shapes.AddPicture(image, MsoTriState.msoFalse,
                        MsoTriState.msoCTrue, left, top, width, height);
                    }
                    else
                    {                        
                        DownloadImageUrl(complete_path);

                        if (File.Exists(image))
                        {
                            ws2.Shapes.AddPicture(image, MsoTriState.msoFalse,
                            MsoTriState.msoCTrue, left, top, width, height);
                        }
                        else
                        {
                            string ruta_destino = Global.DIRECTORIO_IMAGENES + @"\" + "phaf.JPG";

                            if (!File.Exists(ruta_destino))
                            {
                                Properties.Resources.hpc_logo.Save(ruta_destino);
                            }

                            ws2.Shapes.AddPicture(ruta_destino, MsoTriState.msoFalse,
                            MsoTriState.msoCTrue, left, top, width, height);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en tiempo de ejecución: " + ex.ToString());
                }
            }
        }

        public static void ImageManager(string img, ToolStripItemClickedEventArgs e, List<ToolStripMenuItem> it, bool ispath, PictureBox pb)
        {
            if (!img.Equals(""))
            {
                ToolStripItem tsmi = e.ClickedItem;
                if (tsmi == it[0])
                {
                    //VISOR IMAGEN
                    VisorImagenes vi = new VisorImagenes(ispath);
                    vi.imgShow = img;
                    vi.ShowDialog();
                    vi.Dispose();
                }
                if (tsmi == it[1])
                {
                    //ELIMINAR IMAGEN                    
                    pb.Image = Properties.Resources.placeholder;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Primero cargue una imágen!");
            }
        }

        public static string CargarImagenXaml()
        {
            //BitmapImage bi = null;
            string image = "";
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                {
                    dlg.Title = "Abrir imagen";
                    dlg.Filter = "Imágenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dlg.ShowDialog() == true)
                    {
                        string ruta_origen = dlg.FileName;

                        string ruta_destino = Global.DIRECTORIO_IMAGENES + @"\" + dlg.SafeFileName;

                        Bitmap bm = new Bitmap(ruta_origen);
                        //bi = new BitmapImage(new Uri(dlg.FileName));

                        if (!File.Exists(ruta_destino))
                        {
                            //File.Copy(dlg.FileName, ruta_destino);
                            SaveJpeg(ruta_destino, bm, 50);
                        }
                        else
                        {
                            if (!FileCompare(ruta_origen, ruta_destino))
                            {
                                int counter = 0;
                                string filenameNoPath = Path.GetFileNameWithoutExtension(ruta_destino);
                                string temppath = Path.GetDirectoryName(ruta_destino);
                                string extension = Path.GetExtension(ruta_destino);
                                string path = "";

                                do
                                {
                                    counter++; // we're here, so lets count files with same name
                                    path = temppath + "\\" + filenameNoPath + "(" + counter.ToString() + ")" + extension;
                                } while (File.Exists(path));

                                ruta_destino = path;

                                //File.Copy(dlg.FileName, path);
                                SaveJpeg(path, bm, 50);
                            }
                        }

                        image = ruta_destino;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imágen no válida!" + ex.ToString());
            }

            return image;
        }

        public static string CargarImagenPictureBox(PictureBox pb)
        {           
            string image = "";
            try
            {                            
                using (System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog())
                {
                    dlg.Title = "Abrir imagen";
                    dlg.Filter = "Imágenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string ruta_origen = dlg.FileName;

                        string ruta_destino = Global.DIRECTORIO_IMAGENES + @"\" + dlg.SafeFileName;

                        Bitmap bm = new Bitmap(ruta_origen);
                        pb.Image = bm;

                        if (!File.Exists(ruta_destino))
                        {
                            //File.Copy(dlg.FileName, ruta_destino);
                            SaveJpeg(ruta_destino, bm, 50);
                        }
                        else
                        {
                            if (!FileCompare(ruta_origen, ruta_destino))
                            {                                
                                int counter = 0;
                                string filenameNoPath = Path.GetFileNameWithoutExtension(ruta_destino);
                                string temppath = Path.GetDirectoryName(ruta_destino);
                                string extension = Path.GetExtension(ruta_destino);
                                string path = "";

                                do
                                {
                                    counter++; // we're here, so lets count files with same name
                                    path = temppath + "\\" + filenameNoPath + "(" + counter.ToString() + ")" + extension;
                                } while (File.Exists(path));

                                ruta_destino = path;

                                //File.Copy(dlg.FileName, path);
                                SaveJpeg(path, bm, 50);
                            }                            
                        }
                    
                        image = ruta_destino;
                        dlg.Dispose();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Imágen no válida!");
            }

            return image;
        }

        public static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        public static void CopyImageToServer(System.Windows.Forms.OpenFileDialog dlg)
        {
            //VERIFICAR SI LA IMÁGEN EXISTE EN LA RUTA DE IMAGENES
            string ruta_origen = dlg.FileName;

            string ruta_destino = Global.DIRECTORIO_IMAGENES + @"\" + dlg.SafeFileName;

            if (!File.Exists(ruta_destino))
            {
                File.Copy(dlg.FileName, ruta_destino);
            }
            else
            {
                if (!SomeHelpers.FileCompare(ruta_origen, ruta_destino))
                {
                    File.Copy(dlg.FileName, ruta_destino);
                }
                else
                {
                    Console.WriteLine("La imagen no fue copiada");
                }
            }
        }

        public static void DownloadImageUrl(string url)
        {
            using (WebClientMia client = new WebClientMia())
            {
                string ruta = Global.DIRECTORIO_IMAGENES + @"\" + Path.GetFileName(url);
                client.Timeout = 10000;
                client.DownloadFileAsync(new Uri(url), ruta);              
            }
        }
    
        public static Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = (newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
                new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        public static System.Data.DataTable FillDataGridOnDataTable(DataGridView dgv)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;

                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }

        public static Image ImageFromCellGrid(Object val)
        {
            var data = (Byte[])(val);
            var stream = new MemoryStream(data);
            return Image.FromStream(stream);
        }

        public static void StartOSK()
        {
            if ((bool)Properties.Settings.Default["tecladoPantalla"])
            {
                try
                {
                    if (FriendlyName().Equals("10"))
                    {
                        string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
                        string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

                        System.Diagnostics.Process.Start(keyboardPath);
                    }
                    else
                    {
                        string windir = Environment.GetEnvironmentVariable("WINDIR");
                        string osk = null;

                        if (osk == null)
                        {
                            osk = Path.Combine(Path.Combine(windir, "sysnative"), "osk.exe");
                            if (!File.Exists(osk))
                                osk = null;
                        }

                        if (osk == null)
                        {
                            osk = Path.Combine(Path.Combine(windir, "system32"), "osk.exe");
                            if (!File.Exists(osk))
                            {
                                osk = null;
                            }
                        }

                        if (osk == null)
                            osk = "osk.exe";


                        System.Diagnostics.Process.Start(osk);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static string FriendlyName()
        {
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string path = "ProductName";

            RegistryKey rk = Registry.LocalMachine.OpenSubKey(key);
            if (rk == null) return "no key";
            string a = (string)rk.GetValue(path);

            if (a != "")
            {
                a = Regex.Match(a, @"\d+").Value;
                Console.WriteLine(a);
                return (a);
            }
            return "no value";
        }

        public static void AddValueComboBox(ComboBox cbo)
        {
            if (cbo.SelectedValue == null)
            {
                if (cbo.Text.Trim().Length > 0)
                {
                    switch (cbo.Name)
                    {
                        case "cboAreaLinea":
                            if (daoAL.ExistsAreaLinea(cbo.Text.Trim()) == 0)
                            {
                                DialogResult dr = MessageBox.Show("Desea agregar el nuevo valor a la base de datos?",
                                    "Nuevo valor registrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dr == DialogResult.Yes)
                                {
                                    daoAL.AddAreaLinea(new AreaLinea() { nombre = cbo.Text.Trim() });
                                }
                                else
                                {
                                    cbo.SelectedIndex = 0;
                                }
                            }

                            break;
                        case "cboEquipo":
                            if (daoEq.ExistsEquipo(cbo.Text.Trim()) == 0)
                            {
                                DialogResult dr = MessageBox.Show("Desea agregar el nuevo valor a la base de datos?",
                                    "Nuevo valor registrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dr == DialogResult.Yes)
                                {
                                    daoEq.AddEquipo(new Equipos() { nombre = cbo.Text.Trim() });
                                }
                                else
                                {
                                    cbo.SelectedIndex = 0;
                                }
                            }

                            break;
                        case "cboTecnico":
                        case "cboAprobador":
                        case "cboElaborador":
                        case "cboChkTecInvolucrados":
                        case "cboChkOpeInvolucrados":
                        case "cboChkElaborado":
                        case "cboChkContraInvolucrados":
                        case "cboChkValidInvolucrados":
                            if (daoTec.ExistsTecnico(cbo.Text.Trim()) == 0)
                            {
                                DialogResult dr = MessageBox.Show("Desea agregar el nuevo valor a la base de datos?",
                                    "Nuevo valor registrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dr == DialogResult.Yes)
                                {
                                    daoTec.AddTecnico(new Tecnicos() { nombre = cbo.Text.Trim() });
                                }
                                else
                                {
                                    cbo.SelectedIndex = 0;
                                }
                            }
                            break;
                    }
                }
            }
        }

        // This method accepts two strings the represent two files to 
        // compare. A return value of 0 indicates that the contents of the files
        // are the same. A return value of any other value indicates that the 
        // files are not the same.
        public static bool FileCompare(string file1, string file2)
        {
            bool t = true;

            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                t = true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            //MessageBox.Show("Tamaño origen: "+fs1.Length + " Tamaño destino: " + fs2.Length);
            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                t = false;
            }
            return t;
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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

    }
}
