using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conBusGarantia : UserControl
    {
        public event EventHandler ClicBuscar;
        public clsListGarantia listGarantias;
        public conBusGarantia()
        {
            InitializeComponent();
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Por favor ingresar un valor para la búsqueda", "Validación búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCodigo.Focus();
                return;
            }      

            listGarantias = new clsCNGarantia().buscarGarantias(this.txtCodigo.Text.Trim());

            if (ClicBuscar != null)
                ClicBuscar(sender, e);
        }

        public int Count()
        {
            return listGarantias.Count;
        }

        public void limpiarcontroles()
        {
            listGarantias = null;
            this.txtCodigo.Clear();
        }
    }
}
