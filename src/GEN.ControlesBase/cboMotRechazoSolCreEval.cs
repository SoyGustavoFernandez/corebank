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
    public partial class cboMotRechazoSolCreEval : cboBase
    {
        clsCNMotivoRechazoSolCreEval cnMotivo = new clsCNMotivoRechazoSolCreEval();
        
        public cboMotRechazoSolCreEval()
        {
            InitializeComponent();
        }

        public cboMotRechazoSolCreEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos();
        }

        public void cargarDatos()
        {
            DataTable dt = cnMotivo.CNlistaMotivos(2); // 0: todos; 1: obteniendo solo los no vigentes; 2:obteniendo todos los vigente
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
