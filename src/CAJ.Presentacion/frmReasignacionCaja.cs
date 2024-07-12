using CAJ.CapaNegocio;
using EntityLayer;
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

namespace CAJ.Presentacion
{
    public partial class frmReasignacionCieCaja : frmBase
    {
        clsCNControlOpe lstReasgCaja = new clsCNControlOpe();

        public frmReasignacionCieCaja()
        {
            InitializeComponent();
        }

        private void frmReasignacionCaja_Load(object sender, EventArgs e)
        {
            ActivaBotones(true);
            ActivarControles(false);
            dtpFecOpe.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            ActivaBotones(false);
            ActivarControles(true);

            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            DataTable tbColAge = lstReasgCaja.CNListarColabAgenciasIniOpe(idAgencia, dFecIni, dFecFin);
            tbColAge.DefaultView.RowFilter = ("idUsuario<>0");

            cboColaboradorOri.ValueMember = "idUsuario";
            cboColaboradorOri.DisplayMember = "cNombre";
            cboColaboradorOri.DataSource = tbColAge;
            cboColaboradorOri.SelectedIndex = -1;

            grbBase1.Enabled = true;
            grbDestino.Enabled = true;
            LimpiarControlesDestino();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActivaBotones(true);
            ActivarControles(false);
            LimpiarControles();
        }
        private void ActivaBotones(bool lActiva)
        {
            dtpFecIni.Enabled = lActiva;
            dtpFecFin.Enabled = lActiva;
            cboAgencias1.Enabled = lActiva;
            btnBusqueda.Enabled = lActiva;
            btnCancelar.Enabled = !lActiva;
            btnTransferir1.Enabled = !lActiva;
        }
        private void ActivarControles(bool lActiva)
        {
            cboTipRespCajOri.Enabled = lActiva;
            //cboTipRespCajDes.Enabled = lActiva;
            cboFechaOpe.Enabled = lActiva;
            cboColaboradorOri.Enabled = lActiva;
            cboColaboradorDes.Enabled = lActiva;
        }
        private void LimpiarControles()
        {
            cboTipRespCajOri.DataSource = null;
            cboTipRespCajDes.DataSource = null;
            cboFechaOpe.DataSource = null;
            cboColaboradorOri.DataSource = null;
            cboColaboradorDes.DataSource = null;
            lblEstado.Text = "_";
            lblEstadoDes.Text = "_";
            rbtBidereccional.Checked = false;
            rbtUnidireccional.Checked = false;
        }
        private void LimpiarControlesDestino()
        {

            cboTipRespCajDes.DataSource = null;
            cboColaboradorDes.DataSource = null;
            lblEstadoDes.Text = "_";
            rbtBidereccional.Checked = false;
            rbtUnidireccional.Checked = false;
            txtCierreSalSolDes.Text = "0.00";
            txtCierreSalDolDes.Text = "0.00";
        }

        private void cboColaboradorOri_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboFechaOpe.DataSource = null;
            cboTipRespCajOri.DataSource = null;
            int idColaborador = Convert.ToInt32(cboColaboradorOri.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            DataTable dtFechas = lstReasgCaja.CNListaFechasOperacionXUsuario(idColaborador, idAgencia, dFecIni, dFecFin);
            cboFechaOpe.DisplayMember = "dFechaOpe";
            cboFechaOpe.ValueMember = "dFechaOpe";
            cboFechaOpe.DataSource = dtFechas;
            cboFechaOpe.SelectedIndex = -1;
            lblEstado.Text = "_";
            txtSalFinDolOri.Text = "0.00";
            txtSalFinSolOri.Text = "0.00";
            LimpiarControlesDestino();

        }
        private void cboFechaOpe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboTipRespCajOri.DataSource = null;
            int idColaborador = Convert.ToInt32(cboColaboradorOri.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            DateTime dFecOpeOri = Convert.ToDateTime(cboFechaOpe.SelectedValue);
            DataTable dtResCaja = lstReasgCaja.cargarTipRespPorUsuarioIniOpe(idColaborador, idAgencia, dFecOpeOri);
            cboTipRespCajOri.ValueMember = "idTipResCaj";
            cboTipRespCajOri.DisplayMember = "cTipResponsable";
            cboTipRespCajOri.DataSource = dtResCaja;
            cboTipRespCajOri.SelectedIndex = -1;
            lblEstado.Text = "_";
            LimpiarControlesDestino();

        }

