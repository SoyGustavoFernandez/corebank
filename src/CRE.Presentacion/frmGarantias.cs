using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CRE.CapaNegocio;
using CLI.CapaNegocio;
using DEP.CapaNegocio;
using GEN.CapaNegocio;
using System.Collections.Generic;

namespace CRE.Presentacion
{
    public partial class frmGarantias : frmBase
    {

        #region Variables

        private clsCNGarantia _objCNGarantia;
        private clsGarantia _objGarantia;
        private clsCNDirecCli _objCNDireccion;
        private clsCNIntervCre _objCNIntervCre;
        private clsCNProducto _objCNProducto;
        private clsCNDeposito _objCNDeposito;

        private const string cTituloMsjes = "Registro de garantías";
        private Transaccion eTransaccion = Transaccion.Selecciona;

        private Dictionary<string, string> controlsResult = new Dictionary<string, string>()
        {
            {"txtMonGravamenSol","txtMonGravamenSolCon" },
            {"txtMonGravamen","txtMonGravCon" },
            {"txtValorComercial","txtValorComCon" },
            {"txtValorMercado","txtValorMercCon" },
            {"txtValorEdifica","txtValorEdiCon" },
            {"txtValorNuevo","txtValorNueCon" },
            {"txtValorVenta","txtValorVentaCon" },
            {"txtMonGarantia","txtMonGarCon" },
            {"txtValorRealiza","txtValorReaCon"},
            {"txtValorContable","txtValorContableCon"},
            {"txtValorConstituido","txtValorConstituidoCon"}
        };

        
        private readonly Color verdeMonDolar = Color.FromArgb(192, 255, 192);
        private readonly Color celesteMonSoles = Color.FromArgb(192, 255, 255);

        #endregion

        #region Constructores

        public frmGarantias()
        {
            InitializeComponent();

            _objCNGarantia = new clsCNGarantia();
            _objCNDireccion = new clsCNDirecCli();
            _objCNIntervCre = new clsCNIntervCre();
            _objCNProducto = new clsCNProducto();
            _objCNDeposito = new clsCNDeposito();
        }

        #endregion

        #region Eventos

        private void frmGarantias_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            dtgGarantias.AutoGenerateColumns = false;
            dtgDetGarantia.AutoGenerateColumns = false;

            cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia.SelectedValue);
            cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);
            conUbigeoGar.cargar();
            conUbigeoGar.cboPais.SelectedValue = 173;

            conBusCliente.txtCodCli.Focus();

            pnlDatGar.Enabled = false;
            pnlPropGar.Enabled = false;
            pnlAvalados.Enabled = false;
            pnlUbigGar.Enabled = false;

            CargarTipoEmisor();
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void dtgDetGarantia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (eTransaccion != Transaccion.Edita)
            {
                if (e.ColumnIndex == 7)
                {
                    dtgDetGarantia.Columns[7].ReadOnly = false;
                    if (dtgDetGarantia.Rows.Count == 1)
                    {
                        dtgDetGarantia.Rows[0].Cells[7].Value = true;
                        return;
                    }

                    int index = dtgDetGarantia.CurrentRow.Index;
                    for (int i = 0; i < dtgDetGarantia.Rows.Count; i++)
                    {
                        dtgDetGarantia.Rows[i].Cells[7].Value = false;
                    }
                    dtgDetGarantia.Rows[index].Cells[7].Value = true;
                }
            }
        }

        private void cboClaseGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseGarantia.SelectedIndex >= 0)
            {
                cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            AsignarValorConvertido(sender);
        }

        private void txtMonGarantia_TextChanged(object sender, EventArgs e)
        {
            if (_objGarantia != null && _objGarantia.idGarantia == 0)
            {
                if (txtTipoCambio.nDecValor > 0.00M && txtMonGarantia.nDecValor > txtMaximoGar.nDecValor)
                {
                    MessageBox.Show("El valor de la garantía no puede se mayor al valor de realización", "Validación de garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonGarantia.Text = txtMaximoGar.Text;
                }
            }
        }

        private void txtValorRealiza_TextChanged(object sender, EventArgs e)
        {
            txtMaximoGar.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);

            if (rbtTituloValor.Checked)
            {
                txtValorMercado.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);
                txtValorEdifica.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);
                txtValorComercial.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);
                txtValorNuevo.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);
                txtValorVenta.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor);
                txtValorContable.Text = string.Format("{0:#,0.00}", txtValorContable.nDecValor);
                txtValorConstituido.Text = string.Format("{0:#,0.00}", txtValorConstituido.nDecValor);

            }
        }

        private void txtMaximoGar_TextChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.nDecValor > 0.00M)
            {
                var drTipoGar = (DataRowView)cboTipoGarantia.SelectedItem;
                decimal nPorcGarAhorro = (decimal)drTipoGar["nPorAfecta"];

                if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
                {
                    txtMaximoGarCon.Text = string.Format("{0:#,0.00}", txtMaximoGar.nDecValor / txtTipoCambio.nDecValor);
                }
                else
                {
                    txtMaximoGarCon.Text = string.Format("{0:#,0.00}", txtMaximoGar.nDecValor * txtTipoCambio.nDecValor);
                }
                if (txtMaximoGar.nDecValor > txtValorRealiza.nDecValor)
                {
                    MessageBox.Show("El valor de la garantía no puede se mayor al valor de realización", "Validación de garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaximoGar.Text = txtValorRealiza.Text;
                }
                txtMonGarantia.Text = string.Format("{0:#,0.00}", (nPorcGarAhorro) * txtMaximoGar.nDecValor);
            }
            if (_objGarantia != null && _objGarantia.idGarantia == 0)
            {
                if (rbtTituloValor.Checked && _objGarantia.lisDetGarantia.Any())
                {
                    AsignarMontosTitulares(txtMonGarantia.nDecValor);
                }
                else
                {
                    NuevoRegistroClienteGarantia(false);
                }
            }
        }

        private void txtMaximoGar_Leave(object sender, EventArgs e)
        {
            //if (rbtTituloValor.Checked)
            //{
            //    AsignarMontosTitulares(txtMonGarantia.nDecValor);
            //}
            //else
            //{
            //    NuevoRegistroClienteGarantia(false);
            //}
        }

        private void cboTipoGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarGrupos();
            CargarOpcGarantia();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTipoCambio.nDecValor > 0M)
            {
                AsignarValorConvertido(txtMonGravamenSol);
                AsignarValorConvertido(txtMonGravamen);
                AsignarValorConvertido(txtMonGarantia);
                AsignarValorConvertido(txtValorComercial);
                AsignarValorConvertido(txtValorMercado);
                AsignarValorConvertido(txtValorEdifica);
                AsignarValorConvertido(txtValorNuevo);
                AsignarValorConvertido(txtValorRealiza);
                AsignarValorConvertido(txtValorVenta);
                AsignarValorConvertido(txtValorContable);
                AsignarValorConvertido(txtValorConstituido);


                txtMonGravamenSolCon.BackColor = 
                    txtMonGravCon.BackColor =
                    txtValorComCon.BackColor = 
                    txtValorMercCon.BackColor =
                    txtValorEdiCon.BackColor = 
                    txtValorNueCon.BackColor =
                    txtValorReaCon.BackColor = 
                    txtValorVentaCon.BackColor =
                    txtMaximoGarCon.BackColor = 
                    txtMonGarCon.BackColor =
                    txtValorContableCon.BackColor =
                    txtValorConstituidoCon.BackColor =
                    (int)cboMoneda.SelectedValue == 2 ? celesteMonSoles : verdeMonDolar;
            }
        }

        private void txtMonGarCli_TextChanged(object sender, EventArgs e)
        {
            if (txtMonGarCli.nDecValor > txtMonGarantia.nDecValor)
            {
                MessageBox.Show("Por favor ingrese un valor menor al valor de garantía", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonGarCli.Text = "0.00";
                txtMonPorcentaje.Text = "0.00";
                return;
            }
            if (!string.IsNullOrEmpty(txtMonGarantia.Text) && txtMonGarantia.nDecValor > 0.00M)
            {
                txtMonPorcentaje.Text = string.Format("{0:#,0.00}", Math.Round((txtMonGarCli.nDecValor / txtMonGarantia.nDecValor) * 100.00M, 2));
            }
        }

        private void cboGrupoGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoGarantia.SelectedIndex >= 0)
            {
                cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia.SelectedValue);
            }
        }

        private void dtgGarantias_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgGarantias.SelectedRows.Count > 0)
            {
                _objGarantia = (clsGarantia)dtgGarantias.SelectedRows[0].DataBoundItem;
                CargarDatosGarantia(_objGarantia);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            HabControles(true);

            _objGarantia = new clsGarantia();
            eTransaccion = Transaccion.Nuevo;

            tbcGarantia.Enabled = true;
            tbcGarantia.SelectedIndex = 0;

            if (conBusCliente.nidTipoPersona == 1)
            {
                conDatCliPropGarantia.cargarCliente(Convert.ToInt32(conBusCliente.idCli));
                conDatCliGarantizado.cargarCliente(Convert.ToInt32(conBusCliente.idCli));
            }
            else
            {
                conDatCliPropGarantia.cargarClienteJur(Convert.ToInt32(conBusCliente.idCli));
                conDatCliGarantizado.cargarClienteJur(Convert.ToInt32(conBusCliente.idCli));
            }

            var dtDireccion = _objCNDireccion.ListaDirCli(conBusCliente.idCli);
            if (dtDireccion.Rows.Count > 0)
            {
                var idUbigeo = Convert.ToInt32(dtDireccion.Rows[0]["idUbigeo"]);
                conUbigeoGar.cargarUbigeo(idUbigeo);
                txtDireccion.Text = dtDireccion.Rows[0]["cDireccion"].ToString();
                txtReferencia.Text = dtDireccion.Rows[0]["cReferenciaDireccion"].ToString();
            }

            cboEstadosGarantia.SelectedValue = 1;
            cboGrupoGarantia.SelectedValue = 1;

            txtTipoCambio.Text = string.Format("{0:0.0000}", clsVarApl.dicVarGen["nTipCamFij"]);

            txtMonGarCli.Enabled = true;

            cboGrupoGarantia.SelectedValue = 1;

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnReproGravamen.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnCancelaRegistro.Enabled = true;
            btnDetalle.Enabled = false;

            txtDescripcion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            eTransaccion = Transaccion.Selecciona;
            tbcGarantia.SelectedIndex = 0;

            LimpiarControles();
            dtgGarantias.DataSource = null;

            conBusCliente.limpiarControles();
            conBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;

            HabControles(false);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnReproGravamen.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnCancelaRegistro.Enabled = false;
            btnDetalle.Enabled = false;

            conBusCliente.Focus();
            conBusCliente.txtCodCli.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            registrarRastreo(Convert.ToInt32(conBusCliente.idCli), 0, "Inicio - Registro de Garantía", btnGrabar);
            if (!ValidarDatos())
                return;

            #region Seteo Datos Garantia

            _objGarantia.idGrupoGarantia = Convert.ToInt32(cboGrupoGarantia.SelectedValue);
            _objGarantia.idClaseGarantia = Convert.ToInt32(cboClaseGarantia.SelectedValue);
            _objGarantia.idEstado = Convert.ToInt32(cboEstadosGarantia.SelectedValue);
            _objGarantia.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            _objGarantia.idTipoGarantia = Convert.ToInt32(cboTipoGarantia.SelectedValue);
            _objGarantia.idUbigeo = Convert.ToInt32(conUbigeoGar.cboAnexo.SelectedValue);
            _objGarantia.lisDetGarantia = (clsListDetGarantia)dtgDetGarantia.DataSource;
            _objGarantia.lisEspecificacion = Especificacion();
            _objGarantia.nMonGarantia = txtMonGarantia.nDecValor;
            _objGarantia.nMonGravamen = txtMonGravamen.nDecValor;
            _objGarantia.nMonGravamenSol = txtMonGravamenSol.nDecValor;
            _objGarantia.nTipoCambio = txtTipoCambio.nDecValor;
            _objGarantia.nValorComercial = txtValorComercial.nDecValor;
            _objGarantia.nValorEdifica = txtValorEdifica.nDecValor;
            _objGarantia.nValorMercado = txtValorMercado.nDecValor;
            _objGarantia.nValorNuevo = txtValorNuevo.nDecValor;
            _objGarantia.nValorRealiza = txtValorRealiza.nDecValor;
            _objGarantia.nValorVenta = txtValorVenta.nDecValor;
            _objGarantia.cDesObserva = txtObservaciones.Text;
            _objGarantia.cDireccion = txtDireccion.Text;
            _objGarantia.cGarantia = txtDescripcion.Text;
            _objGarantia.cReferencia = txtReferencia.Text;
            _objGarantia.dFecRegistro = clsVarGlobal.dFecSystem;
            _objGarantia.lIndSabana = chcSabana.Checked;
            _objGarantia.nMaxGarantia = txtMaximoGar.nDecValor;
            _objGarantia.idSituacion = Convert.ToInt32(cboSituacion.SelectedValue);
            _objGarantia.cTipoEmisor = cboTipoEmisor.SelectedValue.ToString();

            _objGarantia.dValorContable = txtValorContable.nDecValor;
            _objGarantia.dValorConstituido = txtValorConstituido.nDecValor;
            

            #endregion

            clsDBResp objDbResp = _objCNGarantia.insertarGarantia(_objGarantia);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCliente();

                HabControles(false);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            registrarRastreo(Convert.ToInt32(conBusCliente.idCli), 0, "Fin - Registro de Garantía", btnGrabar);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int idEstadoGarantia = (int)cboEstadosGarantia.SelectedValue;
            if (idEstadoGarantia == 3)
            {
                MessageBox.Show("Estado no válido para edición de la garantía.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                eTransaccion = Transaccion.Selecciona;
                return;
            }

            eTransaccion = Transaccion.Edita;
            tbcGarantia.SelectedIndex = 0;
            dtgGarantias.Enabled = false;

            txtTipoCambio.Text = string.Format("{0:0.0000}", clsVarApl.dicVarGen["nTipCamFij"]);

            HabControles(false);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnReproGravamen.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = false;
            btnCancelaRegistro.Enabled = true;
            btnDetalle.Enabled = true;

            pnlUbigGar.Enabled = true;
            pnlPropGar.Enabled = true;
            pnlAvalados.Enabled = true;

            btnBusCliAval.Enabled = true;
            btnAgregarAval.Enabled = true;
            btnQuitarAval.Enabled = true;

            if (idEstadoGarantia.In(1, 2) && rbtTituloValor.Checked)
            {
                pnlDatGar.Enabled = true;
                btnBuscaCtaAho.Enabled = true;
                lblActualiza.Visible = true;
            }
            
        }

        private void btnReproGravamen_Click(object sender, EventArgs e)
        {
            if (dtgGarantias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una garantía.", cTituloMsjes,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            clsGarantia objGarantia = (clsGarantia)dtgGarantias.SelectedRows[0].DataBoundItem;
            clsDBResp objDbResp = _objCNGarantia.CNActualizaGravamenGarantia(objGarantia.idGarantia);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarCliente();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnCancelaRegistro_Click(object sender, EventArgs e)
        {
            CargarCliente();

            HabControles(false);
        }

        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            int idCuenta = 0;
            int idProducto = 0;
            bool lIndGarantia = false;
            DateTime dFecApertura = clsVarGlobal.dFecSystem.Date;
            int nPlazo = 0;
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            int idCli = conBusCliente.idCli;
            const int idTipoBus = 1;
            const int nTipoOpe = 14;
            DataTable dtDatosCtaAho = null;

            if (eTransaccion == Transaccion.Nuevo)
            {
                LimpiarGrupos();
                LimpiarPropietarios();

                frmBusCtaAho frmCtaAho = new frmBusCtaAho();
                frmCtaAho.idCli = idCli;
                frmCtaAho.pTipBus = idTipoBus;
                frmCtaAho.idMon = idMoneda;
                frmCtaAho.nTipOpe = nTipoOpe;

                DataTable dtbNumCuentas = _objCNDeposito.CNRetornaCuentasAhorros(idCli, idTipoBus, idMoneda, nTipoOpe);

                if (dtbNumCuentas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron cuentas vinculadas al cliente",
                                        "Validar Garantía",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                }

                frmCtaAho.ShowDialog();

                if (string.IsNullOrEmpty(frmCtaAho.pnCta))
                {
                    MessageBox.Show("No se seleccionó ninguna cuenta del cliente",
                                        "Validar cuentas",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                }

                string cNroCta = frmCtaAho.pcNroCta;
                txtCodTitu.Text = cNroCta;
                idCuenta = Convert.ToInt32(frmCtaAho.pnCta);
                idProducto = frmCtaAho.idProducto;

                if (!ValidarExisteGarantia(txtCodTitu.Text.Trim()))
                    return;

                string cProductosAhoCF = clsVarApl.dicVarGen["nProductosAhorroCartaFianza"];
                if (Convert.ToInt32(cboTipoGarantia.SelectedValue) == clsVarApl.dicVarGen["nTipoGaranCFLiquida"]
                        && rbtTituloValor.Checked
                        && !idProducto.ToString().In(cProductosAhoCF.Split(',')))
                {
                    MessageBox.Show("El tipo de cuenta debe de ser cuenta de garantía carta fianza",
                                    "Validar cuentas",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                dtDatosCtaAho = _objCNDeposito.CNRetornaDatosCuenta(idCuenta, "1", 12);
                if (dtDatosCtaAho.Rows.Count == 0)
                {
                    MessageBox.Show("No se encotrarón datos para esta cuenta.",
                                            "Validación Cuenta",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    return;
                }

                DataRow rowCuenta = dtDatosCtaAho.Rows[0];
                lIndGarantia = (bool)rowCuenta["lIndGarantia"];
                dFecApertura = (DateTime)rowCuenta["dFechaApertura"];
                nPlazo = (int)rowCuenta["nPlazoCta"];
                if (lIndGarantia)
                {
                    MessageBox.Show("La cuenta seleccionada ya se encuentra en garantía",
                                        "Validación Cuenta",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                }

                var dtProductoNiv = _objCNProducto.CNListarProductoNivelesSup(idProducto);
                bool lEsPlazoFijo = dtProductoNiv.AsEnumerable().Any(x => (int)x["idProducto"] == 48);

                if (Convert.ToInt32(dtDatosCtaAho.Rows[0]["idPagoInt"]) != 2 && lEsPlazoFijo)
                {
                    MessageBox.Show("La cuenta seleccionada debe de ser de pago de intereses al finalizar el plazo",
                                        "Validación Cuenta",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    return;
                }

                dtpFecIniTitu.Value = dFecApertura.Date;
                dtpFecFinTitu.Value = dtpFecIniTitu.Value.AddDays(nPlazo);

                var drTipoGar = (DataRowView)cboTipoGarantia.SelectedItem;

                decimal nPorcAfeGar = (decimal)drTipoGar["nPorAfecta"];
                decimal nMonto = ((decimal)dtDatosCtaAho.Rows[0]["nMontoDeposito"]);

                lblPorcAhorro.Text = "Aplica el " + string.Format("{0:#,0.00}", nPorcAfeGar * 100M) + "%";

                AsignarMontosAhorros(nMonto);
                txtMonGarantia.Text = string.Format("{0:#,0.00}", (nPorcAfeGar) * txtMaximoGar.nDecValor);
                AgregarTitulares(idCuenta);
                AsignarMontosTitulares(txtMonGarantia.nDecValor);

                txtMaximoGar.Enabled = !(lEsPlazoFijo);

                cboMoneda.SelectedValue = (int)dtDatosCtaAho.Rows[0]["idMoneda"];
                cboMoneda.Enabled = false;
            }
            else if (eTransaccion == Transaccion.Edita && !string.IsNullOrEmpty(txtCodTitu.Text.Trim()))
            {
                idCuenta = (int)_objCNDeposito.CNRetornaidCuenta(txtCodTitu.Text.Trim()).Rows[0][0];

                dtDatosCtaAho = _objCNDeposito.CNRetornaDatosCuenta(idCuenta, "1", 12);
                if (dtDatosCtaAho.Rows.Count == 0)
                {
                    MessageBox.Show("No se encotrarón datos para esta cuenta.",
                                            "Validación Cuenta",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    return;
                }

                DataRow rowCuenta = dtDatosCtaAho.Rows[0];
                dFecApertura = (DateTime)rowCuenta["dFechaApertura"];
                nPlazo = (int)rowCuenta["nPlazoCta"];

                dtpFecIniTitu.Value = dFecApertura.Date;
                dtpFecFinTitu.Value = dtpFecIniTitu.Value.AddDays(nPlazo);

                var drTipoGar = (DataRowView)cboTipoGarantia.SelectedItem;

                decimal nPorcAfeGar = (decimal)drTipoGar["nPorAfecta"];
                decimal nMonto = ((decimal)dtDatosCtaAho.Rows[0]["nMontoDeposito"]);

                lblPorcAhorro.Text = "Aplica el " + string.Format("{0:#,0.00}", nPorcAfeGar * 100M) + "%";

                AsignarMontosAhorros(nMonto);
                txtMonGarantia.Text = string.Format("{0:#,0.00}", (nPorcAfeGar) * txtMaximoGar.nDecValor);
                AsignarMontosTitulares(txtMonGarantia.nDecValor);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            _objGarantia = dtgGarantias.SelectedRows[0].DataBoundItem as clsGarantia;
            if (_objGarantia == null)
            {
                MessageBox.Show("Primero debe de registrar la garantia luego el detalle",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            frmGarantiaDetalle frmdetalle = new frmGarantiaDetalle(_objGarantia.idGarantia);
            frmdetalle.idTipoGarantia = (int)cboTipoGarantia.SelectedValue;
            frmdetalle.nTipoCambio = txtTipoCambio.nDecValor;
            frmdetalle.idMoneda = (int)cboMoneda.SelectedValue;
            frmdetalle.ShowDialog();
            CargarCliente();
        }

        private void btnBusCliAval_Click(object sender, EventArgs e)
        {
            FrmBusCli frmBusca = new FrmBusCli();
            frmBusca.ShowDialog();

            if (string.IsNullOrEmpty(frmBusca.pcCodCli))
            {
                conDatCliGarantizado.limpiarcontroles();
                return;
            }

            if (frmBusca.pnTipoPersona == 1)
            {
                conDatCliGarantizado.cargarCliente(Convert.ToInt32(frmBusca.pcCodCli));
            }
            else
            {
                conDatCliGarantizado.cargarClienteJur(Convert.ToInt32(frmBusca.pcCodCli));
            }
        }

        private void dtgGarPerAval_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgGarPerAval.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dtgGarPerAval.SelectedRows[0].DataBoundItem;
                CargarGarPerAval(row);
            }
        }

        private void btnAgregarAval_Click(object sender, EventArgs e)
        {
            AgregarPerAval();
        }

        private void btnQuitarAval_Click(object sender, EventArgs e)
        {
            QuitarPerAval();
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            FrmBusCli frmBusca = new FrmBusCli();
            frmBusca.ShowDialog();

            if (string.IsNullOrEmpty(frmBusca.pcCodCli))
            {
                return;
            }

            if (frmBusca.pnTipoPersona == 1)
            {
                conDatCliPropGarantia.cargarCliente(Convert.ToInt32(frmBusca.pcCodCli));
            }
            else
            {
                conDatCliPropGarantia.cargarClienteJur(Convert.ToInt32(frmBusca.pcCodCli));
            }
        }

        private void dtgDetGarantia_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetGarantia.SelectedRows.Count > 0)
            {
                clsDetGarantia objDetGar = (clsDetGarantia)dtgDetGarantia.SelectedRows[0].DataBoundItem;
                CargarClienteGarantia(objDetGar);
            }

        }

        private void btnAgregarCli_Click(object sender, EventArgs e)
        {
            AgregarCli();
        }

        private void btnQuitarCli_Click(object sender, EventArgs e)
        {
            QuitarCli();
        }

        #endregion

        #region Metodos

        private void CargarCliente()
        {
            if (conBusCliente.idCli == 0)
            {
                MessageBox.Show("Debe Buscar Primero un Cliente", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCliente.btnBusCliente.Focus();
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = false;
                return;
            }

            ListarGarantiasCliente(conBusCliente.idCli);
            tbcGarantia.SelectedIndex = 0;

            eTransaccion = Transaccion.Selecciona;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = dtgGarantias.Rows.Count > 0;
            btnReproGravamen.Enabled = dtgGarantias.Rows.Count > 0;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            btnCancelaRegistro.Enabled = false;
            btnDetalle.Enabled = false;
        }

        private void CargarDatosGarantia(clsGarantia objgarantia)
        {
            rbtHipoteca.Enabled = false;
            rbtPersonal.Enabled = false;
            rbtTituloValor.Enabled = false;
            rbtVehiculo.Enabled = false;
            rbtElectros.Enabled = false;

            txtDescripcion.Text = objgarantia.cGarantia;
            txtObservaciones.Text = objgarantia.cDesObserva;
            txtDireccion.Text = objgarantia.cDireccion;
            txtReferencia.Text = objgarantia.cReferencia;

            txtTipoCambio.Text = string.Format("{0:0.0000}", objgarantia.nTipoCambio);

            cboGrupoGarantia.SelectedValue = objgarantia.idGrupoGarantia;
            cboClaseGarantia.SelectedValue = objgarantia.idClaseGarantia;
            cboTipoGarantia.SelectedValue = objgarantia.idTipoGarantia;
            cboTipoEmisor.SelectedValue = objgarantia.cTipoEmisor;
            cboSituacion.SelectedValue = objgarantia.idSituacion;
            cboEstadosGarantia.SelectedValue = objgarantia.idEstado;
            cboMoneda.SelectedValue = objgarantia.idMoneda;

            conUbigeoGar.cargarUbigeo(objgarantia.idUbigeo);

            txtValorComercial.Text = string.Format("{0:#,0.00}", objgarantia.nValorComercial);
            txtValorMercado.Text = string.Format("{0:#,0.00}", objgarantia.nValorMercado);
            txtValorEdifica.Text = string.Format("{0:#,0.00}", objgarantia.nValorEdifica);
            txtValorNuevo.Text = string.Format("{0:#,0.00}", objgarantia.nValorNuevo);
            txtValorRealiza.Text = string.Format("{0:#,0.00}", objgarantia.nValorRealiza);
            txtValorVenta.Text = string.Format("{0:#,0.00}", objgarantia.nValorVenta);
            txtMaximoGar.Text = string.Format("{0:#,0.00}", objgarantia.nMaxGarantia);
            txtMonGarantia.Text = string.Format("{0:#,0.00}", objgarantia.nMonGarantia);
            txtMonGravamen.Text = string.Format("{0:#,0.00}", objgarantia.nMonGravamen);
            txtMonGravamenSol.Text = string.Format("{0:#,0.00}", objgarantia.nMonGravamenSol);

            txtValorContable.Text = string.Format("{0:#,0.00}", objgarantia.dValorContable);
            txtValorConstituido.Text = string.Format("{0:#,0.00}", objgarantia.dValorConstituido);
            


            chcSabana.Checked = _objGarantia.lIndSabana;

            objgarantia.lisDetGarantia = _objCNGarantia.listarDetGarantia(objgarantia.idGarantia);
            BindingClienteGar();

            objgarantia.dtGarPerAval = _objCNGarantia.CNlistarGarPerAval(objgarantia.idGarantia);
            BindigGarPerAval();

            CargarEspecificacion(objgarantia.idGarantia);
        }

        private void ListarGarantiasCliente(int idCli)
        {
            dtgGarantias.SelectionChanged -= dtgGarantias_SelectionChanged;

            clsListGarantia listGarantia = _objCNGarantia.listarGarantias(conBusCliente.idCli);
            dtgGarantias.DataSource = listGarantia;
            dtgGarantias.ClearSelection();

            dtgGarantias.SelectionChanged += dtgGarantias_SelectionChanged;

            if (dtgGarantias.RowCount > 0)
                dtgGarantias.Rows[0].Selected = true;
        }

        private void LimpiarControles()
        {
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            txtObservaciones.Text = "";
            txtReferencia.Text = "";          
            
            LimpiarGrupos();
            LimpiarPropietarios();
            LimpiarAvalados();

            chcSabana.Checked = false;
            cboMoneda.SelectedValue = 1;
            cboTipoEmisor.SelectedValue = 10;
            cboEstadosGarantia.SelectedValue = 1;
        }

        private void LimpiarGrupos()
        {
            txtCodHip.Text = string.Empty;
            txtUsoHip.Text = string.Empty;
            nudAnioHip.Value = 2013;
            txtCondiHip.Text = string.Empty;

            txtCodTitu.Text = string.Empty;
            dtpFecIniTitu.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFinTitu.Value = clsVarGlobal.dFecSystem.Date;
            lblPorcAhorro.Text = "Aplica el 0%";

            txtCodVehi.Text = string.Empty;
            txtTipoVehi.Text = string.Empty;
            nudAnioVehi.Value = 2013;
            txtUsoVehi.Text = string.Empty;

            txtDetElecto.Text = string.Empty;
            nudAnioElectro.Value = 2013;
            txtNroFactura.Text = string.Empty;

            txtCodPers.Text = string.Empty;
            txtNombrePers.Text = string.Empty;
            dtpFecIniPers.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFinPers.Value = clsVarGlobal.dFecSystem.Date;

            LimpiarMontos();
        }

        private void LimpiarMontos()
        {
            txtMonGravamenSol.TextChanged -= txtMonto_TextChanged;
            txtMonGravamen.TextChanged -= txtMonto_TextChanged;
            txtValorComercial.TextChanged -= txtMonto_TextChanged;
            txtValorMercado.TextChanged -= txtMonto_TextChanged;
            txtValorEdifica.TextChanged -= txtMonto_TextChanged;
            txtValorNuevo.TextChanged -= txtMonto_TextChanged;
            txtValorVenta.TextChanged -= txtMonto_TextChanged;
            txtMonGarantia.TextChanged -= txtMonto_TextChanged;
            txtValorRealiza.TextChanged -= txtMonto_TextChanged;

            txtMaximoGar.Leave -= txtMaximoGar_Leave;

            txtMonGarantia.TextChanged -= txtMonGarantia_TextChanged;
            txtValorRealiza.TextChanged -= txtValorRealiza_TextChanged;

            txtMonGravamenSol.Text = "0.00";
            txtMonGravamen.Text = "0.00";
            txtValorRealiza.Text = "0.00";
            txtValorComercial.Text = "0.00";
            txtValorMercado.Text = "0.00";
            txtValorEdifica.Text = "0.00";
            txtValorNuevo.Text = "0.00";
            txtValorVenta.Text = "0.00";
            txtMaximoGar.Text = "0.00";
            txtMonGarantia.Text = "0.00";
            txtValorContable.Text = "0.00";
            txtValorConstituido.Text = "0.00";


            txtMonGravamenSolCon.Text = "0.00";
            txtMonGravCon.Text = "0.00";
            txtValorReaCon.Text = "0.00";
            txtValorComCon.Text = "0.00";
            txtValorMercCon.Text = "0.00";
            txtValorEdiCon.Text = "0.00";
            txtValorNueCon.Text = "0.00";
            txtValorVentaCon.Text = "0.00";
            txtMaximoGarCon.Text = "0.00";
            txtMonGarCon.Text = "0.00";
            txtValorContableCon.Text = "0.00";
            txtValorConstituidoCon.Text = "0.00";



            txtMonGravamenSol.TextChanged += txtMonto_TextChanged;
            txtMonGravamen.TextChanged += txtMonto_TextChanged;
            txtValorComercial.TextChanged += txtMonto_TextChanged;
            txtValorMercado.TextChanged += txtMonto_TextChanged;
            txtValorEdifica.TextChanged += txtMonto_TextChanged;
            txtValorNuevo.TextChanged += txtMonto_TextChanged;
            txtValorVenta.TextChanged += txtMonto_TextChanged;
            txtMonGarantia.TextChanged += txtMonto_TextChanged;
            txtValorRealiza.TextChanged += txtMonto_TextChanged;
            txtValorContable.TextChanged += txtMonto_TextChanged;
            txtValorConstituido.TextChanged += txtMonto_TextChanged;
            

            txtMaximoGar.Leave += txtMaximoGar_Leave;

            txtMonGarantia.TextChanged += txtMonGarantia_TextChanged;
            txtValorRealiza.TextChanged += txtValorRealiza_TextChanged;
        }

        private void LimpiarPropietarios()
        {
            txtMonGarCli.Text = "0.00";
            txtMonPorcentaje.Text = "0.00";
            txtMonGravCli.Text = "0.00";
            txtMonSaldo.Text = "0.00";

            dtgDetGarantia.DataSource = null;
            conDatCliPropGarantia.limpiarcontroles();
        }

        private void LimpiarAvalados()
        {
            dtgGarPerAval.DataSource = null;
            conDatCliGarantizado.limpiarcontroles();
        }

        private void HabControles(bool estado)
        {
            pnlDatGar.Enabled = estado;
            pnlPropGar.Enabled = estado;
            pnlAvalados.Enabled = estado;
            pnlUbigGar.Enabled = estado;

            pnlTipGar.Enabled = estado;
            pnlObs.Enabled = estado;
            grbMontos.Enabled = estado;
            btnBuscaCtaAho.Enabled = estado;
            dtgGarantias.Enabled = !estado;

            btnAgregarCli.Enabled = estado;
            btnQuitarCli.Enabled = estado;
            txtMonGarCli.Enabled = estado;
            btnBusCliente.Enabled = estado;

            btnBusCliAval.Enabled = estado;
            btnAgregarAval.Enabled = estado;
            btnQuitarAval.Enabled = estado;
        }

        private void BindingClienteGar()
        {
            dtgDetGarantia.SelectionChanged -= dtgDetGarantia_SelectionChanged;

            dtgDetGarantia.DataSource = null;
            dtgDetGarantia.DataSource = _objGarantia.lisDetGarantia;
            dtgDetGarantia.ClearSelection();

            dtgDetGarantia.SelectionChanged += dtgDetGarantia_SelectionChanged;

            if (dtgDetGarantia.RowCount > 0)
            {
                dtgDetGarantia.Rows[0].Selected = true;
            }

            MostrarConsolidado();
        }

        private void AgregarCli()
        {
            if (string.IsNullOrEmpty(conDatCliPropGarantia.txtCodCli.Text.Trim()))
            {
                MessageBox.Show("Por favor seleccione un cliente a vincular",
                                "Validar cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            var result = _objGarantia.lisDetGarantia.Where(x => x.idCli == conDatCliPropGarantia.cliente.idCli);

            if (result.Any())
            {
                MessageBox.Show("Ya agregó a cliente: " + conDatCliPropGarantia.txtNombre.Text.Trim(),
                                    "Validación Interviniente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                btnBusCliente.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMonGarCli.Text) || txtMonGarCli.nvalor == 0)
            {
                MessageBox.Show("Por favor ingrese un valor de garantía de interviniente",
                                    "Validación Garantía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                txtMonGarCli.Focus();
                txtMonGarCli.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtMonPorcentaje.Text) || txtMonPorcentaje.nvalor == 0)
            {
                MessageBox.Show("Por favor ingrese el porcentaje de garantía de interviniente", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonPorcentaje.Focus();
                txtMonPorcentaje.SelectAll();
                return;
            }

            decimal nTotGarantia = _objGarantia.lisDetGarantia.Sum(x => x.nMonGarantia);

            if (nTotGarantia == txtValorRealiza.nDecValor)
            {
                MessageBox.Show("Ya se cubrio el 100% de la garantia",
                                    "Validar monto garantía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            decimal nGarantiaFalta = txtMonGarantia.nDecValor - nTotGarantia;
            decimal nGarantiaNew = txtMonGarCli.nDecValor + nTotGarantia;

            if (Convert.ToDecimal(txtMonGarantia.nvalor) < nGarantiaNew)
            {
                MessageBox.Show("Debe ingresa un monto de garantía menor igual a: " + nGarantiaFalta.ToString(),
                                    "Validar monto garantía",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                txtMonGarantia.Focus();
                txtMonGarantia.SelectAll();
                return;
            }

            decimal nPorcentaje = txtMonPorcentaje.nDecValor;
            if (txtMonGarCli.nDecValor == nGarantiaFalta)
            {
                decimal nPorcAcum = _objGarantia.lisDetGarantia.Sum(x => x.nPorcentaje);
                nPorcentaje = 100 - nPorcAcum;
            }

            bool lPropietario = _objGarantia.lisDetGarantia.Count() == 0;

            _objGarantia.lisDetGarantia.Add(new clsDetGarantia()
            {
                idCli = Convert.ToInt32(conDatCliPropGarantia.cliente.idCli),
                nMonGarantia = Convert.ToDecimal(txtMonGarCli.Text),
                nPorcentaje = nPorcentaje,
                nMonGravado = Convert.ToDecimal(txtMonGravCli.Text),
                nMonSaldoGrav = Convert.ToDecimal(txtMonGarCli.Text) - Convert.ToDecimal(txtMonGravCli.Text),
                idCliGarantia = 0,
                idGarantia = 0,
                lPropietario = lPropietario
            });

            BindingClienteGar();
            NuevoRegistroClienteGarantia();
        }

        private void QuitarCli()
        {
            if (dtgDetGarantia.RowCount > 0)
            {
                clsDetGarantia objDetGar = (clsDetGarantia)dtgDetGarantia.SelectedRows[0].DataBoundItem;

                _objGarantia.lisDetGarantia.Remove(objDetGar);

                BindingClienteGar();
                NuevoRegistroClienteGarantia();
            }
        }

        private void NuevoRegistroClienteGarantia(bool limpiarCliente = true)
        {
            if(limpiarCliente)
                conDatCliPropGarantia.limpiarcontroles();

            decimal nMontoAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nMonGarantia);
            decimal nPorcAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nPorcentaje);
            decimal nMontoPorAsignar = txtMonGarantia.nDecValor - nMontoAsignado;
            nMontoPorAsignar = nMontoPorAsignar < 0 ? 0 : nMontoPorAsignar;
            decimal nPorcPorAsignar = 100 - nPorcAsignado;

            txtMonGarCli.Text = nMontoPorAsignar.ToString("#,0.00");
            txtMonPorcentaje.Text = nPorcPorAsignar.ToString("#,0.00");
            txtMonGravCli.Text = "0.00";
            txtMonSaldo.Text = nMontoPorAsignar.ToString("#,0.00");
        }

        private void MostrarConsolidado()
        {
            decimal nMontoAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nMonGarantia);
            decimal nPorcAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nPorcentaje);
            decimal nMontoPorAsignar = txtMonGarantia.nDecValor - nMontoAsignado;

            txtMonAsig.Text = nMontoAsignado.ToString("#,0.00");
            txtPorcAsig.Text = nPorcAsignado.ToString("#,0.00");
            txtMontoPorAsig.Text = nMontoPorAsignar.ToString("#,0.00");
        }

        private void CargarClienteGarantia(clsDetGarantia objDetGar)
        {
            if (conBusCliente.nidTipoPersona == 1)
            {
                conDatCliPropGarantia.cargarCliente(objDetGar.idCli);
            }
            else
            {
                conDatCliPropGarantia.cargarClienteJur(objDetGar.idCli);
            }

            txtMonGarCli.Text = string.Format("{0:#,0.00}", objDetGar.nMonGarantia);
            txtMonGravCli.Text = string.Format("{0:#,0.00}", objDetGar.nMonGravado);
            txtMonPorcentaje.Text = string.Format("{0:#,0.00}", objDetGar.nPorcentaje);
            txtMonSaldo.Text = string.Format("{0:#,0.00}", objDetGar.nMonSaldoGrav);
        }

        private void CargarGarPerAval(DataRowView row)
        {
            if (conBusCliente.nidTipoPersona == 1)
            {
                conDatCliGarantizado.cargarCliente(row.Row.Field<int>("idCli"));
            }
            else
            {
                conDatCliGarantizado.cargarClienteJur(row.Row.Field<int>("idCli"));
            }
        }

        private void CargarEspecificacion(int idGar)
        {
            clsLisEspecificacioGarantia listaespecifica = _objCNGarantia.listarespecificacion(idGar);

            if (listaespecifica.Count() > 0)
            {
                string cTipo = listaespecifica.Where(x => x.cCampo == "tipo").FirstOrDefault().cValCampo.ToUpper();
                switch (cTipo)
                {
                    case "H":
                        rbtHipoteca.Checked = true;
                        txtCodHip.Text = listaespecifica.Where(x => x.cCampo == "codigo").FirstOrDefault().cValCampo;
                        nudAnioHip.Value = Convert.ToDecimal(listaespecifica.Where(x => x.cCampo == "anio").FirstOrDefault().cValCampo);
                        txtCondiHip.Text = listaespecifica.Where(x => x.cCampo == "condicion").FirstOrDefault().cValCampo;
                        txtUsoHip.Text = listaespecifica.Where(x => x.cCampo == "uso").FirstOrDefault().cValCampo;

                        break;
                    case "V":
                        rbtVehiculo.Checked = true;
                        txtCodVehi.Text = listaespecifica.Where(x => x.cCampo == "placa").FirstOrDefault().cValCampo;
                        nudAnioVehi.Value = Convert.ToDecimal(listaespecifica.Where(x => x.cCampo == "anio").FirstOrDefault().cValCampo);
                        txtTipoVehi.Text = listaespecifica.Where(x => x.cCampo == "tipovehiculo").FirstOrDefault().cValCampo;
                        txtUsoVehi.Text = listaespecifica.Where(x => x.cCampo == "uso").FirstOrDefault().cValCampo;

                        break;
                    case "T":
                        rbtTituloValor.Checked = true;
                        txtCodTitu.Text = listaespecifica.Where(x => x.cCampo == "cuenta").FirstOrDefault().cValCampo;
                        dtpFecIniTitu.Value = Convert.ToDateTime(listaespecifica.Where(x => x.cCampo == "fecini").FirstOrDefault().cValCampo);
                        dtpFecFinTitu.Value = Convert.ToDateTime(listaespecifica.Where(x => x.cCampo == "fecfin").FirstOrDefault().cValCampo);

                        break;
                    case "P":
                        rbtPersonal.Checked = true;
                        txtCodPers.Text = listaespecifica.Where(x => x.cCampo == "codentiemi").FirstOrDefault().cValCampo;
                        txtNombrePers.Text = listaespecifica.Where(x => x.cCampo == "nomemisora").FirstOrDefault().cValCampo;
                        dtpFecIniPers.Value = Convert.ToDateTime(listaespecifica.Where(x => x.cCampo == "fecini").FirstOrDefault().cValCampo);
                        dtpFecFinPers.Value = Convert.ToDateTime(listaespecifica.Where(x => x.cCampo == "fecfin").FirstOrDefault().cValCampo);

                        break;
                    case "E":
                        rbtElectros.Checked = true;
                        txtDetElecto.Text = listaespecifica.Where(x => x.cCampo == "detelectro").FirstOrDefault().cValCampo;
                        txtNroFactura.Text = listaespecifica.Where(x => x.cCampo == "factura").FirstOrDefault().cValCampo;
                        nudAnioElectro.Value = Convert.ToDecimal(listaespecifica.Where(x => x.cCampo == "anioelectro").FirstOrDefault().cValCampo);

                        break;
                }
            }
        }

        private clsLisEspecificacioGarantia Especificacion()
        {
            clsLisEspecificacioGarantia listaespecificacion = new clsLisEspecificacioGarantia();
            if (rbtHipoteca.Checked)
            {
                #region Hipoteca
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "codigo",
                    cValCampo = txtCodHip.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "anio",
                    cValCampo = nudAnioHip.Value.ToString(),
                    cTipoDato = "int"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "condicion",
                    cValCampo = txtCondiHip.Text.Trim(),
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "uso",
                    cValCampo = txtUsoHip.Text.Trim(),
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipo",
                    cValCampo = "H",
                    cTipoDato = "string"
                });
                #endregion
            }
            else if (rbtVehiculo.Checked)
            {
                #region Vehiculo
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "placa",
                    cValCampo = txtCodVehi.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "anio",
                    cValCampo = nudAnioVehi.Value.ToString(),
                    cTipoDato = "int"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "uso",
                    cValCampo = txtUsoVehi.Text.Trim(),
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipovehiculo",
                    cValCampo = txtTipoVehi.Text.Trim(),
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipo",
                    cValCampo = "V",
                    cTipoDato = "string"
                });
                #endregion
            }
            else if (rbtTituloValor.Checked)
            {
                #region Titulo Valor
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "cuenta",
                    cValCampo = txtCodTitu.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "fecini",
                    cValCampo = dtpFecIniTitu.Value.ToString("dd/MM/yyyy"),
                    cTipoDato = "datetime"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "fecfin",
                    cValCampo = dtpFecFinTitu.Value.ToString("dd/MM/yyyy"),
                    cTipoDato = "datetime"
                });

                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipo",
                    cValCampo = "T",
                    cTipoDato = "string"
                });
                #endregion
            }
            else if (rbtPersonal.Checked)
            {
                #region Personal
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "codentiemi",
                    cValCampo = txtCodPers.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "nomemisora",
                    cValCampo = txtNombrePers.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "fecini",
                    cValCampo = dtpFecIniPers.Value.ToString("dd/MM/yyyy"),
                    cTipoDato = "datetime"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "fecfin",
                    cValCampo = dtpFecFinPers.Value.ToString("dd/MM/yyyy"),
                    cTipoDato = "datetime"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipo",
                    cValCampo = "p",
                    cTipoDato = "string"
                });
                #endregion
            }
            else if (rbtElectros.Checked)
            {
                #region Electro
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "factura",
                    cValCampo = txtNroFactura.Text,
                    cTipoDato = "string"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "anioelectro",
                    cValCampo = nudAnioElectro.Value.ToString(),
                    cTipoDato = "int"
                });
                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "detelectro",
                    cValCampo = txtDetElecto.Text.Trim(),
                    cTipoDato = "string"
                });

                listaespecificacion.Add(new clsEspecificacioGarantia()
                {
                    idGarantia = _objGarantia.idGarantia,
                    cCampo = "tipo",
                    cValCampo = "E",
                    cTipoDato = "string"
                });
                #endregion
            }

            return listaespecificacion;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Por favor ingresar la descripción de la garantía", "Validación descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTipoCambio.Text.Trim()) || txtTipoCambio.nvalor == 0)
            {
                MessageBox.Show("Por favor ingresar el tipo de cambio", "Validación tipo de cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtTipoCambio.Focus();
                txtTipoCambio.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(txtMonGarantia.Text) || txtMonGarantia.nvalor == 0)
            {
                MessageBox.Show("Por favor ingresar el monto de la garantía", "Validación monto garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtMonGarantia.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtValorComercial.Text) || txtValorComercial.nvalor == 0)
            {
                MessageBox.Show("Por favor ingresar el valor comercial", "Validación valor comercial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtValorComercial.Focus();
                return false;
            }

            //if (string.IsNullOrEmpty(this.txtValorMercado.Text) || this.txtValorMercado.nvalor == 0)
            //{
            //    MessageBox.Show("Por favor ingresar valor de mercado", "Validación mercado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.tbcGarantia.SelectedIndex = 0;
            //    this.txtValorMercado.Focus();
            //    return lEstado;
            //}

            //if (string.IsNullOrEmpty(this.txtValorEdifica.Text) || this.txtValorEdifica.nvalor == 0)
            //{
            //    MessageBox.Show("Por favor ingresa el valor de edificación", "Validación edificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.tbcGarantia.SelectedIndex = 1;
            //    this.txtValorEdifica.Focus();
            //    return lEstado;
            //}

            //if (string.IsNullOrEmpty(this.txtValorNuevo.Text) || this.txtValorNuevo.nvalor == 0)
            //{
            //    MessageBox.Show("Por favor ingresar valor nuevo", "Validación nuevo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.tbcGarantia.SelectedIndex = 1;
            //    this.txtValorNuevo.Focus();
            //    return lEstado;
            //}

            if (string.IsNullOrEmpty(txtValorRealiza.Text.Trim()) || txtValorRealiza.nvalor == 0)
            {
                MessageBox.Show("Por favor ingresar valor realización", "Validación realización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtValorRealiza.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtObservaciones.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar las observaciones", "Validación Garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 0;
                txtObservaciones.Focus();
                return false;
            }

            if (dtgDetGarantia.RowCount < 1)
            {
                MessageBox.Show("Por favor agregar a los intervinientes de la garantía", "Registrar Garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 1;
                btnBusCliente.Focus();
                return false;
            }

            int idCli = conBusCliente.idCli;
            int nCountCli = (from item in (clsListDetGarantia)dtgDetGarantia.DataSource
                             where item.idCli == idCli
                             select item).Count();
            if (nCountCli == 0)
            {
                MessageBox.Show("Por favor agregar al cliente: " + conBusCliente.txtNombre.Text.Trim() + " como interviniente de la garantía",
                                "Validación interviniente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 1;
                btnBusCliente.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                MessageBox.Show("Por favor ingresar la dirección de la garantía", "Validación Garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 3;
                txtDireccion.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtReferencia.Text))
            {
                MessageBox.Show("Por favor ingresar referencia de la dirección", "Validación referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 3;
                txtReferencia.Focus();
                return false;
            }

            //if (Convert.ToInt32(this.conUbigeoGar.cboDistrito.SelectedValue) == 0)
            //{
            //    MessageBox.Show("Por favor seleccione un distrito de la dirección de la garantía", "Validación ubigeo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.tbcGarantia.SelectedIndex = 2;
            //    this.conUbigeoGar.Focus();
            //    return lEstado;
            //}


            //if (rbtHipoteca.Checked && string.IsNullOrEmpty(txtCodHip.Text))
            //{
            //     MessageBox.Show("Por favor ingrese codigo de inscripcion de hipoteca", "Validación Hipoteca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     this.txtCodHip.SelectAll();
            //     this.txtCodHip.Focus();
            //     return lEstado;
            //}

            if (rbtVehiculo.Checked && string.IsNullOrEmpty(txtCodVehi.Text))
            {
                MessageBox.Show("Por favor ingrese el número de placa del vehículo", "Validación vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodVehi.SelectAll();
                txtCodVehi.Focus();
                return false;
            }

            if (rbtTituloValor.Checked && string.IsNullOrEmpty(txtCodTitu.Text))
            {
                MessageBox.Show("Por favor ingrese el numero de cuenta de ahorro en garantía", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodTitu.SelectAll();
                txtCodTitu.Focus();
                return false;
            }

            if (rbtPersonal.Checked && string.IsNullOrEmpty(txtCodPers.Text))
            {
                MessageBox.Show("Por favor ingrese código de persona", "Validación persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodPers.SelectAll();
                txtCodPers.Focus();
                return false;
            }

            if (rbtElectros.Checked && string.IsNullOrEmpty(txtNroFactura.Text))
            {
                MessageBox.Show("Por favor ingrese el número de factura de electrodoméstico en garantía", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroFactura.SelectAll();
                txtNroFactura.Focus();
                return false;
            }

            if (Convert.ToInt32(cboEstadosGarantia.SelectedValue) == 3)
            {
                if (_objGarantia.idGarantia > 0)
                {
                    var dtCreGar = _objCNGarantia.DatosGarantiaCredito(_objGarantia.idGarantia);
                    if (dtCreGar.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtCreGar.Rows)
                        {
                            if (item["idEstado"].ToString() == "5")
                            {
                                MessageBox.Show("El crédito: " + item["idCuenta"].ToString() + " aún se encuentra vigente \n no puede liberar la garantía", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tbcGarantia.SelectedIndex = 0;
                                cboEstadosGarantia.Focus();
                                return false;
                            }
                        }
                    }
                }
            }

            if (dtgGarPerAval.RowCount == 0)
            {
                MessageBox.Show("Registre datos de personas a quienes puede avalar", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcGarantia.SelectedIndex = 2;
                return false;
            }

            if (_objGarantia.idGarantia == 0)
            {
                clsListDetGarantia lstDetGar = dtgDetGarantia.DataSource as clsListDetGarantia;
                if (lstDetGar != null)
                {
                    if (lstDetGar.Sum(x => x.nPorcentaje) != 100)
                    {
                        MessageBox.Show("Se debe registrar el 100% de los propietarios de las garantias.", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbcGarantia.SelectedIndex = 1;
                        return false;
                    }
                }
            }

            if (_objGarantia.idGarantia == 0)
            {
                clsListDetGarantia lstDetGar = dtgDetGarantia.DataSource as clsListDetGarantia;
                if (lstDetGar != null)
                {
                    if (lstDetGar.Sum(x => x.nMonGarantia) != txtMonGarantia.nDecValor)
                    {
                        MessageBox.Show("EL monto de la garantia no coincide con el monto asignado de los propietarios.", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbcGarantia.SelectedIndex = 1;
                        return false;
                    }
                }
            }

            return true;
        }

        private void CargarOpcGarantia()
        {
            rbtHipoteca.Checked = false;
            rbtPersonal.Checked = false;
            rbtTituloValor.Checked = false;
            rbtVehiculo.Checked = false;
            rbtElectros.Checked = false;

            rbtHipoteca.Enabled = false;
            rbtPersonal.Enabled = false;
            rbtTituloValor.Enabled = false;
            rbtVehiculo.Enabled = false;
            rbtElectros.Enabled = false;

            grbHipoteca.Visible = false;
            grbVehiculo.Visible = false;
            grbTituloValor.Visible = false;
            grbPersonal.Visible = false;
            grbPrenda.Visible = false;

            if (cboTipoGarantia.SelectedIndex >= 0)
            {
                int idTipoGarantia = (int)cboTipoGarantia.SelectedValue;
                
                string cTipoGarantiaHipoteca = Convert.ToString(clsVarApl.dicVarGen["idTipoGarantiaHipoteca"]);
                int[] idTipoGarantiaHipoteca = cTipoGarantiaHipoteca.Split(',').Select(h => Int32.Parse(h)).ToArray();

                string cTipoGarantiaVehiculo = Convert.ToString(clsVarApl.dicVarGen["idTipoGarantiaVehiculo"]);
                int[] idTipoGarantiaVehiculo = cTipoGarantiaVehiculo.Split(',').Select(h => Int32.Parse(h)).ToArray();

                string cTipoGarantiaTituloValor = Convert.ToString(clsVarApl.dicVarGen["idTipoGarantiaTituloValor"]);
                int[] idTipoGarantiaTituloValor = cTipoGarantiaTituloValor.Split(',').Select(h => Int32.Parse(h)).ToArray();

                string cTipoGarantiaPersonal = Convert.ToString(clsVarApl.dicVarGen["idTipoGarantiaPersonal"]);
                int[] idTipoGarantiaPersonal = cTipoGarantiaPersonal.Split(',').Select(h => Int32.Parse(h)).ToArray();

                string cTipoGarantiaPrenda = Convert.ToString(clsVarApl.dicVarGen["idTipoGarantiaPrenda"]);
                int[] idTipoGarantiaPrenda = cTipoGarantiaPrenda.Split(',').Select(h => Int32.Parse(h)).ToArray();


                if (idTipoGarantiaHipoteca.Contains(idTipoGarantia) || idTipoGarantia == Convert.ToInt32(clsVarApl.dicVarGen["nTipoGaranCFHipoteca"]))
                {
                    rbtHipoteca.Checked = true;
                    grbHipoteca.Visible = true;
                }
                if (idTipoGarantiaVehiculo.Contains(idTipoGarantia))
                {
                    rbtVehiculo.Checked = true;
                    grbVehiculo.Visible = true;
                }

                if (idTipoGarantiaTituloValor.Contains(idTipoGarantia) || idTipoGarantia == Convert.ToInt32(clsVarApl.dicVarGen["nTipoGaranCFLiquida"]))
                {
                    rbtTituloValor.Checked = true;
                    grbTituloValor.Visible = true;
                }

                if (idTipoGarantiaPersonal.Contains(idTipoGarantia))
                {
                    rbtPersonal.Checked = true;
                    grbPersonal.Visible = true;
                }

                if (idTipoGarantiaPrenda.Contains(idTipoGarantia))
                {
                    rbtElectros.Checked = true;
                    grbPrenda.Visible = true;
                }
            }

            if (eTransaccion == Transaccion.Nuevo)
            {
                txtValorComercial.Enabled = !rbtTituloValor.Checked;
                txtValorMercado.Enabled = !rbtTituloValor.Checked;
                txtValorEdifica.Enabled = !rbtTituloValor.Checked;
                txtValorNuevo.Enabled = !rbtTituloValor.Checked;
                txtValorRealiza.Enabled = !rbtTituloValor.Checked;
                txtValorVenta.Enabled = !rbtTituloValor.Checked;
                txtMaximoGar.Enabled = true;
            }

            CargarSituacionGarantia();
        }

        private bool ValidarExisteGarantia(string cCodigo)
        {
            clsListGarantia listaGara = _objCNGarantia.buscarGarantias(cCodigo);

            if (listaGara.Count > 0)
            {
                MessageBox.Show("Ya existe registro de garantía con código: " + listaGara[0].idGarantia.ToString() +
                                " \n Descripción: " + listaGara[0].cGarantia.ToString().Trim(),
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void AgregarTitulares(int idCuenta)
        {
            DataTable dtIntervinientes = _objCNIntervCre.CNdtIntervCre(idCuenta, (int)Modulo.AHORROS);
            var filterSoloTitulares = dtIntervinientes.AsEnumerable().Where(x => (int)x["idTipoInterv"] == 6);

            _objGarantia.lisDetGarantia = new clsListDetGarantia();

            foreach (DataRow item in filterSoloTitulares.ToList())
            {
                _objGarantia.lisDetGarantia.Add(new clsDetGarantia()
                {
                    idCli = (int)item["idCli"],
                    nMonGarantia = 0,
                    nPorcentaje = Math.Round(100.00M / filterSoloTitulares.Count(), 2),
                    nMonGravado = 0,
                    nMonSaldoGrav = 0,
                    idCliGarantia = 0,
                    idGarantia = 0
                });
            }
        }

        private void AsignarMontosTitulares(decimal nMonto)
        {
            foreach (var detGar in _objGarantia.lisDetGarantia)
            {
                detGar.nMonGarantia = Math.Round(nMonto / _objGarantia.lisDetGarantia.Count, 2);
                detGar.nMonSaldoGrav = detGar.nMonGarantia - detGar.nMonGravado;
            }

            decimal nMontoAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nMonGarantia);
            decimal nResto = nMonto - nMontoAsignado;
            decimal nPorcAsignado = _objGarantia.lisDetGarantia.Sum(x => x.nPorcentaje);
            decimal nRestoPorc = 100 - nPorcAsignado;

            if (nResto != 0 || nRestoPorc != 0)
            {
                clsDetGarantia objDetAjuste = _objGarantia.lisDetGarantia.Last();
                objDetAjuste.nMonGarantia += nResto;
                objDetAjuste.nPorcentaje += nRestoPorc;
                objDetAjuste.nMonSaldoGrav = objDetAjuste.nMonGarantia - objDetAjuste.nMonGravado;
            }

            _objGarantia.lisDetGarantia.First().lPropietario = true;

            BindingClienteGar();

            btnAgregarCli.Enabled = false;
            btnQuitarCli.Enabled = false;
        }

        private void AsignarMontosAhorros(decimal nMonto)
        {
            txtValorRealiza.Text = string.Format("{0:#,0.00}", nMonto);
            txtMaximoGar.Text = string.Format("{0:#,0.00}", nMonto);
            txtValorComercial.Text = string.Format("{0:#,0.00}", nMonto);
            txtValorMercado.Text = string.Format("{0:#,0.00}", nMonto);
            txtValorEdifica.Text = string.Format("{0:#,0.00}", nMonto);
            txtValorNuevo.Text = string.Format("{0:#,0.00}", nMonto);
            txtValorVenta.Text = string.Format("{0:#,0.00}", nMonto);
        }

        private void BindigGarPerAval()
        {
            dtgGarPerAval.SelectionChanged -= dtgGarPerAval_SelectionChanged;

            dtgGarPerAval.DataSource = null;
            dtgGarPerAval.DataSource = _objGarantia.dtGarPerAval;
            FormatoGridGarPerAval();
            dtgGarPerAval.ClearSelection();

            dtgGarPerAval.SelectionChanged += dtgGarPerAval_SelectionChanged;

            if (dtgGarPerAval.RowCount > 0)
            {
                dtgGarPerAval.Rows[0].Selected = true;
            }
        }

        private void AgregarPerAval()
        {
            if (conDatCliGarantizado.cliente == null)
            {
                MessageBox.Show("Debe de seleccionar primero a un cliente",
                                    "Validación de persona",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            var nExisteCliente = _objGarantia.dtGarPerAval.AsEnumerable()
                                    .Where(x => x.Field<int>("idCli") == conDatCliGarantizado.cliente.idCli);

            if (nExisteCliente.Any())
            {
                MessageBox.Show("Cliente seleccionado ya fue agregado",
                                    "Validación de persona",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            DataRow drGarPerAval = _objGarantia.dtGarPerAval.NewRow();
            drGarPerAval["idGarantia"] = _objGarantia.idGarantia;
            drGarPerAval["idCli"] = conDatCliGarantizado.cliente.idCli;
            drGarPerAval["lVigente"] = true;
            drGarPerAval["cNombre"] = conDatCliGarantizado.cliente.cNomCli;
            drGarPerAval["cDocumentoID"] = conDatCliGarantizado.cliente.cDocumentoID;
            drGarPerAval["idTipoDocumento"] = conDatCliGarantizado.cliente.idTipoDocumento;
            drGarPerAval["cTipoDocumento"] = "";
            _objGarantia.dtGarPerAval.Rows.Add(drGarPerAval);

            BindigGarPerAval();
        }

        private void QuitarPerAval()
        {
            if (dtgGarPerAval.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccion el cliente a quitar.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            if (conBusCliente.idCli == (int)dtgGarPerAval.SelectedRows[0].Cells["idCli"].Value)
            {
                MessageBox.Show("No puede quitar al dueño de la garantía",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            _objGarantia.dtGarPerAval.Rows.RemoveAt(dtgGarPerAval.SelectedRows[0].Index);

            BindigGarPerAval();
        }

        private void FormatoGridGarPerAval()
        {
            foreach (DataGridViewColumn item in dtgGarPerAval.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgGarPerAval.Columns["idCli"].Visible = true;
            dtgGarPerAval.Columns["cNombre"].Visible = true;
            dtgGarPerAval.Columns["cTipoDocumento"].Visible = true;
            dtgGarPerAval.Columns["cDocumentoID"].Visible = true;

            dtgGarPerAval.Columns["idCli"].HeaderText = "Cod.Cliente";
            dtgGarPerAval.Columns["cNombre"].HeaderText = "Nombres/Razón Social";
            dtgGarPerAval.Columns["cTipoDocumento"].HeaderText = "Tipo Doc.";
            dtgGarPerAval.Columns["cDocumentoID"].HeaderText = "Documento";

            dtgGarPerAval.Columns["idCli"].FillWeight = 10;
            dtgGarPerAval.Columns["cNombre"].FillWeight = 50;
            dtgGarPerAval.Columns["cTipoDocumento"].FillWeight = 20;
            dtgGarPerAval.Columns["cDocumentoID"].FillWeight = 20;
        }

        private void AsignarValorConvertido(object sender, TextBox txtDestination = null)
        {
            decimal nMonto;
            decimal nMontoConvertido = 0M;
            TextBox txt = sender as TextBox;
            if (txt == null)
                return;

            if (!decimal.TryParse(txt.Text, out nMonto))
                return;

            if (txtDestination == null)
            {
                string nameTxtDestination = controlsResult[txt.Name];
                var result = Controls.Find(nameTxtDestination, true);

                if (!result.Any())
                    return;

                txtDestination = result.First() as TextBox;
                if (txtDestination == null)
                    return;
            }

            if (txtTipoCambio.nDecValor != 0)
                nMontoConvertido = CalcularMontoConvertido(nMonto);

            txtDestination.Text = string.Format("{0:#,0.00}", nMontoConvertido);
        }

        private decimal CalcularMontoConvertido(decimal nMonto)
        {
            decimal nMontoConvertido = 0M;
            int idMoneda = (int)cboMoneda.SelectedValue;
            nMontoConvertido = idMoneda == 1 ? nMonto / txtTipoCambio.nDecValor : nMonto * txtTipoCambio.nDecValor;
            return nMontoConvertido;
        }

        private void CargarSituacionGarantia()
        {
            int idTipoSituacion = rbtVehiculo.Checked ? 2 : 1;
            var dtSituacion = _objCNGarantia.CNListarSituacionGarantiaIdTipoSituacion(idTipoSituacion);

            cboSituacion.DisplayMember = "cSituacion";
            cboSituacion.ValueMember = "idSituacionSbs";
            cboSituacion.DataSource = dtSituacion;
        }

        private void CargarTipoEmisor()
        {
            var dtSituacion = _objCNGarantia.CNListarTipoEmisorGarantia();

            cboTipoEmisor.DisplayMember = "cTipoEmisor";
            cboTipoEmisor.ValueMember = "cCodSbs";
            cboTipoEmisor.DataSource = dtSituacion;
            cboTipoEmisor.SelectedValue = 10;
        }

        private void CargaDatoValorContable()
        {

            decimal dValorRealiza;
            decimal dValorComercial;
            decimal dValorConstituido;


            if (String.IsNullOrEmpty(txtValorRealiza.Text))
                dValorRealiza = 0.0m;
            else
                dValorRealiza = Convert.ToDecimal(txtValorRealiza.Text);

            if (String.IsNullOrEmpty(txtValorComercial.Text))
                dValorComercial = 0.0m;
            else
                dValorComercial = Convert.ToDecimal(txtValorComercial.Text);

            if (String.IsNullOrEmpty(txtValorConstituido.Text))
                dValorConstituido = 0.0m;
            else
                dValorConstituido = Convert.ToDecimal(txtValorConstituido.Text);

            if (dValorRealiza <= dValorComercial && dValorRealiza <= dValorConstituido)
            {
                txtValorContable.Text = string.Format("{0:#,0.00}", dValorRealiza); //Convert.ToString(dValorRealiza);
            }
            else
            {
                if (dValorComercial < dValorConstituido)
                {
                    txtValorContable.Text = string.Format("{0:#,0.00}", dValorComercial); //Convert.ToString(dValorComercial);
                }
                else
                {
                    txtValorContable.Text = string.Format("{0:#,0.00}", dValorConstituido); //Convert.ToString(dValorConstituido);
                }

            }

        }


        #endregion

        private void txtValorConstituido_TextChanged(object sender, EventArgs e)
        {
            CargaDatoValorContable();
        }

        private void txtValorRealiza_TextChanged_1(object sender, EventArgs e)
        {
            CargaDatoValorContable();
        }

        private void txtValorComercial_TextChanged(object sender, EventArgs e)
        {
            CargaDatoValorContable();
        }



    }
}
