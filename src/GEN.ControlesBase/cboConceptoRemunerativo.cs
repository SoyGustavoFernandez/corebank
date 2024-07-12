using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboConceptoRemunerativo : cboBase
    {
        clsCNConceptoRemunerativo objConceptoRemunerativo = new clsCNConceptoRemunerativo();
        
        public cboConceptoRemunerativo()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboConceptoRemunerativo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarConceptoTipoPlanilla(int idTipoPlanilla)
        {
            DataTable dtConceptoRemunerativo = objConceptoRemunerativo.CNListarConceptoTipoPlanilla(idTipoPlanilla);
            dtConceptoRemunerativo.DefaultView.RowFilter = ("lVigente = 1");
            this.DataSource = dtConceptoRemunerativo;
            this.ValueMember = dtConceptoRemunerativo.Columns["idConcepto"].ToString();
            this.DisplayMember = dtConceptoRemunerativo.Columns["cConcepto"].ToString();
        }
    }
}
