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
using LOG.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace LOG.Presentacion
{
    public partial class frmRequisitosMin : frmBase
    {

        #region Variables

        public string cTipoOpe = "N";
        public string cProcesoOper;
        public int xIdNotaPedido;
        public bool lEditable = true;
        public bool lIndicaConsolidado = false;
        private clsCNNotaPedido clsNotaPedido = new clsCNNotaPedido();

        public List<clsDetalleNotaPedido> pLstDetNot = new List<clsDetalleNotaPedido>();

        public List<clsEvaRequisitosMinimos> pLstReqMin;
        private List<clsDetalleNotaPedido> tmpLstDetNot;

        private List<clsTipReqMin> lstTipReqMin;

        #endregion 

        #region Eventos

        private void frmRequisitosMin_Load(object sender, EventArgs e)
        {
            dtgDetalleNP.SelectionChanged -= new EventHandler(dtgDetalleNP_SelectionChanged);

            tmpLstDetNot = pLstDetNot;

            lstTipReqMin = new clsCNTipReqMin().CNListaTipoReqMin();

            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = pLstDetNot.Where(x => x.lVigente == true).ToList();
            FormatoGridViewDetNP();


            dtgTipoRequisito.DataSource = typeof(List<clsTipReqMin>);
            dtgTipoRequisito.DataSource = lstTipReqMin;
            FormatoGridTipReq();
            dtgDetalleNP.SelectionChanged += new EventHandler(dtgDetalleNP_SelectionChanged);
            dtgDetalleNP.CurrentCell = dtgDetalleNP.Rows[0].Cells["nItem"];
            dtgDetalleNP_SelectionChanged(sender, e);
            
            if (!lEditable)
            {
                OnlyReadControls();
                btnAceptar.Visible = false;
            }
            if (lIndicaConsolidado)
            {
                btnAceptar.Enabled = false;
                OnlyReadControls();
            }
            //DataTable dtNop = (DataTable)dtgDetalleNP.DataSource;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pLstDetNot = tmpLstDetNot;
            this.Dispose();
        }

        private void txtDetalleReq_Leave(object sender, EventArgs e)
        {
            if (dtgDetalleNP.CurrentRow == null) return;
            if (dtgTipoRequisito.CurrentRow == null) return;

            var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
            var objTipReqMin = (clsTipReqMin)dtgTipoRequisito.CurrentRow.DataBoundItem;
            var lstReqMin = objDetNP.lstReqMin;

            var lstDetReqMin = lstReqMin.Where(x => x.idTipoReqMinimo == objTipReqMin.idTipoReqMinimo).ToList();

            if (lstDetReqMin.Count() == 0)
            {
                var objReqMin = new clsEvaRequisitosMinimos();
                objReqMin.idReqMinimo = 0;
                objReqMin.idTipoReqMinimo = objTipReqMin.idTipoReqMinimo;
                objReqMin.lIndica = true;
                objReqMin.nItem = objDetNP.nItem;
                objReqMin.idDetalleNotaPedido = objDetNP.idDetalleNotaPedido;
                objReqMin.cSustento = txtDetalleReq.Text.Trim();
                objReqMin.lVigente = true;
                lstReqMin.Add(objReqMin);
            }
            else
            {
                var objReqMin = lstDetReqMin.First();
                objReqMin.cSustento = txtDetalleReq.Text.Trim();
                objReqMin.lVigente = true;
            }
        }

        private void dtgDetalleNP_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNP.CurrentRow == null) return;
            var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
            if (dtgTipoRequisito.Rows.Count <= 0) return;

            dtgTipoRequisito.CurrentCell = dtgTipoRequisito.Rows[0].Cells["idTipoReqMinimo"];          
            
            foreach (var item in lstTipReqMin)
            {
                var lstReqMinFilter = objDetNP.lstReqMin.Where(x => x.idTipoReqMinimo == item.idTipoReqMinimo).ToList();
                if (lstReqMinFilter.Where(x => x.lVigente).Count() > 0)
                {
                    item.lIndAplica = true;
                    txtDetalleReq.Enabled = true;
                    txtDetalleReq.Text = lstReqMinFilter.Where(x => x.lVigente).First().cSustento;
                }
                else
                {
                    item.lIndAplica = false;
                    txtDetalleReq.Enabled = false;
                    txtDetalleReq.Text = string.Empty;
                }
            }

            dtgTipoRequisito.DataSource = typeof(clsTipReqMin);
            dtgTipoRequisito.DataSource = lstTipReqMin;
            FormatoGridTipReq();
        }

        private void dtgTipoRequisito_SelectionChanged(object sender, EventArgs e)
        {        
            if (dtgDetalleNP.CurrentRow == null) return;
            if (dtgTipoRequisito.CurrentRow == null) return;

            txtDetalleReq.Text = string.Empty;
            txtDetalleReq.Enabled = false;

            var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
            var objTipReqMin = (clsTipReqMin)dtgTipoRequisito.CurrentRow.DataBoundItem;
            
            var lstReqMinFilter = objDetNP.lstReqMin.Where(x => x.idTipoReqMinimo == objTipReqMin.idTipoReqMinimo && 
                                                                x.lVigente == true).ToList();
            if (lstReqMinFilter.Count() > 0)
            {
                txtDetalleReq.Enabled = true;
                txtDetalleReq.Text = lstReqMinFilter.First().cSustento;
            }
        }

        private void dtgTipoRequisito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDetalleNP.CurrentRow == null) return;
            if (dtgTipoRequisito.CurrentRow == null) return;

            var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
            var objTipReqMin = (clsTipReqMin)dtgTipoRequisito.CurrentRow.DataBoundItem;

            DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgTipoRequisito.CurrentRow.Cells["lIndAplica"];
            txtDetalleReq.Enabled = Convert.ToBoolean(checkbox.EditedFormattedValue);
            if (!Convert.ToBoolean(checkbox.EditedFormattedValue))
            {
                txtDetalleReq.Text = string.Empty;
                var lstReqMinFilter = objDetNP.lstReqMin.Where(x => x.idTipoReqMinimo == objTipReqMin.idTipoReqMinimo &&
                                                                    x.lVigente == true).ToList();
                if (lstReqMinFilter.Where(x => x.idReqMinimo == 0).Count() > 0)
                {
                    objDetNP.lstReqMin.Remove(lstReqMinFilter.First());
                }
                else if (lstReqMinFilter.Where(x => x.idReqMinimo > 0).Count() > 0)
                {
                    objDetNP.lstReqMin.Where(x => x.idReqMinimo > 0).First().lVigente = false;
                }
            }
        }

        private void dtgTipoRequisito_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgTipoRequisito.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        #endregion

        #region Metodos

        public frmRequisitosMin()
        {
            InitializeComponent();
        }

        private void OnlyReadControls()
        {
            dtgDetalleNP.ReadOnly = true;
            dtgTipoRequisito.ReadOnly = true;
            txtDetalleReq.ReadOnly = true;
        }

        private void FormatoGridTipReq()
        {
            dtgTipoRequisito.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgTipoRequisito.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgTipoRequisito.Columns["idTipoReqMinimo"].Visible = true;
            dtgTipoRequisito.Columns["cTipoReqMinimo"].Visible = true;
            dtgTipoRequisito.Columns["lIndAplica"].Visible = true;

            dtgTipoRequisito.Columns["idTipoReqMinimo"].HeaderText = "Nro.";
            dtgTipoRequisito.Columns["cTipoReqMinimo"].HeaderText = "Descripción";
            dtgTipoRequisito.Columns["lIndAplica"].HeaderText = "X";

            dtgTipoRequisito.Columns["idTipoReqMinimo"].DisplayIndex = 0;
            dtgTipoRequisito.Columns["cTipoReqMinimo"].DisplayIndex = 1;
            dtgTipoRequisito.Columns["lIndAplica"].DisplayIndex = 2;

            dtgTipoRequisito.Columns["idTipoReqMinimo"].FillWeight = 20;
            dtgTipoRequisito.Columns["cTipoReqMinimo"].FillWeight = 60;
            dtgTipoRequisito.Columns["lIndAplica"].FillWeight = 20;

            dtgTipoRequisito.Columns["lIndAplica"].ReadOnly = false;
        }

        private void FormatoGridViewDetNP()
        {
            dtgDetalleNP.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNP.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgDetalleNP.Columns["nItem"].Visible = true;
            dtgDetalleNP.Columns["idCatalogo"].Visible = true;
            dtgDetalleNP.Columns["cProducto"].Visible = true;
            dtgDetalleNP.Columns["cUnidad"].Visible = true;
            dtgDetalleNP.Columns["nCantidad"].Visible = true;
            dtgDetalleNP.Columns["nPrecioUnit"].Visible = true;

            dtgDetalleNP.Columns["nItem"].HeaderText = "Item";
            dtgDetalleNP.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNP.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleNP.Columns["cUnidad"].HeaderText = "UM";
            dtgDetalleNP.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNP.Columns["nPrecioUnit"].HeaderText = "Pre.Uni";

            dtgDetalleNP.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleNP.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleNP.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleNP.Columns["cUnidad"].DisplayIndex = 3 ;
            dtgDetalleNP.Columns["nCantidad"].DisplayIndex = 4;
            dtgDetalleNP.Columns["nPrecioUnit"].DisplayIndex = 5;

            dtgDetalleNP.Columns["nItem"].FillWeight = 5;
            dtgDetalleNP.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleNP.Columns["cProducto"].FillWeight = 35;
            dtgDetalleNP.Columns["cUnidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nPrecioUnit"].FillWeight = 10;
        }

        #endregion

    }
}
