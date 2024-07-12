using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using CNT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmRptIngresoCreditos : frmBase
    {
        List<ReportParameter> paramlist = new List<ReportParameter>();

        public frmRptIngresoCreditos()
        {
            InitializeComponent();
        }

        private void frmRptIngresoCreditos_Load(object sender, EventArgs e)
        {

        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {

        }
        void parametros()
        {
            if (Valida())
            {
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
                paramlist.Add(new ReportParameter("x_idagencia", cboAgencia.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            }
            else
            {
                return;
            }
        }

        Boolean Valida()
        {
            Boolean lEstado = true;
            if (dFecFin.Value < dFecIni.Value)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la fecha inicial");
                lEstado = false;
                return lEstado;
            }
            return lEstado;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            parametros();            
            string reportpath = "";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);

            dtslist.Add(new ReportDataSource("dtsOperaciones", new clsCNBalance().CNResumCobranAge(dFecIni.Value, dFecFin.Value, idAgencia)));
            reportpath = "RptResumenOperacionesCNTAge.rdlc";                
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
