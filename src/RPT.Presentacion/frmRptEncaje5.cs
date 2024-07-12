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
    public partial class frmRptEncaje5 : frmBase
    {
        public frmRptEncaje5()
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

            DataTable dtEncaje1 = new clsRPTCNCredito().CNEncaje5(dFecProceso, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, lGrabar);
            if (dtEncaje1.Rows.Count == 0)
            {
                MessageBox.Show("No Existen Datos para el Reporte 5 del Encaje", "Reporte Encaje 5", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dtslist.Add(new ReportDataSource("dsEncaje", dtEncaje1));

                string reportpath = "RptEncaje5.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
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
            DataTable dtEncaje5 = new clsRPTCNCredito().CNEncaje5(dFecha, idMoneda, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, false);
            if (dtEncaje5.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen Datos para el Reporte de Encaje", "Reporte Encaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cMonedaRpt="00";
            string cRuta;
            string cNomArc;

            if (idMoneda==2)
            {
                cMonedaRpt = "03";
            }


            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\0115" +"06" +"00849"+
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            dFecha.Day.ToString("00") +
                            cMonedaRpt + ".txt";

                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena;

                pcCadena = "0115" + "06" + "00849" +
                            dFecha.Year.ToString() +
                            dFecha.Month.ToString("00") +
                            dFecha.Day.ToString("00") +
                            cMonedaRpt;
                sr.WriteLine(pcCadena);

                for (int i = 0; i < dtEncaje5.Rows.Count; i++)
                {
                    pcCadena =  dtEncaje5.Rows[i]["cCodigoOpe"].ToString().PadLeft(6, ' ') +
                                dFecha.Year.ToString() +
                                dFecha.Month.ToString("00") +
                                dFecha.Day.ToString("00") +
                                cMonedaRpt +
                                Math.Round(Convert.ToDecimal(dtEncaje5.Rows[i]["nMonto"])*100,0).ToString().PadLeft(14, '0');
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " se genero correctamente", "Valida Encaje 5", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnExportar.Enabled = false;            
        }
    }
}
