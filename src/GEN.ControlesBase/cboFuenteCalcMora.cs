using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboFuenteCalcMora : cboBase
    {
        public cboFuenteCalcMora()
        {
            InitializeComponent();
        }

        public cboFuenteCalcMora(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            this.ValueMember = "idFuenteCalcMora";
            this.DisplayMember = "cFuenteCalcMora";
            this.DataSource = new clsCNTipCalcMora().CNGetTipCalcMora();
        }
    }
}
