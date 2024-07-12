using ADM.CapaNegocio;
using EntityLayer;
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

namespace ADM.Presentacion
{
    public partial class frmConfigurarOficinasSegOpt : frmBase
    {
        #region Variables Globales
        clsCNConfigurarSeguroOptativo clsMantenimiento = new clsCNConfigurarSeguroOptativo();
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt = new clsMantenimientoSeguroOptativo();
        public int idTipoSeguro, idAgencia, idUsuario = clsVarGlobal.User.idUsuario, nEdicion = 0;
        public bool lAutorizado;

        #region SeguroOncologico
        clsHistoricoSegurosOptativos objFrmEditarSeguroOptativo = new clsHistoricoSegurosOptativos();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        #endregion

        #endregion

        public frmConfigurarOficinasSegOpt()
        {
            InitializeComponent();
        }

        public frmConfigurarOficinasSegOpt(clsMantenimientoSeguroOptativo _clsDatosSeguroOpt, clsHistoricoSegurosOptativos _objFrmEditarSeguroOptativo)
        {
            InitializeComponent();
            clsDatosSeguroOpt = _clsDatosSeguroOpt;
            objFrmEditarSeguroOptativo = _objFrmEditarSeguroOptativo;
        }

        #region Eventos
        private void frmAgregarOficinasSegOpt_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (clsDatosSeguroOpt.nEstado == 0)
            {
                AgregarDatosAgencia();
            }
            else
            {
                EdidarDatosAgencia();
            }
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona1.SelectedValue);
            cboAgencias1.FiltrarPorZonaAgenciaVigenteTodos(idZonaSeleccionado);
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgencias1.SelectedValue) == 0 && chbAutorizado.Checked == true && clsDatosSeguroOpt.nEstadoAgencia == 2)
            {
                MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos las agencias.", "Agregar sub agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chbAutorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgencias1.SelectedValue) == 0 && chbAutorizado.Checked == true && clsDatosSeguroOpt.nEstadoAgencia == 2)
            {
                MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos las agencias.", "Agregar sub agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(cboAgencias1.SelectedValue) == 0 && chbAutorizado.Checked == false && clsDatosSeguroOpt.nEstadoAgencia == 2 && nEdicion == 1)
            {
                MessageBox.Show("En caso se desmarque esta opción se procederá a RESTABLECER la configuración para todos las agencias.", "Agregar sub agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Metodos
        void CargarDatos()
        {
            if (clsDatosSeguroOpt.nEstado == 0)
            {
                return;
            }
            else
            {
                CargarDatosEditar();
            }
        }

        void CargarDatosEditar()
        {
            chbAutorizado.CheckedChanged -= new EventHandler(chbAutorizado_CheckedChanged);
            cboZona1.SelectedValue        = clsDatosSeguroOpt.idZona;
            cboAgencias1.SelectedValue    = clsDatosSeguroOpt.idAgencia;
            chbAutorizado.Checked         = clsDatosSeguroOpt.lAutorizadoAgencia;
            cboZona1.Enabled              = false;
            cboAgencias1.Enabled          = false;
            nEdicion                      = 1;
            chbAutorizado.CheckedChanged += new EventHandler(chbAutorizado_CheckedChanged);
        }
        void AgregarDatosAgencia()
        {
            idTipoSeguro           = clsDatosSeguroOpt.idTipoSeguro;
            lAutorizado            = chbAutorizado.Checked;
            idAgencia              = Convert.ToInt32(cboAgencias1.SelectedValue);
            
            DataTable dtAgenciaSegOptConfig = clsMantenimiento.CNAgregarOficinaProSegOptConfig(idTipoSeguro, idAgencia, idUsuario, lAutorizado);
            MessageBox.Show(dtAgenciaSegOptConfig.Rows[0]["cMensaje"].ToString(), "Agregar agencia.", MessageBoxButtons.OK, ((int)dtAgenciaSegOptConfig.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            if ((int)dtAgenciaSegOptConfig.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroAgencia("REGISTRO DE AGENCIA AGREGADO", AccionHistorico.AGREGAR, new clsMantenimientoSeguroOptativo { idTipoSeguro = idTipoSeguro, idAgencia = idAgencia, idZona = clsDatosSeguroOpt.idZona, lAutorizadoAgencia = lAutorizado }, objFrmEditarSeguroOptativo);
        
            this.Dispose();
        }

        void EdidarDatosAgencia()
        {
            idTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
            idAgencia    = Convert.ToInt32(cboAgencias1.SelectedValue);
            lAutorizado  = chbAutorizado.Checked;
            
            DataTable dtEditarAgenciaOpatativo = clsMantenimiento.CNEditarOficinaProSegOptConfig(idTipoSeguro, idAgencia, idUsuario, lAutorizado);
            MessageBox.Show(dtEditarAgenciaOpatativo.Rows[0]["cMensaje"].ToString(), "Editar agencia.", MessageBoxButtons.OK, ((int)dtEditarAgenciaOpatativo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            if ((int)dtEditarAgenciaOpatativo.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroAgencia("REGISTRO DE AGENCIA MODIFICADO", AccionHistorico.EDITAR, new clsMantenimientoSeguroOptativo { idTipoSeguro = idTipoSeguro, idAgencia = idAgencia, idZona = clsDatosSeguroOpt.idZona, lAutorizadoAgencia = lAutorizado }, objFrmEditarSeguroOptativo);

            this.Dispose();
        }
        #endregion
    }
}