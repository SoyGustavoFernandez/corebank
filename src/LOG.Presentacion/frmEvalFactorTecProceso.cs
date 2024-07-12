using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmEvalFactorTecProceso : frmBase
    {

        #region Variables

        public clsListaDetalleProcesoAdj lstDetProAdj = new clsListaDetalleProcesoAdj();
        clsCNNotaPedido evaFacTec = new clsCNNotaPedido();
        clsListaEvaFactorTecnico lstModEvaFacTec = new clsListaEvaFactorTecnico();
        clsListaEvaFactorTecnico listaEvaFacTec = new clsListaEvaFactorTecnico();

        public int pIdProveedor;
        public int pIdProceso;
        public int nGrupo = 0;
        public int idVincuProveedor;
        public bool lContinuar = true;
        public bool lFlagAcep = false;
        public bool lConfirmado = false;
        public int idEstadoEva = 0;

        #endregion

        #region Constructores

        public frmEvalFactorTecProceso()
        {
            InitializeComponent();
        }

        public frmEvalFactorTecProceso(string cNompreEmpresa)
        {
            InitializeComponent();
            lblNombreEmpres.Text = cNompreEmpresa;
        }

        #endregion

        #region Eventos

        private void frmEvalFactorTecProceso_Load(object sender, EventArgs e)
        {
            listaEvaFacTec = new clsCNEvalProcAdj().buscarPlantillaEvaFacTecnico(pIdProceso, pIdProveedor);
            //Cargar Grupo

            dtgGrupo.SelectionChanged -= new EventHandler(dtgGrupo_SelectionChanged);

            int idGrupoant = 0;
            foreach (var item in lstDetProAdj)
            {
                if (item.idGrupo != null && item.idGrupo != idGrupoant && item.idGrupo == nGrupo)
                {
                    dtgGrupo.Rows.Add(item.idGrupo, item.cDesGrupo);
                    idGrupoant = (int)item.idGrupo;

                }
            }
            dtgGrupo.SelectionChanged += new EventHandler(dtgGrupo_SelectionChanged);
            actualizarDetalleGrupo();

            if (idVincuProveedor == 0)
            {
                habilitarBoton(false);
            }
            else
            {
                DataTable dtEvaFacTec = new clsCNEvalProcAdj().RetornaEvaFacTec(pIdProveedor, pIdProceso);
                foreach (var item1 in listaEvaFacTec)
                {
                    foreach (DataRow item2 in dtEvaFacTec.Rows)
                    {
                        if (item1.idFacTecnicos == Convert.ToInt32(item2["idFacTecnico"]) && item1.nOrden == Convert.ToInt32(item2["nOrden"])
                                && item1.idGrupo == Convert.ToInt32(item2["idGrupo"]))
                        {
                            item1.idEvaFacTec = Convert.ToInt32(item2["idEvaFacTec"]);
                            item1.CumpleReq = true;
                        }
                    }
                }
                habilitarBoton(true);
                foreach (var item in listaEvaFacTec)
                {
                    if (item.CumpleReq == true)
                    {
                        lstModEvaFacTec.Add(new clsEvaFactorTecnico(item));
                    }
                }
            }

            this.dtgEvaFacTec.ReadOnly = true;
            if (lConfirmado)
            {
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow nRow in dtgGrupo.Rows)
            {
                var lstFacTec = listaEvaFacTec.Where(x => x.idPadre == 0 && x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value)).ToList();
                foreach (var item in lstFacTec)
                {
                    int nCount = listaEvaFacTec.Where(x => x.idPadre != 0 && x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value) && x.idFacTecnicos == item.idFacTecnicos && x.CumpleReq == true).Count();
                    if (nCount == 0)
                    {
                        MessageBox.Show("Falta Registrar Criterios de Evaluación para el Factor '" + item.cDecripcion + "' del Grupo : " + nRow.Cells[0].Value.ToString(), "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (nCount > 1)
                    {
                        MessageBox.Show("Se Registró mas de un Criterio de Evaluación para el Factor '" + item.cDecripcion + "' del Grupo : " + nRow.Cells[0].Value.ToString(), "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            this.Dispose();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(false);

            ColorDataGrid();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarBoton(true);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            idEstadoEva = 3;
            bool lEstadoCalifica = true;
            foreach (DataGridViewRow nRow in dtgGrupo.Rows)
            {
                var lstFacTec = listaEvaFacTec.Where(x => x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value)).ToList();
                foreach (var item in lstFacTec)
                {
                    int nCount = listaEvaFacTec.Where(x => x.idGrupo == Convert.ToInt32(nRow.Cells[0].Value) && x.idFacTecnicos == item.idFacTecnicos && x.CumpleReq == true && x.nOrden == item.nOrden).Count();
                    if (nCount == 0)
                    {
                        MessageBox.Show("Falta Registrar Criterios de Evaluación para el Factor '" + item.cDecripcion + "' del Grupo : " + nRow.Cells[0].Value.ToString(), "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (nCount > 1)
                    {
                        MessageBox.Show("Se Registró mas de un Criterio de Evaluación para el Factor '" + item.cDecripcion + "' del Grupo : " + nRow.Cells[0].Value.ToString(), "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            DateTime dFechaReg = clsVarGlobal.dFecSystem;
            int idUsuReg = clsVarGlobal.User.idUsuario;
            if (listaEvaFacTec.Count == 0)
            {
                MessageBox.Show("No existen factores técnicos, debe configurarlos en Proceso de adquisición", "Validar Criterio de Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var item1 in listaEvaFacTec)
            {
                foreach (var item2 in lstModEvaFacTec)
                {
                    if (item1.idFacTecnicos == item2.idFacTecnicos && item1.nOrden == item2.nOrden && item1.idGrupo == item2.idGrupo)
                    {
                        if (item1.CumpleReq != item2.CumpleReq)
                        {
                            item1.lVigente = false;
                        }
                    }
                }
            }
            var lstFinal = listaEvaFacTec.Where(x => x.CumpleReq == true).ToList();
            clsListaEvaFactorTecnico lstfin = new clsListaEvaFactorTecnico();
            lstfin.AddRange(lstFinal);

            DataTable dtResp = new clsCNEvalProcAdj().cnGrabarEvaFactoreTecnicos(idVincuProveedor, pIdProveedor, dFechaReg, idUsuReg, idEstadoEva, lEstadoCalifica, lstfin);
            if (dtResp.Rows[0][0].ToString() != "0")
            {
                MessageBox.Show(dtResp.Rows[0][1].ToString(), "Registro de Evaluación de Factores Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lFlagAcep = true;
                this.Dispose();
            }

        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            actualizarDetalleGrupo();
        }

        private void dtgGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgGrupo_SelectionChanged(sender, e);
        }

        private void dtgGrupo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgGrupo_SelectionChanged(sender, e);
        }

        private void dtgEvaFacTec_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgEvaFacTec.CurrentRow == null)
                return;

            if (dtgEvaFacTec.Columns[e.ColumnIndex].Name == "nPuntajeDataGridViewTextBoxColumn")
            {
                if (string.IsNullOrEmpty(dtgEvaFacTec.CurrentRow.Cells["nPuntajeDataGridViewTextBoxColumn"].EditedFormattedValue.ToString()))
                {
                    dtgEvaFacTec.EditingControl.Text = "0";
                    return;
                }
            }

            if (e.ColumnIndex != 7)
                return;

            dtgEvaFacTec.CellValueChanged -= dtgEvaFacTec_CellValueChanged;

            decimal MaxValue = Convert.ToDecimal(dtgEvaFacTec.Rows[e.RowIndex].Cells[8].Value);
            decimal PuntajeAsig = Convert.ToDecimal(e.FormattedValue);
            if(PuntajeAsig < 0)
            {
                MessageBox.Show("El puntaje asignado no puede ser negativo", "Mensaje alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgEvaFacTec.EditingControl.Text = "0";
                return;
            }
            if (MaxValue < PuntajeAsig)
            {
                MessageBox.Show("El puntaje asignado supera al puntaje máximo del factor que es: " + MaxValue.ToString("#,0.00"), "Mensaje alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgEvaFacTec.EditingControl.Text = "0";
                return;
            }

            dtgEvaFacTec.CellValueChanged += dtgEvaFacTec_CellValueChanged;
        }

        private void dtgEvaFacTec_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEvaFacTec.DataSource == null)
                return;
            if (dtgEvaFacTec.RowCount == 0)
                return;

            int indice = e.RowIndex;
            int nColumna = e.ColumnIndex;
            if (nColumna == 10)
            {
                int idPadre = Convert.ToInt32(dtgEvaFacTec.Rows[indice].Cells[13].Value);
                bool lSelected = Convert.ToBoolean(dtgEvaFacTec.Rows[indice].Cells[nColumna].Value);
                if (idPadre != 0)
                {
                    actualizaPadre(idPadre, nColumna);
                    return;
                }

                int idDocExp = Convert.ToInt32(dtgEvaFacTec.Rows[indice].Cells[2].Value);

                SelecionarHijos(idDocExp, lSelected, nColumna, indice);
            }
        }

        private void dtgEvaFacTec_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 8;
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '-') && (txt.Text.Length > 0))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Métodos

        private void actualizaPadre(int idPadre, int nColumna)
        {
            dtgEvaFacTec.CellValueChanged -= dtgEvaFacTec_CellValueChanged;

            int nTotalElem = 0;
            int nTotalElemSel = 0;
            foreach (DataGridViewRow item in dtgEvaFacTec.Rows)
            {
                if (idPadre == Convert.ToInt32(item.Cells[13].Value))
                {
                    nTotalElem++;
                    if (Convert.ToBoolean(item.Cells[nColumna].Value))
                    {
                        nTotalElemSel++;
                    }
                }
            }

            foreach (DataGridViewRow item in dtgEvaFacTec.Rows)
            {
                if (idPadre == Convert.ToInt32(item.Cells[2].Value) && Convert.ToInt32(item.Cells[13].Value) == 0)
                {
                    item.Cells[nColumna].Value = (nTotalElemSel == nTotalElem) ? true : false;
                }
            }

            dtgEvaFacTec.CellValueChanged += dtgEvaFacTec_CellValueChanged;
        }

        private void SelecionarHijos(int idFacTecnicos, bool lBol, int nColumna, int indice)
        {
            dtgEvaFacTec.CellValueChanged -= dtgEvaFacTec_CellValueChanged;

            int idPadre = Convert.ToInt32(dtgEvaFacTec.Rows[indice].Cells[13].Value);
            if (idPadre != 0)
                return;

            foreach (DataGridViewRow item in dtgEvaFacTec.Rows)
            {
                if (Convert.ToInt32(item.Cells[2].Value) == idFacTecnicos)
                {
                    item.Cells[nColumna].Value = lBol;
                }
            }

            dtgEvaFacTec.CellValueChanged += dtgEvaFacTec_CellValueChanged;
        }

        private void ColorDataGrid()
        {
            if (dtgEvaFacTec.RowCount <= 0)
            {
                return;
            }
            dtgEvaFacTec.ReadOnly = false;
            foreach (DataGridViewRow row in dtgEvaFacTec.Rows)
            {
                if (Convert.ToInt32(row.Cells[3].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
                    row.ReadOnly = true;
                    row.Cells[10].ReadOnly = false;
                }
            }
        }

        private void actualizarDetalleGrupo()
        {
            if (dtgGrupo.RowCount <= 0)
            {
                return;
            }
            int fila = dtgGrupo.CurrentRow.Index;
            int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());

            dtgDetProAdj.DataSource = null;
            dtgDetProAdj.DataSource = lstDetProAdj.Where(x => x.idGrupo == xidGrupo).ToList();
            dtgEvaFacTec.DataSource = listaEvaFacTec.Where(x => x.idGrupo == xidGrupo).ToList();// && x.idProveedor == pIdProveedor).ToList();
            dtgEvaFacTec.Enabled = true;
            dtgEvaFacTec.ReadOnly = false;
            ColorDataGrid();
        }

        private void habilitarBoton(bool lActivo)
        {
            btnEditar1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;

            dtgEvaFacTec.ReadOnly = lActivo;

            if (!lActivo)
            {
                dtgEvaFacTec.ReadOnly = false;
                foreach (DataGridViewColumn item in dtgEvaFacTec.Columns)
                {
                    item.ReadOnly = true;
                }
                dtgEvaFacTec.Columns[10].ReadOnly = false;
                dtgEvaFacTec.Columns[7].ReadOnly = false;
            }
            else
            {
                dtgEvaFacTec.ReadOnly = true;
                foreach (DataGridViewColumn item in dtgEvaFacTec.Columns)
                {
                    item.ReadOnly = true;
                }
            }
        }

        private bool validarFormatoDecimal(int nFila, int nColumna)
        {
            try
            {
                decimal nValor = Convert.ToDecimal(dtgEvaFacTec.Rows[nFila].Cells[nColumna].EditedFormattedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("El Numero no es decimal", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgEvaFacTec.CancelEdit();
                return false;
            }

            return true;
        }

        #endregion

        
    }
}
