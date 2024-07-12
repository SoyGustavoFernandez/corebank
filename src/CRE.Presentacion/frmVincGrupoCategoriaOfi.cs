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
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmVincGrupoCategoriaOfi : frmBase
    {
        #region Variables Globales

        clsCNCategoriaOficina cnCatOficina = new clsCNCategoriaOficina();
        int idPeriodo;
        int idEstPeriodo;
        string cPeriodo;
        int idUsuario = clsVarGlobal.User.idUsuario;
        string cNomUsu = clsVarGlobal.User.cWinUser;
        DataTable dtVincGrupoCateOfi = new DataTable("dtVincGrupoCate");
        DataTable dtVincGrupoCateOfiRes = new DataTable("dtVincGrupoCateRes");
        List<decimal> lValoresMaximoHistorico = new List<decimal>();
        decimal nMaxHistorico;
        String cTitulo = "Vinculación de grupo con categoría";
        #endregion
        public frmVincGrupoCategoriaOfi()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmVincGrupoCategoriaOfi_Load(object sender, EventArgs e)
        {
            this.Text = cTitulo;
            this.cargarEstructuraVincGrupoCateOfi();

            this.cboPeriodoCateOfi1.cargarDatos(false);

            if (this.cboPeriodoCateOfi1.SelectedIndex != -1)
            {
                idPeriodo = Convert.ToInt32(this.cboPeriodoCateOfi1.SelectedValue);
                DataRowView item = (DataRowView)this.cboPeriodoCateOfi1.SelectedItem;
                cPeriodo = Convert.ToString(item["cNombre"]);
                idEstPeriodo = Convert.ToInt32(item["idEstadoCateOfi"]);
            }

            this.cargarEstructuraGridVincGrupoCateOfi();

            this.ProcesarVincActual(idPeriodo);
            calcularValoresMinimos();
            CambiarEstadoControles(false);


            //this.dtgVincGrupoCateOfi.DataSource = this.dtVincGrupoCateOfi;
            //this.dtgVincGrupoCateOfi.Refresh();


        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (!validarEdicion())
            {
                return;
            }
            this.CambiarEstadoControles(true);

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.dtVincGrupoCateOfi.AcceptChanges();
            this.dtgVincGrupoCateOfi.Refresh();

            if (!verificarPorcentajeMaximo())
            {
                return;
            }

            List<string> aRemCol = new List<string>();
            aRemCol.Add("cPeriodo");
            aRemCol.Add("cGrupo");
            aRemCol.Add("cCategoria");
            aRemCol.Add("nValorMin");
            aRemCol.Add("idUsuReg");
            aRemCol.Add("cUsuReg");
            aRemCol.Add("dFechaReg");
            aRemCol.Add("idUsuMod");
            aRemCol.Add("cUsuMod");
            aRemCol.Add("dFechaMod");

            DataTable dtNuevaVinc = new DataTable("dtVincGrupoCate");
            dtNuevaVinc = this.dtVincGrupoCateOfi.Copy();
            dtNuevaVinc.TableName = "dtVincGrupoCate";

            foreach (string col in aRemCol)
            {
                dtNuevaVinc.Columns.Remove(col);
            }
            dtNuevaVinc.AcceptChanges();

            DataSet dsVincGrupoCate = new DataSet("dsVincGrupoCate");
            dsVincGrupoCate.Tables.Add(dtNuevaVinc);
            string xmlVincGrupoCate = dsVincGrupoCate.GetXml();
            xmlVincGrupoCate = clsCNFormatoXML.EncodingXML(xmlVincGrupoCate);
            dsVincGrupoCate.Tables.Clear();

            DataTable dtResultado = cnCatOficina.GuardarVincGrupoCat(idPeriodo, xmlVincGrupoCate, idUsuario);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTitulo, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

            ProcesarVincActual(idPeriodo);

            calcularValoresMinimos();

            CambiarEstadoControles(false);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtVincGrupoCateOfi = this.dtVincGrupoCateOfiRes;
            this.dtVincGrupoCateOfi.TableName = "dtVincGrupoCate";
            this.dtgVincGrupoCateOfi.DataSource = this.dtVincGrupoCateOfi;
            this.dtgVincGrupoCateOfi.Refresh();
            calcularValoresMinimos();
            CambiarEstadoControles(false);
        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {

            ProcesarVincActual(idPeriodo);

        }
        private void dtgVincGrupoCateOfi_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgVincGrupoCateOfi.Rows.Count > 0)
            {
                int nIndex = this.dtgVincGrupoCateOfi.CurrentCell.ColumnIndex;
                string cNombreCol = this.dtgVincGrupoCateOfi.Columns[nIndex].Name;

                List<string> aCellBloq = new List<string>();
                aCellBloq.Add("cPeriodo");
                aCellBloq.Add("cGrupo");
                aCellBloq.Add("cCategoria");
                aCellBloq.Add("cUsuReg");
                aCellBloq.Add("cUsuMod");

                if (aCellBloq.Contains(cNombreCol))
                {
                    this.dtgVincGrupoCateOfi.CurrentCell.Selected = false;
                }
            }
        }
        private void dtgVincGrupoCateOfi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // calcularValoresMinimos();
        }
        private void cboPeriodoCateOfi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPeriodoCateOfi1.SelectedIndex != -1)
            {
                idPeriodo = Convert.ToInt32(this.cboPeriodoCateOfi1.SelectedValue);
                DataRowView item = (DataRowView)this.cboPeriodoCateOfi1.SelectedItem;
                cPeriodo = Convert.ToString(item["cNombre"]);
                idEstPeriodo = Convert.ToInt32(item["idEstadoCateOfi"]);

                DataTable dt = cnCatOficina.obtenerPeriodoCateOfi(false, idPeriodo);
                this.lblValor.Text = Convert.ToString(dt.Rows[0]["cEstado"]);

                this.dtVincGrupoCateOfi = cnCatOficina.ListarVincGrupoCateOfi(idPeriodo);
                this.dtVincGrupoCateOfiRes = this.dtVincGrupoCateOfi.Copy();
                this.dtVincGrupoCateOfiRes.TableName = "dtVincGrupoCateRes";

                //this.CalcularMinValores();
                //this.CalcularMaxValores();

                this.dtgVincGrupoCateOfi.DataSource = this.dtVincGrupoCateOfi;
                this.dtgVincGrupoCateOfi.Refresh();

                this.dtVincGrupoCateOfi.DefaultView.AllowDelete = true;
                this.dtVincGrupoCateOfi.DefaultView.AllowEdit = true;

                this.dtVincGrupoCateOfi.Columns["nValorMin"].ReadOnly = true;
                calcularValoresMinimos();
            }
        }
        private void dtgVincGrupoCateOfi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgVincGrupoCateOfi.Rows[e.RowIndex].ErrorText = String.Empty;
            verificarEdicionCelda(e.RowIndex);
        }
        private void dtgVincGrupoCateOfi_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int idGrupo = Convert.ToInt16(dtgVincGrupoCateOfi.Rows[e.RowIndex].Cells["idGrupo"].Value);
            decimal nMax = Convert.ToDecimal(dtgVincGrupoCateOfi.Rows[e.RowIndex].Cells["nValorMax"].Value);
            nMaxHistorico = nMax;
            almacenarHistorico(idGrupo, nMax);
        }
        private void dtgVincGrupoCateOfi_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgVincGrupoCateOfi.Columns["lvigente"].Index)
            {
                calcularValoresMinimos();
            }

        }
        private void dtgVincGrupoCateOfi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dtgVincGrupoCateOfi.Rows[e.RowIndex].ErrorText =
                    "Las celdas no pueden ser vacios.";
                e.Cancel = true;
            }
        }
        private void dtgVincGrupoCateOfi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgVincGrupoCateOfi.IsCurrentCellDirty)
            {
                dtgVincGrupoCateOfi.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dtgVincGrupoCateOfi_Sorted(object sender, EventArgs e)
        {
            calcularValoresMinimos();
        }
        private void dtgVincGrupoCateOfi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            clsFunUtiles clsfunutiles = new clsFunUtiles();
            clsfunutiles.validarCeldas(dtg, e);
        }
        #endregion
        #region Metodos
        private void cargarEstructuraVincGrupoCateOfi()
        {
            this.dtVincGrupoCateOfi.Columns.Clear();

            this.dtVincGrupoCateOfi.Columns.Add("idGrupoCategoriaOfi",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("idPeriodoCateOfi",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("cPeriodo",typeof(string));
            this.dtVincGrupoCateOfi.Columns.Add("idGrupo",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("cGrupo",typeof(string));
            this.dtVincGrupoCateOfi.Columns.Add("idCategoria",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("cCategoria",typeof(string));
            this.dtVincGrupoCateOfi.Columns.Add("nValorMin",typeof(decimal));
            this.dtVincGrupoCateOfi.Columns.Add("nValorMax",typeof(decimal));
            this.dtVincGrupoCateOfi.Columns.Add("idUsuReg",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("cUsuReg",typeof(string));
            this.dtVincGrupoCateOfi.Columns.Add("dFechaReg",typeof(DateTime));
            this.dtVincGrupoCateOfi.Columns.Add("idUsuMod",typeof(int));
            this.dtVincGrupoCateOfi.Columns.Add("cUsuMod",typeof(string));
            this.dtVincGrupoCateOfi.Columns.Add("dFechaMod",typeof(DateTime));
            this.dtVincGrupoCateOfi.Columns.Add("lVigente",typeof(bool));

        }
        private void cargarEstructuraGridVincGrupoCateOfi()
        {
            this.dtgVincGrupoCateOfi.Columns.Clear();

            CalendarColumn dFechaReg = new CalendarColumn();
            dFechaReg.Name = "dFechaReg";
            dFechaReg.HeaderText = "dFechaReg";
            CalendarColumn dFechaMod = new CalendarColumn();
            dFechaMod.Name = "dFechaMod";
            dFechaMod.HeaderText = "dFechaMod";

            DataGridViewCheckBoxColumn lVigente = new DataGridViewCheckBoxColumn();
            lVigente.Name = "lVigente";
            lVigente.HeaderText = "Vigencia";

            this.dtgVincGrupoCateOfi.Columns.Add("idGrupoCategoriaOfi", "idGrupoCategoriaOfi");
            this.dtgVincGrupoCateOfi.Columns.Add("idPeriodoCateOfi", "idPeriodoCateOfi");
            this.dtgVincGrupoCateOfi.Columns.Add("cPeriodo", "cPeriodo");
            this.dtgVincGrupoCateOfi.Columns.Add("idGrupo", "idGrupo");
            this.dtgVincGrupoCateOfi.Columns.Add("cGrupo", "Grupo");
            this.dtgVincGrupoCateOfi.Columns.Add("idCategoria", "idCategoria");
            this.dtgVincGrupoCateOfi.Columns.Add("cCategoria", "Categoría");
            this.dtgVincGrupoCateOfi.Columns.Add("nValorMin", "% Mora mínima");
            this.dtgVincGrupoCateOfi.Columns.Add("nValorMax", "% Mora máxima");
            this.dtgVincGrupoCateOfi.Columns.Add("idUsuReg", "idUsuReg");
            this.dtgVincGrupoCateOfi.Columns.Add("cUsuReg", "cUsuReg");
            this.dtgVincGrupoCateOfi.Columns.Add(dFechaReg);
            this.dtgVincGrupoCateOfi.Columns.Add("idUsuMod", "idUsuMod");
            this.dtgVincGrupoCateOfi.Columns.Add("cUsuMod", "cUsuMod");
            this.dtgVincGrupoCateOfi.Columns.Add(dFechaMod);
            this.dtgVincGrupoCateOfi.Columns.Add(lVigente);

            this.dtgVincGrupoCateOfi.EditMode = DataGridViewEditMode.EditOnEnter;
            for (int i = 0; i < this.dtgVincGrupoCateOfi.Columns.Count; i++)
            {
                this.dtgVincGrupoCateOfi.Columns[i].DataPropertyName = this.dtgVincGrupoCateOfi.Columns[i].Name;
                this.dtgVincGrupoCateOfi.Columns[i].Visible = false;
                this.dtgVincGrupoCateOfi.Columns[i].MinimumWidth = 50;
            }

            this.dtVincGrupoCateOfi.DefaultView.AllowEdit = true;
            this.dtVincGrupoCateOfi.DefaultView.AllowDelete = true;

            this.dtgVincGrupoCateOfi.Columns["cPeriodo"].Visible = false;
            this.dtgVincGrupoCateOfi.Columns["cGrupo"].Visible = true;
            this.dtgVincGrupoCateOfi.Columns["cCategoria"].Visible = true;
            this.dtgVincGrupoCateOfi.Columns["nValorMin"].Visible = true;
            this.dtgVincGrupoCateOfi.Columns["nValorMax"].Visible = true;
            this.dtgVincGrupoCateOfi.Columns["cUsuReg"].Visible = false;
            this.dtgVincGrupoCateOfi.Columns["cUsuMod"].Visible = false;
            this.dtgVincGrupoCateOfi.Columns["lVigente"].Visible = true;
            this.dtgVincGrupoCateOfi.Columns["nValorMax"].DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);

        }
        private void CambiarEstadoControles(bool lActivo)
        {

            List<string> aColBloq = new List<string>();
            aColBloq.Add("cPeriodo");
            aColBloq.Add("cGrupo");
            aColBloq.Add("cCategoria");
            aColBloq.Add("cUsuReg");
            aColBloq.Add("cUsuMod"); 
            aColBloq.Add("nValorMin"); 

            this.cboPeriodoCateOfi1.Enabled = !lActivo;

            this.btnGrabar1.Enabled = lActivo;
            this.btnCancelar1.Enabled = lActivo;
            this.btnEditar1.Enabled = !lActivo;
            //this.btnSalir1.Enabled = lActivo;

            this.dtgVincGrupoCateOfi.ReadOnly = !lActivo;

            if (lActivo)
            {
                foreach (string cNombColBLoq in aColBloq)
                {
                    this.dtgVincGrupoCateOfi.Columns[cNombColBLoq].ReadOnly = true;
                }
            }

        }
        private void ProcesarVincActual(int idPeriodo)
        {
            // Procesaiento de la Vinculacion con los parametros actuales
            // Ordenado por Grupo, Agencia

            this.dtVincGrupoCateOfi = cnCatOficina.ListarVincGrupoCateOfi(idPeriodo);
            this.dtVincGrupoCateOfi.TableName = "dtVincGrupoCate";
            this.dtVincGrupoCateOfiRes = this.dtVincGrupoCateOfi.Copy();
            this.dtVincGrupoCateOfiRes.TableName = "dtVincGrupoCateRes";



            // Calcular Valores Min y Max
            this.dtgVincGrupoCateOfi.DataSource = this.dtVincGrupoCateOfi;
            this.dtgVincGrupoCateOfi.Refresh();

        }
        public bool validarEdicion()
        {
            if (this.idEstPeriodo != 2)
            {
                MessageBox.Show("No se permite la edicion de grupos cuando el estado del periodo no esta en Pendiente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        public void calcularValoresMinimos()
        {
            this.dtVincGrupoCateOfi.Columns["nValorMin"].ReadOnly = false;
            for (int i = 0; i < dtgVincGrupoCateOfi.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgVincGrupoCateOfi.Rows[i].Cells["lvigente"].Value) == true)
                {
                    int idGrupo = Convert.ToInt16(dtgVincGrupoCateOfi.Rows[i].Cells["idGrupo"].Value);
                    decimal nMaximo = Convert.ToDecimal(dtgVincGrupoCateOfi.Rows[i].Cells["nValorMax"].Value);
                    decimal nValor = calcular(idGrupo, nMaximo);
                    dtgVincGrupoCateOfi.Rows[i].Cells["nValorMin"].Value = nValor;
                }

            }
            this.dtVincGrupoCateOfi.Columns["nValorMin"].ReadOnly = true;
        }
        public decimal calcular(int idGrupo, decimal nMaximo)
        {
            decimal nRetornar = 0;
                var results = from fila in dtVincGrupoCateOfi.AsEnumerable()
                              where fila.Field<int>("idGrupo") == idGrupo
                                && fila.Field<Boolean>("lVigente") == true
                              select fila;
                List<decimal> lValoresMaximo = new List<decimal>();
                foreach (DataRow item in results)
                {
                    lValoresMaximo.Add(Convert.ToDecimal(item["nValorMax"]));
                }
                lValoresMaximo.Sort();
            System.Console.WriteLine(lValoresMaximo);
            for (int i = 0; i < lValoresMaximo.Count; i++)
            {
                if (lValoresMaximo[i] == nMaximo)
                {
                    if (i == 0)
                    {
                        nRetornar = 0.00m;
                    }
                    else
                    {
                        nRetornar = lValoresMaximo[i - 1] + 0.01m;
                    }

                }
            }
            return nRetornar;

        }
        private void almacenarHistorico(int idGrupo, decimal nMax)
        {
            var results = from fila in dtVincGrupoCateOfi.AsEnumerable()
                          where fila.Field<int>("idGrupo") == idGrupo
                          && fila.Field<Boolean>("lVigente") == true
                          select fila;
            foreach (DataRow item in results)
            {
                if (!(Convert.ToDecimal(item["nValorMax"]) == nMax))
                {
                    lValoresMaximoHistorico.Add(Convert.ToDecimal(item["nValorMax"]));
                }
            }
        }
        private void verificarEdicionCelda(int nFila)
        {
            decimal nMax = Convert.ToDecimal(dtgVincGrupoCateOfi.Rows[nFila].Cells["nValorMax"].Value);
            if (!lValoresMaximoHistorico.Contains(nMax))
            {
                calcularValoresMinimos();
            }
            else
            {
                dtgVincGrupoCateOfi.CancelEdit();
                dtgVincGrupoCateOfi.Rows[nFila].Cells["nValorMax"].Value = nMaxHistorico;
            }
            lValoresMaximoHistorico.Clear();
            nMaxHistorico = 0;
        }
        private Boolean verificarPorcentajeMaximo()
        {
            Boolean lRetornar = false;
            List<int> idGrupo = new List<int>();
            
            for (int i = 0; i < dtgVincGrupoCateOfi.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgVincGrupoCateOfi.Rows[i].Cells["lvigente"].Value) == true)
                {
                    if (!idGrupo.Contains(Convert.ToInt16(dtgVincGrupoCateOfi.Rows[i].Cells["idGrupo"].Value)))
                        {
                            idGrupo.Add(Convert.ToInt16(dtgVincGrupoCateOfi.Rows[i].Cells["idGrupo"].Value));
                        }
                }
            }
            foreach (int item in idGrupo)
            {
                List<decimal> nMaximo = new List<decimal>();
                nMaximo.Clear();
                for (int i = 0; i < dtgVincGrupoCateOfi.Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(dtgVincGrupoCateOfi.Rows[i].Cells["lvigente"].Value) == true) && (Convert.ToInt16(dtgVincGrupoCateOfi.Rows[i].Cells["idGrupo"].Value) == item))
                    {

                        if (!nMaximo.Contains(Convert.ToDecimal(dtgVincGrupoCateOfi.Rows[i].Cells["nValorMax"].Value)))
                        {
                            nMaximo.Add(Convert.ToDecimal(dtgVincGrupoCateOfi.Rows[i].Cells["nValorMax"].Value));
                        }
                        else
                        {
                            MessageBox.Show("En un grupo existe valor máximo por duplicado.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
                if (nMaximo.Contains(0m))
                {
                    MessageBox.Show("En la columna de valores máximos no debe existir valores iguales o inferiores a 0.00", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (nMaximo.Contains(100.00m))
                {
                    lRetornar = true;
                }
                else
                {
                    MessageBox.Show("En cada grupo debe existir un valor máximo de 100 que representa el 100%.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            
            return lRetornar;
        }
        #endregion
    }
}
