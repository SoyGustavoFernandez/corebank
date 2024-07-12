using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace GEN.CapaNegocio
{
    public class clsCovertRptXml
    {
        /**
        * 
        * Convertir todos los datos que se envian a un reporte
        * en xml para guardarlos en la base de datos
        * 
        */
        public XElement convertirReportAXml(List<ReportDataSource> dtslist, string reportpath)
        {
            XElement xListReportDataSource = new XElement("ListReportDataSource");
            dtslist.ForEach(delegate(ReportDataSource item)
            {
                DataTable dtItem = new DataTable();
                dtItem.Clear();
                dtItem.Dispose();
                dtItem.Reset();
                dtItem = (DataTable)item.Value;

                // convertir DataTable a XML
                StringWriter sw = new StringWriter();
                DataTable dtItem2 = dtItem.Copy();
                dtItem2.TableName = item.Name;
                dtItem.WriteXml(sw);
                string cDtItem = sw.ToString();

                // convertir a XElement
                XElement xDtItem = XElement.Parse(cDtItem);

                xListReportDataSource.Add(new XElement(item.Name, xDtItem));
            });

            XElement xReportPath = new XElement("reportpath", reportpath);
            XElement xReport = new XElement("report");
            xReport.Add(xListReportDataSource);
            xReport.Add(new XElement("version", "0.1"));
            return xReport;
        }

        /**
         * 
         * Convierte un objeto XElement a datatable
         * 
         */
        public DataTable xmlADatatable(XElement xTabla)
        {
            StringReader srXmlData = new StringReader(xTabla.ToString());
            DataSet dtsLector = new DataSet();
            dtsLector.ReadXml(srXmlData);
            return dtsLector.Tables[0];
        }
    }
}
