using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmDetalleActividadAgricola : frmBase
    {
        #region atributos
        
        private clsCNEvalCred objCNEvalCred = new clsCNEvalCred();
        private clsCNEvalAgrico objCNEvalAgrico = new clsCNEvalAgrico();
        private List<clsEvaluacionCultivoAgrico> lstEvaluacionCultivosAgrico;
        private List<clsMovimientoEval> lstMovimientosEval;
        private clsEvaluacionCultivoAgrico objEvalCultivoAgrico;
        private BindingSource bindingEvaluacionCultivos = new BindingSource();
        private int idEvalCred;
        private int idZona;
        private int idMoneda;
        private clsEvalCred objEvalCred;
        private bool lMatrizAgricola;

        #endregion

        public frmDetalleActividadAgricola(clsEvalCred objEvalCred, bool lMatrizAgricola = false)
        {
            InitializeComponent();

            this.objEvalCred = objEvalCred;
            this.formatearDataGridView();
            this.idEvalCred = objEvalCred.idEvalCred;
            this.idZona = Int32.Parse(this.objCNEvalCred.obtenerZonaAgencia(clsVarGlobal.nIdAgencia).Rows[0]["idZona"].ToString());
            this.idMoneda = 1;
            this.lMatrizAgricola = lMatrizAgricola;
        }

        #region Metodos Privados

        private void obtenerMatrizAgricola(clsEvaluacionCultivoAgrico objEvaluacionCultivoAgrico)
        {
            if (objEvaluacionCultivoAgrico.idMatrizAgricola == null)
                return;

            if (objEvaluacionCultivoAgrico.idMatrizAgricola > 0)
            {
                objEvaluacionCultivoAgrico.objMatrizAgricola = new clsMatrizAgricola();
                objEvaluacionCultivoAgrico.objMatrizAgricola.idMatrizAgricola = objEvaluacionCultivoAgrico.idMatrizAgricola ?? 0;
                objEvaluacionCultivoAgrico.objMatrizAgricola.idUnidadProductiva = objEvaluacionCultivoAgrico.idUnidadProductiva;

                DataTable dt = this.objCNEvalAgrico.dtObtenerMatrizAgricola(objEvaluacionCultivoAgrico.objMatrizAgricola);

                if (dt.Rows.Count > 0)
                {
                    objEvaluacionCultivoAgrico.objMatrizAgricola.nRendimiento = dt.Rows[0].Field<decimal>("nRendimiento");
                    objEvaluacionCultivoAgrico.objMatrizAgricola.nPrecioUnidadMN = dt.Rows[0].Field<decimal>("nPrecioUnidadMN");
                    objEvaluacionCultivoAgrico.objMatrizAgricola.nCostoProduccionMN = dt.Rows[0].Field<decimal>("nCostoProduccionMN");
                    objEvaluacionCultivoAgrico.objMatrizAgricola.nEquivHas = dt.Rows[0].Field<decimal>("nEquivHas");
                    objEvaluacionCultivoAgrico.objMatrizAgricola.idRegistroMatriz = dt.Rows[0].Field<int>("idRegistroMatriz");
                }
            }
        }

        private void cargarEvaluacionCultivos()
        {
            this.lstEvaluacionCultivosAgrico = objCNEvalAgrico.obtenerEvaluacionCultivos(this.idEvalCred);
            this.mapearParametrosMatriz(this.lstEvaluacionCultivosAgrico);
            this.dtgEvaluacionCultivos.DataSource = this.lstEvaluacionCultivosAgrico;
            this.nuevaActividadAgricola();
        }

        private void mapearParametrosMatriz(List<clsEvaluacionCultivoAgrico> lstCultivos)
        {
            foreach (clsEvaluacionCultivoAgrico obj in lstCultivos)
            {
                this.obtenerMatrizAgricola(obj);
            }
        }

        private void validarParametrosMatriz(DataGridView dtgCultivos)
        {
            List<clsEvaluacionCultivoAgrico> lstCultivos = (List<clsEvaluacionCultivoAgrico>)dtgCultivos.DataSource;
            clsEvaluacionCultivoAgrico objCultivo;
            foreach (DataGridViewRow row in dtgCultivos.Rows)
            {
                objCultivo = lstCultivos[row.Index];

                if (objCultivo.nMontoIngresosMatriz > 0 && objCultivo.nMontoIngresos > objCultivo.nMontoIngresosMatriz)
                {
                    row.Cells["nMontoIngresos"].Style.BackColor = Color.Orange;
                }
                else
                {
                    row.Cells["nMontoIngresos"].Style.BackColor = Color.White;
                }

                if (objCultivo.nMontoEgresosMatriz > 0 && objCultivo.nMontoEgresos < objCultivo.nMontoEgresosMatriz)
                {
                    row.Cells["nMontoEgresos"].Style.BackColor = Color.Orange;
                }
                else
                {
                    row.Cells["nMontoEgresos"].Style.BackColor = Color.White;
                }
            }
        }

        private void formatearDataGridView()
        {
            this.dtgEvaluacionCultivos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvaluacionCultivos.MultiSelect = false;
            this.dtgEvaluacionCultivos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;            
            this.dtgEvaluacionCultivos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;            
            this.dtgEvaluacionCultivos.RowHeadersVisible = false;
            this.dtgEvaluacionCultivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;            
            this.dtgEvaluacionCultivos.ReadOnly = true;

            DataGridViewButtonColumn dgvbtnIngresos = new DataGridViewButtonColumn();
            dgvbtnIngresos.Name = "btnIngresos";
            dgvbtnIngresos.Text = "...";
            dgvbtnIngresos.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dgvbtnIngresos.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn dgvbtnEgresos = new DataGridViewButtonColumn();
            dgvbtnEgresos.Name = "btnEgresos";
            dgvbtnEgresos.Text = "...";
            dgvbtnEgresos.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dgvbtnEgresos.UseColumnTextForButtonValue = true;

            this.dtgEvaluacionCultivos.Columns.Add(dgvbtnIngresos);
            this.dtgEvaluacionCultivos.Columns.Add(dgvbtnEgresos);
        }

        private void formatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgEvaluacionCultivos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgEvaluacionCultivos.Columns["cCultivoEval"].DisplayIndex = 0;
            this.dtgEvaluacionCultivos.Columns["cVariedadCultivoEval"].DisplayIndex = 1;
            this.dtgEvaluacionCultivos.Columns["cUnidadProductiva"].DisplayIndex = 2;
            this.dtgEvaluacionCultivos.Columns["cUnidadMedida"].DisplayIndex = 3;
            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].DisplayIndex = 4;
            this.dtgEvaluacionCultivos.Columns["btnIngresos"].DisplayIndex = 5;
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].DisplayIndex = 6;
            this.dtgEvaluacionCultivos.Columns["btnEgresos"].DisplayIndex = 7;

            this.dtgEvaluacionCultivos.Columns["cCultivoEval"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["cVariedadCultivoEval"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["cUnidadProductiva"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["cUnidadMedida"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["btnIngresos"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].Visible = true;
            this.dtgEvaluacionCultivos.Columns["btnEgresos"].Visible = true;

            this.dtgEvaluacionCultivos.Columns["cCultivoEval"].HeaderText = "Cultivo";
            this.dtgEvaluacionCultivos.Columns["cVariedadCultivoEval"].HeaderText = "Variedad";
            this.dtgEvaluacionCultivos.Columns["cUnidadProductiva"].HeaderText = "Unid. Productiva";
            this.dtgEvaluacionCultivos.Columns["cUnidadMedida"].HeaderText = "Unid. Medida";
            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].HeaderText = "Ingreso";
            this.dtgEvaluacionCultivos.Columns["btnIngresos"].HeaderText = "";
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].HeaderText = "Egreso";
            this.dtgEvaluacionCultivos.Columns["btnEgresos"].HeaderText = "";

            this.dtgEvaluacionCultivos.Columns["cCultivoEval"].FillWeight = 45;
            this.dtgEvaluacionCultivos.Columns["cVariedadCultivoEval"].FillWeight = 45;
            this.dtgEvaluacionCultivos.Columns["cUnidadProductiva"].FillWeight = 30;
            this.dtgEvaluacionCultivos.Columns["cUnidadMedida"].FillWeight = 30;
            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].FillWeight = 20;
            this.dtgEvaluacionCultivos.Columns["btnIngresos"].FillWeight = 10;
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].FillWeight = 20;
            this.dtgEvaluacionCultivos.Columns["btnEgresos"].FillWeight = 10;

            this.dtgEvaluacionCultivos.Columns["cCultivoEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dtgEvaluacionCultivos.Columns["cVariedadCultivoEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dtgEvaluacionCultivos.Columns["cUnidadProductiva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvaluacionCultivos.Columns["cUnidadMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgEvaluacionCultivos.Columns["btnIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgEvaluacionCultivos.Columns["btnEgresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dtgEvaluacionCultivos.Columns["nMontoIngresos"].DefaultCellStyle.Format = "n2";
            this.dtgEvaluacionCultivos.Columns["nMontoEgresos"].DefaultCellStyle.Format = "n2";
        }

        private void nuevaActividadAgricola()
        {
            this.dtgEvaluacionCultivos.ClearSelection();
            this.objEvalCultivoAgrico = new clsEvaluacionCultivoAgrico();
            this.objEvalCultivoAgrico.idEvalCred = this.idEvalCred;
            this.objEvalCultivoAgrico.idZona = this.idZona;
            this.objEvalCultivoAgrico.lVigente = true;
            this.objEvalCultivoAgrico.lstMovimientosEval = new List<clsMovimientoEval>();

            if (this.lMatrizAgricola)
                this.objEvalCultivoAgrico.idMatrizAgricola = 0;
            else
                this.objEvalCultivoAgrico.idMatrizAgricola = null;

            asignarFormulario();
            habilitarFormulario(true);

            this.btnMiniNuevo.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniQuitar.Enabled = false;
            this.btnMiniAceptar.Enabled = true;
            this.btnMiniCancelar.Enabled = true;
            //this.btnAceptar.Enabled = false;
        }

        private void actualizarActividadAgricola()
        {            
            this.habilitarFormulario(true);
            this.cboCultivo.Enabled = false;
            this.cboVariedadCultivo.Enabled = false;
            this.cboUnidadMedida.Enabled = false;
            this.cboTipoFinanciamientoCultivo1.Enabled = false;
            this.cboTipoCultivo1.Enabled = false;

            this.btnMiniNuevo.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniQuitar.Enabled = false;
            this.btnMiniAceptar.Enabled = true;
            this.btnMiniCancelar.Enabled = true;
            //this.btnAceptar.Enabled = false;
        }

        private void registrarActividadAgricola()
        {
            if (!this.formularioValido())
                return;

            this.leerFormulario();

            if (this.objEvalCultivoAgrico.idRegistroMatriz >= 0)
            {
                clsMatrizAgricola objMatrizAgricola = new clsMatrizAgricola();
                objMatrizAgricola.idMatrizAgricola = this.objEvalCultivoAgrico.idMatrizAgricola ?? 0;
                objMatrizAgricola.idAgencia = clsVarGlobal.nIdAgencia;
                objMatrizAgricola.idCultivoEval = this.objEvalCultivoAgrico.idCultivoEval;
                objMatrizAgricola.idVariedadCultivoEval = this.objEvalCultivoAgrico.idVariedadCultivoEval;
                objMatrizAgricola.idTipoCultivo = this.objEvalCultivoAgrico.idTipoCultivo;
                objMatrizAgricola.idTipoFinanciamientoCultivo = this.objEvalCultivoAgrico.idTipoFinanciamientoCultivo;
                objMatrizAgricola.idUnidadMedida = this.objEvalCultivoAgrico.idUnidadMedida;
                objMatrizAgricola.idUnidadProductiva = this.objEvalCultivoAgrico.idUnidadProductiva;

                DataTable dtMatrizAgricola = this.objCNEvalAgrico.dtObtenerMatrizAgricola(objMatrizAgricola);

                if (dtMatrizAgricola.Rows.Count > 0)
                    this.objEvalCultivoAgrico.idMatrizAgricola = dtMatrizAgricola.Rows[0].Field<int>("idMatrizAgricola");
                else
                    this.objEvalCultivoAgrico.idMatrizAgricola = 0;
            }

            if (this.objEvalCultivoAgrico.idEvaluacionCultivo > 0)
            {
                DataTable dt = objCNEvalAgrico.registrarEvaluacionCultivo("update", this.objEvalCultivoAgrico);
            }                
            else
            {
                DataTable dt = objCNEvalAgrico.registrarEvaluacionCultivo("insert", this.objEvalCultivoAgrico);
            }
            this.cargarEvaluacionCultivos();

            this.btnMiniNuevo.Enabled = false;
            this.btnMiniEditar.Enabled = false;
            this.btnMiniQuitar.Enabled = false;
            this.btnMiniAceptar.Enabled = false;
            this.btnMiniCancelar.Enabled = false;
            //this.btnAceptar.Enabled = true;
        }

        private void eliminarActividadAgricola(object sender, EventArgs e)
        {            
            this.objCNEvalAgrico.registrarEvaluacionCultivo("delete", this.objEvalCultivoAgrico);
            this.cargarEvaluacionCultivos();
        }

        private void reiniciarFormulario()
        {
            habilitarFormulario(false);            

            this.btnMiniNuevo.Enabled = true;
            this.btnMiniEditar.Enabled = true;
            this.btnMiniQuitar.Enabled = true;
            this.btnMiniAceptar.Enabled = false;
            this.btnMiniCancelar.Enabled = false;
            //this.btnAceptar.Enabled = true;
        }

        private void habilitarFormulario(bool habilitado)
        {
            this.cboRegion.Enabled = false;
            this.cboMoneda.Enabled = false;
            this.cboCultivo.Enabled = habilitado;
            this.cboVariedadCultivo.Enabled = habilitado;
            this.cboTipoCultivo1.Enabled = habilitado;
            this.cboTipoFinanciamientoCultivo1.Enabled = habilitado;
            this.cboTipoSiembra.Enabled = habilitado;
            this.cboUnidadProductiva.Enabled = habilitado;
            this.cboUnidadMedida.Enabled = habilitado;
            this.txtUPPropias.Enabled = habilitado;
            this.txtUPAlquiladas.Enabled = habilitado;

            this.txtUPAPropias.Enabled = habilitado;
            this.txtUPAAlquiladas.Enabled = habilitado;

            this.txtUPTotal.Enabled = false;
            this.txtUPPropiasFinanciadas.Enabled = habilitado;
            this.txtUPAlquiladasFinanciadas.Enabled = habilitado;
            this.txtUPTotalFinanciadas.Enabled = false;
            this.txtCampanha.Enabled = habilitado;
        }

        private void leerFormulario()
        {            
            this.objEvalCultivoAgrico.idCultivoEval = Int32.Parse(this.cboCultivo.SelectedValue.ToString());
            this.objEvalCultivoAgrico.idVariedadCultivoEval = Int32.Parse(this.cboVariedadCultivo.SelectedValue.ToString());
            this.objEvalCultivoAgrico.idTipoSiembra = Int32.Parse(this.cboTipoSiembra.SelectedValue.ToString());
            this.objEvalCultivoAgrico.idUnidadProductiva = Int32.Parse(this.cboUnidadProductiva.SelectedValue.ToString());
            this.objEvalCultivoAgrico.idUnidadMedida = Int32.Parse(this.cboUnidadMedida.SelectedValue.ToString());
            this.objEvalCultivoAgrico.nUniProdPropias = decimal.Parse(this.txtUPPropias.Text);
            this.objEvalCultivoAgrico.nUniProdAlquiladas = decimal.Parse(this.txtUPAlquiladas.Text);

            this.objEvalCultivoAgrico.nUniProdPropiasAct = decimal.Parse(this.txtUPAPropias.Text);
            this.objEvalCultivoAgrico.nUniProdAlquiladasAct = decimal.Parse(this.txtUPAAlquiladas.Text);

            this.objEvalCultivoAgrico.nUniProdPropiasFin = decimal.Parse(this.txtUPPropiasFinanciadas.Text);
            this.objEvalCultivoAgrico.nUniProdAlquiladasFin = decimal.Parse(this.txtUPAlquiladasFinanciadas.Text);

            this.objEvalCultivoAgrico.cCultivoEval = this.cboCultivo.Text;
            this.objEvalCultivoAgrico.cVariedadCultivoEval = this.cboVariedadCultivo.Text;
            this.objEvalCultivoAgrico.cUnidadProductiva = this.cboUnidadProductiva.Text;
            this.objEvalCultivoAgrico.cUnidadMedida = this.cboUnidadMedida.Text;

            this.objEvalCultivoAgrico.cCampanha = this.txtCampanha.Text;
            this.objEvalCultivoAgrico.idTipoCultivo = Int32.Parse(this.cboTipoCultivo1.SelectedValue.ToString());
            this.objEvalCultivoAgrico.idTipoFinanciamientoCultivo = Int32.Parse(this.cboTipoFinanciamientoCultivo1.SelectedValue.ToString());
        }

        private void asignarFormulario()
        {
            this.cboCultivo.cargar(this.objEvalCultivoAgrico.idRegistroMatriz, clsVarGlobal.nIdAgencia);

            this.cboRegion.SelectedValue = this.objEvalCultivoAgrico.idZona;
            this.cboMoneda.SelectedValue = this.idMoneda;
            this.cboCultivo.SelectedValue = this.objEvalCultivoAgrico.idCultivoEval;
            this.cboVariedadCultivo.SelectedValue = this.objEvalCultivoAgrico.idVariedadCultivoEval;
            this.cboTipoCultivo1.SelectedValue = this.objEvalCultivoAgrico.idTipoCultivo;
            this.cboTipoFinanciamientoCultivo1.SelectedValue = this.objEvalCultivoAgrico.idTipoFinanciamientoCultivo;
            this.cboTipoSiembra.SelectedValue = this.objEvalCultivoAgrico.idTipoSiembra;
            this.cboUnidadProductiva.SelectedValue = this.objEvalCultivoAgrico.idUnidadProductiva;
            this.cboUnidadMedida.SelectedValue = this.objEvalCultivoAgrico.idUnidadMedida;
            this.txtUPPropias.Text = this.objEvalCultivoAgrico.nUniProdPropias.ToString();
            this.txtUPAlquiladas.Text = this.objEvalCultivoAgrico.nUniProdAlquiladas.ToString();

            this.txtUPAPropias.Text = this.objEvalCultivoAgrico.nUniProdPropiasAct.ToString();
            this.txtUPAAlquiladas.Text = this.objEvalCultivoAgrico.nUniProdAlquiladasAct.ToString();            

            this.txtUPPropiasFinanciadas.Text = this.objEvalCultivoAgrico.nUniProdPropiasFin.ToString();
            this.txtUPAlquiladasFinanciadas.Text = this.objEvalCultivoAgrico.nUniProdAlquiladasFin.ToString();            

            this.cboCultivo.Text = this.objEvalCultivoAgrico.cCultivoEval;
            this.cboVariedadCultivo.Text = this.objEvalCultivoAgrico.cVariedadCultivoEval;
            this.cboUnidadProductiva.Text = this.objEvalCultivoAgrico.cUnidadProductiva;
            this.cboUnidadMedida.Text = this.objEvalCultivoAgrico.cUnidadMedida;

            this.txtCampanha.Text = this.objEvalCultivoAgrico.cCampanha;
            
            this.calcularUPTotal();
            this.calcularUPTotalFinanciadas();
        }

        private bool formularioValido()
        {
            if (this.cboCultivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cultivo", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.cboVariedadCultivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la variedad del cultivo", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.cboTipoSiembra.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de siembra", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.cboUnidadProductiva.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la cantidad de unidades productivas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.cboUnidadMedida.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la unidad de medida", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtCampanha.Text))
            {
                MessageBox.Show("Debe ingresar la descripcion de la campaña", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtUPPropias.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades productivas propias", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtUPAlquiladas.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades alquiladas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtUPAPropias.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades productivas propias activas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtUPAAlquiladas.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades alquiladas activas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtUPPropiasFinanciadas.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades productivas propias financiadas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtUPAlquiladasFinanciadas.Text))
            {
                MessageBox.Show("Seleccione la cantidad de unidades productivas alquiladas financiadas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (Convert.ToDecimal(this.txtUPAPropias.Text) > Convert.ToDecimal(this.txtUPPropias.Text))
            {
                MessageBox.Show("El Número de Unidades Propias Activas debe ser menor o igual que el Número de Unidades Propias", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToDecimal(this.txtUPPropiasFinanciadas.Text) > Convert.ToDecimal(this.txtUPAPropias.Text))
            {
                MessageBox.Show("El Número de Unidades Propias Financiadas debe ser menor o igual que el Número de Unidades Propias Activas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToDecimal(this.txtUPAAlquiladas.Text) > Convert.ToDecimal(this.txtUPAlquiladas.Text))
            {
                MessageBox.Show("El Número de Unidades Alquiladas Activas debe ser menor o igual que el Número de Unidades Alquiladas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToDecimal(this.txtUPAlquiladasFinanciadas.Text) > Convert.ToDecimal(this.txtUPAAlquiladas.Text))
            {
                MessageBox.Show("El Número de Unidades Alquiladas Financiadas debe ser menor o igual que el Número de Unidades Alquiladas Activas", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void calcularUPTotal()
        {
            decimal nUPPropias = !String.IsNullOrEmpty(this.txtUPPropias.Text) ? decimal.Parse(this.txtUPPropias.Text) : 0;
            decimal nUPAlquiladas = !String.IsNullOrEmpty(this.txtUPAlquiladas.Text) ? decimal.Parse(this.txtUPAlquiladas.Text) : 0;
            this.txtUPTotal.Text = (nUPPropias + nUPAlquiladas).ToString();
        }

        private void calcularUPTotalActivas()
        {
            decimal nUPPropiasAct = !String.IsNullOrEmpty(this.txtUPAPropias.Text) ? decimal.Parse(this.txtUPAPropias.Text) : 0;
            decimal nUPAlquiladasAct = !String.IsNullOrEmpty(this.txtUPAAlquiladas.Text) ? decimal.Parse(this.txtUPAAlquiladas.Text) : 0;
            this.txtUPATotal.Text = (nUPPropiasAct + nUPAlquiladasAct).ToString();            
        }
        
        private void calcularUPTotalFinanciadas()
        {
            decimal nUPPropiasFinanciadas = !String.IsNullOrEmpty(this.txtUPPropiasFinanciadas.Text) ? decimal.Parse(this.txtUPPropiasFinanciadas.Text) : 0;
            decimal nUPAlquiladasFinanciadas = !String.IsNullOrEmpty(this.txtUPAlquiladasFinanciadas.Text) ? decimal.Parse(this.txtUPAlquiladasFinanciadas.Text) : 0;
            this.txtUPTotalFinanciadas.Text = (nUPPropiasFinanciadas + nUPAlquiladasFinanciadas).ToString();            
        }
        #endregion

        #region Métodos Públicos
        public List<clsEvaluacionCultivoAgrico> getEvaluacionCultivosAgrico()
        {
            return this.lstEvaluacionCultivosAgrico;
        }

        public List<clsMovimientoEval> getMovimientosEval()
        {
            List<clsMovimientoEval> lstRes = new List<clsMovimientoEval>();
            foreach (clsEvaluacionCultivoAgrico obj in this.lstEvaluacionCultivosAgrico)
            {
                lstRes.AddRange(obj.lstMovimientosEval);
            }
            return lstRes;
        }
        #endregion

        #region Eventos
        private void frmDetalleActividadAgricola_Load(object sender, EventArgs e)
        {
            this.cargarEvaluacionCultivos();
        }

        private void dtgEvaluacionCultivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == this.dtgEvaluacionCultivos.Columns["btnIngresos"].Index)
            {
                this.btnIngresos_Click(sender, e);
            }
            else if (e.ColumnIndex == this.dtgEvaluacionCultivos.Columns["btnEgresos"].Index)
            {
                this.btnEgresos_Click(sender, e);
            }
        }

        private void btnIngresos_Click(object sender, DataGridViewCellEventArgs e)
        {
            frmIngresosAgricola frmIngresosAgricola = new frmIngresosAgricola(lstEvaluacionCultivosAgrico[e.RowIndex], this.objEvalCred);
            frmIngresosAgricola.ShowDialog();

            this.lstEvaluacionCultivosAgrico[e.RowIndex].nMontoIngresos = frmIngresosAgricola.obtenerIngresos().Where(x => x.idTipoMovEvalCultivo == 1).Sum(x => x.nMontoTotal);
            this.lstEvaluacionCultivosAgrico[e.RowIndex].nMontoEgresos = frmIngresosAgricola.obtenerIngresos().Where(x => x.idTipoMovEvalCultivo == 2).Sum(x => x.nMontoTotal);
            this.objCNEvalAgrico.registrarEvaluacionCultivo("update", this.lstEvaluacionCultivosAgrico[e.RowIndex]);
            this.cargarEvaluacionCultivos();
        }

        private void btnEgresos_Click(object sender, DataGridViewCellEventArgs e)
        {            
            frmEgresosAgricola frmEgresosAgricola = new frmEgresosAgricola(lstEvaluacionCultivosAgrico[e.RowIndex], this.objEvalCred);
            frmEgresosAgricola.ShowDialog();
            this.lstEvaluacionCultivosAgrico[e.RowIndex].nMontoEgresos = frmEgresosAgricola.obtenerEgresos().Where(x => x.idTipoMovEvalCultivo == 2).Sum(x => x.nMontoTotal);
            this.objCNEvalAgrico.registrarEvaluacionCultivo("update", this.lstEvaluacionCultivosAgrico[e.RowIndex]);
            this.cargarEvaluacionCultivos();
        }

        private void btnMiniCancelar_Click(object sender, EventArgs e)
        {
            this.reiniciarFormulario();
        }

        private void btnMiniAceptar_Click(object sender, EventArgs e)
        {
            this.registrarActividadAgricola();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCultivo.SelectedIndex >= 0)
            {
                this.cboVariedadCultivo.cargar(
                    this.objEvalCultivoAgrico.idRegistroMatriz,
                    clsVarGlobal.nIdAgencia,
                    Int32.Parse(this.cboCultivo.SelectedValue.ToString())
                );
            }
        }

        private void dtgEvaluacionCultivos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.objEvalCultivoAgrico = this.lstEvaluacionCultivosAgrico[e.RowIndex];
            this.asignarFormulario();
            this.reiniciarFormulario();

            this.btnMiniNuevo.Enabled = true;
            this.btnMiniEditar.Enabled = true;
            this.btnMiniQuitar.Enabled = true;
            this.btnMiniAceptar.Enabled = false;
            this.btnMiniCancelar.Enabled = false;
            //this.btnAceptar.Enabled = true;
        }

        private void txtUPAlquiladas_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotal();
        }

        private void txtUPPropias_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotal();
        }

        private void txtUPAPropias_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotalActivas();
        }

        private void txtUPAAlquiladas_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotalActivas();
        }

        private void txtUPPropiasFinanciadas_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotalFinanciadas();
        }

        private void txtUPAlquiladasFinanciadas_TextChanged(object sender, EventArgs e)
        {
            this.calcularUPTotalFinanciadas();
        }

        private void btnMiniNuevo_Click(object sender, EventArgs e)
        {
            this.nuevaActividadAgricola();
        }

        private void btnMiniEditar_Click(object sender, EventArgs e)
        {
            this.actualizarActividadAgricola();
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            this.eliminarActividadAgricola(sender, e);
        }

        private void cboVariedadCultivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCultivo.SelectedIndex >= 0 && this.cboVariedadCultivo.SelectedIndex >= 0)
            {
                this.cboTipoCultivo1.cargar(
                    this.objEvalCultivoAgrico.idRegistroMatriz,
                    clsVarGlobal.nIdAgencia,
                    Int32.Parse(this.cboCultivo.SelectedValue.ToString()),
                    Int32.Parse(this.cboVariedadCultivo.SelectedValue.ToString())
                );
            }
        }

        private void cboTipoCultivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCultivo.SelectedIndex >= 0 && this.cboVariedadCultivo.SelectedIndex >= 0)
            {
                this.cboTipoFinanciamientoCultivo1.cargar(
                    this.objEvalCultivoAgrico.idRegistroMatriz,
                    clsVarGlobal.nIdAgencia,
                    Int32.Parse(this.cboCultivo.SelectedValue.ToString()),
                    Int32.Parse(this.cboVariedadCultivo.SelectedValue.ToString())
                );
            }
        }

        private void cboTipoFinanciamientoCultivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                this.cboCultivo.SelectedIndex >= 0
                && this.cboVariedadCultivo.SelectedIndex >= 0
                && this.cboTipoCultivo1.SelectedIndex >= 0
                && this.cboTipoFinanciamientoCultivo1.SelectedIndex >= 0)
            {
                this.cboUnidadMedida.cargar(
                    this.objEvalCultivoAgrico.idRegistroMatriz,
                    clsVarGlobal.nIdAgencia,
                    Int32.Parse(this.cboCultivo.SelectedValue.ToString()),
                    Int32.Parse(this.cboVariedadCultivo.SelectedValue.ToString()),
                    Int32.Parse(this.cboTipoCultivo1.SelectedValue.ToString()),
                    Int32.Parse(this.cboTipoFinanciamientoCultivo1.SelectedValue.ToString())
                );
            }
        }

        private void dtgEvaluacionCultivos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dtgEvaluacionCultivos_DataSourceChanged(object sender, EventArgs e)
        {
            this.formatearColumnasDataGridView();
            this.validarParametrosMatriz(this.dtgEvaluacionCultivos);
        }
        #endregion                                
    }
}
