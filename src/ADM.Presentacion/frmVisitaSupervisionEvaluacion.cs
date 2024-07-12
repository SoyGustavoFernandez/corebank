using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;

namespace ADM.Presentacion
{
    public partial class frmVisitaSupervisionEvaluacion : frmBase
    {
        #region Variables
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        public bool lEditar = true;
        private DataTable dtPreguntas = new DataTable();
        private DataTable dtPreguntaSelect = new DataTable();
        public int idVisita = 0;
        private int idPreguntaSelect = 0;
        private int nOrdenSelect = 0;
        public int idTipoVisita;
        public int idEstablecimiento = 0;
        #endregion

        #region Metodos
        public frmVisitaSupervisionEvaluacion()
        {
            InitializeComponent();
        }

        private void agregarGrupoPreguntas()
        {
            DataTable dtGrupoPreg = clsVisita.listarGrupoPreguntas(idTipoVisita);
            cboGrupoPregunta.ValueMember = "idGrupo";
            cboGrupoPregunta.DisplayMember = "cGrupo";
            cboGrupoPregunta.DataSource = dtGrupoPreg;
            if (dtGrupoPreg.Rows.Count > 0)
            {
                cboGrupoPregunta.SelectedIndex = 0;
            }
            else
            {
                cboGrupoPregunta.SelectedIndex = -1;
            }
        }

        private void toggleButton(string btnPres)
        {
            if (btnPres == "")
                return;

            string cNota = "0";
            if (dtPreguntaSelect.Rows.Count > 0)
            {
                DataRow row = dtPreguntaSelect.Rows[0];
                cNota = row["nNota"].ToString();
            }

            if (btnPres == "SI")
            {
                btnSi.BackColor = Color.FromArgb(0, 204, 0);
                btnSi.ForeColor = Color.White;
                btnNo.BackColor = Color.FromArgb(224, 224, 224);
                btnNo.ForeColor = Color.Black;
                lblNota.Text = cNota;
                txtCumple.Text = "SI";
            }
            else
            {
                btnSi.BackColor = Color.FromArgb(224, 224, 224);
                btnSi.ForeColor = Color.Black;
                btnNo.BackColor = Color.FromArgb(228, 70, 61);
                btnNo.ForeColor = Color.White;
                lblNota.Text = "0";
                txtCumple.Text = "NO";
            }
        }

        private DataTable listarPreguntasDeGrupo(int idGrupo, int idPregunta)
        {
            string cQuery = "idGrupo=" + idGrupo;
            if (idPregunta != -1)
            {
                cQuery += "AND idPregunta=" + idPregunta;
            }
            DataTable dtPreguntasTmp = new DataTable();
            DataRow[] dtRow = dtPreguntas.Select(cQuery);
            return (DataTable)dtRow.CopyToDataTable();
        }

        private void ponerPregunta(DataTable dtPregSelect)
        {
            DataRow row = dtPregSelect.Rows[0];

            lblPregunta.Text = row["cPregunta"].ToString();
            lblTextoAyuda.Text = row["cTexto"].ToString();

            pnlOpcion1.Visible = false;
            pnlOpcion2.Visible = false;
            if (Convert.ToInt32(row["idTipo"]) == 1)
            {
                pnlOpcion1.Visible = true;
            }
            else
            {
                pnlOpcion2.Visible = true;
            }

            pnlPregunta.Visible = true;

        }

        private void ponerDiferencia()
        {
            txtCantDiferencia.Text = (Convert.ToDecimal(txtCantSistema.Text) - Convert.ToDecimal(txtCantFisico.Text)).ToString();

            if ((Convert.ToDecimal(txtCantSistema.Text) - Convert.ToDecimal(txtCantFisico.Text)) == 0)
            {
                string cNota = "0";
                if (dtPreguntaSelect.Rows.Count > 0)
                {
                    DataRow row = dtPreguntaSelect.Rows[0];
                    cNota = row["nNota"].ToString();
                }

                lblNota.Text = cNota;
            }
            else
            {
                lblNota.Text = "0";
            }

        }
        private void reiniciarPregunta()
        {
            txtCumple.Text = "";
            btnSi.BackColor = Color.FromArgb(224, 224, 224);
            btnSi.ForeColor = Color.Black;
            btnNo.BackColor = Color.FromArgb(224, 224, 224);
            btnNo.ForeColor = Color.Black;

            txtCantSistema.Text = "0";
            txtCantFisico.Text = "0";
            txtCantDiferencia.Text = "0";
            lblNota.Text = "-";

            txtComentario.Text = "";
        }

