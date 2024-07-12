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
    public partial class cboRegimenPens : cboBase
    {
        public cboRegimenPens()
        {
            InitializeComponent();
        }

        public cboRegimenPens(IContainer container)
        {
            container.Add(this);

            InitializeComponent();    
            
        }
        public void CargarRegimenPens(int idTipoReg) {
            clsCNListarRegPens objProcJud = new clsCNListarRegPens();
            DataTable dt = objProcJud.ListarRegimenPen(idTipoReg);         
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();  
        
        }

       
    }
}
