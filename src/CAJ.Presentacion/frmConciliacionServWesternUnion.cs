using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;

namespace CAJ.Presentacion
{
    public partial class frmConciliacionServWesternUnion : frmBase
    {
        #region Variables
        private Excel.Application oExcel = null;
        private Excel.Workbook oWorkBook = null;
        private Excel.Worksheet oWorkSheet = null;
        public DataTable dtOperacionesWesternUnion = new DataTable();
        public DataTable dtOficinas;
        public DataTable dtEmisionRecibos;
        public DataTable dtCopyEmisionRecibos;
        public DataTable dtVolcadoExcel;
        public int nPermiso1 = 0;
        public int nPermiso2 = 0;
        public int nRecibosFaltantesCorebank = 0;
        private string cRuta = string.Empty;
        public string cOrdenMonto = "ASC";
        string cTituloMsjs = "Conciliación de Servicios Western Union";
        #endregion


        public frmConciliacionServWesternUnion()
        {
            this.dtOperacionesWesternUnion.Columns.Add("nLote", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("nSecuencia", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("cEntidad", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("cCuenta", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("dFecha", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("dHora", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("cFirma", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("cOperador", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("nImporte", typeof(string));
            this.dtOperacionesWesternUnion.Columns.Add("cMoneda", typeof(string));

            InitializeComponent();
            HabilitaBtns(false);
        }

        #region Eventos
        private void frmConciliacionServWesternUnion_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
            this.dtpFecha.MaxDate = clsVarGlobal.dFecSystem;
            this.lblEstadoConciliacion.Visible = false;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;


            /******************** Convierte a partir de si_finVaribale->cPerfES ***************************/
            string cIdPerfiles = clsVarApl.dicVarGen["cPerfES"];

            String[] cArrayIdPerfiles;

            int[] nArrayIdPerfiles;
            cArrayIdPerfiles = cIdPerfiles.Split(',');
            nArrayIdPerfiles = Array.ConvertAll<string, int>(cArrayIdPerfiles, int.Parse);
            /******************************************************************************************************/



            if (clsVarGlobal.PerfilUsu.idPerfil.In(nArrayIdPerfiles))
            {
                this.cboZona.Enabled = false;
            }


            if (cboZona.Enabled == false)
            {
                //this.btnImportar.Enabled = true;
                //this.btn_Vincular.Enabled = true;
                this.cboZona.Enabled = this.cboAgencia.Enabled = this.cboColaborador.Enabled = false;

                DataTable dtUsuario = new clsCNControlOpe().obtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);

                this.comboBoxValoresXDefecto(this.cboZona, 0, dtUsuario.Rows[0]["cDesZona"].ToString());
                this.comboBoxValoresXDefecto(this.cboAgencia, clsVarGlobal.nIdAgencia, clsVarGlobal.cNomAge);
                this.comboBoxValoresXDefecto(this.cboColaborador, clsVarGlobal.User.idUsuario, clsVarGlobal.User.cNomUsu);
            }
            else
            {
                this.cboAgencia.Enabled = false;
                this.cboColaborador.Enabled = false;
                cboZona.SelectedIndex = -1;
                nPermiso1 = 1;
            }

            this.dtgEmisionRec.Scroll += new ScrollEventHandler(dtgEmisionRec_Scroll);
            this.dtgWesternUnionExcel.Scroll += new ScrollEventHandler(dtgWesternUnionExcel_Scroll);

            cargarTiporecibos();
            this.cboTipRec.SelectedValue = 1;
            this.cboTipRec.Enabled = false;
            dtgWesternUnionExcel.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtgWesternUnionExcel.MultiSelect = false;

        }

        private void frmConciliacionServWesternUnion_Shown(object sender, EventArgs e)
        {
            if (cboZona.Enabled == false)
            {
                btnConsultar.PerformClick();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog objLoadDialogo = new OpenFileDialog();
            objLoadDialogo.Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xls;*‌​.xml;";

            var result = objLoadDialogo.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (objLoadDialogo.SafeFileName != "")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", cTituloMsjs, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cRuta = objLoadDialogo.FileName;
                        this.cargarArchivo(ref oExcel, ref oWorkBook, ref oWorkSheet);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No seleccionó una dirección correcta", "Error al cargar archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            btnComparar.Enabled = false;
            nRecibosFaltantesCorebank = 0;

            //Para comparación de tablas segun orden ASC o DESC

            List<double> nMontoDtgEmision = new List<double>();
            List<double> nMontoDtgExcel = new List<double>();

            foreach (DataGridViewRow row in dtgWesternUnionExcel.Rows)
            {
                nMontoDtgExcel.Add(Convert.ToDouble(row.Cells["nImporte"].Value));
            }
            foreach (DataGridViewRow row in dtgEmisionRec.Rows)
            {
                nMontoDtgEmision.Add(Convert.ToDouble(row.Cells["nMontoTot"].Value));
            }

            List<double> objMontosExistentes = new List<double>();

            List<double> objNuevoWestern = noContieneMonto(nMontoDtgEmision, dtgWesternUnionExcel, "nImporte");
            foreach (double monto in objNuevoWestern.Concat(nMontoDtgEmision))
            {
                if (!objMontosExistentes.Contains(monto))
                {
                    objMontosExistentes.Add(monto);
                }
            }

            if (cOrdenMonto == "ASC")
            {
                objMontosExistentes.Sort((a, b) => -1 * a.CompareTo(b));
            }
            else
            {
                objMontosExistentes.Sort((a, b) => a.CompareTo(b));
            }

            // ===============Tabla 01 ===============
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dtgEmisionRec.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (double m in objMontosExistentes)
            {

                if (objNuevoWestern.Contains(m))
                {
                    for (int i = 0; i < objNuevoWestern.Where(c => c == m).Count(); i++)
                    {
                        DataRow dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }
                else
                {
                    double montoTmp = 0;

                    foreach (DataGridViewRow row in dtgEmisionRec.Rows)
                    {
                        if (Convert.ToDouble(row.Cells["nMontoTot"].Value) == m)
                        {
                            DataRow dRow = dt.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dt.Rows.Add(dRow);
                            montoTmp = m;
                        }
                    }

                    for (int i = 0; i < contarMontoDtgExcel(montoTmp) - contarMontoDtgEmisionRecibo(montoTmp); i++)
                    {
                        DataRow dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

            }


            this.dtgEmisionRec.DataSource = dt;

            /* =====================TABLA 02 =====================================**/

            DataTable dtWesternUnionExcel = new DataTable();
            List<double> montosNoExistentesDtgEmision = noContieneMonto(nMontoDtgExcel, dtgEmisionRec, "nMontoTot");

            foreach (DataGridViewColumn col in dtgWesternUnionExcel.Columns)
            {
                dtWesternUnionExcel.Columns.Add(col.Name);
            }

            foreach (double m in objMontosExistentes)
            {
                if (montosNoExistentesDtgEmision.Contains(m))
                {
                    for (int i = 0; i < montosNoExistentesDtgEmision.Where(c => c == m).Count(); i++)
                    {
                        DataRow dRow = dtWesternUnionExcel.NewRow();
                        dtWesternUnionExcel.Rows.Add(dRow);
                    }
                }
                else
                {
                    double montoTmp = 0;

                    foreach (DataGridViewRow row in dtgWesternUnionExcel.Rows)
                    {
                        if (Convert.ToDouble(row.Cells["nImporte"].Value) == m)
                        {
                            DataRow dRow = dtWesternUnionExcel.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtWesternUnionExcel.Rows.Add(dRow);
                            montoTmp = m;
                        }
                    }

                    for (int i = 0; i < contarMontoDtgEmisionRecibo(montoTmp) - contarMontoDtgExcel(montoTmp); i++)
                    {
                        DataRow dRow = dtWesternUnionExcel.NewRow();
                        dtWesternUnionExcel.Rows.Add(dRow);
                    }
                }
            }


            this.dtgWesternUnionExcel.DataSource = dtWesternUnionExcel;

            colorearTabla();
        }

        private void dtgEmisionRec_Scroll(object sender, ScrollEventArgs e)
        {
            if (btnComparar.Enabled == false)
            {
                this.dtgWesternUnionExcel.FirstDisplayedScrollingRowIndex = this.dtgEmisionRec.FirstDisplayedScrollingRowIndex;
            }
        }

        private void dtgWesternUnionExcel_Scroll(object sender, ScrollEventArgs e)
        {
            if (btnComparar.Enabled == false)
            {
                this.dtgEmisionRec.FirstDisplayedScrollingRowIndex = this.dtgWesternUnionExcel.FirstDisplayedScrollingRowIndex;
            }
        }

        private void dtgWesternUnionExcel_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgWesternUnionExcel.Columns[e.ColumnIndex].HeaderText == "Monto" && btnComparar.Enabled == false)
            {
                btnConsultar.PerformClick();
            }

            if (dtgWesternUnionExcel.Columns[e.ColumnIndex].HeaderText == "Monto")
            {
                if (cOrdenMonto == "ASC")
                {
                    this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["nImporte"], ListSortDirection.Ascending);
                    this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["nMontoTot"], ListSortDirection.Ascending);
                    cOrdenMonto = "DESC";
                }
                else
                {
                    this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["nImporte"], ListSortDirection.Descending);
                    this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["nMontoTot"], ListSortDirection.Descending);
                    cOrdenMonto = "ASC";
                }
            }
        }

        private void dtgEmisionRec_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgEmisionRec.Columns[e.ColumnIndex].HeaderText == "Monto" && btnComparar.Enabled == false)
            {
                btnConsultar.PerformClick();
            }

            if (dtgEmisionRec.Columns[e.ColumnIndex].HeaderText == "Monto")
            {
                if (cOrdenMonto == "ASC")
                {
                    if (dtgWesternUnionExcel.RowCount > 0)
                        this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["nImporte"], ListSortDirection.Ascending);


                    this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["nMontoTot"], ListSortDirection.Ascending);
                    cOrdenMonto = "DESC";
                }
                else
                {
                    if (dtgWesternUnionExcel.RowCount > 0)
                        this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["nImporte"], ListSortDirection.Descending);

                    this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["nMontoTot"], ListSortDirection.Descending);
                    cOrdenMonto = "ASC";
                }
            }
        }


        void tbKeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsDigit(e.KeyChar)))
            {

                if (e.KeyChar != '\b') //allow the backspace key
                {

                    e.Handled = true;

                }

            }

        }

        private void btn_Vincular_Click(object sender, EventArgs e)
        {
            DataTable dtFilterConciliacion = new DataTable();
            dtFilterConciliacion.Columns.Add("idOperWesternU");
            dtFilterConciliacion.Columns.Add("idRecibo");

            int nContador = 0;
            int nCantidadVincular = 0;

            double nTotalConciliacionTabla1PEN = 0;
            double nTotalConciliacionTabla1USD = 0;
            double nTotalConciliacionTabla2PEN = 0;
            double nTotalConciliacionTabla2USD = 0;
            var nIdRecibosVincular = new List<string>();

            if (nRecibosFaltantesCorebank > 0)
            {
                mensajeAlerta("Falta registrar " + nRecibosFaltantesCorebank + " emisiones de recibos en el Core Bank para realizar la conciliación.");
                return;
            }

            foreach (DataRow row in datagridToDatatable(dtgWesternUnionExcel).Rows)
            {
                DataRow dRow = dtFilterConciliacion.NewRow();

                dRow[0] = row["idOperWesternU"];
                if (Regex.IsMatch(row["idRec"].ToString(), @"^\d+$"))
                {
                    if (Convert.ToInt32(row["idRec"]) != 0)
                    {
                        dRow[1] = row["idRec"];
                        if (Convert.ToInt32(row["idMoneda"]) == 1)
                        {
                            nTotalConciliacionTabla2PEN += Convert.ToDouble(row["nImporte"]);
                        }
                        else
                        {
                            nTotalConciliacionTabla2USD += Convert.ToDouble(row["nImporte"]);
                        }
                        nIdRecibosVincular.Add(row["idRec"].ToString());
                        nCantidadVincular++;
                    }
                }
                else
                {
                    dRow[1] = 0;
                }
                dtFilterConciliacion.Rows.InsertAt(dRow, nContador++);
            }

            if (nCantidadVincular == 0)
            {
                mensajeAlerta("No hay registros para vincular, no se puede realizar la conciliación.");
                return;
            }

            foreach (DataRow row in dtEmisionRecibos.Rows)
            {
                if (nIdRecibosVincular.Contains(row["idRecibo"].ToString()))
                {
                    if (Convert.ToInt32(row["idMoneda"]) == 1)
                    {
                        nTotalConciliacionTabla1PEN += Convert.ToDouble(row["nMontoTot"]);
                    }
                    else
                    {
                        nTotalConciliacionTabla2USD += Convert.ToDouble(row["nMontoTot"]);
                    }
                }
            }

            if (nTotalConciliacionTabla1PEN != nTotalConciliacionTabla2PEN)
            {
                mensajeAlerta("Los montos en SOLES de ambas tablas a las que va a realizar la conciliación no coinciden, verifique que la vinculación sea correcta.");
                return;
            }

            if (nTotalConciliacionTabla1USD != nTotalConciliacionTabla2USD)
            {
                mensajeAlerta("Los montos en DOLARES de ambas tablas a las que va a realizar la conciliación no coinciden, verifique que la vinculación sea correcta.");
                return;
            }

            if (nCantidadVincular != Convert.ToInt32(dtgWesternUnionExcel.RowCount.ToString()))
            {
                mensajeAlerta("No todas las filas del reporte cargado se encuentran vinculados, por favor validar.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Se realizará la conciliación de " + nCantidadVincular + " registros, ¿Desea continuar?", "Conciliación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                DataSet dsLisOpWU = new DataSet("dtFilterConciliacion");
                dsLisOpWU.Tables.Add(dtFilterConciliacion);
                clsCNControlOpe app = new clsCNControlOpe();
                app.GuardarConcilicionWesternUnion(dsLisOpWU.GetXml(), clsVarGlobal.dFecSystem);
                btnConsultar.PerformClick();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dtgEmisionRec.DataSource = null;
            dtgWesternUnionExcel.DataSource = null;

            //Reseteo de valores de suma total de tablas
            this.txtTotSoles1.Text = this.txtTotSoles2.Text = this.txtTotDolar1.Text = this.txtTotDolar2.Text = "0.00";

            //Validación de filtros
            if (cboZona.SelectedValue == null) { mensajeAlerta("No ha seleccionado una Zona"); return; }
            if (cboAgencia.SelectedValue == null) { mensajeAlerta("No ha seleccionado una Agencia"); return; }
            if (cboColaborador.SelectedValue == null) { mensajeAlerta("No ha seleccionado un Usuario"); return; }

            DataSet dtResult = new DataSet();
            dtResult = new clsCNControlOpe().ListarOperacionConciliacionWesternUnion(Convert.ToInt32(this.cboColaborador.SelectedValue.ToString()), Convert.ToInt32(this.cboAgencia.SelectedValue.ToString()), dtpFecha.Value.Date.ToString("yyyy-MM-dd"), Convert.ToInt32(this.cboTipRec.SelectedValue.ToString()));


            dtEmisionRecibos = dtResult.Tables[0];
            dtCopyEmisionRecibos = dtResult.Tables[0];
            dtVolcadoExcel = dtResult.Tables[1];

            if (dtEmisionRecibos.Rows.Count > 0)
                this.btnImportar.Enabled = true;
            else
                mensajeAlerta("No existen registros de operaciones hechas.");


            if (dtVolcadoExcel.Rows.Count > 0)
            {
                this.btnComparar.Enabled = true;
                this.btnVincular.Enabled = true;
                this.btnImportar.Enabled = true;
            }

            if (dtEmisionRecibos.Rows.Count == 0 && dtVolcadoExcel.Rows.Count == 0)
                HabilitaBtns(false);



            this.lblEstadoConciliacion.Visible = !(dtEmisionRecibos.Rows.Count == 0 && dtVolcadoExcel.Rows.Count == 0);
            if (!(dtEmisionRecibos.Rows.Count == 0 && dtVolcadoExcel.Rows.Count == 0))
            {
                this.lblEstadoConciliacion.Text = "Conciliación no realizada";
                this.lblEstadoConciliacion.ForeColor = System.Drawing.Color.Red;
            }

            int nConciliacion = dtVolcadoExcel.AsEnumerable().Where(x => x["idRec"].ToString() != "0").ToList().Count;

            if (nConciliacion > 0)
            {
                var removeItem = new List<string>();

                this.btnImportar.Enabled = false;
                this.btnVincular.Enabled = false;
                this.lblEstadoConciliacion.Text = "Conciliación realizada";
                this.lblEstadoConciliacion.ForeColor = System.Drawing.Color.Green;
                this.dtgEmisionRec.DefaultCellStyle.BackColor = Color.LightGreen;
                this.dtgWesternUnionExcel.DefaultCellStyle.BackColor = Color.LightGreen;

                for (int i = dtVolcadoExcel.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtVolcadoExcel.Rows[i];
                    if (dr["idRec"].ToString() == "0")
                        dr.Delete();
                    else
                        removeItem.Add(dr["idRec"].ToString());
                }
                dtVolcadoExcel.AcceptChanges();

                for (int i = dtEmisionRecibos.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtEmisionRecibos.Rows[i];
                    if (!removeItem.Contains(dr["idRecibo"].ToString()))
                    {
                        dr.Delete();
                    }
                }
                dtEmisionRecibos.AcceptChanges();
            }

            //Datos de table Emision Recibos Corebank
            if (dtEmisionRecibos.Rows.Count > 0)
            {
                dtgEmisionRec.DataSource = dtEmisionRecibos;
                dtgEmisionRec.Update();
                dtgEmisionRec.Columns["idMoneda"].Visible = false;
                dtgEmisionRec.Columns["nMontoTot"].DefaultCellStyle.Format = "N2";
                dtgEmisionRec.AllowUserToResizeColumns = false;

                this.txtTotSoles1.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal(sumarColumna(dtEmisionRecibos, "nMontoTot", 1)));
                this.txtTotDolar1.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal(sumarColumna(dtEmisionRecibos, "nMontoTot", 2)));

                renombrarCabecerasDataGridView(this.dtgEmisionRec, "nMontoTot=Monto,cMoneda=Moneda,cSustento=Sustento,idRecibo=N° Recibo,dFechaReg=Fecha de Registro");

                dtgEmisionRec.CurrentCell.Selected = false;
                dtgEmisionRec.AllowUserToAddRows = false;

                foreach (DataGridViewColumn column in dtgEmisionRec.Columns)
                {
                    if (column.Name != "nMontoTot")
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["nMontoTot"], ListSortDirection.Descending);
            }
            else
            {
                this.dtgEmisionRec.DataSource = null;
            }

            if (dtVolcadoExcel.Rows.Count > 0)
            {
                this.dtgWesternUnionExcel.AllowUserToAddRows = false;
                this.dtgWesternUnionExcel.DataSource = dtVolcadoExcel;

                dtgWesternUnionExcel.Columns[0].Visible = false;
                dtgWesternUnionExcel.Columns["idMoneda"].Visible = false;
                dtgWesternUnionExcel.Columns["nImporte"].DefaultCellStyle.Format = "N2"; //formato a moneda
                ((DataGridViewTextBoxColumn)dtgWesternUnionExcel.Columns["idRec"]).MaxInputLength = 8;
                dtgWesternUnionExcel.AllowUserToResizeColumns = false;

                this.txtTotSoles2.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal(sumarColumna(dtVolcadoExcel, "nImporte", 1)));
                this.txtTotDolar2.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal(sumarColumna(dtVolcadoExcel, "nImporte", 2)));

                renombrarCabecerasDataGridView(this.dtgWesternUnionExcel, "nImporte=Monto,cMoneda=Moneda,cEntidad=Entidad,idRec=N° \nRecibo,dFecha=Fecha y Hora");

                foreach (DataGridViewColumn column in dtgWesternUnionExcel.Columns)
                {
                    if (column.Name != "nImporte")
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["nImporte"], ListSortDirection.Descending);
            }
            else
            {
                this.dtgWesternUnionExcel.DataSource = null;
            }

            if (dtpFecha.Value.Date.ToString("yyyy-MM-dd") != clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd"))
            {
                btnVincular.Enabled = false;
                btnImportar.Enabled = false;
            }

            if (nConciliacion > 0)
            {
                this.dtgWesternUnionExcel.Sort(this.dtgWesternUnionExcel.Columns["idRec"], ListSortDirection.Ascending);
                this.dtgEmisionRec.Sort(this.dtgEmisionRec.Columns["idRecibo"], ListSortDirection.Ascending);
                btnComparar.Enabled = false;
            }

            if (!(this.cboZona.Enabled == false))
            {
                this.btnVincular.Enabled = false;
                this.btnImportar.Enabled = false;
            }

            if (Convert.ToInt32(dtgWesternUnionExcel.RowCount.ToString()) == 0 && Convert.ToInt32(dtgEmisionRec.RowCount.ToString()) > 0)
            {

                dtgEmisionRec.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (nPermiso1 == 1 && cboZona.Text.Trim() != "")
            {
                clsCNRegionZona listOficina = new clsCNRegionZona();

                dtOficinas = listOficina.CNListarOficinaByZona(Convert.ToInt32(cboZona.SelectedValue));

                this.cboAgencia.DataSource = dtOficinas;
                this.cboAgencia.ValueMember = dtOficinas.Columns[0].ToString();
                this.cboAgencia.DisplayMember = dtOficinas.Columns[1].ToString();

                if (Convert.ToInt32(cboAgencia.SelectedValue) == 0)
                {
                    this.cboAgencia.SelectedIndex = -1;
                    this.cboAgencia.Enabled = false;
                }
                else
                {
                    this.cboAgencia.SelectedIndex = -1;
                    this.cboAgencia.SelectedValue = 0;
                    this.cboAgencia.Enabled = true;
                    this.cboColaborador.Enabled = false;
                    nPermiso2 = 1;
                }
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nPermiso2 == 1 && cboAgencia.Text.Trim().ToString() != "" && Convert.ToInt32(cboAgencia.SelectedValue.ToString()) > 0)
            {
                clsCNControlOpe LisColAge = new clsCNControlOpe();
                DataTable tbColAge = LisColAge.ListarUsuariosEjecutivoServicioConciliacionWestern(dtpFecha.Value.Date, dtpFecha.Value.Date.ToString("yyyy-MM-dd") == clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd"), Convert.ToInt32(this.cboAgencia.SelectedValue));

                if (Convert.ToInt32(tbColAge.Rows.Count.ToString()) < 1)
                {
                    MessageBox.Show("No se encontraron usuarios que hayan conciliado para esta fecha.", cTituloMsjs, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cboColaborador.Enabled = false;
                    return;
                }

                this.cboColaborador.DataSource = tbColAge;
                this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
                this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();

                this.cboColaborador.Enabled = true;
                this.cboColaborador.SelectedIndex = -1;
                this.cboColaborador.SelectedValue = 0;
            }
            nPermiso2 = 0;
        }

        private void dtgWesternUnionExcel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value == null)
            {
                e.Value = "_nro recibo"; //Valor por default combobox
            }
        }

     

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboZona.Enabled != false)
            {
                this.cboZona.SelectedIndex = -1;
                this.cboAgencia.SelectedIndex = -1;
                this.cboAgencia.Enabled = false;
                this.cboColaborador.SelectedIndex = -1;
                this.cboColaborador.Enabled = false;
            }
        }
        #endregion

        #region Métodos
        private void cargarArchivo(ref Excel.Application oExcel, ref Excel.Workbook oWorkBook, ref Excel.Worksheet oWorkSheet)
        {
            this.dtOperacionesWesternUnion.Rows.Clear();

            oExcel = new Excel.Application();
            oWorkBook = oExcel.Workbooks.Open(cRuta, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            int i = 2;

            String cLote;
            String cNumeroSecuencia;
            String cEntidad;
            String cCuenta;
            String cFecha;
            String cHora;
            String cFirma;
            String cOperador;
            String cImporte;
            String cMoneda;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                cLote = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value);
                cNumeroSecuencia = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value); ;
                cEntidad = Convert.ToString((oWorkSheet.Cells[i, 3] as Excel.Range).Value);
                cCuenta = Convert.ToString((oWorkSheet.Cells[i, 4] as Excel.Range).Value);
                cFecha = Convert.ToString((oWorkSheet.Cells[i, 5] as Excel.Range).Value);
                cHora = Convert.ToString((oWorkSheet.Cells[i, 6] as Excel.Range).Value);
                cFirma = Convert.ToString((oWorkSheet.Cells[i, 7] as Excel.Range).Value);
                cOperador = Convert.ToString((oWorkSheet.Cells[i, 8] as Excel.Range).Value);
                cImporte = Convert.ToString((oWorkSheet.Cells[i, 9] as Excel.Range).Value);
                cMoneda = Convert.ToString((oWorkSheet.Cells[i, 10] as Excel.Range).Value);

                if (cLote != null)
                {
                    this.dtOperacionesWesternUnion.Rows.Add(cLote, cNumeroSecuencia, cEntidad, cCuenta, cFecha, cHora, cFirma, cOperador, cImporte, cMoneda);
                }
                else
                {
                    lIndValCelda = false;
                }

                i = i + 1;
            }

            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);

            frmCargaExcelWesternUnion frmExcelWestern = new frmCargaExcelWesternUnion(this.dtOperacionesWesternUnion);
            DialogResult dr = frmExcelWestern.ShowDialog();

            if (dr == DialogResult.OK)
            {
                btnConsultar.PerformClick();
            }
        }

        private void cargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void liberarObjecto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto :" + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = getIdentificadorProceso("EXCEL");

                if (id != -1)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(id).Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private int getIdentificadorProceso(string cNombreProceso)
        {
            try
            {
                System.Diagnostics.Process[] asProccess = System.Diagnostics.Process.GetProcessesByName(cNombreProceso);

                foreach (System.Diagnostics.Process pProccess in asProccess)
                {
                    if (pProccess.MainWindowTitle == "")
                    {
                        return pProccess.Id;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool montoExisteDtgEmisionRec(double monto)
        {
            var result = false;
            foreach (DataGridViewRow row in dtgEmisionRec.Rows)
            {
                if (Convert.ToDouble(row.Cells["nMontoTot"].Value) == monto)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public List<double> noContieneMonto(List<double> montos, DataGridView dtg, string columnName)
        {
            List<double> objNoContieneMonto = new List<double>();
            foreach (DataGridViewRow row in dtg.Rows)
            {
                if (row.Cells[columnName].Value != DBNull.Value)
                {
                    if (!montos.Contains(Convert.ToDouble(row.Cells[columnName].Value)))
                    {
                        objNoContieneMonto.Add(Convert.ToDouble(row.Cells[columnName].Value));
                    }
                }
            }
            return objNoContieneMonto;
        }

        public void colorearTabla()
        {
            int cont = 0;
            foreach (DataGridViewRow row in dtgWesternUnionExcel.Rows)
            {
                if (dtgEmisionRec.Rows[cont].Cells["idMoneda"].Value != DBNull.Value && dtgWesternUnionExcel.Rows[cont].Cells["idMoneda"].Value != DBNull.Value)
                {
                    if (Convert.ToInt32(dtgEmisionRec.Rows[cont].Cells["idMoneda"].Value) == Convert.ToInt32(dtgWesternUnionExcel.Rows[cont].Cells["idMoneda"].Value))
                    {
                        if (contarMontoDtgEmisionRecibo(Convert.ToDouble(dtgEmisionRec.Rows[cont].Cells["nMontoTot"].Value)) == 1 && contarMontoDtgExcel(Convert.ToDouble(dtgWesternUnionExcel.Rows[cont].Cells["nImporte"].Value)) == 1 && Convert.ToDouble(dtgEmisionRec.Rows[cont].Cells["nMontoTot"].Value) == Convert.ToDouble(dtgWesternUnionExcel.Rows[cont].Cells["nImporte"].Value))
                        {
                            dtgEmisionRec.Rows[cont].DefaultCellStyle.BackColor = Color.LightGreen;
                            dtgWesternUnionExcel.Rows[cont].DefaultCellStyle.BackColor = Color.LightGreen;
                            dtgWesternUnionExcel.Rows[cont].Cells["idRec"].Value = dtgEmisionRec.Rows[cont].Cells["idRecibo"].Value;
                        }
                    }

                    if (Convert.ToDouble(dtgEmisionRec.Rows[cont].Cells["nMontoTot"].Value) == Convert.ToDouble(dtgWesternUnionExcel.Rows[cont].Cells["nImporte"].Value) && Convert.ToInt32(dtgEmisionRec.Rows[cont].Cells["idMoneda"].Value) != Convert.ToInt32(dtgWesternUnionExcel.Rows[cont].Cells["idMoneda"].Value))
                    {
                        dtgEmisionRec.Rows[cont].DefaultCellStyle.BackColor = Color.LightPink;
                        dtgWesternUnionExcel.Rows[cont].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
                else
                {
                    if (dtgEmisionRec.Rows[cont].Cells["idMoneda"].Value == DBNull.Value)
                    {
                        dtgEmisionRec.Rows[cont].DefaultCellStyle.BackColor = Color.Pink;
                        dtgWesternUnionExcel.Rows[cont].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (dtgWesternUnionExcel.Rows[cont].Cells["idMoneda"].Value == DBNull.Value)
                    {
                        dtgWesternUnionExcel.Rows[cont].DefaultCellStyle.BackColor = Color.Pink;
                        dtgEmisionRec.Rows[cont].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                cont++;
            }
        }

        public int contarMontoDtgExcel(Double monto)
        {
            int contador = 0;
            foreach (DataGridViewRow row in dtgWesternUnionExcel.Rows)
            {
                if (row.Cells["nImporte"].Value != DBNull.Value)
                {
                    if (Convert.ToDouble(row.Cells["nImporte"].Value) == monto)
                    {
                        contador++;
                    }
                }
            }

            return contador;
        }

        public int contarMontoDtgEmisionRecibo(Double monto)
        {
            int contador = 0;
            foreach (DataGridViewRow row in dtgEmisionRec.Rows)
            {
                if (row.Cells["nMontoTot"].Value != DBNull.Value)
                {
                    if (Convert.ToDouble(row.Cells["nMontoTot"].Value) == monto)
                    {
                        contador++;
                    }
                }
            }

            return contador;
        }

        public bool verificarMontosIguales(Double monto)
        {
            int contador = 0;
            foreach (DataGridViewRow row in dtgWesternUnionExcel.Rows)
            {
                if (Convert.ToDouble(row.Cells["nImporte"].Value) == monto)
                {
                    contador++;
                }
            }

            return contador > 1 ? true : false;
        }

        public void comboBoxValoresXDefecto(cboBase cbo, int value, string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("value", typeof(int));
            dt.Columns.Add("name", typeof(string));
            DataRow dr = dt.NewRow();
            dr["value"] = value;
            dr["name"] = name;
            dt.Rows.Add(dr);
            cbo.DataSource = dt;
            cbo.ValueMember = dt.Columns["value"].ToString();
            cbo.DisplayMember = dt.Columns["name"].ToString();
        }

        public void renombrarCabecerasDataGridView(DataGridView dtg, string cadena)
        {
            string[] separadas;
            separadas = cadena.Split(',');

            foreach (string s in separadas)
            {
                string[] c;
                c = s.Split('=');
                if (dtg.Columns.Contains(c[0]))
                {
                    dtg.Columns[c[0]].HeaderText = c[1];
                }
            }
        }

        public double sumarColumna(DataTable dt, string columnName, int idMoneda)
        {
            double sum = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (idMoneda == Convert.ToInt32(row["idMoneda"]))
                {
                    sum += Convert.ToDouble(row[columnName].ToString());
                }
            }

            return sum;
        }

        public DataTable datagridToDatatable(DataGridView dtg)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn col in dtg.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dtg.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }

        public void mensajeAlerta(String s)
        {
            MessageBox.Show(s, cTituloMsjs, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void HabilitaBtns(bool idEstado)
        {
            this.btnComparar.Enabled = idEstado;
            this.btnImportar.Enabled = idEstado;
            this.btnVincular.Enabled = idEstado;

        }
        #endregion
    }
}