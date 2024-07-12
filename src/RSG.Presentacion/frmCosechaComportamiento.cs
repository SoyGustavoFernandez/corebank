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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmCosechaComportamiento : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Cosecha de comportamiento";
        clsCNProducto cnproducto = new clsCNProducto();
        DataSet dsProductos = new DataSet("dsProductos");
        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboTipCred.SelectedIndexChanged -= cboTipCred_SelectedIndexChanged;
            cboTipCred.CargarProducto(1);
            AddTodos(cboTipCred);
            cboTipCred.SelectedIndexChanged += cboTipCred_SelectedIndexChanged;
            cboPais.CargarUbigeo(0);
            AddTodos(cboAsesor1);
            AddTodos(cboOperacionCre);
            AddTodos(cboActividadInterna);
            AddTodos(cboZona);
            
            IniControles();
        }

        private void cboTipCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipCred.SelectedValue != null && !(cboTipCred.SelectedValue is DataRowView))
            {
                cboSubTipCred.CargarProducto(Convert.ToInt32(cboTipCred.SelectedValue), true);
                AddTodos(cboSubTipCred);
                if (Convert.ToInt32(cboTipCred.SelectedValue) == 0)
                {
                    cboSubTipCred.SelectedValue = 0;
                    cboProd.SelectedValue = 0;
                    cboSubProd.SelectedValue = 0;
                    cboSubTipCred.Enabled = false;
                    cboProd.Enabled = false;
                    cboSubProd.Enabled = false;
                }
                else
                {
                    cboSubTipCred.SelectedIndex = -1;
                    cboProd.SelectedIndex = -1;
                    cboSubProd.SelectedIndex = -1;
                    cboSubTipCred.Enabled = true;
                    cboProd.Enabled = true;
                    cboSubProd.Enabled = true;
                }
            }
        }

        private void cboSubTipCred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipCred.SelectedValue != null && !(cboSubTipCred.SelectedValue is DataRowView))
            {
                cboProd.CargarProducto(Convert.ToInt32(cboSubTipCred.SelectedValue), true);
                AddTodos(cboProd);
                if (Convert.ToInt32(cboSubTipCred.SelectedValue) == 0)
                {
                    cboProd.SelectedValue = 0;
                    cboSubProd.SelectedValue = 0;
                    cboProd.Enabled = false;
                    cboSubProd.Enabled = false;
                }
                else
                {
                    cboProd.SelectedIndex = -1;
                    cboSubProd.SelectedIndex = -1;
                    cboProd.Enabled = true;
                    cboSubProd.Enabled = true;
                }
            }
        }

        private void cboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProd.SelectedValue != null && !(cboProd.SelectedValue is DataRowView))
            {
                cboSubProd.CargarProducto(Convert.ToInt32(cboProd.SelectedValue), true);
                AddTodos(cboSubProd);
                if (Convert.ToInt32(cboProd.SelectedValue) == 0)
                {
                    cboSubProd.SelectedValue = 0;
                    cboSubProd.Enabled = false;
                }
                else
                {
                    cboSubProd.SelectedIndex = -1;
                    cboSubProd.Enabled = true;
                }
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0 && !(cboPais.SelectedValue is DataRowView))
            {
                cboDepartamento.CargarUbigeo(Convert.ToInt32(cboPais.SelectedValue));
                cboDepartamento.Enabled = true;
            }
            else
            {

                cboDepartamento.SelectedIndex = -1;
                cboDepartamento.Enabled = true;
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedIndex > 0 && !(cboDepartamento.SelectedValue is DataRowView))
            {
                cboProvincia.CargarUbigeo(Convert.ToInt32(cboDepartamento.SelectedValue));
                cboProvincia.Enabled = true;
            }
            else
            {
                cboProvincia.SelectedIndex = -1;
                cboProvincia.Enabled = true;
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0 && !(cboProvincia.SelectedValue is DataRowView))
            {
                cboDistrito.CargarUbigeo(Convert.ToInt32(cboProvincia.SelectedValue));
                cboDistrito.Enabled = true;
            }
            else
            {
                cboDistrito.SelectedIndex = -1;
                cboDistrito.Enabled = true;
            }
        }

        private void chcTodosUbigeo_CheckedChanged(object sender, EventArgs e)
        {
            cboPais.Enabled = !chcTodosUbigeo.Checked;
            cboDepartamento.Enabled = !chcTodosUbigeo.Checked;
            cboProvincia.Enabled = !chcTodosUbigeo.Checked;
            cboDistrito.Enabled = !chcTodosUbigeo.Checked;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            int nAnio = Convert.ToInt32(nudAnio.Value);
            int nMes = Convert.ToInt32(cboMeses.SelectedValue);
            int nNumPeriodos = Convert.ToInt32(nudNumPeriodos.Value);
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            int idTipCred = Convert.ToInt32(cboTipCred.SelectedValue);
            int idSubTipCred = Convert.ToInt32(cboSubTipCred.SelectedValue);
            int idTipProd = Convert.ToInt32(cboProd.SelectedValue);
            int idSubTipProd = Convert.ToInt32(cboSubProd.SelectedValue);
            int idAsesor = Convert.ToInt32(cboAsesor1.SelectedValue);
            int idOperacion = Convert.ToInt32(cboOperacionCre.SelectedValue);
            int idZona = chcTodosUbigeo.Checked ? 0 : Convert.ToInt32(cboZona.SelectedValue);
            int idUbigeo = Convert.ToInt32(cboDistrito.SelectedValue);
            int idActInt = Convert.ToInt32(cboActividadInterna.SelectedValue);

            string cxmlProducto = retornarXmlProductosSel();

            this.Cursor = Cursors.WaitCursor;

            DataTable dtData = new clsRPTCNRiesgos().CNRptCosechaComportamiento(nAnio, nMes, nNumPeriodos, idAgencia,
                                        idTipCred, idSubTipCred, idTipProd, idSubTipProd, idAsesor,
                                        idOperacion, idZona, idUbigeo, idActInt, cxmlProducto);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Cosecha Comportamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dInicio = new DateTime(nAnio, nMes, 1);
            dInicio = dInicio.AddMonths(-1);

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("dInicio", dInicio.ToString("yyyy-MM-dd"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = "rptCosechaComportamiento.rdlc";

            this.Cursor = Cursors.Default;

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZona.SelectedIndex > -1)
            {
                if (Convert.ToInt32(this.cboZona.SelectedValue) == 0)
                {
                    cboAgencia1.AgenciasYTodos();
                    cboAgencia1.SelectedValue = 0;
                    cboAgencia1.Enabled = false;
                    cboAsesor1.SelectedValue = 0;
                    cboAsesor1.Enabled = false;
                }
                else
                {
                    cboAgencia1.Enabled = true;
                    cboAsesor1.Enabled = true;
                    cboAgencia1.FiltrarPorZona(Convert.ToInt32(this.cboZona.SelectedValue));
                    if (cboAgencia1.Items.Count > 1)
                    {
                        AddTodos(cboAgencia1);
                    }
                }
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAgencia1.SelectedIndex > -1)
            {
                if (Convert.ToInt32(this.cboAgencia1.SelectedValue) == 0)
                {
                    AddTodos(cboAsesor1);
                    cboAsesor1.SelectedValue = 0;
                    cboAsesor1.Enabled = false;
                }
                else
                {
                    cboAsesor1.Enabled = true;
                    cboAsesor1.ListarPersonal(Convert.ToInt32(this.cboAgencia1.SelectedValue));
                    if (cboAsesor1.Items.Count > 1)
                    {
                        AddTodos(cboAsesor1);
                    }
                }
            }
        }

        private void dtgTipoCredito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgTipoCredito.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgTipoCredito.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;

                dtgTipoCredito.CurrentCell.Value = isChecked;


            }
        }

        private void chcTipoCre_CheckedChanged(object sender, EventArgs e)
        {
            actualizarTodosGrid(dtgTipoCredito, sender);
        }

        private void chcSubTipoCre_CheckedChanged(object sender, EventArgs e)
        {
            actualizarTodosGrid(dtgSubTipoCredito, sender);
        }

        private void chcProducto_CheckedChanged(object sender, EventArgs e)
        {
            actualizarTodosGrid(dtgProducto, sender);
        }

        private void chcSubProducto_CheckedChanged(object sender, EventArgs e)
        {
            actualizarTodosGrid(dtgSubProducto, sender);
        }

        #endregion

        #region Metodos

        public frmCosechaComportamiento()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboSubTipCred.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el sub tipo de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSubTipCred.Focus();
                return false;
            }
            if (cboProd.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el producto del crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProd.Focus();
                return false;
            }
            if (cboSubProd.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el sub producto de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSubProd.Focus();
                return false;
            }

            if (!chcTodosUbigeo.Checked)
            {
                if (cboDistrito.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione el distrito del ubigeo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboDistrito.Focus();
                    return false;
                }
            }
            return true;
        }

        private void IniControles()
        {
            nudAnio.Value = clsVarGlobal.dFecSystem.AddYears(-1).Year;
            cboMeses.SelectedValue = clsVarGlobal.dFecSystem.Month;
            cboAgencia1.SelectedValue = 0;
            cboAsesor1.SelectedValue = 0;
            cboOperacionCre.SelectedValue = 0;
            cboActividadInterna.SelectedValue = 0;
            cboTipCred.SelectedIndex = 0;
            cboZona.SelectedValue = 0;
            cboPais.SelectedValue = 173;
            cboDepartamento.SelectedIndex = -1;
            cboProvincia.SelectedIndex = -1;
            cboDistrito.SelectedIndex = -1;
            chcTodosUbigeo.Checked = true;
            nudNumPeriodos.Value = 12;

            cargarTipoCredito();
            caragarProducto(dtgTipoCredito, dtgSubTipoCredito, 1);
            caragarProducto(dtgSubTipoCredito, dtgProducto, 2);
            caragarProducto(dtgProducto, dtgSubProducto,3);
        }       

        private void AddTodos(cboBase cboBase)
        {
            if (cboBase.DataSource is DataTable)
            {
                DataTable dtData = (DataTable)cboBase.DataSource;
                string cDisplay = cboBase.DisplayMember;
                string cValue = cboBase.ValueMember;
                int indexColDisplay = 0;
                int indexColValue = 0;
                int indexVigenteCol = 0;

                indexColDisplay = dtData.Columns.IndexOf(cDisplay);
                indexColValue = dtData.Columns.IndexOf(cValue);

                if (cboBase is cboProducto)
                {
                    List<int> rowDelete = new List<int>();
                    foreach (DataRow row in dtData.Rows)
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(row[cDisplay]).Trim()))
                        {
                            rowDelete.Add(dtData.Rows.IndexOf(row));
                        }
                    }

                    foreach (int item in rowDelete)
                    {
                        dtData.Rows.RemoveAt(item);
                    }
                }

                DataRow drNew = dtData.NewRow();         

                drNew[indexColDisplay] = "TODOS";
                drNew[indexColValue] = 0;

                if (dtData.Columns.Contains("lVigente"))
                {
                    indexVigenteCol = dtData.Columns.IndexOf("lVigente");
                    drNew[indexVigenteCol] = 1;
                }
                
                dtData.Rows.InsertAt(drNew, 0);
            }
        }

        private void cargarTipoCredito()
        {
            var dtTipoCre = cnproducto.listarProducto(1, true);
            dtTipoCre.TableName = "dtProducto0";
            dtTipoCre.Columns.Add("Chk", typeof(bool));
            dtTipoCre.Columns["Chk"].ReadOnly = false;
            dtTipoCre.Columns["Chk"].DefaultValue = false;
            dtTipoCre.Rows.RemoveAt(0);
            dtTipoCre.AsEnumerable().ToList().ForEach(x => x["Chk"] = false);

            dtTipoCre.Columns.Remove("cCuentaContable");
            dtTipoCre.Columns.Remove("IdProductoPadre");
            dtTipoCre.Columns.Remove("lVigente");
            dtTipoCre.Columns.Remove("idModulo");
            dtTipoCre.Columns.Remove("cCodSBS");
            dtTipoCre.Columns.Remove("dVigenciaInicio");
            dtTipoCre.Columns.Remove("dVigenciaFin");
            dtTipoCre.Columns.Remove("lConfigurable");
            dtTipoCre.Columns.Remove("idFuenteCalcMora");

            dtgTipoCredito.DataSource = dtTipoCre;
            dtgTipoCredito.Enabled = true;
            dtgTipoCredito.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgTipoCredito.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTipoCredito.Columns["cProducto"].Visible = true;
            dtgTipoCredito.Columns["Chk"].Visible = true;
            dtgTipoCredito.Columns["Chk"].DisplayIndex = 0;
            dtgTipoCredito.Columns["Chk"].Width = 25;
            dtgTipoCredito.Columns["cProducto"].HeaderText = "Tipo Crédito";
            dtgTipoCredito.Columns["Chk"].HeaderText = "Sel.";

            dsProductos.Tables.Add(dtTipoCre);
        }

        private void caragarProducto(dtgBase dtgFuente, dtgBase dtgDestino, int nNivel)
        {
            var dtProdSel = ((DataTable)dtgFuente.DataSource).Clone();

            (from item in ((DataTable)dtgFuente.DataSource).AsEnumerable()
             select item).CopyToDataTable(dtProdSel, LoadOption.OverwriteChanges);

            if (dtProdSel.Rows.Count > 0)
            {
                DataSet dsProducto = new DataSet("dsProducto");
                dtProdSel.TableName = "dtProducto";
                string cxmlProducto = "";
                if (dtProdSel.DataSet == null)
                {
                    dsProducto.Tables.Add(dtProdSel);
                    cxmlProducto = dsProducto.GetXml();
                }
                else
                {
                    cxmlProducto = dtProdSel.DataSet.GetXml();
                }

                var dtSubTipoCre = cnproducto.CNListarProductoxNivel(cxmlProducto, nNivel, 1);
                dtSubTipoCre.Columns["Chk"].ReadOnly = false;


                dtgDestino.DataSource = dtSubTipoCre;
                dtgDestino.Enabled = true;
                dtgDestino.ReadOnly = false;
                foreach (DataGridViewColumn item in dtgDestino.Columns)
                {
                    item.Visible = false;
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dtgDestino.Columns["cProducto"].Visible = true;
                dtgDestino.Columns["Chk"].Visible = true;
                dtgDestino.Columns["Chk"].DisplayIndex = 0;
                dtgDestino.Columns["Chk"].Width = 25;

                dtgDestino.Columns["cProducto"].HeaderText = "Sub Tipo Crédito";
                dtgDestino.Columns["Chk"].HeaderText = "Sel.";                
            }
            else
            {
                dtgDestino.DataSource = null;
            }
        }

        private void actualizarTodosGrid(dtgBase dtgActualiza, object sender)
        {
            ((DataTable)dtgActualiza.DataSource).AsEnumerable().ToList().ForEach(x => x["Chk"] = ((chcBase)sender).Checked);
        }

        private string retornarXmlProductosSel()
        {
            dsProductos.Tables.Clear();

            var dtProdXml = ((DataTable)dtgTipoCredito.DataSource).Clone();
            dtProdXml.TableName = "dtProducto0";

            (from item in ((DataTable)dtgTipoCredito.DataSource).AsEnumerable()
             where (bool)item["Chk"] == true
             select item).CopyToDataTable(dtProdXml, LoadOption.OverwriteChanges);

            dsProductos.Tables.Add(dtProdXml);

            var dtProdXml1 = ((DataTable)this.dtgSubTipoCredito.DataSource).Clone();
            dtProdXml1.TableName = "dtProducto1";

            (from item in ((DataTable)dtgSubTipoCredito.DataSource).AsEnumerable()
             where (bool)item["Chk"] == true
             select item).CopyToDataTable(dtProdXml1, LoadOption.OverwriteChanges);
            
            dsProductos.Tables.Add(dtProdXml1);


            var dtProdXml2 = ((DataTable)this.dtgProducto.DataSource).Clone();
            dtProdXml2.TableName = "dtProducto2";

            (from item in ((DataTable)dtgProducto.DataSource).AsEnumerable()
             where (bool)item["Chk"] == true
             select item).CopyToDataTable(dtProdXml2, LoadOption.OverwriteChanges);

            dsProductos.Tables.Add(dtProdXml2);

            var dtProdXml3 = ((DataTable)this.dtgSubProducto.DataSource).Clone();
            dtProdXml3.TableName = "dtProducto3";

            (from item in ((DataTable)dtgSubProducto.DataSource).AsEnumerable()
             where (bool)item["Chk"] == true
             select item).CopyToDataTable(dtProdXml3, LoadOption.OverwriteChanges);

            dsProductos.Tables.Add(dtProdXml3);

            return dsProductos.GetXml();
        }

        #endregion        
    }
}
