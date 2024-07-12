using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReporteMora : frmBase
    {
        clsCNCredito clsCNCredito = new clsCNCredito();

        public frmReporteMora()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            this.GenerarReporteExcel();
            
            /*
            DataTable dtCreditosMora = new DataTable();

            if (chcReporteEnLinea.Checked)
            {
                dtCreditosMora = clsCNCredito.obtenerListaMora();
            }
            else
            {
                DateTime dFechaSeleccionada = Convert.ToDateTime(dtpPeriodo.Value);

                dFechaSeleccionada = new DateTime(dFechaSeleccionada.Year, dFechaSeleccionada.Month, 1).AddMonths(1);
                dFechaSeleccionada = dFechaSeleccionada.AddDays(-1);
                dtCreditosMora = clsCNCredito.obtenerListaMoraHistorico(dFechaSeleccionada);
            }


            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            if (dtCreditosMora.Rows.Count > 0)
            {
                dtslist.Add(new ReportDataSource("dsCreditosCastigados", dtCreditosMora));
                string reportpath = "rptCreditosMora.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }*/
        }

        private void GenerarReporteExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                DataTable dtCreditosMora = new DataTable();

                if (chcReporteEnLinea.Checked)
                {
                    dtCreditosMora = clsCNCredito.obtenerListaMora();
                }
                else
                {
                    DateTime dFechaSeleccionada = Convert.ToDateTime(dtpPeriodo.Value);

                    dFechaSeleccionada = new DateTime(dFechaSeleccionada.Year, dFechaSeleccionada.Month, 1).AddMonths(1);
                    dFechaSeleccionada = dFechaSeleccionada.AddDays(-1);
                    dtCreditosMora = clsCNCredito.obtenerListaMoraHistorico(dFechaSeleccionada);
                }

                try
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);                    

                    hoja_trabajo.Cells[1, 1] = "Zona";
                    hoja_trabajo.Cells[1, 2] ="Oficina";
                    hoja_trabajo.Cells[1, 3] ="Tipo cartera";
                    hoja_trabajo.Cells[1, 4] ="Cod. Cliente";
                    hoja_trabajo.Cells[1, 5] ="Cod. SBS";
                    hoja_trabajo.Cells[1, 6] ="Nombre Cliente";
                    hoja_trabajo.Cells[1, 7] ="Tipo. Doc.";
                    hoja_trabajo.Cells[1, 8] ="Nro. Documento";
                    hoja_trabajo.Cells[1, 9] ="Cod. Crédito";
                    hoja_trabajo.Cells[1, 10] ="Estado Contable";
                    hoja_trabajo.Cells[1, 11] ="Tipo Crédito";
                    hoja_trabajo.Cells[1, 12] ="Producto";
                    hoja_trabajo.Cells[1, 13] ="Fecha Desembolso";
                    hoja_trabajo.Cells[1, 14] ="Mon.";
                    hoja_trabajo.Cells[1, 15] ="Fecha Vencimiento";
                    hoja_trabajo.Cells[1, 16] ="Fecha Vencimiento Cuota";
                    hoja_trabajo.Cells[1, 17] ="Saldo Capital";
                    hoja_trabajo.Cells[1, 18] ="Saldo Capital Venc";
                    hoja_trabajo.Cells[1, 19] ="Saldo Capital Atrasado";
                    hoja_trabajo.Cells[1, 20] ="Saldo Interes";
                    hoja_trabajo.Cells[1, 21] ="Saldo Int. Comp";
                    hoja_trabajo.Cells[1, 22] ="Saldo Mora";
                    hoja_trabajo.Cells[1, 23] ="Saldo Otros";
                    hoja_trabajo.Cells[1, 24] ="Total";
                    hoja_trabajo.Cells[1, 25] ="Atraso";
                    hoja_trabajo.Cells[1, 26] ="Tramo";
                    hoja_trabajo.Cells[1, 27] ="Fecha Ultimo Movimiento";
                    hoja_trabajo.Cells[1, 28] ="Tipo Periodo Couta";
                    hoja_trabajo.Cells[1, 29] ="Días entre cuota";
                    hoja_trabajo.Cells[1, 30] ="Cuotas Pagadas";
                    hoja_trabajo.Cells[1, 31] ="Coutas Faltantes";
                    hoja_trabajo.Cells[1, 32] ="Coutas Atrasadas";
                    hoja_trabajo.Cells[1, 33] ="Fecha Ingreso a Mora Contable";
                    hoja_trabajo.Cells[1, 34] ="Fecha Transferencia a Judicial";
                    hoja_trabajo.Cells[1, 35] ="Nombre Gestor";
                    hoja_trabajo.Cells[1, 36] ="Nombre Asesor";
                    hoja_trabajo.Cells[1, 37] ="Dirección";
                    hoja_trabajo.Cells[1, 38] ="Distrito";
                    hoja_trabajo.Cells[1, 39] ="Provincia";
                    hoja_trabajo.Cells[1, 40] ="Departamento";
                    hoja_trabajo.Cells[1, 41] ="Numero Entidades";
                    hoja_trabajo.Cells[1, 42] ="Saldo SBS";
                    hoja_trabajo.Cells[1, 43] ="Provisión";
                    hoja_trabajo.Cells[1, 44] ="Calificación";
                    hoja_trabajo.Cells[1, 45] ="Teléfono";
                    hoja_trabajo.Cells[1, 46] ="Tipo documento";
                    hoja_trabajo.Cells[1, 47] ="Nro. Documento";
                    hoja_trabajo.Cells[1, 48] ="Nombres";
                    hoja_trabajo.Cells[1, 49] ="Departamento";
                    hoja_trabajo.Cells[1, 50] ="Provincia";
                    hoja_trabajo.Cells[1, 51] ="Distrito";
                    hoja_trabajo.Cells[1, 52] ="Dirección";
                    hoja_trabajo.Cells[1, 53] ="Telefono";
                    hoja_trabajo.Cells[1, 54] ="Nro. Entidades";
                    hoja_trabajo.Cells[1, 55] ="Saldo SBS";
                    hoja_trabajo.Cells[1, 56] ="Calificación";               

                    for (int i = 0; i < dtCreditosMora.Rows.Count; i++)
                    {
                        hoja_trabajo.Cells[i + 2, 1] = dtCreditosMora.Rows[i]["cRegion"].ToString(); 
                        hoja_trabajo.Cells[i + 2, 2] = dtCreditosMora.Rows[i]["cAgencia"].ToString(); 
                        hoja_trabajo.Cells[i + 2, 3] = dtCreditosMora.Rows[i]["cTipoTramo"].ToString(); 
                        hoja_trabajo.Cells[i + 2, 4] = dtCreditosMora.Rows[i]["idCliente"].ToString();  
                        hoja_trabajo.Cells[i + 2, 5] = dtCreditosMora.Rows[i]["cCodSBS"].ToString();
                        hoja_trabajo.Cells[i + 2, 6] = dtCreditosMora.Rows[i]["cNombreCliente"].ToString();
                        hoja_trabajo.Cells[i + 2, 7] = dtCreditosMora.Rows[i]["cTipoDocumento"].ToString();
                        hoja_trabajo.Cells[i + 2, 8] = dtCreditosMora.Rows[i]["cNroDocumento"].ToString();                        
                        hoja_trabajo.Cells[i + 2, 9] = dtCreditosMora.Rows[i]["idCuenta"].ToString();
                        hoja_trabajo.Cells[i + 2, 10] = dtCreditosMora.Rows[i]["cEstadoContable"].ToString();
                        hoja_trabajo.Cells[i + 2, 11] = dtCreditosMora.Rows[i]["cTipoCredito"].ToString();
                        hoja_trabajo.Cells[i + 2, 12] = dtCreditosMora.Rows[i]["cProducto"].ToString();
                        hoja_trabajo.Cells[i + 2, 13] = dtCreditosMora.Rows[i]["dFechaDesembolso"].ToString();
                        hoja_trabajo.Cells[i + 2, 14] = dtCreditosMora.Rows[i]["cMoneda"].ToString();
                        hoja_trabajo.Cells[i + 2, 15] = dtCreditosMora.Rows[i]["dFechaVencimiento"].ToString();
                        hoja_trabajo.Cells[i + 2, 16] = dtCreditosMora.Rows[i]["dFechaVencimientoCuota"].ToString();
                        hoja_trabajo.Cells[i + 2, 17] = dtCreditosMora.Rows[i]["nSaldoCapita"].ToString();
                        hoja_trabajo.Cells[i + 2, 18] = dtCreditosMora.Rows[i]["nSaldoCapitalVenc"].ToString();
                        hoja_trabajo.Cells[i + 2, 19] = dtCreditosMora.Rows[i]["nSaldoCapitalAtrasado"].ToString();
                        hoja_trabajo.Cells[i + 2, 20] = dtCreditosMora.Rows[i]["nSaldoInteres"].ToString();
                        hoja_trabajo.Cells[i + 2, 21] = dtCreditosMora.Rows[i]["nSaldoIntComp"].ToString();
                        hoja_trabajo.Cells[i + 2, 22] = dtCreditosMora.Rows[i]["nSaldoMora"].ToString();
                        hoja_trabajo.Cells[i + 2, 23] = dtCreditosMora.Rows[i]["nSaldoOtros"].ToString();
                        hoja_trabajo.Cells[i + 2, 24] = dtCreditosMora.Rows[i]["nTotal"].ToString();
                        hoja_trabajo.Cells[i + 2, 25] = dtCreditosMora.Rows[i]["nAtraso"].ToString();
                        hoja_trabajo.Cells[i + 2, 26] = dtCreditosMora.Rows[i]["cTramo"].ToString();
                        hoja_trabajo.Cells[i + 2, 27] = dtCreditosMora.Rows[i]["dFechaUltMovimiento"].ToString();
                        hoja_trabajo.Cells[i + 2, 28] = dtCreditosMora.Rows[i]["cTipoCouta"].ToString();
                        hoja_trabajo.Cells[i + 2, 29] = dtCreditosMora.Rows[i]["nNroDias"].ToString();
                        hoja_trabajo.Cells[i + 2, 30] = dtCreditosMora.Rows[i]["nCoutaPagadas"].ToString();
                        hoja_trabajo.Cells[i + 2, 31] = dtCreditosMora.Rows[i]["nCoutaNoPagadas"].ToString();
                        hoja_trabajo.Cells[i + 2, 32] = dtCreditosMora.Rows[i]["nCoutasAtrasadas"].ToString();
                        hoja_trabajo.Cells[i + 2, 33] = dtCreditosMora.Rows[i]["dFechaPaseVencido"].ToString();
                        hoja_trabajo.Cells[i + 2, 34] = dtCreditosMora.Rows[i]["dFechaEstadoJudicial"].ToString();
                        hoja_trabajo.Cells[i + 2, 35] = dtCreditosMora.Rows[i]["cNombreGestor"].ToString();
                        hoja_trabajo.Cells[i + 2, 36] = dtCreditosMora.Rows[i]["cNombreAsesor"].ToString();
                        hoja_trabajo.Cells[i + 2, 37] = dtCreditosMora.Rows[i]["cDireccion"].ToString();
                        hoja_trabajo.Cells[i + 2, 38] = dtCreditosMora.Rows[i]["cDistrito"].ToString();
                        hoja_trabajo.Cells[i + 2, 39] = dtCreditosMora.Rows[i]["cProvincia"].ToString();
                        hoja_trabajo.Cells[i + 2, 40] = dtCreditosMora.Rows[i]["cDepartamento"].ToString();
                        hoja_trabajo.Cells[i + 2, 41] = dtCreditosMora.Rows[i]["nNumeroEntidades"].ToString();
                        hoja_trabajo.Cells[i + 2, 42] = dtCreditosMora.Rows[i]["nSaldoSBS"].ToString();
                        hoja_trabajo.Cells[i + 2, 43] = dtCreditosMora.Rows[i]["nProvision"].ToString();
                        hoja_trabajo.Cells[i + 2, 44] = dtCreditosMora.Rows[i]["idCalificacion"].ToString();
                        hoja_trabajo.Cells[i + 2, 45] = dtCreditosMora.Rows[i]["cTelefono"].ToString();
                        hoja_trabajo.Cells[i + 2, 46] = dtCreditosMora.Rows[i]["cTipoDocumentoIntev"].ToString();
                        hoja_trabajo.Cells[i + 2, 47] = dtCreditosMora.Rows[i]["cNroDocumentoIntev"].ToString();
                        hoja_trabajo.Cells[i + 2, 48] = dtCreditosMora.Rows[i]["cNombreInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 49] = dtCreditosMora.Rows[i]["cDepartamentoInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 50] = dtCreditosMora.Rows[i]["cProvinciaInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 51] = dtCreditosMora.Rows[i]["cDistritoInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 52] = dtCreditosMora.Rows[i]["cDireccionInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 53] = dtCreditosMora.Rows[i]["cTelefonoInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 54] = dtCreditosMora.Rows[i]["cNroEntidadesIntev"].ToString();
                        hoja_trabajo.Cells[i + 2, 55] = dtCreditosMora.Rows[i]["nSaldoSBSInterv"].ToString();
                        hoja_trabajo.Cells[i + 2, 56] = dtCreditosMora.Rows[i]["idCalificacionInterv"].ToString();                        
                    }

                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    MessageBox.Show("Exportado completo", "Reporte de Mora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                    aplicacion.Quit();
                }catch(SystemException ex){
                    MessageBox.Show("Error al guardar el archivo", "Reporte de Mora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmReporteMora_Load(object sender, EventArgs e)
        {
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MMMM yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem;
            dtpPeriodo.Value = clsVarGlobal.dFecSystem;
        }

        private void chcReporteEnLinea_CheckedChanged(object sender, EventArgs e)
        {
            grbDatos.Enabled = !chcReporteEnLinea.Checked;

            if (chcReporteEnLinea.Checked)
            {
                dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem;
                dtpPeriodo.Value = clsVarGlobal.dFecSystem;
            }
            else
            {
                dtpPeriodo.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
                dtpPeriodo.MaxDate = clsVarGlobal.dFecSystem.AddMonths(-1);
            }
        }
    }
}
