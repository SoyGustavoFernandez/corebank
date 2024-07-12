using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoHorario : cboBase
    {
        public cboTipoHorario()
        {
            InitializeComponent();
        }

        public cboTipoHorario(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            RecargarCboTipoHorario();
            
        }
        public void RecargarCboTipoHorario() { 
            
            clsCNListarHorario objProcJud = new clsCNListarHorario();
            DataTable dt = objProcJud.ListarHorario();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();        
        }
    }
}
