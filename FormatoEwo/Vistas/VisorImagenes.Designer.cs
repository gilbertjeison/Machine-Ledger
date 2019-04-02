namespace FormatoEwo.Vistas
{
    partial class VisorImagenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorImagenes));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bgLoadImage = new System.ComponentModel.BackgroundWorker();
            this.imgCargando = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 508);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bgLoadImage
            // 
            this.bgLoadImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadImage_DoWork);
            this.bgLoadImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadImage_RunWorkerCompleted);
            // 
            // imgCargando
            // 
            this.imgCargando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCargando.Image = global::FormatoEwo.Properties.Resources.Cargando;
            this.imgCargando.Location = new System.Drawing.Point(0, 0);
            this.imgCargando.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgCargando.Name = "imgCargando";
            this.imgCargando.Size = new System.Drawing.Size(607, 508);
            this.imgCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgCargando.TabIndex = 1;
            this.imgCargando.TabStop = false;
            // 
            // VisorImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 508);
            this.Controls.Add(this.imgCargando);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Unilever DIN Offc Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VisorImagenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor de Imágenes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VisorImagenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bgLoadImage;
        private System.Windows.Forms.PictureBox imgCargando;
    }
}