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
using GEN.CapaNegocio;
using GEN.ControlesBase;

namespace CRE.Presentacion
{
    public partial class frmBuscarInfRiegos : frmBase
    {
        DataTable dtInfRiesgos = new DataTable();
        clsCNInformeRiesgos InformeRiesgos = new clsCNInformeRiesgos();
        public int nidSolInfRiesgo = 0;
        public int nidSolCre = 0;
        public string cMotivoSolInformeRiesgo = "";
       public DataTable dtResultado = new DataTable();
        public frmBuscarInfRiegos()
        {
            InitializeComponent();
        }

        private void frmBuscarInfRiegos_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechafin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            int idInfRiesgos = 0;//no se envia el idInfRiesgos
            dtInfRiesgos = InformeRiesgos.BuscarInformeRiesgo(idInfRiesgos, dtpFechaIni.Value, dtpFechafin.Value, null, string.Empty, 1);

            if (dtInfRiesgos.Rows.Count == 0)
            {
                MessageBox.Show("No existe Informe de Riesgos en los rangos seleccionados", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtgInformeRiesgo.DataSource = null;
            dtgInformeRiesgo.DataSource = dtInfRiesgos;
            DarFormatoGridDocumentos();
        }
        private void DarFormatoGridDocumentos()
        {
            foreach (DataGridViewColumn column in dtgInformeRiesgo.Columns)
            {
                column.Visible = false;
            }

            dtgInformeRiesgo.Columns["idInfRiesgos"].Visible = true;
            dtgInformeRiesgo.Columns["dFechaRegistroInforme"].Visible = true;
            dtgInformeRiesgo.Columns["idSolCre"].Visible = true;
            dtgInformeRiesgo.Columns["cCodCliente"].Visible = false;
            dtgInformeRiesgo.Columns["idCli"].Visible = true;
            dtgInformeRiesgo.Columns["cNombre"].Visible = true;
            dtgInformeRiesgo.Columns["cDocumentoID"].Visible = true;
            //dtgInformeRiesgo.Columns["cMotivo"].Visible = true;
            dtgInformeRiesgo.Columns["cEstado"].Visible = true;
            dtgInformeRiesgo.Columns["cNomCorto"].Visible = true;
            dtgInformeRiesgo.Columns["cNombreAsesor"].Visible = true;
            

            dtgInformeRiesgo.Columns["idInfRiesgos"].HeaderText = "Id Inf. Riesgo";
            dtgInformeRiesgo.Columns["dFechaRegistroInforme"].HeaderText = "Fec. Reg. Informe";
            dtgInformeRiesgo.Columns["idSolCre"].HeaderText = "Sol Cre";
            dtgInformeRiesgo.Columns["idCli"].HeaderText = "Cod. Cliente";
            dtgInformeRiesgo.Columns["cNombre"].HeaderText = "Nombre";
            dtgInformeRiesgo.Columns["cDocumentoID"].HeaderText = "Nro de Documento";
            //dtgInformeRiesgo.Columns["cMotivo"].HeaderText = "Motivo";
            dtgInformeRiesgo.Columns["cEstado"].HeaderText = "Estado";
            dtgInformeRiesgo.Columns["cNombreAsesor"].HeaderText = "Asesor";
            dtgInformeRiesgo.Columns["cNomCorto"].HeaderText = "Oficina";

            dtgInformeRiesgo.Columns["cNombre"].Width = 200;

            //dtgInformeRiesgo.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewColumn item in dtgInformeRiesgo.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void dtgInformeRiesgo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgInformeRiesgo.SelectedRows.Count > 0)
            {
                DataRowView dr = dtgInformeRiesgo.SelectedRows[0].DataBoundItem as DataRowView;
                nidSolInfRiesgo = Convert.ToInt32(dr["idInfRiesgos"]);
                dtResultado = dtInfRiesgos.Select("idInfRiesgos = " + nidSolInfRiesgo).CopyToDataTable();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Seleccione algun registro", "Buscar informe de riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buscar()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text) && string.IsNullOrEmpty(this.txtNombre.Text))
            {
                return;
            }

            int idInfRiesgos = 0;//no se envia el idInfRiesgos
            int idCli;
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                idCli = 0;
            }
            else
            {
                idCli = Convert.ToInt32(this.txtCodigo.Text);
            }

            string cNombre = this.txtNombre.Text;
            dtInfRiesgos = InformeRiesgos.BuscarInformeRiesgo(idInfRiesgos, null, null, idCli, cNombre, 3);

            if (dtInfRiesgos.Rows.Count == 0)
            {
                MessageBox.Show("No existe Informe de Riesgos en los rangos seleccionados", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtgInformeRiesgo.DataSource = null;
            dtgInformeRiesgo.DataSource = dtInfRiesgos;
            DarFormatoGridDocumentos();
        }

        private void btnBusqueda2_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscar();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscar();
            }
        }


    }
}
