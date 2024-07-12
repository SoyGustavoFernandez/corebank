using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CAJ.Presentacion
{
    public partial class frmCargaBancos : frmBase
    {
        string hoja = "MovBco";
        private DataTable tmpdtImpDatBco = new DataTable();
        DataTable dtImpDatBco = null;
        clsCNMovimientoBanco objBco = new clsCNMovimientoBanco();
        Boolean lCarga = false;
        Boolean lActualiza = false;
        int pidCuentaInstitucion = 0;
        public frmCargaBancos()
        {
            InitializeComponent();
        }

        private void btnImportar1_Click(object sender, EventArgs e)
        {
           //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
           OpenFileDialog dialog = new OpenFileDialog();
           dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
           //solo los archivos excel
 
           dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
 
           dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
 
           //si al seleccionar el archivo damos Ok
           if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               //el nombre del archivo sera asignado al textbox
               txtArchivo.Text = dialog.FileName;
               LLenarGrid(txtArchivo.Text,hoja); //se manda a llamar al metodo
 
               dtgCargaBco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
               //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
           }      
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            DataSet dsDetalle = null;
            Cursor = Cursors.WaitCursor;

            Excel.Application oExcel = new Excel.Application();
            Excel.Workbook oWorkBook = oExcel.Workbooks.Open(archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Excel.Worksheet oWorkSheet = (Excel.Worksheet)oWorkBook.Worksheets.get_Item(1);

            int i = 2;
            String Fecha, Descripcion, Monto, NroOpe, UTC, idSocio;

            bool lIndValCelda = true;

            while (lIndValCelda)
            {
                Fecha = Convert.ToString((oWorkSheet.Cells[i, 1] as Excel.Range).Value2);
                Descripcion = Convert.ToString((oWorkSheet.Cells[i, 2] as Excel.Range).Value2);
                Monto = Convert.ToString((oWorkSheet.Cells[i, 3] as Excel.Range).Value2);
                NroOpe = Convert.ToString((oWorkSheet.Cells[i, 4] as Excel.Range).Value2);
                UTC = Convert.ToString((oWorkSheet.Cells[i, 5] as Excel.Range).Value2);
                idSocio = Convert.ToString((oWorkSheet.Cells[i, 6] as Excel.Range).Value2);
                if (string.IsNullOrEmpty(Fecha))
                {
                    lIndValCelda = false;
                }
                else
                {
                    tmpdtImpDatBco.Rows.Add(Fecha, Descripcion, Monto, NroOpe, UTC, idSocio);
                }
                i = i + 1;
            }

            oWorkBook.Close(true, null, null);
            oExcel.Quit();
            liberarObjecto(oWorkSheet);
            liberarObjecto(oWorkBook);
            liberarObjecto(oExcel);

            dsDetalle = new DataSet(); // creamos la instancia del objeto DataSet
            dsDetalle.Tables.Add(tmpdtImpDatBco);
 
            ActualizaDatos(dsDetalle);
            lCarga = true;
            btnGrabar.Enabled = true;

            Cursor = Cursors.Default;

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
                MessageBox.Show("No se puede liberar el objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = GetIDProcces("EXCEL");

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

        private int GetIDProcces(string nameProcces)
        {
            try
            {
                System.Diagnostics.Process[] asProccess = System.Diagnostics.Process.GetProcessesByName(nameProcces);

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
        private void ActualizaDatos(DataSet dsImpDatBco)
        {
            string XmlDetalle = "";
            XmlDetalle = dsImpDatBco.GetXml();
            XmlDetalle = clsCNFormatoXML.EncodingXML(XmlDetalle);
            dtImpDatBco = objBco.CNTransMovBco(XmlDetalle);
            
            //dtImpDatBco.Columns["lEstado"].ReadOnly = false;
            dtImpDatBco.Columns["idIdentifica"].ReadOnly = false;
            dtImpDatBco.Columns["idCli"].ReadOnly = false;
            dtImpDatBco.Columns["cDocume"].ReadOnly = false;
            dtImpDatBco.Columns["idTipoDestino"].ReadOnly = false;
            dtImpDatBco.Columns["lEstado"].ReadOnly = false;
            dtImpDatBco.Columns["cNomCli"].ReadOnly = false;

            dtgCargaBco.DataSource = dtImpDatBco; //le asignamos al DataGridView el contenido del dataSet
            //dtgCargaBco.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega

            dtgCargaBco.ReadOnly = false;
            dtgCargaBco.Columns["lEstado"].ReadOnly = false;
            dtgCargaBco.Columns["dFecha"].ReadOnly = true;
            dtgCargaBco.Columns["cDescripcion"].ReadOnly = true;
            dtgCargaBco.Columns["cNroOpe"].ReadOnly = true;
            dtgCargaBco.Columns["cUTC"].ReadOnly = true;
            dtgCargaBco.Columns["nMonto"].ReadOnly = true;
        }

        private void frmCargaBancos_Load(object sender, EventArgs e)
        {
            cboMotOperacionBco.cargarMotivoOperacion(0);
            cargarTipoOperMovBanco();
            cargarTipoDocumento();
            cargarTipoIdentificado();
            CargarTipoPago();

            tmpdtImpDatBco.Columns.Add("Fecha", typeof(String));
            tmpdtImpDatBco.Columns.Add("Descripcion", typeof(String));
            tmpdtImpDatBco.Columns.Add("Monto", typeof(Decimal));
            tmpdtImpDatBco.Columns.Add("NroOpe", typeof(String));
            tmpdtImpDatBco.Columns.Add("UTC", typeof(String));
            tmpdtImpDatBco.Columns.Add("idSocio", typeof(String));
        }

        private void cargarTipoOperMovBanco()
        {
            DataTable dtTipoOpeMovBco = objBco.listarTipoOperMovBanco();
            cboTipoMotOpeBco.DataSource = dtTipoOpeMovBco;
            cboTipoMotOpeBco.ValueMember = "idTipOpeMovBco";
            cboTipoMotOpeBco.DisplayMember = "cTipoOperacion";
        }

        private void cargarTipoDocumento()
        {
            cboTipoDocumentoBco.DataSource = objBco.ListarTipoDocumentoBanco();
            cboTipoDocumentoBco.DisplayMember = "cDescripcion";
            cboTipoDocumentoBco.ValueMember = "idTipoDocBco";
        }

        private void cargarTipoIdentificado()
        {
            cboTipoOperacionBco.DataSource = objBco.CNListarTiposIdentificadosBanco();
            cboTipoOperacionBco.DisplayMember = "cDescripcion";
            cboTipoOperacionBco.ValueMember = "idTipoOpeBco";
        }

        private void CargarTipoPago()
        {
            GEN.CapaNegocio.clsCNTipoPago objTipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable ListaTipoPago = objTipoPago.CNListaTipPagOpeBanco();
            cboTipoPago.DataSource = ListaTipoPago;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";
        }
        private void cboTipoOperacionBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOperacionBco.SelectedIndex != -1)
            {
                if (cboTipoOperacionBco.SelectedValue.ToString() == "2" && btnGrabar.Enabled == true)
                {
                    cboTipoDestino.SelectedValue = 0;
                    cboTipoDestino.Enabled = false;
                    btnBusquedaDestino.Enabled = false;
                }
                else if (cboTipoOperacionBco.SelectedValue.ToString() == "1" && grbDatosMovimiento.Enabled == true)
                {
                    if (dtImpDatBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "1")//transaccion de ingreso
                    {
                        cboTipoDestino.SelectedValue = 2;
                    }
                    else if (dtImpDatBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "2")//transaccion de Egreso
                    {
                        cboTipoDestino.SelectedValue = 1;
                    }
                    if (btnGrabar.Enabled == true)
                    {
                        cboTipoDestino.Enabled = true;
                    }
                    btnBusquedaDestino.Enabled = true;
                }
            }
            Actualiza();
        }

        private void btnBusquedaDestino_Click(object sender, EventArgs e)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            if (!string.IsNullOrEmpty(cliente.pcCodCli))
            {
                txtCodigo.Text = cliente.pcCodCli;
                txtCliente.Text = cliente.pcNomCli;
                Actualiza();                
            }
        }

        private Boolean Validar()
        {
            return false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            if (Validar())
            {
                return;
            }
            DataTable dtSaldos = new DataTable();
            for (int i = 0; i < dtImpDatBco.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtImpDatBco.Rows[i]["lEstado"]))
                {
                    dtSaldos = objBco.grabarMovimientoBancos(convertXml(i), dtpfechaOperac.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.nIdAgencia, Convert.ToInt16(dtImpDatBco.Rows[i]["lEstado"]));
                }
            }
            MessageBox.Show("Movimiento Grabado Correctamente", "Movimiento Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private string convertXml(int fila)
        {
            int idCliente = 0, idMotOpeBanco = 0, idTipOpeMovBco = 0;
            int idTipMedPago = 0, idTipoDocumento = 0, idTipoOperaBco = 0, idTipoDestino = 0;
            decimal nMontoOpera;
            DateTime dfechaOpe;
            string cDescripcion, cNroDocumento, cNroConciliaBcos;
            int nTipMovCapInt, idTipoPago;

            dfechaOpe = Convert.ToDateTime(dtImpDatBco.Rows[fila]["dFecha"]);
            cDescripcion = Convert.ToString(dtImpDatBco.Rows[fila]["cDescripcion"]);
            nMontoOpera = Convert.ToDecimal(dtImpDatBco.Rows[fila]["nMonto"]);
            idMotOpeBanco = Convert.ToInt16(dtImpDatBco.Rows[fila]["idMotOpeBanco"]);
            idTipMedPago = Convert.ToInt16(dtImpDatBco.Rows[fila]["idTipMedPago"]);
            idTipoDocumento = Convert.ToInt16(dtImpDatBco.Rows[fila]["idTipoDocumento"]);
            idTipOpeMovBco = Convert.ToInt16(dtImpDatBco.Rows[fila]["idTipOpeMovBco"]);
            idTipoPago = Convert.ToInt16(dtImpDatBco.Rows[fila]["idTipoPago"]);
            idCliente=Convert.ToInt16(dtImpDatBco.Rows[fila]["idCli"]);;
            cNroDocumento = Convert.ToString(dtImpDatBco.Rows[fila]["cDocume"]);
            cNroConciliaBcos = Convert.ToString(dtImpDatBco.Rows[fila]["cNroOpe"]);
            idTipoOperaBco = Convert.ToInt16(dtImpDatBco.Rows[fila]["idIdentifica"]);

            idTipoDestino = Convert.ToInt16(dtImpDatBco.Rows[fila]["idTipoDestino"]);

            nTipMovCapInt = 1;
            string xmlMovimiento = clsCNFormatoXML.EncodingXML(objBco.convertMovimientoXml(-1, pidCuentaInstitucion, idMotOpeBanco, idTipOpeMovBco, idTipMedPago, nMontoOpera, idTipoOperaBco, idTipoDestino, idCliente, cDescripcion, dfechaOpe, idTipoDocumento, cNroDocumento, nTipMovCapInt, idTipoPago, cNroConciliaBcos));
            return xmlMovimiento;
        }


        private void cboMotOperacionBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void Actualiza()
        {
            if (lCarga  && lActualiza)
            {
                Int32 fila = Convert.ToInt32(this.dtgCargaBco.CurrentRow.Index);
                dtImpDatBco.Rows[fila]["cDescripcion"] = txtConcepto.Text;
                dtImpDatBco.Rows[fila]["idMotOpeBanco"] = cboMotOperacionBco.SelectedValue;
                dtImpDatBco.Rows[fila]["idTipMedPago"] = cboMedioPagoSunat.SelectedValue;
                dtImpDatBco.Rows[fila]["idTipoDocumento"] = cboTipoDocumentoBco.SelectedValue;
                dtImpDatBco.Rows[fila]["idIdentifica"] = cboTipoOperacionBco.SelectedValue;
                dtImpDatBco.Rows[fila]["idTipoPago"] = cboTipoPago.SelectedValue;
                dtImpDatBco.Rows[fila]["idCli"] = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text);
                dtImpDatBco.Rows[fila]["cNomCli"] = string.IsNullOrEmpty(txtCliente.Text) ? "" : txtCliente.Text;
                dtImpDatBco.Rows[fila]["cDocume"] = txtDocumento.Text;
                dtImpDatBco.Rows[fila]["cNroOpe"] = txtNroConciliaBco.Text;
                dtImpDatBco.Rows[fila]["idTipoDestino"] = Convert .ToInt32(cboTipoOperacionBco.SelectedValue) == 1 ? 0 : cboTipoOperacionBco.SelectedValue;
            }
        }

        private void cboMedioPagoSunat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void cboTipoMotOpeBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void cboTipoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void cboTipoDocumentoBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNroConciliaBco_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtConcepto_Validated(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst buscar = new frmBusquedaCuentaInst();
            buscar.ShowDialog();
            if (buscar.pidCuentaInstitucion == 0) return;
            txtNroCuenta.Text = buscar.pcNumeroCuenta;
            pidCuentaInstitucion = buscar.pidCuentaInstitucion;
            cboMoneda1.SelectedValue = buscar.pidMoneda;
            btnImportar1.Enabled = true;

        }

        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            Actualiza();

        }

        private void txtNroConciliaBco_Validated(object sender, EventArgs e)
        {
            Actualiza();

        }

        private void dtgCargaBco_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgCargaBco.Rows.Count > 0)
            {
                lActualiza = false;

                Int32 fila = Convert.ToInt32(this.dtgCargaBco.CurrentRow.Index);
                dtpfechaOperac.Value = Convert.ToDateTime(dtgCargaBco.Rows[fila].Cells["dFecha"].Value);
                txtConcepto.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["cDescripcion"].Value);
                txtMontoOperac.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["nMonto"].Value);
                cboTipoMotOpeBco.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idTipOpeMovBco"].Value);
                cboMotOperacionBco.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idMotOpeBanco"].Value);
                cboMedioPagoSunat.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idTipMedPago"].Value);
                cboTipoDocumentoBco.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idTipoDocumento"].Value);
                cboTipoOperacionBco.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idIdentifica"].Value);
                cboTipoPago.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idTipoPago"].Value);
                txtDocumento.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["cDocume"].Value);
                txtNroConciliaBco.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["cNroOpe"].Value);
                txtCodigo.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["idCli"].Value);
                txtCliente.Text = Convert.ToString(dtgCargaBco.Rows[fila].Cells["cNomCli"].Value);
                cboTipoDestino.SelectedValue = Convert.ToInt32(dtgCargaBco.Rows[fila].Cells["idTipoDestino"].Value);

                lActualiza = true;
            }
        }

        private void cboTipoPago_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 || Convert.ToInt32(cboTipoPago.SelectedValue) == 6)
            {
                cboTipoDocumentoBco.SelectedValue = 2;
            }
            else
            {
                cboTipoDocumentoBco.SelectedValue = 1;
            }
        }
    }
}
