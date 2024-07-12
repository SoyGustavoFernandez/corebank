using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class FrmActaAprobCredNivel : frmBase
    {
        #region Variables

        private const string cTituloMsjes = "Imprimir acta de aprobación de créditos";

        #endregion

        #region Constructores
        public FrmActaAprobCredNivel()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos

        private void FrmActaAprobCredNivel_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            BuscarSolicitudes();
        }

        private void btnImpActaCredito_Click(object sender, EventArgs e)
        {
            if (!Validar(2)) return;

            int idSolicitud = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitud"].Value);
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataSet dsData = new clsRPTCNCredito().CNGenActaAprobDenegCred(idSolicitud);

            if (dsData.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDatosGenerales", dsData.Tables["dtDatosGenerales"]));
            dtslist.Add(new ReportDataSource("dsDestCredSol", dsData.Tables["dtDestCredSol"]));
            dtslist.Add(new ReportDataSource("dsComite", dsData.Tables["dtComite"]));
            dtslist.Add(new ReportDataSource("dsNivAproba", dsData.Tables["dtNivAproba"]));
            dtslist.Add(new ReportDataSource("dsIntervSolCre", dsData.Tables["dtIntervSolCre"]));

            string reportpath = "rptActaAprobacionCredito.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        #endregion

        #region Métodos

        private void BuscarSolicitudes()
        {
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;

            DataTable dtResult = new clsCNSolCre().GetSolAprobNiveles(idUsuario, idPerfil, dFecIni, dFecFin);
            dtgSolicitudes.DataSource = dtResult;
            FormatoGrid();
        }

        private bool Validar(int nValid)
        {
            if (nValid == 1)
            {
                if (dtpFecFin.Value < dtpFecIni.Value)
                {
                    MessageBox.Show("La fecha final de busqueda no puede ser anterior a la fecha inicial.", cTituloMsjes,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (nValid == 2)
            {
                if (dtgSolicitudes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el registro para el reporte.", cTituloMsjes,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void FormatoGrid()
        {
            foreach (DataGridViewColumn column in dtgSolicitudes.Columns)
            {
                column.Visible = false;
            }

            dtgSolicitudes.Columns["nNum"].Visible = true;
            dtgSolicitudes.Columns["idSolicitud"].Visible = true;
            dtgSolicitudes.Columns["dFechaDecisFinal"].Visible = true;
            dtgSolicitudes.Columns["cMoneda"].Visible = true;
            dtgSolicitudes.Columns["cNombre"].Visible = true;
            dtgSolicitudes.Columns["cEstado"].Visible = true;
            dtgSolicitudes.Columns["cSubProd"].Visible = true;
            dtgSolicitudes.Columns["cAsesor"].Visible = true;
            dtgSolicitudes.Columns["nCapitalAprobado"].Visible = true;

            dtgSolicitudes.Columns["nNum"].HeaderText = "N°";
            dtgSolicitudes.Columns["idSolicitud"].HeaderText = "N° solicitud";
            dtgSolicitudes.Columns["dFechaDecisFinal"].HeaderText = "Fec. decisión";
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Cliente";
            dtgSolicitudes.Columns["cEstado"].HeaderText = "Estado";
            dtgSolicitudes.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolicitudes.Columns["nCapitalAprobado"].HeaderText = "Monto";
            dtgSolicitudes.Columns["cSubProd"].HeaderText = "Producto";
            dtgSolicitudes.Columns["cAsesor"].HeaderText = "Asesor";

            dtgSolicitudes.Columns["nNum"].DisplayIndex = 0;
            dtgSolicitudes.Columns["idSolicitud"].DisplayIndex = 1;
            dtgSolicitudes.Columns["dFechaDecisFinal"].DisplayIndex = 2;
            dtgSolicitudes.Columns["cNombre"].DisplayIndex = 3;
            dtgSolicitudes.Columns["cEstado"].DisplayIndex = 4;
            dtgSolicitudes.Columns["cMoneda"].DisplayIndex = 5;
            dtgSolicitudes.Columns["nCapitalAprobado"].DisplayIndex = 6;
            dtgSolicitudes.Columns["cSubProd"].DisplayIndex = 7;
            dtgSolicitudes.Columns["cAsesor"].DisplayIndex = 8;
        }

        #endregion


    }
}
