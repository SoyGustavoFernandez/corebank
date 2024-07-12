using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmConfiguracionLimite : frmBase
    {
        #region Variables

        clsCNConfiguracionLimite clsCNConfiguracionLimite = new clsCNConfiguracionLimite();
        private int idConfigLimite = 0;
        private int idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString());
        DataTable dtConfigLim = new DataTable();

        #endregion

        #region Metodos Publicos

        public frmConfiguracionLimite()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos Privados

        private void cargarDatos()
        {
            limpiarControles();
            
            dtConfigLim = clsCNConfiguracionLimite.CNListarConfiguracionLimite();
            BindingSource bsConfigLim = new BindingSource();
            bsConfigLim.DataSource = dtConfigLim;
            dtgConfiguracionLimite.DataSource = bsConfigLim.DataSource;
            formatearDataGrid();
            cboTipoOpeEOB.CargarTipoOpeEOB();
            cboLimitesExcep.CargarLimitesExcep();
            
        }
       
        private void formatearDataGrid()
        {
            foreach (DataGridViewColumn item in dtgConfiguracionLimite.Columns)
            {
                item.Visible = false;
            }
            dtgConfiguracionLimite.ScrollBars = ScrollBars.Both;
            dtgConfiguracionLimite.Columns["cTipoOpe"].Visible = true;
            dtgConfiguracionLimite.Columns["nLimiteInferior"].Visible = true;
            dtgConfiguracionLimite.Columns["nLimiteSuperior"].Visible = true;
            dtgConfiguracionLimite.Columns["cLimiteExcep"].Visible = true;

            dtgConfiguracionLimite.Columns["cTipoOpe"].HeaderText = "Tipo Operacion";
            dtgConfiguracionLimite.Columns["nLimiteInferior"].HeaderText = "Limite Inferior";
            dtgConfiguracionLimite.Columns["nLimiteSuperior"].HeaderText = "Limite Superior";
            dtgConfiguracionLimite.Columns["cLimiteExcep"].HeaderText = "Tipo Limite";

            dtgConfiguracionLimite.Columns["cTipoOpe"].DisplayIndex =0;
            dtgConfiguracionLimite.Columns["nLimiteInferior"].DisplayIndex = 1;
            dtgConfiguracionLimite.Columns["nLimiteSuperior"].DisplayIndex = 2;
            dtgConfiguracionLimite.Columns["cLimiteExcep"].DisplayIndex = 3;

            dtgConfiguracionLimite.Columns["cTipoOpe"].Width = 210;
            dtgConfiguracionLimite.Columns["nLimiteInferior"].Width = 80;
            dtgConfiguracionLimite.Columns["nLimiteSuperior"].Width = 80;
            dtgConfiguracionLimite.Columns["cLimiteExcep"].Width = 90;
        }
       
        private void cargarControles(clsConfiguracionLimite clsConfigLimite)
        {
            cboTipoOpeEOB.SelectedValue = clsConfigLimite.idTipoOpe;
            cboLimitesExcep.SelectedValue = clsConfigLimite.idLimiteExcep;
            txtLimiteInferior.Text = clsConfigLimite.nLimiteInferior.ToString();
            txtLimiteSuperior.Text = clsConfigLimite.nLimiteSuperior.ToString();
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            cboTipoOpeEOB.Enabled = true;
            cboLimitesExcep.Enabled = true;
            txtLimiteInferior.Enabled= true;
            txtLimiteSuperior.Enabled = true;
            btnCancelar.Enabled = true;

        }
        
        private void limpiarControles()
        {
            cboTipoOpeEOB.SelectedIndex = -1;
            cboLimitesExcep.SelectedIndex = -1;
            txtLimiteInferior.Text = "";
            txtLimiteSuperior.Text = "";
            idConfigLimite = 0;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            cboTipoOpeEOB.Enabled = false;
            cboLimitesExcep.Enabled = false;
            txtLimiteInferior.Enabled = false;
            txtLimiteSuperior.Enabled = false;
        }
        
        private bool validarControles()
        {
            bool valido = true;
            if (cboTipoOpeEOB.SelectedIndex <=0 || cboTipoOpeEOB.SelectedValue == "0")
            {
                MessageBox.Show("Seleccione un tipo de operación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valido= false;
            }

            if (cboLimitesExcep.SelectedIndex <= 0 || cboLimitesExcep.SelectedValue == "0")
            {
                MessageBox.Show("Seleccione un tipo de limite", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valido = false;
            }
            if (txtLimiteInferior.Text == "")
            {
                MessageBox.Show("Ingrese un limite inferior", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valido = false;
            }
            if (txtLimiteSuperior.Text == "")
            {
                MessageBox.Show("Ingrese un limite superior", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valido = false;
            }

            if (idConfigLimite == 0)
            {
                bool Registrado = dtConfigLim.AsEnumerable().Any(row =>
                    cboTipoOpeEOB.SelectedIndex >= row.Field<int>("idTipoOpe") &&
                    cboTipoOpeEOB.SelectedIndex <= row.Field<int>("idLimiteExcep"));

                if (Registrado)
                {
                    MessageBox.Show("Ya esta registrado la configuracion", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valido = false;
                }
            }
            return valido;
            
        }

        #endregion

        #region Eventos

        private void frmConfiguracionLimite_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        
        private void txtLimiteInferior_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            if (decimal.TryParse(txtLimiteSuperior.Text, out value))
            {
                int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
                if (decimalPlaces > 2)
                {
                    value = Math.Round(value, 2);
                    txtLimiteSuperior.Text = value.ToString("0.00");
                    txtLimiteSuperior.SelectionStart = txtLimiteSuperior.Text.Length;
                }
            }
            else
            {
                txtLimiteSuperior.Text = string.Empty;
            }
        }

        private void txtLimiteSuperior_TextChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            if (decimal.TryParse(txtLimiteSuperior.Text, out value))
            {
                int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
                if (decimalPlaces > 2)
                {
                    value = Math.Round(value, 2);
                    txtLimiteSuperior.Text = value.ToString("0.00");
                    txtLimiteSuperior.SelectionStart = txtLimiteSuperior.Text.Length;
                }
            }
            else
            {
                txtLimiteSuperior.Text = string.Empty;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            clsConfiguracionLimite configuracionLimiteEditar = new clsConfiguracionLimite();
            if (dtgConfiguracionLimite.SelectedRows.Count > 0)            {
                configuracionLimiteEditar.idConfig = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idConfig"].Value.ToString());
                configuracionLimiteEditar.idTipoOpe = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idTipoOpe"].Value.ToString());
                configuracionLimiteEditar.idLimiteExcep = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idLimiteExcep"].Value.ToString());
                configuracionLimiteEditar.nLimiteInferior = Convert.ToDecimal(dtgConfiguracionLimite.CurrentRow.Cells["nLimiteInferior"].Value.ToString());
                configuracionLimiteEditar.nLimiteSuperior = Convert.ToDecimal(dtgConfiguracionLimite.CurrentRow.Cells["nLimiteSuperior"].Value.ToString());
                idConfigLimite = configuracionLimiteEditar.idConfig;
                cargarControles(configuracionLimiteEditar);
            }
            else
            {
                MessageBox.Show("Selecione la configuración a editar");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clsConfiguracionLimite configuracionLimiteNuevo = new clsConfiguracionLimite();
            configuracionLimiteNuevo.idConfig = 0;
            configuracionLimiteNuevo.idTipoOpe =-1;
            configuracionLimiteNuevo.idLimiteExcep = -1;
            configuracionLimiteNuevo.nLimiteInferior = 0;
            configuracionLimiteNuevo.nLimiteSuperior = 0;
            idConfigLimite = configuracionLimiteNuevo.idConfig;
            cargarControles(configuracionLimiteNuevo);
        }
        
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarControles())
            {
                clsConfiguracionLimite configuracionLimite = new clsConfiguracionLimite();
                configuracionLimite.idConfig = idConfigLimite;
                configuracionLimite.idTipoOpe = Convert.ToInt32(cboTipoOpeEOB.SelectedValue.ToString());
                configuracionLimite.idLimiteExcep = Convert.ToInt32(cboLimitesExcep.SelectedValue.ToString());
                configuracionLimite.nLimiteInferior = Convert.ToDecimal(txtLimiteInferior.Text);
                configuracionLimite.nLimiteSuperior = Convert.ToDecimal(txtLimiteSuperior.Text);
                configuracionLimite.lVigente = true;
                configuracionLimite.nUsuario = idUsuario;
                if (MessageBox.Show("¿Está seguro de guardar la configuración?", "Guardar Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtNewConfig = clsCNConfiguracionLimite.CNMantenimientoConfiguracionLimite(configuracionLimite);
                    if (dtNewConfig.Rows.Count > 0)
                    {
                        string Msj = dtNewConfig.Rows[0]["cInformación"].ToString();
                        MessageBox.Show(Msj,"Información",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        limpiarControles();
                        cargarDatos();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsConfiguracionLimite configuracionLimiteEliminar = new clsConfiguracionLimite();
            if (dtgConfiguracionLimite.SelectedRows.Count > 0)
            {
                configuracionLimiteEliminar.idConfig = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idConfig"].Value.ToString());
                configuracionLimiteEliminar.idTipoOpe = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idTipoOpe"].Value.ToString());
                configuracionLimiteEliminar.idLimiteExcep = Convert.ToInt32(dtgConfiguracionLimite.CurrentRow.Cells["idLimiteExcep"].Value.ToString());
                configuracionLimiteEliminar.nLimiteInferior = Convert.ToDecimal(dtgConfiguracionLimite.CurrentRow.Cells["nLimiteInferior"].Value.ToString());
                configuracionLimiteEliminar.nLimiteSuperior = Convert.ToDecimal(dtgConfiguracionLimite.CurrentRow.Cells["nLimiteSuperior"].Value.ToString());
                configuracionLimiteEliminar.lVigente = false;
                configuracionLimiteEliminar.nUsuario = idUsuario;
                if (MessageBox.Show("¿Está seguro de eliminar la configuración?", "Eliminar Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtNewConfig = clsCNConfiguracionLimite.CNMantenimientoConfiguracionLimite(configuracionLimiteEliminar);
                    if (dtNewConfig.Rows.Count > 0)
                    {
                        string Msj = dtNewConfig.Rows[0]["cInformación"].ToString();
                        MessageBox.Show(Msj);
                        limpiarControles();
                        cargarDatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione la configuración a eliminar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        #endregion
    }
}