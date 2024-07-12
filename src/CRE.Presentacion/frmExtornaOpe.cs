using System;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.Collections.Generic;

namespace CRE.Presentacion
{
    public partial class frmExtornaOpe : frmBase
    {

        #region Variables

        int pidCuenta = 0;
        int pidmodulo = 1;
        bool lbloqueo = false;
        public DataTable dtOperacion = new DataTable();
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        clsCNOperacion Operacion = new clsCNOperacion();
        public int nNumOperacion, nidUserBloqueo;

        #endregion
        clsCNValidaReglasDinamicas ObjCnValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        public int idMod, idProd, idEstKar, idcli;

        int idSolAprob = 0;
        #region Eventos

        private void frmExtornaOpe_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            this.activarControlObjetos(this, EventoFormulario.INICIO);
            this.cboTipoOperacion.SelectedIndex = -1;
            this.cboTipoOperacionExt.SelectedIndex = -1;
            this.cboMonedaExt.SelectedIndex = -1;
            this.cboMotivoExtorno.SelectedIndex = -1;

            cboEstadoSolic1.EstSol(1);
            cboEstadoSolic1.SelectedValue = 1;

            int idKardexSol = 0;
            idKardexSol = Convert.ToInt32(nudNroKardexSolExt.Value);

            if (idKardexSol > 0)
            {
                BuscarOperacionSol(idKardexSol);
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nudNroKardex.Value) > 0)
            {
                LiberarCuenta();
            }

