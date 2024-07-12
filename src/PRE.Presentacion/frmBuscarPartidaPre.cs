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
using PRE.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmBuscarPartidaPre : frmBase
        {
        #region Variables Globales
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        private DataTable dtPartidasPresupuestales = new DataTable();

        private int idPartidaSelec;
        private int idLimAplicSelec;

        private decimal nPorcentajeAsigSelec;
        private decimal nPresAperSelec;

        private string cDescripcionSelec;
        private string cTituloMensaje = "Buscar partida presupuestal";

        public int idPeriodoSelec = 0;
        public int idPartidaBuscada;
        public int idLimAplicBuscado;
        public int idNivelAprobacion;

        public string cDescripcionBuscada;
        public decimal nPresAperBuscado;
        public decimal nPorcentajeAsigBuscado;

        #endregion
        #region Eventos
        public frmBuscarPartidaPre()
        {
            InitializeComponent();
        }
        private void frmBuscarPartidaPre_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            listarPartidas();
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            enviarPartidaPres();
        }      
        private void dtgPartidasPresupuestales_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarPartida();
        }
        #endregion
        #region Metodos
        public void buscarPorIdPartida()
        {
            dtPartidasPresupuestales = new DataTable();
            dtPartidasPresupuestales = cnpartidaspres.listarUnaPartida(idPeriodoSelec, idPartidaBuscada);
            if (dtPartidasPresupuestales.Rows.Count > 0)
            {
                dtgPartidasPresupuestales.DataSource = dtPartidasPresupuestales;
                idPartidaSelec = Convert.ToInt32(dtgPartidasPresupuestales.Rows[0].Cells["idPartida"].Value);
                cDescripcionSelec = Convert.ToString(dtgPartidasPresupuestales.Rows[0].Cells["cDescripcion"].Value).Trim();
                nPresAperSelec = Convert.ToDecimal(dtgPartidasPresupuestales.Rows[0].Cells["nPresupuestoApertura"].Value);
                idLimAplicSelec = Convert.ToInt32(dtgPartidasPresupuestales.Rows[0].Cells["idLimAplicacion"].Value);
                nPorcentajeAsigSelec = Convert.ToDecimal(dtgPartidasPresupuestales.Rows[0].Cells["nPorcentajeAsignacion"].Value);
                this.idNivelAprobacion = Convert.ToInt32(dtgPartidasPresupuestales.Rows[0].Cells["idNivelAprobAfectacion"].Value);
                btnAceptar1.Enabled = true;
                enviarPartidaPres();
            }
            else
            {
                MessageBox.Show("No existen partidas presupuestales", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
        private void listarPartidas()
        {
            dtPartidasPresupuestales = new DataTable();
            dtPartidasPresupuestales = cnpartidaspres.listarTodasPartidas(idPeriodoSelec);
            if (dtPartidasPresupuestales.Rows.Count > 0)
            {
                dtgPartidasPresupuestales.DataSource = dtPartidasPresupuestales;
                formatearGrid();
                habilitarCeldas();
            }
            else
            {
                MessageBox.Show("No existen partidas presupuestales", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void formatearGrid()
        {

            dtgPartidasPresupuestales.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgPartidasPresupuestales.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
                
            }
            dtgPartidasPresupuestales.Columns["cDescripcion"].Visible = true;
            dtgPartidasPresupuestales.Columns["cDescripcion"].HeaderText = "Partida Presupuestal";

        }
        private void habilitarCeldas()
        {
            for (int i = 0; i < dtgPartidasPresupuestales.Rows.Count; i++)
                {
                    int editable = Convert.ToInt32(dtgPartidasPresupuestales.Rows[i].Cells["Editable"].Value);
                    if (editable == 1)
                    {
                        
                    }
                    else
                    {
                        dtgPartidasPresupuestales.Rows[i].Cells["cDescripcion"].Style.BackColor = Color.FromArgb(224, 224, 224);
                    }
                }
        }
        private void enviarPartidaPres()
        {
            idPartidaBuscada = idPartidaSelec;
            cDescripcionBuscada = cDescripcionSelec;
            nPresAperBuscado = nPresAperSelec;
            idLimAplicBuscado = idLimAplicSelec;
            nPorcentajeAsigBuscado = nPorcentajeAsigSelec;

            this.Dispose();
        }
        private void seleccionarPartida()
        {
            int nFilaClick = Convert.ToInt32(dtgPartidasPresupuestales.CurrentCell.RowIndex);
            int editable = Convert.ToInt32(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["Editable"].Value);
            if (editable == 1)
            {
                idPartidaSelec = Convert.ToInt32(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["idPartida"].Value);
                cDescripcionSelec = Convert.ToString(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["cDescripcion"].Value).Trim();
                nPresAperSelec = Convert.ToDecimal(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["nPresupuestoApertura"].Value);
                idLimAplicSelec = Convert.ToInt32(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["idLimAplicacion"].Value);
                nPorcentajeAsigSelec = Convert.ToDecimal(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["nPorcentajeAsignacion"].Value);
                this.idNivelAprobacion = Convert.ToInt32(dtgPartidasPresupuestales.Rows[nFilaClick].Cells["idNivelAprobAfectacion"].Value);
                btnAceptar1.Enabled = true;
            }
            else
            {
                btnAceptar1.Enabled = false;
            }
        }
        #endregion
    }
}
