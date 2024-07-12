using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using RPT.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmEnvioEstadosDeCuentaIndividual : frmBase
    {
        clsCNEnvExtCtas clsEnvExtCtas = new clsCNEnvExtCtas();
        DateTime dFechaInicio = new DateTime();
        DateTime dFechaFin = new DateTime();
        string cPathRoot = "";
        string cPathAnioMes = "";
        string cDirectorioMes = "";
        string cDirectorioContrasenia = "";
        int nCorrectos = 0;
        int nIncorrectos = 0;
        string cDni = "";
        DataTable dtDatos = new DataTable();
        DataTable dtEECC = new DataTable();
        int nTipoEnvio = clsVarApl.dicVarGen["nTipoEnvioCorreoMasivo"];
        string cDirectorioSalida = clsVarApl.dicVarGen["cDirecEstAho"];

        public frmEnvioEstadosDeCuentaIndividual()
        {
            InitializeComponent();
            conLoader1.Visible = false;
            conLoader1.Active = false;

            this.btnExporExcel1.Enabled = false;
            this.btnGenerar1.Enabled = false;
            this.btnEnviar1.Enabled = false;

            dtEECC.Columns.Add("cNroCuenta", typeof(string));
            dtEECC.Columns.Add("Nombre", typeof(string));
            dtEECC.Columns.Add("AnioMes", typeof(string));
            dtEECC.Columns.Add("Correo", typeof(string));
            dtEECC.Columns.Add("Estado", typeof(string));
            dtEECC.Columns.Add("Correcto", typeof(string));
            dtEECC.Columns.Add("fechaGeneracion", typeof(DateTime));
            dtEECC.Columns.Add("Adjunto", typeof(string));
        }

        private void frmEnvioEstadosDeCuentaIndividual_Load(object sender, EventArgs e)
        {
            obtenerAnioMes();
        }

        private void conBusCtaAho_ChangeDocumentoID(object sender, EventArgs e)
        {
            dtgCtasCuentas.Columns.Clear();
            obtenerListaEnvioExtractoCtasGenerados();
        }

        private void obtenerListaEnvioExtractoCtasGenerados()
        {
            if (!string.IsNullOrEmpty(conBusCliente.txtCodCli.Text.ToString()) && !string.IsNullOrEmpty(this.txtAnioMes.Text.ToString()) )
            {
                DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreoIndividual(Convert.ToInt32(this.txtAnioMes.Text.ToString()), Convert.ToInt32(conBusCliente.txtCodCli.Text));
                if (dtEnvExtCtas.Rows.Count > 0)
                {
                    for (int i = 0; i < dtEnvExtCtas.Rows.Count; i++)
                    {
                        int nCorrecto = (String.IsNullOrEmpty(dtEnvExtCtas.Rows[i]["lCorrecto"].ToString())) ? 3 : (dtEnvExtCtas.Rows[i]["lCorrecto"].Equals("SI")) ? 1 : 0;
                        dtEnvExtCtas.Rows[i]["cMsgError"] = cEstado((String.IsNullOrEmpty(dtEnvExtCtas.Rows[i]["nTipoGenEnv"].ToString())) ? 5 : Convert.ToInt32(dtEnvExtCtas.Rows[i]["nTipoGenEnv"]), nCorrecto);
                    }
                    this.dtgCtasCuentas.Columns.Clear();
                    this.dtgCtasCuentas.DataSource = dtEnvExtCtas;
                    this.formatoGrid();
                    ColorFilasGrid();
                    resultadoCuenta();
                }
                else
                {
                    MessageBox.Show("No existen datos para Generar los Estados de Cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


        }
        public void formatoGrid()
        {
            for (int i = 0; i < this.dtgCtasCuentas.Columns.Count; i++)
            {
                this.dtgCtasCuentas.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgCtasCuentas.Columns[0].Visible = false;
            this.dtgCtasCuentas.Columns[1].Visible = false;
            this.dtgCtasCuentas.Columns[2].Visible = false;
            this.dtgCtasCuentas.Columns[3].Visible = false;
            this.dtgCtasCuentas.Columns[4].Visible = true;
            this.dtgCtasCuentas.Columns[5].Visible = true;
            this.dtgCtasCuentas.Columns[6].Visible = false;
            this.dtgCtasCuentas.Columns[7].Visible = true;
            this.dtgCtasCuentas.Columns[8].Visible = true;
            this.dtgCtasCuentas.Columns[9].Visible = false;
            this.dtgCtasCuentas.Columns[10].Visible = true;
            this.dtgCtasCuentas.Columns[11].Visible = true;
            this.dtgCtasCuentas.Columns[12].Visible = false;
            this.dtgCtasCuentas.Columns[13].Visible = false;
            this.dtgCtasCuentas.Columns[14].Visible = false;
            dtgCtasCuentas.Columns["cNroCuenta"].HeaderText = "N° de Cuenta";
            dtgCtasCuentas.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgCtasCuentas.Columns["nAnioMes"].HeaderText = "Año y Mes";
            dtgCtasCuentas.Columns["cDireccionEnvioEstCta"].HeaderText = "Correo Electrónico";
            dtgCtasCuentas.Columns["cMsgError"].HeaderText = "Estado";
            dtgCtasCuentas.Columns["dFechaReg"].HeaderText = "F.Registro";

            dtgCtasCuentas.Columns["cNroCuenta"].Width = 150;
            dtgCtasCuentas.Columns["cNombre"].Width = 250;
            dtgCtasCuentas.Columns["nAnioMes"].Width = 50;
            dtgCtasCuentas.Columns["cDireccionEnvioEstCta"].Width = 180;
            dtgCtasCuentas.Columns["cMsgError"].Width = 200;
            dtgCtasCuentas.Columns["dFechaReg"].Width = 100;

            
        }
        private void ColorFilasGrid()
        {
            foreach (DataGridViewRow row in dtgCtasCuentas.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells[13].Value);

                if (idMon == 1)//domicilio
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                else if (idMon == 2)//correo
                {

                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
                else//agencia
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }

            }
        }
        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            dtEECC.Rows.Clear();
            if (this.dtgCtasCuentas.RowCount > 0)
            {
                try
                {

                    var listaEECC = new List<clsListaEECC>();
                    int nCorrecto = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString())) ? 3 : (dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString().Equals("SI")) ? 1 : 0;
                    string cNroCuenta = dtgCtasCuentas.SelectedRows[0].Cells["cNroCuenta"].Value.ToString();
                    string cNombre = dtgCtasCuentas.SelectedRows[0].Cells["cNombre"].Value.ToString();
                    string cAnioMes = dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString();
                    string cCorreo = dtgCtasCuentas.SelectedRows[0].Cells["cDireccionEnvioEstCta"].Value.ToString();
                    string cEstado = this.cEstado((String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value.ToString())) ? 5 : Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value), nCorrecto);
                    string cCorrecto = dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString();
                    string dFechaGeneracion = dtgCtasCuentas.SelectedRows[0].Cells["dFechaReg"].Value.ToString();
                    string dFechaModificado = dtgCtasCuentas.SelectedRows[0].Cells["dFechaMod"].Value.ToString();
                    string cNombreAdjunto = (dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString() != "") ? (dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString() + "_" + dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value.ToString() + "_Secure.pdf") : "";

                    if (String.IsNullOrEmpty(cNroCuenta) || String.IsNullOrEmpty(cEstado) || String.IsNullOrEmpty(cCorrecto) || String.IsNullOrEmpty(dFechaGeneracion) || String.IsNullOrEmpty(cNombreAdjunto))
                    {
                        MessageBox.Show("Para poder exportar, necesita generar el documento primero.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    clsListaEECC objEECC = new clsListaEECC();
                    objEECC.cNroCuenta = dtgCtasCuentas.SelectedRows[0].Cells["cNroCuenta"].Value.ToString();
                    objEECC.cNombre = dtgCtasCuentas.SelectedRows[0].Cells["cNombre"].Value.ToString();
                    objEECC.cAnioMes = dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString();
                    objEECC.cCorreo = dtgCtasCuentas.SelectedRows[0].Cells["cDireccionEnvioEstCta"].Value.ToString();
                    objEECC.cEstado = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].ToString())) ? "" : this.cEstado(Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value), nCorrecto);
                    objEECC.cCorrecto = dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString();
                    objEECC.dFechaGeneracion = dtgCtasCuentas.SelectedRows[0].Cells["dFechaReg"].Value.ToString();
                    objEECC.dFechaModificado = dtgCtasCuentas.SelectedRows[0].Cells["dFechaMod"].Value.ToString();
                    objEECC.cNombreAdjunto = (dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString() != "") ? (dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString() + "_" + dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value.ToString() + "_Secure.pdf") : "";


                    DataRow drfila = dtEECC.NewRow();
                    drfila["cNroCuenta"] = objEECC.cNroCuenta;
                    drfila["Nombre"] = objEECC.cNombre;
                    drfila["AnioMes"] = objEECC.cAnioMes;
                    drfila["Correo"] = objEECC.cCorreo;
                    drfila["Estado"] = objEECC.cEstado;
                    drfila["Correcto"] = objEECC.cCorrecto;
                    drfila["fechaGeneracion"] = objEECC.dFechaGeneracion;
                    drfila["Adjunto"] = objEECC.cNombreAdjunto;

                    dtEECC.Rows.Add(drfila);
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();

                    dtslist.Add(new ReportDataSource("dsListaEnvio", dtEECC));

                    string reportpath = "rptExportarListaCorreo.rdlc";


                    frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel);
                    frmReporte.ShowDialog();
                    
                    //listaEECC.Add(objEECC);

                    //exportarExcel(listaEECC);

                }
                catch (Exception err)
                {
                    MessageBox.Show("Error, debe seleccionar un registro: " +
                        Environment.NewLine + err.Message, "Error al Exportar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        static void exportarExcel(IEnumerable<clsListaEECC> listaEECC)
        {

            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "cNroCuenta";
            workSheet.Cells[1, "B"] = "Nombre";
            workSheet.Cells[1, "C"] = "AnioMes";
            workSheet.Cells[1, "D"] = "Correo";
            workSheet.Cells[1, "E"] = "Estado";
            workSheet.Cells[1, "F"] = "Correcto";
            workSheet.Cells[1, "G"] = "fechaGeneracion";
            workSheet.Cells[1, "H"] = "Adjunto";

            workSheet.get_Range("A1", "H1").Interior.Color = System.Drawing.Color.FromArgb(0, 166, 244);
            workSheet.get_Range("A1", "H1").Font.Bold = true;
            workSheet.get_Range("A1", "H1").Font.Color = System.Drawing.Color.FromArgb(255, 255, 255);
            workSheet.get_Range("A2", "A" + (listaEECC.Count()+2)).NumberFormat = "@";
            var row = 1;
            foreach (var item in listaEECC)
            {
                row++;
                workSheet.Cells[row, "A"] = item.cNroCuenta;
                workSheet.Cells[row, "B"] = item.cNombre;
                workSheet.Cells[row, "C"] = item.cAnioMes;
                workSheet.Cells[row, "D"] = item.cCorreo;
                workSheet.Cells[row, "E"] = item.cEstado;
                workSheet.Cells[row, "F"] = item.cCorrecto;
                workSheet.Cells[row, "G"] = item.dFechaGeneracion;
                workSheet.Cells[row, "H"] = item.cNombreAdjunto;
            }
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[4].AutoFit();
            workSheet.Columns[5].AutoFit();
            workSheet.Columns[6].AutoFit();
            workSheet.Columns[7].AutoFit();
            workSheet.Columns[8].AutoFit();
            ((Excel.Range)workSheet.Columns[1]).AutoFit();
            ((Excel.Range)workSheet.Columns[2]).AutoFit();
            ((Excel.Range)workSheet.Columns[3]).AutoFit();
            ((Excel.Range)workSheet.Columns[4]).AutoFit();
            ((Excel.Range)workSheet.Columns[5]).AutoFit();
            ((Excel.Range)workSheet.Columns[6]).AutoFit();
            ((Excel.Range)workSheet.Columns[7]).AutoFit();
            ((Excel.Range)workSheet.Columns[8]).AutoFit();
            

        }
        public string cEstado(int nValor, int nCorrecto = 0)
        {

            string cResultado ="";
            switch(nValor) 
            {
              case 1:
                    if (nCorrecto == 1)
                    {
                        cResultado = "Documento generado";
                    }
                    else
                    {
                        cResultado = "Documento no generado";
                    }
                
                break;
              case 2:
                if (nCorrecto == 1)
                {
                    cResultado = "Correo enviado";
                }
                else
                {
                    cResultado = "Correo no enviado";
                }
                break;
              case 3:
                cResultado = "Documento generado y enviado";
                break;
              case 4:
                if (nCorrecto == 1)
                {
                    cResultado = "Documento encriptado";
                }
                else
                {
                    cResultado = "Documento no encriptado";
                }
                break;

              default:
                cResultado ="";
                break;
            }
            return cResultado;
        }
        private void obtenerAnioMes()
        {
            string idMes = Convert.ToString(this.conFechaAñoMes1.idMes);
            string idAnio = Convert.ToString(this.conFechaAñoMes1.anio);

            string nDia = "01";

            if (idMes == "1" || idMes == "2" || idMes == "3" || idMes == "4" || idMes == "5" || idMes == "6" || idMes == "7"
                || idMes == "8" || idMes == "9")
            {
                idMes = "0" + idMes;
            }


            string dFecIni = nDia + "/" + idMes + "/" + idAnio;
            dFechaInicio = Convert.ToDateTime(dFecIni);
            int nDiasxMes = System.DateTime.DaysInMonth(Convert.ToInt32(idAnio), Convert.ToInt32(idMes));
            string dFecFin = Convert.ToString(nDiasxMes) + "/" + idMes + "/" + idAnio;
            dFechaFin = Convert.ToDateTime(dFecFin);

            if (dFechaFin > Convert.ToDateTime(clsVarGlobal.dFecSystem.Date.ToString()))
            {
                MessageBox.Show("La generación de estados de cuenta solo aplica después del cierre de mes seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtAnioMes.Text = "";
                this.dtgCtasCuentas.DataSource = null;

                return;
            }
            cPathRoot = "";
            cPathAnioMes = idAnio + idMes;
            this.txtAnioMes.Text = cPathAnioMes;
        }
        private void conFechaAñoMes1_eventCambio(object sender, EventArgs e)
        {
            obtenerAnioMes();
            dtgCtasCuentas.Columns.Clear();
            obtenerListaEnvioExtractoCtasGenerados();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCliente.limpiarControles();
            this.lblResultado.Text = "";
            this.btnExporExcel1.Enabled = false;
            this.btnGenerar1.Enabled = false;
            this.btnEnviar1.Enabled = false;
        }
        private void resultadoCuenta()
        {
            string cResultado = "";
            int nResultado = Convert.ToInt16(dtgCtasCuentas.SelectedRows[0].Cells[13].Value);
            if (nResultado == 1)//domicilio
            {
                this.lblResultado.ForeColor = Color.Red;
                this.btnExporExcel1.Enabled = false;
                this.btnGenerar1.Enabled = false;
                this.btnEnviar1.Enabled = false;
                cResultado = "Extracto de Cuenta a Domicilio.";
            }
            else if (nResultado == 2)//correo
            {
                this.lblResultado.ForeColor = Color.Green;
                this.btnExporExcel1.Enabled = true;
                this.btnGenerar1.Enabled = true;
                this.btnEnviar1.Enabled = true;
                cResultado = "Extracto de Cuenta por Correo.";

            }
            else//agencia
            {
                this.lblResultado.ForeColor = Color.Blue;
                this.btnExporExcel1.Enabled = false;
                this.btnGenerar1.Enabled = false;
                this.btnEnviar1.Enabled = false;
                cResultado = "Extracto de Cuenta en Agencia.";
            }
            this.lblResultado.Text = cResultado;
        }
        private void dtgCtasCuentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resultadoCuenta();

        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            cDirectorioMes = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\SinSeguridad");
            cDirectorioContrasenia = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\ConSeguridad");

            conLoader1.Visible = true;
            conLoader1.Active = true;

            this.btnExporExcel1.Enabled = false;
            this.btnGenerar1.Enabled = false;
            this.btnEnviar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.dtgCtasCuentas.Enabled = false;
            System.IO.Directory.CreateDirectory(cDirectorioMes);
            System.IO.Directory.CreateDirectory(cDirectorioContrasenia);

            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork +=
            delegate(object se, DoWorkEventArgs es)
            {
                this.backgroundWorker_DoWork1(cPathRoot, cPathAnioMes, dFechaInicio, dFechaFin);
            };

            this.backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

            this.backgroundWorker1.RunWorkerAsync();

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;

            this.btnExporExcel1.Enabled = true;
            this.btnGenerar1.Enabled = true;
            this.btnEnviar1.Enabled = true;
            this.btnCancelar1.Enabled = true;
            this.dtgCtasCuentas.Enabled = true;
            obtenerAnioMes();
            dtgCtasCuentas.Columns.Clear();
            obtenerListaEnvioExtractoCtasGenerados();
            MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", "Finalizo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void backgroundWorker_DoWork1(string cPathRoot, string cPathAnioMes, DateTime dFechaInicio, DateTime dFechaFin)
        {

            string reportpath = "rptExtractoCtaSimple.rdlc";// "rptExtCtaCorreo.rdlc";
            int idCuenta = -1;
            string cNroCuenta = "";
            int idUsuario = clsVarGlobal.User.idUsuario;
            string cRuta = "";
            string cDireccion = "";
            nCorrectos = 0;
            nIncorrectos = 0;
            string cFileName = "";
            cDirectorioMes = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\SinSeguridad");
            cDirectorioContrasenia = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\ConSeguridad");

            cDireccion = cDirectorioContrasenia + "\\" + cPathAnioMes + "_" + idCuenta + "_Secure.pdf";

            

            idCuenta = Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value);
            cNroCuenta = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cNroCuenta"].Value);
            idUsuario = clsVarGlobal.User.idUsuario;
            cFileName = Convert.ToString(this.txtAnioMes.Text) + "_" + Convert.ToString(idCuenta);
            cDireccion = cDirectorioContrasenia + "\\" + cPathAnioMes + "_" + idCuenta + "_Secure.pdf";
            dtDatos = new clsRPTCNDeposito().CNRptDetalleExtCtaCorreo(idCuenta);

            cDni = Convert.ToString(this.dtDatos.Rows[0]["cDocumentoID"]);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtDatosCta = new clsRPTCNDeposito().CNDatosExtractoCta(Convert.ToInt32(idCuenta));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("x_dFechaINI", dFechaInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("idCuenta", idCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("dFecProc", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            DataTable dtExtracto = new clsRPTCNDeposito().CNExtractoCta(Convert.ToInt32(idCuenta), dFechaInicio, dFechaFin);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDatosGenCta", dtDatosCta));
            dtslist.Add(new ReportDataSource("dsExtractoCta", dtExtracto));

            DataTable dtExtCtasGenEnv = null;
            try
            {

                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cDirectorioMes, cFileName);

                string destPdf = cDirectorioContrasenia + "\\" + cFileName.ToString() + "_Secure.pdf";
                //sourcePdf  unsecured PDF file
                //destPdf secured PDF file
                string sourcePdf = cDirectorioMes + "\\" + cFileName.ToString() + ".pdf";
                using (Stream input = new FileStream(sourcePdf, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (Stream output = new FileStream(destPdf, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfReader reader = new PdfReader(input);

                        string Password = cDni.ToString();//password
                        PdfEncryptor.Encrypt(reader, output, true, Password, Password, PdfWriter.ALLOW_PRINTING);
                    }
                }

                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 4, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                nCorrectos++;
            }
            catch (Exception ex)
            {
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 4, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());

                nIncorrectos++;
            }

        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            string cPath = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["cPath"].Value.ToString())) ? "" : Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cPath"].Value);
            string cTipoGenEnv = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value.ToString())) ? "" : dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value.ToString();
            string cIdCuenta = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value.ToString()) ) ? "" : dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value.ToString();
            string lCorrecto = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString())) ? "" : dtgCtasCuentas.SelectedRows[0].Cells["lCorrecto"].Value.ToString();

            string cAnioMes = (String.IsNullOrEmpty(dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString())) ? "" : dtgCtasCuentas.SelectedRows[0].Cells["nAnioMes"].Value.ToString();

            if (String.IsNullOrEmpty(cPath) || String.IsNullOrEmpty(cTipoGenEnv) || String.IsNullOrEmpty(cIdCuenta) || String.IsNullOrEmpty(lCorrecto) || String.IsNullOrEmpty(cAnioMes))
            {
                MessageBox.Show("Para poder enviar, necesita generar el documento primero.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int idCuenta = (String.IsNullOrEmpty(cIdCuenta)) ? -1 : Convert.ToInt32(cIdCuenta);
            int nTipoGenEnv = (String.IsNullOrEmpty(cTipoGenEnv)) ? -1 : Convert.ToInt32(cTipoGenEnv);
            if (idCuenta != -1 && ((nTipoGenEnv == 4 && lCorrecto.Equals("SI")) || (nTipoGenEnv == 2 && !lCorrecto.Equals("SI"))))
            {
                switch (nTipoEnvio)
                {
                    case 0:
                        EnvioMasiv();
                        break;
                    case 1:
                        EnvioMasiv();
                        break;
                    case 2:
                        envioNormal();
                        break;
                    case 3:
                        MessageBox.Show("No hay opción seleccionada para envío.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("El correo no se puede enviar, El correo ya fue enviado o faltan datos de Generación de EECC.");
            }
        }

        public void envioNormal()
        {
            int idCuenta = 1;
            idCuenta = Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value);
            string idAnioMes = Convert.ToString(txtAnioMes.Text);
            //int idMes = Convert.ToInt32(this.cboMeses1.SelectedValue);
            string cCorreo = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cDireccionEnvioEstCta"].Value);
            string cNombre = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cNombre"].Value);

            int idUsuario = clsVarGlobal.User.idUsuario;
            idUsuario = clsVarGlobal.User.idUsuario;

            string cDireccion = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cPath"].Value); ;
            int nTamanio = txtAnioMes.Text.Length;
            string cIdMes = txtAnioMes.Text.Substring((nTamanio - 2), 2);
            int nIdMes = Convert.ToInt32(cIdMes);
            DataTable dtExtCtasGenEnv = null;
            try
            {
                DataTable dtEnvioDeCorreos = clsEnvExtCtas.CNEnvioDeCorreos(idCuenta, idAnioMes, nIdMes, cCorreo, cNombre);

                if (Convert.ToInt32(dtEnvioDeCorreos.Rows[0]["cError"]) == 1)
                {

                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                    MessageBox.Show("El correo se envió correctamente.");

                }
                else
                {
                    MessageBox.Show("Error: El correo no se envió correctamente.");
                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ERROR DB");
                }
                
            }
            catch (Exception ex)
            {
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ErrorDB: " + ex.ToString());
                MessageBox.Show("Error: El correo no se envió correctamente.");
            }
        }
        public void EnvioMasiv()
        {

            string cAsunto = "";
            string cMesExtrato = "Estado de Cuenta: " + cAsunto;

            string cPath = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cPath"].Value);
            int idCuenta = Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["idCuenta"].Value);
            int nTipoGenEnv = Convert.ToInt32(dtgCtasCuentas.SelectedRows[0].Cells["nTipoGenEnv"].Value);

            string cNombre = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cNombre"].Value);
            string cCorreo = Convert.ToString(dtgCtasCuentas.SelectedRows[0].Cells["cDireccionEnvioEstCta"].Value);

            string cNombreEmpresa;
            string cCorreoEmpresa;
            string cEndPointEnvioCorreo;
            string cServicio;
            int idUsuario = 0;
            idUsuario = clsVarGlobal.User.idUsuario;
            cNombreEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            cCorreoEmpresa = clsVarApl.dicVarGen["cCorreoEmpresaMasiv"];
            cServicio = clsVarApl.dicVarGen["cUrlServicioMasiv"];

            string cFile = "";

            string base64String = "";
            string cNombresApellido = "";
            string correo = "";
            string cCliente = "";
            string cDestinatarios = "";

            string cHtml = "";

            cFile = cPath;

            if (cFile != null)
            {
                Byte[] bytes = File.ReadAllBytes(cFile);
                base64String = Convert.ToBase64String(bytes);

            }
            string authHeader = clsVarApl.dicVarGen["cAuthHeaderMasiv"];
            cNombresApellido = cNombre;
            correo = cCorreo;
            cCliente = "{\"To\":\"" + cNombresApellido + "<" + correo + ">\",\"From\":\"" + cNombreEmpresa + "<" + cCorreoEmpresa + ">\",\"Subject\":\"" + cMesExtrato + "\",\"Parameters\":[{\"Name\":\"nombre\",\"Type\":\"text\",\"Value\":\"" + cNombresApellido + "\"}],\"Attachments\":[{\"Path\":\"data:application/pdf;base64;base64," + base64String + "\",\"Filename\":\"Extracto de Cuenta.pdf\"}]}";

            cDestinatarios = cCliente;
            cHtml = "<!DOCTYPE html><html><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>Caja Los Andes- Extract de Cuenta</title><style type='text/css'>header {padding: 0 50px;}div.content {padding: 0 50px;}footer {padding: 0 50px;}table.table1 {width: 100%;}table.table2 {width: 100%;padding: 10px 0;background-color: #eee;font-size: 1.2rem;}table.table3 {width: 100%;}table.table4 {width: 100%;font-size: 1.2rem;}table.table5 {width: 100%;font-size: 1.2rem;border-spacing:0; } table.table6 {width: 100%;text-align: center; }p.p1 {text-align: center;color: #064775;font-size: 18px;margin: 1.5rem auto auto;font-family: Arial;}p.p2 {color: #064775;text-align: justify;font-size: 18px;margin-left: 40px;margin-right: 40px;font-family: Arial;}p.p3 {text-align: center;color: #00C7FE;font-size: 15px;font-family: Arial;}p.p4 {/*margin: 0 auto 1rem auto;*/margin: 0;text-align: center;}p.p5 {text-align: center;color: #00C7FE;font-size: 17px;font-family: Arial;font-weight: bold;}table.table2 tr td p {margin: 0;}hr {border-color: white;}div.numero {display: table-cell;vertical-align: middle;height: 2rem;width: 2rem;color: white;background-color: #4CAF50;border-radius: 50%;text-align: center;font-size: 1.2rem;font-weight: bolder;}p.basico {text-align: justify;font-size:small;font-family: Arial;}</style></head><body style='width: 700px; max-width: 700px; min-width: 700px; font-family: Roboto'><header><div style='text-align: center'><img src='https://losandes.pe/wp-content/uploads/Logo-Andes.jpg' alt='Caja Los Andes' height='200px' width='600px'></div></header><div class='content'><table class='table1'><tr><td><p class='p1' style='margin-top: 1rem'>Hola, <span style='text-transform: uppercase'> {{nombre}},</span></p></td></tr><tr><td><p class='p2'>Te adjuntamos tu Estado de Cuenta, para revisarlo debes descargarlo y luego ingresar el número de tu DNI.</p></td></tr></table><table class='table6'><tr><td><b><p class='p3'>Tu cuenta esta supervisado por:</p></b><a href='http://www.sbs.gob.pe/' target='blank'><img src='https://losandes.pe/wp-content/uploads/sbs.jpg' class='img-responsive' alt='Logo de la superintendencia de banca y seguros' ></a></td><td><b><p class='p3'>Y respaldado por:</p></b><a href='http://www.fsd.org.pe/' target='blank'><img src='https://losandes.pe/wp-content/uploads/fsd.jpg' class='img-responsive' alt='Logo de la superintendencia de banca y seguros' ></a></td></tr></table></div><footer><div style='text-align: center; background-color: #064775'><img src='https://losandes.pe/wp-content/uploads/Logo-Andes2.jpg' alt='Caja Los Andes' height='200px' width='600px'><table class='table5'><tr><td style='text-align: center' BGCOLOR='#064775' ><a href='https://www.losandes.pe' target='blank' style='text-decoration: none;'><p class='p5'>Losandes.pe</p></a></td><td BGCOLOR='#064775'><a href='https://www.facebook.com/cajalosandespe' target='blank' style='padding: 5px'><img src='https://losandes.pe/wp-content/uploads/facebook.png' class='img-responsive' width='35' alt='ícono de facebook'></a><a href='https://www.youtube.com/channel/UCUlROITQ08xE6C4-bGaX2cg' target='blank' style='padding: 5px'><img src='https://losandes.pe/wp-content/uploads/youtube.png' class='img-responsive' width='35' alt='ícono de youtube'></a><a href='https://www.instagram.com/losandes_peru/' target='blank' style='padding: 5px'><img src='https://losandes.pe/wp-content/uploads/instagram.png' class='img-responsive' width='35' alt='ícono de instagram'></a><a href='https://www.linkedin.com/company/caja-los-andes---banco-rural-l%C3%ADder-del-per%C3%BA/mycompany/' target='blank' style='padding: 5px'><img src='https://losandes.pe/wp-content/uploads/linkedin.png' class='img-responsive' width='35' alt='ícono de linkedin'></a></td></tr></table></div><div><hr><p class='basico'>Esta comunicación ha sido enviada por Caja Rural de Ahorro y Crédito Los Andes S.A. según los datos personales disponibles en los bancos de datos de los que es titular. Los destinarios pueden ejercer los derechos de acceso, rectificación, cancelación y posición al tratamiento de sus datos apersonándose a cualquier oficina de Los Andes.</p></div></footer></body></html>";
            cEndPointEnvioCorreo = "{\"Subject\":\"" + cMesExtrato + "\",\"From\":\"" + cNombreEmpresa + "<" + cCorreoEmpresa + ">\",\"Template\":{\"Type\":\"text/html\",\"Value\":\"" + cHtml + "\"},\"Recipients\":[" + cDestinatarios + "]}";

            byte[] bBytes = Encoding.UTF8.GetBytes(cEndPointEnvioCorreo);
            byte[] response;
            string concatenar = "";
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Headers.Add("Authorization", "Basic" + " " + authHeader);

            webClient.Encoding = Encoding.UTF8;

            string serviceURL = string.Format(cServicio + "/");
            string cResponse = "";
            try
            {
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                Stream stream = new MemoryStream(response);

                foreach (char a in response)
                {
                    cResponse += a;
                }
                cResponse.Replace("\"", "\\\"");

                clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cFile, Convert.ToInt32(cPathAnioMes), 1, cResponse);
                MessageBox.Show("El correo se envio correctamente.");
            }
            catch (Exception e)
            {
                clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cFile, Convert.ToInt32(cPathAnioMes), 0, e.ToString());
                MessageBox.Show("Error: El correo no se envio correctamente.");
            }
            
        }

        private void dtgCtasCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }


}
