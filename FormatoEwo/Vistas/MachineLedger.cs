
using FormatoEwo.DaoEF;
using FormatoEwo.Objetos;
using FormatoEwo.SubViews;
using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static FormatoEwo.Vistas.SubMenu;


namespace FormatoEwo.Vistas
{
    public partial class MachineLedger : MetroForm
    {       
        string texto_busq = "Buscar elemento...";
        //OBJETOS DE ACCESO A DATOS
        //DaoMachineLedger daoML = new DaoMachineLedger();
        DaoML daoML = new DaoML();
        Splash splash = new Splash();
        /// <summary>
        /// VARIABLE DONDE SE ALMACENA EL NOMBRE DE LA PLANTA
        /// </summary>
        Plantas planta = new Plantas() { nombre = "..." };
        /// <summary>
        /// VARIABLE DONDE SE ALMACENA EL NOMBRE DE LA MAQUINA
        /// </summary>
        string maquina = "...";
        /// <summary>
        /// VARIABLE DONDE SE ALMACENA EL NOMBRE DEL SISTEMA
        /// </summary>
        string sistema = "...";
        /// <summary>
        /// VARIABLE DONDE SE ALMACENA EL NOMBRE DEL CONJUNTO
        /// </summary>
        string conjunto = "...";
        
        /// <summary>
        ///  ENUMERACIONES PARA FILTRAR OPCIONES
        /// </summary>
        
        enum Acciones_list { AgregarMay = 0, AgregarMen = 1, Editar = 2, Eliminar = 3 }
        enum tipos { Maquina = 0, Sistema = 1, Conjunto = 2, Componente = 3 }

        int type_selected;

        /// <summary>
        /// LISTAS PARA EL ALMACENAMIENTO DE MAQUINAS EN DATOS DE CONSULTAS
        /// </summary>
        List<Machines> listMachines = new List<Machines>();
        /// <summary>
        /// LISTAS PARA EL ALMACENAMIENTO DE SISTEMAS EN DATOS DE CONSULTAS
        /// </summary>
        List<Sistemas> listSubSytems = new List<Sistemas>();
        /// <summary>
        /// LISTAS PARA EL ALMACENAMIENTO DE CONJUNTOS EN DATOS DE CONSULTAS
        /// </summary>
        List<Conjuntos> listConjuntos = new List<Conjuntos>();

        /// <summary>
        /// RUTA DEL ARCHIVO EXCEL
        /// </summary>
        private string path = String.Empty;

        /// <summary>
        /// OBEJTO QUE PERMITE GESTIONAR DOCUMENTO EXCEL
        /// </summary>
        //Microsoft.Office.Interop.Excel.Application xlApp =
        //        new Microsoft.Office.Interop.Excel.Application();
        /// <summary>
        /// OBEJTO QUE PERMITE GESTIONAR LIBRO EXCEL
        /// </summary>
        //Workbook wb;

        /// <summary>
        /// CONSTRUCTOR CON PARÁMETRO DE PLANTA SELECCIONADA
        /// </summary>
        public MachineLedger(Planta p)
        {
            //COMPONENTES DE INTERFAZ
            InitializeComponent();
            
            //VERIFICAR QUE PLANTA SELECCIONA PARA ASI 
            //MISMO MOSTRAR EL NOMBRE
            if (p == Planta.Planta_jabones)
            {
                planta.id = 1;
                planta.nombre = "Planta de Jabones";
            }
            else
            {
                planta.id = 2;
                planta.nombre = "Planta de Detergentes";
            }

            //LLAMAR METODO QUE ESCRIBE RUTA EN PANTALLA
            SetName();                        
        }

        /// <summary>
        /// LOAD DE LA PANTALLA, SE EJECUTA DESPUES DEL CONSTRUCTOR
        /// </summary>
        private void Lineas_Load(object sender, EventArgs e)
        {
            //if (!bgLoad.IsBusy)
            //{
            //    splash.Show();
            //    bgLoad.RunWorkerAsync();
            //}

            CreateModalLineas();
        }

