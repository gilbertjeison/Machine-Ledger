namespace FormatoEwo.SubViews
{
    partial class NuevaEntradaMtto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaEntradaMtto));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbDatosEntrada = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSMP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEwo = new System.Windows.Forms.ComboBox();
            this.dtpFech = new System.Windows.Forms.ComboBox();
            this.txtTiempoAverias = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkMttoPlaneado = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkAveria = new System.Windows.Forms.CheckBox();
            this.chkMttoPE = new System.Windows.Forms.CheckBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.txtTecnicos = new System.Windows.Forms.TextBox();
            this.chkMttoExtra = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtReplicas = new System.Windows.Forms.NumericUpDown();
            this.txtHasta = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuevaEntrada = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargarSmp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.gbLista = new System.Windows.Forms.GroupBox();
            this.lvMtto = new System.Windows.Forms.ListView();
            this.fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ewo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duracion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observaciones = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bgSave = new System.ComponentModel.BackgroundWorker();
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.bgDelete = new System.ComponentModel.BackgroundWorker();
            this.bgSaveMultipleEntry = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbDatosEntrada.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplicas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.gbLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbDatosEntrada, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbLista, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.07188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.7463F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.28818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbDatosEntrada
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDatosEntrada, 2);
            this.gbDatosEntrada.Controls.Add(this.tableLayoutPanel2);
            this.gbDatosEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDatosEntrada.Enabled = false;
            this.gbDatosEntrada.Location = new System.Drawing.Point(3, 3);
            this.gbDatosEntrada.Name = "gbDatosEntrada";
            this.gbDatosEntrada.Size = new System.Drawing.Size(715, 205);
            this.gbDatosEntrada.TabIndex = 0;
            this.gbDatosEntrada.TabStop = false;
            this.gbDatosEntrada.Text = "Datos de entrada";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.27581F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.97595F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.12448F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.30551F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.31825F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSMP, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboEwo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpFech, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTiempoAverias, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCantidad, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkMttoPlaneado, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkAveria, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkMttoPE, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtDuracion, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTecnicos, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkMttoExtra, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtObservaciones, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtReplicas, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtHasta, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(709, 183);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "Replicar cada (semanas)";
            // 
            // txtSMP
            // 
            this.txtSMP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMP.ForeColor = System.Drawing.Color.Black;
            this.txtSMP.Location = new System.Drawing.Point(111, 70);
            this.txtSMP.Name = "txtSMP";
            this.txtSMP.Size = new System.Drawing.Size(213, 20);
            this.txtSMP.TabIndex = 23;
            this.txtSMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de entrada";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleccione ewo";
            // 
            // cboEwo
            // 
            this.cboEwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEwo.DisplayMember = "desc_averia";
            this.cboEwo.DropDownWidth = 500;
            this.cboEwo.FormattingEnabled = true;
            this.cboEwo.Location = new System.Drawing.Point(111, 37);
            this.cboEwo.Name = "cboEwo";
            this.cboEwo.Size = new System.Drawing.Size(213, 23);
            this.cboEwo.TabIndex = 12;
            this.cboEwo.ValueMember = "Id";
            this.cboEwo.SelectedIndexChanged += new System.EventHandler(this.cboEwo_SelectedIndexChanged);
            // 
            // dtpFech
            // 
            this.dtpFech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.dtpFech, 3);
            this.dtpFech.DisplayMember = "fecha";
            this.dtpFech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpFech.DropDownWidth = 300;
            this.dtpFech.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFech.FormattingEnabled = true;
            this.dtpFech.Location = new System.Drawing.Point(111, 4);
            this.dtpFech.Name = "dtpFech";
            this.dtpFech.Size = new System.Drawing.Size(414, 23);
            this.dtpFech.TabIndex = 17;
            this.dtpFech.ValueMember = "wy";
            // 
            // txtTiempoAverias
            // 
            this.txtTiempoAverias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiempoAverias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempoAverias.ForeColor = System.Drawing.Color.Black;
            this.txtTiempoAverias.Location = new System.Drawing.Point(330, 38);
            this.txtTiempoAverias.Name = "txtTiempoAverias";
            this.txtTiempoAverias.Size = new System.Drawing.Size(108, 20);
            this.txtTiempoAverias.TabIndex = 0;
            this.txtTiempoAverias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTiempoAverias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(444, 38);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(81, 20);
            this.txtCantidad.TabIndex = 16;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Goldenrod;
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "SMP asignado";
            // 
            // chkMttoPlaneado
            // 
            this.chkMttoPlaneado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMttoPlaneado.AutoSize = true;
            this.chkMttoPlaneado.ImageIndex = 3;
            this.chkMttoPlaneado.ImageList = this.imageList1;
            this.chkMttoPlaneado.Location = new System.Drawing.Point(531, 67);
            this.chkMttoPlaneado.Name = "chkMttoPlaneado";
            this.chkMttoPlaneado.Size = new System.Drawing.Size(118, 26);
            this.chkMttoPlaneado.TabIndex = 8;
            this.chkMttoPlaneado.Tag = "17";
            this.chkMttoPlaneado.Text = "Mtto planeado";
            this.chkMttoPlaneado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMttoPlaneado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkMttoPlaneado.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "image170.png");
            this.imageList1.Images.SetKeyName(1, "image171.png");
            this.imageList1.Images.SetKeyName(2, "image172.png");
            this.imageList1.Images.SetKeyName(3, "image173.png");
            this.imageList1.Images.SetKeyName(4, "delete.png");
            this.imageList1.Images.SetKeyName(5, "icon_change_blue.jpg");
            this.imageList1.Images.SetKeyName(6, "edit.png");
            this.imageList1.Images.SetKeyName(7, "select all.png");
            this.imageList1.Images.SetKeyName(8, "add.png");
            this.imageList1.Images.SetKeyName(9, "salir2.png");
            this.imageList1.Images.SetKeyName(10, "save1600.png");
            this.imageList1.Images.SetKeyName(11, "save-icon-91461.png");
            this.imageList1.Images.SetKeyName(12, "excel.png");
            // 
            // chkAveria
            // 
            this.chkAveria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAveria.AutoSize = true;
            this.chkAveria.ImageIndex = 0;
            this.chkAveria.ImageList = this.imageList1;
            this.chkAveria.Location = new System.Drawing.Point(531, 35);
            this.chkAveria.Name = "chkAveria";
            this.chkAveria.Size = new System.Drawing.Size(74, 26);
            this.chkAveria.TabIndex = 7;
            this.chkAveria.Tag = "20";
            this.chkAveria.Text = "Avería";
            this.chkAveria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAveria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkAveria.UseVisualStyleBackColor = true;
            // 
            // chkMttoPE
            // 
            this.chkMttoPE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMttoPE.AutoSize = true;
            this.chkMttoPE.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMttoPE.ImageIndex = 1;
            this.chkMttoPE.ImageList = this.imageList1;
            this.chkMttoPE.Location = new System.Drawing.Point(531, 99);
            this.chkMttoPE.Name = "chkMttoPE";
            this.chkMttoPE.Size = new System.Drawing.Size(164, 26);
            this.chkMttoPE.TabIndex = 10;
            this.chkMttoPE.Tag = "18";
            this.chkMttoPE.Text = "Mtto planeado ejecutado";
            this.chkMttoPE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkMttoPE.UseVisualStyleBackColor = true;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuracion.ForeColor = System.Drawing.Color.Black;
            this.txtDuracion.Location = new System.Drawing.Point(330, 70);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(108, 20);
            this.txtDuracion.TabIndex = 22;
            this.txtDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTecnicos
            // 
            this.txtTecnicos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTecnicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTecnicos.ForeColor = System.Drawing.Color.Black;
            this.txtTecnicos.Location = new System.Drawing.Point(444, 70);
            this.txtTecnicos.Name = "txtTecnicos";
            this.txtTecnicos.Size = new System.Drawing.Size(81, 20);
            this.txtTecnicos.TabIndex = 23;
            this.txtTecnicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkMttoExtra
            // 
            this.chkMttoExtra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMttoExtra.AutoSize = true;
            this.chkMttoExtra.ImageIndex = 2;
            this.chkMttoExtra.ImageList = this.imageList1;
            this.chkMttoExtra.Location = new System.Drawing.Point(531, 3);
            this.chkMttoExtra.Name = "chkMttoExtra";
            this.chkMttoExtra.Size = new System.Drawing.Size(96, 26);
            this.chkMttoExtra.TabIndex = 9;
            this.chkMttoExtra.Tag = "19";
            this.chkMttoExtra.Text = "Mtto extra";
            this.chkMttoExtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMttoExtra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkMttoExtra.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtObservaciones, 4);
            this.txtObservaciones.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(111, 131);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(595, 49);
            this.txtObservaciones.TabIndex = 19;
            // 
            // txtReplicas
            // 
            this.txtReplicas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplicas.Location = new System.Drawing.Point(111, 100);
            this.txtReplicas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtReplicas.Name = "txtReplicas";
            this.txtReplicas.Size = new System.Drawing.Size(213, 23);
            this.txtReplicas.TabIndex = 24;
            this.txtReplicas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHasta
            // 
            this.txtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHasta.Location = new System.Drawing.Point(444, 100);
            this.txtHasta.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtHasta.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(81, 23);
            this.txtHasta.TabIndex = 25;
            this.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHasta.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnNuevaEntrada, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnCargarSmp, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 506);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(354, 97);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // btnNuevaEntrada
            // 
            this.btnNuevaEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevaEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaEntrada.ImageIndex = 8;
            this.btnNuevaEntrada.ImageList = this.imageList1;
            this.btnNuevaEntrada.Location = new System.Drawing.Point(6, 59);
            this.btnNuevaEntrada.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNuevaEntrada.Name = "btnNuevaEntrada";
            this.btnNuevaEntrada.Size = new System.Drawing.Size(165, 26);
            this.btnNuevaEntrada.TabIndex = 26;
            this.btnNuevaEntrada.Text = "Nueva entrada";
            this.btnNuevaEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevaEntrada.UseVisualStyleBackColor = true;
            this.btnNuevaEntrada.Click += new System.EventHandler(this.btnNuevaEntrada_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageIndex = 9;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(183, 59);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(165, 26);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCargarSmp
            // 
            this.btnCargarSmp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarSmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarSmp.ImageIndex = 12;
            this.btnCargarSmp.ImageList = this.imageList1;
            this.btnCargarSmp.Location = new System.Drawing.Point(180, 19);
            this.btnCargarSmp.Name = "btnCargarSmp";
            this.btnCargarSmp.Size = new System.Drawing.Size(171, 26);
            this.btnCargarSmp.TabIndex = 38;
            this.btnCargarSmp.Text = "Ver SMP";
            this.btnCargarSmp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarSmp.UseVisualStyleBackColor = true;
            this.btnCargarSmp.Click += new System.EventHandler(this.btnCargarSmp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel6);
            this.groupBox3.Location = new System.Drawing.Point(363, 506);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 97);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnSelectAll, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnEditar, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnActualizar, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnRemover, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(349, 75);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAll.ImageIndex = 7;
            this.btnSelectAll.ImageList = this.imageList1;
            this.btnSelectAll.Location = new System.Drawing.Point(180, 42);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(163, 28);
            this.btnSelectAll.TabIndex = 27;
            this.btnSelectAll.Text = "Seleccionar todas";
            this.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.Enabled = false;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.ImageIndex = 6;
            this.btnEditar.ImageList = this.imageList1;
            this.btnEditar.Location = new System.Drawing.Point(6, 42);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(162, 28);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "Editar entrada";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.ImageIndex = 5;
            this.btnActualizar.ImageList = this.imageList1;
            this.btnActualizar.Location = new System.Drawing.Point(6, 5);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(162, 27);
            this.btnActualizar.TabIndex = 25;
            this.btnActualizar.Text = "Actualizar entradas";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemover.Enabled = false;
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemover.ImageIndex = 4;
            this.btnRemover.ImageList = this.imageList1;
            this.btnRemover.Location = new System.Drawing.Point(180, 5);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(163, 27);
            this.btnRemover.TabIndex = 24;
            this.btnRemover.Text = "Remover entrada(s)";
            this.btnRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // gbLista
            // 
            this.gbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.gbLista, 2);
            this.gbLista.Controls.Add(this.lvMtto);
            this.gbLista.Location = new System.Drawing.Point(3, 214);
            this.gbLista.Name = "gbLista";
            this.tableLayoutPanel1.SetRowSpan(this.gbLista, 2);
            this.gbLista.Size = new System.Drawing.Size(715, 286);
            this.gbLista.TabIndex = 4;
            this.gbLista.TabStop = false;
            this.gbLista.Text = "Entradas de mtto del componente";
            // 
            // lvMtto
            // 
            this.lvMtto.CheckBoxes = true;
            this.lvMtto.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fecha,
            this.year,
            this.descripcion,
            this.ewo,
            this.duracion,
            this.cantidad,
            this.observaciones,
            this.user_id});
            this.lvMtto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMtto.LargeImageList = this.imageList1;
            this.lvMtto.Location = new System.Drawing.Point(3, 19);
            this.lvMtto.Name = "lvMtto";
            this.lvMtto.Size = new System.Drawing.Size(709, 264);
            this.lvMtto.SmallImageList = this.imageList1;
            this.lvMtto.TabIndex = 3;
            this.lvMtto.UseCompatibleStateImageBehavior = false;
            this.lvMtto.View = System.Windows.Forms.View.Details;
            this.lvMtto.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMtto_ItemChecked);
            // 
            // fecha
            // 
            this.fecha.Text = "Semana";
            this.fecha.Width = 105;
            // 
            // year
            // 
            this.year.Text = "Año";
            // 
            // descripcion
            // 
            this.descripcion.Text = "Descripción";
            this.descripcion.Width = 200;
            // 
            // ewo
            // 
            this.ewo.Text = "# Ewo";
            // 
            // duracion
            // 
            this.duracion.Text = "Duración";
            // 
            // cantidad
            // 
            this.cantidad.Text = "Cantidad";
            // 
            // observaciones
            // 
            this.observaciones.Text = "Observaciones";
            this.observaciones.Width = 600;
            // 
            // user_id
            // 
            this.user_id.Text = "Diligenciado por...";
            this.user_id.Width = 200;
            // 
            // bgSave
            // 
            this.bgSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSave_DoWork);
            this.bgSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSave_RunWorkerCompleted);
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoad_RunWorkerCompleted);
            // 
            // bgDelete
            // 
            this.bgDelete.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDelete_DoWork);
            this.bgDelete.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDelete_RunWorkerCompleted);
            // 
            // bgSaveMultipleEntry
            // 
            this.bgSaveMultipleEntry.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSaveMultipleEntry_DoWork);
            this.bgSaveMultipleEntry.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSaveMultipleEntry_RunWorkerCompleted);
            // 
            // NuevaEntradaMtto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(767, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NuevaEntradaMtto";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "Nueva entrada de mantenimiento";
            this.Load += new System.EventHandler(this.NuevaEntradaMtto_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbDatosEntrada.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplicas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasta)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.gbLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbDatosEntrada;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtTiempoAverias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAveria;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkMttoPlaneado;
        private System.Windows.Forms.CheckBox chkMttoExtra;
        private System.Windows.Forms.CheckBox chkMttoPE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEwo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.ComponentModel.BackgroundWorker bgSave;
        private System.ComponentModel.BackgroundWorker bgLoad;
        private System.Windows.Forms.ListView lvMtto;
        private System.Windows.Forms.ColumnHeader fecha;
        private System.Windows.Forms.ColumnHeader descripcion;
        private System.Windows.Forms.ColumnHeader ewo;
        private System.Windows.Forms.ColumnHeader duracion;
        private System.Windows.Forms.ColumnHeader cantidad;
        private System.Windows.Forms.GroupBox gbLista;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnEditar;
        private System.ComponentModel.BackgroundWorker bgDelete;
        private System.Windows.Forms.Button btnNuevaEntrada;
        private System.Windows.Forms.ComboBox dtpFech;
        private System.Windows.Forms.ColumnHeader observaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.TextBox txtTecnicos;
        private System.Windows.Forms.TextBox txtSMP;
        private System.Windows.Forms.ColumnHeader year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtReplicas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtHasta;
        private System.ComponentModel.BackgroundWorker bgSaveMultipleEntry;
        private System.Windows.Forms.ColumnHeader user_id;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCargarSmp;
    }
}