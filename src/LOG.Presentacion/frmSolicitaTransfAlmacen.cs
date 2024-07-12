using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using LOG.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;

namespace LOG.Presentacion
{
    public partial class frmSolicitaTransfAlmacen : frmBase
    {
        #region Variables

        private const string cTituloMsjes = "Solicitud de transferencia entre almacenes.";
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
        private clsCNAlmacen cnalmacen;
        private List<clsTransferenciaAlmacen> lstTransferencia = new List<clsTransferenciaAlmacen>();
        private clsTransferenciaAlmacen objTransfAlmacen;
        public List<clsDetTransferenciasActivo> listaActivosATransferirTotal = new List<clsDetTransferenciasActivo>();

        #endregion

        #region Constructores

        public frmSolicitaTransfAlmacen()
        {
            InitializeComponent();
            cnalmacen = new clsCNAlmacen();
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(dFechaSis.Year, dFechaSis.Month, 1);
            dtpFecFin.Value = dFechaSis;
            cboAgencias.SelectedIndex = -1;
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            ActivaControl(true);
            ListarTransferencias();
            if (clsVarGlobal.nIdAgencia == 1)
                cboAgencias.Enabled = true;
            else cboAgencias.Enabled = false;

            cboEstadoProcLog.listarEstadoProcesoAdj(4);
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt32(cboAgencias.SelectedValue));
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!ValidaBusqueda())
                return;

            ListarTransferencias();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            objTransfAlmacen = new clsTransferenciaAlmacen();
            ActivaControl(false);
            cboMoneda.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dtgTransferencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActivaControl(false);
            btnEditar.Enabled = false;
            btnAddTransf.Enabled = false;
            btnRemoveTransf.Enabled = false;
            objTransfAlmacen = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;
            objTransfAlmacen.lstDetTransf = (List<clsDetTranfAlmacen>)dtgDetalleTransferencia.DataSource;
            lstTransferencia.Clear();
            lstTransferencia.Add(objTransfAlmacen);
            dtgTransferencias.SelectionChanged -= new EventHandler(dtgTransferencias_SelectionChanged);

            dtgTransferencias.DataSource = lstTransferencia.Where(x => x.lVigente == true).ToList();
            FormatoTransferencia();

