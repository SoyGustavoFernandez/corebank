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

namespace CRE.ControlBase
{
    public partial class ConPropuesta : UserControl
    {
        private string placeholderEntFamiliar = Ayuda.EntFamiliar;
        private string placeholderDestPrestamo = Ayuda.DestPrestamo;
        private string placeholderAntecedentes = Ayuda.Antecedentes;
        private string placeholderIndFinancieros = Ayuda.IndFinancieros;
        private string placeholderGarantias = Ayuda.Garantias;
        private string placeholderConclusiones = Ayuda.Conclusiones;
        private string placeholderSustentoCredito = Ayuda.SustentoCredito;
        private int idTipoEval;

        public string cMsjCaption = "Validación del Formulario";

        public ConPropuesta()
        {
            InitializeComponent();

            this.conActPrincipal.ActividadInternaEnabled = false;

            this.ttpPropuesta.SetToolTip(this.pbxActPrincipal, Ayuda.ActEconomica);
            this.ttpPropuesta.SetToolTip(this.pbxEntFamiliar, Ayuda.EntFamiliar);
            this.ttpPropuesta.SetToolTip(this.pbxDestPrestamo, Ayuda.DestPrestamo);
            this.ttpPropuesta.SetToolTip(this.pbxAntecedentes, Ayuda.Antecedentes);
            this.ttpPropuesta.SetToolTip(this.pbxIndFinancieros, Ayuda.IndFinancieros);
            this.ttpPropuesta.SetToolTip(this.pbxGarantias, Ayuda.Garantias);
            this.ttpPropuesta.SetToolTip(this.pbxConclusiones, Ayuda.Conclusiones);
            this.ttpPropuesta.SetToolTip(this.pbxSustentoCredito, Ayuda.SustentoCredito);
        }

