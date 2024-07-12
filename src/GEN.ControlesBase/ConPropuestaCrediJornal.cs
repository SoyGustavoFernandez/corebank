#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
#endregion

namespace GEN.ControlesBase
{
    public partial class ConPropuestaCrediJornal : UserControl
    {
        #region Variables Globales
        private string placeholderActPrincipal = Ayuda.DetalleActPrincipal;
        private string placeholderDetCliente = Ayuda.DetalleCliente;
        private string placeholderDetCredito = Ayuda.DetalleCredito;

        public string cMsjCaption = "Validación del Formulario";
        #endregion

        #region Constructores
        public ConPropuestaCrediJornal()
        {
            InitializeComponent();
            this.conActPrincipal.ActividadInternaEnabled = false;
            this.ttpPropuesta.SetToolTip(this.pbxActividadPrincipal, Ayuda.DetalleActPrincipal);
            this.ttpPropuesta.SetToolTip(this.pbxDatosCliente, Ayuda.DetalleCliente);
            this.ttpPropuesta.SetToolTip(this.pbxDatosCredito, Ayuda.DetalleCredito);
        }
        #endregion

        #region Métodos

        public void AsignarDatos(ClsPropCreditoJornal objPropCredito)
        {
            this.conActPrincipal.AsignarDatos(objPropCredito.oActPrincipal);

            this.txtDatosCliente.Text = objPropCredito.cComPropCliente;
            this.txtDatosCredito.Text = objPropCredito.cComPropCredito;
        }
        public ClsPropCreditoJornal ObtenerDatos()
        {
            ClsPropCreditoJornal objPropCreditoJornal = new ClsPropCreditoJornal();
            objPropCreditoJornal.oActPrincipal = this.conActPrincipal.ObtenerDatos();
            objPropCreditoJornal.cComPropCliente = Convert.ToString(this.txtDatosCliente.Text);
            objPropCreditoJornal.cComPropCredito = Convert.ToString(this.txtDatosCredito.Text);

            return objPropCreditoJornal;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            errorProvider.SetError(this.txtDatosCliente, String.Empty);
            errorProvider.SetError(this.txtDatosCredito, String.Empty);

            var objActPrinMsjError = this.conActPrincipal.Validar();
            if (objActPrinMsjError.HasErrors)
            {
                foreach (var error in objActPrinMsjError.GetListError())
                    objMsjError.AddError(error);
            }

            if(!EsDetalleClienteValido())
            {
                objMsjError.AddError("Detalles del Clientes está VACIO");
                errorProvider.SetError(this.txtDatosCliente, "Ingrese una descripción");
            }
            if (!EsDetalleCreditoValido())
            {
                objMsjError.AddError("Detalles del Crédito está VACIO");
                errorProvider.SetError(this.txtDatosCredito, "Ingrese una descripción");
            }
            return objMsjError;
        }

        public void ActualizarActividadInterna(int idActividadinterna)
        {
            this.conActPrincipal.ActualizarActividadInterna(idActividadinterna);
        }

        private bool EsDetalleClienteValido()
        {
            if ((this.txtDatosCliente.Enabled) &&
                (String.IsNullOrWhiteSpace(this.txtDatosCliente.Text) ||
                this.txtDatosCliente.Text.Equals(placeholderDetCliente)))
                return false;
            return true;
        }

        private bool EsDetalleCreditoValido()
        {
            if ((this.txtDatosCredito.Enabled) &&
                (String.IsNullOrWhiteSpace(this.txtDatosCredito.Text) ||
                this.txtDatosCredito.Text.Equals(placeholderDetCredito)))
                return false;
            return true;
        }


        #endregion

        #region Eventos

        private void txtDatosCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDetalleClienteValido())
                errorProvider.SetError(this.txtDatosCliente, "Ingrese una descripción");
            else
                errorProvider.SetError(this.txtDatosCliente, String.Empty);
        }

        private void txtDatosCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDetalleCreditoValido())
                errorProvider.SetError(this.txtDatosCredito, "Ingrese una descripción");
            else
                errorProvider.SetError(this.txtDatosCredito, String.Empty);
        }


        #endregion

        #region Properties
        public bool TxtDatosClienteEnabled

        {
            get
            {
                return this.txtDatosCliente.Enabled;
            }
            set
            {
                this.txtDatosCliente.Enabled = value;
                this.lblBaseCustom2.Enabled = value;
                this.pbxDatosCliente.Visible = false;
            }
        }

        public bool TxtDatosCreditoEnabled
        {
            get
            {
                return this.txtDatosCredito.Enabled;
            }
            set
            {
                this.txtDatosCredito.Enabled = value;
                this.lblBaseCustom3.Enabled = value;
                this.pbxDatosCredito.Visible = value;
            }
        }

        #endregion

    }
}
