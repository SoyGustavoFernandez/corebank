using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmGeneracionPlanilla : frmBase
    {
        clsCNPlanilla objPlanilla = new clsCNPlanilla();
        DataTable dtPlanillaPersona;

        public frmGeneracionPlanilla()
        {
            InitializeComponent();
        }

        private void cargarPlanillaPersona(int idTipoPlanilla)
        {
            dtPlanillaPersona = objPlanilla.CNVisualizarPlanillaProceso(idTipoPlanilla);
            dtgPlanillaPersona.DataSource = dtPlanillaPersona;
        }

        private void visualizarConceptosUsuario()
        {
            int iFilaPlanilla = dtgPlanillaPersona.SelectedCells[0].RowIndex;
            int idTipoPlanilla = (int)dtPlanillaPersona.Rows[iFilaPlanilla]["idTipoPlanilla"];
            int idUsuario = (int)dtPlanillaPersona.Rows[iFilaPlanilla]["idUsuario"];

            frmConceptosUsuarioPlanillaTmp frmConceptosUsuarioPlanilla = new frmConceptosUsuarioPlanillaTmp();
            frmConceptosUsuarioPlanilla.x_idTipoPlanilla = idTipoPlanilla;
            frmConceptosUsuarioPlanilla.x_idUsuario = idUsuario;
            frmConceptosUsuarioPlanilla.ShowDialog();

            cargarPlanillaPersona(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
            dtgPlanillaPersona.CurrentCell = dtgPlanillaPersona.Rows[iFilaPlanilla].Cells[2];
        }

        private void frmGeneracionPlanilla_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();

            frmPlanillasTmp frmPlanillasTmp = new frmPlanillasTmp();
            frmPlanillasTmp.ShowDialog();

            if (frmPlanillasTmp.idPeriodoPlanilla == "" && frmPlanillasTmp.idPeriodoDeclaracion == "")
            {
                btnCancelar.Enabled = false;
                btnCerrar.Enabled = false;
            }
            else
            {
                cboRelacionLabInst.SelectedValue = Convert.ToInt32(frmPlanillasTmp.idTipoRelLab);
                cboTipoPlanilla.SelectedValue = Convert.ToInt32(frmPlanillasTmp.idTipoPlanilla);
                cboModalidadPlanilla.SelectedValue = Convert.ToInt32(frmPlanillasTmp.idModalidad);
                cboPeriodoPlanilla.SelectedValue = Convert.ToInt32(frmPlanillasTmp.idPeriodoPlanilla);
                cboPeriodoDeclaracion.SelectedValue = Convert.ToInt32(frmPlanillasTmp.idPeriodoDeclaracion);

                cargarPlanillaPersona(Convert.ToInt32(frmPlanillasTmp.idTipoPlanilla));

                cboRelacionLabInst.Enabled = false;
                cboModalidadPlanilla.Enabled = false;
                cboTipoPlanilla.Enabled = false;
                cboPeriodoPlanilla.Enabled = false;
                cboPeriodoDeclaracion.Enabled = false;

                btnAceptar.Enabled = false;
                btnCancelar.Enabled = true;
                btnCerrar.Enabled = true;
            }
        }

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.ValueMember == "" || cboRelacionLabInst.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
            }
        }

        private void cboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPlanilla.ValueMember == "" || cboTipoPlanilla.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboModalidadPlanilla.ListarModalidadTipoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
                cboPeriodoPlanilla.ListarPeriodoVigenteTipoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idTipoRelLab = Convert.ToInt32(cboRelacionLabInst.SelectedValue);
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
            int idModalidad = Convert.ToInt32(cboModalidadPlanilla.SelectedValue);
            int idPeriodoPlanilla = Convert.ToInt32(cboPeriodoPlanilla.SelectedValue);
            int idPeriodoDeclaracion = Convert.ToInt32(cboPeriodoDeclaracion.SelectedValue);

            DataTable dtListadoPersonal = objPlanilla.CNListarPersonalCalculoPlanilla(idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla);

            //==================================================
            //--Llamar al Formulario
            //==================================================
            frmSeleccionPersonalPlanilla frmSeleccionPersonal = new frmSeleccionPersonalPlanilla();
            frmSeleccionPersonal.x_dtListadoPersonal = dtListadoPersonal.Copy();
            frmSeleccionPersonal.ShowDialog();

            if (frmSeleccionPersonal.dtSeleccionados.Rows.Count > 0)
            {
                cboRelacionLabInst.Enabled = false;
                cboModalidadPlanilla.Enabled = false;
                cboTipoPlanilla.Enabled = false;
                cboPeriodoPlanilla.Enabled = false;
                cboPeriodoDeclaracion.Enabled = false;
                
                DataSet ds = new DataSet("dsPersonalSelec");
                ds.Tables.Add(frmSeleccionPersonal.dtSeleccionados);
                String XmlPersonalSelec = ds.GetXml();
                XmlPersonalSelec = clsCNFormatoXML.EncodingXML(XmlPersonalSelec);

                DataTable dtProcesarPlanilla =  objPlanilla.CNProcesarPlanilla(idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla, idPeriodoDeclaracion, XmlPersonalSelec);
                MessageBox.Show(dtProcesarPlanilla.Rows[0]["cMensaje"].ToString(), "Generación de Planillas", MessageBoxButtons.OK, ((int)dtProcesarPlanilla.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

                if ((int)dtProcesarPlanilla.Rows[0]["idError"] != 0)
                {
                    cboRelacionLabInst.Enabled = true;
                    cboModalidadPlanilla.Enabled = true;
                    cboTipoPlanilla.Enabled = true;
                    cboPeriodoPlanilla.Enabled = true;
                    cboPeriodoDeclaracion.Enabled = true;
                    return;
                }

                btnAceptar.Enabled = false;
                btnCancelar.Enabled = true;
                btnCerrar.Enabled = true;

                cargarPlanillaPersona(idTipoPlanilla);     
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCerrar.Enabled = false;
            btnCancelar.Enabled = false;
            cboRelacionLabInst.Enabled = true;
            cboModalidadPlanilla.Enabled = true;
            cboTipoPlanilla.Enabled = true;
            cboPeriodoPlanilla.Enabled = true;
            cboPeriodoDeclaracion.Enabled = true;
            btnAceptar.Enabled = true;
            dtPlanillaPersona.Clear();
        }

        private void dtgPlanillaPersona_DoubleClick(object sender, EventArgs e)
        {
            visualizarConceptosUsuario();
        }

        private void smiCargaIndividual_Click(object sender, EventArgs e)
        {
            visualizarConceptosUsuario();
        }

        private void smiEliminar_Click(object sender, EventArgs e)
        {
            int iFilaPlanilla = dtgPlanillaPersona.SelectedCells[0].RowIndex;
            int idTipoPlanilla = (int)dtPlanillaPersona.Rows[iFilaPlanilla]["idTipoPlanilla"];
            int idUsuario = (int)dtPlanillaPersona.Rows[iFilaPlanilla]["idUsuario"];

            DataTable dtEliminarUsuario = objPlanilla.CNEliminarUsuarioPlanillaTmp(idTipoPlanilla, idUsuario);

            if ((int)dtEliminarUsuario.Rows[0]["idError"] == 0)
            {
                cargarPlanillaPersona(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
            }

            MessageBox.Show(dtEliminarUsuario.Rows[0]["cMensaje"].ToString(), "Generación de Planillas", MessageBoxButtons.OK, ((int)dtEliminarUsuario.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            btnCerrar.Enabled = false;

            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);

            //=================  Registro Inicio Rastreo ======================
            this.registrarRastreo(0, 0, "Inicio - Generación de planillas", btnCerrar);
            //=================================================================

            DataTable dtCerrarPlanilla = objPlanilla.CNCerrarPlanilla(idTipoPlanilla, clsVarGlobal.dFecSystem, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(0, 0, "Fin - Generación de planillas", btnCerrar);
            //============================================================================
            
            MessageBox.Show(dtCerrarPlanilla.Rows[0]["cMensaje"].ToString(), "Generación de Planillas", MessageBoxButtons.OK, ((int)dtCerrarPlanilla.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

            if ((int)dtCerrarPlanilla.Rows[0]["idError"] != 0)
            {
                btnCerrar.Enabled = true;
                return;
            }

            btnAceptar.Enabled = true;
            btnCancelar.Enabled = false;

            cboRelacionLabInst.Enabled = true;
            cboModalidadPlanilla.Enabled = true;
            cboTipoPlanilla.Enabled = true;
            cboPeriodoPlanilla.Enabled = true;
            cboPeriodoDeclaracion.Enabled = true;

            dtPlanillaPersona.Clear();
        }
    }
}