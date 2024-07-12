using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmRptHistoricoReasigPromotorCta : frmBase
    {
        int idPromotor = 0;

        public frmRptHistoricoReasigPromotorCta()
        {
            InitializeComponent();
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (this.conBusCol.idUsu==null)
            {
                MessageBox.Show(@"No existe el código del promotor", "Validar promotor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.conBusCol.idUsu.Equals(""))
            {
                MessageBox.Show(@"No existe el código del promotor", "Validar promotor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.conBusCol.idUsu != null && Convert.ToInt32(this.conBusCol.idUsu) > 0)
            {
                this.conBusCol.HabilitarControles(false);
                idPromotor = Convert.ToInt32(this.conBusCol.idUsu);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            //Seccion Busqueda por Promotor
            //VALIDACIONES
            if (this.idPromotor == null || this.idPromotor == 0)
            {
                MessageBox.Show("Seleccione un colaborador antes de generar el reporte", "Reporte de historico de reasignación de promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecIni=dtpFecIni.Value ;
            DateTime dFecFin=dtpFecFin.Value;

            if (dFecFin > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha del sistema", "Reporte de Reasignación de Promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dFecIni > dFecFin)
            {
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "Reporte de Reasignación de Promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDatosHistReasigPromotor = new clsRPTCNDeposito().ADDatosHistReasigPromPorPromotor(idPromotor, dFecIni, dFecFin);

            if (dtDatosHistReasigPromotor.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de historico de reasignación de promotores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();


                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));

                paramlist.Add(new ReportParameter("idPersonal",idPromotor.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToShortDateString(), false));
                                                
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsHistReasigProm", dtDatosHistReasigPromotor));

                string reportpath = "rptHistoricoReasignacionPromotor.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idPromotor = 0;
            this.conBusCol.LimpiarDatos();
            this.conBusCol.HabilitarControles(true);
        }
    }
}
