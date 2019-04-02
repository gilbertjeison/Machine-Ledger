namespace FormatoEwo.Vistas
{
    partial class Lineas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lineas));
            this.imagesMachines = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lvSubSistemas = new System.Windows.Forms.ListView();
            this.imagesSubSystems = new System.Windows.Forms.ImageList(this.components);
            this.lvImagenes = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imagesMachines
            // 
            this.imagesMachines.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesMachines.ImageStream")));
            this.imagesMachines.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesMachines.Images.SetKeyName(0, "image168.jpg");
            this.imagesMachines.Images.SetKeyName(1, "mespack.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lvImagenes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 423);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbImage);
            this.panel2.Controls.Add(this.lvSubSistemas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(195, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 423);
            this.panel2.TabIndex = 6;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(192, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(315, 423);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // lvSubSistemas
            // 
            this.lvSubSistemas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvSubSistemas.LargeImageList = this.imagesSubSystems;
            this.lvSubSistemas.Location = new System.Drawing.Point(0, 0);
            this.lvSubSistemas.MultiSelect = false;
            this.lvSubSistemas.Name = "lvSubSistemas";
            this.lvSubSistemas.Size = new System.Drawing.Size(192, 423);
            this.lvSubSistemas.SmallImageList = this.imagesSubSystems;
            this.lvSubSistemas.TabIndex = 0;
            this.lvSubSistemas.UseCompatibleStateImageBehavior = false;
            this.lvSubSistemas.View = System.Windows.Forms.View.Tile;
            this.lvSubSistemas.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imagesSubSystems
            // 
            this.imagesSubSystems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesSubSystems.ImageStream")));
            this.imagesSubSystems.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesSubSystems.Images.SetKeyName(0, "tool.png");
            // 
            // lvImagenes
            // 
            this.lvImagenes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvImagenes.GridLines = true;
            this.lvImagenes.LargeImageList = this.imagesMachines;
            this.lvImagenes.Location = new System.Drawing.Point(0, 0);
            this.lvImagenes.Margin = new System.Windows.Forms.Padding(2);
            this.lvImagenes.MultiSelect = false;
            this.lvImagenes.Name = "lvImagenes";
            this.lvImagenes.Size = new System.Drawing.Size(195, 423);
            this.lvImagenes.SmallImageList = this.imagesMachines;
            this.lvImagenes.TabIndex = 5;
            this.lvImagenes.UseCompatibleStateImageBehavior = false;
            this.lvImagenes.DoubleClick += new System.EventHandler(this.lvImagenes_DoubleClick);
            // 
            // Lineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 503);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lineas";
            this.Text = "Lineas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Lineas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imagesMachines;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvImagenes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ListView lvSubSistemas;
        private System.Windows.Forms.ImageList imagesSubSystems;
    }
}