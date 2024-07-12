#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
#endregion


namespace CAJ.Presentacion
{
    public partial class frmBuscarDatosSeguro : frmBase
    {
        #region Variables Globales
        private int idSolicitud { get; set; }
        private BindingSource bsCreditoSeguro { get; set; }
        private List<clsCreditoSeguro> lstCreditoSeguro { get; set; }
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro { get; set; }
        private clsCreditoSeguro objCreditoSeguro { get; set; }
        
        #endregion

        public frmBuscarDatosSeguro()
        {
            
            InitializeComponent();

            conBusCuentaCli.cTipoBusqueda = "S";
            conBusCuentaCli.cEstado = "[5]";
        }

        #region Eventos
        private void frmBuscarDatosSeguro_Load(object sender, EventArgs e)
        {
            cargarComponentes();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            validaBusquedaCredito();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            validaBusquedaCredito();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int nIndex = (dtgCreditoSeguro.SelectedRows.Count > 0) ? dtgCreditoSeguro.SelectedRows[0].Index : -1;

            if (nIndex != -1)
            {
                objCreditoSeguro = (clsCreditoSeguro)dtgCreditoSeguro.SelectedRows[0].DataBoundItem;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un seguro del cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        #endregion

        #region Metodos
        private void cargarComponentes()
        {
            

            idSolicitud = 0;
            lstCreditoSeguro                = new List<clsCreditoSeguro>();
            bsCreditoSeguro                 = new BindingSource();
            bsCreditoSeguro.DataSource      = lstCreditoSeguro;
            dtgCreditoSeguro.DataSource     = bsCreditoSeguro;
            objCNCreditoCargaSeguro         = new clsCNCreditoCargaSeguro();
            objCreditoSeguro                = new clsCreditoSeguro();
            formatearCreditoSeguro();
        }

        private void validaBusquedaCredito()
        {
            int idSolicitudValidar = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if(idSolicitudValidar == 0)
            {
                MessageBox.Show("Ingrese un número de Solicitud Válido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                conBusCuentaCli.txtNroBusqueda.Focus();
                activarControles(accionFormulario.REGISTRO_DEFECTO);
                return;
            }
            else
            {
                idSolicitud = idSolicitudValidar;
            }
            cargarDatos(idSolicitud);
        }

        private void limpiar()
        {
            conBusCuentaCli.limpiarControles();
            lstCreditoSeguro = new List<clsCreditoSeguro>();
            bsCreditoSeguro = new BindingSource();
            bsCreditoSeguro.DataSource = lstCreditoSeguro;
            bsCreditoSeguro.ResetBindings(false);
            dtgCreditoSeguro.DataSource = bsCreditoSeguro;
            dtgCreditoSeguro.Refresh();
            formatearCreditoSeguro();
            activarControles(accionFormulario.REGISTRO_DEFECTO);
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
        }

        private void cargarDatos(int idSolicitud)
        {
            List<clsCreditoSeguro> lstCreditoSeguroCompleto = new List<clsCreditoSeguro>();
            lstCreditoSeguroCompleto = objCNCreditoCargaSeguro.CNObtenerListaCreditoSeguro(idSolicitud);
            lstCreditoSeguro = lstCreditoSeguroCompleto.Where(item => item.idEstadoSeguro == 1).ToList();

            if(lstCreditoSeguro.Count == 0)
            {
                MessageBox.Show("La solicitud no tiene seguros pendientes para cobrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
            }
            else
            {
                actualizarDatosCreditoSeguro();
                activarControles(accionFormulario.REGISTRO_RECUPERADO);
            }
        }

        private void formatearCreditoSeguro()
        {
            foreach(DataGridViewColumn dgvColumna in dtgCreditoSeguro.Columns )
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dtgCreditoSeguro.Columns["cEstadoSeguro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgCreditoSeguro.Columns["idCuenta"].Visible        = true;
            dtgCreditoSeguro.Columns["idCliente"].Visible       = true;
            dtgCreditoSeguro.Columns["cTipoSeguro"].Visible     = true;
            dtgCreditoSeguro.Columns["nMontoPrima"].Visible     = true;
            dtgCreditoSeguro.Columns["nMontoCobertura"].Visible = true;
            dtgCreditoSeguro.Columns["cMoneda"].Visible         = true;
            dtgCreditoSeguro.Columns["cEstadoSeguro"].Visible   = true;
            

            dtgCreditoSeguro.Columns["idCuenta"].HeaderText             = "Cuenta";
            dtgCreditoSeguro.Columns["idCliente"].HeaderText            = "Cod. Cliente";
            dtgCreditoSeguro.Columns["cTipoSeguro"].HeaderText          = "Tipo Seguro";
            dtgCreditoSeguro.Columns["nMontoPrima"].HeaderText          = "Prima";
            dtgCreditoSeguro.Columns["nMontoCobertura"].HeaderText      = "Monto Cobertura";
            dtgCreditoSeguro.Columns["cMoneda"].HeaderText              = "Moneda";
            dtgCreditoSeguro.Columns["cEstadoSeguro"].HeaderText        = "Estado";

        }

        private void actualizarDatosCreditoSeguro()
        {
            bsCreditoSeguro.DataSource      = lstCreditoSeguro;
            dtgCreditoSeguro.DataSource     = bsCreditoSeguro;
            bsCreditoSeguro.ResetBindings(false);
            formatearCreditoSeguro();
            dtgCreditoSeguro.Refresh();
        }

        private void activarControles(accionFormulario evento)
        {
            switch (evento)
            {
                case accionFormulario.REGISTRO_DEFECTO:
                    conBusCuentaCli.Enabled     = true;
                    dtgCreditoSeguro.Enabled    = false;
                    btnAceptar.Enabled          = false;
                    btnCancelar.Enabled         = false;
                    btnSalir.Enabled            = true;
                    break;
                case accionFormulario.REGISTRO_RECUPERADO:
                    conBusCuentaCli.Enabled     = true;
                    dtgCreditoSeguro.Enabled    = true;
                    btnAceptar.Enabled          = true;
                    btnCancelar.Enabled         = true;
                    btnSalir.Enabled            = true;
                    break;
                case accionFormulario.REGISTRO_CANCELADO:
                    conBusCuentaCli.Enabled     = true;
                    dtgCreditoSeguro.Enabled    = false;
                    btnAceptar.Enabled          = false;
                    btnCancelar.Enabled         = false;
                    btnSalir.Enabled            = true;
                    break;
                default:
                    conBusCuentaCli.Enabled     = false;
                    dtgCreditoSeguro.Enabled    = false;
                    btnAceptar.Enabled          = false;
                    btnCancelar.Enabled         = false;
                    btnSalir.Enabled            = true;
                    break;
            }
        }

        public clsCreditoSeguro obtenerCreditoSeguro()
        {
            return objCreditoSeguro;
        }
        
        #endregion

        #region Enumeradores
        private enum accionFormulario
        {
            REGISTRO_DEFECTO        = 0,
            REGISTRO_RECUPERADO     = 1,
            REGISTRO_CANCELADO      = 2
        }

        #endregion

    }
}
