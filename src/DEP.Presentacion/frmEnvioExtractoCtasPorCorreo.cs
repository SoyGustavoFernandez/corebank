using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmEnvioExtractoCtasPorCorreo : frmBase
    {
        clsCNEnvExtCtas clsEnvExtCtas = new clsCNEnvExtCtas();
        DataTable dtExtCtasGen = new DataTable();
        DataTable dtExtCtasEnv = new DataTable();
        string cHtmlPlantilla;
        string cNota;
        int nCorrectos = 0;
        int nIncorrectos = 0;        

        public frmEnvioExtractoCtasPorCorreo()
        {
            InitializeComponent();
        }

        private void frmEnvioExtractoCtasPorCorreo_Load(object sender, EventArgs e)
        {
            this.txtNomGen.Enabled = false;
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.txtDirectorioCliente.Enabled = false;
            this.txtDirectorioServidor.Enabled = false;
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            DataTable dtHtmlPlanExtCtasCor = clsEnvExtCtas.CNObtenerHtmlPlanExtCtaCorreo();
            if (dtHtmlPlanExtCtasCor.Rows.Count > 0)
            {
                this.cHtmlPlantilla = Convert.ToString(dtHtmlPlanExtCtasCor.Rows[0]["cHtmlPlan"]);
                this.cNota = Convert.ToString(dtHtmlPlanExtCtasCor.Rows[0]["cNota"]);
            }
            else
            {
                MessageBox.Show("No se encuentra la plantilla html para el envío de correo", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }        

        private void obtenerListaEnvioExtractoCtasGenerados() 
        {
            DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 1, Convert.ToInt32(this.txtNomGen.Text));
            if (dtEnvExtCtas.Rows.Count > 0)
            {
                dtEnvExtCtas.Columns["lCheck"].ReadOnly = false;

                this.dtgExtCtaGen.DataSource = dtEnvExtCtas;
                this.dtgExtCtaGen.Refresh();

                this.dtgExtCtaGen.ReadOnly = false;  
                this.dtgExtCtaGen.Columns["Row_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["idEnvExtCtas_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["idCuenta_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["cNroCuenta_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["nAnioMes_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["cDireccionEnvioEstCta_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["cPath_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["lCorrecto_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["cMsgError_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["dFechaReg_gen"].ReadOnly = true;
                this.dtgExtCtaGen.Columns["dFechaMod_gen"].ReadOnly = true;                                
            }
            else
            {
                MessageBox.Show("No existen datos para el reporte", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void obtenerListaEnvioExtractoCtasEnviados()
        {            
            DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(2, 2, Convert.ToInt32(this.txtNomGen.Text));
            if (dtEnvExtCtas.Rows.Count > 0)
            {
                dtEnvExtCtas.Columns["lCheck"].ReadOnly = false;

                this.dtgExtCtaEnv.DataSource = dtEnvExtCtas;
                this.dtgExtCtaEnv.Refresh();

                this.dtgExtCtaEnv.ReadOnly = false;
                this.dtgExtCtaEnv.Columns["Row_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["idEnvExtCtas_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["idCuenta_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["cNroCuenta_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["nAnioMes_env"].ReadOnly = true;
                //this.dtgExtCtaGen.Columns["cDirecEnvEstCta_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["cPath_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["lCorrecto_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["cMsgError_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["dFechaReg_env"].ReadOnly = true;
                this.dtgExtCtaEnv.Columns["dFechaMod_env"].ReadOnly = true;                
            }
            else
            {
                MessageBox.Show("No existen datos para el reporte", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }        

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.dtpFechaInicio.Value >= this.dtpFechaFin.Value)
            {
                MessageBox.Show("Seleccione un rango de fechas correcto antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!this.algunSeleccionado(this.dtgExtCtaGen, "lCheck_gen"))
	        {
                MessageBox.Show("Seleccione por lo menos un extracto de cuenta a generar antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
	        }            
                                    
            string cPathRoot = "";
            string cPathAnioMes = this.txtNomGen.Text;            
            
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;

            FolderBrowserDialog savedialogo = new FolderBrowserDialog();
            var result = savedialogo.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (savedialogo.SelectedPath != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de generar los extractos de cuenta seleccionados?", "Envío de extractos de cuentas por Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cPathRoot = savedialogo.SelectedPath;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó una direccion correcta", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                return;
            }
            
            conLoader.Visible = true;
            conLoader.Active = true;

            this.habilitarControles(false);
            this.txtDirectorioCliente.Text = savedialogo.SelectedPath;
            this.dtgExtCtaGen.CurrentCell = null;

            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork +=
            delegate(object se, DoWorkEventArgs es)
            {
                this.backgroundWorker_DoWork1(cPathRoot, cPathAnioMes, dFechaInicio, dFechaFin);
            };

            this.backgroundWorker1.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted1;
            
            this.backgroundWorker1.RunWorkerAsync();            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Validar
            if (!this.algunSeleccionado(this.dtgExtCtaEnv, "lCheck_env"))
            {
                MessageBox.Show("Seleccione por lo menos un extracto de cuenta a enviar antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtDirectorioCliente.Text.Trim() == "")
            {
                MessageBox.Show("Se requiere un \"Directorio Cliente\" con extractos de cuentas generados antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de enviar los extractos de cuenta seleccionados?", "Envío de extractos de cuentas por Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                clsCNServicioCorreo obj = new clsCNServicioCorreo();

                DateTime dFechaInicio = this.dtpFechaInicio.Value;
                DateTime dFechaFin = this.dtpFechaFin.Value;
                int idUsuario = clsVarGlobal.User.idUsuario;

                string cPathRoot = this.txtDirectorioCliente.Text;
                string cPathAnioMes = this.txtNomGen.Text;
                string cRuta = Path.Combine(cPathRoot, cPathAnioMes);

                conLoader.Visible = true;
                conLoader.Active = true;

                this.habilitarControles(false);
                this.dtgExtCtaGen.CurrentCell = null;

                this.backgroundWorker2 = new BackgroundWorker();
                this.backgroundWorker2.DoWork +=
                delegate(object se, DoWorkEventArgs es)
                {
                    this.backgroundWorker_DoWork2(cPathRoot, cPathAnioMes, dFechaInicio, dFechaFin);
                };

                this.backgroundWorker2.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted2;

                this.backgroundWorker2.RunWorkerAsync();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }                               
        }

        private void btnCargarFile_Click(object sender, EventArgs e)
        {
            if (this.txtDirectorioCliente.Text.Trim() == "")
            {
                MessageBox.Show("Genere por lo menos un extracto de cuenta antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.txtDirectorioServidor.Text = "";
            string rutaOrigen = "";
            string rutaDestino = "";            

            FolderBrowserDialog savedialogo = new FolderBrowserDialog();            

            var result = savedialogo.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (savedialogo.SelectedPath != "" && savedialogo.SelectedPath != this.txtDirectorioCliente.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de cargar los extractos de cuenta seleccionados?", "Envío de extractos de cuentas por Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        rutaDestino = savedialogo.SelectedPath;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó una dirección correcta", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                return;
            }

            rutaOrigen = this.txtDirectorioCliente.Text;
            this.txtDirectorioServidor.Text = rutaDestino;

            conLoader.Visible = true;
            conLoader.Active = true;            

            this.habilitarControles(false);

            this.backgroundWorker3 = new BackgroundWorker();
            this.backgroundWorker3.DoWork +=
            delegate(object se, DoWorkEventArgs es)
            {
                this.backgroundWorker_DoWork3(rutaOrigen, rutaDestino);
            };

            this.backgroundWorker3.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted3;

            this.backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork1(string cPathRoot, string cPathAnioMes, DateTime dFechaInicio, DateTime dFechaFin)
        {
            string reportpath = "rptExtCtaCorreo.rdlc";
            int idCuenta = -1;
            string cNroCuenta = "";
            int idUsuario = clsVarGlobal.User.idUsuario;
            string cRuta = "";
            string cDireccion = "";
            nCorrectos = 0;
            nIncorrectos = 0;

            foreach (DataGridViewRow row in dtgExtCtaGen.Rows)
            {
                if (Convert.ToInt32(row.Cells["lCheck_gen"].Value) == 1)
                {
                    idCuenta = Convert.ToInt32(row.Cells["idCuenta_gen"].Value);
                    cNroCuenta = Convert.ToString(row.Cells["cNroCuenta_gen"].Value);
                    idUsuario = clsVarGlobal.User.idUsuario;
                    cRuta = Path.Combine(cPathRoot, cPathAnioMes);                    
                    cDireccion = Path.Combine(cRuta, cNroCuenta + "." + enuFormatoReporte.Pdf);

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

                    DataTable dtExtCtasGenEnv = null;
                    try
                    {
                        new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cRuta, cNroCuenta);
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                        nCorrectos++;
                    }
                    catch (Exception ex)
                    {
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                        nIncorrectos++;
                    }
                }
            }
        }

        private void backgroundWorker_DoWork2(string cPathRoot, string cPathAnioMes, DateTime dFechaInicio, DateTime dFechaFin)
        {
            clsCNServicioCorreo obj = new clsCNServicioCorreo();            

            int idCuenta = -1;
            string cNroCuenta = "";
            int idUsuario = clsVarGlobal.User.idUsuario;
            string cNombresCliente = "";

            string cRuta = Path.Combine(cPathRoot, cPathAnioMes);
            string cDireccion = "";

            string cCorreo = "";
            string cAsunto = "Extracto de Cuenta (CRAC LOS ANDES)";
            string cMensaje = "";
            nCorrectos = 0;
            nIncorrectos = 0;

            foreach (DataGridViewRow row in this.dtgExtCtaEnv.Rows)
            {
                if (Convert.ToInt32(row.Cells["lCheck_env"].Value) == 1)
                {
                    idCuenta = Convert.ToInt32(row.Cells["idCuenta_env"].Value);
                    cNroCuenta = Convert.ToString(row.Cells["cNroCuenta_env"].Value);
                    cDireccion = Path.Combine(cRuta, cNroCuenta + "." + enuFormatoReporte.Pdf);
                    cNombresCliente = Convert.ToString(row.Cells["cNombre_env"].Value);
                    cCorreo = Convert.ToString(row.Cells["cDirecEnvEstCta_env"].Value);

                    List<string> cDestinoCorreo = new List<string>();                    
                    cDestinoCorreo.Add(cCorreo); //Cambiar correo para pruebas
                                        
                    List<string> cAdjunto = new List<string>();

                    if (File.Exists(cDireccion))
                    {
                        cAdjunto.Add(cDireccion);
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra el extracto de cuenta generado", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cMensaje = this.cHtmlPlantilla;
                    cMensaje = cMensaje.Replace("$varCliente", cNombresCliente);
                    cMensaje = cMensaje.Replace("$varCorreo", cCorreo);
                       
                    DataTable dtExtCtasGenEnv = null;                    
                    try
                    {
                        if (obj.enviarMensaje(cDestinoCorreo, cAsunto, cMensaje, cAdjunto))
                        {
                            dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                        }
                        else
                        {
                            dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ERROR");
                        }
                        nCorrectos++;
                    }
                    catch (Exception ex)
                    {
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                        nIncorrectos++;
                    }   
                }              
            }
        }

        private void backgroundWorker_DoWork3(string rutaOrigen, string rutaDestino)
        {            
            this.CopyFolder(rutaOrigen, rutaDestino);
        }

        private void backgroundWorker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            this.habilitarControles(true);

            this.obtenerListaEnvioExtractoCtasGenerados();            
            this.btn_Vincular_Click(sender, e);

            this.chcTodosGen.CheckedChanged -= new System.EventHandler(this.chcTodosGen_CheckedChanged);
            this.chcTodosGen.Checked = false;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);

            this.chcCorrectoGen.CheckedChanged -= new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            this.chcCorrectoGen.Checked = false;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);

            MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            this.habilitarControles(true);

            this.btn_Vincular_Click(sender, e);

            this.chcTodosEnv.CheckedChanged -= new System.EventHandler(this.chcTodosEnv_CheckedChanged);
            this.chcTodosEnv.Checked = false;
            this.chcTodosEnv.CheckedChanged += new System.EventHandler(this.chcTodosEnv_CheckedChanged);

            this.chcCorrectoEnv.CheckedChanged -= new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);
            this.chcCorrectoEnv.Checked = false;
            this.chcCorrectoEnv.CheckedChanged += new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);

            MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker_RunWorkerCompleted3(object sender, RunWorkerCompletedEventArgs e)
        {
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            this.habilitarControles(true);

            MessageBox.Show("Proceso completado", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest, true);
                }
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void habilitarControles(bool lEnabled)
        {
            this.btnAceptar.Enabled = lEnabled;
            this.txtNomGen.Enabled = lEnabled;
            this.dtpFechaInicio.Enabled = lEnabled;
            this.dtpFechaFin.Enabled = lEnabled;
            this.dtgExtCtaGen.Enabled = lEnabled;
            this.dtgExtCtaEnv.Enabled = lEnabled;
            this.btnGenerar.Enabled = lEnabled;
            this.btnActGenerados.Enabled = lEnabled;
            this.btnEnviar.Enabled = lEnabled;
            //this.btnActEnviados.Enabled = lEnabled;
            this.btnCargarFile.Enabled = lEnabled;
            this.btnSalir.Enabled = lEnabled;
            this.chcTodosGen.Enabled = lEnabled;
            this.chcCorrectoGen.Enabled = lEnabled;
            this.chcTodosEnv.Enabled = lEnabled;
            this.chcCorrectoEnv.Enabled = lEnabled;
        }

        private void btnActGenerados_Click(object sender, EventArgs e)
        {
            this.obtenerListaEnvioExtractoCtasGenerados();
            this.chcTodosGen.CheckedChanged -= new System.EventHandler(this.chcTodosGen_CheckedChanged);
            this.chcTodosGen.Checked = false;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);

            this.chcCorrectoGen.CheckedChanged -= new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            this.chcCorrectoGen.Checked = false;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
        }

        private void btnActEnviados_Click(object sender, EventArgs e)
        {
            this.obtenerListaEnvioExtractoCtasEnviados();
            this.chcTodosEnv.CheckedChanged -= new System.EventHandler(this.chcTodosEnv_CheckedChanged);
            this.chcTodosEnv.Checked = false;
            this.chcTodosEnv.CheckedChanged += new System.EventHandler(this.chcTodosEnv_CheckedChanged);

            this.chcCorrectoEnv.CheckedChanged -= new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);
            this.chcCorrectoEnv.Checked = false;
            this.chcCorrectoEnv.CheckedChanged += new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);
        }

        private void btn_Vincular_Click(object sender, EventArgs e)
        {
            this.obtenerListaEnvioExtractoCtasEnviados();
            this.chcTodosEnv.CheckedChanged -= new System.EventHandler(this.chcTodosEnv_CheckedChanged);
            this.chcTodosEnv.Checked = false;
            this.chcTodosEnv.CheckedChanged += new System.EventHandler(this.chcTodosEnv_CheckedChanged);

            this.chcCorrectoEnv.CheckedChanged -= new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);
            this.chcCorrectoEnv.Checked = false;
            this.chcCorrectoEnv.CheckedChanged += new System.EventHandler(this.chcCorrectoEnv_CheckedChanged);            

            string cFiltro = "";
            DataTable dtEnv = (DataTable)this.dtgExtCtaEnv.DataSource;            

            foreach(DataGridViewRow row1 in this.dtgExtCtaGen.Rows)
            {
                foreach (DataGridViewRow row2 in this.dtgExtCtaEnv.Rows)
                {
                    if (Convert.ToInt32(row1.Cells["idCuenta_gen"].Value) == Convert.ToInt32(row2.Cells["idCuenta_env"].Value))
                    {
                        if (Convert.ToString(row1.Cells["lCorrecto_gen"].Value) == "SI")
                        {
                            if (!File.Exists(Convert.ToString(row1.Cells["cPath_gen"].Value)))
                            {
                                cFiltro += row1.Cells["idCuenta_gen"].Value + ",";                                
                            }
                        }
                        else
                        {
                            cFiltro += row1.Cells["idCuenta_gen"].Value + ",";                                     
                        }
                    }
                }             
            }

            cFiltro = cFiltro.TrimEnd(',');
            if (cFiltro.Trim() != "")
            {
                dtEnv.DefaultView.RowFilter = String.Format("idCuenta NOT IN({0})", cFiltro);
            }

            foreach (DataGridViewRow row in this.dtgExtCtaEnv.Rows)
            {                
                if (Convert.ToString(row.Cells["lCorrecto_env"].Value) == "SI")
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["lCheck_env"];
                    chk.Value = false;
                    chk.FlatStyle = FlatStyle.Flat;
                    chk.Style.ForeColor = Color.DarkGray;                

                    row.Cells["lCheck_env"].ReadOnly = true;    
                }                
            }

            this.chcTodosEnv.Checked = false;
            this.chcCorrectoEnv.Checked = false;
        }

        private void chcTodosGen_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgExtCtaGen.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["lCheck_gen"];
                chk.Value = chcTodosGen.Checked;                
            }            
        }

        private void chcTodosEnv_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgExtCtaEnv.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["lCheck_env"];
                
                if (chk.FlatStyle != FlatStyle.Flat && chk.Style.ForeColor != Color.DarkGray)
                {
                    chk.Value = chcTodosEnv.Checked;    
                }                
            }
        }

        private bool algunSeleccionado(DataGridView dgvModelo, string key)
        {
            bool lCheckeado = false;
            foreach (DataGridViewRow row in dgvModelo.Rows)
            {
                if (Convert.ToBoolean(row.Cells[key].Value) == true)
                {
                    lCheckeado = true;
                    break;
                }
            }

            return lCheckeado;
        }

        private void chcCorrectoGen_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtGen = (DataTable)this.dtgExtCtaGen.DataSource;

            if (dtGen.Rows.Count > 0)
            {
                string cFiltro = chcCorrectoGen.Checked ? "'SI'" : "'SI','NO',''";    

                dtGen.DefaultView.RowFilter = String.Format("lCorrecto IN({0})", cFiltro);
            }
            else
            {
                this.obtenerListaEnvioExtractoCtasGenerados();
            }
        }

        private void chcCorrectoEnv_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtEnv = (DataTable)this.dtgExtCtaEnv.DataSource;

            if (dtEnv.Rows.Count > 0)
            {
                if (this.chcCorrectoEnv.Checked == true)
                {
                    string cFiltro = chcCorrectoEnv.Checked ? "'SI'" : "'SI','NO',''";

                    dtEnv.DefaultView.RowFilter = String.Format("lCorrecto IN({0})", cFiltro);
                }
                else
                {
                    this.obtenerListaEnvioExtractoCtasEnviados();

                    string cFiltro = "";

                    foreach (DataGridViewRow row1 in this.dtgExtCtaGen.Rows)
                    {
                        foreach (DataGridViewRow row2 in this.dtgExtCtaEnv.Rows)
                        {
                            if (Convert.ToInt32(row1.Cells["idCuenta_gen"].Value) == Convert.ToInt32(row2.Cells["idCuenta_env"].Value))
                            {
                                if (Convert.ToString(row1.Cells["lCorrecto_gen"].Value) == "SI")
                                {
                                    if (!File.Exists(Convert.ToString(row1.Cells["cPath_gen"].Value)))
                                    {
                                        cFiltro += row1.Cells["idCuenta_gen"].Value + ",";
                                    }
                                }
                                else
                                {
                                    cFiltro += row1.Cells["idCuenta_gen"].Value + ",";
                                }
                            }
                        }
                    }

                    cFiltro = cFiltro.TrimEnd(',');
                    if (cFiltro.Trim() != "")
                    {
                        dtEnv.DefaultView.RowFilter = String.Format("idCuenta NOT IN({0})", cFiltro);
                    }
                }

                foreach (DataGridViewRow row in this.dtgExtCtaEnv.Rows)
                {
                    if (Convert.ToString(row.Cells["lCorrecto_env"].Value) == "SI")
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["lCheck_env"];
                        chk.Value = false;
                        chk.FlatStyle = FlatStyle.Flat;
                        chk.Style.ForeColor = Color.DarkGray;

                        row.Cells["lCheck_env"].ReadOnly = true;
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.dtpFechaInicio.Value >= this.dtpFechaFin.Value)
            {
                MessageBox.Show("Seleccione un rango de fechas correcto antes de continuar", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.txtNomGen.Text = this.dtpFechaFin.Value.ToString("yyyyMM");
            this.obtenerListaEnvioExtractoCtasGenerados();
            this.btn_Vincular_Click(sender, e);
            //this.obtenerListaEnvioExtractoCtasEnviados();
        }
    }
}
