using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoAsiento : cboBase
    {
        public cboTipoAsiento()
        {
            InitializeComponent();
        }

        public cboTipoAsiento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            
            
        }
        public void CargarTipoAsientos(int idModulo){

            clsCNTipoAsiento ListadoAsientos = new clsCNTipoAsiento();
            DataTable dt = ListadoAsientos.ListarTipoAsiento(idModulo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoAsiento"].ToString();
            this.DisplayMember = dt.Columns["cAsiento"].ToString();
        
        }
    }
}
