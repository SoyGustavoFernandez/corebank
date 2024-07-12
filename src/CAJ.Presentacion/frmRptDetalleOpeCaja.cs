using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptDetalleOpeCaja : frmBase
    {
        public frmRptDetalleOpeCaja()
        {
            InitializeComponent();
        }

        private void frmRptDetalleOpe_Load(object sender, EventArgs e)
        {
            DatosUsuario();           
        }

        private void DatosUsuario()
        {
            //dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            //txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            //txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                //txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                //txtNomUsu.Text = "";
            }
            this.dtpFecProcIni.Value = clsVarGlobal.dFecSystem;
        }        

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFechaIni = this.dtpFecProcIni.Value;
            DateTime dFechaFin = this.dtpFecProcIni.Value;
            int idUsu = clsVarGlobal.User.idUsuario;
            int idAge = clsVarGlobal.nIdAgencia;
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            if (new clsRPTCNCaja().CNDetallOperaciones(dFechaIni, idUsu, idAge, idTipResCaj).Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Detalle de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsKardex", new clsRPTCNCaja().CNDetallOperaciones(dFechaIni, idUsu, idAge, idTipResCaj)));

            bool lFiltroRSC = false;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("lFiltroRSC", lFiltroRSC.ToString(), false));

            string reportpath = "rptDetalleOpe.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
            

        }
    }
}
