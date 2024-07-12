using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using System.IO;
using CRE.CapaNegocio;
using System.Drawing.Imaging;

namespace CRE.Presentacion
{
	public partial class frmRegistroGastos : frmBase
	{

		#region Variables Globales

		private string cDocumentoSesion;
		private byte[] vDocumentoSesion;
		private Image imgDoc;
		private string cExtension;

		private decimal nTipCambio = 0M;

		DataTable dtGastosCuenta = null;

		private const string cTituloMsjes = "Registro de gastos";

		#endregion

		#region Eventos

		private void Form_Load(object sender, EventArgs e)
		{
			ttpMonCred.SetToolTip(lblMtoMonCred, "Monto del gasto convertido a la moneda del crédito");
			ttpMtoGasto.SetToolTip(lblMtoGasto, "Monto del gasto");
			nTipCambio = Convert.ToDecimal(clsVarApl.dicVarGen["nTipoCambio"]);

			LimpiarDatosCredito();
			dtgGastosCuenta.DataSource = string.Empty;
			LimpiarControles();
			HabilitarControles(false);

			dtpFecIni.Enabled = false;
			dtpFecFin.Enabled = false;
			btnFiltroGastos.Enabled = false;
			btnMiniDescargar.Enabled = false;

			btnNuevo.Enabled = false;
			btnGrabar.Enabled = false;
			btnEliminar.Enabled = false;
			btnCancelar.Enabled = false;

			conBusCuentaCli.Focus();
			conBusCuentaCli.txtNroBusqueda.Select();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			LimpiarControles();
			CrearTableGastos();

			dtGastosCuenta.Rows[0]["idGastoCuenta"] = 0;

			cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
			cboMonGasto.SelectedValue = 1;
			cboGrupoGasto.SelectedValue = 1;
			cboTipGasto.CargarTipGasto(1);
			//txtTipCambio.Text = string.Format("{0:#,0.00}", nTipCambio);

			dtgGastosCuenta.Enabled = false;

			HabilitarControles(true);

			btnNuevo.Enabled = false;
			btnGrabar.Enabled = true;
			btnEliminar.Enabled = false;
			btnCancelar.Enabled = true;

			cboTipGasto.Focus();
		}

