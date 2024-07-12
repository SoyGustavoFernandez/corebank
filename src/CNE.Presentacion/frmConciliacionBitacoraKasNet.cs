using CNE.CapaNegocio;
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

namespace CNE.Presentacion
{
    public partial class frmConciliacionBitacoraKasNet : frmBase
    {
        public frmConciliacionBitacoraKasNet()
        {            
        }

        public frmConciliacionBitacoraKasNet(DateTime dFechaConci)
        {
            InitializeComponent();
            this.dtpFechaConci.Value = dFechaConci.Date;
            this.CargarComboEstadoConci();
            this.CargarDtgBitacoraConciKasNet();
        }

        private void CargarComboEstadoConci()
        {
            DataTable dtEstadoConci = new DataTable();
            dtEstadoConci.Columns.Add("idEstado", typeof(int));
            dtEstadoConci.Columns.Add("cEstado", typeof(string));

            DataRow row = dtEstadoConci.NewRow();
            row["idEstado"] = -1;
            row["cEstado"] = string.Empty;
            dtEstadoConci.Rows.InsertAt(row, 0);

            row = dtEstadoConci.NewRow();
            row["idEstado"] = 1;
            row["cEstado"] = "Correcto";
            dtEstadoConci.Rows.InsertAt(row, 1);

            row = dtEstadoConci.NewRow();
            row["idEstado"] = 2;
            row["cEstado"] = "Pendiente";
            dtEstadoConci.Rows.InsertAt(row, 2);

            row = dtEstadoConci.NewRow();
            row["idEstado"] = 3;
            row["cEstado"] = "Observado";
            dtEstadoConci.Rows.InsertAt(row, 3);

            this.cboEstadoConci.DataSource = dtEstadoConci;
            this.cboEstadoConci.ValueMember = "idEstado";
            this.cboEstadoConci.DisplayMember = "cEstado";
        }

        private void CargarDtgBitacoraConciKasNet()
        {
            DataTable dtBitacoraConciKasNet = new DataTable();
            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();
            DateTime dFechaConci = this.dtpFechaConci.Value;
            string cEstado = Convert.ToString(this.cboEstadoConci.SelectedText);

            dtBitacoraConciKasNet = objCNConciliacionKasNet.CNListarBitacoraConciKasNet(dFechaConci);

            this.dtgBitacoraConciKasNet.DataSource = dtBitacoraConciKasNet;
            this.dtgBitacoraConciKasNet.Refresh();
            this.dtgBitacoraConciKasNet.ClearSelection();
        }
        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.cboEstadoConci.GetItemText(this.cboEstadoConci.SelectedItem) == string.Empty)
            {
                MessageBox.Show("Seleccione un estado válido.", "Bitacora de Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtDescripcion.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese una decripción válida.", "Bitacora de Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();

            DateTime dFechaConci = this.dtpFechaConci.Value;
            string cEstado = this.cboEstadoConci.GetItemText(this.cboEstadoConci.SelectedItem);
            string cDescripcion = this.txtDescripcion.Text;
            string cWinUser = clsVarGlobal.User.cWinUser;

            objCNConciliacionKasNet.CNGrabarBitacoraConciKasNet(dFechaConci.Date, cEstado, cDescripcion, cWinUser);

            this.CargarDtgBitacoraConciKasNet();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cboEstadoConci.SelectedValue = -1;
            this.txtDescripcion.Text = string.Empty;
        }

        private void dtpFechaConci_ValueChanged(object sender, EventArgs e)
        {
            this.cboEstadoConci.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;

            this.CargarDtgBitacoraConciKasNet();
        }
    }    
}
