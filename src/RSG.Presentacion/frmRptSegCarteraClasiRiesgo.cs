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
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmRptSegCarteraClasiRiesgo : frmBase
    {
        #region Variables Globales
            string cNomUser = clsVarGlobal.User.cNomUsu;
            string cTituloMsjes = "Seguimiento de Cartera Clasificacion Riesgo";
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            clsCNCro cnRptRsg = new clsCNCro();
            int cIdUser = clsVarGlobal.User.idUsuario;
      
        #endregion
        #region eventos
                public frmRptSegCarteraClasiRiesgo()
                {
                    InitializeComponent();
                    this.txtBase1.Text = cNomUser;
                    LlenarCombo();
                }
                private void btnImprimir1_Click(object sender, EventArgs e)
                {
                    Reporte();
                }

        #endregion
        #region metodos
        
            private void LlenarCombo()
            {
                cboBase1.Items.Clear();
            
                cboBase1.Items.Add("CPP");
                cboBase1.Items.Add("DEFICIENTE");
                cboBase1.Items.Add("DUDOSO");
                cboBase1.Items.Add("PERDIDA");
            }
            private void Reporte()
            {
                string dFecOpe = Convert.ToString(dFechaSistema);//"2016-08-31"; 
                string cNomAgen = clsVarGlobal.cNomAge.ToString();
                int idUsuario = Convert.ToInt32(cIdUser);//1034;
                int idCalificativo = Convert.ToInt32(this.cboBase1.SelectedIndex)+1;
                DateTime diaPrueba1 = Convert.ToDateTime(dFecOpe);
                string cCalificativo = Convert.ToString(this.cboBase1.SelectedItem);
                DateTime diaPrueba = diaPrueba1.AddDays(-1);

                //if (dFechaConsulta <= dFechaHoy)
                //{
                if (idCalificativo == 0)
                {
                    MessageBox.Show("Seleccion algun tipo de Clasificación", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                  
                    DataTable dtData = cnRptRsg.segCarteraClasiRiesgo(diaPrueba1, idUsuario, idCalificativo);
                    if (dtData.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsSegCarteraRiesgo", dtData));

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Add(new ReportParameter("nCalificativo", idCalificativo.ToString(), false));
                        paramlist.Add(new ReportParameter("nCodeUsuario", cIdUser.ToString(), false));
                        paramlist.Add(new ReportParameter("cAsesor", cNomUser.ToString(), false));
                        paramlist.Add(new ReportParameter("cClasificacion", cCalificativo.ToString(), false));
                        paramlist.Add(new ReportParameter("dFecOpe", dFechaSistema.ToString(), false));
                        paramlist.Add(new ReportParameter("dFechaConsulta", diaPrueba.ToString(), false));
                        paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false)); 

                        string reportPath = "rptSegCarteraClasiRiesgo.rdlc"; 
                        new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos para esta fecha. ", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
 
        #endregion
    }
}
