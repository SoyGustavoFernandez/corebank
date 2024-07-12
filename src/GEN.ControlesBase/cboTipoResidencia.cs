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
    public partial class cboTipoResidencia : cboBase
    {
        public cboTipoResidencia()
        {
            InitializeComponent();
        }

        public cboTipoResidencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoResidencia objTipoResidencia = new clsCNTipoResidencia();
            DataTable dtTipoResidencia = objTipoResidencia.CNListaTipoResidencia();
            this.DataSource = dtTipoResidencia;
            this.ValueMember = dtTipoResidencia.Columns[0].ToString();
            this.DisplayMember = dtTipoResidencia.Columns[1].ToString();

        }
    }
}
