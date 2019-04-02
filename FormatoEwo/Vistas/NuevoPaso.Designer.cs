namespace FormatoEwo.Vistas
{
    partial class NuevoPaso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoPaso));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.cmsImagen1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDescripcion = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.gbCategoria = new System.Windows.Forms.GroupBox();
            this.rbProductivity = new MetroFramework.Controls.MetroRadioButton();
            this.rbEnvironment = new MetroFramework.Controls.MetroRadioButton();
            this.rbQuality = new MetroFramework.Controls.MetroRadioButton();
            this.rbSafety = new MetroFramework.Controls.MetroRadioButton();
            this.pbProductivity = new System.Windows.Forms.PictureBox();
            this.pbEnvironment = new System.Windows.Forms.PictureBox();
            this.pbQuality = new System.Windows.Forms.PictureBox();
            this.pbSafety = new System.Windows.Forms.PictureBox();
            this.txtDuracion = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPaso = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.categoryImages = new System.Windows.Forms.ImageList(this.components);
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.cmsImagen1.SuspendLayout();
            this.gbCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnvironment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSafety)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.pbImg1);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.gbCategoria);
            this.groupBox1.Controls.Add(this.txtDuracion);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.txtPaso);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(17, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(504, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese la información del proceso";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(14, 146);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(70, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Fotografía";
            // 
            // pbImg1
            // 
            this.pbImg1.ContextMenuStrip = this.cmsImagen1;
            this.pbImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg1.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg1.Location = new System.Drawing.Point(96, 137);
            this.pbImg1.Margin = new System.Windows.Forms.Padding(2);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(142, 190);
            this.pbImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg1.TabIndex = 7;
            this.pbImg1.TabStop = false;
            this.pbImg1.Click += new System.EventHandler(this.pbImg1_Click);
            // 
            // cmsImagen1
            // 
            this.cmsImagen1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsImagen1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVerImagen,
            this.itemQuitarImagen});
            this.cmsImagen1.Name = "cmsImagen1";
            this.cmsImagen1.Size = new System.Drawing.Size(181, 70);
            this.cmsImagen1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsImagen1_ItemClicked);
            // 
            // tsmVerImagen
            // 
            this.tsmVerImagen.Name = "tsmVerImagen";
            this.tsmVerImagen.Size = new System.Drawing.Size(180, 22);
            this.tsmVerImagen.Text = "Ver imágen";
            // 
            // itemQuitarImagen
            // 
            this.itemQuitarImagen.Name = "itemQuitarImagen";
            this.itemQuitarImagen.Size = new System.Drawing.Size(180, 22);
            this.itemQuitarImagen.Text = "Quitar imágen";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(95, 73);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(398, 45);
            this.txtDescripcion.TabIndex = 6;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 73);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(76, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Descripción";
            // 
            // gbCategoria
            // 
            this.gbCategoria.Controls.Add(this.rbProductivity);
            this.gbCategoria.Controls.Add(this.rbEnvironment);
            this.gbCategoria.Controls.Add(this.rbQuality);
            this.gbCategoria.Controls.Add(this.rbSafety);
            this.gbCategoria.Controls.Add(this.pbProductivity);
            this.gbCategoria.Controls.Add(this.pbEnvironment);
            this.gbCategoria.Controls.Add(this.pbQuality);
            this.gbCategoria.Controls.Add(this.pbSafety);
            this.gbCategoria.Location = new System.Drawing.Point(310, 137);
            this.gbCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.gbCategoria.Name = "gbCategoria";
            this.gbCategoria.Padding = new System.Windows.Forms.Padding(2);
            this.gbCategoria.Size = new System.Drawing.Size(183, 190);
            this.gbCategoria.TabIndex = 4;
            this.gbCategoria.TabStop = false;
            this.gbCategoria.Text = "Categoría";
            // 
            // rbProductivity
            // 
            this.rbProductivity.AutoSize = true;
            this.rbProductivity.Location = new System.Drawing.Point(41, 154);
            this.rbProductivity.Margin = new System.Windows.Forms.Padding(2);
            this.rbProductivity.Name = "rbProductivity";
            this.rbProductivity.Size = new System.Drawing.Size(87, 15);
            this.rbProductivity.TabIndex = 10;
            this.rbProductivity.TabStop = true;
            this.rbProductivity.Text = "Productivity";
            this.rbProductivity.UseVisualStyleBackColor = true;
            this.rbProductivity.CheckedChanged += new System.EventHandler(this.rbSafety_CheckedChanged);
            // 
            // rbEnvironment
            // 
            this.rbEnvironment.AutoSize = true;
            this.rbEnvironment.Location = new System.Drawing.Point(41, 112);
            this.rbEnvironment.Margin = new System.Windows.Forms.Padding(2);
            this.rbEnvironment.Name = "rbEnvironment";
            this.rbEnvironment.Size = new System.Drawing.Size(91, 15);
            this.rbEnvironment.TabIndex = 9;
            this.rbEnvironment.TabStop = true;
            this.rbEnvironment.Text = "Environment";
            this.rbEnvironment.UseVisualStyleBackColor = true;
            this.rbEnvironment.CheckedChanged += new System.EventHandler(this.rbSafety_CheckedChanged);
            // 
            // rbQuality
            // 
            this.rbQuality.AutoSize = true;
            this.rbQuality.Location = new System.Drawing.Point(41, 68);
            this.rbQuality.Margin = new System.Windows.Forms.Padding(2);
            this.rbQuality.Name = "rbQuality";
            this.rbQuality.Size = new System.Drawing.Size(61, 15);
            this.rbQuality.TabIndex = 8;
            this.rbQuality.TabStop = true;
            this.rbQuality.Text = "Quality";
            this.rbQuality.UseVisualStyleBackColor = true;
            this.rbQuality.CheckedChanged += new System.EventHandler(this.rbSafety_CheckedChanged);
            // 
            // rbSafety
            // 
            this.rbSafety.AutoSize = true;
            this.rbSafety.Location = new System.Drawing.Point(41, 25);
            this.rbSafety.Margin = new System.Windows.Forms.Padding(2);
            this.rbSafety.Name = "rbSafety";
            this.rbSafety.Size = new System.Drawing.Size(55, 15);
            this.rbSafety.TabIndex = 7;
            this.rbSafety.TabStop = true;
            this.rbSafety.Text = "Safety";
            this.rbSafety.UseVisualStyleBackColor = true;
            this.rbSafety.CheckedChanged += new System.EventHandler(this.rbSafety_CheckedChanged);
            // 
            // pbProductivity
            // 
            this.pbProductivity.Image = global::FormatoEwo.Properties.Resources.productivity;
            this.pbProductivity.Location = new System.Drawing.Point(13, 148);
            this.pbProductivity.Margin = new System.Windows.Forms.Padding(2);
            this.pbProductivity.Name = "pbProductivity";
            this.pbProductivity.Size = new System.Drawing.Size(24, 27);
            this.pbProductivity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductivity.TabIndex = 6;
            this.pbProductivity.TabStop = false;
            // 
            // pbEnvironment
            // 
            this.pbEnvironment.Image = global::FormatoEwo.Properties.Resources.environment;
            this.pbEnvironment.Location = new System.Drawing.Point(13, 106);
            this.pbEnvironment.Margin = new System.Windows.Forms.Padding(2);
            this.pbEnvironment.Name = "pbEnvironment";
            this.pbEnvironment.Size = new System.Drawing.Size(24, 27);
            this.pbEnvironment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEnvironment.TabIndex = 5;
            this.pbEnvironment.TabStop = false;
            // 
            // pbQuality
            // 
            this.pbQuality.Image = global::FormatoEwo.Properties.Resources.quality;
            this.pbQuality.Location = new System.Drawing.Point(13, 62);
            this.pbQuality.Margin = new System.Windows.Forms.Padding(2);
            this.pbQuality.Name = "pbQuality";
            this.pbQuality.Size = new System.Drawing.Size(24, 27);
            this.pbQuality.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuality.TabIndex = 1;
            this.pbQuality.TabStop = false;
            // 
            // pbSafety
            // 
            this.pbSafety.Image = global::FormatoEwo.Properties.Resources.safety;
            this.pbSafety.Location = new System.Drawing.Point(13, 18);
            this.pbSafety.Margin = new System.Windows.Forms.Padding(2);
            this.pbSafety.Name = "pbSafety";
            this.pbSafety.Size = new System.Drawing.Size(24, 27);
            this.pbSafety.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSafety.TabIndex = 0;
            this.pbSafety.TabStop = false;
            // 
            // txtDuracion
            // 
            this.txtDuracion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtDuracion.Location = new System.Drawing.Point(447, 33);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(46, 20);
            this.txtDuracion.TabIndex = 3;
            this.txtDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuracion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuracion_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(351, 33);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(98, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Duración (MIN)";
            // 
            // txtPaso
            // 
            this.txtPaso.Location = new System.Drawing.Point(95, 33);
            this.txtPaso.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaso.Name = "txtPaso";
            this.txtPaso.Size = new System.Drawing.Size(251, 20);
            this.txtPaso.TabIndex = 1;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 33);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Paso a paso";
            // 
            // categoryImages
            // 
            this.categoryImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("categoryImages.ImageStream")));
            this.categoryImages.TransparentColor = System.Drawing.Color.Transparent;
            this.categoryImages.Images.SetKeyName(0, "safety.png");
            this.categoryImages.Images.SetKeyName(1, "quality.png");
            this.categoryImages.Images.SetKeyName(2, "environment.png");
            this.categoryImages.Images.SetKeyName(3, "productivity.png");
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(211, 433);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 20);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // NuevoPaso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 466);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NuevoPaso";
            this.Padding = new System.Windows.Forms.Padding(15, 65, 15, 17);
            this.Text = "Nuevo paso";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.cmsImagen1.ResumeLayout(false);
            this.gbCategoria.ResumeLayout(false);
            this.gbCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnvironment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSafety)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPaso;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.GroupBox gbCategoria;
        private System.Windows.Forms.PictureBox pbSafety;
        private MetroFramework.Controls.MetroTextBox txtDuracion;
        private System.Windows.Forms.ImageList categoryImages;
        private System.Windows.Forms.PictureBox pbQuality;
        private System.Windows.Forms.PictureBox pbEnvironment;
        private System.Windows.Forms.PictureBox pbProductivity;
        private MetroFramework.Controls.MetroRadioButton rbProductivity;
        private MetroFramework.Controls.MetroRadioButton rbEnvironment;
        private MetroFramework.Controls.MetroRadioButton rbQuality;
        private MetroFramework.Controls.MetroRadioButton rbSafety;
        private MetroFramework.Controls.MetroTextBox txtDescripcion;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.PictureBox pbImg1;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private System.Windows.Forms.ContextMenuStrip cmsImagen1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen;
    }
}