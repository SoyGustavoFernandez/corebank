using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.Funciones;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio;
using System.Xml.Serialization;
using System.Net;

namespace CRE.Presentacion
{
    public partial class frmExtornoDesembolso : frmBase
    {
        #region Variables

        clsCNKardex cnkardex = new clsCNKardex();
        clsCNDeposito cndeposito = new clsCNDeposito();
        DataTable dtExtornoCre;
        DataTable dtExtornoAho;
        DataTable dtOpeRelacionadas;
        DataTable dtCreditosAmp;
        DataTable dtFinalizaEx = new DataTable();
        DataTable Table1 = new DataTable("Table1");
        bool EstadoTrx = true;
        int nCodUsu = clsVarGlobal.User.idUsuario;
        DateTime dFecSis = clsVarGlobal.dFecSystem;
        clsCNCredito cncredito = new clsCNCredito();
        clsCNRetornaNumCuenta cnretornacuenta = new clsCNRetornaNumCuenta();
        CRE.CapaNegocio.clsCNOperacion cnoperacion = new CRE.CapaNegocio.clsCNOperacion();
        clsCNOperacionDep cnoperaciondep = new clsCNOperacionDep();
        int idKardexExtorno=0;
        private int idKardexDesembolso = 0;
        DataTable dtRecibosSeguroVinculados = new DataTable();


        //Variables solExtorno
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        public int idMod, idProd, idEstKar, idcli;
        public string idCuenta = string.Empty;
        int idSolAprob = 0;
        string cNombreUsuario = clsVarGlobal.User.cNomUsu;
        DataTable dtParamEnvioEmail = new DataTable();
        DataTable dtParamEnvioSMS = new DataTable();
        #endregion

        public frmExtornoDesembolso()
        {
            InitializeComponent();
            conBusCuentaCli.cEstado = "[5]";
            conBusCuentaCli.cTipoBusqueda = "C";

        }

        #region Eventos

        private void frmExtornoDesembolso_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            //Load SolExtorno
            this.btnNuevo.PerformClick();
            cboEstadoSolic1.EstSol(1);
            cboEstadoSolic1.SelectedValue = 1;
            cboMotivoExtorno.cargarDatosOperacion(1);

            //===========================================================================================
            //--Validar Extornos Pendientes Aprobación
            //===========================================================================================

        }

        private void conBusCuentaCli_MyKey_1(object sender, KeyPressEventArgs e)
        {
            Int32 idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            CargaDatosDesembolso(idCuenta);

            clsCNAprobacion dtSolExto = new clsCNAprobacion();
            DataTable tbSolApr = dtSolExto.ListarSolicitudesExtorno(clsVarGlobal.User.idUsuario.ToString(), idKardexDesembolso.ToString());

            if (tbSolApr.Rows.Count > 0)
            {
                this.nudNroKardex.Value = Convert.ToInt32(tbSolApr.Rows[0]["idKardex"]);
                this.txtModulo.Text = tbSolApr.Rows[0]["cModulo"].ToString();
                this.txtCliente.Text = tbSolApr.Rows[0]["cNomCliente"].ToString();
                this.cboTipoOperacion.SelectedValue = tbSolApr.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = tbSolApr.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = tbSolApr.Rows[0]["nMontoOperacion"].ToString();
                this.cboMotivoExtorno.Text = tbSolApr.Rows[0]["cMotivoExt"].ToString();
                this.txtSustento.Text = tbSolApr.Rows[0]["cSustento"].ToString();
                this.cboEstadoSolic1.EstadosYTodos();
                this.cboEstadoSolic1.SelectedValue = Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]);

