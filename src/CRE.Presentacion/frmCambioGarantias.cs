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
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using System.Xml.Linq;

namespace CRE.Presentacion
{
    public partial class frmCambioGarantias : frmBase
    {
        #region Variables

        private clsListDetGarantia _lstDetGarSolicitud;
        private clsCNSolicitud _objCNSolicitud;
        private clsCNGarantia _objCNGarantia;
        private clsCNCartaFianza _objCNCartaFianza;
        private clsCNValidaReglasDinamicas _objCNReglaDinamicas;
        private clsCNIntervCre _objCNIntervinientes;
        private CRE.CapaNegocio.clsCNCredito _objCNCredito;

        private DataTable dtSolicitud;
        private DataTable dtGarIntervinientes;

        private Transaccion operacion = Transaccion.Selecciona;
        private const string cTituloMsjes = "Vinculación Garantía";
     
        private readonly decimal nTipoCambio;

        #endregion

        #region Constructores

        public frmCambioGarantias()
        {
            InitializeComponent();
            conBusCuentaCli.cTipoBusqueda = "C";
            conBusCuentaCli.cEstado = "[5]";

            _objCNSolicitud = new clsCNSolicitud();
            _objCNGarantia = new clsCNGarantia();
            _objCNCartaFianza = new clsCNCartaFianza();
            _objCNReglaDinamicas = new clsCNValidaReglasDinamicas();
            _objCNIntervinientes = new clsCNIntervCre();
            _objCNCredito = new CRE.CapaNegocio.clsCNCredito();

            nTipoCambio = clsVarApl.dicVarGen["nTipoCambio"];
        }

        #endregion

        #region Eventos

        private void frmVincularGarantia_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            dtgGarantias.SelectionChanged += dtgGarantias_SelectionChanged;
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatos();
        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            CargarGarantiasCli();
        }

        private void dtgGarantiasCli_RowEnter(object sender, EventArgs e)
        {
            SeleccionarGarLista();
        }