        private void cboTipRespCajOri_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idColaborador = Convert.ToInt32(cboColaboradorOri.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            DateTime dFecOpeOri = Convert.ToDateTime(cboFechaOpe.SelectedValue);
            int idTipResCaj = Convert.ToInt32(cboTipRespCajOri.SelectedValue);

            cboTipRespCajDes.cargarTipoResponsableCajaAdm(idAgencia);

            cboTipRespCajDes.SelectedValue = idTipResCaj;
            DataTable dtSaldos = lstReasgCaja.CNListarSaldoIniCieOpe(idAgencia, dFecOpeOri, idTipResCaj, idColaborador);
            if (dtSaldos.Rows.Count > 0)
            {
                lblEstado.Text = dtSaldos.Rows[0]["cEstadoCie"].ToString();
                txtSalFinSolOri.Text = dtSaldos.Rows[0]["nMontoCieSol"].ToString();
                txtSalFinDolOri.Text = dtSaldos.Rows[1]["nMontoCieDol"].ToString();

                DataTable dtLisReasigCaj = lstReasgCaja.CNListarReasignacionCajUsu(idColaborador, idAgencia, idTipResCaj);
                if (dtLisReasigCaj.Rows.Count > 0)
                {
                    lblEstado.Text = "R";

                    //if (Convert.ToBoolean(dtLisReasigCaj.Rows[0]["lUsado"]))
                    //{
                    txtSalFinSolOri.Text = dtLisReasigCaj.Rows[0]["nMonNueSalSol"].ToString();
                    txtSalFinDolOri.Text = dtLisReasigCaj.Rows[0]["nMonNueSalDol"].ToString();
                    //}                   

                    grbDestino.Enabled = false;
                    MessageBox.Show("El colaborador aún tiene caja reasignada \n debe iniciar y cerrar con ese saldo...", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                cboTipRespCajDes_SelectionChangeCommitted(sender, e);

                if (lblEstado.Text.Equals("A"))
                {
                    grbDestino.Enabled = false;
                    MessageBox.Show("El colaborador aún tiene caja abierta \n debe cerrar para realizar la reasignación...", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    grbDestino.Enabled = true;
                }
                if (idTipResCaj == 3)
                {
                    rbtUnidireccional.Checked = true;
                    rbtBidereccional.Enabled = false;
                }
                else
                {
                    rbtBidereccional.Checked = false;
                    rbtUnidireccional.Checked = false;
                    rbtBidereccional.Enabled = true;
                }
            }
        }

        private void cboTipRespCajDes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string msg = "";
            string idTipResCaj = cboTipRespCajDes.SelectedValue.ToString();
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            string idUsuOri = cboColaboradorOri.SelectedValue.ToString();
            DataTable tbTipRes = lstReasgCaja.LisRespHab(5, idAgencia, idTipResCaj, 0, ref msg, Convert.ToDateTime(dtpFecOpe.Value));

            if (msg == "OK")
            {
                tbTipRes.DefaultView.RowFilter = ("idUsuario <> " + idUsuOri);
                cboColaboradorDes.ValueMember = "idUsuario";
                cboColaboradorDes.DisplayMember = "cNombre";
                cboColaboradorDes.DataSource = tbTipRes;
                cboColaboradorDes.SelectedIndex = -1;

                lblEstadoDes.Text = "_";
                txtCierreSalSolDes.Text = "0.00";
                txtCierreSalDolDes.Text = "0.00";
                dtpFecOpe.Value = clsVarGlobal.dFecSystem;
                rbtBidereccional.Checked = false;
                rbtUnidireccional.Checked = false;
                rbtUnidireccional.Visible = true;
                rbtBidereccional.Visible = true;
                dtpFecOpe.Visible = true;

                lblBase20.Visible = true;
                lblBase10.Visible = true;
                lblBase13.Visible = true;
                txtCierreSalDolDes.Visible = true;
                txtCierreSalSolDes.Visible = true;

            }
            else
            {
                MessageBox.Show(msg, "Responsables de habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cboColaboradorDes_SelectionChangeCommitted(object sender, EventArgs e)
        {


            int idTipResCaj = Convert.ToInt32(cboTipRespCajDes.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            int idColaboraDes = Convert.ToInt32(cboColaboradorDes.SelectedValue);
            DataTable tbUltOper = lstReasgCaja.CNListarUltOperacionUsuTipRes(idColaboraDes, idAgencia, idTipResCaj);
            if (tbUltOper.Rows.Count > 0)
            {
                lblEstadoDes.Text = tbUltOper.Rows[0]["cEstadoCie"].ToString();
                txtCierreSalSolDes.Text = tbUltOper.Rows[0]["nMontoCieSol"].ToString();
                txtCierreSalDolDes.Text = tbUltOper.Rows[1]["nMontoCieDol"].ToString();
                dtpFecOpe.Value = Convert.ToDateTime(tbUltOper.Rows[0]["dFechaOpe"]);

                DataTable dtLisReasigCaj = lstReasgCaja.CNListarReasignacionCajUsu(idColaboraDes, idAgencia, idTipResCaj);
                if (dtLisReasigCaj.Rows.Count > 0)
                {
                    lblEstadoDes.Text = "R";

                    txtCierreSalSolDes.Text = dtLisReasigCaj.Rows[0]["nMonNueSalSol"].ToString();
                    txtCierreSalDolDes.Text = dtLisReasigCaj.Rows[0]["nMonNueSalDol"].ToString();

                    grbDestino.Enabled = false;
                    MessageBox.Show("El colaborador aún tiene caja reasignada \n debe iniciar y cerrar con ese saldo...", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                rbtUnidireccional.Visible = true;
                rbtBidereccional.Visible = true;
                dtpFecOpe.Visible = true;

                lblBase20.Visible = true;
                lblBase10.Visible = true;
                lblBase13.Visible = true;
                txtCierreSalDolDes.Visible = true;
                txtCierreSalSolDes.Visible = true;

                rbtBidereccional.Checked = false;
                rbtUnidireccional.Checked = false;

                if (lblEstadoDes.Text.Equals("A"))
                {
                    btnTransferir1.Enabled = false;
                    MessageBox.Show("El colaborador aún tiene caja abierta \n debe cerrar para realizar la reasignación...", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    btnTransferir1.Enabled = true;
                }

            }
            else
            {
                lblEstadoDes.Text = "SIN OPERACIONES";
                rbtUnidireccional.Checked = true;

                rbtUnidireccional.Visible = true;
                rbtBidereccional.Visible = false;
                dtpFecOpe.Visible = false;
                btnTransferir1.Enabled = true;
                lblBase20.Visible = false;
                lblBase10.Visible = false;
                lblBase13.Visible = false;
                txtCierreSalDolDes.Visible = false;
                txtCierreSalSolDes.Visible = false;
            }
        }

        private void btnTransferir1_Click(object sender, EventArgs e)
        {
            if (cboColaboradorDes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir al colaborador destino", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!rbtBidereccional.Checked && !rbtUnidireccional.Checked)
            {
                MessageBox.Show("Debe elegir el tipo de resignación", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTipReasignacion = rbtUnidireccional.Checked ? 1 : 2;
            int idAgenciaOpe = Convert.ToInt32(cboAgencias1.SelectedValue);
            int idUsuOri = Convert.ToInt32(cboColaboradorOri.SelectedValue);
            int idTipResCajOri = Convert.ToInt32(cboTipRespCajOri.SelectedValue);
            DateTime dFecOperaOri = Convert.ToDateTime(cboFechaOpe.SelectedValue);

            int idUsuDes = Convert.ToInt32(cboColaboradorDes.SelectedValue);
            int idTipResCajDes = Convert.ToInt32(cboTipRespCajDes.SelectedValue);
            DateTime dFecOpeDes = dtpFecOpe.Value;
            DateTime dFecReasigna = clsVarGlobal.dFecSystem;
            int idUsuReasigna = clsVarGlobal.User.idUsuario;
            int idAgeReasigna = clsVarGlobal.nIdAgencia;

            decimal nMonSalAntSolOri;
            decimal nMonSalAntDolOri;
            decimal nMonNueSalSolOri;
            decimal nMonNueSalDolOri;

            decimal? nMonSalAntSolDes = null;
            decimal? nMonSalAntDolDes = null;
            decimal nMonNueSalSolDes = 0;
            decimal nMonNueSalDolDes = 0;

            if (idTipReasignacion == 1)
            {
                nMonSalAntSolOri = Convert.ToDecimal(txtSalFinSolOri.Text);
                nMonSalAntDolOri = Convert.ToDecimal(txtSalFinDolOri.Text);
                nMonNueSalSolOri = 0;
                nMonNueSalDolOri = 0;

                nMonNueSalSolDes = Convert.ToDecimal(txtSalFinSolOri.Text) + Convert.ToDecimal(txtCierreSalSolDes.Text);
                nMonNueSalDolDes = Convert.ToDecimal(txtSalFinDolOri.Text) + Convert.ToDecimal(txtCierreSalDolDes.Text);

                if (lblEstadoDes.Text.Equals("A") || lblEstadoDes.Text.Equals("C"))
                {
                    if (Convert.ToDecimal(txtCierreSalSolDes.Text) > 0 || Convert.ToDecimal(txtCierreSalDolDes.Text) > 0)
                    {
                        nMonSalAntSolDes = Convert.ToDecimal(txtCierreSalSolDes.Text);
                        nMonSalAntDolDes = Convert.ToDecimal(txtCierreSalDolDes.Text);
                    }
                }
                else
                {
                    nMonSalAntSolDes = null;
                    nMonSalAntDolDes = null;
                }
                                

                if (nMonSalAntSolOri == 0 && nMonSalAntDolOri == 0)
                {
                    MessageBox.Show("El saldo origen en soles o dólares debe ser mayor a cero", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                nMonSalAntSolOri = Convert.ToDecimal(txtSalFinSolOri.Text);
                nMonSalAntDolOri = Convert.ToDecimal(txtSalFinDolOri.Text);
                nMonNueSalSolOri = Convert.ToDecimal(txtCierreSalSolDes.Text);
                nMonNueSalDolOri = Convert.ToDecimal(txtCierreSalDolDes.Text);

                nMonSalAntSolDes = Convert.ToDecimal(txtCierreSalSolDes.Text);
                nMonSalAntDolDes = Convert.ToDecimal(txtCierreSalDolDes.Text);
                nMonNueSalSolDes = Convert.ToDecimal(txtSalFinSolOri.Text);
                nMonNueSalDolDes = Convert.ToDecimal(txtSalFinDolOri.Text);
                if (nMonSalAntSolOri == 0 && nMonSalAntDolOri == 0 && nMonSalAntSolDes == 0 && nMonSalAntDolDes == 0)
                {
                    MessageBox.Show("Los saldos en soles o dólares deben ser mayores a cero", "Reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            DataTable dtReasigna = lstReasgCaja.CNInsertarTrasladoSaldoCaja(idTipReasignacion, idAgenciaOpe, idUsuOri, idTipResCajOri, dFecOperaOri,
                                                            nMonSalAntSolOri, nMonSalAntDolOri, nMonNueSalSolOri, nMonNueSalDolOri,
                                                            idUsuDes, idTipResCajDes, dFecOpeDes, nMonSalAntSolDes, nMonSalAntDolDes, nMonNueSalSolDes,
                                                            nMonNueSalDolDes, dFecReasigna, idUsuReasigna, idAgeReasigna);
            if (dtReasigna.Rows.Count > 0)
            {
                if (dtReasigna.Rows[0]["nResp"].ToString().Equals("1"))
                {
                    grbDestino.Enabled = false;
                    grbBase1.Enabled = false;
                    MessageBox.Show(dtReasigna.Rows[0]["cMensaje"].ToString(), "Registro de reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(dtReasigna.Rows[0]["cMensaje"].ToString(), "Registro de reasignación de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void grbDestino_Enter(object sender, EventArgs e)
        {

        }
    }
}
