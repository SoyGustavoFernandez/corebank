using EntityLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConPropuestaPymeEst : UserControl
    {
        #region Variables

        private string placeholderDestPrestamo = Ayuda.DestPrestamo;
        private string placeholderAntecedentes = Ayuda.Antecedentes;

        public string cMsjCaption = "Validación del Formulario";

        #endregion

        #region Métodos Públicos

        public ConPropuestaPymeEst()
        {
            InitializeComponent();

            this.conActPrincipal.ActividadInternaEnabled = false;
            this.ttpPropuesta.SetToolTip(this.pbxDestPrestamo, Ayuda.DestPrestamo);
            this.ttpPropuesta.SetToolTip(this.pbxAntecedentes, Ayuda.Antecedentes);
        }

        public void asignarDatos(clsPropCredito objPropCredito)
        {
            this.conActPrincipal.AsignarDatos(objPropCredito.oActPrincipal);

            if (objPropCredito.lActSecundaria == true)
            {
                this.conActSecundaria.Checked = true;
                this.conActSecundaria.AsignarDatos(objPropCredito.oActSecundaria);
                this.conActSecundaria.lTipoActividadHabilitado = true;
            }
            else
            {
                this.conActSecundaria.lTipoActividadHabilitado = false;
            }

            this.txtDestPrestamo.Text = objPropCredito.cComDestCredito;
            this.txtAntecedentes.Text = objPropCredito.cComAnteCred;
        }

        public clsPropCredito obtenerDatos()
        {
            clsPropCredito objPropCredito = new clsPropCredito();


            objPropCredito.oActPrincipal = this.conActPrincipal.ObtenerDatos();
            objPropCredito.cComDestCredito = this.txtDestPrestamo.Text;
            objPropCredito.cComAnteCred = this.txtAntecedentes.Text;
            objPropCredito.lActSecundaria = this.conActSecundaria.Checked;

            if (objPropCredito.lActSecundaria)
                objPropCredito.oActSecundaria = this.conActSecundaria.ObtenerDatos();
            else
                objPropCredito.oActSecundaria = new clsActividadEconomica();

            return objPropCredito;
        }

        public clsMsjError validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            errorProvider.SetError(this.txtDestPrestamo, String.Empty);
            errorProvider.SetError(this.txtAntecedentes, String.Empty);
            
            var objActPrinMsjError = this.conActPrincipal.Validar();

            if (objActPrinMsjError.HasErrors)
            {
                foreach (var err in objActPrinMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            if (this.conActSecundaria.Checked == true)
            {
                var objActSecMsjError = this.conActSecundaria.Validar();

                if (objActSecMsjError.HasErrors)
                {
                    foreach (var err in objActSecMsjError.GetListError())
                        objMsjError.AddError(err);
                }
            }

            if (!validaDestPrestamo())
            {
                objMsjError.AddError("Destino de Préstamo está VACIO.");
                errorProvider.SetError(this.txtDestPrestamo, "Ingrese una descripción.");
            }

            if (!validaAntecedentes())
            {
                objMsjError.AddError("Antecedentes Crediticios está VACIO.");
                errorProvider.SetError(this.txtAntecedentes, "Ingrese una descripción.");
            }

            return objMsjError;
        }

        #endregion

        #region Métodos Privados
        
        private bool validaDestPrestamo()
        {
            if ((this.txtDestPrestamo.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtDestPrestamo.Text) || this.txtDestPrestamo.Text.Equals(placeholderDestPrestamo)))
                return false;

            return true;
        }

        private bool validaAntecedentes()
        {
            if ((this.txtAntecedentes.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtAntecedentes.Text) || this.txtAntecedentes.Text.Equals(placeholderAntecedentes)))
                return false;

            return true;
        }

        #endregion

        #region Eventos
        
        private void txtDestPrestamo_Validating(object sender, CancelEventArgs e)
        {
            if (!validaDestPrestamo())
                errorProvider.SetError(this.txtDestPrestamo, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtDestPrestamo, String.Empty);
        }

        private void txtAntecedentes_Validating(object sender, CancelEventArgs e)
        {
            if (!validaAntecedentes())
                errorProvider.SetError(this.txtAntecedentes, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtAntecedentes, String.Empty);
        }

        #endregion
    }
}
