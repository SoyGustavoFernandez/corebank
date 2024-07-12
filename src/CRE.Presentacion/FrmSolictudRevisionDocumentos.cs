using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class FrmSolictudRevisionDocumentos : frmBase
    {

        #region Variables

        private const string cTituloMsjes = "Solicitud de revisión de documentos";
        private clsRevisionDocCred _objRevision;
        private string cDirectorioDocs = "tempDocsCred";

        #endregion

        #region Constructores

        public FrmSolictudRevisionDocumentos()
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

        private void btnAgrDoc_Click(object sender, EventArgs e)
        {
            FrmAddDocRevCred frmAddDoc = new FrmAddDocRevCred();
            frmAddDoc.ShowDialog();

            if (frmAddDoc.ObjDocRevCred == null)
            {
                MessageBox.Show("No se seleccionó ningun documento.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var objDetRevision = frmAddDoc.ObjDocRevCred;

            if (_objRevision.LstDetRevisionDocCres.Any(x => x.cNomArchivo == objDetRevision.cNomArchivo && x.lVigente))
            {
                MessageBox.Show("El nombre del archivo ya existe.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _objRevision.LstDetRevisionDocCres.Add(objDetRevision);
            dtgDocumentos.DataSource = _objRevision.LstDetRevisionDocCres.Where(x => x.lVigente).ToList();
        }

        private void btnQuitDoc_Click(object sender, EventArgs e)
        {
            if (dtgDocumentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a quitar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var objDetRevision = dtgDocumentos.SelectedRows[0].DataBoundItem as clsDetRevisionDocCre;
            if (objDetRevision.idDetRevisionDocCred > 0)
            {
                var objDetEliminar = _objRevision.LstDetRevisionDocCres.First(
                    x => x.idDetRevisionDocCred == objDetRevision.idDetRevisionDocCred);
                objDetEliminar.lVigente = false;
                objDetEliminar.vArchivo = null;
            }
            else
            {
                _objRevision.LstDetRevisionDocCres.Remove(objDetRevision);
            }
            dtgDocumentos.DataSource = _objRevision.LstDetRevisionDocCres.Where(x=>x.lVigente).ToList();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _objRevision = new clsRevisionDocCred();

            HabilitarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GetDataRevision();
            GuardarRevision();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            CancelarRegistro();
            conBusCuentaCli.txtNroBusqueda.Focus();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (_objRevision == null)
            {
                MessageBox.Show("No se puede enviar a revisión. Intentelo más tarde.", cTituloMsjes, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _objRevision.idEstado = 2;
            _objRevision.dFecha = clsVarGlobal.dFecSystem.Date;

            DialogResult result = MessageBox.Show("¿Está seguro de enviar para revisión?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result != DialogResult.Yes)
                return;

            GuardarRevision();
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
            string xmlRevision = _objRevision.GetXml();

            clsDBResp objDbResp = new clsCNRevisionDocCred().CNGuardarRevison(xmlRevision);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var objRevisionDocCred = new clsCNRevisionDocCred().CNGetRevisionDocCred(conBusCuentaCli.nValBusqueda);
                CargarRevision(objRevisionDocCred);

                HabilitarControles(false);
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEnviar.Enabled = objRevisionDocCred.idEstado == 1;
                btnEditar.Enabled = _objRevision.idEstado == 1;
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
                    btnEnviar.Enabled = _objRevision.idEstado == 1;
                    btnEditar.Enabled = _objRevision.idEstado == 1;
                    btnNuevo.Enabled = false;
                }
                else
                {
                    btnEditar.Enabled = false;
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
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEnviar.Enabled = false;
        }

        private void GetDataRevision()
        {
            _objRevision.idSolicitud = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text.Trim());
            _objRevision.idEstado = 1;
            _objRevision.cMotivo = txtMotivo.Text;
            _objRevision.dFecha = clsVarGlobal.dFecSystem;
        }

        private void HabilitarControles(bool lHabil)
        {
            txtMotivo.Enabled = lHabil;
            btnAgrDoc.Enabled = lHabil;
            btnQuitDoc.Enabled = lHabil;

            btnNuevo.Enabled = !lHabil;
            btnEditar.Enabled = !lHabil;
            btnGrabar.Enabled = lHabil;
            btnCancelar.Enabled = lHabil;
            btnEnviar.Enabled = !lHabil;
        }

        #endregion

    }
}
