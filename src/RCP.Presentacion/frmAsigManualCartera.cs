using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmAsigManualCartera : frmBase
    {
        clsCNCarteraRecupera cnCarteraRecupera = new clsCNCarteraRecupera();

        DataTable dtCreditosAsignar = new DataTable();
        DataTable dtCreditosAsignados = new DataTable();

        public frmAsigManualCartera()
        {
            InitializeComponent();
        }       

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            FrmAgregarCredAsignar frm = new FrmAgregarCredAsignar();
            frm.ShowDialog();
            if (frm.lAceptar)
            {
                DataSet dsCodigos = new DataSet();
                dsCodigos.Tables.Add(frm.dtCodigos);
                string xmlCodigos = dsCodigos.GetXml();

                dtCreditosAsignar = cnCarteraRecupera.obtenerCreditosParaAsignar(xmlCodigos);
                if (dtCreditosAsignar.Rows.Count > 0)
                {
                    dtgCreditosAsignar.DataSource = dtCreditosAsignar;
                    formatoGridCreditosAsignar();

                    txtNumeroCreditosAsignar.Text = dtgCreditosAsignar.Rows.Count.ToString();
                    txtTotalSaldoCapitalAsignar.Text = dtCreditosAsignar.Compute("Sum(nSaldoCapitalMN)", "").ToString();
                }
            }
        }

        private void cargar()
        {
            if (conBusCli1.idCli == 0)
            {
                habilitarControles(false);
                limpiarControles();
                return;
            }

            DataTable dtUsuario = cnCarteraRecupera.obtenerUsuario(conBusCli1.idCli);
            if (dtUsuario.Rows.Count > 0)
            {
                txtUsuarioAsignado.Text = txtCodigoUsuarioAsignar.Text = dtUsuario.Rows[0][0].ToString();               
            }
            else
            {
                txtUsuarioAsignado.Text = txtCodigoUsuarioAsignar.Text = "0";
            }

            dtCreditosAsignados = cnCarteraRecupera.obtenerCreditosAsignados(conBusCli1.idCli);
            if (dtCreditosAsignados.Rows.Count > 0)
            {
                dtgCreditosAsignados.DataSource = dtCreditosAsignados;
                formatoGridCreditosAsignados();
                txtNumeroCreditosAsignado.Text = dtCreditosAsignados.Rows.Count.ToString();
                txtTotalSaldoCapitalMNAsignado.Text = dtCreditosAsignados.Compute("Sum(nSaldoCapitalMN)", "").ToString();
            }
            txtPeriodoAsignado.Text = txtPeriodoAsignar.Text = clsVarGlobal.dFecSystem.Month.ToString("00") + " - " + clsVarGlobal.dFecSystem.Year.ToString("0000");
            habilitarControles(true);
        }

        private void formatoGridCreditosAsignar()
        {
            foreach (DataGridViewColumn column in this.dtgCreditosAsignar.Columns)
            {
                column.Visible = false;
                //column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCreditosAsignar.Columns["cTramo"].Visible = true;
            dtgCreditosAsignar.Columns["cEstadoContable"].Visible = true;
            dtgCreditosAsignar.Columns["nAtraso"].Visible = true;
            dtgCreditosAsignar.Columns["cNombre"].Visible = true;
            dtgCreditosAsignar.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditosAsignar.Columns["cMoneda"].Visible = true;
            dtgCreditosAsignar.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditosAsignar.Columns["nSaldoCapital"].Visible = true;
            dtgCreditosAsignar.Columns["cAsignado"].Visible = true;

            dtgCreditosAsignar.Columns["cTramo"].HeaderText = "Tramo";
            dtgCreditosAsignar.Columns["cEstadoContable"].HeaderText = "Estado contable";
            dtgCreditosAsignar.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditosAsignar.Columns["cNombre"].HeaderText = "Nombre del cliente";
            dtgCreditosAsignar.Columns["dFechaDesembolso"].HeaderText = "Fec. Desembolso";
            dtgCreditosAsignar.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditosAsignar.Columns["nCapitalDesembolso"].HeaderText = "Desembolso";
            dtgCreditosAsignar.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";
            dtgCreditosAsignar.Columns["cAsignado"].HeaderText = "Asignado";

            dtgCreditosAsignar.Columns["cTramo"].Width = 70;
            dtgCreditosAsignar.Columns["cEstadoContable"].Width = 70;
            dtgCreditosAsignar.Columns["nAtraso"].Width = 50;
            dtgCreditosAsignar.Columns["cNombre"].Width = 150;
            dtgCreditosAsignar.Columns["dFechaDesembolso"].Width = 50;
            dtgCreditosAsignar.Columns["cMoneda"].Width = 50;
            dtgCreditosAsignar.Columns["nCapitalDesembolso"].Width = 70;
            dtgCreditosAsignar.Columns["nSaldoCapital"].Width = 70;
            dtgCreditosAsignar.Columns["cAsignado"].Width = 100;
        }
        
        private void formatoGridCreditosAsignados()
        {
            foreach (DataGridViewColumn column in this.dtgCreditosAsignados.Columns)
            {
                column.Visible = false;
                //column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCreditosAsignados.Columns["cTramo"].Visible = true;
            dtgCreditosAsignados.Columns["cPeriodo"].Visible = true;
            dtgCreditosAsignados.Columns["cEstadoContable"].Visible = true;
            dtgCreditosAsignados.Columns["nAtraso"].Visible = true;
            dtgCreditosAsignados.Columns["cNombre"].Visible = true;
            dtgCreditosAsignados.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditosAsignados.Columns["cMoneda"].Visible = true;
            dtgCreditosAsignados.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditosAsignados.Columns["nSaldoCapital"].Visible = true;

            dtgCreditosAsignados.Columns["cTramo"].HeaderText = "Tramo";
            dtgCreditosAsignados.Columns["cPeriodo"].HeaderText = "Periodo";
            dtgCreditosAsignados.Columns["cEstadoContable"].HeaderText = "Estado contable";
            dtgCreditosAsignados.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditosAsignados.Columns["cNombre"].HeaderText = "Nombre del cliente";
            dtgCreditosAsignados.Columns["dFechaDesembolso"].HeaderText = "Fec. Desembolso";
            dtgCreditosAsignados.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditosAsignados.Columns["nCapitalDesembolso"].HeaderText = "Desembolso";
            dtgCreditosAsignados.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";

            //dtgCreditosAsignados.Columns["cTramo"].Width = 70;
            //dtgCreditosAsignados.Columns["cEstadoContable"].Width = 70;
            //dtgCreditosAsignados.Columns["nAtraso"].Width = 50;
            //dtgCreditosAsignados.Columns["cNombre"].Width = 150;
            //dtgCreditosAsignados.Columns["dFechaDesembolso"].Width = 50;
            //dtgCreditosAsignados.Columns["cMoneda"].Width = 50;
            //dtgCreditosAsignados.Columns["nCapitalDesembolso"].Width = 70;
            //dtgCreditosAsignados.Columns["nSaldoCapital"].Width = 70;
        }

        private void frmAsigManualCartera_Load(object sender, EventArgs e)
        {
            habilitarControles(false);
            limpiarControles();
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            cargar();
        }

        private void conBusCli1_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void habilitarControles(bool lHabilitar)
        {
            conBusCli1.Enabled = !lHabilitar;
            tabControl1.Enabled = lHabilitar;
            btnCancelar1.Enabled = lHabilitar;
            btnGrabar1.Enabled = lHabilitar;
        }

        private void limpiarControles()
        {
            txtCodigoUsuarioAsignar.Clear();
            txtUsuarioAsignado.Clear();
            txtPeriodoAsignado.Clear();
            txtPeriodoAsignar.Clear();
            txtNumeroCreditosAsignado.Clear();
            txtNumeroCreditosAsignar.Clear();
            txtTotalSaldoCapitalAsignar.Clear();
            txtTotalSaldoCapitalMNAsignado.Clear();
            dtgCreditosAsignados.DataSource = null;
            dtgCreditosAsignar.DataSource = null;
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            limpiarControles();
        }

        private void btnMiniImprimir1_Click(object sender, EventArgs e)
        {
            if (dtCreditosAsignar.Rows.Count > 0)
            {
                String cTitulo = "Crédito a asignar a " + conBusCli1.txtNombre.Text + " Periodo " + txtPeriodoAsignar.Text;
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCreditos", dtCreditosAsignar));

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramList.Add(new ReportParameter("cTitulo", cTitulo, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptAsignacionFutCarteraRecuperaciones.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();  
            }
            else
            {
                MessageBox.Show("El reporte no tiene datos que mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void btnMiniImprimir2_Click(object sender, EventArgs e)
        {
            if (dtCreditosAsignados.Rows.Count > 0)
            {
                String cTitulo = "Crédito a asignados a " + conBusCli1.txtNombre.Text + " Periodo " + txtPeriodoAsignar.Text;
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCreditos", dtCreditosAsignados));

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramList.Add(new ReportParameter("cTitulo", cTitulo, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptAsignacionCarteraRecuperaciones.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("El reporte no tiene datos que mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtCreditosAsignar.Rows.Count > 0)
            {
                DialogResult result =
                            MessageBox.Show(
                                "Se asignará "+dtCreditosAsignar.Rows.Count +" Créditos. ¿Desea continuar?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                DataSet dsCreditos = new DataSet();
                dsCreditos.Tables.Add(dtCreditosAsignar);
                string xmlCodigos = dsCreditos.GetXml();

                DataTable dtResultado = cnCarteraRecupera.AsignarCarteraAGestor(xmlCodigos, 
                                                                                Convert.ToInt32(txtCodigoUsuarioAsignar.Text), 
                                                                                conBusCli1.idCli,
                                                                                clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year.ToString("0000"),
                                                                                clsVarGlobal.PerfilUsu.idUsuario,
                                                                                clsVarGlobal.dFecSystem
                                                                                );

                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                    dtgCreditosAsignar.DataSource = null;
                    tabControl1.SelectedTab = tabPage2;
                }


            }
        }
    }
}