            dtgTransferencias.SelectionChanged += new EventHandler(dtgTransferencias_SelectionChanged);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Valida())
                return;

            objTransfAlmacen.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

            clsDBResp objDbResp = cnalmacen.CNGuardaTransferenciaAlmacen(objTransfAlmacen);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActivaControl(true);
                ListarTransferencias();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(dFechaSis.Year, dFechaSis.Month, 1);
            dtpFecFin.Value = dFechaSis;
            LimpiarControles();
            ActivaControl(true);
            cboMoneda.Enabled = false;
        }

        private void dtgTransferencias_SelectionChanged(object sender, EventArgs e)
        {
            ListarDetalleTransferencia();
            selDetaTransferenciaActivosEvento();
        }

        private void btnAddTransf_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.Rows.Count > 0)
            {
                MessageBox.Show("Ya existe un Almacen Registrado - Quite y Agrege si quiere cambiar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnRemoveTransf.Focus();
                return;
            }

            frmBuscaAlmacen FrmBuscaAlmacen = new frmBuscaAlmacen();
            FrmBuscaAlmacen.ShowDialog();
            if (!string.IsNullOrEmpty(FrmBuscaAlmacen.cAlmacenOri))
            {
                lstTransferencia.Clear();
                objTransfAlmacen.dFechaRegistro = clsVarGlobal.dFecSystem;
                objTransfAlmacen.cWinUser = clsVarGlobal.User.cWinUser;
                objTransfAlmacen.cAlmacenOri = FrmBuscaAlmacen.cAlmacenOri;
                objTransfAlmacen.cAlmacenDes = FrmBuscaAlmacen.cAlmacenDes;
                objTransfAlmacen.cEstado = "POR SOLICITAR";
                objTransfAlmacen.idAlmacenOri = FrmBuscaAlmacen.idAlmacenOri;
                objTransfAlmacen.idAlmacenDes = FrmBuscaAlmacen.idAlmacenDes;

                objTransfAlmacen.idAgenciaOri = FrmBuscaAlmacen.idAgenciaOri;
                objTransfAlmacen.idAgenciaDes = FrmBuscaAlmacen.idAgenciaDes;
                objTransfAlmacen.idUsuarioOri = clsVarGlobal.User.idUsuario;
                objTransfAlmacen.lVigente = true;

                lstTransferencia.Add(objTransfAlmacen);
                ProcesaNumeroItems();

                dtgTransferencias.DataSource = lstTransferencia.Where(x => x.lVigente).ToList();
                FormatoTransferencia();
            }
        }

        private void btnRemoveTransf_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtgTransferencias.SelectionChanged -= new EventHandler(dtgTransferencias_SelectionChanged);

            var objTrans = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;
            if (objTrans.idTrasferencias == 0)
            {
                lstTransferencia.Remove(objTrans);
                objTransfAlmacen = new clsTransferenciaAlmacen();

                dtgDetalleTransferencia.DataSource = null;
                dtgActivos.DataSource = null;
            }
            else
            {
                objTrans.lVigente = false;
            }

            dtgTransferencias.DataSource = lstTransferencia.Where(x => x.lVigente).ToList();
            FormatoTransferencia();

            dtgTransferencias.SelectionChanged += new EventHandler(dtgTransferencias_SelectionChanged);
        }

        private void btnAddBien_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Agregar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Int32 idAlmacenActual = lstTransferencia.First().idAlmacenOri;
            frmBusquedaCatalogo frmBusCatalogo = new frmBusquedaCatalogo();
            frmBusCatalogo.idAlmacen = idAlmacenActual;
            frmBusCatalogo.nTipBusqueda = 1;
            frmBusCatalogo.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            frmBusCatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmBusCatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se selecciono ningun producto del catalogo", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgDetalleTransferencia.Rows.Count > 0)
            {
                if (((clsDetTranfAlmacen)dtgDetalleTransferencia.Rows[0].DataBoundItem).objCatalogo.idTipoBien != LstCatalogoSeleccionado[0].idTipoBien)
                {
                    MessageBox.Show("No puede agregar tipos difentes de bienes.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            /*Obtener Stock Transferible por Nota de Entrada*/
            string xmlCatalogo = LstCatalogoSeleccionado.GetXml<clsCatalogo>();
            DataTable dtStock = cnalmacen.CNObtenerStockParaTransferir(xmlCatalogo, idAlmacenActual, Convert.ToInt32(cboMoneda.SelectedValue));

            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                foreach (DataRow row in dtStock.Rows)
                {
                    if (objCatalogo.idCatalogo == Convert.ToInt32(row["idCatalogo"]))
                    {
                        objCatalogo.nCantidadFisico = Convert.ToDecimal(row["nCantidad"]);
                        objCatalogo.nCantidadVirtual = Convert.ToDecimal(row["nCantidad"]);
                        break;
                    }
                }
            }
            

            int nRepetidos = 0, nStockCero = 0, nSolicitados = 0;
            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                Boolean lSolicitado = false;
                foreach (DataRow row in dtStock.Rows)
                {
                    if (objCatalogo.idCatalogo == Convert.ToInt32(row["idCatalogo"]))
                    {
                        lSolicitado = Convert.ToBoolean(row["lSolicitado"]);
                        break;
                    }
                }

                if (objTransfAlmacen.lstDetTransf.Where(x => x.idCatalogo == objCatalogo.idCatalogo && x.lVigente == true).Count() > 0)
                {
                    nRepetidos++;
                }
                else if (objCatalogo.nCantidadVirtual == 0)
                {
                    nStockCero++;
                }
                else if(lSolicitado){
                    nSolicitados++;
                }
                else
                {
                    clsDetTranfAlmacen objDetTrans = new clsDetTranfAlmacen();
                    objDetTrans.objCatalogo = objCatalogo;
                    objDetTrans.idTrasferencia = objDetTrans.idTrasferencia;

                    objTransfAlmacen.lstDetTransf.Add(objDetTrans);
                    ProcNumDetalle();

                    dtgDetalleTransferencia.DataSource = typeof(List<clsCatalogo>);
                    dtgDetalleTransferencia.DataSource = objTransfAlmacen.lstDetTransf.Where(x => x.lVigente).ToList();
                    FormatoDetalle();
                }
            }

            string cMensaje = "Se encontraron item's: \n\n";
            if (nRepetidos > 0)
            {
                cMensaje += "- " + nRepetidos + " Repetidos \n";
            }

            if (nStockCero > 0)
            {
                cMensaje += "- " + nStockCero + " con Stock Cero \n";
            }

            if (nSolicitados > 0)
            {
                cMensaje += "- " + nSolicitados + " pendientes de aprobación \n";
            }

            if (nRepetidos > 0 || nStockCero > 0 || nSolicitados > 0)
            {
                MessageBox.Show(cMensaje + "\n Los demás productos fueron agregados", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitBien_Click(object sender, EventArgs e)
        {
            if (dtgDetalleTransferencia.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida Solicitud de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var objDetTranf = (clsDetTranfAlmacen)dtgDetalleTransferencia.SelectedCells[0].OwningRow.DataBoundItem;
                objTransfAlmacen.lstDetTransf.Remove(objDetTranf);
            }

            dtgDetalleTransferencia.DataSource = objTransfAlmacen.lstDetTransf.Where(x => x.lVigente == true).ToList();
            FormatoDetalle();
        }

        private void dtgDetalleTransferencia_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            int columnIng = dtgDetalleTransferencia.CurrentCell.ColumnIndex;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgDetalleTransferencia_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleTransferencia.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgDetalleTransferencia.CurrentRow.Cells["nCantidad"].EditedFormattedValue.ToString()))
                {
                    dtgDetalleTransferencia.EditingControl.Text = "0";
                    return;
                }
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '-') && (txt.Text.Length > 0))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAgregarActivo_Click(object sender, EventArgs e)
        {
            if (dtgDetalleTransferencia.SelectedCells.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun detalle de transferencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var obj = dtgDetalleTransferencia.SelectedCells[0].OwningRow.DataBoundItem as clsDetTranfAlmacen;

            if (obj.nCantidad > obj.nCantStock)
            {
                MessageBox.Show("La Cantidad a transferir no puede ser mayor que la cantidad en stock", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (obj.nCantidad == 0)
            {
                MessageBox.Show("La Cantidad a transferir no puede ser 0", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una moneda para incluir activos en la misma moneda", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsTransferenciaAlmacen objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;

            frmBuscaActivoPorCli frm = new frmBuscaActivoPorCli();
            frm.idCatalogo = obj.objCatalogo.idCatalogo;
            frm.cProducto = "Producto :" + obj.objCatalogo.cProducto;
            frm.cMoneda = "Moneda :" + cboMoneda.Text;
            frm.idAgenciaOrigen = objTransf.idAgenciaOri;
            frm.cAgencia = "Agencia :" + cboAgencias.obtenerNombreAgenciaPorId(objTransf.idAgenciaOri);
            frm.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

            frm.ShowDialog();

            foreach (clsDetTransferenciasActivo nuevoItem in frm.listaActivosSeleccionados)
            {
                if (objTransf.listaActivosATransferir.Any(x => x.idActivo == nuevoItem.idActivo))
                    continue;

                objTransf.listaActivosATransferir.Add(nuevoItem);
            }

            dtgActivos.DataSource = objTransf.listaActivosATransferir.Where(x => x.idCatalogo == obj.idCatalogo).ToList();
            FormatoGrid();
            cboMoneda.Enabled = objTransf.listaActivosATransferir.Count == 0;
        }

        private void btnQuitarActivo_Click(object sender, EventArgs e)
        {
            if (dtgActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ningun activo seleccionado", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgDetalleTransferencia.SelectedCells.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun detalle de transferencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDetTransferenciasActivo item = (clsDetTransferenciasActivo)dtgActivos.SelectedRows[0].DataBoundItem;
            objTransfAlmacen.listaActivosATransferir.Remove(item);
            dtgActivos.DataSource = objTransfAlmacen.listaActivosATransferir.Where(x => x.idCatalogo == item.idCatalogo).ToList();
            FormatoGrid();
            cboMoneda.Enabled = objTransfAlmacen.listaActivosATransferir.Count == 0;
        }

        private void dtgDetalleTransferencia_SelectionChanged(object sender, EventArgs e)
        {
            selDetaTransferenciaActivosEvento();
        }

        private void frmSolicitaTransfAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgActivos.DataSource = null;
            dtgDetalleTransferencia.DataSource = null;
            dtgTransferencias.DataSource = null;
        }

        #endregion
        
        #region Metodos

        private string convertDataTableXml(DataTable dt)
        {
            dt.TableName = "clsCatalogo";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
                ds = dt.DataSet;
            else
                ds.Tables.Add(dt);
            return ds.GetXml();
        }

        private bool ValidaBusqueda()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha De no debe ser mayor que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecIni.Focus();
                return false;
            }

            return true;

        }

        private void ListarTransferencias()
        {
            LimpiarGrids();
            int idAlmacenDes = 0;
            if (cboAlmacen.SelectedIndex >= 0)
            {
                idAlmacenDes = Convert.ToInt32(cboAlmacen.SelectedValue);
                lstTransferencia = cnalmacen.CNListaSolicitudTransferencia(dtpFecIni.Value, dtpFecFin.Value, idAlmacenDes, -1, Convert.ToInt32(cboEstadoProcLog.SelectedValue));//Convert.ToInt16(EstLog.SOLICITADO));
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
                btnEditar.Enabled = false;
            }
            btnImprimir1.Enabled = true;
        }

        private void ListarDetalleTransferencia()
        {
            if (dtgTransferencias.SelectedRows.Count > 0)
            {
                var objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;

                if (objTransf.idTrasferencias == 0)
                {
                    dtgDetalleTransferencia.DataSource = objTransf.lstDetTransf.Where(x => x.lVigente == true).ToList();
                    FormatoDetalle();
                    return;
                }

                var lstDetTrans = cnalmacen.ListaDetalleTransferencia(objTransf.idTrasferencias);
                dtgDetalleTransferencia.DataSource = lstDetTrans.Where(x => x.lVigente).ToList();
                FormatoDetalle();
                dtgDetalleTransferencia.ReadOnly = true;

                /*Obtener Stock Transferible por Nota de Entrada*/
                DataTable dtCatalogo = new DataTable();
                dtCatalogo.Columns.Add("idCatalogo", typeof(string));
                foreach (var str in lstDetTrans)
                {
                    DataRow row = dtCatalogo.NewRow();
                    row["idCatalogo"] = str;
                    dtCatalogo.Rows.Add(row);
                }

                DataTable dtStock = cnalmacen.CNObtenerStockParaTransferir(convertDataTableXml(dtCatalogo), Convert.ToInt32(cboAlmacen.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));

                foreach (DataGridViewRow rowDet in dtgDetalleTransferencia.Rows)
                {
                    foreach (DataRow row in dtStock.Rows)
                    {
                        if (Convert.ToInt32(rowDet.Cells["idCatalogo"].Value) == Convert.ToInt32(row["idCatalogo"]))
                        {
                            rowDet.Cells["nCantidadFisico"].Value = Convert.ToDecimal(row["nCantidad"]);
                            rowDet.Cells["nCantidadVirtual"].Value = Convert.ToDecimal(row["nCantidad"]);
                            break;
                        }
                    }
                }

                btnEditar.Enabled = (objTransf.idEstado == Convert.ToInt16(EstLog.SOLICITADO));

                objTransf.listaActivosATransferir = new clsCNAlmacen().CNListaDetalleTransActivos(objTransf.idTrasferencias);
                cboMoneda.SelectedIndexChanged -= cboMoneda_SelectedIndexChanged;
                cboMoneda.SelectedValue = objTransf.idMoneda;
                cboMoneda.SelectedIndexChanged += cboMoneda_SelectedIndexChanged;
                cboMoneda.Enabled = false;
            }
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
            dtgDetalleTransferencia.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleTransferencia.Columns)
            {
                column.ReadOnly = true;
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
            dtgDetalleTransferencia.Columns["idCatalogo"].HeaderText = "Cod. Prod.";
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
            dtgDetalleTransferencia.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleTransferencia.Columns["cProducto"].FillWeight = 43;
            dtgDetalleTransferencia.Columns["cUnidad"].FillWeight = 11;
            dtgDetalleTransferencia.Columns["nCantStock"].FillWeight =13;
            dtgDetalleTransferencia.Columns["nCantidad"].FillWeight = 15;

            dtgDetalleTransferencia.Columns["nCantStock"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleTransferencia.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleTransferencia.Columns["nCantidad"].ReadOnly = false;
        }

        private bool Valida()
        {
            if (dtgTransferencias.Rows.Count <= 0)
            {
                MessageBox.Show("Agregue los datos de la transferencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(objTransfAlmacen.cWinUser))
                {
                    MessageBox.Show("Registre Usuario que solicita la transferencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (string.IsNullOrEmpty(objTransfAlmacen.cAlmacenOri))
                {
                    MessageBox.Show("Registre almacen de origen para la solicitud de transferencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (string.IsNullOrEmpty(objTransfAlmacen.cAlmacenDes))
                {
                    MessageBox.Show("Registre almacen de destino que solicita la transferencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (dtgDetalleTransferencia.Rows.Count <= 0)
            {
                MessageBox.Show("Registre detalle de la transferencia de almacen", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var lstDet = dtgDetalleTransferencia.DataSource as List<clsDetTranfAlmacen>;

            if(lstDet.Any(x=>x.nCantidad == 0))
            {
                MessageBox.Show("Existen items con la cantidad igual a 0.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (lstDet.Any(x=>x.nCantidad > x.nCantStock))
            {
                MessageBox.Show("Existen items con la cantidad de items mayor que el stock disponible.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            foreach (DataGridViewRow row in dtgDetalleTransferencia.Rows)
            {
                var objDetTransf = (clsDetTranfAlmacen)row.DataBoundItem;

                if (objDetTransf.idTipoBien != 1)
                    continue;

                int nItemsActivo = objTransfAlmacen.listaActivosATransferir.Where(x => x.idCatalogo == objDetTransf.idCatalogo).Count();
                if (nItemsActivo != objDetTransf.nCantidad)
                {
                    MessageBox.Show("Existen items con la cantidad de activos diferente a la cantidad a transferir.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        private void ActivaControl(bool lActiva)
        {
            btnNuevo.Enabled = lActiva;
            btnEditar.Enabled = lActiva;
            btnGrabar.Enabled = !lActiva;
            btnAddTransf.Enabled = !lActiva;
            btnRemoveTransf.Enabled = !lActiva;
            btnAddBien.Enabled = !lActiva;
            btnQuitBien.Enabled = !lActiva;
            btnBusqueda.Enabled = lActiva;
            dtpFecIni.Enabled = lActiva;
            dtpFecFin.Enabled = lActiva;
            cboAgencias.Enabled = lActiva;
            cboAlmacen.Enabled = lActiva;
            dtgActivos.Enabled = !lActiva;
            btnAgregarActivo.Enabled = !lActiva;
            btnQuitarActivo.Enabled = !lActiva;
            btnImprimir1.Enabled = lActiva;
        }

        private void LimpiarControles()
        {
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtgTransferencias.DataSource = typeof(List<clsTransferenciaAlmacen>);
            dtgDetalleTransferencia.DataSource = typeof(List<clsDetTranfAlmacen>);
            lstTransferencia.Clear();
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

        private void ProcNumDetalle()
        {
            int nNum = 1;
            foreach (var item in objTransfAlmacen.lstDetTransf)
            {
                if (item.lVigente)
                {
                    item.nItem = nNum++;
                }
            }
        }

        private void LimpiarGrids()
        {
            dtgTransferencias.DataSource = typeof(List<clsTransferenciaAlmacen>);
            dtgDetalleTransferencia.DataSource = typeof(List<clsDetTranfAlmacen>);
        }

        private void FormatoGrid()
        {
            dtgActivos.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgActivos.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgActivos.Columns["cNomAgencia"].Visible = true;
            dtgActivos.Columns["cProducto"].Visible = true;
            dtgActivos.Columns["cSerie"].Visible = true;

            dtgActivos.Columns["cNomAgencia"].HeaderText = "Agencia";
            dtgActivos.Columns["cProducto"].HeaderText = "Producto";
            dtgActivos.Columns["cSerie"].HeaderText = "Serie";
        }

        private void selDetaTransferenciaActivosEvento()
        {
            if (dtgDetalleTransferencia.SelectedCells.Count == 0)
            {
                dtgActivos.DataSource = null;
                return;
            }
            if(dtgTransferencias.SelectedRows.Count == 0)
            {
                return;
            }

            var objTransf = dtgTransferencias.SelectedRows[0].DataBoundItem as clsTransferenciaAlmacen;

            clsDetTranfAlmacen obj = (clsDetTranfAlmacen)dtgDetalleTransferencia.SelectedCells[0].OwningRow.DataBoundItem;
            dtgActivos.DataSource = objTransf.listaActivosATransferir.Where(x => x.idCatalogo == obj.idCatalogo).ToList();
            FormatoGrid();
        }

        #endregion

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgDetalleTransferencia.DataSource = null;
            dtgDetalleTransferencia.Rows.Clear();
            dtgDetalleTransferencia.Refresh();
            objTransfAlmacen.lstDetTransf.Clear();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgTransferencias.SelectedRows.Count > 0)
            {
                var objTransf = (clsTransferenciaAlmacen)dtgTransferencias.SelectedRows[0].DataBoundItem;

                DataTable dtTransferencia = cnalmacen.CNGetTransferencia(objTransf.idTrasferencias);
                DataTable dtDetTransferencia = cnalmacen.CNGetDetTransferencia(objTransf.idTrasferencias);
                
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dtTransferencia", dtTransferencia));
                    dtsList.Add(new ReportDataSource("dtDetalleTransferencia", dtDetTransferencia));

                    List<ReportParameter> paramList = new List<ReportParameter>();

                    paramList.Add(new ReportParameter("dFecIni", dFechaSis.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("dFecFin", dFechaSis.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("idTransferencia", objTransf.idTrasferencias.ToString(), false));

                    string reportPath = "rptTransferenciaAlmacen.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
               
            }
        }

    }
}
