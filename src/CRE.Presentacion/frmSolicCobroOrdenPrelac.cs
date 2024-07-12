using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmSolicCobroOrdenPrelac : frmBase
    {

        #region Variables globales

        private const decimal nPorciento = 100.00M;
        DataTable dtCredito = new DataTable("dtCredito");
        DataTable dtPlanPago = new DataTable("dtPlanPago");
        DataTable dtDatSolicitud = null, dtDatCre = null;
        clsLisPrelacion lista = new clsLisPrelacion();
        clsPlanPago objplanpago;
        string pcTipoBusqueda, pnEstadoCredito;
        clsFunUtiles objfunciones = new clsFunUtiles();
        clsCNSolicitudAmortiza cnsoliAmortiza = new clsCNSolicitudAmortiza();
        clsSolicitudAmortiza soliAmortiza = null;
        private int idMoneda = 0;
        private int idProducto = 0;
        private int idCli = 0;

        clsCNPlanPago cnPlanPago = new clsCNPlanPago();
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarconcepto();
            formatogridconcepto();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargaDatos();
        }

        private void dtgConcepto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int nOrden = Convert.ToInt32(dtgConcepto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (nOrden > 5 || nOrden < 1)
                {
                    MessageBox.Show("Por favor ingrese un valor entre 1 y 5", "Validacion orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lista = null;
                    lista = new clsLisPrelacion();
                    cargarconcepto();
                    formatogridconcepto();
                    return;
                }

                lista = (clsLisPrelacion)dtgConcepto.DataSource;
                var listaordenada = lista.OrderByDescending(x => x.nOrden);

                lista = null;
                lista = new clsLisPrelacion();
                foreach (var item in listaordenada)
                {
                    lista.Add(new clsPrelacion() { idcuenta = item.idcuenta, cConcepto = item.cConcepto, nOrden = item.nOrden });
                }

                dtgConcepto.DataSource = null;
                dtgConcepto.DataSource = lista;
                formatogridconcepto();
            }
        }

        private void dtgConcepto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            LimpiarDistribucion();
        }

        private void rbtnOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOrden.Checked)
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                grbDistribucion.Enabled = true;
                txtDisTotal.Enabled = true;
                txtDisTotal.Focus();
                txtDisTotal.SelectAll();

                txtDisCapital.Enabled = false;
                txtDisInteres.Enabled = false;
                txtDisIntComp.Enabled = false;
                txtDisGastos.Enabled = false;
                txtDisMora.Enabled = false;

                dtgConcepto.Visible = true;
            }
            else
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                grbDistribucion.Enabled = false;

                dtgConcepto.Visible = false;
            }

        }

        private void rbtnPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPorcentaje.Checked)
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                grbPorcentaje.Enabled = true;
                grbDistribucion.Enabled = true;
                txtDisTotal.Enabled = true;
                txtDisTotal.Focus();
                txtDisTotal.SelectAll();

                txtDisCapital.Enabled = false;
                txtDisInteres.Enabled = false;
                txtDisIntComp.Enabled = false;
                txtDisGastos.Enabled = false;
                txtDisMora.Enabled = false;

            }
            else
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                this.grbPorcentaje.Enabled = false;
            }
        }

        private void rbtnMontos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                grbDistribucion.Enabled = true;
                txtDisTotal.Enabled = false;

                txtDisCapital.Enabled = true;
                txtDisInteres.Enabled = true;
                txtDisIntComp.Enabled = true;
                txtDisGastos.Enabled = true;
                txtDisMora.Enabled = true;

                txtDisCapital.Focus();
                txtDisCapital.SelectAll();
            }
            else
            {
                LimpiarPorcentaje();
                LimpiarDistribucion();
                grbDistribucion.Enabled = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                clsPlanPago pladistribuido = distriCuotaPrelacion(txtDisTotal.nDecValor);

                for (int i = 0; i < pladistribuido.Count(); i++)
                {
                    pladistribuido[i].idPlanPago = objplanpago[i].idPlanPago;
                    pladistribuido[i].idContable = 1;
                }

                DataSet ds = new DataSet("dsPlanPagos");

                #region Plan de pagos

                DataTable dtPlanPagDis = convertToDataTable(pladistribuido);
                dtPlanPagDis.TableName = "dtPlanPagos";
                ds.Tables.Add(dtPlanPagDis);

                #endregion

                DataTable dtDetalleCargaGasto = new clsCNPlanPago().DistribuirGastosPagados(dtPlanPagDis);
                dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
                ds.Tables.Add(dtDetalleCargaGasto);

                #region Guardar los Datos de la persona que está pagando la cuota
                {
                    DataTable dtPagador = new DataTable("TablaDatosPagador");

                    dtPagador.Columns.Add("cNroDNI", typeof(string));
                    dtPagador.Columns.Add("cNomCliente", typeof(string));
                    dtPagador.Columns.Add("cDireccion", typeof(string));

                    DataRow drfila = dtPagador.NewRow();
                    drfila["cNroDNI"] = conBusCuentaCli.txtNroDoc.Text;
                    drfila["cNomCliente"] = conBusCuentaCli.txtNombreCli.Text;
                    drfila["cDireccion"] = "";
                    dtPagador.Rows.Add(drfila);

                    ds.Tables.Add(dtPagador);
                }
                #endregion

                string xmlPpg = ds.GetXml();//Plan Pagos y DetalleCargaGastos en caso se haya realizado pagos
                xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);

                int idCuenta;
                if (soliAmortiza == null)
                {
                    idCuenta = conBusCuentaCli.nIdCuenta;
                }
                else
                {
                    idCuenta = soliAmortiza.listaDetalle.Where(x => x.idEstado == 1).ToList()[0].idCuenta;
                }

                decimal nItf = clsVarGlobal.nITF * sumardistribucion() / nPorciento;

                //====================================== INSERTAR SOLICITUD AUTORIZACIÓN ORDEN PRELACIÓN  ====================================>
                DataTable dtConcepto = new DataTable("dtConcepto");

                dtConcepto.Columns.Add("cConcepto", typeof(string));
                dtConcepto.Columns.Add("nOrden", typeof(int));

                DataTable dtSolicitudOrdenPrelac = new DataTable("dtSolicitudOrdenPrelac");

                dtSolicitudOrdenPrelac.Columns.Add("idFormaPago", typeof(int));
                dtSolicitudOrdenPrelac.Columns.Add("idcuenta", typeof(int));
                dtSolicitudOrdenPrelac.Columns.Add("nCapital", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nInteres", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nIntComp", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nMora", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nGastos", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nTotal", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nCapitalPorcent", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nInteresPorcent", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nIntCompPorcen", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nMoraPorcent", typeof(Decimal)/*era (double)*/);
                dtSolicitudOrdenPrelac.Columns.Add("nGastosPorcent", typeof(Decimal)/*era (double)*/);

                DataRow fila = dtSolicitudOrdenPrelac.NewRow();
                fila["idcuenta"] = conBusCuentaCli.nValBusqueda;

                //Identificar el tipo Forma de Pago
                if (rbtnOrden.Checked)//Por orden de Recuperación
                {
                    fila["idFormaPago"] = 1;
                    for (int c = 0; c < dtgConcepto.Rows.Count; c++)
                    {
                        DataRow filaConcepto = dtConcepto.NewRow();
                        filaConcepto["cConcepto"] = Convert.ToString(dtgConcepto.Rows[c].Cells[1].Value.ToString());
                        filaConcepto["nOrden"] = Convert.ToInt32(dtgConcepto.Rows[c].Cells[2].Value.ToString());
                        dtConcepto.Rows.Add(filaConcepto);
                    }
                }
                if (rbtnPorcentaje.Checked)//Por porcentaje del pago
                {
                    fila["idFormaPago"] = 2;
                }
                if (rbtnMontos.Checked)//Por montos libres
                {
                    fila["idFormaPago"] = 3;
                }
                fila["nCapitalPorcent"] = Convert.ToDecimal (txtPorCapital.Text);
                fila["nInteresPorcent"] = Convert.ToDecimal (txtPorInteres.Text);
                fila["nIntCompPorcen"] = Convert.ToDecimal (txtPorIntComp.Text);
                fila["nMoraPorcent"] = Convert.ToDecimal (txtPorMora.Text);
                fila["nGastosPorcent"] = Convert.ToDecimal (txtPorGastos.Text);

                fila["nCapital"] = Convert.ToDecimal (txtDisCapital.Text);
                fila["nInteres"] = Convert.ToDecimal (txtDisInteres.Text);
                fila["nIntComp"] = Convert.ToDecimal (txtDisIntComp.Text);
                fila["nMora"] = Convert.ToDecimal (txtDisMora.Text);
                fila["nGastos"] = Convert.ToDecimal (txtDisGastos.Text);
                fila["nTotal"] = Convert.ToDecimal (txtDisCapital.Text) +
                                Convert.ToDecimal (txtDisInteres.Text) +
                                Convert.ToDecimal (txtDisIntComp.Text) +
                                Convert.ToDecimal (txtDisMora.Text) +
                                Convert.ToDecimal (txtDisGastos.Text);

                dtSolicitudOrdenPrelac.Rows.Add(fila);

                DataSet dsSolicitudOrdenPrelac = new DataSet("dsSolicitudOrdenPrelac");
                dsSolicitudOrdenPrelac.Tables.Add(dtSolicitudOrdenPrelac);

                DataSet dsConcepto = new DataSet("dsConcepto");
                dsConcepto.Tables.Add(dtConcepto);

                string xmlSolicitudOrdenPrelac = dsSolicitudOrdenPrelac.GetXml();
                xmlSolicitudOrdenPrelac = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlSolicitudOrdenPrelac);

                string xmlConcepto = dsConcepto.GetXml();
                xmlConcepto = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlConcepto);

                int idCliente = Convert.ToInt32(this.conBusCuentaCli.nIdCliente);
                int idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
                int idProducto = Convert.ToInt32(this.cboSubProducto.SelectedValue);
                int nNumCredito = this.conBusCuentaCli.nValBusqueda;
                int idMotivo = 2;//'A Solicitud del Cliente' -- Tabla  SI_FinMotivoExtorno
                string cMotivo = "Solicita Usar Opción Orden Prelación";
                decimal nValAproba = Convert.ToDecimal(txtDisTotal.Text);

                DataTable dtSolicAutoriz = new clsCNPlanPago().SolicitarAutorizOrdenPrelac(xmlSolicitudOrdenPrelac, xmlConcepto,
                                                                            clsVarGlobal.nIdAgencia, idCliente, 1,
                                                                            idMoneda, idProducto, nValAproba, nNumCredito,
                                                                            clsVarGlobal.dFecSystem, idMotivo, cMotivo, 1,
                                                                            Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario));
                if (Convert.ToInt32(dtSolicAutoriz.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    MessageBox.Show(dtSolicAutoriz.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtSolicAutoriz.Rows[0]["idSolAproba"].ToString(), "Registro Solicitud Autoriz. Orden Prelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Convert.ToInt32(dtSolicAutoriz.Rows[0]["idEstadoSol"]) == 4)//Rechazado 
                    {//Actualizar estado de la Autorizac.
                        idCuenta = this.conBusCuentaCli.nValBusqueda;
                        DataSet dsResultadosConsulta = new clsCNPlanPago().BuscarSolicitudAutorizOrdenPrelac(idCuenta, idCliente, idMoneda, idProducto);
                    }
                }
                else
                {
                    MessageBox.Show(dtSolicAutoriz.Rows[0]["cMensaje"].ToString(), "Registro Solicitud Autoriz. Orden Prelación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //============================================================================================================================>
                ds.Dispose();
                conBusCuentaCli.LiberarCuenta();

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LiberarCuenta();

            txtPorCapital.TextChanged -= txtPorCapital_TextChanged;
            txtPorInteres.TextChanged -= txtPorInteres_TextChanged;
            txtPorIntComp.TextChanged -= txtPorIntComp_TextChanged;
            txtPorMora.TextChanged -= txtPorMora_TextChanged;
            txtPorGastos.TextChanged -= txtPorGastos_TextChanged;

            txtDisCapital.TextChanged -= txtDisCapital_TextChanged;
            txtDisInteres.TextChanged -= txtDisInteres_TextChanged;
            txtDisIntComp.TextChanged -= txtDisIntComp_TextChanged;
            txtDisMora.TextChanged -= txtDisMora_TextChanged;
            txtDisGastos.TextChanged -= txtDisGastos_TextChanged;
            txtDisTotal.TextChanged -= txtDisTotal_TextChanged;

            LimpiarAntesPago();
            LimpiarDistribucion();
            LimpiarPorcentaje();
            LimpiarDespuesPago();
            conBusCuentaCli.Enabled = true;
            cargarconcepto();
            formatogridconcepto();

            rbtnOrden.Checked = false;
            rbtnMontos.Checked = false;
            rbtnPorcentaje.Checked = false;
            grbFormaPago.Enabled = false;
            dtgConcepto.Enabled = true;
            soliAmortiza = null;
            conSolesDolar.iMagenMoneda(1);

            txtMonTotal.Text = "0.00";
            txtItf.Text = "0.00";
            txtRedondeo.Text = "0.00";

            cboMoneda.SelectedIndex = -1;
            cboTipoCredito.SelectedIndex = -1;
            cboSubTipoCredito.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            cboSubProducto.SelectedIndex = -1;
            cboDestinoCredito.SelectedIndex = -1;

            dtgConcepto.Visible = false;
            lblEstSolicitud.Text = "";
            lblEstSolicitud.Visible = false;
            dtgConcepto.ForeColor = Color.Black;

            txtPorCapital.TextChanged += txtPorCapital_TextChanged;
            txtPorInteres.TextChanged += txtPorInteres_TextChanged;
            txtPorIntComp.TextChanged += txtPorIntComp_TextChanged;
            txtPorMora.TextChanged += txtPorMora_TextChanged;
            txtPorGastos.TextChanged += txtPorGastos_TextChanged;

            txtDisCapital.TextChanged += txtDisCapital_TextChanged;
            txtDisInteres.TextChanged += txtDisInteres_TextChanged;
            txtDisIntComp.TextChanged += txtDisIntComp_TextChanged;
            txtDisMora.TextChanged += txtDisMora_TextChanged;
            txtDisGastos.TextChanged += txtDisGastos_TextChanged;
            txtDisTotal.TextChanged += txtDisTotal_TextChanged;

            conBusCuentaCli.Focus();
            conBusCuentaCli.txtNroBusqueda.Focus();
            conBusCuentaCli.txtNroBusqueda.Select();
        }

        private void txtPorCapital_TextChanged(object sender, EventArgs e)
        {
            if (sumaporcentaje() > nPorciento)
            {
                MessageBox.Show("Por favor ingresar un valor valido que no supere el 100% en total", "Validación porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorCapital.Text = "0.00";
                txtPorCapital.Focus();
                txtPorCapital.SelectAll();
                txtPorTotal.Text = string.Format("{0:0.00}", sumaporcentaje());
                return;
            }
            asignarPorcentaje();
            asignardespuespago();

            if (txtDesCapital.nDecValor < 0.00M)
            {
                MessageBox.Show("Por favor ingrese valor válido que no supere el capital", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorCapital.Text = "0.00";
                txtPorCapital.Focus();
                txtPorCapital.SelectAll();
                return;
            }
            asignartotal();
        }

        private void txtPorInteres_TextChanged(object sender, EventArgs e)
        {
            if (sumaporcentaje() > 100)
            {
                MessageBox.Show("Por favor ingresar un valor valido que no supere el 100% en total", "Validación porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorInteres.Text = "0.00";
                txtPorInteres.Focus();
                txtPorInteres.SelectAll();
                txtPorTotal.Text = string.Format("{0:0.00}", sumaporcentaje());
                return;
            }
            asignarPorcentaje();
            asignardespuespago();
            if (txtDesInteres.nDecValor < 0.00M)
            {
                MessageBox.Show("Por favor ingrese un valor válido que no supere el interes", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorInteres.Text = "0.00";
                txtPorInteres.Focus();
                txtPorInteres.SelectAll();
                return;
            }
            asignartotal();
        }

        private void txtPorIntComp_TextChanged(object sender, EventArgs e)
        {
            if (sumaporcentaje() > 100)
            {
                MessageBox.Show("Por favor ingresar un valor valido que no supere el 100% en total", "Validación porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorIntComp.Text = "0.00";
                txtPorIntComp.Focus();
                txtPorIntComp.SelectAll();
                txtPorIntComp.Text = string.Format("{0:0.00}", sumaporcentaje());
                return;
            }
            asignarPorcentaje();
            asignardespuespago();

            if (txtDesIntComp.nDecValor < 0.00M)
            {
                MessageBox.Show("Por favor ingrese un valor válido que no supere el interés compensatorio", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorIntComp.Text = "0.00";
                txtPorIntComp.Focus();
                txtPorIntComp.SelectAll();
                return;
            }
            asignartotal();
        }

        private void txtPorMora_TextChanged(object sender, EventArgs e)
        {
            if (sumaporcentaje() > 100)
            {
                MessageBox.Show("Por favor ingresar un valor valido que no supere el 100% en total", "Validación porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorMora.Text = "0.00";
                txtPorMora.Focus();
                txtPorMora.SelectAll();
                txtPorTotal.Text = string.Format("{0:0.00}", sumaporcentaje());
                return;
            }
            asignarPorcentaje();
            asignardespuespago();

            if (txtDesMora.nDecValor < 0.00M)
            {
                MessageBox.Show("Por favor ingrese un valor válido que no supere la mora", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorMora.Text = "0.00";
                txtPorMora.Focus();
                txtPorMora.SelectAll();
                return;
            }
            asignartotal();
        }

        private void txtPorGastos_TextChanged(object sender, EventArgs e)
        {
            if (sumaporcentaje() > 100)
            {
                MessageBox.Show("Por favor ingresar un valor valido que no supere el 100% en total", "Validación porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorGastos.Text = "0.00";
                txtPorGastos.Focus();
                txtPorGastos.SelectAll();
                txtPorTotal.Text = string.Format("{0:0.00}", sumaporcentaje());
                return;
            }
            asignarPorcentaje();
            asignardespuespago();

            if (txtDesGastos.nDecValor < 0.00M)
            {
                MessageBox.Show("Por favor ingrese un valor válido que no supere los gastos", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorGastos.Text = "0.00";
                txtPorGastos.Focus();
                txtPorGastos.SelectAll();
                return;
            }
            asignartotal();
        }

        private void txtDisCapital_TextChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                asignardespuespago();

                if (txtDesCapital.nDecValor < 0.00M)
                {
                    MessageBox.Show("Por favor ingrese un valor válido que no supere el capital", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisCapital.Text = "0.00";
                    txtDisCapital.Focus();
                    txtDisCapital.SelectAll();
                    return;
                }

                txtDisTotal.Text = string.Format("{0:0.00}", sumardistribucion());
            }


        }

        private void txtDisInteres_TextChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                asignardespuespago();

                if (txtDesInteres.nDecValor < 0.00M)
                {
                    MessageBox.Show("Por favor ingrese un valor válido que no supere el interes", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisInteres.Text = "0.00";
                    txtDisInteres.Focus();
                    txtDisInteres.SelectAll();
                    return;
                }
                txtDisTotal.Text = string.Format("{0:0.00}", sumardistribucion());
            }

        }

        private void txtDisIntComp_TextChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                asignardespuespago();

                if (txtDesIntComp.nDecValor < 0.00M)
                {
                    MessageBox.Show("Por favor ingrese un valor válido que no supere el interés compensatorio", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisIntComp.Text = "0.00";
                    txtDisIntComp.Focus();
                    txtDisIntComp.SelectAll();
                    return;
                }
                txtDisTotal.Text = string.Format("{0:0.00}", sumardistribucion());
            }
        }

        private void txtDisMora_TextChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                asignardespuespago();

                if (txtDesMora.nDecValor < 0.00M)
                {
                    MessageBox.Show("Por favor ingrese un valor válido que no supere la mora", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisMora.Text = "0.00";
                    txtDisMora.Focus();
                    txtDisMora.SelectAll();
                    return;
                }
                txtDisTotal.Text = string.Format("{0:0.00}", sumardistribucion());
            }

        }

        private void txtDisGastos_TextChanged(object sender, EventArgs e)
        {
            if (rbtnMontos.Checked)
            {
                asignardespuespago();

                if (txtDesGastos.nDecValor < 0.00M)
                {
                    MessageBox.Show("Por favor ingrese un valor válido que no supere los gastos", "Validación montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisGastos.Text = "0.00";
                    txtDisGastos.Focus();
                    txtDisGastos.SelectAll();
                    return;
                }
                txtDisTotal.Text = string.Format("{0:0.00}", sumardistribucion());
            }

        }

        private void txtDisTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtDisTotal.nDecValor > txtAntTotal.nDecValor)
            {
                txtDisCapital.Text = "0.00";
                txtDisInteres.Text = "0.00";
                txtDisIntComp.Text = "0.00";
                txtDisMora.Text = "0.00";
                txtDisGastos.Text = "0.00";

                MessageBox.Show("Ingrese un valor menor al Total de la deuda", "Validación Total", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarDistribucion();
                txtDisTotal.Text = "0.00";
                txtDisTotal.SelectAll();
                return;
            }

            if (this.rbtnOrden.Checked)
            {
                txtDisCapital.Text = "0.00";
                txtDisInteres.Text = "0.00";
                txtDisIntComp.Text = "0.00";
                txtDisMora.Text = "0.00";
                txtDisGastos.Text = "0.00";

                int nsumorden = lista.Sum(x => x.nOrden);
                if (nsumorden != 15)
                {
                    MessageBox.Show("Porfavor ingrese un orden correcto de los conceptos", "Validación Orden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                asignarDistribucion();
                asignardespuespago();
            }

            if (this.rbtnPorcentaje.Checked)
            {
                txtDisCapital.Text = "0.00";
                txtDisInteres.Text = "0.00";
                txtDisIntComp.Text = "0.00";
                txtDisMora.Text = "0.00";
                txtDisGastos.Text = "0.00";

                asignarPorcentaje();
                asignardespuespago();
            }

            asignartotal();
        }

        private void frmCobroPrelacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        #endregion

        #region Metodos

        #region Constructor

        public frmSolicCobroOrdenPrelac()
        {
            InitializeComponent();
            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            pcTipoBusqueda = this.conBusCuentaCli.cTipoBusqueda;
            pnEstadoCredito = this.conBusCuentaCli.cEstado;
        }

        #endregion

        private bool validar()
        {
            if (this.txtMonTotal.nDecValor == 0M)
            {
                MessageBox.Show("Monto a cobrar no es válido", "Validación registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMonTotal.Focus();
                return false;
            }

            return true;
        }

        private void asignartotal()
        {
            decimal nItf = clsVarGlobal.nITF * sumardistribucion() / nPorciento;
            Decimal /*era double*/nRedondeo = 0.00m;

            txtItf.Text = string.Format("{0:0.00}", objfunciones.truncar(Convert.ToDecimal /*era ToDouble*/(nItf), 2, Convert.ToInt16(cboMoneda.SelectedValue)));

            txtMonTotal.Text = string.Format("{0:0.00}", objfunciones.redondearBCR(Convert.ToDecimal /*era ToDouble*/(txtItf.nDecValor + sumardistribucion()),
                                                                                ref nRedondeo,
                                                                                Convert.ToInt16(cboMoneda.SelectedValue),
                                                                                true,
                                                                                true));

            txtRedondeo.Text = string.Format("{0:0.00}", nRedondeo);
        }

        private void asignardespuespago()
        {
            txtDesCapital.Text = string.Format("{0:#,0.00}", txtAntCapital.nDecValor - txtDisCapital.nDecValor);
            txtDesInteres.Text = string.Format("{0:#,0.00}", txtAntInteres.nDecValor - txtDisInteres.nDecValor);
            txtDesIntComp.Text = string.Format("{0:#,0.00}", txtAntIntComp.nDecValor - txtDisIntComp.nDecValor);
            txtDesMora.Text = string.Format("{0:#,0.00}", txtAntMora.nDecValor - txtDisMora.nDecValor);
            txtDesGastos.Text = string.Format("{0:#,0.00}", txtAntGastos.nDecValor - txtDisGastos.nDecValor);
            txtDesTotal.Text = string.Format("{0:#,0.00}", sumardespuespago());
        }

        private void asignarPorcentaje()
        {
            txtPorTotal.Text = string.Format("{0:#,0.00}", sumaporcentaje());
            txtDisCapital.Text = string.Format("{0:#,0.00}", Math.Round(txtPorCapital.nDecValor * txtDisTotal.nDecValor / nPorciento, 2));
            txtDisInteres.Text = string.Format("{0:#,0.00}", Math.Round(txtPorInteres.nDecValor * txtDisTotal.nDecValor / nPorciento, 2));
            txtDisIntComp.Text = string.Format("{0:#,0.00}", Math.Round(txtPorIntComp.nDecValor * txtDisTotal.nDecValor / nPorciento, 2));
            txtDisMora.Text = string.Format("{0:#,0.00}", Math.Round(txtPorMora.nDecValor * txtDisTotal.nDecValor / nPorciento, 2));
            txtDisGastos.Text = string.Format("{0:#,0.00}", Math.Round(txtPorGastos.nDecValor * txtDisTotal.nDecValor / nPorciento, 2));
        }

        private void asignarDistribucion()
        {
            clsPlanPago pladistribuido = distriCuotaPrelacion(txtDisTotal.nDecValor);

            txtDisCapital.Text = pladistribuido.Sum(x => x.nCapitalPagado).ToString("#,0.00");
            txtDisGastos.Text = pladistribuido.Sum(x => x.nOtrosPagado).ToString("#,0.00");
            txtDisIntComp.Text = pladistribuido.Sum(x => x.nInteresCompPago).ToString("#,0.00");
            txtDisInteres.Text = pladistribuido.Sum(x => x.nInteresPagado).ToString("#,0.00");
            txtDisMora.Text = pladistribuido.Sum(x => x.nMoraPagada).ToString("#,0.00");
        }

        private clsPlanPago distriCuotaPrelacion(decimal nMontoPagado)
        {
            clsPlanPago auxplan = (clsPlanPago)objplanpago.Clone();
            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.nOtrosPagado = 0.00M);
            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.nMoraPagada = 0.00M);
            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.nInteresCompPago = 0M);
            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.nInteresPagado = 0.00M);
            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.nCapitalPagado = 0.00M);

            if (rbtnOrden.Checked)
            {
                #region Orden de Conceptos
                for (int i = 0; i < objplanpago.Count; i++)
                {
                    for (int j = 0; j < lista.Count; j++)
                    {
                        var concepto = (from item in lista
                                        where item.nOrden == j + 1
                                        select item).FirstOrDefault();

                        if (concepto.cConcepto == "GASTOS" && nMontoPagado > 0.00M)
                        {
                            if (objplanpago[i].nOtrosSaldo > nMontoPagado)
                            {
                                auxplan[i].nOtrosPagado = auxplan[i].nOtrosPagado + nMontoPagado;
                                nMontoPagado = 0.00M;
                                break;
                            }
                            else
                            {
                                nMontoPagado = nMontoPagado - objplanpago[i].nOtrosSaldo;
                                auxplan[i].nOtrosPagado = objplanpago[i].nOtrosSaldo;
                            }
                        }

                        if (concepto.cConcepto == "MORA" && nMontoPagado > 0.00M)
                        {
                            if (objplanpago[i].nMoraSaldo > nMontoPagado)
                            {
                                auxplan[i].nMoraPagada = auxplan[i].nMoraPagada + nMontoPagado;
                                nMontoPagado = 0.00M;
                                break;
                            }
                            else
                            {
                                nMontoPagado = nMontoPagado - objplanpago[i].nMoraSaldo;
                                auxplan[i].nMoraPagada = objplanpago[i].nMoraSaldo;
                            }
                        }

                        if (concepto.cConcepto == "INT. COMPENSATORIO" && nMontoPagado > 0.00M)
                        {
                            if (objplanpago[i].nIntCompSaldo > nMontoPagado)
                            {
                                auxplan[i].nInteresCompPago = auxplan[i].nInteresCompPago + nMontoPagado;
                                nMontoPagado = 0.00M;
                                break;
                            }
                            else
                            {
                                nMontoPagado = nMontoPagado - objplanpago[i].nIntCompSaldo;
                                auxplan[i].nInteresCompPago = objplanpago[i].nIntCompSaldo;
                            }
                        }

                        if (concepto.cConcepto == "INTERES" && nMontoPagado > 0.00M)
                        {
                            if (objplanpago[i].nInteresSaldo > nMontoPagado && objplanpago[i].nAtrasoCuota > 0)
                            {
                                auxplan[i].nInteresPagado = auxplan[i].nInteresPagado + nMontoPagado;
                                nMontoPagado = 0.00M;
                                break;
                            }
                            else
                            {
                                if (objplanpago[i].nAtrasoCuota > 0)
                                {
                                    nMontoPagado = nMontoPagado - objplanpago[i].nInteresSaldo;
                                    auxplan[i].nInteresPagado = objplanpago[i].nInteresSaldo;
                                }
                                else
                                {
                                    nMontoPagado = nMontoPagado - objplanpago[i].nInteresFecha;
                                    auxplan[i].nInteresPagado = objplanpago[i].nInteresFecha;
                                }
                            }
                        }

                        if (concepto.cConcepto == "CAPITAL" && nMontoPagado > 0.00M)
                        {
                            if (objplanpago[i].nCapitalSaldo > nMontoPagado)
                            {
                                auxplan[i].nCapitalPagado = auxplan[i].nCapitalPagado + nMontoPagado;
                                nMontoPagado = 0.00M;
                                break;
                            }
                            else
                            {
                                nMontoPagado = nMontoPagado - objplanpago[i].nCapitalSaldo;
                                auxplan[i].nCapitalPagado = objplanpago[i].nCapitalSaldo;
                            }
                        }
                    }
                }

                #endregion
            }

            if (rbtnMontos.Checked || rbtnPorcentaje.Checked)
            {
                #region Montos libres
                decimal nCapital = 0.00M, nInteres = 0.00M, nIntComp = 0M, nMora = 0.00M, nGastos = 0.00M;
                nCapital = txtDisCapital.nDecValor;
                nInteres = txtDisInteres.nDecValor;
                nIntComp = txtDisIntComp.nDecValor;
                nMora = txtDisMora.nDecValor;
                nGastos = txtDisGastos.nDecValor;

                for (int i = 0; i < objplanpago.Count; i++)
                {

                    if (objplanpago[i].nOtrosSaldo > nGastos)
                    {
                        auxplan[i].nOtrosPagado = auxplan[i].nOtrosPagado + nGastos;
                        nGastos = 0.00M;
                        break;
                    }
                    else
                    {
                        nGastos = nGastos - objplanpago[i].nOtrosSaldo;
                        auxplan[i].nOtrosPagado = objplanpago[i].nOtrosSaldo;
                    }

                }
                for (int i = 0; i < objplanpago.Count; i++)
                {

                    if (objplanpago[i].nMoraSaldo > nMora)
                    {
                        auxplan[i].nMoraPagada = auxplan[i].nMoraPagada + nMora;
                        nMora = 0.00M;
                        break;
                    }
                    else
                    {
                        nMora = nMora - objplanpago[i].nMoraSaldo;
                        auxplan[i].nMoraPagada = objplanpago[i].nMoraSaldo;
                    }

                }
                for (int i = 0; i < objplanpago.Count; i++)
                {

                    if (objplanpago[i].nIntCompSaldo > nIntComp)
                    {
                        auxplan[i].nInteresCompPago = auxplan[i].nInteresCompPago + nIntComp;
                        nIntComp = 0.00M;
                        break;
                    }
                    else
                    {
                        nIntComp = nIntComp - objplanpago[i].nIntCompSaldo;
                        auxplan[i].nInteresCompPago = objplanpago[i].nIntCompSaldo;
                    }

                }
                for (int i = 0; i < objplanpago.Count; i++)
                {

                    if (objplanpago[i].nInteresSaldo > nInteres)
                    {
                        auxplan[i].nInteresPagado = auxplan[i].nInteresPagado + nInteres;
                        nInteres = 0.00M;
                        break;
                    }
                    else
                    {
                        nInteres = nInteres - objplanpago[i].nInteresSaldo;
                        auxplan[i].nInteresPagado = objplanpago[i].nInteresSaldo;
                    }

                }
                for (int i = 0; i < objplanpago.Count; i++)
                {

                    if (objplanpago[i].nCapitalSaldo > nCapital)
                    {
                        auxplan[i].nCapitalPagado = auxplan[i].nCapitalPagado + nCapital;
                        nCapital = 0.00M;
                        break;
                    }
                    else
                    {
                        nCapital = nCapital - objplanpago[i].nCapitalSaldo;
                        auxplan[i].nCapitalPagado = objplanpago[i].nCapitalSaldo;
                    }

                }

                #endregion
            }

            auxplan.FindAll(x => x.idEstadocuota == 1).ForEach(x => x.dFechaPago = clsVarGlobal.dFecSystem);
            return auxplan;
        }

        private void LimpiarDistribucion()
        {
            txtDisCapital.Text = "0.00";
            txtDisInteres.Text = "0.00";
            txtDisIntComp.Text = "0.00";
            txtDisMora.Text = "0.00";
            txtDisGastos.Text = "0.00";
            txtDisTotal.Text = "0.00";
        }

        private void LimpiarPorcentaje()
        {
            txtPorCapital.Text = "0.00";
            txtPorInteres.Text = "0.00";
            txtPorIntComp.Text = "0.00";
            txtPorMora.Text = "0.00";
            txtPorGastos.Text = "0.00";
            txtPorTotal.Text = "0.00";
        }

        private void LimpiarAntesPago()
        {
            txtAntCapital.Text = "0.00";
            txtAntInteres.Text = "0.00";
            txtAntIntComp.Text = "0.00";
            txtAntMora.Text = "0.00";
            txtAntGastos.Text = "0.00";
            txtAntTotal.Text = "0.00";
        }

        private void LimpiarDespuesPago()
        {
            txtDesCapital.Text = "0.00";
            txtDesInteres.Text = "0.00";
            txtDesIntComp.Text = "0.00";
            txtDesMora.Text = "0.00";
            txtDesGastos.Text = "0.00";
            txtDesTotal.Text = "0.00";
        }

        private void CargaDatos()
        {
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;
            if (String.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = true;
                conBusCuentaCli.btnBusCliente1.Enabled = true;
                return;
            }

            //Validar que no exista una solicitud de condonación pendiente o aprobada
            DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(conBusCuentaCli.nIdCliente, Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show("Existe una solicitud vigente de condonación enviada por:" +
                                "\nUsuario:   " + Convert.ToString(SolicDuplicada.Rows[0]["cNombre"]) +
                                "\nAgencia:   " + Convert.ToString(SolicDuplicada.Rows[0]["cNombreAge"]) + 
                                "\nFecha: " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", 
                                                                                                                                MessageBoxButtons.OK, 
                                                                                                                                MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                return;
            }

            //Busca si existe una solicitud de amortización
            soliAmortiza = cnsoliAmortiza.retornarDatSolAmortiza(conBusCuentaCli.nIdCliente);
            if (soliAmortiza != null)
            {
                if (soliAmortiza.listaDetalle.Count > 0 && soliAmortiza.listaDetalle.Any(x => x.idEstado == 1))
                {
                    MessageBox.Show("Cliente tiene una solicitud de AMORTIZACIÓN.\n"+
                                    "Debe cobrar la amortización correspondiente para poder realizar " + 
                                    "una solicitud de cobro por orden de prelación.", "Pago Amortización", 
                                                                                        MessageBoxButtons.OK, 
                                                                                        MessageBoxIcon.Information);

                    return;
                }
            }

            GetDataCredito(nNumCredito);

            if (soliAmortiza != null)
            {
                if (soliAmortiza.listaDetalle.Count(x => x.idEstado == 1) > 0)
                {
                    CargarCredito();
                    asignarAmortizacion(soliAmortiza, nNumCredito);
                    btnGrabar.Enabled = false;
                    return;
                }
            }

            //================================ Revisar Solicitud de Aprobac. Orden Prelación ==================================>
            int idCuenta = this.conBusCuentaCli.nValBusqueda;
            int idCliente = Convert.ToInt32(conBusCuentaCli.nIdCliente);

            DataSet dsResultadosConsulta = new clsCNPlanPago().BuscarSolicitudAutorizOrdenPrelac(idCuenta, idCliente, idMoneda, idProducto);

            DataTable dtSolAutorizacOrdenPrelac = dsResultadosConsulta.Tables[0];//Datos de la solicitud Orden Prelac
            DataTable dtConceptosOrdenPrelac = dsResultadosConsulta.Tables[1];//Orden de los Conceptos (en caso sea: 'Por orden de Recuperación')
            DataTable dtSolAprobacOrdenPrelac = dsResultadosConsulta.Tables[2];//Estado de la Aprobac

            if (dtSolAutorizacOrdenPrelac.Rows.Count > 0)//Existe solicitud Autorizac.
            {
                // LLenar los campos con los datos de la solicitud de autorizac.
                if (Convert.ToInt32(dtSolAutorizacOrdenPrelac.Rows[0]["idFormaPago"]) == 1)//Por orden de recuperación
                {
                    rbtnOrden.Checked = true;
                    //---------------------------------------- Conceptos ------------------------->                    
                    dtgConcepto.Enabled = false;
                    dtgConcepto.ForeColor = Color.Gray;

                    dtgConcepto.DataSource = null;
                    lista = new clsLisPrelacion();
                    foreach (DataRow row in dtConceptosOrdenPrelac.Rows)
                    {
                        lista.Add(new clsPrelacion()
                                    {
                                        idcuenta = idCuenta,
                                        cConcepto = row["cConcepto"].ToString(),
                                        nOrden = Convert.ToInt32(row["nOrden"])
                                    });
                    }

                    //Reordenar Conceptos Orden Prelación
                    lista = (clsLisPrelacion)lista.OrderByDescending(x => x.nOrden).ToList<clsPrelacion>();
                    dtgConcepto.DataSource = lista;
                    formatogridconcepto();

                    dtgConcepto.Visible = true;
                    //----------------------------------------------------------------------------->
                }

                if (Convert.ToInt32(dtSolAutorizacOrdenPrelac.Rows[0]["idFormaPago"]) == 2)//Por porcentaje del pago
                {
                    rbtnPorcentaje.Checked = true;
                    dtgConcepto.Visible = false;
                }

                if (Convert.ToInt32(dtSolAutorizacOrdenPrelac.Rows[0]["idFormaPago"]) == 3)//Por montos libres
                {
                    rbtnMontos.Checked = true;
                    dtgConcepto.Visible = false;
                }

                CargarCredito();

                txtPorCapital.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nCapitalPorcent"]));
                txtPorInteres.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nInteresPorcent"]));
                txtPorIntComp.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nIntCompPorcen"]));
                txtPorMora.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nMoraPorcent"]));
                txtPorGastos.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nGastosPorcent"]));
                txtPorTotal.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nCapitalPorcent"]) +
                                                                Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nInteresPorcent"]) +
                                                                Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nIntCompPorcen"]) +
                                                                Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nMoraPorcent"]) +
                                                                Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nGastosPorcent"]));


                txtDisCapital.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nCapital"]));
                txtDisInteres.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nInteres"]));
                txtDisIntComp.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nIntComp"]));
                txtDisMora.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nMora"]));
                txtDisGastos.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nGastos"]));
                txtDisTotal.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtSolAutorizacOrdenPrelac.Rows[0]["nTotal"]));

                //--------------------- Deshabilitartodos los textBox --------------->
                grbFormaPago.Enabled = false;

                txtPorCapital.Enabled = false;
                txtPorInteres.Enabled = false;
                txtPorIntComp.Enabled = false;
                txtPorMora.Enabled = false;
                txtPorGastos.Enabled = false;

                txtDisCapital.Enabled = false;
                txtDisInteres.Enabled = false;
                txtDisIntComp.Enabled = false;
                txtDisMora.Enabled = false;
                txtDisGastos.Enabled = false;

                txtDisTotal.Enabled = false;

                btnGrabar.Enabled = true;
                //------------------------------------------------------------------>

                if (dtSolAprobacOrdenPrelac.Rows.Count == 0)//La solicitud de aprobación fué rechazada
                {
                    //Actualizar estado de rechazado de solictud de aprobación
                    MessageBox.Show("La solicitud de Autorizac. para ORDEN PRELACIÓN fué RECHAZADA. Puede solicitar otra solicitud.", "Buscar Solicitud Autoriz. orden Prelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar.Enabled = false;
                }
                else//Tiene un Estado
                {
                    //Datos solicitud de aprobación
                    if (Convert.ToInt32(dtSolAprobacOrdenPrelac.Rows[0]["idEstadoSol"]) == 1)//SOLICITADO
                    {
                        MessageBox.Show("La solicitud de Autorizac. para ORDEN PRELACIÓN ya fue Enviada por:\n \tUsuario:   " + dtSolAprobacOrdenPrelac.Rows[0]["cNombre"] +
                        "\n \tAgencia:   " + dtSolAprobacOrdenPrelac.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(dtSolAprobacOrdenPrelac.Rows[0]["dFecSolici"]).ToShortDateString() +
                        "\n está a la espera de APROBACIÓN.", "Buscar Solicitud Autoriz. orden Prelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.lblEstSolicitud.Text = "Solicitud Autoriz. orden prelación: EN ESPERA DE APROBACIÓN";     
                    }
                    else//APROBADO
                    {
                        MessageBox.Show("La solicitud de Autorizac. para ORDEN PRELACIÓN está APROBADA.", "Buscar Solicitud Autoriz. orden Prelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.lblEstSolicitud.Text = "Solicitud Autoriz. orden prelación: APROBADO";
                        this.lblEstSolicitud.Text = "Solicitud Autoriz. orden prelación: EN ESPERA DE APROBACIÓN";
                    }
                    this.btnGrabar.Enabled = false;
                    lblEstSolicitud.Visible = true;
                }
            }
            grbFormaPago.Enabled = true;
            CargarCredito();
            //=================================================================================================================>
        }

        private void GetDataCredito(int nNumCredito)
        {
            CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
            clsCNSolicitud Solicitud = new clsCNSolicitud();

            dtDatCre = Credito.CNdtDataCreditoCobro(nNumCredito);
            dtDatSolicitud = Solicitud.ConsultaSolicitud(Convert.ToInt32(dtDatCre.Rows[0]["idSolicitud"]));

            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);

            //Datos del plan de pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            objplanpago = null;
            objplanpago = PlanPago.retonarPlanPago(nNumCredito);

            idMoneda = Convert.ToInt32(dtCredito.Rows[0]["idMoneda"]);
            idProducto = Convert.ToInt32(dtDatSolicitud.Rows[0]["nSubPro"]);
        }

        private void CargarCredito()
        {
            //datos del maestro creditos
            cboMoneda.SelectedValue = Convert.ToInt32(dtCredito.Rows[0]["idMoneda"]); 
            //lblTextMoneda.Text = (Convert.ToInt16(dtCredito.Rows[0]["idMoneda"])) == 1 ? "S/." : "$";
            conSolesDolar.iMagenMoneda(Convert.ToInt16(dtCredito.Rows[0]["idMoneda"]));
            //lblTextMoneda.Visible = true;

            cboTipoCredito.CargarProducto(1);
            cboSubTipoCredito.CargarProducto(Convert.ToInt32(dtDatSolicitud.Rows[0]["nTipCre"]));
            cboProducto.CargarProducto(Convert.ToInt32(dtDatSolicitud.Rows[0]["nSubTip"]));
            cboSubProducto.CargarProducto(Convert.ToInt32(dtDatSolicitud.Rows[0]["nProdu"]));

            cboTipoCredito.SelectedValue = Convert.ToInt32(dtDatSolicitud.Rows[0]["nTipCre"]);
            cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtDatSolicitud.Rows[0]["nSubTip"]);
            cboProducto.SelectedValue = Convert.ToInt32(dtDatSolicitud.Rows[0]["nProdu"]);
            cboSubProducto.SelectedValue = Convert.ToInt32(dtDatSolicitud.Rows[0]["nSubPro"]);  

            cboDestinoCredito.SelectedValue = Convert.ToInt32(dtDatSolicitud.Rows[0]["idDestino"]);

            if (dtPlanPago.Rows.Count > 0)
            {
                txtAntCapital.Text = objplanpago.Where(p => p.idEstadocuota == 1).Sum(x => x.nCapital - x.nCapitalPagado).ToString("#,0.00");
                txtAntInteres.Text = objplanpago.Where(p => p.idEstadocuota == 1).Sum(x => x.nInteresFecha - x.nInteresPagado).ToString("#,0.00");
                txtAntIntComp.Text = objplanpago.Where(p => p.idEstadocuota == 1).Sum(x => x.nIntComp - x.nInteresCompPago).ToString("#,0.00");
                txtAntMora.Text = objplanpago.Where(p => p.idEstadocuota == 1).Sum(x => x.nMora - x.nMoraPagada).ToString("#,0.00");
                txtAntGastos.Text = objplanpago.Where(p => p.idEstadocuota == 1).Sum(x => x.nOtros - x.nOtrosPagado).ToString("#,0.00");

                txtAntTotal.Text = (txtAntCapital.nvalor + txtAntInteres.nvalor + txtAntIntComp.nvalor + txtAntMora.nvalor + txtAntGastos.nvalor).ToString("#,0.00");
            }
            else
            {
                LimpiarAntesPago();
            }
        }

        private void asignarAmortizacion(clsSolicitudAmortiza soliAmortiza, int nNumCredito)
        {
            rbtnMontos.Checked = true;
            txtDisCapital.Text = String.Format("{0:#,0.00}", soliAmortiza.listaDetalle.Where(x => x.idEstado == 1 && x.idCuenta == nNumCredito).ToList()[0].nCapital);
            txtDisInteres.Text = String.Format("{0:#,0.00}", soliAmortiza.listaDetalle.Where(x => x.idEstado == 1 && x.idCuenta == nNumCredito).ToList()[0].nInteres);
            txtDisIntComp.Text = String.Format("{0:#,0.00}", soliAmortiza.listaDetalle.Where(x => x.idEstado == 1 && x.idCuenta == nNumCredito).ToList()[0].nIntComp);
            txtDisMora.Text = String.Format("{0:#,0.00}", soliAmortiza.listaDetalle.Where(x => x.idEstado == 1 && x.idCuenta == nNumCredito).ToList()[0].nMora);
            txtDisGastos.Text = String.Format("{0:#,0.00}", soliAmortiza.listaDetalle.Where(x => x.idEstado == 1 && x.idCuenta == nNumCredito).ToList()[0].nGastos);

            txtDisCapital.Enabled = false;
            txtDisInteres.Enabled = false;
            txtDisIntComp.Enabled = false;
            txtDisMora.Enabled = false;
            txtDisGastos.Enabled = false;

            grbFormaPago.Enabled = false;
            dtgConcepto.Enabled = false;
        }

        private void cargarconcepto()
        {
            lista.Clear();
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "CAPITAL", nOrden = 5 });
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INTERES", nOrden = 4 });
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "INT. COMPENSATORIO", nOrden = 3 });
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "MORA", nOrden = 2 });
            lista.Add(new clsPrelacion() { idcuenta = 0, cConcepto = "GASTOS", nOrden = 1 });

            this.dtgConcepto.DataSource = null;

            this.dtgConcepto.DataSource = lista;
        }

        private void formatogridconcepto()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConcepto.ReadOnly = false;
            this.dtgConcepto.Columns["idCuenta"].Visible = false;
            this.dtgConcepto.Columns["cConcepto"].HeaderText = "Concepto";
            this.dtgConcepto.Columns["nOrden"].HeaderText = "Orden";
            this.dtgConcepto.Columns["cConcepto"].Width = 130;
            this.dtgConcepto.Columns["cConcepto"].ReadOnly = true;
            this.dtgConcepto.Columns["nOrden"].CellTemplate.Style = style;
            dtgConcepto.Refresh();
        }

        private void LiberarCuenta()
        {
            this.conBusCuentaCli.txtNroBusqueda.Text = String.Empty;
            this.conBusCuentaCli.txtNombreCli.Text = String.Empty;
            this.conBusCuentaCli.txtEstado.Text = String.Empty;
            this.conBusCuentaCli.txtCodAge.Text = String.Empty;
            this.conBusCuentaCli.txtCodCli.Text = String.Empty;
            this.conBusCuentaCli.txtCodIns.Text = String.Empty;
            this.conBusCuentaCli.txtCodMod.Text = String.Empty;
            this.conBusCuentaCli.txtCodMon.Text = String.Empty;
            this.conBusCuentaCli.txtNroDoc.Text = String.Empty;

            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        private decimal sumaporcentaje()
        {
            return txtPorCapital.nDecValor + txtPorGastos.nDecValor + txtPorIntComp.nDecValor + txtPorInteres.nDecValor + txtPorMora.nDecValor;
        }

        private decimal sumardespuespago()
        {
            return txtDesCapital.nDecValor + txtDesGastos.nDecValor + txtDesIntComp.nDecValor + txtDesInteres.nDecValor + txtDesMora.nDecValor;
        }

        private decimal sumardistribucion()
        {
            return txtDisCapital.nDecValor + txtDisGastos.nDecValor + txtDisIntComp.nDecValor + txtDisInteres.nDecValor + txtDisMora.nDecValor;
        }

        private DataTable convertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            string name; Type type;

            foreach (PropertyDescriptor prop in properties)
            {
                name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                name = (name == "idEstadocuota" ? "idEstadoCuota" : name);
                type = (prop.Name == "dFechaPago" ? typeof(DateTime) : Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                table.Columns.Add(name, type);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                    row[name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        #endregion

    }
}
