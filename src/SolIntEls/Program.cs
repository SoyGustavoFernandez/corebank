using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace SolIntEls
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-PE");
            //Application.ThreadException += Application_ThreadException;
            //Application.Run(new frmContenedor());
            Application.Run(new frm_Inicio());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string user = !EntityLayer.clsVarGlobal.lEstLogeado ? Environment.UserName : EntityLayer.clsVarGlobal.User.cWinUser;
            string cDirectorio = String.Format("{0}\\{1}",System.IO.Directory.GetCurrentDirectory(),"Log");
            string cNombreArchivo = String.Format("{0}_{1}_{2}.txt", user, Environment.MachineName, DateTime.Now.ToString("yyyyMMdd"));
            string ruta = String.Format("{0}\\{1}", cDirectorio, cNombreArchivo);
            if (!System.IO.Directory.Exists(cDirectorio))
            {
                System.IO.Directory.CreateDirectory(cDirectorio);
            }

            System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(ruta, true);

            try
            {
                fileWriter.WriteLine("================================");
                fileWriter.WriteLine("Entrada del log:");
                fileWriter.WriteLine("================================");
                fileWriter.WriteLine("Fecha y hora: {0}", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                fileWriter.WriteLine("Mensaje del error: {0}", e.Exception.Message);
                fileWriter.WriteLine("StackTrace: {0}", e.Exception.StackTrace);
                fileWriter.WriteLine();
                fileWriter.Close();
            }
            catch
            {
                fileWriter.Close();
            }
            finally
            {
                fileWriter.Close();
            }

            //MessageBox.Show(e.Exception.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw e.Exception;
        }
    }
}
