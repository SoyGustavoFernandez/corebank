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
using GEN.LibreriaOffice;
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmPagosMasivoCredito : frmBase
    {
        #region Atributos
        private OpenFileDialog OpenDialog;
        private DataTable dtCreditosExcel;
        string[] cColumnas = new string[] { "IDORDEN", "IDCUENTA", "IDMONEDA", "MONTO A PAGAR", "TIPO DOC TITULAR", "NRO DOCUMENTO TITULAR", "ESTADO" };
        string[] cColumnasAdicionales = new string[] { "ACCION PAGO MASIVO CUENTA", "MONEDA CORRECTA", "MONEDA"};
        bool lCargaCorrecta = true;
        private int idPagoMasivo;
        #endregion

        #region Metodos Públicos
        public frmPagosMasivoCredito()
        {
            InitializeComponent();
            OpenDialog = new OpenFileDialog();
            dtpCorto1.Value = clsVarGlobal.dFecSystem;
            ControlFormulario(EventoFormulario.INICIO);
        }

        public void LimpiarFormulario()
        {
            cboTipoPagoMasivo1.SelectedIndexChanged -= cboTipoPagoMasivo1_SelectedIndexChanged;

            conBusCol1.LimpiarDatos();
            cboMoneda1.SelectedIndex = -1;
            cboTipoPagoMasivo1.SelectedIndex = -1;
            conPagoBcos.LimpiarControles();
            conPagoBcos.Visible = false;

            if (dtgCreditosParaPago.DataSource != null)
            {
                ((DataTable)dtgCreditosParaPago.DataSource).Clear();
                dtgCreditosParaPago.Update();
            }

            dtgCreditosParaPago.Columns.Clear();
            OpenDialog.FileName = null;

            cboTipoPagoMasivo1.SelectedIndexChanged += cboTipoPagoMasivo1_SelectedIndexChanged;
            this.idPagoMasivo = 0;
            this.ImprimirResultadoFinal();
            this.txtCuentaNoExistente.Clear();          
            this.txtPagar.Clear();
            this.txtPagarySobrante.Clear();
            this.txtTotal.Clear();
            this.conBusCol1.Reset();
        }

        public bool ValidarDatos()
        {
            if (!conBusCol1.ValidarColaboradorSeleccionado())
            {
                MessageBox.Show("No se ha seleccionado al Colaborador Ordenante de la Operación", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conBusCol1.Focus();
                return false;
            }

            if (cboMoneda1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la moneda del proceso de Pago Masivo", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMoneda1.Focus();
                return false;
            }

            if (cboTipoPagoMasivo1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Pago Masivo", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoPagoMasivo1.Focus();
                return false;
            }

            int idTipoPagoMasivo = 0;

            idTipoPagoMasivo = Convert.ToInt32(cboTipoPagoMasivo1.SelectedValue);
            DataRow dRow = ((DataRowView)cboTipoPagoMasivo1.SelectedItem).Row;
            if (Convert.ToBoolean(dRow["lDatosBanco"]))
            {
                if (!conPagoBcos.ValidarPagoBcos())
                {
                    MessageBox.Show("Se debe seleccionar y registrar el bloque de Detalle Medio de Pago (Entidad, Cuenta y Nro. Operación) ", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conPagoBcos.Focus();
                    return false;
                }
            }
            return true;
        }

        public bool ValidarFormulario()
        {
            if (!this.ValidarDatos())
                return false;

            if (!ValidarCargaExcel())
                return false;

            if (!this.lCargaCorrecta)
            {
                MessageBox.Show("Se ha identificado cuentas canceladas, no existen en el sistema y/o créditos con moneda diferente del Pago Masivo, favor de corregir dichas cuentas y volver a cargar el Excel", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnImportar.Focus();
                return false;
            }

            return true;
        }

        public bool ValidarCargaExcel()
        {
            if (cboMoneda1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la moneda del proceso de Pago Masivo", "Pago Masivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMoneda1.Focus();
                return false;
            }

            return true;
        }

        public bool ValidarCuenta()
        {
            return true;
        }

        #endregion

        #region Metodos Privados       

        private string ValidarHojaVacia(DataTable dtExcel)
        {
            string rpta = "";
            if (dtExcel.Rows.Count == 0)
            {
                rpta = "fallo";
            }
            return rpta;
        }

        private void CargarExcel()
        { 
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();

            if (!ValidarCargaExcel())
                return;
            
            if (String.IsNullOrEmpty(OpenDialog.FileName))
            {
                return;
            }
                      
            try
            {
                ExcelHandler exHandler = new ExcelHandler();
                dtCreditosExcel = exHandler.ImportExcelToDataTable(this.OpenDialog.FileName, "Pagos");

                foreach (DataRow row in dtCreditosExcel.Rows) 
                {
                    if (row["IDORDEN"].ToString() == "" && row["IDCUENTA"].ToString() == "" && row["IDMONEDA"].ToString() == "" && row["MONTO A PAGAR"].ToString() == "" && row["TIPO DOC TITULAR"].ToString() == "" && row["NRO DOCUMENTO TITULAR"].ToString() == "")
                    {
                        row.Delete();
                    }
                }

                string rpta = "";
                foreach (DataRow row in dtCreditosExcel.Rows) 
                {                  
                    if (row["NRO DOCUMENTO TITULAR"].ToString() == "" || cboMoneda1.SelectedValue.ToString() != row["IDMONEDA"].ToString()) 
                    {
                        rpta = "error";                     
                    }                              
                }

                if (rpta != "")
                {
                    MessageBox.Show("Inconsistencia de datos en 'Hoja Excel'. ¡Verificar!", "Pago Masivo de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                dtCreditosExcel.Columns.Add("ESTADO", typeof(string));
                dtCreditosExcel.Columns.Add("MONEDA", typeof(string));
                              
                if (ValidarExcel())
                {
                    if (ValidarHojaVacia(dtCreditosExcel) != "")
                    {
                        MessageBox.Show("Inconsistencia de datos en 'Hoja Excel'. ¡Verificar!", "Pago Masivo de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dtgCreditosParaPago.DataSource = this.AgregarMoneda(dtCreditosExcel);
                        FormatoGridCreditosParaPagar();
                        ImprimirResultadoFinal();
                    }
                }
                                         
                ControlFormulario(EventoFormulario.NUEVO);
            }
            catch (Exception e)
            {
                MessageBox.Show("Inconsistencia de datos en 'Hoja Excel'. ¡Verificar!", "Pago Masivo de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //LimpiarFormulario();
            }
        }

        private DataTable AgregarMoneda(DataTable dtExcel)
        {
            foreach (DataRow item in dtExcel.Rows)
            {
                item["MONEDA"] = (Convert.ToInt32((item["IDMONEDA"]== DBNull.Value)?0:item["IDMONEDA"]) == 1) ? "SOLES" : "DÓLARES";
            }
            return dtExcel;
        }

        private bool ValidarExcel()
        {
            ExcelHandler exHandler = new ExcelHandler();
            ClsResponse DResp = exHandler.ValidaCamposObligatorios(this.cColumnas, this.dtCreditosExcel);
            if (DResp.idRespuesta == 0)
            {
                MessageBox.Show("Excel no contiene las siguientes columnas obligatorias : \n " + DResp.cMensaje, "Faltan Columnas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidaAsignaAccionCuentasCredito())
            {
                return false;
            }

            return true;
        }

        private bool ValidaAsignaAccionCuentasCredito()
        {
            DataSet dsCred = new DataSet("dsCreditos");
            this.dtCreditosExcel.TableName = "dtCreditos";
            dsCred.Tables.Add(this.dtCreditosExcel);
            string cCreditos = dsCred.GetXml();
            clsCNCredito objCredito = new clsCNCredito();
            this.dtCreditosExcel = objCredito.CNValidacionCuentasPagoMasivo(cCreditos, Convert.ToInt32(cboMoneda1.SelectedValue));
            dtCreditosExcel.Columns.Add("ESTADO", typeof(string));
            dtCreditosExcel.Columns.Add("MONEDA", typeof(string));
            return true;

        }

        private void ControlFormulario(EventoFormulario nEvento)
        {
            switch (nEvento)
            {
                case EventoFormulario.INICIO:
                case EventoFormulario.CANCELAR:
                    conBusCol1.Enabled = true;
                    cboMoneda1.Enabled = true;
                    cboTipoPagoMasivo1.Enabled = true;
                    conPagoBcos.Enabled = true;
                    dtgCreditosParaPago.Enabled = true;
                    btnImportar.Enabled = true;
                    btnImprimir1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar.Enabled = false;
                    break;
                case EventoFormulario.NUEVO:
                    conBusCol1.Enabled = true;
                    cboMoneda1.Enabled = true;
                    cboTipoPagoMasivo1.Enabled = true;
                    conPagoBcos.Enabled = true;
                    dtgCreditosParaPago.Enabled = true;
                    btnImportar.Enabled = true;
                    btnImprimir1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar.Enabled = lCargaCorrecta;
                    break;
                case EventoFormulario.GRABAR:
                    conBusCol1.Enabled = false;
                    cboMoneda1.Enabled = false;
                    cboTipoPagoMasivo1.Enabled = false;
                    conPagoBcos.Enabled = false;
                    dtgCreditosParaPago.Enabled = false;
                    btnImportar.Enabled = false;
                    btnImprimir1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ImprimirResultadoFinal()
        {
            decimal nIngreso = 0m;
            decimal nPagoIngreso = 0m;
            decimal nPagar = 0m;
            decimal nError = 0m;

            this.lCargaCorrecta = true;

            foreach (DataGridViewRow item in this.dtgCreditosParaPago.Rows)
            {
                switch (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value))
                {
                    case 0:
                        item.DefaultCellStyle.ForeColor = lblError.BackColor;
                        nError += (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value) == 0) ? Convert.ToDecimal(item.Cells["MONTO A PAGAR"].Value) : 0m;
                        this.lCargaCorrecta = false;                        
                        break;
                    case 1:                                       
                    case 2:
                    case 3:
                        item.DefaultCellStyle.ForeColor = lblCorrecto.BackColor;
                        //nIngreso += (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value) == 3) ? Convert.ToDecimal(item.Cells["MONTO A PAGAR"].Value) : 0m;
                        nPagoIngreso += (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value) == 2) ? Convert.ToDecimal(item.Cells["MONTO A PAGAR"].Value) : 0m;
                        nPagar += (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value) == 1) ? Convert.ToDecimal(item.Cells["MONTO A PAGAR"].Value) : 0m;
                        break;
                    default:
                        item.DefaultCellStyle.ForeColor = lblError.BackColor;
                        this.lCargaCorrecta = false;
                        nError += (Convert.ToInt32(item.Cells["idAccionPagoMasivoCuenta"].Value) == 4) ? Convert.ToDecimal(item.Cells["MONTO A PAGAR"].Value) : 0m;
                        break;
                }
            }
        
            if (nError > 0)
            {
                txtCuentaNoExistente.ForeColor = lblError.BackColor;
                txtCuentaNoExistente.BackColor = Color.MistyRose;
                lblCuentaNoExiste.ForeColor = lblError.BackColor;

            }
            else 
            {
                txtCuentaNoExistente.ForeColor = SystemColors.WindowText;
                txtCuentaNoExistente.BackColor = SystemColors.Control;
                lblCuentaNoExiste.ForeColor = Color.Navy;
            }
            
            txtPagarySobrante.Text = nPagoIngreso.ToString("N2");
            txtPagar.Text = nPagar.ToString("N2");
            txtCuentaNoExistente.Text = nError.ToString("N2");
            txtTotal.Text = (nIngreso + nPagoIngreso + nPagar + nError).ToString("N2");
            txtTotalCuentas.Text = (dtgCreditosParaPago.Rows.Count).ToString();
        }

        private void FormatoGridCreditosParaPagar()
        {
            foreach (DataGridViewColumn dtgColumna in dtgCreditosParaPago.Columns)
            {
                dtgColumna.Visible = false;
                dtgColumna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (string cColumna in cColumnas)
	        {
                dtgCreditosParaPago.Columns[cColumna].Visible = true;
	        }

            foreach (string cColumna in cColumnasAdicionales)
	        {
                dtgCreditosParaPago.Columns[cColumna].Visible = true;
	        }

            dtgCreditosParaPago.Columns["ACCION PAGO MASIVO CUENTA"].FillWeight = 180;
            dtgCreditosParaPago.Columns["MONEDA"].DisplayIndex = 8;
            dtgCreditosParaPago.Columns["IDMONEDA"].Visible = false;
            dtgCreditosParaPago.Columns["IDORDEN"].FillWeight = 70;
        }

        private void ProcesarPagos()
        {
            conPagoBcos.CargaResultado();

            if (!ValidarFormulario())
                return;

            DataSet dsCreditos = new DataSet("dsCreditos");
            this.dtCreditosExcel.TableName = "dtCreditos";
            dsCreditos.Tables.Add(this.dtCreditosExcel);
            string cCreditos = dsCreditos.GetXml(),
                    cNroOperacion   = conPagoBcos.cNroTrx;
            int idTipoPagoMasivo    = Convert.ToInt32(cboTipoPagoMasivo1.SelectedValue),
                 idUsuarioOrden     = Convert.ToInt32(conBusCol1.idUsu), 
                 idAgencia          = clsVarGlobal.nIdAgencia,     
                 idUsuarioReg       = clsVarGlobal.User.idUsuario,
                 idEntidad          = conPagoBcos.idEntidad,
                 idCuenta           = conPagoBcos.idCuenta;
            DateTime dFechaSistema  = clsVarGlobal.dFecSystem;
            byte[] bExcel           = new byte[0];

            clsCNCredito objCredito = new clsCNCredito();
            DataSet dsProcesado = objCredito.CNProcesarPagoMasivo(cCreditos, idTipoPagoMasivo, idUsuarioOrden, idAgencia, idUsuarioReg, dFechaSistema, bExcel, idEntidad, idCuenta, cNroOperacion);

            if (Convert.ToInt32(dsProcesado.Tables[0].Rows[0]["nResultado"]) == 0)
            {
                MessageBox.Show(dsProcesado.Tables[0].Rows[0]["cMensaje"].ToString(), "Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            this.ActualizarEstadoCarga(dsProcesado.Tables[1]);
            this.dtgCreditosParaPago.DataSource = this.dtCreditosExcel;
            this.FormatoGridCreditosParaPagar();
            this.idPagoMasivo = Convert.ToInt32(dsProcesado.Tables[1].Rows[0]["idPagoMasivo"]);

            ControlFormulario(EventoFormulario.GRABAR);

             if (Convert.ToInt32(dsProcesado.Tables[0].Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show(dsProcesado.Tables[0].Rows[0]["cMensaje"].ToString(), "Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ActualizarEstadoCarga(DataTable dtMerge)
        { 
            foreach (DataRow item in dtCreditosExcel.Rows)
	        {
                item["ESTADO"] = BuscarEstadoMerge(dtMerge, Convert.ToInt32(item["IDCUENTA"]), Convert.ToDecimal(item["MONTO A PAGAR"]));
	        }
            
        }

        private string BuscarEstadoMerge(DataTable dtMerge, int idCuenta, decimal nMontoPagar)
        {
            string cEstDetPagoMasivo ="";
            foreach (DataRow item in dtMerge.Rows)
            {
                if (Convert.ToInt32(item["idCuenta"]) == idCuenta && Convert.ToDecimal(item["nMontoPago"]) == nMontoPagar)
                {
                    cEstDetPagoMasivo = Convert.ToString(item["cEstDetPagoMasivo"]);
                }
            }
            return cEstDetPagoMasivo;
        }

        #endregion 

        #region Eventos
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            frmReportePagosMasivos frm = new frmReportePagosMasivos(this.idPagoMasivo);
        }

        private void frmPagosMasivoCredito_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            LimpiarFormulario();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            CargarExcel();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult dRes = MessageBox.Show("¿Desea procesar los créditos?", "Pagos Masivos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRes != DialogResult.Yes)
            {
                return;
            }
            ProcesarPagos();     
        }

        private void cboTipoPagoMasivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoPagoMasivo = 0;

            idTipoPagoMasivo = Convert.ToInt32(cboTipoPagoMasivo1.SelectedValue);
            DataRow dRow = ((DataRowView)cboTipoPagoMasivo1.SelectedItem).Row;
            if (Convert.ToBoolean(dRow["lDatosBanco"]))
            {
                conPagoBcos.Visible = true;
                conPagoBcos.LimpiarControles();
                conPagoBcos.CargaEntidadMoneda(Convert.ToInt32(dRow["idTipoPago"]), Convert.ToInt32(cboMoneda1.SelectedValue));
            }
            else
            {
                conPagoBcos.Visible = false;
            }

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();           
            ControlFormulario(EventoFormulario.CANCELAR);
        }
        #endregion
    }
}
