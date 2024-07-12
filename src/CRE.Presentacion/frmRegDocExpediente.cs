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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.BotonesBase;

namespace CRE.Presentacion
{
    public partial class frmRegDocExpediente : frmBase
    {
        clsCNControlExp ListaDetExp = new clsCNControlExp();         
        int ncliente;
        DataTable dtTipoDocumentos;
        DataTable dtPadreDoc;
        DataTable dtHijosDoc;
        GEN.CapaNegocio.clsCNCredito clsCredito = new GEN.CapaNegocio.clsCNCredito();
        public frmRegDocExpediente()
        {
            InitializeComponent();
            dtTipoDocumentos = ListaDetExp.CNListaDocumentosExpedientes();
            listarTipoDocumento();
            
            limpiar();
            cboDocumentosExpedientePadre.Enabled = true;

        }
        
        private void listarPadreDoc(int nTipo)
        {
            dtPadreDoc = null;
            dtPadreDoc = dtTipoDocumentos.Clone();

            foreach (DataRow item in dtTipoDocumentos.Rows)
            {
                if (Convert.ToInt32(item["idPadre"]) == 0 && Convert.ToInt32(item["idTipoOpeExp"]) == nTipo)
                {
                    dtPadreDoc.ImportRow(item);
                }
            }

            if (dtPadreDoc.Rows.Count == 0)
            {
                cboDocumentosExpedientePadre.Enabled = false;
                cboDocumentosExpediente.Enabled = false;
                /*---------- VACIA HIJOS SI NO HAY LISTADO DE PADRES O GRUPO DE DOCUMENTOS  -----------*/
                cboDocumentosExpediente.DataSource = dtPadreDoc;
                cboDocumentosExpediente.DisplayMember = "cDocumento";
                cboDocumentosExpediente.ValueMember = "idDocExp";
                /*---------- FIN  -----------*/
            }
            else
            {
                cboDocumentosExpedientePadre.Enabled = true;
            }

            cboDocumentosExpedientePadre.DataSource = dtPadreDoc;
            cboDocumentosExpedientePadre.DisplayMember = "cDocumento";
            cboDocumentosExpedientePadre.ValueMember = "idDocExp";
        }
        private void cargarHijos(int idPadre)
        {
            dtHijosDoc = null;
            dtHijosDoc = dtTipoDocumentos.Clone();
            
            foreach (DataRow item in dtTipoDocumentos.Rows)
            {
                if (Convert.ToInt32(item["idPadre"]) == idPadre)
                {
                    dtHijosDoc.ImportRow(item);
                }
            }

            if (dtHijosDoc.Rows.Count == 0)
            {
                cboDocumentosExpediente.Enabled = false;
            }
            else
            {
                cboDocumentosExpediente.Enabled = true;
            }

            cboDocumentosExpediente.DataSource = dtHijosDoc;
            cboDocumentosExpediente.DisplayMember = "cDocumento";
            cboDocumentosExpediente.ValueMember = "idDocExp";
        }
       