        #region Métodos Públicos
        public void AsignarDatos(clsPropCredito objPropCredito, int idTipoEval = 0)
        {
            this.conActPrincipal.AsignarDatos(objPropCredito.oActPrincipal);

            this.idTipoEval = idTipoEval;

            //Se habilita la opcion de sustento de credito en la evaluacion rural
            if (idTipoEval == Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
            {
                this.lblSustentoCredito.Visible = true;
                this.txtSustentoCredito.Visible = true;
                this.pbxSustentoCredito.Visible = true;

                this.lblEntFamiliar.Location = new System.Drawing.Point(354, 12);
                this.lblEntFamiliar.Size = new System.Drawing.Size(325, 26);
                this.txtEntFamiliar.Location = new System.Drawing.Point(354, 43);
                this.txtEntFamiliar.Size = new System.Drawing.Size(320, 82);
                this.pbxEntFamiliar.Location = new System.Drawing.Point(658, 12);

                this.lblDestPrestamo.Location = new System.Drawing.Point(354, 137);
                this.lblDestPrestamo.Size = new System.Drawing.Size(325, 13);
                this.txtDestPrestamo.Location = new System.Drawing.Point(354, 156);
                this.txtDestPrestamo.Size = new System.Drawing.Size(320, 82);
                this.pbxDestPrestamo.Location = new System.Drawing.Point(658, 137);

                this.lblAntecedentes.Location = new System.Drawing.Point(351, 259);
                this.lblAntecedentes.Size = new System.Drawing.Size(325, 28);
                this.txtAntecedentes.Location = new System.Drawing.Point(354, 291);
                this.txtAntecedentes.Size = new System.Drawing.Size(320, 82);
                this.pbxAntecedentes.Location = new System.Drawing.Point(658, 259);

                this.lblIndFinancieros.Location = new System.Drawing.Point(694, 12);
                this.lblIndFinancieros.Size = new System.Drawing.Size(325, 28);
                this.txtIndFinancieros.Location = new System.Drawing.Point(694, 43);
                this.txtIndFinancieros.Size = new System.Drawing.Size(320, 82);
                this.pbxIndFinancieros.Location = new System.Drawing.Point(998, 12);

                this.lblGarantias.Location = new System.Drawing.Point(694, 137);
                this.lblGarantias.Size = new System.Drawing.Size(325, 13);
                this.txtGarantias.Location = new System.Drawing.Point(694, 156);
                this.txtGarantias.Size = new System.Drawing.Size(320, 82);
                this.pbxGarantias.Location = new System.Drawing.Point(998, 137);

                this.lblConclusiones.Location = new System.Drawing.Point(694, 259);
                this.lblConclusiones.Size = new System.Drawing.Size(325, 29);
                this.txtConclusiones.Location = new System.Drawing.Point(694, 291);
                this.txtConclusiones.Size = new System.Drawing.Size(320, 82);
                this.pbxConclusiones.Location = new System.Drawing.Point(998, 259);

            }

            if (objPropCredito.lActSecundaria == true)
            {
                this.conActSecundaria.Checked = true;
                this.conActSecundaria.AsignarDatos(objPropCredito.oActSecundaria);
            }

            this.txtEntFamiliar.Text = objPropCredito.cComEntFamiliar;
            this.txtDestPrestamo.Text = objPropCredito.cComDestCredito;
            this.txtAntecedentes.Text = objPropCredito.cComAnteCred;
            this.txtIndFinancieros.Text = objPropCredito.cComAnalisisFinan;
            this.txtGarantias.Text = objPropCredito.cComGarantias;
            this.txtConclusiones.Text = objPropCredito.cComConclusiones;
            this.txtSustentoCredito.Text = objPropCredito.cComSustentoCredito;
            //InitPlaceholder();
        }

        public clsPropCredito ObtenerDatos()
        {
            clsPropCredito objPropCredito = new clsPropCredito();

            /*objPropCredito.cComEntFamiliar = (this.txtEntFamiliar.Text.Equals(placeholderEntFamiliar) ? "" : this.txtEntFamiliar.Text);
            objPropCredito.cComDestCredito = (this.txtDestPrestamo.Text.Equals(placeholderDestPrestamo) ? "" : this.txtDestPrestamo.Text);
            objPropCredito.cComAnteCred = (this.txtAntecedentes.Text.Equals(placeholderAntecedentes) ? "" : this.txtAntecedentes.Text);
            objPropCredito.cComAnalisisFinan = (this.txtIndFinancieros.Text.Equals(placeholderIndFinancieros) ? "" : this.txtIndFinancieros.Text);
            objPropCredito.cComGarantias = (this.txtGarantias.Text.Equals(placeholderGarantias) ? "" : this.txtGarantias.Text);
            objPropCredito.cComConclusiones = (this.txtConclusiones.Text.Equals(placeholderConclusiones) ? "" : this.txtConclusiones.Text);*/

            objPropCredito.oActPrincipal = this.conActPrincipal.ObtenerDatos();
            objPropCredito.cComEntFamiliar = this.txtEntFamiliar.Text;
            objPropCredito.cComDestCredito = this.txtDestPrestamo.Text;
            objPropCredito.cComAnteCred = this.txtAntecedentes.Text;
            objPropCredito.cComAnalisisFinan = this.txtIndFinancieros.Text;
            objPropCredito.cComGarantias = this.txtGarantias.Text;
            objPropCredito.cComConclusiones = this.txtConclusiones.Text;
            objPropCredito.cComSustentoCredito = this.txtSustentoCredito.Text;
            objPropCredito.lActSecundaria = this.conActSecundaria.Checked;

            if (objPropCredito.lActSecundaria)
                objPropCredito.oActSecundaria = this.conActSecundaria.ObtenerDatos();
            else
                objPropCredito.oActSecundaria = new clsActividadEconomica();

            return objPropCredito;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            errorProvider.SetError(this.txtEntFamiliar, String.Empty);
            errorProvider.SetError(this.txtDestPrestamo, String.Empty);
            errorProvider.SetError(this.txtAntecedentes, String.Empty);
            errorProvider.SetError(this.txtIndFinancieros, String.Empty);
            errorProvider.SetError(this.txtGarantias, String.Empty);
            errorProvider.SetError(this.txtConclusiones, String.Empty);
            errorProvider.SetError(this.txtSustentoCredito, String.Empty);

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

            if (!EsEntFamiliarValido())
            {
                objMsjError.AddError("Entorno Familiar está VACIO.");
                errorProvider.SetError(this.txtEntFamiliar, "Ingrese una descripción.");
            }

            if (!EsDestPrestamoValido())
            {
                objMsjError.AddError("Destino de Préstamo está VACIO.");
                errorProvider.SetError(this.txtDestPrestamo, "Ingrese una descripción.");
            }

            if (!EsAntecedentesValido())
            {
                objMsjError.AddError("Antecedentes Crediticios está VACIO.");
                errorProvider.SetError(this.txtAntecedentes, "Ingrese una descripción.");
            }

            if (!EsIndFinancierosValido())
            {
                objMsjError.AddError("Indicadores Financieros está VACIO.");
                errorProvider.SetError(this.txtIndFinancieros, "Ingrese una descripción.");
            }

            if (!EsGarantiasValido())
            {
                objMsjError.AddError("Garantías está VACIO.");
                errorProvider.SetError(this.txtGarantias, "Ingrese una descripción.");
            }

            if (!EsConclusionesValido())
            {
                objMsjError.AddError("Conclusiones está VACIO.");
                errorProvider.SetError(this.txtConclusiones, "Ingrese una descripción.");
            }

            if (!EsSustentoCreditoMaxCaracteres())
            {
                objMsjError.AddError("Sustento de Credito exede los 250 caracteres.");
                errorProvider.SetError(this.txtSustentoCredito, "Se supero el maximo de caracteres permitidos.");
            }

            if (!EsSustentoCredito())
            {
                objMsjError.AddError("Sustento de Credito está VACIO.");
                errorProvider.SetError(this.txtSustentoCredito, "Ingrese una descripción.");
            }

            return objMsjError;
        }

        public void ActualizarActividadInterna(int idActividadInterna)
        {
            this.conActPrincipal.ActualizarActividadInterna(idActividadInterna);
        }
        #endregion

        #region Métodos Privados
        /*private void InitPlaceholder()
        {
            if (String.IsNullOrWhiteSpace(this.txtEntFamiliar.Text) && TxtEntFamiliarEnabled == true)
            {
                this.txtEntFamiliar.Text = placeholderEntFamiliar;
                this.txtEntFamiliar.ForeColor = SystemColors.GrayText;
            }

            if (String.IsNullOrWhiteSpace(this.txtDestPrestamo.Text) && TxtDestPrestamoEnabled == true)
            {
                this.txtDestPrestamo.Text = placeholderDestPrestamo;
                this.txtDestPrestamo.ForeColor = SystemColors.GrayText;
            }

            if (String.IsNullOrWhiteSpace(this.txtAntecedentes.Text) && TxtAntecedentesEnabled == true)
            {
                this.txtAntecedentes.Text = placeholderAntecedentes;
                this.txtAntecedentes.ForeColor = SystemColors.GrayText;
            }

            if (String.IsNullOrWhiteSpace(this.txtIndFinancieros.Text) && TxtIndFinancierosEnabled == true)
            {
                this.txtIndFinancieros.Text = placeholderIndFinancieros;
                this.txtIndFinancieros.ForeColor = SystemColors.GrayText;
            }
            if (String.IsNullOrWhiteSpace(this.txtGarantias.Text) && TxtGarantiasEnabled == true)
            {
                this.txtGarantias.Text = placeholderGarantias;
                this.txtGarantias.ForeColor = SystemColors.GrayText;
            }

            if (String.IsNullOrEmpty(this.txtConclusiones.Text)&& TxtConclusionesEnabled == true)
            {
                this.txtConclusiones.Text = placeholderConclusiones;
                this.txtConclusiones.ForeColor = SystemColors.GrayText;
            }
        }*/

        private bool EsEntFamiliarValido()
        {
            if ((this.txtEntFamiliar.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtEntFamiliar.Text) || this.txtEntFamiliar.Text.Equals(placeholderEntFamiliar)))

                return false;
            return true;
        }

