using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmRptCreditosGarantias : frmBase
    {
        clsCNGarantia cngarantia = new clsCNGarantia();

        public frmRptCreditosGarantias()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia1.SelectedValue);
            cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private bool validar()
        {
            bool lVal = false;

            if ((dtpFecIni.Value-dtpFecFin.Value).Days > 0)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "Validación del rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }


            lVal = true;
            return lVal;
        }

        private void cboGrupoGarantia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoGarantia1.SelectedIndex >= 0)
            {
                cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia1.SelectedValue);
            }
        }

        private void cboClaseGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClaseGarantia.SelectedIndex >= 0)
            {
                cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var idTipoGarantia = Convert.ToInt32(this.cboTipoGarantia.SelectedValue);
                DataTable dtCreGarantias = cngarantia.RptCreditosGarantias(dtpFecIni.Value, dtpFecFin.Value, idTipoGarantia);

                if (dtCreGarantias.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para los parámetros seleccionados", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dsCreGarantias", dtCreGarantias));                
                paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idTipoGarantia", idTipoGarantia.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));


                string reportpath = "rptCreditoGarantia.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
