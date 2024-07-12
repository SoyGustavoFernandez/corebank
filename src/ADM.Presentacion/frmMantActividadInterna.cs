using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CLI.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantActividadInterna : frmBase
    {
        #region Variable Globales

        Transaccion operacion = Transaccion.Selecciona;
        clsCNListaActivEco cnactividad = new clsCNListaActivEco();

        #endregion

        public frmMantActividadInterna()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            this.cboActividadEco.CargarActivEconomica(0);
            cargarActividadesInternas();
            cargarCategoria();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarcontroles();
            habilitarcontroles(true);
            this.cboActividadEco.SelectedValue = 0;
            txtDescripcion.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.cboActividadInterna1.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            operacion = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarcontroles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);
            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Selecciona;
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            this.cargarActividadesInternas();
            habilitarcontroles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var cDescripcion = txtDescripcion.Text.Trim();
                var idActividad = Convert.ToInt32(this.cboCIIU.SelectedValue);
                var idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);

                string cmensaje = "";
                DataTable dtResultado;
                if (operacion == Transaccion.Nuevo)
                {
                    dtResultado=cnactividad.CNInsertarActividadInterna(cDescripcion, idActividad, clsVarGlobal.User.idUsuario, rbtActivo.Checked, idCategoria);

                    cmensaje = "Se registro correctamente los datos ingresados";
                }
                else
                {
                    dtResultado=cnactividad.CNActualizarActividadInterna(Convert.ToInt32(cboActividadInterna1.SelectedValue), cDescripcion, idActividad, clsVarGlobal.User.idUsuario, rbtActivo.Checked, idCategoria);
                    cmensaje = "Se actualizaron correctamente los datos ingresados";
                }

                if ((int)dtResultado.Rows[0][0]==1)
                {
                    MessageBox.Show("Error al registrar los datos. \n comuníquese con el área de T.I.", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else //igual a 0
                {
                    MessageBox.Show(cmensaje, "Registro de Actividad Interna", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                               

                btnEditar1.Enabled = true;
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                this.cboActividadInterna1.Update();
                this.cargarActividadesInternas();
                habilitarcontroles(false);
                operacion = Transaccion.Selecciona;
            }
        }

        private void cboActividadInterna1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarActividadesInternas();
        }

        private void cboActividadEco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividadEco.SelectedIndex > 0)
            {
                this.cboGrupoCiiu.CargarActivEconomica((int)cboActividadEco.SelectedValue);                
            }
            else
            {
                cboGrupoCiiu.SelectedValue = 0;                
            }

            if (operacion== Transaccion.Selecciona)
            {
                cboGrupoCiiu.Enabled = false;
                cboCIIU.Enabled = false;
            }
            else
            {
                cboGrupoCiiu.Enabled = true;
                cboCIIU.Enabled = true;
            }
        }

        private void cboGrupoCiiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoCiiu.SelectedIndex > -1)
            {
                if (cboGrupoCiiu.SelectedValue is DataRowView) return;

                this.cboCIIU.CargarActivEconomica((int)cboGrupoCiiu.SelectedValue);
            }
            else
            {
                cboCIIU.SelectedValue = 0;
            }
            if (operacion == Transaccion.Selecciona)
            {
                cboGrupoCiiu.Enabled = false;
                cboCIIU.Enabled = false;
            }
            else
            {
                cboGrupoCiiu.Enabled = true;
                cboCIIU.Enabled = true;
            }
        }

        private void cboActividadEco_MouseHover(object sender, EventArgs e)
        {
            this.ttpMensaje.ToolTipTitle = "";
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 1000;
            this.ttpMensaje.ReshowDelay = 0;

            this.ttpMensaje.SetToolTip(this.cboActividadEco, this.cboActividadEco.Text);
        }

        private void cboGrupoCiiu_MouseHover(object sender, EventArgs e)
        {
            this.ttpMensaje.ToolTipTitle = "";
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 1000;
            this.ttpMensaje.ReshowDelay = 0;

            this.ttpMensaje.SetToolTip(this.cboGrupoCiiu, this.cboGrupoCiiu.Text);
        }

        private void cboCIIU_MouseHover(object sender, EventArgs e)
        {
            this.ttpMensaje.ToolTipTitle = "CIIU:";
            this.ttpMensaje.UseFading = true;
            this.ttpMensaje.UseAnimation = true;
            this.ttpMensaje.IsBalloon = true;
            this.ttpMensaje.ShowAlways = true;
            this.ttpMensaje.AutoPopDelay = 5000;
            this.ttpMensaje.InitialDelay = 1000;
            this.ttpMensaje.ReshowDelay = 0;

            this.ttpMensaje.SetToolTip(this.cboCIIU, this.cboCIIU.Text);          
        }

        #endregion

        #region Métodos

        private bool validar()
        {   
            bool lValida = false;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una desripción por favor", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lValida;
            }

            if (cboCIIU.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una actividad por favor", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCIIU.Focus();
                return lValida;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado activo/inactivo por favor", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            if (this.cboCIIU.SelectedIndex > -1)
            {

                var cExisteDes = ((DataTable)this.cboActividadInterna1.DataSource).AsEnumerable().Where(x => x["cActividadInterna"].ToString() == this.txtDescripcion.Text.Trim()).Count();
                if (cExisteDes > 0 && operacion == Transaccion.Nuevo)
                {
                    MessageBox.Show("La descripción de la actividad interna ya existe", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return lValida;
                }
            }

            lValida = true;
            return lValida;
        }

        private void limpiarcontroles()
        {
            txtDescripcion.Text = "";
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarcontroles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboActividadInterna1.Enabled = !estado;
            cboActividadInterna1.Visible = !estado;
            lblActividadInterna.Visible = !estado;

            this.cboActividadEco.Enabled = estado;
            this.cboGrupoCiiu.Enabled = estado;
            this.cboCIIU.Enabled = estado;
            cboCategoria.Enabled = estado;
        }

        private void cargarActividadesInternas()
        {
            if (this.cboActividadInterna1.Items.Count > 0)
            {
                var drActividadInterna = (DataRowView)cboActividadInterna1.SelectedItem;
                txtDescripcion.Text = drActividadInterna["cActividadInterna"].ToString();
                
                if (drActividadInterna["idActividad"] == DBNull.Value)
                {
                    limpiarcontroles();
                    cboActividadEco.SelectedIndex = -1;
                    cboGrupoCiiu.SelectedIndex = -1;
                    cboCIIU.SelectedIndex = -1;
                    cboCategoria.SelectedIndex = -1;
                    return;
                }

                cargarActividad(Convert.ToInt32(drActividadInterna["idActividad"]));
                cboCategoria.SelectedValue = Convert.ToInt32(drActividadInterna["idCategoria"]);
                if (Convert.ToBoolean(drActividadInterna["lVigente"]) == false)
                {
                    rbtnInactivo.Checked = true;
                    rbtActivo.Checked = false;
                }
                else
                {
                    rbtnInactivo.Checked = false;
                    rbtActivo.Checked = true;
                }
            }
        }

        private void cargarActividad(int idActividad)
        {
            var dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);
            if (dtActividad.Rows.Count > 0)
            {
                var idPadreActividad = Convert.ToInt32(dtActividad.Rows[0]["idPadreActividad"]);
                var dtActividad2 = cnactividad.CNListaActividadEspecifica(idPadreActividad);
                var idPadreActividad2 = Convert.ToInt32(dtActividad2.Rows[0]["idPadreActividad"]);  
                this.cboActividadEco.SelectedValue = idPadreActividad2;
                this.cboGrupoCiiu.SelectedValue = idPadreActividad;
                this.cboCIIU.SelectedValue = idActividad;
            }            
        }

        private void cargarCategoria()
        {
            DataTable dtCategoria = new DataTable();
            dtCategoria.Columns.Add("idCategoria", typeof(int));
            dtCategoria.Columns.Add("cCategoria", typeof(string));

            DataRow dr;
            dr = dtCategoria.NewRow();
            dr["idCategoria"] = 1;
            dr["cCategoria"] = "MENOR";
            dtCategoria.Rows.Add(dr);

            dr = dtCategoria.NewRow();
            dr["idCategoria"] = 2;
            dr["cCategoria"] = "MAYOR";
            dtCategoria.Rows.Add(dr);

            cboCategoria.DataSource = dtCategoria;
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DisplayMember = "cCategoria";
        }

        #endregion
    }
}
