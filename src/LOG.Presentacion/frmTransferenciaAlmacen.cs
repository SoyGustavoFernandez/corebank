using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.PrintHelper;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmTransferenciaAlmacen : frmBase
    {
        #region Variables Globales
        clsCNAlmacen cnalmacen = new clsCNAlmacen();
        private List<clsTransferenciaAlmacen> lstTransferencia = new List<clsTransferenciaAlmacen>();
        private clsTransferenciaAlmacen objTransf;

        public List<clsDetTransferenciasActivo> listaActivosATransferir = new List<clsDetTransferenciasActivo>();
        public List<clsDetTransferenciasActivo> listaActivosATransferirTotal = new List<clsDetTransferenciasActivo>();

        BindingSource bs = new BindingSource();

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;            
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAlmacen.SelectedIndex = -1;
            ListarTransferencias();
            bs.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bs_ListChanged);
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt32(cboAgencias.SelectedValue));
            }
        }

        private void bs_ListChanged(object sender, EventArgs e)
        {
            bs.ListChanged -= bs_ListChanged;
            selDetaTransferenciaActivosEvento();
            bs.ListChanged += bs_ListChanged;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!ValidaBusqueda()) return;
            ListarTransferencias();
        }

        private bool ValidaBusqueda()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha De no debe ser mayor que la fecha Hasta", "Busqueda transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecIni.Focus();
                return false;
            }

            return true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una Transferencia por favor", "Aceptar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var objTransferencia = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;
            objTransferencia.idEstado = Convert.ToInt16(EstLog.APROBADO);
            objTransferencia.listaActivosATransferir = listaActivosATransferirTotal;
            clsDBResp objDbResp = cnalmacen.ActualizaTransferenciaAlmacen(objTransferencia);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Aceptar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarTransferencias();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Aceptar Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una Transferencia por favor", "Anular Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var objTransferencia = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;
            objTransferencia.idEstado = Convert.ToInt16(EstLog.DENEGADO);
            clsDBResp objDbResp = cnalmacen.ActualizaTransferenciaAlmacen(objTransferencia);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Anular Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarTransferencias();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Anular Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Metodos

        public frmTransferenciaAlmacen()
        {
            InitializeComponent();
        }

        private void ListarTransferencias()
        {
            LimpiarGridViews();
            int idAlmacenOri = 0;
            if (cboAlmacen.SelectedIndex >= 0)
            {
                idAlmacenOri = Convert.ToInt32(cboAlmacen.SelectedValue);                
                lstTransferencia = cnalmacen.CNListaSolicitudTransferencia(dtpFecIni.Value, dtpFecFin.Value, idAlmacenOri, -1, Convert.ToInt16(EstLog.SOLICITADO));
                ProcesaNumeroItems();
            }
            dtgTransferencias.DataSource = lstTransferencia;
            FormatoTransferencia();
            if (dtgTransferencias.Rows.Count > 0)
            {
                ListarDetalleTransferencia();
            }
            else
            {
                btnAceptar.Enabled = false;
                btnAnular.Enabled = false;
            }
        }

        private void ProcesaNumeroItems()
        {
            int nNum = 1;
            foreach (var item in lstTransferencia)
            {
                if (item.lVigente)
                {
                    item.nItem = nNum++;
                }
            }
        }

        private void ListarDetalleTransferencia()
        {
            if (dtgTransferencias.SelectedRows.Count > 0)
            {
                objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;                

                if (objTransf.idTrasferencias == 0)
                {
                    dtgDetalleTransferencia.DataSource = objTransf.lstDetTransf.Where(x => x.lVigente == true).ToList();
                    FormatoDetalle();
                    return;
                }

                var lstDetTrans = cnalmacen.ListaDetalleTransferencia(objTransf.idTrasferencias);
                dtgDetalleTransferencia.DataSource = lstDetTrans.Where(x => x.lVigente == true).ToList();
                FormatoDetalle();
                dtgDetalleTransferencia.ReadOnly = true;
                listarDetalleTransActivos(objTransf.idTrasferencias);
                cboMoneda1.SelectedValue = objTransf.idMoneda;
                if (objTransf.idEstado == Convert.ToInt16(EstLog.SOLICITADO))
                {
                    btnAceptar.Enabled = true;
                    btnAnular.Enabled = true;
                }
                else
                {
                    btnAceptar.Enabled = false;
                    btnAnular.Enabled = false;
                }
            }
        }

        private void listarDetalleTransActivos(int idTransferencias)
        {
            listaActivosATransferirTotal.Clear();
            listaActivosATransferir.Clear();
            bs.ResetBindings(true);
            listaActivosATransferirTotal = new clsCNAlmacen().CNListaDetalleTransActivos(idTransferencias);
        }

        private void FormatoTransferencia()
        {
            foreach (DataGridViewColumn item in dtgTransferencias.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTransferencias.Columns["nItem"].Visible = true;
            dtgTransferencias.Columns["dFechaRegistro"].Visible = true;
            dtgTransferencias.Columns["cWinUser"].Visible = true;
            dtgTransferencias.Columns["cAlmacenOri"].Visible = true;
            dtgTransferencias.Columns["cAlmacenDes"].Visible = true;
            dtgTransferencias.Columns["cEstado"].Visible = true;

            dtgTransferencias.Columns["nItem"].HeaderText = "N°";
            dtgTransferencias.Columns["dFechaRegistro"].HeaderText = "Fecha";
            dtgTransferencias.Columns["cWinUser"].HeaderText = "Usuario";
            dtgTransferencias.Columns["cAlmacenOri"].HeaderText = "Almacén Origen";
            dtgTransferencias.Columns["cAlmacenDes"].HeaderText = "Almacén Destino";
            dtgTransferencias.Columns["cEstado"].HeaderText = "Estado";

            dtgTransferencias.Columns["nItem"].FillWeight = 5;
            dtgTransferencias.Columns["dFechaRegistro"].FillWeight = 15;
            dtgTransferencias.Columns["cWinUser"].FillWeight = 15;
            dtgTransferencias.Columns["cAlmacenOri"].FillWeight = 25;
            dtgTransferencias.Columns["cAlmacenDes"].FillWeight = 25;
            dtgTransferencias.Columns["cEstado"].FillWeight = 15;

            dtgTransferencias.Columns["nItem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTransferencias.Columns["dFechaRegistro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTransferencias.Columns["cWinUser"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTransferencias.Columns["cAlmacenOri"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTransferencias.Columns["cAlmacenDes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgTransferencias.Columns["cEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormatoDetalle()
        {          
            foreach (DataGridViewColumn column in dtgDetalleTransferencia.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleTransferencia.Columns["nItem"].Visible = true;
            dtgDetalleTransferencia.Columns["nCantidad"].Visible = true;
            dtgDetalleTransferencia.Columns["idCatalogo"].Visible = true;
            dtgDetalleTransferencia.Columns["cProducto"].Visible = true;
            dtgDetalleTransferencia.Columns["cUnidad"].Visible = true;
            dtgDetalleTransferencia.Columns["nCantStock"].Visible = true;

            dtgDetalleTransferencia.Columns["nItem"].HeaderText = "N°";
            dtgDetalleTransferencia.Columns["idCatalogo"].HeaderText = "Cod. Prod";
            dtgDetalleTransferencia.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleTransferencia.Columns["cUnidad"].HeaderText = "Uni. Med.";
            dtgDetalleTransferencia.Columns["nCantStock"].HeaderText = "Stock";
            dtgDetalleTransferencia.Columns["nCantidad"].HeaderText = "Cantidad";

            dtgDetalleTransferencia.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleTransferencia.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleTransferencia.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleTransferencia.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetalleTransferencia.Columns["nCantStock"].DisplayIndex = 4;
            dtgDetalleTransferencia.Columns["nCantidad"].DisplayIndex = 5;

            dtgDetalleTransferencia.Columns["nItem"].FillWeight = 5;
            dtgDetalleTransferencia.Columns["idCatalogo"].FillWeight = 12;
            dtgDetalleTransferencia.Columns["cProducto"].FillWeight = 50;
            dtgDetalleTransferencia.Columns["cUnidad"].FillWeight = 15;
            dtgDetalleTransferencia.Columns["nCantStock"].FillWeight = 15;
            dtgDetalleTransferencia.Columns["nCantidad"].FillWeight = 15;

            dtgDetalleTransferencia.Columns["nCantStock"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleTransferencia.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
        }

        private void LimpiarGridViews()
        {
            dtgTransferencias.DataSource = typeof(List<clsTransferenciaAlmacen>);
            dtgDetalleTransferencia.DataSource = typeof(List<clsDetTranfAlmacen>);
        }

        #endregion

        private void dtgTransferencias_SelectionChanged(object sender, EventArgs e)
        {
            ListarDetalleTransferencia();
            selDetaTransferenciaActivosEvento();
        }

        private void dtgDetalleTransferencia_SelectionChanged(object sender, EventArgs e)
        {
            selDetaTransferenciaActivosEvento();
        }

        private void selDetaTransferenciaActivosEvento()
        {
            if (dtgDetalleTransferencia.DataSource == null)
                return;

            if (dtgDetalleTransferencia.RowCount == 0)
                return;

            if (dtgDetalleTransferencia.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay detalle de transferencia seleccionado", "Transferencia Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDetTranfAlmacen obj = (clsDetTranfAlmacen)dtgDetalleTransferencia.SelectedRows[0].DataBoundItem;
            selDetTransActivosPorIdCatalogo(obj.idCatalogo);
        }

        private void selDetTransActivosPorIdCatalogo(int idCatalogo)
        {
            listaActivosATransferir = listaActivosATransferirTotal.Where(x => x.idCatalogo == idCatalogo).ToList();
            bs.DataSource = listaActivosATransferir;
            dtgActivos.DataSource = bs;
            formatoGrid();
        }

        private void formatoGrid()
        {
            dtgActivos.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgActivos.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;

            }
            dtgActivos.Columns["lSel"].ReadOnly = false;

            dtgActivos.Columns["cNomAgencia"].Visible = true;
            dtgActivos.Columns["cProducto"].Visible = true;
            dtgActivos.Columns["cSerie"].Visible = true;

            dtgActivos.Columns["lSel"].HeaderText = "S.";
            dtgActivos.Columns["cNomAgencia"].HeaderText = "Agencia";
            dtgActivos.Columns["cProducto"].HeaderText = "Producto";
            dtgActivos.Columns["cSerie"].HeaderText = "Serie";
        }

        private void dtgDetalleTransferencia_Click(object sender, EventArgs e)
        {
            selDetaTransferenciaActivosEvento();
        }

        private void dtgDetalleTransferencia_Enter(object sender, EventArgs e)
        {
            selDetaTransferenciaActivosEvento();
        }

        private void dtgDetalleTransferencia_SelectionChanged_1(object sender, EventArgs e)
        {
            selDetaTransferenciaActivosEvento();
        }
    }
}
