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
    public partial class cboMagnitudEmpresarial : cboBase
    {
        clsCNMagnitudEmpresarial objMagnitud = new clsCNMagnitudEmpresarial();
        public cboMagnitudEmpresarial()
        {
            InitializeComponent();
        }

        public cboMagnitudEmpresarial(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargarDatos(0);
        }

        public void cargarDatos(int idTipoPersona)
        {
            DataTable dtMagnitud = objMagnitud.CNListaMagnitudEmpresarial(idTipoPersona);
            this.DataSource = dtMagnitud;
            this.ValueMember = dtMagnitud.Columns["idMagnitud"].ToString();
            this.DisplayMember = dtMagnitud.Columns["cMagnitudEmpresarial"].ToString();
        }
    }
}
