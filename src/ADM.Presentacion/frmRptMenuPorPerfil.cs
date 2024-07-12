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
using ADM.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmRptMenuPorPerfil : frmBase
    {
        #region Variables

        clsCNPerfilUsu perfilusu = new clsCNPerfilUsu();
        clsCNMantenimiento cnmantenimiento = new clsCNMantenimiento();

        #endregion

        public frmRptMenuPorPerfil()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarPerfiles();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (lstPerfiles.SelectedItems.Count > 0)
            {
                int idPerfil = Convert.ToInt32(lstPerfiles.SelectedValue);

                DataTable dtMenuPerfil = perfilusu.ReporteMenuPorPerfil(idPerfil);

                if (dtMenuPerfil.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsMenuPerfil", dtMenuPerfil));

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idPerfil", idPerfil.ToString(), false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));

                    string reportPath = "rptMenuPorPerfil.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos", "Reporte de Menú Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un perfil por favor", "Reporte de Menú Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Metodos

        private void cargarPerfiles()
        {
            var dtPerfiles = cnmantenimiento.ListarPerfiles();

            if (dtPerfiles.Rows.Count > 0)
            {
                lstPerfiles.DataSource = dtPerfiles;
                lstPerfiles.DisplayMember = dtPerfiles.Columns[1].ColumnName;
                lstPerfiles.ValueMember = dtPerfiles.Columns[0].ColumnName;
            }
        }

        #endregion
    }
}
