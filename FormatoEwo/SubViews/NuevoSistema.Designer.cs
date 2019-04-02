namespace FormatoEwo.SubViews
{
    partial class NuevoSistema
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.lblSelected = new MetroFramework.Controls.MetroLabel();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.cmsImagen1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.cboMaquina = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.cmsImagen1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel1.Controls.Add(this.metroButton1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSelected, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbImg1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboMaquina, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10943F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10943F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.67172F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10943F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(3, 261);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(184, 23);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Aceptar";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Location = new System.Drawing.Point(237, 261);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(228, 23);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(132, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Maquina relacionada";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 47);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Nombre del sistema";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(193, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PromptText = "Ingrese el nombre de la maquina...";
            this.txtNombre.Size = new System.Drawing.Size(272, 23);
            this.txtNombre.TabIndex = 14;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(3, 164);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 0);
            this.lblSelected.TabIndex = 10;
            // 
            // pbImg1
            // 
            this.pbImg1.ContextMenuStrip = this.cmsImagen1;
            this.pbImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg1.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg1.Location = new System.Drawing.Point(193, 79);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(264, 171);
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
            // cboMaquina
            // 
            this.cboMaquina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaquina.DisplayMember = "nombre";
            this.cboMaquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaquina.FormattingEnabled = true;
            this.cboMaquina.Location = new System.Drawing.Point(193, 8);
            this.cboMaquina.Name = "cboMaquina";
            this.cboMaquina.Size = new System.Drawing.Size(272, 21);
            this.cboMaquina.TabIndex = 16;
            this.cboMaquina.ValueMember = "Id";
            // 
            // NuevoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 372);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NuevoSistema";
            this.Text = "Nuevo sistema";
            this.Load += new System.EventHandler(this.NuevoSistema_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.cmsImagen1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblSelected;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private System.Windows.Forms.PictureBox pbImg1;
        private MetroFramework.Controls.MetroButton btnCerrar;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ComboBox cboMaquina;
        private System.Windows.Forms.ContextMenuStrip cmsImagen1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen;
    }
}