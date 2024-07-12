using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoAmbito : cboBase
    {
        public cboTipoAmbito()
        {
            InitializeComponent();
        }

        public cboTipoAmbito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoAmbito ListaTipoAmbito = new clsCNTipoAmbito();

            DataTable tbTipoAmbito = ListaTipoAmbito.CNLisTipoAmbito();
            this.DataSource = tbTipoAmbito;
            this.ValueMember = tbTipoAmbito.Columns[0].ToString();
            this.DisplayMember = tbTipoAmbito.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}