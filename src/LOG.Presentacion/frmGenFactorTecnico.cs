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
using LOG.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmGenFactorTecnico : frmBase
    {
        #region Variables

        public clsListaDetalleProcesoAdj lstdetProAdj = new clsListaDetalleProcesoAdj();
        clsListaFactoresTecnicos lstCriEva = new clsListaFactoresTecnicos();
        clsListaFactoresTecnicos lstModCriEva = new clsListaFactoresTecnicos();
        clsListaFactoresTecnicos lstNoVigCriEva = new clsListaFactoresTecnicos();
        clsListaTipoFacTecnicos lstTipFacTec = new clsListaTipoFacTecnicos();
        clsCNNotaPedido cnFactAdj = new clsCNNotaPedido();
        bool lFlgAcepta = false;
        public int idProceso = 0;
        public bool lConfirmado = false;
        public int idTipoPedido = 0;

        #endregion


        public frmGenFactorTecnico()
        {
            InitializeComponent();
        }

        private void frmGenFactorTecnico_Load(object sender, EventArgs e)
        {
            lstCriEva = new clsCNProcesoAdjudicacion().buscaFactoresTecnicosProAdj(idProceso);
            if (lConfirmado)
            {
                btnGrabar1.Enabled = false;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                txtDescripcion.Enabled = false;
                chcUsaPlantilla.Enabled = false;
                txtPGrupo.Enabled = false;
                cboTipoEvaluacion.Enabled = false;
                txtPuntaje.Enabled = false;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;

                FormatoGrids(true);
            }
            else
            {
                if (lstCriEva.Count == 0)
                {
                    btnGrabar1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = false;

                    txtDescripcion.Enabled = true;
                    chcUsaPlantilla.Enabled = true;
                    txtPGrupo.Enabled = true;
                    cboTipoEvaluacion.Enabled = true;
                    txtPuntaje.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;

                    FormatoGrids(true);
                }
                else
                {
                    btnGrabar1.Enabled = false;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;

                    FormatoGrids(false);
                }
            }

            //lstCriEva = new clsCNProcesoAdjudicacion().buscaFactoresTecnicosProAdj(idProceso);
     
            lstModCriEva = new clsListaFactoresTecnicos(lstCriEva.Where(x => x.lVigente== true).ToList());
            lstNoVigCriEva = new clsListaFactoresTecnicos(lstCriEva.Where(x => x.lVigente == false).ToList());
            dtgGrupo.SelectionChanged -= new EventHandler(dtgGrupo_SelectionChanged);

            if(idTipoPedido != 0)
                cboTipoPedido.SelectedValue = idTipoPedido;
          
            int idGrupoant = 0;
            bool lExiste = false;
            foreach (var item in lstdetProAdj)
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

            actualizarDetalleGrupo();
            lstTipFacTec = new clsCNProcesoAdjudicacion().buscaTipoFacTecnicoGrupo(Convert.ToInt32(cboTipoPedido.SelectedValue), 0);

            dtgFactorTecnico.DataSource = lstTipFacTec;

            cboTipoEvaluacion.DataSource = new clsCNProcesoAdjudicacion().buscaTipoEvaFacTec();
            cboTipoEvaluacion.ValueMember = "idTipoEvaFacTec";
            cboTipoEvaluacion.DisplayMember = "cDescripcion";
            
            int fila = dtgGrupo.CurrentRow.Index;
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());

            dtgCriterioEva.DataSource = null;
            dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == x.idGrupo).ToList();
            //FormatoGrids(false);
            
            ActualizarSelecTipoFacTec(xidGrupo);
        }
        private void ActualizarSelecTipoFacTec(int lIdGrupo)
        {
            var lstTmpFacTec = lstModCriEva.Where(x => x.nOrden == 0 && x.idGrupo == lIdGrupo).ToList();
            if (lstTmpFacTec.Count()<=0)
            {
                foreach (var item2 in lstTipFacTec)
                {
                        item2.lSelec = false;
                }
            }
            else
            {
                foreach (var item1 in lstTmpFacTec)
                {
                    foreach (var item2 in lstTipFacTec)
                    {

                        if (item1.idGrupo == lIdGrupo)
                        {
                            item2.lSelec = false;
                        }

                    }
                }

                foreach (var item1 in lstTmpFacTec)
                {
                    foreach (var item2 in lstTipFacTec)
                    {
                        
                        if (item1.idFacTecnicos == item2.idFacTecnicos && item1.idGrupo==lIdGrupo)
                        {
                            item2.lSelec = true;
                        }
                       
                    }
                }
            }
            dtgFactorTecnico.DataSource = null;
            dtgFactorTecnico.DataSource = lstTipFacTec;

            dtgCriterioEva.DataSource = null;
            dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == lIdGrupo).ToList();
            ColorDataGrid();
        }
                
        
        private void FormatoGrids(bool lHabil)
        {
            dtgFactorTecnico.ReadOnly = false;

            foreach (DataGridViewColumn column in dtgFactorTecnico.Columns)
            {
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            lSelec.ReadOnly = !lHabil;
        }
        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            actualizarDetalleGrupo();

        }
        private void actualizarDetalleGrupo()
        {
            if (dtgGrupo.RowCount<=0)
            {
                return;
            }
            int fila = dtgGrupo.CurrentRow.Index;
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());
            dtgDetProAdj.DataSource = null;
            dtgDetProAdj.DataSource = lstdetProAdj.Where(x => x.idGrupo == xidGrupo).ToList();

            ActualizarSelecTipoFacTec(xidGrupo);

            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgFactorTecnico.RowCount<=0)
            {
                return;
            }
            var itemSelc = (clsTipoFactoresTecnicos)dtgFactorTecnico.CurrentRow.DataBoundItem;

            if (itemSelc.lSelec== false)
            {
                MessageBox.Show("Seleccione El Factor Técnico", "Validar Registro de Criterio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtPuntaje.Text.Trim()))
            {
                MessageBox.Show("Ingrese Valores de Puntaje Correcto","Validar Puntaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtPuntaje.Focus();
                return;
            }
            
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells[0].Value.ToString());

            decimal MaxValFacTec = lstModCriEva.Where(x => x.idFacTecnicos == itemSelc.idFacTecnicos && x.nOrden == 0 && x.idGrupo == xidGrupo).Sum(y => y.P_Grupo);

            if (Convert.ToDecimal(txtPuntaje.Text.Trim()) <= 0)
            {
                MessageBox.Show("Ingrese Puntaje Mayo a Cero", "Validar Puntaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuntaje.Focus();
                return;
            }
            if (Convert.ToDecimal(txtPuntaje.Text.Trim()) > MaxValFacTec)
            {
                MessageBox.Show("Valor del Puntaje Supera al Puntaje Por Grupo en " + itemSelc.cFacTecnicos , "Validar Puntaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuntaje.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Ingrese la descripción del criterio.", "Validar Puntaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPuntaje.Focus();
                return;
            }

            int xcodigo, xidPadre;
            string xDescripcion;

            decimal xnpuntaje = Convert.ToDecimal(txtPuntaje.Text);
            decimal xP_Grupo = Convert.ToDecimal(txtPGrupo.Text);

            if (!validarAgregaFactor(itemSelc.idFacTecnicos, xnpuntaje, Convert.ToInt32(cboTipoEvaluacion.SelectedValue), cboTipoEvaluacion.Text, xidGrupo))
            {
                return;
            }

            int index = lstModCriEva.ToList().FindLastIndex(p => p.idFacTecnicos == itemSelc.idFacTecnicos);
            var items = lstModCriEva.Where(x => x.idFacTecnicos == itemSelc.idFacTecnicos && x.idGrupo == xidGrupo).ToList();
            if (items.Count() > 0)
            {
                xidPadre = itemSelc.idFacTecnicos;
                xDescripcion = txtDescripcion.Text;
                xcodigo = items.Where(x => x.idFacTecnicos == itemSelc.idFacTecnicos && x.idGrupo == xidGrupo).Count();
                dtgCriterioEva.DataSource = null;
                
                lstModCriEva.Insert(index + 1, new clsFactoresTecnicos()
                {
                    nOrden = xcodigo,
                    cDecripcion = xDescripcion,
                    cTipoEval = cboTipoEvaluacion.Text,
                    idGrupo = xidGrupo,
                    idProceso = 0,
                    idTipoEvaFacTec = Convert.ToInt32(cboTipoEvaluacion.SelectedValue),
                    idFacTecnicos = itemSelc.idFacTecnicos,
                    lVigente = true,
                    nPuntaje = xnpuntaje,
                    P_Grupo = 0,
                    idPadre = xidPadre,
                     lSelect=true
                });
                txtPuntaje.Text = "0.00";
                txtDescripcion.Clear();
                dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == xidGrupo).ToList();
                if (dtgCriterioEva.DataSource == null)
                {
                    dtgCriterioEva.Rows[index + 1].Selected = true;
                }
                
                ColorDataGrid();
            }
        }

        private bool validarAgregaFactor(int idFacTecnicos, decimal nPuntaje, int idTipEvaFacTec, string cTipEvaFacTec, int idGrupo)
        {
            var lisTipEval = lstModCriEva.Where(x => x.idFacTecnicos == idFacTecnicos && x.idPadre == 0 && x.idGrupo == idGrupo).ToList();
            string cEvalFacTec = lisTipEval[0].cTipoEval.ToString();
            decimal nMax = 0, nTotal = 0; 
            if (dtgCriterioEva.RowCount > 0)
            {
                var lista = lstModCriEva;
                var padre = lista.Where(x => x.idTipoEvaFacTec == idTipEvaFacTec  && x.idFacTecnicos == idFacTecnicos && x.idPadre == 0 && x.idGrupo == idGrupo).ToList();

                if (padre.Count == 0)
                {

                    MessageBox.Show("El tipo de evaluación para el grupo de factor debe ser: " + cEvalFacTec + "; Actualmente es : "+cTipEvaFacTec, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                nMax = padre[0].P_Grupo;

                switch (idTipEvaFacTec)
                {
                    case 1 : //mayor
                        if (nPuntaje > nMax)
                        {
                            MessageBox.Show("El Puntaje Supera al maximo del grupo", "Mensaje Mayor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboTipoEvaluacion.Focus();
                            return false;
                        }
                        
                        break;
                    case 2: //suma
                        foreach (var item in lista)
                        {
                            if (item.idFacTecnicos == idFacTecnicos && item.idPadre != 0 && item.idGrupo == idGrupo)
                            {
                                nTotal = nTotal + item.nPuntaje;
                            }
                        }
                        if (nTotal + nPuntaje > nMax)
                        {
                            MessageBox.Show("El Puntaje Supera al maximo del grupo", "Mensaje Suma", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        break;
                    case 3: //DIRECT. PROPORCIONAL
                        foreach (var item in lista)
                        {
                            if (item.idFacTecnicos == idFacTecnicos && item.idPadre != 0 && item.idGrupo == idGrupo)
                            {
                                nTotal = nTotal + item.nPuntaje;
                            }
                        }
                        if (nTotal + nPuntaje > nMax)
                        {
                            MessageBox.Show("El Puntaje Supera al maximo del grupo", "Mensaje DIRECT. PROPORCIONAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        break;
                    case 4: //INVERS. PROPORCIONAL
                        if (nPuntaje > nMax)
                        {
                            MessageBox.Show("El Puntaje debe ser menor o igual al del grupo que es: "+ nMax, "Mensaje INVERS. PROPORCIONAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCriterioEva.RowCount<=0)
            {
                return;
            }
            var itemSel = (clsFactoresTecnicos)dtgCriterioEva.CurrentRow.DataBoundItem;
            if (itemSel.nOrden==0)
            {
                MessageBox.Show("No Puede Eliminar la Fila, Para Quitar Click en el Check de Los Factores Técnicos","Validar Criterios Evaluación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells[0].Value.ToString());

            int OrdenEliminar= lstModCriEva.Where(x => x.idFacTecnicos == itemSel.idFacTecnicos && x.idGrupo == xidGrupo).Max(y => y.nOrden);
            if (OrdenEliminar!=itemSel.nOrden)
            {
                MessageBox.Show("No Puede Eliminar la Fila, Para Quitar Selecione el Ultimo Criterio del Factor Técnico", "Validar Criterios Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;   
            }
            
            dtgCriterioEva.DataSource = null;


            //if (itemSel.idProceso == null)
            //{
                lstModCriEva.Remove(itemSel);
            //}
            ////else
            ////{
            //    itemSel.lVigente = false;
            //    lstModCriEva.Remove(itemSel);
            ////    lstNoVigCriEva.Add(itemSel);
            ////}
            dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == xidGrupo).ToList();
           
            ColorDataGrid();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
         
            foreach (DataGridViewRow nRow in dtgGrupo.Rows)
            {
                var lstFacTec = lstModCriEva.Where(x => x.idPadre == 0 && x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value)).ToList();
                foreach (var item in lstFacTec)
                {
                    int nCount = lstModCriEva.Where( x => x.idPadre != 0 && x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value) && x.idFacTecnicos==item.idFacTecnicos).Count();
                    if (nCount<=0)
                    {
                        MessageBox.Show("Falta Registrar Criterios de Evaluación para el Factor '" + item.cDecripcion + "' del Grupo : " + nRow.Cells[0].Value.ToString(), "Validar Factores Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            
            lstCriEva = lstModCriEva;
            lFlgAcepta = true;
            this.Dispose();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
        }

        private void dtgFactorTecnico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgFactorTecnico.CurrentCell is DataGridViewCheckBoxCell)
            {
                var detalleSele = ((clsTipoFactoresTecnicos)dtgFactorTecnico.CurrentRow.DataBoundItem);
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgFactorTecnico.CurrentCell;
                bool isChecked = (bool)checkbox.EditedFormattedValue;
                detalleSele.lVigente= isChecked;
                int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells[0].Value.ToString());
                if (isChecked)
                {
                    
                    int xcodigo, xidPadre;
                    string xDescripcion;
                    decimal xnpuntaje = 0; // Convert.ToDecimal(txtPuntaje.Text);
                    decimal xP_Grupo = Convert.ToDecimal(txtPGrupo.Text);
                    var items = lstModCriEva.Where(x => x.idFacTecnicos == detalleSele.idFacTecnicos && x.idGrupo == xidGrupo).ToList();
                    if (items.Count() <= 0)
                    {
                        xcodigo = 0;
                        xidPadre = 0;
                        xDescripcion = detalleSele.cFacTecnicos;
                        dtgCriterioEva.DataSource = null;
                        lstModCriEva.Add(new clsFactoresTecnicos()
                        {
                            nOrden = xcodigo,
                            cDecripcion = xDescripcion,
                            cTipoEval = cboTipoEvaluacion.Text,
                            idGrupo = xidGrupo,
                            idProceso = null,
                            idFacTecnicos = detalleSele.idFacTecnicos,
                            idTipoEvaFacTec = Convert.ToInt32(cboTipoEvaluacion.SelectedValue),
                            nPuntaje = xnpuntaje,
                            P_Grupo = xP_Grupo,
                            lVigente = true,
                            idPadre = xidPadre,
                            lSelect = true
                        });

                        buscarPlantillaFactorTecnico(detalleSele.idFacTecnicos);

                        dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == xidGrupo).ToList();
                        chcUsaPlantilla.Checked = false;
                    }
                }
                else
                {
                    var bList_Temp = lstModCriEva.Where(w => w.idFacTecnicos == detalleSele.idFacTecnicos && w.idGrupo == xidGrupo).ToList();
                    dtgCriterioEva.DataSource =null;
                    foreach (clsFactoresTecnicos p in bList_Temp)
                        lstModCriEva.Remove(p);
                    dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == xidGrupo).ToList();
                    chcUsaPlantilla.Checked = false;
                }
                
                ColorDataGrid();
            }
        }
        private void buscarPlantillaFactorTecnico(int idTipoFactor)
        {
            if (chcUsaPlantilla.Checked)
            {

                clsListaTipoFacTecnicos lstPlaCriEva = new clsListaTipoFacTecnicos();
                lstPlaCriEva = new clsCNProcesoAdjudicacion().buscaTipoFacTecnico(Convert.ToInt32(cboTipoPedido.SelectedValue), idTipoFactor);
                
                int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells[0].Value.ToString());

                //int xcodigo = lstModCriEva.Where(x => x.idFacTecnicos == idTipoFactor && x.idGrupo == xidGrupo).ToList().Count();
                int xcodigo = 1;
                foreach (var item in lstPlaCriEva)
                {
                    lstModCriEva.Add(new clsFactoresTecnicos()
                    {
                        nOrden = xcodigo++,
                        cDecripcion = item.cFacTecnicos,
                        cTipoEval = cboTipoEvaluacion.Text,
                        idGrupo = xidGrupo,
                        idProceso = 0,
                        idTipoEvaFacTec = Convert.ToInt32(cboTipoEvaluacion.SelectedValue),
                        idFacTecnicos = idTipoFactor,
                        lVigente = true,
                        nPuntaje = item.nPuntaje,
                        P_Grupo = 0,
                        idPadre = idTipoFactor,
                        lSelect = true
                    });
                }
            }
        }
        private void ColorDataGrid()
        {
            foreach (DataGridViewRow row in dtgCriterioEva.Rows)
                if (Convert.ToInt32(row.Cells["nOrden"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
                }
        }
        private void dtgFactorTecnico_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgFactorTecnico.RowCount <= 0)
                return;
            var itemSel = (clsTipoFactoresTecnicos)dtgFactorTecnico.CurrentRow.DataBoundItem;
            txtPGrupo.Text = itemSel.nPuntaje.ToString();
            grbCriEva.Text = "Criterio de Evaluación:" + itemSel.cFacTecnicos.ToString();
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[dtgGrupo.CurrentRow.Index].Cells[0].Value.ToString());
            int index = lstModCriEva.ToList().FindIndex(p => p.idFacTecnicos == itemSel.idFacTecnicos && p.idGrupo == xidGrupo);
            if (index!=-1)
            {
                if (dtgCriterioEva.DataSource==null)
                {
                    dtgCriterioEva.Rows[index].Selected = true;
                }
            }
            chcUsaPlantilla.Checked = false;
        }

        private void txtPGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var itemSel=(clsTipoFactoresTecnicos)dtgFactorTecnico.CurrentRow.DataBoundItem;
            if (e.KeyChar==(char)Keys.Return)
            {
                dtgCriterioEva.DataSource = null;
                foreach (var item in lstModCriEva)
                {
                    if (item.nOrden == 0 && itemSel.idFacTecnicos==item.idFacTecnicos)
                    {
                        item.P_Grupo = Convert.ToDecimal(txtPGrupo.Text.Trim());
                    }
                }
                dtgCriterioEva.DataSource = lstModCriEva.Where(x => x.idGrupo == x.idGrupo).ToList();
                ColorDataGrid();
            }
        }

        private void dtgCriterioEva_SelectionChanged(object sender, EventArgs e)
        {
            var itemSelCriEva = (clsFactoresTecnicos)dtgCriterioEva.CurrentRow.DataBoundItem;
        }

        private void frmGenFactorTecnico_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (lFlgAcepta)
            //{
            //    lstCriEva = lstNoVigCriEva; 
                
            //        var lstFinalCriEva = lstModCriEva.Union(lstNoVigCriEva.ToList()).ToList();
            //        lstCriEva.Clear();
            //        foreach (var item in lstFinalCriEva)
            //        {
            //            lstCriEva.Add(item);
            //        }
            //}
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            lFlgAcepta = true;
            this.ActualizarFactortecnico();
            if ( idProceso == 0)
            {
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegFactorTecnico(idProceso, lstCriEva);
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
                DataTable dtResp = new clsCNProcesoAdjudicacion().RegFactorTecnico(idProceso, lstCriEva);
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
            this.btnEditar1.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;

            this.txtDescripcion.Enabled = false;
            this.chcUsaPlantilla.Enabled = false;
            this.txtPGrupo.Enabled = false;
            this.cboTipoEvaluacion.Enabled = false;
            this.txtPuntaje.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;

        }
        private void ActualizarFactortecnico()
        {
            if (lFlgAcepta)
            {
                lstCriEva = lstModCriEva;

                //var lstFinalCriEva = lstModCriEva.Union(lstNoVigCriEva.ToList()).ToList();
                //lstCriEva.Clear();
                //foreach (var item in lstFinalCriEva)
                //{
                //    lstCriEva.Add(item);
                //}
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lFlgAcepta = false;
            ActualizarFactortecnico();
            txtDescripcion.Enabled = false;
            chcUsaPlantilla.Enabled = false;
            txtPGrupo.Enabled = false;
            cboTipoEvaluacion.Enabled = false;
            txtPuntaje.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;

            FormatoGrids(false);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            chcUsaPlantilla.Enabled = true;
            txtPGrupo.Enabled = true;
            cboTipoEvaluacion.Enabled = true;
            txtPuntaje.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            btnEditar1.Enabled = false;
            FormatoGrids(true);
        }
       
    }
}
