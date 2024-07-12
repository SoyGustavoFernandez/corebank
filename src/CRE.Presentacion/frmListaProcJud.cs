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

namespace CRE.Presentacion
{
    public partial class frmListaProcJud : frmBase
    {
        DataTable dtLstProcJud;
        clsCNProcJud objProcJud = new clsCNProcJud();
        public int idProcJudicial = 0;
        public frmListaProcJud()
        {
            InitializeComponent();
        }

        private void frmListaProcJud_Load(object sender, EventArgs e)
        {

        }

        public void CargarDatos(int idCli, int idProc)
        {
            dtLstProcJud = objProcJud.BusLstProcJud(idCli);
            dtLstProcJud.DefaultView.RowFilter = ("idProcJudicial <>" + idProc.ToString());
            dtgLstProcJud.DataSource = dtLstProcJud;
            FormatoDataGridView();
        }

        private void FormatoDataGridView()
        {
            dtgLstProcJud.Columns["idProcJudicial"].Visible=true;
            dtgLstProcJud.Columns["cNroExpediente"].Visible=true;
            dtgLstProcJud.Columns["cJuzgado"].Visible = true;
            dtgLstProcJud.Columns["cNomJuez"].Visible=false;
            dtgLstProcJud.Columns["cNomSecretario"].Visible = false;
            dtgLstProcJud.Columns["cNomAbogIFI"].Visible = true;
            dtgLstProcJud.Columns["cTipoProcJud"].Visible = false;
            dtgLstProcJud.Columns["cTipoMedJud"].Visible = false;
            dtgLstProcJud.Columns["dFecRegExp"].Visible = false;
            dtgLstProcJud.Columns["dFecEntrAsesor"].Visible=false;
            dtgLstProcJud.Columns["lIndTerceria"].Visible=true;
            dtgLstProcJud.Columns["cApeNomDeman"].Visible = true;
            dtgLstProcJud.Columns["lVinculado"].Visible = false;
            dtgLstProcJud.Columns["lVigente"].Visible = false;
            dtgLstProcJud.Columns["idTipoDocumento"].Visible = false;

            dtgLstProcJud.Columns["idProcJudicial"].HeaderText = "Nro. Proceso";
            dtgLstProcJud.Columns["cNroExpediente"].HeaderText = "Nro. Expendiente";
            dtgLstProcJud.Columns["cJuzgado"].HeaderText = "Juzgado";
            dtgLstProcJud.Columns["cNomAbogIFI"].HeaderText = "Abogado";
            dtgLstProcJud.Columns["lIndTerceria"].HeaderText = "Es Terceria?";
            dtgLstProcJud.Columns["cApeNomDeman"].HeaderText = "Demandante";

            dtgLstProcJud.Columns["idProcJudicial"].FillWeight = 20;
            dtgLstProcJud.Columns["cNroExpediente"].FillWeight = 60;
            dtgLstProcJud.Columns["cJuzgado"].FillWeight = 40;
            dtgLstProcJud.Columns["cNomAbogIFI"].FillWeight = 60;
            dtgLstProcJud.Columns["lIndTerceria"].FillWeight = 20;
            dtgLstProcJud.Columns["cApeNomDeman"].FillWeight = 50;

            dtgLstProcJud.Columns["idProcJudicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
	
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            if (dtgLstProcJud.SelectedRows.Count > 0)
            {
                idProcJudicial = Convert.ToInt32(dtgLstProcJud.SelectedRows[0].Cells["idProcJudicial"].Value);
                this.Dispose();
            }
            else
            {
                return;
            }
        }

    }
}
