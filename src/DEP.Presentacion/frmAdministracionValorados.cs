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
using DEP.CapaNegocio;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmAdministracionValorados : frmBase
    {
        #region Variables Globales
        clsCNValorados objValorados = new clsCNValorados();
        int nFinSerie = 0;
        int nOrder = 0;
        string cTipoBus = "N";
        int idValorado = 0;
        int idEstadoVal = 0;
        DataTable dtValorados;
        DataTable dtDetValgen;
        DataTable dtDetGenerados;
        #endregion
        #region Eventos
        public frmAdministracionValorados()
        {
            InitializeComponent();
        }

        private void frmAdministracionValorados_Load(object sender, EventArgs e)
        {
            this.ListaColaborador();
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validando Inserción:
            if (string.IsNullOrEmpty(this.txtNumFinal.Text.Trim()))
            {
                MessageBox.Show("Registre el Número Final de Serie del Valorado", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNumFinal.Focus();
                this.txtNumFinal.SelectAll();
                return ;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.Text.Trim()))
            {
                 MessageBox.Show("Seleccione una Usuario Responsable", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 this.cboColaborador.Focus();
                 return ;
            }

            if (nOrder>1)
            {
                MessageBox.Show("Existe un Lote Anterior Pendiente de Asignacion", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnBusqueda1.Focus();
                return;
            }
            int nNumserie = Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim());
            int nNumInicio = Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim());
            int nNumFin = Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim());
            int idUsuOrigen = clsVarGlobal.User.idUsuario;
            int idUsuDestino = (int)this.cboColaborador.SelectedValue;
            DateTime dFechaEntrega = clsVarGlobal.dFecSystem;
            DataTable dtResp = objValorados.CNGuardarGeneracionValorado( idValorado,nNumserie, nNumInicio, nNumFin, 
                                                                         idUsuOrigen, idUsuDestino,dFechaEntrega, idEstadoVal);
            if ((int)dtResp.Rows[0]["Resultado"] > 0)
            {
                MessageBox.Show("Los Cambios se Guardaron Correctamente", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.HabilitarControles(false);
                this.LimpiarControles();
                this.txtNumFinal.Enabled = false;
                this.btnEditar.Enabled = false; 
                this.btnGrabar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error el Guardar los Datos", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar.Enabled = false;
                this.btnEditar.Enabled = false;
                return;
            }
                
        }
        private void dtpFechaFin_Validating(object sender, CancelEventArgs e)
        {
            //if (this.dtpFechaFin.Value > clsVarGlobal.dFecSystem)
            //{
            //    MessageBox.Show("La Fecha Final No Puede ser Mayor que la Fecha del Sistema", "Generacion de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.dtpFechaFin.Focus();
            //    return;
            //}
        }
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.HabilitarControles(true);
            this.cboColaborador.Enabled = false;
            this.btnEliminar1.Enabled = false;
            this.txtNumFinal.Enabled = false;
            this.btnGrabar.Enabled = false;
            frmListaValoradosAsignados frmValoradosAsig = new frmListaValoradosAsignados();
            frmValoradosAsig.nEstadoVal = 1;
            frmValoradosAsig.ShowDialog();
            if (frmValoradosAsig.nFin - frmValoradosAsig.nInicio <= 0)
            {
                this.LimpiarControles();
                this.HabilitarControles(false);
                this.txtNumFinal.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                return;
            }
            else
	        {
                idValorado = frmValoradosAsig.idValorado;
                idEstadoVal = 2;
                nFinSerie = frmValoradosAsig.nFin;
                nOrder = frmValoradosAsig.nOrden;
                this.txtNumSerie.Text = frmValoradosAsig.nSerie.ToString().PadLeft(7, '0');
                this.txtNumInicio.Text = frmValoradosAsig.nInicio.ToString().PadLeft(7, '0');
                this.txtNumFinal.Text = frmValoradosAsig.nFin.ToString().PadLeft(7, '0');
                this.cboTipoValorado1.SelectedValue = frmValoradosAsig.idTipoValorado;
                this.cboMoneda1.SelectedValue = frmValoradosAsig.idMoneda;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = true;
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

        private void dtpFechaInicio_Validating(object sender, CancelEventArgs e)
        {

            //if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
            //{
            //    MessageBox.Show("La Fecha Inicio No Puede ser Mayor que la Fecha del Final", "Generacion de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.dtpFechaInicio.Focus();
            //    return;
            //}
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dtgValEntregados.Rows.Count>0)
            {
               if (dtDetValgen.Rows.Count > 0)
               {
                   MessageBox.Show("Uno o Más valorados estan siendo Utilizados. Verifique...", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
               }
              else
	          {
                  DataTable dtValidaGen = objValorados.CNValidaModifiValorado((Int32)cboTipoValorado1.SelectedValue, Convert.ToInt32(this.txtNumSerie.Text.Trim()), clsVarGlobal.nIdAgencia, Convert.ToInt32(this.txtNumInicio.Text.Trim()), 2);
                  if (dtValidaGen.Rows.Count > 1)
                {
                    MessageBox.Show("Existen Valorados Generados despues del Bloque Seleccionado", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNumFinal.Enabled = false;
                    this.btnEliminar1.Enabled = true;
                    return;
                }
                else
	            {
                    this.HabilitarControles(true);
                    this.btnEditar.Enabled = false;
                    this.btnGrabar.Enabled = true;
                    this.txtNumFinal.Enabled = true;
                    //this.btnEliminar1.Enabled = false;
                    this.txtNumFinal.Focus();
                    this.txtNumFinal.BackColor = Color.White;   
	            }
	          }
 
            }
            else
            {
                this.HabilitarControles(true);
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.txtNumFinal.Enabled = true;
                //this.btnEliminar1.Enabled = false;
                this.txtNumFinal.Focus();
                this.txtNumFinal.BackColor = Color.White;
            }
        }
        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBase1.Checked == true)
            {
                cTipoBus = "T";
                this.cboTipoValorado1.Enabled = false;
                this.cboMoneda1.Enabled = false;
            }
            else
            {
                this.cboTipoValorado1.Enabled = true;
                this.cboMoneda1.Enabled = true;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            this.ListaValoradosEntregados();
        }

        private void txtNumFinal_Validating(object sender, CancelEventArgs e)
        {
            string cValor = this.txtNumFinal.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(cValor))
            {
                if (Convert.ToInt32(cValor) == 0)
                {
                    cValor = "1";
                } 
            }
            this.txtNumFinal.Text = cValor.PadLeft(7, '0');
            if (this.dtgValEntregados.Rows.Count>0)
            {
                nFinSerie = Convert.ToInt32(dtgValEntregados.Rows[dtgValEntregados.SelectedCells[0].RowIndex].Cells["nFinBloque"].Value);
                if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) > nFinSerie)
                {
                    MessageBox.Show("El Valor Ingresado Supera el Limite Final del Bloque a Asignar", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNumFinal.Focus();
                    this.txtNumFinal.SelectAll();
                    return;
                }
            }
            
            else
            {
                if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) < Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim()))
                {
                    MessageBox.Show("EL Número de Serie Final no puede ser Menor que el que Inicia la Serie", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNumFinal.Focus();
                    this.txtNumFinal.SelectAll();
                    return;
                }
                if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim()) > nFinSerie)
                {
                    MessageBox.Show("El Valor Ingresado Supera el Limite Final del Bloque a Asignar", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNumFinal.Focus();
                    this.txtNumFinal.SelectAll();
                    return;
                }
            }

           
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.LimpiarControles();
            this.HabilitarControles(false);
            this.txtNumFinal.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnEliminar1.Enabled = false;
            this.btnEditar.Enabled = false;

        }
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
               
            

        }
        private void txtNumFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtNumFinal.Text.ToString().Trim()))
            {
                cValor = "1";
            }
            else
            {
                if (Convert.ToInt32(this.txtNumFinal.Text.ToString().Trim())==0)
                {
                    cValor = "1";
                }
                cValor = this.txtNumFinal.Text.ToString().Trim();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtNumFinal.Text = cValor.PadLeft(7, '0');

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtNumFinal.Text = cValor.PadLeft(7, '0');
            }
        }
        private void dtgValEntregados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgValEntregados.IsCurrentCellDirty)
            {
                dtgValEntregados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgValEntregados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nfila = e.RowIndex;
            if (dtgValEntregados.Rows.Count > 0)
            {
                idValorado = (int)dtgValEntregados.Rows[nfila].Cells["idValorado"].Value;
                this.cboTipoValorado1.SelectedValue = dtgValEntregados.Rows[nfila].Cells["idTipoValorado"].Value.ToString();
                this.cboMoneda1.SelectedValue = dtgValEntregados.Rows[nfila].Cells["idMoneda"].Value.ToString();
                this.cboColaborador.SelectedValue = dtgValEntregados.Rows[nfila].Cells["idusuDestino"].Value.ToString();
                this.txtNumSerie.Text = dtgValEntregados.Rows[nfila].Cells["nSerie"].Value.ToString();
                this.txtNumInicio.Text = dtgValEntregados.Rows[nfila].Cells["nInicio"].Value.ToString();
                this.txtNumFinal.Text = dtgValEntregados.Rows[nfila].Cells["nFin"].Value.ToString();
                nFinSerie = Convert.ToInt32(dtgValEntregados.Rows[nfila].Cells["nFin"].Value);
                //Retornando el Detalle del Bloque de Valorados
                dtDetValgen = objValorados.CNListaDetValgen(idValorado, Convert.ToInt32(this.txtNumSerie.Text.Trim()), Convert.ToInt32(this.txtNumInicio.Text.Trim()), Convert.ToInt32(this.txtNumFinal.Text.Trim()));
                this.dtgDetValorados.DataSource = dtDetValgen;
                if (dtDetValgen.Rows.Count>0)
                {
                    this.FomartoGridDet();
                    this.SortGridDetValEntregados();
                }
                
                this.txtNumSerie.Enabled = false;
                this.txtNumInicio.Enabled = false;
                this.txtNumFinal.Enabled = false;
                this.cboTipoValorado1.Enabled = false;
                this.cboColaborador.Enabled = false;
                this.cboMoneda1.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnEliminar1.Enabled = true;
            }
        }
        #endregion
        #region Metodos
        public void ListaValoradosEntregados()
        {
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idtipoValorado = (int)this.cboTipoValorado1.SelectedValue;
            int idTipoMoneda = (int)this.cboMoneda1.SelectedValue;
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;
            dtValorados = objValorados.CNListaValoradosEntregados(cTipoBus, idtipoValorado, idTipoMoneda, idAgencia, dFechaInicio, dFechaFin);
            if (dtValorados.Rows.Count > 0)
            {
                this.dtgValEntregados.DataSource = dtValorados;
                this.FormatoGrid();
                this.SortGridValEntregados();
                this.HabilitarControles(true);
                this.cboColaborador.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnEliminar1.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se Encontraron Datos", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.HabilitarControles(false);
                this.btnEditar.Enabled = false;
            }
        }
        public void FormatoGrid()
        {
            this.dtgValEntregados.Columns["idValorado"].Visible = false;
            this.dtgValEntregados.Columns["idTipoValorado"].Visible = false;
            this.dtgValEntregados.Columns["idMoneda"].Visible = false;
            this.dtgValEntregados.Columns["idUsuOrigen"].Visible = false;
            this.dtgValEntregados.Columns["idusuDestino"].Visible = false;
            this.dtgValEntregados.Columns["nFinBloque"].Visible = false;
            this.dtgValEntregados.Columns["cValorado"].Visible = false;
            this.dtgValEntregados.Columns["cEstadoVal"].Visible = false;
            this.dtgValEntregados.Columns["cNomCorto"].Visible = false;
            this.dtgValEntregados.Columns["cNombreAge"].Visible = false;

            this.dtgValEntregados.Columns["Row"].HeaderText = "Nro";
            this.dtgValEntregados.Columns["nSerie"].HeaderText = "Serie";
            this.dtgValEntregados.Columns["nInicio"].HeaderText = "Ini.Serie";
            this.dtgValEntregados.Columns["nFin"].HeaderText = "Fin.Serie";
      
            this.dtgValEntregados.Columns["cUserOrigen"].HeaderText = "Usu.Origen";
            this.dtgValEntregados.Columns["cUserDestino"].HeaderText = "Usu.Desti";
            this.dtgValEntregados.Columns["dFechaEntrega"].HeaderText = "Fech.Entrega";

            this.dtgValEntregados.Columns["Row"].Width = 25;
            this.dtgValEntregados.Columns["nSerie"].Width = 80;
            this.dtgValEntregados.Columns["nInicio"].Width = 80;
            this.dtgValEntregados.Columns["nFin"].Width = 80;
            this.dtgValEntregados.Columns["cUserOrigen"].Width = 80;
            this.dtgValEntregados.Columns["cUserDestino"].Width = 80;
            this.dtgValEntregados.Columns["dFechaEntrega"].Width = 80;
        }
        public void ListaColaborador()
        {
            clsCNPersonal Listapersonal = new clsCNPersonal();
            DataTable dt = Listapersonal.ListaPersonal(clsVarGlobal.nIdAgencia);
            this.cboColaborador.DataSource = dt;
            this.cboColaborador.ValueMember = dt.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = dt.Columns["cNombre"].ToString();
        }
        public void LimpiarControles()
        {
            this.txtNumSerie.Text = "0000001";
            this.txtNumInicio.Text = "0000001";
            this.txtNumFinal.Text = "0000001";
            this.cboColaborador.SelectedIndex = 0;
            this.dtgValEntregados.DataSource = "";
            this.dtgDetValorados.DataSource = "";
            this.dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            this.cboTipoValorado1.SelectedIndex = 0;
            this.chcBase1.Checked = false;
            this.cboMoneda1.SelectedIndex = 0;
        }
        private void HabilitarControles(Boolean val)
        {
        //    this.txtNumFinal.Enabled = val;
            this.cboColaborador.Enabled = val;
          //  this.btnGrabar.Enabled = val;
            this.btnCancelar.Enabled = val;
           // this.btnEliminar1.Enabled = val;

            this.cboMoneda1.Enabled = !val;
            this.cboTipoValorado1.Enabled = !val;
            this.dtpFechaInicio.Enabled = !val;
            this.dtpFechaFin.Enabled = !val;
            this.btnProcesar.Enabled = !val;
            this.chcBase1.Enabled = !val;
        }
        public void FomartoGridDet()
        {
            dtgDetValorados.Columns["idCuenta"].HeaderText="Cuenta";
            dtgDetValorados.Columns["nserie"].HeaderText="Serie";
            dtgDetValorados.Columns["ninicio"].HeaderText = "Ini.Serie";
            dtgDetValorados.Columns["nfin"].HeaderText = "Fin.Serie";
            dtgDetValorados.Columns["nNumVal"].HeaderText="Nro.Val";
            dtgDetValorados.Columns["idkardex"].HeaderText="Nro.Kadex";
            dtgDetValorados.Columns["dFechaOpe"].HeaderText="Fecha.Ope";
            dtgDetValorados.Columns["cEstadoVincu"].HeaderText="Estado";

        }
        private void SortGridValEntregados()
        {
            this.dtgValEntregados.Columns["Row"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["idValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["idTipoValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["nSerie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["nInicio"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["nFin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["idMoneda"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["idUsuOrigen"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["cUserOrigen"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["idusuDestino"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["cUserDestino"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dtgValEntregados.Columns["dFechaEntrega"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void SortGridDetValEntregados()
        {
            dtgDetValorados.Columns["idCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["nserie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["ninicio"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["nfin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["nNumVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["idkardex"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["dFechaOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetValorados.Columns["cEstadoVincu"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        #endregion

        private void dtpFechaInicio_Validating_1(object sender, CancelEventArgs e)
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

        private void dtpFechaFin_Validating_1(object sender, CancelEventArgs e)
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

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            this.dtgValEntregados.Focus();
            if (this.dtgValEntregados.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Valorados Generados a Eliminar", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtDetValgen.Rows.Count > 0)
                {
                    MessageBox.Show("Eliminación No Válida, Uno o Más Valorados estan siendo Utlizados", "Generación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {


                    var Msg = MessageBox.Show("Esta Seguro que desea Eliminar Valorados Generados?...", "Generación de Valorados", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Msg == DialogResult.No)
                    {
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    else
                    {
                        idEstadoVal = 3;
                        this.btnGrabar.Enabled = true;
                        this.btnGrabar.PerformClick();
                    }
                }
            }
           
          
        }

      
        

       
    }
}
