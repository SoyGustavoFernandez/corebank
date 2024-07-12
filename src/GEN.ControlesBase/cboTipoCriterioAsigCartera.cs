using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoCriterioAsigCartera : cboBase
    {
        clsCNTipoCriteAsigCarteraRecu cnTipoCriteAsigCarteraRecu = new clsCNTipoCriteAsigCarteraRecu();
        public cboTipoCriterioAsigCartera()
        {
            InitializeComponent();
        }

        public cboTipoCriterioAsigCartera(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dtResultado = cnTipoCriteAsigCarteraRecu.listarTipoCriteAsigCarteRecu();
            this.DataSource = dtResultado;
            this.ValueMember = dtResultado.Columns[0].ToString();
            this.DisplayMember = dtResultado.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
