using CAJ.CapaNegocio;
using CLI.Servicio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace CAJ.Presentacion
{
    public partial class frmRegCpgCajGen : frmBase
    {
        #region Variables

        public static int contador = 0;
		private int nidComprobantePago = 0;
		clsCNCajaChica objCajaChica = new clsCNCajaChica();
		clsCNComprobantes objCmp = new clsCNComprobantes();
		DataTable dtBienServDetra, dtComprPago, dtDetComprPago, dtDescComprPago;
		DataTable dtConfigTipCompr;
		bool lBloquearCalcular = false, lIsCierre = false;
		Transaccion eoperacion = Transaccion.Selecciona;
		int idDestino = 0,pEstadoCpg=0;
        private int idSinProyecto;
        private string cSinProyecto = "";
        private bool lCorregir = false; 
        private decimal nMontoInicial = 0;

        clsCNCargaMasivaComprobantes objCNCargaMasiva = new clsCNCargaMasivaComprobantes();
        private DataSet dsDatosConf = new DataSet();
        private DataTable dtCabeceras = new DataTable();
        private string InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private Thread excelThread;
        private enum eTipoPlantilla
        {
            Resumido = 1,
            Completo = 2
        }

        #endregion

        public frmRegCpgCajGen()
		{
			InitializeComponent();
			CargarTipoOperacion();
			CargarCboDestinos();
        }

		private void frmRegCpgCajGen_Load(object sender, EventArgs e)
		{
			//=======================================================================
			//--Llenar datagridview detalle de comprobante y darle formato
			//=======================================================================
			LimpiarCampos();
			dtComprPago = new DataTable();
			dtDetComprPago = new DataTable();
			dtDescComprPago = new DataTable();
			CrearDataTables();
			dtgDetalleComprobante.DataSource = dtDetComprPago;
			FormatoGridDetalle();
			EnableDisableControls(1);
			dtgOtrosDesctosCpg.DataSource = null;
			CargarOtrosDescuentos();
			btnNuevo.Enabled = true;
			btnEditar.Enabled = false;
			btnImprimir1.Enabled = false;
			btnGrabar.Enabled = false;
			btnCancelar.Enabled = false;
			btnBusqueda.Enabled = true;
			btnAgregarDetalle.Enabled = false;
			btnImportarPlantillaExcel.Enabled = false;
            btnQuitarDetalle.Enabled = false;
			txtCodigo.Enabled = true;
			dFecRegistro.Value = clsVarGlobal.dFecSystem;
			dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
			dtpFecVenc.Value = clsVarGlobal.dFecSystem;
			dtpFecDetraccion.Value = clsVarGlobal.dFecSystem;
			dtpFechaProvision.Value = clsVarGlobal.dFecSystem;

      cboTipoPago1.SelectedValue = -1;

			//Control de objetos
			activarControlObjetos(this, EventoFormulario.INICIO);
            obtenerDatosSinProyecto();

            btnCorregir.Visible = false;
		}

        private void obtenerDatosSinProyecto()
        {
            DataTable dSinProyecto = objCmp.CNObtenerDatoSinProyecto();

            if (dSinProyecto.Rows.Count > 0)
            { 

                idSinProyecto = Convert.ToInt32(dSinProyecto.Rows[0]["idProyecto"]);
                cSinProyecto = dSinProyecto.Rows[0]["cProyecto"].ToString();
            }
            else
                MessageBox.Show("No se encontro una configuracion de SIN PROYECTO..", "Mensaje de Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            
        }

		private void btnBusqCodRef_Click(object sender, EventArgs e)
		{
			//=======================================================================
			//--Recuperar datos de gasto sin comprobante
			//--Checked  = false ---> Gasto sin comprobante
			//--Checked  = true  ---> Gasto con comprobante
			//=======================================================================
			frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
			frmBusqCompPago.chcTieneComprobante.Checked = true;
			frmBusqCompPago.chcCajChic.Checked = false;
			frmBusqCompPago.ShowDialog();
			nidComprobantePago = frmBusqCompPago.pidComprobantePago;
			if (nidComprobantePago == 0)
			{
				MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			txtCodRef.Text = nidComprobantePago.ToString();
		}      

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			//=======================================================================
			//--Referenciar a null los DataTable y Crear Nuevos Objetos 
			//=======================================================================
			lBloquearCalcular = false;
			dtComprPago = null;
			dtDetComprPago = null;
			dtDescComprPago = null;
			dtComprPago = new DataTable("dtComprPago");
			dtDetComprPago = new DataTable("dtDetComprPago");
			dtDescComprPago = new DataTable("dtDescComprPago");
			dtgDetalleComprobante.Columns.Clear();

			DesvincularComponentes();
			LimpiarCampos();
			CrearDataTables();

			//=======================================================================
			//--Asignar Datos Por Defecto para la insercion en el Maestro 
			//=======================================================================
			DataRow dr = dtComprPago.NewRow();
			dr["idComprobantePago"] = 0;
			dr["idAgencia"] = clsVarGlobal.nIdAgencia;
			dr["nMontoITF"] = 0.00;
			dr["dFechaOpe"] = clsVarApl.dicVarGen["dFechaAct"];
			dr["dFechaEmision"] = clsVarApl.dicVarGen["dFechaAct"];
			dr["dFechaPago"] = clsVarApl.dicVarGen["dFechaAct"];
			dr["lTieneComprobante"] = 1;
			dr["nSubTotal"] = 0.00;
			dr["nTotalIGV"] = 0.00;
			dr["nTotal"] = 0.00;
			dr["nTotalDetraccion"] = 0.00;
			dr["lAfeCuartaCateg"] = false;
			dr["nPorcCuartaCateg"] = 0.00;
			dr["nTotCuartaCateg"] = 0.00;
			dr["nTotOtros"] = 0.00;	
			dr["idUsuarioRegistro"] = clsVarGlobal.User.idUsuario;
			dr["dFechaProvision"] = clsVarApl.dicVarGen["dFechaAct"];
			dr["lEstadoProvision"] = false;
			dr["lCpgCajChica"] = 0;
			dr["idEstadoComprobante"] = 1;
			dtComprPago.Rows.Add(dr);

			//=======================================================================
			//--Llenar datagridview detalle de comprobante y darle formato
			//=======================================================================
			dtgDetalleComprobante.DataSource = dtDetComprPago;
			FormatoGridDetalle();

			dtgOtrosDesctosCpg.DataSource = null;
			CargarOtrosDescuentos();

			VincularComponentes();
			EnableDisableControls(2);
            btnCorregir.Enabled = false;
			btnNuevo.Enabled = false;
			btnEditar.Enabled = false;
			btnGrabar.Enabled = true;
			btnCancelar.Enabled = true;
			btnBusqueda.Enabled = false;
			btnImprimir1.Enabled = false;
			btnAgregarDetalle.Enabled = true;
            btnImportarPlantillaExcel.Enabled = true;
            btnQuitarDetalle.Enabled = true;
			btnBusqCodRef.Enabled = false;
			btnAnular.Enabled = false;
			txtCodigo.Enabled = false;
			txtTotPag.Text = "0.00";
			txtDescuentos.Text = "0.00";
			txtNetoPagar.Text = "0.00";
			chcAnular.Enabled = false;
			cboMoneda.SelectedValue = 1;
			chcCuartaCateg.Visible = false;
			chcProvisionar.Checked = true;
			cboTipoComprobantePago.Focus();

			chcCuartaCateg.Enabled = true;

			eoperacion = Transaccion.Nuevo;
			grbDetraccion.Enabled = true;
			rbtnConDetraccion.Checked = false;
			rbtnSinDetraccion.Checked = true;
			lIsCierre = false;
			pEstadoCpg = 0;

            conBusCliente.Enabled = true;
            this.conBusCliente.btnBusCliente.Enabled = true;
            this.conBusCliente.txtCodCli.Enabled = true;
		}

		private void btnGrabar_Click(object sender, EventArgs e)
		{
            if (lCorregir)
            {
                if (nMontoInicial != Convert.ToDecimal(txtNetoPagar.Text))
                {
                    MessageBox.Show("El Importe Neto a Pagar no puede ser diferente al monto original de: "+nMontoInicial, "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

			if (!Validar()) return;

			if (dtComprPago.Rows.Count>0)
			{
				if (rbtnConDetraccion.Checked)
				{
					dtComprPago.Rows[0]["dFecDetraccion"] = dtpFecDetraccion.Value.Date;  
				}
				else
				{
					dtComprPago.Rows[0]["dFecDetraccion"] = Convert.ToDateTime("01/01/1900");
					dtComprPago.Rows[0]["idBienServicioDetr"] = 0;
				}

				dtComprPago.Rows[0]["dFechaOpe"] = dFecRegistro.Value.Date;
			}

      dtComprPago.Rows[0]["idTipoPago"] = cboTipoPago1.SelectedValue;

			//=======================================================================
			//--Crear los DataSet y agregar los Datatables para los xml
			//=======================================================================
			DataSet dsComprPago = new DataSet("dsComprPago");
			DataSet dsDetComprPago = new DataSet("dsDetComprPago");
			DataSet dsDescComprPago = new DataSet("dsDescComprPago");

			dtDescComprPago = CrearTablaOtrosDescuentos(dtDescComprPago.Copy());

			dtComprPago.TableName = "dtComprPago";
			dtDetComprPago.TableName = "dtDetComprPago";
			dtDescComprPago.TableName = "dtDescComprPago";

			dsComprPago.Tables.Add(dtComprPago);
			dsDetComprPago.Tables.Add(dtDetComprPago);
			dsDescComprPago.Tables.Add(dtDescComprPago);            

			string xmlComprPago = clsCNFormatoXML.EncodingXML(dsComprPago.GetXml());
			string xmlDetComprPago = clsCNFormatoXML.EncodingXML(dsDetComprPago.GetXml());
			string xmlDescComprPago = clsCNFormatoXML.EncodingXML(dsDescComprPago.GetXml());

			dsComprPago.Tables.Clear();
			dsDetComprPago.Tables.Clear();
			dsDescComprPago.Tables.Clear();

			int idCpgRef = !(string.IsNullOrEmpty(txtCodRef.Text)) ? Convert.ToInt32(txtCodRef.Text) : 0;

			DataTable result = objCajaChica.GuardarCpgCajGen(xmlComprPago, xmlDetComprPago, xmlDescComprPago, idCpgRef, lCorregir);

			if (result.Rows[0]["idMsje"].ToString() == "0")
			{
				MessageBox.Show(result.Rows[0]["cMsje"].ToString() + "NRO DE REGISTRO: " + result.Rows[0]["nNroRegistro"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//BuscarComprobante(Convert.ToInt32(result.Rows[0]["nNroRegistro"].ToString()));
				txtCodigo.Text = result.Rows[0]["nNroRegistro"].ToString();
				EnableDisableControls(1);
                btnCorregir.Enabled = true;
				btnNuevo.Enabled = true;
				btnEditar.Enabled = true;
				btnGrabar.Enabled = false;
				btnCancelar.Enabled = true;
				btnBusqueda.Enabled = false;
				btnAgregarDetalle.Enabled = false;
                btnImportarPlantillaExcel.Enabled = false;
                btnQuitarDetalle.Enabled = false;
				btnAnular.Enabled = false;
				btnBusqCodRef.Enabled = false;
				txtCodigo.Enabled = false;
				chcAnular.Enabled = false;
				BuscarComprobante(Convert.ToInt32(result.Rows[0]["nNroRegistro"].ToString()));
				//DataTable dtAtoCnt = objCmp.CNGeneraAsientoCmp(clsVarGlobal.dFecSystem, Convert.ToInt32(txtCodigo.Text));
				//if (Convert.ToInt32(dtAtoCnt.Rows[0]["nResultado"]) == 1)
				//{
				//    btnImprimir1.Enabled = true;
				//}
				//else
				//{
				//    MessageBox.Show(dtAtoCnt.Rows[0]["cMensaje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				//}

			}
			else
			{
				MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			lBloquearCalcular = false;
			lIsCierre = false;
		}        

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			DesvincularComponentes();
			LimpiarCampos();
			dtgOtrosDesctosCpg.DataSource = null;
			CargarOtrosDescuentos();
			EnableDisableControls(1);
            btnCorregir.Enabled = false;
			btnNuevo.Enabled = true;
			btnEditar.Enabled = false;
			btnGrabar.Enabled = false;
			btnCancelar.Enabled = false;
			btnBusqueda.Enabled = true;
			btnAgregarDetalle.Enabled = false;
            btnImportarPlantillaExcel.Enabled = false;
            btnQuitarDetalle.Enabled = false;
			btnBusqCodRef.Enabled = false;
			txtCodigo.Enabled = true;
			btnAnular.Enabled = false;
			chcAnular.Enabled = false;
			txtCodigo.Focus();
			lBloquearCalcular = false;

			chcCuartaCateg.Visible = false;         
			chcImpRenta.Visible = false;           
			lblFecVenc.Visible = false;
			dtpFecVenc.Visible = false;
			btnImprimir1.Enabled = false;
			eoperacion = Transaccion.Selecciona;
			lIsCierre = false;
			pEstadoCpg = 0;
			dtpFechaProvision.Value = clsVarGlobal.dFecSystem;
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			EnableDisableControls(2);
            btnCorregir.Enabled = false;
			//chcAnular_CheckedChanged(sender, e);
			//chcReparar_CheckedChanged(sender, e);
			//chcProvisionar_CheckedChanged(sender, e);
			txtCodigo.Enabled = false;
			chcCuartaCateg.Enabled = false;
			btnNuevo.Enabled = false;
			btnEditar.Enabled = false;
			btnGrabar.Enabled = true;
			btnImprimir1.Enabled = false;
			btnCancelar.Enabled = true;
			btnBusqueda.Enabled = false;
			btnAgregarDetalle.Enabled = false;
            btnImportarPlantillaExcel.Enabled = false;
            btnQuitarDetalle.Enabled = false;
			btnBusqCodRef.Enabled = true;
			btnQuitarDetalle.Enabled = false;
				   
			dtgOtrosDesctosCpg.Enabled = false;
			eoperacion = Transaccion.Edita;

			if (dtComprPago.Rows.Count > 0)
			{
				if (Convert.ToInt32(dtComprPago.Rows[0]["idDestino"]).In(1, 2))
				{
					cboDestino.Enabled = true;
				}
				else
				{
					cboDestino.Enabled = false;
				}
			}

			switch (pEstadoCpg)
			{
				case 1: //--Registrado
					dtgDetalleComprobante.Enabled = true;
					dtgDetalleComprobante.ReadOnly = false;
					dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = false;
					dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = false;

					dFecRegistro.Enabled = true;
					btnAgregarDetalle.Enabled = true;
                    btnImportarPlantillaExcel.Enabled = true;
                    btnQuitarDetalle.Enabled = true;
					rbtnConDetraccion.Enabled = true;
					rbtnSinDetraccion.Enabled = true;
					dtpFechaEmision.Enabled = true;
					grbDetraccion.Enabled = true;
					rbtnSinDetraccion.Enabled = true;
					rbtnConDetraccion.Enabled = true;
					cboTipoOperacion.Enabled = true;
					cboBienServicio.Enabled = true;

                    if (Convert.ToInt32(cboTipoComprobantePago.SelectedValue) == 2) //comprobante Factura 
                        if (cboDestino.SelectedIndex == 1) //Sin IGV
                        {
                            cboIGV.Enabled = false;
                            cboIGV.SelectedIndex = -1;
                        }
                        else
                            cboIGV.Enabled = true;
                        
					lBloquearCalcular = false;
                    chcCuartaCateg.Enabled = true;
                    conBusCliente.Enabled = true;
                    this.conBusCliente.btnBusCliente.Enabled = true;
                    this.conBusCliente.txtCodCli.Enabled = true;
					break;
				case 2:  //--Pagado
					dtgDetalleComprobante.Enabled = true;
                    dtgDetalleComprobante.Columns["cProyecto"].ReadOnly = true;
					dtgDetalleComprobante.Columns["cConceptoComprPago"].ReadOnly = true;
					dtgDetalleComprobante.Columns["cCentroCosto"].ReadOnly = true;
					dtgDetalleComprobante.Columns["cEstablecimiento"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = true;
					dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = true;

					cboTipoComprobantePago.Enabled = false;
					dFecRegistro.Enabled = false;
					rbtnConDetraccion.Enabled = false;
					rbtnSinDetraccion.Enabled = false;
					dtpFechaEmision.Enabled = false;
					cboMoneda.Enabled = false;
					cboTipoOperacion.Enabled = false;
					cboBienServicio.Enabled = false;
					txtCIIU.Enabled = false;
					txtPorcDetraccion.Enabled = false;
					txtCodigo.Enabled = false;
					cboDestino.Enabled = false;
                    cboIGV.Enabled = false;
					dtgOtrosDesctosCpg.Enabled = false;
					dtpFechaEmision.Enabled = true;
					btnAnular.Enabled = false;
					conBusCliente.btnBusCliente.Enabled = false;
					conBusCliente.txtCodCli.Enabled = false;
					txtSerie.Enabled = true;
					txtNumero.Enabled = true;
					txtSerie.Focus();
					lBloquearCalcular = true;
					break;
				default:
					EnableDisableControls(1);
					break;
			}
		}

		private void btnAgregarDetalle_Click(object sender, EventArgs e)
		{
			if (ValidarExistenDetalle("") == 0) return;
			if (dtgDetalleComprobante.Rows.Count > 0)
			{
				foreach (DataRow nrow in dtDetComprPago.Rows)
				{
					if (nrow["nMontoImporte"].ToString().Equals("") || nrow["cConceptoComprPago"].ToString().Equals("") || nrow["cCentroCosto"].ToString().Equals(""))
					{
						return;
					}
				}
			}

            if (dtgDetalleComprobante.Rows.Count > 0)
            {
                foreach (DataRow nrow in dtDetComprPago.Rows)
                {
                    if (Convert.ToInt32(nrow["idEstablecimiento"]) == 0 )
                    {
                        MessageBox.Show("Seleccione la Agencia/EOB", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

			if (Convert.ToInt32(cboTipoComprobantePago.SelectedIndex) == -1)
			{
				MessageBox.Show("Seleccione el tipo de comprobante", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}


			if (!rbtnConDetraccion.Checked && !rbtnSinDetraccion.Checked)
			{
				MessageBox.Show("Indique si el recibo es con detraccion o sin detraccion", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (rbtnConDetraccion.Checked)
			{
				if (string.IsNullOrEmpty(txtPorcDetraccion.Text.Trim()))
				{
					MessageBox.Show("Seleccione un el tipo de operacion y el bien y servicio para el calculo de detraccion.", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			//=======================================================================
			//--Asignar Datos Por Defecto para la insercion en el Detalle
			//=======================================================================
			int idCpg = 0;
			if (string.IsNullOrEmpty(txtCodigo.Text))
			{
				idCpg = 0;
			}
			if (Convert.ToInt32(txtCodigo.Text)>0)
			{
				idCpg = Convert.ToInt32(txtCodigo.Text);
			}

			DataRow dr = dtDetComprPago.NewRow();
			dr["idDetalleComprobante"] = -1;
			dr["idComprobantePago"] = idCpg;
			dr["nSubtotalImporte"] = 0.00;
			dr["nIgvImporte"] = 0.00;
			dr["nMontoDetraccion"] = 0.00;
			dr["nMontoImporte"] = 0.00;
			dr["lVigente"] = 1;
			dr["nCuartaCategImporte"] = 0.00;
			dr["nMontoPagar"] = 0.00;
			dr["nOtrosImporte"] = 0.00;
			dr["idAgencia"] = clsVarGlobal.nIdAgencia;
            dr["idProyecto"] = idSinProyecto;
            dr["cProyecto"] = cSinProyecto;
			dr["cConceptoComprPago"] = "";
			dr["idConceptoComprobante"] = 0;
			dr["lVigente"] = 1;
			dr["idCentroCosto"] = 0;
			dr["cCentroCosto"] = "";
            dr["idEstablecimiento"] = clsVarGlobal.User.idEstablecimiento;
            dr["cEstablecimiento"] = clsVarGlobal.User.cEstablecimiento;

			dtDetComprPago.Rows.Add(dr);
		}   

		private void btnQuitarDetalle_Click(object sender, EventArgs e)
		{
			if (this.dtgDetalleComprobante.SelectedCells.Count == 0)
			{
				MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleComprobante.SelectedCells[0].RowIndex);
				if (Convert.ToInt32(dtgDetalleComprobante.Rows[nFilaActual].Cells["idDetalleComprobante"].Value) == -1)
				{
					dtgDetalleComprobante.Rows.RemoveAt(nFilaActual);
				}
				else
				{
					dtgDetalleComprobante.Rows[nFilaActual].Cells["lVigente"].Value = 0;
				}
				this.dtgDetalleComprobante.Focus();
				ProcessTabKey(true);
				CalcularTotal(true);
			}
		}

		private void rbtnSinDetraccion_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnSinDetraccion.Checked)
			{
				cboTipoOperacion.Enabled = false;
				cboBienServicio.Enabled = false;
				cboTipoOperacion.SelectedIndex = -1;
				cboBienServicio.DataSource = null;
				//cboBienServicio.SelectedIndex = -1;
				txtPorcDetraccion.Text = "";
				txtCIIU.Clear();
				CalcularTotal(true);
			}
		}

		private void rbtnConDetraccion_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnConDetraccion.Checked)
			{
				if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text) || string.IsNullOrEmpty(conBusCliente.txtNombre.Text))
				{
					MessageBox.Show("Seleccione un proveedor.", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					rbtnConDetraccion.Checked = false;
					return;
				}
				cboTipoOperacion.Enabled = true;
				cboBienServicio.Enabled = true;
				txtCIIU.Enabled = true;
				txtPorcDetraccion.Enabled = true;

				DataTable dtCIIU = objCajaChica.BusCIIUCliente(Convert.ToInt32(conBusCliente.txtCodCli.Text));
				if (dtCIIU.Rows.Count <= 0) return;
				int nCIIU = Convert.ToInt32(dtCIIU.Rows[0]["nIdActivEco"]);
				txtCIIU.Text = nCIIU.ToString();

			}
		}

		private void cboTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTipoOperacion.SelectedValue != null)
			{
				CargarBienServicio(Convert.ToInt32(cboTipoOperacion.SelectedValue.ToString()));
			}
		}

        private void configurarControlesPorTipoComprobante(object sender, EventArgs e)
        {
            int idTipoCompr = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
            dtConfigTipCompr = objCajaChica.RetConfigTipoComp(idTipoCompr);
            if (dtConfigTipCompr.Rows.Count > 0)
            {
                dtgOtrosDesctosCpg.DataSource = null;
                CargarOtrosDescuentos();

                if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lPermiteDocRef"]))
                {
                    lblCodRef.Visible = true;
                    txtCodRef.Visible = true;
                    btnBusqCodRef.Visible = true;
                    btnBusqCodRef.Enabled = true;
                }
                else
                {
                    lblCodRef.Visible = false;
                    txtCodRef.Visible = false;
                    btnBusqCodRef.Visible = false;
                    btnBusqCodRef.Enabled = false;
                }
                if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lisGravado"]))
                {
                    cboDestino.SelectedValue = 2;
                    cboDestino.Enabled = true;

                    if (Convert.ToInt32(dtConfigTipCompr.Rows[0]["idTipComPag"]) == 2) //Factura
                        cboIGV.Enabled = true;
                    else
                        cboIGV.Enabled = false;

                    cboIGV.SelectedValue = Convert.ToInt32(dtConfigTipCompr.Rows[0]["idIGV"]);
                }
                else
                {
                    cboDestino.SelectedValue = 3;
                    //cboDestino.Enabled = false;

                    cboIGV.Enabled = false;
                    cboIGV.SelectedIndex = -1;
                }

                if (Convert.ToInt32(dtConfigTipCompr.Rows[0]["nnumero"]) == 14)
                {
                    lblFecVenc.Visible = true;
                    dtpFecVenc.Visible = true;
                    if (eoperacion == Transaccion.Nuevo)
                    {
                        dtComprPago.Rows[0]["dFechaVencimiento"] = clsVarGlobal.dFecSystem;
                    }
                }
                else
                {
                    lblFecVenc.Visible = false;
                    dtpFecVenc.Visible = false;
                    dtComprPago.Rows[0]["dFechaVencimiento"] = DBNull.Value;
                }
            }

            
            if (Convert.ToInt32(cboTipoComprobantePago.SelectedValue) == 2)//factura
            {
                if (lCorregir)
                {
                    rbtnSinDetraccion.Checked = false;
                    rbtnConDetraccion.Checked = false;
                }
                rbtnSinDetraccion.Enabled = true;
                rbtnConDetraccion.Enabled = true;
            }
            else
            {
                //detracciones
                if (lCorregir)
                {
                    rbtnSinDetraccion.Checked = true;
                    rbtnConDetraccion.Checked = false;
                }
                rbtnConDetraccion.Enabled = false;
                rbtnSinDetraccion_CheckedChanged(sender, e);
            }
        }

		private void cboTipoComprobantePago_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTipoComprobantePago.SelectedIndex == -1) return;

            configurarControlesPorTipoComprobante(sender, e);

            FormatoGridDetalle();
            CalcularTotal(true);
            cboDestino.Enabled = true;
		}

		private void cboBienServicio_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboBienServicio.Items.Count > 0 && cboBienServicio.DataSource != null)
			{
				int index = cboBienServicio.SelectedIndex;
				if (index == -1) 
				{
					txtPorcDetraccion.Text = "";
					return;
				}
				txtPorcDetraccion.Text = dtBienServDetra.Rows[index]["nPorcentaje"].ToString();
			}
		}

		private void txtPorcDetraccion_TextChanged(object sender, EventArgs e)
		{
			CalcularTotal(true);
		}

		private void chcAnular_CheckedChanged(object sender, EventArgs e)
		{
			if (dtComprPago.Rows[0]["cMotAnul"] == DBNull.Value || string.IsNullOrEmpty(dtComprPago.Rows[0]["cMotAnul"].ToString()))
			{
				txtMotAnulacion.Text = "";
			}

			if (chcAnular.Checked)
			{               
				txtMotAnulacion.Enabled = true;
				btnAnular.Enabled = true;
				btnGrabar.Enabled = false;
				btnEditar.Enabled = false;
			}
			else
			{
				txtMotAnulacion.Enabled = false;
				btnAnular.Enabled = false;
				btnGrabar.Enabled = false;
				btnEditar.Enabled = true;
			}
		}

		private void chcReparar_CheckedChanged(object sender, EventArgs e)
		{
			if (dtComprPago.Rows[0]["IdMotReparoCpg"] == DBNull.Value || string.IsNullOrEmpty(dtComprPago.Rows[0]["IdMotReparoCpg"].ToString()))
			{
				cboMotReparoCpg.SelectedIndex = -1;
			}           
			if (chcReparar.Checked)
			{
				cboMotReparoCpg.Enabled = true;
			}
			else
			{
				cboMotReparoCpg.Enabled = false;
			}
		}

		private void btnBusqueda_Click(object sender, EventArgs e)
		{
			//=======================================================================
			//--Recuperar datos de gasto sin comprobante
			//--Checked  = false ---> Gasto sin comprobante
			//--Checked  = true  ---> Gasto con comprobante
			//=======================================================================
			frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
			frmBusqCompPago.chcTieneComprobante.Checked = true;
			frmBusqCompPago.chcCajChic.Checked = false;
			frmBusqCompPago.ShowDialog();
			nidComprobantePago = frmBusqCompPago.pidComprobantePago;
			if (nidComprobantePago == 0)
			{
				MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			BuscarComprobante(nidComprobantePago);          
		}

		private void txtSerie_Leave(object sender, EventArgs e)
		{
			txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
		}

		private void txtNumero_Leave(object sender, EventArgs e)
		{
			//txtNumero.Text = txtNumero.Text.PadLeft(11, '0');
		}

		private void dtgOtrosDesctosCpg_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "nMonto")
			{
				DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["lVigente"];

				bool isChecked = (bool)checkbox.EditedFormattedValue;
				if (!isChecked)
				{
					dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].ReadOnly = true;
					MessageBox.Show("Seleccione el check de este descuento.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "lVigente")
			{
				DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["lVigente"];

				bool isChecked = (bool)checkbox.EditedFormattedValue;
				if (!isChecked)
				{
					dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].ReadOnly = false;
					dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].Value = 0.00;
				}
			}
		}

		private void dtgDetalleComprobante_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            if (lCorregir) return;
			if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 0)
			{
				frmBuscarConceptoComprPago frmBscConcepto = new frmBuscarConceptoComprPago();
				frmBscConcepto.ShowDialog();
				if (frmBscConcepto.pidSubConcepto == 0) return;                
				dtgDetalleComprobante.CurrentRow.Cells["idConceptoComprobante"].Value = frmBscConcepto.pidSubConcepto;
				dtgDetalleComprobante.CurrentRow.Cells["cConceptoComprPago"].Value = frmBscConcepto.pcSubConcpeto;
			}
			if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 2)
			{
				frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto();
				frmBuscaCtrCosto.ShowDialog();
				if (frmBuscaCtrCosto.pnidCentroCosto == 0) return;
				dtgDetalleComprobante.CurrentRow.Cells["IdCentroCosto"].Value = frmBuscaCtrCosto.pnidCentroCosto;
				dtgDetalleComprobante.CurrentRow.Cells["cCentroCosto"].Value = frmBuscaCtrCosto.pcNombreCentroCosto;
			}
			if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 4)
			{
				frmBuscaEstablecimiento frmBuscaEstab = new frmBuscaEstablecimiento();
				frmBuscaEstab.ShowDialog();
				if (frmBuscaEstab.pnidEstablecimiento == 0) return;
				dtgDetalleComprobante.CurrentRow.Cells["idEstablecimiento"].Value = frmBuscaEstab.pnidEstablecimiento;
				dtgDetalleComprobante.CurrentRow.Cells["cEstablecimiento"].Value = frmBuscaEstab.pcNombreEstablecimiento;
			}
            if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 6)
            {
                frmBuscaProyecto frmBscProyecto = new frmBuscaProyecto();
                frmBscProyecto.ShowDialog();
                //if (frmBscProyecto.pidSubConcepto == 0) return;
                if (frmBscProyecto.pidSubConcepto == 0)
                    return;

                dtgDetalleComprobante.CurrentRow.Cells["idProyecto"].Value = frmBscProyecto.pidSubConcepto;
                dtgDetalleComprobante.CurrentRow.Cells["cProyecto"].Value = frmBscProyecto.pcSubConcpeto;
            }
		}

		private void dtgDetalleComprobante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1) return;
			if (dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nSubtotalImporte" ||
				dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nOtrosImporte")
			{
				CalcularTotal(true);
			}
			if (dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nIgvImporte") //Para Editar IGV
			{
				CalcularTotal(false);
			}
		}

		private void chcProvisionar_CheckedChanged(object sender, EventArgs e)
		{
			if (chcProvisionar.Checked)
			{
				dtpFechaProvision.Format = DateTimePickerFormat.Short;
				dtpFechaProvision.Enabled = true;
				if (dtComprPago.Rows[0]["dFechaProvision"] == DBNull.Value)
				{              
					//DateTime dFechaActual = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
					//DateTime dUltDiaMes = new DateTime(dFechaActual.Year, dFechaActual.Month, 1).AddMonths(1).AddDays(-1);
					//dtpFechaProvision.Value = dUltDiaMes.Date;
					dtpFechaProvision.Value = clsVarGlobal.dFecSystem;
				}
				
			}
			else
			{
				dtpFechaProvision.Format = DateTimePickerFormat.Custom;
				dtpFechaProvision.CustomFormat = " ";
				dtpFechaProvision.Enabled = false;
				dtComprPago.Rows[0]["dFechaProvision"] = DBNull.Value;
			}
		}

		private void dtgOtrosDesctosCpg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1) return;
			if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "nMonto")
			{
				CalcularTotal(true);
			}
		}

		private DataTable CrearTablaOtrosDescuentos(DataTable dtDescuentos)
		{
			DataView dv = dtDescuentos.DefaultView;
			dv.RowFilter = ("lVigente = true or idComprobantePago <> -1");
			dtDescuentos = dv.ToTable();

			return dtDescuentos;
		}

		private void CrearDataTables()
		{
			dtComprPago.Columns.Add("idComprobantePago", typeof(Int32));
			dtComprPago.Columns.Add("idCliente", typeof(Int32));
			dtComprPago.Columns.Add("idTipoComprobantePago", typeof(Int32));
			dtComprPago.Columns.Add("idMoneda", typeof(Int32));
			dtComprPago.Columns.Add("idDestino", typeof(Int32));
			dtComprPago.Columns.Add("idAgencia", typeof(Int32));
			dtComprPago.Columns.Add("dFechaRegistro", typeof(DateTime));
			dtComprPago.Columns.Add("dFechaEmision", typeof(DateTime));
			dtComprPago.Columns.Add("dFechaPago", typeof(DateTime));
			dtComprPago.Columns.Add("lTieneComprobante", typeof(bool));
			dtComprPago.Columns.Add("cSerie", typeof(string));
			dtComprPago.Columns.Add("cNumero", typeof(string));
			dtComprPago.Columns.Add("idBienServicioDetr", typeof(Int32));
			dtComprPago.Columns.Add("cGlosa", typeof(string));
			dtComprPago.Columns.Add("nSubTotal", typeof(decimal));
			dtComprPago.Columns.Add("nTotalIGV", typeof(decimal));
			dtComprPago.Columns.Add("nIgvCalculo", typeof(decimal));
			dtComprPago.Columns.Add("nTotal", typeof(decimal));
			dtComprPago.Columns.Add("nTotalDetraccion", typeof(decimal));
			dtComprPago.Columns.Add("idUsuarioRegistro", typeof(Int32));
			dtComprPago.Columns.Add("dFechaProvision", typeof(DateTime));
			dtComprPago.Columns.Add("lEstadoProvision", typeof(bool));
			dtComprPago.Columns.Add("lCpgCajChica", typeof(bool));
			dtComprPago.Columns.Add("idEstadoComprobante", typeof(Int32));
			dtComprPago.Columns.Add("idTipoPago", typeof(Int32));
			dtComprPago.Columns.Add("dFechaOpe", typeof(DateTime));
			dtComprPago.Columns.Add("nMontoITF", typeof(decimal));
			dtComprPago.Columns.Add("cMotAnul", typeof(string));
			dtComprPago.Columns.Add("IdMotReparoCpg", typeof(Int32));
			dtComprPago.Columns.Add("lAfeCuartaCateg", typeof(bool));
			dtComprPago.Columns.Add("nPorcCuartaCateg", typeof(decimal));
			dtComprPago.Columns.Add("nTotCuartaCateg", typeof(decimal));
			dtComprPago.Columns.Add("nTotOtros", typeof(decimal));
			dtComprPago.Columns.Add("nTipCambio", typeof(decimal));
			dtComprPago.Columns.Add("dFechaVencimiento", typeof(DateTime));
			dtComprPago.Columns.Add("lAfecLeyImpRenta", typeof(bool));
			dtComprPago.Columns.Add("dFecDetraccion", typeof(DateTime));
            dtComprPago.Columns.Add("idIGV", typeof(Int32));

			dtDetComprPago.Columns.Add("idDetalleComprobante", typeof(Int32));
			dtDetComprPago.Columns.Add("idComprobantePago", typeof(Int32));
			dtDetComprPago.Columns.Add("idConceptoComprobante", typeof(Int32));
			dtDetComprPago.Columns.Add("cConceptoComprPago", typeof(string));
			dtDetComprPago.Columns.Add("nSubtotalImporte", typeof(decimal));
			dtDetComprPago.Columns.Add("nIgvImporte", typeof(decimal));
			dtDetComprPago.Columns.Add("nMontoDetraccion", typeof(decimal));
			dtDetComprPago.Columns.Add("nMontoImporte", typeof(decimal));
			dtDetComprPago.Columns.Add("lVigente", typeof(bool));
			dtDetComprPago.Columns.Add("nCuartaCategImporte", typeof(decimal));
			dtDetComprPago.Columns.Add("nOtrosImporte", typeof(decimal));
			dtDetComprPago.Columns.Add("nMontoPagar", typeof(decimal));
			dtDetComprPago.Columns.Add("idAgencia", typeof(Int32));

            dtDetComprPago.Columns.Add("idProyecto", typeof(Int32)); // centro de costos
            dtDetComprPago.Columns.Add("cProyecto", typeof(string));
            dtDetComprPago.Columns.Add("IdCentroCosto", typeof(Int32)); // centro de costos
			dtDetComprPago.Columns.Add("cCentroCosto", typeof(string));
			dtDetComprPago.Columns.Add("idEstablecimiento", typeof(Int32)); // centro de costos
			dtDetComprPago.Columns.Add("cEstablecimiento", typeof(string));
			dtDescComprPago.Columns.Add("idDescuentosComprPago", typeof(Int32));
			dtDescComprPago.Columns.Add("idComprobantePago", typeof(Int32));
			dtDescComprPago.Columns.Add("idTipoDescComPago", typeof(Int32));
			dtDescComprPago.Columns.Add("nMonto", typeof(decimal));
			dtDescComprPago.Columns.Add("lVigente", typeof(bool));

            //=======================================================================
            //--Agregar Colummna de tipo button
            //=======================================================================
            DataGridViewButtonColumn btnProyecto = new DataGridViewButtonColumn();
            btnProyecto.Name = "btnProyecto";
            btnProyecto.UseColumnTextForButtonValue = true;
            btnProyecto.Text = "...";
            this.dtgDetalleComprobante.Columns.Add(btnProyecto);

			//=======================================================================
			//--Agregar Colummna de tipo button
			//=======================================================================
			DataGridViewButtonColumn btnDetConcepto = new DataGridViewButtonColumn();
			btnDetConcepto.Name = "btnDetConcepto";
			btnDetConcepto.UseColumnTextForButtonValue = true;
			btnDetConcepto.Text = "...";
			this.dtgDetalleComprobante.Columns.Add(btnDetConcepto);

			clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
			DataTable dtAgencia = ListadoAgencia.ListarAgencias();
			//=======================================================================
			//--Agregar Colummna de tipo combobox
			//=======================================================================
			DataGridViewComboBoxColumn cboAgencia = new DataGridViewComboBoxColumn();
			cboAgencia.Name = "cboAgencia";
			cboAgencia.DataPropertyName = "idAgencia";
			cboAgencia.DataSource = dtAgencia;
			cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
			cboAgencia.DisplayMember = dtAgencia.Columns["cNomCorto"].ToString();
			this.dtgDetalleComprobante.Columns.Add(cboAgencia);
			//=======================================================================
			//--Agregar Colummna de tipo button para centro de costos
			//=======================================================================
			DataGridViewButtonColumn btnDetCentroCosto = new DataGridViewButtonColumn();
			btnDetCentroCosto.HeaderText = "";
			btnDetCentroCosto.Name = "btnDetCentroCosto";
			btnDetCentroCosto.FillWeight = 20;
			btnDetCentroCosto.UseColumnTextForButtonValue = true;
			btnDetCentroCosto.Text = "...";
			this.dtgDetalleComprobante.Columns.Add(btnDetCentroCosto);
/********************************************************************************************************************************/
			//=======================================================================
			//--Agregar Colummna de tipo button para centro de costos
			//=======================================================================
			DataGridViewButtonColumn btnDetAgenciaEstab = new DataGridViewButtonColumn();
			btnDetAgenciaEstab.HeaderText = "";
			btnDetAgenciaEstab.Name = "btnDetAgenciaEstab";
			btnDetAgenciaEstab.FillWeight = 20;
			btnDetAgenciaEstab.UseColumnTextForButtonValue = true;
			btnDetAgenciaEstab.Text = "...";
			this.dtgDetalleComprobante.Columns.Add(btnDetAgenciaEstab);

		
		}

		private void FormatoGridDetalle()
		{
			dtgDetalleComprobante.ReadOnly = false;
			foreach (DataGridViewColumn item in dtgDetalleComprobante.Columns)
			{
				item.ReadOnly = false;
			}

            dtgDetalleComprobante.Columns["idProyecto"].Visible = false;     // centro de costos
            dtgDetalleComprobante.Columns["cProyecto"].Visible = true;
			dtgDetalleComprobante.Columns["idDetalleComprobante"].Visible = false;
			dtgDetalleComprobante.Columns["idComprobantePago"].Visible = false;
			dtgDetalleComprobante.Columns["idConceptoComprobante"].Visible = false;
			dtgDetalleComprobante.Columns["cConceptoComprPago"].Visible = true;
			dtgDetalleComprobante.Columns["IdCentroCosto"].Visible = false;     // centro de costos
			dtgDetalleComprobante.Columns["cCentroCosto"].Visible = true;
			dtgDetalleComprobante.Columns["idEstablecimiento"].Visible = false;
			dtgDetalleComprobante.Columns["cEstablecimiento"].Visible = true;
			dtgDetalleComprobante.Columns["nSubtotalImporte"].Visible = true;
			dtgDetalleComprobante.Columns["nIgvImporte"].Visible = true;
			dtgDetalleComprobante.Columns["nMontoDetraccion"].Visible = true;
			dtgDetalleComprobante.Columns["nMontoImporte"].Visible = true;
			dtgDetalleComprobante.Columns["lVigente"].Visible = false;
			if (dtConfigTipCompr != null)
			{
				if (Convert.ToDecimal(dtConfigTipCompr.Rows[0]["nValCuartaCateg"]) > 0)
				{
					chcCuartaCateg.Visible = true;
					chcImpRenta.Visible = true;
					txtTot4taCateg.Visible = true;
					dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = true;                   
				}
				else
				{
					chcCuartaCateg.Visible = false;
					chcCuartaCateg.Checked = false;
					chcImpRenta.Visible = false;
					chcImpRenta.Checked = false;
					txtTot4taCateg.Visible = false;
					dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = false;
				}
			}
			else
			{
				chcCuartaCateg.Visible = false;
				chcCuartaCateg.Checked = false;
				chcImpRenta.Visible = false;
				chcImpRenta.Checked = false;
				txtTot4taCateg.Visible = false;
				dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = false;
			}
			dtgDetalleComprobante.Columns["nOtrosImporte"].Visible = true;
			dtgDetalleComprobante.Columns["nMontoPagar"].Visible = true;
            dtgDetalleComprobante.Columns["btnProyecto"].Visible = true;
            dtgDetalleComprobante.Columns["btnDetConcepto"].Visible = true;
			dtgDetalleComprobante.Columns["cboAgencia"].Visible = false;

			dtgDetalleComprobante.Columns["cProyecto"].HeaderText = "Proyecto";
			dtgDetalleComprobante.Columns["cConceptoComprPago"].HeaderText = "Concepto";
			dtgDetalleComprobante.Columns["cCentroCosto"].HeaderText = "Centro Costo";
			dtgDetalleComprobante.Columns["cEstablecimiento"].HeaderText = "Agencia/EOB";
			dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderText = "Subtotal";
			dtgDetalleComprobante.Columns["nIgvImporte"].HeaderText = "IGV";
			dtgDetalleComprobante.Columns["nMontoDetraccion"].HeaderText = "Detracción";
			dtgDetalleComprobante.Columns["nCuartaCategImporte"].HeaderText = "4ta Cat.";
			dtgDetalleComprobante.Columns["nMontoImporte"].HeaderText = "Total";
			dtgDetalleComprobante.Columns["nOtrosImporte"].HeaderText = "Otros";
			dtgDetalleComprobante.Columns["nMontoPagar"].HeaderText = "Mont.Pagar";
            dtgDetalleComprobante.Columns["btnProyecto"].HeaderText = "";
            dtgDetalleComprobante.Columns["btnDetConcepto"].HeaderText = "";
			dtgDetalleComprobante.Columns["cboAgencia"].HeaderText = "Agencia";

			dtgDetalleComprobante.Columns["nSubtotalImporte"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nIgvImporte"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nMontoDetraccion"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nCuartaCategImporte"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nMontoImporte"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nOtrosImporte"].DefaultCellStyle.Format = "##,##0.00";
			dtgDetalleComprobante.Columns["nMontoPagar"].DefaultCellStyle.Format = "##,##0.00";

			dtgDetalleComprobante.Columns["nSubtotalImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtgDetalleComprobante.Columns["nIgvImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtgDetalleComprobante.Columns["nMontoDetraccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtgDetalleComprobante.Columns["nMontoImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtgDetalleComprobante.Columns["nOtrosImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dtgDetalleComprobante.Columns["nMontoPagar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dtgDetalleComprobante.Columns["cProyecto"].ReadOnly = true;
			dtgDetalleComprobante.Columns["cConceptoComprPago"].ReadOnly = true;
			dtgDetalleComprobante.Columns["cCentroCosto"].ReadOnly = true;
			dtgDetalleComprobante.Columns["cEstablecimiento"].ReadOnly = true;
			dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = false;
			dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = false;
			dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = true;
			dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = true;
			dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = true;
			dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = false;
			dtDetComprPago.Columns["nMontoPagar"].ReadOnly = false;
			dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = true;
            dtgDetalleComprobante.Columns["btnProyecto"].ReadOnly = false;
            dtgDetalleComprobante.Columns["btnDetConcepto"].ReadOnly = false;
			dtDetComprPago.Columns["idAgencia"].ReadOnly = false;
			
			dtgDetalleComprobante.Columns["cboAgencia"].ReadOnly = false;

			dtgDetalleComprobante.Columns["cProyecto"].FillWeight = 120;
			dtgDetalleComprobante.Columns["cConceptoComprPago"].FillWeight = 120;
			dtgDetalleComprobante.Columns["cCentroCosto"].FillWeight = 120;
			dtgDetalleComprobante.Columns["cEstablecimiento"].FillWeight = 120;
			dtgDetalleComprobante.Columns["nSubtotalImporte"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nIgvImporte"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nMontoDetraccion"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nMontoImporte"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nOtrosImporte"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nMontoPagar"].FillWeight = 52;
			dtgDetalleComprobante.Columns["nCuartaCategImporte"].FillWeight = 52;
            
            dtgDetalleComprobante.Columns["btnDetConcepto"].FillWeight = 20;
            dtgDetalleComprobante.Columns["btnDetCentroCosto"].FillWeight = 20;
            dtgDetalleComprobante.Columns["btnDetAgenciaEstab"].FillWeight = 20;
			dtgDetalleComprobante.Columns["btnProyecto"].FillWeight = 20;


			dtgDetalleComprobante.Columns["btnDetConcepto"].DisplayIndex = 0;
			dtgDetalleComprobante.Columns["cConceptoComprPago"].DisplayIndex = 1;
			dtgDetalleComprobante.Columns["btnDetCentroCosto"].DisplayIndex = 2;
			dtgDetalleComprobante.Columns["cCentroCosto"].DisplayIndex = 3;

			dtgDetalleComprobante.Columns["btnDetAgenciaEstab"].DisplayIndex = 4;
			dtgDetalleComprobante.Columns["cEstablecimiento"].DisplayIndex = 5;

            dtgDetalleComprobante.Columns["btnProyecto"].DisplayIndex = 6;
            dtgDetalleComprobante.Columns["cProyecto"].DisplayIndex = 7;

			dtgDetalleComprobante.Columns["cboAgencia"].DisplayIndex = 15;
			dtgDetalleComprobante.Columns["nSubtotalImporte"].DisplayIndex = 8;
			dtgDetalleComprobante.Columns["nIgvImporte"].DisplayIndex = 9;
			dtgDetalleComprobante.Columns["nOtrosImporte"].DisplayIndex = 10;
			dtgDetalleComprobante.Columns["nMontoImporte"].DisplayIndex = 11;
			dtgDetalleComprobante.Columns["nMontoDetraccion"].DisplayIndex = 12;
			dtgDetalleComprobante.Columns["nCuartaCategImporte"].DisplayIndex = 13;
			dtgDetalleComprobante.Columns["nMontoPagar"].DisplayIndex = 14;

            dtgDetalleComprobante.Columns["cConceptoComprPago"].Width = 110;
            dtgDetalleComprobante.Columns["cCentroCosto"].Width = 110;
            dtgDetalleComprobante.Columns["cEstablecimiento"].Width = 110;
            dtgDetalleComprobante.Columns["cProyecto"].Width = 110;



			dtgDetalleComprobante.CellValueChanged += new DataGridViewCellEventHandler(dtgDetalleComprobante_CellValueChanged);

			foreach (DataGridViewColumn column in dtgDetalleComprobante.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}

			FormatoTextBox();
		}

		private void CargarOtrosDescuentos()
		{
			dtDescComprPago = objCajaChica.ListarOtrosDescuentoComprobantes();
			dtgOtrosDesctosCpg.DataSource = dtDescComprPago;

			FormatoGridOtrosDescuentos();
		}

		private void FormatoGridOtrosDescuentos()
		{
			dtDescComprPago.Columns["idDescuentosComprPago"].ReadOnly = false;
			dtDescComprPago.Columns["idComprobantePago"].ReadOnly = false;
			dtDescComprPago.Columns["idTipoDescComPago"].ReadOnly = false;
			dtDescComprPago.Columns["Concepto"].ReadOnly = true;
			dtDescComprPago.Columns["nMonto"].ReadOnly = false;
			dtDescComprPago.Columns["lVigente"].ReadOnly = false;
			dtDescComprPago.Columns["cAbrev"].ReadOnly = true;

			dtgOtrosDesctosCpg.ReadOnly = false;

			dtgOtrosDesctosCpg.Columns["idDescuentosComprPago"].Visible = false;
			dtgOtrosDesctosCpg.Columns["idTipoDescComPago"].Visible = false;
			dtgOtrosDesctosCpg.Columns["idComprobantePago"].Visible = false;
			dtgOtrosDesctosCpg.Columns["Concepto"].Visible = true;
			dtgOtrosDesctosCpg.Columns["nMonto"].Visible = true;
			dtgOtrosDesctosCpg.Columns["lVigente"].Visible = true;
			dtgOtrosDesctosCpg.Columns["cAbrev"].Visible = false;

			dtgOtrosDesctosCpg.Columns["lVigente"].Width = 50;
			dtgOtrosDesctosCpg.Columns["Concepto"].Width = 250;
			dtgOtrosDesctosCpg.Columns["nMonto"].Width = 80;

			dtgOtrosDesctosCpg.Columns["lVigente"].ReadOnly = false;
			dtgOtrosDesctosCpg.Columns["Concepto"].ReadOnly = true;
			dtgOtrosDesctosCpg.Columns["nMonto"].ReadOnly = false;

			dtgOtrosDesctosCpg.Columns["lVigente"].HeaderText = "";
			dtgOtrosDesctosCpg.Columns["Concepto"].HeaderText = "Concepto";
			dtgOtrosDesctosCpg.Columns["nMonto"].HeaderText = "Monto";

			dtgOtrosDesctosCpg.Columns["nMonto"].DefaultCellStyle.Format = "##,##0.00";
		}

		private void CargarTipoOperacion()
		{
			this.cboTipoOperacion.SelectedIndexChanged -= new EventHandler(cboTipoOperacion_SelectedIndexChanged);

			DataTable listaTipoOperDetra = objCajaChica.ListarTipoOperacionDetraccion();
			cboTipoOperacion.DataSource = listaTipoOperDetra;
			cboTipoOperacion.ValueMember = "idTipoOperacionDetr";
			cboTipoOperacion.DisplayMember = "cDescripcion";

			this.cboTipoOperacion.SelectedIndexChanged += new EventHandler(cboTipoOperacion_SelectedIndexChanged);
		}

		private void CargarCboDestinos()
		{
			DataTable Destinos = objCajaChica.ListarDestinoComprPago(clsVarGlobal.nIdAgencia);
			cboDestino.DataSource = Destinos;
			cboDestino.ValueMember = "idDetinoComprPago";
			cboDestino.DisplayMember = "cDescripcion";
		}

		private void CargarBienServicio(int idTipoOpera)
		{
			dtBienServDetra = objCajaChica.ListarBienServicioDetraccion(idTipoOpera);
			cboBienServicio.DataSource = dtBienServDetra;
			cboBienServicio.ValueMember = "idBienServicioDetr";
			cboBienServicio.DisplayMember = "cDescripcion";
		}

		private void LimpiarCampos()
		{
            lCorregir = false;
            btnCorregir.Visible = false;
			cboTipoComprobantePago.SelectedIndex = -1;
			txtSerie.Text = "";
			txtNumero.Text = "";
			dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
			dFecRegistro.Value = clsVarGlobal.dFecSystem;
			dtpFecDetraccion.Value= clsVarGlobal.dFecSystem;
			cboMoneda.SelectedIndex = -1;
			txtCambio.Text = "";
			txtCodigo.Text = "";
			
            cboIGV.SelectedIndex = -1;
			conBusCliente.limpiarControles();

			rbtnConDetraccion.Checked = false;
			rbtnSinDetraccion.Checked = false;
			cboTipoOperacion.SelectedIndex = -1;
			cboBienServicio.SelectedIndex = -1;
			txtCIIU.Text = "";
			txtPorcDetraccion.TextChanged -= new EventHandler(txtPorcDetraccion_TextChanged);
			txtPorcDetraccion.Text = "";
			txtPorcDetraccion.TextChanged += new EventHandler(txtPorcDetraccion_TextChanged);
			cboDestino.SelectedIndex = -1;
			txtGlosa.Text = "";
			dtgDetalleComprobante.DataSource = null;
			txtValorCompra.Text = "";
			txtIGV.Text = "";
			txtDetraccion.Text = "";
			chcCuartaCateg.Checked = false;
			txtTot4taCateg.Text = "";
			txtTotOtros.Text = "";
			txtTotal.Text = "";
			chcAnular.Checked = false;
			txtMotAnulacion.Text = "";
			chcReparar.Checked = false;
			cboMotReparoCpg.SelectedIndex = -1;
			chcProvisionar.Checked = false;
			dtpFechaProvision.Format = DateTimePickerFormat.Custom;
			dtpFechaProvision.CustomFormat = " ";
			txtTotPag.Text = "";
			txtDescuentos.Text = "";
			txtNetoPagar.Text = "";
			chcImpRenta.Checked = false;
			dtpFecVenc.Value = clsVarGlobal.dFecSystem;
		}

		private void VincularComponentes()
		{
			txtCodigo.DataBindings.Add("Text", dtComprPago, "idComprobantePago", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            cboTipoComprobantePago.DataBindings.Add("SelectedValue", dtComprPago, "idTipoComprobantePago", true, DataSourceUpdateMode.OnPropertyChanged, -1);
			cboMoneda.DataBindings.Add("SelectedValue", dtComprPago, "idMoneda", true, DataSourceUpdateMode.OnPropertyChanged, -1);
			
			conBusCliente.txtCodCli.DataBindings.Add("Text", dtComprPago, "idCliente", true, DataSourceUpdateMode.OnPropertyChanged, "");
			txtSerie.DataBindings.Add("Text", dtComprPago, "cSerie", true, DataSourceUpdateMode.OnPropertyChanged, "");
			txtNumero.DataBindings.Add("Text", dtComprPago, "cNumero", true, DataSourceUpdateMode.OnPropertyChanged, "");
			cboDestino.DataBindings.Add("SelectedValue", dtComprPago, "idDestino", true, DataSourceUpdateMode.OnPropertyChanged, "0");
            cboTipoPago1.DataBindings.Add("SelectedValue", dtComprPago, "idTipoPago", true, DataSourceUpdateMode.OnPropertyChanged, "0");
            cboBienServicio.DataBindings.Add("SelectedValue", dtComprPago, "idBienServicioDetr", true, DataSourceUpdateMode.OnPropertyChanged, -1);
			txtGlosa.DataBindings.Add("Text", dtComprPago, "cGlosa", true, DataSourceUpdateMode.OnPropertyChanged, "");
			txtValorCompra.DataBindings.Add("Text", dtComprPago, "nSubTotal", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			txtIGV.DataBindings.Add("Text", dtComprPago, "nTotalIGV", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			txtDetraccion.DataBindings.Add("Text", dtComprPago, "nTotalDetraccion", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			chcCuartaCateg.DataBindings.Add("Checked", dtComprPago, "lAfeCuartaCateg", true, DataSourceUpdateMode.OnPropertyChanged, 0);
			txtTot4taCateg.DataBindings.Add("Text", dtComprPago, "nTotCuartaCateg", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			txtTotOtros.DataBindings.Add("Text", dtComprPago, "nTotOtros", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            cboIGV.DataBindings.Add("SelectedValue", dtComprPago, "idIGV", true, DataSourceUpdateMode.OnPropertyChanged, -1);

			if (Convert.ToInt32(cboTipoComprobantePago.SelectedValue) ==3)
			{
				txtTotal.DataBindings.Add("Text", dtComprPago, "nSubTotal", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			}
			else
			{
				txtTotal.DataBindings.Add("Text", dtComprPago, "nTotal", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
			}
			
			dtpFechaEmision.DataBindings.Add("Value", dtComprPago, "dFechaEmision", true, DataSourceUpdateMode.OnPropertyChanged);
			dFecRegistro.DataBindings.Add("Value", dtComprPago, "dFechaOpe", true, DataSourceUpdateMode.OnPropertyChanged);
			dtpFechaProvision.DataBindings.Add("Text", dtComprPago, "dFechaProvision", true, DataSourceUpdateMode.OnPropertyChanged, " ");
			chcProvisionar.DataBindings.Add("Checked", dtComprPago, "lEstadoProvision", true, DataSourceUpdateMode.OnPropertyChanged);
			txtMotAnulacion.DataBindings.Add("Text", dtComprPago, "cMotAnul", true, DataSourceUpdateMode.OnPropertyChanged, "");
			cboMotReparoCpg.DataBindings.Add("SelectedValue", dtComprPago, "IdMotReparoCpg", true, DataSourceUpdateMode.OnPropertyChanged, null);
			txtCambio.DataBindings.Add("Text", dtComprPago, "nTipCambio", true, DataSourceUpdateMode.OnPropertyChanged, "0.0000", "##0.0000");

			dtpFecVenc.DataBindings.Add("Value", dtComprPago, "dFechaVencimiento", true, DataSourceUpdateMode.OnPropertyChanged);
			chcImpRenta.DataBindings.Add("Checked", dtComprPago, "lAfecLeyImpRenta", true, DataSourceUpdateMode.OnPropertyChanged);            
		}

		private void DesvincularComponentes()
		{
			txtCodigo.DataBindings.Clear();
			cboTipoComprobantePago.DataBindings.Clear();
			cboMoneda.DataBindings.Clear();
			
			conBusCliente.txtCodCli.DataBindings.Clear();
			txtSerie.DataBindings.Clear();
			txtNumero.DataBindings.Clear();
			cboDestino.DataBindings.Clear();
            cboTipoPago1.DataBindings.Clear();
            cboBienServicio.DataBindings.Clear();
			txtGlosa.DataBindings.Clear();
			txtValorCompra.DataBindings.Clear();
			txtIGV.DataBindings.Clear();
			txtDetraccion.DataBindings.Clear();
			chcCuartaCateg.DataBindings.Clear();
			txtTot4taCateg.DataBindings.Clear();
			txtTotOtros.DataBindings.Clear();
			txtTotal.DataBindings.Clear();
			dtpFechaEmision.DataBindings.Clear();
			dFecRegistro.DataBindings.Clear();
			dtpFechaProvision.DataBindings.Clear();
			chcProvisionar.DataBindings.Clear();
			txtMotAnulacion.DataBindings.Clear();
			cboMotReparoCpg.DataBindings.Clear();
			txtCambio.DataBindings.Clear();
			txtDescuentos.DataBindings.Clear();
			txtNetoPagar.DataBindings.Clear();
			dtpFecVenc.DataBindings.Clear();
			chcImpRenta.DataBindings.Clear();
            cboIGV.DataBindings.Clear();

		}

		private void EnableDisableControls(int nOpcion)
		{
			if (nOpcion == 1) // Al Cargar Formulario, seleccionar el boton Cancelar y seleccionar el boton Grabar
			{
				dtgDetalleComprobante.Enabled = false;
				dtgOtrosDesctosCpg.Enabled = false;
				cboTipoComprobantePago.Enabled = false;
				dFecRegistro.Enabled = false;
				txtSerie.Enabled = false;
				txtNumero.Enabled = false;
				dtpFechaEmision.Enabled = false;                
				cboMoneda.Enabled = false;
				txtCambio.Enabled = false;
				txtCodigo.Enabled = false;
				
                cboIGV.Enabled = false;
				conBusCliente.Enabled = false;

				rbtnConDetraccion.Enabled = false;
				rbtnSinDetraccion.Enabled = false;
				cboTipoOperacion.Enabled = false;
				cboBienServicio.Enabled = false;
				cboDestino.Enabled = false;
        cboTipoPago1.Enabled = false;
				txtGlosa.Enabled = false;
				chcAnular.Enabled = false;
				txtMotAnulacion.Enabled =false ;
				chcReparar.Enabled = false;
				cboMotReparoCpg.Enabled = false;
				chcProvisionar.Enabled = false;
				dtpFechaProvision.Enabled = false;
				dtgDetalleComprobante.ReadOnly = true;
				chcCuartaCateg.Enabled = false;
				chcImpRenta.Enabled = false;
				dtpFecVenc.Enabled = false;
				lblFecVenc.Visible = false;
				dtpFecVenc.Visible = false;
				dtpFecDetraccion.Enabled = false;
			}
			else // Al seleccionar el boton Nuevo
			{
				dtgDetalleComprobante.Enabled = true;
				dtgOtrosDesctosCpg.Enabled = true;
				cboTipoComprobantePago.Enabled = true;
				dFecRegistro.Enabled = true;
				txtSerie.Enabled = true;
				txtNumero.Enabled = true;
				dtpFechaEmision.Enabled = true;
				cboMoneda.Enabled = true;
				txtCambio.Enabled = true;
				txtCodigo.Enabled = true;
				
				conBusCliente.Enabled = true;

				rbtnConDetraccion.Enabled = true;
				rbtnSinDetraccion.Enabled = true;
				cboDestino.Enabled = true;
        cboTipoPago1.Enabled = true;
				txtGlosa.Enabled = true;
				chcAnular.Enabled = true;
				chcReparar.Enabled = true;
				chcCuartaCateg.Enabled = true;
				chcImpRenta.Enabled = true;
				dtpFecVenc.Enabled = true;
				dtpFecDetraccion.Enabled = true;
			}
		}

		private int ValidarExistenDetalle(string valor)
		{
			if (dtgDetalleComprobante.Rows.Count > 0)
			{
				foreach (DataRow nrow in dtDetComprPago.Rows)
				{
					if (nrow["idConceptoComprobante"].ToString().Equals(valor))
					{
						return 0;
					}
				}
			}
			return 1;
		}        

		private bool Validar()
		{
      if (cboTipoPago1.SelectedIndex == -1)
      {
         MessageBox.Show("Seleccione el tipo de pago.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         cboTipoPago1.Focus();
         return false;
         }
      if (cboTipoComprobantePago.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione el tipo de comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboTipoComprobantePago.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtSerie.Text))
			{
				MessageBox.Show("Ingrese la Serie del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSerie.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtSerie.Text))
			{
				MessageBox.Show("Ingrese el número de serie del comprobante", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtSerie.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtNumero.Text))
			{
				MessageBox.Show("Ingrese el número del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtNumero.Focus();
				return false;
			}
			if (cboMoneda.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione la moneda del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboMoneda.Focus();
				return false;
			}
			if (txtCodRef.Visible && string.IsNullOrEmpty(txtCodRef.Text))
			{
				MessageBox.Show("Seleccione el documento de referencia.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnBusqCodRef.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text) || string.IsNullOrEmpty(conBusCliente.txtNombre.Text))
			{
				MessageBox.Show("Seleccione un cliente para el comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				conBusCliente.txtCodCli.Focus();
				return false;
			}
			if (!rbtnSinDetraccion.Checked && !rbtnConDetraccion.Checked)
			{
				MessageBox.Show("Seleccione si el comprobante con detraccion o sin detraccion.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				rbtnSinDetraccion.Focus();
				return false;
			}
			if (rbtnConDetraccion.Checked)
			{
				if (cboTipoOperacion.SelectedIndex == -1)
				{
					MessageBox.Show("Seleccione el tipo de operacion del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					cboTipoOperacion.Focus();
					return false;
				}
				if (cboBienServicio.SelectedIndex == -1)
				{
					MessageBox.Show("Seleccione el bien o servicio del tipo de operación.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					cboBienServicio.Focus();
					return false;
				}
			}
			if (cboDestino.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione el destino del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboDestino.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtGlosa.Text))
			{
				MessageBox.Show("Complete la descripcion en el campo glosa del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtGlosa.Focus();
				return false;
			}
			if (dtgDetalleComprobante.RowCount == 0)
			{
				MessageBox.Show("Agregue al menos un detalle al comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtgDetalleComprobante.Focus();
				return false;
			}

			if (chcAnular.Checked && string.IsNullOrEmpty(txtMotAnulacion.Text))
			{
				MessageBox.Show("Ingrese el motivo de anulación del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMotAnulacion.Focus();
				return false;
			}
			if (chcReparar.Checked && cboMotReparoCpg.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione el motivo de reparo del comprobante.", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMotAnulacion.Focus();
				return false;
			}
			if (Convert.ToDecimal(txtTotPag.Text)<=0)
			{
				MessageBox.Show("Debe Ingresar el monto del detalle", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dtgDetalleComprobante.Focus();
				return false;
			}
			return true;
		}

		private void FormatoTextBox()
		{
			var SubTotRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nSubtotalImporte"].Index, true);
			var IgvRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nIgvImporte"].Index, true);
			var nMontDetracRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoDetraccion"].Index, true);
			var nMontoImportRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoImporte"].Index, true);
			var CuartaCategRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nCuartaCategImporte"].Index, true);
			var OtrosRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nOtrosImporte"].Index, true);
			var TotPagRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoPagar"].Index, true);


			int PosY = SubTotRectangle.Y + dtgDetalleComprobante.Height + dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderCell.Size.Height;

			this.txtValorCompra.Width = dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderCell.Size.Width;
			this.txtIGV.Width = dtgDetalleComprobante.Columns["nIgvImporte"].HeaderCell.Size.Width;
			this.txtDetraccion.Width = dtgDetalleComprobante.Columns["nMontoDetraccion"].HeaderCell.Size.Width;
			this.txtTot4taCateg.Width = dtgDetalleComprobante.Columns["nCuartaCategImporte"].HeaderCell.Size.Width;
			this.txtTotOtros.Width = dtgDetalleComprobante.Columns["nOtrosImporte"].HeaderCell.Size.Width;
			this.txtTotal.Width = dtgDetalleComprobante.Columns["nMontoImporte"].HeaderCell.Size.Width;
			this.txtTotPag.Width = dtgDetalleComprobante.Columns["nMontoPagar"].HeaderCell.Size.Width;
			this.txtDescuentos.Width = txtTotPag.Width;
			this.txtNetoPagar.Width = txtTotPag.Width;

			this.txtValorCompra.Location = new Point(SubTotRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtIGV.Location = new Point(IgvRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtDetraccion.Location = new Point(nMontDetracRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtTot4taCateg.Location = new Point(CuartaCategRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtTotOtros.Location = new Point(OtrosRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtTotal.Location = new Point(nMontoImportRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtTotPag.Location = new Point(TotPagRectangle.X + dtgDetalleComprobante.Location.X, PosY + 2);
			this.txtDescuentos.Location = new Point(txtTotPag.Location.X, txtDescuentos.Location.Y);
			this.txtNetoPagar.Location = new Point(txtTotPag.Location.X, txtNetoPagar.Location.Y);
		}

		private void CalcularTotal(bool lRecalcularIGV)
		{
            decimal nSubTotal = 0.00M;
            decimal nTotalIGV = 0.00M;
            decimal nTotalOtros = 0.00M;
            decimal nTotalDetraccion = 0.00M;
            decimal nTotCuartaCateg = 0.00M;
            decimal nTotal = 0.00M;
            decimal nTotPagar = 0.00M;
            decimal nTotDes = 0.00M;

            foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
            {
                if (!lBloquearCalcular)
                {
                    //nSubTotal = Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value);
                    if (Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) < 0)
                    {
                        MessageBox.Show("Valor no puede ser negativo", "Registro de comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        row.Cells["nSubtotalImporte"].Value = 0;
                        return;
                    }
                   
                    decimal nPorcIgv;
                    if (cboIGV.SelectedIndex != -1)
                    {
                        DataTable dtIGV = cboIGV.DataSource as DataTable;
                        nPorcIgv = Convert.ToDecimal(dtIGV.Rows[cboIGV.SelectedIndex]["nValorIGV"]);

                    }
                    else
                        nPorcIgv = 0.00M;

                    decimal nPorcCuartaCateg;
                    if (chcCuartaCateg.Checked)
                    {
                        nPorcCuartaCateg = Convert.ToDecimal(dtConfigTipCompr.Rows[0]["nValCuartaCateg"]);
                    }
                    else
                    {
                        nPorcCuartaCateg = Convert.ToDecimal(0.00);
                    }

                    decimal nPorcDetraccion = string.IsNullOrEmpty(txtPorcDetraccion.Text) ? 0.00M : Convert.ToDecimal(txtPorcDetraccion.Text);
                    DataTable dtDestinos = (DataTable)cboDestino.DataSource;
                    bool lAfectaIGV = false;
                    if (cboDestino.SelectedIndex != -1)
                    {
                        lAfectaIGV = Convert.ToBoolean(dtDestinos.Rows[cboDestino.SelectedIndex]["lAplIgv"]);
                    }
                    if (lAfectaIGV)
                    {
                        if (lRecalcularIGV)
                        {
                            row.Cells["nIgvImporte"].Value = Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2);
                        }
                        else
                        {
                            if (Math.Abs(Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2) - Convert.ToDecimal(row.Cells["nIgvImporte"].Value)) > 0.01M) // Si el IGV difiere en mas de 1 centimo se recalcula
                            {
                                row.Cells["nIgvImporte"].Value = Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2);
                            }
                        }
                    }
                    else
                    {
                        row.Cells["nIgvImporte"].Value = 0.00M;
                    }
                    row.Cells["nMontoImporte"].Value = Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) +
                                                       Convert.ToDecimal(row.Cells["nIgvImporte"].Value) +
                                                       Convert.ToDecimal(row.Cells["nOtrosImporte"].Value);

                    if (rbtnConDetraccion.Checked)
                    {
                        var dtDetalle = (DataTable)(dtgDetalleComprobante.DataSource);
                        decimal nTotalBaseImp = dtDetalle.AsEnumerable().Sum(x => Convert.ToDecimal(x["nSubtotalImporte"]));
                        decimal nFactor = Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) / nTotalBaseImp;
                        decimal nTotIgv = Math.Round(nTotalBaseImp * nPorcIgv / 100.00M, 2);
                        decimal nDetraccion = Math.Round(((nTotalBaseImp + nTotIgv) * nPorcDetraccion) / 100.00M, 0);
                        row.Cells["nMontoDetraccion"].Value = Math.Round(nDetraccion * nFactor, 2);
                    }
                    else
                    {
                        row.Cells["nMontoDetraccion"].Value = 0.00M;
                    }


                    row.Cells["nCuartaCategImporte"].Value = (Convert.ToDecimal(row.Cells["nMontoImporte"].Value) * nPorcCuartaCateg) / (100.00M);
                }

                row.Cells["nMontoPagar"].Value = Convert.ToDecimal(row.Cells["nMontoImporte"].Value) - Convert.ToDecimal(row.Cells["nMontoDetraccion"].Value) - Convert.ToDecimal(row.Cells["nCuartaCategImporte"].Value);

                nSubTotal += Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value);
                nTotalIGV += Convert.ToDecimal(row.Cells["nIgvImporte"].Value);
                nTotalOtros += Convert.ToDecimal(row.Cells["nOtrosImporte"].Value);
                nTotal += Convert.ToDecimal(row.Cells["nMontoImporte"].Value);
                nTotalDetraccion += Convert.ToDecimal(row.Cells["nMontoDetraccion"].Value);
                nTotCuartaCateg += Convert.ToDecimal(row.Cells["nCuartaCategImporte"].Value);
                nTotPagar += Convert.ToDecimal(row.Cells["nMontoPagar"].Value);

            }

            foreach (DataGridViewRow row1 in dtgOtrosDesctosCpg.Rows)
            {
                nTotDes += Convert.ToDecimal(row1.Cells["nMonto"].Value);
            }

            this.txtValorCompra.Text = nSubTotal.ToString("##,##0.00");
            this.txtIGV.Text = nTotalIGV.ToString("##,##0.00");

            decimal nTotDetraccion = Math.Round(((txtValorCompra.nDecValor + txtIGV.nDecValor) * txtPorcDetraccion.nDecValor) / 100.00M, 0);
            decimal nDifAjuste = nTotDetraccion - nTotalDetraccion;

            if (dtgDetalleComprobante.RowCount > 0)
            {
                dtgDetalleComprobante.Rows[dtgDetalleComprobante.RowCount - 1].Cells["nMontoDetraccion"].Value = Convert.ToDecimal(dtgDetalleComprobante.Rows[dtgDetalleComprobante.RowCount - 1].Cells["nMontoDetraccion"].Value) + nDifAjuste;
            }


            this.txtDetraccion.Text = nTotDetraccion.ToString("##,##0.00");
            //this.txtDetraccion.Text = nTotalDetraccion.ToString("##,##0.00");
            this.txtTot4taCateg.Text = nTotCuartaCateg.ToString("##,##0.00");
            this.txtTotOtros.Text = nTotalOtros.ToString("##,##0.00");
            this.txtTotal.Text = nTotal.ToString("##,##0.00");
            this.txtTotPag.Text = nTotPagar.ToString("##,##0.00");
            this.txtDescuentos.Text = nTotDes.ToString("##,##0.00");
            this.txtNetoPagar.Text = (nTotPagar - nTotDes).ToString("##,##0.00");
		}

		private void BuscarComprobante(int idCpg)
		{
			lBloquearCalcular = true;
			DesvincularComponentes();
			LimpiarCampos();
			//=======================================================================
			//--Referenciar a null los DataTable y Crear Nuevos Objetos 
			//=======================================================================
			dtComprPago = null;
			dtDetComprPago = null;
			dtDescComprPago = null;
			dtComprPago = new DataTable("dtComprPago");
			dtDetComprPago = new DataTable("dtDetComprPago");
			dtDescComprPago = new DataTable("dtDescComprPago");

			//=======================================================================
			//--Buscar Datos del maestro y detalle 
			//=======================================================================
			dtComprPago = objCajaChica.BuscarComprPago(idCpg);
			if (dtComprPago.Rows.Count<=0)
			{
				MessageBox.Show("No Existe Comprobante...Validar", "Buscar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				lBloquearCalcular = false;
				return;
			}

			if (Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]) == 3)
			{
				MessageBox.Show("El Comprobante se Encuentra Eliminado", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				lBloquearCalcular = false;
				return;
			}

			if (Convert.ToInt16(dtComprPago.Rows[0]["lCpgCajChica"]) == 1)
			{
				MessageBox.Show("El Comprobante no Pertenece a Caja General", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				lBloquearCalcular = false;
				return;
			}

			dtDetComprPago = objCajaChica.BuscarDetComprPago(idCpg);
			dtDetComprPago.DefaultView.RowFilter = ("lVigente <> 0");

			foreach (DataColumn column in dtComprPago.Columns)
			{
				column.ReadOnly = false;
			}

			foreach (DataColumn column in dtDetComprPago.Columns)
			{
				column.ReadOnly = false;
			}


			

			//=======================================================================
			//--Asignar valores a controles
			//=======================================================================
			//clsCNBuscarCli listarCli = new clsCNBuscarCli();
			//DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(dtComprPago.Rows[0]["idCliente"].ToString()));

			//conBusCliente.txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
			//conBusCliente.txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
			//conBusCliente.txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);
			//conBusCliente.txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
			//conBusCliente.txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
			//conBusCliente.txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);

			conBusCliente.CargardatosCli(Convert.ToInt32(dtComprPago.Rows[0]["idCliente"].ToString()));
			conBusCliente.txtCodCli.Enabled = false;

			clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
			DataTable dtAgencia = ListadoAgencia.ListarAgencias();
			//=======================================================================
			//--Agregar Colummna de tipo combobox
			//=======================================================================
			DataGridViewComboBoxColumn cboAgencia = new DataGridViewComboBoxColumn();
			cboAgencia.Name = "cboAgencia";
			cboAgencia.DataPropertyName = "idAgencia";
			cboAgencia.DataSource = dtAgencia;
			cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
			cboAgencia.DisplayMember = dtAgencia.Columns["cNomCorto"].ToString();
			this.dtgDetalleComprobante.Columns.Add(cboAgencia);

			//=======================================================================
			//--Llenar datagridview descuentos de comprobante y darle formato
			//=======================================================================
			dtDescComprPago = objCajaChica.BuscarDescComprPago(idCpg);
			dtgOtrosDesctosCpg.DataSource = dtDescComprPago;
			FormatoGridOtrosDescuentos();

			txtCodRef.Text = dtComprPago.Rows[0]["IdCpgRef"].ToString();

			if (string.IsNullOrEmpty(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString()))
			{
				rbtnSinDetraccion.Checked = true;
				cboTipoOperacion.SelectedIndex = -1;
				cboBienServicio.SelectedIndex = -1;
				txtPorcDetraccion.Text = "";
			}
			else
			{
				rbtnConDetraccion.Checked = true;
				cboTipoOperacion.DataBindings.Clear();
				cboBienServicio.DataBindings.Clear();
				cboTipoOperacion.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString());
				cboBienServicio.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idBienServicioDetr"].ToString());
			}

			if (dtComprPago.Rows[0]["dFechaProvision"] != DBNull.Value)
			{
				dtpFechaProvision.Format = DateTimePickerFormat.Short;
				dtpFechaProvision.Text = dtComprPago.Rows[0]["dFechaProvision"].ToString();
			}

			if (dtComprPago.Rows[0]["cMotAnul"] != DBNull.Value)
			{
				chcAnular.Checked = true;
			}

			if (dtComprPago.Rows[0]["IdMotReparoCpg"] != DBNull.Value)
			{
				chcReparar.Checked = true;
			}

			if (dtComprPago.Rows[0]["dFechaOpe"] != DBNull.Value)
			{
				this.dFecRegistro.Value = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaOpe"]);
			}

			if (dtComprPago.Rows[0]["dFechaDetraccion"] != DBNull.Value)
			{
				this.dtpFecDetraccion.Value = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaDetraccion"]);
			}
            /*PRUEBA***********************/
            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetComprPago;
            FormatoGridDetalle();

            VincularComponentes();
            /*PRUEBA***********************/



			chcAnular.Enabled = false;
			chcReparar.Enabled = false;
			txtMotAnulacion.Enabled = false;
			cboMotReparoCpg.Enabled = false;
			dtpFechaProvision.Enabled = false;
			cboTipoOperacion.Enabled = false;
			cboBienServicio.Enabled = false;
			cboDestino.Enabled = false;
            cboIGV.Enabled = false;

            btnCorregir.Enabled = true;
			btnNuevo.Enabled = false;
			btnEditar.Enabled = true;
			btnGrabar.Enabled = false;
			btnCancelar.Enabled = true;
			btnBusqueda.Enabled = false;
			btnAgregarDetalle.Enabled = false;
            btnImportarPlantillaExcel.Enabled = false;
            btnQuitarDetalle.Enabled = false;
			btnBusqCodRef.Enabled = false;
			txtCodigo.Enabled = false;

			lIsCierre = Convert.ToBoolean(dtComprPago.Rows[0]["lIsCierre"]); //--Indica si el comprobante ya esta cerrado o no
			pEstadoCpg = Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]);

			if (Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]) == 2)
			{
				MessageBox.Show("El Comprobante se Encuentra Pagado, No puede Modificar montos ni Anular", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				btnEditar.Enabled = false;
				chcAnular.Enabled = false;
			}

			if (lIsCierre)
			{
				 MessageBox.Show("El Comprobante pertenece a un periódo cerrado, no puede modificar", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				 btnEditar.Enabled = false;
			}

            if (Convert.ToBoolean(dtComprPago.Rows[0]["lViatico"]))
            {
                MessageBox.Show("El comprobante fue registrado desde el Sistema Web de Viáticos y Entregas a Rendir, no puede ser modificado", "Comprobante de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEditar.Enabled = false;
            }

            /*Habilitar botón de corrección*/
            string cPerfiles = Convert.ToString(clsVarApl.dicVarGen["cIdPerfilEditarComprobante"]);
            String[] cPerfil;
            int[] nPerfil;
            cPerfil = cPerfiles.Split(',');
            nPerfil = Array.ConvertAll<string, int>(cPerfil, int.Parse);
            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 2 && clsVarGlobal.PerfilUsu.idPerfil.In(nPerfil) && !lIsCierre)
            {
                btnCorregir.Visible = true;
                btnEditar.Enabled = true;
            }

			dtgDetalleComprobante.Enabled = false;
			dtgOtrosDesctosCpg.Enabled = false;
			//lBloquearCalcular = false;
			grbDetraccion.Enabled = false;

			idDestino = Convert.ToInt32(dtComprPago.Rows[0]["idDestino"]);

            nMontoInicial = Convert.ToDecimal(txtNetoPagar.Text);          
		}

		private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMoneda.SelectedValue != null)
			{
				if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
				{
					clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
					DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
					lblCambio.Visible = true;
					txtCambio.Visible = true;
					if (tbTipCam.Rows.Count > 0) 
					{
						txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);   
					}
					else
					{
						MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtCambio.Text = "0.00";
						return;
					}
									
				}                    
				else
				{
					lblCambio.Visible = false;
					txtCambio.Visible = false;
					txtCambio.Text = "";
				}
			}
			else
			{
				lblCambio.Visible = false;
				txtCambio.Visible = false;
				txtCambio.Text = "";
			}
		}

		private void cboDestino_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboDestino.SelectedIndex == -1) return;
			if (dtComprPago != null)
			{
				if (dtComprPago.Rows.Count > 0)
				{
					if (eoperacion == Transaccion.Edita)
					{
						var idDestinoNew = Convert.ToInt32(cboDestino.SelectedValue);
						if (idDestinoNew == 3 && idDestino.In(1, 2))
						{
							MessageBox.Show("Destino ya tenía afectación de IGV, por favor validar los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							//cboDestino.SelectedValue = idDestino;
						}
					}

                    if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lisGravado"]) && cboDestino.SelectedIndex == 0 )
                    {
                        if (Convert.ToInt32(dtConfigTipCompr.Rows[0]["idTipComPag"]) == 2) //Factura
                            cboIGV.Enabled = true;
                        else
                            cboIGV.Enabled = false;

                        cboIGV.SelectedValue = Convert.ToInt32(dtConfigTipCompr.Rows[0]["idIGV"]);
                    }
                    else
                    {
                        cboIGV.Enabled = false;
                        cboIGV.SelectedIndex = -1;
                    }

				}
			}
			CalcularTotal(true);
		}

		private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
			{
				e.Handled = true;
			}
			if (e.KeyChar == 13)
			{
				if (string.IsNullOrEmpty(txtCodigo.Text.Trim()))
				{
					MessageBox.Show("Ingrese Codigo de Comprobante...", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (Convert.ToInt32(txtCodigo.Text)<=0)
				{
					MessageBox.Show("Ingrese Codigo de Comprobante Valido", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				BuscarComprobante(Convert.ToInt32(txtCodigo.Text));
			}
		}

		private void btnAnular_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtCodigo.Text))
			{
				MessageBox.Show("Primero debe Buscar el Comprobante a Eliminar", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			int idCpg = Convert.ToInt32(txtCodigo.Text);
			string cMotivoEli = "Comprobante Mal Emitido";

			if (idCpg <= 0)
			{
				MessageBox.Show("El Número de Comprobante no es Válido", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (MessageBox.Show("¿Esta seguro(a) de anular este comprobante de pago?", "Registro de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}

			DataTable result = objCajaChica.CNEliminarComprobanteCaja(idCpg, cMotivoEli, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

			if (result.Rows[0]["nResp"].ToString() == "0")
			{
				MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
				EnableDisableControls(1);
                btnCorregir.Enabled = false;
				btnNuevo.Enabled = true;
				btnEditar.Enabled = false;
				btnGrabar.Enabled = false;
				btnCancelar.Enabled = true;
				btnBusqueda.Enabled = false;
				btnAgregarDetalle.Enabled = false;
                btnImportarPlantillaExcel.Enabled = false;
                btnQuitarDetalle.Enabled = false;
				btnAnular.Enabled = false;
				btnBusqCodRef.Enabled = false;
				txtCodigo.Enabled = false;
				chcAnular.Enabled = false;
				btnAnular.Enabled = false;
				objCmp.CNAnulaAsientoCmp(dtpFechaEmision.Value.Date, idCpg, 3);
			}
			else
			{
				MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void chcCuartaCateg_CheckedChanged(object sender, EventArgs e)
		{
			CalcularTotal(false);//Se debe mantener el valor de IGV
		}

		private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
		{
			if (cboMoneda.SelectedValue != null)
			{
				if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
				{
					clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
					DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
					lblCambio.Visible = true;
					txtCambio.Visible = true;
					if (tbTipCam.Rows.Count > 0)
					{
						txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
					}
					else
					{
						MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtCambio.Text = "0.00";
						return;
					}                    
				}
				else
				{
					lblCambio.Visible = false;
					txtCambio.Visible = false;
					txtCambio.Text = "";
				}
			}
			else
			{
				lblCambio.Visible = false;
				txtCambio.Visible = false;
				txtCambio.Text = "";
			}

		}

        private void dtpFechaEmision_Leave(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblCambio.Visible = true;
                    txtCambio.Visible = true;
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
            }
            else
            {
                lblCambio.Visible = false;
                txtCambio.Visible = false;
                txtCambio.Text = "";
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
		{
			DateTime dFecIni = dtpFechaEmision.Value.Date;
			DateTime dFecFin = dtpFechaEmision.Value.Date;
			int idModulo = 3;
			decimal nTipCambio = clsVarApl.dicVarGen["nTipoCambio"];
			int nCuenta = Convert.ToInt32(txtCodigo.Text);

			List<ReportParameter> paramlist = new List<ReportParameter>();
			paramlist.Clear();

			paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
			paramlist.Add(new ReportParameter("x_dfecini", dFecIni.ToString(), false));
			paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString(), false));
			paramlist.Add(new ReportParameter("x_idCuenta", nCuenta.ToString(), false));
			paramlist.Add(new ReportParameter("x_TipoCambio", nTipCambio.ToString(), false));

			List<ReportDataSource> dtslist = new List<ReportDataSource>();
			dtslist.Clear();
			dtslist.Add(new ReportDataSource("dtsAsientoCuenta", new clsRPTCNContabilidad().CNAsientoTRX(dFecIni, dFecFin, nCuenta, idModulo)));

			string reportpath = "RptAsientoTrx.rdlc";
			new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void btnCorregir_Click(object sender, EventArgs e)
        {
            if (cboTipoComprobantePago.SelectedIndex == -1) return;

            grbDetraccion.Enabled = true;
            chcCuartaCateg.Enabled = true;

            configurarControlesPorTipoComprobante(sender, e);

            dtgDetalleComprobante.Enabled = true;
            dtgDetalleComprobante.ReadOnly = false;
            dtgDetalleComprobante.Columns["cProyecto"].ReadOnly = true;
            dtgDetalleComprobante.Columns["cConceptoComprPago"].ReadOnly = true;
            dtgDetalleComprobante.Columns["cCentroCosto"].ReadOnly = true;
            dtgDetalleComprobante.Columns["cEstablecimiento"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = true;

            lCorregir = true;
            cboTipoComprobantePago.Enabled = true;
            cboDestino.Enabled = true;
            conBusCliente.Enabled = true;
            this.conBusCliente.btnBusCliente.Enabled = true;
            this.conBusCliente.txtCodCli.Enabled = true;
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            lBloquearCalcular = false;
            txtSerie.Enabled = true;
            txtNumero.Enabled = true;
            dtpFechaEmision.Enabled = true;
            dFecRegistro.Enabled = true;
            cboMoneda.Enabled = true;

            if (rbtnConDetraccion.Checked)
            {
                cboTipoOperacion.Enabled = true;
                cboBienServicio.Enabled = true;
            }

            btnCorregir.Enabled = false;
        }

        private void btnDescargar1_Click(object sender, System.EventArgs e)
        {
            if (txtCodigo.Text != "" && dtComprPago.Rows.Count > 0)
            {
                DataTable dtImagenComprobante = new clsCNCuentasPorPagar().obtenerImagenComprobante(Convert.ToInt32(txtCodigo.Text));

                if (dtImagenComprobante.Rows.Count > 0)
                {
                    frmMostrarImagen frmImagen = new frmMostrarImagen(dtImagenComprobante.Rows[0]["cNombreArchivo"].ToString(), dtImagenComprobante.Rows[0]["cExtension"].ToString(), (byte[])dtImagenComprobante.Rows[0]["bArchivoBinario"]);
                    frmImagen.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado una imagen cargado para este comprobante de pago", "Mostrar Comprobante de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se ha encontrado un código de comprobante válido, registre o busque un comprobante válido", "Mostrar Comprobante de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void cboIGV_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CalcularTotal(true);
        }

        private void ObtenerDatos()
        {
            this.dsDatosConf = this.objCNCargaMasiva.CNObtieneConfiguracionPlantilla((int)eTipoPlantilla.Resumido);
            this.dtCabeceras = this.dsDatosConf.Tables[0];
        }

        private void GenerarPlantilla()
        {
            int progress = 5;
            UpdateProgress(progress);

            Excel.Application excelApp = new Excel.Application();
            excelApp.ScreenUpdating = false;
            excelApp.DisplayAlerts = false;

            Excel.Workbook oWorkBook = excelApp.Workbooks.Add();

            Excel.Worksheet oWorkSheetCatalogos = (Excel.Worksheet)oWorkBook.Sheets[1];
            oWorkSheetCatalogos.Name = "Catalogos";

            Excel.Worksheet oWorkSheetFormato = (Excel.Worksheet)oWorkBook.Sheets.Add();
            oWorkSheetFormato.Name = "Formato";

            progress += 10;
            UpdateProgress(progress);

            foreach (DataRow dr in dtCabeceras.Rows)
            {
                bool lObligatorio = dr.Field<bool>("lRequerido");
                string cRequerido = lObligatorio ? "(*)" : "";
                bool lDetalle = dr.Field<bool>("lDetalle");
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")] = dr["cCabecera"].ToString() + cRequerido;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].Interior.Color = lDetalle ? ColorTranslator.ToOle(Color.LightYellow) : ColorTranslator.ToOle(Color.SkyBlue);
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].Font.Bold = true;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetFormato.Cells[1, dr.Field<int>("nOrden")].ColumnWidth = 20;
            }

            DataTable dtCatalogos = dtCabeceras.Select("cTipoDato = 'collection'").CopyToDataTable();
            int nCantidadCatalogos = dtCatalogos.Rows.Count;

            for (int i = 1; i <= dtCatalogos.Rows.Count; i++)
            {
                dsDatosConf.Tables[i].TableName = dtCatalogos.Rows[i - 1]["cCabecera"].ToString();
            }

            progress += 10;
            UpdateProgress(progress);

            int step = 1;
            step = 75 / nCantidadCatalogos;

            for (int i = 1; i < nCantidadCatalogos * 3; i += 3)
            {
                string cNombreCatalogo = dtCatalogos.Rows[(i - 1) / 3]["cCabecera"].ToString();

                oWorkSheetCatalogos.Cells[1, i] = cNombreCatalogo;
                oWorkSheetCatalogos.Range[oWorkSheetCatalogos.Cells[1, i], oWorkSheetCatalogos.Cells[1, i + 1]].Merge();
                oWorkSheetCatalogos.Cells[1, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetCatalogos.Cells[1, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[1, i].Interior.Color = ColorTranslator.ToOle(Color.SkyBlue);
                oWorkSheetCatalogos.Cells[1, i].Font.Bold = true;

                oWorkSheetCatalogos.Cells[2, i] = "Código";
                oWorkSheetCatalogos.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oWorkSheetCatalogos.Cells[2, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[2, i].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                oWorkSheetCatalogos.Cells[2, i].Font.Bold = true;

                oWorkSheetCatalogos.Cells[2, i + 1] = "Descripción";
                oWorkSheetCatalogos.Cells[2, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oWorkSheetCatalogos.Cells[2, i + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oWorkSheetCatalogos.Cells[2, i + 1].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                oWorkSheetCatalogos.Cells[2, i + 1].Font.Bold = true;

                foreach (DataRow dr in dsDatosConf.Tables[cNombreCatalogo].Rows)
                {
                    int index = dsDatosConf.Tables[cNombreCatalogo].Rows.IndexOf(dr);

                    oWorkSheetCatalogos.Cells[3 + index, i] = dr["idCodigo"].ToString();
                    oWorkSheetCatalogos.Cells[3 + index, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    oWorkSheetCatalogos.Cells[3 + index, i].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    oWorkSheetCatalogos.Cells[3 + index, i + 1] = dr["cDescripcion"].ToString();
                    oWorkSheetCatalogos.Cells[3 + index, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    oWorkSheetCatalogos.Cells[3 + index, i + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    oWorkSheetCatalogos.Cells[3 + index, i + 2] = " ";
                }

                progress += (step > 100) ? 100 : step;
                UpdateProgress(progress);
            }

            for (int i = 1; i <= nCantidadCatalogos * 3; i += 3)
            {
                oWorkSheetCatalogos.Cells[1, i].ColumnWidth = 8;
                oWorkSheetCatalogos.Cells[1, i + 1].ColumnWidth = 30;
                oWorkSheetCatalogos.Cells[1, i + 2].ColumnWidth = 3;
            }

            UpdateProgress(100);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = InitialDirectory;
            saveFileDialog.FileName = string.Format("Plantilla de Carga Masiva para un solo Comprobante - {0}.xlsx", DateTime.Now.ToString("ddMMyyyy"));
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                InitialDirectory = Path.GetDirectoryName(rutaArchivo);
                oWorkBook.SaveAs(rutaArchivo);
            }

            oWorkBook.Close();
            excelApp.Quit();
            UpdateProgress(0);

            // Libera recursos COM
            ReleaseComObject(oWorkSheetFormato);
            ReleaseComObject(oWorkSheetCatalogos);
            ReleaseComObject(oWorkBook);
            ReleaseComObject(excelApp);

            HabilitarFormulario(true);

            if (this.InvokeRequired)
                Invoke(new Action(() => this.progressBar.Visible = false));
        }

        private void HabilitarFormulario(bool lHabilita)
        {
            if (this.InvokeRequired)
                Invoke(new Action<bool>(HabilitarFormulario), lHabilita);

            this.Enabled = lHabilita;
        }

        private void UpdateProgress(int progress)
        {
            if (this.InvokeRequired)
                Invoke(new Action<int>(UpdateProgress), progress);

            this.progressBar.Value = progress;
        }

        private void ReleaseComObject(object obj)
        {
            if (obj != null && System.Runtime.InteropServices.Marshal.IsComObject(obj))
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }

        private void ValidaDatosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataColumn dc in dtDatosCargados.Columns)
            {
                if (dc.ColumnName.Contains("(*)"))
                    dc.ColumnName = dc.ColumnName.Replace("(*)", "");
            }

            if (!ValidaCabecerasExcel(dtDatosCargados))
                return;

            DataTable dtCatalogos = dtCabeceras.Select("cTipoDato = 'collection'").CopyToDataTable();

            for (int i = 1; i <= dtCatalogos.Rows.Count; i++)
            {
                this.dsDatosConf.Tables[i].TableName = dtCatalogos.Rows[i - 1]["cCabecera"].ToString();
            }

            if (!ValidaCatalogosExcel(dtDatosCargados))
                return;

            if (!ValidaCamposObligatoriosExcel(dtDatosCargados))
                return;

            if (!ValidaFormatosExcel(dtDatosCargados))
                return;

            int idCpg = (string.IsNullOrEmpty(this.txtCodigo.Text)) ? 0 : Convert.ToInt32(this.txtCodigo.Text);

			foreach (DataRow row in dtDatosCargados.Rows)
			{
				if (!row.ItemArray.All(value => value == null || value == DBNull.Value))
				{
					DataRow dr = this.dtDetComprPago.NewRow();
					dr["idDetalleComprobante"] = -1;
					dr["idComprobantePago"] = idCpg;
					dr["nSubtotalImporte"] = Convert.ToDecimal(row.Field<string>("SubTotal"));
					dr["nIgvImporte"] = 0.00;
					dr["nMontoDetraccion"] = 0.00;
					dr["nMontoImporte"] = 0.00;
					dr["nCuartaCategImporte"] = 0.00;
					dr["nMontoPagar"] = 0.00;
					dr["nOtrosImporte"] = Convert.ToDecimal(row.Field<string>("Otros"));
					dr["idAgencia"] = clsVarGlobal.nIdAgencia;
					string cProyecto = row.Field<string>("Proyecto").ToUpper();
                    int idProyecto = this.dsDatosConf.Tables["Proyecto"].AsEnumerable().FirstOrDefault(c => c.Field<string>("cDescripcion").ToUpper() == cProyecto).Field<int>("idCodigo");
                    dr["idProyecto"] = idProyecto;
					dr["cProyecto"] = cProyecto;
					string cConcepto = row.Field<string>("Concepto").ToUpper();
                    int idConcepto = this.dsDatosConf.Tables["Concepto"].AsEnumerable().FirstOrDefault(c => c.Field<string>("cDescripcion").ToUpper() == cConcepto).Field<int>("idCodigo");
                    dr["idConceptoComprobante"] = idConcepto;
                    dr["cConceptoComprPago"] = cConcepto;
					string cCentroCosto = row.Field<string>("Centro de Costo").ToUpper();
                    int idCentroCosto = this.dsDatosConf.Tables["Centro de Costo"].AsEnumerable().FirstOrDefault(c => c.Field<string>("cDescripcion").ToUpper() == cCentroCosto).Field<int>("idCodigo");
                    dr["idCentroCosto"] = idCentroCosto;
                    dr["cCentroCosto"] = cCentroCosto;
                    string cEstablecimiento = row.Field<string>("Agencia/EOB").ToUpper();
                    int idEstablecimiento = this.dsDatosConf.Tables["Agencia/EOB"].AsEnumerable().FirstOrDefault(c => c.Field<string>("cDescripcion").ToUpper() == cEstablecimiento).Field<int>("idCodigo");
                    dr["idEstablecimiento"] = idEstablecimiento;
					dr["cEstablecimiento"] = cEstablecimiento;
                    dr["lVigente"] = 1;
                    this.dtDetComprPago.Rows.Add(dr);
				}
			}

            CalcularTotal(true);
		}

        private bool ValidaCabecerasExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drCabecera in this.dtCabeceras.Rows)
            {
                var cNombreCabecera = drCabecera.Field<string>("cCabecera");
                if (!dtDatosCargados.Columns.Contains(cNombreCabecera))
                    lstErrores.Add($"No se encontró la columna {cNombreCabecera} en el archivo.");
            }

            foreach (DataColumn dc in dtDatosCargados.Columns)
            {
                if (!this.dtCabeceras.Rows.Cast<DataRow>().Any(c => c.Field<string>("cCabecera") == dc.ColumnName))
                    lstErrores.Add($"No se encontró la configuración de la columna {dc.ColumnName} en la base de datos.");
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores en las cabeceras, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Cabeceras");
                return false;
            }

            return true;
        }

        private bool ValidaCatalogosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drCabecera in this.dtCabeceras.Rows)
            {
                string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                string cTipoDato = drCabecera.Field<string>("cTipoDato");

                if (cTipoDato == "collection" && !this.dsDatosConf.Tables.Contains(cNombreCabecera))
                    lstErrores.Add($"No se encontró el catalogo de valores para la columna {cNombreCabecera} en la base de datos.");
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores de catálogos, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Catálogos");
                return false;
            }

            return true;
        }

        private bool ValidaCamposObligatoriosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drDatos in dtDatosCargados.Rows)
            {
                foreach (DataRow drCabecera in this.dtCabeceras.Rows)
                {
                    string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                    bool lRequerido = drCabecera.Field<bool>("lRequerido");
                    string cValor = drDatos.Field<string>(cNombreCabecera);

                    if (string.IsNullOrEmpty(cValor))
                    {
                        if (lRequerido)
                            lstErrores.Add($"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} es requerido.");
                        continue;
                    }
                }
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " campos obligatorios vacíos, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Campos Obligatorios");
                return false;
            }

            return true;
        }

        private bool ValidaFormatosExcel(DataTable dtDatosCargados)
        {
            var lstErrores = new List<string>();

            foreach (DataRow drDatos in dtDatosCargados.Rows)
            {
                foreach (DataRow drCabecera in this.dtCabeceras.Rows)
                {
                    string cNombreCabecera = drCabecera.Field<string>("cCabecera");
                    string cTipoDato = drCabecera.Field<string>("cTipoDato");
                    string cFormato = drCabecera.Field<string>("cFormato");
                    string cValor = drDatos[cNombreCabecera] == null ? string.Empty : drDatos[cNombreCabecera].ToString();
                    bool lRequerido = drCabecera.Field<bool>("lRequerido");

                    if (!lRequerido && string.IsNullOrEmpty(cValor))
                        continue;

                    if (cTipoDato == "collection")
                    {
                        if (!this.dsDatosConf.Tables[cNombreCabecera].AsEnumerable().Any(c => c.Field<string>("cDescripcion").ToUpper() == cValor.ToUpper()))
                            lstErrores.Add($"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} no se encuentra en el catálogo.");
                    }
                    else
                    {
                        if (cTipoDato == "datetime" && double.TryParse(cValor, out double cValorEntero))
                        {
                            DateTime dFecha;
                            if (DateTime.TryParse(DateTime.FromOADate(cValorEntero).ToString(), out dFecha))
                            {
                                cValor = dFecha.ToString("dd/MM/yyyy");
                                drDatos[cNombreCabecera] = cValor;
                            }
                        }

                        bool ExisteFormato() => !string.IsNullOrEmpty(cFormato);
                        bool FormatoValido() => Regex.IsMatch(cValor, cFormato);

                        string cMensajeError = $"El campo {cNombreCabecera} en la fila {drDatos.Table.Rows.IndexOf(drDatos) + 2} no cumple con el formato requerido.";

                        switch (cTipoDato)
                        {
                            case "string":
                                if (ExisteFormato() && !FormatoValido())
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "datetime":
                                if (ExisteFormato())
                                {
                                    if (!DateTime.TryParseExact(cValor, cFormato, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                                        lstErrores.Add(cMensajeError);
                                }
                                else
                                {
                                    if (!DateTime.TryParse(cValor, out _))
                                        lstErrores.Add(cMensajeError);
                                }
                                break;

                            case "int":
                                if ((ExisteFormato() && !FormatoValido()) || (!int.TryParse(cValor, out _)))
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "decimal":
                                if ((ExisteFormato() && !FormatoValido()) || (!decimal.TryParse(cValor, out _)))
                                    lstErrores.Add(cMensajeError);
                                break;

                            case "bool":
                                if (string.IsNullOrEmpty(cValor))
                                    drDatos[cNombreCabecera] = "NO";
                                else if (cValor.ToUpper() != "SI" && cValor.ToUpper() != "NO")
                                    lstErrores.Add(cMensajeError);
                                break;
                        }
                    }
                }
            }

            if (lstErrores.Count > 0)
            {
                if (MessageBox.Show("Se encontraron " + lstErrores.Count + " errores de formato, ¿Desea descargar el archivo con los detalles?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    GeneraDetalleErrores(lstErrores, "Formato");
                return false;
            }

            return true;
        }

        private void GeneraDetalleErrores(List<string> lstErrores, string cNivel)
        {
            string cRutaArchivo = Path.Combine(this.InitialDirectory, DateTime.Now.ToString("ddMMyyyy-HHmmss") + "-ErroresCargaMasiva(" + cNivel + ").txt");

            using (StreamWriter sw = new StreamWriter(cRutaArchivo))
            {
                foreach (string cError in lstErrores)
                {
                    sw.WriteLine(cError);
                }
            }

            MessageBox.Show("Se generó un archivo con los errores en la siguiente ruta: " + cRutaArchivo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportarDatos(string rutaArchivo)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(rutaArchivo);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            Excel.Range usedRange = worksheet.UsedRange;
            object[,] valores = (object[,])usedRange.Value2;

            DataTable dt = new DataTable();

            for (int col = 1; col <= valores.GetLength(1); col++)
            {
                dt.Columns.Add(valores[1, col] == null ? string.Empty : valores[1, col].ToString());
            }

            for (int row = 2; row <= valores.GetLength(0); row++)
            {
                DataRow dataRow = dt.NewRow();
                for (int col = 1; col <= valores.GetLength(1); col++)
                {
                    dataRow[col - 1] = valores[row, col];
                }
                dt.Rows.Add(dataRow);
            }

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                bool isRowEmpty = true;

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null && !string.IsNullOrWhiteSpace(dt.Rows[i][j].ToString()))
                    {
                        isRowEmpty = false;
                        break;
                    }
                }

                if (isRowEmpty)
                {
                    dt.Rows[i].Delete();
                }
            }

            workbook.Close(false);
            excelApp.Quit();

            ReleaseComObject(worksheet);
            ReleaseComObject(workbook);
            ReleaseComObject(excelApp);

            ValidaDatosExcel(dt);
        }

        private void btnExporPlantillaExcel_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            string cMensaje = "¿Deseas generar una plantilla?";

            if (MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;

            HabilitarFormulario(false);

            this.progressBar.Visible = true;
            this.progressBar.Value = 0;
            this.excelThread = new Thread(GenerarPlantilla);
            this.excelThread.SetApartmentState(ApartmentState.STA);
            this.excelThread.Start();
        }

        private void btnImportarPlantillaExcel_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = InitialDirectory;
            openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                ImportarDatos(openFileDialog.FileName);
        }
    }
}
