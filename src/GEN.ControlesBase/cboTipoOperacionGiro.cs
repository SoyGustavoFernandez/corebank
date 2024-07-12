using SER.CapaNegocio;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoOperacionGiro : cboBase
    {
        public cboTipoOperacionGiro()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoOperacionGiro(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            DataTable OperacionesGiro = new clsCNControlServ().CNListarTipoOperacionGiro();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DataSource = OperacionesGiro;
            this.ValueMember = OperacionesGiro.Columns[0].ToString();
            this.DisplayMember = OperacionesGiro.Columns[1].ToString();
        }
    }
}