        /// <summary>
        /// MODAL PARA MOSTRAR LAS LINEAS DE LA PLANTA SELECCIONADA AL PRINCIPIO
        /// </summary>
        private void CreateModalLineas()
        {
            //ESCONDER PANELES DE ADMINISTRACIÓN
            tlpSistemas.Visible = false;
            tlpConjuntos.Visible = false;
            tlpDetalles.Visible = false;

            //INHABILITAR PANTALLA PRINCIPAL
            Enabled = false;
            //VENTANA QUE SERVIRÁ DE SOMBRA DEL MODAL
            Shadow mod = new Shadow
            {
                //LA SOMBRA TOMARÁ EL MISMO TAMAÑO DE LA VENTANA PRINCIPAL
                Size = Size
            };

            //MOSTRAR LA VENTANA DE SOMBRA
            mod.Show();
            //LA SOMBRA TENDRÁ LA MISMA UBICACIÓN EN LA PANTALLA QUE LA VENTANA PRINCIPAL
            mod.Location = Location;

            FormLineas fLin = new FormLineas(planta);

            //INICIALIZAR EVENTO DE CIERRE DE FORMULARIO PARA CONTROLARLO DESDE LA PANTALLA PADRE
            fLin.FormClosed += (s, e) => { mod.Close(); Enabled = true; };//HABILITAR VENTANA PRINCIPAL APENAS SE CIERRE

            //TAMAÑO MAS PEQUEÑO
            //fLin.Size = new System.Drawing.Size(400, 350);

            //LA POSICIÓN PRINCIPAL SERÁ FIJADA POR LA UBICACIÓN MANUAL
            fLin.StartPosition = FormStartPosition.CenterScreen;

            //CALCULAR POSICIÓN DE ACUERDO AL TAMAÑO DE LA VENTANA PRINCIPAL
            //nvE.Location = new System.Drawing.Point(mod.Left + (mod.Width - nvE.Width) / 2,
            //                         mod.Top + (mod.Height - nvE.Height) / 2);
            //MOSTRAR MODAL SOBRE EL FORMULARIO DE SOMBRA
            fLin.ShowDialog();

            //CUANDO SE CIERRE EL MODAL, MOSTRAR LA VENTANA PRINCIPAL
            this.BringToFront();

            if (fLin.DialogResult == DialogResult.OK)
            {                
                if (!bgLoad.IsBusy)
                {
                    splash.Show();
                    bgLoad.RunWorkerAsync();
                }

                tlpDetalles.Visible = false;
            }

            fLin.Dispose();            
        }

        /// <summary>
        /// CREAR PANTALLA MODAL PERSONALIZADA, RECIBE LA ACCIÓN A REALIZAR CON LA PANTALLA
        /// ASI MISMO MOSTRAR LA PANTALLA CORRECTA
        /// </summary>
        /// <param name="op" ></param>
        private void CreateFormModalMachines(Acciones_list al,Machines m)
        {
            if (al == Acciones_list.Eliminar)
            {                
                if (listSubSytems.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar, hay sistemas que dependen de esta máquina !","Error eliminando máquina",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult res = MessageBox.Show("Desea eliminar realmente " + m.nombre + " ?"
                    , "Eliminar máquina", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        daoML.DeleteMaquina(m);

                        if (!bgLoad.IsBusy)
                        {
                            splash.Show();
                            bgLoad.RunWorkerAsync();
                        }
                    }
                }       
            }
            else
            {
                //INHABILITAR PANTALLA PRINCIPAL
                Enabled = false;
                //VENTANA QUE SERVIRÁ DE SOMBRA DEL MODAL
                Shadow mod = new Shadow
                {
                    //LA SOMBRA TOMARÁ EL MISMO TAMAÑO DE LA VENTANA PRINCIPAL
                    Size = Size
                };

                //MOSTRAR LA VENTANA DE SOMBRA
                mod.Show();
                //LA SOMBRA TENDRÁ LA MISMA UBICACIÓN EN LA PANTALLA QUE LA VENTANA PRINCIPAL
                mod.Location = Location;

                //CREAR NUEVO ELEMENTO
                if (al == Acciones_list.AgregarMay || al == Acciones_list.Editar)
                {
                    NuevoItem nvE;

                    //PANTALLA PARA NUEVO ELEMENTO
                    if (al == Acciones_list.AgregarMay)
                    {
                        nvE = new NuevoItem(null);
                    }
                    else
                    {
                        nvE = new NuevoItem(m);
                    }

                    //INICIALIZAR EVENTO DE CIERRE DE FORMULARIO PARA CONTROLARLO DESDE LA PANTALLA PADRE
                    nvE.FormClosed += (s, e) => { mod.Close(); Enabled = true; };//HABILITAR VENTANA PRINCIPAL APENAS SE CIERRE

                    //TAMAÑO MAS PEQUEÑO
                    nvE.Size = new System.Drawing.Size(400, 350);

                    //LA POSICIÓN PRINCIPAL SERÁ FIJADA POR LA UBICACIÓN MANUAL
                    nvE.StartPosition = FormStartPosition.CenterScreen;

                    //CALCULAR POSICIÓN DE ACUERDO AL TAMAÑO DE LA VENTANA PRINCIPAL
                    //nvE.Location = new System.Drawing.Point(mod.Left + (mod.Width - nvE.Width) / 2,
                    //                         mod.Top + (mod.Height - nvE.Height) / 2);
                    //MOSTRAR MODAL SOBRE EL FORMULARIO DE SOMBRA
                    nvE.ShowDialog();

                    //CUANDO SE CIERRE EL MODAL, MOSTRAR LA VENTANA PRINCIPAL
                    this.BringToFront();

                    if (nvE.DialogResult == DialogResult.OK)
                    {
                        if (al == Acciones_list.AgregarMay)
                        {
                            //OBTENER EL OBJETO CON INFORMACIÓN Y AGREGARLO A LA BASE DE DATOS
                            
                            daoML.AddMachine(nvE.maquina);
                        }
                        else if (al == Acciones_list.Editar)
                        {                            
                            //OBTENER EL OBJETO CON INFORMACIÓN Y EDITARLO EN LA BASE DE DATOS
                            daoML.EditMaquina(nvE.maquina);
                        }

                        if (!bgLoad.IsBusy)
                        {
                            splash.Show();
                            bgLoad.RunWorkerAsync();
                        }

                        tlpDetalles.Visible = false;
                        tlpSistemas.Visible = false;
                        tlpConjuntos.Visible = false;
                    }
                    nvE.Dispose();
                }
            }  
        }

