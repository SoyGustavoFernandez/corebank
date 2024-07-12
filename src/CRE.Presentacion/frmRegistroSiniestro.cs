using ADM.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRegistroSiniestro : frmBase
    {
        clsCNSiniestros objCNSiniestros = new clsCNSiniestros();
        int _nIdSeguroSiniestro = 0;
        int _nIdSeguro = 0;
        int _nIdAgencia = 0;
        string cFormName = "Registro de Siniestro";
        bool lAdquiridoVentaLibre = false;

        public frmRegistroSiniestro()
        {
            InitializeComponent();
        }

        private void frmRegistroSiniestro_Load(object sender, System.EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            //Coloco por defecto la fecha del sistema
            tmpFechaRegistro.Text = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
            ValidaPermisosEnForm();
        }

        private void CargarDatos(int idCli)
        {
            DataTable dtSiniestros = objCNSiniestros.ListarSiniestrosPorCliente(idCli);
            //llena el dtgsiniestros
            if (dtSiniestros.Rows.Count > 0)
            {
                dtgSiniestros.DataSource = dtSiniestros;
                InicializarDTGSiniestros();
                tbcBase1.SelectedTab = tbcBase1.TabPages[1];
            }
            CargarCombos(idCli);
        }

        private void InicializarDTGSiniestros()
        {
            dtgSiniestros.Columns["nIdSeguroSiniestro"].Visible = false;
            dtgSiniestros.Columns["nTipoSeguro"].Visible = false;
            dtgSiniestros.Columns["cTipoSeguro"].Visible = true;
            dtgSiniestros.Columns["idAgencia"].Visible = false;
            dtgSiniestros.Columns["idCli"].Visible = false;
            dtgSiniestros.Columns["idCuenta"].Visible = true;
            dtgSiniestros.Columns["idRecibo"].Visible = true;
            dtgSiniestros.Columns["saldoCapital"].Visible = true;
            dtgSiniestros.Columns["dFecIniCobertura"].Visible = true;
            dtgSiniestros.Columns["dFecFinCobertura"].Visible = true;
            dtgSiniestros.Columns["idEstadoSiniestro"].Visible = false;
            dtgSiniestros.Columns["dFechaSiniestro"].Visible = false;
            dtgSiniestros.Columns["cEstado"].Visible = true;
            dtgSiniestros.Columns["idUsuReg"].Visible = false;
            dtgSiniestros.Columns["idUsuMod"].Visible = false;
            dtgSiniestros.Columns["dFecReg"].Visible = false;
            dtgSiniestros.Columns["dFecMod"].Visible = false;
            dtgSiniestros.Columns["lVigente"].Visible = false;
            dtgSiniestros.Columns["cTipoSeguro"].HeaderText = "Tipo Seguro";
            dtgSiniestros.Columns["cEstado"].HeaderText = "Estado";
            dtgSiniestros.Columns["dFecIniCobertura"].HeaderText = "Inicio Cobertura";
            dtgSiniestros.Columns["dFecFinCobertura"].HeaderText = "Fin Cobertura";
            dtgSiniestros.Columns["saldoCapital"].HeaderText = "Saldo Capital";
            dtgSiniestros.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSiniestros.Columns["idRecibo"].HeaderText = "Recibo";
            dtgSiniestros.Columns["cEstablecimiento"].HeaderText = "Establecimiento";
            //Ajusto el tamaño del datagrid para que se vea bien
            dtgSiniestros.Columns["cTipoSeguro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["dFecIniCobertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["dFecFinCobertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["idCuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["idRecibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["saldoCapital"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["cEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgSiniestros.Columns["cEstablecimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void CargarCombos(int idCli)
        {
            try
            {
                DataTable tblSeguros = new clsCNSeguros().ListarSeguros(idCli);
                DataTable tblEstadosSiniestro = objCNSiniestros.CargarEstadosSiniestro();

                llenarPredeterminadoEnCombo(tblSeguros);
                cboSeguros.DataSource = tblSeguros;
                cboSeguros.DisplayMember = "cTipoSeguro";
                cboSeguros.ValueMember = "idTipoSeguro";

                if (tblEstadosSiniestro.Rows.Count > 0)
                {
                    cboEstadoSiniestro.DataSource = tblEstadosSiniestro;
                    cboEstadoSiniestro.DisplayMember = "cEstado";
                    cboEstadoSiniestro.ValueMember = "idEstadoSiniestro";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarPredeterminadoEnCombo(DataTable tblSeguros)
        {
            DataRow row = tblSeguros.NewRow();
            row["idTipoSeguro"] = -1;
            row["cTipoSeguro"] = "NINGUNO";
            row["nValor"] = 0;
            row["idTipoValor"] = 0;
            row["idConceptoRecibo"] = 0;
            row["lVigente"] = true;
            row["idTipoPagoSeguroOptativo"] = 0;
            row["idUsuReg"] = 0;
            row["dFechaRegistro"] = DateTime.Now;
            row["idUsuMod"] = 0;
            row["dFechaMod"] = DateTime.Now;
            row["lPagoCuotas"] = false;
            row["lHistorico"] = false;
            row["lCambioPrima"] = false;
            row["lRegistroSiniestro"] = false;
            tblSeguros.Rows.InsertAt(row, 0);
        }

        private void ValidaPermisosEnForm()
        {
            DataTable tblPermisos = objCNSiniestros.ValidaPermisosEnForm(clsVarGlobal.PerfilUsu.idPerfil);

            if (tblPermisos.Rows.Count > 0)
                ValidarBotonesSegunPermiso(Convert.ToBoolean(tblPermisos.Rows[0]["lPermisoEscritura"]));
            else
                ValidarBotonesSegunPermiso(false);

            cboSeguros.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoSiniestro.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void ValidarBotonesSegunPermiso(bool lPermisoEscritura)
        {
            cboSeguros.Enabled = lPermisoEscritura;
            tmpIniCobertura.Enabled = false; 
            tmpFinCobertura.Enabled = false; 
            txtRegion.Enabled = false; 
            txtOficina.Enabled = false; 
            txtNumCredito.Enabled = false; 
            txtSaldoCapital.Enabled = false; 
            tmpFechaRegistro.Enabled = lPermisoEscritura;
            cboEstadoSiniestro.Enabled = lPermisoEscritura;
            btnGrabar.Enabled = lPermisoEscritura;
            btnNuevo.Enabled = lPermisoEscritura;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                    return;

                clsSiniestros objSiniestros = new clsSiniestros();
                objSiniestros.nIdSeguroSiniestro = _nIdSeguroSiniestro;
                objSiniestros.idSeguro = _nIdSeguro;
                objSiniestros.nTipoSeguro = Convert.ToInt32(cboSeguros.SelectedValue);
                objSiniestros.idAgencia = _nIdAgencia == 0 ? clsVarGlobal.nIdAgencia : _nIdAgencia;
                objSiniestros.idCli = Convert.ToInt32(conBusCli.txtCodCli.Text);
                objSiniestros.idRecibo = lAdquiridoVentaLibre ? Convert.ToInt32(txtNumCredito.Text) : 0;
                objSiniestros.idCuenta = !lAdquiridoVentaLibre ? Convert.ToInt32(txtNumCredito.Text) : 0;
                objSiniestros.saldoCapital = Convert.ToDecimal(txtSaldoCapital.Text);
                objSiniestros.dFecIniCobertura = Convert.ToDateTime(tmpIniCobertura.Text);
                objSiniestros.dFecFinCobertura = Convert.ToDateTime(tmpFinCobertura.Text);
                objSiniestros.idEstadoSiniestro = Convert.ToInt32(cboEstadoSiniestro.SelectedValue);
                objSiniestros.dFechaSiniestro = Convert.ToDateTime(tmpFechaRegistro.Text);
                objSiniestros.idUsuReg = clsVarGlobal.PerfilUsu.idUsuario;
                objSiniestros.idUsuMod = clsVarGlobal.PerfilUsu.idUsuario;
                objSiniestros.dFecReg = clsVarGlobal.dFecSystem;
                objSiniestros.dFecMod = clsVarGlobal.dFecSystem;
                objSiniestros.lVigente = true;

                var result = objCNSiniestros.InsUpdSiniestros(objSiniestros);
                _nIdSeguroSiniestro = Convert.ToInt32(result.Rows[0]["nIdSeguroSiniestro"].ToString());

                if (!string.IsNullOrEmpty(result.Rows[0]["nIdSeguroSiniestro"].ToString()))
                {
                    MessageBox.Show("Se guardó correctamente el siniestro", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos(objSiniestros.idCli);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (cboSeguros.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar un seguro", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtNumCredito.Text))
            {
                MessageBox.Show("Debe ingresar un número de crédito", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(txtSaldoCapital.Text))
            {
                MessageBox.Show("Debe ingresar un saldo capital", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(tmpIniCobertura.Text))
            {
                MessageBox.Show("Debe ingresar una fecha de inicio de cobertura", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(tmpFinCobertura.Text))
            {
                MessageBox.Show("Debe ingresar una fecha de fin de cobertura", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cboEstadoSiniestro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado de siniestro", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void CargarDatosSiniestro(int idCli)
        {
            try
            {
                CargarDatos(idCli);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void conBusCli_ChangeDocumentoID(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
                    CargarDatosSiniestro(Convert.ToInt32(conBusCli.txtCodCli.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            conBusCli.limpiarControles();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar(bool limpiarComboSeguro = true)
        {
            if (limpiarComboSeguro)
            {
                cboSeguros.SelectedIndex = -1;
                cboSeguros.Enabled = true;
                dtgSiniestros.DataSource = null;
            }
            _nIdSeguroSiniestro = -1;
            _nIdAgencia = 0;
            tmpIniCobertura.Text = "";
            tmpFinCobertura.Text = "";
            txtRegion.Text = "";
            txtOficina.Text = "";
            txtNumCredito.Text = "";
            txtSaldoCapital.Text = "";
            tmpFechaRegistro.Text = "";
            cboEstadoSiniestro.SelectedIndex = -1;
            lblSeguroLibre.Visible = false;
            labelNumCred.Text = "Número de crédito:";
            tmpFechaRegistro.Enabled = true;
            lAdquiridoVentaLibre = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSeguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idSeguro = 0;
            if (cboSeguros.SelectedValue != null)
            {
                if (int.TryParse(cboSeguros.SelectedValue.ToString(), out idSeguro))
                {
                    idSeguro = (int)cboSeguros.SelectedValue;
                    cargarDatosSeguroIndividual(idSeguro);
                }
            }
        }

        private void cargarDatosSeguroIndividual(int idSeguro)
        {
            int idCli = Convert.ToInt32(conBusCli.txtCodCli.Text);

            DataTable dtSeguro = objCNSiniestros.CargarDatosSeguroIndividual(idSeguro, idCli);
            if (dtSeguro.Rows.Count > 0)
            {
                cboSeguros.SelectedValue = dtSeguro.Rows[0]["idTipoSeguro"].ToString();
                _nIdSeguro = Convert.ToInt32(dtSeguro.Rows[0]["idCreditoSeguro"].ToString());
                tmpIniCobertura.Text = dtSeguro.Rows[0]["dFechaInicioVigencia"].ToString();
                tmpFinCobertura.Text = dtSeguro.Rows[0]["dFechaFinVigencia"].ToString();
                txtRegion.Text = dtSeguro.Rows[0]["cZona"].ToString();
                txtOficina.Text = dtSeguro.Rows[0]["cAgencia"].ToString();
                _nIdAgencia = Convert.ToInt32(dtSeguro.Rows[0]["idAgencia"].ToString());
                txtNumCredito.Text = dtSeguro.Rows[0]["idCuenta"].ToString();
                txtSaldoCapital.Text = dtSeguro.Rows[0]["nSaldoCapitalNormal"].ToString();
                if (Convert.ToBoolean(dtSeguro.Rows[0]["lRecibo"]))
                {
                    lAdquiridoVentaLibre = true;
                    lblSeguroLibre.Visible = true;
                    labelNumCred.Text = "Número de crédito (RECIBO):";
                }
            }
            else
            {
                limpiar(false);
            }
        }

        private void dtgSiniestros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
                return;

            cargarDetalleSeguro(Convert.ToInt32(dtgSiniestros.Rows[e.RowIndex].Cells["nIdSeguroSiniestro"].Value));
        }

        private void cargarDetalleSeguro(int idSiniestro)
        {
            int idCli = Convert.ToInt32(conBusCli.txtCodCli.Text);

            DataTable dtSeguro = objCNSiniestros.CargarDetalleSiniestro(idSiniestro);
            if (dtSeguro.Rows.Count > 0)
            {
                _nIdSeguro = Convert.ToInt32(dtSeguro.Rows[0]["idSeguro"].ToString());
                _nIdSeguroSiniestro = Convert.ToInt32(dtSeguro.Rows[0]["nIdSeguroSiniestro"].ToString());
                reiniciarComboSeguros(dtSeguro);
                tmpIniCobertura.Text = dtSeguro.Rows[0]["dFecIniCobertura"].ToString();
                tmpFinCobertura.Text = dtSeguro.Rows[0]["dFecFinCobertura"].ToString();
                tmpFechaRegistro.Text = dtSeguro.Rows[0]["dFechaSiniestro"].ToString();
                txtRegion.Text = dtSeguro.Rows[0]["cZona"].ToString();
                txtOficina.Text = dtSeguro.Rows[0]["cAgencia"].ToString();
                txtNumCredito.Text = dtSeguro.Rows[0]["idCuenta"].ToString();
                txtSaldoCapital.Text = dtSeguro.Rows[0]["saldoCapital"].ToString();
                cboEstadoSiniestro.SelectedValue = dtSeguro.Rows[0]["idEstadoSiniestro"].ToString();
                tmpFechaRegistro.Enabled = false;
                tbcBase1.SelectedTab = tbcBase1.TabPages[0];
            }
        }

        private void reiniciarComboSeguros(DataTable dtSeguro)
        {
            cboSeguros.DataSource = null;
            cboSeguros.Items.Clear();
            DataTable dtSeguroTMP = new DataTable();
            dtSeguroTMP.Columns.Add("nTipoSeguro", typeof(int));
            dtSeguroTMP.Columns.Add("cTipoSeguro", typeof(string));
            cboSeguros.DataSource = dtSeguroTMP;
            cboSeguros.DisplayMember = "cTipoSeguro";
            cboSeguros.ValueMember = "nTipoSeguro";
            DataRow row = dtSeguroTMP.NewRow();
            row["nTipoSeguro"] = -1;
            row["cTipoSeguro"] = "NINGUNO";
            dtSeguroTMP.Rows.Add(row);
            row = dtSeguroTMP.NewRow();
            row["nTipoSeguro"] = Convert.ToInt16(dtSeguro.Rows[0]["nTipoSeguro"].ToString());
            row["cTipoSeguro"] = dtSeguro.Rows[0]["cTipoSeguro"].ToString();
            dtSeguroTMP.Rows.Add(row);
            cboSeguros.Enabled = false;
            cboSeguros.SelectedValue = dtSeguro.Rows[0]["nTipoSeguro"].ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtDatosSeguro = objCNSiniestros.RPTSiniestros_SP(conBusCli.idCli);

            if (dtDatosSeguro.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dtDatosSeguro", dtDatosSeguro));

            string reportpath = "rptSiniestros.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            //Invoco el método para cargar el detalle del siniestro
            if (dtgSiniestros.SelectedRows.Count > 0)
                cargarDetalleSeguro(Convert.ToInt32(dtgSiniestros.SelectedRows[0].Cells["nIdSeguroSiniestro"].Value));
            else
                MessageBox.Show("Debe seleccionar un siniestro", cFormName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}