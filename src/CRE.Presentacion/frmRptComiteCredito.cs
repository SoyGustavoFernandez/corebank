using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
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
    public partial class frmRptComiteCredito : frmBase
    {
        #region Propiedades
        private int idZona;
        private int idAgencia;
        private DateTime dFechaInicio;
        private DateTime dFechaFin;

        private clsRPTCNCredito objRPTCNCredito;
        #endregion

        public frmRptComiteCredito()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.idZona = 0;
            this.idAgencia = 0;
            this.dFechaInicio = clsVarGlobal.dFecSystem;
            this.dFechaFin= clsVarGlobal.dFecSystem;

            this.objRPTCNCredito = new clsRPTCNCredito();

            this.cboZona.cargarZona(true, false);
            this.dtpFechaInicio.Value = this.dFechaInicio;
            this.dtpFechaFin.Value = this.dFechaFin;

            this.cboZona.SelectedIndexChanged -= cboZona_SelectedIndexChanged;
            this.cboZona.SelectedIndex = -1;
            this.cboZona.SelectedIndexChanged += cboZona_SelectedIndexChanged;

            this.cboAgencia.SelectedIndexChanged -= cboAgencia_SelectedIndexChanged;
            this.cboAgencia.SelectedIndex = -1;
            this.cboAgencia.SelectedIndexChanged += cboAgencia_SelectedIndexChanged;

        }

        private bool validarSeleccion()
        {
            if (this.cboZona.SelectedIndex < 0)
            {
                MessageBox.Show("¡Debe seleccionar la Zona!","ZONA NO SELECCIONADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("¡Debe seleccionar la Agencia!","AGENCIA NO SELECCIONADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.dtpFechaInicio.Value > clsVarGlobal.dFecSystem || this.dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show(string.Concat("Las fechas de inicio y fin deben ser menores a la fecha del sistema (",clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"),")."),
                    "RANGO DE FECHAS INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
            {
                MessageBox.Show(string.Concat("La fecha de inicio debe ser menor a la fecha de fin (", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), ")."),
                    "RANGO DE FECHAS INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region Eventos
        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZona.SelectedIndex >= 0)
            {
                this.idZona = Convert.ToInt32(this.cboZona.SelectedValue);
                this.cboAgencia.FiltrarPorZonaTodos(this.idZona);

                this.cboAgencia.SelectedIndexChanged -= cboAgencia_SelectedIndexChanged;
                this.cboAgencia.SelectedIndex = -1;
                this.cboAgencia.SelectedIndexChanged += cboAgencia_SelectedIndexChanged;
            }
            else
            {
                this.idZona = 0;
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAgencia.SelectedIndex >= 0)
            {
                this.idAgencia = Convert.ToInt32(this.cboAgencia.SelectedValue);
            }
            else
            {
                this.idAgencia = 0;
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            this.dFechaInicio = this.dtpFechaInicio.Value;
            this.dtpFechaFin.ValueChanged -= dtpFechaFin_ValueChanged;
            this.dtpFechaFin.Value = this.dtpFechaInicio.Value.AddDays(30);
            this.dFechaFin = this.dtpFechaFin.Value;
            this.dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            this.dFechaFin = this.dtpFechaFin.Value;
            int nDiasRango = (int)(this.dFechaFin - this.dFechaInicio).TotalDays + 1;
            DateTime dFechaIniTemp = this.dFechaInicio;
            if (nDiasRango > 31)
            {
                this.dFechaFin = dFechaIniTemp.AddDays(30);

                MessageBox.Show("El rango máximo permitido entre la Fecha Inicio y la Fecha Fin es de 31 días.\n\n" +
                    string.Concat("* La selección actual tiene ", nDiasRango, " días.\n",
                    "** Se establecerá la Fecha Fin al ", this.dFechaFin.ToString("dd/MM/yyyy"),"."),"RANGO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dtpFechaFin.ValueChanged -= dtpFechaFin_ValueChanged;
                this.dtpFechaFin.Value = this.dFechaFin;
                this.dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!this.validarSeleccion()) return;

            DataSet dsComiteCredito = objRPTCNCredito.rptComiteCreditoDetallado(this.idZona,this.idAgencia,this.dFechaInicio, this.dFechaFin);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("DSComiteCreditoOrdinario", dsComiteCredito.Tables[0]));
            dtsList.Add(new ReportDataSource("DSComiteCreditoExtraordinario", dsComiteCredito.Tables[1]));

            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("idZona", this.idZona.ToString(), false));
            paramList.Add(new ReportParameter("idAgencia", this.idAgencia.ToString(), false));
            paramList.Add(new ReportParameter("dFechaInicio", this.dFechaInicio.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("dFechaFin", this.dFechaFin.ToString("dd/MM/yyyy"), false));

            string reportPath = "rptComiteCreditoDetallado.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
