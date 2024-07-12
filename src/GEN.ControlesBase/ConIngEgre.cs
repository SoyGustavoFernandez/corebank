using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class ConIngEgre : UserControl
    {
        #region Variables
        
        clsCNEvalConsumo cnConsumo = new clsCNEvalConsumo();
        clsCNMoneda cnMoneda = new clsCNMoneda();

        clsEvalCred oEvalCred;

        public DataTable dtIngresos;
        public DataTable dtEgresos;

        public int idEvalCre = 0;
        Decimal nTipoDeCambio = 0.00m;

        string cTituloMensaje = "Ingresos y egresos";

        public event DataGridViewCellEventHandler eHandlerCambioIngrEgre;
        public event EventHandler eClickAgregarBorrar;

        private int idTipEvalCre = 0;

        #endregion
        public ConIngEgre()
        {
            InitializeComponent();
        }

        #region Metodos

        public void limpiar()
        {
            if (dtIngresos != null)
                dtIngresos.Clear();
            if (dtEgresos != null)
                dtEgresos.Clear();
            idEvalCre = 0;
            nTipoDeCambio = 0.00m;
        }
        
        public void cargarIngEgrDataTable(DataTable dtDet, Decimal nTipCamb, int idTipEvalCre = 1, clsEvalCred objEvalCred  = null)
        {
            this.idTipEvalCre = idTipEvalCre;
            this.visualizarComponentes(idTipEvalCre);

            dtgIngreso.CellClick -= dtgIngreso_CellClick;
           
            oEvalCred = objEvalCred;
            DataTable dtDetIngEgr;

            nTipoDeCambio = nTipCamb;

            DistribuirIngrEgre(dtDet);

            foreach (DataColumn item in dtIngresos.Columns)
                item.ReadOnly = false;

            foreach (DataColumn item in dtEgresos.Columns)
                item.ReadOnly = false;


            dtgIngreso.DataSource = dtIngresos;
            dtgEgreso.DataSource = dtEgresos;

            dtDetIngEgr = cnConsumo.CNListarDetIngEgr(idTipEvalCre);
            DataSet dsDet = DistribuirDetIngEgr(dtDetIngEgr);

            /* ----------------------------------------------------------------------------------------
             * Creando el cbo detalle Ingr en el data grid de ingresos
             * ----------------------------------------------------------------------------------------*/
            DataGridViewComboBoxColumn dtgCboDetIng = new DataGridViewComboBoxColumn();
            dtgCboDetIng.HeaderText = "Detalle";
            dtgCboDetIng.Name = "cboDetalleIngEgr";
            dtgCboDetIng.MaxDropDownItems = 3;
            dtgCboDetIng.DisplayMember = dsDet.Tables["dtDetIng"].Columns[1].ToString();
            dtgCboDetIng.ValueMember = dsDet.Tables["dtDetIng"].Columns[0].ToString();
            dtgCboDetIng.DataSource = dsDet.Tables["dtDetIng"];

            dtgIngreso.Columns.Add(dtgCboDetIng);

            DataTable dtMoneda = cnMoneda.listarMoneda();
            DataGridViewComboBoxColumn dtgMoneda = new DataGridViewComboBoxColumn();
            dtgMoneda.HeaderText = "M.";
            dtgMoneda.Name = "cboMoneda";
            dtgMoneda.MaxDropDownItems = 3;
            dtgMoneda.DisplayMember = dtMoneda.Columns[5].ToString();
            dtgMoneda.ValueMember = dtMoneda.Columns[0].ToString();
            dtgMoneda.DataSource = dtMoneda;

            dtgIngreso.Columns.Add(dtgMoneda);


            /* ----------------------------------------------------------------------------------------
             Creando el cbo detalle Egre en el data grid deegresos
             * ----------------------------------------------------------------------------------------*/
            DataGridViewComboBoxColumn dtgCboDetEgr = new DataGridViewComboBoxColumn();
            dtgCboDetEgr.HeaderText = "Detalle";
            dtgCboDetEgr.Name = "cboDetalleIngEgr";
            dtgCboDetEgr.MaxDropDownItems = 3;
            dtgCboDetEgr.DisplayMember = dsDet.Tables["dtDetEgr"].Columns[1].ToString();
            dtgCboDetEgr.ValueMember = dsDet.Tables["dtDetEgr"].Columns[0].ToString();
            dtgCboDetEgr.DataSource = dsDet.Tables["dtDetEgr"];

            dtgEgreso.Columns.Add(dtgCboDetEgr);

            DataGridViewComboBoxColumn dtgMoneda2 = new DataGridViewComboBoxColumn();
            dtgMoneda2.HeaderText = "M.";
            dtgMoneda2.Name = "cboMoneda";
            dtgMoneda2.MaxDropDownItems = 3;
            dtgMoneda2.DisplayMember = dtMoneda.Columns[5].ToString();
            dtgMoneda2.ValueMember = dtMoneda.Columns[0].ToString();
            dtgMoneda2.DataSource = dtMoneda;

            dtgEgreso.Columns.Add(dtgMoneda2);

            formatoGrid(dtgIngreso);
            formatoGrid(dtgEgreso);

            actualizarCombosDeGrid(dtgIngreso);
            actualizarCombosDeGrid(dtgEgreso);

            dtgIngreso.CellClick += dtgIngreso_CellClick;
        }

        public void cargarIngresosEgresos(int idEval, Decimal nTipCamb)
        {
            idEvalCre = idEval;
            cargarIngEgrDataTable(cnConsumo.CNListarIngEgre(idEvalCre), nTipCamb);
        }

        public void DistribuirIngrEgre(DataTable dt)
        {
            dtEgresos = dt.Clone();
            dtIngresos = dt.Clone();

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["IdTipIngEgr"]) == 1)
                {
                    dtIngresos.ImportRow(item);
                }
                else
                {
                    dtEgresos.ImportRow(item);
                }
            }
        }

        private void visualizarComponentes(int idTipEvalCre)
        {
            switch (idTipEvalCre)
            {
                case 1:
                    this.gbxEgresos.Visible = false; 
                    break;
                default:
                    this.gbxEgresos.Visible = true; 
                    break;
            }
        }

        private DataSet DistribuirDetIngEgr(DataTable dt)
        {
            DataSet ds = new DataSet();
            DataTable dtDetIng = dt.Clone(),
                      dtDetEgr = dt.Clone();

            dtDetIng.TableName = "dtDetIng";
            dtDetEgr.TableName = "dtDetEgr";

            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["idTipIngEgre"]) == 1)
                {
                    dtDetIng.ImportRow(item);
                }
                else
                {
                    dtDetEgr.ImportRow(item);
                }
            }

            ds.Tables.Add(dtDetEgr);
            ds.Tables.Add(dtDetIng);

            return ds;
        }

        private void formatoGrid(DataGridView dtg)
        {
            dtg.ReadOnly = false;
            foreach (DataGridViewColumn item in dtg.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = false;
            }
            dtg.Columns["nMontoFlujo"].Visible = true;
            dtg.Columns["nPorcPartFlujo"].Visible = true;
            dtg.Columns["cboDetalleIngEgr"].Visible = true;
            dtg.Columns["cboMoneda"].Visible = true;
            dtg.Columns["nMontoTipCambio"].Visible = true;

            dtg.Columns["nMontoFlujo"].HeaderText = "Monto";
            dtg.Columns["nPorcPartFlujo"].HeaderText = "Part";
            dtg.Columns["nMontoTipCambio"].HeaderText = "M. (S/.)";

            dtg.Columns["cboDetalleIngEgr"].DisplayIndex = 1;
            dtg.Columns["cboMoneda"].DisplayIndex = 2;

            dtg.Columns["cboDetalleIngEgr"].Width = 170;
            //dtg.Columns["cboMoneda"].Visible = true;

            dtg.Columns["nPorcPartFlujo"].ReadOnly = true;
            dtg.Columns["nMontoTipCambio"].ReadOnly = true;

            dtg.Columns["nMontoFlujo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtg.Columns["nMontoFlujo"].DefaultCellStyle.Format = "N2";
            dtg.Columns["nMontoTipCambio"].DefaultCellStyle.Format = "N2";
            dtg.Columns["nPorcPartFlujo"].DefaultCellStyle.Format = "P2";

            dtg.Columns["nMontoTipCambio"].HeaderText = "M. (S/.)";
        }

        private void actualizarCombosDeGrid(DataGridView dtg)
        {
            foreach (DataGridViewRow item in dtg.Rows)
            {
                if (item.Cells["idDetalle"].Value != DBNull.Value)
                {
                    if (Convert.ToInt32(item.Cells["idDetalle"].Value) != 0)
                    {
                        item.Cells["cboDetalleIngEgr"].Value = Convert.ToInt32(item.Cells["idDetalle"].Value);
                    }
                }
                if (item.Cells["IdMoneda"].Value != DBNull.Value)
                {
                        if(Convert.ToInt32(item.Cells["IdMoneda"].Value) != 0)
                    {
                        item.Cells["cboMoneda"].Value = Convert.ToInt32(item.Cells["IdMoneda"].Value);
                    }
                }

                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) == DEINGREGRE.OtrosIngresos)
                {
                    item.Cells["nMontoFlujo"].ReadOnly = true;
                }
            }
        }

        private void agregarFila(DataTable dt, DataGridView dtg, int idTipoIngrEgre)
        {
            DataRow dr = dt.NewRow();
            dr["IdDetalleEvalCon"] = 0;
            dr["idEvalCre"] = idEvalCre;
            dr["IdTipIngEgr"] = idTipoIngrEgre;
            dr["IdTipPerDet"] = 0;
            dr["IdMoneda"] = 0;
            dr["nMontoFlujo"] = 0.00m;
            dr["nPorcPartFlujo"] = 0.00m;
            dr["lVigente"] = true;
            dr["idDetalle"] = 0;
            dr["nMontoTipCambio"] = 0.00m;
            dr["idDetalle"] = 0;

            dt.Rows.Add(dr);
            //formatoGrid(dtg);
        }

        private void quitarFila(DataGridView dtg, DataTable dt)
        {
            if (dtg.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                int nFila = Convert.ToInt32(dtg.SelectedCells[0].RowIndex);
                dtg.Rows.RemoveAt(nFila);
                actualizarDt(dtg, dt);
                dt.AcceptChanges();
                actualizarCombosDeGrid(dtg);
            }
        }
        
        private void actualizarDt(DataGridView dtg, DataTable dt)
        {
            foreach (DataGridViewRow item in dtg.Rows)
            {
                if (dt.Rows[item.Index].RowState.ToString() != "Deleted")
                {
                    dt.Rows[item.Index]["idMoneda"] = Convert.ToInt32(item.Cells["cboMoneda"].Value);
                    dt.Rows[item.Index]["idDetalle"] = Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value);
                }
            }
        }

        private void currentCellDirty(DataGridView dtg)
        {
            if (dtg.IsCurrentCellDirty)
            {
                // dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                // // dtg.Rows[dtg.CurrentCell.RowIndex].Cells[dtg.CurrentCell.ColumnIndex]
                // dtg.BeginEdit(false);
            }
        }

        private void calcularParticiPorcentual(DataGridView dtg)
        {
            Decimal nTotal = calcularTotalDetaIngEgr(dtg);
            foreach (DataGridViewRow item in dtg.Rows)
            {
                if (nTotal > 0)
                {
                    if (Convert.ToDecimal(item.Cells["cboMoneda"].Value) == 2)
                    {
                        item.Cells["nPorcPartFlujo"].Value = (Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) * nTipoDeCambio) / nTotal;
                        item.Cells["nMontoTipCambio"].Value = Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) * nTipoDeCambio;
                    }
                    else
                    {
                        item.Cells["nPorcPartFlujo"].Value = Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) / nTotal;
                        item.Cells["nMontoTipCambio"].Value = Convert.ToDecimal(item.Cells["nMontoFlujo"].Value);
                    }
                }
            }
        }

        private decimal calcularTotalDetaIngEgr(DataGridView dtg)
        {
            decimal nTotalDet = 0;
            foreach (DataGridViewRow item in dtg.Rows)
            {
                nTotalDet += (Convert.ToDecimal(item.Cells["cboMoneda"].Value) == 1) ? Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) : Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) * nTipoDeCambio;
            }
            return nTotalDet;
        }

        public DataTable obtIngresos()
        {
            int i = 0;
            foreach (DataRow item in dtIngresos.Rows)
            {
                item["IdMoneda"] = Convert.ToInt32(dtgIngreso.Rows[i].Cells["cboMoneda"].Value);
                item["idDetalle"] = Convert.ToInt32(dtgIngreso.Rows[i].Cells["cboDetalleIngEgr"].Value);
                item["nMontoFlujo"] = Convert.ToDecimal(dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value);
                i++;
            }
            return dtIngresos;
        }


        public DataTable obtEgresos()
        {
            int i = 0;
            foreach (DataRow item in dtEgresos.Rows)
            {
                item["IdMoneda"] = Convert.ToInt32(dtgEgreso.Rows[i].Cells["cboMoneda"].Value);
                item["idDetalle"] = Convert.ToInt32(dtgEgreso.Rows[i].Cells["cboDetalleIngEgr"].Value);
                item["nMontoFlujo"] = Convert.ToDecimal(dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value);
                i++;
            }
            return dtEgresos;
        }

        public clsMsjError validarIngresosEgresos()
        {
            clsMsjError obj = new clsMsjError();
            if (dtgIngreso.RowCount == 0)
            {
                obj.AddError("Debe registrar al menos 1 ingreso");
            }

            if (dtgEgreso.RowCount == 0 && this.idTipEvalCre != 1)
            {
                obj.AddError("Debe registrar al menos 1 egreso");
            }

            foreach (DataGridViewRow item in dtgIngreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value)<1)
                {
                    obj.AddError("Debe seleccionar la moneda del ingreso");
                }

                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) < 1)
                {
                    obj.AddError("Debe seleccionar el detalle del ingreso");
                }

                if (Convert.ToInt32(item.Cells["nMontoFlujo"].Value) <= 0)
                {
                    obj.AddError("El monto de ingreso debe ser mayor que 0");
                }
            }

            foreach (DataGridViewRow item in dtgEgreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboMoneda"].Value) < 1)
                {
                    obj.AddError("Debe seleccionar la moneda del egreso");
                }

                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) < 1)
                {
                    obj.AddError("Debe seleccionar el detalle del egreso");
                }

                if (Convert.ToInt32(item.Cells["nMontoFlujo"].Value) <= 0)
                {
                    obj.AddError("El monto de egreso debe ser mayor que 0");
                }
            }
            return obj;
        }

        public DataTable obtIngEgre()
        {
            DataTable dtIng = this.obtIngresos();
            DataTable dtEgr = this.obtEgresos();

            DataTable dtIngEgre = dtIng.Clone();
            foreach (DataRow item in dtIng.Rows)
            {
                dtIngEgre.ImportRow(item);
            }

            foreach (DataRow item in dtEgr.Rows)
            {
                dtIngEgre.ImportRow(item);
            }

            return dtIngEgre;
        }

        /// <summary>
        /// Obtiene ingresos en soles
        /// </summary>
        /// <param name="idDetalle">idDetalle del ingreso egreso a obtener</param>
        /// <returns></returns>
        public Decimal obtIngresosSoles(int idDetalle)
        {
            Decimal nTotalIng = 0m;
            foreach (DataGridViewRow item in dtgIngreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) == idDetalle)
                {
                    nTotalIng += (Convert.ToDecimal(item.Cells["cboMoneda"].Value) == 1) ? Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) : Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) * nTipoDeCambio;
                }
            }
            return nTotalIng;
        }

        public decimal obtIngresosMonedaActual(int idDetalle)
        {
            Decimal nTotalIng = 0m;
            foreach (DataGridViewRow item in dtgIngreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) == idDetalle)
                {
                    return Convert.ToDecimal(item.Cells["nMontoFlujo"].Value);
                }
            }
            return nTotalIng;
        }

        public int obtMoneda(int idDetalle)
        {
            int idMoneda = 0;
            foreach (DataGridViewRow item in dtgIngreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) == idDetalle)
                {
                    return Convert.ToInt32(item.Cells["cboMoneda"].Value);
                }
            }
            return idMoneda;
        }
        /// <summary>
        /// Obtiene egresos en soles por id detalle
        /// </summary>
        /// <param name="idDetalle">idDetalle del ingreso egreso a obtener</param>
        /// <returns></returns>
        public Decimal obtEgresosSoles(int idDetalle)
        {
            Decimal nTotal = 0m;
            foreach (DataGridViewRow item in dtgEgreso.Rows)
            {
                if (Convert.ToInt32(item.Cells["cboDetalleIngEgr"].Value) == idDetalle)
                {
                    nTotal += (Convert.ToDecimal(item.Cells["cboMoneda"].Value) == 1) ? Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) : Convert.ToDecimal(item.Cells["nMontoFlujo"].Value) * nTipoDeCambio;
                }
            }
            return nTotal;
        }

        public Decimal obEgresoSoles(int Detalle)
        {
            Decimal nTotalProv = 0m;
            DataTable dtTotalEgreso = new DataTable();
            dtTotalEgreso.Columns.Add("idMoneda", typeof(int));
            dtTotalEgreso.Columns.Add("nMonto", typeof(decimal));

            DataRow dr1 = dtTotalEgreso.NewRow();
            dr1["idMoneda"] = 1;
            dr1["nMonto"] = 0m;
            dtTotalEgreso.Rows.Add(dr1);
            DataRow dr2 = dtTotalEgreso.NewRow();
            dr2["idMoneda"] = 2;
            dr2["nMonto"] = 0m;
            dtTotalEgreso.Rows.Add(dr2);

            //obteniendo la suma de deudas en sus respectivas monedas
            foreach (DataGridViewRow item in dtgEgreso.Rows)
            {
                if (Detalle == Convert.ToInt32(item.Cells["idDetalle"].Value))
                {
                    if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 1) //moneda soles
                    {
                        dtTotalEgreso.Rows[0]["nMonto"] = Convert.ToDecimal(dtTotalEgreso.Rows[0]["nMonto"]) + Convert.ToDecimal(item.Cells["nMontoFlujo"].Value);
                    }
                    if (Convert.ToInt32(item.Cells["cboMoneda"].Value) == 2) //moneda dolares
                    {
                        dtTotalEgreso.Rows[1]["nMonto"] = Convert.ToDecimal(dtTotalEgreso.Rows[1]["nMonto"]) + Convert.ToDecimal(item.Cells["nMontoFlujo"].Value);
                    }
                }
            }

            foreach (DataRow item in dtTotalEgreso.Rows)
            {
                if (Convert.ToInt32(item["idMoneda"]) == 1) //moneda soles
                {
                    nTotalProv = nTotalProv + Convert.ToDecimal(item["nMonto"]);
                }
                if (Convert.ToInt32(item["idMoneda"]) == 2) //moneda soles
                {
                    nTotalProv = nTotalProv + Convert.ToDecimal(item["nMonto"]) * nTipoDeCambio;
                }
            }
            return nTotalProv;
        }

        private void cambioMontoCalcularPor(DataGridView dtg, int nFila, int nColumna)
        {
            if (dtg.RowCount == 0)
                return;

            if (nFila < 0)
                return;

            if (nColumna < 0)
                return;

            if (dtg.Columns[nColumna].Name.In("nMontoFlujo", "cboMoneda"))
            {
                if (dtg.Rows[nFila].Cells[nColumna].Value == DBNull.Value)
                {
                    return;
                }

                calcularParticiPorcentual(dtg);
            }
        }

        private bool verificarDecimal(string nValue)
        {
            decimal d;
            if (decimal.TryParse(nValue, out d))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cancelarEdicion()
        {
            MessageBox.Show("Se cancelo la edición", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            dtgIngreso.CancelEdit();
        }

        private void AbrirFrmEvalAlterna(int nFila, int nColumna)
        {
            int nFilaIndice = nFila,
                nColumnaIndice = nColumna;
            if (nFilaIndice < 0)
                return;

            if (oEvalCred == null)
                return;

            if (dtgIngreso.RowCount == 0)
            {
                return;
            }

            if (dtgIngreso.Rows[nFilaIndice].Cells["cboMoneda"].Value == null)
                return;
            if (dtgIngreso.Rows[nFilaIndice].Cells["cboDetalleIngEgr"].Value == null)
                return;

            if (Convert.ToInt32(dtgIngreso.Rows[nFilaIndice].Cells["cboDetalleIngEgr"].Value) == DEINGREGRE.OtrosIngresos)
            {
                if (dtgIngreso.Columns[nColumnaIndice].Name.In("nMontoFlujo"))
                {
                    clsDetEstResEval objOtrosIngresos = new clsDetEstResEval();
                    objOtrosIngresos.idMoneda = Convert.ToInt32(dtgIngreso.Rows[nFilaIndice].Cells["cboMoneda"].Value);
                    objOtrosIngresos.idEvalCred = idEvalCre;
                    objOtrosIngresos.nTipoCambio = nTipoDeCambio;

                    objOtrosIngresos.idEEFF = 0;
                    objOtrosIngresos.idEvalCredAlterna = (dtgIngreso.Rows[nFilaIndice].Cells["idEvalCredAlterna"].Value == DBNull.Value) ? 0 : Convert.ToInt32(dtgIngreso.Rows[nFilaIndice].Cells["idEvalCredAlterna"].Value);
                    objOtrosIngresos.cDescripcion = "OTROS INGRESOS - Evaluación Alterna"; //dtgIngreso.Rows[nFilaIndice].Cells["cboDetalleIngEgr"].Value;

                    frmEvalAlterna frmCronogramaDeudas = new frmEvalAlterna(objOtrosIngresos);
                    frmCronogramaDeudas.ShowDialog();

                    clsDetEstResEval objDetEstResEval = frmCronogramaDeudas.OtroIngreso();

                    dtgIngreso.Rows[nFilaIndice].Cells["idEvalCredAlterna"].Value = objDetEstResEval.idEvalCredAlterna;
                    dtgIngreso.Rows[nFilaIndice].Cells["nMontoFlujo"].Value = objDetEstResEval.nPUnitario;

                    frmCronogramaDeudas.Dispose();
                }
            }
        }

        #endregion

        #region Eventos
        private void dtgIngreso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cambioMontoCalcularPor(dtgIngreso, e.RowIndex, e.ColumnIndex);

            if (dtgIngreso.RowCount == 0)
                return;

            if (dtgIngreso.Columns[e.ColumnIndex].Name.In("cboDetalleIngEgr"))
            {
                if (Convert.ToInt32(dtgIngreso.Rows[e.RowIndex].Cells["cboDetalleIngEgr"].Value) == DEINGREGRE.OtrosIngresos)
                {
                    dtgIngreso.Rows[e.RowIndex].Cells["nMontoFlujo"].ReadOnly = true;
                    dtgIngreso.Rows[e.RowIndex].Cells["nMontoFlujo"].Value = 0.00M;
                }
                else
                {
                    dtgIngreso.Rows[e.RowIndex].Cells["nMontoFlujo"].ReadOnly = false;
                    dtgIngreso.Rows[e.RowIndex].Cells["nMontoFlujo"].Value = 0.00M;
                }
            }

            if (eHandlerCambioIngrEgre != null)
            {
                eHandlerCambioIngrEgre(sender, e);
            }
        }

        private void dtgEgreso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cambioMontoCalcularPor(dtgEgreso, e.RowIndex, e.ColumnIndex);

            if (eHandlerCambioIngrEgre != null)
            {
                eHandlerCambioIngrEgre(sender, e);
            }
        }
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            agregarFila(dtIngresos, dtgIngreso, 1);

            if (eClickAgregarBorrar != null)
            {
                eClickAgregarBorrar(sender, e);
            }
        }

        private void btnMiniAgregar2_Click(object sender, EventArgs e)
        {
            agregarFila(dtEgresos, dtgEgreso, 2);
            if (eClickAgregarBorrar != null)
            {
                eClickAgregarBorrar(sender, e);
            }
        }

        private void btnMiniQuitar2_Click(object sender, EventArgs e)
        {
            quitarFila(dtgEgreso, dtEgresos);
            if (eClickAgregarBorrar != null)
            {
                eClickAgregarBorrar(sender, e);
            }
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            quitarFila(dtgIngreso, dtIngresos);
            if (eClickAgregarBorrar != null)
            {
                eClickAgregarBorrar(sender, e);
            }
        }

        private void dtgIngreso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            currentCellDirty(dtgIngreso);
        }

        private void dtgEgreso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            currentCellDirty(dtgEgreso);
        }

        
        private void dtgIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cambioMontoCalcularPor(dtgIngreso, e.RowIndex, e.ColumnIndex);
        }
        private void dtgEgreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cambioMontoCalcularPor(dtgEgreso, e.RowIndex, e.ColumnIndex);
        }

        private void dtgIngreso_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            actualizarCombosDeGrid(dtgIngreso);
            actualizarCombosDeGrid(dtgEgreso);
        }

        private void dtgIngreso_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dtgIngreso_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if ("nMontoFlujo" == dtgIngreso.Columns[e.ColumnIndex].Name)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgIngreso.CancelEdit();
                    return;
                }
                else if (verificarDecimal(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("No es un número correcto", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgIngreso.CancelEdit();
                    return;
                }
                else if (Convert.ToDecimal(e.FormattedValue) < 0)
                {
                    MessageBox.Show("No puede ser negativo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgIngreso.CancelEdit();
                    return;
                }
            }
        }

        private void dtgIngreso_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            cancelarEdicion();
        }

        private void dtgEgreso_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            cancelarEdicion();
        }

        private void dtg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMontoFlujo"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dtgIngreso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirFrmEvalAlterna(e.RowIndex, e.ColumnIndex);
        }

        #endregion

        private void dtgIngreso_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AbrirFrmEvalAlterna(e.RowIndex, e.ColumnIndex);
        }

    }
}
