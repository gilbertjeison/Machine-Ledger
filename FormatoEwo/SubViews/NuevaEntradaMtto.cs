using FormatoEwo.Objetos;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using FormatoEwo.Util;
using FormatoEwo.DaoEF;
using FormatoEwo.Database;
using System.Diagnostics;
using System.Globalization;

namespace FormatoEwo.SubViews
{
    public partial class NuevaEntradaMtto : MetroForm
    {        
        //COMPONENTE QUE CONTIENE LOS MTTOS
        Componentes comp;
        //DAO DATABASE
        DaoCalPM daoCal = new DaoCalPM();
        DaoEwo daoEwo = new DaoEwo();
        DaoSMP daoSmp = new DaoSMP();
        //LISTA PARA DATOS
        List<ewos> listEwos = new List<ewos>();
        List<CalendarioPm> listCal = new List<CalendarioPm>();
        List<smp> listSmp = new List<smp>();
        //ENTRADA QUE SERÁ EDITADA
        CalendarioPm calToEdit = new CalendarioPm();
        //SPLASH QUE SE MUESTRA MIENTRAS CARGA
        Splash splash = new Splash();
        SmpHandler sHan = new SmpHandler();
        
        //FLAG PARA VERIFICAR SI SE REALIZÓ UNA TRANSACCIÓN EFECTIVA
        bool trans = false;

        public NuevaEntradaMtto(Componentes com)
        {
            InitializeComponent();
            comp = com;
        }               

        private void NuevaEntradaMtto_Load(object sender, EventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                bgLoad.RunWorkerAsync();
            }
        }