        private void CreateFormModalSystem(Acciones_list al,Machines m, Sistemas sis)
        {
            if (al == Acciones_list.Eliminar)
            {
                if (listConjuntos.Count > 0)
                {
                    MessageBox.Show("No se puede eliminar, hay conjuntos que dependen de este sistema !", "Error eliminando sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult res = MessageBox.Show("Desea eliminar realmente " + sis.nombre + " ?"
                    , "Eliminar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        daoML.DeleteSistema(sis);

                        if (!bgLoadSistemas.IsBusy)
                        {
                            splash.Show();
                            bgLoadSistemas.RunWorkerAsync(1);
                        }
                    }
                }
                
            }
            else
            {
                //INHABILITAR PANTALLA PRINCIPAL
                Enabled = false;
                //VENTANA QUE SERVIRÁ DE SOMBRA DEL MODAL
                Shadow mod = new Shadow();
                //LA SOMBRA TOMARÁ EL MISMO TAMAÑO DE LA VENTANA PRINCIPAL
                mod.Size = Size;
                //MOSTRAR LA VENTANA DE SOMBRA
                mod.Show();
                //LA SOMBRA TENDRÁ LA MISMA UBICACIÓN EN LA PANTALLA QUE LA VENTANA PRINCIPAL
                mod.Location = Location;

                //CREAR NUEVO ELEMENTO
                if (al == Acciones_list.AgregarMay ||  al == Acciones_list.Editar || al == Acciones_list.AgregarMen)
                {
                    NuevoSistema nvS;
                    
                    if (al == Acciones_list.AgregarMen)
                    {                         
                        nvS = new NuevoSistema(null,m);                        
                    }
                    else if (al == Acciones_list.AgregarMay)
                    {
                        nvS = new NuevoSistema(null, null);                        
                    }
                    else 
                    {
                        nvS = new NuevoSistema(sis,null);
                    }
                    
                    //INICIALIZAR EVENTO DE CIERRE DE FORMULARIO PARA CONTROLARLO DESDE LA PANTALLA PADRE
                    nvS.FormClosed += (s, e) => { mod.Close(); Enabled = true; };//HABILITAR VENTANA PRINCIPAL APENAS SE CIERRE
                                        
                    //LA POSICIÓN PRINCIPAL SERÁ FIJADA POR LA UBICACIÓN MANUAL
                    nvS.StartPosition = FormStartPosition.CenterScreen;

                    //CALCULAR POSICIÓN DE ACUERDO AL TAMAÑO DE LA VENTANA PRINCIPAL
                    //nvS.Location = 
                        //new System.Drawing.Point(mod.Left + (mod.Width - nvS.Width) / 2,
                        //                     mod.Top + (mod.Height - nvS.Height) / 2);

                    //TAMAÑO MAS PEQUEÑO
                    nvS.Size = new System.Drawing.Size(420, 300);

                    //MOSTRAR MODAL SOBRE EL FORMULARIO DE SOMBRA
                    nvS.ShowDialog();

                    //CUANDO SE CIERRE EL MODAL, MOSTRAR LA VENTANA PRINCIPAL
                    this.BringToFront();

                    if (al == Acciones_list.AgregarMen || al == Acciones_list.AgregarMay)
                    {
                        if (nvS.DialogResult == DialogResult.OK)
                        {
                            //OBTENER EL OBJETO CON INFORMACIÓN Y AGREGARLO A LA BASE DE DATOS
                            daoML.AddSistema(nvS.sistema);
                        }
                    }
                    else
                    {
                        if (nvS.DialogResult == DialogResult.OK)
                        {
                            //OBTENER EL OBJETO CON INFORMACIÓN Y EDITARLO EN LA BASE DE DATOS
                            daoML.EditSistema(nvS.sistema);                            
                        }

                        tlpSistemas.Visible = false;
                        tlpConjuntos.Visible = false;

                    }

                    tlpDetalles.Visible = false;

                    if (!bgLoad.IsBusy)
                    {
                        splash.Show();
                        bgLoad.RunWorkerAsync();
                    }
                    nvS.Dispose();
                }
            }
        }

