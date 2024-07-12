using CNT.CapaNegocio;
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
using Microsoft.SqlServer.Dts.Runtime;
using EntityLayer;
using System.IO;

namespace CNT.Presentacion
{
    public partial class frmDeclaracionITF : frmBase
    {
        enum Meses {Enero = 1, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Setiembre, Octubre, Noviembre, Diciembre};
        DateTime dFecIni;
        DateTime dFecFin;
        int nAnio;
        int nmes;
        Boolean lReporte;

        public frmDeclaracionITF()
        {
            InitializeComponent();
            this.cboMeses.DataSource = Enum.GetValues(typeof(Meses));
            this.cboMeses.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnValidar1_Click(object sender, EventArgs e)
        {
            dFecIni = dtpFechaInicial.Value.Date;
            dFecFin = dtpFechaFinal.Value.Date;
            nAnio = (int)nudAnio.Value;
            nmes = cboMeses.SelectedIndex + 1;
            lReporte = chcBase1.Checked;

            DataTable dtCalculoErrado = new clsCNITF().CNValidaCalculoITF(dFecIni, dFecFin, nmes, nAnio, lReporte);
            if (dtCalculoErrado.Rows.Count > 0)
            {
                dFecIni = Convert.ToDateTime(dtCalculoErrado.Rows[0]["dFecIni"]);
                dFecFin = Convert.ToDateTime(dtCalculoErrado.Rows[0]["dFecFin"]);

                MessageBox.Show("Existen registros mal calculados", "Valida ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsRegistroErrados", dtCalculoErrado));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptErrorITF.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }

            dtCalculoErrado = new clsCNITF().CNValidaAsientoTrx(dFecIni, dFecFin, nmes, nAnio, lReporte);
            if (dtCalculoErrado.Rows.Count > 0)
            {
                dFecIni = Convert.ToDateTime(dtCalculoErrado.Rows[0]["dFecIni"]);
                dFecFin = Convert.ToDateTime(dtCalculoErrado.Rows[0]["dFecFin"]);

                MessageBox.Show("Existen registros errados", "Valida ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsRegistroErrados", dtCalculoErrado));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptErrorITFAsientoTRX.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                this.btnTransferir1.Enabled = true;
            }
        }

        private void btnTransferir1_Click(object sender, EventArgs e)
        {
            string cNomArc;
            Cursor.Current = Cursors.WaitCursor;

            //Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
            cNomArc = "\\0695" + Convert.ToString(nudAnio.Value) + (cboMeses.SelectedIndex + 1).ToString("00") + clsVarApl.dicVarGen["cRUC"] + ".mov";

            dFecIni = dtpFechaInicial.Value.Date;
            dFecFin = dtpFechaFinal.Value.Date;
            nAnio = (int)nudAnio.Value;
            nmes = cboMeses.SelectedIndex + 1;
            lReporte = chcBase1.Checked;

            DataSet dsITF = new clsCNITF().CNTransTXT(dFecIni, dFecFin, nmes, nAnio, lReporte);
            Cursor.Current = Cursors.Default;

            if (dsITF.Tables.Count > 0)
            {
                StreamWriter Archivo;
                Archivo = GeneraArchivo(cNomArc);
                if (CargaDatosArchivo(Archivo, dsITF))
                {
                    CierreArchivo(Archivo, cNomArc);
                }
            }
            else
            {
                MessageBox.Show("No existen datos de ITF", "Genera ITF PDT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void CierreArchivo(StreamWriter Archivo, string cNombreArchivo)
        {
            Archivo.Flush();
            Archivo.Close();
            MessageBox.Show("El archivo " + cNombreArchivo + " se genero correctamente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private StreamWriter GeneraArchivo(string cNomArc)
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
        private Boolean CargaDatosArchivo(StreamWriter swArchivo, DataSet dsAnexo)
        {
            if (swArchivo == null)
            {
                return false;
            }
            string pcCadena;
            DataTable dtDato;

            for (int i = 0; i < dsAnexo.Tables.Count; i++)
            {
                dtDato = dsAnexo.Tables[i];
                for (int j = 0; j < dtDato.Rows.Count; j++)
                {
                    pcCadena = dtDato.Rows[j]["cStrITFPDT"].ToString();
                    swArchivo.WriteLine(pcCadena);
                }
            }
            return true;
        }
        private void frmDeclaracionITF_Load(object sender, EventArgs e)
        {
            this.txtRUC.Text = clsVarApl.dicVarGen["cRUC"];
            this.nudAnio.Value = clsVarGlobal.dFecSystem.Year;
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcBase1.Checked)
            {
                cboMeses.Enabled = true;
                nudAnio.Enabled = true;
                dtpFechaInicial.Enabled = false;
                dtpFechaFinal.Enabled = false;
            }
            else
            {
                cboMeses.Enabled = false;
                nudAnio.Enabled = false;
                dtpFechaInicial.Enabled = true;
                dtpFechaFinal.Enabled = true;
            }
        }
    }
}
