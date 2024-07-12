using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmConfiguracionMetas : frmBase
    {
        DataTable dtConfigMetas = new DataTable();
        clsCNConfigMetas cnConfigMetas = new clsCNConfigMetas();
        DataTable dtAgencias = null;
        int idPerfil = 0;

        public frmConfiguracionMetas()
        {
            InitializeComponent();            
        }

        private void frmConfiguracionMetas_Load(object sender, EventArgs e)
        {
            cboUsuRecuperadores1.SelectedIndexChanged -= cboUsuRecuperadores1_SelectedIndexChanged;
            cboUsuRecuperadores1.cargarTodosGestores();
            cboUsuRecuperadores1.SelectedIndex = -1;
            cboUsuRecuperadores1.SelectedIndexChanged += cboUsuRecuperadores1_SelectedIndexChanged;

            cboTramo1.SelectedIndexChanged -= cboTramo1_SelectedIndexChanged;
            cboTramo1.SelectedValue = 0;
            cboTramo1.SelectedIndexChanged += cboTramo1_SelectedIndexChanged;

            dtAgencias = new clsCNAgencia().LisSoloAgencias();
            
            clbAgencias.DataSource = dtAgencias;
            clbAgencias.ValueMember = "idAgencia";
            clbAgencias.DisplayMember = "cNombreAge";          

            clbAgencias.Enabled = false;
            cboPeriodo1.Enabled = false;
            cboTramo1.Enabled = false;
            cboVariableRecuperaciones1.Enabled = false;
            btnAgregar1.Enabled = false;
            btnEditar1.Enabled = false;
            chbTodasAgencias.Enabled = false;
            chbTodasAgencias.Checked = true;      
        }

        private void cboUsuRecuperadores1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadores1.SelectedIndex >= 0)
            {                
                DataTable dtRecuperador = (DataTable)cboUsuRecuperadores1.DataSource;
                idPerfil = Convert.ToInt32(((DataRowView)cboUsuRecuperadores1.SelectedItem).Row["idPerfil"]);
                cboTramo1.cargarTramosPerfil(idPerfil);

                clbAgencias.Enabled = true;
                chbTodasAgencias.Enabled = true;
                cboPeriodo1.Enabled = true;
                cboVariableRecuperaciones1.Enabled = true;                
                cboTramo1.Enabled = true;
                cboTramo1.SelectedValue = 0;
                cboPeriodo1.SelectedValue = "000000";
                cboVariableRecuperaciones1.SelectedIndex = 0;
                btnAgregar1.Enabled = true;
                btnEditar1.Enabled = true;
                chbTodasAgencias.Enabled = true;
                chbTodasAgencias.Checked = true;
            }
        }

        private void cargarConfiguracionMetas()
        {
            string cListaAgencias = "";
            for (int i = 0; i < clbAgencias.Items.Count; i++)
			{
			    if(clbAgencias.GetItemChecked(i))
                {
                    cListaAgencias += dtAgencias.Rows[i]["idAgencia"] + ",";
                }
            }
            dtConfigMetas = cnConfigMetas.Listar(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), chbTodasAgencias.Checked, cListaAgencias, Convert.ToInt32(cboTramo1.SelectedValue), Convert.ToInt32(cboVariableRecuperaciones1.SelectedValue), Convert.ToString(cboPeriodo1.SelectedValue), idPerfil);
            dtgConfigMetas.DataSource = dtConfigMetas;
            btnEditar1.Enabled = (dtConfigMetas.Rows.Count > 0);
        }        

        private void cboPeriodo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodo1.SelectedIndex >= 0)
            {
                cargarConfiguracionMetas();
            }
        }

        private void cboTramo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTramo1.SelectedIndex >= 0)
            {
                cargarConfiguracionMetas();
            }
        }

        private void cboVariableRecuperaciones1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVariableRecuperaciones1.SelectedIndex >= 0)
            {
                cargarConfiguracionMetas();
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            frmAgregarEditarConfMeta frmAgregarEditarConfMeta = new frmAgregarEditarConfMeta();
            frmAgregarEditarConfMeta.idPerfil = idPerfil; 
            frmAgregarEditarConfMeta.cboTramo1.cargarTramosPerfil(idPerfil);
            frmAgregarEditarConfMeta.cboUsuRecuperadores1.SelectedValue = cboUsuRecuperadores1.SelectedValue;
            frmAgregarEditarConfMeta.cboTramo1.SelectedValue = 0;
            frmAgregarEditarConfMeta.cboVariableRecuperaciones1.SelectedValue = cboVariableRecuperaciones1.SelectedValue;
            cboPeriodo1.SelectedValue = cboPeriodo1.SelectedValue;
            frmAgregarEditarConfMeta.cboUsuRecuperadores1.SelectedValue = 0;
            frmAgregarEditarConfMeta.cboUsuRecuperadores1.Enabled = true;
            frmAgregarEditarConfMeta.lstAgenciasSeleccionadas = clbAgencias.Items.Cast<DataRowView>()
                                                                                    .Select(x => Convert.ToInt32(x["idAgencia"]))
                                                                                     .ToList();

            frmAgregarEditarConfMeta.ShowDialog();

            if (frmAgregarEditarConfMeta.lGrabar)
            {
                cboTramo1.SelectedValue = frmAgregarEditarConfMeta.idTramo;
                cboPeriodo1.SelectedValue = frmAgregarEditarConfMeta.cPeriodo;
                cboVariableRecuperaciones1.SelectedValue = frmAgregarEditarConfMeta.idVariable;

                clbAgencias.SelectedValueChanged -= clbAgencias_SelectedValueChanged;

                foreach (DataRow row in dtAgencias.Rows)
                {
                    if (frmAgregarEditarConfMeta.lstAgenciasSeleccionadas.Any(element => element == Convert.ToInt32(row["idAgencia"])))
                    {
                        clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(row), true);
                    }
                    else
                    {
                        clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(row), false);
                    }

                }

                clbAgencias.SelectedValueChanged += clbAgencias_SelectedValueChanged;
                cargarConfiguracionMetas();
            }     
        }

        private void chbTodasAgencias_CheckedChanged(object sender, EventArgs e)
        {
            clbAgencias.ItemCheck -= clbAgencias_ItemCheck;
            clbAgencias.SelectedValueChanged -= clbAgencias_SelectedValueChanged;
            if (chbTodasAgencias.Checked)
            {
                for (int i = 0; i < clbAgencias.Items.Count; i++)
                {
                    clbAgencias.SetItemCheckState(i, CheckState.Checked);
                }
            }
            else
            {
                for (int i = 0; i < clbAgencias.Items.Count; i++)
                {
                    clbAgencias.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            clbAgencias.SelectedValueChanged += clbAgencias_SelectedValueChanged;
            clbAgencias.ItemCheck += clbAgencias_ItemCheck;
            cargarConfiguracionMetas();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgConfigMetas.SelectedRows.Count > 0 && dtgConfigMetas.Rows.Count > 0)
            {

                int nMes = clsVarGlobal.dFecSystem.Month;
                int nMesEditar = Convert.ToInt32(dtgConfigMetas.SelectedRows[0].Cells["cPeriodo"].Value.ToString().Substring(0, 2));
                if (Convert.ToInt32(clsVarApl.dicVarGen["nDiasLimiteModificarMetas"]) <= clsVarGlobal.dFecSystem.Day)
                {
                    nMes++;
                }
                if (nMes > nMesEditar)
                {
                    MessageBox.Show("No puede editar editar esta configuración", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmAgregarEditarConfMeta frmAgregarEditarConfMeta = new frmAgregarEditarConfMeta();
                frmAgregarEditarConfMeta.idPerfil = idPerfil;
                frmAgregarEditarConfMeta.cboTramo1.cargarTramosPerfil(idPerfil);
                frmAgregarEditarConfMeta.cboTramo1.SelectedValue = Convert.ToInt32(dtgConfigMetas.SelectedRows[0].Cells["idTramo"].Value);
                frmAgregarEditarConfMeta.cboVariableRecuperaciones1.SelectedValue = Convert.ToInt32(dtgConfigMetas.SelectedRows[0].Cells["idVariableRecuperacion"].Value);
                frmAgregarEditarConfMeta.cboUsuRecuperadores1.SelectedIndex = cboUsuRecuperadores1.SelectedIndex;
                frmAgregarEditarConfMeta.cboUsuRecuperadores1.Enabled = false;
                frmAgregarEditarConfMeta.cboVariableRecuperaciones1.Enabled = false;
                frmAgregarEditarConfMeta.cboPeriodo1.SelectedValue = Convert.ToString(dtgConfigMetas.SelectedRows[0].Cells["cPeriodo"].Value);
                
                frmAgregarEditarConfMeta.nMeta = Convert.ToDecimal(dtgConfigMetas.SelectedRows[0].Cells["nPorcMeta"].Value);
                frmAgregarEditarConfMeta.nMinMetaComision = Convert.ToDecimal(dtgConfigMetas.SelectedRows[0].Cells["nPorcMinMetaComision"].Value);
                frmAgregarEditarConfMeta.nComision = Convert.ToDecimal(dtgConfigMetas.SelectedRows[0].Cells["nComision"].Value);
                frmAgregarEditarConfMeta.nMetaBono = Convert.ToDecimal(dtgConfigMetas.SelectedRows[0].Cells["nPorcMetaBono"].Value);
                frmAgregarEditarConfMeta.nBono = Convert.ToDecimal(dtgConfigMetas.SelectedRows[0].Cells["nBono"].Value);
                frmAgregarEditarConfMeta.cboUsuRecuperadores1.SelectedValue = cboUsuRecuperadores1.SelectedValue;
                frmAgregarEditarConfMeta.lstAgenciasSeleccionadas =  clbAgencias.CheckedItems.Cast<DataRowView>()                    
                                                                                    .Select(x => Convert.ToInt32(x["idAgencia"]))
                                                                                     .ToList();
                frmAgregarEditarConfMeta.ShowDialog();
                
                if (frmAgregarEditarConfMeta.lGrabar)
                {
                    cboTramo1.SelectedValue = frmAgregarEditarConfMeta.idTramo;
                    cboPeriodo1.SelectedValue = frmAgregarEditarConfMeta.cPeriodo;
                    cboVariableRecuperaciones1.SelectedValue = frmAgregarEditarConfMeta.idVariable;

                    clbAgencias.SelectedValueChanged -= clbAgencias_SelectedValueChanged;

                    foreach (DataRow row in dtAgencias.Rows)
                    {
                        if (frmAgregarEditarConfMeta.lstAgenciasSeleccionadas.Any(element => element == Convert.ToInt32(row["idAgencia"])))
                        {
                            clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(row), true);
                        }
                        else
                        {
                            clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(row), false);
                        }

                    }

                    clbAgencias.SelectedValueChanged += clbAgencias_SelectedValueChanged;
                    cargarConfiguracionMetas();
                }               
            }
            
        }

        private void clbAgencias_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarConfiguracionMetas();
        }

        private void clbAgencias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            chbTodasAgencias.CheckedChanged -= new System.EventHandler(this.chbTodasAgencias_CheckedChanged);

            if (e.NewValue == CheckState.Checked)
            {

                var itemsChecked = clbAgencias.CheckedItems.Cast<DataRowView>().ToList();
                itemsChecked.Add((DataRowView)clbAgencias.Items[e.Index]);

                chbTodasAgencias.Checked = itemsChecked.Count == clbAgencias.Items.Count;
            }
            else
            {
                chbTodasAgencias.Checked = false;
            }
            
            chbTodasAgencias.CheckedChanged += new System.EventHandler(this.chbTodasAgencias_CheckedChanged);
        }
             
    }
}
