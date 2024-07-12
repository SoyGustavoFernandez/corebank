using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJ.Presentacion
{
    public partial class frmLibroCuadreCajaCnt : frmBase
    {
        public frmLibroCuadreCajaCnt()
        {
            InitializeComponent();
            DatosUsuario();
            cboAgencias1.AgenciasYTodos();
        }
        private void DatosUsuario()
        {
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if ( dtpFechaFin.Value.Date<dtpFechaIni.Value.Date)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual al fecha inicial","Validar reporte",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
           int idAgencia=Convert.ToInt32(cboAgencias1.SelectedValue);

            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            parametros.Add(new ReportParameter("dFechaSis",clsVarGlobal.dFecSystem.ToShortDateString(),false));
            parametros.Add(new ReportParameter("cNombreAge",clsVarGlobal.cNomAge.ToString(),false));
            parametros.Add(new ReportParameter("dFechaIni",dtpFechaIni.Value.ToShortDateString(), false));
            parametros.Add(new ReportParameter("dFechaFin", dtpFechaFin.Value.ToShortDateString(), false));
            parametros.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            parametros.Add(new ReportParameter("lConsolidado", Convert.ToInt32(chcConsolidad.Checked).ToString(), false));
            List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
            clsCNControlOpe conControlOpe = new clsCNControlOpe();
            DataTable dtResultado=conControlOpe.CNListarCuadreLibroCajaCnt(dtpFechaIni.Value, dtpFechaFin.Value, idAgencia,chcConsolidad.Checked);
            if (dtResultado.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros para el reporte","Valida libro caja contable",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            lstDataSource.Add(new ReportDataSource("dtsValidaSaldoCajCnt", dtResultado)); ;
            string reportPath = "RptValidaSaldoCajCnt.rdlc";
            new frmReporteLocal(lstDataSource,reportPath,parametros).ShowDialog();
        }

        private void frmLibroCuadreCajaCnt_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem.AddDays(-1);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void chcConsolidad_CheckedChanged(object sender, EventArgs e)
        {
            if (chcConsolidad.Checked)
            {
                cboAgencias1.Enabled = false;
                //dtpFechaIni.Enabled = false;
                //dtpFechaFin.Enabled = false;
            }
            else
            {
                cboAgencias1.Enabled = true;
                //dtpFechaIni.Enabled = true;
                //dtpFechaFin.Enabled = true;
            }
        }

        
    }
}
