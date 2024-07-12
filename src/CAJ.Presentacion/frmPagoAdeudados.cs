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
using EntityLayer;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmPagoAdeudados : frmBase
    {
        DataTable dtPlanPagos;
        DataTable dtCanAnt;
        clsCNControlOpe Adeudo = new clsCNControlOpe();        
        DataTable dtPagoPlanAdeuda = new DataTable();
        public int idDesAnterior;
        private int nMaxNroCuotaPagada;

        public frmPagoAdeudados()
        {
            InitializeComponent();
        }

        private void frmPagoAdeudados_Load(object sender, EventArgs e)
        {
            cboTipoEntidad.cargarTipoDeEntidad("1");
            DatoInicial();
            nMaxNroCuotaPagada = 0;
            Habilita(false);
            btnCalcular.Visible = false;
            lblTotPagar.Visible = false;
            txtTotalAPagar.Visible = false;
            lblIC.Visible = false;
            lblComision.Visible = false;
            txtTotComPagar.Visible = false;
                        
            limpiarDatosIniciales();
        }

        private Boolean CargaDatos()
        {
            
            int CodAde = 0;
            
            if (string.IsNullOrEmpty(this.txtCodAdeudo.Text))
            {
              
                CodAde = 0;
                limpiarDatosIniciales();
                limpiarMontos();
                return false;
            }
            
            CodAde = Convert.ToInt32(this.txtCodAdeudo.Text);

            if (CodAde==0)
            {
                MessageBox.Show("Codigo de Adeudado debe ser diferente de CERO", "Pago Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarDatosIniciales();
                limpiarMontos();
                return false;
            }

            DataTable dtAdeudo = Adeudo.CNConsultaAdeudado(CodAde,"%","%","%","%");

            if (dtAdeudo.Rows.Count==0)
            {
                MessageBox.Show("No existe Adeudado con el codigo ingresado", "Pago Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarDatosIniciales();
                limpiarMontos();
                return false;
            }

            if (Convert.ToInt32(dtAdeudo.Rows[0]["idEstado"])==2)
            {
                MessageBox.Show("El Adeudado esta CANCELADO", "Pago Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarDatosIniciales();
                limpiarMontos();
                return false;
            }            
            ListarDesembolso(CodAde);            
            this.cboTipoEntidad.SelectedValue = Convert.ToString(dtAdeudo.Rows[0]["idTipoEntidad"]);
            this.cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(this.cboTipoEntidad.SelectedValue),"1");
            this.cboEntidad.SelectedValue = Convert.ToString(dtAdeudo.Rows[0]["idEntidad"]);
            this.cboMoneda.SelectedValue=  Convert.ToInt32(dtAdeudo.Rows[0]["idMoneda"]);
            //this.txtNroPagre.Text = dtAdeudo.Rows[0]["cNroPagre"].ToString();
            this.dtgPlanPagos.Enabled = true;            
            this.dtgPlanPagos.ReadOnly = true;
            this.txtNroCuota.Enabled =true ;
            cboMoneda.Enabled = false;
            cboFormaPago.Enabled = false ;
            cboTipoDocumento.Enabled = true ;
            cboPagare.Enabled = true ;
            txtNroDocumento.ReadOnly = false;
            txtNroCuota.ReadOnly = false;
            chcCancelAnticipada.Enabled =true;            
            txtNroCuota.Text = dtPlanPagos.Compute("Min(nNroCuota)", "chk='False'").ToString();
            txtCodAdeudo.Enabled = false;
            return true;
        }

        void limpiarDatosIniciales()
        {
    
            cboPagare.DataSource = null;
            dtgPlanPagos.DataSource = null;
            cboTipoEntidad.SelectedValue = -1;
            cboEntidad.SelectedValue = -1;
            txtNroCuota.Clear();
            cboFormaPago.SelectedValue = 1;
            cboTipoDocumento.SelectedValue = -1;
            txtNroDocumento.Clear();
            chcCancelAnticipada.Checked = false;
            
            cboFormaPago.Enabled = false;
            cboTipoDocumento.Enabled = false;
            cboPagare.Enabled = false;
            txtNroDocumento.ReadOnly = true;
            txtNroCuota.ReadOnly = true;
            chcCancelAnticipada.Enabled = false;
            
        }

        void ListarDesembolso(int codigoAdeudado)
        {
            cboPagare.SelectedIndexChanged -= new EventHandler(cboDesembolso_SelectedIndexChanged);
            //listar Desembolos de adeudado sin pagar
            DataTable dtDesembolso = Adeudo.ListarDesembolsoAdeudado(codigoAdeudado,"1");
            cboPagare.DataSource = dtDesembolso;
            cboPagare.ValueMember = "idDesembolso";
            cboPagare.DisplayMember = "cNroPagre";

            cboPagare.SelectedIndexChanged += new EventHandler(cboDesembolso_SelectedIndexChanged);

            ListarPlanPagosAdeudado(Convert.ToInt32(cboPagare.SelectedValue));

        } 
    
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dtgBase1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private Boolean valida()
        {
            if (String.IsNullOrEmpty(cboTipoDocumento.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Documento de Pago", "Pago de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtNroDocumento.Text))
            {
                MessageBox.Show("Ingrese Nro de Documento de Pago", "Pago de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (String.IsNullOrEmpty(this.txtTotal.Text) || Convert.ToDecimal (this.txtTotal.Text)<=0)
            {
                MessageBox.Show("Ingrese el Total a Pagar", "Pago de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTotal.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtComision.Text.ToString()))
            {
                txtComision.Text = "0.00";
            }           
            if (string.IsNullOrEmpty(this.txtOtros.Text))
            {
                this.txtOtros.Text = "0.00";
            }
            if (string.IsNullOrEmpty(this.txtMora.Text))
            {
                this.txtMora.Text = "0.00";
            }
            
            return true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (!valida())
            {
                return;
            }

            int idAdeudo = Convert.ToInt32(this.txtCodAdeudo.Text);
            if (chcCancelAnticipada.Checked)
            {
                dtPagoPlanAdeuda = dtCanAnt;
            }
            else
            {
                msg = "Se Pago con éxito el Adeudado Nro. ";
                foreach (DataRow nrow in dtPagoPlanAdeuda.Rows)
                {
                    nrow["nCapitalPagado"] = txtCapital.Text;
                    nrow["nInteresPagado"] = txtInteres.Text;
                    nrow["nComisionPagado"] = txtComision.Text;
                    nrow["nOtrosPagado"] = txtOtros.Text;
                    nrow["nMoraPagado"] = txtMora.Text;
                    nrow["dFechaPago"] = clsVarGlobal.dFecSystem.Date;
                    nrow["idFromaPagoPlaAde"] = Convert.ToInt32(cboFormaPago.SelectedValue);
                    nrow["idDocPagoPlaAde"] = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                    nrow["cNroDocumento"] = txtNroDocumento.Text;
                }
            }

            DataSet ds = new DataSet("dsPagoAdeudado");
            ds.Tables.Add(dtPagoPlanAdeuda);
            String XmlPagoPlanAde = ds.GetXml();
            XmlPagoPlanAde = clsCNFormatoXML.EncodingXML(XmlPagoPlanAde);

            int ncancelacion = (chcCancelAnticipada.Checked) ? 1 : 0;
            ncancelacion = (lbUltCuota.Visible == true) ? 1 : ncancelacion;
            idDesAnterior =Convert.ToInt32(cboPagare.SelectedValue);
            

            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(Convert.ToInt32(txtCodAdeudo.Text), 0, "Inicio - Pago de Adeudados", btnGrabar1);
            //==============================================================================

            string cResul = Adeudo.GuardaPagoAdeudado(XmlPagoPlanAde, ncancelacion, ref msg, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario);
            
            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(Convert.ToInt32(txtCodAdeudo.Text), 0, "Fin - Pago de Adeudados", btnGrabar1);
            //============================================================================
            
            if (ncancelacion == 1)
            {
                MessageBox.Show("Se Cancelo el Adeudado Nº " + txtCodAdeudo.Text, "Pago Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocumento.Clear();
                txtCodAdeudo.Clear();
                txtCodAdeudo.Focus();

            }else{
                MessageBox.Show("Pago Satisfactorio de la cuota Nº " + cResul + " del Adeudado Nº " + txtCodAdeudo.Text, "Pago Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroDocumento.Clear();
            }
            this.btnGrabar1.Enabled = false;
            dtgPlanPagos.DataSource = "";
            CargaDatos();
            cboPagare.SelectedValue = idDesAnterior;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            dtgPlanPagos.DataSource = "";
        }

        void DatoInicial()
        {
            this.txtCodAdeudo.Text = "0";        

            // lista las formas de pago.
            DataTable dtFormaPago = new DataTable();
            dtFormaPago = Adeudo.listarFormaPagoAdeudado();
            cboFormaPago.DataSource = dtFormaPago;
            cboFormaPago.DisplayMember = "cDescripcion";
            cboFormaPago.ValueMember = "idFromaPagoPlaAde";

            //lista los tipos de Documento
            DataTable dtTipoDocumento = new DataTable();
            dtTipoDocumento = Adeudo.listarTipoDocumentoAdeudado();
            cboTipoDocumento.DataSource = dtTipoDocumento;
            cboTipoDocumento.DisplayMember = "cDescripcion";
            cboTipoDocumento.ValueMember = "idDocPagoPlaAde";
        }

        void Habilita(Boolean lEst)
        {
            
            this.dtgPlanPagos.Enabled = lEst;
            this.btnGrabar1.Enabled = lEst;
            this.btnExtorno1.Enabled = lEst;
        }
        
        private void txtCodAdeudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                if (!CargaDatos())
                {
                }
                
            }

        }

        void ListarPlanPagosAdeudado(int codigoDesemAdeudado)
        {
            dtgPlanPagos.Enabled = true;
            // Listar destino de Producto credito           
           dtPlanPagos = Adeudo.listarPlanPagoAdeudado(codigoDesemAdeudado, "%");
           dtgPlanPagos.DataSource = dtPlanPagos;
           
           formatoPlanPagos();
            
        }

        void formatoPlanPagos()
        {
            foreach (DataGridViewColumn col in dtgPlanPagos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
           
            dtgPlanPagos.Columns["idPlanPagosAde"].Visible = false;
            dtgPlanPagos.Columns["idDesembolso"].Visible = false;
            dtgPlanPagos.Columns["idFromaPagoPlaAde"].Visible = false;
            dtgPlanPagos.Columns["idDocPagoPlaAde"].Visible = false;
            dtgPlanPagos.Columns["cNroDocumento"].Visible = false;
            dtgPlanPagos.Columns["idEstPlaPago"].Visible = false;
            dtgPlanPagos.Columns["chk"].Visible = false;
            dtgPlanPagos.Columns["cTipoCuota"].Visible = false;
            dtgPlanPagos.Columns["idAdeudado"].Visible = false;
            dtgPlanPagos.Columns["idTipoPlazo"].Visible = false;
            dtgPlanPagos.Columns["cTipPlaCorto"].Visible = false;
            dtgPlanPagos.Columns["nNroCuota"].HeaderText = "Nº Cuota";            
            dtgPlanPagos.Columns["dFechaVenc"].HeaderText = "Fecha de Vencimiento";
            dtgPlanPagos.Columns["dFechaPago"].HeaderText = "Fecha de Pago";
            dtgPlanPagos.Columns["nCapital"].HeaderText = "Capital Pactado";
            dtgPlanPagos.Columns["nCapitalPagado"].HeaderText = "Capital Pagado";
            dtgPlanPagos.Columns["nInteres"].HeaderText = "Interes Pactado";
            dtgPlanPagos.Columns["nInteresPagado"].HeaderText = "Interes Pagado";
            dtgPlanPagos.Columns["nComision"].HeaderText = "Comision Pactado";
            dtgPlanPagos.Columns["nComisionPagado"].HeaderText = "Comision Pagado";
            dtgPlanPagos.Columns["nOtros"].HeaderText = "Otros Pactado";
            dtgPlanPagos.Columns["nOtrosPagado"].HeaderText = "Otros Pagado";
            dtgPlanPagos.Columns["nMoraPagado"].HeaderText = "Mora Pagado";
            
            dtgPlanPagos.Columns["nNroCuota"].Width = 40;
            dtgPlanPagos.Columns["dFechaVenc"].Width = 71;            
            dtgPlanPagos.Columns["dFechaPago"].Width = 71;
            dtgPlanPagos.Columns["nCapital"].Width = 73;
            dtgPlanPagos.Columns["nCapitalPagado"].Width = 73;
            dtgPlanPagos.Columns["nInteres"].Width = 73;
            dtgPlanPagos.Columns["nInteresPagado"].Width = 73;
            dtgPlanPagos.Columns["nComision"].Width = 52;
            dtgPlanPagos.Columns["nComisionPagado"].Width = 52;
            dtgPlanPagos.Columns["nOtros"].Width = 50;
            dtgPlanPagos.Columns["nOtrosPagado"].Width = 50;
            dtgPlanPagos.Columns["Estado"].Width = 60;
            dtgPlanPagos.Columns["nMoraPagado"].Width=70;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            
            frmBuscarAdeudado buscarAdeudado = new frmBuscarAdeudado();
            buscarAdeudado.ShowDialog();
            DataTable dtNuevo= buscarAdeudado.dtExternoAdeudado;
            if (dtNuevo!=null)
            {
                txtCodAdeudo.Text = dtNuevo.Rows[0]["idAdeudado"].ToString();
                CargaDatos();                
            }
            
        }

        private void grbBase3_Enter(object sender, EventArgs e)
        {

        }

        private void txtNroCuota_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNroCuota.Text))
            {
                limpiarMontos();
                btnGrabar1.Enabled = false;
                return;
            }
            if (Convert.ToInt32(txtNroCuota.Text)<=0)
            {
                limpiarMontos();
                btnGrabar1.Enabled = false;
                MessageBox.Show("Nro Cuota Invalido","Advertencia:Pago De Couta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            if (Convert.ToInt32(dtPlanPagos.Compute("Max(nNroCuota)", "").ToString()) >= Convert.ToInt32(txtNroCuota.Text))
            {
                if (dtPlanPagos.Compute("Max(nNroCuota)", "").ToString() == txtNroCuota.Text)
                {
                    lbUltCuota.Visible = true;
                }
                else
                {
                    lbUltCuota.Visible = false;
                }

                

                DataTable dt2 = dtPlanPagos.Select("nNroCuota=" + txtNroCuota.Text).CopyToDataTable();
                dtPagoPlanAdeuda = dt2;

                txtCapital.Text = dt2.Rows[0]["nCapital"].ToString();
                txtInteres.Text = dt2.Rows[0]["nInteres"].ToString();
                txtComision.Text = dt2.Rows[0]["nComision"].ToString();
                txtOtros.Text = dt2.Rows[0]["nOtros"].ToString();
                txtMora.Text = "0.00";
                
                this.dtgPlanPagos.Rows[Convert.ToInt32(txtNroCuota.Text) - 1-nMaxNroCuotaPagada].Selected = true;
                this.dtgPlanPagos.CurrentCell = this.dtgPlanPagos.Rows[Convert.ToInt32(txtNroCuota.Text) - 1-nMaxNroCuotaPagada].Cells["nNroCuota"];
                
                if (dtgPlanPagos.Rows[dtgPlanPagos.SelectedCells[0].RowIndex].Cells["chk"].Value.ToString() == "True")
                {
                    btnGrabar1.Enabled = false;
                    btnExtorno1.Enabled = true;
                }
                else
                {
                    btnGrabar1.Enabled = true;
                    btnExtorno1.Enabled = false;
                }

                txtOtros.Enabled = true;
                txtMora.Enabled = true;
                txtCapital.Enabled = true;
                txtInteres.Enabled = true;
                txtComision.Enabled = true;
                txtOtros.ReadOnly= false ;
                txtMora.ReadOnly = false;
                //btnGrabar1.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existe Nro de Cuota "+ txtNroCuota.Text ,"Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                limpiarMontos();
                txtNroCuota.Text = dtPlanPagos.Compute("Min(nNroCuota)", "chk='False'").ToString();
            }
            

        }

        private void limpiarMontos()
        {
            txtCapital.Clear();
            txtInteres.Clear();
            txtComision.Clear();
            txtOtros.Clear();
            txtMora.Clear();
            txtNroCuota.Clear();
            txtTotal.Text = "0.00";
            lbUltCuota.Visible = false;
        }

       

       

        private void txtCodAdeudo_TextChanged(object sender, EventArgs e)
        {
            limpiarDatosIniciales();
            limpiarMontos();
        }

        private void chcCancelAnticipada_CheckedChanged(object sender, EventArgs e)
        {
            idDesAnterior = Convert.ToInt32(cboPagare.SelectedValue);

            if (chcCancelAnticipada.Checked)
            {
               
                btnCalcular.Visible = true;
                
                txtComision.ReadOnly = false;
                
                txtTotal.ReadOnly = false;
                txtTotal.Enabled = true;
                txtOtros.ReadOnly = true;
                txtMora.ReadOnly = true;
                limpiarMontos();
                txtComision.Focus();
                txtNroCuota.ReadOnly = true;
            
                var dv = dtPlanPagos.DefaultView;
                dv.RowFilter = "idEstPlaPago='1'";
                var newDT = dv.ToTable();
                dtCanAnt = newDT;
                dtgPlanPagos.DataSource = null;

                dtgPlanPagos.SelectionChanged -= new EventHandler(
          dtgPlanPagos_SelectionChanged);
                dtgPlanPagos.DataSource = dtCanAnt;
                dtgPlanPagos.SelectionChanged += new EventHandler(
          dtgPlanPagos_SelectionChanged);
                formatoPlanPagos();
                lblTotPagar.Visible = true;
                txtTotalAPagar.Visible = true;
                lblIC.Visible = true;
                lblComision.Visible = true;
                txtTotComPagar.Visible = true;
                if (dtCanAnt.Rows.Count>=1)
                {
                    txtComision.Text = "0.00";
                    txtTotalAPagar.Text = (Convert.ToDecimal(dtCanAnt.Compute("sum(nCapital)", "")) + Convert.ToDecimal(dtCanAnt.Compute("sum(nInteres)", ""))).ToString();
                    txtTotComPagar.Text = (Convert.ToDecimal(dtCanAnt.Compute("sum(nComision)", ""))).ToString();
                }
                txtNroCuota.TextChanged -= new EventHandler(txtNroCuota_TextChanged);
                txtNroCuota.Text = dtCanAnt.Compute("Max(nNroCuota)","").ToString();
                nMaxNroCuotaPagada = Convert.ToInt32(dtCanAnt.Compute("Min(nNroCuota)", "") )- 1;
                txtNroCuota.TextChanged += new EventHandler(txtNroCuota_TextChanged);
                this.dtgPlanPagos.Rows[Convert.ToInt32(txtNroCuota.Text) - nMaxNroCuotaPagada-1].Selected = true;
                this.dtgPlanPagos.CurrentCell = this.dtgPlanPagos.Rows[Convert.ToInt32(txtNroCuota.Text) - nMaxNroCuotaPagada-1].Cells["nNroCuota"];
                this.btnGrabar1.Enabled = false;   
            }
            else

            {   
                nMaxNroCuotaPagada = 0;
                btnCalcular.Visible = false;
                txtTotal.ReadOnly = true;
                txtTotal.Enabled = false ;
                txtOtros.ReadOnly = false;
                txtMora.ReadOnly = false;
                txtComision.ReadOnly = true;
                CargaDatos();
              
                txtNroCuota.ReadOnly = false ;
                lblTotPagar.Visible = false;
                txtTotalAPagar.Visible = false;
                lblIC.Visible = false;
                lblComision.Visible = false;
                txtTotComPagar.Visible = false;
                nMaxNroCuotaPagada = 0;
            }
            cboPagare.SelectedValue = idDesAnterior;

        }

        private void dtgPlanPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoDocumento.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe Seleccionar Tipo de Documento de Pago","Alerta: Cancelación de Adeudado",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtNroDocumento.Text))
            {
                MessageBox.Show("Debe Ingresar Nro de Documento de Pago", "Alerta: Cancelación de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtComision.Text))
            {
                MessageBox.Show("Debe Ingresar Correctamente la comision ", "Alerta: Cancelación de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTotal.Text) || Convert.ToDecimal(txtTotal.Text)<=0)
            {
                MessageBox.Show("Debe Ingresar Correctamente el Total a Pagar ", "Alerta: Cancelación de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }          
            decimal saldo,comision;
            saldo = Convert.ToDecimal(txtTotal.Text);
            comision = Convert.ToDecimal(txtComision.Text);

            if (saldo>Convert.ToDecimal(txtTotalAPagar.Text))
            {
                MessageBox.Show("El Monto a pagar ingresado supera el monto total maximo a pagar. ", "Alerta: Cancelación de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotal.Text = txtTotalAPagar.Text;
            }
            if (comision > Convert.ToDecimal(txtTotComPagar.Text))
            {
                MessageBox.Show("Las comisiones ingresadas superan el monto de comisiones maximo a pagar. ", "Alerta: Cancelación de Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComision.Text = txtTotComPagar.Text;
            }

            
            var dv = dtPlanPagos.DefaultView;
            dv.RowFilter = "idEstPlaPago='1'";
            var newDT = dv.ToTable();
            dtCanAnt = newDT;
            dtgPlanPagos.DataSource = null;
            dtgPlanPagos.DataSource = dtCanAnt;
            formatoPlanPagos();

            
            foreach (DataRow nRow in dtCanAnt.Rows)
            {
                nRow["dFechaPago"]=clsVarGlobal.dFecSystem.Date;

                if (saldo >= Convert.ToDecimal(nRow["nCapital"]))
                {
                    nRow["nCapitalPagado"] = Convert.ToDecimal(nRow["nCapital"]);
                    saldo = saldo - Convert.ToDecimal(nRow["nCapital"]);
                }
                else
                {
                    nRow["nCapitalPagado"] = saldo;
                    saldo =Convert.ToDecimal("0.00");

                }

            }
            
                foreach (DataRow nRow in dtCanAnt.Rows)
                {
                    if (saldo >= Convert.ToDecimal(nRow["nInteres"]))
                    {
                        nRow["nInteresPagado"] = Convert.ToDecimal(nRow["nInteres"]);
                        saldo = saldo - Convert.ToDecimal(nRow["nInteres"]);
                    }
                    else
                    {
                        nRow["nInteresPagado"] = saldo;
                        saldo = Convert.ToDecimal("0.00");                         
                    }
                }                
            
            foreach (DataRow nRow in dtCanAnt.Rows)
            {
                nRow["nOtrosPagado"] = Convert.ToDecimal("0.00");
                nRow["nMoraPagado"] = Convert.ToDecimal("0.00");
                nRow["idFromaPagoPlaAde"] = Convert.ToInt32(cboFormaPago.SelectedValue);
                nRow["idDocPagoPlaAde"] = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                nRow["cNroDocumento"] = txtNroDocumento.Text;
                
                    if (comision >= Convert.ToDecimal(nRow["nComision"]))
                    {
                        nRow["nComisionPagado"] = Convert.ToDecimal(nRow["nComision"]);
                        comision = comision - Convert.ToDecimal(nRow["nComision"]);
                    }
                    else
                    {
                        nRow["nComisionPagado"] = comision;
                        comision = Convert.ToDecimal("0.00");
                    }                
            }
            btnGrabar1.Enabled = true;
        }

        private void cboDesembolso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarPlanPagosAdeudado(Convert.ToInt32(cboPagare.SelectedValue));
            txtNroCuota.Text = dtPlanPagos.Compute("Min(nNroCuota)", "chk='False'").ToString();
            txtNroCuota_TextChanged(sender, e);
        }

        private void btnExtorno1_Click(object sender, EventArgs e)
        {
            string cNroCuota,idAdeudado,cDesembolso;
            cDesembolso=cboPagare.SelectedValue.ToString();
            idAdeudado=txtCodAdeudo.Text;
            cNroCuota=txtNroCuota.Text;
            string msg="";
            
            if ((dtPlanPagos.Compute("Max(nNroCuota)", "chk='True'").ToString() == cNroCuota))
            {
                if (MessageBox.Show("¿Esta seguro de Extornar la cuota Nº " + cNroCuota + "?", "Pago Adeudado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //=================  Registro Inicio Rastreo ===================================
                    this.registrarRastreo(Convert.ToInt32(idAdeudado), 0, "Inicio - Extorno Pago de Adeudados", btnExtorno1);
                    //==============================================================================
                    
                    string cResul = Adeudo.ExtornarPagoAdeudado(Convert.ToInt32(idAdeudado), Convert.ToInt32(cDesembolso), Convert.ToInt32(cNroCuota), ref msg);
                    
                    //=================   Registro Fin Rastreo    ================================
                    this.registrarRastreo(Convert.ToInt32(idAdeudado), 0, "Fin - Extorno Pago de Adeudados", btnExtorno1);
                    //============================================================================

                    MessageBox.Show("La cuota Nº " + cResul + " fue extornado Satisfactoriamente", "Pago Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
                dtgPlanPagos.DataSource = "";
                CargaDatos();
                cboPagare.SelectedValue = idDesAnterior;
            }
            else
            {
                MessageBox.Show("La cuota seleccionada no coincide con el ultimo Pago", "Pago Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgPlanPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                metodoAsignacionDatos();
            }
            catch (Exception ex)
            {
                
                
            }
           // txtNroCuota_TextChanged(sender, e);    
            
        }

        private void dtgPlanPagos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
             
                metodoAsignacionDatos();
            }
            catch (Exception ex)
            {


            }
            //txtNroCuota_TextChanged(sender, e);
        }

        private void metodoAsignacionDatos()
        {
            int nNroCuotaVig = Convert.ToInt32(dtPlanPagos.Compute("Min(nNroCuota)", "chk='False'"));
            int nNroCuotaEleg = Convert.ToInt32(dtgPlanPagos.Rows[dtgPlanPagos.SelectedCells[0].RowIndex].Cells["nNroCuota"].Value);

            if (nNroCuotaEleg > nNroCuotaVig && !chcCancelAnticipada.Checked)
            {
                MessageBox.Show("Debe cancelar la primera cuota vigente", "Pago Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCuota.Text = nNroCuotaVig.ToString();
                this.dtgPlanPagos.Rows[Convert.ToInt32(txtNroCuota.Text) - 1 - nMaxNroCuotaPagada].Selected = true;
                DataTable dt2 = dtPlanPagos.Select("nNroCuota=" + txtNroCuota.Text).CopyToDataTable();
                dtPagoPlanAdeuda = dt2;

                txtCapital.Text = dt2.Rows[0]["nCapital"].ToString();
                txtInteres.Text = dt2.Rows[0]["nInteres"].ToString();
                txtComision.Text = dt2.Rows[0]["nComision"].ToString();
                txtOtros.Text = dt2.Rows[0]["nOtros"].ToString();
                txtMora.Text = "0.00";
                return;
            }

            if (dtgPlanPagos.Rows[dtgPlanPagos.SelectedCells[0].RowIndex].Cells["chk"].Value.ToString() == "True")
            {
                btnGrabar1.Enabled = false;
                btnExtorno1.Enabled = true;
                txtNroDocumento.Enabled = false;
                txtNroCuota.Enabled = false;
                txtMora.Enabled = false;
                txtOtros.Enabled = false;
                cboTipoDocumento.Enabled = false;
            }
            else
            {
                btnGrabar1.Enabled = true;
                btnExtorno1.Enabled = false;
                txtNroDocumento.Enabled = true;
                txtNroCuota.Enabled = true;
                txtMora.Enabled = true;
                txtOtros.Enabled = true;
                cboTipoDocumento.Enabled = true;
            }
            txtNroCuota.TextChanged -= new EventHandler(txtNroCuota_TextChanged);
            txtNroCuota.Text = dtgPlanPagos.Rows[dtgPlanPagos.SelectedCells[0].RowIndex].Cells["nNroCuota"].Value.ToString();
            txtNroCuota.TextChanged += new EventHandler(txtNroCuota_TextChanged);
            
            if (chcCancelAnticipada.Checked == false)
            {
                DataTable dt2 = dtPlanPagos.Select("nNroCuota=" + txtNroCuota.Text).CopyToDataTable();
                dtPagoPlanAdeuda = dt2;

                txtCapital.Text = dt2.Rows[0]["nCapital"].ToString();
                txtInteres.Text = dt2.Rows[0]["nInteres"].ToString();
                txtComision.Text = dt2.Rows[0]["nComision"].ToString();
                txtOtros.Text = dt2.Rows[0]["nOtros"].ToString();
                txtMora.Text = "0.00";
            }

            try
            {
                txtTotal.Text = (Convert.ToDecimal(txtCapital.Text) + Convert.ToDecimal(txtInteres.Text) + Convert.ToDecimal(txtComision.Text) + Convert.ToDecimal(txtOtros.Text) + Convert.ToDecimal(txtMora.Text)).ToString();
            }
            catch (Exception)
            {


            }
            
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarDatosIniciales();
            limpiarMontos();
            txtCodAdeudo.Clear();
            txtCodAdeudo.Enabled = true;
            txtCodAdeudo.Focus();
        }

        private void txtMora_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = (Convert.ToDecimal(txtCapital.Text) + Convert.ToDecimal(txtInteres.Text) + Convert.ToDecimal(txtComision.Text) + Convert.ToDecimal(txtOtros.Text) + Convert.ToDecimal(txtMora.Text)).ToString();
            }
            catch (Exception)
            {
            }
        }
        private void txtOtros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = (Convert.ToDecimal(txtCapital.Text) + Convert.ToDecimal(txtInteres.Text) + Convert.ToDecimal(txtComision.Text) + Convert.ToDecimal(txtOtros.Text) + Convert.ToDecimal(txtMora.Text)).ToString();
            }
            catch (Exception)
            {}
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            txtNroDocumento.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
