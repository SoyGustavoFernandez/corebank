using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptDetalleOpe : frmBase
    {
        clsCNControlOpe ValCorFra = new clsCNControlOpe();
        public frmRptDetalleOpe()
        {
            InitializeComponent();
        }

        private void frmRptDetalleOpe_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            activarControlObjetos(this, EventoFormulario.INICIO);
            
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;

            dtpFecProc.Value = clsVarGlobal.dFecSystem;
            //--Validar si ya Realizó su corte Fraccionario
            //if (ValidarCorteFracc() == "ERROR")
            //{
            //    this.Dispose();
            //    return;
            //}
            cargarColaborador();
            cboColaborador.SelectedValue = clsVarGlobal.User.idUsuario;
            cargarTipoResponsable();
        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
            this.dtpFecProc.Value = clsVarGlobal.dFecSystem;
        }

        private string ValidarCorteFracc()
        {
            string cRpta = "OK";
            string msge = "";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFracc(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge);
            if (msge == "OK")
            {
                if (cCorFra == "0")
                {
                    MessageBox.Show("Primero debe realizar su billetaje ... por Favor..", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cRpta = "ERROR";
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFecha = this.dtpFecProc.Value;
            if (cboColaborador.SelectedValue==null)
            {
                MessageBox.Show("No existen datos del colaborador para mostrar.", "Reporte de Detalle de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTipResponsable.SelectedValue == null)
            {
                MessageBox.Show("No existen datos del tipo de responsable para mostrar.", "Reporte de Detalle de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idUsu = (int)cboColaborador.SelectedValue;
            int idAge = (int)cboAgencias.SelectedValue;
            int idTipResCaj = Convert.ToInt32(cboTipResponsable.SelectedValue);
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            DataTable dtDetOpe= new clsRPTCNCaja().CNDetallOperaciones(dFecha, idUsu, idAge, idTipResCaj);

            int idRSC = new clsCNPerfilUsu().buscarPerfil("REPRESENTANTE DE SERVICIO AL CLIENTE").FirstOrDefault().idPerfil;
            int idEDS = new clsCNPerfilUsu().buscarPerfil("EJECUTIVO DE SERVICIOS").FirstOrDefault().idPerfil;
            bool lFiltroRSC = (idPerfil == idRSC || idPerfil == idEDS) ? true : false;

            if (dtDetOpe.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Detalle de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dsKardex", dtDetOpe));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("lFiltroRSC", lFiltroRSC.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            string reportpath = "rptDetalleOpe.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }

        private void cargarColaborador()
        {
            DateTime dFecProceso = dtpFecProc.Value;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);

            DataTable tbColAge = ValCorFra.CNListarColabAgenciasIniOpe(idAgencia, dFecProceso, dFecProceso);
            tbColAge.DefaultView.RowFilter = ("idUsuario<>0");

            cboColaborador.ValueMember = "idUsuario";
            cboColaborador.DisplayMember = "cNombre";
            cboColaborador.DataSource = tbColAge;
        } 
        
        private void cargarTipoResponsable()
        {
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idUsuario = Convert.ToInt32(cboColaborador.SelectedValue);
            DataTable dtResBov = ValCorFra.cargarTipRespPorUsuarioIniOpe(idUsuario, idAgencia, dtpFecProc.Value);
            cboTipResponsable.ValueMember = dtResBov.Columns["idTipResCaj"].ToString();
            cboTipResponsable.DisplayMember = dtResBov.Columns["cTipResponsable"].ToString();
            cboTipResponsable.DataSource = dtResBov;
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarColaborador();
            cargarTipoResponsable();
        }
        
        private void dtpFecProc_ValueChanged(object sender, EventArgs e)
        {
            cargarColaborador();
            cargarTipoResponsable();
        }
        
        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTipoResponsable();
        }
    }
}
