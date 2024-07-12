using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmRPTMantenimientoSeguroOptativo : frmBase
    {
        public frmRPTMantenimientoSeguroOptativo()
        {
            InitializeComponent();
        }

        private void frmRPTMantenimientoSeguroOptativo_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            CargaInicial();
        }

        private void CargaInicial()
        {
            //FECHAS
            dtpDesde.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
            dtpHasta.Value = clsVarGlobal.dFecSystem;

            //COMBO SEGUROS
            List<clsSolicitudCreditoSeguro> dtListaSeguros = DataTableToList.ConvertTo<clsSolicitudCreditoSeguro>(new clsCNConfigurarSeguroOptativo().CNListaSeguroOptativo()).ToList<clsSolicitudCreditoSeguro>();

            if (dtListaSeguros.Count > 0)
            {
                cboSeguros.DataSource = dtListaSeguros.FindAll(x => x.lVigente && x.lHistorico);
                cboSeguros.DisplayMember = "cTipoSeguro";
                cboSeguros.ValueMember = "idTipoSeguro";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idSeguro = Convert.ToInt32(cboSeguros.SelectedValue);

            DataTable dtDatosHistorico  = new clsCNHistoricoSegurosOptativos().CNObtenerHistoricoSegurosOptativos(dFechaDesde, dFechaHasta, idSeguro);

            if (dtDatosHistorico.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsHistoricoSeguros", dtDatosHistorico));

            string reportpath = "rptHistoricoSeguroOptativo.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private bool validar()
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}