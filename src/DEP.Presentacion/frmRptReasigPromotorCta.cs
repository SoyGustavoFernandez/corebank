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
    public partial class frmRptReasigPromotorCta : frmBase
    {
        int idPromotor = 0;

        public frmRptReasigPromotorCta()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            if (this.conBusCol.idUsu.Equals(""))
            {
                MessageBox.Show("No existe el código del promotor", "Validar promotor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
          
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            if (!chcPromotor.Checked)
            {
                if (idPromotor == null || idPromotor == 0)
                {
                    MessageBox.Show("Seleccione un colaborador antes de generar el reporte", "Reporte de Reasignación de Promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            DateTime dFecIni =dtpFecIni.Value;
            DateTime dFecFin =dtpFecFin.Value;
            if (dFecFin>clsVarGlobal.dFecSystem )
            {
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha del sistema", "Reporte de Reasignación de Promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dFecIni>dFecFin)
            {
                 MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "Reporte de Reasignación de Promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            int    idAgeDes=Convert.ToInt32(cboAgencias.SelectedValue);
            DataTable dtDatReasigPromotor = new clsRPTCNDeposito().ADDatosReasigPromPorPromotor( dFecIni ,    dFecFin ,     idAgeDes , idPromotor);

            if (dtDatReasigPromotor.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de reasignación de promotores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("idAgeDes", idAgeDes.ToString(), false));
                paramlist.Add(new ReportParameter("idUsuDes", idPromotor.ToString(), false));

                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReasigProm", dtDatReasigPromotor));

                string reportpath = "rptReasignacionPromotor.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.conBusCol.LimpiarDatos();
            conBusCol.idUsu = "";
            conBusCol.cNom = "";
            conBusCol.cDocID = "";
            conBusCol.idCargoPer = "";
            conBusCol.cCargoPer = "";
            conBusCol.idCliPer = "";
            conBusCol.nPorLibVia = 0;
            conBusCol.idAgencia = "";
            this.conBusCol.HabilitarControles(true);
        }

        private void chcPromotor_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPromotor.Checked)
            {
                conBusCol.Enabled = false;
                conBusCol.LimpiarDatos();
                conBusCol.idUsu = "";
                conBusCol.cNom = "";
                conBusCol.cDocID = "";
                conBusCol.idCargoPer = "";
                conBusCol.cCargoPer = "";
                conBusCol.idCliPer = "";
                conBusCol.nPorLibVia = 0;
                conBusCol.idAgencia = "";
            }
            else
            {
                conBusCol.Enabled = true;
            }
        }

        private void frmRptReasigPromotorCta_Load(object sender, EventArgs e)
        {
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
        }

     
    }
}
