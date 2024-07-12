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
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRecepcionValorado : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();

        public frmRecepcionValorado()
        {
            InitializeComponent();
        }

        private void frmRecepcionValorado_Load(object sender, EventArgs e)
        {
            CargarOrdenesPago();
            CargarCertificados();
        }

        private void CargarOrdenesPago()
        {
            DataTable dtSolOP = clsOpeValorado.CNValoradosParaEnvio(clsVarGlobal.nIdAgencia, 4); //--4--> Estado Enviado
            dtgSolOP.ReadOnly = false;
            dtgSolOP.DataSource = dtSolOP;

            dtgSolOP.Columns["idMoneda"].Visible = false;
            dtgSolOP.Columns["idAgencia"].Visible = false;
            dtgSolOP.Columns["idEstadoVal"].Visible = false;
            dtgSolOP.Columns["cModPagOP"].Visible = false;
            dtgSolOP.Columns["cNomCorto"].Visible = false;

            dtgSolOP.Columns["idSolicitudOP"].HeaderText = "Solicitud";
            dtgSolOP.Columns["idSolicitudOP"].Width = 50;
            dtgSolOP.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolOP.Columns["idCuenta"].Width = 60;
            dtgSolOP.Columns["nNumTalonarios"].HeaderText = "Talonarios";
            dtgSolOP.Columns["nNumTalonarios"].Width = 55;
            dtgSolOP.Columns["nCantidadPorTal"].HeaderText = "Cantidad";
            dtgSolOP.Columns["nCantidadPorTal"].Width = 45;
            dtgSolOP.Columns["dFechaSol"].HeaderText = "Fec. Solicitud";
            dtgSolOP.Columns["dFechaSol"].Width = 70;
            dtgSolOP.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgSolOP.Columns["cEstadoVal"].Width = 60;
            dtgSolOP.Columns["lok"].HeaderText = "Recepción";
            dtgSolOP.Columns["lok"].Width = 40;

            dtgSolOP.Columns["idSolicitudOP"].ReadOnly = true;
            dtgSolOP.Columns["idCuenta"].ReadOnly = true;
            dtgSolOP.Columns["nNumTalonarios"].ReadOnly = true;
            dtgSolOP.Columns["nCantidadPorTal"].ReadOnly = true;
            dtgSolOP.Columns["dFechaSol"].ReadOnly = true;
            dtgSolOP.Columns["cNomCorto"].ReadOnly = true;
            dtgSolOP.Columns["cModPagOP"].ReadOnly = true;
            dtgSolOP.Columns["cEstadoVal"].ReadOnly = true;
            dtSolOP.Columns["lok"].ReadOnly = false;
            dtgSolOP.Columns["lok"].ReadOnly = false;
            btnRecibidoOP.Enabled = true;
            btnCancelarOP.Enabled = true;
            if (dtSolOP.Rows.Count <= 0)
            {
                btnRecibidoOP.Enabled = false;
                btnCancelarOP.Enabled = false;
                btnRechazarOP.Enabled = false;
            }
            else
            {
                btnRecibidoOP.Enabled = true;
                btnCancelarOP.Enabled = true;
                btnRechazarOP.Enabled = true ;
            }
        }

        private void CargarCertificados()
        {
            DataTable dtCert = clsOpeValorado.CNCertificadosParaEnvio(clsVarGlobal.nIdAgencia,0, 3);
            dtgCertificado.DataSource = dtCert;
            FormatoGridCert();
            if (dtCert.Rows.Count<=0)
            {
                btnRecibidoCert.Enabled = false;
                btnCancelarCert.Enabled = false;
                btnRechazarConstancia.Enabled = false;
            }
            else
            {
                btnRecibidoCert.Enabled = true;
                btnCancelarCert.Enabled = true;
                btnRechazarConstancia.Enabled = true;
            }
        }

        private void FormatoGridCert()
        {
            dtgCertificado.Columns["idVincuCuenta"].Visible = false;
            dtgCertificado.Columns["idTipoValorado"].Visible = false;
            dtgCertificado.Columns["idValorado"].Visible = false;
            dtgCertificado.Columns["idAgencia"].Visible = false;

            dtgCertificado.Columns["nNroFolio"].HeaderText = "Nro de Folio";
            dtgCertificado.Columns["cEstadoVal"].HeaderText = "Estado del Certificado";
            dtgCertificado.Columns["lVigente"].HeaderText = "Recepción";

        }

        private void btnSalirOP_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalirCert_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRecibidoOP_Click(object sender, EventArgs e)
        {
            if (!ValidaEnvioOP())
            {
                return;
            }

            //===================================================================
            //--Generar XML del Detalle de Ordenes de Pago
            //===================================================================
            DataTable dtOP = (DataTable)dtgSolOP.DataSource;
            DataSet dsValoradoOP = new DataSet("dsValorado");
            dsValoradoOP.Tables.Add(dtOP);
            string xmlDetOP = clsCNFormatoXML.EncodingXML(dsValoradoOP.GetXml());
            string cDescri = txtDescriOP.Text;

            DataTable dtEnviOP = clsOpeValorado.CNRegistraEnvioOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetOP, 5, cDescri,"0");
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Recepción de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOrdenesPago();
                txtDescriOP.Text = "";
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Recepción de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private bool ValidaEnvioOP()
        {
            if (dtgSolOP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen, Ordenes de Pago para su Recepción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int k = 0;
            for (int i = 0; i < dtgSolOP.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgSolOP.Rows[i].Cells["lok"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe Seleccionar las Ordenes a Recepcionar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgSolOP.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescriOP.Text))
            {
                MessageBox.Show("Debe Registrar la Descripción de la Recepcion de las Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescriOP.Focus();
                return false;
            }
            return true;
        }

        private void btnRecibidoCert_Click(object sender, EventArgs e)
        {
            if (dtgCertificado.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen certificados para su Recepción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCertificado.Focus();
                txtDescriCert.Text = "";
                return;
            }
            int k = 0;
            for (int i = 0; i < dtgCertificado.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgCertificado.Rows[i].Cells["lVigente"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe Seleccionar los certificados", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCertificado.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescriCert.Text))
            {
                MessageBox.Show("Debe Registrar la Descripción de la Recepcion de los Certificados", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescriCert.Focus();
                return;
            }

            //===================================================================
            //--Generar XML del Detalle de Certificados
            //===================================================================
            DataTable dtCert = (DataTable)dtgCertificado.DataSource;
            DataSet dsValoradoCert = new DataSet("dsValorado");
            dsValoradoCert.Tables.Add(dtCert);
            string xmlDetCert = clsCNFormatoXML.EncodingXML(dsValoradoCert.GetXml());
            string cDescri = txtDescriCert.Text;

            DataTable dtEnviCert = clsOpeValorado.CNRegistraEnvioCertificados(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetCert, 6, cDescri,"0");
            if (Convert.ToInt32(dtEnviCert.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviCert.Rows[0]["cMensage"].ToString(), "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCertificados();
            }
            else
            {
                MessageBox.Show(dtEnviCert.Rows[0]["cMensage"].ToString(), "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCancelarCert_Click(object sender, EventArgs e)
        {
            txtDescriCert.Text = "";
            txtDescriCert.Focus();
        }

        private void btnCancelarOP_Click(object sender, EventArgs e)
        {
            txtDescriOP.Text = "";
            txtDescriOP.Focus();
        }

        private void tabOP_Click(object sender, EventArgs e)
        {

        }

        private void btnRechazarOP_Click(object sender, EventArgs e)
        {
            if (dtgSolOP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen certificados para su rechazo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCertificado.Focus();
                txtDescriCert.Text = "";
                return;
            }
            int k = 0;
            for (int i = 0; i < dtgSolOP.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgSolOP.Rows[i].Cells["lok"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe seleccionar las ordenes a rechazar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgSolOP.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDescriOP.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el motivo de rechazo en la descripción.", "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //===================================================================
            //--Generar XML del Detalle de Ordenes de Pago
            //===================================================================
            DataTable dtOP = (DataTable)dtgSolOP.DataSource;
            DataSet dsValoradoOP = new DataSet("dsValorado");
            dsValoradoOP.Tables.Add(dtOP);
            string xmlDetOP = clsCNFormatoXML.EncodingXML(dsValoradoOP.GetXml());
            string cDescri = txtDescriOP.Text;

            DataTable dtRechaCert = clsOpeValorado.CNRechazoValoradoRecepOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetOP, cDescri);
            if (Convert.ToInt32(dtRechaCert.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtRechaCert.Rows[0]["cMensage"].ToString(), "Rechazo de ordenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                MessageBox.Show(dtRechaCert.Rows[0]["cMensage"].ToString(), "Rechazo de ordenes de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOrdenesPago();
            }    
        }

        private void btnRechazarConstancia_Click(object sender, EventArgs e)
        {
            if (dtgCertificado.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen certificados para su Recepción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCertificado.Focus();
                txtDescriCert.Text = "";
                return;
            }

            int k = 0;
            for (int i = 0; i < dtgCertificado.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgCertificado.Rows[i].Cells["lVigente"].Value))
                {
                    k = 1;
                    break;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Debe seleccionar las ordenes a rechazar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgSolOP.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescriCert.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el motivo de rechazo en la descripción.", "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //===================================================================
            //--Generar XML del Detalle de Certificados
            //===================================================================
            DataTable dtCert = (DataTable)dtgCertificado.DataSource;
            DataSet dsValoradoCert = new DataSet("dsValorado");
            dsValoradoCert.Tables.Add(dtCert);
            string xmlDetCert = clsCNFormatoXML.EncodingXML(dsValoradoCert.GetXml());
            string cDescri = txtDescriCert.Text;

            DataTable dtRechaCert = clsOpeValorado.CNRechazoValoradoRecepCert(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetCert,  cDescri);
            if (Convert.ToInt32(dtRechaCert.Rows[0]["idRpta"].ToString()) == 0)
            {
               MessageBox.Show(dtRechaCert.Rows[0]["cMensage"].ToString(), "Rechazo de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);             
            }
            else
            {
                
                MessageBox.Show(dtRechaCert.Rows[0]["cMensage"].ToString(), "Rechazo de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCertificados();
            }

        }

    }
}
