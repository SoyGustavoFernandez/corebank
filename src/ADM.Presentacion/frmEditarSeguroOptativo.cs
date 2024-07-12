using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmEditarSeguroOptativo : frmBase
    {
        #region Variables Globales
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt = new clsMantenimientoSeguroOptativo();
        clsCNConfigurarSeguroOptativo clsMantenimiento   = new clsCNConfigurarSeguroOptativo();
        public int idTipoSeguro, idTipoValSegOptativo, idConcepto, idTipoPagoSeguroOptativo, idUsuario = clsVarGlobal.User.idUsuario;
        public string cTipoSeguro;
        public decimal nValor;
        public bool lvigente;
        private bool lPerfilModificado = false;

        #region SeguroOncologico
        clsHistoricoSegurosOptativos objFrmEditarSeguroOptativo = new clsHistoricoSegurosOptativos();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        #endregion

        #endregion

        public frmEditarSeguroOptativo()
        {
            InitializeComponent();
        }

        public frmEditarSeguroOptativo(clsMantenimientoSeguroOptativo _clsDatosSeguroOpt, clsHistoricoSegurosOptativos _objFrmEditarSeguroOptativo)
        {
            InitializeComponent();
            clsDatosSeguroOpt = _clsDatosSeguroOpt;
            objFrmEditarSeguroOptativo = _objFrmEditarSeguroOptativo;
        }

        #region Eventos
        private void frmEditarSeguroOptativo_Load(object sender, EventArgs e)
        {
            CargarConceptoRecibo();
            CargarTipValSegOpt();
            CargarTipPagSegOpt();
            ListaPlanSeguro();

            idTipoSeguro                    = clsDatosSeguroOpt.idTipoSeguro;
            txtTipoSeguro.Text              = clsDatosSeguroOpt.cTipoSeguro;
            txtPrima.Text                   = Convert.ToString(clsDatosSeguroOpt.nValor);
            cboTipoValor.SelectedValue      = clsDatosSeguroOpt.idTipoValSegOptativo;
            cboConceptoRecibo.SelectedValue = clsDatosSeguroOpt.idConcepto;
            cboTipoPago.SelectedValue       = clsDatosSeguroOpt.idTipoPagoSeguroOptativo;
            chbVigente.Checked              = clsDatosSeguroOpt.lvigente;
            EditarControles(clsDatosSeguroOpt.lEsPaqueteSeguro);
        }

        private void EditarControles(bool esPaquete)
        {
            txtTipoSeguro.ReadOnly = esPaquete;
            txtPrima.ReadOnly = esPaquete;
            cboTipoValor.Enabled = !esPaquete;
            cboConceptoRecibo.Enabled = !esPaquete;
            cboTipoPago.Enabled = !esPaquete;
            chbVigente.Enabled = !esPaquete;
            lblPaquetes.Visible = esPaquete;
            txtPrecioMensual.ReadOnly = esPaquete;
            btnCancelarPlan.Enabled = !esPaquete;
            btnMiniEditar1.Enabled = !esPaquete;
            btnGrabar1.Enabled = !esPaquete;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            try
            {
            if (ValidarRegistro())
            {
                cTipoSeguro              = txtTipoSeguro.Text;
                nValor                   = Convert.ToDecimal(txtPrima.Text);
                idTipoValSegOptativo     = Convert.ToInt32(Convert.ToString(cboTipoValor.SelectedValue));
                idConcepto               = Convert.ToInt32(Convert.ToString(cboConceptoRecibo.SelectedValue));
                idTipoPagoSeguroOptativo = Convert.ToInt32(Convert.ToString(cboTipoPago.SelectedValue));
                lvigente                 = chbVigente.Checked;

                DataTable dtMatenimientoSegOpatativo = clsMantenimiento.CNMantenimientoSeguroOptativo(idTipoSeguro, cTipoSeguro, nValor, idTipoValSegOptativo, idConcepto, idTipoPagoSeguroOptativo, lvigente, idUsuario);
                MessageBox.Show(dtMatenimientoSegOpatativo.Rows[0]["cMensaje"].ToString(), "Mantenimiento de seguros", MessageBoxButtons.OK, ((int)dtMatenimientoSegOpatativo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

                if ((int)dtMatenimientoSegOpatativo.Rows[0]["idError"] == 1)
                    _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguro("REGISTRO DE SEGURO MODIFICADO", AccionHistorico.EDITAR,
                    new clsMantenimientoSeguroOptativo
                    {
                        idTipoSeguro = idTipoSeguro,
                        cTipoSeguro = txtTipoSeguro.Text,
                        nValor = nValor,
                        idTipoValSegOptativo = idTipoValSegOptativo,
                        cTipoValSegOptativo = cboTipoValor.Text,
                        idConcepto = idConcepto,
                        cConcepto = cboConceptoRecibo.Text,
                        idTipoPagoSeguroOptativo = idTipoPagoSeguroOptativo,
                        cTipoPagoSeguroOptativo = cboTipoPago.Text,
                        lvigente = chbVigente.Checked
                    },
                   objFrmEditarSeguroOptativo, lPerfilModificado);

                this.Dispose();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Ocurrió un error, por favor completar los datos correctamente antes de guardar", "Registro seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlExpandCollapse1_Paint(object sender, PaintEventArgs e)
        {
            if (dtgListaPlanSeguro.RowCount == 0)
            {
                pnlExpandCollapse1.Visible = false;
                
            }
            else
            {
                txtPrima.Enabled = false;
            }
        }

        private void dtgListaPlanSeguro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgListaPlanSeguro_SelectionChanged(sender, e);
        }

        private void dtgListaPlanSeguro_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListaPlanSeguro.RowCount >= 0)
            {
                txtPrecioMensual.Text    = Convert.ToString(dtgListaPlanSeguro.CurrentRow.Cells["nPrecioMensual"].Value);
                txtPrecioMensual.Enabled = false;
                btnMiniEditar1.Enabled   = true;
            }
        }

        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            clsMantenimientoPlanSeguroVida objPlanPagoActual = new clsMantenimientoPlanSeguroVida
            {
                idTipoPlan = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idTipoPlan"].Value.ToString()),
                nPrecioMensual = Convert.ToDecimal(dtgListaPlanSeguro.CurrentRow.Cells["nPrecioMensual"].Value.ToString()),
                nMeses = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMeses"].Value.ToString()),
                nPrecioTotal = Convert.ToDecimal(dtgListaPlanSeguro.CurrentRow.Cells["nPrecioTotal"].Value.ToString()),
                cDescripcion = dtgListaPlanSeguro.CurrentRow.Cells["cDescripcion"].Value.ToString(),
                idTipoSeguro = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idTipoSeguro"].Value.ToString()),
                idConcepto = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idConcepto"].Value.ToString()),
                cTipoSeguro = txtTipoSeguro.Text,
                nMinMes = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMinMes"].Value.ToString()),
                nMaxMes = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMaxMes"].Value.ToString()),
                lFijo = Convert.ToBoolean(dtgListaPlanSeguro.CurrentRow.Cells["lFijo"].Value.ToString()),
                lSolicitud = Convert.ToBoolean(dtgListaPlanSeguro.CurrentRow.Cells["lSolicitud"].Value.ToString()),
                lRedondear = true //Convert.ToBoolean(dtgListaPlanSeguro.CurrentRow.Cells["lRedondear"].Value.ToString())
            };

            frmPlanPagoSeguro frmPlanPagoSeguro = new frmPlanPagoSeguro(objPlanPagoActual, objFrmEditarSeguroOptativo, clsDatosSeguroOpt);
            frmPlanPagoSeguro.ShowDialog();
            ListaPlanSeguro();
        }

        private void btnAceptarPlan_Click(object sender, EventArgs e)
        {
            dtgListaPlanSeguro.SelectionChanged -= new EventHandler(dtgListaPlanSeguro_SelectionChanged);
            int nfilaseleccionada    = Convert.ToInt32(dtgListaPlanSeguro.CurrentCell.RowIndex);
            btnMiniEditar1.Enabled   = true;
            txtPrecioMensual.Enabled = false;

            AsignarNuevoValorPlan();
            ListaPlanSeguro();
            dtgListaPlanSeguro.CurrentCell       = dtgListaPlanSeguro.Rows[nfilaseleccionada].Cells["cDescripcion"];
            dtgListaPlanSeguro.SelectionChanged += new EventHandler(dtgListaPlanSeguro_SelectionChanged);
            lPerfilModificado = true;
        }

        private void btnCancelarPlan_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("¿Está seguro de desactivar el plan de pagos actual", "Mantenimiento de seguros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg != DialogResult.Yes)
                return;
            
            clsMantenimientoPlanSeguroVida objPlanPagoActual = new clsMantenimientoPlanSeguroVida
            {
                idTipoPlan = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idTipoPlan"].Value.ToString()),
                nPrecioMensual = Convert.ToDecimal(dtgListaPlanSeguro.CurrentRow.Cells["nPrecioMensual"].Value.ToString()),
                nMeses = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMeses"].Value.ToString()),
                cDescripcion = dtgListaPlanSeguro.CurrentRow.Cells["cDescripcion"].Value.ToString(),
                idTipoSeguro = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idTipoSeguro"].Value.ToString()),
                idConcepto = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idConcepto"].Value.ToString()),
                cTipoSeguro = txtTipoSeguro.Text,
                nMinMes = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMinMes"].Value.ToString()),
                nMaxMes = Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["nMaxMes"].Value.ToString()),
                lFijo = false,
                lSolicitud = Convert.ToBoolean(dtgListaPlanSeguro.CurrentRow.Cells["lSolicitud"].Value.ToString())
            };

            try
            {
                clsDatosSeguroOpt.listaValseguro = DataTableToList.ConvertTo<clsMantenimientoPlanSeguroVida>(new clsCNPlanPagoSeguro().InsUpdPlanPagoSeguro(objPlanPagoActual)).ToList<clsMantenimientoPlanSeguroVida>();
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPlanes("REGISTRO DE PLAN ELIMINADO", AccionHistorico.ELIMINAR, objPlanPagoActual, objFrmEditarSeguroOptativo);

                MessageBox.Show("Se desactivó el plan de pago de manera exitosa", "Mantenimiento de seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ListaPlanSeguro();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error en la transacción: " + ex.Message, "Mantenimiento de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //dtgListaPlanSeguro_SelectionChanged(sender, e);
        }
        #endregion

        #region Metodos
        public void ListaPlanSeguro()
        {
            dtgListaPlanSeguro.DataSource = clsDatosSeguroOpt.listaValseguro;
            AsignarValoresPlanes();
        }

        void AsignarValoresPlanes()
        {
            for (int i = 0; i < dtgListaPlanSeguro.Columns.Count; i++)
            {
                dtgListaPlanSeguro.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgListaPlanSeguro.RowCount >= 0)
            {
                dtgListaPlanSeguro.Columns["cDescripcion"].AutoSizeMode   = DataGridViewAutoSizeColumnMode.AllCells;
                dtgListaPlanSeguro.Columns["nPrecioMensual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgListaPlanSeguro.Columns["nMeses"].AutoSizeMode         = DataGridViewAutoSizeColumnMode.AllCells;
                dtgListaPlanSeguro.Columns["nPrecioTotal"].AutoSizeMode   = DataGridViewAutoSizeColumnMode.AllCells;
                dtgListaPlanSeguro.Columns["lFijo"].AutoSizeMode          = DataGridViewAutoSizeColumnMode.AllCells;

                dtgListaPlanSeguro.Columns["cDescripcion"].Width   = 211;
                dtgListaPlanSeguro.Columns["nMeses"].Width         = 50;
                dtgListaPlanSeguro.Columns["nPrecioMensual"].Width = 50;
                dtgListaPlanSeguro.Columns["lFijo"].Width          = 50;
                dtgListaPlanSeguro.Columns["nPrecioTotal"].Width = 50;

                dtgListaPlanSeguro.ReadOnly = true;
                dtgListaPlanSeguro.Columns["idTipoPlan"].Visible     = false;
                dtgListaPlanSeguro.Columns["idTipoSeguro"].Visible   = false;
                dtgListaPlanSeguro.Columns["cDescripcion"].Visible   = true;
                dtgListaPlanSeguro.Columns["nPrecioMensual"].Visible = true;
                dtgListaPlanSeguro.Columns["nMeses"].Visible         = true;
                dtgListaPlanSeguro.Columns["nPrecioTotal"].Visible   = true;
                dtgListaPlanSeguro.Columns["nMinMes"].Visible        = false;
                dtgListaPlanSeguro.Columns["nMaxMes"].Visible        = false;
                dtgListaPlanSeguro.Columns["lFijo"].Visible          = true;
                dtgListaPlanSeguro.Columns["lRedondear"].Visible     = false;
                dtgListaPlanSeguro.Columns["lSolicitud"].Visible     = false;
                dtgListaPlanSeguro.Columns["idConcepto"].Visible     = false;
                dtgListaPlanSeguro.Columns["cTipoSeguro"].Visible    = false;

                dtgListaPlanSeguro.Columns["cDescripcion"].HeaderText   = "Descripción";
                dtgListaPlanSeguro.Columns["nPrecioMensual"].HeaderText = "Precio Mensual";
                dtgListaPlanSeguro.Columns["nMeses"].HeaderText         = "Meses";
                dtgListaPlanSeguro.Columns["nPrecioTotal"].HeaderText   = "Precio Total";
                dtgListaPlanSeguro.Columns["lFijo"].HeaderText          = "Vigente";

                //Coloco el orden a mostrar de las columnas
                dtgListaPlanSeguro.Columns["nPrecioMensual"].DisplayIndex = 0;
                dtgListaPlanSeguro.Columns["nMeses"].DisplayIndex         = 1;
                dtgListaPlanSeguro.Columns["nPrecioTotal"].DisplayIndex   = 2;
                dtgListaPlanSeguro.Columns["cDescripcion"].DisplayIndex   = 3;
                dtgListaPlanSeguro.Columns["lFijo"].DisplayIndex          = 4;

            }
        }

        private void CargarTipValSegOpt()
        {
            cboTipoValor.DataSource     = clsMantenimiento.CNListarTipValSegOpt();
            cboTipoValor.DisplayMember  = "cTipoValSegOptativo";
            cboTipoValor.ValueMember    = "idTipoValSegOptativo";
            cboTipoValor.SelectedIndex  = -1;
            cboTipoValor.Enabled        = false;
        }

        private void CargarConceptoRecibo()
        {
            cboConceptoRecibo.DataSource    = clsMantenimiento.CNListarConceptoRecibo();
            cboConceptoRecibo.DisplayMember = "cConcepto";
            cboConceptoRecibo.ValueMember   = "idConcepto";
            cboConceptoRecibo.SelectedIndex = -1;
        }

        private void btnAgregarPlanPagos_Click(object sender, EventArgs e)
        {
            clsMantenimientoPlanSeguroVida objPlanPagoActual = new clsMantenimientoPlanSeguroVida();
            objPlanPagoActual.cTipoSeguro = txtTipoSeguro.Text;
            objPlanPagoActual.idTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
            objPlanPagoActual.idConcepto = Convert.ToInt32(Convert.ToString(cboConceptoRecibo.SelectedValue));
            frmPlanPagoSeguro frmPlanPagoSeguro = new frmPlanPagoSeguro(objPlanPagoActual, objFrmEditarSeguroOptativo, clsDatosSeguroOpt);
            frmPlanPagoSeguro.ShowDialog();
            ListaPlanSeguro();
        }

        private void CargarTipPagSegOpt()
        {
            cboTipoPago.DataSource    = clsMantenimiento.CNListarTipPagSegOpt();
            cboTipoPago.DisplayMember = "cTipoPagoSeguroOptativo";
            cboTipoPago.ValueMember   = "idTipoPagoSeguroOptativo";
            cboTipoPago.SelectedIndex = -1;
        }

        private bool ValidarRegistro()
        {
            if (txtTipoSeguro.Text.Trim().Length < 3)
            {
                MessageBox.Show("Debe ingresar nombre del seguro.", "Registro seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPrima.Text.Trim() == "" || Convert.ToDecimal(txtPrima.Text) <= 0.00m)
            {
                MessageBox.Show("El monto de la prima debe ser mayor a cero.", "Registro seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarPlanSeguroVida()
        {
            if (txtPrecioMensual.Text.Trim() == "" || Convert.ToDecimal(txtPrecioMensual.Text) <= 0.00m)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Registro seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        void AsignarNuevoValorPlan()
        {
            clsDatosSeguroOpt.listaValseguro = clsDatosSeguroOpt.listaValseguro.Select(i =>
            {
                if (i.idTipoPlan == Convert.ToInt32(dtgListaPlanSeguro.CurrentRow.Cells["idTipoPlan"].Value.ToString()))
                {
                    if (ValidarPlanSeguroVida())
                    {
                        i.nPrecioMensual = (!String.IsNullOrEmpty(txtPrecioMensual.Text)) ? Convert.ToDecimal(txtPrecioMensual.Text) : 0;
                    }
                }
                return i;
            }).ToList();
        }
        #endregion
    }
}
