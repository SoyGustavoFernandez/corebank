using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using SER.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace SER.Presentacion
{
    public partial class frmRegistrarComisionGiro : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();

        DataTable dtComisionGiros       = new DataTable();
        DataTable dtTipoComisionGiro    = new DataTable();        

        int idAgenciaOrigen = 0;
        int idAgenciaDestino= 0;
        int idComisionGiro = 0;

        String cTipoOperacion = "N"; //N: nuevo, A: actualizar
        String cTituloMensajes = "Registro de comisión de giro";

        #endregion

        public frmRegistrarComisionGiro()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmRegistrarComisionGiro_Load(object sender, EventArgs e)
        {            
            //cargar combo Tipo Comisión
            cboTipoComision.SelectedIndexChanged -= new EventHandler(cboTipoComision_SelectedIndexChanged);

            dtTipoComisionGiro = cncontrolserv.listarTipoComisionGiro();
            cboTipoComision.DataSource      = dtTipoComisionGiro;
            cboTipoComision.ValueMember     = dtTipoComisionGiro.Columns["idTipComGiro"].ToString();
            cboTipoComision.DisplayMember   = dtTipoComisionGiro.Columns["cDesTipComGiro"].ToString();

            cboTipoComision.SelectedIndexChanged += new EventHandler(cboTipoComision_SelectedIndexChanged);            

            habilitarControles(false);
            // carga agencias que aplican a giros ===================================================
            this.cboAgenciaOrigen.SelectedIndexChanged -= new EventHandler(cboAgenciaOrigen_SelectedIndexChanged);
            this.cboAgenciaDestino.SelectedIndexChanged -= new EventHandler(cboAgenciaDestino_SelectedIndexChanged);
            this.cboAgenciaOrigen.SoloAptosAgiros();
            this.cboAgenciaDestino.SoloAptosAgiros();
            this.cboAgenciaOrigen.SelectedIndexChanged += new EventHandler(cboAgenciaOrigen_SelectedIndexChanged);
            this.cboAgenciaDestino.SelectedIndexChanged += new EventHandler(cboAgenciaDestino_SelectedIndexChanged);
        }       

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            habilitarControles(false);
            limpiarCampos();
            verComisionGiro();
            cTipoOperacion = String.Empty;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (lCamposSonValidos() == false) return;

            DataTable dtComisionGiro = new DataTable("dtComisionGiro");
            dtComisionGiro.Columns.Add("idComisionGiro", typeof(int));
            dtComisionGiro.Columns.Add("idAgencia", typeof(int));
            dtComisionGiro.Columns.Add("idAgeDestino", typeof(int));
            dtComisionGiro.Columns.Add("idTipComGiro", typeof(int));
            dtComisionGiro.Columns.Add("idMoneda", typeof(int));
            dtComisionGiro.Columns.Add("nMontoCom", typeof(Decimal));
            dtComisionGiro.Columns.Add("nMonMinCom", typeof(Decimal));
            dtComisionGiro.Columns.Add("nMonMaxCom", typeof(Decimal));
            dtComisionGiro.Columns.Add("lEstado", typeof(Boolean));

            DataRow drFila = dtComisionGiro.NewRow();
            drFila["idComisionGiro"] = this.idComisionGiro;
            drFila["idAgencia"] = Convert.ToInt32(cboAgenciaOrigen.SelectedValue);
            drFila["idAgeDestino"] = Convert.ToInt32(cboAgenciaDestino.SelectedValue);
            drFila["idTipComGiro"] = Convert.ToInt32(cboTipoComision.SelectedValue);
            drFila["idMoneda"] = Convert.ToInt32(this.cboMoneda.SelectedValue);
            drFila["nMontoCom"] = Convert.ToDecimal(txtMontoComision.Text);
            drFila["nMonMinCom"] = Convert.ToDecimal(txtMontoMin.Text);
            drFila["nMonMaxCom"] = Convert.ToDecimal(txtMontoMax.Text);
            drFila["lEstado"] = Convert.ToBoolean(this.chcVigente.Checked);
            dtComisionGiro.Rows.Add(drFila);

            //----------------------- NUEVA CONFIGURACIÓN ---------------------------->
            DataSet ds = new DataSet("dsComisionGiro");
            ds.Tables.Add(dtComisionGiro);
            String xmlComisionGiro = ds.GetXml();
            xmlComisionGiro = clsCNFormatoXML.EncodingXML(xmlComisionGiro);
            //------------------------------------------------------------------------>
            
            DataTable dtRpta = cncontrolserv.RegistaConfiguracComisionGiro(xmlComisionGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(dtRpta.Rows[0]["idError"]) == 1)
            {
                MessageBox.Show(dtRpta.Rows[0]["cMensaje"].ToString(), "Registrar Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(dtRpta.Rows[0]["cMensaje"].ToString(), "Registrar Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarComisionGiro();
            }
            limpiarCampos();
            habilitarControles(false);
        }
        private void cboTipoComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoComision.SelectedValue) == 1)//FIJO
            {
                lblSimbolo.Visible = false;
            }
            if (Convert.ToInt32(cboTipoComision.SelectedValue) == 2)//PORCENTUAL
            {
                lblSimbolo.Visible = true;
            }
        }

        private void cboAgenciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            verComisionGiro();
        }
        private void cboAgenciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            verComisionGiro();
        }
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            verComisionGiro();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            /*if (Convert.ToInt32(cboAgenciaOrigen.SelectedValue) == Convert.ToInt32(cboAgenciaDestino.SelectedValue))
            {
                MessageBox.Show("No se permite guardar una comisión de envío de giro para la misma Agencia.", "Validación Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } */           
            this.idComisionGiro = 0;
            this.cTipoOperacion = "N";
            this.chcVigente.Checked = true;
            habilitarControles(true);
            txtMontoComision.Focus();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dtgComisionGiros.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros de comisiones para editar", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (this.dtgComisionGiros.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar el registro que desea editar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cTipoOperacion = "A";
                    llenarCampos();
                    habilitarControles(true);
                }
            }
        }
        private void txtMontoComision_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtMontoComision);
        }

        private void txtMontoMin_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtMontoMin);
        }

        private void txtMontoMax_Leave(object sender, EventArgs e)
        {
            darFormatoTxtDecimal(this.txtMontoMax);
        }
        #endregion
        #region Metodos

        private void limpiarCampos()
        {       
            this.cboTipoComision.SelectedIndex = 0;
            this.txtMontoComision.Clear();
            this.txtMontoMin.Clear();
            this.txtMontoMax.Clear();
            this.chcVigente.Checked = false;
        }
        private void verComisionGiro()
        {
            /*if (Convert.ToInt32(cboAgenciaOrigen.SelectedValue) == Convert.ToInt32(cboAgenciaDestino.SelectedValue))
            {
                MessageBox.Show("La agencia de Origen y Destino deben ser diferentes", "Validación Agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                dtgComisionGiros.DataSource = null;
            }
            else
            {*/
            BuscarComisionGiro();
            btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            String cSimbolo = (String)((DataRowView)this.cboMoneda.SelectedItem)["cSimbolo"];
            this.grbMontos.Text = this.grbMontos.Text.Substring(0, this.grbMontos.Text.IndexOf("(") + 1) + cSimbolo + ")";
            //}
        }
        private void BuscarComisionGiro()
        {
            idAgenciaOrigen = Convert.ToInt32(cboAgenciaOrigen.SelectedValue);
            idAgenciaDestino= Convert.ToInt32(cboAgenciaDestino.SelectedValue);
            int idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);

            dtComisionGiros = cncontrolserv.BuscarDatosComisionGiro(idAgenciaOrigen, idAgenciaDestino, idMoneda);
            dtgComisionGiros.DataSource = dtComisionGiros;

            DarFormatoGridComisionGiro();
        }

        private void DarFormatoGridComisionGiro()
        {
            foreach (DataGridViewColumn item in dtgComisionGiros.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }             

            this.dtgComisionGiros.Columns["cDesTipComGiro"].Visible  = true;
            this.dtgComisionGiros.Columns["nMontoCom"].Visible       = true;
            this.dtgComisionGiros.Columns["nMonMinCom"].Visible      = true;
            this.dtgComisionGiros.Columns["nMonMaxCom"].Visible      = true;
            this.dtgComisionGiros.Columns["lEstado"].Visible         = true;

            this.dtgComisionGiros.Columns["cDesTipComGiro"].Width = 160;            
            this.dtgComisionGiros.Columns["lEstado"].Width = 60;

            this.dtgComisionGiros.Columns["nMontoCom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgComisionGiros.Columns["nMonMinCom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgComisionGiros.Columns["nMonMaxCom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            this.dtgComisionGiros.Columns["cDesTipComGiro"].HeaderText   = "Tipo de Comisión";
            this.dtgComisionGiros.Columns["nMontoCom"].HeaderText        = "Monto Comisión";
            this.dtgComisionGiros.Columns["nMonMinCom"].HeaderText       = "Monto Mínimo";
            this.dtgComisionGiros.Columns["nMonMaxCom"].HeaderText       = "Monto Máximo";
            this.dtgComisionGiros.Columns["lEstado"].HeaderText          = "Vigente";                         
        }
              
        private Boolean lCamposSonValidos()
        {
            if (string.IsNullOrEmpty(txtMontoComision.Text))
            {
                MessageBox.Show("Debe ingresar el monto de la COMISIÓN", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoComision.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtMontoComision.Text)<=0.00m)
            {
                MessageBox.Show("El monto de la COMISIÓN debe ser mayor que 0.00", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoComision.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtMontoMin.Text))
            {
                MessageBox.Show("Debe ingresar el MONTO MÍNIMO de comisión", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoMin.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtMontoMin.Text) <= 0.00m)
            {
                MessageBox.Show("monto mínimo de COMISIÓN debe ser mayor que 0.00", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoMin.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtMontoMax.Text))
            {
                MessageBox.Show("Debe ingresar el MONTO MÁXIMO de comisión", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoMax.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtMontoMax.Text) <= 0.00m)
            {
                MessageBox.Show("El MONTO MÁXIMO de comisión debe ser mayor que 0.00", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoMax.Focus();
                return false;
            }

            //Monto mínimo no pede ser mayor que monto máximo
            if (Convert.ToDecimal(txtMontoMin.Text) >= Convert.ToDecimal(txtMontoMax.Text))
            {
                MessageBox.Show("El MONTO MÍNIMO de comisión no puede ser mayor al MONTO MÁXIMO", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoMax.Focus();
                return false;
            }
            /* VERIFICA SI EL RANGO DE MONTOS  NO SE SUPERPONE SOBRE EXISTENTES --------------------------------------*/            
            if (this.cTipoOperacion == "N")
            {   //busca en toda la grilla de comisiones
                foreach (DataGridViewRow item in this.dtgComisionGiros.Rows)
                {                   
                    if ((Boolean)item.Cells["lEstado"].Value) //busca entre los vigentes
                    {   //si el monto minimo o maximo existe entre los rangos existentes
                        if ((Convert.ToDecimal(item.Cells["nMonMinCom"].Value) <= Convert.ToDecimal(this.txtMontoMin.Text) && Convert.ToDecimal(this.txtMontoMin.Text) <= Convert.ToDecimal(item.Cells["nMonMaxCom"].Value))
                          || (Convert.ToDecimal(item.Cells["nMonMinCom"].Value) <= Convert.ToDecimal(this.txtMontoMax.Text) && Convert.ToDecimal(this.txtMontoMax.Text) <= Convert.ToDecimal(item.Cells["nMonMaxCom"].Value)))
                        {
                            MessageBox.Show("Rango de montos se superpone a rango definido anteriormente", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtMontoMin.Focus();
                            return false;
                        }
                    }
                }
            }
            else if (this.cTipoOperacion == "A")
            {   // busca en todo, menos en la fila seleccionada
                foreach (DataGridViewRow item in this.dtgComisionGiros.Rows)
                {
                    if (item.Index != this.dtgComisionGiros.SelectedRows[0].Index)
                    {
                        if ((Boolean)item.Cells["lEstado"].Value) //busca entre los vigentes
                        {   //si el monto minimo o maximo existe entre los rangos existentes
                            if ((Convert.ToDecimal(item.Cells["nMonMinCom"].Value) <= Convert.ToDecimal(this.txtMontoMin.Text) && Convert.ToDecimal(this.txtMontoMin.Text) <= Convert.ToDecimal(item.Cells["nMonMaxCom"].Value))
                              || (Convert.ToDecimal(item.Cells["nMonMinCom"].Value) <= Convert.ToDecimal(this.txtMontoMax.Text) && Convert.ToDecimal(this.txtMontoMax.Text) <= Convert.ToDecimal(item.Cells["nMonMaxCom"].Value)))
                            {
                                MessageBox.Show("Rango de montos se superpone a rango definido anteriormente", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.txtMontoMin.Focus();
                                return false;
                            }
                        }
                    }
                }                                           
            }                                    
            return true;
        }
        
        private void llenarCampos()
        {
            this.idComisionGiro = Convert.ToInt32(this.dtgComisionGiros.SelectedRows[0].Cells["idComisionGiro"].Value);
            this.cboTipoComision.SelectedValue = Convert.ToInt32(this.dtgComisionGiros.SelectedRows[0].Cells["idTipComGiro"].Value);
            this.txtMontoComision.Text = Convert.ToString(Convert.ToDecimal(this.dtgComisionGiros.SelectedRows[0].Cells["nMontoCom"].Value));
            this.txtMontoMin.Text = Convert.ToString(Convert.ToDecimal(this.dtgComisionGiros.SelectedRows[0].Cells["nMonMinCom"].Value));
            this.txtMontoMax.Text = Convert.ToString(Convert.ToDecimal(this.dtgComisionGiros.SelectedRows[0].Cells["nMonMaxCom"].Value));
            this.chcVigente.Checked = Convert.ToBoolean(this.dtgComisionGiros.SelectedRows[0].Cells["lEstado"].Value);            
        }
        private void habilitarControles(Boolean val)
        {
            this.pnlMontos.Enabled = val;
            this.chcVigente.Enabled = val;            

            this.cboAgenciaOrigen.Enabled = !val;
            this.cboAgenciaDestino.Enabled = !val;
            this.cboMoneda.Enabled = !val;

            this.dtgComisionGiros.Enabled = !val;
            this.btnNuevo.Enabled = !val;
            this.btnEditar.Enabled = !val;
            btnGrabar.Enabled = val;
            btnCancelar.Enabled = val;
        }
        private void darFormatoTxtDecimal(txtNumRea txtNR)
        {
            Decimal d;
            if (!Decimal.TryParse(txtNR.Text, out d))
            {
                MessageBox.Show("Ingrese un monto correcto", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNR.Text = "0.00";
                txtNR.Focus();
            }
            txtNR.Text = txtNR.nDecValor.ToString("N2");
        }
        #endregion       

        
    }
}

