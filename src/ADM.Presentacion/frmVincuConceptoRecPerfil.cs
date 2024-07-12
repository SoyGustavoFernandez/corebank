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
using CAJ.CapaNegocio;
using EntityLayer;
using ADM.CapaNegocio;
using GEN.CapaNegocio;
namespace ADM.Presentacion
{
    public partial class frmVincuConceptoRecPerfil : frmBase
    {

        #region Variables

        DataTable dtConceptoAsig=new DataTable();
        DataTable tbConcepNoAsig = new DataTable();       
        clsCNMantConcepRec Conceptos = new clsCNMantConcepRec();

        #endregion

        #region Eventos

        private void frmVincuConceptoRecPerfil_Load(object sender, EventArgs e)
        {
            cboTipRec.SelectedIndexChanged -= new EventHandler(cboTipRec_SelectedIndexChanged);
            CargarTiporecibos();
            cboTipRec.SelectedIndexChanged += new EventHandler(cboTipRec_SelectedIndexChanged);
            cboTipRec.SelectedIndex = -1;
            cboPerfiles.SelectedIndex = -1;

            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = true;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerfiles.SelectedValue != null && cboTipRec.SelectedValue != null && !(cboTipRec.SelectedValue is DataRowView))
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));
                CargarConcepRecibosPerfil(Convert.ToInt32(cboPerfiles.SelectedValue));
            }
        }

        private void cboPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPerfiles.SelectedValue != null && cboTipRec.SelectedValue != null && !(cboPerfiles.SelectedValue is DataRowView))
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));
                CargarConcepRecibosPerfil(Convert.ToInt32(cboPerfiles.SelectedValue.ToString()));
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgConceptoNoAsig.Rows.Count > 0)
            {
                if (dtgConceptoNoAsig.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el concepto que desea asignar.", "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dtgConceptoNoAsig.Focus();
                int idConcepto;
                idConcepto = Convert.ToInt32(dtgConceptoNoAsig.SelectedRows[0].Cells["idConcepto"].Value.ToString());

                object ncantida;
                ncantida = dtConceptoAsig.Compute("Count(idConcepto)", "idConcepto=" + idConcepto.ToString());
                if ((int)ncantida > 0)
                {
                    MessageBox.Show("El Concepto ya está Asignado al Perfil ", "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow drNuevo = dtConceptoAsig.NewRow();
                drNuevo["idConcepto"] = idConcepto;
                drNuevo["cConcepto"] = dtgConceptoNoAsig.SelectedRows[0].Cells["cConcepto"].Value.ToString();
                drNuevo["nMontoCon"] = Convert.ToDecimal(dtgConceptoNoAsig.SelectedRows[0].Cells["nMontoCon"].Value.ToString());
                drNuevo["cEstado"] = dtgConceptoNoAsig.SelectedRows[0].Cells["cEstado"].Value.ToString();
                drNuevo["Est"] = dtgConceptoNoAsig.SelectedRows[0].Cells["Est"].Value.ToString();
                dtConceptoAsig.Rows.Add(drNuevo);

                var drElimina = tbConcepNoAsig.AsEnumerable().Where(x => (int)x["idConcepto"] == idConcepto).ToList()[0];

                dtgConcepAsig.Rows[dtgConcepAsig.RowCount - 1].Selected = true;
                dtgConcepAsig.FirstDisplayedScrollingRowIndex = dtgConcepAsig.RowCount - 1;
                tbConcepNoAsig.Rows.Remove(drElimina);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgConcepAsig.Rows.Count > 0)
            {
                if (dtgConcepAsig.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el concepto que desea quitar.", "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dtgConcepAsig.Focus();
                int idConcepto;
                idConcepto = Convert.ToInt32(dtgConcepAsig.SelectedRows[0].Cells["idConcepto"].Value.ToString());

                var ncantida = (int)tbConcepNoAsig.Compute("Count(idConcepto)", "idConcepto=" + idConcepto.ToString());
                if (ncantida > 0)
                {
                    MessageBox.Show("El Concepto ya está Asignado al Perfil ", "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow drNuevo = this.tbConcepNoAsig.NewRow();
                drNuevo["idConcepto"] = idConcepto;
                drNuevo["cConcepto"] = dtgConcepAsig.SelectedRows[0].Cells["cConcepto"].Value.ToString();
                drNuevo["nMontoCon"] = Convert.ToDecimal(dtgConcepAsig.SelectedRows[0].Cells["nMontoCon"].Value.ToString());
                drNuevo["cEstado"] = dtgConcepAsig.SelectedRows[0].Cells["cEstado"].Value.ToString();
                drNuevo["Est"] = dtgConcepAsig.SelectedRows[0].Cells["Est"].Value.ToString();
                tbConcepNoAsig.Rows.Add(drNuevo);

                var drElimina = dtConceptoAsig.AsEnumerable().Where(x => (int)x["idConcepto"] == idConcepto).ToList()[0];
                dtConceptoAsig.Rows.Remove(drElimina);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de Asignar los Conceptos al perfiles?", "Asignar Conceptos a Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int idTipRecibo = Convert.ToInt32(cboTipRec.SelectedValue);
                int idPerfil = Convert.ToInt32(cboPerfiles.SelectedValue);

                DataSet ds = new DataSet("dtConceptoAsig");
                ds.Tables.Add(dtConceptoAsig);
                string XmlConceptoAsignado = ds.GetXml();

                DataTable dtResp = Conceptos.GrabarConceptoXPerfil(idTipRecibo, idPerfil, XmlConceptoAsignado);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString(), "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarConcepRecibosPerfil(Convert.ToInt32(cboPerfiles.SelectedValue));

                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    cboPerfiles.Enabled = true;
                    cboTipRec.Enabled = true;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString(), "Asignar Conceptos a Perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (cboPerfiles.SelectedValue != null)
            {
                CargarConcepRecibosPerfil(Convert.ToInt32(cboPerfiles.SelectedValue));
            }
            if (cboTipRec.SelectedValue != null)
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));
            }
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = true;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            cboPerfiles.Enabled = true;
            cboTipRec.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            cboPerfiles.Enabled = false;
            cboTipRec.Enabled = false;
        }

        #endregion

        #region Metodos

        public frmVincuConceptoRecPerfil()
        {            
            InitializeComponent();
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();     
            cboTipRec.ValueMember = "idTipRecibo";
            cboTipRec.DisplayMember = "cDescripcion";
            cboTipRec.DataSource = tbTipRec;
        }

        private void CargarConceptos(int idTipRecibo)
        {
            if (cboPerfiles.SelectedIndex >= 0 && cboTipRec.SelectedIndex>=0)
            {
                tbConcepNoAsig = Conceptos.ListarConcepNoAsigandoPerfil(idTipRecibo, Convert.ToInt32(cboPerfiles.SelectedValue));
                if (dtgConceptoNoAsig.ColumnCount > 0)
                {
                    dtgConceptoNoAsig.Columns.Clear();
                }
                dtgConceptoNoAsig.DataSource = tbConcepNoAsig.DefaultView;
                formatoConceptoRecibo();
            }
            else
            {
                if (dtgConceptoNoAsig.ColumnCount > 0)
                {
                    dtgConceptoNoAsig.Columns.Clear();
                }
                dtgConceptoNoAsig.DataSource = null;
            }
        }

        private void CargarConcepRecibosPerfil(int idPerfil)
        {
            if (cboPerfiles.SelectedIndex >= 0 && cboTipRec.SelectedIndex >= 0)
            {
                int idTipoRec = Convert.ToInt32(cboTipRec.SelectedValue);
                dtConceptoAsig = Conceptos.ListarConceptoXPerfil(idPerfil, idTipoRec);

                if (dtgConcepAsig.ColumnCount > 0)
                {
                    dtgConcepAsig.Columns.Remove("idConcepto");
                    dtgConcepAsig.Columns.Remove("cConcepto");
                    dtgConcepAsig.Columns.Remove("nMontoCon");
                    dtgConcepAsig.Columns.Remove("cEstado");
                }
                dtgConcepAsig.DataSource = dtConceptoAsig.DefaultView;
                FormatoDtgConceptosRec();
            }
            else
            {
                if (dtgConcepAsig.ColumnCount > 0)
                {
                    dtgConcepAsig.Columns.Remove("idConcepto");
                    dtgConcepAsig.Columns.Remove("cConcepto");
                    dtgConcepAsig.Columns.Remove("nMontoCon");
                    dtgConcepAsig.Columns.Remove("cEstado");
                }
                dtgConcepAsig.DataSource = null;
            }
        }

        private void FormatoDtgConceptosRec()
        {
            dtgConcepAsig.Columns["Est"].Visible = false;
            dtgConcepAsig.Columns["nMontoCon"].Visible = false;
            dtgConcepAsig.Columns["cEstado"].Visible = false;

            dtgConcepAsig.Columns["idConcepto"].Width = 35;
            dtgConcepAsig.Columns["idConcepto"].HeaderText = "Cod.";
            dtgConcepAsig.Columns["cConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConcepAsig.Columns["cConcepto"].HeaderText = "Conceptos Asignados";
            dtgConcepAsig.Columns["idConcepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void formatoConceptoRecibo()
        {
            dtgConceptoNoAsig.Columns["Est"].Visible = false;
            dtgConceptoNoAsig.Columns["nMontoCon"].Visible = false;
            dtgConceptoNoAsig.Columns["cEstado"].Visible = false;

            dtgConceptoNoAsig.Columns["idConcepto"].Width = 35;
            dtgConceptoNoAsig.Columns["idConcepto"].HeaderText = "Cod.";
            dtgConceptoNoAsig.Columns["cConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConceptoNoAsig.Columns["cConcepto"].HeaderText = "Conceptos No Asignados";
            dtgConceptoNoAsig.Columns["idConcepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        #endregion
 
    }
}
