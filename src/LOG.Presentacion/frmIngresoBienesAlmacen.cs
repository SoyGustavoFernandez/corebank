using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using LOG.CapaNegocio;
using CAJ.CapaNegocio;
using CAJ.Presentacion;


namespace LOG.Presentacion
{
    public partial class frmIngresoBienesAlmacen : frmBase
    {
        #region Variables Globales

        private const string cTituloMensajes = "Entrada a almacén";
        private int curRow = -1;
        private string cSerieCpg = string.Empty;
        private string cNumeroCpg = string.Empty;
        private int idcliProveedor;
        private int idCliProveedorComprobante;

        private clsCNCajaChica objCNCajaChica;
        private clsCNNotaEntrada objCNNotaEntrada = new clsCNNotaEntrada();
        private clsNotaEntrada objNotaEntrada;
        private clsTransferenciaAlmacen objTransferencia;
        private clsOrdenCompra objOrdenCompra;

        #endregion

        #region Constructores

        public frmIngresoBienesAlmacen()
        {
            InitializeComponent();
            objCNCajaChica = new clsCNCajaChica();
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboAgencias.SelectedIndex = -1;
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencias.Enabled = true;
            }
            else
            {
                cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias.Enabled = false;
            }
            IniForm();
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt32(cboAgencias.SelectedValue));
            }
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
                return;
            }

            BuscarComprobante(frmBusCpg.pidComprobantePago);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cboTipoIngresoNotEnt.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de ingreso a almacén", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarControles();
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            txtNumOC.Enabled = true;
            btnBusqOC.Enabled = true;
            cboTipoIngresoNotEnt.Enabled = false;
            chcIgv.Enabled = false;

            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                objNotaEntrada = new clsNotaEntrada();

                grbCpg.Enabled = true;
                grbDatEntrada.Enabled = true;
                grbBienes.Enabled = true;
                btnMiniAgregar.Enabled = false;
                btnMiniQuitar.Enabled = false;
                grbDetalleActivos.Enabled = true;

                txtNumOC.Focus();
                btnMiniAgregar.Enabled = false;
                btnMiniQuitar.Enabled = false;
            }
            else if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                grbBienes.Enabled = true;
                btnMiniAgregar.Enabled = false;
                btnMiniQuitar.Enabled = false;
                frmTransfIngresoAlmacen frmBusTransf = new frmTransfIngresoAlmacen();
                frmBusTransf.ShowDialog();
                if (frmBusTransf.objTransf == null)
                {
                    MessageBox.Show("No se selecciono ninguna transferencia", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnNuevo.Enabled = true;
                    cboTipoIngresoNotEnt.Enabled = true;
                    return;
                }
                objNotaEntrada = new clsNotaEntrada();
                objTransferencia = frmBusTransf.objTransf;
                cboMonedaCpg.SelectedValue = objTransferencia.idMoneda;
            }
            if (Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 3 || Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue) == 4)
            {
                objNotaEntrada = new clsNotaEntrada();

                grbCpg.Enabled = true;
                grbDatEntrada.Enabled = true;
                grbBienes.Enabled = true;
                grbDetalleActivos.Enabled = true;

                this.txtNumOC.Enabled = false;
                this.btnBusqOC.Enabled = false;
                this.btnMiniAgregar.Enabled = true;
                this.btnMiniQuitar.Enabled = true;
                this.chcIgv.Enabled = true;
            }

            CargarNuevaNotaEntrada();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;

            objNotaEntrada.idTipIngNotaEntrada = Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue);

            objNotaEntrada.nNroDocumento = string.Empty;
            objNotaEntrada.idUsuario = clsVarGlobal.User.idUsuario;
            objNotaEntrada.idEstadoLog = Convert.ToInt16(EstLog.SOLICITADO);
            objNotaEntrada.idAgencia = Convert.ToInt16(cboAgencias.SelectedValue);
            objNotaEntrada.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            objNotaEntrada.dFechaReg = clsVarGlobal.dFecSystem;
            objNotaEntrada.dFechaMod = clsVarGlobal.dFecSystem;
            objNotaEntrada.nNroNotaEntrada = 1;
            objNotaEntrada.nTotal = Convert.ToDecimal(txtTotalNE.Text);
            objNotaEntrada.nMontoConvertido = string.IsNullOrEmpty(txtConvertido.Text) ? 0 : Convert.ToDecimal(txtConvertido.Text);
            objNotaEntrada.nTipoCambio = txtTipCambio.nDecValor;

            if (objNotaEntrada.idTipIngNotaEntrada == 2)
            {
                objNotaEntrada.idMoneda = objTransferencia.idMoneda;
            }
            else
            {
                objNotaEntrada.idMoneda = (cboMonedaCpg.SelectedIndex < 0) ? 0 : Convert.ToInt16(cboMonedaCpg.SelectedValue);
            }

            objNotaEntrada.idCliProveedor = idcliProveedor;
            objNotaEntrada.idOrden = (string.IsNullOrEmpty(txtNumOC.Text) ? Convert.ToInt32(null) : Convert.ToInt32(txtNumOC.Text));
            objNotaEntrada.nTotal = txtTotalNE.nDecValor;
            objNotaEntrada.nMontoConvertido = txtConvertido.nDecValor;
            objNotaEntrada.nSubTotal = txtSubTotal.nDecValor;
            objNotaEntrada.nMontoIGV = txtIgv.nDecValor;
            objNotaEntrada.lIncluIGV = chcIgv.Checked;
            if (objNotaEntrada.idTipIngNotaEntrada == 2)
            {
                objNotaEntrada.idTrasferencias = objTransferencia.idTrasferencias;
                objNotaEntrada.idProveedor = 0;
            }

            clsDBResp objDbResp = objCNNotaEntrada.InsertarActualizarNotaEntrada(objNotaEntrada);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniForm();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IniForm();
        }

        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
            frmBusquedaCatalogo frmBusCatalogo = new frmBusquedaCatalogo();
            frmBusCatalogo.nTipBusqueda = 1;
            frmBusCatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmBusCatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningun producto.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nRepetidos = 0;
            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                if (objNotaEntrada.lstDetalleNotaEntrada.Where(x => x.idCatalogo == objCatalogo.idCatalogo).Count() > 0)
                {
                    nRepetidos++;
                }
                
                    clsDetalleNotaEntrada objDetNE = new clsDetalleNotaEntrada();
                    objDetNE.nNum = 0;
                    objDetNE.idTipoBien = objCatalogo.idTipoBien;
                    objDetNE.idCatalogo = objCatalogo.idCatalogo;
                    objDetNE.cProducto = objCatalogo.cProducto;
                    objDetNE.idUnidad = objCatalogo.idUnidadCompra;
                    objDetNE.cUnidad = objCatalogo.cUnidCompra;
                    objDetNE.idNotaEntrada = 0;
                    objDetNE.nCantidad = 0;
                    objDetNE.nPrecioUnitario = 0;
                    objDetNE.nSubTotal = 0;

                    objNotaEntrada.lstDetalleNotaEntrada.Add(objDetNE);

                    EnumerarLista();

                    dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada.ToList();
            }

            if (nRepetidos > 0)
            {
                MessageBox.Show("Se encontraron ítems repetidos, " + nRepetidos + " en total, los cuales fueron agregados nuevamente.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            FormatoGridDetNotEntrada();

            dtgDetalleNotaEntrada.SelectionChanged += new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNotaEntrada.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Seleccione por lo menos un ítem.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedCells[0].OwningRow.DataBoundItem;
            objNotaEntrada.lstDetalleNotaEntrada.Remove(objDetNE);

            dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada.ToList();
            FormatoGridDetNotEntrada();
            CalcularTotalFinal();
        }

        private void btnAddDetActivos_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1) //devolución de bienes
            {
                if (string.IsNullOrEmpty(txtProveedor.Text))
                {
                    MessageBox.Show("Seleccione el proveedor de los bienes.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtNumCpg.Text))
                {
                    MessageBox.Show("Seleccione el comprobante de los bienes.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (dtgDetalleNotaEntrada.SelectedCells.Count == 0)
            {
                MessageBox.Show("Seleccione el producto a detallar.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDetalleNotaEntrada objDetNotaEntrada = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedCells[0].OwningRow.DataBoundItem;
            if (objDetNotaEntrada.idTipoBien != 1)
            {
                MessageBox.Show("Solo puede ingresar el detalle para activos.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (objDetNotaEntrada.lstActivos.Count >= objDetNotaEntrada.nCantidad)
            {
                MessageBox.Show("Ya se detallaron todos los productos.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1 || Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3)
            {
                frmDetalleActivo frmDetActivo = new frmDetalleActivo();
                frmDetActivo.ShowDialog();

                if (frmDetActivo.objActivo == null)
                {
                    MessageBox.Show("No se creó el detalle para el activo.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clsActivo objActivo = frmDetActivo.objActivo;
                objActivo.nValConversion = Convert.ToInt16(cboMonedaCpg.SelectedValue) == 2 ? Convert.ToDecimal(txtTipCambio.Text) : 0;
                objActivo.dFechaCompra = dtpFechaCpg.Value;
                objActivo.idTipoBien = objDetNotaEntrada.idTipoBien;
                objActivo.idCatalogo = objDetNotaEntrada.idCatalogo;
                objActivo.idCliProveedor = objNotaEntrada.idCliProveedor;
                objActivo.idMoneda = Convert.ToInt16(cboMonedaCpg.SelectedValue);
                objActivo.cSerieCpg = cSerieCpg;
                objActivo.cNumeroCpg = cNumeroCpg;
                objActivo.idTipComPag = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
                objActivo.idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                objDetNotaEntrada.lstActivos.Add(frmDetActivo.objActivo);

                dtgDetActivos.DataSource = objDetNotaEntrada.lstActivos.ToList();
                FormatoDetalleActivos();
            }
            else if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 4)
            {
                frmBuscaActivoPorCli frm = new frmBuscaActivoPorCli();
                frm.idCatalogo = objDetNotaEntrada.idCatalogo;
                frm.cProducto = "";
                frm.lBuscaCli = true;
                frm.idAgenciaOrigen = Convert.ToInt32(cboAgencias.SelectedValue);
                frm.cAgencia = cboAgencias.Text;

                frm.ShowDialog();

                if (frm.listaActivosSel.Count > 0)
                {
                    foreach (clsActivo item in frm.listaActivosSel)
                    {
                        objDetNotaEntrada.lstActivos.Add(item);
                    }
                }

                cargarTotalDetalleNotaEntrada();
                FormatoGridDetNotEntrada();
                CalcularTotalFinal();
                dtgDetActivos.DataSource = objDetNotaEntrada.lstActivos.ToList();
                FormatoDetalleActivos();
            }
        }

        private void btnQuitDetActivos_Click(object sender, EventArgs e)
        {
            if (dtgDetActivos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione el detalle del activo que desea eliminar.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgDetalleNotaEntrada.SelectedCells.Count == 0)
            {
                MessageBox.Show("Seleccione el producto del detalle.", "Entrada a almacen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDetalleNotaEntrada objDetNotaEntrada = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedCells[0].OwningRow.DataBoundItem;
            objDetNotaEntrada.lstActivos.Remove((clsActivo)dtgDetActivos.SelectedRows[0].DataBoundItem);

            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            dtgDetActivos.DataSource = objDetNotaEntrada.lstActivos;
            FormatoDetalleActivos();

        }

        private void dtgDetalleNotaEntrada_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNotaEntrada.SelectedCells.Count <= 0)
                return;

            if (dtgDetalleNotaEntrada.SelectedCells[0].RowIndex != curRow)
            {
                clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.SelectedCells[0].OwningRow.DataBoundItem;
                dtgDetActivos.DataSource = objDetNE.lstActivos.ToList();
                FormatoDetalleActivos();
                curRow = dtgDetalleNotaEntrada.SelectedCells[0].RowIndex;
            }
        }

        private void dtgDetalleNotaEntrada_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleNotaEntrada.CurrentRow != null)
            {
                if (dtgDetalleNotaEntrada.Columns[e.ColumnIndex].Name.Equals("nCantidad"))
                {
                    if (string.IsNullOrEmpty(dtgDetalleNotaEntrada.CurrentRow.Cells["nCantidad"].EditedFormattedValue.ToString()))
                    {
                        dtgDetalleNotaEntrada.EditingControl.Text = "0";
                        return;
                    }
                }

                if (dtgDetalleNotaEntrada.Columns[e.ColumnIndex].Name.Equals("nPrecioUnitario"))
                {
                    if (string.IsNullOrEmpty(dtgDetalleNotaEntrada.CurrentRow.Cells["nPrecioUnitario"].EditedFormattedValue.ToString()))
                    {
                        dtgDetalleNotaEntrada.EditingControl.Text = "0";
                        return;
                    }
                }
            }
        }

        private void dtgDetalleNotaEntrada_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgDetalleNotaEntrada.CurrentRow != null)
                {
                    if (dtgDetalleNotaEntrada.Columns[e.ColumnIndex].Name.Equals("nCantidad") ||
                        dtgDetalleNotaEntrada.Columns[e.ColumnIndex].Name.Equals("nPrecioUnitario"))
                        CalcularTotalFila();
                    CalcularTotalFinal();
                }
            }
        }

        private void dtgDetalleNotaEntrada_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        private void btnBusProveedor_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
            frmBusProveedor.ShowDialog();

            if (frmBusProveedor.objProveedor == null)
            {
                MessageBox.Show("No se seleccionó ningún proveedor.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objNotaEntrada.idProveedor = frmBusProveedor.objProveedor.idProveedor;
            txtProveedor.Text = frmBusProveedor.objProveedor.cNombre;
            idcliProveedor = frmBusProveedor.objProveedor.idCli;
        }

        bool lTieneMasDeDosDecimales(decimal d)
        {
            return (d * 10 - Math.Floor(d * 10) != 0);
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txt.Text != "")
            {
                string nNum = txt.Text;
                if (nNum[0] == '.')
                {
                    nNum = '0' + nNum;
                }
                if (lTieneMasDeDosDecimales(Convert.ToDecimal(nNum)) && e.KeyChar != (Char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Metodos

        private void cargarTotalDetalleNotaEntrada()
        {
            decimal nSubTotal = 0;
            foreach (DataGridViewRow item in dtgDetalleNotaEntrada.Rows)
            {
                nSubTotal = 0;
                clsDetalleNotaEntrada objDetNotaEntrada = (clsDetalleNotaEntrada)item.DataBoundItem;
                foreach (clsActivo item2 in objDetNotaEntrada.lstActivos)
                {
                    nSubTotal += item2.nValorActual;
                }
                objDetNotaEntrada.nSubTotal = nSubTotal;

            }
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

        private void CargarNuevaNotaEntrada()
        {
            if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                objNotaEntrada.lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();
                cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            }
            else if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 2)
            {
                cboAgencias.SelectedValue = objTransferencia.idAgenciaDes;
                cboAlmacen.SelectedValue = objTransferencia.idAlmacenDes;
                objNotaEntrada.lstDetalleNotaEntrada = new List<clsDetalleNotaEntrada>();

                List<clsActivo> lista = new clsCNAlmacen().CNObtenerActivosxTransferencia(objTransferencia.idTrasferencias);

                foreach (var objDetTransf in objTransferencia.lstDetTransf)
                {
                    objDetTransf.nCantidad = objDetTransf.nPorEntregar;
                    if (objDetTransf.nPorEntregar > 0M)
                    {
                        clsDetalleNotaEntrada objDetalleNotaEntrada = new clsDetalleNotaEntrada();
                        objDetalleNotaEntrada.lstActivos = lista.Where(x => x.idCatalogo == objDetTransf.idCatalogo).ToList();

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

            dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada;
            FormatoGridDetNotEntrada();
            CalcularTotalFinal();
        }

        private void IniForm()
        {
            LimpiarCpg();
            LimpiarControles();
            cboTipoIngresoNotEnt.SelectedIndex = -1;
            cboTipoIngresoNotEnt.Enabled = true;
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            grbCpg.Enabled = false;
            grbDatEntrada.Enabled = false;
            grbBienes.Enabled = false;
            grbDetalleActivos.Enabled = false;
            txtNumOC.Enabled = false;
            btnBusqOC.Enabled = false;
        }

        private bool ValidarControles()
        {
            if (cboTipoIngresoNotEnt.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de ingreso.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAlmacen.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacén donde ingresarán los productos.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumOC.Text) && Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {
                MessageBox.Show("Debe registrar una orden de compra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idcliProveedor == 0 && Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3)
            {
                MessageBox.Show("   Seleccione un Proveedor     ", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idCliProveedorComprobante == 0 && Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3 )
            {
                MessageBox.Show("Seleccione un Comprobante de Pago", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idCliProveedorComprobante != idcliProveedor && (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1 || Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3))
            {
                MessageBox.Show("El proveedor del comprobante de pago con el proveedor seleccionado no son los mismos, verificar.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1)
            {                     
                if (Convert.ToInt32(cboMonedaCpg.SelectedValue) != objOrdenCompra.idMoneda)
                {
                    MessageBox.Show("La moneda de la orden de compra con la moneda del comprobante no son iguales", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (dtgDetalleNotaEntrada.Rows.Count == 0)
            {
                MessageBox.Show("No se tiene listado ningun Item", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int[] nTipoIngNot = new int[3];
            nTipoIngNot[0] = 1;
            nTipoIngNot[1] = 4;
            nTipoIngNot[2] = 3;
            int nTipoIngresoNota = Convert.ToInt16(cboTipoIngresoNotEnt.SelectedValue);

            if (nTipoIngresoNota.In(nTipoIngNot))
            {
                List<clsDetalleNotaEntrada> lista = (List<clsDetalleNotaEntrada>)dtgDetalleNotaEntrada.DataSource;
                bool lBoolPrecio = true;
                bool lBoolCantidad = true;
                string cMsgPrecio = "El precio unitario de los siguientes items estan en 0 : \n";
                string cMsgCantid = "La cantidad de los siguientes items estan en 0 : \n";
                foreach (clsDetalleNotaEntrada item in lista)
                {
                    if (item.nPrecioUnitario == 0)
                    {
                        lBoolPrecio = false;
                        cMsgPrecio += "- " + item.cProducto + "\n";
                    }

                    if (item.nCantidad == 0)
                    {
                        lBoolCantidad = false;
                        cMsgCantid += "- " + item.cProducto + "\n";
                    }
                }

                if (!lBoolPrecio && Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1 || !lBoolPrecio && Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3)
                {
                    MessageBox.Show(cMsgPrecio, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!lBoolCantidad)
                {
                    MessageBox.Show(cMsgCantid, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                foreach (clsDetalleNotaEntrada item in lista)
                {
                    int nCont = 0;
                    foreach (clsDetalleNotaEntrada item2 in lista)
                    {
                        if (item.idCatalogo == item2.idCatalogo && item.nPrecioUnitario == item2.nPrecioUnitario)
                        {
                            nCont++;
                        }
                    }
                    if (nCont >= 2)
                    {
                        MessageBox.Show("No es válido el ingreso, el producto " + item.cProducto + " no puede ser registrado con el mismo precio", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            StringBuilder cMsje = new StringBuilder();

            if (nTipoIngresoNota.In(nTipoIngNot))
            {
                foreach (DataGridViewRow row in dtgDetalleNotaEntrada.Rows)
                {
                    clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)row.DataBoundItem;
                    if (objDetNE.idTipoBien == 1)
                    {
                        if (objDetNE.lstActivos.Count < objDetNE.nCantidad)
                        {
                            cMsje.Append("Ingrese el detalle de todo los productos " + objDetNE.cProducto + "\n");
                        }

                        if (objDetNE.lstActivos.Count > objDetNE.nCantidad)
                        {
                            cMsje.Append("Ha ingresado mas detalles del activo para el producto : " + objDetNE.cProducto + "\n");
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(cMsje.ToString().Trim()))
            {
                MessageBox.Show(cMsje.ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nTipoIngresoNota.In(nTipoIngNot) && (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 1 || Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3))
            {
                if (!string.IsNullOrEmpty(txtTotalCpg.Text) && !string.IsNullOrEmpty(txtTotalCpg.Text))
                {
                    if (Convert.ToDecimal(txtTotalCpg.Text) != Convert.ToDecimal(txtTotalNE.Text))
                    {
                        MessageBox.Show("El Monto total del comprobante no coincide con la suma de los bienes.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El Monto total del comprobante no coincide con la suma de los bienes.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void BuscarComprobante(int idCpg)
        {
            idCliProveedorComprobante = 0;
            DataTable dtComprPago = objCNCajaChica.BuscarComprPago(idCpg);
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

            DataTable dtValidaComrpobante = objCNCajaChica.CNValidarComprobanteNotaEntrada(idCpg);
            if (Convert.ToInt32(dtValidaComrpobante.Rows[0]["idResp"]) == 1)
            {
                MessageBox.Show(dtValidaComrpobante.Rows[0]["cmensaje"].ToString(), "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cSerieCpg = Convert.ToString(dtComprPago.Rows[0]["cSerie"]);
            cNumeroCpg = Convert.ToString(dtComprPago.Rows[0]["cNumero"]);
            txtNumCpg.Text = string.Format("{0} - {1}", cSerieCpg, cNumeroCpg);
            cboTipoComprobantePago.SelectedValue = Convert.ToInt16(dtComprPago.Rows[0]["idTipoComprobantePago"]);
            cboMonedaCpg.SelectedValue = Convert.ToInt16(dtComprPago.Rows[0]["idMoneda"]);
            txtTipCambio.Text = string.Format("{0:0.00}", Convert.ToDecimal(dtComprPago.Rows[0]["nTipCambio"]));
            chcCajaChica.Checked = Convert.ToBoolean(dtComprPago.Rows[0]["lCpgCajChica"]);
            txtTotalCpg.Text = string.Format("{0:0.00}", Convert.ToDecimal(dtComprPago.Rows[0]["nTotal"]));
            dtpFechaCpg.Value = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaEmision"]);
            idCliProveedorComprobante = Convert.ToInt32(dtComprPago.Rows[0]["idCliente"]);
            objNotaEntrada.idComprobantePago = Convert.ToInt32(dtComprPago.Rows[0]["idComprobantePago"]);
        }

        private void EnumerarLista()
        {
            int nNum = 1;
            foreach (var item in objNotaEntrada.lstDetalleNotaEntrada)
            {
                item.nNum = nNum++;
            }
        }

        private void FormatoGridDetNotEntrada()
        {
            dtgDetalleNotaEntrada.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNotaEntrada.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgDetalleNotaEntrada.Columns["nNum"].Visible = true;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].Visible = true;
            dtgDetalleNotaEntrada.Columns["cProducto"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nCantidad"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].Visible = true;
            dtgDetalleNotaEntrada.Columns["cUnidad"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].Visible = true;

            dtgDetalleNotaEntrada.Columns["nNum"].HeaderText = "N°";
            dtgDetalleNotaEntrada.Columns["idCatalogo"].HeaderText = "Cod. Prod.";
            dtgDetalleNotaEntrada.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleNotaEntrada.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].HeaderText = "Prec. Unitario";
            dtgDetalleNotaEntrada.Columns["cUnidad"].HeaderText = "Uni. Med.";
            dtgDetalleNotaEntrada.Columns["nSubTotal"].HeaderText = "SubTotal";

            dtgDetalleNotaEntrada.Columns["nNum"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["cProducto"].FillWeight = 40;
            dtgDetalleNotaEntrada.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["cUnidad"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].FillWeight = 10;

            dtgDetalleNotaEntrada.Columns["nNum"].DisplayIndex = 0;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleNotaEntrada.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleNotaEntrada.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetalleNotaEntrada.Columns["nCantidad"].DisplayIndex = 4;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DisplayIndex = 5;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].DisplayIndex = 6;

            dtgDetalleNotaEntrada.Columns["nCantidad"].DefaultCellStyle.Format = "#,0.00";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "#,0.00";
            dtgDetalleNotaEntrada.Columns["nSubTotal"].DefaultCellStyle.Format = "#,0.00";

            if (Convert.ToInt32(cboTipoIngresoNotEnt.SelectedValue) == 3)
            {
                dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].ReadOnly = false;
                dtgDetalleNotaEntrada.Columns["nCantidad"].ReadOnly = false;
            }
        }

        private void LimpiarCpg()
        {
            txtNumCpg.Text = string.Empty;
            cboTipoComprobantePago.SelectedIndex = -1;
            chcCajaChica.Checked = false;
            cboMonedaCpg.SelectedIndex = -1;
            txtTipCambio.Text = string.Empty;
            txtTotalCpg.Text = string.Empty;
            dtpFechaCpg.Value = clsVarGlobal.dFecSystem;
        }

        private void LimpiarControles()
        {
            txtProveedor.Text = string.Empty;
            dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            dtgDetActivos.DataSource = typeof(List<clsActivo>);
            txtTotalNE.Text = string.Empty;
            txtConvertido.Text = string.Empty;
            txtNumOC.Text = string.Empty;
            idcliProveedor = 0;
            btnParcialOC.Visible = false;
        }

        private void CalcularTotalFila()
        {
            clsDetalleNotaEntrada objDetNE = (clsDetalleNotaEntrada)dtgDetalleNotaEntrada.CurrentRow.DataBoundItem;
            dtgDetalleNotaEntrada.CurrentRow.Cells["nSubTotal"].Value = objDetNE.nCantidad * objDetNE.nPrecioUnitario;
        }

        private void CalcularTotalFinal()
        {
            decimal nSubTotal = 0.00M;
            decimal nTotal = 0.00M;
            foreach (DataGridViewRow row in dtgDetalleNotaEntrada.Rows)
            {
                nTotal += Convert.ToDecimal(row.Cells["nSubTotal"].Value);
            }

            txtSubTotal.Text = string.Format("{0:0.00}", nSubTotal);
            txtTotalNE.Text = nTotal.ToString();

            CalcularIGV();
            CalcularConvertido();
        }

        private void CalcularIGV()
        {
            if (chcIgv.Checked)
            {
                txtSubTotal.Text = Convert.ToString(Convert.ToDecimal(txtTotalNE.Text) / (1 + Convert.ToDecimal(clsVarApl.dicVarGen["nIGV"])));
                txtIgv.Text = Convert.ToString(Convert.ToDecimal(txtTotalNE.Text) - ((Convert.ToDecimal(txtTotalNE.Text) / (1 + Convert.ToDecimal(clsVarApl.dicVarGen["nIGV"])))));
            }
            else
            {
                txtSubTotal.Text = Convert.ToString(Convert.ToDecimal(txtTotalNE.Text));
                txtIgv.Text = "0.00";
            }
        }
        private void CalcularConvertido()
        {
            if (Convert.ToInt16(cboMonedaCpg.SelectedValue) == 2)
            {
                if (!string.IsNullOrEmpty(txtTotalNE.Text))
                {
                    decimal nTipCambio = string.IsNullOrEmpty(txtTipCambio.Text) ? 0 : Convert.ToDecimal(txtTipCambio.Text);
                    txtConvertido.Text = string.Format("{0:0.00}", Convert.ToString(Convert.ToDecimal(txtTotalNE.Text) * nTipCambio));
                }
            }
            else
            {
                txtConvertido.Text = string.Format("{0:0.00}", txtTotalNE.Text);
            }
        }

        #endregion


        private void txtNumOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(e.KeyChar) == 13)
            {
                BusOrdenCompra();
            }
        }
        private void btnBusqOC_Click(object sender, EventArgs e)
        {
            BusOrdenCompra();
        }
        private void BusOrdenCompra()
        {
            btnParcialOC.Visible = false;
            if (string.IsNullOrEmpty(txtNumOC.Text))
            {
                MessageBox.Show("Ingrese el número de orden de compra.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNumOC.Focus();
                return;
            }
            if (Convert.ToInt32(txtNumOC.Text) <= 0)
            {
                MessageBox.Show("Ingrese un número valido para la busqueda.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNumOC.Focus();
                return;
            }
            int idOrden = Convert.ToInt32(txtNumOC.Text);
            objOrdenCompra = new clsCNOrdenCompra().ListarOrdenesidOrden(idOrden);
            if (objOrdenCompra == null)
            {
                MessageBox.Show("No se encontró la orden de compra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNumOC.Focus();
                return;
            }

            if (objOrdenCompra.idEstadoLog == 11)
            {
                MessageBox.Show("La Orden de Compra fue Anulada", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNumOC.Focus();
                return;
            }

            DataTable dtRes = new clsCNOrdenCompra().CNExisteOrdenCompraNotaEntrada(idOrden);
            if (dtRes.Rows.Count > 0)
            {
                MessageBox.Show("La orden de compra esta vinculada a la Nota de Entrada : " + dtRes.Rows[0]["idNotaEntrada"].ToString() + ", el cual fue registrado por el usuario: " + dtRes.Rows[0]["cWinUser"].ToString() +".", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNumOC.Focus();
                return;
            }


            MapeaEntidadControl(objOrdenCompra);
            dtgDetalleNotaEntrada.ReadOnly = true;
            txtNumOC.Enabled = false;
            btnBusqOC.Enabled = false;
            btnMiniAgregar.Enabled = false;
            btnMiniQuitar.Enabled = false;
        }

        private void MapeaEntidadControl(clsOrdenCompra objOrdenCompra)
        {                       
            cboAgencias.SelectedValue = objOrdenCompra.idAgencia;
            cboAlmacen.SelectedValue = objOrdenCompra.idAlmacenEntrega;
            cboMonedaCpg.SelectedValue = objOrdenCompra.idMoneda;
            txtTipCambio.Text = string.Format("{0:0.0000}", objOrdenCompra.nTipoCambio);            
            txtProveedor.Text = objOrdenCompra.cProveedor;
            txtTotalCpg.Text = string.Format("{0:0.00}", objOrdenCompra.nMontoTotal);
            txtTotalNE.Text = string.Format("{0:0.00}", objOrdenCompra.nMontoTotal);
            txtConvertido.Text = string.Format("{0:0.00}", objOrdenCompra.nMonConvertido);
            txtSubTotal.Text = string.Format("{0:0.00}", objOrdenCompra.nSubTotal);
            txtIgv.Text = string.Format("{0:0.00}", objOrdenCompra.nMontoIGV);
            chcIgv.Checked = objOrdenCompra.lIncluIGV;
            idcliProveedor = objOrdenCompra.idCli;
            int idOrden = Convert.ToInt32(txtNumOC.Text);
            DataTable dtDetNotaEntrada = new clsCNOrdenCompra().CNListarDetalleOrden(idOrden, true);

            dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);

            decimal nTotal = 0;
            for (int i = 0; i < dtDetNotaEntrada.Rows.Count; i++)
            { 
                clsDetalleNotaEntrada objDetNE = new clsDetalleNotaEntrada();
                objDetNE.nNum =i;
                objDetNE.idTipoBien = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idTipoBien"]);
                objDetNE.idCatalogo = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idCatalogo"]);
                objDetNE.cProducto = dtDetNotaEntrada.Rows[i]["cProducto"].ToString();
                objDetNE.idUnidad = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idUnidad"]);
                objDetNE.cUnidad = dtDetNotaEntrada.Rows[i]["cDesTipoUniMed"].ToString();
                objDetNE.idNotaEntrada = 0;
                objDetNE.nCantidad = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nCantidad"]);
                objDetNE.nPrecioUnitario = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nPrecioUnitario"]);
                objDetNE.nSubTotal = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nSubTotal"]);
                nTotal += Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nSubTotal"]);
                objNotaEntrada.lstDetalleNotaEntrada.Add(objDetNE);
            }

            EnumerarLista();
            dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada.ToList();
            FormatoGridDetNotEntrada();
            
            dtgDetalleNotaEntrada.SelectionChanged += new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);

            btnParcialOC.Visible = true;


            if (nTotal != Convert.ToDecimal(txtTotalNE.Text))
            {
                txtTotalNE.Text = nTotal.ToString();
                if (objOrdenCompra.idMoneda == 2)
                    txtConvertido.Text = (nTotal * objOrdenCompra.nTipoCambio).ToString();
                else
                    txtConvertido.Text = (nTotal).ToString();

                CalcularIGV();

                txtSubTotal.Text = (nTotal - Convert.ToDecimal(txtIgv.Text)).ToString();
            }
        }

        private void chcIgv_CheckedChanged(object sender, EventArgs e)
        {
            CalcularIGV();
            CalcularConvertido();
        }

        private void btnParcialOC_Click(object sender, EventArgs e)
        {
            frmParcialOrdenCompra frmParcialOC = new frmParcialOrdenCompra(Convert.ToInt32(txtNumOC.Text));
            frmParcialOC.ShowDialog();
            DataTable dtDetNotaEntrada = frmParcialOC.dtCatalogo;

            objNotaEntrada.lstDetalleNotaEntrada.Clear();
            
            
            dtgDetalleNotaEntrada.SelectionChanged -= new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);
            decimal nTotal = 0, nTotalConvertido = 0;
            if (dtDetNotaEntrada != null)
            {
                for (int i = 0; i < dtDetNotaEntrada.Rows.Count; i++)
                {
                    clsDetalleNotaEntrada objDetNE = new clsDetalleNotaEntrada();
                    objDetNE.nNum = i;
                    objDetNE.idTipoBien = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idTipoBien"]);
                    objDetNE.idCatalogo = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idCatalogo"]);
                    objDetNE.cProducto = dtDetNotaEntrada.Rows[i]["cProducto"].ToString();
                    objDetNE.idUnidad = Convert.ToInt32(dtDetNotaEntrada.Rows[i]["idUnidad"]);
                    objDetNE.cUnidad = dtDetNotaEntrada.Rows[i]["cDesTipoUniMed"].ToString();
                    objDetNE.idNotaEntrada = 0;
                    objDetNE.nCantidad = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nCantidad"]);
                    objDetNE.nPrecioUnitario = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nPrecioUnitario"]);
                    objDetNE.nSubTotal = Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nSubTotal"]);
                    nTotal = nTotal + Convert.ToDecimal(dtDetNotaEntrada.Rows[i]["nSubTotal"]);
                    objNotaEntrada.lstDetalleNotaEntrada.Add(objDetNE);
                }
            }

            EnumerarLista();
            dtgDetalleNotaEntrada.DataSource = typeof(List<clsDetalleNotaEntrada>);
            dtgDetalleNotaEntrada.DataSource = objNotaEntrada.lstDetalleNotaEntrada.ToList();
            FormatoGridDetNotEntrada();

            dtgDetalleNotaEntrada.SelectionChanged += new EventHandler(dtgDetalleNotaEntrada_SelectionChanged);

            txtTotalNE.Text = nTotal.ToString();
            if (objOrdenCompra.idMoneda == 2)
                txtConvertido.Text = (nTotal * objOrdenCompra.nTipoCambio).ToString();
            else
                txtConvertido.Text = (nTotal).ToString();

            CalcularIGV();

            txtSubTotal.Text = (nTotal - Convert.ToDecimal(txtIgv.Text)).ToString();
        }   
    }
}
