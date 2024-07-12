using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmBandejaObservaciones : frmBase
    {

        DataTable dtSolicitudes = new DataTable();

        clsCNAprobacion cnAprobacion = new clsCNAprobacion();
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        private ContextMenuStrip cmsOpciones = new ContextMenuStrip();
        private int idRegistro = 0;

        int idSolAproba = 0;

        #region Observaciones Evaluación

        private int idSolicitud = 0;
        List<clsObservacion> listSolicitudes;

        #endregion


        public frmBandejaObservaciones()
        {
            InitializeComponent();
            cargarSolicitudes(clsVarGlobal.PerfilUsu.idUsuario, 0);
            cmsOpciones.Items.Add("Devolver expediente.", null, btnFinalizar1_Click_1);
        }

        public frmBandejaObservaciones(int idSoli)
        {
            InitializeComponent();
            limpiar();
            this.idSolicitud = idSoli;
            cargarSolicitudes(0, this.idSolicitud);
        }

        private void frmBandejaObservaciones_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            dtgObservaciones.DataSource = null;
            dtgSolicitudesObservadas.DataSource = null;
            //btnFinalizar1.Enabled = false;
        }

        private void cargarSolicitudes(int idUsuario, int idRegistro)
        {
            this.dtgObservaciones.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgObservaciones.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgObservaciones.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            limpiar();
            dtSolicitudes = cnAprobacion.ListarSolicitudesObservadas(idUsuario, idRegistro);
            dtgSolicitudesObservadas.DataSource = dtSolicitudes;
            formatoGridSolicitudes();
            dtgSolicitudesObservadas.Focus();
        }

        private void dtgSolicitudesObservadas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSolicitudesObservadas.SelectedRows.Count > 0)
            {
                idRegistro = Convert.ToInt32(dtgSolicitudesObservadas.SelectedRows[0].Cells["idRegistro"].Value);
                idSolAproba = Convert.ToInt32(dtgSolicitudesObservadas.SelectedRows[0].Cells["idSolAproba"].Value);

                int idTipoOperacion = Convert.ToInt32(dtgSolicitudesObservadas.SelectedRows[0].Cells["idTipoOperacion"].Value);
                List<clsObservacion> lstObservaciones = new clsCNObservaciones().CNGetObservaciones(idRegistro, idTipoOperacion);
                dtgObservaciones.DataSource = lstObservaciones.ToList();
                formatoGridObservaciones();
                //btnFinalizar1.Enabled = (Convert.ToInt32(dtgSolicitudesObservadas.Rows[e.RowIndex].Cells["idEstadoCartaFianza"].Value) == 2);
            }
        }

        private void formatoGridSolicitudes()
        {
            foreach (DataGridViewColumn columna in dtgSolicitudesObservadas.Columns)
            {
                columna.Visible = false;
            }

            dtgSolicitudesObservadas.Columns["idRegistro"].Visible = true;
            dtgSolicitudesObservadas.Columns["cNombre"].Visible = true;
            dtgSolicitudesObservadas.Columns["cTipoOperacion"].Visible = true;

            dtgSolicitudesObservadas.Columns["idRegistro"].HeaderText = "Documento";
            dtgSolicitudesObservadas.Columns["cNombre"].HeaderText = "Cliente";
            dtgSolicitudesObservadas.Columns["cTipoOperacion"].HeaderText = "Tipo Operacion";

            dtgSolicitudesObservadas.Columns["idRegistro"].DisplayIndex = 0;
            dtgSolicitudesObservadas.Columns["cNombre"].DisplayIndex = 1;
            dtgSolicitudesObservadas.Columns["cTipoOperacion"].DisplayIndex = 1;

            dtgSolicitudesObservadas.Columns["idRegistro"].FillWeight = 15;
            dtgSolicitudesObservadas.Columns["cNombre"].FillWeight = 50;
            dtgSolicitudesObservadas.Columns["cTipoOperacion"].FillWeight = 35;
        }

        private void formatoGridSolicitudesList()
        {

        }

        private void formatoGridObservaciones()
        {
            foreach (DataGridViewColumn columna in dtgObservaciones.Columns)
            {
                columna.Visible = false;
            }

            dtgObservaciones.Columns["cNivelAproba"].Visible = true;
            dtgObservaciones.Columns["cOrigenObs"].Visible = true;
            dtgObservaciones.Columns["cGrupoObs"].Visible = true;
            dtgObservaciones.Columns["cTipObs"].Visible = true;
            dtgObservaciones.Columns["cObservacion"].Visible = true;
            dtgObservaciones.Columns["lSubsanado"].Visible = true;
            dtgObservaciones.Columns["dFecha"].Visible = true;

            dtgObservaciones.Columns["cNivelAproba"].HeaderText = "Nivel";
            dtgObservaciones.Columns["cOrigenObs"].HeaderText = "Origen";
            dtgObservaciones.Columns["cGrupoObs"].HeaderText = "Grupo Obs.";
            dtgObservaciones.Columns["cTipObs"].HeaderText = "Tipo Obs.";
            dtgObservaciones.Columns["cObservacion"].HeaderText = "Detalle";
            dtgObservaciones.Columns["lSubsanado"].HeaderText = "Subsanado";
            dtgObservaciones.Columns["dFecha"].HeaderText = "Fecha Registro";

            dtgObservaciones.Columns["lSubsanado"].DisplayIndex = 0;
            dtgObservaciones.Columns["cNivelAproba"].DisplayIndex = 1;
            dtgObservaciones.Columns["cOrigenObs"].DisplayIndex = 2;
            dtgObservaciones.Columns["cGrupoObs"].DisplayIndex = 3;
            dtgObservaciones.Columns["cTipObs"].DisplayIndex = 4;
            dtgObservaciones.Columns["cObservacion"].DisplayIndex = 5;
            dtgObservaciones.Columns["dFecha"].DisplayIndex = 6;

            dtgObservaciones.Columns["lSubsanado"].FillWeight = 5;
            dtgObservaciones.Columns["cNivelAproba"].FillWeight = 10;
            dtgObservaciones.Columns["cOrigenObs"].FillWeight = 15;
            dtgObservaciones.Columns["cGrupoObs"].FillWeight = 10;
            dtgObservaciones.Columns["cTipObs"].FillWeight = 20;
            dtgObservaciones.Columns["cObservacion"].FillWeight = 30;
            dtgObservaciones.Columns["dFecha"].FillWeight = 10;

            dtgObservaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnFinalizar1_Click(object sender, EventArgs e)
        {
            DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idRegistro);
            if (dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) > 0)
            {
                MessageBox.Show("Validación: " + System.Environment.NewLine + dtValidar.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtResultado = cnCartaFianza.ActualizarEstadoCartaFianza(idRegistro, 3);

            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("Finalizo con la edición de la carta fianza puede comunicar a los aprobadores.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                clsCreditoProp objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idRegistro);
                objCreditoProp.idOrigenCredProp = 5;
                string xmlCreditoProp = objCreditoProp.GetXml();
                clsDBResp objDbResp = new clsCNSolCre().GuardarCreditoProp(xmlCreditoProp, clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem.Date);
                if (objDbResp.nMsje == 0)
                {
                    cargarSolicitudes(clsVarGlobal.PerfilUsu.idUsuario, 0);
                    MessageBox.Show("Finalizo con la edición de la carta fianza puede comunicar a los aprobadores.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cnCartaFianza.ActualizarEstadoCartaFianza(idRegistro, 2);
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0][1]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                cnCartaFianza.ActualizarEstadoCartaFianza(idRegistro, 2);
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0][1]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgSolicitudesObservadas_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (dtgSolicitudesObservadas.SelectedRows.Count > 0)
                    {
                        int idTipoOpe = Convert.ToInt32(dtgSolicitudesObservadas.SelectedRows[0].Cells["idTipoOperacion"].Value);
                        if (idTipoOpe == 120)
                        {
                            switch (idTipoOpe)
                            {
                                case 120:
                                    cmsOpciones.Items[0].Visible = true;
                                    break;
                            }

                            cmsOpciones.Show(dtgSolicitudesObservadas, dtgSolicitudesObservadas.PointToClient(Cursor.Position));
                        }
                    }
                }
            }
        }

        private void btnFinalizar1_Click_1(object sender, EventArgs e)
        {
            DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idRegistro);
            if (dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) > 0)
            {
                MessageBox.Show("Validación: " + System.Environment.NewLine + dtValidar.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtResultado = cnCartaFianza.ActualizarEstadoCartaFianza(idRegistro, 3);
            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                dtResultado = cnAprobacion.ActualizarMontoSolicitud(idSolAproba);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    cargarSolicitudes(clsVarGlobal.PerfilUsu.idUsuario, 0);
                    MessageBox.Show("Finalizo con la edición de la carta fianza puede comunicar a los aprobadores.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cnCartaFianza.ActualizarEstadoCartaFianza(idRegistro, 2);
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0][1]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0][1]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
