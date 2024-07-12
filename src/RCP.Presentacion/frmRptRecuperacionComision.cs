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
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmRptRecuperacionComision : frmBase
    {
        #region Variables Globales
        #endregion
        public frmRptRecuperacionComision()
        {
            InitializeComponent();
        }

        
        #region Metodos
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFechaComision.Value;
            DataSet dsReporte = (new clsCNRecuperacionComision()).recuperacionComisionHistorico(dFecha);

            if (dsReporte.Tables.Count == 3)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.User.cEstablecimiento, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
                paramlist.Add(new ReportParameter("idZona", "0", false));
                paramlist.Add(new ReportParameter("idEstablecimiento",clsVarGlobal.User.idEstablecimiento.ToString(), false));
                paramlist.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy") , false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRecupComisionHistorico", dsReporte.Tables[0]));
                dtslist.Add(new ReportDataSource("dsRecupComisionHistoricoEspecial", dsReporte.Tables[1]));
                dtslist.Add(new ReportDataSource("dsEvolucionRecupComision", dsReporte.Tables[2]));

                string reportpath = "rptRecuperacionComisionHistorico.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
