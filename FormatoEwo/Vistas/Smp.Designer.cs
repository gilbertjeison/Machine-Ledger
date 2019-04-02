using MetroFramework.Controls;

namespace FormatoEwo.Vistas
{
    partial class Smp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Smp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tecnicosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ewoDatabaseDataSet = new FormatoEwo.EwoDatabaseDataSet();
            this.tecnicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.arealineaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equiposBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EppsImages = new System.Windows.Forms.ImageList(this.components);
            this.equiposTableAdapter = new FormatoEwo.EwoDatabaseDataSetTableAdapters.equiposTableAdapter();
            this.area_lineaTableAdapter = new FormatoEwo.EwoDatabaseDataSetTableAdapters.area_lineaTableAdapter();
            this.tecnicosTableAdapter = new FormatoEwo.EwoDatabaseDataSetTableAdapters.tecnicosTableAdapter();
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.cmsImagen2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen2 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsImagen1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.RiskImages = new System.Windows.Forms.ImageList(this.components);
            this.tabPasoPaso = new System.Windows.Forms.TabPage();
            this.btnEditar = new MetroFramework.Controls.MetroButton();
            this.label23 = new System.Windows.Forms.Label();
            this.btnPaso = new MetroFramework.Controls.MetroButton();
            this.lblPaPCargados = new System.Windows.Forms.Label();
            this.dtgPasoAPaso = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabRepuestos = new System.Windows.Forms.TabPage();
            this.dtgRep = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblCargados = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.tabHerramientas = new System.Windows.Forms.TabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.lblCargadas = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtgHerr = new System.Windows.Forms.DataGridView();
            this.sel_herr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramienta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.tabEpps = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgEpps = new System.Windows.Forms.DataGridView();
            this.seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabInformacionBasica = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConsecutivo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chlbPermisosRequeridos = new System.Windows.Forms.CheckedListBox();
            this.rbLotoNo = new System.Windows.Forms.RadioButton();
            this.rbLotoSi = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNombreSMP = new System.Windows.Forms.TextBox();
            this.txtTecnicosRequeridos = new System.Windows.Forms.TextBox();
            this.cboFrecuencia = new System.Windows.Forms.ComboBox();
            this.txtFrecuencia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTiempoEquipoParado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDuracionActividad = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAprobador = new System.Windows.Forms.ComboBox();
            this.cboTipoMtto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label69 = new System.Windows.Forms.Label();
            this.cboElaborador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAreaLinea = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEquipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboClasificación = new System.Windows.Forms.ComboBox();
            this.txtSMP = new System.Windows.Forms.TextBox();
            this.gbImagenes = new System.Windows.Forms.GroupBox();
            this.pbImg2 = new System.Windows.Forms.PictureBox();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.tabcontrol = new MetroFramework.Controls.MetroTabControl();
            this.btnSiguiente1 = new System.Windows.Forms.Button();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.label67 = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGenerando = new System.Windows.Forms.Label();
            this.RiksImages = new System.Windows.Forms.ImageList(this.components);
            this.bgSaveData = new System.ComponentModel.BackgroundWorker();
            this.pbGenerando = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.lblPorFavor = new System.Windows.Forms.Label();
            this.chkPDF = new MetroFramework.Controls.MetroCheckBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.ewoDatabaseDataSet1 = new FormatoEwo.EwoDatabaseDataSet();
            this.ewoDatabaseDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eppsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eppsTableAdapter = new FormatoEwo.EwoDatabaseDataSetTableAdapters.eppsTableAdapter();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tecnicosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tecnicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arealineaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiposBindingSource)).BeginInit();
            this.cmsImagen2.SuspendLayout();
            this.cmsImagen1.SuspendLayout();
            this.tabPasoPaso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPasoAPaso)).BeginInit();
            this.tabRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRep)).BeginInit();
            this.tabHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).BeginInit();
            this.tabEpps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEpps)).BeginInit();
            this.tabInformacionBasica.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbImagenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.tabcontrol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eppsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tecnicosBindingSource1
            // 
            this.tecnicosBindingSource1.DataMember = "tecnicos";
            this.tecnicosBindingSource1.DataSource = this.ewoDatabaseDataSet;
            // 
            // ewoDatabaseDataSet
            // 
            this.ewoDatabaseDataSet.DataSetName = "EwoDatabaseDataSet";
            this.ewoDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tecnicosBindingSource
            // 
            this.tecnicosBindingSource.DataMember = "tecnicos";
            this.tecnicosBindingSource.DataSource = this.ewoDatabaseDataSet;
            // 
            // arealineaBindingSource
            // 
            this.arealineaBindingSource.DataMember = "area_linea";
            this.arealineaBindingSource.DataSource = this.ewoDatabaseDataSet;
            // 
            // equiposBindingSource
            // 
            this.equiposBindingSource.DataMember = "equipos";
            this.equiposBindingSource.DataSource = this.ewoDatabaseDataSet;
            // 
            // EppsImages
            // 
            this.EppsImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("EppsImages.ImageStream")));
            this.EppsImages.TransparentColor = System.Drawing.Color.Transparent;
            this.EppsImages.Images.SetKeyName(0, "image001.png");
            this.EppsImages.Images.SetKeyName(1, "image003.png");
            this.EppsImages.Images.SetKeyName(2, "image005.png");
            this.EppsImages.Images.SetKeyName(3, "image007.png");
            this.EppsImages.Images.SetKeyName(4, "image009.png");
            this.EppsImages.Images.SetKeyName(5, "image011.png");
            this.EppsImages.Images.SetKeyName(6, "image013.png");
            this.EppsImages.Images.SetKeyName(7, "image015.png");
            this.EppsImages.Images.SetKeyName(8, "image017.png");
            this.EppsImages.Images.SetKeyName(9, "image019.png");
            this.EppsImages.Images.SetKeyName(10, "image021.png");
            this.EppsImages.Images.SetKeyName(11, "image023.png");
            this.EppsImages.Images.SetKeyName(12, "image025.png");
            this.EppsImages.Images.SetKeyName(13, "image027.png");
            this.EppsImages.Images.SetKeyName(14, "image029.png");
            this.EppsImages.Images.SetKeyName(15, "image031.png");
            this.EppsImages.Images.SetKeyName(16, "image033.png");
            this.EppsImages.Images.SetKeyName(17, "image035.png");
            this.EppsImages.Images.SetKeyName(18, "image037.png");
            this.EppsImages.Images.SetKeyName(19, "image039.png");
            this.EppsImages.Images.SetKeyName(20, "image041.png");
            this.EppsImages.Images.SetKeyName(21, "image043.png");
            this.EppsImages.Images.SetKeyName(22, "image044.png");
            this.EppsImages.Images.SetKeyName(23, "image045.png");
            this.EppsImages.Images.SetKeyName(24, "image047.png");
            this.EppsImages.Images.SetKeyName(25, "image049.png");
            this.EppsImages.Images.SetKeyName(26, "image051.png");
            this.EppsImages.Images.SetKeyName(27, "image053.png");
            this.EppsImages.Images.SetKeyName(28, "image055.png");
            this.EppsImages.Images.SetKeyName(29, "image057.png");
            this.EppsImages.Images.SetKeyName(30, "image059.png");
            this.EppsImages.Images.SetKeyName(31, "image061.png");
            this.EppsImages.Images.SetKeyName(32, "image063.png");
            // 
            // equiposTableAdapter
            // 
            this.equiposTableAdapter.ClearBeforeFill = true;
            // 
            // area_lineaTableAdapter
            // 
            this.area_lineaTableAdapter.ClearBeforeFill = true;
            // 
            // tecnicosTableAdapter
            // 
            this.tecnicosTableAdapter.ClearBeforeFill = true;
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgLoad_RunWorkerCompleted);
            // 
            // cmsImagen2
            // 
            this.cmsImagen2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsImagen2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerImagen2,
            this.itemQuitarImagen2});
            this.cmsImagen2.Name = "cmsImagen1";
            this.cmsImagen2.Size = new System.Drawing.Size(151, 48);
            this.cmsImagen2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsImagen2_ItemClicked);
            // 
            // tsmVerImagen2
            // 
            this.tsmVerImagen2.Name = "tsmVerImagen2";
            this.tsmVerImagen2.Size = new System.Drawing.Size(150, 22);
            this.tsmVerImagen2.Text = "Ver imágen";
            // 
            // itemQuitarImagen2
            // 
            this.itemQuitarImagen2.Name = "itemQuitarImagen2";
            this.itemQuitarImagen2.Size = new System.Drawing.Size(150, 22);
            this.itemQuitarImagen2.Text = "Quitar imágen";
            // 
            // cmsImagen1
            // 
            this.cmsImagen1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsImagen1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerImagen,
            this.itemQuitarImagen});
            this.cmsImagen1.Name = "cmsImagen1";
            this.cmsImagen1.Size = new System.Drawing.Size(151, 48);
            this.cmsImagen1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsImagen1_ItemClicked);
            // 
            // tsmVerImagen
            // 
            this.tsmVerImagen.Name = "tsmVerImagen";
            this.tsmVerImagen.Size = new System.Drawing.Size(150, 22);
            this.tsmVerImagen.Text = "Ver imágen";
            // 
            // itemQuitarImagen
            // 
            this.itemQuitarImagen.Name = "itemQuitarImagen";
            this.itemQuitarImagen.Size = new System.Drawing.Size(150, 22);
            this.itemQuitarImagen.Text = "Quitar imágen";
            // 
            // RiskImages
            // 
            this.RiskImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RiskImages.ImageStream")));
            this.RiskImages.TransparentColor = System.Drawing.Color.Transparent;
            this.RiskImages.Images.SetKeyName(0, "trabajo_caliente.png");
            this.RiskImages.Images.SetKeyName(1, "trabajo_alturas.png");
            this.RiskImages.Images.SetKeyName(2, "sustancias_quimicas.png");
            this.RiskImages.Images.SetKeyName(3, "excavaciones.png");
            this.RiskImages.Images.SetKeyName(4, "energia_cero.png");
            this.RiskImages.Images.SetKeyName(5, "trabajo_subestacion.png");
            this.RiskImages.Images.SetKeyName(6, "espacio_confinado.png");
            this.RiskImages.Images.SetKeyName(7, "trafico_montacargas.png");
            this.RiskImages.Images.SetKeyName(8, "atrapamiento.jpg");
            this.RiskImages.Images.SetKeyName(9, "levantamiento_carga.png");
            this.RiskImages.Images.SetKeyName(10, "herramientas_equipos.png");
            // 
            // tabPasoPaso
            // 
            this.tabPasoPaso.AutoScroll = true;
            this.tabPasoPaso.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.tabPasoPaso.BackColor = System.Drawing.Color.Azure;
            this.tabPasoPaso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPasoPaso.Controls.Add(this.btnEditar);
            this.tabPasoPaso.Controls.Add(this.label23);
            this.tabPasoPaso.Controls.Add(this.btnPaso);
            this.tabPasoPaso.Controls.Add(this.lblPaPCargados);
            this.tabPasoPaso.Controls.Add(this.dtgPasoAPaso);
            this.tabPasoPaso.Location = new System.Drawing.Point(4, 35);
            this.tabPasoPaso.Margin = new System.Windows.Forms.Padding(2);
            this.tabPasoPaso.Name = "tabPasoPaso";
            this.tabPasoPaso.Padding = new System.Windows.Forms.Padding(2);
            this.tabPasoPaso.Size = new System.Drawing.Size(578, 711);
            this.tabPasoPaso.TabIndex = 4;
            this.tabPasoPaso.Text = "Paso a paso";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(461, 72);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(117, 24);
            this.btnEditar.TabIndex = 18;
            this.btnEditar.Text = "Editar paso";
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(15, 75);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 17);
            this.label23.TabIndex = 17;
            this.label23.Text = "Agregado(s)";
            // 
            // btnPaso
            // 
            this.btnPaso.Location = new System.Drawing.Point(216, 41);
            this.btnPaso.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(117, 24);
            this.btnPaso.TabIndex = 16;
            this.btnPaso.Text = "Nuevo paso ";
            this.btnPaso.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lblPaPCargados
            // 
            this.lblPaPCargados.AutoSize = true;
            this.lblPaPCargados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaPCargados.ForeColor = System.Drawing.Color.Black;
            this.lblPaPCargados.Location = new System.Drawing.Point(91, 79);
            this.lblPaPCargados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaPCargados.Name = "lblPaPCargados";
            this.lblPaPCargados.Size = new System.Drawing.Size(14, 14);
            this.lblPaPCargados.TabIndex = 15;
            this.lblPaPCargados.Text = "0";
            // 
            // dtgPasoAPaso
            // 
            this.dtgPasoAPaso.AllowUserToAddRows = false;
            this.dtgPasoAPaso.AllowUserToDeleteRows = false;
            this.dtgPasoAPaso.BackgroundColor = System.Drawing.Color.White;
            this.dtgPasoAPaso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPasoAPaso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewImageColumn3,
            this.foto,
            this.categoria,
            this.imagen_path});
            this.dtgPasoAPaso.Location = new System.Drawing.Point(10, 98);
            this.dtgPasoAPaso.Margin = new System.Windows.Forms.Padding(2);
            this.dtgPasoAPaso.MultiSelect = false;
            this.dtgPasoAPaso.Name = "dtgPasoAPaso";
            this.dtgPasoAPaso.RowTemplate.Height = 180;
            this.dtgPasoAPaso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPasoAPaso.Size = new System.Drawing.Size(563, 673);
            this.dtgPasoAPaso.TabIndex = 14;
            this.dtgPasoAPaso.Visible = false;
            this.dtgPasoAPaso.SelectionChanged += new System.EventHandler(this.dtgPasoAPaso_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "paso";
            this.dataGridViewTextBoxColumn2.HeaderText = "Paso a Paso";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "duracion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Duración";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "categoria_img";
            this.dataGridViewTextBoxColumn4.HeaderText = "Categoría";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn3.DataPropertyName = "desc";
            this.dataGridViewImageColumn3.HeaderText = "Descripción";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // foto
            // 
            this.foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.foto.DataPropertyName = "imagen_paso";
            this.foto.HeaderText = "Fotografía";
            this.foto.Name = "foto";
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoria.DataPropertyName = "categoria";
            this.categoria.HeaderText = "categoria";
            this.categoria.Name = "categoria";
            this.categoria.Visible = false;
            // 
            // imagen_path
            // 
            this.imagen_path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.imagen_path.DataPropertyName = "imagen_paso_path";
            this.imagen_path.HeaderText = "imagen_path";
            this.imagen_path.Name = "imagen_path";
            this.imagen_path.Visible = false;
            // 
            // tabRepuestos
            // 
            this.tabRepuestos.AutoScroll = true;
            this.tabRepuestos.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.tabRepuestos.BackColor = System.Drawing.Color.Azure;
            this.tabRepuestos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabRepuestos.Controls.Add(this.dtgRep);
            this.tabRepuestos.Controls.Add(this.lblCargados);
            this.tabRepuestos.Controls.Add(this.label21);
            this.tabRepuestos.Controls.Add(this.label22);
            this.tabRepuestos.Controls.Add(this.button1);
            this.tabRepuestos.Location = new System.Drawing.Point(4, 35);
            this.tabRepuestos.Margin = new System.Windows.Forms.Padding(2);
            this.tabRepuestos.Name = "tabRepuestos";
            this.tabRepuestos.Padding = new System.Windows.Forms.Padding(2);
            this.tabRepuestos.Size = new System.Drawing.Size(578, 711);
            this.tabRepuestos.TabIndex = 3;
            this.tabRepuestos.Text = "Repuestos";
            // 
            // dtgRep
            // 
            this.dtgRep.AllowUserToAddRows = false;
            this.dtgRep.BackgroundColor = System.Drawing.Color.White;
            this.dtgRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.repuesto,
            this.cantidad,
            this.dataGridViewImageColumn2});
            this.dtgRep.Location = new System.Drawing.Point(14, 96);
            this.dtgRep.Margin = new System.Windows.Forms.Padding(2);
            this.dtgRep.MultiSelect = false;
            this.dtgRep.Name = "dtgRep";
            this.dtgRep.RowTemplate.Height = 180;
            this.dtgRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRep.Size = new System.Drawing.Size(563, 674);
            this.dtgRep.TabIndex = 23;
            this.dtgRep.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // repuesto
            // 
            this.repuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.repuesto.DataPropertyName = "repuesto";
            this.repuesto.HeaderText = "Repuesto";
            this.repuesto.Name = "repuesto";
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 90;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn2.DataPropertyName = "imagen";
            this.dataGridViewImageColumn2.HeaderText = "Imágen";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // lblCargados
            // 
            this.lblCargados.AutoSize = true;
            this.lblCargados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargados.ForeColor = System.Drawing.Color.Black;
            this.lblCargados.Location = new System.Drawing.Point(86, 78);
            this.lblCargados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargados.Name = "lblCargados";
            this.lblCargados.Size = new System.Drawing.Size(14, 14);
            this.lblCargados.TabIndex = 16;
            this.lblCargados.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(17, 78);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 17);
            this.label21.TabIndex = 15;
            this.label21.Text = "Cargado(s)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(185, 36);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(183, 17);
            this.label22.TabIndex = 13;
            this.label22.Text = "Cargar repuestos con asistente";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabHerramientas
            // 
            this.tabHerramientas.AutoScroll = true;
            this.tabHerramientas.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.tabHerramientas.BackColor = System.Drawing.Color.Azure;
            this.tabHerramientas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabHerramientas.Controls.Add(this.metroButton2);
            this.tabHerramientas.Controls.Add(this.lblCargadas);
            this.tabHerramientas.Controls.Add(this.label20);
            this.tabHerramientas.Controls.Add(this.dtgHerr);
            this.tabHerramientas.Controls.Add(this.label15);
            this.tabHerramientas.Location = new System.Drawing.Point(4, 35);
            this.tabHerramientas.Margin = new System.Windows.Forms.Padding(2);
            this.tabHerramientas.Name = "tabHerramientas";
            this.tabHerramientas.Padding = new System.Windows.Forms.Padding(2);
            this.tabHerramientas.Size = new System.Drawing.Size(578, 711);
            this.tabHerramientas.TabIndex = 2;
            this.tabHerramientas.Text = "Herramientas";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(367, 36);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(31, 24);
            this.metroButton2.TabIndex = 13;
            this.metroButton2.Text = "...";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // lblCargadas
            // 
            this.lblCargadas.AutoSize = true;
            this.lblCargadas.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargadas.ForeColor = System.Drawing.Color.Black;
            this.lblCargadas.Location = new System.Drawing.Point(93, 84);
            this.lblCargadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargadas.Name = "lblCargadas";
            this.lblCargadas.Size = new System.Drawing.Size(14, 14);
            this.lblCargadas.TabIndex = 11;
            this.lblCargadas.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(21, 84);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 17);
            this.label20.TabIndex = 10;
            this.label20.Text = "Cargada(s)";
            // 
            // dtgHerr
            // 
            this.dtgHerr.AllowUserToAddRows = false;
            this.dtgHerr.BackgroundColor = System.Drawing.Color.White;
            this.dtgHerr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHerr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sel_herr,
            this.Id,
            this.herramienta,
            this.tipo,
            this.dataGridViewImageColumn1});
            this.dtgHerr.Location = new System.Drawing.Point(14, 102);
            this.dtgHerr.Margin = new System.Windows.Forms.Padding(2);
            this.dtgHerr.MultiSelect = false;
            this.dtgHerr.Name = "dtgHerr";
            this.dtgHerr.RowTemplate.Height = 180;
            this.dtgHerr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHerr.Size = new System.Drawing.Size(563, 663);
            this.dtgHerr.TabIndex = 7;
            this.dtgHerr.Visible = false;
            // 
            // sel_herr
            // 
            this.sel_herr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sel_herr.DataPropertyName = "sel";
            this.sel_herr.HeaderText = "Seleccione";
            this.sel_herr.Name = "sel_herr";
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // herramienta
            // 
            this.herramienta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.herramienta.DataPropertyName = "herramienta";
            this.herramienta.HeaderText = "Herramienta";
            this.herramienta.Name = "herramienta";
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.DataPropertyName = "imagen";
            this.dataGridViewImageColumn1.HeaderText = "Imágen";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(161, 38);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(203, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Cargar herramientas con asistente";
            // 
            // tabEpps
            // 
            this.tabEpps.AutoScroll = true;
            this.tabEpps.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.tabEpps.BackColor = System.Drawing.Color.Azure;
            this.tabEpps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabEpps.Controls.Add(this.groupBox2);
            this.tabEpps.Location = new System.Drawing.Point(4, 35);
            this.tabEpps.Margin = new System.Windows.Forms.Padding(2);
            this.tabEpps.Name = "tabEpps";
            this.tabEpps.Padding = new System.Windows.Forms.Padding(2);
            this.tabEpps.Size = new System.Drawing.Size(578, 711);
            this.tabEpps.TabIndex = 1;
            this.tabEpps.Text = "EPPS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDisponibles);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.lblSeleccionados);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtgEpps);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(574, 707);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione los Elementos de Protección Personal Requeridos";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.ForeColor = System.Drawing.Color.Black;
            this.lblDisponibles.Location = new System.Drawing.Point(261, 55);
            this.lblDisponibles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(14, 14);
            this.lblDisponibles.TabIndex = 7;
            this.lblDisponibles.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(185, 51);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "Disponibles";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBuscar.Location = new System.Drawing.Point(335, 51);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(226, 24);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.lblSeleccionados.Location = new System.Drawing.Point(126, 55);
            this.lblSeleccionados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(14, 14);
            this.lblSeleccionados.TabIndex = 3;
            this.lblSeleccionados.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(24, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Seleccionado(s)";
            // 
            // dtgEpps
            // 
            this.dtgEpps.AllowUserToAddRows = false;
            this.dtgEpps.AllowUserToDeleteRows = false;
            this.dtgEpps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEpps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgEpps.BackgroundColor = System.Drawing.Color.White;
            this.dtgEpps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEpps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgEpps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEpps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionado,
            this.nombre,
            this.codigo,
            this.id_c,
            this.image_path,
            this.imagen});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEpps.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgEpps.GridColor = System.Drawing.Color.White;
            this.dtgEpps.Location = new System.Drawing.Point(12, 80);
            this.dtgEpps.Margin = new System.Windows.Forms.Padding(2);
            this.dtgEpps.MultiSelect = false;
            this.dtgEpps.Name = "dtgEpps";
            this.dtgEpps.RowTemplate.Height = 24;
            this.dtgEpps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgEpps.Size = new System.Drawing.Size(549, 650);
            this.dtgEpps.TabIndex = 1;
            this.dtgEpps.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgEpps_CurrentCellDirtyStateChanged);
            // 
            // seleccionado
            // 
            this.seleccionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.seleccionado.DataPropertyName = "sel";
            this.seleccionado.HeaderText = "Selección";
            this.seleccionado.Name = "seleccionado";
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombre.DataPropertyName = "nombre";
            this.nombre.FillWeight = 22.22223F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 80;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            // 
            // id_c
            // 
            this.id_c.DataPropertyName = "id";
            this.id_c.HeaderText = "Id";
            this.id_c.Name = "id_c";
            this.id_c.Visible = false;
            // 
            // image_path
            // 
            this.image_path.DataPropertyName = "path_image";
            this.image_path.HeaderText = "Image Path";
            this.image_path.Name = "image_path";
            this.image_path.Visible = false;
            // 
            // imagen
            // 
            this.imagen.DataPropertyName = "imagen";
            this.imagen.FillWeight = 177.7778F;
            this.imagen.HeaderText = "Foto";
            this.imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.imagen.Name = "imagen";
            this.imagen.Width = 189;
            // 
            // tabInformacionBasica
            // 
            this.tabInformacionBasica.AutoScroll = true;
            this.tabInformacionBasica.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.tabInformacionBasica.BackColor = System.Drawing.Color.Azure;
            this.tabInformacionBasica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabInformacionBasica.Controls.Add(this.groupBox1);
            this.tabInformacionBasica.Controls.Add(this.gbImagenes);
            this.tabInformacionBasica.Location = new System.Drawing.Point(4, 35);
            this.tabInformacionBasica.Margin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.tabInformacionBasica.Name = "tabInformacionBasica";
            this.tabInformacionBasica.Padding = new System.Windows.Forms.Padding(2);
            this.tabInformacionBasica.Size = new System.Drawing.Size(578, 711);
            this.tabInformacionBasica.TabIndex = 0;
            this.tabInformacionBasica.Text = "Información básica";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConsecutivo);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.rbLotoNo);
            this.groupBox1.Controls.Add(this.rbLotoSi);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtNombreSMP);
            this.groupBox1.Controls.Add(this.txtTecnicosRequeridos);
            this.groupBox1.Controls.Add(this.cboFrecuencia);
            this.groupBox1.Controls.Add(this.txtFrecuencia);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTiempoEquipoParado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDuracionActividad);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboAprobador);
            this.groupBox1.Controls.Add(this.cboTipoMtto);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label69);
            this.groupBox1.Controls.Add(this.cboElaborador);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboAreaLinea);
            this.groupBox1.Controls.Add(this.label68);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboEquipo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboClasificación);
            this.groupBox1.Controls.Add(this.txtSMP);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(565, 463);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsecutivo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConsecutivo.Location = new System.Drawing.Point(90, 22);
            this.txtConsecutivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.ReadOnly = true;
            this.txtConsecutivo.Size = new System.Drawing.Size(75, 23);
            this.txtConsecutivo.TabIndex = 41;
            this.txtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 27);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 17);
            this.label17.TabIndex = 40;
            this.label17.Text = "Consecutivo";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.chlbPermisosRequeridos);
            this.groupBox3.Location = new System.Drawing.Point(318, 220);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(240, 234);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos requeridos";
            // 
            // chlbPermisosRequeridos
            // 
            this.chlbPermisosRequeridos.CheckOnClick = true;
            this.chlbPermisosRequeridos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlbPermisosRequeridos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chlbPermisosRequeridos.FormattingEnabled = true;
            this.chlbPermisosRequeridos.Location = new System.Drawing.Point(2, 19);
            this.chlbPermisosRequeridos.Margin = new System.Windows.Forms.Padding(2);
            this.chlbPermisosRequeridos.Name = "chlbPermisosRequeridos";
            this.chlbPermisosRequeridos.Size = new System.Drawing.Size(236, 213);
            this.chlbPermisosRequeridos.TabIndex = 38;
            // 
            // rbLotoNo
            // 
            this.rbLotoNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbLotoNo.AutoSize = true;
            this.rbLotoNo.Location = new System.Drawing.Point(427, 193);
            this.rbLotoNo.Margin = new System.Windows.Forms.Padding(2);
            this.rbLotoNo.Name = "rbLotoNo";
            this.rbLotoNo.Size = new System.Drawing.Size(44, 21);
            this.rbLotoNo.TabIndex = 37;
            this.rbLotoNo.TabStop = true;
            this.rbLotoNo.Text = "NO";
            this.rbLotoNo.UseVisualStyleBackColor = true;
            // 
            // rbLotoSi
            // 
            this.rbLotoSi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbLotoSi.AutoSize = true;
            this.rbLotoSi.Checked = true;
            this.rbLotoSi.Location = new System.Drawing.Point(376, 193);
            this.rbLotoSi.Margin = new System.Windows.Forms.Padding(2);
            this.rbLotoSi.Name = "rbLotoSi";
            this.rbLotoSi.Size = new System.Drawing.Size(38, 21);
            this.rbLotoSi.TabIndex = 36;
            this.rbLotoSi.TabStop = true;
            this.rbLotoSi.Text = "SI";
            this.rbLotoSi.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(325, 193);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "¿Loto?";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Nombre SMP";
            // 
            // txtNombreSMP
            // 
            this.txtNombreSMP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreSMP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNombreSMP.Location = new System.Drawing.Point(311, 22);
            this.txtNombreSMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreSMP.Name = "txtNombreSMP";
            this.txtNombreSMP.Size = new System.Drawing.Size(248, 24);
            this.txtNombreSMP.TabIndex = 34;
            // 
            // txtTecnicosRequeridos
            // 
            this.txtTecnicosRequeridos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTecnicosRequeridos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTecnicosRequeridos.Location = new System.Drawing.Point(177, 203);
            this.txtTecnicosRequeridos.Margin = new System.Windows.Forms.Padding(2);
            this.txtTecnicosRequeridos.MaxLength = 3;
            this.txtTecnicosRequeridos.Name = "txtTecnicosRequeridos";
            this.txtTecnicosRequeridos.Size = new System.Drawing.Size(39, 24);
            this.txtTecnicosRequeridos.TabIndex = 32;
            this.txtTecnicosRequeridos.Text = "0";
            this.txtTecnicosRequeridos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTecnicosRequeridos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMP_KeyPress);
            // 
            // cboFrecuencia
            // 
            this.cboFrecuencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboFrecuencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFrecuencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFrecuencia.DisplayMember = "descripcion";
            this.cboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrecuencia.DropDownWidth = 215;
            this.cboFrecuencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboFrecuencia.FormattingEnabled = true;
            this.cboFrecuencia.Items.AddRange(new object[] {
            "Dia(s)",
            "Semana(s)",
            "Mes(es)",
            "Año(s)"});
            this.cboFrecuencia.Location = new System.Drawing.Point(220, 325);
            this.cboFrecuencia.Margin = new System.Windows.Forms.Padding(2);
            this.cboFrecuencia.Name = "cboFrecuencia";
            this.cboFrecuencia.Size = new System.Drawing.Size(82, 25);
            this.cboFrecuencia.TabIndex = 31;
            this.cboFrecuencia.ValueMember = "Id";
            // 
            // txtFrecuencia
            // 
            this.txtFrecuencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFrecuencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtFrecuencia.Location = new System.Drawing.Point(177, 325);
            this.txtFrecuencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrecuencia.MaxLength = 3;
            this.txtFrecuencia.Name = "txtFrecuencia";
            this.txtFrecuencia.Size = new System.Drawing.Size(39, 24);
            this.txtFrecuencia.TabIndex = 30;
            this.txtFrecuencia.Text = "0";
            this.txtFrecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFrecuencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMP_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 328);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 14);
            this.label9.TabIndex = 29;
            this.label9.Text = "Frecuencia";
            // 
            // txtTiempoEquipoParado
            // 
            this.txtTiempoEquipoParado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTiempoEquipoParado.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTiempoEquipoParado.Location = new System.Drawing.Point(177, 285);
            this.txtTiempoEquipoParado.Margin = new System.Windows.Forms.Padding(2);
            this.txtTiempoEquipoParado.MaxLength = 3;
            this.txtTiempoEquipoParado.Name = "txtTiempoEquipoParado";
            this.txtTiempoEquipoParado.Size = new System.Drawing.Size(39, 24);
            this.txtTiempoEquipoParado.TabIndex = 28;
            this.txtTiempoEquipoParado.Text = "0";
            this.txtTiempoEquipoParado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTiempoEquipoParado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMP_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 288);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "Tiempo equipo parado (MIN)";
            // 
            // txtDuracionActividad
            // 
            this.txtDuracionActividad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDuracionActividad.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtDuracionActividad.Location = new System.Drawing.Point(177, 245);
            this.txtDuracionActividad.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuracionActividad.MaxLength = 3;
            this.txtDuracionActividad.Name = "txtDuracionActividad";
            this.txtDuracionActividad.ReadOnly = true;
            this.txtDuracionActividad.Size = new System.Drawing.Size(39, 24);
            this.txtDuracionActividad.TabIndex = 26;
            this.txtDuracionActividad.Text = "0";
            this.txtDuracionActividad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuracionActividad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMP_KeyPress);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 249);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 14);
            this.label11.TabIndex = 25;
            this.label11.Text = "Duración de la actividad (MIN)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // cboAprobador
            // 
            this.cboAprobador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboAprobador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAprobador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAprobador.DataSource = this.tecnicosBindingSource1;
            this.cboAprobador.DisplayMember = "Nombre";
            this.cboAprobador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboAprobador.FormattingEnabled = true;
            this.cboAprobador.Location = new System.Drawing.Point(99, 424);
            this.cboAprobador.Margin = new System.Windows.Forms.Padding(2);
            this.cboAprobador.Name = "cboAprobador";
            this.cboAprobador.Size = new System.Drawing.Size(203, 25);
            this.cboAprobador.TabIndex = 20;
            this.cboAprobador.ValueMember = "Id";
            this.cboAprobador.Validated += new System.EventHandler(this.cboAreaLinea_Validated);
            // 
            // cboTipoMtto
            // 
            this.cboTipoMtto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTipoMtto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoMtto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoMtto.DisplayMember = "descripcion";
            this.cboTipoMtto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMtto.DropDownWidth = 215;
            this.cboTipoMtto.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboTipoMtto.FormattingEnabled = true;
            this.cboTipoMtto.Items.AddRange(new object[] {
            "Mtto correctivo (CM)",
            "Mtto por avería (BDM)",
            "Mtto basado en el tiempo (TBM)",
            "Mtto basado en condición (CBM)"});
            this.cboTipoMtto.Location = new System.Drawing.Point(399, 146);
            this.cboTipoMtto.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoMtto.Name = "cboTipoMtto";
            this.cboTipoMtto.Size = new System.Drawing.Size(161, 25);
            this.cboTipoMtto.TabIndex = 24;
            this.cboTipoMtto.ValueMember = "Id";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Aprobado por";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFecha.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dtpFecha.Location = new System.Drawing.Point(89, 62);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(213, 24);
            this.dtpFecha.TabIndex = 0;
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(335, 149);
            this.label69.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(61, 17);
            this.label69.TabIndex = 23;
            this.label69.Text = "Tipo mtto";
            // 
            // cboElaborador
            // 
            this.cboElaborador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboElaborador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboElaborador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboElaborador.DataSource = this.tecnicosBindingSource;
            this.cboElaborador.DisplayMember = "Nombre";
            this.cboElaborador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboElaborador.FormattingEnabled = true;
            this.cboElaborador.Location = new System.Drawing.Point(99, 381);
            this.cboElaborador.Margin = new System.Windows.Forms.Padding(2);
            this.cboElaborador.Name = "cboElaborador";
            this.cboElaborador.Size = new System.Drawing.Size(203, 25);
            this.cboElaborador.TabIndex = 12;
            this.cboElaborador.ValueMember = "Id";
            this.cboElaborador.Validated += new System.EventHandler(this.cboAreaLinea_Validated);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Área/Línea";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 385);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Elaborado por";
            // 
            // cboAreaLinea
            // 
            this.cboAreaLinea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboAreaLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreaLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAreaLinea.DataSource = this.arealineaBindingSource;
            this.cboAreaLinea.DisplayMember = "nombre";
            this.cboAreaLinea.DropDownWidth = 250;
            this.cboAreaLinea.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboAreaLinea.FormattingEnabled = true;
            this.cboAreaLinea.Location = new System.Drawing.Point(118, 104);
            this.cboAreaLinea.Margin = new System.Windows.Forms.Padding(2);
            this.cboAreaLinea.Name = "cboAreaLinea";
            this.cboAreaLinea.Size = new System.Drawing.Size(184, 25);
            this.cboAreaLinea.TabIndex = 3;
            this.cboAreaLinea.ValueMember = "Id";
            this.cboAreaLinea.Validated += new System.EventHandler(this.cboAreaLinea_Validated);
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(5, 206);
            this.label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(149, 17);
            this.label68.TabIndex = 21;
            this.label68.Text = "# de Técnicos requeridos";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Equipo";
            // 
            // cboEquipo
            // 
            this.cboEquipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboEquipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEquipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEquipo.DataSource = this.equiposBindingSource;
            this.cboEquipo.DisplayMember = "Nombre";
            this.cboEquipo.DropDownWidth = 500;
            this.cboEquipo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboEquipo.FormattingEnabled = true;
            this.cboEquipo.Location = new System.Drawing.Point(386, 62);
            this.cboEquipo.Margin = new System.Windows.Forms.Padding(2);
            this.cboEquipo.Name = "cboEquipo";
            this.cboEquipo.Size = new System.Drawing.Size(174, 25);
            this.cboEquipo.TabIndex = 5;
            this.cboEquipo.ValueMember = "Id";
            this.cboEquipo.Validated += new System.EventHandler(this.cboAreaLinea_Validated);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "SMP #";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clasificación SMP";
            // 
            // cboClasificación
            // 
            this.cboClasificación.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboClasificación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboClasificación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClasificación.DisplayMember = "descripcion";
            this.cboClasificación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificación.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboClasificación.FormattingEnabled = true;
            this.cboClasificación.Items.AddRange(new object[] {
            "Lubricación",
            "Mecánica",
            "Eléctrica",
            "Instrumentación",
            "Metrología",
            "Control Procesos"});
            this.cboClasificación.Location = new System.Drawing.Point(118, 146);
            this.cboClasificación.Margin = new System.Windows.Forms.Padding(2);
            this.cboClasificación.Name = "cboClasificación";
            this.cboClasificación.Size = new System.Drawing.Size(184, 25);
            this.cboClasificación.TabIndex = 9;
            this.cboClasificación.ValueMember = "Id";
            // 
            // txtSMP
            // 
            this.txtSMP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSMP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSMP.Location = new System.Drawing.Point(386, 104);
            this.txtSMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSMP.MaxLength = 9;
            this.txtSMP.Name = "txtSMP";
            this.txtSMP.Size = new System.Drawing.Size(174, 24);
            this.txtSMP.TabIndex = 10;
            this.txtSMP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMP_KeyPress);
            // 
            // gbImagenes
            // 
            this.gbImagenes.Controls.Add(this.pbImg2);
            this.gbImagenes.Controls.Add(this.pbImg1);
            this.gbImagenes.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImagenes.Location = new System.Drawing.Point(1, 471);
            this.gbImagenes.Margin = new System.Windows.Forms.Padding(2);
            this.gbImagenes.Name = "gbImagenes";
            this.gbImagenes.Padding = new System.Windows.Forms.Padding(2);
            this.gbImagenes.Size = new System.Drawing.Size(565, 232);
            this.gbImagenes.TabIndex = 32;
            this.gbImagenes.TabStop = false;
            this.gbImagenes.Text = "Mapa de la máquina que indica los grupos de máquinas donde se realizan las tareas" +
    " de mantenimiento";
            // 
            // pbImg2
            // 
            this.pbImg2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbImg2.ContextMenuStrip = this.cmsImagen2;
            this.pbImg2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg2.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg2.Location = new System.Drawing.Point(355, 37);
            this.pbImg2.Margin = new System.Windows.Forms.Padding(2);
            this.pbImg2.Name = "pbImg2";
            this.pbImg2.Size = new System.Drawing.Size(159, 174);
            this.pbImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg2.TabIndex = 1;
            this.pbImg2.TabStop = false;
            this.pbImg2.Click += new System.EventHandler(this.img2_Click);
            // 
            // pbImg1
            // 
            this.pbImg1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbImg1.ContextMenuStrip = this.cmsImagen1;
            this.pbImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg1.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg1.Location = new System.Drawing.Point(54, 37);
            this.pbImg1.Margin = new System.Windows.Forms.Padding(2);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(159, 174);
            this.pbImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg1.TabIndex = 0;
            this.pbImg1.TabStop = false;
            this.pbImg1.Click += new System.EventHandler(this.img1_Click);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcontrol.Controls.Add(this.tabInformacionBasica);
            this.tabcontrol.Controls.Add(this.tabHerramientas);
            this.tabcontrol.Controls.Add(this.tabRepuestos);
            this.tabcontrol.Controls.Add(this.tabPasoPaso);
            this.tabcontrol.Controls.Add(this.tabEpps);
            this.tabcontrol.Location = new System.Drawing.Point(1, 152);
            this.tabcontrol.Margin = new System.Windows.Forms.Padding(2);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(586, 750);
            this.tabcontrol.TabIndex = 3;
            this.tabcontrol.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tabcontrol.UseStyleColors = true;
            // 
            // btnSiguiente1
            // 
            this.btnSiguiente1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente1.BackColor = System.Drawing.Color.White;
            this.btnSiguiente1.BackgroundImage = global::FormatoEwo.Properties.Resources.validate;
            this.btnSiguiente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSiguiente1.Location = new System.Drawing.Point(501, 108);
            this.btnSiguiente1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente1.Name = "btnSiguiente1";
            this.btnSiguiente1.Size = new System.Drawing.Size(68, 46);
            this.btnSiguiente1.TabIndex = 10;
            this.metroToolTip1.SetToolTip(this.btnSiguiente1, "Validar datos de formulario");
            this.btnSiguiente1.UseVisualStyleBackColor = false;
            this.btnSiguiente1.Click += new System.EventHandler(this.btnSiguiente1_Click);
            // 
            // pbLoad
            // 
            this.pbLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoad.Location = new System.Drawing.Point(120, 130);
            this.pbLoad.Margin = new System.Windows.Forms.Padding(2);
            this.pbLoad.MarqueeAnimationSpeed = 10;
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(376, 23);
            this.pbLoad.TabIndex = 11;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(122, 108);
            this.label67.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(94, 15);
            this.label67.TabIndex = 12;
            this.label67.Text = "Completado...";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(232, 108);
            this.lblPorcentaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(25, 15);
            this.lblPorcentaje.TabIndex = 13;
            this.lblPorcentaje.Text = "0%";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(501, 73);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(68, 32);
            this.btnExportar.TabIndex = 14;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Visible = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormatoEwo.Properties.Resources.hpc_logo;
            this.pictureBox1.Location = new System.Drawing.Point(20, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblGenerando
            // 
            this.lblGenerando.AutoSize = true;
            this.lblGenerando.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerando.Location = new System.Drawing.Point(165, 61);
            this.lblGenerando.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenerando.Name = "lblGenerando";
            this.lblGenerando.Size = new System.Drawing.Size(164, 15);
            this.lblGenerando.TabIndex = 15;
            this.lblGenerando.Text = "Generando archivo excel,";
            this.lblGenerando.Visible = false;
            // 
            // RiksImages
            // 
            this.RiksImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RiksImages.ImageStream")));
            this.RiksImages.TransparentColor = System.Drawing.Color.Transparent;
            this.RiksImages.Images.SetKeyName(0, "trabajo_caliente.png");
            this.RiksImages.Images.SetKeyName(1, "trabajo_alturas.png");
            this.RiksImages.Images.SetKeyName(2, "sustancias_quimicas.png");
            this.RiksImages.Images.SetKeyName(3, "excavaciones.png");
            this.RiksImages.Images.SetKeyName(4, "energia_cero.png");
            this.RiksImages.Images.SetKeyName(5, "trabajo_subestacion.png");
            this.RiksImages.Images.SetKeyName(6, "espacio_confinado.png");
            this.RiksImages.Images.SetKeyName(7, "trafico_montacargas.png");
            this.RiksImages.Images.SetKeyName(8, "atrapamiento.jpg");
            this.RiksImages.Images.SetKeyName(9, "levantamiento_carga.png");
            this.RiksImages.Images.SetKeyName(10, "herramientas_equipos.png");
            // 
            // bgSaveData
            // 
            this.bgSaveData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSaveData_DoWork);
            this.bgSaveData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSaveData_RunWorkerCompleted);
            // 
            // pbGenerando
            // 
            this.pbGenerando.animated = true;
            this.pbGenerando.animationIterval = 20;
            this.pbGenerando.animationSpeed = 80;
            this.pbGenerando.BackColor = System.Drawing.Color.White;
            this.pbGenerando.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbGenerando.BackgroundImage")));
            this.pbGenerando.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 15.25F);
            this.pbGenerando.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.pbGenerando.LabelVisible = false;
            this.pbGenerando.LineProgressThickness = 5;
            this.pbGenerando.LineThickness = 4;
            this.pbGenerando.Location = new System.Drawing.Point(119, 57);
            this.pbGenerando.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.pbGenerando.MaxValue = 100;
            this.pbGenerando.Name = "pbGenerando";
            this.pbGenerando.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.pbGenerando.ProgressColor = System.Drawing.Color.CadetBlue;
            this.pbGenerando.Size = new System.Drawing.Size(47, 47);
            this.pbGenerando.TabIndex = 17;
            this.pbGenerando.Value = 40;
            this.pbGenerando.Visible = false;
            // 
            // lblPorFavor
            // 
            this.lblPorFavor.AutoSize = true;
            this.lblPorFavor.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorFavor.Location = new System.Drawing.Point(166, 79);
            this.lblPorFavor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorFavor.Name = "lblPorFavor";
            this.lblPorFavor.Size = new System.Drawing.Size(121, 15);
            this.lblPorFavor.TabIndex = 18;
            this.lblPorFavor.Text = "por favor espere...";
            this.lblPorFavor.Visible = false;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(395, 103);
            this.chkPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(88, 15);
            this.chkPDF.TabIndex = 19;
            this.chkPDF.Text = "Generar PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            this.chkPDF.Visible = false;
            // 
            // ewoDatabaseDataSet1
            // 
            this.ewoDatabaseDataSet1.DataSetName = "EwoDatabaseDataSet";
            this.ewoDatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ewoDatabaseDataSet1BindingSource
            // 
            this.ewoDatabaseDataSet1BindingSource.DataSource = this.ewoDatabaseDataSet1;
            this.ewoDatabaseDataSet1BindingSource.Position = 0;
            // 
            // eppsBindingSource
            // 
            this.eppsBindingSource.DataMember = "epps";
            this.eppsBindingSource.DataSource = this.ewoDatabaseDataSet1;
            // 
            // eppsTableAdapter
            // 
            this.eppsTableAdapter.ClearBeforeFill = true;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(231, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Buscar (Ingrese Código o Nombre EPP)";
            // 
            // Smp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 918);
            this.Controls.Add(this.chkPDF);
            this.Controls.Add(this.lblPorFavor);
            this.Controls.Add(this.pbGenerando);
            this.Controls.Add(this.lblGenerando);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.btnSiguiente1);
            this.Controls.Add(this.tabcontrol);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Smp";
            this.Padding = new System.Windows.Forms.Padding(17, 79, 17, 21);
            this.Text = "@2017 SMP (Procedimiento Estandar de Mantenimiento) V 1.0 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Smp_FormClosing);
            this.Load += new System.EventHandler(this.Smp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tecnicosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tecnicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arealineaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiposBindingSource)).EndInit();
            this.cmsImagen2.ResumeLayout(false);
            this.cmsImagen1.ResumeLayout(false);
            this.tabPasoPaso.ResumeLayout(false);
            this.tabPasoPaso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPasoAPaso)).EndInit();
            this.tabRepuestos.ResumeLayout(false);
            this.tabRepuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRep)).EndInit();
            this.tabHerramientas.ResumeLayout(false);
            this.tabHerramientas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).EndInit();
            this.tabEpps.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEpps)).EndInit();
            this.tabInformacionBasica.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbImagenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.tabcontrol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eppsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion       
        private EwoDatabaseDataSet ewoDatabaseDataSet;
        private System.Windows.Forms.BindingSource equiposBindingSource;
        private EwoDatabaseDataSetTableAdapters.equiposTableAdapter equiposTableAdapter;
        private System.Windows.Forms.BindingSource arealineaBindingSource;
        private EwoDatabaseDataSetTableAdapters.area_lineaTableAdapter area_lineaTableAdapter;
        private System.Windows.Forms.BindingSource tecnicosBindingSource;
        private EwoDatabaseDataSetTableAdapters.tecnicosTableAdapter tecnicosTableAdapter;
        private System.Windows.Forms.BindingSource tecnicosBindingSource1;
        private System.Windows.Forms.ImageList EppsImages;
        private System.ComponentModel.BackgroundWorker bgLoad;
        private System.Windows.Forms.ImageList RiskImages;
        private System.Windows.Forms.ContextMenuStrip cmsImagen1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen;
        private System.Windows.Forms.ContextMenuStrip cmsImagen2;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen2;
        private System.Windows.Forms.TabPage tabPasoPaso;
        private MetroButton btnEditar;
        private System.Windows.Forms.Label label23;
        private MetroButton btnPaso;
        private System.Windows.Forms.Label lblPaPCargados;
        private System.Windows.Forms.DataGridView dtgPasoAPaso;
        private System.Windows.Forms.TabPage tabRepuestos;
        private System.Windows.Forms.DataGridView dtgRep;
        private System.Windows.Forms.Label lblCargados;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private MetroButton button1;
        private System.Windows.Forms.TabPage tabHerramientas;
        private MetroButton metroButton2;
        private System.Windows.Forms.Label lblCargadas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dtgHerr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabEpps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblSeleccionados;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dtgEpps;
        private System.Windows.Forms.TabPage tabInformacionBasica;
        private MetroTabControl tabcontrol;
        private System.Windows.Forms.Button btnSiguiente1;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGenerando;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sel_herr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramienta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn repuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagen_path;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chlbPermisosRequeridos;
        private System.Windows.Forms.RadioButton rbLotoNo;
        private System.Windows.Forms.RadioButton rbLotoSi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombreSMP;
        private System.Windows.Forms.TextBox txtTecnicosRequeridos;
        private System.Windows.Forms.ComboBox cboFrecuencia;
        private System.Windows.Forms.TextBox txtFrecuencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTiempoEquipoParado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDuracionActividad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAprobador;
        private System.Windows.Forms.ComboBox cboTipoMtto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.ComboBox cboElaborador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAreaLinea;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEquipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboClasificación;
        private System.Windows.Forms.TextBox txtSMP;
        private System.Windows.Forms.GroupBox gbImagenes;
        private System.Windows.Forms.PictureBox pbImg2;
        private System.Windows.Forms.PictureBox pbImg1;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen2;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen;
        private System.Windows.Forms.ImageList RiksImages;
        private System.ComponentModel.BackgroundWorker bgSaveData;
        private Bunifu.Framework.UI.BunifuCircleProgressbar pbGenerando;
        private System.Windows.Forms.Label lblPorFavor;
        private MetroCheckBox chkPDF;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.Label label17;
        private EwoDatabaseDataSet ewoDatabaseDataSet1;
        private System.Windows.Forms.BindingSource ewoDatabaseDataSet1BindingSource;
        private System.Windows.Forms.BindingSource eppsBindingSource;
        private EwoDatabaseDataSetTableAdapters.eppsTableAdapter eppsTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn image_path;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
        private System.Windows.Forms.Label label14;
    }
}