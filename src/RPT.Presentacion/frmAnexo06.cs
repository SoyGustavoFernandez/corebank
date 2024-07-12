using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.SqlServer.Dts.Runtime;

namespace RPT.Presentacion
{
    public partial class frmAnexo06 : frmBase
    {
        public frmAnexo06()
        {
            InitializeComponent();
        }

        class MyEventListener : DefaultEvents
        {
            public override bool OnError(DtsObject source, int errorCode, string subComponent,
              string description, string helpFile, int helpContext, string idofInterfaceWithError)
            {
                MessageBox.Show(description,"Error Transferencia de Archivos", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }
        private void frmAnexo06_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnRCD_Click(object sender, EventArgs e)
        {
            string pkgLocation;
            Package pkg;
            Variables vars;
            string cRuta;
            string cNomArc;
            DialogResult result;
            DTSExecResult pkgResults;

            result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                Microsoft.SqlServer.Dts.Runtime.Application app;
                app = new Microsoft.SqlServer.Dts.Runtime.Application();

                MyEventListener eventListener = new MyEventListener();

                pkgLocation = clsVarGlobal.cRutPathApp + "\\PqtGeneraRCD.dtsx";
                pkg = app.LoadPackage(@pkgLocation, eventListener);

                vars = pkg.Variables;
                cNomArc = cRuta + "\\RCC" + Convert.ToString(dtpFecha.Value.Year) + dtpFecha.Value.Month.ToString("00") + "." + Convert.ToString(clsVarApl.dicVarGen["cCodInst"]).Substring(2,3);

                vars["cCodIfi"].Value = clsVarApl.dicVarGen["cCodInst"];
                vars["VarRuta"].Value = @cNomArc;
                vars["dFecha"].Value = dtpFecha.Value.Date;

                Cursor.Current = Cursors.WaitCursor;

                pkgResults = pkg.Execute(null, vars, eventListener, null, null);

                Cursor.Current = Cursors.Default;

                MessageBox.Show(pkgResults.ToString(), "Genera RCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRCA.Enabled = true;
                btnRCCOD.Enabled = true;
            }
            else
            {
                btnRCA.Enabled = false;
                btnRCCOD.Enabled = false;
            }
        }

        private void btnRCCOD_Click(object sender, EventArgs e)
        {
            string pkgLocation;
            Package pkg;
            Variables vars;
            string cRuta;
            string cNomArc;
            DialogResult result;
            DTSExecResult pkgResults;

            result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                Microsoft.SqlServer.Dts.Runtime.Application app;
                app = new Microsoft.SqlServer.Dts.Runtime.Application();

                MyEventListener eventListener = new MyEventListener();

                pkgLocation = clsVarGlobal.cRutPathApp + "\\PqtGeneraRCCOD.dtsx";
                pkg = app.LoadPackage(@pkgLocation, eventListener);

                string cCodIfi = Convert.ToString(clsVarApl.dicVarGen["cCodInst"]);
                vars = pkg.Variables;
                cNomArc = cRuta + "\\RCCOD" + Convert.ToString(dtpFecha.Value.Year) + dtpFecha.Value.Month.ToString("00") + "." + cCodIfi.Substring(2,3);

                vars["cCodIfi"].Value = cCodIfi;
                vars["VarRuta"].Value = @cNomArc;
                vars["dFecha"].Value = dtpFecha.Value.Date;

                Cursor.Current = Cursors.WaitCursor;

                pkgResults = pkg.Execute(null, vars, eventListener, null, null);

                Cursor.Current = Cursors.Default;

                MessageBox.Show(pkgResults.ToString(), "Genera RCCOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnRCA_Click(object sender, EventArgs e)
        {
            string pkgLocation;
            Package pkg;
            Variables vars;
            string cRuta;
            string cNomArc;
            DialogResult result;
            DTSExecResult pkgResults;

            result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                Microsoft.SqlServer.Dts.Runtime.Application app;
                app = new Microsoft.SqlServer.Dts.Runtime.Application();

                MyEventListener eventListener = new MyEventListener();

                pkgLocation = clsVarGlobal.cRutPathApp + "\\PqtGeneraRCA.dtsx";
                pkg = app.LoadPackage(@pkgLocation, eventListener);

                string cCodIfi = Convert.ToString(clsVarApl.dicVarGen["cCodInst"]);
                vars = pkg.Variables;
                cNomArc = cRuta + "\\RCA" + Convert.ToString(dtpFecha.Value.Year) + dtpFecha.Value.Month.ToString("00") + "." + cCodIfi.Substring(2, 3);

                vars["cCodIfi"].Value = cCodIfi;
                vars["VarRuta"].Value = @cNomArc;
                vars["dFecha"].Value = dtpFecha.Value.Date;

                Cursor.Current = Cursors.WaitCursor;

                pkgResults = pkg.Execute(null, vars, eventListener, null, null);

                Cursor.Current = Cursors.Default;

                MessageBox.Show(pkgResults.ToString(), "Genera RCCOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}

