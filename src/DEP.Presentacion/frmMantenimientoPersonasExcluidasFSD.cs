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
using DEP.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmMantenimientoPersonasExcluidasFSD : frmBase
    {
        #region Variables Globales
        private clsCNFsd objCNFsd = new clsCNFsd();
        private DataTable dtMotivoExclusion;
        private List<clsClienteExcluidoFSD> lstExcluido;
        private clsClienteExcluidoFSD objExcluido;
        private int idCliExcl = 0;
        #endregion

        #region Metodos
        public frmMantenimientoPersonasExcluidasFSD()
        {
            InitializeComponent();
            this.inicializarFormulario();
        }

        public void inicializarFormulario()
        {
            this.objExcluido = new clsClienteExcluidoFSD();
            this.lstExcluido = new List<clsClienteExcluidoFSD>();
            this.bsClienteExcluidoFSD.DataSource = this.lstExcluido;
            this.cargarListaExcluido();
            this.cargarDatos();
        }

        public void cargarListaExcluido()
        {
            this.lstExcluido.Clear();
            this.lstExcluido.AddRange(this.objCNFsd.CNListarClienteExcluidoFSD());
            this.bsClienteExcluidoFSD.ResetBindings(false);
            this.dtgExcluido.Refresh();
        }

        public void cargarDatos()
        {
            this.cboMotivoExclusion.DataSource = null;
            this.dtMotivoExclusion = this.objCNFsd.CNListarMotivoExclusionFSD();
            DataRow newRow = this.dtMotivoExclusion.NewRow();
            newRow["idExcluidoFSD"] = 0;
            newRow["cExcluidoFSD"] = "Seleccione un motivo de exclusión";
            newRow["lVigente"] = false;
            this.dtMotivoExclusion.Rows.Add(newRow);
            this.cboMotivoExclusion.DataSource = this.dtMotivoExclusion;
            this.cboMotivoExclusion.DisplayMember = "cExcluidoFSD";
            this.cboMotivoExclusion.ValueMember = "idExcluidoFSD";
            this.cboMotivoExclusion.SelectedValue = 0;
            this.estadoFormulario(clsAcciones.CANCELAR);
        }

        public bool validarCampos()
        {
            if (Convert.ToInt32(this.cboMotivoExclusion.SelectedValue) == 0)
            {
                MessageBox.Show("Selecione un motivo de exclusión", "Mantenimiento de personas excluidas de FSD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.conBusCliExcluido.idCli == 0)
            {
                MessageBox.Show("Busque un cliente válido", "Mantenimiento de personas excluidas de FSD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToDateTime(this.dtpFechaInicio.Value) > Convert.ToDateTime(this.dtpFechaHasta.Value))
            {
                MessageBox.Show("La fecha inicio no puede ser superior a la fecha Hasta", "Mantenimiento de personas excluidas de FSD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public void estadoFormulario(int idEstado)
        {
            switch (idEstado)
            {
                case clsAcciones.NUEVO:
                    this.conBusCliExcluido.Enabled = true;
                    this.cboMotivoExclusion.Enabled = true;
                    this.dtpFechaInicio.Enabled = true;
                    this.dtpFechaHasta.Enabled = true;
                    this.btnEliminar1.Enabled = false;
                    this.btnNuevo1.Enabled = false;
                    this.btnEditar1.Enabled = false;
                    this.btnGrabar1.Enabled = true;
                    this.btnCancelar1.Enabled = true;
                    this.dtgExcluido.Enabled = false;
                    break;
                case clsAcciones.EDITAR:
                    this.conBusCliExcluido.Enabled = true;
                    this.cboMotivoExclusion.Enabled = true;
                    this.dtpFechaInicio.Enabled = true;
                    this.dtpFechaHasta.Enabled = true;
                    this.btnEliminar1.Enabled = false;
                    this.btnNuevo1.Enabled = false;
                    this.btnEditar1.Enabled = false;
                    this.btnGrabar1.Enabled = true;
                    this.btnCancelar1.Enabled = true;
                    this.dtgExcluido.Enabled = false;
                    break;
                case clsAcciones.GRABAR:
                    this.conBusCliExcluido.Enabled = false;
                    this.cboMotivoExclusion.Enabled = false;
                    this.dtpFechaInicio.Enabled = false;
                    this.dtpFechaHasta.Enabled = false;
                    this.btnEliminar1.Enabled = true;
                    this.btnNuevo1.Enabled = true;
                    this.btnEditar1.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    this.dtgExcluido.Enabled = true;
                    break;
                default:
                    this.conBusCliExcluido.Enabled = false;
                    this.cboMotivoExclusion.Enabled = false;
                    this.dtpFechaInicio.Enabled = false;
                    this.dtpFechaHasta.Enabled = false;
                    this.btnEliminar1.Enabled = true;
                    this.btnNuevo1.Enabled = true;
                    this.btnEditar1.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    this.dtgExcluido.Enabled = true;
                    break;
            }
        }
        #endregion

        #region Eventos
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar a: " + this.conBusCliExcluido.txtNombre.Text, "ELIMINADO CORRECTAMENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            clsRespuestaServidor objRespuesta = this.objCNFsd.CNRegistrarClienteExcluidoFSD(idCliExcl,
                Convert.ToInt32(this.conBusCliExcluido.idCli),
                Convert.ToInt32(this.cboMotivoExclusion.SelectedValue),
                Convert.ToDateTime(this.dtpFechaInicio.Value),
                Convert.ToDateTime(this.dtpFechaHasta.Value), false);
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, "ELIMINADO CORRECTAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.estadoFormulario(clsAcciones.GRABAR);
                this.dtgExcluido.SelectionChanged -= new System.EventHandler(this.dtgExcluido_SelectionChanged);
                this.cargarListaExcluido();
                this.dtgExcluido.SelectionChanged += new System.EventHandler(this.dtgExcluido_SelectionChanged);
                this.dtgExcluido_SelectionChanged(this, null);
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.idCliExcl = 0;
            this.conBusCliExcluido.limpiarControles();
            this.cboMotivoExclusion.SelectedValue = 0;
            this.dtpFechaInicio.Value = DateTime.Now;
            this.dtpFechaHasta.Value = DateTime.Now;
            this.estadoFormulario(clsAcciones.NUEVO);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.estadoFormulario(clsAcciones.EDITAR);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!this.validarCampos())
            {
                return;
            }
            clsRespuestaServidor objRespuesta = this.objCNFsd.CNRegistrarClienteExcluidoFSD(idCliExcl,
                Convert.ToInt32(this.conBusCliExcluido.idCli),
                Convert.ToInt32(this.cboMotivoExclusion.SelectedValue),
                Convert.ToDateTime(this.dtpFechaInicio.Value),
                Convert.ToDateTime(this.dtpFechaHasta.Value), true);
            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.estadoFormulario(clsAcciones.GRABAR);
                this.dtgExcluido.SelectionChanged -= new System.EventHandler(this.dtgExcluido_SelectionChanged);
                this.cargarListaExcluido();
                this.dtgExcluido.SelectionChanged += new System.EventHandler(this.dtgExcluido_SelectionChanged);
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, "ERROR DE GRABADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.estadoFormulario(clsAcciones.CANCELAR);
            this.dtgExcluido_SelectionChanged(this, EventArgs.Empty);
        }

        private void dtgExcluido_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgExcluido.SelectedRows.Count > 0)
            {
                int nIndice = this.dtgExcluido.SelectedRows[0].Index;
                this.objExcluido = this.lstExcluido[nIndice];
                this.idCliExcl = this.objExcluido.idCliExcl;
                this.conBusCliExcluido.CargardatosCli(this.objExcluido.idCli);
                this.cboMotivoExclusion.SelectedValue = this.objExcluido.idExcluidoFSD;
                this.dtpFechaInicio.Value = this.objExcluido.dFechaInicio;
                this.dtpFechaHasta.Value = this.objExcluido.dFechaFinal;
            }
        }

        private void frmMantenimientoPersonasExcluidasFSD_Load(object sender, EventArgs e)
        {
            this.dtgExcluido.SelectionChanged += new System.EventHandler(this.dtgExcluido_SelectionChanged);
            this.dtgExcluido_SelectionChanged(this, EventArgs.Empty);
        }
        #endregion
    }
}
