using ADM.CapaNegocio;
using CRE.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmAprobPagoComisionAT : frmBase
    {
        #region Variables Globales
        private BindingSource bsAprobPagoComAT { get; set; }
        private clsCNCreditoCargaComision objCNCreditoCargaComision { get; set; }
        private DataTable dtDatosZonaUsuario { get; set; }
        private clsCNAprobPagoComisionAT objCNAprobPagoComisionAT { get; set; }
        private List<clsAprobPagoComAT> lstAprobPagoComisionAT { get; set; }
        private clsCNDeposito objDeposito = new clsCNDeposito();
        #endregion

        public frmAprobPagoComisionAT()
        {
            InitializeComponent();
            this.cargarComponentes();
        }

        #region Metodos
        private void cargarComponentes()
        {
            this.cboAgencias.AgenciasYTodos();            
            this.cboAgencias.SelectedValue = 0;

            this.cboAsistenteTecnico.AsistenteTecnicoPorAgencia(Convert.ToInt32(this.cboAsociacion.SelectedValue));

            if (!this.validarCargosVisualizaPagoComision()) //294 JEFE DE PRODUCTO PECUARIO, 277 JEFE DE PRODUCTO AGRICOLA
	        {		        
                this.cboAgencias.Enabled = false;
                this.cboAgencias.SelectedValue = Convert.ToInt32(clsVarGlobal.nIdAgencia);
	        }

            if (!this.validarCargosDepMasPagoComision())
            {
                this.btnPagar.Enabled = false;
            }

            this.objCNAprobPagoComisionAT = new clsCNAprobPagoComisionAT();
            this.objCNAprobPagoComisionAT.CNCalcularEstDistribucionPagosAT();

            this.dtDatosZonaUsuario = new DataTable();
            this.objCNCreditoCargaComision = new clsCNCreditoCargaComision();
            this.dtDatosZonaUsuario = objCNCreditoCargaComision.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);
        }

        private void cargarGridAprobPagoComisionAT(int idAgencia, int idAsociacionAsisTec, int idCli, int idEstPagoAT)
        {
            this.objCNAprobPagoComisionAT = new clsCNAprobPagoComisionAT();
            this.lstAprobPagoComisionAT = this.objCNAprobPagoComisionAT.CNListarPagosAsistentesTecnicos(idAgencia, idAsociacionAsisTec, idCli, idEstPagoAT);

            this.bsAprobPagoComAT = new BindingSource();
            this.bsAprobPagoComAT.DataSource = this.lstAprobPagoComisionAT;
            this.dtgPagoComisionAT.DataSource = this.bsAprobPagoComAT;

            this.formatearGridAprobPagoComisionAT();
            this.dtgPagoComisionAT.Refresh();            
        }

        private void formatearGridAprobPagoComisionAT()
        {
            this.dtgPagoComisionAT.ReadOnly = false;
            foreach (DataGridViewColumn dgvColumn in this.dtgPagoComisionAT.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.HeaderText = dgvColumn.Name;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvColumn.ReadOnly = true;                
            }

            //this.dtgPagoComisionAT.Columns["lSeleccionado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dtgPagoComisionAT.Columns["lSeleccionado"].Visible = true;
            this.dtgPagoComisionAT.Columns["idCreditoComision"].Visible = false;
            this.dtgPagoComisionAT.Columns["idCuenta"].Visible = true;
            this.dtgPagoComisionAT.Columns["cNivel"].Visible = true;
            this.dtgPagoComisionAT.Columns["cDistribucion"].Visible = true;
            this.dtgPagoComisionAT.Columns["cDocumentoID"].Visible = true;
            this.dtgPagoComisionAT.Columns["cNombre"].Visible = true;            
            this.dtgPagoComisionAT.Columns["nMontoCapDesem"].Visible = true;
            this.dtgPagoComisionAT.Columns["nValorEspecifico"].Visible = true;
            this.dtgPagoComisionAT.Columns["nMontoComision"].Visible = true;
            this.dtgPagoComisionAT.Columns["nValorDistribucion"].Visible = true;
            this.dtgPagoComisionAT.Columns["nMontoPago"].Visible = true;
            this.dtgPagoComisionAT.Columns["lCumpleCondicion"].Visible = true;
            this.dtgPagoComisionAT.Columns["lAprobado"].Visible = true;
            this.dtgPagoComisionAT.Columns["lPagado"].Visible = true;
            this.dtgPagoComisionAT.Columns["idEstadoPago"].Visible = false;
            this.dtgPagoComisionAT.Columns["cEstado"].Visible = true;
            this.dtgPagoComisionAT.Columns["idKardexRecibo"].Visible = true;
            this.dtgPagoComisionAT.Columns["idKardexReciboExtorno"].Visible = true;
            this.dtgPagoComisionAT.Columns["dFechaDesembolso"].Visible = true;
            this.dtgPagoComisionAT.Columns["dFechaCancelacion"].Visible = true;
            this.dtgPagoComisionAT.Columns["lVigente"].Visible = true;
            
            this.dtgPagoComisionAT.Columns["lSeleccionado"].HeaderText = "#";
            this.dtgPagoComisionAT.Columns["idCreditoComision"].HeaderText = "Id";
            this.dtgPagoComisionAT.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgPagoComisionAT.Columns["cNivel"].HeaderText = "Nivel";
            this.dtgPagoComisionAT.Columns["cDistribucion"].HeaderText = "Distribución";
            this.dtgPagoComisionAT.Columns["cDocumentoID"].HeaderText = "Documento";
            this.dtgPagoComisionAT.Columns["cNombre"].HeaderText = "Asistente Técnico";            
            this.dtgPagoComisionAT.Columns["nMontoCapDesem"].HeaderText = "Capital Desembolsado";
            this.dtgPagoComisionAT.Columns["nValorEspecifico"].HeaderText = "% Comisión";
            this.dtgPagoComisionAT.Columns["nMontoComision"].HeaderText = "Monto Comisión";
            this.dtgPagoComisionAT.Columns["nValorDistribucion"].HeaderText = "% Distribución";
            this.dtgPagoComisionAT.Columns["nMontoPago"].HeaderText = "Monto Pago";
            this.dtgPagoComisionAT.Columns["lCumpleCondicion"].HeaderText = "Cumple";
            this.dtgPagoComisionAT.Columns["lAprobado"].HeaderText = "Aprobado";
            this.dtgPagoComisionAT.Columns["lPagado"].HeaderText = "Pagado";
            this.dtgPagoComisionAT.Columns["idEstadoPago"].HeaderText = "Estado";
            this.dtgPagoComisionAT.Columns["cEstado"].HeaderText = "Estado";
            this.dtgPagoComisionAT.Columns["idKardexRecibo"].HeaderText = "Kardex";
            this.dtgPagoComisionAT.Columns["idKardexReciboExtorno"].HeaderText = "Kardex Extorno";
            this.dtgPagoComisionAT.Columns["dFechaDesembolso"].HeaderText = "Fecha Desembolso";
            this.dtgPagoComisionAT.Columns["dFechaCancelacion"].HeaderText = "Fecha Cancelación";
            this.dtgPagoComisionAT.Columns["lVigente"].HeaderText = "Vigente";            
            
            this.dtgPagoComisionAT.Columns["lSeleccionado"].ReadOnly = false;
        }

        public void ConsultarAprobPagoComisionAT()
        {
            int idAgencia = (int)this.cboAgencias.SelectedValue;
            int idAsociacionAsisTec = (int)this.cboAsociacion.SelectedValue;
            int idCli = (int)this.cboAsistenteTecnico.SelectedValue;
            int idEstPagoAT = (int)this.cboEstPagoAT.SelectedValue;
            this.cargarGridAprobPagoComisionAT(idAgencia, idAsociacionAsisTec, idCli, idEstPagoAT);
        }

        private int RegistraCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal, int idAgencia, int idProducto, int idMoneda,
                                            string xmlLisCtas, int idUsuOpe, int idUsuOrdenante, string cCaracteristica, DateTime dFecOpe, int idTipoCarga)
        {
            DataTable dtRegistraCargaMasivaAho;

            dtRegistraCargaMasivaAho = objDeposito.CNRegistraCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                         idAgencia, idProducto, idMoneda, xmlLisCtas, idUsuOpe, idUsuOrdenante,
                                                                        cCaracteristica, dFecOpe, idTipoCarga);

            return Convert.ToInt32(dtRegistraCargaMasivaAho.Rows[0]["idCarga"].ToString());
        }

        private int RegistraDepositoCtaMasivo(int idDetCredComi, int idCarga, int nIntNumCel, int idCuenta, int nPlazo, int idMoneda, decimal nMonOperac,
                                              decimal nMonComis, decimal nMonITF, int idCanal, int idAgencia, int idUsu,
                                              DateTime dFechaOpe, int idProducto, bool lIsAhoProg, int nCuota,
                                              int nTipPago, string xmlTipPago, string cNroDoc, int cCodInstFin,
                                              int cCtaTransf, int idCliente, int idTipPersona, string cDniCliOpe,
                                              string cNomCliOpe, string cDirCliOpe, int idPeriodoCTS, decimal nSumUltRemun,
                                              int x_idTipoCarga)
        {
            DataTable dtRegistraDepositoCtaMasivo;

            dtRegistraDepositoCtaMasivo = objDeposito.CNRegistraDepositoCtaMasivoAT(idDetCredComi, idCarga, nIntNumCel, idCuenta, nPlazo, idMoneda, nMonOperac,
                                                                            nMonComis, nMonITF, idCanal, idAgencia, idUsu,
                                                                            dFechaOpe, idProducto, lIsAhoProg, nCuota, nTipPago,
                                                                            xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf,
                                                                            idCliente, idTipPersona, cDniCliOpe, cNomCliOpe,
                                                                            cDirCliOpe, idPeriodoCTS, nSumUltRemun, x_idTipoCarga);

            return Convert.ToInt32(dtRegistraDepositoCtaMasivo.Rows[0]["idKardex"].ToString());
        }

        private bool validapago()
        {
            bool lvalida = true;
            int nCantidadSelect = 0;
            int nCantidadSelectEst = 0;
            decimal nMontoTotal = 0;            

            var lstAprobPagoComisionATTmpSelect = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true);
            var lstAprobPagoComisionATTmpSelectEst = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true && item.idEstadoPago == 7);

            nCantidadSelect = lstAprobPagoComisionATTmpSelect.Count();
            nCantidadSelectEst = lstAprobPagoComisionATTmpSelectEst.Count();
            nMontoTotal = lstAprobPagoComisionATTmpSelectEst.Sum(item => item.nMontoPago);            

            if ((nCantidadSelect == 0 || nCantidadSelect != nCantidadSelectEst) || nMontoTotal <= 0)
            {
                MessageBox.Show("No existen pagos a ser depositados", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            return lvalida;
        }

        private bool validaAprobacion()
        {
            bool lvalida = true;
            int nCantidadSelect = 0;
            int nCantidadSelectEst = 0;

            var lstAprobPagoComisionATTmpSelect = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true);
            var lstAprobPagoComisionATTmpSelectEst = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true && item.idEstadoPago == 26);
            nCantidadSelect = lstAprobPagoComisionATTmpSelect.Count();
            nCantidadSelectEst = lstAprobPagoComisionATTmpSelectEst.Count();

            if (nCantidadSelect == 0 || nCantidadSelect != nCantidadSelectEst)
            {
                MessageBox.Show("No existen montos a ser aprobados", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            return lvalida;
        }

        private bool validaDenegacion()
        {
            bool lvalida = true;
            int nCantidadSelect = 0;
            int nCantidadSelectEst = 0;

            var lstAprobPagoComisionATTmpSelect = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true);
            var lstAprobPagoComisionATTmpSelectEst = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true && item.idEstadoPago == 26);
            nCantidadSelect = lstAprobPagoComisionATTmpSelect.Count();
            nCantidadSelectEst = lstAprobPagoComisionATTmpSelectEst.Count();

            if (nCantidadSelect == 0 || nCantidadSelect != nCantidadSelectEst)
            {
                MessageBox.Show("No existen montos a ser denegados", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            return lvalida;
        }

        public void LiberarCuenta()
        {
            objDeposito.CNUpdNoUsoCuentaMasivo(clsVarGlobal.User.idUsuario);
        }

        private bool validarCargosVisualizaPagoComision()
        {
            bool lValor = true;
            clsVarGen objVariableGeneral = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaCargoVistaPagosComision"));
            string cListaCargo = objVariableGeneral.cValVar;

            if (cListaCargo == "0")
                return true;

            List<int> lstCargosPermitidos = objVariableGeneral.cValVar.Split(',').Select(Int32.Parse).ToList();
            int idCargoActual = clsVarGlobal.User.idCargo;

            lValor = (lstCargosPermitidos.Contains(idCargoActual)) ? true : false;

            return lValor;
        }

        private bool validarCargosDepMasPagoComision()
        {
            bool lValor = true;
            clsVarGen objVariableGeneral = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaCargoEjecutaPagoComision"));
            string cListaCargo = objVariableGeneral.cValVar;

            if (cListaCargo == "0")
                return true;

            List<int> lstCargosPermitidos = objVariableGeneral.cValVar.Split(',').Select(Int32.Parse).ToList();
            int idCargoActual = clsVarGlobal.User.idCargo;

            lValor = (lstCargosPermitidos.Contains(idCargoActual)) ? true : false;

            return lValor;
        }
        #endregion        

        #region Eventos
        private void cboAsociacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboAsistenteTecnico.AsistenteTecnicoPorAgencia(Convert.ToInt32(this.cboAsociacion.SelectedValue));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.ConsultarAprobPagoComisionAT();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
              * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Inicio-Deposito masivo por servicios de asistencia técnica", this.btnPagar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (!validapago())
            {
                return;
            }

            if (string.IsNullOrEmpty(conBusCol.idUsu))
            {
                MessageBox.Show("Debe ingresar los datos del ordenante.", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal nMontoTotal = 0;
            int nTipPago = 7; // Nota de cargo

            var lstAprobPagoComisionATTmp = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true && item.lPagado == false);
            nMontoTotal = lstAprobPagoComisionATTmp.Sum(item => item.nMontoPago);

            /*if (conBusCli.txtNroDoc.Text != clsVarApl.dicVarGen["cRUC"])
            {
                nTipPago = 1; // Efectivo

                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 1, nMontoTotal))
                {
                    return;
                }
            }*/

            int idCarga = 0;
            int idTipoCarga = this.objCNAprobPagoComisionAT.CNObtenerTipoCargaPagoAsistenteTecnico();
            int idCliJuridico = 0;            
            int nNroCorrelativo = 0;
            string cNomArchivo = string.Empty;
            int idTipoOperac = 10;  // Deposito
            int idCanal = 1;    // Ventanilla
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idProducto = 0;
            int idMoneda = 1;
            int idUsuOrdenante = Convert.ToInt32(conBusCol.idUsu);

            var lstCliAsoc = lstAprobPagoComisionATTmp.GroupBy(item => item.idCliEmpDep).Select(itemgrp => itemgrp.First()).First();
            idCliJuridico = ((clsAprobPagoComAT)lstCliAsoc).idCliEmpDep;
            idProducto = ((clsAprobPagoComAT)lstCliAsoc).idProducto;
            nNroCorrelativo = ((clsAprobPagoComAT)lstCliAsoc).nNroCorrelativo + 1;
            cNomArchivo = ((clsAprobPagoComAT)lstCliAsoc).cCodCliEmpDep.Substring(0, 13) + "_" + clsVarGlobal.dFecSystem.Date.ToString("yyyyMMdd") + "_" + nNroCorrelativo;

            //
            DataTable dtDatosPagos = new DataTable();
            dtDatosPagos.Columns.Add("nIntNumCel", typeof(int));
            dtDatosPagos.Columns.Add("lSelCta", typeof(bool));
            dtDatosPagos.Columns.Add("cNroDocIde", typeof(string));
            dtDatosPagos.Columns.Add("cNombre", typeof(string));
			dtDatosPagos.Columns.Add("idCuenta", typeof(int));
            dtDatosPagos.Columns.Add("cCodCta", typeof(string));
            dtDatosPagos.Columns.Add("nMontoOperacion", typeof(decimal));
            dtDatosPagos.Columns.Add("nSumUltRem", typeof(decimal));
            dtDatosPagos.Columns.Add("nMontoITF", typeof(decimal));
            dtDatosPagos.Columns.Add("nMontoDeposito", typeof(decimal));            

            int nIntNumCelTmp = 1;
            foreach (var item in lstAprobPagoComisionATTmp)
            {
                dtDatosPagos.Rows.Add(
                    nIntNumCelTmp,
                    1,
                    item.cDocumentoID,
                    item.cNombre,
                    item.idCuenta,
                    item.cNroCuenta,                    
                    item.nMontoPago,
                    0,
                    decimal.Zero,                    
                    item.nMontoPago
                );

                item.nIntNumCel = nIntNumCelTmp;

                nIntNumCelTmp++;                
            }
            //

            DataSet dsDatosPagos = new DataSet("dsDatosCtasCts");
            dsDatosPagos.Tables.Add(dtDatosPagos);
            string xmldsDatosPagos = dsDatosPagos.GetXml();
            xmldsDatosPagos = clsCNFormatoXML.EncodingXML(xmldsDatosPagos);
            dsDatosPagos.Tables.Clear();
            string cCaracteristica = "Deposito de pagos por servicio de Asistencia Técnica";

            idCarga = RegistraCargaMasivaAho(idCliJuridico, cNomArchivo, idTipoOperac, idCanal,
                                             idAgencia, idProducto, idMoneda, xmldsDatosPagos,
                                             clsVarGlobal.PerfilUsu.idUsuario, idUsuOrdenante, cCaracteristica, clsVarGlobal.dFecSystem, idTipoCarga);

            int idDetCredComi;
            int nIntNumCel;
            int idKardex;
            int idCuenta;
            int nPlazo;            
            decimal nMonOperac;
            decimal nMonComis;
            decimal nMonITF;
            int idUsu = clsVarGlobal.PerfilUsu.idUsuario;
            DateTime dFechaOpe = clsVarGlobal.dFecSystem;
            bool lIsAhoProg = false;
            int nCuota = 0;
            string xmlTipPago = clsCNFormatoXML.EncodingXML("<dsDatosCtasCts><Table1></Table1></dsDatosCtasCts>");
            string cNroDoc = "";
            int cCodInstFin = 0;
            int cCtaTransf = 0;
            int idCliOperac;
            int idTipPersona;
            string cDniCliOpe = "";
            string cNomCliOpe = "";
            string cDirCliOpe = "";
            int idPeriodoCTS = 0;            

            decimal nSumUltRemun;

            DataTable dtRepreJuridica = new clsCNAperturaCta().RetornaRepreJuridica(idCliJuridico);
            if (dtRepreJuridica.Rows.Count > 0)
            {
                cNomCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cNombre"]);
                cDniCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cDocumentoID"]);
                cDirCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cDireccion"]);
            }

            int idProductoCta = 0;            

            foreach (var item in this.lstAprobPagoComisionAT)
            {
                if (Convert.ToBoolean(item.lPagado))
                {
                    continue;
                }

                if (!Convert.ToBoolean(item.lSeleccionado))
                {
                    continue;
                }

                nMonOperac = Convert.ToDecimal(item.nMontoPago);
                if (nMonOperac <= 0)
                {
                    continue;
                }

                idDetCredComi = item.idDetCredComi;
                nIntNumCel = item.nIntNumCel;
                idCuenta = item.idCuenta;
                nPlazo = 0;
                idMoneda = item.idMoneda;
                nMonComis = 0;
                nMonITF = decimal.Zero;
                idCliOperac = item.idCli;
                idTipPersona = item.IdTipoPersona;
                nSumUltRemun = item.nMontoPago;
                idProductoCta = item.idProducto;
                idKardex = this.RegistraDepositoCtaMasivo(idDetCredComi, idCarga, nIntNumCel, idCuenta, nPlazo, idMoneda, nMonOperac, nMonComis, nMonITF,
                                                     idCanal, idAgencia, idUsu, dFechaOpe, idProductoCta, lIsAhoProg, nCuota,
                                                     nTipPago, xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf, idCliOperac,
                                                     idTipPersona, cDniCliOpe, cNomCliOpe, cDirCliOpe, idPeriodoCTS, nSumUltRemun,
                                                     idTipoCarga);                

                item.lPagado = true;                
            }            

            //----------------------------------------------------------------------------------
            //--Actualizar Saldos de Caja
            //----------------------------------------------------------------------------------
            //if (nTipPago == 1)
            //{
            //    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt16(cboMoneda.SelectedValue), 1, nMontoTotal);
            //}

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/            
            this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Fin-Deposito masivo por servicios de asistencia técnica", this.btnPagar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            this.ConsultarAprobPagoComisionAT();

            MessageBox.Show("Deposito masivo realizado satisfactoriamente.", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LiberarCuenta();
            
            //btnImprimirDepMas_Click(sender, e);            
        }
        
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (!validaAprobacion())
            {
                return;
            }

            var lstAprobPagoComisionATTmp = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true);

            DataTable dtDatosPagos = new DataTable();
            dtDatosPagos.Columns.Add("idDetCredComi", typeof(int));
            dtDatosPagos.Columns.Add("idZona", typeof(string));
            dtDatosPagos.Columns.Add("idAgencia", typeof(string));
            dtDatosPagos.Columns.Add("idUsuario", typeof(string));
            dtDatosPagos.Columns.Add("idCargo", typeof(string));
            dtDatosPagos.Columns.Add("cSustento", typeof(string));
            dtDatosPagos.Columns.Add("lAprobDeneg", typeof(bool));

            int idZona = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idZona"]);
            int idAgencia = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idAgencia"]);
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idCargo = clsVarGlobal.User.idCargo;

            foreach (var item in lstAprobPagoComisionATTmp)
            {
                dtDatosPagos.Rows.Add(
                    item.idDetCredComi,
                    idZona,
                    idAgencia,
                    idUsuario,
                    idCargo,
                    "",
                    1
                );
            }

            DataSet dsDatosPagos = new DataSet("dsDatosPagos");
            dsDatosPagos.Tables.Add(dtDatosPagos);
            string xmldsDatosPagos = dsDatosPagos.GetXml();
            xmldsDatosPagos = clsCNFormatoXML.EncodingXML(xmldsDatosPagos);

            DataTable dtResultado = new DataTable();
            dtResultado = objCNAprobPagoComisionAT.CNAprobDenegPagosAsistentesTecnicos(xmldsDatosPagos);

            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0]["lResultado"].ToString()) == 1)
            {
                this.ConsultarAprobPagoComisionAT();
                MessageBox.Show("Aprobaciones realizadas correctamente.", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            if (!validaDenegacion())
            {
                return;
            }

            var lstAprobPagoComisionATTmp = this.lstAprobPagoComisionAT.Where(item => item.lSeleccionado == true);

            DataTable dtDatosPagos = new DataTable();
            dtDatosPagos.Columns.Add("idDetCredComi", typeof(int));
            dtDatosPagos.Columns.Add("idZona", typeof(string));
            dtDatosPagos.Columns.Add("idAgencia", typeof(string));
            dtDatosPagos.Columns.Add("idUsuario", typeof(string));
            dtDatosPagos.Columns.Add("idCargo", typeof(string));
            dtDatosPagos.Columns.Add("cSustento", typeof(string));
            dtDatosPagos.Columns.Add("lAprobDeneg", typeof(bool));

            int idZona = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idZona"]);
            int idAgencia = Convert.ToInt32(dtDatosZonaUsuario.Rows[0]["idAgencia"]);
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idCargo = clsVarGlobal.User.idCargo;

            foreach (var item in lstAprobPagoComisionATTmp)
            {
                dtDatosPagos.Rows.Add(
                    item.idDetCredComi,
                    idZona,
                    idAgencia,
                    idUsuario,
                    idCargo,
                    "",
                    0
                );
            }

            DataSet dsDatosPagos = new DataSet("dsDatosPagos");
            dsDatosPagos.Tables.Add(dtDatosPagos);
            string xmldsDatosPagos = dsDatosPagos.GetXml();
            xmldsDatosPagos = clsCNFormatoXML.EncodingXML(xmldsDatosPagos);

            DataTable dtResultado = new DataTable();
            dtResultado = objCNAprobPagoComisionAT.CNAprobDenegPagosAsistentesTecnicos(xmldsDatosPagos);

            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0]["lResultado"].ToString()) == 1)
            {
                this.ConsultarAprobPagoComisionAT();
                MessageBox.Show("Aprobaciones realizadas correctamente.", "Aprobación de Pagos de Comisión por AT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion        
    }
}
