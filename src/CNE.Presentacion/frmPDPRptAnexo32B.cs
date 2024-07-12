using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using CNE.CapaNegocio;
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

namespace CNE.Presentacion
{
    public partial class frmPDPRptAnexo32B : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();
        DateTime dFecSystem = clsVarGlobal.dFecSystem;

        public frmPDPRptAnexo32B()
        {
            InitializeComponent();
        }

        private void frmPDPRptAnexo32B_Load(object sender, EventArgs e)
        {
            CargarComboTipoReporte();
        }

        public void CargarComboTipoReporte()
        { 
            Dictionary<string, string> itemsTipoReporte = new Dictionary<string, string>();
            itemsTipoReporte.Add("1", "Anexo 32B-I");
            itemsTipoReporte.Add("2", "Anexo 32B-II");
            itemsTipoReporte.Add("3", "Anexo 32B-III");
            itemsTipoReporte.Add("4", "Anexo 32B-IV");            

            this.cboTipoReporte.DataSource = new BindingSource(itemsTipoReporte, null);
            this.cboTipoReporte.DisplayMember = "Value";
            this.cboTipoReporte.ValueMember = "Key";           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicial.Value.Date > this.dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nTipoReporte = Convert.ToInt32(this.cboTipoReporte.SelectedValue);
            DateTime dFechaInicial = this.dtpFechaInicial.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFinal.Value.Date;
            string cDsDatosAnexo = string.Empty;
            string cNomAnexo = string.Empty;

            DataTable dtAnexo32B = cnRptPdp.ObtenerReporte32B(nTipoReporte, dFechaInicial, dFechaFinal);
            if (dtAnexo32B.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramlist.Add(new ReportParameter("dFechaInicial", dFechaInicial.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFinal", dFechaFinal.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"].ToString(), false));
                
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                switch(nTipoReporte)
                {
                    case 1:
                        cDsDatosAnexo = "dsDatosAnexo32B_I";
                        cNomAnexo = "RptReporte32B_I.rdlc";
                        break;
                    case 2:
                        cDsDatosAnexo = "dsDatosAnexo32B_II";
                        cNomAnexo = "RptReporte32B_II.rdlc";
                        break;
                    case 3:
                        cDsDatosAnexo = "dsDatosAnexo32B_III";
                        cNomAnexo = "RptReporte32B_III.rdlc";
                        break;
                    case 4:
                        cDsDatosAnexo = "dsDatosAnexo32B_IV";
                        cNomAnexo = "RptReporte32B_IV.rdlc";
                        break;
                }

                dtslist.Add(new ReportDataSource(cDsDatosAnexo, dtAnexo32B));

                string reportpath = cNomAnexo;
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicial.Value.Date > this.dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Se exportara la información con la Fecha Final: " + this.dtpFechaFinal.Value.Date.ToString("MM/yyyy"), "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int nTipoReporte = Convert.ToInt32(this.cboTipoReporte.SelectedValue);
            //DateTime dFechaInicial = this.dtpFechaInicial.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFinal.Value.Date;

            DataTable dtAnexo32B = cnRptPdp.ObtenerReporte32B(nTipoReporte, dFechaFinal, dFechaFinal);
            if (dtAnexo32B.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                string cRuta, cNomArc, cAnexo;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;
                    cAnexo = string.Empty;

                    switch (nTipoReporte)
                    {
                        case 1:
                            cAnexo = "I";
                            break;
                        case 2:
                            cAnexo = "II";
                            break;
                        case 3:
                            cAnexo = "III";
                            break;
                        case 4:
                            cAnexo = "IV";
                            break;
                    }

                    cNomArc = "\\REPORTE32B-"+cAnexo+"-CRANDES-" +
                                Convert.ToDateTime(dtAnexo32B.Rows[0]["dFecha"].ToString()).Year.ToString() +
                                Convert.ToDateTime(dtAnexo32B.Rows[0]["dFecha"].ToString()).Month.ToString("00") + ".txt";

                    StreamWriter sr = new StreamWriter(cRuta + @cNomArc, false, Encoding.ASCII);
                    string pcCadena = String.Empty;

                    pcCadena += dtAnexo32B.Rows[0]["cCodFormato"].ToString().Trim().PadLeft(4, '0'); //Codigo Formato "0232"
                    pcCadena += dtAnexo32B.Rows[0]["cAnexo"].ToString().Trim().PadLeft(2, '0');   //Anexo "02"
                    pcCadena += dtAnexo32B.Rows[0]["cEntidad"].ToString().Trim().PadLeft(5, '0'); //Entidad "00169"
                    pcCadena += Convert.ToDateTime(dtAnexo32B.Rows[0]["dFecha"].ToString()).Year.ToString("0000") +
                                Convert.ToDateTime(dtAnexo32B.Rows[0]["dFecha"].ToString()).Month.ToString("00") +
                                Convert.ToDateTime(dtAnexo32B.Rows[0]["dFecha"].ToString()).Day.ToString("00"); //Fecha
                    pcCadena += dtAnexo32B.Rows[0]["cCodigoExpMonto"].ToString().Trim().PadLeft(3, '0'); //Codigo Expresion "012"
                    pcCadena += dtAnexo32B.Rows[0]["nDatosControl"].ToString().Trim().PadLeft(15, '0'); //Datos Control "000000000000000"
                    sr.WriteLine(pcCadena);                    

                    switch (nTipoReporte)
                    {
                        case 1:
                            for (int i = 0; i < dtAnexo32B.Rows.Count; i++)
                            {
                                pcCadena = dtAnexo32B.Rows[i]["nCodigoFila"].ToString().Trim().PadLeft(6, '0') +
                                            //dtAnexo32B.Rows[i]["cConversiones"].ToString().Trim().PadLeft(0, '0') +   
                                            Convert.ToInt32(Convert.ToDecimal(dtAnexo32B.Rows[i]["nMontoA"]) * 100).ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroOpeA"].ToString().Trim().PadLeft(18, '0') +
                                            //dtAnexo32B.Rows[i]["cTransPagos"].ToString().Trim().PadLeft(0, '0') +     
                                            Convert.ToInt32(Convert.ToDecimal(dtAnexo32B.Rows[i]["nMontoB"]) * 100).ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroOpeB"].ToString().Trim().PadLeft(18, '0') +
                                            //dtAnexo32B.Rows[i]["cReconversiones"].ToString().Trim().PadLeft(0, '0') +
                                            Convert.ToInt32(Convert.ToDecimal(dtAnexo32B.Rows[i]["nMontoC"]) * 100).ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroOpeC"].ToString().Trim().PadLeft(18, '0') +
                                            //dtAnexo32B.Rows[i]["cOtras"].ToString().Trim().PadLeft(0, ' ') +           
                                            Convert.ToInt32(Convert.ToDecimal(dtAnexo32B.Rows[i]["nMontoD"]) * 100).ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroOpeD"].ToString().Trim().PadLeft(18, '0') +
                                            Convert.ToInt32(Convert.ToDecimal(dtAnexo32B.Rows[i]["nTipoCambioCont"]) * 1000).ToString().Trim().PadLeft(6, '0');                                            
                                sr.WriteLine(pcCadena);
                            }
                            break;
                        case 2:
                            for (int i = 0; i < dtAnexo32B.Rows.Count; i++)
                            {
                                pcCadena = dtAnexo32B.Rows[i]["nCodigoFila"].ToString().Trim().PadLeft(6, '0') +
                                            dtAnexo32B.Rows[i]["nMonedaNacional"].ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nMonedaExtranjera"].ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nTotal"].ToString().Trim().PadLeft(18, '0');

                                sr.WriteLine(pcCadena);
                            }
                            break;
                        case 3:
                            for (int i = 0; i < dtAnexo32B.Rows.Count; i++)
                            {
                                pcCadena = dtAnexo32B.Rows[i]["nCodigoFila"].ToString().Trim().PadLeft(6, '0') +
                                            //dtAnexo32B.Rows[i]["cCuentasSimplif"].ToString().Trim().PadLeft(0, '0') +   
                                            dtAnexo32B.Rows[i]["nNroCuentas"].ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroTitulares"].ToString().Trim().PadLeft(18, '0') +
                                            //dtAnexo32B.Rows[i]["cCtasGenerales"].ToString().Trim().PadLeft(0, '0') +     
                                            dtAnexo32B.Rows[i]["nNroCuentasNV"].ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nNroTitularesNV"].ToString().Trim().PadLeft(18, '0');

                                sr.WriteLine(pcCadena);
                            }
                            break;
                        case 4:
                            for (int i = 0; i < dtAnexo32B.Rows.Count; i++)
                            {
                                pcCadena = dtAnexo32B.Rows[i]["nCodigoFila"].ToString().Trim().PadLeft(6, '0') +
                                            dtAnexo32B.Rows[i]["nTotalDECirculacion"].ToString().Trim().PadLeft(18, '0') +
                                            dtAnexo32B.Rows[i]["nValorPatriFide"].ToString().Trim().PadLeft(18, '0');

                                sr.WriteLine(pcCadena);
                            }
                            break;                        
                    }
                    
                    sr.Flush();
                    sr.Close();

                    MessageBox.Show("El Archivo " + cNomArc + " se generó correctamente", "Anexo 32B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
