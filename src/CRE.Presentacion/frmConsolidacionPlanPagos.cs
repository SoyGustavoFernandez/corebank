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
    public partial class frmConsolidacionPlanPagos : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();
        clsCredito credito = new clsCredito();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();

        public frmConsolidacionPlanPagos()
        {
            InitializeComponent();
        }

        private void frmConsolidacionPlanPagos_Load(object sender, EventArgs e)
        {
            conBusCuentaCli1.cTipoBusqueda = "C";
            limpiar();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargar();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            
            if (!String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                int idCuenta = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);

                /***************************************************************/
                // verificación de solicitud de condonacion pendiente
                /***************************************************************/
                DataTable SolicDuplicada = new clsCNCondonacion().DatosSolicCond(conBusCuentaCli1.nIdCliente, idCuenta);
                if (SolicDuplicada.Rows.Count > 0)
                {
                    MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                    "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    return;
                }
                /***************************************************************/
                // Fin verificación de solicitud de condonacion pendiente
                /***************************************************************/

                credito = cnCredito.retornaDatosCredito(idCuenta);
                cboMoneda1.SelectedValue = credito.IdMoneda;

                txtSaldoCapital.Text = (credito.nCapitalDesembolso - credito.nCapitalPagado).ToString("0.00");
                txtSaldoInteres.Text = (credito.nInteresPactado - credito.nInteresPagado).ToString("0.00");
                txtSaldoIntComp.Text = (credito.nInteresComp - credito.nInteresCompPago).ToString("0.00");
                txtSaldoMora.Text = (credito.nMoraGenerado - credito.nMoraPagada).ToString("0.00");
                txtSaldoOtros.Text = (credito.nOtrosGenerado - credito.nOtrosPagado).ToString("0.00");

                txtTotalDeuda.Text = ((credito.nCapitalDesembolso - credito.nCapitalPagado) +
                                     (credito.nInteresPactado - credito.nInteresPagado) +
                                     (credito.nInteresComp - credito.nInteresCompPago) +
                                     (credito.nMoraGenerado - credito.nMoraPagada) +
                                     (credito.nOtrosGenerado - credito.nOtrosPagado)).ToString("0.00");

                txtTasaInteres.Text = credito.nTasaCostoEfectivo.ToString("0.00");
                txtTasaMoratoria.Text = credito.nTasaMoratoria.ToString("0.00");
                txtDiasAtraso.Text = credito.nAtraso.ToString();
                cboEstadoCredito1.CargaEstadoActual(credito.idEstado);
                cboEstadoCredito1.SelectedValue = credito.idEstado;

                clsCNPlanPago PlanPago = new clsCNPlanPago();
                DataTable ListPlanPago = PlanPago.CNdtPlanPagPosi(credito.idCuenta);

                dtgPpg.DataSource = ListPlanPago;
                FormatoPlanPagos();

                btnGrabar1.Enabled = true;
                btnCancelar1.Enabled = true;
                conBusCuentaCli1.Enabled = false;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                String cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                       clsVarGlobal.nIdAgencia, credito.idCli,
                                                       1, credito.IdMoneda, 0,
                                                       0, credito.idCuenta, clsVarGlobal.dFecSystem,
                                                       2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);



                if (cCumpleReglas.Equals("Cumple"))
                {
                    DialogResult drResultado = MessageBox.Show("Esta seguro de consolidar el plan de pagos?", this.Text, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (drResultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dtResultado = cnCredito.consolidarPlanPagos(credito.idCuenta,
                                                                                credito.idPlanPagos,
                                                                                clsVarGlobal.dFecSystem,
                                                                                clsVarGlobal.User.idUsuario,
                                                                                true);

                        if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                        {
                            MessageBox.Show("Se realizó la consolidación del plan de pagos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dtSoliciAproba = ValidaReglasDinamicas.ConsultaSolicitudesAprobadas(135, credito.idCuenta);

                            foreach (DataRow drSoliciAproba in dtSoliciAproba.Rows)
                            {
                                ValidaReglasDinamicas.ActualizaSolicitudApr(Convert.ToInt32(drSoliciAproba["idSolAproba"]), 3);
                            }
                            cargar();
                            btnGrabar1.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Error al consolidar plan de pagos: " + dtResultado.Rows[0]["cMensaje"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private bool validar()
        {
            if (dtgPpg.Rows.Count == 1)
            {
                MessageBox.Show("El crédito cuenta con una sola cuota, NO es necesario la consolidación del plan de pagos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void FormatoPlanPagos()
        {
            void ConfigurarColumna(string nombreColumna, string encabezado, int indice, DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft, string formato = null)
            {
                var columna = dtgPpg.Columns[nombreColumna];
                if (columna != null)
                {
                    columna.Visible = true;
                    columna.HeaderText = encabezado;
                    columna.DisplayIndex = indice;
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    columna.DefaultCellStyle.Alignment = alineacion;
                    if (!string.IsNullOrEmpty(formato))
                    {
                        columna.DefaultCellStyle.Format = formato;
                    }
                }
            }

            // Hacer invisible todas las columnas por defecto
            foreach (DataGridViewColumn columna in dtgPpg.Columns)
            {
                columna.Visible = false;
            }

            // Configurar columnas visibles
            ConfigurarColumna("idCuota", "Nro", 0);
            ConfigurarColumna("dFechaProg", "Fecha prog.", 1);
            ConfigurarColumna("dFechaPago", "Fecha pag.", 2);
            ConfigurarColumna("dFechaValor", "Fecha val.", 3);
            ConfigurarColumna("nAtrasoCuota", "Dias atr. cuo.", 4);
            ConfigurarColumna("nNumDiaCuota", "Dias entre cuota", 5);
            ConfigurarColumna("nMonCuoIni", "Monto cuota", 6, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("EstadoCuota", "Estado", 7);
            ConfigurarColumna("nCapital", "Capital", 8, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nCapitalPagado", "Cap. pag.", 9, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalCap", "Saldo cap.", 10, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteres", "Int.", 11, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresPagado", "Int. pag.", 13, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalInt", "Saldo int.", 14, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresComp", "Int. comp.", 15, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresCompPago", "Int. comp. pag.", 16, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalIntComp", "Saldo int. comp.", 17, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraGenerado", "Mora. gen.", 18, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraPagada", "Mora. pag.", 19, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalMor", "Saldo mora", 20, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtros", "Otros", 21, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtrosPagado", "Otros pag.", 22, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalOtr", "Saldo otros", 23, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalTot", "Saldo total", 24, DataGridViewContentAlignment.MiddleRight, "#,0.00");
        }

        private void limpiar()
        {
            cboMoneda1.SelectedIndex = -1;
            txtSaldoCapital.Text = "";
            txtSaldoInteres.Text = "";
            txtSaldoIntComp.Text = "";
            txtSaldoMora.Text = "";
            txtSaldoOtros.Text = "";
            txtTotalDeuda.Text = "";
            txtTasaInteres.Text = "";
            txtTasaMoratoria.Text = "";
            txtDiasAtraso.Text = "";
            cboEstadoCredito1.SelectedIndex = -1;

            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Focus();

            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            dtgPpg.DataSource = null;
        }

        private void frmConsolidacionPlanPagos_FormClosed(object sender, FormClosedEventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCuentaCli1.LiberarCuenta();
            limpiar();
        }


        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "nAtraso";
            drfila[1] = credito.nAtraso;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nSaldoCapital";
            drfila[1] = (credito.IdMoneda == 1) ? (credito.nCapitalDesembolso - credito.nCapitalPagado) : (credito.nCapitalDesembolso - credito.nCapitalPagado) * Convert.ToDecimal(clsVarApl.dicVarGen["nTipoCambio"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idContable";
            drfila[1] = (credito.nSaldoCapitalVenc > 0)?  credito.idCondContableNormal : credito.idCondContableNormal;
            dtTablaParametros.Rows.Add(drfila);


            //drfila = dtTablaParametros.NewRow();
            //drfila[0] = "idCuenta";
            //drfila[1] = conBusCuentaCli.txtNroBusqueda.Text;
            //dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

    }
}
