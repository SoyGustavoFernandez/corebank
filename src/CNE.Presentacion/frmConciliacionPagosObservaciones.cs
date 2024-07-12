using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmConciliacionPagosObservaciones : frmBase
    {
        #region Variables

        private clsCNConciliacionPagos API = new clsCNConciliacionPagos();
        private enum StatusCode
        {
            OK = 200,
            BadRequest = 400
        }

        #endregion

        #region Metodos Publicos

        public frmConciliacionPagosObservaciones(DateTime dFechaConci, int idCanal)
        {
            InitializeComponent();
            CargarComboCanales(idCanal);
            CargarDatapickerFechaCarga(dFechaConci);
            CargarComboEstadoObs();
            CargarEstadosPorDefecto();
            HabilitarGrabarPorCanalYFecha();
            ObtenerBitacoraConciliacion();
        }

        #endregion

        #region Metodos Privados

        private void CargarComboCanales(int idCanal)
        {
            var dtCanales = new clsCNConciliacionPagos().ObtenerConfiguracionCanalesElectronicos();

            List<object> listCanales = new List<object>();

            foreach (DataRow row in dtCanales.Rows)
            {
                var objeto = new
                {
                    idCanal = Convert.ToInt32(row["idCanal"]),
                    cNombreCanal = row["cNombreCanal"].ToString()
                };
                listCanales.Add(objeto);
            }

            this.cboCanal.DataSource = listCanales;
            this.cboCanal.ValueMember = "idCanal";
            this.cboCanal.DisplayMember = "cNombreCanal";
            this.cboCanal.SelectedValue = idCanal;
            this.cboCanal.Enabled = false;
        }

        private void CargarDatapickerFechaCarga(DateTime dFechaConci)
        {
            this.dtpFechaObs.Enabled = false;
            this.dtpFechaObs.Value = dFechaConci.Date;
        }

        private void CargarComboEstadoObs()
        {
            var callResult = API.ObtenerEstadosBitacora();
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtEstadoConci = callResult.Data;

            if (dtEstadoConci.Rows.Count <= 0)
            {
                this.cboEstadoObs.DataSource = null;
                return;
            }

            this.cboEstadoObs.DataSource = dtEstadoConci;
            this.cboEstadoObs.ValueMember = "idEstadoBitacora";
            this.cboEstadoObs.DisplayMember = "cEstadoBitacora";
        }

        private void CargarEstadosPorDefecto()
        {
            this.cboEstadoObs.SelectedValue = 1;
            this.txtDescripcion.Text = string.Empty;
        }

        private void HabilitarGrabarPorCanalYFecha()
        {
            if (this.dtpFechaObs.Value == clsVarGlobal.dFecSystem.AddDays(-1) ||
                this.dtpFechaObs.Value == clsVarGlobal.dFecSystem)
            {
                this.btnGrabar.Enabled = true;
                this.txtDescripcion.Enabled = true;
            }
            else
            {
                this.btnGrabar.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
        }

        private void ObtenerBitacoraConciliacion()
        {
            DateTime dFechaIni = this.dtpFechaObs.Value;
            DateTime dFechaFin = this.dtpFechaObs.Value;
            int idCanal = (int)this.cboCanal.SelectedValue;

            var callResult = API.ObtenerBitacoraConciliacion(dFechaIni, dFechaFin, idCanal);
            if (callResult == null) return;
            if (callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtBitacora = callResult.Data;

            if (dtBitacora.Rows.Count <= 0)
            {
                this.dtgConciliacionPagosObservacion.DataSource = null;
                return;
            }

            this.dtgConciliacionPagosObservacion.DataSource = dtBitacora;
            this.dtgConciliacionPagosObservacion.Refresh();
        }

        #endregion

        #region Eventos

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea guardar la observación?", "Bitácora de Observaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                return;

            var data = new
            {
                dFechaConci = this.dtpFechaObs.Value,
                idEstado = Convert.ToInt32(this.cboEstadoObs.SelectedValue),
                idCanal = Convert.ToInt32(this.cboCanal.SelectedValue),
                cDescripcion = this.txtDescripcion.Text.Trim(),
                cUsuarioReg = clsVarGlobal.User.cNomUsu
            };

            var callResult = API.GuardarBitacoraConciliacion(data);
            if(callResult == null) return;
            if(callResult.StatusCode == (int)StatusCode.BadRequest)
            {
                MessageBox.Show(callResult.Error, "Registro de Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            MessageBox.Show(callResult.Response, "Registro de Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ObtenerBitacoraConciliacion();
            CargarEstadosPorDefecto();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarEstadosPorDefecto();
        }

        #endregion
    }
}
