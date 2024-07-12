using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboMotivoMoraRiesgos : cboBase
    {
        clsCNVisita cnVisita;
        public cboMotivoMoraRiesgos()
        {
            InitializeComponent();
            cnVisita = new clsCNVisita();
        }

        public cboMotivoMoraRiesgos(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cnVisita = new clsCNVisita();
            cargar(false);
        }
        public void cargar(Boolean lTodos)
        {
            DataTable dt = cnVisita.CNListaMotivoMoraRiesgos(lTodos);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
