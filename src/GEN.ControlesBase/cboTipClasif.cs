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
    public partial class cboTipClasif : cboBase
    {
        public cboTipClasif()
        {
            InitializeComponent();
        }

        public cboTipClasif(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void CargarClasificacion(int cTipoFiltro)
        {
            clsCNTipClasif ListaTipClas = new clsCNTipClasif();
            DataTable tbTipClas = ListaTipClas.ListaTipClasificacion(cTipoFiltro);            
            this.ValueMember = tbTipClas.Columns[0].ToString();
            this.DisplayMember = tbTipClas.Columns[1].ToString();
            this.DataSource = tbTipClas;
        }
    }
}
