using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboModalidadContrato : cboBase
    {
        clsCNConceptoRemunerativo ListModCont = new clsCNConceptoRemunerativo();
        public DataTable dtModContrato;
        
        public cboModalidadContrato()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboModalidadContrato(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            dtModContrato = ListModCont.CNListaModalidadContrato();

            this.DataSource = dtModContrato;
            this.ValueMember = dtModContrato.Columns[0].ToString();
            this.DisplayMember = dtModContrato.Columns[1].ToString();
        }        
    }
}
