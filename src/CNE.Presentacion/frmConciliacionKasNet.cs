using CNE.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmConciliacionKasNet : frmBase
    {
        class clsPagos
        {
            public int idCuenta { get; set; }
            public decimal nMonto { get; set; }
        }

        public frmConciliacionKasNet()
        {
            InitializeComponent();
            this.CargarComboArchivosSubidos();
        }

        private void CargarComboArchivosSubidos()
        {
            DataTable dtCargaArchivoSubido = new DataTable();
            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();
            DateTime dFechaCarga = this.dtpFechaCarga.Value.Date;

            dtCargaArchivoSubido = objCNConciliacionKasNet.CNListarCargaArchivoFecha(dFechaCarga);            

            this.cboCargaArchivo.DataSource = dtCargaArchivoSubido;
            this.cboCargaArchivo.ValueMember = "idAPICargaConciTransacKasNet";
            this.cboCargaArchivo.DisplayMember = "cNombreCarga";            
        }

        private void CargarComboArchivosSubidosConci()
        {
            DataTable dtCargaArchivoSubido = new DataTable();
            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();
            DateTime dFechaCarga = this.dtpFechaCargaConci.Value.Date;

            dtCargaArchivoSubido = objCNConciliacionKasNet.CNListarCargaArchivoFecha(dFechaCarga);            

            this.cboCargaArchivoConci.DataSource = dtCargaArchivoSubido;
            this.cboCargaArchivoConci.ValueMember = "idAPICargaConciTransacKasNet";
            this.cboCargaArchivoConci.DisplayMember = "cNombreCarga";
        }

        private void CargarDtgPagosKasNet()
        {            
            DataTable dtPagosKasNet = new DataTable();
            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();
            int idCargaArcSub = (int)this.cboCargaArchivo.SelectedValue;

            dtPagosKasNet = objCNConciliacionKasNet.CNListarPagosCarga(idCargaArcSub);

            this.dtgCargaListPagosKasNet.DataSource = dtPagosKasNet;
            this.dtgCargaListPagosKasNet.Refresh();
            this.dtgCargaListPagosKasNet.ClearSelection();
        }

        private void CargarDtgPagosConciCoreKasNet()
        {
            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();

            DataTable dtPagosConciKasNet = new DataTable();            
            int idCargaArcSub = (int)this.cboCargaArchivoConci.SelectedValue;
            
            DataTable dtPagosCoreKasNet = new DataTable();            
            DateTime dtFechaPago = this.dtpFechaCargaConci.Value;            

            dtPagosConciKasNet = objCNConciliacionKasNet.CNListarPagosConci(idCargaArcSub);
            dtPagosCoreKasNet = objCNConciliacionKasNet.CNListarPagosCore(dtFechaPago.Date);

            //Validacion de idCuenta y Montos
            List<clsPagos> ListPagosConci = new List<clsPagos>();
            List<clsPagos> BlackListPagosConci = new List<clsPagos>();
            List<clsPagos> ListPagosCore = new List<clsPagos>();
            List<clsPagos> BlackListPagosCore = new List<clsPagos>();
            int index = 0;
            
            foreach (DataRow Row in dtPagosConciKasNet.Rows)
            {
                if (Row[1].ToString() == "P")
                {
                    if (ListPagosConci.Exists(x => x.idCuenta == Convert.ToInt32(Row[2].ToString())))
                    {
                        index = ListPagosConci.FindIndex(x => x.idCuenta == Convert.ToInt32(Row[2].ToString()));
                        ListPagosConci[index].nMonto = ListPagosConci[index].nMonto + Convert.ToDecimal(Row[4].ToString());
                    }
                    else
                    {
                        ListPagosConci.Add(new clsPagos() { idCuenta = Convert.ToInt32(Row[2].ToString()), nMonto = Convert.ToDecimal(Row[4].ToString()) });
                    }
                }
            }

            foreach (DataRow Row in dtPagosCoreKasNet.Rows)
            {
                if (Convert.ToInt32(Row[8].ToString()) == 1)
                {
                    if (ListPagosCore.Exists(x => x.idCuenta == Convert.ToInt32(Row[1].ToString())))
                    {
                        index = ListPagosCore.FindIndex(x => x.idCuenta == Convert.ToInt32(Row[1].ToString()));
                        ListPagosCore[index].nMonto = ListPagosCore[index].nMonto + Convert.ToDecimal(Row[4].ToString());
                    }
                    else
                    {
                        ListPagosCore.Add(new clsPagos() { idCuenta = Convert.ToInt32(Row[1].ToString()), nMonto = Convert.ToDecimal(Row[4].ToString()) });
                    }
                }
            }

            foreach (var item in ListPagosConci)
            {
                index = ListPagosCore.FindIndex(x => x.idCuenta == item.idCuenta && x.nMonto == item.nMonto);
                if (index < 0)
                {
                    BlackListPagosConci.Add(item);
                }
            }

            foreach (var item in ListPagosCore)
            {
                index = ListPagosConci.FindIndex(x => x.idCuenta == item.idCuenta && x.nMonto == item.nMonto);
                if (index < 0)
                {
                    BlackListPagosCore.Add(item);
                }
            }
            //-------------

            //-------------
            this.dtgPagosConciKasNet.SelectionChanged -= new System.EventHandler(this.dtgPagosConciKasNet_SelectionChanged);            

            int nCantidadConci = 0;
            decimal nTotalConci = 0;

            foreach (DataRow Row in dtPagosConciKasNet.Rows)
            {
                if (Row[1].ToString() == "P")
                {
                    nTotalConci += Convert.ToDecimal(Row[4].ToString());
                    nCantidadConci++;
                }
            }

            this.dtgPagosConciKasNet.DataSource = dtPagosConciKasNet;
            this.dtgPagosConciKasNet.Refresh();

            foreach (DataGridViewRow Row in this.dtgPagosConciKasNet.Rows)
            {
                if (Row.Cells["cTipoRegistroConci"].Value.ToString() == "P")
                {
                    if (BlackListPagosConci.Exists(x => x.idCuenta == Convert.ToInt32(Row.Cells["cNroSuministroConci"].Value)))
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Green;
                    }                    
                }
                else if (Row.Cells["cTipoRegistroConci"].Value.ToString() == "E")
                {
                    Row.DefaultCellStyle.ForeColor = Color.Orange;
                }
            }

            this.txtCantidadConci.Text = nCantidadConci.ToString();
            this.txtTotalConci.Text = nTotalConci.ToString();

            this.dtgPagosConciKasNet.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            this.dtgPagosConciKasNet.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dtgPagosConciKasNet.ClearSelection();

            this.dtgPagosConciKasNet.SelectionChanged += new System.EventHandler(this.dtgPagosConciKasNet_SelectionChanged);

            //-------------

            this.dtgPagosCoreKasNet.SelectionChanged -= new System.EventHandler(this.dtgPagosCoreKasNet_SelectionChanged);            

            int nCantidadCore = 0;
            decimal nTotalCore = 0;            

            //Totales Cantidad y Monto
            foreach (DataRow Row in dtPagosCoreKasNet.Rows)
            {
                if (Convert.ToInt32(Row[8].ToString()) == 1)
                {
                    nTotalCore += Convert.ToDecimal(Row[4].ToString());
                    nCantidadCore++;                    
                }
            }
            //-------------

            this.dtgPagosCoreKasNet.DataSource = dtPagosCoreKasNet;
            this.dtgPagosCoreKasNet.Refresh();

            foreach (DataGridViewRow Row in this.dtgPagosCoreKasNet.Rows)
            {
                if (Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 1)
                {
                    if (BlackListPagosCore.Exists(x => x.idCuenta == Convert.ToInt32(Row.Cells["idCuenta"].Value)))
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Green;
                    }                    
                }
                else if (Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 2 || Convert.ToInt32(Row.Cells["idEstadoKardex"].Value) == 4)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Orange;                    
                }
                else
                {
                    Row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            this.txtCantidadCore.Text = nCantidadCore.ToString();
            this.txtTotalCore.Text = nTotalCore.ToString();

            this.dtgPagosCoreKasNet.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            this.dtgPagosCoreKasNet.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dtgPagosCoreKasNet.ClearSelection();

            this.dtgPagosCoreKasNet.SelectionChanged += new System.EventHandler(this.dtgPagosCoreKasNet_SelectionChanged);
        }

        private void btnCargarFile_Click(object sender, EventArgs e)
        {
            String ruta = string.Empty;
            String str = string.Empty;            

            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "TXT files (*.txt)|*.txt";
                openfile1.Title = "Seleccione el archivo de conciliación";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                        str = Path.GetFileNameWithoutExtension(ruta);                        

                        DialogResult result = MessageBox.Show("Está seguro de importar el archivo?", "Conciliación KasNet", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {                            
                            string dsConciliacion = ConvertTXTtoDataTable(ruta);

                            if (dsConciliacion.Length == 0)
                            {
                                MessageBox.Show("No se encontraron datos válidos para la carga. Ingrese otro archivo con el formato y datos correctos.", "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }                            

                            clsCNConciliacionKasNet objCNConciliacionKasNet = new clsCNConciliacionKasNet();
                            DateTime dFechaRegistro = this.dtpFechaCarga.Value;
                            DataTable dtRespuesta = objCNConciliacionKasNet.CNCargarArchivoConciliacion(dFechaRegistro.Date, dsConciliacion);

                            if (dtRespuesta.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtRespuesta.Rows[0]["idRpta"].ToString()) == 1)
                                {
                                    this.CargarComboArchivosSubidos();
                                    MessageBox.Show(dtRespuesta.Rows[0]["cMensage"].ToString(), "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(dtRespuesta.Rows[0]["cMensage"].ToString(), "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error inesperado.", "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        public static string ConvertTXTtoDataTable(string strFilePath)
        {
            string dsXml = string.Empty;

            DataTable dtCab = new DataTable();
            DataTable dtDet = new DataTable();

            int count = 0;

            dtCab.Columns.Add("cTipoRegistro");
            dtCab.Columns.Add("cCodCanal");
            dtCab.Columns.Add("cFechaProceso");
            dtCab.Columns.Add("cCantidadReg");
            dtCab.Columns.Add("cTotalDeudaConvertido");
            dtCab.Columns.Add("cTotalComisionesConvertido");
            dtCab.Columns.Add("cTotalConceptosAdicConvertido");
            dtCab.Columns.Add("cTotalMontosTotalesConvertidos");
            dtCab.Columns.Add("cTipoConciliacion");
            dtCab.Columns.Add("cBlancos");

            dtDet.Columns.Add("cTipoRegistro");
            dtDet.Columns.Add("cNroSuministro");
            dtDet.Columns.Add("cFechaPago");
            dtDet.Columns.Add("cTerminalID");
            dtDet.Columns.Add("cMontoDeudaConvertido");
            dtDet.Columns.Add("cComisionConvertido");
            dtDet.Columns.Add("cTotalConceptosAdicConvetidos");
            dtDet.Columns.Add("cImporteTotalConvertido");
            dtDet.Columns.Add("cNroTransacGKN");
            dtDet.Columns.Add("cNroOperacion");
            dtDet.Columns.Add("cNroFactura");
            dtDet.Columns.Add("cCodEmpresa");
            dtDet.Columns.Add("cCodServicio");		    

            try
            {
                using (StreamReader lector = new StreamReader(strFilePath))
                {
                    while (lector.Peek() > -1)
                    {
                        string linea = lector.ReadLine();
                        if (!String.IsNullOrEmpty(linea))
                        {
                            if (count == 0)
                            {
                                DataRow drCab = dtCab.NewRow();

                                drCab["cTipoRegistro"] = linea.Substring(0, 1);
                                drCab["cCodCanal"] = linea.Substring(1, 3);
                                drCab["cFechaProceso"] = linea.Substring(4, 8);
                                drCab["cCantidadReg"] = linea.Substring(12, 9);
                                drCab["cTotalDeudaConvertido"] = linea.Substring(21, 13);
                                drCab["cTotalComisionesConvertido"] = linea.Substring(34, 13);
                                drCab["cTotalConceptosAdicConvertido"] = linea.Substring(47, 13);
                                drCab["cTotalMontosTotalesConvertidos"] = linea.Substring(60, 13);
                                drCab["cTipoConciliacion"] = linea.Substring(73, 3);
                                drCab["cBlancos"] = linea.Substring(76, 79);

                                dtCab.Rows.Add(drCab);
                            }
                            else
                            {
                                DataRow drDet = dtDet.NewRow();

                                drDet["cTipoRegistro"] = linea.Substring(0, 1);
                                drDet["cNroSuministro"] = linea.Substring(1, 20);
                                drDet["cFechaPago"] = linea.Substring(21, 14);
                                drDet["cTerminalID"] = linea.Substring(35, 8);
                                drDet["cMontoDeudaConvertido"] = linea.Substring(43, 12);
                                drDet["cComisionConvertido"] = linea.Substring(55, 12);
                                drDet["cTotalConceptosAdicConvetidos"] = linea.Substring(67, 12);
                                drDet["cImporteTotalConvertido"] = linea.Substring(79, 12);
                                drDet["cNroTransacGKN"] = linea.Substring(91, 28);
                                drDet["cNroOperacion"] = linea.Substring(119, 10);
                                drDet["cNroFactura"] = linea.Substring(129, 20);
                                drDet["cCodEmpresa"] = linea.Substring(149, 3);
                                drDet["cCodServicio"] = linea.Substring(152, 3);

                                dtDet.Rows.Add(drDet);
                            }
                            
                            count++;
                        }
                    }
                }

                dtCab.TableName = "dtCabecera";
                dtDet.TableName = "dtDetalle";

                DataSet ds = new DataSet("dsConciliacionKasNet");
                ds.Tables.Add(dtCab);
                ds.Tables.Add(dtDet);

                dsXml = ds.GetXml();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dsXml;
        }

        private void dtpFechaCarga_Leave(object sender, EventArgs e)
        {
            this.CargarComboArchivosSubidos();
        }

        private void dtpFechaCargaConci_Leave(object sender, EventArgs e)
        {
            this.CargarComboArchivosSubidosConci();
        }

        private void btnConsultarCarga_Click(object sender, EventArgs e)
        {
            if (this.cboCargaArchivo.GetItemText(this.cboCargaArchivo.SelectedItem) == string.Empty)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarDtgPagosKasNet();
        }

        private void btnConsultarConci_Click(object sender, EventArgs e)
        {
            if (this.cboCargaArchivoConci.GetItemText(this.cboCargaArchivoConci.SelectedItem) == string.Empty)
            {
                MessageBox.Show("Seleccione un archivo de carga válido.", "Conciliación KasNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarDtgPagosConciCoreKasNet();            
        }               

        private void dtgPagosConciKasNet_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPagosConciKasNet.CurrentRow == null)
                return;

            this.dtgPagosCoreKasNet.SelectionChanged -= new System.EventHandler(this.dtgPagosCoreKasNet_SelectionChanged);

            if (this.dtgPagosCoreKasNet.RowCount > 0)
            {
                this.dtgPagosCoreKasNet.CurrentRow.Selected = false;    
            }            

            int nRowSelection = this.dtgPagosConciKasNet.CurrentCell.RowIndex;
            DataGridViewCell dtgc = this.dtgPagosConciKasNet.CurrentCell;

            int nCodSuministro = Convert.ToInt32(this.dtgPagosConciKasNet.Rows[nRowSelection].Cells["cNroSuministroConci"].Value);            

            foreach (DataGridViewRow row in this.dtgPagosConciKasNet.Rows)
            {
                if (row.Index != nRowSelection)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            foreach (DataGridViewRow row in this.dtgPagosCoreKasNet.Rows)
            {
                if (Convert.ToInt32(row.Cells["idCuenta"].Value) == nCodSuministro)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;                    
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            this.dtgPagosCoreKasNet.SelectionChanged += new System.EventHandler(this.dtgPagosCoreKasNet_SelectionChanged);
        }

        private void dtgPagosCoreKasNet_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPagosCoreKasNet.CurrentRow == null)
                return;

            this.dtgPagosConciKasNet.SelectionChanged -= new System.EventHandler(this.dtgPagosConciKasNet_SelectionChanged);

            if (this.dtgPagosConciKasNet.RowCount > 0)
            {
                this.dtgPagosConciKasNet.CurrentRow.Selected = false;
            }

            int nRowSelection = this.dtgPagosCoreKasNet.CurrentCell.RowIndex;

            int idCuenta = Convert.ToInt32(this.dtgPagosCoreKasNet.Rows[nRowSelection].Cells["idCuenta"].Value);            

            foreach (DataGridViewRow row in this.dtgPagosCoreKasNet.Rows)
            {
                if (row.Index != nRowSelection)
                {
                    row.DefaultCellStyle.BackColor = Color.White;       
                }      
            }

            foreach (DataGridViewRow row in this.dtgPagosConciKasNet.Rows)
            {
                if (Convert.ToInt32(row.Cells["cNroSuministroConci"].Value) == idCuenta)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;                    
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            this.dtgPagosConciKasNet.SelectionChanged += new System.EventHandler(this.dtgPagosConciKasNet_SelectionChanged);            
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            frmConciliacionBitacoraKasNet objConciliacionBitacoraKasNet = new frmConciliacionBitacoraKasNet(this.dtpFechaCargaConci.Value.Date);
            objConciliacionBitacoraKasNet.ShowDialog();
        }
    }
}
