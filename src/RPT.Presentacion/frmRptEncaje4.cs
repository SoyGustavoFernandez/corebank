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
    public partial class frmRptEncaje4 : frmBase
    {
        public frmRptEncaje4()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void frmRptEncaje1_Load(object sender, EventArgs e)
        {
            rbtPagina1.Checked = true;
            rbtPagina2.Checked = false;
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

            if (rbtPagina1.Checked == true)
            {
                DataTable dtEncaje4 = new clsRPTCNCredito().CNEncaje4(dFecProceso, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, lGrabar);
                if (dtEncaje4.Rows.Count == 0)
                {
                    MessageBox.Show("No Existen Datos para el Reporte Encaje", "Reporte Encaje 4", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();

                    paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsReporte4", dtEncaje4));

                    string reportpath = "RptSBSEncaje4.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
            }
            else
            {
                DataTable dtEncaje4_1 = new clsRPTCNCredito().CNEncaje4(dFecProceso, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, lGrabar);
                if (dtEncaje4_1.Rows.Count == 0)
                {
                    MessageBox.Show("No Existen Datos para el Reporte Encaje", "Reporte Encaje 4", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();

                    paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsReporte4", dtEncaje4_1));

                    string reportpath = "RptSBSEncaje4_1.rdlc";
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
            DataTable dtEncaje4 = new clsRPTCNCredito().CNEncaje4Txt(dFecha, idMoneda);
            if (dtEncaje4.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen Datos para el Reporte de Encaje", "Reporte Encaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cMonedaRpt = "00";
            string cRuta;
            string cNomArc;

            if (idMoneda == 2)
            {
                cMonedaRpt = "03";
            }
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\00350400849" +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            cMonedaRpt + ".txt";

                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena,cCodigoOpe,cProgramaCre;

                pcCadena = "00350400849" +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            cMonedaRpt;
                sr.WriteLine(pcCadena);

                for (int i = 1; i < dtEncaje4.Columns.Count; i++)
                {
                    cProgramaCre = "006";
                    cCodigoOpe = dtEncaje4.Columns[i].ColumnName.ToString();
                    if (cCodigoOpe=="500000")
                    {
                        cProgramaCre = "   ";
                    }
                    
                    for (int f = 0; f < dtEncaje4.Rows.Count; f++)
                    {
                        if (Convert.ToDecimal(dtEncaje4.Rows[f][i]) == 0)
                        {
                            break;
                        }

                        pcCadena = cCodigoOpe +
                                   Convert.ToDateTime(dtEncaje4.Rows[f]["dFecha"]).Year.ToString() +
                                   Convert.ToDateTime(dtEncaje4.Rows[f]["dFecha"]).Month.ToString("00") +
                                   Convert.ToDateTime(dtEncaje4.Rows[f]["dFecha"]).Day.ToString("00") +
                                   cProgramaCre +
                                   cMonedaRpt +
                                   Math.Round(Convert.ToDecimal(dtEncaje4.Rows[f][i]) * 100, 0).ToString().PadLeft(14, '0');

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
