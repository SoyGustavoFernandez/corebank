using DEP.CapaNegocio;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmEnvioExtractoCtasADomicilio : frmBase
    {
        clsCNEnvExtCtas clsEnvExtCtas = new clsCNEnvExtCtas();
        string cHtmlPlantilla;
        string cNota;
        int nCorrectos = 0;
        int nIncorrectos = 0;

        public frmEnvioExtractoCtasADomicilio()
        {
            InitializeComponent();
        }

        private void frmEnvioExtractoCtasADomicilio_Load(object sender, EventArgs e)
        {
            this.txtNomGen.Enabled = false;
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.txtDirectorioCliente.Enabled = false;
            this.txtDirectorioServidor.Enabled = false;
            this.conLoader.Visible = false;
            this.conLoader.Active = false;
        }

        private void obtenerListaEnvioExtractoCtasGenerados()
        {
            DataTable dtEnvExtCtas = clsEnvExtCtas.CNListEnvExtCtasCorreo(1, 3, Convert.ToInt32(this.txtNomGen.Text));
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
                MessageBox.Show("No existen datos para el reporte", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.dtpFechaInicio.Value >= this.dtpFechaFin.Value)
            {
                MessageBox.Show("Seleccione un rango de fechas correcto antes de continuar", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.txtNomGen.Text = this.dtpFechaFin.Value.ToString("yyyyMM");
            this.obtenerListaEnvioExtractoCtasGenerados();
        }        

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.dtpFechaInicio.Value >= this.dtpFechaFin.Value)
            {
                MessageBox.Show("Seleccione un rango de fechas correcto antes de continuar", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!this.algunSeleccionado(this.dtgExtCtaGen, "lCheck_gen"))
            {
                MessageBox.Show("Seleccione por lo menos un extracto de cuenta a generar antes de continuar", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de generar los extractos de cuenta seleccionados?", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                    MessageBox.Show("No seleccionó una direccion correcta", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnActGenerados_Click(object sender, EventArgs e)
        {
            if (this.txtNomGen.Text.Trim() == "")
	        {
                MessageBox.Show("Consulte un periodo valido antes de continuar", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
	        }
                        
            this.obtenerListaEnvioExtractoCtasGenerados();
            this.chcTodosGen.CheckedChanged -= new System.EventHandler(this.chcTodosGen_CheckedChanged);
            this.chcTodosGen.Checked = false;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);

            this.chcCorrectoGen.CheckedChanged -= new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            this.chcCorrectoGen.Checked = false;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
        }

        private void backgroundWorker_DoWork1(string cPathRoot, string cPathAnioMes, DateTime dFechaInicio, DateTime dFechaFin)
        {
            string reportpath = "rptExtractoCtaDetallado.rdlc";
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
                    paramlist.Add(new ReportParameter("idCuenta", idCuenta.ToString(), false));
                    paramlist.Add(new ReportParameter("dFecProc", clsVarGlobal.dFecSystem.ToShortDateString(), false));
                    paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsDatosGenCta", dtRpt1));
                    dtslist.Add(new ReportDataSource("dsExtractoCta", dtRpt2));

                    DataTable dtExtCtasGenEnv = null;
                    try
                    {                       
                        new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cRuta, cNroCuenta);
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(1, 3, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                        nCorrectos++;
                    }
                    catch (Exception ex)
                    {
                        dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(1, 3, idCuenta, idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                        nIncorrectos++;
                    }
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            this.habilitarControles(true);

            this.obtenerListaEnvioExtractoCtasGenerados();            

            this.chcTodosGen.CheckedChanged -= new System.EventHandler(this.chcTodosGen_CheckedChanged);
            this.chcTodosGen.Checked = false;
            this.chcTodosGen.CheckedChanged += new System.EventHandler(this.chcTodosGen_CheckedChanged);

            this.chcCorrectoGen.CheckedChanged -= new System.EventHandler(this.chcCorrectoGen_CheckedChanged);
            this.chcCorrectoGen.Checked = false;
            this.chcCorrectoGen.CheckedChanged += new System.EventHandler(this.chcCorrectoGen_CheckedChanged);

            MessageBox.Show("Proceso completado... Correctos(" + nCorrectos + ") - Incorrectos(" + nIncorrectos + ")", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chcTodosGen_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgExtCtaGen.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["lCheck_gen"];
                chk.Value = chcTodosGen.Checked;
            }
        }

        private void chcCorrectoGen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dtgExtCtaGen.Rows.Count > 0)
            {
                string cFiltro = chcCorrectoGen.Checked ? "'SI'" : "'SI','NO',''";
                DataTable dtGen = (DataTable)this.dtgExtCtaGen.DataSource;
                dtGen.DefaultView.RowFilter = String.Format("lCorrecto IN({0})", cFiltro);
            }
            else
            {
                this.obtenerListaEnvioExtractoCtasGenerados();
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

        private void habilitarControles(bool lEnabled)
        {
            this.btnAceptar.Enabled = lEnabled;
            this.txtNomGen.Enabled = lEnabled;
            this.dtpFechaInicio.Enabled = lEnabled;
            this.dtpFechaFin.Enabled = lEnabled;
            this.dtgExtCtaGen.Enabled = lEnabled;            
            this.btnGenerar.Enabled = lEnabled;
            this.btnActGenerados.Enabled = lEnabled;            
            this.btnCargarFile.Enabled = lEnabled;
            this.btnSalir.Enabled = lEnabled;
            this.chcTodosGen.Enabled = lEnabled;
            this.chcCorrectoGen.Enabled = lEnabled;
        }

        private void btnCargarFile_Click(object sender, EventArgs e)
        {
            if (this.txtDirectorioCliente.Text.Trim() == "")
            {
                MessageBox.Show("Genere por lo menos un extracto de cuenta antes de continuar", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de cargar los extractos de cuenta seleccionados?", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                    MessageBox.Show("No seleccionó una direccion correcta", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void backgroundWorker_DoWork3(string rutaOrigen, string rutaDestino)
        {
            this.CopyFolder(rutaOrigen, rutaDestino);
        }

        private void backgroundWorker_RunWorkerCompleted3(object sender, RunWorkerCompletedEventArgs e)
        {
            this.conLoader.Visible = false;
            this.conLoader.Active = false;

            this.habilitarControles(true);

            MessageBox.Show("Proceso completado", "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.ToString(), "Envío de Extractos de Cuentas a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
