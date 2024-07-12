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
    public partial class frmMantenimientoTipoAfec : frmBase
    {
        #region Variables Globales
        private clsCNMantenimientoTablas cnmantenimientotablas = new clsCNMantenimientoTablas();
        private DataTable dtMantenimiento = new DataTable();
        private int idMovimiento;
        private bool lCombo = false;
        private string cTituloMensaje = "Mantenimiento tipos de afectación";
        #endregion
        #region Eventos
        public frmMantenimientoTipoAfec()
        {
            InitializeComponent();
        }
        private void frmMantenimientoTipoAfec_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarMeses();
            listarMantenimiento();
            habilitarControles(true);
        }
        private void frmMantenimientoTipoAfec_Shown(object sender, EventArgs e)
        {
            idMovimiento = Convert.ToInt32(cboMantenimiento.SelectedValue);
            lCombo = true;
            cargarDetalle(idMovimiento);
        }
        private void cboMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lCombo)
            {
                idMovimiento = Convert.ToInt32(cboMantenimiento.SelectedValue);
                cargarDetalle(idMovimiento);
            }
            habilitarControles(true);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarMovimiento();
            habilitarControles(false);
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            actualizarMantenimiento();
            listarMantenimiento();
            habilitarControles(true);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            listarMantenimiento();
            habilitarControles(true);
        }
        #endregion
        #region Metodos
        private void listarMantenimiento()
        {
            dtMantenimiento = cnmantenimientotablas.ListarTiposAfectacion();
            cboMantenimiento.DataSource = dtMantenimiento;
            cboMantenimiento.ValueMember = dtMantenimiento.Columns[0].ToString();
            cboMantenimiento.DisplayMember = dtMantenimiento.Columns[1].ToString();
        }
        private void cargarDetalle(int idMovimiento)
        {
            txtDescripcion.Text = Convert.ToString(cboMantenimiento.Text);
            txtCodigo.Text = Convert.ToString(cboMantenimiento.SelectedValue);
            txtAbreviatura.Text = Convert.ToString(dtMantenimiento.Rows[buscarFila(idMovimiento)]["cAbreviatura"].ToString());
            cboMesInicio.SelectedValue = dtMantenimiento.Rows[buscarFila(idMovimiento)]["cMesInicio"].ToString();
            cboMesFin.SelectedValue = dtMantenimiento.Rows[buscarFila(idMovimiento)]["cMesFin"].ToString();
        }
        private int buscarFila(int idMovimiento)
        {
            int nFila = 0;
            for (int i = 0; i < dtMantenimiento.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtMantenimiento.Rows[i]["idLimAplicacion"]) == idMovimiento)
                {
                    nFila = i;
                }
            }
            return nFila;
        }
        private void cargarMeses()
        {
            Dictionary<string, string> cDicMes = new Dictionary<string, string>();
            cDicMes.Add("0", "No aplica");
            cDicMes.Add("X", "Mes en Transcurso");
            cDicMes.Add("1", "Enero");
            cDicMes.Add("2", "Febrero");
            cDicMes.Add("3", "Marzo");
            cDicMes.Add("4", "Abril");
            cDicMes.Add("5", "Mayo");
            cDicMes.Add("6", "Junio");
            cDicMes.Add("7", "Julio");
            cDicMes.Add("8", "Agosto");
            cDicMes.Add("9", "Setiembre");
            cDicMes.Add("10", "Octubre");
            cDicMes.Add("11", "Noviembre");
            cDicMes.Add("12", "Diciembre");
            cboMesInicio.DataSource = new BindingSource(cDicMes, null);
            cboMesInicio.DisplayMember = "Value";
            cboMesInicio.ValueMember = "Key";

            cboMesFin.DataSource = new BindingSource(cDicMes, null);
            cboMesFin.DisplayMember = "Value";
            cboMesFin.ValueMember = "Key";
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
                txtAbreviatura.Enabled = !val;
                btnCancelar.Enabled = !val;
                btnEditar.Enabled = val;
                btnGrabar.Enabled = !val;
                cboMesInicio.Enabled = !val;
                cboMesFin.Enabled = !val;
            }
            else
            {
                txtDescripcion.Enabled = !val;
                txtDescripcion.ReadOnly = val;
                txtAbreviatura.Enabled = !val;
                txtAbreviatura.ReadOnly = val;
                btnCancelar.Enabled = !val;
                btnEditar.Enabled = val;
                btnGrabar.Enabled = !val;
                cboMesInicio.Enabled = !val;
                cboMesFin.Enabled = !val;
            }
        }
        private void actualizarMantenimiento()
        {
            int idLimAplicacion = idMovimiento;
            string cDescripcion = Convert.ToString(txtDescripcion.Text);
            string cAbreviatura = Convert.ToString(txtAbreviatura.Text);
            string cMesInicio = cboMesInicio.SelectedValue.ToString();
            string cMesFin = cboMesFin.SelectedValue.ToString();
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;

            DataTable dtResultado = cnmantenimientotablas.ActualizarTiposAfectacion(idLimAplicacion, cDescripcion, cAbreviatura, cMesInicio, cMesFin, idUsuMod, dFechaMod);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        private void limpiarDatos()
        {
            cboMantenimiento.SelectedValue = -1;
            txtDescripcion.Clear();
            txtAbreviatura.Clear();
            cboMesInicio.SelectedValue = -1;
            cboMesFin.SelectedValue = -1;
            habilitarControles(false);
            cboMantenimiento.Enabled = false;
            txtDescripcion.Enabled = true;
            txtDescripcion.ReadOnly = false;
            txtAbreviatura.Enabled = true;
            txtAbreviatura.ReadOnly = false;
        }
        #endregion
    }
}
