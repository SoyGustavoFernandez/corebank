using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmRptVenciTasacion : frmBase
    {
        #region Variable Globales

        clsCNGarantia cngarantia = new clsCNGarantia();

        #endregion

        public frmRptVenciTasacion()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtVenceTasacion = cngarantia.CNRptVencimientoTasacion(Convert.ToInt32(txtDiasVencidos.Text));

                if (dtVenceTasacion.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para los parámetros seleccionados", "Validación de reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dsVenceTasacion", dtVenceTasacion));

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("nDias", txtDiasVencidos.Text, false));
                string reportpath = "rptVencimientoTasaciones.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lVal = false;

            if (string.IsNullOrEmpty(txtDiasVencidos.Text))
            {
                MessageBox.Show("Por favor asigne un valor en el número de días vencidos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiasVencidos.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        #endregion
    }
}
