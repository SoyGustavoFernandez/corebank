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
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmPreAprobaTasaNegociable : frmBase
    {
        #region Variables Globales
        DataTable Sol = new DataTable("dtSolicitud");
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        int idSolAprobacion = 0;
        int idSolici = 0;
        int lAproba = 0;
        int nCodProducto = 1, nCodEstado = 0, idCliente = 0, idAgencia = clsVarGlobal.nIdAgencia;
        int idTasa = 0;
        bool lEstado = true, lValGarantia = false;
        decimal nMontoSolicitado = 0;
        char Transaccion = Convert.ToChar("I");
        public int idEstadoSol = 0;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();

        private decimal nTasaCompensatoriaSol { get; set; }
        private decimal nTasaMoraSol { get; set; }
        private string cJustificacionSol { get; set; }

        #endregion

        #region Metodos
        public frmPreAprobaTasaNegociable(int idSolAproba, int idSolicitud, int lAprob)
        {
            idSolAprobacion = idSolAproba;
            idSolici = idSolicitud;
            lAproba = lAprob;
            InitializeComponent();
            cboTipoCredito.CargarProducto(nCodProducto);
        }

        private void CargarSolicitudesTasaNegociable()
        {
            //DataTable Solicitudes = cnsolicitud.ListaSolicitudesTasaNegociable(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            DataTable Solicitudes = cnsolicitud.CNListaSoliciPreTasaNegociable(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, idSolAprobacion, idSolici);
            dtgSolicitudes.DataSource = Solicitudes;
            if (Solicitudes.Rows.Count > 0)
            {
                cJustificacionSol = Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["cJustificacion"].Value);
                nTasaCompensatoriaSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value);
                nTasaMoraSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value);

                DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;

                int idSolicitudCre = Convert.ToInt32(drSolicitud["nSolicitud"]);
                int idTasaNegociable = Convert.ToInt32(drSolicitud["idTasaNegociada"]);
                int idUsuario = clsVarGlobal.User.idUsuario;

                conRastreoTasaNegociable.cargarDatos(idSolicitudCre, idTasaNegociable, idUsuario);

                BuscarSolicitud(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitud"].Value), Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value));
                asignarTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasas"].Value.ToString()));

                btnGrabar1.Enabled = true;
                btnDenegar1.Enabled = true;
            }
            else
            {
                limpiar();
                cJustificacionSol = String.Empty;
                nTasaCompensatoriaSol = Decimal.Zero;
                nTasaMoraSol = Decimal.Zero;

                btnGrabar1.Enabled = false;
                btnDenegar1.Enabled = false;
            }
        }

        private bool validar()
        {
            bool flag = true;
            if (dtgSolicitudes.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione la Solicitud a Aprobar", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa debe estar comprendida dentro del Rango", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMax.Text) < Convert.ToDecimal(txtTasaCompAprobada.Text))
            {
                MessageBox.Show("La Tasa debe estar comprendida dentro del Rango", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = false;
            }

            return flag;
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
                //if (idTipoTasaCredito == 1 && Transaccion == 'I')
                //if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() == dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString() && Transaccion == 'U')//Update
                if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() != "" && Transaccion == 'U')//Update
                {
                    txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                    txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                    idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);
                    txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);
                    //lblTipoTasaCredito.Text = Convert.ToString(dtTasa.Rows[0]["cDescripcion"]);
                }
                else
                {
                    txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);
                    txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                }

                //btnGrabar1.Enabled = true;
            }
            else
            {
                txtTasCompensatoriaMin.Text = "";
                txtTasCompensatoriaMax.Text = "";
                txtTasaCompAprobada.Text = Convert.ToString(nTasaCompensatoriaSol);
                txtTasaMora.Text = "";
                txtTasaMoraSecAproba.Text = Convert.ToString(nTasaMoraSol);
                //btnGrabar1.Enabled = false;
                lblClasifInterna.Text = string.Empty;
                MessageBox.Show("El Producto no cuenta con Tasas Negociables", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private int obtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }

        private void BuscarSolicitud(int CodigoSol, int idTasaNegociada)
        {

            //Sol = cnsolicitud.ConsultaSolicitud(CodigoSol);
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
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);


                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);

                nCodEstado = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboEstadoCredito.CargaEstadoActual(nCodEstado);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idCli"]);
                //txtMontoAmpliado.Text = (Sol.Rows[0]["nMontoAmpliado"] == DBNull.Value) ? "" : Sol.Rows[0]["nMontoAmpliado"].ToString();
                //txtSaldoCredito.Text = (Sol.Rows[0]["nSaldoCreditos"] == DBNull.Value) ? "" : Sol.Rows[0]["nSaldoCreditos"].ToString();

                var nEvaluacion = Convert.ToInt32(Sol.Rows[0]["nEvaluacion"]);


                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                    //this.nudPlazo.Maximum = 31;
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                    // this.nudPlazo.Maximum = 365;
                }
                Transaccion = Convert.ToChar("U");

                var drGarantia = cnsolicitud.ValidaGarantiasSolicitud(CodigoSol).Rows[0];

            }
            else
            {
                limpiar();
                Transaccion = Convert.ToChar("I");
                cboTipoPeriodo.Enabled = false;
                nudPlazo.Enabled = false;

                //btnGrabar1.Enabled = true;
            }

        }

        private void limpiar()
        {
            txtMonto.Text = "";
            cboMoneda.SelectedValue = 0;
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = DateTime.Today;
            cboOperacionCre1.SelectedValue = 1;
            cboEstadoCredito.SelectedValue = 0;

            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";

            cboEstadoCredito.CargaEstadoActual(999);

            //txtMontoAmpliado.Text = "";
            //txtSaldoCredito.Text = "";

            cboTipoTasaCredito.DataSource = null;
            txtTasCompensatoriaMin.Clear();
            txtTasCompensatoriaMax.Clear();
            txtTasaMoraSecAproba.Clear();
            txtTasaCompAprobada.Clear();
            //lblTipoTasaCredito.Text = "";
            conRastreoTasaNegociable.limpiar();

        }

        #endregion

        #region Eventos
        private void frmPreAprobaTasaNegociable_Load(object sender, EventArgs e)
        {
            CargarSolicitudesTasaNegociable();
            btnDenegar1.Visible = false;

            btnGrabar1.Enabled = (lAproba != 1);
        }

        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Decimal nTEM = Convert.ToDecimal(clsMathFinanciera.TEM(Convert.ToDouble(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value)).ToString("n4"));
                DataTable RegistroSolicitud = cnsolicitud.CNRegistroPreAprobacionTasaNegociable(
                                                          Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value.ToString()),
                                                          clsVarGlobal.User.idUsuario,
                                                          Convert.ToDecimal(txtTasaCompAprobada.Text),
                                                          Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value.ToString()),
                                                          nTEM
                                                          );
                if (RegistroSolicitud.Rows.Count > 0)
                {
                    MessageBox.Show("Se guardo correctamente la Tasa Negociada.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarSolicitudesTasaNegociable();
            }

        }

        private void dtgSolicitudes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                cJustificacionSol = Convert.ToString(dtgSolicitudes.SelectedRows[0].Cells["cJustificacion"].Value);
                nTasaCompensatoriaSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaSolicitada"].Value);
                nTasaMoraSol = Convert.ToDecimal(dtgSolicitudes.SelectedRows[0].Cells["nTasaMoratoriaSol"].Value);

                DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;

                int idSolicitudCre      = Convert.ToInt32(drSolicitud["nSolicitud"]);
                int idTasaNegociable    = Convert.ToInt32(drSolicitud["idTasaNegociada"]);
                int idUsuario           = clsVarGlobal.User.idUsuario;

                conRastreoTasaNegociable.cargarDatos(idSolicitudCre, idTasaNegociable, idUsuario);

                BuscarSolicitud(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitud"].Value), Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value));
                asignarTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasas"].Value.ToString()));

            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.CurrentRow != null)
            {
                DataTable Resultado = cnsolicitud.DenegarAprobacionTasaNegociable(
                                                              Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value.ToString()),
                                                              clsVarGlobal.User.idUsuario);
                if (Resultado.Rows.Count > 0)
                {
                    MessageBox.Show("Se Denego la Solicitud de la Tasa Negociada.", "Aprobación de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CargarSolicitudesTasaNegociable();
        }

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodProducto = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(nCodProducto);
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
                nCodProducto = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(nCodProducto);
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
                nCodProducto = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(nCodProducto);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }
        }

        #endregion

        
        
        
    }
}
