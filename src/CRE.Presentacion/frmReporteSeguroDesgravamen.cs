using EntityLayer;
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

namespace CRE.Presentacion
{
    public partial class frmReporteSeguroDesgravamen : frmBase
    {
        #region Variables
        private clsRPTCNCredito clsRptCredito = new clsRPTCNCredito();
        #endregion

        #region Metodos
        public frmReporteSeguroDesgravamen()
        {
            InitializeComponent();
        }

        private void exportarExcel()
        {
            bool planesActivos = false;

            if (clsVarApl.dicVarGen.ContainsKey("nPolizaPlanesSeguro"))
                planesActivos = true;

            DataTable dtRptPoliza = clsRptCredito.CNReportePolizaSeguroDesgravamen(
                    Convert.ToInt32(cboZona1.SelectedValue),
                    Convert.ToInt32(cboAgencias1.SelectedValue),
                    cboTipoPoliza.SelectedIndex,
                    1, //.Todo
                    dtpFecha.Value
                );

            if (dtRptPoliza.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Reporte de Poliza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                //exportar cabeceras dgvLog
                int i = 1;
                hoja_trabajo.Cells[1, i] = "NRO CRÉDITO"; i++;
                hoja_trabajo.Cells[1, i] = "MONEDA"; i++;
                hoja_trabajo.Cells[1, i] = "SALDO CAPITAL"; i++;
                hoja_trabajo.Cells[1, i] = "SALDO DEUDOR"; i++;
                hoja_trabajo.Cells[1, i] = "FECHA DE INICIO DE VIGENCIA"; i++;
                hoja_trabajo.Cells[1, i] = "FECHA DE FIN DE VIGENCIA"; i++;
                hoja_trabajo.Cells[1, i] = "TIPO DE DOCUMENTO DE IDENTIDAD"; i++;
                hoja_trabajo.Cells[1, i] = "NRO DE DOCUMENTO DE IDENTIDAD"; i++;
                hoja_trabajo.Cells[1, i] = "APELLIDO PATERNO"; i++;
                hoja_trabajo.Cells[1, i] = "APELLIDO MATERNO"; i++;
                hoja_trabajo.Cells[1, i] = "NOMBRES"; i++;
                hoja_trabajo.Cells[1, i] = "FECHA DE NACIMIENTO"; i++;
                hoja_trabajo.Cells[1, i] = "SEXO"; i++;
                hoja_trabajo.Cells[1, i] = "ESTADO CIVIL"; i++;
                hoja_trabajo.Cells[1, i] = "DIRECCIÓN"; i++;
                hoja_trabajo.Cells[1, i] = "DISTRITO"; i++;
                hoja_trabajo.Cells[1, i] = "PROVINCIA"; i++;
                hoja_trabajo.Cells[1, i] = "DEPARTAMENTO"; i++;
                hoja_trabajo.Cells[1, i] = "TITULAR / CONYUGE"; i++;
                if (planesActivos)
                {
                    hoja_trabajo.Cells[1, i] = "NOMBRE DEL PLAN"; i++;
                    hoja_trabajo.Cells[1, i] = "PRECIO DEL PLAN"; i++;
                }

                //Recorremos el DataGridView rellenando la hoja de trabajo con los 
                for (i = 0; i < dtRptPoliza.Rows.Count; i++)
                {
                    for (int j = 1; j < dtRptPoliza.Columns.Count; j++)
                    {
                        // Verifica si la columna es nPrecioPlan o cPlan y si planesActivos es false
                        if ((dtRptPoliza.Columns[j].ColumnName == "nPrecioPlan" || dtRptPoliza.Columns[j].ColumnName == "cPlan") && !planesActivos)
                        {
                            // Si planesActivos es false y la columna es nPrecioPlan o cPlan, no escribe nada
                            continue;
                        }

                        hoja_trabajo.Cells[i + 2, j] = dtRptPoliza.Rows[i][j].ToString();
                    }
                }
                
                libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                hoja_trabajo.Columns.AutoFit();
                libros_trabajo.Close(true);
                MessageBox.Show("Se ha completado la exportación.");
                aplicacion.Quit();
            }
        }

        private void imprimirReporte()
        {
            DataTable dtRptPoliza = clsRptCredito.CNReportePolizaSeguroDesgravamen(
                    Convert.ToInt32(cboZona1.SelectedValue),
                    Convert.ToInt32(cboAgencias1.SelectedValue),
                    cboTipoPoliza.SelectedIndex,
                    2, //Solo del mes
                    dtpFecha.Value
                );

            if (dtRptPoliza.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Reporte de Poliza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            dtslist.Add(new ReportDataSource("dtRptPoliza", dtRptPoliza));

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            string reportpath = "rptPolizaSeguroDesgravamen.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion

        #region Eventos
        private void frmReporteSeguroDesgravamen_Load(object sender, EventArgs e)
        {
            cboZona1.AgregarTodos();
            cboZona1.SelectedValue = 0;
            cboAgencias1.FiltrarPorZonaTodos(0);
            cboAgencias1.SelectedValue = 0;

            cboTipoPoliza.SelectedIndex = 0;

            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAgencias1.FiltrarPorZonaTodos(Convert.ToInt32(cboZona1.SelectedValue));
            cboAgencias1.SelectedValue = 0;
        }

        private void btnImprimirStock_Click(object sender, EventArgs e)
        {
            btnImprimirStock.Enabled = false;
            exportarExcel();
            btnImprimirStock.Enabled = true;
        }

        private void btnImprimirNueva_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }
        #endregion
    }
}
