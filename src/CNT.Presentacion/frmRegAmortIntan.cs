using CNT.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmRegAmortIntan : frmBase
    {
        clsCNAmortizacion objAmortiza = new clsCNAmortizacion();
        clsCtaContable objctactb;
        DataTable dtDetalle, dtMaestroAmortiza, dtDetalleAmotiza;
        int TipoOpera = 1; //1 Nuevo, 2 Edita
        public decimal pnValConvertido;
        public decimal pnTipCambio;
        public frmRegAmortIntan()
        {
            InitializeComponent();
            CargaDatos();
            dtpFechaPago.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void CargaDatos()
        {
            dtMaestroAmortiza = objAmortiza.CNActProAmorti();
            if (dtMaestroAmortiza.Rows.Count > 0)
            {
                dtgAmortizacion.DataSource = dtMaestroAmortiza;
                CargaDetalle(Convert.ToInt32(dtMaestroAmortiza.Rows[0]["idIntangible"]));
                btnEditar1.Enabled = true;
            }
            else
            {
                CargaDetalle(0);
                btnEditar1.Enabled = false;
            }
        }
        private void CargaDetalle(int idItg)
        {
            dtDetalle = objAmortiza.CNDetalleAmorti(idItg);
            dtgCronograma.DataSource = dtDetalle;

            dtDetalleAmotiza = objAmortiza.CNListaAmotizacionGen(idItg);
            dtgAmortizacionGenera.DataSource = dtDetalleAmotiza;

            Decimal nTotalAmortizado = 0;
            for (int i = 0; i < dtgAmortizacionGenera.RowCount; i++)
            {
                nTotalAmortizado += Convert.ToDecimal(dtgAmortizacionGenera.Rows[i].Cells[2].Value);

            }
            txtTotalPagadoAmort.Text = nTotalAmortizado.ToString();
        }

        private void txtidComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                validaComprobante();
            }
        }
        private void validaComprobante()
        {
            DataTable dtCompr, dtValidaCmb;
            int idCpr;
            if (txtidComprobante.Text.Trim().Equals(""))
            {
                idCpr = 0;
            }
            else{
                idCpr= Convert.ToInt32(txtidComprobante.Text);
            }
        
           

            dtValidaCmb = objAmortiza.CNValidaComprobante(idCpr);
            if (dtValidaCmb.Rows.Count > 0)
            {
                MessageBox.Show("El comprobante ya se encuentra registrado, Actividad: " + dtValidaCmb.Rows[0]["cDetalleAmortiza"].ToString(), "Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                    LimpiarNuevo();
                txtidComprobante.Text = "";
                return;
            }

            if (idCpr > 0)
            {
                dtCompr = objAmortiza.CNComprobante(idCpr);
                if (dtCompr.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtCompr.Rows[0]["idEstadoComprobante"]) != 2)
                    {
                        MessageBox.Show("El comprobante no se encuentra en estado pagado, Estado: " + dtCompr.Rows[0]["cDescripcion"].ToString(), "Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtidComprobante.Text = "";
                        return;
                    }
                    else
                    {
                        txtNroDocumento.Text = dtCompr.Rows[0]["cSerie"].ToString() + "-" + dtCompr.Rows[0]["cNumero"].ToString();
                        txtImporte.Text = dtCompr.Rows[0]["nSubTotal"].ToString();
                        cboMoneda1.SelectedValue = dtCompr.Rows[0]["idMoneda"];
                        txtProveedor.Text = dtCompr.Rows[0]["cNombre"].ToString();
                        dtpFechaEmision.Value = Convert.ToDateTime(dtCompr.Rows[0]["dFechaEmision"].ToString());
                        btnMiniAgregar1.Enabled = true;
                        cboMonedaGenera.SelectedValue = Convert.ToInt32(dtCompr.Rows[0]["idMoneda"].ToString());
                        if ((int)cboMoneda1.SelectedValue == (int)cboMonedaGenera.SelectedValue)
                        {
                            pnTipCambio = 0;
                            pnValConvertido = Convert.ToDecimal(dtCompr.Rows[0]["nSubTotal"].ToString());
                        }
                        else
                        {
                            pnTipCambio = Convert.ToDecimal(dtCompr.Rows[0]["nTipCambio"].ToString());
                            pnValConvertido = Convert.ToDecimal(dtCompr.Rows[0]["nValConvertido"].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Existe el comprobante", "Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtidComprobante.Text = "";
                    return;
                }
            }

        }

        private void LimpiarNuevo()
        {
            txtidComprobante.Text = "";
            txtNroDocumento.Text = "";
            txtImporte.Text = "";
            cboMoneda1.SelectedValue = 0;
            txtProveedor.Text = "";
            btnMiniAgregar1.Enabled = false;
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem;

            txtActividad.Text = "";
            cboTipoIntangible1.SelectedValue = 0;
            txtNumMeses.Text = "";
            txtCtaDebe.Text = "";
            txtCtaHaber.Text = "";
            dtgAmortizacion.Visible = true;
            grbNuevo.Visible = false;
            dtpFecIniAmort.Value = clsVarGlobal.dFecSystem;
            txtValTotActivo.Text = "0.00";
            txtConvertido.Clear();
            cboMonedaGenera.SelectedValue = 0;
            //////btnNuevo1.Enabled = true;
            //////btnEditar1.Enabled = true;
        }

        private Boolean ValidarCtaCtb(string pcCodCtb)
        {
            objctactb = new clsCNCtaContable().detallectactb(pcCodCtb);
            if (objctactb.nHijos > 0)
            {
                MessageBox.Show("Cuenta debe ser del ultimo nivel", "Graba Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (string.IsNullOrEmpty(objctactb.cDescripcion))
            {
                return true;
            }
            return false;
        }

        private void txtCtaHaber_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCtaHaber.Text))
            {
                if (ValidarCtaCtb(txtCtaHaber.Text))
                {
                    txtCtaHaber.Focus();
                }
            }
        }

        private void txtCtaDebe_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCtaDebe.Text))
            {
                if (ValidarCtaCtb(txtCtaDebe.Text))
                {
                    txtCtaDebe.Focus();
                }
            }
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNroDocumento.Text))
            {
                MessageBox.Show("Registre un Comprobante", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DateTime dFecActPro;
            if (dtMaestroAmortiza.Rows.Count > 0)
            {
                dFecActPro = Convert.ToDateTime(dtgAmortizacion.CurrentRow.Cells["dFechaRegistro"].Value).Date;
            }
            else
            {
                dFecActPro = dtpFechaInicio.Value.Date;
            }

            if (dtpFechaPago.Value < dFecActPro)
            {
                MessageBox.Show("Fecha de Inicio de Comprobante debe ser mayor a la fecha de inicio de la Actividad", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgCronograma.Rows.Count!=0)
            {
                 if (Convert.ToInt32(dtgCronograma.Rows[0].Cells[8].Value)!=(int)cboMoneda1.SelectedValue)
                {
                    MessageBox.Show("La moneda debe ser de la misma denominación", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            DataRow dataRow = dtDetalle.NewRow();
            Nuevo(dataRow);
            dtDetalle.Rows.Add(dataRow);
            Sumariza();
            //LimpiarNuevo();
        }

        private void Nuevo(DataRow dataRow)
        {
            if (TipoOpera == 1)
            {
                dataRow["idInt"] = 0;
            }
            else
            {
                dataRow["idInt"] = Convert.ToInt32(dtgAmortizacion.CurrentRow.Cells["idIntangible"].Value);
            }
            dataRow["idComprobantePago"] = txtidComprobante.Text;
            dataRow["dFechaInicio"] = dtpFechaPago.Value.Date;
            dataRow["nValorComprobante"] = Convert.ToDecimal(txtImporte.Text);
            dataRow["nValorAmortizado"] = 0;
            dataRow["nValorAmortizar"] = pnValConvertido;
            dataRow["cMoneda"] = cboMoneda1.Text;
            dataRow["nCuotas"] = 0;
            dataRow["nCuotaPagada"] = 0;
            dataRow["idMoneda"] = cboMoneda1.SelectedValue;
            dataRow["nTipCambio"] = pnTipCambio;
            dataRow["nValConvertido"] = pnValConvertido;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {

            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;

            txtidComprobante.Enabled = true;
            dtgAmortizacion.Enabled = false;

            TipoOpera = 2;
            txtidComprobante.Focus();

            txtConvertido.Enabled = false;
            txtValTotActivo.Enabled = false;

            cboMonedaGenera.Enabled = dtgAmortizacionGenera.RowCount > 0 ? false : true;
            dtpFecIniAmort.Enabled = dtgAmortizacionGenera.RowCount > 0 ? false : true;

        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            TipoOpera = 1;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;

            dtDetalle = null;

            LimpiarNuevo();
            CargaDetalle(0);
            grbNuevo.Visible = true;
            dtgAmortizacion.Visible = false;
            txtidComprobante.Enabled = true;
            txtActividad.Focus();

            txtConvertido.Enabled = false;
            txtValTotActivo.Enabled = false;
            cboMonedaGenera.Enabled = true;
            dtpFecIniAmort.Enabled = true;

        }

        private void btnCtaDebe_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
            frmBscCtaCtb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;

            if (ValidarCtaCtb(frmBscCtaCtb.pcCtaCtb))
            {
                return;
            }
            txtCtaDebe.Text = frmBscCtaCtb.pcCtaCtb;
        }

        private void btnHaber_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtbDeb = new frmBuscaCtaCtb();
            frmBscCtaCtbDeb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtbDeb.pcCtaCtb)) return;
            if (ValidarCtaCtb(frmBscCtaCtbDeb.pcCtaCtb))
            {
                return;
            }
            txtCtaHaber.Text = frmBscCtaCtbDeb.pcCtaCtb;
        }
        private Boolean Validar()
        {
            if (TipoOpera == 1 && string.IsNullOrEmpty(txtActividad.Text))
            {
                MessageBox.Show("Ingrese el detalle de la Actividad o Proyecto", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (TipoOpera == 1 && Convert.ToInt16(cboTipoIntangible1.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione el Tipo de Intangible", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (TipoOpera == 1 && Convert.ToInt16(string.IsNullOrEmpty(txtNumMeses.Text) ? "0" : txtNumMeses.Text) == 0)
            {
                MessageBox.Show("Plazo incorrecto, verificar", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (TipoOpera == 1 && string.IsNullOrEmpty(txtCtaDebe.Text))
            {
                MessageBox.Show("Registre la cuenta del Debe", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (TipoOpera == 1 && string.IsNullOrEmpty(txtCtaHaber.Text))
            {
                MessageBox.Show("Registre la cuenta del Haber", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (dtpFechaInicio.Value > dtpFecIniAmort.Value)
            {
                MessageBox.Show("La fecha de inicio de la actividad o proyecto debe ser menor a la fecha de inicio de amotización", "Registro de Amortización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                return;
            }
            btnGrabar1.Enabled = false;
            string cDetalleAmortiza = txtActividad.Text,
                    cCuentaContableDebe = txtCtaDebe.Text,
                    cCuentaContableHaber = txtCtaHaber.Text,
                    XmlDetalle = "";

            DataTable dtResulta;
            DataSet ds = new DataSet("dsAmortiza");
            ds.Tables.Add(dtDetalle);
            XmlDetalle = ds.GetXml();
            XmlDetalle = clsCNFormatoXML.EncodingXML(XmlDetalle);

            DateTime dFechaRegistro = dtpFechaInicio.Value.Date;

            int idUsuRegistro = clsVarGlobal.User.idUsuario,
                idEstado = 1,
                idIntangible = 0;
            
            decimal nValConvert = Convert.ToDecimal(txtAmortTotal.Text);

            decimal nValorContable = Convert.ToDecimal(txtnTotal.Text),//valor del activo
                    nAmortizaContable = Convert.ToDecimal(txtTotalPagadoAmort.Text),
                    nValorNeto = nValConvert - nAmortizaContable;
            int idTipoIntangible, nPlazo;
            DateTime dFecIniAmorti;
            int idMonedaGeneracion;
            if (TipoOpera == 1)
            {
                idTipoIntangible = Convert.ToInt16(cboTipoIntangible1.SelectedValue);
                nPlazo = Convert.ToInt16(txtNumMeses.Text);
                idIntangible = 0;
                dFecIniAmorti = Convert.ToDateTime(dtpFecIniAmort.Value);
                idMonedaGeneracion = (int)cboMonedaGenera.SelectedValue;
            }
            else
            {
                idTipoIntangible = 0;
                nPlazo = 0;
                idIntangible = Convert.ToInt32(dtgAmortizacion.CurrentRow.Cells["idIntangible"].Value);
                dFecIniAmorti = Convert.ToDateTime(dtgAmortizacion.CurrentRow.Cells["dFechaIniAmortizacion"].Value);
                idMonedaGeneracion = Convert.ToInt32(dtgAmortizacion.CurrentRow.Cells["idMonedaGen"].Value);
            }
            

            dtResulta = objAmortiza.CNInsUpdAmorti(cDetalleAmortiza, dFechaRegistro, idTipoIntangible, nPlazo,
                              cCuentaContableDebe, cCuentaContableHaber, nValorContable,
                              nAmortizaContable, nValorNeto, idUsuRegistro, idEstado,
                              XmlDetalle, idIntangible, dFecIniAmorti, idMonedaGeneracion, nValConvert);

            if (Convert.ToInt16(dtResulta.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show("Actualización Correcta", "Registro de Amortizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimpiarNuevo();
            CargaDatos();
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgCronograma.Rows.Count > 0)
            {
                dtDetalle.Rows.RemoveAt(dtgCronograma.CurrentCell.RowIndex);
                dtgCronograma.Refresh();
            }
            Sumariza();
        }

        private void Sumariza()
        {
            Decimal nTotalAmortizar = 0, nPorAmortizar = 0, nAmortizado = 0;
            for (int i = 0; i < dtgCronograma.RowCount; i++)
            {
                nTotalAmortizar += Convert.ToDecimal(dtgCronograma.Rows[i].Cells["nValorComprobante"].Value);
                nAmortizado += Convert.ToDecimal(dtgCronograma.Rows[i].Cells["nValorAmortizado"].Value);
                nPorAmortizar += Convert.ToDecimal(dtgCronograma.Rows[i].Cells["nValConvertido"].Value);
            }
            txtnTotal.Text = nTotalAmortizar.ToString();
            txtValTotActivo.Text = txtnTotal.Text;
            txtAmortTotal.Text = nPorAmortizar.ToString();
            txtConvertido.Text = txtAmortTotal.Text;
            //txtPagado.Text = nAmortizado.ToString();
        }

        private void dtgAmortizacion_SelectionChanged(object sender, EventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgAmortizacion.CurrentRow.Index);
            CargaDetalle(Convert.ToInt32(dtMaestroAmortiza.Rows[fila]["idIntangible"]));
            dtpFechaInicio.Value = Convert.ToDateTime(dtMaestroAmortiza.Rows[fila]["dFechaRegistro"]);
            dtpFecIniAmort.Value = Convert.ToDateTime(dtMaestroAmortiza.Rows[fila]["dFechaIniAmortizacion"]);
            Sumariza();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarNuevo();
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            dtgAmortizacion.Enabled = true;
            CargaDatos();
            
        }

        private void grbNuevo_Enter(object sender, EventArgs e)
        {

        }

        private void txtidComprobante_Leave(object sender, EventArgs e)
        {
            validaComprobante();
        }

        private void frmRegAmortIntan_Load(object sender, EventArgs e)
        {

        }

        private void txtidComprobante_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
