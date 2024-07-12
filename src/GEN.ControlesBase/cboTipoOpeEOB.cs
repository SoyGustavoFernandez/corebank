using ADM.CapaNegocio;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoOpeEOB : cboBase
    {
        clsCNConfiguracionLimite clsCNConfiguracionLimite = new clsCNConfiguracionLimite();

        public cboTipoOpeEOB()
        {
            InitializeComponent();
        }

        public cboTipoOpeEOB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        public void CargarTipoOpeEOB()
        {
            DataTable dt = clsCNConfiguracionLimite.CNCargarTiposOperacionesLimites();
            DataRow row = dt.NewRow();
            row["idTipoOpe"] = -1;
            row["cTipoOpe"] = "";
            dt.Rows.InsertAt(row, 0);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoOpe"].ToString();
            this.DisplayMember = dt.Columns["cTipoOpe"].ToString().ToUpper();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DropDownWidth = 200;
        }
        
        public void TipoOpeEOBYTodos()
        {
            DataTable dt = clsCNConfiguracionLimite.CNCargarTiposOperacionesLimites();
            DataRow row = dt.NewRow();
            row["idTipoOpe"] = 0;
            row["cTipoOpe"] = "TODOS";
            dt.Rows.InsertAt(row, 0);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
