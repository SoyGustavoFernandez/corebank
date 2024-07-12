using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmVincAsesorPromotor : frmBase
    {
        #region Variables Globales

        private clsCNVincAseProm cnVincAseProm = new clsCNVincAseProm();
        private DataTable dtPromotores;
        private const string cTituloMensaje = "Vinculación de asesores y promotores";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            IniForm();
        }

        private void cboAgenciaIni_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cboAgenciaIni.SelectedIndex >= 0)
            {
                if (cboAgenciaIni.SelectedValue != null && !(cboAgenciaIni.SelectedValue is DataRowView))
                {
                    cboAsesorIni.SelectedIndexChanged-=cboAsesorIni_SelectedIndexChanged;
                    cboAsesorIni.ListarPersonal(Convert.ToInt32(cboAgenciaIni.SelectedValue));
                    cboAsesorIni.SelectedIndex = -1;
                    cboAsesorIni.SelectedIndexChanged += cboAsesorIni_SelectedIndexChanged;
                    LimpiarOrigen();
                    int idAgencia = Convert.ToInt32(cboAgenciaIni.SelectedValue);
                    txtPromotor.Text = "";                    
                    cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), idAgencia);                    
                }
            }
        }

        private void cboAgenciaFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgenciaFin.SelectedIndex >= 0)
            {
                if (cboAgenciaFin.SelectedValue != null && !(cboAgenciaFin.SelectedValue is DataRowView))
                {
                    cboAsesorFin.SelectedIndexChanged -= cboAsesorFin_SelectedIndexChanged;
                    cboAsesorFin.ListarPersonal(Convert.ToInt32(cboAgenciaFin.SelectedValue));
                    cboAsesorFin.SelectedIndex = -1;
                    cboAsesorFin.SelectedIndexChanged += cboAsesorFin_SelectedIndexChanged;
                }
            }
        }

        private void cboAsesorIni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAsesorIni.SelectedIndex >= 0)
            {
                if (cboAsesorIni.SelectedValue != null && !(cboAsesorIni.SelectedValue is DataRowView))
                {
                    LimpiarOrigen();
                    if (Convert.ToInt32(cboAsesorIni.SelectedValue) == Convert.ToInt32(cboAsesorFin.SelectedValue))
                    {
                        MessageBox.Show("El asesor de origen y el asesor de destino no pueden ser iguales.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboAsesorIni.SelectedIndex = -1;
                        cboAsesorIni.Focus();
                        dtgPromotoresIni.DataSource = string.Empty;
                        return;
                    }
                    cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue));
                }
            }
        }

        private void cboAsesorFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAsesorFin.SelectedIndex >= 0)
            {
                if (cboAsesorFin.SelectedValue != null && !(cboAsesorFin.SelectedValue is DataRowView))
                {
                    LimpiarDestino();
                    if (Convert.ToInt32(cboAsesorIni.SelectedValue) == Convert.ToInt32(cboAsesorFin.SelectedValue))
                    {
                        MessageBox.Show("El asesor de origen y el asesor de destino no pueden ser iguales.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboAsesorFin.SelectedIndex = -1;
                        cboAsesorFin.Focus();
                        dtgPromotoresFin.DataSource = string.Empty;
                        return;
                    }
                    cargarPromotores(dtgPromotoresFin,lblPromotorFin,Convert.ToInt32(cboAsesorFin.SelectedValue));
                }
            }
        }

        private void cboAgenPromotores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgenPromotores.SelectedValue is int)
            {
                LimpiarOrigen();
                int idAgencia = Convert.ToInt32(cboAgenPromotores.SelectedValue);
                cargarPromotores(dtgPromotoresIni, lblPromotorIni,(chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), idAgencia);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            DataSet dsPromotores = new DataSet("dsPromotores");
            dtPromotores = (DataTable)dtgPromotoresIni.DataSource;
            dtPromotores = dtPromotores.AsEnumerable().Where(x => Convert.ToBoolean(x["lVinc"]) == true).CopyToDataTable();

            dtPromotores.TableName = "dtPromotores";
            dsPromotores.Tables.Add(dtPromotores);

            string xmlPromotores = clsCNFormatoXML.EncodingXML(dsPromotores.GetXml());

            dsPromotores.Tables.Clear();

            int idAsesor = Convert.ToInt32(cboAsesorFin.SelectedValue);
            DateTime dFecSis = clsVarGlobal.dFecSystem;
            int idUsuReg = clsVarGlobal.User.idUsuario;

            DataTable dtResult = cnVincAseProm.CNVincAsesorPromotor(idAsesor, xmlPromotores, dFecSis, idUsuReg);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarOrigen();
                LimpiarDestino();
                cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue));
                cargarPromotores(dtgPromotoresFin, lblPromotorFin, Convert.ToInt32(cboAsesorFin.SelectedValue));
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IniForm();
        }

        private void chcNoVinc_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarOrigen();
            if (chcNoVinc.Checked)
            {

                grbAsesorIni.Enabled = false;
                cboAgenciaIni.SelectedIndex = -1;
                cboAsesorIni.SelectedIndex = -1;
                int idAgencia = Convert.ToInt32(cboAgenPromotores.SelectedValue);
                cargarPromotores(dtgPromotoresIni, lblPromotorIni, -1, idAgencia);
                cboAgenPromotores.Enabled = true;
                btnLiberar1.Enabled = false;
            }
            else
            {
                grbAsesorIni.Enabled = true;
                cboAgenciaIni.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAsesorIni.SelectedIndex = (cboAsesorIni.Items.Count > 0) ? 0 : -1;
                if (cboAsesorIni.SelectedIndex >= 0)
                {
                    if (cboAsesorIni.SelectedValue != null && !(cboAsesorIni.SelectedValue is DataRowView))
                    {
                        cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue));
                    }
                }
                cboAgenPromotores.Enabled = false;
                btnLiberar1.Enabled = true;
            }
            
        }

        private void dtgPromotoresIni_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int nFilasCheck = dtgPromotoresIni.Rows.Cast<DataGridViewRow>()
                                                     .Count(x => Convert.ToBoolean(x.Cells["lVinc"].Value) == true);
            lblSelecIni.Text = string.Format("Seleccionados: {0}", nFilasCheck.ToString());
        }

        private void dtgPromotoresIni_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgPromotoresIni.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        #endregion

        #region Metodos

        public frmVincAsesorPromotor()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            
            
            if (!chcNoVinc.Checked)
            {
                if (cboAgenciaIni.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione la agencia de origen.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cboAsesorIni.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el asesor de origen.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (Convert.ToInt32(cboAgenciaIni.SelectedValue) != Convert.ToInt32(cboAgenciaFin.SelectedValue))
                {
                    MessageBox.Show("La Agencia del Promotor debe ser la misma que el Asesor destino", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAgenciaFin.SelectedValue = cboAgenciaIni.SelectedValue;
                    cboAgenciaFin.Focus();
                    return false;
                }

            }

            int nFilasCheck = dtgPromotoresIni.Rows.Cast<DataGridViewRow>()
                                                     .Count(x => Convert.ToBoolean(x.Cells["lVinc"].Value) == true);
            if (nFilasCheck == 0)
            {
                MessageBox.Show("Seleccione por lo menos un promotor.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgenciaFin.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia de destino.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAsesorFin.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el asesor de destino.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboAsesorIni.SelectedValue) == Convert.ToInt32(cboAsesorFin.SelectedValue))
            {
                MessageBox.Show("El asesor de origen y el asesor de destino no pueden ser iguales.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (chcNoVinc.Checked)
            {
                if (Convert.ToInt32(cboAgenPromotores.SelectedValue) != Convert.ToInt32(cboAgenciaFin.SelectedValue))
                {
                    MessageBox.Show("La Agencia del Promotor debe ser la misma que el Asesor destino", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAgenciaFin.SelectedValue = cboAgenPromotores.SelectedValue;
                    cboAgenciaFin.Focus();
                    return false;
                }
            }

            
            return true;
        }

        private void FormatoGrid(DataGridView dtgLoad,bool bcheck )
        {
            
            dtPromotores.Columns["lVinc"].ReadOnly = false;
            dtgLoad.ReadOnly = false;

            foreach (DataGridViewColumn column in dtgLoad.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            if (bcheck)
            {
                dtgLoad.Columns["lVinc"].Visible = true;
            }
            dtgLoad.Columns["Promotor"].Visible = true;
            dtgLoad.Columns["NombreAsesor"].Visible = true;
            
            
            dtgLoad.Columns["lVinc"].HeaderText = "Vinc?";
            dtgLoad.Columns["Promotor"].HeaderText = "Promotor";
            dtgLoad.Columns["NombreAsesor"].HeaderText = "Asesor";
            

            dtgLoad.Columns["lVinc"].FillWeight = 15;
            dtgLoad.Columns["Promotor"].FillWeight = 55;
            dtgLoad.Columns["NombreAsesor"].FillWeight = 50;
            
            if (dtgLoad.Equals(dtgPromotoresFin))
            {
                dtgLoad.Columns["Agencia"].Visible = true;
                dtgLoad.Columns["Agencia"].HeaderText = "Agencia";
                dtgLoad.Columns["lVinc"].FillWeight = 50;
                
            }

            dtgLoad.Columns["lVinc"].ReadOnly = false;
        }

        private void IniForm()
        {
            LimpiarOrigen();
            LimpiarDestino();
            cboAgenciaIni.SelectedIndex = -1;
            cboAsesorIni.SelectedIndex = -1;
            cboAgenPromotores.SelectedValue = 0;
            cboAgenciaFin.SelectedValue = clsVarGlobal.nIdAgencia;
            chcNoVinc.CheckedChanged -= chcNoVinc_CheckedChanged;
            chcNoVinc.Checked = true;
            chcNoVinc_CheckedChanged(this, null);
            chcNoVinc.CheckedChanged += chcNoVinc_CheckedChanged;
        }

        private void cargarPromotores(DataGridView dtgLoad,Label lblResult,int idAsesor,int idAgencia = 0, bool loadbuscar = false)
        {
            if (loadbuscar == true)
            {
                if (chcNoVinc.Checked)
                {
                    dtPromotores = cnVincAseProm.CNbuscarPromotor(false, Convert.ToInt32(cboAgenPromotores.SelectedValue), Convert.ToString(txtPromotor.Text).Trim());
                }
                else {
                    dtPromotores = cnVincAseProm.CNbuscarPromotor(true, Convert.ToInt32(cboAgenciaIni.SelectedValue), Convert.ToString(txtPromotor.Text).Trim());
                }                
                dtgLoad.DataSource = dtPromotores;
                lblResult.Text = string.Format("Promotores: {0}", dtgLoad.Rows.Count);
                FormatoGrid(dtgLoad, (dtgLoad.Name.Equals("dtgPromotoresIni")));                
            }
            else {
                dtPromotores = cnVincAseProm.CNLstPromotorByAsesorAgencia(idAsesor, idAgencia);
                dtgLoad.DataSource = dtPromotores;
                lblResult.Text = string.Format("Promotores: {0}", dtgLoad.Rows.Count);
                FormatoGrid(dtgLoad, (dtgLoad.Name.Equals("dtgPromotoresIni")));
            }
        }

        private void LimpiarOrigen()
        {
            lblPromotorIni.Text = "Promotores: 0";
            lblSelecIni.Text = "Seleccionados: 0";     
        }

        private void LimpiarDestino()
        {
            lblPromotorFin.Text = "Promotores: 0";
        }

        private void btnBuscarPromotor_Click(object sender, EventArgs e)
        {
            if (chcNoVinc.Checked)
            {
                cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), (cboAgenciaIni.SelectedIndex < 0) ? 0 : Convert.ToInt16(cboAgenciaIni.SelectedValue), true);
            }
            else {
                cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), (cboAgenPromotores.SelectedIndex < 0) ? 0 : Convert.ToInt16(cboAgenPromotores.SelectedValue), true);
            }
        }
        
        #endregion

        private void txtPromotor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (String.IsNullOrEmpty(this.txtPromotor.Text.ToString()))
                {
                    MessageBox.Show("Ingrese valores de [A-Z]", "Búsqueda de promotores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {                    
                    if (chcNoVinc.Checked)
                    {
                        cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), (cboAgenciaIni.SelectedIndex < 0) ? 0 : Convert.ToInt16(cboAgenciaIni.SelectedValue), true);
                    }
                    else
                    {
                        cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue), (cboAgenPromotores.SelectedIndex < 0) ? 0 : Convert.ToInt16(cboAgenPromotores.SelectedValue), true);
                    }
                }
            }
        }

        private void btnLiberar1_Click(object sender, EventArgs e)
        {
            if (!Valida()) return;
            {
            DataSet dsPromotores = new DataSet("dsPromotores");
            dtPromotores = (DataTable)dtgPromotoresIni.DataSource;
            dtPromotores = dtPromotores.AsEnumerable().Where(x => Convert.ToBoolean(x["lVinc"]) == true).CopyToDataTable();

            dtPromotores.TableName = "dtPromotores";
            dsPromotores.Tables.Add(dtPromotores);

            string xmlPromotores = clsCNFormatoXML.EncodingXML(dsPromotores.GetXml());

            dsPromotores.Tables.Clear();

            int idAsesor = Convert.ToInt32(cboAsesorFin.SelectedValue);
            DateTime dFecSis = clsVarGlobal.dFecSystem;
            int idUsuReg = clsVarGlobal.User.idUsuario;

            DataTable dtResult = cnVincAseProm.CNDesvincAsesorPromotor(idAsesor, xmlPromotores, dFecSis, idUsuReg);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarOrigen();
                LimpiarDestino();
                cargarPromotores(dtgPromotoresIni, lblPromotorIni, (chcNoVinc.Checked) ? -1 : Convert.ToInt32(cboAsesorIni.SelectedValue));
                cargarPromotores(dtgPromotoresFin, lblPromotorFin, Convert.ToInt32(cboAsesorFin.SelectedValue));
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }

            }

        private void dtgPromotoresIni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool Valida()
        {
            int nFilasCheck = dtgPromotoresIni.Rows.Cast<DataGridViewRow>()
                                                     .Count(x => Convert.ToBoolean(x.Cells["lVinc"].Value) == true);
            if (nFilasCheck == 0)
            {
                MessageBox.Show("Seleccione por lo menos un promotor.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
          return true;
        }
        

    }
}
