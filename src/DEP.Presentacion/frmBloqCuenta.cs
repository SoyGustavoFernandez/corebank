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
    public partial class frmBloqCuenta : frmBase
    {
        #region Variables Globales
        clsCNDeposito clsDeposito = new clsCNDeposito();
        DataTable dtBloq = new DataTable(), dtCarac;
        int idCuenta = 0;
        string cTipOpe = "N";
        #endregion

        public frmBloqCuenta()
        {
            InitializeComponent();         
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(idCuenta);
            limpiarcontroles();
            dtBloq.Rows.Clear();            
            HabDesabilitaCtr(false);                        
            conBusCtaAho.btnBusCliente.Enabled = true;
            this.btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            cTipOpe = "N";
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            rbtInterno.Checked = false;
            rbtExterno.Checked = false;
            txtNombre.Enabled = false;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.txtCodAge.Focus();
        }
        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
             * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Desbloqueo de cuenta", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Buscar Primero una Cuenta para Registrar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoBloqueo.Focus();
                return;
            }
            if (cTipOpe == "N")
            {
                if (dtBloq.Rows.Count<=0)
                {
                     MessageBox.Show("Debe Agregar Mínimamente un Tipo de Bloqueo", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     cboTipoBloqueo.Focus();
                     return; 
                }
            }

            //=====================================================
            //--Validar si hay cambios en los datos
            //=====================================================
            int nCambios = 0;
            for (int i = 0; i < dtBloq.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtBloq.Rows[i]["lBloqueado"])==false)
                {
                    nCambios = 1;
                    break;
                }
                
            }

            if (nCambios==0)
            {
                MessageBox.Show("No existe cambios para guardar datos...Verificar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoBloqueo.Focus();
                return;    
            }

            //--=======================================================
            //--Generar XML de Datos Bloqueo
            //--=======================================================
            DataTable tbBloqueo = dtBloq.Clone();
            for (int i = 0; i < dtBloq.Rows.Count; i++)
            {
                tbBloqueo.ImportRow(dtBloq.Rows[i]);
            }

            DataSet dsBloq = new DataSet("dsBloqueo");
            //dsBloq.Tables.Add(dtBloq);
            dsBloq.Tables.Add(tbBloqueo);            
            string xmlBloq = clsCNFormatoXML.EncodingXML(dsBloq.GetXml()); 
            int nCta=Convert.ToInt32(conBusCtaAho.idcuenta);
            Decimal nMonto=Convert.ToDecimal (txtTotalBloq.Text);

            DataTable tbRegBlo = clsDeposito.CNRegistraBloqueoCuenta(xmlBloq,nCta,nMonto,clsVarGlobal.User.idUsuario,clsVarGlobal.dFecSystem,"",true,0,"");

            if (Convert.ToInt32(tbRegBlo.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegBlo.Rows[0]["cMensage"].ToString(), "Registro Bloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRegBlo.Rows[0]["cMensage"].ToString(), "Registro Bloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //=====================================================
            //--Actualizar el Flag
            //=====================================================
            for (int i = 0; i < dtBloq.Rows.Count; i++)
            {
                dtBloq.Rows[i]["lBloqueado"] = true;
            }

            //=====================================================
            //--Liberar Variables
            //=====================================================
            dtBloq.Dispose();

            btnAgregar.Enabled = false;
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            HabDesabilitaCtr(false);
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;

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
            HabDesabilitaCtr(true);
            btnAgregar.Enabled = true;
            conBusCtaAho.btnBusCliente.Enabled = false;
            this.btnEditar.Enabled=false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            cTipOpe = "A";
            conBusCol.HabilitarControles(false);
            txtNombre.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            cboTipoBloqueo.Focus();
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
        private void CargarCaracterisBloq(int idBloq)
        {
            txtMonBloq.Text = "0.00";
            dtCarac = new clsCNAperturaCta().RetornaTiposCaractBloq(idBloq);
            cboCaractBloq.DataSource = dtCarac;            
            cboCaractBloq.ValueMember = dtCarac.Columns["idCaracteristicaBloq"].ToString();
            cboCaractBloq.DisplayMember = dtCarac.Columns["cDescripcion"].ToString();
            if (dtCarac.Rows.Count>0)
            {
                if ((bool)dtCarac.Rows[cboCaractBloq.SelectedIndex]["lIsReqMonto"])
                {
                    txtMonBloq.Enabled = true;
                    txtMonBloq.Select();
                    txtMonBloq.Focus();
                }
                else
                {
                    txtMonBloq.Enabled = false;
                    txtObservacion.Select();
                    txtObservacion.Focus();
                }
            }
            
        }

        
        #endregion

        private void frmBloqCuenta_Load(object sender, EventArgs e)
        {
            CargarDatosBloqueo(0);
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            HabDesabilitaCtr(false);
            conBusCtaAho.nTipOpe = 12;  //--Ope Cancelación, Igual Lista todas las cuentas vigentes
            conBusCtaAho.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();
        }

        private void cboTipoBloqueo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCaracterisBloq(Convert.ToInt32(cboTipoBloqueo.SelectedValue));
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            limpiarcontroles();
            if (conBusCtaAho.idcuenta>0)
            {
                DatosCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
            cboTipoBloqueo.Focus();
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

        private void CargarDatosBloqueo(int idCta)
        {
            dtBloq.Rows.Clear();
            dtBloq = clsDeposito.CNRetornaBloqueosCuenta(idCta);
            dtgBloqueosCta.DataSource = dtBloq;
            if (dtBloq.Rows.Count>0)
            {
                btnAgregar.Enabled = false;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
                HabDesabilitaCtr(false);
                cTipOpe = "A";
                conBusCtaAho.HabDeshabilitarCtrl(false);
            }
            else
            {
                btnAgregar.Enabled = true;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
                HabDesabilitaCtr(true);
                cTipOpe = "N";
                conBusCtaAho.HabDeshabilitarCtrl(false);
                conBusCol.HabilitarControles(false);
                txtNombre.Enabled = false;
            }
            formatoGrid();
            
            CalcularTotal();
        }

        public void formatoGrid()
        { 
            dtgBloqueosCta.Columns["idCuenta"].Visible = false;
            dtgBloqueosCta.Columns["idBloqueo"].Visible = false;
            dtgBloqueosCta.Columns["lBloqueado"].Visible = false;
            dtgBloqueosCta.Columns["idBloCta"].Visible = false;
            dtgBloqueosCta.Columns["idCaracteristicaBloq"].Visible = false;
            dtgBloqueosCta.Columns["idTipoSolicitante"].Visible = false;
            dtgBloqueosCta.Columns["cNombreSolicitante"].Visible = false;

            dtgBloqueosCta.Columns["cDescripcion"].HeaderText = "Motivo de Bloqueo";
            dtgBloqueosCta.Columns["cDescripcion"].Width = 180;
            dtgBloqueosCta.Columns["cDescriCaract"].HeaderText = "Tipo Bloqueo";
            dtgBloqueosCta.Columns["cDescriCaract"].Width = 180;
            dtgBloqueosCta.Columns["nMonBloqueo"].HeaderText = "Monto";
            dtgBloqueosCta.Columns["nMonBloqueo"].Width = 70;
            dtgBloqueosCta.Columns["dFechaDocBloqueo"].HeaderText = "Fecha Doc";
            dtgBloqueosCta.Columns["dFechaDocBloqueo"].Width = 70;
            dtgBloqueosCta.Columns["cDesMotivo"].HeaderText = "Descripción del Bloqueo";
        }
        
        private void limpiarcontroles()
        {
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            txtMonto.Text = "0.00";
            cboTipoBloqueo.SelectedValue = 0;
            txtMonBloq.Text = "0.00";
            txtTotalBloq.Text = "0.00";
            conBusCol.LimpiarDatos();
            txtNombre.Clear();
            txtObservacion.Text = "";            
        }

        private void HabDesabilitaCtr(bool Val)
        {
            cboTipoBloqueo.Enabled = Val;
            cboCaractBloq.Enabled = Val;
            txtMonBloq.Enabled = Val;
            dtpFecDoc.Enabled = Val;
            rbtInterno.Enabled = Val;
            rbtExterno.Enabled = Val;
            conBusCol.HabilitarControles(Val);
            txtNombre.Enabled = Val;
            txtObservacion.Enabled = Val;
            txtNombre.Enabled = Val;
            btnAgregar.Enabled = Val;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidardetBloq())
            {
                return;
            }

            DataRow dr = dtBloq.NewRow();
            dr["idCuenta"] = Convert.ToInt32(conBusCtaAho.idcuenta);
            dr["idBloqueo"] = Convert.ToInt32(cboTipoBloqueo.SelectedValue);
            dr["cDescripcion"] = cboTipoBloqueo.Text;
            dr["idCaracteristicaBloq"] = Convert.ToInt32(cboCaractBloq.SelectedValue);
            dr["cDescriCaract"] = cboCaractBloq.Text;
            dr["nMonBloqueo"] = Convert.ToDecimal (txtMonBloq.Text);
            dr["dFechaDocBloqueo"] = dtpFecDoc.Value;
            dr["cDesMotivo"] = txtObservacion.Text.ToString().Trim();
            dr["lBloqueado"] = false;
            if (rbtInterno.Checked)
            {
                dr["idTipoSolicitante"] = 1;  //--Interno
                dr["cNombreSolicitante"] = conBusCol.txtNom.Text;
            }
            else
            {
                dr["idTipoSolicitante"] = 2; //--Externo
                dr["cNombreSolicitante"] = txtNombre.Text;
            }
            
            dtBloq.Rows.Add(dr);

            CalcularTotal();

            if (dtBloq.Rows.Count>0)
            {
                btnGrabar.Enabled = true;
            }
            cboTipoBloqueo.SelectedValue = 0;
            txtMonBloq.Text = "0.00";
            conBusCol.LimpiarDatos();            
            rbtInterno.Checked = false;
            rbtInterno.Checked = false;
            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = false;
            txtNombre.Clear();
            txtObservacion.Text = "";
            cboTipoBloqueo.Focus();
        }

        private bool ValidardetBloq()
        {
            if (cboTipoBloqueo.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Tipo de Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoBloqueo.Focus();
                return false;
            }

            if (cboCaractBloq.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar la Característica del Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCaractBloq.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMonBloq.Text))
            {
                MessageBox.Show("Debe de ingresar el Monto del Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonBloq.Select();
                txtMonBloq.Focus();
                return false;
            }

            if (Convert.ToInt32(cboCaractBloq.SelectedValue)==1)
            {
                if (Convert.ToDecimal (txtMonBloq.Text)<=0)
                {
                    MessageBox.Show("El Monto del Bloqueo, debe Ser Mayor a Cero", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMonBloq.Select();
                    txtMonBloq.Focus();
                    return false;
                }
            }

            if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
            {
                 MessageBox.Show("La Fecha de Bloqueo de documento, no puede ser Posterior a la Fecha de Sistema", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecDoc.Focus();
                return false;
            }

            if (rbtInterno.Checked==false && rbtExterno.Checked==false)
            {
                MessageBox.Show("Debe seleccionar el Solicitante...Verificar", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbtInterno.Focus();
                return false;
            }

            if (rbtInterno.Checked)
            {
                if (string.IsNullOrEmpty(conBusCol.txtNom.Text))
                {
                    MessageBox.Show("Debe Buscar al Colaborador Solicitante...Verificar", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCol.txtCod.Focus();
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                     MessageBox.Show("Debe Registrar el Nombre del Solicitante Externo...", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show("Debe de ingresar el Motivo del Bloqueo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObservacion.Select();
                txtObservacion.Focus();
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
            //if (dtBloq.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(dtgBloqueosCta.CurrentRow.Cells["idBloqueo"].Value.ToString()) == 3)
            //    {
            //        if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            //        {
            //            MessageBox.Show("Primero debe Buscar la Cuenta", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            return;
            //        }
            //        DataTable dtValBloq = clsDeposito.CNValidaBloqueoCuentaxGar(Convert.ToInt32(conBusCtaAho.idcuenta));
            //        if (dtValBloq.Rows.Count > 0)
            //        {
            //            MessageBox.Show("No Puede Realizar el Desbloqueo de la Cuenta, Primero Liberar en el Control de Garantías", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            return;
            //        }
            //    }                
            //    dtBloq.Rows.Remove(dtBloq.Rows[dtgBloqueosCta.CurrentRow.Index]);
            //    this.dtgBloqueosCta.Refresh();
            //}
            //CalcularTotal();
        }

        private void cboCaractBloq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bool)dtCarac.Rows[cboCaractBloq.SelectedIndex]["lIsReqMonto"])
            {
                txtMonBloq.Enabled = true;
                txtMonBloq.Select();
                txtMonBloq.Focus();
            }
            else
            {
                txtMonBloq.Enabled = false;
                txtObservacion.Select();
                txtObservacion.Focus();
            }
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


    }
}
