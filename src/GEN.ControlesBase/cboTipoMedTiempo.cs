using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoMedTiempo : cboBase
    {
        clsCNFuentesIngreso objFuenteIngr = new clsCNFuentesIngreso();
        public cboTipoMedTiempo()
        {
            InitializeComponent();
        }

        public cboTipoMedTiempo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtMedTiempo = objFuenteIngr.CNListarTipoMedTiempo();
            this.DataSource = dtMedTiempo;
            this.ValueMember = dtMedTiempo.Columns["idMedicTiempo"].ToString();
            this.DisplayMember = dtMedTiempo.Columns["cMedicTiempo"].ToString();
        }
    }
}
