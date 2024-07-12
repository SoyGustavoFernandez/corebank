using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmRegistroDocumentoCTS : frmBase
    {
        clsCNRegDocumentoCTS objRegDocumentoCTS = new clsCNRegDocumentoCTS();
        DataTable dtListaRegDoc = new DataTable();
        DataTable dtDocumentosCTS = new DataTable();
        public frmRegistroDocumentoCTS()
        {
            InitializeComponent();
            iniciarTipoDocumento();
        }

        private void iniciarTipoDocumento()
        {
            DataTable dtTipoDoc = objRegDocumentoCTS.CNListarTipoDocumentoCTS();

            DataRow row = dtTipoDoc.NewRow();
            row["idTipoDocumentoCTS"] = 0;
            row["cTipoDocumentoCTS"] = "TODOS";
            dtTipoDoc.Rows.Add(row);

            cboTipoDocumento.DataSource = dtTipoDoc;
            cboTipoDocumento.ValueMember = dtTipoDoc.Columns["idTipoDocumentoCTS"].ToString();
            cboTipoDocumento.DisplayMember = dtTipoDoc.Columns["cTipoDocumentoCTS"].ToString();
        }

        private void frmRegistroDocumentoCTS_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 2;
            conBusCtaAho.idEstCuenta = 1;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            cboTipoDocumento.SelectedValue = 0;
            cboTipoDocumento.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (conBusCtaAho.idcuenta == 0)
	        {
		       // MessageBox.Show("Seleccione una cuenta de ahorros antes de continuar", "Registro de Documentos CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.LimpiarControles();
                if (dtgListRegDoc.Rows.Count>0)
                {
                    dtgListRegDoc.DataSource = ((DataTable)dtgListRegDoc.DataSource).Clone();
                }
               

                conBusCtaAho.HabDeshabilitarCtrl(true);
                cboTipoDocumento.Enabled = false;
                dtgListRegDoc.ReadOnly = true;
                btnGrabar.Enabled = false;
                return;
	        }
            
            int idCuenta = conBusCtaAho.idcuenta;
             dtListaRegDoc = new clsCNRegDocumentoCTS().CNListarRegDocumentosCTS(idCuenta);

            if (dtListaRegDoc.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione una cuenta de ahorros CTS", "Registro de Documentos CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCtaAho.LimpiarControles();
                dtgListRegDoc.DataSource = dtListaRegDoc;

                conBusCtaAho.HabDeshabilitarCtrl(true);
                cboTipoDocumento.Enabled = false;
                dtgListRegDoc.ReadOnly = true;
                btnGrabar.Enabled = false;
                return;
            }
            else
            {
                cboTipoDocumento.SelectedValue = 0;
                if (dtListaRegDoc.Rows.Count == 1 && Convert.ToInt32(dtListaRegDoc.Rows[0]["idCuenta"].ToString()) == 0)
                {
                    dtDocumentosCTS = new clsCNRegDocumentoCTS().CNListaDocumentosCTS((int) cboTipoDocumento.SelectedValue);
                    dtgListRegDoc.DataSource = dtDocumentosCTS;
                    dtDocumentosCTS.Columns["bEnviado"].ReadOnly=false;
                    dtDocumentosCTS.Columns["bFirmado"].ReadOnly = false;
                    dtDocumentosCTS.Columns["lVigente"].ReadOnly = false;
                }
                else
                {
                    dtgListRegDoc.DataSource = dtListaRegDoc;
                    conBusCtaAho.HabDeshabilitarCtrl(false);
                   
     
                    
                }
                dtListaRegDoc.Columns["bEnviado"].ReadOnly = false;
                dtListaRegDoc.Columns["bFirmado"].ReadOnly = false;
                dtListaRegDoc.Columns["lVigente"].ReadOnly = false;
                txtPromotor.Text = dtgListRegDoc.Rows[0].Cells["cpromotor"].Value.ToString();
                cboTipoDocumento.Enabled = true;
                btnGrabar.Enabled = true;
                formatoGrid();
            }
        }
        private void Buscar()
        {
 
        }
        private void formatoGrid()
        {
            dtgListRegDoc.ReadOnly = false;
            dtgListRegDoc.Columns["idCuenta"].ReadOnly = true;
            dtgListRegDoc.Columns["idRegDoc"].ReadOnly = true;
            dtgListRegDoc.Columns["cDenominacion"].ReadOnly = true;
            dtgListRegDoc.Columns["idTipoDocumentoCTS"].ReadOnly = true;
            dtgListRegDoc.Columns["cTipo"].ReadOnly = true;
            dtgListRegDoc.Columns["cpromotor"].Visible = false;
            dtgListRegDoc.Columns["idDocumentoCTS"].Visible = false;

            dtgListRegDoc.Columns["cpromotor"].ReadOnly = true;
            dtgListRegDoc.Columns["bEnviado"].ReadOnly = false;
            dtgListRegDoc.Columns["bFirmado"].ReadOnly = false;
            dtgListRegDoc.Columns["lVigente"].ReadOnly = false;
        }
        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conBusCtaAho.idcuenta == 0)
            {
                //MessageBox.Show("Seleccione una cuenta de ahorros antes de continuar", "Registro de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de documento", "Registro de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtgListRegDoc.CurrentCell = null;
       
            if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
            {
                foreach (DataGridViewRow item in dtgListRegDoc.Rows)
                {
                    if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
                    {
                        item.Visible = true;
                    }
                }
            }
            int idTipoDoc = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            if (dtDocumentosCTS.Rows.Count>0)
            {
                dtDocumentosCTS.DefaultView.RowFilter = "idTipoDocumentoCTS="+idTipoDoc;
                dtgListRegDoc.DataSource = dtDocumentosCTS.DefaultView.ToTable();
            }
            else
            {
                if (idTipoDoc == 0)
                {

                    int idCuenta = conBusCtaAho.idcuenta;
                    dtListaRegDoc = new clsCNRegDocumentoCTS().CNListarRegDocumentosCTS(idCuenta);

                    dtgListRegDoc.DataSource = dtListaRegDoc.DefaultView.ToTable();

                }
                else
                {
                    dtListaRegDoc.DefaultView.RowFilter = "idTipoDocumentoCTS=" + idTipoDoc;

                    dtgListRegDoc.DataSource = dtListaRegDoc.DefaultView.ToTable();
                }
            }
            
            //foreach (DataGridViewRow item in dtgListRegDoc.Rows)
            //{
            //    if (Convert.ToInt32(cboTipoDocumento.SelectedValue) == 0)
            //    {
            //        item.Visible = true;
            //    }
            //    else if (Convert.ToInt32(item.Cells["idTipoDocumentoCTS"].Value) == Convert.ToInt32(cboTipoDocumento.SelectedValue))
            //    {
            //        item.Visible = true;
            //    }
            //    else
            //    {
            //        item.Visible = false;
            //    }
            //}
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //===================================================================
            // Validaciones
            //===================================================================
            if (conBusCtaAho.idcuenta == 0)
            {
                MessageBox.Show("Seleccione una cuenta de ahorros antes de continuar", "Registro de Documentos CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgListRegDoc.RowCount == 0)
            {
                MessageBox.Show("No tiene registro de documentos para grabar cambios", "Registro de Documentos CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            btnGrabar.Enabled = false;
            //===================================================================
            // Guardar Datos de Registro de Documentos CTS Mediante XML
            //===================================================================
         //   DataTable dtListRegDoc = new DataTable() ;
            //foreach (DataRow row  in dtgListRegDoc.Rows)
            //{
            //    dtListRegDoc.Rows.Add(row);
            //}
            DataTable dtListRegDoc = (DataTable)(dtgListRegDoc.DataSource);
           
            //dtListRegDoc.Columns.Remove("idCuenta");
            //dtListRegDoc.Columns.Remove("cDenominacion");

            DataSet dsRegDocCTS = new DataSet("dsRegDocCTS");
            dsRegDocCTS.Tables.Add(dtListRegDoc);
            string xmlRegDoc = dsRegDocCTS.GetXml();
            xmlRegDoc = clsCNFormatoXML.EncodingXML(xmlRegDoc);
            dsRegDocCTS.Tables.Clear();

            DataTable dtResponse = new clsCNRegDocumentoCTS().CNGrabarRegDocumentosCTS(xmlRegDoc, conBusCtaAho.idcuenta);

            if (Convert.ToInt32(dtResponse.Rows[0][0]) == 0)
            {
                MessageBox.Show("Error al grabar datos", "Registro de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se grabaron los datos correctamente", "Registro de Documento CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cboTipoDocumento.Enabled = false;
            dtgListRegDoc.ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCtaAho.LimpiarControles();
            cboTipoDocumento.SelectedValue = 0;
            if (dtgListRegDoc.Rows.Count > 0)
            {
                dtgListRegDoc.DataSource = ((DataTable)dtgListRegDoc.DataSource).Clone();
            }
            
            txtPromotor.Clear();
            conBusCtaAho.HabDeshabilitarCtrl(true);
            cboTipoDocumento.Enabled = false;
            dtgListRegDoc.ReadOnly = true;
            btnGrabar.Enabled = false;
        }       
    }
}
