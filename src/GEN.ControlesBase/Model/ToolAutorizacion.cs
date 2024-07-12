using CLI.Servicio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase.Model
{
   public static class ToolAutorizacion
   {

       public static bool validarHuella(int IdSolicitud, int pIdCliente, string cNroDoc, string cNombre)
       {
           DataTable dtIntervinientes = new DataTable("NombreTablaDos");
           dtIntervinientes.Columns.Add("isReqFirma", typeof(bool));
           dtIntervinientes.Columns.Add("idCli", typeof(int));
           dtIntervinientes.Columns.Add("cDocumentoID", typeof(string));
           dtIntervinientes.Columns.Add("cNombre", typeof(string));

           DataRow workRow = dtIntervinientes.NewRow();
           workRow["isReqFirma"] = 1;
           workRow["idCli"] = pIdCliente;
           workRow["cDocumentoID"] = cNroDoc;
           workRow["cNombre"] = cNombre;

           dtIntervinientes.Rows.Add(workRow);  

           clsBiometrico oBiometrico = new clsBiometrico();
           clsCNSolicitud cnsolicitud = new clsCNSolicitud();
           clsCNTipAutUsoDatos objAutorizacion= new clsCNTipAutUsoDatos();

           #region Huellas           
               int idProducto = 1882;
               int idOperacion = 209;
               int idMonenda = 1;
               decimal nMonto = 0;

               var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]) ) //&& Convert.ToInt32(x["idCli"]) == pIdCliente)
                                                       .OrderBy(x => Convert.ToInt32(x["idCli"]));
               string cMensaje = "";

               if (!oBiometrico.validacionBiometricaAutorizacion(
                       listFirmantes
                       , idMonenda
                       , idProducto
                       , nMonto
                       , idOperacion
                       , ref cMensaje))
               {
                   MessageBox.Show("La operación no se ejecutó debido a que no se pasó el control biométrico.\n " + cMensaje, "Validación Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                   return false;
               }
           return true;
           #endregion
       }
       public static byte[] GenerarDocumento(string reportpath, string cNombreArchivo, List<ReportParameter> paramlist, List<ReportDataSource> dtslist, ref string cArchivoFin)
       {
           string cPathRoot = clsVarGlobal.cRutPathApp;
           string cPathAnioMes ="AUTORIZACIONES";

           string cRuta = Path.Combine(cPathRoot, cPathAnioMes);

           //ExportarPDF

           new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cRuta, cNombreArchivo);
           string cArchivo = cRuta + "\\" + cNombreArchivo + ".pdf";
           //carga de documento 

           FileInfo fInfo = new FileInfo(cArchivo);
           long numBytes = fInfo.Length;
           FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
           BinaryReader br = new BinaryReader(fStream);

           string nameFile = cArchivo;
           string cDocumentoSesion = fInfo.Name;
           byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
           string cExtension = fInfo.Extension;
           fStream.Flush();
           fStream.Close();
           br.Close();

           cArchivoFin = cDocumentoSesion;
           borrarDocumentosAut(cArchivo);
           return Compresion.CompressedByte(vDocumentoSesion);
       }
         
        public static void borrarDocumentosAut(string ruta)
        {   
            try
            {
                File.SetAttributes(ruta, FileAttributes.Normal);
                File.Delete(ruta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
