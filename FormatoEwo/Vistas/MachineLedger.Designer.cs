namespace FormatoEwo.Vistas
{
    partial class MachineLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineLedger));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageOptions = new System.Windows.Forms.ImageList(this.components);
            this.tlpConjuntos = new System.Windows.Forms.TableLayoutPanel();
            this.lblConjuntos = new System.Windows.Forms.Label();
            this.lvConjuntos = new System.Windows.Forms.ListView();
            this.imagesConjuntos = new System.Windows.Forms.ImageList(this.components);
            this.txtBuscarConjunto = new System.Windows.Forms.TextBox();
            this.tlpSistemas = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscarSistemas = new System.Windows.Forms.TextBox();
            this.lblSistemas = new System.Windows.Forms.Label();
            this.lvSistemas = new System.Windows.Forms.ListView();
            this.imagesSubSystems = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaquinas = new System.Windows.Forms.Label();
            this.lvMaquinas = new System.Windows.Forms.ListView();
            this.cmsMaquina = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCrearMaquina = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDuplicar = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesMachines = new System.Windows.Forms.ImageList(this.components);
            this.lblSelected = new System.Windows.Forms.Label();
            this.tlpDetalles = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lvOpciones = new System.Windows.Forms.ListView();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.bgLoad = new System.ComponentModel.BackgroundWorker();
            this.bgLoadSistemas = new System.ComponentModel.BackgroundWorker();
            this.bgLoadConjuntos = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpConjuntos.SuspendLayout();
            this.tlpSistemas.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.cmsMaquina.SuspendLayout();
            this.tlpDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.32749F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.10526F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.28655F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.51462F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpConjuntos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlpSistemas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSelected, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpDetalles, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 591);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 9;
            this.button1.ImageList = this.imageOptions;
            this.button1.Location = new System.Drawing.Point(722, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Admin. líneas";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageOptions
            // 
            this.imageOptions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageOptions.ImageStream")));
            this.imageOptions.TransparentColor = System.Drawing.Color.Transparent;
            this.imageOptions.Images.SetKeyName(0, "add.png");
            this.imageOptions.Images.SetKeyName(1, "edit.png");
            this.imageOptions.Images.SetKeyName(2, "delete.png");
            this.imageOptions.Images.SetKeyName(3, "machine.png");
            this.imageOptions.Images.SetKeyName(4, "system.png");
            this.imageOptions.Images.SetKeyName(5, "conjunto.png");
            this.imageOptions.Images.SetKeyName(6, "componente.png");
            this.imageOptions.Images.SetKeyName(7, "icon_change_blue.jpg");
            this.imageOptions.Images.SetKeyName(8, "Factory_icon_265x265.png");
            this.imageOptions.Images.SetKeyName(9, "collapse icon.png");
            // 
            // tlpConjuntos
            // 
            this.tlpConjuntos.ColumnCount = 2;
            this.tlpConjuntos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConjuntos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConjuntos.Controls.Add(this.lblConjuntos, 0, 0);
            this.tlpConjuntos.Controls.Add(this.lvConjuntos, 0, 1);
            this.tlpConjuntos.Controls.Add(this.txtBuscarConjunto, 1, 0);
            this.tlpConjuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConjuntos.Location = new System.Drawing.Point(398, 62);
            this.tlpConjuntos.Name = "tlpConjuntos";
            this.tlpConjuntos.RowCount = 2;
            this.tlpConjuntos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpConjuntos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tlpConjuntos.Size = new System.Drawing.Size(175, 526);
            this.tlpConjuntos.TabIndex = 12;
            this.tlpConjuntos.Visible = false;
            // 
            // lblConjuntos
            // 
            this.lblConjuntos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConjuntos.AutoSize = true;
            this.lblConjuntos.BackColor = System.Drawing.Color.Azure;
            this.lblConjuntos.Location = new System.Drawing.Point(3, 10);
            this.lblConjuntos.Name = "lblConjuntos";
            this.lblConjuntos.Size = new System.Drawing.Size(61, 15);
            this.lblConjuntos.TabIndex = 10;
            this.lblConjuntos.Text = "Conjuntos";
            // 
            // lvConjuntos
            // 
            this.tlpConjuntos.SetColumnSpan(this.lvConjuntos, 2);
            this.lvConjuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConjuntos.GridLines = true;
            this.lvConjuntos.HideSelection = false;
            this.lvConjuntos.LargeImageList = this.imagesConjuntos;
            this.lvConjuntos.Location = new System.Drawing.Point(2, 38);
            this.lvConjuntos.Margin = new System.Windows.Forms.Padding(2);
            this.lvConjuntos.MultiSelect = false;
            this.lvConjuntos.Name = "lvConjuntos";
            this.lvConjuntos.Size = new System.Drawing.Size(171, 486);
            this.lvConjuntos.TabIndex = 6;
            this.lvConjuntos.UseCompatibleStateImageBehavior = false;
            this.lvConjuntos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvConjuntos_ItemSelectionChanged);
            // 
            // imagesConjuntos
            // 
            this.imagesConjuntos.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagesConjuntos.ImageSize = new System.Drawing.Size(150, 150);
            this.imagesConjuntos.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtBuscarConjunto
            // 
            this.txtBuscarConjunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarConjunto.Location = new System.Drawing.Point(90, 6);
            this.txtBuscarConjunto.Name = "txtBuscarConjunto";
            this.txtBuscarConjunto.Size = new System.Drawing.Size(82, 23);
            this.txtBuscarConjunto.TabIndex = 11;
            this.txtBuscarConjunto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtBuscarConjunto.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtBuscarConjunto.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // tlpSistemas
            // 
            this.tlpSistemas.ColumnCount = 2;
            this.tlpSistemas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSistemas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSistemas.Controls.Add(this.txtBuscarSistemas, 1, 0);
            this.tlpSistemas.Controls.Add(this.lblSistemas, 0, 0);
            this.tlpSistemas.Controls.Add(this.lvSistemas, 0, 1);
            this.tlpSistemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSistemas.Location = new System.Drawing.Point(210, 62);
            this.tlpSistemas.Name = "tlpSistemas";
            this.tlpSistemas.RowCount = 2;
            this.tlpSistemas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpSistemas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tlpSistemas.Size = new System.Drawing.Size(182, 526);
            this.tlpSistemas.TabIndex = 11;
            this.tlpSistemas.Visible = false;
            // 
            // txtBuscarSistemas
            // 
            this.txtBuscarSistemas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarSistemas.Location = new System.Drawing.Point(94, 6);
            this.txtBuscarSistemas.Name = "txtBuscarSistemas";
            this.txtBuscarSistemas.Size = new System.Drawing.Size(85, 23);
            this.txtBuscarSistemas.TabIndex = 12;
            this.txtBuscarSistemas.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtBuscarSistemas.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtBuscarSistemas.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // lblSistemas
            // 
            this.lblSistemas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSistemas.AutoSize = true;
            this.lblSistemas.BackColor = System.Drawing.Color.Azure;
            this.lblSistemas.Location = new System.Drawing.Point(3, 10);
            this.lblSistemas.Name = "lblSistemas";
            this.lblSistemas.Size = new System.Drawing.Size(56, 15);
            this.lblSistemas.TabIndex = 10;
            this.lblSistemas.Text = "Sistemas";
            // 
            // lvSistemas
            // 
            this.tlpSistemas.SetColumnSpan(this.lvSistemas, 2);
            this.lvSistemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSistemas.HideSelection = false;
            this.lvSistemas.LargeImageList = this.imagesSubSystems;
            this.lvSistemas.Location = new System.Drawing.Point(3, 39);
            this.lvSistemas.MultiSelect = false;
            this.lvSistemas.Name = "lvSistemas";
            this.lvSistemas.Size = new System.Drawing.Size(176, 484);
            this.lvSistemas.SmallImageList = this.imagesSubSystems;
            this.lvSistemas.TabIndex = 7;
            this.lvSistemas.UseCompatibleStateImageBehavior = false;
            this.lvSistemas.View = System.Windows.Forms.View.Tile;
            this.lvSistemas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvSistemas_ItemSelectionChanged);
            // 
            // imagesSubSystems
            // 
            this.imagesSubSystems.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagesSubSystems.ImageSize = new System.Drawing.Size(16, 16);
            this.imagesSubSystems.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaquinas, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lvMaquinas, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(201, 526);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // lblMaquinas
            // 
            this.lblMaquinas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaquinas.AutoSize = true;
            this.lblMaquinas.BackColor = System.Drawing.Color.Azure;
            this.lblMaquinas.Location = new System.Drawing.Point(3, 10);
            this.lblMaquinas.Name = "lblMaquinas";
            this.lblMaquinas.Size = new System.Drawing.Size(59, 15);
            this.lblMaquinas.TabIndex = 10;
            this.lblMaquinas.Text = "Máquinas";
            // 
            // lvMaquinas
            // 
            this.lvMaquinas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.lvMaquinas, 2);
            this.lvMaquinas.ContextMenuStrip = this.cmsMaquina;
            this.lvMaquinas.GridLines = true;
            this.lvMaquinas.HideSelection = false;
            this.lvMaquinas.LargeImageList = this.imagesMachines;
            this.lvMaquinas.Location = new System.Drawing.Point(2, 38);
            this.lvMaquinas.Margin = new System.Windows.Forms.Padding(2);
            this.lvMaquinas.MultiSelect = false;
            this.lvMaquinas.Name = "lvMaquinas";
            this.lvMaquinas.ShowItemToolTips = true;
            this.lvMaquinas.Size = new System.Drawing.Size(197, 486);
            this.lvMaquinas.TabIndex = 6;
            this.lvMaquinas.UseCompatibleStateImageBehavior = false;
            this.lvMaquinas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMaquinas_ItemSelectionChanged);
            this.lvMaquinas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvMaquinas_KeyDown);
            // 
            // cmsMaquina
            // 
            this.cmsMaquina.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMaquina.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCrearMaquina,
            this.tsmDuplicar});
            this.cmsMaquina.Name = "cmsImagen1";
            this.cmsMaquina.Size = new System.Drawing.Size(188, 48);
            this.cmsMaquina.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsMaquina_ItemClicked);
            // 
            // tsmCrearMaquina
            // 
            this.tsmCrearMaquina.Name = "tsmCrearMaquina";
            this.tsmCrearMaquina.Size = new System.Drawing.Size(187, 22);
            this.tsmCrearMaquina.Text = "Crear nueva máquina";
            // 
            // tsmDuplicar
            // 
            this.tsmDuplicar.Name = "tsmDuplicar";
            this.tsmDuplicar.Size = new System.Drawing.Size(187, 22);
            this.tsmDuplicar.Text = "Duplicar";
            // 
            // imagesMachines
            // 
            this.imagesMachines.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagesMachines.ImageSize = new System.Drawing.Size(150, 150);
            this.imagesMachines.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelected.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblSelected, 3);
            this.lblSelected.Location = new System.Drawing.Point(3, 22);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(16, 15);
            this.lblSelected.TabIndex = 9;
            this.lblSelected.Text = "...";
            // 
            // tlpDetalles
            // 
            this.tlpDetalles.ColumnCount = 3;
            this.tlpDetalles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetalles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetalles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDetalles.Controls.Add(this.lblNombre, 0, 0);
            this.tlpDetalles.Controls.Add(this.lvOpciones, 1, 2);
            this.tlpDetalles.Controls.Add(this.pbImage, 0, 1);
            this.tlpDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalles.Location = new System.Drawing.Point(579, 62);
            this.tlpDetalles.Name = "tlpDetalles";
            this.tlpDetalles.RowCount = 3;
            this.tlpDetalles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDetalles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetalles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetalles.Size = new System.Drawing.Size(273, 526);
            this.tlpDetalles.TabIndex = 13;
            this.tlpDetalles.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Azure;
            this.tlpDetalles.SetColumnSpan(this.lblNombre, 3);
            this.lblNombre.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(128, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(17, 21);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "-";
            // 
            // lvOpciones
            // 
            this.lvOpciones.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvOpciones.BackColor = System.Drawing.Color.White;
            this.lvOpciones.BackgroundImageTiled = true;
            this.lvOpciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlpDetalles.SetColumnSpan(this.lvOpciones, 2);
            this.lvOpciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOpciones.LargeImageList = this.imageOptions;
            this.lvOpciones.Location = new System.Drawing.Point(94, 296);
            this.lvOpciones.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.lvOpciones.MultiSelect = false;
            this.lvOpciones.Name = "lvOpciones";
            this.lvOpciones.Size = new System.Drawing.Size(176, 227);
            this.lvOpciones.SmallImageList = this.imageOptions;
            this.lvOpciones.StateImageList = this.imageOptions;
            this.lvOpciones.TabIndex = 8;
            this.lvOpciones.TileSize = new System.Drawing.Size(100, 100);
            this.lvOpciones.UseCompatibleStateImageBehavior = false;
            this.lvOpciones.View = System.Windows.Forms.View.List;
            this.lvOpciones.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvOpciones_ItemSelectionChanged);
            // 
            // pbImage
            // 
            this.tlpDetalles.SetColumnSpan(this.pbImage, 3);
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(3, 55);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(267, 204);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            // 
            // bgLoad
            // 
            this.bgLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgLoad_DoWork);
            this.bgLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoad_RunWorkerCompleted);
            // 
            // bgLoadSistemas
            // 
            this.bgLoadSistemas.DoWork += new System.ComponentModel.DoWorkEventHandler(this.gbLoadSistemas_DoWork);
            this.bgLoadSistemas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.gbLoadSistemas_RunWorkerCompleted);
            // 
            // bgLoadConjuntos
            // 
            this.bgLoadConjuntos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgLoadConjuntos_DoWork);
            this.bgLoadConjuntos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgLoadConjuntos_RunWorkerCompleted);
            // 
            // MachineLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 685);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineLedger";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "Machine Ledger";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MachineLedger_FormClosed);
            this.Load += new System.EventHandler(this.Lineas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpConjuntos.ResumeLayout(false);
            this.tlpConjuntos.PerformLayout();
            this.tlpSistemas.ResumeLayout(false);
            this.tlpSistemas.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.cmsMaquina.ResumeLayout(false);
            this.tlpDetalles.ResumeLayout(false);
            this.tlpDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imagesMachines;
        private System.Windows.Forms.ImageList imagesSubSystems;
        private System.Windows.Forms.ListView lvSistemas;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMaquinas;
        private System.Windows.Forms.ListView lvMaquinas;
        private System.Windows.Forms.TableLayoutPanel tlpSistemas;
        private System.Windows.Forms.Label lblSistemas;
        private System.Windows.Forms.TableLayoutPanel tlpConjuntos;
        private System.Windows.Forms.Label lblConjuntos;
        private System.Windows.Forms.ListView lvConjuntos;
        private System.Windows.Forms.ImageList imagesConjuntos;
        private System.Windows.Forms.TextBox txtBuscarConjunto;
        private System.Windows.Forms.TextBox txtBuscarSistemas;
        private System.Windows.Forms.TableLayoutPanel tlpDetalles;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ListView lvOpciones;
        private System.Windows.Forms.ImageList imageOptions;
        private System.ComponentModel.BackgroundWorker bgLoad;
        private System.ComponentModel.BackgroundWorker bgLoadSistemas;
        private System.ComponentModel.BackgroundWorker bgLoadConjuntos;
        private System.Windows.Forms.ContextMenuStrip cmsMaquina;
        private System.Windows.Forms.ToolStripMenuItem tsmCrearMaquina;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem tsmDuplicar;
    }
}