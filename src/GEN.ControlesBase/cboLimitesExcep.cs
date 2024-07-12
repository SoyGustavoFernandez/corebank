using ADM.CapaNegocio;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboLimitesExcep : cboBase
    {
        clsCNConfiguracionLimite clsCNConfiguracionLimite = new clsCNConfiguracionLimite();
        
        public cboLimitesExcep()
        {
            InitializeComponent();
        }

        public cboLimitesExcep(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        
        public void CargarLimitesExcep()
        {
            DataTable dt = clsCNConfiguracionLimite.CNCargarTipoLimitesExcepciones();
            DataRow row = dt.NewRow();
            row["idLimiteExcep"] = -1;
            row["cLimiteExcep"] = "";
            dt.Rows.InsertAt(row, 0);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idLimiteExcep"].ToString();
            this.DisplayMember = dt.Columns["cLimiteExcep"].ToString().ToUpper();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        public void LimitesExcepYTodos()
        {
            DataTable dt = clsCNConfiguracionLimite.CNCargarTipoLimitesExcepciones();
            DataRow row = dt.NewRow();
            row["idLimiteExcep"] = 0;
            row["cLimiteExcep"] = "TODOS";
            dt.Rows.InsertAt(row, 0);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
