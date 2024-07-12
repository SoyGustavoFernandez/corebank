using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CAJ.CapaNegocio;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GRH.Presentacion
{
    public partial class frmRptArchivosDeposito : frmBase
    {
        int permiso = 0;
        clsCNComprobantes objCpg = new clsCNComprobantes();
        clsCNPlanilla ObjPlanilla = new clsCNPlanilla();
        
        public frmRptArchivosDeposito()
        {
            InitializeComponent();
        }

        private void frmRptArchivosDeposito_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst1.ListarTipoRelacionLaboralPlanillas();
            cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(0);
            cboPeriodoPlanilla1.ListarTodosPeriodoTipoPlanilla(0);
            permiso = 1;
            cboRelacionLabInst1.SelectedIndex = -1;
            cboTipoPlanilla1.SelectedIndex = -1;
            cboPeriodoPlanilla1.SelectedIndex = -1;
            cboModalidadPlanilla1.SelectedIndex = -1;

            cargarCtaCargo();
            chcValDoc.Checked = true;
            grbBase2.Enabled = false;

            //se deja la entidad BANCO DE CREDITO DEL PERÚ para el telecredito pero puede generar para cualquier otro.
            ComboEntidad();
            cboEntidad.SelectedValue = 22;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (cboRelacionLabInst1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Categoría", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboTipoPlanilla1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Planilla", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboPeriodoPlanilla1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboModalidadPlanilla1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Modalidad", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string cCategoria = Convert.ToString(cboRelacionLabInst1.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla1.Text);
            string cPeriodo = Convert.ToString(cboPeriodoPlanilla1.Text);
            string cModalidad = Convert.ToString(cboModalidadPlanilla1.Text);

            DataTable dtRpt = new clsRPTCNRecurHum().CNLisPlanillas(Convert.ToInt16(cboPeriodoPlanilla1.SelectedValue), Convert.ToInt16(cboModalidadPlanilla1.SelectedValue));
            if (dtgPlanillas1.ColumnCount > 0)
                {
                    dtgPlanillas1.Columns.Remove("idPlanilla");
                    dtgPlanillas1.Columns.Remove("dFechaPlanilla");
                    dtgPlanillas1.Columns.Remove("cTipoPlanilla");
                    dtgPlanillas1.Columns.Remove("lVigente");
                }

            dtgPlanillas1.DataSource = dtRpt.DefaultView;
            
                dtgPlanillas1.Columns["idPlanilla"].Width = 10;
                dtgPlanillas1.Columns["idPlanilla"].HeaderText = "Cod.";
                dtgPlanillas1.Columns["idPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas1.Columns["dFechaPlanilla"].Width = 30;
                dtgPlanillas1.Columns["dFechaPlanilla"].HeaderText = "Fecha";
                dtgPlanillas1.Columns["dFechaPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas1.Columns["cTipoPlanilla"].Width = 60;
                dtgPlanillas1.Columns["cTipoPlanilla"].HeaderText = "Tipo de Planilla";
                dtgPlanillas1.Columns["cTipoPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas1.Columns["lVigente"].Visible = false;
            if (dtRpt.Rows.Count > 0)
            { 
                btnImprimir1.Enabled = true;
                grbBase2.Enabled = true; 
            }
            else
            {
                btnImprimir1.Enabled = false;
                grbBase2.Enabled = false; 
                MessageBox.Show("No Existen Planillas halladas con estos filtros", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string cCategoria = Convert.ToString(cboRelacionLabInst1.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla1.Text);
            string cPeriodo = Convert.ToString(cboPeriodoPlanilla1.Text);
            string cModalidad = Convert.ToString(cboModalidadPlanilla1.Text);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            int filaseleccionada = Convert.ToInt32(this.dtgPlanillas1.CurrentRow.Index);
            DataTable dtRpt = new clsRPTCNRecurHum().CNListarPlanillas(Convert.ToInt32(dtgPlanillas1.Rows[filaseleccionada].Cells["idPlanilla"].Value));
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();


                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));

                paramlist.Add(new ReportParameter("x_cCategoria", cCategoria, false));
                paramlist.Add(new ReportParameter("x_cTipoPlanilla", cTipoPlanilla, false));
                paramlist.Add(new ReportParameter("x_cPeriodo", cPeriodo, false));
                paramlist.Add(new ReportParameter("x_cModalidad", cModalidad, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsArchivosDep", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "RptArchivosDep.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void cboRelacionLabInst1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1)
            {
                cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst1.SelectedValue));
                cboTipoPlanilla1.SelectedIndex = -1;
            }
        }

        private void cboTipoPlanilla1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1)
            {
                cboPeriodoPlanilla1.ListarTodosPeriodoTipoPlanilla(Convert.ToInt32(cboTipoPlanilla1.SelectedValue));
                cboPeriodoPlanilla1.SelectedIndex = -1;
            }
        }

        private void btnTeleCredito_Click(object sender, EventArgs e)
        {
            if (!ValidaTelecred())
            {
                return;
            }

            string dfechaPro = clsVarGlobal.dFecSystem.ToString("yyyyMMdd");
            string cTipoCtaCargo = Convert.ToString(Convert.ToInt32(cboCtaCargo.SelectedValue) == 1 ? 'C' : 'M');

            int filaseleccionada = Convert.ToInt32(this.dtgPlanillas1.CurrentRow.Index);
            DataTable dtDatoGralTelecred = ObjPlanilla.CNListaDatoGralTelecred(Convert.ToInt32(dtgPlanillas1.Rows[filaseleccionada].Cells["idPlanilla"].Value));

            if (Convert.ToInt32(cboTipoPlanilla1.SelectedValue) == 4)
            {
                DataTable dtListPlanillaCTSTelecred = ObjPlanilla.CNListaPlanillaCTSTelecredit(Convert.ToInt32(dtgPlanillas1.Rows[filaseleccionada].Cells["idPlanilla"].Value), Convert.ToInt32(cboPeriodoPlanilla1.SelectedValue));
                if (dtListPlanillaCTSTelecred.Rows.Count > 0)
                {
                    DialogResult result;
                    string cRuta;
                    string cNomArc;
                    string cNomArcDes;
                    result = folderBrowserDialog1.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        cRuta = folderBrowserDialog1.SelectedPath;
                        cNomArcDes = cRuta + "\\" + dfechaPro + "TeleCreditoCTS" + ".xls";

                        cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\TeleCreditoCTS.xls";

                        Excel.Application application = new Excel.Application();
                        Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                        Excel.Worksheet worksheet = workbook.Sheets[1];

                        worksheet.Cells[3, 4] = clsVarApl.dicVarGen["cRUC"];
                        worksheet.Cells[7, 2] = dtDatoGralTelecred.Rows[0]["nNroAbonos"].ToString().PadLeft(6, '0');
                        worksheet.Cells[7, 3] = dfechaPro;
                        worksheet.Cells[7, 4] = cTipoCtaCargo;
                        worksheet.Cells[7, 5] = cboCuenta.Text;
                        worksheet.Cells[7, 6] = dtDatoGralTelecred.Rows[0]["nMontoPlanilla"];
                        worksheet.Cells[7, 7] = dtDatoGralTelecred.Rows[0]["cReferenciaPlanilla"];

                        var columns = dtListPlanillaCTSTelecred.Columns.Count;
                        var rows = dtListPlanillaCTSTelecred.Rows.Count;
                        int pnFilaInicio = 11;
                        int pnColInicio = 1;

                        for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                        {
                            for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                            {
                                worksheet.Cells[rowNumber + pnFilaInicio, columnNumber + pnColInicio] = dtListPlanillaCTSTelecred.Rows[rowNumber][columnNumber];
                            }
                        }

                        workbook.SaveAs(cNomArcDes);
                        workbook.Close();
                        Marshal.ReleaseComObject(application);
                        MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para su generación", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                DataTable dtListaPlanillaTelecred = ObjPlanilla.CNListaPlanillaTelecredit(Convert.ToInt32(dtgPlanillas1.Rows[filaseleccionada].Cells["idPlanilla"].Value), chcValDoc.Checked);

                if (dtListaPlanillaTelecred.Rows.Count > 0)
                {
                    DialogResult result;
                    string cRuta;
                    string cNomArc;
                    string cNomArcDes;
                    result = folderBrowserDialog1.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        cRuta = folderBrowserDialog1.SelectedPath;
                        cNomArcDes = cRuta + "\\" + dfechaPro + "TeleCredRem" + ".xls";

                        cNomArc = clsVarGlobal.cRutPathApp + "\\Plantillas\\TeleCreditoRemuneracion.xls";

                        Excel.Application application = new Excel.Application();
                        Excel.Workbook workbook = application.Workbooks.Open(cNomArc);
                        Excel.Worksheet worksheet = workbook.Sheets[1];

                        worksheet.Cells[7, 2] = dtDatoGralTelecred.Rows[0]["nNroAbonos"].ToString().PadLeft(6, '0');
                        worksheet.Cells[7, 3] = dfechaPro;
                        worksheet.Cells[7, 4] = dtDatoGralTelecred.Rows[0]["cSubTipoPlanHaber"];
                        worksheet.Cells[7, 5] = cTipoCtaCargo;
                        worksheet.Cells[7, 6] = cboCuenta.Text;
                        worksheet.Cells[7, 7] = dtDatoGralTelecred.Rows[0]["nMontoPlanilla"];
                        worksheet.Cells[7, 8] = dtDatoGralTelecred.Rows[0]["cReferenciaPlanilla"];

                        var columns = dtListaPlanillaTelecred.Columns.Count;
                        var rows = dtListaPlanillaTelecred.Rows.Count;
                        int pnFilaInicio = 11;
                        int pnColInicio = 1;

                        for (int rowNumber = 0; rowNumber < rows; rowNumber++)
                        {
                            for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                            {
                                worksheet.Cells[rowNumber + pnFilaInicio, columnNumber + pnColInicio] = dtListaPlanillaTelecred.Rows[rowNumber][columnNumber];
                            }
                        }

                        workbook.SaveAs(cNomArcDes);
                        workbook.Close();
                        Marshal.ReleaseComObject(application);
                        MessageBox.Show("El archivo " + cNomArcDes + " se genero Correctamente", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos para su generación", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private bool ValidaTelecred()
        {
            if (Convert.ToInt32(cboEntidad.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Entidad Financiera para generar el Telecredito", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEntidad.Focus();
                return false;
            }
            if (Convert.ToInt32(cboCuenta.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Nro de Cuenta para generar el Telecredito", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCuenta.Focus();
                return false;
            }
            if (Convert.ToInt32(dtgPlanillas1.CurrentRow.Index) < 0)
            {
                MessageBox.Show("Seleccione Planilla para generar el Telecredito", "Datos TeleCreditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgPlanillas1.Focus();
                return false;
            }
            return true;
        }

        private void cargarCtaCargo()
        {
            List<clsTipoEvento> listaCtaCargo = new List<clsTipoEvento>();
            listaCtaCargo.Add(new clsTipoEvento() { idTipoEvento = 1, cEvento = "Cuenta Corriente" });
            listaCtaCargo.Add(new clsTipoEvento() { idTipoEvento = 2, cEvento = "Cuenta Maestra" });

            cboCtaCargo.SelectedIndexChanged -= new EventHandler(cboCtaCargo_SelectedIndexChanged);
            cboCtaCargo.DataSource = listaCtaCargo;
            cboCtaCargo.DisplayMember = "cEvento";
            cboCtaCargo.ValueMember = "idTipoEvento";
            cboCtaCargo.SelectedIndexChanged += new EventHandler(cboCtaCargo_SelectedIndexChanged);
        }

        private void ComboEntidad()
        {
            DataTable dtEntidad;
            dtEntidad = objCpg.ListarEntidadesConCuenta(4);
            cboEntidad.DataSource = dtEntidad;
            cboEntidad.ValueMember = "idEntidad";
            cboEntidad.DisplayMember = "cNombreCorto";
        }

        private void cboCtaCargo_SelectedIndexChanged(object sender, System.EventArgs e)
        { } 

        private void cboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad.SelectedIndex == -1 || cboEntidad.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            dt = objCpg.ListarCuentaXEntidades(Convert.ToInt32(cboEntidad.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }
    }
}
