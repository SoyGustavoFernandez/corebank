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
using GEN.CapaNegocio;
//using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmRptCreditosConOpinionRiesgos : frmBase
    {
        #region Variables
        clsCNCro cnRptRsg = new clsCNCro();
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        #endregion

        public frmRptCreditosConOpinionRiesgos()
        {
            InitializeComponent();
        }

        private void frmRptCreditosConOpinionRiesgos_Load(object sender, EventArgs e)
        {
            cargarAnalistasCbo();
            this.dFechaIni.Value = dFechaHoy;
            this.dFechaFin.Value = dFechaHoy;
        }

        private void cargarAnalistasCbo()
        {
            DataTable data = cnRptRsg.ListarAnalistasRiesgos();
            cboAnalista.ValueMember = "idUsuario";
            cboAnalista.DisplayMember = "cNombre";

            DataRow row = data.NewRow();
            row["idUsuario"] = 0;
            row["cNombre"] = "* TODOS *";
            data.Rows.Add(row);

            cboAnalista.DataSource = data;
            cboAnalista.SelectedValue = 0;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtData = cnRptRsg.rptCreditosConOpinionRiesgos(
                    Convert.ToDateTime(dFechaIni.Value),
                    Convert.ToDateTime(dFechaFin.Value),
                    Convert.ToInt32(cboAnalista.SelectedValue)
                );

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();



            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.Value.ToString(), false));

            dtslist.Add(new ReportDataSource("datos", dtData));

            string reportpath = "rptCreditosOpinionRiesgoAnalista.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
