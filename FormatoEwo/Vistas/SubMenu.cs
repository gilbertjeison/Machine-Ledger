using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class SubMenu : MetroForm
    {
        public enum Planta {Planta_jabones =  1, Planta_detergentes = 2 }
        public SubMenu()
        {
            InitializeComponent();

            btnML.MouseMove += BtnML_MouseMove;
        }

        private void BtnML_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripDropDown customToolTip = new ToolStripDropDown();
            customToolTip.Items.Add(new CustomPopupControl("Seleccione planta", "world"));

            Point location = e.Location;
            location.Offset(10, 10);
            customToolTip.Show(this, location);

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            FormEwo principal = new FormEwo();
            principal.ShowDialog();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            FormSmp smp = new FormSmp();
            smp.ShowDialog();
        }

        private void btnML_Click(object sender, EventArgs e)
        {
            //Lineas l = new Lineas();
            //l.ShowDialog();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            CalendarioPm cp = new CalendarioPm();
            cp.ShowDialog();
        }

        private void btnWH_Click(object sender, EventArgs e)
        {
            Almacen a = new Almacen();
            a.ShowDialog();
        }
    }

    class CustomPopupControl : ToolStripControlHost
    {
        private Bunifu.Framework.UI.BunifuTileButton btnJabones;
        private Bunifu.Framework.UI.BunifuTileButton btnDetergentes;
        
        public CustomPopupControl(string title, string message)
            : base(new Panel())
        {
            this.btnDetergentes = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnJabones = new Bunifu.Framework.UI.BunifuTileButton();

            Label titleLabel = new Label();
            titleLabel.BackColor = SystemColors.Control;
            titleLabel.Text = title;
            titleLabel.Dock = DockStyle.Top;

            // 
            // bunifuTileButton1
            // 
            this.btnDetergentes.BackColor = System.Drawing.Color.White;
            this.btnDetergentes.color = System.Drawing.Color.White;
            this.btnDetergentes.colorActive = System.Drawing.Color.RoyalBlue;
            this.btnDetergentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetergentes.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnDetergentes.ForeColor = System.Drawing.Color.Black;
            this.btnDetergentes.Image = global::FormatoEwo.Properties.Resources.detergetnte;
            this.btnDetergentes.ImagePosition = 20;
            this.btnDetergentes.ImageZoom = 50;
            this.btnDetergentes.LabelPosition = 41;
            this.btnDetergentes.LabelText = "Detergentes";
            this.btnDetergentes.Location = new System.Drawing.Point(29, 163);
            this.btnDetergentes.Margin = new System.Windows.Forms.Padding(6);
            this.btnDetergentes.Name = "bunifuTileButton1";
            this.btnDetergentes.Size = new System.Drawing.Size(146, 129);
            this.btnDetergentes.TabIndex = 3;
            // 
            // bunifuTileButton2
            // 
            this.btnJabones.BackColor = System.Drawing.Color.White;
            this.btnJabones.color = System.Drawing.Color.White;
            this.btnJabones.colorActive = System.Drawing.Color.RoyalBlue;
            this.btnJabones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJabones.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnJabones.ForeColor = System.Drawing.Color.Black;
            this.btnJabones.Image = global::FormatoEwo.Properties.Resources.soap;
            this.btnJabones.ImagePosition = 20;
            this.btnJabones.ImageZoom = 50;
            this.btnJabones.LabelPosition = 41;
            this.btnJabones.LabelText = "Jabones";
            this.btnJabones.Location = new System.Drawing.Point(29, 22);
            this.btnJabones.Margin = new System.Windows.Forms.Padding(6);
            this.btnJabones.Name = "bunifuTileButton2";
            this.btnJabones.Size = new System.Drawing.Size(146, 129);
            this.btnJabones.TabIndex = 2;

            this.btnJabones.Click += BtnJabones_Click;
            this.btnDetergentes.Click += BtnDetergentes_Click;

            Control.MinimumSize = new Size(200, 200);

            Control.Controls.Add(titleLabel);
            Control.Controls.Add(this.btnJabones);
            Control.Controls.Add(this.btnDetergentes);
        }

        private void BtnDetergentes_Click(object sender, EventArgs e)
        {   
            MachineLedger ml = new MachineLedger(SubMenu.Planta.Planta_detergentes);
            Global.planta_selected = 2;
            ml.ShowDialog();
        }

        private void BtnJabones_Click(object sender, EventArgs e)
        {         
            MachineLedger ml = new MachineLedger(SubMenu.Planta.Planta_jabones);
            Global.planta_selected = 1;
            ml.ShowDialog();
        }
    }
        
}
