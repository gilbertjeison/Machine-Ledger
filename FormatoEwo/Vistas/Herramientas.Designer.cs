namespace FormatoEwo.Vistas
{
    partial class Herramientas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Herramientas));
            this.lvImagenes = new System.Windows.Forms.ListView();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagenInternet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFijarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramientaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgHerr = new System.Windows.Forms.DataGridView();
            this.herramientasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ewoDatabaseDataSet = new FormatoEwo.EwoDatabaseDataSet();
            this.herramientasTableAdapter = new FormatoEwo.EwoDatabaseDataSetTableAdapters.herramientasTableAdapter();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCantidadImagenes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnsPlaceholder = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pbCargando = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ttBotones = new MetroFramework.Components.MetroToolTip();
            this.sel_herr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.herramienta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmsOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.herramientasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // lvImagenes
            // 
            this.lvImagenes.ContextMenuStrip = this.cmsOpciones;
            this.lvImagenes.LargeImageList = this.imageList1;
            this.lvImagenes.Location = new System.Drawing.Point(475, 26);
            this.lvImagenes.Margin = new System.Windows.Forms.Padding(2);
            this.lvImagenes.MultiSelect = false;
            this.lvImagenes.Name = "lvImagenes";
            this.lvImagenes.Size = new System.Drawing.Size(417, 440);
            this.lvImagenes.TabIndex = 3;
            this.lvImagenes.UseCompatibleStateImageBehavior = false;
            this.lvImagenes.DoubleClick += new System.EventHandler(this.lvImagenes_DoubleClick);
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerImagenInternet,
            this.tsmFijarImagen});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(261, 56);
            this.cmsOpciones.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsOpciones_ItemClicked);
            // 
            // tsmVerImagenInternet
            // 
            this.tsmVerImagenInternet.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.tsmVerImagenInternet.Name = "tsmVerImagenInternet";
            this.tsmVerImagenInternet.Size = new System.Drawing.Size(260, 26);
            this.tsmVerImagenInternet.Text = "Ver imágen";
            // 
            // tsmFijarImagen
            // 
            this.tsmFijarImagen.Image = global::FormatoEwo.Properties.Resources.Work;
            this.tsmFijarImagen.Name = "tsmFijarImagen";
            this.tsmFijarImagen.Size = new System.Drawing.Size(260, 26);
            this.tsmFijarImagen.Text = "Fijar como imagen de herramienta";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(180, 180);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(471, 470);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(383, 18);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Cargando imágenes, espere un momento por favor!...";
            this.lblInfo.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(416, 488);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 34);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // herramientaDataGridViewTextBoxColumn
            // 
            this.herramientaDataGridViewTextBoxColumn.DataPropertyName = "herramienta";
            this.herramientaDataGridViewTextBoxColumn.HeaderText = "herramienta";
            this.herramientaDataGridViewTextBoxColumn.Name = "herramientaDataGridViewTextBoxColumn";
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "tipo";
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            // 
            // dtgHerr
            // 
            this.dtgHerr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHerr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sel_herr,
            this.Id,
            this.herramienta,
            this.tipo,
            this.imagen});
            this.dtgHerr.Location = new System.Drawing.Point(6, 54);
            this.dtgHerr.Margin = new System.Windows.Forms.Padding(2);
            this.dtgHerr.MultiSelect = false;
            this.dtgHerr.Name = "dtgHerr";
            this.dtgHerr.RowTemplate.Height = 24;
            this.dtgHerr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHerr.Size = new System.Drawing.Size(464, 411);
            this.dtgHerr.TabIndex = 6;
            this.dtgHerr.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgHerr_CurrentCellDirtyStateChanged);
            // 
            // herramientasBindingSource
            // 
            this.herramientasBindingSource.DataMember = "herramientas";
            this.herramientasBindingSource.DataSource = this.ewoDatabaseDataSet;
            // 
            // ewoDatabaseDataSet
            // 
            this.ewoDatabaseDataSet.DataSetName = "EwoDatabaseDataSet";
            this.ewoDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // herramientasTableAdapter
            // 
            this.herramientasTableAdapter.ClearBeforeFill = true;
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.ForeColor = System.Drawing.Color.Black;
            this.lblDisponibles.Location = new System.Drawing.Point(180, 36);
            this.lblDisponibles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(14, 14);
            this.lblDisponibles.TabIndex = 13;
            this.lblDisponibles.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(115, 36);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 14);
            this.label16.TabIndex = 12;
            this.label16.Text = "Disponibles";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(304, 14);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 14);
            this.label14.TabIndex = 11;
            this.label14.Text = "Buscar en la lista";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(306, 31);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(165, 22);
            this.txtBuscar.TabIndex = 10;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.lblSeleccionados.Location = new System.Drawing.Point(98, 36);
            this.lblSeleccionados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(14, 14);
            this.lblSeleccionados.TabIndex = 9;
            this.lblSeleccionados.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "Seleccionado(s)";
            // 
            // lblCantidadImagenes
            // 
            this.lblCantidadImagenes.AutoSize = true;
            this.lblCantidadImagenes.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadImagenes.ForeColor = System.Drawing.Color.Black;
            this.lblCantidadImagenes.Location = new System.Drawing.Point(878, 8);
            this.lblCantidadImagenes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadImagenes.Name = "lblCantidadImagenes";
            this.lblCantidadImagenes.Size = new System.Drawing.Size(14, 14);
            this.lblCantidadImagenes.TabIndex = 15;
            this.lblCantidadImagenes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(739, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Imágenes encontradas";
            // 
            // columnsPlaceholder
            // 
            this.columnsPlaceholder.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("columnsPlaceholder.ImageStream")));
            this.columnsPlaceholder.TransparentColor = System.Drawing.Color.Transparent;
            this.columnsPlaceholder.Images.SetKeyName(0, "Sidebar-Pictures-icon.png");
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::FormatoEwo.Properties.Resources.add;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(89, 487);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 33);
            this.button2.TabIndex = 18;
            this.ttBotones.SetToolTip(this.button2, "Agregar nuevo item a la lista");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::FormatoEwo.Properties.Resources.attach;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(47, 487);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 33);
            this.button1.TabIndex = 17;
            this.ttBotones.SetToolTip(this.button1, "Adjuntar imagen desde archivo");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbCargando
            // 
            this.pbCargando.BackColor = System.Drawing.Color.White;
            this.pbCargando.Image = global::FormatoEwo.Properties.Resources.Cargando;
            this.pbCargando.Location = new System.Drawing.Point(628, 182);
            this.pbCargando.Margin = new System.Windows.Forms.Padding(2);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(137, 129);
            this.pbCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargando.TabIndex = 16;
            this.pbCargando.TabStop = false;
            this.pbCargando.Visible = false;
            this.pbCargando.WaitOnLoad = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::FormatoEwo.Properties.Resources.search;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(6, 487);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(30, 33);
            this.btnBuscar.TabIndex = 7;
            this.ttBotones.SetToolTip(this.btnBuscar, "Buscar imágen de fila seleccionada");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ttBotones
            // 
            this.ttBotones.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // sel_herr
            // 
            this.sel_herr.DataPropertyName = "sel";
            this.sel_herr.HeaderText = "Seleccione";
            this.sel_herr.Name = "sel_herr";
            this.sel_herr.Width = 60;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // herramienta
            // 
            this.herramienta.DataPropertyName = "herramienta";
            this.herramienta.HeaderText = "Herramienta";
            this.herramienta.Name = "herramienta";
            this.herramienta.Width = 240;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            // 
            // imagen
            // 
            this.imagen.DataPropertyName = "imagen";
            this.imagen.HeaderText = "Imágen";
            this.imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imagen.Name = "imagen";
            this.imagen.Width = 180;
            // 
            // Herramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(905, 526);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbCargando);
            this.Controls.Add(this.lblCantidadImagenes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblSeleccionados);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtgHerr);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lvImagenes);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Herramientas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Herramientas";
            this.Load += new System.EventHandler(this.Herramientas_Load);
            this.cmsOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHerr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.herramientasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ewoDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvImagenes;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramientaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dtgHerr;
        private EwoDatabaseDataSet ewoDatabaseDataSet;
        private System.Windows.Forms.BindingSource herramientasBindingSource;
        private EwoDatabaseDataSetTableAdapters.herramientasTableAdapter herramientasTableAdapter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblSeleccionados;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagenInternet;
        private System.Windows.Forms.Label lblCantidadImagenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem tsmFijarImagen;
        private System.Windows.Forms.PictureBox pbCargando;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList columnsPlaceholder;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Components.MetroToolTip ttBotones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sel_herr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn herramienta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewImageColumn imagen;
    }
}