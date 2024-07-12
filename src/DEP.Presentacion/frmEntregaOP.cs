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

namespace DEP.Presentacion
{
    public partial class frmEntregaOP : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();
        clsCNFirmas cnFirma = new clsCNFirmas();

        public frmEntregaOP()
        {
            InitializeComponent();
        }

        private void frmEntregaOP_Load(object sender, EventArgs e)
        {
            this.conBusCtaAho.nTipOpe = 13;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            dtgIntervinientes.AutoGenerateColumns = false;
            conBusCtaAho.txtCodAge.Focus();
            btnImprimir.Enabled = false;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = false;
            dtgSolOP.Enabled = true;
            if (!string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text))
            {
                if (Convert.ToInt32(this.conBusCtaAho.txtNroCta.Text.ToString().Trim()) == 0)
                {
                    MessageBox.Show("Debe de Ingresar un Número de Cuenta Diferente de Cero(0)", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                int idCuenta = 0;

                idCuenta = Convert.ToInt32(conBusCtaAho.idcuenta);

                //--===================================================================================
                //--Datos Generales
                //--===================================================================================
                DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCuenta, "1", 12);
                if (dtbNumCuentas.Rows.Count > 0)
                {
                    txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                    cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                    cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
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
                //--Cargar el Detalle de Firmas
                //--===================================================================================
                DataTable tbDetFirmasOP = clsOpeValorado.CNDetalleFirmasOP(idCuenta);
                if (tbDetFirmasOP.Rows.Count > 0)
                {
                    if (Convert.ToInt32(tbDetFirmasOP.Rows[0]["idAgencia"].ToString()) != clsVarGlobal.nIdAgencia)
                    {
                        MessageBox.Show("El Talonario, debe Recogerlo en la Agencia: " + tbDetFirmasOP.Rows[0]["cNomCortoAge"].ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAho.LimpiarControles();
                        LimpiarCtrl();
                        conBusCtaAho.txtCodAge.Focus();
                        return;
                    }
                    dtgIntervinientes.DataSource = tbDetFirmasOP;
                    txtNumFirmas.Text = tbDetFirmasOP.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("La Cuenta no Tiene Talonarios a Entregar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCtaAho.LimpiarControles();
                    LimpiarCtrl();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--===================================================================================
                //--Cargar el Detalle Solicitudes de OP
                //--===================================================================================
                DataTable tbDetSolOP = clsOpeValorado.CNDetalleOPRecepcionados(idCuenta, clsVarGlobal.nIdAgencia);
                if (tbDetSolOP.Rows.Count > 0)
                {
                    dtgSolOP.ReadOnly = false;
                    dtgSolOP.DataSource = tbDetSolOP;
                    dtgSolOP.Columns["idMoneda"].Visible = false;
                    dtgSolOP.Columns["idAgencia"].Visible = false;
                    dtgSolOP.Columns["idEstadoVal"].Visible = false;
                    dtgSolOP.Columns["cModPagOP"].Visible = false;
                    dtgSolOP.Columns["cNomCorto"].Visible = false;

                    dtgSolOP.Columns["idSolicitudOP"].HeaderText = "Solicitud";
                    dtgSolOP.Columns["idSolicitudOP"].Width = 50;
                    dtgSolOP.Columns["idCuenta"].HeaderText = "Cuenta";
                    dtgSolOP.Columns["idCuenta"].Width = 60;
                    dtgSolOP.Columns["nNumTalonarios"].HeaderText = "Talonarios";
                    dtgSolOP.Columns["nNumTalonarios"].Width = 55;
                    dtgSolOP.Columns["nCantidadPorTal"].HeaderText = "Cantidad";
                    dtgSolOP.Columns["nCantidadPorTal"].Width = 45;
                    dtgSolOP.Columns["dFechaSol"].HeaderText = "Fec. Solicitud";
                    dtgSolOP.Columns["dFechaSol"].Width = 70;
                    dtgSolOP.Columns["cEstadoVal"].HeaderText = "Estado";
                    dtgSolOP.Columns["cEstadoVal"].Width = 60;
                    dtgSolOP.Columns["lok"].HeaderText = "Entrega";
                    dtgSolOP.Columns["lok"].Width = 40;

                    dtgSolOP.Columns["idSolicitudOP"].ReadOnly = true;
                    dtgSolOP.Columns["idCuenta"].ReadOnly = true;
                    dtgSolOP.Columns["nNumTalonarios"].ReadOnly = true;
                    dtgSolOP.Columns["nCantidadPorTal"].ReadOnly = true;
                    dtgSolOP.Columns["dFechaSol"].ReadOnly = true;
                    dtgSolOP.Columns["cNomCorto"].ReadOnly = true;
                    dtgSolOP.Columns["cModPagOP"].ReadOnly = true;
                    dtgSolOP.Columns["cEstadoVal"].ReadOnly = true;
                    tbDetSolOP.Columns["lok"].ReadOnly = false;
                    dtgSolOP.Columns["lok"].ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("La Cuenta no Tiene Solicitudes de Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCtaAho.LimpiarControles();
                    LimpiarCtrl();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                btnGrabar.Enabled = true;
                conBusCtaAho.HabDeshabilitarCtrl(false);
                this.conBusCtaAho.btnBusCliente.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe ingresar el Número de Cuenta a Buscar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.HabDeshabilitarCtrl(true);
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
                return;
            }
        }

        private void LimpiarCtrl()
        {
            txtNumFirmas.Text = "";
            //--Clientes que Firman
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();
            //--Solicitudes
            if (dtgSolOP.Rows.Count > 0)
            {
                ((DataTable)dtgSolOP.DataSource).Rows.Clear();
            }
            dtgSolOP.Refresh();
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
            LimpiarCtrl();
            conBusCtaAho.idcuenta = 0;
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();
        }

        private bool ValidaEnvioOP()
        {
            if (dtgIntervinientes.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen Responsables para la Entrega de las OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtgSolOP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen, Ordenes de Pago para su Entrega", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int k = 0;
            for (int i = 0; i < dtgSolOP.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgSolOP.Rows[i].Cells["lok"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe Seleccionar las Ordenes a Entregar al Cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgSolOP.Focus();
                return false;
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaEnvioOP())
            {
                return;
            }

            //===================================================================
            //--Generar XML del Detalle de Ordenes de Pago
            //===================================================================
            DataTable dtOP = (DataTable)dtgSolOP.DataSource;
            DataSet dsValoradoOP = new DataSet("dsValorado");
            dsValoradoOP.Tables.Add(dtOP);
            string xmlDetOP = clsCNFormatoXML.EncodingXML(dsValoradoOP.GetXml());

            DataTable dtEnviOP = clsOpeValorado.CNRegistraEnvioOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetOP, 6, "", "0");
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Entrega de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = false;
                dtgSolOP.Enabled = false;
                btnImprimir.Enabled = true;
                btnImprimir_Click(sender, e);
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Entrega de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (conBusCtaAho.idcuenta != 0)
            {
                DataTable dtOP = (DataTable)dtgSolOP.DataSource;                
                DataRow[] dtLit = dtOP.Select("lok=1");
                string cidSolicitud="";
                foreach (DataRow row in dtLit)
                {
                   cidSolicitud=cidSolicitud + row[0].ToString()+",";
                }

                DataTable dtActOP = clsOpeValorado.CNImprimirActaEntregaOP(conBusCtaAho.idcuenta, clsVarGlobal.dFecSystem, cidSolicitud,clsVarGlobal.nIdAgencia);
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("idCuenta", conBusCtaAho.idcuenta.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaEntrega", clsVarGlobal.dFecSystem.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cidSolicitud", cidSolicitud, false));
                paramlist.Add(new ReportParameter("idAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
                int nCan = cidSolicitud.LastIndexOf(",");
                cidSolicitud = cidSolicitud.Substring(0,nCan);

                paramlist.Add(new ReportParameter("cSolicitudAct", cidSolicitud, false));
               
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsActaEntrega", dtActOP));

                string reportpath = "rptActEntregaOP.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }

        }
    }
}