            LimpiarControles();
            pidCuenta = 0;
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 1;
            frmExtPen.pidTipOpe = "2";
            frmExtPen.cSustento = txtSustentoExt.Text;
            frmExtPen.idKardexExtorno = Convert.ToInt32(this.nudNroKardexSolExt.Value);
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar > 0)
            {
                nudNroKardex.Value = nidKar;
                this.txtEstadoOpe.Text = frmExtPen.pcEstKardex;
                btnCancelar.Enabled = true;
            }
            else
            {
                nudNroKardex.Value = 0;
                this.txtEstadoOpe.Text = "";
                return;
            }

            clsCNAprobacion objApr = new clsCNAprobacion();
            DataTable dtDatExt = objApr.RetornaDatosOperacionExt(Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia,
                                                                clsVarGlobal.User.idUsuario, 1, "2");

            nNumOperacion = Convert.ToInt32(this.nudNroKardex.Value);
            dtOperacion = Operacion.CNdtOperacion(nNumOperacion);//Obtener los datos propios de la Cobranza que se quiere extornar

            if (Convert.ToInt32(dtDatExt.Rows[0]["idRpta"].ToString()) == 1)
            {
                MessageBox.Show(dtDatExt.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnExtorno.Enabled = false;
            }
            else if (Convert.ToInt32(dtDatExt.Rows[0]["idRpta"].ToString()) == 0 && dtDatExt.Rows.Count > 0 && dtOperacion.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dtDatExt.Rows[0]["cProducto"].ToString()))
                {
                    MessageBox.Show("No Tiene Datos del Producto: VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pidCuenta = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                //--===============================================================================
                //--Validar Si Cuenta esta Siendo Usada
                //--===============================================================================
                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(pidCuenta);
                nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0]);
                if (nidUserBloqueo != 0)
                {
                    DataTable dtUsu = new DataTable();
                    dtUsu = RetornaNumCuenta.BusUsuBlo(nidUserBloqueo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lbloqueo = false;
                    LimpiarControles();
                    return;
                }
                else
                {
                    RetornaNumCuenta.UpdEstCuenta(pidCuenta, clsVarGlobal.User.idUsuario);//Usando la cuenta
                    lbloqueo = true;
                }
                this.txtDocIdePerson.Text = dtDatExt.Rows[0]["cNroDNI"].ToString();
                this.txtNombrePerson.Text = dtDatExt.Rows[0]["cNomCliente"].ToString();
                this.txtFechaOpe.Text = Convert.ToDateTime(dtDatExt.Rows[0]["dFechaOpe"]).ToString("dd/MM/yyyy") + " " + dtDatExt.Rows[0]["cHoraOpe"].ToString();
                this.txtProducto.Text = dtDatExt.Rows[0]["cProducto"].ToString();
                this.txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                //--Asignando Valores                
                cboTipoPago.SelectedValue = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());
                DataRow drDatos = dtOperacion.AsEnumerable().First();
                //Rellenar los datos del cobro a Extornar
                this.txtCapital.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoCapital"]));
                this.txtInteres.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoInteres"]));
                this.txtIntComp.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoIntComp"]));
                this.txtMora.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoMora"]));
                this.txtOtros.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoOtros"]));
                this.txtITF.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nITF"]));
                this.txtTotExtorno.Text = String.Format("{0:#,0.00}", Convert.ToString(drDatos["nMontoOperacion"]));

                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = "";
            LimpiarControles();
            lbloqueo = true;
            LiberarCuenta();
            btnExtorno.Enabled = false;
            cboTipoPago.SelectedIndex = 0;
            LimpiarControlesSolExt();
            nudNroKardexSolExt.Value = 0;
            nudNroKardexSolExt.Enabled = true;

            this.txtModuloExt.Clear();
            this.txtClienteExto.Clear();
            this.cboMonedaExt.SelectedIndex = -1;
            this.cboTipoOperacionExt.SelectedIndex = -1;
            this.txtMonOpeExt.Text = "0.00";
            this.cboMotivoExtorno.SelectedIndex = -1;
            this.txtSustentoExt.Clear();

            nudNroKardexSolExt.Value = 0;
            nudNroKardexSolExt.Enabled = true;
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(0, nNumOperacion, "Inicio - Extorno de Cobranza", btnExtorno);
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("¿Esta Seguro de Extornar la Operación?", "Extornar Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int nidModPagoCre = Convert.ToInt32(dtOperacion.Rows[0]["idModPagoCre"]);

            int nUsusis = clsVarGlobal.User.idUsuario;
            DateTime dfecsis = clsVarGlobal.dFecSystem.Date;

            if (Convert.ToInt32(dtOperacion.Rows[0]["iduser"]) != nUsusis)
            {
                MessageBox.Show("El usuario que hizo la operación no es el mismo que él del extorno", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Valido si el campo dtOperacion.Rows[0]["dFechaValor"] tiene datos
            if (dtOperacion.Rows[0]["dFechaValor"] == DBNull.Value)
            {
                if (Convert.ToDateTime(dtOperacion.Rows[0]["dFechaOpe"]).ToShortDateString() != dfecsis.ToShortDateString())
                {
                    MessageBox.Show("La fecha en la que se hizo la operación no es el misma que la del extorno", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (Convert.ToDateTime(dtOperacion.Rows[0]["dFechaValor"]).ToShortDateString() != dfecsis.ToShortDateString())
                {
                    MessageBox.Show("La fecha en la que se hizo la operación de Fecha Valor no es el misma que la del extorno", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }           

            int nKarAExtornar = Convert.ToInt32(this.nudNroKardex.Value);
            int nIdUsuario = clsVarGlobal.User.idUsuario;

            DataTable dtValPlanPago = Operacion.CNRecuperarPlanPagosValidarExtorno(nKarAExtornar);

            if(Convert.ToInt32(dtValPlanPago.Rows[0]["idPlanPagosCredito"]) != Convert.ToInt32(dtValPlanPago.Rows[0]["idPlanPagosKardex"]))
            {
                MessageBox.Show("El Plan de Pagos del Crédito Actual es diferente de la operación que quiere Extornar.\nNo se podrá realizar el Extorno de la operación", "Validación de Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)//Efectivo
            {
                if (ValidaSaldoLinea(nIdUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda.SelectedValue), 2, Convert.ToDecimal(txtTotExtorno.Text)))
                {
                    return;
                }
            }

            DataTable nKarQueExtorna;
            int idKardexExtorno = 0;

            if (nidModPagoCre == 4)
            {
                bool lModificaSaldoLinea = false;
                int idTipoTransac = 2; //EGRESO
                decimal nMontoExtorno = Convert.ToDecimal(txtTotExtorno.Text);
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

                if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
                    lModificaSaldoLinea = true;

                idKardexExtorno = Operacion.extornarPrePago(nKarAExtornar, clsVarGlobal.dFecSystem, nIdUsuario,
                                                             lModificaSaldoLinea, idTipoTransac, clsVarGlobal.nIdAgencia, idMoneda, nMontoExtorno);
                if (idKardexExtorno != -1)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    MessageBox.Show("El Extorno se realizó con éxito !!", "Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                bool lModificaSaldoLinea = false;
                bool lKardexRelacionado = true;
                int idTipoTransac = 2; //EGRESO
                decimal nMontoExtorno = Convert.ToDecimal(txtTotExtorno.Text);
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

                if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
                    lModificaSaldoLinea = true;
                
                nKarQueExtorna = Operacion.CNdtExtornaOpe(nKarAExtornar, clsVarGlobal.dFecSystem, nIdUsuario,
                                                          lModificaSaldoLinea, lKardexRelacionado, idTipoTransac, clsVarGlobal.nIdAgencia, idMoneda, nMontoExtorno);

                idKardexExtorno = Convert.ToInt32(nKarQueExtorna.Rows[0]["idRpta"]);

                if (nKarQueExtorna.Rows.Count > 0 && idKardexExtorno != -1)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    MessageBox.Show("El Extorno se realizó con éxito !!", "Extorno de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnExtorno.Enabled = false;

                    ImpresionVoucher(nIdKardex: idKardexExtorno, idModulo: 1, idTipoOpe: 2, idEstadoKardex: 2,
                                    nValRec: 0,
                                    nValdev: 0,
                                    idKardexAd: 0, idTipoImpresion: 1);

                    btnCancelar.Enabled = true;
                }
                else
                {
                    MessageBox.Show(nKarQueExtorna.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnExtorno.Enabled = false;
                }
            }

            LiberarCuenta();

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(0, pidCuenta, "Extorno de Cobranza completado", btnExtorno);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO 
             ========================================================================================*/
            this.registrarRastreo(0, nNumOperacion, "Fin - Extorno de Cobranza", btnExtorno);
        }

        private void frmExtornaOpe_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        #endregion

        #region Métodos

        public frmExtornaOpe()
        {
            InitializeComponent();
        }
        public frmExtornaOpe(int nIdKardexExtorno) //jcasas
        {
            InitializeComponent();
            nudNroKardexSolExt.Value = nIdKardexExtorno;
            cboTipoOperacionExt.ListadoTipoOpe();
        }
        private void LimpiarControles()
        {
            txtDocIdePerson.Clear();
            txtNombrePerson.Clear();
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
            txtProducto.Clear();
            this.cboTipoOperacion.SelectedIndex = -1;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonOpe.Text = "0.00";

            //Detalles Monto
            txtCapital.Text = String.Empty;
            txtInteres.Text = String.Empty;
            txtIntComp.Text = String.Empty;
            txtMora.Text = String.Empty;
            txtOtros.Text = String.Empty;
            txtITF.Text = String.Empty;
            txtTotExtorno.Text = String.Empty;
        }

        private bool ValiDatos()
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Número de Kardex, esta Vacío, por favor Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.nudNroKardex.Value <= 0)
            {
                MessageBox.Show("El Número de Kardex no es Válido, por favor Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No puede realizar el Extorno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        public void EmitirVoucherExtorno(DataTable dtDatosCobro, int idKardex, int idmodulo)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));
            paramlist.Add(new ReportParameter("x_idModulo", idmodulo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            string reportpath = "RptVouchersExtorno.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();

        }

        private void LiberarCuenta()
        {
            if (lbloqueo)
            {
                new clsCNRetornaNumCuenta().UpdEstCuenta(pidCuenta, 0);
                lbloqueo = false;
            }
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            BuscarOperacionSol(Convert.ToInt32(this.nudNroKardexSolExt.Value));
        }

        public void BuscarOperacionSol(int nudNroKardex)
        {
            LimpiarControlesSolExt();
            int idKar = nudNroKardex;

            if (string.IsNullOrEmpty(idKar.ToString()))
            {
                MessageBox.Show("Debe Ingresar el número de Operación", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudNroKardex.Select();
                this.nudNroKardex.Focus();
                return;
            }
            if (idKar <= 0)
            {
                MessageBox.Show("El número de operación ingresado No Es Válido", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudNroKardex.Select();
                this.nudNroKardex.Focus();
                return;
            }

            clsCNGenAdmOpe dtDatTrx = new clsCNGenAdmOpe();
            DataTable tbTrx = dtDatTrx.RetDatosOperacion(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (Convert.ToInt32(tbTrx.Rows[0]["idRpta"].ToString()) == 0)
            {
                this.txtModuloExt.Text = tbTrx.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacionExt.SelectedValue = tbTrx.Rows[0]["idTipoOperacion"].ToString();
                this.cboMonedaExt.SelectedValue = tbTrx.Rows[0]["idMoneda"].ToString();
                this.txtMonOpeExt.Text = tbTrx.Rows[0]["nMontoOperacion"].ToString();
                this.txtClienteExto.Text = tbTrx.Rows[0]["cNomCliente"].ToString();
                idMod = Convert.ToInt32(tbTrx.Rows[0]["idModulo"].ToString());
                idProd = Convert.ToInt32(tbTrx.Rows[0]["idProducto"].ToString());
                idEstKar = Convert.ToInt32(tbTrx.Rows[0]["idEstadoKardex"].ToString());
                idcli = Convert.ToInt32(tbTrx.Rows[0]["idCliAfeITF"].ToString());
                this.nudNroKardexSolExt.Enabled = false;
                this.btnEnviar1.Enabled = true;
                this.cboMotivoExtorno.Enabled = true;
                this.txtSustentoExt.Enabled = true;
                this.cboMotivoExtorno.Focus();
            }
            else if (Convert.ToInt32(tbTrx.Rows[0]["idRpta"].ToString()) == 6)
            {
                DataTable dtOperacionExtorno = dtDatTrx.recuperarOperacionExtorno(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
                clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.In("lstTipoOpeAnular"));
                List<int> lstTipoOpeAnular = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

                if (dtOperacionExtorno.Rows.Count > 0)
                {
                    int idTipoOperacion = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idTipoOperacion"]);
                    idSolAprob = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idSolAproba"]);

                    if (idSolAprob != 0 && lstTipoOpeAnular.Any(item => idTipoOperacion == item))
                    {
                        this.txtModuloExt.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cModulo"]);
                        this.cboTipoOperacionExt.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idTipoOperacion"]);
                        this.cboMonedaExt.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idMoneda"]);
                        this.txtMonOpeExt.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["nMontoOperacion"]);
                        this.txtClienteExto.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cNomCliente"]);
                        this.cboMotivoExtorno.SelectedValue = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idMotivo"]);
                        this.txtSustentoExt.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cSustento"]);
                        idMod = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idModulo"]);
                        idProd = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idProducto"]);
                        idEstKar = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idEstadoKardex"]);
                        idcli = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idCliAfeITF"]);
                        this.nudNroKardexSolExt.Enabled = false;
                        this.btnEnviar1.Enabled = false;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustentoExt.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nudNroKardexSolExt.Focus();
                        this.nudNroKardexSolExt.Select();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroKardexSolExt.Focus();
                    this.nudNroKardexSolExt.Select();
                }
            }
            else
            {
                MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardexSolExt.Focus();
                this.nudNroKardexSolExt.Select();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarControlesSolExt()
        {
            this.txtModuloExt.Clear();
            this.txtClienteExto.Clear();
            this.cboMonedaExt.SelectedIndex = -1;
            this.cboTipoOperacionExt.SelectedIndex = -1;
            this.txtMonOpeExt.Text = "0.00";
            this.cboMotivoExtorno.SelectedIndex = -1;
            this.txtSustentoExt.Clear();

        }
        private void ActualizarEstado()
        {
            String cCumpleReglas = "";

            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ObjCnValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name, clsVarGlobal.nIdAgencia, idcli,
                                               1, Convert.ToInt32(cboMonedaExt.SelectedValue), idProd,
                                               Decimal.Parse(txtMonOpeExt.Text), idSolAprob, clsVarGlobal.dFecSystem,
                                               2, Convert.ToInt32(cboEstadoSolic1.SelectedValue),
                                               clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("Cumple"))
            {
                int idKar = Convert.ToInt32(this.nudNroKardexSolExt.Text.ToString());
                int idTipOpe = Convert.ToInt32(this.cboTipoOperacionExt.SelectedValue.ToString());
                int idMon = Convert.ToInt32(this.cboMonedaExt.SelectedValue.ToString());
                Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpeExt.Text);
                int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                string cSust = this.txtSustentoExt.Text.Trim();
                int idEstSolicitud = 1;

                clsCNAprobacion dtSolApr = new clsCNAprobacion();
                DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nudNroKardexSolExt.Enabled = false;
                    this.btnEnviar1.Enabled = false;
                    this.cboMotivoExtorno.Enabled = false;
                    this.txtSustentoExt.Enabled = false;

                }
                else
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            if (cCumpleReglas.Equals("ExcepcionRechazada"))
            {
                int idKar = Convert.ToInt32(this.nudNroKardexSolExt.Text.ToString());
                int idTipOpe = Convert.ToInt32(this.cboTipoOperacionExt.SelectedValue.ToString());
                int idMon = Convert.ToInt32(this.cboMonedaExt.SelectedValue.ToString());
                Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpeExt.Text);
                int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                string cSust = this.txtSustentoExt.Text.Trim();
                int idEstSolicitud = 4;

                clsCNAprobacion dtSolApr = new clsCNAprobacion();
                DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nudNroKardexSolExt.Enabled = false;
                    this.btnEnviar1.Enabled = false;
                    this.cboMotivoExtorno.Enabled = false;
                    this.txtSustentoExt.Enabled = false;

                }
                else
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            DataTable dtConsultaSolApr = ObjCnValidaReglasDinamicas.CNConsultaEstExcepExtorno(idSolAprob, idProd, idcli, Convert.ToInt32(this.cboMonedaExt.SelectedValue.ToString()),
                                                                                        clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, Decimal.Parse(txtMonOpeExt.Text));
            if (dtConsultaSolApr.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtConsultaSolApr.Rows[0]["idEstadoSol"].ToString()) == 4)
                {
                    int idKar = Convert.ToInt32(this.nudNroKardexSolExt.Text.ToString());
                    int idTipOpe = Convert.ToInt32(this.cboTipoOperacionExt.SelectedValue.ToString());
                    int idMon = Convert.ToInt32(this.cboMonedaExt.SelectedValue.ToString());
                    Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpeExt.Text);
                    int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                    string cSust = this.txtSustentoExt.Text.Trim();
                    int idEstSolicitud = 4;

                    clsCNAprobacion dtSolApr = new clsCNAprobacion();
                    DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                    if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                    {
                        this.nudNroKardexSolExt.Enabled = false;
                        this.btnEnviar1.Enabled = false;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustentoExt.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idcli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSol";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = cboTipoOperacion.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue;
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
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void nudNroKardexSolExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 13))
            {
                BuscarOperacionSol(Convert.ToInt32(this.nudNroKardexSolExt.Value));

            }
        }

        private void btnlimpiarSoli_Click(object sender, EventArgs e)
        {
            this.txtModuloExt.Clear();
            this.txtClienteExto.Clear();
            this.cboMonedaExt.SelectedIndex = -1;
            this.cboTipoOperacionExt.SelectedIndex = -1;
            this.txtMonOpeExt.Text = "0.00";
            this.cboMotivoExtorno.SelectedIndex = -1;
            this.txtSustentoExt.Clear();
            LiberarCuenta();
            nudNroKardexSolExt.Value = 0;
            nudNroKardexSolExt.Enabled = true;
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nudNroKardexSolExt.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor Registrar ", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardexSolExt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtModuloExt.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Registrar la Solicitud", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardexSolExt.Focus();
                return;
            }

            if (this.cboMotivoExtorno.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMotivoExtorno.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.cboMotivoExtorno.Text))
            {
                MessageBox.Show("Debe Seleccionar el Motivo del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMotivoExtorno.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtSustentoExt.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardexSolExt.Focus();
                return;
            }

            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================

            int idKar = Convert.ToInt32(this.nudNroKardexSolExt.Text.ToString());
            int idTipOpe = Convert.ToInt32(this.cboTipoOperacionExt.SelectedValue.ToString());
            int idMon = Convert.ToInt32(this.cboMonedaExt.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpeExt.Text);
            int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
            string cSust = this.txtSustentoExt.Text.Trim();

            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, idcli, Convert.ToInt32(cboTipoOperacionExt.SelectedValue), 2,
                                                                Convert.ToInt16(cboMonedaExt.SelectedValue), idProd, Convert.ToDecimal(txtMonOpeExt.Text),
                                                               Convert.ToInt32(nudNroKardexSolExt.Value), clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivoExtorno.SelectedValue),
                                                                txtSustentoExt.Text, 0, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                idSolAprob = Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]);
                this.nudNroKardexSolExt.Enabled = false;
                this.btnEnviar1.Enabled = false;
                this.cboMotivoExtorno.Enabled = false;
                this.txtSustentoExt.Enabled = false;
                if (Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]) == 4)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ActualizarEstado();
        }
    }
}
