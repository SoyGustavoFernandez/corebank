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
using System.Drawing.Printing;
using System.Drawing.Imaging;


namespace GEN.ControlesBase
{
    public partial class frmReporte : Form
    {
        #region Variables

        List<ReportParameter> Parameters;
        String ReportPath;
        bool lImpDirecta = false;
        private int m_currentPageIndex;
        IList<Stream> m_streams = new List<Stream>();
        #endregion

        #region Constructor

        public frmReporte()
        {
            InitializeComponent();
        }

        public frmReporte(List<ReportParameter> x_Parameter, String x_ReportPath)
        {
            Parameters = x_Parameter;
            ReportPath = x_ReportPath;
            InitializeComponent();
        }
        public frmReporte(List<ReportParameter> x_Parameter, String x_ReportPath, bool x_lImpDirecta)
        {
            Parameters = x_Parameter;
            ReportPath = x_ReportPath;
            lImpDirecta = x_lImpDirecta;
            InitializeComponent();
        }
        #endregion

        private void frmReporte_Load(object sender, EventArgs e)
        {
            this.WindowState = (lImpDirecta == false ? FormWindowState.Maximized : FormWindowState.Minimized);
            this.reportViewer1.ProcessingMode = ProcessingMode.Remote;
            this.reportViewer1.ServerReport.ReportServerUrl = new Uri(clsVarGlobal.cURLReport);
            this.reportViewer1.ServerReport.ReportPath = ReportPath;
            this.reportViewer1.ServerReport.SetParameters(Parameters);

            if (lImpDirecta)
            {
                this.reportViewer1.ProcessingMode = ProcessingMode.Remote;
                this.reportViewer1.ServerReport.ReportServerUrl = new Uri(clsVarGlobal.cURLReport);
                this.reportViewer1.ServerReport.ReportPath = ReportPath;
                this.reportViewer1.ServerReport.SetParameters(Parameters);

                string deviceInfo = @"<DeviceInfo>
                                    <OutputFormat>EMF</OutputFormat>
                                    <PageWidth>8.5in</PageWidth>
                                    <PageHeight>11in</PageHeight>
                                    <MarginTop>0.25in</MarginTop>
                                    <MarginLeft>0.25in</MarginLeft>
                                    <MarginRight>0.25in</MarginRight>
                                    <MarginBottom>0.25in</MarginBottom>
                                </DeviceInfo>";
                Warning[] warnings;
                reportViewer1.LocalReport.Render("Image", deviceInfo, CreateStream, out warnings);
                foreach (Stream x in m_streams)
                    x.Position = 0;

                if (m_streams == null || m_streams.Count == 0)
                {
                    throw new Exception("Error: no stream to print.");
                }

                PrintDocument printDoc = new PrintDocument();

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
            else
            {

                this.reportViewer1.RefreshReport();
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

    }
}
