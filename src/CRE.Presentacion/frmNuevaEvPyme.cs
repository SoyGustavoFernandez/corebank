using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CLI.CapaNegocio;
using CRE.CapaNegocio;
using GEN.Funciones;
using GEN.ControlesBase;
using EntityLayer;
using CRE.Presentacion;
using System.Linq;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmNuevaEvPyme : frmBase
    {
        public int idCli;
        public int idEvalCred;
        public int idSolicitud;
        public int idProducto;
        public string cNroDocumento;
        public string cNombreCliente;
        private string cMsjCaption;

        private clsEvalCred objEvalCred;
        private clsCNEvaluacion objCapaNegocio;
        private clsCreditoProp objCredSolicitado;
        private List<clsCreditoProp> listCredSolicitado;
        private List<clsTipEvalCred> listTipEvalCred;

        private List<clsDeudasEval> listRCCSaldosDirectos;
        private List<clsDeudasEval> listRCCSaldosIndirectos;
        private List<clsDeudasEval> listCRACSaldos;
        private List<clsDeudasEval> listEFinSaldos;
        private List<clsProductoTipEval> listProdTipEval;

        private decimal nMontoTotalMN;
        private decimal nMontoSolicitado;
        private bool lPorVinculacion;
        private bool lCheckFormSaldos = false;
        private bool lVinculado = false;
        private bool lCredEstacional = false;

        private string cTipoEvaluacion = "";
        private string cSectorEconomico = "";

        private bool lFueraRango = false;

        public string cNombreFormulario = "";
        clsCNSeleccionarDocEvalAnterior objCNCargaArchivoDocEval = new clsCNSeleccionarDocEvalAnterior();

        public frmNuevaEvPyme()
        {
            InitializeComponent();
        }

        public frmNuevaEvPyme(string cTipoEvalCre, string cSectorEcon, int idCli = 0, string cTituloForm = "frmNuevaEvPyme", bool _lPorVinculacion = false)
        {
            InitializeComponent();
            FormatearDataGridView();

            this.lPorVinculacion = _lPorVinculacion;
            this.conBusCli.BorderStyle = BorderStyle.None;

            this.idCli = idCli;
            this.idEvalCred = 0;
            this.cNroDocumento = "";
            this.cNombreCliente = "";
            this.cMsjCaption = "Registro de Evaluación de Crédito";
            this.nMontoTotalMN = 0;
            this.nMontoSolicitado = 9999999999;
            this.cTipoEvaluacion = cTipoEvalCre;
            this.cSectorEconomico = cSectorEcon;

            this.Text = cTituloForm;

            this.objCapaNegocio = new clsCNEvaluacion();
            this.objCredSolicitado = new clsCreditoProp();

            this.lCredEstacional = (Convert.ToString(clsVarApl.dicVarGen["cIDTipEvalPymeEstacional"]) == cTipoEvalCre) ? true : false;

            Habilitar(false);

            if (this.lPorVinculacion)
            {
                this.conBusCli.Enabled = false;
                //this.grbCredProp.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        #region Métodos Públicos
        public void InicializarValores(clsEvalCred objEvalCred)
        {
            this.objEvalCred = objEvalCred;
        }
        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgSolicitud.Margin = new System.Windows.Forms.Padding(0);
            this.dtgSolicitud.MultiSelect = false;
            this.dtgSolicitud.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgRefCliente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgSolicitud.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgRefCliente.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgSolicitud.RowHeadersVisible = false;
            this.dtgSolicitud.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitud.ReadOnly = true;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgSolicitud.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dtgSolicitud.Columns["idSolicitud"].DisplayIndex = 1;
            //this.dtgSolicitud.Columns["idEvalCred"].DisplayIndex = 2;
            this.dtgSolicitud.Columns["cProducto"].DisplayIndex = 3;
            this.dtgSolicitud.Columns["cOperacion"].DisplayIndex = 4;
            this.dtgSolicitud.Columns["cModalidadCredito"].DisplayIndex = 5;
            this.dtgSolicitud.Columns["cMoneda"].DisplayIndex = 6;
            this.dtgSolicitud.Columns["nMonto"].DisplayIndex = 7;

            this.dtgSolicitud.Columns["idSolicitud"].Visible = true;
            //this.dtgSolicitud.Columns["idEvalCred"].Visible = true;
            this.dtgSolicitud.Columns["cProducto"].Visible = true;
            this.dtgSolicitud.Columns["cOperacion"].Visible = true;
            this.dtgSolicitud.Columns["cModalidadCredito"].Visible = true;
            this.dtgSolicitud.Columns["cMoneda"].Visible = true;
            this.dtgSolicitud.Columns["nMonto"].Visible = true;

            this.dtgSolicitud.Columns["idSolicitud"].HeaderText = "Solicitud";
            //this.dtgSolicitud.Columns["idEvalCred"].HeaderText = "Evaluacion";
            this.dtgSolicitud.Columns["cProducto"].HeaderText = "Producto";
            this.dtgSolicitud.Columns["cOperacion"].HeaderText = "Operación";
            this.dtgSolicitud.Columns["cModalidadCredito"].HeaderText = "Modalidad Cred.";
            this.dtgSolicitud.Columns["cMoneda"].HeaderText = "Mda.";
            this.dtgSolicitud.Columns["nMonto"].HeaderText = "Monto sol.";

            this.dtgSolicitud.Columns["idSolicitud"].FillWeight = 60;
            //this.dtgSolicitud.Columns["idEvalCred"].FillWeight = 60;
            this.dtgSolicitud.Columns["cProducto"].FillWeight = 150;
            this.dtgSolicitud.Columns["cOperacion"].FillWeight = 100;
            this.dtgSolicitud.Columns["cModalidadCredito"].FillWeight = 100;
            this.dtgSolicitud.Columns["cMoneda"].FillWeight = 30;
            this.dtgSolicitud.Columns["nMonto"].FillWeight = 80;

            //this.dtgSolicitud.Columns["idSolicitud"].DefaultCellStyle.Format = "D8";
            //this.dtgSolicitud.Columns["idEvalCred"].DefaultCellStyle.Format = "D8";
            this.dtgSolicitud.Columns["nMonto"].DefaultCellStyle.Format = "N2";
        }

        private void SeleccionarTipoEvaluacion()
        {
            int idMonedaOrig = this.conCreditoTasa.idMoneda;
            decimal nSaldoConEntFinan = String.IsNullOrWhiteSpace(this.txtSaldoTotal.Text) ?  0 : Convert.ToDecimal(this.txtSaldoTotal.Text);
            decimal nSaldoCRACFinan = (listCRACSaldos == null) ? 0 : listCRACSaldos.Where(item => item.idTipoDeuda == 1).Sum(item => item.nSCapTotalMN);
            decimal nMontoSolicitadoMN = clsMathFinanciera.Convertir(idMonedaOrig, 1, this.conCreditoTasa.Monto(), Evaluacion.TipoCambio);
            decimal nSaldoConEntFinanMN = clsMathFinanciera.Convertir(idMonedaOrig, 1, nSaldoConEntFinan, Evaluacion.TipoCambio);
            decimal nSaldoCRACMN = clsMathFinanciera.Convertir(idMonedaOrig, 1, nSaldoCRACFinan, Evaluacion.TipoCambio);

            clsTipEvalCred objTipEvalCredFac = new clsTipEvalCred();
            objTipEvalCredFac = this.listTipEvalCred.FirstOrDefault(item => item.cTipEvalCred == "FACILITO PYME");
            int idTipEvalCredFac = (objTipEvalCredFac == null) ? 0 : objTipEvalCredFac.idTipEvalCred;
            int idTipEvalDef = 0;
            var lstTipEval = this.cTipoEvaluacion.Split(',').Select(Int32.Parse).ToList();
            idTipEvalDef = (lstTipEval.Count > 0) ? lstTipEval[0] : 0;

            if (idTipEvalDef == idTipEvalCredFac)
            {
                this.nMontoTotalMN = nMontoSolicitadoMN + nSaldoCRACMN;
            }
            else
            {
                this.nMontoTotalMN = nMontoSolicitadoMN + nSaldoConEntFinanMN;
            }

            foreach (clsTipEvalCred tec in this.listTipEvalCred)
            {
                if (this.nMontoTotalMN >= tec.nMinimo && this.nMontoTotalMN <= tec.nMaximo)
                {
                    this.cboTipoEvaluacion.SelectedValue = tec.idTipEvalCred;
                    return;
                }
            }

            this.lFueraRango = true;
            this.cboTipoEvaluacion.SelectedIndex = -1;
        }

        private void Habilitar(bool lHabilitado)
        {
            this.grbCredProp.Enabled = lHabilitado;

            this.btnGrabar.Enabled = lHabilitado;
            this.btnCancelar.Enabled = lHabilitado;
        }

        private void LimpiarForm()
        {
            this.conBusCli.limpiarControles();
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();

            this.cboTipoEvaluacion.SelectedIndex = -1;
            this.cboSectorEcon.SelectedIndex = -1;
            this.txtSaldoTotal.Text = "0";
            this.txtAniosActv.Text = "0";

            this.cboActividadInterna.SelectedIndex = -1;
            this.cboCIIU.SelectedIndex = -1;

            this.errorProvider.SetError(this.cboSectorEcon, String.Empty);
            this.errorProvider.SetError(this.txtAniosActv, String.Empty);
            this.errorProvider.SetError(this.txtSaldoTotal, String.Empty);
            this.errorProvider.SetError(this.cboActividadInterna, String.Empty);

            this.dtgSolicitud.DataSource = null;
            this.conCreditoTasa.LimpiarFormulario();

            this.lFueraRango = false;
        }

        private bool EsSectoEconValido()
        {
            if (this.cboSectorEcon.Enabled == true && (int)(this.cboSectorEcon.SelectedValue) == 999)
                return false;
            return true;
        }

        private bool EsAniosActvValido()
        {
            if (this.txtAniosActv.Enabled == true)
            {
                if (String.IsNullOrEmpty(this.txtAniosActv.Text) || Convert.ToInt32(this.txtAniosActv.Text) == 0)
                    return false;
            }
            return true;
        }

        private bool EsActInternaValido()
        {
            if (this.cboActividadInterna.SelectedIndex < 0) return false;
            return true;
        }

        private bool EsTipEvaluacionValido()
        {
            if (this.cboTipoEvaluacion.SelectedIndex < 0) return false;
            return true;
        }

        private clsMsjError ValidarGrabar()
        {
            clsMsjError objMsjError = new clsMsjError();

            this.errorProvider.SetError(this.cboSectorEcon, String.Empty);
            this.errorProvider.SetError(this.txtAniosActv, String.Empty);
            this.errorProvider.SetError(this.txtSaldoTotal, String.Empty);
            this.errorProvider.SetError(this.cboActividadInterna, String.Empty);

            var objCreditoTasaMsjError = this.conCreditoTasa.Validar();

            if (objCreditoTasaMsjError.HasErrors)
            {
                foreach (var err in objCreditoTasaMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            int idProducto = this.conCreditoTasa.ObtenerIdProducto();

            if (!EsValidoProducto(idProducto))
            {
                objMsjError.AddError("El producto no es valido para esta evaluación.");
            }

            if (!EsSectoEconValido())
            {
                objMsjError.AddError("Sector Econ.: Seleccione una opción.");
                this.errorProvider.SetError(this.cboSectorEcon, "Seleccione el Sector Económico.");
            }

            if (!EsActInternaValido())
            {
                objMsjError.AddError("Actividad Interna: Seleccione una opción.");
                this.errorProvider.SetError(this.cboActividadInterna, "Seleccione una opción de la Actividad Interna.");
            }

            if (!EsAniosActvValido())
            {
                objMsjError.AddError("Años Actividad: Ingrese un valor distinto a CERO.");
                this.errorProvider.SetError(this.txtAniosActv, "Ingrese los años de actividad.");
            }

            if (!this.lCheckFormSaldos)
            {
                objMsjError.AddError("Saldo de Deudas: Verifique los saldos con Entidades Financieras.");
                this.errorProvider.SetError(this.txtSaldoTotal, "Verifique Saldos de Deudas con Entidades Financieras.");
            }

            if(this.lFueraRango && !EsTipEvaluacionValido())
            {
                objMsjError.AddError("Tipo Evaluación: Verifique el Tipo de Evaluación.");
                this.errorProvider.SetError(this.cboTipoEvaluacion, "Verifique que Saldos de Deudas este dentro del rango permitido para Tipo de Evaluación");
            }

            /*if (this.lPorVinculacion == true && this.objEvalCred != null)
            {
                if (this.objEvalCred.idTipEvalCred != Convert.ToInt32(this.cboTipoEvaluacion.SelectedValue))
                {
                    objMsjError.AddError("Tipo de Evaluacion: Los tipos de evaluación son distinto.");
                    //this.errorProvider.SetError(this.cboTipoEvaluacion, "Verifique Saldos de Deudas con Entidades Financieras.");
                }
            }*/

            return objMsjError;
        }

        private clsMsjError ValidarVinculacionConSolicitud(int idProducto, int idEvalCred)
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsValidoProducto(idProducto))
            {
                objMsjError.AddError("El producto no es valido para esta evaluación.");
            }

            if (EstaVinculado(idEvalCred))
            {
                objMsjError.AddError("La solicitud ya está vinculado con la Evaluación Nº " + idEvalCred.ToString("D6") + ".");
            }

            return objMsjError;
        }

        private string EvalCredEnXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idTipEvalCred", typeof(int));
            dt.Columns.Add("idCli", typeof(int));
            dt.Columns.Add("idSolicitud", typeof(int));
            dt.Columns.Add("idUsuReg", typeof(int));
            dt.Columns.Add("idAgencia", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("dFecReg", typeof(DateTime));
            dt.Columns.Add("nCapitalPropuesto", typeof(decimal));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nCuotas", typeof(int));
            dt.Columns.Add("idTipoPeriodo", typeof(int));
            dt.Columns.Add("nPlazoCuota", typeof(int));
            dt.Columns.Add("nDiasGracia", typeof(int));
            dt.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dt.Columns.Add("idTasa", typeof(int));
            dt.Columns.Add("nTEA", typeof(decimal));
            dt.Columns.Add("nTEM", typeof(decimal));
            dt.Columns.Add("idActividad", typeof(int));
            dt.Columns.Add("idSectorEcon", typeof(int));
            dt.Columns.Add("idActividadInternaPri", typeof(int));
            dt.Columns.Add("nActPriAnios", typeof(int));
            dt.Columns.Add("nTotalDeudas", typeof(decimal));
            dt.Columns.Add("nPlazo", typeof(int));
            dt.Columns.Add("nCuotasGracia", typeof(int));
            dt.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dt.Columns.Add("cCalendarioPagos", typeof(string));
            dt.Columns.Add("nTotalMontoPagar", typeof(decimal));

            DataRow row = dt.NewRow();

            row["idTipEvalCred"] = this.cboTipoEvaluacion.SelectedValue;
            row["idCli"] = this.idCli;
            row["idSolicitud"] = this.objCredSolicitado.idSolicitud;
            row["idUsuReg"] = clsVarGlobal.User.idUsuario;
            row["idAgencia"] = clsVarGlobal.nIdAgencia;
            row["idProducto"] = this.objCredSolicitado.idProducto;
            row["dFecReg"] = clsVarGlobal.dFecSystem;
            row["nCapitalPropuesto"] = this.objCredSolicitado.nMonto;
            row["idMoneda"] = this.objCredSolicitado.idMoneda;
            row["nCuotas"] = this.objCredSolicitado.nCuotas;
            row["idTipoPeriodo"] = this.objCredSolicitado.idTipoPeriodo;
            row["nPlazoCuota"] = this.objCredSolicitado.nPlazoCuota;
            row["nDiasGracia"] = this.objCredSolicitado.nDiasGracia;
            row["dFechaDesembolso"] = this.objCredSolicitado.dFechaDesembolso;
            row["idTasa"] = this.objCredSolicitado.idTasa;
            row["nTEA"] = this.objCredSolicitado.nTea;
            row["nTEM"] = this.objCredSolicitado.nTem;
            row["idActividad"] = this.cboCIIU.SelectedValue;
            row["idSectorEcon"] = this.cboSectorEcon.SelectedValue;
            row["idActividadInternaPri"] = this.cboActividadInterna.SelectedValue;
            row["nActPriAnios"] = Convert.ToInt32(this.txtAniosActv.Text);
            row["nTotalDeudas"] = Convert.ToDecimal(this.txtSaldoTotal.Text);
            row["nPlazo"] = this.objCredSolicitado.nPlazo;
            row["nCuotasGracia"] = this.objCredSolicitado.nCuotasGracia;
            row["nCuotaGraciaAprox"] = this.objCredSolicitado.nCuotaGraciaAprox;
            row["cCalendarioPagos"] = this.objCredSolicitado.cCalendarioPagos;
            row["nTotalMontoPagar"] = this.objCredSolicitado.nTotalMontoPagar;

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private void BuscarCliente(int idCli)
        {
            if (idCli != 0)
            {
                #region Cargar Datos de BD
                DataSet ds = this.objCapaNegocio.BuscarSolicitudesPorCliente(idCli, clsVarGlobal.User.idUsuario, this.cTipoEvaluacion, this.cSectorEconomico);

                //-- Valida creditos pyme estacionales
                if (ds.Tables[1].Rows.Count > 0)
                {
                    var credSolicitado = DataTableToList.ConvertTo<clsCreditoProp>(ds.Tables[1]) as List<clsCreditoProp>;
                    if (credSolicitado[0].idModalidadCredito == 3 && !this.lCredEstacional)
                        ds.Tables[1].Clear();
                    else if (credSolicitado[0].idModalidadCredito != 3 && this.lCredEstacional)
                        ds.Tables[1].Clear();
                }

                if (ds.Tables[1].Rows.Count <= 0)
                {
                    MessageBox.Show("¡No se ha encontrado ninguna solicitud enviada para este tipo de evaluación!",
                        "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCancelar.Enabled = true;
                    return;
                }

                //-- Table[0] : Variables Globales
                DataTable tdVarGlobales = ds.Tables[0];
                Evaluacion.TipoCambio = Convert.ToDecimal(tdVarGlobales.Rows[0]["nTipoCambio"]);

                //-- Table[1] : Solicitud de Crédito
                this.listCredSolicitado = DataTableToList.ConvertTo<clsCreditoProp>(ds.Tables[1]) as List<clsCreditoProp>;

                //-- Table[2] : Tipos de Evaluación
                this.listTipEvalCred = DataTableToList.ConvertTo<clsTipEvalCred>(ds.Tables[2]) as List<clsTipEvalCred>;

                //-- Table[3] : Sectores Economicos
                DataTable dtSectorEconomico = ds.Tables[3];

                //-- Table[4] : Tipos de productos por tipos de evaluación
                this.listProdTipEval = DataTableToList.ConvertTo<clsProductoTipEval>(ds.Tables[4]) as List<clsProductoTipEval>;
                #endregion

                #region Asignar datos a los controles
                this.cNroDocumento = this.conBusCli.txtNroDoc.Text;
                this.cNombreCliente = this.conBusCli.txtNombre.Text;
                this.txtAniosActv.Text = this.conBusCli.nAniosActEco.ToString();
                if (this.conBusCli.nAniosActEco <= 0)
                {
                    MessageBox.Show("Años de Actividad debe ser mayor que CERO." +
                        "* Solucione este problema revisando la Fecha de Inicio de Actividad Económica en el formulario de Registro de Clientes.", "AÑOS DE ACTIVIDAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                this.dtgSolicitud.DataSource = this.listCredSolicitado;
                FormatearColumnasDataGridView();

                this.cboTipoEvaluacion.DisplayMember = "cTipEvalCred";
                this.cboTipoEvaluacion.ValueMember = "idTipEvalCred";
                this.cboTipoEvaluacion.DataSource = this.listTipEvalCred;

                if (ValidaCreditoEstamosContigo(this.listCredSolicitado))
                {
                    string cSecEcoCredEstCont = clsVarApl.dicVarGen["cIDsSectorEconCredEstCon"];
                    var dtSecEcoCredEstCont = new clsCNActividadInternaConfig().CNRecuperarSectorEconomico(cSecEcoCredEstCont);
                    dtSectorEconomico = dtSecEcoCredEstCont;
                }

                DataRow row = dtSectorEconomico.NewRow();
                row["idSectorEcon"] = 999;
                row["cDescripcion"] = "--Seleccione--";
                row["nCodigo"] = 0;
                dtSectorEconomico.Rows.InsertAt(row, 0);

                this.cboSectorEcon.DisplayMember = "cDescripcion";
                this.cboSectorEcon.ValueMember = "idSectorEcon";
                this.cboSectorEcon.DataSource = dtSectorEconomico;
                #endregion

                if (this.listCredSolicitado.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Desea Vincular la Solicitud Nº " + this.listCredSolicitado[0].idSolicitud + " con la Evaluación.",
                        "Vinculación de Solicitud", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        VincularSolicitud();
                    }
                }
                else
                {
                    this.conCreditoTasa.LimpiarFormulario();
                }

                this.cboSectorEcon.SelectedIndex = 0;
                this.txtSaldoTotal.Text = "0";

                this.btnVincular.Enabled = (this.listCredSolicitado.Count == 0 || this.lVinculado == true) ? false : true;
                this.conCreditoTasa.MonedaEnabled = true;
                this.conCreditoTasa.NivelesProductoEnabled = true;

                this.dtgSolicitud.Focus();
                this.cboActividadInterna_SelectedIndexChanged(null, null);

                if (this.lPorVinculacion == false)
                {
                    Habilitar(true);
                }
            }

        }

        private bool ValidaCreditoEstamosContigo(List<clsCreditoProp> listCredSolicitado)
        {
            if (listCredSolicitado.Count <= 0)
                return false;

            if (Convert.ToInt32(this.cTipoEvaluacion) != Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredJornal"]))
                return false;

            int idSubProducto = listCredSolicitado[0].idProducto;

            string cProductosEstamosContigo = clsVarApl.dicVarGen["nSubProductoCamEstCon"];
            String[] cProdCampania = cProductosEstamosContigo.Split(',');
            int[] nProdCampania = Array.ConvertAll<string, int>(cProdCampania, int.Parse);

            if (nProdCampania.Contains(idSubProducto))
                return true;
            else
                return false;
        }

        private void VincularSolicitud()
        {
            if (this.dtgSolicitud.RowCount > 0)
            {
                this.conCreditoTasa.LimpiarFormulario();

                this.errorProvider.SetError(this.cboSectorEcon, String.Empty);
                this.errorProvider.SetError(this.txtAniosActv, String.Empty);
                this.errorProvider.SetError(this.txtSaldoTotal, String.Empty);
                this.errorProvider.SetError(this.cboActividadInterna, String.Empty);

                int rowIndex = this.dtgSolicitud.SelectedCells[0].RowIndex;
                this.objCredSolicitado = this.listCredSolicitado[rowIndex];

                var objMsjError = ValidarVinculacionConSolicitud(this.objCredSolicitado.idProducto, this.objCredSolicitado.idEvalCred);

                if (objMsjError.HasErrors)
                {
                    string cMsj = "No se puede vincular por las siguientes razones: \n\n" + objMsjError.GetErrors();
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.nMontoSolicitado = this.objCredSolicitado.nMonto;

                this.conCreditoTasa.AsignarDatos(new clsCreditoProp()
                {
                    idSolicitud = this.objCredSolicitado.idSolicitud,
                    idMoneda = this.objCredSolicitado.idMoneda,
                    nMonto = this.objCredSolicitado.nMonto,
                    nCuotas = this.objCredSolicitado.nCuotas,
                    idTipoPeriodo = this.objCredSolicitado.idTipoPeriodo,
                    nPlazoCuota = this.objCredSolicitado.nPlazoCuota,
                    nDiasGracia = this.objCredSolicitado.nDiasGracia,
                    dFechaDesembolso = this.objCredSolicitado.dFechaDesembolso,
                    idProducto = this.objCredSolicitado.idProducto,
                    idTasa = this.objCredSolicitado.idTasa,
                    nTasaCompensatoria = this.objCredSolicitado.nTasaCompensatoria,
                    nCuotasGracia = this.objCredSolicitado.nCuotasGracia,
                    idAgencia = clsVarGlobal.nIdAgencia,
                    idClasificacionInterna = this.objCredSolicitado.idClasificacionInterna
                });

                this.cboActividadInterna.SelectedValue = this.objCredSolicitado.idActividadInterna;

                if (this.objCredSolicitado.idActividadInterna > 0)
                    this.cboActividadInterna.Enabled = false;
                else
                    this.cboActividadInterna.Enabled = true;

                this.conCreditoTasa.Enabled = false;
                this.btnVincular.Enabled = false;

                SeleccionarTipoEvaluacion();

                if (this.lPorVinculacion == true)
                {
                    Habilitar(false);
                    this.btnGrabar.Enabled = true;
                }
                else
                {
                    Habilitar(true);
                }

                this.lVinculado = true;

                conCreditoTasa_ChangeMoneda(null, null);
            }
        }
        #endregion

        #region Eventos
        private void FrmNuevaEvPyme_Shown(object sender, EventArgs e)
        {
            this.conBusCli.Select();
            this.conBusCli.txtCodCli.Focus();

            if (this.lPorVinculacion == true && idCli != 0 && this.objEvalCred != null)
            {
                // Cargamos los datos del cliente
                this.conBusCli.CargardatosCli(idCli);

                // Buscar al cliente 
                BuscarCliente(this.idCli);

                this.cboActividadInterna.SelectedValue = this.objEvalCred.idActividadInternaPri;
                this.cboSectorEcon.SelectedValue = this.objEvalCred.idSectorEcon;
                this.txtAniosActv.Text = this.objEvalCred.nActPriAnios.ToString("n0");
                this.txtSaldoTotal.Text = this.objEvalCred.nTotalDeudas.ToString("N2");
                this.lCheckFormSaldos = true;
            }
        }

        private void FrmNuevaEvPyme_Load(object sender, EventArgs e)
        {
            this.conBusCli.Select();
            this.conBusCli.txtCodCli.Focus();
            this.conCreditoTasa.lMostrarTodosNivCred = true;
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            this.idCli = this.conBusCli.idCli;
            BuscarCliente(this.idCli);
        }

        private void dtgSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnVincular.PerformClick();

            e.Handled = true;
        }

        private void cboActividadInterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadInterna.SelectedIndex >= 0)
            {
                if (this.cboActividadInterna.Items.Count > 0)
                {
                    var drActividadInterna = (DataRowView)cboActividadInterna.SelectedItem;
                    int idActividad = Convert.ToInt32(drActividadInterna["idActividad"]);
                    int idActividadInterna = Convert.ToInt32(drActividadInterna["idActividadInterna"]);

                    clsCNListaActivEco cnactividad = new clsCNListaActivEco();
                    DataTable dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);

                    if (dtActividad.Rows.Count > 0)
                    {
                        int idPadreActividad = Convert.ToInt32(dtActividad.Rows[0]["idPadreActividad"]);

                        this.cboCIIU.CargarActivEconomica(idPadreActividad);
                        //this.objCredSolicitado.idActividadInterna = idActividadInterna;
                        //this.objCredSolicitado.idActividad = idActividad;
                    }
                }
            }
        }

        private void txtDeudaSF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarTipoEvaluacion();
            }
        }

        private void txtDeudaSF_Leave(object sender, EventArgs e)
        {
            SeleccionarTipoEvaluacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarForm();
            this.Habilitar(false);
        }

        private string SaldosEnXML(List<clsDeudasEval> listDeudas)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("idDeudasEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idTipoDeuda", typeof(int));
            dt.Columns.Add("idDeudaCA", typeof(int));
            dt.Columns.Add("cCodigoEmpresa", typeof(string));
            dt.Columns.Add("cNombreEmpresa", typeof(string));
            dt.Columns.Add("idCuenta", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nMontoAprobado", typeof(decimal));
            dt.Columns.Add("nCuotasPag", typeof(int));
            dt.Columns.Add("nCuotasPen", typeof(int));
            dt.Columns.Add("nCuotasTotal", typeof(int));
            dt.Columns.Add("nSCapTotalSis", typeof(decimal));
            dt.Columns.Add("nSCapTotal", typeof(decimal));
            dt.Columns.Add("nSCapCortoPlz", typeof(decimal));
            dt.Columns.Add("nSCapLargoPlz", typeof(decimal));
            dt.Columns.Add("nMontoCuota", typeof(decimal));
            dt.Columns.Add("cCronograma", typeof(string));
            dt.Columns.Add("dFechaConsulta", typeof(DateTime));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("lAutomatico", typeof(bool));
            dt.Columns.Add("idTipoCredito", typeof(int));

            dt.Columns.Add("lUtilizada", typeof(bool));
            dt.Columns.Add("idTipoInterv", typeof(int));

            foreach (var deuda in listDeudas)
            {
                DataRow row = dt.NewRow();

                //newCustomersRow["idDeudasEval"] = rcc.idDeudasEval;
                //newCustomersRow["idEvalCred"] = rcc.idEvalCred;
                row["idTipoDeuda"] = deuda.idTipoDeuda;
                row["idDeudaCA"] = deuda.idDeudaCA; //false
                row["cCodigoEmpresa"] = deuda.cCodigoEmpresa;
                row["cNombreEmpresa"] = deuda.cNombreEmpresa;
                row["idCuenta"] = deuda.idCuenta;
                row["idProducto"] = deuda.idProducto;
                row["idMoneda"] = deuda.idMoneda;
                row["nMontoAprobado"] = deuda.nMontoAprobado;
                row["nCuotasPag"] = deuda.nCuotasPag;
                row["nCuotasPen"] = deuda.nCuotasPen;
                row["nCuotasTotal"] = deuda.nCuotasTotal;
                row["nSCapTotalSis"] = deuda.nSCapTotalSis;
                row["nSCapTotal"] = deuda.nSCapTotal;
                row["nSCapCortoPlz"] = deuda.nSCapCortoPlz;
                row["nSCapLargoPlz"] = deuda.nSCapLargoPlz;
                row["nMontoCuota"] = deuda.nMontoCuota;
                row["cCronograma"] = deuda.cCronograma;
                row["dFechaConsulta"] = deuda.dFechaConsulta;
                row["idMonedaMA"] = this.objCredSolicitado.idMoneda;
                row["lAutomatico"] = deuda.lAutomatico;
                row["idTipoCredito"] = deuda.idTipoCredito;

                row["lUtilizada"] = deuda.lUtilizada;
                row["idTipoInterv"] = deuda.idTipoInterv;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DeudasEval", "Item");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            clsMsjError objMsjError = ValidarGrabar();

            if (objMsjError.HasErrors)
            {
                MessageBox.Show(objMsjError.GetErrors(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            this.objCredSolicitado.idMoneda = oEvalCredTemp.idMoneda;
            this.objCredSolicitado.nMonto = oEvalCredTemp.nMonto;
            this.objCredSolicitado.nCuotas = oEvalCredTemp.nCuotas;
            this.objCredSolicitado.idTipoPeriodo = oEvalCredTemp.idTipoPeriodo;
            this.objCredSolicitado.nPlazoCuota = oEvalCredTemp.nPlazoCuota;
            this.objCredSolicitado.nDiasGracia = oEvalCredTemp.nDiasGracia;
            this.objCredSolicitado.dFechaDesembolso = oEvalCredTemp.dFechaDesembolso;
            this.objCredSolicitado.idProducto = oEvalCredTemp.idProducto;
            this.objCredSolicitado.idTasa = oEvalCredTemp.idTasa;
            this.objCredSolicitado.nTasaCompensatoria = oEvalCredTemp.nTasaCompensatoria;

            this.objCredSolicitado.nPlazo = oEvalCredTemp.nPlazo;
            this.objCredSolicitado.nCuotasGracia = oEvalCredTemp.nCuotasGracia;
            this.objCredSolicitado.nCuotaGraciaAprox = oEvalCredTemp.nCuotaGraciaAprox;
            this.objCredSolicitado.cCalendarioPagos = oEvalCredTemp.cCalendarioPagos;
            this.objCredSolicitado.nTotalMontoPagar = oEvalCredTemp.nTotalMontoPagar;

            if (dtgSolicitud.Rows.Count > 0 && objCredSolicitado.idSolicitud == 0)
            {
                DialogResult dr = MessageBox.Show("Aun no se tiene vinculado la Solicitud con la Evaluacion.¿Esta seguro de continuar?", this.cMsjCaption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.No) return;
            }

            if (this.lPorVinculacion == false)
            {
                #region Saldos con entidades financieras
                List<clsDeudasEval> objSaldosDeudas = new List<clsDeudasEval>();
                foreach (clsDeudasEval saldos in this.listRCCSaldosDirectos)
                {
                    saldos.nCuotasPag = 0;
                    saldos.nCuotasPen = 0;
                    saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                    saldos.nSCapLargoPlz = 0;
                    saldos.nMontoCuota = 0;
                    //saldos.dFechaConsulta = "";
                    saldos.lAutomatico = true;
                    //saldos.idTipoCredito = 0;

                    objSaldosDeudas.Add(saldos);
                }

                foreach (clsDeudasEval saldos in this.listRCCSaldosIndirectos)
                {
                    saldos.nCuotasPag = 0;
                    saldos.nCuotasPen = 0;
                    saldos.nSCapCortoPlz = 0;
                    saldos.nSCapLargoPlz = saldos.nSCapTotalSis;
                    saldos.nMontoCuota = 0;
                    //saldos.dFechaConsulta = "";
                    saldos.lAutomatico = true;
                    //saldos.idTipoCredito = 0;

                    objSaldosDeudas.Add(saldos);
                }

                foreach (clsDeudasEval saldos in this.listCRACSaldos)
                {
                    //saldos.nCuotasPag       = 0;
                    //saldos.nCuotasPen       = 0;
                    if (saldos.idTipoDeuda == TipoDeuda.Directo)
                    {
                        saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                        saldos.nSCapLargoPlz = decimal.Zero;
                    }
                    else
                    {
                        saldos.nSCapCortoPlz = decimal.Zero;
                        saldos.nSCapLargoPlz = saldos.nSCapTotalSis;
                    }
                    //saldos.nMontoCuota      = 0;
                    saldos.dFechaConsulta = clsVarGlobal.dFecSystem; ;
                    saldos.lAutomatico = true;
                    saldos.idTipoCredito = 4;

                    objSaldosDeudas.Add(saldos);
                }

                foreach (clsDeudasEval saldos in this.listEFinSaldos)
                {
                    if (saldos.nSCapTotal > 0)
                    {
                        saldos.idDeudasEval = 0;
                        saldos.idTipoDeuda = 1;
                        saldos.idCuenta = 0;
                        saldos.idProducto = 0;
                        //saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                        saldos.nSCapLargoPlz = 0;
                        //saldos.nMontoCuota      = 0;
                        saldos.dFechaConsulta = clsVarGlobal.dFecSystem;
                        saldos.lAutomatico = false;
                        saldos.idTipoCredito = 0;

                        objSaldosDeudas.Add(saldos);
                    }
                }
                #endregion

                string xmlEvalCred = EvalCredEnXML();
                string xmlSaldosDeudas = SaldosEnXML(objSaldosDeudas);

                DataTable td = this.objCapaNegocio.GrabarNuevaEvalCred(xmlEvalCred, xmlSaldosDeudas, clsVarGlobal.User.idEstablecimiento);
                if (td.Rows.Count > 0)
                {
                    if (td.Rows[0]["idMsje"].ToString().Equals("0"))
                    {
                        MessageBox.Show(td.Rows[0]["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.idEvalCred = Convert.ToInt32(td.Rows[0]["idEvalCred"]);

                        #region ValidarPDS
                        DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(this.objCredSolicitado.idSolicitud);
                        if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                        {
                            MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion

                        #region Evaluación Remota-Presencial
                        ValidarVisitaPresencialRemota();
                        #endregion
                        this.Close();
                    }
                }
            }
            else
            {
                SeleccionarTipoEvaluacion();

                if (this.objEvalCred.idMoneda != this.objCredSolicitado.idMoneda)
                {
                    MessageBox.Show("No se puede vincular por tener Monedas distintas en Solicitud y Evaluación.", this.cMsjCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.objEvalCred.idTipEvalCred != Convert.ToInt32(this.cboTipoEvaluacion.SelectedValue))
                {
                    MessageBox.Show("No se puede vincular por tener distinto formatos de Evaluación. Revise el Monto de la Solicitud.", this.cMsjCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string xmlEvalCred = EvalCredEnXML();

                DataTable td = this.objCapaNegocio.VincularEvalCred(this.objEvalCred.idEvalCred, xmlEvalCred, clsVarGlobal.User.idEstablecimiento);
                if (td.Rows.Count > 0)
                {
                    if (td.Rows[0]["idMsje"].ToString().Equals("0"))
                    {
                        MessageBox.Show(td.Rows[0]["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.idEvalCred = Convert.ToInt32(td.Rows[0]["idEvalCred"]);
                        this.idSolicitud = Convert.ToInt32(td.Rows[0]["idSolicitud"]);
                        this.idProducto = Convert.ToInt32(td.Rows[0]["idProducto"]);
                    }
                    else
                    {
                        this.idProducto = this.objEvalCred.idProducto;
                        this.idSolicitud = 0;
                    }

                    this.Close();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.conCreditoTasa.idMoneda > 0)
            {
                this.btnAgregar.Enabled = false;

                DataRowView dr = this.conCreditoTasa.MonedaItem;

                Cursor.Current = Cursors.WaitCursor;

                frmSaldoDeudasFinanc saldoDeudasFinanc = new frmSaldoDeudasFinanc();
                saldoDeudasFinanc.AsignarDataTable(Evaluacion.DataTableMoneda);
                saldoDeudasFinanc.AsignarDatos(this.cNroDocumento, this.cNombreCliente,
                    Evaluacion.TipoCambio, this.conCreditoTasa.idMoneda, dr["cSimbolo"].ToString(),
                    this.listCredSolicitado[0].idSolicitud);

                Cursor.Current = Cursors.Default;
                saldoDeudasFinanc.ShowDialog();

                this.txtSaldoTotal.Text = saldoDeudasFinanc.ObtenerSaldoTotal().ToString("n2");
                this.lCheckFormSaldos = true;
                this.btnAgregar.Enabled = true;

                this.listRCCSaldosDirectos = saldoDeudasFinanc.ObtenerRCCSaldosDirectos();
                this.listRCCSaldosIndirectos = saldoDeudasFinanc.ObtenerRCCSaldosIndirectos();
                this.listCRACSaldos = saldoDeudasFinanc.ObtenerCRACSaldos();
                this.listEFinSaldos = saldoDeudasFinanc.ObtenerEFinSaldos();

                saldoDeudasFinanc.Close();
                saldoDeudasFinanc.Dispose();

                txtSaldoTotal_Validated(null, null);

                SeleccionarTipoEvaluacion();
            }
            else
            {
                MessageBox.Show("Moneda no definida", "Nueva Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtAniosActv_Validated(object sender, EventArgs e)
        {
            if (this.txtAniosActv.Enabled == true && !EsAniosActvValido())
            {
                this.errorProvider.SetError(this.txtAniosActv, "Ingrese un valor mayor a CERO.");
            }
            else
            {
                this.errorProvider.SetError(this.txtAniosActv, String.Empty);
            }
        }

        private void cboSectorEcon_Validated(object sender, EventArgs e)
        {
            if (this.cboSectorEcon.Enabled == true && !EsSectoEconValido())
            {
                this.errorProvider.SetError(this.cboSectorEcon, "Seleccione una opción de la lista.");
            }
            else
            {
                this.errorProvider.SetError(this.cboSectorEcon, String.Empty);
            }
        }

        private void txtSaldoTotal_Validated(object sender, EventArgs e)
        {
            if (!this.lCheckFormSaldos)
            {
                this.errorProvider.SetError(this.txtSaldoTotal, "Verifique los saldos con Entidades Financieras.");
            }
            else
            {
                this.errorProvider.SetError(this.txtSaldoTotal, String.Empty);
            }
        }

        private void cboActividadInterna_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.cboActividadInterna.Enabled == true && !EsActInternaValido())
            {
                this.errorProvider.SetError(this.cboActividadInterna, "Seleccione una Actividad Económica");
            }
            else
            {
                this.errorProvider.SetError(this.cboActividadInterna, String.Empty);
            }
        }

        private bool EsValidoProducto(int idProducto)
        {
            clsProductoTipEval objProductoTipEval = this.listProdTipEval.Find(x => x.idProducto == idProducto);

            if (objProductoTipEval == null) return false;
            else return true;
        }

        private bool EstaVinculado(int idEvalCred)
        {
            if (idEvalCred > 0) return true;
            return false;
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            VincularSolicitud();
        }

        private void conCreditoTasa_ChangeMonto(object sender, EventArgs e)
        {
            SeleccionarTipoEvaluacion();
        }

        private void conCreditoTasa_ChangeMoneda(object sender, EventArgs e)
        {
            this.cboMoneda.SelectedValue = this.conCreditoTasa.idMoneda;
            this.txtSaldoTotal.Text = "0";
            this.lCheckFormSaldos = false;
        }

        #region Evaluacion Presencial-remota
        private void ValidarVisitaPresencialRemota()
        {
            List<Tuple<int, string>> listTiposEvaluacionPresencialRemota = new List<Tuple<int, string>>();

            DataTable dtTipoEvaluacion = objCNCargaArchivoDocEval.CNListaTipoEvaluacion();

            foreach (DataRow row in dtTipoEvaluacion.Rows)
            {
                int idTipEvalConfig = Convert.ToInt32(row["idTipEvalConfig"]);
                DataTable dtRespuestaEvalPreRem = ArmarTablaParametrosEvalPreRemo(idTipEvalConfig);
                string cCumpleReglas = new clsCNValidaReglaConfig().ValidarReglasConfig(dtRespuestaEvalPreRem, this.cNombreFormulario, idTipEvalConfig);

                if (cCumpleReglas == "OK")
                {
                    string cTipEvalConfig = row["cTipEvalConfig"].ToString();
                    Tuple<int, string> listTipoEvaluacionTuple = new Tuple<int, string>(idTipEvalConfig, cTipEvalConfig);

                    if (idTipEvalConfig == 3)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                    else if (idTipEvalConfig == 2 )
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                }
            }

            if (listTiposEvaluacionPresencialRemota.Count > 0)
            {
                RecuperarDocEvalAnterior(listTiposEvaluacionPresencialRemota);
            }
            else
            {
                MessageBox.Show("No cumple con las reglas de validación para una solicitud anterior.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable ArmarTablaParametrosEvalPreRemo(int idTipEvalConfig)
        {
            DataTable dtTablaParametrosEval = new DataTable();
            dtTablaParametrosEval.Columns.Add("cNombreCampo");
            dtTablaParametrosEval.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametrosEval.NewRow();

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.idCli;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idTipEvalConfig";
            drfila[1] = idTipEvalConfig;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "nMontoSol";
            drfila[1] = this.objCredSolicitado.nMonto;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "cIdTipEvalCred";
            drfila[1] = this.cTipoEvaluacion;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametrosEval.Rows.Add(drfila);

            return dtTablaParametrosEval;
        }

        private void RecuperarDocEvalAnterior(List<Tuple<int, string>> listTiposEvaluacion)
        {
            int idTipEvalConfig = listTiposEvaluacion[0].Item1;
            int idSolicitudAnterior = 0;
            int idSolicitud = this.objCredSolicitado.idSolicitud;
            string cIdTipEvalCred = this.cTipoEvaluacion;
            int idEvalCredAnterior = 0;
            int idTipEvalConfigRespuesta = 0;
            
            DataTable dtSolicitudEvalAnterior = objCNCargaArchivoDocEval.CNRecuperaSolicitudAnterior(this.idCli, Convert.ToDateTime(Evaluacion.FechaActualEval), cIdTipEvalCred, idTipEvalConfig);
            
            if (Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]) == 0)
            {
                MessageBox.Show("La validación de las reglas remota y presencial ha fallado.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (dtSolicitudEvalAnterior.Rows.Count > 0)
            {
                idSolicitudAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]);

                frmSeleccionarDocEvalAnterior frmSeleccionarDoc = new frmSeleccionarDocEvalAnterior(idSolicitudAnterior, idSolicitud, listTiposEvaluacion);
                frmSeleccionarDoc.ShowDialog();
                idTipEvalConfigRespuesta = frmSeleccionarDoc.idTipEvalConfig;
                frmSeleccionarDoc.Dispose();
                
                idEvalCredAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idEvalCred"]);
                ActualizaInformacionEvaluacion(this.idEvalCred, idEvalCredAnterior, idTipEvalConfigRespuesta, cIdTipEvalCred);
           }
        }

        public void RecuperarNombreFormulario(string cNombreFormulario)
        {
            this.cNombreFormulario = cNombreFormulario;
        }

        private void ActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            DataTable dt = objCNCargaArchivoDocEval.CNActualizaInformacionEvaluacion(idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #endregion

    }
}