        private bool EsDestPrestamoValido()
        {
            if ((this.txtDestPrestamo.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtDestPrestamo.Text) || this.txtDestPrestamo.Text.Equals(placeholderDestPrestamo)))
                return false;

            return true;
        }

        private bool EsAntecedentesValido()
        {
            if ((this.txtAntecedentes.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtAntecedentes.Text) || this.txtAntecedentes.Text.Equals(placeholderAntecedentes)))
                return false;

            return true;
        }

        private bool EsIndFinancierosValido()
        {
            if ((this.txtIndFinancieros.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtIndFinancieros.Text) || this.txtIndFinancieros.Text.Equals(placeholderIndFinancieros)))
                return false;

            return true;
        }

        private bool EsGarantiasValido()
        {
            if ((this.txtGarantias.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtGarantias.Text) || this.txtGarantias.Text.Equals(placeholderGarantias)))
                return false;

            return true;
        }

        private bool EsConclusionesValido()
        {
            if ((this.txtConclusiones.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtConclusiones.Text) || this.txtConclusiones.Text.Equals(placeholderConclusiones)))
                return false;

            return true;
        }

        private bool EsSustentoCredito()
        {
            if ((this.txtSustentoCredito.Enabled == true) &&
                (String.IsNullOrWhiteSpace(this.txtSustentoCredito.Text) || this.txtSustentoCredito.Text.Equals(placeholderSustentoCredito)) &&
                this.idTipoEval == Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                return false;

            return true;
        }

        private bool EsSustentoCreditoMaxCaracteres()
        {
            if ((this.txtSustentoCredito.Enabled == true) && this.txtSustentoCredito.Text.Length > 250 &&
                 this.idTipoEval == Convert.ToInt32(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                return false;

            return true;
        }

        #endregion

        #region Eventos
        private void txtEntFamiliar_Validating(object sender, CancelEventArgs e)
        {
            if (!EsEntFamiliarValido())
                errorProvider.SetError(this.txtEntFamiliar, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtEntFamiliar, String.Empty);
        }

        private void txtDestPrestamo_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDestPrestamoValido())
                errorProvider.SetError(this.txtDestPrestamo, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtDestPrestamo, String.Empty);
        }

        private void txtAntecedentes_Validating(object sender, CancelEventArgs e)
        {
            if (!EsAntecedentesValido())
                errorProvider.SetError(this.txtAntecedentes, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtAntecedentes, String.Empty);
        }

        private void txtIndFinancieros_Validating(object sender, CancelEventArgs e)
        {
            if (!EsIndFinancierosValido())
                errorProvider.SetError(this.txtIndFinancieros, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtIndFinancieros, String.Empty);
        }

        private void txtGarantias_Validating(object sender, CancelEventArgs e)
        {
            if (!EsGarantiasValido())
                errorProvider.SetError(this.txtGarantias, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtGarantias, String.Empty);
        }

        private void txtConclusiones_Validating(object sender, CancelEventArgs e)
        {
            if (!EsConclusionesValido())
                errorProvider.SetError(this.txtConclusiones, "Ingrese una descripción.");
            else
                errorProvider.SetError(this.txtConclusiones, String.Empty);
        }

        private void txtSustentoCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsSustentoCredito())
                errorProvider.SetError(this.txtSustentoCredito, "Ingrese una descripción.");
            else if (!EsSustentoCreditoMaxCaracteres())
                errorProvider.SetError(this.txtSustentoCredito, "Se exedio el maximo de caracteres.");
            else
                errorProvider.SetError(this.txtSustentoCredito, String.Empty);
        }
        
        #endregion

        #region "Properties"
        public bool ConActSecundariaEnabled
        {
            get
            {
                return this.conActSecundaria.Enabled;
            }
            set
            {
                this.conActSecundaria.Enabled = value;
                this.conActSecundaria.Visible = value;
            }
        }

        public bool TxtEntFamiliarEnabled
        {
            get
            {
                return this.txtEntFamiliar.Enabled;
            }
            set
            {
                this.txtEntFamiliar.Enabled = value;
                this.lblEntFamiliar.Enabled = value;
                this.pbxEntFamiliar.Visible = value;
            }
        }

        public bool TxtDestPrestamoEnabled
        {
            get
            {
                return this.txtDestPrestamo.Enabled;
            }
            set
            {
                this.txtDestPrestamo.Enabled = value;
                this.lblDestPrestamo.Enabled = value;
                this.pbxDestPrestamo.Visible = value;
            }
        }

        public bool TxtAntecedentesEnabled
        {
            get
            {
                return this.txtAntecedentes.Enabled;
            }
            set
            {
                this.txtAntecedentes.Enabled = value;
                this.lblAntecedentes.Enabled = value;
                this.pbxAntecedentes.Visible = value;
            }
        }

        public bool TxtIndFinancierosEnabled
        {
            get
            {
                return this.txtIndFinancieros.Enabled;
            }
            set
            {
                this.txtIndFinancieros.Enabled = value;
                this.lblIndFinancieros.Enabled = value;
                this.pbxIndFinancieros.Visible = value;
            }
        }

        public bool TxtGarantiasEnabled
        {
            get
            {
                return this.txtGarantias.Enabled;
            }
            set
            {
                this.txtGarantias.Enabled = value;
                this.lblGarantias.Enabled = value;
                this.pbxGarantias.Visible = value;
            }
        }

        public bool TxtConclusionesEnabled
        {
            get
            {
                return this.txtConclusiones.Enabled;
            }
            set
            {
                this.txtConclusiones.Enabled = value;
                this.lblConclusiones.Enabled = value;
                this.pbxConclusiones.Visible = value;
            }
        }
        #endregion

    }
}
