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
using GEN.CapaNegocio;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmConfiguraGrupoAsesor : frmBase
    {
        #region Variable Globales

        clsCNMeta cnmeta = new clsCNMeta();
        DataSet dsGrupoAsesor = new DataSet("dsGrupoAsesor");

        #endregion

        public frmConfiguraGrupoAsesor()
        {
            InitializeComponent();
            cboMes.cargarTodos();
            this.cboAgencia.AgenciasYTodos();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            nudAnio.Value = clsVarGlobal.dFecSystem.Year;
            cboMes.SelectedValue = clsVarGlobal.dFecSystem.Month;
            cargarAsesores();

        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarAsesores();
        }
        
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                dsGrupoAsesor.Tables.Clear();

                DataTable dtAsesor = (DataTable)dtgGrupoAsesor.DataSource;
                dtAsesor.Columns["idGrupoAsesor"].ReadOnly = false;

                for (int i = 0; i < dtgGrupoAsesor.Rows.Count; i++)
                {
                    dtAsesor.Rows[i]["idGrupoAsesor"] = (int)dtgGrupoAsesor.Rows[i].Cells["cmb"].Value;
                }

                DataTable dtAsesor2 = (Convert.ToInt32(cboMes.SelectedValue) == 0) ? cargarTodosMesesAsesores(dtAsesor) : dtAsesor;
                dsGrupoAsesor.Tables.Add(dtAsesor2);

                var cxmlGrupoAsesor = dsGrupoAsesor.GetXml();

                cnmeta.CNInsActGrupoAsesor(cxmlGrupoAsesor, clsVarGlobal.User.idUsuario);

                MessageBox.Show("Los datos se guardaron correctamente", "Registro de grupo asesor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnSalir1.Enabled = false;
                btnProcesar1.Enabled = true;
                grbParametros.Enabled = false;
                dtgGrupoAsesor.Enabled = false;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            btnProcesar1.Enabled = false;
            grbParametros.Enabled = false;
            dtgGrupoAsesor.Enabled = true;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnProcesar1.Enabled = false;
            grbParametros.Enabled = true;
            dtgGrupoAsesor.Enabled = false;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            var lResultado = MessageBox.Show("A continuación se procesará la asignación de metas para el periodo seleccionado." +
                                             "\n Tener en cuenta que debió configurar a el personal de todas las agencias. \n ¿Desea continuar?",
                                            "Confirmación de proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (lResultado == System.Windows.Forms.DialogResult.Yes)
            {

                var dtResultado = cnmeta.CNProcesaAsignacionMetas((int)nudAnio.Value, (int)cboMes.SelectedValue);

                if ((int)dtResultado.Rows[0][0] == 1)
                {
                    MessageBox.Show("Las metas fueron asignadas correctamente", "Asignación de metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al procesar asignación de metas", "Asignación de metas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnProcesar1.Enabled = false;
                btnSalir1.Enabled = true;
                grbParametros.Enabled = true;
                dtgGrupoAsesor.Enabled = false;
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarAsesores();
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            cargarAsesores();
        }

        #endregion

        #region Métodos

        private DataTable cargarTodosMesesAsesores(DataTable dt)
        {
            DataTable dtReturn = dt.Clone();
            int nMeses = 12, i;
            
            foreach (DataRow item in dt.Rows)
            {
                DataRow item2 = item;
                for (i = 1; i <= nMeses; i++)
                {
                    item2["nMes"] = i;
                    dtReturn.ImportRow(item2);
                }

            }

            return dtReturn;
        }

        private bool validar()
        {
            bool lValida = false;

            if (dtgGrupoAsesor.RowCount <= 0)
            {
                MessageBox.Show("No se ha seleccionado items para el registro", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void formatoGrid()
        {
            dtgGrupoAsesor.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgGrupoAsesor.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = true;
            }

            dtgGrupoAsesor.Columns["cNombre"].Visible = true;
            dtgGrupoAsesor.Columns["cmb"].Visible = true;
            dtgGrupoAsesor.Columns["cNombre"].HeaderText = "Nombres";
            dtgGrupoAsesor.Columns["cmb"].ReadOnly = false;
            dtgGrupoAsesor.Columns["cmb"].Width = 150;
        }

        private void cargarAsesores()
        {
            if (cboAgencia.SelectedIndex > -1)
            {
                dtgGrupoAsesor.Columns.Clear();
                DataTable dtAsesor = cnmeta.CNListaAsesorGrupoMeta((int)cboAgencia.SelectedValue, (int)nudAnio.Value, (int)cboMes.SelectedValue);
                dtAsesor.Columns["nMes"].ReadOnly = false;

                if (dtAsesor.Rows.Count > 0)
                {
                    var dtAux = dtAsesor.Clone();

                    #region Asignar Datos y ComboBox

                    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                    cmb.HeaderText = "Grupo";
                    cmb.Name = "cmb";
                    cmb.FillWeight = 130;
                    cmb.MaxDropDownItems = 4;
                    cmb.DataSource = cargarGrupos();
                    cmb.DisplayMember = "cGrupoAsesor";
                    cmb.ValueMember = "idGrupoAsesor";
                    cmb.ReadOnly = false;

                    dtgGrupoAsesor.ReadOnly = false;

                    //if ((int)this.cboMes.SelectedValue == 0)
                    //{
                    //    for (int i = 1; i <= 12; i++)
                    //    {
                    //        for (int j = 0; j < dtAsesor.Rows.Count; j++)
                    //        {
                    //            var dr = dtAsesor.Rows[j];
                    //            dr["nMes"] = i;
                    //            dtAux.ImportRow(dr);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                        dtAux = dtAsesor;
                    //}
                    dtAux.Columns["cNombre"].ReadOnly = false;
                    dtgGrupoAsesor.DataSource = dtAux;
                    dtgGrupoAsesor.Columns.Add(cmb);
                    for (int i = 0; i < dtgGrupoAsesor.Rows.Count; i++)
                    {
                        dtgGrupoAsesor.Rows[i].Cells["cmb"].Value = Convert.ToInt32(dtAux.Rows[i]["idGrupoAsesor"]);
                    }
                    formatoGrid();

                    #endregion
                }
            }
            lblTotal.Text = "";
            if (dtgGrupoAsesor.RowCount > 0)
            {
                lblTotal.Text = "Total : " + dtgGrupoAsesor.RowCount.ToString();
            }
        }

        private DataTable cargarGrupos()
        {
            DataTable dtGrupos = new DataTable();
            dtGrupos.Columns.Add("idGrupoAsesor", typeof(int));
            dtGrupos.Columns.Add("cGrupoAsesor", typeof(string));

            DataRow drgrupo;
            drgrupo = dtGrupos.NewRow();
            drgrupo["idGrupoAsesor"] = 1;
            drgrupo["cGrupoAsesor"] = "Normal";
            dtGrupos.Rows.Add(drgrupo);

            drgrupo = dtGrupos.NewRow();
            drgrupo["idGrupoAsesor"] = 2;
            drgrupo["cGrupoAsesor"] = "Experiencia sin cartera";
            dtGrupos.Rows.Add(drgrupo);

            drgrupo = dtGrupos.NewRow();
            drgrupo["idGrupoAsesor"] = 3;
            drgrupo["cGrupoAsesor"] = "Zona nueva";
            dtGrupos.Rows.Add(drgrupo);

            drgrupo = dtGrupos.NewRow();
            drgrupo["idGrupoAsesor"] = 4;
            drgrupo["cGrupoAsesor"] = "Asesor Convenio";
            dtGrupos.Rows.Add(drgrupo);

            return dtGrupos;
        }

        #endregion

    }
}
