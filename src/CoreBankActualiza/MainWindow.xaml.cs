using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace CoreBankActualiza
{
    public partial class MainWindow : Window
    {
        #region Variables Globales

        clsConector ejecutaSP = new clsConector();
        clsCNActualiza actualiza = new clsCNActualiza();
        string  cRutaActualizaciones;
        WebClient webClient = new WebClient();
        private string cRutaRar = String.Empty;
        private string cRutaApp = String.Empty;
        private int nVersion = 0;
        private const string cTituloMsjes = "Actualización del Core Bank";

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            validarSistemaActivo();
            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
        }

        private void validarSistemaActivo()
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.MainWindowTitle.Contains("..:: Validación de Usuario ::..")
                        || item.MainWindowTitle.Contains("..:: Core Bank")
                        || item.ProcessName.Equals("SolIntEls"))
                {
                    MessageBox.Show("CoreBank se encuentra activo \n por favor cierre el sistema", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            //actualizarRedInterna();
            actualizarWeb();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtLinkSolintels_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            startInfo.Arguments = "www.solintels.com";
            Process.Start(startInfo);
        }

        private void actualizarRedInterna()
        {
            try
            {
                string cRutaApp = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";

                if (actualiza.AutenticarUsuActualiza("uActualiza", "P@ssw0rd"))
                {
                    actualiza.leerXML("uActualiza", "P@ssw0rd");
                    int nVersion = Convert.ToInt32(ejecutaSP.EjecSP("Gen_RetVariable_Sp", "cVersionSis", 0).Rows[0][0]);
                    int nVersionActual = Convert.ToInt32(File.ReadAllText(cRutaApp + "version.txt"));

                    if (nVersionActual == nVersion)
                    {
                        MessageBox.Show("La versión del Sistema ya se encuentra actualizado", "Validar la Versión del Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    List<int> lisVersiones = new List<int>();
                    cRutaActualizaciones = ejecutaSP.EjecSP("Gen_RetVariable_Sp", "cRutaActualizaciones", 0).Rows[0][0].ToString();

                    var lisCarpetas = Directory.GetDirectories(cRutaActualizaciones);

                    if (lisCarpetas.Count() > 0)
                    {
                        foreach (var item in lisCarpetas)
                        {
                            DirectoryInfo infoCarpeta = new DirectoryInfo(item);
                            lisVersiones.Add(Convert.ToInt32(infoCarpeta.Name));
                        }

                        string cVersionMax = lisVersiones.Max().ToString();
                        var lisArchivos = Directory.GetFiles(cRutaActualizaciones + cVersionMax + "\\");

                        foreach (var item in lisArchivos)
                        {
                            FileInfo info = new FileInfo(item);
                            var cNomArchivo = info.Name;

                            File.Copy(item, cRutaApp + cNomArchivo, true);

                            if (info.Extension == ".rar")
                            {
                                ProcessStartInfo startInfo = new ProcessStartInfo("WinRAR.exe");
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "x -Y " + cRutaApp + cNomArchivo + " " + System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                                try
                                {
                                    using (Process exeProcess = Process.Start(startInfo))
                                    {
                                        exeProcess.WaitForExit();
                                    }

                                    File.Delete(cRutaApp + cNomArchivo);
                                }
                                catch
                                {
                                    MessageBox.Show("Error al descomprimir archivos");
                                }
                            }
                        }
                        File.WriteAllText(cRutaApp + "version.txt", cVersionMax);

                        MessageBox.Show("Las Actualizaciones se instalaron correctamente", "Actualización Corebank", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No existe actualizaciones pendientes", "Actualización Corebank", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void actualizarWeb()
        {
            try
            {
                var cUsuario = "uActualiza";
                var cClave = "P@ssw0rd";

                cRutaApp = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";

                if (!ValidaPermisosEscritura(cRutaApp))
                {
                    return;
                }

                if (actualiza.AutenticarUsuActualiza(cUsuario, cClave))
                {
                    actualiza.leerXML(cUsuario, cClave);
                    nVersion = Convert.ToInt32(ejecutaSP.EjecSP("Gen_RetVariable_Sp", "cVersionSis", 0).Rows[0][0]);
                    string cUrlActualizaCoreBank =
                        Convert.ToString(ejecutaSP.EjecSP("Gen_RetVariable_Sp", "cUrlActualizaCoreBank", 0).Rows[0][0]);

                    //int nVersionActual = Convert.ToInt32(File.ReadAllText(cRutaApp + "version.txt"));

                    //if (nVersionActual == nVersion)
                    //{
                    //    MessageBox.Show("La versión del sistema ya se encuentra actualizado", "Validar la Versión del Sistema", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //    this.Close();
                    //    return;
                    //}

                    if (ValidarVersionAssemblies())
                    {
                        MessageBox.Show("La versión del sistema ya se encuentra actualizado", cTituloMsjes,
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                        this.Close();
                        return;
                    }

                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                    var cNombreArchivo = nVersion.ToString() + ".rar";
                    cRutaRar = cRutaApp + cNombreArchivo;

                    pgbActualiza.Visibility = Visibility.Visible;
                    btnActualizar.IsEnabled = false;

                    try
                    {
                        WebRequest request = WebRequest.Create(new Uri(cUrlActualizaCoreBank + cNombreArchivo));
                        request.Method = "HEAD";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        response.Dispose();
                        request.Abort();
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show("No se encontro el archivo de actualización.");
                        return;
                    }

                    webClient.DownloadFileAsync(new Uri(cUrlActualizaCoreBank + cNombreArchivo), cRutaRar);
                }
            }
            catch (WebException ex)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                MessageBox.Show("Error al descargar actualización \n" + ex.Message);
                this.Close();
            }
            catch (IOException ex)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                MessageBox.Show("No se tiene acceso de escritura a la carpeta");
                this.Close();
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                MessageBox.Show("Error de actualización \n" + ex.Message);
                this.Close();
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            pgbActualiza.Value = int.Parse(Math.Truncate(percentage).ToString());

        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgbActualiza.Visibility = Visibility.Hidden;
            Descomprimir();
        }

        void Descomprimir()
        {
            if (File.Exists(cRutaRar))
            {
                try
                {
                    KillCoreBank();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cerrar procesos de Core Bank. Privilegios insuficientes.", "Actualización Corebank", MessageBoxButton.OK, MessageBoxImage.Warning);
                    throw;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo("WinRAR.exe");
                Process exeProcess = null;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "x -y " + string.Format("\"{0}\"", cRutaRar) + " " + string.Format("\"{0}\"", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                try
                {
                    using (exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }

                    File.Delete(cRutaRar);
                }
                catch (Exception ex)
                {
                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                    MessageBox.Show("Error al descomprimir archivos \n" + ex.Message);
                    this.Close();
                    return;
                }

                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                if (ValidarVersionAssemblies())
                {
                    MessageBox.Show(
                       "Las actualizaciones se instalaron correctamente.\nAhora puede iniciar Core Bank",
                       cTituloMsjes, MessageBoxButton.OK, MessageBoxImage.Information);
                    File.WriteAllText(cRutaApp + "version.txt", nVersion.ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                       "Las actualizaciones no se instalaron correctamente.\nIntente actualizar el sistema nuevamente o contacte a soporte técnico.\n"
                        + "Es posible que el sistema se encuentre abierto en otras terminales.",
                       cTituloMsjes, MessageBoxButton.OK, MessageBoxImage.Error);
                    btnActualizar.IsEnabled = true;
                }
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                MessageBox.Show("No existe actualizaciones pendientes", "Actualización Corebank", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void cargarCorebank()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("SolIntEls.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                MessageBox.Show("Error iniciar Core Bank \n" + ex.Message);
            }
        }

        private void KillCoreBank()
        {
            var process = Process.GetProcessesByName("SolIntEls");
            foreach (var proc in process)
            {
                proc.Kill();
            }

            DataTable dtData = clsUtilsNetwork.GetSharedFiles();
            var resultFilter = dtData.AsEnumerable().Where(x => x.Field<string>("File").EndsWith(".dll") ||
                                                            x.Field<string>("File").EndsWith(".exe"));
            foreach (DataRow row in resultFilter)
            {
                int id = Convert.ToInt32(row["ID"]);
                clsUtilsNetwork.DisconnectFile(id);
            }
        }

        private bool ValidarVersionAssemblies()
        {
            List<clsAssembly> lstAssembliesDB = MapeaTablaEntidad(ejecutaSP.EjecSP("ADM_GetAssembliesInfo_Sp"));

            string cRutaEjecucion = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(cRutaEjecucion).Where(x => x.EndsWith(".dll") || x.EndsWith(".exe"));

            List<clsAssembly> lstAssemblies = new List<clsAssembly>();

            foreach (var file in files)
            {
                //Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file);
                AssemblyName assembly = AssemblyName.GetAssemblyName(file);
                clsAssembly objAssembly = new clsAssembly();
                objAssembly.cNomAssembly = assembly.Name;

                objAssembly.cVersion = FileVersionInfo.GetVersionInfo(file).FileVersion;

                lstAssemblies.Add(objAssembly);
            }

            List<clsAssembly> lstNoActualizados = (from assemblyDB in lstAssembliesDB
                                                      from assemlyLocal in lstAssemblies
                                                .Where(x => x.cNomAssembly == assemblyDB.cNomAssembly
                                                            && x.cVersion == assemblyDB.cVersion).DefaultIfEmpty().
                                                Where(x => x == null)
                                                      select assemblyDB).ToList();

            StringBuilder sbArchivos = new StringBuilder();

            foreach (var fileNoAct in lstNoActualizados)
            {
                sbArchivos.AppendFormat("{0}\n", fileNoAct.cNomAssembly);
            }


            if (lstNoActualizados.Any())
            {
                return false;
            }

            return true;
        }

        private List<clsAssembly> MapeaTablaEntidad(DataTable dtResult)
        {
            List<clsAssembly> lstAssemblies = new List<clsAssembly>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsAssembly assembly = new clsAssembly();
                assembly.cNomAssembly = Convert.ToString(row["cNomAssembly"]);
                assembly.cVersion = Convert.ToString(row["cVersion"]);

                lstAssemblies.Add(assembly);
            }
            return lstAssemblies;
        }

        private bool ValidaPermisosEscritura(string cPath)
        {
            string cNomFile = string.Format("{0}\\test.txt", cPath);
            try
            {
                using (StreamWriter sw = File.CreateText(cNomFile))
                {
                    sw.WriteLine(" ");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Error: Privilegios de escritura insuficientes.", cTituloMsjes, MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear o copiar archivo.", cTituloMsjes, MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            File.Delete(cNomFile);
            return true;
        }

    }
}
