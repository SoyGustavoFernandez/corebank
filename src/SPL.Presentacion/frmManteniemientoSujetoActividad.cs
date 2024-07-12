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
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmManteniemientoSujetoActividad : frmBase
    {
        #region Variable Globales

        clsCNDeclaracionJurada cnDeclaJur = new clsCNDeclaracionJurada();
        DataTable dtActivSujeto;
        string cTitulo = "Actividades sujeto obligado";
        Transaccion tranForm = Transaccion.Selecciona;
        #endregion

        public frmManteniemientoSujetoActividad()
        {
            InitializeComponent();
            dtActivSujeto = cnDeclaJur.CNListaActividadSujetoObligado();
            dtgActividadSujetoOb.DataSource = dtActivSujeto;
            formatoGrid();
            activarform(false);
            controlBotones(tranForm);
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            DataRow dr = dtActivSujeto.NewRow();
            dr["idSujetoActividad"] = 0;
            dr["dFechaReg"] = clsVarGlobal.dFecSystem;
            dr["dFechaMod"] = DBNull.Value;
            dr["idActividad"] = Convert.ToInt32(conActividad1.cboCIIU.SelectedValue);
            dr["idActividadPadre1"] = Convert.ToInt32(conActividad1.cboGrupoCiiu.SelectedValue);
            dr["idActividadPadre2"] = Convert.ToInt32(conActividad1.cboActividadEco.SelectedValue);
            dr["cActividad"] = ((DataTable)conActividad1.cboCIIU.DataSource).Rows[Convert.ToInt32(conActividad1.cboCIIU.SelectedIndex)]["cActividad"].ToString();
            dr["cWinUserReg"] = clsVarGlobal.User.cWinUser;
            dr["cWinUserMod"] = DBNull.Value;
            dr["idUsuario"] = clsVarGlobal.User.idUsuario;
            dr["idUsuarioMod"] = DBNull.Value; 
            dr["lVigente"] = true;

            dtActivSujeto.Rows.Add(dr);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            activarform(true);
            tranForm = Transaccion.Nuevo;
            controlBotones(tranForm);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            tranForm = Transaccion.Selecciona;
            controlBotones(tranForm);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            limpiar();
            activarform(false);
            tranForm = Transaccion.Edita;
            controlBotones(tranForm);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtgActividadSujetoOb.RowCount == 0)
            {
                MessageBox.Show("No hay actividades registradas", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataSet ds = new DataSet("dsActiSujeto");
            if (dtActivSujeto.DataSet == null)
            {
                ds.Tables.Add(dtActivSujeto);
            }
            else
            {
                ds = dtActivSujeto.DataSet;
            }

            string xml = ds.GetXml();
            DataTable dtResultado = cnDeclaJur.CNInsertaActSujetoOb(xml);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
            activarform(false);
            dtActivSujeto = cnDeclaJur.CNListaActividadSujetoObligado();
            dtgActividadSujetoOb.DataSource = dtActivSujeto;
            formatoGrid();
            tranForm = Transaccion.Selecciona;
            controlBotones(tranForm);
        }
        private void dtgActividadSujetoOb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActividadSujetoOb.RowCount == 0)
            {
                return;
            }

            if (tranForm == Transaccion.Edita)
            {
                dtActivSujeto.Rows[e.RowIndex]["lVigente"] = !Convert.ToBoolean(dtActivSujeto.Rows[e.RowIndex]["lVigente"]);
                dtActivSujeto.Rows[e.RowIndex]["idUsuarioMod"] = clsVarGlobal.User.idUsuario;
                dtActivSujeto.Rows[e.RowIndex]["cWinUserMod"] = clsVarGlobal.User.cWinUser;
                dtActivSujeto.Rows[e.RowIndex]["dFechaMod"] = clsVarGlobal.dFecSystem;
            }
        }
        
        private void dtgActividadSujetoOb_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActividadSujetoOb.RowCount == 0)
            {
                return;
            }

            conActividad1.cboActividadEco.SelectedValue = Convert.ToInt32(dtActivSujeto.Rows[e.RowIndex]["idActividadPadre2"]);
            conActividad1.cboGrupoCiiu.SelectedValue = Convert.ToInt32(dtActivSujeto.Rows[e.RowIndex]["idActividadPadre1"]);
            conActividad1.cboCIIU.SelectedValue  = Convert.ToInt32(dtActivSujeto.Rows[e.RowIndex]["idActividad"]);
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = true;
            if (conActividad1.cboActividadEco.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la actividad económica", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conActividad1.cboActividadEco.Focus();
                return false;
            }

            if (conActividad1.cboGrupoCiiu.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el grupo", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conActividad1.cboGrupoCiiu.Focus();
                return false;
            }

            if (conActividad1.cboCIIU.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el CIIU", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                conActividad1.cboCIIU.Focus();
                return false;
            }

            foreach (DataGridViewRow item in dtgActividadSujetoOb.Rows)
            {
                if (Convert.ToInt32(item.Cells["idActividad"].Value) == Convert.ToInt32(conActividad1.cboCIIU.SelectedValue))
                {
                    MessageBox.Show("El CIIU: "+((DataTable)conActividad1.cboCIIU.DataSource).Rows[Convert.ToInt32(conActividad1.cboCIIU.SelectedIndex)]["cActividad"].ToString()
                        +" ya esta agregado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    item.Selected = true;
                    dtgActividadSujetoOb.FirstDisplayedScrollingRowIndex = item.Index;
                    return false;
                }
            }

            return lValida;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgActividadSujetoOb.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            
            if (dtgActividadSujetoOb.RowCount == 0)
                dtgActividadSujetoOb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            else
                dtgActividadSujetoOb.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dtgActividadSujetoOb.Columns["dFechaReg"].Visible = true;
            dtgActividadSujetoOb.Columns["cActividad"].Visible = true;
            dtgActividadSujetoOb.Columns["cWinUserReg"].Visible = true;
            dtgActividadSujetoOb.Columns["lVigente"].Visible = true;

            dtgActividadSujetoOb.Columns["dFechaReg"].HeaderText = "Fecha Registro";
            dtgActividadSujetoOb.Columns["dFechaMod"].HeaderText = "Fecha modificación";
            dtgActividadSujetoOb.Columns["cActividad"].HeaderText = "CIIU";
            dtgActividadSujetoOb.Columns["cWinUserReg"].HeaderText = "Usuario crea";
            dtgActividadSujetoOb.Columns["cWinUserMod"].HeaderText = "Fecha Modificación";
            dtgActividadSujetoOb.Columns["lVigente"].HeaderText = " Vigencia";
            dtgActividadSujetoOb.Columns["lVigente"].ReadOnly = false;

            dtgActividadSujetoOb.Columns["lVigente"].DisplayIndex = 1;

        }

        private void limpiar()
        {
            conActividad1.cboActividadEco.SelectedIndex = -1;
            conActividad1.cboGrupoCiiu.SelectedIndex = -1;
            conActividad1.cboCIIU.SelectedIndex = -1;
        }

        private void activarform(Boolean lBol)
        {
            conActividad1.Enabled = lBol;
            btnAgregar1.Enabled = lBol;
        }

        private void controlBotones(Transaccion tran)
        {
            switch (tran)
            {
                case Transaccion.Selecciona:
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    break;
                case Transaccion.Nuevo:
                case Transaccion.Edita:
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
            }
        }
        #endregion 
    }
}
