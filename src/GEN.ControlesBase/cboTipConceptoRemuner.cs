using GRH.CapaNegocio;
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
    public partial class cboTipConceptoRemuner : cboBase
    {
        public cboTipConceptoRemuner()
        {
            InitializeComponent();
        }

        public cboTipConceptoRemuner(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNConceptoRemunerativo objConcepto = new clsCNConceptoRemunerativo();
            DataTable dt = objConcepto.ListarTipoConcRem();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
