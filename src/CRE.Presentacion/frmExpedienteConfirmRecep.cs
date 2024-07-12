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
    public partial class frmExpedienteConfirmRecep : frmBase
    {
        clsCNControlExp SolPenExpediente = new clsCNControlExp();
        DataTable dtExpedienteEnt = new DataTable();       

        public frmExpedienteConfirmRecep()
        {
            InitializeComponent();
        }

        private void frmExpedienteConfirmRecep_Load(object sender, EventArgs e)
        {
            BuscaSolExpediente();           
        }

        private void BuscaSolExpediente()
        {
            dtExpedienteEnt = SolPenExpediente.CNBuscaExpEntregado(clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia, clsVarGlobal.PerfilUsu.idPerfil);
            dtExpedienteEnt.Columns["chk"].ReadOnly = false;
            dtgExpedienteEnt.DataSource = dtExpedienteEnt;
            FormatoGrid();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            ((DataTable)dtgExpedienteEnt.DataSource).AsEnumerable().ToList().ForEach(x => x["chk"] = chcTodos.Checked);
        }

        private void FormatoGrid()
        {
            if (dtgExpedienteEnt.RowCount == 0)
                dtgExpedienteEnt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            else 
                dtgExpedienteEnt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            foreach (DataGridViewColumn item in dtgExpedienteEnt.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            
            this.dtgExpedienteEnt.Columns["cCodExpediente"].Visible = true;
            this.dtgExpedienteEnt.Columns["cNombreAgencia"].Visible = true;
            this.dtgExpedienteEnt.Columns["cNombre"].Visible = true;
            this.dtgExpedienteEnt.Columns["cWinUser"].Visible = true;
            this.dtgExpedienteEnt.Columns["cNombreUsu"].Visible = true;
            this.dtgExpedienteEnt.Columns["dFechaRegistro"].Visible = true;
            this.dtgExpedienteEnt.Columns["cMotivo"].Visible = true;
            this.dtgExpedienteEnt.Columns["chk"].Visible = true;

            this.dtgExpedienteEnt.Columns["cCodExpediente"].HeaderText = "N° Exp";
            this.dtgExpedienteEnt.Columns["cNombreAgencia"].HeaderText = "Agencia";
            this.dtgExpedienteEnt.Columns["cNombre"].HeaderText = "Datos Cliente";
            this.dtgExpedienteEnt.Columns["cWinUser"].HeaderText = "Usuario que Solicita";
            this.dtgExpedienteEnt.Columns["cNombreUsu"].HeaderText = "Colaborador Solicitante";
            this.dtgExpedienteEnt.Columns["dFechaRegistro"].HeaderText = "Fecha Reg.";
            this.dtgExpedienteEnt.Columns["cMotivo"].HeaderText = "Motivo";
            this.dtgExpedienteEnt.Columns["chk"].HeaderText = "";

            this.dtgExpedienteEnt.Columns["chk"].Width = 10;

        }
        private void dtgExpedienteEnt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataTable)dtgExpedienteEnt.DataSource).Rows[e.RowIndex]["chk"] = !((Boolean)((DataTable)dtgExpedienteEnt.DataSource).Rows[e.RowIndex]["chk"]);
            int nSeleccionados = ((DataTable)dtgExpedienteEnt.DataSource).AsEnumerable().Where(x => Convert.ToBoolean(x["chk"]) == true).Count();
            if (nSeleccionados != dtgExpedienteEnt.RowCount)
                chcTodos.Checked = false;
            else
                chcTodos.Checked = true;
        }

        private void btnRecibido1_Click(object sender, EventArgs e)
        {
            DataTable dtRegExpediente = new DataTable();
            dtRegExpediente = SolPenExpediente.CNBuscaExpEntregado(0, 0, clsVarGlobal.PerfilUsu.idPerfil);
            foreach (DataColumn item in dtRegExpediente.Columns)
            {
                item.AllowDBNull = true;
            } 
            for (int i = 0; i < dtgExpedienteEnt.RowCount; i++)
            {
                if (Convert.ToBoolean(dtgExpedienteEnt.Rows[i].Cells[0].Value) == true)
                {
                    DataRow drfilaExp = dtRegExpediente.NewRow();
                    drfilaExp["cNombre"] = this.dtgExpedienteEnt.Rows[i].Cells["cNombre"].Value.ToString();
                    drfilaExp["cWinUser"] = this.dtgExpedienteEnt.Rows[i].Cells["cWinUser"].Value.ToString();
                    drfilaExp["idMovExpediente"] = Convert.ToInt32(this.dtgExpedienteEnt.Rows[i].Cells["idMovExpediente"].Value);
                    drfilaExp["idCli"]              = Convert.ToInt32(this.dtgExpedienteEnt.Rows[i].Cells["idCli"].Value); ;
                    drfilaExp["dFechaRegistro"]    = clsVarGlobal.dFecSystem.ToString();
                    dtRegExpediente.Rows.Add(drfilaExp);                    
                }
            }

            if (dtRegExpediente.Rows.Count == 0)
            {
                MessageBox.Show("No hay expedientes seleccionados para confirmar recepción de expedientes", "Confirma Recepción de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet dsExpediente = new DataSet("dsExpediente");
            dsExpediente.Tables.Add(dtRegExpediente);
            string xmlExpediente = clsCNFormatoXML.EncodingXML(dsExpediente.GetXml());

            DataTable RegSolExp = SolPenExpediente.CNActEstadoExp(xmlExpediente, "CE", clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idUsuario);
            if (Convert.ToBoolean(RegSolExp.Rows[0]["nResultado"]))
            {
                MessageBox.Show("Se Confirmo la Recepción Correctamente", "Confirma Recepción de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chcTodos.Checked = false;
                BuscaSolExpediente();
            }
            else
            {
                MessageBox.Show("No se pudo recepcionar expediente", "Confirma Recepción de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chcTodos.Checked = false;
                BuscaSolExpediente();
            }
            
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            chcTodos.Checked = false;
            for (int i = 0; i < dtgExpedienteEnt.RowCount; i++)
            {
                dtgExpedienteEnt.Rows[i].Cells[0].Value = false;
            }
        }       
    }
}
