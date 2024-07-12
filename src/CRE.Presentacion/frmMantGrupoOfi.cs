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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmMantGrupoOfi : frmBase
    {
        #region Variable Globales

        DataTable dtGrupoCatOfi = new DataTable("dtGrupoCat");
        DataTable dtGrupoCatRes = new DataTable("dtGrupoRes");
        clsCNCategoriaOficina cnCatOficina = new clsCNCategoriaOficina();
        int idPeriodo;
        int idEstPeriodo;
        string cPeriodo;
        int idUsuario = clsVarGlobal.User.idUsuario;
        string cNomUsu = clsVarGlobal.User.cWinUser;
        List<decimal> aMaxHist = new List<decimal>();

        #endregion

        public frmMantGrupoOfi()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmMantGrupoOfi_Load(object sender, EventArgs e)
        {

            this.cboPeriodoCateOfi1.cargarDatos(false);
            if (this.cboPeriodoCateOfi1.SelectedIndex != -1)
            {
                idPeriodo = Convert.ToInt32(this.cboPeriodoCateOfi1.SelectedValue);
                DataRowView item = (DataRowView)this.cboPeriodoCateOfi1.SelectedItem;
                cPeriodo = Convert.ToString(item["cNombre"]);
                idEstPeriodo = Convert.ToInt32(item["idEstadoCateOfi"]);
            }            

            cargarEstructuraGrupoCatOfi();

            cargarDatosGrupos();

            cargarEstructuraGridGrupoCatOfi();

            this.CalcularMinValor();
            this.CalcularMaxValor();

            CambiarEstadoControles(false);
            
            this.dtgGrupoCatOfi.DataSource = this.dtGrupoCatOfi;
            this.dtgGrupoCatOfi.Refresh();

        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            AgregarNuevoGrupo();
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (this.dtgGrupoCatOfi.Rows.Count > 0)
            {
                int nIndex = this.dtgGrupoCatOfi.SelectedRows[0].Index;
                this.dtgGrupoCatOfi.Rows.RemoveAt(nIndex);
                if (this.dtgGrupoCatOfi.Rows.Count == 0)
                {
                    this.btnMiniQuitar1.Enabled = false;
                }

                this.dtGrupoCatOfi.AcceptChanges();

                CalcularMinValor();
                CalcularMaxValor();
            }
            else
            {
                this.btnMiniQuitar1.Enabled = false;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {

            this.dtGrupoCatOfi.AcceptChanges();
            this.dtgGrupoCatOfi.Refresh();

            if (!validarCampos())
            {
                return;
            }

            List<string> aRemCol = new List<string>();
            aRemCol.Add("idPeriodoCateOfi");
            aRemCol.Add("cPeriodo");
            aRemCol.Add("nValorMin");
            aRemCol.Add("idUsuReg");
            aRemCol.Add("cUsuReg");
            aRemCol.Add("dFechaReg");
            aRemCol.Add("idUsuMod");
            aRemCol.Add("cUsuMod");
            aRemCol.Add("dFechaMod");

            DataTable dtNuevoGrupo = new DataTable("dtGrupoOficina");
            dtNuevoGrupo = this.dtGrupoCatOfi.Copy();
            dtNuevoGrupo.TableName = "dtGrupoOficina";

            foreach (string col in aRemCol)
            {
                dtNuevoGrupo.Columns.Remove(col);
            }
            dtNuevoGrupo.AcceptChanges();

            DataSet dsGrupoOfi = new DataSet("dsGrupoOfi");
            dsGrupoOfi.Tables.Add(dtNuevoGrupo);
            string xmlGrupoOfi = dsGrupoOfi.GetXml();
            xmlGrupoOfi = clsCNFormatoXML.EncodingXML(xmlGrupoOfi);
            dsGrupoOfi.Tables.Clear();

            DataTable dtResultado = cnCatOficina.GuardarGrupoOficina(idPeriodo, xmlGrupoOfi, idUsuario);

            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimeinto de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CambiarEstadoControles(false);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtGrupoCatOfi = this.dtGrupoCatRes.Copy();
            this.dtGrupoCatOfi.TableName = "dtGrupoCat";
            this.dtGrupoCatRes.TableName = "dtGrupoRes";
            this.dtgGrupoCatOfi.DataSource = this.dtGrupoCatOfi;
            this.dtgGrupoCatOfi.Refresh();

            CambiarEstadoControles(false);

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (!validarEdicion())
            {
                return;
            }
            this.CambiarEstadoControles(true);
        }

        private void dtgGrupoCatOfi_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgGrupoCatOfi.Rows.Count > 0)
            {
                int nIndex = this.dtgGrupoCatOfi.CurrentCell.ColumnIndex;
                string cNombreCol = this.dtgGrupoCatOfi.Columns[nIndex].Name;
                List<string> aCellBloq = new List<string>();
                aCellBloq.Add("nValorMin");

                if (aCellBloq.Contains(cNombreCol))
                {
                    this.dtgGrupoCatOfi.CurrentCell.Selected = false;
                }
            }
        }

        private void cboPeriodoCateOfi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPeriodoCateOfi1.SelectedIndex != -1)
            {
                idPeriodo = Convert.ToInt32(this.cboPeriodoCateOfi1.SelectedValue);
                DataRowView item = (DataRowView)this.cboPeriodoCateOfi1.SelectedItem;
                cPeriodo = Convert.ToString(item["cNombre"]);
                idEstPeriodo = Convert.ToInt32(item["idEstadoCateOfi"]);

                cargarDatosGrupos();

                this.CalcularMinValor();
                this.CalcularMaxValor();

                DataTable dt = cnCatOficina.obtenerPeriodoCateOfi(false, idPeriodo);
                this.lblValor.Text = Convert.ToString(dt.Rows[0]["cEstado"]);

                this.dtgGrupoCatOfi.DataSource = this.dtGrupoCatOfi;
                this.dtgGrupoCatOfi.Refresh();

                this.dtGrupoCatOfi.DefaultView.AllowEdit = true;
                this.dtGrupoCatOfi.DefaultView.AllowDelete = true;

                this.dtGrupoCatOfi.Columns["nValorMin"].ReadOnly = false;
            }
        }

        private void dtgGrupoCatOfi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nColIndex = e.ColumnIndex;
            if (nColIndex == 4)
            {
                CalcularMaxValor();
                CalcularMinValor();
            }
            else if (nColIndex == 5)
            {
                CalcularMinValor();
                CalcularMaxValor();
            }
        }

        private void dtgGrupoCatOfi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgGrupoCatOfi.Rows[e.RowIndex].ErrorText = String.Empty;

            if (e.ColumnIndex == 5)
            {
                decimal nMaxVal = Convert.ToDecimal(this.dtgGrupoCatOfi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                bool temp = false;
                if (this.aMaxHist.Contains(nMaxVal) && e.ColumnIndex == 5)
                {
                    temp = this.dtgGrupoCatOfi.CancelEdit();
                    //this.dtGrupoCatOfi.RejectChanges();
                    this.CalcularMinValor();
                    this.CalcularMaxValor();
                    this.dtGrupoCatOfi.AcceptChanges();
                }
            }
            this.aMaxHist.Clear();
        }

        private void dtgGrupoCatOfi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int i = 0;
                foreach (DataRow row in this.dtGrupoCatOfi.Rows)
                {
                    if (i != e.RowIndex)
                        this.aMaxHist.Add(Convert.ToDecimal(row["nValorMax"]));
                    i++;
                }
            }


        }

        private void dtgGrupoCatOfi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            clsFunUtiles clsfunutiles = new clsFunUtiles();
            clsfunutiles.validarCeldas(dtg, e);
        }

        private void dtgGrupoCatOfi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 5 && e.ColumnIndex != 1)
                return;

            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dtgGrupoCatOfi.Rows[e.RowIndex].ErrorText = "Las celdas no pueden ser vacios.";
                e.Cancel = true;
            }
        }

        #endregion

        #region Metodos
        public void cargarDatosGrupos()
        {
            this.dtGrupoCatOfi = cnCatOficina.obtenerGrupoCompCatOfi(idPeriodo);
            this.dtGrupoCatOfi.TableName = "dtGrupoCat";
            this.dtGrupoCatRes = this.dtGrupoCatOfi.Copy();
            this.dtGrupoCatRes.TableName = "dtGrupoRes";
        }

        public void cargarEstructuraGrupoCatOfi()
        {
            this.dtGrupoCatOfi.Columns.Clear();
            
            this.dtGrupoCatOfi.Columns.Add("idGrupo", typeof(int));
            this.dtGrupoCatOfi.Columns.Add("cDescripcion", typeof(string));
            this.dtGrupoCatOfi.Columns.Add("idPeriodoCateOfi", typeof(int));
            this.dtGrupoCatOfi.Columns.Add("cPeriodo", typeof(string));
            this.dtGrupoCatOfi.Columns.Add("nValorMin", typeof(decimal));
            this.dtGrupoCatOfi.Columns.Add("nValorMax", typeof(decimal));
            this.dtGrupoCatOfi.Columns.Add("idUsuReg", typeof(int));
            this.dtGrupoCatOfi.Columns.Add("cUsuReg", typeof(string));
            this.dtGrupoCatOfi.Columns.Add("dFechaReg", typeof(DateTime));
            this.dtGrupoCatOfi.Columns.Add("idUsuMod", typeof(int));
            this.dtGrupoCatOfi.Columns.Add("cUsuMod", typeof(string));
            this.dtGrupoCatOfi.Columns.Add("dFechaMod", typeof(DateTime));

        }

        public void cargarEstructuraGridGrupoCatOfi()
        {
            this.dtgGrupoCatOfi.Columns.Clear();

            CalendarColumn dFechaReg = new CalendarColumn();
            dFechaReg.Name = "dFechaReg";
            dFechaReg.HeaderText = "Fecha de Reg.";
            CalendarColumn dFechaMod = new CalendarColumn();
            dFechaMod.Name = "dFechaMod";
            dFechaMod.HeaderText = "Fecha de Mod.";
            
            this.dtgGrupoCatOfi.Columns.Add("idGrupo", "idGrupo");
            this.dtgGrupoCatOfi.Columns.Add("cDescripcion", "Nomb. Grupo");
            this.dtgGrupoCatOfi.Columns.Add("idPeriodoCateOfi", "idPeriodoCateOfi");
            this.dtgGrupoCatOfi.Columns.Add("cPeriodo", "Periodo");
            this.dtgGrupoCatOfi.Columns.Add("nValorMin", "Valor Mínimo");
            this.dtgGrupoCatOfi.Columns.Add("nValorMax", "Valor Maximo");
            this.dtgGrupoCatOfi.Columns.Add("idUsuReg", "idUsuReg");
            this.dtgGrupoCatOfi.Columns.Add("cUsuReg", "Usu. Reg.");
            this.dtgGrupoCatOfi.Columns.Add(dFechaReg);
            this.dtgGrupoCatOfi.Columns.Add("idUsuMod", "idUsuMod");
            this.dtgGrupoCatOfi.Columns.Add("cUsuMod", "cUsuMod");
            this.dtgGrupoCatOfi.Columns.Add(dFechaMod);
            
            this.dtgGrupoCatOfi.EditMode = DataGridViewEditMode.EditOnEnter;
            this.dtgGrupoCatOfi.AllowUserToAddRows = false; // 
            
            for (int i = 0; i < this.dtgGrupoCatOfi.Columns.Count; i++)
            {
                this.dtgGrupoCatOfi.Columns[i].DataPropertyName = this.dtgGrupoCatOfi.Columns[i].Name;
                this.dtgGrupoCatOfi.Columns[i].Visible = false;
                this.dtgGrupoCatOfi.Columns[i].MinimumWidth = 50;
            }
            
            this.dtGrupoCatOfi.DefaultView.AllowEdit = true;
            this.dtGrupoCatOfi.DefaultView.AllowDelete = true;
            
            this.dtgGrupoCatOfi.Columns["cDescripcion"].Visible = true;
            //this.dtgGrupoCatOfi.Columns["cPeriodo"].Visible = true;
            this.dtgGrupoCatOfi.Columns["nValorMin"].Visible = true;
            this.dtgGrupoCatOfi.Columns["nValorMax"].Visible = true;
            //this.dtgGrupoCatOfi.Columns["dFechaReg"].Visible = true;
            //this.dtgGrupoCatOfi.Columns["cUsuReg"].Visible = true;
            //this.dtgGrupoCatOfi.Columns["cUsuMod"].Visible = true;

            this.dtgGrupoCatOfi.Columns["nValorMin"].DefaultCellStyle.Format = "c";
            this.dtgGrupoCatOfi.Columns["nValorMax"].DefaultCellStyle.Format = "c";

            this.dtgGrupoCatOfi.Columns["cDescripcion"].DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);
            this.dtgGrupoCatOfi.Columns["nValorMax"].DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);

        }

        private void CalcularMinValor()
        {
            this.dtGrupoCatOfi.Columns["nValorMin"].ReadOnly = false;
            if (this.dtGrupoCatOfi.Rows.Count > 0)
            {
                List<decimal> aMaxValCol = new List<decimal>();
                foreach (DataRow dr in this.dtGrupoCatOfi.Rows)
                {
                    if ((decimal)dr["nValorMax"] > 0)
                    {
                        aMaxValCol.Add((decimal)dr["nValorMax"]);
                    }
                }

                aMaxValCol.Sort((a, b) => -1 * a.CompareTo(b));


                for (int i = 0; i < this.dtGrupoCatOfi.Rows.Count ; i++)
                {
                    decimal nMinValAnt = 0.00m;
                    for (int j = 0; j < aMaxValCol.Count ; j++)
                    {
                        if(Convert.ToDecimal(this.dtGrupoCatOfi.Rows[i]["nValorMax"]) == aMaxValCol[j])
                        {
                            nMinValAnt = (j == aMaxValCol.Count - 1) ? nMinValAnt : aMaxValCol[j + 1] + 0.01m;
                            this.dtGrupoCatOfi.Rows[i]["nValorMin"] = nMinValAnt;
                        }
                    }
                }
                

            }
        }

        private void CalcularMaxValor()
        {
            this.dtGrupoCatOfi.Columns["nValorMax"].ReadOnly = false;
            if (this.dtGrupoCatOfi.Rows.Count > 0)
            {
                decimal nMax = 999999999999.99M;

                for (int i = 0; i < this.dtGrupoCatOfi.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(this.dtGrupoCatOfi.Rows[i]["nValorMax"]) == nMax)
                    {
                        this.dtGrupoCatOfi.Rows[i]["nValorMax"] = 0.00M;
                    }
                    if (i == 0)
                    {
                        this.dtGrupoCatOfi.Rows[i]["nValorMax"] = nMax;
                    }
                }
            }
        }

        private void AgregarNuevoGrupo()
        {
            DataRow drNuevoGrupo = this.dtGrupoCatOfi.NewRow();

            drNuevoGrupo["idGrupo"] = 0;
            drNuevoGrupo["cDescripcion"] = "";
            drNuevoGrupo["idPeriodoCateOfi"] = this.idPeriodo;
            drNuevoGrupo["cPeriodo"] = this.cPeriodo;
            drNuevoGrupo["nValorMin"] = 0.00M;
            drNuevoGrupo["nValorMax"] = 0.00M;
            drNuevoGrupo["idUsuReg"] = clsVarGlobal.User.idUsuario;
            drNuevoGrupo["cUsuReg"] = clsVarGlobal.User.cWinUser;
            drNuevoGrupo["dFechaReg"] = DateTime.Now;
            drNuevoGrupo["idUsuMod"] = DBNull.Value;
            drNuevoGrupo["cUsuMod"] = DBNull.Value;
            drNuevoGrupo["dFechaMod"] = DBNull.Value;

            this.dtGrupoCatOfi.Rows.Add(drNuevoGrupo);

            this.CalcularMinValor();
            this.CalcularMaxValor();

            this.dtGrupoCatOfi.AcceptChanges();

            this.btnMiniQuitar1.Enabled = true;

        }

        private void CambiarEstadoControles(bool lActivo)
        {
            this.dtGrupoCatOfi.Columns["nValorMin"].ReadOnly = false;
            List<string> aColBloq = new List<string>();
            aColBloq.Add("nValorMin");

            this.cboPeriodoCateOfi1.Enabled = !lActivo;

            this.btnMiniAgregar1.Enabled = lActivo;
            this.btnMiniQuitar1.Enabled = lActivo;
            this.btnGrabar1.Enabled = lActivo;
            this.btnCancelar1.Enabled = lActivo;
            this.btnEditar1.Enabled = !lActivo;

            this.dtgGrupoCatOfi.ReadOnly = !lActivo;

            if (lActivo)
            {
                this.dtgGrupoCatOfi.CellBeginEdit -= this.dtgGrupoCatOfi_CellBeginEdit;
                this.dtgGrupoCatOfi.CellEndEdit -= this.dtgGrupoCatOfi_CellEndEdit;
                foreach (string cNombColBloq in aColBloq)
                {
                    this.dtgGrupoCatOfi.Columns[cNombColBloq].ReadOnly = true;
                }
            }
            else
            {
                this.dtgGrupoCatOfi.CellBeginEdit += this.dtgGrupoCatOfi_CellBeginEdit;
                this.dtgGrupoCatOfi.CellEndEdit += this.dtgGrupoCatOfi_CellEndEdit;
            }
            
        }

        private void OrdenarGrupos()
        {
            DataTable dtGrupoOrd = this.dtGrupoCatOfi.Copy();
            dtGrupoOrd.TableName = "dtGrupoOrd";

            DataRow[] drGrupos = dtGrupoOrd.Select(null, "nValorMax ASC", DataViewRowState.CurrentRows);

            this.dtGrupoCatOfi.Rows.Clear();

            foreach (DataRow drGrupo in drGrupos)
            {
                this.dtGrupoCatOfi.ImportRow(drGrupo);
            }

            this.dtGrupoCatOfi.AcceptChanges();
            this.dtgGrupoCatOfi.DataSource = this.dtGrupoCatOfi;
            this.dtgGrupoCatOfi.Refresh();
        }
        private bool validarCampos()
        {

            foreach (DataRow drData in this.dtGrupoCatOfi.Rows)
            {
                if (drData["cDescripcion"].ToString() == String.Empty)
                {
                    MessageBox.Show("El campo del Nombre del Grupo no puede estar en blanco", "Mantenimeinto de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (drData["nValorMax"].ToString() == String.Empty || Convert.ToDecimal(drData["nValorMax"]) <= 0.00M)
                {
                    MessageBox.Show("El Monto máximo debe ser mayor a cero", "Mantenimiento de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (!verificarDuplicado())
            {
                MessageBox.Show("Valores Duplicados en la columna de Monto Máximo", "Mantenimiento de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            return true;
        }

        public bool validarEdicion()
        {
            if (this.idEstPeriodo != 2)
            {
                MessageBox.Show("No se permite la edicion de grupos cuando el estado del periodo no esta en Pendiente", "Mantenimiento de grupos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private Boolean verificarDuplicado()
        {
            List<decimal> nValorMax = new List<decimal>();
            Boolean lReturn = false;
            for (int i = 0; i < dtgGrupoCatOfi.Rows.Count; i++)
            {
                if (nValorMax.Contains(Convert.ToDecimal(dtgGrupoCatOfi.Rows[i].Cells["nValorMax"].Value)))
                {
                    nValorMax.Add(Convert.ToDecimal(dtgGrupoCatOfi.Rows[i].Cells["nValorMax"].Value));
                    return false;
                }
                else
                {
                    nValorMax.Add(Convert.ToDecimal(dtgGrupoCatOfi.Rows[i].Cells["nValorMax"].Value));
                    lReturn = true;
                }
            }
            return lReturn;
        }
        #endregion

        private void dtgGrupoCatOfi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dtgGrupoCatOfi.IsCurrentCellDirty)
            //{
            //    dtgGrupoCatOfi.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

    }
}

