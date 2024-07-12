using CRE.CapaNegocio;
using EntityLayer;
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
    public partial class frmCambiarOrdenPrelacion : frmBase
    {
        #region Variables

        DataTable dtCredito = new DataTable();
        clsCNCredito cnCredito = new clsCNCredito();
        clsLisPrelacion lista = new clsLisPrelacion();
        clsLisPrelacion listaActual = new clsLisPrelacion();
        int idCuenta = 0;
        int idOrdenPrelacion = 0;

        #endregion

        #region Constructor
        public frmCambiarOrdenPrelacion()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargar();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            cargar();
        }

        private void frmCambiarOrdenPrelacion_Load(object sender, EventArgs e)
        {
            conBusCuentaCli1.cTipoBusqueda = "C";
            habilitarControles(1);
        }

        private void dtgConcepto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;

                if (object.ReferenceEquals(dtgConceptoNuevo.CurrentCell.ValueType, typeof(System.Int32)))
                {
                    txt.KeyPress += SoloNumeros_KeyPress;
                }
                else
                {
                    txt.KeyPress -= SoloNumeros_KeyPress;
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(3);
        }

        private void frmCambiarOrdenPrelacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
        }

        private void dtgConcepto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int nOrden = 0;
                if (!String.IsNullOrEmpty(dtgConceptoNuevo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    nOrden = Convert.ToInt32(dtgConceptoNuevo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }

                if (nOrden > 5 || nOrden < 1)
                {
                    MessageBox.Show("Por favor ingrese un valor entre 1 y 5", "Validacion orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lista = null;
                    lista = new clsLisPrelacion();
                    cargarConceptoNuevo();
                    formatoGridConceptoNuevo();
                    return;
                }

                lista = (clsLisPrelacion)dtgConceptoNuevo.DataSource;
                var listaordenada = lista.OrderBy(x => x.nOrden);

                lista = null;
                lista = new clsLisPrelacion();
                foreach (var item in listaordenada)
                {
                    lista.Add(new clsPrelacion() { idcuenta = item.idcuenta, cConcepto = item.cConcepto, nOrden = item.nOrden, idConcepto = item.idConcepto });
                }

                dtgConceptoNuevo.DataSource = null;
                dtgConceptoNuevo.DataSource = lista;
                formatoGridConceptoNuevo();
            }

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (btnGrabar1.Enabled)
            {
                habilitarControles(2);
            }
            else
            {
                conBusCuentaCli1.LiberarCuenta();
                habilitarControles(1);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DialogResult drEleccion = MessageBox.Show("Desea cambiar el orden de prelación?", "Confimación", MessageBoxButtons.YesNo);
                if (drEleccion == DialogResult.Yes)
                {
                    DataTable dtOrdenPrelacion = new DataTable();
                    dtOrdenPrelacion.Columns.Add("nOrden", typeof(int));
                    dtOrdenPrelacion.Columns.Add("cConcepto", typeof(string));
                    dtOrdenPrelacion.Columns.Add("idConcepto", typeof(int));

                    foreach (clsPrelacion prelacion in lista)
                    {
                        DataRow dr = dtOrdenPrelacion.NewRow();
                        dr["nOrden"] = prelacion.nOrden;
                        dr["cConcepto"] = prelacion.cConcepto;
                        dr["idConcepto"] = prelacion.idConcepto;
                        dtOrdenPrelacion.Rows.Add(dr);
                    }

                    DataSet dsOrdenPrelacion = new DataSet("dsOrdenPrelacion");
                    dsOrdenPrelacion.Tables.Add(dtOrdenPrelacion.Copy());
                    string xmlOrdenPrelacion = dsOrdenPrelacion.GetXml();

                    DataTable dtResultado = cnCredito.grabarNuevoOrdenPrelacion(idCuenta, idOrdenPrelacion, xmlOrdenPrelacion, clsVarGlobal.User.idUsuario);
                    if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Se cambio correctamente el orden de prelación del crédito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar();
                    }
                    else
                    {
                        MessageBox.Show("Error al cambiar orden de prelación: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dtgConceptoNuevo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Debe ingresar un valor entre 1 y 5", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if ((e.Exception) is ConstraintException)
            {
                dtg.Rows[e.RowIndex].ErrorText = "an error";
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        #endregion

        #region Metodos

        private bool validar()
        {
            int nsumorden = lista.Sum(x => x.nOrden);
            for (int i = 1; i <= lista.Count; i++)
            {
                if (!lista.Exists(x => x.nOrden == i))
                {
                    MessageBox.Show("Por favor ingrese un orden correcto de los conceptos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            int nIguales = 0;

            for (int i = 0; i < dtgConceptoActual.Rows.Count; i++)
            {
                if (dtgConceptoActual.Rows[i].Cells["cConcepto"].Value.ToString() == dtgConceptoNuevo.Rows[i].Cells["cConcepto"].Value.ToString() && dtgConceptoActual.Rows[i].Cells["nOrden"].Value.ToString() == dtgConceptoNuevo.Rows[i].Cells["nOrden"].Value.ToString())
                {
                    nIguales++;
                }
            }

            if (nIguales == 5)
            {
                MessageBox.Show("No puede ingresar el mismo orden de prelación actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void cargar()
        {
            if (!String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                idCuenta = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);

                dtCredito = cnCredito.obtenerCreditoCambioOrdenPrelacion(idCuenta);

                if (dtCredito.Rows.Count > 0)
                {
                    txtMoneda.Text = dtCredito.Rows[0]["cMoneda"].ToString();
                    txtEstadoCredito.Text = dtCredito.Rows[0]["cEstado"].ToString();
                    txtSaldoCapital.Text = dtCredito.Rows[0]["nSaldoCapital"].ToString();
                    txtSaldoInteres.Text = dtCredito.Rows[0]["nSaldoInteres"].ToString();
                    txtSaldoIntComp.Text = dtCredito.Rows[0]["nSaldoIntComp"].ToString();
                    txtSaldoMora.Text = dtCredito.Rows[0]["nSaldoMora"].ToString();
                    txtSaldoOtros.Text = dtCredito.Rows[0]["nSaldoOtros"].ToString();
                    txtTotalDeuda.Text = dtCredito.Rows[0]["nTotalDeuda"].ToString();
                    txtTasaInteres.Text = dtCredito.Rows[0]["nTasaInteres"].ToString();
                    txtTasaMoratoria.Text = dtCredito.Rows[0]["nTasaCompen"].ToString();
                    txtDiasAtraso.Text = dtCredito.Rows[0]["nAtraso"].ToString();
                    txtAsesor.Text = dtCredito.Rows[0]["cNombreAsesor"].ToString();
                    idOrdenPrelacion = Convert.ToInt32(dtCredito.Rows[0]["idOrdenPrelacion"]);
                    cargarConceptoActual();

                    habilitarControles(2);


                    if (Convert.ToInt32(dtCredito.Rows[0]["nCuotas"]) != 1)
                    {
                        btnNuevo1.Enabled = false;
                        MessageBox.Show("Para cambiar el orden de prelación, debe consolidar el plan de pagos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void habilitarControles(int idEstado)
        {
            switch (idEstado)
            {
                case 1:
                    limpiar();
                    dtgConceptoNuevo.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnSalir1.Enabled = true;
                    break;
                case 2:
                    conBusCuentaCli1.Enabled = false;
                    dtgConceptoNuevo.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    dtgConceptoNuevo.DataSource = null;
                    btnSalir1.Enabled = false;
                    break;
                case 3:
                    conBusCuentaCli1.Enabled = false;
                    dtgConceptoNuevo.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    btnNuevo1.Enabled = false;
                    cargarConceptoNuevo();
                    btnSalir1.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void limpiar()
        {
            txtMoneda.Text = "";
            txtEstadoCredito.Text = "";

            txtSaldoCapital.Text = "";
            txtSaldoInteres.Text = "";
            txtSaldoIntComp.Text = "";
            txtSaldoMora.Text = "";
            txtSaldoOtros.Text = "";

            txtTotalDeuda.Text = "";

            txtTasaInteres.Text = "";
            txtTasaMoratoria.Text = "";
            txtDiasAtraso.Text = "";
            txtAsesor.Text = "";

            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();

            dtgConceptoActual.DataSource = null;
            dtgConceptoNuevo.DataSource = null;
        }

        private void formatoGridConceptoNuevo()
        {
            DataGridViewCellStyle styleNuevo = new DataGridViewCellStyle();
            styleNuevo.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConceptoNuevo.ReadOnly = false;
            this.dtgConceptoNuevo.Columns["idCuenta"].Visible = false;
            this.dtgConceptoNuevo.Columns["idConcepto"].Visible = false;
            this.dtgConceptoNuevo.Columns["cConcepto"].HeaderText = "Concepto";
            this.dtgConceptoNuevo.Columns["nOrden"].HeaderText = "Orden";
            this.dtgConceptoNuevo.Columns["cConcepto"].Width = 130;
            this.dtgConceptoNuevo.Columns["cConcepto"].ReadOnly = true;
            this.dtgConceptoNuevo.Columns["nOrden"].CellTemplate.Style = styleNuevo;
            this.dtgConceptoNuevo.Refresh();
        }

        private void formatoGridConceptoActual()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgConceptoActual.Columns["idCuenta"].Visible = false;
            this.dtgConceptoActual.Columns["idConcepto"].Visible = false;
            this.dtgConceptoActual.Columns["cConcepto"].HeaderText = "Concepto";
            this.dtgConceptoActual.Columns["nOrden"].HeaderText = "Orden";
            this.dtgConceptoActual.Columns["cConcepto"].Width = 130;
            this.dtgConceptoActual.Columns["cConcepto"].ReadOnly = true;
            this.dtgConceptoActual.Columns["nOrden"].CellTemplate.Style = style;
            this.dtgConceptoActual.ClearSelection();
            this.dtgConceptoActual.Refresh();
        }

        private void cargarConceptoActual()
        {
            listaActual.Clear();
            if (idOrdenPrelacion == 0)
            {
                lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "OTROS", nOrden = 1, idConcepto = 63 });
                lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "MORA", nOrden = 2, idConcepto = 3 });
                lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INTERES COMPENSATORIO", nOrden = 3, idConcepto = 24 });
                lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INTERES", nOrden = 4, idConcepto = 4 });
                lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "CAPITAL", nOrden = 5, idConcepto = 1 });
            }
            else
            {
                DataTable dtOrdenPrelacion = cnCredito.ObtenerOrdenPrelacion(idCuenta, idOrdenPrelacion);
                foreach (DataRow drFila in dtOrdenPrelacion.Rows)
                {
                    listaActual.Add(new clsPrelacion() { idcuenta = 0, cConcepto = Convert.ToString(drFila["cConcepto"]),
                                                         nOrden = Convert.ToInt32(drFila["nOrden"]),
                                                         idConcepto = Convert.ToInt32(drFila["idConcepto"])
                                                       });
                }
            }

            this.dtgConceptoActual.DataSource = null;
            this.dtgConceptoActual.DataSource = listaActual;
            formatoGridConceptoActual();
        }

        private void cargarConceptoNuevo()
        {
            lista.Clear();

            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "OTROS", nOrden = 1, idConcepto = 63});
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "MORA", nOrden = 2, idConcepto = 3});
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INTERES COMPENSATORIO", nOrden = 3, idConcepto = 24});
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INTERES", nOrden = 4, idConcepto = 4});
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "CAPITAL", nOrden = 5, idConcepto = 1});

            this.dtgConceptoNuevo.DataSource = null;

            this.dtgConceptoNuevo.DataSource = lista;
            formatoGridConceptoNuevo();
        }

        #endregion
    }
}
