using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarPagos : frmBase
    {
        clsCNPdp cnObjectPdp = new clsCNPdp();
        frmPDPGestionaPagoDialog objPDPGesPagoDialog = new frmPDPGestionaPagoDialog();
        DateTime dFecSystem = clsVarGlobal.dFecSystem;

        public frmPDPGestionarPagos()
        {
            InitializeComponent();
        }

        private void frmPDPGestionarPagos_Load(object sender, EventArgs e)
        {
            this.InicializarComponentes();

            this.dtpFechaInicio1.Value = dFecSystem.Date;
            this.dtpFechaFin1.Value = dFecSystem.Date;

            this.dtpFechaInicio2.Value = dFecSystem.Date;
            this.dtpFechaFin2.Value = dFecSystem.Date;

            this.dtpFechaInicio3.Value = dFecSystem.Date;
            this.dtpFechaFin3.Value = dFecSystem.Date;
        }

        public void InicializarComponentes()
        {
            this.InitCboEstado();       
        }

        public void InitCboEstado()
        {
            this.cboPDPEmisor1.cargarVigentesTodos();
            this.cboPDPEmisor2.cargarVigentesTodos();
            this.cboPDPEmisor3.cargarVigentesTodos();
            this.cboPDPEstado1.ModalidadPDPEstado(1);
            this.cboPDPEstado2.ModalidadPDPEstado(2);
        }        

        public void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio1.Value.Date > this.dtpFechaFin1.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int nModulo = 1;            
            int idEmisor = (int)this.cboPDPEmisor1.SelectedValue;
            int idEstado = (int)this.cboPDPEstado1.SelectedValue;
            DateTime dFechaInicial = this.dtpFechaInicio1.Value;
            DateTime dFechaFinal = this.dtpFechaFin1.Value;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarPagos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);

            this.dtgConsultarPagos.DataSource = dt;            
        }        

        private void btnConsultar2_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio2.Value.Date > this.dtpFechaFin2.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int nModulo = 2;
            int idEmisor = (int)this.cboPDPEmisor2.SelectedValue;
            int idEstado = (int)this.cboPDPEstado2.SelectedValue;
            DateTime dFechaInicial = this.dtpFechaInicio2.Value;
            DateTime dFechaFinal = this.dtpFechaFin2.Value;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarPagos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);

            this.dtgActualizarPago.DataSource = dt;            
        }

        private void btnConsultar3_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio3.Value.Date > this.dtpFechaFin3.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int nModulo = 3;
            int idEmisor = (int)this.cboPDPEmisor3.SelectedValue;
            int idEstado = -1;
            DateTime dFechaInicial = this.dtpFechaInicio3.Value;
            DateTime dFechaFinal = this.dtpFechaFin3.Value;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarPagos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);

            dt.Columns["lCheck"].ReadOnly = false;
            dt.Columns["lCheck"].AllowDBNull = true;

            this.dtgEnviarPago.DataSource = dt;
            this.dtgEnviarPago.Refresh();

            this.dtgEnviarPago.ReadOnly = false;
            this.dtgEnviarPago.Columns["idSetPar3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cIdInstruccionPago3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["dFechaProc3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cFechaHoraTransaccion3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cEmisorCorto3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["nMonto3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["idPDPEstado3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cEstado3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cIdTransaccion3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cWinUser3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["dFechaHoraAct3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["dFechaEstTrans3"].ReadOnly = true;
            this.dtgEnviarPago.Columns["cComentario3"].ReadOnly = true;           
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int nModalidad = 1;
            int idEmisor = (int)this.cboPDPEmisor1.SelectedValue;
            int idEstado = (int)this.cboPDPEstado1.SelectedValue;
            DateTime dFechaInicial = this.dtpFechaInicio1.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin1.Value.Date;

            DataTable dtInstPago = new DataTable();
            dtInstPago = cnObjectPdp.ListarPagos(nModalidad, idEmisor, idEstado, dFechaInicial, dFechaFinal);
            
            if (dtInstPago.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Gestión de Instrucciones de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("nModalidad", nModalidad.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaIni", dFechaInicial.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idEmisor", idEmisor.ToString(), false));
                paramlist.Add(new ReportParameter("idEstado", idEstado.ToString(), false));

                paramlist.Add(new ReportParameter("cNomAgen", "Incluir agencia <<>>>", false));
                paramlist.Add(new ReportParameter("dFechaSis", "12/03/2017", false));
                paramlist.Add(new ReportParameter("dFechaProceso", "15/03/2017", false));
                paramlist.Add(new ReportParameter("cRutaLogo", "Incluir ruta log", false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsInstruccionesPagoDE", dtInstPago));

                string reportpath = "rptReporteInstPagoDE.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir3_Click(object sender, EventArgs e)
        {

        }

        private void dtgConsultarPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgConsultarPagos.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0 && string.IsNullOrEmpty(this.dtgConsultarPagos.Rows[e.RowIndex].Cells["idSetPar1"].Value.ToString()))
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro de crear un Nuevo Pago?", "Gestionar Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int idSetPay = (int)this.dtgConsultarPagos.Rows[e.RowIndex].Cells["idSetPay1"].Value;
                    int idUsuario = clsVarGlobal.User.idUsuario;
                    cnObjectPdp.NuevoPago(idSetPay, idUsuario);                    

                    this.btnConsultar1_Click(null, null);
                }                
            }
        }

        private void dtgConsultarPagos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgConsultarPagos.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0)
            {
                if (string.IsNullOrEmpty(this.dtgConsultarPagos.Rows[e.RowIndex].Cells["idSetPar1"].Value.ToString()))
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dtgConsultarPagos.Rows[e.RowIndex].Cells["cAccion11"] as DataGridViewButtonCell;
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgConsultarPagos.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgConsultarPagos.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgConsultarPagos.Rows[e.RowIndex].Cells["cAccion11"].Style = CellStyle;
                }
            }
        }

        private void dtgActualizarPago_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgActualizarPago.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgActualizarPago.Rows[e.RowIndex].Cells["cAccion12"] as DataGridViewButtonCell;
                Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgActualizarPago.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                this.dtgActualizarPago.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                e.Handled = true;
            }
        }

        private void dtgActualizarPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgActualizarPago.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0)
            {
                int idSetPar = Convert.ToInt32(this.dtgActualizarPago.Rows[e.RowIndex].Cells["idSetPar2"].Value);                

                DataTable dt = new DataTable();
                dt = cnObjectPdp.ListarPago(idSetPar);

                DataRow dr = dt.Rows[0];

                int idPDPEmisor = (int)dr["idPDPEmisor"];
                string cIdInsPago = dr["cIdInstruccionPago"].ToString();
                DateTime dFecEstTrans = (string.IsNullOrEmpty(dr["dFechaEstTrans"].ToString())) ? DateTime.Now : Convert.ToDateTime(dr["dFechaEstTrans"].ToString());
                int idEstado = (int)dr["idPDPEstado"];                
                string cComentario = dr["cComentario"].ToString();

                this.objPDPGesPagoDialog = new frmPDPGestionaPagoDialog();
                this.objPDPGesPagoDialog.CargarComponentes(idSetPar, idPDPEmisor, cIdInsPago, idEstado, cComentario);
                this.objPDPGesPagoDialog.ShowDialog();

                this.btnConsultar2_Click(null, null);
            }
        }

        private void dtgEnviarPago_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgEnviarPago.Columns[e.ColumnIndex].Name == "lCheck3" && e.RowIndex >= 0)
            {
                if ((int)this.dtgEnviarPago.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 6 || (int)this.dtgEnviarPago.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 7)
                {
                    this.dtgEnviarPago.Rows[e.RowIndex].Cells["lCheck3"].ReadOnly = true;

                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarPago.Rows[e.RowIndex].Cells["lCheck3"].Style = CellStyle;
                }
            }            

            /*if (e.ColumnIndex >= 0 && this.dtgEnviarPago.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0)
            {
                if ((int)(this.dtgEnviarPago.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 2)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dtgEnviarPago.Rows[e.RowIndex].Cells["cAccion13"] as DataGridViewButtonCell;
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEnviar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgEnviarPago.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgEnviarPago.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarPago.Rows[e.RowIndex].Cells["cAccion13"].Style = CellStyle;
                }                                
            }*/
        }

        private void dtgEnviarPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (this.dtgEnviarPago.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0 && (int)(this.dtgEnviarPago.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 2)
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro de enviar el Pago?", "Gestionar Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int idSetPar = Convert.ToInt32(this.dtgEnviarPago.Rows[e.RowIndex].Cells["idSetPar3"].Value);
                    int idUsuario = clsVarGlobal.User.idUsuario;
                    this.cnObjectPdp.EnviarPago(idSetPar, idUsuario);

                    this.btnConsultar3_Click(null, null);
                }
            }*/
        }

        private void btnEnviar3_Click(object sender, EventArgs e)
        {
            string idSetPars = string.Empty;
            int count = 0;

            foreach (DataGridViewRow row in dtgEnviarPago.Rows)
            {
                if (row.Cells["lCheck3"].Value != DBNull.Value && Convert.ToInt32(row.Cells["lCheck3"].Value) == 1)
                {
                    idSetPars += row.Cells["idSetPar3"].Value.ToString() + ",";
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Antes de proceder debe seleccionar los pagos a enviar.", "Gestionar Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idSetPars = idSetPars.Substring(0, idSetPars.Length - 1);

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de enviar los Pago(s)?", "Gestionar Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idUsuario = clsVarGlobal.User.idUsuario;
                this.cnObjectPdp.EnviarPago(idSetPars, idUsuario);

                this.btnConsultar3_Click(null, null);
            }
        }              
    }
}
