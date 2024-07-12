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
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmDesbloqCuenta : frmBase
    {
        #region Variables Globales
        clsCNDeposito clsDeposito = new clsCNDeposito();
        DataTable dtBloq = new DataTable(), dtCarac;
        int idCuenta = 0;
        string cTipOpe = "N";
        #endregion

        public frmDesbloqCuenta()
        {
            InitializeComponent();         
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(idCuenta);
            rbtInterno.Checked = false;
            rbtExterno.Checked = false;
            limpiarcontroles();
            dtBloq.Rows.Clear();
            conBusCtaAho.LimpiarControles();
            HabDesabilitaCtr(false);                        
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            this.btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            cTipOpe = "N";
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodAge.Focus();
            txtTotalBloq.Text ="0.00";
        }
        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Buscar Primero una Cuenta para Registrar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.txtNroCta.Focus();
                return;
            }
                        
            if (rbtInterno.Checked == false && rbtExterno.Checked == false)
            {
                MessageBox.Show("Debe seleccionar el Solicitante...Verificar", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbtInterno.Focus();
                return;
            }

            if (rbtInterno.Checked)
            {
                if (string.IsNullOrEmpty(conBusCol.txtNom.Text))
                {
                    MessageBox.Show("Debe Buscar al Colaborador Solicitante...Verificar", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCol.txtCod.Focus();
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Debe Registrar el Nombre del Solicitante Externo...", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtMotDesbloqueo.Text))
            {
                MessageBox.Show("Debe de Ingresar el Motivo de Desbloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotDesbloqueo.Select();
                txtMotDesbloqueo.Focus();
                return;
            }

            if (dtBloq.Rows.Count<=0)
            {
                MessageBox.Show("la Cuenta no Tiene Bloqueos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotDesbloqueo.Select();
                txtMotDesbloqueo.Focus();
                return;
            }

            //-------------------------------------------------------------------------------------------------------
            //--Validar si la Cuenta esta bloqueado por Garantía y esta vigente
            //-------------------------------------------------------------------------------------------------------
            DataTable dtValBloq = clsDeposito.CNValidaBloqueoCuentaxGar(Convert.ToInt32(conBusCtaAho.idcuenta));
            if (dtValBloq.Rows.Count > 0)
            {
                MessageBox.Show("No Puede Realizar el Desbloqueo de la Cuenta, Primero Liberar en el Control de Garantías", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /*========================================================================================
             * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Desbloqueo de cuenta", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
              //--=======================================================
            //--Generar XML de Datos Bloqueo
            //--=======================================================
            DataTable tbBloqueo = dtBloq.Clone();

            tbBloqueo.ImportRow(dtBloq.Rows[dtgBloqueosCta.CurrentRow.Index]);
  
            DataSet dsBloq = new DataSet("dsBloqueo");
            dsBloq.Tables.Add(tbBloqueo);            
            string xmlBloq = clsCNFormatoXML.EncodingXML(dsBloq.GetXml());

            int idTipSolDesbloq = 0;
            string cNomSolDesbloq = "";

            if (rbtInterno.Checked)
            {
                idTipSolDesbloq = 1;  //--Interno
                cNomSolDesbloq = conBusCol.txtNom.Text;
            }
            else
            {
                idTipSolDesbloq = 2; //--Externo
                cNomSolDesbloq = txtNombre.Text;
            }

            int nCta=Convert.ToInt32(conBusCtaAho.idcuenta);
            Decimal nMonto=Convert.ToDecimal (txtTotalBloq.Text);
            string x_cMotDesblq = txtMotDesbloqueo.Text;

            DataTable tbRegBlo = clsDeposito.CNRegistraBloqueoCuenta(xmlBloq, nCta, nMonto, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, x_cMotDesblq, false, idTipSolDesbloq, cNomSolDesbloq);

            if (Convert.ToInt32(tbRegBlo.Rows[0]["idRpta"].ToString()) == 0)
            {
                dtBloq.Rows.Remove(dtBloq.Rows[dtgBloqueosCta.CurrentRow.Index]);
                MessageBox.Show(tbRegBlo.Rows[0]["cMensage"].ToString(), "Registro de Desbloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRegBlo.Rows[0]["cMensage"].ToString(), "Registro de Desbloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //=====================================================
            //--Liberar Variables
            //=====================================================
            dtBloq.Dispose();

            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            HabDesabilitaCtr(false);
            if (dtBloq.Rows.Count<=0)
            {
                dtgBloqueosCta.Enabled = false;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                dtgBloqueosCta.Enabled = true;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
            }

            rbtExterno.Checked = false;
            rbtInterno.Checked = false;
            conBusCol.LimpiarDatos();
            txtNombre.Enabled = false;
            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = false;
            txtNombre.Clear();

            /*========================================================================================
            * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Fin-Desbloqueo de cuenta", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

        }
      
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < dtBloq.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtBloq.Rows[i]["lBloqueado"]))
                {
                    k++;
                    break;
                }
            }
            if (k<=0)
            {
                MessageBox.Show("Para Editar, primero debe seleccionar uno de los bloqueos para su Desbloqueo", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgBloqueosCta.Focus();
                return;
            }
            HabDesabilitaCtr(true);
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            this.btnEditar.Enabled=false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            cTipOpe = "A";            
            conBusCol.HabilitarControles(false);
            txtNombre.Enabled = false;
            dtgBloqueosCta.Enabled = false;
            rbtInterno.Focus();
            //txtMotDesbloqueo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(idCuenta);
        }

        private void frmBloqueoCuenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(idCuenta);
        }

        #endregion
        #region Metodos
        
        //--====================================================
        //--Lista Caracteristicas del Bloqueo
        //--====================================================
        //private void CargarCaracterisBloq(int idBloq)
        //{
        //    txtMonBloq.Text = "0.00";
        //    dtCarac = new clsCNAperturaCta().RetornaTiposCaractBloq(idBloq);
        //    cboCaractBloq.DataSource = dtCarac;            
        //    cboCaractBloq.ValueMember = dtCarac.Columns["idCaracteristicaBloq"].ToString();
        //    cboCaractBloq.DisplayMember = dtCarac.Columns["cDescripcion"].ToString();
        //    if (dtCarac.Rows.Count>0)
        //    {
        //        if ((bool)dtCarac.Rows[cboCaractBloq.SelectedIndex]["lIsReqMonto"])
        //        {
        //            txtMonBloq.Enabled = true;
        //            txtMonBloq.Select();
        //            txtMonBloq.Focus();
        //        }
        //        else
        //        {
        //            txtMonBloq.Enabled = false;
        //            txtMotDesbloqueo.Select();
        //            txtMotDesbloqueo.Focus();
        //        }
        //    }
            
        //}

        
        #endregion

        private void frmBloqCuenta_Load(object sender, EventArgs e)
        {
            CargarDatosBloqueoIni(0);
            HabDesabilitaCtr(false);
            conBusCtaAho.nTipOpe = 12;  //--Ope Cancelación, Igual Lista todas las cuentas vigentes
            conBusCtaAho.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
        }

        private void cboTipoBloqueo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarCaracterisBloq(Convert.ToInt32(cboTipoBloqueo.SelectedValue));
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            limpiarcontroles();
            if (conBusCtaAho.idcuenta>0)
            {
                DatosCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
        }

        private void DatosCuenta(int idCta)
        {
            limpiarcontroles();
            HabDesabilitaCtr(false);
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1",12);
             if (dtbNumCuentas.Rows.Count>0)
             {
                 txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                 cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                 txtMonto.Text = dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString();
                 CargarDatosBloqueo(idCta);                 
             }
        }

        private void CargarDatosBloqueoIni(int idCta)
        {
            dtBloq = clsDeposito.CNRetornaBloqueosCuenta(idCta);
            dtgBloqueosCta.DataSource = dtBloq;
            formatoGrid();
            CalcularTotal();
        }

        private void CargarDatosBloqueo(int idCta)
        {
            dtBloq.Rows.Clear();
            dtBloq = clsDeposito.CNRetornaBloqueosCuenta(idCta);
            dtgBloqueosCta.DataSource = dtBloq;
            if (dtBloq.Rows.Count>0)
            {
                btnGrabar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
                HabDesabilitaCtr(false);
                cTipOpe = "A";
                conBusCtaAho.HabDeshabilitarCtrl(false);
                dtgBloqueosCta.Enabled = true;
            }
            else
            {
                MessageBox.Show("La Cuenta no Tiene Bloqueos...", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarcontroles();                
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
                HabDesabilitaCtr(false);
                cTipOpe = "N";
                conBusCtaAho.LimpiarControles();
                dtgBloqueosCta.Enabled = false;
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
            }
            formatoGrid();
            
            CalcularTotal();
        }

        private void DesmarcarTodo()
        {
            for (int i = 0; i < dtBloq.Rows.Count; i++)
            {
                dtBloq.Rows[i]["lBloqueado"]=false;
            }
        }

        public void formatoGrid()
        {
            DesmarcarTodo();
            dtgBloqueosCta.ReadOnly = false;
            dtgBloqueosCta.Columns["idCuenta"].Visible = false;
            dtgBloqueosCta.Columns["idBloqueo"].Visible = false;
            //dtgBloqueosCta.Columns["lBloqueado"].Visible = false;
            dtgBloqueosCta.Columns["idBloCta"].Visible = false;
            dtgBloqueosCta.Columns["idCaracteristicaBloq"].Visible = false;
            dtgBloqueosCta.Columns["idTipoSolicitante"].Visible = false;
            dtgBloqueosCta.Columns["cNombreSolicitante"].Visible = false;

            dtgBloqueosCta.Columns["lBloqueado"].HeaderText = "X";
            dtgBloqueosCta.Columns["lBloqueado"].Width = 25;
            dtgBloqueosCta.Columns["cDescripcion"].HeaderText = "Motivo de Bloqueo";
            dtgBloqueosCta.Columns["cDescripcion"].Width = 180;
            dtgBloqueosCta.Columns["cDescriCaract"].HeaderText = "Tipo Bloqueo";
            dtgBloqueosCta.Columns["cDescriCaract"].Width = 180;
            dtgBloqueosCta.Columns["nMonBloqueo"].HeaderText = "Monto";
            dtgBloqueosCta.Columns["nMonBloqueo"].Width = 70;
            dtgBloqueosCta.Columns["dFechaDocBloqueo"].HeaderText = "Fecha Doc";
            dtgBloqueosCta.Columns["dFechaDocBloqueo"].Width = 70;
            dtgBloqueosCta.Columns["cDesMotivo"].HeaderText = "Descripción del Bloqueo";

            dtgBloqueosCta.Columns["cDescripcion"].ReadOnly = true;
            dtgBloqueosCta.Columns["cDescriCaract"].ReadOnly = true;
            dtgBloqueosCta.Columns["nMonBloqueo"].ReadOnly = true;
            dtgBloqueosCta.Columns["cDescripcion"].ReadOnly = true;
            dtgBloqueosCta.Columns["dFechaDocBloqueo"].ReadOnly = true;
            dtgBloqueosCta.Columns["cDesMotivo"].ReadOnly = true;

            dtgBloqueosCta.Columns["lBloqueado"].ReadOnly = false;
            dtBloq.Columns["lBloqueado"].ReadOnly = false;
        }
        
        private void limpiarcontroles()
        {
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            txtMonto.Text = "0.00";
            txtMotDesbloqueo.Text = "";
            conBusCol.LimpiarDatos();
            txtNombre.Text = "";
        }

        private void HabDesabilitaCtr(bool Val)
        {
            txtMotDesbloqueo.Enabled = Val;
            rbtInterno.Enabled = Val;
            rbtExterno.Enabled = Val;
            conBusCol.HabilitarControles(Val);
            txtNombre.Enabled = Val;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidardetBloq())
            {
                return;
            }

            DataRow dr = dtBloq.NewRow();
            //dr["idCuenta"] = Convert.ToInt32(conBusCtaAho.txtNroCta.Text);
            //dr["idBloqueo"] = Convert.ToInt32(cboTipoBloqueo.SelectedValue);
            //dr["cDescripcion"] = cboTipoBloqueo.Text;
            //dr["idCaracteristicaBloq"] = Convert.ToInt32(cboCaractBloq.SelectedValue);
            //dr["cDescriCaract"] = cboCaractBloq.Text;
            //dr["nMonBloqueo"] = Convert.ToDecimal (txtMonBloq.Text);
            //dr["dFechaDocBloqueo"] = dtpFecDoc.Value;
            //dr["cDesMotivo"] = txtMotDesbloqueo.Text.ToString().Trim();
            //dr["lBloqueado"] = 0;
            dtBloq.Rows.Add(dr);

            //if (dtBloq.Rows.Count<=0)
            //{//idCuenta,B.idBloqueo,TB.cDescripcion,B.idCaracteristicaBloq,C.cDescripcion AS cDescriCaract,
            //    //B.nMonBloqueo,B.cDesMotivo
                
            //}
            //else
            //{
            //    //foreach (DataRow item in dtBloq.Rows)
            //    //{
            //    //    if (Convert.ToInt32(item["idBloqueo"]) ==Convert.ToInt32(cboTipoBloqueo.SelectedValue) && Convert.ToInt32(item["idCaracteristicaBloq"])==Convert.ToInt32(cboCaractBloq.SelectedValue))
            //    //    {
            //    //        MessageBox.Show("Ya Agrego El Tipo de Bloqueo", "Validación de Bloqueos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //        return;
            //    //    }
            //    //}

            //}
            //CalcularTotal();
            //cboTipoBloqueo.SelectedValue = 0;
            //txtMonBloq.Text = "0.00";
            //txtMotDesbloqueo.Text = "";
            //cboTipoBloqueo.Focus();
        }

        private bool ValidardetBloq()
        {
            //if (cboTipoBloqueo.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Primero debe Seleccionar el Tipo de Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cboTipoBloqueo.Focus();
            //    return false;
            //}

            //if (cboCaractBloq.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Primero debe Seleccionar la Característica del Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cboCaractBloq.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txtMonBloq.Text))
            //{
            //    MessageBox.Show("Debe de ingresar el Monto del Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtMonBloq.Select();
            //    txtMonBloq.Focus();
            //    return false;
            //}

            //if (Convert.ToInt32(cboCaractBloq.SelectedValue)==1)
            //{
            //    if (Convert.ToDecimal (txtMonBloq.Text)<=0)
            //    {
            //        MessageBox.Show("El Monto del Bloqueo, debe Ser Mayor a Cero", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtMonBloq.Select();
            //        txtMonBloq.Focus();
            //        return false;
            //    }
            //}

            //if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
            //{
            //     MessageBox.Show("La Fecha de Bloqueo, no puede ser Posterior a la Fecha de Sistema", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    dtpFecDoc.Focus();
            //    return false;
            //}

            if (string.IsNullOrEmpty(txtMotDesbloqueo.Text))
            {
                MessageBox.Show("Debe de Ingresar el Motivo de Desbloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotDesbloqueo.Select();
                txtMotDesbloqueo.Focus();
                return false;
            }
            return true;
        }

        private void CalcularTotal()
        {
            Decimal nTotal = 0.00m;
            dtBloq = null;
            dtBloq = (DataTable)dtgBloqueosCta.DataSource;
            if (dtBloq.Rows.Count > 0)
            {
                foreach (DataRow item in dtBloq.Rows)
                {
                    nTotal = nTotal + Convert.ToDecimal (item["nMonBloqueo"]);
                    txtTotalBloq.Text = String.Format("{0:0.00}", nTotal);
                }
            }
            else
            {
                txtTotalBloq.Text = String.Format("{0:0.00}", 0.00);
            }
            
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtBloq.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtgBloqueosCta.CurrentRow.Cells["idBloqueo"].Value.ToString()) == 3)
                {
                    if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
                    {
                        MessageBox.Show("Primero debe Buscar la Cuenta", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DataTable dtValBloq = clsDeposito.CNValidaBloqueoCuentaxGar(Convert.ToInt32(conBusCtaAho.idcuenta));
                    if (dtValBloq.Rows.Count > 0)
                    {
                        MessageBox.Show("No Puede Realizar el Desbloqueo de la Cuenta, Primero Liberar en el Control de Garantías", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }                
                dtBloq.Rows.Remove(dtBloq.Rows[dtgBloqueosCta.CurrentRow.Index]);
                this.dtgBloqueosCta.Refresh();
            }
            CalcularTotal();
        }

        private void cboCaractBloq_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((bool)dtCarac.Rows[cboCaractBloq.SelectedIndex]["lIsReqMonto"])
            //{
            //    txtMonBloq.Enabled = true;
            //    txtMonBloq.Select();
            //    txtMonBloq.Focus();
            //}
            //else
            //{
            //    txtMonBloq.Enabled = false;
            //    txtMotDesbloqueo.Select();
            //    txtMotDesbloqueo.Focus();
            //}
        }

        private void dtgBloqueosCta_SelectionChanged(object sender, EventArgs e)
        {
            txtMotDesbloqueo.Text = "";
        }

        private void rbtInterno_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            conBusCol.LimpiarDatos();
            txtNombre.Enabled = false;
            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = true;
            conBusCol.btnConsultar.Focus();
        }

        private void rbtExterno_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            conBusCol.LimpiarDatos();
            txtNombre.Enabled = true;
            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = false;
            txtNombre.Focus();
        }

        private void dtgBloqueosCta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                bool lCheck = Convert.ToBoolean(dtgBloqueosCta.Rows[index].Cells["lBloqueado"].Value);

                dtgBloqueosCta.CellValueChanged -= dtgBloqueosCta_CellValueChanged;

                DesmarcarTodo();

                dtgBloqueosCta.Rows[index].Cells["lBloqueado"].Value = lCheck;

                dtgBloqueosCta.CellValueChanged += dtgBloqueosCta_CellValueChanged;
            }

        }

        private void dtgBloqueosCta_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgBloqueosCta.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


    }
}
