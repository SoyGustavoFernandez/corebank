using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using LOG.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmEvaReqMinimo : frmBase
    {

        #region Variables Globales

        private const string cTituloMsjes = "Registro de Evaluación de Requisitos Minimos";
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
        private readonly int idUsuario = clsVarGlobal.User.idUsuario;

        public clsListaDetalleProcesoAdj lstDetProAdj = new clsListaDetalleProcesoAdj();
        public clsListaEvaRequisitosMinimos lstEvaReqMin = new clsListaEvaRequisitosMinimos();
        public int pIdProveedor;
        public int pIdProceso;
        clsCNNotaPedido evaReqMinimo = new clsCNNotaPedido();
        public int nGrupo=0;
        public bool lContinuar = true;
        public int idVincuProveedor;
        public int idEstadoEva=0 ;
        public bool lFlagAcep = false;
        public bool lConfirmado=false;
        public int idEstaEva;

        #endregion
        #region Constructor
        public frmEvaReqMinimo()
        {
            InitializeComponent();
        }
        public frmEvaReqMinimo(string cNombreProveedor)
        {
            InitializeComponent();
            lblNombreEmpres.Text = cNombreProveedor;

        }
        #endregion
        #region Eventos

        private void frmEvaReqMinimo_Load(object sender, EventArgs e)
        {
            //cargar requisitos minimos
            clsListaEvaRequisitosMinimos listaEvaReqMin = new clsListaEvaRequisitosMinimos();
            listaEvaReqMin = new clsCNEvalProcAdj().buscarReqMinProcesoEvaluacion(pIdProceso);
            
            foreach (var item in listaEvaReqMin)
            {
                lstEvaReqMin.Add(new clsEvaRequisitosMinimos()
                {
                    idEvaReqMin = item.idEvaReqMin,
                    cSustento = item.cSustento,
                    idProveedor = pIdProveedor,
                    cTipoReqMinimo = item.cTipoReqMinimo,
                    idProcesoAdj = pIdProceso,
                    idTipoReqMinimo = item.idTipoReqMinimo,
                    nItem = item.nItem,
                    idDetalleNotaPedido = item.idDetalleNotaPedido,
                    idEstadoEvaGen = item.idEstadoEvaGen
                });
            }
            dtgDetProAdj.DataSource = lstDetProAdj.Where(x => x.idGrupo == nGrupo).ToList();
            if (idVincuProveedor == 0)
            {
                habilitarBoton(false);
                FormatoGrids();
            }
            else
            {
                DataTable dtEvaReqMin = new clsCNEvalProcAdj().RetornaEvaReMinByProv(pIdProveedor, pIdProceso);
                foreach (var item1 in lstEvaReqMin)
                {
                    foreach (DataRow item2 in dtEvaReqMin.Rows)
                    {
                        if (item1.nItem == Convert.ToInt32(item2["nItem"]) && item1.idTipoReqMinimo == Convert.ToInt32(item2["idTipoReqMinimo"]))
                        {
                            item1.idEvaReqMin = Convert.ToInt32(item2["idEvaReqMin"]);
                            item1.lIndica = Convert.ToBoolean(item2["lIndica"]);
                        }
                    }
                }
                this.dtgEvaREqMin.ReadOnly = true;
                habilitarBoton(true);
            }
            if (lConfirmado)
            {
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
            }
        }       
        private void dtgEvaREqMin_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEvaREqMin.RowCount <= 0)
            {
                return;
            }
            var itemSelc = (clsEvaRequisitosMinimos)dtgEvaREqMin.CurrentRow.DataBoundItem;
            txtSustento.Text = itemSelc.cSustento;
        }

        private void dtgDetProAdj_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetProAdj.RowCount <= 0)
            {
                return;
            }

            cargarDetEvaluacion();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(true);
            this.dtgEvaREqMin.ReadOnly = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            idEstadoEva = 1;
            bool lCalifica = true;
            bool lEstadoCalifica = true;

            foreach (DataGridViewRow item in dtgDetProAdj.Rows)
            {
                string numItem = item.Cells[1].Value.ToString();

                var itemLst = lstEvaReqMin.Where(x => x.idProveedor == pIdProveedor && x.nItem == Convert.ToInt32(numItem)).ToList();
                foreach (var item2 in itemLst)
                {
                    if (item2.lIndica == false)
                    {
                        lEstadoCalifica = false;
                    }
                }
            }
            
            if (!lEstadoCalifica)
            {
                var result = MessageBox.Show("El Proveedor no Cumple con uno de los Requisitos Mínimos" + ". \n Desea DESCALIFICAR la propuesta.", cTituloMsjes, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                lContinuar = !(result == DialogResult.Yes);
                lCalifica = !(result == DialogResult.Yes);
            }

            var objDbResp = new clsCNEvalProcAdj().cnGrabarEvaReqMin(idVincuProveedor, pIdProceso, pIdProveedor, dFechaSis, idUsuario, nGrupo, idEstadoEva, lCalifica, lstEvaReqMin);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                idVincuProveedor = objDbResp.idGenerado;
                idEstaEva = 7;
                lFlagAcep = true;
                Dispose();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(false);
            FormatoGrids();
        }
        #endregion
        #region Metodos
        private void cargarDetEvaluacion()
        {
            var itemSelc = (clsDetalleProcesoAdj)dtgDetProAdj.CurrentRow.DataBoundItem;
            dtgEvaREqMin.DataSource = lstEvaReqMin.Where(x => x.idProveedor == pIdProveedor && x.nItem == itemSelc.nItem).ToList();
        }
        private void FormatoGrids()
        {
            dtgEvaREqMin.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgEvaREqMin.Columns)
            {
                item.ReadOnly = true;
                if (item.HeaderText == "Cumple?")
                {
                    item.ReadOnly = false;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void habilitarBoton(bool lActivo)
        {
            btnEditar1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;
        }
        #endregion

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            lContinuar = false;
        }

    }
}
