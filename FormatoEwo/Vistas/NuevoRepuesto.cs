using FormatoEwo.DaoEF;
using FormatoEwo.Objetos;
using FormatoEwo.Util;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace FormatoEwo.Vistas
{
    public partial class NuevoRepuesto : MetroForm
    {        
        public string repuesto { get; set; }
        public int cantidad { get; set; }
        DaoRepuestosUtilizados daoRU = new DaoRepuestosUtilizados();

        public NuevoRepuesto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!txtCantidad.Text.Trim().Equals("") && !txtRepuesto.Text.Trim().Equals(""))
            {
                repuesto = txtRepuesto.Text;
                cantidad = int.Parse(txtCantidad.Text);

                daoRU.AddRepuestoUtilizado(new Database.repuestos_utilizados()
                {
                    descripcion = repuesto,
                    cantidad = cantidad
                });

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Campo no debe estar en blanco!");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxHelper.OnlyNumbers(sender, e);
        }
    }
}