		private void btnGrabar_Click(object sender, EventArgs e)
		{
			if (!Validar()) return;

			LlenarTablaGastosData();

			dtGastosCuenta.TableName = "dtGastosCuenta";

			DataSet dsGastosCuenta = new DataSet("dsGastosCuenta");
			dsGastosCuenta.Tables.Add(dtGastosCuenta);

			string xmlGastosCuenta = dsGastosCuenta.GetXml();

			dsGastosCuenta.Tables.Clear();

			clsDBResp objDbResp = new clsCNGastosCuenta().CNGrabarGastos(xmlGastosCuenta,vDocumentoSesion);
			if (objDbResp.nMsje == 0)
			{
				MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
				dtgGastosCuenta.DataSource = string.Empty;
				LimpiarControles();
				DataTable dtResult = new clsCNGastosCuenta().CNLstGastosCuenta(conBusCuentaCli.nValBusqueda);
				dtResult.Columns["lDescargar"].ReadOnly = false;
				dtgGastosCuenta.DataSource = dtResult;
				FormatoGrid();
                CalcularTotal();

				HabilitarControles(false);
				btnEliminar.Enabled = (dtResult.Rows.Count > 0);
				btnNuevo.Enabled = true;
				btnCancelar.Enabled = true;
				btnGrabar.Enabled = false;

				dtgGastosCuenta.Enabled = true;

				dtgGastosCuenta.Focus();
			}
			else
			{
				MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (dtgGastosCuenta.SelectedRows.Count == 0)
			{
				MessageBox.Show("Seleccione el gasto a eliminar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult result = MessageBox.Show("¿Está seguro de eliminar el gasto?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != System.Windows.Forms.DialogResult.Yes)
				return;

			dtGastosCuenta = null;
			CrearTableGastos();

			dtgGastosCuenta.Enabled = false;

			dtGastosCuenta.Rows[0]["idGastoCuenta"] = Convert.ToInt32(dtgGastosCuenta.SelectedRows[0].Cells["idGastoCuenta"].Value);
			LlenarTablaGastosData();

			dtGastosCuenta.TableName = "dtGastosCuenta";

			DataSet dsGastosCuenta = new DataSet("dsGastosCuenta");
			dsGastosCuenta.Tables.Add(dtGastosCuenta);

			string xmlGastosCuenta = dsGastosCuenta.GetXml();

			dsGastosCuenta.Tables.Clear();

			clsDBResp objDbResp = new clsCNGastosCuenta().CNGrabarGastos(xmlGastosCuenta, vDocumentoSesion);
			if (objDbResp.nMsje == 0)
			{
				MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
				dtgGastosCuenta.DataSource = string.Empty;
				LimpiarControles();
				DataTable dtResult = new clsCNGastosCuenta().CNLstGastosCuenta(conBusCuentaCli.nValBusqueda);
				dtResult.Columns["lDescargar"].ReadOnly = false;
				dtgGastosCuenta.DataSource = dtResult;
				FormatoGrid();
				CalcularTotal();

				HabilitarControles(false);
				btnEliminar.Enabled = (dtResult.Rows.Count > 0);
				btnNuevo.Enabled = true;
				btnCancelar.Enabled = true;
				btnGrabar.Enabled = false;

				dtgGastosCuenta.Enabled = true;

				dtgGastosCuenta.Focus();
			}
			else
			{
				MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			conBusCuentaCli.LiberarCuenta();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			conBusCuentaCli.LiberarCuenta();
			conBusCuentaCli.limpiarControles();
			LimpiarDatosCredito();
			dtgGastosCuenta.DataSource = string.Empty;
			LimpiarControles();

			dtGastosCuenta = null;

			HabilitarControles(false);

			dtpFecIni.Enabled = false;
			dtpFecFin.Enabled = false;
			btnFiltroGastos.Enabled = false;
			btnMiniDescargar.Enabled = false;

			btnNuevo.Enabled = false;
			btnGrabar.Enabled = false;
			btnEliminar.Enabled = false;
			btnCancelar.Enabled = false;

			conBusCuentaCli.txtNroBusqueda.Enabled = true;
			conBusCuentaCli.btnBusCliente1.Enabled = true;

			conBusCuentaCli.Focus();
			conBusCuentaCli.txtNroBusqueda.Select(); 
		}

		private void txtMontoGasto_Leave(object sender, EventArgs e)
		{
			CalcularCambioMonto();
		}

		private void btnAddDoc_Click(object sender, EventArgs e)
		{
			OpenFileDialog fDialog = new OpenFileDialog();
			fDialog.Title = "Abrir archivo";
			fDialog.DefaultExt = "jpg";
			fDialog.Filter = "Archivos jpg (*.jpg)|*.jpg";
			fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
			fDialog.Multiselect = false;

			if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string cArchivo = fDialog.FileName;

				FileInfo fInfo = new FileInfo(cArchivo);
                if (fInfo.Length/1024.0M > Convert.ToDecimal(clsVarApl.dicVarGen["nSizeFileGastos"]))
                {
                    MessageBox.Show("El tamaño del archivo no puede superar los " 
                                    + Convert.ToInt64(clsVarApl.dicVarGen["nSizeFileGastos"]) + " Kb.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocSustento.Text = String.Empty;
                    cDocumentoSesion = null;
                    cExtension = null;
                    vDocumentoSesion = null;
                    return;
                }

				MemoryStream ms = new MemoryStream();
				imgDoc = Image.FromFile(cArchivo);
				imgDoc.Save(ms, ImageFormat.Jpeg);
				
				txtDocSustento.Text = cArchivo;
				cDocumentoSesion = fInfo.Name;
				cExtension = fInfo.Extension;
				vDocumentoSesion = ms.ToArray();
			}
		}

		private void conBusCuentaCli_MyClic(object sender, EventArgs e)
		{
			cargarDatos();
		}

		private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
		{
			cargarDatos();
		}

		private void dtgGastosCuenta_SelectionChanged(object sender, EventArgs e)
		{
			if (dtgGastosCuenta.SelectedRows.Count > 0)
			{
				MapeaTablaControles(dtgGastosCuenta.SelectedRows[0]);
			}
		}

		private void frmRegistroGastos_FormClosed(object sender, FormClosedEventArgs e)
		{
			conBusCuentaCli.LiberarCuenta();
		}

		private void cboMonGasto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboMonGasto.SelectedIndex >= 0 && cboMonGasto.SelectedValue != null
				 && !(cboMonGasto.SelectedValue is DataRowView))
			{
				CalcularCambioMonto();
			}
		}

		private void cboTipDocGasto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboTipDocGasto.SelectedValue != null && !(cboTipDocGasto.SelectedValue is DataRowView))
			{
				txtTipDocGasto.Enabled = Convert.ToInt32(cboTipDocGasto.SelectedValue) == 5;
			}
		}

