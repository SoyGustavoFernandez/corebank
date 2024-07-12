using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboActividadPorEtapaCultivoEval : cboBase
    {
        public cboActividadPorEtapaCultivoEval()
        {
            InitializeComponent();
        }

        public cboActividadPorEtapaCultivoEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargarDatos(int idEtapaCultivo)
        {
            DataTable dt = new clsCNEvalAgrico().obtenerActividadesPorEtapaCultivo(idEtapaCultivo);
            this.ValueMember = "idEtapaCultivo";
            this.DisplayMember = "cEtapaCultivo";
            this.DataSource = dt;
        }
    }
}
