using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmRptEncaje : frmBase
    {
        public frmRptEncaje()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void frmRptEncaje1_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFecha.Value.Date;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue.ToString());
            bool lGrabar = false;

            if (chcGrabar.Checked)
            {
                var Msg = MessageBox.Show("Esta seguro de guardar los datos del reporte?...", "Guardar datos del reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg == DialogResult.Yes)
                {
                    lGrabar = true;
                }                
            }
            if (idMoneda==1)  //--Soles
            {
                DataTable dtEncaje1 = new clsRPTCNCredito().CNEncaje1(dFecProceso, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, lGrabar);
                if (dtEncaje1.Rows.Count == 0)
                {
                    MessageBox.Show("No Existen Datos para el Reporte Encaje", "Reporte Encaje 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();

                    paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                    paramlist.Add(new ReportParameter("x_dFechaReg", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("x_idUsuReg", clsVarGlobal.User.idUsuario.ToString(), false));
                    paramlist.Add(new ReportParameter("x_lGrabar", lGrabar.ToString(), false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsReporte1", dtEncaje1));
                    string reportpath = "RptSBSEncaje1.rdlc";

                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
            }
            else
            {
                DataTable dtEncaje1 = new clsRPTCNCredito().CNEncaje1_1(dFecProceso, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, lGrabar);
                if (dtEncaje1.Rows.Count == 0)
                {
                    MessageBox.Show("No Existen Datos para el Reporte Encaje", "Reporte Encaje 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();

                    paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                    paramlist.Add(new ReportParameter("x_dFechaReg", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("x_idUsuReg", clsVarGlobal.User.idUsuario.ToString(), false));
                    paramlist.Add(new ReportParameter("x_lGrabar", lGrabar.ToString(), false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsReporte1", dtEncaje1));
                    string reportpath = "RptSBSEncaje1_2.rdlc";

                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
            }

            if (chcGrabar.Checked)
            {
                btnExportar.Enabled = true;
            }
           
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue.ToString());
            DataTable dtEncaje1 = new clsRPTCNCredito().CNEncaje1Txt(dFecha, idMoneda);
            if (dtEncaje1.Rows.Count<=0)
            {
                MessageBox.Show("No Existen Datos para el Reporte de Encaje", "Reporte Encaje 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cMonedaRpt = "00";
            string cRuta;
            string cNomArc;

            if (idMoneda==2)
            {
                cMonedaRpt = "03";
            }

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\00350100849" +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            cMonedaRpt + ".txt";

                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena;

                pcCadena = "00350100849" + 
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            cMonedaRpt;
                sr.WriteLine(pcCadena);

                for (int i = 1; i < dtEncaje1.Columns.Count; i++)
			    {
			        for (int f = 0; f < dtEncaje1.Rows.Count; f++)
                    {

                         pcCadena = dtEncaje1.Columns[i].ColumnName.ToString()+  
                                    Convert.ToDateTime(dtEncaje1.Rows[f]["dFecha"]).Year.ToString()+
                                    Convert.ToDateTime(dtEncaje1.Rows[f]["dFecha"]).Month.ToString("00")+
                                    Convert.ToDateTime(dtEncaje1.Rows[f]["dFecha"]).Day.ToString("00") +
                                    cMonedaRpt+
                                    Math.Round(Convert.ToDecimal((dtEncaje1.Rows[f][i] == DBNull.Value)? 0: dtEncaje1.Rows[f][i])*100, 0).ToString().PadLeft(14, '0');
                                    
                        sr.WriteLine(pcCadena);
                    }
			    }
                               
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " se genero correctamente", "Valida Encaje 1", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnExportar.Enabled = false;
        }
    }
}