        private void CreateFormModalConjuntos(Acciones_list al, Sistemas sis, Conjuntos con)
        {
            if (al == Acciones_list.Eliminar)
            {
                //if (listConjuntos.Count > 0)
                //{
                //    MessageBox.Show("No se puede eliminar, hay conjuntos que dependen de este sistema !", "Error eliminando sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                //{
                DialogResult res = MessageBox.Show("Esto eliminará este conjunto y todos sus componentes, desea eliminar realmente " + con.nombre + " ?"
                , "Eliminar conjunto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    daoML.DeleteConjunto(con);

                    if (!bgLoadConjuntos.IsBusy)
                    {
                        splash.Show();
                        bgLoadConjuntos.RunWorkerAsync(1);
                    }
                }
                //}
            }
            else
            {
                //INHABILITAR PANTALLA PRINCIPAL
                Enabled = false;
                //VENTANA QUE SERVIRÁ DE SOMBRA DEL MODAL
                Shadow mod = new Shadow();
                //LA SOMBRA TOMARÁ EL MISMO TAMAÑO DE LA VENTANA PRINCIPAL
                mod.Size = Size;
                //MOSTRAR LA VENTANA DE SOMBRA
                mod.Show();
                //LA SOMBRA TENDRÁ LA MISMA UBICACIÓN EN LA PANTALLA QUE LA VENTANA PRINCIPAL
                mod.Location = Location;

                //CREAR NUEVO ELEMENTO
                if (al == Acciones_list.AgregarMay || al == Acciones_list.Editar || al == Acciones_list.AgregarMen)
                {
                    NuevoConjunto nvC;

                    if (al == Acciones_list.AgregarMen)
                    {
                        nvC = new NuevoConjunto(sis, con);
                    }
                    if (al == Acciones_list.AgregarMay)
                    {
                        nvC = new NuevoConjunto(sis, null);
                    }
                    else
                    {
                        nvC = new NuevoConjunto(sis, con);
                    }

                    //INICIALIZAR EVENTO DE CIERRE DE FORMULARIO PARA CONTROLARLO DESDE LA PANTALLA PADRE
                    nvC.FormClosed += (s, e) => { mod.Close(); Enabled = true; };//HABILITAR VENTANA PRINCIPAL APENAS SE CIERRE

                    //LA POSICIÓN PRINCIPAL SERÁ FIJADA POR LA UBICACIÓN MANUAL
                    nvC.StartPosition = FormStartPosition.CenterScreen;

                    //CALCULAR POSICIÓN DE ACUERDO AL TAMAÑO DE LA VENTANA PRINCIPAL
                    //nvS.Location = 
                    //new System.Drawing.Point(mod.Left + (mod.Width - nvS.Width) / 2,
                    //                     mod.Top + (mod.Height - nvS.Height) / 2);

                    //TAMAÑO MAS PEQUEÑO
                    nvC.Size = new System.Drawing.Size(548, 516);

                    //MOSTRAR MODAL SOBRE EL FORMULARIO DE SOMBRA
                    nvC.ShowDialog();

                    //CUANDO SE CIERRE EL MODAL, MOSTRAR LA VENTANA PRINCIPAL
                    this.BringToFront();

                    if (al == Acciones_list.AgregarMen || al == Acciones_list.AgregarMay)
                    {
                        if (nvC.DialogResult == DialogResult.OK)
                        {
                            //OBTENER EL OBJETO CON INFORMACIÓN Y AGREGARLO A LA BASE DE DATOS
                            daoML.AddConjunto(nvC.conjunto);
                            //MODIFICAR EL SMP EN TODOS LOS COMPONENTES
                            daoML.EditSmpComponents(nvC.conjunto);
                        }
                    }
                    else
                    {
                        if (nvC.DialogResult == DialogResult.OK)
                        {
                            //OBTENER EL OBJETO CON INFORMACIÓN Y EDITARLO EN LA BASE DE DATOS
                            daoML.EditConjunto(nvC.conjunto);
                            //MODIFICAR EL SMP EN TODOS LOS COMPONENTES
                            daoML.EditSmpComponents(nvC.conjunto);
                        }

                        //tlpSistemas.Visible = false;
                    }
                    nvC.Dispose();

                    tlpDetalles.Visible = false;

                    if (!bgLoad.IsBusy)
                    {
                        splash.Show();
                        bgLoad.RunWorkerAsync();
                    }
                }
            }
        }

