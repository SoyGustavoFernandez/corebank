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
    public partial class frmRptSplaftPEP : frmBase
    {
        clsRPTCNSplaft clsrptcnsplaft = new clsRPTCNSplaft();
        String cTitulo = "Reporte de PEPs";

        public frmRptSplaftPEP()
        {
            InitializeComponent();
        }

        private void frmRptSplaftPEP_Load(object sender, EventArgs e)
        {
            this.cboAgencias1.AgenciasYTodos();

            String[] cPerfiles;

            int[] nPerfiles;

            cPerfiles = clsVarApl.dicVarGen["nPerfilesRptSplaftSelecionaAgencia"].Split(',');
            nPerfiles = Array.ConvertAll<string, int>(cPerfiles, int.Parse);
            int idAgenciaUsuario = clsVarGlobal.nIdAgencia;
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            if (idPerfil.In(nPerfiles))
            {
                cboAgencias1.SelectedValue = idAgenciaUsuario;
                cboAgencias1.Enabled = false;
            }
            
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            DateTime dFechaDesde = Convert.ToDateTime("01/" + this.conFechaAñoMesDesde.cPeriodo);
            DateTime dFechaHasta = Convert.ToDateTime(DateTime.DaysInMonth(this.conFechaAñoMesHasta.anio, this.conFechaAñoMesHasta.idMes) + "/" + this.conFechaAñoMesHasta.cPeriodo);
            
            int idAgencia = Convert.ToInt32(this.cboAgencias1.SelectedValue);

            DataTable dtResultado = clsrptcnsplaft.CNListaPEPOpe(idAgencia, dFechaDesde, dFechaHasta);

            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No hay resultados para esos filtros", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            string reportpath = "rptSplaftListaPEP.rdlc";
            dtslist.Add(new ReportDataSource("dsSplaftListaPEP", dtResultado));

            new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
        }
        private Boolean validar()
        {
            if ((Convert.ToDateTime(this.conFechaAñoMesDesde.cPeriodo) > Convert.ToDateTime(this.conFechaAñoMesHasta.cPeriodo)))
            {
                MessageBox.Show("La fecha fin no puede ser menor que la fecha inicio", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}
