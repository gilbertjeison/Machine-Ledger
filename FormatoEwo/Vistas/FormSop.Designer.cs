namespace FormatoEwo.Vistas
{
    partial class FormSop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSop));
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGenerando = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.btnSiguiente1 = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.chkPDF = new MetroFramework.Controls.MetroCheckBox();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tabInformacionBasica = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtConsecutivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoSop = new System.Windows.Forms.ComboBox();
            this.txtNombreSOP = new System.Windows.Forms.TextBox();
            this.txtSOP = new System.Windows.Forms.TextBox();
            this.txtNumRevision = new System.Windows.Forms.TextBox();
            this.txtCodFormato = new System.Windows.Forms.TextBox();
            this.cboMaquina = new System.Windows.Forms.ComboBox();
            this.cboFrecuencia = new System.Windows.Forms.ComboBox();
            this.cboElaborador = new System.Windows.Forms.ComboBox();
            this.cboAprobador = new System.Windows.Forms.ComboBox();
            this.cboAreaAprobadora = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpMaquinaParada = new System.Windows.Forms.DateTimePicker();
            this.dtpDuracionTarea = new System.Windows.Forms.DateTimePicker();
            this.txtNumPersonas = new System.Windows.Forms.TextBox();
            this.dtpTiempoPersona = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabEpps = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgEpps = new System.Windows.Forms.DataGridView();
            this.seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabHerramientas = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgHerr = new System.Windows.Forms.DataGridView();
            this.sel_herr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramienta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCargadas = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.tabPasoPaso = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgPasoAPaso = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPaPCargados = new System.Windows.Forms.Label();
            this.btnPaso = new MetroFramework.Controls.MetroButton();
            this.btnEditar = new MetroFramework.Controls.MetroButton();
            this.EppsImages = new System.Windows.Forms.ImageList(this.components);
            this.bgSaveData = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramientaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.image_path_pp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabcontrol.SuspendLayout();
            this.tabInformacionBasica.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabEpps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEpps)).BeginInit();
            this.tabHerramientas.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).BeginInit();
            this.tabPasoPaso.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPasoAPaso)).BeginInit();
            this.SuspendLayout();
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoad_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabcontrol, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.78261F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.21739F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 507);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = global::FormatoEwo.Properties.Resources.left_mask2_blue;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblGenerando, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pbLoad, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnSiguiente1, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnExportar, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label67, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPorcentaje, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkPDF, 3, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(605, 68);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblGenerando
            // 
            this.lblGenerando.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGenerando.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblGenerando, 3);
            this.lblGenerando.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerando.Location = new System.Drawing.Point(123, 1);
            this.lblGenerando.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenerando.Name = "lblGenerando";
            this.lblGenerando.Size = new System.Drawing.Size(282, 15);
            this.lblGenerando.TabIndex = 21;
            this.lblGenerando.Text = "Generando archivo excel, por favor espere...";
            this.lblGenerando.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::FormatoEwo.Properties.Resources.hpc_wcm;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel2.SetRowSpan(this.pictureBox1, 4);
            this.pictureBox1.Size = new System.Drawing.Size(117, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pbLoad
            // 
            this.pbLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.pbLoad, 3);
            this.pbLoad.Location = new System.Drawing.Point(123, 52);
            this.pbLoad.Margin = new System.Windows.Forms.Padding(2);
            this.pbLoad.MarqueeAnimationSpeed = 10;
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(359, 14);
            this.pbLoad.TabIndex = 12;
            // 
            // btnSiguiente1
            // 
            this.btnSiguiente1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente1.BackColor = System.Drawing.Color.White;
            this.btnSiguiente1.BackgroundImage = global::FormatoEwo.Properties.Resources.validate;
            this.btnSiguiente1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSiguiente1.Location = new System.Drawing.Point(486, 34);
            this.btnSiguiente1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente1.Name = "btnSiguiente1";
            this.tableLayoutPanel2.SetRowSpan(this.btnSiguiente1, 2);
            this.btnSiguiente1.Size = new System.Drawing.Size(117, 32);
            this.btnSiguiente1.TabIndex = 13;
            this.btnSiguiente1.UseVisualStyleBackColor = false;
            this.btnSiguiente1.Click += new System.EventHandler(this.btnSiguiente1_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(486, 4);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.tableLayoutPanel2.SetRowSpan(this.btnExportar, 2);
            this.btnExportar.Size = new System.Drawing.Size(117, 21);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Visible = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(123, 31);
            this.label67.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(94, 15);
            this.label67.TabIndex = 16;
            this.label67.Text = "Completado...";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(244, 31);
            this.lblPorcentaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(25, 15);
            this.lblPorcentaje.TabIndex = 17;
            this.lblPorcentaje.Text = "0%";
            // 
            // chkPDF
            // 
            this.chkPDF.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPDF.AutoSize = true;
            this.chkPDF.BackColor = System.Drawing.Color.Transparent;
            this.chkPDF.Location = new System.Drawing.Point(366, 31);
            this.chkPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(88, 15);
            this.chkPDF.TabIndex = 20;
            this.chkPDF.Text = "Generar PDF";
            this.chkPDF.UseVisualStyleBackColor = false;
            this.chkPDF.Visible = false;
            // 
            // tabcontrol
            // 
            this.tabcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcontrol.Controls.Add(this.tabInformacionBasica);
            this.tabcontrol.Controls.Add(this.tabEpps);
            this.tabcontrol.Controls.Add(this.tabHerramientas);
            this.tabcontrol.Controls.Add(this.tabPasoPaso);
            this.tabcontrol.Location = new System.Drawing.Point(3, 77);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(605, 427);
            this.tabcontrol.TabIndex = 1;
            // 
            // tabInformacionBasica
            // 
            this.tabInformacionBasica.Controls.Add(this.tableLayoutPanel3);
            this.tabInformacionBasica.Location = new System.Drawing.Point(4, 24);
            this.tabInformacionBasica.Name = "tabInformacionBasica";
            this.tabInformacionBasica.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformacionBasica.Size = new System.Drawing.Size(597, 399);
            this.tabInformacionBasica.TabIndex = 0;
            this.tabInformacionBasica.Text = "Información básica";
            this.tabInformacionBasica.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 393F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(591, 393);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel4.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtConsecutivo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.dtpFecha, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.cboCategoria, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.cboTipoSop, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtNombreSOP, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtSOP, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtNumRevision, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtCodFormato, 4, 3);
            this.tableLayoutPanel4.Controls.Add(this.cboMaquina, 4, 4);
            this.tableLayoutPanel4.Controls.Add(this.cboFrecuencia, 4, 5);
            this.tableLayoutPanel4.Controls.Add(this.cboElaborador, 4, 6);
            this.tableLayoutPanel4.Controls.Add(this.cboAprobador, 4, 7);
            this.tableLayoutPanel4.Controls.Add(this.cboAreaAprobadora, 4, 8);
            this.tableLayoutPanel4.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label13, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.label21, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.label3, 3, 4);
            this.tableLayoutPanel4.Controls.Add(this.label9, 3, 5);
            this.tableLayoutPanel4.Controls.Add(this.label6, 3, 6);
            this.tableLayoutPanel4.Controls.Add(this.label7, 3, 7);
            this.tableLayoutPanel4.Controls.Add(this.label69, 3, 8);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 9;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.4031F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.819121F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(585, 387);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(2, 14);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 15);
            this.label17.TabIndex = 41;
            this.label17.Text = "Consecutivo";
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConsecutivo.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsecutivo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConsecutivo.Location = new System.Drawing.Point(136, 10);
            this.txtConsecutivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.ReadOnly = true;
            this.txtConsecutivo.Size = new System.Drawing.Size(75, 23);
            this.txtConsecutivo.TabIndex = 42;
            this.txtConsecutivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFecha.CalendarForeColor = System.Drawing.SystemColors.HotTrack;
            this.dtpFecha.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(136, 53);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(130, 23);
            this.dtpFecha.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "Categoría";
            // 
            // cboCategoria
            // 
            this.cboCategoria.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategoria.DisplayMember = "descripcion";
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.DropDownWidth = 250;
            this.cboCategoria.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(136, 96);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(130, 23);
            this.cboCategoria.TabIndex = 50;
            this.cboCategoria.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Tipo SOP";
            // 
            // cboTipoSop
            // 
            this.cboTipoSop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboTipoSop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipoSop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipoSop.DisplayMember = "descripcion";
            this.cboTipoSop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoSop.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoSop.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboTipoSop.FormattingEnabled = true;
            this.cboTipoSop.Location = new System.Drawing.Point(136, 139);
            this.cboTipoSop.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoSop.Name = "cboTipoSop";
            this.cboTipoSop.Size = new System.Drawing.Size(130, 23);
            this.cboTipoSop.TabIndex = 54;
            this.cboTipoSop.ValueMember = "Id";
            // 
            // txtNombreSOP
            // 
            this.txtNombreSOP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNombreSOP.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreSOP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNombreSOP.Location = new System.Drawing.Point(450, 10);
            this.txtNombreSOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreSOP.Name = "txtNombreSOP";
            this.txtNombreSOP.Size = new System.Drawing.Size(133, 23);
            this.txtNombreSOP.TabIndex = 44;
            // 
            // txtSOP
            // 
            this.txtSOP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSOP.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSOP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSOP.Location = new System.Drawing.Point(450, 53);
            this.txtSOP.Margin = new System.Windows.Forms.Padding(2);
            this.txtSOP.MaxLength = 18;
            this.txtSOP.Name = "txtSOP";
            this.txtSOP.Size = new System.Drawing.Size(133, 23);
            this.txtSOP.TabIndex = 52;
            this.txtSOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPersonas_KeyPress);
            // 
            // txtNumRevision
            // 
            this.txtNumRevision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNumRevision.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRevision.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNumRevision.Location = new System.Drawing.Point(450, 96);
            this.txtNumRevision.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumRevision.MaxLength = 18;
            this.txtNumRevision.Name = "txtNumRevision";
            this.txtNumRevision.Size = new System.Drawing.Size(133, 23);
            this.txtNumRevision.TabIndex = 76;
            // 
            // txtCodFormato
            // 
            this.txtCodFormato.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCodFormato.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodFormato.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCodFormato.Location = new System.Drawing.Point(450, 139);
            this.txtCodFormato.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodFormato.MaxLength = 18;
            this.txtCodFormato.Name = "txtCodFormato";
            this.txtCodFormato.Size = new System.Drawing.Size(133, 23);
            this.txtCodFormato.TabIndex = 77;
            // 
            // cboMaquina
            // 
            this.cboMaquina.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboMaquina.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMaquina.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMaquina.DisplayMember = "Nombre";
            this.cboMaquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaquina.DropDownWidth = 250;
            this.cboMaquina.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaquina.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboMaquina.FormattingEnabled = true;
            this.cboMaquina.Location = new System.Drawing.Point(450, 182);
            this.cboMaquina.Margin = new System.Windows.Forms.Padding(2);
            this.cboMaquina.Name = "cboMaquina";
            this.cboMaquina.Size = new System.Drawing.Size(133, 23);
            this.cboMaquina.TabIndex = 48;
            this.cboMaquina.ValueMember = "Id";
            // 
            // cboFrecuencia
            // 
            this.cboFrecuencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboFrecuencia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFrecuencia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFrecuencia.DisplayMember = "descripcion";
            this.cboFrecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrecuencia.DropDownWidth = 215;
            this.cboFrecuencia.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFrecuencia.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboFrecuencia.FormattingEnabled = true;
            this.cboFrecuencia.Location = new System.Drawing.Point(450, 225);
            this.cboFrecuencia.Margin = new System.Windows.Forms.Padding(2);
            this.cboFrecuencia.Name = "cboFrecuencia";
            this.cboFrecuencia.Size = new System.Drawing.Size(133, 23);
            this.cboFrecuencia.TabIndex = 32;
            this.cboFrecuencia.ValueMember = "Id";
            // 
            // cboElaborador
            // 
            this.cboElaborador.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboElaborador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboElaborador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboElaborador.DisplayMember = "Nombre";
            this.cboElaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElaborador.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboElaborador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboElaborador.FormattingEnabled = true;
            this.cboElaborador.Location = new System.Drawing.Point(450, 268);
            this.cboElaborador.Margin = new System.Windows.Forms.Padding(2);
            this.cboElaborador.Name = "cboElaborador";
            this.cboElaborador.Size = new System.Drawing.Size(133, 23);
            this.cboElaborador.TabIndex = 70;
            this.cboElaborador.ValueMember = "Id";
            // 
            // cboAprobador
            // 
            this.cboAprobador.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboAprobador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAprobador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAprobador.DisplayMember = "Nombre";
            this.cboAprobador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAprobador.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAprobador.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboAprobador.FormattingEnabled = true;
            this.cboAprobador.Location = new System.Drawing.Point(450, 313);
            this.cboAprobador.Margin = new System.Windows.Forms.Padding(2);
            this.cboAprobador.Name = "cboAprobador";
            this.cboAprobador.Size = new System.Drawing.Size(133, 23);
            this.cboAprobador.TabIndex = 72;
            this.cboAprobador.ValueMember = "Id";
            // 
            // cboAreaAprobadora
            // 
            this.cboAreaAprobadora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboAreaAprobadora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreaAprobadora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAreaAprobadora.DisplayMember = "descripcion";
            this.cboAreaAprobadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaAprobadora.DropDownWidth = 215;
            this.cboAreaAprobadora.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreaAprobadora.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cboAreaAprobadora.FormattingEnabled = true;
            this.cboAreaAprobadora.Location = new System.Drawing.Point(450, 356);
            this.cboAreaAprobadora.Margin = new System.Windows.Forms.Padding(2);
            this.cboAreaAprobadora.Name = "cboAreaAprobadora";
            this.cboAreaAprobadora.Size = new System.Drawing.Size(133, 23);
            this.cboAreaAprobadora.TabIndex = 56;
            this.cboAreaAprobadora.ValueMember = "Id";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(316, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Título SOP";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(316, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 51;
            this.label5.Text = "SOP #";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(316, 100);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 15);
            this.label13.TabIndex = 75;
            this.label13.Text = "Revisión #";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(316, 135);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(130, 30);
            this.label21.TabIndex = 78;
            this.label21.Text = "Código formato que se relaciona";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "Máquina";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(316, 229);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 63;
            this.label9.Text = "Frecuencia";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(316, 272);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 69;
            this.label6.Text = "Preparado por";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(316, 317);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 71;
            this.label7.Text = "Lider del área";
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(316, 360);
            this.label69.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(101, 15);
            this.label69.TabIndex = 55;
            this.label69.Text = "Área que aprueba";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Location = new System.Drawing.Point(3, 175);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel4.SetRowSpan(this.groupBox1, 4);
            this.groupBox1.Size = new System.Drawing.Size(262, 171);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiempos";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.LightBlue;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.30935F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.69065F));
            this.tableLayoutPanel5.Controls.Add(this.dtpMaquinaParada, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.dtpDuracionTarea, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtNumPersonas, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.dtpTiempoPersona, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label19, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label68, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(256, 149);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // dtpMaquinaParada
            // 
            this.dtpMaquinaParada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpMaquinaParada.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpMaquinaParada.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpMaquinaParada.CustomFormat = "HH:mm:ss";
            this.dtpMaquinaParada.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMaquinaParada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMaquinaParada.Location = new System.Drawing.Point(165, 118);
            this.dtpMaquinaParada.Name = "dtpMaquinaParada";
            this.dtpMaquinaParada.ShowUpDown = true;
            this.dtpMaquinaParada.Size = new System.Drawing.Size(88, 23);
            this.dtpMaquinaParada.TabIndex = 84;
            this.dtpMaquinaParada.Value = new System.DateTime(2018, 9, 12, 0, 0, 0, 0);
            // 
            // dtpDuracionTarea
            // 
            this.dtpDuracionTarea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDuracionTarea.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDuracionTarea.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpDuracionTarea.CustomFormat = "HH:mm:ss";
            this.dtpDuracionTarea.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDuracionTarea.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDuracionTarea.Location = new System.Drawing.Point(165, 81);
            this.dtpDuracionTarea.Name = "dtpDuracionTarea";
            this.dtpDuracionTarea.ShowUpDown = true;
            this.dtpDuracionTarea.Size = new System.Drawing.Size(88, 23);
            this.dtpDuracionTarea.TabIndex = 83;
            this.dtpDuracionTarea.Value = new System.DateTime(2018, 9, 12, 0, 0, 0, 0);
            // 
            // txtNumPersonas
            // 
            this.txtNumPersonas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumPersonas.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumPersonas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNumPersonas.Location = new System.Drawing.Point(189, 7);
            this.txtNumPersonas.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumPersonas.MaxLength = 3;
            this.txtNumPersonas.Name = "txtNumPersonas";
            this.txtNumPersonas.Size = new System.Drawing.Size(39, 23);
            this.txtNumPersonas.TabIndex = 82;
            this.txtNumPersonas.Text = "0";
            this.txtNumPersonas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumPersonas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumPersonas_KeyPress);
            // 
            // dtpTiempoPersona
            // 
            this.dtpTiempoPersona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTiempoPersona.CalendarForeColor = System.Drawing.SystemColors.Highlight;
            this.dtpTiempoPersona.CalendarTitleBackColor = System.Drawing.SystemColors.Highlight;
            this.dtpTiempoPersona.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDark;
            this.dtpTiempoPersona.CustomFormat = "HH:mm:ss";
            this.dtpTiempoPersona.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTiempoPersona.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTiempoPersona.Location = new System.Drawing.Point(165, 44);
            this.dtpTiempoPersona.Name = "dtpTiempoPersona";
            this.dtpTiempoPersona.ShowUpDown = true;
            this.dtpTiempoPersona.Size = new System.Drawing.Size(88, 23);
            this.dtpTiempoPersona.TabIndex = 81;
            this.dtpTiempoPersona.Value = new System.DateTime(2018, 9, 12, 0, 0, 0, 0);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(2, 115);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 30);
            this.label19.TabIndex = 81;
            this.label19.Text = "Tiempo máquina parada (SEG)";
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(2, 11);
            this.label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(154, 15);
            this.label68.TabIndex = 75;
            this.label68.Text = "No. de personas requeridas";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(2, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 15);
            this.label11.TabIndex = 77;
            this.label11.Text = "Tiempo por persona (SEG)";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 15);
            this.label8.TabIndex = 79;
            this.label8.Text = "Duración de la tarea (SEG)";
            // 
            // tabEpps
            // 
            this.tabEpps.Controls.Add(this.groupBox2);
            this.tabEpps.Location = new System.Drawing.Point(4, 24);
            this.tabEpps.Name = "tabEpps";
            this.tabEpps.Padding = new System.Windows.Forms.Padding(3);
            this.tabEpps.Size = new System.Drawing.Size(597, 399);
            this.tabEpps.TabIndex = 1;
            this.tabEpps.Text = "EPPS";
            this.tabEpps.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(591, 393);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione los Elementos de Protección Personal Requeridos";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.86747F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.507745F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.62134F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.991394F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.83993F));
            this.tableLayoutPanel8.Controls.Add(this.dtgEpps, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblSeleccionados, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label16, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblDisponibles, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.txtBuscar, 4, 1);
            this.tableLayoutPanel8.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(2, 18);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(587, 373);
            this.tableLayoutPanel8.TabIndex = 0;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEpps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgEpps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEpps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionado,
            this.nombre,
            this.codigo,
            this.id_c,
            this.image_path,
            this.imagen});
            this.tableLayoutPanel8.SetColumnSpan(this.dtgEpps, 5);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEpps.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgEpps.GridColor = System.Drawing.Color.White;
            this.dtgEpps.Location = new System.Drawing.Point(2, 51);
            this.dtgEpps.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.dtgEpps.MultiSelect = false;
            this.dtgEpps.Name = "dtgEpps";
            this.dtgEpps.RowTemplate.Height = 24;
            this.dtgEpps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgEpps.Size = new System.Drawing.Size(583, 320);
            this.dtgEpps.TabIndex = 11;
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
            this.nombre.Width = 76;
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
            this.imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imagen.Name = "imagen";
            this.imagen.Width = 189;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(4, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Seleccionado(s)";
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.lblSeleccionados.Location = new System.Drawing.Point(101, 26);
            this.lblSeleccionados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(14, 14);
            this.lblSeleccionados.TabIndex = 4;
            this.lblSeleccionados.Text = "0";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(153, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 15);
            this.label16.TabIndex = 7;
            this.label16.Text = "Disponibles";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.ForeColor = System.Drawing.Color.Black;
            this.lblDisponibles.Location = new System.Drawing.Point(248, 26);
            this.lblDisponibles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(14, 14);
            this.lblDisponibles.TabIndex = 8;
            this.lblDisponibles.Text = "0";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBuscar.Location = new System.Drawing.Point(318, 24);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(226, 23);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(322, 7);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(218, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "Buscar (Ingrese Código o Nombre EPP)";
            // 
            // tabHerramientas
            // 
            this.tabHerramientas.Controls.Add(this.tableLayoutPanel9);
            this.tabHerramientas.Location = new System.Drawing.Point(4, 24);
            this.tabHerramientas.Name = "tabHerramientas";
            this.tabHerramientas.Size = new System.Drawing.Size(597, 399);
            this.tabHerramientas.TabIndex = 2;
            this.tabHerramientas.Text = "Herramientas";
            this.tabHerramientas.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.01058F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.00593F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.87093F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.11257F));
            this.tableLayoutPanel9.Controls.Add(this.dtgHerr, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblCargadas, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label15, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.metroButton2, 3, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.761788F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.23821F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(597, 399);
            this.tableLayoutPanel9.TabIndex = 0;
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
            this.tableLayoutPanel9.SetColumnSpan(this.dtgHerr, 4);
            this.dtgHerr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHerr.Location = new System.Drawing.Point(2, 32);
            this.dtgHerr.Margin = new System.Windows.Forms.Padding(2);
            this.dtgHerr.MultiSelect = false;
            this.dtgHerr.Name = "dtgHerr";
            this.dtgHerr.RowTemplate.Height = 180;
            this.dtgHerr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHerr.Size = new System.Drawing.Size(593, 365);
            this.dtgHerr.TabIndex = 15;
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
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(41, 15);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 15);
            this.label20.TabIndex = 11;
            this.label20.Text = "Cargada(s)";
            // 
            // lblCargadas
            // 
            this.lblCargadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCargadas.AutoSize = true;
            this.lblCargadas.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargadas.ForeColor = System.Drawing.Color.Black;
            this.lblCargadas.Location = new System.Drawing.Point(151, 16);
            this.lblCargadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargadas.Name = "lblCargadas";
            this.lblCargadas.Size = new System.Drawing.Size(14, 14);
            this.lblCargadas.TabIndex = 12;
            this.lblCargadas.Text = "0";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(288, 15);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "Cargar herramientas con asistente";
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton2.Location = new System.Drawing.Point(490, 4);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(31, 24);
            this.metroButton2.TabIndex = 14;
            this.metroButton2.Text = "...";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // tabPasoPaso
            // 
            this.tabPasoPaso.Controls.Add(this.tableLayoutPanel11);
            this.tabPasoPaso.Location = new System.Drawing.Point(4, 24);
            this.tabPasoPaso.Name = "tabPasoPaso";
            this.tabPasoPaso.Size = new System.Drawing.Size(597, 399);
            this.tabPasoPaso.TabIndex = 4;
            this.tabPasoPaso.Text = "Paso a paso";
            this.tabPasoPaso.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.23729F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.37288F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.11864F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.27119F));
            this.tableLayoutPanel11.Controls.Add(this.dtgPasoAPaso, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblPaPCargados, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.btnPaso, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.btnEditar, 3, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.022787F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.97721F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(597, 399);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // dtgPasoAPaso
            // 
            this.dtgPasoAPaso.AllowUserToAddRows = false;
            this.dtgPasoAPaso.BackgroundColor = System.Drawing.Color.White;
            this.dtgPasoAPaso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPasoAPaso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.herramientaC,
            this.dataGridViewImageColumn3,
            this.foto,
            this.image_path_pp});
            this.tableLayoutPanel11.SetColumnSpan(this.dtgPasoAPaso, 4);
            this.dtgPasoAPaso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPasoAPaso.Location = new System.Drawing.Point(2, 34);
            this.dtgPasoAPaso.Margin = new System.Windows.Forms.Padding(2);
            this.dtgPasoAPaso.MultiSelect = false;
            this.dtgPasoAPaso.Name = "dtgPasoAPaso";
            this.dtgPasoAPaso.RowTemplate.Height = 180;
            this.dtgPasoAPaso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPasoAPaso.Size = new System.Drawing.Size(593, 363);
            this.dtgPasoAPaso.TabIndex = 22;
            this.dtgPasoAPaso.Visible = false;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(36, 17);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 15);
            this.label23.TabIndex = 18;
            this.label23.Text = "Agregado(s)";
            // 
            // lblPaPCargados
            // 
            this.lblPaPCargados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaPCargados.AutoSize = true;
            this.lblPaPCargados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaPCargados.ForeColor = System.Drawing.Color.Black;
            this.lblPaPCargados.Location = new System.Drawing.Point(146, 18);
            this.lblPaPCargados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaPCargados.Name = "lblPaPCargados";
            this.lblPaPCargados.Size = new System.Drawing.Size(14, 14);
            this.lblPaPCargados.TabIndex = 19;
            this.lblPaPCargados.Text = "0";
            // 
            // btnPaso
            // 
            this.btnPaso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPaso.Location = new System.Drawing.Point(299, 6);
            this.btnPaso.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(117, 24);
            this.btnPaso.TabIndex = 20;
            this.btnPaso.Text = "Nuevo paso ";
            this.btnPaso.Click += new System.EventHandler(this.btnPaso_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditar.Location = new System.Drawing.Point(459, 6);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(117, 24);
            this.btnEditar.TabIndex = 21;
            this.btnEditar.Text = "Editar paso";
            this.btnEditar.Visible = false;
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
            // bgSaveData
            // 
            this.bgSaveData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSaveData_DoWork);
            this.bgSaveData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSaveData_RunWorkerCompleted);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "numPaso";
            this.dataGridViewTextBoxColumn2.HeaderText = "Paso";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "duracion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Duración";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // herramientaC
            // 
            this.herramientaC.DataPropertyName = "herramienta";
            this.herramientaC.HeaderText = "Herramienta";
            this.herramientaC.Name = "herramientaC";
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
            this.foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.foto.Name = "foto";
            // 
            // image_path_pp
            // 
            this.image_path_pp.DataPropertyName = "imagen_paso_path";
            this.image_path_pp.HeaderText = "image_path";
            this.image_path_pp.Name = "image_path_pp";
            this.image_path_pp.Visible = false;
            // 
            // FormSop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 587);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSop";
            this.Load += new System.EventHandler(this.FormSop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabcontrol.ResumeLayout(false);
            this.tabInformacionBasica.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabEpps.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEpps)).EndInit();
            this.tabHerramientas.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).EndInit();
            this.tabPasoPaso.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPasoAPaso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblGenerando;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.Button btnSiguiente1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lblPorcentaje;
        private MetroFramework.Controls.MetroCheckBox chkPDF;
        private System.Windows.Forms.ImageList EppsImages;
        private System.Windows.Forms.TabControl tabcontrol;
        private System.Windows.Forms.TabPage tabInformacionBasica;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtConsecutivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoSop;
        private System.Windows.Forms.TextBox txtNombreSOP;
        private System.Windows.Forms.TextBox txtSOP;
        private System.Windows.Forms.TextBox txtNumRevision;
        private System.Windows.Forms.TextBox txtCodFormato;
        private System.Windows.Forms.ComboBox cboMaquina;
        private System.Windows.Forms.ComboBox cboFrecuencia;
        private System.Windows.Forms.ComboBox cboElaborador;
        private System.Windows.Forms.ComboBox cboAprobador;
        private System.Windows.Forms.ComboBox cboAreaAprobadora;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DateTimePicker dtpMaquinaParada;
        private System.Windows.Forms.DateTimePicker dtpDuracionTarea;
        private System.Windows.Forms.TextBox txtNumPersonas;
        private System.Windows.Forms.DateTimePicker dtpTiempoPersona;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabEpps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.DataGridView dtgEpps;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn image_path;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSeleccionados;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabHerramientas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.DataGridView dtgHerr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sel_herr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramienta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCargadas;
        private System.Windows.Forms.Label label15;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.TabPage tabPasoPaso;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.DataGridView dtgPasoAPaso;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPaPCargados;
        private MetroFramework.Controls.MetroButton btnPaso;
        private MetroFramework.Controls.MetroButton btnEditar;
        private System.ComponentModel.BackgroundWorker bgSaveData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramientaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn image_path_pp;
    }
}