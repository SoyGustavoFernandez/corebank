using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;


namespace CAJ.Presentacion
{
    public partial class frmConsultaBilletaje : frmBase
    {
        int pnCantidad = 0;
        public frmConsultaBilletaje()
        {
            InitializeComponent();
        }

        #region eventos
        private void frmCorteFraccionario_Load(object sender, EventArgs e)
        {
           

            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            DatosUsuario();
            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No Existe Usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grbBase1.Enabled = false;
                return;
            }
            this.dtpProceso.Value = clsVarGlobal.dFecSystem;
            cboTipResponsableCaja1.cargarTipoResponsableCajaOpe(Convert.ToInt32(cboAgencias.SelectedValue), clsVarGlobal.dFecSystem);

            int nValResBov = ValidaRespBoveda();
            //para ventanilla solo permite ver sus operaciones
            if (nValResBov == 1 && pnCantidad == 1)
            {
                cboColaborador.Enabled = false;
                cboTipResponsableCaja1.Enabled = false;
                cboAgencias.Enabled = false;
                
            }
            else
            {
                cboColaborador.Enabled = true;
                cboTipResponsableCaja1.Enabled = true;
                cboAgencias.Enabled = false;

                //El responsable de boveda puede visualizar de otras agencias
                //if (EsResponsableBoveda)
                //{
                //    cboAgencias1.Enabled = true;
                   
                //}
                //else
                //{
                //    cboAgencias1.Enabled = false;
                //}
            }
            //DataTable dtNeuvo = (DataTable)cboAgencias1.DataSource;
            //DataRow[] foundTipoAge = dtNeuvo.Select("idTipoOficina = 1 AND idAgencia='"+cboAgencias1.SelectedValue.ToString()+"'");
            //if (foundTipoAge.Length != 0)
            //{
            //    cboAgencias1.Enabled = true;
            //}
            //cboAgencias1.Enabled = true;
            cboTipResponsableCaja1.SelectedValue = nValResBov;
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DateTime dFecha = Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString());
            int idUsu = Convert.ToInt32(this.cboColaborador.SelectedValue.ToString());
            int idAge = Convert.ToInt32(cboAgencias.SelectedValue);
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            dtslist.Add(new ReportDataSource("dsCorteFracc", new clsRPTCNCaja().CNCorteFracc(dFecha, idUsu, idAge, idTipResCaja)));
            string reportpath = "rptCorteFracc.rdlc";
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            new frmReporteLocal(dtslist, reportpath, param).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar un Colaborador", "Consultar Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar un Colaborador", "Consultar Billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //--Reiniciar Valores
            this.txtMonMoneda.Text = "0.00";
            this.txtMonBillete.Text = "0.00";
            this.txtMonTotal.Text = "0.00";
            this.txtBillDol.Text = "0.00";
            this.txtTotDolar.Text = "0.00";
            //--Cargar Datos del Billetaje
            ListarMonedaSoles(2);
            ListarBilleteSoles(2);
            ListarBilleteDolar(2);
            SumaMonSol();

