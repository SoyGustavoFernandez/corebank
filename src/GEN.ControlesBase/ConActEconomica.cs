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
    public partial class ConActEconomica : UserControl
    {
        private string placeholderDescripcion = Ayuda.ActEconomicaPri;

        public ConActEconomica()
        {
            InitializeComponent();
            AsignarDataTable();

            Habilitar(this.chcHabilitado.Checked);
            lTipoActividadHabilitado = true;
        }

        #region "Properties"
        public string Titulo
        {
            get
            {
                return this.grbTitulo.Text;
            }
            set
            {
                this.grbTitulo.Text = value;
            }
        }

        public bool Checked
        {
            get
            {
                return this.chcHabilitado.Checked;
            }
            set
            {
                this.chcHabilitado.Checked = value;
            }
        }

        public bool CheckedEnabled
        {
            get
            {
                return this.chcHabilitado.Enabled;
            }
            set
            {
                this.chcHabilitado.Enabled = value;
            }
        }

        public bool ActividadInternaEnabled
        {
            get
            {
                return this.cboActividadInterna.Enabled;
            }
            set
            {
                this.cboActividadInterna.Enabled = value;
            }
        }

        public bool lTipoActividadHabilitado
        {
            get
            {
                return this.cboTipoActividad.Enabled;
            }
            set
            {
                this.cboTipoActividad.Enabled = value;
            }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDatos(clsActividadEconomica _objActEconomica)
        {
            this.cboTipoActividad.SelectedValue = _objActEconomica.idTipoActividad;
            this.cboActividadInterna.SelectedValue = _objActEconomica.idActividadInterna;
            this.txtAnios.Text = _objActEconomica.nAnios.ToString();
            this.txtDireccion.Text = _objActEconomica.cDireccion;
            this.txtReferencia.Text = _objActEconomica.cReferencia;
            this.txtDescripcion.Text = _objActEconomica.cDescripcion;

            _objActEconomica = null;
        }

        public clsActividadEconomica ObtenerDatos()
        {
            clsActividadEconomica objActEconomica = new clsActividadEconomica();

            objActEconomica.idTipoActividad = Convert.ToInt32(this.cboTipoActividad.SelectedValue);
            objActEconomica.idActividadInterna = Convert.ToInt32(this.cboActividadInterna.SelectedValue);
            objActEconomica.nAnios = Convert.ToInt32(this.txtAnios.Value);
            objActEconomica.cDireccion = this.txtDireccion.Text;
            objActEconomica.cReferencia = this.txtReferencia.Text;
            objActEconomica.cDescripcion = this.txtDescripcion.Text;

            return objActEconomica;
        }

        public void ActualizarActividadInterna(int idActividadInterna)
        {
            this.cboActividadInterna.SelectedValue = idActividadInterna;
        }

        public clsMsjError Validar()
        {
            var objMsjError = new clsMsjError();

            errorProvider.SetError(this.cboTipoActividad, String.Empty);
            errorProvider.SetError(this.cboActividadInterna, String.Empty);
            errorProvider.SetError(this.txtAnios, String.Empty);
            errorProvider.SetError(this.txtDireccion, String.Empty);
            errorProvider.SetError(this.txtReferencia, String.Empty);
            errorProvider.SetError(this.txtDescripcion, String.Empty);

            if (this.chcHabilitado.Checked == true)
            {
                if (!EsTipoActividadValido())
                {
                    objMsjError.AddError("Tipo de Actividad sin seleccionar.");
                    errorProvider.SetError(this.cboTipoActividad, "Seleccione el Tipo de Actividad.");
                }

                if (!EsActividadInternaValido())
                {
                    objMsjError.AddError("Actividad del Cliente sin seleccionar");
                    errorProvider.SetError(this.cboActividadInterna, "Selecciona la Actividad del Cliente.");
                }

                if (!EsAniosValido())
                {
                    objMsjError.AddError("Años de la Actividad en CERO");
                    errorProvider.SetError(this.txtAnios, "Los años de la actividad debe ser mayor a CERO.");
                }

                if (!EsDireccionValido())
                {
                    objMsjError.AddError("Dirección de la Act. en BLANCO");
                    errorProvider.SetError(this.txtDireccion, "Ingrese la dirección de la Actividad.");
                }

                if (!EsReferenciaValido())
                {
                    objMsjError.AddError("Referencia de la Act. en BLANCO");
                    errorProvider.SetError(this.txtReferencia, "Ingrese la referencia de la Dirección.");
                }

                if (!EsDescripcionValido())
                {
                    objMsjError.AddError("Descripción de la Act. en BLANCO");
                    errorProvider.SetError(this.txtDescripcion, "Descripción de la actividad no puede ser en BLANCO.");
                }
            }

            return objMsjError;
        }
        #endregion

        #region Métodos Privados
        private bool EsTipoActividadValido()
        {
            if (this.cboTipoActividad.SelectedIndex == -1 || Convert.ToInt32(this.cboTipoActividad.SelectedValue) == 999)
                return false;
            return true;
        }

        private bool EsActividadInternaValido()
        {
            if (this.cboActividadInterna.SelectedIndex == -1) return false;
            return true;
        }

        private bool EsAniosValido()
        {
            if (String.IsNullOrWhiteSpace(this.txtAnios.Text) || this.txtAnios.Value <= 0) return false;
            return true;
        }

        private bool EsDireccionValido()
        {
            if (String.IsNullOrWhiteSpace(this.txtDireccion.Text)) return false;
            return true;
        }

        private bool EsReferenciaValido()
        {
            if (String.IsNullOrWhiteSpace(this.txtReferencia.Text)) return false;
            return true;
        }

        private bool EsDescripcionValido()
        {
            if (String.IsNullOrWhiteSpace(this.txtDescripcion.Text)) return false;
            return true;
        }

        private void AsignarDataTable()
        {
            DataTable dtTipoActividad = new DataTable();
            dtTipoActividad.Columns.Add("idTipoActividad", typeof(int));
            dtTipoActividad.Columns.Add("cDescripcion", typeof(string));
            dtTipoActividad.Rows.Add(999, "-- Seleccione --");
            dtTipoActividad.Rows.Add(1, "Dependiente");
            dtTipoActividad.Rows.Add(2, "Independiente");

            this.cboTipoActividad.DisplayMember = "cDescripcion";
            this.cboTipoActividad.ValueMember = "idTipoActividad";
            this.cboTipoActividad.DataSource = dtTipoActividad;
        }

        /*private void AgregarBinding()
        {
            this.cboTipoActividad.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingActEconomica, "idTipoActividad", true));
            this.cboActividadInterna.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingActEconomica, "idActividadInterna", true));
            this.txtAnios.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingActEconomica, "nAnios", true));
            this.txtDireccion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingActEconomica, "cDireccion", true));
            this.txtReferencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingActEconomica, "cReferencia", true));
            this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingActEconomica, "cDescripcion", true, DataSourceUpdateMode.OnValidation));
        }*/

        private void Habilitar(bool lHabilitado)
        {
            this.cboTipoActividad.Enabled = lHabilitado;
            this.cboActividadInterna.Enabled = lHabilitado;
            this.txtAnios.Enabled = lHabilitado;
            this.txtDireccion.Enabled = lHabilitado;
            this.txtReferencia.Enabled = lHabilitado;
            this.txtDescripcion.Enabled = lHabilitado;

            this.lblBaseCustom8.Enabled = lHabilitado;
            this.lblBaseCustom10.Enabled = lHabilitado;
            this.lblBaseCustom11.Enabled = lHabilitado;
            this.lblBaseCustom12.Enabled = lHabilitado;
            this.lblBaseCustom13.Enabled = lHabilitado;
        }
        #endregion

        #region Eventos

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                this.txtDescripcion.Text = placeholderDescripcion;
                this.txtDescripcion.ForeColor = SystemColors.GrayText;
            }
        }

        private void chcHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar(this.chcHabilitado.Checked);

            errorProvider.SetError(this.cboTipoActividad, String.Empty);
            errorProvider.SetError(this.cboActividadInterna, String.Empty);
            errorProvider.SetError(this.txtAnios, String.Empty);
            errorProvider.SetError(this.txtDireccion, String.Empty);
            errorProvider.SetError(this.txtReferencia, String.Empty);
            errorProvider.SetError(this.txtDescripcion, String.Empty);
        }

        private void cboTipoActividad_Validating(object sender, CancelEventArgs e)
        {
            if (!EsTipoActividadValido())
                errorProvider.SetError(this.cboTipoActividad, "Seleccione el Tipo de Actividad.");
            else
                errorProvider.SetError(this.cboTipoActividad, String.Empty);
        }

        private void cboActividadInterna_Validating(object sender, CancelEventArgs e)
        {
            if (!EsActividadInternaValido())
                errorProvider.SetError(this.cboActividadInterna, "Selecciona la Actividad del Cliente.");
            else
                errorProvider.SetError(this.cboActividadInterna, String.Empty);
        }

        private void txtAnios_Validating(object sender, CancelEventArgs e)
        {
            if (!EsAniosValido())
                errorProvider.SetError(this.txtAnios, "Los años de la actividad debe ser mayor a CERO.");
            else
                errorProvider.SetError(this.txtAnios, String.Empty);
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDireccionValido())
                errorProvider.SetError(this.txtDireccion, "Ingrese la dirección de la Actividad.");
            else
                errorProvider.SetError(this.txtDireccion, String.Empty);
        }

        private void txtReferencia_Validating(object sender, CancelEventArgs e)
        {
            if (!EsReferenciaValido())
                errorProvider.SetError(this.txtReferencia, "Ingrese la referencia de la Dirección.");
            else
                errorProvider.SetError(this.txtReferencia, String.Empty);
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDescripcionValido())
                errorProvider.SetError(this.txtDescripcion, "Descripción de la actividad no puede ser en BLANCO.");
            else
                errorProvider.SetError(this.txtDescripcion, String.Empty);
        }
        #endregion
    }
}
