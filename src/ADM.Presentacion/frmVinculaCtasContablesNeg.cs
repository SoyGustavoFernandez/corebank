using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmVinculaCtasContablesNeg : frmBase
    {
        clsCNPlantillaCuentaAsiento PlantillaCuentaAsiento = new clsCNPlantillaCuentaAsiento();
        DataTable dtPlantillaCtaCtb = new DataTable();
        int idCentroCosto = 0;

        public frmVinculaCtasContablesNeg()
        {
            InitializeComponent();
        }

        private void frmVinculaCtasContablesNeg_Load(object sender, EventArgs e)
        {
            clsCNTipoAfectacionCuentaCtb TipoAfectacionCuentaCtb = new clsCNTipoAfectacionCuentaCtb();

            cboCondicionContable.SelectedIndexChanged -= new EventHandler(cboCondicionContable_SelectedIndexChanged);
            cboCondicionContable.ListarCondicionContable(0);
            cboCondicionContable.SelectedIndexChanged += new EventHandler(cboCondicionContable_SelectedIndexChanged);

            cboTipoOperacion.SelectedIndexChanged -= new EventHandler(cboTipoOperacion_SelectedIndexChanged);
            cboTipoOperacion.LisTipoOperacProduc(0);
            cboTipoOperacion.SelectedIndexChanged += new EventHandler(cboTipoOperacion_SelectedIndexChanged);


            DataTable dtTipoAfectacionDebe = TipoAfectacionCuentaCtb.CNListarTipoAfectacionCuentaCtb();
            cboTipoAfectacionDebe.DataSource = dtTipoAfectacionDebe;
            cboTipoAfectacionDebe.ValueMember = dtTipoAfectacionDebe.Columns["idTipoAfectacion"].ToString();
            cboTipoAfectacionDebe.DisplayMember = dtTipoAfectacionDebe.Columns["cDesTipoAfectacion"].ToString();

            DataTable dtTipoAfectacionHaber = TipoAfectacionCuentaCtb.CNListarTipoAfectacionCuentaCtb();
            cboTipoAfectacionHaber.DataSource = dtTipoAfectacionHaber;
            cboTipoAfectacionHaber.ValueMember = dtTipoAfectacionHaber.Columns["idTipoAfectacion"].ToString();
            cboTipoAfectacionHaber.DisplayMember = dtTipoAfectacionHaber.Columns["cDesTipoAfectacion"].ToString();

            if (cboModulo.Items.Count > 0)
            {
                cboModulo.SelectedIndex = 0;
            }
            HabilitarControles(false);
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProducto.ValueMember = "";
            cboProducto.DisplayMember = "";
            cboProducto.DataSource = null;
            int nivelProd;
            nivelProd = (int)cboModulo.SelectedValue == 3 ? 2 : 4;

            cboProducto.CargarProductoModNivel((int)cboModulo.SelectedValue, nivelProd);
            if (cboProducto.Items.Count == 0)
            {
                cboCondicionContable.ValueMember = "";
                cboCondicionContable.DisplayMember = "";
                cboCondicionContable.DataSource = null;
                cboTipoPersona.ValueMember = "";
                cboTipoPersona.DisplayMember = "";
                cboTipoPersona.DataSource = null;
                cboTipoOperacion.ValueMember = "";
                cboTipoOperacion.DisplayMember = "";
                cboTipoOperacion.DataSource = null;
                cboCanal.ValueMember = "";
                cboCanal.DisplayMember = "";
                cboCanal.DataSource = null;
                cboTipoPago.ValueMember = "";
                cboTipoPago.DisplayMember = "";
                cboTipoPago.DataSource = null;
                cboConcepto.ValueMember = "";
                cboConcepto.DisplayMember = "";
                cboConcepto.DataSource = null;
                cboMotivoOperacion.ValueMember = "";
                cboMotivoOperacion.DisplayMember = "";
                cboMotivoOperacion.DataSource = null;
                CargarPlantillaCtaCtb();
            }
            if ((int)cboModulo.SelectedValue == 1 || (int)cboModulo.SelectedValue == 2)
            {
                cboMotivoOperacion.Visible = true;
                lblMotOpe.Visible = true;
            }
            else
            {
                cboMotivoOperacion.Visible = false;
                lblMotOpe.Visible = false;
            }
        }

        private void HabCentroCosto(Boolean Hab)
        {
            lblCentroCosto.Visible = Hab;
            txtDescCentroCosto.Visible = Hab;
            btnAddCentroCosto.Visible = Hab;
            if (!Hab)
            {
                idCentroCosto = 0;
                txtDescCentroCosto.Text = "";
            }
        }
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.ValueMember == "" || cboProducto.DisplayMember == "")
            {
                return;
            }

            if (Convert.ToInt32(cboProducto.SelectedValue) == 123 || Convert.ToInt32(cboProducto.SelectedValue) == 129 || Convert.ToInt32(cboProducto.SelectedValue) == 121)
            {
                HabCentroCosto(true);
            }
            else
            {
                HabCentroCosto(false);
            }

            cboCondicionContable.ValueMember = "";
            cboCondicionContable.DisplayMember = "";
            cboCondicionContable.DataSource = null;
            cboCondicionContable.ListarCondicionContable((int)cboProducto.SelectedValue);
            cboTipoPersona.ValueMember = "";
            cboTipoPersona.DisplayMember = "";
            cboTipoPersona.DataSource = null;
            cboTipoPersona.TipoPersonaProducto((int)cboProducto.SelectedValue);
            cboTipoOperacion.ValueMember = "";
            cboTipoOperacion.DisplayMember = "";
            cboTipoOperacion.DataSource = null;
            cboTipoOperacion.LisTipoOperacProduc((int)cboProducto.SelectedValue);
            
            cboMotivoOperacion.ValueMember = "";
            cboMotivoOperacion.DisplayMember = "";
            cboMotivoOperacion.DataSource = null;

            if (cboTipoOperacion.Items.Count == 0)
            {
                cboCanal.ValueMember = "";
                cboCanal.DisplayMember = "";
                cboCanal.DataSource = null;
                cboTipoPago.ValueMember = "";
                cboTipoPago.DisplayMember = "";
                cboTipoPago.DataSource = null;
                cboConcepto.ValueMember = "";
                cboConcepto.DisplayMember = "";
                cboConcepto.DataSource = null;
                CargarPlantillaCtaCtb();
            }
        }

        private void cboCondicionContable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcepto.ValueMember == "" || cboConcepto.DisplayMember == "")
            {
                return;
            }

            if (cboCondicionContable.ValueMember == "" || cboCondicionContable.DisplayMember == "")
            {
                return;
            }

            CargarPlantillaCtaCtb();
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcepto.ValueMember == "" || cboConcepto.DisplayMember == "")
            {
                return;
            }

            if (cboTipoPersona.ValueMember == "" || cboTipoPersona.DisplayMember == "")
            {
                return;
            }

            CargarPlantillaCtaCtb();
        }

        private void cboTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOperacion.ValueMember == "" || cboTipoOperacion.DisplayMember == "")
            {
                return;
            }
            cboCanal.ValueMember = "";
            cboCanal.DisplayMember = "";
            cboCanal.DataSource = null;
            cboCanal.ListarCanalTipOpe((int)cboTipoOperacion.SelectedValue);
            int indice = cboTipoOperacion.SelectedIndex;

            string idTipoOpe = cboTipoOperacion.dtOperacion.Rows[indice]["idTipoOperacion"].ToString();


            cboMotivoOperacion.ListarMotivoOperacionCNT(Convert.ToInt32(idTipoOpe));
            //cboMotivoOperacion.SelectedIndex = -1;
            if (cboCanal.Items.Count == 0)
            {
                cboTipoPago.ValueMember = "";
                cboTipoPago.DisplayMember = "";
                cboTipoPago.DataSource = null;
                cboConcepto.ValueMember = "";
                cboConcepto.DisplayMember = "";
                cboConcepto.DataSource = null;
                CargarPlantillaCtaCtb();
            }

        }

        private void cboCanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCanal.ValueMember == "" || cboCanal.DisplayMember == "")
            {
                return;
            }

            cboTipoPago.ValueMember = "";
            cboTipoPago.DisplayMember = "";
            cboTipoPago.DataSource = null;
            cboTipoPago.ListarTipPagCanal((int)cboCanal.SelectedValue);
            if (cboTipoPago.Items.Count == 0)
            {
                cboConcepto.ValueMember = "";
                cboConcepto.DisplayMember = "";
                cboConcepto.DataSource = null;
                CargarPlantillaCtaCtb();
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.ValueMember == "" || cboTipoPago.DisplayMember == "")
            {
                return;
            }

            cboConcepto.ValueMember = "";
            cboConcepto.DisplayMember = "";
            cboConcepto.DataSource = null;
            if ((int)cboModulo.SelectedValue == 3)
            {

                if ((int)cboProducto.SelectedValue == 119 || (int)cboProducto.SelectedValue == 120)
                {
                    cboConcepto.ListarConcepTipPag((int)cboTipoPago.SelectedValue);
                }
                else
                {
                    cboConcepto.ListarConcepRecTipPag((int)cboTipoPago.SelectedValue);
                }
            }
            else
            {
                cboConcepto.ListarConcepTipPag((int)cboTipoPago.SelectedValue);
            }
        }

        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConcepto.ValueMember == "" || cboConcepto.DisplayMember == "")
            {
                return;
            }
            if (((int)cboModulo.SelectedValue == 1 & cboConcepto.Text == "INTERES DIA")
                || ((int)cboModulo.SelectedValue == 1 & cboConcepto.Text == "INTERES ADELANTADO AÑO")
                || ((int)cboModulo.SelectedValue == 1 & cboConcepto.Text == "INTERES POR CANCELACIÓN ANTICIPADA"))
            {
                lblCalifacacion.Visible = true;
                cboCalificacion1.Visible = true;
                cboCalificacion1.SelectedValue = 0;
            }
            else
            {
                lblCalifacacion.Visible = false;
                cboCalificacion1.Visible = false;
                cboCalificacion1.SelectedValue = 0;
            }
            CargarPlantillaCtaCtb();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //if (btnAddCentroCosto.Visible && idCentroCosto == 0)
            //{
            //    MessageBox.Show("Debe registrar un centro de costo", "Valida centro de costo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (cboProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir un producto", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTipoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir el tipo de operación", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboCanal.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir el tipo de canal", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir el tipo de pago", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboConcepto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir el concepto", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTipoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir el tipo de operación", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActualizarPlantillaCtaCtb();
            CargarPlantillaCtaCtb();
            HabilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarPlantillaCtaCtb();
            HabilitarControles(false);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe elegir un producto", "Valida asignación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow dr = dtPlantillaCtaCtb.NewRow();
            dr["cCtaDebe"] = "";
            dr["cTipSegDebe"] = "";
            dr["cCtaHaber"] = "";
            dr["cTipSegHaber"] = "";
            //            dr["cCentroCosto"] = "";

            dtPlantillaCtaCtb.Rows.Add(dr);

            if (dtPlantillaCtaCtb.Rows.Count == 1)
            {
                dtPlantillaCtaCtb.Columns["cCtaDebe"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cTipSegDebe"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cCtaHaber"].ReadOnly = false;
                dtPlantillaCtaCtb.Columns["cTipSegHaber"].ReadOnly = false;
                //               dtPlantillaCtaCtb.Columns["cCentroCosto"].ReadOnly = false;

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgPlantillaCtaCtb.Rows.Count > 0)
            {
                this.dtgPlantillaCtaCtb.Rows.Remove(dtgPlantillaCtaCtb.CurrentRow);
                this.dtgPlantillaCtaCtb.Refresh();
            }
        }

        private void dtgPlantillaCtaCtb_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HabilitarControles(bool lHabilitar)
        {
            btnEditar.Enabled = !lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;

            btnAgregar.Enabled = lHabilitar;
            btnQuitar.Enabled = lHabilitar;

            cboModulo.Enabled = !lHabilitar;
            cboProducto.Enabled = !lHabilitar;
            cboCondicionContable.Enabled = !lHabilitar;
            cboTipoPersona.Enabled = !lHabilitar;
            cboTipoOperacion.Enabled = !lHabilitar;
            cboCanal.Enabled = !lHabilitar;
            cboTipoPago.Enabled = !lHabilitar;
            cboConcepto.Enabled = !lHabilitar;
            cboCalificacion1.Enabled = !lHabilitar;
            cboMotivoOperacion.Enabled = !lHabilitar;
            dtgPlantillaCtaCtb.ReadOnly = !lHabilitar;
            if (dtPlantillaCtaCtb.Rows.Count > 0)
            {
                dtPlantillaCtaCtb.Columns["cCtaDebe"].ReadOnly = !lHabilitar;
                dtPlantillaCtaCtb.Columns["cTipSegDebe"].ReadOnly = !lHabilitar;
                dtPlantillaCtaCtb.Columns["cCtaHaber"].ReadOnly = !lHabilitar;
                dtPlantillaCtaCtb.Columns["cTipSegHaber"].ReadOnly = !lHabilitar;
                //              dtPlantillaCtaCtb.Columns["cCentroCosto"].ReadOnly = lHabilitar;
            }

        }

        private void CargarPlantillaCtaCtb()
        {
            int idModulo = (cboModulo.Items.Count > 0 ? (int)cboModulo.SelectedValue : 0);
            int idProducto = (cboProducto.Items.Count > 0 ? (int)cboProducto.SelectedValue : 0);
            int idCondicionContable = (cboCondicionContable.Items.Count > 0 ? (int)cboCondicionContable.dtCondicionContable.Rows[cboCondicionContable.SelectedIndex]["idCondicionContable"] : 0);
            int idTipoPersona = (cboTipoPersona.Items.Count > 0 ? (int)cboTipoPersona.dtTipoPersona.Rows[cboTipoPersona.SelectedIndex]["idTipoPersona"] : 0);
            int idTipoOperacion = (cboTipoOperacion.Items.Count > 0 ? (int)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["idTipoOperacion"] : 0);
            int idCanal = (cboCanal.Items.Count > 0 ? (int)cboCanal.dtCanal.Rows[cboCanal.SelectedIndex]["idCanal"] : 0);
            int idTipoPago = (cboTipoPago.Items.Count > 0 ? (int)cboTipoPago.dtTipoPago.Rows[cboTipoPago.SelectedIndex]["idTipoPago"] : 0);
            int idConcepto = (cboConcepto.Items.Count > 0 ? (int)cboConcepto.dtConcepto.Rows[cboConcepto.SelectedIndex]["idConcepto"] : 0);
            int idTipoAsiento = (cboTipoOperacion.Items.Count > 0 ? (int)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["idTipoAsiento"] : 0);
            int idCalifica = (int)cboCalificacion1.SelectedValue;
            //if (cboMotivoOperacion.SelectedIndex != -1)
            //{
                
            //}
            int idMotivoOpe = cboMotivoOperacion.Items.Count > 0 ? (int)cboMotivoOperacion.SelectedValue : 0;
            dtPlantillaCtaCtb = PlantillaCuentaAsiento.CNListarPlantillaCuentaAsiento(idModulo, idProducto, idCondicionContable,
                                                                                      idTipoPersona, idTipoOperacion, idCanal,
                                                                                      idTipoPago, idConcepto, idTipoAsiento,
                                                                                      idCalifica, idCentroCosto, idMotivoOpe);

            dtgPlantillaCtaCtb.DataSource = dtPlantillaCtaCtb;
        }

        private void ActualizarPlantillaCtaCtb()
        {
            int idModulo = (int)cboModulo.SelectedValue;
            int idProducto = (int)cboProducto.SelectedValue;
            int idCondicionContable = 0;
            int idTipoPersona = 0;
            if (cboCondicionContable.Items.Count > 0)
            {
                idCondicionContable = (int)cboCondicionContable.dtCondicionContable.Rows[cboCondicionContable.SelectedIndex]["idCondicionContable"];
            }
            if (cboTipoPersona.Items.Count > 0)
            {
                idTipoPersona = (int)cboTipoPersona.dtTipoPersona.Rows[cboTipoPersona.SelectedIndex]["idTipoPersona"];
            }

            int idTipoOperacion = (int)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["idTipoOperacion"];
            int idCanal = (int)cboCanal.dtCanal.Rows[cboCanal.SelectedIndex]["idCanal"];
            int idTipoPago = (int)cboTipoPago.dtTipoPago.Rows[cboTipoPago.SelectedIndex]["idTipoPago"];
            int idConcepto = (int)cboConcepto.dtConcepto.Rows[cboConcepto.SelectedIndex]["idConcepto"];
            int idTipoAsiento = (int)cboTipoOperacion.dtOperacion.Rows[cboTipoOperacion.SelectedIndex]["idTipoAsiento"];

            int idCalifica = (int)cboCalificacion1.SelectedValue;
            int idMontivoOperacion = 0;
            if (cboMotivoOperacion.SelectedIndex > -1)
            {
                idMontivoOperacion = (int)cboMotivoOperacion.SelectedValue == null ? 0 : (int)cboMotivoOperacion.SelectedValue;
            }
            ;
            DataSet dsPlantillaCtaCtb = new DataSet("dsPlantillaCtaCtb");
            dsPlantillaCtaCtb.Tables.Add(dtPlantillaCtaCtb);
            string xmlPlantillaCtaCtb = dsPlantillaCtaCtb.GetXml();
            xmlPlantillaCtaCtb = clsCNFormatoXML.EncodingXML(xmlPlantillaCtaCtb);
            dsPlantillaCtaCtb.Tables.Clear();

            DataTable dtActPlantilla = PlantillaCuentaAsiento.CNActualizaPlantillaCuentaAsiento(idModulo, idProducto, idCondicionContable,
                                                                                         idTipoPersona, idTipoOperacion, idCanal,
                                                                                         idTipoPago, idConcepto, idTipoAsiento,
                                                                                         xmlPlantillaCtaCtb, idCalifica, idCentroCosto, idMontivoOperacion);
            if (dtActPlantilla.Rows[0]["idRpta"].ToString().Equals("0"))
            {
                MessageBox.Show(dtActPlantilla.Rows[0]["cMensage"].ToString(), "Asignación de Cuentas Contables",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtActPlantilla.Rows[0]["cMensage"].ToString(), "Asignación de Cuentas Contables",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboCalificacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCalificacion1.ValueMember == "" || cboCalificacion1.DisplayMember == "")
            {
                return;
            }
            CargarPlantillaCtaCtb();
        }

        private void dtgPlantillaCtaCtb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPlantillaCtaCtb.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgPlantillaCtaCtb.Columns[e.ColumnIndex].DisplayIndex) == 0)
            {

                frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                frmBscCtaCtb.ShowDialog();
                if (btnEditar.Enabled == false)
                {
                    if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                    dtgPlantillaCtaCtb.CurrentRow.Cells["txtCtaCtbDebe"].Value = frmBscCtaCtb.pcCtaCtb;
                }

            }
            if (dtgPlantillaCtaCtb.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgPlantillaCtaCtb.Columns[e.ColumnIndex].DisplayIndex) == 3)
            {

                frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
                frmBscCtaCtb.ShowDialog();
                if (btnEditar.Enabled == false)
                {
                    if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
                    dtgPlantillaCtaCtb.CurrentRow.Cells["txtCtaCtbHaber"].Value = frmBscCtaCtb.pcCtaCtb;
                }
            }
        }

        private void btnAddCentroCosto_Click(object sender, EventArgs e)
        {
            frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto();
            frmBuscaCtrCosto.ShowDialog();
            if (frmBuscaCtrCosto.pnidCentroCosto == 0)
            {
                idCentroCosto = 0;
                txtDescCentroCosto.Text = "";
            }
            else
            {
                idCentroCosto = frmBuscaCtrCosto.pnidCentroCosto;
                txtDescCentroCosto.Text = frmBuscaCtrCosto.pcNombreCentroCosto;
            }
            CargarPlantillaCtaCtb();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idModulo = (int)cboModulo.SelectedValue;

            DataTable dtPlantillaCtaCtb = PlantillaCuentaAsiento.CNListarPlantillaCtaCtbPorModulo(idModulo);

            if (dtPlantillaCtaCtb.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsPlantillaCtaCtb", dtPlantillaCtaCtb));

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("idModulo", idModulo.ToString(), false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));

                string reportPath = "rptPlantillaCtaCtb.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para el modulo seleccionado", "Plantilla de Cuentas Contable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboMotivoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivoOperacion.ValueMember == "" || cboMotivoOperacion.DisplayMember == "")
            {
                return;
            }
            CargarPlantillaCtaCtb();
        }
    }
}
