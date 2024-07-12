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
    public partial class frmGenCalendarioPro : frmBase
    {

        #region Variables

        clsCalendarioAdjudicacion calendarioAdjud = null;
        public clsListaCalendarioAdj lstCalendario=new clsListaCalendarioAdj();
        clsListaCalendarioAdj lstModCalendario = new clsListaCalendarioAdj();
        clsListaCalendarioAdj lstNoVigCalendario = new clsListaCalendarioAdj();
        clsCNProcesoAdjudicacion clsNotPedido = new clsCNProcesoAdjudicacion();
        BindingSource bs = new BindingSource();
        public int IdTipoProceso = 0, idProceso;
        bool lFlagAcep = false;
        public bool lConfirmado = false;

        #endregion

        #region Eventos 

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lFlagAcep = true;
          //  this.Dispose();
        }

        private void frmGenCalendarioPro_Load(object sender, EventArgs e)
        {
            controlObjetos(1);
            lstCalendario = clsNotPedido.buscaCalendarioProAdj(idProceso);
            if(lstCalendario.Count > 0)
            {
                this.ActualizarListaCalendario();
                controlObjetos(3);
            }

            bs.DataSource = lstModCalendario;
            dtgCalendario.DataSource = null;
            dtgCalendario.DataSource = bs;
            dtgCalendario.Refresh();
            this.dtpFechaIni.Value = clsVarGlobal.dFecSystem;
            this.dtpdFechaFin.Value = clsVarGlobal.dFecSystem;
            this.CargarDatos();
            this.HabilitarGrid(true);
            ActualizarDatosListaCalendario();
            if (lConfirmado)
            {
                this.btnGrabar1.Enabled = false;
                this.btnEditar1.Enabled = false;
                this.btnCancelar1.Enabled = false;

                controlObjetos(3);
            }
            else
            {
                if (lstCalendario.Count == 0)
                {
                    this.btnGrabar1.Enabled = true;
                    this.btnEditar1.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    this.btnAgregar1.Enabled = true;
                    this.btnQuitar2.Enabled = true;

                    controlObjetos(1);
                }
                if (lstCalendario.Count > 0)
                {
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = true;
                    this.btnCancelar1.Enabled = false;
                    this.btnAgregar1.Enabled = false;
                    this.btnQuitar2.Enabled = false;

                    controlObjetos(3);
                }
            }

        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            txtObservacion.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnAgregar1_Click_1(object sender, EventArgs e)
        {
            if (this.dtgEtapaProceso.RowCount == 0)
            {
                return;
            }

            if (!ValidaAgrega())
                return;

            int nfila = this.dtgEtapaProceso.SelectedCells[0].RowIndex;
            int nTotalFilas = this.dtgEtapaProceso.Rows.Count;
            if (Convert.ToBoolean(this.dtgEtapaProceso.Rows[nfila].Cells["lSelect"].Value)==false)
            {
                MessageBox.Show("Seleccione la Etapa a añadir", "Validar Calendario del Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (dtpdFechaFin.Value < dtpFechaIni.Value)
            {
                MessageBox.Show("La Fecha de Inicio no puede ser menor que la Fecha Final", "Validar Calendario del Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (dtpFechaIni.Value<clsVarGlobal.dFecSystem)
            {
                 MessageBox.Show("La Fecha de Inicio no puede ser menor que la Fecha del Sistema", "Validar Calendario del Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            calendarioAdjud = new clsCalendarioAdjudicacion();
            calendarioAdjud.idCalendario = 0;
            calendarioAdjud.idProceso = idProceso;
            calendarioAdjud.idEtapaCalendario = Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["idEtapaCalendario"].Value);
            calendarioAdjud.cEtapaCalendario = this.dtgEtapaProceso.Rows[nfila].Cells["cEtapaCalendario"].Value.ToString();
            calendarioAdjud.nOrden = Convert.ToInt32(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nOrdenEtapa"].Value));

            //Valida si ya existe en el registro la Etapa a Añadir
            var list = bs.DataSource;
            var validaexiste = lstModCalendario.Where(x => x.idEtapaCalendario == calendarioAdjud.idEtapaCalendario).Count();
            if (validaexiste > 0)
            {
                 MessageBox.Show("Ya Existe la Etapa en el Calendario", "Validación de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //Valida el orden de inserción
            int nOrdenEtapa=0;
            if (this.dtgCalendario.Rows.Count > 0)
            {
                nOrdenEtapa = lstModCalendario.Select(x => x.nOrden).ToList().Last();
            }
            //if (this.dtgCalendario.Rows.Count > 0 && Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nOrdenEtapa"].Value) != nOrdenEtapa + 1)
            //{
            //    MessageBox.Show("Registre en orden las etapas del Proceso", "Validación de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    ((DataGridViewCheckBoxCell)dtgEtapaProceso.Rows[nfila].Cells["lSelect"]).Value = false;
            //    dtgEtapaProceso.Rows[nfila].Cells["cEstado"].Value = 1;
            //    ((DataTable)dtgEtapaProceso.DataSource).AcceptChanges();
            //    dtgEtapaProceso.EndEdit();
            //    return;
            //}

            if (this.dtgCalendario.Rows.Count>0)
            {
                var ValidFecAnt = lstModCalendario.Select(x => x.dFechaFin).ToList().Last();
                if (this.dtpFechaIni.Value < ValidFecAnt)
                {
                    MessageBox.Show("La fecha de Inicio de la Etapa no puede ser menor que la fecha final de la etapa anterior", "Validación de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }            

            if (this.chcUtilizaPlantilla.Checked)
            {

                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value = this.dtpFechaIni.Value;
                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value = this.dtpFechaIni.Value.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nDiasEtapa"].Value));
                this.dtpdFechaFin.Value = this.dtpFechaIni.Value.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nDiasEtapa"].Value));
                if (nfila<nTotalFilas-1)
                {
                    this.dtgEtapaProceso.Rows[nfila + 1].Cells["dFechaIni"].Value = this.dtpdFechaFin.Value.AddDays(1);
                    this.dtgEtapaProceso.Rows[nfila + 1].Cells["dFechaFin"].Value = this.dtpdFechaFin.Value.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila + 1].Cells["nDiasEtapa"].Value) + 1);
 
                }
                
            }
            else
            {
                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value = this.dtpFechaIni.Value;
                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value = this.dtpdFechaFin.Value;
                if (nfila < nTotalFilas-1)
                {
                    this.dtgEtapaProceso.Rows[nfila + 1].Cells["dFechaIni"].Value = this.dtpdFechaFin.Value.AddDays(1);
                    this.dtgEtapaProceso.Rows[nfila + 1].Cells["dFechaFin"].Value = this.dtpdFechaFin.Value.AddDays(1);
                }
               
            }

            calendarioAdjud.dFechaInicio = Convert.ToDateTime(this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value);
            calendarioAdjud.dFechaFin = Convert.ToDateTime(this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value);
            calendarioAdjud.cObservaciones = txtObservacion.Text;
            calendarioAdjud.idUsuReg = clsVarGlobal.User.idUsuario;
            calendarioAdjud.dFechaReg = clsVarGlobal.dFecSystem;
            calendarioAdjud.lVigente = true;
            this.dtgEtapaProceso.Rows[nfila].Cells["lSelect"].ReadOnly = true;
            this.dtgEtapaProceso.Rows[nfila].Cells["cEstado"].Value = 1;
            //dtgCalendario.DataSource = null;
            
            bs.Add(calendarioAdjud);
            this.dtgCalendario.Refresh();
            //bs.DataSource = lstModCalendario;

            //dtgCalendario.DataSource = bs; 
        }

        private bool ValidaAgrega()
        {
            if (dtpFechaIni.Value < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial no puede ser menor que la Fecha del Sistema", "Registro de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaIni.Focus();
                dtpFechaIni.Select();
                return false;
            }
            if (dtpdFechaFin.Value < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Final no puede ser menor que la Fecha del Sistema", "Registro de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpdFechaFin.Focus();
                dtpdFechaFin.Select();
                return false;
            }
            if (dtpFechaIni.Value > dtpdFechaFin.Value)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor que la Fecha Final", "Registro de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaIni.Focus();
                dtpFechaIni.Select();
                return false;
            }
            return true;
        }

        private void dtpFechaIni_Leave(object sender, EventArgs e)
        {
            if (dtgEtapaProceso.SelectedRows.Count == 0)
                return;

            var fila = dtgEtapaProceso.SelectedRows[0];
            if (chcUtilizaPlantilla.Checked)
            {
                dtpdFechaFin.Value = dtpFechaIni.Value.AddDays(Convert.ToInt32(fila.Cells["nDiasEtapa"].Value));
            }
            fila.Cells["dFechaIni"].Value = dtpFechaIni.Value;
            fila.Cells["dFechaFin"].Value = dtpdFechaFin.Value;
        }

        private void dtpdFechaFin_Leave(object sender, EventArgs e)
        {
            if (dtgEtapaProceso.SelectedRows.Count == 0)
                return;

            var fila = dtgEtapaProceso.SelectedRows[0];
            if (chcUtilizaPlantilla.Checked)
            {
                dtpdFechaFin.Value = dtpFechaIni.Value.AddDays(Convert.ToInt32(fila.Cells["nDiasEtapa"].Value));
            }
            fila.Cells["dFechaIni"].Value = dtpFechaIni.Value;
            fila.Cells["dFechaFin"].Value = dtpdFechaFin.Value;
        }

        private void frmGenCalendarioPro_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (lFlagAcep)
            //{

            //    var lstFinalCalendario = lstModCalendario.Union(lstNoVigCalendario);
            //    lstCalendario.Clear();
            //    foreach (var item in lstFinalCalendario)
            //    {
            //        lstCalendario.Add(item);
            //    }
            //}
        }

        private void btnQuitar2_Click(object sender, EventArgs e)
        {

            if (this.dtgCalendario.Rows.Count>0)
            {
                var itemselec = (clsCalendarioAdjudicacion)dtgCalendario.CurrentRow.DataBoundItem;
                if (idProceso==0)
                {
                    //lstModCalendario.Remove(itemselec);
                    bs.Remove(itemselec);
                }
                else
                {
                    int i = dtgCalendario.RowCount;
                    itemselec.lVigente = false;
                    bs.Remove(itemselec);
                    //lstModCalendario.Remove(itemselec);
                    //lstNoVigCalendario.Add(itemselec);
                }
                for (int i = 0; i < dtgEtapaProceso.Rows.Count; i++)
                {
                    int idcalendario = Convert.ToInt32(this.dtgEtapaProceso.Rows[i].Cells["idEtapaCalendario"].Value);
                    if (idcalendario == itemselec.idEtapaCalendario)
                    {
                        this.dtgEtapaProceso.Rows[i].Cells["lSelect"].ReadOnly = false;
                        ((DataGridViewCheckBoxCell)dtgEtapaProceso.Rows[i].Cells["lSelect"]).Value = false;
                        dtgEtapaProceso.Rows[i].Cells["cEstado"].Value = 0;
                        
                    }
                }
                ((DataTable)dtgEtapaProceso.DataSource).AcceptChanges();
                dtgEtapaProceso.EndEdit();
              
            }
            else
            {
                MessageBox.Show("No Existe registro a Eliminar","Registro de Calendario",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            //dtgCalendario.DataSource = null;
            //bs.ResetBindings(false);
            //bs.DataSource = lstModCalendario;
            //dtgCalendario.DataSource = bs;
            //dtgCalendario.Refresh();
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dtgEtapaProceso.RowCount == 0)
            {
                return;
            }
            //this.dtgEtapaProceso.Rows[0].Selected=true;
            if (this.chcUtilizaPlantilla.Checked)
            {
                if (this.dtgEtapaProceso.Rows.Count>0)
                {
                    int nfila = this.dtgEtapaProceso.SelectedCells[0].RowIndex;
                    //if (Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nOrdenEtapa"].Value)==1)
                    //{
                    //    this.dtpFechaIni.Enabled = true;
                    //    this.dtpdFechaFin.Enabled = false;
                    //}
                    //else
                    //{
                    //    this.dtpFechaIni.Enabled = false;
                    //    this.dtpdFechaFin.Enabled = false;
                    //}
                    if (nfila > 0)
                    {
                        var validaexiste = lstModCalendario.ToList().OrderBy(x => x.dFechaFin).LastOrDefault();
                        if (validaexiste == null)
                            return;
                        DateTime dFecha = validaexiste.dFechaFin;
                        this.dtpFechaIni.Value = dFecha.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila - 1].Cells["nDiasEtapa"].Value) + 1);
                        this.dtpdFechaFin.Value = dtpFechaIni.Value.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nDiasEtapa"].Value));
                    }
                    else
                    {
                        
                        this.dtpdFechaFin.Value = dtpFechaIni.Value.AddDays(Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nDiasEtapa"].Value));
                    }
                    this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value = this.dtpFechaIni.Value;
                    this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value = this.dtpdFechaFin.Value;
                }
            }
            else
            {
                //this.dtpFechaIni.Enabled = true;
                //this.dtpdFechaFin.Enabled = true;
            }
        }

        private void dtgEtapaProceso_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgEtapaProceso.RowCount == 0)
            {
                return;
            }
            int nfila = e.RowIndex;
            this.txtObservacion.Focus();
            if (this.dtgEtapaProceso.Rows[nfila].Cells["cObservaciones"].Value.ToString().Length < 10)
            {
                this.txtObservacion.Clear();
            }
            if (this.dtgEtapaProceso.Rows.Count > 0)
            {
                //this.txtObservacion.Text = this.dtgEtapaProceso.Rows[nfila].Cells["cObservaciones"].Value.ToString();
            }
            if ((int)this.dtgEtapaProceso.Rows[nfila].Cells["cEstado"].Value==0)
            {
                this.dtgEtapaProceso.Rows[nfila].Cells["lSelect"].Value = false;
            }
            if (this.chcUtilizaPlantilla.Checked)
            {
                if (this.dtgEtapaProceso.Rows.Count > 0)
                {
                    if (Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["nOrdenEtapa"].Value) == 1)
                    {
                        //this.dtpFechaIni.Enabled = true;
                        //this.dtpdFechaFin.Enabled = false;

                    }
                    else
                    {
                        //this.dtpFechaIni.Enabled = false;
                        //this.dtpdFechaFin.Enabled = false;
                    }
                }
            }
            else
            {
                //this.dtpFechaIni.Enabled = true;
                //this.dtpdFechaFin.Enabled = true;
            }
            if (nfila > 0 && Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["cEstado"].Value)==0)
            {
                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value = Convert.ToDateTime(this.dtgEtapaProceso.Rows[nfila - 1].Cells["dFechaFin"].Value).AddDays(1);
                this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value = this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value;
            }

            this.dtpFechaIni.Value = Convert.ToDateTime(this.dtgEtapaProceso.Rows[nfila].Cells["dFechaIni"].Value);
            this.dtpdFechaFin.Value = Convert.ToDateTime(this.dtgEtapaProceso.Rows[nfila].Cells["dFechaFin"].Value);
            if (Convert.ToInt32(this.dtgEtapaProceso.Rows[nfila].Cells["cEstado"].Value)==1)
            {
                this.txtObservacion.Enabled = false;
            }
            else
            {
                this.txtObservacion.Enabled = true;
            }
          //  this.txtObservacion.SelectAll();

            
        }

        private void dtgCalendario_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nfila = e.RowIndex;
            if (this.dtgCalendario.Rows.Count > 0)
            {

            }
        }

        private void dtgCalendario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgCalendario.IsCurrentCellDirty)
            {
                dtgCalendario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgEtapaProceso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgEtapaProceso.IsCurrentCellDirty)
            {
                dtgEtapaProceso.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtObservacion_Leave(object sender, EventArgs e)
        {
            if (dtgEtapaProceso.CurrentRow!= null)
            {
                //this.dtgEtapaProceso.CurrentRow.Cells["cObservaciones"].Value = this.txtObservacion.Text;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            lFlagAcep = true;
            this.ActualizarCalendario();
            if (idProceso == 0)
            {
                DataTable dtResp = clsNotPedido.RegCalendario(idProceso, lstCalendario);
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
                DataTable dtResp = clsNotPedido.RegCalendario(idProceso, lstCalendario);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) == 0)
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Se Actualizó Correctamente el Proceso", "Edición del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.btnEditar1.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.btnAgregar1.Enabled = false;
            this.btnQuitar2.Enabled = false;
            this.chcUtilizaPlantilla.Enabled = false;
            this.dtpFechaIni.Enabled = false;
            this.dtpdFechaFin.Enabled = false;
            this.txtObservacion.Enabled = false;
            controlObjetos(3);

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lFlagAcep = false;
            this.ActualizarCalendario();
            ActualizarDatosListaCalendario();
            this.btnEditar1.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnCancelar1.Enabled = false;

            controlObjetos(3);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.btnEditar1.Enabled = false;
            this.btnGrabar1.Enabled = true;
            this.btnCancelar1.Enabled = true;

            controlObjetos(2);
        }

        #endregion

        #region Metodos

        public frmGenCalendarioPro()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            clsCNAdquisionesLogistica listEtapaCalendario = new clsCNAdquisionesLogistica();
            DataTable dt = listEtapaCalendario.listarEtapaCalendario(IdTipoProceso);
            dt.Columns.Add("dFechaIni",typeof (DateTime));
            dt.Columns.Add("dFechaFin",typeof (DateTime));
            dt.Columns.Add("cEstado",typeof(int));

            dt.Columns["lSelect"].ReadOnly=false;
            dt.Columns["cObservaciones"].ReadOnly = false;
            dt.Columns["dFechaIni"].ReadOnly = false;
            dt.Columns["dFechaFin"].ReadOnly = false;
            dt.Columns["cEstado"].ReadOnly = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["dFechaIni"] = clsVarGlobal.dFecSystem;
                dt.Rows[i]["dFechaFin"] = clsVarGlobal.dFecSystem;
                dt.Rows[i]["cEstado"] = 0;
            } 
            this.dtgEtapaProceso.DataSource = dt;

            FormatoGridEtapaProceso();
        }

        private void HabilitarGrid(bool val)
        
        {
            this.dtgEtapaProceso.ReadOnly = !val;
            this.dtgEtapaProceso.Columns["idEtapaCalendario"].ReadOnly = val;
            this.dtgEtapaProceso.Columns["cEtapaCalendario"].ReadOnly = val;
            this.dtgEtapaProceso.Columns["nOrdenEtapa"].ReadOnly = val;
            this.dtgEtapaProceso.Columns["lSelect"].ReadOnly = !val;
            this.dtgEtapaProceso.Columns["cObservaciones"].ReadOnly = !val;
            this.dtgEtapaProceso.Columns["nDiasEtapa"].ReadOnly = val;
            this.dtgEtapaProceso.Columns["dFechaIni"].ReadOnly = !val;
            this.dtgEtapaProceso.Columns["dFechaFin"].ReadOnly = !val;
            this.dtgEtapaProceso.Columns["cEstado"].ReadOnly = !val;
            

        }

        public void ActualizarCalendario()
        {
            if (lFlagAcep)
            {

                var lstFinalCalendario = lstModCalendario;
                lstCalendario.Clear();
                foreach (var item in lstFinalCalendario)
                {
                    lstCalendario.Add(item);
                }
            }
            this.lstModCalendario.Clear();
            this.ActualizarListaCalendario();
          
        }

        private void ActualizarListaCalendario()
        {

            foreach (var item in lstCalendario)
            {
                if (item.lVigente)
                {
                    lstModCalendario.Add(new clsCalendarioAdjudicacion(item));
                }
                else
                {
                    lstNoVigCalendario.Add(new clsCalendarioAdjudicacion(item));
                }

            }
        }

        private void ActualizarDatosListaCalendario()
        {
            for (int i = 0; i < this.dtgEtapaProceso.Rows.Count; i++)
            {
                int idcalendario = Convert.ToInt32(this.dtgEtapaProceso.Rows[i].Cells["idEtapaCalendario"].Value);
                var validaexiste = lstModCalendario.Where(x => x.idEtapaCalendario == idcalendario).Count();
                if (validaexiste > 0)
                {
                    // nOrdenEtapa = lstModCalendario.Select(x => x.nOrden).ToList().Last();
                    this.dtgEtapaProceso.Rows[i].Cells["dFechaIni"].Value = lstModCalendario.Where(x => x.idEtapaCalendario == idcalendario).Select(x => x.dFechaInicio).First();
                    this.dtgEtapaProceso.Rows[i].Cells["dFechaFin"].Value = lstModCalendario.Where(x => x.idEtapaCalendario == idcalendario).Select(x => x.dFechaFin).First();
                    this.dtgEtapaProceso.Rows[i].Cells["cObservaciones"].Value = lstModCalendario.Where(x => x.idEtapaCalendario == idcalendario).Select(x => x.cObservaciones).First();
                    this.dtgEtapaProceso.Rows[i].Cells["lSelect"].ReadOnly = true;
                    ((DataGridViewCheckBoxCell)dtgEtapaProceso.Rows[i].Cells["lSelect"]).Value = true;
                    this.dtgEtapaProceso.Rows[i].Cells["cEstado"].Value = 1;

                }
            }
        }

        private void FormatoGridEtapaProceso() 
        {
            this.dtgEtapaProceso.Columns["idEtapaCalendario"].Visible = false;
            this.dtgEtapaProceso.Columns["nOrdenEtapa"].Visible = false;
            this.dtgEtapaProceso.Columns["nDiasEtapa"].Visible = false;
            this.dtgEtapaProceso.Columns["cObservaciones"].Visible = false;
            this.dtgEtapaProceso.Columns["dFechaIni"].Visible = false;
            this.dtgEtapaProceso.Columns["dFechaFin"].Visible = false;
            this.dtgEtapaProceso.Columns["cEstado"].Visible = false;

            this.dtgEtapaProceso.Columns["cEtapaCalendario"].HeaderText = "Etapas";
            this.dtgEtapaProceso.Columns["lSelect"].HeaderText = "X";

            this.dtgEtapaProceso.Columns["cEtapaCalendario"].Width = 240;
            this.dtgEtapaProceso.Columns["lSelect"].Width = 30;
            this.dtgEtapaProceso.Columns["cEtapaCalendario"].SortMode = DataGridViewColumnSortMode.NotSortable; 
        }

        private void controlObjetos(int idEstado) 
        {
            switch (idEstado) { 
                case 1: // nuevo
                case 2: // editar
                    txtObservacion.Enabled = true;
                    btnAgregar1.Enabled = true;
                    btnQuitar2.Enabled = true;
                    dtpFechaIni.Enabled = true;
                    dtpdFechaFin.Enabled = true;
                    chcUtilizaPlantilla.Enabled = true;
                    dtgCalendario.Enabled = true;
                    break;

                case 3: // guardado
                    txtObservacion.Enabled = false;
                    btnAgregar1.Enabled = false;
                    btnQuitar2.Enabled = false;
                    dtpFechaIni.Enabled = false;
                    dtpdFechaFin.Enabled = false;
                    chcUtilizaPlantilla.Enabled = false;
                    dtgCalendario.Enabled = false;
                    break;
            }
        }
        #endregion

    }
}
