using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmBilletaje : frmBase
    {
        #region Variables
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        public string cTipoVisita;
        public int idVisita;
        public int idEstablecimiento;
        public bool lBtnFinalizar = true;
        private int idBilletaje = 0;
        public bool lVisitaFinalizado = false;
        public int idSupervisor = 0;
        #endregion

        #region Metodos
        public frmBilletaje()
        {
            InitializeComponent();
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgMonedas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn item in dtgBilletes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn item in dtgBillDolares.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //--Formato Grid Moneda Soles
            this.dtgMonedas.Columns["idMoneda"].Visible = false;
            this.dtgMonedas.Columns["idTipBillMon"].Visible = false;
            this.dtgMonedas.Columns["nValor"].Visible = false;
            this.dtgMonedas.Columns["cDescripcion"].FillWeight = 45;
            this.dtgMonedas.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgMonedas.Columns["nCantidad"].FillWeight = 22;
            this.dtgMonedas.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgMonedas.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgMonedas.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgMonedas.Columns["nCantDeterioro"].FillWeight = 23;
            this.dtgMonedas.Columns["nCantDeterioro"].HeaderText = "Deteriorado";
            this.dtgMonedas.Columns["nCantDeterioro"].DefaultCellStyle.Format = "N0";
            this.dtgMonedas.Columns["nCantDeterioro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgMonedas.Columns["nTotal"].FillWeight = 30;
            this.dtgMonedas.Columns["nTotal"].HeaderText = "Total";
            this.dtgMonedas.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            this.dtgMonedas.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //--Formato Grid Billetes Soles
            this.dtgBilletes.Columns["idMoneda"].Visible = false;
            this.dtgBilletes.Columns["idTipBillMon"].Visible = false;
            this.dtgBilletes.Columns["nValor"].Visible = false;
            this.dtgBilletes.Columns["cDescripcion"].FillWeight = 45;
            this.dtgBilletes.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgBilletes.Columns["nCantidad"].FillWeight = 22;
            this.dtgBilletes.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgBilletes.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgBilletes.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgBilletes.Columns["nCantDeterioro"].FillWeight = 23;
            this.dtgBilletes.Columns["nCantDeterioro"].HeaderText = "Deteriorado";
            this.dtgBilletes.Columns["nCantDeterioro"].DefaultCellStyle.Format = "N0";
            this.dtgBilletes.Columns["nCantDeterioro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgBilletes.Columns["nTotal"].FillWeight = 30;
            this.dtgBilletes.Columns["nTotal"].HeaderText = "Total";
            this.dtgBilletes.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            this.dtgBilletes.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ////--Formato Grid Billetes Dolares

            this.dtgBillDolares.Columns["idMoneda"].Visible = false;
            this.dtgBillDolares.Columns["idTipBillMon"].Visible = false;
            this.dtgBillDolares.Columns["nValor"].Visible = false;
            this.dtgBillDolares.Columns["cDescripcion"].FillWeight = 45;
            this.dtgBillDolares.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgBillDolares.Columns["nCantidad"].FillWeight = 22;
            this.dtgBillDolares.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgBillDolares.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgBillDolares.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgBillDolares.Columns["nCantDeterioro"].FillWeight = 23;
            this.dtgBillDolares.Columns["nCantDeterioro"].HeaderText = "Deteriorado";
            this.dtgBillDolares.Columns["nCantDeterioro"].DefaultCellStyle.Format = "N0";
            this.dtgBillDolares.Columns["nCantDeterioro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgBillDolares.Columns["nTotal"].FillWeight = 30;
            this.dtgBillDolares.Columns["nTotal"].HeaderText = "Total";
            this.dtgBillDolares.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            this.dtgBillDolares.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void habilitarControles(Boolean lIniciado, bool lConforme, bool lFinalizado, bool lSupervisor)
        {
            dtgBilletes.Enabled = !lConforme;
            dtgMonedas.Enabled = !lConforme;
            dtgBillDolares.Enabled = !lConforme;

            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = lIniciado ? !lConforme : lIniciado;
            btnCancelar1.Enabled = lIniciado ? !lConforme : lIniciado;
            btnConformidad.Enabled = lIniciado ? !lConforme : lIniciado;
            btnSinConformidad.Enabled = lIniciado ? !lConforme : lIniciado;
            btnFinalizar1.Enabled = lIniciado ? (lConforme ? !lFinalizado : lConforme ) : lIniciado;//lIniciado ? !lFinalizado : lIniciado;

            btnIniciar1.Visible = cboColaborador.SelectedIndex >= 0 ? !lIniciado : false;
            btnIniciar1.Enabled = cboColaborador.SelectedIndex >= 0 ? !lIniciado : false;

            pnlResultados.Visible = lConforme;

            if (txtObservacion.Text != "" || txtAccion.Text != "")
            {
                txtObservacion.ReadOnly = true;
                txtAccion.ReadOnly = true;
            }
            else
            {
                txtObservacion.ReadOnly = false;
                txtAccion.ReadOnly = false;
            }

            if (txtSustento.Text != "")
            {
                cboAnularArqueo.Enabled = false;
                txtSustento.ReadOnly = true;
            }

            btnGrabar1.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnEditar1.Visible = lSupervisor ? !(lFinalizado || lConforme) : lSupervisor;
            btnConformidad.Visible = lSupervisor ? !(lFinalizado || lConforme || !lIniciado) : lSupervisor;
            btnSinConformidad.Visible = lSupervisor ? !(lFinalizado || lConforme || !lIniciado) : lSupervisor;
            btnFinalizar1.Visible = lSupervisor ? (lBtnFinalizar ? !lFinalizado : lBtnFinalizar) : lSupervisor;
            btnEditObs.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnGrabarObs.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnEditAnular.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnGrabarAnular.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnAnular.Visible = lSupervisor ? (lIniciado ? !lConforme : lIniciado) : lSupervisor;
            btnIniciar1.Visible = lSupervisor ? !lFinalizado : lSupervisor;
            btnCancelar1.Visible = lSupervisor ? !lFinalizado : lSupervisor;
        }

        private void listarBilletaje(int idVisita, int idUsuario, int idTipResp)
        {
            DataSet dsBilletaje = clsVisita.listarBilletajeResponsable(idVisita, idUsuario, idTipResp);
            dtgBilletes.DataSource = dsBilletaje.Tables[0].Copy();
            dtgMonedas.DataSource = dsBilletaje.Tables[1].Copy();
            dtgBillDolares.DataSource = dsBilletaje.Tables[2].Copy();
            bool lSinConformidad = false;

            if (dsBilletaje.Tables[3].Rows.Count > 0)
            {
                txtSaldoSolesSis.Text = dsBilletaje.Tables[3].Rows[0]["nSaldoSoles"].ToString();
                txtSaldoDolarSis.Text = dsBilletaje.Tables[3].Rows[0]["nSaldoDolar"].ToString();
                txtFecha.Text = dsBilletaje.Tables[3].Rows[0]["dFechaInicio"].ToString();
                txtFechaConforme.Text = dsBilletaje.Tables[3].Rows[0]["dFechaConforme"].ToString();
                txtUsuario.Text = dsBilletaje.Tables[3].Rows[0]["cWinUser"].ToString();
                txtObservacion.Text = dsBilletaje.Tables[3].Rows[0]["cObservacion"].ToString();
                txtAccion.Text = dsBilletaje.Tables[3].Rows[0]["cAccion"].ToString();
                idBilletaje = Convert.ToInt32(dsBilletaje.Tables[3].Rows[0]["idBilletaje"]);
                idSupervisor = Convert.ToInt32(dsBilletaje.Tables[3].Rows[0]["idSupervisor"]);
                lSinConformidad = Convert.ToBoolean(dsBilletaje.Tables[3].Rows[0]["lSinConformidad"]);
                if (lSinConformidad)
                {
                    pnlSinConformidad.Visible = true;
                }
                else
                {
                    pnlSinConformidad.Visible = false;
                }
            }
            else
            {
                txtObservacion.Text = "";
                txtAccion.Text = "";
            }

            if (idSupervisor == 0)
            {
                idSupervisor = clsVarGlobal.PerfilUsu.idUsuario;
            }

            sumarBilletesSoles();
            sumarBilletesDolares();

            bool lConformidad = false;
            bool lFinalizado = false;
            if (dsBilletaje.Tables[3].Rows.Count > 0)
            {
                lConformidad = Convert.ToBoolean(dsBilletaje.Tables[3].Rows[0]["lConformidad"]);
                lFinalizado = Convert.ToBoolean(dsBilletaje.Tables[3].Rows[0]["lFinalizado"]);
            }

            calcularDiferenciaSaldos(lConformidad, lSinConformidad);

            cboAnularArqueo.SelectedIndex = -1;
            txtSustento.Text = "";

            habilitarControles(dsBilletaje.Tables[0].Rows.Count > 0, lConformidad, lFinalizado, idSupervisor == clsVarGlobal.PerfilUsu.idUsuario);
        }

        private void sumarBilletesSoles()
        {
            decimal nSoles = 0;
            foreach (DataGridViewRow row in dtgMonedas.Rows)
            {
                nSoles += Convert.ToDecimal(row.Cells["nCantidad"].Value) * Convert.ToDecimal(row.Cells["nValor"].Value);
            }

            foreach (DataGridViewRow row in dtgBilletes.Rows)
            {
                nSoles += Convert.ToDecimal(row.Cells["nCantidad"].Value) * Convert.ToDecimal(row.Cells["nValor"].Value);
            }

            txtSolesTotal.Text = nSoles.ToString();
            txtSaldoSolesBilletaje.Text = nSoles.ToString();
        }

        private void sumarBilletesDolares()
        {
            decimal nDolar = 0;
            foreach (DataGridViewRow row in dtgBillDolares.Rows)
            {
                nDolar += Convert.ToDecimal(row.Cells["nCantidad"].Value) * Convert.ToDecimal(row.Cells["nValor"].Value);
            }

            txtDolarTotal.Text = nDolar.ToString();
            txtSaldoDolarBilletaje.Text = nDolar.ToString();
        }

        private void calcularDiferenciaSaldos(bool lConformidad, bool lSinConformidad)
        {
            if (!lConformidad)
            {
                activarPnlExtra("ninguno");
                return;
            }

            txtSaldoSolesDif.Text = ((Convert.ToDecimal(txtSaldoSolesBilletaje.Text)) - (Convert.ToDecimal(txtSaldoSolesSis.Text))).ToString();
            txtSaldoDolarDif.Text = ((Convert.ToDecimal(txtSaldoDolarBilletaje.Text)) - (Convert.ToDecimal(txtSaldoDolarSis.Text))).ToString();

            if ((Convert.ToDecimal(txtSaldoSolesBilletaje.Text)) - (Convert.ToDecimal(txtSaldoSolesSis.Text)) != 0 
                || (Convert.ToDecimal(txtSaldoDolarBilletaje.Text)) - (Convert.ToDecimal(txtSaldoDolarSis.Text)) != 0
                || lSinConformidad)
            {
                activarPnlExtra("observacion");
            }
            else
            {
                activarPnlExtra("ninguno");
            }
        }

        private string convertDtgXml(DataTable dt)
        {
            dt.TableName = "billetaje";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
                ds = dt.DataSet;
            else
                ds.Tables.Add(dt);
            return ds.GetXml();
        }

        private void listarResponsablesEstablecimiento()
        {
            cboColaborador.SelectedIndexChanged -= cboColaborador_SelectedIndexChanged;
            int idTipResCaj = 0;
            if (cboTipResponsableCaja1.SelectedIndex >= 0)
            {
                idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            }
            DataTable dtResponsable = clsVisita.listarResponsablesVisitaEstablecimiento(idVisita, idEstablecimiento, idTipResCaj);
            cboColaborador.ValueMember = dtResponsable.Columns["idUsuario"].ToString();
            cboColaborador.DisplayMember = dtResponsable.Columns["cNombre"].ToString();
            cboColaborador.DataSource = dtResponsable;
            cboColaborador.SelectedIndex = dtResponsable.Rows.Count == 1 ? 0 : -1;
            cboColaborador.SelectedIndexChanged += cboColaborador_SelectedIndexChanged;
        }

        private void configurarEdicion(bool lEditar)
        {
            //grid soles monedas
            dtgMonedas.ReadOnly = !lEditar;
            dtgMonedas.Columns["idMoneda"].ReadOnly = lEditar;
            dtgMonedas.Columns["idTipBillMon"].ReadOnly = lEditar;
            dtgMonedas.Columns["nValor"].ReadOnly = lEditar;
            dtgMonedas.Columns["cDescripcion"].ReadOnly = lEditar;
            dtgMonedas.Columns["nCantidad"].ReadOnly = !lEditar;
            dtgMonedas.Columns["nCantDeterioro"].ReadOnly = !lEditar;
            dtgMonedas.Columns["nTotal"].ReadOnly = lEditar;
            //grid soles billetes
            dtgBilletes.ReadOnly = !lEditar;
            dtgBilletes.Columns["idMoneda"].ReadOnly = lEditar;
            dtgBilletes.Columns["idTipBillMon"].ReadOnly = lEditar;
            dtgBilletes.Columns["nValor"].ReadOnly = lEditar;
            dtgBilletes.Columns["cDescripcion"].ReadOnly = lEditar;
            dtgBilletes.Columns["nCantidad"].ReadOnly = !lEditar;
            dtgBilletes.Columns["nCantDeterioro"].ReadOnly = !lEditar;
            dtgBilletes.Columns["nTotal"].ReadOnly = lEditar;

            //grid dolares
            dtgBillDolares.ReadOnly = !lEditar;
            dtgBillDolares.Columns["idMoneda"].ReadOnly = lEditar;
            dtgBillDolares.Columns["idTipBillMon"].ReadOnly = lEditar;
            dtgBillDolares.Columns["nValor"].ReadOnly = lEditar;
            dtgBillDolares.Columns["cDescripcion"].ReadOnly = lEditar;
            dtgBillDolares.Columns["nCantidad"].ReadOnly = !lEditar;
            dtgBillDolares.Columns["nCantDeterioro"].ReadOnly = !lEditar;
            dtgBillDolares.Columns["nTotal"].ReadOnly = lEditar;

            btnEditar1.Enabled = dtgBilletes.Rows.Count>0 ? !lEditar: false;
            btnGrabar1.Enabled = lEditar;
            btnConformidad.Enabled = !lEditar;
            btnSinConformidad.Enabled = !lEditar;
        }

        private void activarPnlExtra(string cTipo)
        {
            pnlExtra.Visible = true;
            btnGrabar1.Visible = false;
            btnEditar1.Visible = false;
            btnConformidad.Visible = false;
            btnSinConformidad.Visible = false;

            if (cTipo == "anular")
            {
                pnlObservacion.Visible = false;
                pnlAnular.Visible = true;
            }
            else if (cTipo == "observacion")
            {
                pnlObservacion.Visible = true;
                pnlAnular.Visible = false;
            }
            else if (cTipo == "ninguno")
            {
                pnlExtra.Visible = false;
            }
        }
        #endregion

        #region Eventos
        private void dtgMonedas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int fila = Convert.ToInt32(this.dtgMonedas.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            this.dtgMonedas.Rows[fila].Cells["nTotal"].Value = Convert.ToDecimal(this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal(this.dtgMonedas.Rows[fila].Cells["nValor"].Value);
            sumarBilletesSoles();
        }

        private void dtgMonedas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgBilletes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBilletes.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgBilletes.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgBilletes.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            this.dtgBilletes.Rows[fila].Cells["nTotal"].Value = Convert.ToDecimal(this.dtgBilletes.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal(this.dtgBilletes.Rows[fila].Cells["nValor"].Value);
            sumarBilletesSoles();
        }

        private void dtgBilletes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgBillDolares_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBillDolares.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgBillDolares.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgBillDolares.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            this.dtgBillDolares.Rows[fila].Cells["nTotal"].Value = Convert.ToDecimal(this.dtgBillDolares.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal(this.dtgBillDolares.Rows[fila].Cells["nValor"].Value);
            sumarBilletesDolares();
        }

        private void dtgBillDolares_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmBilletaje_Load(object sender, EventArgs e)
        {
            cboTipResponsableCaja1.cargarTipoResponsableSupervision(cTipoVisita);

            listarResponsablesEstablecimiento();

            dtgBilletes.CellValueChanged -= dtgBilletes_CellValueChanged;
            dtgBilletes.EditingControlShowing -= dtgBilletes_EditingControlShowing;
            dtgMonedas.CellValueChanged -= dtgMonedas_CellValueChanged;
            dtgMonedas.EditingControlShowing -= dtgMonedas_EditingControlShowing;
            dtgBillDolares.CellValueChanged -= dtgBillDolares_CellValueChanged;
            dtgBillDolares.EditingControlShowing -= dtgBillDolares_EditingControlShowing;
            int idResponsable = 0;
            if (cboColaborador.SelectedIndex >= 0)
                idResponsable = Convert.ToInt32(cboColaborador.SelectedValue);
            int idTipResCaj = 0;
            if (cboTipResponsableCaja1.SelectedIndex >= 0)
                idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);

            listarBilletaje(idVisita, idResponsable, idTipResCaj);
            formatoGrid();

            dtgBilletes.CellValueChanged += dtgBilletes_CellValueChanged;
            dtgBilletes.EditingControlShowing += dtgBilletes_EditingControlShowing;
            dtgMonedas.CellValueChanged += dtgMonedas_CellValueChanged;
            dtgMonedas.EditingControlShowing += dtgMonedas_EditingControlShowing;
            dtgBillDolares.CellValueChanged += dtgBillDolares_CellValueChanged;
            dtgBillDolares.EditingControlShowing += dtgBillDolares_EditingControlShowing;

            DataTable dtMotivos = clsVisita.getMotivosAnularBilletaje();
            cboAnularArqueo.ValueMember = dtMotivos.Columns[0].ToString();
            cboAnularArqueo.DisplayMember = dtMotivos.Columns[1].ToString();
            cboAnularArqueo.DataSource = dtMotivos;
            cboAnularArqueo.SelectedIndex = -1;
        }

        private void btnIniciar1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Convert.ToInt32(cboColaborador.SelectedValue)) == clsVarGlobal.PerfilUsu.idUsuario)
            {
                MessageBox.Show( "El arqueo Inopinado no puede realizarse a sí mismo", "Inicio de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea Iniciar el registro de Arqueo Inopinado?", "Registro de Arqueo Inopinado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtInicio = clsVisita.iniciarBilletajeSupervision(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue), clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

                if (Convert.ToInt32(dtInicio.Rows[0]["idResp"]) == 1)
                {
                    MessageBox.Show(dtInicio.Rows[0]["cMensaje"].ToString(), "Inicio de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarBilletaje(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue));
                    configurarEdicion(true);
                    txtSustento.ReadOnly = false;
                    cboAnularArqueo.Enabled = true;
                }
                else
                {
                    MessageBox.Show(dtInicio.Rows[0]["cMensaje"].ToString(), "Inicio de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable tbMonSol = (DataTable)dtgMonedas.DataSource;
            DataTable tbBillSol = (DataTable)dtgBilletes.DataSource; ;
            DataTable tbBillDol = (DataTable)dtgBillDolares.DataSource;

            string xmlMonSol = convertDtgXml(tbMonSol);
            string xmlBillSol = convertDtgXml(tbBillSol);
            string xmlBillDol = convertDtgXml(tbBillDol);

            DataTable dtRes = clsVisita.guardarBilletaje(idBilletaje, clsVarGlobal.PerfilUsu.idUsuario, xmlMonSol, xmlBillSol, xmlBillDol);

            if (Convert.ToInt32(dtRes.Rows[0]["idResp"]) == 1)
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Guardar Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarControles(true, false, false, true);
                configurarEdicion(false);
            }
            else
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Guardar Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipResponsableCaja1.SelectedIndex >= 0 && cboColaborador.SelectedIndex >= 0)
            {
                listarBilletaje(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue));
                configurarEdicion(false);
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            configurarEdicion(true);
        }

        private void btnConformidad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea dar su Conformidad al registro de Arqueo Inopinado?", "Conformidad de Registro de Arqueo Inopinado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmCredenciales frmCredenciales = new frmCredenciales();
                frmCredenciales.cWinUser = txtUsuario.Text;
                frmCredenciales.ShowDialog();
                if (!frmCredenciales.lValido)
                {
                    MessageBox.Show("Confirmación no realizada. Las credenciales no son válidas.", "Conformidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Inicio - Conformidad de Arqueo Inopinado idVisita: " + idVisita + "- " + cboTipResponsableCaja1.Text + ": " + txtUsuario.Text, btnConformidad);

                DataTable dtConforme = clsVisita.guardarConformidadBilletaje(idBilletaje, clsVarGlobal.PerfilUsu.idUsuario);

                if (Convert.ToInt32(dtConforme.Rows[0]["idResp"]) == 1)
                {
                    MessageBox.Show(dtConforme.Rows[0]["cMensaje"].ToString(), "Inicio de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarBilletaje(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue));
                }
                else
                {
                    MessageBox.Show(dtConforme.Rows[0]["cMensaje"].ToString(), "Inicio de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Fin - Conformidad de Arqueo Inopinado idVisita: " + idVisita + "- " + cboTipResponsableCaja1.Text + ": " + txtUsuario.Text, btnConformidad);

            }
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            txtObservacion.ReadOnly = false;
            txtAccion.ReadOnly = false;
        }

        private void btnGrabarObs_Click(object sender, EventArgs e)
        {
            if (txtObservacion.Text == "")
            {
                MessageBox.Show("Se debe llenar el campo Observación", "Observaciones y Acciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtAccion.Text == "")
            {
                MessageBox.Show("Se debe llenar el campo Acciones a Tomar", "Observaciones y Acciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtResp = clsVisita.guardarObservacionAccion(idBilletaje, txtObservacion.Text, txtAccion.Text, clsVarGlobal.PerfilUsu.idUsuario);

            if (Convert.ToInt32(dtResp.Rows[0]["idResp"]) == 1)
            {
                MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtObservacion.ReadOnly = true;
                txtAccion.ReadOnly = true;
            }
            else
            {
                MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFinalizar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea finalizar el Arqueo Inopinado?", "Arqueo Inopinado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtValidaArqueo = clsVisita.validarArqueoInopinado(idVisita, cTipoVisita);

                if (dtValidaArqueo.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtValidaArqueo.Rows[0]["idRespuesta"]) == 0)
                    {
                        MessageBox.Show(dtValidaArqueo.Rows[0]["cMensaje"].ToString(), "Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DataTable dtResp = clsVisita.finalizarVisitaSupervision(idVisita, clsVarGlobal.PerfilUsu.idUsuario);

                if (Convert.ToInt32(dtResp.Rows[0]["idRes"]) == 1)
                {
                    MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarControles(true, true, true, true);
                    lVisitaFinalizado = true;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            idBilletaje = 0;
            listarBilletaje(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue));
            configurarEdicion(false);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            activarPnlExtra("anular");
            btnAnular.Visible = false;
        }

        private void btnGrabarAnular_Click(object sender, EventArgs e)
        {
            if (txtSustento.Text == "")
            {
                MessageBox.Show("Se debe llenar el campo Sustento", "Anular Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboAnularArqueo.SelectedIndex < 0)
            {
                MessageBox.Show("Se debe seleccionar un Motivo de anulación", "Anular Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtResp = clsVisita.anularBilletaje(idBilletaje, Convert.ToInt32(cboAnularArqueo.SelectedValue), txtSustento.Text, clsVarGlobal.PerfilUsu.idUsuario);

            if (Convert.ToInt32(dtResp.Rows[0]["idResp"]) == 1)
            {
                MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Anular Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSustento.ReadOnly = true;
                cboAnularArqueo.Enabled = false;
            }
            else
            {
                MessageBox.Show(dtResp.Rows[0]["cMensaje"].ToString(), "Anular Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditAnular_Click(object sender, EventArgs e)
        {
            txtSustento.ReadOnly = false;
            cboAnularArqueo.Enabled = true;
        }

        private void btnSinConformidad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea registrar el Arqueo Inopinado SIN CONFORMIDAD por parte de responsable?", "Sin Conformidad - Arqueo Inopinado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtRes = clsVisita.guardarSustentoSinConformidad(idBilletaje, clsVarGlobal.PerfilUsu.idUsuario);

                if (Convert.ToInt32(dtRes.Rows[0]["idResp"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Sustento de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarBilletaje(idVisita, Convert.ToInt32(cboColaborador.SelectedValue), Convert.ToInt32(cboTipResponsableCaja1.SelectedValue));
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Sustento de Arqueo Inopinado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion
    }
}
