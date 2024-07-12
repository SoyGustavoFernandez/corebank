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
    public partial class frmRptSegCarteraClasiRiesgoAliInt : frmBase
    {

        #region Variables Globales
            string cNomUser = clsVarGlobal.User.cNomUsu;
            string cTituloMsjes = "Seguimiento de Cartera Clasificación Riesgo Alineacion Interna";
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            clsCNCro cnRptRsg = new clsCNCro();
            int cIdUser = clsVarGlobal.User.idUsuario;
          
        #endregion
        #region eventos
            public frmRptSegCarteraClasiRiesgoAliInt()
            {
                InitializeComponent();
                this.txtBase1.Text = cNomUser;
                this.datePicker1.Value = dFechaSistema;
               
            }      
            private void btnImprimir1_Click_1(object sender, EventArgs e)
            {
                Reporte();
            }
               


        #endregion
        #region metodos

            private void Reporte()
            {
                string dFecOpe = Convert.ToString(dFechaSistema);//"2016-08-31"; 
                string cNomAgen = clsVarGlobal.cNomAge.ToString();
                int idUsuario = Convert.ToInt32(cIdUser);//1034;
                DateTime dFechaConsul = Convert.ToDateTime(this.datePicker1.Value);
                dFechaConsul = dFechaConsul.AddDays(-1);
                string dFechaConsulta = dFechaConsul.ToString("yyyy/MM/dd");
                MessageBox.Show("Se realizará el reporte con la fecha: "+dFechaConsulta, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable dtData = cnRptRsg.segCarteraClasiRiesgoInt(dFechaConsul, idUsuario);
                    if (dtData.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsSegCarteraRiesgo", dtData));

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Add(new ReportParameter("nCodeUsuario", cIdUser.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                        paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                        paramlist.Add(new ReportParameter("dFechaConsulta", dFechaConsulta.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                        string reportPath = "rptSegCartxClasiriesgoAlInterna.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                        new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para esta fecha. ", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

            }
            
 
        #endregion

    }
}
