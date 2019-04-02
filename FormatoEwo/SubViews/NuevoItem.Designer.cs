namespace FormatoEwo.SubViews
{
    partial class NuevoItem
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.btnAcpetar = new MetroFramework.Controls.MetroButton();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.cmsImagen1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmVerImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuitarImagen = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cboLinea = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.cmsImagen1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.48744F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.51256F));
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAcpetar, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbImg1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboLinea, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.952029F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.07011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.02214F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.95572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 318);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.White;
            this.metroLabel1.CustomBackground = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 12);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(183, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Línea relacionada";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(192, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PromptText = "Ingrese el nombre de la maquina...";
            this.txtNombre.Size = new System.Drawing.Size(203, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // btnAcpetar
            // 
            this.btnAcpetar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcpetar.Location = new System.Drawing.Point(3, 281);
            this.btnAcpetar.Name = "btnAcpetar";
            this.btnAcpetar.Size = new System.Drawing.Size(183, 23);
            this.btnAcpetar.TabIndex = 4;
            this.btnAcpetar.Text = "Aceptar";
            this.btnAcpetar.Click += new System.EventHandler(this.btnAcpetar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(192, 281);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(203, 23);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // pbImg1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbImg1, 2);
            this.pbImg1.ContextMenuStrip = this.cmsImagen1;
            this.pbImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImg1.Image = global::FormatoEwo.Properties.Resources.placeholder;
            this.pbImg1.Location = new System.Drawing.Point(3, 76);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(392, 188);
            this.pbImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg1.TabIndex = 7;
            this.pbImg1.TabStop = false;
            this.pbImg1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.White;
            this.metroLabel2.CustomBackground = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 45);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(183, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Nombre de la máquina";
            // 
            // cboLinea
            // 
            this.cboLinea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLinea.DisplayMember = "nombre";
            this.cboLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinea.FormattingEnabled = true;
            this.cboLinea.Location = new System.Drawing.Point(192, 11);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Size = new System.Drawing.Size(203, 21);
            this.cboLinea.TabIndex = 17;
            this.cboLinea.ValueMember = "Id";
            // 
            // NuevoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 398);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NuevoItem";
            this.Text = "Nuevo elemento";
            this.Load += new System.EventHandler(this.NuevoItem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.cmsImagen1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnAcpetar;
        private System.Windows.Forms.PictureBox pbImg1;
        private System.Windows.Forms.ContextMenuStrip cmsImagen1;
        private System.Windows.Forms.ToolStripMenuItem tsmVerImagen;
        private System.Windows.Forms.ToolStripMenuItem itemQuitarImagen;
        private MetroFramework.Controls.MetroButton btnCerrar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox cboLinea;
    }
}