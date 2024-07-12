using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
 
    public partial class frmTransferenciaBancaria : frmBase
    {
        public int pidCtaOri, pidCtaDes, pidMoneda;
 
        clsCNMovimientoBanco objTranBco = new clsCNMovimientoBanco();
        
        #region eventos
        public frmTransferenciaBancaria()
        {
            InitializeComponent();
            habilitarControles(grbCtaOri, false);
            habilitarControles(grbCtaDes, false);            
            btnTransferir.Enabled  = false;
            btnExtorno.Enabled     = false;
        }
        private void btnBusCtaDes_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst buscar = new frmBusquedaCuentaInst();
            buscar.pidAgencia = Convert.ToInt16(cboAgenDes.SelectedValue);
            buscar.ShowDialog();
            if (txtNumeroCtaOri.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar Una cuenta Origen", "Advertencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarDatos(2);
            }
            else if (String.IsNullOrEmpty(buscar.pcNumeroCuenta))
            {
                MessageBox.Show("Debe elegir una Cuenta Destino", "Advertencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarDatos(2);
            }
            else if (buscar.pcNumeroCuenta.ToString() == txtNumeroCtaOri.Text.ToString())
            {
                MessageBox.Show("El Numero De Cuenta Origen y Destino Deben Ser Diferentes", "Advertencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarDatos(2);
            }
            else if (pidMoneda != buscar.pidMoneda)
            {
                MessageBox.Show("El Tipo de Moneda de la Cuenta Destino es Diferente al Tipo de Moneda de la Cuenta Origen", "Advertencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarDatos(2);
            }
            else
            {
                pidCtaDes = buscar.pidCuentaInstitucion;
                cboEntidadDes.CargarEntidades(buscar.pidTipoEntidad);
                cboAgenDes.SelectedValue = buscar.pidAgencia;
                cboTipoEntidadDes.SelectedValue = buscar.pidTipoEntidad;
                cboEntidadDes.SelectedValue = buscar.pidEntidad;
                cboTipoCuentaBcoDes.SelectedValue = buscar.pidTipoCuenta;
                txtNumeroCtaDes.Text = buscar.pcNumeroCuenta;
                txtSaldoDispDes.Text = buscar.pcSaldoDisponible;
                btnTransferir.Enabled = true;
            }
            
        }
        private void btnBusCtaOri_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst buscar = new frmBusquedaCuentaInst();
            buscar.ShowDialog();
            if (string.IsNullOrEmpty(buscar.pcNumeroCuenta))
            {
                return;
            }
           if (buscar.pcNumeroCuenta.ToString() ==txtNumeroCtaDes.Text.ToString() ){
                MessageBox.Show("El Numero De Cuenta Origen y Destino Deben Ser Diferentes","Advertencias",MessageBoxButtons.OK  ,MessageBoxIcon.Exclamation);
                limpiarDatos(2);
                limpiarDatos(1);
                cboMotOperacionBco.Enabled = false;
                txtMontoTrans.Enabled = false;
                txtDescripción.Enabled = false;
                btnTransferir.Enabled = false;
                dtgListaTransferencias.DataSource = null;
            }
           else if (buscar.pidTipoCuenta==2)
           {
               MessageBox.Show("No Se Permite Hacer Transferencias de Cuentas de Plazo Fijo", "Advertencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               limpiarDatos(2);
               limpiarDatos(1);
               cboMotOperacionBco.Enabled = false;
               txtMontoTrans.Enabled = false;
               txtDescripción.Enabled = false;
               btnTransferir.Enabled = false;
               dtgListaTransferencias.DataSource = null;
           }
           else
            {
                pidMoneda = buscar.pidMoneda;
                cboTipoEntidadOri.SelectedValue = buscar.pidTipoEntidad;
                cboEntidadOri.CargarEntidades(buscar.pidTipoEntidad);
                cboAgenOri.SelectedValue = buscar.pidAgencia;
                cboEntidadOri.SelectedValue = buscar.pidEntidad;
                cboTipoCuentaBcoOri.SelectedValue = buscar.pidTipoCuenta;
                cboMoneda.SelectedValue = buscar.pidMoneda;
                txtNumeroCtaOri.Text = buscar.pcNumeroCuenta;
                txtSaldoDispOri.Text = buscar.pcSaldoDisponible;
                pidCtaOri = buscar.pidCuentaInstitucion;
                
                cboMotOperacionBco.Enabled = true;
                txtMontoTrans.Enabled = true;
                txtDescripción.Enabled = true;
                dtpfechaOperac.Enabled = true;

                ListarTranferencias();
            }
           cboAgenDes.Enabled = true;
        }
        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {
                if (MessageBox.Show("Esta Seguro de Realizar la Transferencias?", "Confrimar Transferencia...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int idMotOpeBanco = 0, idMoneda = 0;
                    decimal nMontoOpera;
                    DateTime dfechaOpe;
                    string cDescripcion, xmlTransferencia;
                    DataTable dtTransBco = new DataTable();
                    idMotOpeBanco = Convert.ToInt32(cboMotOperacionBco.SelectedValue);
                    idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                    nMontoOpera = Convert.ToDecimal(txtMontoTrans.Text);
                    cDescripcion = txtDescripción.Text;
                    dfechaOpe = dtpfechaOperac.Value;
                    xmlTransferencia = objTranBco.convertTransferenciaXml(pidCtaOri, pidCtaDes, idMotOpeBanco, idMoneda, nMontoOpera, cDescripcion, dfechaOpe);
                    xmlTransferencia = clsCNFormatoXML.EncodingXML(xmlTransferencia);

                    //=================  Registro Inicio Rastreo ===================================
                    this.registrarRastreo(clsVarGlobal.User.idUsuario, pidCtaOri, "Inicio - Transferencia Bancaria", btnTransferir);
                    //==============================================================================

                    dtTransBco = objTranBco.grabarTransferencia(xmlTransferencia, dfechaOpe, clsVarGlobal.User.idUsuario, Convert.ToInt32(cboAgenDes.SelectedValue), Convert.ToInt32(cboAgenOri.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));

                    //=================   Registro Fin Rastreo    ================================
                    this.registrarRastreo(clsVarGlobal.User.idUsuario, pidCtaDes, "Fin - Transferencia Bancaria", btnTransferir);
                    //============================================================================

                    MessageBox.Show("Transferencia Exitosa...", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarTranferencias();
                    if (dtTransBco.Rows.Count > 0)
                    {
                        DataRow rows = dtTransBco.Rows[0];
                        txtSaldoDispOri.Text = rows["1"].ToString();

                        DataRow rows1 = dtTransBco.Rows[0];
                        txtSaldoDispDes.Text = rows1["2"].ToString();
                    }
                    txtMontoTrans.Text = "";
                    cboMotOperacionBco.SelectedValue = -1;
                    txtDescripción.Text = "";
                }
            }
        }
        private void frmTransferenciaBancaria_Load(object sender, EventArgs e)
        {
            limpiarDatos(1);
            limpiarDatos(2);
            cboMotOperacionBco.cargarMotivoOperacion(9);
            dtpfechaOperac.Value = clsVarGlobal.dFecSystem;
            
        }
        #endregion
       
    
        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (dtgListaTransferencias.RowCount > 0)
            {
                if (MessageBox.Show("¿Esta Seguro de Extornar la Transferencia?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    int idTrasferencia, idMovOri, idMovDes;
                                    
                    idMovOri= Convert.ToInt32(dtgListaTransferencias.Rows[dtgListaTransferencias.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    idMovDes= Convert.ToInt32(dtgListaTransferencias.Rows[dtgListaTransferencias.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                    idTrasferencia = Convert.ToInt32(dtgListaTransferencias.Rows[dtgListaTransferencias.SelectedCells[0].RowIndex].Cells[2].Value.ToString());    
                    DataTable dtSaldos = new DataTable();

                    //=================  Registro Inicio Rastreo ===================================
                    this.registrarRastreo(clsVarGlobal.User.idUsuario, idMovOri, "Inicio - Extorno Transferencia Bancaria", btnExtorno);
                    //==============================================================================
                    
                    dtSaldos = objTranBco.ExtornarTransferenciaBancos(idTrasferencia,idMovOri,idMovDes);

                    //=================   Registro Fin Rastreo    ================================
                    this.registrarRastreo(clsVarGlobal.User.idUsuario, idMovDes, "Fin - Extorno Transferencia Bancaria", btnExtorno);
                    //============================================================================

                    
                    MessageBox.Show("la Transferencias Fue Extornada Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataRow row = dtSaldos.Rows[0];
                    txtSaldoDispOri.Text = row["nSaldoDisOri"].ToString();
                    if (pidCtaDes.ToString() == row["idCuentaInsDes"].ToString())
                    {
                        txtSaldoDispDes.Text = row["nSaldoDisDes"].ToString();
                    }
                    ListarTranferencias();
                }
            }
        }


        #region Metodos
        private void limpiarDatos(int nOpcion)
        {
            switch (nOpcion)
            {
                case 2://Destino
                    cboAgenDes.SelectedValue=-1;            
                    cboTipoCuentaBcoDes.SelectedValue = -1;            
                    cboTipoEntidadDes.SelectedValue = -1;            
                    cboEntidadDes.SelectedValue = -1;                   
                    txtNumeroCtaDes.Text = "";            
                    txtSaldoDispDes.Text = "";
                    dtpfechaOperac.Value = clsVarGlobal.dFecSystem;
                    break;
                case 1://Origen
                    cboAgenOri.SelectedValue = -1;
                    cboTipoCuentaBcoOri.SelectedValue = -1;
                    cboTipoEntidadOri.SelectedValue = -1;
                    cboEntidadOri.SelectedValue = -1;
                    cboMotOperacionBco.SelectedValue = -1;
                    cboMoneda.SelectedValue = -1;
                    txtNumeroCtaOri.Text = "";
                    txtSaldoDispOri.Text = "";
                    break;
            }
        }      
        private bool validarRegistro()
        {
            bool validar=true ;
            if (Convert.ToDecimal(txtSaldoDispOri.Text) <= 0)
            {
                MessageBox.Show("La Cuenta no Tiene Saldo Disponible"+"\n"+" Para Realizar la Transferencia", "Registro de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validar = false;
            }
            else if (txtMontoTrans.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar Monto de Transferencias Correcto","Registro de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                validar = false;
            }
            else if (Convert.ToDecimal(txtSaldoDispOri.Text) < Convert.ToDecimal(txtMontoTrans.Text.Trim()))
            {
                MessageBox.Show("El Monto a Transferir Supera al Saldo Disponible", "Registro de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validar = false;
            }
            else if (Convert.ToDecimal(txtMontoTrans.Text)<=0)
            {
                MessageBox.Show("Debe Ingresar Monto de Transferencias Mayor a Cero", "Registro de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validar = false;
            }

            else if (txtDescripción.Text.Trim()=="")
            {
                MessageBox.Show("Debe Ingresar una Descripción Correcta","Registro de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                validar = false;
            }
            else if (cboMotOperacionBco.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione Motivo de  Operación", "Registro de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                validar = false;
            }
            return validar;
        }
        private void ListarTranferencias()
        {
            int idCuentaOrigen = pidCtaOri;
            string cNroCuentaOrigen=txtNumeroCtaOri.Text;
            dtgListaTransferencias.DataSource = objTranBco.ListarTransferencia(idCuentaOrigen,cNroCuentaOrigen);
            this.dtgListaTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            
            
            dtgListaTransferencias.Columns[0].Visible = false;
            dtgListaTransferencias.Columns[1].Visible = false;
            dtgListaTransferencias.Columns[2].Width = 50;
            dtgListaTransferencias.Columns[3].Width = 150;
            dtgListaTransferencias.Columns[4].Width = 150;
            dtgListaTransferencias.Columns[5].Width = 130;
            dtgListaTransferencias.Columns[6].Width = 130;
            dtgListaTransferencias.Columns[7].Width = 130;
            dtgListaTransferencias.Columns[8].Width = 150;
            dtgListaTransferencias.Columns[9].Width = 80;
            
            //dtgListaTransferencias.Columns[2].Visible = false;
            //dtgListaTransferencias.Columns[3].Visible = false;
            //dtgListaTransferencias.Columns[4].Visible = false;
            //dtgListaTransferencias.Columns[5].Visible = false;
        }
        #endregion

        private void dtgListaTransferencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTransferencias_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnExtorno.Enabled = true;
        }

        private void txtDescripción_TextChanged(object sender, EventArgs e)
        {
            txtDescripción.CharacterCasing = CharacterCasing.Upper;
        }
        
    }
}

