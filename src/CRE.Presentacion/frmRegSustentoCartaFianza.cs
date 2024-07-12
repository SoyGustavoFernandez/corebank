using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRegSustentoCartaFianza : frmBase
    {
        enum Modo { Lectura, Editar, Bloqueado };
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza = 0;
        int modoFormulario = (int)Modo.Bloqueado;
        int idEstado = 0;
        private int idPadre = 0;
        public frmRegSustentoCartaFianza()
        {
            InitializeComponent();
        }

        private void frmRegSustentoCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[1,13]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            controles((int)Modo.Bloqueado);
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro Solicitud: ";
            this.dtpFechaFinalPropuesta.Value = this.dtpFechaInicioPropuesta.Value = clsVarGlobal.dFecSystem;
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

                DataTable dtResultado = cnCartaFianza.obtenerCaracteristicasCartaFianza(idSolicitud);
                if (dtResultado.Rows.Count > 0)
                {
                    if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(dtResultado.Rows[0]["idProducto"]))) //carta fianza
                    {
                        MessageBox.Show("La solicitud no corresponde a una carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }

                    if (Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]) != 2)
                    {
                        MessageBox.Show("La carta fianza no se encuentra en estado SOLICITADO", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }

                    idEstado = Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]);
                    idPadre = Convert.ToInt32(dtResultado.Rows[0]["idPadre"]);
                    this.idCartaFianza = Convert.ToInt32(dtResultado.Rows[0]["idCartaFianza"]);

                    txtMontoSolicitado.Text = dtResultado.Rows[0]["nCapitalSolicitado"].ToString();
                    txtPlazoSolicitado.Text = dtResultado.Rows[0]["nPlazoCuota"].ToString();
                    txtFechaInicioSolicitada.Text = Convert.ToDateTime(dtResultado.Rows[0]["dFechaDesembolsoSugerido"]).ToString("dd/MM/yyyy");
                    txtFechaFinalSolicitada.Text = Convert.ToDateTime(dtResultado.Rows[0]["dFechaFinalSugerido"]).ToString("dd/MM/yyyy");
                    cboMoneda1.SelectedValue = dtResultado.Rows[0]["IdMoneda"];
                    if (Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]) == 1 || Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]) == 2)
                    {
                        dtpFechaInicioPropuesta.Value = dtResultado.Rows[0]["dFechaDesembolsoPropuesto"];
                        txtPlazoPropuesto.Text = dtResultado.Rows[0]["nPlazoCuotaPropuesto"].ToString();
                        txtMontoPropuesto.Text = dtResultado.Rows[0]["nCapitalPropuesto"].ToString();
                        txtGiroNegocio.Text = dtResultado.Rows[0]["cDescGiroNegocio"].ToString();
                        txtDestino.Text = dtResultado.Rows[0]["cDescDestino"].ToString();
                        txtGarantia.Text = dtResultado.Rows[0]["cDescGarantia"].ToString();
                        txtConclusiones.Text = dtResultado.Rows[0]["cConclusiones"].ToString();
                    }
                    controles((int)Modo.Lectura);
                }
                else
                {
                    controles((int)Modo.Editar);
                }
            }
            else
            {
                controles((int)Modo.Bloqueado);
            }
        }

        public void limpiarControles()
        {
            txtMontoSolicitado.Text = "";
            txtPlazoSolicitado.Text = "";
            txtFechaInicioSolicitada.Text = "";
            txtFechaFinalSolicitada.Text = "";
            cboMoneda1.SelectedIndex = -1;
            txtMontoPropuesto.Text = "";
            txtPlazoPropuesto.Text = "";
            dtpFechaInicioPropuesta.Value = DateTime.Now;
            dtpFechaFinalPropuesta.Value = DateTime.Now;
            txtGiroNegocio.Text = "";
            txtDestino.Text = "";
            txtGarantia.Text = "";
            txtConclusiones.Text = "";
        }

        public void controles(int estado)
        {
            modoFormulario = estado;
            switch (estado)
            {
                case (int)Modo.Bloqueado:
                    this.txtMontoPropuesto.Enabled = false;
                    this.txtPlazoPropuesto.Enabled = false;
                    this.dtpFechaInicioPropuesta.Enabled = false;
                    this.txtGiroNegocio.Enabled = false;
                    this.txtDestino.Enabled = false;
                    this.txtGarantia.Enabled = false;
                    this.txtConclusiones.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = false;
                    this.conBusCuentaCli1.limpiarControles();
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    this.conBusCuentaCli1.txtNroBusqueda.Focus();
                    this.btnCargarFile1.Enabled = true;
                    limpiarControles();
                    break;
                case (int)Modo.Lectura:
                    this.txtMontoPropuesto.Enabled = false;
                    this.txtPlazoPropuesto.Enabled = false;
                    this.dtpFechaInicioPropuesta.Enabled = false;
                    this.txtGiroNegocio.Enabled = false;
                    this.txtDestino.Enabled = false;
                    this.txtGarantia.Enabled = false;
                    this.txtConclusiones.Enabled = false;
                    this.btnCancelar1.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = true;
                    this.btnCargarFile1.Enabled = true;
                    break;
                case (int)Modo.Editar:
                    this.txtMontoPropuesto.Enabled = true;
                    this.txtPlazoPropuesto.Enabled = true;
                    this.dtpFechaInicioPropuesta.Enabled = true;
                    this.txtGiroNegocio.Enabled = true;
                    this.txtDestino.Enabled = true;
                    this.txtGarantia.Enabled = true;
                    this.txtConclusiones.Enabled = true;
                    this.btnCancelar1.Enabled = true;
                    this.btnGrabar1.Enabled = true;
                    this.btnEditar1.Enabled = false;
                    this.btnCargarFile1.Enabled = false;
                    break;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            controles((int)Modo.Editar);
            txtMontoPropuesto.Enabled = !(idPadre > 0);
            dtpFechaInicioPropuesta.Enabled = !(idPadre > 0);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            controles((int)Modo.Bloqueado);
        }

        private void txtPlazoPropuesto_TextChanged(object sender, EventArgs e)
        {
            if (txtPlazoPropuesto.Text.Trim().Length > 0)
            {
                DateTime fechaFinal = (DateTime)dtpFechaInicioPropuesta.Value;
                fechaFinal = fechaFinal.AddDays(Convert.ToInt32(txtPlazoPropuesto.Text) - 1);
                dtpFechaFinalPropuesta.Value = fechaFinal;
            }
            else
            {
                dtpFechaFinalPropuesta.Value = dtpFechaInicioPropuesta.Value;
            }
        }
        public bool validar()
        {
            if (Convert.ToDecimal (txtMontoPropuesto.Text) > Convert.ToDecimal (txtMontoSolicitado.Text))
            {
                MessageBox.Show("El monto propuesto no puede ser mayor al solicitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMontoPropuesto.Focus();
                return false;
            }

            if (Convert.ToDateTime(dtpFechaInicioPropuesta.Value) < Convert.ToDateTime(txtFechaInicioSolicitada.Text))
            {
                MessageBox.Show("La fecha propuesta no puede ser menor a la fecha solicitada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicioPropuesta.Focus();
                return false;
            }

            if (this.txtMontoPropuesto.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar el monto propuesto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMontoPropuesto.Focus();
                return false;
            }
            if (this.txtPlazoPropuesto.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar el plazo propuesto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPlazoPropuesto.Focus();
                return false;
            }
            if (this.txtGiroNegocio.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar el giro del negocio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtGiroNegocio.Focus();
                return false;
            }
            if (this.txtDestino.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar el destino de la carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDestino.Focus();
                return false;
            }
            if (this.txtGarantia.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar la descripción de la garantia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtGarantia.Focus();
                return false;
            }
            if (this.txtConclusiones.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe de ingresar las conclusiones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtConclusiones.Focus();
                return false;
            }
            if (idEstado > 2)
            {
                MessageBox.Show("La carta fianza no puede ser editada dado que esta aprobada o denegada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarControles();
                controles((int)Modo.Bloqueado);
                return false;
            }
            return true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);
                DataTable dtResultado = new DataTable();
                if (this.idCartaFianza > 0)
                {
                    dtResultado = cnCartaFianza.actualizarSustentoCartaFianza(this.idCartaFianza, Convert.ToDecimal(this.txtMontoPropuesto.Text.Trim()), Convert.ToInt32(this.txtPlazoPropuesto.Text.Trim()), this.dtpFechaInicioPropuesta.Text.Trim().ToUpper(), this.txtGiroNegocio.Text.Trim().ToUpper(), this.txtDestino.Text.Trim().ToUpper(), this.txtGarantia.Text.Trim().ToUpper(), this.txtConclusiones.Text.Trim().ToUpper());
                }
                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0)
                {
                    MessageBox.Show((this.idCartaFianza > 0) ? "Se actualizó correctamente" : "Se registro correctamente", "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    controles((int)Modo.Lectura);
                }
                else
                {
                    MessageBox.Show("Error al actualizar el sustento carta fianza", "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            frmBuscarCartasFianza frmBuscarCartasFianza = new frmBuscarCartasFianza();
            frmBuscarCartasFianza.cargarCartasFianza(2);
            frmBuscarCartasFianza.ShowDialog();
            if (frmBuscarCartasFianza.idSolicitud > 0 && frmBuscarCartasFianza.lAceptar)
            {
                this.conBusCuentaCli1.txtNroBusqueda.Text = frmBuscarCartasFianza.idSolicitud.ToString();
                this.conBusCuentaCli1.consultar();
            }
        }

        private void dtpFechaInicioPropuesta_ValueChanged(object sender, EventArgs e)
        {
            if (txtPlazoPropuesto.Text.Trim().Length > 0)
            {
                DateTime fechaFinal = (DateTime)dtpFechaInicioPropuesta.Value;
                fechaFinal = fechaFinal.AddDays(Convert.ToInt32(txtPlazoPropuesto.Text) - 1);
                dtpFechaFinalPropuesta.Value = fechaFinal;
            }
            else
            {
                dtpFechaFinalPropuesta.Value = dtpFechaInicioPropuesta.Value;
            }
        }
    }
}
