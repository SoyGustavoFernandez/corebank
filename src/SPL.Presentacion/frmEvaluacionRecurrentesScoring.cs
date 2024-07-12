using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmEvaluacionRecurrentesScoring : frmBase
    {

        #region Variables globales

        private clsCNScoring _cnScoring;
        private const string cTitulo = "Evaluación por Lotes Scoring";
        private DataTable _dtClientes;

        #endregion

        public frmEvaluacionRecurrentesScoring()
        {
            InitializeComponent();
            _cnScoring = new clsCNScoring();
        }

        #region Eventos

        private void frmEvaluacionRecurrentesScoring_Load(object sender, EventArgs e)
        {
            cboAgencia.SelectedIndex = -1;
            cboAgencia.SelectedIndexChanged += new EventHandler(cboAgencia_SelectedIndexChanged);
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            VerificarPerfilEvaluador();
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de realizar evaluaciones?",
                cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            int nCantidadEvaluacioneHechas = 0;
            int nCantidadEvaluacionesFallidas = 0;

            DataTable dtFactoresTotal = _cnScoring.ListaGruposFactoresCalific(0);
            DataTable dtPuntajeCalif = _cnScoring.ListaDesCalificacion(0);
            DataTable dtCriterios = _cnScoring.ListaFactoresCalificacion(0, 0, 0);
            var lstCalificacion = dtPuntajeCalif.AsEnumerable().Where(x => x.Field<bool>("lVigente"));
            dtPuntajeCalif = lstCalificacion.Any() ? lstCalificacion.CopyToDataTable() : dtPuntajeCalif.Clone();
            var lstClientes = new List<int>();
            
            foreach (DataGridViewRow item in dtgClientes.Rows)
            {
                try
                {
                    lstClientes.Clear();
                    int idCli = Convert.ToInt32(item.Cells["idCli"].Value);
                    int idTipoEval = Convert.ToInt32(item.Cells["idTipoEval"].Value);
                    lstClientes.Add(idCli);
                    DataTable dtDatosCli = _cnScoring.ListaDatosCliEvaluacion(lstClientes);
                    var lstFactores = dtFactoresTotal.AsEnumerable().Where(x => x.Field<int>("idTipoEval") == idTipoEval);
                    DataTable dtFactores = lstFactores.Any() ? lstFactores.CopyToDataTable() : dtFactoresTotal.Clone();

                    DataTable dtCalificacion = _cnScoring.GeneraEvaluacion(idTipoEval, dtDatosCli.Rows[0], dtFactores, dtCriterios);

                    decimal SumaTotal = dtCalificacion.AsEnumerable().Where(x => x.Field<int>("idFactorPadre") == 0)
                                                                .Sum(x => x.Field<decimal>("Puntaje"));

                    DataRow result = dtPuntajeCalif.AsEnumerable().FirstOrDefault(x => Convert.ToDecimal(x["nMinCalific"]) <= SumaTotal
                                                                        && SumaTotal <= Convert.ToDecimal(x["nMaxCalific"]));
                    int idCalifRiesgo = 0;
                    if (result != null)
                        idCalifRiesgo = (int)result["idCalificativo"];

                    DataSet DSDetalleEval = new DataSet("DSDetalleEval");
                    DSDetalleEval.Tables.Add(dtCalificacion);
                    string xmlDetalle = DSDetalleEval.GetXml();
                    xmlDetalle = clsCNFormatoXML.EncodingXML(xmlDetalle);
                    DSDetalleEval.Tables.Clear();

                    string cEvalBatch = "BATCH";
                    bool lBatch = true;
                    DataTable dtInsercion = _cnScoring.GuardaEvaluacionScoring(idCli, idTipoEval, 1,
                                                                                SumaTotal, idCalifRiesgo, 1,
                                                                                clsVarGlobal.dFecSystem.Date, cEvalBatch, lBatch, xmlDetalle);
                    if (dtInsercion.Rows.Count > 0 && (int)dtInsercion.Rows[0]["idError"] == 0)
                    {
                        item.Cells["lCorrecto"].Value = true;
                        dtgClientes.FirstDisplayedScrollingRowIndex = item.Index;
                        dtgClientes.Update();
                        nCantidadEvaluacioneHechas++;
                    }
                    else
                    {
                        nCantidadEvaluacionesFallidas++;
                    }
                }
                catch (Exception)
                {
                    nCantidadEvaluacionesFallidas++;
                }
                
            }
            Cursor.Current = Cursors.Default;

            CargarClientes();
            MessageBox.Show("Total de evaluaciones hechas con éxito: " + nCantidadEvaluacioneHechas + ", total de evaluaciones fallidas: " + nCantidadEvaluacionesFallidas, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int nCantidadEval = 0;
            string cIdEval = String.Empty;
            //foreach (DataGridViewRow item in this.dtgClientes.Rows)
            //{
            //    if (!String.IsNullOrEmpty(item.Cells["idEvaluacion"].ToString()))
            //    {
            //        nCantidadEval++;
            //        cIdEval += "," + item.Cells["idEvaluacion"].ToString();
            //    }
            //}
            //cIdEval = cIdEval.Substring(1); //cadena de evaluaciones
            //if (nCantidadEval == 0)
            //{
            //    MessageBox.Show("No hay evaluaciones hechas", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}


            MessageBox.Show("Aqui se deben de generar todos los reportes de dichos clientes ", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Metodos

        private void FormatoDatosClientes()
        {
            _dtClientes.Columns["lCorrecto"].ReadOnly = false;
            foreach (DataGridViewColumn item in dtgClientes.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgClientes.Columns["idCli"].Visible = true;
            dtgClientes.Columns["cNombre"].Visible = true;
            dtgClientes.Columns["cTipoPersona"].Visible = true;
            dtgClientes.Columns["cAgenciaReg"].Visible = true;
            dtgClientes.Columns["dFechaIngreso"].Visible = true;
            dtgClientes.Columns["dFechaPrimerEval"].Visible = true;
            dtgClientes.Columns["lCorrecto"].Visible = true;

            dtgClientes.Columns["idCli"].FillWeight = 35;
            dtgClientes.Columns["cNombre"].FillWeight = 120;
            dtgClientes.Columns["cTipoPersona"].FillWeight = 45;
            dtgClientes.Columns["cAgenciaReg"].FillWeight = 50;
            dtgClientes.Columns["dFechaIngreso"].FillWeight = 50;
            dtgClientes.Columns["dFechaPrimerEval"].FillWeight = 50;
            dtgClientes.Columns["lCorrecto"].FillWeight = 20;

            dtgClientes.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgClientes.Columns["cNombre"].HeaderText = "Nombres";
            dtgClientes.Columns["cTipoPersona"].HeaderText = "Tipo persona";
            dtgClientes.Columns["cAgenciaReg"].HeaderText = "Agencia Reg.";
            dtgClientes.Columns["dFechaIngreso"].HeaderText = "Fecha ingreso";
            dtgClientes.Columns["dFechaPrimerEval"].HeaderText = "Fecha Eval.Batch";
            dtgClientes.Columns["lCorrecto"].HeaderText = "Correcto";
        }

        private void VerificarPerfilEvaluador()
        {
            bool lEsPerfil = false;
            DataTable dtPerfil = _cnScoring.ListarPerfilSuperEvalScoring();
            foreach (DataRow item in dtPerfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lEsPerfil = true;
                    break;
                }
            }

            cboAgencia.Enabled = lEsPerfil;
        }

        private void CargarClientes()
        {
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            _dtClientes = _cnScoring.ListarClientesConProd(idAgencia, clsVarGlobal.dFecSystem.Date);
            dtgClientes.DataSource = _dtClientes;
            FormatoDatosClientes();
        }

        #endregion


    }
}
