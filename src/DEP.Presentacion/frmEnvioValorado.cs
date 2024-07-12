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
    public partial class frmEnvioValorado : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();

        public frmEnvioValorado()
        {
            InitializeComponent();
        }

        private void frmEnvioValorado_Load(object sender, EventArgs e)
        {
            StockCertificados();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            CargarSolParaEnvio();

        }

        private void CargarSolParaEnvio()
        {
            btnTransOP.Enabled = false;
            txtDescriOP.Enabled = false;
            if (!ValidarDatos())
            {
                return;
            }

            if (dtgSolOP.Rows.Count > 0)
            {
                ((DataTable)dtgSolOP.DataSource).Rows.Clear();
            }
            dtgSolOP.Refresh();

            DataTable dtSolOP = clsOpeValorado.CNValoradosParaEnvio(Convert.ToInt16(cboAgencias.SelectedValue), 3); //--Estado Impreso
            if (dtSolOP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Ordenes de Pago para Envio", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            else
            {
                dtgSolOP.ReadOnly = false;
                dtgSolOP.DataSource = dtSolOP;

                dtgSolOP.Columns["idMoneda"].Visible = false;
                dtgSolOP.Columns["idAgencia"].Visible = false;
                dtgSolOP.Columns["idEstadoVal"].Visible = false;
                dtgSolOP.Columns["cModPagOP"].Visible = false;

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
                dtgSolOP.Columns["cNomCorto"].HeaderText = "Agencia Destino";
                dtgSolOP.Columns["cNomCorto"].Width = 100;
                dtgSolOP.Columns["cEstadoVal"].HeaderText = "Estado";
                dtgSolOP.Columns["cEstadoVal"].Width = 60;
                dtgSolOP.Columns["lok"].HeaderText = "Envio";
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
                btnTransOP.Enabled = true;
                txtDescriOP.Enabled = true;
                conBusColOp.Focus();
            }
        }

        private bool ValidarDatos()
        {
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return false;
            }
            return true;
        }

        private void btnProcesarCer_Click(object sender, EventArgs e)
        {
            btnTransCer.Enabled = false;
            txtDescriCert.Enabled = false;
            if (!ValidarDatosCert())
            {
                return;
            }
            DataTable dtCert = clsOpeValorado.CNCertificadosParaEnvio(Convert.ToInt16(cboAgeCert.SelectedValue), Convert.ToInt32(nudCantidad.Value), 2);
            if (dtCert.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Certificados en el Almacén", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            else
            {
                dtgCertificado.DataSource = dtCert;
                FormatoGridCert();
                btnCanCer.Enabled = true;
                nudCantidad.Enabled = false;
                cboAgeCert.Enabled = false;
                btnTransCer.Enabled = true;
                txtDescriCert.Enabled = true;
                conBusColConstancia.Focus();
            }
        }

        private void FormatoGridCert()
        {
            dtgCertificado.Columns["idVincuCuenta"].Visible = false;
            dtgCertificado.Columns["idTipoValorado"].Visible = false;
            dtgCertificado.Columns["idAgencia"].Visible = false;

            dtgCertificado.Columns["idValorado"].HeaderText = "Id. Valorado";
            dtgCertificado.Columns["idValorado"].Width = 60;
            dtgCertificado.Columns["nNroFolio"].HeaderText = "Nro Folio";
            dtgCertificado.Columns["nNroFolio"].Width = 80;
            dtgCertificado.Columns["cEstadoVal"].HeaderText = "Estado Valorado";
            dtgCertificado.Columns["cEstadoVal"].Width = 120;
            dtgCertificado.Columns["cNomAgencia"].HeaderText = "Agencia Destino";
            dtgCertificado.Columns["cNomAgencia"].Width = 120;
            dtgCertificado.Columns["lVigente"].HeaderText = "Envio";
            dtgCertificado.Columns["lVigente"].Width = 50;

        }

        private void StockCertificados()
        {
            DataTable dtCert = clsOpeValorado.CNCertificadosParaEnvio(0, 0, 1);
            nudIniValorado.Value = Convert.ToInt32(dtCert.Rows[0]["nMinFolio"].ToString());
            nudFinValorado.Value = Convert.ToInt32(dtCert.Rows[0]["nMaxFolio"].ToString());
            nudStock.Value = Convert.ToInt32(dtCert.Rows[0]["nCanCerti"].ToString());
        }

        private bool ValidarDatosCert()
        {
            if (nudStock.Value <= 0)
            {
                MessageBox.Show("No Hay Certificados en Almacén...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (nudIniValorado.Value > nudFinValorado.Value)
            {
                MessageBox.Show("El Folio Inicial, no Puede Ser Mayor que el Folio Final...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboAgeCert.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgeCert.Focus();
                return false;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("la Cantidad a Enviar no es Válido...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudCantidad.Focus();
                return false;
            }
            if (nudStock.Value < nudCantidad.Value)
            {
                 MessageBox.Show("la cantidad a enviar debe ser menor al stock...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudCantidad.Focus();
                return false;
            }

            return true;
        }

        private bool ValidaEnvioOP()
        {
            if (dtgSolOP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen, Ordenes de Pago para Envió", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
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
                MessageBox.Show("Debe Seleccionar las Ordenes a Enviar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgSolOP.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescriOP.Text))
            {
                MessageBox.Show("Debe Registrar la Descripción, para el Envió", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescriOP.Focus();
                return false;
            }
            if (conBusColOp.idUsu.Equals(""))
            {
                MessageBox.Show("Debe elegir al colaborador responsable", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnSalirOP_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalirCer_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTransOP_Click(object sender, EventArgs e)
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

            DataTable dtEnviOP = clsOpeValorado.CNRegistraEnvioOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetOP, 4, cDescri,conBusColOp.idUsu);
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Envió de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTransOP.Enabled = false;
                cboAgencias.Enabled = false;
                dtgSolOP.Enabled = false;
                btnProcesar.Enabled = false;
                txtDescriOP.Enabled = false;
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Envió de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void btnTransCer_Click(object sender, EventArgs e)
        {
            if (dtgCertificado.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen certificados para Envió", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgCertificado.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescriCert.Text))
            {
                MessageBox.Show("Debe Registrar la Descripción, para el Envió", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescriCert.Focus();
                return;
            }
            if (conBusColConstancia.idUsu.Equals(""))
            {
                MessageBox.Show("Debe elegir al colaborador responsable", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            DataTable dtEnviCert = clsOpeValorado.CNRegistraEnvioCertificados(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlDetCert, 4, cDescri,conBusColConstancia.idUsu);
            if (Convert.ToInt32(dtEnviCert.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtEnviCert.Rows[0]["cMensage"].ToString(), "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesarCer.Enabled = false;
                btnTransCer.Enabled = false;
                btnCanCer.Enabled = true;
                StockCertificados();
            }
            else
            {
                MessageBox.Show(dtEnviCert.Rows[0]["cMensage"].ToString(), "Envió de Certificados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCanOP_Click(object sender, EventArgs e)
        {
            if (dtgSolOP.Rows.Count > 0)
            {
                ((DataTable)dtgSolOP.DataSource).Rows.Clear();
            }
            dtgSolOP.Refresh();
            txtDescriOP.Text = "";
            txtDescriOP.Enabled = false;
            cboAgencias.Enabled = true;
            btnProcesar.Enabled = true;
            dtgSolOP.Enabled = true;
            cboAgencias.Focus();
            conBusColOp.LimpiarDatos();
        }

        private void btnCanCer_Click(object sender, EventArgs e)
        {
            if (dtgCertificado.Rows.Count > 0)
            {
                ((DataTable)dtgCertificado.DataSource).Rows.Clear();
            }
            dtgCertificado.Refresh();
            txtDescriCert.Text = "";
            txtDescriCert.Enabled = false;
            btnCanCer.Enabled = true;
            nudCantidad.Enabled = true;
            cboAgeCert.Enabled = true;
            nudCantidad.Value = 0;
            btnProcesarCer.Enabled = true;
            btnTransCer.Enabled = false;
            nudCantidad.Focus();
            conBusColConstancia.LimpiarDatos();
        }

        private void btnSalirCert_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarCert_Click(object sender, EventArgs e)
        {

        }

        private void btnRecibidoCert_Click(object sender, EventArgs e)
        {

        }

        private void conBusColOp_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColOp.idUsu==null)
            {
                MessageBox.Show("Debe elegir al colaborador responsable", "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColOp.LimpiarDatos();
                return;
            }
            if (conBusColOp.idUsu.Equals(""))
            {
                MessageBox.Show("Debe elegir al colaborador responsable", "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColOp.LimpiarDatos();
                return;
            }
            int idAgenciaDes = 0, indice=0;
            string cAgenciaDes = "";
            if (dtgSolOP.RowCount<=0)
            {
                MessageBox.Show("No existe ordenes de pago para el envío", "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColOp.LimpiarDatos();
                return;
            }
            indice = dtgSolOP.SelectedRows[0].Index;
            idAgenciaDes = Convert.ToInt32(dtgSolOP["idAgencia", indice].Value);
            cAgenciaDes = dtgSolOP["cNomCorto", indice].Value.ToString();

            if (!conBusColOp.idAgencia.Equals(idAgenciaDes.ToString()))
            {
                MessageBox.Show("El colaborador responsable debe pertenecer \n a la agencia " + cAgenciaDes, "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColOp.LimpiarDatos();
                return;
            }
        }

        private void conBusColConstancia_BuscarUsuario(object sender, EventArgs e)
        {
            if (conBusColConstancia.idUsu.Equals(""))
            {
                MessageBox.Show("Debe elegir al colaborador responsable", "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColConstancia.LimpiarDatos();
                return;
            }
      

            int idAgenciaDes = 0,indice;
            string cAgenciaDes = "";
            if (dtgCertificado.RowCount <= 0)
            {
                MessageBox.Show("No existe constancias para el envío", "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColConstancia.LimpiarDatos();
                return;
            }

            indice = dtgCertificado.SelectedRows[0].Index;
            idAgenciaDes = Convert.ToInt32(dtgCertificado["idAgencia", indice].Value);
            cAgenciaDes = dtgCertificado["cNomAgencia",indice].Value.ToString();
            if (!conBusColConstancia.idAgencia.Equals(idAgenciaDes.ToString()))
            {
                MessageBox.Show("El colaborador responsable debe pertenecer \n a la agencia " + cAgenciaDes, "Envío de valorados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusColConstancia.LimpiarDatos();
                return;
            }
        }
    }
}
