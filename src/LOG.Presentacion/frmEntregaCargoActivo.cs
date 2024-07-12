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
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmEntregaCargoActivo : frmBase
    {
        public string cNomOri, cDocIDOri, idCargoPerOri, cCargoPerOri, idCliPerOri;
        public int idUsuOri, nidAgenciaOri,nidAreaOri;
        public string cNomDes, cDocIDDes, idCargoPerDes, cCargoPerDes, idCliPerDes;
        public int idUsuDes, nidAgenciaDes, nidAreaDes;
        decimal sumatoria = 0;
        clsCNActivos ListaActivo = new clsCNActivos();
        DataTable dtDetalleActivo = new DataTable();
        DataTable dtEntregaCargo = new DataTable();
        DataTable dtListActColOri = new DataTable("dtListActColOri");

        public frmEntregaCargoActivo()
        {
            InitializeComponent();
            cboAgenciasOri.SelectedValue = -1;
            cboAgenciasDes.SelectedValue = -1;
        }

        private void frmEntregaCargoActivo_Load(object sender, EventArgs e)
        {
            cargarEstructuraGrid();
            cargarEntregaCargo();
            ActivarControl(false);
        }

        private void BuscaColaboradorOri()
        {
            FrmBusCol frm = new FrmBusCol();
            frm.ShowDialog();
            if (Convert.ToString(frm.idUsu) != "")
            {
                idUsuOri = Convert.ToInt32(frm.idUsu);
                cNomOri = frm.cNom;
                cDocIDOri = frm.cDocID;
                idCargoPerOri = frm.idCargoPer;
                cCargoPerOri = frm.cCargoPer;
                idCliPerOri = frm.idCliPer;
                nidAgenciaOri = Convert.ToInt32(frm.nidAgencia);
                nidAreaOri = Convert.ToInt32(frm.nidArea);
            }

        }

        private void BuscaColaboradorDes()
        {
            FrmBusCol frm = new FrmBusCol();
            frm.ShowDialog();
            if (Convert.ToString(frm.idUsu) != "")
            {
                idUsuDes = Convert.ToInt32(frm.idUsu);
                cNomDes = frm.cNom;
                cDocIDDes = frm.cDocID;
                idCargoPerDes = frm.idCargoPer;
                cCargoPerDes = frm.cCargoPer;
                idCliPerDes = frm.idCliPer;
                nidAgenciaDes = Convert.ToInt32(frm.nidAgencia);
                nidAreaDes = Convert.ToInt32(frm.nidArea);
            }
        }

        private void sumaMontoFaltante()
        {
            sumatoria = 0;
            foreach (DataGridViewRow row in dtgActivoOrigen.Rows)
            {
                //sumatoria += Convert.ToDecimal(row.Cells["Valor"].Value);
                if (!Convert.ToBoolean(row.Cells["lEntregado"].Value))
                {
                    sumatoria += Convert.ToDecimal(row.Cells["nValor"].Value);                    
                }                
            }

            txtMontoFaltante.Text = sumatoria.ToString("#,0.00");
        }

        private decimal sumarValor()
        {
            decimal result = dtgActivoOrigen.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells["nValor"].Value));
            return result;
        }

        private void CargaGrid(int usuario)
        {
            dtListActColOri = ListaActivo.CNListaActPersonal(usuario);
            dtListActColOri.Columns["lEntregado"].ReadOnly = false;
            dtgActivoOrigen.DataSource = dtListActColOri;

            dtgActivoOrigen.ReadOnly = false;
            dtgActivoOrigen.Columns["nNro"].ReadOnly = true;
            dtgActivoOrigen.Columns["cProducto"].ReadOnly = true;
            dtgActivoOrigen.Columns["cRubro"].ReadOnly = true;
            dtgActivoOrigen.Columns["cMaterial"].ReadOnly = true;
            dtgActivoOrigen.Columns["cColor"].ReadOnly = true;
            dtgActivoOrigen.Columns["cMarca"].ReadOnly = true;
            dtgActivoOrigen.Columns["cSerie"].ReadOnly = true;
            dtgActivoOrigen.Columns["cModelo"].ReadOnly = true;
            dtgActivoOrigen.Columns["nValor"].ReadOnly = true;

            dtgActivoOrigen.Columns["idActivo"].Visible = false;
            dtgActivoOrigen.Columns["idCatalogo"].Visible = false;

            dtgActivoOrigen.Columns["nNro"].HeaderText = "Nro";
            dtgActivoOrigen.Columns["cProducto"].HeaderText = "Producto";
            dtgActivoOrigen.Columns["cRubro"].HeaderText = "Rubro";
            dtgActivoOrigen.Columns["cMaterial"].HeaderText = "Material";
            dtgActivoOrigen.Columns["cColor"].HeaderText = "Color";
            dtgActivoOrigen.Columns["cMarca"].HeaderText = "Marca";
            dtgActivoOrigen.Columns["cSerie"].HeaderText = "Serie";
            dtgActivoOrigen.Columns["cModelo"].HeaderText = "Modelo";
            dtgActivoOrigen.Columns["nValor"].HeaderText = "Valor";
            dtgActivoOrigen.Columns["lEntregado"].HeaderText = "Entregado";
        }

        private void cargaMotivoEntregaCargo()
        {
            DataTable dtListaMotivo = ListaActivo.CNListaMotEntregaCargo();
            this.cboMotEntregaCargo.DataSource = dtListaMotivo;
            this.cboMotEntregaCargo.ValueMember = dtListaMotivo.Columns["idMotivoEntrega"].ToString();
            this.cboMotEntregaCargo.DisplayMember = dtListaMotivo.Columns["cDescripcion"].ToString();
            this.cboMotEntregaCargo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cargarEstructuraGrid()
        {
            dtListActColOri.Rows.Clear();
            dtListActColOri.Columns.Add("idActivo", typeof(int));
            dtListActColOri.Columns.Add("idCatalogo", typeof(int));
            dtListActColOri.Columns.Add("cProducto", typeof(string));
            dtListActColOri.Columns.Add("cRubro", typeof(string));
            dtListActColOri.Columns.Add("cMaterial", typeof(string));
            dtListActColOri.Columns.Add("cColor", typeof(string));
            dtListActColOri.Columns.Add("cMarca", typeof(string));
            dtListActColOri.Columns.Add("cSerie", typeof(string));
            dtListActColOri.Columns.Add("cModelo", typeof(string));
            dtListActColOri.Columns.Add("lEntregado", typeof(string));
        }

        private void cargarEntregaCargo()
        {
            dtEntregaCargo.Rows.Clear();
            dtEntregaCargo.Columns.Add("idUsuarioReg", typeof(int));
            dtEntregaCargo.Columns.Add("idUsuarioDes", typeof(int));
            dtEntregaCargo.Columns.Add("idAgenciaReg", typeof(int));
            dtEntregaCargo.Columns.Add("idAgenciaDes", typeof(int));
            dtEntregaCargo.Columns.Add("idMotivoEntrega", typeof(int));
            dtEntregaCargo.Columns.Add("cObservacion", typeof(string));
            dtEntregaCargo.Columns.Add("dFechaEntrega", typeof(DateTime));
            dtEntregaCargo.Columns.Add("idMoneda", typeof(int));
            dtEntregaCargo.Columns.Add("nMontoTotal", typeof(decimal));        
        }

        private void btnBusColOri_Click(object sender, EventArgs e)
        {
            CleanDataUsuOri();
            BuscaColaboradorOri();
            if (String.IsNullOrEmpty(cNomOri))
            {
                return;
            }
            else {
                txtUsuOrigen.Text = cNomOri;
                cboAgenciasOri.SelectedValue = nidAgenciaOri;

                cboAreaOri.CargarArea(Convert.ToInt32(cboAgenciasOri.SelectedValue));
                cboAreaOri.SelectedValue = nidAreaOri;
                cboCargoPersonalOri.CargarCargo(nidAreaOri);
                cboCargoPersonalOri.SelectedValue = idCargoPerOri;
                CargaGrid(idUsuOri);
                txtMontoTotal.Text = Convert.ToString(sumarValor());
                txtMontoFaltante.Text = Convert.ToString(sumarValor());
            }
            

            
        }

        private void btnBusColDes_Click(object sender, EventArgs e)
        {
            CleanDataUsuDes();
            BuscaColaboradorDes();
            if (String.IsNullOrEmpty(cNomDes))
            {
                return;
            }
            else
            {
                txtUsuDestino.Text = cNomDes;
                cboAgenciasDes.SelectedValue = nidAgenciaDes;

                cboAreaDes.CargarArea(Convert.ToInt32(cboAgenciasDes.SelectedValue));
                cboAreaDes.SelectedValue = nidAreaDes;

                cboCargoPersonalDes.CargarCargo(nidAreaDes);
                cboCargoPersonalDes.SelectedValue = idCargoPerDes;
            }
        }

        private void CleanDataUsuOri()
        {
            idUsuOri = 0;
            cNomOri = "";
            cDocIDOri = "";
            idCargoPerOri = "";
            cCargoPerOri = "";
            idCliPerOri = "";
            nidAgenciaOri = 0;

            txtUsuOrigen.Text = "";
            cboAgenciasOri.SelectedValue = 0;
            cboAreaOri.SelectedValue = 0;
            cboCargoPersonalOri.SelectedValue = 0;
            dtgActivoOrigen.DataSource = "";
            txtObserv.Text = "";
            txtMontoFaltante.Text = "0.00";
            txtMontoTotal.Text = "0.00";
        }

        private void CleanDataUsuDes()
        {
            idUsuDes = 0;
            cNomDes = "";
            cDocIDDes = "";
            idCargoPerDes = "";
            cCargoPerDes = "";
            idCliPerDes = "";
            nidAgenciaDes = 0;

            txtUsuDestino.Text = "";
            cboAgenciasDes.SelectedValue = 0;
            cboAreaDes.SelectedValue = 0;
            cboCargoPersonalDes.SelectedValue = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CleanDataUsuOri();
            CleanDataUsuDes();
            ActivarControl(true);
            cargaMotivoEntregaCargo();
            //btnImprimir.Enabled = true;
        }

        private void ActivarControl(bool Val)
        {
            btnNuevo.Enabled = !Val;
            btnGrabar.Enabled = Val;
            btnBusColOri.Enabled = Val;
            btnBusColDes.Enabled = Val;
            txtObserv.Enabled = Val;
            cboMotEntregaCargo.Enabled = Val;
            cboMoneda.Enabled = Val;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }

            DataSet dsDetActivo = new DataSet("dsDetActivo");
            dsDetActivo.Tables.Add(dtListActColOri);
            string xmlDetActivo = dsDetActivo.GetXml();
            xmlDetActivo = clsCNFormatoXML.EncodingXML(xmlDetActivo);
            dsDetActivo.Tables.Clear();

            DataRow drEntregCargo = null;
            drEntregCargo = dtEntregaCargo.NewRow();

            drEntregCargo["idUsuarioReg"] = idUsuOri;
            drEntregCargo["idUsuarioDes"] = idUsuDes;
            drEntregCargo["idAgenciaReg"] = nidAgenciaOri;
            drEntregCargo["idAgenciaDes"] = nidAgenciaDes;
            drEntregCargo["idMotivoEntrega"] = Convert.ToInt32(cboMotEntregaCargo.SelectedValue);
            drEntregCargo["cObservacion"] = txtObserv.Text;
            drEntregCargo["dFechaEntrega"] = clsVarGlobal.dFecSystem;
            drEntregCargo["idMoneda"] = Convert.ToInt32(cboMoneda.SelectedValue);
            drEntregCargo["nMontoTotal"] = Convert.ToDecimal(Convert.ToDecimal(txtMontoTotal.Text) - Convert.ToDecimal(txtMontoFaltante.Text));
            dtEntregaCargo.Rows.Add(drEntregCargo);

            DataSet dsEntregaCargo = new DataSet("dsEntregaCargo");
            dsEntregaCargo.Tables.Add(dtEntregaCargo);
            string xmlEntregaCargo = dsEntregaCargo.GetXml();
            xmlEntregaCargo = clsCNFormatoXML.EncodingXML(xmlEntregaCargo);
            dsEntregaCargo.Tables.Clear();

            DataTable dtRtpa = ListaActivo.CNInsertaEntregaCargo(xmlDetActivo, xmlEntregaCargo);

            if (Convert.ToInt16(dtRtpa.Rows[0]["idError"].ToString()) == 0)
            {
                MessageBox.Show(dtRtpa.Rows[0]["cMensaje"].ToString(), "Entrega Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(dtRtpa.Rows[0]["cMensaje"].ToString(), "Entrega Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnImprimir.Enabled = true;
            btnGrabar.Enabled = false;
            dtgActivoOrigen.Columns["lEntregado"].ReadOnly = true;
        }

        private void limpiar()
        {           
            CleanDataUsuOri();
            CleanDataUsuDes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanDataUsuOri();
            CleanDataUsuDes();
            ActivarControl(false);
        }

        Boolean Valida()
        {

            if (string.IsNullOrEmpty(txtUsuOrigen.Text))
            {
                MessageBox.Show("Debe Ingresar el Usuario que realizará la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColOri.Focus();
                return false;
            }
            if (cboAgenciasOri.SelectedIndex < 0)
            {
                MessageBox.Show("No se encuentra Oficina de origen de la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColOri.Focus();
                return false;
            }
            if (cboAreaOri.SelectedIndex < 0)
            {
                MessageBox.Show("No se encuentra el Area de origen de la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColOri.Focus();
                return false;
            }
            if (cboCargoPersonalOri.SelectedIndex < 0)
            {
                MessageBox.Show("No tiene Cargo el personal que realiza la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColOri.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUsuDestino.Text))
            {
                MessageBox.Show("Debe Ingresar el Usuario que Recibirá la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColDes.Focus();
                return false;
            }
            if (cboAgenciasDes.SelectedIndex < 0)
            {
                MessageBox.Show("No se encuentra Oficina de Destino para entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColDes.Focus();
                return false;
            }
            if (cboAreaDes.SelectedIndex < 0)
            {
                MessageBox.Show("No se encuentra el Area de Destino para entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColDes.Focus();
                return false;
            }
            if (cboCargoPersonalDes.SelectedIndex < 0)
            {
                MessageBox.Show("No tiene Cargo el personal que recibirá la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColDes.Focus();
                return false;
            }
            if (cboMotEntregaCargo.SelectedIndex < 0)
            {
                MessageBox.Show("Debe detallar el Motivo de la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotEntregaCargo.Focus();
                return false;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Debe detallar la Moneda de la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }

            if (dtgActivoOrigen.Rows.Count <= 0)
            {
                MessageBox.Show("No tiene activos asignados para la entrega de cargo", "Valida Entrega de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBusColOri.Focus();
                return false;
            }

            return true;
        }

        private void dtgActivoOrigen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sumaMontoFaltante();
        }

        private void dtgActivoOrigen_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgActivoOrigen.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = clsVarGlobal.dFecSystem;
            //DataTable dtgDatos = ((DataTable)dtgActivoOrigen.DataSource);
            DataTable dtgDatos = new clsCNActivos().CNListaEntregaCargo(dFecProceso, idUsuOri, idUsuDes);
            if (dtgActivoOrigen.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsDatos", dtgDatos));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("idUsuarioResp", idUsuOri.ToString(), false));
                paramlist.Add(new ReportParameter("idUsuarioReg", idUsuOri.ToString(), false));
                paramlist.Add(new ReportParameter("idUsuarioDes", idUsuDes.ToString(), false));
                paramlist.Add(new ReportParameter("cNomUsuOrigen", cNomOri, false));
                paramlist.Add(new ReportParameter("cOficinaOri", cboAgenciasOri.Text, false));
                paramlist.Add(new ReportParameter("cAreaOri", cboAreaOri.Text, false));
                paramlist.Add(new ReportParameter("cCargoOri", cboCargoPersonalOri.Text, false));
                paramlist.Add(new ReportParameter("cNomUsuDestino", cNomDes, false));
                paramlist.Add(new ReportParameter("cOficinaDes", cboAgenciasDes.Text, false));
                paramlist.Add(new ReportParameter("cAreaDes", cboAreaDes.Text, false));
                paramlist.Add(new ReportParameter("cCargoDes", cboAreaDes.Text, false));
                paramlist.Add(new ReportParameter("dFecProces", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaEntrega", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cObservaciones", txtObserv.Text, false));
                paramlist.Add(new ReportParameter("cMontoTotal", txtMontoTotal.Text, false));
                paramlist.Add(new ReportParameter("cMontoFaltante", txtMontoFaltante.Text, false));
                paramlist.Add(new ReportParameter("cMontoCalculado", Convert.ToString(Convert.ToDecimal(txtMontoTotal.Text) - Convert.ToDecimal(txtMontoFaltante.Text)), false));

                string reportpath = "rptEntregaCargo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para imprimir", "DataSource", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnNuevo.Enabled = true;
            btnImprimir.Enabled = false;
            limpiar();
            ActivarControl(true);
        }

    }
}
