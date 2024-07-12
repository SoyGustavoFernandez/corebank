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
using CAJ.CapaNegocio;
using CAJ.Presentacion;

namespace LOG.Presentacion
{
    public partial class frmEntradaAlmacen : frmBase
    {
        #region Variables Globales

        private const string cTituloMensajes = "Entrada a almacén";
        clsCNNotaEntrada objCNNotaEntrada = new clsCNNotaEntrada();
        clsCNOrdenCompra objCNOrdenCompra = new clsCNOrdenCompra();
        private List<clsOrdenCompra> lstOrdenCompra = new List<clsOrdenCompra>();
        private List<clsTransferenciaAlmacen> lstTransAlmacen = new List<clsTransferenciaAlmacen>();
        private List<clsDetalleOrdenCompra> lstDetalleOrdenCompra = new List<clsDetalleOrdenCompra>();
        private List<clsDetTranfAlmacen> lstDetTransf = new List<clsDetTranfAlmacen>();
        private clsNotaEntrada objNotaEntrada;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgenciaBus.SelectedValue = clsVarGlobal.nIdAgencia;
            //cboAlmacenes.CargarAlmacenOfi(clsVarGlobal.nIdAgencia);
            IniForm();
            //ListarOrdenesCompra();
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacenes.CargarAlmacenOfi(Convert.ToInt32(cboAgencia.SelectedValue));
            }
        }

        private void cboAgenciaBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgenciaBus.SelectedIndex >= 0)
            {
                cboAlmacenBus.CargarAlmacenOfi(Convert.ToInt32(cboAgenciaBus.SelectedValue));
            }
        }

        private void cboTipoIngresoNotEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTipoIngresoNotEnt.SelectedIndex >= 0)
            //{
            //    grbCpg.Visible = (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1);
            //}
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            LimpiarGrids("T");
            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                ListarOrdenesCompra();
            }
            else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                ListarTransferencias();
            }
        }

        private void dtgOrdenesCompra_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarGrids("D");
            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                ListarDetalleOrdenCompra();
                ListarNotasEntrada();
            }
            else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                ListarDetTransferencias();
                ListarNotasEntrada();
            }
        }

        private void dtgNotasEntrada_SelectionChanged(object sender, EventArgs e)
        {
            ListarDetalleNotaEntrada();
            HabilitaEditarCantidad(false);
        }

        private void dtgDetalleNotaEntrada_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDetalleNotaEntrada.CurrentRow == null)
                return;

            var objDetNotaEntrada = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.CurrentRow.DataBoundItem;
            var objDetOrdenCompra = lstDetalleOrdenCompra.Where(x=>x.idCatalogo == objDetNotaEntrada.idCatalogo).First();


            if (objDetNotaEntrada.nCantidad > objDetOrdenCompra.nPorEntregar)
            {
                MessageBox.Show("La cantidad debe de ser menor o igual a: " + objDetOrdenCompra.nPorEntregar.ToString(), "Registro Nota Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objDetNotaEntrada.nCantidad = 0M;
                objDetNotaEntrada.nSubTotal = 0M;
                return;
            }

            objDetNotaEntrada.nSubTotal = objDetNotaEntrada.nCantidad * objDetNotaEntrada.nPrecioUnitario;
        }

        private void dtgDetalleNotaEntrada_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleNotaEntrada.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgDetalleNotaEntrada.CurrentRow.Cells["nCantidad"].EditedFormattedValue.ToString()))
                {
                    dtgDetalleNotaEntrada.EditingControl.Text = "0.00";
                    return;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                if (lstDetalleOrdenCompra.Where(x => x.nPorEntregar > 0).ToList().Count == 0)
                {
                    MessageBox.Show("Todos los items de la orden de compra ya fueron entregados.", "Entrada a almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                if (lstDetTransf.Where(x => x.nPorEntregar > 0).ToList().Count == 0)
                {
                    MessageBox.Show("Todos los items de la orden de compra ya fueron entregados.", "Entrada a almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnAddDetActivos.Enabled = true;
            btnQuitDetActivos.Enabled = true;

            LimpiarControles();
            HabilitaEditarCantidad(true);
            HabilitarControles(true);

            objNotaEntrada = new clsNotaEntrada();
            CargarNuevaNotaEntrada();
            dtgDetalleNotaEntrada.SelectionChanged += new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);   
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var lstItemNoEntreg = lstDetalleOrdenCompra.Where(x => x.nPorEntregar > 0).ToList();
            if (lstItemNoEntreg.Count == 0)
            {
                MessageBox.Show("Todos los items de la orden de compra ya fueron entregados.", "Entrada a almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;

            dtgOrdenesCompra.Enabled = false;
            dtgDetalleOrdenCompra.Enabled = false;
            dtgNotasEntrada.Enabled = false;
            dtgDetalleNotaEntrada.Enabled = true;
            grbBusca.Enabled = false;

            if (dtgNotasEntrada.SelectedRows.Count > 0)
            {
                objNotaEntrada = (clsNotaEntrada)dtgNotasEntrada.SelectedRows[0].DataBoundItem;
            }

            HabilitaEditarCantidad(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            grbBusca.Enabled = true;
            btnAddDetActivos.Enabled = false;
            btnQuitDetActivos.Enabled = false;

            dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);

            dtgOrdenesCompra.Enabled = true;
            dtgDetalleOrdenCompra.Enabled = true;
            dtgNotasEntrada.Enabled = true;
            dtgDetalleNotaEntrada.Enabled = true;

            dtgDetalleNotaEntrada.DataSource = null;
            ListarNotasEntrada();
            HabilitaEditarCantidad(false);
            HabilitarControles(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;

            objNotaEntrada.idTipIngNotaEntrada = Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue);
            if (objNotaEntrada.idTipIngNotaEntrada == 1)
            {
                var objOrdenCompra = (clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                objNotaEntrada.idOrden = objOrdenCompra.idOrden;
                objNotaEntrada.idProveedor = objOrdenCompra.idProveedor;
                objNotaEntrada.idCliProveedor = objOrdenCompra.idCli; 
            }
            else if (objNotaEntrada.idTipIngNotaEntrada == 2)
            {
                var objTransferencia = (clsTransferenciaAlmacen)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                objNotaEntrada.idTrasferencias = objTransferencia.idTrasferencias;
                objNotaEntrada.idProveedor = 0;
                objNotaEntrada.idCliProveedor = 0; 
            }
          
            objNotaEntrada.nNroDocumento = string.Empty;            
            objNotaEntrada.idUsuario = clsVarGlobal.User.idUsuario;           
            objNotaEntrada.idEstadoLog = Convert.ToInt16(EstLog.SOLICITADO);
            objNotaEntrada.idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);
            objNotaEntrada.idAlmacen = Convert.ToInt32(cboAlmacenes.SelectedValue);            
            objNotaEntrada.dFechaReg = clsVarGlobal.dFecSystem;
            objNotaEntrada.dFechaMod = clsVarGlobal.dFecSystem;
            objNotaEntrada.nNroNotaEntrada = 1;
            objNotaEntrada.nTotal = objNotaEntrada.lstDetalleNotaEntrada.Where(x=>x.nCantidad>0).Sum(x=>x.nSubTotal);

            clsDBResp objDbResp = objCNNotaEntrada.InsertarActualizarNotaEntrada(objNotaEntrada);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Entrada a almacén.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Entrada a almacén.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnAddDetActivos.Enabled = false;
            btnQuitDetActivos.Enabled = false;

            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            cboAlmacenes.Enabled = false;

            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                ListarDetalleOrdenCompra();
            }
            else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                ListarDetTransferencias();
            }
            btnCancelar.PerformClick();
        }

        private void btnAddDetActivos_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNotaEntrada.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el producto a detallar.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDetalleNotaEntrada objDetNotaEntrada = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedRows[0].DataBoundItem;
            if (objDetNotaEntrada.idTipoBien != 1)
            {
                MessageBox.Show("Solo puede ingresar el detalle para activos.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (objDetNotaEntrada.lstActivos.Count >= objDetNotaEntrada.nCantidad)
            {
                MessageBox.Show("Ya se detallaron todos los productos.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmDetalleActivo frmDetActivo = new frmDetalleActivo();
            frmDetActivo.ShowDialog();

            if (frmDetActivo.objActivo == null)
            {
                MessageBox.Show("No se creó el detalle para el activo.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsActivo objActivo = frmDetActivo.objActivo;
            objActivo.dFechaCompra = ((clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem).dFechaEmision;
            objActivo.idTipoBien = objDetNotaEntrada.idTipoBien;
            objActivo.idCatalogo = objDetNotaEntrada.idCatalogo;
            objActivo.nValorActual = objDetNotaEntrada.nPrecioUnitario;
            objActivo.idCliProveedor = ((clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem).idProveedor;
            objDetNotaEntrada.lstActivos.Add(frmDetActivo.objActivo);

            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            dtgDetActivos.DataSource = objDetNotaEntrada.lstActivos;
            FormatoDetalleActivos();
        }

        private void btnQuitDetActivos_Click(object sender, EventArgs e)
        {
            if (dtgDetActivos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione el detalle del activo que desea eliminar.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgDetalleNotaEntrada.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el producto a detallar.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDetalleNotaEntrada objDetNotaEntrada = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedRows[0].DataBoundItem;
            objDetNotaEntrada.lstActivos.Remove((clsActivo)dtgDetActivos.SelectedRows[0].DataBoundItem);

            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            dtgDetActivos.DataSource = objDetNotaEntrada.lstActivos;
            FormatoDetalleActivos();

        }

        private void dtgDetalleNotaEntrada_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNotaEntrada.SelectedRows.Count <= 0)
            {
                return;
            }
            clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedRows[0].DataBoundItem;

            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            dtgDetActivos.DataSource = objDetNE.lstActivos;
            FormatoDetalleActivos();
        }

        private void btnBusCpg_Click(object sender, EventArgs e)
        {
            frmBuscarComprPago frmBusCpg = new frmBuscarComprPago();
            frmBusCpg.chcTieneComprobante.Checked = true;
            frmBusCpg.chcCajChic.Checked = chcCajaChica.Checked;
            frmBusCpg.ShowDialog();

            if (frmBusCpg.pidComprobantePago == 0)
            {
                MessageBox.Show("No se seleccionó ningun comprobante de pago.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BuscarComprobante(frmBusCpg.pidComprobantePago);
        }

        #endregion

        #region Metodos

        public frmEntradaAlmacen()
        {
            InitializeComponent();
        }

        private void ListarOrdenesCompra()
        {
            int idAlmacen = 0;
            if (cboAlmacenBus.SelectedIndex >= 0)
            {
                idAlmacen = Convert.ToInt32(cboAlmacenBus.SelectedValue);
                lstOrdenCompra = objCNOrdenCompra.ListarOrdenes(dtpFecIni.Value, dtpFecFin.Value, idAlmacen);
            }
            if (lstOrdenCompra.Count > 0)
            {
                btnNuevo.Enabled = true;
            }

            dtgOrdenesCompra.SelectionChanged -= new EventHandler(dtgOrdenesCompra_SelectionChanged);
            dtgOrdenesCompra.DataSource = lstOrdenCompra;
            FormatoOrdenesCompra();

            ListarDetalleOrdenCompra();
            dtgOrdenesCompra.SelectionChanged += new EventHandler(dtgOrdenesCompra_SelectionChanged);
            ListarNotasEntrada();
        }

        private void ListarDetalleOrdenCompra()
        {
            if (dtgOrdenesCompra.SelectedRows.Count > 0)
            {
                clsOrdenCompra objOrdenCompra = (clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                lstDetalleOrdenCompra = objCNOrdenCompra.ListarDetalleOrden(objOrdenCompra.idOrden);

                dtgDetalleOrdenCompra.DataSource = lstDetalleOrdenCompra;
                FormatoDetalleOrdenCompra();
            }
        }

        private void ListarTransferencias()
        {
            int idAlmacenDes = 0;
            if (cboAlmacenes.SelectedIndex >= 0)
            {
                idAlmacenDes = Convert.ToInt32(cboAlmacenBus.SelectedValue);
                lstTransAlmacen = new clsCNAlmacen().CNListaSolicitudTransferencia(dtpFecIni.Value, dtpFecFin.Value, -1,idAlmacenDes, Convert.ToInt16(EstLog.APROBADO));
            }

            if (lstTransAlmacen.Count > 0)
            {
                btnNuevo.Enabled = true;
            }

            dtgOrdenesCompra.SelectionChanged -= new EventHandler(dtgOrdenesCompra_SelectionChanged);
            dtgOrdenesCompra.DataSource = lstTransAlmacen;
            FormatoTransferencia();

            ListarDetTransferencias();
            dtgOrdenesCompra.SelectionChanged += new EventHandler(dtgOrdenesCompra_SelectionChanged);
            ListarNotasEntrada();
        }

        private void ListarDetTransferencias()
        {
            if (dtgOrdenesCompra.SelectedRows.Count > 0)
            {
                clsTransferenciaAlmacen objTransf = (clsTransferenciaAlmacen)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                lstDetTransf = new clsCNAlmacen().ListarDetTransfIngresoAlmacen(objTransf.idTrasferencias);

                dtgDetalleOrdenCompra.DataSource = lstDetTransf;
                FormatoDetalleTransferencias();
            } 
        }

        private void ListarNotasEntrada()
        {
            if (dtgOrdenesCompra.SelectedRows.Count > 0)
            {
                List<clsNotaEntrada> lstNotasEntrada = new List<clsNotaEntrada>();
                if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
                {
                    var objOrdenCompra = (clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                    lstNotasEntrada = objCNNotaEntrada.ListaNotasEntradaxMovimiento(objOrdenCompra.idOrden,1);
                }
                else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
                {
                    var objTransAlmacen = (clsTransferenciaAlmacen)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                    lstNotasEntrada = objCNNotaEntrada.ListaNotasEntradaxMovimiento(objTransAlmacen.idTrasferencias,2);
                }  

                if (lstNotasEntrada.Count > 0)
                {
                    btnEditar.Enabled = true;
                }
                dtgNotasEntrada.SelectionChanged -= new EventHandler(dtgNotasEntrada_SelectionChanged);
                dtgNotasEntrada.DataSource = lstNotasEntrada;
                FormatoNotasEntrada();
                dtgNotasEntrada.SelectionChanged += new EventHandler(dtgNotasEntrada_SelectionChanged);
                ListarDetalleNotaEntrada();
                
            }
        }

        private void ListarDetalleNotaEntrada()
        {
            if (dtgNotasEntrada.SelectedRows.Count > 0)
            {
                objNotaEntrada = (clsNotaEntrada)dtgNotasEntrada.SelectedRows[0].DataBoundItem;
                MapeaDatosNotaEntrada(objNotaEntrada);

                var lstDetalleNotaEntrada = objCNNotaEntrada.ListDetalleNotaEntrada(objNotaEntrada.idNotaEntrada);
                dtgDetalleNotaEntrada.DataSource = lstDetalleNotaEntrada;
                FormatoDetalleNotaEntrada();
            }
            else
            {
                LimpiarControles();
            }
        }

        private void FormatoOrdenesCompra()
        {
            foreach (DataGridViewColumn item in dtgOrdenesCompra.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgOrdenesCompra.Columns["idOrden"].Visible = true;
            dtgOrdenesCompra.Columns["dFechaReg"].Visible = true;
            dtgOrdenesCompra.Columns["cMoneda"].Visible = true;

            dtgOrdenesCompra.Columns["idOrden"].HeaderText = "Código";
            dtgOrdenesCompra.Columns["dFechaReg"].HeaderText = "Fecha";
            dtgOrdenesCompra.Columns["cMoneda"].HeaderText = "Moneda";

            dtgOrdenesCompra.Columns["idOrden"].FillWeight = 20;
            dtgOrdenesCompra.Columns["dFechaReg"].FillWeight = 40;
            dtgOrdenesCompra.Columns["cMoneda"].FillWeight = 40;
        }

        private void FormatoDetalleOrdenCompra()
        {
            foreach (DataGridViewColumn item in dtgDetalleOrdenCompra.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleOrdenCompra.Columns["nNum"].Visible = true;
            dtgDetalleOrdenCompra.Columns["cProducto"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nCantidad"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].Visible = true;

            dtgDetalleOrdenCompra.Columns["nNum"].HeaderText = "N°";
            dtgDetalleOrdenCompra.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleOrdenCompra.Columns["nCantidad"].HeaderText = "Cant. Comprada";
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].HeaderText = "Por Entregar";
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].HeaderText = "P.U.";

            dtgDetalleOrdenCompra.Columns["nNum"].DisplayIndex = 0;
            dtgDetalleOrdenCompra.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleOrdenCompra.Columns["nCantidad"].DisplayIndex = 2;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DisplayIndex = 3;
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].DisplayIndex = 5;

            dtgDetalleOrdenCompra.Columns["nNum"].FillWeight = 6;
            dtgDetalleOrdenCompra.Columns["cProducto"].FillWeight = 38;
            dtgDetalleOrdenCompra.Columns["nCantidad"].FillWeight = 11;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].FillWeight = 10;
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].FillWeight = 12;

            dtgDetalleOrdenCompra.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleOrdenCompra.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleOrdenCompra.Columns["nPrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FormatoNotasEntrada()
        {
            foreach (DataGridViewColumn item in dtgNotasEntrada.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgNotasEntrada.Columns["nNroDocumento"].Visible = true;

            dtgNotasEntrada.Columns["nNroDocumento"].HeaderText = "Nro. Documento";
        }

        private void FormatoDetalleNotaEntrada()
        {
            dtgDetalleNotaEntrada.CellValidating -= new DataGridViewCellValidatingEventHandler(dtgDetalleNotaEntrada_CellValidating);
            dtgDetalleNotaEntrada.CellValueChanged -= new DataGridViewCellEventHandler(dtgDetalleNotaEntrada_CellValueChanged);
            dtgDetalleNotaEntrada.ReadOnly = false;
            foreach (DataGridViewColumn item in this.dtgDetalleNotaEntrada.Columns)
            {
                item.ReadOnly = true;
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleNotaEntrada.Columns["nNum"].Visible = true;
            dtgDetalleNotaEntrada.Columns["cProducto"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nCantidad"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].Visible = true;

            dtgDetalleNotaEntrada.Columns["nNum"].HeaderText = "Item";
            dtgDetalleNotaEntrada.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleNotaEntrada.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].HeaderText = "P.U.";

            dtgDetalleNotaEntrada.Columns["nNum"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["cProducto"].FillWeight = 40;
            dtgDetalleNotaEntrada.Columns["nCantidad"].FillWeight = 25;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].FillWeight = 25;

            dtgDetalleNotaEntrada.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetalleNotaEntrada.Columns["nCantidad"].ReadOnly = false;
            dtgDetalleNotaEntrada.CellValueChanged += new DataGridViewCellEventHandler(dtgDetalleNotaEntrada_CellValueChanged);
            dtgDetalleNotaEntrada.CellValidating += new DataGridViewCellValidatingEventHandler(dtgDetalleNotaEntrada_CellValidating);
        }

        private void FormatoDetalleActivos()
        {
            foreach (DataGridViewColumn column in dtgDetActivos.Columns)
            {
                column.Visible = false;
            }

            dtgDetActivos.Columns["cColor"].Visible = true;
            dtgDetActivos.Columns["cMaterial"].Visible = true;
            dtgDetActivos.Columns["cRubro"].Visible = true;
            dtgDetActivos.Columns["cMarca"].Visible = true;
            dtgDetActivos.Columns["cSerie"].Visible = true;
            dtgDetActivos.Columns["cModelo"].Visible = true;

            dtgDetActivos.Columns["cColor"].HeaderText = "Color";
            dtgDetActivos.Columns["cMaterial"].HeaderText = "Material";
            dtgDetActivos.Columns["cRubro"].HeaderText = "Rubro";
            dtgDetActivos.Columns["cMarca"].HeaderText = "Marca";
            dtgDetActivos.Columns["cSerie"].HeaderText = "Serie";
            dtgDetActivos.Columns["cModelo"].HeaderText = "Modelo";
        }

        private void FormatoTransferencia()
        {
            foreach (DataGridViewColumn item in dtgOrdenesCompra.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgOrdenesCompra.Columns["idTrasferencias"].Visible = true;
            dtgOrdenesCompra.Columns["dFechaRegistro"].Visible = true;
            dtgOrdenesCompra.Columns["cAlmacenOri"].Visible = true;

            dtgOrdenesCompra.Columns["idTrasferencias"].HeaderText = "Código";
            dtgOrdenesCompra.Columns["dFechaRegistro"].HeaderText = "Fecha";
            dtgOrdenesCompra.Columns["cAlmacenOri"].HeaderText = "Almacén Origen";

            dtgOrdenesCompra.Columns["idTrasferencias"].FillWeight = 20;
            dtgOrdenesCompra.Columns["dFechaRegistro"].FillWeight = 40;
            dtgOrdenesCompra.Columns["cAlmacenOri"].FillWeight = 40;
        }

        private void FormatoDetalleTransferencias()
        {
            foreach (DataGridViewColumn column in dtgDetalleOrdenCompra.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleOrdenCompra.Columns["nItem"].Visible = true;
            dtgDetalleOrdenCompra.Columns["cProducto"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nCantidad"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nPrecUni"].Visible = true;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].Visible = true;

            dtgDetalleOrdenCompra.Columns["nItem"].HeaderText = "N°";
            dtgDetalleOrdenCompra.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleOrdenCompra.Columns["nCantidad"].HeaderText = "Cant. Enviada";
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].HeaderText = "Por Entregar";
            dtgDetalleOrdenCompra.Columns["nPrecUni"].HeaderText = "P.U.";           

            dtgDetalleOrdenCompra.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleOrdenCompra.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleOrdenCompra.Columns["nCantidad"].DisplayIndex = 2;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DisplayIndex = 3;
            dtgDetalleOrdenCompra.Columns["nPrecUni"].DisplayIndex = 4;          

            dtgDetalleOrdenCompra.Columns["nItem"].FillWeight = 6;
            dtgDetalleOrdenCompra.Columns["cProducto"].FillWeight = 38;
            dtgDetalleOrdenCompra.Columns["nCantidad"].FillWeight = 11;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].FillWeight = 10;
            dtgDetalleOrdenCompra.Columns["nPrecUni"].FillWeight = 12;

            dtgDetalleOrdenCompra.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleOrdenCompra.Columns["nPrecUni"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleOrdenCompra.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleOrdenCompra.Columns["nPorEntregar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleOrdenCompra.Columns["nPrecUni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;    
        }

        private void CargarNuevaNotaEntrada()
        {
            if (dtgOrdenesCompra.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1)
                {
                    var objOrdenCompra = (clsOrdenCompra)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                    cboAgencia.SelectedValue = objOrdenCompra.idAgencia;
                    cboAlmacenes.SelectedValue = objOrdenCompra.idAlmacenEntrega;
                    var lstDetalleOrdenCompra = (List<clsDetalleOrdenCompra>)dtgDetalleOrdenCompra.DataSource; //objCNOrdenCompra.ListarDetalleOrden(objOrdenCompra.idOrden);
                    objNotaEntrada.lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();

                    foreach (var objDetOC in lstDetalleOrdenCompra)
                    {
                        objDetOC.nCantidad = objDetOC.nPorEntregar;
                        if (objDetOC.nPorEntregar > 0M)
                        {
                            clsDetalleNotaEntrada objDetalleNotaEntrada = new clsDetalleNotaEntrada();
                            objDetalleNotaEntrada.nNum = objDetOC.nNum;
                            objDetalleNotaEntrada.idNotaEntrada = objDetOC.idNotaEntrada;
                            objDetalleNotaEntrada.nTotal = objDetOC.nTotal;
                            objDetalleNotaEntrada.idCatalogo = objDetOC.idCatalogo;
                            objDetalleNotaEntrada.cProducto = objDetOC.cProducto;
                            objDetalleNotaEntrada.cUnidad = objDetOC.cDesTipoUniMed;
                            objDetalleNotaEntrada.nCantidad = objDetOC.nCantidad;
                            objDetalleNotaEntrada.nPrecioUnitario = objDetOC.nPrecioUnitario;
                            objDetalleNotaEntrada.nSubTotal = objDetOC.nCantidad * objDetOC.nPrecioUnitario;
                            objDetalleNotaEntrada.idTipoBien = objDetOC.idTipoBien;

                            objNotaEntrada.lstDetalleNotaEntrada.Add(objDetalleNotaEntrada);
                        }
                    }                    
                }
                else if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 2)
                {
                    var objTransferencia = (clsTransferenciaAlmacen)dtgOrdenesCompra.SelectedRows[0].DataBoundItem;
                    cboAgencia.SelectedValue = objTransferencia.idAgenciaDes;
                    cboAlmacenes.SelectedValue = objTransferencia.idAlmacenDes;
                    var lstDetTransferencia = (List<clsDetTranfAlmacen>)dtgDetalleOrdenCompra.DataSource; 
                    objNotaEntrada.lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();

                    foreach (var objDetTransf in lstDetTransferencia)
                    {
                        objDetTransf.nCantidad = objDetTransf.nPorEntregar;
                        if (objDetTransf.nPorEntregar > 0M)
                        {
                            clsDetalleNotaEntrada objDetalleNotaEntrada = new clsDetalleNotaEntrada();
                            objDetalleNotaEntrada.nNum = objDetTransf.nItem;
                            objDetalleNotaEntrada.idNotaEntrada = 0;
                            objDetalleNotaEntrada.nTotal = 0;
                            objDetalleNotaEntrada.idCatalogo = objDetTransf.idCatalogo;
                            objDetalleNotaEntrada.cProducto = objDetTransf.cProducto;
                            objDetalleNotaEntrada.cUnidad = objDetTransf.objCatalogo.cUnidAlmacenaje;
                            objDetalleNotaEntrada.nCantidad = objDetTransf.nCantidad;
                            objDetalleNotaEntrada.nPrecioUnitario = objDetTransf.nPrecUni;
                            objDetalleNotaEntrada.nSubTotal = objDetTransf.nCantidad * objDetTransf.nPrecUni;
                            objDetalleNotaEntrada.idTipoBien = objDetTransf.idTipoBien;

                            objNotaEntrada.lstDetalleNotaEntrada.Add(objDetalleNotaEntrada);
                        }
                    }
                }

                objNotaEntrada.nTotal = objNotaEntrada.lstDetalleNotaEntrada.Sum(x => x.nSubTotal);

                //dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
                dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
                dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada;
                //dtgDetalleNotaEntrada.SelectionChanged += new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
                FormatoDetalleNotaEntrada();
            }
        }

        private void HabilitaEditarCantidad(bool lEstado)
        {
            if (dtgDetalleNotaEntrada.Rows.Count > 0)
            {
                dtgDetalleNotaEntrada.ReadOnly = !lEstado;
                foreach (DataGridViewColumn item in dtgDetalleNotaEntrada.Columns)
                {
                    item.ReadOnly = true;
                }
                dtgDetalleNotaEntrada.Columns["nCantidad"].ReadOnly = !lEstado;
            }
        }

        private void IniForm()
        {
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboTipoIngresoNotEnt.SelectedValue = 1;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAddDetActivos.Enabled = false;
            btnQuitDetActivos.Enabled = false;
            dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
            HabilitarControles(false);
        }

        private bool ValidarControles()
        {
            if (cboTipoIngresoNotEnt.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de ingreso.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAlmacenes.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacen donde ingresarán los productos.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            StringBuilder cMsje = new StringBuilder();
            foreach (DataGridViewRow row in dtgDetalleNotaEntrada.Rows)
            {
                clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)row.DataBoundItem;
                if(objDetNE.idTipoBien==1){
                    if (objDetNE.lstActivos.Count < objDetNE.nCantidad)
                    {
                        cMsje.Append("Ingrese el detalle de todo los productos " + objDetNE.cProducto +"\n");
                    }
                }
            }

            if(!string.IsNullOrEmpty(cMsje.ToString().Trim()))
            {
                MessageBox.Show(cMsje.ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            //{
            //    if (objNotaEntrada.idComprobantePago == 0)
            //    {
            //        MessageBox.Show("Seleccione el comprobante de pago asociado a la orden de entrega.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}

            return true;
        }

        private void BuscarComprobante(int idCpg)
        {
            DataTable dtComprPago = new clsCNCajaChica().BuscarComprPago(idCpg);
            if (dtComprPago.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Comprobante...Validar", "Buscar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]) == 3)
            {
                MessageBox.Show("El Comprobante se Encuentra Eliminado", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtNumCpg.Text = string.Format("{0} - {1}", Convert.ToString(dtComprPago.Rows[0]["cSerie"]), Convert.ToString(dtComprPago.Rows[0]["cNumero"]));
            cboTipoComprobantePago.SelectedValue = Convert.ToInt16(dtComprPago.Rows[0]["idTipoComprobantePago"]);
            objNotaEntrada.idComprobantePago = Convert.ToInt32(dtComprPago.Rows[0]["idComprobantePago"]);
            chcCajaChica.Checked = Convert.ToBoolean(dtComprPago.Rows[0]["lCpgCajChica"]);
        }

        private void HabilitarControles(bool lHabilitar)
        {
            dtpFecIni.Enabled = !lHabilitar;
            dtpFecFin.Enabled = !lHabilitar;
            btnBusqueda.Enabled = !lHabilitar;
            cboAgenciaBus.Enabled = !lHabilitar;
            cboAlmacenBus.Enabled = !lHabilitar;
            dtgOrdenesCompra.Enabled = !lHabilitar;
            dtgDetalleOrdenCompra.Enabled = !lHabilitar;
            grbBusca.Enabled = !lHabilitar;
            cboAgencia.Enabled = !lHabilitar;
            cboAlmacenes.Enabled = !lHabilitar;
            cboTipoIngresoNotEnt.Enabled = !lHabilitar;
            btnBusCpg.Enabled = lHabilitar;
            chcCajaChica.Enabled = lHabilitar; 
            dtgNotasEntrada.Enabled = !lHabilitar;
            dtgDetalleNotaEntrada.Enabled = lHabilitar;    
        }

        private void MapeaDatosNotaEntrada(clsNotaEntrada objNotaEntrada)
        {
            cboAgencia.SelectedValue = objNotaEntrada.idAgencia;
            cboAlmacenes.SelectedValue = objNotaEntrada.idAlmacen;
            cboTipoIngresoNotEnt.SelectedValue = objNotaEntrada.idTipIngNotaEntrada;
            //if (objNotaEntrada.idTipIngNotaEntrada == 1)
            //{
            //    BuscarComprobante(objNotaEntrada.idComprobantePago);
            //}
            HabilitarControles(false);
        }

        private void LimpiarControles()
        {
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            txtNumCpg.Text = string.Empty;
            cboTipoComprobantePago.SelectedIndex = -1;
            chcCajaChica.Checked = false;            
        }

        private void LimpiarGrids(string cTipo)
        {
            if (cTipo.Equals("T"))
            {
                if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
                {
                    dtgOrdenesCompra.DataSource = typeof(List<clsOrdenCompra>);
                    dtgDetalleOrdenCompra.DataSource = typeof(List<clsDetalleOrdenCompra>);
                }
                else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
                {
                    dtgOrdenesCompra.DataSource = typeof(List<clsTransferenciaAlmacen>);
                    dtgDetalleOrdenCompra.DataSource = typeof(List<clsDetTranfAlmacen>);
                }
                dtgNotasEntrada.DataSource = typeof(List<clsNotaEntrada>);
                dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            }
            else if (cTipo.Equals("D"))
            {
                if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
                {
                    dtgDetalleOrdenCompra.DataSource = typeof(List<clsDetalleOrdenCompra>);
                }
                else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
                {
                    dtgDetalleOrdenCompra.DataSource = typeof(List<clsDetTranfAlmacen>);
                }
                dtgNotasEntrada.DataSource = typeof(List<clsNotaEntrada>);
                dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            }
        }
        
        #endregion 

    }
}
