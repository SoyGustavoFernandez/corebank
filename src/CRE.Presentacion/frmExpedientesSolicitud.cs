using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmExpedientesSolicitud : frmBase
    {
        clsCNControlExp ListaDetExp = new clsCNControlExp();         
        DataTable dtSolExpediente = new DataTable("dtSolExpediente");
        DataTable dtDetalleExp = new DataTable("dtDetalleExp");
        clsCNControlExp DetExpediente = new clsCNControlExp();
        clsCNCliente clsValidaCliente = new clsCNCliente();
        DataTable dtExpediente;
        int nIndiceSelecCli = -1;
        public frmExpedientesSolicitud()
        {
            InitializeComponent();
            DataTable dtMotivoSolicitudExp = ListaDetExp.CNListarMotivosSolicitudExpediente(clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoExpediente.DataSource = dtMotivoSolicitudExp;
            cboMotivoExpediente.ValueMember = "idMotivoSolicitud";
            cboMotivoExpediente.DisplayMember = "cMotivo";
            
        }

        private void frmSolicitudExpedientes_Load(object sender, EventArgs e)
        {
            agregarColumnasGrid(dtSolExpediente);
            conBusCli1.txtCodCli.Focus();

            
            dtgDetalleExp.DataSource =  DetExpediente.CNListDetalleExp(0, 0);
            formatoDetalleExp();

            dtgSolicExped.DataSource = dtSolExpediente.DefaultView;
            formatoGridExpediente(dtgSolicExped, true);

            dtExpediente = DetExpediente.CNListarExpedientePorTipoOperacion(0);

            dtgExpedientesCliente.DataSource = dtExpediente;
            formatoGridExpediente(dtgExpedientesCliente, false);
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (this.conBusCli1.txtNombre.Text =="")
            {
                 MessageBox.Show("Debe ingresar un Cliente","Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
            }
            
            if (dtgSolicExped.RowCount>0)
            {
                for (int i = 0; i < dtgSolicExped.Rows.Count; i++)
			    {
                    if (Convert.ToInt32(dtSolExpediente.Rows[i]["idCli"]) == Convert.ToInt32(this.conBusCli1.txtCodCli.Text))
                    {
                        MessageBox.Show("El Expediente del Cliente ya esta agregado", "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
			    }               
            }

            formatoDetalleExp();
            limpiar();
            activo();
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicExped.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Int32 nFilaActual = Convert.ToInt32(this.dtgSolicExped.SelectedCells[0].RowIndex);
            dtgSolicExped.Rows.RemoveAt(nFilaActual);
            dtgSolicExped.EndEdit();
        }

        public void limpiar() 
        {
            conBusCli1.txtCodInst.Text = "";
            conBusCli1.txtCodAge.Text = "";
            conBusCli1.txtCodCli.Text = "";
            conBusCli1.txtDireccion.Text = "";
            conBusCli1.txtNombre.Text = "";
            conBusCli1.txtNroDoc.Text = ""; 
        }
        public void activo() 
        {
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.btnBusCliente.Enabled = true;
            btnGrabar1.Enabled = true;
        }       

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtSolExpediente.Clear();
            dtDetalleExp.Clear();
            DataTable dtDetExp = ((DataTable)dtgExpedientesCliente.DataSource);
            if (dtDetExp  != null)
            {
                dtDetExp.Clear();
            }
            
            limpiar();
            activo();
            cboMotivoExpediente.SelectedIndex = -1;
        }
        
        Boolean Valida()
        {
            if (dtgSolicExped.RowCount == 0)
            {
                MessageBox.Show("No existe datos de cliente para su registro", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }       

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {               
                return;
            }

            DataTable dtRegExpediente = new DataTable();
            dtRegExpediente = DetExpediente.CNBuscaExp(0, 0);
            

            for (int i = 0; i < dtgSolicExped.Rows.Count; i++)
            {

                int idCli =  Convert.ToInt32(this.dtgSolicExped.Rows[i].Cells["idCli"].Value);
                int idtipoexpediente = Convert.ToInt32(this.dtgSolicExped.Rows[i].Cells["idTipoOpeExp"].Value);
                DataTable dtExpSol = DetExpediente.CNValidarSolExpPendUsuario(
                        clsVarGlobal.User.idUsuario
                        , idCli
                        , idtipoexpediente);
                if (dtExpSol.Rows.Count >0)
                {
                   
                MessageBox.Show("Ud. ya tiene una solicitud del expediente: "
                            +dtgSolicExped.Rows[i].Cells["idExpediente"].Value.ToString()
                            + " del cliente: "
                            +dtgSolicExped.Rows[i].Cells["cNombre"].Value.ToString(), "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (String.IsNullOrEmpty(this.dtgSolicExped.Rows[i].Cells["idMotivoExp"].Value.ToString()))
                {
                    MessageBox.Show("No se asigno motivo de solicitud del expediente del cliente : " + this.dtgSolicExped.Rows[i].Cells["cNombre"].Value.ToString(), "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //DataTable dtestexpediente=DetExpediente.CNValidarEstExpediente(
                //        clsVarGlobal.User.idUsuario
                //        , idCli
                //        , idtipoexpediente);

                //if (dtestexpediente.Rows.Count > 0)
                //{

                //    MessageBox.Show("El expediente: "
                //                + dtgSolicExped.Rows[i].Cells["idExpediente"].Value.ToString()
                //                + " del cliente: "
                //                + dtgSolicExped.Rows[i].Cells["cNombre"].Value.ToString()+ ", se encuentra en calidad de préstamo", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}


                DataRow drfilaExp = dtRegExpediente.NewRow();
                drfilaExp["idUsuario"] = clsVarGlobal.User.idUsuario.ToString();
                drfilaExp["idEstadoExp"] = 1;
                drfilaExp["dFechaRegistro"] = clsVarGlobal.dFecSystem.ToString();
                drfilaExp["idAgencia"] = clsVarGlobal.nIdAgencia;
                drfilaExp["idcli"] = Convert.ToInt32(this.dtgSolicExped.Rows[i].Cells["idCli"].Value);
                drfilaExp["idMotivoSolicitud"] = Convert.ToInt32(this.dtgSolicExped.Rows[i].Cells["idMotivoExp"].Value);
                drfilaExp["idTipoOpeExp"] = Convert.ToInt32(this.dtgSolicExped.Rows[i].Cells["idTipoOpeExp"].Value);
                drfilaExp["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
                
                dtRegExpediente.Rows.Add(drfilaExp);
            }
           
            DataSet dsExpediente = new DataSet("dsExpediente");
            dsExpediente.Tables.Add(dtRegExpediente);
            string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

            DataTable dtRegSolExp = DetExpediente.CNRegistroSolExp(xmlExpediente);

            if (Convert.ToInt32(dtRegSolExp.Rows[0]["idRpta"].ToString()) != 0)
            {
                MessageBox.Show(dtRegSolExp.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + dtRegSolExp.Rows[0]["idRpta"].ToString(), "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
            }
            else
            {
                MessageBox.Show(dtRegSolExp.Rows[0]["cMensaje"].ToString(), "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }             
            this.btnGrabar1.Enabled = false;
            dtSolExpediente.Clear();
            dtDetalleExp.Clear();
            
            //((DataTable)dtgExpedientesCliente.DataSource).Clear();
        }
        private void cargarExpedientesClienteTipoExpediente(int nIndiceSelecCli)
        {
            if (dtgSolicExped.SelectedRows.Count == 0)
            {
                return;
            }
            if (nIndiceSelecCli < 0)
            {
                MessageBox.Show("No hay clientes seleccionados", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtDetalleExp = DetExpediente.CNListDetalleExp(Convert.ToInt32(dtgSolicExped.SelectedRows[0].Cells["idCli"].Value), Convert.ToInt32(dtgSolicExped.SelectedRows[0].Cells["idTipoOpeExp"].Value));
            dtgDetalleExp.DataSource = dtDetalleExp.DefaultView;
            

        }

        private void formatoDetalleExp()
        {
            foreach (DataGridViewColumn item in dtgDetalleExp.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgDetalleExp.Columns["idExpediente"].Visible = true;
            this.dtgDetalleExp.Columns["cObservacion"].Visible = true;
            this.dtgDetalleExp.Columns["cDescripCond"].Visible = true;
            this.dtgDetalleExp.Columns["cDescripTipoFolio"].Visible = true;
            this.dtgDetalleExp.Columns["nNroFolios"].Visible = true;
            this.dtgDetalleExp.Columns["cTipoDocumento"].Visible = true;
            this.dtgDetalleExp.Columns["cDocumento"].Visible = true;

            this.dtgDetalleExp.Columns["idExpediente"].HeaderText = "Cod. Exp";
            this.dtgDetalleExp.Columns["cObservacion"].HeaderText = "Observaciones";
            this.dtgDetalleExp.Columns["cDescripCond"].HeaderText = "Condición Expediente";
            this.dtgDetalleExp.Columns["cDescripTipoFolio"].HeaderText = "Tipo Folio";
            this.dtgDetalleExp.Columns["nNroFolios"].HeaderText = "Nro. Folios";
            this.dtgDetalleExp.Columns["cTipoDocumento"].HeaderText = "Tip. Doc.";
            this.dtgDetalleExp.Columns["cDocumento"].HeaderText = "Documento";

            this.dtgDetalleExp.Columns["cDescripCond"].Width = 80;
            this.dtgDetalleExp.Columns["cDescripTipoFolio"].Width = 80;
            this.dtgDetalleExp.Columns["cDocumento"].Width = 150;
            /* ---- orden de columas --- */
            this.dtgDetalleExp.Columns["cDocumento"].DisplayIndex = 0;
            this.dtgDetalleExp.Columns["cObservacion"].DisplayIndex = 9;
            /* ---- orden de columas --- */
        }
        
        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli < 1) 
            {
                MessageBox.Show("Busque un cliente", "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtExpediente = null;
            dtExpediente = DetExpediente.CNListarExpedientePorTipoOperacion(conBusCli1.idCli);
            
            if (dtExpediente.Rows.Count == 0)
            {
                dtgExpedientesCliente.DataSource = null;
                MessageBox.Show("El Cliente no tiene ningún expediente", "Solicitud de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtgExpedientesCliente.DataSource = dtExpediente;
            formatoGridExpediente(dtgExpedientesCliente, false);
            conBusCli1.btnBusCliente.Enabled = false;
        }

        private void formatoGridExpediente(DataGridView dtgView, Boolean lSel)
        {
            foreach (DataGridViewColumn item in dtgView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;    
            }

            dtgView.Columns["lSel"].Visible = lSel;
            dtgView.Columns["lSel"].Width = 25;
            dtgView.Columns["cDescripcion"].Width = 80;
            dtgView.Columns["cNombre"].Width = 150;

            dtgView.Columns["cCodCliente"].Visible = false;
            dtgView.Columns["idCli"].Visible = false;
            dtgView.Columns["idTipoOpeExp"].Visible = false;
            dtgView.Columns["cDescripcion"].Visible = false;
            dtgView.Columns["idExpediente"].HeaderText = "Expediente";
            dtgView.Columns["cNombre"].HeaderText = "Cliente";
            dtgView.Columns["cTipoDoc"].HeaderText = "Tipo Documento";
            dtgView.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            dtgView.Columns["cDescripcion"].HeaderText = "Tipo Expediente";
            dtgView.Columns["lSel"].HeaderText = "";
            dtgView.Columns["cNombreAgencia"].HeaderText = "Agencia";
            if (lSel)
            {
                dtgView.Columns["idMotivoExp"].Visible = false;
                dtgView.Columns["cMotivo"].DisplayIndex = 3;
                dtgView.Columns["cMotivo"].HeaderText = "Motivo";
            }
            
        }
        private void agregarColumnasGrid(DataTable dt)
        {
            dt.Columns.Add("lSel", typeof(Boolean));
            dt.Columns.Add("cCodCliente", typeof(string));
            dt.Columns.Add("idCli", typeof(int));
            dt.Columns.Add("idExpediente", typeof(string));
            dt.Columns.Add("cNombre", typeof(string));
            dt.Columns.Add("cTipoDoc", typeof(string));
            dt.Columns.Add("cDocumentoID", typeof(string));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idTipoOpeExp", typeof(int));
            dt.Columns.Add("idMotivoExp", typeof(int));
            dt.Columns.Add("cMotivo", typeof(string));
            dt.Columns.Add("cNombreAgencia", typeof(string));
            dt.Columns["lSel"].ReadOnly = false;
            
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicExped.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Int32 nFilaActual = Convert.ToInt32(this.dtgSolicExped.SelectedCells[0].RowIndex);
            dtSolExpediente.Rows.RemoveAt(nFilaActual);
            dtSolExpediente.AcceptChanges();
            dtDetalleExp = DetExpediente.CNListDetalleExp(Convert.ToInt32(0), Convert.ToInt32(0));
            dtgDetalleExp.DataSource = dtDetalleExp.DefaultView;
        }

        private void btnMiniActualizar1_Click(object sender, EventArgs e)
        {
            if (cboMotivoExpediente.SelectedIndex < 0)
            {
                MessageBox.Show("Tiene que seleccionar el motivo de la solicitud del expediente", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!verificarFilasSeleccionadas())
            {
                MessageBox.Show("Tiene que seleccionar al menos un expediente solicitado", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /*------------------- Actualizando motivo -------------------------*/
            DataTable dtTemp = ((DataView)dtgSolicExped.DataSource).Table;
            foreach (DataRow item in dtTemp.Rows)
            {
                if (Convert.ToBoolean(item["lSel"]) == true)
                {
                    item["idMotivoExp"] = Convert.ToInt32(cboMotivoExpediente.SelectedValue);
                    item["cMotivo"]     = (((DataTable)cboMotivoExpediente.DataSource).Rows[cboMotivoExpediente.SelectedIndex]["cMotivo"]).ToString();
                    item["lSel"]        = false;
                }
            }
            MessageBox.Show("Se ha actualizado el motivo de la solicitud a las filas seleccionadas", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*------------------- End actualizando motivo -------------------------*/
        }
        private Boolean verificarFilasSeleccionadas()
        {
            DataTable dtTemp = ((DataView)dtgSolicExped.DataSource).Table;
            foreach (DataRow item in dtTemp.Rows)
	        {
                if (Convert.ToBoolean(item["lSel"]) == true)
                {
                    return true;
                }
	        }
            return false;
        }

        private void chcTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (dtgSolicExped.SelectedCells.Count == 0)
            {
                return;
            }
            var dtExpedientes = ((DataView)dtgSolicExped.DataSource).Table;
            dtExpedientes.AsEnumerable().ToList().ForEach(x => x["lSel"] = chcTodo.Checked);
        }

        private void dtgSolicExped_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSolicExped.RowCount > 0)
            {
                cargarExpedientesClienteTipoExpediente(dtgSolicExped.CurrentCell.RowIndex);
            }
        }

        private void dtgSolicExped_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = ((DataView)dtgSolicExped.DataSource).ToTable();
            if (dt.Rows.Count == 0)
            {
                return;
            }

            dtgSolicExped.SelectedRows[0].Cells["lSel"].Value = !Convert.ToBoolean(dtgSolicExped.SelectedRows[0].Cells["lSel"].Value);
            dt.AcceptChanges();
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (this.conBusCli1.txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string idExpediente = dtgExpedientesCliente.SelectedRows[0].Cells["idExpediente"].Value.ToString();
            int indexRow = dtgExpedientesCliente.SelectedRows[0].Index;
            if (dtgSolicExped.RowCount > 0)
            {
                for (int i = 0; i < dtgSolicExped.Rows.Count; i++)
                {
                    if (dtSolExpediente.Rows[i]["idExpediente"].ToString().Trim().ToUpper() == idExpediente.Trim().ToUpper())
                    {
                        MessageBox.Show("El expediente del cliente ya esta agregado", "Solicitud de expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            DataRow drNuevo = dtExpediente.Rows[indexRow];
            dtSolExpediente.ImportRow(drNuevo);
        }
    }
}
