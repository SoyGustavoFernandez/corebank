using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.BotonesBase;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using CLI.Presentacion;
using CRE.CapaNegocio;
using EntityLayer;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCargarGastos : frmBase
    {

        #region Variables

        public clsCNConfigGastComiSeg ConfigGastComiSeg = new clsCNConfigGastComiSeg();
        private DataTable dtAuxDetalleGastos;
        int nfilaActualSeleccionada = 0;
        int nSwitchAgregar = 0; //1: El botón Guardar se comporta como 'AGREGAR NUEVO GASTO'
                                //2: El botón Guardar se comporta como 'ELIMINAR GASTO'
        private int nidPlanPagos = 0;
        public DataTable dtCargaGasto = new DataTable("dtCargaGasto"); //Contendrá los nuevos gastos a cargar al plan de pagos

        public DataTable dtKardex = new DataTable("TablaKardexCargaGastos");
        public DataTable dtDetalleKardex = new DataTable("TablaDetalleKardexCargaGastos");
        
        public Int32 pnIdCliente;
        public DataTable dtbPlanPagos;
        public Int32 pnIdNumCuenta;
        public string pcTipoBusqueda;
        public string pcEstadoCredito;
        public Int32 nNumCuotas =0;

        #endregion

        #region Eventos

        private void frmCargarGastos_Load(object sender, EventArgs e)
        {
            LimpiarControles();
            DefinirEstructuraKardex();
        }

        private void frmCargarGastos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.conBusCuentaCli.LiberarCuenta();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatos();
        } 

        private void chcAplicaTodo_Click(object sender, EventArgs e)
        {
            if (nNumCuotas == 0)
            {
                MessageBox.Show("No existe plan de pagos de la cuenta.", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCuentaCli.Focus();
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dtgPlanPagos.Rows)
                {
                    row.Cells["lAplicar"].Value = chcAplicaTodo.Checked;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Inicio - Registro de Carga de Gastos", btnGrabar);
            if (dtbPlanPagos.Rows.Count == 0)
            {
                MessageBox.Show("Se requiere un Plan de Pagos para Esta Operación", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {


                #region Agregar
                //Verificar como se va comportar el boton guardar(Agregar o Eliminar Gasto)            
                if (nSwitchAgregar == 1)//AGREGAR
                {
                    decimal nValorOtros;//es el valor sea fijo o porcentual del gasto a cargar
                    Int32 nIdTipoGasto = Convert.ToInt32(this.cboTipoGasto.SelectedValue.ToString());
                    if (this.txtMontoCarga.Text.ToString().Equals(""))
                    {
                        nValorOtros = 0;
                    }
                    else
                    {
                        nValorOtros = Convert.ToDecimal(this.txtMontoCarga.Text.ToString());
                    }
                    DataSet ds = new DataSet("dsplanPagos");
                    ds.Tables.Add(dtbPlanPagos);
                    ds.Tables.Add(dtCargaGasto);//Añdadir su detalle de Gastos
                    //Carga Kardex
                    ds.Tables.Add(dtKardex);//En caso de que no se haya hecho check en chcConfigAsientosContables, éste datatable estará vacío
                    //Carga Detalle Kardex
                    ds.Tables.Add(dtDetalleKardex);//En caso de que no se haya hecho check en chcConfigAsientosContables, éste datatable estará vacío
                    string XMLPpg = ds.GetXml();
                    clsCNPlanPago objPpg = new clsCNPlanPago();

                    int idAplicaConcepto = Convert.ToInt32(cboTipoValor.SelectedValue) == 1 ? 7 : Convert.ToInt32(cboAplicaConcepto.SelectedValue);

                    DataTable dtbGuardarGasto = objPpg.CNGuardarCargarGasto(XMLPpg, nIdTipoGasto, nValorOtros, nidPlanPagos, idAplicaConcepto, 
                                                                                Convert.ToInt32(cboTipoValor.SelectedValue));
                    MessageBox.Show("La Carga de Gastos se ha registrado correctamente.", "Guardar Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /*========================================================================================
                     * REGISTRO DE RASTREO
                     ========================================================================================*/

                    this.registrarRastreo(conBusCuentaCli.nIdCliente, conBusCuentaCli.nValBusqueda, "Carga de Gasto - Agregar gasto completada", btnGrabar);

                    /*========================================================================================
                     * FIN DEL REGISTRO DE RASTREO
                     ========================================================================================*/

                    ds.Tables.Remove(dtbPlanPagos);
                    ds.Tables.Remove(dtCargaGasto);
                    ds.Tables.Remove(dtKardex);
                    ds.Tables.Remove(dtDetalleKardex);

                    //Quitar los elementos de la Tabla Carga Gasto
                    dtCargaGasto.Clear();
                    dtbPlanPagos.Clear();
                    dtKardex.Clear();
                    dtDetalleKardex.Clear();
                }
                # endregion

                #region Eliminar
                if (nSwitchAgregar == 2)//ELIMINAR
                {
                    //===== Validar que se haya seleccionado un Gasto por lo menos para poder eliminar
                    int nCantGastosSelecParaEliminar = 0;
                    if (dtgDetalleGastos.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtgDetalleGastos.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dtgDetalleGastos.Rows[i].Cells["Eliminar"].Value) == 1)
                            {
                                nCantGastosSelecParaEliminar++;
                                break;
                            }
                        }
                    }
                    if (nCantGastosSelecParaEliminar == 0)
                    {
                        MessageBox.Show("Debe seleccionar un Gasto Cargado Para Eliminar.", "Eliminar Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //==============================================//


                    int nfilaseleccionadaPPG = Convert.ToInt32(this.dtgPlanPagos.CurrentRow.Index);

                    //Recorrer la tabla de Detalle para eliminar los seleccionados
                    Decimal nGastoEliminar = 0;
                    Decimal nNuevoCargaGasto = 0;

                    for (int i = 0; i < dtAuxDetalleGastos.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(this.dtAuxDetalleGastos.Rows[i]["Eliminar"]) == 1)
                        {
                            if (dtAuxDetalleGastos.Rows[i]["cTipoValor"].ToString().Equals("PORCENTUAL COMPUESTO"))
                            {
                                if (dtAuxDetalleGastos.Rows[i]["cAplicaConc"].ToString().Equals("SALDO CAPITAL"))
                                {
                                    Decimal nValorTasaEfectivaDiaria = Convert.ToDecimal(Math.Pow((1.0 + (Convert.ToDouble (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()) / 100)), (1.0 / 30.0))) - 1;
                                    Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nSaldoCapital"]) * Convert.ToDecimal(Math.Pow((1.0 + (double)nValorTasaEfectivaDiaria), Convert.ToInt32(dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nNumDiaCuota"]))) - Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nSaldoCapital"])), 1);

                                    nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);
                                }
                            }
                            if (dtAuxDetalleGastos.Rows[i]["cTipoValor"].ToString().Equals("PORCENTUAL SIMPLE"))
                            {
                                if (dtAuxDetalleGastos.Rows[i]["cAplicaConc"].ToString().Equals("SALDO CAPITAL"))
                                {
                                    Decimal nValorTasaEfectivaDiaria = (Convert.ToDecimal (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()) / 100) / 30;
                                    Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nSaldoCapital"]) * nValorTasaEfectivaDiaria * Convert.ToInt32(dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nNumDiaCuota"])), 1);

                                    nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);

                                }
                                if (dtAuxDetalleGastos.Rows[i]["cAplicaConc"].ToString().Equals("MONTO PRESTAMO"))
                                {
                                    Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nCapitalDesembolso"]) * Convert.ToDecimal (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()) / 100), 1);

                                    nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);
                                }

                                if (dtAuxDetalleGastos.Rows[i]["cAplicaConc"].ToString().Equals("CUOTA (CAPITAL + INTERÉS)"))
                                {
                                    Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()) / 100;
                                    Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * (Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nCapital"]) + Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nInteres"]))), 1);

                                    nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);
                                }

                                if (dtAuxDetalleGastos.Rows[i]["cAplicaConc"].ToString().Equals("CAPITAL"))
                                {
                                    Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()) / 100;
                                    Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * Convert.ToDecimal (dtbPlanPagos.Rows[nfilaseleccionadaPPG]["nCapital"])), 1);

                                    nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);
                                }
                            }
                            if (dtAuxDetalleGastos.Rows[i]["cTipoValor"].ToString().Equals("FIJO"))
                            {
                                Decimal nMontoGasto = Math.Round(Convert.ToDecimal (dtAuxDetalleGastos.Rows[i]["nValor"].ToString()), 1);

                                nGastoEliminar = nGastoEliminar + Convert.ToDecimal(nMontoGasto);
                            }

                        }//Fin del cálculo de Gastos que se van a mantener
                    }

                    nNuevoCargaGasto = Convert.ToDecimal(dtgPlanPagos.Rows[nfilaseleccionadaPPG].Cells["nOtros"].Value) - nGastoEliminar;
                    dtgPlanPagos.Rows[nfilaseleccionadaPPG].Cells["nOtros"].Value = nNuevoCargaGasto;
                    dtgPlanPagos.Rows[nfilaseleccionadaPPG].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[nfilaseleccionadaPPG].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[nfilaseleccionadaPPG].Cells["nCapital"].Value);


                    DataSet ds = new DataSet("dsplanPagos");
                    ds.Tables.Add(dtbPlanPagos);
                    dtAuxDetalleGastos.TableName = "TablaDetalleGasto";
                    ds.Tables.Add(dtAuxDetalleGastos);
                    String XMLPpg = ds.GetXml();
                    XMLPpg = clsCNFormatoXML.EncodingXML(XMLPpg);
                    clsCNPlanPago objPpg = new clsCNPlanPago();
                    DataTable dtbGuardarGasto = objPpg.CNEliminarGasto(XMLPpg, nNuevoCargaGasto);
                    MessageBox.Show("La Carga de Gastos se ha eliminado correctamente.", "Eliminar Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnQuitar.Enabled = false;

                    /*========================================================================================
                     * REGISTRO DE RASTREO
                     ========================================================================================*/

                    this.registrarRastreo(conBusCuentaCli.nIdCliente, conBusCuentaCli.nValBusqueda, "Carga de Gasto - Eliminar gasto completada", btnGrabar);

                    /*========================================================================================
                     * FIN DEL REGISTRO DE RASTREO
                     ========================================================================================*/

                    ds.Tables.Remove(dtbPlanPagos);

                    //Limpiar
                    //Quitar los elementos de la Tabla Carga Gasto
                    dtCargaGasto.Clear();
                    dtbPlanPagos.Clear();
                    dtKardex.Clear();
                    dtDetalleKardex.Clear();
                }
                #endregion
                this.HabilitarGridPlanPagos(true);
                this.HabilitarControles(true);
                this.CargarPlanPagosCreditoCli(pnIdNumCuenta);
                this.dtgDetalleGastos.Enabled = true;
                chcAplicaTodo.Enabled = true;
                grbGasto.Enabled = true;

                this.btnGrabar.Enabled = false;
                this.txtMontoCarga.Clear();
                this.chcAplicaTodo.Checked = false;

                //Una vez Agregado/Eliminado el Gasto, mantener la fila seleccionada al recargar
                int nUbicacion = Convert.ToInt32(this.dtgPlanPagos.CurrentRow.Index);
                dtgPlanPagos.Rows[nUbicacion].Selected = true;
                CargarDetalleGasto(nUbicacion);

                dtgPlanPagos.Focus();
            }
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Fin - Registro de Carga de Gastos", btnGrabar);
        }

        private void cboGrupoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdGrupoGasto = Convert.ToInt32(cboGrupoGasto.SelectedValue);

            cboTipoGasto.CargarTipGasto(nIdGrupoGasto);
            cboTipoGasto.Enabled = nIdGrupoGasto > 0;
        }

        private void cboTipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cTipoValor = cboTipoValor.GetItemText(cboTipoValor.SelectedItem);

            //Valor 1 = FIJO
            lblPorcentaje.Visible = !(Convert.ToInt16(cboTipoValor.SelectedValue)==1);
            cboAplicaConcepto.Enabled = !(Convert.ToInt16(cboTipoValor.SelectedValue) == 1);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int nCount = 0;

            #region Validaciones

            if (Convert.ToInt32(cboTipoGasto.SelectedValue) == 0)
            {
                MessageBox.Show("No se ha seleccionado un tipo de gasto", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoGasto.Focus();
                return;
            }

            if (nNumCuotas == 0)
            {
                MessageBox.Show("No existe plan de pagos a cargar gasto ", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCuentaCli.txtNroBusqueda.Focus();
                return;
            }

            if (txtMontoCarga.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese el monto a cargar", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMontoCarga.Focus();
                return;
            }

            //Validar las posibles combinaciones aplicables a los conceptos
            if (cboTipoValor.Text.Equals("PORCENTUAL COMPUESTO"))
            {
                if (!cboAplicaConcepto.Text.Equals("SALDO CAPITAL"))
                {
                    MessageBox.Show("Los gastos con tasa PORCENTUAL COMPUESTO sólo pueden afectar a SALDO CAPITAL", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (cboTipoValor.Text.Equals("PORCENTUAL SIMPLE"))
            {
                if (!(cboAplicaConcepto.Text.Equals("SALDO CAPITAL") || cboAplicaConcepto.Text.Equals("MONTO PRESTAMO")
                       || cboAplicaConcepto.Text.Equals("CUOTA (CAPITAL + INTERÉS)") || cboAplicaConcepto.Text.Equals("CAPITAL")))
                {
                    MessageBox.Show("Los Gastos con tasa PORCENTUAL SIMPLE sólo pueden afectar a:" +
                    Environment.NewLine + "SALDO CAPITAL" +
                    Environment.NewLine + "MONTO PRESTAMO" +
                    Environment.NewLine + "CUOTA (CAPITAL + INTERÉS)" +
                    Environment.NewLine + "CAPITAL"
                    , "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //Fin valdación posibles combinaciones

            #endregion

            Decimal nTotalMontoCargaGasto = 0;

            #region AplicarGasto_TODOS

            if (chcAplicaTodo.Checked == true)
            {
                for (int i = 0; i < nNumCuotas; i++)
                {
                    //Calcular el Monto del Gasto a Adicionar de acuerdo a la selección 
                    if (cboTipoValor.Text.Equals("PORCENTUAL COMPUESTO"))
                    {
                        if (cboAplicaConcepto.Text.Equals("SALDO CAPITAL"))
                        {
                            Decimal nValorTasaEfectivaDiaria = Convert.ToDecimal(Math.Pow((1.0 + (Convert.ToDouble (this.txtMontoCarga.Text) / 100)), (1.0 / 30.0))) - 1;
                            Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"]) * Convert.ToDecimal(Math.Pow((1.0 + (double)nValorTasaEfectivaDiaria), Convert.ToInt32(dtbPlanPagos.Rows[i]["nNumDiaCuota"]))) - Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"])), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                            if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                            {
                                if (i == (nNumCuotas - 1))
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                                }
                                else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                                }
                            }
                        }
                    }
                    if (cboTipoValor.Text.Equals("PORCENTUAL SIMPLE"))
                    {
                        if (cboAplicaConcepto.Text.Equals("SALDO CAPITAL"))
                        {
                            Decimal nValorTasaEfectivaDiaria = (Convert.ToDecimal (this.txtMontoCarga.Text) / 100) / 30;
                            Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"]) * nValorTasaEfectivaDiaria * Convert.ToInt32(dtbPlanPagos.Rows[i]["nNumDiaCuota"])), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                            if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                            {
                                if (i == (nNumCuotas - 1))
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                                }
                                else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                                }
                            }
                        }
                        if (cboAplicaConcepto.Text.Equals("MONTO PRESTAMO"))
                        {
                            Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapitalDesembolso"]) * Convert.ToDecimal (this.txtMontoCarga.Text) / 100), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                            if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                            {
                                if (i == (nNumCuotas - 1))
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                                }
                                else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                                }
                            }
                        }

                        if (cboAplicaConcepto.Text.Equals("CUOTA (CAPITAL + INTERÉS)"))
                        {
                            Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (this.txtMontoCarga.Text) / 100;
                            Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * (Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapital"]) + Convert.ToDecimal (dtbPlanPagos.Rows[i]["nInteres"]))), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                            if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                            {
                                if (i == (nNumCuotas - 1))
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                                }
                                else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                                }
                            }
                        }

                        if (cboAplicaConcepto.Text.Equals("CAPITAL"))
                        {
                            Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (this.txtMontoCarga.Text) / 100;
                            Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapital"])), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                            if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                            {
                                if (i == (nNumCuotas - 1))
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                                }
                                else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                                {
                                    RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                                }
                            }
                        }
                    }
                    if (cboTipoValor.Text.Equals("FIJO"))
                    {
                        Decimal nMontoGasto = Math.Round(Convert.ToDecimal (this.txtMontoCarga.Text), 1);
                        dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                        dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                        AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                        nTotalMontoCargaGasto = nTotalMontoCargaGasto + nMontoGasto;

                        if (chcConfigAsientosContables.Checked == true)//En la última cuota llenar la tabla 'detalle de Kardex', y también la tabla Kardex
                        {
                            if (i == (nNumCuotas - 1))
                            {
                                RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 2);
                            }
                            else//llenar la tabla 'detalle de Kardex' , pero no el Kardex 
                            {
                                RellenardtKardex(nMontoGasto, nTotalMontoCargaGasto, i, 0);
                            }
                        }
                    }

                }
            }
            #endregion

            #region AplicarGastos_Específico

            else if (chcAplicaTodo.Checked == false)
            {
                for (int i = 0; i < nNumCuotas; i++)
                {
                    if (Convert.ToInt32(dtgPlanPagos.Rows[i].Cells["lAplicar"].Value) == 1)
                    {
                        //Calcular el Monto del Gasto a Adicionar de acuerdo a la selección 
                        if (cboTipoValor.Text.Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (cboAplicaConcepto.Text.Equals("SALDO CAPITAL"))
                            {
                                Decimal nValorTasaEfectivaDiaria = Convert.ToDecimal(Math.Pow((1.0 + (Convert.ToDouble (this.txtMontoCarga.Text) / 100)), (1.0 / 30.0))) - 1;
                                Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"]) * Convert.ToDecimal(Math.Pow((1.0 + (double)nValorTasaEfectivaDiaria), Convert.ToInt32(dtbPlanPagos.Rows[i]["nNumDiaCuota"]))) - Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"])), 1);
                                dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                                dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                                AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                                if (chcConfigAsientosContables.Checked == true)
                                {
                                    RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                                }
                            }
                        }
                        if (cboTipoValor.Text.Equals("PORCENTUAL SIMPLE"))
                        {
                            if (cboAplicaConcepto.Text.Equals("SALDO CAPITAL"))
                            {
                                Decimal nValorTasaEfectivaDiaria = (Convert.ToDecimal (this.txtMontoCarga.Text) / 100) / 30;
                                Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nSaldoCapital"]) * nValorTasaEfectivaDiaria * Convert.ToInt32(dtbPlanPagos.Rows[i]["nNumDiaCuota"])), 1);
                                dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                                dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                                AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                                if (chcConfigAsientosContables.Checked == true)
                                {
                                    RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                                }
                            }
                            if (cboAplicaConcepto.Text.Equals("MONTO PRESTAMO"))
                            {
                                Decimal nMontoGasto = Math.Round((Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapitalDesembolso"]) * Convert.ToDecimal (this.txtMontoCarga.Text) / 100), 1);
                                dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                                dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                                AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                                if (chcConfigAsientosContables.Checked == true)
                                {
                                    RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                                }
                            }

                            if (cboAplicaConcepto.Text.Equals("CUOTA (CAPITAL + INTERÉS)"))
                            {
                                Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (this.txtMontoCarga.Text) / 100;
                                Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * (Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapital"]) + Convert.ToDecimal (dtbPlanPagos.Rows[i]["nInteres"]))), 1);
                                dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                                dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                                AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                                if (chcConfigAsientosContables.Checked == true)
                                {
                                    RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                                }
                            }

                            if (cboAplicaConcepto.Text.Equals("CAPITAL"))
                            {
                                Decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal (this.txtMontoCarga.Text) / 100;
                                Decimal nMontoGasto = Math.Round((nTasaCalculadaDelTipoGasto * Convert.ToDecimal (dtbPlanPagos.Rows[i]["nCapital"])), 1);
                                dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                                dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                                AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                                if (chcConfigAsientosContables.Checked == true)
                                {
                                    RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                                }
                            }
                        }
                        if (cboTipoValor.Text.Equals("FIJO"))
                        {
                            Decimal nMontoGasto = Math.Round(Convert.ToDecimal (this.txtMontoCarga.Text), 1);
                            dtgPlanPagos.Rows[i].Cells["nOtros"].Value = Convert.ToDecimal (dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + nMontoGasto;
                            dtgPlanPagos.Rows[i].Cells["nMontoTotal"].Value = Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nOtros"].Value) + Convert.ToDecimal(dtgPlanPagos.Rows[i].Cells["nCapital"].Value);

                            AgregarCargaGasto(Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuenta"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idCuota"]), Convert.ToInt32(dtbPlanPagos.Rows[i]["idPlanPagos"]), nMontoGasto);

                            if (chcConfigAsientosContables.Checked == true)
                            {
                                RellenardtKardex(nMontoGasto, nMontoGasto, i, 1);
                            }
                        }
                    }
                    else
                    {
                        nCount++;
                    }
                }
                if (nCount == nNumCuotas)
                {
                    MessageBox.Show("Debe de Seleccionar la Cuota donde se Cargarán los Gastos", "Validación de Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dtgPlanPagos.Focus();
                    return;
                }
            }

            #endregion

            grbGasto.Enabled = false;
            dtgDetalleGastos.Enabled = false;
            btnQuitar.Enabled = false;
            nSwitchAgregar = 1;//Habilitar el 'boton guardar' como 'AGREGAR NUEVO GASTO'

            btnAgregar.Enabled = false;
            btnGrabar.Enabled = true;
            this.HabilitarGridPlanPagos(false);
            HabilitarControles(false);
            btnCancelar.Enabled = true;
            chcAplicaTodo.Checked = false;

            //pulsar btn_guardar
            btnGrabar_Click(sender, e);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleGastos.SelectedRows.Count > 0)
            {
                if (Convert.ToBoolean(dtgDetalleGastos.SelectedRows[0].Cells["Eliminar"].Value) == false)
                {
                    if (Convert.ToDecimal(dtgDetalleGastos.SelectedRows[0].Cells["nGastoPag"].Value) > 0)
                    {
                        MessageBox.Show("Este Gasto ya está PARCIALMENTE PAGADO, no se puede eliminar", "Validación eliminar Carga de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtAuxDetalleGastos.Rows[dtgDetalleGastos.SelectedRows[0].Index]["Eliminar"] = false;
                        return;
                    }
                }

                btnAgregar.Enabled = false;
                btnGrabar.Enabled = true;

                nSwitchAgregar = 2; //2: El botón Guardar se comporta como 'ELIMINAR GASTO'

                //pulsar btn_guardar
                btnGrabar_Click(sender, e);
                chcConfigAsientosContables.Enabled = true;
                chcConfigAsientosContables.Checked = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            dtAuxDetalleGastos.Clear();
            dtgDetalleGastos.DataSource = null;

            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;

            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            grbGasto.Enabled = false;
            chcAplicaTodo.Enabled = false;
            chcConfigAsientosContables.Enabled = false;

            conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.LiberarCuenta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.conBusCuentaCli.LiberarCuenta();
        }

        private void dtgPlanPagos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgPlanPagos.SelectedRows.Count > 0)
            {
                //Habilitar para que se pueda seleccionar las cuotas del plan de pagos
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = false;
                nSwitchAgregar = 1;//1: El botón Guardar se comporta como 'AGREGAR NUEVO GASTO'
                grbGasto.Enabled = true;
                chcAplicaTodo.Enabled = true;

                for (int i = 0; i < nNumCuotas; i++)
                {
                    if (this.chcAplicaTodo.Checked == true && Convert.ToInt32(dtgPlanPagos.Rows[i].Cells["lAplicar"].Value) == 0)
                    {
                        this.chcAplicaTodo.Checked = false;
                    }
                }

                int nfilaseleccionada = Convert.ToInt32(this.dtgPlanPagos.CurrentRow.Index);
                CargarDetalleGasto(nfilaseleccionada);
            }
        }

        private void dtgDetalleGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnQuitar.Enabled = true;
            grbGasto.Enabled = false;
            btnAgregar.Enabled = false;
            chcAplicaTodo.Enabled = false;
            chcAplicaTodo.Checked = false;
            chcConfigAsientosContables.Enabled = false;

            int nfilaseleccionadaPPG = Convert.ToInt32(this.dtgPlanPagos.CurrentRow.Index);
            //Habilitar solo la cuota actual
            for (int i = 0; i < nNumCuotas; i++)
            {
                if (nfilaseleccionadaPPG == i)
                {
                    dtgPlanPagos.Rows[i].Cells["lAplicar"].Value = true;
                }
                else
                {
                    dtgPlanPagos.Rows[i].Cells["lAplicar"].Value = false;
                }
            }
        }

        private void txtMontoCarga_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMontoCarga.Text))
            {
                decimal nMonto = 0M;
                decimal.TryParse(txtMontoCarga.Text, out nMonto);
                txtMontoCarga.Text = string.Format("{0:#,0.00}", nMonto);
            }
        }

        #endregion

        #region Métodos

        public frmCargarGastos()
        {
            InitializeComponent();
            FiltrarGrupoGasto();
            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";
            pcTipoBusqueda = this.conBusCuentaCli.cTipoBusqueda;
            pcEstadoCredito = this.conBusCuentaCli.cEstado;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            lblPorcentaje.Visible = false;
            cboTipoGasto.Enabled = false;
            grbGasto.Enabled = false;
            chcConfigAsientosContables.Enabled = false;
        }

        private void CargarDatos()
        {
            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                LimpiarControles();
                conBusCuentaCli.Focus();
                return;
            }
            else
            {
                pnIdNumCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
                //===================================================================================
                //--Cargando Datos de la Cuenta Seleccionada
                //===================================================================================
                CRE.CapaNegocio.clsCNCredito objCredito = new CapaNegocio.clsCNCredito();
                DataTable dtbCredito = objCredito.CNdtDataCreditoCobro(pnIdNumCuenta);


                txtTipoCredito.Text = dtbCredito.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = dtbCredito.Rows[0]["IdMoneda"].ToString();
                txtMonto.Text = dtbCredito.Rows[0]["nCapitalDesembolso"].ToString();
                txtCuotas.Text = dtbCredito.Rows[0]["nCuotas"].ToString();
                //===================================================================================
                //--Cargando Datos del Plan de Pagos de la Cuenta Seleccionada
                //===================================================================================
                CargarPlanPagosCreditoCli(pnIdNumCuenta);
                HabilitarControles(true);
                HabilitarGridPlanPagos(true);

                btnAgregar.Enabled = true;
                grbGasto.Enabled = true;
                chcConfigAsientosContables.Enabled = true;
            }
        }

        public void HabilitarControles(bool bVal)
        {
            this.btnAgregar.Enabled = bVal;
            this.btnCancelar.Enabled = bVal;
            this.txtMontoCarga.Enabled = bVal;
            this.chcAplicaTodo.Enabled = bVal;
            this.chcConfigAsientosContables.Checked = false;
        }

        public void LimpiarControles()
        {
            conBusCuentaCli.txtCodIns.Text=string.Empty;
            conBusCuentaCli.txtCodAge.Text = string.Empty;
            conBusCuentaCli.txtCodMod.Text = string.Empty;
            conBusCuentaCli.txtCodMon.Text = string.Empty;
            conBusCuentaCli.txtNroBusqueda.Text = string.Empty;
            conBusCuentaCli.txtCodCli.Text = string.Empty;
            conBusCuentaCli.txtNroDoc.Text = string.Empty;
            conBusCuentaCli.txtEstado.Text = string.Empty;
            conBusCuentaCli.txtNombreCli.Text = string.Empty;
            txtTipoCredito.Text = string.Empty;
            cboMoneda.SelectedIndex = -1;
            txtMonto.Text = string.Empty;
            txtCuotas.Text = string.Empty;
            txtMontoCarga.Text = string.Empty;
            cboGrupoGasto.SelectedIndex = -1;
            cboTipoGasto.SelectedIndex = -1;
            cboTipoValor.SelectedIndex = -1;
            cboAplicaConcepto.SelectedIndex = -1;
            CargarPlanPagosCreditoCli(0);
            chcAplicaTodo.Checked = false;
        }

        public void FormatoGridPlanPagos()
        {
            foreach (DataGridViewColumn column in dtgPlanPagos.Columns)
            {
                column.Visible = false;
            }

            dtgPlanPagos.Columns["idCuota"].Visible = true;
            dtgPlanPagos.Columns["nCapital"].Visible = true;
            dtgPlanPagos.Columns["nInteres"].Visible = true;
            dtgPlanPagos.Columns["nSaldoCapital"].Visible = true;
            dtgPlanPagos.Columns["nOtros"].Visible = true;
            dtgPlanPagos.Columns["dFechaProg"].Visible = true;
            dtgPlanPagos.Columns["lAplicar"].Visible = true;

            dtgPlanPagos.Columns["idCuota"].HeaderText = "Cuota";
            dtgPlanPagos.Columns["nCapital"].HeaderText = "Capital";
            dtgPlanPagos.Columns["nInteres"].HeaderText = "Interés";
            dtgPlanPagos.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";
            dtgPlanPagos.Columns["nOtros"].HeaderText = "Gastos Cargados";
            dtgPlanPagos.Columns["dFechaProg"].HeaderText = "Fec.Prog";
            dtgPlanPagos.Columns["lAplicar"].HeaderText = "Aplicar";

            dtgPlanPagos.Columns["idCuota"].Width = 40;
            dtgPlanPagos.Columns["nCapital"].Width = 60;
            dtgPlanPagos.Columns["nInteres"].Width = 90;
            dtgPlanPagos.Columns["nSaldoCapital"].Width = 92;
            dtgPlanPagos.Columns["nOtros"].Width = 50;
            dtgPlanPagos.Columns["dFechaProg"].Width = 70;
            dtgPlanPagos.Columns["lAplicar"].Width = 40;
            
            dtgPlanPagos.Columns["nInteres"].ReadOnly = true;
            dtgPlanPagos.Columns["nSaldoCapital"].ReadOnly = true;
            dtgPlanPagos.Columns["nOtros"].ReadOnly = true;
        }

        public void HabilitarGridPlanPagos(bool bVal)
        {
            dtgPlanPagos.ReadOnly = !bVal;
            dtgPlanPagos.Columns["lAplicar"].ReadOnly = !bVal;
            dtgPlanPagos.Columns["idCuota"].ReadOnly = bVal;
            dtgPlanPagos.Columns["nCapital"].ReadOnly = bVal;
            dtgPlanPagos.Columns["dFechaProg"].ReadOnly = bVal;
            dtgPlanPagos.Columns["nOtros"].ReadOnly = true;
            dtgPlanPagos.Columns["nMontoTotal"].ReadOnly = bVal;

            dtgPlanPagos.Columns["nInteres"].ReadOnly = true;
            dtgPlanPagos.Columns["nSaldoCapital"].ReadOnly = true;
        }

        public void CargarPlanPagosCreditoCli(int nNumCredito)
        {
            dtbPlanPagos = new clsCNPlanPago().CNdtPlanPago(nNumCredito);
            dtbPlanPagos.Columns.Add("nMontoTotal", typeof(decimal));
            dtbPlanPagos.Columns.Add("lAplicar", typeof(Boolean));

            dtgPlanPagos.DataSource = dtbPlanPagos;
            FormatoGridPlanPagos();

            //Seteando el currentRow
            if (dtbPlanPagos.Rows.Count > 0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=1 fila=0 (visible en el dataGridView)
                dtgPlanPagos.CurrentCell = dtgPlanPagos[2, 0];
            }

            //===================================================================================
            //--Asignando Valor a la Columna Aplicar Gasto
            //===================================================================================
            nNumCuotas = dtbPlanPagos.Rows.Count;
            if (nNumCuotas > 0)
            {
                for (int i = 0; i < nNumCuotas; i++)
                {
                    dtgPlanPagos.Rows[i].Cells["lAplicar"].Value = false;
                }

                //Cargar Detalles Gasto
                int nfilaseleccionada = Convert.ToInt32(dtgPlanPagos.CurrentRow.Index);
                CargarDetalleGasto(nfilaseleccionada);
                dtgPlanPagos.Focus();
            }
        }

        private void DefinirEstructuraKardex()
        {
            //Definiendo estructura Kardex
            dtKardex.Columns.Add("dFechaOpe", typeof(DateTime));
            dtKardex.Columns.Add("idProducto", typeof(int));
            dtKardex.Columns.Add("idCanal", typeof(int));
            dtKardex.Columns.Add("idMoneda", typeof(int));
            dtKardex.Columns.Add("IdUsuario", typeof(int));
            dtKardex.Columns.Add("idCuenta", typeof(int));
            dtKardex.Columns.Add("idTipoOperacion", typeof(int));
            dtKardex.Columns.Add("idEstadoKardex", typeof(int));
            dtKardex.Columns.Add("nMontoOperacion", typeof(decimal));
            dtKardex.Columns.Add("nMontoCapital", typeof(decimal));
            dtKardex.Columns.Add("nMontoInteres", typeof(decimal));
            dtKardex.Columns.Add("nMontoMora", typeof(decimal));
            dtKardex.Columns.Add("nMontoOtros", typeof(decimal));
            dtKardex.Columns.Add("nITFNormal", typeof(decimal));
            dtKardex.Columns.Add("idTipoIngresoEgreso", typeof(int));
            dtKardex.Columns.Add("idAgeSaldo", typeof(int));
            dtKardex.Columns.Add("idAgeOpera", typeof(int));
            dtKardex.Columns.Add("idModulo", typeof(int));
            dtKardex.Columns.Add("idTipoAfeCaj", typeof(int));
            dtKardex.Columns.Add("nAtrasoPago", typeof(int));
            dtKardex.Columns.Add("idTipoPago", typeof(int));

            //Definiendo estructura del detalle de kardex
            dtDetalleKardex.Columns.Add("idCuenta", typeof(int));
            dtDetalleKardex.Columns.Add("idPlanPagos", typeof(int));
            dtDetalleKardex.Columns.Add("idCuota", typeof(int));
            dtDetalleKardex.Columns.Add("nMonto", typeof(decimal));
            dtDetalleKardex.Columns.Add("idTipoAfeCaj", typeof(int));
            dtDetalleKardex.Columns.Add("idTipoTransaccion", typeof(int));
            dtDetalleKardex.Columns.Add("idConcepto", typeof(int));
            dtDetalleKardex.Columns.Add("idCondicionContable", typeof(int));

            //Definir estructura de la tabla CargaGastos (Nuevos gastos que se cargarán al plan de pagos)
            dtCargaGasto.Columns.Add("nidNumCuenta", typeof(int));
            dtCargaGasto.Columns.Add("nIdNumCuota", typeof(int));
            dtCargaGasto.Columns.Add("idPlanPagos", typeof(int));
            dtCargaGasto.Columns.Add("nGasto", typeof(decimal));
        }

        private void AgregarCargaGasto(int nIdCuenta, int nCuota, int nIdPlanPagos, Decimal nGasto)//Se agregará los 'Otros Gastos' 
        {
            DataRow fila = dtCargaGasto.NewRow();
            fila["nidNumCuenta"] = nIdCuenta;
            fila["nIdNumCuota"] = nCuota;
            fila["idPlanPagos"] = nIdPlanPagos;
            fila["nGasto"] = nGasto;
            dtCargaGasto.Rows.Add(fila);
        }

        private void RellenardtKardex(Decimal nValorGasto, Decimal nMontoTotalCargaGasto, int nIndiceActual, int nRellenarKardex)
        {
            //nRellenarKardex: 1: Cuando se debe rellenar el Kardex que afecta sólo a una cuota
            //                  2: Cuando se debe rellenar el Kardex que afecta a todas las cuotas
            //                  n:No se va genrar Kardex

            DataRow dr = dtKardex.NewRow();

            dr["dFechaOpe"] = clsVarGlobal.dFecSystem;
            //Llenando el Kardex
            dr["idProducto"] = Convert.ToInt32(cboTipoGasto.SelectedValue);
            dr["idCanal"] = 1;//VENTANILLA
            dr["idMoneda"] = Convert.ToInt32(cboMoneda.SelectedValue);
            dr["IdUsuario"] = clsVarGlobal.User.idUsuario;
            dr["idCuenta"] = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
            dr["idTipoOperacion"] = 3;
            dr["idEstadoKardex"] = 1;//NORMAL
            dr["nMontoOperacion"] = (nRellenarKardex == 1) ? Convert.ToDecimal(nValorGasto) :  Convert.ToDecimal(nMontoTotalCargaGasto);  
            dr["nMontoCapital"] = 0;
            dr["nMontoInteres"] = 0;
            dr["nMontoMora"] = 0;
            dr["nMontoOtros"] = (nRellenarKardex == 1) ? Convert.ToDecimal(nValorGasto) : Convert.ToDecimal(nMontoTotalCargaGasto);  
            dr["nITFNormal"] = 0;
            dr["idTipoIngresoEgreso"] = 2;//EGRESO
            dr["idAgeSaldo"] = clsVarGlobal.nIdAgencia;
            dr["idAgeOpera"] = clsVarGlobal.nIdAgencia;
            dr["idModulo"] = 1;
            dr["idTipoAfeCaj"] = 2;//Proceso
            dr["nAtrasoPago"] = 0;
            dr["idTipoPago"] = 1;//Efectivo

            dtKardex.Rows.Add(dr);

            //LLenando el Detalle de Kardex
            DataRow drfila = dtDetalleKardex.NewRow();
            drfila["idCuenta"] = Convert.ToInt32(dtbPlanPagos.Rows[nIndiceActual]["idCuenta"]);
            drfila["idPlanPagos"] = Convert.ToInt32(dtbPlanPagos.Rows[nIndiceActual]["idPlanPagos"]);
            drfila["idCuota"] = Convert.ToInt32(dtbPlanPagos.Rows[nIndiceActual]["idCuota"]);
            drfila["nMonto"] = Convert.ToDecimal(nValorGasto);
            drfila["idTipoAfeCaj"] = 2;
            drfila["idTipoTransaccion"] = 2;
            drfila["idConcepto"] = Convert.ToInt32(cboTipoGasto.SelectedValue);
            drfila["idCondicionContable"] = Convert.ToInt32(dtbPlanPagos.Rows[nIndiceActual]["idContable"]);
            this.dtDetalleKardex.Rows.Add(drfila);
        }

        private void CargarDetalleGasto(int nfilaseleccionada)
        {
            int nNumCuotaActual = Convert.ToInt32(this.dtgPlanPagos.Rows[nfilaseleccionada].Cells["idCuota"].Value);
            nidPlanPagos = Convert.ToInt32(this.dtgPlanPagos.Rows[nfilaseleccionada].Cells["idPlanPagos"].Value);

            int nIdNumCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
            clsCNPlanPago ObjPlanPagos = new clsCNPlanPago();

            dtAuxDetalleGastos = ObjPlanPagos.ListarDetalleGasto(nIdNumCuenta, nNumCuotaActual, nidPlanPagos);

            dtAuxDetalleGastos.Columns.Add("Eliminar", typeof(bool));
            dtAuxDetalleGastos.Columns["Eliminar"].ReadOnly = false;

            dtAuxDetalleGastos.Columns.Add("nidNumCuenta", typeof(int));
            dtAuxDetalleGastos.Columns["nidNumCuenta"].ReadOnly = false;

            dtAuxDetalleGastos.Columns.Add("nIdNumCuota", typeof(int));
            dtAuxDetalleGastos.Columns["nIdNumCuota"].ReadOnly = false;

            dtAuxDetalleGastos.Columns.Add("idPlanPagos", typeof(int));
            dtAuxDetalleGastos.Columns["idPlanPagos"].ReadOnly = false;

            for (int i = 0; i < dtAuxDetalleGastos.Rows.Count; i++)
            {
                dtAuxDetalleGastos.Rows[i]["Eliminar"] = false;
                dtAuxDetalleGastos.Rows[i]["nidNumCuenta"] = nIdNumCuenta;
                dtAuxDetalleGastos.Rows[i]["nIdNumCuota"] = nNumCuotaActual;
                dtAuxDetalleGastos.Rows[i]["idPlanPagos"] = nidPlanPagos;
            }

            //Si el tipo de valor es FIJO no se debe mostrar a que se campo se afecta ''
            for (int i = 0; i < dtAuxDetalleGastos.Rows.Count; i++)
            {
                if (dtAuxDetalleGastos.Rows[i]["cTipoValor"].ToString().Equals("FIJO"))
                {
                    dtAuxDetalleGastos.Rows[i]["cAplicaConc"] = "";
                }
            }

            dtgDetalleGastos.ReadOnly = false;//para permitir hacer check en los Gastos elegidos
            dtgDetalleGastos.DataSource = dtAuxDetalleGastos;

            dtgDetalleGastos.Columns["idCargaGasto"].Visible = false;
            dtgDetalleGastos.Columns["nValor"].HeaderText = "Valor";
            dtgDetalleGastos.Columns["nValor"].ReadOnly = true;

            dtgDetalleGastos.Columns["nGasto"].HeaderText = "Monto";
            dtgDetalleGastos.Columns["cGasto"].HeaderText = "Descripción";

            dtgDetalleGastos.Columns["nidTipoGasto"].Visible = false;
            dtgDetalleGastos.Columns["nidTipoGasto"].ReadOnly = true;

            dtgDetalleGastos.Columns["nGasto"].ReadOnly = true;
            dtgDetalleGastos.Columns["cGasto"].ReadOnly = true;

            dtgDetalleGastos.Columns["nidNumCuenta"].Visible = false;
            dtgDetalleGastos.Columns["nIdNumCuota"].Visible = false;

            dtgDetalleGastos.Columns["cTipoValor"].ReadOnly = true;
            dtgDetalleGastos.Columns["cTipoValor"].HeaderText = "Tipo de valor";
            dtgDetalleGastos.Columns["cAplicaConc"].ReadOnly = true;
            dtgDetalleGastos.Columns["cAplicaConc"].HeaderText = "Aplica a";

            dtgDetalleGastos.Columns["idTipoValor"].Visible = false;
            dtgDetalleGastos.Columns["idAplicaConc"].Visible = false;

            dtgDetalleGastos.Columns["nGastoPag"].Visible = false;

            dtgDetalleGastos.Columns["idPlanPagos"].Visible = false;

            dtgDetalleGastos.Columns["nValor"].Width = 53;
            dtgDetalleGastos.Columns["cGasto"].Width = 80;
            dtgDetalleGastos.Columns["nGasto"].Width = 57;
            dtgDetalleGastos.Columns["cTipoValor"].Width = 110;
            dtgDetalleGastos.Columns["cAplicaConc"].Width = 90;
        }

        private void FiltrarGrupoGasto()
        {
            var dtGrupoGastos = (DataTable)cboGrupoGasto.DataSource;
            dtGrupoGastos = dtGrupoGastos.AsEnumerable().Where(x => Convert.ToInt32(x["idGrupoConcepto"]) != 1).CopyToDataTable();
            cboGrupoGasto.DataSource = dtGrupoGastos;
        }

        #endregion

    }
}
