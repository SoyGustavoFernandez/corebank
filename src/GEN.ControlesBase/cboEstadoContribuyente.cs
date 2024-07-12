using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoContribuyente : cboBase
    {
        clsCNEstadoContribuyente ObjEstadoContribuy = new clsCNEstadoContribuyente();
        public cboEstadoContribuyente()
        {
            InitializeComponent();
        }

        public cboEstadoContribuyente(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dt = ObjEstadoContribuy.CNListaEstadoContribuyente();
            this.DataSource = dt;
            this.DisplayMember = dt.Columns["cEstContribuyente"].ToString();
            this.ValueMember = dt.Columns["idEstContribuyente"].ToString();
            
        }
    }
}
