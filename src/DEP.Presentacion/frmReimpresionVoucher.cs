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
using GEN.CapaNegocio;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using CRE.CapaNegocio;
using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using ADM.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmReimpresionVoucher : frmBase
    {
        #region Variables Globales
        clsCNImpresion Imprimir = new clsCNImpresion();
        clsCNSocio cnsocio = new clsCNSocio();
        private int idkardex = 0;
        private int idModulo = 0;
        private int idTipoImpresion = 3;
        private bool lTipoImpTermica = true;
        private string cFechayhora = "";
        private int idCuenta = 0,pidTipoOperacion=0,pidSolicitud=0, idEstadoKardex=0;
        #endregion
        #region Constructor
        public frmReimpresionVoucher()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmReimpresionVoucher_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //Emision de Voucher
            int idKardexInt = Convert.ToInt32(this.txtNroKardex.Text.ToString().Trim());
            
            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("hh:mm:ss tt");
            this.cFechayhora = cFecha + " " + cHora;

            //DataTable dtDatosOpeInt = Imprimir.CNDatosOperacion(idKardexInt, idModulo);
            //TIPO DE IMPRESIÓN
            //1-->IMPRESION
            //2-->REIMPRESION
            if (idKardexInt > 0)
            {
                if (lTipoImpTermica)
                {
                    if (idKardexInt > 0)
                    {
                        DateTime dFechaUnificacion = clsVarGlobal.dFecSystem;
                        clsVarGen objFechaVoucherUni = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("dFechaVoucherUnificado"));
                        dFechaUnificacion = (objFechaVoucherUni == null) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(objFechaVoucherUni.cValVar);

                        if (pidTipoOperacion == 1 && clsVarGlobal.dFecSystem >= dFechaUnificacion)
                        {
                            ImpresionVoucherRelacionado(idKardexInt, idModulo, pidTipoOperacion, idEstadoKardex, 0, 0, 0, 2);
                        }
                        else
                        {
                            ImpresionVoucher(idKardexInt, idModulo, pidTipoOperacion, idEstadoKardex, 0, 0, 0, 2);//Parámetros que se requieren kardex,Modulo,TipoOperacion,MOntoRecibido, MontoDVuelto, KardexEgreso caso Habilitacion
                        }
                    }
                }
                else
                {
                    DataTable dtCobro;
                    switch (pidTipoOperacion)
                    {
                        case 1://DESEMBOLSO
                            //Emisión de Voucher              
                            dtCobro = new clsCNPlanPago().CNGetCobro(idKardexInt);
                            EmitirVoucherCreditos(dtCobro, idKardexInt);
                            break;
                        case 34://CANCELACION ANTICIPADA
                        case 59://CANCELACIÓN POR REFINANCIACIÓN
                        case 7://CONDONACIÓN DE DEUDA
                        case 2://COBRANZA
                            //Emisión de Voucher              
                            dtCobro = new clsCNPlanPago().CNGetCobro(idKardexInt);
                            EmitirVoucherCreditos(dtCobro, idKardexInt);
                            break;
                        case 6:
                        case 8://HABILITACIONES
                            clsCNControlOpe DtReciboI = new clsCNControlOpe();
                            dtCobro = DtReciboI.CNBuscaHab(idKardexInt);
                            DataTable tbRecE = new DataTable();
                            EmitirVoucherHab(dtCobro, tbRecE, idKardexInt);
                            break;
                        case 5://EMISION DE RECIBOS DE INGRESO
                        case 62: //EMISION DE RECIBOS DE EGRESO
                            string msge = "";
                            int idRec = Convert.ToInt32(idCuenta);
                            clsCNControlOpe DtRecibo = new clsCNControlOpe();
                            dtCobro = DtRecibo.BuscarRecibo(idRec, ref msge);
                            EmitirVoucherEmision(dtCobro, idRec, idKardexInt);
                            break;
                        case 52://PAGO DE FONDO MORTUORIO   
                        case 51://PAGO DE APORTE
                            int idKarFondo = 0;
                            int idKarInscr = 0;
                            int idKarAporte = 0;
                            int idCli = 0;
                            if (pidTipoOperacion == 52)
                            {
                                idKarFondo = idKardexInt;
                            }
                            else
                                idKarAporte = idKardexInt;
                            DataTable dtCli = cnsocio.CNDatosCli(idKarFondo, idKarAporte);
                            if (dtCli.Rows.Count > 0)
                            {
                                idCli = Convert.ToInt32(dtCli.Rows[0]["idCli"]);
                            }
                            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                            int idUsuario = clsVarGlobal.User.idUsuario;
                            string nSaldoAporte =dtCli.Rows[0]["nSaldoAporte"].ToString();
                            string nSaldoFondo=dtCli.Rows[0]["nSaldoFondo"].ToString();
                            EmitirVoucherAporte(idKarAporte, idKarFondo, idKarInscr, idCli, idMoneda, idUsuario, chcSaldo.Checked,nSaldoAporte, nSaldoFondo);
                            break;
                        case 58://DEVOLUCIÓN DE APORTE
                            DataTable dtDatosOperacion = Imprimir.CNDatosOperacion(idKardexInt, 4, 0, 0, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
                            EmitirVoucherDevolucion(idKardexInt, clsVarGlobal.idModulo, dtDatosOperacion);
                            break;
                        case 20://COMPRA DÓLARES
                        case 21: //VENTA DE DÓLARES
                            dtCobro = Imprimir.CNDatosCompraVentaDol(idKardexInt);
                            EmitirVoucherDolares(idKardexInt, dtCobro);
                            break;
                        case 12://CANCELACIÓN DE DEPÓSITO
                            dtCobro = Imprimir.CNDatosCancelación(idKardexInt);
                            EmitirVoucherCancel(idKardexInt, dtCobro);
                            break;
                        case 90: //INDEMNIZACION 
                            dtCobro = Imprimir.CNBuscaKardexIndem(idKardexInt, clsVarGlobal.nIdAgencia);
                            EmitirVoucherIndemr(idKardexInt,dtCobro,false);
                            break;
                        default://9,10,11,12: APERTURA, DEPOSITO, RETIRO/
                            DataTable dtOperacion = new clsRPTCNDeposito().CNDetalleTransaccion(idKardexInt, chcSaldo.Checked);
                            EmitirVoucherCreditos(dtOperacion, idKardexInt);
                            break;
                    }
                }
            }
            else
            {

                MessageBox.Show("No se encontró número de operación en búsqueda","Validación de reimpresión",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            //Guardar la Impresion
            int nNumImpresion = Convert.ToInt32(this.lblNroImpresion.Text.ToString().Trim()) + 1;
            string cMotivo = this.txtMotivo.Text.ToString();

            DateTime dresultFechyHora;
            DateTime.TryParse(this.cFechayhora, out dresultFechyHora);

            DataTable dtResp = Imprimir.CNGuardaImpresion(0, clsVarGlobal.idModulo, nNumImpresion, idkardex, clsVarGlobal.User.idUsuario, idTipoImpresion, dresultFechyHora, cMotivo, false, pidSolicitud);
            if ((int)dtResp.Rows[0]["nResultado"] == 1)
            {
                this.btnImprimir.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.txtMotivo.Enabled = false;
                chcSaldo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al Momento de Vincular Kardex para la Impresión", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
        private void EmitirVoucherIndemr(int idKarIndemnizac, DataTable dtDatosOperacion,Boolean lIndPagoSepelio)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKardex", idKarIndemnizac.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("lIndPagSep", lIndPagoSepelio.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsOper", dtDatosOperacion));
            string reportpath = "rptVoucherIndem.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist,true).ShowDialog();
        }
        private void EmitirVoucherCreditos(DataTable dtDatosCobro, int idKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            //  List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist,true).ShowDialog();
        }

        private void EmitirVoucherAporte(int idKarAporte, int idKarFondo, int idKarInscr, int idCli, int idMoneda, int idUsuario, bool lIndSaldo, string nSaldoAporte,string nSaldoFondo)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKarAporte", idKarAporte.ToString(), false));
            paramlist.Add(new ReportParameter("idKarFondo", idKarFondo.ToString(), false));
            paramlist.Add(new ReportParameter("idKarInscr", idKarInscr.ToString(), false));

            paramlist.Add(new ReportParameter("idCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));

            paramlist.Add(new ReportParameter("nSaldoAporte", nSaldoAporte, false));
            paramlist.Add(new ReportParameter("nSaldoFondo", nSaldoFondo, false));
            paramlist.Add(new ReportParameter("lIndicaSaldo", lIndSaldo.ToString(), false));

            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsPagoAporteFondo", cnsocio.CNReportePagoAporteFondo(idKarInscr, idKarAporte, idKarFondo, idCli, idMoneda, idUsuario)));
            string reportpath = "RptVoucherAporte.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        private void EmitirVoucherHab(DataTable dtDatosIngreso, DataTable dtDatosEgreso, int idKardex)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsDatIngreso", dtDatosIngreso));
            dtslist.Add(new ReportDataSource("dtsDatEgreso", dtDatosEgreso));
            string reportpath = "rptVoucherHabil.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        private void EmitirVoucherCancel(int idKardex, DataTable dtOper)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsOper", dtOper));
            string reportpath = "rptVoucherCancelAho.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        private void EmitirVoucherDevolucion(int idKardex, int idModulo, DataTable dtDatOpe)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));
            paramlist.Add(new ReportParameter("x_idModulo", idModulo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsOpeDev", dtDatOpe));
            string reportpath = "RptVoucherDev.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void EmitirVoucherEmision(DataTable dtDatosCobro, int idRec, int idKardex)
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
        private void EmitirVoucherDolares(int idKardex, DataTable dtOperacion)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsOper", dtOperacion));

            //  List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "rptVoucherOpeDol.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist,true).ShowDialog();
        }
        private void txtNroKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(this.txtNroKardex.Text.ToString().Trim()))
                {
                    MessageBox.Show("Ingrese un Número de Kardex Válido", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroKardex.Focus();
                    this.txtNroKardex.SelectAll();
                    return;
                }
                else
                {
                    idkardex = Convert.ToInt32(this.txtNroKardex.Text.ToString().Trim());
                    this.BuscarKardex();
                }
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.btnImprimir.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.lblNroImpresion.Text = "0";
            chcSaldo.Checked = false;
            chcSaldo.Enabled = false;
            this.btnSolAprobadas.Enabled = true;
            this.btnSolAprobadas.Focus();
        }
        #endregion
        #region Metodos
        private void BuscarKardex()
        {
            DataTable dtDatKardex = Imprimir.CNBuscaKardex(idkardex,0);
            if (dtDatKardex.Rows.Count>0)
            {
                this.txtEstadoOpe.Text = dtDatKardex.Rows[0]["cEstadoKardex"].ToString();
                this.txtFechaOpe.Text = Convert.ToDateTime(dtDatKardex.Rows[0]["dFechaOpe"]).ToString("dd/MM/yyyy") + " " + dtDatKardex.Rows[0]["cHoraOpe"].ToString(); 
                this.txtModulo.Text = dtDatKardex.Rows[0]["cModulo"].ToString();
                this.txtTipoOperacion.Text = dtDatKardex.Rows[0]["cTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatKardex.Rows[0]["idMoneda"];
                this.txtMonOpe.Text = dtDatKardex.Rows[0]["nMontoOperacion"].ToString();
                this.lblNroImpresion.Text = dtDatKardex.Rows[0]["nNumImpresion"].ToString();
                idModulo = Convert.ToInt32(dtDatKardex.Rows[0]["idModulo"].ToString());
                this.btnImprimir.Enabled = true;
                this.btnCancelar.Enabled = true;
                idCuenta = Convert.ToInt32(dtDatKardex.Rows[0]["idCuenta"].ToString());
                pidTipoOperacion = Convert.ToInt32(dtDatKardex.Rows[0]["idTipoOperacion"]);
                this.btnSolAprobadas.Enabled = false;
                idEstadoKardex = Convert.ToInt32(dtDatKardex.Rows[0]["idTipoOperacion"]);
            }
            else
            {
                MessageBox.Show("No se encontro Datos del Kardex ingresado", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnSolAprobadas.Focus();
                return;
            }
        }
        private void LimpiarControles()
        {
            this.txtNroKardex.Clear();
            this.txtEstadoOpe.Clear();
            this.txtFechaOpe.Clear();
            this.txtModulo.Clear();
            this.txtTipoOperacion.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonOpe.Clear();
            this.txtMotivo.Clear();
        }
        #endregion

        private void btnSolAprobadas_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            frmBuscarSolicitudApr frmExtPen = new frmBuscarSolicitudApr();
            frmExtPen.pidMod = 2;
            frmExtPen.pidTipOpe = 116;
            frmExtPen.pidUsario = clsVarGlobal.User.idUsuario;
            frmExtPen.pidAgencia = clsVarGlobal.nIdAgencia;
            frmExtPen.ShowDialog();
            pidSolicitud = frmExtPen.pidSolExt;
            idkardex = frmExtPen.pidKardex;
            if (idkardex > 0)
            {
                txtNroKardex.Text = idkardex.ToString();
                this.txtEstadoOpe.Text = frmExtPen.pcEstKardex;
                this.txtMotivo.Text=frmExtPen.pcSustento;
                this.BuscarKardex();
            }
            else
            {
                txtNroKardex.Text = "";
                this.txtEstadoOpe.Text = "";
                return;
            }
        }


       

       
    }
}
