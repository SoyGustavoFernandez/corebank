using ADM.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipGasto : cboBase
    {
        public cboTipGasto()
        {
            InitializeComponent();
        }

        public cboTipGasto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CargarTipGasto(0);
        }

        public void CargarTipGasto(int idGrupoGasto)
        {
            DataTable dt = new clsCNConfigGastComiSeg().CargarConcepto(idGrupoGasto);
            dt.DefaultView.Sort = "cConcepto ASC";
            this.DataSource = dt;
            this.DisplayMember = "cConcepto";
            this.ValueMember = "idConcepto";
        }
    }
}
