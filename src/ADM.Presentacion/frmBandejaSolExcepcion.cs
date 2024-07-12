using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmBandejaSolExcepcion : frmBase
    {
        #region Variables

        private DateTime fechaActual = clsVarGlobal.dFecSystem;
        private DateTime fechaInicio = clsVarGlobal.dFecSystem.AddDays(-2);
        clsCNRegAprobaSolicitud clsCNRegAprobaSolicitud = new clsCNRegAprobaSolicitud();
        int idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString());
        DataTable dtBandejaSolExcepcion = new DataTable();

        #endregion

        #region Metodos Publicos

        public frmBandejaSolExcepcion()
        {
            InitializeComponent();
            btnEnviar.SetButtonText("Escalar");
            btnEliminar.SetButtonText("Rechazar");
        }

        #endregion

        #region Metodos Privados

        private void cargarDatos()
        {
            dtBandejaSolExcepcion = new DataTable();
            dtBandejaSolExcepcion = clsCNRegAprobaSolicitud.CNObtenerSolExcepcion(idUsuario, fechaInicio, fechaActual);

            dtgSolExcepcion.DataSource = dtBandejaSolExcepcion;
            if (dtBandejaSolExcepcion != null)
            {
                formatearGrid();
            }
        }
        
        private void formatearGrid()
        {
            foreach (DataGridViewColumn item in dtgSolExcepcion.Columns)
            {
                item.Visible = false;
            }
            dtgSolExcepcion.ScrollBars = ScrollBars.Both;
            dtgSolExcepcion.Columns["idSolExcepcion"].Visible = true;
            dtgSolExcepcion.Columns["idNivelAprRanOpe"].Visible = false;
            dtgSolExcepcion.Columns["cMotivo"].Visible = true;
            dtgSolExcepcion.Columns["cEstadoSol"].Visible = true;
            dtgSolExcepcion.Columns["cNivelAproba"].Visible = true;
            dtgSolExcepcion.Columns["nValorAproba"].Visible = true;
            dtgSolExcepcion.Columns["idSolExcepcion"].HeaderText = "Cod. Solicitud";
            dtgSolExcepcion.Columns["cMotivo"].HeaderText = "Motivo";
            dtgSolExcepcion.Columns["cEstadoSol"].HeaderText = "Estado";
            dtgSolExcepcion.Columns["cNivelAproba"].HeaderText = "Nivel Aprobación";
            dtgSolExcepcion.Columns["nValorAproba"].HeaderText = "Valor por Aprobar";
            dtgSolExcepcion.Columns["nValorAproba"].Width = 100;
            dtgSolExcepcion.Columns["idSolExcepcion"].Width = 100;
            dtgSolExcepcion.Columns["cMotivo"].Width = 150;
            dtgSolExcepcion.Columns["cEstadoSol"].Width = 80;
        }

        #endregion

        #region Eventos

        private void frmBandejaSolExcepcion_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgSolExcepcion.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Estás seguro de eliminar la solicitud de límite de excepción?", "Bandeja de Solicitudes", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }

                int idEstadoSol = Convert.ToInt32(dtgSolExcepcion.CurrentRow.Cells["idEstadoSol"].Value.ToString());

                if (idEstadoSol != 1)
                {
                    MessageBox.Show("Solo se puede eliminar las solicitudes con estado SOLICITAD0.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idSolAproba = Convert.ToInt32(dtgSolExcepcion.CurrentRow.Cells["idSolExcepcion"].Value.ToString());

                int idNivelAprRanOpe = Convert.ToInt32(dtgSolExcepcion.CurrentRow.Cells["idNivelAprRanOpe"].Value.ToString());
                int idEstado = 4; //RECHAZADO
                string cOpinion = "Solicitud de excepción eliminada por el usuario.";
                clsCreditoProp objCreditoProp = new clsCreditoProp();
                string xmlPropSolCred = objCreditoProp.GetXml();

                string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
                string cHora = DateTime.Now.ToString("hh:mm tt");
                string cFechayhora = cFecha + " " + cHora;

                DateTime dresultFechyHora;
                DateTime.TryParse(cFechayhora, out dresultFechyHora);

                DataTable dtAprobaSolicitud = new GEN.CapaNegocio.clsCNAprobacion().CNRegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, 
                                                                                    dresultFechyHora, clsVarGlobal.PerfilUsu.idPerfil, xmlPropSolCred);

                int idRpta = Convert.ToInt32(dtAprobaSolicitud.Rows[0]["idRpta"]);
                MessageBox.Show(dtAprobaSolicitud.Rows[0]["cMensage"].ToString(), "Bandeja de Solicitudes", MessageBoxButtons.OK, (idRpta == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione una solicitud de excepción a eliminar.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (dtgSolExcepcion.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Estás seguro de escalar la solicitud de límite de excepción?", "Bandeja de Solicitudes", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                int idEstadoSol = Convert.ToInt32(dtgSolExcepcion.CurrentRow.Cells["idEstadoSol"].Value.ToString());
                if (idEstadoSol != 1)
                {
                    MessageBox.Show("Solo se puede escalar las solicitudes con estado SOLICITAD0.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dtEscalarSolExcepcion = clsCNRegAprobaSolicitud.CNActualizarAprobadorSolExcep(Convert.ToInt32(dtgSolExcepcion.CurrentRow.Cells["idSolExcepcion"].Value.ToString()));
                if (dtEscalarSolExcepcion.Rows.Count > 0)
                {
                    if (dtEscalarSolExcepcion.Rows[0]["nRespuesta"].ToString() == "1")
                    {
                        MessageBox.Show("Se escalo correctamente la solicitud de limite de excepción.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show(dtEscalarSolExcepcion.Rows[0]["cMensaje"].ToString(), "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al escalar la solicitud de excepción.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una solicitud de excepción a escalar.", "Bandeja de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void dtgSolExcepcion_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int valorDeLaColumna = Convert.ToInt32(dtgSolExcepcion.Rows[e.RowIndex].Cells["idEstadoSol"].Value);

            switch (valorDeLaColumna)
            {
                case 0:
                    dtgSolExcepcion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
                    break;
                case 1:
                    dtgSolExcepcion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
                    break;
                case 2:
                    dtgSolExcepcion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
                case 3:
                    dtgSolExcepcion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;
                    break;
                case 4:
                    dtgSolExcepcion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                    break;
                default:
                    break;
            }            
        }

        #endregion
    }
}