using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmReporteSUNAT : frmBase
    {
        private clsRPTCNDeposito clsRPTCNDeposito;
        private DateTime dFechaSistema;

        public DateTime dPeriodo
        {
            get
            {
                int anio = Int16.Parse(this.cboAnio.Text);
                int mes = Int16.Parse(this.cboMeses1.SelectedValue.ToString());
                return new DateTime(anio, mes, 01);
            }
        }

        public frmReporteSUNAT()
        {
            InitializeComponent();
            this.clsRPTCNDeposito = new clsRPTCNDeposito();
            this.dFechaSistema = clsVarGlobal.dFecSystem;
            this.iniciarParametros();
            this.iniciarFormCabecera();            
        }

        private void iniciarParametros() {
            this.cboMeses1.SelectedValue = 1;
            for (int i = 2021; i <= this.dFechaSistema.Year; i++)
            {
                this.cboAnio.Items.Add(i);
            }
            this.cboAnio.Text = clsVarGlobal.dFecSystem.Year.ToString();
        }

        private void iniciarFormCabecera()
        {
            this.txtNumeroPeriodos.Text = "6";
            this.txtNumeroPeriodos.cPatron = "^[0-6]{0,1}$";
            this.txtNumeroPeriodos.cPatronValidacion = "^[0-6]{1}$";
            this.cboTipoDeclaracion.SelectedIndex = 0;
            this.cboCaracteristicaDeclaracion.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> lstParamentros = new List<ReportParameter>();
            lstParamentros.Clear();
            lstParamentros.Add(new ReportParameter("dPeriodo", this.dPeriodo.ToShortDateString(), false));            
            string cRptPath = "rptSUNATDatosTitular.rdlc";

            DataTable dtDatosTitular = this.clsRPTCNDeposito.CNObtenerDatosTitular(this.dPeriodo);
            if (dtDatosTitular.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte - Archivo 002: Datos del Titular", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
            lstDataSource.Clear();
            lstDataSource.Add(new ReportDataSource("dtsDatosTitular", dtDatosTitular));
            new frmReporteLocal(lstDataSource, cRptPath, lstParamentros).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<ReportParameter> lstParamentros = new List<ReportParameter>();
            lstParamentros.Clear();
            lstParamentros.Add(new ReportParameter("dPeriodo", this.dPeriodo.ToShortDateString(), false));
            string cRptPath = "rptSUNATDatosCuenta.rdlc";

            DataTable dtDatosCuenta = this.clsRPTCNDeposito.CNObtenerDatosCuenta(this.dPeriodo);
            if (dtDatosCuenta.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte - Archivo 003: Datos de la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
            lstDataSource.Clear();
            lstDataSource.Add(new ReportDataSource("dtsDatosCuenta", dtDatosCuenta));
            new frmReporteLocal(lstDataSource, cRptPath, lstParamentros).ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<ReportParameter> lstParamentros = new List<ReportParameter>();
            lstParamentros.Clear();
            lstParamentros.Add(new ReportParameter("dPeriodo", this.dPeriodo.ToShortDateString(), false));
            string cRptPath = "rptSUNATCuentasPorTitular.rdlc";

            DataTable dtDatosCuentasPorTitular = this.clsRPTCNDeposito.CNObtenerCuentasPorTitular(this.dPeriodo);
            if (dtDatosCuentasPorTitular.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte - Archivo 004: Cuentas por Titular", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
            lstDataSource.Clear();
            lstDataSource.Add(new ReportDataSource("dtsCuentasPorTitular", dtDatosCuentasPorTitular));
            new frmReporteLocal(lstDataSource, cRptPath, lstParamentros).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DataTable dtDatosTitular = this.clsRPTCNDeposito.CNObtenerDatosTitular(this.dPeriodo);
                    if (dtDatosTitular.Rows.Count == 0)
                    {
                        MessageBox.Show("No existen datos para el reporte", "Archivo 002: Datos del Titular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string cRuta = folderBrowserDialog1.SelectedPath;
                    string cNombreArchivo = "20322445564-" + this.dPeriodo.ToString("yyyyMM") + "-DT.txt";
                    StreamWriter sw = new StreamWriter(Path.Combine(cRuta, cNombreArchivo), false, new UTF8Encoding(false));
                    for (int i = 0; i < dtDatosTitular.Rows.Count; i++)
                    {
                        string cCadena = dtDatosTitular.Rows[i]["cPeriodoC01"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cTipoPersonaC02"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cTipoDocumento1C03"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cDescripcionTipoDocumentoOtros1C04"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cPaisEmisionTipoDocumento1C05"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cNumeroDocumento1C06"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cTipoDocumento2C07"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cPaisEmisionTipoDocumento2C08"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cNumeroDocumento2C09"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cPrimerApellidoC10"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cSegundoApellidoC11"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cNombresC12"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cDenominacionC13"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cDireccionC14"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cDepartamentoDireccionC15"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cProvinciaDireccionC16"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cDistritoDireccionC17"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cUbigeoDireccionC18"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cPaisDireccionC19"].ToString() +
                                    "|" + dtDatosTitular.Rows[i]["cPaisConstitucionC20"].ToString();
                        sw.WriteLine(cCadena);
                    }
                    sw.Flush();
                    sw.Close();

                    MessageBox.Show("El archivo \"" + cNombreArchivo + "\" se generó correctamente", "Archivo 002: Datos del Titular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Archivo 002: Datos del Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DataTable dtDatosCuenta = this.clsRPTCNDeposito.CNObtenerDatosCuenta(this.dPeriodo);
                    if (dtDatosCuenta.Rows.Count == 0)
                    {
                        MessageBox.Show("No existen datos para el reporte", "Archivo 003: Datos de la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string cRuta = folderBrowserDialog1.SelectedPath;
                    string cNombreArchivo = "20322445564-" + this.dPeriodo.ToString("yyyyMM") + "-DC.txt";
                    StreamWriter sw = new StreamWriter(Path.Combine(cRuta, cNombreArchivo), false, new UTF8Encoding(false));
                    for (int i = 0; i < dtDatosCuenta.Rows.Count; i++)
                    {
                        string cCadena = dtDatosCuenta.Rows[i]["cPeriodoC01"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cTipoCuentaC02"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cDescripcionTipoCuentaOtrosC03"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cNumeroCuentaC04"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cCCIC05"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cMonedaC06"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cTipoTitularidadC07"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["nSaldoCargoMayorC08"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["nSaldoAbonoMayorIgualC09"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["nRendimientoGeneradoC10"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["cCanceladoC11"].ToString() +
                                    "|" + dtDatosCuenta.Rows[i]["dFechaCancelacionC12"].ToString();
                        sw.WriteLine(cCadena);
                    }
                    sw.Flush();
                    sw.Close();

                    MessageBox.Show("El archivo \"" + cNombreArchivo + "\" se generó correctamente", "Archivo 003: Datos de la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Archivo 003: Datos de la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DataTable dtCuentasTitular = this.clsRPTCNDeposito.CNObtenerCuentasPorTitular(this.dPeriodo);
                    if (dtCuentasTitular.Rows.Count == 0)
                    {
                        MessageBox.Show("No existen datos para el reporte", "Archivo 004: Cuentas por Titular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string cRuta = folderBrowserDialog1.SelectedPath;
                    string cNombreArchivo = "20322445564-" + this.dPeriodo.ToString("yyyyMM") + "-CT.txt";
                    StreamWriter sw = new StreamWriter(Path.Combine(cRuta, cNombreArchivo), false, new UTF8Encoding(false));
                    for (int i = 0; i < dtCuentasTitular.Rows.Count; i++)
                    {
                        string cCadena = dtCuentasTitular.Rows[i]["cPeriodoC01"].ToString() +
                                    "|" + dtCuentasTitular.Rows[i]["cTipoDocumento1C02"].ToString() +
                                    "|" + dtCuentasTitular.Rows[i]["cPaisEmisionTipoDocumento1C03"].ToString() +
                                    "|" + dtCuentasTitular.Rows[i]["cNumeroDocumento1C04"].ToString() +
                                    "|" + dtCuentasTitular.Rows[i]["cTipoCuentaC05"].ToString() +
                                    "|" + dtCuentasTitular.Rows[i]["cNumeroCuentaC06"].ToString();
                        sw.WriteLine(cCadena);
                    }
                    sw.Flush();
                    sw.Close();

                    MessageBox.Show("El archivo \"" + cNombreArchivo + "\" se generó correctamente", "Archivo 004: Cuentas por Titular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Archivo 004: Cuentas por Titular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private bool formCabeceraValido()
        {            
            if (!this.txtNumeroPeriodos.valido())
            {
                MessageBox.Show("Caracter numérico (entre 0 y 6)", "Error - Número de Periodos Mensuales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!this.formCabeceraValido()) return;
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string cRuta = folderBrowserDialog1.SelectedPath;
                    string cSemestre = (this.dPeriodo.Month <= 6) ? "01" : "02"; // Semestre al que corresponde la declaración informativa (01 = Primer Semestre y 02 = Segundo semestre)
                    string cNombreArchivo = "Archivo 001 Datos de cabecera de la declaración - " + this.dPeriodo.ToString("yyyy") + cSemestre + ".txt";
                    StreamWriter sw = new StreamWriter(Path.Combine(cRuta, cNombreArchivo), false, new UTF8Encoding(false));
                    string cCadena = "20322445564" + // RUC de la empresa del sistema financiero informante
                        "|0" + (this.cboTipoDeclaracion.SelectedIndex + 1) +
                        ((this.cboCaracteristicaDeclaracion.SelectedIndex == -1) ? "|" : ("|0" + (this.cboCaracteristicaDeclaracion.SelectedIndex + 1))) +
                        "|" + this.cboAnio.Text + // Año que corresponde al semestre de la declaración
                        "|" + cSemestre +
                        "|02" + // La empresa del sistema financiero informante se encuentra afiliada al servicio de transferencia interbancario - (01 = Sí; 02 = No)
                        "|" + this.txtNumeroPeriodos.Text;
                    sw.WriteLine(cCadena);
                    sw.Flush();
                    sw.Close();

                    MessageBox.Show("El archivo \"" + cNombreArchivo + "\" se generó correctamente", "Archivo 001: Datos de cabecera de la declaración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Archivo 001: Datos de cabecera de la declaración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                  
        }

        private void cboTipoDeclaracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoDeclaracion.SelectedIndex == 1)
            {
                this.cboCaracteristicaDeclaracion.SelectedIndex = 0;
                this.cboCaracteristicaDeclaracion.Enabled = true;
            }
            else
            {
                this.cboCaracteristicaDeclaracion.SelectedIndex = -1;
                this.cboCaracteristicaDeclaracion.Enabled = false;
            }
        }
    }
}
