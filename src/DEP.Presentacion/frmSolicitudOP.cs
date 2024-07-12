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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmSolicitudOP : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNFirmas cnFirma = new clsCNFirmas();
        clsCNValorados clsOpeValorado = new clsCNValorados();
        public frmSolicitudOP()
        {
            InitializeComponent();
        }

        private void frmSolicitudOP_Load(object sender, EventArgs e)
        {
            this.conBusCtaAho.nTipOpe = 13;
            ListarModalidadSolVal();
            ListarTipPagoSolVal();
            HabDeshabCtrls(false);
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            dtgIntervinientes.AutoGenerateColumns = false;
            conBusCtaAho.txtCodAge.Focus();
        }

        private void MostrarFirma(int idCliente)
        {
            ptbFirma.Image = null;
            var objFirma = cnFirma.retornaFirma(idCliente);
            if (objFirma != null)
            {
                ptbFirma.Image = objFirma.imgFirma;
                ptbFirma.Refresh();
            }

        }

        private void ListarModalidadSolVal()
        {
            DataTable LisModSol = clsOpeValorado.CNListarModalidadSolVal();
            cboModSolicitud.DataSource = LisModSol;
            cboModSolicitud.ValueMember = LisModSol.Columns["idModSolVal"].ToString();
            cboModSolicitud.DisplayMember = LisModSol.Columns["cDescripcion"].ToString();
        }

        private void ListarTipPagoSolVal()
        {
            DataTable LisTipPagSol = clsOpeValorado.CNListarTiposPagoSolVal();
            cboModPago.DataSource = LisTipPagSol;
            cboModPago.ValueMember = LisTipPagSol.Columns["idTipoPago"].ToString();
            cboModPago.DisplayMember = LisTipPagSol.Columns["cDesTipoPago"].ToString();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            this.btnGrabar.Enabled = false;
            HabDeshabCtrls(false);
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
                    conBusCtaAho.txtCodAge.Focus();
                    MessageBox.Show("No Existen los Datos de la Cuenta, por Favor Validar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        dtbIntervCta.Columns["isReqFirma"].ReadOnly = false;

                        dtgIntervinientes.Columns["cDocumentoID"].ReadOnly = true;
                        dtgIntervinientes.Columns["cNombre"].ReadOnly = true;
                        dtgIntervinientes.Columns["cTipoIntervencion"].ReadOnly = true;
                        dtgIntervinientes.Columns["isReqFirma"].ReadOnly = false;

                        foreach (DataGridViewRow row in dtgIntervinientes.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["idTipoDocumento"].Value) == 4)
                            {
                                row.Cells["isReqFirma"].ReadOnly = true;
                            }
                        }
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
                    conBusCtaAho.txtCodAge.Focus();
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    return;
                }

                conBusCtaAho.HabDeshabilitarCtrl(false);
                this.conBusCtaAho.btnBusCliente.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = true;
                HabDeshabCtrls(true);
                nudNroTalon.Focus();
            }
            else
            {
                MessageBox.Show("Debe ingresar el Número de Cuenta a Buscar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.LimpiarControles();
                LimpiarCtrl();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
            }
        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                MostrarFirma(Convert.ToInt32(dtgIntervinientes.CurrentRow.Cells["idCli"].Value));
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {                        
            conBusCtaAho.LimpiarControles();
            dtgIntervinientes.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            LimpiarCtrl();
            conBusCtaAho.idcuenta = 0;
            HabDeshabCtrls(false);
            btnNuevo.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();
        }

        private void LimpiarCtrl()
        {
            //--Datos de la Cuenta
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtNumFirmas.Text = "0";
            ptbFirma.Image = null;
            //--Datos de Montos
            nudNroTalon.Value = 0;
            cboLimitesVal.SelectedValue = 1;
            cboModPago.SelectedValue = 1;
            cboModSolicitud.SelectedValue = 1;
            txtDescripcionSol.Text = "";
            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();
        }

        private void HabDeshabCtrls(Boolean valor)
        {
            nudNroTalon.Enabled = valor;
            cboLimitesVal.Enabled = valor;
            cboModPago.Enabled = valor;
            cboModSolicitud.Enabled = valor;
            dtgIntervinientes.Enabled = valor;            
            conBusCtaAho.HabDeshabilitarCtrl(valor);
            conBusCtaAho.btnBusCliente.Enabled = valor;
            btnGrabar.Enabled = valor;
        }

        private void cboModSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcionSol.Text = "";
            txtDescripcionSol.Enabled = false;
            if (Convert.ToInt16(cboModSolicitud.SelectedIndex)>0)
            {
                if (Convert.ToInt16(cboModSolicitud.SelectedValue) == 1)
                {
                    txtDescripcionSol.Enabled = false;
                }
                else
                {
                    txtDescripcionSol.Text = "";
                    txtDescripcionSol.Enabled = true;
                }
            }
        }

        private bool ValidarDatos()
        {
            int k = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value))
                {
                    k++;
                    break;
                }
            }
            if (k <= 0)
            {
                MessageBox.Show("Por lo menos, se debe marcar a un Interviniente para que recoja el talonario", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgIntervinientes.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Buscar Primero la Cuenta, para Solicitar la Orden de Pago...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.txtNroCta.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text))
            {
                MessageBox.Show("El Código del Cliente no es Válido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (nudNroTalon.Value<=0)
            {
                MessageBox.Show("El Número de Talonarios no Puede ser Cero (0)...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudNroTalon.Focus();
                return false;
            }
            if (cboModPago.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar la Modalidad de Pago de la OP...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModPago.Focus();
                return false;   
            }
            if (cboModSolicitud.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar la Modalidad de Solicitud de la OP...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModSolicitud.Focus();
                return false;
            }
            if (Convert.ToInt16(cboModSolicitud.SelectedValue)==2)
            {
                if (string.IsNullOrEmpty(txtDescripcionSol.Text))
                {
                    MessageBox.Show("Deb Registar la Descripción de la Carta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDescripcionSol.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            //--===============================================
            //--Asignar Datos para Guardar
            //--===============================================
            int x_idCuenta = Convert.ToInt32(conBusCtaAho.idcuenta),
                x_idMoneda = Convert.ToInt16(cboMoneda.SelectedValue),
                x_nNroTalonario = Convert.ToInt16(nudNroTalon.Value),
                x_nCantidadxTal = Convert.ToInt16(cboLimitesVal.Text),
                x_nModPagoOP = Convert.ToInt16(cboModPago.SelectedValue),
                x_nModSolOP = Convert.ToInt16(cboModSolicitud.SelectedValue);
            string x_cDesCartaNot = txtDescripcionSol.Text.Trim();

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable dtInterv = (DataTable)dtgIntervinientes.DataSource;
            DataSet dsIntervin = new DataSet("dsRetiro");
            dsIntervin.Tables.Add(dtInterv);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());

            DataTable tbRegSolOP = clsOpeValorado.CNRegistrarSolicitudOP(x_idCuenta,x_idMoneda, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, 
                                                                    x_nNroTalonario,x_nCantidadxTal, x_nModPagoOP, x_nModSolOP, x_cDesCartaNot, xmlInterv);
            if (Convert.ToInt32(tbRegSolOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegSolOP.Rows[0]["cMensage"].ToString() + ", Nro. Solicitud: " + tbRegSolOP.Rows[0]["idNroSolOP"].ToString(), "Registro de Solicitud de OP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRegSolOP.Rows[0]["cMensage"].ToString(), "Registro de Solicitud de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string cNumSolicitud = tbRegSolOP.Rows[0]["idNroSolOP"].ToString();
            int idAgenciaOrigen = clsVarGlobal.nIdAgencia;
            //Impresión de Solicitud de Apertura
            DataTable dtSolOP = clsOpeValorado.CNRetornaDatosSolOP(idAgenciaOrigen, Convert.ToInt32(cNumSolicitud), x_idCuenta);
            
            string cNumeroCuenta = conBusCtaAho.txtCodIns.Text + conBusCtaAho.txtCodAge.Text + conBusCtaAho.txtCodMod.Text + conBusCtaAho.txtCodMon.Text + conBusCtaAho.txtNroCta.Text;
            string cDiaSemana = clsVarGlobal.dFecSystem.ToString("dddd");
            string cDia = clsVarGlobal.dFecSystem.Day.ToString();
            string cMes = clsVarGlobal.dFecSystem.ToString("MMMM");
            string cAño = clsVarGlobal.dFecSystem.Year.ToString();
            string nNumTal = nudNroTalon.Value.ToString();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_idSolicitud", cNumSolicitud, false));
            paramlist.Add(new ReportParameter("x_idCuenta", x_idCuenta.ToString(), false));            
            paramlist.Add(new ReportParameter("x_cNumeroCuenta", cNumeroCuenta, false));
            paramlist.Add(new ReportParameter("x_cDiaSemana", cDiaSemana, false));
            paramlist.Add(new ReportParameter("x_cDia", cDia, false));
            paramlist.Add(new ReportParameter("x_cMes", cMes, false));
            paramlist.Add(new ReportParameter("x_cAnio", cAño, false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
            paramlist.Add(new ReportParameter("x_nNumTalonario", nNumTal, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsSolicitud", dtSolOP));            

            string reportpath = "RptSolOrdPago.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();            
            btnGrabar.Enabled = false;
            dtgIntervinientes.Enabled = false;
            HabDeshabCtrls(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            conBusCtaAho.LimpiarControles();
            LimpiarCtrl();
            HabDeshabCtrls(true);
            btnNuevo.Enabled = false;
        }

        private void dtgIntervinientes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                bool lCheck = Convert.ToBoolean(dtgIntervinientes.Rows[index].Cells["isReqFirma"].Value);
                
                dtgIntervinientes.CellValueChanged -= dtgIntervinientes_CellValueChanged;

                for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                {
                    dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value = false;
                }
                dtgIntervinientes.Rows[index].Cells["isReqFirma"].Value = lCheck;

                dtgIntervinientes.CellValueChanged += dtgIntervinientes_CellValueChanged;
            }
        }

        private void dtgIntervinientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgIntervinientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
