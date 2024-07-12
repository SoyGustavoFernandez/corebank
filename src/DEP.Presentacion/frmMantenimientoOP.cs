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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmMantenimientoOP : frmBase
    {
        DataTable LisDetOP = null;

        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();
        clsCNFirmas cnFirma = new clsCNFirmas();

        public frmMantenimientoOP()
        {
            InitializeComponent();
        }

        private void frmMantenimientoOP_Load(object sender, EventArgs e)
        {
            this.conBusCtaAho.nTipOpe = 13;
            ListarEstadoChequera();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            dtgIntervinientes.AutoGenerateColumns = false;
            conBusCtaAho.txtCodAge.Focus();            
        }

        private void ListarEstadoChequera()
        {
            DataTable LisEstCheq = clsOpeValorado.CNListarEstadosSol();
            cboEstCheq.DataSource = LisEstCheq;
            cboEstCheq.ValueMember = LisEstCheq.Columns["idEstadoSolOP"].ToString();
            cboEstCheq.DisplayMember = LisEstCheq.Columns["cDescripcion"].ToString();
        }

        private void ListarSolicitudesxOP(int idEstado)
        {
            DataTable LisSol = clsOpeValorado.CNListarSolicitudesxEstado(idEstado,conBusCtaAho.idcuenta);
            dtgSolicitudes.DataSource = LisSol;
            FormatoGridSolicitudes();
        }

        private void FormatoGridSolicitudes()
        {
            dtgSolicitudes.Columns["idCuenta"].Visible = false;

            dtgSolicitudes.Columns["idSolicitudOP"].HeaderText = "Solicitud";
            dtgSolicitudes.Columns["idSolicitudOP"].Width = 45;
            dtgSolicitudes.Columns["dFechaSol"].HeaderText = "Fecha Sol";
            dtgSolicitudes.Columns["dFechaSol"].Width = 40;
            dtgSolicitudes.Columns["nNumTalonarios"].HeaderText = "Talonarios Sol";
            dtgSolicitudes.Columns["nNumTalonarios"].Width = 50;
            dtgSolicitudes.Columns["nCantidadPorTal"].HeaderText = "Cantidad";
            dtgSolicitudes.Columns["nCantidadPorTal"].Width = 50;
            dtgSolicitudes.Columns["nSerie"].HeaderText = "Serie";
            dtgSolicitudes.Columns["nSerie"].Width = 30;
            dtgSolicitudes.Columns["nNumeroIni"].HeaderText = "Nro. Inicial";
            dtgSolicitudes.Columns["nNumeroIni"].Width = 50;
            dtgSolicitudes.Columns["nNumeroFin"].HeaderText = "Nro Final";
            dtgSolicitudes.Columns["nNumeroFin"].Width = 80;
            if (Convert.ToInt32(cboEstCheq.SelectedValue) == 3)
            {
                dtgSolicitudes.Columns["cDescriRechaz"].Visible = true;
                dtgSolicitudes.Columns["cDescriRechaz"].HeaderText = "Motivo rechazo";
                dtgSolicitudes.Columns["cDescriRechaz"].Width = 120;
            }
            else if (Convert.ToInt32(cboEstCheq.SelectedValue) == 4)
            {
                dtgSolicitudes.Columns["cDescriRechaz"].Visible = true;
                dtgSolicitudes.Columns["cDescriRechaz"].HeaderText = "Motivo anulación";
                dtgSolicitudes.Columns["cDescriRechaz"].Width = 120;
            }
            else
            {
                dtgSolicitudes.Columns["cDescriRechaz"].Visible = false;
            }


        }

        private void ListarDetallexOP(int idSolOP)
        {
            LisDetOP = clsOpeValorado.CNListarSolicitudesOPDetalle(idSolOP);
            dtgDetalle.DataSource = LisDetOP;
            FormatoGridDetalleOP();
        }

        private void FormatoGridDetalleOP()
        {            
            dtgDetalle.Columns["idVincuCuenta"].Visible = false;
            dtgDetalle.Columns["idValorado"].Visible = false;
            dtgDetalle.Columns["cNroDNI"].Visible = false;
            dtgDetalle.Columns["idSolicitudOP"].Visible = false;
            dtgDetalle.Columns["idEstado"].Visible = false;

            dtgDetalle.Columns["nNroFolio"].HeaderText = "Nro Folio";
            dtgDetalle.Columns["nNroFolio"].Width = 30;
            dtgDetalle.Columns["nSerie"].HeaderText = "Serie";
            dtgDetalle.Columns["nSerie"].Width = 30;
            dtgDetalle.Columns["nNumero"].HeaderText = "Nro OP";
            dtgDetalle.Columns["nNumero"].Width = 40;
            dtgDetalle.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgDetalle.Columns["cEstadoVal"].Width = 50;
            dtgDetalle.Columns["idKardex"].HeaderText = "Nro Operación";
            dtgDetalle.Columns["idKardex"].Width = 45;
            dtgDetalle.Columns["cNomCliente"].HeaderText = "Nombre Cliente";
            dtgDetalle.Columns["cNomCliente"].Width = 100;

            //if (Convert.ToInt32(cboEstCheq.SelectedValue) == 3 )
            //{
            //    dtgDetalle.Columns["cMotivoAnula"].Visible = true;
            //    dtgDetalle.Columns["cMotivoAnula"].HeaderText = "Motivo rechazo";
            //    dtgDetalle.Columns["cMotivoAnula"].Width = 150;
            //}
            //if (Convert.ToInt32(cboEstCheq.SelectedValue) == 4)
            //{
            //    dtgDetalle.Columns["cMotivoAnula"].Visible = true;
            dtgDetalle.Columns["cMotivoAnula"].HeaderText = "Motivo rechazo/anulación";
            dtgDetalle.Columns["cMotivoAnula"].Width = 100;
            //}
            //else
            //{
            //    dtgDetalle.Columns["cMotivoAnula"].Visible = false;
            //}
            dtgDetalle.Columns["lisEstado"].HeaderText = "OK";
            dtgDetalle.Columns["lisEstado"].Width = 30;
        }
        

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            this.btnGrabar.Enabled = false;
            LimpiarCtrl();
            if (!string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text))
            {
                if (Convert.ToInt32(this.conBusCtaAho.txtNroCta.Text.ToString().Trim()) == 0)
                {
                    MessageBox.Show("Debe de Ingresar un Número de Cuenta Diferente de Cero(0)", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int idCuenta = 0;
                
                idCuenta = Convert.ToInt32(conBusCtaAho.idcuenta);

                DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCuenta, "1", 12);
                if (dtbNumCuentas.Rows.Count > 0)
                {
                    txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                    cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                    cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                    txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                }
                else
                {
                    conBusCtaAho.LimpiarControles();
                    LimpiarCtrl();
                    MessageBox.Show("No Existen los Datos de la Cuenta, por Favor Validar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCuenta);
                dtgIntervinientes.Enabled = true;
                dtgIntervinientes.ReadOnly = false;
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    if (dtbIntervCta.Rows.Count > 1)
                    {
                        dtgIntervinientes.Columns["cDocumentoID"].ReadOnly = true;
                        dtgIntervinientes.Columns["cNombre"].ReadOnly = true;
                        dtgIntervinientes.Columns["cTipoIntervencion"].ReadOnly = true;
                        dtbIntervCta.Columns["isReqFirma"].ReadOnly = false;
                        dtgIntervinientes.Columns["isReqFirma"].ReadOnly = false;
                    }
                    else
                    {
                        dtgIntervinientes.ReadOnly = true;
                    }
                }
                else
                {
                    conBusCtaAho.LimpiarControles();
                    LimpiarCtrl();
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                dtgDetalle.Enabled = true;
                if (dtgDetalle.Rows.Count>0)
                {
                    dtgDetalle.Enabled = true;
                }
                cboEstCheq.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = true;
                this.conBusCtaAho.HabDeshabilitarCtrl(false);
                this.conBusCtaAho.btnBusCliente.Enabled = false;
                cboEstCheq.Focus();
            }
            else
            {
                conBusCtaAho.LimpiarControles();
                LimpiarCtrl();
                this.conBusCtaAho.HabDeshabilitarCtrl(true);
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
            }
        }

        private void LimpiarCtrl()
        {
            //--Datos de la Cuenta
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtNumFirmas.Text = "0";
            ptbFirma.Image = null;
            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();

            if (dtgSolicitudes.Rows.Count > 0)
            {
                ((DataTable)dtgSolicitudes.DataSource).Rows.Clear();
            }
            dtgSolicitudes.Refresh();

            if (dtgDetalle.Rows.Count > 0)
            {
                ((DataTable)dtgDetalle.DataSource).Rows.Clear();
            }
            dtgDetalle.Refresh();
        }

        private void limpiarCtrlsOP()
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                ((DataTable)dtgSolicitudes.DataSource).Rows.Clear();
            }
            dtgSolicitudes.Refresh();

            if (dtgDetalle.Rows.Count > 0)
            {
                ((DataTable)dtgDetalle.DataSource).Rows.Clear();
            }
            dtgDetalle.Refresh();
            chcAnularOP.Checked  = false;
            chcAnularTal.Checked = false;
            txtMotivo.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCtaAho.LimpiarControles();
            LimpiarCtrl();
            conBusCtaAho.idcuenta = 0;
            chcAnularOP.Checked = false;
            chcAnularTal.Checked = false;
            cboEstCheq.SelectedValue = 0;
            chcAnularOP.Enabled = false;
            chcAnularTal.Enabled = false;
            cboEstCheq.Enabled = false;
            txtMotivo.Text = "";
            txtMotivo.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            btnGrabar.Enabled = false;
            conBusCtaAho.txtCodAge.Focus();
        }

        private void DesabilitarCtrls()
        {
            cboEstCheq.Enabled = false;
            dtgSolicitudes.Enabled = false;
            chcAnularOP.Checked = false;
            chcAnularTal.Checked = false;
            dtgDetalle.Enabled = false;
            chcAnularOP.Enabled = false;
            txtMotivo.Enabled = false;
        }

        private void cboEstCheq_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEst = 0;
            limpiarCtrlsOP();
            if (cboEstCheq.SelectedIndex!=0)
            {
                idEst=Convert.ToInt16(cboEstCheq.SelectedValue);
                ListarSolicitudesxOP(idEst);
            }
            
        }

        private void dtgSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            chcAnularOP.Checked = false;
            chcAnularTal.Checked = false;
            if (dtgSolicitudes.Rows.Count > 0)
            {
                ListarDetallexOP(Convert.ToInt32(dtgSolicitudes.CurrentRow.Cells["idSolicitudOP"].Value));
                if (dtgDetalle.Rows.Count>0)
                {
                    chcAnularOP.Enabled = true;
                    chcAnularTal.Enabled = true;
                    txtMotivo.Enabled = true;
                }
                else
                {
                    chcAnularOP.Enabled = false;
                    chcAnularTal.Enabled = false;
                    txtMotivo.Enabled = false;
                }
                ColorDetalleOP();
            }
        }

        private void ColorDetalleOP()
        {
            for (int i = 0; i < dtgDetalle.Rows.Count; i++)
            {
                if (Convert.ToInt16(dtgDetalle.Rows[i].Cells["idEstado"].Value)==10)
                {
                    dtgDetalle.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dtgDetalle.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void chcAnularOP_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAnularOP.Checked)
            {
                chcAnularTal.Checked = false;
                dtgDetalle.ReadOnly = false;
                LisDetOP.Columns["lisEstado"].ReadOnly = false;
                dtgDetalle.Columns["lisEstado"].ReadOnly = false;
                           
                SoloLecturaDetalle();
                //for (int i = 0; i < LisDetOP.Rows.Count; i++)
                //{                    
                //    dtgDetalle.Rows[i].Cells["lisEstado"].Value = false;
                //}

                for (int i = 0; i < LisDetOP.Rows.Count; i++)
                {
                 //   if(dtgDetalle.Rows[i].Cells["lisEstado"].Value)
                    dtgDetalle.Rows[i].Cells["lisEstado"].ReadOnly= false;
                    string cidEstado = dtgDetalle.Rows[i].Cells["idEstado"].Value.ToString();
                    if (cidEstado!="6")  //--cidEstado.Equals("10")
                    {
                         dtgDetalle.Rows[i].Cells["lisEstado"].ReadOnly= true ;
                    }
                }

                dtgDetalle.Refresh();
            }
            else
            {
                dtgDetalle.ReadOnly = true;
                for (int i = 0; i < LisDetOP.Rows.Count; i++)
                {
                    dtgDetalle.Rows[i].Cells["lisEstado"].Value = false;
                }
                dtgDetalle.Refresh();
            }

        }

        private void SoloLecturaDetalle()
        {
            dtgDetalle.Columns["nNroFolio"].ReadOnly = true;
            dtgDetalle.Columns["nSerie"].ReadOnly = true;
            dtgDetalle.Columns["nNumero"].ReadOnly = true;
            dtgDetalle.Columns["cEstadoVal"].ReadOnly = true;
            dtgDetalle.Columns["idKardex"].ReadOnly = true;
            dtgDetalle.Columns["cNomCliente"].ReadOnly = true;
            dtgDetalle.Columns["cMotivoAnula"].ReadOnly = true;
        }

        private void chcAnularTal_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAnularTal.Checked)
            {
                chcAnularOP.Checked = false;                
                LisDetOP.Columns["lisEstado"].ReadOnly = false;                
                for (int i = 0; i < LisDetOP.Rows.Count; i++)
                {
                    if (Convert.ToInt16(dtgDetalle.Rows[i].Cells["idEstado"].Value)==6)
                    {
                        dtgDetalle.Rows[i].Cells["lisEstado"].Value = true;    
                    }                    
                }
                dtgDetalle.ReadOnly = true;
                dtgDetalle.Refresh();
            }
            else
            {
                for (int i = 0; i < LisDetOP.Rows.Count; i++)
                {
                    dtgDetalle.Rows[i].Cells["lisEstado"].Value = false;
                }
                dtgDetalle.Refresh();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaDatosOP())
            {
                return;
            }

            int idOpcion = 1;
            if (chcAnularTal.Checked)
            {
                idOpcion = 2;
            }
            int idSolOP = Convert.ToInt32(dtgSolicitudes.Rows[dtgSolicitudes.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString());
            
            //===================================================================
            //--Generar XML del Detalle de Ordenes de Pago
            //===================================================================
            DataTable dtOP = (DataTable)dtgDetalle.DataSource;
            DataSet dsValoradoOP = new DataSet("dsValorado");
            dsValoradoOP.Tables.Add(dtOP);
            string xmlDetOP = clsCNFormatoXML.EncodingXML(dsValoradoOP.GetXml());
            string cDescri = txtMotivo.Text;

            DataTable dtEnviOP = clsOpeValorado.CNRegistramantenimientoOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetOP, idOpcion, cDescri, idSolOP);
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Mantenimiento de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = false;
                DesabilitarCtrls();
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Mantenimiento de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private bool ValidaDatosOP()
        {
            if (dtgSolicitudes.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Solicitudes de Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtgDetalle.Rows.Count<=0)
            {
                MessageBox.Show("No Existe Detalle de Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!chcAnularOP.Checked && !chcAnularTal.Checked)
            {
                MessageBox.Show("Debe Seleccionar, bien para Anular o la Devolución de las Órdenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            int k = 0;
            for (int i = 0; i < dtgDetalle.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgDetalle.Rows[i].Cells["lisEstado"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe Seleccionar las Ordenes de Pago a Anular", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgDetalle.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("Debe Registrar el Motivo de Anulación de las Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivo.Focus();
                return false;
            }
            return true;
        }

        private void dtgDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDetalle.IsCurrentCellDirty)
            {
                dtgDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)  
            {
                if (dtgDetalle.Columns[e.ColumnIndex].Name == "lisEstado")
                {
                    if (Convert.ToInt16(dtgDetalle.Rows[e.RowIndex].Cells["idEstado"].Value) == 10)
                    {
                        dtgDetalle.Rows[e.RowIndex].Cells["lisEstado"].Value = false;
                        dtgDetalle.Refresh();
                    }
                }
            }
            
        }

    }
}