        private void bgLoad_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            listCal = daoCal.GetCalendario(comp.id);
            listEwos = daoEwo.GetEwos();
            listSmp = daoSmp.GetSmps();
        }

        private void bgLoad_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {            
            cboEwo.DataSource = listEwos;                       

            //CARGAR INFORMACIÓN DEL SMP
            smp s = listSmp.FirstOrDefault(x => x.Id == comp.id_smp);
            if (s != null)
            {
                txtSMP.Text = s.nombre;
                txtDuracion.Text = s.duracion_actividad.ToString() + " Mins";
                txtTecnicos.Text = s.tecnicos_req + " Técnicos";
            }            
            
            //RESET DE LA LISTA
            lvMtto.Items.Clear();

            foreach (CalendarioPm item in listCal)
            {
                //LLENAR LA LISTA CON MTTOS CORRESPONDIENTES
                string[] array = new string[] { item.semana.ToString(),item.year.ToString(), item.desc, item.id_ewo.ToString(), item.duracion_total.ToString(), item.cantidad.ToString(),item.observaciones, item.usuario };
                int index = -1;
                //SELECCIÓN DE IMÁGEN DEL TIPO DE MTTO
                switch (array[2])
                {
                    case "Mantenimiento planeado":
                        index = 3;
                        break;
                    default:
                        break;
                    case "Mantenimiento planeado ejecutado":
                        index = 1;
                        break;
                    case "Mantenimiento extra":
                        index = 2;
                        break;
                    case "Mantenimiento por avería":
                        index = 0;
                        break;
                }
                ListViewItem lvi = new ListViewItem(array, index);
                lvi.Tag = item;
                //GroupItem(lvi);
                lvMtto.Items.Add(lvi);
            }

            //NOMBRE DEL COMPONENTE
            gbLista.Text = "Entradas de mtto para componente (" + comp.descripcion + ") - ("+ listCal.Count +" entradas)";
            
            //HABILITAR CONTROLES
            chkAveria.Enabled = true;
            chkMttoPlaneado.Enabled = true;
            chkMttoExtra.Enabled = true;
            chkMttoPE.Enabled = true;

            chkAveria.Checked = false;
            chkMttoPlaneado.Checked = false;
            chkMttoExtra.Checked = false;
            chkMttoPE.Checked = false;

            txtCantidad.Text = "";
            //dtpFech.SelectedIndex = 0;
            txtHasta.Value = 2016;
            dtpFech.DataSource = GenerateWeeks();
            cboEwo.SelectedIndex = -1;
            
            txtTiempoAverias.Text = "";

            splash.Hide();

            AutoClosingMessageBox.Show("Actualizando...", "Datos de entrada", 1000);
        }             


        private bool ExistsEntry(int id_tm)
        {
            bool res = false;
            string[] dates = dtpFech.SelectedValue.ToString().Split('-');

            //CONSULTAR LOS MTTOS EN LA FECHA SELECCIONADA
            var listFil = listCal.Where(x => x.semana == 
                int.Parse(dates[0]) && x.year == int.Parse(dates[1])
                    && x.id_tipo_mtto == id_tm).ToList();

            if (listFil.Count == 0)
            {
                res = false;
            }
            else
            {
                res = true;
                MessageBox.Show("Ya existe una entrada de Mtto con este tipo, por favor revise en el lado derecho y modifique los valores deseados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return res;
        }

        private void bgSave_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<CalendarioPm> list = (List<CalendarioPm>)e.Argument;
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].user_id = Global.UserLoged.Id;                    
                    daoCal.AddEntryMtto(list[i]);
                }
            }
            else
            {
                daoCal.EditEntry(calToEdit);
            }
        }

        private void bgSave_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {            
            btnNuevaEntrada.ImageIndex = 8;
            btnNuevaEntrada.Text = "Nueva entrada";
            EnableControls(false);

            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }

            trans = true;
            MessageBox.Show("Transacción realizada correctamente!");
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.TextBoxHelper.OnlyNumbers(sender, e);
        }

        private void GroupItem(ListViewItem item)
        {
            // This flag will tell us if proper group already exists
            bool group_exists = false;

            // Check each group if it fits to the item
            foreach (ListViewGroup group in lvMtto.Groups)
            {
                // Compare group's header to selected subitem's text
                if (group.Header == item.SubItems[0].Text)
                {
                    // Add item to the group.
                    // Alternative is: group.Items.Add(item);
                    item.Group = group;
                    group_exists = true;
                    break;
                }
            }

            // Create new group if no proper group was found
            if (!group_exists)
            {
                // Create group and specify its header by
                // getting selected subitem's text
                ListViewGroup group = new ListViewGroup(item.SubItems[0].Text);
                // We need to add the group to the ListView first
                this.lvMtto.Groups.Add(group);
                item.Group = group;
            }
        }

        private void cboEwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selVal = cboEwo.SelectedValue == null ? 0 : int.Parse(cboEwo.SelectedValue.ToString());
                        
            if (selVal > 0)
            {
                ewos ew = daoEwo.GetEwoById(selVal);                
                txtTiempoAverias.Text = ew.tiempo_total.ToString() + " Mins";
                txtCantidad.Text = "2 Técnicos";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvMtto.Items.Count > 0)
            {
                lvMtto.Select();

                foreach (ListViewItem item in lvMtto.Items)
                {                    
                    item.Checked = !item.Checked;
                }                
            }            
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Realmente desea eliminar ("
                +lvMtto.CheckedItems.Count+") entrada(s) de mantenimiento?","Eliminar entradas",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (!bgDelete.IsBusy)
                {
                    splash.Show();
                    bgDelete.RunWorkerAsync();
                }
            }            
        }

        private void lvMtto_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvMtto.CheckedItems.Count > 0)
            {                
                btnRemover.Enabled = true;
                if (lvMtto.CheckedItems.Count > 1)
                {
                    btnEditar.Enabled = false;
                }
            }
            if (lvMtto.CheckedItems.Count == 1)
            {
                btnEditar.Enabled = true;
            }
            else if (lvMtto.CheckedItems.Count == 0)
            {
                btnRemover.Enabled = false;
                btnEditar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
        }

        private void bgDelete_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (ListViewItem item in lvMtto.Items)
                {
                    if (item.Checked)
                    {
                        CalendarioPm calDel = item.Tag as CalendarioPm;
                        daoCal.DeleteEntry(calDel);
                    }
                }
            });
        }

        private void bgDelete_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!bgLoad.IsBusy)
            {
                splash.Show();
                bgLoad.RunWorkerAsync();
            }
            splash.Hide();
        }

        private void EnableControls(bool state)
        {
            gbDatosEntrada.Enabled = state;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EnableControls(true);
            CalendarioPm calEd = lvMtto.CheckedItems[0].Tag as CalendarioPm;
            calToEdit = calEd;

            switch (calEd.id_tipo_mtto)
            {
                case 20:
                    chkAveria.Checked = true;
                    break;
                case 17:
                    chkMttoPlaneado.Checked = true;
                    break;
                case 19:
                    chkMttoExtra.Checked = true;
                    break;
                case 18:
                    chkMttoPE.Checked = true;
                    break;
            }

            chkAveria.Enabled = false;
            chkMttoPlaneado.Enabled = false;
            chkMttoExtra.Enabled = false;
            chkMttoPE.Enabled = false;

            dtpFech.SelectedValue = calEd.semana;
            cboEwo.SelectedValue = calEd.id_ewo;
            txtCantidad.Text = calEd.cantidad.ToString();
            txtObservaciones.Text = calEd.observaciones;

            btnNuevaEntrada.ImageIndex = 11;
            btnNuevaEntrada.Text = "Guardar edición";
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            if (btnNuevaEntrada.ImageIndex == 8)
            {
                EnableControls(true);
                btnNuevaEntrada.ImageIndex = 10;
                btnNuevaEntrada.Text = "Guardar entrada";
            }
            else
            {
                if (btnNuevaEntrada.ImageIndex == 10)
                {
                    //GUARDAR NUEVA ENTRADA DE MTTO
                    if (!bgSave.IsBusy)
                    {
                        string[] dates = dtpFech.SelectedValue.ToString().Split('-');
                         
                        //GUARDAR POR AVERÍA
                        if (chkAveria.Checked || chkMttoPlaneado.Checked || chkMttoExtra.Checked || chkMttoPE.Checked)
                        {
                            //VERIFICAR REPLICA DE SEMANAS
                            int replicas = (int)txtReplicas.Value;

                            if (replicas > 0)
                            {
                                if (!bgSaveMultipleEntry.IsBusy)
                                {
                                    bgSaveMultipleEntry.RunWorkerAsync();
                                }
                            }
                            else
                            {
                                //GUARDAR UNA SOLA VEZ
                                List<CalendarioPm> list = new List<CalendarioPm>();

                                if (chkAveria.Checked)
                                {
                                    if (!ExistsEntry(int.Parse(chkAveria.Tag.ToString())))
                                    {
                                        CalendarioPm pm = new CalendarioPm()
                                        {
                                            semana = int.Parse(dates[0]),
                                            year = int.Parse(dates[1]),
                                            id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                            id_componente = comp.id,
                                            cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                            id_tipo_mtto = int.Parse(chkAveria.Tag.ToString()),
                                            observaciones = txtObservaciones.Text.Trim()
                                        };

                                        list.Add(pm);
                                    }
                                }
                                if (chkMttoPlaneado.Checked)
                                {
                                    if (!ExistsEntry(int.Parse(chkMttoPlaneado.Tag.ToString())))
                                    {
                                        CalendarioPm pm = new CalendarioPm()
                                        {
                                            semana = int.Parse(dates[0]),
                                            year = int.Parse(dates[1]),
                                            id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                            id_componente = comp.id,
                                            cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                            id_tipo_mtto = int.Parse(chkMttoPlaneado.Tag.ToString()),
                                            observaciones = txtObservaciones.Text.Trim()
                                        };
                                        list.Add(pm);
                                    }
                                }
                                if (chkMttoExtra.Checked)
                                {
                                    if (!ExistsEntry(int.Parse(chkMttoExtra.Tag.ToString())))
                                    {
                                        CalendarioPm pm = new CalendarioPm()
                                        {
                                            semana = int.Parse(dates[0]),
                                            year = int.Parse(dates[1]),
                                            id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                            id_componente = comp.id,
                                            cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                            id_tipo_mtto = int.Parse(chkMttoExtra.Tag.ToString()),
                                            observaciones = txtObservaciones.Text.Trim()
                                        };
                                        list.Add(pm);
                                    }
                                }
                                if (chkMttoPE.Checked)
                                {
                                    if (!ExistsEntry(int.Parse(chkMttoPE.Tag.ToString())))
                                    {
                                        CalendarioPm pm = new CalendarioPm()
                                        {
                                            semana = int.Parse(dates[0]),
                                            year = int.Parse(dates[1]),
                                            id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                            id_componente = comp.id,
                                            cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                            id_tipo_mtto = int.Parse(chkMttoPE.Tag.ToString()),
                                            observaciones = txtObservaciones.Text.Trim()
                                        };
                                        list.Add(pm);
                                    }
                                }

                                if (list.Count > 0)
                                {
                                    
                                    splash.Show();                                    
                                    bgSave.RunWorkerAsync(list);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un tipo de mantenimiento!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    //EDITAR ENTRADA DE MTTO
                    if (!bgSave.IsBusy)
                    {
                        string[] dates = dtpFech.SelectedValue.ToString().Split('-');

                        calToEdit.semana = int.Parse(dates[0]);
                        calToEdit.year = int.Parse(dates[1]);
                        calToEdit.id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0");
                        calToEdit.cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0");
                        calToEdit.observaciones = txtObservaciones.Text.Trim();

                        splash.Show();
                        bgSave.RunWorkerAsync(null);                          
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un tipo de mantenimiento!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }

                
            }            
        }

        private int[] GetWeekIntoYear(int week, int ano)
        {            
            //CALCULO SEMANA
            int veces = week / 52;
            int res = week;
                           
            res = week - (52*veces);                              
            
            if (res == 0)
            {
                res = 52;
            }

            int y;
            //CALCULO AÑO
            if (veces == 1 && res == 52)
            {
                y = ano;
            }
            else
            {
                y = ano + veces;
            }
            
            int[] r = new int[2] { res, y };
            return r;
        }
                
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (trans)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }            
        }

        private List<WeeksCal> GenerateWeeks()
        {
            List<WeeksCal> dates = new List<WeeksCal>();
            int InitYear = 2016;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 1; i < 53; i++)
                {                    
                    DateTime dtIni = FirstDateOfWeekISO8601(InitYear + j, i);
                    DateTime dtFin = FirstDateOfWeekISO8601(InitYear + j, i + 1).AddDays(-1);
                    dates.Add(new WeeksCal()
                    {
                        fecha = "Semana " + i + " desde " + dtIni.ToString("dd-MMM-yy") + " hasta " + dtFin.ToString("dd-MMM-yy"),
                        week = i,
                        year = InitYear + j ,
                        wy = i + "-" + SumValues(InitYear, j)
                    });                    
                }
            }
            
            return dates;
        }

        private int SumValues(int a, int b) { return a + b; }

       
      
        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        private void bgSaveMultipleEntry_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string[] dates = dtpFech.SelectedValue.ToString().Split('-');

                int ano_desde = int.Parse(dates[1]);
                int ano_hasta = (int)txtHasta.Value;
                int weeks = ((ano_hasta - ano_desde) + 1) * 52;

                int anos = (ano_hasta - ano_desde) + 1; //AÑOS EN PLAN

                if (weeks < 0)
                {
                    MessageBox.Show("No es posible replicar entradas, el año debe ser mayor al de la entrada de mantenimiento!");
                }
                else
                {
                    int replicas = (int)txtReplicas.Value;
                    int first_week = int.Parse(dates[0]);

                    for (int i = first_week; i < weeks + 1; i += replicas)
                    {

                        
                        splash.Show();
                        int[] par = (int[])e.Argument;

                        List<CalendarioPm> list = new List<CalendarioPm>();

                        if (chkAveria.Checked)
                        {
                            if (!ExistsEntry(int.Parse(chkAveria.Tag.ToString())))
                            {
                                CalendarioPm pm = new CalendarioPm()
                                {
                                    semana = GetWeekIntoYear(i, ano_desde)[0],
                                    year = GetWeekIntoYear(i, ano_desde)[1],
                                    id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                    id_componente = comp.id,
                                    cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                    id_tipo_mtto = int.Parse(chkAveria.Tag.ToString()),
                                    observaciones = txtObservaciones.Text.Trim()
                                };

                                list.Add(pm);
                            }
                        }
                        if (chkMttoPlaneado.Checked)
                        {
                            if (!ExistsEntry(int.Parse(chkMttoPlaneado.Tag.ToString())))
                            {
                                CalendarioPm pm = new CalendarioPm()
                                {
                                    semana = GetWeekIntoYear(i, ano_desde)[0],
                                    year = GetWeekIntoYear(i, ano_desde)[1],
                                    id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                    id_componente = comp.id,
                                    cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                    id_tipo_mtto = int.Parse(chkMttoPlaneado.Tag.ToString()),
                                    observaciones = txtObservaciones.Text.Trim()
                                };
                                list.Add(pm);
                            }
                        }
                        if (chkMttoExtra.Checked)
                        {
                            if (!ExistsEntry(int.Parse(chkMttoExtra.Tag.ToString())))
                            {
                                CalendarioPm pm = new CalendarioPm()
                                {
                                    semana = GetWeekIntoYear(i, ano_desde)[0],
                                    year = GetWeekIntoYear(i, ano_desde)[1],
                                    id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                    id_componente = comp.id,
                                    cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                    id_tipo_mtto = int.Parse(chkMttoExtra.Tag.ToString()),
                                    observaciones = txtObservaciones.Text.Trim()
                                };
                                list.Add(pm);
                            }
                        }
                        if (chkMttoPE.Checked)
                        {
                            if (!ExistsEntry(int.Parse(chkMttoPE.Tag.ToString())))
                            {
                                CalendarioPm pm = new CalendarioPm()
                                {
                                    semana = GetWeekIntoYear(i, ano_desde)[0],
                                    year = GetWeekIntoYear(i, ano_desde)[1],
                                    id_ewo = int.Parse(cboEwo.SelectedIndex > -1 ? cboEwo.SelectedValue.ToString() : "0"),
                                    id_componente = comp.id,
                                    cantidad = int.Parse(txtCantidad.Text.Trim().Length > 0 ? txtCantidad.Text.Trim() : "0"),
                                    id_tipo_mtto = int.Parse(chkMttoPE.Tag.ToString()),
                                    observaciones = txtObservaciones.Text.Trim()
                                };
                                list.Add(pm);
                            }
                        }

                        if (list != null)
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                list[j].user_id = Global.UserLoged.Id;
                                daoCal.AddEntryMtto(list[j]);
                            }
                        }    
                    }
                }                
            });
        }

        private void bgSaveMultipleEntry_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Transacción realizada correctamente!");
            btnNuevaEntrada.ImageIndex = 8;
            btnNuevaEntrada.Text = "Nueva entrada";

            if (!bgLoad.IsBusy)
            {
                bgLoad.RunWorkerAsync();
            }

            trans = true;
        }

        private void btnCargarSmp_Click(object sender, EventArgs e)
        {
            sHan.GenerateSmp(comp.id_smp);
        }
    }

    public class WeeksCal
    {
        public int year { get; set; }
        public int week { get; set; }
        public string wy { get; set; }

        public string fecha { get; set; }
    }
}