        private void listarTipoDocumento()
        {
            cboTipoDocumento.DataSource = ListaDetExp.CNListaTipoDocumentoExpediente(0);
            cboTipoDocumento.DisplayMember = "cTipoDocumento";
            cboTipoDocumento.ValueMember = "idTipoDocumento";
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtListDetExp = ListaDetExp.CNBuscaDetalleExp(0);
            DataRow drListDetExp = dtListDetExp.NewRow();
            if (!validar())
            {
                return;
            }
            //drListDetExp["idSocio"] = nSocio;
            drListDetExp["idCli"] = ncliente;
            drListDetExp["cObservacion"] = rtbDescripDoc.Text;
            drListDetExp["idCondicionExp"] = Convert.ToInt32(cboCondicionExp1.SelectedValue);
            drListDetExp["dFechaRegistro"] = clsVarGlobal.dFecSystem;
            drListDetExp["idTipoFolioExp"] = Convert.ToInt32(cboTipoFolioExpediente1.SelectedValue);
            drListDetExp["idAgencia"] = clsVarGlobal.nIdAgencia;
            drListDetExp["idUsuario"] = clsVarGlobal.User.idUsuario;
            drListDetExp["idTipoOpeExp"] = Convert.ToInt32(cboTipoExpediente.SelectedValue);
            drListDetExp["idTipoDocumento"] = (cboTipoDocumento.SelectedValue != null) ? Convert.ToInt32(cboTipoDocumento.SelectedValue) : 0;
            drListDetExp["nNroFolios"] = Convert.ToInt32(nudNroFolios.Value);
            drListDetExp["lVigente"] = 1;
            drListDetExp["idDocExp"] = Convert.ToInt32(cboDocumentosExpediente.SelectedValue);
            
           
            dtListDetExp.Rows.Add(drListDetExp);
            DataSet dsExpediente = new DataSet("dsExpediente");
            dsExpediente.Tables.Add(dtListDetExp);
            string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

            DataTable dtRegDetExpediente = ListaDetExp.CNInsDetalleExpediente(xmlExpediente);
            MessageBox.Show("Se Registro Correctamente el contenido del expediente", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        void limpiar() 
        {
            rtbDescripDoc.Text = "";            
            cboCondicionExp1.SelectedValue = 0;
            cboTipoFolioExpediente1.SelectedValue = 0;
            cboTipoDocumento.SelectedValue = 0;
            cboTipoExpediente.SelectedValue = 0;
            cboDocumentosExpedientePadre.SelectedValue = -1;
            cboDocumentosExpediente.SelectedValue = -1;
            nudNroFolios.Value = 0;
        }

        private Boolean TieneCreditos(int idCli)
        {
            DataTable dtResult = clsCredito.CNCreditosCliente(idCli);
            if (dtResult.Rows.Count == 0)
                return false;

            return true;
        }

        private Boolean TieneAhorros(int idCli)
        {
            DataTable dtResult = clsCredito.CNAhorrosCliente(idCli);
            if (dtResult.Rows.Count == 0)
                return false;

            return true;
        }

        Boolean validar() 
        {
            int idCli = Convert.ToInt32(ncliente);
            if (!TieneCreditos(idCli) && Convert.ToInt32(cboTipoExpediente.SelectedValue) == 1)
            {
                MessageBox.Show("El cliente no tiene ningún crédito registrado, no puede registrar documentos", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!TieneAhorros(idCli) && Convert.ToInt32(cboTipoExpediente.SelectedValue) == 2)
            {
                MessageBox.Show("El cliente no tiene ningún ahorro registrado, no puede registrar documentos", "Entrega de expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToInt32(cboCondicionExp1.SelectedIndex) < 0)
            {
                MessageBox.Show("Debe indicar en que condición se encuentra el Documento", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(cboTipoFolioExpediente1.SelectedIndex) < 0)
            {
                MessageBox.Show("Debe indicar el tipo de folio del Documento", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(cboTipoExpediente.SelectedIndex) < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de expediente", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToInt32(cboDocumentosExpedientePadre.SelectedIndex) < 0)
            {
                MessageBox.Show("Debe seleccionar el documento grupo", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDocumentosExpedientePadre.Focus();
                return false;
            }

            
            if (nudNroFolios.Value == 0)
            {
                MessageBox.Show("Nro Folios debe ser mayor a cero ", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(cboTipoFolioExpediente1.SelectedValue) != 2) 
            {
                if (Convert.ToInt32(cboTipoDocumento.SelectedIndex) < 0) //Digital
                {
                    MessageBox.Show("Debe seleccionar un tipo de documento", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (Convert.ToInt32(cboDocumentosExpediente.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar un Documento", "Documentos de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public void InsDetalle(int idcliente)//, int idSocio)         
        {
            ncliente = idcliente;
            //nSocio = idSocio;
        }

        private void cboDocumentosExpedientePadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDocumentosExpedientePadre.SelectedValue is DataRowView)
            {
                return;
            }

            cargarHijos(Convert.ToInt32(cboDocumentosExpedientePadre.SelectedValue));
            limpiarRegContExp();
            //if (cboTipoExpediente.SelectedValue is DataRowView)
            //{
            //    return;
            //}
            //listarPadreDoc(Convert.ToInt32(cboTipoExpediente.SelectedValue));
        }


        private void cboTipoExpediente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTipoExpediente.SelectedValue is DataRowView)
            {
                return;
            }
            listarPadreDoc(Convert.ToInt32(cboTipoExpediente.SelectedValue));
            limpiarRegContExp();
        }

        private void cboTipoFolioExpediente1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoFolioExpediente1.SelectedValue) == 2)
            {
                cboTipoDocumento.SelectedIndex = -1;
                cboTipoDocumento.Enabled = false;
            }
            else 
            {
                cboTipoDocumento.Enabled = true;
            }
        }

        private void limpiarRegContExp()
        {
            cboCondicionExp1.SelectedIndex = -1;
            cboTipoFolioExpediente1.SelectedIndex = -1;
            nudNroFolios.Value = 0;
            rtbDescripDoc.Clear();
            cboTipoDocumento.SelectedIndex = -1;
        }

        private void cboDocumentosExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarRegContExp();
        }
    }
}
