using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmGanadoresProceso : frmBase
    {

        #region Variables

        private const string cTituloMsjes = "Ganador de proceso de adquisición.";
        private readonly int idUsuario = clsVarGlobal.User.idUsuario;
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
        private List<clsDetalleProcesoAdj> _lstDetProcAdj;
        private List<clsVinculoProveedor> _lstProveedores;
        private List<Grupo> _lstGrupos;
        private clsProcesoAdjudicacion _objProceso;
        private clsCNProcesoAdjudicacion _objCNProc;

        public bool lConfirmacion { get; private set; }

        #endregion

        #region Constructores

        public frmGanadoresProceso()
        {
            InitializeComponent();
            _lstGrupos = new List<Grupo>();
            _objCNProc = new clsCNProcesoAdjudicacion();
            lConfirmacion = false;
        }

        public frmGanadoresProceso(clsProcesoAdjudicacion objProceso) : this()
        {
            _objProceso = objProceso;
            _lstDetProcAdj = objProceso.listaDetalleProAdj.ToList();
            _lstProveedores = objProceso.LstProveedores.ToList();
        }

        #endregion

        #region Eventos

        private void frmGanadoresProceso_Load(object sender, EventArgs e)
        {
            dtgProveedores.AutoGenerateColumns = false;
            AsignarGanadores();
            FillGrupos();
        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalleGrupo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            var result = _lstGrupos.GroupJoin(_lstProveedores,
                                                x => x.idGrupo,
                                                y => y.nGrupo,
                                                (a, b) => new { a.idGrupo, nNum = b.Count(t => t.lGanadorTemp.Value) });
            if (result.Any(x => x.nNum == 0))
            {
                var resultQuestion = MessageBox.Show("Existen grupos sin ganador.¿Desea declarar desierto el proceso?",
                                                cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultQuestion != DialogResult.Yes)
                    return;

                clsDBResp objDbResp = _objCNProc.CNDeclararDesiertoProceso(_objProceso.idProceso, idUsuario, dFechaSis);
                if (objDbResp.nMsje == 0)
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lConfirmacion = true;
                    Dispose();
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            var objDbRespAct = _objCNProc.CNActualizaGanadoresProceso(_lstProveedores, idUsuario, dFechaSis);
            if (objDbRespAct.nMsje == 0)
            {
                MessageBox.Show(objDbRespAct.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lConfirmacion = true;
                Dispose();
            }
            else
            {
                MessageBox.Show(objDbRespAct.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Métodos

        private bool Validar()
        {
            var result = _lstGrupos.GroupJoin(_lstProveedores,
                                                x => x.idGrupo,
                                                y => y.nGrupo,
                                                (a, b) => new { a.idGrupo, nNum = b.Count(t => t.lGanadorTemp.Value) });

            if (result.Any(x => x.nNum > 1))
            {
                MessageBox.Show("Solo puede haber un ganador por grupo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void FillGrupos()
        {
            dtgGrupos.SelectionChanged -= dtgGrupo_SelectionChanged;

            var grupos = _lstDetProcAdj.GroupBy(x => new { x.idGrupo, x.cDesGrupo });
            foreach (var grupo in grupos)
            {
                _lstGrupos.Add(new Grupo(grupo.Key.idGrupo.Value, grupo.Key.cDesGrupo));
                dtgGrupos.Rows.Add(grupo.Key.idGrupo, grupo.Key.cDesGrupo);
            }

            dtgGrupos.ClearSelection();

            dtgGrupos.SelectionChanged += dtgGrupo_SelectionChanged;

            if (dtgGrupos.RowCount > 0)
                dtgGrupos.Rows[0].Selected = true;
        }

        private void ActualizarDetalleGrupo()
        {
            if (dtgGrupos.RowCount <= 0)
                return;

            if (dtgGrupos.SelectedRows.Count == 0)
                return;

            int idGrupo = Convert.ToInt32(dtgGrupos.SelectedRows[0].Cells["Grupo"].Value);

            FillProveedores(idGrupo);
        }

        private void FillProveedores(int idGrupo)
        {
            dtgProveedores.DataSource = _lstProveedores.Where(x => x.nGrupo == idGrupo)
                                                        .OrderByDescending(x => x.nPuntaje)
                                                        .ToList();
            FormatoGridProveedores(idGrupo);
        }

        private bool AsignarGanadores()
        {
            var puntajesMaximos = _lstProveedores
                                        .Where(x => x.nPuntaje > 0)
                                        .GroupBy(x => x.nGrupo)
                                        .Select(x => new { idGrupo = x.Key, nMax = x.Max(y => y.nPuntaje) }).ToList();

            foreach (var grupo in puntajesMaximos)
            {
                var ganadores = _lstProveedores.Where(x => x.nGrupo == grupo.idGrupo && x.nPuntaje == grupo.nMax);
                if (ganadores.Count() == 1)
                {
                    ganadores.First().lGanadorTemp = true;
                }
            }
            return false;
        }

        private void FormatoGridProveedores(int idGrupo)
        {
            dtgProveedores.ReadOnly = false;
            foreach (DataGridViewRow row in dtgProveedores.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.Cells["lGanadorTempColumn"].ReadOnly = true;
            }
            var puntajesMaximos = _lstProveedores
                                        .Where(x => x.nPuntaje > 0)
                                        .GroupBy(x => x.nGrupo)
                                        .Select(x => new { idGrupo = x.Key, nMax = x.Max(y => y.nPuntaje) }).ToList();

            var ptjeGrupo = puntajesMaximos.Where(x => x.idGrupo == idGrupo).FirstOrDefault();
            if (ptjeGrupo == null)
                return;

            var ganadores = _lstProveedores.Where(x => x.nPuntaje == ptjeGrupo.nMax);

            foreach (DataGridViewRow row in dtgProveedores.Rows)
            {
                var objProv = row.DataBoundItem as clsVinculoProveedor;
                if (objProv.idProveedor.In(ganadores.Select(x => x.idProveedor).ToArray()))
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    if (ganadores.Count() > 1)
                    {
                        row.Cells["lGanadorTempColumn"].ReadOnly = false;
                    }
                }
            }
        }

        #endregion

    }
}
