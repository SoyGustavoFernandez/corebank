using GEN.ControlesBase;
using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarComisiones : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();

        public frmPDPGestionarComisiones()
        {
            InitializeComponent();
        }

        private void frmPDPGestionarComisiones_Load(object sender, EventArgs e)
        {
            this.cboPDPEmisor.cargarVigentes();
            this.cboPDPEstado.ModalidadPDPEstado(1);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void dtgConsultarComisiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgConsultarComisiones.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0)
            {

            }
        }   

        private void dtgConsultarComisiones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgConsultarComisiones.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgConsultarComisiones.Rows[e.RowIndex].Cells["cAccion11"] as DataGridViewButtonCell;
                Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgConsultarComisiones.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                this.dtgConsultarComisiones.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                e.Handled = true;
            }
        }
    }
}
