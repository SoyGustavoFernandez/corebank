using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CNT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Dts.Runtime;

namespace CNT.Presentacion
{
    public partial class frmLibroDia : frmBase
    {
        public frmLibroDia()
        {
            InitializeComponent();
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
            this.cboTipoAsiento.DataSource = dt;
            this.cboTipoAsiento.ValueMember = dt.Columns[0].ToString();
            this.cboTipoAsiento.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoAsiento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        class MyEventListener : DefaultEvents
        {
            public override bool OnError(DtsObject source, int errorCode, string subComponent,
              string description, string helpFile, int helpContext, string idofInterfaceWithError)
            {
                MessageBox.Show(description, "Error Transferencia de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dInicio = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idAgencia = (int)cboAgencia1.SelectedValue;
            int idTipAsi = (int)cboTipoAsiento.SelectedValue;
            int idMoneda = (int)cboMoneda.SelectedValue;

            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                cRuta = "";
            }

            if (string.IsNullOrEmpty(cRuta))
            {
                return;
            }
            string cNomArc = "";
            Cursor.Current=Cursors.WaitCursor;

            while (dFecFin >= dFecIni)
            {
                string pkgLocation;
                Package pkg;
                Variables vars;
                DTSExecResult pkgResults;

                cNomArc = "PLEDiario" + dFecIni.ToString("ddMMyyyy");

                if (result == DialogResult.OK)
                {
                    cRuta = folderBrowserDialog1.SelectedPath;

                    string cArchivo = "C:\\tmp\\LibroDiarioTMP.xlsx";
                    string cPathOrigen = clsVarGlobal.cRutPathApp + "\\Plantillas\\PLEPlantillaLibroDiario.xlsx";

                    Microsoft.SqlServer.Dts.Runtime.Application app;
                    app = new Microsoft.SqlServer.Dts.Runtime.Application();
                    MyEventListener eventListener = new MyEventListener();

                    pkgLocation = clsVarGlobal.cRutPathApp + "\\PqtLibroDiario.dtsx";
                    pkg = app.LoadPackage(@pkgLocation, eventListener);


                    vars = pkg.Variables;
                    vars["cPathDestino"].Value = cArchivo;
                    vars["cPathOrigen"].Value = cPathOrigen;
                    vars["dFecha"].Value = dFecIni;
                    vars["idAgencia"].Value = idAgencia;
                    vars["idMoneda"].Value = idMoneda;
                    vars["nAsiento"].Value = idTipAsi;

                    Cursor.Current = Cursors.WaitCursor;
                    pkgResults = pkg.Execute(null, vars, eventListener, null, null);

                    Cursor.Current = Cursors.Default;

                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(cArchivo);

                    string pcCodRUC = clsVarApl.dicVarGen["cRUC"];
                    string pcNomIns = clsVarApl.dicVarGen["cNomEmpresa"];
                    string pcPeriodo = dFecIni.Year.ToString() + "/" + dFecIni.Month.ToString("00");
                    Excel.Worksheet worksheetDG = workbook.Sheets["Hoja1"];

                    DataSet dsTotalLibDia = new clsCNAsiento().CNTotalLibroDia(dFecIni,idTipAsi, idMoneda, idAgencia);
                    DataTable dtViene = dsTotalLibDia.Tables[0];
                    DataTable dtVan = dsTotalLibDia.Tables[1];
                    DataTable dtRegistros = dsTotalLibDia.Tables[2];

                    worksheetDG.Cells[3, 2] = pcPeriodo;
                    worksheetDG.Cells[4, 2] = pcCodRUC;
                    worksheetDG.Cells[5, 2] = pcNomIns;

                    worksheetDG.Cells[6, 8] = "Viene: ";
                    worksheetDG.Cells[6, 9] = dtViene.Rows[0][0];
                    worksheetDG.Cells[6, 10] = dtViene.Rows[0][1];

                    int nReg = Convert.ToInt32(dtRegistros.Rows[0][0]) + 10;
                    worksheetDG.Cells[nReg, 8] = "Van: ";
                    worksheetDG.Cells[nReg, 9] = dtVan.Rows[0][0];
                    worksheetDG.Cells[nReg, 10] = dtVan.Rows[0][1];

                    worksheetDG.Cells.Font.Name = "Arial Narrow";
                    worksheetDG.Cells.Font.Size = 8;
                    worksheetDG.Range["9:9"].Delete();

                    string cNomArcDes = cRuta + "\\" + cNomArc;

                    workbook.SaveAs(cNomArcDes);
                    workbook.Close();
                    Marshal.ReleaseComObject(application);

                    dFecIni = dFecIni.AddDays(1);
                }
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Proceso concluido revisar los archivos generados en la ruta indicada", "Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        Boolean Validar()
        {
            if (this.dtpFecIni.Value.Date>this.dtpFecFin.Value.Date)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial");
                return false;
            }
            else
	        {
            return true;
	        }
        }

        private void frmLibroDia_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.cboMoneda.CargaDatosContaIntegrado();
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);

            DataTable dtLibroDia = new clsCNAsiento().CNPLELibroDiario(dFecIni, dFecFin, idMoneda);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\" + new clsCNAsiento().cNomArcPLELibroDiario(cboMoneda.SelectedValue.ToString(), dtLibroDia.Rows.Count, dFecFin);
                StreamWriter sr = new StreamWriter(@cNomArc);
                string pcCadena;

                for (int i = 0; i < dtLibroDia.Rows.Count; i++)
                {
                    pcCadena = dtLibroDia.Rows[i]["cCadena"].ToString();
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " se generó correctamente", "PLE - Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
