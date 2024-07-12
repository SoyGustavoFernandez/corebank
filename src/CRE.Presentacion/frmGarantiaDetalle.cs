using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CRE.Presentacion
{
    public partial class frmGarantiaDetalle : frmBase
    {
        #region Variables

        public int idTipoGarantia { get; set; }
        public int idMoneda { get; set; }
        public decimal nTipoCambio { get; set; }
        public int idGarantia = 0;
        clsValorizacionGar datValoriza;
        clsPolizaGarantia datPoliza;
        clsRegPubGarantia datRegPublicos;
        clsCNValorizacionGar objvaloriza = new clsCNValorizacionGar();
        clsCNPolizaGarantia ojbpoliza = new clsCNPolizaGarantia();
        clsCNRegPubGarantia objregpub = new clsCNRegPubGarantia();

        #endregion

        #region Eventos

        public frmGarantiaDetalle()
        {
            InitializeComponent();
        }

        public frmGarantiaDetalle(int idGar)
        {
            InitializeComponent();
            idGarantia = idGar;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            this.Size = new Size(644, 680);
            if (idTipoGarantia.In(1, 2,7))
            {
                grbHipoteca.Visible = true;
                grbRRPP.Visible = true;
                grbTitulos.Visible = false;
                grbVehiculo.Visible = true;
                grbHipoteca.Location = new Point(27, 12);
                grbVehiculo.Location = new Point(614, 12);
                this.Size = new Size(1221, 635);
                btnHisTasacion.Location = new Point(btnHisTasacion.Location.X, 520);
                btnCancelar1.Location = new Point(btnCancelar1.Location.X, 520);
                btnEditar1.Location = new Point(btnEditar1.Location.X, 520);
                btnGrabar1.Location = new Point(btnGrabar1.Location.X, 520);
                btnSalir1.Location = new Point(btnSalir1.Location.X, 520);
            }

            else if (idTipoGarantia.In(3, 4, 5))
            {
                grbHipoteca.Visible = false;
                grbRRPP.Visible = true;
                grbTitulos.Visible = false;
                grbVehiculo.Visible = true;
                grbVehiculo.Location = new Point(27, 12);
                grbRRPP.Location = new Point(27,150);
                btnHisTasacion.Location = new Point(btnHisTasacion.Location.X, 375);
                btnCancelar1.Location = new Point(btnCancelar1.Location.X, 375);
                btnEditar1.Location = new Point(btnEditar1.Location.X, 375);
                btnGrabar1.Location = new Point(btnGrabar1.Location.X, 375);
                btnSalir1.Location = new Point(btnSalir1.Location.X, 375);
                Height = 495;
            }

            else if (idTipoGarantia.In(8))
            {
                grbHipoteca.Visible = false;
                grbRRPP.Visible = false;
                grbTitulos.Visible = true;
                grbVehiculo.Visible = false;
                grbTitulos.Location = new Point(27, 12);
                btnHisTasacion.Location = new Point(btnHisTasacion.Location.X, 120);
                btnCancelar1.Location = new Point(btnCancelar1.Location.X, 120);
                btnEditar1.Location = new Point(btnEditar1.Location.X, 120);
                btnGrabar1.Location = new Point(btnGrabar1.Location.X, 120);
                btnSalir1.Location = new Point(btnSalir1.Location.X, 120);
                Height = 245;
            }
            else if (idTipoGarantia.In(6, 9, 20, 21))//SE INCLUYO autoliquidables y carta fianza
            {
                grbHipoteca.Visible = false;
                grbRRPP.Visible = true;
                grbTitulos.Visible = false;
                grbVehiculo.Visible = false;
                grbRRPP.Location = new Point(27, 12);
                this.Height = 365;
                btnHisTasacion.Location = new Point(btnHisTasacion.Location.X, 245);
                btnCancelar1.Location = new Point(btnCancelar1.Location.X, 245);
                btnEditar1.Location = new Point(btnEditar1.Location.X, 245);
                btnGrabar1.Location = new Point(btnGrabar1.Location.X, 245);
                btnSalir1.Location = new Point(btnSalir1.Location.X, 245);

                rbtPriVentaNo.Visible = false;
                rbtPriVentaSi.Visible = false;
                lblPrimeraVenta.Visible = false;
            }
            else
            {
                this.Dispose();
            }

            if (idTipoGarantia.In(12, 2))
            {
                lblAreaCons.Visible = false;
                lblPisos.Visible = false;
                lblParedes.Visible = false;
                lblPuerta.Visible = false;
                lblTecho.Visible = false;
                txtAreaConstruida.Visible = false;
                txtAreaConstruida.Text = "0.0";
                txtNumPisos.Visible = false;
                txtNumPisos.Text = "0";
                cboMaterialesPared.Visible = false;
                cboMaterialesTecho.Visible = false;
                cboMaterialesVentana.Visible = false;
            }
            else
            {
                lblAreaCons.Visible = true;
                lblPisos.Visible = true;
                lblParedes.Visible = true;
                lblPuerta.Visible = true;
                lblTecho.Visible = true;
                txtAreaConstruida.Visible = true;
                txtAreaConstruida.Text = "0.0";
                txtNumPisos.Visible = true;
                txtNumPisos.Text = "0";
                cboMaterialesPared.Visible = true;
                cboMaterialesTecho.Visible = true;
                cboMaterialesVentana.Visible = true;
            }

            this.btnHisTasacion.Visible = grbHipoteca.Visible;
            dtpFecIniPol.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
            dtpFecFinPol.Value = clsVarGlobal.dFecSystem;
            cargarcontroles();
            cargaDatosValorizacion();
            cargaDatosPoliza();
            cargaDatosRegPub();

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void cboZonaRegistral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZonaRegistral.SelectedIndex > 0)
            {
                this.cboSedeRegistral.CargarZonaRegistral(Convert.ToInt32(cboZonaRegistral.SelectedValue));
            }
            else
            {
                cboZonaRegistral.SelectedIndex = 0;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (idTipoGarantia.In(1, 2))
            {
                #region Valorizacion

                if (datValoriza == null) datValoriza = new clsValorizacionGar();

                datValoriza.idGarantia = idGarantia;
                datValoriza.idValorizacion = 0;
                datValoriza.dFecUltVal = dtpFecUltVal.Value;
                datValoriza.dFecVenVal = dtpdFecVenVal.Value;
                datValoriza.idTasador = (int)cboTasadores1.SelectedValue;
                datValoriza.idCondiInmueble = (int)cboCondicionInmueble1.SelectedValue;
                datValoriza.idEstadoConservacion = (int)cboEstadosConservacion1.SelectedValue;
                datValoriza.idMatPared = cboMaterialesPared.SelectedValue == null ? 0 : (int)cboMaterialesPared.SelectedValue;
                datValoriza.idMatTecho = cboMaterialesTecho.SelectedValue == null ? 0 : (int)cboMaterialesTecho.SelectedValue;
                datValoriza.idMatVenPuer = cboMaterialesVentana.SelectedValue == null ? 0 : (int)cboMaterialesVentana.SelectedValue;
                datValoriza.nNumPisos = (int)txtNumPisos.nDecValor;
                datValoriza.nAreaTerreno = txtAreaTerreno.nDecValor;
                datValoriza.nAreaContru = txtAreaConstruida.nDecValor;
                datValoriza.idUsuReg = clsVarGlobal.User.idUsuario;
                datValoriza.idUsuMod = clsVarGlobal.User.idUsuario;
                datValoriza.dFecRegistro = clsVarGlobal.dFecSystem;
                datValoriza.dFecMod = clsVarGlobal.dFecSystem;
                datValoriza.idEstado = 1;

                datValoriza.nValorRealiza = txtValorRealiza.nDecValor;
                datValoriza.nValorEdifica = txtValorEdifica.nDecValor;
                datValoriza.nValorComercial = txtValorComercial.nDecValor;
                datValoriza.nValorMercado = txtValorMercado.nDecValor;
                datValoriza.nValorNuevo = txtValorNuevo.nDecValor;
                datValoriza.nValorVenta = txtValorVenta.nDecValor;

                datValoriza.dValorContable = txtValorContable.nDecValor;
                datValoriza.dValorConstituido = txtValorConstituido.nDecValor;

                objvaloriza.insertaactValorizacion(datValoriza);

                if (datRegPublicos == null) datRegPublicos = new clsRegPubGarantia();

                datRegPublicos.cAsiento = txtAsiento.Text.Trim();
                datRegPublicos.cCodPredio = txtCodPredio.Text.Trim();
                datRegPublicos.cFicha = txtFicha.Text;
                datRegPublicos.cFojas = txtFojas.Text.Trim();
                datRegPublicos.cFolio = txtFolio.Text.Trim();
                datRegPublicos.cPartidIns = txtPartida.Text.Trim();
                datRegPublicos.cPreferente = txtPreferente.Text.Trim();
                datRegPublicos.cRubro = txtRubro.Text.Trim();
                datRegPublicos.cTomo = txtTomo.Text.Trim();
                datRegPublicos.dFecConsGar = dtpFecConsGar.Value;
                datRegPublicos.dFechaMod = clsVarGlobal.dFecSystem;
                datRegPublicos.dFechaReg = clsVarGlobal.dFecSystem;
                datRegPublicos.dFecInsBlo = dtpFecInscripcion.Value;
                datRegPublicos.idEstado = 1;
                datRegPublicos.idGarantia = idGarantia;
                datRegPublicos.idOfiRegis = Convert.ToInt32(this.cboZonaRegistral.SelectedValue);
                datRegPublicos.idRegPub = 0;
                datRegPublicos.idSedeRegis = Convert.ToInt32(this.cboSedeRegistral.SelectedValue);
                datRegPublicos.idTipoCober = Convert.ToInt32(cboCoberturas1.SelectedValue);
                datRegPublicos.idUsuMod = clsVarGlobal.User.idUsuario;
                datRegPublicos.idUsuReg = clsVarGlobal.User.idUsuario;
                datRegPublicos.lPrimeraVenta = rbtPriVentaSi.Checked;
                datRegPublicos.cTituloInscripcion = this.txtTituloInscripcion.Text.Trim();
                objregpub.insertaactRegPubGarantia(datRegPublicos);

                #endregion
            }
            else if (idTipoGarantia.In(6, 9, 20, 21))//SE INCLUYO autoliquidables y carta fianza
            {
                if (datRegPublicos == null) datRegPublicos = new clsRegPubGarantia();

                datRegPublicos.cAsiento = txtAsiento.Text.Trim();
                datRegPublicos.cCodPredio = txtCodPredio.Text.Trim();
                datRegPublicos.cFicha = txtFicha.Text;
                datRegPublicos.cFojas = txtFojas.Text.Trim();
                datRegPublicos.cFolio = txtFolio.Text.Trim();
                datRegPublicos.cPartidIns = txtPartida.Text.Trim();
                datRegPublicos.cPreferente = txtPreferente.Text.Trim();
                datRegPublicos.cRubro = txtRubro.Text.Trim();
                datRegPublicos.cTomo = txtTomo.Text.Trim();
                datRegPublicos.dFecConsGar = dtpFecConsGar.Value;
                datRegPublicos.dFechaMod = clsVarGlobal.dFecSystem;
                datRegPublicos.dFechaReg = clsVarGlobal.dFecSystem;
                datRegPublicos.dFecInsBlo = dtpFecInscripcion.Value;
                datRegPublicos.idEstado = 1;
                datRegPublicos.idGarantia = idGarantia;
                datRegPublicos.idOfiRegis = Convert.ToInt32(this.cboZonaRegistral.SelectedValue);
                datRegPublicos.idRegPub = 0;
                datRegPublicos.idSedeRegis = Convert.ToInt32(this.cboSedeRegistral.SelectedValue);
                datRegPublicos.idTipoCober = Convert.ToInt32(cboCoberturas1.SelectedValue);
                datRegPublicos.idUsuMod = clsVarGlobal.User.idUsuario;
                datRegPublicos.idUsuReg = clsVarGlobal.User.idUsuario;
                datRegPublicos.lPrimeraVenta = rbtPriVentaSi.Checked;
                datRegPublicos.cTituloInscripcion = this.txtTituloInscripcion.Text.Trim();

                objregpub.insertaactRegPubGarantia(datRegPublicos);
            }

            else if (idTipoGarantia.In(3, 4, 5))
            {
                #region Poliza

                if (datPoliza == null) datPoliza = new clsPolizaGarantia();

                datPoliza.idPoliza = 0;
                datPoliza.idGarantia = idGarantia;
                datPoliza.idCompania = (int)cboCompaniasSeguro1.SelectedValue;
                datPoliza.cNumPoliza = txtNumPoliza.Text;
                datPoliza.nCobertura = txtCobertura.nDecValor;
                datPoliza.dFecIniPol = dtpFecIniPol.Value;
                datPoliza.dFecFinPol = dtpFecFinPol.Value;
                datPoliza.nIndSeguro = (int)txtIndicador.nDecValor;
                datPoliza.cNumCerti = txtNumCertificado.Text;
                datPoliza.idUsuReg = clsVarGlobal.User.idUsuario;
                datPoliza.idUsuMod = clsVarGlobal.User.idUsuario;
                datPoliza.dFechaReg = clsVarGlobal.dFecSystem;
                datPoliza.dFechaMod = clsVarGlobal.dFecSystem;
                datPoliza.idEstado = 1;
                datPoliza.nPrima = txtPrima.nDecValor;
                datPoliza.idMoneda = (int)this.cboMoneda1.SelectedValue;
                datPoliza.lPolizaExterna = rbtSiPolizaExt.Checked;
                ojbpoliza.insertaactPoliza(datPoliza);

                if (datRegPublicos == null) datRegPublicos = new clsRegPubGarantia();

                datRegPublicos.cAsiento = txtAsiento.Text.Trim();
                datRegPublicos.cCodPredio = txtCodPredio.Text.Trim();
                datRegPublicos.cFicha = txtFicha.Text;
                datRegPublicos.cFojas = txtFojas.Text.Trim();
                datRegPublicos.cFolio = txtFolio.Text.Trim();
                datRegPublicos.cPartidIns = txtPartida.Text.Trim();
                datRegPublicos.cPreferente = txtPreferente.Text.Trim();
                datRegPublicos.cRubro = txtRubro.Text.Trim();
                datRegPublicos.cTomo = txtTomo.Text.Trim();
                datRegPublicos.dFecConsGar = dtpFecConsGar.Value;
                datRegPublicos.dFechaMod = clsVarGlobal.dFecSystem;
                datRegPublicos.dFechaReg = clsVarGlobal.dFecSystem;
                datRegPublicos.dFecInsBlo = dtpFecInscripcion.Value;
                datRegPublicos.idEstado = 1;
                datRegPublicos.idGarantia = idGarantia;
                datRegPublicos.idOfiRegis = Convert.ToInt32(this.cboZonaRegistral.SelectedValue);
                datRegPublicos.idRegPub = 0;
                datRegPublicos.idSedeRegis = Convert.ToInt32(this.cboSedeRegistral.SelectedValue);
                datRegPublicos.idTipoCober = Convert.ToInt32(cboCoberturas1.SelectedValue);
                datRegPublicos.idUsuMod = clsVarGlobal.User.idUsuario;
                datRegPublicos.idUsuReg = clsVarGlobal.User.idUsuario;
                datRegPublicos.lPrimeraVenta = rbtPriVentaSi.Checked;
                datRegPublicos.cTituloInscripcion = this.txtTituloInscripcion.Text.Trim();
                objregpub.insertaactRegPubGarantia(datRegPublicos);


                #endregion
            }

            else if (idTipoGarantia.In(8))
            {

            }

            if (idTipoGarantia.In(1, 2))
            {
                if (datPoliza == null) datPoliza = new clsPolizaGarantia();
                datPoliza.idPoliza = 0;
                datPoliza.idGarantia = idGarantia;
                datPoliza.idCompania = (int)cboCompaniasSeguro1.SelectedValue;
                datPoliza.cNumPoliza = txtNumPoliza.Text;
                datPoliza.nCobertura = txtCobertura.nDecValor;
                datPoliza.dFecIniPol = dtpFecIniPol.Value;
                datPoliza.dFecFinPol = dtpFecFinPol.Value;
                datPoliza.nIndSeguro = (int)txtIndicador.nDecValor;
                datPoliza.cNumCerti = txtNumCertificado.Text;
                datPoliza.idUsuReg = clsVarGlobal.User.idUsuario;
                datPoliza.idUsuMod = clsVarGlobal.User.idUsuario;
                datPoliza.dFechaReg = clsVarGlobal.dFecSystem;
                datPoliza.dFechaMod = clsVarGlobal.dFecSystem;
                datPoliza.idEstado = 1;
                datPoliza.nPrima = txtPrima.nDecValor;
                datPoliza.idMoneda = (int)this.cboMoneda1.SelectedValue;
                datPoliza.lPolizaExterna = rbtSiPolizaExt.Checked;
                ojbpoliza.insertaactPoliza(datPoliza);
            }

            grbHipoteca.Enabled = false;
            grbRRPP.Enabled = false;
            grbTitulos.Enabled = false;
            grbVehiculo.Enabled = false;
            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
            MessageBox.Show("La información se guardo correctamente", "Registro detalle garantía", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            frmHistorialTasacion frmhistorialtasacion = new frmHistorialTasacion(idGarantia);
            frmhistorialtasacion.ShowDialog();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            grbHipoteca.Enabled = true;
            grbRRPP.Enabled = true;
            grbTitulos.Enabled = true;
            grbVehiculo.Enabled = true;

            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarcontroles();
            cargaDatosValorizacion();
            cargaDatosPoliza();
            cargaDatosRegPub();
            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;
        }

        private void txtValorRealiza_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorReaCon.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorReaCon.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor * nTipoCambio);
                }
            }

            CargaDatoValorContable();
        }

        private void txtValorComercial_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorComCon.Text = string.Format("{0:#,0.00}", txtValorComercial.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorComCon.Text = string.Format("{0:#,0.00}", txtValorComercial.nDecValor * nTipoCambio);
                }
            }

            CargaDatoValorContable();
        }

        private void txtValorMercado_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorMercCon.Text = string.Format("{0:#,0.00}", txtValorMercado.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorMercCon.Text = string.Format("{0:#,0.00}", txtValorMercado.nDecValor * nTipoCambio);
                }
            }
        }

        private void txtValorEdifica_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorEdiCon.Text = string.Format("{0:#,0.00}", txtValorEdifica.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorEdiCon.Text = string.Format("{0:#,0.00}", txtValorEdifica.nDecValor * nTipoCambio);
                }
            }
        }

        private void txtValorNuevo_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorNueCon.Text = string.Format("{0:#,0.00}", txtValorNuevo.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorNueCon.Text = string.Format("{0:#,0.00}", txtValorNuevo.nDecValor * nTipoCambio);
                }
            }
        }

        private void txtValorVenta_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorVentaCon.Text = string.Format("{0:#,0.00}", txtValorVenta.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorVentaCon.Text = string.Format("{0:#,0.00}", txtValorVenta.nDecValor * nTipoCambio);
                }
            }
        }

        private void txtValorConstituido_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorConstituidoCon.Text = string.Format("{0:#,0.00}", txtValorConstituido.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorConstituidoCon.Text = string.Format("{0:#,0.00}", txtValorConstituido.nDecValor * nTipoCambio);
                }
            }
            CargaDatoValorContable();
        }

        private void txtValorContable_TextChanged(object sender, EventArgs e)
        {
            if (nTipoCambio > 0.00M)
            {
                if (idMoneda == 1)
                {
                    txtValorContableCon.Text = string.Format("{0:#,0.00}", txtValorContable.nDecValor / nTipoCambio);
                }
                else
                {
                    txtValorContableCon.Text = string.Format("{0:#,0.00}", txtValorContable.nDecValor * nTipoCambio);
                }
            }
        }

        #endregion

        #region Metodos

        private void cargarcontroles()
        {
            this.cboZonaRegistral.CargarZonaRegistral(0);
            this.cboCondicionInmueble1.cargarLista();
            this.cboTasadores1.cargarActivos();
            this.cboMaterialesPared.cargarListaPared();
            this.cboMaterialesTecho.cargarListaTecho();
            this.cboMaterialesVentana.cargarListaVentana();
            this.cboCompaniasSeguro1.cargarActivas();
            this.cboEstadosConservacion1.cargarActivas();
            this.cboCoberturas1.cargarActivas();
        }

        private void cargaDatosValorizacion()
        {
            if (cboTasadores1.Items.Count == 0)
            {
                MessageBox.Show("No existe Tasador registrado \n por favor registre mediante la opción mantenimiento de tasador",
                    "Validación Tasador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            datValoriza = objvaloriza.retornaDatValoriza(idGarantia);

            if (datValoriza == null) return;

            if (datValoriza.idValorizacion != 0)
            {
                dtpFecUltVal.Value = datValoriza.dFecUltVal;
                dtpdFecVenVal.Value = datValoriza.dFecVenVal;
                cboTasadores1.SelectedValue = datValoriza.idTasador;
                cboCondicionInmueble1.SelectedValue = datValoriza.idCondiInmueble;
                cboEstadosConservacion1.SelectedValue = datValoriza.idEstadoConservacion;
                cboMaterialesPared.SelectedValue = datValoriza.idMatPared;
                cboMaterialesTecho.SelectedValue = datValoriza.idMatTecho;
                cboMaterialesVentana.SelectedValue = datValoriza.idMatVenPuer;
                txtNumPisos.Text = datValoriza.nNumPisos.ToString();
                txtAreaTerreno.Text = datValoriza.nAreaTerreno.ToString();
                txtAreaConstruida.Text = datValoriza.nAreaContru.ToString();
            }
            txtValorRealiza.Text = datValoriza.nValorRealiza.ToString();
            txtValorComercial.Text = datValoriza.nValorComercial.ToString();
            txtValorEdifica.Text = datValoriza.nValorEdifica.ToString();
            txtValorMercado.Text = datValoriza.nValorMercado.ToString();
            txtValorNuevo.Text = datValoriza.nValorNuevo.ToString();
            txtValorVenta.Text = datValoriza.nValorVenta.ToString();

            txtValorContable.Text = datValoriza.dValorContable.ToString();
            txtValorConstituido.Text = datValoriza.dValorConstituido.ToString();
            
            formatoTasacion();

        }

        private void formatoTasacion()
        {
            if (idMoneda == 2)
            {
                txtValorReaCon.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor * nTipoCambio);
                txtValorComCon.Text = string.Format("{0:#,0.00}", txtValorComercial.nDecValor * nTipoCambio);
                txtValorMercCon.Text = string.Format("{0:#,0.00}", txtValorMercado.nDecValor * nTipoCambio);
                txtValorEdiCon.Text = string.Format("{0:#,0.00}", txtValorEdifica.nDecValor * nTipoCambio);
                txtValorNueCon.Text = string.Format("{0:#,0.00}", txtValorNuevo.nDecValor * nTipoCambio);
                txtValorVentaCon.Text = string.Format("{0:#,0.00}", txtValorVenta.nDecValor * nTipoCambio);

                txtValorReaCon.BackColor = Color.FromArgb(192, 255, 255);
                txtValorComCon.BackColor = Color.FromArgb(192, 255, 255);
                txtValorMercCon.BackColor = Color.FromArgb(192, 255, 255);
                txtValorEdiCon.BackColor = Color.FromArgb(192, 255, 255);
                txtValorNueCon.BackColor = Color.FromArgb(192, 255, 255);
                txtValorVentaCon.BackColor = Color.FromArgb(192, 255, 255);

            }
            if (idMoneda == 1 && nTipoCambio > 0.0M)
            {
                txtValorReaCon.Text = string.Format("{0:#,0.00}", txtValorRealiza.nDecValor / nTipoCambio);
                txtValorComCon.Text = string.Format("{0:#,0.00}", txtValorComercial.nDecValor / nTipoCambio);
                txtValorMercCon.Text = string.Format("{0:#,0.00}", txtValorMercado.nDecValor / nTipoCambio);
                txtValorEdiCon.Text = string.Format("{0:#,0.00}", txtValorEdifica.nDecValor / nTipoCambio);
                txtValorNueCon.Text = string.Format("{0:#,0.00}", txtValorNuevo.nDecValor / nTipoCambio);
                txtValorVentaCon.Text = string.Format("{0:#,0.00}", txtValorVenta.nDecValor / nTipoCambio);

                txtValorReaCon.BackColor = Color.FromArgb(192, 255, 192);
                txtValorComCon.BackColor = Color.FromArgb(192, 255, 192);
                txtValorMercCon.BackColor = Color.FromArgb(192, 255, 192);
                txtValorEdiCon.BackColor = Color.FromArgb(192, 255, 192);
                txtValorNueCon.BackColor = Color.FromArgb(192, 255, 192);
                txtValorVentaCon.BackColor = Color.FromArgb(192, 255, 192);
            }
        }

        private void cargaDatosPoliza()
        {
            datPoliza = ojbpoliza.retornadatPoliza(idGarantia);
            if (datPoliza == null) return;

            cboCompaniasSeguro1.SelectedValue = datPoliza.idCompania;
            txtNumPoliza.Text = datPoliza.cNumPoliza;
            txtCobertura.Text = datPoliza.nCobertura.ToString();
            dtpFecIniPol.Value = datPoliza.dFecIniPol;
            dtpFecFinPol.Value = datPoliza.dFecFinPol;
            txtIndicador.Text = datPoliza.nIndSeguro.ToString();
            txtNumCertificado.Text = datPoliza.cNumCerti;
            txtPrima.Text = datPoliza.nPrima.ToString();
            cboMoneda1.SelectedValue = datPoliza.idMoneda;
            rbtSiPolizaExt.Checked = datPoliza.lPolizaExterna;
            rbtNoPolizaExt.Checked = !datPoliza.lPolizaExterna;
        }

        private void cargaDatosRegPub()
        {

            datRegPublicos = objregpub.retornadatRegPubGar(idGarantia);
            if (datRegPublicos == null) return;
            txtAsiento.Text = datRegPublicos.cAsiento;
            txtCodPredio.Text = datRegPublicos.cCodPredio;
            txtFicha.Text = datRegPublicos.cFicha;
            txtFojas.Text = datRegPublicos.cFojas;
            txtFolio.Text = datRegPublicos.cFolio;
            txtPartida.Text = datRegPublicos.cPartidIns;
            txtPreferente.Text = datRegPublicos.cPreferente;
            txtRubro.Text = datRegPublicos.cRubro;
            txtTomo.Text = datRegPublicos.cTomo;
            dtpFecConsGar.Value = datRegPublicos.dFecConsGar;
            dtpFecInscripcion.Value = datRegPublicos.dFecInsBlo;
            cboZonaRegistral.SelectedValue = datRegPublicos.idOfiRegis;
            cboSedeRegistral.SelectedValue = datRegPublicos.idSedeRegis;
            cboCoberturas1.SelectedValue = datRegPublicos.idTipoCober;
            rbtPriVentaSi.Checked = datRegPublicos.lPrimeraVenta;
            rbtPriVentaNo.Checked = !datRegPublicos.lPrimeraVenta;
            txtTituloInscripcion.Text = datRegPublicos.cTituloInscripcion;
        }



        private void CargaDatoValorContable()
        {
            decimal dValorRealiza ;
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
                txtValorContable.Text = Convert.ToString(dValorRealiza);
            }
            else
            {
                if (dValorComercial < dValorConstituido)
                {
                    txtValorContable.Text = Convert.ToString(dValorComercial);
                }
                else
                {
                    txtValorContable.Text = Convert.ToString(dValorConstituido);
                }

            }


        }





        
        #endregion





    }
}