        private void setDetails(string image, string nombre, tipos tipo)
        {
            using (FileStream fileStream = new FileStream(image, FileMode.Open))
            {
                pbImage.Image = new Bitmap(fileStream);
            }
            
            lvOpciones.Items.Clear();
            lblNombre.Text = nombre;

            if (tipo == tipos.Maquina)
            {
                type_selected = 0;
                ListViewItem lviEditar = new ListViewItem();
                lviEditar.Text = "Editar maquina";
                lviEditar.ImageIndex = 1;
                lviEditar.Tag = Acciones_list.Editar;
                lvOpciones.Items.Add(lviEditar);

                ListViewItem lviEliminar = new ListViewItem();
                lviEliminar.Text = "Eliminar maquina";
                lviEliminar.ImageIndex = 2;
                lviEliminar.Tag = Acciones_list.Eliminar;
                lvOpciones.Items.Add(lviEliminar);

                ListViewItem lviAgregarMaq = new ListViewItem();
                lviAgregarMaq.Text = "Agregar nueva maquina";
                lviAgregarMaq.ImageIndex = 3;
                lviAgregarMaq.Tag = Acciones_list.AgregarMay;
                lvOpciones.Items.Add(lviAgregarMaq);

                ListViewItem lviAgregarSis = new ListViewItem();
                lviAgregarSis.Text = "Agregar nuevo sistema a esta máquina";
                lviAgregarSis.ImageIndex = 4;
                lviAgregarSis.Tag = Acciones_list.AgregarMen;
                lvOpciones.Items.Add(lviAgregarSis);
            }

            if (tipo == tipos.Sistema)
            {
                type_selected = 1;
                ListViewItem lviEditar = new ListViewItem();
                lviEditar.Text = "Editar sistema";
                lviEditar.ImageIndex = 1;
                lviEditar.Tag = Acciones_list.Editar;
                lvOpciones.Items.Add(lviEditar);

                ListViewItem lviEliminar = new ListViewItem();
                lviEliminar.Text = "Eliminar sistema";
                lviEliminar.ImageIndex = 2;
                lviEliminar.Tag = Acciones_list.Eliminar;
                lvOpciones.Items.Add(lviEliminar);

                ListViewItem lviAgregarMa = new ListViewItem();
                lviAgregarMa.Text = "Agregar nuevo sistema";
                lviAgregarMa.ImageIndex = 4;
                lviAgregarMa.Tag = Acciones_list.AgregarMay;
                lvOpciones.Items.Add(lviAgregarMa);

                ListViewItem lviAgregarMe = new ListViewItem();
                lviAgregarMe.Text = "Agregar nuevo conjunto a este sistema";
                lviAgregarMe.ImageIndex = 5;
                lviAgregarMe.Tag = Acciones_list.AgregarMen;
                lvOpciones.Items.Add(lviAgregarMe);
            }

            if (tipo == tipos.Conjunto)
            {
                type_selected = 2;
                ListViewItem lviEditar = new ListViewItem();
                lviEditar.Text = "Editar conjunto";
                lviEditar.ImageIndex = 1;
                lviEditar.Tag = Acciones_list.Editar;
                lvOpciones.Items.Add(lviEditar);

                ListViewItem lviEliminar = new ListViewItem();
                lviEliminar.Text = "Eliminar conjunto";
                lviEliminar.ImageIndex = 2;
                lviEliminar.Tag = Acciones_list.Eliminar;
                lvOpciones.Items.Add(lviEliminar);

                ListViewItem lviAgregarMa = new ListViewItem();
                lviAgregarMa.Text = "Agregar nuevo conjunto";
                lviAgregarMa.ImageIndex = 5;
                lviAgregarMa.Tag = Acciones_list.AgregarMay;
                lvOpciones.Items.Add(lviAgregarMa);

                ListViewItem lviAgregarMe = new ListViewItem();
                lviAgregarMe.Text = "Administrar componentes de este conjunto";
                lviAgregarMe.ImageIndex = 6;
                lviAgregarMe.Tag = Acciones_list.AgregarMen;
                lvOpciones.Items.Add(lviAgregarMe);
            }
        }

        /// <summary>
        /// CUANDO SE SELECCIONA UNA MAQUINA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMaquinas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {            
            //SI ETÁ SELECCIONADO AL MENOS UNO
            if (lvMaquinas.SelectedItems.Count == 1)
            {
                if (!bgLoadSistemas.IsBusy)
                {
                    splash.Show();
                    bgLoadSistemas.RunWorkerAsync();
                }
            }
            else
            {
                tlpSistemas.Visible = false;
                tlpConjuntos.Visible = false;
                tlpDetalles.Visible = false;
                maquina = "...";                
            }

