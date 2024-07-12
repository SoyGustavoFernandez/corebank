using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADM.CapaNegocio;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace ADM.Presentacion
{
    public partial class frmAuditoriaTablas : frmBase
    {
        clsCNAuditoriaTablas objAuditoria = new clsCNAuditoriaTablas();

        DataTable dtTblNoAuditadas = new DataTable();
        DataTable dtTblAuditadas = new DataTable();

        public frmAuditoriaTablas()
        {
            InitializeComponent();
        }

        private void cargarListadosTablas()
        {
            dtTblNoAuditadas = objAuditoria.CNListarTablasNoAuditadas();
            dtTblAuditadas = objAuditoria.CNListarTablasAuditadas();

            dtgTblNoAuditadas.DataSource = dtTblNoAuditadas;
            dtgTblAuditadas.DataSource = dtTblAuditadas;

            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void frmAuditoriaTablas_Load(object sender, EventArgs e)
        {
            cargarListadosTablas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtTblNoAuditadas.Rows.Count > 0)
            {
                DataRow drNuevo = dtTblAuditadas.NewRow();
                drNuevo["cTablaAudit"] = dtgTblNoAuditadas.CurrentRow.Cells["dtgTxtTablaNoAudit"].Value;
                drNuevo["lFlagAudit"] = dtgTblNoAuditadas.CurrentRow.Cells["dtgChcFlagNoAudit"].Value;
                dtTblAuditadas.Rows.Add(drNuevo);
                dtTblNoAuditadas.Rows.RemoveAt(dtgTblNoAuditadas.CurrentRow.Index);

                btnCancelar.Enabled = true;
                btnGrabar.Enabled = true;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtTblAuditadas.Rows.Count > 0)
            {
                DataRow drNuevo = dtTblNoAuditadas.NewRow();
                drNuevo["cTablaNoAudit"] = dtgTblAuditadas.CurrentRow.Cells["dtgTxtTablaAudit"].Value;
                drNuevo["lFlagNoAudit"] = dtgTblAuditadas.CurrentRow.Cells["dtgChcFlagAudit"].Value;
                dtTblNoAuditadas.Rows.Add(drNuevo);
                dtTblAuditadas.Rows.RemoveAt(dtgTblAuditadas.CurrentRow.Index);

                btnCancelar.Enabled = true;
                btnGrabar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarListadosTablas();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dtRespuesta = new DataTable();

            for (int i = 0; i < dtTblNoAuditadas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtTblNoAuditadas.Rows[i]["lFlagNoAudit"]) == true)
                {
                    dtRespuesta = objAuditoria.CNDeshabilitarAuditoriaTablas(Convert.ToString(dtTblNoAuditadas.Rows[i]["cTablaNoAudit"]));

                    if ((int)dtRespuesta.Rows[0]["idError"] != 0)
                    {
                        MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString(), "Auditoría de Tablas", MessageBoxButtons.OK, ((int)dtRespuesta.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                        cargarListadosTablas();
                        return;
                    }
                }
            }

            for (int i = 0; i < dtTblAuditadas.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtTblAuditadas.Rows[i]["lFlagAudit"]) == false)
                {
                    dtRespuesta = objAuditoria.CNHabilitarAuditoriaTabla(Convert.ToString(dtTblAuditadas.Rows[i]["cTablaAudit"]));

                     if ((int)dtRespuesta.Rows[0]["idError"] != 0)
                     {
                         MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString(), "Auditoría de Tablas", MessageBoxButtons.OK, ((int)dtRespuesta.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                         cargarListadosTablas();
                         return;
                     }
                }
            }

            if (dtRespuesta.Rows.Count > 0)
            {
                MessageBox.Show("Se Habilito/Deshabilito exitosamente la Auditoria de Tablas", "Auditoría de Tablas", MessageBoxButtons.OK, ((int)dtRespuesta.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            cargarListadosTablas();
        }
    }
}
