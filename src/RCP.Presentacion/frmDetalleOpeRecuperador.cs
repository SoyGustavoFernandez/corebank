using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmDetalleOpeRecuperador : frmBase
    {
        #region Variables Globales

        clsCNPersonal cnpersonal = new clsCNPersonal();

        #endregion

        public frmDetalleOpeRecuperador()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarRecuperadores();
            dFecIni.Value =new DateTime(clsVarGlobal.dFecSystem.Year,clsVarGlobal.dFecSystem.Month,1);
            dFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private bool validar()
        {
            bool lVal = false;

            if (dFecFin.Value < dFecIni.Value)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la Fecha Inicial","Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (chkRecuperadores.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un recuperador por favor", "Validación recuperadores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkRecuperadores.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void cargarRecuperadores()
        {
            DataTable dt = cnpersonal.ListaPersonalCargo("nCargosRecuperadores", 0);
            chkRecuperadores.DataSource = dt;
            chkRecuperadores.ValueMember = dt.Columns[0].ToString();
            chkRecuperadores.DisplayMember = dt.Columns[1].ToString();
        }
        
        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkRecuperadores.Items.Count; ++i)
                chkRecuperadores.SetItemChecked(i, chcTodos.Checked);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                string CodRecuperador = "";

                foreach (DataRowView item in this.chkRecuperadores.CheckedItems)
                {
                    CodRecuperador += (item.Row["idUsuario"] + ",");
                }


                paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
                paramlist.Add(new ReportParameter("idAgencia", cboAgencia1.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsCobranza", new clsRPTCNCredito().RptDetCobranzaRecup(dFecIni.Value, dFecFin.Value, idAgencia, CodRecuperador)));

                string reportpath = "RptDetalleOperaciones.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
