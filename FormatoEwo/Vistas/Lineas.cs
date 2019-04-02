using FormatoEwo.Objetos;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
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
    public partial class Lineas : MetroForm
    {
        List<Machines> listMachines = new List<Machines>();
        List<Sistemas> listSubSytems = new List<Sistemas>();        
        private string path;
        //GENERAR EXCEL
        //OBEJTO QUE PERMITE GESTIONAR DOCUMENTO EXCEL
        Microsoft.Office.Interop.Excel.Application xlApp =
                new Microsoft.Office.Interop.Excel.Application();
        Workbook wb;

        public Lineas()
        {
            InitializeComponent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (lvSubSistemas.SelectedItems.Count == 1)
            {
                //MOSTRAR ARCHIVO MIENTRAS SE UTILIZA
                xlApp.Visible = true;
                xlApp.WindowState = XlWindowState.xlMaximized;
                
                //DIRECTORIO DONDE SE COPIARÁ EL ARCHIVO TEMPORALMENTE
                //PARA EDITARLO
                path = Properties.Settings.Default["MachineLedger"].ToString();

                //CREAR EL OBJETO DEL LIBRO A PARTIR DE LA RUTA 
                wb = xlApp.Workbooks.Open(path);
                //FIJAR EN OBJETOS LAS PESTAÑAS U HOJA DEL LIBRO PARA TRABAJAR
                Worksheet ws2 = (Worksheet)wb.Worksheets[lvSubSistemas.Items.IndexOf(lvSubSistemas.SelectedItems[0]) + 1];
                ws2.Activate();

                //MINIMIZAR PANTALLA
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void Lineas_Load(object sender, EventArgs e)
        {
            LoadMachines();

            foreach (Machines mach in listMachines)
            {
                lvImagenes.Items.Add(new ListViewItem()
                {
                    Text = mach.nombre,
                    ImageKey = mach.foto,
                    Tag = mach.id
                });
            }
            
            lvImagenes.Refresh();
        }

        private void lvImagenes_DoubleClick(object sender, EventArgs e)
        {
            if (lvImagenes.SelectedItems.Count == 1)
            {
                lvSubSistemas.Items.Clear();
                ListViewItem lvi = lvImagenes.SelectedItems[0];

                foreach (Sistemas mach in listSubSytems)
                {
                    if (mach.id_machine.ToString().Equals(lvi.Tag.ToString()))
                    {
                        lvSubSistemas.Items.Add(new ListViewItem()
                        {
                            Text = mach.id + ". " + mach.nombre,
                            ImageIndex = 0                            
                        });
                    }
                    
                   pbImage.Image = listMachines[int.Parse(lvi.Tag.ToString())-1].foto_max;                    
                   
                }                               

                lvSubSistemas.Refresh();
            }
        }

        private void LoadMachines()
        {
            //SUBMAQUINAS
            listSubSytems.Add(new Sistemas() { id = 1, nombre = "Alimentación material de envasado", id_machine = 1});
            listSubSytems.Add(new Sistemas() { id = 2, nombre = "Control de cantos de cinta", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 3, nombre = "Separación longitudinal de banda", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 4, nombre = "Placa de inversión", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 5, nombre = "Dosificador", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 6, nombre = "Sellado longitudinal", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 7, nombre = "Dispositivo de marcado y desgarre", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 8, nombre = "Extractor", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 9, nombre = "Separación longitudinal", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 10, nombre = "Sellado transversal", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 11, nombre = "Corte horizontal", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 12, nombre = "Transferencia y evacuacion bolsas", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 13, nombre = "Dispositivo de seguridad", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 14, nombre = "Bastidor de la máquina", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 15, nombre = "Componente neumático", id_machine = 1 });
            listSubSytems.Add(new Sistemas() { id = 16, nombre = "Sistema eléctrico", id_machine = 1 });
            //SUBMAQUINAS 2
            listSubSytems.Add(new Sistemas() { id = 1, nombre = "Sistema Embobinado", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 2, nombre = "Sistema Sellado Inferior", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 3, nombre = "Sistema Sellado Lateral", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 4, nombre = "Sistema Refrigeracion  Sellado Inferior y Lateral", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 5, nombre = "Sistema Arrastre Film - Fotocelda", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 6, nombre = "Sistema Tijeras", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 7, nombre = "Sistema Pinzas cambio de Linea", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 8, nombre = "Sistema Carros Fijos Superiores", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 9, nombre = "Sistema Apertura de Sobres", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 10, nombre = "Sistema de Dosificacion", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 11, nombre = "Sistema Estirado de Sobres", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 12, nombre = "Sistema Carros Moviles - Mesa Apoyo sobres", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 13, nombre = "Sistema Sellado Superior", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 14, nombre = "Sistema Refrigeracion Sellado Superior", id_machine = 2 });
            listSubSytems.Add(new Sistemas() { id = 15, nombre = "Sistema Banda de salida - Bajante ", id_machine = 2 });

            //MAQUINAS
            listMachines.Add(new Machines()
            {
                id = 1,
                nombre = "Hassia-Redatron FlexiBag Si 600",
                foto = imagesMachines.Images.Keys[0],
                foto_max = FormatoEwo.Properties.Resources.image163
            });

            listMachines.Add(new Machines()
            {
                id = 2,
                nombre = "Mespack H-360 FED 363.008",
                foto = imagesMachines.Images.Keys[1],
                foto_max = FormatoEwo.Properties.Resources.mespack
            });
        }
    }
}
