using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.Funciones;
using GEN.CapaNegocio;
using EntityLayer;
using System.Security.Cryptography;
using ADM.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conPlanPagos : UserControl
    {
        #region Variables Globales

        public DataTable dtCalendarioPagos { get; set; }
        public DataTable dtCargaGastos { get; set; }
        public short nTipPeriodo { get; set; }
        public int nNumCuotas { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public decimal nMonto { get; set; }
        public int nPlazo { get; set; }
        public int nDiasGracia { get; set; }
        public decimal nTasaInteres { get; set; }
        public int idMoneda { get; set; }
        public bool lCuotaCte { get; set; }
        public DateTime dFecPriCuota { get; set; }
        public int IdSolicitud { get; set; }
        public clsCNPlanPago cnplanpago { get; set; }
        public DataTable dtGastosPP { get; set; }
        public decimal nCapitalMaxCobSeg { get; set; }

        public DataTable dtModificaciones = new DataTable("dtModificaciones");

        private DataTable dtCuotasDobles = new DataTable();

        private bool lVerificarError;

        public event EventHandler clickModificaciones;

        public event EventHandler ModificacionesCanceladas;
        public int idTipoPlanPago { get; set; }
        private bool lModifExterna = false;
        public bool lEditorEnabled
        {
            get
            {
                return this.grbEditor.Enabled;
            }
            set
            {
                this.grbEditor.Enabled = value;
            }
        }

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();

        #endregion

        public conPlanPagos()
        {
            InitializeComponent();
            cnplanpago = new clsCNPlanPago();
            idTipoPlanPago = 0;
        }

        public void AsignaObjetoSeguroOptativo(clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro)
        {
            this.objSolicitudCreditoCargaSeguro = objSolicitudCreditoCargaSeguro;
        }

        public void modificarPlanPagos(bool lModifExterna, int idAccion, int nCuota = 0, clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null)
        {
            this.lModifExterna = lModifExterna;
            if (this.lModifExterna)
            {
                cboAccionCuota1.SelectedValue = idAccion;
                txtNumCuotaGracia.Text = nCuota.ToString();                
            }
            var drModifica = agregarModificacionPP();

            if (drModifica != null)
            {
                #region SETEO DE PARÁMETROS PARA MODIFICACIÓN DE PLAN DE PAGOS

                //int idAccion = Convert.ToInt32(this.cboAccionCuota1.SelectedValue);
                short nTipPerPag = nTipPeriodo;
                int nDiaFecPag = nPlazo;
                decimal nTasa = nTasaInteres / 100.00M;
                DataTable dtGastos = dtCargaGastos;
                decimal nMonDesemb = nMonto;
                DateTime dFecDesemb = dFechaDesembolso;
                int nNumCuoCta = nNumCuotas;
                int nDiaGraCta = nDiasGracia;

                DataTable dtGastosModificaCuota = dtGastos.Clone();
                (from item in dtGastos.AsEnumerable()
                 select item).CopyToDataTable(dtGastosModificaCuota, LoadOption.OverwriteChanges);

                #endregion

                switch (idAccion)
                {
                    /*CUOTA BALON*/
                    case 1:
                        dtCuotasDobles = cnplanpago.retornarCuotasDobles(dtModificaciones, dFecDesemb, nNumCuoCta);
                        dtCalendarioPagos = cnplanpago.CalcularCuotaBalon(dtCalendarioPagos, drModifica, dFecDesemb,
                                            nTipPerPag, nDiaFecPag, nTasa, dtGastosModificaCuota, idMoneda, dtCuotasDobles,
                                            lCuotaCte, this.objSolicitudCreditoCargaSeguro, nCapitalMaxCobSeg);
                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);
                        dtgCalendario.DataSource = dtCalendarioPagos;
                        #region FORMATO PLAN DE PAGOS MODIFICADO

                        dtgCalendario.Rows[dtgCalendario.Rows.Count - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        dtgCalendario.FirstDisplayedScrollingRowIndex = dtgCalendario.Rows.Count - 1;

                        #endregion

                        break;

                    /*JUNTAR CUOTAS*/
                    case 2:

                        dtCalendarioPagos = cnplanpago.CalcularJuntarCuotas(dtCalendarioPagos, drModifica, nTasa, dtGastosModificaCuota,
                                                                                nMonDesemb, dFecDesemb, nCapitalMaxCobSeg, this.objSolicitudCreditoCargaSeguro);
                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);
                        dtgCalendario.DataSource = dtCalendarioPagos;
                        #region FORMATO PLAN DE PAGOS MODIFICADO

                        dtgCalendario.Rows[(int)drModifica["nCuota"] - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;

                        #endregion

                        break;

                    /*CUOTAS DOBLES*/
                    case 3:
                        calcularPlanpagos();
                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);

                        dtgCalendario.DataSource = dtCalendarioPagos;

                        #region FORMATO PLAN DE PAGOS MODIFICADO

                        var nCuotaMax = dtCalendarioPagos.AsEnumerable().Max(x => (decimal)x["imp_cuota"]);

                        foreach (DataGridViewRow item in dtgCalendario.Rows)
                        {
                            if (nCuotaMax == (decimal)item.Cells["imp_cuota"].Value)
                            {
                                item.DefaultCellStyle.BackColor = Color.NavajoWhite;
                            }
                        }

                        #endregion

                        break;

                    /*MODIFICAR CUOTA*/
                    case 4:

                        #region MODIFICAR CUOTA

                        cnplanpago.RecalcModificarCuota(dtCalendarioPagos, drModifica, nMonDesemb, nTasa,
                            dFecDesemb, dtGastosModificaCuota, cnplanpago.nMontoCuota, nCapitalMaxCobSeg,
                            this.objSolicitudCreditoCargaSeguro);

                        decimal montoCuota = cnplanpago.nMontoCuota;
                        decimal montoUltimaCuota = dtCalendarioPagos.AsEnumerable().Last().Field<decimal>("imp_cuota");

                        decimal variacion = montoUltimaCuota - montoCuota;
                        decimal nuevaCuota = cnplanpago.nMontoCuota;
                        int contadorCiclos = 0;
                        bool flag = false;

                        do
                        {
                            nuevaCuota = dtCalendarioPagos.AsEnumerable().Where(y => (int)y["cuota"] != (int)drModifica["nCuota"]).Sum(x => (decimal)x["imp_cuota"]) / (nNumCuoCta - 1);

                            cnplanpago.RecalcModificarCuota(dtCalendarioPagos, drModifica, nMonDesemb, nTasa,
                            dFecDesemb, dtGastosModificaCuota, nuevaCuota, nCapitalMaxCobSeg,
                            this.objSolicitudCreditoCargaSeguro);

                            montoUltimaCuota = dtCalendarioPagos.AsEnumerable().Last().Field<decimal>("imp_cuota");

                            variacion = montoUltimaCuota - nuevaCuota;
                            contadorCiclos++;

                            if (contadorCiclos >= (int)Math.Abs((double)(montoCuota - nuevaCuota) / 0.1) + 10)
                            {
                                flag = true;
                            }
                            if (flag && variacion < 0)
                                break;

                        } while (!(variacion >= -3 && variacion <= 0));

                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);

                        this.dtgCalendario.DataSource = dtCalendarioPagos;
                        dtgCalendario.Rows[(int)drModifica["nCuota"] - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;

                        #endregion

                        break;

                    /*CUOTAS DE GRACIA*/
                    case 5:

                        //calcularPlanpagos(0, (int)drModifica["nCuota"]);

                        if (objSolCargaSeguros == null)                            
                            objSolCargaSeguros = this.objSolicitudCreditoCargaSeguro;

                        dtCalendarioPagos = cnplanpago.CalcularCuotasGracia(dtCalendarioPagos, nMonDesemb, nTasa, dFecDesemb, nDiaGraCta,
                            nTipPerPag, nDiaFecPag, dtGastos, idMoneda, new DataTable(), dFecPriCuota, nNumCuoCta, (int)drModifica["nCuota"], nCapitalMaxCobSeg, objSolCargaSeguros);
                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);

                        dtgCalendario.DataSource = dtCalendarioPagos;

                        #region FORMATO PLAN DE PAGOS MODIFICADO

                        for (int i = 0; i < (int)drModifica["nCuota"]; i++)
                        {
                            dtgCalendario.Rows[i].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        }

                        #endregion

                        break;

                    /*CUOTA LIBRE*/
                    case 6:
                        var dtCuotaLibre = cnplanpago.CalcularCuotaLibre(dtCalendarioPagos, drModifica, dFecDesemb,
                                                nTipPerPag, nDiaFecPag, nTasa, dtGastosModificaCuota, idMoneda, new DataTable(),
                                                lCuotaCte, nCapitalMaxCobSeg, this.objSolicitudCreditoCargaSeguro);
                        dtGastosPP = cnplanpago.ObtenerGastos(IdSolicitud);
                        #region FORMATO PLAN DE PAGOS MODIFICADO

                        if (dtCuotaLibre == null)
                        {
                            dtgModificaciones.DataSource = null;
                            dtModificaciones.Clear();
                            cboAccionCuota1.SelectedIndex = -1;
                            calcularPlanpagos();
                            MessageBox.Show("Inconsistencia con el monto ingresado", "Validación cuota libre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            dtCalendarioPagos = dtCuotaLibre;
                            dtgCalendario.DataSource = dtCalendarioPagos;
                            dtgCalendario.Rows[(int)drModifica["nCuota"] - 1].DefaultCellStyle.BackColor = Color.NavajoWhite;
                        }

                        #endregion

                        break;
                }

                cnplanpago.calcularInteresCompReprog(this.dtCalendarioPagos, nTasaInteres);

                dtgCalendario.ClearSelection();
                formatoGridPlanPago();
                //formatoGridModificaciones();
                asignarTCEA(nMonDesemb);
                asignarTotalesPP();

                var nValCuoNeg = dtCalendarioPagos.AsEnumerable().Count(x => (decimal)x["imp_cuota"] <= 0);

                if (nValCuoNeg > 0)
                {
                    MessageBox.Show("El cambio realizado no aplica por generar inconsistencias en el plan de pagos");
                    dtgModificaciones.DataSource = null;
                    dtModificaciones.Clear();
                    calcularPlanpagos();
                }

                FillModificaciones();                
            }
        }
        #region Eventos

        private void conPlanPagos_Load(object sender, EventArgs e)
        {
            dtgModificaciones.AutoGenerateColumns = false;
            dtgModificaciones.DataSource = null;
            dtModificaciones.Clear();
            cboAccionCuota1.SelectedIndex = -1;
            if (dtCalendarioPagos != null)
            {
                cboAccionCuota1.SelectedIndex = -1;
                if (dtCalendarioPagos.Rows.Count > 0)
                {
                    dtgCalendario.DataSource = dtCalendarioPagos;
                }
            }
        }

        private void dtgCalendario_SelectionChanged(object sender, EventArgs e)
        {
            asignarValorModificacion();
        }

        private void dtgCalendario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 1)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MMM/yyyy").ToUpper();
                    e.FormattingApplied = true;
                }
            }
        }

        private void dtgCalendario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            asignarValorModificacion();
        }

        private void dtgCalendario_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dtgCalendario.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void cboAccionCuota1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillModificaciones();
        }

        private void pbxAyuda1_Click(object sender, EventArgs e)
        {
            var idAccion = Convert.ToInt32(cboAccionCuota1.SelectedValue);
            string cMensajeAyuda = "";
            switch (idAccion)
            {
                case 1:
                    cMensajeAyuda = "Seleccione la cuota a trasladar al final";
                    break;
                case 2:
                    cMensajeAyuda = "Seleccione la cuota que ha de unirse a la siguiente";
                    break;
                case 3:
                    cMensajeAyuda = "Seleccione la cuota donde desea la cuota doble";
                    break;
                case 4:
                    cMensajeAyuda = "Seleccione la cuota a modificar el monto";
                    break;
                case 5:
                    cMensajeAyuda = "Ingrese la cantidad de cuotas de gracia";
                    break;
                case 6:
                    cMensajeAyuda = "Seleccione la cuota a modificar";
                    break;
                default:
                    break;
            }

            this.toolTipPP.Show(cMensajeAyuda, pbxAyuda1, 5000);
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            txtMontoCuota.nNumDecimales = 0;
            txtMontoCuota.Text = "0";
            txtMontoCuota.Focus();
            txtMontoCuota.SelectAll();
            lblMontoModifica.Text = "Número de Días";
        }

        private void rbtCapital_CheckedChanged(object sender, EventArgs e)
        {
            txtMontoCuota.nNumDecimales = 2;
            txtMontoCuota.Text = "0.00";
            txtMontoCuota.Focus();
            txtMontoCuota.SelectAll();
            lblMontoModifica.Text = "Monto";
        }

        private void rbtCuota_CheckedChanged(object sender, EventArgs e)
        {
            txtMontoCuota.nNumDecimales = 2;
            txtMontoCuota.Text = "0.00";
            txtMontoCuota.Focus();
            txtMontoCuota.SelectAll();
            lblMontoModifica.Text = "Monto";
        }

        private void btnModificaPP_Click(object sender, EventArgs e)
        {
            int idAccion = Convert.ToInt32(this.cboAccionCuota1.SelectedValue);
            this.modificarPlanPagos(false, idAccion);
            if (clickModificaciones != null)
                clickModificaciones(sender, e);
        }

        private void btnCancelarModificaciones_Click(object sender, EventArgs e)
        {
            dtgModificaciones.DataSource = null;
            dtModificaciones.Clear();
            cboAccionCuota1.SelectedIndex = -1;
            if (dtGastosPP != null)
            {
                dtGastosPP.Clear();
            }
            if (validaingresodatos())
            {
                calcularPlanpagos();

                if (ModificacionesCanceladas != null)
                    ModificacionesCanceladas(btnCancelarModificaciones, EventArgs.Empty);
            }
        }

        private void txtNumCuota_Leave(object sender, EventArgs e)
        {
            if (cboAccionCuota1.SelectedIndex > -1)
            {
                if ((int)cboAccionCuota1.SelectedValue == 1)
                {
                    txtNumCuota.SelectAll();
                }

                if (((int)cboAccionCuota1.SelectedValue).In(1, 2, 4))
                {
                    if (txtNumCuota.nDecValor >= nNumCuotas)
                    {
                        txtNumCuota.Text = (nNumCuotas - 1).ToString();
                        txtNumCuota.SelectAll();
                    }
                }
            }
        }

        private void txtNumCuota_TextChanged(object sender, EventArgs e)
        {
            if (cboAccionCuota1.SelectedIndex > -1)
            {
                if ((int)cboAccionCuota1.SelectedValue == 2)
                {
                    txtOtraCuota.Text = string.Format("{0:0}", txtNumCuota.nDecValor + 1);
                }

                if (Convert.ToInt32(txtNumCuota.nDecValor) > nNumCuotas)
                {
                    txtNumCuota.Text = nNumCuotas.ToString();
                    txtNumCuota.SelectAll();
                }
                if (Convert.ToInt32(txtNumCuota.nDecValor) == 0)
                {
                    txtNumCuota.Text = "2";
                    txtNumCuota.SelectAll();
                }
            }
        }

        private void txtNumCuotaGracia_Leave(object sender, EventArgs e)
        {
            if (cboAccionCuota1.SelectedIndex < 0)
            {
                return;
            }
            if ((int)cboAccionCuota1.SelectedValue == 5)
            {
                if (txtNumCuotaGracia.nDecValor >= nNumCuotas)
                {
                    txtNumCuotaGracia.Text = (nNumCuotas - 1).ToString();
                    txtNumCuotaGracia.SelectAll();
                }
            }
        }

        private void txtNumCuotaGracia_TextChanged(object sender, EventArgs e)
        {
            if (cboAccionCuota1.SelectedIndex < 0)
            {
                return;
            }
            if ((int)cboAccionCuota1.SelectedValue == 5)
            {
                if (txtNumCuotaGracia.nDecValor >= nNumCuotas)
                {
                    txtNumCuotaGracia.Text = (nNumCuotas - 1).ToString();
                    txtNumCuotaGracia.SelectAll();
                }
            }
        }

        private void menuCuotaBalon_Click(object sender, EventArgs e)
        {
            if (dtgCalendario.RowCount > 0)
            {
                if (dtgCalendario.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una cuota por favor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cboAccionCuota1.SelectedValue = 1;
                btnModificaPP_Click(sender, e);
            }
        }

        private void menuUnificarCuota_Click(object sender, EventArgs e)
        {
            if (dtgCalendario.RowCount > 0)
            {
                if (dtgCalendario.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una cuota por favor", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cboAccionCuota1.SelectedValue = 2;
                btnModificaPP_Click(sender, e);
            }
        }

        private void menuModificarCuota_Click(object sender, EventArgs e)
        {
            if (dtgCalendario.RowCount > 0)
            {
                if (dtgCalendario.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una cuota por favor", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cboAccionCuota1.SelectedValue = 4;
                txtMontoCuota.Text = "0.00";
                txtMontoCuota.Focus();
                txtMontoCuota.SelectAll();
            }
        }

        private void menucuotaLibre_Click(object sender, EventArgs e)
        {
            if (dtgCalendario.RowCount > 0)
            {
                if (dtgCalendario.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una cuota por favor", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cboAccionCuota1.SelectedValue = 6;
            }
        }

        #endregion

        #region Métodos

        private void FillModificaciones()
        {
            if (cboAccionCuota1.SelectedIndex < 0)
            {
                cboMeses1.Visible = false;
                chcAnios.Visible = false;
                nudAnios.Visible = false;
                txtMontoCuota.Visible = false;
                chcAnios.Visible = false;
                txtNumCuota.Visible = false;
                txtOtraCuota.Visible = false;
                txtNumCuotaGracia.Visible = false;

                lblNumCuota.Visible = false;
                lblOtraCuota.Visible = false;
                lblMes.Visible = false;
                lblMontoModifica.Visible = false;
                lblNumCuotaGracia.Visible = false;
                grbCuotaLibre.Visible = false;
                grbCuotaLibre.Enabled = false;
                return;
            }
            lblMontoModifica.Visible = true;
            switch ((int)cboAccionCuota1.SelectedValue)
            {
                case 1:

                    #region Cuota Balon

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Enabled = false;
                    nudAnios.Enabled = false;
                    txtMontoCuota.Enabled = false;
                    txtOtraCuota.Text = (dtgCalendario.RowCount).ToString();
                    chcAnios.Checked = false;
                    txtNumCuotaGracia.Enabled = false;

                    cboMeses1.Visible = false;
                    chcAnios.Visible = false;
                    nudAnios.Visible = false;
                    txtMontoCuota.Visible = false;
                    chcAnios.Visible = false;
                    txtNumCuota.Visible = true;
                    txtOtraCuota.Visible = true;
                    txtNumCuotaGracia.Visible = false;

                    lblNumCuota.Visible = true;
                    lblOtraCuota.Visible = true;
                    lblMes.Visible = false;
                    lblMontoModifica.Visible = false;
                    lblNumCuotaGracia.Visible = false;
                    grbCuotaLibre.Visible = false;

                    #endregion

                    break;
                case 2:

                    #region Juntar cuotas

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Enabled = false;
                    nudAnios.Enabled = false;
                    txtMontoCuota.Enabled = false;
                    txtOtraCuota.Text = string.Format("{0:0}", txtNumCuota.nDecValor + 1);
                    chcAnios.Checked = false;
                    txtNumCuotaGracia.Enabled = false;

                    txtNumCuota.Visible = true;
                    txtOtraCuota.Visible = true;
                    cboMeses1.Visible = false;
                    chcAnios.Visible = false;
                    nudAnios.Visible = false;
                    txtMontoCuota.Visible = false;
                    chcAnios.Visible = false;
                    txtNumCuotaGracia.Visible = false;

                    lblNumCuota.Visible = true;
                    lblOtraCuota.Visible = true;
                    lblMes.Visible = false;
                    lblMontoModifica.Visible = false;
                    lblNumCuotaGracia.Visible = false;
                    grbCuotaLibre.Visible = false;

                    #endregion

                    break;
                case 3:

                    #region Cuotas Dobles

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Checked = false;

                    if (nTipPeriodo.ToString() == "1")
                    {
                        chcAnios.Enabled = true;
                        nudAnios.Enabled = true;
                    }
                    else
                    {
                        chcAnios.Enabled = false;
                        nudAnios.Enabled = false;
                    }

                    txtMontoCuota.Enabled = false;
                    txtNumCuotaGracia.Enabled = false;

                    txtNumCuota.Text = "1";
                    txtOtraCuota.Text = "1";
                    txtMontoCuota.Text = "0.00";

                    txtNumCuota.Visible = false;
                    txtOtraCuota.Visible = false;
                    txtMontoCuota.Visible = false;
                    cboMeses1.Visible = true;
                    chcAnios.Visible = true;
                    nudAnios.Visible = true;
                    txtNumCuotaGracia.Visible = false;

                    lblNumCuota.Visible = false;
                    lblOtraCuota.Visible = false;
                    lblMes.Visible = true;
                    lblMontoModifica.Visible = false;
                    lblNumCuotaGracia.Visible = false;
                    grbCuotaLibre.Visible = false;

                    #endregion

                    break;
                case 4:

                    #region Modificar Cuota

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Enabled = false;
                    nudAnios.Enabled = false;
                    txtMontoCuota.Enabled = true;
                    txtNumCuota.Text = "1";
                    txtOtraCuota.Text = "1";
                    chcAnios.Checked = false;
                    txtNumCuotaGracia.Enabled = false;

                    txtOtraCuota.Visible = false;
                    cboMeses1.Visible = false;
                    chcAnios.Visible = false;
                    nudAnios.Visible = false;
                    chcAnios.Visible = false;
                    txtMontoCuota.Visible = true;
                    txtNumCuota.Visible = true;
                    txtNumCuotaGracia.Visible = false;

                    lblNumCuota.Visible = true;
                    lblOtraCuota.Visible = false;
                    lblMes.Visible = false;
                    lblMontoModifica.Visible = true;
                    lblNumCuotaGracia.Visible = false;
                    grbCuotaLibre.Visible = false;

                    #endregion

                    break;
                case 5:

                    #region Cuotas de Gracia

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Enabled = false;
                    nudAnios.Enabled = false;
                    txtMontoCuota.Enabled = false;
                    txtNumCuota.Text = "1";
                    txtOtraCuota.Text = "1";
                    chcAnios.Checked = false;
                    txtNumCuotaGracia.Enabled = true;

                    txtOtraCuota.Visible = false;
                    cboMeses1.Visible = false;
                    chcAnios.Visible = false;
                    nudAnios.Visible = false;
                    chcAnios.Visible = false;
                    txtMontoCuota.Visible = false;
                    txtNumCuota.Visible = false;
                    txtNumCuotaGracia.Visible = true;

                    lblNumCuota.Visible = false;
                    lblOtraCuota.Visible = false;
                    lblMes.Visible = false;
                    lblMontoModifica.Visible = false;
                    lblNumCuotaGracia.Visible = true;
                    grbCuotaLibre.Visible = false;

                    #endregion

                    break;

                case 6:

                    #region Cuota Libre

                    txtNumCuota.Enabled = false;
                    txtOtraCuota.Enabled = false;
                    cboMeses1.Enabled = false;
                    chcAnios.Enabled = false;
                    nudAnios.Enabled = false;
                    txtMontoCuota.Enabled = true;
                    txtNumCuota.Text = "1";
                    txtOtraCuota.Text = "1";
                    chcAnios.Checked = false;
                    txtNumCuotaGracia.Enabled = false;

                    txtOtraCuota.Visible = false;
                    cboMeses1.Visible = false;
                    chcAnios.Visible = false;
                    nudAnios.Visible = false;
                    chcAnios.Visible = false;
                    txtMontoCuota.Visible = true;
                    txtNumCuota.Visible = true;
                    txtNumCuotaGracia.Visible = false;

                    lblNumCuota.Visible = true;
                    lblOtraCuota.Visible = false;
                    lblMes.Visible = false;
                    lblNumCuotaGracia.Visible = false;

                    grbCuotaLibre.Visible = true;
                    grbCuotaLibre.Enabled = true;

                    rbtCapital.Checked = true;
                    txtMontoCuota.nNumDecimales = 2;
                    lblMontoModifica.Visible = false;

                    #endregion

                    break;
            }

            if (dtgCalendario.SelectedRows.Count > 0)
            {
                txtNumCuota.Text = dtgCalendario.SelectedRows[0].Cells["cuota"].Value.ToString();
            }
            pbxAyuda1_Click(new object(), new EventArgs());

            txtMontoCuota.Text = "0.00";
            txtMontoCuota.Focus();
            txtMontoCuota.SelectAll();
        }

        public void cargarDatos()
        {
            if (dtCalendarioPagos != null)
            {
                if (nNumCuotas > 2)
                {
                    int nNumCuo = nNumCuotas;

                    if (cboAccionCuota1.SelectedIndex >= 0)
                    {
                        if ((int)cboAccionCuota1.SelectedValue == 1)
                        {
                            txtOtraCuota.Text = (nNumCuo - 1).ToString();
                            dtModificaciones.Rows.Clear();
                        }

                        if (((int)cboAccionCuota1.SelectedValue).In(2))
                        {
                            nNumCuo = nNumCuotas;
                            if (Convert.ToInt32(txtNumCuota.Text) >= nNumCuo)
                            {
                                txtNumCuota.Text = (nNumCuo - 1).ToString();
                                txtOtraCuota.Text = nNumCuo.ToString();
                            }

                            var qExistCuota = dtModificaciones.AsEnumerable().Count(x => (int)x["nOtraCuota"] > nNumCuo);
                            if (qExistCuota > 0)
                            {
                                dtModificaciones.Rows.Clear();
                            }
                        }
                    }
                }
                else
                {
                    dtModificaciones.Rows.Clear();
                }
                asignarMaxMinAnios();
                cargarEstructuradtModifica();

                cboAccionCuota1.SelectedIndex = -1;
                if (dtCalendarioPagos.Rows.Count > 0)
                {
                    dtgCalendario.DataSource = dtCalendarioPagos;
                }

                int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
                if (nFormaCalculoTasa == 1)
                {
                    txtTEA.Text = string.Format("{0:0.0000}", nTasaInteres);
                    txtTEM.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1.00 + (double)nTasaInteres / 100.00), (1.0 / 12.0)) - 1.0) * 100.0), 4));
                }

                if (nFormaCalculoTasa == 2)
                {
                    txtTEA.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1 + (double)nTasaInteres / 100.0), (360.0 / 30.0)) - 1) * 100.0), 4));
                    txtTEM.Text = string.Format("{0:0.0000}", nTasaInteres);
                }

                formatoGridPlanPago();
                asignarTotalesPP();
                asignarTCEA(nMonto);
                dtgCalendario.ClearSelection();
                this.ControlReprogramacionEspecial();
            }

        }

        private void asignarValorModificacion()
        {
            if (dtgCalendario.SelectedRows.Count > 0)
            {
                asignarMaxMinAnios();
                txtNumCuota.Text = dtgCalendario.SelectedRows[0].Cells["cuota"].Value.ToString();
                cboMeses1.SelectedValue = Convert.ToDateTime(dtgCalendario.SelectedRows[0].Cells["fecha"].Value).Month;
                nudAnios.Value = Convert.ToDecimal(Convert.ToDateTime(dtgCalendario.SelectedRows[0].Cells["fecha"].Value).Year);
            }
        }

        private DataRow agregarModificacionPP()
        {
            if (!ValidaAgregarModificacion())
                return null;

            DataRow drModifica = dtModificaciones.NewRow();

            drModifica["idTipoAccion"] = (int)cboAccionCuota1.SelectedValue;
            drModifica["cTipoAccion"] = cboAccionCuota1.Text;


            switch ((int)cboAccionCuota1.SelectedValue)
            {
                case 1:
                    #region CUOTA BALON

                    drModifica["nCuota"] = Convert.ToInt32(txtNumCuota.Text);
                    drModifica["nOtraCuota"] = Convert.ToInt32(txtOtraCuota.Text);
                    drModifica["nMes"] = 0;
                    drModifica["cMes"] = "";
                    drModifica["nAnio"] = 0;
                    drModifica["cAnio"] = "";
                    drModifica["nMonto"] = 0.00M;
                    drModifica["lIndTodAnios"] = chcAnios.Checked;

                    break;

                    #endregion
                case 2:
                    #region JUNTAR CUOTAS


                    drModifica["nCuota"] = Convert.ToInt32(txtNumCuota.Text);
                    drModifica["nOtraCuota"] = Convert.ToInt32(txtOtraCuota.Text);
                    drModifica["nMes"] = 0;
                    drModifica["cMes"] = "";
                    drModifica["nAnio"] = 0;
                    drModifica["cAnio"] = "";
                    drModifica["nMonto"] = 0.00M;
                    drModifica["lIndTodAnios"] = chcAnios.Checked;

                    break;

                    #endregion
                case 3:
                    #region CUOTA DOBLE

                    drModifica["nCuota"] = 0;
                    drModifica["nOtraCuota"] = 0;
                    drModifica["nMonto"] = 0.00M;
                    drModifica["lIndTodAnios"] = chcAnios.Checked;
                    drModifica["nMes"] = (int)cboMeses1.SelectedValue;
                    drModifica["cMes"] = cboMeses1.Text;
                    drModifica["nDia"] = Convert.ToDateTime(this.dtgCalendario.SelectedRows[0].Cells["fecha"].Value).Day;

                    if (chcAnios.Checked)
                    {
                        drModifica["nAnio"] = 0;
                        drModifica["cAnio"] = "TODOS";
                    }
                    else
                    {
                        if ((int)cboMeses1.SelectedValue < dFechaDesembolso.Month
                            && nudAnios.Value == dFechaDesembolso.Year)
                        {
                            drModifica["nAnio"] = Convert.ToInt32(nudAnios.Value) + 1;
                        }
                        else
                        {
                            drModifica["nAnio"] = Convert.ToInt32(nudAnios.Value);
                        }
                        drModifica["cAnio"] = drModifica["nAnio"].ToString();
                    }

                    break;
                    #endregion
                case 4:
                    #region MODIFICAR CUOTA

                    drModifica["nCuota"] = Convert.ToInt32(txtNumCuota.Text);
                    drModifica["nOtraCuota"] = 0;
                    drModifica["nMes"] = 0;
                    drModifica["cMes"] = "";
                    drModifica["nAnio"] = 0;
                    drModifica["cAnio"] = "";
                    drModifica["nMonto"] = txtMontoCuota.nDecValor;
                    drModifica["lIndTodAnios"] = chcAnios.Checked;              
                    break;
                    #endregion
                case 5:
                    #region CUOTAS DE GRACIA

                    drModifica["nCuota"] = Convert.ToInt32(txtNumCuotaGracia.Text);
                    drModifica["nOtraCuota"] = 0;
                    drModifica["nMes"] = 0;
                    drModifica["cMes"] = "";
                    drModifica["nAnio"] = 0;
                    drModifica["cAnio"] = "";
                    drModifica["nMonto"] = 0.00;
                    drModifica["lIndTodAnios"] = false;
                    
                    break;

                    #endregion
                case 6:
                    #region CUOTAS LIBRES

                    drModifica["nCuota"] = Convert.ToInt32(txtNumCuota.Text);
                    drModifica["nOtraCuota"] = 0;
                    drModifica["nMes"] = 0;
                    drModifica["cMes"] = "";
                    drModifica["nAnio"] = 0;
                    drModifica["cAnio"] = "";
                    drModifica["nMonto"] = txtMontoCuota.nDecValor;
                    drModifica["lIndTodAnios"] = chcAnios.Checked;

                    int idCuotalibre = 0;
                    if (grbCuotaLibre.Visible)
                    {
                        if (rbtFecha.Checked)
                        {
                            idCuotalibre = 1;
                        }
                        if (rbtCapital.Checked)
                        {
                            idCuotalibre = 2;
                        }
                        if(rbtCuota.Checked)
                        {
                            idCuotalibre = 3;
                        }
                    }

                    drModifica["idCuotalibre"] = idCuotalibre;
                    break;
                    #endregion
            }

            dtModificaciones.Rows.Add(drModifica);
            dtgModificaciones.DataSource = string.Empty;
            dtgModificaciones.DataSource = dtModificaciones;
            //formatoGridModificaciones();

            return drModifica;
        }

        private bool ValidaAgregarModificacion()
        {
            #region Comentarios
            //if ((int)cboAccionCuota1.SelectedValue == 6 &&
            //    dtModEnum.Any(x => x.Field<int>("nCuota") > Convert.ToInt32(txtNumCuota.Text.Trim())))
            //{
            //    var dtAux = dtModificaciones.Clone();
            //    var rowsNoaplica = dtModEnum.Where(x => (int)x["nCuota"] > Convert.ToInt32(txtNumCuota.Text.Trim())).ToList();

            //    (dtModEnum.Except(rowsNoaplica)).CopyToDataTable(dtAux, LoadOption.OverwriteChanges);
            //    dtModificaciones.Clear();

            //    foreach (DataRow item in dtAux.Rows)
            //    {
            //        dtModificaciones.ImportRow(item);
            //    }
            //}

            //if (Convert.ToInt32(cboAccionCuota1.SelectedValue).In(5, 3, 1))
            //{
            //    if (Convert.ToInt32(cboAccionCuota1.SelectedValue).In(1, 5))
            //    {
            //        dtgModificaciones.DataSource = null;
            //        dtModificaciones.Clear();
            //    }
            //    else if (Convert.ToInt32(cboAccionCuota1.SelectedValue) == 3 &&
            //           dtModificaciones.AsEnumerable().Any(x => x.Field<int>("idTipoAccion") != 3))
            //    {
            //        dtgModificaciones.DataSource = null;
            //        dtModificaciones.Clear();
            //    }
            //}

            #endregion

            if (cboAccionCuota1.SelectedIndex < 0)
                return false;

            int idTipoAccion = Convert.ToInt32(cboAccionCuota1.SelectedValue);

            if (dtgCalendario.RowCount == 0 || (idTipoAccion != 5 && dtgCalendario.SelectedRows.Count == 0))
            {
                MessageBox.Show("Seleccione la cuota a modificar.", "Validación de modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var dtModEnum = dtModificaciones.AsEnumerable();
            DataRowView row;
            if (idTipoAccion != 5)
                row = dtgCalendario.SelectedRows[0].DataBoundItem as DataRowView;
            else
                row = dtgCalendario.Rows[0].DataBoundItem as DataRowView;

            if (Convert.ToInt16(row["cuota"]) == dtgCalendario.RowCount)
            {
                MessageBox.Show("No se puede realizar modificaciones sobre la última cuota. " + cboAccionCuota1.Text, "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idTipoAccion.In(4, 5))
            {
                if (dtModEnum.Any(x => x.Field<int>("idTipoAccion") == idTipoAccion))
                {
                    MessageBox.Show("Ya se agregó la especificación: " + cboAccionCuota1.Text, "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            int idCuotaMod = 0;
            int idOtraCuota = 0;
            if (!string.IsNullOrEmpty(txtNumCuota.Text.Trim()))
            {
                idCuotaMod = Convert.ToInt16(txtNumCuota.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtOtraCuota.Text.Trim()))
            {
                idOtraCuota = Convert.ToInt16(txtOtraCuota.Text.Trim());
            }

            if (dtModEnum.Any(x => x.Field<int>("nCuota") > idCuotaMod))
            {
                MessageBox.Show("Las modificaciones de cuotas tienen que aplicarse en orden.", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            switch (idTipoAccion)
            {
                case 1:
                    #region CUOTA BALON

                    if (dtModificaciones.AsEnumerable().Any(x => (int)x["nCuota"] == idCuotaMod
                                                                  && (int)x["nOtraCuota"] == idOtraCuota))
                    {
                        MessageBox.Show("Ya se agregó la especificación de cuota balón para esa cuota", "Validación Modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    break;

                    #endregion
                case 2:
                    #region JUNTAR CUOTAS

                    if (dtModificaciones.AsEnumerable().Any(x => (int)x["nCuota"] == idCuotaMod
                                                               && (int)x["nOtraCuota"] == idOtraCuota))
                    {
                        MessageBox.Show("Ya se agregó la especificación de juntar cuotas", "Validación Juntar Cuota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                    #endregion
                case 3:
                    #region CUOTA DOBLE

                    int nMes = (int)cboMeses1.SelectedValue;
                    int nAnio ;
                    if (chcAnios.Checked)
                    {
                        nAnio = 0;
                    }
                    else
                    {
                        if ((int)cboMeses1.SelectedValue < dFechaDesembolso.Month && nudAnios.Value == dFechaDesembolso.Year)
                        {
                            nAnio = Convert.ToInt32(nudAnios.Value) + 1;
                        }
                        else
                        {
                            nAnio = Convert.ToInt32(nudAnios.Value);
                        }
                        
                    }

                    if (dtModEnum.Count(x => (int)x["nMes"] == nMes && (int)x["nAnio"] == nAnio) > 0)
                    {
                        MessageBox.Show("Ya se agregó la especificación de cuota doble", "Validación Cuota Doble", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (dtModEnum.Count(x => (int)x["nMes"] == nMes && nAnio == 0) > 0)
                    {
                        MessageBox.Show("Ya se agregó la especificación del mes para todos los años", "Validación Cuota Doble", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var valTodos2 = dtModEnum.Count(x => (int)x["nMes"] == nMes && nAnio == 0);
                    if (valTodos2 > 0)
                    {
                        MessageBox.Show("Ya se agregó la especificación del mes para todos los años", "Validación Cuota Doble", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var valTodos3 = dtModificaciones.AsEnumerable().Count(x => (int)x["nAnio"] == nAnio);
                    if (valTodos3 > 2)
                    {
                        MessageBox.Show("Solo se permite 3 modificaciones de cuota doble por año", "Validación Cuota Doble", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    break;
                    #endregion
                case 4:
                    #region MODIFICAR CUOTA

                    if (txtMontoCuota.nDecValor > nMonto)
                    {
                        MessageBox.Show("Debe ingresar un valor menor al monto a desembolsar", "Validación Modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMontoCuota.Focus();
                        txtMontoCuota.SelectAll();
                        return false;

                    }
                    if (txtMontoCuota.nDecValor == 0)
                    {
                        MessageBox.Show("Ingrese un valor mayor a cero (0)", "Validación Modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMontoCuota.Focus();
                        txtMontoCuota.SelectAll();
                        return false;
                    }

                    break;
                    #endregion
                case 5:
                    #region CUOTAS DE GRACIA

                    if (nTipPeriodo == 1)
                    {
                        MessageBox.Show("Esta acción no esta permitida para el tipo de periodo seleccionado", "Validación Simulador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (nDiasGracia >= nPlazo)
                    {
                        MessageBox.Show("Esta acción no esta permitida para días de gracia mayor a periodo", "Validación Simulador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (txtNumCuotaGracia.nDecValor == 0)
                    {
                        MessageBox.Show("Ingrese un valor mayor a cero", "Validación Simulador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumCuotaGracia.Focus();
                        return false;
                    }

                    if (txtNumCuotaGracia.nDecValor > dtgCalendario.RowCount)
                    {
                        MessageBox.Show("Ingrese un valor menor al total de cuotas", "Validación Simulador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumCuotaGracia.Focus();
                        return false;
                    }

                    break;

                    #endregion
                case 6:
                #region CUOTAS LIBRES

                    if (!rbtCapital.Checked && !rbtCuota.Checked && !rbtFecha.Checked)
                    {
                        MessageBox.Show("Seleccione el tipo de cuota libre.", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtMontoCuota.Text.Trim()))
                    {
                        MessageBox.Show("Ingrese la especificacion a modificar.", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToDecimal(txtMontoCuota.Text.Trim()) <= 0)
                    {
                        MessageBox.Show("El valor a modificar tiene que ser mayor a cero.", "Validación de modificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;
                #endregion
            }

            if (idTipoAccion.In(4, 5))
            {
                if (!this.lModifExterna)
                {
                    DialogResult result =
                                MessageBox.Show(
                                    "Esta modificación borrará todos los cambios hechos anteriormente. ¿Desea continuar?", "Validación Modificaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Se aplicará la modificación de cuotas de forma automática", "Modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dtModificaciones.Rows.Clear();
            }
            return true;
        }

        private void formatoGridModificaciones()
        {
            foreach (DataGridViewColumn item in dtgModificaciones.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgModificaciones.Columns["cTipoAccion"].Visible = true;
            dtgModificaciones.Columns["nCuota"].Visible = true;
            dtgModificaciones.Columns["nOtraCuota"].Visible = true;
            dtgModificaciones.Columns["cMes"].Visible = true;
            dtgModificaciones.Columns["cAnio"].Visible = true;
            dtgModificaciones.Columns["nMonto"].Visible = true;

            dtgModificaciones.Columns["cTipoAccion"].HeaderText = "Acción";
            dtgModificaciones.Columns["cTipoAccion"].Width = 80;

            dtgModificaciones.Columns["nCuota"].Width = 50;
            dtgModificaciones.Columns["nCuota"].HeaderText = "Nro. Cuota";

            dtgModificaciones.Columns["nOtraCuota"].Width = 50;
            dtgModificaciones.Columns["nOtraCuota"].HeaderText = "A que cuota";

            dtgModificaciones.Columns["cMes"].Width = 50;
            dtgModificaciones.Columns["cMes"].HeaderText = "Mes";

            dtgModificaciones.Columns["cAnio"].Width = 50;
            dtgModificaciones.Columns["cAnio"].HeaderText = "Años";

            dtgModificaciones.Columns["nMonto"].Width = 50;
            dtgModificaciones.Columns["nMonto"].HeaderText = "Monto";
            dtgModificaciones.Columns["nMonto"].DefaultCellStyle.Format = "N2";
            dtgModificaciones.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgModificaciones.Columns["nCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgModificaciones.Columns["nOtraCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgModificaciones.Columns["cMes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgModificaciones.Columns["cAnio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgModificaciones.Focus();
            dtgModificaciones.Rows[0].Selected = true;
        }

        public void limpiarControlesTotales()
        {
            this.txtTotInteres.Text = "0.0";
            this.txtTotCapital.Text = "0.0";
            this.txtTotDias.Text = "0.0";
            this.txtTotComi.Text = "0.0";
            this.txtTotItf.Text = "0.0";
            this.txtTCEA.Text = "0.0";
            this.txtTEM.Text = "0.0";
            this.txtTEA.Text = "0.0";
            this.txtTotCuota.Text = "0.0";
        }

        public void asignarTotalesPP()
        {
            DataTable dtPpgTotalizado = cnplanpago.TotalizaPpg(dtCalendarioPagos);
            this.txtTotCuota.Text = dtPpgTotalizado.Rows[0]["nTotImportePpg"].ToString();
            this.txtTotCuota.TextAlign = HorizontalAlignment.Right;
            this.txtTotInteres.Text = dtPpgTotalizado.Rows[0]["nTotInteresPpg"].ToString();
            this.txtTotCapital.Text = dtPpgTotalizado.Rows[0]["nTotCapitalPpg"].ToString();
            this.txtTotDias.Text = dtPpgTotalizado.Rows[0]["nTotdias"].ToString();
            this.txtTotComi.Text = dtPpgTotalizado.Rows[0]["nTotComi"].ToString();
            this.txtTotItf.Text = dtPpgTotalizado.Rows[0]["nTotItf"].ToString();
        }

        public void asignarTCEA(decimal nMonDesemb)
        {
            #region Define plan pago para calculo de tcea

            DataTable dtPlanPago = new DataTable();
            dtPlanPago.Columns.Add("dias", typeof(decimal));
            dtPlanPago.Columns.Add("dias_acu", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));

            int nDiasAcum = 0;
            for (int i = 0; i < dtCalendarioPagos.Rows.Count; i++)
            {
                
                DataRow drCuota = dtPlanPago.NewRow();
                int nDias = Convert.ToInt32(dtCalendarioPagos.Rows[i]["dias"]);
                drCuota["dias"] = nDias;
                nDiasAcum += nDias;
                drCuota["dias_acu"] = nDiasAcum;
                drCuota["imp_cuota"] = Convert.ToDecimal(dtCalendarioPagos.Rows[i]["imp_cuota"]);
                dtPlanPago.Rows.Add(drCuota);
            }

            #endregion

            if (txtTotComi.nvalor == 0)
            {
                txtTCEA.Text = string.Format("{0:0.0000}", txtTEA.nDecValor);
            }
            else
            {
                decimal nTCEA = cnplanpago.CNnCalculaTCEA(dtPlanPago, nMonDesemb, txtTEA.nDecValor);
                txtTCEA.Text = nTCEA < txtTEA.nDecValor ? string.Format("{0:0.0000}", txtTEA.nvalor) : string.Format("{0:0.00000}", nTCEA);
            }
        }

        private void calcularPlanpagos(decimal nCuotaSugerida = 0M, int nNroCuotasGracia = 0)
        {
            //Validar las Tasas para CUOTAS CONSTANTES
            //Validar los gastos que se encuentran en la lista -- para el caso cuando se desee CUOTAS CONSTANTES
            if (lCuotaCte)
            {
                VerificarConsistenciaTasasParaCuotasConstantes();//Para los gastos que ya se encuentren en la lista para aplicar ala SIMULACION
                if (lVerificarError)//Se ha encontrado errores al verificar tasas para CUOTAS CONSTNTES
                {
                    return;
                }
            }

            #region SETEO DE PARÁMETROS PARA EL CÁLCULO DE PLAN DE PAGOS

            var nMonDesemb = nMonto;                           // Monto Desembolsado
            var nTasaEfectiva = nTasaInteres / 100.00m;                 // Tasa de Interes
            var dFecDesemb = dFechaDesembolso;                                       // Fecha de Desembolso
            var nNumCuoCta = nNumCuotas;                                  // Número de Cuotas del Crédito
            var nDiaGraCta = nDiasGracia;                                // Días de Gracia
            var nTipPerPag = nTipPeriodo;        // Tipo de periodo de pago (Fecha o Periodo Fijo)
            var nDiaFecPag = nPlazo;                                   // Día o Periodo fijo de pago
            var idSolicitud = IdSolicitud;

            #endregion

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
            if (nFormaCalculoTasa == 1)
            {
                txtTEA.Text = string.Format("{0:0.0000}", nTasaInteres);
                txtTEM.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1.00 + (double)nTasaInteres / 100.00), (1.0 / 12.0)) - 1.0) * 100.0), 4));
            }

            if (nFormaCalculoTasa == 2)
            {
                txtTEA.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1 + (double)nTasaInteres / 100.0), (360.0 / 30.0)) - 1) * 100.0), 4));
                txtTEM.Text = string.Format("{0:0.0000}", nTasaInteres);
            }

            ///llamando a la función que calcula el plan de pagos en la capa de negocios

            dtCuotasDobles = cnplanpago.retornarCuotasDobles(dtModificaciones, dFecDesemb, nNumCuoCta);

            ///Generar el plan de pagos manteniendo o no las cuotas a pagar constantes
            //if (dtCargaGastos == null)
            //{
            //    CargarConfiguracionesDeGasto();
            //}

            dtCalendarioPagos = cnplanpago.CalculaPpgCuotasConstantes2(nMonDesemb, nTasaEfectiva, dFecDesemb, nNumCuoCta,
                                                                       nDiaGraCta, nTipPerPag,
                                                                       nDiaFecPag, idSolicitud, dtCargaGastos, idMoneda,
                                                                       dtCuotasDobles, dFecPriCuota,
                                                                       nCuotaSugerida, nCapitalMaxCobSeg,
                                                                       nNroCuotasGracia, lCuotaCte, 0, this.objSolicitudCreditoCargaSeguro, true);

            dtGastosPP = cnplanpago.ObtenerGastos(idSolicitud);
            cboAccionCuota1.SelectedIndex = -1;

            this.dtgCalendario.DataSource = dtCalendarioPagos;

            if (this.dtgCalendario.DataSource != null)
            {
                asignarTotalesPP();
                asignarTCEA(nMonDesemb);
                formatoGridPlanPago();
                dtgCalendario.ClearSelection();
            }
            else
            {
                limpiarControlesTotales();
            }
        }

        private void VerificarConsistenciaTasasParaCuotasConstantes()
        {
            Int32 nAuxIdTipoValor = 0;
            Boolean nSwitch = false;
            for (int i = 0; i < dtCargaGastos.Rows.Count; i++)
            {
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))//Hasta aqui ya se ha validado el ingreso de Gastos con tasa PORCENTUAL COMPUESTA que sólo afecten a SALDO CAPITAL
                {
                    if (nSwitch == false)
                    {
                        nAuxIdTipoValor = Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]);
                        //Modificar el tipo  Valor como 1, para que se obtenga CUOTAS CONSTANTES
                        dtCargaGastos.Columns["nClasificTipoGasto"].ReadOnly = false;
                        dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "1";
                        nSwitch = true;
                        lVerificarError = false;
                    }
                    else//Ya existe un gasto que afecte a SALDO CAPITAL con tasa PORCENTUAL COMPUESTA verificar que los demás gastos que afecten a saldo capital tambien tengan éste mismo tipo de Tasa
                    {
                        if (nAuxIdTipoValor != Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]))
                        {
                            MessageBox.Show("PARA QUE LAS CUOTAS SEAN CONSTANTES:" + Environment.NewLine + "Se debe usar sólo TASA PORCENTUAL SIMPLE ó COMPUESTA (No ambos a la vez) en los Gastos que afecten a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lVerificarError = true;
                            return;
                        }
                        else
                        {
                            lVerificarError = false;
                        }
                    }
                }
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                {
                    if (nSwitch == false)
                    {
                        nAuxIdTipoValor = Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]);
                        //Modificar el tipo  Valor como 1, para que se obtenga CUOTAS CONSTANTES
                        dtCargaGastos.Columns["nClasificTipoGasto"].ReadOnly = false;
                        dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "1";
                        nSwitch = true;
                        lVerificarError = false;
                    }
                    else//Ya existe un gasto que afecte a SALDO CAPITAL con tasa PORCENTUAL SIMPLE verificar que los demás gastos que afecten a saldo capital tambien tengan éste mismo tipo de Tasa
                    {
                        if (nAuxIdTipoValor != Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]))
                        {
                            MessageBox.Show("PARA QUE LAS CUOTAS SEAN CONSTANTES:" + Environment.NewLine + "Se debe usar sólo TASA PORCENTUAL SIMPLE ó COMPUESTA (No ambos a la vez) en los Gastos que afecten a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lVerificarError = true;
                            return;
                        }
                        else
                        {
                            lVerificarError = false;
                        }
                    }
                }
            }//Fin de recorrer la lista de Gastos a cargar a la SIMULACIÓN
        }

        public void formatoGridPlanPago()
        {
            foreach (DataGridViewColumn item in dtgCalendario.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCalendario.Columns["cuota"].Visible = true;
            dtgCalendario.Columns["fecha"].Visible = true;
            dtgCalendario.Columns["dias"].Visible = true;
            dtgCalendario.Columns["sal_cap"].Visible = true;
            dtgCalendario.Columns["capital"].Visible = true;
            dtgCalendario.Columns["interes"].Visible = true;
            dtgCalendario.Columns["comisiones"].Visible = true;
            dtgCalendario.Columns["imp_cuota"].Visible = true;

            dtgCalendario.Columns["nAtrasoCuota"].Visible = true;
            dtgCalendario.Columns["nInteresComp"].Visible = true;

            dtgCalendario.Columns["cuota"].HeaderText = "Cuota";
            dtgCalendario.Columns["cuota"].Width = 40;
            dtgCalendario.Columns["cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            
            dtgCalendario.Columns["fecha"].Width = 83;
            dtgCalendario.Columns["fecha"].HeaderText = "Fecha Pago";
            dtgCalendario.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            
            dtgCalendario.Columns["dias"].Width = 75;
            dtgCalendario.Columns["dias"].HeaderText = "Frecuencia Pago";
            dtgCalendario.Columns["dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            
            dtgCalendario.Columns["sal_cap"].Width = 73;
            dtgCalendario.Columns["sal_cap"].HeaderText = "Sal. Cap.";
            dtgCalendario.Columns["sal_cap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["sal_cap"].DefaultCellStyle.Format = "#,0.00";

            
            dtgCalendario.Columns["capital"].Width = 73;
            dtgCalendario.Columns["capital"].HeaderText = "Capital";
            dtgCalendario.Columns["capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["capital"].DefaultCellStyle.Format = "#,0.00";

            
            dtgCalendario.Columns["interes"].Width = 74;
            dtgCalendario.Columns["interes"].HeaderText = "Interés";
            dtgCalendario.Columns["interes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["interes"].DefaultCellStyle.Format = "#,0.00";

            
            dtgCalendario.Columns["comisiones"].Width = 74;
            dtgCalendario.Columns["comisiones"].HeaderText = "Seg.| Comi.";
            dtgCalendario.Columns["comisiones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["comisiones"].DefaultCellStyle.Format = "#,0.00";

            dtgCalendario.Columns["nAtrasoCuota"].Width = 73;
            dtgCalendario.Columns["nAtrasoCuota"].HeaderText = "Atraso";
            dtgCalendario.Columns["nAtrasoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dtgCalendario.Columns["nAtrasoCuota"].DefaultCellStyle.Format = "n0";

            dtgCalendario.Columns["nInteresComp"].Width = 75;
            dtgCalendario.Columns["nInteresComp"].HeaderText = "Interés Comp.";
            dtgCalendario.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            
            dtgCalendario.Columns["imp_cuota"].Width = 75;
            dtgCalendario.Columns["imp_cuota"].HeaderText = "Monto Cuota";
            dtgCalendario.Columns["imp_cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgCalendario.Columns["imp_cuota"].DefaultCellStyle.Format = "#,0.00";

            dtgCalendario.Columns["cuota"].DisplayIndex = 0;
            dtgCalendario.Columns["fecha"].DisplayIndex = 1;
            dtgCalendario.Columns["dias"].DisplayIndex = 2;
            dtgCalendario.Columns["sal_cap"].DisplayIndex = 3;
            dtgCalendario.Columns["capital"].DisplayIndex = 4;
            dtgCalendario.Columns["interes"].DisplayIndex = 5;
            dtgCalendario.Columns["comisiones"].DisplayIndex = 6;
            dtgCalendario.Columns["nAtrasoCuota"].DisplayIndex = 7;
            dtgCalendario.Columns["nInteresComp"].DisplayIndex = 8;
            dtgCalendario.Columns["imp_cuota"].DisplayIndex = 9;           

            
            dtgCalendario.Rows[0].Cells["fecha"].Style.BackColor = Color.Yellow;

            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgCalendario.CellFormatting += dataGridViewDetalleGastos_CellFormatting;
        }

        private void dataGridViewDetalleGastos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dtgCalendario.Columns["comisiones"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private bool validaingresodatos()
        {
            bool lvalidatos;
            lvalidatos = true;
            if (nMonto <= 0.00m)
            {
                MessageBox.Show("El Monto a desembolsar debe ser mayor a cero", "Validación de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalidatos = false;
                return lvalidatos;
            }

            if (nNumCuotas <= 0.00m)
            {
                MessageBox.Show("El número de cuotas debe ser mayor a cero", "Validación de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalidatos = false;
                return lvalidatos;
            }
            if (nDiasGracia < 0.00m)
            {
                MessageBox.Show("Los días de gracias deben ser mayor o iguales a cero", "Validación de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalidatos = false;
                return lvalidatos;
            }
            if ( Convert.ToDecimal(nPlazo) <= 0.00m)
            {
                MessageBox.Show("La frecuencia en días debe ser mayor a cero", "Validación de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalidatos = false;
                return lvalidatos;
            }

            if (nTasaInteres <= 0M)
            {
                MessageBox.Show("Debe ingresar la tasa de interes", "Validación de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalidatos = false;
                return lvalidatos;
            }

            return lvalidatos;
        }

        public void asignarMaxMinAnios()
        {
            nudAnios.Minimum =dFechaDesembolso.Year;
            if (this.nTipPeriodo.ToString() == "1")
            {
                nudAnios.Maximum = Math.Round(nudAnios.Minimum + (nNumCuotas / 12.0M), 0, MidpointRounding.ToEven) + 10M;
            }
            else
            {
                nudAnios.Maximum = nudAnios.Minimum + (Convert.ToDecimal(nPlazo) * Convert.ToDecimal(nNumCuotas) / 12.0M) + 10M;
            }
        }

        private void cargarEstructuradtModifica()
        {
            dtModificaciones.Columns.Clear();

            dtModificaciones.Columns.Add("cTipoAccion", typeof(string));
            dtModificaciones.Columns.Add("idTipoAccion", typeof(int));
            dtModificaciones.Columns.Add("nCuota", typeof(int));
            dtModificaciones.Columns.Add("nOtraCuota", typeof(int));
            dtModificaciones.Columns.Add("nMes", typeof(int));
            dtModificaciones.Columns.Add("cMes", typeof(string));
            dtModificaciones.Columns.Add("nAnio", typeof(int));
            dtModificaciones.Columns.Add("cAnio", typeof(string));
            dtModificaciones.Columns.Add("nMonto", typeof(decimal));
            dtModificaciones.Columns.Add("lIndTodAnios", typeof(bool));
            dtModificaciones.Columns.Add("idCuotalibre", typeof(int));
            dtModificaciones.Columns.Add("nDia", typeof(int));
        }

        public void CargarGridPlanPagos()
        {
            if ( dtCalendarioPagos == null )  
                return;

            cboAccionCuota1.SelectedIndex = -1;
            if (dtCalendarioPagos.Rows.Count > 0)
            {
                dtgCalendario.DataSource = dtCalendarioPagos;
            }

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
            if (nFormaCalculoTasa == 1)
            {
                txtTEA.Text = string.Format("{0:0.0000}", nTasaInteres);
                txtTEM.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1.00 + (double)nTasaInteres / 100.00), (1.0 / 12.0)) - 1.0) * 100.0), 4));
            }

            if (nFormaCalculoTasa == 2)
            {
                txtTEA.Text = string.Format("{0:0.0000}", Math.Round(((Math.Pow((1 + (double)nTasaInteres / 100.0), (360.0 / 30.0)) - 1) * 100.0), 4));
                txtTEM.Text = string.Format("{0:0.0000}", nTasaInteres);
            }

            formatoGridPlanPago();
            asignarTotalesPP();
            asignarTCEA(nMonto);
            dtgCalendario.ClearSelection();
        }

        #endregion

        private void ControlReprogramacionEspecial()
        {
            string cLstModificacionTPlanPago = Convert.ToString(clsVarApl.dicVarGen["cLstModificacionCuotaBloqTPlanPago"]);
            List<int> lstTipoPlanPagoHabilitados = cLstModificacionTPlanPago.Split(',').Select(Int32.Parse).ToList();

            if (lstTipoPlanPagoHabilitados.Any(item => item == idTipoPlanPago))
            {
                this.cboAccionCuota1.Enabled = false;
                if (this.dtgCalendario.Rows.Count > 0) this.dtgCalendario.Rows[0].Selected = true;
                this.btnModificaPP.Enabled = false;
                this.btnCancelarModificaciones.Visible = false;
                this.dtgCalendario.ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void dtgCalendario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgCalendario.Columns[e.ColumnIndex].Name == "comisiones")
                {
                    DataGridViewRow selectedRow = dtgCalendario.Rows[e.RowIndex];
                    List<clsOtrosGastos> listaGastos = DataTableToList.ConvertTo<clsOtrosGastos>(dtGastosPP) as List<clsOtrosGastos>;
                    frmDetalleOtrosGastos detalleForm = new frmDetalleOtrosGastos();
                    DataGridView dataGridViewDetalleGastos = detalleForm.dtgDetalleGastos;

                    var query = from gasto in listaGastos
                                join concepto in lstConceptos on gasto.idTipoGasto equals concepto.idConcepto
                                select new
                                {
                                    gasto.idCuota,
                                    concepto.cNombreCorto,
                                    gasto.nGasto
                                };
                    
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuota", typeof(string));

                    foreach (var item in query)
                    {
                        if (!dataTable.Columns.Contains(item.cNombreCorto))
                            dataTable.Columns.Add(item.cNombreCorto, typeof(decimal));

                        DataRow existingRow = null;
                         foreach (DataRow row in dataTable.Rows)
                        {
                            if (Convert.ToInt32(row["Cuota"]) == item.idCuota)
                            {
                                existingRow = row;
                                break;
                            }
                        }
                        if (existingRow == null)
                        {
                            existingRow = dataTable.NewRow();
                            existingRow["Cuota"] = item.idCuota;
                            dataTable.Rows.Add(existingRow);
                        }
                        existingRow[item.cNombreCorto] = item.nGasto;
                    }

                    dataTable.Columns.Add("Total", typeof(decimal));

                    DataRow totalRow = dataTable.NewRow();

                    int totalFilas = dataTable.Rows.Count;
                    int totalColumnas = dataTable.Columns.Count;

                    decimal[] sumatorias = new decimal[totalColumnas];

                    for (int fila = 0; fila < totalFilas; fila++)
                    {
                        for (int columna = 0; columna < totalColumnas; columna++)
                        {
                            object cellValue = dataTable.Rows[fila][columna];
                            if (cellValue != null)
                            {
                                decimal valorCelda;
                                if (decimal.TryParse(cellValue.ToString(), out valorCelda))
                                {
                                    sumatorias[columna] += valorCelda;
                                }
                            }
                        }
                    }

                    DataRow rowSumatoria = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        rowSumatoria[columna] = sumatorias[columna];

                    dataTable.Rows.Add(rowSumatoria);

                    int ultimaFilaIndex = dataTable.Rows.Count - 1;
                    dataTable.Rows[ultimaFilaIndex][0] = "TOTAL";

                    dataGridViewDetalleGastos.DataSource = dataTable;

                    dataGridViewDetalleGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dgvRow.Cells.Count; i++)
                        {
                            decimal valor;
                            if (dgvRow.Cells[i].Value != null && decimal.TryParse(dgvRow.Cells[i].Value.ToString(), out valor))
                                total += valor;
                        }
                        dgvRow.Cells["TOTAL"].Value = total;
                    }

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                    {
                        if (columna.Name == "Cuota")
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        else
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dataGridViewDetalleGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    
                    dataGridViewDetalleGastos.Columns["Cuota"].Width = 50;
                    dataGridViewDetalleGastos.Columns["Total"].Width = 70;
                    
                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                        if (columna.Name != "Cuota" && columna.Name != "Total")
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 

                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error interno: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
