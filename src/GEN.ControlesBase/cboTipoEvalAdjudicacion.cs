using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboTipoEvalAdjudicacion : cboBase
    {
        public cboTipoEvalAdjudicacion()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoEvalAdjudicacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            DataTable dt = listTipoProceso.listarTipoEvalAdj();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
           
        }
    }
}
