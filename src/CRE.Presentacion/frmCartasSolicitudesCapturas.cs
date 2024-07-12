using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCartasSolicitudesCapturas : frmBase
    {
        clsCNCredito Credito = new clsCNCredito();
        DataTable dtCreditosAprobado = new DataTable("dtCreditosAprobado");

        int idCliente = 0;

        public frmCartasSolicitudesCapturas()
        {
            InitializeComponent();
        }

        private void btnPlanPago_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtCreditosAprobado.Rows.Count; i++)
            {
                int idCuenta = Convert.ToInt32(dtCreditosAprobado.Rows[i]["idCuenta"]);
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                dtslist.Add(new ReportDataSource("dtsPPG", new clsRPTCNPlanPagos().CNCronogramaPagos(idCuenta)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                paramlist.Add(new ReportParameter("nNumCredito", Convert.ToString(idCuenta), false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));
                string reportpath = "rptPlanPagoPosInt.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }         
        }

        private void btnKardexPago_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtCreditosAprobado.Rows.Count; i++)
            {
                int idCuenta = Convert.ToInt32(dtCreditosAprobado.Rows[i]["idCuenta"]);
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> listParam = new List<ReportParameter>();

                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];


                listParam.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                listParam.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                dtslist.Add(new ReportDataSource("dtsKardexPagoCre", new clsRPTCNPlanPagos().CNKardexPagos(idCuenta)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptKardexPagoCre.rdlc";
                new frmReporteLocal(dtslist, reportpath,listParam).ShowDialog();
            }
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtCreditosAprobado.Rows.Count; i++)
            {
                int idCuenta = Convert.ToInt32(dtCreditosAprobado.Rows[i]["idCuenta"]);
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> listPar = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dtsLiquidacion", new clsRPTCNCredito().CNLiquidacionJudiciales(idCuenta)));
                dtslist.Add(new ReportDataSource("dtsAgencia", new clsRPTCNAgencia().CNAgenciaUsuario(clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario)));

                listPar.Add(new ReportParameter("nNumCuenta", idCuenta.ToString(), false));
                listPar.Add(new ReportParameter("nNumAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
                listPar.Add(new ReportParameter("nNumUsuario", clsVarGlobal.User.idUsuario.ToString(), false));

                string reportpath = "rptLiquidacionJudiciales.rdlc";
                new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
            }
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
        }

        private void btnCargo_Click(object sender, EventArgs e)
        {
            frmCargoCartasSolCaptura frmCargo = new frmCargoCartasSolCaptura(dtCreditosAprobado, this.conBusCli1.txtCodCli.Text, conBusCli1.txtNroDoc.Text, conBusCli1.txtNombre.Text);
            frmCargo.ShowDialog();
        }

        private void cargarCreditosParaCaptura()
        {
            LimpiarDatos();
                        
            dtCreditosAprobado = Credito.ListarCreditosAprobadasParaCaptura(this.conBusCli1.idCli);
            dtgCreditosAprobados.DataSource = dtCreditosAprobado;
            DarFormatoGridCreditosAprobados();

            if (dtCreditosAprobado.Rows.Count!=0)
            {
                //Habilitar Botones
                btnCarta.Enabled = true;
                btnLiquidacion.Enabled = true;
                btnPlanPago.Enabled = true;
                btnKardexPago.Enabled = true;
                btnCargo.Enabled = true;
            }
            else
            {
                conBusCli1.Enabled = true;
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodCli.Focus();
            }
        }

        private void DarFormatoGridCreditosAprobados()
        {
            dtgCreditosAprobados.Columns["idSolAproba"].Visible = false;
            dtgCreditosAprobados.Columns["idCuenta"].Visible = false;
            dtgCreditosAprobados.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditosAprobados.Columns["cProducto"].HeaderText = "Producto";	
            dtgCreditosAprobados.Columns["cNroCuenta"].HeaderText = "Número de cuenta";
            dtgCreditosAprobados.Columns["cNroCuenta"].Width = 150;
            dtgCreditosAprobados.Columns["cMoneda"].Width = 120;											
        }

        private void LimpiarDatos()
        {
            //Datos del cliente
            //this.conBusCli1.limpiarControles();

            //Deshabilitar Botones
            btnCarta.Enabled = false;
            btnLiquidacion.Enabled = false;
            btnPlanPago.Enabled = false;
            btnKardexPago.Enabled = false;
            btnCargo.Enabled = false;
        }
              
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            conBusCli1.Enabled = true;
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            dtCreditosAprobado.Clear();
            dtgCreditosAprobados.DataSource = null;
        }



        private void frmCartasSolicitudesCapturas_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (this.conBusCli1.idCli == 0)
            {
                return;
            }

            cargarCreditosParaCaptura();
        }
    }
}
