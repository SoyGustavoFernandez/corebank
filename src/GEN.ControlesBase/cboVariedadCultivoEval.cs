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
    public partial class cboVariedadCultivoEval : cboBase
    {
        public cboVariedadCultivoEval()
        {
            InitializeComponent();
        }

        public cboVariedadCultivoEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargaVariedadPorCultivo(int idCultivoEval)
        {
            clsCNEvalCred obj = new clsCNEvalCred();
            DataTable dtResp = obj.CNListarVariedadPorCultivo(idCultivoEval);
            this.DisplayMember = "cVariedadCultivoEval";
            this.ValueMember = "idVariedadCultivoEval";
            this.DataSource = dtResp;
        }
    }
}
