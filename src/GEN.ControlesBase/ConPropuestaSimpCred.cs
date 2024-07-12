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

namespace GEN.ControlesBase
{
    public partial class ConPropuestaSimpCred : UserControl
    {
        private string placeholderEntFamiliar = Ayuda.DetalleCliente;
        private string placeholderDestPrestamo = Ayuda.DetalleCredito;

        public string cMsjCaption = "Validación del Formulario";

        public ConPropuestaSimpCred()
        {
            InitializeComponent();

            this.conActPrincipal.ActividadInternaEnabled = false;
            lHabilitarTipActividad = true;

            this.ttpPropuesta.SetToolTip(this.pbxActividadPrincipal, Ayuda.ActEconomica);
            this.ttpPropuesta.SetToolTip(this.pbxDatosCliente, Ayuda.DetalleCliente);
            this.ttpPropuesta.SetToolTip(this.pbxDatosCredito, Ayuda.DetalleCredito);
        }


        #region Métodos Públicos
        public void AsignarDatos(ClsPropSimpleCred objPropCredito)
        {
            this.conActPrincipal.AsignarDatos(objPropCredito.oActPrincipal);

            this.txtDatosCliente.Text = objPropCredito.cComPropCliente;
            this.txtDatosCredito.Text = objPropCredito.cComPropCredito;
        }

        public ClsPropSimpleCred ObtenerDatos()
        {
            ClsPropSimpleCred objPropCredito = new ClsPropSimpleCred();

            objPropCredito.oActPrincipal = this.conActPrincipal.ObtenerDatos();
            objPropCredito.cComPropCliente = this.txtDatosCliente.Text;
            objPropCredito.cComPropCredito = this.txtDatosCredito.Text;
            return objPropCredito;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            errorProvider.SetError(this.txtDatosCliente, String.Empty);
            errorProvider.SetError(this.txtDatosCredito, String.Empty);

            var objActPrinMsjError = this.conActPrincipal.Validar();

            if (objActPrinMsjError.HasErrors)
            {
                foreach (var err in objActPrinMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            
            if (!EsDatosClienteValido())
            {
                objMsjError.AddError("Detalles del Cliente está VACIO.");
                errorProvider.SetError(this.txtDatosCliente, "Ingrese una descripción.");
            }

            if (!EsDatosCreditoValido())
            {
                objMsjError.AddError("Detalles del Crédito está VACIO.");
                errorProvider.SetError(this.txtDatosCredito, "Ingrese una descripción.");
            }

            return objMsjError;
        }

        public void ActualizarActividadInterna(int idActividadInterna)
        {
            this.conActPrincipal.ActualizarActividadInterna(idActividadInterna);
        }
        #endregion

        #region Métodos Privados

        private bool EsDatosClienteValido()
        {
            if ((this.txtDatosCliente.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtDatosCliente.Text) || this.txtDatosCliente.Text.Equals(placeholderEntFamiliar)))

                return false;
            return true;
        }

        private bool EsDatosCreditoValido()
        {
            if ((this.txtDatosCredito.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtDatosCredito.Text) || this.txtDatosCredito.Text.Equals(placeholderDestPrestamo)))
                return false;

            return true;
        }

        #endregion

        #region Eventos
        private void txtDatosCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDatosClienteValido())
                errorProvider.SetError(this.txtDatosCliente, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtDatosCliente, String.Empty);
        }

        private void txtDatosCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDatosCreditoValido())
                errorProvider.SetError(this.txtDatosCredito, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtDatosCredito, String.Empty);
        }

        #endregion

        #region "Properties"
        public bool TxtDatosClienteEnabled
        {
            get
            {
                return this.txtDatosCliente.Enabled;
            }
            set
            {
                this.txtDatosCliente.Enabled = value;
                this.lblDatosCliente.Enabled = value;
                this.pbxDatosCliente.Visible = value;
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
                this.lblDatosCredito.Enabled = value;
                this.pbxDatosCredito.Visible = value;
            }
        }

        public bool lHabilitarTipActividad
        {
            get
            {
                return this.conActPrincipal.lTipoActividadHabilitado;
            }
            set
            {
                this.conActPrincipal.lTipoActividadHabilitado = value;
            }
        }

        #endregion
    }
}
