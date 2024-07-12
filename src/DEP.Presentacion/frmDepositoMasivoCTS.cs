using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using DEP.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System.Data.Common;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmDepositoMasivoCTS : frmBase
    {
        private clsCNDeposito Deposito = new clsCNDeposito();
        private DataTable dtCtasCtsEmpleador = new DataTable();
        private DataTable dtDatosCtasCts = new DataTable();
        private DataTable dtCboPlanilla;
        private DataTable dtClienteJuridico;
        private DataTable dtRpt = new DataTable();
        int idEmpPropia = 0;
        int permiso = 0;
        string cNomArchivo;

        
        private Excel.Application oExcel;
        private Excel.Workbook oWorkBook;
        private Excel.Worksheet oWorkSheet;

        public frmDepositoMasivoCTS()
        {
            InitializeComponent();
            cboTipoCargaMasivaAho.cargarDatos(1);
            cboPeriodoCTS.cargarPeriodoCTS(clsVarGlobal.dFecSystem);
        }
        public void CargarCboPlanilla()
        {

            dtCboPlanilla = Deposito.CargarPlanillaNoPagadas();
            cboPlanilla.DataSource = dtCboPlanilla;
            cboPlanilla.ValueMember = dtCboPlanilla.Columns["idPlanilla"].ToString();
            cboPlanilla.DisplayMember = dtCboPlanilla.Columns["cPlanilla"].ToString();
        }

        private void FormatoGrid()
        {
            dtgDatosCtasCts.Columns["nIntNumCel"].Visible = false;
            dtgDatosCtasCts.Columns["idCuenta"].Visible = false;
            dtgDatosCtasCts.Columns["idCliente"].Visible = false;
            dtgDatosCtasCts.Columns["idTipPersona"].Visible = false;
            dtgDatosCtasCts.Columns["nPlazo"].Visible = false;
            dtgDatosCtasCts.Columns["lReproceso"].Visible = false;

            dtgDatosCtasCts.Columns["lSelCta"].Width = 20;
            dtgDatosCtasCts.Columns["cNroDocIde"].Width = 60;
            dtgDatosCtasCts.Columns["cNombre"].Width = 150;
            dtgDatosCtasCts.Columns["cCodCta"].Width = 150;
            dtgDatosCtasCts.Columns["nMontoOperacion"].Width = 80;
            dtgDatosCtasCts.Columns["nMontoComision"].Width = 60;
            dtgDatosCtasCts.Columns["nMontoITF"].Width = 50;
            dtgDatosCtasCts.Columns["nMontoDeposito"].Width = 80;
            dtgDatosCtasCts.Columns["lEjecutado"].Width = 55;

            dtgDatosCtasCts.Columns["lSelCta"].HeaderText = "Sel.";
            dtgDatosCtasCts.Columns["cNroDocIde"].HeaderText = "DNI";
            dtgDatosCtasCts.Columns["cNombre"].HeaderText = "Cliente";
            dtgDatosCtasCts.Columns["cCodCta"].HeaderText = "N° de Cuenta";
            dtgDatosCtasCts.Columns["nMontoOperacion"].HeaderText = "Monto de Operación";
            dtgDatosCtasCts.Columns["nMontoComision"].HeaderText = "Comisión";
            dtgDatosCtasCts.Columns["nMontoITF"].HeaderText = "ITF";
            dtgDatosCtasCts.Columns["nMontoDeposito"].HeaderText = "Monto de Deposito";
            dtgDatosCtasCts.Columns["lEjecutado"].HeaderText = "Ejecutado";

            dtgDatosCtasCts.ReadOnly = false;
            dtgDatosCtasCts.Columns["lSelCta"].ReadOnly = true;
            dtgDatosCtasCts.Columns["cNroDocIde"].ReadOnly = true;
            dtgDatosCtasCts.Columns["cNombre"].ReadOnly = true;
            dtgDatosCtasCts.Columns["cCodCta"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nMontoOperacion"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nMontoComision"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nMontoITF"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nMontoDeposito"].ReadOnly = true;
            dtgDatosCtasCts.Columns["lEjecutado"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nSumUltRem"].ReadOnly = true;
            dtgDatosCtasCts.Columns["nMontoOperacion"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgDatosCtasCts.Columns["nMontoOperacion"].DefaultCellStyle.ForeColor = Color.White;

            if (Convert.ToInt32(cboTipoCargaMasivaAho.SelectedValue) == 1)//CTS
            {
                dtgDatosCtasCts.Columns["nSumUltRem"].Width = 90;
                dtgDatosCtasCts.Columns["nSumUltRem"].Visible = true;
                dtgDatosCtasCts.Columns["nSumUltRem"].HeaderText = "Suma Ultimas Remuneraciones";
                
            }
            else
            {
                dtgDatosCtasCts.Columns["nSumUltRem"].Visible = false;
            }
        }

        private string ValidaNulos(string cValor) 
        {
            if (cValor != null)
            {
                if (cValor.Trim() == "")
                {
                    return null;
                }
                else 
                {
                    return cValor;
                }
            }
            else
            {
                return null;
            }
        }

        private void MensajeError(string cMensaje)
        {
            MessageBox.Show(cMensaje, "Depósitos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);
        }

        private bool CargarArchivo(String rutaArchivo)
        {
            oExcel = new Excel.Application();
            oWorkBook = oExcel.Workbooks.Open(rutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            int idCliente = 0, nFilaSeleccionada = 8, nIntNumCel;
            String cNumCelda, cNroDocIde, cNombre, cCodCta, cMonto, cSumUltRem;
            Decimal nMonto, nSumUltRem;
            bool lIndValCelda = true;

            String cCodCli = Convert.ToString((oWorkSheet.Cells[4, 3] as Excel.Range).Value2);
            cCodCli = (cCodCli == null ? "" : cCodCli);

            if (!(System.Text.RegularExpressions.Regex.IsMatch(cCodCli.Trim(), "^([0-9])*$")))
            {
                MensajeError("El código de cliente no es correcto, solo se admite Números.");
                return false;
            }

            if (cCodCli.Trim().Length != 13)
            {
                MensajeError("El código de cliente no es correcto, verificar archivo.");
                return false;
            }

            if (int.TryParse(cCodCli.Substring(cCodCli.Length - 7, 7), out idCliente) == false)
            {
                MensajeError("El código de cliente no es correcto, verificar archivo.");
                return false;
            }

            if (idCliente != conBusCli.idCli)
            {
                MensajeError("El código de cliente registrado en archivo no coincide con el seleccionado, verificar.");
                return false;
            }

            while (lIndValCelda)
            {
                cNumCelda = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 1] as Excel.Range).Value2);
                cNroDocIde = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 2] as Excel.Range).Value2);

                if (cNumCelda == null && cNroDocIde == null)
                {
                    lIndValCelda = false;
                    break;
                }

                if (ValidaNulos(cNumCelda) == null)
                {
                    MensajeError("Nro: " + (nFilaSeleccionada - 7) + ", El campo 'Nro.' no puede estar vacío.");
                    return false;
                }
                else if (!(System.Text.RegularExpressions.Regex.IsMatch(cNumCelda.Trim(), "^([0-9])*$")))
                {
                    MensajeError("Nro: " + (nFilaSeleccionada - 7) + ", El campo 'Nro.' solo debe ser numérico.");
                    return false;
                }

                nIntNumCel = Convert.ToInt32((oWorkSheet.Cells[nFilaSeleccionada, 1] as Excel.Range).Value2);
                cNombre = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 3] as Excel.Range).Value2);
                cCodCta = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 4] as Excel.Range).Value2);
                cMonto = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 5] as Excel.Range).Value2);
                cSumUltRem = Convert.ToString((oWorkSheet.Cells[nFilaSeleccionada, 6] as Excel.Range).Value2);

                if (nIntNumCel != 0)
                {
                    if (ValidaNulos(cNroDocIde) == null)
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'Documento de Identidad' no puede estar vacío.");
                        return false;
                    }
                    else if (!(System.Text.RegularExpressions.Regex.IsMatch(cNroDocIde.Trim(), "^([0-9])*$")))
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'Documento de Identidad' solo debe contener Números.");
                        return false;
                    }

                    if (ValidaNulos(cNombre) == null)
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'Nombre' no puede estar vacío.");
                        return false;
                    }

                    if (ValidaNulos(cCodCta) == null)
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'N° de Cuenta' no puede estar vacío.");
                        return false;
                    }
                    else if (!(System.Text.RegularExpressions.Regex.IsMatch(cCodCta.Trim(), "^([0-9])*$")))
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'N° de Cuenta' solo puede contener Números.");
                        return false;
                    }

                    if (ValidaNulos(cMonto) == null)
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'Monto' no puede estar vacío.");
                        return false;
                    }
                    else if (!(System.Text.RegularExpressions.Regex.IsMatch(cMonto.Trim(), "^([0-9.,])*$")))
                    {
                        MensajeError("Nro: " + nIntNumCel + ", El 'Monto' solo puede contener Decimales.");
                        return false;
                    }

                    if (ValidaNulos(cSumUltRem) != null)
                    {
                        if (!(System.Text.RegularExpressions.Regex.IsMatch(cSumUltRem.Trim(), "^([0-9.,])*$")))
                        {
                            MensajeError("Nro: " + nIntNumCel + ", La 'Suma de las 4 últimas remuneraciones' solo puede contener Decimales.");
                            return false;
                        }
                    }
                    else
                    {
                        cSumUltRem = null;
                    }

                    nMonto = Convert.ToDecimal((oWorkSheet.Cells[nFilaSeleccionada, 5] as Excel.Range).Value2);
                    nSumUltRem = Convert.ToDecimal(cSumUltRem);
                    dtCtasCtsEmpleador.Rows.Add(nIntNumCel, nMonto > 0 ? true : false, cNroDocIde, cNombre, "0", cCodCta, nMonto, nSumUltRem);
                }
                else
                {
                    lIndValCelda = false;
                }
                nFilaSeleccionada++;
            }

            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);
            return true;
        }

        private void SumaPagos()
        {
            int nNumCtasDep = 0;
            Decimal nMonTotDep = 0;

            for (int i = 0; i < dtDatosCtasCts.Rows.Count; i++)
            {
                bool lSelCta = Convert.ToBoolean(dtDatosCtasCts.Rows[i]["lSelCta"]);
                if (lSelCta)
                {
                    nMonTotDep += Convert.ToDecimal (dtDatosCtasCts.Rows[i]["nMontoOperacion"]);
                    if (Convert.ToDecimal (dtDatosCtasCts.Rows[i]["nMontoOperacion"]) > 0.00m)
                    {
                        nNumCtasDep++;
                    }
                }
            }

            txtNumCtas.Text = dtDatosCtasCts.Rows.Count.ToString();
            txtMonTotDep.Text = nMonTotDep.ToString();
            txtNumCtasDep.Text = nNumCtasDep.ToString();
        }

        private bool validapago()
        {
            bool lvalida = true;

            if (this.txtNumCtasDep.Text.Trim() == "" || Convert.ToDecimal (this.txtMonTotDep.Text) <= 0)
            {
                MessageBox.Show("No hay montos a ser depositados.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            return lvalida;
        }

        public void LiberarCuenta()
        {
            Deposito.CNUpdNoUsoCuentaMasivo(clsVarGlobal.User.idUsuario);
        }

        private void liberarObjecto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = GetIDProcces("EXCEL");

                if (id != -1)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(id).Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private int GetIDProcces(string nameProcces)
        {
            try
            {
                System.Diagnostics.Process[] asProccess = System.Diagnostics.Process.GetProcessesByName(nameProcces);

                foreach (System.Diagnostics.Process pProccess in asProccess)
                {
                    if (pProccess.MainWindowTitle == "")
                    {
                        return pProccess.Id;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        private bool ValidaCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                          int idAgencia, int idProducto, int idMoneda, string xmlLisCtas)
        {
            DataTable dtValidaCargaMasivaAho;
            
            dtValidaCargaMasivaAho = Deposito.CNValidaCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                     idAgencia, idProducto, idMoneda, xmlLisCtas,clsVarGlobal.dFecSystem);
            dtRpt = dtValidaCargaMasivaAho;
            if (dtValidaCargaMasivaAho.Rows.Count==0)
            {
                btnImprimirIncosis.Enabled = false;
                btnImprimirDepMas.Enabled = false;
                return true;
            }
            if (dtValidaCargaMasivaAho.Rows[0]["idError"].ToString().Equals("0"))
            {
                btnImprimirIncosis.Enabled = false;
                btnImprimirDepMas.Enabled = false;
                return true;
            }
            if (dtValidaCargaMasivaAho.Rows[0]["idError"].ToString().Equals("1"))
            {
                MessageBox.Show(dtValidaCargaMasivaAho.Rows[0]["cMensaje"].ToString(), "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimirDepMas.Enabled = true;
                btnImprimirIncosis.Enabled = false;
                return false;
            }
            else
            {
                MessageBox.Show("Inconsistencia en el archivo...\n Se procede a visualizar los errores...", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimirIncosis.Enabled = true;
                btnImprimirDepMas.Enabled = false;
                imprimirInconsistencia();
                return false;
            }
        }

        private void CargarDatosCtaMasivo(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal,
                                           int idAgencia, int idProducto, int idMoneda, string xmlLisCtas)
        {
            dtDatosCtasCts = Deposito.CNRetornaDatosCtaMasivo(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                              idAgencia, idProducto, idMoneda, xmlLisCtas);

            dtgDatosCtasCts.DataSource = dtDatosCtasCts;
            dtgDatosCtasCts.Enabled = true;

            FormatoGrid();
            SumaPagos();

            if (dtgDatosCtasCts.Rows.Count > 0)
            {
                dtgDatosCtasCts.Columns["lSelCta"].ReadOnly = Convert.ToBoolean(dtDatosCtasCts.Rows[0]["lReproceso"]);
            }
        }

        private int RegistraCargaMasivaAho(int idCliente, string cNomArchivo, int idTipoOperac, int idCanal, int idAgencia, int idProducto, int idMoneda,
                                            string xmlLisCtas, int idUsuOpe, int idUsuOrdenante, string cCaracteristica, DateTime dFecOpe, int idTipCarga)
        {
            DataTable dtRegistraCargaMasivaAho;

            dtRegistraCargaMasivaAho = Deposito.CNRegistraCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal,
                                                                         idAgencia, idProducto, idMoneda, xmlLisCtas, idUsuOpe, idUsuOrdenante,
                                                                        cCaracteristica, dFecOpe, idTipCarga);

            return Convert.ToInt32(dtRegistraCargaMasivaAho.Rows[0]["idCarga"].ToString());
        }

        private int RegistraDepositoCtaMasivo(int idCarga, int idCuenta, int nPlazo, int idMoneda, decimal nMonOperac,
                                              decimal nMonComis, decimal nMonITF, int idCanal, int idAgencia, int idUsu,
                                              DateTime dFechaOpe, int idProducto, bool lIsAhoProg, int nCuota,
                                              int nTipPago, string xmlTipPago, string cNroDoc, int cCodInstFin,
                                              int cCtaTransf, int idCliente, int idTipPersona, string cDniCliOpe,
                                              string cNomCliOpe, string cDirCliOpe, int idPeriodoCTS, decimal nSumUltRemun,
                                              int x_idTipoCarga, int x_idPlanilla)
        {
            DataTable dtRegistraDepositoCtaMasivo;

            dtRegistraDepositoCtaMasivo = Deposito.CNRegistraDepositoCtaMasivo(idCarga, idCuenta, nPlazo, idMoneda, nMonOperac,
                                                                            nMonComis, nMonITF, idCanal, idAgencia, idUsu,
                                                                            dFechaOpe, idProducto, lIsAhoProg, nCuota, nTipPago,
                                                                            xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf,
                                                                            idCliente, idTipPersona, cDniCliOpe, cNomCliOpe,
                                                                            cDirCliOpe, idPeriodoCTS, nSumUltRemun, x_idTipoCarga, x_idPlanilla);

            return Convert.ToInt32(dtRegistraDepositoCtaMasivo.Rows[0]["idKardex"].ToString());
        }

        private void frmDepositoMasivoCTS_Load(object sender, EventArgs e)
        {
            dtCtasCtsEmpleador.Columns.Add("nIntNumCel", typeof(int));
            dtCtasCtsEmpleador.Columns.Add("lSelCta", typeof(bool));
            dtCtasCtsEmpleador.Columns.Add("cNroDocIde", typeof(String));
            dtCtasCtsEmpleador.Columns.Add("cNombre", typeof(String));
            dtCtasCtsEmpleador.Columns.Add("idCuenta", typeof(int));
            dtCtasCtsEmpleador.Columns.Add("cCodCta", typeof(String));
            dtCtasCtsEmpleador.Columns.Add("nMonto", typeof(Decimal));
            dtCtasCtsEmpleador.Columns.Add("nSumUltRem", typeof(Decimal));
            CargarCboPlanilla();

            DesactivarControl();

            permiso = 1;
            conBusCli.lblBase2.Text = "Empleador : ";
            this.btnImprimirDepMas.Enabled = false;
        }
        private void DesactivarControl()
        {
            cboMoneda.SelectedIndex = -1;
            cboTipoCargaMasivaAho.SelectedIndex = -1;
            cboPlanilla.SelectedIndex = -1;
            cboPeriodoCTS.SelectedIndex = -1;

            cboTipoCargaMasivaAho.Enabled = false;
            cboMoneda.Enabled = false;
            cboPlanilla.Enabled = false;
            btnImportar.Enabled = false;
            btnAceptar1.Enabled = false;           
            
            cboPeriodoCTS.Enabled = false;
        }
        private void cboTipoCargaMasivaAho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoCargaMasivaAho.SelectedIndex) >= 0)
            {
                if ((bool)cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["lPeriodoCts"] && (int)cboTipoCargaMasivaAho.SelectedValue==1)
                {
                    //lblPeriodoCTS.Visible = true;
                    //cboPeriodoCTS.Visible = true;
                    cboPeriodoCTS.Enabled = true;
                    //cboPlanilla.SelectedIndex = -1;

                    //if (conBusCli1.idCli == idEmpPropia)
                    //{
                    //    btnImportar.Enabled = false;
                    //    //btnAceptar1.Enabled = true;
                    //    //cboPlanilla.Enabled = true;
                    //}
                    //else
                    //{
                        btnImportar.Enabled = true;
                        //btnAceptar1.Enabled = false;
                       // cboPlanilla.Enabled = false;
                    //}
                }
                else
                {
                    //lblPeriodoCTS.Visible = false;
                    //cboPeriodoCTS.Visible = false;
                    cboPeriodoCTS.Enabled = false;
                    cboPeriodoCTS.SelectedIndex = -1;
                    //if (conBusCli1.idCli == idEmpPropia)
                    //{
                        //if (dtCboPlanilla.Rows.Count > 0)
                        //    cboPlanilla.SelectedIndex = 0;
                        //cboPlanilla.Enabled = true;
                        //btnImportar.Enabled = false;
                        //btnAceptar1.Enabled = true;
                        //cboPlanilla.Enabled = true;
                    //}
                    //else
                    //{
                    //    cboPlanilla.SelectedIndex = -1;
                    //    cboPlanilla.Enabled = false;
                        btnImportar.Enabled = true;
                    //    btnAceptar1.Enabled = false;

                    //}
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir el tipo de moneda.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMoneda.Focus();
                return;
            }
            if (cboTipoCargaMasivaAho.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir el tipo a cargar.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoCargaMasivaAho.Focus();
                return;
            }
            if ((int)cboTipoCargaMasivaAho.SelectedValue==1 && cboPeriodoCTS.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir el periodo CTS.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPeriodoCTS.Focus();
                return;
            }
            btnImprimirIncosis.Enabled = false;
            dtCtasCtsEmpleador.Clear();
            dtDatosCtasCts.Clear();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string cNomArc;
                string cCodCli;
                int idCliente;

                cNomArc = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName).Trim();

                if (!(System.Text.RegularExpressions.Regex.IsMatch(cNomArc, "^([0-9_])*$")))
                {
                    MessageBox.Show("El Nombre del archivo es incorrecto, solo se admite Números y Sub Guiones.", "Deposito Masivos ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if ((cNomArc.Length != 24 && cNomArc.Length != 25) || cNomArc.Substring(13, 1) != "_" || cNomArc.Substring(22, 1) != "_")
                {
                    MessageBox.Show("Nombre de Archivo no cumple con formato.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cCodCli = cNomArc.Substring(0, 13);

                if (!(System.Text.RegularExpressions.Regex.IsMatch(cCodCli, "^([0-9])*$")))
                {
                    MessageBox.Show("El código del archivo es incorrecto, solo se admite Números.", "Depósito Masivos ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (int.TryParse(cCodCli.Substring(cCodCli.Length - 7, 7), out idCliente) == false)
                {
                    MessageBox.Show("Archivo no pertenece a Cliente seleccionado, verificar nombre de archivo.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (idCliente != (int)conBusCli.idCli)
                {
                    MessageBox.Show("Archivo no pertenece a Cliente seleccionado, verificar nombre de archivo.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (CargarArchivo(openFileDialog.FileName) == false)
                {
                    return;
                }

                if (dtCtasCtsEmpleador.Rows.Count <= 0)
                {
                    MessageBox.Show("No se cargo ninguna cuenta para deposito masivo.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataSet dsLisCtasAho = new DataSet("dsLisCtasAho");
                dsLisCtasAho.Tables.Add(dtCtasCtsEmpleador);
                string xmlLisCtasAho = dsLisCtasAho.GetXml();
                xmlLisCtasAho = clsCNFormatoXML.EncodingXML(xmlLisCtasAho);
                dsLisCtasAho.Tables.Clear();

                 cNomArchivo = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName).Trim();
                int idTipoOperac = 10;   // Deposito
                int idCanal = 1;        // Ventanilla
                int idAgencia = clsVarGlobal.nIdAgencia;
                int idProducto = (int)cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["idProducto"];
                int idMoneda = (int)cboMoneda.SelectedValue;

                if (!ValidaCargaMasivaAho(idCliente, cNomArchivo, idTipoOperac, idCanal, idAgencia, idProducto, idMoneda, xmlLisCtasAho))
                {
                    return;
                }

                CargarDatosCtaMasivo(idCliente, cNomArchivo, idTipoOperac, idCanal, idAgencia, idProducto, idMoneda, xmlLisCtasAho);

                conBusCli.Enabled = false;
                cboMoneda.Enabled = false;
                cboTipoCargaMasivaAho.Enabled = false;
                cboPeriodoCTS.Enabled = false;

                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnImportar.Enabled = false;

                txtMonTotDep.Enabled = false;
                txtNumCtasDep.Enabled = false;
            }
        }

        private void dtgDepositosCTS_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDatosCtasCts.IsCurrentCellDirty)
            {
                dtgDatosCtasCts.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgDepositosCTS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SumaPagos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
              * REGISTRO DE RASTREO
          ========================================================================================*/

            this.registrarRastreo(conBusCli.idCli, 0, "Inicio-Deposito masivo cts", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (!validapago())
            {
                return;
            }

            if (string.IsNullOrEmpty(conBusCol.idUsu))
            {
                MessageBox.Show("Debe ingresar los datos del ordenante.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal nMontoTotal = 0;
            int nTipPago = 7; // Nota de cargo

            nMontoTotal = Convert.ToDecimal(txtMonTotDep.Text);

            if (conBusCli.txtNroDoc.Text != clsVarApl.dicVarGen["cRUC"])
            {
                nTipPago = 1; // Efectivo

                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 1, nMontoTotal))
                {
                    return;
                }
            }

            int idCarga = 0;
            int idCliJuridico = conBusCli.idCli;
            string cNomArchivo = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName).Trim();
            int idTipoOperac = 10;   // Deposito
            int idCanal = 1;        // Ventanilla
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idProducto = (int)cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["idProducto"];
            int idMoneda = (int)cboMoneda.SelectedValue;
            int idUsuOrdenante = Convert.ToInt32(conBusCol.idUsu);
            int x_idTipoCarga = (int)cboTipoCargaMasivaAho.SelectedValue;
            DataSet dsDatosCtasCts = new DataSet("dsDatosCtasCts");
            dsDatosCtasCts.Tables.Add(dtDatosCtasCts);
            string xmlDatosCtasCts = dsDatosCtasCts.GetXml();
            xmlDatosCtasCts = clsCNFormatoXML.EncodingXML(xmlDatosCtasCts);
            dsDatosCtasCts.Tables.Clear();
            string cCaracteristica = txtCaracteristica.Text;

            idCarga = RegistraCargaMasivaAho(idCliJuridico, cNomArchivo, idTipoOperac, idCanal,
                                             idAgencia, idProducto, idMoneda, xmlDatosCtasCts,
                                             clsVarGlobal.PerfilUsu.idUsuario, idUsuOrdenante, cCaracteristica,
                                             clsVarGlobal.dFecSystem, x_idTipoCarga);

            int idKardex;
            int idCuenta;
            int nPlazo;
            decimal nMonOperac;
            decimal nMonComis;
            decimal nMonITF;
            int idUsu = clsVarGlobal.PerfilUsu.idUsuario;
            DateTime dFechaOpe = clsVarGlobal.dFecSystem;
            bool lIsAhoProg = false;
            int nCuota = 0;                
            
            string xmlTipPago = clsCNFormatoXML.EncodingXML("<dsDeposito><Table1></Table1></dsDeposito>");
            string cNroDoc = "";
            int cCodInstFin = 0;
            int cCtaTransf = 0;
            int idCliOperac;
            int idTipPersona;
            string cDniCliOpe = "";
            string cNomCliOpe = "";
            string cDirCliOpe = "";
            
            int idPeriodoCTS = 0;
            if ((bool)cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["lPeriodoCts"])
            {
                idPeriodoCTS = (int)cboPeriodoCTS.SelectedValue;
            }

            int x_idPlanilla = 0;
            if (Convert.ToInt32(cboPlanilla.SelectedValue) > 0)
            {
                x_idPlanilla = Convert.ToInt32(cboPlanilla.SelectedValue);
            }

            decimal nSumUltRemun;
            string cSumUltRem;

            DataTable dtRepreJuridica = new clsCNAperturaCta().RetornaRepreJuridica(idCliJuridico);
            if (dtRepreJuridica.Rows.Count > 0)
            {
                cNomCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cNombre"]);
                cDniCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cDocumentoID"]);
                cDirCliOpe = Convert.ToString(dtRepreJuridica.Rows[0]["cDireccion"]);
            }

            int idProductoCta = 0;
            
            for (int i = 0; i < dtDatosCtasCts.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtDatosCtasCts.Rows[i]["lEjecutado"]))
                {
                    continue;
                }

                if (!Convert.ToBoolean(dtDatosCtasCts.Rows[i]["lSelCta"]))
                {
                    continue;
                }

                nMonOperac = Convert.ToDecimal(dtDatosCtasCts.Rows[i]["nMontoOperacion"]);
                if (nMonOperac <= 0)
                {
                    continue;
                }

                if (ValidaNulos(dtDatosCtasCts.Rows[i]["nSumUltRem"].ToString()) == null)
                {
                    dtDatosCtasCts.Rows[i]["nSumUltRem"] = null;
                }

                idCuenta = Convert.ToInt32(dtDatosCtasCts.Rows[i]["idCuenta"]);
                nPlazo = Convert.ToInt32(dtDatosCtasCts.Rows[i]["nPlazo"]);
                nMonComis = Convert.ToDecimal(dtDatosCtasCts.Rows[i]["nMontoComision"]);
                nMonITF = Convert.ToDecimal(dtDatosCtasCts.Rows[i]["nMontoITF"]);
                idCliOperac = Convert.ToInt32(dtDatosCtasCts.Rows[i]["idCliente"]);
                idTipPersona = Convert.ToInt32(dtDatosCtasCts.Rows[i]["idTipPersona"]);
                nSumUltRemun = Convert.ToDecimal((dtDatosCtasCts.Rows[i]["nSumUltRem"]));
                idProductoCta = Convert.ToInt32((dtDatosCtasCts.Rows[i]["idProducto"]));
                idKardex = RegistraDepositoCtaMasivo(idCarga, idCuenta, nPlazo, idMoneda, nMonOperac, nMonComis, nMonITF,
                                                     idCanal, idAgencia, idUsu, dFechaOpe, idProductoCta, lIsAhoProg, nCuota,
                                                     nTipPago, xmlTipPago, cNroDoc, cCodInstFin, cCtaTransf, idCliOperac,
                                                     idTipPersona, cDniCliOpe, cNomCliOpe, cDirCliOpe, idPeriodoCTS, nSumUltRemun, 
                                                     x_idTipoCarga, x_idPlanilla);

                //if (Convert.ToInt32(cboPlanilla.SelectedValue) > 0)
                //{
                //    int idTipoPlanillaPeriodo = 0;  // 1==>planilla,   2==>periodo
                //    int idPlanillaPeriodo = 0;
                //    if (Convert.ToInt32(cboTipoCargaMasivaAho.SelectedValue) == 1)
                //    {
                //        idTipoPlanillaPeriodo = 1;
                //        idPlanillaPeriodo = Convert.ToInt32(cboPlanilla.SelectedValue);
                //    }
                //    else
                //    {
                //        idTipoPlanillaPeriodo = 2;
                //        idPlanillaPeriodo = Convert.ToInt32(cboPeriodoCTS.SelectedValue);
                //    }
                //Deposito.ActualizarPlanillaPagada(idKardex, idTipoPlanillaPeriodo, idPlanillaPeriodo, clsVarApl.dicVarGen["dFechaGRH"], idCliOperac);
                //}

                dtDatosCtasCts.Columns["lEjecutado"].ReadOnly = false;
                dtDatosCtasCts.Rows[i]["lEjecutado"] = true;
                dtDatosCtasCts.Columns["lEjecutado"].ReadOnly = true;
                                
            }

            //----------------------------------------------------------------------------------
            //--Actualizar Saldos de Caja
            //----------------------------------------------------------------------------------
            if (nTipPago == 1)
            {
                ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt16(cboMoneda.SelectedValue), 1, nMontoTotal);
            }

            /*========================================================================================
                * REGISTRO DE RASTREO
                ========================================================================================*/

            this.registrarRastreo(conBusCli.idCli, 0, "Fin-Deposito masivo cts", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            MessageBox.Show("Deposito masivo Realizado Satisfactoriamente.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LiberarCuenta();

            if (dtgDatosCtasCts.Rows.Count > 0)
            {
                dtgDatosCtasCts.Columns["lSelCta"].ReadOnly = true;
            }
            btnImprimirDepMas_Click(sender,e);
            if (cboPlanilla.Text != "")
            {
                CargarCboPlanilla();
                if (dtCboPlanilla.Rows.Count > 0)
                    cboPlanilla.SelectedIndex = 0;
            }

            this.btnGrabar.Enabled = false;
            btnImprimirDepMas.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnImportar.Enabled = false;
            this.btnAceptar1.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtgDatosCtasCts.Enabled = false;
            conBusCli.Enabled = true;
            this.cboMoneda.Enabled = true;
            this.cboTipoCargaMasivaAho.Enabled = true;
            this.cboPeriodoCTS.Enabled = true;

            this.btnGrabar.Enabled = false;
            this.btnImprimirIncosis.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.btnImprimirDepMas.Enabled = false;
            conBusCol.LimpiarDatos();
            txtCaracteristica.Clear();

            //if (conBusCli1.idCli == idEmpPropia)
            //{
            //    this.btnImportar.Enabled = false;
            //    this.btnAceptar1.Enabled = true;
            //}
            //if (conBusCli1.idCli != idEmpPropia)
            //{
                this.btnImportar.Enabled = true;
            //    this.btnAceptar1.Enabled = false;
            //}


            //if (cboPlanilla.Text != "")
            //    this.cboPlanilla.Enabled = true;
            //else
            //    this.cboPlanilla.Enabled = false;


            this.dtgDatosCtasCts.DataSource = "";
            this.txtNumCtasDep.Text = "";
            this.txtNumCtas.Text = "";
            this.txtMonTotDep.Text = "";
            conBusCli.limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;
            LiberarCuenta();
            DesactivarControl();
            txtCaracteristica.Enabled = false;
            conBusCol.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        private void frmDepositoMasivoCTS_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (cboPeriodoCTS.Visible == true && cboPeriodoCTS.Text == "")
            {
                MessageBox.Show("Seleccione el Periodo CTS.", "Depósito Masivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataSet dsLisCtasAho = new DataSet("dsLisCtasAho");
            dsLisCtasAho.Tables.Add(dtCtasCtsEmpleador);
            string xmlLisCtasAho = dsLisCtasAho.GetXml();
            xmlLisCtasAho = clsCNFormatoXML.EncodingXML(xmlLisCtasAho);
            dsLisCtasAho.Tables.Clear();

            int idTipoPlanillaPeriodo = 0;  // 1==>planilla,   2==>periodo
            int idPlanillaPeriodo = 0;
            if (Convert.ToInt32(cboTipoCargaMasivaAho.SelectedValue) == 1)//==>planilla, 
            {
            //    idTipoPlanillaPeriodo = 1;
            //    idPlanillaPeriodo = Convert.ToInt32(cboPlanilla.SelectedValue);
            //}
            //else //==>periodo
            //{
                idTipoPlanillaPeriodo = 2;//verificar falta  corregir
                idPlanillaPeriodo = Convert.ToInt32(cboPeriodoCTS.SelectedValue);
            }


            int idTipoOperac = 10;   // Deposito
            int idCanal = 1;        // Ventanilla
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idProducto = (int)cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["idProducto"];
            int idMoneda = (int)cboMoneda.SelectedValue;


            //------------------------------------------------------------------------------------
            dtDatosCtasCts = Deposito.CNRetornaCtaMasivoPropio(idTipoPlanillaPeriodo, idPlanillaPeriodo, idTipoOperac,
                                                                idCanal, idAgencia, idProducto, idMoneda, xmlLisCtasAho);
            dtgDatosCtasCts.DataSource = dtDatosCtasCts;
            dtgDatosCtasCts.Enabled = true;
            FormatoGrid();
            SumaPagos();
            if (dtgDatosCtasCts.Rows.Count > 0)
            {
                dtgDatosCtasCts.Columns["lSelCta"].ReadOnly = Convert.ToBoolean(dtDatosCtasCts.Rows[0]["lReproceso"]);
            }
            //------------------------------------------------------------------------------------

            conBusCli.Enabled = false;
            cboMoneda.Enabled = false;
            cboTipoCargaMasivaAho.Enabled = false;
            cboPeriodoCTS.Enabled = false;
            cboPlanilla.Enabled = false;

            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnImportar.Enabled = false;
            this.btnAceptar1.Enabled = false;

            txtMonTotDep.Enabled = false;
            txtNumCtasDep.Enabled = false;
        }

        private void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlanilla.SelectedIndex >= 0)
                btnAceptar1.Enabled = true;
            else
                btnAceptar1.Enabled = false;
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.nidTipoPersona == 0)
            {
                return;
            }
            if (conBusCli.nidTipoPersona == 1)
            {
                MessageBox.Show("Debe elegir una persona jurídica.", "Deposito masivo cts.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli.limpiarControles();
                return;
            }
            if (clsVarApl.dicVarGen["cRUC"] == conBusCli.txtNroDoc.Text)
            {
                idEmpPropia = conBusCli.idCli;
                CargarCboPlanilla();
                if (dtCboPlanilla.Rows.Count > 0)
                    cboPlanilla.SelectedIndex = 0;
            }
            if (permiso == 1)
            {
                cboTipoCargaMasivaAho.Enabled = true ;
                cboMoneda.Enabled = true ;
                btnCancelar.Enabled = true;
                conBusCli.btnBusCliente.Enabled = false;
                txtCaracteristica.Enabled = true;
                conBusCol.Enabled = true;
                conBusCol.txtCod.Enabled = true;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            imprimirInconsistencia();
        }
        private void imprimirInconsistencia()
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cEmpleador = conBusCli.txtNombre.Text;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
        

            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cEmpleador", cEmpleador, false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
        
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDescripcionError", dtRpt));

            string reportpath = "rptErrorCargaMasiva.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprimirDepMas_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            
            string idProducto =cboTipoCargaMasivaAho.tbTipoCargaMasiva.Rows[cboTipoCargaMasivaAho.SelectedIndex]["idProducto"].ToString();
            string idMoneda =cboMoneda.SelectedValue.ToString();
            
            
            paramlist.Add(new ReportParameter("idCliente", conBusCli.idCli.ToString(), false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda, false));
            paramlist.Add(new ReportParameter("idAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProducto, false));
            paramlist.Add(new ReportParameter("dFechaOpe", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cNombreArc", cNomArchivo, false));

            DataTable dtDepMasivo = new clsRPTCNDeposito().CNRptDepositoMasivo(conBusCli.idCli, Convert.ToInt32(idMoneda), clsVarGlobal.nIdAgencia, Convert.ToInt32(idProducto), cNomArchivo);
       
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDepositoMasivo", dtDepMasivo));

            string reportpath = "rptDepositoMasivo.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            conBusCol.txtCod.Enabled = false;
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}