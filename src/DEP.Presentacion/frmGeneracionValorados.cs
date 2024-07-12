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
using GEN.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio;
using CAJ.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmGeneracionValorados : frmBase
    {
        #region Variables Globales
        clsCNValorados objValorados = new clsCNValorados();
        int idValorado=0;
        int idEstadoVal =0;
        string cTipoBus = "N";
        DataTable dtValorados;
        DataTable dtDetValgen;

        #endregion
        #region Eventos
        public frmGeneracionValorados()
        {
            InitializeComponent();
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
        }

        private void frmGeneracionValorados_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
         
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!this.ValidRegValorado())
            {
                return;
            }
            int idTipoValorado = (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda= (int)this.cboMoneda1.SelectedValue;
            int idAgencia=(int)this.cboAgencia.SelectedValue;
            int nNumserie=Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim());
            int nNumInicio = Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim()); 
            int nNumFin=Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim());
            int idUsuOrigen=clsVarGlobal.User.idUsuario;
            int idUsuDestino = (int)this.cboColaborador.SelectedValue; 
            DateTime dFechaEntrega=clsVarGlobal.dFecSystem;
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            string cMotivo = this.txtMotivo.Text.ToString();

            DataTable dtResp = objValorados.CNGuardarIngresoValorado( idTipoValorado,idTipoMoneda,idAgencia,idValorado,
                                                   nNumserie,nNumInicio,nNumFin,idUsuOrigen,idUsuDestino,
                                                   dFechaEntrega, idEstadoVal, idUsuMod, dFechaMod, cMotivo);

            if ((int)dtResp.Rows[0]["Resultado"] > 0)
            {
                MessageBox.Show("Los Cambios se Guardaron Correctamente", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.btnEditar.Visible = false;
               // this.btnAnular.Visible = false;
                this.btnEditar.Enabled = false;
                this.btnAnular.Enabled = false;
                this.HabilitarControles(false);
                this.cboAgencia.Enabled = true;
                this.cboTipoValorado1.Enabled = true;
                this.cboMoneda1.Enabled=true;
                this.chcBase1.Enabled = true;
                this.txtMotivo.Enabled = false;

                this.chcAnulados.Visible = false;
                this.chcAnulados.Enabled = false;
                this.chcAsignados.Visible = false;
                this.chcAsignados.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnProcesar.Enabled = true;
                this.LimpiarControles();
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.dtpFechaInicio.Enabled = true;
                this.dtpFechaFin.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error el Guardar los Datos", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListaColaborador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idValorado = 0;
            idEstadoVal = 1;
            this.HabilitarControles(true);
            this.LimpiarControles();
            this.cboTipoValorado1.Enabled = true;
            this.cboTipoValorado1.Enabled = true;
            this.cboAgencia.Enabled = true;
            this.cboMoneda1.Enabled = true;
            this.cboAgencia.SelectedIndex = 1;
            this.txtNumSerie.BackColor = Color.White;
            this.txtNumInicio.BackColor = Color.White;
            this.txtNumFinal.BackColor = Color.White;

            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnProcesar.Enabled = false;
            this.chcBase1.Enabled = false;
           // this.btnAnular.Visible = false;
            this.btnAnular.Enabled = false;
            //this.btnEditar.Visible= false;
            this.btnEditar.Enabled = false;
            this.chcAnulados.Visible = false;
            this.chcAnulados.Enabled = false;
            this.chcAsignados.Visible = false;
            this.chcAsignados.Enabled = false;

            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;

            this.dtpFechaFin.Enabled = false;
            this.dtpFechaInicio.Enabled = false;

            this.txtNumSerie.Focus();
            this.txtNumSerie.SelectAll();

        }
        private void btnAnular1_Click(object sender, EventArgs e)
        {
           
            this.dtgValorados.Focus();
            this.HabilitarControles(false);
       
            this.cboAgencia.Enabled = false;
            this.btnGrabar.Enabled = true;
            if (idEstadoVal == 3)
            {
                MessageBox.Show("Operacion Inválida: Verifique Estado de Asignación", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar.Enabled = false;
                return;
            }
            else
            {
                    DataTable dtValidaGen = objValorados.CNValidaModifiValorado((Int32)cboTipoValorado1.SelectedValue, Convert.ToInt32(this.txtNumSerie.Text.Trim()), clsVarGlobal.nIdAgencia, Convert.ToInt32(this.txtNumInicio.Text.Trim()), 2);
                    if (dtValidaGen.Rows.Count > 0)
                    {
                        MessageBox.Show("Uno o Más valorados han Sido Generados. Verifique...", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    else
                    {
                        var Msg = MessageBox.Show("Está Seguro que desea Anular Asignación de Valorados?...", "Asignación de Valorado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Msg == DialogResult.No)
                        {
                            this.btnGrabar.Enabled = false;
                            this.txtMotivo.Enabled = false;
                            this.txtMotivo.Clear();
                            return;
                        }
                        else
                        {
                            idEstadoVal = 3;
                            this.txtMotivo.Enabled = true;
                            this.btnEditar.Enabled = false;
                            this.txtMotivo.Focus();
                            this.btnGrabar.Enabled = true;
                        }
                    }
            }
        }
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicio No Puede ser Mayor que la Fecha del Sistema", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                this.dtpFechaInicio.Focus();
                this.dtpFechaInicio.Select();
                return;
            }

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Final No Puede ser Mayor que la Fecha del Sistema", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
                this.dtpFechaFin.Focus();
                this.dtpFechaFin.Select();
                return;
            }

        }

        private void dtpFechaInicio_Validating(object sender, CancelEventArgs e)
        {
            if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
            {
                MessageBox.Show("La Fecha Inicio No Puede ser Mayor que la Fecha del Final", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                this.dtpFechaInicio.Focus();
                this.dtpFechaInicio.Select();
                return;
            }
        }

        private void txtNumSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaFin_Validating(object sender, CancelEventArgs e)
        {
            if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
            {
                MessageBox.Show("La Fecha Final No Puede ser Menor que la Fecha del Inicio", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
                this.dtpFechaFin.Focus();
                this.dtpFechaFin.Select();
                return;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.chcAnulados.Checked = false;
            this.chcAsignados.Checked = false;
            this.BuscarValoradosEntregados();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
           
            if (idEstadoVal==3)
            {
                MessageBox.Show("No se puede Editar Registros en Estado Anulado", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {                
                dtDetValgen = objValorados.CNListaDetValgen(idValorado, Convert.ToInt32(this.txtNumSerie.Text.Trim()), Convert.ToInt32(this.txtNumInicio.Text.Trim()), Convert.ToInt32(this.txtNumFinal.Text.Trim()));
                if (dtDetValgen.Rows.Count > 0)
                {
                    MessageBox.Show("Uno o Más valorados han Sido Utilizados. Verifique...", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNumFinal.Enabled = false;
                    this.txtNumInicio.Enabled = false;
                    this.cboColaborador.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    return;
                }
                else
                {
                    DataTable dtValidaIng = objValorados.CNValidaModifiValorado((Int32)cboTipoValorado1.SelectedValue, Convert.ToInt32(this.txtNumSerie.Text.Trim()), clsVarGlobal.nIdAgencia, Convert.ToInt32(this.txtNumInicio.Text.Trim()), 1);
                    if (dtValidaIng.Rows.Count > 1)
                    {
                        DataTable dtValidaGen = objValorados.CNValidaModifiValorado((Int32)cboTipoValorado1.SelectedValue, Convert.ToInt32(this.txtNumSerie.Text.Trim()), clsVarGlobal.nIdAgencia, Convert.ToInt32(this.txtNumInicio.Text.Trim()), 2);
                        if (dtValidaGen.Rows.Count>0)
                        {
                            MessageBox.Show("Uno o Más valorados han Sido Generados. Verifique...", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNumFinal.Enabled = false;
                            this.txtNumInicio.Enabled = false;
                            this.cboColaborador.Enabled = false;
                            this.btnGrabar.Enabled = false;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Existen Valorados Asignados despues del Bloque Seleccionado", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtNumInicio.Enabled = false;
                            this.txtNumFinal.Enabled = false;
                            this.cboAgencia.Enabled = true;
                        }
                        
                       
                    }
                    else
                    {
                        this.HabilitarControles(true);
                        this.txtNumSerie.Enabled = false;
                        this.cboAgencia.Enabled = true;
                        this.btnAnular.Enabled = true;
                        this.btnGrabar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                        this.chcAnulados.Visible = false;
                        this.chcAnulados.Enabled = false;
                        this.chcAsignados.Visible = false;
                        this.chcAsignados.Enabled = false;
                        // this.txtNumSerie.BackColor = Color.White;
                        this.txtNumInicio.BackColor = Color.White;
                        this.txtNumFinal.BackColor = Color.White;
                    }

                }

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idValorado=0;
            idEstadoVal =0;
            cTipoBus = "N";
            this.LimpiarControles();
            this.cboAgencia.Enabled = true;
            this.cboTipoValorado1.Enabled = true;
            this.cboMoneda1.Enabled = true;
            this.dtpFechaInicio.Enabled = true;
            this.dtpFechaFin.Enabled = true;
            this.chcBase1.Enabled = true;
            this.chcAnulados.Visible = false;
            this.chcAnulados.Enabled = false;
            this.chcAsignados.Visible = false;
            this.chcAsignados.Enabled = false;

            this.btnAnular.Enabled = false;
            this.btnEditar.Enabled = false;
          //  this.btnEditar.Visible = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnProcesar.Enabled = true;
            this.btnNuevo.Enabled = true;

            this.txtNumSerie.BackColor =  Color.FromName("Control");
            this.txtNumInicio.BackColor = Color.FromName("Control");
            this.txtNumFinal.BackColor = Color.FromName("Control");

            this.txtNumSerie.Enabled=false;
            this.txtNumInicio.Enabled = false;
            this.txtNumFinal.Enabled = false;
            this.cboColaborador.Enabled = false;

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validando Insercion
            if (!ValidRegValorado())
            {
                return;
            }
            DataRow dr = dtValorados.NewRow();
            dr["idValorado"]=0;
            dr["idTipoValorado"]=this.cboTipoValorado1.SelectedValue;
            dr["nSerie"]=this.txtNumSerie.Text.Trim();
            dr["nInicio"]=this.txtNumInicio.Text.Trim();
            dr["nFin"]=this.txtNumFinal.Text.Trim();
            dr["idMoneda"]=this.cboMoneda1.SelectedValue;
            dr["idAgencia"]=this.cboAgencia.SelectedValue;
            dr["cNombreAge"]=this.cboAgencia.Text.Trim();;
            dr["idUsuOrigen"]=clsVarGlobal.User.idUsuario;
            dr["cWinUser"]="";
            dr["idusuDestino"]=this.cboColaborador.SelectedValue;
            dr["cWinUser"]="";
            dr["idEstadoVal"]=idEstadoVal;
            dr["cEstadoVal"]="";
            dtValorados.Rows.Add(dr);
            

        }
        private void txtNumFinal_Validating(object sender, CancelEventArgs e)
        {
            string cValor = this.txtNumFinal.Text.ToString().Trim();
            this.txtNumFinal.Text = cValor.PadLeft(7, '0');

            if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) < Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim()))
            {
                MessageBox.Show("EL Número de Serie Final no puede ser Menor que el que Inicia la Serie", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumFinal.Focus();
                this.txtNumFinal.SelectAll();
                return;
            }
        }

        private void dtgValorados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgValorados.IsCurrentCellDirty)
            {
                dtgValorados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked==true)
            {
                cTipoBus = "T";
                this.cboTipoValorado1.Enabled = false;
                this.cboAgencia.Enabled = false;
                this.cboMoneda1.Enabled = false;
            }
            else
            {
                this.cboTipoValorado1.Enabled = true;
                this.cboAgencia.Enabled = true;
                this.cboMoneda1.Enabled = true;
            }

        }


        private void chcAsignados_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcAsignados.Checked == true)
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'3'");
                dtgValorados.DataSource = dtValorados.DefaultView;
                this.chcAnulados.Checked = false;
            }
            else if (this.chcAnulados.Checked == true)
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'1'");
                dtgValorados.DataSource = dtValorados.DefaultView;
                this.chcAsignados.Checked = false;
            }
            else
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'0'");
                dtgValorados.DataSource = dtValorados.DefaultView;
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcAnulados.Checked == true)
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'1'");
                dtgValorados.DataSource = dtValorados.DefaultView;
                this.chcAsignados.Checked = false;
            }
            else if (this.chcAsignados.Checked == true)
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'3'");
                dtgValorados.DataSource = dtValorados.DefaultView;
                this.chcAnulados.Checked = false;
            }
            else
            {
                dtValorados.DefaultView.RowFilter = ("idEstadoVal <>'0'");
                dtgValorados.DataSource = dtValorados.DefaultView;
            }
        }

        private void txtNumSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtNumSerie.Text.ToString().Trim()))
            {
                cValor = "1";
            }
            else
            {
                if (Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim())==0)
                {
                    cValor = "1";
                }
                cValor = this.txtNumSerie.Text.ToString().Trim();
            }
                

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtNumSerie.Text = cValor.PadLeft(7, '0');

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtNumSerie.Text = cValor.PadLeft(7, '0');
            }
        }

        private void txtNumSerie_Validating(object sender, CancelEventArgs e)
        {
            string cValor = this.txtNumSerie.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(cValor))
            {
                if (Convert.ToInt32(cValor) == 0)
                {
                    cValor = "1";
                }
            }
            this.txtNumSerie.Text = cValor.PadLeft(7, '0');
        }

        private void txtNumInicio_Validated(object sender, EventArgs e)
        {
            string cValor = this.txtNumInicio.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(cValor))
            {
                if (Convert.ToInt32(cValor) == 0)
                {
                    cValor = "1";
                }
            }
            this.txtNumInicio.Text = cValor.PadLeft(7, '0');
        }

        private void txtNumInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtNumInicio.Text.ToString().Trim()))
            {
                cValor = "1";
            }
            else
            {
                if (Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim())==0)
                {
                    cValor = "1";
                }
                cValor = this.txtNumInicio.Text.ToString().Trim();
            }
               
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtNumInicio.Text = cValor.PadLeft(7, '0');

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtNumInicio.Text = cValor.PadLeft(7, '0');
            }
        }

        private void txtNumFinal_KeyPress(object sender, KeyPressEventArgs e)
        {

            string cValor;
            if (string.IsNullOrEmpty(this.txtNumFinal.Text.ToString().Trim()))
            {
                cValor = "0";
            }
            else
                cValor = this.txtNumFinal.Text.ToString().Trim();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtNumFinal.Text = cValor.PadLeft(7, '0');

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtNumFinal.Text = cValor.PadLeft(7, '0');
            }
        }

        private void dtgValorados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int fila = e.RowIndex;
            if (dtgValorados.Rows.Count > 0)
            {
                idValorado = (int)dtgValorados.Rows[fila].Cells["idValorado"].Value;
                idEstadoVal = (int)dtgValorados.Rows[fila].Cells["idEstadoVal"].Value;
                this.cboTipoValorado1.SelectedValue = dtgValorados.Rows[fila].Cells["idTipoValorado"].Value.ToString();
                this.cboMoneda1.SelectedValue = dtgValorados.Rows[fila].Cells["idMoneda"].Value.ToString();
                this.cboAgencia.SelectedValue = dtgValorados.Rows[fila].Cells["idAgencia"].Value.ToString();
                this.cboColaborador.SelectedValue = dtgValorados.Rows[fila].Cells["idusuDestino"].Value.ToString();
                this.txtNumSerie.Text = dtgValorados.Rows[fila].Cells["nSerie"].Value.ToString();
                this.txtNumInicio.Text = dtgValorados.Rows[fila].Cells["nInicio"].Value.ToString();
                this.txtNumFinal.Text = dtgValorados.Rows[fila].Cells["nFin"].Value.ToString();
                this.txtMotivo.Text = dtgValorados.Rows[fila].Cells["cMotivo"].Value.ToString();

                this.txtNumSerie.Enabled = false;
                this.txtNumInicio.Enabled = false;
                this.txtNumFinal.Enabled = false;
                this.cboAgencia.Enabled = false;
                this.cboTipoValorado1.Enabled = false;
                this.cboAgencia.Enabled = false;
                this.cboColaborador.Enabled = false;
                this.cboMoneda1.Enabled = false;
                this.btnGrabar.Enabled = false;

                this.chcAnulados.Visible = true;
               // this.chcAnulados.Checked = false;
                this.chcAnulados.Enabled = true;
                this.chcAsignados.Enabled = true;
                //this.chcAsignados.Checked = false;
                this.chcAsignados.Visible = true;
        
            }
        }

        #endregion
        #region Metodos
        public void ListaColaborador()
        {

            if ((int)cboAgencia.SelectedValue>0)
            {
                int idAgencia = (int)cboAgencia.SelectedValue;
                clsCNControlOpe Listapersonal = new clsCNControlOpe();
                DataTable dt = Listapersonal.ListarResBovAge(idAgencia,clsVarGlobal.dFecSystem);
                this.cboColaborador.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    
                    this.cboColaborador.ValueMember = dt.Columns["idUsuario"].ToString();
                    this.cboColaborador.DisplayMember = dt.Columns["cNombre"].ToString();
                }
                else
                {
                    MessageBox.Show("No Existe Responsable de Agencia Seleccionada. Verifique", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                } 
            } 
                
        
        }
        public void LimpiarControles()
        {
            this.cboTipoValorado1.SelectedIndex = 0;
            this.cboMoneda1.SelectedIndex = 0;
            this.cboAgencia.SelectedIndex = 0;
            this.txtNumSerie.Text="00000001";
            this.txtNumInicio.Text = "0000001";
            this.txtNumFinal.Text="0000001";
            this.dtgValorados.DataSource = "";
            this.txtMotivo.Clear();
            //this.chcAnulados.Checked = false;
            //this.chcAsignados.Checked = false;
            this.chcBase1.Checked = false;
        }
        public void HabilitarControles(Boolean val)
        {
            this.txtNumSerie.Enabled = val;
            this.txtNumInicio.Enabled = val;
            this.txtNumFinal.Enabled = val;

            this.dtpFechaFin.Enabled = !val;
            this.dtpFechaInicio.Enabled = !val;
            this.cboColaborador.Enabled = val;
        }
        public void BuscarValoradosEntregados()
        {
            int idAgencia=(int)this.cboAgencia.SelectedValue;
            int idtipoValorado= (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            if (idAgencia == 0 && this.chcBase1.Checked == false)
            {
                cTipoBus = "A";
            }
            dtValorados = objValorados.CNListaValorados(cTipoBus,idtipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFin);
            if (dtValorados.Rows.Count>0)
            {
                this.dtgValorados.DataSource = dtValorados;
                this.FormatoGrid();
                this.SortGrid();
                this.cboAgencia.Enabled = false;
                this.cboColaborador.Enabled = false;
                this.cboMoneda1.Enabled = false;
                this.cboTipoValorado1.Enabled = false;
                this.dtpFechaInicio.Enabled = false;
                this.dtpFechaFin.Enabled = false;
                this.chcBase1.Enabled = false;
               // this.btnEditar.Visible = true;
                this.btnEditar.Enabled = true;
                this.btnProcesar.Enabled = false;
              //  this.btnAnular.Visible = true;
                this.btnAnular.Enabled = true;

                this.chcAsignados.Enabled = true;
                this.chcAnulados.Enabled = true;
                this.chcAsignados.Visible = true;
                this.chcAnulados.Visible = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se Encontraron Datos", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencia.Enabled = true;
               // this.cboColaborador.Enabled = true;
                this.cboMoneda1.Enabled = true;
                this.cboTipoValorado1.Enabled = true;
                this.chcBase1.Checked = false;

                this.btnEditar.Enabled = false;
                this.btnAnular.Enabled = false;
                this.btnCancelar.Enabled = false;

                this.chcAsignados.Enabled = false;
                this.chcAnulados.Enabled = false;
            }
         
        }
        public void FormatoGrid()
        {

            this.dtgValorados.Columns["idValorado"].Visible = false;
            this.dtgValorados.Columns["idTipoValorado"].Visible = false;
            this.dtgValorados.Columns["idMoneda"].Visible = false;
            this.dtgValorados.Columns["idAgencia"].Visible = false;
            this.dtgValorados.Columns["idUsuOrigen"].Visible = false;
            this.dtgValorados.Columns["idusuDestino"].Visible = false;
            this.dtgValorados.Columns["idEstadoVal"].Visible = false;
            this.dtgValorados.Columns["cNombreAge"].Visible = false;
            this.dtgValorados.Columns["cValorado"].Visible = false;
            this.dtgValorados.Columns["cMotivo"].Visible = false;

            this.dtgValorados.Columns["Row"].HeaderText = "Nro";
            this.dtgValorados.Columns["nSerie"].HeaderText = "Serie";
            this.dtgValorados.Columns["nInicio"].HeaderText = "Ini.Serie";
            this.dtgValorados.Columns["nFin"].HeaderText = "Fin.Serie";
            this.dtgValorados.Columns["cNomCorto"].HeaderText = "Age";
            this.dtgValorados.Columns["cUserOrigen"].HeaderText = "Usu.Origen";
            this.dtgValorados.Columns["cUserDestino"].HeaderText = "Usu.Desti";
            this.dtgValorados.Columns["cEstadoVal"].HeaderText = "Estado";
            this.dtgValorados.Columns["dFechaEntrega"].HeaderText = "Fech.Entrega";

            this.dtgValorados.Columns["Row"].Width =25 ;
            this.dtgValorados.Columns["nSerie"].Width =80;
            this.dtgValorados.Columns["nInicio"].Width =80;
            this.dtgValorados.Columns["nFin"].Width = 80;
            this.dtgValorados.Columns["cNomCorto"].Width = 50;
            this.dtgValorados.Columns["cUserOrigen"].Width = 80;
            this.dtgValorados.Columns["cUserDestino"].Width =80;
            this.dtgValorados.Columns["cEstadoVal"].Width = 100;
            this.dtgValorados.Columns["dFechaEntrega"].Width = 80;
        }
        public Boolean ValidRegValorado()
        {
            if (idEstadoVal==1)
            {
                int idTipoValorado = (int)this.cboTipoValorado1.SelectedValue;
                int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
                int idAgencia = (int)this.cboAgencia.SelectedValue;
                int nNumserie = Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim());
                int nNumInicio = Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim());
                int nNumFin = Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim());
                //Validando que no se duplique la Serie asignadas a las agencias
                DataTable dtValidaAsig = objValorados.CNValidaAsigValorado(idValorado, idTipoValorado, idTipoMoneda, idAgencia, nNumserie, nNumInicio, nNumFin);
             
                if (dtValidaAsig.Rows.Count > 0)
                { 
                        string cValor = dtValidaAsig.Rows[0]["nSerie"] + " de " + dtValidaAsig.Rows[0]["nInicio"] + " a " + dtValidaAsig.Rows[0]["nFin"];
                        MessageBox.Show("Existe el Siguiente Registro, Serie : " + cValor + " para la agencia " + dtValidaAsig.Rows[0]["cNombreAge"], "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtNumSerie.Focus();
                        this.txtNumSerie.SelectAll();
                        return false;
                }
            }
        

            if ((int)this.cboAgencia.SelectedValue == 0)
            {
                MessageBox.Show("Seleccione una Agencia", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.Text.Trim()))
            {
                MessageBox.Show("Seleccione una Usuario Responsable", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNumSerie.Text))
            {
                MessageBox.Show("Registre el Número de Serie del Valorado", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumSerie.Focus();
                this.txtNumSerie.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNumInicio.Text))
            {
                MessageBox.Show("Registre el Número de Inicio de Serie del Valorado", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumInicio.Focus();
                this.txtNumInicio.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNumFinal.Text))
            {
                MessageBox.Show("Registre el Número Final de Serie del Valorado", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumFinal.Focus();
                this.txtNumFinal.SelectAll();
                return false;
            }
            if (Convert.ToInt64(this.txtNumInicio.Text.Trim())>=Convert.ToInt64(this.txtNumFinal.Text.Trim()))
            {
                MessageBox.Show("Registro No Válido para el Número Final de Serie", "Asignación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumFinal.Focus();
                this.txtNumFinal.SelectAll();
                return false;
            }

            return true;
        }
        private void SortGrid()
        {
            dtgValorados.Columns["Row"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idTipoValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["nSerie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["nInicio"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["nFin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idMoneda"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idAgencia"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["cNomCorto"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idUsuOrigen"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["cUserOrigen"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idusuDestino"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["cUserDestino"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["idEstadoVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["cEstadoVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgValorados.Columns["dFechaEntrega"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        #endregion


       



    }
}
