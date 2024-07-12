using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class FrmRevisarDocCred : frmBase
    {
        #region Variables

        private const string cTituloMsjes = "Revisión de documentos de créditos";
        private clsRevisionDocCred _objRevision;
        private string cDirectorioDocs = "tempDocsCred";

        #endregion

        #region Constructores

        public FrmRevisarDocCred()
        {
            InitializeComponent();
            conBusCuentaCli.cTipoBusqueda = "S";
            conBusCuentaCli.cEstado = "[1,13]";
            cboAsesor.ListarPersonal(0);
        }

        #endregion

        #region Eventos

        private void FrmSolictudRevisionDocumentos_Load(object sender, EventArgs e)
        {
            dtgDocumentos.AutoGenerateColumns = false;
            grbDatSol.Enabled = false;
            CancelarRegistro();
            LimpiarControles();
            conBusCuentaCli.txtNroBusqueda.Focus();
        }

        private void dtgDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dtgDocumentos.CurrentCell.OwningColumn.Name.Equals("btnVer"))
                return;

            if (dtgDocumentos.SelectedRows.Count == 0)
                return;

            var objDetRevision = dtgDocumentos.SelectedRows[0].DataBoundItem as clsDetRevisionDocCre;

            if (objDetRevision == null)
                return;

            string cExt = objDetRevision.cExtension;
            string cNomFile = objDetRevision.cNomArchivo;
            string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, cDirectorioDocs);

            if (!Directory.Exists(cDirectorio))
            {
                Directory.CreateDirectory(cDirectorio);
            }

            string ruta = String.Format("{0}\\{1}", cDirectorio, cNomFile);
            File.WriteAllBytes(ruta, (objDetRevision.vArchivo));
            frmVisualisarDocRiesgos frmVerDoc = new frmVisualisarDocRiesgos(cDirectorio, cNomFile, cExt);
            frmVerDoc.ShowDialog();
        }

        private void conBusCuentaCli_OnCuentaChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (_objRevision == null)
            {
                MessageBox.Show("No se puede enviar a revisión. Intentelo más tarde.", cTituloMsjes, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("¿Está seguro de realizar la acción?", cTituloMsjes, MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _objRevision.idEstado = 3;
            _objRevision.cComentRevisor = txtComentRev.Text.Trim();
            _objRevision.idUsuRevision = clsVarGlobal.User.idUsuario;
            _objRevision.dFecha = clsVarGlobal.dFecSystem.Date;
            GuardarRevision();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            CancelarRegistro();
            conBusCuentaCli.txtNroBusqueda.Focus();
        }

        private void dtgDocumentos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dtgDocumentos.Rows)
            {
                var objDetRev = row.DataBoundItem as clsDetRevisionDocCre;
                if (objDetRev == null)
                    continue;
                if (row.Cells["iconDoc"].Value != null)
                    continue;

                switch (objDetRev.cExtension.Replace(".", "").ToUpper())
                {
                    case "JPG":
                        row.Cells["iconDoc"].Value = Properties.Resources.ImgPng;
                        break;
                    case "PNG":
                        row.Cells["iconDoc"].Value = Properties.Resources.ImgPng;
                        break;
                    case "DOC":
                        row.Cells["iconDoc"].Value = Properties.Resources.ImgWord;
                        break;
                    case "DOCX":
                        row.Cells["iconDoc"].Value = Properties.Resources.ImgWord;
                        break;
                    case "PDF":
                        row.Cells["iconDoc"].Value = Properties.Resources.ImgPdf;
                        break;
                }
            }
        }

        #endregion

        #region Métodos

        private void GuardarRevision()
        {
            _objRevision.LstDetRevisionDocCres = null;
            string xmlRevision = _objRevision.GetXml();

            clsDBResp objDbResp = new clsCNRevisionDocCred().CNGuardarRevison(xmlRevision);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var objRevisionDocCred = new clsCNRevisionDocCred().CNGetRevisionDocCred(conBusCuentaCli.nValBusqueda);
                CargarRevision(objRevisionDocCred);

                HabilitarControles(false);
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarRevision(clsRevisionDocCred objRevisionDocCred)
        {
            _objRevision = objRevisionDocCred;
            lblEstado.Text = objRevisionDocCred.cEstado;
            txtMotivo.Text = objRevisionDocCred.cMotivo;
            txtComentRev.Text = objRevisionDocCred.cComentRevisor;
            objRevisionDocCred.LstDetRevisionDocCres =
                new clsCNRevisionDocCred().CNGetDetRevisionDocCred(objRevisionDocCred.idRevisionDocCred);
            dtgDocumentos.DataSource = objRevisionDocCred.LstDetRevisionDocCres.Where(x => x.lVigente).ToList();
        }

        private void LimpiarControles()
        {
            cboAgencia.SelectedIndex = -1;
            cboAsesor.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtMonto.Text = string.Empty;
            txtMotivo.Text = string.Empty;
            txtComentRev.Text = string.Empty;
            lblEstado.Text = string.Empty;
            dtgDocumentos.DataSource = null;

            conBusCuentaCli.limpiarControles();
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;
        }

        private void CargarDatos()
        {
            int idSolicitud = conBusCuentaCli.nValBusqueda;

            if (idSolicitud == 0)
            {
                CancelarRegistro();
            }
            else
            {
                DataTable dtSolicitud = new clsCNSolicitud().ConsultaSolicitud(idSolicitud);

                if (dtSolicitud.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos de la solicitud.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow drSolicitud = dtSolicitud.AsEnumerable().First();

                cboAgencia.SelectedValue = Convert.ToInt32(drSolicitud["idAgencia"]);
                cboAsesor.SelectedValue = drSolicitud["idAsesor"] == DBNull.Value ? 0 : Convert.ToInt32(drSolicitud["idUsuario"]);
                cboMoneda.SelectedValue = Convert.ToInt32(drSolicitud["IdMoneda"]);
                txtMonto.Text = string.Format("{0:#,0.00}", drSolicitud["nCapitalSolicitado"]);

                _objRevision = new clsCNRevisionDocCred().CNGetRevisionDocCred(idSolicitud);

                HabilitarControles(false);
                if (_objRevision != null)
                {
                    CargarRevision(_objRevision);
                    txtComentRev.Enabled = _objRevision.idEstado == 2;
                    btnGrabar.Enabled = _objRevision.idEstado == 2;
                    activarControlObjetos(this, EventoFormulario.EDITAR);
                    if (_objRevision.idEstado != 2)
                    {
                        MessageBox.Show("El estado de la solicitud de revisión es distinto de ENVIADO.", cTituloMsjes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron solicitudes en estado ENVIADO.", cTituloMsjes,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                btnCancelar.Enabled = true;
            }
        }

        private void CancelarRegistro()
        {
            _objRevision = null;
            LimpiarControles();
            conBusCuentaCli.txtNroBusqueda.Focus();
            HabilitarControles(false);
            btnCancelar.Enabled = false;
        }

        private void HabilitarControles(bool lHabil)
        {
            txtComentRev.Enabled = lHabil;

            btnGrabar.Enabled = lHabil;
            btnCancelar.Enabled = lHabil;
        }

        #endregion
    }
}
