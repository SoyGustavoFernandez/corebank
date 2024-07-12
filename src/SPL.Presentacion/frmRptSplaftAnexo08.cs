using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmRptSplaftAnexo08 : frmBase
    {
        private int idAgenciaUsuarioLogeado = 0;
        public frmRptSplaftAnexo08()
        {
            InitializeComponent();
        }

        private void frmRptSplaftAnexo08_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem.AddMonths(-3);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;

            String[] cPerfiles;

            int[] nPerfiles;

            cPerfiles = clsVarApl.dicVarGen["nPerfilesRptSplaftSelecionaAgencia"].Split(',');
            nPerfiles = Array.ConvertAll<string, int>(cPerfiles, int.Parse);
            int idAgenciaUsuario = clsVarGlobal.nIdAgencia;
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            if (idPerfil.In(nPerfiles))
            {
                idAgenciaUsuarioLogeado = idAgenciaUsuario;
            }
            else
            {
                idAgenciaUsuarioLogeado = 0;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtpFechaInicio.Value.Date;
            DateTime dFechaFinal = dtpFechaFin.Value.Date;

            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtSplaftAnexo08 = new clsRPTCNSplaft().CNSplaftAnexo08(dFechaInicio, dFechaFinal, idAgenciaUsuarioLogeado);
            if (dtSplaftAnexo08.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el anexo", "Anexo 08", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgencia", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaInicio", dFechaInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFinal", dFechaFinal.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsSplaftAnexo08", dtSplaftAnexo08));

                string reportpath = "RptSplaftAnexo08.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
