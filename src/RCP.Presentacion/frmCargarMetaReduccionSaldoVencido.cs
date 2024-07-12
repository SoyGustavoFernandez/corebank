using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GEN.ControlesBase;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RCP.Presentacion
{
    public partial class frmCargarMetaReduccionSaldoVencido : frmBase
    {
        #region Variables Globales
        private clsCNRecuperacionComision objCNRecuperacionComision;
        private List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencidoArchivo;
        private List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencidoBD;
        private List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencido;
        private BindingSource bsMetaReduccionSaldoVencido;

        private int nAnio;
        private int nMes;
        private string cDireccionRuta;
        private Excel.Application appExcel { get; set; }
        private Excel.Workbook workBookExcel { get; set; }
        private Excel.Worksheet workSheetExcel { get; set; }
        #endregion

        public frmCargarMetaReduccionSaldoVencido()
        {
            InitializeComponent();
            this.inicializarDatos();
        }

        

        #region Metodos
        private void inicializarDatos()
        {
            this.objCNRecuperacionComision = new clsCNRecuperacionComision();

            this.nAnio = clsVarGlobal.dFecSystem.Year;
            this.nMes = clsVarGlobal.dFecSystem.Month;
            this.cDireccionRuta = string.Empty;
            this.lstMetaReduccionSaldoVencidoArchivo = new List<clsMetaReduccionSaldoVencido>();
            this.lstMetaReduccionSaldoVencidoBD = new List<clsMetaReduccionSaldoVencido>();
            this.lstMetaReduccionSaldoVencido = new List<clsMetaReduccionSaldoVencido>();
            this.bsMetaReduccionSaldoVencido = new BindingSource();

            this.bsMetaReduccionSaldoVencido.DataSource = this.lstMetaReduccionSaldoVencido;
            this.dtgMetaReduccionSaldoVencido.DataSource = this.bsMetaReduccionSaldoVencido;

            this.formatearMetaReduccionSaldoVencido();


            this.nudAnio.Value = this.nAnio;
            this.cboMes.SelectedValue = this.nMes;

            this.habilitarControles(clsAcciones.NUEVO);
        }
        private void importarMetasArchivo()
        {
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Office Files|*.xls;*.xlsx";
            objOpenFileDialog.InitialDirectory = @"C:\";
            objOpenFileDialog.Title = "Selección el archivo de carga de metas";

            DialogResult drResultado = objOpenFileDialog.ShowDialog();

            if (drResultado == DialogResult.OK)
            {
                if (objOpenFileDialog.SafeFileName != String.Empty)
                {
                    DialogResult drConsulta = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (drConsulta == DialogResult.Yes)
                    {
                        cDireccionRuta = objOpenFileDialog.FileName;
                        this.txtUbicacionArchivo.Text = cDireccionRuta;
                        this.cargarDatosMetaReduccionSaldoVencido();
                        this.btnImportar.Enabled = false;
                        this.btnGrabar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                    }
                    else
                    {
                        txtUbicacionArchivo.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó un archivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private void cargarDatosMetaReduccionSaldoVencido()
        {
            bool lValor = true;
            appExcel = new Excel.Application();
            workBookExcel = appExcel.Workbooks.Open(cDireccionRuta, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            workSheetExcel = workBookExcel.Worksheets.get_Item(1);
            lstMetaReduccionSaldoVencidoArchivo.Clear();

            int i = 2;

            while (lValor)
            {
                clsMetaReduccionSaldoVencido objMetaReduccionSaldoVencido = new clsMetaReduccionSaldoVencido();
                objMetaReduccionSaldoVencido.idEstablecimiento = Convert.ToInt32((workSheetExcel.Cells[i, 1] as Excel.Range).Value2);
                objMetaReduccionSaldoVencido.cEstablecimiento = Convert.ToString((workSheetExcel.Cells[i, 2] as Excel.Range).Value2);
                objMetaReduccionSaldoVencido.nMonto = Convert.ToInt32((workSheetExcel.Cells[i, 3] as Excel.Range).Value2);
                objMetaReduccionSaldoVencido.dFecha = new DateTime(this.nAnio, this.nMes, DateTime.DaysInMonth(this.nAnio, this.nMes));
                objMetaReduccionSaldoVencido.idEstadoRegistro = EstadoRegistro.Nuevo;

                if (objMetaReduccionSaldoVencido.idEstablecimiento != 0)
                {
                    lstMetaReduccionSaldoVencidoArchivo.Add(objMetaReduccionSaldoVencido);
                }
                else
                {
                    lValor = false;
                }
                i++;
            }

            combinarDatosActualArchivo();

            workBookExcel.Close(false, null, null);
            appExcel.Quit();
            liberarObjeto(workSheetExcel);
            liberarObjeto(workBookExcel);
            liberarObjeto(appExcel);
        }
        private void combinarDatosActualArchivo()
        {
            this.lstMetaReduccionSaldoVencido.Clear();
            if (this.lstMetaReduccionSaldoVencidoBD.Count == 0)
            {
                this.lstMetaReduccionSaldoVencido.AddRange(this.lstMetaReduccionSaldoVencidoArchivo);
            }
            else if (this.lstMetaReduccionSaldoVencidoArchivo.Count == 0)
            {
                this.lstMetaReduccionSaldoVencido.AddRange(this.lstMetaReduccionSaldoVencidoBD);
            }
            else
            {
                List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencidoEditados = this.lstMetaReduccionSaldoVencidoArchivo.Intersect(lstMetaReduccionSaldoVencidoBD, new clsMetaReduccionSaldoVencidoCompareEditado()).ToList();
                List<clsMetaReduccionSaldoVencido> lstMetaReduccionSaldoVencidoNuevos = this.lstMetaReduccionSaldoVencidoArchivo.Except(lstMetaReduccionSaldoVencidoBD, new clsMetaReduccionSaldoVencidoCompareNuevo()).ToList();

                List<clsMetaReduccionSaldoVencido> lstMetaCreditosActualizados = this.lstMetaReduccionSaldoVencidoBD.GroupJoin(lstMetaReduccionSaldoVencidoEditados, k1 => k1.idEstablecimiento, k2 => k2.idEstablecimiento, (k1, k2) => new clsMetaReduccionSaldoVencido
                {

                    idEstablecimiento = (k2.SingleOrDefault() == null) ? k1.idEstablecimiento : k2.SingleOrDefault().idEstablecimiento,
                    cEstablecimiento = k1.cEstablecimiento,
                    nMonto = (k2.SingleOrDefault() == null) ? k1.nMonto : k2.SingleOrDefault().nMonto,
                    dFecha = k1.dFecha,
                    idEstadoRegistro = (k2.SingleOrDefault() == null) ? k1.idEstadoRegistro : EstadoRegistro.Editado,
                }).ToList();
                this.lstMetaReduccionSaldoVencido.AddRange(lstMetaCreditosActualizados);
                this.lstMetaReduccionSaldoVencido.AddRange(lstMetaReduccionSaldoVencidoNuevos);
            }            
            this.bsMetaReduccionSaldoVencido.ResetBindings(false);
            this.dtgMetaReduccionSaldoVencido.Refresh();
            this.formatearModificacion();
        }
        private void listarMetaReduccionSaldoVencido(bool lMensaje = true)
        {
            this.nAnio = Convert.ToInt32(this.nudAnio.Value);
            this.lstMetaReduccionSaldoVencidoBD = this.objCNRecuperacionComision.listarMetaReduccionSaldoVencido(this.nAnio, this.nMes);
            if (this.lstMetaReduccionSaldoVencidoBD.Count > 0)
            {
                this.habilitarControles(clsAcciones.BUSCAR);
            }
            else
            {
                if(lMensaje)MessageBox.Show("No se ha encontrado datos registrados para el mes de " + this.cboMes.Text,"SIN DATOS",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.habilitarControles(clsAcciones.NUEVO);
            }
            this.combinarDatosActualArchivo();
        }
        private void grabarMetaReduccionSaldoVencido()
        {
            DataTable dtResultado =  this.objCNRecuperacionComision.grabarMetaReduccionSaldoVencido(this.lstMetaReduccionSaldoVencido);
            if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Grabado Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.GRABAR);
            }
            else
            {
                MessageBox.Show("" + dtResultado.Rows[0]["cMensaje"].ToString(), "Error de Grabado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void formatearMetaReduccionSaldoVencido()
        {
            foreach (DataGridViewColumn dtgColumn in this.dtgMetaReduccionSaldoVencido.Columns)
            {
                dtgColumn.Visible = false;
                dtgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dtgMetaReduccionSaldoVencido.Columns["idEstablecimiento"].Visible = true;
            this.dtgMetaReduccionSaldoVencido.Columns["cEstablecimiento"].Visible = true;
            this.dtgMetaReduccionSaldoVencido.Columns["nMonto"].Visible = true;

            this.dtgMetaReduccionSaldoVencido.Columns["idEstablecimiento"].HeaderText = "Código";
            this.dtgMetaReduccionSaldoVencido.Columns["cEstablecimiento"].HeaderText = "Establecimiento";
            this.dtgMetaReduccionSaldoVencido.Columns["nMonto"].HeaderText = "Monto Meta";

        }
        public void formatearModificacion()
        {
            foreach (DataGridViewRow dtgColumn in dtgMetaReduccionSaldoVencido.Rows)
            {
                clsMetaReduccionSaldoVencido objMeta = (clsMetaReduccionSaldoVencido)dtgColumn.DataBoundItem;

                if (objMeta.idEstadoRegistro == EstadoRegistro.Editado)
                {
                    dtgColumn.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (objMeta.idEstadoRegistro == EstadoRegistro.Nuevo)
                {
                    dtgColumn.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
        private void limpiar()
        {
            this.lstMetaReduccionSaldoVencido.Clear();
            this.lstMetaReduccionSaldoVencidoArchivo.Clear();
            this.lstMetaReduccionSaldoVencidoBD.Clear();

            this.bsMetaReduccionSaldoVencido.ResetBindings(false);
            this.dtgMetaReduccionSaldoVencido.Refresh();

            this.txtUbicacionArchivo.Text = string.Empty;
            this.nMes = clsVarGlobal.dFecSystem.Month;
            this.cboMes.SelectedValue = this.nMes;
        }
        private void habilitarControles(int nAccion)
        {
            switch (nAccion)
            {
                case clsAcciones.NUEVO:
                    this.btnImportar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    break;
                case clsAcciones.GRABAR:
                    this.nudAnio.Enabled = false;
                    this.cboMes.Enabled = false;

                    this.btnGrabar.Enabled = false;
                    this.btnImportar.Enabled = false;
                    break;
                case clsAcciones.CANCELAR:
                    this.nudAnio.Enabled = true;
                    this.cboMes.Enabled = true;

                    this.btnMiniBusq.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnImportar.Enabled = true;
                    break;
                case clsAcciones.BUSCAR:
                    this.nudAnio.Enabled = false;
                    this.cboMes.Enabled = false;

                    this.btnMiniBusq.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnImportar.Enabled = true;
                    break;
            }
        }
        private void liberarObjeto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = getIDProcess("EXCEL");

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
        private int getIDProcess(string nameProcess)
        {
            try
            {
                System.Diagnostics.Process[] asProcess = System.Diagnostics.Process.GetProcessesByName(nameProcess);
                foreach (System.Diagnostics.Process pProcess in asProcess)
                {
                    if (pProcess.MainWindowTitle == "")
                        return pProcess.Id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        private void imprimirFormato()
        {
            DataTable dtEstablecimiento = (new clsCNRecuperador()).listarRegionAgenciaEstabs(0);

            if (dtEstablecimiento.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("DSEstablecimiento", dtEstablecimiento));

                List<ReportParameter> paramList = new List<ReportParameter>();


                string reportPath = "RptFormatoMetaReducSaldoVencido.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region dtEstablecimiento
        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            this.listarMetaReduccionSaldoVencido();
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.listarMetaReduccionSaldoVencido(false);
            this.importarMetasArchivo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.grabarMetaReduccionSaldoVencido();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitarControles(clsAcciones.CANCELAR);
        }
        private void btnDescargar_Click(object sender, EventArgs e)
        {
            this.imprimirFormato();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboMes.SelectedIndex < 0) return;
            this.nMes = Convert.ToInt32(this.cboMes.SelectedValue);
            this.habilitarControles(clsAcciones.NUEVO);
        }
        #endregion        
    }
}
