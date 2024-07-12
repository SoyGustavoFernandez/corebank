using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmReasigDeposito : frmBase
    {
        #region Variables Globales
        clsCNDeposito clsDeposito = new clsCNDeposito();
        DataTable dtDepositos;
        DataTable dtDestino;
        DataTable dtDepOri;
    
        string xmlCuentasAsig;
        DataSet dsAsignacion = new DataSet();
        #endregion
        public frmReasigDeposito()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmReasigDeposito_Load(object sender, EventArgs e)
        {
            this.Limpiar();

            this.cboAgenciasOri.Enabled = false;
            this.cboAgenciasDes.Enabled = false;

            this.cboAgenciasOri.SelectedIndex=-1;
            this.cboAgenciasDes.SelectedIndex = -1;
            this.chcTodos.Enabled = false;
            this.txtMotivo.Enabled = false;

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataRow dr;
            DataTable dtCuentasAsig= new DataTable();
            dtCuentasAsig.Columns.Add("idCuenta", typeof(Int32));

            if (Validar())
            {
                for (int i = 0; i < dtDepOri.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtDepOri.Rows[i]["lSeleCta"].ToString()) == true)
                    {
                        dr = dtCuentasAsig.NewRow();
                        dr["idCuenta"] = dtDepOri.Rows[i]["idCuenta"];
                        dtCuentasAsig.Rows.Add(dr);
                    }
                }
                if (dtCuentasAsig.Rows.Count<=0)
                {
                    MessageBox.Show("Debe elegir por lo menos una cuenta para reasignar", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idAgenOri = Convert.ToInt32(this.cboAgenciasOri.SelectedValue);
                int idUsuOri = Convert.ToInt32(this.conBusColOrigen.idUsu);
                int idAgenDes = Convert.ToInt32(this.cboAgenciasDes.SelectedValue);
                int idUsuDes = Convert.ToInt32(this.conBusColDestino.idUsu);
                string cMotivo = this.txtMotivo.Text.Trim();
                dsAsignacion.Tables.Add(dtCuentasAsig);
                xmlCuentasAsig = dsAsignacion.GetXml();
                
                DataTable dtResp = clsDeposito.CNGuadarReasig(xmlCuentasAsig, idAgenDes, idUsuDes, cMotivo, idAgenOri, idUsuOri,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia,clsVarGlobal.dFecSystem );
                if ((Int32)dtResp.Rows[0]["RSPT"] == 1)
                {
                    MessageBox.Show("Reasignación de depósitos exitosa", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    txtMotivo.Enabled = false;

                    this.conBusColDestino.txtCod.Enabled = true;                
                    this.conBusColOrigen.txtCod.Enabled = true;              
                    this.chcTodos.Enabled = false;
                    this.txtMotivo.Enabled = false;
                    this.conBusColOrigen.txtCod.Focus();
                    limpiarDatosColDes();
                    limpiarDatosColOri();
                }
                else
                {
                    MessageBox.Show("No se pudo Realizar la Reasignacion de Depositos", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                dsAsignacion.Tables.Remove("Table1");
                this.btnCancelar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.PerformClick();
            }           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { 
            this.Limpiar();
            this.btnCancelar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.conBusColDestino.txtCod.Enabled = true;
            this.conBusColDestino.LimpiarDatos();
            this.conBusColOrigen.txtCod.Enabled = true;
            this.conBusColOrigen.LimpiarDatos();
            this.chcTodos.Enabled = false;
            this.txtMotivo.Enabled = false;
            this.conBusColOrigen.txtCod.Focus();
            limpiarDatosColOri();
            limpiarDatosColDes();
        }
        #endregion

        private void limpiarDatosColOri()
        {
            conBusColOrigen.idUsu="";
            conBusColOrigen.cNom="";
            conBusColOrigen.cDocID="";
            conBusColOrigen.idCargoPer="";
            conBusColOrigen.cCargoPer="";
            conBusColOrigen.idCliPer = "";
            conBusColOrigen.idAgencia="";
            conBusColOrigen.nPorLibVia = 0;
        }
        private void limpiarDatosColDes()
        {
            conBusColDestino.idUsu = "";
            conBusColDestino.cNom = "";
            conBusColDestino.cDocID = "";
            conBusColDestino.idCargoPer = "";
            conBusColDestino.cCargoPer = "";
            conBusColDestino.idCliPer = "";
            conBusColDestino.idAgencia = "";
            conBusColDestino.nPorLibVia = 0;

        }
        #region Metodos
        private DataTable DepositoxPer(int idusuario)
        {
            dtDepositos = clsDeposito.CNListaDepositoxPer(idusuario);
            return dtDepositos;            
        }
        private void FormatoGridOrigen()
        {
            dtgOrigen.Columns["idCuenta"].Width = 60;
            dtgOrigen.Columns["cNomCli"].Width = 180;
            dtgOrigen.Columns["cProducto"].Width = 110;
            dtgOrigen.Columns["nMontoDeposito"].Width = 70;
            dtgOrigen.Columns["nCuoPen"].Width = 30;
            dtgOrigen.Columns["nAtrasoDep"].Width = 30;
            this.dtgOrigen.Columns["lSeleCta"].Width = 20;

            this.dtgOrigen.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgOrigen.Columns["cNomCli"].HeaderText = "Cliente";
            this.dtgOrigen.Columns["cProducto"].HeaderText = "Prod.";
            this.dtgOrigen.Columns["nMontoDeposito"].HeaderText = "Monto";
            this.dtgOrigen.Columns["nCuoPen"].HeaderText = "CuPen";
            this.dtgOrigen.Columns["nAtrasoDep"].HeaderText = "Atr";
            this.dtgOrigen.Columns["lSeleCta"].HeaderText = " ";

        }
        private void FormatoGridDestino()
        {
            this.dtgDestino.Columns["lSeleCta"].Visible = false;
            this.dtgDestino.Columns["nCuoPen"].Visible =false;
            this.dtgDestino.Columns["nAtrasoDep"].Visible =false;

            this.dtgDestino.Columns["idCuenta"].Width = 60;
            this.dtgDestino.Columns["cNomCli"].Width = 180;
            this.dtgDestino.Columns["cProducto"].Width = 90;
            this.dtgDestino.Columns["nMontoDeposito"].Width = 50;
       
            this.dtgDestino.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgDestino.Columns["cNomCli"].HeaderText = "Cliente";
            this.dtgDestino.Columns["cProducto"].HeaderText = "Prod.";
            this.dtgDestino.Columns["nMontoDeposito"].HeaderText = "Monto";
            this.dtgDestino.Columns["nCuoPen"].HeaderText = "CuPen";
            this.dtgDestino.Columns["nAtrasoDep"].HeaderText = "Atr";
        }
        private void HabilitarGridOrigen(Boolean bVal)
        {
            this.dtgOrigen.ReadOnly = !bVal;
            this.dtgOrigen.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgOrigen.Columns["cNomCli"].ReadOnly = bVal;
            this.dtgOrigen.Columns["cProducto"].ReadOnly = bVal;
            this.dtgOrigen.Columns["nMontoDeposito"].ReadOnly = bVal;
            this.dtgOrigen.Columns["nCuoPen"].ReadOnly = bVal;
            this.dtgOrigen.Columns["nAtrasoDep"].ReadOnly = bVal;
            this.dtgOrigen.Columns["lSeleCta"].ReadOnly = !bVal;
        }
        private void Limpiar()
        {
            this.cboAgenciasOri.SelectedIndex = -1;
            this.cboAgenciasDes.SelectedIndex = -1;
            this.lblNroCueDest.Text = "";
            this.lblNroCueOrigen.Text = "";
            this.txtMotivo.Clear();
            this.dtgOrigen.DataSource = "";
            this.dtgDestino.DataSource = "";
            conBusColOrigen.LimpiarDatos();
            conBusColDestino.LimpiarDatos();
          
        }
        private Boolean Validar()
        {
           
            if (this.conBusColDestino.idUsu == null)
            {
                MessageBox.Show("Seleccione colaborador destino", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return false;
            }
            if (this.cboAgenciasDes.SelectedIndex <=-1)
            {
                MessageBox.Show("Seleccione agencia destino", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgenciasDes.Focus();
                return false;
            }         
            if (this.dtgOrigen.Rows.Count <= 0)
            {
                MessageBox.Show("Colaborador origen no tiene depósitos asignados", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (conBusColOrigen.idUsu == conBusColDestino.idUsu)
            {
                MessageBox.Show("El colaborador orígen y destino no pueden ser el mismo", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMotivo.Text.Trim() == "")
            {
                MessageBox.Show("Se debe ingresar obligatoriamente un motivo", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            bool nIndSel = false;
            foreach (DataRow item in dtDepOri.Rows)
            {
                if ((bool)item["lSeleCta"])
                {
                    nIndSel = true;
                    break;
                }
            }
            if (!nIndSel)
            {
                MessageBox.Show("Debe seleccionar al menos una Cuenta.", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        #endregion        

        private void dtgOrigen_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgOrigen.IsCurrentCellDirty)
            {
                dtgOrigen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                foreach (DataRow NRow in dtDepOri.Rows)
                {
                    NRow["lSeleCta"] = true;
                }
                dtgOrigen.Refresh();
            }
            else
            {
                foreach (DataRow NRow in dtDepOri.Rows)
                {
                    NRow["lSeleCta"] = false;
                }
                dtgOrigen.Refresh();
            }
        }

        private void conBusColOrigen_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColOrigen.idUsu == null)
            {
                limpiarDatosColDes();
                conBusColDestino.LimpiarDatos();
                this.dtgOrigen.DataSource = "";
                chcTodos.Enabled=false;
                txtMotivo.Enabled = false;
                lblNroCueOrigen.Text = "";
                cboAgenciasOri.SelectedIndex = -1;
                return;
            }

            /*if (conBusColOrigen.idAgencia != cboAgenciasOri.SelectedValue)
	        {
                MessageBox.Show("El colaborador seleccionado no pertenece a la agencia origen", "Reasignación de Depositos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
	        }*/

            if (conBusColOrigen.idUsu == conBusColDestino.idUsu)
            {
                MessageBox.Show("El colaborador origen no puede ser igual al colaborador destino", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiarDatosColOri();    
                conBusColOrigen.LimpiarDatos();
    
                return;
            }

            this.lblNroCueOrigen.Text = "";
            if (conBusColOrigen.idCliPer != "")
            {
                cboAgenciasOri.SelectedValue = conBusColOrigen.idAgencia;               

                dtDepOri = DepositoxPer(Convert.ToInt32(conBusColOrigen.idUsu));
                if (dtDepOri.Rows.Count > 0)
                {
              
                    this.dtDepOri.Columns["lSeleCta"].ReadOnly = false;

                    this.dtgOrigen.DataSource = dtDepOri;
                    this.dtgOrigen.ReadOnly = false;

                    this.FormatoGridOrigen();
                    this.lblNroCueOrigen.Text = dtDepOri.Rows.Count.ToString();
                    this.btnGrabar.Enabled = true;
                    this.chcTodos.Enabled = true;
                    this.txtMotivo.Enabled = true;
                    this.conBusColOrigen.txtCod.Enabled = false;
                }
                else
                {
                    this.dtgOrigen.DataSource = "";
                    this.btnCancelar.Enabled = false;
                    MessageBox.Show("El colaborador no tiene cuentas asignadas", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.btnCancelar.Enabled = true;
            }
        }

        private void conBusColDestino_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColDestino.idUsu == null)
            {
                limpiarDatosColDes();
                conBusColDestino.LimpiarDatos();
                this.dtgDestino.DataSource = "";
                lblNroCueDest.Text = "";
                cboAgenciasDes.SelectedIndex = -1;
                return;
            }

            /*if (conBusColDestino.idAgencia != cboAgenciasDes.SelectedValue)
	        {
                MessageBox.Show("El colaborador seleccionado no pertenece a la agencia destino", "Reasignación de Depositos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
	        }*/

            if (conBusColDestino.idUsu == conBusColOrigen.idUsu)
            {
                MessageBox.Show("El colaborador destino no puede ser igual al colaborador origen", "Reasignación de depósito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarDatosColDes();
                conBusColDestino.LimpiarDatos();
                return;
            }

            this.lblNroCueDest.Text = "";
            if (conBusColDestino.idCliPer != "")
            {
                cboAgenciasDes.SelectedValue = conBusColDestino.idAgencia;               

                dtDestino = DepositoxPer(Convert.ToInt32(conBusColDestino.idUsu));
                if (dtDestino.Rows.Count > 0)
                {
                    this.dtDestino.Columns["lSeleCta"].ReadOnly = false;
                    this.dtgDestino.DataSource = dtDestino;
                    this.dtgDestino.ReadOnly = false;
                    this.FormatoGridDestino();
                    this.lblNroCueDest.Text = dtDestino.Rows.Count.ToString();
                    this.btnCancelar.Enabled = true;
                    this.conBusColDestino.txtCod.Enabled = false;
                }
                else
                {
                    this.dtgDestino.DataSource = "";
                    this.btnCancelar.Enabled = false;
                }
            }
        }
    }
}
