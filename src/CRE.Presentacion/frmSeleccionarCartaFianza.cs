using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmSeleccionarCartaFianza : frmBase
    {
        public int idSeleccionado { get; set; }
        public bool lAceptar = false;
        public frmSeleccionarCartaFianza()
        {
            InitializeComponent();
        }

        public frmSeleccionarCartaFianza(DataTable dtCartasFianza)
        {
            InitializeComponent();
            dtgCartasFianzas.DataSource = dtCartasFianza;
        }

        private void dtgCartasFianzas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idSeleccionado = e.RowIndex;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            lAceptar = true;
            this.Dispose();

        }
    }
}
