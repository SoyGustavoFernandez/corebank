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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmMantenimientoCertificados : frmBase
    {

        #region Variables Globales
        private int idMoneda, idValorado, nFinSerie, nOrder, idCuenta=0, idTipOpe, idEstadoVal, ncertificado, idVincuCuenta;
        private DataTable dtValorados = new DataTable();
        private DataTable DetValorados = new DataTable();
        private DataTable dtEstadoVinc = new DataTable();
        DataTable dtbIntervCta = new DataTable();
        private bool lIndBloqTot = false;
        private clsCNValorados objValorados = new clsCNValorados();
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        #endregion
        #region Constructor
        public frmMantenimientoCertificados()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            this.txtNumSerie.Text = "0000001";
            this.txtCBNumCerti.Text = "0000001";
            this.txtNumInicio.Text = "0000001";
            this.txtNumFinal.Text = "0000001";
            this.txtCBNumCerti.Enabled = false;
            this.btnMiniAceptar1.Enabled = false;
            this.btnMiniCancelar1.Enabled = false;
            //Valida que no se encuentre vigente un certificado vinculado a la cuenta
            if (dtValorados.Rows.Count >0)
            {
                for (int i = 0; i < dtValorados.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtValorados.Rows[i]["idEstadoVinc"]) == 1)
                    {
                        MessageBox.Show("Existe un Certificado Vinculado Vigente. Verifique", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnMiniAceptar1.Enabled = false;
                        this.btnMiniCancelar1.Enabled = false;
                        this.txtCBNumCerti.Enabled = false;
                        this.cboEstado.Enabled = true;
                        this.btnBusqueda.Enabled = false;
                        this.btnNuevo.Enabled = true;
                        this.cboEstado.Focus();
                        return;
                    }
                }
            }

            frmListaValoradosAsignados frmValoradosAsig = new frmListaValoradosAsignados();
            frmValoradosAsig.nEstadoVal = 2;
            frmValoradosAsig.idMoneda = idMoneda;
            frmValoradosAsig.idValorado = 2;
            frmValoradosAsig.ShowDialog();
            idValorado = frmValoradosAsig.idValorado;
            //            idEstadoVal = 1;
            nFinSerie = frmValoradosAsig.nFin;
            nOrder = frmValoradosAsig.nOrden;
            this.txtNumSerie.Text = frmValoradosAsig.nSerie.ToString().PadLeft(7, '0');
            this.txtNumInicio.Text = frmValoradosAsig.nInicio.ToString().PadLeft(7, '0');
            this.txtNumFinal.Text = frmValoradosAsig.nFin.ToString().PadLeft(7, '0');

            if (Convert.ToInt32(this.txtNumSerie.Text) == 0 && Convert.ToInt32(this.txtNumInicio.Text) == 0 && Convert.ToInt32(this.txtNumFinal.Text) == 0)
            {
                this.btnBusqueda.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnNuevo.Focus();
                this.btnMiniAceptar1.Enabled = false;
                this.btnMiniCancelar1.Enabled = false;
                this.txtCBNumCerti.Enabled = false;


            }
            else
            {

                this.txtCBNumCerti.Enabled = true;
                this.txtCBNumCerti.Focus();
                this.btnNuevo.Enabled = false;
                this.btnCancelar.Enabled = true;
            //    this.btnGrabar.Enabled = true;
                this.btnMiniAceptar1.Enabled = true;
                this.btnBusqueda.Enabled = false;

            }
        }

        private void conBusCtaAho1_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.conBusCtaAho1.txtNroCta.Text))
            {
                if (Convert.ToInt32(this.conBusCtaAho1.txtNroCta.Text.ToString().Trim()) == 0)
                {
                    MessageBox.Show("Debe de Ingresar Número de cuenta diferente de Cero(0)", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                idMoneda = conBusCtaAho1.idMoneda;
                this.conBusCtaAho1.txtNroCta.Enabled = false;
                this.conBusCtaAho1.btnBusCliente.Enabled = false;
                idCuenta = Convert.ToInt32(conBusCtaAho1.txtNroCta.Text.Trim());
                //Validando que la Cuenta No se Encuentre Bloqueada
         
                DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuentaGen(idCuenta,clsVarGlobal.idModulo);

                if (dtEstCuenta.Rows.Count > 0)
                {
                    if ((int)dtEstCuenta.Rows[0]["nIdUsuBloq"] > 0)
                    {
                        DataTable dtUsu = RetornaNumCuenta.BusUsuBlo((int)dtEstCuenta.Rows[0]["nIdUsuBloq"]);
                        if (dtUsu.Rows.Count>0)
                        {
                            MessageBox.Show("La Cuenta está siendo consultada: " + dtUsu.Rows[0]["cNombre"].ToString() +" - "+ dtUsu.Rows[0]["cNombreAge"].ToString(), "Validar Consulta de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            idCuenta = 0;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("No se Encontró Datos de Usuario que está consultando la Cuenta", "Error en la Carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                }
                //Carga de Valorados por Cuenta
                dtValorados = objValorados.CNListaValoradosxCuenta(idCuenta,2, clsVarGlobal.User.idUsuario);
                if (dtValorados.Rows.Count > 0)
                {
                    this.btnNuevo.Enabled = true;
                    this.cboEstado.Enabled = true;
                }
                else
                {

                    this.btnNuevo.Enabled = true;
                    this.btnNuevo.PerformClick();
                    this.cboEstado.Enabled = false;
                }
                this.btnCancelar.Enabled = true;
                //Carga de Intervinientes
                clsCNDeposito clsDeposito = new clsCNDeposito();
                dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCuenta);
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    FormatoGridInterv();
                }
            }
            else
            {
                this.conBusCtaAho1.txtNroCta.Enabled = true;
                this.conBusCtaAho1.btnBusCliente.Enabled = true;
                this.conBusCtaAho1.Focus();
            }
        }

        private void btnMiniAceptar1_Click(object sender, EventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
            {
                MessageBox.Show("Ingrese un Número Válido de Certificado", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBNumCerti.Focus();
                this.txtCBNumCerti.SelectAll();
                return;
            }
            else
            {
                if (Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim()) == 0)
                {
                    MessageBox.Show("Ingrese un Número Válido de Certificado", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCBNumCerti.Focus();
                    this.txtCBNumCerti.SelectAll();
                    return;
                }
                else
                {
                    cValor = this.txtCBNumCerti.Text.ToString().Trim();
                    this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
                    this.Validar();
                }

            }
        }
        private void frmMantenimientoCertificados_Load(object sender, EventArgs e)
        {
            idTipOpe = 15;
            conBusCtaAho1.nTipOpe = idTipOpe;
            conBusCtaAho1.pnIdMon = 0;  // no es necesario la moneda, debe listar todas las Cuentas.
            this.CargarDatos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RetornaNumCuenta.CNDesbloqueaCuenta(idCuenta, clsVarGlobal.idModulo);
            this.LimpiarControles();
            this.conBusCtaAho1.txtNroCta.Enabled = true;
            this.conBusCtaAho1.btnBusCliente.Enabled = true;
            this.btnMiniAceptar1.Enabled = false;
            this.btnMiniCancelar1.Enabled = false;
            this.cboEstado.Enabled = false;
            this.txtCBNumCerti.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.conBusCtaAho1.txtNroCta.Focus();
            this.btnCancelar.Enabled = false;
            this.btnBusqueda.Enabled = false;
            this.btnGrabar.Enabled = false;
       
            
           
        }
        #endregion
        #region Metodos
        private void FormatoGridInterv()
        {
        }
        private void FormatoGridCertificado()
        {
            this.dtgCertificado.Columns["Row"].Visible = false;
            this.dtgCertificado.Columns["idVincuCuenta"].Visible = false;
            this.dtgCertificado.Columns["idValorado"].Visible = false;
            this.dtgCertificado.Columns["nFin"].Visible = false;
            this.dtgCertificado.Columns["idEstadoVinc"].Visible = false;

            this.dtgCertificado.Columns["nSerie"].HeaderText = "Serie";
            this.dtgCertificado.Columns["nInicio"].HeaderText = "Nro.Certificado";

            this.dtgCertificado.Columns["nSerie"].Width = 65;

        }
        private void CargarDatos()
        {
            dtEstadoVinc = objValorados.CNListaEstVincu();
            this.cboEstado.DataSource = dtEstadoVinc;
            this.cboEstado.DisplayMember = dtEstadoVinc.Columns["cEstadoVincu"].ToString();
            this.cboEstado.ValueMember = dtEstadoVinc.Columns["idEstadoVincu"].ToString();
        }
        private void LimpiarControles()
        {
            idMoneda=0;
            idValorado=0;
            nFinSerie=0; 
            nOrder=0; 
            idCuenta=0; 
            idEstadoVal=0; 
            ncertificado=0;
            idVincuCuenta=0;
            dtValorados.Rows.Clear();
            DetValorados.Rows.Clear();
            this.conBusCtaAho1.txtCodCli.Clear();
            this.conBusCtaAho1.txtNombre.Clear();
            this.conBusCtaAho1.txtNroCta.Clear();
            this.conBusCtaAho1.txtNroDoc.Clear();
            this.conBusCtaAho1.txtCodAge.Clear();
            this.conBusCtaAho1.txtCodMon.Clear();
            this.conBusCtaAho1.txtCodMod.Clear();
            this.conBusCtaAho1.txtCodIns.Clear();

            this.cboEstado.SelectedIndex = -1;
            this.dtgCertificado.DataSource = "";
            this.dtgDetalleVal.DataSource = "";
            if (dtgIntervinientes.Rows.Count > 0)
            {
                dtbIntervCta.Rows.Clear();
            }
            this.chcBase1.Checked = false;
            this.txtMotivo.Clear();

            this.txtNumSerie.Text = "0000001";
            this.txtNumInicio.Text = "0000001";
            this.txtNumFinal.Text = "0000001";

            this.txtCBNumCerti.Text = "0000000";
        }
        public void Validar()
        {

            ncertificado = Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim());
            DataTable dtValCerti = objValorados.CNValidaVincuCerti(ncertificado, idMoneda,clsVarGlobal.nIdAgencia);
            if (dtValCerti.Rows.Count > 0)
            {
                MessageBox.Show("El Número de Certificado se encuentra vinculada a la Cuenta: " + dtValCerti.Rows[0]["idCuenta"].ToString(), "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBNumCerti.Focus();
                this.txtCBNumCerti.SelectAll();
                this.btnGrabar.Enabled = false;
                //this.btnAceptar1.Enabled = false;
                return;
            }
            else
            {

                DataTable dtGenCerti = objValorados.CNValidaGenCerti(ncertificado, idMoneda, 2, clsVarGlobal.nIdAgencia);
                if (dtGenCerti.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dtGenCerti.Rows[0]["nNumCertiSerie"]) == ncertificado)
                    {
                        idEstadoVal = 1;
                        this.txtCBNumCerti.Enabled = false;
                        this.btnMiniCancelar1.Enabled = true;
                        this.btnMiniAceptar1.Enabled = false;
                        this.btnGrabar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El Número de Certificado Pendiente de Vinculación es:  " + dtGenCerti.Rows[0]["nNumCertiSerie"].ToString(), "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
                        this.txtCBNumCerti.Text = dtGenCerti.Rows[0]["nNumCertiSerie"].ToString();
                        this.txtCBNumCerti.Focus();
                        this.txtCBNumCerti.SelectAll();
                        this.btnMiniCancelar1.Enabled = false;
                        this.btnMiniAceptar1.Enabled = true;
                        this.btnGrabar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("El Número de Certificado no ha sido Generado. Verifique", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                    this.txtCBNumCerti.Focus();
                    this.txtCBNumCerti.SelectAll();
                    this.btnGrabar.Enabled = false;
                    //this.btnAceptar1.Enabled = false;
                    return;
                }
            }

        }
        private void FormatoGridVal()
        {
            dtgDetalleVal.Columns["idVincuCuenta"].Visible = false;
            dtgDetalleVal.Columns["idCuenta"].Visible = false;
            dtgDetalleVal.Columns["idEstadoVal"].Visible = false;
            dtgDetalleVal.Columns["nSerie"].Visible = false;

            dtgDetalleVal.Columns["nNumValorado"].HeaderText = "Nro.Ord";
            //    dtgDetalleVal.Columns["cmb"].HeaderText = "Estado";
            dtgDetalleVal.Columns["idKardex"].HeaderText = "Kardex";
            dtgDetalleVal.Columns["dFechaOpe"].HeaderText = "Fecha.Ope";
            dtgDetalleVal.Columns["cEstadoVincu"].HeaderText = "Estado";
            dtgDetalleVal.Columns["lIndAplica"].HeaderText = "X";

            dtgDetalleVal.Columns["nNumValorado"].Width = 50;
            // dtgDetalleVal.Columns["cmb"].Width = 80;
            dtgDetalleVal.Columns["idKardex"].Width = 70;
            dtgDetalleVal.Columns["dFechaOpe"].Width = 70;
            dtgDetalleVal.Columns["cEstadoVincu"].Width = 70;
            dtgDetalleVal.Columns["lIndAplica"].Width = 30;

        }
        private void SortGridDetValorados()
        {
            dtgDetalleVal.Columns["idVincuCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nSerie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nNumValorado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idKardex"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idEstadoVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["dFechaOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idVincuCuenta = 0;
            idEstadoVal = 1;
            this.DetValorados.Rows.Clear();
            this.btnMiniAceptar1.Enabled = false;
            this.btnMiniCancelar1.Enabled = false;
            this.txtCBNumCerti.Text = "0000000";
            this.btnNuevo.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnBusqueda.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.chcBase1.Checked = false;
            this.chcBase1.Enabled = false;
           
            this.dtgDetalleVal.DataSource = "";
            this.dtgCertificado.DataSource = "";
            this.btnBusqueda.Focus();
            this.cboEstado.Enabled = false;
        
            
        }

        private void btnMiniCancelar1_Click(object sender, EventArgs e)
        {
            this.btnMiniAceptar1.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.txtCBNumCerti.Enabled = true;
            this.txtCBNumCerti.Focus();
            this.txtCBNumCerti.SelectAll();
            this.btnMiniCancelar1.Enabled = false;
            this.btnBusqueda.Enabled = true;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.conBusCtaAho1.txtCodCli.Text.ToString().Trim()))
	        {
                MessageBox.Show("Realice la Búsqueda de un Cliente", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

	        }
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
	        {
                MessageBox.Show("Número de Certificado No Válido", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	        }
            int nCantidad = 1;
            int nSerie = Convert.ToInt32(this.txtNumSerie.Text.ToString().Trim());
            int nNumInicio = Convert.ToInt32(this.txtNumInicio.Text.ToString().Trim());
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idAgencia = clsVarGlobal.nIdAgencia;
            DateTime dFechaOpe = clsVarGlobal.dFecSystem;
            DateTime dFechaMod = clsVarGlobal.dFecSystem;
            int idUsuMod = clsVarGlobal.User.idUsuario;
            string cMotivo=this.txtMotivo.Text.ToString();
            DataSet dsDetValorados = new DataSet("dsDetValorados");
            string XMLDetValorados;
            if (DetValorados.Rows.Count <= 0)
            {
                DetValorados = objValorados.CNGeneraSerieValorados(idVincuCuenta, idCuenta, nNumInicio, nCantidad);
            }
            if (idEstadoVal == 3)
            {
                DetValorados.Columns["idEstadoVal"].ReadOnly = false;
                for (int i = 0; i < DetValorados.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DetValorados.Rows[i]["lIndAplica"]) == 1)
                    {
                        DetValorados.Rows[i]["idEstadoVal"] = 3;
                    }

                }
            }
            dsDetValorados.Tables.Add(DetValorados);
            XMLDetValorados = dsDetValorados.GetXml();
            XMLDetValorados = clsCNFormatoXML.EncodingXML(XMLDetValorados);
            dsDetValorados.Tables.Clear();

            DataTable dtResp = objValorados.CNGuardarVinculacion(idVincuCuenta, idValorado, idCuenta, nSerie,
                                                                    nNumInicio, nNumInicio, idUsuario, idAgencia,
                                                                    dFechaOpe, idEstadoVal, XMLDetValorados, dFechaMod,
                                                                    idUsuMod, cMotivo, lIndBloqTot);
            if ((int)dtResp.Rows[0]["Resultado"] > 0)
            {
                MessageBox.Show("Los Cambios se Guardaron Correctamente", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
               //Impresion del Certificado
                if (idVincuCuenta==0)
                {
                    string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                    DataTable dtcertificado = new clsRPTCNDeposito().CNRetornaDatosCerti(idCuenta,false);
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();
                    paramlist.Add(new ReportParameter("x_idCuenta", idCuenta.ToString(), false));
                    paramlist.Add(new ReportParameter("cNombreEmpresa", cNomEmp, true));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("DsCuenta", dtcertificado));

                    string reportpath = "RptCertificado.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                   
                }
                this.btnCancelar.PerformClick();
               
            }
            else
            {
                MessageBox.Show("Error el Guardar los Datos", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

        }


        private void cboEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.chcBase1.Checked = false;
            this.chcBase1.Enabled = false;
            DetValorados.Rows.Clear();
            this.dtgCertificado.DataSource = null;
       //     this.DetValorados.Rows.Clear();
            
            if (cboEstado.SelectedIndex>0)
            {
                if (this.cboEstado.SelectedIndex == 1)
                {
                    dtValorados.DefaultView.RowFilter = ("idEstadoVinc ='1'");
                    this.dtgCertificado.DataSource = dtValorados.DefaultView;
                    this.FormatoGridCertificado();
                }
                else if (this.cboEstado.SelectedIndex == 2)
                {
                    dtValorados.DefaultView.RowFilter = ("idEstadoVinc ='2'");
                    this.dtgCertificado.DataSource = dtValorados.DefaultView;
                    this.FormatoGridCertificado();
                }
                else if (this.cboEstado.SelectedIndex == 3)
                {
                    dtValorados.DefaultView.RowFilter = ("idEstadoVinc ='3'");
                    this.dtgCertificado.DataSource = dtValorados.DefaultView;
                    this.FormatoGridCertificado();
                }
                else
                {
                    dtValorados.Rows.Clear();
                    DetValorados.Rows.Clear();
                }
            }

        }

        private void dtgCertificado_RowEnter(object sender, DataGridViewCellEventArgs e)
       {
             int nfila = e.RowIndex;
            if (dtgCertificado.Rows.Count > 0)
            {
                this.DetValorados.Rows.Clear();
                idVincuCuenta = Convert.ToInt32(Convert.ToInt32(dtgCertificado.Rows[nfila].Cells["idVincuCuenta"].Value));
                //Retornando el Detalle del Bloque de Valorados
                RetornaDetValorados(idCuenta, idVincuCuenta);
            }
            else
            {
                this.DetValorados.Rows.Clear();
                this.chcBase1.Enabled = false;
            }

        }

        private void dtgCertificado_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgCertificado.IsCurrentCellDirty)
            {
                dtgCertificado.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgDetalleVal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = e.RowIndex;
            if (dtgDetalleVal.Rows.Count > 0)
            {
                DetValorados.Columns["lIndAplica"].ReadOnly = false;
                if (Convert.ToInt32(dtgDetalleVal.Rows[fila].Cells["idEstadoVal"].Value) != 1)
                {
                    dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value = 0;
                }

            }
        }


        public void FomartoGridDet()
        {
            dtgDetalleVal.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgDetalleVal.Columns["nserie"].HeaderText = "Serie";
            dtgDetalleVal.Columns["ninicio"].HeaderText = "Ini.Serie";
            dtgDetalleVal.Columns["nfin"].HeaderText = "Fin.Serie";
            dtgDetalleVal.Columns["nNumVal"].HeaderText = "Nro.Val";
            dtgDetalleVal.Columns["idkardex"].HeaderText = "Nro.Kadex";
            dtgDetalleVal.Columns["dFechaOpe"].HeaderText = "Fecha.Ope";
            dtgDetalleVal.Columns["cEstadoVincu"].HeaderText = "Estado";

        }
        private void SortGridDetValEntregados()
        {
            dtgDetalleVal.Columns["idCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nserie"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["ninicio"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nfin"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["nNumVal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["idkardex"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["dFechaOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgDetalleVal.Columns["cEstadoVincu"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void txtCBNumCerti_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
            {
                cValor = "1";
            }
            else
            {
                if (Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim())==0)
                {
                    cValor = "1";
                }
            }
                cValor = this.txtCBNumCerti.Text.ToString().Trim();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
                this.btnMiniAceptar1.PerformClick();

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
            }
        }

        private void txtCBNumCerti_Validated(object sender, EventArgs e)
        {
            string cValor = this.txtCBNumCerti.Text.ToString().Trim();
            this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
           
        }



        private void chcBase1_CheckedChanged_1(object sender, EventArgs e)
        {

            if (this.chcBase1.Checked == true)
            {

                int fila = 0;
                int nContFila = 0;
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    MessageBox.Show("Seleccione Item a Anular", "Vinculación de Valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (nContFila == this.dtgDetalleVal.Rows.Count)
                {
                    lIndBloqTot = true;
                }
                idEstadoVal = 3;
                this.btnGrabar.Enabled = true;
                this.txtMotivo.Enabled = true;
                this.txtMotivo.Focus();
            }
            else
            {
                lIndBloqTot = false;
                this.txtMotivo.Enabled = false;
                this.txtMotivo.Clear();
                this.btnGrabar.Enabled = false;
            }

        }
        private void RetornaDetValorados(int idCuenta, int idVincuCuenta)
        {
            DetValorados = objValorados.CNListaDetalleValorados(idCuenta, idVincuCuenta);
            if (this.dtgDetalleVal.ColumnCount > 0)
            {
                this.dtgDetalleVal.Columns.Clear();
            }
            if (DetValorados.Rows.Count > 0)
            {
                this.dtgDetalleVal.DataSource = DetValorados;
                this.FormatoGridVal();
                this.SortGridDetValorados();
                this.HabilitarGridDetalle(true);
                if ((int)cboEstado.SelectedValue != 1)
                {
                    //this.btnEditar.Enabled = false;
                    this.chcBase1.Enabled = false;
                   // this.chcSelec.Enabled = false;
                }
                else
                {
                    // this.btnEditar.Enabled = true;
                    this.chcBase1.Enabled = true;
                   // this.chcSelec.Enabled = true;
                }


            }
            else
            {
                //this.btnEditar.Enabled = false;
                this.chcBase1.Enabled = false;
                
            }


        }
        public void HabilitarGridDetalle(Boolean bVal)
        {
            // dtValorados.
            this.dtgDetalleVal.ReadOnly = !bVal;
            this.dtgDetalleVal.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["idKardex"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["idEstadoVal"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["dFechaOpe"].ReadOnly = bVal;
            this.dtgDetalleVal.Columns["lIndAplica"].ReadOnly = !bVal;
            for (int i = 0; i < this.dtgDetalleVal.Rows.Count; i++)
            {
                if (Convert.ToInt32(this.dtgDetalleVal.Rows[i].Cells["idEstadoVal"].Value) == 1)
                {
                    this.dtgDetalleVal.Rows[i].Cells["lIndAplica"].ReadOnly = false;
                }
                else
                {
                    this.dtgDetalleVal.Rows[i].Cells["lIndAplica"].ReadOnly = true;
                }
            }

        }

        private void dtgDetalleVal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgDetalleVal.Rows.Count > 0)
            {
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    idEstadoVal = 1;
                }
            }
        }

        private void dtgDetalleVal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nContFila = 0;
            Int32 fila = 0;
            if (this.dtgDetalleVal.Rows.Count > 0)
            {
                while (fila < this.dtgDetalleVal.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtgDetalleVal.Rows[fila].Cells["lIndAplica"].Value) == 1)
                    {
                        nContFila++;
                    }
                    fila++;
                }
                if (nContFila == 0)
                {
                    this.chcBase1.Checked = false;
                    idEstadoVal = 1;
                }
            }
        }

        private void dtgDetalleVal_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDetalleVal.IsCurrentCellDirty)
            {
                dtgDetalleVal.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void frmMantenimientoCertificados_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (idCuenta!=0)
            {
                RetornaNumCuenta.CNDesbloqueaCuenta(idCuenta, clsVarGlobal.idModulo); 
            }
           
        }
    }
}
