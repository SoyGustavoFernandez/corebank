using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptConcentracionCarteraAsesTramo : frmBase
    {
        public frmRptConcentracionCarteraAsesTramo()
        {
            InitializeComponent();
            cargar();
        }

        private void frmRptConcentracionCarteraAsesTramo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string cNomEmp  = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin  = clsVarGlobal.User.cWinUser;
            int idAgencia   = cboAgencia.SelectedIndex;
            
            if (!validar())
                return;
            
            DateTime dFecha = dtpFechaProceso.Value;
            clsRPTCNCredito rptCredito = new clsRPTCNCredito();
            DataTable dtRptConceCartAsesTramo = rptCredito.CNRptConcentCartAseTramo(idAgencia, dFecha);

            if (dtRptConceCartAsesTramo.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNombreAge", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("nTipoCambio", EntityLayer.clsVarApl.dicVarGen["nTipoCambio"].ToString(), false)); 
                paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));


                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("carteraOficinaAsesorTramoDiasMora", dtRptConceCartAsesTramo));

                string reportpath = "rptConCarteraOfiAsesorTramosDiaMora.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Datos para este Reporte", "Concentración de Cartera Oficina, Asesor y Tramos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencia.Focus();
                return;
            }
        }


        private Boolean validar()
        {
            if (dtpFechaProceso.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("Seleccione fecha anterior a : " + clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), "Concentración de Cartera Oficina, Asesor y Tramos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboAgencia.SelectedIndex < 0) 
            {
                MessageBox.Show("No se ha seleccionado la agencia" , "Concentración de Cartera Oficina, Asesor y Tramos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        
    }
}
