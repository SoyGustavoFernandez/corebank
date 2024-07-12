using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;

using System.Data;

using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCobroComisionCartaFianza : frmBase
    {
        enum Modo { Editar, Bloqueado };
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza = 0;
        int modoFormulario = (int)Modo.Bloqueado;
        GEN.Funciones.clsFunUtiles funUtiles = new GEN.Funciones.clsFunUtiles();
        int idMoneda = 1;
        Decimal nRedondeoFavCli = 0.00m;
        Decimal nItf = 0.00m;
        
        public frmCobroComisionCartaFianza()
        {
            InitializeComponent();
        }

        private void frmCobroComisionCartaFianza_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[2]";//ESTADO DE LA SOLICITUD
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            //controles((int)Modo.Bloqueado);
            limpiarControles();
            conCalcVuelto.MyKey += conCalcVuelto_MyKey;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro Solicitud: ";
        }

        void conCalcVuelto_MyKey(object sender, EventArgs e)
        {
            btnGrabar1.Enabled = conCalcVuelto.lCorrecto;
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private bool estaEnDatos(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');
            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }
        public void cargarDatos()
        {
            limpiarControles();

            int idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);

            if (idSolicitud != 0)
            {
                DataTable dtDatosCartaFianza = cnCartaFianza.obtenerDatosCartaFianzaAprobada(idSolicitud);

                if (dtDatosCartaFianza.Rows.Count > 0)
                {
                    if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idProducto"]))) //carta fianza                    
                    {
                        MessageBox.Show("La solicitud no corresponde a una carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }

                    if (Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idEstadoCartaFianza"]) != 4)
                    {
                        MessageBox.Show("La carta fianza no se encuentra en estado APROBADO", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }

                    this.idCartaFianza = Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idCartaFianza"]);
                    int idMoneda = Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idMoneda"]);
                    cboMoneda1.SelectedValue = idMoneda;
                    DataTable dtOtrasComisiones = cnCartaFianza.ListarComisionesCartaFianza(idMoneda, Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idProducto"]), Convert.ToInt32(dtDatosCartaFianza.Rows[0]["IdTipoPersona"]), Convert.ToDecimal (dtDatosCartaFianza.Rows[0]["nMonto"]), Convert.ToInt32(dtDatosCartaFianza.Rows[0]["nPlazo"]), Convert.ToInt32(dtDatosCartaFianza.Rows[0]["idAgencia"]));
                    dtgOtrasComisiones.DataSource = dtOtrasComisiones;
                    formatearOtrasComisiones();
                    txtMontoAprobado.Text = dtDatosCartaFianza.Rows[0]["nMonto"].ToString();
                    txtPlazoAprobado.Text = dtDatosCartaFianza.Rows[0]["nPlazo"].ToString();
                    txtCartaFianza.Text = dtDatosCartaFianza.Rows[0]["codCartaFianza"].ToString();                
                    txtFechaInicioAprobado.Text = dtDatosCartaFianza.Rows[0]["dFechaVigencia"].ToString();
                    txtTasaAprobada.Text = dtDatosCartaFianza.Rows[0]["nTasaComision"].ToString();
                    Decimal nComision = Convert.ToDecimal (dtDatosCartaFianza.Rows[0]["nComision"].ToString());
                    txtComision.Text = nComision.ToString("0,0.00");
                    Decimal nSubTotal = nComision + sumarOtrasComisiones();
                    txtSubtotal.Text = nSubTotal.ToString("0,0.00");
                    nItf = (Decimal)clsVarGlobal.nITF / 100.00m * nSubTotal;
                    nItf = funUtiles.truncar(nItf, 2, idMoneda);                   
                    txtImpuestos.Text = nItf.ToString("0,0.00");                    
                    txtTotalAPagar.Text = (funUtiles.redondearBCR((nSubTotal + nItf), ref nRedondeoFavCli, idMoneda, true, true)).ToString("0,0.00");
                    txtRedondeo.Text = nRedondeoFavCli.ToString("0,0.00");
                    conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtTotalAPagar.Text);
                    controles((int)Modo.Editar);
                    btnCargarFile1.Enabled = false;
                }
                else
                {
                    controles((int)Modo.Bloqueado);
                }
            }
            else
            {
                controles((int)Modo.Bloqueado);
            }
        }

        private Decimal sumarOtrasComisiones()
        {
            Decimal suma = 0.00m;
            foreach (DataGridViewRow row in dtgOtrasComisiones.Rows)
            {
                suma += Convert.ToDecimal (row.Cells["nValorAplica"].Value);
            }
            return suma;
        }

        public void formatearOtrasComisiones()
        {
            dtgOtrasComisiones.Columns["cDescripcion"].HeaderText = "Concepto";
            dtgOtrasComisiones.Columns["cDescripcion"].Width = 160;
            dtgOtrasComisiones.Columns["cSimbolo"].HeaderText = "Moneda";
            dtgOtrasComisiones.Columns["cSimbolo"].Width = 55;
            dtgOtrasComisiones.Columns["nValorAplica"].HeaderText = "Monto";
            dtgOtrasComisiones.Columns["nValorAplica"].Width = 60;

        }

        public void limpiarControles()
        {
            dtgOtrasComisiones.DataSource = null;
            txtMontoAprobado.Text = "";
            txtPlazoAprobado.Text = "";
            txtFechaInicioAprobado.Text = "";
            txtTasaAprobada.Text = "";
            txtComision.Text = "";
            txtSubtotal.Text = "";
            txtImpuestos.Text = "";
            txtTotalAPagar.Text = "";
            txtRedondeo.Text = "";
            txtCartaFianza.Text = "";
            conCalcVuelto.limpiar();
        }

        public void controles(int estado)
        {
            modoFormulario = estado;
            switch (estado)
            {
                case (int)Modo.Bloqueado:
                    this.btnCancelar1.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.conBusCuentaCli1.limpiarControles();
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    this.conBusCuentaCli1.txtNroBusqueda.Focus();
                    this.conCalcVuelto.Enabled = false;
                    break;
                case (int)Modo.Editar:
                    this.btnCancelar1.Enabled = true;
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = false;
                    this.conBusCuentaCli1.btnBusCliente1.Enabled = false;
                    this.conCalcVuelto.txtMonEfectivo.Focus();
                    this.conCalcVuelto.Enabled = true;
                    break;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text))
            {
                MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
                return;
            }
            if (conCalcVuelto.txtMonEfectivo.nDecValor < Convert.ToDecimal(txtTotalAPagar.Text))
            {
                MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
                return;
            }
            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(idMoneda), 1, Convert.ToDecimal(txtTotalAPagar.Text)))
            {
                return;
            }
            //if (!ActualizarSaldo(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(idMoneda), 1, Convert.ToDecimal /*era ToDouble*/(txtTotalAPagar.Text)))
            //{

            bool lModificaSaldoLinea = true;
            int idTipoTransac = 1; //INGRESO
            int idMoneda_Saldo = Convert.ToInt32(idMoneda);

            DataTable dtResultadoPago = cnCartaFianza.pagarComision(idCartaFianza, Convert.ToDecimal(txtTotalAPagar.Text), Convert.ToDecimal(txtImpuestos.Text), 
                                        nRedondeoFavCli, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, nItf, 
                                        Convert.ToDecimal(txtSubtotal.Text), lModificaSaldoLinea, idMoneda_Saldo, idTipoTransac);

            if (dtResultadoPago.Rows.Count > 0)
            {
                int idKardex = Convert.ToInt32(dtResultadoPago.Rows[0]["idResultado"]);
                if (idKardex != 0)
                {
                    btnGrabar1.Enabled = false;
                    conCalcVuelto.Enabled = false;

                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    MessageBox.Show("Se realizó el pago de la comisión de carta fianza", "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //impresion del voucher
                    decimal nMontoRecibido = Convert.ToDecimal(conCalcVuelto.txtMonEfectivo.Text);
                    decimal nMontoVuelto = Convert.ToDecimal(conCalcVuelto.txtMonDiferencia.Text);
                    ImpresionVoucher(idKardex, 1, 1, 1, nMontoRecibido, nMontoVuelto, 0, 1);
                }
                else
                {
                    //ActualizarSaldo(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(idMoneda), 2, Convert.ToDecimal /*era ToDouble*/(txtTotalAPagar.Text));
                    //objFrmSemaforo.ValidarSaldoSemaforo();
                    MessageBox.Show("Error al realizar el pago de carta fianza: " + dtResultadoPago.Rows[0]["cMensaje"], "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                //ActualizarSaldo(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(idMoneda), 2, Convert.ToDecimal /*era ToDouble*/(txtTotalAPagar.Text));
                //objFrmSemaforo.ValidarSaldoSemaforo();
                MessageBox.Show("No se logró realizar la operación de cobro de comisión de carta fianza", "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //return;
            //}
            //else
            //{
            //    return;
            //}

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            controles((int)Modo.Bloqueado);
            limpiarControles();
            btnCargarFile1.Enabled = true;
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            frmBuscarCartasFianza frmBuscarCartasFianza = new frmBuscarCartasFianza();
            frmBuscarCartasFianza.cargarCartasFianza(4);
            frmBuscarCartasFianza.ShowDialog();
            if (frmBuscarCartasFianza.idSolicitud > 0 && frmBuscarCartasFianza.lAceptar)
            {
                this.conBusCuentaCli1.txtNroBusqueda.Text = frmBuscarCartasFianza.idSolicitud.ToString();
                this.conBusCuentaCli1.consultar();
            }
        }
    }
}
