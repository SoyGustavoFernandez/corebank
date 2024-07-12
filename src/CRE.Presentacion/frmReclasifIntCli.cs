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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmReclasifIntCli : frmBase
    {
        #region Variables Globales

        clsCNCalifInt cncalifica = new clsCNCalifInt();
        clsCNProvision cnprovision = new clsCNProvision();
        private const string cTituloMsjes = "Reclasificación interna de clientes";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            conBusCli.limpiarControles();
            limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;
            HabilitarControles(false);

            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCli.Focus();
            conBusCli.txtCodCli.Focus();
            conBusCli.txtCodCli.Select();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCli.limpiarControles();
            limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;

            HabilitarControles(false);

            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);

            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;

            DialogResult result;

            result = MessageBox.Show("¿Esta seguro de realizar la reclasificación?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes) return;

            int idCli = conBusCli.idCli;
            int idCalif = Convert.ToInt32(cboCalifFin.SelectedValue);
            string cObservacion = txtObservacion.Text.Trim();
            DateTime dFecRegistro = clsVarGlobal.dFecSystem.Date;
            int idUsuario = clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = cncalifica.CNGuardarClasifIntCli(idCli, idCalif, cObservacion, dFecRegistro, idUsuario);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarControles(false);

                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Procesar Provisiones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcesarProvisiones_Click(object sender, EventArgs e)
        {
            /*this.Cursor = Cursors.WaitCursor;
            DataTable resultado = cnprovision.CalcularProvicionFecha(dtpFecClasif.Value);

            string nResultado = Convert.ToString(resultado.Rows[0]["nResultado"]);
            string cMensaje = Convert.ToString(resultado.Rows[0]["cMensaje"]);

            if (nResultado == "1")
            {
                MessageBox.Show(cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                MessageBox.Show(cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }*/
        }
        /// <summary>
        /// Exportar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportarCli_Click(object sender, EventArgs e)
        {
            /*
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("x_dFecha", "01-26-2018", false));

            DataTable resultado = cnprovision.ReportarRiesgoProvisiones(clsVarGlobal.dFecSystem);
            dtslist.Add(new ReportDataSource("propiedades", resultado));


            string reportpath = "RptRiesgoClientesProvisiones.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            */
        }

        #endregion

        #region Metodos

        public frmReclasifIntCli()
        {
            InitializeComponent();
        }

        private void cargarDatos()
        {
            limpiarControles();
            HabilitarControles(false);

            if (conBusCli.idCli > 0)
            {
                cargarCalificacion();

                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                conBusCli.limpiarControles();
                conBusCli.txtCodCli.Enabled = true;
                conBusCli.btnBusCliente.Enabled = true;

                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;

                conBusCli.Focus();
                conBusCli.txtCodCli.Focus();
                conBusCli.txtCodCli.Select();
            }

            btnGrabar.Enabled = false;
        }

        private bool validar()
        {
            if (conBusCli.idCli == 0)
            {
                MessageBox.Show("Seleccione un cliente para la reclasificación", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboCalifIni.SelectedValue) == Convert.ToInt32(cboCalifFin.SelectedValue))
            {
                MessageBox.Show("La nueva calificación debe de ser distinta a la actual", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show("Ingrese el sustento para la reclasificación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void HabilitarControles(bool lHabil)
        {
            cboCalifFin.Enabled = lHabil;
            txtObservacion.Enabled = lHabil;
        }

        private void limpiarControles()
        {
            dtpFecUltClasif.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecClasif.Value = clsVarGlobal.dFecSystem.Date;
            cboCalifIni.SelectedIndex = -1;
            cboCalifFin.SelectedIndex = -1;
            txtObservacion.Text = string.Empty;
            chcTieneClasif.Checked = false;
        }

        private void cargarCalificacion()
        {
            DataTable dtCalifica = cncalifica.CNGetClasifIntCli(conBusCli.idCli);

            if (dtCalifica.Rows.Count > 0)
            {
                foreach (DataRow row in dtCalifica.Rows)
                {
                    dtpFecUltClasif.Value = Convert.ToDateTime(row["dFecSis"]);
                    cboCalifIni.SelectedValue = Convert.ToInt32(row["idClasifInterna"]);
                    chcTieneClasif.Checked = true;
                }
            }
            else
            {
                cboCalifIni.SelectedIndex = -1;
                dtpFecUltClasif.Value = clsVarGlobal.dFecSystem.Date;
                chcTieneClasif.Checked = false;
            }
        }

        #endregion
   

    }
}
