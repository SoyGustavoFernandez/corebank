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
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using LOG.CapaNegocio;
using CAJ.Presentacion;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmOrdenCompra : frmBase
    {

        #region Variables Globales

        private const string cTituloMensajes = "Registro Orden de Compra";
        private clsOrdenCompra objOrdenCompra;
        int idcliProveedor;
        int nGrupo;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            IniForm();
            HabilitarControles(false);
            btnBusqOC.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnAddItem.Enabled = false;
            btnQuitarItem.Enabled = false;
            btnGrabar.Enabled = false;
            cboTipoPago.ListarTipPagOrdenCompra();
            txtNotaPedido.Enabled = false;
            txtIdProcAdq.Enabled = false;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
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
                if (objOrdenCompra.lstDetOrdenCompra.Where(x => x.idCatalogo == objCatalogo.idCatalogo).Count() > 0)
                {
                    nRepetidos++;
                }
                else
                {
                    clsDetalleOrdenCompra objDetOC = new clsDetalleOrdenCompra();
                    objDetOC.nNum = 0;
                    objDetOC.idCatalogo = objCatalogo.idCatalogo;
                    objDetOC.cProducto = objCatalogo.cProducto;
                    objDetOC.idUnidad = objCatalogo.idUnidadCompra;
                    objDetOC.cDesTipoUniMed = objCatalogo.cUnidCompra;
                    objDetOC.idNotaEntrada = 0;
                    objDetOC.nCantidad = 0;
                    objDetOC.nPrecioUnitario = 0;
                    objDetOC.nSubTotal = 0;

                    objOrdenCompra.lstDetOrdenCompra.Add(objDetOC);

                    EnumerarLista();

                    dtgDetalleOC.DataSource = typeof(List<clsDetalleOrdenCompra>);
                    dtgDetalleOC.DataSource = objOrdenCompra.lstDetOrdenCompra;
                }
            }

            if (nRepetidos > 0)
            {
                MessageBox.Show("Se encontraron item's repetidos, solo los item's no repetidos fueron agregados.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FormatoGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IniForm();

            HabilitarControles(true);
            btnBusqOC.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAddItem.Enabled = true;
            btnQuitarItem.Enabled = true;
            btnGrabar.Enabled = true;
            btnImprimir1.Enabled = false;
            btnAnular1.Visible = false;
            lblSustento.Visible = false;
            txtSustento.Visible = false;

            objOrdenCompra = new clsOrdenCompra();
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dtgDetalleOC.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Seleccione por lo menos un item.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsDetalleOrdenCompra objDetOC = (clsDetalleOrdenCompra)dtgDetalleOC.SelectedCells[0].OwningRow.DataBoundItem;
            objOrdenCompra.lstDetOrdenCompra.Remove(objDetOC);

            dtgDetalleOC.DataSource = typeof(List<clsDetalleOrdenCompra>);
            dtgDetalleOC.DataSource = objOrdenCompra.lstDetOrdenCompra;
            FormatoGrid();
            CalcularTotalFinal();
        }

        private void dtgDetalleOC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgDetalleOC.CurrentRow != null)
                {
                    if (dtgDetalleOC.Columns[e.ColumnIndex].Name.Equals("nCantidad") ||
                        dtgDetalleOC.Columns[e.ColumnIndex].Name.Equals("nPrecioUnitario"))
                        CalcularTotalFila();
                    CalcularTotalFinal();
                }
            }
        }

        private void dtgDetalleOC_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleOC.CurrentRow != null)
            {
                if (dtgDetalleOC.Columns[e.ColumnIndex].Name.Equals("nCantidad"))
                {
                    if (string.IsNullOrEmpty(dtgDetalleOC.CurrentRow.Cells["nCantidad"].EditedFormattedValue.ToString()))
                    {
                        dtgDetalleOC.EditingControl.Text = "0";
                        return;
                    }
                }

                if (dtgDetalleOC.Columns[e.ColumnIndex].Name.Equals("nPrecioUnitario"))
                {
                    if (string.IsNullOrEmpty(dtgDetalleOC.CurrentRow.Cells["nPrecioUnitario"].EditedFormattedValue.ToString()))
                    {
                        dtgDetalleOC.EditingControl.Text = "0";
                        return;
                    }
                }
            }
        }

        private void dtgDetalleOC_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        bool lTieneMasDeDosDecimales(decimal d)
        {
            return (d * 10 - Math.Floor(d * 10) != 0);
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
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

            if (txt.Text != "")
            {
                string nNum = txt.Text;
                if (nNum[0] == '.')
                {
                    nNum = '0'+nNum;
                }
                if (lTieneMasDeDosDecimales(Convert.ToDecimal(nNum)) && e.KeyChar != (Char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void chcIgv_CheckedChanged(object sender, EventArgs e)
        {
            CalcularIGV();
            CalcularConvertido();
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt16(cboAgencia.SelectedValue));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IniForm();
            HabilitarControles(false);
            btnBusqOC.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnAddItem.Enabled = false;
            btnQuitarItem.Enabled = false;
            btnGrabar.Enabled = false;
            btnImprimir1.Enabled = false;
            txtIdProcAdq.Text = "";
            txtNotaPedido.Text = "";
            rdoBtn3Nivel.Checked = false;
            rdoBtn4toNivel.Checked = false;
            txtSustento.Visible = false;
            lblSustento.Visible = false;
            btnAnular1.Visible = false;
            txtSustento.Enabled = true;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex >= 0)
            {
                CalcularConvertido();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            btnBusqOC.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnAddItem.Enabled = true;
            btnQuitarItem.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            objOrdenCompra.idEstadoLog = Convert.ToInt16(EstLog.EN_ADQUISICIÓN);
            objOrdenCompra.dFechaEmision = dtpFecEmision.Value;
            objOrdenCompra.dFechaReg = clsVarGlobal.dFecSystem.Date;
            objOrdenCompra.idUsuReg = clsVarGlobal.User.idUsuario;
            objOrdenCompra.idTipoOrden = Convert.ToInt16(cboTipoOrden.SelectedValue);
            objOrdenCompra.idTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue);
            objOrdenCompra.idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            objOrdenCompra.idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);
            objOrdenCompra.idAlmacenEntrega = Convert.ToInt16(cboAlmacen.SelectedValue);
            objOrdenCompra.nTipoCambio = txtTipCambio.nDecValor; 
            objOrdenCompra.cObservacion = txtObservacion.Text;
            objOrdenCompra.nSubTotal = txtSubTotal.nDecValor; 
            objOrdenCompra.nMontoIGV = txtIgv.nDecValor;
            objOrdenCompra.nMontoTotal = txtTotal.nDecValor;
            objOrdenCompra.nMonConvertido = txtConvertido.nDecValor;
            objOrdenCompra.cLugarEntrega = txtLugarEntrega.Text;
            objOrdenCompra.lIncluIGV = chcIgv.Checked;
            objOrdenCompra.idCli = idcliProveedor;
            objOrdenCompra.nGrupo = nGrupo;

            clsDBResp objDbResp = new clsCNOrdenCompra().InsertarOrden(objOrdenCompra);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje ,cTituloMensajes , MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumOC.Text = objDbResp.idGenerado.ToString();
                HabilitarControles(false);
                txtNumOC.Enabled = false;
                btnBusqOC.Enabled = false;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnAddItem.Enabled = false;
                btnQuitarItem.Enabled = false;
                btnGrabar.Enabled = false;
                dtgDetalleOC.ReadOnly = true;
                btnImprimir1.Enabled = true;
                lblSustento.Visible = true;
                txtSustento.Visible = true;
                btnAnular1.Visible = true;

                DataTable ListaDetOrdenComp = new clsCNOrdenCompra().CNListarDetalleOrden(objDbResp.idGenerado);
                DataTable ListaOrdenComp = new clsCNOrdenCompra().CNListaOrdenComp(objDbResp.idGenerado);
                DataTable ListaDatosEmp = new clsCNOrdenCompra().CNListaDatosEmp(Convert.ToInt32(cboAgencia.SelectedValue));
                int idOrden = objDbResp.idGenerado;
                int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);

                if (ListaDetOrdenComp.Rows.Count > 0)
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> listPar = new List<ReportParameter>();

                    listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                    listPar.Add(new ReportParameter("idOrden", idOrden.ToString(), false));
                    listPar.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));

                    string reportpath = "";

                    dtslist.Add(new ReportDataSource("dtsDetalleOrdenCompra", ListaDetOrdenComp));
                    dtslist.Add(new ReportDataSource("dtsListOrdenCompra", ListaOrdenComp));
                    dtslist.Add(new ReportDataSource("dtsListaDatosEmp", ListaDatosEmp));
                    reportpath = "rptOrdenCompra.rdlc";

                    new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay datos para el Reporte", "Reporte orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }     
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

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

        private void btnBusProveedor_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
            frmBusProveedor.ShowDialog();

            if (frmBusProveedor.objProveedor == null)
            {
                MessageBox.Show("No se seleccionó ningún proveedor.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objOrdenCompra.idProveedor = frmBusProveedor.objProveedor.idProveedor;
            txtProveedor.Text = frmBusProveedor.objProveedor.cNombre;
            idcliProveedor = frmBusProveedor.objProveedor.idCli;
            txtNotaPedido.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idOrden = Convert.ToInt32(txtNumOC.Text);
            DataTable ListaDetOrdenComp = new clsCNOrdenCompra().CNListarDetalleOrden(idOrden);
            DataTable ListaOrdenComp = new clsCNOrdenCompra().CNListaOrdenComp(idOrden);
            DataTable ListaDatosEmp = new clsCNOrdenCompra().CNListaDatosEmp(Convert.ToInt32(cboAgencia.SelectedValue));
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);

            if (ListaDetOrdenComp.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> listPar = new List<ReportParameter>();

                listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                listPar.Add(new ReportParameter("idOrden", idOrden.ToString(), false));
                listPar.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));

                string reportpath = "";

                dtslist.Add(new ReportDataSource("dtsDetalleOrdenCompra", ListaDetOrdenComp));
                dtslist.Add(new ReportDataSource("dtsListOrdenCompra", ListaOrdenComp));
                dtslist.Add(new ReportDataSource("dtsListaDatosEmp", ListaDatosEmp));
                reportpath = "rptOrdenCompra.rdlc";

                new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos para el Reporte", "Reporte orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void txtNotaPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtNotaPedido.Text.Trim()))
                {
                    MessageBox.Show("Ingrese Nº de Proceso de Adquisición correcto...", "Búsqueda de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idNotaPedido = Convert.ToInt32(txtNotaPedido.Text);
                clsCNOrdenCompra objOrde = new clsCNOrdenCompra();
                DataTable NotaPedido = objOrde.CNProveedorBuenaPro(idNotaPedido);
                if (NotaPedido.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro proceso o no tiene Buena Pro", "Búsqueda de Notas de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaPedido.Focus();
                    return;
                }
                /* --------------------------------------- *
                    cargando formulario de seleccion de grupo
                * --------------------------------------- */
                frmSeleccionaGrupoProceso frm = new frmSeleccionaGrupoProceso(NotaPedido);
                frm.ShowDialog();

                NotaPedido.Clear();
                NotaPedido = frm.obtenerDtDetalleBP();
                int idGrupo = Convert.ToInt32(NotaPedido.Rows[0]["nGrupo"]);
                string cGrupo = NotaPedido.Rows[0]["cDesGrupo"].ToString();
                nGrupo = idGrupo;
                DataTable OrdenCompraReg = objOrde.CNExisteOrdenCompraProceso(idNotaPedido, idGrupo);
                if (NotaPedido.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro proceso o no tiene Buena Pro", "Búsqueda de Notas de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaPedido.Focus();
                    return;
                }
                if (OrdenCompraReg.Rows.Count != 0)
                {
                    MessageBox.Show("El proceso Nro: " + idNotaPedido + " y el grupo: " + cGrupo + " ya esta registrado en la Orden de Compra Nro: " + OrdenCompraReg.Rows[0]["idOrden"].ToString(), "Búsqueda de Notas de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaPedido.Focus();
                    return;
                }

                //modificar el cambio
                objOrdenCompra.idProveedor = Convert.ToInt32(NotaPedido.Rows[0]["idProveedor"].ToString());
                txtProveedor.Text = NotaPedido.Rows[0]["cNombre"].ToString();
                idcliProveedor = Convert.ToInt32(NotaPedido.Rows[0]["idCliProveedor"].ToString());
                cboMoneda.SelectedValue = Convert.ToInt32(NotaPedido.Rows[0]["idMoneda"]);
                objOrdenCompra.idProceso = Convert.ToInt32(NotaPedido.Rows[0]["idProceso"]);
                objOrdenCompra.idTipoProceso = Convert.ToInt32(NotaPedido.Rows[0]["idTipoProceso"]);

                foreach (DataRow item in NotaPedido.Rows)
                {
                    clsDetalleOrdenCompra objDetOC = new clsDetalleOrdenCompra();
                    objDetOC.nNum = 0;
                    objDetOC.idCatalogo = Convert.ToInt32(item["idCatalogo"].ToString());
                    objDetOC.cProducto = item["cProducto"].ToString();
                    objDetOC.idUnidad = Convert.ToInt32(item["idUnidad"].ToString());
                    objDetOC.cDesTipoUniMed = item["cDesTipoUniMed"].ToString();
                    objDetOC.idNotaEntrada = 0;
                    objDetOC.nCantidad = Convert.ToDecimal(item["nCantidad"].ToString());
                    objDetOC.nPrecioUnitario = Convert.ToDecimal(item["nPrecioUnitario"].ToString());
                    objDetOC.nSubTotal = Convert.ToDecimal(item["nSubTotal"].ToString());

                    objOrdenCompra.lstDetOrdenCompra.Add(objDetOC);
                    EnumerarLista();
                }
                dtgDetalleOC.DataSource = objOrdenCompra.lstDetOrdenCompra.ToList();
                FormatoGrid(false);
                rdoBtn3Nivel.Click -= rdoBtn3Nivel_Click;
                rdoBtn4toNivel.Click -= rdoBtn4toNivel_Click;
                rdoBtn3Nivel.Enabled = false;
                rdoBtn4toNivel.Enabled = false;

                CalcularTotalFinal();

                cboMoneda.Enabled = false;
                txtNotaPedido.Enabled = false;
                btnBusProveedor.Enabled = false;
                btnAddItem.Enabled = false;
                btnQuitarItem.Enabled = false;

                
            }
        }        
        #endregion

        #region Metodos

        public frmOrdenCompra()
        {
            InitializeComponent();
        }

        private void BusOrdenCompra()
        {
            if (string.IsNullOrEmpty(txtNumOC.Text))
            {
                MessageBox.Show("Ingrese el número de orden de compra.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(txtNumOC.Text) <= 0)
            {
                MessageBox.Show("Ingrese un número valido para la busqueda.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idOrden = Convert.ToInt32(txtNumOC.Text);
            objOrdenCompra = new clsCNOrdenCompra().ListarOrdenesidOrden(idOrden);
            if (objOrdenCompra == null)
            {
                MessageBox.Show("No se encontró la orden de compra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (objOrdenCompra.idNotaEntrada == 0)
            {
                btnAnular1.Visible = true;
                txtSustento.Visible = true;
                lblSustento.Visible = true;
                if (objOrdenCompra.idEstadoLog == 11)
                {
                    txtSustento.Enabled = false;
                    btnAnular1.Enabled = false;
                }
                else
                {
                    txtSustento.Enabled = true;
                    btnAnular1.Enabled = true;
                }
            }
            else
            {
                btnAnular1.Visible = false;
                txtSustento.Visible = false;
                lblSustento.Visible = false;
            }

            objOrdenCompra.lstDetOrdenCompra = new clsCNOrdenCompra().ListarDetalleOrden(idOrden);

            MapeaEntidadControl(objOrdenCompra);
            dtgDetalleOC.ReadOnly = true;
            txtNumOC.Enabled = false;
            btnBusqOC.Enabled = false;
            btnImprimir1.Enabled = true;
        }

        private void MapeaEntidadControl(clsOrdenCompra objOrdenCompra)
        {
            dtpFecEmision.Value = objOrdenCompra.dFechaEmision;
            cboTipoOrden.SelectedValue = objOrdenCompra.idTipoOrden;
            cboTipoPago.SelectedValue = objOrdenCompra.idTipoPago;
            cboAgencia.SelectedValue = objOrdenCompra.idAgencia;
            cboAlmacen.SelectedValue = objOrdenCompra.idAlmacenEntrega;
            cboMoneda.SelectedValue = objOrdenCompra.idMoneda;
            txtTipCambio.Text = string.Format("{0:0.0000}", objOrdenCompra.nTipoCambio);
            txtLugarEntrega.Text = objOrdenCompra.cLugarEntrega;
            txtProveedor.Text = objOrdenCompra.cProveedor;
            txtObservacion.Text = objOrdenCompra.cObservacion;
            txtSubTotal.Text = string.Format("{0:#,0.00}", objOrdenCompra.nSubTotal);
            txtIgv.Text = string.Format("{0:#,0.00}", objOrdenCompra.nMontoIGV);
            txtTotal.Text = string.Format("{0:#,0.00}", objOrdenCompra.nMontoTotal);
            txtConvertido.Text = string.Format("{0:#,0.00}", objOrdenCompra.nMonConvertido);
            chcIgv.Checked = objOrdenCompra.lIncluIGV;
            txtSustento.Text = objOrdenCompra.cSustento;

            if (objOrdenCompra.idTipoProceso == 9)
            {
                txtIdProcAdq.Text = objOrdenCompra.idProceso.ToString();
            }
            else if (!string.IsNullOrEmpty(objOrdenCompra.idTipoProceso.ToString()))
            {
                txtNotaPedido.Text = objOrdenCompra.idProceso.ToString();
            }
            

            dtgDetalleOC.DataSource = typeof(List<clsOrdenCompra>);
            dtgDetalleOC.DataSource = objOrdenCompra.lstDetOrdenCompra;
            FormatoGrid();
        }

        private bool Validar()
        {
            if (cboTipoOrden.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de orden de compra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia donde se hará la entrega.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de pago de la orden de compra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAlmacen.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacén donde se guardaran los productos.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la moneda de la orden de compra.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt16(cboMoneda.SelectedValue) == 2)
            {
                if (string.IsNullOrEmpty(txtTipCambio.Text.Trim()))
                {
                    MessageBox.Show("Ingrese el tipo de cambio.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtLugarEntrega.Text.Trim()))
            {
                MessageBox.Show("Seleccione el lugar de entrega del producto.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtgDetalleOC.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese el detalle del la orden de compra.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            StringBuilder cMsje = new StringBuilder();
            foreach (DataGridViewRow row in dtgDetalleOC.Rows)
            {
                clsDetalleOrdenCompra objDetOC = (clsDetalleOrdenCompra)row.DataBoundItem;
                if (objDetOC.nCantidad == 0)
                {
                    cMsje.AppendLine(string.Format("Ingrese la cantidad del producto {0}", objDetOC.cProducto));
                }
            }

            if (!string.IsNullOrEmpty(cMsje.ToString().Trim()))
            {
                MessageBox.Show(cMsje.ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow row in dtgDetalleOC.Rows)
            {
                clsDetalleOrdenCompra objDetOC = (clsDetalleOrdenCompra)row.DataBoundItem;
                if (objDetOC.nPrecioUnitario == 0)
                {
                    cMsje.AppendLine(string.Format("Ingrese el precio unitario del producto {0}", objDetOC.cProducto));
                }
            }

            if (!string.IsNullOrEmpty(cMsje.ToString().Trim()))
            {
                MessageBox.Show(cMsje.ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text.Trim()))
            {
                MessageBox.Show("Se debe registrar el campo Observación.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (objOrdenCompra.idProveedor == 0)
            {
                MessageBox.Show("Seleccione el proveedor de la orden de compra.", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txtNumOC.Text = string.Empty;
            cboTipoOrden.SelectedIndex = -1;
            cboTipoPago.SelectedIndex = -1;
            cboAgencia.SelectedIndex = -1;
            cboAlmacen.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtLugarEntrega.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
            txtIgv.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtConvertido.Text = string.Empty;
            txtProveedor.Text = string.Empty;

            dtgDetalleOC.DataSource = typeof(List<clsDetalleOrdenCompra>);

            this.txtNotaPedido.Text = String.Empty;
        }

        private void FormatoGrid(bool lHabil = true)
        {
            dtgDetalleOC.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleOC.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgDetalleOC.Columns["nNum"].Visible = true;
            dtgDetalleOC.Columns["cProducto"].Visible = true;
            dtgDetalleOC.Columns["nCantidad"].Visible = true;
            dtgDetalleOC.Columns["nPrecioUnitario"].Visible = true;
            dtgDetalleOC.Columns["cDesTipoUniMed"].Visible = true;
            dtgDetalleOC.Columns["nSubTotal"].Visible = true;

            dtgDetalleOC.Columns["nNum"].HeaderText = "N°";
            dtgDetalleOC.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleOC.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleOC.Columns["nPrecioUnitario"].HeaderText = "Prec. Unitario";
            dtgDetalleOC.Columns["cDesTipoUniMed"].HeaderText = "Uni. Med.";
            dtgDetalleOC.Columns["nSubTotal"].HeaderText = "SubTotal";

            dtgDetalleOC.Columns["nNum"].DisplayIndex = 0;
            dtgDetalleOC.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleOC.Columns["cDesTipoUniMed"].DisplayIndex = 2;
            dtgDetalleOC.Columns["nCantidad"].DisplayIndex = 3;
            dtgDetalleOC.Columns["nPrecioUnitario"].DisplayIndex = 4;
            dtgDetalleOC.Columns["nSubTotal"].DisplayIndex = 5;

            dtgDetalleOC.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.##";
            dtgDetalleOC.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "##,##0.##";
            dtgDetalleOC.Columns["nSubTotal"].DefaultCellStyle.Format = "##,##0.##";

            if (lHabil)
            {
                dtgDetalleOC.Columns["nCantidad"].ReadOnly = false;
                dtgDetalleOC.Columns["nPrecioUnitario"].ReadOnly = false;
            }

            dtgDetalleOC.Columns["nNum"].FillWeight = 4;
            dtgDetalleOC.Columns["cProducto"].FillWeight = 50;
            dtgDetalleOC.Columns["cDesTipoUniMed"].FillWeight = 6;
            dtgDetalleOC.Columns["nCantidad"].FillWeight = 11;
            dtgDetalleOC.Columns["nPrecioUnitario"].FillWeight = 14;
            dtgDetalleOC.Columns["nSubTotal"].FillWeight = 15;
        }

        private void IniForm()
        {
            txtNumOC.Enabled = true;
            dtpFecEmision.Value = clsVarGlobal.dFecSystem;
            dtpFecEmision.Enabled = true;
            txtTipCambio.Text = string.Format("{0:0.0000}", Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]));
            nGrupo = 0;
            LimpiarControles();
        }

        private void EnumerarLista()
        {
            int nNum = 1;
            foreach (var item in objOrdenCompra.lstDetOrdenCompra)
            {
                item.nNum = nNum++;
            }
        }

        private void CalcularTotalFila()
        {
            clsDetalleOrdenCompra objDetOC = (clsDetalleOrdenCompra)dtgDetalleOC.CurrentRow.DataBoundItem;
            dtgDetalleOC.CurrentRow.Cells["nSubTotal"].Value = objDetOC.nCantidad * objDetOC.nPrecioUnitario;
        }

        private void CalcularTotalFinal()
        {
            decimal nSubTotal = 0.00M;
            decimal nTotal = 0.00M;
            foreach (DataGridViewRow row in dtgDetalleOC.Rows)
            {
                nTotal += Convert.ToDecimal(row.Cells["nSubTotal"].Value);
            }

            txtSubTotal.Text = string.Format("{0:0.00}", nSubTotal);
            txtTotal.Text = nTotal.ToString();

            CalcularIGV();
            CalcularConvertido();
        }

        private void CalcularConvertido()
        {
            if (Convert.ToInt16(cboMoneda.SelectedValue) == 2)
            {
                if (!string.IsNullOrEmpty(txtTotal.Text))
                {
                    decimal nTipCambio = string.IsNullOrEmpty(txtTipCambio.Text) ? 0 : Convert.ToDecimal(txtTipCambio.Text);
                    txtConvertido.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) * nTipCambio);
                }
            }
            else
            {
                txtConvertido.Text = txtTotal.Text;
            }
        }

        private void CalcularIGV()
        {
            if (chcIgv.Checked)
            {
                txtSubTotal.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) / (1 + Convert.ToDecimal(clsVarApl.dicVarGen["nIGV"]   )));
                txtIgv.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) - ((Convert.ToDecimal(txtTotal.Text) / (1 + Convert.ToDecimal(clsVarApl.dicVarGen["nIGV"])))));
            }
            else
            {
                txtSubTotal.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text));
                txtIgv.Text = "0.00";
            }
            
        }

        private void HabilitarControles(bool lHabilitar)
        {
            txtNumOC.Enabled = !lHabilitar;
            dtpFecEmision.Enabled = lHabilitar;
            cboTipoOrden.Enabled = lHabilitar;
            cboTipoPago.Enabled = lHabilitar;
            cboAgencia.Enabled = lHabilitar;
            cboAlmacen.Enabled = lHabilitar;
            cboMoneda.Enabled = lHabilitar;
            txtLugarEntrega.Enabled = lHabilitar;
            txtObservacion.Enabled = lHabilitar;
            chcIgv.Enabled = lHabilitar;
            btnBusProveedor.Enabled = lHabilitar;
            this.txtNotaPedido.Enabled = false;
            txtIdProcAdq.Enabled = false;
            txtIdProcAdq.Text = "";

            rdoBtn4toNivel.Enabled = lHabilitar;
            rdoBtn3Nivel.Enabled = lHabilitar;

            if (lHabilitar)
            {
                rdoBtn3Nivel.Click += rdoBtn3Nivel_Click;
                rdoBtn4toNivel.Click += rdoBtn4toNivel_Click;
            }
            else
            {
                rdoBtn3Nivel.Click -= rdoBtn3Nivel_Click;
                rdoBtn4toNivel.Click -= rdoBtn4toNivel_Click;
            }
        }

        private void HabilitarBotones(bool lHabilitar)
        {
            btnBusqOC.Enabled = !lHabilitar;
            btnNuevo.Enabled = !lHabilitar;
            btnAddItem.Enabled = lHabilitar;
            btnQuitarItem.Enabled = lHabilitar;
            btnEditar.Enabled = lHabilitar;
        }
     
        #endregion          

        private void rdoBtn4toNivel_Click(object sender, EventArgs e)
        {
            txtNotaPedido.Enabled = true;
            txtIdProcAdq.Enabled = false;
            rdoBtn3Nivel.Checked = false;
            txtNotaPedido.Text = "";
            txtIdProcAdq.Text = "";
            txtNotaPedido.Focus();
            rdoBtn3Nivel.Checked = false;
        }

        private void rdoBtn3Nivel_Click(object sender, EventArgs e)
        {
            txtNotaPedido.Enabled = false;
            txtIdProcAdq.Enabled = true;
            rdoBtn4toNivel.Checked = false;
            txtNotaPedido.Text = "";
            txtIdProcAdq.Text = "";
            txtIdProcAdq.Focus();
            rdoBtn4toNivel.Checked = false;
        }

        private void txtIdProcAdq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtIdProcAdq.Text.Trim()))
                {
                    MessageBox.Show("Ingrese Nº de Proceso de Adquisición correcto...", "Búsqueda de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idNotaPedido = Convert.ToInt32(txtIdProcAdq.Text);
                clsCNOrdenCompra objOrde = new clsCNOrdenCompra();
                DataTable NotaPedido = objOrde.CNProveedorBuenaPro3Nivel(idNotaPedido);
                if (NotaPedido.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro proceso o no tiene Buena Pro", "Búsqueda de Notas de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNotaPedido.Focus();
                    return;
                }
                /* --------------------------------------- *
                    cargando formulario de seleccion de grupo
                * --------------------------------------- */
                frmSeleccionaGrupoProceso frm = new frmSeleccionaGrupoProceso(NotaPedido);
                frm.ShowDialog();

                NotaPedido.Clear();
                NotaPedido = frm.obtenerDtDetalleBP();
                int idGrupo = Convert.ToInt32(NotaPedido.Rows[0]["nGrupo"]);
                string cGrupo = NotaPedido.Rows[0]["cDesGrupo"].ToString();
                objOrdenCompra.idProceso = Convert.ToInt32(NotaPedido.Rows[0]["idProceso"]);
                objOrdenCompra.idTipoProceso = Convert.ToInt32(NotaPedido.Rows[0]["idTipoProceso"]);
                nGrupo = idGrupo;
               
                //modificar el cambio
                objOrdenCompra.idProveedor = Convert.ToInt32(NotaPedido.Rows[0]["idProveedor"].ToString());
                txtProveedor.Text = NotaPedido.Rows[0]["cNombre"].ToString();
                idcliProveedor = Convert.ToInt32(NotaPedido.Rows[0]["idCliProveedor"].ToString());
                cboMoneda.SelectedValue = Convert.ToInt32(NotaPedido.Rows[0]["idMoneda"]);

                foreach (DataRow item in NotaPedido.Rows)
                {
                    clsDetalleOrdenCompra objDetOC = new clsDetalleOrdenCompra();
                    objDetOC.nNum = 0;
                    objDetOC.idCatalogo = Convert.ToInt32(item["idCatalogo"].ToString());
                    objDetOC.cProducto = item["cProducto"].ToString(); 
                    objDetOC.idUnidad = Convert.ToInt32(item["idUnidad"].ToString()); 
                    objDetOC.cDesTipoUniMed = item["cDesTipoUniMed"].ToString(); 
                    objDetOC.idNotaEntrada = 0;
                    objDetOC.nCantidad = Convert.ToDecimal(item["nCantidad"].ToString());
                    objDetOC.nPrecioUnitario = Convert.ToDecimal(item["nPrecioUnitario"].ToString());
                    objDetOC.nSubTotal = Convert.ToDecimal(item["nSubTotal"].ToString());

                    objOrdenCompra.lstDetOrdenCompra.Add(objDetOC);
                    EnumerarLista();
                }
                dtgDetalleOC.DataSource = objOrdenCompra.lstDetOrdenCompra.ToList();
                FormatoGrid(false);
                
                rdoBtn3Nivel.Click -= rdoBtn3Nivel_Click;
                rdoBtn4toNivel.Click -= rdoBtn4toNivel_Click;
                rdoBtn3Nivel.Enabled = false;
                rdoBtn4toNivel.Enabled = false;

                CalcularTotalFinal();

                chcIgv.Checked = Convert.ToBoolean(NotaPedido.Rows[0]["lIgv"]);

                cboMoneda.Enabled = false;
                txtNotaPedido.Enabled = false;
                btnBusProveedor.Enabled = false;
                btnAddItem.Enabled = false;
                btnQuitarItem.Enabled = false;
                txtIdProcAdq.Enabled = false;
            }
        }

        private void btnAnular1_Click(object sender, EventArgs e)
        {
            if (txtSustento.Text == "")
            {
                MessageBox.Show("Debe de registrar un sustento para anular la Orden de Compra", "Anular Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDBResp objDbResp = new clsCNOrdenCompra().CNAnularOrdenCompra(objOrdenCompra.idOrden, txtSustento.Text);
            if (objDbResp.nMsje == 1)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                BusOrdenCompra();
            }
            else{
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
