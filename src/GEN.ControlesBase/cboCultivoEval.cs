using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboCultivoEval : cboBase
    {
        public cboCultivoEval()
        {
            InitializeComponent();
        }

        public cboCultivoEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarCultivoEval();
        }

        public void cargarCultivoEval()
        {
            clsCNEvalCred obj = new clsCNEvalCred();
            DataTable  dtResp = obj.CNListarCultivo();
            this.DisplayMember = "cCultivoEval";
            this.ValueMember = "idCultivoEval";
            this.DataSource = dtResp;
        }

    }
}
