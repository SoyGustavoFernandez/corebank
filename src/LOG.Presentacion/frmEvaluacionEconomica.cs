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
namespace LOG.Presentacion
{
    public partial class frmEvaluacionEconomica : frmBase
    {

        #region Variables

        public clsListaDetalleProcesoAdj lstDetallePro = new clsListaDetalleProcesoAdj();
        public clsListaDetalleProcesoAdj lstDetalleProMod = new clsListaDetalleProcesoAdj();
        public string cCodigo;
        public string cProveedor;
        public string cNroDoc;
        public int idProceso;
        public int pnGrupo;
        public int idVinculoPro;
        public int idEstadoEvaPro;
        public bool lFlagAcep = false;
        public bool lConfirmado = false;
        public decimal nIGV = 0.00m;

        #endregion

        #region Constructores

        public frmEvaluacionEconomica()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
        private void frmEvaluacionEconomica_Load(object sender, EventArgs e)
        {

            var lstDet = lstDetallePro.Where(x => x.idGrupo == pnGrupo).ToList();
            lstDetalleProMod = new clsListaDetalleProcesoAdj(lstDet);

            List<clsVarGen> lista = clsVarGlobal.lisVars;
            foreach (clsVarGen item in lista)
            {
                if (item.cVariable.Equals("nIGV"))
                {
                    nIGV = Convert.ToDecimal(item.cValVar);
                }
            }

            dtgDetalleNP.DataSource = lstDetalleProMod;// lstDetallePro.Where(x => x.idGrupo == pnGrupo).ToList();
            FormatoGrids();
            habilitarBoton(true);
            txtCodigo.Text = cCodigo;
            txtNroDoc.Text = cNroDoc;
            txtProveedor.Text = cProveedor;
            DataTable dtEva = new clsCNEvalProcAdj().RetornaEvaEco(idVinculoPro);

            foreach (var item1 in lstDetalleProMod)
            {
                foreach (DataRow item2 in dtEva.Rows)
                {
                    if (item1.idDetalleNotapedido == Convert.ToInt32(item2["idDetalleNotapedido"]) && item1.idGrupo == Convert.ToInt32(item2["nGrupo"]))
                    {
                        item1.nPrecioUnit = Convert.ToDecimal(item2["nPrecioUnitario"]);
                        item1.nsubTotal = item1.nCantidad * Convert.ToDecimal(item2["nPrecioUnitario"]) + item1.nCantidad * Convert.ToDecimal(item2["nPrecioUnitario"])*nIGV*item1.lIgv;
                    }
                }
            }
            txtSubTotal.Text = lstDetalleProMod.Where(y => y.idGrupo == pnGrupo).Sum(x => x.nsubTotal).ToString();
            if (lConfirmado)
            {
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBoton(false);
            FormatoGrids();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBoton(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            idEstadoEvaPro = 4;
            decimal nMonto = Convert.ToDecimal(txtSubTotal.Text);
            clsListaDetalleProcesoAdj listFinal = new clsListaDetalleProcesoAdj();
            foreach (var item in lstDetalleProMod)
            {
                if (item.idGrupo == pnGrupo)
                {
                    listFinal.Add(item);
                }
            }
            DataTable dtResp = new clsCNEvalProcAdj().cnGrabarEvaEconomica(idVinculoPro, idProceso, Convert.ToInt32(cCodigo), idEstadoEvaPro, pnGrupo, nMonto, listFinal);
            if (dtResp.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show(dtResp.Rows[0][1].ToString(), "Registro de Evaluación Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lFlagAcep = true;
                Dispose();
            }
        }

        private void dtgDetalleNP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDetalleNP.RowCount <= 0)
            {
                return;
            }
            var detalleNp = ((clsDetalleProcesoAdj)dtgDetalleNP.CurrentRow.DataBoundItem);
            detalleNp.nsubTotal = detalleNp.nPrecioUnit * detalleNp.nCantidad + detalleNp.nPrecioUnit * detalleNp.nCantidad*nIGV * detalleNp.lIgv; //Si esta afecto a IGV se suma
            txtSubTotal.Text = lstDetalleProMod.Where(y => y.idGrupo == pnGrupo).Sum(x => x.nsubTotal).ToString();
        }

        private void dtgDetalleNP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex != 6)
                return;
            if (e.Exception.Message.ToString() == @"Input string was not in a correct format.")
            {
                e.ThrowException = false;
            }
        }

        private void dtgDetalleNP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgDetalleNP.Refresh();
        }

        private void dtgDetalleNP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void frmEvaluacionEconomica_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgDetalleNP.DataSource = null;
        }

        #endregion

        #region Metodos

        private void FormatoGrids()
        {
            dtgDetalleNP.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgDetalleNP.Columns)
            {
                item.ReadOnly = true;
                if (item.DataPropertyName == "nPrecioUnit")
                {
                    item.ReadOnly = false;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void habilitarBoton(bool lActivo)
        {
            btnEditar.Enabled = lActivo;
            btnGrabar.Enabled = !lActivo;
            btnCancelar.Enabled = !lActivo;
            dtgDetalleNP.ReadOnly = lActivo;
        }

        private bool validar()
        {
            bool lBool = true;
            string cMsg = "Los siguientes items estan con precio unitario 0: \n";
            foreach (clsDetalleProcesoAdj item in lstDetalleProMod)
            {
                if (item.nPrecioUnit == 0)
                {
                    lBool = false;
                    cMsg += "- " + item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show(cMsg + "Debe registrar un valor diferente de 0.", "Registro de Evaluación Económica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return lBool;
            }

            return lBool;
        }

        #endregion

    }
}
