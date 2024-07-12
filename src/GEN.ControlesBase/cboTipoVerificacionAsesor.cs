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
    public partial class cboTipoVerificacionAsesor : cboBase
    {
        clsCNVisita cnVisita;
        public cboTipoVerificacionAsesor()
        {
            InitializeComponent();
            cnVisita = new clsCNVisita();
        }

        public cboTipoVerificacionAsesor(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cnVisita = new clsCNVisita();
            cargar(false);
        }
        public void cargar(Boolean lTodos)
        {
            DataTable dt = cnVisita.CNListaTipoVerificacionAsesor(lTodos);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
