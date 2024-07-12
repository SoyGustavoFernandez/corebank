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
    public partial class cboEstadoProcLog : cboBase
    {

        public cboEstadoProcLog()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboEstadoProcLog(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }
        public void listarEstadoProcesoAdj(int idOpcPro)
        {
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            DataTable dt = listTipoProceso.listarEstadoProcesoAdj(idOpcPro);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();  
        }
    }
}
