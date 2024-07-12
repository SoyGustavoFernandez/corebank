using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class FrmBuscaCuentaCliente : frmBase
    {
        public string cIdCreSol;
        public int idCli;
        public string cNombre;
        public string cEstado;
        public string cDireccion;
        public string cCodCliente;
        public string NroDocument;
        public DateTime dFechaDesembolso;
        public string cMoneda;
        public Decimal nCapitalDesembolso;
        public string cProducto;
        public int idProducto;
        public string idSolicitud;
        public string idCuenta;

        public FrmBuscaCuentaCliente()
        {
            InitializeComponent();
            this.conBusCli.btnBusCliente.Visible = false;
        }

        public void CargarDatos(Int32 nIdCliente, string cTipoBusqueda, string cEstadoCredito)
        {
            DataTable dtbNumCuentas;
            switch (cTipoBusqueda)
            {
                case "D":
                    clsCNDeposito objDeposito = new clsCNDeposito();
                    dtbNumCuentas = objDeposito.CNCuentasDeposito(nIdCliente, cEstadoCredito);
                    if (dtgDatosCreSol.Columns.Count > 0)
                    {
                        dtgDatosCreSol.Columns.Remove("idNum");
                        dtgDatosCreSol.Columns.Remove("cNombre");
                        dtgDatosCreSol.Columns.Remove("cEstado");
                        dtgDatosCreSol.Columns.Remove("Fecha_Desembolso");
                        dtgDatosCreSol.Columns.Remove("cProducto");
                        dtgDatosCreSol.Columns.Remove("nMonto");
                        dtgDatosCreSol.Columns.Remove("idCli");
                        dtgDatosCreSol.Columns.Remove("cDocumentoID");
                        dtgDatosCreSol.Columns.Remove("cDireccion");
                        dtgDatosCreSol.Columns.Remove("cCodCliente");

                    }
                    dtgDatosCreSol.DataSource = dtbNumCuentas;

                    conBusCli.txtCodInst.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(0,3);
                    conBusCli.txtCodAge.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(3, 3);
                    conBusCli.txtCodCli.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(6);
                    conBusCli.txtCodCli.Enabled = false;
                    conBusCli.txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                    conBusCli.txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                    conBusCli.txtDireccion.Text = dtbNumCuentas.Rows[0]["cDireccion"].ToString();

                    this.formatoGridDep();
                    break;
                default:

                    clsCNRetornsCuentaSolCliente objNumCreSol = new clsCNRetornsCuentaSolCliente();
                    dtbNumCuentas = objNumCreSol.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstadoCredito);
                    if (dtgDatosCreSol.Columns.Count > 0)
                    {
                        dtgDatosCreSol.Columns.Remove("IdNum");
                        dtgDatosCreSol.Columns.Remove("cEstado");
                        dtgDatosCreSol.Columns.Remove("cNombre");
                        dtgDatosCreSol.Columns.Remove("idCli");
                        dtgDatosCreSol.Columns.Remove("Fecha_Desembolso");
                        dtgDatosCreSol.Columns.Remove("Frecuencia");
                        dtgDatosCreSol.Columns.Remove("nMonto");
                        dtgDatosCreSol.Columns.Remove("nCuotas");
                        dtgDatosCreSol.Columns.Remove("IdMoneda");
                        dtgDatosCreSol.Columns.Remove("idProducto");
                        dtgDatosCreSol.Columns.Remove("cProducto");
                        dtgDatosCreSol.Columns.Remove("Monto_Cuota");
                        dtgDatosCreSol.Columns.Remove("nAtraso");
                        dtgDatosCreSol.Columns.Remove("cDocumentoID");
                        dtgDatosCreSol.Columns.Remove("cDireccion");
                        dtgDatosCreSol.Columns.Remove("cCodCliente");

                    }
                    dtgDatosCreSol.DataSource = dtbNumCuentas;
                    if (cTipoBusqueda == "F")
                    {
                        formatoGridCartaFianza();
                    }
                    else
                    {
                        this.formatoGrid();
                    }
                    if (dtbNumCuentas.Rows.Count > 0)
                    {
                        conBusCli.txtCodInst.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(0, 3);
                        conBusCli.txtCodAge.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(3, 3);
                        conBusCli.txtCodCli.Text = dtbNumCuentas.Rows[0]["cCodCliente"].ToString().Substring(6);
                        conBusCli.txtCodCli.Enabled = false;
                        conBusCli.txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                        conBusCli.txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                        conBusCli.txtDireccion.Text = dtbNumCuentas.Rows[0]["cDireccion"].ToString();
                    }
                    break;
            }
        }

        public void formatoGridCartaFianza()
        {
            dtgDatosCreSol.Columns["cNombre"].Visible = false;
            dtgDatosCreSol.Columns["idcuenta"].Visible = false;
            dtgDatosCreSol.Columns["idCli"].Visible = false;
            dtgDatosCreSol.Columns["Frecuencia"].Visible = false;
            dtgDatosCreSol.Columns["IdMoneda"].Visible = false;
            dtgDatosCreSol.Columns["idProducto"].Visible = false;
            dtgDatosCreSol.Columns["cCodCliente"].Visible = false;
            dtgDatosCreSol.Columns["cDocumentoID"].Visible = false;
            dtgDatosCreSol.Columns["cDireccion"].Visible = false;
            dtgDatosCreSol.Columns["cCodCliente"].Visible = false;
            dtgDatosCreSol.Columns["idTipoDocumento"].Visible = false;
            dtgDatosCreSol.Columns["Monto_Cuota"].Visible = false;
            dtgDatosCreSol.Columns["nAtraso"].Visible = false;
            dtgDatosCreSol.Columns["nCuotas"].Visible = false;

            dtgDatosCreSol.Columns["idNum"].HeaderText = "N°";
            dtgDatosCreSol.Columns["cEstado"].HeaderText = "Estado";
            dtgDatosCreSol.Columns["Fecha_Desembolso"].HeaderText = "Fec. Vigencia";
            dtgDatosCreSol.Columns["nMonto"].HeaderText = "Monto";
            dtgDatosCreSol.Columns["cProducto"].HeaderText = "Producto";
            dtgDatosCreSol.Columns["cMoneda"].HeaderText = "Moneda";

            dtgDatosCreSol.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void formatoGrid()
        {
            dtgDatosCreSol.Columns["cNombre"].Visible = false;
            dtgDatosCreSol.Columns["idCli"].Visible = false;
            dtgDatosCreSol.Columns["Frecuencia"].Visible = false;
            dtgDatosCreSol.Columns["IdMoneda"].Visible = false;
            dtgDatosCreSol.Columns["idProducto"].Visible = false;
            dtgDatosCreSol.Columns["cCodCliente"].Visible = false;
            dtgDatosCreSol.Columns["cDocumentoID"].Visible = false;
            dtgDatosCreSol.Columns["cDireccion"].Visible = false;
            dtgDatosCreSol.Columns["cCodCliente"].Visible = false;
            dtgDatosCreSol.Columns["idTipoDocumento"].Visible = false;

            dtgDatosCreSol.Columns["idNum"].HeaderText = "N°";
            dtgDatosCreSol.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgDatosCreSol.Columns["cEstado"].HeaderText = "Estado";
            dtgDatosCreSol.Columns["Fecha_Desembolso"].HeaderText = "Fec. Desembolso";
            dtgDatosCreSol.Columns["nMonto"].HeaderText = "Monto";
            dtgDatosCreSol.Columns["nCuotas"].HeaderText = "N° Cuotas";
            dtgDatosCreSol.Columns["cProducto"].HeaderText = "Producto";
            dtgDatosCreSol.Columns["Monto_Cuota"].HeaderText = "Cuota";
            dtgDatosCreSol.Columns["nAtraso"].HeaderText = "Atraso";
            dtgDatosCreSol.Columns["cMoneda"].HeaderText = "Moneda";
        }

        public void formatoGridDep()
        {
            dtgDatosCreSol.Columns["cNombre"].Visible = false;
            dtgDatosCreSol.Columns["idCuenta"].Visible = false;
            dtgDatosCreSol.Columns["idCli"].Visible = false;
            dtgDatosCreSol.Columns["cDocumentoID"].Visible = false;
            dtgDatosCreSol.Columns["cDireccion"].Visible = false;
            dtgDatosCreSol.Columns["cCodCliente"].Visible = false;

            dtgDatosCreSol.Columns["idNum"].HeaderText = "N°";
            dtgDatosCreSol.Columns["cEstado"].HeaderText = "Estado";
            dtgDatosCreSol.Columns["Fecha_Desembolso"].HeaderText = "Fec. Apertura";
            dtgDatosCreSol.Columns["cProducto"].HeaderText = "Producto";
            dtgDatosCreSol.Columns["nMonto"].HeaderText = "Monto";
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {

            aceptar();
        }

        private void aceptar()
        {
            if (dtgDatosCreSol.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un crédito a agregar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgDatosCreSol.RowCount > 0)
            {
                cIdCreSol = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idNum"].Value.ToString();
                cNombre = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                cEstado = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cEstado"].Value.ToString();
                cDireccion = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cDireccion"].Value.ToString();
                cCodCliente = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                NroDocument = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();
                dFechaDesembolso = Convert.ToDateTime(dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["Fecha_Desembolso"].Value.ToString());
                cMoneda = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cMoneda"].Value.ToString();
                nCapitalDesembolso = Convert.ToDecimal(dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["nMonto"].Value.ToString());
                cProducto = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["cProducto"].Value.ToString();
                idProducto = Convert.ToInt32(dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idProducto"].Value.ToString());
                idCli = conBusCli.idCli;
                idSolicitud = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idNum"].Value.ToString();
                idCuenta = dtgDatosCreSol.Rows[dtgDatosCreSol.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString();
            }
            else
            {
                cIdCreSol = "";
                cNombre = "";
                cEstado = "";
                cDireccion = "";
                cCodCliente="";
                NroDocument = "";
                idSolicitud = "";
                idCuenta = "";
            }
            this.Dispose();
        }

        private void dtgDatosCreSol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAceptar1.PerformClick();
        }

        private void dtgDatosCreSol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
        }

        private void FrmBuscaCuentaCliente_Load(object sender, EventArgs e)
        {
            asignarColorSeleccion();
        }

        private void asignarColorSeleccion()
        {
            foreach (DataGridViewRow row in dtgDatosCreSol.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["IdMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            CargarDatos(Convert.ToInt32(conBusCli.idCli), "C", "[5]");
        }

    }
}
