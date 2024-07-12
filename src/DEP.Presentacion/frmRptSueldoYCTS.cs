#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml.Linq;
using EntityLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;

#endregion

namespace DEP.Presentacion
{
    public partial class frmRptSueldoYCTS : frmBase
    {
        #region Variables

        private clsCNDeposito objCNDeposito = new clsCNDeposito();
        private DataTable dtDatCuentas = new DataTable();
        private clsCNProducto objCNProducto = new clsCNProducto();
        private DataTable dtProducto;

        #endregion

        public frmRptSueldoYCTS()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmRptSueldoYCTS_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            dtProducto = objCNProducto.CNlistarIdProducto(clsVarApl.dicVarGen["cProductosSueldoYCTS"]);

            DataTable dtListProductos = new DataTable();
            dtListProductos.Columns.Add("idProducto", typeof(String));
            dtListProductos.Columns.Add("cNombre", typeof(String));
            dtListProductos.Rows.Add("0", "TODOS");

            bool lConcatenarComa = false;
            string cListProductos = "";

            foreach (DataRow row in dtProducto.Rows)
            {
                if (lConcatenarComa)
                {
                    cListProductos += ",";
                }
                else
                {
                    lConcatenarComa = true;
                }
                cListProductos += row["idProducto"];
                dtListProductos.Rows.Add(row["idProducto"], row["cProducto"]);
            }

            dtListProductos.Rows[0]["idProducto"] = cListProductos;

            cboProductos.DataSource = dtListProductos;
            cboProductos.ValueMember = "idProducto";
            cboProductos.DisplayMember = "cNombre";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            dtDatCuentas = objCNDeposito.CNListarCuentasAhorroActivas(cboProductos.SelectedValue.ToString());

            if (dtDatCuentas.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsSueldoYCTS", dtDatCuentas));
                string reportpath = "rptSueldoYCTS.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Reporte de cuentas Sueldo y CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
        

    }
}