        private void asignarControl()
        {
            pnlPregunta.Enabled = lEditar;
            btnGrabar1.Enabled = lEditar;
        }

        private void bloquearPregunta(bool lBloqueo)
        {
            if (!lEditar)
                lBloqueo = true;

            btnEditar1.Enabled = lBloqueo;
            btnGrabar1.Enabled = !lBloqueo;
            pnlPregunta.Enabled = !lBloqueo;
            lblEstado.Text = "HABILITADO";
            if (lBloqueo)
            {
                lblEstado.Text = "DESHABILITADO";
            }
        }

        private int getOrdenPregunta(int idPregunta)
        {
            DataTable dt = (DataTable)cboPregunta.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["idPregunta"]) == idPregunta)
                {
                    lblNumPregunta.Text = row["nOrden"].ToString() + " / " + dt.Rows.Count;
                    return Convert.ToInt32(row["nOrden"]);
                }
            }
            lblNumPregunta.Text = "- / -";
            return 0;
        }

        private void listarPreguntasPorGrupo(int idPreguntaSeleccionada)
        {
            DataTable dtPreguntasxGrupo = clsVisita.listarBloquePreguntas(Convert.ToInt32(cboGrupoPregunta.SelectedValue), idVisita);
            dtPreguntas = dtPreguntasxGrupo;
            cboPregunta.ValueMember = "idpregunta";
            cboPregunta.DisplayMember = "cPregunta";
            cboPregunta.DataSource = dtPreguntasxGrupo;

            if (dtPreguntasxGrupo.Rows.Count > 0 && idPreguntaSeleccionada == 0)
            {
                idPreguntaSeleccionada = Convert.ToInt32(dtPreguntasxGrupo.Rows[0]["idPregunta"]);
            }

            if (dtPreguntasxGrupo.Rows.Count > 0)
            {
                cboPregunta.SelectedValue = idPreguntaSeleccionada;
            }
            else
            {
                cboPregunta.SelectedIndex = -1;
                nOrdenSelect = 0;
            }
        }

        private void mostrarCantidadPreguntas()
        {
            DataTable dtCant = clsVisita.listarCantidadPregunta(idVisita, Convert.ToInt32(cboGrupoPregunta.SelectedValue));
            lblCantidadVisita.Text = dtCant.Rows[0]["nCantEvalVisita"].ToString() + " / " + dtCant.Rows[0]["nCantPregVisita"].ToString();
            lblCantidadGrupo.Text = dtCant.Rows[0]["nCantEvalGrupo"].ToString() + " / " + dtCant.Rows[0]["nCantPregGrupo"].ToString();
        }

        private void cambiarOrdenPregunta(int nPos)
        {
            DataTable dt = (DataTable)cboPregunta.DataSource;

            if (nPos != 0)
            {
                int idPregunta = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["nOrden"]) == nOrdenSelect + nPos)
                    {
                        idPregunta = Convert.ToInt32(row["idPregunta"]);
                        break;
                    }
                }
                cboPregunta.SelectedValue = idPregunta;
            }

            if (nOrdenSelect == dt.Rows.Count)
            {
                btnSiguiente.Enabled = false;
            }
            else
            {
                btnSiguiente.Enabled = true;
            }

            if (nOrdenSelect <= 1)
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }
        }

        private void bloquearControles()
        {
            pnlPreguntaGral.Enabled = false;
            btnEditar1.Visible = false;
            btnGrabar1.Visible = false;
            btnAdjuntar.Text = "Adjuntados";
        }
        #endregion
        /*******************************************************************************************************/
        #region Eventos
        private void frmVisitaSupervisionEvaluacion_Load(object sender, EventArgs e)
        {
            asignarControl();
            dtPreguntas = clsVisita.listarBloquePreguntas(0, 0);
            agregarGrupoPreguntas();

            DataTable dtDatosVisita = clsVisita.getDatosVisita(idVisita);
            if (Convert.ToInt32(dtDatosVisita.Rows[0]["idEstado"]) == 2 || Convert.ToInt32(dtDatosVisita.Rows[0]["idUsuario"]) != clsVarGlobal.User.idUsuario || Convert.ToInt32(dtDatosVisita.Rows[0]["nConformidad"]) > 0)
            {
                bloquearControles();
                lEditar = false;
            }
        }

        private void cboGrupoPregunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoPregunta.SelectedIndex != -1)
            {
                listarPreguntasPorGrupo(0);
                mostrarCantidadPreguntas();
            }
        }

        private void cboPregunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPregunta.SelectedIndex != -1)
            {
                idPreguntaSelect = Convert.ToInt32(cboPregunta.SelectedValue);
                dtPreguntaSelect = listarPreguntasDeGrupo(Convert.ToInt32(cboGrupoPregunta.SelectedValue), Convert.ToInt32(cboPregunta.SelectedValue));
                ponerPregunta(dtPreguntaSelect);

                reiniciarPregunta();
                if (idPreguntaSelect.In(1, 2))
                {
                    btnBilletaje.Visible = true;
                }
                else
                {
                    btnBilletaje.Visible = false;
                }

                DataTable dtDatosRespuesta = clsVisita.listarDatosRespuestaPregunta(idVisita, Convert.ToInt32(cboPregunta.SelectedValue));
                if (dtDatosRespuesta.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDatosRespuesta.Rows[0]["idTipo"]) != 0)
                    {
                        bloquearPregunta(true);
                        lblNota.Text = dtDatosRespuesta.Rows[0]["nNota"].ToString();

                        if (Convert.ToInt32(dtDatosRespuesta.Rows[0]["idTipo"]) == 1)
                        {
                            toggleButton(dtDatosRespuesta.Rows[0]["nValor"].ToString());
                            txtComentario.Text = dtDatosRespuesta.Rows[0]["cValor"].ToString();
                        }
                        else
                        {
                            txtCantDiferencia.Text = dtDatosRespuesta.Rows[0]["nValor"].ToString();
                            txtCantSistema.Text = dtDatosRespuesta.Rows[0]["cValor"].ToString();
                            txtCantFisico.Text = dtDatosRespuesta.Rows[1]["cValor"].ToString();
                        }
                    }
                    else
                    {
                        bloquearPregunta(false);
                    }

                    if (dtDatosRespuesta.Rows[0]["nArchivos"].ToString() == "0")
                        btnAdjuntar.Text = "Adjuntar";
                    else
                        btnAdjuntar.Text = "Adjuntar (" + dtDatosRespuesta.Rows[0]["nArchivos"].ToString() + ")";
                }
                else
                {
                    btnAdjuntar.Text = "Adjuntar";
                }

                nOrdenSelect = getOrdenPregunta(idPreguntaSelect);
                cambiarOrdenPregunta(0);
            }

        }

        private void txtCantSistema_TextChanged(object sender, EventArgs e)
        {
            if (txtCantSistema.Text == "")
            {
                txtCantSistema.Text = "0";
                txtCantSistema.SelectAll();
            }
            ponerDiferencia();
        }

        private void txtCantFisico_TextChanged(object sender, EventArgs e)
        {
            if (txtCantFisico.Text == "")
            {
                txtCantFisico.Text = "0";
                txtCantFisico.SelectAll();
            }
            ponerDiferencia();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            toggleButton("SI");
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            toggleButton("NO");
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataRow row = dtPreguntaSelect.Rows[0];

            if (Convert.ToInt32(row["idPregunta"]).In(1, 2))
            {
                string cTipoSupervision = "";
                if (Convert.ToInt32(row["idPregunta"]) == 1)
                {
                    cTipoSupervision = "ArqueoBoveda";
                }
                else if (Convert.ToInt32(row["idPregunta"]) == 2)
                {
                    cTipoSupervision = "ArqueoVentanilla";
                }

                DataTable dtValidaArqueo = clsVisita.validarArqueoInopinado(idVisita, cTipoSupervision);
                if( dtValidaArqueo.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtValidaArqueo.Rows[0]["idRespuesta"]) == 0)
                    {
                        MessageBox.Show(dtValidaArqueo.Rows[0]["cMensaje"].ToString(), "Guardar Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            

            if (lblNota.Text == "-")
            {
                MessageBox.Show("Debe seleccionar/llenar una opción para poder Guardar su respuesta", "Guardar Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(cboGrupoPregunta.SelectedValue) != -1 && (Convert.ToInt32(cboPregunta.SelectedValue) == Convert.ToInt32(row["idPregunta"])) && idVisita != 0)
            {
                DataTable dtRes = clsVisita.guardarRespuesta(
                    idVisita, Convert.ToInt32(row["idPregunta"]),
                    txtCumple.Text, txtComentario.Text,
                    Convert.ToInt32(txtCantSistema.Text), Convert.ToInt32(txtCantFisico.Text), Convert.ToInt32(txtCantDiferencia.Text),
                    Convert.ToDecimal(lblNota.Text));

                if (Convert.ToInt32(dtRes.Rows[0]["idRespuesta"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Guardar Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarPreguntasPorGrupo(idPreguntaSelect);
                    mostrarCantidadPreguntas();
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Guardar Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error, vuelva a seleccionar la pregunta", "Guardar Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            bloquearPregunta(false);
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            cambiarOrdenPregunta(1);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            cambiarOrdenPregunta(-1);
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            frmArchivoSupervisionOperacion frmArchivo = new frmArchivoSupervisionOperacion();
            frmArchivo.idVisita = idVisita;
            frmArchivo.idPregunta = idPreguntaSelect;
            frmArchivo.lEdicion = lEditar;
            frmArchivo.ShowDialog();

            DataTable dtDatosRespuesta = clsVisita.listarDatosRespuestaPregunta(idVisita, Convert.ToInt32(cboPregunta.SelectedValue));
            if (dtDatosRespuesta.Rows.Count > 0)
            {
                btnAdjuntar.Text = "Adjuntar (" + dtDatosRespuesta.Rows[0]["nArchivos"].ToString() + ")";
            }
            else
            {
                btnAdjuntar.Text = "Adjuntar";
            }
        }

        private void btnBilletaje_Click(object sender, EventArgs e)
        {
            string cTipoVisita = "";
            if (idPreguntaSelect == 1)
            {
                cTipoVisita = "ArqueoBoveda";
            }
            else if (idPreguntaSelect == 2)
            {
                cTipoVisita = "ArqueoVentanilla";
            }
            frmBilletaje frmBilletaje = new frmBilletaje();
            frmBilletaje.idVisita = idVisita;
            frmBilletaje.cTipoVisita = cTipoVisita;
            frmBilletaje.idEstablecimiento = idEstablecimiento;
            frmBilletaje.lBtnFinalizar = false;
            frmBilletaje.ShowDialog();

            if (!Convert.ToBoolean(dtPreguntaSelect.Rows[0]["lEvaluado"]))
            {
                DataTable dtDiferencia = clsVisita.obtenerDiferenciaArqueoInopinado(idVisita, cTipoVisita);
                if (Convert.ToInt32(dtDiferencia.Rows[0]["nDiferenciaArqueo"]) == 0)
                {
                    toggleButton("SI");
                    MessageBox.Show(dtDiferencia.Rows[0]["cMensaje"].ToString(), "Validación de Diferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToInt32(dtDiferencia.Rows[0]["nDiferenciaArqueo"]) == 1)
                {
                    toggleButton("NO");
                    MessageBox.Show(dtDiferencia.Rows[0]["cMensaje"].ToString(), "Validación de Diferencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(dtDiferencia.Rows[0]["cMensaje"].ToString(), "Validación de Diferencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion
    }
}
