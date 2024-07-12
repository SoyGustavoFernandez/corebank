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


namespace GEN.ControlesBase
{
    public partial class frmSolCreTasaNegSimp : frmBase
    {

        #region Variables Globales

        DataTable Sol = new DataTable("dtSolicitud");
        int nCodPro = 1, nCodEst = 0, idCliente = 0, idAgencia = clsVarGlobal.nIdAgencia;
        int idTasa = 0;
        bool lEstado = true, lValGarantia = false;
        decimal nMontoSolicitado = 0;
        char Transaccion = Convert.ToChar("I");
        public int idEstadoSol = 0;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        int idClasificacionInterna;
        
        int idSolicitudT = 0;
        public bool lSolicitudCargado = false;

        #endregion

        public frmSolCreTasaNegSimp()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[0,1,2,13]";
            cboTipoCredito.CargarProducto(nCodPro);

            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;

            btnAnular1.Enabled = false;
        }


        public frmSolCreTasaNegSimp(int _idCli, int _idSolicitud)
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[0,1,2,13]";
            cboTipoCredito.CargarProducto(nCodPro);

            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;

            this.idCliente = _idCli;
            this.idSolicitudT = _idSolicitud;
            this.lSolicitudCargado = true;

            btnAnular1.Enabled = false;
        }

        private void buscarCuenta(int idSolicitud)
        {
            if (idSolicitud == 0)
            {
                limpiar();
                MessageBox.Show("No se encontró número de solicitud", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            BuscarSolicitud(idSolicitud);
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
            cboPersonalCreditos.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";

            cboEstadoCredito.CargaEstadoActual(999);
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";

            btnGrabar1.Enabled = true;


            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;


            conBusCuentaCli1.txtNroBusqueda.Focus();

            txtJustificacionSolicitud.Clear();
            cboTipoTasaCredito.DataSource = null;
            txtTasCompensatoriaMin.Clear();
            txtTasCompensatoriaMax.Clear();
            txtTasaMoraSec.Clear();
            txtTasaCompensatoria.Clear();
            lblTipoTasaCredito.Text = "";
            lblClasifInterna.Text = string.Empty;

            limpiarTasasNegociadas();


        }
        private void limpiarTasasNegociadas()
        {
            int c = dtgSolicitudes.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtgSolicitudes.Rows.RemoveAt(0);
            }
        }

        private void formatearSolicitudTasaNegociable()
        {
            foreach(DataGridViewColumn dgColumna in dtgSolicitudes.Columns)
            {
                dgColumna.Visible = false;
            }

            dtgSolicitudes.Columns["idSolicitud"].Visible           = true;
            dtgSolicitudes.Columns["dFechaReg"].Visible             = true;
            dtgSolicitudes.Columns["cUsuAprueba"].Visible           = true;
            dtgSolicitudes.Columns["nTasaSolicitada"].Visible       = true;
            dtgSolicitudes.Columns["nTasaPreAprobada"].Visible      = true;
            dtgSolicitudes.Columns["nTasaAprobada"].Visible         = true;
            dtgSolicitudes.Columns["nTasaMoratoriaSol"].Visible     = true;
            dtgSolicitudes.Columns["cDescEstado"].Visible           = true;
            dtgSolicitudes.Columns["cProducto"].Visible             = true;
            dtgSolicitudes.Columns["cMoneda"].Visible               = true;
            dtgSolicitudes.Columns["nCapitalSolicitado"].Visible    = true;
            dtgSolicitudes.Columns["nCuotas"].Visible               = true;
            dtgSolicitudes.Columns["cDescripTipoPeriodo"].Visible   = true;
            dtgSolicitudes.Columns["nPlazoCuota"].Visible           = true;
            dtgSolicitudes.Columns["nDiasGracia"].Visible           = true;
            dtgSolicitudes.Columns["FechaDesembolso"].Visible       = true;

            dtgSolicitudes.Refresh();
        }

        public void BuscarSolicitud(int CodigoSol)
        {

            Sol = cnsolicitud.ExtraeDatosSolicitudTNegociable(CodigoSol, clsVarGlobal.User.idUsuario);

            if (Sol.Rows.Count > 0)
            {
                bool lNegociableRefinanciado = false;
                lNegociableRefinanciado = Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["lTasaNegociableRefinanciado"]));

                int idOperacion = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ?
                    0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);

                if (idOperacion.In(2,6) && !lNegociableRefinanciado)
                {
                    MessageBox.Show("¡No se permite negociar la tasa para operaciones de REFINANCIAMIENTO en ninguna de sus modalidades!", "OPERACION NO ADMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                    btnGrabar1.Enabled = false;
                    btnAnular1.Enabled = false;
                    txtJustificacionSolicitud.Clear();
                    return;
                }

                dtpFechaSol.Value = (Sol.Rows[0]["dFechaRegistro"] == DBNull.Value) ? clsVarGlobal.dFecSystem : (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? "" : Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? 0.00m : (Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = (Sol.Rows[0]["IdMoneda"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = (Sol.Rows[0]["nCuotas"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboPersonalCreditos.SelectedValue = (Sol.Rows[0]["idUsuario"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idUsuario"]);
                cboTipoCredito.SelectedValue = (Sol.Rows[0]["nTipCre"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = (Sol.Rows[0]["nSubTip"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = (Sol.Rows[0]["nProdu"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = (Sol.Rows[0]["nSubPro"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                idClasificacionInterna = (Sol.Rows[0]["idClasificacionInterna"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idClasificacionInterna"]);

                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);
                lblClasifInterna.Text = (Sol.Rows[0]["cClasificacionInterna"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["cClasificacionInterna"]);

                nCodEst = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboEstadoCredito.CargaEstadoActual(nCodEst);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idCli"]);
                //txtMontoAmpliado.Text = (Sol.Rows[0]["nMontoAmpliado"] == DBNull.Value) ? "" : Sol.Rows[0]["nMontoAmpliado"].ToString();
                //txtJustificacionSolicitud.Text = (Sol.Rows[0]["cComentAproba"] == DBNull.Value) ? "" : Sol.Rows[0]["cComentAproba"].ToString();

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
                conBusCuentaCli1.btnBusCliente1.Enabled = false;
                conBusCuentaCli1.txtNroBusqueda.Enabled = false;

                btnGrabar1.Enabled = true;
                txtJustificacionSolicitud.Enabled = true;

                var drGarantia = cnsolicitud.ValidaGarantiasSolicitud(CodigoSol).Rows[0];

                int nTotalDias = obtenerTotalDias(dtFechaDesembolso.Value, Convert.ToInt32(nudCuotas.Value), Convert.ToInt32(nudDiasGracia.Value.ToString()), Convert.ToInt32(cboTipoPeriodo.SelectedValue), Convert.ToInt32(nudPlazo.Value));
                int idProducto = Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                decimal nMonto = Convert.ToDecimal(string.IsNullOrEmpty(txtMonto.Text) ? "0.00" : txtMonto.Text);
                int idMoneda = Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);

                asignarTasaNegociable(nTotalDias, idProducto, nMonto, idMoneda);
                seguimientoTasaNegociable(CodigoSol, clsVarGlobal.User.idUsuario);

            }
            else
            {
                if(!lSolicitudCargado)
                {
                    limpiar();
                }

                Transaccion = Convert.ToChar("I");
                cboTipoPeriodo.Enabled = false;
                nudPlazo.Enabled = false;

                btnGrabar1.Enabled = false;
            }

        }
        private void seguimientoTasaNegociable(int idSolicitud, int idusuario)
        {
            DataTable TasasNegociadas = cnsolicitud.SeguimientoTasaNegociable(idSolicitud, idusuario);
            limpiarTasasNegociadas();
            if (TasasNegociadas.Rows.Count > 0)
            {
                dtgSolicitudes.DataSource = TasasNegociadas;
                formatearSolicitudTasaNegociable();
            }

            if (tbcBase1.SelectedIndex == 1)
            {
                if (dtgSolicitudes.Rows.Count > 0)
                {
                    btnAnular1.Enabled = true;
                }
            }
        }

        private int obtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }

        private void asignarTasaNegociable(int nTotalDias, int idProducto, decimal nMonto, int idMoneda)
        {

            cboTipoTasaCredito.DataSource = null;

            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
            DataTable dtTasa;
            dtTasa = TasaCredito.ListaTasaCreditoNegociable(nTotalDias, idProducto, nMonto, idMoneda, idAgencia, Convert.ToInt32(cboOperacionCre1.SelectedValue), idClasificacionInterna);

            if (dtTasa.Rows.Count > 0)
            {

                cboTipoTasaCredito.DataSource = dtTasa;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                var idTipoTasaCredito = Convert.ToInt32(dtTasa.Rows[0]["idTipoTasaCredito"]);

                //if (idTipoTasaCredito == 1 && Transaccion == 'I')
                //if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() == dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString() && Transaccion == 'U')//Update
                if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() != "" && Transaccion == 'U')//Update
                {
                    txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                    txtTasaMoraSec.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
                    idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);

                    lblTipoTasaCredito.Text = Convert.ToString(dtTasa.Rows[0]["cDescripcion"]);
                    txtTasaCompensatoria.Enabled = true;
                    txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                }
                else
                {
                    txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasaMoraSec.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
                }

                txtTasaCompensatoria.Enabled = true;
                btnGrabar1.Enabled = true;
            }
            else
            {
                txtTasCompensatoriaMin.Text = "";
                txtTasCompensatoriaMax.Text = "";
                txtTasaCompensatoria.Text = "";
                //txtTasaMora.Text = "";
                txtTasaMoraSec.Text = "";
                txtTasaCompensatoria.Enabled = false;
                btnGrabar1.Enabled = false;

                MessageBox.Show("El Producto no cuenta con Tasas Negociables", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool validar()
        {
            bool flag = true;
            if (txtJustificacionSolicitud.Text == "")
            {
                MessageBox.Show("Debe hacer el ingreso de su justificación", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompensatoria.Text))
            {
                MessageBox.Show("Debe Ingresar una Tasa Valida.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(txtTasaCompensatoria.Text) > Convert.ToDecimal(txtTasCompensatoriaMax.Text))
            {
                MessageBox.Show("Debe Ingresar una Tasa Valida.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return flag;

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            //cboTipoTasaCredito.DataSource = null;
            btnGrabar1.Enabled = false;
            if (validar())
            {
                clsCNTasaCredito TasaCredito = new clsCNTasaCredito();

                DataTable dtResultado;

                dtResultado = cnsolicitud.RegistraSolicitudTasaNegociable(
                                                    Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()),
                                                    Convert.ToInt32(cboTipoTasaCredito.SelectedValue),
                                                    Convert.ToDecimal(txtTasaCompensatoria.Text),
                                                    Convert.ToDecimal(txtTasaMoraSec.Text),
                                                    txtJustificacionSolicitud.Text,
                                                    clsVarGlobal.User.idUsuario,
                                                    Convert.ToInt32(Sol.Rows[0]["idTasa"].ToString()),
                                                    Convert.ToDecimal(Sol.Rows[0]["nTasaCompensatoria"].ToString()),
                                                    clsVarGlobal.nIdAgencia,
                                                    clsVarGlobal.dFecSystem.Date,

                                                    Convert.ToInt32(Sol.Rows[0]["nTipCre"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nSubTip"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nProdu"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nSubPro"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["IdMoneda"].ToString()),
                                                    Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nCuotas"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["ndiasgracia"].ToString()),
                                                    Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"].ToString())
                                                    );

                if (dtResultado.Rows.Count > 0)
                {
                    //txtTasaCompensatoria.Enabled = true;
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    seguimientoTasaNegociable(Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()), clsVarGlobal.User.idUsuario);
                }
                else
                {
                    MessageBox.Show("No se Pudo hacer el registro de la Solicitud", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar1.Enabled = true;
                }
            }
            else
            {
                btnGrabar1.Enabled = true;
            }

        }
        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            Int32 nIdSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            buscarCuenta(nIdSol);
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            BuscarSolicitud(CodSol);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            btnGrabar1.Enabled = false;
            btnAnular1.Enabled = false;
            //Habilitar(false);
            txtJustificacionSolicitud.Clear();
        }


        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTasaCredito.SelectedIndex > -1)
            {
                var drTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;
                txtTasCompensatoriaMin.Text = Convert.ToString(drTasa["nTasaCompensatoria"]);
                txtTasCompensatoriaMax.Text = Convert.ToString(drTasa["nTasaCompensatoriaMax"]);
                txtTasaMoraSec.Text = Convert.ToString(drTasa["nTasaMoratoria"]);
                txtTasaCompensatoria.Text = Convert.ToString(drTasa["nTasaCompensatoriaMax"]);
                if (txtTasCompensatoriaMin.Text == txtTasCompensatoriaMax.Text)
                {
                    txtTasaCompensatoria.Enabled = false;
                    txtTasaCompensatoria.Text = txtTasCompensatoriaMax.Text;
                }
                else
                {
                    txtTasaCompensatoria.Focus();
                    txtTasaCompensatoria.SelectAll();
                    txtTasaCompensatoria.Enabled = true;
                }
            }
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void dtgSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarDetalleSeguimientoTasaNegociable();
        }

        private void btnMiniDetalle_Click(object sender, EventArgs e)
        {
            mostrarDetalleSeguimientoTasaNegociable();
        }

        public void mostrarDetalleSeguimientoTasaNegociable()
        {
            if(dtgSolicitudes.SelectedRows.Count > 0)
            {
                int nIndex = (dtgSolicitudes.SelectedRows.Count > 0) ? dtgSolicitudes.SelectedRows[0].Index : -1;
                DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;
                int idSolicitudN = Convert.ToInt32(drSolicitud["nSolicitud"]);
                int idTasaNegociadaN = Convert.ToInt32(drSolicitud["idTasaNegociada"]);

                if (nIndex != -1)
                {
                    frmDetalleTasaNegSimp frmDetalleNegociable = new frmDetalleTasaNegSimp();
                    frmDetalleNegociable.cargarDetalleTasaNegociable(idSolicitudN, idTasaNegociadaN, clsVarGlobal.User.idUsuario);
                    frmDetalleNegociable.ShowDialog();
                }
            }
        }

        private void frmSolCreTasaNegSimp_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.buscarCuentasPorCliente(idCliente);
            buscarCuenta(idSolicitudT);
            this.btnCancelar1.Enabled = (lSolicitudCargado) ? false : true;
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

        private void btnAnular1_Click(object sender, EventArgs e)
        {
            if(dtgSolicitudes.SelectedRows.Count > 0)
            {
                if(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idEstado"].Value) != 5 )
                {
                    DataTable Resultado = cnsolicitud.AnularSolicitudTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idTasaNegociada"].Value),
                                                                            Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idEstado"].Value),
                                                                            clsVarGlobal.User.idUsuario, Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolAproba"].Value));
                    if (Resultado.Rows.Count > 0)
                    {
                        MessageBox.Show(Resultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo anular la Solicitud ", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    seguimientoTasaNegociable(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitud"].Value), clsVarGlobal.User.idUsuario);
                }
            }
            
        }

        private void tbcBase1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbcBase1.SelectedIndex == 0)
            {
                btnAnular1.Enabled = false;
            }

            if (tbcBase1.SelectedIndex == 1)
            {
                if (dtgSolicitudes.Rows.Count > 0)
                {
                    btnAnular1.Enabled = true;
                }
            }

        }

    }
}