            if (this.dtgMonedas.Rows.Count > 0)
            {
                this.btnImprimir.Enabled = true;
            }
            if (this.dtgBilletes.Rows.Count > 0)
            {
                this.btnImprimir.Enabled = true;
            }
            if (this.dtgBillDolares.Rows.Count > 0)
            {
                this.btnImprimir.Enabled = true;
            }
        }
        #endregion

        #region metodos
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

        }

        private void ListarColAgencia(string cTipRes, int idAge)
        {
            //clsCNControlOpe LisColAge = new clsCNControlOpe();
            //DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);
            //this.cboColaborador.DataSource = tbColAge;
            //this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            //this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            //if (tbColAge.Rows.Count > 0)
            //{
            //    this.cboColaborador.Enabled = true;
            //}
            //else
            //{
            //    this.cboColaborador.Enabled = false;
            //}

            string msg = "";
            DateTime dtFecConsulta = dtpProceso.Value;
            clsCNControlOpe LisColAge = new clsCNControlOpe();

            DataTable tbColAge = LisColAge.LisRespHab(5, idAge, cTipRes, clsVarGlobal.User.idUsuario, ref msg, dtFecConsulta);

            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();

        }

        private void ListarMonedaSoles(int nOpc)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                return;
            }
            string msge = "";
            clsCNControlOpe LisMonSol = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            DataTable tbMonSol = LisMonSol.ListarCorteFrac(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), Convert.ToInt32(this.cboColaborador.SelectedValue.ToString()),Convert.ToInt32(cboAgencias.SelectedValue), 1, 1, idTipResCaja, ref msge);
            if (msge == "OK")
            {
                this.dtgMonedas.DataSource = tbMonSol;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtMonMoneda.Text = tbMonSol.Compute("SUM(nTotal)", "").ToString();
        }

        private void ListarBilleteSoles(int nOpc)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                return;
            }
            string msge = "";
            clsCNControlOpe LisBillSol = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            DataTable tbBillSol = LisBillSol.ListarCorteFrac(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), Convert.ToInt32(this.cboColaborador.SelectedValue.ToString()), Convert.ToInt32(cboAgencias.SelectedValue), 1, 2, idTipResCaja, ref msge);
            if (msge == "OK")
            {
                this.dtgBilletes.DataSource = tbBillSol;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de Billetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.txtMonBillete.Text = tbBillSol.Compute("SUM(nTotal)", "").ToString();
        }

        private void ListarBilleteDolar(int nOpc)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                return;
            }
            string msge = "";
            clsCNControlOpe LisBillDol = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            DataTable tbBillDol = LisBillDol.ListarCorteFrac(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), Convert.ToInt32(this.cboColaborador.SelectedValue.ToString()), Convert.ToInt32(cboAgencias.SelectedValue), 2, 2, idTipResCaja, ref msge);
            if (msge == "OK")
            {
                this.dtgBillDolares.DataSource = tbBillDol;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Billetes en Dólares", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.txtBillDol.Text = tbBillDol.Compute("SUM(nTotal)", "").ToString();
            this.txtTotDolar.Text = (this.txtBillDol.Text.Trim() == "") ? "0.00" : this.txtBillDol.Text;
        }

        private void SumaMonSol()
        {
            this.txtMonMoneda.Text = (this.txtMonMoneda.Text.Trim().Equals("")) ? "0.00" : this.txtMonMoneda.Text;
            this.txtMonBillete.Text = (this.txtMonBillete.Text.Trim().Equals("")) ? "0.00" : this.txtMonBillete.Text;
            this.txtMonTotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtMonMoneda.Text) + Convert.ToDecimal (this.txtMonBillete.Text)), 2));
        }
        bool EsResponsableBoveda=false;
        private int ValidaRespBoveda()
        {

            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipResCaja = 0;//Responsable de bóveda

            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }
            DataRow[] foundAuthors = dtResBov.Select("idTipResCaj = 3");
            if (foundAuthors.Length != 0)
            {
               EsResponsableBoveda=true;
            }

            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

           
        }
        #endregion

        private void cboTipResponsableCaja1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboColaborador.SelectedIndex = -1;
           
            if (cboTipResponsableCaja1.SelectedIndex > -1)
            {
                string cTxtTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                if (!cTxtTipResCaj.Equals("System.Data.DataRowView"))
                {
                    string idTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                    ListarColAgencia(idTipResCaj, Convert.ToInt32(cboAgencias.SelectedValue));
                    cboColaborador.SelectedValue = clsVarGlobal.User.idUsuario;

                }               
            }
            
            limpiarGrid();
        }
        private void limpiarGrid()
        {
            DataTable dtBil;
            dtBil = (DataTable)dtgBilletes.DataSource;
            if (dtBil != null)
            {
                dtgBilletes.DataSource = dtBil.Clone();
            }
            DataTable dtMon;
            dtMon = (DataTable)dtgMonedas.DataSource;
            if (dtBil != null)
            {
                dtgMonedas.DataSource = dtMon.Clone();
            }
            DataTable dtBilDol;
            dtBilDol = (DataTable)dtgBillDolares.DataSource;
            if (dtBilDol != null)
            {
                dtgBillDolares.DataSource = dtBilDol.Clone();
            }
        }
        private void dtpProceso_ValueChanged(object sender, EventArgs e)
        {
            //carga el tipo re responsable de caja
            DateTime dFecOperacion = dtpProceso.Value;
            cboTipResponsableCaja1.cargarTipoResponsableCajaOpe(Convert.ToInt32(cboAgencias.SelectedValue), dFecOperacion);
            cboColaborador.DataSource = null;
            cboTipResponsableCaja1_SelectedIndexChanged(sender, e);
        }

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarGrid();
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

        private void cboAgencias1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtpProceso_ValueChanged(sender,e);
        }
    }
}
