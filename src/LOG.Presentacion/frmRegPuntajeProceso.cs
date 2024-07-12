using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using LOG.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmRegPuntajeProceso : frmBase
    {
        #region Variables

        public clsListaDetalleProcesoAdj lisDetProAdj = new clsListaDetalleProcesoAdj();
        public clsListaPuntajeProcesoAdj lstPtj = new clsListaPuntajeProcesoAdj();
        public clslistaVinculoNotaPedido listNotPed = new clslistaVinculoNotaPedido();
        public clsProcesoAdjudicacion ProcAdj = null;

        clsListaTipoFacPonderacion lstTipoFacTec = new clsListaTipoFacPonderacion();
        clsTipoFacPonderacion ObjFacTec;
        clsTipoFacPonderacion ObjFacEco;
        clsListaPuntajeProcesoAdj lstModifPtj = new clsListaPuntajeProcesoAdj();
        clsListaPuntajeProcesoAdj lstNoVigPtj = new clsListaPuntajeProcesoAdj();
        public int idProceso = 0;
        clsListaDetalleProcesoAdj newLstDet;
        bool lFlagAcep = false;
        public bool lConfirmado =false;
        
        public int idTipoPedido = 0;

        #endregion

        #region Eventos

        private void frmRegPuntaje_Load(object sender, EventArgs e)
        {
            if (idProceso == 0)
            {
                txtFacEco.Enabled = true;
                txtFacTec.Enabled = true;
                txtPuntMin.Enabled = true;
                btnAgrPuntaje.Enabled = true;
                btnQuitPuntaje.Enabled = true;
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else if (idProceso > 0)
            {
                txtFacEco.Enabled = false;
                txtFacTec.Enabled = false;
                txtPuntMin.Enabled = false;
                btnAgrPuntaje.Enabled = false;
                btnQuitPuntaje.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnEditar.Enabled = true;
                lstPtj = new clsCNProcesoAdjudicacion().buscaPuntajeProAdj(ProcAdj.idProceso);
            }
            dtgGrupo.SelectionChanged -= new EventHandler(dtgGrupo_SelectionChanged);

            lstModifPtj = new clsListaPuntajeProcesoAdj(lstPtj.Where(x => x.lVigente == true).ToList());
            lstNoVigPtj = new clsListaPuntajeProcesoAdj(lstPtj.Where(x => x.lVigente == false).ToList());

            int idGrupoant = 0;
            bool lExiste = false;
            foreach (var item in lisDetProAdj)
            {
                lExiste = false;
                if (item.idGrupo != null)
                {
                    foreach (DataGridViewRow item2 in dtgGrupo.Rows)
                    {
                        if (item.idGrupo == Convert.ToInt32(item2.Cells[0].Value))
                        {
                            lExiste = true;
                        }
                    }

                    if (!lExiste)
                    {
                        dtgGrupo.Rows.Add(item.idGrupo, item.cDesGrupo);
                        idGrupoant = (int)item.idGrupo;
                    }
                }
            }

            dtgGrupo.SelectionChanged += new EventHandler(dtgGrupo_SelectionChanged);

            ActualizarDetalleGrupo();

            //regPuntaje.buscaTipoProceso();


            dtgPuntaje.DataSource = null;
            dtgPuntaje.DataSource = lstModifPtj;
            //Cargando el Tipo de Factor de Ponderacion
            lstTipoFacTec = new clsCNProcesoAdjudicacion().buscaFacTipPonderacion(idTipoPedido);

            ObjFacEco = lstTipoFacTec.Where(x => x.cFactorPonderacion == "ECONOMICO").First();
            lblFacEconomica.Text = "De " + ObjFacEco.nFacMin.ToString() + " a " + ObjFacEco.nFacMax.ToString();
            ObjFacTec = lstTipoFacTec.Where(x => x.cFactorPonderacion == "TECNICO").First();
            lblFacTecnica.Text = "De " + ObjFacTec.nFacMin.ToString() + " a " + ObjFacTec.nFacMax.ToString();
            if (lConfirmado)
            {
                this.btnGrabar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnAgrPuntaje_Click(object sender, EventArgs e)
        {
            if (dtgGrupo.RowCount <= 0)
            {
                MessageBox.Show("No Existe Grupos", "Validación de Puntaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int fila = dtgGrupo.SelectedRows[0].Index;
            int pidGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());

            var validaExiste = lstModifPtj.Where(x => x.idGrupo == pidGrupo).Count();
            if (validaExiste > 0)
            {
                MessageBox.Show("Ya Existe Puntaje Para el Grupo", "Validación de Puntaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtFacEco.Clear();
                this.txtFacTec.Clear();
                this.txtPuntMin.Clear();
                return;
            }
            if (Validar() == false)
            {
                return;
            }
            
            int? nProcesoId  =  (idProceso != 0)? idProceso : (int?)null;

            lstModifPtj.Add(new clsPuntajeProcesoAdj()
            {
                dFechReg = clsVarGlobal.dFecSystem,
                idGrupo = pidGrupo,
                idProceso = nProcesoId,
                dFechaMod = null,
                idUsuMod = null,
                idUsuReg = clsVarGlobal.User.idUsuario,
                nEvaEconomica = Convert.ToDecimal(txtEvaEco.Text),
                nEvaTecnica = Convert.ToDecimal(txtEvaTec.Text),
                nFacEconomica = Convert.ToDecimal(txtFacEco.Text),
                nFacTecnica = Convert.ToDecimal(txtFacTec.Text),
                nPuntajeMin = Convert.ToDecimal(txtPuntMin.Text),
                lVigente = true
            });
            if (dtgGrupo.CurrentRow.Index + 1 < dtgGrupo.RowCount)
            {
                dtgGrupo.Rows[dtgGrupo.CurrentRow.Index + 1].Selected = true;
                dtgGrupo.CurrentCell = dtgGrupo.Rows[dtgGrupo.CurrentRow.Index + 1].Cells[1];
            }
            this.txtFacEco.Clear();
            this.txtFacTec.Clear();
            this.txtPuntMin.Clear();
            this.txtFacEco.Focus();
        }

        private void btnQuitPuntaje_Click(object sender, EventArgs e)
        {
            if (dtgPuntaje.CurrentRow != null)
            {
                var itemSelc = (clsPuntajeProcesoAdj)dtgPuntaje.CurrentRow.DataBoundItem;
                if (itemSelc.idProceso == null)
                {
                    lstModifPtj.Remove(itemSelc);
                }
                else
                {
                    itemSelc.lVigente = false;
                    lstModifPtj.Remove(itemSelc);
                    //lstNoVigPtj.Add(itemSelc);
                }
                if (dtgGrupo.CurrentRow.Index - 1 >= 0)
                {
                    dtgGrupo.Rows[dtgGrupo.CurrentRow.Index - 1].Selected = true;
                    dtgGrupo.CurrentCell = dtgGrupo.Rows[dtgGrupo.CurrentRow.Index - 1].Cells[1];
                }
                if (dtgPuntaje.RowCount >= 1)
                {
                    if (dtgPuntaje.CurrentRow.Index - 1 >= 0)
                    {
                        dtgPuntaje.Rows[dtgPuntaje.CurrentRow.Index - 1].Selected = true;
                        dtgPuntaje.CurrentCell = dtgPuntaje.Rows[dtgPuntaje.CurrentRow.Index - 1].Cells[1];
                    }
                }

                dtgPuntaje.DataSource = lstModifPtj;
            }
            else
            {
                if (this.dtgPuntaje.Rows.Count < 1)
                {
                    MessageBox.Show("No Existe Puntaje a Eliminar", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalleGrupo();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (!this.ValidarGrabacion())
            {

                return;
            }
            lFlagAcep = true;
            this.ActualizarListaPuntaje();

            if (idProceso == 0)
            {

                //string msg = "";
                //int nResp = 0;
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegPuntajeAdqui(ProcAdj, lisDetProAdj, listNotPed, lstPtj);
                idProceso = Convert.ToInt32(dtResp.Rows[0]["idProceso"].ToString());
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) == 0)
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idProceso = Convert.ToInt32(dtResp.Rows[0]["idProceso"].ToString());
                    ProcAdj.idProceso = idProceso;
                    foreach (clsDetalleProcesoAdj item in lisDetProAdj)
                    {
                        item.idProceso = idProceso;
                    }

                    foreach (clsVinculoNotaPedido item in listNotPed)
	                {
                        item.idProceso = idProceso;
	                }

                    foreach (clsPuntajeProcesoAdj item in lstPtj)
	                {
                        item.idProceso = idProceso;
	                }
                }
            }
            else
            {
                //string msg = "";
                //int nResp = 0;
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegPuntajeAdqui(ProcAdj, lisDetProAdj, listNotPed, lstPtj);
                idProceso = Convert.ToInt32(dtResp.Rows[0]["idProceso"].ToString());
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) == 0)
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Se Actualizó Correctamente el Proceso", "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnAgrPuntaje.Enabled = false;
            this.btnQuitPuntaje.Enabled = false;
            this.txtFacEco.Enabled = false;
            this.txtFacTec.Enabled = false;
            this.txtPuntMin.Enabled = false;
            this.txtFacEco.Clear();
            this.txtFacTec.Clear();
            this.txtPuntMin.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAgrPuntaje.Enabled = true;
            btnQuitPuntaje.Enabled = true;
            txtFacEco.Enabled = true;
            txtFacTec.Enabled = true;
            txtPuntMin.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnAgrPuntaje.Enabled = true;
            this.btnQuitPuntaje.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lFlagAcep = false;
            this.ActualizarListaPuntaje();
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnAgrPuntaje.Enabled = false;
            this.btnQuitPuntaje.Enabled = false;
            this.txtFacEco.Enabled = false;
            this.txtFacTec.Enabled = false;
            this.txtPuntMin.Enabled = false;
            this.txtFacEco.Clear();
            this.txtFacTec.Clear();
            this.txtPuntMin.Clear();
        }

        #endregion

        #region Metodos

        public frmRegPuntajeProceso()
        {
            InitializeComponent();
        }

        private void ActualizarDetalleGrupo()
        {
            if (dtgGrupo.RowCount > 0)
            {

                int fila = dtgGrupo.SelectedRows[0].Index;
                int idGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());
                newLstDet = new clsListaDetalleProcesoAdj();

                foreach (var item in lisDetProAdj)
                {
                    if (item.idGrupo == idGrupo)
                    {
                        newLstDet.Add(new clsDetalleProcesoAdj()
                        {
                            cDesGrupo = item.cDesGrupo,
                            cProducto = item.cProducto,
                            idCatalogo = item.idCatalogo,
                            idGrupo = item.idGrupo,
                            idProceso = item.idProceso,
                            nCantidad = item.nCantidad,
                            nItem = item.nItem,
                            nPrecioUnit = item.nPrecioUnit,
                            nsubTotal = item.nsubTotal
                        });
                    }

                }

                dtgDetConGrp.DataSource = null;
                dtgDetConGrp.DataSource = newLstDet;
            }
        }

        private bool Validar()
        {
            bool lvalida = true;
            if (string.IsNullOrEmpty(txtEvaEco.Text))
            {
                MessageBox.Show("Ingrese Puntaje de la Evaluación Económica", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEvaEco.Focus();
                lvalida = false;
                return lvalida;
            }
            if (string.IsNullOrEmpty(txtEvaTec.Text))
            {
                MessageBox.Show("Ingrese Puntaje de la Evaluación Técnica", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEvaTec.Focus();
                lvalida = false;
                return lvalida;
            }
            if (string.IsNullOrEmpty(txtFacEco.Text))
            {
                MessageBox.Show("Ingrese el Coeficiente de la Factibilidad Económica", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFacEco.Focus();
                lvalida = false;
                return lvalida;
            }
            if (Convert.ToDecimal(txtFacEco.Text) < ObjFacEco.nFacMin || Convert.ToDecimal(txtFacEco.Text) > ObjFacEco.nFacMax)
            {
                MessageBox.Show("El valor del Coeficiente de la Factibilidad Económica debe ser mayor a " + ObjFacEco.nFacMin + " y menor a " + ObjFacEco.nFacMax, "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFacEco.Text = "";
                txtFacEco.Focus();
                lvalida = false;
                return lvalida;
            }
            if (string.IsNullOrEmpty(txtFacTec.Text))
            {
                MessageBox.Show("Ingrese el Coeficiente de la Factibilidad Técnica", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFacTec.Focus();
                lvalida = false;
                return lvalida;
            }
            if (Convert.ToDecimal(txtFacTec.Text) < ObjFacTec.nFacMin || Convert.ToDecimal(txtFacTec.Text) > ObjFacTec.nFacMax)
            {
                MessageBox.Show("El valor del Coeficiente de la Factibilidad Técnica debe ser mayor a " + ObjFacTec.nFacMin + " y menor a " + ObjFacTec.nFacMax, "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFacTec.Text = "";
                txtFacTec.Focus();
                lvalida = false;
                return lvalida;
            }
            if (string.IsNullOrEmpty(txtPuntMin.Text))
            {
                MessageBox.Show("Ingrese la Puntuación Mínima del Grupo", "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPuntMin.Focus();
                lvalida = false;
                return lvalida;
            }
            if (Convert.ToDecimal(txtPuntMin.Text) < 0 || Convert.ToDecimal(txtPuntMin.Text) > 100)
            {
                MessageBox.Show("El rango de valores para la Puntuación Mínima del Grupo es entre 0 y 100.\nIngrese un valor que se encuentre en este rango.",
                                "Registro de Puntaje para la Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPuntMin.Focus();
                lvalida = false;
                return lvalida;
            }
            return lvalida;
        }

        public void ActualizarListaPuntaje()
        {
            if (lFlagAcep)
            {
                lstPtj = lstModifPtj;
                //var lstFinalPtj = lstModifPtj.Union(lstNoVigPtj.ToList()).ToList();
                //lstPtj.Clear();
                //foreach (var item in lstFinalPtj)
                //{
                //    lstPtj.Add(item);

                //}
            }
            dtgPuntaje.DataSource = lstPtj;

        }

        private bool ValidarGrabacion()
        {
            if (listNotPed == null)
            {
                MessageBox.Show("Realice la búsqueda una Nota de Pedido para el Proceso de Adquisición", "Registro del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (lisDetProAdj == null)
            {
                MessageBox.Show("No se Cuenta con un detalle de la Nota de Pedido para el Proceso de Adquisición", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (lstPtj == null)
            {
                MessageBox.Show("Ingrese el Puntaje para los grupos del Proceso de Adquisición", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!ValidaGrupoPuntaje())
            {
                MessageBox.Show("Se tiene un puntaje de un grupo que ha sido eliminado, quite el puntaje del grupo eliminado y vuelva a grabar", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidaGrupoPuntaje() 
        {
            var puntajes = dtgPuntaje.Rows.Cast<DataGridViewRow>()
                                            .Select(x=>new { idGrupo = Convert.ToInt32(x.Cells["idGrupoDataGridViewTextBoxColumn1"].Value)});
            var grupos = dtgGrupo.Rows.Cast<DataGridViewRow>()
                                        .Select(x => new {
                                            idGrupo = Convert.ToInt32(x.Cells["Grupo"].Value)
                                        });

            var result = (from puntaje in puntajes
                          from grupo in grupos
                        .Where(x => x.idGrupo == puntaje.idGrupo).DefaultIfEmpty()
                        .Where(x => x == null)
                        select puntaje).ToList();

            if (result.Any())
                return false;

            return true; 
        }
        #endregion

    }
}
