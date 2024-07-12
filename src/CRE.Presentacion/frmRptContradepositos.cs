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
using CRE.CapaNegocio;

using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmRptContradepositos : frmBase
    {
        public frmRptContradepositos()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("x_idAgencia", "5", false));
            paramlist.Add(new ReportParameter("x_idClaseGarantia", Convert.ToString(cboClaseGarantia.SelectedValue), false));
            paramlist.Add(new ReportParameter("x_dFecha", (dtpFecha.Value).ToString(), false));
            paramlist.Add(new ReportParameter("x_claseGarantia", cboClaseGarantia.Text, false));

            DataTable dtRes = conListAgencias.obtenerAgenciasSeleccionados();
            DataSet dsRes = new DataSet("dsAgencia");

            dsRes.Tables.Add(dtRes);
            string cXmlAgencias = dsRes.GetXml();

            //MessageBox.Show(cXmlAgencias);

            //DataTable contradepositos = new clsCNGarantia().CNRptContradepositos( cboAgencias.SelectedValue, cboClaseGarantia.SelectedValue , dtpFecha.Value);
            DataTable contradepositos = new clsCNGarantia().CNRptContradepositos(cXmlAgencias, Convert.ToInt32(cboClaseGarantia.SelectedValue), dtpFecha.Value);
            dtslist.Add(new ReportDataSource("dataContradepositos", contradepositos));

            string reportpath = "rptContradepositos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptContradepositos_Load(object sender, EventArgs e)
        {
            cboClaseGarantia.cargarClaseByGrupo(1,true);
        }

    }
}
