using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmReporteLocal : frmBase
    {
        #region Variables Globales

        clsCNFormulario objform = new clsCNFormulario();
        clslisControl controles = new clslisControl();
        List<ReportDataSource> dts;
        List<ReportParameter> param;
        String ReportPath;
        bool lGenArcDirecto = false;
        string NombreArchivo = "";
        string PathArchivo = "";
        bool lImpDirecta = false;
        int m_currentPageIndex;
        IList<Stream> m_streams = new List<Stream>();
        enuFormatoReporte extensioExpArc = enuFormatoReporte.Ninguno;
        Warning[] warnings;
        string[] streamids;
        string mimeType, encoding, extension;
        SaveFileDialog savedialogo = new SaveFileDialog();
        public bool lEsExpedienteVirtual2 = false;
        private bool lHorizontal = false;
        public PrintDocument printDoc = new PrintDocument();
        bool lGeneraBinario = false;
        enuFormatoReporte formatoBinario = enuFormatoReporte.Ninguno;
        byte[] lBinario = null;

        #endregion

        /// <summary>
        /// Muestra Reporte sin parametros
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            InitializeComponent();
            this.Name = ReportPath;
        }

        /// <summary>
        /// Muestra Reporte con parametros
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            InitializeComponent();
            this.Name = ReportPath;
        }

        /// <summary>
        /// Muestra Reporte con parametros
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        /// <param name="x_lGeneraBinario">se debe generar un resultado binario del reporte?</param>
        /// <param name="x_formatoBinario">formato del binario generado</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter, bool x_lGeneraBinario, enuFormatoReporte x_formatoBinario)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            InitializeComponent();
            this.Name = ReportPath;
            lGeneraBinario = x_lGeneraBinario;
            if (lGeneraBinario)
            {
                formatoBinario = x_formatoBinario;
                this.frmReporteLocal_Load(null, null);
            }
        }

        /// <summary>
        /// Realiza el envio directo de impresion del reporte
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        /// <param name="x_lIndImpDir">true => impresion directa</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter, bool x_lIndImpDir)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            lImpDirecta = x_lIndImpDir;
            InitializeComponent();
            this.Name = ReportPath;

        }

        /// <summary>
        /// Realiza el envio directo de impresion del reporte
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        /// <param name="x_lIndImpDir">true => impresion directa</param>
        /// <param name="lHorizontal_">true => impresion en Horizontal</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter, bool x_lIndImpDir, bool lHorizontal_)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            lImpDirecta = x_lIndImpDir;
            lHorizontal = lHorizontal_;
            InitializeComponent();
            this.Name = ReportPath;

        }

        /// <summary>
        /// Exporta el reporte a un archivo excel,word,pdf,imagen
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        /// <param name="x_extension">usar la enumeracion "enuFormatoReporte"</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter, enuFormatoReporte x_extension)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            lImpDirecta = false;
            extensioExpArc = x_extension;
            InitializeComponent();
            this.Name = ReportPath;

        }

        /// <summary>
        /// Exporta el reporte a un archivo excel,word,pdf,imagen sin mostrar dialogo y con un nombre predefinido
        /// </summary>
        /// <param name="x_dts">Coleccion de Datasource (ReportDataSource)</param>
        /// <param name="x_ReportPath">Nombre del reporte (.rdlc)</param>
        /// <param name="x_Parameter">coleccion de parametros (ReportParameter)</param>
        /// <param name="x_extension">usar la enumeracion "enuFormatoReporte"</param>
        public frmReporteLocal(List<ReportDataSource> x_dts, String x_ReportPath, List<ReportParameter> x_Parameter, enuFormatoReporte x_extension, string cPath, string cArchivo)
        {
            dts = x_dts;
            ReportPath = x_ReportPath;
            param = x_Parameter;
            lGenArcDirecto = true;
            lImpDirecta = false;
            extensioExpArc = x_extension;
            InitializeComponent();
            this.Name = ReportPath;
            this.PathArchivo = cPath;
            this.NombreArchivo = cArchivo;
            this.frmReporteLocal_Load(null, null);            
        }

        private void frmReporteLocal_Load(object sender, EventArgs e)
        {
            if (lImpDirecta)
                this.WindowState = FormWindowState.Minimized;
            else if (extensioExpArc != enuFormatoReporte.Ninguno)
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Normal;
            }
            else if (!lEsExpedienteVirtual2)
            {
                    this.WindowState = FormWindowState.Maximized;    
            }

            //this.Visible = (lImpDirecta==false? true : false);
            this.rpvReporteLocal.ProcessingMode = ProcessingMode.Local;
            this.rpvReporteLocal.LocalReport.EnableExternalImages = true;
            //this.reportViewer1.LocalReport.ReportPath = clsVarGlobal.cRutPathApp + @"\" + ReportPath;

            Assembly assembly = Assembly.LoadFrom("RPT.Presentacion.dll");
            Stream stream = assembly.GetManifestResourceStream("RPT.Presentacion." + ReportPath);
            rpvReporteLocal.LocalReport.LoadReportDefinition(stream);

            ReportDataSource dtsunico = new ReportDataSource();
            if (param != null)
            {
                this.rpvReporteLocal.LocalReport.SetParameters(param);
            }
            for (int i = 0; i < dts.Count(); i++)
            {
                dtsunico.Name = dts[i].Name;
                dtsunico.Value = dts[i].Value;
                this.rpvReporteLocal.LocalReport.DataSources.Add(new ReportDataSource(dtsunico.Name, dtsunico.Value));
            }
            
            if (lImpDirecta)
            {
                imprimirReporte();
            }
            else if (extensioExpArc!= enuFormatoReporte.Ninguno)
            {
                if (this.lGenArcDirecto == true)
                {
                    exportarArchivo(this.PathArchivo , this.NombreArchivo);
                }
                else
                {
                    exportarArchivo();
                }    
                this.Close();
            }
            else
            {                
                validarPermisos(ReportPath);
                if (lGeneraBinario)
                {
                    lBinario = exportarBinario();
                }
                else
                {
                    this.rpvReporteLocal.RefreshReport();
                }
            }

            if (lEsExpedienteVirtual2)
            {
                this.Dock = DockStyle.Fill;
            }
            
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void imprimirReporte()
        {
            string deviceInfo = @"<DeviceInfo>
                                    <OutputFormat>EMF</OutputFormat>
                                    <PageWidth>8.5in</PageWidth>
                                    <PageHeight>11in</PageHeight>
                                    <MarginTop>0.59in</MarginTop>
                                    <MarginLeft>0.59in</MarginLeft>
                                    <MarginRight>0.59in</MarginRight>
                                    <MarginBottom>0.59in</MarginBottom>
                                </DeviceInfo>";
            if (lHorizontal)
            {
                deviceInfo = @"<DeviceInfo>
                                   <OutputFormat>EMF</OutputFormat>
                                   <PageWidth>11.69in</PageWidth>
                                   <PageHeight>8.27in</PageHeight>
                                   <MarginTop>0.3937in</MarginTop>
                                   <MarginLeft>0.07874in</MarginLeft>
                                   <MarginRight>0.07874in</MarginRight>
                                   <MarginBottom>0.3937in</MarginBottom>
                                </DeviceInfo>";
            }

            Warning[] warnings;
            rpvReporteLocal.LocalReport.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream x in m_streams)
                x.Position = 0;

            if (m_streams == null || m_streams.Count == 0)
            {
                throw new Exception("Error: no stream to print.");
            }

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: No se puede encontrar Impresora por Defecto.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
                this.Dispose();
            }
        }

        private void validarPermisos(string cReporte)
        {
            int idPerfil = clsVarGlobal.User.idUsuario;
            EventoFormulario idEvento= EventoFormulario.INICIO;

            controles.Clear();
            controles.Add(new clsControl() { cControl = "btnImprimir" });
            controles.Add(new clsControl() { cControl = "btnExportar" });

            clslisControl liscontrolesperfil = objform.listarcontrolesByPerfil(cReporte, clsVarGlobal.PerfilUsu.idPerfil, (int)idEvento);
            habilitar(liscontrolesperfil);

        }

        private void habilitar(clslisControl controlesperfil)
        {            
            var lista = (from x in controlesperfil
                         join y in controles
                         on x.cControl equals y.cControl
                         select new { y.control, x });

            foreach (var item in lista)
            {
                if (item.x.cControl == "btnExportar")
                {
                    switch (item.x.idEstado)
                    {

                        case 1:
                            rpvReporteLocal.ShowExportButton = false;

                            break;
                        case 2:
                            rpvReporteLocal.ShowExportButton = true;
                            break;
                    }
                }

                if (item.x.cControl == "btnImprimir")
                {
                    switch (item.x.idEstado)
                    {

                        case 1:
                            rpvReporteLocal.ShowPrintButton = false;

                            break;
                        case 2:
                            rpvReporteLocal.ShowPrintButton = true;
                            break;
                    }
                }
                

            }
        }

        private void exportarArchivo()
        {
            byte[] bytes = null;

            var cNombreXDefecto = ReportPath.Split('.')[0] + "_" + DateTime.Now.Date.ToString("dd_MM_yyy");

            switch (extensioExpArc)
            {
                case enuFormatoReporte.Excel:
                    bytes = rpvReporteLocal.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    savedialogo.Filter = "Archivo Excel|*.xlsx;*.xls";
                    savedialogo.Title = "Exportar Reporte a Excel";
                    
                    break;
                case enuFormatoReporte.Word:
                    bytes = rpvReporteLocal.LocalReport.Render("Word", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    savedialogo.Filter = "Archivo Word|*.doc";
                    savedialogo.Title = "Exportar Reporte a Word";
                    break;
                case enuFormatoReporte.Pdf:
                    bytes = rpvReporteLocal.LocalReport.Render("PDF", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    savedialogo.Filter = "Archivo Pdf|*.pdf";
                    savedialogo.Title = "Exportar Reporte a Pdf";
                    break;
                case enuFormatoReporte.Imagen:
                    bytes = rpvReporteLocal.LocalReport.Render("Image", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    savedialogo.Filter = "Archivo Imagen|*.jpg";
                    savedialogo.Title = "Exportar Reporte a Imagen";
                    break;
                default:
                    break;
            }
            savedialogo.FileName = cNombreXDefecto;

            var result=savedialogo.ShowDialog();

            if (result== System.Windows.Forms.DialogResult.OK)
            {
                if (savedialogo.FileName!="")
                {
                    FileStream fs = new FileStream(savedialogo.FileName,FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("No seleccionó un nombre al archivo vuelva aintentarlo", "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
            }
        }

        private void exportarArchivo(string cPath, string cArchivo)
        {
            byte[] bytes = null;
            string cExtension = "";
            System.IO.Directory.CreateDirectory(cPath);
            //var cNombreXDefecto = ReportPath.Split('.')[0] + "_" + DateTime.Now.Date.ToString("dd_MM_yyy");

            switch (extensioExpArc)
            {
                case enuFormatoReporte.Excel:
                    bytes = rpvReporteLocal.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    //savedialogo.Filter = "Archivo Excel|*.xls";
                    //savedialogo.Title = "Exportar Reporte a Excel";
                    cExtension=".xlsx";
                    break;
                case enuFormatoReporte.Word:
                    bytes = rpvReporteLocal.LocalReport.Render("Word", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    //savedialogo.Filter = "Archivo Word|*.doc";
                    //savedialogo.Title = "Exportar Reporte a Word";
                    cExtension = ".doc";
                    break;
                case enuFormatoReporte.Pdf:
                    bytes = rpvReporteLocal.LocalReport.Render("PDF", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    //savedialogo.Filter = "Archivo Pdf|*.pdf";
                    //savedialogo.Title = "Exportar Reporte a Pdf";
                    cExtension = ".pdf";
                    break;
                case enuFormatoReporte.Imagen:
                    bytes = rpvReporteLocal.LocalReport.Render("Image", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    //savedialogo.Filter = "Archivo Imagen|*.jpg";
                    //savedialogo.Title = "Exportar Reporte a Imagen";
                    cExtension = ".img";
                    break;
                default:
                    break;
            }
            //savedialogo.FileName = cArchivo;

            FileStream fs = new FileStream(Path.Combine(cPath, cArchivo + cExtension), FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
        }

        private byte[] exportarBinario()
        {
            byte[] bytes = null;

            switch (formatoBinario)
            {
                case enuFormatoReporte.Excel:
                    bytes = rpvReporteLocal.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    break;
                case enuFormatoReporte.Word:
                    bytes = rpvReporteLocal.LocalReport.Render("Word", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    break;
                case enuFormatoReporte.Pdf:
                    bytes = rpvReporteLocal.LocalReport.Render("PDF", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    break;
                case enuFormatoReporte.Imagen:
                    bytes = rpvReporteLocal.LocalReport.Render("Image", null, out mimeType, out encoding,
                                                            out extension, out streamids, out warnings);
                    break;
                default:
                    break;
            }
            return bytes;
        }

        public byte[] obtenerBinario()
        {
            return lBinario;
        }
    }
}
