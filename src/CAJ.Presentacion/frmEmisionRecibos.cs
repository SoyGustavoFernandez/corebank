using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.Funciones;
using GEN.CapaNegocio;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using ADM.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmEmisionRecibos : frmBase
    {
        #region Variables
        private int nIndAfecITF = 0;
        private DataTable tbConcep;
        private int x_nTipOpe = 0;
        private int idReciboProvisional = 0;

        clsFunUtiles FunTruncar = new clsFunUtiles();
        private clsCreditoSeguro objCreditoSeguro = new clsCreditoSeguro();

        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        private int idEntregaCuentasPagar = 0;
        private int idUsuario_;
        private int idTipIngEgr_;
        private int idConcepto_;
        int idMoneda_;
        private decimal nMonto_;
        private string cMotivo_;
        private bool lLlenarFormularioRendicion;
        public string cCodigoRecibo = "";
        public int idReciboBuscar = 0;
        private bool lDesembolsoEntregaRendir = false;

        private int nCodCli_;
        private int nMeses_;
        private int idTipoPlan_;
        private bool lLlenarFormularioSeguro = false;
        private bool lLlenarFormulariSolReimpresion = false;
        public bool lGrabarSeguro = false;
        public delegate void PasarDato(string cNroRecibo);
        public event PasarDato cNroRecibo;
   
        #endregion

        public frmEmisionRecibos()
        {
            InitializeComponent();
        }

        public frmEmisionRecibos(decimal nMontoSeguro, int nCodCli, int idConcepto, string cSustento, int nMeses, int idTipoPlan)
        {
            nMeses_ = nMeses;
            nMonto_ = nMontoSeguro;
            nCodCli_ = nCodCli;
            idConcepto_ = idConcepto;
            cMotivo_ = cSustento;
            idTipoPlan_ = idTipoPlan;
            lLlenarFormularioSeguro = true;
            InitializeComponent();
        }

        public frmEmisionRecibos(int idUsuario, int idTipIngEgr, int idConcepto, int idMoneda, decimal nMonto, string cMotivo, int idEntregaRendir_)
        {
            idUsuario_ = idUsuario;
            idTipIngEgr_ = idTipIngEgr;
            idConcepto_ = idConcepto;
            idMoneda_ = idMoneda;
            nMonto_ = nMonto;
            cMotivo_ = cMotivo;
            idEntregaCuentasPagar = idEntregaRendir_;
            lLlenarFormularioRendicion = true;

            InitializeComponent();
        }
        public frmEmisionRecibos( int idConcepto,int idCLiente)
        {

            idConcepto_ = idConcepto;
            nCodCli_ = idCLiente;
            lLlenarFormulariSolReimpresion = true;
            InitializeComponent();
        }
        private void frmEmisionRecibos_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            x_nTipOpe = 5;
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpeSoloCaja() != "A")
            {
                this.Dispose();
                return;
            }

            //======================================================
            //--Cargar Datos
            //======================================================
            CargarTiporecibos();
            if (this.cboTipRec.SelectedIndex < 0)  //(string.IsNullOrEmpty(txtCodUsu.Text.Trim()))
            {
                CargarConceptos(0);
            }
            else
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue.ToString().Trim()));
            }
            // CargarSubItemCon(0);

            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            HabilitarControles(false);
            this.chcColab.Enabled = false;
            this.chcCliente.Enabled = false;
            conCalcVuelto.Enabled = false;
            //===========================================================
            //--Validar Parametro de Configuración
            //===========================================================
            //if (RetParamConfig() == 2)
            //{
            //    //===========================================================
            //    //--Valida si el Usuario tiene Nivel para Eliminar Recibos
            //    //===========================================================
            //    if (ValNivAut() == 0)
            //    {
            //        this.btnEliminar.Visible = false;
            //    }
            //    else
            //    {
            //        this.btnEliminar.Visible = true;
            //    }
            //}

            if(lLlenarFormularioRendicion){
                llenarFormulario(idUsuario_, idTipIngEgr_, idConcepto_, idMoneda_, nMonto_, cMotivo_);
            }

            if (lLlenarFormularioSeguro)
            {
                llenarFormularioSeguro(nMonto_, nCodCli_, idConcepto_, cMotivo_);
            }
            if (lLlenarFormulariSolReimpresion)
            {
                llenarFormularioSolReimpresion(idConcepto_, nCodCli_);
            }

            /*Seteado y llamado desde Rendiciones*/
            if (idReciboBuscar != 0)
            {
                setearReciboBuscar(idReciboBuscar);
                BuscarRecibo();
                ocultarBotones();
            }
        }

        private void ocultarBotones()
        {
            btnCuentasPagar.Visible = false;
            //btnBuscarSeguro.Visible = false;
            btnNuevo.Visible = false;
            btnGrabar.Visible = false;
            btnCancelar.Visible = false;
        }

        private bool validarSeguros(int idCli, int nMeses, int idSeguro)
        {
            DataTable dtResultado;
            if (idSeguro == Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]))
            {
                #region SeguroVida
            string xmlSeguros = "<?xml version='1.0'?><ArrayOfXElement xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'><XElement><idTipoSeguro>2</idTipoSeguro></XElement></ArrayOfXElement>";
                dtResultado = objCNCreditoCargaSeguro.CNValidarSeguros(
                    idCli,
                    xmlSeguros,
                    nMeses,
                    0);
            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                {
                    MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
                #endregion
            }
            else if (idSeguro == Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]))
            {
                #region SeguroOncologico
                dtResultado = objCNCreditoCargaSeguro.CNValidarSeguroOncologico(idCli, nMeses, 0);
                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRespuesta"]) == 0)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                #endregion
            }
            return true;
        }

        private string ValidarDatIng()
        {
            if (string.IsNullOrEmpty(txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("Debe Existir un Codigo de Usuario Para Registrar el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodUsu.Select();
                txtCodUsu.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboTipRec.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir un Tipo de Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipRec.Select();
                cboTipRec.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboConcepto.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir un Concepto para el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboConcepto.Select();
                cboConcepto.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboMoneda.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir la Moneda para el Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Select();
                cboMoneda.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtMonRec.Text.Trim()))//&& Convert.ToInt32(txtMonRec.Text.Trim()) == 0)
            {
                MessageBox.Show("Debe Ingresar el Monto del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtMonRec.Text) <= 0)
            {
                MessageBox.Show("El Monto del Recibo no debe Ser Cero(0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtTotRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el MOnto del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtTotRec.Text)<=0)
            {
                MessageBox.Show("El Monto Total del Recibo no debe Ser Cero(0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                return "ERROR";
            }
            if (true)
            {
                
            }
            if (string.IsNullOrEmpty(txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento del Recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSustento.Select();
                txtSustento.Focus();
                return "ERROR";
            }
            if (cboTipRec.SelectedValue.ToString() == "1")
            {
                if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text))
                {
                    MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return "ERROR";
                }
                if (conCalcVuelto.txtMonEfectivo.nDecValor < Convert.ToDecimal(txtTotRec.Text))
                {
                    MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return "ERROR";
                }
            }
          
            //===========================================================
            //--Valida Monto Maximo de Operacion del concepto de operacion
            //===========================================================
            clsCNControlOpe LisMonto = new clsCNControlOpe();
            DataTable tbMontoConcep = LisMonto.LisMonConcep(clsVarGlobal.nIdAgencia, Convert.ToInt32(this.cboConcepto.SelectedValue));

            if (tbMontoConcep.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Monto de Validacion para el Concepto Registrado", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboConcepto.Select();
                return "ERROR";
            }

            if (Convert.ToDecimal (txtMonRec.Text.Trim()) > Convert.ToDecimal (tbMontoConcep.Rows[0]["nMontoMax"].ToString()))
            {
                MessageBox.Show("El Monto Maximo permitido es:  " + tbMontoConcep.Rows[0]["nMontoMax"].ToString() + " .Verique ", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonRec.Select();
                txtMonRec.Focus();
                //return "ERROR";
            }

            if (cboAgencias.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una agencia destino", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Select();
                cboAgencias.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private bool validarConceptoRestringido()
        {
            DataRowView dtConcepto = (DataRowView)cboConcepto.SelectedItem;

            return Convert.ToBoolean(dtConcepto["lRestringido"]);
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void CargarConceptos(int nTipRec)
        {
            /*C.idConcepto,C.cConcepto,C.cTipMonto,C.nMontoCon,C.nAfectoITF*/
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            tbConcep = LisConcep.ListaConceptosPer(nTipRec, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            if (tbConcep.Rows.Count > 1)
            {
                cboConcepto.SelectedIndex = 1;
            }
            else
            {
                cboConcepto.SelectedIndex = 0;
            }
        }

        private int ValNivAut()
        {
            clsCNControlOpe ValNivAuto = new clsCNControlOpe();
            return ValNivAuto.RetNivelAutorizacion(1, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
        }

        private int RetParamConfig()
        {
            clsCNControlOpe ParamConfig = new clsCNControlOpe();
            return ParamConfig.RetParamConfiguracion(1);
        }

        private string ValidaInicioOpe()
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpe(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada            
            return cEstCie;
        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void LimpiarControles()
        {
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.txtNroRec.Clear();
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();


            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.conBusCli.txtCodAge.Clear();
            this.conBusCli.txtCodInst.Clear();
            this.conBusCli.txtDireccion.Clear();

            this.txtMonRec.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtMonItf.Text = "0.00";
            this.txtSustento.Clear();

            conCalcVuelto.limpiar();

            idEntregaCuentasPagar = 0;
        }

        private void LimpiarControlesBus()
        {
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
            this.conBusCli.txtCodCli.Clear();
            this.conBusCli.txtNombre.Clear();
            this.conBusCli.txtNroDoc.Clear();
            this.txtMonRec.Text = "0.00";
            this.txtMonItf.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
        }
        private void HabilitarControles(Boolean Val)
        {
            this.cboTipRec.Enabled = Val;
            this.cboConcepto.Enabled = Val;
            this.cboMoneda.Enabled = Val;
            //this.cboDetalle.Enabled = Val;
            this.cboAgencias.Enabled = false;
            this.conBusCol.txtCod.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = Val;
            this.conBusCli.btnBusCliente.Enabled = Val;
            this.txtMonRec.Enabled = Val;
            //this.txtTotRec.Enabled = Val;
            this.txtSustento.Enabled = Val;
            //this.chcColab.Checked = false;
            //this.chcColab.Enabled = Val;
            //this.chcCliente.Checked = false;
            //this.chcCliente.Enabled = Val;
        }

        private void cboTipRec_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipRec.SelectedValue.ToString() == "1")
            {
                CargarConceptos(1);
                conCalcVuelto.txtMonEfectivo.Focus();
                lblAge.Text = "Ag. Origen:";

            }
            else
            {
                CargarConceptos(2);
                conCalcVuelto.limpiar();
                conCalcVuelto.Enabled = false;
                lblAge.Text = "Ag. Destino:";
            }
            txtMonRec.Focus();

        }


        private void cboTipRec_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles(true);
            this.cboConcepto.SelectedIndex = 0;
            this.txtMonRec.BackColor = Color.White;
            this.chcBuscar.Enabled = false;
            this.chcBuscar.Checked = false;
            this.txtNroRec.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            //this.btnBuscarSeguro.Enabled = false;
            this.btnCuentasPagar.Enabled = false;

            this.chcColab.Enabled = true;
            this.chcColab.Checked = false;
            this.chcCliente.Enabled = true;
            this.chcCliente.Checked = false;
            this.conBusCol.btnConsultar.Enabled = false;
            this.conBusCli.btnBusCliente.Enabled = false;
            this.cboTipRec.SelectedValue = 1;
            this.cboTipRec.Focus();
            this.idReciboProvisional = 0;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //======================================================================
            //--Obtener Datos Generales
            //======================================================================
            int TipRec = Convert.ToInt32(this.cboTipRec.SelectedValue.ToString());
            int TipCon = Convert.ToInt32(this.cboConcepto.SelectedValue.ToString());
            int idCol;
            int idCli;
            DataRow[] resultados = new clsCNConfigurarSeguroOptativo().CNListaPlanSeguro(0).Select("idConcepto = " + TipCon);
            int idTipoSeguro = resultados.FirstOrDefault()?["idTipoSeguro"] as int? ?? 0;

            // int nSubItem;

            //======================================================================
            //--Validar Datos Ingresados
            //======================================================================
            if (ValidarDatIng() == "ERROR")
            {
                return;
            }
            
            if(Convert.ToDecimal (txtMonRec.Text) <= 0)
            {
                MessageBox.Show("El Monto de Recibo Debe Ser Mayor a Cero...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // txtMonRec.Select();
                txtMonRec.Focus();
                return;
            }

            if (lLlenarFormularioSeguro)
            {
                if (!validarSeguros(nCodCli_, nMeses_, idTipoSeguro))
                {
                    return;
                }
            }
           
            //======================================================================
            //--Valida, que Mínimo Registre un Colaborador o Cliente
            //======================================================================
            if (!chcColab.Checked && !chcCliente.Checked)
            {
                MessageBox.Show("Debe Seleccionar por lo Menos al Colaborador o Cliente", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //======================================================================
            //--Valida conceptos restringidos para su registro manual
            //======================================================================
            if (!lLlenarFormularioSeguro)
            {
                if (validarConceptoRestringido() && idEntregaCuentasPagar == 0)
                {
                    MessageBox.Show("Concepto RESTRINGIDO, El concepto ha sido restringido para su uso desde este formulario.", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cancelarEmisionRecibo();
                    btnCuentasPagar.Focus();
                    return;
                }
            }
            idCli = 0;
            idCol = 0;
            if (chcColab.Checked) //Si se Requiere Colaborador
            {
                if (string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Colaborador", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (string.IsNullOrEmpty(this.conBusCol.txtNom.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Colaborador...VERIFICAR", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                idCol = Convert.ToInt32(this.conBusCol.txtCod.Text.Trim());
                idCli = Convert.ToInt32(conBusCol.idCliPer);
            }

            if (chcCliente.Checked) //Si se Requiere al Cliente
            {
                if (string.IsNullOrEmpty(this.conBusCli.txtCodCli.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Cliente Cliente", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (string.IsNullOrEmpty(this.conBusCli.txtNroDoc.Text.Trim()))
                {
                    MessageBox.Show("Debe Registrar al Cliente Cliente...VERIFICAR", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                idCli = Convert.ToInt32(this.conBusCli.txtCodCli.Text.Trim());
            }

            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglas())
            {
                return;
            }

            int TipMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMonRec = Convert.ToDecimal (this.txtMonRec.Text);
            Decimal nMonItf = Convert.ToDecimal (this.txtMonItf.Text);
            Decimal nMonTot = Convert.ToDecimal (this.txtTotRec.Text);
            string cSust = this.txtSustento.Text.Trim();
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text.Trim());

            int idAgeOri = clsVarGlobal.nIdAgencia;
            int idAgeDest = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());

            DataTable dtRec = (DataTable)cboConcepto.DataSource;

            bool lAfecCaja = true;
            lAfecCaja = Convert.ToBoolean(dtRec.Rows[cboConcepto.SelectedIndex][6].ToString());

            if (lAfecCaja)
            {
                  if(ValidaSaldoLinea(idUsu, idAgeOri, TipMon, TipRec, nMonTot))
                  {
                      return;
                  }
            }

            string msg = "";
            clsCNImpresion Imprimir = new clsCNImpresion();
            clsCNControlOpe GuardarRec = new clsCNControlOpe();

            //=================  Registro Inicio Rastreo ===================================
            string cMsgCuentasPagar = idEntregaCuentasPagar == 0 ? "" : "(" + (lDesembolsoEntregaRendir ? "(Desembolso)" : "") + "Solicitud Cuentas por Pagar: " + idEntregaCuentasPagar + " )";

            this.registrarRastreo(idCli, 0, "Inicio  - Emitir Recibos "+cMsgCuentasPagar, btnGrabar);
            //==============================================================================

            DataTable dtResul = new DataTable();
            bool lModificaSaldoLinea = lAfecCaja;
           
            if (!lLlenarFormularioSeguro)
            {
                
                dtResul = GuardarRec.GuardarRecibo(TipRec, TipCon, idCol, idCli, TipMon, nMonRec, nMonItf, nMonTot, cSust, dtpFechaSis.Value, idUsu, idAgeOri,
                                                   idAgeDest, 0, ref msg, 0, lModificaSaldoLinea, this.idReciboProvisional, nMeses_);
            }
            else 
            {               
                dtResul = GuardarRec.GuardarReciboRelacionadoSeguro(TipRec, TipCon, idCol, idCli, TipMon, nMonRec, nMonItf, nMonTot, cSust, dtpFechaSis.Value, idUsu, idAgeOri,
                                                                    idAgeDest, 0, ref msg, 0, objCreditoSeguro.idCreditoSeguro, lModificaSaldoLinea, this.idReciboProvisional, idTipoPlan_, nMeses_);
                    lGrabarSeguro = true;
                
            }
            if (dtResul.Rows.Count > 0)
            {
                this.txtNroRec.Text = dtResul.Rows[0]["cCodRec"].ToString();
                
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                /*Actualizar Estado en Cuentas por Pagar de la Solicitud*/
                if (idEntregaCuentasPagar != 0 && lDesembolsoEntregaRendir)
                {
                    DataTable dtResp = new clsCNCuentasPorPagar().registrarConfirmacionDesembolso(
                        idEntregaCuentasPagar,
                        Convert.ToInt32(dtResul.Rows[0]["cCodRec"]),
                        Convert.ToDecimal(txtMonRec.Text),
                        clsVarGlobal.PerfilUsu.idUsuario);
                    if (dtResp.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtResp.Rows[0]["idEstado"]) == 1)
                        {
                            cMsgCuentasPagar += " Confirmación exitosa " + dtResul.Rows[0]["cCodRec"];
                        }
                        else
                        {
                            cMsgCuentasPagar += " Confirmación erronea";
                        }
                    }
                    else
                    {
                        cMsgCuentasPagar += " No Confirmado";
                    }
                }

                cCodigoRecibo = dtResul.Rows[0]["cCodRec"].ToString();
                MessageBox.Show("El Recibo se Registro Correctamente, NRO RECIBO: " + dtResul.Rows[0]["cCodRec"].ToString(), "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //--Imprimir Voucher 
                int idKardex = Convert.ToInt32(dtResul.Rows[0]["idKardex"]);
                ImpresionVoucher(idKardex, 3, x_nTipOpe, 1, Convert.ToDecimal(conCalcVuelto.txtMonEfectivo.Text), Convert.ToDecimal(conCalcVuelto.txtMonDiferencia.Text), 0, 1);
                if (lLlenarFormulariSolReimpresion)
                {
                    btnCancelar.Enabled = false;
                    conCalcVuelto.Enabled = false;

                    cNroRecibo(dtResul.Rows[0]["cCodRec"].ToString());
                    this.Close();
                }
               
                /////////////////////////////////////////////////////////////////////
            }

            else
            {
                MessageBox.Show(msg, "Error al Registrar el Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(idCli, 0, "Fin - Emitir Recibos "+cMsgCuentasPagar, btnGrabar);
            //============================================================================   
            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            HabilitarControles(false);
            this.chcBuscar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.chcColab.Enabled = false;
            this.chcCliente.Enabled = false;
            this.conBusCol.btnConsultar.Enabled = false;
            this.conBusCli.btnBusCliente.Enabled = false;
            this.btnNuevo.Enabled = (objCreditoSeguro.idCreditoSeguro != 0) ? false : true ;

            if (lLlenarFormularioRendicion || lLlenarFormularioSeguro)
            {
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = false;
                chcBuscar.Enabled = false;
            }
        }
        public void EmitirVoucher(DataTable dtDatosCobro, int idRec, int idKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idRec", idRec.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));
            string reportpath = "RptVoucherEmiRec.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEmisionRecibo();
        }

        private void chcBuscar_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarControles(false);
            LimpiarControles();
            if (this.chcBuscar.Checked)
            {
                this.txtNroRec.Enabled = true;
                this.btnBusRec.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.txtNroRec.Select();
                this.txtNroRec.Focus();
            }
            else
            {
                this.txtNroRec.Enabled = false;
                this.btnBusRec.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            if (chcCliente.Checked)
            {
                x_idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);
            }
            else
            {
                x_idCliente = clsVarGlobal.User.idCli;
            }

            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), 121,
                                                   Decimal.Parse(txtMonRec.Text), x_idCliente, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            if (cCumpleReglas.Equals("ExcepcionRechazada"))
            {
                DataTable dtActVigSolAprobada = ValidaReglasDinamicas.CNUpdVigSolicitudAprob(x_idCliente);
                return false;
            }
            return true;
        }

        private void setearReciboBuscar(int idRecibo)
        {
            txtNroRec.Text = idRecibo.ToString();
        }

        private void BuscarRecibo()
        {
            LimpiarControlesBus();
            this.chcColab.Checked = false;
            this.chcCliente.Checked = false;
            if (string.IsNullOrEmpty(this.txtNroRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Número de Recibo a Buscar...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.SelectAll();
                this.txtNroRec.Focus();
                return;
            }

            string msge = "";
            clsCNControlOpe DatosRecibo = new clsCNControlOpe();
            DataTable tbRec = DatosRecibo.BuscarRecibo(Convert.ToInt32(txtNroRec.Text.Trim()), ref msge);
            if (msge == "OK")
            {
                if (tbRec.Rows.Count == 0)
                {
                    MessageBox.Show("El Nro de Recibo Buscado no Existe...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.SelectAll();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (tbRec.Rows[0]["cEstadoRec"].ToString() == "X")
                {
                    MessageBox.Show("El Nro de Recibo Buscado Esta ELIMINADO...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.Select();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (RetParamConfig() == 1)
                {
                    if (tbRec.Rows[0]["idUsuOpe"].ToString().Trim() != this.txtCodUsu.Text.Trim())
                    {
                        MessageBox.Show("El Recibo fue Generado por Otro Usuario: NO PUEDE ELIMINARLO...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtNroRec.Select();
                        this.txtNroRec.Focus();
                        this.btnCancelar.Enabled = true;
                        return;
                    }
                }

                if (tbRec.Rows[0]["dFechaReg"].ToString() != this.dtpFechaSis.Value.ToString())
                {
                    MessageBox.Show("El Recibo fue Generado En Otra Fecha...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroRec.Select();
                    this.txtNroRec.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (RetParamConfig() == 1)
                {
                    if (Convert.ToInt32(tbRec.Rows[0]["idAgencia"].ToString()) != clsVarGlobal.nIdAgencia)
                    {
                        MessageBox.Show("El Recibo fue Generado En Otra Agencia...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtNroRec.Select();
                        this.txtNroRec.Focus();
                        this.btnCancelar.Enabled = true;
                        return;
                    }
                }

                //============================================================
                //--Cargar Datos del Recibo
                //============================================================
                this.cboTipRec.SelectedValue = tbRec.Rows[0]["idTipRecibo"];
                this.cboMoneda.SelectedValue = tbRec.Rows[0]["idMoneda"];
                this.cboConcepto.SelectedValue = tbRec.Rows[0]["idConcepto"];
                // this.cboDetalle.SelectedValue = tbRec.Rows[0]["idSubItem"];

                this.cboAgencias.SelectedValue = tbRec.Rows[0]["idAgeDestino"];
                this.lblAge.Text = (tbRec.Rows[0]["idTipRecibo"].ToString() == "1" ? "Ag. Origen" : "Ag. Destino");

                //this.cboDetalle.Enabled = false;

                if (tbRec.Rows[0]["idColaborador"].ToString() != "0")
                {
                    //this.chcColab.Checked = true;
                    this.conBusCol.txtCod.Text = tbRec.Rows[0]["idColaborador"].ToString();
                    this.conBusCol.txtCargo.Text = tbRec.Rows[0]["cCargo"].ToString();
                    this.conBusCol.txtNom.Text = tbRec.Rows[0]["NombreCol"].ToString();
                }
                else
                {
                    this.conBusCol.txtCod.Clear();
                    this.conBusCol.txtCargo.Clear();
                    this.conBusCol.txtNom.Clear();
                }

                //--datos del Cliente
                if (tbRec.Rows[0]["idCli"].ToString() != "0")
                {
                    //this.chcCliente.Checked = true;
                    this.conBusCli.CargardatosCli(Convert.ToInt32(tbRec.Rows[0]["idCli"].ToString()));
                    //this.conBusCli.txtCodCli.Text = tbRec.Rows[0]["idCli"].ToString();
                    //this.conBusCli.txtNroDoc.Text = tbRec.Rows[0]["cDocumentoID"].ToString();
                    //this.conBusCli.txtNombre.Text = tbRec.Rows[0]["cNombre"].ToString();
                }
                else
                {
                    this.conBusCli.txtCodCli.Clear();
                    this.conBusCli.txtNroDoc.Clear();
                    this.conBusCli.txtNombre.Clear();
                }

                //Asignar=tbRec.Rows[0]["idColaborador"];
                this.txtMonRec.Text = tbRec.Rows[0]["nMontoRec"].ToString();
                this.txtMonItf.Text = tbRec.Rows[0]["nMontoITF"].ToString();
                this.txtTotRec.Text = tbRec.Rows[0]["nMontoTot"].ToString();
                this.txtSustento.Text = tbRec.Rows[0]["cSustento"].ToString();
                txtMonRec.Enabled = false;
                chcColab.Enabled = false;
                chcCliente.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.conBusCol.btnConsultar.Enabled = false;
                this.conBusCli.btnBusCliente.Enabled = false;
                this.cboAgencias.Enabled = false;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatoMonto()
        {
           if (!string.IsNullOrEmpty(this.txtMonRec.Text.Trim()))
           {
               this.txtMonItf.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtMonItf.Text));
               this.txtMonRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtMonRec.Text));
               this.txtTotRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (this.txtTotRec.Text));
           }
           else
           {
                  this.txtMonItf.Text = "0.00";
                  this.txtMonRec.Text = "0.00";
                  this.txtTotRec.Text = "0.00";
           }
            
        }

        private void btnBusRec_Click(object sender, EventArgs e)
        {
            BuscarRecibo();
        }



        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nItem;
            this.txtMonRec.Clear();
            this.txtMonItf.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.conCalcVuelto.txtMonEfectivo.Text = "0.00";
            this.conCalcVuelto.txtMonDiferencia.Text = "0.00";
            this.txtSustento.Clear();
            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            chcAfectaCaja.Checked = false;
            if (cboConcepto.SelectedIndex > 0)
            {
                //Validando la Afectacion de ITF
                chcAfectaCaja.Checked = (bool)tbConcep.Rows[this.cboConcepto.SelectedIndex]["lAfectaCaja"];

                if (Convert.ToDecimal (tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"]) > 0)
                {
                    this.txtMonRec.Enabled = false;
                    this.txtMonRec.BackColor = Color.FromName("Control");
                    this.txtMonRec.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
                    this.Calcular();
                }
                else
                {
                    this.txtMonRec.Enabled = true;
                    this.txtMonRec.BackColor = Color.White;
                }
                //Validando concepto para clientes o colaborador
                if (Convert.ToInt32(tbConcep.Rows[this.cboConcepto.SelectedIndex]["nIndSoloPer"].ToString())==1)
                {
                    this.chcColab.Enabled = true;
                    this.chcCliente.Enabled = false;
                    this.chcColab.Checked = false;
                    this.chcCliente.Checked = false;
                }
                else
                {
                    this.chcColab.Enabled = false;
                    this.chcCliente.Enabled = true;
                    this.chcColab.Checked = false;
                    this.chcCliente.Checked = false;
                }
            }
            else
            {
                //CargarSubItemCon(0);
            }

            if (this.cboConcepto.SelectedValue.ToString() == "5")
            {
                lblAge.Text = "Ag. Origen:";
                //                this.cboAgencias.Enabled = true;
            }
            else
            {
                lblAge.Text = "Ag. Destino:";
                this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
                //                this.cboAgencias.Enabled = false;
            }

        }

        private void txtNroRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarRecibo();
            }
        }



        private void chcColab_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcColab.Checked)
            {
                this.conBusCol.txtCod.Clear();
                this.conBusCol.txtCargo.Clear();
                this.conBusCol.txtNom.Clear();
                this.conBusCol.btnConsultar.Enabled = true;
                this.chcCliente.Checked = false;
            }
            else
            {
                this.conBusCol.txtCod.Clear();
                this.conBusCol.txtCargo.Clear();
                this.conBusCol.txtNom.Clear();
                this.conBusCol.btnConsultar.Enabled = false;
            }
        }

        private void chcCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcCliente.Checked)
            {
                this.conBusCli.Enabled = true;
                this.conBusCli.txtCodInst.Clear();
                this.conBusCli.txtCodAge.Clear();
                this.conBusCli.txtCodCli.Clear();
                this.conBusCli.txtNroDoc.Clear();
                this.conBusCli.txtNombre.Clear();
                this.conBusCli.btnBusCliente.Enabled = true;
                this.chcColab.Checked = false;
            }
            else
            {
                this.conBusCli.Enabled = false;
                this.conBusCli.txtCodInst.Clear();
                this.conBusCli.txtCodAge.Clear();
                this.conBusCli.txtCodCli.Clear();
                this.conBusCli.txtNroDoc.Clear();
                this.conBusCli.txtNombre.Clear();
                this.conBusCli.btnBusCliente.Enabled = false;
            }
        }

        private void Calcular()
        {
            if (!string.IsNullOrEmpty(this.txtMonRec.Text.Trim()))
            {
                if (this.txtMonRec.Text.Trim() == ".")
                {
                    this.txtTotRec.Text = "0.00";
                    return;
                }
                Decimal nITF;
                if (nIndAfecITF == 1)
                {
                    nITF = nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * Convert.ToDecimal (this.txtMonRec.Text.ToString().Trim()), 2, (Int32)this.cboMoneda.SelectedValue);
                }
                else
                {
                    nITF = 0;
                }
                this.txtMonItf.Text = string.Format("{0:#,#0.00}", nITF);
                Decimal nSuma = Convert.ToDecimal (this.txtMonRec.Text) + Convert.ToDecimal (this.txtMonItf.Text);
                this.txtMonRec.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (this.txtMonRec.Text));
                this.txtTotRec.Text = string.Format("{0:#,#0.00}", nSuma);
                if (cboTipRec.SelectedValue.ToString() == "1")
                {
                    if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtTotRec.Text.Trim()))
                    {
                        conCalcVuelto.limpiar();
                    }
                    conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtTotRec.Text.Trim());
                    conCalcVuelto.Enabled = true;
                    conCalcVuelto.CalculoDirecto(Convert.ToDecimal(txtTotRec.Text.Trim()));
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                }

            }
            else
            {
                this.txtTotRec.Text = "0.00";
                this.txtMonRec.SelectAll();
                this.txtMonRec.Focus();
            }
        }
        private void txtMonRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Calcular();
            }
        }

        private void txtMonRec_Validated(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void txtMonRec_TextChanged(object sender, EventArgs e)
        {

        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            string dni = conBusCli.txtNroDoc.Text;
            string idCli = conBusCli.txtCodCli.Text;

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = dni == "" ? "0" : dni;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli == "" ? "0" : idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idColaborador";
            drfila[1] = conBusCol.txtCod.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipRecibo";
            drfila[1] = cboTipRec.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgeDestino";
            drfila[1] = cboAgencias.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idConcepto";
            drfila[1] = cboConcepto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRec";
            drfila[1] = txtMonRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtMonItf.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoTotal";
            drfila[1] = txtTotRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cSustento";
            drfila[1] = txtSustento.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMonRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);
            
            return dtTablaParametros;
        }

        private void txtSustento_TextChanged(object sender, EventArgs e)
        {
            txtSustento.CharacterCasing = CharacterCasing.Upper;
        }
        
        private void btnReciboProvicional_Click(object sender, EventArgs e)
        {
            frmBuscarReciboProvicional frmBusRecProv = new frmBuscarReciboProvicional();
            DialogResult dr = frmBusRecProv.ShowDialog();

            btnNuevo.PerformClick();

            if (dr == DialogResult.OK)
            {
                this.idReciboProvisional = frmBusRecProv.idReciboProvisional;
                this.cboTipRec.SelectedValue = frmBusRecProv.idTipRecibo;
                this.cboTipRec.Enabled = false;
                this.cboConcepto.SelectedValue = frmBusRecProv.idConceptoRec;
                this.cboConcepto.Enabled = false;
                this.cboMoneda.SelectedValue = frmBusRecProv.idMoneda;
                this.cboMoneda.Enabled = false;

                chcCliente.Enabled = false;
                chcCliente.Checked = true;
                this.conBusCli.btnBusCliente.Enabled = false;
                this.conBusCli.CargardatosCli(frmBusRecProv.idCli);

                this.txtMonRec.Text = frmBusRecProv.nMonto;
                this.txtMonRec.Enabled = false;
                this.txtSustento.Text = frmBusRecProv.cSustento;
                this.txtSustento.Enabled = false;
                this.Calcular();
            }
            if (dr == DialogResult.Cancel)
            {
                this.idReciboProvisional = 0;
                HabilitarControles(false);
                LimpiarControles();
                conBusCli.Enabled = false;
                this.cboConcepto.SelectedIndex = 0;
                this.chcBuscar.Enabled = true;
                this.chcBuscar.Checked = false;
                this.txtNroRec.Enabled = false;
                this.txtMonRec.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;

                this.chcColab.Enabled = false;
                this.chcColab.Checked = false;
                this.chcCliente.Enabled = false;
                this.chcCliente.Checked = false;
                conCalcVuelto.Enabled = false;
            }
            
        }

        private void cargarCreditoSeguro()
        {

            cboMoneda.SelectedValue     = objCreditoSeguro.idMoneda;
            cboAgencias.SelectedValue   = objCreditoSeguro.idAgencia;
            cboTipRec.SelectedValue     = 1;

            CargarConceptos(1);

            cboConcepto.SelectedValue   = objCreditoSeguro.idConceptoRecibo;
            chcAfectaCaja.Checked       = true;
            chcColab.Checked            = false;
            chcCliente.Checked          = true;
            chcCliente.Enabled          = false;
            conBusCol.CargarColaboradorxUsuario(objCreditoSeguro.idUsuario);
            conBusCol.Enabled           = false;
            conBusCli.CargardatosCli(objCreditoSeguro.idCliente);
            txtMonRec.Text              = Convert.ToString(objCreditoSeguro.nMontoPrima);
            txtSustento.Text            = Convert.ToString(objCreditoSeguro.cTipoSeguro);
            Calcular();
            conBusCli.Enabled           = false;
            txtSustento.Enabled         = false;
            txtMonRec.Enabled           = false;
            conCalcVuelto.CalculoDirecto(objCreditoSeguro.nMontoPrima);
            //btnBuscarSeguro.Enabled     = false;
            btnCuentasPagar.Enabled     = false;
            cboConcepto.Enabled         = false;
            cboTipRec.Enabled           = false;
        }

        private void cancelarEmisionRecibo()
        {
            HabilitarControles(false);
            LimpiarControles();
            conBusCli.Enabled = false;
            this.cboConcepto.SelectedIndex = 0;
            this.chcBuscar.Enabled = true;
            this.chcBuscar.Checked = false;
            this.txtNroRec.Enabled = false;
            this.txtMonRec.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.chcColab.Enabled = false;
            this.chcColab.Checked = false;
            this.chcCliente.Enabled = false;
            this.chcCliente.Checked = false;

            conCalcVuelto.Enabled = false;
            this.idReciboProvisional = 0;
            objCreditoSeguro = new clsCreditoSeguro();
            //btnBuscarSeguro.Enabled = true;

            btnCuentasPagar.Enabled = true;
        }

        private void btnCuentasPagar_Click(object sender, EventArgs e)
        {
            frmEntregasRendirAprobados frmCuentasPagar = new frmEntregasRendirAprobados();
            frmCuentasPagar.cTipoEntrega = "EntregasRendir";
            frmCuentasPagar.ShowDialog();
            int idUsuario = frmCuentasPagar.idUsuario;
            int idConcepto = frmCuentasPagar.idConcepto;
            int idMoneda = frmCuentasPagar.idMoneda;
            decimal nMonto = frmCuentasPagar.nMonto;
            string cMotivo = frmCuentasPagar.cMotivo;
            idEntregaCuentasPagar = frmCuentasPagar.idEntrega;

            if (frmCuentasPagar.idEntrega != 0 && frmCuentasPagar.idUsuario != 0)
            {
                bool lDesembolso = true;
                llenarFormulario(idUsuario, 2, idConcepto, idMoneda, nMonto, "(SOL:"+idEntregaCuentasPagar+") " + cMotivo, lDesembolso);
            }
        }

        private void llenarFormularioSeguro(decimal nMontoSeguro, int nCodCli, int idConcepto, string cMotivo)
        {
            cboMoneda.SelectedValue = 1;
            cboTipRec.SelectedValue = 1;
            cboConcepto.SelectedValue = idConcepto;
            txtSustento.Text = cMotivo;
            conCalcVuelto.txtMonEfectivo.Text = nMontoSeguro.ToString();
            txtMonRec.Text = nMontoSeguro.ToString();
            this.Calcular();
            chcCliente.Checked = true;
            chcCliente.Enabled = false;
            this.conBusCli.txtCodCli.Text = nCodCli.ToString();
            this.conBusCli.CargardatosCli(nCodCli);
            this.conBusCli.btnBusCliente.Enabled = false;
            txtMonRec.Enabled = false;
            btnCuentasPagar.Enabled = false;
            btnNuevo.Enabled = false;
            //btnBuscarSeguro.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            this.conCalcVuelto.txtMonEfectivo.Enabled = false;
            this.conCalcVuelto.txtMonEfectivo.Text = nMontoSeguro.ToString();
            this.chcBuscar.Enabled = false;
            if (lLlenarFormularioSeguro)
                btnCancelar.Enabled = false;
        }

        private void llenarFormularioSolReimpresion( int idConcepto,int idCliente)
        {
            LimpiarControles();
            cboMoneda.SelectedValue = 1;
            cboTipRec.SelectedValue = 1;
            cboConcepto.SelectedValue = idConcepto;
            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            chcAfectaCaja.Checked = false;
            chcAfectaCaja.Checked = (bool)tbConcep.Rows[this.cboConcepto.SelectedIndex]["lAfectaCaja"];
            conCalcVuelto.txtMonEfectivo.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
            txtMonRec.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
            this.Calcular();
            chcCliente.Checked = true;
            chcCliente.Enabled = false;
            this.conBusCli.txtCodCli.Text = idCliente.ToString();
            this.conBusCli.CargardatosCli(idCliente);
            this.conBusCli.btnBusCliente.Enabled = false;
            txtMonRec.Enabled = false;
            btnCuentasPagar.Enabled = false;
            btnNuevo.Enabled = false;
            //btnBuscarSeguro.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            this.conCalcVuelto.txtMonEfectivo.Enabled = true;
            this.conCalcVuelto.txtMonEfectivo.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
            this.chcBuscar.Enabled = false;
            txtSustento.Enabled = true;
            conCalcVuelto.Enabled = true;
     
            //if (lLlenarFormulariSolReimpresion)
            //    btnCancelar.Enabled = false;
        }

        private void llenarFormulario(int idUsuario, int idTipIngEgr, int idConcepto, int idMoneda, decimal nMonto, string cMotivo, bool lDesembolso = false)
        {
            cboTipRec.SelectedValue = idTipIngEgr;
            cboConcepto.SelectedValue = idConcepto;
            cboMoneda.SelectedValue = idMoneda;
            txtMonRec.Text = nMonto.ToString();
            this.Calcular();
            chcColab.Checked = true;
            chcColab.Enabled = false;
            txtSustento.Text = cMotivo;

            this.conBusCol.txtCod.Text = idUsuario.ToString();
            this.conBusCol.BusPerByCod();
            this.conBusCol.btnConsultar.Enabled = false;

            txtMonRec.Enabled = false;
            btnNuevo.Enabled = false;
            //btnBuscarSeguro.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnCuentasPagar.Enabled = false;
            this.conCalcVuelto.txtMonEfectivo.Enabled = false;
            this.conCalcVuelto.txtMonEfectivo.Text = nMonto.ToString();
            this.chcBuscar.Enabled = false;
            if (lLlenarFormularioRendicion)
                btnCancelar.Enabled = false;
            lDesembolsoEntregaRendir = lDesembolso;
        }

        private void conBusCli_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCli.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCli.txtNroDoc.Text);
            }
        }
   } 
}
