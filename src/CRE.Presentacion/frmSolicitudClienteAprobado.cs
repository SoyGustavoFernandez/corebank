using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmSolicitudClienteAprobado : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();

        DataTable dtOfertaCredito = new DataTable();
        DataTable dtDestino = new DataTable();
        DataTable dtTasa = new DataTable();
        DataTable dtAprobarSolicitudEAI = new DataTable();
        DataTable dtSolicitud = new DataTable();
        DataTable dtNroCredEAI = new DataTable();
        
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        public bool lSolicitudAprob = false;
        int idUsuario;
        int idEstablecimiento;
        int idCli;
        int idSolicitud = 0;
        int idOferta;
        String cDocumentoID;
        Decimal nSaldoOferta;

        public frmSolicitudClienteAprobado()
        {
            InitializeComponent();
        }
        public frmSolicitudClienteAprobado(int idUsuario, int idEstablecimiento, int idCli, String cDocumentoID, int idOferta, DataTable dtNroCredEAI, Decimal nSaldoOferta)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idEstablecimiento = idEstablecimiento;
            this.idCli = idCli;
            this.idOferta = idOferta;
            this.dtNroCredEAI = dtNroCredEAI;
            this.cDocumentoID = cDocumentoID;
            this.nSaldoOferta = nSaldoOferta;

            dtSolicitud = cnCredito.CNRecuperaSolicitudEAI(idCli, idOferta);

            cboDetalleGasto1.listarDetalleGastoEnSolicitud();

            if (dtSolicitud.Rows.Count == 0)
            {
                cargarOferta();
            }
            else 
            {
                idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"].ToString());
                cargarSolicitud();
            }

        }
        private void cambiarClasificacionInterna(int idCli, int idClasifInterna)
        {
            clsCNBuscarCli ClasifInterna = new clsCNBuscarCli();
            DataTable dtClasifCliente = ClasifInterna.CNCambiarClasificacionInterna(idCli, idClasifInterna);
            if (dtClasifCliente.Rows.Count > 0)
                MessageBox.Show("Se actualizó la clasificacion del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al actualizar la clasificacion del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void cargarOferta()
        {
            dtOfertaCredito = cnCredito.CNCargarSolicitudCamp(idCli, idOferta);
            dtDestino = cnCredito.CNListarDestinoEAI(Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()));

            if (String.IsNullOrEmpty(Convert.ToString(dtOfertaCredito.Rows[0]["idClasifInterna"].ToString())) ||
                Convert.ToString(dtOfertaCredito.Rows[0]["idClasifInterna"].ToString()) == "0")
            {
                cambiarClasificacionInterna(idCli, 0);
                dtOfertaCredito.Clear();
                dtOfertaCredito = cnCredito.CNCargarSolicitudCamp(idCli, idOferta);
            }

            cboDestino.DisplayMember = "cDestino";
            cboDestino.ValueMember = "idDestino";
            cboDestino.DataSource = dtDestino;
            cboDestino.SelectedValue = 31;

            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
                        
            txtDNI.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cDocumentoId"].ToString());
            txtClasifInterna.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cClasifInterna"].ToString());
            txtNombre.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cNombreCliOferta"].ToString());

            //if(Convert.ToInt32(dtNroCredEAI.Rows[0]["nNroCreditos"].ToString()) == 2)
            if (dtNroCredEAI.Rows.Count == 0)
            {
                txtMonto.Text = Convert.ToString(dtOfertaCredito.Rows[0]["nMontoOferta"].ToString());
            }
            else 
            {
                txtMonto.Text = Convert.ToString(nSaldoOferta);
                if (Convert.ToDouble(txtMonto.Text) < 300)
                {
                    MessageBox.Show("El Saldo de la Oferta es menor a S/ 300.00.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnAprobar.Enabled = false;
                    txtDNI.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    txtClasifInterna.ReadOnly = true;
                    txtIdSolicitud.Enabled = false;
                    txtMonto.Enabled = false;
                    txtSaldoADescontar.Enabled = false;
                    txtMontoCobrar.Enabled = false;
                    txtPlazo.Enabled = false;
                    txtProducto.Enabled = false;
                    cboDestino.Enabled = false;
                    txtTasa.Enabled = false;
                    dpFechaPago.Enabled = false;
                    cboDetalleGasto1.Enabled = false;
                    btnAprobar.Enabled = false;
                    btnCargaArhivos.Enabled = false;
                    return;
                }
            }

            if (String.IsNullOrEmpty(Convert.ToString(dtOfertaCredito.Rows[0]["nSaldoCapital"].ToString())))
            {
                txtSaldoADescontar.Text = "0";

                if (nSaldoOferta > 0)
                {
                    txtMontoCobrar.Text = Convert.ToString(nSaldoOferta);
                }
                else
                {
                    MessageBox.Show("El Saldo de la Oferta es menor a S/ 300.00.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                txtSaldoADescontar.Text = Convert.ToString(dtOfertaCredito.Rows[0]["nSaldoCapital"].ToString());
                Decimal nMontoOferta, nSaldoCapital;
                nMontoOferta = Convert.ToDecimal(dtOfertaCredito.Rows[0]["nMontoOferta"].ToString());
                nSaldoCapital = Convert.ToDecimal(dtOfertaCredito.Rows[0]["nSaldoCapital"].ToString());
                txtMontoCobrar.Text = Convert.ToString(nSaldoOferta - nSaldoCapital);
            }

            txtPlazo.Text = Convert.ToString(dtOfertaCredito.Rows[0]["nPlazo"].ToString());
            txtProducto.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cProducto"].ToString());
            dtTasa = TasaCredito.ListaTasaCredito(Convert.ToInt32(txtPlazo.Text) * 30,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()),
                                                    Convert.ToDecimal(txtMonto.Text),
                                                    1,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idAgencia"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idOperacion"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idClasifInterna"].ToString()));

            if (dtTasa.Rows.Count > 0)
            {
                lblTMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"].ToString());
                lblTMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString());
            }
            else
            {
                lblTMin.Text = Convert.ToString(0);
                lblTMax.Text = Convert.ToString(0);
                txtTasa.Text = Convert.ToString(0);
                MessageBox.Show("No se encuentra tasa para la oferta del cliente.", "Validación de Tasa Efectivo al Instante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAprobar.Enabled = false;
                return;
            }
            
            dpFechaPago.MinDate = clsVarGlobal.dFecSystem.AddDays(25);
            dpFechaPago.MaxDate = clsVarGlobal.dFecSystem.AddDays(50);
            dpFechaPago.Value = clsVarGlobal.dFecSystem.AddDays(25);

            txtDNI.ReadOnly = true;
            txtClasifInterna.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtSaldoADescontar.ReadOnly = true;
            txtMontoCobrar.ReadOnly = true;
            txtProducto.ReadOnly = true;
            txtIdSolicitud.ReadOnly = true;

            btnCargaArhivos.Enabled = false;
        }
        public void cargarSolicitud()
        {
            dtOfertaCredito = cnCredito.CNCargarSolicitudCamp(idCli, idOferta);
            dtDestino = cnCredito.CNListarDestinoEAI(Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()));

            cboDestino.DisplayMember = "cDestino";
            cboDestino.ValueMember = "idDestino";
            cboDestino.DataSource = dtDestino;
            cboDestino.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idDestino"].ToString());
            cboDetalleGasto1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idDetalleGasto"].ToString());

            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();

            txtDNI.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cDocumentoId"].ToString());
            txtClasifInterna.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cClasifInterna"].ToString());
            txtNombre.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cNombreCliOferta"].ToString());

            txtIdSolicitud.Text = Convert.ToString(dtSolicitud.Rows[0]["idsolicitud"].ToString());
            txtMonto.Text = Convert.ToString(dtSolicitud.Rows[0]["nCapitalSolicitado"].ToString());
            txtSaldoADescontar.Text = Convert.ToString(dtSolicitud.Rows[0]["nSaldoCreditos"].ToString());

            txtMontoCobrar.Text = Convert.ToString(Convert.ToDecimal(txtMonto.Text) - Convert.ToDecimal(txtSaldoADescontar.Text));

            txtPlazo.Text = Convert.ToString(dtOfertaCredito.Rows[0]["nPlazo"].ToString());
            txtProducto.Text = Convert.ToString(dtOfertaCredito.Rows[0]["cProducto"].ToString());
            dtTasa = TasaCredito.ListaTasaCredito(Convert.ToInt32(txtPlazo.Text) * 30,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()),
                                                    Convert.ToDecimal(txtMonto.Text),
                                                    1,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idAgencia"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idOperacion"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idClasifInterna"].ToString()));

            lblTMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"].ToString());
            lblTMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString());
            txtTasa.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaCompensatoria"].ToString());

            dpFechaPago.MinDate = clsVarGlobal.dFecSystem.AddDays(25);
            dpFechaPago.MaxDate = clsVarGlobal.dFecSystem.AddDays(50);
            dpFechaPago.Value = Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaPrimeraCuota"].ToString());

            txtDNI.ReadOnly = true;
            txtClasifInterna.ReadOnly = true;
            txtNombre.ReadOnly = true;

            txtIdSolicitud.ReadOnly = true;
            txtMonto.ReadOnly = true;
            txtSaldoADescontar.ReadOnly = true;
            txtMontoCobrar.ReadOnly = true;
            txtPlazo.ReadOnly = true;
            txtProducto.ReadOnly = true;
            cboDestino.Enabled = false;
            txtTasa.ReadOnly = true;
            dpFechaPago.Enabled = false;
            cboDetalleGasto1.Enabled = false;
            btnAprobar.Enabled = false;
        }
        private void cargarTasa()
        {
            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
            dtTasa = TasaCredito.ListaTasaCredito(Convert.ToInt32(txtPlazo.Text) * 30,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()),
                                                    Convert.ToDecimal(txtMonto.Text),
                                                    1,
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idAgencia"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idOperacion"].ToString()),
                                                    Convert.ToInt32(dtOfertaCredito.Rows[0]["idClasifInterna"].ToString()));

            if (dtTasa.Rows.Count > 0)
            {
            lblTMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"].ToString());
            lblTMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString());
            }
            else
            {
                lblTMin.Text = Convert.ToString(0);
                lblTMax.Text = Convert.ToString(0);
                txtTasa.Text = Convert.ToString(0);
                MessageBox.Show("No se encuentra tasa para el monto solicitado.", "Validación de Tasa Efectivo al Instante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAprobar.Enabled = false;
                return;
            }
        }
        private bool validarCalificativo()
        {
            DataTable dtValidarCalificativoEAI = cnCredito.CNValidarCalificativoEAI(idCli);
            if (dtValidarCalificativoEAI.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarCalificativoEAI.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show(Convert.ToString(dtValidarCalificativoEAI.Rows[0]["cMsg"]), "Validación de Calificativo Efectivo al Instante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarMora()
        {
            DataTable dtValidarMoraEAI = cnCredito.CNValidarMoraEAI(idCli);
            if (dtValidarMoraEAI.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarMoraEAI.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show(Convert.ToString(dtValidarMoraEAI.Rows[0]["cMsg"]), "Validación de Mora Efectivo al Instante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarBaseNegativa()
        {
            DataTable dtValidarBaseNegativa = cnCredito.CNValidarBaseNegativa(cDocumentoID);
            if (dtValidarBaseNegativa.Rows.Count > 0)
            {
                MessageBox.Show(Convert.ToString(dtValidarBaseNegativa.Rows[0]["cMotivo"]), "Suspendido - Validación de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAprobar.Enabled = false;
                return true;
            }
            return false;
        }
        private bool validarNroEntidades()
        {
            DataTable dtValidarNroEntidades = cnCredito.CNValidarNroEntidades(idCli);
            if (dtValidarNroEntidades.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidarNroEntidades.Rows[0]["nNroEntidades"]) > 3)
                {
                    MessageBox.Show("El Cliente tiene más de 03 entidades", "Suspendido - Validación de Nro. de Entidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
            }
            return false;
        }
        private bool validarNroCredAct()
        {
            DataTable dtValidarNroCredAct = cnCredito.CNValidarNroCredAct(idCli);
            if (dtValidarNroCredAct.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidarNroCredAct.Rows[0]["nNroCredAct"]) == 0)
                {
                    MessageBox.Show("El cliente debe contar máximo con 03 créditos incluido el crédito a otorgar.", "Suspendido - Validación de Nro. de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
            }
            return false;
        }
        private bool validarEndeudamiento()
        {
            DataTable dtValidarEndeudamiento = cnCredito.CNValidarEndeudamiento(idCli, Convert.ToDecimal(txtMonto.Text));
            if (dtValidarEndeudamiento.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidarEndeudamiento.Rows[0]["nValor"]) == 0)
                {
                    MessageBox.Show("El Cliente supera más del 30% de endeudamiento total con otras entidades financieras.", "Validación de Endeudamiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
            }
            return false;
        }
        private bool validarSolicitudAct()
        {
            int nCodigoSol;
            int idSubProducto = Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString());
            if (String.IsNullOrEmpty(txtIdSolicitud.Text))
            {
                nCodigoSol = 0;
            }
            else
            {
                nCodigoSol = Convert.ToInt32(txtIdSolicitud.Text);
            }

            DataTable dtValidarSolicitudAct = cnCredito.CNValidarSolicitudAct(Convert.ToInt32(idCli), nCodigoSol, idSubProducto);
                        
            if (dtValidarSolicitudAct.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarSolicitudAct.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show("Cliente tiene una solicitud registrada en el formulario “Registro de Solicitud de créditos”.", "Validación de número de solicitudes activas.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarBloqueoEAI()
        {
            //DataTable dtValidarBloqueoEAI = cnCredito.CNValidarBloqueoEAI(Convert.ToInt32(txtCodCliente.Text), Convert.ToInt32(cboSubProducto.SelectedValue.ToString()));
            DataTable dtValidarBloqueoEAI = cnCredito.CNValidarBloqueoEAI(idCli, Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()));
            if (dtValidarBloqueoEAI.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarBloqueoEAI.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show(Convert.ToString(dtValidarBloqueoEAI.Rows[0]["cMsg"]), "Validación de bloqueo para Efectivo al Instante.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = false;
                    //btnGrabar1.Enabled = false;
                    //btnEnviar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarDiaPagoEAI()
        {
            DateTime dFechaPriCuota = Convert.ToDateTime(dpFechaPago.Text);
            DataTable dtValidarDiaPago = cnCredito.CNValidarDiaPagoEAI(dFechaPriCuota);
            if (dtValidarDiaPago.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidarDiaPago.Rows[0]["nValor"]) == 0)
                {
                    MessageBox.Show("Efectivo al Instante: Solo se puede programar los días de pago del 1 al 23 de cada Mes.", "Validación de Fecha de Pago.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAprobar.Enabled = true;
                    return true;
                }
            }
            return false;
        }
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            dtOfertaCredito.Clear();
            dtOfertaCredito = cnCredito.CNCargarSolicitudCamp(idCli, idOferta);

            if (!String.IsNullOrEmpty(dtOfertaCredito.Rows[0]["idEstado"].ToString()))
            {
                if (Convert.ToInt32(dtOfertaCredito.Rows[0]["idEstado"].ToString()) == 6)
                {
                    MessageBox.Show("El crédito a ampliar fue cancelado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAprobar.Enabled = false;
                    return;
                }
            }
            if (String.IsNullOrEmpty(txtTasa.Text))
            {
                MessageBox.Show("No se registro la Tasa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(txtTasa.Text) < Convert.ToDecimal(lblTMin.Text) || Convert.ToDecimal(txtTasa.Text) > Convert.ToDecimal(lblTMax.Text))
            {
                MessageBox.Show("La Tasa debe ser mayor a " + Convert.ToString(lblTMin.Text) + " y menor a " + Convert.ToString(lblTMax.Text) + ".", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(Convert.ToDecimal(txtMonto.Text) <= nSaldoOferta))
            {
                MessageBox.Show("El monto solicitado es mayor al saldo disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(dtOfertaCredito.Rows[0]["idCliVin"].ToString()))
            {
                if (Convert.ToInt32(cboDetalleGasto1.SelectedValue) == 2)
                {
                    MessageBox.Show("No se puede otorgar el Seguro de Desgravamen Conyugal, el cliente no tiene registrado un conyuge.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Convert.ToInt32(cboDestino.SelectedValue) == 1)
            {
                if (Convert.ToInt32(txtPlazo.Text) > 24 || Convert.ToInt32(txtPlazo.Text) < 1)
                {
                    MessageBox.Show("Capital de Trabajo: Hasta 24 meses", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (Convert.ToInt32(cboDestino.SelectedValue) == 30)
            {
                if (Convert.ToInt32(txtPlazo.Text) > 36 || Convert.ToInt32(txtPlazo.Text) < 1)
                {
                    MessageBox.Show("Activo Fijo: Hasta 36 meses", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (Convert.ToInt32(cboDestino.SelectedValue) == 31)
            {
                if (Convert.ToDecimal(txtMonto.Text) > 0 && Convert.ToDecimal(txtMonto.Text) <= 3000)
                {
                    if (Convert.ToInt32(txtPlazo.Text) > 12 || Convert.ToInt32(txtPlazo.Text) < 1)
                    {
                        MessageBox.Show("Libre Disponibilidad: Hasta 12 meses para montos menores o igual a S/ 3000.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (Convert.ToDecimal(txtMonto.Text) > 3000 && Convert.ToDecimal(txtMonto.Text) <= 10000)
                {
                    if (Convert.ToInt32(txtPlazo.Text) > 18 || Convert.ToInt32(txtPlazo.Text) < 1)
                    {
                        MessageBox.Show("Libre Disponibilidad: Hasta 18 meses para montos mayores a S/ 3000.00 y montos menores o igual a S/ 10000.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (Convert.ToDecimal(txtMonto.Text) > 10000 && Convert.ToDecimal(txtMonto.Text) <= 20000)
                {
                    if (Convert.ToInt32(txtPlazo.Text) > 24 || Convert.ToInt32(txtPlazo.Text) < 1)
                    {
                        MessageBox.Show("Libre Disponibilidad: Hasta 24 meses para montos mayores a S/ 10000.00 y montos menores o igual a S/ 20000.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (Convert.ToDecimal(txtMonto.Text) > 20000)
                {
                    if (Convert.ToInt32(txtPlazo.Text) > 36 || Convert.ToInt32(txtPlazo.Text) < 1)
                    {
                        MessageBox.Show("Libre Disponibilidad: Hasta 36 meses para montos mayores a S/ 20000.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            if (validarDiaPagoEAI())
            {
                return;
            }
            if (validarCalificativo())
            {
                return;
            }
            if (validarMora())
            {
                return;
            }
            if (validarBaseNegativa())
            {
                return;
            }
            if (validarNroEntidades())
            {
                return;
            }
            if (validarEndeudamiento())
            {
                return;
            }
            if (validarSolicitudAct())
            {
                return;
            }
            if (validarNroCredAct())
            {
                return;
            }            
            if (validarBloqueoEAI())
            {
                return;
            }
                                    
            DateTime dFechaSistema = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            DateTime dFechaEsperada = dFechaSistema.AddMonths(1);
            int nDiasGracia = Convert.ToInt32((Convert.ToDateTime(dpFechaPago.Text) - dFechaEsperada).TotalDays);
            nDiasGracia = (nDiasGracia < 0) ? 0 : nDiasGracia;

            dtAprobarSolicitudEAI = cnCredito.CNAprobarSolicitudEAI(
                idCli, Convert.ToInt32(dtOfertaCredito.Rows[0]["idProducto"].ToString()), Convert.ToInt32(dtOfertaCredito.Rows[0]["idOperacion"].ToString()),
                idUsuario, Convert.ToInt32(txtPlazo.Text), Convert.ToInt32(txtPlazo.Text), Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtTasa.Text),
                Convert.ToDecimal(dtTasa.Rows[0]["nTasaMoratoria"].ToString()), Convert.ToDateTime(clsVarGlobal.dFecSystem), "Campaña Efectivo al Instante", Convert.ToInt32(cboDestino.SelectedValue),
                Convert.ToInt32(dtOfertaCredito.Rows[0]["idAgencia"].ToString()), Convert.ToInt32(dtTasa.Rows[0]["idTasa"].ToString()), 2, nDiasGracia, 0, 
                1, 1, 1, Convert.ToDecimal(txtMontoCobrar.Text),
                Convert.ToDecimal(txtSaldoADescontar.Text), Convert.ToDecimal(txtTasa.Text), 1170, 2,
                "Aprobado por Yuri Martinez", 100,
                idUsuario,
                idEstablecimiento,
                Convert.ToDateTime(dpFechaPago.Text),
                Convert.ToInt32(dtOfertaCredito.Rows[0]["idOferta"].ToString()),
                Convert.ToInt32(cboDetalleGasto1.SelectedValue)

                );
            if (Convert.ToInt32(dtAprobarSolicitudEAI.Rows[0]["idError"].ToString()) == 0)
            {
                MessageBox.Show("Solicitud Aprobada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lSolicitudAprob = true;
            }
            else
            {
                MessageBox.Show("No se aprobó la Solicitud.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dtSolicitud = cnCredito.CNRecuperaSolicitudEAI(idCli, idOferta);
            idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"].ToString());
            txtIdSolicitud.Text = Convert.ToString(dtSolicitud.Rows[0]["idSolicitud"].ToString());

            /*  Guardar Expedientes - Solicitud de Credito  */
            bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Solicitud de Credito", idSolicitud, this);
            if (!lRespuesta)
            {
                return;
            }

            txtIdSolicitud.ReadOnly = true;
            txtMonto.ReadOnly = true;
            txtPlazo.ReadOnly = true;
            txtProducto.ReadOnly = true;
            cboDestino.Enabled = false;
            txtTasa.ReadOnly = true;
            dpFechaPago.Enabled = false;
            cboDetalleGasto1.Enabled = false;
            
            btnCargaArhivos.Enabled = true;
            btnAprobar.Enabled = false;
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(idSolicitud, false);
                frmCargaArchivo.ShowDialog();
            }

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            decimal nMonto = (!String.IsNullOrEmpty(txtMonto.Text)) ? Convert.ToDecimal(txtMonto.Text) : 0;
            decimal nSaldoADescontar = (!String.IsNullOrEmpty(txtSaldoADescontar.Text)) ? Convert.ToDecimal(txtSaldoADescontar.Text) : 0;
            txtMontoCobrar.Text = Convert.ToString(nMonto - nSaldoADescontar);
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMonto.Text) < 300)
            {
                MessageBox.Show("El monto mínimo es S/ 300.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Text = "300.00";
            }
            if (Convert.ToDecimal(txtMonto.Text) > Convert.ToDecimal(nSaldoOferta))
            {
                MessageBox.Show("El monto máximo para esta oferta es S/ " + Convert.ToString(nSaldoOferta) + ",\nrevise el saldo oferta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Text = Convert.ToString(nSaldoOferta);
            }
            if (Convert.ToDecimal(txtMontoCobrar.Text) < 1)
            {
                MessageBox.Show("El Monto a Cobrar no puese ser menor o igual a S/ 0.00", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Text = Convert.ToString(nSaldoOferta);
            }
            cargarTasa();
        }

        private void txtPlazo_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPlazo.Text) < 1)
            {
                MessageBox.Show("El plazo mínimo es: 1", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlazo.Text = "1";
            }
        }

        private void txtTasa_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTasa.Text))
            {
                MessageBox.Show("No se registro la Tasa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (idSolicitud > 0) { }
            else
            {
                if (Convert.ToDecimal(txtTasa.Text) < Convert.ToDecimal(lblTMin.Text))
                {
                    MessageBox.Show("La Tasa mínima es: " + Convert.ToString(lblTMin.Text) + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTasa.Text = Convert.ToString(lblTMin.Text);
                }
                if (Convert.ToDecimal(txtTasa.Text) > Convert.ToDecimal(lblTMax.Text))
                {
                    MessageBox.Show("La Tasa máxima es: " + Convert.ToString(lblTMax.Text) + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTasa.Text = Convert.ToString(lblTMax.Text);
                }
            }
        }

    }
}
