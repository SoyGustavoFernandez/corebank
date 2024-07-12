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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmMantenimientoOrdenes : frmBase
    {
        #region Variables Globales

        private int idValorado=0, idEstadoVal=0, nOrder, nFinSerie, idMoneda, idCuenta=0,idVincuCuenta=0;
        private clsCNValorados objValorados = new clsCNValorados();
        private DataTable dtValorados, dtEstadoVinc;
        private DataTable DetValorados = new DataTable();
        DataTable dtbIntervCta = new DataTable();
        private bool lIndBloqTot = false;

        #endregion
        #region Constructor
        public frmMantenimientoOrdenes()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            frmListaValoradosAsignados frmValoradosAsig = new frmListaValoradosAsignados();
            frmValoradosAsig.nEstadoVal = 2;
            frmValoradosAsig.idMoneda = idMoneda;
            frmValoradosAsig.idValorado = 1;
            frmValoradosAsig.ShowDialog();
            idValorado = frmValoradosAsig.idValorado;
            nFinSerie = frmValoradosAsig.nFin;
            nOrder = frmValoradosAsig.nOrden;
            this.txtNumSerie.Text = frmValoradosAsig.nSerie.ToString().PadLeft(7, '0');
            this.txtNumInicio.Text = frmValoradosAsig.nInicio.ToString().PadLeft(7, '0');


            if (Convert.ToInt32(this.txtNumSerie.Text) == 0 && Convert.ToInt32(this.txtNumInicio.Text) == 0 && Convert.ToInt32(this.txtNumFinal.Text) == 0)
            {
                if (dtValorados.Rows.Count>0)
                {
                    this.cboEstado.Enabled = true;
                    treeviewValorado.Enabled = true;
                }
                else
                    this.cboEstado.Enabled = false;
                this.cboLimitesVal1.Enabled = false;
                this.btnBusqueda.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnNuevo.Focus();
                return;
            }
            else
            {
                this.btnNuevo.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = true;
                this.cboLimitesVal1.Enabled = true;
                this.cboLimitesVal1.Focus();
                
            }
        }
        private void frmMantenimientoOrdenes_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
            this.conBusCtaAho.nTipOpe = 13;
         
            conBusCtaAho.pnIdMon = 0;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text))
            {
                if (Convert.ToInt32(this.conBusCtaAho.txtNroCta.Text.ToString().Trim())==0)
                {
                    MessageBox.Show("Debe de Ingresar Número de cuenta diferente de Cero(0)", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                idMoneda = conBusCtaAho.idMoneda;
                this.conBusCtaAho.txtNroCta.Enabled = false;
                this.conBusCtaAho.btnBusCliente.Enabled = false;
                idCuenta = Convert.ToInt32(conBusCtaAho.txtNroCta.Text.Trim());
                //Carga de Intervinientes
                clsCNDeposito clsDeposito = new clsCNDeposito();
                dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCuenta);
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    FormatoGridInterv();
                }
                //Carga de Valorados por Cuenta
                dtValorados = objValorados.CNListaValoradosxCuenta(idCuenta, 1,0);
                if (dtValorados.Rows.Count > 0)
                {
                   
                    this.cboEstado.Enabled = true;
                    this.btnNuevo.Enabled = true;
                    this.treeviewValorado.Enabled = true;
                }
                else
                {
                    this.cboEstado.Enabled = false;
                    this.treeviewValorado.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    this.btnNuevo.PerformClick();
                }
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.conBusCtaAho.txtNroCta.Enabled = true;
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.Focus();
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idEstadoVal = 1;
            idVincuCuenta = 0;
            this.DetValorados.Rows.Clear();
            this.btnNuevo.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnBusqueda.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.chcBase1.Checked = false;
            this.chcSelec.Checked = false;
            this.chcSelec.Enabled = false;
         //   this.btnEditar.Enabled = false;
            this.cboEstado.Enabled = false;
            this.chcBase1.Enabled = false;
            this.dtgDetalleVal.ClearSelection();
           // this.dtgIntervinientes.ClearSelection();
            this.btnBusqueda.Focus();
            this.treeviewValorado.Nodes.Clear();
            this.treeviewValorado.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lIndBloqTot = false;
            this.DetValorados.Rows.Clear();
            this.btnNuevo.Enabled = false;
            this.btnBusqueda.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
           // this.btnEditar.Enabled = false;
            this.chcBase1.Enabled = false;
            this.LimpiarControles();
            this.CargarDatos();
            this.conBusCtaAho.txtNroCta.Enabled = true;
            this.conBusCtaAho.btnBusCliente.Enabled = true;
            this.cboEstado.Enabled = false;
            this.conBusCtaAho.btnBusCliente.Focus();
            this.btnBusqueda.Enabled = false;
            this.cboLimitesVal1.Enabled = false;
            this.txtNumFinal.Text = "0000000";
            this.chcSelec.Enabled = false;
            this.txtMotivo.Enabled = false;
            this.conBusCtaAho.txtNroCta.Focus();
         
           
   
        }
        private void treeviewValorado_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Checked == true)
            {
                this.DetValorados.Rows.Clear(); 
                idVincuCuenta = Convert.ToInt32(e.Node.Tag.ToString());
                this.RetornaDetValorados(idCuenta, idVincuCuenta);
            }
            else
            {
                this.DetValorados.Rows.Clear();
                this.chcBase1.Enabled = false;
                this.chcSelec.Enabled = false;
                //this.btnEditar.Enabled = false;
            }
        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DetValorados.Rows.Clear();
            this.chcBase1.Checked = false;
            this.chcBase1.Enabled = false;
            this.chcSelec.Checked = false;
            this.chcSelec.Enabled = false;
            if (cboEstado.SelectedIndex > 0)
            {
                idEstadoVal = (int)this.cboEstado.SelectedValue;
                this.LoadTree(FiltrarDT(dtValorados, idEstadoVal));
            }
            else
                this.treeviewValorado.Nodes.Clear();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (nOrder > 1)
            {
                MessageBox.Show("Existe un Lote Anterior Pendiente de Asignación", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnBusqueda.Focus();
                return;
            }
            int nNumInicio = Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim());
            int nCantidad = Convert.ToInt32(this.cboLimitesVal1.Text.ToString().Trim());
            int nNumFin = Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim());
            int nserie = Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim());
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idUsuario = clsVarGlobal.User.idUsuario;
            DateTime dFechaOpe = clsVarGlobal.dFecSystem;
            DataSet dsDetValorados = new DataSet("dsDetValorados");
            string XMLDetValorados;
            if (DetValorados.Rows.Count <= 0)
            {
                DetValorados = objValorados.CNGeneraSerieValorados(idVincuCuenta, idCuenta, nNumInicio, nCantidad);
            }
            else
            {
                if (idEstadoVal == 3)
                {
                    DetValorados.Columns["idEstadoVal"].ReadOnly = false;
                    //for (int i = 0; i < DetValorados.Rows.Count; i++)
                    //{
                    //    DetValorados.Rows[i]["idEstadoVal"] = Convert.ToInt32(dtgDetalleVal.Rows[i].Cells["idEstadoVal"].Value);
                    //}
                    for (int i = 0; i < DetValorados.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(DetValorados.Rows[i]["lIndAplica"]) == 1)
                        {
                            DetValorados.Rows[i]["idEstadoVal"] = 3;
                        }

                    }
                }
                //else
                //{
                    
                //}

            }
            dsDetValorados.Tables.Add(DetValorados);
            XMLDetValorados = dsDetValorados.GetXml();
            XMLDetValorados = clsCNFormatoXML.EncodingXML(XMLDetValorados);
            dsDetValorados.Tables.Clear();
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            int idUsuMod = clsVarGlobal.User.idUsuario;
            string cMotivo = this.txtMotivo.Text.ToString();

            DataTable dtResp = objValorados.CNGuardarVinculacion(idVincuCuenta, idValorado, idCuenta, nserie,
                                                                    nNumInicio, nNumFin, idUsuario, idAgencia,
                                                                    dFechaOpe, idEstadoVal, XMLDetValorados, dFechaMod,
                                                                    idUsuMod, cMotivo, lIndBloqTot);
            if ((int)dtResp.Rows[0]["Resultado"] > 0)
            {
                MessageBox.Show("Los Datos se Guardaron Correctamente", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCancelar.PerformClick();
            }
            else
            {
                MessageBox.Show("Error el Guardar los Datos", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
           

        }
        private void cboLimitesVal1_Validating(object sender, CancelEventArgs e)
        {
            int nValor = Convert.ToInt32(this.cboLimitesVal1.Text.Trim());
            this.txtNumFinal.Text = (Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim()) + (nValor - 1)).ToString().PadLeft(7, '0');
            if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) > nFinSerie)
            {
                MessageBox.Show("Número Final de Serie de Valorados No Válido. Seleccione una cantidad menor", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboLimitesVal1.Focus();
                return;
            }
        }

        private void cboLimitesVal1_TextChanged(object sender, EventArgs e)
        {
            
    
        }

        private void dtgDetalleVal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
        #region Metodos
        private void LimpiarControles()
        {

            idCuenta = 0;
            idVincuCuenta = 0;

            nOrder = 0;
            idEstadoVal = 0;
            idValorado = 0;
            dtValorados.Rows.Clear();
            DetValorados.Rows.Clear();
            this.conBusCtaAho.txtCodCli.Clear();
            this.conBusCtaAho.txtNombre.Clear();
            this.conBusCtaAho.txtNroCta.Clear();
            this.conBusCtaAho.txtNroDoc.Clear();
            this.conBusCtaAho.txtCodAge.Clear();
            this.conBusCtaAho.txtCodMon.Clear();
            this.conBusCtaAho.txtCodMod.Clear();
            this.conBusCtaAho.txtCodIns.Clear();

            this.cboEstado.SelectedIndex = -1;
            this.dtgDetalleVal.DataSource = "";
            if (dtgIntervinientes.Rows.Count > 0)
            {
                dtbIntervCta.Rows.Clear();
            }
            this.chcBase1.Checked = false;
            this.chcSelec.Checked = false;

           
            this.cboLimitesVal1.SelectedValue = 1;
            nFinSerie = 1;
            this.txtNumSerie.Text = "0000001";
            this.txtNumInicio.Text = "0000001";
            this.txtNumFinal.Text = "0000000";
            this.treeviewValorado.Nodes.Clear();
            this.txtMotivo.Clear();
            this.cboLimitesVal1.Validating -= new CancelEventHandler(cboLimitesVal1_Validating);
        }
        private void CargarDatos()
        {
            dtEstadoVinc = objValorados.CNListaEstVincu();
            this.cboEstado.DataSource = dtEstadoVinc;
            this.cboEstado.DisplayMember = dtEstadoVinc.Columns["cEstadoVincu"].ToString();
            this.cboEstado.ValueMember = dtEstadoVinc.Columns["idEstadoVincu"].ToString();
        }
        private void RetornaDetValorados(int idCuenta, int idVincuCuenta)
        {
            DetValorados = objValorados.CNListaDetalleValorados(idCuenta, idVincuCuenta);
            if (this.dtgDetalleVal.ColumnCount > 0)
            {
                this.dtgDetalleVal.Columns.Clear();
            }
            if (DetValorados.Rows.Count > 0)
            {
                this.dtgDetalleVal.DataSource = DetValorados;
                this.FormatoGridVal();
                this.SortGridDetValorados();
                this.HabilitarGridDetalle(true);
                if ((int)cboEstado.SelectedValue == 3)
                {
                    //this.btnEditar.Enabled = false;
                    this.chcBase1.Enabled = false;
                    this.chcSelec.Enabled = false;
                }
                else
                {
                    // this.btnEditar.Enabled = true;
                    this.chcBase1.Enabled = true;
                    this.chcSelec.Enabled = true;
                }


            }
            else
            {
                //this.btnEditar.Enabled = false;
                this.chcBase1.Enabled = false;
            }
                
                
        }
        private void FormatoGridVal()
        {
            dtgDetalleVal.Columns["idVincuCuenta"].Visible = false;
            dtgDetalleVal.Columns["idCuenta"].Visible = false;
            dtgDetalleVal.Columns["idEstadoVal"].Visible = false;
            dtgDetalleVal.Columns["nSerie"].Visible = false;

            dtgDetalleVal.Columns["nNumValorado"].HeaderText = "Nro.Ord";
        //    dtgDetalleVal.Columns["cmb"].HeaderText = "Estado";
            dtgDetalleVal.Columns["idKardex"].HeaderText = "Kardex";
            dtgDetalleVal.Columns["dFechaOpe"].HeaderText = "Fecha.Ope";
            dtgDetalleVal.Columns["cEstadoVincu"].HeaderText = "Estado";
            dtgDetalleVal.Columns["lIndAplica"].HeaderText = "X";

            dtgDetalleVal.Columns["nNumValorado"].Width = 50;
           // dtgDetalleVal.Columns["cmb"].Width = 80;
            dtgDetalleVal.Columns["idKardex"].Width = 70;
            dtgDetalleVal.Columns["dFechaOpe"].Width = 70;
            dtgDetalleVal.Columns["cEstadoVincu"].Width = 70;
            dtgDetalleVal.Columns["lIndAplica"].Width = 30;
        }

        private DataTable FiltrarDT(DataTable dt, int idValorado)
        {
            try
            {
                DataTable dtnew;
                var query = from d in dtValorados.AsEnumerable()
                            where (Convert.ToInt32(d["idEstadoVinc"]) == idValorado)
                            select d;
                if (query.Count() > 0)
                {
                    dtnew = query.CopyToDataTable();
                }
                else
                {
                    dtnew = new DataTable();
                }

                return dtnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void LoadTree(DataTable dt)
        {
            DataTable dtMenu = dt;
            this.treeviewValorado.Nodes.Clear();
            if (dt.Rows.Count > 0)
            {
                TreeNode Padre= new TreeNode();
                TreeNode Hijo;
                int nserie = Convert.ToInt32(dt.Rows[0]["nSerie"]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Hijo = new TreeNode();
                    Hijo.Text = dt.Rows[i]["nInicio"].ToString() + "-" + dt.Rows[i]["nFin"].ToString();
                    Hijo.Tag = dt.Rows[i]["idVincuCuenta"].ToString();
                    Hijo.NodeFont = new Font("Comic Sans", 8F, System.Drawing.FontStyle.Regular);
                    Hijo.ToolTipText = dt.Rows[i]["nInicio"].ToString() + "-" + dt.Rows[i]["nFin"].ToString();
                    if (Convert.ToInt32(dt.Rows[i]["Row"].ToString()) == 1)
                    {
                        Padre = new TreeNode();
                        Padre.Text = dt.Rows[i]["nSerie"].ToString();
                        Padre.Tag = dt.Rows[i]["nSerie"];
                        this.treeviewValorado.Nodes.Add(Padre);
                        Padre.Nodes.Add(Hijo);
                    }
                    else
                    {
                        Padre.Nodes.Add(Hijo);
                    }

                }

             this.treeviewValorado.ExpandAll();
            }
        }

        public void HabilitarGridDetalle(Boolean bVal)
        {
           // dtValorados.
            this.dtgDetalleVal.ReadOnly = !bVal;
            this.dtgDetalleVal.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["idKardex"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["idEstadoVal"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["dFechaOpe"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["lIndAplica"].ReadOnly = !bVal;
            for (int i = 0; i < this.dtgDetalleVal.Rows.Count; i++)
            {
                if (Convert.ToInt32(this.dtgDetalleVal.Rows[i].Cells["idEstadoVal"].Value) == 1)
                {
                    this.dtgDetalleVal.Rows[i].Cells["lIndAplica"].ReadOnly = false;
                }
                else
                {
                    this.dtgDetalleVal.Rows[i].Cells["lIndAplica"].ReadOnly = true;
                }
            }

        }
        private bool HabilitarChek()
        {
            bool rResp = true;
            int fila = 0;
            while (fila < this.dtgDetalleVal.Rows.Count)
            {
                if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["idEstadoVal"].Value) == 3)
                {
                    if (fila==this.dtgDetalleVal.Rows.Count)
                    {
                        return rResp = false;
                        break;
                 
                    }
                }
                
                fila++;
            }
            return rResp;
        }
        public void FormatoGridInterv()
        {

        }
        private void SortGridDetValorados()
        {
            dtgDetalleVal.Columns["idVincuCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nSerie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nNumValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idKardex"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idEstadoVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["dFechaOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        #endregion

        private void dtgDetalleVal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = e.RowIndex;
            if (dtgDetalleVal.Rows.Count > 0)
            {
                DetValorados.Columns["lIndAplica"].ReadOnly = false;
                if (Convert.ToInt32(dtgDetalleVal.Rows[fila].Cells["idEstadoVal"].Value) != 1)
                {
                    dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value = 0;
                }

            }
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSelec.Checked)
            {
                for (int i = 0; i < DetValorados.Rows.Count; i++)
                {
                    DetValorados.Columns["lIndAplica"].ReadOnly = false;
                    if (Convert.ToInt32(dtgDetalleVal.Rows[i].Cells["idEstadoVal"].Value) != 1)
                    {
                        dtgDetalleVal.Rows[i].Cells["lIndAplica"].Value = false;
                    }
                    else
                    {
                        dtgDetalleVal.Rows[i].Cells["lIndAplica"].Value = true;
                    }
                }
                dtgDetalleVal.Refresh();
            }
            else
            {
                this.chcBase1.Checked = false;
                foreach (DataRow NRow in DetValorados.Rows)
                {
                    NRow["lIndAplica"] = false;
                }
                dtgDetalleVal.Refresh();
               
            }
        }

        private void chcBase1_CheckedChanged_1(object sender, EventArgs e)
        {
           

            if (this.chcBase1.Checked == true)
            {

                int fila = 0;
                int nContFila = 0;
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    MessageBox.Show("Seleccione Item a Anular", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (nContFila == this.dtgDetalleVal.Rows.Count)
                {
                    lIndBloqTot = true;
                }
                idEstadoVal = 3;
                this.btnGrabar.Enabled = true;
                this.txtMotivo.Enabled = true;
                this.txtMotivo.Focus();
            }
            else
            {
                lIndBloqTot = false;
                this.txtMotivo.Enabled = false;
                this.txtMotivo.Clear();
                this.btnGrabar.Enabled = false;
            }
        
        }

        private void dtgDetalleVal_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgDetalleVal.Rows.Count > 0)
            {
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    idEstadoVal = 1;
                }
            }
        }

        private void dtgDetalleVal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgDetalleVal.Rows.Count > 0)
            {
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    idEstadoVal = 1;
                }
            }
        }

        private void dtgDetalleVal_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDetalleVal.IsCurrentCellDirty)
            {
                dtgDetalleVal.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void cboLimitesVal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nValor = Convert.ToInt32(this.cboLimitesVal1.Text.Trim());
            this.txtNumFinal.Text = (Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim()) + (nValor - 1)).ToString().PadLeft(7, '0');
            if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) > nFinSerie)
            {
                MessageBox.Show("Número Final de Serie de Valorados No Válido. Seleccione una cantidad menor", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboLimitesVal1.Focus();
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }   
}
