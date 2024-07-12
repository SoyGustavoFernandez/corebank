using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using CRE.CapaNegocio;
using System.IO;

namespace CRE.Presentacion
{
    public partial class frmAprobaTasaNegociable : frmBase
    {
        #region Variables Globales
        private clsCNExpedienteLinea clsExpediente = new clsCNExpedienteLinea();
        private clsCNAprobacion objAprobacion = new clsCNAprobacion();
        private clsCreditoProp objCreditoProp;
        DataTable Sol = new DataTable("dtSolicitud");
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        private DataTable dtSolicitudes;
        private decimal nValAprobaSol = 0m;
        private decimal cGlobal_CapitalSolicitadoSOL = 0;
        private int idEstadoSolAproba = 0;
        private int idTipoOpe = 0;
        int nCodPro = 1, nCodEst = 0, idCliente = 0, idAgencia = clsVarGlobal.nIdAgencia, idZonaUsuario = 0, idUsuBloqueo = 0;
        int idTasa = 0;
        bool lEstado = true, lValGarantia = false, lBloqueo = false, lMontodiferente = false;
        decimal nMontoSolicitado = 0;
        public int idEstadoSol = 0;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        DataTable dtParamEnvioEmail = new DataTable();
        DataTable dtParamEnvioSMS = new DataTable();
        string cNombreUsuario = clsVarGlobal.User.cNomUsu;
        string cNombreagencia = clsVarGlobal.cNomAge;
        string cPerfilUsuario = clsVarGlobal.PerfilUsu.cPerfil;
        string cTipoTN = "";
        private int cGlobal_idCuenta = 0, cGlobal_idsolicitud = 0, cGlobal_idSolicitudCre = 0, cGlobal_idTasaNegociable = 0, cGlobal_idUsuario = 0, cGlobal_idEstadoTasa = 0;
        private string cGlobal_cDocumento = "0";
        DataTable dtHistTEA;

        private decimal nTasaCompensatoriaSol { get; set; }
        private decimal nTasaMoraSol { get; set; }
        #endregion

