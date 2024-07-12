using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GEN.BotonesBase;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmConfigurarCargaArchivo : frmBase
    {
        #region Variables
        private clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
        #endregion
        public frmConfigurarCargaArchivo()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmConfigurarCargaArchivo_Load(object sender, EventArgs e)
        {
            cboOperacionCredito1.SelectedIndexChanged -= cboOperacionCredito1_SelectedIndexChanged;
            cboTipoEvaluacion1.SelectedIndexChanged -= cboTipoEvaluacion1_SelectedIndexChanged;
            cboGrupoCargaArchivo1.SelectedIndexChanged -= cboGrupoCargaArchivo1_SelectedIndexChanged;
            cboGrupoCargaArchivo2.SelectedIndexChanged -= cboGrupoCargaArchivo2_SelectedIndexChanged;

            cboOperacionCredito1.ListarOperacionCredito();
            cboTipoEvaluacion1.ListarTipoEvaluacion();
            cboGrupoCargaArchivo1.ListarGrupoCargaArchivo();
            cboGrupoCargaArchivo2.ListarGrupoCargaArchivo();
            cboGrupoCargaArchivo2.SelectedIndex = -1;
            cancelarConfiguracion();

            cboOperacionCredito1.SelectedIndexChanged += cboOperacionCredito1_SelectedIndexChanged;
            cboTipoEvaluacion1.SelectedIndexChanged += cboTipoEvaluacion1_SelectedIndexChanged;
            cboGrupoCargaArchivo1.SelectedIndexChanged += cboGrupoCargaArchivo1_SelectedIndexChanged;
            cboGrupoCargaArchivo2.SelectedIndexChanged += cboGrupoCargaArchivo2_SelectedIndexChanged;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (cboOperacionCredito1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de operación", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoEvaluacion1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de evaluación", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboGrupoCargaArchivo1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un grupo de archivos", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtConfig = clsConfiguracion.CNListarConfiguracionArchivo(
                Convert.ToInt32(cboOperacionCredito1.SelectedValue),
                Convert.ToInt32(cboTipoEvaluacion1.SelectedValue),
                Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue)
                );

            if (dtConfig.Rows.Count > 0)
            {
                btnEditar1.Enabled = true;
                btnGrabar1.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se encontró archivos para este grupo", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataColumn col in dtConfig.Columns)
                col.ReadOnly = false;

            dtgArchivos.DataSource = dtConfig;
            dtgArchivos.ReadOnly = false;
            formatoDtgArchivos();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtgArchivos.Rows.Count > 0)
            {
                
                DataTable dtRes = clsConfiguracion.CNGuardarConfiguracion(
                        Convert.ToInt32(cboOperacionCredito1.SelectedValue),
                        Convert.ToInt32(cboTipoEvaluacion1.SelectedValue),
                        Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue),
                        convertXmlDtg((DataTable)dtgArchivos.DataSource)
                    );

                if (Convert.ToInt32(dtRes.Rows[0]["idMsg"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se encontró ninguna configuración para guardar", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void cboOperacionCredito1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarDtArchivos();
        }

        private void cboTipoEvaluacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarDtArchivos();
        }

        private void cboGrupoCargaArchivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarDtArchivos();
            ponerTipEvalTodos();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarDtArchivos();
            cancelarConfiguracion();
            cboTipoEvaluacion1.Enabled = false;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            dtgArchivos.Columns["lVisibleNatural"].ReadOnly = false;
            dtgArchivos.Columns["lVisibleJuridica"].ReadOnly = false;
            dtgArchivos.Columns["lObligatorioNatural"].ReadOnly = false;
            dtgArchivos.Columns["lObligatorioJuridica"].ReadOnly = false;

            btnGrabar1.Enabled = true;
        }
        #endregion

        #region Metodos
        public void ponerTipEvalTodos()
        {
            if (cboGrupoCargaArchivo1.SelectedIndex != -1)
            {
                if (Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue) != 10)
                {
                    cboTipoEvaluacion1.SelectedValue = 0;
                    cboTipoEvaluacion1.Enabled = false;
                }
                else
                {
                    cboTipoEvaluacion1.SelectedValue = -1;
                    cboTipoEvaluacion1.Enabled = true;
                }
            }
        }

        public string convertXmlDtg(DataTable dt)
        {
            dt.TableName = "dtArchivo";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }


            return ds.GetXml();
        }

        private void cancelarConfiguracion()
        {
            cboOperacionCredito1.SelectedIndex = -1;
            cboTipoEvaluacion1.SelectedIndex = -1;
            cboGrupoCargaArchivo1.SelectedIndex = -1;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = false;
        }

        private void limpiarDtArchivos()
        {
            dtgArchivos.DataSource = null;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }

        private void formatoDtgArchivos()
        {
            foreach (DataGridViewColumn column in dtgArchivos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgArchivos.Columns["cTipoArchivo"].Visible = true;
            dtgArchivos.Columns["lVisibleNatural"].Visible = true;
            dtgArchivos.Columns["lVisibleJuridica"].Visible = true;
            dtgArchivos.Columns["lObligatorioNatural"].Visible = true;
            dtgArchivos.Columns["lObligatorioJuridica"].Visible = true;

            dtgArchivos.Columns["cTipoArchivo"].HeaderText = "Archivo";
            dtgArchivos.Columns["lVisibleNatural"].HeaderText = "Natural";
            dtgArchivos.Columns["lVisibleJuridica"].HeaderText = "Jurídica";
            dtgArchivos.Columns["lObligatorioNatural"].HeaderText = "Natural";
            dtgArchivos.Columns["lObligatorioJuridica"].HeaderText = "Jurídica";

            dtgArchivos.Columns["cTipoArchivo"].FillWeight = 50;
            dtgArchivos.Columns["lVisibleNatural"].FillWeight = 10;
            dtgArchivos.Columns["lVisibleJuridica"].FillWeight = 10;
            dtgArchivos.Columns["lObligatorioNatural"].FillWeight = 10;
            dtgArchivos.Columns["lObligatorioJuridica"].FillWeight = 10;

        }
        #endregion

        #region Eventos GrupoArchivos
        private void cboGrupoCargaArchivo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarArchivosxGrupo();
        }

        private void cargarArchivosxGrupo(){
            DataTable dtConfig = clsConfiguracion.CNListarConfiguracionArchivo(0, 0, Convert.ToInt32(cboGrupoCargaArchivo2.SelectedValue));
            
            foreach (DataColumn col in dtConfig.Columns)
                col.ReadOnly = false;

            dtgArchivoxGrupo.DataSource = dtConfig;
            dtgArchivoxGrupo.ReadOnly = false;
            formatoDtgArchivoscGrupo();
        }

        private void formatoDtgArchivoscGrupo()
        {
            foreach (DataGridViewColumn column in dtgArchivoxGrupo.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgArchivoxGrupo.Columns["cTipoArchivo"].Visible = true;
            dtgArchivoxGrupo.Columns["cTipoArchivo"].HeaderText = "Archivo";
        }

        private void btnEditar3_Click(object sender, EventArgs e)
        {
            dtgArchivoxGrupo.Columns["cTipoArchivo"].ReadOnly = false;
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (txtNuevoArchivo.Text != "")
            {
                DataTable datatable = new DataTable();
                datatable = dtgArchivoxGrupo.DataSource as DataTable;

                DataRow datarow;
                datarow = datatable.NewRow();
                datarow["idTipoArchivo"] = 0;
                datarow["cTipoArchivo"] = txtNuevoArchivo.Text;
                datarow["lVisibleNatural"] = 0;
                datarow["lVisibleJuridica"] = 0;
                datarow["lObligatorioNatural"] = 0;
                datarow["lObligatorioJuridica"] = 0;

                datatable.Rows.Add(datarow);
                txtNuevoArchivo.Text = "";
            }
        }

        private void btnGrabar3_Click(object sender, EventArgs e)
        {
            if (dtgArchivoxGrupo.Rows.Count > 0)
            {

                DataTable dtRes = clsConfiguracion.CNGuardarNuevoArchivo(
                        Convert.ToInt32(cboGrupoCargaArchivo2.SelectedValue),
                        convertXmlDtg((DataTable)dtgArchivoxGrupo.DataSource)
                    );

                if (Convert.ToInt32(dtRes.Rows[0]["idMsg"]) == 1)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarArchivosxGrupo();
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se encontró ningun Archivo para guardar", "Configuración de carga de archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            dtgArchivoxGrupo.DataSource = null;
            cboGrupoCargaArchivo2.SelectedIndex = -1;
            txtNuevoArchivo.Text = "";
        }
        #endregion
    }
}
