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
using DEP.CapaNegocio;
using EntityLayer;
namespace DEP.Presentacion
{
    public partial class frmBuscaSolCompraVenta : frmBase
    {
        public DataTable tbComVen;
        public int pnComVen=-1;
        public int pidOperacion;
        public int pidEstadoSol;
        public int pidSolAproba;
        public string pcIdCli;
        public Decimal pnTipcam;
        public bool pbTipCamEsp;

        public Decimal pnMonOpe;
        public Decimal pnMonEqui;
        public Decimal pnMonRed;
        public Decimal pnMonNeto;

        public int pidNacionalidad;
        public int pidTipDocumento;
        public string pcNroDoc;
        public string pcNomCli;
        public string pcDirCli;
       

        public frmBuscaSolCompraVenta()
        {
            InitializeComponent();
        }

        private void frmBuscaSolCompraVenta_Load(object sender, EventArgs e)
        {
            buscarSolicitud();
        }

        private void bloquearActivarAceptar()
        {
            if (this.dtgSolComVen.SelectedRows.Count > 0)
            {
                DataRow drFila = ((DataRowView)this.dtgSolComVen.SelectedRows[0].DataBoundItem).Row;
                int idEstadoOpe = Convert.ToInt32(drFila["idEstadoOpe"]);
                int idEstadoSol = Convert.ToInt32(drFila["idEstadoSol"]);

                if (idEstadoOpe == 3 && idEstadoSol == 2)
                {
                    this.btnAceptar.Enabled = true;
                }
                else
                {
                    this.btnAceptar.Enabled = false;
                }
            }
            else
            {
                this.btnAceptar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgSolComVen.RowCount > 0)
            {
                pidOperacion = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idOperacion"].Value);
                pnComVen = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idTipComVen"].Value);

                pnTipcam = Convert.ToDecimal (dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["nTipoCambio"].Value);

                pnMonOpe = Convert.ToDecimal (dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["nMontoOpe"].Value);
                pnMonEqui = Convert.ToDecimal(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["nMontoEqui"].Value);
                pnMonRed = Convert.ToDecimal (dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["nMonRedondeo"].Value);
                pnMonNeto = Convert.ToDecimal(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["nMontoNeto"].Value);

                pcIdCli = dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                pcNroDoc = dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();
                pcNomCli = dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                pcDirCli = dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["cDireccion"].Value.ToString();
                pbTipCamEsp = Convert.ToBoolean(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["bTipCamEsp"].Value);
                pidEstadoSol = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idEstadoSol"].Value);
                pidSolAproba = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idSolAproba"].Value);
                pidTipDocumento = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idTipDocumento"].Value);
                pidNacionalidad = Convert.ToInt32(dtgSolComVen.Rows[dtgSolComVen.SelectedCells[0].RowIndex].Cells["idNacionalidad"].Value);

            }
            this.Dispose();
        }

       
        void buscarSolicitud()
        {
            clsCNCompraVenta dtComVen = new clsCNCompraVenta();

            tbComVen = dtComVen.ListarSolCV(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            dtgSolComVen.DataSource = tbComVen;
            this.bloquearActivarAceptar();
        }

        private void dtgSolComVen_SelectionChanged(object sender, EventArgs e)
        {
            this.bloquearActivarAceptar();
        }
    }
}
