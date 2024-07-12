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
using GEN.Funciones;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using DEP.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRegistroVentas : frmBase
    {
        private string cNuevo = "N";
        clsCNCajaChica objCajaChica = new clsCNCajaChica();
        clsNumLetras objNumLetras = new clsNumLetras();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        DataTable dtRegVenta, dtDetRegVenta;
        DataTable dtConfigTipCompr;
        private decimal nPorcIGV = 0.00M;
        private int nidRegVenta = 0;
        int idCpgRef = 0;
        bool lModoEdic = false;
        int nTipoDocumento;
        Transaccion eoperacion = Transaccion.Selecciona;
        int idDestino = 0;
        clsCNComprobantes objCpg = new clsCNComprobantes();

        public frmRegistroVentas()
        {
            InitializeComponent();
            CargarCboDestinos();
            FiltrarTipoCpg();
        }

        private void frmRegistroVentas_Load(object sender, EventArgs e)
        {         
            lbRuc.Text="R.U.C. "+clsVarApl.dicVarGen["cRUC"];
            cboTipoComprobantePago.SelectedValue = 1;
            LimpiarCampos();
            dtRegVenta = null;
            dtDetRegVenta = null;
            dtRegVenta = new DataTable("dtRegVenta");
            dtDetRegVenta = new DataTable("dtDetRegVenta");
            CrearDataTables();
            dtgDetalleComprobante.DataSource = dtDetRegVenta;
            FormatoGridDetalle();
            DeshabilitarControles();
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;           
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBusqueda.Enabled = true;
            btnAnular.Enabled = false;
            btnAgregarDetalle.Enabled = false;
            btnQuitarDetalle.Enabled = false;
            btnMiniEditar.Enabled = false;
            btnBusqCodRef.Enabled = false;

            btnAnular.Enabled = false;
            btnAnular.Visible = true;
            btnExtorno1.Enabled = false;
            btnExtorno1.Visible = false;

            CargarComboModalidad();

            dFecRegistro.Value = clsVarGlobal.dFecSystem;
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
            
        }
        private void CargarComboModalidad()
        {
            //====================== Cargar Modalidad =================================>
            cboModalidad.SelectedIndexChanged -= new
            EventHandler(cboModalidad_SelectedIndexChanged);

            cboModalidad.DataSource = objCajaChica.CNListarModalidadPagoRegVentas(); 
            cboModalidad.ValueMember = "idModPagoAporteFondoSeg";
            cboModalidad.DisplayMember = "cModPagoAporteFondoSeg";

            cboModalidad.SelectedIndexChanged += new
            EventHandler(cboModalidad_SelectedIndexChanged);
            //========================================================================>
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBusRegVenta frmBusRegVenta = new frmBusRegVenta();
            frmBusRegVenta.ShowDialog();
            nidRegVenta = frmBusRegVenta.pidRegVenta;
            if (nidRegVenta == 0)
            {
                MessageBox.Show("No seleccionó ningun registro de venta.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarRegVenta(nidRegVenta);           
            DeshabilitarControles();
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnAnular.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            btnBusqueda.Enabled = false;
            btnAgregarDetalle.Enabled = false;
            btnQuitarDetalle.Enabled = false;
            btnMiniEditar.Enabled = false;
            btnBusqCodRef.Enabled = false;
            lModoEdic = false;

            if (Convert.ToInt32(dtRegVenta.Rows[0]["idEstado"]) == 2)
            {
                MessageBox.Show("El comprobante de Venta esta en estado PAGADO", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEditar.Enabled = false;
                btnExtorno1.Visible = true;
                btnExtorno1.Enabled = true;
                btnAnular.Enabled = false;
                btnAnular.Visible = false;
                return;
            }
            else 
            {
                btnExtorno1.Visible = false;
                btnExtorno1.Enabled = false;
                btnAnular.Enabled = true;
                btnAnular.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtRegVenta = null;
            dtDetRegVenta = null;
            dtRegVenta = new DataTable("dtRegVenta");
            dtDetRegVenta = new DataTable("dtDetRegVenta");

            LimpiarCampos();
            CrearDataTables();

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Maestro 
            //=======================================================================
            DataRow dr = dtRegVenta.NewRow();
            dr["idComprobante"] = 0;
            dr["idEstado"] = 1;            
            dr["dFechaEmision"] = clsVarApl.dicVarGen["dFechaAct"];
            dr["idUsuarioEmi"] = clsVarGlobal.User.idUsuario;
            dr["nSubTotal"] = 0.00;
            dr["nMontoIGV"] = 0.00;
            dr["nTotal"] = 0.00;
            dr["idAgencia"] = clsVarGlobal.nIdAgencia;
            dr["nMontoDetraccion"] = 0.00;
            dtRegVenta.Rows.Add(dr);

            txtCodigo.Text = "0";

            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetRegVenta;
            FormatoGridDetalle();

            HabilitarNuevo();
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnBusqueda.Enabled = false;            
            btnAgregarDetalle.Enabled = true;
            btnQuitarDetalle.Enabled = true;
            btnMiniEditar.Enabled = true;
            btnBusqCodRef.Enabled = false;
            lModoEdic = false;

            btnAnular.Enabled = false;
            btnAnular.Visible = true;
            btnExtorno1.Enabled = false;
            btnExtorno1.Visible = false;

            cboModalidad.Enabled = false;
            cboModalidad.SelectedValue = 0;
            eoperacion = Transaccion.Nuevo;
            cNuevo = "N";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            AsignarDatosGrabar();
            //=======================================================================
            //--Crear los DataSet y agregar los Datatables para los xml
            //=======================================================================
            DataSet dsRegVenta = new DataSet("dsRegVenta");
            DataSet dsDetRegVenta = new DataSet("dsDetRegVenta");

            dtRegVenta.TableName = "dtRegVenta";
            dtDetRegVenta.TableName = "dtDetRegVenta";

            dsRegVenta.Tables.Add(dtRegVenta);
            dsDetRegVenta.Tables.Add(dtDetRegVenta);

            string xmlRegVenta = clsCNFormatoXML.EncodingXML(dsRegVenta.GetXml());
            string xmlDetRegVenta = clsCNFormatoXML.EncodingXML(dsDetRegVenta.GetXml());

            dsRegVenta.Tables.Clear();
            dsDetRegVenta.Tables.Clear();

            //============= Valida el inicio y cierre de operaciones para el pago de reg de Ventas =============================================

            if (Convert.ToInt32(dtRegVenta.Rows[0]["idEstado"]) == 2)
            {
                if (Convert.ToInt32(cboModalidad.SelectedValue) == 1) //valida inicio de operacion solo para pago en efectivo
                {
                    if (this.ValidarInicioOpe() != "A")
                    {
                        this.Dispose();
                        return;
                    }
                }               
            }   
               
            //======================================  Registro Inicio Rastreo ===================================================================
            this.registrarRastreo(0, Convert.ToInt32(txtCodigo.Text), "Inicio - Emisión de Comprobantes", btnGrabar);
            //===================================================================================================================================

            /*=========================      REALIZA MONITOREO DE SALDOS   ==========================*/
            decimal nMonOpe = Convert.ToDecimal(txtTotal.Text);

            //if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)//CUANDO SE PAGA EL APORTE EN EFECTIVO
            //{
            //    if (ActualizarSaldo(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda.SelectedValue), 1, nMonOpe))
            //    {
            //        return;
            //    }
            //}

            /*==========================     FIN MONITOREO DE SALDOS    ===============================*/
            
            DataTable result = objCajaChica.GuardarRegVenta(xmlRegVenta, xmlDetRegVenta, idCpgRef, dFecRegistro.Value.Date, clsVarGlobal.nIdAgencia);
            
            //===========================================  Registro Fin Rastreo  ================================================================
            this.registrarRastreo(0, Convert.ToInt32(result.Rows[0]["nNroRegistro"].ToString()), "Fin - Emisión de Comprobantes", btnGrabar);
            //===================================================================================================================================



            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString() + "NRO REGISTRO: " + result.Rows[0]["nNroRegistro"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarRegVenta(Convert.ToInt32(result.Rows[0]["nNroRegistro"].ToString()));
                DeshabilitarControles();
                btnNuevo.Enabled = true;

                if (Convert.ToInt32(dtRegVenta.Rows[0]["idEstado"]) == 2)
                {
                    btnEditar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnAnular.Visible = false;
                    btnExtorno1.Enabled = true;
                    btnExtorno1.Visible = true;
                }
                else
                {
                    btnEditar.Enabled = true;
                    btnAnular.Enabled = true;
                    btnAnular.Visible = true;
                    btnExtorno1.Enabled = false;
                    btnExtorno1.Visible = false;
                }                
                
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnBusqueda.Enabled = false;
                btnAgregarDetalle.Enabled = false;
                btnQuitarDetalle.Enabled = false;
                btnMiniEditar.Enabled = false;
                btnBusqCodRef.Enabled = false;
                lModoEdic = false;
                eoperacion = Transaccion.Selecciona;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cNuevo = "N";
        }        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarEdicion();
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnBusqueda.Enabled = false;
            btnAnular.Enabled = false;
            btnAgregarDetalle.Enabled = false;
            btnQuitarDetalle.Enabled = false;
            btnMiniEditar.Enabled = true;
            btnBusqCodRef.Enabled = false;
            lModoEdic = false;
            cboModalidad.Enabled = false;
            if (Convert.ToInt32(cboModalidad.SelectedValue)==3)
            {
                grbCheque.Enabled = true;
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)
            {
                grbInterbancario.Enabled = true;
            }
            eoperacion = Transaccion.Edita;
            if (chcDetrac.Checked)
            {
                grbCompSUNAT.Enabled = true;  
                txtCompSunat.Enabled = true;               
            }
            cboModalidad.Enabled = true;
            cNuevo = "E";
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro(a) de anular este comprobante de pago?", "Registro de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            frmAnulRegVenta frmAnulRegVenta = new frmAnulRegVenta();
            frmAnulRegVenta.ShowDialog();

            if (!frmAnulRegVenta.lFlagAceptar)
            {
                MessageBox.Show("Anulacion cancelada, Intente nuevamente.", "Anular Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtRegVenta.Rows[0]["dFechaEli"] = clsVarGlobal.dFecSystem;
            dtRegVenta.Rows[0]["idUsuarioEli"] = clsVarGlobal.User.idUsuario;
            dtRegVenta.Rows[0]["idMotivoEli"] = frmAnulRegVenta.idMotAnul;
            dtRegVenta.Rows[0]["cMotivoEli"] = frmAnulRegVenta.cMotAnul;
            dtRegVenta.Rows[0]["idEstado"] = 3;

            dtRegVenta.TableName = "dtRegVenta";
            dtDetRegVenta.TableName = "dtDetRegVenta";

            DataSet dsRegVenta = new DataSet("dsRegVenta");
            DataSet dsDetRegVenta = new DataSet("dsDetRegVenta");

            dsRegVenta.Tables.Add(dtRegVenta);
            dsDetRegVenta.Tables.Add(dtDetRegVenta);

            string xmlRegVenta = clsCNFormatoXML.EncodingXML(dsRegVenta.GetXml());
            string xmlDetRegVenta = clsCNFormatoXML.EncodingXML(dsDetRegVenta.GetXml());

            dsRegVenta.Tables.Clear();
            dsDetRegVenta.Tables.Clear();

            DataTable result = objCajaChica.GuardarRegVenta(xmlRegVenta, xmlDetRegVenta,idCpgRef, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeshabilitarControles();
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnBusqueda.Enabled = true;
                btnAnular.Enabled = false;
                btnAgregarDetalle.Enabled = false;
                btnQuitarDetalle.Enabled = false;
                btnMiniEditar.Enabled = false;
                btnBusqCodRef.Enabled = false;
                lModoEdic = false;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DeshabilitarControles();
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBusqueda.Enabled = true;
            btnAnular.Enabled = false;

            btnExtorno1.Enabled = false;
            btnExtorno1.Visible = false;

            btnAgregarDetalle.Enabled = false;
            btnQuitarDetalle.Enabled = false;
            btnMiniEditar.Enabled = false;
            btnBusqCodRef.Enabled = false;
            lModoEdic = false;
            eoperacion = Transaccion.Selecciona;
            cNuevo = "N";
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoComprobantePago.SelectedIndex) == -1)
            {
                MessageBox.Show("Seleccione el tipo de comprobante.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(cboDestino.SelectedIndex) == -1)
            {
                MessageBox.Show("Seleccione el destino.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAgregDetRegVentas frmAgDetRegVent = new frmAgregDetRegVentas();
            frmAgDetRegVent.ShowDialog();
            if (frmAgDetRegVent.pidSubConcepto == 0) return;        

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Detalle
            //=======================================================================
            DataRow dr = dtDetRegVenta.NewRow();
            dr["idDetRegVenta"] = -1;
            dr["nNumeroItem"] = dtgDetalleComprobante.Rows.Count + 1;
            dr["idConcepto"] = frmAgDetRegVent.pidSubConcepto;
            dr["idAgencia"] = frmAgDetRegVent.pidAgencia;
            dr["cDescripcion"] = frmAgDetRegVent.pcSubConcpeto;
            dr["nCantidad"] = frmAgDetRegVent.pnCantidad;
            dr["nPreUnitario"] = frmAgDetRegVent.pnPrecUnit;
            dr["nTotalItem"] = frmAgDetRegVent.pnCantidad * frmAgDetRegVent.pnPrecUnit;
            dr["lVigente"] = 1;
            dtDetRegVenta.Rows.Add(dr);
            CalcularTotal();
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleComprobante.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleComprobante.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetalleComprobante.Rows[nFilaActual].Cells["idDetRegVenta"].Value) == -1)
                {
                    dtgDetalleComprobante.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetalleComprobante.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetalleComprobante.Focus();
                ProcessTabKey(true);
                ReprocesarNroItem();
                CalcularTotal();
            }
        }

        private void btnMiniEditar_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleComprobante.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAgregDetRegVentas frmAgDetRegVent = new frmAgregDetRegVentas();
            frmAgDetRegVent.eoperacion = this.eoperacion;
            frmAgDetRegVent.pidAgencia = Convert.ToInt32(dtgDetalleComprobante.CurrentRow.Cells["cboAgencia"].Value);
            frmAgDetRegVent.pidSubConcepto = Convert.ToInt32(dtgDetalleComprobante.CurrentRow.Cells["idConcepto"].Value);
            frmAgDetRegVent.pnCantidad = Convert.ToDecimal(dtgDetalleComprobante.CurrentRow.Cells["nCantidad"].Value);
            frmAgDetRegVent.pnPrecUnit = Convert.ToDecimal(dtgDetalleComprobante.CurrentRow.Cells["nPreUnitario"].Value);
            frmAgDetRegVent.pcSubConcpeto = dtgDetalleComprobante.CurrentRow.Cells["cDescripcion"].Value.ToString();
            if (lModoEdic) frmAgDetRegVent.HabilitarEdicionConcepto();
            frmAgDetRegVent.ShowDialog();
            if (frmAgDetRegVent.pidSubConcepto == 0) return;

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Detalle
            //=======================================================================

            dtgDetalleComprobante.CurrentRow.Cells["cboAgencia"].Value = frmAgDetRegVent.pidAgencia;
            dtgDetalleComprobante.CurrentRow.Cells["idConcepto"].Value = frmAgDetRegVent.pidSubConcepto;
            dtgDetalleComprobante.CurrentRow.Cells["cDescripcion"].Value = frmAgDetRegVent.pcSubConcpeto;
            dtgDetalleComprobante.CurrentRow.Cells["nCantidad"].Value = frmAgDetRegVent.pnCantidad;
            dtgDetalleComprobante.CurrentRow.Cells["nPreUnitario"].Value = frmAgDetRegVent.pnPrecUnit;
            dtgDetalleComprobante.CurrentRow.Cells["nTotalItem"].Value = frmAgDetRegVent.pnCantidad * frmAgDetRegVent.pnPrecUnit;
            CalcularTotal();
        }        

        private void chcCliente_CheckedChanged(object sender, EventArgs e)
        {
            conBusCliente.txtCodAge.Clear();
            conBusCliente.txtCodInst.Clear();
            conBusCliente.txtCodCli.Clear();
            conBusCliente.txtNroDoc.Clear();
            conBusCliente.txtNombre.Clear();
            conBusCliente.txtDireccion.Clear();
            txtNroDocNoCli.Clear();
            txtNomNoCli.Clear();
            txtDireccionNoCli.Clear();
            grbNoCliente.Visible = chcCliente.Checked;
            conBusCliente.Visible = !chcCliente.Checked;
            conBusCliente.txtCodCli.Enabled = conBusCliente.Visible;
        }

        private void cboTipPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipPersona.SelectedIndex == -1)
            {
                return;
            }
            if (Convert.ToUInt16(cboTipPersona.SelectedValue) == 1)
            {
                txtNroDocNoCli.Text = "";
                txtNroDocNoCli.MaxLength = 8;
                this.cboTipDocumento.CargarDocumentos("N");
                this.cboTipDocumento.SelectedValue = 1;
                this.cboTipDocumento.Enabled = false;                
            }
            else 
            {
                this.cboTipDocumento.CargarDocumentos("J");
                this.cboTipDocumento.SelectedValue = 4;
                this.cboTipDocumento.Enabled = false;  
                txtNroDocNoCli.Text = "";
                txtNroDocNoCli.MaxLength = 11;                
            }
            chcCliente.Enabled = true;
            conBusCliente.Enabled = true;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);


                    lblCambio.Visible = true;
                    txtCambio.Visible = true;                    
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
                if (!string.IsNullOrEmpty(txtTotal.Text)) ConverNumLetras(Convert.ToDecimal(txtTotal.Text));
            }
            else
            {
                lblCambio.Visible = false;
                txtCambio.Visible = false;
                txtCambio.Text = "";
            }
        }

        private void cboTipoComprobantePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoComprobantePago.SelectedIndex == -1) return;
            lbTipoDoc.Text = cboTipoComprobantePago.Text.Trim();
//            int idTipoCompr = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);

            DataTable dtListaSerieNro = objCpg.CNListaSerieNroRegVentas(Convert.ToInt32(cboTipoComprobantePago.SelectedValue));
            txtSerie.Text = dtListaSerieNro.Rows[0]["cSerie"].ToString();
            txtNumero.Text = dtListaSerieNro.Rows[0]["cNumero"].ToString();

            int idTipoCompr = 2;
            dtConfigTipCompr = objCajaChica.RetConfigTipoComp(idTipoCompr);
            if (dtConfigTipCompr.Rows.Count > 0)
            {
                nPorcIGV = Convert.ToDecimal(dtConfigTipCompr.Rows[0]["nValIgv"]);
                if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lPermiteDocRef"]))
                {
                    btnBusqCodRef.Enabled = true;
                }
                else
                {
                    btnBusqCodRef.Enabled = false;
                }
            }
//            if (Convert.ToInt32(cboTipoComprobantePago.SelectedValue) == 2)//factura
            if (idTipoCompr == 2)//factura
            {
                cboDestino.SelectedValue = 0;
                cboDestino.Enabled = true;
                chcDetrac.Enabled = true;
            }
            else
            {
                cboDestino.SelectedValue = 3;
                cboDestino.Enabled = false;
                chcDetrac.Enabled = false;
            }
            CalcularTotal();
        }

        private void CrearDataTables()
        {
            dtRegVenta.Columns.Add("idComprobante", typeof(Int32));
            dtRegVenta.Columns.Add("idCliente", typeof(Int32));
            dtRegVenta.Columns.Add("idTipoComprobante", typeof(Int32));
            dtRegVenta.Columns.Add("idMoneda", typeof(Int32));
            dtRegVenta.Columns.Add("idDestino", typeof(Int32));
            dtRegVenta.Columns.Add("idTipPersona", typeof(Int32));
            dtRegVenta.Columns.Add("idEstado", typeof(Int32));
            dtRegVenta.Columns.Add("nTipCambio", typeof(decimal));
            dtRegVenta.Columns.Add("dFechaEmision", typeof(DateTime));
            dtRegVenta.Columns.Add("idUsuarioEmi", typeof(Int32));
            dtRegVenta.Columns.Add("dFechaPago", typeof(DateTime));
            dtRegVenta.Columns.Add("idUsuarioPago", typeof(Int32));
            dtRegVenta.Columns.Add("dFechaEli", typeof(DateTime));
            dtRegVenta.Columns.Add("idUsuarioEli", typeof(Int32));
            dtRegVenta.Columns.Add("idMotivoEli", typeof(Int32));
            dtRegVenta.Columns.Add("cMotivoEli", typeof(string));
            dtRegVenta.Columns.Add("nPorcIGV", typeof(decimal));
            dtRegVenta.Columns.Add("nSubTotal", typeof(decimal));
            dtRegVenta.Columns.Add("nMontoIGV", typeof(decimal));
            dtRegVenta.Columns.Add("nTotal", typeof(decimal));
            dtRegVenta.Columns.Add("cMontoLetras", typeof(string));
            dtRegVenta.Columns.Add("cGlosa", typeof(string));
            dtRegVenta.Columns.Add("idAgencia", typeof(Int32));
            dtRegVenta.Columns.Add("cDocumento", typeof(string));
            dtRegVenta.Columns.Add("cNombre", typeof(string));
            dtRegVenta.Columns.Add("cDireccion", typeof(string));

            dtRegVenta.Columns.Add("nMontoDetraccion", typeof(decimal));
            dtRegVenta.Columns.Add("nCompDetraccion", typeof(string));
            dtRegVenta.Columns.Add("idTipoDocumento", typeof(Int32)); 
            
            dtRegVenta.Columns.Add("idModalidadPag", typeof(Int32));  
            dtRegVenta.Columns.Add("idEntidadFIPag", typeof(Int32));  
            dtRegVenta.Columns.Add("idCtaInstitucionPag", typeof(Int32));  
            dtRegVenta.Columns.Add("nNroCtaInstPag", typeof(string));  
            dtRegVenta.Columns.Add("cSeriePag", typeof(string ));  
            dtRegVenta.Columns.Add("nNroDocumentoPag", typeof(string));  

            dtDetRegVenta.Columns.Add("idDetRegVenta", typeof(Int32));
            dtDetRegVenta.Columns.Add("idComprobante", typeof(Int32));
            dtDetRegVenta.Columns.Add("nNumeroItem", typeof(Int32));
            dtDetRegVenta.Columns.Add("idConcepto", typeof(Int32));
            dtDetRegVenta.Columns.Add("idAgencia", typeof(Int32));
            dtDetRegVenta.Columns.Add("cDescripcion", typeof(string));
            dtDetRegVenta.Columns.Add("nCantidad", typeof(decimal));
            dtDetRegVenta.Columns.Add("nPreUnitario", typeof(decimal));
            dtDetRegVenta.Columns.Add("nTotalItem", typeof(decimal));
            dtDetRegVenta.Columns.Add("lVigente", typeof(bool));
            dtDetRegVenta.Columns.Add("idDestino", typeof(Int32));

            if (!dtgDetalleComprobante.Columns.Contains("cboAgencia"))
            {
                clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
                DataTable dtAgencia = ListadoAgencia.ListarAgencias();
                //=======================================================================
                //--Agregar Colummna de tipo combobox
                //=======================================================================
                DataGridViewComboBoxColumn cboAgencia = new DataGridViewComboBoxColumn();
                cboAgencia.Name = "cboAgencia";
                cboAgencia.DataPropertyName = "idAgencia";
                cboAgencia.DataSource = dtAgencia;
                cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
                cboAgencia.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
                this.dtgDetalleComprobante.Columns.Add(cboAgencia);
            }
        }

        private void AsignarDatosGrabar()
        {
            dtRegVenta.Rows[0]["idComprobante"] = txtCodigo.Text;
            if (!chcCliente.Checked)
            {
                dtRegVenta.Rows[0]["idCliente"] = conBusCliente.txtCodCli.Text;
                if (!string.IsNullOrEmpty(conBusCliente.nidTipoDocumento))
	            {
		            dtRegVenta.Rows[0]["idTipoDocumento"] = Convert.ToInt32(conBusCliente.nidTipoDocumento);
	            }
               
            }
            else
            {
                dtRegVenta.Rows[0]["idCliente"] = 0;
                dtRegVenta.Rows[0]["cDocumento"] = txtNroDocNoCli.Text;
                dtRegVenta.Rows[0]["cNombre"] = txtNomNoCli.Text;
                dtRegVenta.Rows[0]["cDireccion"] = txtDireccionNoCli.Text;
                dtRegVenta.Rows[0]["idTipoDocumento"] = cboTipDocumento.SelectedValue;
            }

            dtRegVenta.Rows[0]["idTipoComprobante"] = cboTipoComprobantePago.SelectedValue;
            dtRegVenta.Rows[0]["idMoneda"] = cboMoneda.SelectedValue;
            dtRegVenta.Rows[0]["idDestino"] = cboDestino.SelectedValue;
            dtRegVenta.Rows[0]["idTipPersona"] = cboTipPersona.SelectedValue;
            dtRegVenta.Rows[0]["dFechaEmision"] = dtpFechaEmision.Value.Date;


            if (chcPago.Checked)
            {
                dtRegVenta.Rows[0]["dFechaPago"] = dtpFecPago.Value.Date;
                dtRegVenta.Rows[0]["idUsuarioPago"] = clsVarGlobal.User.idUsuario;
                dtRegVenta.Rows[0]["idEstado"] = 2;
            }

            if (nPorcIGV > 0)
            {
                dtRegVenta.Rows[0]["nPorcIGV"] = nPorcIGV;
            }
            dtRegVenta.Rows[0]["nSubTotal"] = txtSubTotal.Text;
            dtRegVenta.Rows[0]["nMontoIGV"] = txtIgv.Text;
            dtRegVenta.Rows[0]["nTotal"] = txtTotal.Text;
            dtRegVenta.Rows[0]["cMontoLetras"] = txtMonLetras.Text;
            dtRegVenta.Rows[0]["cGlosa"] = txtGlosa.Text; 
            dtRegVenta.Rows[0]["idModalidadPag"] = cboModalidad.SelectedValue.ToString();
            //PAGO CON CHEQUE
            if (Convert.ToInt32(cboModalidad.SelectedValue)==3)
            {
              
                dtRegVenta.Rows[0]["idEntidadFIPag"] = cboEntidad1.SelectedValue.ToString();               
                dtRegVenta.Rows[0]["nNroCtaInstPag"] = txtNroCuentaCheq.Text;
                dtRegVenta.Rows[0]["cSeriePag"] = txtNroSerieCheq.Text;
                dtRegVenta.Rows[0]["nNroDocumentoPag"] = txtNroDocumentoCheq.Text;
            }  //PAGO CON INTERBANCARIO
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)
            {
                dtRegVenta.Rows[0]["idEntidadFIPag"] = cboEntidad2.SelectedValue.ToString();
                dtRegVenta.Rows[0]["idCtaInstitucionPag"] = cboCuenta.SelectedValue.ToString();
                dtRegVenta.Rows[0]["nNroCtaInstPag"] = cboCuenta.Text;
                dtRegVenta.Rows[0]["cSeriePag"] = txtNroSerieInt.Text;
                dtRegVenta.Rows[0]["nNroDocumentoPag"] = txtNroDocInt.Text;
            }

            if (chcDetrac.Checked)
            {
                dtRegVenta.Rows[0]["nMontoDetraccion"] = txtNumDetracc.Text;
                dtRegVenta.Rows[0]["nCompDetraccion"] = txtCompSunat.Text;
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue)==0)
            {
                 dtRegVenta.Rows[0]["idModalidadPag"] = 8;
            }

            idCpgRef = !(string.IsNullOrEmpty(txtCodRef.Text)) ? Convert.ToInt32(txtCodRef.Text) : 0;

            if (Convert.ToInt32(cboDestino.SelectedValue) > 0)
            {
                dtDetRegVenta.Rows[0]["idDestino"] = Convert.ToInt32(cboDestino.SelectedValue);    
            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) > 1)
            {
                dtRegVenta.Rows[0]["nTipCambio"] = txtCambio.Text;
            }
        }

        private void CalcularTotal()
        {
            decimal nSubtotal = 0.00M;
            decimal nIgv = 0.00M;
            decimal nDetracc = 0.00M;
            decimal nTotal = 0.00M;

            DataTable dtDestinos = (DataTable)cboDestino.DataSource;
            if (!(string.IsNullOrEmpty(txtNumDetracc.Text)))
            {
                nDetracc = Convert.ToDecimal(txtNumDetracc.Text);   
            }            

            bool lAfectaIGV = false;
            if (cboDestino.SelectedIndex != -1)
            {
                lAfectaIGV = Convert.ToBoolean(dtDestinos.Rows[cboDestino.SelectedIndex]["lAplIgv"]);
            }

            foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
            {
                //nSubtotal += Convert.ToDecimal(row.Cells["nTotalItem"].Value); 
                nTotal += Convert.ToDecimal(row.Cells["nTotalItem"].Value); 
            }
            
            if (lAfectaIGV)
            {
                //nIgv = (nSubtotal * nPorcIGV)/ 100.00M;
                nSubtotal = Math.Round(nTotal / ((100.00M + nPorcIGV) / 100.00M),2);
                nIgv = nTotal - nSubtotal;
               
                if (chcDetrac.Checked)
                {
                    nTotal = nSubtotal + nIgv - nDetracc;
                }
                else
                {
                    nTotal = nSubtotal + nIgv;
                }
            }
            else
            {
                //nTotal = nSubtotal;
                nSubtotal = nTotal;
                nIgv = 0.00M;

                if (chcDetrac.Checked)
                {
                    nTotal = nSubtotal - nDetracc;
                }
                //else
                //{
                //    nTotal = nSubtotal;
                //}
            }
 
            txtSubTotal.Text = nSubtotal.ToString("##,##0.00");
            txtIgv.Text = nIgv.ToString("##,##0.00"); 
            txtTotal.Text = nTotal.ToString("##,##0.00");

            txtNumDetracc.Text = nDetracc.ToString("##,##0.00");

            ConverNumLetras(Convert.ToDecimal(nTotal));
        }

        private void HabilitarNuevo()
        {
            cboTipoComprobantePago.Enabled = true;
            cboMoneda.Enabled = true;
            dtpFechaEmision.Enabled = true;
            txtCambio.Enabled = false;
            txtCodigo.Enabled = false;
            cboDestino.Enabled = true;
            cboTipPersona.Enabled = true;
            conBusCliente.Enabled = false;
            conBusCliente.txtCodAge.Enabled = false;
            conBusCliente.txtCodInst.Enabled = false;
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.txtNroDoc.Enabled = false;
            conBusCliente.txtNombre.Enabled = false;
            conBusCliente.txtDireccion.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = true;
            txtSerie.Enabled = false;
            txtNumero.Enabled = false;
            txtEstado.Enabled = false;
            chcCliente.Enabled = false;
            txtMonLetras.Enabled = false;
            chcPago.Enabled = true;
            dtpFecPago.Enabled = false;
            txtGlosa.Enabled = true;
            txtSubTotal.Enabled = false;
            txtIgv.Enabled = false;
            txtTotal.Enabled = false;
            txtCodRef.Enabled = false;

            grbCompSUNAT.Visible = false;
            lblBase8.Visible = false;
            txtCompSunat.Visible = false;            
        }

        private void HabilitarEdicion()
        {
            cboTipoComprobantePago.Enabled = false;
            cboMoneda.Enabled = false;
            dtpFechaEmision.Enabled = true;
            txtCambio.Enabled = false;
            txtCodigo.Enabled = false;
            cboTipPersona.Enabled = true;
            conBusCliente.txtCodAge.Enabled = false;
            conBusCliente.txtCodInst.Enabled = false;
            chcCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.txtNroDoc.Enabled = false;
            conBusCliente.txtNombre.Enabled = false;
            conBusCliente.txtDireccion.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = true;
            txtNroDocNoCli.Enabled = true;
            txtNomNoCli.Enabled = true;
            txtDireccionNoCli.Enabled = true;
            txtSerie.Enabled = false;
            txtNumero.Enabled = false;
            txtEstado.Enabled = false;
            txtMonLetras.Enabled = false;
            chcPago.Enabled = true;            
            dtpFecPago.Enabled = chcPago.Checked;
            txtGlosa.Enabled = true;
            txtSubTotal.Enabled = false;
            txtIgv.Enabled = false;
            txtTotal.Enabled = false;
            txtCodRef.Enabled = false;
            chcDetrac.Enabled = true;

            if (dtRegVenta.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtRegVenta.Rows[0]["idDestino"]).In(1, 2))
                {
                    cboDestino.Enabled = true;
                }
                else
                {
                    cboDestino.Enabled = false;
                }
            }
        }

        private void DeshabilitarControles()
        {
            cboTipoComprobantePago.Enabled = false;
            cboMoneda.Enabled = false;
            dtpFechaEmision.Enabled = false;
            txtCambio.Enabled = false;
            txtCodigo.Enabled = false;
            cboDestino.Enabled = false;
            cboTipPersona.Enabled = false;
            conBusCliente.txtCodAge.Enabled = false;
            conBusCliente.txtCodInst.Enabled = false;
            conBusCliente.txtCodCli.Enabled = false;
            conBusCliente.txtNroDoc.Enabled = false;
            conBusCliente.txtNombre.Enabled = false;
            conBusCliente.txtDireccion.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = false;
            txtSerie.Enabled = false;
            txtNumero.Enabled = false;
            txtEstado.Enabled = false;
            chcCliente.Enabled = false;
            txtMonLetras.Enabled = false;
            chcPago.Enabled = false;
            dtpFecPago.Enabled = false;
            txtGlosa.Enabled = false;
            txtSubTotal.Enabled = false;
            txtIgv.Enabled = false;
            txtTotal.Enabled = false;
            txtCodRef.Enabled = false;

            chcDetrac.Enabled = false;
            grbCompSUNAT.Enabled = false;
            lblBase8.Enabled = false;
            txtCompSunat.Enabled = false;
            txtNumDetracc.Enabled = false;
            grbInterbancario.Enabled = false;
            grbCheque.Enabled = false;
           
            cboModalidad.Enabled = false;       
        }

        private void LimpiarCampos()
        {
            cboTipoComprobantePago.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
            txtCambio.Clear();
            txtCodigo.Clear();
            cboDestino.SelectedIndex = -1;
            cboTipPersona.SelectedIndex = -1;
            conBusCliente.txtCodAge.Clear();
            conBusCliente.txtCodInst.Clear();
            conBusCliente.txtCodCli.Clear();
            conBusCliente.txtNroDoc.Clear();
            conBusCliente.txtNombre.Clear();
            conBusCliente.txtDireccion.Clear();
            lbTipoDoc.Text = "";
            txtSerie.Clear();
            txtNumero.Clear();
            txtEstado.Clear();
            chcCliente.Checked = false;
            txtMonLetras.Clear();
            chcPago.Checked = false;
            dtpFecPago.Value = clsVarGlobal.dFecSystem;
            txtGlosa.Clear();
            txtSubTotal.Clear();
            txtIgv.Clear();
            txtTotal.Clear();
            txtCodRef.Clear();
            if (dtgDetalleComprobante.DataSource != null) ((DataTable)dtgDetalleComprobante.DataSource).Rows.Clear();
            chcDetrac.Checked = false;
            txtNumDetracc.Clear();
            txtCompSunat.Clear();

            txtNroDocInt.Clear();
            txtNroCuentaCheq.Clear();
            txtNroSerieInt.Clear();
            txtNroSerieCheq.Clear();
            cboTipoEntidad.SelectedIndex = -1;
            cboEntidad1.SelectedIndex = -1;
            cboEntidad2.SelectedIndex = -1;
            cboCuenta.SelectedIndex = -1;
            cboModalidad.SelectedIndex = -1;
        }

        private void CargarCboDestinos()
        {
            DataTable Destinos = objCajaChica.ListarTipoOperacionVenta();
            cboDestino.DataSource = Destinos;
            cboDestino.ValueMember = "idTipoOperacionVenta";
            cboDestino.DisplayMember = "cDescripcion";
        }

        private void FormatoGridDetalle()
        {
            dtgDetalleComprobante.Columns["idDetRegVenta"].Visible = false;
            dtgDetalleComprobante.Columns["idComprobante"].Visible = false;
            dtgDetalleComprobante.Columns["nNumeroItem"].Visible = true;
            dtgDetalleComprobante.Columns["idConcepto"].Visible = false;
            //dtgDetalleComprobante.Columns["idAgencia"].Visible = false;
            dtgDetalleComprobante.Columns["cDescripcion"].Visible = true;
            dtgDetalleComprobante.Columns["nCantidad"].Visible = true;
            dtgDetalleComprobante.Columns["nPreUnitario"].Visible = true;
            dtgDetalleComprobante.Columns["nTotalItem"].Visible = true;
            dtgDetalleComprobante.Columns["lVigente"].Visible = false;
            dtgDetalleComprobante.Columns["idDestino"].Visible = false;

            dtgDetalleComprobante.Columns["nNumeroItem"].HeaderText = "N° Item";
            dtgDetalleComprobante.Columns["cDescripcion"].HeaderText = "Concepto";
            dtgDetalleComprobante.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleComprobante.Columns["nPreUnitario"].HeaderText = "Prec. Unit.";
            dtgDetalleComprobante.Columns["nTotalItem"].HeaderText = "Total";
            dtgDetalleComprobante.Columns["cboAgencia"].HeaderText = "Agencia";

            dtgDetalleComprobante.Columns["cDescripcion"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nPreUnitario"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nTotalItem"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleComprobante.Columns["nNumeroItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDetalleComprobante.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nPreUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nTotalItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetalleComprobante.Columns["nNumeroItem"].FillWeight = 30;
            dtgDetalleComprobante.Columns["cDescripcion"].FillWeight = 200;
            dtgDetalleComprobante.Columns["nCantidad"].FillWeight = 60;
            dtgDetalleComprobante.Columns["nPreUnitario"].FillWeight = 60;
            dtgDetalleComprobante.Columns["nTotalItem"].FillWeight = 60;
            dtgDetalleComprobante.Columns["cboAgencia"].FillWeight = 60;

            dtgDetalleComprobante.Columns["nNumeroItem"].DisplayIndex = 0;
            dtgDetalleComprobante.Columns["cDescripcion"].DisplayIndex = 1;
            dtgDetalleComprobante.Columns["cboAgencia"].DisplayIndex = 2;
            dtgDetalleComprobante.Columns["nCantidad"].DisplayIndex = 3;
            dtgDetalleComprobante.Columns["nPreUnitario"].DisplayIndex = 4;
            dtgDetalleComprobante.Columns["nTotalItem"].DisplayIndex = 5;

            foreach (DataGridViewColumn column in dtgDetalleComprobante.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ConverNumLetras(decimal nMontoTotal)
        {
            objNumLetras.LetraCapital = true;
            objNumLetras.MascaraSalidaDecimal = "/100 " + cboMoneda.Text;
            objNumLetras.SeparadorDecimalSalida = "con";
            objNumLetras.Decimales = 2;
            txtMonLetras.Text = objNumLetras.ToCustomCardinal(nMontoTotal);
        }

        private bool Validar()
        {
            if (cboTipoComprobantePago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de comprobante para el Registro de Venta.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoComprobantePago.Focus();
                return false;
            }
            if (cboMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la moneda para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMoneda.Focus();
                return false;
            }
            if (cboDestino.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el destino para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDestino.Focus();
                return false;
            }
            if (cboTipPersona.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de persona para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipPersona.Focus();
                return false;
            }
            if (conBusCliente.Visible && (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text) || string.IsNullOrEmpty(conBusCliente.txtNroDoc.Text)))
            {
                MessageBox.Show("Seleccione el cliente para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCliente.txtCodCli.Focus();
                return false;
            }
            if (grbNoCliente.Visible && (string.IsNullOrEmpty(txtNroDocNoCli.Text) || string.IsNullOrEmpty(txtNomNoCli.Text) || string.IsNullOrEmpty(txtDireccionNoCli.Text)))
            {
                MessageBox.Show("Ingrese los datos de la persona a la cual se emitira el comprobante.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroDocNoCli.Focus();
                return false;
            }

            if (dtgDetalleComprobante.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese por lo menos un detalle para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtgDetalleComprobante.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGlosa.Text))
            {
                MessageBox.Show("Ingrese la glosa para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGlosa.Focus();
                return false;
            }
            if (btnBusqCodRef.Enabled && string.IsNullOrEmpty(txtCodRef.Text))
            {
                MessageBox.Show("Seleccione el documento de referencia para el Registro de Ventas.", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBusqCodRef.Focus();
                return false;
            }
            if (chcDetrac.Checked && string.IsNullOrEmpty(txtCompSunat.Text) && chcPago.Checked)
            {
                MessageBox.Show("Debe ingresar el comprobante del Pago de Detraccion SUNAT", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompSunat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboModalidad.Text))
            {
                MessageBox.Show("Debe elegir la modalidad de pago", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModalidad.Focus();
                return false;
            }

            if (chcPago.Checked && Convert.ToInt32(cboModalidad.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe elegir la modalidad de pago", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModalidad.Focus();
                return false;
            }
            DataTable dtListaSerieNro = objCpg.CNListaSerieNroRegVentas(Convert.ToInt32(cboTipoComprobantePago.SelectedValue));
            if (dtListaSerieNro.Rows.Count > 0 && !chcPago.Checked)
            {
                if (cNuevo == "N")
                {
                    if (dtListaSerieNro.Rows[0]["cSerie"].ToString() != txtSerie.Text)
                    {
                        MessageBox.Show("La serie mostrada varió con el numero serie actual", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (dtListaSerieNro.Rows[0]["cNumero"].ToString() != txtNumero.Text)
                    {
                        MessageBox.Show("El nro de comprobante mostrado varió con el nro comprobante actual verifique...", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }                
                
            }

            // ADICIONAR TIPOS DE PAGO

            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1 && Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            //{
            //    if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariSoles"]))
            //    {
            //        MessageBox.Show("Debe Seleccionar un Tipo de Cobro <> Efectivo..." + "\r\n" + "Monto límite de Bancarización: " +"S/. "+ clsVarApl.dicVarGen["nMontoBancariSoles"], "Validar Cobro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return true;
            //    }
            //}

            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1 && Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            //{
            //    if (Convert.ToDecimal(txtTotal.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariDolares"]))
            //    {
            //        MessageBox.Show("Debe Seleccionar un Tipo de Cobro <> Efectivo..." + "\r\n" + "Monto límite de Bancarización: " + "$ " + clsVarApl.dicVarGen["nMontoBancariDolares"], "Validar Cobro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return true;
            //    }
            //}
            return true;
        }

        private void BuscarRegVenta(int idCpg)
        {
            LimpiarCampos();

            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtRegVenta = null;
            dtDetRegVenta = null;
            dtRegVenta = new DataTable("dtRegVenta");
            dtDetRegVenta = new DataTable("dtDetRegVenta");

            //=======================================================================
            //--Buscar Datos del maestro y detalle 
            //=======================================================================
            dtRegVenta = objCajaChica.BuscarRegVenta(idCpg);
            dtDetRegVenta = objCajaChica.BuscarDetRegVenta(idCpg);
            dtDetRegVenta.DefaultView.RowFilter = ("lVigente <> 0");

            foreach (DataColumn column in dtRegVenta.Columns)
            {
                column.ReadOnly = false;
            }

            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            cboTipPersona.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idTipPersona"]);

            if (Convert.ToInt32(dtRegVenta.Rows[0]["idCliente"]) > 0)
            {
                chcCliente.Checked = false;
                DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(dtRegVenta.Rows[0]["idCliente"].ToString()));
                conBusCliente.txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                conBusCliente.txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                conBusCliente.txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);
                conBusCliente.txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                conBusCliente.txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
                conBusCliente.txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                conBusCliente.txtCodCli.Enabled = false;
               
            }
            else
            {
                chcCliente.Checked = true;
                txtNroDocNoCli.Text = dtRegVenta.Rows[0]["cDocumento"].ToString();
                txtNomNoCli.Text = dtRegVenta.Rows[0]["cNombre"].ToString();
                txtDireccionNoCli.Text = dtRegVenta.Rows[0]["cDireccion"].ToString();
                txtNroDocNoCli.Enabled = false;
                txtNomNoCli.Enabled = false;
                txtDireccionNoCli.Enabled = false;                
            }
            cboTipDocumento.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idTipoDocumento"]);
            txtCodigo.Text = dtRegVenta.Rows[0]["idComprobante"].ToString();
            DataTable dtEstados = objCajaChica.ListarEstadosCpg();
            txtEstado.Text = dtEstados.Select("idEstadoComprobante = " + dtRegVenta.Rows[0]["idEstado"].ToString()).First()["cDescripcion"].ToString();                 
            cboTipoComprobantePago.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idTipoComprobante"]);
            txtSerie.Text = dtRegVenta.Rows[0]["cSerie"].ToString();
            txtNumero.Text = dtRegVenta.Rows[0]["cNumero"].ToString();   
            cboMoneda.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idMoneda"]) ;
            dtpFechaEmision.Value = Convert.ToDateTime(dtRegVenta.Rows[0]["dFechaEmision"]);
            
            if(Convert.ToInt32(dtRegVenta.Rows[0]["idMoneda"])==2)
            {
                txtCambio.Text = dtRegVenta.Rows[0]["nTipCambio"].ToString();
            }

            cboDestino.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idDestino"]) ;            

            if (!string.IsNullOrEmpty(Convert.ToString(dtRegVenta.Rows[0]["dFechaPago"])))
            {
                chcPago.CheckedChanged -= new EventHandler(chcPago_CheckedChanged);
                chcPago.Checked = true;
                dtpFecPago.Value = Convert.ToDateTime(dtRegVenta.Rows[0]["dFechaPago"]);
                chcPago.CheckedChanged += new EventHandler(chcPago_CheckedChanged);
            }

            if (!string.IsNullOrEmpty(dtRegVenta.Rows[0]["nPorcIGV"].ToString()))
            {
                nPorcIGV = Convert.ToDecimal(dtRegVenta.Rows[0]["nPorcIGV"]);
            }

            txtGlosa.Text = dtRegVenta.Rows[0]["cGlosa"].ToString();
            
            if (!string.IsNullOrEmpty(dtRegVenta.Rows[0]["IdCpgReferencia"].ToString()))
            {
                txtCodRef.Text = dtRegVenta.Rows[0]["IdCpgReferencia"].ToString();
            }

            if (!string.IsNullOrEmpty(dtRegVenta.Rows[0]["nMontoDetraccion"].ToString()) || !string.IsNullOrEmpty(dtRegVenta.Rows[0]["nCompDetraccion"].ToString()) || Convert.ToInt32(dtRegVenta.Rows[0]["nMontoDetraccion"])!= 0)
            {
                if (Convert.ToInt32(dtRegVenta.Rows[0]["nMontoDetraccion"]) != 0)
                {
                    chcDetrac.CheckedChanged -= new EventHandler(chcBase1_CheckedChanged);
                    chcDetrac.Checked = true;
                    grbCompSUNAT.Visible = true;
                    lblBase8.Visible = true;
                    txtCompSunat.Visible = true;
                    txtNumDetracc.Text = dtRegVenta.Rows[0]["nMontoDetraccion"].ToString();
                    txtCompSunat.Text = dtRegVenta.Rows[0]["nCompDetraccion"].ToString();

                    chcDetrac.CheckedChanged += new EventHandler(chcBase1_CheckedChanged);
                }
            }
            cboModalidad.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idModalidadPag"]);
            if (Convert.ToInt32(dtRegVenta.Rows[0]["idModalidadPag"])==3) //PAGO CON CHEQUE
            {
                grbInterbancario.Visible = false;
                grbCheque.Visible = true;
                cboTipoEntidad.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idTipoEntidad"]);                
                cboEntidad1.SelectedValue=Convert.ToInt32(dtRegVenta.Rows[0]["idEntidadFIPag"]);
                txtNroCuentaCheq.Text = dtRegVenta.Rows[0]["nNroCtaInstPag"].ToString();
                txtNroSerieCheq.Text  = dtRegVenta.Rows[0]["cSeriePag"].ToString() ;
                txtNroDocumentoCheq.Text = dtRegVenta.Rows[0]["nNroDocumentoPag"].ToString();
            }
            if (Convert.ToInt32(dtRegVenta.Rows[0]["idModalidadPag"]) == 4)//PAGO CON INTERBANCARIO
            {
                grbInterbancario.Visible = true;
                grbCheque.Visible = false ;
                cboEntidad2.SelectedValue = Convert.ToInt32(dtRegVenta.Rows[0]["idEntidadFIPag"].ToString());
                cboCuenta.SelectedValue=Convert.ToInt32(dtRegVenta.Rows[0]["idCtaInstitucionPag"].ToString());
                txtNroSerieInt.Text = dtRegVenta.Rows[0]["cSeriePag"].ToString();
                txtNroDocInt.Text= dtRegVenta.Rows[0]["nNroDocumentoPag"].ToString() ;
            }


           
         

            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetRegVenta;
            FormatoGridDetalle();
            //CalcularTotal();
            txtSubTotal.Text = Convert.ToDecimal(dtRegVenta.Rows[0]["nSubTotal"]).ToString("##,##0.00");
            txtIgv.Text = Convert.ToDecimal(dtRegVenta.Rows[0]["nMontoIGV"]).ToString("##,##0.00");
            txtTotal.Text = Convert.ToDecimal(dtRegVenta.Rows[0]["nTotal"]).ToString("##,##0.00");
            txtNumDetracc.Text = Convert.ToDecimal(dtRegVenta.Rows[0]["nMontoDetraccion"]).ToString("##,##0.00");

            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            conBusCliente.btnBusCliente.Enabled = false;
            cboDestino.Enabled = false;
            dtgDetalleComprobante.Enabled = false;
            idDestino = Convert.ToInt32(dtRegVenta.Rows[0]["idDestino"]);
                   
        }

        private void ReprocesarNroItem()
        {
            int i = 1;
            foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
            {
                if (Convert.ToBoolean(row.Cells["lVigente"].Value))
                {
                    row.Cells["nNumeroItem"].Value = i;
                    i++;
                }
            }
        }

        private void FiltrarTipoCpg()
        {
           DataView dv = new DataView((DataTable)cboTipoComprobantePago.DataSource);
           dv.RowFilter = "lPermRegVenta = 1";
           cboTipoComprobantePago.DataSource = dv.ToTable();
        }

        private void chcPago_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFecPago.Value = clsVarGlobal.dFecSystem;
            dtpFecPago.Enabled = chcPago.Checked;
            if (chcPago.Checked)
            {
                cboModalidad.Enabled = true;
            }
            else
            {
                cboModalidad.Enabled = false;
            }
        }

        private void btnBusqCodRef_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBusRegVenta frmBusRegVenta = new frmBusRegVenta();
            frmBusRegVenta.ShowDialog();
            nidRegVenta = frmBusRegVenta.pidRegVenta;
            if (nidRegVenta == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtCodRef.Text = nidRegVenta.ToString();
        }

        private void cboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDestino.SelectedIndex == -1) return;

            if (this.dtRegVenta != null)
            {
                if (dtRegVenta.Rows.Count > 0)
                {
                    if (eoperacion == Transaccion.Edita)
                    {
                        var idDestinoNew = Convert.ToInt32(cboDestino.SelectedValue);
                        if (idDestinoNew == 3 && idDestino.In(1, 2))
                        {
                            MessageBox.Show("Destino ya tiene afectación de IGV no puede editar a SIN IGV", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboDestino.SelectedValue = idDestino;
                        }
                    }
                }
            }

            CalcularTotal();
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {         
            grbCompSUNAT.Visible = chcDetrac.Checked;
            lblBase8.Visible = chcDetrac.Checked;
            txtCompSunat.Visible = chcDetrac.Checked;
            txtNumDetracc.Enabled = chcDetrac.Checked;
            grbCompSUNAT.Enabled = chcDetrac.Checked;
            lblBase8.Enabled = chcDetrac.Checked;
            txtCompSunat.Enabled = chcDetrac.Checked;

            if (!chcDetrac.Checked)
            {
                txtCompSunat.Text = "";
                txtNumDetracc.Text = "";
                CalcularTotal();
            }
        }        

        private void txtNumDetracc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalcularTotal();
            }  
        }

        private void cboTipDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNroDocNoCli.Text = "";            
        }

        private void chcIGV_CheckedChanged(object sender, EventArgs e)
        {
            if (chcIGV.Checked)
            {
                txtIgv.Enabled = true;
            }
            else
            {
                txtIgv.Enabled = false;
                CalcularTotal();
            }
        }

        private void txtIgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalcularTotalIgv();
            }  
        }
        private void CalcularTotalIgv()
        {
            if (chcIGV.Checked)
            {            
                decimal nSubtotal = 0.00M;
                decimal nIgv = 0.00M;
                decimal nDetracc = 0.00M;
                decimal nTotal = 0.00M;

                DataTable dtDestinos = (DataTable)cboDestino.DataSource;
                if (!(string.IsNullOrEmpty(txtNumDetracc.Text)))
                {
                    nDetracc = Convert.ToDecimal(txtNumDetracc.Text);
                }

                bool lAfectaIGV = false;
                if (cboDestino.SelectedIndex != -1)
                {
                    lAfectaIGV = Convert.ToBoolean(dtDestinos.Rows[cboDestino.SelectedIndex]["lAplIgv"]);
                }

                foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
                {
                    //nSubtotal += Convert.ToDecimal(row.Cells["nTotalItem"].Value);
                    nTotal += Convert.ToDecimal(row.Cells["nTotalItem"].Value);
                }            

                if (lAfectaIGV)
                {
                    //nIgv = Convert.ToDecimal(txtIgv.Text);

                    nIgv += Convert.ToDecimal(txtIgv.Text);
                    nSubtotal = nTotal - nIgv;

                    if (chcDetrac.Checked)
                    {
                        nTotal = nSubtotal + nIgv - nDetracc;
                    }
                    else
                    {
                        nTotal = nSubtotal + nIgv;
                    }
                }
                else
                {
                    //nTotal = nSubtotal;
                    nSubtotal = nTotal;
                    nIgv = 0.00M;

                    if (chcDetrac.Checked)
                    {
                        nTotal = nSubtotal - nDetracc;
                    }
                    //else
                    //{
                    //    nTotal = nSubtotal;
                    //}
                }

                txtSubTotal.Text = nSubtotal.ToString("##,##0.00");
                txtIgv.Text = nIgv.ToString("##,##0.00");
                txtTotal.Text = nTotal.ToString("##,##0.00");

                txtNumDetracc.Text = nDetracc.ToString("##,##0.00");

                ConverNumLetras(Convert.ToDecimal(nTotal));
            }            
        }

        private void txtIgv_Leave(object sender, EventArgs e)
        {
            CalcularTotalIgv();
        }

        private void txtIgv_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalIgv();
        }

        private void txtIgv_Validating(object sender, CancelEventArgs e)
        {
            CalcularTotalIgv();
        }

        private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);


                    lblCambio.Visible = true;
                    txtCambio.Visible = true;
                    
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
                if (!string.IsNullOrEmpty(txtTotal.Text)) ConverNumLetras(Convert.ToDecimal(txtTotal.Text));
            }
            else
            {
                lblCambio.Visible = false;
                txtCambio.Visible = false;
                txtCambio.Text = "";
            }
        }

        private void dtpFechaEmision_Leave(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);


                    lblCambio.Visible = true;
                    txtCambio.Visible = true;
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
                if (!string.IsNullOrEmpty(txtTotal.Text)) ConverNumLetras(Convert.ToDecimal(txtTotal.Text));
            }
            else
            {
                lblCambio.Visible = false;
                txtCambio.Visible = false;
                txtCambio.Text = "";
            }
        }

        private void cboModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0 || Convert.ToInt32(cboModalidad.SelectedValue) == 1)//Sin seleccionar - EFECTIVO 
            {
           
                grbCheque.Enabled = false;//panel cheque
                grbInterbancario.Enabled = false;//panel interbancario
                cboTipoEntidad.SelectedIndex = -1;
                cboEntidad1.SelectedIndex = -1;
                txtNroSerieCheq.Clear();
                txtNroDocumentoCheq.Clear();
                txtNroCuentaCheq.Clear();
       

            }
            //PAGO CON CHEQUE
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)
            {
                grbCheque.Enabled = true;
                grbCheque.Visible = true;
                grbInterbancario.Enabled = false;
                grbInterbancario.Visible = false;
                cboTipoEntidad.Enabled = true;

                cboTipoEntidad.SelectedIndex = -1;

                cboTipoEntidad.Visible = true;
                lblBase24.Visible = true;

                cboEntidad1.SelectedIndex = -1;
                txtNroSerieCheq.Clear();
                txtNroDocumentoCheq.Clear();
                txtNroCuentaCheq.Clear();
                txtNroSerieCheq.ReadOnly = false;
                txtNroDocumentoCheq.ReadOnly = false;
                txtNroCuentaCheq.Visible = true;
                txtNroCuentaCheq.ReadOnly = false;
                txtNroCuentaCheq.Enabled = true;
                txtNroDocumentoCheq.Enabled = true;
            }
            //INTERBANCARIOS
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)
            {
                CargarCtasbancosInterbancarios();
                grbCheque.Enabled = false;
                grbCheque.Visible = false;
                grbInterbancario.Enabled = true;
                grbInterbancario.Visible = true;
                cboCuenta.Enabled = true;
                cboTipoEntidad.Visible = false;
                lblBase24.Visible = false;
                
                cboEntidad2.SelectedIndex = -1;
                cboCuenta.SelectedIndex = -1;
                txtNroSerieInt.Clear();
                txtNroDocInt.Clear();

                txtNroSerieInt.ReadOnly = false;
                txtNroDocInt.ReadOnly = false;               
            }
            
        }
        private void CargarCtasbancosInterbancarios()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            cboEntidad2.DataSource = dtEntidad;
            cboEntidad2.ValueMember = "idEntidad";
            cboEntidad2.DisplayMember = "cNombreCorto";
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidad.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad.SelectedValue);
                cboEntidad1.CargarEntidades(nTipEnt);
                cboEntidad1.SelectedIndex = -1;
            }
        }

        private void cboEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboEntidad2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad2.SelectedIndex == -1 || cboEntidad2.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            int idEntidad = Convert.ToInt32(cboEntidad2.SelectedValue);
            dt = objCpg.ListarCuentaXEntidades(idEntidad,Convert.ToInt32(cboMoneda.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }

        private void btnExtorno1_Click(object sender, EventArgs e)
        {
            if (!ValidarDatoExtorno()) return;

            if (MessageBox.Show("¿Esta seguro(a) de Extornar este comprobante de pago?", "Pago de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            frmAnulRegVenta frmAnulRegVenta = new frmAnulRegVenta();
            frmAnulRegVenta.ShowDialog();

            if (!frmAnulRegVenta.lFlagAceptar)
            {
                MessageBox.Show("Extorno cancelado, Intente nuevamente.", "Anular Pago de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtRegVenta.Rows[0]["dFechaEli"] = clsVarGlobal.dFecSystem;
            dtRegVenta.Rows[0]["idUsuarioEli"] = clsVarGlobal.User.idUsuario;
            dtRegVenta.Rows[0]["idMotivoEli"] = frmAnulRegVenta.idMotAnul;
            dtRegVenta.Rows[0]["cMotivoEli"] = frmAnulRegVenta.cMotAnul;
            dtRegVenta.Rows[0]["idEstado"] = 1;

            dtRegVenta.TableName = "dtRegVenta";
            dtDetRegVenta.TableName = "dtDetRegVenta";

            DataSet dsRegVenta = new DataSet("dsRegVenta");
            DataSet dsDetRegVenta = new DataSet("dsDetRegVenta");

            dsRegVenta.Tables.Add(dtRegVenta);
            dsDetRegVenta.Tables.Add(dtDetRegVenta);

            string xmlRegVenta = clsCNFormatoXML.EncodingXML(dsRegVenta.GetXml());
            string xmlDetRegVenta = clsCNFormatoXML.EncodingXML(dsDetRegVenta.GetXml());

            dsRegVenta.Tables.Clear();
            dsDetRegVenta.Tables.Clear();

            DataTable result = objCajaChica.GuardarRegVenta(xmlRegVenta, xmlDetRegVenta, idCpgRef, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show("El comprobante de Venta se extorno Correctamente", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeshabilitarControles();
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnBusqueda.Enabled = true;
                btnAnular.Enabled = false;
                btnAgregarDetalle.Enabled = false;
                btnQuitarDetalle.Enabled = false;
                btnMiniEditar.Enabled = false;
                btnBusqCodRef.Enabled = false;
                lModoEdic = false;
                btnExtorno1.Enabled = false;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cNuevo = "N";
        }
        private bool ValidarDatoExtorno()
        {
            DataTable dtKardexPagVentas = objCajaChica.CNListarDatosPagoVentas(Convert.ToInt32(txtCodigo.Text));
            if (dtKardexPagVentas.Rows.Count>0)
            {
                if (Convert.ToInt32(dtKardexPagVentas.Rows[0]["idAgeOpera"]) != clsVarGlobal.nIdAgencia)
                {
                    MessageBox.Show("La agencia no es igual a la agencia donde se pago el comprobante", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTipoComprobantePago.Focus();
                    return false;
                }
                if ((Convert.ToDateTime(dtKardexPagVentas.Rows[0]["dFechaOpe"]) != clsVarGlobal.dFecSystem) && Convert.ToInt32(dtKardexPagVentas.Rows[0]["idTipoPago"]) == 1)
                {
                    MessageBox.Show("La fecha no es igual a la fecha de operación", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMoneda.Focus();
                    return false;
                }
                if (Convert.ToInt32(dtKardexPagVentas.Rows[0]["IdUsuario"]) != clsVarGlobal.User.idUsuario)
                {
                    MessageBox.Show("El usuario de operación debe ser igual al usuario de extorno", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboDestino.Focus();
                    return false;
                }                
            }
            else
            {
                MessageBox.Show("El registro de ventas ya esta Extornado o esta en Estado Registrado", "Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                return false;
            }           
            return true;
        }

        private void dFecRegistro_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
