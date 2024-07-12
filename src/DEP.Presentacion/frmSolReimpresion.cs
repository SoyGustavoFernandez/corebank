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
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmSolReimpresion : frmBase
    {
        private int p_idProd = 0, idTipOpe = 0, p_idCta = 0;

        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNImpresion clsImpresion = new clsCNImpresion();
        clsCNValorados objValorados = new clsCNValorados();
        clsCNListaFormatoImp ListaFormato = new clsCNListaFormatoImp();

        public frmSolReimpresion()
        {
            InitializeComponent();
        }

        private void frmSolReimpresion_Load(object sender, EventArgs e)
        {
            idTipOpe = 16;
            conBusCtaAho.nTipOpe = idTipOpe;
            conBusCtaAho.pnIdMon = 0;  //Para Cancelación no es necesario la moneda, debe listar todas las Cuentas.
            cboMotivos.CargarMotivos(6);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && conBusCtaAho.idcuenta > 0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                if (Convert.ToInt32(p_idCta) > 0)
                {
                    this.DatosCuenta();

                }
            }
            else
            {
                this.conBusCtaAho.txtNroCta.Focus();
            }
        }

        private void DatosCuenta()
        {
            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(p_idCta, "1", idTipOpe);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                //---------------------------------------------------------------------------
                //------Validar el Estado de la Cuenta
                //---------------------------------------------------------------------------
                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idEstado"]) == 4)
                {
                    MessageBox.Show("La Cuenta se Encuentra en Estado Pre Solicitado, No puede Imprimir...", "Impresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--==================================================================================
                //--Datos generales de la Cuenta
                //--==================================================================================
                this.txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                this.cboMoneda.SelectedValue = dtbNumCuentas.Rows[0]["idMoneda"].ToString();
                this.cboTipoCuenta.SelectedValue = dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString();
                this.dtpCorto1.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]);
                bool lIsRequeCert = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsRequeCert"]);

                //--==================================================================================
                //--Validar si ya Tiene Certificado
                //--==================================================================================
                if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNumeCertificado"]) > 0)
                {
                    txtCodCertificado.Text = dtbNumCuentas.Rows[0]["nNumeCertificado"].ToString();
                    if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNroFolio"]) > 0)
                    {
                        txtNroFolio.Text = dtbNumCuentas.Rows[0]["nNroFolio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Folio no Existe, Inconsistencia de datos...Por Favor Revisar", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarControles();
                        conBusCtaAho.LimpiarControles();
                        this.btnCancelar.Enabled = false;
                        this.conBusCtaAho.btnBusCliente.Enabled = true;
                        this.conBusCtaAho.txtCodAge.Focus();
                        return;
                    }
                }
                
                //--==================================================================================
                //--Se debe Definir si se va Imprimir la Constancia o No
                //--==================================================================================
                if (lIsRequeCert)
                {
                    llenarTiposDeDocumento(1,p_idCta);
                }
                else
                {
                    llenarTiposDeDocumento(0, p_idCta);
                }
                btnEnviar.Enabled = true;
                dtgFormatos.Enabled = true;
                cboMotivos.Enabled = true;
                txtMotReimpresion.Enabled = true;
                conBusCtaAho.btnBusCliente.Enabled = false;
                conBusCtaAho.HabDeshabilitarCtrl(false);
                cboMotivos.Focus();
            }
            else
            {
                MessageBox.Show("Número de Cuenta no Válido para Reimpresión de Formatos", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                this.btnCancelar.Enabled = false;
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
                return;
            }
            
        }

        private void llenarTiposDeDocumento(int idOpcion,int idCuenta)
        {
            DataTable dt = ListaFormato.CNListaFormatosReimpresion(idOpcion, idCuenta);
            dtgFormatos.DataSource = dt;
            dtgFormatos.ReadOnly = false;
            dtgFormatos.Columns["idTipDocImp"].Visible = false;
            dtgFormatos.Columns["lIsImpresion"].Width = 130;
            dtgFormatos.Columns["lIsImpresion"].HeaderText = "Impresiones";
            dtgFormatos.Columns["lIsImpresion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFormatos.Columns["cDescripcion"].HeaderText = "Documentos para Reimpresión";
            dtgFormatos.Columns["cDescripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFormatos.Columns["cDescripcion"].Width = 350;
            dtgFormatos.Columns["nNroImpresiones"].HeaderText = "Nro Impresiones";
            dtgFormatos.Columns["nNroImpresiones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dt.Columns["cDescripcion"].ReadOnly = true;
            dtgFormatos.Columns["cDescripcion"].ReadOnly = true;
            dt.Columns["lIsImpresion"].ReadOnly = false;
            dtgFormatos.Columns["lIsImpresion"].ReadOnly = false;
        }

        private void LimpiarControles()
        {
            p_idCta = 0;
            this.conBusCtaAho.LimpiarControles();
            this.txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtCodCertificado.Text = "";
            txtNroFolio.Text = "";
            cboMotivos.SelectedValue = 1;
            txtMotReimpresion.Clear();
            if (dtgFormatos.Rows.Count > 0)
            {
                ((DataTable)dtgFormatos.DataSource).Rows.Clear();
            }
            dtgFormatos.Refresh();
        }

        private bool ValidarDatosIngresados()
        {
            int nVal = 0;
            DataTable dtDocs = (DataTable)dtgFormatos.DataSource;
            for (int i = 0; i < dtDocs.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtDocs.Rows[i]["lIsImpresion"].ToString()))
                {
                    nVal = nVal + 1;
                }
            }

            if (nVal==0)
            {
                MessageBox.Show("Debe Seleccionar por lo menos un Documento a Reimprimir...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgFormatos.Focus();
                return false;
            }

            if (Convert.ToInt32(cboMotivos.SelectedIndex) == -1)
            {
                MessageBox.Show("Debe seleccionar el Motivo de reimpresión...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboMotivos.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotReimpresion.Text))
            {
                MessageBox.Show("Debe registrar el motivo de reimpresión de documentos...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMotReimpresion.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            this.btnEnviar.Enabled = false;
            this.conBusCtaAho.HabDeshabilitarCtrl(true);
            this.conBusCtaAho.btnBusCliente.Enabled = true;
            this.conBusCtaAho.txtCodAge.Focus();            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados())
            {
                return;
            }
            //===================================================================
            //--XML de los Documentos
            //===================================================================
            DataTable dtDocs = (DataTable)dtgFormatos.DataSource;
            DataSet dsDocs = new DataSet("dsDocumentos");
            dsDocs.Tables.Add(dtDocs);
            string xmlDocs = clsCNFormatoXML.EncodingXML(dsDocs.GetXml());

            string x_cMotCambio = txtMotReimpresion.Text;
            int x_idCuenta = conBusCtaAho.idcuenta,
               x_idMotivo = Convert.ToInt16(cboMotivos.SelectedValue);

            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
            DataTable dtSol = solicitud.EnviarSolicitud(clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCtaAho.txtCodCli.Text), 115, 1, Convert.ToInt32(cboMoneda.SelectedValue),
                                        p_idProd, 0, p_idCta, clsVarGlobal.dFecSystem, Convert.ToInt32(cboMotivos.SelectedValue), x_cMotCambio, 1,
                                        Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario));
            if (Convert.ToInt32(dtSol.Rows[0]["idEstadoSol"].ToString()) == 1)
            {
                int x_idSolicitud = Convert.ToInt32(dtSol.Rows[0]["idSolAproba"].ToString());
                DataTable dtRegSol = ListaFormato.CNRegistraReimpresionDocs(x_idCuenta, x_idMotivo, x_cMotCambio,x_idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, xmlDocs);
                if (Convert.ToInt32(dtSol.Rows[0]["idSolAproba"].ToString()) > 0)
                {
                    MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + dtSol.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtRegSol.Rows[0]["cMensaje"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEnviar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnEnviar.Enabled = false;
            }
            dsDocs.Dispose();
            dtDocs.Dispose();
            btnEnviar.Enabled = false;
            dtgFormatos.Enabled = false;
            cboMotivos.Enabled = false;
            txtMotReimpresion.Enabled = false;
        }

    }
}
