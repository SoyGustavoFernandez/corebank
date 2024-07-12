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
using EntityLayer;
using GEN.CapaNegocio;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmRegDocSolProceso : frmBase
    {

        private const string cTituloMsjes = "Edición del Proceso de Adquisición";
        public clsListaCalendarioAdj LstCalendarioAdj = new clsListaCalendarioAdj();
        clsListaDocumentoPorCalendario lstDocCal = new clsListaDocumentoPorCalendario();
        public int idProceso = 0;
        public int idTipoProceso = 0;
        public bool lConfirmado = false;
        clsListaDocumentoPorCalendario lstModDocCal = new clsListaDocumentoPorCalendario();
        clsListaDocumentoPorCalendario lstNoVig = new clsListaDocumentoPorCalendario();
        clsDocumentoPorCalendario docCal;
        bool lFlagAcep = false;
        clsCalendarioAdjudicacion clsCalAdj = new clsCalendarioAdjudicacion();
        clsCNNotaPedido clsNotPedido = new clsCNNotaPedido();
        public frmRegDocSolProceso()
        {
            InitializeComponent();
        }

        private void frmRegDocSolProceso_Load(object sender, EventArgs e)
        {
            lstDocCal = new clsCNProcesoAdjudicacion().buscarDocumentoCal(idProceso);
            if (lConfirmado)
            {
                btnGrabar1.Enabled = false;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                chcBase1.Enabled = false;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
            }
            else
            {
                if (lstDocCal.Count == 0)
                {
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    chcBase1.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                }
                else if (lstDocCal.Count > 0)
                {
                    btnGrabar1.Enabled = false;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                }
            }

            //lstDocCal = new clsCNProcesoAdjudicacion().buscarDocumentoCal(idProceso);
            dtgCalendario.DataSource = LstCalendarioAdj;
            ActualizarListaDocumentos();


        }
        private void ActualizarListaDocumentos()
        {
            foreach (var item in lstDocCal)
            {
                if (item.lVigente == true)
                {
                    lstModDocCal.Add(new clsDocumentoPorCalendario(item));
                }
                else
                {
                    lstNoVig.Add(new clsDocumentoPorCalendario(item));
                }
            }

            if (dtgCalendario.Rows.Count > 0)
            {
                var IdEtapa = (clsCalendarioAdjudicacion)(dtgCalendario.CurrentRow.DataBoundItem);
                dtgDetalleDoc.DataSource = null;
                dtgDetalleDoc.DataSource = lstModDocCal.Where(x => x.idCalendario == IdEtapa.idCalendario).ToList();
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void dtgCalendario_SelectionChanged(object sender, EventArgs e)
        {

            if (dtgCalendario.Rows.Count > 0)
            {
                var IdEtapa = (clsCalendarioAdjudicacion)(dtgCalendario.CurrentRow.DataBoundItem);
                dtgDetalleDoc.DataSource = null;
                dtgDetalleDoc.DataSource = lstModDocCal.Where(x => x.idCalendario == IdEtapa.idCalendario && x.idEtapaCalendario == IdEtapa.idEtapaCalendario).ToList();

            }


            int nfila = 0;
            if (dtgCalendario.CurrentRow != null)
            {
                nfila = dtgCalendario.CurrentRow.Index;
            }

            int nIdTipoCalendario = Convert.ToInt32(dtgCalendario.Rows[nfila].Cells["idEtapaCalendario"].Value);
            CargarDatos(idTipoProceso, nIdTipoCalendario);

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            lFlagAcep = true;
            Dispose();
        }

        private void dtgCalendario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CargarDatos(int idTipoProceso, int nIdEtapaProceso)
        {

            clsCNAdquisionesLogistica ListadoTipoDocumento = new clsCNAdquisionesLogistica();

            DataTable dt = ListadoTipoDocumento.listarTipoDocumentoAdj(idTipoProceso, nIdEtapaProceso);
            dt.Columns["lSelect"].ReadOnly = false;
            if (dtgDocumentos.Rows.Count > 0)
            {
                dtgDocumentos.DataSource = null;
            }
            dtgDocumentos.DataSource = dt;
            dtgDocumentos.Columns["idEtapaCalendario"].Visible = false;
            dtgDocumentos.Columns["idTipoDocProAdqui"].Visible = false;
            dtgDocumentos.Columns["cTipoDocProAdqui"].HeaderText = "Documentos";
            dtgDocumentos.Columns["lDocObligatorio"].HeaderText = "Doc.Obli";
            dtgDocumentos.Columns["lSelect"].HeaderText = "X";
            dtgDocumentos.Columns["cTipoDocProAdqui"].Width = 285;
            dtgDocumentos.Columns["lDocObligatorio"].Width = 40;
            dtgDocumentos.Columns["lSelect"].Width = 25;
            HabilitarGrid(true);


        }
        private void HabilitarGrid(bool Val)
        {
            dtgDocumentos.ReadOnly = !Val;
            dtgDocumentos.Columns["idEtapaCalendario"].ReadOnly = Val;
            dtgDocumentos.Columns["idTipoDocProAdqui"].ReadOnly = Val;
            dtgDocumentos.Columns["cTipoDocProAdqui"].ReadOnly = Val;
            dtgDocumentos.Columns["lDocObligatorio"].ReadOnly = Val;
            dtgDocumentos.Columns["lSelect"].ReadOnly = !Val;
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            int nCont = 0;
            for (int i = 0; i < dtgDocumentos.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgDocumentos.Rows[i].Cells["lSelect"].Value) == 0)
                {
                    nCont++;
                }
            }
            if (nCont == dtgDocumentos.Rows.Count)
            {
                MessageBox.Show("Seleccione Documento a añadir", "Validación de registro de documentos por Etapa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < dtgDocumentos.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgDocumentos.Rows[i].Cells["lSelect"].Value) == 1)
                {
                    // int nfila = Convert.ToInt32(this.dtgDocumentos.SelectedCells[i].RowIndex);
                    var itemSelecCal = (clsCalendarioAdjudicacion)dtgCalendario.CurrentRow.DataBoundItem;
                    int idEtapaCal = Convert.ToInt32(itemSelecCal.idEtapaCalendario.ToString());
                    if (itemSelecCal.listaDocCal == null)
                    {
                        itemSelecCal.listaDocCal = new clsListaDocumentoPorCalendario();
                    }
                    docCal = new clsDocumentoPorCalendario();
                    docCal.cDesTipoDoc = dtgDocumentos.Rows[i].Cells["cTipoDocProAdqui"].Value.ToString();
                    docCal.idTipoDocProAdqui = Convert.ToInt32(dtgDocumentos.Rows[i].Cells["idTipoDocProAdqui"].Value.ToString());
                    docCal.idCalendario = Convert.ToInt32(itemSelecCal.idCalendario.ToString());
                    docCal.idEtapaCalendario = Convert.ToInt32(dtgDocumentos.Rows[i].Cells["idEtapaCalendario"].Value.ToString());
                    docCal.lVigente = true;

                    var validaexiste = lstModDocCal.Where(x => x.idTipoDocProAdqui == docCal.idTipoDocProAdqui && x.idEtapaCalendario == docCal.idEtapaCalendario).Count();
                    if (validaexiste > 0)
                    {
                        MessageBox.Show("Ya Existe el Documento:  " + dtgDocumentos.Rows[i].Cells["cTipoDocProAdqui"].Value.ToString() + "  en el Calendario", "Validación de Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    lstModDocCal.Add(docCal);
                }
            }

            if (dtgCalendario.Rows.Count > 0)
            {
                var IdEtapa = (clsCalendarioAdjudicacion)(dtgCalendario.CurrentRow.DataBoundItem);
                dtgDetalleDoc.DataSource = null;
                dtgDetalleDoc.DataSource = lstModDocCal.Where(x => x.idCalendario == IdEtapa.idCalendario && x.idEtapaCalendario == IdEtapa.idEtapaCalendario).ToList();

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleDoc.Rows.Count > 0)
            {
                clsCalendarioAdjudicacion itemSelecCal = (clsCalendarioAdjudicacion)dtgCalendario.CurrentRow.DataBoundItem;
                clsDocumentoPorCalendario itemselect = (clsDocumentoPorCalendario)dtgDetalleDoc.CurrentRow.DataBoundItem;
                if (idProceso == 0)
                {
                    lstModDocCal.Remove(itemselect);
                }
                else
                {
                    itemselect.lVigente = false;
                    lstModDocCal.Remove(itemselect);
                }
                if (dtgCalendario.Rows.Count > 0)
                {
                    clsCalendarioAdjudicacion IdEtapa = (clsCalendarioAdjudicacion)(dtgCalendario.CurrentRow.DataBoundItem);
                    dtgDetalleDoc.DataSource = null;
                    dtgDetalleDoc.DataSource = lstModDocCal.Where(x => x.idCalendario == IdEtapa.idCalendario).ToList();
                }
            }
            else
            {
                MessageBox.Show("No Existe registro a Eliminar", "Registro de Documentos por Etapa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void dtgCalendario_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int nfila = e.RowIndex;
            int nIdTipoCalendario = Convert.ToInt32(dtgCalendario.Rows[nfila].Cells["idEtapaCalendario"].Value);
            CargarDatos(idTipoProceso, nIdTipoCalendario);
            chcBase1.Checked = false;

        }

        private void dtgCalendario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgCalendario.IsCurrentCellDirty)
            {
                dtgCalendario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void frmRegDocSolProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (lFlagAcep)
            //{

            //    var lstFinalCalendario = lstModDocCal.Union(lstNoVig);
            //    lstDocCal.Clear();
            //    foreach (var item in lstFinalCalendario)
            //    {
            //        lstDocCal.Add(item);
            //    }
            //}
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked == true)
            {
                for (int i = 0; i < dtgDocumentos.Rows.Count; i++)
                {
                    if (dtgDocumentos.Rows[i].Cells["lDocObligatorio"].Value.ToString().Trim() == "X")
                    {
                        dtgDocumentos.Rows[i].Cells["lSelect"].Value = true;
                        dtgDocumentos.Rows[i].Cells["lSelect"].ReadOnly = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dtgDocumentos.Rows.Count; i++)
                {
                    dtgDocumentos.Rows[i].Cells["lSelect"].Value = false;
                    dtgDocumentos.Rows[i].Cells["lSelect"].ReadOnly = false;
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            lFlagAcep = true;
            ActualizarRegDocProceso();
            if (idProceso == 0)
            {
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegDocSolProceso(idProceso, LstCalendarioAdj, lstDocCal);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) == 0)
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegDocSolProceso(idProceso, LstCalendarioAdj, lstDocCal);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) == 0)
                {
                    MessageBox.Show("Se Actualizó Correctamente el Proceso", "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            btnEditar1.Enabled = true;
            btnGrabar1.Enabled = false;

        }

        private bool Validar()
        {
            if (!LstCalendarioAdj.Any())
            {
                MessageBox.Show("No se agregaron documentos para el proceso.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ActualizarRegDocProceso()
        {
            lstDocCal.Clear();

            foreach (var item in lstModDocCal)
            {
                lstDocCal.Add(item);
            }

            lstModDocCal.Clear();
            ActualizarListaDocumentos();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lFlagAcep = false;
            ActualizarRegDocProceso();
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnEditar1.Enabled = true;
            chcBase1.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            chcBase1.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
        }

    }
}
