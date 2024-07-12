using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class FrmImpCalendario : frmBase
    {
        #region Variables Globales

        DataTable dtPPGCred = new DataTable();
        clsRPTCNPlanPagos PPGCred = new clsRPTCNPlanPagos();
        clsFunUtiles objutiles = new clsFunUtiles();
        clsNumLetras cnnumeroletras = new clsNumLetras();
        CRE.CapaNegocio.clsCNCredito cncredito = new CapaNegocio.clsCNCredito();
        clsCNClienteVinculado clientevinculo = new clsCNClienteVinculado();
        clsCNBuscarCli cndatoscliente = new clsCNBuscarCli();
        CLI.CapaNegocio.clsCNRetDatosCliente datoscliente = new CLI.CapaNegocio.clsCNRetDatosCliente();

        #endregion

        public FrmImpCalendario()
        {
            InitializeComponent();
            conBusCuentaCli1.cTipoBusqueda = "C";
            conBusCuentaCli1.cEstado = "[5]";
        }

        #region Eventos

        private void btnImprimir1_Click(object sender, EventArgs e)
        {            
            int nNumCredito = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);

            if (nNumCredito == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente", "Reimpresion de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            dtPPGCred = PPGCred.CNCronogramaCreditoGastosNoConfirmados(nNumCredito);               
            int idcli = Convert.ToInt32(dtPPGCred.Rows[0]["idCli"]);

            dtPPGCred.Columns["nITF"].ReadOnly = false;

            for (int i = 0; i < dtPPGCred.Rows.Count; i++)
            {
                dtPPGCred.Rows[i]["nITF"] = 0;
            }
            
            dtslist.Add(new ReportDataSource("dtsPPG",dtPPGCred));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(nNumCredito)));
                                    
            if (cboRptImpCre.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Reporte para Imprimir", "Reimpresion de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboRptImpCre.Focus();
                this.cboRptImpCre.SelectAll();
            }
            else
            {
                int RPTImp = Convert.ToInt32(cboRptImpCre.SelectedValue);
                switch (RPTImp)
                {
                    case 1://Plan de pago
                        {
                            paramlist.Clear();

                            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlist.Add(new ReportParameter("idCliente", this.conBusCuentaCli1.nIdCliente.ToString(), false));
                            paramlist.Add(new ReportParameter("nNumCredito", nNumCredito.ToString(), false));
                            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
                            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

                            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(nNumCredito)));
                            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNDireccion(nNumCredito)));

                            string reportpath = "RptCalendarioCredito.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                        break;
                    case 2://Pagare
                        {
                            int idSolicitud = Convert.ToInt32(dtPPGCred.Rows[0]["idSolicitud"]);
                            int idCliente = conBusCuentaCli1.nIdCliente;

                            var dtSolitictud=cncredito.DatosImpPagare(idSolicitud);

                            cnnumeroletras.SeparadorDecimalSalida = "con ";
                            cnnumeroletras.MascaraSalidaDecimal = Convert.ToInt32(dtSolitictud.Rows[0]["idMoneda"]) == 1 ? "/100 Nuevos Soles" : "/100 Dolares Americanos";
                            string cMontoLetras = cnnumeroletras.ToCustomCardinal(Convert.ToDecimal (dtSolitictud.Rows[0]["nCapitalDesembolso"]));
                            string cFechaLugar = "Lima " + new clsCNMeses().retornarFechaDescMes();
                            dtslist.Clear();
                            paramlist.Clear();
                            dtslist.Add(new ReportDataSource("dsDatosPagare", dtSolitictud));
                            dtslist.Add(new ReportDataSource("dsRepresentante", clientevinculo.ListaClienteVinculado(idCliente)));
                            dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));

                            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                            paramlist.Add(new ReportParameter("cFechaLugar", cFechaLugar, false));
                            paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                            string reportpath = "rptPagareCredito_01.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                            dtslist.Clear();
                            paramlist.Clear();
                            dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));

                            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            paramlist.Add(new ReportParameter("cFechaLugar", cFechaLugar, false));
                            reportpath = "rptPagareCredito_02.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                        }
                        break;
                    case 3://Contrato de credito
                        {
                            int idSolicitud = Convert.ToInt32(dtPPGCred.Rows[0]["idSolicitud"]);
                            int idCliente = conBusCuentaCli1.nIdCliente;
                            var dtCliente = datoscliente.ListarDatosCli(idCliente, "O");
                            int idTipoPersona = Convert.ToInt32(dtCliente.Rows[0][0]);
                            var dtCooperativa = cndatoscliente.ListarClientes("3", clsVarApl.dicVarGen["cRUC"]);
                            int idCliCoop = Convert.ToInt32(dtCooperativa.Rows[0][0]);
                            string reportpath = "";

                            var dtSolitictud = cncredito.DatosImpPagare(idSolicitud);

                            cnnumeroletras.SeparadorDecimalSalida = "con ";
                            cnnumeroletras.MascaraSalidaDecimal = Convert.ToInt32(dtSolitictud.Rows[0]["idMoneda"]) == 1 ? "/100 Nuevos Soles" : "/100 Dolares Americanos";
                            string cMontoLetras = cnnumeroletras.ToCustomCardinal(Convert.ToDecimal (dtSolitictud.Rows[0]["nCapitalDesembolso"]));
                            dtslist.Clear();
                            paramlist.Clear();

                            //if (idTipoPersona == 1)
                            //{
                                dtslist.Add(new ReportDataSource("dsContratoNatural", cncredito.DatosImpContratoNat(idSolicitud)));
                                dtslist.Add(new ReportDataSource("dsRepresentanteCoop", cncredito.ListaRepresentanteJur(idCliCoop)));
                                dtslist.Add(new ReportDataSource("dsInterviniente", cncredito.DetalleImpPagare(idSolicitud)));
                                dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));
                                dtslist.Add(new ReportDataSource("dsRepresentanteJur", cncredito.ListaRepresentanteJur(idCliente)));

                                paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                                paramlist.Add(new ReportParameter("idCliCoop", idCliCoop.ToString(), false));
                                paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                                paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                                reportpath = "rptContrato.rdlc";
                            //}
                            //else
                            //{
                            //    dtslist.Add(new ReportDataSource("dsInterviniente", cncredito.DetalleImpPagare(idSolicitud)));
                            //    dtslist.Add(new ReportDataSource("dsRepresentanteCoop", cncredito.ListaRepresentanteJur(idCliCoop)));
                            //    dtslist.Add(new ReportDataSource("dsRepresentanteJur", cncredito.ListaRepresentanteJur(idCliente)));
                            //    dtslist.Add(new ReportDataSource("dsContratoJuridico", cncredito.DatosImpContratoJur(idSolicitud)));

                            //    paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            //    paramlist.Add(new ReportParameter("idCliCoop", idCliCoop.ToString(), false));
                            //    paramlist.Add(new ReportParameter("idCli", idCliente.ToString(), false));
                            //    paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                            //    reportpath = "rptContratoPerJuridica.rdlc";
                            //}

                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                        break;
                    case 4://Hoja resumen
                        {
                            string reportpath = "RptHojaResumen.rdlc";
                            new frmReporteLocal(dtslist, reportpath).ShowDialog();
                        }
                        break;
                    default:
                        MessageBox.Show("Seleccione el Reporte a Imprimir");
                        break;
                }
            }
        }

        private void FrmImpCalendario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.conBusCuentaCli1.LiberarCuenta();
        }

        private void btnCancelar1_Click(object sender, System.EventArgs e)
        {
            limpiar();
            this.conBusCuentaCli1.LiberarCuenta();
        }

        private void conBusCuentaCli1_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli1.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCuentaCli1.txtNroDoc.Text);
            }
        }
        #endregion

        #region Metodos

        private void limpiar()
        {
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;

            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtCodAge.Text = "";
            conBusCuentaCli1.txtCodIns.Text = "";
            conBusCuentaCli1.txtCodMod.Text = "";
            conBusCuentaCli1.txtCodMon.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";

        }

        #endregion
    }
}
