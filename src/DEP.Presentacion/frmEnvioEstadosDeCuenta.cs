using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using EntityLayer;
namespace DEP.Presentacion
{
    public partial class frmEnvioEstadosDeCuenta : frmBase
    {
        #region Variables Globales

        clsCNEnvExtCtas clsEnvExtCtas = new clsCNEnvExtCtas();
        DataTable dtDatos = new DataTable();
        DataTable dtEnvioDeCorreos = new DataTable();
                
        string cNota="";
        int nCorrectos = 0;
        int nIncorrectos = 0;
        //string dFechaInicio="20170601";
        //string dFechaFin="20170630";
        //DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
        DateTime dFechaInicio=new DateTime();
        DateTime dFechaFin=new DateTime();
        string cDni="";
        //string cDirecPrincipal = clsVarApl.dicVarGen["cIdPerfilAsesor"];
        string cDirectorioSalida = clsVarApl.dicVarGen["cDirecEstAho"];
        string lBloqueo = clsVarApl.dicVarGen["lBloqueoGenerarEECC"];
        string cDirectorioMes = "";
        string cDirectorioContrasenia = "";
        string cTitulo = "Envío de Estados de Cuenta Mensual - Ahorros";
        string cPathRoot = "";
        string cPathAnioMes ="";
        DataTable dtEECC = new DataTable();
        int nIdMes;
        int nTime = Convert.ToInt32(clsVarApl.dicVarGen["nTimeEnvioEstados"]);
        
