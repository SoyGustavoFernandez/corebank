using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace CNT.Presentacion
{
    public partial class frmRptEstFinanSMV : frmBase
    {
        public frmRptEstFinanSMV()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dfechaPro = dtpFechaSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dfechaPro)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida estado financiero SMV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cRuta;
            string cNomArc;
            string cNomArcDes = null;
            string pcNombMes = dfechaPro.ToString("yyyyMMdd");
            cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\";
            DataSet dsDatos;

            if (rbtAnual.Checked)
            {

                dsDatos = new clsRPTCNContabilidad().CNRptFormatoEEFF_MSV_Anual(dfechaPro);
            }
            else
            {

                dsDatos = new clsRPTCNContabilidad().CNRptFormatoEEFF_MSV_Trim(dfechaPro);
            }


            DataTable dtDatosSF = dsDatos.Tables[0];

            if (dtDatosSF.Rows.Count > 0)
            {
                DialogResult result;
                result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;

                    if (rbtAnual.Checked)
                    {
                        cNomArc = cNomArc + "SMV_Anual.xls";
                        cNomArcDes = cRuta + "\\" + pcNombMes + "_BANCOS_AI" + ".xls";
                    }
                    int trimestre = 0;
                    if (rbtTrimestral.Checked)
                    {
                        trimestre = (dfechaPro.Month - 1) / 3 + 1;

                        cNomArc = cNomArc + "SMV_Trimestre.xls";
                        cNomArcDes = cRuta + "\\" + pcNombMes + "_BANCOS_TRIM_IND_" + trimestre.ToString() + ".xls";
                    }

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                    Excel.Worksheet worksheetDG = workbook.Sheets["DG"];

                    string pcCodIns = clsVarApl.dicVarGen["cCodInst"];
                    string pcNomIns = clsVarApl.dicVarGen["cNomEmpresa"];
                    string pcAnio = dfechaPro.Year.ToString();
                    worksheetDG.Cells[4, 2] = clsVarApl.dicVarGen["RPJ_EEFF"]; //debe enviar contabilidad.
                    worksheetDG.Cells[5, 2] = pcAnio;

                    if (rbtAnual.Checked)
                    {
                        worksheetDG.Cells[7, 2] = pcNomIns;
                    }
                    if (rbtTrimestral.Checked)
                    {
                        worksheetDG.Cells[7, 2] = trimestre.ToString();
                        worksheetDG.Cells[8, 2] = pcNomIns;
                    }

                    Excel.Worksheet worksheetSF = workbook.Sheets["SF"];
                    var rows = dtDatosSF.Rows.Count;
                    int fila = 0;
                    int filaDt = 2;

                    #region SITUACION FINANCIERA
                    #region cargar activo
                    for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                    {
                        fila = rowNumber + 9;
                        worksheetSF.Cells[fila, 4] = dtDatosSF.Rows[filaDt]["nValor"];
                        worksheetSF.Cells[fila, 5] = dtDatosSF.Rows[filaDt]["nValorAnt"];
                        if (fila == 15 || fila == 19 || fila == 33 || fila == 36 || fila == 39)
                        {
                            rowNumber++;
                            filaDt++;
                        }
                        if (fila == 23)
                        {
                            rowNumber = rowNumber + 2;
                            filaDt++;
                        }
                        if (fila == 50)
                        {
                            worksheetSF.Cells[fila, 4] = dtDatosSF.Rows[filaDt + 1]["nValor"];
                            worksheetSF.Cells[fila, 5] = dtDatosSF.Rows[filaDt + 1]["nValorAnt"];
                            break;
                        }
                        if (fila == 44)
                        {
                            filaDt++;
                        }
                        if (fila == 49)
                        {
                            filaDt--;
                        }
                        filaDt++;
                    }
                    #endregion
                    filaDt = filaDt + 2;
                    #region cargar pasivo
                    for (int rowNumber = 0; rowNumber < rows - filaDt + 12; rowNumber++)
                    {
                        fila = rowNumber + 9;
                        worksheetSF.Cells[fila, 9] = dtDatosSF.Rows[filaDt + 3]["nValor"];
                        worksheetSF.Cells[fila, 10] = dtDatosSF.Rows[filaDt + 3]["nValorAnt"];
                        if (fila == 13 || fila == 17 || fila == 26)
                        {
                            rowNumber++;
                            filaDt++;
                        }
                        if (fila == 33)
                        {
                            worksheetSF.Cells[fila, 9] = dtDatosSF.Rows[filaDt + 3]["nValor"];
                            worksheetSF.Cells[fila, 10] = dtDatosSF.Rows[filaDt + 3]["nValorAnt"];
                            filaDt = filaDt + 3;
                            break;
                        }
                        filaDt++;
                    }
                    #endregion
                    #region patrimonio
                    filaDt = filaDt + 5;
                    worksheetSF.Cells[37, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[37, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    filaDt++;
                    worksheetSF.Cells[38, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[38, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    filaDt++;
                    worksheetSF.Cells[40, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[40, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    filaDt++;
                    worksheetSF.Cells[43, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[43, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    filaDt++;
                    worksheetSF.Cells[41, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[41, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    filaDt++;
                    worksheetSF.Cells[42, 9] = dtDatosSF.Rows[filaDt - 1]["nValor"];
                    worksheetSF.Cells[42, 10] = dtDatosSF.Rows[filaDt - 1]["nValorAnt"];
                    #endregion
                    #endregion

                    Excel.Worksheet worksheetER = workbook.Sheets["ER"];
                    Excel.Worksheet worksheetRI = workbook.Sheets["RI"];
                    if (rbtAnual.Checked)
                    {
                        #region ESTADO DE RESULTADO
                        DataTable dtDatosER = dsDatos.Tables[1];
                        if (dtDatosER.Rows.Count > 0)
                        {
                            rows = dtDatosER.Rows.Count;

                            filaDt = 1;

                            for (int rowNumber = 8; rowNumber < rows + 6; rowNumber++)
                            {
                                worksheetER.Cells[rowNumber, 4] = dtDatosER.Rows[filaDt]["nValor"];
                                worksheetER.Cells[rowNumber, 5] = dtDatosER.Rows[filaDt]["nValorAnt"];
                                if (rowNumber.In(21,39,72,74,76))
                                {
                                    if (rowNumber.In(74, 76))
                                    {
                                        filaDt++;
                                    }
                                    filaDt++;
                                    rowNumber++;
                                }
                                else if (rowNumber.In(16,31,34,55,61))
                                {
                                    if (rowNumber.In(31,34,55, 61))
                                    {
                                        filaDt++;
                                    }
                                    filaDt++;
                                    rowNumber = rowNumber + 2;
                                }
                                else if (rowNumber == 44)
                                {
                                    rowNumber = rowNumber + 3;
                                    filaDt = filaDt + 3;
                                }
                                else if (rowNumber == 38)
                                {
                                    filaDt++;
                                }

                                filaDt++;
                            }
                        }
                        #endregion
                        #region RESULTADO INTEGRALES
                        worksheetRI.Cells[7, 4] = worksheetER.Cells[77, 4];
                        worksheetRI.Cells[7, 5] = worksheetER.Cells[77, 5];
                        #endregion
                    }
                    if (rbtTrimestral.Checked)
                    {
                        #region ESTADO DE RESULTADO
                        DataTable dtDatosER = dsDatos.Tables[1];
                        if (dtDatosER.Rows.Count > 0)
                        {
                            rows = dtDatosER.Rows.Count;

                            filaDt = 1;

                            for (int rowNumber = 8; rowNumber < rows + 6; rowNumber++)
                            {
                                worksheetER.Cells[rowNumber, 4] = dtDatosER.Rows[filaDt]["nValTrimActAcum"];
                                worksheetER.Cells[rowNumber, 5] = dtDatosER.Rows[filaDt]["nValTrimAntAcum"];
                                worksheetER.Cells[rowNumber, 6] = dtDatosER.Rows[filaDt]["nValorActAcu"];
                                worksheetER.Cells[rowNumber, 7] = dtDatosER.Rows[filaDt]["nValorAntAcu"];
                                if (rowNumber.In(21, 39, 72, 74, 76))
                                {
                                    if (rowNumber.In(74, 76))
                                    {
                                        filaDt++;
                                    }
                                    filaDt++;
                                    rowNumber++;
                                }
                                else if (rowNumber.In(16, 31, 34, 55, 61))
                                {
                                    if (rowNumber.In(31, 34, 55, 61))
                                    {
                                        filaDt++;
                                    }
                                    filaDt++;
                                    rowNumber = rowNumber + 2;
                                }
                                else if (rowNumber == 44)
                                {
                                    rowNumber = rowNumber + 3;
                                    filaDt = filaDt + 3;
                                }
                                else if (rowNumber == 38)
                                {
                                    filaDt++;
                                }
                                filaDt++;
                            }
                        }
                        #endregion
                        #region RESULTADO INTEGRALES
                        worksheetRI.Cells[7, 4] = worksheetER.Cells[77, 4];
                        worksheetRI.Cells[7, 5] = worksheetER.Cells[77, 5];
                        worksheetRI.Cells[7, 6] = worksheetER.Cells[77, 6];
                        worksheetRI.Cells[7, 7] = worksheetER.Cells[77, 7];
                        #endregion
                    }

                    Excel.Worksheet worksheetFE = workbook.Sheets["FE"];
                    #region FLUJO DE EFECTIVO
                    DataTable dtDatosFE = dsDatos.Tables[2];
                    foreach (DataRow dtRow in dtDatosFE.Rows)
                    {
                        if ((int)dtRow["nPosExpotrSMV"]>0)
                        {
                            worksheetFE.Cells[dtRow["nPosExpotrSMV"], 4] = dtRow["nValor"];
                            worksheetFE.Cells[dtRow["nPosExpotrSMV"], 5] = dtRow["nValorAnt"];
                        }
                    }
                    #endregion 

                    Excel.Worksheet worksheetCP = workbook.Sheets["CP"];
                    #region CAMBIO PATRIMONIO
                    DataTable dtDatosCP = dsDatos.Tables[3];
                    if (dtDatosCP.Rows.Count > 0)
                    {
                        rows = dtDatosCP.Rows.Count;

                        filaDt = 0;
                        foreach (DataRow dtRow in dtDatosCP.Rows)
                        {
                            if ((int)dtRow["nOrderFil"] > 0 && (int)dtRow["nOrderCol"] > 0)
                            {
                                try
                                {
                                    worksheetCP.Cells[dtRow["nOrderFil"], dtRow["nOrderCol"]] = dtRow["nValor"];
                                }
                                catch (Exception)
                                {
                                    
                                    throw;
                                }
                               
                            }
                        }
                        
                    }
                    #endregion

                    workbook.CheckCompatibility = false;
                    workbook.SaveAs(cNomArcDes);
                    workbook.Close();
                    Marshal.ReleaseComObject(application);
                    MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "Datos EEFF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        private void FormatoAnula()
        {

        }

        private void formatoTrimestral()
        {

        }
    }
}
