using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmAsignaMetas : frmBase
    {
        #region Variables Globales

        clsCNMeta objMeta = new clsCNMeta();
        DataTable dtMeta;
        
        #endregion

        public frmAsignaMetas()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmAsignaMetas_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            nudAnio.Value = clsVarGlobal.dFecSystem.Year;
            cboMes.SelectedValue = clsVarGlobal.dFecSystem.Month;
            cargarGrupos();
        }
        
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            btnGrabar1.Enabled = false;
            DataSet dsMeta = new DataSet("dsMeta");
            dsMeta.Tables.Add(dtMeta);
            String XmlMeta = dsMeta.GetXml();
            XmlMeta = clsCNFormatoXML.EncodingXML(XmlMeta);

            clsCNMeta InsMeta = new clsCNMeta();
            DataTable dtResultado = InsMeta.CNInsActMeta((int)cboAgencia.SelectedValue, (int)nudAnio.Value, (int)cboMes.SelectedValue, 
                                                            (int)cboTipoMeta.SelectedValue, XmlMeta);
            if (Convert.ToInt16(dtResultado.Rows[0]["lIndError"]) == 1)
            {
                MessageBox.Show("Actualización correcta", "Registro Metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error de Actualización", "Registro Metas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboTipoMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgMetas.DataSource = null;
            txtTotalMeta.Text = "0";
            btnGrabar1.Enabled = false;
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            Consulta();
        }

        private void dtgMetas_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            suma();
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgMetas.DataSource = null;
            txtTotalMeta.Text = "0";
            btnGrabar1.Enabled = false;
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgMetas.DataSource = null;
            txtTotalMeta.Text = "0";
            btnGrabar1.Enabled = false;
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            dtgMetas.DataSource = null;
            txtTotalMeta.Text = "0";
            btnGrabar1.Enabled = false;
        }

        #region FormatoNumeroGrid

        private void dtgMetas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgMetas.DataSource = null;
            txtTotalMeta.Text = "0";
            btnGrabar1.Enabled = false;
        }

        #endregion

        #endregion

        #region Métodos

        private void suma()
        {
            if (dtMeta.Rows.Count > 0)
            {
                decimal pnAcumula = 0;
                int idTipoMeta = (int)cboTipoMeta.SelectedValue;
                int idGrupo = (int)this.cboGrupo.SelectedValue;

                for (int i = 0; i < dtMeta.Rows.Count; i++)
                {
                    if (dtMeta.Rows[i]["nMeta"] == System.DBNull.Value)
                    {
                        dtMeta.Rows[i]["nMeta"] = 0.00;
                    }
                    pnAcumula = pnAcumula + Convert.ToDecimal(dtMeta.Rows[i]["nMeta"]);
                }
                if (idTipoMeta == 3 && idGrupo != 0)// Ratio 
                {
                    txtTotalMeta.Text = Convert.ToString(pnAcumula / dtMeta.Rows.Count);
                    lblAcumula.Text = "% Grupo:";
                }
                else
                {
                    txtTotalMeta.Text = Convert.ToString(pnAcumula);
                    lblAcumula.Text = "Total Grupo:";
                }

                if (idTipoMeta == 3 && idGrupo == 0)
                {
                    txtTotalMeta.Text = Convert.ToString(pnAcumula / dtMeta.Rows.Count);
                    lblAcumula.Text = "% Agencia:";
                }
                else if (idGrupo == 0)
                {
                    txtTotalMeta.Text = Convert.ToString(pnAcumula);
                    lblAcumula.Text = "Total Agencia:";
                }
            }
        }

        private void FormatoGrid()
        {
            foreach (DataGridViewColumn item in dtgMetas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtMeta.Columns["nMeta"].ReadOnly = false;
            dtgMetas.Enabled = true;
            dtgMetas.ReadOnly = false;

            dtgMetas.Columns["idUsuario"].Visible = false;
            dtgMetas.Columns["idCategoria"].Visible = false;
            dtgMetas.Columns["idGrupoAsesor"].Visible = false;

            dtgMetas.Columns["cCategoriaAsesor"].HeaderText = "Categoría";

            dtgMetas.Columns["cNombre"].HeaderText = "Asesor de Negocio";
            dtgMetas.Columns["cNombre"].Width = 250;

            dtgMetas.Columns["nNum"].HeaderText = "N°";
            dtgMetas.Columns["nNum"].Width = 27;

            dtgMetas.Columns["nMeta"].HeaderText = this.cboTipoMeta.Text;
            dtgMetas.Columns["nMeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgMetas.Columns["nMeta"].Width = 100;

            dtgMetas.Columns["cNombre"].ReadOnly = true;
            dtgMetas.Columns["cCategoriaAsesor"].ReadOnly = true;
            dtgMetas.Columns["nMeta"].ReadOnly = false;
        }
         
        private void Consulta()
        {
            int nAnio = Convert.ToInt32(nudAnio.Value);
            int nMes = Convert.ToInt16(cboMes.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idTipoMeta = Convert.ToInt32(cboTipoMeta.SelectedValue);

            dtMeta = objMeta.CNConsultaMeta(idAgencia, nAnio, nMes, idTipoMeta, (int)cboGrupo.SelectedValue);
            if (dtMeta.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para cargar metas", "Asignación Metas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dtgMetas.DataSource = dtMeta;
            FormatoGrid();
            btnGrabar1.Enabled = true;
            suma();
        }

        private void cargarGrupos()
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

            drgrupo = dtGrupos.NewRow();
            drgrupo["idGrupoAsesor"] = 0;
            drgrupo["cGrupoAsesor"] = "***TODOS***";
            dtGrupos.Rows.Add(drgrupo);

            cboGrupo.DataSource = dtGrupos;
            cboGrupo.DisplayMember = "cGrupoAsesor";
            cboGrupo.ValueMember = "idGrupoAsesor";
        }

        #endregion


    }
}