        #endregion
        public frmEnvioEstadosDeCuenta()
        {
            InitializeComponent();
            conLoader1.Visible = false;
            conLoader1.Active = false;  
            this.btnGenerar1.Enabled = false;
            this.btnEnviar1.Enabled = false; 
            //this.btnImprimir1.Enabled = false;

            dtEECC.Columns.Add("cNroCuenta", typeof(string));
            dtEECC.Columns.Add("Nombre", typeof(string));
            dtEECC.Columns.Add("AnioMes", typeof(string));
            dtEECC.Columns.Add("Correo", typeof(string));
            dtEECC.Columns.Add("Estado", typeof(string));
            dtEECC.Columns.Add("Correcto", typeof(string));
            dtEECC.Columns.Add("fechaGeneracion", typeof(DateTime));
            dtEECC.Columns.Add("Adjunto", typeof(string));

        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("No podrá cerrar el formulario, mientras se esté GENERANDO los Estados de Cuenta, ¿Está seguro de continuar?", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {

                HabilitarBtn(0);
                conLoader1.Visible = true;
                conLoader1.Active = true;
                cDirectorioMes = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\SinSeguridad");
                cDirectorioContrasenia = System.IO.Path.Combine(cDirectorioSalida, cPathAnioMes + "\\ConSeguridad");
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
            else
            {
                return;
            }

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
            string cFileName="";

            foreach (DataGridViewRow row in dtgBase1.Rows)
            {
                //if (Convert.ToInt32(row.Cells["lCheck"].Value) == 1)
                //{
                
                    idCuenta = Convert.ToInt32(row.Cells["idCuenta"].Value);
                    cNroCuenta = Convert.ToString(row.Cells["cNroCuenta"].Value);
                    idUsuario = clsVarGlobal.User.idUsuario;
                    cFileName = Convert.ToString(this.txtBase1.Text)+"_"+Convert.ToString(idCuenta);

                    dtDatos = new clsRPTCNDeposito().CNRptDetalleExtCtaCorreo(idCuenta);

                    cDni = Convert.ToString(this.dtDatos.Rows[0]["cDocumentoID"]);

                    /*
                        DataTable dtRpt1 = new clsRPTCNDeposito().CNRptDetalleExtCtaCorreo(idCuenta);
                        DataTable dtRpt2 = new clsRPTCNDeposito().CNRptMovimientosExtCtaCorreo(idCuenta, dFechaInicio, dFechaFin);

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Clear();

                        paramlist.Add(new ReportParameter("x_dFechaINI", dFechaInicio.ToString("dd/MM/yyyy"), false));
                        paramlist.Add(new ReportParameter("x_dFechaFIN", dFechaFin.ToString("dd/MM/yyyy"), false));
                        paramlist.Add(new ReportParameter("x_cNomEmpresa", "", false));
                        paramlist.Add(new ReportParameter("x_cNomAgen", "", false));
                        paramlist.Add(new ReportParameter("x_cMensaje", this.cNota, false));
                        paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                        dtslist.Clear();

                        dtslist.Add(new ReportDataSource("dsGenExtracCta", dtRpt1));
                        dtslist.Add(new ReportDataSource("dsExtractoCuenta", dtRpt2));
                    */
                   //esde aquiiiiii
                                   
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
                   // if (dtExtracto.Rows.Count == 0)
                   // {
                   //     MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   //     return;
                   // }
                  
                // DataTable dtResImpExtCta = new clsRPTCNDeposito().CNRegistroImpresionesExtCta(Convert.ToInt32(idCuenta), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia);
                
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsDatosGenCta", dtDatosCta));
                    dtslist.Add(new ReportDataSource("dsExtractoCta", dtExtracto));

                   // string reportpath = "rptExtractoCtaSimple.rdlc";
                   // new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    DataTable dtExtCtasGenEnv = null;
                    try
                    {

                        new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cDirectorioMes, cFileName);

                        string destPdf = cDirectorioContrasenia +"\\"+ cFileName.ToString() + "_Secure.pdf";
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
                        nCorrectos++;
                    }
                    catch (Exception ex)
                    {
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());

                        nIncorrectos++;
                    }

               // }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;
           MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
           HabilitarBtn(2);
        }
  

        private void obtenerListaEnvioExtractoCtasGenerados()
        {   
            DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 1, Convert.ToInt32(this.txtBase1.Text));
            if (dtEnvExtCtas.Rows.Count > 0)
            {
                //dtEnvExtCtas.Columns["lCheck"].ReadOnly = false;

                this.dtgBase1.DataSource = dtEnvExtCtas;
                //this.dtgBase1.Refresh();
                for (int i = 0; i < dtEnvExtCtas.Rows.Count; i++)
                {
                    int nCorrecto = (String.IsNullOrEmpty(dtEnvExtCtas.Rows[i]["lCorrecto"].ToString())) ? 3 : (dtEnvExtCtas.Rows[i]["lCorrecto"].Equals("SI")) ? 1 : 0;
                    dtEnvExtCtas.Rows[i]["cMsgError"] = cEstado((String.IsNullOrEmpty(dtEnvExtCtas.Rows[i]["nTipoGenEnv"].ToString())) ? 5 : Convert.ToInt32(dtEnvExtCtas.Rows[i]["nTipoGenEnv"]), nCorrecto);
                }
                dtgBase1.Columns["idCuenta"].Width = 25;
                dtgBase1.Columns["cNombre"].Width = 70;
                dtgBase1.Columns["nAnioMes"].Width = 25;
                dtgBase1.Columns["cDireccionEnvioEstCta"].Width = 70;
                dtgBase1.Columns["cMsgError"].Width = 50;
                dtgBase1.Columns["dFechaReg"].Width = 30;
                
                this.dtgBase1.ReadOnly = true;
                this.dtgBase1.Columns[0].Visible = false;
                this.dtgBase1.Columns[1].Visible = false;
                this.dtgBase1.Columns[2].Visible = false;
                this.dtgBase1.Columns[3].Visible = true;
                this.dtgBase1.Columns[4].Visible = false;
                this.dtgBase1.Columns[5].Visible = true;
                this.dtgBase1.Columns[6].Visible = false;
                this.dtgBase1.Columns[7].Visible = true;
                this.dtgBase1.Columns[8].Visible = true;
                this.dtgBase1.Columns[9].Visible = false;
                this.dtgBase1.Columns[10].Visible = true;
                this.dtgBase1.Columns[11].Visible = true;
                this.dtgBase1.Columns[12].Visible = false;
                this.dtgBase1.Columns[13].Visible = false;
                dtgBase1.Columns["idCuenta"].HeaderText = "N° de Cuenta";
                dtgBase1.Columns["cNombre"].HeaderText = "Nombre del Cliente";
                dtgBase1.Columns["nAnioMes"].HeaderText = "Año y Mes";
                dtgBase1.Columns["cDireccionEnvioEstCta"].HeaderText = "Correo Electrónico";
                dtgBase1.Columns["cMsgError"].HeaderText = "Estado";
                dtgBase1.Columns["dFechaReg"].HeaderText = "F.Registro";
             
            }
            else
            {
                MessageBox.Show("No existen datos para Generar los Estados de Cuenta.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            string idMes = Convert.ToString(this.conFechaAñoMes1.idMes.ToString());
            string idAnio = Convert.ToString(this.conFechaAñoMes1.anio.ToString());

            string nDia="01";
            
            if (idMes == "1" || idMes == "2" || idMes == "3" || idMes == "4" || idMes == "5" || idMes == "6" || idMes == "7"
                || idMes == "8" || idMes == "9")
            {
                idMes = "0" + idMes;
            }


            string dFecIni = nDia + "/" + idMes + "/" + idAnio;
            dFechaInicio=Convert.ToDateTime(dFecIni);
            int nDiasxMes = System.DateTime.DaysInMonth(Convert.ToInt32(idAnio),Convert.ToInt32(idMes));
            string dFecFin = Convert.ToString(nDiasxMes)+"/" + idMes+"/" + idAnio;
            dFechaFin = Convert.ToDateTime(dFecFin);

            if (dFechaFin > Convert.ToDateTime(clsVarGlobal.dFecSystem.Date.ToString()))
            {
                MessageBox.Show("La generación de estados de cuenta solo aplica despues del cierre de mes seleccionado.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtBase1.Text = "";
                this.dtgBase1.DataSource = null;
                this.dtgBase2.DataSource = null;
            
                return;
            }

            cPathRoot = "";
            cPathAnioMes = idAnio + idMes;
            this.txtBase1.Text = cPathAnioMes;

            obtenerListaEnvioExtractoCtasGenerados();
            obtenerListaEnvioExtractoCtasEnviados();
            
            DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 1, Convert.ToInt32(this.txtBase1.Text));
            string cMsgError = dtEnvExtCtas.Rows[0]["cMsgError"].ToString();
            if (dtEnvExtCtas.Rows.Count > 0 && (cMsgError == null || cMsgError == "") && this.lBloqueo.Equals("1"))
            {
                this.btnGenerar1.Enabled = true;
            }
            else
            {
                this.btnGenerar1.Enabled = false;
            }
            //this.btnEnviar1.Enabled = false;
             DataTable dtEnvExtCtas1 = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 2, Convert.ToInt32(this.txtBase1.Text));
             if (dtEnvExtCtas1.Rows.Count > 0)
             {
                 this.btnEnviar1.Enabled = false;
             }
             else if (dtEnvExtCtas1.Rows.Count == 0 && (cMsgError == null || cMsgError == ""))
             {
                 this.btnEnviar1.Enabled = false;
             }
             else
             {
                 if (this.lBloqueo.Equals("0"))
                 {
                     this.btnEnviar1.Enabled = false;
                 }
                 else
                 {
                     this.btnEnviar1.Enabled = true;
                 }
             }



           // this.btnImprimir1.Enabled = false;

        }
        private void obtenerListaEnvioExtractoCtasEnviados()
        {
            DataTable dtEnvExtCtas1 = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 2, Convert.ToInt32(this.txtBase1.Text));
            if (dtEnvExtCtas1.Rows.Count > 0)
            {
               // dtEnvExtCtas.Columns["lCheck"].ReadOnly = false;

                this.dtgBase2.DataSource = dtEnvExtCtas1;
                //this.dtgBase2.Refresh();
                for (int i = 0; i < dtEnvExtCtas1.Rows.Count; i++)
                {
                    int nCorrecto = (String.IsNullOrEmpty(dtEnvExtCtas1.Rows[i]["lCorrecto"].ToString())) ? 3 : (dtEnvExtCtas1.Rows[i]["lCorrecto"].Equals("SI")) ? 1 : 0;
                    dtEnvExtCtas1.Rows[i]["cMsgError"] = cEstado((String.IsNullOrEmpty(dtEnvExtCtas1.Rows[i]["nTipoGenEnv"].ToString())) ? 5 : Convert.ToInt32(dtEnvExtCtas1.Rows[i]["nTipoGenEnv"]), nCorrecto);
                }
                this.dtgBase2.ReadOnly = true;
                this.dtgBase2.Columns[0].Visible = false;
                this.dtgBase2.Columns[1].Visible = false;
                this.dtgBase2.Columns[2].Visible = false;
                this.dtgBase2.Columns[3].Visible = true;
                this.dtgBase2.Columns[4].Visible = false;
                this.dtgBase2.Columns[5].Visible = true;
                this.dtgBase2.Columns[6].Visible = false;
                this.dtgBase2.Columns[7].Visible = true;
                this.dtgBase2.Columns[8].Visible = true;
                this.dtgBase2.Columns[9].Visible = false;
                this.dtgBase2.Columns[10].Visible = true;
                this.dtgBase2.Columns[11].Visible = true;
                this.dtgBase2.Columns[12].Visible = false;
                this.dtgBase2.Columns[13].Visible = false;
                this.dtgBase2.Columns["idCuenta"].HeaderText = "N° de Cuenta";
                this.dtgBase2.Columns["cNombre"].HeaderText = "Nombre del Cliente";
                this.dtgBase2.Columns["nAnioMes"].HeaderText = "Año y Mes";
                this.dtgBase2.Columns["cDireccionEnvioEstCta"].HeaderText = "Correo Electrónico";
                this.dtgBase2.Columns["cMsgError"].HeaderText = "Estado";
                this.dtgBase2.Columns["dFechaReg"].HeaderText = "F.Registro";

                //this.dtgBase2.Columns["idCuenta"].Width = 25;
                //this.dtgBase2.Columns["cNombre"].Width = 70;
                //this.dtgBase2.Columns["nAnioMes"].Width = 25;
                //this.dtgBase2.Columns["cDireccionEnvioEstCta"].Width = 70;
                //this.dtgBase2.Columns["cMsgError"].Width = 10;
                //this.dtgBase2.Columns["dFechaReg"].Width = 30;
            }
            else
            {
                //this.btnEnviar1.Enabled = true;
                MessageBox.Show("No existen Estados de Cuenta Enviados para este mes.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtgBase2.DataSource = null;
                return;
            }
        }        


        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de enviar los estados de cuenta generados?, No podrá cerrar el formulario, mientras se esten ENVIANDO, tome sus previsiones.", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                HabilitarBtn(0);
                conLoader1.Visible = true;
                conLoader1.Active = true;

                this.backgroundWorker2 = new BackgroundWorker();
                this.backgroundWorker2.DoWork +=
                delegate(object se, DoWorkEventArgs es)
                {
                    this.backgroundWorker_DoWork2(cPathRoot, cPathAnioMes, dFechaInicio, dFechaFin);
                };

                this.backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;

                this.backgroundWorker2.RunWorkerAsync();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }      
        }
        private void HabilitarBtn(int idHabilitar) 
        {
            if (idHabilitar == 1)
            {
                this.txtBase1.Enabled = true;
                this.conFechaAñoMes1.Enabled = true;

                if (this.lBloqueo.Equals("0"))
                {
                    this.btnGenerar1.Enabled = false;
                    this.btnEnviar1.Enabled = false; 
                }
                else
                {
                    this.btnGenerar1.Enabled = true;
                    this.btnEnviar1.Enabled = true;
                }

                this.btnProcesar1.Enabled = true;
                //this.btnImprimir1.Enabled = true;
                this.btnSalir1.Enabled = true;
            }
            else if (idHabilitar == 0)
            {
                this.txtBase1.Enabled = false;
                this.conFechaAñoMes1.Enabled = false;
                this.btnEnviar1.Enabled = false;
                this.btnGenerar1.Enabled = false;
                this.btnProcesar1.Enabled = false;
                //this.btnImprimir1.Enabled = false;
                this.btnSalir1.Enabled = false;
            }
            else if (idHabilitar == 2)
            {
                this.txtBase1.Enabled = false;
                this.conFechaAñoMes1.Enabled = false;
                this.btnEnviar1.Enabled = false;
                this.btnGenerar1.Enabled = false;
                this.btnProcesar1.Enabled = true;
               // this.btnImprimir1.Enabled = false;
                this.btnSalir1.Enabled = true;
            }

        }
        private void backgroundWorker_DoWork2(string cPathRoot, string cPathAnioMes, DateTime dFechaInicio, DateTime dFechaFin)
        {
            int idCuenta = -1;
            string cNroCuenta = "";
            int idUsuario = clsVarGlobal.User.idUsuario;
            string cNombresCliente = "";

            string cRuta = Path.Combine(cPathRoot, cPathAnioMes);
            string cDireccion = cDirectorioSalida + "\\" + cPathAnioMes + "\\ConSeguridad\\";

            //string cCorreo = "";
            string cAsunto = "Extracto de Cuenta (CRAC LOS ANDES)";
            string cMensaje = "";
            
            nCorrectos = 0;
            nIncorrectos = 0;

            foreach (DataGridViewRow row in this.dtgBase1.Rows)
            {

                idCuenta = Convert.ToInt32(row.Cells["idCuenta"].Value);
                string idAnioMes = Convert.ToString(txtBase1.Text);
                //int idMes = Convert.ToInt32(this.cboMeses1.SelectedValue);
                string cCorreo = Convert.ToString(row.Cells["cDireccionEnvioEstCta"].Value);
                string cNombre = Convert.ToString(row.Cells["cNombre"].Value);


                    DataTable dtExtCtasGenEnv = null;
                    try
                    {   
                        //idcuenta,idaniomes, mes, correo, nombre

                        Thread.Sleep(nTime);

                        DataTable dtEnvioDeCorreos = clsEnvExtCtas.CNEnvioDeCorreos(idCuenta, idAnioMes, nIdMes, cCorreo, cNombre);
                                             
                        if (Convert.ToInt32(dtEnvioDeCorreos.Rows[0]["cError"]) == 1)
                        {
                            
                            dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");

                        }
                        else
                        {
                            dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ERROR DB");
                        }
                        nCorrectos++;
                    }
                    catch (Exception ex)
                    {
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ErrorDB: "+ex.ToString());
                        nIncorrectos++;
                    }
                
            }
        }


        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;

            MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            HabilitarBtn(1);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void exportarExcel(IEnumerable<clsListaEECC> listaEECC)
        {

            DialogResult dialogResult = MessageBox.Show("No podrá cerrar el formulario, mientras se esté GENERANDO el Excel, ¿Está seguro de continuar?",cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xlsx)|*.xlsx";
                fichero.ShowDialog();
                if (fichero.FileName.ToString().Equals(""))
                {
                    return;
                }

                conLoader1.Visible = true;
                conLoader1.Active = true;

                this.btnProcesar1.Enabled = false;
                this.btnSalir1.Enabled = false;
                this.btnExporExcel1.Enabled = false;
                this.conFechaAñoMes1.Enabled = false;

                this.backgroundWorker3 = new BackgroundWorker();
                this.backgroundWorker3.DoWork +=
                delegate(object se, DoWorkEventArgs es)
                {
                    this.backgroundWorker_DoWork3(listaEECC,fichero);
                };

                this.backgroundWorker3.RunWorkerCompleted += backgroundWorker3_RunWorkerCompleted;

                this.backgroundWorker3.RunWorkerAsync();
            }
            else
            {
                return;
            }

        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            dtEECC.Rows.Clear();
            if (dtgBase1.ColumnCount==0)
            {
                MessageBox.Show("No se encontraron datos en la tabla, Procese antes de Exportar.", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }
            DataTable dtEnvExtCtas;
            if (Convert.ToInt32(tabControl1.SelectedIndex) == 0)
            {
                dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 1, Convert.ToInt32(this.txtBase1.Text));
            }
            else
            {
                dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 2, Convert.ToInt32(this.txtBase1.Text));
            }
            
            if (dtEnvExtCtas.Rows.Count > 0)
            {
                List<clsListaEECC> listaEECC = new List<clsListaEECC>();
   
                foreach (DataRow row in dtEnvExtCtas.Rows)
                {
                    clsListaEECC objEECC = new clsListaEECC();
                    int nCorrecto = (String.IsNullOrEmpty(row["lCorrecto"].ToString())) ? 3 : (row["lCorrecto"].ToString().Equals("SI")) ? 1 : 0;
                    objEECC.cNroCuenta = row["cNroCuenta"].ToString();
                    objEECC.cNombre = row["cNombre"].ToString();
                    objEECC.cAnioMes = row["nAnioMes"].ToString();
                    objEECC.cCorreo = row["cDireccionEnvioEstCta"].ToString();
                    objEECC.cEstado = (String.IsNullOrEmpty(row["nTipoGenEnv"].ToString())) ? "" : cEstado(Convert.ToInt32(row["nTipoGenEnv"]), nCorrecto);
                    objEECC.cCorrecto = row["lCorrecto"].ToString();
                    objEECC.dFechaGeneracion = row["dFechaReg"].ToString();
                    objEECC.dFechaModificado = row["dFechaMod"].ToString();
                    objEECC.cNombreAdjunto = (String.IsNullOrEmpty(row["lCorrecto"].ToString())) ? "" : (this.txtBase1.Text.ToString() + "_" + row["idCuenta"].ToString() + "_Secure.pdf");

                    DataRow drfila = dtEECC.NewRow();
                    drfila["cNroCuenta"] = objEECC.cNroCuenta;
                    drfila["Nombre"] = objEECC.cNombre;
                    drfila["AnioMes"] = objEECC.cAnioMes;
                    drfila["Correo"] = objEECC.cCorreo;
                    drfila["Estado"] = objEECC.cEstado;
                    drfila["Correcto"] = objEECC.cCorrecto;
                    drfila["fechaGeneracion"] = (String.IsNullOrEmpty(objEECC.dFechaGeneracion)) ? "01/01/2000 00:00:00" : objEECC.dFechaGeneracion;
                    drfila["Adjunto"] = objEECC.cNombreAdjunto;
                    dtEECC.Rows.Add(drfila);

                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dsListaEnvio", dtEECC));

                string reportpath = "rptExportarListaCorreo.rdlc";


                frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel);
                frmReporte.ShowDialog();

                //exportarExcel(listaEECC);
            }
            else
            {
                MessageBox.Show("No existen datos para Generar los Estados de Cuenta.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        public string cEstado(int nValor)
        {
            string cResultado = "";
            switch (nValor)
            {
                case 1:
                    cResultado = "Documento generado";
                    break;
                case 2:
                    cResultado = "Correo enviado";
                    break;
                case 3:
                    cResultado = "Documento generado y enviado";
                    break;
                case 4:
                    cResultado = "Documento encriptado";
                    break;

                default:
                    cResultado = "";
                    break;
            }
            return cResultado;
        }

        private void backgroundWorker_DoWork3(IEnumerable<clsListaEECC> listaEECC, SaveFileDialog fichero)
        {
            

            var excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "cNroCuenta";
            workSheet.Cells[1, "B"] = "Nombre";
            workSheet.Cells[1, "C"] = "AnioMes";
            workSheet.Cells[1, "D"] = "Correo";
            workSheet.Cells[1, "E"] = "Estado";
            workSheet.Cells[1, "F"] = "Correcto";
            workSheet.Cells[1, "G"] = "FechaGeneracion";
            workSheet.Cells[1, "H"] = "Adjunto";


            workSheet.get_Range("A1", "H1").Interior.Color = System.Drawing.Color.FromArgb(0, 166, 244);
            workSheet.get_Range("A1", "H1").Font.Bold = true;
            workSheet.get_Range("A1", "H1").Font.Color = System.Drawing.Color.FromArgb(255, 255, 255);
            workSheet.get_Range("A2", "A" + (listaEECC.Count() + 2)).NumberFormat = "@";
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

            workSheet.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            //workSheet.cl Close(true);
            excelApp.Quit();
        }
        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            conLoader1.Visible = false;
            conLoader1.Active = false;

            this.btnProcesar1.Enabled = true;
            this.btnSalir1.Enabled = true;
            this.btnExporExcel1.Enabled = true;
            this.conFechaAñoMes1.Enabled = true;
            MessageBox.Show("Exportación de Excel Completada.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            HabilitarBtn(2);
        }
        public string cEstado(int nValor, int nCorrecto = 0)
        {

            string cResultado = "";
            switch (nValor)
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
                    cResultado = "";
                    break;
            }
            return cResultado;
        }
        
    }

}
