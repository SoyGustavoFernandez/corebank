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
using LOG.CapaNegocio;
using EntityLayer;
namespace LOG.Presentacion
{
    public partial class frmDocEntregaAdjudicaccion : frmBase
    {
        public clsListaEvaDocumentoProceso lstEvaDocPro = new clsListaEvaDocumentoProceso();
        public int pIdProveedor;
        public int pIdProceso;
        public int idVincuProveedor;
        public bool lContinuar = true;
        public int idEstadoEva = 0;
        public bool lFlagAcep = false;
        public bool lConfirmado = false;
        clsCNNotaPedido cnDocumento = new clsCNNotaPedido();
        BindingSource bs = new BindingSource();

        public frmDocEntregaAdjudicaccion()
        {
            InitializeComponent();
        }
        public frmDocEntregaAdjudicaccion(string cNompreEmpresa)
        {
            InitializeComponent();
            lblNombreEmpres.Text = cNompreEmpresa;
        }
   
        private void frmDocEntregaAdjudicaccion_Load(object sender, EventArgs e)
        {
            //Cargar Documentos a evaluar 
            clsListaEvaDocumentoProceso listaEvaDoc = new clsListaEvaDocumentoProceso();
            listaEvaDoc = new clsCNEvalProcAdj().buscarDocumentoProcesoEvaluacion(pIdProceso);
            foreach (var item in listaEvaDoc)
            {
                lstEvaDocPro.Add(new clsEvaDocumentoProceso()
                {

                    cTipoDocProAdqui = item.cTipoDocProAdqui,
                    dFechaEva = clsVarGlobal.dFecSystem.ToString(),
                    idEstadoEvaDoc = item.idEstadoEvaDoc,
                    idProceso = pIdProceso,
                    idProveedor = pIdProveedor,
                    idTipoDocProAdqui = item.idTipoDocProAdqui,
                    idCalendario = item.idCalendario,
                    lVigente = item.lVigente,
                    idEtapaCalendario = item.idEtapaCalendario

                });
            }



            DataGridViewComboBoxColumn colComboBox = dtgDocumento.Columns["idEstadoEvaDoc"] as DataGridViewComboBoxColumn;
            DataTable dtTipEstadoEva = new clsCNEvalProcAdj().buscarEstadoEvaDoc();

            colComboBox.DataSource = dtTipEstadoEva;
            colComboBox.DisplayMember = "cDescripcion";
            colComboBox.ValueMember = "idEstadoEvaDoc";


            this.dtgDocumento.Enabled = true;
            this.dtgDocumento.ReadOnly = false;

            if (idVincuProveedor == 0)
            {
                habilitarBoton(false);
                FormatoGrids();
            }
            else
            {
                DataTable dtEvaDoc = new clsCNEvalProcAdj().RetornaEvaDocByProv(pIdProveedor, pIdProceso);
                foreach (var item1 in lstEvaDocPro)
                {
                    foreach (DataRow item2 in dtEvaDoc.Rows)
                    {
                        colComboBox.DataPropertyName = "idEstadoEvaDoc";
                        if (item1.idTipoDocProAdqui == Convert.ToInt32(item2["idTipoDocProAdqui"]) && item1.idEtapaCalendario == Convert.ToInt32(item2["idEtapaCalendario"]))
                        {
                            item1.idEvaDocumento = Convert.ToInt32(item2["idEvaDocumento"]);
                            item1.idEstadoEvaDoc = Convert.ToInt32(item2["idEstadoEvaDoc"]);

                        }
                    }
                }
                habilitarBoton(true);
                this.dtgDocumento.ReadOnly = true;
            }
            var lst = lstEvaDocPro.Where(x => x.idProveedor == pIdProveedor);
            bs.DataSource = lst.ToList();
            dtgDocumento.DataSource = bs;

            if (lConfirmado)
            {
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
            }
        }
        private void FormatoGrids()
        {
            dtgDocumento.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgDocumento.Columns)
            {
                item.ReadOnly = true;
                if (item.HeaderText == "Entrega")
                {
                    item.ReadOnly = false;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void habilitarBoton(bool lActivo)
        {
            btnEditar1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;

            //dtgDocumento.ReadOnly = lActivo;

        }
        //private void btnAceptar1_Click(object sender, EventArgs e)
        //{
        //    foreach (var item in lstEvaDocPro)
        //    {
        //        if (item.idEstadoEvaDoc == 0)
        //        {
        //            MessageBox.Show("No se ha seleccionado el estado para: " + item.cTipoDocProAdqui, "Evaluación de Documentos del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //    }

        //    this.Dispose();
        //}

        private void dtgDocumento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgDocumento.RowCount == 0) return;
            if (dtgDocumento.SelectedRows.Count == 0) return;
            try
            {
                var itemSelec = (clsEvaDocumentoProceso)dtgDocumento.CurrentRow.DataBoundItem;
                itemSelec.idEstadoEvaDoc = Convert.ToInt32(dtgDocumento.CurrentRow.Cells["idEstadoEvaDoc"].Value);
            }
            catch (Exception)
            {
            }
            
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            //bool idEstadoCalifica = false;
            idEstadoEva = 2;
            bool lEstadoCalifica = true;
            bool lCalifica = true;
            var itemLst = lstEvaDocPro.Where(x => x.idProveedor == pIdProveedor).ToList();

            foreach (var item in itemLst)
            {
                if (item.idEstadoEvaDoc == 0)
                {
                    MessageBox.Show("No se ha seleccionado el estado para: " + item.cTipoDocProAdqui, "Evaluación de Documentos del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lEstadoCalifica = false;
                              return;
                }
                if (item.idEstadoEvaDoc== 2 || item.idEstadoEvaDoc==3)
                {
                    lEstadoCalifica = false;
                }
            }
            if (!lEstadoCalifica)
            {
                DialogResult result=MessageBox.Show("El Proveedor no Cumple con uno de los Documentos" + ". \n Desea DESCALIFICAR la propuesta.", "Evaluación de requisitos Mínimos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) ;
                if (result == DialogResult.Yes)
                {
                    lContinuar = false;
                    lCalifica = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    lContinuar = true;
                }
            }
            DateTime dFechaReg = clsVarGlobal.dFecSystem;
            int idUsuReg = clsVarGlobal.User.idUsuario;
            DataTable dtResp = new clsCNEvalProcAdj().cnGrabarEvaDocumentos(idVincuProveedor, dFechaReg, idUsuReg, idEstadoEva, lCalifica, lstEvaDocPro);
            if (dtResp.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show(dtResp.Rows[0][1].ToString(), "Registro de Evaluación de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lFlagAcep=true;
                this.Dispose();    
            }

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(false);
            FormatoGrids();
        }
       

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(true);
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

        private void dtgDocumento_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void dtgDocumento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void dtgDocumento_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void dtgDocumento_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void frmDocEntregaAdjudicaccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            bs.DataSource = null;
            dtgDocumento.DataSource = bs;
        }
    }
}
