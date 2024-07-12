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
using System.Reflection;

namespace RPT.Presentacion
{
    public partial class frmRegistroOperacionesMultiples : frmBase
    {
        public frmRegistroOperacionesMultiples()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = dtFechaInicio.Value.Date;
            DateTime dFechaFinal = dtFechaFinal.Value.Date;

            DataTable dtRegOpeUni = new clsRPTCNSplaft().CNRegistroOperacionesMultiples(dFechaInicio, dFechaFinal);

            if (dtRegOpeUni.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos en Registro de operaciones múltiples", "Registro de operaciones múltiples", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cNomArc = cRuta + "\\03" + dFechaFinal.Year.ToString().Substring(2, 2) +
                                               dFechaFinal.Month.ToString("00") +
                                               dFechaFinal.Day.ToString("00") + ".501";

                    StreamWriter sr = new StreamWriter(@cNomArc,true,Encoding.ASCII);
                    string pcCadena;

                    pcCadena = "050103" + clsVarApl.dicVarGen["cCodInst"] +
                                          dFechaFinal.Year.ToString() +
                                          dFechaFinal.Month.ToString("00") +
                                          dFechaFinal.Day.ToString("00") + "012";

                    sr.WriteLine(pcCadena);

                    for (int i = 0; i < dtRegOpeUni.Rows.Count; i++)
                    {
                        pcCadena = dtRegOpeUni.Rows[i]["nCodRegistro_010"].ToString().PadLeft(8, '0')
                            + dtRegOpeUni.Rows[i]["cCodSBS_020"].ToString().PadLeft(4, '0')
                            + dtRegOpeUni.Rows[i]["idCodOperacion_030"].ToString().PadLeft(8, '0')
                            + dtRegOpeUni.Rows[i]["idKardex_040"].ToString().PadLeft(20, '0')
                            + Convert.ToString("M").PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodUbiOfiOpe_060"]).PadLeft(6, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cFechaOperac_070"]).PadLeft(8, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cHoraOperac_080"]).PadLeft(6, '0')
                            + dtRegOpeUni.Rows[i]["idTipRelPerFis_090"].ToString().PadLeft(1, ' ')
                            + ((dtRegOpeUni.Rows[i]["idConResPerFis_100"] == DBNull.Value) ? "1".PadLeft(1, ' ') : dtRegOpeUni.Rows[i]["idConResPerFis_100"].ToString().PadLeft(1, ' '))
                            + dtRegOpeUni.Rows[i]["idTipPerFis_110"].ToString().PadLeft(1, ' ')
                            + dtRegOpeUni.Rows[i]["idTipDocPerFis_120"].ToString().PadLeft(1, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["nDocIdePerFis_130"]).ToString().PadRight(12, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cRucPerFis_140"]).PadLeft(11, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cApePatPerFis_150"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cApeMatPerFis_160"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNombrePerFis_170"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cOcupacPerFis_180"]).PadLeft(4, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodCIIUPerFis_190"]).PadLeft(6, ' ')
                            + ((dtRegOpeUni.Rows[i]["cDesOcuPerFis_200"] == DBNull.Value) ? "".PadRight(104, ' ') : dtRegOpeUni.Rows[i]["cDesOcuPerFis_200"].ToString().PadRight(104, ' '))
                            + ((dtRegOpeUni.Rows[i]["idCargoPerFis_210"] == DBNull.Value) ? "99".PadLeft(2, ' ') : dtRegOpeUni.Rows[i]["idCargoPerFis_210"].ToString().PadLeft(2, ' '))
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDirecPerFis_220"]).PadRight(150, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDepPerFis_230"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiProPerFis_240"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDisPerFis_250"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNumTelPerFis_260"]).PadLeft(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["idTipRelPerOrd_270"]).ToString().PadLeft(1, ' ')
                            + ((dtRegOpeUni.Rows[i]["idConResPerOrd_280"] == DBNull.Value) ? "1".PadLeft(1, ' ') : dtRegOpeUni.Rows[i]["idConResPerOrd_280"].ToString().PadLeft(1, ' '))
                            + ((dtRegOpeUni.Rows[i]["idTipPerOrd_290"] == DBNull.Value) ? "2".PadLeft(1, ' ') : dtRegOpeUni.Rows[i]["idTipPerOrd_290"].ToString().PadLeft(1, '0'))
                            + dtRegOpeUni.Rows[i]["idTipDocPerOrd_300"].ToString().Trim().PadLeft(1, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["nDocIdePerOrd_310"]).ToString().PadRight(12, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cRucPerOrd_320"]).PadLeft(11, ' ')
                            + ((dtRegOpeUni.Rows[i]["cApePatPerOrd_330"] == DBNull.Value) ? "".PadRight(120, ' ') : dtRegOpeUni.Rows[i]["cApePatPerOrd_330"].ToString().PadRight(120, ' '))
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cApeMatPerOrd_340"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNombrePerOrd_350"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cOcupacPerOrd_360"]).PadLeft(4, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodCIIUPerOrd_370"]).PadLeft(6, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDesOcuPerOrd_380"]).PadRight(104, ' ')
                            + ((dtRegOpeUni.Rows[i]["idCargoPerOrd_390"] == DBNull.Value) ? "99".PadLeft(2, ' ') : dtRegOpeUni.Rows[i]["idCargoPerOrd_390"].ToString().PadLeft(2, ' '))
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDirecPerOrd_400"]).PadRight(150, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDepPerOrd_410"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiProPerOrd_420"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDisPerOrd_430"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNumTelPerOrd_440"]).PadLeft(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["idTipRelPerBen_450"]).ToString().PadLeft(1, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["idConResPerBen_460"]).ToString().PadLeft(1, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["idTipPerBen_470"]).ToString().PadLeft(1, ' ')
                            + dtRegOpeUni.Rows[i]["idTipDocPerBen_480"].ToString().Trim().PadLeft(1, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["nDocIdePerBen_490"]).ToString().PadRight(12, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cRucPerBen_500"]).PadLeft(11, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cApePatPerBen_510"]).PadRight(120, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cApeMatPerBen_520"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNombrePerBen_530"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cOcupacPerBen_540"]).PadLeft(4, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodCIIUPerBen_550"]).PadLeft(6, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDesOcuPerBen_560"]).PadRight(104, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["idCargoPerBen_570"]).ToString().PadLeft(2, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDirecPerBen_580"]).PadRight(150, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDepPerBen_590"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiProPerBen_600"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cUbiDisPerBen_610"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cNumTelPerBen_620"]).PadLeft(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodTipPago_630"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodTipOpe_640"]).PadLeft(2, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDesTipOpe_650"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cOriFondos_660"]).PadRight(80, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodTipMon_670"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDesTipMon_680"]).PadRight(40, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["nMontoOperacion_690"]).ToString().PadLeft(18, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cTipoCambio_700"]).PadLeft(6, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodEntInvOrd_711"]).PadLeft(5, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodTipCtaOrd_712"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodCtaIntOrd_713"]).PadRight(20, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["c_714"]).PadRight(150, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodEntInvBen_721"]).PadLeft(5, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodTipCtaBen_722"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodCtaIntBen_723"]).PadRight(20, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["c_724"]).PadRight(150, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cAlcanceOpe_730"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodPaiOri_740"]).PadLeft(2, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodPaiDes_750"]).PadLeft(2, ' ')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodIntOpe_760"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cCodForOpe_770"]).PadLeft(1, '0')
                            + Convert.ToString(dtRegOpeUni.Rows[i]["cDesForOpe_780"]).PadRight(40, ' ');

                        sr.WriteLine(pcCadena);
                    }
                    sr.Close();
                    MessageBox.Show("El archivo se generó correctamente", "Registro de operaciones múltiples", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmRegistroOperacionesMultiples_Load(object sender, EventArgs e)
        {
            dtFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtFechaFinal.Value = clsVarGlobal.dFecSystem;
        }
    }
}
