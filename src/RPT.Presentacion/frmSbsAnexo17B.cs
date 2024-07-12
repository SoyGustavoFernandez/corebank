using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using DEP.CapaNegocio;
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace RPT.Presentacion
{
    public partial class frmSbsAnexo17B : frmBase
    {
        string cReporteSBS = "0117", cAnexoSbs = "06";
        DataTable dtLimiteCoberFSD;

        public frmSbsAnexo17B()
        {
            InitializeComponent();
        }

        private void frmSbsAnexo17B_Load(object sender, EventArgs e)
        {
            dtLimiteCoberFSD = new clsCNFsd().ADListarLimiteCoberFSD();
            dtLimiteCoberFSD.DefaultView.Sort = "dFechaInicial DESC";

            cboLimiteCoberFSD.Sorted = false;
            cboLimiteCoberFSD.DataSource = dtLimiteCoberFSD;
            cboLimiteCoberFSD.ValueMember = dtLimiteCoberFSD.Columns["idLimiteFSD"].ToString();
            cboLimiteCoberFSD.DisplayMember = dtLimiteCoberFSD.Columns["cPeriodo"].ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cCodInstFin = clsVarApl.dicVarGen["cCodInstFin"];
            int idLimiteFSD = (int)cboLimiteCoberFSD.SelectedValue;

            DataSet dsSbsAnexo17B = new clsRPTCNDeposito().CNSBSAnexo17B(cCodInstFin, idLimiteFSD, cReporteSBS, cAnexoSbs);
            DataTable dtSbsAnexo17B = dsSbsAnexo17B.Tables[0];

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Clear();

            paramList.Add(new ReportParameter("x_cCodInstFin", cCodInstFin, false));
            paramList.Add(new ReportParameter("x_idLimiteFSD", idLimiteFSD.ToString(), false));

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Clear();

            dtsList.Add(new ReportDataSource("dsSBSAnexo17B", dtSbsAnexo17B));

            string reportPath = "RptSbsAnexo17B.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private void btnExporTxt1_Click(object sender, EventArgs e)
        {
            string cCodInstFin = clsVarApl.dicVarGen["cCodInstFin"];
            int idLimFSD = (int)cboLimiteCoberFSD.SelectedValue;
            DataSet dsAnexos = new clsRPTCNDeposito().CNSBSAnexo17B(cCodInstFin, idLimFSD, cReporteSBS, cAnexoSbs);

            IEnumerable<DateTime> dFechaProceso = from FSD in dtLimiteCoberFSD.AsEnumerable()
                                     where FSD.Field<int>("idLimiteFSD") == idLimFSD
                                     select Convert.ToDateTime(FSD["dFechaFinal"]);

            DateTime dFec = dFechaProceso.FirstOrDefault();

            string cNomArc = "\\" + cAnexoSbs + dFec.ToString("yyMMdd") + "." + cReporteSBS.Substring(1, 3);
            StreamWriter Archivo;
            Archivo = GeneraArchivoSucave(cNomArc);
            if (CargaDatosArchivo(cReporteSBS, cAnexoSbs, Archivo, dsAnexos, true, dFec, 4))
            {
                CierreArchivo(Archivo, cNomArc);
            }
        }
        private StreamWriter GeneraArchivoSucave(string cNomArc)
        {
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            StreamWriter sr;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + cNomArc;
                sr = new StreamWriter(@cNomArc);
            }
            else
            {
                sr = null;
            }
            return sr;
        }
        private Boolean CargaDatosArchivo(string cReporteSBS, string cAnexoSbs, StreamWriter swArchivo, DataSet dsAnexo, Boolean lRegCero, DateTime dFecha, int nRegCodigoFila)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;
            pcCadena = cReporteSBS + cAnexoSbs + clsVarApl.dicVarGen["cCodInst"] + dFecha.ToString("yyyyMMdd") + "012";
            swArchivo.WriteLine(pcCadena);
   
            dtDato = dsAnexo.Tables[1];
            for (int j = 0; j < dtDato.Rows.Count; j++)
            {
                pcCadena = (Convert.ToInt32((Convert.ToDecimal(dtDato.Rows[j]["nOrden"]) * 100)).ToString()).PadLeft(nRegCodigoFila, ' ') + dtDato.Rows[j]["cTexto"].ToString();
                swArchivo.WriteLine(pcCadena);
            }
            return true;
        }
        private void CierreArchivo(StreamWriter Archivo, string cNombreArchivo)
        {
            Archivo.Flush();
            Archivo.Close();
            MessageBox.Show("El archivo " + cNombreArchivo + " se genero correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
