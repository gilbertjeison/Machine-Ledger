using FormatoEwo.DaoEF;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormatoEwo.Util
{
    public class SmpHandler
    {
        Splash splash = new Splash();
        string path = "";
        DaoSMP daoSMP = new DaoSMP();

        public SmpHandler()
        { }

        public void GenerateSmp(int id_smp)
        {
            try
            {    
                //BUSCAR SMP EN SU TABLA
                if (id_smp == 0)
                {
                    MessageBox.Show("SMP no cargado aún...");
                }
                else
                {
                    splash.Show();
                    //CREAR SMP A PARTIR DE LA BASE DE DATOS
                    //OBEJTO QUE PERMITE GESTIONAR DOCUMENTO EXCEL
                    Excel.Application xlApp = new Excel.Application();
                    //NO MOSTRAR ARCHIVO MIENTRAS SE UTILIZA
                    xlApp.Visible = false;
                    //DIRECTORIO DONDE SE COPIARÁ EL ARCHIVO TEMPORALMENTE
                    //PARA EDITARLO
                    string sru = System.IO.Path.GetTempPath();
                    //NOMBRE DEL ARCHIVO TEMPORAL
                    path = @"" + sru + "\\SMP_TEMP.xlsx";
                    //COPIAR EL ARCHIVO DE LOS RECURSOS DE LA APLICACIÓN
                    // A LA RUTA ESTABLECIDA
                    File.WriteAllBytes(path, Properties.Resources.SMP_MODIFICADO);

                    //VERIFICAR SI EL ARCHIVO ESTÁ BLOQUEADO O ESTA SIENDO UTILIZADO POR OTRO PROCESO
                    if (IsFileLocked(new FileInfo(path)))
                    {
                        MessageBox.Show("El archivo se está ejecutando, debe cerrarlo para continuar",
                            "Abrir SMP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //CREAR EL OBJETO DEL LIBRO A PARTIR DE LA RUTA 
                        Excel.Workbook wb = xlApp.Workbooks.Open(path);

                        //FIJAR EN OBJETOS LAS PESTAÑAS U HOJA DEL LIBRO PARA TRABAJAR
                        Excel.Worksheet ws2 = (Excel.Worksheet)wb.Worksheets[1];

                        //INFORMACIÓN DE BD
                        CustomSMP cs = daoSMP.GetCustomSMP(id_smp);
                        //////////////////////////////////////////////////
                        //**************** INFORMACIÓN BÁSICA ************
                        //////////////////////////////////////////////////  
                        //LINEA
                        FillCell(ws2, 3, 5, cs.desc_linea);
                        //EQUIPO
                        FillCell(ws2, 4, 5, cs.desc_equipo);
                        //CLASDIFICACIÓN SMP
                        FillCell(ws2, 5, 5, cs.desc_clasificacion);
                        //NOMBRE SMP
                        FillCell(ws2, 2, 14, cs.nombre);
                        //NÚMERO SMP
                        FillCell(ws2, 3, 18, cs.numero.ToString());
                        //ELABORADO POR
                        FillCell(ws2, 3, 25, cs.desc_elaborador);
                        //APROBADO POR
                        FillCell(ws2, 3, 35, cs.desc_aprobador);
                        //FECHA
                        FillCell(ws2, 4, 40, cs.fecha_smp.ToString());
                        //NÚMERO DE TECNICOS REQUERIDOS
                        FillCell(ws2, 5, 14, cs.tecnicos_eq.ToString());
                        //TIPO MANTENIMIENTO
                        FillCell(ws2, 5, 24, cs.desc_tipo_mtto);
                        //DURACIÓN DE LA ACTIVIDAD
                        FillCell(ws2, 5, 30, cs.duracion_actividad.ToString());
                        //TIEMPO EQUIPO PARADO
                        FillCell(ws2, 5, 35, cs.equipo_parado.ToString());
                        ////FREUENCIA
                        FillCell(ws2, 5, 41, cs.frecuencia + " " + cs.desc_tipo_frecuencia.ToString());
                        ////LOTO
                        FillCell(ws2, 16, 3, cs.loto ? "SI" : "NO");

                        //IMAGEN 1                
                        if (!cs.imagen_1.Equals(""))
                        {
                            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[7, 9];
                            SomeHelpers.AddImageExcel(ws2, Global.DIRECTORIO_IMAGENES + @"\" + cs.imagen_1, (float)rIm.Left + 1, (float)rIm.Top + 1, 152, 150);
                        }
                        //IMAGEN 2                
                        if (!cs.imagen_2.Equals(""))
                        {
                            Microsoft.Office.Interop.Excel.Range rIm = (Microsoft.Office.Interop.Excel.Range)ws2.Cells[7, 21];
                            SomeHelpers.AddImageExcel(ws2, Global.DIRECTORIO_IMAGENES + @"\" + cs.imagen_2, (float)rIm.Left + 1, (float)rIm.Top + 1, 152, 150);
                        }

                        //PERMISOS DE TRABAJO
                        string[] permisos = cs.permisos.Split(',');
                        int k = 0;
                        for (int i = 5; i <= 30; i += 2)
                        {
                            if (k < permisos.Length)
                            {
                                //CÓDIGO PODEROSO
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                + GetImageFromRisk(permisos[k]), (float)GetRangeImageRisk(ws2, i).Left + 1,
                                (float)GetRangeImageRisk(ws2, i).Top + 1, 55, 58);

                                FillCell(ws2, 19, i, permisos[k]);
                                k++;
                            }
                        }

                        //////////////////////////////////////////////////
                        //**************** EPPS *************************
                        ////////////////////////////////////////////////// 
                        //EPPS
                        //EPPS IMAGENES RANGO
                               
                        int j = 0;

                        for (int i = 6; i <= 70; i += 2)
                        {
                            if (j < cs.list_epps.Count)
                            {
                                //CÓDIGO PODEROSO
                                SomeHelpers.AddImageExcel(ws2, Util.Global.DIRECTORIO_IMAGENES + @"\"
                                    + cs.list_epps[j].foto, (float)GetRangeImageEpp(ws2, i).Left + 1,
                                    (float)GetRangeImageEpp(ws2, i).Top + 1, 56, 59);

                                FillCell(ws2, 12, i, cs.list_epps[j].nombre);

                                j++;
                            }
                        }


                        //////////////////////////////////////////////////
                        //**************** HERRAMIENTAS *****************
                        //////////////////////////////////////////////////   
                        int herramientas_cant = cs.list_herramientas.Count;
                        int inicio_herr = 22;
                        Excel.Range linePpal = (Excel.Range)ws2.Rows[inicio_herr - 1];
                        if (herramientas_cant > 0)
                        {
                            linePpal.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < herramientas_cant; i++)
                        {
                            Excel.Range line = (Excel.Range)ws2.Rows[inicio_herr];
                            linePpal.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_herr, 26], ws2.Cells[inicio_herr, 42]].Merge();
                            //COMBINAR CELDA DE NOMBRE HERRAMIENTA
                            ws2.Range[ws2.Cells[inicio_herr, 13], ws2.Cells[inicio_herr, 25]].Merge();
                            //COMBINAR CELDA DE NOMBRE CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_herr, 11], ws2.Cells[inicio_herr, 12]].Merge();
                        }
                        //SI HAY MAS DE 1 ELEMENTO, SE COMBINAN LAS COLUMNAS
                        if (herramientas_cant > 1)
                        {
                            ws2.Range[ws2.Cells[inicio_herr - 1, 3], ws2.Cells[inicio_herr + herramientas_cant - 2, 9]].Merge();
                        }

                        //AÑADIR ELEMENTOS A CELDAS
                        int l = inicio_herr - 1;

                        for (int i = 0; i < herramientas_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, l, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + System.IO.Path.GetFileName(cs.list_herramientas[i].image_path);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS
                            SomeHelpers.AddImageExcelFromWeb(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137, cs.list_herramientas[i].image_path);
                            //NOMBRE DE LA HERRAMIENTA
                            FillCell(ws2, l, 13, cs.list_herramientas[i].herramienta);
                            l++;
                        }

                        //////////////////////////////////////////////////
                        //**************** REPUESTOS *****************
                        ////////////////////////////////////////////////// 
                        if (herramientas_cant == 0)
                        {
                            herramientas_cant++;
                        }

                        int repuestos_cant = cs.list_repuestos.Count;
                        int inicio_rep = inicio_herr + herramientas_cant; //+ 1; //23;
                        Excel.Range linePpalRep = (Excel.Range)ws2.Rows[inicio_rep - 1];
                        if (repuestos_cant > 0)
                        {
                            linePpalRep.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < repuestos_cant; i++)
                        {
                            Excel.Range line = (Excel.Range)ws2.Rows[inicio_rep];
                            linePpalRep.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_rep, 26], ws2.Cells[inicio_rep, 42]].Merge();
                            //COMBINAR CELDA DE NOMBRE HERRAMIENTA
                            ws2.Range[ws2.Cells[inicio_rep, 13], ws2.Cells[inicio_rep, 25]].Merge();
                            //COMBINAR CELDA DE NOMBRE CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_rep, 11], ws2.Cells[inicio_rep, 12]].Merge();
                        }
                        //SI HAY MAS DE 1 ELEMENTO, SE COMBINAN LAS COLUMNAS
                        if (repuestos_cant > 1)
                        {
                            ws2.Range[ws2.Cells[inicio_rep - 1, 3], ws2.Cells[inicio_rep + repuestos_cant - 2, 9]].Merge();
                        }

                        //AÑADIR ELEMENTOS A CELDAS
                        int b = inicio_rep - 1;

                        for (int i = 0; i < repuestos_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, b, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + System.IO.Path.GetFileName(cs.list_repuestos[i].image_path);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcelFromWeb(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137, cs.list_repuestos[i].image_path);
                            //NOMBRE DE LA HERRAMIENTA
                            FillCell(ws2, b, 13, "(" + cs.list_repuestos[i].cantidad + ") " + cs.list_repuestos[i].descripcion);
                            b++;
                        }

                        //////////////////////////////////////////////////
                        //**************** PASO A PASO *****************
                        //////////////////////////////////////////////////                  
                        if (repuestos_cant == 0)
                        {
                            repuestos_cant += 1;
                        }

                        int paso_cant = cs.list_pasos.Count;
                        int inicio_paso = inicio_rep + repuestos_cant + 1; //23;
                        Excel.Range linePpalPas = (Excel.Range)ws2.Rows[inicio_paso - 1];
                        if (paso_cant > 0)
                        {
                            linePpalPas.RowHeight = 138.6;
                        }

                        //COMBINAR Y CENTRAR CELDAS
                        for (int i = 1; i < paso_cant; i++)
                        {
                            Excel.Range line = (Excel.Range)ws2.Rows[inicio_paso];
                            linePpalPas.RowHeight = 138.6;
                            line.Insert();

                            //COMBINAR CELDA DE FOTO
                            ws2.Range[ws2.Cells[inicio_paso, 26], ws2.Cells[inicio_paso, 42]].Merge();
                            //COMBINAR CELDA DESCRIPCIÓN DEL PASO
                            ws2.Range[ws2.Cells[inicio_paso, 13], ws2.Cells[inicio_paso, 25]].Merge();
                            //COMBINAR CELDA DE FOTO CATEGORÍA
                            ws2.Range[ws2.Cells[inicio_paso, 11], ws2.Cells[inicio_paso, 12]].Merge();
                            //COMBINAR CELDA DE DURACIÓN
                            ws2.Range[ws2.Cells[inicio_paso, 10], ws2.Cells[inicio_paso, 10]].Merge();
                            //COMBINAR CELDA DE NOMBRE
                            ws2.Range[ws2.Cells[inicio_paso, 3], ws2.Cells[inicio_paso, 9]].Merge();
                        }


                        System.Windows.Forms.Application.DoEvents();


                        //AÑADIR ELEMENTOS A CELDAS
                        int p = inicio_paso - 1;

                        for (int i = 0; i < paso_cant; i++)
                        {
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPosition = GetRangeHerramienta(ws2, p, 32);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_p = Util.Global.DIRECTORIO_IMAGENES + @"\" + System.IO.Path.GetFileName(cs.list_pasos[i].imagen_paso_path);
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcel(ws2, image_p, (float)picPosition.Left, (float)picPosition.Top + 1, 170, 137);

                            //DESCRIPCIÓN
                            FillCell(ws2, p, 13, cs.list_pasos[i].desc);
                            //NOMBRE
                            FillCell(ws2, p, 3, cs.list_pasos[i].paso);
                            //DURACIÓN
                            FillCell(ws2, p, 10, cs.list_pasos[i].duracion + "");
                            //NUMERO PASO
                            int num_pas = i + 1;
                            FillCell(ws2, p, 2, num_pas.ToString() + "");

                            //IMAGEN CATEGORIA
                            //OBTENER EL RANGO DEPENDIENDO DE CADA ELEMENTO
                            Microsoft.Office.Interop.Excel.Range picPositionCat = GetRangeHerramienta(ws2, p, 11);
                            //LA IMAGEN EN EL DATAGRID FUE DESCARGADA, SE OBTIENE LA RUTA PARA PEGAR EN EL EXCEL
                            string image_pCat = Util.Global.DIRECTORIO_IMAGENES + @"\" + System.IO.Path.GetFileName(cs.list_pasos[i].categoria + ".PNG");
                            //SE INSERTA LA IMAGEN EN EL EXCEL, CONFIGURANDO ATRIBUTOS                    
                            SomeHelpers.AddImageExcel(ws2, image_pCat, (float)picPositionCat.Left + 15, (float)picPositionCat.Top + 57, 20, 20);

                            p++;
                        }

                        int limit = inicio_paso + paso_cant;
                        //CONFIGURANDO AREA DE IMPRESIÓN
                        ws2.PageSetup.PrintArea = "$A$1:$AP$" + limit;

                        wb.Save();
                        wb.Close();

                        System.Diagnostics.Process.Start(path);
                        splash.Hide();
                    }
                }   
            }
            catch (Exception ex)
            {
                splash.Hide();
                MessageBox.Show("Item inválido, " + ex.Message.ToLower());
            }
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

        private void FillCell(Excel.Worksheet w, int row, int column, string value)
        {
            w.Cells[row, column] = (string)(w.Cells[row, column]
                as Excel.Range).Value + " " + value;
        }

        private Excel.Range GetRangeImageRisk(Excel.Worksheet w, int index)
        {
            Excel.Range rIm = (Excel.Range)w.Cells[16, index];
            return rIm;
        }

        private string GetImageFromRisk(string risk)
        {
            string image = "none";

            switch (risk)
            {
                case "TRABAJO CALIENTE":
                    image = "trabajo_caliente.png";
                    break;
                case "TRABAJO EN ALTURAS":
                    image = "trabajo_alturas.png";
                    break;
                case "SUSTANCIAS QUÍMICAS":
                    image = "sustancias_quimicas.png";
                    break;
                case "EXCAVACIONES":
                    image = "excavaciones.png";
                    break;
                case "ENERGÍA CERO":
                    image = "energia_cero.png";
                    break;
                case "TRABAJO EN SUBESTACIÓN":
                    image = "trabajo_subestacion.png";
                    break;
                case "ESPACIOS CONFINADOS":
                    image = "espacio_confinado.png";
                    break;
                case "TRÁFICO DE MONTACARGAS":
                    image = "trafico_montacargas.png";
                    break;
                case "ATRAPAMIENTO":
                    image = "atrapamiento.jpg";
                    break;
                case "LEVANTAMIENTO DE CARGAS":
                    image = "levantamiento_carga.png";
                    break;
                case "HERRAMIENTAS Y EQUIPOS":
                    image = "herramientas_equipos.png";
                    break;
                default:
                    break;
            }

            return image;
        }

        private Excel.Range GetRangeHerramienta(Excel.Worksheet w, double row, int index)
        {
            Excel.Range rIm = (Excel.Range)w.Cells[row, index];
            rIm.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            return rIm;
        }

        private Excel.Range GetRangeImageEpp(Excel.Worksheet w, int index)
        {
            Excel.Range rIm = (Excel.Range)w.Cells[8, index];
            return rIm;
        }
    }
}
