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
    public partial class frmRegCampaniaCondonacion : frmBase
    {
        #region Variables Globales
        int idCampania = 0;
        Boolean lVigenteCampania = false;
        DateTime dFechaFinVigencia;
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();

        DataTable dtReglas = new DataTable();
        String cTituloMensaje = "Campañas de condonación";
        String cTipoOperacion = "N";    //N:nuevo, A:actualizar
        #endregion

        public frmRegCampaniaCondonacion()
        {
            InitializeComponent();
        }

        private void frmRegCampaniaCondonacion_Load(object sender, EventArgs e)
        {
            habilitarControlesCampania(false);
            
            this.cboTipoRango.SelectedIndexChanged -= new EventHandler(cboTipoRango_SelectedIndexChanged);

            cargaCboTipoRango();
            this.cboCondicionContable1.listaCondicionContableXIDs(1);
            cargarCampanias();
            this.cboTipoRango.SelectedIndexChanged += new EventHandler(cboTipoRango_SelectedIndexChanged);
        }
        
        private void dtgCampanias_SelectionChanged(object sender, EventArgs e)
        {
            verDetallesCampania();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiarControlesCampania();
            habilitarControlesCampania(true);
            habilitarControlReglas(false);
            this.cTipoOperacion = "N";
       
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (lVigenteCampania)
            {
                habilitarControlesCampania(true);
                habilitarSoloVigencia(true);
                bloqueoControlesReglas(false);
            }
            else
            {                
                habilitarControlesCampania(true);
                habilitarControlReglas(false);            
            }
            this.cTipoOperacion = "A";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControlesCampania();
            habilitarControlesCampania(false);
            verDetallesCampania();
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validaDatos())
            {
                return;
            }
            String cNombre = this.txtNombre.Text;
            String cDescripcion = this.txtDescripcion.Text;
            DateTime dVigInicio = this.dtpVigDesde.Value;
            DateTime dVigFin = this.dtpVigHasta.Value;

            DataSet DSReglas = new DataSet("DSReglas");
            DSReglas.Tables.Add(this.dtReglas);
            String xmlReglas = DSReglas.GetXml();
            xmlReglas = clsCNFormatoXML.EncodingXML(xmlReglas);
            DSReglas.Tables.Clear();

            if (this.cTipoOperacion == "N")
            {
                DataTable dtGuardar = cnCondonacion.guardarTipoCondonacion(0, cNombre, cDescripcion, dVigInicio, dVigFin, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlReglas);
                MessageBox.Show(dtGuardar.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtGuardar.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtGuardar = cnCondonacion.guardarTipoCondonacion(this.idCampania, cNombre, cDescripcion, dVigInicio, dVigFin, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlReglas);
                MessageBox.Show(dtGuardar.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtGuardar.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            cargarCampanias();
            limpiarControlesCampania();
            habilitarControlesCampania(false);
            //habilitarControlReglas(false);
            verDetallesCampania();
        }
        private void btnMiniNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControlReglas(true);
        }      
        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            limpiarControlesReglas();
            habilitarControlReglas(false);
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (!validaReglaNueva())
            {
                return;
            }
            DataRow drRegla = this.dtReglas.NewRow();
            drRegla["idDetalleTipoCond"] = 0;
            drRegla["idTipoCartera"] = this.cboCondicionContable1.SelectedValue;
            drRegla["cCartera"] = ((System.Data.DataRowView)this.cboCondicionContable1.SelectedItem)["cContable"].ToString();
            drRegla["idRangoTipoDato"] = this.cboTipoRango.SelectedValue;
            drRegla["cRangoTipoDato"] = ((System.Data.DataRowView)this.cboTipoRango.SelectedItem).Row.ItemArray[1].ToString();
            drRegla["nRangoMinimo"] = this.nudRangoMin.Value;
            drRegla["nRangoMaximo"] = this.nudRangoMax.Value;
            drRegla["nPorcDsctoCapital"] = this.nudDsctoCapital.Value;
            drRegla["nPorcDsctoInteres"] = this.nudDsctoInteres.Value;
            drRegla["nPorcDsctoIntComp"] = this.nudDsctoIntComp.Value;
            drRegla["nPorcDsctoMora"] = this.nudDsctoMora.Value;
            drRegla["nPorcDsctoGastos"] = this.nudDsctoOtros.Value;
            this.dtReglas.Rows.Add(drRegla);

            limpiarControlesReglas();
            habilitarControlReglas(false);
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgReglas.Rows.Count <= 0)
            {
                MessageBox.Show("No existen reglas para quitar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (this.dtgReglas.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar la regla que desea eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    int id = this.dtgReglas.SelectedRows[0].Index;
                    this.dtgReglas.Rows.RemoveAt(id);
                }
            }
        }
        private void cboCondicionContable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboCondicionContable1.SelectedValue) == 1)
            {
                this.cboTipoRango.SelectedValue = 1;
            }
            else if (Convert.ToInt32(this.cboCondicionContable1.SelectedValue) == 3 || Convert.ToInt32(this.cboCondicionContable1.SelectedValue) == 4)
            {
                this.cboTipoRango.SelectedValue = 0;
            }
            else if (Convert.ToInt32(this.cboCondicionContable1.SelectedValue) == 6)
            {
                this.cboTipoRango.SelectedValue = 2;
            }
        }
        private void cboTipoRango_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboTipoRango.SelectedValue) == 0)
            {
                this.nudRangoMin.Enabled = false;
                this.nudRangoMax.Enabled = false;
                this.nudRangoMin.Minimum = 0;
                this.nudRangoMin.Maximum = 999;
                this.nudRangoMax.Minimum = 0;
                this.nudRangoMax.Maximum = 999;
                this.nudRangoMin.Value = 0;     this.nudRangoMax.Value = 999;
            }
            if (Convert.ToInt32(this.cboTipoRango.SelectedValue) == 1)
            {
                this.nudRangoMin.Enabled = true;
                this.nudRangoMax.Enabled = true;
                this.nudRangoMin.Minimum = 0;                
                this.nudRangoMin.Maximum = 999;
                this.nudRangoMax.Minimum = 0;
                this.nudRangoMax.Maximum = 999;
                this.nudRangoMin.Value = this.nudRangoMax.Value = 1;                
            }
            if (Convert.ToInt32(this.cboTipoRango.SelectedValue) == 2)
            {
                this.nudRangoMin.Enabled = true;
                this.nudRangoMax.Enabled = true;
                this.nudRangoMin.Minimum = 1900;
                this.nudRangoMin.Maximum = 9999;
                this.nudRangoMax.Minimum = 1900;
                this.nudRangoMax.Maximum = 9999;
                this.nudRangoMin.Value = this.nudRangoMax.Value = DateTime.Today.Year; 
            }
        }

        #region Metodos 
        private void cargarCampanias()
        {
            DataTable dtListaCampañas = cnCondonacion.listaTipoCondonacion(0, 1);//perfil admin de sistemas, para todos los usuarios
            this.dtgCampanias.DataSource = dtListaCampañas;
            formatoDTVCampanias();
            cargarReglasCampania(Convert.ToInt32(this.dtgCampanias.SelectedRows[0].Cells["idTipoCondonacion"].Value));
        }
        private void formatoDTVCampanias()
        {
            foreach (DataGridViewColumn columna in this.dtgCampanias.Columns)
            {
                columna.Visible = false;
            }
            this.dtgCampanias.Columns["idTipoCondonacion"].Visible = true;
            this.dtgCampanias.Columns["cNombreCondonacion"].Visible = true;
            this.dtgCampanias.Columns["dFechaInicio"].Visible = true;
            this.dtgCampanias.Columns["dFechaFin"].Visible = true;
            this.dtgCampanias.Columns["lVigente"].Visible = true;

            this.dtgCampanias.Columns["idTipoCondonacion"].Width = 10;
            this.dtgCampanias.Columns["cNombreCondonacion"].Width = 60;
            this.dtgCampanias.Columns["dFechaInicio"].Width = 30;
            this.dtgCampanias.Columns["dFechaFin"].Width = 30;
            this.dtgCampanias.Columns["lVigente"].Width = 40; 

            this.dtgCampanias.Columns["idTipoCondonacion"].HeaderText = "Nº";
            this.dtgCampanias.Columns["cNombreCondonacion"].HeaderText = "Nombre";
            this.dtgCampanias.Columns["dFechaInicio"].HeaderText = "Fechainicio";
            this.dtgCampanias.Columns["dFechaFin"].HeaderText = "Fecha fin";
            this.dtgCampanias.Columns["lVigente"].HeaderText = "Vigencia";

        }
        private void verDetallesCampania()
        {
            if (this.dtgCampanias.SelectedRows.Count > 0)
            {
                this.idCampania = Convert.ToInt32(this.dtgCampanias.SelectedRows[0].Cells["idTipoCondonacion"].Value);
                this.txtNombre.Text = Convert.ToString(this.dtgCampanias.SelectedRows[0].Cells["cNombreCondonacion"].Value);
                this.txtDescripcion.Text = Convert.ToString(this.dtgCampanias.SelectedRows[0].Cells["cDescripcionCond"].Value);
                this.dtpVigDesde.Value = Convert.ToDateTime(this.dtgCampanias.SelectedRows[0].Cells["dFechaInicio"].Value);
                this.dtpVigHasta.Value = Convert.ToDateTime(this.dtgCampanias.SelectedRows[0].Cells["dFechaFin"].Value);
                this.lVigenteCampania = Convert.ToBoolean(this.dtgCampanias.SelectedRows[0].Cells["lVigente"].Value);
                cargarReglasCampania(idCampania);
                if (this.dtpVigHasta.Value < clsVarGlobal.dFecSystem)
                {
                    this.btnEditar1.Enabled = false;
                }
                else
                {
                    this.btnEditar1.Enabled = true;
                }
            }
        }
        private void cargarReglasCampania(int idCampania)
        {
            this.dtReglas = cnCondonacion.listaReglasTipoCondonacion(idCampania);
            this.dtgReglas.DataSource = this.dtReglas;
            formatoDTVReglas();
        }
        private void formatoDTVReglas()
        {
            foreach (DataGridViewColumn columna in this.dtgReglas.Columns)
            {
                columna.Visible = false;
            }            
            this.dtgReglas.Columns["cCartera"].Visible = true;
            this.dtgReglas.Columns["cRangoTipoDato"].Visible = true;
            this.dtgReglas.Columns["nRangoMinimo"].Visible = true;
            this.dtgReglas.Columns["nRangoMaximo"].Visible = true;
            this.dtgReglas.Columns["nPorcDsctoCapital"].Visible = true;
            this.dtgReglas.Columns["nPorcDsctoInteres"].Visible = true;
            this.dtgReglas.Columns["nPorcDsctoIntComp"].Visible = true;
            this.dtgReglas.Columns["nPorcDsctoMora"].Visible = true;
            this.dtgReglas.Columns["nPorcDsctoGastos"].Visible = true;

            this.dtgReglas.Columns["cCartera"].Width = 70;
            this.dtgReglas.Columns["cRangoTipoDato"].Width = 85;
            this.dtgReglas.Columns["nRangoMinimo"].Width = 40;
            this.dtgReglas.Columns["nRangoMaximo"].Width = 40;
            
            this.dtgReglas.Columns["nPorcDsctoCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgReglas.Columns["nPorcDsctoInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            this.dtgReglas.Columns["nPorcDsctoIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            this.dtgReglas.Columns["nPorcDsctoMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            this.dtgReglas.Columns["nPorcDsctoGastos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
     
            this.dtgReglas.Columns["cCartera"].HeaderText = "Cartera";
            this.dtgReglas.Columns["cRangoTipoDato"].HeaderText = "Rango por";
            this.dtgReglas.Columns["nRangoMinimo"].HeaderText = "Mín.";
            this.dtgReglas.Columns["nRangoMaximo"].HeaderText = "Máx.";
            this.dtgReglas.Columns["nPorcDsctoCapital"].HeaderText = "%Capital";
            this.dtgReglas.Columns["nPorcDsctoInteres"].HeaderText = "%Interés";
            this.dtgReglas.Columns["nPorcDsctoIntComp"].HeaderText = "%Inter. Comp.";
            this.dtgReglas.Columns["nPorcDsctoMora"].HeaderText = "%Mora";
            this.dtgReglas.Columns["nPorcDsctoGastos"].HeaderText = "%Gastos";
        }
        private void habilitarControlesCampania(Boolean val)
        {           
            this.txtNombre.Enabled = val;
            this.txtDescripcion.Enabled = val;
            this.dtpVigDesde.Enabled = val;
            this.dtpVigHasta.Enabled = val;
                        
            this.btnNuevo1.Enabled = !val;
            this.btnEditar1.Enabled = !val;
            this.btnGrabar1.Enabled = val;
            this.btnCancelar.Enabled = val;

            //this.grbReglas.Enabled = val;
            bloqueoControlesReglas(val);

            this.dtgCampanias.Enabled = !val;
        }
        private void habilitarSoloVigencia(Boolean val) 
        {
            this.dtpVigDesde.Enabled = !val;
            this.dtpVigHasta.Enabled = val;
            this.txtNombre.Enabled = !val;
            this.txtDescripcion.Enabled = !val;
        }
        private void habilitarControlReglas(Boolean val)
        {
            this.cboCondicionContable1.Enabled = val;
            this.cboTipoRango.Enabled = val;
            this.nudRangoMin.Enabled = val;
            this.nudRangoMax.Enabled = val;
            this.nudDsctoCapital.Enabled = val;
            this.nudDsctoInteres.Enabled = val;
            this.nudDsctoIntComp.Enabled = val;
            this.nudDsctoMora.Enabled = val;
            this.nudDsctoOtros.Enabled = val;

            this.btnMiniNuevo1.Enabled = !val;            
            this.btnMiniAgregar1.Enabled = val;
            this.btnMiniQuitar1.Enabled = !val;
            this.btnMiniCancelEst1.Enabled = val;

            //this.dtgReglas.Enabled = !val;            
        }
        private void bloqueoControlesReglas( Boolean val)
        { //bloquea todos los controles para agregar reglas
            habilitarControlReglas(val);
            this.btnMiniNuevo1.Enabled = val;
            this.btnMiniQuitar1.Enabled = val;
        }
        private void limpiarControlesCampania()
        {
            this.txtNombre.Clear();
            this.txtDescripcion.Clear();
            this.dtpVigDesde.Value = DateTime.Now;
            this.dtpVigHasta.Value = DateTime.Now;
            cargarReglasCampania(0);            
        }
        private void limpiarControlesReglas()
        {
            this.cboCondicionContable1.SelectedIndex = 0;
            this.cboTipoRango.SelectedIndex = 1;
            this.nudRangoMin.Value = 0;
            this.nudRangoMax.Value = 0;
            this.nudDsctoCapital.Value = 0;
            this.nudDsctoInteres.Value = 0;
            this.nudDsctoIntComp.Value = 0;
            this.nudDsctoMora.Value = 0;
            this.nudDsctoOtros.Value = 0;
        }
        #endregion

        
        private void cargaCboTipoRango()
        {
            DataTable dtTipoRango = new DataTable();
            dtTipoRango.Columns.Add("idTipoRango", typeof(String));
            dtTipoRango.Columns.Add("cTipoRango", typeof(String));
            DataRow drTipRang0 = dtTipoRango.NewRow();
            drTipRang0["idTipoRango"] = "0";
            drTipRang0["cTipoRango"] = "Sin rangos";
            dtTipoRango.Rows.Add(drTipRang0);
            DataRow drTipRang = dtTipoRango.NewRow();
            drTipRang["idTipoRango"] = "1";
            drTipRang["cTipoRango"] = "Días de atraso";
            dtTipoRango.Rows.Add(drTipRang);
            DataRow drTipRang2 = dtTipoRango.NewRow();
            drTipRang2["idTipoRango"] = "2";
            drTipRang2["cTipoRango"] = "Año de castigo";
            dtTipoRango.Rows.Add(drTipRang2);

            this.cboTipoRango.DataSource = dtTipoRango;
            this.cboTipoRango.ValueMember = dtTipoRango.Columns["idTipoRango"].ToString();
            this.cboTipoRango.DisplayMember = dtTipoRango.Columns["cTipoRango"].ToString();

        }
        private Boolean validaDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para campaña", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para campaña", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDescripcion.Focus();
                return false;
            }
            if (this.dtpVigDesde.Value > this.dtpVigHasta.Value)
            {
                MessageBox.Show("La fecha de vigencia final no puede ser menor que la fecha de inicio", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpVigHasta.Focus();
                return false;
            }
            if (this.dtgReglas.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese al menos una regla de campaña", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnMiniNuevo1.Focus();
                return false;
            }
            return true;
        }
        private Boolean validaReglaNueva()
        {
            foreach (DataGridViewRow item in this.dtgReglas.Rows)
            {
                if (this.nudRangoMin.Value > this.nudRangoMax.Value)
                {
                    MessageBox.Show("Rango máximo debe ser mayor a mínimo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudRangoMax.Focus();
                    return false;
                }
                if (this.cboTipoRango.SelectedValue.ToString() == item.Cells["idRangoTipoDato"].Value.ToString() && this.cboCondicionContable1.SelectedValue.ToString() == item.Cells["idTipoCartera"].Value.ToString()
                    && Convert.ToInt32(this.cboTipoRango.SelectedValue) != 0 )
                {
                    if ((Convert.ToInt32(item.Cells["nRangoMinimo"].Value) <= this.nudRangoMin.Value && this.nudRangoMin.Value <= Convert.ToInt32(item.Cells["nRangoMaximo"].Value))
                        || (Convert.ToInt32(item.Cells["nRangoMinimo"].Value) <= this.nudRangoMax.Value && this.nudRangoMax.Value <= Convert.ToInt32(item.Cells["nRangoMaximo"].Value)))
                    {
                        MessageBox.Show("Rangos se superponen a rangos existentes", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nudRangoMin.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        

        
    }
}
