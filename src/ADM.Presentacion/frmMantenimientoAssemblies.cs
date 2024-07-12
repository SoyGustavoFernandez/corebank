using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoAssemblies : frmBase
    {
        #region Variables

        private const string cTituloMsjes = "Mantenimiento de assemblies";

        #endregion

        public frmMantenimientoAssemblies()
        {
            InitializeComponent();
        }

        #region Eventos

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
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

            lstAssemblies = lstAssemblies.Where(x => !x.cNomAssembly.Equals("BarcodeLib") &&
                                                    !x.cNomAssembly.Equals("GMap.NET.Core") &&
                                                    !x.cNomAssembly.Equals("GMap.NET.WindowsForms") &&
                                                    !x.cNomAssembly.Equals("Microsoft.VisualBasic.PowerPacks.Vs") &&
                                                    !x.cNomAssembly.Equals("vshost32") &&
                                                    !x.cNomAssembly.Equals("CoreBankActualiza")).ToList();

            string xmlAssemblies = lstAssemblies.GetXml();

            clsDBResp objDbResp = new clsCNMantAssemblies().GuardarInfoAssemblies(xmlAssemblies);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Métodos
        #endregion

    }
}
