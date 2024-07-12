using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboTipoProcesoLog : cboBase
    {
        public DataTable dt;
        public cboTipoProcesoLog()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoProcesoLog(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            dt=listTipoProceso.listarTipoProceso();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void CargarTotalNotaPedio()
        {
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            dt = listTipoProceso.listarTipoProcesoGeneral();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