            SetName();
        }
       
        private void lvSistemas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvSistemas.SelectedItems.Count == 1)
            {
                tlpDetalles.Visible = true;

                if (!bgLoadConjuntos.IsBusy)
                {
                    splash.Show();
                    bgLoadConjuntos.RunWorkerAsync();
                }
            }
            else
            {
                tlpDetalles.Visible = false;

                if (lvMaquinas.SelectedItems.Count > 0)
                {
                    Machines machine_selected = (Machines)lvMaquinas.SelectedItems[0].Tag as Machines;
                    maquina = machine_selected.nombre;
                    sistema = "...";
                    conjunto = "...";
                }
                else
                {
                    maquina = "...";                    
                }                
            }

            SetName();
        }

        private void lvConjuntos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvConjuntos.SelectedItems.Count == 1)
            {
                try
                {
                    Conjuntos conjunto_selected = (Conjuntos)lvConjuntos.SelectedItems[0].Tag as Conjuntos;
                    conjunto = conjunto_selected.nombre;
                    SetName();

                    setDetails(Global.DIRECTORIO_IMAGENES + @"\" + conjunto_selected.image_path, conjunto_selected.nombre, tipos.Conjunto);                    

                    tlpDetalles.Visible = true;
                }
                catch (Exception EX)
                {
                    MessageBox.Show("error: " + EX.ToString());
                }
            }
            else
            {
                tlpDetalles.Visible = false;
            }
        }

        /// <summary>
        /// ESCRIBE LA RUTA DE CADA ELEMENTO SELECIONADO
        /// </summary>
        private void SetName()
        {
            if (maquina.Equals("..."))
            {
                lblSelected.Text = planta.nombre;
            }
            else if (sistema.Equals("..."))
            {
                lblSelected.Text = planta.nombre + " → " + maquina;
            }
            else if (conjunto.Equals("..."))
            {
                lblSelected.Text = planta.nombre + " → " + maquina + " → " + sistema;
            }
            else
            {
                lblSelected.Text = planta.nombre + " → " + maquina + " → " + sistema + " → " + conjunto;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            if (texto_busq.Equals(txt.Text))
                txt.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            if (String.IsNullOrWhiteSpace(txt.Text))
                txt.Text = texto_busq;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!texto_busq.Equals(txtBuscarSistemas.Text.Trim()))
            {
                lvSistemas.Items.Clear(); // clear list items before adding 
                                          // filter the items match with search key and add result to list view 
                lvSistemas.Items.AddRange(listSubSytems.Where(i => string.IsNullOrEmpty(txtBuscarSistemas.Text) || i.nombre.ToLower().StartsWith(txtBuscarSistemas.Text.ToLower()))
                    .Select(c => new ListViewItem() { ImageKey = c.image_path, Text = c.nombre, Tag = c }).ToArray());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!texto_busq.Equals(txtBuscarConjunto.Text.Trim()))
            {
                lvConjuntos.Items.Clear(); // clear list items before adding 
                                           // filter the items match with search key and add result to list view 
                lvConjuntos.Items.AddRange(listConjuntos.Where(i => string.IsNullOrEmpty(txtBuscarConjunto.Text) || i.nombre.ToLower().StartsWith(txtBuscarConjunto.Text.ToLower()))
                    .Select(c => new ListViewItem() { ImageKey = c.image_path, Text = c.nombre, Tag = c }).ToArray());
            }
        }

        private void lvOpciones_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvOpciones.SelectedItems.Count == 1)
            {
                ListViewItem lviOptionSeleted = lvOpciones.SelectedItems[0];
                Acciones_list opSel = (Acciones_list)lviOptionSeleted.Tag;
                
                switch (opSel)
                {
                    case Acciones_list.AgregarMay:
                        switch (type_selected)
                        {
                            //MAQUINAS
                            case 0:
                                CreateFormModalMachines(opSel,null);
                                break;
                            //SISTEMAS
                            case 1:
                                CreateFormModalSystem(opSel, null,null);
                                break;
                            //CONJUNTOS
                            case 2:
                                ListViewItem lv_edit_co = lvConjuntos.SelectedItems[0];
                                Conjuntos con = (Conjuntos)lv_edit_co.Tag;
                                CreateFormModalConjuntos(opSel, listSubSytems.Where(x => x.id == con.id_sistema).First(), null);
                                break;
                            default:
                                break;
                        }
                        break;
                    case Acciones_list.AgregarMen:
                        switch (type_selected)
                        {
                            //MAQUINA
                            case 0:
                                ListViewItem lvi = lvMaquinas.SelectedItems[0];
                                Machines m = (Machines)lvi.Tag;                                
                                CreateFormModalSystem(opSel, m,null);
                                
                                break;
                            //SISTEMA
                            case 1:
                                ListViewItem lvi_sis = lvSistemas.SelectedItems[0];
                                Sistemas sis = (Sistemas)lvi_sis.Tag;
                                CreateFormModalConjuntos(opSel, sis, null);
                                break;
                            case 2:
                                //var compWin = new CalendarioPMBiBlio.Calendar();
                                //ElementHost.EnableModelessKeyboardInterop(compWin);
                                //compWin.Show();
                                ListViewItem lvi_s = lvConjuntos.SelectedItems[0];
                                Conjuntos cc = (Conjuntos)lvi_s.Tag;
                                Util.Global.conjunto = cc;
                                CalendarioPm cpm = new CalendarioPm();
                                cpm.ShowDialog();
                                cpm.Dispose();
                                cpm = null;
                                GC.Collect();
                                break;
                            default:
                                break;
                        }
                        break;                        
                    case Acciones_list.Editar:
                        switch (type_selected)
                        {
                            case 0:                               
                                ListViewItem lvi = lvMaquinas.SelectedItems[0];
                                Machines m = (Machines)lvi.Tag;
                                CreateFormModalMachines(opSel,m);
                                break;
                            case 1:
                                ListViewItem lv = lvSistemas.SelectedItems[0];
                                Sistemas sis = (Sistemas)lv.Tag;
                                CreateFormModalSystem(opSel, null,sis);
                                break;
                                //CONJUNTOS
                            case 2:
                                ListViewItem lv_edit_co = lvConjuntos.SelectedItems[0];
                                Conjuntos con = (Conjuntos)lv_edit_co.Tag;
                                CreateFormModalConjuntos(opSel, listSubSytems.Where(x => x.id == con.id_sistema).First(), con);
                                break;
                            default:
                                break;
                        }
                        break;
                    case Acciones_list.Eliminar:
                        switch (type_selected)
                        {
                            //MAQUINA
                            case 0:
                                ListViewItem lvi = lvMaquinas.SelectedItems[0];
                                Machines m = (Machines)lvi.Tag;
                                CreateFormModalMachines(opSel, m);
                                break;
                            case 1:
                                ListViewItem lv = lvSistemas.SelectedItems[0];
                                Sistemas sis_del = (Sistemas)lv.Tag;
                                CreateFormModalSystem(opSel, null,sis_del);
                                break;
                            //CONJUNTOS
                            case 2:
                                ListViewItem lv_eli = lvConjuntos.SelectedItems[0];
                                Conjuntos con_del = (Conjuntos)lv_eli.Tag;
                                CreateFormModalConjuntos(opSel, listSubSytems.Where(x => x.id == con_del.id_sistema).First(), con_del);
                                break;
                            default:
                                break;
                        }
                        break;                        
                    default:
                        break;
                }                
            }            
        }

        private void BgLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //CARGAR LA LISTA DE MAQUINAS DEL SISTEMA
                listMachines = daoML.GetMachines(Global.selected_line.id);
                lvMaquinas.Items.Clear();
                //COPIAR FOTOS DE RECURSOS A CARPETA DE IMÁGENES
                //ITERACCION PARA ESTA ACCIÓN Y LLENADO DE LISTA<
                foreach (Machines mach in listMachines)
                {                    
                    //VERIFICAR SI LA IMÁGEN DE LA BASE DE DATOS EXISTE EN LA CARPERTA DE IMAGENES
                    if (File.Exists(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.foto))
                    {
                        Application.DoEvents();

                        if (!imagesMachines.Images.ContainsKey(mach.foto))
                        {                            
                            ///PARA EL CORRECTO FUNCIONAMIENTO DEL LISTVIEW CON LAS IMAGENES ES NECESARIO USAR
                            ///UN IMAGE LIST Y LLENARLO CON LAS IMAGENES A MOSTRAR, SE CARGAN LAS IMAGENES DE CADA
                            ///ELEMENTO DE LA LISTA CON SU RESPECTIVO NOMBRE
                            using (var bmpTemp = new Bitmap(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.foto))
                            {
                                imagesMachines.Images.Add(mach.foto, bmpTemp);
                            }
                        }                        
                    }
                    else
                    {
                        //SI LA IMÁGEN NO NO EXISTE, SE CARGA POR DEFECTO EL LOGO DEL ÁREA DE LA COMPAÑÍA,
                        //QUE DESPUES PUEDE SER SUSTITUIDA
                        imagesMachines.Images.Add(mach.foto, Properties.Resources.hpc_logo);
                    }

                    //CONSTRUYENDO LISTVIEWITEMS A PARTIR DE LOS OBJETOS
                    //LOS LISTVIEWS SOLO PUEDEN SER CARGADOS CON ESTA CLASE
                    lvMaquinas.Items.Add(new ListViewItem()
                    {
                        Text = mach.nombre,
                        ImageKey = mach.foto,
                        //EN EL TAG DEL ITEM SE GUARDA EL OBJETO
                        Tag = mach
                    });
                }
            });
        }

        private void bgLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            //REFRESCAR LISTA
            lvMaquinas.Refresh();

            //CARAGAR EL TEXTO DE BUSQUEDA
            txtBuscarConjunto.Text = texto_busq;
            txtBuscarSistemas.Text = texto_busq;
                        
            tlpDetalles.Visible = false;

            lblMaquinas.Text = "Máquinas: "+listMachines.Count;
            splash.Hide();
        }

        private void gbLoadSistemas_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //LIMPIAR LA LISTA DE SISTEMAS Y CONJUNTOS
                if (lvSistemas.Items.Count> 0)
                {
                    lvSistemas.Items.Clear();
                }

                if (lvConjuntos.Items.Count > 0)
                {
                    lvConjuntos.Items.Clear();
                }

                //OBTENER EL ITEM SELECCIONADO
                ListViewItem lvi = lvMaquinas.SelectedItems[0];
                //CONVERTIR A OBJETO EL ITEM SELECCIONADO
                Machines ms = (Machines)lvi.Tag;
                //OBTENER LA LISTA DE SISTEMAS A PARTIR DEL ID DEL OBJETO SELECCIONADO
                listSubSytems = daoML.GetSystems(ms.id);
                //ESTABLECER NOMBRE DE LOS ELEMENTOS SELECCIONADOS
                maquina = ms.nombre;
                
                sistema = "...";
                conjunto = "...";

            //PROCESO PARA CARGAR IMAGENES E ITEMS A LA LISTA
            foreach (Sistemas mach in listSubSytems)
            {
                    //AGREGAR IMAGEN EN MINIATURA EN CADA ELEMENTO DE LA LISTA CONSUME 
                    //DEMASIADO RECURSOS, POR LO TANTO ESTE PROCESO SE CANCELA Y SE VA USAR EL LOGO DE HPC PALMIRA
                    //PARA AHORRAR RECURSOS, YA QUE NO ES IMPORTANTE MOSTRAR LA IMAGEN EN MINIATURA 
                    //EN SISTEMAS
                    //    if (File.Exists(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path))
                    //    {
                    //        if (!imagesSubSystems.Images.ContainsKey(mach.image_path))
                    //        {
                    //            imagesSubSystems.Images.Add(mach.image_path, Image.FromFile(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path));
                    //            //using (var bmpTemp = new Bitmap(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path))
                    //            //{
                    //            //    imagesSubSystems.Images.Add(mach.image_path, bmpTemp);
                    //            //}
                    //        }
                    //    }
                    //    else
                    //    {
                    if (!imagesSubSystems.Images.ContainsKey(Properties.Resources.hpc_logo.ToString()))
                    {
                        imagesSubSystems.Images.Add(Properties.Resources.hpc_logo.ToString(), Properties.Resources.hpc_logo);
                    }
                    //    }

                    lvSistemas.Items.Add(new ListViewItem()
                    {
                        Text = mach.nombre,
                        ImageIndex = 0,
                        Tag = mach
                    });
                }

                if (e.Argument == null)
                {
                    setDetails(Global.DIRECTORIO_IMAGENES + @"\" + ms.foto, ms.nombre, tipos.Maquina);                    
                }
            });
        }

        private void gbLoadSistemas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvSistemas.Refresh();
            tlpDetalles.Visible = true;
            if (listSubSytems.Count > 0)
            {
                tlpSistemas.Visible = true;
            }
            else
            {
                tlpConjuntos.Visible = false;
                tlpSistemas.Visible = false;
            }

            lblSistemas.Text = "Sistemas: " + listSubSytems.Count;
            SetName();

            splash.Hide();
        }

        private void BgLoadConjuntos_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    Sistemas system_selected = (Sistemas)lvSistemas.SelectedItems[0].Tag as Sistemas;
                    sistema = system_selected.nombre;
                    conjunto = "...";                    

                    lvConjuntos.Items.Clear();
                    listConjuntos = daoML.GetConjuntos(system_selected.id);

                    foreach (Conjuntos mach in listConjuntos)
                    {
                        if (File.Exists(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path))
                        {
                            if (!imagesConjuntos.Images.ContainsKey(mach.image_path))
                            {
                                FileStream stream = new FileStream(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path, FileMode.Open, FileAccess.Read);                                
                                imagesConjuntos.Images.Add(mach.image_path, Image.FromStream(stream));
                                stream.Close();
                                //imagesConjuntos.Images.Add(mach.image_path, Image.FromFile(Util.Global.DIRECTORIO_IMAGENES + @"\" + mach.image_path));
                            }
                        }
                        else
                        {
                            imagesConjuntos.Images.Add(mach.image_path, Properties.Resources.hpc_logo);
                        }

                        lvConjuntos.Items.Add(new ListViewItem()
                        {
                            Text = mach.nombre,
                            ImageKey = mach.image_path,
                            Tag = mach
                        });

                        //pbImage.Image = listMachines[int.Parse(lvi.Tag.ToString()) - 1].foto_max;
                    }

                    if (e.Argument == null)
                    {         
                        setDetails(Global.DIRECTORIO_IMAGENES + @"\" + system_selected.image_path, system_selected.nombre, tipos.Sistema);                       
                    }
                    ////MOSTRAR ARCHIVO MIENTRAS SE UTILIZA
                    //xlApp.Visible = true;
                    //xlApp.WindowState = XlWindowState.xlMaximized;

                    ////DIRECTORIO DONDE SE COPIARÁ EL ARCHIVO TEMPORALMENTE
                    ////PARA EDITARLO
                    //path = Properties.Settings.Default["MachineLedger"].ToString();

                    ////CREAR EL OBJETO DEL LIBRO A PARTIR DE LA RUTA 
                    //wb = xlApp.Workbooks.Open(path);
                    ////FIJAR EN OBJETOS LAS PESTAÑAS U HOJA DEL LIBRO PARA TRABAJAR
                    //Worksheet ws2 = (Worksheet)wb.Worksheets[lvSistemas.Items.IndexOf(lvSistemas.SelectedItems[0]) + 1];
                    //ws2.Activate();

                    ////MINIMIZAR PANTALLA
                    //this.WindowState = FormWindowState.Minimized;
                }
                catch (Exception EX)
                {
                    MessageBox.Show("error: " + EX.ToString());
                }
            });
        }

        private void BgLoadConjuntos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvConjuntos.Refresh();            

            if (listConjuntos.Count > 0)
            {
                tlpConjuntos.Visible = true;
            }
            else
            {
                tlpConjuntos.Visible = false;
            }

            lblConjuntos.Text = "Conjuntos: " + listConjuntos.Count;
            SetName();

            splash.Hide();
        }

        private void cmsMaquina_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {            
            if (e.ClickedItem == tsmDuplicar)
            {
                Machines machine_selected = (Machines)lvMaquinas.SelectedItems[0].Tag as Machines;

                if (machine_selected != null)
                {
                    FormCopySelector fcs = new FormCopySelector(machine_selected.id);                    
                    fcs.ShowDialog();
                }
                
            }
            else
            {
                CreateFormModalMachines(Acciones_list.AgregarMay, null);
            }            
        }

        private void MachineLedger_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateModalLineas();
        }

        private void lvMaquinas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (!bgLoad.IsBusy)
                {
                    splash.Show();
                    bgLoad.RunWorkerAsync();
                }
            }
        }
    }
}
