using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipGarRDS : cboBase
    {
        clsCNEvalConsumo EvalConsumo = new clsCNEvalConsumo();
       
        public cboTipGarRDS()
        {
            InitializeComponent();
        }

        public cboTipGarRDS(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtTipGarRieRDS = EvalConsumo.CNdtLisTipGarRDS();
            this.DataSource = dtTipGarRieRDS;
            this.DisplayMember = dtTipGarRieRDS.Columns["cTipGarRDS"].ToString();
            this.ValueMember = dtTipGarRieRDS.Columns["IdTipGarRDS"].ToString();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
