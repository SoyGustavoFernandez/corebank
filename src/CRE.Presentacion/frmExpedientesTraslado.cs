using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using CLI.CapaNegocio;
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExpedientesTraslado : frmBase
    {
        clsCNRetDatosCliente ListaCliente = new clsCNRetDatosCliente();
        clsCNControlExp Expediente = new clsCNControlExp();
        DataTable dtBuscaClientes = new DataTable();
        
        string cTitulo = "Traslado de expedientes";
        public frmExpedientesTraslado()
        {
            InitializeComponent();
            
        }

        private void frmExpedientesTraslado_Load(object sender, EventArgs e)
        {
            cboPersCustodiaOrig.DataSource = null;
            cboPersCustodiaDes.DataSource = null;
            cboAgenciaOrig.SelectedIndex = -1;
            cboPersCustodiaOrig.SelectedIndex = -1;
            cboAgenciaDes.SelectedIndex = -1;
            cboPersCustodiaDes.SelectedIndex = -1;
            cboPersonalCreditos.SelectedIndex = -1;
            Limpiar();
            cboAgenciaOrig.SelectedValue = clsVarGlobal.nIdAgencia;
        }

        public void NroExpediente()
        {
            int NroExp = 0;
            for (int i = 0; i < dtgTrasladoExp.RowCount; i++)
                if (Convert.ToBoolean(dtgTrasladoExp.Rows[i].Cells[0].Value) == true)
                    NroExp++;

            txtNroExpediente.Text = Convert.ToString(NroExp);
        }
        public void Limpiar() 
        {
            txtNroExpediente.Text = "";
            dtFechaTraslado.Value = clsVarGlobal.dFecSystem;
            
            cboAgenciaDes.SelectedValue = 0;
            
            cboPersCustodiaDes.SelectedValue = 0;
            chcTodos.Checked = false;
            txtCBFiltro.Clear();
            for (int i = 0; i < dtgTrasladoExp.RowCount; i++)
                dtgTrasladoExp.Rows[i].Cells["chk"].Value = false;

            dtBuscaClientes.Clear();
            cboPersonalCreditos.SelectedIndex = -1;
        }       

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                return;
            }
            DataTable dtTrasladoExp = new DataTable();
            DataSet dsExpediente = new DataSet("dsExpediente");
            dtTrasladoExp = Expediente.CNBuscaExpTrasladados(0);

            for (int i = 0; i < dtgTrasladoExp.RowCount; i++)
            {
                if (Convert.ToBoolean(dtgTrasladoExp.Rows[i].Cells["chk"].Value) == true)
                {
                    DataTable dtTraslado = Expediente.CNBuscaExpTrasladados(Convert.ToInt32(dtgTrasladoExp.Rows[i].Cells["idCli"].Value));
                    DataRow drfilaExp = dtTrasladoExp.NewRow();
                    
                    drfilaExp["idTrasladoExpediente"] = 0;
                    drfilaExp["idCli"]                = Convert.ToInt32(dtgTrasladoExp.Rows[i].Cells["idCli"].Value);
                    drfilaExp["idOficinaOrigen"]      = cboAgenciaOrig.SelectedValue;
                    drfilaExp["idOficinaDestino"]     = cboAgenciaDes.SelectedValue;
                    drfilaExp["idUsuCustodioOri"]     = cboPersCustodiaOrig.SelectedValue;
                    drfilaExp["idUsuCustodioDes"]     = cboPersCustodiaDes.SelectedValue;
                    drfilaExp["dFechaRegistro"]       = clsVarGlobal.dFecSystem;
                    drfilaExp["idAgenciaReg"]         = clsVarGlobal.nIdAgencia;
                    drfilaExp["idUsuarioReg"]         = clsVarGlobal.User.idUsuario;
                    drfilaExp["lVigente"]             = 1;
                    //drfilaExp["idExpediente"]       = Convert.ToInt32(dtgTrasladoExp.Rows[i].Cells["idSocio"].Value);
                    dtTrasladoExp.Rows.Add(drfilaExp);                                      
                }
            }
            dsExpediente.Tables.Add(dtTrasladoExp); 
            string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

            DataTable RegTrasladoExp = Expediente.CNRegistraTrasladoExp(xmlExpediente,clsVarGlobal.PerfilUsu.idPerfil);
            MessageBox.Show("El Traslado el Expediente(s) se realizo Correctamente y procedio a su Entrega", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            chcTodos.Checked = false;           
            Limpiar();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgTrasladoExp.RowCount; i++)
            {
                dtgTrasladoExp.Rows[i].Cells["chk"].Value = chcTodos.Checked;
            }
            NroExpediente();
        }

        private void dtgTrasladoExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ((DataTable)dtgTrasladoExp.DataSource).Rows[e.RowIndex]["chk"] = !Convert.ToBoolean(((DataTable)dtgTrasladoExp.DataSource).Rows[e.RowIndex]["chk"]);
                NroExpediente();
            }
        }

        private Boolean Valida()
        {
            if (dtFechaTraslado.Value < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha de Traslado no puede ser menor a la Fecha del Sistema", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboAgenciaOrig.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la Oficina de Origen del Traslado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboAgenciaDes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la Oficina de Destino a la que Trasladara", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(cboAgenciaOrig.SelectedValue) == Convert.ToInt32(cboAgenciaDes.SelectedValue))
            {
                MessageBox.Show("La oficina de Origen No puede ser la misma a la oficina de destino", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboPersCustodiaOrig.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el personal que Traslada", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboPersCustodiaDes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el personal que Traslada", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtgTrasladoExp.Rows.Count <= 0 )
            {
                MessageBox.Show("No Existe Expediente a Trasladar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (this.txtNroExpediente.Text == "" || this.txtNroExpediente.Text == "0")
            {
                MessageBox.Show("Debe elegir al menos un expediente para realizar el traslado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }       

        private void cboAgenciaOrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNroExpediente.Clear();
            txtCBFiltro.Clear();
            int pidAgen = Convert.ToInt32(cboAgenciaOrig.SelectedValue);
            if (pidAgen == 0)
            {
                cboPersCustodiaOrig.DataSource = null;
                Limpiar();
                cargarListaExpedientes();
            }
            else
            {
                cboPersCustodiaOrig.PersonaAgencia(pidAgen, "cPerfilAdministradorExpediente");
                cboPersonalCreditos.ListarPersonal(pidAgen, true);
                cboPersCustodiaOrig.SelectedValue = clsVarGlobal.User.idUsuario;
            }
            
        }

        private void cargarListaExpedientes()
        {
            int Agencia = Convert.ToInt32(cboAgenciaOrig.SelectedValue);
            string cAgencia = "";
            string cUsuario = "";
            if(cboAgenciaOrig.SelectedIndex < 0)
                return;
            
            if (cboPersonalCreditos.SelectedIndex < 0)
                return;

            cAgencia = ((DataTable)cboAgenciaOrig.DataSource).Rows[cboAgenciaOrig.SelectedIndex]["cNombreAge"].ToString();
            cUsuario = ((DataTable)cboPersonalCreditos.DataSource).Rows[cboPersonalCreditos.SelectedIndex]["cNombre"].ToString();

            int idUsuario = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
            dtBuscaClientes = ListaCliente.CNBuscaClientesAgencia(Agencia, idUsuario);
            if (dtBuscaClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay clientes con expedientes de la oficina: " + cAgencia + "; y del asesor: " + cUsuario, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtBuscaClientes.Columns["chk"].ReadOnly = false;
            dtgTrasladoExp.DataSource = dtBuscaClientes;
            formatoGrid();
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgTrasladoExp.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            dtgTrasladoExp.ReadOnly = true;
           
            this.dtgTrasladoExp.Columns["chk"].HeaderText = "";
            this.dtgTrasladoExp.Columns["cCodExpediente"].HeaderText = "Cod Exp";
            this.dtgTrasladoExp.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            this.dtgTrasladoExp.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            this.dtgTrasladoExp.Columns["cNombreAsesor"].HeaderText = "Nombre Asesor";

            this.dtgTrasladoExp.Columns["cCodExpediente"].Visible = true;
            this.dtgTrasladoExp.Columns["cNombre"].Visible = true;
            this.dtgTrasladoExp.Columns["cDocumentoID"].Visible = true;
            this.dtgTrasladoExp.Columns["cNombreAsesor"].Visible = true;
            this.dtgTrasladoExp.Columns["chk"].Visible = true;

            this.dtgTrasladoExp.Columns["chk"].ReadOnly = false;
            this.dtgTrasladoExp.Columns["cCodExpediente"].ReadOnly = true;
            this.dtgTrasladoExp.Columns["cNombre"].ReadOnly = true;
            this.dtgTrasladoExp.Columns["cDocumentoID"].ReadOnly = true;
            this.dtgTrasladoExp.Columns["cNombreAsesor"].ReadOnly = true;

            this.dtgTrasladoExp.Columns["cCodExpediente"].Width = 60;
            this.dtgTrasladoExp.Columns["cNombre"].Width = 200;
            this.dtgTrasladoExp.Columns["chk"].Width = 20;
            this.dtgTrasladoExp.Columns["cDocumentoID"].Width = 90;
        }

        private void cboAgenciaDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pidAgen = Convert.ToInt32(cboAgenciaDes.SelectedValue);
            if (pidAgen == 0)
            {
                cboPersCustodiaDes.DataSource = null;
                Limpiar();
            }
            else
            {
                cboPersCustodiaDes.PersonaAgencia(pidAgen, "cPerfilAdministradorExpediente");
            }  
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            buscarExpediente();
        }

        private void buscarExpediente()
        {
            if (txtCBFiltro.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Nro de Expediente a buscar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtCBFiltro.Text.Length < 8)
            {
                MessageBox.Show("El Nro de Expediente tiene 8 digitos ", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtgTrasladoExp.RowCount <= 0)
            {
                MessageBox.Show("No hay Expedientes", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string cNroExpedienteBuscar = txtCBFiltro.Text;
            DataTable dtExp = ((DataTable)dtgTrasladoExp.DataSource);
            Boolean bEstado = false;
            foreach (DataGridViewRow item in dtgTrasladoExp.Rows)
            {

                if (item.Cells["cCodExpediente"].Value.ToString().Trim().ToUpper() == cNroExpedienteBuscar.Trim().ToUpper())
                {
                    item.Cells["chk"].Value = true;
                    item.Selected = true;

                    dtgTrasladoExp.FirstDisplayedScrollingRowIndex = item.Index;
                    bEstado = true;
                }
            }
            if (!bEstado)
            {
                MessageBox.Show("Expediente no encontrado en el el listado de expedientes", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NroExpediente();
        }

        private void txtCBFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) >= 48 && Convert.ToInt32(e.KeyChar) <= 57) || Convert.ToInt32(e.KeyChar) == 8)
                e.Handled = false;
            else
                e.Handled = true;

            if (e.KeyChar == 13)
            {
                buscarExpediente();
            }
        }

        private void cboPersonalCreditos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarListaExpedientes();
            NroExpediente();
        }

        private void txtCBFiltro_TextChanged(object sender, EventArgs e)
        {
            if (txtCBFiltro.Text.Length == 0)
            {
                return;
            }
            int nCod = Convert.ToInt32(txtCBFiltro.Text);
            txtCBFiltro.Text = Convert.ToString(nCod).PadLeft(8, '0');
            txtCBFiltro.Select(8, 1);
        }

        private void txtCBFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCBFiltro.Text.Length == 9)
            {
                txtCBFiltro.Text = txtCBFiltro.Text.Remove(txtCBFiltro.Text.Length - 1);
            }
        }
    }
}
