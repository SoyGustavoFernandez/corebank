#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
#endregion


namespace RPT.Presentacion
{
    public partial class frmRegOpeUnMul : frmBase
    {
        #region Variagles Globales
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        #endregion

        public frmRegOpeUnMul()
        {
            InitializeComponent();

            dtFechaInicio.Value = dFechaHoy;
            dtFechaFinal.Value = dFechaHoy;
            this.radioButton1.Text = "Actualizado al " + dFechaHoy.Year.ToString();
        }

        #region Eventos
        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            DataTable dtRegOpeUni;

            if (radioButton1.Checked)
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeUnicaN2021(dFechaInicio, dFechaFinal);
                this.generaArchivoRegOpe2021(dtRegOpeUni, ".501", dFechaFinal, "050101", "01");
            }
            else
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeUnicaNueUlt(dFechaInicio, dFechaFinal);
                this.generaArchivo(dtRegOpeUni, ".501", dFechaFinal, "050101", "01");
            }
        }
        private void btnBlanco2_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            DataTable dtRegOpeMul;

            if (this.radioButton1.Checked)
            {
                dtRegOpeMul = new clsRPTCNSplaft().CNRegOpeMulN2021(dFechaInicio, dFechaFinal);
                this.generaArchivoRegOpe2021(dtRegOpeMul, ".501", dFechaFinal, "050103", "03");
            }
            else
            {
                dtRegOpeMul = new clsRPTCNSplaft().CNRegOpeMulNueUlt(dFechaInicio, dFechaFinal);
                this.generaArchivo(dtRegOpeMul, ".501", dFechaFinal, "050103", "03");
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            if (!validarFechas(dFechaInicio, dFechaFinal))
            {
                MessageBox.Show("La fecha no es valida");
                return;
            }
            mostrarPreImpresionROU();

        }
        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            if (!validarFechas(dFechaInicio, dFechaFinal))
            {
                MessageBox.Show("La fecha no es valida");
                return;
            }
            mostrarPreImpresionROM();
        }
        #endregion

        #region Metodos
        private Boolean validarFechas(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            if (dFechaFinal <= dFechaHoy && dFechaInicio <= dFechaHoy)
            {
                if (dFechaInicio <= dFechaFinal)
                {
                    return true;
                }
                else
                {
                    //MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("Las fechas no puede ser mayor a la de hoy", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void mostrarPreImpresionROU(){
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            DataTable dtRegOpeUni;
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportPath = "rptRegOpeMulti.rdlc";

            if (radioButton1.Checked)
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeUnicaN2021(dFechaInicio, dFechaFinal);
                reportPath = "rptRegOpeUniMulti.rdlc";
            }
            else
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeUnicaNueUlt(dFechaInicio, dFechaFinal);
                reportPath = "rptRegOpeMulti.rdlc";
            }

            dtsList.Add(new ReportDataSource("dsRegOpe", dtRegOpeUni));
            paramlist.Add(new ReportParameter("dFechaOpe", dFechaInicio.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToString(), false));
            new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
        }

        private void mostrarPreImpresionROM() {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            DataTable dtRegOpeUni;
            string reportPath = "rptRegOpeMulti.rdlc";

            if (radioButton1.Checked)
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeMulN2021(dFechaInicio, dFechaFinal);
                reportPath = "rptRegOpeUniMulti.rdlc";
            }
            else
            {
                dtRegOpeUni = new clsRPTCNSplaft().CNRegOpeMulNueUlt(dFechaInicio, dFechaFinal);
                reportPath = "rptRegOpeMulti.rdlc";
            }

            dtsList.Add(new ReportDataSource("dsRegOpe", dtRegOpeUni));
            paramlist.Add(new ReportParameter("dFechaOpe", dFechaInicio.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToString(), false));
            new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
        }
        private void generaArchivo(DataTable dt, string cExtencion, DateTime dFechaFinal, string cPrefijo, string cPrefijoRuta)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos en Registro de operaciones", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog.SelectedPath;
                    cNomArc = cRuta + "\\" + cPrefijoRuta + dFechaFinal.Year.ToString().Substring(2, 2) +
                                               dFechaFinal.Month.ToString("00") +
                                               dFechaFinal.Day.ToString("00") + cExtencion;

                    StreamWriter sr = new StreamWriter(@cNomArc, false, Encoding.ASCII);
                    string pcCadena;

                    pcCadena = cPrefijo + clsVarApl.dicVarGen["cCodInst"] +
                                          dFechaFinal.Year.ToString() +
                                          dFechaFinal.Month.ToString("00") +
                                          dFechaFinal.Day.ToString("00") + "012";

                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        pcCadena = Convert.ToInt32(dt.Rows[i]["nCodRegistro_010"]).ToString().PadLeft(8, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodSBS_020"]).PadLeft(4, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idCodOperacion_030"]).ToString().PadLeft(8, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idKardex_040"]).ToString().PadLeft(20, '0') +
                                    Convert.ToString(dt.Rows[i]["cModalidadOpe_050"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodUbiOfiOpe_060"]).PadLeft(6, '0') +
                                    Convert.ToString(dt.Rows[i]["cFechaOperac_070"]).PadLeft(8, '0') +
                                    Convert.ToString(dt.Rows[i]["cHoraOperac_080"]).PadLeft(6, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idTipRelPerFis_090"]).ToString().PadLeft(1, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idConResPerFis_100"]).ToString().PadLeft(1, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idTipPerFis_110"]).ToString().PadLeft(1, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idTipDocPerFis_120"]).ToString().PadRight(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerFis_130"]).ToString().PadLeft(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerFis_140"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerFis_150"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerFis_160"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerFis_170"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerFis_180"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodCIIUPerFis_190"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDesOcuPerFis_200"]).PadRight(104, ' ') +
                                    Convert.ToInt32(dt.Rows[i]["idCargoPerFis_210"]).ToString().PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerFis_220"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerFis_230"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerFis_240"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerFis_250"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerFis_260"]).PadLeft(40, ' ') +
                                    Convert.ToInt32(dt.Rows[i]["idTipRelPerOrd_270"]).ToString().PadLeft(1, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idConResPerOrd_280"]).ToString().PadLeft(1, '0') +
                                    Convert.ToInt32(dt.Rows[i]["idTipPerOrd_290"]).ToString().PadLeft(1, '0') +
                                    dt.Rows[i]["idTipDocPerOrd_300"].ToString().Trim().PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerOrd_310"]).ToString().PadRight(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerOrd_320"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerOrd_330"]).PadRight(120, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerOrd_340"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerOrd_350"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerOrd_360"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodCIIUPerOrd_370"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDesOcuPerOrd_380"]).PadRight(104, ' ') +
                                    dt.Rows[i]["idCargoPerOrd_390"].ToString().Trim().PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerOrd_400"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerOrd_410"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerOrd_420"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerOrd_430"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerOrd_440"]).PadLeft(40, ' ') +
                                    Convert.ToInt32(dt.Rows[i]["idTipRelPerBen_450"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dt.Rows[i]["idConResPerBen_460"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dt.Rows[i]["idTipPerBen_470"]).ToString().PadLeft(1, ' ') +
                                    dt.Rows[i]["idTipDocPerBen_480"].ToString().Trim().PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerBen_490"]).ToString().PadRight(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerBen_500"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerBen_510"]).PadRight(120, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerBen_520"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerBen_530"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerBen_540"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodCIIUPerBen_550"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDesOcuPerBen_560"]).PadRight(104, ' ') +
                                    dt.Rows[i]["idCargoPerBen_570"].ToString().Trim().PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerBen_580"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerBen_590"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerBen_600"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerBen_610"]).PadLeft(2, '0') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerBen_620"]).PadLeft(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipPago_630"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodTipOpe_640"]).PadLeft(2, '0') +
                                    //Convert.ToString(dt.Rows[i]["cDesTipOpe_650"]).PadRight(40, ' ') +
                                    Convert.ToString("").PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOriFondos_660"]).PadRight(80, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipMon_670"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cDesTipMon_680"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["nMontoOperacion_690"]).PadLeft(18, ' ') +
                                    Convert.ToString(dt.Rows[i]["cTipoCambio_700"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodEntInvOrd_711"]).PadLeft(5, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodTipCtaOrd_712"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodCtaIntOrd_713"]).PadRight(20, ' ') +
                                    Convert.ToString(dt.Rows[i]["c_714"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodEntInvBen_721"]).PadLeft(5, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodTipCtaBen_722"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodCtaIntBen_723"]).PadRight(20, ' ') +
                                    Convert.ToString(dt.Rows[i]["c_724"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cAlcanceOpe_730"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodPaiOri_740"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodPaiDes_750"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodIntOpe_760"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodForOpe_770"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cDesForOpe_780"]).PadRight(40, ' ');


                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se generó correctamente", "Registro de operaciones ùnicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void generaArchivoRegOpe2021(DataTable dt, string cExtencion, DateTime dFechaFinal, string cPrefijo, string cPrefijoRuta)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos en Registro de operaciones", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result;
                result = folderBrowserDialog.ShowDialog();
                string cRuta;
                string cNomArc;

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog.SelectedPath;
                    cNomArc = cRuta + "\\" + cPrefijoRuta + dFechaFinal.Year.ToString().Substring(2, 2) +
                                               dFechaFinal.Month.ToString("00") +
                                               dFechaFinal.Day.ToString("00") + cExtencion;

                    StreamWriter sr = new StreamWriter(@cNomArc, false, Encoding.ASCII);
                    string pcCadena;

                    pcCadena = cPrefijo + clsVarApl.dicVarGen["cCodInst"] +
                                          dFechaFinal.Year.ToString() +
                                          dFechaFinal.Month.ToString("00") +
                                          dFechaFinal.Day.ToString("00") + "012";

                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        pcCadena = Convert.ToString(dt.Rows[i]["nCodRegistro_010"]).PadLeft(8, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodSBS_020"]).PadLeft(4, '0') +
                                    Convert.ToString(dt.Rows[i]["idCodOperacion_030"]).PadLeft(8, '0') +
                                    Convert.ToString(dt.Rows[i]["idKardex_040"]).PadLeft(20, '0') +
                                    Convert.ToString(dt.Rows[i]["cModalidadOpe_050"]).PadLeft(1, '0') +
                                    Convert.ToString(dt.Rows[i]["cCodUbiOfiOpe_060"]).PadLeft(6, '0') +
                                    Convert.ToString(dt.Rows[i]["cFechaOperac_070"]).PadLeft(8, '0') +
                                    Convert.ToString(dt.Rows[i]["cHoraOperac_080"]).PadLeft(6, '0') +
                                    // Persona ejecutante
                                    Convert.ToString(dt.Rows[i]["idTipRelPerFis_090"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idConResPerFis_100"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipPerFis_110"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipDocPerFis_120"]).PadRight(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerFis_130"]).PadRight(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerFis_140"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerFis_150"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerFis_160"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerFis_170"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerFis_180"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodNacPerFis_190"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCargoPepPerFis_200"]).PadRight(104, ' ') +
                                    Convert.ToString(dt.Rows[i]["idCargoPerFis_210"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerFis_220"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerFis_230"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerFis_240"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerFis_250"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerFis_260"]).PadLeft(40, ' ') +
                                    // Ordenante
                                    Convert.ToString(dt.Rows[i]["idTipRelPerOrd_270"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idConResPerOrd_280"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipPerOrd_290"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipDocPerOrd_300"]).PadRight(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerOrd_310"]).PadRight(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerOrd_320"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerOrd_330"]).PadRight(120, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerOrd_340"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerOrd_350"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerOrd_360"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodNacPerOrd_370"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCargoPepPerOrd_380"]).PadRight(104, ' ') +
                                    Convert.ToString(dt.Rows[i]["idCargoPerOrd_390"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerOrd_400"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerOrd_410"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerOrd_420"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerOrd_430"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerOrd_440"]).PadLeft(40, ' ') +
                                    // Beneficiario
                                    Convert.ToString(dt.Rows[i]["idTipRelPerBen_450"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idConResPerBen_460"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipPerBen_470"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["idTipDocPerBen_480"]).PadRight(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["nDocIdePerBen_490"]).PadRight(12, ' ') +
                                    Convert.ToString(dt.Rows[i]["cRucPerBen_500"]).PadLeft(11, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApePatPerBen_510"]).PadRight(120, ' ') +
                                    Convert.ToString(dt.Rows[i]["cApeMatPerBen_520"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNombrePerBen_530"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOcupacPerBen_540"]).PadLeft(4, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodNacPerBen_550"]).PadLeft(6, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCargoPepPerBen_560"]).PadRight(104, ' ') +
                                    Convert.ToString(dt.Rows[i]["idCargoPerBen_570"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDirecPerBen_580"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDepPerBen_590"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiProPerBen_600"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cUbiDisPerBen_610"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cNumTelPerBen_620"]).PadLeft(40, ' ') +
                                    // Informacion de la operacion
                                    Convert.ToString(dt.Rows[i]["cCodTipPago_630"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipOpe_640"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cDesTipOpe_650"]).PadRight(40, ' ') +
                                    Convert.ToString(dt.Rows[i]["cOriFondos_660"]).PadRight(80, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipMonA_670"]).PadLeft(3, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipMonB_680"]).PadLeft(3, ' ') +
                                    Convert.ToString(dt.Rows[i]["cMontoOpeA_690"]).PadLeft(29, ' ') +
                                    Convert.ToString(dt.Rows[i]["cMontoOpeB_700"]).PadLeft(30, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodEntInvOrd_711"]).PadLeft(5, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipCtaOrd_712"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodCtaIntOrd_713"]).PadRight(20, ' ') +
                                    Convert.ToString(dt.Rows[i]["c_714"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodEntInvBen_721"]).PadLeft(5, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodTipCtaBen_722"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodCtaIntBen_723"]).PadRight(20, ' ') +
                                    Convert.ToString(dt.Rows[i]["c_724"]).PadRight(150, ' ') +
                                    Convert.ToString(dt.Rows[i]["cAlcanceOpe_730"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodPaiOri_740"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodPaiDes_750"]).PadLeft(2, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodIntOpe_760"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cCodForOpe_770"]).PadLeft(1, ' ') +
                                    Convert.ToString(dt.Rows[i]["cInfAdiOpe_780"]).PadRight(40, ' ');

                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se generó correctamente", "Registro de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

    }
}
