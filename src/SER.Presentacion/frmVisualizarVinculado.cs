using GEN.ControlesBase;
using SER.CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace SER.Presentacion
{
    public partial class frmVisualizarVinculado : frmBase
    {

        #region Propiedades
        public int idCli { get; set; }
        #endregion


        #region Constructor
        public frmVisualizarVinculado()
        {
            InitializeComponent();
        }
        #endregion


        #region Eventos
        private void frmVisualizarVinculado_Load(object sender, EventArgs e)
        {
            DataTable dt = new clsCNControlServ().CNListarVinculados(idCli);
            if (dt.Rows.Count > 0)
            {
                dtgVinculados.DataSource = dt;
                FormatearDtgVinculados();
            }
        }
        #endregion


        #region Metodos
        private void FormatearDtgVinculados()
        {

            foreach (DataGridViewColumn column in dtgVinculados.Columns)
            {
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dtgVinculados.Columns["cTipoVinculo"].Visible = true;
            dtgVinculados.Columns["cDocumentoID"].Visible = true;
            dtgVinculados.Columns["cNombre"].Visible = true;

            dtgVinculados.Columns["cTipoVinculo"].HeaderText = "Vinculo";
            dtgVinculados.Columns["cDocumentoID"].HeaderText = "Número documento";
            dtgVinculados.Columns["cNombre"].HeaderText = "Nombres";

            dtgVinculados.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        #endregion

    }
}
