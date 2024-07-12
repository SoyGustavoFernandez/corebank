using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoActoProcesal : cboBase
    {
        clsCNTipoActoProcesal cnTipoActoProcesal = new clsCNTipoActoProcesal();
 
        public cboTipoActoProcesal()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public void cargar()
        {
            DataTable dt = cnTipoActoProcesal.listarTipoActoProcesal();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoActoProcesal"].ToString();
            this.DisplayMember = dt.Columns["cTipoActoProcesal"].ToString();        
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);            
        }
    }
}
