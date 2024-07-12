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
    public partial class frmConfigurarProductosSegOpt : frmBase
    {
        #region Variables Globales
        clsCNConfigurarSeguroOptativo clsMantenimiento    = new clsCNConfigurarSeguroOptativo();
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt  = new clsMantenimientoSeguroOptativo();
        public int idSubProducto, idTipoSeguro, idUsuario = clsVarGlobal.User.idUsuario;
        public bool lAutorizado;

        #region SeguroOncologico
        clsHistoricoSegurosOptativos objFrmEditarSeguroOptativo = new clsHistoricoSegurosOptativos();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        #endregion

        #endregion

        public frmConfigurarProductosSegOpt()
        {
            InitializeComponent();
        }

        public frmConfigurarProductosSegOpt(clsMantenimientoSeguroOptativo _clsDatosSeguroOpt, clsHistoricoSegurosOptativos _objFrmEditarSeguroOptativo)
        {
            InitializeComponent();
            clsDatosSeguroOpt = _clsDatosSeguroOpt;
            objFrmEditarSeguroOptativo = _objFrmEditarSeguroOptativo;
        }

        #region Eventos
        private void frmAgregarProductosSegOpt_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (clsDatosSeguroOpt.nEstado == 0)
            {
                AgregarDatosProducto();
            }
            else
            {
                EditarDatosProducto();
            }
        }

        private void chbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodos.Checked == true)
            {
                conProducto1.Enabled = false;
                conProducto1.cboTipoCredito.SelectedValue = 0;
                idSubProducto = 0;
            }
            else
            {
                conProducto1.Enabled = true;
            }
        }

        private void conProducto1_ChangeProducto(object sender, EventArgs e)
        {
            if (Convert.ToInt32(conProducto1.cboTipoCredito.SelectedValue) > 0)
            {
                chbTodos.Enabled = false;
            }
            else
            {
                chbTodos.Enabled = true;
            }
        }

        private void chbAutorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutorizado.Checked == true && chbTodos.Checked == true && clsDatosSeguroOpt.nEstadoProducto == 2)
            {
                MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos los productos.", "Agregar sub producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chbAutorizado.Checked == false && chbTodos.Checked == true && clsDatosSeguroOpt.nEstadoProducto == 2)
            {
                MessageBox.Show("En caso se desmarque esta opción se procederá a RESTABLECER la configuración para todos los productos.", "Agregar sub producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            conProducto1.cboTipoCredito.SelectedValue    = clsDatosSeguroOpt.idTipoCredito;
            conProducto1.cboSubTipoCredito.SelectedValue = clsDatosSeguroOpt.idSubTipo;
            conProducto1.cboProducto.SelectedValue       = clsDatosSeguroOpt.idProducto;
            conProducto1.cboSubProducto.SelectedValue    = clsDatosSeguroOpt.idSubProducto;
            chbAutorizado.Checked                        = clsDatosSeguroOpt.lAutorizadoProducto;
            conProducto1.Enabled                         = false;

            if (clsDatosSeguroOpt.idSubProducto == 0)
            {
                conProducto1.cboSubProducto.CargarProductoModNivelTodos(1, 4);
                conProducto1.cboSubProducto.SelectedValue = 0;
                chbTodos.Checked = true;
                chbTodos.Enabled = false;
            }
        }
        void AgregarDatosProducto()
        {
            idTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
            lAutorizado  = chbAutorizado.Checked;

            if (chbTodos.Checked == false)
            {
                if (!conProducto1.validarSeleccion())
                {
                    return;
                }
                idSubProducto = Convert.ToInt32(conProducto1.cboSubProducto.SelectedValue);
            }
            DataTable dtSubProSegOptConfig = clsMantenimiento.CNAgregarSubProSegOptConfig(idTipoSeguro, idSubProducto, idUsuario, lAutorizado);
            MessageBox.Show(dtSubProSegOptConfig.Rows[0]["cMensaje"].ToString(), "Agregar sub producto", MessageBoxButtons.OK, ((int)dtSubProSegOptConfig.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            if ((int)dtSubProSegOptConfig.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroProducto("REGISTRO DE PRODUCTO AGREGADO", AccionHistorico.AGREGAR, new clsMantenimientoSeguroOptativo
                {
                    idTipoSeguro = idTipoSeguro,
                    idSubProducto = idSubProducto,
                    lAutorizadoProducto = chbAutorizado.Checked
                }, objFrmEditarSeguroOptativo);

            this.Dispose();
        }

        void EditarDatosProducto()

        {
            idTipoSeguro  = clsDatosSeguroOpt.idTipoSeguro;
            idSubProducto = Convert.ToInt32(conProducto1.cboSubProducto.SelectedValue);
            lAutorizado   = chbAutorizado.Checked;

            DataTable dtEditarSegOpatativo = clsMantenimiento.CNEditarSubProSegOptConfig(idTipoSeguro, idSubProducto, idUsuario, lAutorizado);
            MessageBox.Show(dtEditarSegOpatativo.Rows[0]["cMensaje"].ToString(), "Editar sub producto", MessageBoxButtons.OK, ((int)dtEditarSegOpatativo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            if ((int)dtEditarSegOpatativo.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroProducto("REGISTRO DE PRODUCTO MODIFICADO", AccionHistorico.EDITAR, new clsMantenimientoSeguroOptativo
                {
                    idTipoSeguro = idTipoSeguro,
                    idSubProducto = idSubProducto,
                    lAutorizadoProducto = chbAutorizado.Checked
                }, objFrmEditarSeguroOptativo);

            this.Dispose();
        }
        #endregion
    }
}
