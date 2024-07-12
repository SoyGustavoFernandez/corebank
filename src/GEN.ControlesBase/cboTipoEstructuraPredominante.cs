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
    public partial class cboTipoEstructuraPredominante : cboBase
    {
        public cboTipoEstructuraPredominante()
        {
            InitializeComponent();
        }

        public cboTipoEstructuraPredominante(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoEstructuraPredominante ListaEstrPred = new clsCNTipoEstructuraPredominante();
            DataTable tbEstructuraPred = ListaEstrPred.ListaEstructuraPredominante();
            this.DataSource = tbEstructuraPred;
            this.ValueMember = tbEstructuraPred.Columns[0].ToString();
            this.DisplayMember = tbEstructuraPred.Columns[2].ToString();
        }

    }//end class

}
