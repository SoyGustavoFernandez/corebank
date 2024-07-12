using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmSolAprobReimpresion : frmBase
    {
        public int pidCta = 0,pidSolicitud=0,pidCli=0, pidTipoDocumento = 0, pIdTipoPersona = 0;
        public string pcNroCuenta = "",pcNomCli="",pcNroDoc="",pcMtivoReimpres="", pcCodClienteLargo=String.Empty;

        public frmSolAprobReimpresion()
        {
            InitializeComponent();
        }

        private void frmSolAprobTitular_Load(object sender, EventArgs e)
        {
            ListarSolApr();
        }

        private void ListarSolApr()
        {
            clsCNListaFormatoImp solicitud = new clsCNListaFormatoImp();
            DataTable dtSolApr = solicitud.CNSolicitudReimpresionApr();
            dtgSolAprobados.DataSource = dtSolApr;
            //---Formato Grid
            FormatoGrid();

            if (dtSolApr.Rows.Count>0)
            {
                btnAceptar.Enabled = true;
            }
        }

        private void FormatoGrid()
        {
            this.dtgSolAprobados.Columns["cNroCuenta"].Visible = false;
            this.dtgSolAprobados.Columns["idCli"].Visible = false;
            this.dtgSolAprobados.Columns["cDocumentoID"].Visible = false;
            this.dtgSolAprobados.Columns["cMotivoCambio"].Visible = false;

            this.dtgSolAprobados.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgSolAprobados.Columns["idCuenta"].Width = 80;
            this.dtgSolAprobados.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgSolAprobados.Columns["cNombre"].Width = 170;
            this.dtgSolAprobados.Columns["idSolicitud"].HeaderText = "Nro Solicitud";
            this.dtgSolAprobados.Columns["idSolicitud"].Width = 60;
            this.dtgSolAprobados.Columns["cMotivoExt"].HeaderText = "Motivo de Reimpresión";
            this.dtgSolAprobados.Columns["cMotivoExt"].Width = 200;
            this.dtgSolAprobados.Columns["cCodCliente"].Visible = false;
            this.dtgSolAprobados.Columns["idTipoDocumento"].Visible = false;
            this.dtgSolAprobados.Columns["IdTipoPersona"].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pidCta = 0;
            pidSolicitud = 0;
            pcNroCuenta = "";
            pidCli = 0;
            pcNomCli = "";
            pcNroDoc = "";
            pcMtivoReimpres = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgSolAprobados.RowCount > 0)
            {
                pidCta = Convert.ToInt32(dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString());
                pidSolicitud = Convert.ToInt32(dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["idSolicitud"].Value.ToString());
                pcNroCuenta = dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["cNroCuenta"].Value.ToString();

                pidCli = Convert.ToInt32(dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString());
                pcNomCli = dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                pcNroDoc = dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();
                pcMtivoReimpres = dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["cMotivoCambio"].Value.ToString();
            }
            else
            {
                pidCta = 0;
                pidSolicitud = 0;
                pcNroCuenta = "";
                pidCli = 0;
                pcNomCli = "";
                pcNroDoc = "";
                pcMtivoReimpres = "";
            }

            this.Dispose();
        }

        private void dtgSolAprobados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgSolAprobados_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }
    }
}
