using FormatoEwo.DaoEF;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class NuevoElemento : MetroForm
    {
        public bool seleccionada { get; set; }
        public string herramienta { get; set; }
        public string tipo { get; set; }

        DaoHerr daoHerr = new DaoHerr();

        public NuevoElemento()
        {
            InitializeComponent();
            cboTipo.SelectedIndex = 0;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!txtHerramienta.Text.Trim().Equals(""))
            {
                tipo = cboTipo.Text;
                herramienta = txtHerramienta.Text;
                seleccionada = chkSeleccionada.Checked;

                daoHerr.AddTool(new Objetos.Herramientas()
                {
                    herramienta = herramienta,
                    sel = seleccionada,
                    tipo = tipo
                });

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campo no debe estar en blanco!");

                //DialogResult result = 
                //MessageBox.Show("Salir sin agregar herrramienta?", "Salir",
                //   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                //if (result == DialogResult.Yes)
                //{
                //    DialogResult = DialogResult.Cancel;
                //}    
            }
            
        }
    }
}
