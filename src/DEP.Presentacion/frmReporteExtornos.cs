using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteExtornos : frmBase
    {
        public frmReporteExtornos()
        {
            InitializeComponent();
            DataRow dr = cboModulo.dtModulo.NewRow();
            dr["idModulo"] = "0";
            dr["cModulo"] = "TODOS";
            dr["cDescripcion"] = "";
            dr["cComponente"] = "";
            dr["lBaseNegativa"] = 0;
            cboModulo.dtModulo.Rows.Add(dr);
        }        

        private void btnImprimir1_Click(object sender, System.EventArgs e)
        {
           //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Reporte de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtFecInicio.Focus();
                return;
            }
            if (cboAgencia.Text.Trim()=="")
            {
                MessageBox.Show("Seleccione la Agencia", "Reporte de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencia.Focus();
                return;
            }
            if (cboModulo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Módulo", "Reporte de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModulo.Focus();
                return;
            }        
                                                   
            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cAgenciaExtornos = cboAgencia.Text;
            string cNomModulo = cboModulo.Text;
            int x_idModulo = Convert.ToInt16(cboModulo.SelectedValue);
           
            DataTable dtDatosExtorno = new clsRPTCNDeposito().CNDatosExtornos(dFecInicio, dFecFin, Convert.ToInt32(cboAgencia.SelectedValue), x_idModulo);
                
            if (dtDatosExtorno.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Extornos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cAgencia", cAgenciaExtornos, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomModulo", cNomModulo, false));
                    
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosExtorno", dtDatosExtorno));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptListaExtornos.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();                    
            }
        }        

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date; 
            cboAgencia.SelectedIndex = -1;
        }

        private void frmReporteExtornos_Load(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date; 
            //cboAgencia.SelectedIndex = -1;
            cboAgencia.SelectedValue = 0;
        }
    }
}
