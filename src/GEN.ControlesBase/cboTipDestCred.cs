using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboTipDestCred : cboBase
    {
        public DataTable dtTipDestCred;
        public cboTipDestCred()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipDestCred(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void listarTipDestCred(int idTipDestCred, int idPadre)
        {
            dtTipDestCred = (new clsCNEvalCred()).listarTipDestCred(idTipDestCred, idPadre);
            
            this.DataSource = dtTipDestCred;
            this.ValueMember = dtTipDestCred.Columns["idTipDestCred"].ToString();
            this.DisplayMember = dtTipDestCred.Columns["cDestino"].ToString();
        }
    }
}
