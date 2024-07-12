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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmTrackingRiesgos : frmBase
    {
        private clsCNExcepcionesCreditos objCNExcepciones = new clsCNExcepcionesCreditos();
        private clsCNInformeRiesgos objRiesgos = new clsCNInformeRiesgos();
        private List<clsConfigDataGridView> listConfigDtg = new List<clsConfigDataGridView>();
        private List<clsExcepReglaNegResum> lstExcepReglaResum;

        public frmTrackingRiesgos()
        {
            InitializeComponent();
            this.lstExcepReglaResum = new List<clsExcepReglaNegResum>();
            this.cboEstSolCred.SelectedIndexChanged -= new System.EventHandler(this.cboEstSolCred_SelectedIndexChanged);
        }

        private void frmTrackingRiesgos_Load(object sender, EventArgs e)
        {
            CargarSolicitudesCli(false);
            ConfigDataGridView();
            AdicionandoBotones();
            this.cboEstSolCred.ListEstCred(0, true);
            this.cboEstSolCred.SelectedIndexChanged += new System.EventHandler(this.cboEstSolCred_SelectedIndexChanged);
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            limpiar();
            txtCodCliente.Enabled = true;
            txtCodigoSol.Enabled = true;
            BuscarCliente();
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCodCliente.Text == "")
                {
                    MessageBox.Show("No se encuentra datos del código ingresado", "Validación de Traking de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                this.txtCodigoSol.Text = "";
                this.lblNombre.Text = "";
                this.lblDoc.Text = "";
                CargarSolicitudesCli();
                AdicionandoBotones();
            }
        }

        private void txtCodigoSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.cboEstSolCred.SelectedValue = 9999;
                this.txtCodCliente.Text = "";
                this.lblNombre.Text = "";
                this.lblDoc.Text = "";
                CargarSolicitudesCli();
                AdicionandoBotones();
            }
        }

        private void BuscarCliente()
        {
            FrmBusCli FrmBus = new FrmBusCli();
            FrmBus.ShowDialog();

            if (FrmBus.pcCodCli == "" || string.IsNullOrEmpty(FrmBus.pcCodCli))
            {
                limpiar();
            }
            else
            {
                if (Convert.ToBoolean(FrmBus.pIndicaDatoBasico) == true)
                {
                    MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    return;
                }

                txtCodCliente.Text = FrmBus.pcCodCliLargo.Substring(6);
                lblNombre.Text = FrmBus.pcNomCli;
                lblDoc.Text = FrmBus.pcNroDoc;

                CargarSolicitudesCli();
                AdicionandoBotones();
            }
        }

        private void CargarSolicitudesCli(bool lCargar = true) 
        {
            int idCliTemp = Convert.ToInt32((this.txtCodCliente.Text.Trim()) == "" ? "0" : this.txtCodCliente.Text.Trim()),
                idSolTemp = Convert.ToInt32((this.txtCodigoSol.Text.Trim()) == "" ? "0" : this.txtCodigoSol.Text.Trim());

            if (idCliTemp == 0 && idSolTemp == 0 && lCargar)
            {
                return;
            }

            DataTable dtSolCliente = objRiesgos.CNObtenerSolicitudesParaOpinionRiesgo((lCargar == false ? -100 : idCliTemp), idSolTemp, Convert.ToInt32(this.cboEstSolCred.SelectedValue??9999));
            
            DataTable dtOpinion = dtSolCliente.Copy();
            DataRow[] drElimSolOp = dtOpinion.Select("lOpinion = 0");
            foreach (DataRow item in drElimSolOp){item.Delete();}
            dtOpinion.AcceptChanges();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtOpinion;
            this.dtgOpinionRiesgos.DataSource = bindingSource;

            DataTable dtExcep = dtSolCliente.Copy();
            DataRow[] drElimExcep = dtExcep.Select("lExcepGen = 0");
            foreach (DataRow item in drElimExcep) { item.Delete(); }
            dtExcep.AcceptChanges();

            BindingSource bindingSourceExcep = new BindingSource();
            bindingSourceExcep.DataSource = dtExcep;
            this.dtgExcepcionCanal.DataSource = bindingSourceExcep;

            if (dtSolCliente.Rows.Count > 0)
            {
                this.txtCodCliente.Text = (dtSolCliente.AsEnumerable().FirstOrDefault().Field<int>("idCli")).ToString();
                this.lblNombre.Text = (dtSolCliente.AsEnumerable().FirstOrDefault().Field<string>("cNombreCli"));
                this.lblDoc.Text = (dtSolCliente.AsEnumerable().FirstOrDefault().Field<string>("cDocumentoID"));
            }
        }

        private void ConfigDataGridView()
        {
            this.dtgOpinionRiesgos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgOpinionRiesgos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dtgOpinionRiesgos.MultiSelect = true;

            this.dtgExcepcionCanal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcepcionCanal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dtgExcepcionCanal.MultiSelect = true;

            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "idSolicitud", cNombre = "ID SOLICITUD", nWidth = 90 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cWinUser", cNombre = "USUARIO", nWidth = 100 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cNombre", cNombre = "NOMBRE USUARIO", nWidth = 240 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cAgencia", cNombre = "AGENCIA", nWidth = 100 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cEstado", cNombre = "ESTADO", nWidth = 150 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cOpinion1", cNombre = "OPINION", nWidth = 90 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "cOpinion2", cNombre = "RECONSI.", nWidth = 90 });
            this.listConfigDtg.Add(new clsConfigDataGridView() { cAlias = "dFechaRegistro", cNombre = "FECHA", nWidth = 80 });

            foreach (DataGridViewColumn columna in this.dtgOpinionRiesgos.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgOpinionRiesgos.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgOpinionRiesgos.Columns[columna.Index].Width = objItemConfig.nWidth;
                    this.dtgOpinionRiesgos.Columns[columna.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dtgOpinionRiesgos.Columns[columna.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    this.dtgOpinionRiesgos.Columns[columna.Index].Visible = false;
                }
            }

            foreach (DataGridViewColumn columna in this.dtgExcepcionCanal.Columns)
            {
                clsConfigDataGridView objItemConfig = this.listConfigDtg.Find(p => p.cAlias == columna.HeaderText) ?? new clsConfigDataGridView() { cAlias = "", cNombre = "" };
                if (columna.HeaderText == objItemConfig.cAlias)
                {
                    this.dtgExcepcionCanal.Columns[columna.Index].HeaderText = objItemConfig.cNombre;
                    this.dtgExcepcionCanal.Columns[columna.Index].Width = objItemConfig.nWidth;
                    this.dtgExcepcionCanal.Columns[columna.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dtgExcepcionCanal.Columns[columna.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    this.dtgExcepcionCanal.Columns[columna.Index].Visible = false;
                }
            }

            DataGridViewButtonColumn dtgBotonDet = new DataGridViewButtonColumn();
            dtgBotonDet.HeaderText = "";
            dtgBotonDet.Name = "btnMasDet";
            this.dtgOpinionRiesgos.Columns.Add(dtgBotonDet);
            this.dtgOpinionRiesgos.Columns["btnMasDet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dtgOpinionRiesgos.Columns["btnMasDet"].Width = 30;

            DataGridViewButtonColumn dtgBotonDet2 = new DataGridViewButtonColumn();
            dtgBotonDet2.HeaderText = "";
            dtgBotonDet2.Name = "btnMasDet";
            this.dtgExcepcionCanal.Columns.Add(dtgBotonDet2);
            this.dtgExcepcionCanal.Columns["btnMasDet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dtgExcepcionCanal.Columns["btnMasDet"].Width = 30;
        }

        private void AdicionandoBotones()
        {
            for (int i = 0; i < dtgOpinionRiesgos.Rows.Count; i++)
            {
                DataGridViewRow row = this.dtgOpinionRiesgos.Rows[i];
                DataGridViewButtonCell btnMasDet = (DataGridViewButtonCell)row.Cells["btnMasDet"];
                btnMasDet.ToolTipText = "Detalle del procedimiento";
                btnMasDet.Value = "...";
                dtgOpinionRiesgos.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgOpinionRiesgos.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }
            for (int i = 0; i < dtgExcepcionCanal.Rows.Count; i++)
            {
                DataGridViewRow row = this.dtgExcepcionCanal.Rows[i];
                DataGridViewButtonCell btnMasDet = (DataGridViewButtonCell)row.Cells["btnMasDet"];
                btnMasDet.ToolTipText = "Detalle del procedimiento";
                btnMasDet.Value = "...";
                dtgExcepcionCanal.AutoResizeRow(i, DataGridViewAutoSizeRowMode.AllCells);
                dtgExcepcionCanal.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }

        private void limpiar()
        {
            txtCodCliente.Text = "";
            txtCodigoSol.Text = "";
            lblNombre.Text = "";
            lblDoc.Text = "";
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            CargarSolicitudesCli(false);
        }

        private void cboEstSolCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSolicitudesCli();
            AdicionandoBotones();
        }

        private void dtgExcepcionCanal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dtgExcepcionCanal.Columns["btnMasDet"].Index && e.RowIndex >= 0)
            {
                frmDetalleTrackingRiesgos frmDetTraking = new frmDetalleTrackingRiesgos();
                frmDetTraking.idSolicitud = Convert.ToInt32(this.dtgExcepcionCanal.Rows[e.RowIndex].Cells["idSolicitud"].Value);
                frmDetTraking.cModo = "Excepcion";
                frmDetTraking.ShowDialog();
            }
        }

        private void dtgExcepcionCanal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dtgExcepcionCanal.Rows[e.RowIndex];
                //if ((row.Cells["idEstado"].Value != null ? Convert.ToInt32(row.Cells["idEstado"].Value) : 6) == 6)
                //{
                //    e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
                //    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                //}
                //else
                //{
                //    e.CellStyle.BackColor = Color.FromArgb(204, 255, 204);
                //    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                //}
            }
        }

        private void dtgExcepcionCanal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                using (Font font = new Font(this.dtgExcepcionCanal.Font, FontStyle.Bold))
                {
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        using (Brush backBrush = new SolidBrush(Color.Blue))
                        {
                            e.PaintBackground(e.CellBounds, true);
                            e.Graphics.FillRectangle(backBrush, e.CellBounds);
                            e.Graphics.DrawString(e.Value.ToString(), font, textBrush, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void dtgOpinionRiesgos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dtgOpinionRiesgos.Columns["btnMasDet"].Index && e.RowIndex >= 0)
            {
                frmDetalleTrackingRiesgos frmDetTraking = new frmDetalleTrackingRiesgos();
                frmDetTraking.idSolicitud = Convert.ToInt32(this.dtgOpinionRiesgos.Rows[e.RowIndex].Cells["idSolicitud"].Value);
                frmDetTraking.cModo = "Opinion";
                frmDetTraking.ShowDialog();
            }
        }

        private void dtgOpinionRiesgos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dtgOpinionRiesgos.Rows[e.RowIndex];
                if ((row.Cells["idEstado"].Value != null ? Convert.ToInt32(row.Cells["idEstado"].Value) : 6) == 6)
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 204, 204);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(204, 255, 204);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 102, 204);
                }
            }
        }

        private void dtgOpinionRiesgos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                using (Font font = new Font(this.dtgOpinionRiesgos.Font, FontStyle.Bold))
                {
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        using (Brush backBrush = new SolidBrush(Color.Blue))
                        {
                            e.PaintBackground(e.CellBounds, true);
                            e.Graphics.FillRectangle(backBrush, e.CellBounds);
                            e.Graphics.DrawString(e.Value.ToString(), font, textBrush, e.CellBounds.X + 5, e.CellBounds.Y + 5);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

    }
}
