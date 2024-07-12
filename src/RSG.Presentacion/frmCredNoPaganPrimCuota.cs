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
using GEN.CapaNegocio;
//using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using RSG.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RSG.Presentacion
{
    public partial class frmCredNoPaganPrimCuota : frmBase
    {
        #region Variables Globales
        DateTime dFechaConsulta,dFechaCierre,dFechaHasta;
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Créditos que no pagan Primera Cuota";
        clsCNCro CNCredNoPagan = new clsCNCro();
        string cMes="NO_MES";
        #endregion
        #region Eventos
        public frmCredNoPaganPrimCuota()
        {
            InitializeComponent();
            this.datePicker1.Value = dFechaHoy;
            this.datePicker2.Value = dFechaHoy;
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Reporte();
        }
        #endregion
        #region Metodos
         private void Reporte()
         {
             string cMesEnvio;
             dFechaConsulta = Convert.ToDateTime(this.datePicker1.Value);
             dFechaHasta = Convert.ToDateTime(this.datePicker2.Value);
             dFechaCierre=dFechaConsulta.AddDays(-1);
             string dFecOpe = Convert.ToString(dFechaHoy);
             string cNomAgen = clsVarGlobal.cNomAge.ToString();
             string cierre = Convert.ToString(dFechaHasta);
             int idMesCierre = dFechaHasta.Month;
             int idMesConsulta = dFechaConsulta.Month;
             int idAnioCierre = dFechaHasta.Year;
             int idAnioConsulta = dFechaConsulta.Year;
             string cMesCierre = Convert.ToString(dFechaHasta.Month);
             string cAnioCierre = Convert.ToString(dFechaHasta.Year);
             Meses(idMesCierre);
             string cMes1=cMes;
             if (idMesCierre <= 9)
             {
                 cMesEnvio = cAnioCierre + "-0" + cMesCierre;
             }
             else
             {
                 cMesEnvio = cAnioCierre + "-" + cMesCierre;
             }
             if (idAnioCierre > idAnioConsulta)
             {
                 if (dFechaConsulta <= dFechaHoy)
                 {
                     DataTable dtData = CNCredNoPagan.credNoPagan(dFechaConsulta, cMesEnvio);//(dFechaDesde, dFechaHasta);
                     if (dtData.Rows.Count > 0)
                     {
                         List<ReportDataSource> dtsList = new List<ReportDataSource>();
                         dtsList.Add(new ReportDataSource("dsCredNoPagan", dtData));

                         List<ReportParameter> paramlist = new List<ReportParameter>();

                         paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                         paramlist.Add(new ReportParameter("dFecOpe", dFecOpe, false));
                         paramlist.Add(new ReportParameter("dFechaConsulta", dFechaConsulta.ToString(), false));
                         paramlist.Add(new ReportParameter("cMesConsulta", cMesEnvio.ToString(), false));
                         paramlist.Add(new ReportParameter("dFechaCierre", dFechaCierre.ToString(), false));
                         paramlist.Add(new ReportParameter("cMes", cMes1.ToString(), false));
                         paramlist.Add(new ReportParameter("cAnio", cAnioCierre.ToString(), false));


                         string reportPath = "rptCredNoPagan.rdlc";//
                         new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                     }
                     else
                     {
                         MessageBox.Show("No existe algún valor.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                 }
                 else
                 {
                     MessageBox.Show("La fecha de Consulta debe de ser menor o igual que la fecha actual.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     this.datePicker1.Focus();
                 }
             }
             else if (idAnioCierre == idAnioConsulta)
             {
                 if (idMesCierre >= idMesConsulta)
                 {
                     if (dFechaConsulta <= dFechaHoy)
                     {
                         DataTable dtData = CNCredNoPagan.credNoPagan(dFechaConsulta, cMesEnvio);//(dFechaDesde, dFechaHasta);
                         if (dtData.Rows.Count > 0)
                         {
                             List<ReportDataSource> dtsList = new List<ReportDataSource>();
                             dtsList.Add(new ReportDataSource("dsCredNoPagan", dtData));

                             List<ReportParameter> paramlist = new List<ReportParameter>();

                             paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                             paramlist.Add(new ReportParameter("dFecOpe", dFecOpe, false));
                             paramlist.Add(new ReportParameter("dFechaConsulta", dFechaConsulta.ToString(), false));
                             paramlist.Add(new ReportParameter("cMesConsulta", cMesEnvio.ToString(), false));
                             paramlist.Add(new ReportParameter("dFechaCierre", dFechaCierre.ToString(), false));
                             paramlist.Add(new ReportParameter("cMes", cMes1.ToString(), false));
                             paramlist.Add(new ReportParameter("cAnio", cAnioCierre.ToString(), false));

                             string reportPath = "rptCredNoPagan.rdlc";//
                             new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                         }
                         else
                         {
                             MessageBox.Show("No existe algún valor.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         }
                     }
                     else
                     {
                         MessageBox.Show("La fecha de Consulta debe de ser menor o igual que la fecha actual.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         this.datePicker1.Focus();
                     }
                 }
                 else
                 {
                     MessageBox.Show("El Mes seleccionado debe de ser mayor o igual al mes actual", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     this.datePicker1.Focus();
                 }
             }
             else
             {
                 MessageBox.Show("El Mes y Año seleccionados respectivamente deben de ser mayores o iguales que la fecha actual.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 this.datePicker1.Focus();
             }
         }

         private void Meses(int idMes)
         {             
             if (idMes == 1) { cMes = "ENERO"; }
             if (idMes == 2) { cMes = "FEBRERO"; }
             if (idMes == 3) { cMes = "MARZO"; }
             if (idMes == 4) { cMes = "ABRIL"; }
             if (idMes == 5) { cMes = "MAYO"; }
             if (idMes == 6) { cMes = "JUNIO"; }
             if (idMes == 7) { cMes = "JULIO"; }
             if (idMes == 8) { cMes = "AGOSTO"; }
             if (idMes == 9) { cMes = "SEPTIEMBRE"; }
             if (idMes == 10) { cMes = "OCTUBRE"; }
             if (idMes == 11) { cMes = "NOVIEMBRE"; }
             if (idMes == 12) { cMes = "DICIEMBRE"; }
         }
        #endregion
    }
}
