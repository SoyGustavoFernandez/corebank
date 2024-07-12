using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipDocRevCred : cboBase
    {
        public cboTipDocRevCred()
        {
            InitializeComponent();
            ListarTipDocRevCred();
        }

        public cboTipDocRevCred(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ListarTipDocRevCred();
        }

        public void ListarTipDocRevCred()
        {
            DataTable dtResult = new clsCNTipDocRevCred().GetTipDocRevCred();
            DisplayMember = "cTipDocRevCred";
            ValueMember = "idTipDocRevCred";
            DataSource = dtResult;
        }
    }
}
