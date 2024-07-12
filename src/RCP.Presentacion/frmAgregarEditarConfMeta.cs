using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmAgregarEditarConfMeta : frmBase
    {
        #region Variables
        clsCNConfigMetas cnConfigMetas = new clsCNConfigMetas();

        public string cPeriodo;
        public int  idTramo,
                    idVariable,
                    idPerfil = 0;
        public decimal nMeta = 0M,
                        nMinMetaComision = 0M,
                        nComision = 0M,
                        nMetaBono = 0M,
                        nBono = 0M;

        public DataTable dtAgencias = null;
        public List<int> lstAgenciasSeleccionadas = new List<int>();
        public bool lGrabar = false;
        #endregion

        public frmAgregarEditarConfMeta()
        {
            InitializeComponent();
            cboUsuRecuperadores1.cargarTodosGestoresYTodos();
            cboPeriodo1.cargarPeriodoDesdeFecha();
        }

        private void frmAgregarEditarConfMeta_Load(object sender, EventArgs e)
        {
            dtAgencias = new clsCNAgencia().LisSoloAgencias();

            clbAgencias.ItemCheck -= clbAgencias_ItemCheck;

            clbAgencias.DataSource = dtAgencias;
            clbAgencias.ValueMember = "idAgencia";
            clbAgencias.DisplayMember = "cNombreAge";

            foreach (DataRowView objAgencia in clbAgencias.Items.Cast<DataRowView>().ToList())
            {
                DataRow rowAgencia = objAgencia.Row;
                if (lstAgenciasSeleccionadas.Any(element => element == Convert.ToInt32(rowAgencia["idAgencia"])))
                {
                    clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(rowAgencia), true);
                }
                else
                {
                    clbAgencias.SetItemChecked(dtAgencias.Rows.IndexOf(rowAgencia), false);
                }
            }

            chbTodasAgencias.CheckedChanged-=chbTodasAgencias_CheckedChanged;
            chbTodasAgencias.Checked = clbAgencias.CheckedItems.Count == clbAgencias.Items.Count;
            chbTodasAgencias.CheckedChanged+=chbTodasAgencias_CheckedChanged;

            clbAgencias.ItemCheck += clbAgencias_ItemCheck;

            txtMeta.Text = nMeta.ToString("0.00");
            txtMinMetaComi.Text = nMinMetaComision.ToString("0.00");
            txtComision.Text = nComision.ToString("0.00");
            txtMetaBono.Text = nMetaBono.ToString("0.00");
            txtBono.Text = nBono.ToString("0.00");
            cboListaPerfil1.cargarPerfilRecuperadores();
            cboListaPerfil1.SelectedValue = idPerfil;            
        }

        private void chbTodasAgencias_CheckedChanged(object sender, EventArgs e)
        {
            clbAgencias.ItemCheck -= clbAgencias_ItemCheck;
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
            clbAgencias.ItemCheck += clbAgencias_ItemCheck;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string cListaAgencias = "";
                string cListaPeriodos = "";
                idPerfil = Convert.ToInt32(cboListaPerfil1.SelectedValue);
                for (int i = 0; i < clbAgencias.Items.Count; i++)
                {
                    if (clbAgencias.GetItemChecked(i))
                    {
                        cListaAgencias += dtAgencias.Rows[i]["idAgencia"] + ",";
                    }
                }

                if (Convert.ToString(cboPeriodo1.SelectedValue) == "000000")
                {
                    int nMes = clsVarGlobal.dFecSystem.Month;
                    if (Convert.ToInt32(clsVarApl.dicVarGen["nDiasLimiteModificarMetas"]) <= clsVarGlobal.dFecSystem.Day)
                    {
                        nMes++;
                    }
                    for (int i = nMes; i <= 12; i++)
                    {
                        cListaPeriodos += i.ToString("00") + clsVarGlobal.dFecSystem.ToString("yyyy") + ",";
                    }
                    if (cListaPeriodos.Length > 0)
                    {
                        cListaPeriodos = cListaPeriodos.Substring(0, cListaPeriodos.Length - 1);
                    }
                }
                else
                {
                    cListaPeriodos = Convert.ToString(cboPeriodo1.SelectedValue);
                }


                DataTable dtResultado = cnConfigMetas.agregarModificar(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue),
                                                                           cListaAgencias,
                                                                           Convert.ToInt32(cboTramo1.SelectedValue),
                                                                           cListaPeriodos,
                                                                           Convert.ToInt32(cboVariableRecuperaciones1.SelectedValue),
                                                                           Convert.ToDecimal(txtMeta.Text),
                                                                           Convert.ToDecimal(txtMinMetaComi.Text),
                                                                           Convert.ToDecimal(txtComision.Text),
                                                                           Convert.ToDecimal(txtMetaBono.Text),
                                                                           Convert.ToDecimal(txtBono.Text),
                                                                           idPerfil,
                                                                           clsVarGlobal.User.idUsuario,
                                                                           clsVarGlobal.dFecSystem.Date);

                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Gestión registrada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lGrabar = true;
                    lstAgenciasSeleccionadas.Clear();
                    for (int i = 0; i < clbAgencias.Items.Count; i++)
                    {
                        if (clbAgencias.GetItemChecked(i))
                        {
                            lstAgenciasSeleccionadas.Add(Convert.ToInt32(dtAgencias.Rows[i]["idAgencia"]));
                        }
                    }
                    idTramo = Convert.ToInt32(cboTramo1.SelectedValue);
                    idVariable = Convert.ToInt32(cboVariableRecuperaciones1.SelectedValue);
                    cPeriodo = Convert.ToString(cboPeriodo1.SelectedValue);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Error al registrar configuración: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validar()
        {
            if (clbAgencias.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una agencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMeta.Focus();
                return false;
            }

            if (txtMeta.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar meta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMeta.Focus();
                return false;
            }

            if (cboListaPerfil1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar perfil", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboListaPerfil1.Focus();
                return false;
            }

            if (txtMinMetaComi.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar meta minima de comisión", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMinMetaComi.Focus();
                return false;
            }

            if (txtComision.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar comisión", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtComision.Focus();
                return false;
            }

            if (txtMetaBono.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar Meta minima para bono", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMetaBono.Focus();
                return false;
            }

            if (txtBono.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar bono", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBono.Focus();
                return false;
            }
            //validar montos,
            if (Convert.ToDecimal(txtMeta.Text) <= 0)
            {
                MessageBox.Show("La meta no puede ser 0.00 %", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMeta.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtMinMetaComi.Text) <= 0)
            {
                MessageBox.Show("La meta minima no puede ser 0.00 %", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMinMetaComi.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtMetaBono.Text) <= 0)
            {
                MessageBox.Show("La meta para acceder a bono no puede ser 0.00 %", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMetaBono.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtMinMetaComi.Text) > Convert.ToDecimal(txtMeta.Text))
            {
                MessageBox.Show("La meta minima para comisión no puede ser mayor a la meta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMinMetaComi.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtMetaBono.Text) < Convert.ToDecimal(txtMinMetaComi.Text))
            {
                MessageBox.Show("La meta bono no puede ser menor a la meta minima para comisión", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMetaBono.Focus();
                return false;
            }

            if (Convert.ToDecimal(txtComision.Text) > 100)
            {
                MessageBox.Show("La comisión no puede superar el 100%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBono.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtBono.Text) > 100)
            {
                MessageBox.Show("El bono no puede superar el 100%", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtBono.Focus();
                return false;
            }
            if (!cboTramo1.Enabled)
            {
                MessageBox.Show("Debe seleccionar el perfil y luego el tramo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboListaPerfil1.Focus();
                return false;
            }
            return true;
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

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            TextBox txtMonto = (TextBox)sender;

            decimal nMonto = 0M;
            Decimal.TryParse(txtMonto.Text.Trim(), out nMonto);
            txtMonto.Text = String.Format("{0:#,0.00}", nMonto);
        }

        private void cboUsuRecuperadores1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadores1.SelectedIndex >= 0)
            {
                DataTable dtRecuperador = (DataTable)cboUsuRecuperadores1.DataSource;
                idPerfil = Convert.ToInt32(((DataRowView)cboUsuRecuperadores1.SelectedItem)["idPerfil"]);
                cboListaPerfil1.SelectedValue = idPerfil;
                cboListaPerfil1.Enabled = Convert.ToInt32(cboUsuRecuperadores1.SelectedValue) == 0;
            }
        }

        private void cboListaPerfil1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboListaPerfil1.SelectedIndex >= 0)
            {
                cboTramo1.cargarTramosPerfil(Convert.ToInt32(cboListaPerfil1.SelectedValue));
                cboTramo1.Enabled = true;
            }
            else
            {
                cboTramo1.SelectedIndex = -1;
                cboTramo1.Enabled = false;
            }
        }
    }
}
