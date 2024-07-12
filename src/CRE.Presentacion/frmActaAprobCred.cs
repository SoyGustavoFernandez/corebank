﻿using System;
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
using CRE.CapaNegocio;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using CAJ.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmActaAprobCred : frmBase
    {

        #region Variables Globales

        private const string cTituloMsjes = "Impresión de actas de aprobación";

        #endregion

        #region Metodos

        public frmActaAprobCred()
        {
            InitializeComponent();

            cboNivelAprobacion1.CargarTodoDescripcionCompleta();

            // -------------------------
            clsCNControlOpe lstAgencia = new clsCNControlOpe();
            DataTable dt = lstAgencia.ListarAgencias();

            /*DataRow row = dt.NewRow();
            row["idAgencia"] = 0;
            row["cNombreAge"] = "TODOS";
            dt.Rows.Add(row);*/

            cboAgencias.DataSource = dt;
            cboAgencias.ValueMember = dt.Columns[0].ToString();
            cboAgencias.DisplayMember = dt.Columns[1].ToString();
            // -----------------------------

            chcAgencia_CheckedChanged(this.chcAgencia, new EventArgs());
            chcZona_CheckedChanged(this.chcZona, new EventArgs());
            chcNivAprob_CheckedChanged(this.chcNivAprob, new EventArgs());
        }

        private void BuscarSolicitudes()
        {
            DateTime dFecIni = dtpActaAprobIni.Value.Date;
            DateTime dFecFin = dtpActaAprobFin.Value.Date;

            DataTable dtResult = new clsCNSolCre().GetSolAprobDeneg(dFecIni, dFecFin);
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

                if (chcNivAprob.Checked == true)
                {
                    if (cboNivelAprobacion1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione un Nivel de Aprobación.", cTituloMsjes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (chcZona.Checked == true)
                {
                    if (cboZona1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione una Zona.", cTituloMsjes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (chcAgencia.Checked == true)
                {
                    if (cboAgencias.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione una Agencia.", cTituloMsjes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
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

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;

            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            BuscarSolicitudes();
        }

        private void btnActaNivAprob_Click(object sender, EventArgs e)
        {
            if (!Validar(1)) return;

            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;
            int idNivAprobacion = Convert.ToInt32(cboNivelAprobacion1.SelectedValue);
            int idZona = (cboZona1.SelectedIndex >= 0) ? Convert.ToInt32(cboZona1.SelectedValue) : 0;
            int idAgencia = (cboAgencias.SelectedIndex >= 0) ? Convert.ToInt32(cboAgencias.SelectedValue) : 0;


            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtData = new clsRPTCNCredito().CNGenActaAprobCreditos(dFecIni, dFecFin, idNivAprobacion, idZona, idAgencia);
            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToString()));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString()));
            paramlist.Add(new ReportParameter("idNivelAprobacion", idNivAprobacion.ToString()));
            paramlist.Add(new ReportParameter("idZona", idZona.ToString()));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString()));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            //string reportpath = "rptActaCredAprobadosFecha.rdlc";
            string reportpath = "rptCredAprobadoXNivel.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
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
            dtslist.Add(new ReportDataSource("dsExcepciones", dsData.Tables["dtExcepciones"]));
            dtslist.Add(new ReportDataSource("dsParticipantes", dsData.Tables["dtParticipantes"]));
            dtslist.Add(new ReportDataSource("dsHistObs", dsData.Tables["dtHistObs"]));
            
            string reportpath = "rptActaAprobacionCredito.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void chcAgencia_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            cboAgencias.Enabled = (chk.Checked == true);
            cboAgencias.SelectedIndex = -1;
        }

        private void chcZona_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            cboZona1.Enabled = (chk.Checked == true);
            cboZona1.SelectedIndex = -1;
        }

        private void chcNivAprob_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            cboNivelAprobacion1.Enabled = (chk.Checked == true);
            cboNivelAprobacion1.SelectedIndex = -1;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAgencias.FiltrarPorZonaTodos(Convert.ToInt32(cboZona1.SelectedValue));
            cboAgencias.SelectedIndex = -1;
        }
        #endregion
    }
}

