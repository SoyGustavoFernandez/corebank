using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.ControlesBase;
using EntityLayer;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPorcenIngReal : cboBase
    {        
        public cboPorcenIngReal()
        {
            InitializeComponent();
        }

        public cboPorcenIngReal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            clsCNEvalConsumo EvalConsumo = new clsCNEvalConsumo();

            DataTable dtPorcenIngReaEvalConsumo = EvalConsumo.CNdtLisPorcenIngReaEvaConsumo();

            this.DataSource = dtPorcenIngReaEvalConsumo;
            this.DisplayMember = dtPorcenIngReaEvalConsumo.Columns["nPorcenIngReaEvalConsum"].ToString();
            this.ValueMember = dtPorcenIngReaEvalConsumo.Columns["nPorcenIngReaEvalConsum"].ToString();
            
            this.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}