                this.nudNroKardex.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnBusqueda1.Enabled = false;
                this.btnEnviar1.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else
            {
                if(idKardexDesembolso != 0)
                {
                    this.nudNroKardex.Value = idKardexDesembolso;
                    CargarDatosKardex();
                }

                MessageBox.Show("El Crédito no cuenta con una solicitud de extorno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnExtorno1_Click(object sender, EventArgs e)
        {
            int idKardexExtSel = Convert.ToInt32(nudNroKardex.Value);
            if (!validarSolicitudExtorno(idKardexExtSel))
            {
                MessageBox.Show("El crédito no cuenta con una solicitud de extorno aprobada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cOperacionesRel = "El desembolso tiene las siguientes operaciones relacionadas:" + Environment.NewLine;
            if (dtOpeRelacionadas.Rows.Count > 0)
            {
                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    cOperacionesRel = cOperacionesRel + " - " + item["cTipoOperacion"].ToString() + Environment.NewLine;
                }
                cOperacionesRel = cOperacionesRel + "Las cuales también se procederan a extornar";
                MessageBox.Show(cOperacionesRel, "Extornar operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Inicio - Registro de Extorno de Desembolso", btnExtorno1);

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extornar Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            clsCNKardex cOpeCoreB = new clsCNKardex();
            DataTable dtOpeCoreB = cOpeCoreB.RetornaOperacionCanalRegistro(Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text),"C");

            Int32 idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            ValidaTrx(idCuenta);

            if (EstadoTrx)
            {
                decimal nMontoOpe =Math.Abs(CalcularMontoOpe());
                //if (Convert.ToInt32(dtExtornoCre.Rows[0]["nMontoAmpliado"]) == 0)
                //{
                //    if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtExtornoCre.Rows[0]["idMoneda"]), 1, Convert.ToInt32(dtExtornoCre.Rows[0]["nCapitalSolicitado"])))
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtExtornoCre.Rows[0]["idMoneda"]), 1, Convert.ToInt32(dtExtornoCre.Rows[0]["nMontoAmpliado"])))
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtExtornoCre.Rows[0]["idMoneda"]), 1, nMontoOpe))
                {
                    return;
                }
                //}

                DataSet ds = new DataSet("dsextornoCRE");
                ds.Tables.Add(dtExtornoCre);
                String XmlCredito = ds.GetXml();
                XmlCredito = clsCNFormatoXML.EncodingXML(XmlCredito);

                //INI
                DataSet dsExtAHO = new DataSet("dsextornoAHO");
                dsExtAHO.Tables.Add(dtExtornoAho);
                String XmlAhorros = dsExtAHO.GetXml();
                XmlAhorros = clsCNFormatoXML.EncodingXML(XmlAhorros);
                //FIN

                bool lResultado = ExtornaTrx(XmlCredito, XmlAhorros, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, clsVarGlobal.idCanal);

                int idAfectaCaja = Convert.ToInt32(dtExtornoCre.Rows[0]["idTipoAfeCaj"]);

                if (lResultado && idAfectaCaja == 1)
                {
                    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt32(dtExtornoCre.Rows[0]["idMoneda"]), 1, nMontoOpe);
                }

                var cFinalizaExtorno = "Se realizó el Extorno de las siguientes operaciones relacionadas:" + Environment.NewLine;
                if (dtFinalizaEx.Rows.Count > 0)
                {
                    foreach (DataRow item in dtFinalizaEx.Rows)
                    {
                        cFinalizaExtorno = cFinalizaExtorno + " - [" + item["cOperacion"].ToString() + "] " + item["cMessage"].ToString() + Environment.NewLine;
                    }
                    cFinalizaExtorno = cFinalizaExtorno + "::::";
                    MessageBox.Show(cFinalizaExtorno, "Extorno de Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                        MessageBox.Show("Desembolso Extornado", "Extorno de Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //////if (Convert.ToDecimal (dtExtornoCre.Rows[0]["nMontoAmpliado"]) > 0.00)
                //////{
                //////    MessageBox.Show("Este desembolso fue realizado con ampliacion, \n debe realizar el extorno de las cuentas canceladas una por una", "Extorno de Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //////}
                ImpresionVoucherRelacionado(nIdKardex: idKardexExtorno, idModulo: 1, idTipoOpe: 1, idEstadoKardex: 2,
                          nValRec: 0,
                          nValdev: 0,
                          idKardexAd: 0, idTipoImpresion: 1);
                LiberarCuenta();
                limpiar();
                btnExtorno1.Enabled = false;
                btnCancelar1.Enabled = false;
            }
            //this.objFrmSemaforo.ValidarSaldoSemaforo();

            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Fin - Registro de Extorno de Desembolso", btnExtorno1);

        }

        private decimal CalcularMontoOpe()
        {
            decimal nMontoOpeIng = 0, nMontoOpeEgr = 0, nMontoOpeRelIng = 0, nMontoOpeRelEgr = 0;
            if (dtExtornoCre.Rows.Count > 0)
            {
                nMontoOpeIng = dtExtornoCre.AsEnumerable().Where(x => x.Field<int>("idTipoIngresoEgreso") == 1).Sum(x => x.Field<decimal>("nMontoOperacion"));
                nMontoOpeEgr = dtExtornoCre.AsEnumerable().Where(x => x.Field<int>("idTipoIngresoEgreso") == 2).Sum(x => x.Field<decimal>("nMontoOperacion"));
            }
            if (dtOpeRelacionadas.Rows.Count > 0)
            {
                nMontoOpeRelIng = dtOpeRelacionadas.AsEnumerable().Where(x => x.Field<int>("idTipoIngresoEgreso") == 1).Sum(x => x.Field<decimal>("nMontoOperacion"));
                nMontoOpeRelEgr = dtOpeRelacionadas.AsEnumerable().Where(x => x.Field<int>("idTipoIngresoEgreso") == 2).Sum(x => x.Field<decimal>("nMontoOperacion"));
            }
            return nMontoOpeIng - nMontoOpeEgr + nMontoOpeRelIng - nMontoOpeRelEgr;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        private void frmExtornoDesembolso_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
            if (dtOpeRelacionadas != null)
            {
                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                    var idCta = Convert.ToInt32(item["idCuenta"]);

                    if (idTipoOperacion.In(34))
                    {
                        cnretornacuenta.UpdEstCuenta(idCta, 0);
                    }

                    if (idTipoOperacion.In(10, 11))
                    {
                        cndeposito.CNUpdNoUsoCuenta(idCta);
                    }
                }
            }
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            Int32 idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            CargaDatosDesembolso(idCuenta);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            CancelarExtornoSolicitud();
            LimpiarControles();
            this.nudNroKardex.Enabled = true;
            this.btnAceptar.Enabled = true;
            this.btnBusqueda1.Enabled = true;
            this.conBusCuentaCli.btnBusCliente1.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Visible = false;
            this.btnEnviar1.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cboMotivoExtorno.Enabled = false;
            this.txtSustento.Enabled = false;
            this.nudNroKardex.Value = 0;
            this.btnAnular.Enabled = false;
            this.btnAnular.Visible = false;
        }

        #endregion

        #region Metodos

        private void limpiar()
        {
            conBusCuentaCli.txtCodIns.Text = "";
            conBusCuentaCli.txtCodAge.Text = "";
            conBusCuentaCli.txtCodMod.Text = "";
            conBusCuentaCli.txtCodMon.Text = "";
            conBusCuentaCli.txtNroBusqueda.Text = "";
            conBusCuentaCli.txtCodCli.Text = "";
            conBusCuentaCli.txtNroDoc.Text = "";
            conBusCuentaCli.txtEstado.Text = "";
            conBusCuentaCli.txtNombreCli.Text = "";
            txtMonto.Text = "";
            txtUsuario.Text = "";
            btnExtorno1.Enabled = true;
        }

        public void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        private bool ExtornaTrx(string tExtornoCRE, string tExtornoAHO, int idUsuario, DateTime dFecSystem, int nIdAgencia, int idCanal)
        {
            dtFinalizaEx.Clear();
            dtFinalizaEx.Columns.Add("cOperacion");
            dtFinalizaEx.Columns.Add("cMessage");

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0;
            int idMoneda = 1;

            /* extorno de operaciones relacionadas al seguro vida */
            List<int> lstKardexExtornoOperaciones = new List<int>();
            foreach (DataRow item in dtOpeRelacionadas.Rows)
            {
                var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                var idKardex = Convert.ToInt32(item["IdKardex"]);
                var idCta = Convert.ToInt32(item["idCuenta"]);
                var nMontoOpe = Convert.ToDecimal(item["nMontoOperacion"]);
                var idTipPago = Convert.ToInt32(item["idTipoPago"]);

                if (idTipoOperacion.In(11))//Retiro cuenta de ahorros
                {
                    DataTable dtRespuesta = cnoperaciondep.RegistraExtornoOpe(idKardex, idCta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem,
                                                                nMontoOpe, idTipoOperacion, idTipPago, lModificaSaldoLinea, idTipoTransac, idMoneda);

                    if (dtRespuesta.Rows[0][0].ToString().Equals("1"))
                    {
                        string cMensaje = "Falló el extorno de la operación número " + idKardex + " - RETIRO, se debe extornar manualmente antes de proceder con el extorno del crédito.";
                        MessageBox.Show(cMensaje, "Extorno de Operación Relacionado al Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                    {
                        lstKardexExtornoOperaciones.Add(Int32.Parse(dtRespuesta.Rows[0][2].ToString()));
                        DataRow _row = dtFinalizaEx.NewRow();
                        _row["cOperacion"] = dtRespuesta.Rows[0][2].ToString();
                        _row["cMessage"] = dtRespuesta.Rows[0][1].ToString();
                        dtFinalizaEx.Rows.Add(_row);
                    }
                }

                if (idTipoOperacion.In(5))//Emision de recibo de ingreso
                {
                    DataTable dtExtornoRecibo = new CAJ.CapaNegocio.clsCNControlOpe().CNRegistraExtornoRecibos(
                                          idKardex, idCta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nMontoOpe, idTipoOperacion, idTipPago, lModificaSaldoLinea, idTipoTransac, idMoneda
                    );

                    if (Convert.ToInt32(dtExtornoRecibo.Rows[0]["idRpta"].ToString()) != 0)
                    {
                        string cMensaje = "Falló el extorno de la operación número " + idKardex + " - EMISION DE RECIBOS DE INGRESO, se debe extornar manualmente antes de proceder con el extorno del crédito.";
                        MessageBox.Show(cMensaje, "Extorno de Operación Relacionado al Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                    {
                        lstKardexExtornoOperaciones.Add(Int32.Parse(dtExtornoRecibo.Rows[0][2].ToString()));
                        DataRow _row = dtFinalizaEx.NewRow();
                        _row["cOperacion"] = dtExtornoRecibo.Rows[0][2].ToString();
                        _row["cMessage"] = dtExtornoRecibo.Rows[0][1].ToString();
                        dtFinalizaEx.Rows.Add(_row);
                    }
                }
            }

            DataTable dtExtornar = cnkardex.ExtDesembolso(tExtornoCRE, tExtornoAHO, idUsuario, dFecSystem, nIdAgencia, idCanal);
            idKardexExtorno = Convert.ToInt32(dtExtornar.Rows[0]["KardexCre"].ToString());
            bool lExitoExtorno = true;
            if (dtOpeRelacionadas.Rows.Count > 0)
            {
                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                    var idKardex = Convert.ToInt32(item["IdKardex"]);
                    var idCta = Convert.ToInt32(item["idCuenta"]);
                    var nMontoOpe = Convert.ToDecimal (item["nMontoOperacion"]);
                    var idTipPago = Convert.ToInt32(item["idTipoPago"]);
                    if (idTipoOperacion.In(34))//extorno de cancelacion
                    {
                        bool lKardexRelacionado = false;
                        decimal nMontoExtorno = 0;

                        DataTable dtRespuesta = cnoperacion.CNdtExtornaOpe(idKardex, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,
                                                                            lModificaSaldoLinea, lKardexRelacionado, idTipoTransac, nIdAgencia, idMoneda, nMontoExtorno);
                        if (dtRespuesta.Rows[0][0].ToString().Equals("-1"))
                        {
                            lExitoExtorno = false;
                        }
                    }
                }

                /* relacionar el kardex de extorno principal a las operaciones relacionadas al seguro vida que fueron extornadas */
                foreach (int idKardexExtornoOperacion in lstKardexExtornoOperaciones)
                {
                    new GEN.CapaNegocio.clsCNCredito().CNUpdKardexRelDesem(idKardexExtorno, idKardexExtornoOperacion);
                }

                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                    var idCta = Convert.ToInt32(item["idCuenta"]);

                    if (idTipoOperacion.In(34))
                    {
                        cnretornacuenta.UpdEstCuenta(idCta, 0);
                    }

                    if (idTipoOperacion.In(10, 11))
                    {
                        cndeposito.CNUpdNoUsoCuenta(idCta);
                    }
                }
            }
            return lExitoExtorno;
        }

        private void CargaDatosDesembolso(Int32 idCuenta)
        {
            dtExtornoCre = cnkardex.DetalleDesembolso(idCuenta);
            if (dtExtornoCre.Rows.Count > 0)
            {
                this.idKardexDesembolso = Convert.ToInt32(dtExtornoCre.Rows[0]["IdKardex"]);

                //if(validarExistenciaRecibosSeguro(idCuenta))
                //{
                //    string cMensaje = (dtRecibosSeguroVinculados.Rows.Count == 1) ? "El siguiente recibo:\n" : "Los siguientes recibos: \n"; 
                //    foreach(DataRow drRecibo in dtRecibosSeguroVinculados.Rows)
                //    {
                //        cMensaje = cMensaje + "\t" + drRecibo["idRecibo"] + " - " + drRecibo["cTipoSeguro"] + "\n";
                //    }
                //    cMensaje = cMensaje + "tienen que ser extornados antes de proceder con el extorno del crédito.";
                //    MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    CancelarExtornoSolicitud();
                //    return;
                //}

                if (conBusCuentaCli.nValBusqueda == 0)
                {
                    conBusCuentaCli.asignarCuenta(idCuenta);
                }

                dtpFecDes.Value = Convert.ToDateTime(dtExtornoCre.Rows[0]["dFechaOpe"]);
                txtMonto.Text = Convert.ToString(dtExtornoCre.Rows[0]["nMontoOperacion"]);
                txtUsuario.Text = Convert.ToString(dtExtornoCre.Rows[0]["cNombre"]);

                var idKardexPrincipal = Convert.ToInt32(dtExtornoCre.Rows[0]["IdKardex"]);
                dtExtornoAho = cnkardex.DetalleDesembAHO(idCuenta);
                dtOpeRelacionadas = cnkardex.RetornaOperacionesVinculadas(idKardexPrincipal);

                btnCancelar1.Enabled = true;
                btnExtorno1.Enabled = true;
            }

        }

        private void ValidaTrx(Int32 idCuenta)
        {
            DataTable dtValida = cnkardex.DetalleValida(idCuenta);

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text))
            {
                MessageBox.Show("Debe ingresar un número de cuenta", "Valida cuenta a Extornar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                conBusCuentaCli.Focus();
                return;
            }
            if (dtValida.Rows.Count == 0)
            {
                MessageBox.Show("No existe operación a extornar", "Valida cuenta a Extornar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                conBusCuentaCli.Focus();
                return;
            }
            if (Convert.ToInt32(dtExtornoCre.Rows[0]["IdUsuario"]) != nCodUsu)
            {
                MessageBox.Show("Usuario no realizó la transacción", "Valida usuario de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                return;
            }
            if (Convert.ToDateTime(dtExtornoCre.Rows[0]["dFechaOpe"]) != dFecSis)
            {
                MessageBox.Show("Solo es posible el EXTORNO de desembolso en la fecha actual", "Valida fecha de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                return;
            }
            if (Convert.ToInt32(dtExtornoCre.Rows[0]["IdKardex"]) != Convert.ToInt32(dtValida.Rows[0]["IdKardex"]))
            {
                MessageBox.Show("Existen Transacciones posteriores en esta cuenta", "Valida cuenta a Extornar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                return;
            }
            DataTable ValAprobExtorno = cncredito.CNValidaAprobExtorno(idCuenta);
            int nValidaExt = Convert.ToInt32(ValAprobExtorno.Rows[0]["nValido"]);
            if (nValidaExt == 0)
            {
                MessageBox.Show("Debe Registrar la Solicitud de Extorno o No Esta Aprobada la Solicitud", "Valida solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EstadoTrx = false;
                return;
            }
            //AGREGANDO VALIDACION DE EXTORNO DE AHORRO
            //--===============================================================================
            //--Validar Si Cuenta esta Siendo Usada
            //--===============================================================================

            if (dtOpeRelacionadas.Rows.Count > 0)
            {
                var lisRetiros = dtOpeRelacionadas.AsEnumerable().Where(x => (int)x["idTipoOperacion"] == 11).ToList();
                var lisDepositos = dtOpeRelacionadas.AsEnumerable().Where(x => (int)x["idTipoOperacion"] == 10).ToList();

                Decimal nMonTotRetiro = 0.00m, nMonTotDeposito = 0.00m, nMonSaldo = 0.00m;
                foreach (var item in lisRetiros)
                {
                    nMonTotRetiro = nMonTotRetiro + Convert.ToDecimal(item["nMontoOperacion"]);
                }

                foreach (var item in lisDepositos)
                {
                    nMonTotDeposito = nMonTotDeposito + Convert.ToDecimal(item["nMontoOperacion"]);
                }
                nMonSaldo = nMonTotDeposito - nMonTotRetiro;

            
                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                    //para operacion 34 de cancelacion de cuenta de credito por ampliacion no se valida ya que la cuenta ya esta cancelada

                    if (idTipoOperacion.In(10, 11))//Retiro o deposito cuenta de ahorros
                    {
                        DataTable dtbDatCuentas = cndeposito.CNRetornaDatosCuenta(Convert.ToInt32(item["idCuenta"]), "1", 11);
                        if (dtbDatCuentas.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                            {
                                int idusuBlo = Convert.ToInt32(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                                clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                                DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                                string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                                MessageBox.Show("La Cuenta de ahorros nro:" + item["idCuenta"].ToString() + " esta siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                EstadoTrx = false;
                                return;
                            }
                        }

                        //=========================================================================
                        //--Validar Si Existe Saldo para Realizar Extorno de DEPOSITO
                        //=========================================================================
                        if (Convert.ToInt32(item["idTipoOperacion"]) == 10)
                        {
                            DataTable dtbNumCuentas = cndeposito.CNRetornaDatosCuenta(Convert.ToInt32(item["idCuenta"]), "1", 10);
                            if (dtbNumCuentas.Rows.Count > 0)
                            {
                                if (Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"]) < nMonSaldo)
                                {
                                    MessageBox.Show("No se Puede Extornar la Operación de la cuenta de ahorros nro:" + item["idCuenta"].ToString() + ", porque no cuenta con Saldo Disponible...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    EstadoTrx = false;
                                    return;
                                }
                            }
                        }
                    }
                }

                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    if (item["idTipoOperacion"].ToString().In("10", "11"))
                    {
                        cndeposito.CNUpdUsoCuenta(Convert.ToInt32(item["idCuenta"]), clsVarGlobal.User.idUsuario);
                    }
                }
            }

            /*

            if (dtExtornoAho.Rows.Count > 0)
            {
                DataTable dtbDatCuentas = cndeposito.CNRetornaDatosCuenta(Convert.ToInt32(dtExtornoAho.Rows[0]["idCuenta"]), "1", 11);
                if (dtbDatCuentas.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                    {
                        int idusuBlo = Convert.ToInt32(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                        clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                        DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                        string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                        MessageBox.Show("La Cuenta esta siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        EstadoTrx = false;
                        return;
                    }
                }

                //=========================================================================
                //--Validar Si Existe Saldo para Realizar Extorno de DEPOSITO
                //=========================================================================
                if (Convert.ToInt32(dtExtornoAho.Rows[0]["idTipoOperacion"]) == 10)
                {
                    DataTable dtbNumCuentas = cndeposito.CNRetornaDatosCuenta(Convert.ToInt32(dtExtornoAho.Rows[0]["idCuenta"]), "1", 10);
                    if (dtbNumCuentas.Rows.Count > 0)
                    {
                        if (Convert.ToDouble (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString()) < Convert.ToDouble(dtExtornoAho.Rows[0]["nMontoOperacion"]))
                        {
                            MessageBox.Show("No se Puede Extornar la Operación, porque no cuenta con Saldo Disponible...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            EstadoTrx = false;
                            return;
                        }
                    }
                }

                //=========================================================================
                //--Validar Si no realizó Ninguna Operacion en caso de extorno de APERTURA
                //=========================================================================
                if (Convert.ToInt32(dtExtornoAho.Rows[0]["idTipoOperacion"]) == 9)
                {
                    clsCNOperacionDep clsExtApe = new clsCNOperacionDep();
                    DataTable dtbNumOpe = clsExtApe.RetornaNroOpePostExt(Convert.ToInt32(dtExtornoAho.Rows[0]["IdKardex"]), Convert.ToInt32(dtExtornoAho.Rows[0]["idCuenta"]));
                    if (dtbNumOpe.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtbNumOpe.Rows[0]["nNumOperaciones"].ToString()) > 0)
                        {
                            MessageBox.Show("No se Puede Extornar la Apertura, Tiene Operaciones Posteriores...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            EstadoTrx = false;
                            return;
                        }
                    }
                }
                cndeposito.CNUpdUsoCuenta(Convert.ToInt32(dtExtornoAho.Rows[0]["idCuenta"]), clsVarGlobal.User.idUsuario);

                
            }
            //TERMINA VALIDACION
            */



            EstadoTrx = true;
        }

        private bool validarSolicitudExtorno(int idKardexDesembolso)
        {
            clsCNAprobacion objCNAprobacion = new clsCNAprobacion();
            DataTable dtExtornoAprobado = objCNAprobacion.ListarAprobacionExtorno(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, 1, "1");
            var Table1Extorno = dtExtornoAprobado.AsEnumerable().Where(item => Convert.ToInt32(item["IdKardex"]) == idKardexDesembolso);

            return (Table1Extorno.Any()) ? true : false;
        }

        private bool validarExistenciaRecibosSeguro(int idCuenta)
        {
            CRE.CapaNegocio.clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new CRE.CapaNegocio.clsCNCreditoCargaSeguro();
            dtRecibosSeguroVinculados = objCNCreditoCargaSeguro.CNObtenerRecibosVinculadoCuenta(idCuenta);
            return (dtRecibosSeguroVinculados.Rows.Count > 0) ? true : false ;
        }

        private void CancelarExtornoSolicitud()
        {
            limpiar();
            LiberarCuenta();

            if (dtOpeRelacionadas != null)
            {
                foreach (DataRow item in dtOpeRelacionadas.Rows)
                {
                    var idTipoOperacion = Convert.ToInt32(item["idTipoOperacion"]);
                    var idCta = Convert.ToInt32(item["idCuenta"]);

                    if (idTipoOperacion.In(34))
                    {
                        cnretornacuenta.UpdEstCuenta(idCta, 0);
                    }

                    if (idTipoOperacion.In(10, 11))
                    {
                        cndeposito.CNUpdNoUsoCuenta(idCta);
                    }
                }
            }
            btnExtorno1.Enabled = false;
            btnCancelar1.Enabled = false;
        }

        #endregion

        //Metodos SolExtorno

        private void GeneraNuevaSolicitud(int _idcuenta)
        {

            clsCNKardex cOpeIniSol = new clsCNKardex();
            DataTable dtOpeIniSol = cOpeIniSol.RetornaOperacionInicioSolicitud(_idcuenta);

            int idSolicitud_inicial = Convert.ToInt32(dtOpeIniSol.Rows[0]["idSolicitud"]);

            string xmlCreditoProp = String.Empty;
            clsCreditoProp objCreditoProp = null;

            #region ColumnasTable1
            Table1.Clear();
            Table1.Columns.Add("nCapitalSolicitado");
            Table1.Columns.Add("IdMoneda");
            Table1.Columns.Add("idOperacion");
            Table1.Columns.Add("nCuotas");
            Table1.Columns.Add("nPlazoCuota");
            Table1.Columns.Add("dFechaDesembolsoSugerido");
            Table1.Columns.Add("idEstado");
            Table1.Columns.Add("idUsuario");
            Table1.Columns.Add("idProducto");
            Table1.Columns.Add("nTasaCompensatoria");
            Table1.Columns.Add("nTasaMoratoria");
            Table1.Columns.Add("dFechaRegistro");
            Table1.Columns.Add("idCli");
            Table1.Columns.Add("tObservacion");
            Table1.Columns.Add("idDestino");
            Table1.Columns.Add("idTipoCli");
            Table1.Columns.Add("idTasa");
            Table1.Columns.Add("idActividad");
            Table1.Columns.Add("ndiasgracia");
            Table1.Columns.Add("idModalidadDes");
            Table1.Columns.Add("idTipoPeriodo");
            Table1.Columns.Add("idRecurso");
            Table1.Columns.Add("idCuenta");
            Table1.Columns.Add("idSoliCambio");
            Table1.Columns.Add("nMontoAmpliado");
            Table1.Columns.Add("nSaldoCreditos");
            Table1.Columns.Add("idModalidadCredito");
            Table1.Columns.Add("idPromotor");
            Table1.Columns.Add("cComentAproba");
            Table1.Columns.Add("idActividadInterna");
            Table1.Columns.Add("nEvaluacion");
            Table1.Columns.Add("cTipoEvaluacion");
            Table1.Columns.Add("idPreSolicitud");
            Table1.Columns.Add("idAdeudado");
            Table1.Columns.Add("nCuotasGracia");
            Table1.Columns.Add("idCreditosPreAprobados");
            Table1.Columns.Add("idVisita");
            Table1.Columns.Add("idEOBDesembolso");
            Table1.Columns.Add("idTipoLocalActividad");
            Table1.Columns.Add("idPerfil");
            Table1.Columns.Add("idDetallegasto");
            Table1.Columns.Add("idPeriodoCredito");
            #endregion

            DataRow dr = Table1.NewRow();

            Table1.Columns["idActividad"].ReadOnly = false;
            dr["nCapitalSolicitado"] = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nCapitalSolicitado"]);
            dr["IdMoneda"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["IdMoneda"]);
            dr["idOperacion"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idOperacion"]);
            dr["nCuotas"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["nCuotas"]);
            dr["nPlazoCuota"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["nPlazoCuota"]);
            dr["dFechaDesembolsoSugerido"] = Convert.ToString(dtOpeIniSol.Rows[0]["dFechaDesembolsoSugerido"]);
            dr["idEstado"] = 0;
            dr["idUsuario"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idUsuario"]);
            dr["idProducto"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idProducto"]);
            dr["nTasaCompensatoria"] = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nTasaCompensatoria"]);
            dr["nTasaMoratoria"] = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nTasaMoratoria"]);
            dr["dFechaRegistro"] = Convert.ToString(dtOpeIniSol.Rows[0]["dFechaRegistro"]);
            dr["idCli"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idCli"]);
            dr["tObservacion"] = Convert.ToString(dtOpeIniSol.Rows[0]["tObservacion"]);
            dr["idDestino"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idDestino"]);
            dr["idTipoCli"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idTipoCli"]);
            dr["idTasa"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idTasa"]);
            dr["idActividad"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idActividad"]);
            dr["ndiasgracia"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["ndiasgracia"]);
            dr["idModalidadDes"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idModalidadDes"]);
            dr["idTipoPeriodo"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idTipoPeriodo"]);
            dr["idRecurso"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idRecurso"]);
            dr["idCuenta"] = 0;
            dr["idSoliCambio"] = 0;
            dr["nMontoAmpliado"] = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nMontoAmpliado"]);
            dr["nSaldoCreditos"] = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nSaldoCreditos"]);
            dr["idModalidadCredito"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idModalidadCredito"]);
            dr["idPromotor"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idPromotor"]);
            dr["cComentAproba"] = Convert.ToString(dtOpeIniSol.Rows[0]["cComentAproba"]);
            dr["idActividadInterna"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idActividadInterna"]);
            dr["nEvaluacion"] = 0;
            dr["cTipoEvaluacion"] = "";
            dr["idPreSolicitud"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idPreSolicitud"]);
            dr["idAdeudado"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idAdeudado"]);
            dr["nCuotasGracia"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["nCuotasGracia"]);
            dr["idCreditosPreAprobados"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idCreditosPreAprobados"]);
            dr["idVisita"] = 0;
            dr["idEOBDesembolso"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idEOBDesembolso"]);
            dr["idTipoLocalActividad"] = 0;
            dr["idPerfil"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idPerfilRegistra"]);
            dr["idDetallegasto"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idDetalleGasto"]);
            dr["idPeriodoCredito"] = Convert.ToInt32(dtOpeIniSol.Rows[0]["idPeriodoCredito"]);
            Table1.Rows.Add(dr);

            DataSet ds = new DataSet("dssolici");
            ds.Tables.Add(Table1);
            string XmlSoli = ds.GetXml();
            XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
            ds.Tables.Clear();

            //creditos Ampliados
            string XmlCreAmp;
            XmlCreAmp = XmlCreditosAmpliados();

            objCreditoProp = retornaCreditoProp(dtOpeIniSol);
            xmlCreditoProp = objCreditoProp.GetXml();

            clsCNSolicitud InsertaActualizaSol = new clsCNSolicitud();
            DataTable InsSol = InsertaActualizaSol.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, 0, 0, XmlCreAmp, false, clsVarGlobal.dFecSystem, Convert.ToInt32(dtOpeIniSol.Rows[0]["idUsuario"]), 0, 1);
            string idSolicitud = InsSol.Rows[0]["idCodSol"].ToString();

            InsertaActualizaSol.CNActualizaEstadoSolCre(Convert.ToInt32(idSolicitud), 13);

            DataTable InsEvalSol = InsertaActualizaSol.InsertaEvaluacionSolicitudExt(idSolicitud_inicial, (Convert.ToInt32(idSolicitud)),"I");
            //DataTable InsEvalSol = InsertaActualizaSol.InsertaEvaluacionSolicitudExt(1,1,'I');

            MessageBox.Show(String.Format("Solicitud N° {0} registrada correctamente.", idSolicitud), "Extorno de Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private clsCreditoProp retornaCreditoProp(DataTable dtOpeIniSol)
        {
            return new clsCreditoProp()
            {
                idOrigenCredProp = 1,
                idSolicitud = 0,
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nCapitalSolicitado"]),
                nCuotas = Convert.ToInt32(dtOpeIniSol.Rows[0]["nCuotas"]),
                idTipoPeriodo = Convert.ToInt32(dtOpeIniSol.Rows[0]["idTipoPeriodo"]),
                nPlazoCuota = Convert.ToInt32(dtOpeIniSol.Rows[0]["nPlazoCuota"]),
                nDiasGracia = Convert.ToInt32(dtOpeIniSol.Rows[0]["ndiasgracia"]),
                idTasa =0,
                //dFechaDesembolso = Convert.ToString(dtOpeIniSol.Rows[0]["dFechaDesembolsoSugerido"]),
                nTasaCompensatoria = Convert.ToDecimal(dtOpeIniSol.Rows[0]["nTasaCompensatoria"]),
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = Convert.ToString(dtOpeIniSol.Rows[0]["tObservacion"]),
                nCuotasGracia = Convert.ToInt32(dtOpeIniSol.Rows[0]["nCuotasGracia"])
            };
        }
        private string XmlCreditosAmpliados()
        {
            DataSet dsCreAmp = new DataSet("dsCreAmp");

            if (dtCreditosAmp == null)
            {
                DataTable newDtCreAmp = new DataTable("Table1");
                dsCreAmp.Tables.Add(newDtCreAmp);
            }
            else
            {
                dsCreAmp.Tables.Add(dtCreditosAmp);
            }
            string XmlCreAmp = dsCreAmp.GetXml();
            XmlCreAmp = clsCNFormatoXML.EncodingXML(XmlCreAmp);
            dsCreAmp.Tables.Clear();
            return XmlCreAmp;
        }

        private void LimpiarControles()
        {
            conBusCuentaCli.txtNroBusqueda.Text = "";
            this.txtModulo.Clear();
            this.txtCliente.Clear();
            this.cboMoneda.SelectedIndex = -1;
            this.cboTipoOperacion.SelectedIndex = -1;
            this.txtMonOpe.Text = "0.00";
            this.cboMotivoExtorno.SelectedIndex = -1;
            this.txtSustento.Clear();
            idCuenta = string.Empty;
            this.idKardexDesembolso = 0;
        }

        private void ActualizarEstado()
        {
            String cCumpleReglas = "";

            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name, clsVarGlobal.nIdAgencia, idcli,
                                               1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                               Decimal.Parse(txtMonOpe.Text), idSolAprob, clsVarGlobal.dFecSystem,
                                               2, Convert.ToInt32(cboEstadoSolic1.SelectedValue),
                                               clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("Cumple"))
            {
                int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
                int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                string cSust = this.txtSustento.Text.Trim();
                int idEstSolicitud = 1;

                clsCNAprobacion dtSolApr = new clsCNAprobacion();
                DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    //■-fin ok-■
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nudNroKardex.Enabled = false;
                    this.btnAceptar.Enabled = true;
                    this.btnBusqueda1.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.btnEnviar1.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.cboMotivoExtorno.Enabled = false;
                    this.txtSustento.Enabled = false;
                }
                else
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            if (cCumpleReglas.Equals("ExcepcionRechazada"))
            {
                int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
                int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                string cSust = this.txtSustento.Text.Trim();
                int idEstSolicitud = 4;

                clsCNAprobacion dtSolApr = new clsCNAprobacion();
                DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.nudNroKardex.Enabled = false;
                    this.btnAceptar.Enabled = true;
                    this.btnBusqueda1.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.btnEnviar1.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.cboMotivoExtorno.Enabled = false;
                    this.txtSustento.Enabled = false;
                }
                else
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            DataTable dtConsultaSolApr = ValidaReglasDinamicas.CNConsultaEstExcepExtorno(idSolAprob, idProd, idcli, Convert.ToInt32(this.cboMoneda.SelectedValue.ToString()),
                                                                                        clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, Decimal.Parse(txtMonOpe.Text));
            if (dtConsultaSolApr.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtConsultaSolApr.Rows[0]["idEstadoSol"].ToString()) == 4)
                {
                    int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
                    int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
                    int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
                    Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
                    int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
                    string cSust = this.txtSustento.Text.Trim();
                    int idEstSolicitud = 4;

                    clsCNAprobacion dtSolApr = new clsCNAprobacion();
                    DataTable tbSolApr = dtSolApr.CNUpdEstadoSolicitud(idEstSolicitud, idKar, idTipOpe, idMon, clsVarGlobal.nIdAgencia, idcli, idProd, idSolAprob);

                    if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                    {
                        this.nudNroKardex.Enabled = false;
                        this.btnAceptar.Enabled = true;
                        this.btnBusqueda1.Enabled = true;
                        this.btnNuevo.Enabled = true;
                        this.btnEnviar1.Enabled = false;
                        this.btnCancelar.Enabled = false;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustento.Enabled = false;
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

        private void FinalizasolicitudExtorno(DataTable dt, int fila, Boolean _Aprobado)
        {
            this.nudNroKardex.Value = Convert.ToInt32(dt.Rows[fila]["idKardex"]);
            this.txtModulo.Text = dt.Rows[fila]["cModulo"].ToString();
            this.txtCliente.Text = dt.Rows[fila]["cNomCliente"].ToString();
            this.cboTipoOperacion.SelectedValue = dt.Rows[fila]["idTipoOperacion"].ToString();
            this.cboMoneda.SelectedValue = dt.Rows[fila]["idMoneda"].ToString();
            this.txtMonOpe.Text = dt.Rows[fila]["nMontoOperacion"].ToString();
            this.cboMotivoExtorno.Text = dt.Rows[fila]["cMotivoExt"].ToString();
            this.txtSustento.Text = dt.Rows[fila]["cSustento"].ToString();

            this.nudNroKardex.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnBusqueda1.Enabled = false;
            this.btnEnviar1.Enabled = false;
            this.btnCancelar.Enabled = false;

            if (_Aprobado == true)
            {
                int idCuentaSel = Convert.ToInt32(dt.Rows[fila]["idCuenta"]);
                conBusCuentaCli.asignarCuenta(idCuentaSel);
                CargaDatosDesembolso(idCuentaSel);
                cboEstadoSolic1.EstSol(2);
                this.cboEstadoSolic1.SelectedValue = 2;
            }
            if (_Aprobado == false)
            {
                this.btnNuevo.Enabled = true;
            }

        }

        private void VerificaSolicitudExtorno(string idKardex)
        {
            clsCNAprobacion dtSolExto = new clsCNAprobacion();
            DataTable tbSolApr = dtSolExto.ListarSolicitudesExtorno(clsVarGlobal.User.idUsuario.ToString(), idKardex);

            if (tbSolApr.Rows.Count == 0)
            {
                return;
            }
            if (tbSolApr.Rows.Count == 1)
            {

                if (tbSolApr.Rows[0]["cEstadoSol"].ToString() == "APROBADO")
                {
                    FinalizasolicitudExtorno(tbSolApr, 0, true);
                }
                if (tbSolApr.Rows[0]["cEstadoSol"].ToString() == "SOLICITADO")
                {
                    FinalizasolicitudExtorno(tbSolApr, 0, false);
                    MessageBox.Show("Solicitud e Extorno [" + tbSolApr.Rows[0]["idSolAproba"].ToString() + "], no esta APROBADO...", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            //if (tbSolApr.Rows.Count > 0)
            //{
            //    ListarSolicitudesExtorno(tbSolApr);
            //}
        }

        private void ListarSolicitudesExtorno(DataTable dt)
        {
            try
            {
                var frmDialog = new Form()
                {
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle,
                    StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                    ClientSize = new System.Drawing.Size(720, 250),
                    BackColor = Color.LightSteelBlue
                };
                var lbTitulo = new Label()
                {
                    Size = new System.Drawing.Size(700, 20),
                    Text = "SOLICITUDES DE EXTORNO",
                    Left = 10, Top = 10
                };
                var btnSalir = new Button()
                {
                    BackColor = Color.White,
                    Text = "SALIR",
                    Left = 630, Top = 215
                };
                var dgListaExtorno = new DataGridView()
                {
                    ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                    AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                    BackgroundColor = System.Drawing.Color.White,
                    Size = new System.Drawing.Size(700, 180),
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false,
                    Left = 10, Top = 32
                };
                frmDialog.Load += (sender, args) =>
                {
                    dgListaExtorno.DataSource = dt;
                    dgListaExtorno.Columns[1].Visible = false;
                    dgListaExtorno.Columns[3].Visible = false;
                    dgListaExtorno.Columns[7].Visible = false;
                    dgListaExtorno.Columns[8].Visible = false;
                    dgListaExtorno.Columns[9].Visible = false;
                    dgListaExtorno.Columns[10].Visible = false;
                    dgListaExtorno.Columns[11].Visible = false;
                    dgListaExtorno.Columns[12].Visible = false;
                };
                dgListaExtorno.CellFormatting += (sender, e) =>
                {
                    DataGridView dgv = sender as DataGridView;

                    if (dgv.Columns[e.ColumnIndex].Name == "cEstadoSol")
                    {
                        if (e.Value.ToString().Contains("APROBADO"))
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                        if (e.Value.ToString().Contains("SOLICITADO"))
                        {
                            e.CellStyle.BackColor = Color.LightYellow;
                        }
                    }
                };
                dgListaExtorno.CellDoubleClick += (sender, e) =>
                {
                    if (dgListaExtorno.CurrentRow.Cells[4].Value.ToString() == "APROBADO")
                    {
                        nudNroKardex.Value = Convert.ToInt32(dgListaExtorno.CurrentRow.Cells[1].Value);
                        frmDialog.Close();
                        FinalizasolicitudExtorno(dt, dgListaExtorno.CurrentRow.Index ,true);

                    }
                    if (dgListaExtorno.CurrentRow.Cells[4].Value.ToString() == "SOLICITADO")
                    {
                        frmDialog.Close();
                        FinalizasolicitudExtorno(dt, dgListaExtorno.CurrentRow.Index , false);
                        MessageBox.Show("Solicitud e Extorno [" + dgListaExtorno.CurrentRow.Cells[2].Value.ToString() + "], no esta APROBADO...", "Solicitud de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
                btnSalir.Click += (sender1, args) =>
                {
                    frmDialog.Close();
                };

                frmDialog.Controls.Add(lbTitulo);
                frmDialog.Controls.Add(btnSalir);
                frmDialog.Controls.Add(dgListaExtorno);
                frmDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Eventos SolExtorno
        private void nudNroKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CargarDatosKardex();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CargarDatosKardex();
        }

        private void CargarDatosKardex()
        {
            LimpiarControles();
            btnEnviar1.Enabled = false;
            idMod = 0;
            int idKar = Convert.ToInt32(this.nudNroKardex.Value);

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

            clsCNGenAdmOpe dtDatKRel = new clsCNGenAdmOpe();
            DataTable tbKRel = dtDatKRel.RetDatOpeKardexRel(idKar);
            if (Convert.ToInt32(tbKRel.Rows[0]["idKardexPrincipal"]) != 0)
            {
                DialogResult respMsg = MessageBox.Show("El número de operación buscado esta relacionado y depende de la operación [" + tbKRel.Rows[0]["idKardexPrincipal"].ToString() + "] Ope: " + tbKRel.Rows[0]["cTipoOperacion"].ToString() + "\n\n Desea Extornar Operacion principal?", "Solicitud de Extornos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respMsg == DialogResult.Yes)
                {
                    this.nudNroKardex.Value = Convert.ToInt32(tbKRel.Rows[0]["idKardexPrincipal"]);
                    idKar = Convert.ToInt32(tbKRel.Rows[0]["idKardexPrincipal"]);
                }
                else if (respMsg == DialogResult.No)
                {
                    return;
                }
            }

            clsCNGenAdmOpe dttbKSDisp = new clsCNGenAdmOpe();
            DataTable tbKSDisp = dttbKSDisp.RetDatOpeKardexSalDisp(idKar);
            if (tbKSDisp.Rows.Count != 0)
            {
                if (Convert.ToInt32(tbKSDisp.Rows[0]["idModalidadDes"]) == 2)
                {
                    if ((Convert.ToInt32(tbKSDisp.Rows[0]["nSaldoDis"]) < Convert.ToInt32(tbKSDisp.Rows[0]["SalExt"])) && idSolAprob == 0)
                    {
                        DialogResult respMsg = MessageBox.Show("La cuenta de Ahorros Nro: [" + tbKSDisp.Rows[0]["idCuenta"].ToString() + "] no cuenta con Saldo Suficiente..." + " \n\n Importe Extorno = " + tbKSDisp.Rows[0]["SalExt"].ToString() + "", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (respMsg == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }


            clsCNGenAdmOpe dtDatTrx = new clsCNGenAdmOpe();
            DataTable tbTrx = dtDatTrx.RetDatosOperacion(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (Convert.ToInt32(tbTrx.Rows[0]["idRpta"].ToString()) == 0)
            {
                this.txtModulo.Text = tbTrx.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = tbTrx.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = tbTrx.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = tbTrx.Rows[0]["nMontoOperacion"].ToString();
                this.txtCliente.Text = tbTrx.Rows[0]["cNomCliente"].ToString();
                idMod = Convert.ToInt32(tbTrx.Rows[0]["idModulo"].ToString());
                idProd = Convert.ToInt32(tbTrx.Rows[0]["idProducto"].ToString());
                idEstKar = Convert.ToInt32(tbTrx.Rows[0]["idEstadoKardex"].ToString());
                idcli = Convert.ToInt32(tbTrx.Rows[0]["idCliAfeITF"].ToString());
                idCuenta = tbTrx.Rows[0]["idCuenta"].ToString();
                this.nudNroKardex.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnBusqueda1.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEnviar1.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.cboMotivoExtorno.Enabled = true;
                this.txtSustento.Enabled = true;
                this.cboMotivoExtorno.Focus();

                clsCNAprobacion dtSolExto = new clsCNAprobacion();
                DataTable tbSolApr = dtSolExto.ListarSolicitudesExtorno(clsVarGlobal.User.idUsuario.ToString(), idKardexDesembolso.ToString());
                this.cboEstadoSolic1.EstadosYTodos();
                if (tbSolApr.Rows.Count > 0)
                {
                    this.cboEstadoSolic1.SelectedValue = Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]);
                }
                else
                {
                    this.cboEstadoSolic1.SelectedValue = 1;
                }
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

                    if (idSolAprob != 0)
                    {
                        this.txtModulo.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cModulo"]);
                        this.cboTipoOperacion.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idTipoOperacion"]);
                        this.cboMoneda.SelectedValue = Convert.ToString(dtOperacionExtorno.Rows[0]["idMoneda"]);
                        this.txtMonOpe.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["nMontoOperacion"]);
                        this.txtCliente.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cNomCliente"]);
                        this.cboMotivoExtorno.SelectedValue = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idMotivo"]);
                        this.txtSustento.Text = Convert.ToString(dtOperacionExtorno.Rows[0]["cSustento"]);
                        idMod = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idModulo"]);
                        idProd = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idProducto"]);
                        idEstKar = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idEstadoKardex"]);
                        idcli = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idCliAfeITF"]);
                        this.nudNroKardex.Enabled = false;
                        this.btnAceptar.Enabled = false;
                        this.btnBusqueda1.Enabled = false;
                        this.btnNuevo.Enabled = false;
                        this.btnEnviar1.Enabled = false;
                        this.btnCancelar.Enabled = true;
                        this.cboMotivoExtorno.Enabled = false;
                        this.txtSustento.Enabled = false;
                        this.btnAnular.Enabled = false;
                        this.btnAnular.Visible = false;

                        int idCuentaSel = Convert.ToInt32(dtOperacionExtorno.Rows[0]["idCuenta"]);
                        CargaDatosDesembolso(idCuentaSel);

                        clsCNAprobacion dtSolExto = new clsCNAprobacion();
                        DataTable tbSolApr = dtSolExto.ListarSolicitudesExtorno(clsVarGlobal.User.idUsuario.ToString(), idKardexDesembolso.ToString());
                        this.cboEstadoSolic1.EstadosYTodos();
                        if (tbSolApr.Rows.Count > 0)
                        {
                            this.cboEstadoSolic1.SelectedValue = Convert.ToInt32(tbSolApr.Rows[0]["idEstadoSol"]);
                        }
                        else
                        {
                            this.cboEstadoSolic1.SelectedValue = 1;
                        }

                    }
                    else
                    {
                        MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nudNroKardex.Focus();
                        this.nudNroKardex.Select();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroKardex.Focus();
                    this.nudNroKardex.Select();
                }
            }
            else
            {
                MessageBox.Show(tbTrx.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                this.nudNroKardex.Select();
            }

        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor Registrar ", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Registrar la Solicitud", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
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

            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento del Extorno", "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroKardex.Focus();
                return;
            }

            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================

            int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
            int idMotExt = Convert.ToInt32(this.cboMotivoExtorno.SelectedValue.ToString());
            string cSust = this.txtSustento.Text.Trim();

            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, idcli, Convert.ToInt32(cboTipoOperacion.SelectedValue), 2,
                                                                Convert.ToInt16(cboMoneda.SelectedValue), idProd, Convert.ToDecimal(txtMonOpe.Text),
                                                               Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivoExtorno.SelectedValue),
                                                                txtSustento.Text, 0, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                //MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idSolAprob = Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]);
                this.nudNroKardex.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnBusqueda1.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEnviar1.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.cboMotivoExtorno.Enabled = false;
                this.txtSustento.Enabled = false;
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

            clsCNAprobacion objCNprobacionEmail = new clsCNAprobacion();
            dtParamEnvioEmail = objCNprobacionEmail.CNVerificarParametrosEnvioMail();

            if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
            {
                EnvioCorreoAprobador(idSolAprob);
            }

            clsCNAprobacion objCNprobacionSMS = new clsCNAprobacion();
            dtParamEnvioSMS = objCNprobacionSMS.CNVerificarParametrosEnvioSMS();
            if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
            {
                EnvioSMSAprobador(idSolAprob);
            }

            ActualizarEstado();

            int idCuentaSel = Convert.ToInt32(idCuenta);
            CargaDatosDesembolso(idCuentaSel);

            //Disparo el evento click del botón cancelar1
            btnCancelar1.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.nudNroKardex.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnBusqueda1.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnEnviar1.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cboMotivoExtorno.Enabled = false;
            this.txtSustento.Enabled = false;
            this.nudNroKardex.Value = 0;
            this.btnAnular.Enabled = false;
            this.btnAnular.Visible = false;
            this.btnBusqueda1.Enabled = true;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            string cOpinionAnulacion = String.Empty;
            bool lValida = false;
            frmAnulaSolAprobacionOpinion frmAnulacion = new frmAnulaSolAprobacionOpinion();
            frmAnulacion.ShowDialog();
            cOpinionAnulacion = frmAnulacion.cComentarioAprobador;
            lValida = frmAnulacion.lValidado;

            if (lValida)
            {
                DialogResult drResultado = MessageBox.Show("¿Está seguro que desea Anular la solicitud de Extorno?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResultado == DialogResult.No)
                    return;

                clsCNAprobacion objCNAprobacion = new clsCNAprobacion();
                DataTable dtResultado = objCNAprobacion.CNAnularSolicitudAprobacion(idSolAprob, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, cOpinionAnulacion);

                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAnular.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la Anulación de la Solicitud de Extorno.", "Anulación Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.nudNroKardex.Enabled = true;
            this.btnAceptar.Enabled = true;
            this.btnBusqueda1.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnEnviar1.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.cboMotivoExtorno.Enabled = false;
            this.txtSustento.Enabled = false;
            this.nudNroKardex.Value = 0;
            this.nudNroKardex.Focus();
            this.nudNroKardex.Select(0, nudNroKardex.ToString().Length);
            this.btnAnular.Enabled = false;
            this.btnAnular.Visible = false;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 1;
            frmExtPen.pidTipOpe = "1";
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar > 0)
            {
                nudNroKardex.Value = nidKar;
                VerificaSolicitudExtorno(nudNroKardex.Value.ToString());
            }
            else
            {
                nudNroKardex.Value = (nudNroKardex.Value != 0) ? nudNroKardex.Value : 0;
                return;
            }
        }

        public Dictionary<string, dynamic> EnviarSMS(double numero, string mensaje)
        {
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

            try
            {
                //DataTable dtVariable = objCNMantenimiento.CNRecuperarVariable("cServicioWCFSms");
                //string cServicio = dtVariable.Rows[0]["cValVar"].ToString();
                string cServicio = "http://172.16.7.150:5000/sms/v1/compatibilidad/";
                string dicto = "{\"phone\":" + numero + ",\"content\":\"" + mensaje + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto); //Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string serviceURL = string.Format(cServicio);
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                // Stream stream = new MemoryStream(response);
                //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                //obj = new DataContractJsonSerializer(typeof(clsResponseSMS));
                //var resService = obj.ReadObject(stream) as clsResponseSMS;

                //if (resService.idRespuesta == 1)
                //{
                //    res.Add("cEstado", "success");
                //}
                //else
                //{
                //    res.Add("cEstado", "failed");
                //    res.Add("cFail", resService.cMensaje);
                //}
            }
            catch (Exception e)
            {
                res.Add("cEstado", "failed");
                res.Add("cFail", e.ToString());
            }

            return res;
        }

        private void EnvioCorreoAprobador(int idSolAprob)
        {
            string cPerfil = string.Empty;
            string cCuerpo = string.Empty;
            string cAsunto = string.Empty;

            cPerfil = dtParamEnvioEmail.Rows[0]["cValVar"].ToString();
            cCuerpo = "EL RSC " + cNombreUsuario + " ESTA SOLICITANDO LA APROBACI&Oacute;N DE UN EXTORNO DE DESEMBOLSO, VERIFICAR INGRESANDO A SU BANDEJA DE APROBACI&Oacute;N.<br>";
            cAsunto = "SOLICITUD DE APROBACIÓN DE EXTORNO";
            DataTable dtAprobadorCorreo = new DataTable();
            clsCNAprobacion objCNprobacion = new clsCNAprobacion();
            dtAprobadorCorreo = objCNprobacion.CNListarCorreoAprobaSol(idSolAprob,clsVarGlobal.nIdAgencia);
            foreach (DataRow fila in dtAprobadorCorreo.Rows)
            {
                string cCorreo = Convert.ToString(fila["cEmailInst"]);
                if (!string.IsNullOrEmpty(cCorreo))
                {
                    objCNprobacion.CNEnviarCorreoAprobador(cPerfil, cCorreo, cCuerpo, cAsunto);
                }
            }
        }

        private void EnvioSMSAprobador(int idSolAprob)
        {
            DataTable dtAprobadorSMS = new DataTable();
            clsCNAprobacion objCNprobacion = new clsCNAprobacion();
            dtAprobadorSMS = objCNprobacion.CNListarCelularAprobaSol(idSolAprob, clsVarGlobal.nIdAgencia);
            string cMensaje = string.Empty;
            cMensaje = "EL RSC " + cNombreUsuario + " ESTA SOLICITANDO LA APROBACION DE UN EXTORNO DE DESEMBOLSO, VERIFICAR INGRESANDO A SU BANDEJA DE APROBACION.";
            foreach (DataRow fila in dtAprobadorSMS.Rows)
            {
                string cCelular = Convert.ToString(fila["cCelular"]);
                if (!string.IsNullOrEmpty(cCelular))
                {
                    EnviarSMS(Convert.ToDouble(cCelular), cMensaje);
                }
            }
        }

    }
}
