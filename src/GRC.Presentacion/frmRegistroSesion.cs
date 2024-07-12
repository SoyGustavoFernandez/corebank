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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GRC.CapaNegocio;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace GRC.Presentacion
{
    public partial class frmRegistroSesion : frmBase
    {
        #region Variables

        clsCNConsejo consejo = new clsCNConsejo();
        clsCNIntegranteConsejo integrante = new clsCNIntegranteConsejo();
        clsCNSesionConsejo sesionconsejo = new clsCNSesionConsejo();
        Thread hiloDocumento;
        DataTable dtDocumentos = new DataTable("dtDocumentos");
        int idSesion = 0;
        #endregion

        public frmRegistroSesion()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            crearEstructuraTDocuemnto();
            cargarConsejos();
            if (dtgConsejos.SelectedRows.Count > 0)
            {
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
            }
        }        

        private void dtgConsejos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgConsejos.SelectedRows.Count > 0)
            {
                cargarIntegrantes(Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value));
                
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            dtgConsejos.Enabled=false;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            dtgConsejos.Enabled = false;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;           
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            dtgConsejos.Enabled = true;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string xmlAsistentes = crearXmlAsistentes();

                var idConsejo=Convert.ToInt32(dtgConsejos.SelectedRows[0].Cells["idConsejo"].Value);
                var dtResultado= sesionconsejo.InsertarSesionConsejo(txtDescripcion.Text, idConsejo, Convert.ToInt32(cboTipoSesion2.SelectedValue), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,
                                                    txtAsunto.Text.Trim(),txtAcuerdos.Text.Trim(),txtObservaciones.Text.Trim(),true,xmlAsistentes);
                MessageBox.Show("Los datos se guardaron correctamente", "Registro de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                idSesion = Convert.ToInt32(dtResultado.Rows[0]["idSesionConsejo"]);

                hiloDocumento = new Thread(guardarDocumentos);
                hiloDocumento.Start();
            }
        }

        private string crearXmlAsistentes()
        {
            DataTable dtAsistentes = new DataTable("dtAsistentes");
            dtAsistentes.Columns.Add("idCli", typeof(int));
            DataRow drAsistente;
            dtgIntegrantes.EndEdit();
            foreach (DataGridViewRow item in dtgIntegrantes.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lAsistenca"].Value) == true)
                {
                    drAsistente = dtAsistentes.NewRow();
                    drAsistente["idCli"] = Convert.ToInt32(item.Cells["idCli"].Value);
                    dtAsistentes.Rows.Add(drAsistente);
                }                
            }
            DataSet dsAsistente = new DataSet("dsAsistente");
            dsAsistente.Tables.Add(dtAsistentes);

            return dsAsistente.GetXml();
        }

        private void guardarDocumentos()
        {
            foreach (DataGridViewRow item in dtgDocumentos.Rows)
            {
                var cDocumentoSesion = item.Cells["cDocumentoSesion"].Value.ToString();
                var cExtension = item.Cells["cExtension"].Value.ToString();
                var vDocumentoSesion = (byte[])item.Cells["vDocumentoSesion"].Value;
                sesionconsejo.InsertarDocumentosSesion(idSesion, cDocumentoSesion, vDocumentoSesion, cExtension);
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cArchivo = fDialog.FileName;
                FileInfo fInfo = new FileInfo(cArchivo);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);

                var drDocumento = dtDocumentos.NewRow();
                drDocumento["cDocumentoSesion"] = fInfo.Name;
                drDocumento["vDocumentoSesion"] = br.ReadBytes((int)numBytes);
                drDocumento["cExtension"] = fInfo.Extension;

                dtDocumentos.Rows.Add(drDocumento);
                dtDocumentos.AcceptChanges();
                fStream.Flush();
                fStream.Close();
                br.Close();
            }
        }

        #endregion

        #region Metodos

        private void cargarConsejos()
        {
            var dtConsejos = consejo.ListarConsejo();
            if (dtConsejos.Rows.Count > 0)
            {
                dtgConsejos.DataSource = dtConsejos;
                formatoGridConsejos();
            }
        }

        private void formatoGridConsejos()
        {
            foreach (DataGridViewColumn item in dtgConsejos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgConsejos.Columns["cConsejo"].Visible = true;
            dtgConsejos.Columns["cConsejo"].HeaderText = "Consejo";
        }

        private void cargarIntegrantes(int idConsejo)
        {
            var dtIntegranteAux = integrante.ListarIntegranteIdConsejo(idConsejo);
            if (dtIntegranteAux.Rows.Count > 0)
            {
                dtIntegranteAux.Columns.Add("lAsistenca", typeof(bool));
                foreach (DataRow item in dtIntegranteAux.Rows)
                {
                    item["lAsistenca"] = false;
                }
                dtgIntegrantes.DataSource = dtIntegranteAux;
                formatoGridIntegrante();
            }
        }

        private void formatoGridIntegrante()
        {
            dtgIntegrantes.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgIntegrantes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }
            dtgIntegrantes.Columns["cNombre"].Visible = true;
            dtgIntegrantes.Columns["cTipoIntegranteConsejo"].Visible = true;

            dtgIntegrantes.Columns["cNombre"].DisplayIndex = 1;
            dtgIntegrantes.Columns["cTipoIntegranteConsejo"].DisplayIndex = 2;

            dtgIntegrantes.Columns["cNombre"].HeaderText = "Nombres";
            dtgIntegrantes.Columns["cTipoIntegranteConsejo"].HeaderText = "Tipo";
            dtgIntegrantes.Columns["lAsistenca"].Visible = true;
            dtgIntegrantes.Columns["lAsistenca"].HeaderText = "Asitió";
            dtgIntegrantes.Columns["lAsistenca"].ReadOnly = false;
        }

        private bool validar()
        {
            bool lVal = false;

            if (txtDescripcion.Text=="")
            {
                MessageBox.Show("Debe de ingresar una descripción de la sesión", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            if (this.txtAsunto.Text == "")
            {
                MessageBox.Show("Debe de ingresar el asunto de la sesión", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAsunto.Focus();
                return lVal;
            }

            if (this.txtAcuerdos.Text == "")
            {
                MessageBox.Show("Debe de ingresar los acuerdos de la sesión", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcuerdos.Focus();
                return lVal;
            }

            int nCantasistente = 0;

            foreach (DataGridViewRow item in dtgIntegrantes.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lAsistenca"].Value) == true)
                {
                    nCantasistente++;
                }
            }

            if (nCantasistente == 0)
            {
                 MessageBox.Show("Debe de seleccionar a los participantes de la sesión", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
                return lVal;
            }
            lVal = true;
            return lVal;
        }

        private void habilitarControles(bool lEstado)
        {
            dtgConsejos.Enabled = lEstado;
            dtgIntegrantes.Enabled = lEstado;
            txtAcuerdos.Enabled = lEstado;
            txtAsunto.Enabled = lEstado;
            txtDescripcion.Enabled = lEstado;
            txtObservaciones.Enabled = lEstado;
            cboTipoSesion2.Enabled = lEstado;
            dtgDocumentos.Enabled = lEstado;
            btnAgregar1.Enabled = lEstado;
            btnQuitar1.Enabled = lEstado;
        }

        private void crearEstructuraTDocuemnto()
        {
            dtDocumentos.Columns.Add("cDocumentoSesion", typeof(string));
            dtDocumentos.Columns.Add("vDocumentoSesion", typeof(byte[]));
            dtDocumentos.Columns.Add("cExtension", typeof(string));
            dtgDocumentos.DataSource = dtDocumentos;
            formatoGridDocumento();
        }

        private void formatoGridDocumento()
        {
            foreach (DataGridViewColumn item in dtgDocumentos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgDocumentos.Columns["cDocumentoSesion"].Visible = true;
            dtgDocumentos.Columns["cDocumentoSesion"].HeaderText = "Documentos de la Sesión";
        }
        
        #endregion

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgIntegrantes.Rows.Count > 0)
            {
                if (dtgIntegrantes.SelectedRows.Count > 0)
                {
                    dtgIntegrantes.Rows.Remove(dtgIntegrantes.SelectedRows[0]);
                }
            }
        }
    }
}
