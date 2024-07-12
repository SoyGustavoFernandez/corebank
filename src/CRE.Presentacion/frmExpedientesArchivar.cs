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
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExpedientesArchivar : frmBase
    {
        clsCNControlExp SolPenExpediente = new clsCNControlExp();
        DataTable dtExpedienteRec   = new DataTable();
        DataTable dtDetalleExp      = new DataTable();
        string cTitulo = "Archivar expedientes";
        public frmExpedientesArchivar()
        {
            InitializeComponent();
        }

        private void ExpedientesArchivar_Load(object sender, EventArgs e)
        {
            BuscaSolRecep(0);
        }
        private void BuscaSolRecep(int idCliente)
        {
            dtExpedienteRec = SolPenExpediente.CNBuscaExpRecep(clsVarGlobal.nIdAgencia, idCliente);
            dtExpedienteRec.Columns["chk"].ReadOnly = false;
            dtgListaExpRecib.DataSource = dtExpedienteRec;
            CargarPerfilesMotivoExp();
            FormatoGrid();
            
        }
        
        private void CargarPerfilesMotivoExp()
        {
            cboPerfilesExp.DisplayMember = "cPerfil";
            cboPerfilesExp.ValueMember = "idPerfil";
            cboPerfilesExp.DataSource = SolPenExpediente.CNListarPerfilesMotivoSolExp();
        }

        private void FormatoGrid()
        {
            dtgListaExpRecib.ReadOnly = false;
            if (dtgListaExpRecib.RowCount == 0)
            {
                dtgListaExpRecib.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            foreach (DataGridViewColumn item in dtgListaExpRecib.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }

            this.dtgListaExpRecib.Columns["cCodExpediente"].Visible = true;
            this.dtgListaExpRecib.Columns["cNombreAgencia"].Visible = true;
            this.dtgListaExpRecib.Columns["cNombre"].Visible = true;
            this.dtgListaExpRecib.Columns["cWinUser"].Visible = true;
            this.dtgListaExpRecib.Columns["cNombreUsu"].Visible = true;
            this.dtgListaExpRecib.Columns["dFechaRegistro"].Visible = true;
            this.dtgListaExpRecib.Columns["cMotivo"].Visible = true;
            this.dtgListaExpRecib.Columns["chk"].Visible = true;

            this.dtgListaExpRecib.Columns["cCodExpediente"].HeaderText = "N° Exp";
            this.dtgListaExpRecib.Columns["cNombreAgencia"].HeaderText = "Agencia";
            this.dtgListaExpRecib.Columns["cNombre"].HeaderText = "Datos Cliente";
            this.dtgListaExpRecib.Columns["cWinUser"].HeaderText = "Usuario que Solicita";
            this.dtgListaExpRecib.Columns["cNombreUsu"].HeaderText = "Colaborador Solicitante";
            this.dtgListaExpRecib.Columns["dFechaRegistro"].HeaderText = "Fecha Reg.";
            this.dtgListaExpRecib.Columns["cMotivo"].HeaderText = "Motivo";
            this.dtgListaExpRecib.Columns["chk"].HeaderText = "";

            this.dtgListaExpRecib.Columns["chk"].Width = 10;
            this.dtgListaExpRecib.Columns["cNombre"].Width = 200;
            this.dtgListaExpRecib.Columns["cNombreUsu"].Width = 200;
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgListaExpRecib.RowCount; i++)
            {
                if (chcTodos.Checked)
                {
                    dtgListaExpRecib.Rows[i].Cells[0].Value = true;
                }
                else
                {
                    dtgListaExpRecib.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void dtgListaExpRecib_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaExpRecib.RowCount > 0)
            {
                int nIndice = Convert.ToInt32(dtgListaExpRecib.SelectedRows[0].Index);
                dtgListaExpRecib.Rows[nIndice].Cells[0].Value = !Convert.ToBoolean(dtgListaExpRecib.Rows[nIndice].Cells[0].Value);
                cargarExpedientesClienteTipoExpediente(dtgListaExpRecib.CurrentCell.RowIndex);
            }
        }
        private void cargarExpedientesClienteTipoExpediente(int nIndiceSelecCli)
        {
            if (nIndiceSelecCli < 0)
            {
                MessageBox.Show("No hay clientes seleccionados", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtDetalleExp = SolPenExpediente.CNListDetalleExp(Convert.ToInt32(dtgListaExpRecib.SelectedRows[0].Cells["idCli"].Value), Convert.ToInt32(dtgListaExpRecib.SelectedRows[0].Cells["idTipoOpeExp"].Value));
            dtgDetalleExp.DataSource = dtDetalleExp.DefaultView;
            this.dtgDetalleExp.Columns["idDetalleExp"].Visible = false;
            this.dtgDetalleExp.Columns["idExpediente"].Visible = false;
            this.dtgDetalleExp.Columns["idcli"].Visible = false;
            this.dtgDetalleExp.Columns["idDocExp"].Visible = false;
            this.dtgDetalleExp.Columns["lVigente"].Visible = false;
            this.dtgDetalleExp.Columns["idTipoDocumento"].Visible = false;
            this.dtgDetalleExp.Columns["idTipoOpeExp"].Visible = false;
            this.dtgDetalleExp.Columns["idExpediente"].HeaderText = "Cod. Exp";
            this.dtgDetalleExp.Columns["cObservacion"].HeaderText = "Observaciones";
            this.dtgDetalleExp.Columns["cDescripCond"].HeaderText = "Condición Expediente";
            this.dtgDetalleExp.Columns["cDescripTipoFolio"].HeaderText = "Tipo Folio";
            this.dtgDetalleExp.Columns["nNroFolios"].HeaderText = "Nro. Folios";
            this.dtgDetalleExp.Columns["cTipoDocumento"].HeaderText = "Tip. Doc.";
            this.dtgDetalleExp.Columns["cDocumento"].HeaderText = "Documento";
            this.dtgDetalleExp.Columns["cDescripCond"].Width = 80;
            this.dtgDetalleExp.Columns["cDescripTipoFolio"].Width = 80;
            /* ---- orden de columas --- */
            this.dtgDetalleExp.Columns["cDocumento"].DisplayIndex = 0;
            this.dtgDetalleExp.Columns["cObservacion"].DisplayIndex = 9;
            /* ---- orden de columas --- */

        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            chcTodos.Checked = false;
            for (int i = 0; i < dtgListaExpRecib.RowCount; i++)
            {
                dtgListaExpRecib.Rows[i].Cells[0].Value = false;
            }           
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!Validar()) {
                return;
            }
            DataTable dtRegExpediente = new DataTable();
            dtRegExpediente = SolPenExpediente.CNBuscaExpRecep(0, 0); // obtiene la estructura de la tabla
            dtRegExpediente.Columns.Add("cObservArchivo", typeof(string));
            foreach (DataColumn item in dtRegExpediente.Columns)
            {
                item.AllowDBNull = true;
            }
            for (int i = 0; i < dtgListaExpRecib.RowCount; i++)
            {
                if (Convert.ToBoolean(dtgListaExpRecib.Rows[i].Cells[0].Value) == true)
                {
                    DataRow drfilaExp = dtRegExpediente.NewRow();
                    drfilaExp["idMovExpediente"] = Convert.ToInt32(this.dtgListaExpRecib.Rows[i].Cells["idMovExpediente"].Value);
                    drfilaExp["idCli"] = Convert.ToInt32(this.dtgListaExpRecib.Rows[i].Cells["idCli"].Value); ;
                    drfilaExp["dFechaRegistro"] = clsVarGlobal.dFecSystem.ToString();
                    drfilaExp["cObservArchivo"] = txtCBObservacion.Text;

                    dtRegExpediente.Rows.Add(drfilaExp);
                }
            }
            DataSet dsExpediente = new DataSet("dsExpediente");
            dsExpediente.Tables.Add(dtRegExpediente);
            string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

            DataTable RegSolExp = SolPenExpediente.CNActEstadoExp(xmlExpediente, "A", clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(RegSolExp.Rows[0]["nResultado"]) == 1) 
            {
                MessageBox.Show("Se archivo el expediente correctamente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                chcTodos.Checked = false;
                BuscaSolRecep(0);
                txtCBObservacion.Clear();
                dtDetalleExp.Clear();
                dtExpedienteRec.Clear();
            }
        }
        private Boolean Validar()
        {
            if (String.IsNullOrEmpty(txtCBObservacion.Text.Trim()))
            {
                MessageBox.Show("Ingrese alguna observación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int nContador = 0;
            foreach (DataRow item in ((DataTable)dtgListaExpRecib.DataSource).Rows)
                if (Convert.ToBoolean(item["chk"]))
                    nContador++;
            if (nContador == 0)
            {
                MessageBox.Show("Seleccione al menos un expediente para archivar", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void cboBase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtNuevo = dtExpedienteRec.Clone();
            foreach (DataRow item in dtExpedienteRec.Rows)
            {
                if (Convert.ToInt32(cboPerfilesExp.SelectedValue) == 0)
                    dtNuevo.ImportRow(item);
                else if (Convert.ToInt32(item["idPerfil"]) == Convert.ToInt32(cboPerfilesExp.SelectedValue))
                    dtNuevo.ImportRow(item);
            }
            dtgListaExpRecib.DataSource = null;
            dtgListaExpRecib.DataSource = dtNuevo;
            FormatoGrid();
        }

    }
}
