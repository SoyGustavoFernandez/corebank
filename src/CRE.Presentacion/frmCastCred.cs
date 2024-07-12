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
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCastCred : frmBase
    {
        #region Variables

        clsCNProcJud objProcJud = new clsCNProcJud();
        DataTable dtCtasCast = new DataTable();
        DataTable dtCredCast;

        #endregion

        public frmCastCred()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmCastCred_Load(object sender, EventArgs e)
        {
            dtgCtasCast.AutoGenerateColumns = false;
            cboAgencia.SelectedValue = 0;
            nudAtrasoIni.Value = -99999;
            nudAtrasoMax.Value = 99999;
            FillDataGridView();

            cboTipoCredito.CargarProductoModNivel(1, 1);
            cboSubTipoCredito.CargarProductoModNivel(1, 2);
            cboProducto.CargarProductoModNivel(1, 3);
            cboSubProducto.CargarProductoModNivel(1, 4);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgCtasCast.Rows)
            {
                row.Cells["chcCastigar"].Value = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de realizar esta acción?", "Castigo de Creditos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            FillDataTableToSave();
            DataSet dsCredCast = new DataSet("dsCredCast");
            dsCredCast.Tables.Add(dtCredCast);
            string xmlCredCast = dsCredCast.GetXml();
            xmlCredCast = clsCNFormatoXML.EncodingXML(xmlCredCast);

            dsCredCast.Tables.Clear();

            clsDBResp objDbResp = objProcJud.CastigCreditos(xmlCredCast, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Castigo de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearBindings();
                FillDataGridView();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Castigo de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            ClearBindings();
            FillDataGridView();
        }

        #endregion

        #region Métodos

        private void BindComponents()
        {
            txtSaldoCapital.DataBindings.Add("Text", dtCtasCast, "nMonSalCapital");
            txtSaldoInteres.DataBindings.Add("Text", dtCtasCast, "nMonSalInteres");
            txtSaldoIntComp.DataBindings.Add("Text", dtCtasCast, "nMonSalIntComp");
            txtSaldoMora.DataBindings.Add("Text", dtCtasCast, "nMonSalMora");
            txtSaldoOtros.DataBindings.Add("Text", dtCtasCast, "nMonSalOtros");
            txtTasaInteres.DataBindings.Add("Text", dtCtasCast, "nTasaCompensatoria");
            txtTasaMoratoria.DataBindings.Add("Text", dtCtasCast, "nTasaMoratoria");
            txtDiasAtraso.DataBindings.Add("Text", dtCtasCast, "nAtraso");
            txtTotalDeuda.DataBindings.Add("Text", dtCtasCast, "nTotal");
            txtEstadoCredito.DataBindings.Add("Text", dtCtasCast, "Estado");
            cboTipoCredito.DataBindings.Add("SelectedValue", dtCtasCast, "idTipCred");
            cboSubTipoCredito.DataBindings.Add("SelectedValue", dtCtasCast, "idSubTipCred");
            cboProducto.DataBindings.Add("SelectedValue", dtCtasCast, "idTipProd");
            cboSubProducto.DataBindings.Add("SelectedValue", dtCtasCast, "idSubTipProd");
            cboMoneda.DataBindings.Add("SelectedValue", dtCtasCast, "IdMoneda");
            nudCuotas.DataBindings.Add("value", dtCtasCast, "nCuotas");
            cboFuenteRecurso.DataBindings.Add("SelectedValue", dtCtasCast, "idRecurso", false, DataSourceUpdateMode.Never, 0);
        }

        private void ClearBindings()
        {
            txtSaldoCapital.DataBindings.Clear();
            txtSaldoInteres.DataBindings.Clear();
            txtSaldoIntComp.DataBindings.Clear();
            txtSaldoMora.DataBindings.Clear();
            txtSaldoOtros.DataBindings.Clear();
            txtTasaInteres.DataBindings.Clear();
            txtTasaMoratoria.DataBindings.Clear();
            txtDiasAtraso.DataBindings.Clear();
            txtTotalDeuda.DataBindings.Clear();
            txtEstadoCredito.DataBindings.Clear();
            cboTipoCredito.DataBindings.Clear();
            cboSubTipoCredito.DataBindings.Clear();
            cboProducto.DataBindings.Clear();
            cboSubProducto.DataBindings.Clear();
            cboMoneda.DataBindings.Clear();
            nudCuotas.DataBindings.Clear();
            cboFuenteRecurso.DataBindings.Clear();
        }

        private void FillDataGridView()
        {
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int nAtrasoMin = Convert.ToInt32(nudAtrasoIni.Value);
            int nAtrasoMax = Convert.ToInt32(nudAtrasoMax.Value);
            dtCtasCast = objProcJud.BusLstCtaCast(idAgencia, nAtrasoMin, nAtrasoMax);
            if (dtCtasCast.Rows.Count > 0)
            {
                dtCtasCast.Columns["chcCastigar"].ReadOnly = false;
                dtgCtasCast.DataSource = dtCtasCast;
                BindComponents();
                btnGrabar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existen cuentas para castigo", "Registro de Procesos Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar.Enabled = false;
            }
        }

        private void FillDataTableToSave()
        {
            dtCredCast = new DataTable("dtCredCast");
            dtCredCast.Columns.Add("idCuenta", typeof(int));

            foreach (DataGridViewRow row in dtgCtasCast.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chcCastigar"].Value))
                {
                    DataRow dr = dtCredCast.NewRow();
                    dr["idCuenta"] = Convert.ToInt32(row.Cells["idCuenta"].Value);
                    dtCredCast.Rows.Add(dr);
                }
            }
        }

        private bool Validar()
        {
            int cont = dtgCtasCast.Rows.Cast<DataGridViewRow>().Count(row => Convert.ToBoolean(row.Cells["chcCastigar"].Value));

            if (cont == 0)
            {
                MessageBox.Show("Seleccione al menos una cuenta a castigar.", "Castigo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCtasCast.Focus();
                return false;
            }

            DataTable dtCast = dtgCtasCast.DataSource as DataTable;
            if (dtCast != null)
            {
                if (dtCast.AsEnumerable().Any(x => x.Field<bool>("chcCastigar") && x.Field<decimal>("nMonSalInteres") < 0))
                {
                    MessageBox.Show("No se pueden castigar cuentas con intereses pagados por adelantado.",
                        "Castigo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgCtasCast.Focus();
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}
