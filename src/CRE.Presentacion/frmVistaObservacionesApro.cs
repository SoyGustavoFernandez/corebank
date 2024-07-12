using CRE.CapaNegocio;
using EntityLayer;
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
    public partial class frmVistaObservacionesApro : frmBase
    {
        private List<clsObservacionAprobador> lstObsAprobador;
        private clsCNObservacionAprobador objObsApro=new clsCNObservacionAprobador();
        private int idSolicitud=0;

        public frmVistaObservacionesApro()
        {
            InitializeComponent();

            this.dtgObsAprobador.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgObsAprobador.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;			
        }

        public frmVistaObservacionesApro(int idSolicitud)
        {
            InitializeComponent();

            this.dtgObsAprobador.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgObsAprobador.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;			

            this.idSolicitud = idSolicitud;
            this.ObtenerObsAproSolicitud();

            if (this.lstObsAprobador.Count == 0)
            {
                MessageBox.Show("La solicitud no tiene observaciones pendientes","Observaciones",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            this.AsignarDatosTabla();
            this.FormatearDataGrid();
        }

        private void ObtenerObsAproSolicitud()
        {
            this.lstObsAprobador = objObsApro.ListarObsAprobadorSolicitud(this.idSolicitud);
        }

        private void AsignarDatosTabla()
        {
            this.bindingObsAprobador.DataSource = lstObsAprobador;
            this.dtgObsAprobador.DataSource = this.bindingObsAprobador;
        }

        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgObsAprobador.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgObsAprobador.Columns["cTipObservacion"].DisplayIndex = 0;
            dtgObsAprobador.Columns["cObservacion"].DisplayIndex = 1;
            dtgObsAprobador.Columns["dFechaHrReg"].DisplayIndex = 2;

            dtgObsAprobador.Columns["cTipObservacion"].Visible = true;
            dtgObsAprobador.Columns["cObservacion"].Visible = true;
            dtgObsAprobador.Columns["dFechaHrReg"].Visible = true;

            dtgObsAprobador.Columns["cTipObservacion"].HeaderText = "Tipo ";
            dtgObsAprobador.Columns["cObservacion"].HeaderText = "Observación";
            dtgObsAprobador.Columns["dFechaHrReg"].HeaderText = "Fecha Obs.";

            dtgObsAprobador.Columns["cTipObservacion"].FillWeight = 85;
            dtgObsAprobador.Columns["cObservacion"].FillWeight = 150;
            dtgObsAprobador.Columns["dFechaHrReg"].FillWeight = 40;

            dtgObsAprobador.Columns["dFechaHrReg"].DefaultCellStyle.Format = "dd/mm/yyyy";
        }


    }
}
