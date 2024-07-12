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
using EntityLayer;
using CRE.CapaNegocio;
using SPL.Presentacion;
using GEN.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using DEP.CapaNegocio;
using GEN.Servicio;
namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioDesembolso : frmBase
    {
        #region Variables Globales
        private CRE.CapaNegocio.clsCNGrupoSolidario objCNGrupoSolidario;
        private GEN.CapaNegocio.clsCNCredito objCNCredito;
        private clsCNDeposito objCNDeposito;
        private List<clsGrupoSolidarioBono> lstGrupoSolidarioBono;
        private List<clsDesembolsoSolicitud> lstDesembolsoSolicitud;
        private List<clsGrupoSolidarioAhorro> lstGrupoSolidarioAhorro;
        private BindingSource bsDesembolsoSolicitud;

        private clsFunUtiles objFunUtiles;
        private clsCNValidaReglasDinamicas objValidaReglasDinamicas;
        private clsExpedienteLinea objExpedienteLinea;

        private int idGrupoSolidario;
        private int idSolicitudCredGrupoSol;
        private int idOperacion;
        private int idModalidadCredito;
        private bool lErrorDesembolso;
        private int nAhorroSuficiente;

        private int nIndiceFila;

        private const int idTipoOpeRegimenReforzado = 168;
        private bool lExisteBonos;
        #endregion
        public frmGrupoSolidarioDesembolso()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNGrupoSolidario = new CRE.CapaNegocio.clsCNGrupoSolidario();
            this.objCNCredito = new GEN.CapaNegocio.clsCNCredito();
            this.objCNDeposito = new clsCNDeposito();
            this.lstGrupoSolidarioBono = new List<clsGrupoSolidarioBono>();
            this.lstDesembolsoSolicitud = new List<clsDesembolsoSolicitud>();
            this.lstGrupoSolidarioAhorro = new List<clsGrupoSolidarioAhorro>();
            this.bsDesembolsoSolicitud = new BindingSource();

            this.objFunUtiles = new clsFunUtiles();
            this.objValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            this.objExpedienteLinea = new clsExpedienteLinea();

            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idOperacion = 0;
            this.idModalidadCredito = 0;
            this.lErrorDesembolso = false;
            this.nAhorroSuficiente = 0;

            this.nIndiceFila = -1;
            this.lExisteBonos = true;

            this.bsDesembolsoSolicitud.DataSource = this.lstDesembolsoSolicitud;
            this.dtgDesembolsoSolicitud.DataSource = this.bsDesembolsoSolicitud;

            this.formatearSolicitud();
            this.mensajeProceso(string.Empty);
            this.habilitarControles(clsAcciones.DEFECTO);
        }
        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.btnEjecutar.Enabled = false;
                    this.btnBloquear.Visible = false;
                    this.btnDepositar.Visible = (this.idGrupoSolidario>0 && this.idSolicitudCredGrupoSol>0);
                    break;
                case clsAcciones.RECUPERAR:
                    this.btnEjecutar.Enabled = true;
                    this.btnBloquear.Visible = false;
                    this.btnDepositar.Visible = false;
                    break;
                case clsAcciones.BUSCAR:
                    this.btnEjecutar.Enabled = true;
                    this.btnBloquear.Visible = (this.lErrorDesembolso)? true : false;
                    this.btnDepositar.Visible = (this.lErrorDesembolso)? true : false;
                    break;
                case clsAcciones.FINALIZAR:
                    this.btnEjecutar.Enabled = false;
                    this.btnBloquear.Visible = false;
                    this.btnDepositar.Visible = false;
                    break;
                case clsAcciones.RESOLVER:
                    this.dtgDesembolsoSolicitud.Enabled = false;
                    this.btnEjecutar.Enabled = false;
                    this.btnBloquear.Visible = true;
                    this.btnDepositar.Visible = false;
                    break;
            }
        }
        private void limpiarControles()
        {
            this.mensajeProceso(string.Empty, string.Empty, Estado.NINGUNO);
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.idOperacion = 0;
            this.idModalidadCredito = 0;
            this.lstDesembolsoSolicitud.Clear();
            this.bsDesembolsoSolicitud.ResetBindings(false);
            this.dtgDesembolsoSolicitud.Refresh();

            this.lblFechaProg.Text = string.Empty;
            this.lblFechaSolicitud.Text = string.Empty;            
            this.lblModalidadDes.Text = string.Empty;
            this.lblMoneda.Text = string.Empty;
            this.txtMontoTotal.Text = "0.00";

            this.lblClienteProcesado.Text = "NOMBRE DE CLIENTE PROCESADO";
            this.lblMensajeProceso.Text = "Mensaje de proceso.";

            this.conBusGrupoSol.LimpiarControl();
            this.habilitarControles(clsAcciones.DEFECTO);
        }
        private void formatearSolicitud()
        {
            foreach (DataGridViewColumn dgvColumn in this.dtgDesembolsoSolicitud.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dtgDesembolsoSolicitud.Columns["idSolicitud"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["cCliente"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["cEstado"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nMontoCuota"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nImpuestos"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nSeguros"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nCapitalAprobado"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nMontoRedondeo"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["nMontoEntrega"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["lAhorroBloqueado"].Visible = true;
            this.dtgDesembolsoSolicitud.Columns["lBonoGestionado"].Visible = true;

            this.dtgDesembolsoSolicitud.Columns["idSolicitud"].HeaderText = "Solicitud";
            this.dtgDesembolsoSolicitud.Columns["cCliente"].HeaderText = "Cliente";
            this.dtgDesembolsoSolicitud.Columns["cEstado"].HeaderText = "Estado";
            this.dtgDesembolsoSolicitud.Columns["nMontoCuota"].HeaderText = "1a Cuota";
            this.dtgDesembolsoSolicitud.Columns["nImpuestos"].HeaderText = "Impuestos";
            this.dtgDesembolsoSolicitud.Columns["nSeguros"].HeaderText = "Seguros";
            this.dtgDesembolsoSolicitud.Columns["nCapitalAprobado"].HeaderText = "Capital";
            this.dtgDesembolsoSolicitud.Columns["nMontoRedondeo"].HeaderText = "Redondeo";
            this.dtgDesembolsoSolicitud.Columns["nMontoEntrega"].HeaderText = "A Entregar";
            this.dtgDesembolsoSolicitud.Columns["lAhorroBloqueado"].HeaderText = "Aho. Bloq.";
            this.dtgDesembolsoSolicitud.Columns["lBonoGestionado"].HeaderText = "Bono Gest.";

            this.dtgDesembolsoSolicitud.Columns["idSolicitud"].FillWeight = 20;
            this.dtgDesembolsoSolicitud.Columns["cCliente"].FillWeight = 100;
            this.dtgDesembolsoSolicitud.Columns["cEstado"].FillWeight = 30;
            this.dtgDesembolsoSolicitud.Columns["nMontoCuota"].FillWeight = 20;
            this.dtgDesembolsoSolicitud.Columns["nImpuestos"].FillWeight = 22;
            this.dtgDesembolsoSolicitud.Columns["nSeguros"].FillWeight = 22;
            this.dtgDesembolsoSolicitud.Columns["nCapitalAprobado"].FillWeight = 30;
            this.dtgDesembolsoSolicitud.Columns["nMontoRedondeo"].FillWeight = 25;
            this.dtgDesembolsoSolicitud.Columns["nMontoEntrega"].FillWeight = 30;
            this.dtgDesembolsoSolicitud.Columns["lAhorroBloqueado"].FillWeight = 12;
            this.dtgDesembolsoSolicitud.Columns["lBonoGestionado"].FillWeight = 12;

            this.dtgDesembolsoSolicitud.Columns["nMontoCuota"].DefaultCellStyle.Format = "###,##0.00";
            this.dtgDesembolsoSolicitud.Columns["nImpuestos"].DefaultCellStyle.Format = "###,##0.00";
            this.dtgDesembolsoSolicitud.Columns["nSeguros"].DefaultCellStyle.Format = "###,##0.00";
            this.dtgDesembolsoSolicitud.Columns["nCapitalAprobado"].DefaultCellStyle.Format= "###,###,##0.00";
            this.dtgDesembolsoSolicitud.Columns["nMontoRedondeo"].DefaultCellStyle.Format = "###,###,##0.00";
            this.dtgDesembolsoSolicitud.Columns["nMontoEntrega"].DefaultCellStyle.Format = "###,###,##0.00";
        }
        public void colorearGrupoSolidarioDesembolso()
        {
            foreach (DataGridViewRow dtgRow in this.dtgDesembolsoSolicitud.Rows)
            {
                clsDesembolsoSolicitud objDesembolsoSolicitud = (clsDesembolsoSolicitud)dtgRow.DataBoundItem;
                if (!objDesembolsoSolicitud.lAhorroBloqueado || !objDesembolsoSolicitud.lBonoGestionado)
                {
                    dtgRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffad99");
                }
                else if (objDesembolsoSolicitud.idEstado == (int)EstadoCredito.Activo)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else if (objDesembolsoSolicitud.idEstado == (int)EstadoCredito.Aprobado)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }
        private void listarDesembolsoSolicitudGrupoSolidario()
        {
            this.lstDesembolsoSolicitud.Clear();
            this.lstDesembolsoSolicitud.AddRange(this.objCNGrupoSolidario.listarDesembolsoSolicitudGrupoSolidario(this.idGrupoSolidario));

            if (this.lstDesembolsoSolicitud.Count > 0)
            {
                this.idSolicitudCredGrupoSol = this.lstDesembolsoSolicitud[0].idSolicitudCredGrupoSol;
                this.idOperacion = this.lstDesembolsoSolicitud[0].idOperacion;
                this.idModalidadCredito = this.lstDesembolsoSolicitud[0].idModalidadCredito;
                this.habilitarControles(clsAcciones.RECUPERAR);
                this.mostrarDatosGrupo();
                this.calcularMontoEntrega();
                if (this.idModalidadCredito == (int)ModalidadCredito.Principal)
                {
                    this.validarCuentasAhorro();
                }
            }
            else
            {
                MessageBox.Show("¡El grupo solidario no tiene solicitudes de crédito para desembolsar!\n\n"
                    +"* Revise que el plan de pagos haya sido generado y grabado correctamente.","RESULTADO VACIO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.limpiarControles();
            }
            this.bsDesembolsoSolicitud.ResetBindings(false);
            this.dtgDesembolsoSolicitud.Refresh();
            this.dtgDesembolsoSolicitud.ClearSelection();
        }
        private void calcularMontoEntrega()
        {
            foreach (clsDesembolsoSolicitud objDesembolsoSolicitud in this.lstDesembolsoSolicitud)
            {                
                objDesembolsoSolicitud.nImpuestos = objDesembolsoSolicitud.nMontoRoundITF;
                objDesembolsoSolicitud.lRestarITF = rbtRestarItfSi.Checked;
                if (objDesembolsoSolicitud.lRestarITF)
                {
                    if (this.idOperacion == (int)OperacionCredito.Ampliacion)
                    {
                        decimal nMontoResumen = decimal.Zero;
                        decimal nMontoCancelacion = (objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nMontoAmpliado);

                        decimal nMonITFCancel = objFunUtiles.truncar(objDesembolsoSolicitud.nFactorITF * nMontoCancelacion, 2, objDesembolsoSolicitud.IdMoneda);

                        nMontoCancelacion = nMontoCancelacion + nMonITFCancel;
                        if (objDesembolsoSolicitud.idModalidadDes == (int)ModalidadDesembolso.Efectivo)
                        {
                            nMontoCancelacion = (Math.Floor(nMontoCancelacion * 10)) / 10;
                        }
                        else
                        {
                            nMontoCancelacion = nMontoCancelacion - (nMontoCancelacion % Convert.ToDecimal(0.05));
                        }

                        decimal nMontoDesembolso = objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nMontoRoundITF;
                        nMontoDesembolso = nMontoDesembolso - (nMontoDesembolso % Convert.ToDecimal(0.05));

                        nMontoResumen = nMontoDesembolso - nMontoCancelacion;

                        objDesembolsoSolicitud.nMontoEntrega = nMontoResumen + objDesembolsoSolicitud.nMontoRedondeo;

                    }
                    else
                    {
                        objDesembolsoSolicitud.nMontoEntrega = objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nMontoRoundITF + objDesembolsoSolicitud.nMontoRedondeo;

                    }
                }
                else
                {
                    if (this.idOperacion == (int)OperacionCredito.Ampliacion)
                    {
                        decimal nMontoResumen = decimal.Zero;
                        decimal nMontoCancelacion = (objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nMontoAmpliado);
                        nMontoCancelacion = nMontoCancelacion
                            + objFunUtiles.truncar(objDesembolsoSolicitud.nFactorITF * nMontoCancelacion, 2, objDesembolsoSolicitud.IdMoneda);
                        nMontoCancelacion = nMontoCancelacion - (nMontoCancelacion % Convert.ToDecimal(0.05));

                        decimal nMontoDesembolso = objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nMontoRoundITF;
                        nMontoDesembolso = nMontoDesembolso - (nMontoDesembolso % Convert.ToDecimal(0.05));

                        nMontoResumen = nMontoDesembolso - nMontoCancelacion;

                        objDesembolsoSolicitud.nMontoEntrega = nMontoResumen;
                    }
                    else
                    {
                        objDesembolsoSolicitud.nMontoEntrega =
                            objDesembolsoSolicitud.nCapitalAprobado;
                    }
                }
            }
        }
        private void mostrarDatosGrupo()
        {
            this.lblFechaProg.Text = this.lstDesembolsoSolicitud[0].dFechaProg.ToString("dd/MM/yyyy");
            this.lblMoneda.Text = "SOLES";
            this.lblFechaSolicitud.Text = this.lstDesembolsoSolicitud[0].dFechaRegistro.ToString("dd/MM/yyyy");
            this.lblModalidadDes.Text = "EFECTIVO";
            this.txtMontoTotal.Text = this.lstDesembolsoSolicitud.Sum(x => x.nCapitalAprobado).ToString("###,###,##0.00");
        }
        private void desembolsarCreditosGrupo()
        {
            this.habilitarControles(clsAcciones.FINALIZAR);

            //Validamos solicitudes de aprobación pendientes
            if (this.lstDesembolsoSolicitud.Any(objDesembolsoSolicitud => !ValidarSolicitudPendientePlanSeguro(objDesembolsoSolicitud.idSolicitud)))
                return;

            foreach (clsDesembolsoSolicitud objDesembolsoSolicitud in this.lstDesembolsoSolicitud)
            {
                if(objDesembolsoSolicitud.idEstado != (int)EstadoCredito.Aprobado)
                {
                    continue;
                }
                if (this.lErrorDesembolso)
                {
                    this.habilitarControles(clsAcciones.BUSCAR);
                    return;
                }
                this.lErrorDesembolso = false;
                this.colorearGrupoSolidarioDesembolso();
                this.desembolsarCredito(objDesembolsoSolicitud);
            }

            if (!this.lErrorDesembolso)
            {
                this.imprimirVoucherGrupo();
            }
            this.dtgDesembolsoSolicitud.Refresh();
            this.colorearGrupoSolidarioDesembolso();
        }
        private bool validarSaldoEnLinea()
        {
            decimal nMontoEntregaTotal = decimal.Zero;
            if (this.idOperacion == (int)OperacionCredito.Ampliacion)
            {
               nMontoEntregaTotal = this.lstDesembolsoSolicitud.Where(x => x.idEstado == (int)EstadoCredito.Aprobado).Sum(x => x.nMontoEntrega);
            }
            else
            {
               nMontoEntregaTotal = this.lstDesembolsoSolicitud.Where(x => x.idEstado == (int)EstadoCredito.Aprobado).Sum(x => x.nCapitalAprobado);
            }

            return !ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                   lstDesembolsoSolicitud[0].IdMoneda, 2, nMontoEntregaTotal);
        }
        private void validarCuentasAhorro()
        {
            frmGrupoSolidarioVincularAhorro objFrmGrupoSolidarioVincularAhorro = new frmGrupoSolidarioVincularAhorro(this.idGrupoSolidario, this.idSolicitudCredGrupoSol, this.idOperacion, true);
            objFrmGrupoSolidarioVincularAhorro.ShowDialog();
            this.nAhorroSuficiente = objFrmGrupoSolidarioVincularAhorro.nAhorroSuficiente;
            this.lstGrupoSolidarioAhorro = objFrmGrupoSolidarioVincularAhorro.obtenerGrupoSolidarioAhorro();
            if (this.nAhorroSuficiente < this.lstDesembolsoSolicitud.Count)
            {
                MessageBox.Show("Queda(n) " + (this.lstDesembolsoSolicitud.Count - this.nAhorroSuficiente) +
                " integrante(s) que no dispone(n) de monto ahorrado suficiente.\n" +
                "*No se permitirá ejecutar el desembolso hasta que todos los integrantes cumplan con la condición de monto ahorrado.",
                "AHORRO INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.habilitarControles(clsAcciones.DEFECTO);
            }
            else
            {
                this.habilitarControles(clsAcciones.RECUPERAR);
            }

            List<clsGrupoSolidarioAhorro> lstGSAhorroCopia = this.lstGrupoSolidarioAhorro.Select(x => x).ToList();
            foreach(clsDesembolsoSolicitud objDesembolsoSolicitud in this.lstDesembolsoSolicitud)
            {
                clsGrupoSolidarioAhorro objGSAhorro = lstGSAhorroCopia.Find(x => x.idCliente == objDesembolsoSolicitud.idCli);
                objDesembolsoSolicitud.lAhorroBloqueado = (objGSAhorro != null) ? objGSAhorro.lAhorroBloqueado : false;
                objDesembolsoSolicitud.lBonoGestionado = (objGSAhorro != null)? objGSAhorro.lBonoGestionado : false;

                if (objGSAhorro != null)
                    lstGSAhorroCopia.Remove(objGSAhorro);
            }
        }
        private void desembolsarCredito(clsDesembolsoSolicitud objDesembolsoSolicitud)
        {
            if (!this.validarDesembolso(objDesembolsoSolicitud))
            {
                this.lErrorDesembolso = true;
                return;
            }

            if(objDesembolsoSolicitud.idModalidadDes == (int)ModalidadDesembolso.Efectivo)
            {
                decimal nMonto;

                if (objDesembolsoSolicitud.idOperacion == (int)OperacionCredito.Ampliacion) // Ampliacion
                {
                    nMonto = decimal.Zero;
                }
                else
                {
                    nMonto = objDesembolsoSolicitud.nCapitalAprobado;
                }

                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                   objDesembolsoSolicitud.IdMoneda, 2, nMonto - objDesembolsoSolicitud.nImpuestos))
                {
                    this.lErrorDesembolso = true;
                    return;
                }
            }

            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = objDesembolsoSolicitud.nCapitalAprobado;
            int idMonedaUm = objDesembolsoSolicitud.IdMoneda;
            int idMotivoOpe = (objDesembolsoSolicitud.idModalidadDes == 4) ? 14 : 13;
            int idSubProducto = objDesembolsoSolicitud.idProducto;
            int idTipoPago = 1;
            int idTipoOperacion = 1;

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
            {
                this.lErrorDesembolso = true;
                return;
            }

            #endregion

            grabarDesembolso(objDesembolsoSolicitud);
            if (lErrorDesembolso)
            {
                this.mensajeProceso("Error de desembolso. Proceso detenido.", objDesembolsoSolicitud.cCliente, Estado.DENEGADO); 
                return;
            }

            clsCNImpresion Imprimir = new clsCNImpresion();
            //Emision de Voucher Desembolso
            ImpresionVoucher(nIdKardex: objDesembolsoSolicitud.idKardexDesembolso, idModulo: 1, idTipoOpe: 1, idEstadoKardex: 1,
                            nValRec: 0,
                            nValdev: 0,
                            idKardexAd: 0, idTipoImpresion: 1);

            if (objDesembolsoSolicitud.idModalidadDes == (int)ModalidadDesembolso.TransferenciaCuenta )
            {
                /*===============================================================================
                  REALIZA VALIDACION DE REGISTRO DE OPERACIONES SPLAFT
                  ===============================================================================*/
                //Solo para el Deposito a Cuenta
                frmRegOpeSplaft regope = new frmRegOpeSplaft(objDesembolsoSolicitud.idKardexAhorro, 2);
            }

            //Validacion de Declaracion Jurada de Sujetos Obligados
            frmDeclaracionJurada declara = new frmDeclaracionJurada(objDesembolsoSolicitud.idCli);

            //Guardar Expedientes - Grupo Desembolso
            bool lExpedienteGrabado = this.objExpedienteLinea.guardarCopiaExpediente("Desembolso de Credito", objDesembolsoSolicitud.idSolicitud, this, "individual", false);
            if (!lExpedienteGrabado)
            {
                DialogResult dlgResult = MessageBox.Show("¡Ha ocurrido un error al intentar CONGELAR los EXPEDIENTES DE DESEMBOLSO!\n"+
                    "Cliente: " + objDesembolsoSolicitud.cCliente + "\n"+
                    "Solicitud: " + objDesembolsoSolicitud.idSolicitud.ToString() + "\n\n" +
                    "* Se le sugiere consultar con el área de GESTION DE SISTEMAS antes de continuar, sin embargo puede continuar con el proceso de DESEMBOLSO GRUPAL bajo su responsabilidad.\n\n" +
                    "¿Desea continuar con el proceso de DESEMBOLSO GRUPAL asumiendo la responsabilidad sobre el incidente de CONGELADO DE EXPEDIENTE DE DESEMBOLSO?",
                    "ERROR DE GRABADO DE EXPEDIENTES",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlgResult != DialogResult.Yes)
                {
                    this.lErrorDesembolso = true;
                    return;
                }
            }

            if (this.idModalidadCredito == (int)ModalidadCredito.Principal)
            {
                this.bloquearCuentaAhorro(objDesembolsoSolicitud);
            }
            this.mensajeProceso("Desembolso completo.", objDesembolsoSolicitud.cCliente, Estado.APROBADO);
        }
        private bool validarClientePepYRegimenCli()
        {
            bool lPendiente = false;
            foreach (clsDesembolsoSolicitud objDesembolsoSolicitud in this.lstDesembolsoSolicitud)
            {
                //VALIDA CLIENTE PEP
                string mensaje = "", cNumeroDni = "";
                int x_idEstApr = 0;
                if (!conSplaf.ValidaAprobacionClientePep(objDesembolsoSolicitud.idCli, ref mensaje, ref cNumeroDni, ref x_idEstApr))
                {
                    MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (x_idEstApr == 1) //--Solicitado
                    {
                        frmPep frmPepx = new frmPep(objDesembolsoSolicitud.idTipoDocumento, cNumeroDni);
                        frmPepx.ShowDialog();
                    }
                    lPendiente = true;
                }

                /*========================================================================================
                * VALIDACIONES PARA REGIMEN DEL CLIENTE
                ========================================================================================*/
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(objDesembolsoSolicitud.idCli,
                                                                                   objDesembolsoSolicitud.IdMoneda,
                                                                                   objDesembolsoSolicitud.idProducto,
                                                                                   objDesembolsoSolicitud.idCuenta,
                                                                                   objDesembolsoSolicitud.idOperacion == (int)OperacionCredito.Ampliacion ? decimal.Zero :
                                                                                                           objDesembolsoSolicitud.nCapitalAprobado);
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                {
                    lPendiente = true;
                }
            }
            return !lPendiente;
        }
        private bool regularizarBloqueoCuentasYBonos()
        {
            this.lErrorDesembolso = false;            
            foreach(clsDesembolsoSolicitud objDesembolsoSolicitud in this.lstDesembolsoSolicitud)
            {
                if (objDesembolsoSolicitud.idEstado == (int)EstadoCredito.Activo && !objDesembolsoSolicitud.lAhorroBloqueado)
                {
                    this.bloquearCuentaAhorro(objDesembolsoSolicitud);
                    if (this.lErrorDesembolso)
                    {
                        this.lErrorDesembolso = false;
                        return false;
                    }
                }
            }
            this.lErrorDesembolso = false;
            return true;
        }
        private void grabarDesembolso(clsDesembolsoSolicitud objDesembolsoSolicitud)
        {
            if (objDesembolsoSolicitud.idCuenta <= 0)
            {
                MessageBox.Show("Solicitud no tiene Plan de Pagos generado", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lErrorDesembolso = true;
                return;
            }
            this.mensajeProceso("Desembolsando crédito ...", objDesembolsoSolicitud.cCliente, Estado.APROBADO);

            int idSolicitud = objDesembolsoSolicitud.idSolicitud;
            int idOperacion = objDesembolsoSolicitud.idOperacion;

            int dtNumCre = objDesembolsoSolicitud.idCuenta;

            int idTipoDesembolso = objDesembolsoSolicitud.idModalidadDes;

            if (objDesembolsoSolicitud.idCuenta > 0)
            {
                objDesembolsoSolicitud.idTipoCliente = 2;
            }
            else
            {
                objDesembolsoSolicitud.idTipoCliente = 1;
            }

            List<clsDesembolsoSolicitud> lstCredito= new List<clsDesembolsoSolicitud>();
            lstCredito.Add(objDesembolsoSolicitud);

            string XmlCredito = lstCredito.ListObjectToXml<clsDesembolsoSolicitud>("Table1", "dscredito");
            XmlCredito = clsCNFormatoXML.EncodingXML(XmlCredito);

            clsCreditoDesembolsoCuentaParametro objDesembolsoTransferencia = new clsCreditoDesembolsoCuentaParametro();
            objDesembolsoTransferencia.idModalidadDesembolso = (int)ModalidadDesembolso.Efectivo;
            string xmlParametrosDesembolso = clsCNFormatoXML.EncodingXML(Convert.ToString(System.Security.SecurityElement.FromString(objDesembolsoTransferencia.SerializeToString())));

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 2; //EGRESO

            if (idTipoDesembolso == (int)ModalidadDesembolso.Efectivo)
                lModificaSaldoLinea = true;

            if (objDesembolsoSolicitud.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                DataTable dtCanCreAmp = new DataTable();
                dtCanCreAmp = objCNCredito.CNDesembolsoCreXAmpliacion(
                    XmlCredito,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    clsVarGlobal.nIdAgencia,
                    objDesembolsoSolicitud.idSolicitud,
                    objDesembolsoSolicitud.nMontoRoundITF,
                    clsVarGlobal.idCanal,
                    objDesembolsoSolicitud.nMontoNormalITF,
                    idTipoDesembolso,
                    xmlParametrosDesembolso,
                    objDesembolsoSolicitud.IdMoneda,
                    idTipoTransac,
                    objDesembolsoSolicitud.nMontoEntrega,
                    lModificaSaldoLinea
                    );

                if (dtCanCreAmp.AsEnumerable().Any(item => Convert.ToInt32(item["idEstadoOperacion"]) == 0))
                {
                    foreach (DataRow drError in dtCanCreAmp.Rows)
                    {
                        MessageBox.Show(Convert.ToString(drError["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lErrorDesembolso = true;
                    return;
                }
                else
                {
                    DataRow drResultadoDesembolso = (dtCanCreAmp.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 1).ToArray())[0];
                    objDesembolsoSolicitud.idEstado = (int)EstadoCredito.Activo;
                    objDesembolsoSolicitud.cEstado = "ACTIVO";
                    objDesembolsoSolicitud.idKardexDesembolso = Convert.ToInt32(drResultadoDesembolso["Kardex"]);

                    if (dtCanCreAmp.AsEnumerable().Any(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2))
                    {
                        DataRow drResultadoDeposito = (dtCanCreAmp.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2).ToArray())[0];
                        objDesembolsoSolicitud.idKardexAhorro = Convert.ToInt32(drResultadoDeposito["Kardex"]);
                    }
                }
            }
            else
            {
                DataTable dtCre = new DataTable();
                dtCre = objCNCredito.Desembolsa(
                    XmlCredito,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    clsVarGlobal.nIdAgencia,
                    objDesembolsoSolicitud.nMontoRoundITF,
                    clsVarGlobal.idCanal,
                    objDesembolsoSolicitud.nMontoNormalITF,
                    idTipoDesembolso,
                    1,
                    xmlParametrosDesembolso,
                    objDesembolsoSolicitud.IdMoneda,
                    idTipoTransac,
                    objDesembolsoSolicitud.nCapitalAprobado - objDesembolsoSolicitud.nImpuestos + objDesembolsoSolicitud.nMontoRedondeo,
                    lModificaSaldoLinea
                );

                if (dtCre.AsEnumerable().Any(item => Convert.ToInt32(item["idEstadoOperacion"]) == 0))
                {
                    foreach (DataRow drError in dtCre.Rows)
                    {
                        MessageBox.Show(Convert.ToString(drError["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lErrorDesembolso = true;
                    return;
                }
                else
                {
                    DataRow drResultadoDesembolso = (dtCre.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 1).ToArray())[0];
                    objDesembolsoSolicitud.idEstado = (int)EstadoCredito.Activo;
                    objDesembolsoSolicitud.cEstado = "ACTIVO";
                    objDesembolsoSolicitud.idKardexDesembolso = Convert.ToInt32(drResultadoDesembolso["Kardex"]);

                    if (dtCre.AsEnumerable().Any(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2))
                    {
                        DataRow drResultadoDeposito = (dtCre.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2).ToArray())[0];
                        objDesembolsoSolicitud.idKardexAhorro = Convert.ToInt32(drResultadoDeposito["Kardex"]);
                    }
                }
            }
            // RQ-412 Integracion de Saldos en Linea
            new Semaforo().ValidarSaldoSemaforo();

            MessageBox.Show("Crédito Desembolsado Correctamente.\nCliente: " + objDesembolsoSolicitud.cCliente, "DESEMBOLSO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void bloquearCuentaAhorro(clsDesembolsoSolicitud objDesembolsoSolicitud)
        {
            this.mensajeProceso("Iniciando bloqueo cuenta de ahorro ...", objDesembolsoSolicitud.cCliente, Estado.OBSERVADO);
            clsGrupoSolidarioAhorro objGrupoSolidarioAhorro = this.lstGrupoSolidarioAhorro.Find(x => x.idCliente == objDesembolsoSolicitud.idCli);
            if (!(objGrupoSolidarioAhorro != null))
            {
                MessageBox.Show("Los datos de la cuenta de ahorro no fueron encontrados.\n"+
                "* Intente bloquear la cuenta nuevamente.","OBJETO NO ENCONTRADO",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mensajeProceso("Error iniciando bloqueo cuenta de ahorro.", objDesembolsoSolicitud.cCliente, Estado.DENEGADO);
                this.lErrorDesembolso = true;
                return;
            }

            if (objGrupoSolidarioAhorro.lAhorroBloqueado)
            {
                MessageBox.Show("La cuenta de ahorro N°: " + objGrupoSolidarioAhorro.idCuentaAhorro +
                " ya fué bloquedo para este cliente.","BLOQUEO EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mensajeProceso("Error iniciando bloqueo cuenta de ahorro.", objDesembolsoSolicitud.cCliente, Estado.DENEGADO);
                this.lErrorDesembolso = false;

                if (!objGrupoSolidarioAhorro.lBonoGestionado)
                {
                    this.mensajeProceso("Gestionando Bono de Cumplimiento ...", objDesembolsoSolicitud.cCliente, Estado.OBSERVADO);
                    objDesembolsoSolicitud.lBonoGestionado = objGrupoSolidarioAhorro.lBonoGestionado = this.gestionarGrupoSolidarioBono(objDesembolsoSolicitud.idCli, objDesembolsoSolicitud.cCliente);
                }
                else
                {
                    MessageBox.Show("El Bono de cumplimiento de cuota ya fue gestionado para " + objDesembolsoSolicitud.cCliente,
                        "BLOQUEO EXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    objDesembolsoSolicitud.lBonoGestionado = true;
                }
                return;
            }

            clsBloqueoCuenta objBloqueoCuenta = new clsBloqueoCuenta();
            objBloqueoCuenta.idCuenta = objGrupoSolidarioAhorro.idCuentaAhorro;
            objBloqueoCuenta.idBloqueo = (int)Bloqueo.DesembolsoGrupoSolidario;
            objBloqueoCuenta.idCaracteristicaBloq = (int)CaracteristicaBloqueo.BloqueoParcial;
            objBloqueoCuenta.nMonBloqueo = objGrupoSolidarioAhorro.nMontoBloqueo;
            objBloqueoCuenta.cDesMotivo = string.Concat("DESEMBOLSO GRUPO SOLIDARIO CRÉDITO NRO. ", objDesembolsoSolicitud.idCuenta.ToString());
            objBloqueoCuenta.lBloqueado = true;
            objBloqueoCuenta.dFechaDocBloqueo = clsVarGlobal.dFecSystem;
            objBloqueoCuenta.lVigente = true;
            objBloqueoCuenta.idTipoSolicitante = (int)TipoSolicitanteBloq.Interno;
            objBloqueoCuenta.cNombreSolicitante = clsVarGlobal.User.cNomUsu;

            List<clsBloqueoCuenta> lstBloqueoCuenta = new List<clsBloqueoCuenta>();
            lstBloqueoCuenta.Add(objBloqueoCuenta);
            string xmlBloqueoCuenta = string.Empty;
            xmlBloqueoCuenta = lstBloqueoCuenta.ListObjectToXml("BloqueoCuenta", "BloqueoCuentas");

            this.mensajeProceso("Bloqueando cuenta de ahorro ...", objDesembolsoSolicitud.cCliente, Estado.APROBADO);            
            clsRespuestaServidor objRespuestaServidor = this.objCNDeposito.grabarBloqueoCuentaGrupoSol(
                objDesembolsoSolicitud.idGrupoSolidario, objDesembolsoSolicitud.idSolicitudCredGrupoSol, objGrupoSolidarioAhorro.idOperacion,
                xmlBloqueoCuenta, string.Empty, true, 0, string.Empty);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, "BLOQUEO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objGrupoSolidarioAhorro.lAhorroBloqueado = true;
                objDesembolsoSolicitud.lAhorroBloqueado = true;
                if(objDesembolsoSolicitud.idModalidadCredito != 1/*PRINCIPAL*/)
                {
                    MessageBox.Show("¡Los créditos en modalidades PARALELO o ESTACIONAL no aplican para la entrega del Bono de Cumplimiento!\n\n" +
                    "* Se continuará con el proceso de desembolso grupal omitiendo este paso.",
                        "NO APLICA PARA BONO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(!objGrupoSolidarioAhorro.lBonoGestionado)
                {
                    this.mensajeProceso("Gestionando Bono de Cumplimiento ...", objDesembolsoSolicitud.cCliente, Estado.OBSERVADO);
                    objDesembolsoSolicitud.lBonoGestionado = objGrupoSolidarioAhorro.lBonoGestionado = this.gestionarGrupoSolidarioBono(objDesembolsoSolicitud.idCli, objDesembolsoSolicitud.cCliente);
                }
            }
            else
            {
                this.mensajeProceso("Error de bloqueo de cuenta de ahorro.", objDesembolsoSolicitud.cCliente, Estado.DENEGADO);
                MessageBox.Show(objRespuestaServidor.cMensaje + "\n" +
                "¡Intente bloquear la cuenta de forma manual haciendo clic en el botón <Bloquear>!" +
                "* No se le permitirá continuar con el desembolso hasta que haya bloqueado la cuenta." +
                "* No se gestionará su posible entrega de Bono por Cumplimiento", "ERROR DE GRABADO DE BLOQUEO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.habilitarControles(clsAcciones.RESOLVER);
                this.lErrorDesembolso = true;
            }

        }
        private bool gestionarGrupoSolidarioBono(int idCli, string cCliente = "")
        {
            if (this.lExisteBonos && this.lstGrupoSolidarioBono.Count == 0)
            {
                this.lstGrupoSolidarioBono.Clear();
                this.lstGrupoSolidarioBono.AddRange(this.objCNGrupoSolidario.listarGrupoSolidarioBonoEstimado(this.idGrupoSolidario, this.idSolicitudCredGrupoSol, this.idOperacion));
                if (this.lstGrupoSolidarioBono.Count == 0 ||
                    (this.lstGrupoSolidarioBono.Exists(x=>x.idEstado!=(int)EstadoCredito.Cancelado) && this.idOperacion!=(int)OperacionCredito.Ampliacion))
                {
                    this.lExisteBonos = false;
                }
            }

            if (this.lExisteBonos)
            {

                clsGrupoSolidarioBono objGrupoSolidarioBono = this.lstGrupoSolidarioBono.Find(x=>x.idCli == idCli);
                if (!(objGrupoSolidarioBono != null))
                {
                    MessageBox.Show(cCliente + " no tiene Bono por Cumplimiento de Cuota para este desembolso.\n\n" +
                        "*Se continuará con el proceso de desembolso grupal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                if (!objGrupoSolidarioBono.lEntregado && objGrupoSolidarioBono.nBono > 0)
                {
                    clsGrupoSolidarioIntegrante objGrupoSolidarioIntegrante = (new CRE.CapaNegocio.clsCNGrupoSolidario()).obtenerGrupoSolidarioIntegrante(idCli);

                    if (objGrupoSolidarioIntegrante.idGrupoSolidario > 0)
                    {
                        frmGrupoSolidarioEmisionBono objFrmGrupoSolidarioEmisionBono = new frmGrupoSolidarioEmisionBono(objGrupoSolidarioIntegrante, this.lstGrupoSolidarioBono);
                        objFrmGrupoSolidarioEmisionBono.ShowDialog();
                        if (objFrmGrupoSolidarioEmisionBono.idResultado == ResultadoServidor.Error)
                        {
                            this.mensajeProceso("Error de Gestión de Bono.", cCliente, Estado.DENEGADO);
                            this.lErrorDesembolso = true;
                        }
                        objGrupoSolidarioBono.lEntregado = true;
                        return objFrmGrupoSolidarioEmisionBono.lBonoEntregado;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(objGrupoSolidarioBono.lEntregado)
                {
                    MessageBox.Show(cCliente + " ya recibió su bono por cumplimiento de cuota para este desembolso.\n\n" +
                        "*Se continuará con el proceso de desembolso grupal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(cCliente + " no tiene Bono por Cumplimiento de Cuota para este desembolso.\n\n" +
                        "*Se continuará con el proceso de desembolso grupal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(cCliente + " no tiene Bono por Cumplimiento de Cuota para este desembolso.\n\n" +
                    "*Se continuará con el proceso de desembolso grupal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }
        private bool validarDesembolso(clsDesembolsoSolicitud objDesembolsoSolicitud)
        {
            
            CRE.CapaNegocio.clsCNCredito Creditos = new CRE.CapaNegocio.clsCNCredito();
            DataTable dtMorcli = new DataTable();
            dtMorcli = Creditos.CNdtSumMorCli(objDesembolsoSolicitud.idCli);
            Decimal nSalMorCli = Convert.ToDecimal(dtMorcli.Rows[0][0]);
            if (nSalMorCli > 0)
            {
                MessageBox.Show("El cliente tiene Créditos Vigentes en Mora, consulte Posición del Cliente", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            String cCumpleReglas = "";
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = this.objValidaReglasDinamicas.ValidarReglas(armarTablaParametros(objDesembolsoSolicitud),
                                           this.Name,
                                           clsVarGlobal.nIdAgencia,
                                           objDesembolsoSolicitud.idCli,//Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                           1,
                                           objDesembolsoSolicitud.IdMoneda,
                                           objDesembolsoSolicitud.idProducto,
                                           objDesembolsoSolicitud.nCapitalAprobado,
                                           objDesembolsoSolicitud.idSolicitud,
                                           clsVarGlobal.dFecSystem,
                                           2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            DataTable dtReaprob = new clsCNReaprobSol().obtenerReaprobacion(objDesembolsoSolicitud.idSolicitud);
            if (dtReaprob.Rows.Count > 0)
            {
                MessageBox.Show("Las condiciones de la solicitud están siendo modificadas, Intente nuevamente cuando la edición finalice.", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void imprimirVoucherGrupo()
        {
            clsRespuestaServidor objRespuestaServidor = this.objCNGrupoSolidario.grabarGrupoSolidarioVoucher(
                this.lstDesembolsoSolicitud[0].idGrupoSolidario,
                this.lstDesembolsoSolicitud[0].idSolicitudCredGrupoSol,
                this.lstDesembolsoSolicitud.Count,
                this.lstDesembolsoSolicitud.Sum(x => x.nCapitalAprobado)
                );

            string cTextoVoucher = string.Empty;
            int idTipoPlantImpresion = clsVarGlobal.idTipoPlantillaImpresion;
            clsGrupoSolidarioVoucher objGrupoSolidarioVoucher = new clsGrupoSolidarioVoucher();

            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                objGrupoSolidarioVoucher = (clsGrupoSolidarioVoucher)objRespuestaServidor.objDatos;
                cTextoVoucher = this.generarVoucher(idTipoPlantImpresion, objGrupoSolidarioVoucher);
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje,"ERROR DE REGISTRO DE VOUCHER",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            string cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = "   ";//idTipoImpresion == 1 ? "   " : "COPIA";

            cPlantillaEmpresa = cTextoVoucher;
            if (idTipoPlantImpresion == 2)
            {
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaCliente = this.generarVoucher(idTipoPlantImpresion, objGrupoSolidarioVoucher, true); 
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
            paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
            paramlist.Add(new ReportParameter("cRUC", cRUC, false));
            paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
            paramlist.Add(new ReportParameter("nIdKardex", objGrupoSolidarioVoucher.idGrupoSolidarioVoucher.ToString(), false));
            string reportpath = "rptVoucher.rdlc";

            this.mostrarVoucherGrupo(idTipoPlantImpresion, dtslist, paramlist, reportpath);

            while (MessageBox.Show("¿Desea reimprimir el voucher?", "IMPRESION DE VOUCHER",
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.mostrarVoucherGrupo(idTipoPlantImpresion, dtslist, paramlist, reportpath);
            }
        }

        private void mostrarVoucherGrupo(int idTipoPlantImpresion, List<ReportDataSource> dtslist, List<ReportParameter> paramlist, string reportpath)
        {
            if (idTipoPlantImpresion == 2)
            {
                reportpath = "rptVoucherTicketMatricial.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
            else
            {
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
        }
        private string generarVoucher(int idPlantilla, clsGrupoSolidarioVoucher objGrupoSolidarioVoucher, bool lFirma = false) 
        {
            string cTextoVoucher = string.Empty;
            switch (idPlantilla)
            {
                case 1:
                    cTextoVoucher = "DESEMBOLSO GRUPAL" +
                        "\r\n----------------------------------------------" +
                        "\r\nNro Grupo: " + objGrupoSolidarioVoucher.idGrupoSolidario.ToString() +
                        "\r\nNom. Grup: " + this.conBusGrupoSol.txtNombreGrupo.Text +
                        "\r\nOFICINA  : " + clsVarGlobal.cNomAge + "     CAJERO: " + clsVarGlobal.User.cWinUser +
                        "\r\nFECHA    : " + objGrupoSolidarioVoucher.dFechaHoraRegistro.ToString("dd/MM/yyyy") + "   HORA  : " + objGrupoSolidarioVoucher.dFechaHoraRegistro.ToString("HH:mm:ss") +
                        "\r\nMONEDA   : SOLES  MOD.PAGO: EFECTIVO" +
                        "\r\n----------------------------------------------" +
                        "\r\nMOTIVO   : DESEMBOLSO GRUPAL" +
                        "\r\n\r\nTOTAL DESEMBOLSO:  " + this.completarCadena(this.txtMontoTotal.Text, '*', 27) +
                        "\r\n----------------------------------------------" +
                        ((lFirma)?"\r\n\r\nFIRMA :                        ---------------\r\nDNI:\r\n" : string.Empty) +
                        "\r\n\r\nEL PRESENTE ES REFERENCIAL Y SE EMITE" +
                        "\r\nSOLAMENTE PARA EL CONTROL GRUPAL."
                        ;
                    break;
                case 2:
                    cTextoVoucher = "DESEMBOLSO GRUPAL"+
                        "\r\n------------------------------------" +
                         "\r\nNro Grupo: " + objGrupoSolidarioVoucher.idGrupoSolidario.ToString() +
                         "\r\nNom. Grup: " + this.conBusGrupoSol.txtNombreGrupo.Text +
                         "\r\nOFICINA  : " + clsVarGlobal.cNomAge +
                         "\r\nCAJERO   : " + clsVarGlobal.User.cWinUser +
                         "\r\nFEC/HRA  : " + objGrupoSolidarioVoucher.dFechaHoraRegistro.ToString("dd/MM/yyyy") + " / " + objGrupoSolidarioVoucher.dFechaHoraRegistro.ToString("HH:mm:ss") +
                         "\r\nMONEDA   : SOLES" +
                         "\r\nM.PAGO   : EFECTIVO" +
                         "\r\n------------------------------------" +
                         "\r\nMOTIVO   : DESEMBOLSO GRUPAL" +
                         "\r\n\r\nTOTAL DESEMBOLSO: " + this.completarCadena(this.txtMontoTotal.Text, '*', 18) +
                         "\r\n\r\n\r\n\r\nFIRMA: -----------------------------" +
                         "\r\nDNI  :" +
                         "\r\nEL PRESENTE ES REFERENCIAL Y SE"+
                         "\r\nEMITE SOLAMENTE PARA EL CONTROL" +
                         "\r\nGRUPAL."
                        ;
                    break;
            }

            return cTextoVoucher;
        }
        private string completarCadena(string cCadena, char cCaracter, int nLongitud)
        {
            if (cCadena.Length > nLongitud) return cCadena;
            string cComplemento = new string(cCaracter, nLongitud);
            return string.Concat(cComplemento.Substring(0, cComplemento.Length - cCadena.Length), cCadena);
        }
        private void mensajeProceso(string cMensaje, string cCliente = "", Estado idEstado = Estado.CREADO)
        {
            this.lblMensajeProceso.Text = cMensaje;
            this.lblClienteProcesado.Text = cCliente;
            switch (idEstado)
            {
                case Estado.OBSERVADO:
                    this.pnlMensaje.BackColor = Color.DarkOrange;
                    break;
                case Estado.APROBADO:
                    this.pnlMensaje.BackColor = Color.DarkGreen;
                    break;
                case Estado.DENEGADO:
                    this.pnlMensaje.BackColor = Color.DarkRed;
                    break;
                default:
                    this.pnlMensaje.BackColor = Color.DarkSlateGray;
                    break;
            }
        }
        private DataTable armarTablaParametros(clsDesembolsoSolicitud objDesembolsoSolicitud)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = objDesembolsoSolicitud.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = objDesembolsoSolicitud.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSolicitud";
            drfila[1] = objDesembolsoSolicitud.dFechaRegistro.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";

            drfila[1] = objDesembolsoSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoSolicitado";
            drfila[1] = objDesembolsoSolicitud.nCapitalAprobado;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = objDesembolsoSolicitud.nMontoRedondeo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = objDesembolsoSolicitud.IdMoneda;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "ModDesembolso";
            drfila[1] = ModalidadDesembolso.Efectivo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = clsVarGlobal.cNomAge;
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
            drfila[0] = "lVigente";
            drfila[1] = clsVarGlobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.ToString("yyyy-MM-dd");
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
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitudCredGrupoSol";
            drfila[1] = objDesembolsoSolicitud.idSolicitudCredGrupoSol;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        #endregion
        
        #region Eventos
        private void conBusGrupoSol_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", "RESULTADO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.limpiarControles();
                return;
            }

            this.idGrupoSolidario = this.conBusGrupoSol.idGrupoSolidario;
            this.listarDesembolsoSolicitudGrupoSolidario();

        }
        private void dtgDesembolsoSolicitud_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgDesembolsoSolicitud.SelectedRows.Count == 0)
            {
                this.nIndiceFila = -1; return;
            }
            this.nIndiceFila = this.dtgDesembolsoSolicitud.SelectedRows[0].Index;
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (this.idModalidadCredito == (int)ModalidadCredito.Principal)
            {
                if (!this.validarClientePepYRegimenCli())
                {
                    MessageBox.Show("Se han identificado pendientes en la validación de régimen del cliente y validación del cliente PEP.\n\n"
                        + "* No se le permitirá continuar con el desembolso hasta que nos resuelva dichos pendientes.",
                        "VALIDACION DE REGIMEN DE CLIENTE Y CLIENTE PEP",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.regularizarBloqueoCuentasYBonos())
                {
                    MessageBox.Show("Se han identificado errores en la regularización de bloqueo de cuentas y bonos.\n\n"
                        + "* No se le permitirá continuar con el desembolso hasta que nos resuelva dichos errores.",
                        "REGULARIZACION DE BLOQUEO DE CUENTAS Y BONOS",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.validarSaldoEnLinea())
                    return;

                this.validarCuentasAhorro();

                if (this.nAhorroSuficiente < this.lstDesembolsoSolicitud.Count)
                {
                    MessageBox.Show("Quedan " + (this.lstDesembolsoSolicitud.Count - this.nAhorroSuficiente) +
                    " integrantes que no disponen de monto ahorrado suficiente.\n" +
                    "*No se permitira ejecutar el desembolso hasta que todos los integrantes cumplan con la condicion de monto ahorrado",
                    "AHORRO INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.habilitarControles(clsAcciones.DEFECTO);

                    return;
                }
                else
                {
                    this.habilitarControles(clsAcciones.RECUPERAR);
                }
            }
            else
            {
                if (!this.validarSaldoEnLinea())
                    return;
            }

            this.desembolsarCreditosGrupo();
        }

        private bool ValidarSolicitudPendientePlanSeguro(int idSolicitud)
        {
            DataTable verificacion = new clsCNPaqueteSeguro().CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(idSolicitud);

            if (verificacion.Rows.Count > 0)
            {
                int x_idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);
                int x_numeroSolicitud = Convert.ToInt32(verificacion.Rows[0]["idSolAproba"]);

                if (x_idEstadoSolicitud == 1) //SOLICITADO
                {
                    string x_mensaje = string.Format(clsVarApl.dicVarGen["cMensajeEstadoSolicitud"], x_numeroSolicitud);
                    MessageBox.Show(x_mensaje, "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnEjecutar.Enabled = false;
                    return false;
                }
            }

            var x_solicitud = new clsCNSolicitud().SolicitudDesembolso(idSolicitud);

            if (x_solicitud.Rows.Count > 0)
            {
                bool solicitudRechazada = Convert.ToBoolean(x_solicitud.Rows[0]["SolPlanRechazada"]);

                if (solicitudRechazada)
                {
                    MessageBox.Show("La solicitud ha cambiado de estado, por favor dirigirse al formulario de plan de pagos para generar el cronograma actualizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnEjecutar.Enabled = false;
                    return false;
                }
            }
            return true;
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (this.nIndiceFila < 0)
            {
                MessageBox.Show("Seleccione al cliente cuya cuenta de ahorro desea bloquear.","SELECCIONE...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.lstDesembolsoSolicitud[this.nIndiceFila].lAhorroBloqueado)
            {
                MessageBox.Show("El cliente seleccionado ya tiene su cuenta bloqueada.","BLOQUEO EXISTENTE",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.bloquearCuentaAhorro(this.lstDesembolsoSolicitud[this.nIndiceFila]);
        }
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (this.idGrupoSolidario > 0 && this.idSolicitudCredGrupoSol > 0)
            {
                this.validarCuentasAhorro();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarControles();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
