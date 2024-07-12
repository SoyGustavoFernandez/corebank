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
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmVisitaSupervisionResumen : frmBase
    {
        #region Variables
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        public int idVisita = 0;
        public int idTipoVisita = 0;
        public int idSupervisor = 0;
        public bool lSupervisor = false;
        public bool lFinalizado = false;
        public int idEstablecimiento = 0;
        #endregion

        public frmVisitaSupervisionResumen()
        {
            InitializeComponent();
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            frmVisitaSupervisionEvaluacion frmEvaluacion = new frmVisitaSupervisionEvaluacion();
            frmEvaluacion.idVisita = idVisita;
            frmEvaluacion.idTipoVisita = idTipoVisita;
            frmEvaluacion.lEditar = lSupervisor;
            frmEvaluacion.idEstablecimiento = idEstablecimiento;
            frmEvaluacion.ShowDialog();

            listarResumenEvaluacion();
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            frmColaboradorInterviene frmColaborador = new frmColaboradorInterviene();
            frmColaborador.ShowDialog();

            if (frmColaborador.dtRowSelect != null)
            {
                DataRow dtRowSelect = frmColaborador.dtRowSelect;


                foreach (DataGridViewRow row in dtgInterviene.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idUsuario"].Value) == Convert.ToInt32(dtRowSelect["idUsuario"]))
                    {
                        MessageBox.Show("El Usuario ya existe en el listado", "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DataTable dtRes = clsVisita.agregarIntervinienteColaborador(idVisita, Convert.ToInt32(dtRowSelect["idUsuario"]), Convert.ToInt32(dtRowSelect["idPerfil"]), 1);

                if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                {
                    listarIntervieneVisita();
                    formatoInterviene();

                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private bool todosConforme()
        {
            bool lValidar = Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["lConformidadSupervisionOperativa"]));
            if (lValidar)
            {
                DataTable dt = (DataTable)dtgInterviene.DataSource;
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!Convert.ToBoolean(row["lConformidad"]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }
        private void formatoInterviene()
        {
            foreach (DataGridViewColumn item in dtgInterviene.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgInterviene.Columns["cPerfil"].Visible = true;
            dtgInterviene.Columns["cNombre"].Visible = true;
            dtgInterviene.Columns["dFechaConformidad"].Visible = true;

            dtgInterviene.Columns["cPerfil"].HeaderText = "Perfil Asignado";
            dtgInterviene.Columns["cNombre"].HeaderText = "Nombres y Apellidos";
            dtgInterviene.Columns["dFechaConformidad"].HeaderText = "Conforme";
            dtgInterviene.Columns["cPerfil"].FillWeight = 37;
            dtgInterviene.Columns["cNombre"].FillWeight = 47;
            dtgInterviene.Columns["dFechaConformidad"].FillWeight = 16;
        }

        private void listarIntervieneVisita()
        {
            DataTable dtInterviene = clsVisita.listarIntervieneVisita(idVisita);
            dtgInterviene.DataSource = dtInterviene;
            formatoInterviene();
            if (todosConforme() && lSupervisor)
            {
                btnFinalizar1.Visible = true;
            }
            else
            {
                btnFinalizar1.Visible = false;
            }
        }

        private void listarResumenEvaluacion()
        {
            DataSet dsResumenGral = clsVisita.listarResumenEvaluacion(idVisita);
            DataTable dtResumen = dsResumenGral.Tables[0];
            lblCalificativo.Text = dsResumenGral.Tables[1].Rows[0]["cCalificativo"].ToString();

            dtgResumen.DataSource = dtResumen;
            formatoDtgResumen();
        }

        private void formatoDtgResumen()
        {
            foreach (DataGridViewColumn item in dtgResumen.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgResumen.Columns["cGrupo"].Visible = true;
            dtgResumen.Columns["nPonderado"].Visible = true;
            dtgResumen.Columns["nNota"].Visible = true;
            dtgResumen.Columns["nNotaPonderado"].Visible = true;

            dtgResumen.Columns["cGrupo"].HeaderText = "Concepto";
            dtgResumen.Columns["nPonderado"].HeaderText = "Ponderado";
            dtgResumen.Columns["nNota"].HeaderText = "Nota";
            dtgResumen.Columns["nNotaPonderado"].HeaderText = "Nota Ponderado";

            dtgResumen.Columns["cGrupo"].FillWeight = 40;
            dtgResumen.Columns["nPonderado"].FillWeight = 20;
            dtgResumen.Columns["nNota"].FillWeight = 20;
            dtgResumen.Columns["nNotaPonderado"].FillWeight = 20;
        }

        private void frmVisitaSupervisionResumen_Load(object sender, EventArgs e)
        {
            if (idSupervisor == clsVarGlobal.PerfilUsu.idUsuario)
            {
                lSupervisor = true;
            }
            else
            {
                lSupervisor = false;
            }

            listarIntervieneVisita();
            listarResumenEvaluacion();

            DataTable dtDatosVisita = clsVisita.getDatosVisita(idVisita);
            if (Convert.ToInt32(dtDatosVisita.Rows[0]["idEstado"]) == 2 || Convert.ToInt32(dtDatosVisita.Rows[0]["idUsuario"]) != clsVarGlobal.User.idUsuario)
            {
                bloquearControles();
            }

            if (idTipoVisita != 1)
            {
                btnExporExcel1.Visible = false;
            }

        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgInterviene.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un participante.", "Quitar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (Convert.ToBoolean(dtgInterviene.SelectedRows[0].Cells["lConformidad"].Value))
                {
                    MessageBox.Show("No se puede quitar al Usuario, ya dió su Conformidad.", "Quitar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Seguro que desea quitar a este usuario?", "Quitar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    DataTable dtRes = clsVisita.agregarIntervinienteColaborador(idVisita, Convert.ToInt32(dtgInterviene.SelectedRows[0].Cells["idUsuario"].Value),
                        Convert.ToInt32(dtgInterviene.SelectedRows[0].Cells["idPerfil"].Value), 0);
                    if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Quitar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listarIntervieneVisita();
                    }
                    else
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Quitar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtRptResultado = clsVisita.rptResumenVisitaSupervision(idVisita);
            DataSet dtResumen = clsVisita.listarResumenEvaluacion(idVisita);
            DataTable dtDatosResumen = dtResumen.Tables[0];
            DataTable dtIntervinientes = clsVisita.listarIntervieneVisita(idVisita);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dtResumenVisita", dtRptResultado));
            dtslist.Add(new ReportDataSource("dtDatosResumen", dtDatosResumen));
            dtslist.Add(new ReportDataSource("dtIntervinientes", dtIntervinientes));
            string reportpath = "rptResumenVisitaSupervision.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string cTituloMsjes = "Conformidad de Supervisión";
            if (dtgInterviene.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un participante.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtDatosVisita = clsVisita.getDatosVisita(idVisita);
            if (Convert.ToInt32(dtDatosVisita.Rows[0]["nAtendidos"]) < Convert.ToInt32(dtDatosVisita.Rows[0]["nItems"]))
            {
                MessageBox.Show("Acción inválida, No se ha evaluado todos los items de la Visita, falta " +
                    (Convert.ToInt32(dtDatosVisita.Rows[0]["nItems"]) - Convert.ToInt32(dtDatosVisita.Rows[0]["nAtendidos"])) + " item's por evaluar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt32(dtDatosVisita.Rows[0]["nAnexos"]) <= 0 && Convert.ToInt32(dtDatosVisita.Rows[0]["idTipoVisita"]) == 1)
            {
                MessageBox.Show("Acción inválida, No se tiene cargado ningun Anexo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToBoolean(dtgInterviene.SelectedRows[0].Cells["lConformidad"].Value))
            {
                MessageBox.Show("El Usuario ya dió su Conformidad.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmCredenciales frmCredenciales = new frmCredenciales();
            frmCredenciales.cWinUser = dtgInterviene.SelectedRows[0].Cells["cWinUser"].Value.ToString();
            frmCredenciales.ShowDialog();
            if (!frmCredenciales.lValido)
            {
                MessageBox.Show("Confirmación no realizada. Las credenciales no son válidas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.registrarRastreo(Convert.ToInt32(dtgInterviene.SelectedRows[0].Cells["idCli"].Value), 0,
                "Inicio - Registro de Aprobación de Supervisión (idCli: idCli del Aprobador, idusuReg: idUsuario de Loggin)", btnLogin);

            DataTable dtRes = clsVisita.guardarConformidadUsuario(idVisita, Convert.ToInt32(dtgInterviene.SelectedRows[0].Cells["idUsuario"].Value));
            if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarIntervieneVisita();
            }
            else
            {
                MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.registrarRastreo(Convert.ToInt32(dtgInterviene.SelectedRows[0].Cells["idCli"].Value), 0,
                "Fin - Registro de Aprobación de Supervisión (idCli: idCli del Aprobador, idusuReg: idUsuario de Loggin)", btnLogin);
        }

        private void bloquearControles()
        {
            btnLogin.Enabled = false;
            btnMiniAgregar1.Enabled = false;
            btnMiniQuitar1.Enabled = false;
            btnFinalizar1.Visible = false;
        }

        private void btnFinalizar1_Click(object sender, EventArgs e)
        {
            //Se agrega la valdiación de Items completos y Anexo cargado
            string cTituloMsjes = "Validación de Evaluación";
            DataTable dtDatosVisita = clsVisita.getDatosVisita(idVisita);
            if (Convert.ToInt32(dtDatosVisita.Rows[0]["nAtendidos"]) < Convert.ToInt32(dtDatosVisita.Rows[0]["nItems"]))
            {
                MessageBox.Show("Acción inválida, No se ha evaluado todos los items de la Visita, falta " +
                    (Convert.ToInt32(dtDatosVisita.Rows[0]["nItems"]) - Convert.ToInt32(dtDatosVisita.Rows[0]["nAtendidos"])) + " item's por evaluar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToInt32(dtDatosVisita.Rows[0]["nAnexos"]) <= 0 && Convert.ToInt32(dtDatosVisita.Rows[0]["idTipoVisita"]) == 1)
            {
                MessageBox.Show("Acción inválida, No se tiene cargado ningun Anexo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seguro que desea Finalizar la Visita de Supervisión?", "Finalizar Visita", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dtRes = clsVisita.finalizarVisitaSupervision(idVisita, clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Finalizar Visita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarIntervieneVisita();
                    lFinalizado = true;

                    bloquearControles();
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Finalizar Visita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            frmAnexoSupervisionOperacion frmAnexo = new frmAnexoSupervisionOperacion();
            frmAnexo.idVisita = idVisita;
            frmAnexo.ShowDialog();
        }
    }
}
