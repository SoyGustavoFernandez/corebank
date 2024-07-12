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
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmMantPeriodoCateOfi : frmBase
    {
        #region Variables globales
        String cTitulo = "Clasificación de categorización";
        clsCNCategoriaOficina cncategoriaoficina = new clsCNCategoriaOficina();
        DataTable dtPeriodoCateOfi = new DataTable();
        DataTable dtEstadosCateOfi = new DataTable();
        int idPeriodoCateOfi;
        Boolean lEditar = false;
        #endregion
        public frmMantPeriodoCateOfi()
        {
            InitializeComponent();
            this.Text = cTitulo;
        }
        #region Eventos
        private void frmMantPeriodoCateOfi_Load(object sender, EventArgs e)
        {
            cargarInicio();
        }
        private void cboPeriodoCateOfi_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPeriodoCateOfi = Convert.ToInt16(cboPeriodoCateOfi.SelectedValue);
            mostrarInformacionCategoria();
            HabilitarControles(1, false);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            limpiarControles();
            HabilitarControles(3,true);
            HabilitarControles(2,false);
            cboEstado.SelectedValue = 2;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            lEditar = true;
            HabilitarControles(3, true);
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GrabarRegistro();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarInicio();
            lEditar = false;
        }
        #endregion
        #region Métodos
        private void cargarInicio()
        {
            cboPeriodoCateOfi.cargarDatos(false);
            idPeriodoCateOfi = Convert.ToInt16(cboPeriodoCateOfi.SelectedValue);
            cargarComboEstados();
            mostrarInformacionCategoria();
            HabilitarControles(1, false);
            
        }
        private void cargarComboEstados(){
            dtEstadosCateOfi = cncategoriaoficina.listarEstadosCateOfi();
            this.cboEstado.DataSource = dtEstadosCateOfi;
            this.cboEstado.ValueMember = Convert.ToString(dtEstadosCateOfi.Columns["idEstadoCateOfi"]);
            this.cboEstado.DisplayMember = Convert.ToString(dtEstadosCateOfi.Columns["cDescripcion"]);
        }
        private void mostrarInformacionCategoria()
        {
            dtPeriodoCateOfi = cncategoriaoficina.obtenerPeriodoCateOfi(false, idPeriodoCateOfi);
            if (dtPeriodoCateOfi.Rows.Count > 0)
            {
                this.txtNombre.Text = Convert.ToString(dtPeriodoCateOfi.Rows[0]["cNombre"]);
                this.cboEstado.SelectedValue = Convert.ToInt16(dtPeriodoCateOfi.Rows[0]["idEstadoCateOfi"]);
                this.dtpFechaInicio.Value = Convert.ToDateTime(dtPeriodoCateOfi.Rows[0]["dFechaInicio"]);
                this.txtDescripcion.Text = Convert.ToString(dtPeriodoCateOfi.Rows[0]["cDescripcion"]);
                this.chbVigente.Checked = Convert.ToBoolean(dtPeriodoCateOfi.Rows[0]["lVigente"]);
            }

        }
        private void HabilitarControles(int nValor, Boolean lValor)
        {
            switch (nValor)
            {
                case 1:
                    this.txtNombre.Enabled = lValor;
                     this.dtpFechaInicio.Enabled = lValor;
                    this.txtDescripcion.Enabled = lValor;
                    this.chbVigente.Enabled = lValor;
                    this.btnNuevo.Enabled = !lValor;
                    this.cboPeriodoCateOfi.Enabled = !lValor;
                    if (dtPeriodoCateOfi.Rows.Count > 0)
                    {
                        if (Convert.ToInt16(dtPeriodoCateOfi.Rows[0]["idEstadoCateOfi"]) == 2)
                        {
                            this.btnEditar.Enabled = !lValor;
                        }
                        else
                        {
                            this.btnEditar.Enabled = lValor;
                        }
                    }
                    else
                    {
                        this.btnEditar.Enabled = lValor;
                    }

                    this.btnGrabar.Enabled = lValor;
                    this.btnCancelar.Enabled = lValor;
                    break;
                case 2:
                    this.cboPeriodoCateOfi.Enabled = lValor;
                    break;
                case 3:
                    this.txtNombre.Enabled = lValor;
                    this.dtpFechaInicio.Enabled = lValor;
                    this.txtDescripcion.Enabled = lValor;
                    this.chbVigente.Enabled = lValor;
                    this.btnNuevo.Enabled = !lValor;
                    this.btnEditar.Enabled = !lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.btnCancelar.Enabled = lValor;
                    break;
                default:
                    break;
            }
        }
        private void limpiarControles()
        {
            cboPeriodoCateOfi.SelectedIndex = -1;
            this.txtDescripcion.Clear();
            this.txtNombre.Clear();
        }
        private void GrabarRegistro()
        {
            if (!validarRegistro())
            {
                return;
            }
            String cNombre = this.txtNombre.Text;
            String cDescripcion = this.txtDescripcion.Text;
            DateTime dFechaInicio = Convert.ToDateTime(this.dtpFechaInicio.Value);
            int idEstadoCateOfi = Convert.ToInt16(this.cboEstado.SelectedValue);
            int idUsuReg = clsVarGlobal.User.idUsuario;
            DateTime dFechaReg = clsVarGlobal.dFecSystem; ;
            Boolean lVigente = chbVigente.Checked;
            if (lEditar)
            {
                DataTable dtResultado = cncategoriaoficina.actualizarPeriodoCateOfi(idPeriodoCateOfi ,cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuReg, dFechaReg, lVigente);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

            }
            else
            {
                DataTable dtResultado = cncategoriaoficina.grabarPeriodoCateOfi(cNombre, cDescripcion, dFechaInicio, idEstadoCateOfi, idUsuReg, dFechaReg, lVigente);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            cargarInicio();
            lEditar = false;
        }
        private Boolean validarRegistro()
        {
            
            if (String.IsNullOrEmpty(this.txtNombre.Text.Trim()))
            {
                MessageBox.Show("Ingrese el nombre de la clasificación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                this.txtNombre.Select();
                return false;
            }
            if (Convert.ToInt16(dtpFechaInicio.Value.Day) != 1 || clsVarGlobal.dFecSystem >= dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha inicio deberá ser el primer día de un mes. También posterior a al fecha actual.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicio.Focus();
                this.dtpFechaInicio.Select();
                return false;
            }
            if (!verificarInicioMesDuplicado(dtpFechaInicio.Value))
            {
                MessageBox.Show("Ya existe la misma fecha de inicio de una clasificación.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicio.Focus();
                this.dtpFechaInicio.Select();
                return false;
            }
            if (String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Ingrese la descripción de la recategorización.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDescripcion.Focus();
                this.txtDescripcion.Select();
                return false;
            }

            return true;
        }
        private Boolean verificarInicioMesDuplicado(DateTime dFecha)
        {
            DataTable dtPeriodos = cncategoriaoficina.obtenerPeriodoCateOfi(false, 0);
            DataTable dtPeriodoActual = cncategoriaoficina.obtenerPeriodoCateOfi(false, idPeriodoCateOfi);
            List<DateTime> dFechas = new List<DateTime>();
            dFechas.Clear();
            int c = 0;
            for (int i = 0; i < dtPeriodos.Rows.Count; i++)
            {
                dFechas.Add(Convert.ToDateTime(dtPeriodos.Rows[i]["dFechaInicio"]));
            }
            if (lEditar == true && dFecha == Convert.ToDateTime(dtPeriodoActual.Rows[0]["dFechaInicio"]))
            {
                return true;
            }
            {
                if (dFechas.Contains(dFecha))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion
    }
}