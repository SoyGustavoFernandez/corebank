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

namespace CRE.Presentacion
{
    public partial class frmExpedientesBusqueda : frmBase
    {        
        clsCNControlExp BuscaTodosExp = new clsCNControlExp();
        DataTable dtRealizaBusqueda = new DataTable();
        int estado, agencia,usuario, idTipoOperacionExp;
        public frmExpedientesBusqueda()
        {
            InitializeComponent();
            cboTipoExpediente2.cboCargarOpcionTodos(true);
        }

        private void frmExpedientesBusqueda_Load(object sender, EventArgs e)
        {        
            BuscaExpediente();
            FormatGrid();
            dtpFechaRegistroIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaRegistroFin.Value = clsVarGlobal.dFecSystem;
            conBusCli1.txtCodCli.Focus();
        }

        public void FormatGrid()
        {
            foreach (DataGridViewColumn item in dtgBuscaExp.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtgBuscaExp.Columns["idTipoOpeExp"].Visible = false;
            this.dtgBuscaExp.Columns["idCli"].Visible = false;
            this.dtgBuscaExp.Columns["cChar"].Visible = false;
            this.dtgBuscaExp.Columns["idMoviUltimo"].Visible = false;
            this.dtgBuscaExp.Columns["idMoviUltimo"].Visible = false;
            this.dtgBuscaExp.Columns["idEstadoExp"].Visible = false;
            this.dtgBuscaExp.Columns["dFechaArchivo"].Visible = false;

            this.dtgBuscaExp.Columns["cCodExp"].HeaderText = "Cod Exp";
            this.dtgBuscaExp.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            this.dtgBuscaExp.Columns["dFechaReg"].HeaderText = "Fecha Préstamo";
            this.dtgBuscaExp.Columns["cWinUser"].HeaderText = "Con Cargo";
            this.dtgBuscaExp.Columns["cNombrePrestado"].HeaderText = "Nombre del Solicitante";
            this.dtgBuscaExp.Columns["nDias"].HeaderText = "Dias con Cargo";
            this.dtgBuscaExp.Columns["cArea"].HeaderText = "Oficina Personal";
            this.dtgBuscaExp.Columns["cDescripcion"].HeaderText = "Tipo Expediente";
            this.dtgBuscaExp.Columns["cDescripEstado"].HeaderText = "Estado"; 
        }

        public void BuscaExpediente()
        {
            dtRealizaBusqueda = BuscaTodosExp.CNBuscarExpedienteFiltros(0, 0, 0, dtpFechaRegistroIni.Value, dtpFechaRegistroFin.Value, clsVarGlobal.dFecSystem);
            dtgBuscaExp.DataSource = dtRealizaBusqueda;        
        }
        public void limpiar()
        {
            cboAgencia1.SelectedValue = 0;
            cboEstadoExpediente1.SelectedValue = 0;
            cboTipoExpediente2.SelectedValue= 0;

            dtpFechaRegistroIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaRegistroFin.Value = clsVarGlobal.dFecSystem;
            btnProcesar1.Enabled = true;
        }
        public void limpiarConBusCli()
        {
            conBusCli1.txtCodCli.Text = "";
            conBusCli1.txtCodAge.Text = "";
            conBusCli1.txtCodInst.Text = "";
            conBusCli1.txtNroDoc.Text = "";
            conBusCli1.txtDireccion.Text = "";
            conBusCli1.txtNombre.Text = "";
        }
        public void ActivarFormulario(Boolean lBol)
        {
            grbBase1.Enabled = lBol;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {            
            agencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            estado = Convert.ToInt32(cboEstadoExpediente1.SelectedValue);
            idTipoOperacionExp = Convert.ToInt32(cboTipoExpediente2.SelectedValue);
            dtRealizaBusqueda = BuscaTodosExp.CNBuscarExpedienteFiltros(agencia, estado, idTipoOperacionExp, dtpFechaRegistroIni.Value, dtpFechaRegistroFin.Value, clsVarGlobal.dFecSystem);
            if (((DataTable)dtgDetalleExpediente.DataSource) != null)
                ((DataTable)dtgDetalleExpediente.DataSource).Clear();
            if (dtRealizaBusqueda.Rows.Count>0)
            {
                dtgBuscaExp.DataSource = dtRealizaBusqueda;
                
                //MessageBox.Show("Se proceso el Expediente Correctamente", "Busca de Expediente(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {               
                MessageBox.Show("No se encontró Expedientes", "Busca de Expediente(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgBuscaExp.DataSource = dtRealizaBusqueda;
            }
            FormatGrid();
            
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(string.IsNullOrEmpty(conBusCli1.txtCodCli.Text) ? "0" : conBusCli1.txtCodCli.Text);
            dtRealizaBusqueda = BuscaTodosExp.CNBuscarExpedientePorCliente(idCliente, clsVarGlobal.dFecSystem);

            if (dtRealizaBusqueda.Rows.Count > 0)
            {
                dtgBuscaExp.DataSource = dtRealizaBusqueda;
                if (((DataTable)dtgDetalleExpediente.DataSource) != null)
                    ((DataTable)dtgDetalleExpediente.DataSource).Clear();
            }
            else
            {
                if (((DataTable)dtgDetalleExpediente.DataSource) != null)
                    ((DataTable)dtgDetalleExpediente.DataSource).Clear();   
                dtgBuscaExp.DataSource = dtRealizaBusqueda;  
                MessageBox.Show("No se encontró Expediente del Cliente", "Busca de Expediente(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
            }
            btnProcesar1.Enabled = false;
            ActivarFormulario(false);
            limpiar();
        }
       
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            limpiarConBusCli();
            conBusCli1.txtCodCli.Enabled = true;
            grbBase1.Enabled = true;

            if (((DataTable)dtgBuscaExp.DataSource) != null)
                ((DataTable)dtgBuscaExp.DataSource).Clear();

            if (((DataTable)dtgDetalleExpediente.DataSource) != null)
                ((DataTable)dtgDetalleExpediente.DataSource).Clear();
        }   


        private void btnMiniDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgBuscaExp.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ningún expediente seleccionado para sacar su detalle", "Busca de Expediente(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int idCli = Convert.ToInt32(dtgBuscaExp.SelectedRows[0].Cells["idCli"].Value);
            int idTipoOpeExp = Convert.ToInt32(dtgBuscaExp.SelectedRows[0].Cells["idTipoOpeExp"].Value);
            DataTable dt = BuscaTodosExp.CNHistorialExpediente(idCli, idTipoOpeExp, clsVarGlobal.dFecSystem);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay historial para este expediente", "Busca de Expediente(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            dtgDetalleExpediente.DataSource = dt;
            formatoGridDetalle();
        }

        private void formatoGridDetalle()
        {
            dtgDetalleExpediente.Columns["idMovExpediente"].Visible = false;

            dtgDetalleExpediente.Columns["cCodCliente"].HeaderText = "Código Cliente";
            dtgDetalleExpediente.Columns["cNombre"].HeaderText = "Cliente";
            dtgDetalleExpediente.Columns["dFechaPrestamo"].HeaderText = "Fecha Préstamo";
            dtgDetalleExpediente.Columns["dFechaDevolucion"].HeaderText = "Fecha Devolución";
            dtgDetalleExpediente.Columns["nDias"].HeaderText = "Nro. días";
            dtgDetalleExpediente.Columns["cWinUser"].HeaderText = "Con Cargo";
            dtgDetalleExpediente.Columns["cArea"].HeaderText = "Oficina Personal";
            dtgDetalleExpediente.Columns["cMotivo"].HeaderText = "Motivo";
        }
    }
}
