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
using Microsoft.Reporting.WinForms;
using CLI.CapaNegocio;
using RPT.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmReporteCuentasCli : frmBase
    {
        clsCNSocio cnsocio = new clsCNSocio();

        public frmReporteCuentasCli()
        {
            InitializeComponent();
        }

        private void frmReporteCuentasCli_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            btnImprSocio.Enabled = false;          
        }        

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0)
            { 
                btnImprSocio.Enabled = false;
            }
            else
            {
                btnImprSocio.Enabled = true;
            }
        }

        private void btnImprSocio_Click(object sender, EventArgs e)
        {
            int idCli = Convert.ToInt32(conBusCli1.txtCodCli.Text);
            int idEstado = Convert.ToInt32(cboEstadoCuentaCli1.SelectedValue);
            string cNomEmp      = clsVarApl.dicVarGen["cNomEmpresa"];
            String AgenEmision  = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("pnidCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("idCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

            int lMostrarCuentaAhorro = 0;
            if (CHKVerCuentasAhorro.Checked) lMostrarCuentaAhorro = 1;

            paramlist.Add(new ReportParameter("lMostrarCuentaAhorro", lMostrarCuentaAhorro.ToString(), false));            

            dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoCliente(idCli)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            dtslist.Add(new ReportDataSource("dtsAportes", cnsocio.CNHistoricoAportes(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsFondoSeg", cnsocio.CNHistoricoFondoSeguro(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsCliAval", cnsocio.CNHistoricoCliComoAval(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsCreCli", cnsocio.CNHistoricoCre(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsAhorrroCli", cnsocio.CNHistoricoDeposito(idCli, idEstado)));

            string reportpath = "rptCuentasCli.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog(); 
        }
    }
}
