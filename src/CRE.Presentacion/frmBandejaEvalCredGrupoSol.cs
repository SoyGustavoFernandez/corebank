using CRE.CapaNegocio;
using EntityLayer;
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

namespace CRE.Presentacion
{
    public partial class frmBandejaEvalCredGrupoSol : frmBase
    {
        string cTituloForm = "Bandeja de Evaluaciones de Credito Grupal";
        clsCNGrupoSolidario objCNGrupoSolidario = new clsCNGrupoSolidario();        
        List<clsEvalCredGrupoSol> lstEvalGrupoSolidario = new List<clsEvalCredGrupoSol>();               


        public clsEvalCredGrupoSol objEvalCredGrupoSol;
        public bool lResultado = false;

        public frmBandejaEvalCredGrupoSol()
        {
            InitializeComponent();
            this.BusEvalsCredGrupoSol();
        }

        public void BusEvalsCredGrupoSol()
        {
            this.Text = cTituloForm;
            this.lstEvalGrupoSolidario = objCNGrupoSolidario.BusEvalsCredGrupoSol(clsVarGlobal.nIdAgencia, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.PerfilUsu.idUsuario);

            if (lstEvalGrupoSolidario.Count <= 0)
            {
                MessageBox.Show("No se encontraron evaluaciones pendientes", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.lResultado = false;
                return;
            }
            this.lResultado = true;
            InsertarDatos();
        }

        public void InsertarDatos()
        {
            this.dtgEvalsCredGrupoSol.DataSource = this.lstEvalGrupoSolidario;
            this.FormatearDataGrid();
        }

        public void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgEvalsCredGrupoSol.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgEvalsCredGrupoSol.Columns["idSolicitudCredGrupoSol"].DisplayIndex = 0;
            dtgEvalsCredGrupoSol.Columns["idGrupoSolidario"].DisplayIndex = 1;
            dtgEvalsCredGrupoSol.Columns["cNombre"].DisplayIndex = 2;
            dtgEvalsCredGrupoSol.Columns["cWinUser"].DisplayIndex = 3;
            dtgEvalsCredGrupoSol.Columns["cDireccion"].DisplayIndex = 4;
            dtgEvalsCredGrupoSol.Columns["dFechaCreacion"].DisplayIndex = 5;
            dtgEvalsCredGrupoSol.Columns["nMonto"].DisplayIndex = 6;

            dtgEvalsCredGrupoSol.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["idGrupoSolidario"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["cNombre"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["cWinUser"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["cDireccion"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["dFechaCreacion"].Visible = true;
            dtgEvalsCredGrupoSol.Columns["nMonto"].Visible = true;
            /*dtgEvalsCredGrupoSol.Columns["lDomicilioGrupo"].Visible = true;*/

            dtgEvalsCredGrupoSol.Columns["idSolicitudCredGrupoSol"].HeaderText = "Cod.Sol.Grupo";
            dtgEvalsCredGrupoSol.Columns["idGrupoSolidario"].HeaderText = "Codigo";
            dtgEvalsCredGrupoSol.Columns["cNombre"].HeaderText = "Cliente";
            dtgEvalsCredGrupoSol.Columns["cWinUser"].HeaderText = "Asesor";
            dtgEvalsCredGrupoSol.Columns["cDireccion"].HeaderText = "Direccion";
            dtgEvalsCredGrupoSol.Columns["dFechaCreacion"].HeaderText = "Creacion";
            dtgEvalsCredGrupoSol.Columns["nMonto"].HeaderText = "Monto";
            /*dtgEvalsCredGrupoSol.Columns["lDomicilioGrupo"].HeaderText = "Domicilio Grupo";*/

            dtgEvalsCredGrupoSol.Columns["idSolicitudCredGrupoSol"].FillWeight = 20;
            dtgEvalsCredGrupoSol.Columns["idGrupoSolidario"].FillWeight = 20;
            dtgEvalsCredGrupoSol.Columns["cNombre"].FillWeight = 60;
            dtgEvalsCredGrupoSol.Columns["cWinUser"].FillWeight = 50;
            dtgEvalsCredGrupoSol.Columns["cDireccion"].FillWeight = 70;
            dtgEvalsCredGrupoSol.Columns["dFechaCreacion"].FillWeight = 40;
            dtgEvalsCredGrupoSol.Columns["nMonto"].FillWeight = 30;
            /*dtgEvalsCredGrupoSol.Columns["lDomicilioGrupo"].FillWeight = 20;*/

            dtgEvalsCredGrupoSol.Columns["dFechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtgEvalsCredGrupoSol.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgEvalsCredGrupoSol.Columns["cWinUser"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            /*dtgEvalsCredGrupoSol.Columns["cCargo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgEvalsCredGrupoSol.Columns["cCiclo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;*/

            /*dtgEvalsCredGrupoSol.ReadOnly = false;

            dtgEvalsCredGrupoSol.Columns["idSolicitud"].ReadOnly = true;
            dtgEvalsCredGrupoSol.Columns["cNombre"].ReadOnly = true;*/

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.SeleccionarEvalCredGrupoSol();
            this.Close();
        }

        private void SeleccionarEvalCredGrupoSol()
        {
            if (this.dtgEvalsCredGrupoSol.SelectedRows.Count <= 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna evaluación",this.cTituloForm,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.lResultado = false;
                return;
            }
            int nRow = this.dtgEvalsCredGrupoSol.SelectedRows[0].Index;
            this.objEvalCredGrupoSol = this.lstEvalGrupoSolidario[nRow];
            this.lResultado = true;
        }
    }
}
