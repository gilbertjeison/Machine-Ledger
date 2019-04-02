namespace FormatoEwo.SubViews
{
    partial class NuevoConjunto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoConjunto));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFrecuenciaPM = new System.Windows.Forms.TextBox();
            this.cboFrecuenciaPM = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEstadoEquipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSmp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEstrategiaMtto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblSelected = new MetroFramework.Controls.MetroLabel();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.cmsImagen1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.cmsImagen1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Azure;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboSistema, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroButton1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSelected, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbImg1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.110092F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.568807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.23853F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.73518F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(593, 502);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nombre del conjunto";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(244, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PromptText = "Ingrese el nombre de la maquina...";
            this.txtNombre.Size = new System.Drawing.Size(346, 27);
            this.txtNombre.TabIndex = 14;
            // 
            // cboSistema
            // 
            this.cboSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSistema.DisplayMember = "NOmbre";
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Location = new System.Drawing.Point(244, 7);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(346, 23);
            this.cboSistema.TabIndex = 16;
            this.cboSistema.ValueMember = "Id";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(3, 462);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(235, 27);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Aceptar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Location = new System.Drawing.Point(324, 462);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(266, 27);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.txtFrecuenciaPM, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboFrecuenciaPM, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboEstadoEquipo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboSmp, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboEstrategiaMtto, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDuracion, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(586, 137);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // txtFrecuenciaPM
            // 
            this.txtFrecuenciaPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrecuenciaPM.Enabled = false;
            this.txtFrecuenciaPM.Location = new System.Drawing.Point(198, 111);
            this.txtFrecuenciaPM.Name = "txtFrecuenciaPM";
            this.txtFrecuenciaPM.Size = new System.Drawing.Size(189, 23);
            this.txtFrecuenciaPM.TabIndex = 36;
            this.txtFrecuenciaPM.Text = "0";
            this.txtFrecuenciaPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboFrecuenciaPM
            // 
            this.cboFrecuenciaPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFrecuenciaPM.DisplayMember = "descripcion";
            this.cboFrecuenciaPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrecuenciaPM.Enabled = false;
            this.cboFrecuenciaPM.FormattingEnabled = true;
            this.cboFrecuenciaPM.Location = new System.Drawing.Point(393, 112);
            this.cboFrecuenciaPM.Name = "cboFrecuenciaPM";
            this.cboFrecuenciaPM.Size = new System.Drawing.Size(190, 23);
            this.cboFrecuenciaPM.TabIndex = 35;
            this.cboFrecuenciaPM.ValueMember = "Id";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Frecuencia";
            // 
            // cboEstadoEquipo
            // 
            this.cboEstadoEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cboEstadoEquipo, 2);
            this.cboEstadoEquipo.DisplayMember = "descripcion";
            this.cboEstadoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoEquipo.Enabled = false;
            this.cboEstadoEquipo.FormattingEnabled = true;
            this.cboEstadoEquipo.Location = new System.Drawing.Point(198, 84);
            this.cboEstadoEquipo.Name = "cboEstadoEquipo";
            this.cboEstadoEquipo.Size = new System.Drawing.Size(385, 23);
            this.cboEstadoEquipo.TabIndex = 31;
            this.cboEstadoEquipo.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Estado equipo";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Duración estandar";
            // 
            // cboSmp
            // 
            this.cboSmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cboSmp, 2);
            this.cboSmp.DisplayMember = "nombre";
            this.cboSmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSmp.FormattingEnabled = true;
            this.cboSmp.Location = new System.Drawing.Point(198, 3);
            this.cboSmp.Name = "cboSmp";
            this.cboSmp.Size = new System.Drawing.Size(385, 23);
            this.cboSmp.TabIndex = 27;
            this.cboSmp.ValueMember = "Id";
            this.cboSmp.SelectedIndexChanged += new System.EventHandler(this.cboSmp_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cod. SMP";
            // 
            // cboEstrategiaMtto
            // 
            this.cboEstrategiaMtto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.cboEstrategiaMtto, 2);
            this.cboEstrategiaMtto.DisplayMember = "descripcion";
            this.cboEstrategiaMtto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstrategiaMtto.Enabled = false;
            this.cboEstrategiaMtto.FormattingEnabled = true;
            this.cboEstrategiaMtto.Location = new System.Drawing.Point(198, 30);
            this.cboEstrategiaMtto.Name = "cboEstrategiaMtto";
            this.cboEstrategiaMtto.Size = new System.Drawing.Size(385, 23);
            this.cboEstrategiaMtto.TabIndex = 25;
            this.cboEstrategiaMtto.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Estrategia de Mtto";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuracion.Enabled = false;
            this.txtDuracion.Location = new System.Drawing.Point(198, 57);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(189, 23);
            this.txtDuracion.TabIndex = 32;
            this.txtDuracion.Text = "0";
            this.txtDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(3, 352);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 0);
            this.lblSelected.TabIndex = 10;
            // 
            // pbImg1
            // 
            this.pbImg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImg1.ContextMenuStrip = this.cmsImagen1;
            this.pbImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImg1.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg1.Location = new System.Drawing.Point(244, 258);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(346, 189);
            this.pbImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg1.TabIndex = 15;
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sistema relacionado";
            // 
            // NuevoConjunto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 596);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevoConjunto";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "Nuevo conjunto";
            this.Load += new System.EventHandler(this.NuevoConjunto_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.cmsImagen1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnCerrar;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroLabel lblSelected;
        private System.Windows.Forms.PictureBox pbImg1;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.ContextMenuStrip cmsImagen1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtFrecuenciaPM;
        private System.Windows.Forms.ComboBox cboFrecuenciaPM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEstadoEquipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboEstrategiaMtto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}