		private void btnFiltroGastos_Click(object sender, EventArgs e)
		{
			if (dtpFecIni.Value.Date > dtpFecFin.Value.Date)
			{
				MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string shortDatePattern = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
			string sFilter = String.Format("dFechaReg >= '#{0}#' AND dFechaReg <= '#{1}#'", dtpFecIni.Value.ToString(shortDatePattern),
																								dtpFecFin.Value.ToString(shortDatePattern));
			(dtgGastosCuenta.DataSource as DataTable).DefaultView.RowFilter = sFilter;
			CalcularTotal();
		}

		private void btnMiniDescargar_Click(object sender, EventArgs e)
		{
			var lstDocs = dtgGastosCuenta.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["lDescargar"].Value));

			if (lstDocs.Count() == 0)
			{
				MessageBox.Show("Seleccione por lo menos un documento a descargar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "Guardar archivos";
			dialog.SelectedPath = clsVarGlobal.cRutPathApp;
			dialog.ShowNewFolderButton = true;

			dialog.ShowDialog();

			string cPath = dialog.SelectedPath;

			if (String.IsNullOrEmpty(cPath))
			{
				MessageBox.Show("Seleccione la ruta donde se guardaran los documentos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			foreach (var item in lstDocs)
			{
				if (item.Cells["vDocSustento"].Value != DBNull.Value)
				{
					byte[] vDocumentoSesion = (byte[])item.Cells["vDocSustento"].Value;
					MemoryStream memStream = new MemoryStream();
					memStream.Write(vDocumentoSesion, 0, vDocumentoSesion.Length);
					Image img = Image.FromStream(memStream);
					int idCuenta = Convert.ToInt32(item.Cells["idCuenta"].Value);
					int idGasto = Convert.ToInt32(item.Cells["idGastoCuenta"].Value);

					img.Save(String.Format(@"{0}\Cuenta_{1}_Gasto_{2}.jpg", cPath, idCuenta,idGasto), System.Drawing.Imaging.ImageFormat.Jpeg);
				}
			}
		}

		#endregion

		#region Metodos

		public frmRegistroGastos()
		{
			InitializeComponent();
			conBusCuentaCli.cTipoBusqueda = "C";
			cboTipGasto.DropDownWidth = 300;
		}

		private bool Validar()
		{
			
			if (cboAgencias.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione la agencia del gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (cboMonGasto.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione la moneda del gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			
			if (cboGrupoGasto.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione el grupo del gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			
			if (cboTipGasto.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione el tipo de gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (cboTipDocGasto.SelectedIndex < 0)
			{
				MessageBox.Show("Seleccione el tipo de documento.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (String.IsNullOrEmpty(txtNroDoc.Text.Trim()))
			{
				MessageBox.Show("Ingrese el número de documento.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			
			if (string.IsNullOrEmpty(txtMontoGasto.Text.Trim()))
			{
				MessageBox.Show("Ingrese el monto del gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			if (string.IsNullOrEmpty(txtDetGasto.Text.Trim()))
			{
				MessageBox.Show("Ingrese el detalle del gasto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private void LimpiarControles()
		{
			cboAgencias.SelectedIndex = -1;
			cboMonGasto.SelectedIndex = -1;
			cboGrupoGasto.SelectedIndex = -1;
			cboTipGasto.SelectedIndex = -1;
			cboTipDocGasto.SelectedIndex = -1;
			txtTipDocGasto.Text = string.Empty;
			txtMontoGasto.Text = string.Empty;
			txtMontoMonCred.Text = string.Empty;
			txtNroDoc.Text = string.Empty;
			txtDetGasto.Text = string.Empty;
			txtDocSustento.Text = string.Empty;
			dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
			dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            lblCargaGasto.Text = String.Empty;

			cDocumentoSesion = null;
			vDocumentoSesion = null;
			cExtension = null;
		}

		private void LimpiarDatosCredito()
		{
			txtTipoCredito.Text = string.Empty;
			txtSaldoCred.Text = string.Empty;
			txtAtraso.Text = string.Empty;
			cboMoneda.SelectedIndex = -1;
			txtCuotas.Text = string.Empty;
			txtCuoPend.Text = string.Empty;
			lblMonGasto.Text = string.Empty;
		}

		private void FormatoGrid()
		{
			dtgGastosCuenta.ReadOnly = false;
			foreach (DataGridViewColumn columns in dtgGastosCuenta.Columns)
			{
				columns.ReadOnly = true;
				columns.Visible = false;
			}

			dtgGastosCuenta.Columns["cConcepto"].Visible = true;
			dtgGastosCuenta.Columns["nMontoMonCred"].Visible = true;
			dtgGastosCuenta.Columns["dFechaReg"].Visible = true;
			dtgGastosCuenta.Columns["cWinUser"].Visible = true;
			dtgGastosCuenta.Columns["lDescargar"].Visible = true;


			dtgGastosCuenta.Columns["cConcepto"].HeaderText = "Gasto";
			dtgGastosCuenta.Columns["nMontoMonCred"].HeaderText = "Monto Gasto";
			dtgGastosCuenta.Columns["dFechaReg"].HeaderText = "F. Registro";
			dtgGastosCuenta.Columns["cWinUser"].HeaderText = "Usuario";
			dtgGastosCuenta.Columns["lDescargar"].HeaderText = "Descargar";

			dtgGastosCuenta.Columns["dFechaReg"].FillWeight = 15;
			dtgGastosCuenta.Columns["cWinUser"].FillWeight = 15;
			dtgGastosCuenta.Columns["cConcepto"].FillWeight = 50;
			dtgGastosCuenta.Columns["nMontoMonCred"].FillWeight = 10;
			dtgGastosCuenta.Columns["lDescargar"].FillWeight = 10;

			dtgGastosCuenta.Columns["dFechaReg"].DisplayIndex = 0;
			dtgGastosCuenta.Columns["cWinUser"].DisplayIndex = 1;
			dtgGastosCuenta.Columns["cConcepto"].DisplayIndex = 2;
			dtgGastosCuenta.Columns["nMontoMonCred"].DisplayIndex = 3;
			dtgGastosCuenta.Columns["lDescargar"].DisplayIndex = 4;

			dtgGastosCuenta.Columns["nMontoSoles"].DefaultCellStyle.Format = "#,0.00";

            dtgGastosCuenta.Columns["lDescargar"].ReadOnly = false;
            foreach (DataGridViewRow row in dtgGastosCuenta.Rows)
            {
                row.Cells["lDescargar"].ReadOnly = !(row.Cells["vDocSustento"].Value != DBNull.Value);
            }
		}

		private void cargarDatos()
		{
			LimpiarDatosCredito();
			dtgGastosCuenta.DataSource = string.Empty;
			LimpiarControles();
			if (conBusCuentaCli.nValBusqueda == 0)
			{
				conBusCuentaCli.limpiarControles();
				btnEliminar.Enabled = false;
				btnNuevo.Enabled = false;
				btnCancelar.Enabled = false;
				return;               
			}
			else
			{
				cargarCredito(conBusCuentaCli.nValBusqueda);
				DataTable dtResult = new clsCNGastosCuenta().CNLstGastosCuenta(conBusCuentaCli.nValBusqueda);
				dtResult.Columns["lDescargar"].ReadOnly = false;
				dtgGastosCuenta.DataSource = dtResult;
				FormatoGrid();
				CalcularTotal();

                btnNuevo.Enabled = dtResult.AsEnumerable().Count(x => Convert.ToBoolean(x["lAceptado"])) == 0;
                btnEliminar.Enabled = (dtResult.AsEnumerable().Count(x => Convert.ToBoolean(x["lAceptado"])) == 0) &&
                                        (dtResult.Rows.Count > 0);
                lblCargaGasto.Text = dtResult.AsEnumerable().Count(x => Convert.ToBoolean(x["lAceptado"])) == 0 ? 
                                                                                    String.Empty:
                                                                                    "GASTOS CARGADOS A LA CUENTA";
				btnCancelar.Enabled = true;

				dtgGastosCuenta.Enabled = true;
			}
			btnGrabar.Enabled = false;
			HabilitarControles(false);
		}

		private void cargarCredito(int idCuenta)
		{
			DataTable dtCredito = new clsCNCredito().CNdtDataCreditoCobro(idCuenta);
			decimal nDeuda = 0M;

			if (dtCredito.Rows.Count > 0)
			{
				foreach (DataRow row in dtCredito.Rows)
				{
					DataTable dtPpg = new clsCNPlanPago().CNdtPlanPago(idCuenta);


					nDeuda = (Convert.ToDecimal(row["nCapitalDesembolso"]) - Convert.ToDecimal(row["nCapitalPagado"]) +
								Convert.ToDecimal(row["nInteresPactado"]) - Convert.ToDecimal(row["nInteresPagado"]) +
								Convert.ToDecimal(row["nMoraGenerado"]) - Convert.ToDecimal(row["nMoraPagada"]) +
								Convert.ToDecimal(row["nOtrosGenerado"]) - Convert.ToDecimal(row["nOtrosPagado"]));

					txtTipoCredito.Text = Convert.ToString(row["cProducto"]);
					cboMoneda.SelectedValue = Convert.ToInt16(row["IdMoneda"]);
					txtSaldoCred.Text = string.Format("{0:#,0.00}", nDeuda);
					txtCuotas.Text = Convert.ToString(row["nCuotas"]);
					txtAtraso.Text = Convert.ToString(row["nAtraso"]);
					txtCuoPend.Text = Convert.ToString(new clsCNPlanPago().nNumCuotasPen(dtPpg));
					lblMonGasto.Text = string.Format("en {0}",cboMoneda.Text.ToLower());
				}
			}
		}

		private void MapeaTablaControles(DataGridViewRow dtgRow)
		{
			cboTipDocGasto.SelectedIndexChanged-=cboTipDocGasto_SelectedIndexChanged;

			cboAgencias.SelectedValue = Convert.ToInt32(dtgRow.Cells["idAgencia"].Value);
			cboMonGasto.SelectedValue = Convert.ToString(dtgRow.Cells["idMoneda"].Value);
			cboGrupoGasto.SelectedValue = Convert.ToInt32(dtgRow.Cells["idGrupoGasto"].Value);
			cboTipGasto.SelectedValue = Convert.ToInt32(dtgRow.Cells["idTipoGasto"].Value);
			txtMontoGasto.Text = string.Format("{0:#,0.00}",Convert.ToDecimal(dtgRow.Cells["nMontoSoles"].Value));
			txtMontoMonCred.Text =string.Format("{0:#,0.00}",Convert.ToDecimal(dtgRow.Cells["nMontoMonCred"].Value));
			cboTipDocGasto.SelectedValue = Convert.ToInt32(dtgRow.Cells["idTipDocGasto"].Value);
			txtTipDocGasto.Text = Convert.ToString(dtgRow.Cells["cTipDocGasto"].Value);
			txtNroDoc.Text = Convert.ToString(dtgRow.Cells["cNroDocumento"].Value);
			txtDetGasto.Text = Convert.ToString(dtgRow.Cells["cDetGasto"].Value);
			txtDocSustento.Text = Convert.ToString(dtgRow.Cells["cDocSustento"].Value);

			cboTipDocGasto.SelectedIndexChanged += cboTipDocGasto_SelectedIndexChanged;
		}

		private void CrearTableGastos()
		{
			dtGastosCuenta = new DataTable();

			dtGastosCuenta.Columns.Add("idGastoCuenta",typeof(int));
			dtGastosCuenta.Columns.Add("idCuenta",typeof(int));
			dtGastosCuenta.Columns.Add("idGrupoGasto",typeof(int));
			dtGastosCuenta.Columns.Add("idTipoGasto",typeof(int));
			dtGastosCuenta.Columns.Add("idMoneda",typeof(int));
			dtGastosCuenta.Columns.Add("nMontoSoles",typeof(decimal));
			dtGastosCuenta.Columns.Add("nMontoMonCred",typeof(decimal));
			dtGastosCuenta.Columns.Add("nTipCamFijo",typeof(decimal));
			dtGastosCuenta.Columns.Add("idTipDocGasto", typeof(int));
			dtGastosCuenta.Columns.Add("cTipDocGasto", typeof(string));
			dtGastosCuenta.Columns.Add("cNroDocumento",typeof(string));
			dtGastosCuenta.Columns.Add("cDetGasto",typeof(string));
			dtGastosCuenta.Columns.Add("cDocSustento",typeof(string));
			dtGastosCuenta.Columns.Add("vDocSustento",typeof(byte[]));
			dtGastosCuenta.Columns.Add("cExtDoc",typeof(string));
			dtGastosCuenta.Columns.Add("idAgencia",typeof(int));
			dtGastosCuenta.Columns.Add("dFechaReg",typeof(DateTime));
			dtGastosCuenta.Columns.Add("idUsuario",typeof(int));
			dtGastosCuenta.Columns.Add("lVigente",typeof(bool));
			dtGastosCuenta.Columns.Add("lDescargar", typeof(bool));

			dtGastosCuenta.Rows.Add(dtGastosCuenta.NewRow());
		}

		private void LlenarTablaGastosData()
		{
			DataRow drGasto = dtGastosCuenta.Rows[0];

			drGasto["idCuenta"] = conBusCuentaCli.nValBusqueda;
			drGasto["idGrupoGasto"] = Convert.ToInt32(cboGrupoGasto.SelectedValue);
			drGasto["idTipoGasto"] = Convert.ToInt32(cboTipGasto.SelectedValue);
			drGasto["idMoneda"] = Convert.ToInt32(cboMonGasto.SelectedValue);
			drGasto["nMontoSoles"] = Convert.ToDecimal(txtMontoGasto.Text);
			drGasto["nMontoMonCred"] = Convert.ToDecimal(txtMontoMonCred.Text);
			drGasto["nTipCamFijo"] = nTipCambio;
			drGasto["idTipDocGasto"] = Convert.ToInt32(cboTipDocGasto.SelectedValue);
			drGasto["cTipDocGasto"] = txtTipDocGasto.Text.Trim();
			drGasto["cNroDocumento"] = txtNroDoc.Text;
			drGasto["cDetGasto"] = txtDetGasto.Text;
			drGasto["cDocSustento"] = cDocumentoSesion;
			drGasto["vDocSustento"] = vDocumentoSesion;
			drGasto["cExtDoc"] = cExtension;
			drGasto["idAgencia"] = Convert.ToInt32(cboAgencias.SelectedValue);
			drGasto["dFechaReg"] = clsVarGlobal.dFecSystem.Date;
			drGasto["idUsuario"] = clsVarGlobal.User.idUsuario;
			drGasto["lVigente"] = 1;

		}

		private void HabilitarControles(bool lHabil)
		{
			cboMonGasto.Enabled = lHabil;
			cboTipGasto.Enabled = lHabil;
			cboTipDocGasto.Enabled = lHabil;
			txtTipDocGasto.Enabled = false;
			txtMontoGasto.Enabled = lHabil;
			txtNroDoc.Enabled = lHabil;
			txtDetGasto.Enabled = lHabil;
			btnAddDoc.Enabled = lHabil;
			btnFiltroGastos.Enabled = !lHabil;
			btnMiniDescargar.Enabled = !lHabil;
			dtpFecIni.Enabled = !lHabil;
			dtpFecFin.Enabled = !lHabil;
		}

		private void CalcularCambioMonto()
		{
			if (!string.IsNullOrEmpty(txtMontoGasto.Text))
			{
				decimal nMonto = 0M;
				decimal.TryParse(txtMontoGasto.Text, out nMonto);
				txtMontoGasto.Text = string.Format("{0:#,0.00}", nMonto);
				if (Convert.ToInt16(cboMoneda.SelectedValue) != Convert.ToInt16(cboMonGasto.SelectedValue))
				{
					if (Convert.ToInt16(cboMonGasto.SelectedValue) == 1)
					{
						txtMontoMonCred.Text = string.Format("{0:#,0.00}", (nTipCambio > 0) ? (nMonto / nTipCambio) : 0);
					}
					else
					{
						txtMontoMonCred.Text = string.Format("{0:#,0.00}", (nTipCambio > 0) ? (nMonto * nTipCambio) : 0);
					}
				}
				else
				{
					txtMontoMonCred.Text = string.Format("{0:#,0.00}", nMonto);
				}
			}
		}

		private void CalcularTotal()
		{
			decimal nTotal = 0M;

			nTotal = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
											.Sum(x => Convert.ToDecimal(x.Cells["nMontoMonCred"].Value));
			txtTotalGastos.Text = string.Format("{0:#,0.00}",nTotal);
		}

		#endregion

	}
}
