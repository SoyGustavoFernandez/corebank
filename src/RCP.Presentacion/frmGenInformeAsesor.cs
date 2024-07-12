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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RCP.Presentacion
{
    public partial class frmGenInformeAsesor : frmBase
    {
        #region Variables Globales
        private const string cTituloMsjes = "Generar informe de asesor.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtgCreditos.AutoGenerateColumns = false;

            cboAgencia.SelectedValue = 0;
            DataTable dtData = new clsCNTranferencias().listarCredInformeAsesor(clsVarGlobal.User.idUsuario, Convert.ToInt16(cboAgencia.SelectedValue));
            dtgCreditos.DataSource = dtData;
            btnImprimir.Enabled = (dtData.Rows.Count > 0);
        }

        #endregion

        #region Metodos

        public frmGenInformeAsesor()
        {
            InitializeComponent();
            cboAgencia.cargarAgencia(0);
        }

        private bool Validar()
        {
            if (dtgCreditos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return true;
        }

        #endregion

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                if (cboAgencia.SelectedValue != null && !(cboAgencia.SelectedValue is DataRowView))
                {
                    DataTable dtData = new clsCNTranferencias().listarCredInformeAsesor(clsVarGlobal.User.idUsuario, Convert.ToInt16(cboAgencia.SelectedValue));
                    dtgCreditos.DataSource = dtData;

                    btnImprimir.Enabled = (dtData.Rows.Count > 0);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(!Validar()) return;
            clsCNTranferencias cnTranferencias = new clsCNTranferencias();

            DataRowView row = (DataRowView)dtgCreditos.SelectedRows[0].DataBoundItem;
            int idCuenta = Convert.ToInt32(row["idCuenta"]);
            int idSolicitud = Convert.ToInt32(row["idSolicitud"]);
            int idInfPaseRecuperaciones = Convert.ToInt32(row["idInfPaseRecuperaciones"]);

            DataTable dtCreditoTransferido = cnTranferencias.ObtenerCreditoTransferido(idInfPaseRecuperaciones);
            DataTable dtIntervinientes = cnTranferencias.ListarIntervinientes(idSolicitud);
            DataTable dtGestiones = cnTranferencias.listarGestiones(idCuenta);
            DataTable dtPromesas = cnTranferencias.listarPromesas(idCuenta);



            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsGestiones", dtGestiones));
            dtslist.Add(new ReportDataSource("dsPromesas", dtPromesas));
            dtslist.Add(new ReportDataSource("dsCredito", dtCreditoTransferido));
            dtslist.Add(new ReportDataSource("dsInterviniente", dtIntervinientes));

            string reportpath = "rptInformeTransferencia.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
