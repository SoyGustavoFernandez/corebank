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
using PRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
//using RPT.CapaNegocio;

namespace PRE.Presentacion
{
    public partial class frmAjustesGestion : frmBase
    {
        #region Variables Gloabales
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        private clsCNSimulacionPres cnsimulacionpres = new clsCNSimulacionPres();

        private DataTable dtValoresPresInicial = new DataTable();
        private DataTable dtListaSimulados = new DataTable();
        private DataTable dtValoresSimulados = new DataTable();

        private int idPeriodoSelec;
        private int nEnero = 5;
        private int nFilaPartida;
        private int nFilaClick;

        private bool lEsEjecucion = false;
        private bool lNuevo = false;
        private bool lEditar = false;

        private string cTituloMensaje = "Ajustes de gestión";
        #endregion
        #region Eventos
        public frmAjustesGestion()
        {
            InitializeComponent();
        }
        private void frmAjustesGestion_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (verificarEstadoPeriodo())
            {
                listarSimulados();
                listarValoresPresInicial();
            }
            else
            {
                bloquearTodo();
            }

        }
        private void frmAjustesGestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgValoresPres.CancelEdit();
            limpiarDatosMostrados(true);
        }
        private void cboPeriodoPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarEstadoPeriodo();
            limpiarDatosMostrados(true);
            listarSimulados();
            listarValoresPresInicial();
        }

        private void dtgPresuSimulados_Click(object sender, EventArgs e)
        {
            if (dtgPresuSimulados.CurrentCell != null)
            {
                limpiarDatosMostrados(false);
                nFilaClick= Convert.ToInt32(dtgPresuSimulados.CurrentCell.RowIndex);
                cargarValoresSimulados();
                if (lEsEjecucion)
                {
                    habilitarControles(1); 
                }
                txtDescripcion.ReadOnly = true;
            }
        }
        private void dtgPresuSimulados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgPresuSimulados.Rows[0].Selected = false;
        }
        private void dtgSimuPresupuesto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nColumnaActual = e.ColumnIndex;
            int nFilaActual = e.RowIndex;
            actualizarCeldas(nFilaActual, nColumnaActual);
        }
        private void dtgValoresPres_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Convert.ToInt32(e.ColumnIndex) >= nEnero && Convert.ToInt32(e.ColumnIndex) < nEnero + 12)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresPres.CancelEdit();
                    return;
                }
                else if (verificarDecimal(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("No es un número correcto", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresPres.CancelEdit();
                    return;
                }
                else if (Convert.ToDecimal(e.FormattedValue) < 0 )
                {
                    MessageBox.Show("No puede ser negativo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgValoresPres.CancelEdit();
                    return;
                }
            }

        }
        private void dtgValoresPres_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
            }
        }
        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || Convert.ToInt32(e.KeyChar).In(8, 13, 46))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dtgPresuSimulados.Rows.Count > 1)
            {
                dtgPresuSimulados.Rows[nFilaClick].Selected = false;
            }
            limpiarDatosMostrados(false);
            listarValoresPresInicial();
            lEditar = false;
            lNuevo = true;
            habilitarCeldas(true);
            habilitarControles(2);
            txtDescripcion.ReadOnly = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            lEditar = true;
            lNuevo = false;
            habilitarCeldas(true);
            habilitarControles(2);
            txtDescripcion.ReadOnly = false;

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarSimulacion();
            limpiarDatosMostrados(true);
            listarValoresPresInicial();
            listarSimulados();
            habilitarControles(0);

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                grabarSimulacion();
                limpiarDatosMostrados(true);
                txtDescripcion.ReadOnly = true;
                listarValoresPresInicial();
                listarSimulados();
                habilitarControles(0);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarDatosMostrados(true);
            listarSimulados();
            listarValoresPresInicial();
            habilitarControles(3);
            txtDescripcion.ReadOnly = true;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirReporte();
        }
        #endregion
        #region Metodos
        private bool verificarEstadoPeriodo()
        {
            if (cboPeriodoPresupuestal.SelectedItem == null)
            {
                return false;
            }
            else
            {
                idPeriodoSelec = Convert.ToInt32(this.cboPeriodoPresupuestal.SelectedValue);

                DataTable dtPeriodoSelect = new clsCNPeriodos().PeriodosPresupuesto(idPeriodoSelec);
                this.lblEstado.Text = Convert.ToString(dtPeriodoSelect.Rows[0]["cEstado"]);
                int nEstado = Convert.ToInt32(dtPeriodoSelect.Rows[0]["idEstado"]);
                if (nEstado == 2) 
                {
                    this.lblEstado.ForeColor = Color.RoyalBlue;
                    lEsEjecucion = true;
                }
                else if (nEstado == 1)
                {
                    this.lblEstado.ForeColor = Color.DarkGreen;
                    lEsEjecucion = false;
                }
                else
                {
                    this.lblEstado.ForeColor = Color.Gray;
                    lEsEjecucion = false;
                }
                return true;
            }
        }

        private void listarSimulados()
        {
            dtListaSimulados = cnsimulacionpres.ListarPresuSimulados(idPeriodoSelec);
            if (dtListaSimulados.Rows.Count > 0)
            {
                dtgPresuSimulados.DataSource = dtListaSimulados;
                formatearGridSimulados();
                if (lEsEjecucion)
                {
                    btnNuevo.Enabled = true;
                }
                else
                {
                    btnNuevo.Enabled = false;
                }
            }
            else
            {
                habilitarControles(0);
                if (lEsEjecucion)
                {
                    btnNuevo.Enabled = true;
                }
                else
                {
                    btnNuevo.Enabled = false;
                }
                return;
            }
        }
        private void formatearGridSimulados()
        {
            foreach (DataGridViewColumn item in dtgPresuSimulados.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgPresuSimulados.Columns["cCodigo"].HeaderText = "Código";
            dtgPresuSimulados.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgPresuSimulados.Columns["FechaModificacion"].HeaderText = "Fecha de Modificación";

            dtgPresuSimulados.Columns["cCodigo"].Visible = true;
            dtgPresuSimulados.Columns["cDescripcion"].Visible = true;
            dtgPresuSimulados.Columns["FechaModificacion"].Visible = true;
        }
        private void cargarValoresSimulados()
        {
            int idSimulacion = Convert.ToInt32(dtgPresuSimulados.Rows[nFilaClick].Cells[0].Value);
            listarValoresPresSimu(idSimulacion);
            txtDescripcion.Text = Convert.ToString(dtgPresuSimulados.Rows[nFilaClick].Cells["cDescripcion"].Value);
            txtCodigo.Text = Convert.ToString(dtgPresuSimulados.Rows[nFilaClick].Cells["cCodigo"].Value);
        }
        private void listarValoresPresSimu(int idSimulacion)
        {
            dtValoresSimulados = cnsimulacionpres.ListarValoresSimulados(idPeriodoSelec, idSimulacion);
            dtgValoresPres.DataSource = dtValoresSimulados;
            formatearGridValores(dtValoresSimulados);
        }

        private void listarValoresPresInicial()
        {
            dtValoresPresInicial = cnpartidaspres.ListarValoresDePartidas(idPeriodoSelec);
            if (dtValoresPresInicial.Rows.Count > 0)
            {
                dtgValoresPres.DataSource = dtValoresPresInicial;
                formatearGridValores(dtValoresPresInicial);
            }
            else
            {
                return;
            }
        }
        private void formatearGridValores(DataTable dtValores)
        {
            for (int i = nEnero; i < nEnero + 13; i++)
            {
                dtValores.Columns[i].ReadOnly = false;
            }
            dtgValoresPres.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgValoresPres.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }

            for (int i = nEnero -1; i < nEnero + 13; i++)
            {
                dtgValoresPres.Columns[i].Visible = true;
                if (i >= nEnero)
                {
                    dtgValoresPres.Columns[i].DefaultCellStyle.Format = "N2";
                    dtgValoresPres.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dtgValoresPres.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgValoresPres.Columns[nEnero + 12].HeaderText = "Total";
            dtgValoresPres.Columns["cDescripcion"].Frozen = true;
        }
        private void habilitarCeldas(bool val)
        {
            for (int i = 0; i < dtgValoresPres.Rows.Count; i++)
            {
                int editable = Convert.ToInt32(dtgValoresPres.Rows[i].Cells["Editable"].Value);
                for (int j = nEnero; j < nEnero + 12; j++)
                {
                    if (editable == 1)
                    {
                        dtgValoresPres.Rows[i].Cells[j].ReadOnly = false;
                    }
                    else
                    {
                        dtgValoresPres.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(224, 224, 224);
                    }
                }
            }
        }
        private void limpiarDatosMostrados(bool val)
        {
            if (val)
            {
                dtgValoresPres.DataSource = null;
                dtgPresuSimulados.DataSource = null;
                txtCodigo.Clear();
                txtDescripcion.Clear();
            }
            else
            {
                txtDescripcion.Clear();
                txtCodigo.Clear();
                dtgValoresPres.DataSource = null;
            }



        }
        private void actualizarCeldas(int nFilaActual, int nColumnaActual)
        {
            decimal sumaMeses = 0;

            for (int i = nEnero; i < nEnero + 12; i++)
            {
                sumaMeses += Convert.ToDecimal(dtgValoresPres.Rows[nFilaActual].Cells[i].Value);
            }
            dtgValoresPres.Rows[nFilaActual].Cells[nEnero + 12].Value = sumaMeses;

            int idPartida = Convert.ToInt32(dtgValoresPres.Rows[nFilaActual].Cells["idPartida"].Value);
            nFilaPartida = devolverFilaCelda(idPartida);
            int idPartidaPadre = devolverPadre(idPartida);

            while (idPartidaPadre != 0)
            {
                nFilaPartida = devolverFilaCelda(idPartidaPadre);
                decimal nSuma = verificarHermanoPartida(idPartidaPadre, nColumnaActual);
                dtgValoresPres.Rows[nFilaPartida].Cells[nColumnaActual].Value = nSuma;

                sumaMeses = 0;
                for (int i = nEnero; i < nEnero + 12; i++)
                {
                    sumaMeses += Convert.ToDecimal(dtgValoresPres.Rows[nFilaPartida].Cells[i].Value);
                }

                dtgValoresPres.Rows[nFilaPartida].Cells[nEnero + 12].Value = sumaMeses;

                idPartidaPadre = devolverPadre(idPartidaPadre);
            }

        }
        private int devolverPadre(int idPartida)
        {
            int idPartidaPadre = Convert.ToInt32(dtgValoresPres.Rows[nFilaPartida].Cells["idPartidaPadre"].Value);
            return idPartidaPadre;
        }
        private int devolverFilaCelda(int idPartida)
        {
            for (int i = 0; i < dtgValoresPres.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValoresPres.Rows[i].Cells["idPartida"].Value) == idPartida)
                {
                    nFilaPartida = i;
                }
            }
            return nFilaPartida;
        }
        private decimal verificarHermanoPartida(int idPartidaPadre, int nColumnaActual)
        {
            decimal nValorHermano = 0;
            for (int i = 0; i < dtgValoresPres.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValoresPres.Rows[i].Cells["idPartidaPadre"].Value) == idPartidaPadre)
                {
                    nValorHermano += Convert.ToDecimal(dtgValoresPres.Rows[i].Cells[nColumnaActual].Value);
                }
            }
            return nValorHermano;
        }

        private void habilitarControles(int val)
        {
            switch (val)
            {
                case 1:
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnImprimir.Enabled = true;
                    break;
                case 2:
                    btnCancelar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnImprimir.Enabled = false;
                    break;
                case 3:
                    btnCancelar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnImprimir.Enabled = false;
                    break;
                default:
                    btnCancelar.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnNuevo.Enabled = true; 
                    break;
            }
        }
        private void grabarSimulacion()
        {
            DataSet dsValoresSimulados = new DataSet("DSValoresSimulados");
            if (lNuevo == true)
            {
                dsValoresSimulados.Tables.Add(dtValoresPresInicial);
                string xmlValoresSimulados = dsValoresSimulados.GetXml();
                xmlValoresSimulados = clsCNFormatoXML.EncodingXML(xmlValoresSimulados);
                dsValoresSimulados.Tables.Clear();

                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                bool lVigente = true;
                string descripcion = Convert.ToString(txtDescripcion.Text);
                DataTable dtResultado = cnsimulacionpres.InsertarValoresSimulados(descripcion, idPeriodoSelec, idUsuReg, dFechaReg, lVigente, xmlValoresSimulados);

                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (lEditar == true)
            {
                dsValoresSimulados.Tables.Add(dtValoresSimulados);
                string xmlValoresSimulados = dsValoresSimulados.GetXml();
                xmlValoresSimulados = clsCNFormatoXML.EncodingXML(xmlValoresSimulados);
                dsValoresSimulados.Tables.Clear();

                int idUsuMod = clsVarGlobal.User.idUsuario;
                DateTime dFechaMod = clsVarGlobal.dFecSystem;
                bool lVigente = true;
                int idSimulacion = Convert.ToInt32(dtgPresuSimulados.Rows[nFilaClick].Cells["idSimulacion"].Value);
                string descripcion = Convert.ToString(txtDescripcion.Text);
                DataTable dtResultado = cnsimulacionpres.ActualizarValoresSimulados(idSimulacion,descripcion, idPeriodoSelec, idUsuMod, dFechaMod, lVigente, xmlValoresSimulados);

                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

        }
        private void eliminarSimulacion()
        {
            int idUsuMod = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            int idSimulacion = Convert.ToInt32(dtgPresuSimulados.Rows[nFilaClick].Cells["idSimulacion"].Value);
            DataTable dtResultado = cnsimulacionpres.EliminarValoresSimulados(idSimulacion, idUsuMod, dFechaMod);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
        private void bloquearTodo()
        {
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            habilitarControles(0);
            btnNuevo.Enabled = false;
        }
        private void imprimirReporte()
        {
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cPeriodo = cboPeriodoPresupuestal.Text.ToString();
            string cCodigo = Convert.ToString(dtgPresuSimulados.Rows[nFilaClick].Cells["cCodigo"].Value);
            string idSimulacion = Convert.ToString(dtgPresuSimulados.Rows[nFilaClick].Cells[0].Value);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idPeriodo", cPeriodo, false));
            paramlist.Add(new ReportParameter("idSimulacion",idSimulacion, false));
            paramlist.Add(new ReportParameter("x_cCodigo", cCodigo, false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsAjustesGestion", dtValoresSimulados));
            string reportpath = "rptAjustesGestion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        private bool verificarCampos()
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Ingrese una descripción", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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

        #endregion
    }
}