        private void dtgGarantias_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgGarantias.SelectedRows.Count > 0)
            {
                clsDetGarantia objdet = (clsDetGarantia)dtgGarantias.SelectedRows[0].DataBoundItem;
                if (operacion == Transaccion.Selecciona)
                {
                    txtGravamen.Text = string.Format("{0:0.00}", objdet.nMonGravado);
                    txtPorAfe.Text = string.Format("{0:0.00}", objdet.nPorcentaje);
                }

                SeleccionarInterviniente(objdet.idCli);
            }
        }

        private void pbxAyuda_Click(object sender, EventArgs e)
        {
            ttpMensaje.Show("Recordar que solo se lista garantías a favor del Cliente Titular" +
                "\n Para agregar registre desde la opcion de Registro de Garantía.", pbxAyuda1);
        }

        private void txtGravamen_TextChanged(object sender, EventArgs e)
        {
            CalcularPorcentaje();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarActualizacion())
                return;

            DataGridViewRow rowGarCli = dtgGarantiasCli.SelectedRows[0];

            clsDetGarantia objGarantiaCli = new clsDetGarantia();

            objGarantiaCli.idCli = (int)rowGarCli.Cells["idCli"].Value;
            objGarantiaCli.idCliGarantia = (int)rowGarCli.Cells["idCliGarantia"].Value;
            objGarantiaCli.idGarantia = (int)rowGarCli.Cells["idGarantia"].Value;
            objGarantiaCli.nMonGarantia = (decimal)rowGarCli.Cells["nMonGarantia"].Value;
            objGarantiaCli.nMonSaldoGrav = (decimal)rowGarCli.Cells["nMonSaldoGrav"].Value;
            objGarantiaCli.nPorcentaje = txtPorAfe.nDecValor;
            objGarantiaCli.nMonGravado = txtGravamen.nDecValor;
            objGarantiaCli.cGarantia = rowGarCli.Cells["cGarantia"].Value.ToString();

            _lstDetGarSolicitud.Add(objGarantiaCli);

            DataRow resultGar = dtGarIntervinientes.AsEnumerable()
                                                   .FirstOrDefault(x => (int)x["idCliGarantia"] == objGarantiaCli.idCliGarantia);
            if (resultGar != null)
            {
                decimal nGravado = objGarantiaCli.nMonGravado;
                int idMonSolicitud = (int)cboMoneda.SelectedValue;
                int idMonGarantia = (int)resultGar["idMoneda"];

                if (idMonSolicitud != idMonGarantia)
                {
                    nGravado = idMonGarantia == 1 ? nGravado * nTipoCambio : nGravado / nTipoCambio;
                }

                resultGar.Table.Columns["nMonSaldoGrav"].ReadOnly = false;
                resultGar["nMonSaldoGrav"] = (decimal)resultGar["nMonSaldoGrav"] - nGravado;
                resultGar.Table.Columns["nMonSaldoGrav"].ReadOnly = true;

                CargarGarantiasCli();

            }

            CargarVinculoGarantias();

            btnQuitar.Enabled = true;

            SumarTotales();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgGarantias.Rows.Count > 0)
            {
                clsListDetGarantia lista = (clsListDetGarantia)dtgGarantias.DataSource;
                clsDetGarantia objDetalleGarantia = (clsDetGarantia)dtgGarantias.SelectedRows[0].DataBoundItem;

                _lstDetGarSolicitud.Remove(objDetalleGarantia);

                DataRow resultGar = dtGarIntervinientes.AsEnumerable()
                                                    .FirstOrDefault(x => (int)x["idCliGarantia"] == objDetalleGarantia.idCliGarantia);
                if (resultGar != null)
                {
                    decimal nGravado = objDetalleGarantia.nMonGravado;
                    int idMonSolicitud = (int)cboMoneda.SelectedValue;
                    int idMonGarantia = (int)resultGar["idMoneda"];

                    if (idMonSolicitud != idMonGarantia)
                    {
                        nGravado = idMonGarantia == 1 ? nGravado * nTipoCambio : nGravado / nTipoCambio;
                    }

                    resultGar.Table.Columns["nMonSaldoGrav"].ReadOnly = false;
                    resultGar["nMonSaldoGrav"] = (decimal)resultGar["nMonSaldoGrav"] + nGravado;
                    resultGar.Table.Columns["nMonSaldoGrav"].ReadOnly = true;

                    CargarGarantiasCli();
                }

                CargarVinculoGarantias();
                SumarTotales();

                btnQuitar.Enabled = dtgGarantias.Rows.Count > 0;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;
            _lstDetGarSolicitud = new clsListDetGarantia();
            grbVinculacion.Enabled = true;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Edita;
            grbVinculacion.Enabled = true;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), 0, "Inicio - Cambio de Garantía", btnGrabar);
            if (!Validar())
                return;

            if (!ValidarReglas())
                return;

            int idCuenta = conBusCuentaCli.nValBusqueda;
            int idUsuario = clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = _objCNGarantia.insertaCambioVinCreGar(idCuenta, _lstDetGarSolicitud, idUsuario);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje,
                                cTituloMsjes,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarDatos();
                operacion = Transaccion.Selecciona;
                grbVinculacion.Enabled = false;
                btnEditar.Enabled = true;
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnGrabar.Enabled = false;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje,
                                cTituloMsjes,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), 0, "Fin - Vinculación Garantía", btnGrabar);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCuentaCli.LiberarCuenta();
            InitForm();
        }

        private void frmCambioGarantias_FormClosed(object sender, FormClosedEventArgs e)
        {
            conBusCuentaCli.LiberarCuenta();
        }

        #endregion

        #region Metodos

        private bool Validar()
        {
            if (txtTotPorcentaje.nDecValor < 100 || txtTotMonGar.nDecValor < txtMonSoli.nDecValor)
            {
                MessageBox.Show("Por favor complete el valor de las garantía \n hasta que cubra el porcentaje solicitado.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarReglas()
        {
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            var dtParametros = ArmarTablaParametros();
            var cCumpleReglas = _objCNReglaDinamicas.ValidarReglas(dtParametros, this.Name,
                                                  clsVarGlobal.nIdAgencia, conBusCuentaCli.nIdCliente,
                                                  1, Convert.ToInt32(cboMoneda.SelectedValue), Convert.ToInt32(cboProducto.SelectedValue),
                                                  txtMonSoli.nDecValor, conBusCuentaCli.nIdCuenta, clsVarGlobal.dFecSystem,
                                                  2, 0,
                                                  clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("Cumple"))
                return true;

            return false;
        }

        private bool ValidarActualizacion()
        {
            if (dtgGarantiasCli.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la garantia a asignar.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (txtGravamen.nDecValor == 0 && txtTotPorcentaje.nDecValor == 100)
            {
                MessageBox.Show("Ya se asignó el 100% para cubrir el monto solicitado",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (txtGravamen.nDecValor == 0 && txtTotPorcentaje.nDecValor < 100)
            {
                MessageBox.Show("Ingrese un monto mayor a cero(0)",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                txtGravamen.Focus();
                txtGravamen.SelectAll();
                return false;
            }

            int idCliGarantia = (int)dtgGarantiasCli.SelectedRows[0].Cells["idCliGarantia"].Value;
            clsListDetGarantia lstGarAsig = dtgGarantias.DataSource as clsListDetGarantia;
            if (lstGarAsig != null)
            {
                bool lExisteCli = lstGarAsig.Any(x => x.idCliGarantia == idCliGarantia);
                if (lExisteCli)
                {
                    MessageBox.Show("Ya agregó la garantía nro : " + idCliGarantia, "Validación Garantías", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            decimal montoSolicitado = txtMonSoli.nDecValor;
            decimal montoAsignar = txtGravamen.nDecValor;
            decimal montoSaldo = (decimal)dtgGarantiasCli.SelectedRows[0].Cells["nMonSaldoGrav"].Value;

            int idMonedaGar = (int)dtgGarantiasCli.SelectedRows[0].Cells["idMoneda"].Value;
            int idMonedaSolicitud = (int)cboMoneda.SelectedValue;

            if (idMonedaSolicitud == idMonedaGar)
            {
                montoAsignar = txtGravamen.nDecValor;
            }
            else
            {
                if (idMonedaSolicitud == 1)
                {
                    montoSaldo = Math.Round(montoSaldo * nTipoCambio, 2);
                }
                else
                {
                    montoSaldo = Math.Round(montoSaldo / nTipoCambio, 2);
                }
            }

            if (Math.Round(montoSaldo, 2, MidpointRounding.ToEven) < montoAsignar)
            {
                MessageBox.Show("Por favor asigne  un monto menor a la garantía", "Validación monto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtGravamen.Text = string.Format("{0:0.00}", 0.0);
                txtPorAfe.Text = string.Format("{0:0.00}", 0.0);
                return false;
            }

            if (montoAsignar > montoSolicitado)
            {
                MessageBox.Show("Por favor ingrese un valor menor al total solicitado", "Validación monto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGravamen.Text = string.Format("{0:0.00}", 0.0);
                txtPorAfe.Text = string.Format("{0:0.00}", 0.0);
                return false;
            }

            int idProducto = Convert.ToInt32(cboSubPro.SelectedValue);
            string cSubProdCF = clsVarApl.dicVarGen["nSubProductoCartaFianza"];
            if (idProducto.ToString().In(cSubProdCF.Split(',')))
            {
                if (Convert.ToInt32(dtgGarantiasCli.CurrentRow.Cells["idTipoGarantia"].Value) != Convert.ToInt32(clsVarApl.dicVarGen["nTipoGaranCFLiquida"]) && Convert.ToInt32(dtgGarantiasCli.CurrentRow.Cells["idTipoGarantia"].Value) != Convert.ToInt32(clsVarApl.dicVarGen["nTipoGaranCFHipoteca"]))
                {
                    MessageBox.Show("El tipo de garantia no es aplicable para carta fianza",
                                        cTituloMsjes,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return false;
                }
                if (dtgGarantiasCli.SelectedRows.Count > 0)
                {
                    int idMonedaGarantia = Convert.ToInt16(dtgGarantiasCli.SelectedRows[0].Cells["idMoneda"].Value);
                    if (Convert.ToInt32(cboMoneda.SelectedValue) != idMonedaGarantia)
                    {
                        MessageBox.Show("La moneda de la garantia no es la misma a la solicitud de la carta fianza.",
                                            cTituloMsjes,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            decimal nTotPorcentaje = txtTotPorcentaje.nDecValor;
            decimal nPorNueIng = nTotPorcentaje + txtPorAfe.nDecValor;

            if (nPorNueIng > 100)
            {
                MessageBox.Show("El monto supera el 100% de lo solicitado",
                                    "Validación garantía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void CargarDatos()
        {
            int idCuenta = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if (idCuenta == 0)
                return;

            var Credito = _objCNCredito.retornaDatosCredito(idCuenta);
            int idSolicitud = Credito.idSolicitud;
            decimal nSaldoCapital = Credito.nCapitalDesembolso - Credito.nCapitalPagado;

            CargarSolicitud(idSolicitud);

            txtMonSoli.Text = nSaldoCapital.ToString("#,0.00");

            dtGarIntervinientes = _objCNGarantia.CNGetGarantiasIntervSol(idSolicitud);
            CargarIntervinientes(idSolicitud);

            conBusCuentaCli.txtNroBusqueda.Enabled = false;
            conBusCuentaCli.btnBusCliente1.Enabled = false;
            btnActualizar.Enabled = true;
            txtGravamen.Enabled = true;

            _lstDetGarSolicitud = _objCNGarantia.listarGarVinculadasSol(idSolicitud);

            CargarVinculoGarantias();

            SumarTotales();

            if (_lstDetGarSolicitud.Count > 0)
            {
                btnEditar.Enabled = true;
                btnNuevo.Enabled = false;
                btnQuitar.Enabled = true;

                string cSubProdCF = clsVarApl.dicVarGen["nSubProductoCartaFianza"];
                int idSubProd = Convert.ToInt16(cboSubPro.SelectedValue);
                if (idSubProd.ToString().In(cSubProdCF.Split(',')))
                {
                    DataTable dtCartaFianza = _objCNCartaFianza.ObtenerDatosBasicos(idSolicitud);
                    int idEstadoCartaFianza = Convert.ToInt32(dtCartaFianza.Rows[0]["idEstadoCartaFianza"]);
                    btnEditar.Enabled = (idEstadoCartaFianza == 2);
                }
            }
            else
            {
                btnEditar.Enabled = false;
                btnNuevo.Enabled = true;
                btnQuitar.Enabled = false;
            }

            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
        }

        private void CargarSolicitud(int idSolicitud)
        {
            dtSolicitud = _objCNSolicitud.ConsultaSolicitud(idSolicitud);

            if (dtSolicitud.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos de la solicitud de crédito.",
                                    "Validar Solicitud",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                InitForm();
                return;
            }
            DataRow drSol = dtSolicitud.Rows[0];
            int idOperacion = Convert.ToInt32(drSol["idOperacion"]);
            int idMonedaSol = Convert.ToInt16(drSol["IdMoneda"]);
            int idSubTipo = Convert.ToInt32(drSol["nSubTip"]);
            int idProducto = Convert.ToInt32(drSol["nProdu"]);
            int idSubProducto = Convert.ToInt32(drSol["nSubPro"]);

            if (idOperacion == 3)
            {
                MessageBox.Show("No puede vincular una solicitud de reprogramación por esta opción.",
                                    "Validar Solicitud",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                InitForm();
                return;
            }

            cboMoneda.SelectedValue = idMonedaSol;
            cboProducto.CargarProducto(idSubTipo);
            cboProducto.SelectedValue = idProducto;
            cboSubPro.CargarProducto(idProducto);
            cboSubPro.SelectedValue = idSubProducto;
            txtGravamen.BackColor = idMonedaSol == 1 ? Color.SkyBlue : Color.LightGreen;
        }

        private void CargarIntervinientes(int idSolicitud)
        {
            dtgIntervinientes.SelectionChanged -= dtgIntervinientes_SelectionChanged;

            DataTable ListIntervCre = _objCNIntervinientes.CNdtIntervCre(idSolicitud, (int)Modulo.CREDITOS);
            dtgIntervinientes.DataSource = ListIntervCre;
            FormatoGridInterv();
            dtgIntervinientes.ClearSelection();

            dtgIntervinientes.SelectionChanged += dtgIntervinientes_SelectionChanged;

            if (dtgIntervinientes.RowCount > 0)
            {
                dtgIntervinientes.Rows[0].Selected = true;
            }
        }

        private void CargarGarantiasCli()
        {
            txtGravamen.Text = "0.00";

            if (dtgIntervinientes.SelectedRows.Count == 0)
                return;

            int idCliInterv = (int)dtgIntervinientes.SelectedRows[0].Cells["idCli"].Value;

            BindingGarantiasCli(idCliInterv);
        }

        private void BindingGarantiasCli(int idCli)
        {
            dtgGarantiasCli.RowEnter -= dtgGarantiasCli_RowEnter;

            var resultFilter = dtGarIntervinientes.AsEnumerable()
                                                .Where(x => x.Field<int>("idCli") == idCli);
            dtgGarantiasCli.DataSource = null;
            dtgGarantiasCli.DataSource = resultFilter.Any() ? resultFilter.CopyToDataTable() : dtGarIntervinientes.Clone();

            FormatoGridGarantia();

            dtgGarantiasCli.ClearSelection();
            dtgGarantiasCli.RowEnter += dtgGarantiasCli_RowEnter;

            if (dtgGarantiasCli.RowCount > 0)
            {
                dtgGarantiasCli.Rows[0].Selected = true;
            }
        }

        private void CargarVinculoGarantias()
        {
            dtgGarantias.SelectionChanged -= dtgGarantias_SelectionChanged;

            dtgGarantias.DataSource = null;
            dtgGarantias.DataSource = _lstDetGarSolicitud;
            FormatoGarantiasVinculadas();

            dtgGarantias.ClearSelection();

            dtgGarantias.SelectionChanged += dtgGarantias_SelectionChanged;

            if (dtgGarantias.RowCount > 0)
            {
                dtgGarantias.Rows[0].Selected = true;
            }
        }

        private void SeleccionarInterviniente(int idCli)
        {
            var resultCli = dtgIntervinientes.Rows.Cast<DataGridViewRow>()
                                                    .FirstOrDefault(x => (int)x.Cells["idCli"].Value == idCli);
            if (resultCli != null)
            {
                resultCli.Selected = true;
            }
        }

        private void SeleccionarGarLista()
        {
            if (dtgGarantiasCli.SelectedRows.Count == 0)
            {
                txtPorAfe.Text = string.Format("{0:0.00}", 0);
                txtGravamen.Text = string.Format("{0:0.00}", 0);
                return;
            }

            decimal nMonSaldoGrav = (decimal)dtgGarantiasCli.SelectedRows[0].Cells["nMonSaldoGrav"].Value;

            int idMonedaOri = (int)dtgGarantiasCli.SelectedRows[0].Cells["idMoneda"].Value;
            int idMonedaDes = (int)cboMoneda.SelectedValue;

            decimal nMonGravIni = 0.00M;

            if (idMonedaDes == idMonedaOri)
            {
                nMonGravIni = nMonSaldoGrav;
            }
            else
            {
                if (idMonedaDes == 1)
                    nMonGravIni = decimal.Round(nMonSaldoGrav * nTipoCambio, 2);
                else
                    nMonGravIni = decimal.Round(nMonSaldoGrav / nTipoCambio, 2);
            }

            decimal nMontoSolicitadoGarantia = txtMonSoli.nDecValor;

            if (nMonGravIni > nMontoSolicitadoGarantia - txtTotMonGar.nDecValor)
            {
                decimal nValGravamen = nMontoSolicitadoGarantia - txtTotMonGar.nDecValor;
                txtGravamen.Text = string.Format("{0:0.00}", nValGravamen < 0 ? 0M : nValGravamen);
            }
            else
            {
                txtGravamen.Text = string.Format("{0:0.00}", nMonGravIni);
            }
        }

        private void CalcularPorcentaje()
        {
            decimal montoSolicitado = txtMonSoli.nDecValor;
            decimal montoAsignar = txtGravamen.nDecValor;

            decimal nPorcentaje = decimal.Round((montoAsignar / montoSolicitado) * 100.0M,2);
            txtPorAfe.Text = string.Format("{0:0.00}", nPorcentaje);
        }

        private void SumarTotales()
        {
            decimal nMontoSolicitado = txtMonSoli.nDecValor;
            decimal nSumaTotal = _lstDetGarSolicitud.Sum(x => x.nMonGravado);
            decimal nTotPorcentaje = _lstDetGarSolicitud.Sum(x => x.nPorcentaje);

            txtTotMonGar.Text = string.Format("{0:0.00}", nSumaTotal);
            txtTotPorcentaje.Text = string.Format("{0:0.00}", nTotPorcentaje);

            btnGrabar.Enabled = nSumaTotal == nMontoSolicitado && dtgIntervinientes.Enabled;
        }

        private void InitForm()
        {
            LimpiarControles();
            operacion = Transaccion.Selecciona;
            grbVinculacion.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void FormatoGridInterv()
        {
            foreach (DataGridViewColumn item in dtgIntervinientes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgIntervinientes.Columns["cNombre"].HeaderText = "Nombres";
            dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Tipo";
            dtgIntervinientes.Columns["idCli"].HeaderText = "Cod.Cliente";

            dtgIntervinientes.Columns["idCli"].Visible = true;
            dtgIntervinientes.Columns["idCli"].Width = 70;
            dtgIntervinientes.Columns["cNombre"].Visible = true;
            dtgIntervinientes.Columns["cNombre"].Width = 280;
            dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;
            dtgIntervinientes.Columns["cTipoIntervencion"].Width = 80;
        }

        private void FormatoGridGarantia()
        {
            DataTable dtGarantiasCli = (DataTable)dtgGarantiasCli.DataSource;
            dtGarantiasCli.Columns["nMonSaldoGrav"].ReadOnly = false;

            foreach (DataGridViewColumn item in dtgGarantiasCli.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgGarantiasCli.Columns["idGarantia"].Visible = true;
            dtgGarantiasCli.Columns["cSimbolo"].Visible = true;
            dtgGarantiasCli.Columns["cGarantia"].Visible = true;
            dtgGarantiasCli.Columns["nMonSaldoGrav"].Visible = true;
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].Visible = true;

            dtgGarantiasCli.Columns["idGarantia"].HeaderText = "Cod.Gar.";
            dtgGarantiasCli.Columns["cSimbolo"].HeaderText = "Mon.";
            dtgGarantiasCli.Columns["cGarantia"].HeaderText = "Garantia";
            dtgGarantiasCli.Columns["nMonSaldoGrav"].HeaderText = "Saldo";
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].HeaderText = "Saldo Conv.";

            dtgGarantiasCli.Columns["idGarantia"].DisplayIndex = 1;
            dtgGarantiasCli.Columns["cSimbolo"].DisplayIndex = 2;
            dtgGarantiasCli.Columns["cGarantia"].DisplayIndex = 3;
            dtgGarantiasCli.Columns["nMonSaldoGrav"].DisplayIndex = 4;
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].DisplayIndex = 5;

            dtgGarantiasCli.Columns["idGarantia"].FillWeight = 15;
            dtgGarantiasCli.Columns["cSimbolo"].FillWeight = 10;
            dtgGarantiasCli.Columns["cGarantia"].FillWeight = 40;
            dtgGarantiasCli.Columns["nMonSaldoGrav"].FillWeight = 18;
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].FillWeight = 17;

            dtgGarantiasCli.Columns["cSimbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGarantiasCli.Columns["nMonSaldoGrav"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGarantiasCli.Columns["nMonSaldoGrav"].DefaultCellStyle.Format = "#,0.00";
            //dtgGarantiasCli.Columns["nMonSaldoGravConv"].DefaultCellStyle.Format = "#,0.00";

            foreach (DataGridViewRow row in dtgGarantiasCli.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private DataTable ArmarTablaParametros()
        {
            int idSolCre = conBusCuentaCli.nValBusqueda;
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            dtTablaParametros.Rows.Add("idCli", conBusCuentaCli.nIdCliente);
            dtTablaParametros.Rows.Add("idCliUsuSistem", clsVarGlobal.User.idCli.ToString());
            dtTablaParametros.Rows.Add("dFechaActual", clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd"));
            dtTablaParametros.Rows.Add("dFechaSolicitud", Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaRegistro"]).ToString("yyyy-MM-dd"));
            dtTablaParametros.Rows.Add("nTipoOperacion", Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]).ToString());
            dtTablaParametros.Rows.Add("Monto", txtMonSoli.Text);
            dtTablaParametros.Rows.Add("idMoneda", cboMoneda.SelectedValue);
            dtTablaParametros.Rows.Add("nCuotas", dtSolicitud.Rows[0]["nCuotas"].ToString());
            dtTablaParametros.Rows.Add("idTipoPeriodo", dtSolicitud.Rows[0]["idTipoPeriodo"].ToString());
            dtTablaParametros.Rows.Add("frecuencia", dtSolicitud.Rows[0]["nPlazoCuota"].ToString());
            dtTablaParametros.Rows.Add("nDiasGracia", dtSolicitud.Rows[0]["ndiasgracia"].ToString());
            dtTablaParametros.Rows.Add("dFechaDesembolso", Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"]).ToString("yyyy-MM-dd"));
            dtTablaParametros.Rows.Add("PersonalCre", dtSolicitud.Rows[0]["idUsuario"].ToString());
            dtTablaParametros.Rows.Add("nTipoCredito", dtSolicitud.Rows[0]["nTipCre"].ToString());
            dtTablaParametros.Rows.Add("SubTipoCredito", dtSolicitud.Rows[0]["nSubTip"].ToString());
            dtTablaParametros.Rows.Add("Producto", dtSolicitud.Rows[0]["nProdu"].ToString());
            dtTablaParametros.Rows.Add("SubProducto", dtSolicitud.Rows[0]["nSubPro"].ToString());
            dtTablaParametros.Rows.Add("DestinoCredito", dtSolicitud.Rows[0]["idDestino"].ToString());
            dtTablaParametros.Rows.Add("ModDesembolso", dtSolicitud.Rows[0]["idModalidadDes"].ToString());
            dtTablaParametros.Rows.Add("idCargo", clsVarGlobal.User.idCargo.ToString());
            dtTablaParametros.Rows.Add("idEstado", clsVarGlobal.User.idEstado.ToString());
            dtTablaParametros.Rows.Add("nLimOpePacSol", clsVarApl.dicVarGen["nLimOpePacSol"]);
            dtTablaParametros.Rows.Add("nLimOpePacDol", clsVarApl.dicVarGen["nLimOpePacDol"]);
            dtTablaParametros.Rows.Add("idSolCre", idSolCre.ToString());
            dtTablaParametros.Rows.Add("idUsuSistem", clsVarGlobal.User.idUsuario);
            dtTablaParametros.Rows.Add("nTotalGarantias", dtgGarantias.Rows.Count);

            #region XML de detalle de garantías

            var listagarantias = (clsListDetGarantia)dtgGarantias.DataSource;
            string cxmlGarantia = "'" + @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                                   new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                                   new XElement("dsgarvin",
                                                 from item in listagarantias
                                                 select new XElement("dtgarvin",
                                                                     new XAttribute("idCliGarantia", item.idCliGarantia),
                                                                     new XAttribute("nGravamen", item.nMonGravado),
                                                                     new XAttribute("nMontoGarantia", item.nMonSaldoGrav),
                                                                     new XAttribute("nPorcentaje", item.nPorcentaje))
                                                                   )).ToString() + "'";
            dtTablaParametros.Rows.Add("xmlGarantiasSolicitud", cxmlGarantia);
            #endregion

            return dtTablaParametros;
        }

        private void LimpiarControles()
        {
            dtgGarantias.DataSource = null;
            dtgGarantiasCli.DataSource = null;
            dtgIntervinientes.DataSource = null;

            txtMonSoli.Text = "0.00";
            txtGravamen.Text = "0.00";
            txtPorAfe.Text = "0.00";
            txtTotMonGar.Text = "0.00";
            txtTotPorcentaje.Text = "0.00";

            conBusCuentaCli.limpiarControles();
            cboMoneda.SelectedValue = 0;
            cboSubPro.SelectedValue = 0;
            cboProducto.SelectedValue = 0;

            conBusCuentaCli.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Select();
        }

        private void FormatoGarantiasVinculadas()
        {
            foreach (DataGridViewColumn column in dtgGarantias.Columns)
            {
                column.Visible = false;
            }

            dtgGarantias.Columns["idCliGarantia"].Visible = true;
            dtgGarantias.Columns["idGarantia"].Visible = true;
            dtgGarantias.Columns["cGarantia"].Visible = true;
            dtgGarantias.Columns["idCli"].Visible = true;
            dtgGarantias.Columns["nMonGarantia"].Visible = true;
            dtgGarantias.Columns["nMonGravado"].Visible = true;
            dtgGarantias.Columns["nPorcentaje"].Visible = true;

            dtgGarantias.Columns["idCliGarantia"].HeaderText = "Cod. Vinc. Garantía";
            dtgGarantias.Columns["idGarantia"].HeaderText = "Cod. Garantia";
            dtgGarantias.Columns["cGarantia"].HeaderText = "Garantia";
            dtgGarantias.Columns["idCli"].HeaderText = "Cod. Cliente";
            dtgGarantias.Columns["nMonGarantia"].HeaderText = "Monto Garantía";
            dtgGarantias.Columns["nMonGravado"].HeaderText = "Gravado";
            dtgGarantias.Columns["nPorcentaje"].HeaderText = "%";

            dtgGarantias.Columns["idCliGarantia"].FillWeight = 15;
            dtgGarantias.Columns["idGarantia"].FillWeight = 15;
            dtgGarantias.Columns["cGarantia"].FillWeight = 40;
            dtgGarantias.Columns["idCli"].FillWeight = 15;
            dtgGarantias.Columns["nMonGarantia"].FillWeight = 20;
            dtgGarantias.Columns["nMonGravado"].FillWeight = 20;
            dtgGarantias.Columns["nPorcentaje"].FillWeight = 10;

            dtgGarantias.Columns["idCliGarantia"].DisplayIndex = 0;
            dtgGarantias.Columns["idGarantia"].DisplayIndex = 1;
            dtgGarantias.Columns["cGarantia"].DisplayIndex = 2;
            dtgGarantias.Columns["idCli"].DisplayIndex = 3;
            dtgGarantias.Columns["nMonGarantia"].DisplayIndex = 4;
            dtgGarantias.Columns["nMonGravado"].DisplayIndex = 5;
            dtgGarantias.Columns["nPorcentaje"].DisplayIndex = 6;

            dtgGarantias.Columns["nMonGarantia"].DefaultCellStyle.Format = "#,0.00";
            dtgGarantias.Columns["nMonGravado"].DefaultCellStyle.Format = "#,0.00";
            dtgGarantias.Columns["nPorcentaje"].DefaultCellStyle.Format = "#,0.00";

        }

        #endregion        

    }
}
