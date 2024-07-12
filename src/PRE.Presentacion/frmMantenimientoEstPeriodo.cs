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
using GEN.CapaNegocio;
using PRE.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmMantenimientoEstPeriodo : frmBase
    {
        #region Variables Globales
        private clsCNMantenimientoTablas cnmantenimientotablas = new clsCNMantenimientoTablas();
        private int idMovimiento;
        private string cTituloMensaje = "Mantenimiento estados de periodo";
        #endregion
        #region Eventos
        public frmMantenimientoEstPeriodo()
        {
            InitializeComponent();
        }
        private void frmMantenimientoEstPeriodo_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            listarMantenimiento();
            habilitarControles(true);
        }
        private void cboMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDetalle();
            habilitarControles(true);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listarMantenimiento();
            habilitarControles(true);
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            actualizarMantenimiento();
            listarMantenimiento();
            habilitarControles(true);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarMovimiento();
            habilitarControles(false);
        }
        #endregion
        #region Metodos
        private void listarMantenimiento()
        {
            DataTable dtMantenimiento = cnmantenimientotablas.ListarEstadosPeriodo();
            cboMantenimiento.DataSource = dtMantenimiento;
            cboMantenimiento.ValueMember = dtMantenimiento.Columns[0].ToString();
            cboMantenimiento.DisplayMember = dtMantenimiento.Columns[1].ToString();
        }
        private void cargarDetalle()
        {
            txtDescripcion.Text = Convert.ToString(cboMantenimiento.Text);
            txtCodigo.Text = Convert.ToString(cboMantenimiento.SelectedValue);
        }
        private void editarMovimiento()
        {
            idMovimiento = Convert.ToInt32(cboMantenimiento.SelectedValue);
        }
        private void habilitarControles(bool val)
        {
            if (val)
            {
                txtDescripcion.Enabled = !val;
                btnCancelar.Enabled = !val;
                btnEditar.Enabled = val;
                btnGrabar.Enabled = !val;
            }
            else
            {
                txtDescripcion.Enabled = !val;
                txtDescripcion.ReadOnly = val;
                btnCancelar.Enabled = !val;
                btnEditar.Enabled = val;
                btnGrabar.Enabled = !val;
            }
        }
        private void actualizarMantenimiento()
        {
            int idEstadoPresupuesto = idMovimiento;
            string cDescripcion = Convert.ToString(txtDescripcion.Text);
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            DataTable dtResultado = cnmantenimientotablas.ActualizarEstadosPeriodo(idEstadoPresupuesto, cDescripcion, idUsuMod, dFechaMod);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        #endregion
    }
}
