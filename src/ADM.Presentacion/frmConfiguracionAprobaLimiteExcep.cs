using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmConfiguracionAprobaLimiteExcep : frmBase
    {

        clsCNConfiguracionLimiteAprobacionExcepcion clsCNConfigLimiteAprobacionExcepcion = new clsCNConfiguracionLimiteAprobacionExcepcion();

        int idConfigAproba = 0;

        const string mensajeTitulo = "Mensaje";
        const string mensajeInformacion = "Información";
        public int idCli;
        public frmConfiguracionAprobaLimiteExcep()
        {
            InitializeComponent();
            txtUsuario.Enabled = false;
        }

        private void frmConfiguracionAprobaLimiteExcep_Load(object sender, EventArgs e)
        {
            CargarDatos();          
        }


        private void CargarDatos()
        {
            DataTable dtConfigAprobaLimiteExcep = new DataTable();
            dtConfigAprobaLimiteExcep = clsCNConfigLimiteAprobacionExcepcion.CNListarConfigAprobaLimiteExcep();
            BindingSource bsConfigAprobaLimiteExcep = new BindingSource();
            bsConfigAprobaLimiteExcep.DataSource = dtConfigAprobaLimiteExcep;
            dtgConfigAprobaLimiteExcep.DataSource = bsConfigAprobaLimiteExcep.DataSource;
            dtgConfigAprobaLimiteExcep.ClearSelection();
            FormatearDataGrid();
            EstadosIniciales();

        }
        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn item in dtgConfigAprobaLimiteExcep.Columns)
            {
                item.Visible = false;
            }

            dtgConfigAprobaLimiteExcep.Columns["cWinUser"].Visible = true;
            dtgConfigAprobaLimiteExcep.Columns["cPerfil"].Visible = true;
            dtgConfigAprobaLimiteExcep.Columns["cDesZona"].Visible = true;
            dtgConfigAprobaLimiteExcep.Columns["cNombreAge"].Visible = true;

            dtgConfigAprobaLimiteExcep.Columns["cWinUser"].HeaderText = "Usuario";
            dtgConfigAprobaLimiteExcep.Columns["cPerfil"].HeaderText = "Perfil";
            dtgConfigAprobaLimiteExcep.Columns["cDesZona"].HeaderText = "Región";
            dtgConfigAprobaLimiteExcep.Columns["cNombreAge"].HeaderText = "Agencia";


            dtgConfigAprobaLimiteExcep.Columns["cWinUser"].DisplayIndex = 0;
            dtgConfigAprobaLimiteExcep.Columns["cPerfil"].DisplayIndex = 1;
            dtgConfigAprobaLimiteExcep.Columns["cDesZona"].DisplayIndex = 2;
            dtgConfigAprobaLimiteExcep.Columns["cNombreAge"].DisplayIndex = 3;


            dtgConfigAprobaLimiteExcep.Columns["cWinUser"].Width = 100;
            dtgConfigAprobaLimiteExcep.Columns["cPerfil"].Width = 120;
            dtgConfigAprobaLimiteExcep.Columns["cDesZona"].Width = 110;
            dtgConfigAprobaLimiteExcep.Columns["cNombreAge"].Width = 100;
            dtgConfigAprobaLimiteExcep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgConfigAprobaLimiteExcep.MultiSelect = false;
            dtgConfigAprobaLimiteExcep.ClearSelection();
        }
        private void CargarControles(clsConfigAprobaLimiteExcepc configLimiteAprobaExcep)
        {
            cboListaPerfil.SelectedValue = configLimiteAprobaExcep.idPerfil;
            cboZona.SelectedValue = configLimiteAprobaExcep.idZona;
            cboAgencias.FiltrarPorZonaTodos(configLimiteAprobaExcep.idZona);
            cboAgencias.SelectedValue = configLimiteAprobaExcep.idAgencia;
            txtIdUsuario.Text = configLimiteAprobaExcep.idUsuario.ToString();
            txtUsuario.Text = configLimiteAprobaExcep.cWinUser.ToString();
            btnBusqueda.Visible = false;
        }

        private void EstadosIniciales()
        {
            CambiarAgenciasPorZonas();
            cboListaPerfil.CargarPerfilOrdenadoAsc();
            CargarZonas();
            LimpiarControles1();
        }
        private void CambiarAgenciasPorZonas()
        {
            var idZona = Convert.ToInt32(cboZona.SelectedValue);
            cboAgencias.FiltrarPorZonaTodos(idZona);
            cboAgencias.SelectedValue = 0;
        }
        private void CargarZonas()
        {
            cboZona.cargarZona(true, false);
        }
        private bool ValidarControles()
        {

            bool valid = true;

            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            string usuario = txtUsuario.Text;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            string cPerfil = cboListaPerfil.Text;

            List<string> errores = new List<string>();

            DataTable dtValidacion = clsCNConfigLimiteAprobacionExcepcion.ValidarConfigAprobLimite(idAgencia, usuario, cPerfil, idZona, idConfigAproba);
            string cResultado = dtValidacion.Rows[0]["cError"].ToString();

            if (!string.IsNullOrEmpty(cResultado))
            {
                string[] lstErrores = cResultado.Split(',');
                string cMensaje = string.Join(Environment.NewLine, lstErrores);
                MostrarMensaje(cMensaje, mensajeTitulo, mensajeInformacion);
                return false;
            }

            return valid;

        }


        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarAgenciasPorZonas();
        }
        private void cboListaPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idPerfil = Convert.ToInt32(cboListaPerfil.SelectedValue);


            switch (idPerfil)
            {
                case 93:
                    cboAgencias.SelectedValue = 0;
                    cboAgencias.Enabled = false;
                    break;
                case 172:
                    cboZona.SelectedValue = 0;
                    cboAgencias.SelectedValue = 0;
                    cboZona.Enabled = false;
                    cboAgencias.Enabled = false;
                    break;
                default:
                    cboZona.Enabled = true;
                    cboAgencias.Enabled = true;
                    break;
            }

            if(idPerfil == 93)
            {
                cboAgencias.SelectedValue = 0;
                cboAgencias.Enabled = false;               
            }

            if(idPerfil == 172)
            {
                cboZona.SelectedValue = 0;
                cboZona.Enabled = false;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clsConfigAprobaLimiteExcepc configLimiteAprobaExcep = new clsConfigAprobaLimiteExcepc();

            configLimiteAprobaExcep.idConfigAproba = 0;
            configLimiteAprobaExcep.idUsuario = 0;
            configLimiteAprobaExcep.idPerfil = -1;
            configLimiteAprobaExcep.idZona = 0;
            configLimiteAprobaExcep.idAgencia = 0;
            configLimiteAprobaExcep.lVigente = false;
            configLimiteAprobaExcep.cWinUser = "";
            idConfigAproba = configLimiteAprobaExcep.idConfigAproba;

            btnBusqueda.Visible = true; 

            CargarControles(configLimiteAprobaExcep);           
            CambiarAgenciasPorZonas();
            LimpiarControles2();
            CombosPorDefecto();


        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {

            var indiceAgencia = cboAgencias.SelectedIndex;
            var indiceZona = cboZona.SelectedIndex;

            if (ValidarControles())
            {
                clsConfigAprobaLimiteExcepc configuracionAprobaLimitExcep = new clsConfigAprobaLimiteExcepc();
                configuracionAprobaLimitExcep.idConfigAproba = idConfigAproba;
                configuracionAprobaLimitExcep.idUsuario = Convert.ToInt32(txtIdUsuario.Text); 
                configuracionAprobaLimitExcep.idPerfil = Convert.ToInt32(cboListaPerfil.SelectedValue.ToString());
                configuracionAprobaLimitExcep.idZona= Convert.ToInt32(cboZona.SelectedValue.ToString());
                configuracionAprobaLimitExcep.idAgencia = Convert.ToInt32(cboAgencias.SelectedValue.ToString());
                configuracionAprobaLimitExcep.lVigente = true;
                configuracionAprobaLimitExcep.nUsuReg = clsVarGlobal.User.idCli;
                

                if (MessageBox.Show("¿Está seguro de guardar la configuración?", "Guardar Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtNewConfig = clsCNConfigLimiteAprobacionExcepcion.CNMantenimientoConfiguracionAprobaLimiteExcep(configuracionAprobaLimitExcep);
                    if (dtNewConfig.Rows.Count > 0)
                    {
                        string Msj = dtNewConfig.Rows[0]["cInformación"].ToString();
                        MessageBox.Show(Msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        CargarDatos();
                        LimpiarControles1();
                    }
                }


            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            clsConfigAprobaLimiteExcepc configAprobaLimitExcep = new clsConfigAprobaLimiteExcepc();

            if (dtgConfigAprobaLimiteExcep.SelectedRows.Count > 0)
            {
                configAprobaLimitExcep.idConfigAproba = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idConfigAproba"].Value.ToString());              
                configAprobaLimitExcep.idUsuario = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idUsuario"].Value.ToString());
                configAprobaLimitExcep.cWinUser = dtgConfigAprobaLimiteExcep.CurrentRow.Cells["cWinUser"].Value.ToString();
                configAprobaLimitExcep.idPerfil = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idPerfil"].Value.ToString());

                configAprobaLimitExcep.idZona = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idZona"].Value.ToString());

                configAprobaLimitExcep.idAgencia = (dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idAgencia"].Value.ToString() == "") ? 0: Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idAgencia"].Value.ToString());


                configAprobaLimitExcep.nUsuReg = clsVarGlobal.User.idUsuario;
                idConfigAproba = configAprobaLimitExcep.idConfigAproba;

                CargarControles(configAprobaLimitExcep);

                if(configAprobaLimitExcep.idPerfil==93 )
                {
                    cboZona.Enabled = true;                   //
                }

                LimpiarControles2();

            } else
            {
                MessageBox.Show("Selecione la configuración a editar");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBusqueda.Visible = true;
            CargarDatos();
            LimpiarControles3();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsConfigAprobaLimiteExcepc configAprobaLimiteExcepc = new clsConfigAprobaLimiteExcepc();

            if(dtgConfigAprobaLimiteExcep.SelectedRows.Count > 0)
            {
                configAprobaLimiteExcepc.idConfigAproba = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idConfigAproba"].Value.ToString());
                configAprobaLimiteExcepc.idUsuario = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idUsuario"].Value.ToString());
                configAprobaLimiteExcepc.idPerfil = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idPerfil"].Value.ToString());

                configAprobaLimiteExcepc.idZona = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idZona"].Value.ToString());

                configAprobaLimiteExcepc.idAgencia = Convert.ToInt32(dtgConfigAprobaLimiteExcep.CurrentRow.Cells["idAgencia"].Value.ToString());

                configAprobaLimiteExcepc.nUsuReg = clsVarGlobal.User.idUsuario;

                idConfigAproba = configAprobaLimiteExcepc.idConfigAproba;

                configAprobaLimiteExcepc.lVigente = false;

                if (MessageBox.Show("¿Está seguro de eliminar la configuración?", "Eliminar Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DataTable dtNewConfig = clsCNConfigLimiteAprobacionExcepcion.CNMantenimientoConfiguracionAprobaLimiteExcep(configAprobaLimiteExcepc);
                    if (dtNewConfig.Rows.Count > 0)
                    {
                        string Msj = dtNewConfig.Rows[0]["cInformación"].ToString();                       
                        MostrarMensaje(Msj, mensajeTitulo, mensajeInformacion);
                        LimpiarControles1();
                        CargarDatos();
                    }
                }

            }

        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            var idPerfil = cboListaPerfil.SelectedValue;
            var idZona = cboZona.SelectedValue;
            var idAgencia = cboAgencias.SelectedValue;
            var usuario = txtIdUsuario.Text;

            clsConfigAprobaLimiteExcepc configuracionAprobaLimitExcep = new clsConfigAprobaLimiteExcepc();

            configuracionAprobaLimitExcep.idPerfil = Convert.ToInt32(idPerfil);
            configuracionAprobaLimitExcep.idZona = Convert.ToInt32(idZona);
            configuracionAprobaLimitExcep.idAgencia = Convert.ToInt32(idAgencia);
            if (usuario == "")
                configuracionAprobaLimitExcep.idUsuario = 0;            
            else
            configuracionAprobaLimitExcep.idUsuario = Convert.ToInt32(usuario);

            DataTable dtNewConfig = clsCNConfigLimiteAprobacionExcepcion.CNBuscarConfiguracionAprobaLimiteExcep(configuracionAprobaLimitExcep);
            dtgConfigAprobaLimiteExcep.DataSource = dtNewConfig;

        }


        private void MostrarMensaje(string mensaje, string titulo, string tipo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void LimpiarControles1()
        {
            btnGrabar.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            txtIdUsuario.Text = "";
            txtUsuario.Text = "";

        }
        private void LimpiarControles2()
        {
            btnGrabar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;            

        }
        private void LimpiarControles3()
        { 
            btnEliminar.Enabled = true;
        }
        private void CombosPorDefecto()
        {
            cboZona.SelectedIndex = 0;
            cboListaPerfil.SelectedIndex = 0;
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            frmBusUsuario frmBusUsuario = new frmBusUsuario();
            frmBusUsuario.ShowDialog();

            if (frmBusUsuario.idUsuario!=0)
            {
                int codUser= frmBusUsuario.idUsuario;
        
            btnGrabar.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
                CargardatosCli(codUser);
            }
            else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
            {
                txtIdUsuario.Enabled = true; 
            }
            idCli = txtIdUsuario.Text == "" ? 0 : Convert.ToInt32(txtIdUsuario.Text);
            txtUsuario.Enabled = false;
        }

        public void CargardatosCli(int codUser)
        {
            DataTable tablaUser = clsCNConfigLimiteAprobacionExcepcion.CNBuscarUsuarioXUsuario(codUser);

            if (tablaUser.Rows.Count > 0)
            {
                txtIdUsuario.Text = tablaUser.Rows[0]["idUsuario"].ToString();
                txtUsuario.Text = Convert.ToString(tablaUser.Rows[0]["cWinUser"]);
                this.idCli = txtIdUsuario.Text == "" ? 0 : Convert.ToInt32(txtIdUsuario.Text);
            }
            else if (tablaUser.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún usuario a", "Buscar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdUsuario.Text = "";
                txtIdUsuario.Focus();
                txtUsuario.Text = "";
                this.idCli = 0;
            }
            txtUsuario.Enabled = false;
        }


        private void txtIdUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//solo enter 
            { 
                if (txtIdUsuario.Text != "") { 
                    CargardatosCli(Convert.ToInt32(txtIdUsuario.Text));
                 }
                else
                {
                    txtUsuario.Text = "";
                }
            }
            
        }
    }

}
