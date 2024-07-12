using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using RPT.CapaNegocio;

namespace RPT.Presentacion
{
    public partial class frmRegistroOperacionesEfectivo : frmBase
    {
        public frmRegistroOperacionesEfectivo()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;

            DataTable dtRegOpeEfe = new clsRPTCNSplaft().CNRegistroOperacionesEfectivo(dFechaInicio, dFechaFinal);

            if (dtRegOpeEfe.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos en Registro de Operaciones en Efectivo", "Registro de Operaciones en Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cNomArc = cRuta + "\\02" + clsVarGlobal.dFecSystem.Year.ToString().Substring(2, 2) +
                                               clsVarGlobal.dFecSystem.Month.ToString("00") +
                                               clsVarGlobal.dFecSystem.Day.ToString("00") + ".501";

                    StreamWriter sr = new StreamWriter(@cNomArc);
                    string pcCadena;

                    pcCadena = "050102" + clsVarApl.dicVarGen["cCodInst"] +
                                          clsVarGlobal.dFecSystem.Year.ToString() +
                                          clsVarGlobal.dFecSystem.Month.ToString("00") +
                                          clsVarGlobal.dFecSystem.Day.ToString("00") + "012";

                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtRegOpeEfe.Rows.Count; i++)
                    {
                        pcCadena = Convert.ToInt32(dtRegOpeEfe.Rows[i]["nCodRegistro_010"]).ToString().PadLeft(8, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodSBS_020"]).PadLeft(4, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idCodOperacion_030"]).ToString().PadLeft(8, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idKardex_040"]).ToString().PadLeft(20, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cModalidadOpe_050"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodUbiOfiOpe_060"]).PadLeft(6, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cFechaOperac_070"]).PadLeft(8, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cHoraOperac_080"]).PadLeft(6, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipRelPerFis_090"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idConResPerFis_100"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipPerFis_110"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipDocPerFis_120"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["nDocIdePerFis_130"]).ToString().PadLeft(12, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cRucPerFis_140"]).PadLeft(11, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApePatPerFis_150"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApeMatPerFis_160"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNombrePerFis_170"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cOcupacPerFis_180"]).PadLeft(4, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodCIIUPerFis_190"]).PadLeft(6, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesOcuPerFis_200"]).PadLeft(104, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idCargoPerFis_210"]).ToString().PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDirecPerFis_220"]).PadLeft(150, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDepPerFis_230"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiProPerFis_240"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDisPerFis_250"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNumTelPerFis_260"]).PadLeft(40, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipRelPerOrd_270"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idConResPerOrd_280"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipPerOrd_290"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipDocPerOrd_300"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["nDocIdePerOrd_310"]).ToString().PadLeft(12, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cRucPerOrd_320"]).PadLeft(11, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApePatPerOrd_330"]).PadLeft(120, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApeMatPerOrd_340"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNombrePerOrd_350"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cOcupacPerOrd_360"]).PadLeft(4, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodCIIUPerOrd_370"]).PadLeft(6, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesOcuPerOrd_380"]).PadLeft(104, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idCargoPerOrd_390"]).ToString().PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDirecPerOrd_400"]).PadLeft(150, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDepPerOrd_410"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiProPerOrd_420"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDisPerOrd_430"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNumTelPerOrd_440"]).PadLeft(40, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipRelPerBen_450"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idConResPerBen_460"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipPerBen_470"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idTipDocPerBen_480"]).ToString().PadLeft(1, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["nDocIdePerBen_490"]).ToString().PadLeft(12, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cRucPerBen_500"]).PadLeft(11, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApePatPerBen_510"]).PadLeft(120, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cApeMatPerBen_520"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNombrePerBen_530"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cOcupacPerBen_540"]).PadLeft(4, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodCIIUPerBen_550"]).PadLeft(6, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesOcuPerBen_560"]).PadLeft(104, ' ') +
                                    Convert.ToInt32(dtRegOpeEfe.Rows[i]["idCargoPerBen_570"]).ToString().PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDirecPerBen_580"]).PadLeft(150, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDepPerBen_590"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiProPerBen_600"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cUbiDisPerBen_610"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cNumTelPerBen_620"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodTipPago_630"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodTipOpe_640"]).PadLeft(2, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesTipOpe_650"]).PadLeft(40, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cOriFondos_660"]).PadLeft(80, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodTipMon_670"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesTipMon_680"]).PadLeft(40, ' ') +
                                    Math.Round(Convert.ToDecimal(dtRegOpeEfe.Rows[i]["nMontoOperacion_690"]) * 100, 0).ToString().PadLeft(18, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cTipoCambio_700"]).PadLeft(6, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodEntInvOrd_711"]).PadLeft(5, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodTipCtaOrd_712"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodCtaIntOrd_713"]).PadLeft(34, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodEntInvBen_721"]).PadLeft(5, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodTipCtaBen_722"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodCtaIntBen_723"]).PadLeft(34, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cAlcanceOpe_730"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodPaiOri_740"]).PadLeft(4, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodPaiDes_750"]).PadLeft(4, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodIntOpe_760"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cCodForOpe_770"]).PadLeft(1, ' ') +
                                    Convert.ToString(dtRegOpeEfe.Rows[i]["cDesForOpe_780"]).PadLeft(40, ' ');

                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se generó correctamente", "Registro de Operaciones en Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
