using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmMantenimientoComisiones : frmBase
    {
        #region Variables

        private List<clsConfigComisiones> listConfComisiones;
        private BindingSource bsConfComisionesM = new BindingSource();
        private BindingSource bsConfComisionesD = new BindingSource();

        static class eTipoModalidadPago
        {
            public const string Porcentual = "Valor Porcentual";
            public const string Fijo = "Monto Fijo";
        }

        static class eTipoRango
        {
            public const string Cantidad = "Cantidad";
            public const string Monto = "Monto";
        }

        static class eAsumeComision
        {
            public const int CLA = 1;
            public const int Cliente = 2;
        }

        #endregion

        #region Metodos Publicos

        public frmMantenimientoComisiones()
        {
            InitializeComponent();
            obtenerConfComisiones();
            inicializaTablaConfCanal();
            inicializaTablaConfComision();
            formatearDataGridView();
            cargarCombos();
        }
        
        #endregion

        #region Metodos Privados

        private void obtenerConfComisiones()
        {
            DataSet dsConfComisiones = new clsCNComisionesCanalesElec().ObtenerConfComisiones();

            List<clsConfigComisiones> listConfComisionesM = DataTableToList.ConvertTo<clsConfigComisiones>(dsConfComisiones.Tables[0]) as List<clsConfigComisiones>;
            List<clsDetalleConfigComisiones> listConfComisionesD = DataTableToList.ConvertTo<clsDetalleConfigComisiones>(dsConfComisiones.Tables[1]) as List<clsDetalleConfigComisiones>;

            foreach (var item in listConfComisionesM)
                item.listDetalleConfigComisiones = listConfComisionesD.FindAll(x => x.idMConfComision == item.idMConfComision);
            
            this.listConfComisiones = listConfComisionesM;
        }

        private void inicializaTablaConfCanal()
        {
            this.bsConfComisionesM.DataSource = this.listConfComisiones;
            this.dtgMConfComision.DataSource = this.bsConfComisionesM;

            foreach (DataGridViewColumn column in this.dtgMConfComision.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgMConfComision.Columns["cCanal"].Visible = true;
            dtgMConfComision.Columns["cCanalServicio"].Visible = true;
            dtgMConfComision.Columns["cAsumeComision"].Visible = true;
            dtgMConfComision.Columns["cTipoRango"].Visible = true;
            dtgMConfComision.Columns["cTipoModalidadPago"].Visible = true;

            dtgMConfComision.Columns["cCanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMConfComision.Columns["cCanalServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMConfComision.Columns["cAsumeComision"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMConfComision.Columns["cTipoRango"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMConfComision.Columns["cTipoModalidadPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgMConfComision.Columns["cCanal"].HeaderText = "Canal";
            dtgMConfComision.Columns["cCanalServicio"].HeaderText = "Canal Servicio";
            dtgMConfComision.Columns["cAsumeComision"].HeaderText = "Asume Comision";
            dtgMConfComision.Columns["cTipoRango"].HeaderText = "Tipo Rango";
            dtgMConfComision.Columns["cTipoModalidadPago"].HeaderText = "Modalidad Pago";
        }

        private void inicializaTablaConfComision()
        {
            var listDetalleConfigComisiones = listConfComisiones.SelectMany(config => config.listDetalleConfigComisiones).ToList();

            this.bsConfComisionesD.DataSource = listDetalleConfigComisiones;
            this.dtgDConfComision.DataSource = this.bsConfComisionesD;

            foreach (DataGridViewColumn column in this.dtgDConfComision.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgDConfComision.Columns["cMoneda"].Visible = true;
            this.dtgDConfComision.Columns["cZona"].Visible = true;

            this.dtgDConfComision.Columns["cMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgDConfComision.Columns["cZona"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgDConfComision.Columns["nCantidadMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgDConfComision.Columns["nCantidadMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgDConfComision.Columns["nMontoCuotaMin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDConfComision.Columns["nMontoCuotaMax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDConfComision.Columns["nMontoCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgDConfComision.Columns["nPorcentajeCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dtgDConfComision.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgDConfComision.Columns["cZona"].HeaderText = "Zona";
            this.dtgDConfComision.Columns["nCantidadMin"].HeaderText = "Cantidad Min";
            this.dtgDConfComision.Columns["nCantidadMax"].HeaderText = "Cantidad Max";
            this.dtgDConfComision.Columns["nMontoCuotaMin"].HeaderText = "Monto Min";
            this.dtgDConfComision.Columns["nMontoCuotaMax"].HeaderText = "Monto Max";
            this.dtgDConfComision.Columns["nMontoCosto"].HeaderText = "Monto Fijo";
            this.dtgDConfComision.Columns["nPorcentajeCosto"].HeaderText = "Valor Porcentual";
        }

        private void formatearDataGridView()
        {
            this.dtgMConfComision.Margin = new System.Windows.Forms.Padding(0);
            this.dtgMConfComision.MultiSelect = false;
            this.dtgMConfComision.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgMConfComision.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMConfComision.RowHeadersVisible = false;
            this.dtgMConfComision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dtgDConfComision.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDConfComision.MultiSelect = false;
            this.dtgDConfComision.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgDConfComision.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDConfComision.RowHeadersVisible = false;
            this.dtgDConfComision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void cargarCombos()
        {
            this.cboCanalElecM.SelectedValueChanged -= new System.EventHandler(this.cboCanalElecM_SelectedValueChanged);
            this.cboCanalElecD.SelectedValueChanged -= new System.EventHandler(this.cboCanalElecD_SelectedValueChanged);
            this.cboTipoCanalServD.SelectedValueChanged -= new System.EventHandler(this.cboTipoCanalServD_SelectedValueChanged);
            this.cboZonas.SelectedValueChanged -= new System.EventHandler(this.cboZonas_SelectedValueChanged);
            this.cboAsumeComMixto.SelectedValueChanged -= new System.EventHandler(this.cboAsumeComMixto_SelectedValueChanged);

            this.cboZonas.AgregarTodos();
            this.cboZonas.SelectedValue = 0; //Todos
            this.cboZonas.Enabled = true;

            this.cboMoneda.CargaDatos();
            this.cboMoneda.SelectedValue = 1; //Soles
            this.cboMoneda.Enabled = true;

            this.cboCanalElecM.DataSource = null;
            this.cboCanalElecD.DataSource = null;
            DataTable dtCanales = new clsCNComisionesCanalesElec().ObtenerCanalesElectronicos();
            if (dtCanales.Rows.Count > 0)
            {
                this.cboCanalElecM.DataSource = dtCanales;
                this.cboCanalElecM.ValueMember = "idCanal";
                this.cboCanalElecM.DisplayMember = "cNombreCanal";

                this.cboCanalElecD.DataSource = dtCanales;
                this.cboCanalElecD.ValueMember = "idCanal";
                this.cboCanalElecD.DisplayMember = "cNombreCanal";
            }

            this.cboTipoCanalServM.DataSource = null;
            this.cboTipoCanalServD.DataSource = null;
            DataTable dtTipoCanalServicio = new clsCNComisionesCanalesElec().ObtenerTipoCanalServicio();
            if (dtTipoCanalServicio.Rows.Count > 0)
            {
                this.cboTipoCanalServM.DataSource = dtTipoCanalServicio;
                this.cboTipoCanalServM.ValueMember = "idTipoCanalServicio";
                this.cboTipoCanalServM.DisplayMember = "cNombre";

                this.cboTipoCanalServD.DataSource = dtTipoCanalServicio;
                this.cboTipoCanalServD.ValueMember = "idTipoCanalServicio";
                this.cboTipoCanalServD.DisplayMember = "cNombre";
            }

            this.cboTipoAsumeComi.DataSource = null;
            this.cboAsumeComMixto.DataSource = null;
            DataTable dtAsumeComision = new clsCNComisionesCanalesElec().ObtenerTipoAsumeComision();
            if (dtAsumeComision.Rows.Count > 0)
            {
                this.cboTipoAsumeComi.DataSource = dtAsumeComision;
                this.cboTipoAsumeComi.ValueMember = "idAsumeComision";
                this.cboTipoAsumeComi.DisplayMember = "cNombre";

                this.cboAsumeComMixto.DataSource = dtAsumeComision;
                this.cboAsumeComMixto.ValueMember = "idAsumeComision";
                this.cboAsumeComMixto.DisplayMember = "cNombre";
            }

            this.cboTipoRango.DataSource = null;
            DataTable dtTipoRango = new clsCNComisionesCanalesElec().ObtenerTipoRango();
            if (dtTipoRango.Rows.Count > 0)
            {
                this.cboTipoRango.DataSource = dtTipoRango;
                this.cboTipoRango.ValueMember = "idTipoRango";
                this.cboTipoRango.DisplayMember = "cNombre";
            }

            this.cboTipoModalidadPago.DataSource = null;
            DataTable dtModalidadPago = new clsCNComisionesCanalesElec().ObtenerTipoModalidadPago();
            if (dtModalidadPago.Rows.Count > 0)
            {
                this.cboTipoModalidadPago.DataSource = dtModalidadPago;
                this.cboTipoModalidadPago.ValueMember = "idTipoModalidadPago";
                this.cboTipoModalidadPago.DisplayMember = "cNombre";
            }

            this.cboCanalElecM.SelectedValueChanged += new System.EventHandler(this.cboCanalElecM_SelectedValueChanged);
            this.cboCanalElecD.SelectedValueChanged += new System.EventHandler(this.cboCanalElecD_SelectedValueChanged);
            this.cboTipoCanalServD.SelectedValueChanged += new System.EventHandler(this.cboTipoCanalServD_SelectedValueChanged);
            this.cboZonas.SelectedValueChanged += new System.EventHandler(this.cboZonas_SelectedValueChanged);
            this.cboAsumeComMixto.SelectedValueChanged += new System.EventHandler(this.cboAsumeComMixto_SelectedValueChanged);

            this.cboCanalElecM_SelectedValueChanged(null,null);
            this.cboCanalElecD_SelectedValueChanged(null, null);
        }

        private void limpiarFormularioCanal()
        {
            this.cboTipoCanalServM.SelectedIndex = -1;
            this.cboTipoRango.SelectedIndex = -1;
            this.cboTipoAsumeComi.SelectedIndex = -1;
            this.cboTipoModalidadPago.SelectedIndex = -1;
            this.txtNumeroCuenta.Text = String.Empty;
            this.dtpIniVigencia.Value = new DateTime(2010,01,01);
            this.dtpFinVigencia.Value = new DateTime(2050,12,31);
            this.chcVigente.Checked = false;
        }

        private void limpiarFormularioComision()
        {
            this.txtMin.Text = "0";
            this.txtMax.Text = "0";
            this.txtCosto.Text = "0";
            this.cboMoneda.SelectedValue = -1;
        }

        private void filtraConfComisiones()
        {
            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            int idTipoCanalServ = Convert.ToInt32(this.cboTipoCanalServD.SelectedValue);
            int idZona = Convert.ToInt32(this.cboZonas.SelectedValue);
            int idAsumeComision = Convert.ToInt32(this.cboAsumeComMixto.SelectedValue);

            bool lAplicaComMixta = this.listConfComisiones.Where(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ).Select(y => y.idCanalServicio)
                                                                      .GroupBy(z => z).Any(group => group.Count() > 1);

            this.cboAsumeComMixto.Visible = lAplicaComMixta ? true : false;
            this.lblComMixto.Visible = lAplicaComMixta ? true : false;

            this.bsConfComisionesD.DataSource = this.listConfComisiones.FindAll(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ && x.idAsumeComision == idAsumeComision && x.lActivo).
                                                                        SelectMany(config => config.listDetalleConfigComisiones).ToList().
                                                                        FindAll(y => y.idZona == idZona || idZona == 0);
            this.bsConfComisionesD.ResetBindings(true);

            dtgDConfComision.Columns["idDConfComision"].Visible = false;

            var objMaestro = this.listConfComisiones.Find(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ && x.idAsumeComision == idAsumeComision);

            if (this.listConfComisiones.Count <= 0)
                goto limpiarFormularioComision;

            if (objMaestro == null)
                objMaestro = this.listConfComisiones.First();

            if (objMaestro.cTipoRango == eTipoRango.Monto)
            {
                this.dtgDConfComision.Columns["nMontoCuotaMin"].Visible = true;
                this.dtgDConfComision.Columns["nMontoCuotaMax"].Visible = true;
                this.dtgDConfComision.Columns["nCantidadMin"].Visible = false;
                this.dtgDConfComision.Columns["nCantidadMax"].Visible = false;
                this.lblMin.Text = "Monto Minimo:";
                this.lblMax.Text = "Monto Maximo:";
            }
            else
            {
                this.dtgDConfComision.Columns["nMontoCuotaMin"].Visible = false;
                this.dtgDConfComision.Columns["nMontoCuotaMax"].Visible = false;
                this.dtgDConfComision.Columns["nCantidadMin"].Visible = true;
                this.dtgDConfComision.Columns["nCantidadMax"].Visible = true;
                this.lblMin.Text = "Cantidad Minima:";
                this.lblMax.Text = "Cantidad Maxima:";
            }

            if (objMaestro.cTipoModalidadPago == eTipoModalidadPago.Fijo)
            {
                this.dtgDConfComision.Columns["nMontoCosto"].Visible = true;
                this.dtgDConfComision.Columns["nPorcentajeCosto"].Visible = false;
                this.lblSigno.Text = "S/.";
            }
            else
            {
                this.dtgDConfComision.Columns["nMontoCosto"].Visible = false;
                this.dtgDConfComision.Columns["nPorcentajeCosto"].Visible = true;
                this.lblSigno.Text = "%";
            }

            limpiarFormularioComision:

            if (this.bsConfComisionesD.Count <= 0)
                limpiarFormularioComision();
        }

        private void habilitaBtnsCanal(bool lModoEdicion)
        {
            this.btnNuevoCanal.Enabled = !lModoEdicion;
            this.btnQuitarCanal.Enabled = !lModoEdicion;

            this.btnAgregarCanal.Enabled = lModoEdicion;
            this.btnEditarCanal.Enabled = lModoEdicion;
            this.btnCancelCanal.Enabled = lModoEdicion;
            this.plBotones.Enabled = !lModoEdicion;
        }

        private void habilitaBtnsComisiones(bool lModoEdicion)
        {
            this.btnNuevoComs.Enabled = !lModoEdicion;
            this.btnQuitarComs.Enabled = !lModoEdicion;

            this.btnAgregarComs.Enabled = lModoEdicion;
            this.btnEditarComs.Enabled = lModoEdicion;
            this.btnCancelComs.Enabled = lModoEdicion;
            this.chcAplicaTodos.Enabled = lModoEdicion;
            this.plBotones.Enabled = !lModoEdicion;
        }

        private void habilitaTabsControl(bool lModoEdicion)
        {
            this.tabCanales.Enabled = lModoEdicion;
            this.tabComision.Enabled = lModoEdicion;
        }

        private void habilitaControlesCanal(bool lModoEdicion)
        {
            this.cboCanalElecM.Enabled = !lModoEdicion;
            this.dtgMConfComision.Enabled = !lModoEdicion;
            this.gbConfCanal.Enabled = lModoEdicion;
            this.tabComision.Enabled = !lModoEdicion;
        }

        private void habilitaControlesComision(bool lModoEdicion)
        {
            this.cboCanalElecD.Enabled = !lModoEdicion;
            this.cboTipoCanalServD.Enabled = !lModoEdicion;
            this.cboZonas.Enabled = !lModoEdicion;
            this.cboAsumeComMixto.Enabled = !lModoEdicion;
            this.dtgDConfComision.Enabled = !lModoEdicion;
            this.gbConfComision.Enabled = lModoEdicion;
            this.tabCanales.Enabled = !lModoEdicion;
        }

        private bool validarComisiones(List<clsDetalleConfigComisiones> listConfComisionD, clsDetalleConfigComisiones objConf)
        {
            foreach (var item in listConfComisionD.FindAll(x => x.idZona == Convert.ToInt32(this.cboZonas.SelectedValue) && x.idMoneda == Convert.ToInt32(this.cboMoneda.SelectedValue)))
            {
                if (this.lblMin.Text == "Monto Minimo:" || this.lblMax.Text == "Monto Maximo:")
                {
                    if (objConf.nMontoCuotaMin >= item.nMontoCuotaMin && objConf.nMontoCuotaMin <= item.nMontoCuotaMax)
                    {
                        MessageBox.Show("El monto de cuota minimo está dentro de un rango existente",
                            "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objConf.nMontoCuotaMax >= item.nMontoCuotaMin && objConf.nMontoCuotaMax <= item.nMontoCuotaMax)
                    {
                        MessageBox.Show("El monto de cuota maximo está dentro de un rango existente",
                            "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    if (objConf.nCantidadMin >= item.nCantidadMin && objConf.nCantidadMin <= item.nCantidadMax)
                    {
                        MessageBox.Show("La cantidad minima está dentro de un rango existente",
                            "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (objConf.nCantidadMax >= item.nCantidadMin && objConf.nCantidadMax <= item.nCantidadMax)
                    {
                        MessageBox.Show("La cantidad maxima está dentro de un rango existente",
                            "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool validaCanales(clsConfigComisiones objConf, bool lHabilitaAlertaMixto)
        {
            if (objConf.dFechaFinVigencia <= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de fin seleccionada debe ser mayor a la fecha actual",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            List<clsConfigComisiones> listConfComisiones = this.listConfComisiones.FindAll(x => x.idCanal == objConf.idCanal &&
                                                                                           x.idMConfComision != objConf.idMConfComision &&
                                                                                           x.idCanalServicio == objConf.idCanalServicio &&
                                                                                           x.idAsumeComision == objConf.idAsumeComision);
            foreach (var item in listConfComisiones)
            {
                if (objConf.dFechaInicioVigencia >= item.dFechaInicioVigencia && objConf.dFechaInicioVigencia <= item.dFechaFinVigencia)
                {
                    MessageBox.Show("La fecha de inicio seleccionada está dentro de un rango existente",
                        "Mantenimiento Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (objConf.dFechaFinVigencia >= item.dFechaInicioVigencia && objConf.dFechaFinVigencia <= item.dFechaFinVigencia)
                {
                    MessageBox.Show("La fecha de fin seleccionada está dentro de un rango existente",
                        "Mantenimiento Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            
            foreach (var item in this.listConfComisiones.Where(item => item.idMConfComision != objConf.idMConfComision && item.idCanal == objConf.idCanal).ToList())
            {
                if (item.idCanalServicio == objConf.idCanalServicio && item.idAsumeComision != objConf.idAsumeComision && item.lActivo && lHabilitaAlertaMixto)
                {
                    DialogResult result = MessageBox.Show("Ya existe una configuración para el canal de servicio seleccionado. ¿Desea generar una comisión MIXTA?",
                                               "Mantenimiento de Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result != DialogResult.Yes) return false;
                }

                if (item.idCanalServicio == objConf.idCanalServicio && item.idAsumeComision == objConf.idAsumeComision && item.lActivo)
                {
                    MessageBox.Show("Existe una configuración activa para el canal de servicio seleccionado",
                                                               "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private string convierteConfCanalEnXML(List<clsConfigComisiones> listMConfComision)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idMConfComision", typeof(int));
            dt.Columns.Add("idCanal", typeof(int));
            dt.Columns.Add("cNumeroCuenta", typeof(string));
            dt.Columns.Add("idCanalServicio", typeof(int));
            dt.Columns.Add("idAsumeComision", typeof(int));
            dt.Columns.Add("idTipoRango", typeof(int));
            dt.Columns.Add("idTipoModalidadPago", typeof(int));
            dt.Columns.Add("dFechaInicioVigencia", typeof(DateTime));
            dt.Columns.Add("dFechaFinVigencia", typeof(DateTime));
            dt.Columns.Add("lActivo", typeof(bool));

            foreach (var item in listMConfComision)
            {
                DataRow row = dt.NewRow();
                row["idMConfComision"] = item.idMConfComision;
                row["idCanal"] = item.idCanal;
                row["cNumeroCuenta"] = item.cNumeroCuenta;
                row["idCanalServicio"] = item.idCanalServicio;
                row["idAsumeComision"] = item.idAsumeComision;
                row["idTipoRango"] = item.idTipoRango;
                row["idTipoModalidadPago"] = item.idTipoModalidadPago;
                row["dFechaInicioVigencia"] = item.dFechaInicioVigencia;
                row["dFechaFinVigencia"] = item.dFechaFinVigencia;
                row["lActivo"] = item.lActivo;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "data", "row");
        }

        private string convierteConfComisionEnXML(List<clsDetalleConfigComisiones> listDConfComision)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDConfComision", typeof(int));
            dt.Columns.Add("idMConfComision", typeof(int));
            dt.Columns.Add("idZona", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nMontoCuotaMin", typeof(decimal));
            dt.Columns.Add("nMontoCuotaMax", typeof(decimal));
            dt.Columns.Add("nCantidadMin", typeof(int));
            dt.Columns.Add("nCantidadMax", typeof(int));
            dt.Columns.Add("nMontoCosto", typeof(decimal));
            dt.Columns.Add("nPorcentajeCosto", typeof(decimal));

            foreach (var item in listDConfComision)
            {
                DataRow row = dt.NewRow();
                row["idDConfComision"] = item.idDConfComision;
                row["idMConfComision"] = item.idMConfComision;
                row["idZona"] = item.idZona;
                row["idMoneda"] = item.idMoneda;
                row["nMontoCuotaMin"] = item.nMontoCuotaMin;
                row["nMontoCuotaMax"] = item.nMontoCuotaMax;
                row["nCantidadMin"] = item.nCantidadMin;
                row["nCantidadMax"] = item.nCantidadMax;
                row["nMontoCosto"] = item.nMontoCosto;
                row["nPorcentajeCosto"] = item.nPorcentajeCosto;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "data", "row");
        }

        private bool validaCamposCanal()
        {
            if(this.cboTipoCanalServM.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Canal de Servicio",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.cboTipoAsumeComi.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar quien asume la comision",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.cboTipoRango.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de rango",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.cboTipoModalidadPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la modalidad de Pago",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNumeroCuenta.Text))
            {
                MessageBox.Show("Debe agregar un numero de cuenta asociado",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!this.chcVigente.Checked)
            {
                DialogResult result = MessageBox.Show("Esta creando un nuevo canal de servicio con estado Inactivo, ¿Desea continuar?",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result != DialogResult.Yes)
                    return false;
            }

            if ((int)cboTipoAsumeComi.SelectedValue == eAsumeComision.Cliente && cboTipoRango.Text == eTipoRango.Cantidad)
            {
                MessageBox.Show("El cliente no puede contigurar rangos por cantidad",
                                        "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos

        private void frmMantenimientoComisiones_Load(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            habilitaTabsControl(false);
            habilitaBtnsCanal(false);
            habilitaBtnsComisiones(false);

            this.gbConfCanal.Enabled = false;
            this.gbConfComision.Enabled = false;
        }

        //Eventos de ComboBox

        private void cboCanalElecM_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboCanalElecM.SelectedItem == null) return;

            int idCanal = Convert.ToInt32(this.cboCanalElecM.SelectedValue);
            int idTipoCanalServ = Convert.ToInt32(this.cboTipoCanalServD.SelectedValue);
            this.bsConfComisionesM.DataSource = this.listConfComisiones.FindAll(x => x.idCanal == idCanal);
            this.bsConfComisionesM.ResetBindings(true);

            bool lAplicaComMixta = this.listConfComisiones.Where(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ).Select(y => y.idCanalServicio)
                                                                      .GroupBy(z => z).Any(group => group.Count() > 1);

            this.cboAsumeComMixto.Visible = lAplicaComMixta ? true : false;
            this.lblComMixto.Visible = lAplicaComMixta ? true : false;

            dtgMConfComision.Columns["idMConfComision"].Visible = false;

            if (this.bsConfComisionesM.Count <= 0)
                limpiarFormularioCanal();
        }

        private void cboCanalElecD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboCanalElecD.SelectedItem == null) return;
            filtraConfComisiones();
        }

        private void cboTipoCanalServD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboTipoCanalServD.SelectedItem == null) return;
            filtraConfComisiones();
        }

        private void cboZonas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboZonas.SelectedItem == null) return;
            filtraConfComisiones();
        }

        private void cboAsumeComMixto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboAsumeComMixto.SelectedItem == null) return;
            filtraConfComisiones();
        }

        //Eventos de botones Generales

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            foreach (var item in this.listConfComisiones)
            {
                if (item.cTipoRango == eTipoRango.Cantidad)
                    item.listDetalleConfigComisiones.ForEach(x => { x.nMontoCuotaMin = 0; x.nMontoCuotaMax = 0; });
                else
                    item.listDetalleConfigComisiones.ForEach(x => { x.nCantidadMin = 0; x.nCantidadMax = 0; });

                if (item.cTipoModalidadPago == eTipoModalidadPago.Porcentual)
                    item.listDetalleConfigComisiones.ForEach(x => { x.nMontoCosto = 0; });
                else
                    item.listDetalleConfigComisiones.ForEach(x => { x.nPorcentajeCosto = 0; });
            }

            var listConfComisionesD = this.listConfComisiones.SelectMany(x => x.listDetalleConfigComisiones).ToList();

            string xmlConfComisionM = convierteConfCanalEnXML(this.listConfComisiones);
            string xmlConfComisionD = convierteConfComisionEnXML(listConfComisionesD);

            try
            {
                new clsCNComisionesCanalesElec().GuardaConfComisiones(xmlConfComisionM, xmlConfComisionD);
                MessageBox.Show("Guardado correctamente", "Mantenimiento Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la Base de Datos: " + ex, "Mantenimiento Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            habilitaTabsControl(false);
            habilitaBtnsCanal(false);
            habilitaBtnsComisiones(false);
            obtenerConfComisiones();
            cboCanalElecM_SelectedValueChanged(null, null);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;

            habilitaTabsControl(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            habilitaTabsControl(false);
            habilitaBtnsCanal(false);
            habilitaBtnsComisiones(false);
            obtenerConfComisiones();
            cboCanalElecM_SelectedValueChanged(null, null);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmRptComisionAuditoria objRptComisionAuditoria = new frmRptComisionAuditoria();
            objRptComisionAuditoria.ShowDialog();
        }

        //Eventos de DataGridView

        private void dtgMConfComision_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgMConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgMConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            var dataObject = selectedRow.DataBoundItem as clsConfigComisiones;

            int idCanalServicio = Convert.ToInt32(dataObject.idCanalServicio);
            this.cboTipoCanalServM.SelectedValue = idCanalServicio;

            int idAsumeComision = Convert.ToInt32(dataObject.idAsumeComision);
            this.cboTipoAsumeComi.SelectedValue = idAsumeComision;

            int idTipoRango = Convert.ToInt32(dataObject.idTipoRango);
            this.cboTipoRango.SelectedValue = idTipoRango;

            int idTipoModalidadPago = Convert.ToInt32(dataObject.idTipoModalidadPago);
            this.cboTipoModalidadPago.SelectedValue = idTipoModalidadPago;

            string cNumeroCuenta = dataObject.cNumeroCuenta;
            this.txtNumeroCuenta.Text = cNumeroCuenta;

            DateTime dFechaInicioVigencia = dataObject.dFechaInicioVigencia;
            this.dtpIniVigencia.Value = dFechaInicioVigencia;

            DateTime dFechaFinVigencia = dataObject.dFechaFinVigencia;
            this.dtpFinVigencia.Value = dFechaFinVigencia;

            bool lActivo = dataObject.lActivo;
            this.chcVigente.Checked = lActivo;
        }

        private void dtgDConfComision_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgDConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgDConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            var dataObject = selectedRow.DataBoundItem as clsDetalleConfigComisiones;
            string cTipoRango = this.listConfComisiones.Find(x => x.idCanal == Convert.ToInt32(this.cboCanalElecD.SelectedValue)).cTipoRango;
            string cTipoModalidadPago = this.listConfComisiones.Find(x => x.idCanal == Convert.ToInt32(this.cboCanalElecD.SelectedValue)).cTipoModalidadPago;

            this.txtMin.Text = (cTipoRango == eTipoRango.Cantidad) ? dataObject.nCantidadMin.ToString() : dataObject.nMontoCuotaMin.ToString();
            this.txtMax.Text = (cTipoRango == eTipoRango.Cantidad) ? dataObject.nCantidadMax.ToString() : dataObject.nMontoCuotaMax.ToString();
            this.txtCosto.Text = (cTipoModalidadPago == eTipoModalidadPago.Fijo) ? dataObject.nMontoCosto.ToString() : dataObject.nPorcentajeCosto.ToString();

            this.cboMoneda.SelectedValue = dataObject.idMoneda;
        }

        private void dtgMConfComision_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                habilitaBtnsCanal(true);
                btnAgregarCanal.Enabled = false;
                habilitaControlesCanal(true);
                this.btnEditarCanal.Focus();
            }
        }

        private void dtgDConfComision_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                habilitaBtnsComisiones(true);
                btnAgregarComs.Enabled = false;
                habilitaControlesComision(true);

                if (this.dtgDConfComision.SelectedRows.Count <= 0)
                    return;

                DataGridViewRow selectedRow = this.dtgDConfComision.SelectedRows[0];

                if (selectedRow.DataBoundItem == null)
                    return;

                var dataObject = selectedRow.DataBoundItem as clsDetalleConfigComisiones;
                this.chcAplicaTodos.Checked = (dataObject.idZona == 0) ? true : false;
                this.chcAplicaTodos.Enabled = false;

                this.btnEditarComs.Focus();
            }
        }

        //Eventos de botones de Canales

        private void btnNuevoCanal_Click(object sender, EventArgs e)
        {
            habilitaBtnsCanal(true);
            btnEditarCanal.Enabled = false;
            habilitaControlesCanal(true);
            limpiarFormularioCanal();
            this.btnAgregarCanal.Focus();
        }

        private void btnAgregarCanal_Click(object sender, EventArgs e)
        {
            if (!validaCamposCanal())
                return;

            int idMConfComision = 0;

            if (this.listConfComisiones.FindAll(x => x.idMConfComision == 0).Count > 0)
            {
                idMConfComision = this.listConfComisiones.OrderBy(x => x.idMConfComision).FirstOrDefault().idMConfComision;
                idMConfComision = idMConfComision - 1;
            }

            var objConf = new clsConfigComisiones()
            {
                idMConfComision = idMConfComision,
                idCanal = Convert.ToInt32(this.cboCanalElecM.SelectedValue),
                cCanal = this.cboCanalElecM.Text,
                cNumeroCuenta = this.txtNumeroCuenta.Text,
                idCanalServicio = Convert.ToInt32(this.cboTipoCanalServM.SelectedValue),
                cCanalServicio = this.cboTipoCanalServM.Text,
                idAsumeComision = Convert.ToInt32(this.cboTipoAsumeComi.SelectedValue),
                cAsumeComision = this.cboTipoAsumeComi.Text,
                idTipoRango = Convert.ToInt32(this.cboTipoRango.SelectedValue),
                cTipoRango = this.cboTipoRango.Text,
                idTipoModalidadPago = Convert.ToInt32(this.cboTipoModalidadPago.SelectedValue),
                cTipoModalidadPago = this.cboTipoModalidadPago.Text,
                dFechaInicioVigencia = this.dtpIniVigencia.Value,
                dFechaFinVigencia = this.dtpFinVigencia.Value,
                lActivo = this.chcVigente.Checked,
                listDetalleConfigComisiones = new List<clsDetalleConfigComisiones>()
            };

            bool lCorrecto = validaCanales(objConf, true);

            if (!lCorrecto)
                return;

            this.listConfComisiones.Add(objConf);

            habilitaBtnsCanal(false);
            habilitaControlesCanal(false);

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            this.bsConfComisionesM.DataSource = this.listConfComisiones.FindAll(x => x.idCanal == idCanal);
            this.bsConfComisionesM.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnQuitarCanal_Click(object sender, EventArgs e)
        {
            if (this.dtgMConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgMConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            DialogResult result = MessageBox.Show("¿Esta seguro de eliminar este registro?", "Mantenimiento de Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                return;

            var dataObject = selectedRow.DataBoundItem as clsConfigComisiones;

            this.listConfComisiones.Remove(dataObject);

            int idZona = Convert.ToInt32(this.cboZonas.SelectedValue);

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            this.bsConfComisionesM.DataSource = this.listConfComisiones.Find(x => x.idCanal == idCanal);
            this.bsConfComisionesM.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnEditarCanal_Click(object sender, EventArgs e)
        {
            if (this.dtgMConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgMConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            var dataObject = selectedRow.DataBoundItem as clsConfigComisiones;

            var objConfTemp = new clsConfigComisiones()
            {
                idMConfComision = dataObject.idMConfComision,
                idCanal = Convert.ToInt32(this.cboCanalElecM.SelectedValue),
                cCanal = this.cboCanalElecM.Text,
                cNumeroCuenta = this.txtNumeroCuenta.Text,
                idCanalServicio = Convert.ToInt32(this.cboTipoCanalServM.SelectedValue),
                cCanalServicio = this.cboTipoCanalServM.Text,
                idAsumeComision = Convert.ToInt32(this.cboTipoAsumeComi.SelectedValue),
                cAsumeComision = this.cboTipoAsumeComi.Text,
                idTipoRango = Convert.ToInt32(this.cboTipoRango.SelectedValue),
                cTipoRango = this.cboTipoRango.Text,
                idTipoModalidadPago = Convert.ToInt32(this.cboTipoModalidadPago.SelectedValue),
                cTipoModalidadPago = this.cboTipoModalidadPago.Text,
                dFechaInicioVigencia = this.dtpIniVigencia.Value,
                dFechaFinVigencia = this.dtpFinVigencia.Value,
                lActivo = this.chcVigente.Checked,
                listDetalleConfigComisiones = new List<clsDetalleConfigComisiones>()
            };

            bool lCorrecto = validaCanales(objConfTemp, false);

            if (!lCorrecto)
                return;

            var objConfCanal = this.listConfComisiones.Find(x => x.idMConfComision == dataObject.idMConfComision);

            objConfCanal.idCanalServicio = objConfTemp.idCanalServicio;
            objConfCanal.cCanalServicio = objConfTemp.cCanalServicio;
            objConfCanal.idAsumeComision = objConfTemp.idAsumeComision;
            objConfCanal.cAsumeComision = objConfTemp.cAsumeComision;
            objConfCanal.idTipoRango = objConfTemp.idTipoRango;
            objConfCanal.cTipoRango = objConfTemp.cTipoRango;
            objConfCanal.idTipoModalidadPago = objConfTemp.idTipoModalidadPago;
            objConfCanal.cTipoModalidadPago = objConfTemp.cTipoModalidadPago;
            objConfCanal.cNumeroCuenta = objConfTemp.cNumeroCuenta;
            objConfCanal.dFechaInicioVigencia = objConfTemp.dFechaInicioVigencia;
            objConfCanal.dFechaFinVigencia = objConfTemp.dFechaFinVigencia;
            objConfCanal.lActivo = objConfTemp.lActivo;

            habilitaBtnsCanal(false);
            habilitaControlesCanal(false);

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            this.bsConfComisionesM.DataSource = this.listConfComisiones.FindAll(x => x.idCanal == idCanal);
            this.bsConfComisionesM.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnCancelCanal_Click(object sender, EventArgs e)
        {
            dtgMConfComision_SelectionChanged(null, null);
            habilitaBtnsCanal(false);
            habilitaControlesCanal(false);
        }

        //Eventos de botones de Comisiones

        private void btnNuevoComs_Click(object sender, EventArgs e)
        {
            habilitaBtnsComisiones(true);
            btnEditarComs.Enabled = false;
            habilitaControlesComision(true);
            limpiarFormularioComision();

            this.chcAplicaTodos.Checked = (Convert.ToInt32(this.cboZonas.SelectedValue) == 0) ? true : false;
            this.chcAplicaTodos.Enabled = false;

            this.btnAgregarComs.Focus();
        }

        private void btnAgregarComs_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboMoneda.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar una moneda", "Mantenimiento de Comisiones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            int idTipoCanalServ = Convert.ToInt32(this.cboTipoCanalServD.SelectedValue);
            int idAsumeComision = Convert.ToInt32(this.cboAsumeComMixto.SelectedValue);

            var confComisionM = this.listConfComisiones.Find(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ && x.idAsumeComision == idAsumeComision && x.lActivo);

            if (this.chcAplicaTodos.Checked && confComisionM.listDetalleConfigComisiones.FindAll(x => x.idZona != 0).Count > 0)
            {
                DialogResult result = MessageBox.Show("Esta configurando una comision para Todas las Zonas, Se eliminaran los registros establecidos por zonas ¿Desea Continuar?",
                                               "Mantenimiento de Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result != DialogResult.Yes) return;
            }

            int idDConfComision = 0;

            if (confComisionM.listDetalleConfigComisiones.FindAll(x => x.idDConfComision == 0).Count > 0)
            {
                idDConfComision = confComisionM.listDetalleConfigComisiones.OrderBy(x => x.idDConfComision).FirstOrDefault().idDConfComision;
                idDConfComision = idDConfComision - 1;
            }

            var objConf = new clsDetalleConfigComisiones()
            {
                idDConfComision = idDConfComision,
                idMConfComision = confComisionM.idMConfComision,
                idZona = Convert.ToInt32(this.cboZonas.SelectedValue),
                cZona = this.cboZonas.Text,
                idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue),
                cMoneda = this.cboMoneda.Text,
                nMontoCuotaMin = confComisionM.cTipoRango == eTipoRango.Monto ? Convert.ToDecimal(this.txtMin.Text) : decimal.Zero,
                nMontoCuotaMax = confComisionM.cTipoRango == eTipoRango.Monto ? Convert.ToDecimal(this.txtMax.Text) : decimal.Zero,
                nCantidadMin = confComisionM.cTipoRango == eTipoRango.Cantidad ? Convert.ToInt32(this.txtMin.Text) : 0,
                nCantidadMax = confComisionM.cTipoRango == eTipoRango.Cantidad ? Convert.ToInt32(this.txtMax.Text) : 0,
                nMontoCosto = confComisionM.cTipoModalidadPago == eTipoModalidadPago.Fijo ? Convert.ToDecimal(this.txtCosto.Text) : decimal.Zero,
                nPorcentajeCosto = confComisionM.cTipoModalidadPago == eTipoModalidadPago.Porcentual ? Convert.ToDecimal(this.txtCosto.Text) : decimal.Zero
            };

            bool lCorrecto = validarComisiones(confComisionM.listDetalleConfigComisiones, objConf);

            if (!lCorrecto)
                return;

            if (this.chcAplicaTodos.Checked)
                confComisionM.listDetalleConfigComisiones.RemoveAll(x => x.idZona != 0);

            confComisionM.listDetalleConfigComisiones.Add(objConf);

            habilitaBtnsComisiones(false);
            habilitaControlesComision(false);

            int idZona = Convert.ToInt32(this.cboZonas.SelectedValue);

            this.bsConfComisionesD.DataSource = confComisionM.listDetalleConfigComisiones.FindAll(x => x.idZona == idZona || idZona == 0);
            this.bsConfComisionesD.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnQuitarComs_Click(object sender, EventArgs e)
        {
            if (this.dtgDConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgDConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            DialogResult result = MessageBox.Show("¿Esta seguro de eliminar este registro?", "Mantenimiento Comisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                return;

            var dataObject = selectedRow.DataBoundItem as clsDetalleConfigComisiones;

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            int idTipoCanalServ = Convert.ToInt32(this.cboTipoCanalServD.SelectedValue);
            int idAsumeComision = Convert.ToInt32(this.cboAsumeComMixto.SelectedValue);
            var confComisionM = this.listConfComisiones.Find(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ && x.idAsumeComision == idAsumeComision);
            confComisionM.listDetalleConfigComisiones.Remove(dataObject);

            int idZona = Convert.ToInt32(this.cboZonas.SelectedValue);

            this.bsConfComisionesD.DataSource = confComisionM.listDetalleConfigComisiones.FindAll(x => x.idZona == idZona || idZona == 0);
            this.bsConfComisionesD.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnEditarComs_Click(object sender, EventArgs e)
        {
            if (this.dtgDConfComision.SelectedRows.Count <= 0)
                return;

            DataGridViewRow selectedRow = this.dtgDConfComision.SelectedRows[0];

            if (selectedRow.DataBoundItem == null)
                return;

            var dataObject = selectedRow.DataBoundItem as clsDetalleConfigComisiones;

            int idCanal = Convert.ToInt32(this.cboCanalElecD.SelectedValue);
            int idTipoCanalServ = Convert.ToInt32(this.cboTipoCanalServD.SelectedValue);
            int idAsumeComision = Convert.ToInt32(this.cboAsumeComMixto.SelectedValue);
            var confComisionM = this.listConfComisiones.Find(x => x.idCanal == idCanal && x.idCanalServicio == idTipoCanalServ && x.idAsumeComision == idAsumeComision && x.lActivo);

            var confComision = confComisionM.listDetalleConfigComisiones.Find(x => x.idDConfComision == dataObject.idDConfComision);

            var objConfTemp = new clsDetalleConfigComisiones()
            {
                idDConfComision = confComision.idDConfComision,
                idMConfComision = confComisionM.idMConfComision,
                idZona = Convert.ToInt32(this.cboZonas.SelectedValue),
                cZona = this.cboZonas.Text,
                idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue),
                cMoneda = this.cboMoneda.Text,
                nMontoCuotaMin = confComisionM.cTipoRango == eTipoRango.Monto ? Convert.ToDecimal(this.txtMin.Text) : decimal.Zero,
                nMontoCuotaMax = confComisionM.cTipoRango == eTipoRango.Monto ? Convert.ToDecimal(this.txtMax.Text) : decimal.Zero,
                nCantidadMin = confComisionM.cTipoRango == eTipoRango.Cantidad ? Convert.ToInt32(this.txtMin.Text) : 0,
                nCantidadMax = confComisionM.cTipoRango == eTipoRango.Cantidad ? Convert.ToInt32(this.txtMax.Text) : 0,
                nMontoCosto = confComisionM.cTipoModalidadPago == eTipoModalidadPago.Fijo ? Convert.ToDecimal(this.txtCosto.Text) : decimal.Zero,
                nPorcentajeCosto = confComisionM.cTipoModalidadPago == eTipoModalidadPago.Porcentual ? Convert.ToDecimal(this.txtCosto.Text) : decimal.Zero
            };

            bool lCorrecto = validarComisiones(confComisionM.listDetalleConfigComisiones.Where(item => item.idDConfComision != confComision.idDConfComision).ToList(), objConfTemp);

            if (!lCorrecto)
                return;

            confComision.nMontoCuotaMin = objConfTemp.nMontoCuotaMin;
            confComision.nMontoCuotaMax = objConfTemp.nMontoCuotaMax;
            confComision.nCantidadMin = objConfTemp.nCantidadMin;
            confComision.nCantidadMax = objConfTemp.nCantidadMax;
            confComision.nMontoCosto = objConfTemp.nMontoCosto;
            confComision.nPorcentajeCosto = objConfTemp.nPorcentajeCosto;

            habilitaBtnsComisiones(false);
            habilitaControlesComision(false);

            int idZona = Convert.ToInt32(this.cboZonas.SelectedValue);

            this.bsConfComisionesD.DataSource = confComisionM.listDetalleConfigComisiones.FindAll(x => x.idZona == idZona || idZona == 0);
            this.bsConfComisionesD.ResetBindings(true);
            this.btnGrabar.Focus();
        }

        private void btnCancelComs_Click(object sender, EventArgs e)
        {
            dtgDConfComision_SelectionChanged(null, null);
            habilitaBtnsComisiones(false);
            habilitaControlesComision(false);
        }

        //Eventos de TextBox

        private void txtMin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.txtMin.Text = Math.Round(Convert.ToDecimal(this.txtMin.Text), 2).ToString("0.00");

            if (this.lblMin.Text == "Cantidad Minima:")
                this.txtMin.Text = Math.Round(Convert.ToDecimal(this.txtMin.Text), 0).ToString();        
        }

        private void txtMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.txtMax.Text = Math.Round(Convert.ToDecimal(this.txtMax.Text), 2).ToString("0.00");

            if (this.lblMax.Text == "Cantidad Maxima:")
                this.txtMax.Text = Math.Round(Convert.ToDecimal(this.txtMax.Text), 0).ToString();
        }

        private void txtCosto_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.txtCosto.Text = Math.Round(Convert.ToDecimal(this.txtCosto.Text), 2).ToString("0.00");
        }

        //Otros eventos

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCanalElecD_SelectedValueChanged(null,null);
        }

        private void dtgMConfComision_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.dtgMConfComision.Rows.Count <= 0)
                return;

            int idCanal = Convert.ToInt32(this.cboCanalElecM.SelectedValue);
            bool lAplicaComMixta = this.listConfComisiones.Where(x => x.idCanal == idCanal).GroupBy(x => x.idCanalServicio)
                                                            .Any(group => group.Select(y => y.idCanalServicio).Count() > 1);

            if (!lAplicaComMixta)
                return;

            List<string> listComMix = this.listConfComisiones.Where(x => x.idCanal == idCanal && x.lActivo).GroupBy(x => x.cCanalServicio)
                                                                .Where(group => group.Count() >= 2).Select(group => group.Key.ToString()).ToList();

            foreach (DataGridViewRow row in this.dtgMConfComision.Rows)
            {
                string cCanalServicioValue = row.Cells["cCanalServicio"].Value.ToString();
                int idAsumeValue = Convert.ToInt32(row.Cells["idAsumeComision"].Value);
                bool lActivoValue = Convert.ToBoolean(row.Cells["lActivo"].Value);

                if (listComMix.Contains(cCanalServicioValue) && lActivoValue)
                {
                    if (listConfComisiones.Any(x => x.cCanalServicio == cCanalServicioValue && x.idAsumeComision != idAsumeValue))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        #endregion
    }
}