using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmMantenParamEvalSobredeudaCli : frmBase
    {
        #region Varibles globales
        String cTituloMensaje = "Mantenimiento de parámetros de evaluación de sobreendeudamiento";
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();
        String cTipoOperacion = "N";
        int idParametro = 0;
        DataTable dtRangos;
        #endregion

        public frmMantenParamEvalSobredeudaCli()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMantenParamEvalSobredeudaCli_Load(object sender, EventArgs e)
        {
            cargarCboCalific();
            cargarParametros();
            habilitarControles(false);
        }

        private void dtgParametros_SelectionChanged(object sender, EventArgs e)
        {
            verDetalle();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.cTipoOperacion = "N";
            limpiarControles();
            habilitarControles(true);
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgParametros.Rows.Count <= 0)
            {
                MessageBox.Show("No existen parametros para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.cTipoOperacion = "A";
            habilitarControles(true);
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                return;
            }

            DataSet DSRangos = new DataSet("DSRangos");
            DSRangos.Tables.Add(this.dtRangos);
            String xmlRangos = DSRangos.GetXml();
            xmlRangos = clsCNFormatoXML.EncodingXML(xmlRangos);
            DSRangos.Tables.Clear();

            if (this.cTipoOperacion == "N")
            {
                DataTable dtInsercion = sobreendeuda.guardaParamSobredeudaCliente(0, this.txtNombreP.Text, this.txtAbreviatura.Text, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlRangos);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = sobreendeuda.guardaParamSobredeudaCliente(this.idParametro, this.txtNombreP.Text, this.txtAbreviatura.Text, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlRangos);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            this.cTipoOperacion = "";
            limpiarControles();
            cargarParametros();
            habilitarControles(false);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.cTipoOperacion = "";
            limpiarControles();
            verDetalle();
            habilitarControles(false);
        }

        private void btnMiniNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControlRangos(true);
            limpiarControlReglas();
        }
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (validaRangos())
            {
                return;
            }
            DataRow drRangos = this.dtRangos.NewRow();
            drRangos["idRangoParamet"] = 0;
            drRangos["nRangoMin"] = this.nudRangoMin.Value;
            drRangos["nRangoMax"] = this.nudRangoMax.Value;
            drRangos["idCalificacion"] = Convert.ToInt32(this.cboCalificativo.SelectedValue);
            drRangos["cCalificacion"] = Convert.ToString(((DataRowView)this.cboCalificativo.SelectedItem)[this.cboCalificativo.DisplayMember]);
            drRangos["lVigente"] = true;
            this.dtRangos.Rows.Add(drRangos);
            this.dtRangos.AcceptChanges();
            limpiarControlReglas();
            habilitarControlRangos(false);
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgRangos.Rows.Count <= 0)
            {
                MessageBox.Show("No existen rangos para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.dtgRangos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se seleccionó rango a eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int id = this.dtgRangos.SelectedRows[0].Index;
            this.dtgRangos.Rows.RemoveAt(id);
                     
        }
        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            limpiarControlReglas();
            verDetalle();
            habilitarControlRangos(false);                        
        }
        #endregion
        #region Metodos
        private void cargarParametros()
        {
            DataTable dtParametros = sobreendeuda.listaParamSobredeudaCliente(0);
            this.dtgParametros.DataSource = dtParametros;
            darFormatoDTGParametros();
        }
        private void darFormatoDTGParametros()
        {
            foreach (DataGridViewColumn item in this.dtgParametros.Columns)
            {
                item.Visible = false;
            }

            this.dtgParametros.Columns["idParametro"].Visible = true;
            this.dtgParametros.Columns["cParametro"].Visible = true;
            this.dtgParametros.Columns["cParamAbrv"].Visible = true;            
            this.dtgParametros.Columns["lVigente"].Visible = true;

            this.dtgParametros.Columns["idParametro"].FillWeight = 10;
            //this.dtgParametros.Columns["cParametro"].FillWeight = 20;
            this.dtgParametros.Columns["cParamAbrv"].FillWeight = 40;           
            this.dtgParametros.Columns["lVigente"].FillWeight = 20;

            this.dtgParametros.Columns["idParametro"].HeaderText = "Id";
            this.dtgParametros.Columns["cParametro"].HeaderText = "Nombre parametro";
            this.dtgParametros.Columns["cParamAbrv"].HeaderText = "Nom. corto";            
            this.dtgParametros.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private void cargarReglasParametro()
        {
            dtRangos = sobreendeuda.listaRangosParamSobredeudaCliente(this.idParametro);
            dtRangos.DefaultView.RowFilter = ("lVigente = 1");
            dtgRangos.DataSource = dtRangos;
            darFormatoDTGRangos();
        }
        private void darFormatoDTGRangos()
        {
            foreach (DataGridViewColumn item in this.dtgRangos.Columns)
            {
                item.Visible = false;
            }

            this.dtgRangos.Columns["idRangoParamet"].Visible = true;
            this.dtgRangos.Columns["nRangoMin"].Visible = true;
            this.dtgRangos.Columns["nRangoMax"].Visible = true;
            this.dtgRangos.Columns["cCalificacion"].Visible = true;                        

            this.dtgRangos.Columns["idRangoParamet"].FillWeight = 20;
            //this.dtgRangos.Columns["nRangoMin"].FillWeight = 10;
            //this.dtgRangos.Columns["nRangoMax"].FillWeight = 10;
            this.dtgRangos.Columns["cCalificacion"].FillWeight = 180; 
            //this.dtgRangos.Columns["lVigente"].Visible = true;

            this.dtgRangos.Columns["idRangoParamet"].HeaderText = "Id";
            this.dtgRangos.Columns["nRangoMin"].HeaderText = "Rango Min.";
            this.dtgRangos.Columns["nRangoMax"].HeaderText = "Rango Max.";
            this.dtgRangos.Columns["cCalificacion"].HeaderText = "Calificación";
            //this.dtgRangos.Columns["lVigente"].HeaderText = "";

        }
        private Boolean validarDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombreP.Text))
            {
                MessageBox.Show("Debe de ingresar un nombre para el parámetro", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombreP.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.txtAbreviatura.Text))
            {
                MessageBox.Show("Debe de ingresar una descripción para resultado del parámetro", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtAbreviatura.Focus();
                return true;
            }            
            return false;
        }
        private void verDetalle()
        {
            if (this.dtgParametros.SelectedRows.Count > 0)
            {
                this.idParametro = Convert.ToInt32(this.dtgParametros.SelectedRows[0].Cells["idParametro"].Value);
                this.txtNombreP.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cParametro"].Value);
                this.txtAbreviatura.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cParamAbrv"].Value);
                //this.txtSigno.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cSigno"].Value);
                //this.nudConstanteBase.Value = Convert.ToDecimal(this.dtgParametros.SelectedRows[0].Cells["nConstanteBase"].Value);
                //this.txtSimbolo.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cSimbolo"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgParametros.SelectedRows[0].Cells["lVigente"].Value);

                cargarReglasParametro();
            }
        }

        private void habilitarControles(Boolean Val)
        {
            this.txtNombreP.Enabled = Val;
            this.txtAbreviatura.Enabled = Val;
            this.chcVigencia.Enabled = Val;

            habilitarControlRangos(false);
            if (!Val)
            {                
                this.btnMiniNuevo1.Enabled = false;
                this.btnMiniQuitar1.Enabled = false;
            }            

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;

            this.dtgParametros.Enabled = !Val;
        }
        private void habilitarControlRangos(Boolean Val)
        {
            //this.dtgRangos.Enabled = !Val;

            this.btnMiniNuevo1.Enabled = !Val;
            this.btnMiniAgregar1.Enabled = Val;
            this.btnMiniQuitar1.Enabled = !Val;
            this.btnMiniCancelEst1.Enabled = Val;

            this.nudRangoMin.Enabled = Val;
            this.nudRangoMax.Enabled = Val;
            this.cboCalificativo.Enabled = Val;
        }
        private void limpiarControles()
        {
            this.txtNombreP.Clear();
            this.txtAbreviatura.Clear();
            //this.nudRangoMin.Value = 0.00m;
            //this.nudRangoMax.Value = 0.00m;
            //this.txtSigno.Clear();
            //this.nudConstanteBase.Value = 0.00m;
            //this.txtSimbolo.Clear();
            this.dtRangos.Clear();
            limpiarControlReglas();
            this.chcVigencia.Checked = true;
        }
        private void limpiarControlReglas()
        {
            this.nudRangoMin.Value = 0.00m;
            this.nudRangoMax.Value = 0.00m;
            this.cboCalificativo.SelectedIndex = -1;
        }
       
        private void cargarCboCalific()
        {
            DataTable dtCalificativos = sobreendeuda.listaCalificSobredeudaCli(0);
            dtCalificativos.DefaultView.RowFilter = ("lVigente = 1");
            this.cboCalificativo.DataSource = dtCalificativos;
            this.cboCalificativo.DisplayMember = "cCalificacion";
            this.cboCalificativo.ValueMember = "idCalificacion";
        }
        private Boolean validaRangos()
        {
            if (this.nudRangoMin.Value > this.nudRangoMax.Value)
            {
                MessageBox.Show("Rango máximo debe ser mayor a mínimo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudRangoMax.Focus();
                return true;
            }
            foreach (DataGridViewRow item in this.dtgRangos.Rows)
            {
                if ((Convert.ToDecimal(item.Cells["nRangoMin"].Value) <= this.nudRangoMin.Value && this.nudRangoMin.Value <= Convert.ToDecimal(item.Cells["nRangoMax"].Value))
                   || (Convert.ToDecimal(item.Cells["nRangoMin"].Value) <= this.nudRangoMax.Value && this.nudRangoMax.Value <= Convert.ToDecimal(item.Cells["nRangoMax"].Value)))
                {
                    MessageBox.Show("Rangos se superponen a rangos existentes", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudRangoMin.Focus();
                    return true;
                }                
            }
            if (this.cboCalificativo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un calificativo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboCalificativo.Focus();
                return true;
            }
            return false;
        }
        #endregion           

    }
}