        public frmAprobaTasaNegociable()
        {
            
            InitializeComponent();
            cboTipoCredito.CargarProducto(nCodPro);

        }
        private void frmAprobaTasaNegociable_Load(object sender, EventArgs e)
        {
            cargarSolicitudesTasaNegociable();
        }
        private void btnDevolver1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //APROBAR SOLICITUD TN
            if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "APROBACIÓN")
            {
                if (String.IsNullOrEmpty(txtJustificacionAprobacion.Text.Trim()))
                {
                    MessageBox.Show("Registrar Justificación: Motivo Devolución.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtJustificacionAprobacion.Focus();
                    return;
                }

                DialogResult respMsg = MessageBox.Show("Seguro que desea DEVOLVER solicitud de Tasa Negociable?", "Aprobación de Tasa Negociable", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respMsg == DialogResult.Yes)
                {
                    DataTable Resultado = cnsolicitud.CNDevolverSolicitudTasaNegociable(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value.ToString()), Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idEstado"].Value.ToString()), txtJustificacionAprobacion.Text.Trim(), clsVarGlobal.User.idUsuario);
                    if (Resultado.Rows.Count > 0)
                    {
                        MessageBox.Show(Resultado.Rows[0]["cMensaje"].ToString(), "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string cEstado = "DEVUELTO";

                        clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                        dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                        if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                        {
                            envioCorreoAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value), txtMonto.Text.Trim(), txtJustificacionAprobacion.Text.Trim());
                        }

                        clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                        dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                        if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                        {
                            envioSMSAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value));
                        }
                        cargarSolicitudesTasaNegociable();
                    }
                }
            }
            //APROBAR PRE-SOLICITUD
            else if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "PRE APROBACIÓN")
            {
                if (dtgSolicitudes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (String.IsNullOrEmpty(txtOpinion.Text.Trim()))
                {
                    MessageBox.Show("Registrar Opinión: Motivo Devolución.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOpinion.Focus();
                    return;
                }
                DialogResult respMsg = MessageBox.Show("¿Seguro que desea DEVOLVER solicitud de Tasa Negociable?", "Aprobación de Tasa Negociable", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respMsg == DialogResult.Yes)
                {
                    int idsolTasa = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idSolAproba"].Value);
                    int idTasaNegociada = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value); ;
                    int idEstado = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idEstado"].Value); ;
                    DataTable Resultado = cnsolicitud.CNDevolverSolicitudTasaNegociablePRE(idTasaNegociada, idEstado, idsolTasa, txtOpinion.Text.Trim(), clsVarGlobal.User.idUsuario);
                    if (Resultado.Rows.Count > 0)
                    {
                        MessageBox.Show(Resultado.Rows[0]["cMensaje"].ToString(), "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Resultado.Rows[0]["idError"].ToString() == "0")
                        {
                            string cEstado = "DEVUELTO";
                            clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                            dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                            if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                            {
                                envioCorreoAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value), Convert.ToString(dtgSolicitudes.CurrentRow.Cells["CapitalSolicitadoTASA"].Value), txtOpinion.Text.Trim());
                            }

                            clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                            dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                            if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                            {
                                envioSMSAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value));
                            }
                        }
                        cargarSolicitudesTasaNegociable();
                    }
                }
            }
        }
        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No existe ninguna solicitud seleccionada", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //APROBAR SOLICITUD TN
            if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "APROBACIÓN")
            {
                if (cGlobal_idEstadoTasa != 999)
                {
                    if (cGlobal_idEstadoTasa != 5)
                    {
                        frmAnulaTasaNegociable frmAnulaTasaNegociable = new frmAnulaTasaNegociable();
                        frmAnulaTasaNegociable.idTasaNegociada = cGlobal_idTasaNegociable;
                        frmAnulaTasaNegociable.idEstado = cGlobal_idEstadoTasa;
                        frmAnulaTasaNegociable.lDenegado = true;
                        frmAnulaTasaNegociable.lblBase37.Text = "Seleccionar Motivo de Denegación:";
                        frmAnulaTasaNegociable.Text = "Denegar Tasa Negociable";
                        if (frmAnulaTasaNegociable.ShowDialog() == DialogResult.OK)
                        {
                            string cEstado = "DENEGADO";
                            clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                            dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                            if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                            {
                                envioCorreoAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value), txtMonto.Text.Trim(), txtJustificacionAprobacion.Text.Trim());
                            }

                            clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                            dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                            if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                            {
                                envioSMSAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value));
                            }
                            cargarSolicitudesTasaNegociable();
                        }
                    }
                }
            }
            //APROBAR PRE-SOLICITUD
            else if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "PRE APROBACIÓN")
            {
                if (dtgSolicitudes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No existe ninguna solicitud seleccionada", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int idsolTasa = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idSolAproba"].Value);
                int idTasaNegociada = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value);
                int idEstado = Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idEstado"].Value);

                frmAnulaTasaNegociable frmAnulaTasaNegociable = new frmAnulaTasaNegociable();
                frmAnulaTasaNegociable.idTasaNegociada = idTasaNegociada;
                frmAnulaTasaNegociable.idEstado = idEstado;
                frmAnulaTasaNegociable.lDenegado = true;
                frmAnulaTasaNegociable.lblBase37.Text = "Seleccionar Motivo de Denegación:";
                frmAnulaTasaNegociable.Text = "Denegar Tasa Negociable";
                if (frmAnulaTasaNegociable.ShowDialog() == DialogResult.OK)
                {
                    DataTable ResulSolAproba = cnsolicitud.CNAnulaSolaproba(idsolTasa);
                    if (ResulSolAproba.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ResulSolAproba.Rows[0]["idError"]) == 0)
                        {
                            MessageBox.Show("Se Denegó la Pre-aprobación de la Solicitud de la Tasa Negociada.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string cEstado = "DENEGADO";
                            clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                            dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                            if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                            {
                                envioCorreoAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value), Convert.ToString(dtgSolicitudes.CurrentRow.Cells["CapitalSolicitadoTASA"].Value), txtOpinion.Text.Trim());
                            }

                            clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                            dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                            if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                            {
                                envioSMSAprobador(cEstado, 0, Convert.ToString(dtgSolicitudes.CurrentRow.Cells["nTasaSolicitada"].Value));
                            }
                        }
                    }
                    cargarSolicitudesTasaNegociable();
                }
            }
        }
        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--Validar pagos parciales
            clsPlanPago objPlanPagos = new clsPlanPago();
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
            DataTable dtCuentaxSolicitud = objCNSolicitud.CNObtenerCuentaXSolicitudAll(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["nSolicitud"].Value));
            objPlanPagos = objCNPlanPago.retonarPlanPagoTotal(Convert.ToInt32(dtCuentaxSolicitud.Rows[0]["idCuenta"]));
            int nPagoParcial = objPlanPagos.Count(x => x.idEstadocuota == 1 && x.nInteresPagado > 0);
            if (nPagoParcial > 0)
            {
                MessageBox.Show("La cuenta tiene pagos parciales.", "Validación solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //-Validar importe minimo
            if (cTipoTN == "POS")
            {
                GEN.CapaNegocio.clsCNCredito objValidacion = new GEN.CapaNegocio.clsCNCredito();
                DataTable dtImporteMin = objValidacion.CNObtenerImporteMinSolicitudPost();
                DataTable dtSaldoCapital = objValidacion.CNObtieneSaldoCapitalCuenta(Convert.ToInt32(dtCuentaxSolicitud.Rows[0]["idCuenta"]));
                if (dtImporteMin.Rows.Count > 0 && dtSaldoCapital.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dtSaldoCapital.Rows[0]["nSalCap"].ToString()) < Convert.ToDecimal(dtImporteMin.Rows[0]["cValVar"].ToString()))
                    {
                        MessageBox.Show("Monto para retención está por debajo del Mínimo Permitido", "Solicitud de retención con cambio de Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //-Valida cambio de Monto
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtSolicitud = cnsolicitud.ExtraeDatosSolicitudTNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["nSolicitud"].Value), clsVarGlobal.User.idUsuario);
            
            if (Convert.ToDecimal(txtMonto.Text) != Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalsolicitado"])) 
            {
                MessageBox.Show("El monto del crédito ha cambiado, se debe denegar o anular la solicitud de tasa para ingresar una nueva solicitud.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //APROBAR SOLICITUD TN
            if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "APROBACIÓN")
            {
                if (Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompAprobada.Text))
                {
                    MessageBox.Show("Debe ingresar una nueva tasa de interés válida.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToDecimal(dtgSolicitudes.CurrentRow.Cells["CapitalSolicitadoTASA"].Value.ToString()) != cGlobal_CapitalSolicitadoSOL)
                {
                    MessageBox.Show("Capital solicitado es distinto al registrado en la Solicitud Tasa.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtgSolicitudes.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (String.IsNullOrEmpty(txtJustificacionAprobacion.Text.Trim()))
                {
                    MessageBox.Show("Registrar Justificación.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtJustificacionAprobacion.Focus();
                    return;
                }

                clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();
                int idCuentaBloqueo = 0;
                if (Sol.Rows.Count != 0)
                {
                    idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);

                    DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuentaBloqueo);

                    if (Convert.ToInt32(dtEstCuenta.Rows[0]["idEstado"].ToString()) != 7)
                    {
                        MessageBox.Show("No puede continuar, la solicitud se encuentra con estado: " + Convert.ToString(dtEstCuenta.Rows[0]["cEstadoSol"].ToString()), "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarSolicitudesTasaNegociable();
                        return;
                    }
                }

                if (validar())
                {
                    Decimal nTEM = Convert.ToDecimal(clsMathFinanciera.TEM(Convert.ToDouble(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value)).ToString("n4"));
                    int idTasaNegociada = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value);

                    DataTable RegistroSolicitud = cnsolicitud.RegistroAbprobacionTasaNegociable(
                                                              Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value.ToString()),
                                                              clsVarGlobal.User.idUsuario,
                                                              Convert.ToDecimal(txtTasaCompAprobada.Text),
                                                              Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value.ToString()),
                                                              nTEM,
                                                              txtJustificacionAprobacion.Text
                                                              );
                    if (RegistroSolicitud.Rows.Count > 0)
                    {
                        MessageBox.Show("Se aprobó correctamente la Tasa Negociada.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string cPerfilTasa = "APROBADO";
                        clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                        dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                        if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                        {
                            envioCorreoAprobador(cPerfilTasa, 0, txtTasaCompAprobada.Text.Trim(), txtMonto.Text.Trim(), txtJustificacionAprobacion.Text.Trim());
                        }
                        clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                        dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                        if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                        {
                            envioSMSAprobador(cPerfilTasa, 0, txtTasaCompAprobada.Text.Trim());
                        }

                        if (cTipoTN == "POS")
                        {
                            //grabando Solicitud de ReTencion Cambio Tasa
                            GEN.CapaNegocio.clsCNCredito objCredito = new GEN.CapaNegocio.clsCNCredito();
                            DataTable dtResultCuenta = objCredito.CNListaPARAMSSolicitudRetencionCambioTasa(cGlobal_idCuenta);

                            DataTable dtResultGrabado = objCredito.CNGrabarSolicitudRetencionCambioTasa(
                                      Convert.ToInt32(dtResultCuenta.Rows[0]["idCuenta"])
                                    , Convert.ToInt32(dtResultCuenta.Rows[0]["ndiasgracia"])
                                    , Convert.ToInt32(dtResultCuenta.Rows[0]["nCuotas"])
                                    , Convert.ToInt32(dtResultCuenta.Rows[0]["nDiasPerdon"])
                                    , Convert.ToInt32(dtResultCuenta.Rows[0]["idTipoPlanPago"])
                                    , Convert.ToDateTime(dtResultCuenta.Rows[0]["dFechaPrimeraCuota"])
                                    , Convert.ToDecimal(txtTasaCompAprobada.Text)
                                    , 0, 0);
                            if (dtResultGrabado.Rows.Count == 0)
                            {
                                MessageBox.Show("Ha ocurrido un error al registra la solicitud de Retención Cambio de Tasa.", "Solicitud de Tasa Negociable Post-Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        RetornaNumCuenta.CNDesbloqueaCuenta(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value.ToString()));

                    }
                    DataTable dtApr = cnsolicitud.CNObtenerRastreoTasaNegociableAPR(cGlobal_idSolicitudCre, cGlobal_idTasaNegociable, cGlobal_idUsuario);
                    dtgAprTasa.DataSource = dtApr;
                    guardarDocumento(idTasaNegociada);
                    cargarSolicitudesTasaNegociable();
                    guardarExpedienteTasaNegociable("Solicitud de Tasa Negociable", cGlobal_idsolicitud);
                }
            }
            //APROBAR PRE-SOLICITUD
            else if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "PRE APROBACIÓN")
            {
                if (dtgSolicitudes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (dtgSolicitudes.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (String.IsNullOrEmpty(txtOpinion.Text.Trim()))
                {
                    MessageBox.Show("Registrar Opinión.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtOpinion.Focus();
                    return;
                }

                int idSolAprobaSel = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolAproba"].Value);
                int idUsuario = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
                int idPerfil = Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil);

                /** Confirmación de aprobación ***/
                if (
                    MessageBox.Show(
                        "¿Está seguro de APROBAR la solicitud?",
                        "Aprobación de Solicitudes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    ) == DialogResult.No
                )
                {
                    return;
                }

                int iFilaTipOpe = dtgSolicitudes.SelectedCells[0].RowIndex;
                int idSolAproba = (int)dtSolicitudes.Rows[iFilaTipOpe]["idSolAproba"];
                int idNivelAprRanOpe = (int)dtSolicitudes.Rows[iFilaTipOpe]["idNivelAprRanOpe"];
                int idEstado = 2;
                idEstadoSolAproba = idEstado;
                string cOpinion = txtOpinion.Text;

                if (idTipoOpe.In(55, 120))
                {
                    if (objCreditoProp == null)
                    {
                        int idSolicitud = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idDocument"].Value);
                        objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idSolicitud);
                    }
                }
                else
                {
                    objCreditoProp = new clsCreditoProp();
                }


                string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
                string cHora = DateTime.Now.ToString("hh:mm tt");
                string cFechayhora = cFecha + " " + cHora;

                DateTime dresultFechyHora;
                DateTime.TryParse(cFechayhora, out dresultFechyHora);

                regAprobaSolicitud(idSolAproba, idNivelAprRanOpe, clsVarGlobal.User.idUsuario, idEstado,
                                    cOpinion, dresultFechyHora, clsVarGlobal.PerfilUsu.idPerfil, objCreditoProp);

                cargarSolicitudesTasaNegociable();
            }            
        }
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                //Libera cuenta bloqueada
                clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();
                int idCuentaBloqueo = 0;
                if (Sol.Rows.Count != 0)
                {
                    idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);

                    DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuentaBloqueo);
                    idUsuBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
                }

                if (idUsuBloqueo != 0 && idUsuBloqueo == clsVarGlobal.User.idUsuario)
                {
                    RetornaNumCuenta.CNDesbloqueaCuenta(idCuentaBloqueo);
                }
            }
            this.Close();
        }
        private void dtgSolicitudes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) 
            {
                return;
            }

            if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "APROBACIÓN") 
            {
                txtJustificacionAprobacion.Visible = true;
                txtOpinion.Visible = false;

                if (dtgSolicitudes.Rows.Count > 0)
                {
                    //Libera cuenta bloqueada
                    clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();
                    int idCuentaBloqueo = 0;
                    if (Sol.Rows.Count != 0)
                    {
                        idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);

                        DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuentaBloqueo);
                        idUsuBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
                    }

                    if (idUsuBloqueo != 0 && idUsuBloqueo == clsVarGlobal.User.idUsuario)
                    {
                        RetornaNumCuenta.CNDesbloqueaCuenta(idCuentaBloqueo);
                    }

                    //Selecciona cuenta
                    nTasaCompensatoriaSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value);
                    nTasaMoraSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value);

                    DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;

                    cGlobal_idSolicitudCre = Convert.ToInt32(drSolicitud["nSolicitud"]);
                    cGlobal_idTasaNegociable = Convert.ToInt32(drSolicitud["idTasaNegociada"]);
                    cGlobal_idEstadoTasa = Convert.ToInt32(drSolicitud["idEstado"]);
                    cGlobal_idUsuario = clsVarGlobal.User.idUsuario;
                    cTipoTN = Convert.ToString(drSolicitud["Tipo Tasa"]);

                    DataTable dtCuentaxSolicitud = RetornaNumCuenta.CNObtenerCuentaXSolicitudAll(cGlobal_idSolicitudCre);
                    cGlobal_idCuenta = Convert.ToInt32(dtCuentaxSolicitud.Rows[0]["idCuenta"]);

                    if (cTipoTN == "PRE")
                    {
                        conRastreoTasaNegociable.cTipoMotivo = "P";
                    }
                    else 
                    {
                        conRastreoTasaNegociable.cTipoMotivo = "S";
                    }
                    conRastreoTasaNegociable.cargarDatos(cGlobal_idSolicitudCre, cGlobal_idTasaNegociable, cGlobal_idUsuario);

                    buscarSolicitud(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["nSolicitud"].Value), Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value));
                    if (lMontodiferente == true)
                    {
                        return;
                    }
                    asignarTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasas"].Value.ToString()));

                    DataTable dtClasifInterna = cnsolicitud.CNObtenerClasifInterna(cGlobal_cDocumento);
                    if (dtClasifInterna.Rows.Count > 0)
                    {
                        txtClasifInterna.Text = Convert.ToString(dtClasifInterna.Rows[0]["cClasifInterna"]);
                        lblClasifInterna.Text = Convert.ToString(dtClasifInterna.Rows[0]["cClasifInterna"]);
                    }

                    if (lBloqueo == true)
                    {
                        btnAprobar1.Enabled = false;
                        btnDenegar1.Enabled = false;
                        btnDevolver1.Enabled = false;
                    }
                    else
                    {
                        btnAprobar1.Enabled = true;
                        btnDenegar1.Enabled = true;
                        btnDevolver1.Enabled = true;
                    }
                    txtJustificacionAprobacion.Text = "";
                }
            }
            else if (Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["TipoAprobacion"].Value) == "PRE APROBACIÓN") 
            {
                txtJustificacionAprobacion.Visible = false;
                txtOpinion.Visible = true;

                if (dtgSolicitudes.Rows.Count > 0)
                {
                    dtgPerformanceADN.DataSource = null;
                    dtgHistoricoTEA.DataSource = null;
                    buscarSolicitudPRE(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idDocument"].Value), Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value));
                    txtOpinion.Text = string.Empty;

                    nTasaCompensatoriaSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value);
                    nTasaMoraSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value);

                    asignarTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasas"].Value.ToString()));

                    DataTable dtClasifInterna = cnsolicitud.CNObtenerClasifInterna(cGlobal_cDocumento);
                    if (dtClasifInterna.Rows.Count > 0)
                    {
                        txtClasifInterna.Text = Convert.ToString(dtClasifInterna.Rows[0]["cClasifInterna"]);
                        lblClasifInterna.Text = Convert.ToString(dtClasifInterna.Rows[0]["cClasifInterna"]);
                    }

                    DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;
                    cTipoTN = Convert.ToString(drSolicitud["Tipo Tasa"]);
                    if (cTipoTN == "PRE")
                    {
                        conRastreoTasaNegociable.cTipoMotivo = "P";
                    }
                    else
                    {
                        conRastreoTasaNegociable.cTipoMotivo = "S";
                    }
                    conRastreoTasaNegociable.cargarDatos(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idDocument"].Value), Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value), cGlobal_idUsuario);
                }
            }
        }
        private void dtgSolicitudes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgSolicitudes.Columns[e.ColumnIndex].Name == "TipoSolicitud")
            {
                if (e.Value != null && Convert.ToString(e.Value.ToString()) == "RETENCIÓN TASA")
                {
                    dtgSolicitudes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru;
                }
            }
        }
        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No existe ninguna solicitud seleccionada.", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            mostrarCargaArchivo();
        }
        private void btnMiniActualizar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                //Libera cuenta bloqueada
                clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();
                int idCuentaBloqueo = 0;
                if (Sol.Rows.Count != 0)
                {
                    idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);

                    DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuentaBloqueo);
                    idUsuBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
                }

                if (idUsuBloqueo != 0 && idUsuBloqueo == clsVarGlobal.User.idUsuario)
                {
                    RetornaNumCuenta.CNDesbloqueaCuenta(idCuentaBloqueo);
                }
            }
            
            cargarSolicitudesTasaNegociable();
        }
        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(nCodPro);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
            }
        }
        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
            }
        }
        private void cboProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }
        }
        private void txtTasaCompAprobada_Click(object sender, EventArgs e)
        {
            if (txtTasaCompAprobada.Text == txtTasCompensatoriaMax.Text)
            {
                txtTasaCompAprobada.Text = "";
            }
        }
        private void txtTasaCompAprobada_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((char.IsDigit(e.KeyChar)) && (textBox.Text.Length == 2))
            {
                textBox.Text += "." + e.KeyChar.ToString();
                textBox.SelectionStart = textBox.Text.Length;
                e.Handled = true;
            }
        }
        private void txtTasaCompAprobada_Leave(object sender, EventArgs e)
        {
            if (txtTasaCompAprobada.Text == "")
            {
                txtTasaCompAprobada.Text = txtTasCompensatoriaMax.Text;
            }
            else
            {
                decimal nTasa = Convert.ToDecimal(txtTasaCompAprobada.Text);
                txtTasaCompAprobada.Text = string.Empty;
                txtTasaCompAprobada.Text = nTasa.ToString("N4");
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa a aprobar debe estar comprendida dentro del rango.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTasaCompAprobada.Text = txtTasCompensatoriaMax.Text;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMax.Text) < Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa a aprobar debe estar comprendida dentro del rango.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTasaCompAprobada.Text = txtTasCompensatoriaMax.Text;
            }
        }
        private void frmAprobaTasaNegociable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                //Libera cuenta bloqueada
                clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();
                int idCuentaBloqueo = 0;
                if (Sol.Rows.Count != 0)
                {
                    idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);

                    DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuentaBloqueo);
                    if (dtEstCuenta.Rows.Count > 0) 
                    { 
                       idUsuBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());                 
                    }
                }
                if (idUsuBloqueo != 0 && idUsuBloqueo == clsVarGlobal.User.idUsuario)
                {
                    RetornaNumCuenta.CNDesbloqueaCuenta(idCuentaBloqueo);
                }
            }
        }

        private void cargarSolicitudesTasaNegociable()
        {
            dtSolicitudes = cnsolicitud.CNListaSolicitudesTasaNegociable(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            dtgSolicitudes.DataSource = dtSolicitudes;
            formatearSolicitudes();
            dtgSolicitudes.ClearSelection();
            limpiar();
            txtJustificacionAprobacion.Text = "";

            foreach (DataGridViewColumn column in dtgSolicitudes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void buscarSolicitud(int CodigoSol, int idTasaNegociada)
        {
            cGlobal_idsolicitud = CodigoSol;
            Sol = cnsolicitud.ConsultaSolicitudTNegociable(CodigoSol, idTasaNegociada);

            if (Sol.Rows.Count > 0)
            {
                dtpFechaSol.Value = (Sol.Rows[0]["dFechaRegistro"] == DBNull.Value) ? clsVarGlobal.dFecSystem : (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? "" : Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? 0.00m : (Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = (Sol.Rows[0]["IdMoneda"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = (Sol.Rows[0]["nCuotas"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);


                txtPersonalCreditos.Text = (Sol.Rows[0]["cNombreAsesor"] == DBNull.Value) ? "--" : Sol.Rows[0]["cNombreAsesor"].ToString();
                cboTipoCredito.SelectedValue = (Sol.Rows[0]["nTipCre"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = (Sol.Rows[0]["nSubTip"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = (Sol.Rows[0]["nProdu"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = (Sol.Rows[0]["nSubPro"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubPro"]);

                cboDestinoCredito.lTasa = true;
                cboDestinoCredito.cargar();
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);



                nCodEst = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboEstadoCredito.CargaEstadoActual(nCodEst);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idCli"]);
                cGlobal_cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);

                var nEvaluacion = Convert.ToInt32(Sol.Rows[0]["nEvaluacion"]);
            
                DataTable dtMontosolicitud = cnsolicitud.ConsultaSolicitudCapitalSol(CodigoSol);
                if (dtMontosolicitud.Rows.Count > 0)
                {
                    cGlobal_CapitalSolicitadoSOL = Convert.ToDecimal(dtMontosolicitud.Rows[0]["nCapitalSolicitado"]);
                    if (Convert.ToDecimal(dtgSolicitudes.CurrentRow.Cells["CapitalSolicitadoTASA"].Value.ToString()) != cGlobal_CapitalSolicitadoSOL)
                    {
                        MessageBox.Show("El capital solicitado es distinto al registrado en la Solicitud Tasa.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAprobar1.Enabled = false;
                        lMontodiferente = true;
                        return;
                    }
                    else
                    {
                        btnAprobar1.Enabled = true;
                        lMontodiferente = false;
                    }
                }

                //Historico TEA Cliente
                int nTipodocumento = Convert.ToInt32(Sol.Rows[0]["idTipoDocumento"]);
                string cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);

                historicoTEACliente(nTipodocumento, cDocumento);

                //TPP
                if (dtgSolicitudes.Rows.Count > 0) 
                { 
                    int idUsuario = (Sol.Rows[0]["idUsuReg"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idUsuReg"]);
                    DataTable dtZonaUsuario = cnsolicitud.CNObtenerZonaUsuario(idUsuario);
                    if (dtZonaUsuario.Rows.Count > 0)
                    {
                        idZonaUsuario = Convert.ToInt32(dtZonaUsuario.Rows[0]["idZona"]);
                    }
                    obtenerTasapromedioPonderada(clsVarGlobal.dFecSystem, Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idAgenciaREG"].Value), idZonaUsuario, idUsuario);
                }

                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                }

                var drGarantia = cnsolicitud.ValidaGarantiasSolicitud(CodigoSol).Rows[0];

                int idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idTasaNegociada"]);
                if (!validarBloqueo(idCuentaBloqueo))
                {
                    lBloqueo = true;
                    return;
                }
                else
                {
                    bloquearCuenta(idCuentaBloqueo);
                    lBloqueo = false;
                }
                               
            }
            else
            {
                limpiar();
                cboTipoPeriodo.Enabled = false;
                nudPlazo.Enabled = false;
            }

        }
        private void buscarSolicitudPRE(int CodigoSol, int idTasaNegociada)
        {
            cGlobal_idsolicitud = CodigoSol;
            Sol = cnsolicitud.ConsultaSolicitudTNegociable(CodigoSol, idTasaNegociada);

            if (Sol.Rows.Count > 0)
            {
                dtpFechaSol.Value = (Sol.Rows[0]["dFechaRegistro"] == DBNull.Value) ? clsVarGlobal.dFecSystem : (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? "" : Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? 0.00m : (Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = (Sol.Rows[0]["IdMoneda"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = (Sol.Rows[0]["nCuotas"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                txtPersonalCreditos.Text = (Sol.Rows[0]["cNombreAsesor"] == DBNull.Value) ? "--" : Sol.Rows[0]["cNombreAsesor"].ToString();
                cboTipoCredito.SelectedValue = (Sol.Rows[0]["nTipCre"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = (Sol.Rows[0]["nSubTip"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = (Sol.Rows[0]["nProdu"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = (Sol.Rows[0]["nSubPro"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubPro"]);

                cboDestinoCredito.lTasa = true;
                cboDestinoCredito.cargar();
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);
                nCodEst = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboEstadoCredito.CargaEstadoActual(nCodEst);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idCli"]);

                var nEvaluacion = Convert.ToInt32(Sol.Rows[0]["nEvaluacion"]);

                //Historico TEA Cliente
                int nTipodocumento = Convert.ToInt32(Sol.Rows[0]["idTipoDocumento"]);
                string cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);
                cGlobal_cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);

                historicoTEACliente(nTipodocumento, cDocumento);

                //TPP
                int idUsuario = (Sol.Rows[0]["idUsuReg"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idUsuReg"]);
                DataTable dtZonaUsuario = cnsolicitud.CNObtenerZonaUsuario(idUsuario);
                if (dtZonaUsuario.Rows.Count > 0)
                {
                    idZonaUsuario = Convert.ToInt32(dtZonaUsuario.Rows[0]["idZona"]);
                }
                obtenerTasapromedioPonderada(clsVarGlobal.dFecSystem, Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idAgenciaREG"].Value), idZonaUsuario, idUsuario);

                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                }

                btnAprobar1.Enabled = true;
                btnDenegar1.Enabled = true;
                btnDevolver1.Enabled = true; 
            }
        }
        private void envioCorreoAprobador(string cEstadoSol, int nTOpe, string cTea, string cMonto, string cComentario)
        {
            string cNombreCli = "";
            cNombreCli = dtgSolicitudes.CurrentRow.Cells["cNombreCliente"].Value.ToString();

            string cPerfil = string.Empty;
            string cCuerpo = string.Empty;
            string cAsunto = string.Empty;

            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("HH:mm");
            string cFechayhora = cFecha + " " + cHora;

            DataTable dtAprobadorCorreo = new DataTable();
            clsCNSolicitud objCNprobacion = new clsCNSolicitud();

            DataTable dtCuerpoMensaje = objCNprobacion.CNObtenerCuerpoMensajeAprobacion(cEstadoSol, cNombreCli.Trim(), cTea, cMonto, cComentario, cPerfilUsuario.Trim(), cFechayhora);

            if (dtCuerpoMensaje.Rows.Count == 0)
            {
                MessageBox.Show("Ha ocurrido un error al recuperar texto de correo electrónico.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cPerfil = dtParamEnvioEmail.Rows[0]["cValVar"].ToString();
            cCuerpo = Convert.ToString(dtCuerpoMensaje.Rows[0]["TextoMensaje"].ToString());

            cAsunto = "Solicitud " + cEstadoSol + " de TEA Negociable " + cNombreCli.Trim() + " " + cNombreagencia.Trim() + "";

            if (nTOpe == 0)
            {
                dtAprobadorCorreo = objCNprobacion.CNListarCorreoADN(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuario"].Value.ToString()), Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idPerfilRegistro"].Value.ToString()));
            }
            else
            {
                bool lEsPerfilGerNegocio = false;
                DataTable dtNivelAprobaTasa = objAprobacion.CNObtenerNivelAprobaTasa(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idDocument"].Value));
                if (dtNivelAprobaTasa.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtNivelAprobaTasa.Rows[0]["idTipoTasa"].ToString()) == 31)
                    {
                        lEsPerfilGerNegocio = true;
                    }
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 85) 
                { 
                    dtAprobadorCorreo = objCNprobacion.CNListarCorreoPRE(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuRegist"].Value.ToString()), clsVarGlobal.nIdAgencia, Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idPerfilRegistro"].Value.ToString())); 
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 75)
                {
                    if (lEsPerfilGerNegocio == true)
                    {
                        dtAprobadorCorreo = objCNprobacion.CNListarCorreoPREGerNegociable(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuRegist"].Value.ToString()), clsVarGlobal.nIdAgencia);
                    }
                }        
            }

            var cFinalizaEnvioMAIL = "Se notificó por CORREO a los siguientes usuarios:" + Environment.NewLine + Environment.NewLine;
            if (dtAprobadorCorreo.Rows.Count > 0)
            {
                foreach (DataRow fila in dtAprobadorCorreo.Rows)
                {
                    string cCorreo = Convert.ToString(fila["cEmailInst"]);
                    string cWinuser = Convert.ToString(fila["cWinUser"]);
                    string cPerfilUs = Convert.ToString(fila["cPerfil"]);
                    if (!string.IsNullOrEmpty(cCorreo))
                    {
                        DataTable dtenviocorreo = objCNprobacion.CNEnviarCorreoAprobadorTN(cPerfil, cCorreo, cCuerpo, cAsunto);
                        cFinalizaEnvioMAIL = cFinalizaEnvioMAIL + " - [" + fila["cWinUser"].ToString() + "] " + fila["cPerfil"].ToString() + " [" + Convert.ToString(dtenviocorreo.Rows[0]["cMensaje"]) + "]." + Environment.NewLine;

                    }                    
                }
                MessageBox.Show(cFinalizaEnvioMAIL, "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void envioSMSAprobador(string cEstadoSol, int nTOpe, string cTea)
        {
            DataTable dtAprobadorSMS = new DataTable();
            clsCNSolicitud objCNprobacion = new clsCNSolicitud();
            if (nTOpe == 0)
            {
                dtAprobadorSMS = objCNprobacion.CNListarCelularAprobaSol("", idZonaUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuario"].Value.ToString()), Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idPerfilRegistro"].Value.ToString()));
            }
            else 
            {
                bool lEsPerfilGerNegocio = false;
                DataTable dtNivelAprobaTasa = objAprobacion.CNObtenerNivelAprobaTasa(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idDocument"].Value));
                if (dtNivelAprobaTasa.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtNivelAprobaTasa.Rows[0]["idTipoTasa"].ToString()) == 31)
                    {
                        lEsPerfilGerNegocio = true;
                    }
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 85)
                {
                    dtAprobadorSMS = objCNprobacion.CNListarCelularPRE(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuRegist"].Value.ToString()), clsVarGlobal.nIdAgencia, Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idPerfilRegistro"].Value.ToString()));
                }
                if (clsVarGlobal.PerfilUsu.idPerfil == 75)
                {
                    if (lEsPerfilGerNegocio == true)
                    {
                        dtAprobadorSMS = objCNprobacion.CNListarCelularPREGerNegociable(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idUsuRegist"].Value.ToString()), clsVarGlobal.nIdAgencia);
                    }
                }
            }

            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("HH:mm");
            string cFechayhora = cFecha + " " + cHora;

            string cMensaje = string.Empty;
            DataTable dtCuerpoMensajeSMS = objCNprobacion.CNObtenerCuerpoMensajeAprobacionSMS(cEstadoSol, cTea, cPerfilUsuario.Trim(), cFechayhora);

            if (dtCuerpoMensajeSMS.Rows.Count == 0)
            {
                MessageBox.Show("Ha ocurrido un error al recuperar texto de SMS.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cMensaje = Convert.ToString(dtCuerpoMensajeSMS.Rows[0]["TextoMensaje"].ToString());

            var cFinalizaEnvioSMS = "Se notificó por SMS a los siguientes usuarios:" + Environment.NewLine + Environment.NewLine;
            if (dtAprobadorSMS.Rows.Count > 0)
            {
                foreach (DataRow fila in dtAprobadorSMS.Rows)
                {
                    string cCelular = Convert.ToString(fila["cCelular"]);
                    string cWinuser = Convert.ToString(fila["cWinUser"]);
                    string cPerfilUs = Convert.ToString(fila["cPerfil"]);
                    if (!string.IsNullOrEmpty(cCelular))
                    {
                        Dictionary<string, dynamic> cRespuesta = new Dictionary<string, dynamic>();
                        cRespuesta = enviarSMS(Convert.ToDouble(cCelular), cMensaje);
                        var cRespuestaMensaje = cRespuesta.First();
                        string cResp = $"{cRespuestaMensaje.Value}";
                        cFinalizaEnvioSMS = cFinalizaEnvioSMS + " - [" + fila["cWinUser"].ToString() + "] " + fila["cPerfil"].ToString() + " [" + cResp + "]." + Environment.NewLine;
                    }
                }
                MessageBox.Show(cFinalizaEnvioSMS, "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public Dictionary<string, dynamic> enviarSMS(double numero, string mensaje)
        {
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            ADM.CapaNegocio.clsCNMantenimiento obtenerPerfil = new ADM.CapaNegocio.clsCNMantenimiento();
            DataTable dtPerfil = obtenerPerfil.CNRetornaValorVariableGen("cServicioSMSInfobip");
            if (dtPerfil.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ruta de servicio mensajeria SMS", "Envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                res.Add("cEstado", "No se encontró ruta de Servicio");
                return res;
            }

            try
            {
                string cServicio = Convert.ToString(dtPerfil.Rows[0]["cValVar"]);
                string dicto = "{\"phone\":" + numero + ",\"content\":\"" + mensaje + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string serviceURL = string.Format(cServicio);
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                res.Add("cEstado", "Envío Correcto");
            }
            catch (Exception e)
            {
                res.Add("cEstado", "Falló envio");
                res.Add("cFail", e.ToString());
            }

            return res;
        }
        private void guardarExpedienteTasaNegociable(string cGrupo, int idSolicitud, bool lMensaje = true)
        {
            string cTipoSolicitud = "individual";
            string cMsgError = "Ha ocurrido un error al Guardar los Expedientes \n\n";
            if (cGrupo == "Solicitud de Tasa Negociable")
                cMsgError = "Ha ocurrido un error al Guardar los Expedientes, por lo tanto se cancelará el envío a evaluación de créditos.  \n\n";

            try
            {

                Cursor.Current = Cursors.WaitCursor;
                if (lMensaje)
                    MessageBox.Show("Se procederá a guardar los Expedientes necesarios para este proceso.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataSet dExpedientes = clsExpediente.getGrupoExpedienteLinea(cGrupo, idSolicitud, cTipoSolicitud);
                DataSet dDatosExpedientes = clsExpediente.getEjecutarSpExpediente(cGrupo, idSolicitud, cTipoSolicitud, clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dDatosExpedientes.Tables[dDatosExpedientes.Tables.Count - 1].Rows[0]["nRespuesta"]) == 0)
                {
                    MessageBox.Show(cMsgError, "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Cursor.Current = Cursors.Default;
                }
                DataTable dtProcParamDat = clsExpediente.getParametroAndDatosXml(dExpedientes, dDatosExpedientes, idSolicitud);
                DataTable dtres = clsExpediente.CNGuardarGrupoExpedienteTN(dtHistTEA, idSolicitud, clsVarGlobal.User.idUsuario, cTipoSolicitud, cGrupo);
                DataTable res = clsExpediente.guardarGrupoExpediente(dtProcParamDat, idSolicitud, clsVarGlobal.User.idUsuario, cTipoSolicitud, cGrupo);
                if (lMensaje)
                {
                    if (Convert.ToInt32(res.Rows[0]["nRespuesta"]) == 1)
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show(res.Rows[0]["cRespuesta"].ToString(), "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Cursor.Current = Cursors.Default;

                    }
                }
                if (dExpedientes != null)
                    dExpedientes.Clear();

                if (dDatosExpedientes != null)
                    dDatosExpedientes.Clear();

                if (dtProcParamDat != null)
                    dtProcParamDat.Clear();


                Cursor.Current = Cursors.Default;
            }
            catch (Exception exp)
            {
                if (lMensaje)
                    MessageBox.Show(cMsgError + exp.Message, "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor.Current = Cursors.Default;
            }
        }
        private void dtgPerformanceADN_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dtgPerformanceADN.Rows)
            {
                DataGridViewCell cell = row.Cells[0];
                cell.Style.BackColor = Color.LightGray;
                cell.Style.ForeColor = Color.Black;
            }
        }
        private void dtgPerformanceADN_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    // Dibujar el texto centrado en la celda de cabecera
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font,Brushes.Black, e.CellBounds, format);
                }
                e.Handled = true;
            }
        }
        private void dtgHistoricoTEA_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    // Dibujar el texto centrado en la celda de cabecera
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds, format);
                }
                e.Handled = true;
            }
        }
        private void dtgSolicitudes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    // Dibujar el texto centrado en la celda de cabecera
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                    e.Graphics.DrawString(e.FormattedValue?.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds, format);
                }
                e.Handled = true;
            }
        }
        private void asignarTasaNegociable(int idTasa)
        {
            cboTipoTasaCredito.DataSource = null;
            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
            DataTable dtTasa;
            dtTasa = TasaCredito.TasaCreditoNegociable(idTasa);

            if (dtTasa.Rows.Count > 0)
            {

                cboTipoTasaCredito.DataSource = dtTasa;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                var idTipoTasaCredito = Convert.ToInt32(dtTasa.Rows[0]["idTipoTasaCredito"]);
                lblClasifInterna.Text = dtTasa.Rows[0]["cClasificacionInterna"].ToString();
                txtClasifInterna.Text = dtTasa.Rows[0]["cClasificacionInterna"].ToString();
                
                if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() != "")
                {
                    txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                    txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                    idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);
                    txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);                   
                }
                else
                {
                    txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);
                    txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                }
            }
            else
            {
                txtTasCompensatoriaMin.Text = "";
                txtTasCompensatoriaMax.Text = "";
                txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);
                txtTasaMora.Text = "";
                txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                lblClasifInterna.Text = String.Empty;

                MessageBox.Show("El Producto no cuenta con Tasas Negociables.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool validarBloqueo(int idCuenta)
        {
            clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();

            DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(idCuenta);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                if (nidUserBloqueo != clsVarGlobal.User.idUsuario)
                {
                    DataTable dtUsu = new DataTable();
                    dtUsu = RetornaNumCuenta.CNBusUsuBlo((int)nidUserBloqueo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta: " + idCuenta + " está bloqueada por el usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lBloqueo = true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        private void bloquearCuenta(int idCuenta)
        {
            int nValBusqueda = idCuenta;
            clsCNSolicitud RetornaNumCuenta = new clsCNSolicitud();

            DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuenta(nValBusqueda);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                if (nidUserBloqueo != clsVarGlobal.User.idUsuario)
                { 
                    DataTable dtUsu = new DataTable();
                    dtUsu = RetornaNumCuenta.CNBusUsuBlo((int)nidUserBloqueo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta: " + idCuenta + " está bloqueada por el usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lBloqueo = true;
                }
                return;
            }
            else
            {
                RetornaNumCuenta.CNUpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
            }

        }
        private void obtenerTasapromedioPonderada(DateTime dFecha, int id_Agencia, int id_Zona, int id_Usuario)
        {
            DataTable dtTPP = cnsolicitud.CNMostrarTasaPromedioPonderada(dFecha, id_Agencia, id_Zona, id_Usuario);

            if (dtTPP.Rows.Count > 0)
            {
                dtgPerformanceADN.DataSource = dtTPP;
                formatearTPromedioPonderado();
            }
        }
        private void formatearSolicitudes()
        {
            dtgSolicitudes.Columns["idUsuario"].Visible = false;
            dtgSolicitudes.Columns["idEstado"].Visible = false;
            dtgSolicitudes.Columns["CapitalSolicitadoTASA"].Visible = false;
            dtgSolicitudes.Columns["cDocumentoID"].Visible = false;
            dtgSolicitudes.Columns["idUsuBlo"].Visible = false;
            dtgSolicitudes.Columns["idPerfilRegistro"].Visible = false;
            dtgSolicitudes.Columns["Tipo Tasa"].Visible = false;
            dtgSolicitudes.Columns["idSolAproba"].Visible = false;
            dtgSolicitudes.Columns["idNivelAprRanOpe"].Visible = false;
            dtgSolicitudes.Columns["idAgencia"].Visible = false;
            dtgSolicitudes.Columns["cNombreAge"].Visible = false;
            dtgSolicitudes.Columns["idUsuRegist"].Visible = false;
            dtgSolicitudes.Columns["cNomUsuReg"].Visible = false;
            dtgSolicitudes.Columns["idTipoOperacion"].Visible = false;
            dtgSolicitudes.Columns["cTipoOperacion"].Visible = false;
            dtgSolicitudes.Columns["cNomCliente"].Visible = false;
            dtgSolicitudes.Columns["idProducto"].Visible = false;
            dtgSolicitudes.Columns["cProducto"].Visible = false;
            dtgSolicitudes.Columns["idMoneda"].Visible = false;
            dtgSolicitudes.Columns["cMoneda"].Visible = false;
            dtgSolicitudes.Columns["nValAproba"].Visible = false;
            dtgSolicitudes.Columns["idDocument"].Visible = false;
            dtgSolicitudes.Columns["idMotivo"].Visible = false;
            dtgSolicitudes.Columns["cMotivo"].Visible = false;
            dtgSolicitudes.Columns["cSustento"].Visible = false;
            dtgSolicitudes.Columns["dFecSolici"].Visible = false;
            dtgSolicitudes.Columns["dFecVenSol"].Visible = false;
            dtgSolicitudes.Columns["cOpinion"].Visible = false;
            dtgSolicitudes.Columns["cSimbolo"].Visible = false;
            dtgSolicitudes.Columns["cWinUser"].Visible = false;
            dtgSolicitudes.Columns["lAprob"].Visible = false;
            dtgSolicitudes.Columns["lSoloComent"].Visible = false;
            dtgSolicitudes.Columns["nOrdenAprobacion"].Visible = false;
            dtgSolicitudes.Columns["nTasaSolicitada"].Visible = false;
            dtgSolicitudes.Columns["nSolicitud"].Visible = false;
            dtgSolicitudes.Columns["idAgenciaREG"].Visible = false;
            dtgSolicitudes.Columns["TipoSolicitud"].HeaderText = "Tipo de Solicitud";
            dtgSolicitudes.Columns["TipoAprobacion"].HeaderText = "Tipo de Aprobación";
            dtgSolicitudes.Refresh();
        }
        private void formatearTPromedioPonderado()
        {
            dtgPerformanceADN.Columns["us"].HeaderText = "";
            dtgPerformanceADN.Columns["c_inicial"].HeaderText = "Inicial";
            dtgPerformanceADN.Columns["c_actual"].HeaderText = "Actual";
            dtgPerformanceADN.Columns["c_variacion"].HeaderText = "Variación";
            dtgPerformanceADN.Columns["d_inicial"].HeaderText = "Inicial";
            dtgPerformanceADN.Columns["d_actual"].HeaderText = "Actual";
            dtgPerformanceADN.Columns["d_variacion"].HeaderText = "Variación";

            dtgPerformanceADN.Columns["c_inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["c_actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["c_variacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_variacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Refresh();
        }
        private void historicoTEACliente(int nTipodocumento, string cDocumento)
        {
            dtHistTEA = cnsolicitud.CNMostrarHistoricoTEACliente(nTipodocumento, cDocumento);

            if (dtHistTEA.Rows.Count > 0)
            {
                dtgHistoricoTEA.DataSource = dtHistTEA;
                formatearHistoricoTEACliente();
                txtTpp.Text = Convert.ToString(dtHistTEA.Rows[0]["nTppPonderado"]) + " %";
            }
        }
        private void formatearHistoricoTEACliente()
        {
            dtgHistoricoTEA.Columns["nNumOrdCre"].HeaderText = "Nro.";
            dtgHistoricoTEA.Columns["idCuenta"].HeaderText = "Número de cuenta";
            dtgHistoricoTEA.Columns["cEstado"].HeaderText = "Estado de Crédito";
            dtgHistoricoTEA.Columns["dFechaDesembolso"].HeaderText = "Fecha Desembolso";
            dtgHistoricoTEA.Columns["nCapitalDesembolso"].HeaderText = "Monto";
            dtgHistoricoTEA.Columns["nTasaEfectivaAnual"].HeaderText = "TEA";
            dtgHistoricoTEA.Columns["nAtrasoMaximo"].HeaderText = "Mora Máxima";
            dtgHistoricoTEA.Columns["nAtrasoProm"].HeaderText = "Mora Promedio";
            dtgHistoricoTEA.Columns["cSituacionPago"].HeaderText = "Situación de Pago";
            dtgHistoricoTEA.Columns["idCli"].Visible = false;
            dtgHistoricoTEA.Columns["nTppPonderado"].Visible = false;
            dtgHistoricoTEA.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nTasaEfectivaAnual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nAtrasoMaximo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nAtrasoProm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgHistoricoTEA.Refresh();
        }
        private bool validar()
        {
            bool flag = true;
            if (dtgSolicitudes.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione la Solicitud a Aprobar.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag =  false;
            }

            if(Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa a Aprobar debe estar comprendida dentro del Rango.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMax.Text) < Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa a Aprobar debe estar comprendida dentro del Rango.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            if (txtJustificacionAprobacion.Text == "")
            {
                MessageBox.Show("Debe de hacer ingreso de su Justificación.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            return flag;
        }
        private void limpiar()
        {
            txtMonto.Text = "";
            txtPersonalCreditos.Text = "";
            cboMoneda.SelectedValue = 0;
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = DateTime.Today;
            dtpFechaSol.Value = DateTime.Today;
            cboOperacionCre1.SelectedValue = 0;
            cboEstadoCredito.SelectedValue = 0;
            cboTipoPeriodo.SelectedValue = 0;
            
            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";

            cboEstadoCredito.CargaEstadoActual(999);

            cboTipoTasaCredito.DataSource = null;
            txtTasCompensatoriaMin.Clear();
            txtTasCompensatoriaMax.Clear();
            txtTasaMoraSecAproba.Clear();
            txtTasaCompAprobada.Clear();
            conRastreoTasaNegociable.limpiar();
            txtClasifInterna.Text = string.Empty;
            txtTpp.Text = string.Empty;
            dtgHistoricoTEA.DataSource = "";
            dtgPerformanceADN.DataSource = "";

        }
        private void mostrarCargaArchivo()
        {
            if (cGlobal_idsolicitud == 0)
            {
                MessageBox.Show("No se ha Seleccionado la solicitud", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(cGlobal_idsolicitud, false);
            frmCargaArchivo.lTasa = true;
            frmCargaArchivo.lverTasaPost = true;
            if (Convert.ToInt32(Sol.Rows[0]["idTipoSolTasaDesembolso"]) == 2)
            {
                frmCargaArchivo.lTasaPost = true;                
            }
            frmCargaArchivo.btnGrabar2.Visible = false;
            frmCargaArchivo.ShowDialog();
        }
        private void regAprobaSolicitud(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado, string cOpinion, DateTime dFecSis, int idPerfil, clsCreditoProp objCreditoProp)
        {
            objCreditoProp.idOrigenCredProp = 4;
            objCreditoProp.idSolAproba = idSolAproba;
            objCreditoProp.idNivelAprRanOpe = idNivelAprRanOpe;
            string xmlPropSolCred = objCreditoProp.GetXml();
            nValAprobaSol = (idTipoOpe.In(55, 120)) ? Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nValAproba"].Value) : objCreditoProp.nMonto;
            DataTable dtAprobaSolicitud;

            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("hh:mm tt");
            string cFechayhora = cFecha + " " + cHora;

            DateTime dresultFechyHora;
            DateTime.TryParse(cFechayhora, out dresultFechyHora);
            objAprobacion.CNActualizaTasaNegociada(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idTasaNegociada"].Value), Convert.ToDecimal(txtTasaCompAprobada.Text));
            dtAprobaSolicitud = objAprobacion.CNRegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dresultFechyHora, idPerfil, xmlPropSolCred);

            int idRpta = Convert.ToInt32(dtAprobaSolicitud.Rows[0]["idRpta"]);
            MessageBox.Show(dtAprobaSolicitud.Rows[0]["cMensage"].ToString(), "Aprobación de Solicitudes", MessageBoxButtons.OK, (idRpta == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
            if (idRpta == 2) 
            {
                string cEstado = "PRE-APROBADO";
                clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                {
                    envioCorreoAprobador(cEstado, 1, txtTasaCompAprobada.Text.Trim(), Convert.ToString(dtgSolicitudes.CurrentRow.Cells["CapitalSolicitadoTASA"].Value), txtOpinion.Text.Trim());
                }

                clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                {
                    envioSMSAprobador(cEstado, 1, txtTasaCompAprobada.Text.Trim());
                }
            }            
            txtOpinion.Text = string.Empty;

        }
        private void guardarDocumento(int idTasaNegociada)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string rutaDescarga = string.Empty;
            string rutaDescargahtml = string.Empty;
            string nNombreArchivo = "TasaNegociable" + Convert.ToString(cGlobal_idsolicitud) + ".pdf";
            string nNombreArchivoHtml = "TasaNegociable" + Convert.ToString(cGlobal_idsolicitud) + ".html";
            string userFolder = Environment.UserName;
            rutaDescarga = @"C:\Users\" + userFolder + @"\Downloads\" + nNombreArchivo;
            rutaDescargahtml = @"C:\Users\" + userFolder + @"\Downloads\" + nNombreArchivoHtml;

            byte[] bytesPdf = new byte[0]; ;

            if (cTipoTN == "PRE") 
            {
               DataTable dtResultado = cnsolicitud.CNGuardaPdfTasaNegociable(Convert.ToInt32(cGlobal_idsolicitud), nNombreArchivo.Trim(), (byte[])Compresion.CompressedByte(bytesPdf), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, true, cPerfilUsuario, idTasaNegociada);
            }
            else if (cTipoTN == "POS") 
            {
                DataTable dtResultado = cnsolicitud.CNGuardaPdfTasaNegociablePost(Convert.ToInt32(cGlobal_idsolicitud), nNombreArchivo.Trim(), (byte[])Compresion.CompressedByte(bytesPdf), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, true, cPerfilUsuario, idTasaNegociada);
            }

            if (File.Exists(rutaDescarga)) // si existe el archivo
            {
                File.Delete(rutaDescarga); //borras el archivo
            }
        }
    }
}
