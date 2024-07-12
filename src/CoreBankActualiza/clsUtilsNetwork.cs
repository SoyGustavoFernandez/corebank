using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace CoreBankActualiza
{
    public class clsUtilsNetwork
    {
        public static DataTable GetSharedFiles()
        {
            DataTable dataTable = PrepareDataTable();
            var process = new Process();
            var pInfo = new ProcessStartInfo("openfiles.exe", "/query /fo CSV /v");
            pInfo.UseShellExecute = false;
            pInfo.RedirectStandardOutput = true;
            pInfo.CreateNoWindow = true;
            pInfo.Verb = "runas";

            try
            {
                process = Process.Start(pInfo);
                if ((process.StandardOutput != null))
                {
                    var result = process.StandardOutput.ReadToEnd().Trim().Replace("\"", "");
                    var lines = result.Split('\n');

                    dataTable.Rows.Clear();

                    var firstLineIndex = 1 + lines.Cast<string>().ToList().FindIndex(l => l.Contains("Hostname") ||
                                                                                          l.Contains("Nombre de host"));
                    for (int i = firstLineIndex; i < lines.Count() && firstLineIndex > 0; i++)
                    {
                        var fields = lines[i].Split(',');
                        var newRow = dataTable.NewRow();
                        newRow["HostName"] = fields[0];
                        newRow["ID"] = fields[1];
                        newRow["UserName"] = fields[2];
                        newRow["Type"] = fields[3];
                        newRow["Locks"] = fields[4];
                        newRow["OpenMode"] = fields[5];
                        newRow["File"] = fields[6];
                        dataTable.Rows.Add(newRow);
                    }
                }
                process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error: " + e.Message + " : " + DateTime.Now.ToShortTimeString());
            }
            finally
            {
                process.Close();
            }
            return dataTable;
        }

        private static DataTable PrepareDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable = new DataTable("ShareMonitor");
            dataTable.Columns.Add("HostName");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("UserName");
            dataTable.Columns.Add("Type");
            dataTable.Columns.Add("Locks");
            dataTable.Columns.Add("OpenMode");
            dataTable.Columns.Add("File");

            return dataTable;
        }

        public static void DisconnectFile(int id)
        {
            var process = new Process();
            string cParameter = String.Format("/disconnect /ID {0}", id);
            var pInfo = new ProcessStartInfo("openfiles.exe", cParameter);
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;

            try
            {
                process = Process.Start(pInfo);
                process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error: " + e.Message + " : " + DateTime.Now.ToShortTimeString());
            }
            finally
            {
                process.Close();
            }
        }
    }
}
