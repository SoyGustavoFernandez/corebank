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
using SER.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace SER.Presentacion
{
    public partial class frmRptReporteGiros : frmBase
    {
        #region Variables
        Popup complex;
        conPopUpVoucher complexPopup;
        private const int nMaxRangoDias = 15;
        private DataTable dtMovimientoGiros;
        #endregion

        #region Constructor
        public frmRptReporteGiros()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmReporteGiros_Load(object sender, EventArgs e)
        {
            clsCNRecuperaZonaAgencia objCNZona = new clsCNRecuperaZonaAgencia();
            DataTable dtZona = objCNZona.CNRecuperaZonaAgencia(clsVarGlobal.nIdAgencia);
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboZonaGiros.Enabled = false;
            cboAgenciasGiros.Enabled = false;
            cboEstablecimientoGiro.Enabled = false;
            btnImprimirMovGiro.Enabled=false;

            if (dtZona.Rows.Count > 0)
            {
                int idZona = Convert.ToInt32(dtZona.Rows[0]["idZona"]); 
                cboZonaGiros.SelectedValue = idZona;
            }
            this.cboAgenciasGiros.SelectedValue = clsVarGlobal.nIdAgencia;
            this.cboEstablecimientoGiro.SelectedValue = clsVarGlobal.User.idEstablecimiento;
            
            dtgMovimientosLista.DataBindingComplete += dtgMovimientosLista_DataBindingComplete;
            dtgMovimientosLista.CellClick += dtgMovimientosLista_CellClick;
        }
        private void btnImprimirMovGiro_Click(object sender, EventArgs e)
        {
            if (dtMovimientoGiros.Rows.Count > 0)
            {
                DateTime dFecInicio = dtpFecIni.Value;
                DateTime dFecFin = dtpFecFin.Value;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecIni", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsGiros", dtMovimientoGiros));

                string reportpath = "RptGirosEstado.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void dtgMovimientosLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgMovimientosLista.Columns[e.ColumnIndex].Name == "idGiro")
            {
                var dataRow = ((DataRowView)dtgMovimientosLista.Rows[e.RowIndex].DataBoundItem).Row;
                string tipoOperacion = dataRow["cTipoOperacion"]?.ToString() ?? string.Empty;

                switch (tipoOperacion)
                {
                    case "ENVIO DE GIROS":
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Cyan;
                        break;
                    case "PAGO DE GIROS":
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                        break;
                    case "CAMBIO DE DESTINO":
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                    case "ANULACION DE GIROS":
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        break;
                    default:
                        dtgMovimientosLista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }
        private void btnProcesarMovGiro_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            
            dtMovimientoGiros = new clsCNControlServ().CNListaMovimientosGiros(
                Convert.ToInt32(cboEstablecimientoGiro.SelectedValue),
                dtpFecIni.Value,
                dtpFecFin.Value,
                Convert.ToInt32(cboTipoOperacionGiro.SelectedValue));
            if (dtMovimientoGiros.Rows.Count > 0)
            {
                dtgMovimientosLista.DataSource = dtMovimientoGiros;
                formatearDtgMovimientos();
                dtgMovimientosLista.CellFormatting += dtgMovimientosLista_CellFormatting;
            }
            else
            {
                MessageBox.Show("No existe datos para mostrar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void dtgMovimientosLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dtgMovimientosLista.Columns[e.ColumnIndex].Name == "btnVoucher")
                {
                    complex = new Popup(complexPopup = new conPopUpVoucher());
                    complex.Resizable = false;

                    DataRow dataRow = ((DataRowView)dtgMovimientosLista.Rows[e.RowIndex].DataBoundItem).Row;
                    int idGiro = Convert.ToInt32(dataRow["idGiro"]);
                    int idKardex = Convert.ToInt32(dataRow["idKardex"]);
                    int idModulo = Convert.ToInt32(dataRow["idModulo"]);
                    int idTipoOpe = Convert.ToInt32(dataRow["idTipoOpe"]);
                    int idEstadoKardex = Convert.ToInt32(dataRow["idEstadoKardex"]);                    
                    string cContenidoVoucher = RecuperarVoucher(idKardex, idModulo, idTipoOpe, idEstadoKardex, Decimal.Zero, Decimal.Zero, 0, 1);

                    complexPopup.cContenidoVoucher = cContenidoVoucher;
                    complex.Show(sender as Control);
                }
                
            }            
        }
        private void dtgMovimientosLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnImprimirMovGiro.Enabled = dtgMovimientosLista.RowCount > 0;
        }
        #endregion

        #region Metodos
        private void formatearDtgMovimientos()
        {
            foreach (DataGridViewColumn column in dtgMovimientosLista.Columns)
            {
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }

            dtgMovimientosLista.Columns["idGiro"].Visible = true;
            dtgMovimientosLista.Columns["cTipoOperacion"].Visible = false;
            dtgMovimientosLista.Columns["dFechaGiro"].Visible = true;
            dtgMovimientosLista.Columns["cUsuarioRegistra"].Visible = true;
            dtgMovimientosLista.Columns["cEstadoGiro"].Visible = true;
            dtgMovimientosLista.Columns["nOperacion"].Visible = true;
            dtgMovimientosLista.Columns["cNroDniRem"].Visible = true;
            dtgMovimientosLista.Columns["NombreCompletoRem"].Visible = true;
            dtgMovimientosLista.Columns["cAgenciaOrigen"].Visible = true;
            dtgMovimientosLista.Columns["cNroDniDes"].Visible = true;
            dtgMovimientosLista.Columns["cNroGiro"].Visible = true;
            dtgMovimientosLista.Columns["NombreCompletoDes"].Visible = true;
            dtgMovimientosLista.Columns["cAgenciaDestino"].Visible = true;
            dtgMovimientosLista.Columns["dFecPagoGiro"].Visible = true;
            dtgMovimientosLista.Columns["nMontoGiro"].Visible = true;
            dtgMovimientosLista.Columns["nMonComGiro"].Visible = true;
            dtgMovimientosLista.Columns["idKardex"].Visible =false;
            dtgMovimientosLista.Columns["idModulo"].Visible = false;
            dtgMovimientosLista.Columns["idTipoOpe"].Visible = false;
            dtgMovimientosLista.Columns["idEstadoKardex"].Visible = false;

            dtgMovimientosLista.Columns["idGiro"].HeaderText = "CODIGO DE GIRO";
            dtgMovimientosLista.Columns["dFechaGiro"].HeaderText = "FECHA DE GIRO";
            dtgMovimientosLista.Columns["cUsuarioRegistra"].HeaderText = "USUARIO";
            dtgMovimientosLista.Columns["cEstadoGiro"].HeaderText = "ESTADO";
            dtgMovimientosLista.Columns["nOperacion"].HeaderText = "Nº DE OPERACION";
            dtgMovimientosLista.Columns["cNroDniRem"].HeaderText = "Nº DE DNI REMITENTE";
            dtgMovimientosLista.Columns["NombreCompletoRem"].HeaderText = "APELLIDOS Y NOMBRES DEL REMITENTE";
            dtgMovimientosLista.Columns["cAgenciaOrigen"].HeaderText = "ORIGEN DEL GIRO";
            dtgMovimientosLista.Columns["cNroDniDes"].HeaderText = "Nº DE DNI DEL BENEFICIARIO";
            dtgMovimientosLista.Columns["cNroGiro"].HeaderText = "Nº DE GIRO";
            dtgMovimientosLista.Columns["NombreCompletoDes"].HeaderText = "APELLIDOS Y NOMBRES DEL BENEFICIARIO";
            dtgMovimientosLista.Columns["cAgenciaDestino"].HeaderText = "DESTINO DE GIRO";
            dtgMovimientosLista.Columns["dFecPagoGiro"].HeaderText = "FECHA DE PAGO";
            dtgMovimientosLista.Columns["nMontoGiro"].HeaderText = "IMPORTE";
            dtgMovimientosLista.Columns["nMonComGiro"].HeaderText = "COMISION";

            DataGridViewButtonColumn btnVoucher = new DataGridViewButtonColumn
            {
                Name = "btnVoucher",
                HeaderText = "Voucher",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            btnVoucher.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMovimientosLista.Columns.Add(btnVoucher);

            dtgMovimientosLista.Columns["NombreCompletoRem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgMovimientosLista.Columns["NombreCompletoDes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private bool Validar()
        {
            TimeSpan diferencia = dtpFecFin.Value.Date - dtpFecIni.Value.Date;

            if (Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()) > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha de Inicio no Puede Ser Mayor que la Fecha Actual",
                                "Reporte de Giros",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()) > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha de Fin no Puede Ser Mayor que la Fecha Actual",
                                "Reporte de Giros",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }

            if (diferencia.Days > nMaxRangoDias)
            {
                MessageBox.Show("El rango entre las fechas de inicio y fin no puede ser mayor a " + nMaxRangoDias + " días.",
                                "Reporte de Giros",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.",
                                "Reporte de Giros",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        #endregion

        
    }
}
